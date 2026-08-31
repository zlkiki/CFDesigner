"""
FastAPI REST API Routes for CFDesigner
Provides endpoints for CAD DXF parsing, section wizard, geometric properties,
FSM elastic buckling, KDS 14 31 10 DSM design checks, and A4 reports.
"""

from fastapi import APIRouter, UploadFile, File, Form, HTTPException
from pydantic import BaseModel, Field
from typing import List, Optional, Dict, Any
import tempfile
import os
import math
import numpy as np

from ..cad.dxf_reader import DXFReader, DXFPolyline, DXFVertex
from ..cad.part_mesher import PartMesher, SectionGeometry, Element
from ..geometry.gross_properties import SectionPropertiesCalculator, GrossProperties
from ..geometry.section_wizard import SectionWizard
from ..solver.strip_assembler import StripAssembler
from ..solver.signature_curve import SignatureCurveAnalyzer, BucklingCurveResult
from ..solver.eigen_solver import FSMEigenSolver
from ..design.dsm_compression import DSMCompression, CompressionDesignResult
from ..design.dsm_flexure import DSMFlexure, FlexureDesignResult
from ..design.shear_and_crippling import WebShearAndCrippling, ShearCripplingResult
from ..design.beam_column import BeamColumnInteraction, InteractionResult
from ..report.html_report import HTMLReportGenerator

router = APIRouter(prefix="/api")


# ---------------------------------------------------------
# Pydantic Request & Response Models
# ---------------------------------------------------------

class WizardRequest(BaseModel):
    shape_type: str = "C" # C, Z, HAT, TUBE, ANGLE, DECK
    h: float = 150.0      # Depth (mm)
    b: float = 65.0       # Flange width (mm)
    c: float = 20.0       # Lip length (mm)
    t: float = 2.0        # Thickness (mm)
    r: float = 2.0        # Inside radius (mm)
    b_top: Optional[float] = 60.0
    b_bot: Optional[float] = 40.0
    pitch: Optional[float] = 200.0


class ElementDTO(BaseModel):
    elem_id: int
    x0: float
    y0: float
    x1: float
    y1: float
    length: float
    angle: float
    thickness: float
    radius: float = 0.0


class FSMRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float
    load_type: str = "compression" # compression, bending_x, bending_y
    yield_stress: float = 345.0    # MPa (Fy)
    elastic_modulus: float = 203000.0 # MPa (E)
    poisson_ratio: float = 0.3
    l_min: float = 10.0            # mm
    l_max: float = 5000.0          # mm
    num_points: int = 35
    member_length: float = 3000.0  # mm


class DesignCheckRequest(BaseModel):
    # Cross-Section & Material
    elements: List[ElementDTO]
    thickness: float
    yield_stress: float = 345.0     # MPa (Fy)
    elastic_modulus: float = 203000.0 # MPa (E)
    
    # Member Length & End Conditions
    length_x: float = 3000.0        # mm (Lx)
    length_y: float = 3000.0        # mm (Ly)
    length_t: float = 3000.0        # mm (Lt)
    kx: float = 1.0
    ky: float = 1.0
    kt: float = 1.0
    cb: float = 1.0
    
    # Applied Factored Loads (LRFD / LSD)
    pu: float = 50.0                # kN (Required axial compression)
    mux: float = 5.0                # kN·m (Required bending about major axis)
    muy: float = 0.0                # kN·m (Required bending about minor axis)
    vu: float = 15.0                # kN (Required shear)
    
    # FSM Buckling loads (if overridden or 0 for auto-calc)
    p_crl: Optional[float] = 0.0
    p_crd: Optional[float] = 0.0
    p_cre: Optional[float] = 0.0


# ---------------------------------------------------------
# Helper Functions
# ---------------------------------------------------------

def elements_from_dto(dtos: List[ElementDTO], thickness: float) -> SectionGeometry:
    elems = []
    total_len = 0.0
    for d in dtos:
        e = Element(
            elem_id=d.elem_id,
            x0=d.x0,
            y0=d.y0,
            x1=d.x1,
            y1=d.y1,
            length=d.length,
            angle=d.angle,
            thickness=d.thickness if d.thickness > 0 else thickness,
            radius=d.radius
        )
        elems.append(e)
        total_len += d.length
    return SectionGeometry(elements=elems, thickness=thickness, total_length=total_len)


def serialize_geometry(geom: SectionGeometry, props: GrossProperties) -> Dict[str, Any]:
    elem_list = []
    for e in geom.elements:
        elem_list.append({
            "elem_id": e.elem_id,
            "x0": round(e.x0, 4),
            "y0": round(e.y0, 4),
            "x1": round(e.x1, 4),
            "y1": round(e.y1, 4),
            "length": round(e.length, 4),
            "angle": round(e.angle, 4),
            "thickness": round(e.thickness, 4),
            "radius": round(e.radius, 4),
        })

    return {
        "geometry": {
            "thickness": round(geom.thickness, 4),
            "is_closed": geom.is_closed,
            "total_length": round(geom.total_length, 4),
            "elements": elem_list,
        },
        "properties": {
            "area": round(props.area, 2),
            "weight": round(props.area * 7850.0 / 1e6, 3), # kg/m
            "xcg": round(props.xcg, 3),
            "ycg": round(props.ycg, 3),
            "ix": round(props.ix, 2),
            "iy": round(props.iy, 2),
            "ixy": round(props.ixy, 2),
            "rx": round(props.rx, 3),
            "ry": round(props.ry, 3),
            "theta_p": round(props.theta_p, 3),
            "i1": round(props.i1, 2),
            "i2": round(props.i2, 2),
            "r1": round(props.r1, 3),
            "r2": round(props.r2, 3),
            "sx_top": round(props.sx_top, 2),
            "sx_bot": round(props.sx_bot, 2),
            "sy_right": round(props.sy_right, 2),
            "sy_left": round(props.sy_left, 2),
            "j": round(props.j, 2),
            "cw": round(props.cw, 2),
            "x0": round(props.x0, 3),
            "y0": round(props.y0, 3),
            "ro": round(props.ro, 3),
            "beta_w": round(props.beta_w, 3),
        }
    }


# ---------------------------------------------------------
# API Endpoints
# ---------------------------------------------------------

@router.post("/section/wizard")
async def create_wizard_section(req: WizardRequest):
    """
    Creates a standard CFS cross section using SectionWizard.
    """
    stype = req.shape_type.upper()
    if stype == "C":
        geom = SectionWizard.create_c_section(req.h, req.b, req.c, req.t, req.r)
    elif stype == "Z":
        geom = SectionWizard.create_z_section(req.h, req.b, req.c, req.t, req.r)
    elif stype == "HAT":
        geom = SectionWizard.create_hat_section(req.h, req.b_top or req.b, req.b_bot or req.b, req.c, req.t)
    elif stype == "TUBE":
        geom = SectionWizard.create_tube_section(req.h, req.b, req.t)
    elif stype == "ANGLE":
        geom = SectionWizard.create_angle_section(req.h, req.b, req.t)
    elif stype == "DECK":
        geom = SectionWizard.create_deck_section(req.h, req.pitch or 200.0, req.b_top or 60.0, req.b_bot or 40.0, req.t)
    else:
        geom = SectionWizard.create_c_section(req.h, req.b, req.c, req.t, req.r)

    props = SectionPropertiesCalculator.calculate(geom)
    return serialize_geometry(geom, props)


@router.post("/section/upload-dxf")
async def upload_dxf(file: UploadFile = File(...), default_thickness: float = Form(2.0), unit: str = Form("mm")):
    """
    Parses an uploaded DXF file and returns meshed section geometry and properties.
    """
    if not file.filename.lower().endswith(".dxf"):
        raise HTTPException(status_code=400, detail="Only .dxf files are supported.")

    suffix = os.path.splitext(file.filename)[1]
    with tempfile.NamedTemporaryFile(delete=False, suffix=suffix) as tmp:
        content = await file.read()
        tmp.write(content)
        tmp_path = tmp.name

    try:
        reader = DXFReader(target_unit=unit)
        polylines = reader.read_file(tmp_path)
        if not polylines:
            raise HTTPException(status_code=400, detail="No 2D Polylines found in the DXF file.")

        # Take first valid polyline
        geom = PartMesher.mesh_polyline(polylines[0], default_thickness=default_thickness)
        props = SectionPropertiesCalculator.calculate(geom)
        return serialize_geometry(geom, props)
    finally:
        if os.path.exists(tmp_path):
            os.remove(tmp_path)


@router.post("/section/properties")
async def calculate_properties(elements: List[ElementDTO], thickness: float):
    """
    Computes geometric properties from element list.
    """
    geom = elements_from_dto(elements, thickness)
    props = SectionPropertiesCalculator.calculate(geom)
    return serialize_geometry(geom, props)


@router.post("/fsm/solve")
async def solve_fsm(req: FSMRequest):
    """
    Performs FSM elastic buckling signature curve analysis.
    Also extracts 3D mode shape displacements for Local, Distortional, and Global modes.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(
        geom=geom,
        props=props,
        e_modulus=req.elastic_modulus,
        poisson=req.poisson_ratio
    )

    analyzer = SignatureCurveAnalyzer(assembler)
    result = analyzer.analyze(
        l_min=req.l_min,
        l_max=req.l_max,
        num_points=req.num_points,
        load_type=req.load_type,
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    # Compute 3D Mode Displacement vectors for visualization
    # 1. Local Mode Shape
    l_loc = result.l_local if result.l_local > 0 else 50.0
    ke_loc, kg_loc = assembler.assemble_matrices(half_wavelength=l_loc)
    lf_loc, mode_loc = FSMEigenSolver.solve_min_eigenvalue(ke_loc, kg_loc)

    # 2. Distortional Mode Shape
    l_dist = result.l_distortional if result.l_distortional > 0 else 250.0
    ke_dist, kg_dist = assembler.assemble_matrices(half_wavelength=l_dist)
    lf_dist, mode_dist = FSMEigenSolver.solve_min_eigenvalue(ke_dist, kg_dist)

    # 3. Global Mode Shape
    l_glob = req.member_length if req.member_length > 0 else 3000.0
    ke_glob, kg_glob = assembler.assemble_matrices(half_wavelength=l_glob)
    lf_glob, mode_glob = FSMEigenSolver.solve_min_eigenvalue(ke_glob, kg_glob)

    # Convert mode shapes to serializable node displacement arrays
    nodes_data = []
    for node_idx, n in enumerate(assembler.nodes):
        # 4 DOFs per node: u, v, w, theta
        dof_start = node_idx * 4
        loc_disp = mode_loc[dof_start:dof_start+4].tolist() if mode_loc is not None else [0,0,0,0]
        dist_disp = mode_dist[dof_start:dof_start+4].tolist() if mode_dist is not None else [0,0,0,0]
        glob_disp = mode_glob[dof_start:dof_start+4].tolist() if mode_glob is not None else [0,0,0,0]

        nodes_data.append({
            "node_idx": node_idx,
            "x": round(n.x, 4),
            "y": round(n.y, 4),
            "local_mode": [round(val, 5) for val in loc_disp],
            "dist_mode": [round(val, 5) for val in dist_disp],
            "glob_mode": [round(val, 5) for val in glob_disp],
        })

    # Prepare signature curve chart data
    chart_points = []
    for pt in result.points:
        chart_points.append({
            "length": round(pt.length, 2),
            "load_factor": round(pt.load_factor, 4),
            "p_cr": round(pt.critical_load / 1000.0, 2), # kN
            "m_cr": round(pt.critical_moment / 1e6, 3), # kN·m
        })

    strips_data = [
        {
            "elem_id": s.elem_id,
            "node_i": s.node_i,
            "node_j": s.node_j,
            "thickness": s.thickness,
            "width": round(s.width, 3),
            "alpha": round(s.alpha, 4)
        } for s in assembler.strips
    ]

    return {
        "signature_curve": chart_points,
        "critical_modes": {
            "p_crl": round(result.p_crl / 1000.0, 2), # kN
            "l_local": round(result.l_local, 1),      # mm
            "p_crd": round(result.p_crd / 1000.0, 2), # kN
            "l_distortional": round(result.l_distortional, 1), # mm
            "p_cre": round(result.p_cre / 1000.0, 2), # kN
            "l_global": round(result.l_global, 1),    # mm
        },
        "nodes": nodes_data,
        "strips": strips_data,
    }


@router.post("/design/check")
async def check_design(req: DesignCheckRequest):
    """
    Performs comprehensive KDS 14 31 10 & AISI S100 Direct Strength Method (DSM) design checks.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    # 1. FSM Buckling Loads (Compute if not provided)
    assembler = StripAssembler(geom=geom, props=props, e_modulus=req.elastic_modulus)
    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        yield_stress=req.yield_stress,
        member_length=max(req.length_x, req.length_y, req.length_t)
    )

    p_crl = req.p_crl * 1000.0 if (req.p_crl and req.p_crl > 0) else fsm_res.p_crl
    p_crd = req.p_crd * 1000.0 if (req.p_crd and req.p_crd > 0) else fsm_res.p_crd
    p_cre = req.p_cre * 1000.0 if (req.p_cre and req.p_cre > 0) else fsm_res.p_cre

    # 2. Compression Check
    comp_res = DSMCompression.design_column(
        ag=props.area,
        fy=req.yield_stress,
        p_cre=p_cre,
        p_crl=p_crl,
        p_crd=p_crd
    )
    comp_dc = (req.pu * 1000.0) / comp_res.phi_pn if comp_res.phi_pn > 1e-6 else 0.0

    # 3. Flexure Check
    py = props.area * req.yield_stress
    m_y = props.sx_top * req.yield_stress
    m_crl = (p_crl / py) * m_y if py > 0 else m_y
    m_crd = (p_crd / py) * m_y if py > 0 else m_y
    m_cre = (p_cre / py) * m_y if py > 0 else m_y

    flex_res = DSMFlexure.design_beam(
        sf=props.sx_top,
        fy=req.yield_stress,
        m_cre=m_cre,
        m_crl=m_crl,
        m_crd=m_crd
    )
    flex_dc = (req.mux * 1e6) / flex_res.phi_mn if flex_res.phi_mn > 1e-6 else 0.0

    # 4. Shear & Web Crippling Check
    h_w = 0.0
    for elem in geom.elements:
        dy = abs(elem.y1 - elem.y0)
        if dy > h_w:
            h_w = dy

    v_n = WebShearAndCrippling.calculate_shear(
        h=h_w if h_w > 0 else 100.0,
        t=req.thickness,
        fy=req.yield_stress,
        e_mod=req.elastic_modulus
    )
    phi_vn = WebShearAndCrippling.PHI_V * v_n
    shear_dc = (req.vu * 1000.0) / phi_vn if phi_vn > 1e-6 else 0.0

    p_nc = WebShearAndCrippling.calculate_web_crippling(
        h=h_w if h_w > 0 else 100.0,
        t=req.thickness,
        r=2.0,
        n_bearing=50.0,
        fy=req.yield_stress
    )
    phi_pnc = WebShearAndCrippling.PHI_W * p_nc

    # 5. P-M Interaction Check
    interaction = BeamColumnInteraction.check_interaction(
        pu=req.pu * 1000.0,
        phi_pn=comp_res.phi_pn,
        mux=req.mux * 1e6,
        phi_mnx=flex_res.phi_mn,
        muy=req.muy * 1e6,
        phi_mny=flex_res.phi_mn * 0.3,
        cmx=1.0,
        cmy=1.0
    )

    return {
        "compression": {
            "p_ne": round(comp_res.pne / 1000.0, 2), # kN
            "p_nl": round(comp_res.pnl / 1000.0, 2),
            "p_nd": round(comp_res.pnd / 1000.0, 2),
            "p_n": round(comp_res.pn / 1000.0, 2),
            "phi_pn": round(comp_res.phi_pn / 1000.0, 2),
            "dc_ratio": round(comp_dc, 3),
            "status": "OK" if comp_dc <= 1.0 else "NG",
            "governing_mode": comp_res.governing_mode,
        },
        "flexure": {
            "m_ne": round(flex_res.mne / 1e6, 3), # kN·m
            "m_nl": round(flex_res.mnl / 1e6, 3),
            "m_nd": round(flex_res.mnd / 1e6, 3),
            "m_n": round(flex_res.mn / 1e6, 3),
            "phi_mn": round(flex_res.phi_mn / 1e6, 3),
            "dc_ratio": round(flex_dc, 3),
            "status": "OK" if flex_dc <= 1.0 else "NG",
            "governing_mode": flex_res.governing_mode,
        },
        "shear": {
            "v_n": round(v_n / 1000.0, 2), # kN
            "phi_vn": round(phi_vn / 1000.0, 2),
            "dc_ratio": round(shear_dc, 3),
            "status": "OK" if shear_dc <= 1.0 else "NG",
        },
        "web_crippling": {
            "p_nc": round(p_nc / 1000.0, 2), # kN
            "phi_pnc": round(phi_pnc / 1000.0, 2),
        },
        "interaction": {
            "ratio": round(interaction.controlling_dcr, 3),
            "status": "OK" if interaction.is_safe else "NG",
            "formula_type": "식 (1.4-1)",
        }
    }


@router.post("/report/html")
async def generate_report_html(data: Dict[str, Any]):
    """
    Generates high-quality A4 Engineering Calculation Sheet in HTML format.
    """
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}
