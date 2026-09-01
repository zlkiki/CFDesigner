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
from ..geometry.geometry_editor import GeometryEditor
from ..geometry.library_parser import CFSLibraryParser, ColdWorkCalculator, STANDARD_MATERIALS
from ..geometry.effective_width import EffectiveWidthSolver, EffectivePropertiesResult
from ..solver.strip_assembler import StripAssembler
from ..solver.signature_curve import SignatureCurveAnalyzer, BucklingCurveResult, BucklingPoint
from ..solver.eigen_solver import FSMEigenSolver
from ..design.dsm_compression import DSMCompression, CompressionDesignResult
from ..design.dsm_flexure import DSMFlexure, FlexureDesignResult
from ..design.shear_and_crippling import WebShearAndCrippling, ShearCripplingResult, WebCripplingResult
from ..design.quick_design import QuickDesignEngine, QuickDesignResult
from ..design.beam_column import BeamColumnInteraction, InteractionResult
from ..solver.frame1d import Frame1DSolver, Frame1DAnalysisResult
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


class ElementsUpdateRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0


class TransformRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0
    transform_type: str = "rotate_90_cw" # rotate_90_cw, rotate_90_ccw, rotate_angle, mirror_h, mirror_v, align_cg, align_min
    angle_deg: Optional[float] = 0.0
    center_at_cg: Optional[bool] = True


class InsertRibsRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0
    target_elem_id: int = 1
    rib_type: str = "V" # V, TRAPEZOID
    rib_width: float = 20.0
    rib_depth: float = 10.0
    num_ribs: int = 1
    rib_radius: float = 0.0


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


def _calculate_and_bundle_section(geom: SectionGeometry) -> Dict[str, Any]:
    props = SectionPropertiesCalculator.calculate(geom)
    return serialize_geometry(geom, props)


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


@router.post("/section/elements")
async def update_elements_endpoint(req: ElementsUpdateRequest):
    """
    Reconstructs section geometry from modified element table, calculates properties, and returns updated geometry.
    """
    elem_dicts = [e.model_dump() for e in req.elements]
    geom = GeometryEditor.update_elements(elem_dicts, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)
    return serialize_geometry(geom, props)


@router.post("/section/transform")
async def transform_section_endpoint(req: TransformRequest):
    """
    Performs geometric transformation: 90-degree rotate, arbitrary rotate, mirror H/V, align CG/origin.
    """
    elem_dicts = [e.model_dump() for e in req.elements]
    geom = GeometryEditor.update_elements(elem_dicts, req.thickness)
    
    tt = req.transform_type.lower()
    center_at_cg = req.center_at_cg if req.center_at_cg is not None else True

    if tt == "rotate_90_cw":
        geom = GeometryEditor.rotate_section(geom, -math.pi / 2.0, center_at_cg=center_at_cg)
    elif tt == "rotate_90_ccw":
        geom = GeometryEditor.rotate_section(geom, math.pi / 2.0, center_at_cg=center_at_cg)
    elif tt == "rotate_angle":
        ang_rad = math.radians(req.angle_deg or 0.0)
        geom = GeometryEditor.rotate_section(geom, ang_rad, center_at_cg=center_at_cg)
    elif tt in ("mirror_h", "mirror_x"):
        geom = GeometryEditor.mirror_section(geom, axis="horizontal", center_at_cg=center_at_cg)
    elif tt in ("mirror_v", "mirror_y"):
        geom = GeometryEditor.mirror_section(geom, axis="vertical", center_at_cg=center_at_cg)
    elif tt == "align_cg":
        geom = GeometryEditor.align_to_origin(geom, align_type="cg")
    elif tt == "align_min":
        geom = GeometryEditor.align_to_origin(geom, align_type="min")
    else:
        raise HTTPException(status_code=400, detail=f"Unknown transform type: {req.transform_type}")

    props = SectionPropertiesCalculator.calculate(geom)
    return serialize_geometry(geom, props)


@router.post("/section/insert-ribs")
async def insert_ribs_endpoint(req: InsertRibsRequest):
    """
    Inserts intermediate stiffener ribs into target element and re-meshes geometry.
    """
    elem_dicts = [e.model_dump() for e in req.elements]
    geom = GeometryEditor.update_elements(elem_dicts, req.thickness)
    
    geom = GeometryEditor.insert_rib(
        geom=geom,
        target_elem_id=req.target_elem_id,
        rib_type=req.rib_type,
        rib_width=req.rib_width,
        rib_depth=req.rib_depth,
        num_ribs=req.num_ribs,
        rib_radius=req.rib_radius
    )
    
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
    # 1. Local Mode Shape (Mode 1, Mode 2, Mode 3 at local wavelength)
    l_loc = result.l_local if result.l_local > 0 else 50.0
    ke_loc, kg_loc = assembler.assemble_matrices(half_wavelength=l_loc)
    modes_loc = FSMEigenSolver.solve_eigenvalues(ke_loc, kg_loc, num_modes=3)
    mode_loc_1 = modes_loc[0][1] if len(modes_loc) > 0 else None
    mode_loc_2 = modes_loc[1][1] if len(modes_loc) > 1 else mode_loc_1
    mode_loc_3 = modes_loc[2][1] if len(modes_loc) > 2 else mode_loc_2

    # 2. Distortional Mode Shape
    l_dist = result.l_distortional if result.l_distortional > 0 else 250.0
    ke_dist, kg_dist = assembler.assemble_matrices(half_wavelength=l_dist)
    modes_dist = FSMEigenSolver.solve_eigenvalues(ke_dist, kg_dist, num_modes=3)
    mode_dist_1 = modes_dist[0][1] if len(modes_dist) > 0 else None
    mode_dist_2 = modes_dist[1][1] if len(modes_dist) > 1 else mode_dist_1
    mode_dist_3 = modes_dist[2][1] if len(modes_dist) > 2 else mode_dist_2

    # 3. Global Mode Shape
    l_glob = req.member_length if req.member_length > 0 else 3000.0
    ke_glob, kg_glob = assembler.assemble_matrices(half_wavelength=l_glob)
    modes_glob = FSMEigenSolver.solve_eigenvalues(ke_glob, kg_glob, num_modes=3)
    mode_glob_1 = modes_glob[0][1] if len(modes_glob) > 0 else None
    mode_glob_2 = modes_glob[1][1] if len(modes_glob) > 1 else mode_glob_1
    mode_glob_3 = modes_glob[2][1] if len(modes_glob) > 2 else mode_glob_2

    # Convert mode shapes to serializable node displacement arrays
    nodes_data = []
    for node_idx, n in enumerate(assembler.nodes):
        # 4 DOFs per node: u, v, w, theta
        dof_start = node_idx * 4
        loc_disp_1 = mode_loc_1[dof_start:dof_start+4].tolist() if mode_loc_1 is not None else [0,0,0,0]
        loc_disp_2 = mode_loc_2[dof_start:dof_start+4].tolist() if mode_loc_2 is not None else loc_disp_1
        loc_disp_3 = mode_loc_3[dof_start:dof_start+4].tolist() if mode_loc_3 is not None else loc_disp_2

        dist_disp_1 = mode_dist_1[dof_start:dof_start+4].tolist() if mode_dist_1 is not None else [0,0,0,0]
        dist_disp_2 = mode_dist_2[dof_start:dof_start+4].tolist() if mode_dist_2 is not None else dist_disp_1
        dist_disp_3 = mode_dist_3[dof_start:dof_start+4].tolist() if mode_dist_3 is not None else dist_disp_2

        glob_disp_1 = mode_glob_1[dof_start:dof_start+4].tolist() if mode_glob_1 is not None else [0,0,0,0]
        glob_disp_2 = mode_glob_2[dof_start:dof_start+4].tolist() if mode_glob_2 is not None else glob_disp_1
        glob_disp_3 = mode_glob_3[dof_start:dof_start+4].tolist() if mode_glob_3 is not None else glob_disp_2

        nodes_data.append({
            "node_idx": node_idx,
            "x": round(n.x, 4),
            "y": round(n.y, 4),
            "local_mode": [round(val, 5) for val in loc_disp_1],
            "local_mode_2": [round(val, 5) for val in loc_disp_2],
            "local_mode_3": [round(val, 5) for val in loc_disp_3],
            "dist_mode": [round(val, 5) for val in dist_disp_1],
            "dist_mode_2": [round(val, 5) for val in dist_disp_2],
            "dist_mode_3": [round(val, 5) for val in dist_disp_3],
            "glob_mode": [round(val, 5) for val in glob_disp_1],
            "glob_mode_2": [round(val, 5) for val in glob_disp_2],
            "glob_mode_3": [round(val, 5) for val in glob_disp_3],
        })

    # Prepare signature curve chart data (with multi-mode series)
    chart_points = []
    mode_1_curve = []
    mode_2_curve = []
    mode_3_curve = []

    for pt in result.points:
        chart_points.append({
            "length": round(pt.length, 2),
            "load_factor": round(pt.load_factor, 4),
            "p_cr": round(pt.critical_load / 1000.0, 2), # kN
            "m_cr": round(pt.critical_moment / 1e6, 3), # kN·m
            "mode_lfs": [round(lf, 4) for lf in pt.mode_load_factors],
            "mode_pcrs": [round(p / 1000.0, 2) for p in pt.mode_critical_loads],
            "mode_mcrs": [round(m / 1e6, 3) for m in pt.mode_critical_moments],
        })

        if pt.mode_load_factors:
            mode_1_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[0], 4)})
            if len(pt.mode_load_factors) > 1:
                mode_2_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[1], 4)})
            if len(pt.mode_load_factors) > 2:
                mode_3_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[2], 4)})

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
        "curves": {
            "mode_1": mode_1_curve,
            "mode_2": mode_2_curve,
            "mode_3": mode_3_curve,
        },
        "critical_modes": {
            "load_type": req.load_type,
            "p_crl": round(result.p_crl / 1000.0, 2), # kN
            "l_local": round(result.l_local, 1),      # mm
            "p_crd": round(result.p_crd / 1000.0, 2), # kN
            "l_distortional": round(result.l_distortional, 1), # mm
            "p_cre": round(result.p_cre / 1000.0, 2), # kN
            "l_global": round(result.l_global, 1),    # mm
            "m_crl": round(result.m_crl / 1e6, 3),    # kN·m
            "m_crd": round(result.m_crd / 1e6, 3),    # kN·m
            "m_cre": round(result.m_cre / 1e6, 3),    # kN·m
            "lf_local": round(result.lf_local, 4),
            "lf_distortional": round(result.lf_distortional, 4),
            "lf_global": round(result.lf_global, 4),
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
    Dispatches to summary or detailed report based on options.report_mode.
    """
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}


@router.post("/report/summary")
async def generate_report_summary(data: Dict[str, Any]):
    """
    Generates 1-2 page executive summary report HTML.
    """
    data["options"] = data.get("options", {})
    data["options"]["report_mode"] = "summary"
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}


@router.post("/report/detailed")
async def generate_report_detailed(data: Dict[str, Any]):
    """
    Generates multi-page formal detailed calculation sheet HTML.
    """
    data["options"] = data.get("options", {})
    data["options"]["report_mode"] = "detailed"
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}


# =========================================================
# Phase 2: Section & Material Library Endpoints
# =========================================================

class ColdWorkRequest(BaseModel):
    base_fy: float = 345.0
    base_fu: float = 450.0
    r_inside: float = 2.0
    thickness: float = 1.5
    num_corners: int = 4
    total_length: float = 250.0


@router.get("/library/files")
async def get_library_files():
    """
    Returns the list of available .cfsl library files in original_source.
    """
from src.resource_helper import get_resource_path

@router.get("/library/list")
async def get_libraries():
    """
    Returns the list of available section library files (*.cfsl).
    """
    lib_dir = get_resource_path("original_source")
    if not os.path.exists(lib_dir) and os.path.exists("original_source"):
        lib_dir = "original_source"

    libs = []
    if os.path.exists(lib_dir):
        for f in sorted(os.listdir(lib_dir)):
            if f.lower().endswith(".cfsl"):
                name = os.path.splitext(f)[0]
                libs.append({"name": name, "filename": f, "path": os.path.join(lib_dir, f)})
    return {"libraries": libs}


@router.get("/library/sections")
async def get_library_sections(lib: str = "SSMA", type: Optional[str] = None, query: Optional[str] = None):
    """
    Returns sections in the specified library, with optional type and text filtering.
    """
    lib_dir = get_resource_path("original_source")
    file_path = os.path.join(lib_dir, f"{lib}.cfsl")
    if not os.path.exists(file_path):
        file_path = os.path.join("original_source", f"{lib}.cfsl")
    if not os.path.exists(file_path):
        raise HTTPException(status_code=404, detail=f"Library file {lib}.cfsl not found.")

    summary = CFSLibraryParser.get_library_summary(file_path)
    
    # Flatten sections or filter by type/query
    filtered_types = []
    for t in summary["types"]:
        if type and type.lower() not in t["name"].lower():
            continue
        
        matched_sections = []
        for s in t["sections"]:
            if query:
                q = query.lower()
                if q not in s["name"].lower() and q not in t["name"].lower():
                    continue
            matched_sections.append(s)
            
        filtered_types.append({
            "name": t["name"],
            "count": len(matched_sections),
            "sections": matched_sections
        })

    return {
        "library_name": summary["library_name"],
        "company": summary["company"],
        "types": filtered_types
    }


@router.get("/library/sections/{lib_name}/{offset}")
async def load_library_section(lib_name: str, offset: int):
    """
    Loads full geometric and mechanical properties of a library section by offset.
    """
    lib_dir = get_resource_path("original_source")
    file_path = os.path.join(lib_dir, f"{lib_name}.cfsl")
    if not os.path.exists(file_path):
        file_path = os.path.join("original_source", f"{lib_name}.cfsl")
    if not os.path.exists(file_path):
        raise HTTPException(status_code=404, detail=f"Library {lib_name}.cfsl not found.")

    try:
        geom = CFSLibraryParser.load_section(file_path, offset, to_metric=True)
        if not geom.elements:
            raise HTTPException(status_code=400, detail="Failed to parse section elements.")
        
        return _calculate_and_bundle_section(geom)
    except Exception as e:
        raise HTTPException(status_code=500, detail=f"Error loading section: {str(e)}")


@router.get("/library/materials")
async def get_material_presets():
    """
    Returns standard steel material presets (KDS/KS, ASTM, Stainless Steel).
    """
    return {"materials": STANDARD_MATERIALS}


@router.post("/material/cold-work")
async def calculate_cold_work(req: ColdWorkRequest):
    """
    Calculates cold-work forming yield strength increase (Fya)
    per AISI S100 Section A3.3.2 and KDS 14 31 10 3.3.2.
    """
    res = ColdWorkCalculator.calculate(
        base_fy=req.base_fy,
        base_fu=req.base_fu,
        r_inside=req.r_inside,
        thickness=req.thickness,
        num_corners=req.num_corners,
        total_length=req.total_length
    )
    return res


# ---------------------------------------------------------
# Phase 3: Advanced Design & Solver Endpoints
# ---------------------------------------------------------

class WebCripplingDetailedRequest(BaseModel):
    h: float = 150.0                # Web depth (mm)
    t: float = 2.0                  # Web thickness (mm)
    r: float = 2.0                  # Inside bend radius (mm)
    n_bearing: float = 50.0         # Bearing length N (mm)
    fy: float = 300.0               # Yield strength (MPa)
    condition: str = "IOF"          # "EOF", "IOF", "ETF", "ITF"
    fastened: bool = True           # Flange fastened
    stiffened: bool = True          # Stiffened flange (with lip)
    theta_deg: float = 90.0         # Web inclination angle
    ru: float = 0.0                 # Required reaction Ru (kN)


class QuickDesignSearchRequest(BaseModel):
    # Direct Force Overrides (Legacy & Advanced)
    pu: float = 0.0                 # Axial load Pu (kN)
    mux: float = 0.0                # Moment Mux (kNm)
    muy: float = 0.0                # Moment Muy (kNm)
    vu: float = 0.0                 # Shear force Vu (kN)
    length: float = 3000.0          # Span / Unbraced length (mm)
    fy: float = 345.0               # Yield strength (MPa)
    
    # Section Filtering (CFS frmQuickDesign)
    depth_filter: Optional[float] = None
    shape_type_filter: str = "All"  # "All", "S", "T"
    flange_filter: Optional[float] = None
    thickness_filter: Optional[float] = None
    punched: bool = False           # Web punching hole
    config: str = "Single"          # "Single", "Back-to-Back", "Face-to-Face"
    
    # Material Options
    cold_work: bool = False
    reserve: bool = False
    
    # Span & Spacing & Bracing
    span: Optional[float] = None    # Span length (mm)
    spacing: float = 400.0          # Joist/Stud spacing (mm)
    bracing: str = "Unbraced"       # "Unbraced", "Midpoint", "Third-point", "Quarter-point", "Fully Braced"
    
    # Applied Surface Loads
    dead_load: float = 0.0          # kN/m2 (psf)
    live_load: float = 0.0          # kN/m2 (psf)
    wind_load: float = 0.0          # kN/m2 (psf)
    dead_axial: float = 0.0         # kN (kips)
    live_axial: float = 0.0         # kN (kips)
    
    # Deflection Limits & Bearing
    deflection_live_limit: float = 360.0 # L/360
    deflection_total_limit: float = 240.0 # L/240
    bearing_length: float = 38.0    # mm (1.5" default)
    bearing_condition: str = "EOF"  # "EOF", "IOF", "ETF", "ITF"
    
    # Limits & Result count
    max_depth: Optional[float] = None
    max_weight: Optional[float] = None
    library: Optional[str] = None
    max_results: int = 15


class FSMCustomSweepRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0
    l_min: float = 10.0
    l_max: float = 10000.0
    steps: int = 60
    load_type: str = "compression"   # compression, bending_x, bending_y
    yield_stress: float = 345.0
    elastic_modulus: float = 205000.0
    poisson_ratio: float = 0.3
    member_length: float = 3000.0


class EffectiveWidthRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0
    stress_f: float = 300.0
    fy: float = 300.0
    moment_axis: str = "X"          # "X", "Y", "AXIAL"


@router.post("/design/web-crippling")
async def calculate_web_crippling_api(req: WebCripplingDetailedRequest):
    """
    Computes web crippling nominal and design capacities for 4 support conditions
    (EOF, IOF, ETF, ITF) per KDS 14 31 10 4.4 and AISI S100 G5.
    """
    res = WebShearAndCrippling.calculate_web_crippling_advanced(
        h=req.h,
        t=req.t,
        r=req.r,
        n_bearing=req.n_bearing,
        fy=req.fy,
        condition=req.condition,
        fastened=req.fastened,
        stiffened=req.stiffened,
        theta_deg=req.theta_deg,
        ru=req.ru
    )
    return res


@router.post("/design/quick-design")
async def quick_design_search_api(req: QuickDesignSearchRequest):
    """
    Scans library sections, executes DSM compression, flexure, shear,
    serviceability deflection, and web crippling design checks,
    and returns top candidates sorted by weight ascending.
    """
    res = QuickDesignEngine.search_optimal_sections(
        pu_kn=req.pu,
        mux_knm=req.mux,
        muy_knm=req.muy,
        vu_kn=req.vu,
        length_mm=req.length,
        fy_mpa=req.fy,
        depth_filter=req.depth_filter,
        shape_type_filter=req.shape_type_filter,
        flange_filter=req.flange_filter,
        thickness_filter=req.thickness_filter,
        punched=req.punched,
        config=req.config,
        cold_work=req.cold_work,
        reserve=req.reserve,
        span_mm=req.span if req.span is not None else req.length,
        spacing_mm=req.spacing,
        bracing=req.bracing,
        dead_load_kpa=req.dead_load,
        live_load_kpa=req.live_load,
        wind_load_kpa=req.wind_load,
        dead_axial_kn=req.dead_axial,
        live_axial_kn=req.live_axial,
        deflection_live_limit=req.deflection_live_limit,
        deflection_total_limit=req.deflection_total_limit,
        bearing_length_mm=req.bearing_length,
        bearing_condition=req.bearing_condition,
        max_depth_mm=req.max_depth,
        max_weight_kgm=req.max_weight,
        library_filter=req.library,
        max_results=req.max_results
    )
    return res


@router.post("/fsm/parameters")
async def fsm_custom_sweep_api(req: FSMCustomSweepRequest):
    """
    Executes FSM elastic buckling analysis with customized half-wavelength sweep range,
    number of steps, and stress distribution.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    gross_props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(
        geom=geom,
        props=gross_props,
        e_modulus=req.elastic_modulus,
        poisson=req.poisson_ratio
    )

    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        l_min=req.l_min,
        l_max=req.l_max,
        num_points=req.steps,
        load_type=req.load_type,
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    return {
        "curve": {
            "lengths": fsm_res.lengths,
            "load_factors": fsm_res.load_factors,
            "points": [
                {
                    "length": round(pt.length, 2),
                    "load_factor": round(pt.load_factor, 4),
                    "critical_load": round(pt.critical_load, 1),
                    "critical_moment": round(pt.critical_moment, 1)
                }
                for pt in fsm_res.points
            ]
        },
        "modes": {
            "load_type": req.load_type,
            "p_crl": round(fsm_res.p_crl / 1000.0, 2),
            "l_local": round(fsm_res.l_local, 1),
            "p_crd": round(fsm_res.p_crd / 1000.0, 2),
            "l_distortional": round(fsm_res.l_distortional, 1),
            "p_cre": round(fsm_res.p_cre / 1000.0, 2),
            "l_global": round(fsm_res.l_global, 1),
            "m_crl": round(fsm_res.m_crl / 1e6, 3),
            "m_crd": round(fsm_res.m_crd / 1e6, 3),
            "m_cre": round(fsm_res.m_cre / 1e6, 3),
            "lf_local": round(fsm_res.lf_local, 4),
            "lf_distortional": round(fsm_res.lf_distortional, 4),
            "lf_global": round(fsm_res.lf_global, 4),
        }
    }


@router.post("/section/effective")
async def calculate_section_effective_api(req: EffectiveWidthRequest):
    """
    Computes Winter effective width, reduced section properties (Ae, Ixe, Iye, delta_y),
    and 2D effective/void line segments.
    """
    raw_elems = [
        {
            "id": el.elem_id,
            "x1": el.x0, "y1": el.y0,
            "x2": el.x1, "y2": el.y1,
            "thickness": el.thickness if el.thickness > 0 else req.thickness
        }
        for el in req.elements
    ]

    res = EffectiveWidthSolver.analyze_section_effective(
        elements=raw_elems,
        stress_f=req.stress_f,
        moment_axis=req.moment_axis,
        fy=req.fy
    )
    return res


# ---------------------------------------------------------
# Phase 4: 1D Frame & Beam FEM Analysis Endpoints
# ---------------------------------------------------------

class Frame1DRunRequest(BaseModel):
    spans: List[Dict[str, Any]] = Field(default_factory=lambda: [{"length": 3000.0}])
    supports: List[Dict[str, Any]] = Field(default_factory=lambda: [{"location": 0.0, "type": "pin"}, {"location": 3000.0, "type": "roller"}])
    loads: List[Dict[str, Any]] = Field(default_factory=lambda: [{"load_type": "udl", "magnitude": 10.0, "x_start": 0.0, "x_end": 3000.0}])
    e_mod: float = 205000.0
    ix: float = 1e6
    area: float = 500.0
    self_weight_w: float = 0.0
    num_eval_points: int = 150


class TransferToDesignRequest(BaseModel):
    elements: List[ElementDTO]
    thickness: float = 2.0
    yield_stress: float = 345.0
    member_length: float = 3000.0
    max_forces: Dict[str, Any]


@router.post("/analysis/run")
async def run_frame1d_analysis_api(req: Frame1DRunRequest):
    """
    Executes 1D FEM matrix analysis for single span, continuous beams, and cantilevers.
    Returns reactions, continuous SFD, BMD, Deflection, and max forces.
    """
    res = Frame1DSolver.analyze(
        spans=req.spans,
        supports=req.supports,
        loads=req.loads,
        default_e=req.e_mod,
        default_ix=req.ix,
        default_area=req.area,
        self_weight_w=req.self_weight_w,
        num_eval_points=req.num_eval_points
    )
    return res


@router.post("/analysis/transfer-to-design")
async def transfer_to_design_api(req: TransferToDesignRequest):
    """
    Transfers maximum internal forces from 1D structural analysis directly into
    KDS 14 31 10 DSM member design check.
    """
    mf = req.max_forces
    pu_val = float(mf.get("pu_max", 0.0))
    mux_val = float(mf.get("mux_max", 0.0))
    vu_val = float(mf.get("vu_max", 0.0))

    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    # 1. FSM Buckling loads
    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0)
    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    # 2. DSM Checks
    comp_res = DSMCompression.design_column(
        ag=props.area,
        fy=req.yield_stress,
        p_cre=fsm_res.p_cre,
        p_crl=fsm_res.p_crl,
        p_crd=fsm_res.p_crd
    )
    comp_dc = (pu_val * 1000.0) / comp_res.phi_pn if comp_res.phi_pn > 1e-6 else 0.0

    py = props.area * req.yield_stress
    m_y = props.sx_top * req.yield_stress
    m_crl = (fsm_res.p_crl / py) * m_y if py > 0 else m_y
    m_crd = (fsm_res.p_crd / py) * m_y if py > 0 else m_y
    m_cre = (fsm_res.p_cre / py) * m_y if py > 0 else m_y

    flex_res = DSMFlexure.design_beam(
        sf=props.sx_top,
        fy=req.yield_stress,
        m_cre=m_cre,
        m_crl=m_crl,
        m_crd=m_crd
    )
    flex_dc = (mux_val * 1e6) / flex_res.phi_mn if flex_res.phi_mn > 1e-6 else 0.0

    # Shear
    hw = max([abs(e.y1 - e.y0) for e in geom.elements] + [100.0])
    vn = WebShearAndCrippling.calculate_shear(
        h=hw, t=req.thickness, fy=req.yield_stress, e_mod=205000.0
    )
    phi_vn = WebShearAndCrippling.PHI_V * vn
    shear_dc = (vu_val * 1000.0) / phi_vn if phi_vn > 1e-6 else 0.0

    inter_res = BeamColumnInteraction.check_interaction(
        pu=pu_val * 1000.0,
        phi_pn=comp_res.phi_pn,
        mux=mux_val * 1e6,
        phi_mnx=flex_res.phi_mn,
        muy=0.0,
        phi_mny=1e9
    )

    return {
        "applied_forces": {"pu": pu_val, "mux": mux_val, "vu": vu_val},
        "compression": {
            "phi_pn": round(comp_res.phi_pn / 1000.0, 2),
            "dc_ratio": round(comp_dc, 3),
            "status": "OK" if comp_dc <= 1.0 else "NG",
            "governing_mode": comp_res.governing_mode
        },
        "flexure": {
            "phi_mn": round(flex_res.phi_mn / 1e6, 2),
            "dc_ratio": round(flex_dc, 3),
            "status": "OK" if flex_dc <= 1.0 else "NG",
            "governing_mode": flex_res.governing_mode
        },
        "shear": {
            "phi_vn": round(phi_vn / 1000.0, 2),
            "dc_ratio": round(shear_dc, 3),
            "status": "OK" if shear_dc <= 1.0 else "NG"
        },
        "interaction": {
            "ratio": round(inter_res.controlling_dcr, 3),
            "status": "OK" if inter_res.is_safe else "NG"
        }
    }


