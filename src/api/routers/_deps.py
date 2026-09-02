"""
Shared dependencies for all API routers:
- Pydantic request/response models (ElementDTO, WizardRequest, DesignCheckRequest, etc.)
- Helper functions (elements_from_dto, serialize_geometry, _calculate_and_bundle_section)
- Common engine imports
"""

from fastapi import HTTPException, UploadFile, File, Form
from pydantic import BaseModel, Field
from typing import List, Optional, Dict, Any
import tempfile
import os
import math
import numpy as np

from ...cad.dxf_reader import DXFReader, DXFPolyline, DXFVertex
from ...cad.part_mesher import PartMesher, SectionGeometry, Element
from ...geometry.gross_properties import SectionPropertiesCalculator, GrossProperties
from ...geometry.section_wizard import SectionWizard
from ...geometry.geometry_editor import GeometryEditor
from ...geometry.library_parser import CFSLibraryParser, ColdWorkCalculator, STANDARD_MATERIALS
from ...geometry.effective_width import EffectiveWidthSolver, EffectivePropertiesResult
from ...solver.strip_assembler import StripAssembler
from ...solver.signature_curve import SignatureCurveAnalyzer, BucklingCurveResult, BucklingPoint
from ...solver.eigen_solver import FSMEigenSolver
from ...design.dsm_compression import DSMCompression, CompressionDesignResult
from ...design.dsm_flexure import DSMFlexure, FlexureDesignResult
from ...design.shear_and_crippling import WebShearAndCrippling, ShearCripplingResult, WebCripplingResult
from ...design.quick_design import QuickDesignEngine, QuickDesignResult
from ...design.beam_column import BeamColumnInteraction, InteractionResult
from ...solver.frame1d import Frame1DSolver, Frame1DAnalysisResult
from ...report.html_report import HTMLReportGenerator
from ...resource_helper import get_resource_path


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


class ColdWorkRequest(BaseModel):
    base_fy: float = 345.0
    base_fu: float = 450.0
    r_inside: float = 2.0
    thickness: float = 1.5
    num_corners: int = 4
    total_length: float = 250.0


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


# ---------------------------------------------------------
# Shared Helper Functions
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


def extract_mode_shapes(assembler: StripAssembler, fsm_res, member_length: float):
    """
    Computes 3D mode displacement vectors for Local, Distortional, and Global modes.
    Returns (nodes_data, strips_data, mode_1_curve, mode_2_curve, mode_3_curve).
    """
    l_loc = fsm_res.l_local if fsm_res.l_local > 0 else 50.0
    ke_loc, kg_loc = assembler.assemble_matrices(half_wavelength=l_loc)
    modes_loc = FSMEigenSolver.solve_eigenvalues(ke_loc, kg_loc, num_modes=3)
    mode_loc_1 = modes_loc[0][1] if len(modes_loc) > 0 else None
    mode_loc_2 = modes_loc[1][1] if len(modes_loc) > 1 else mode_loc_1
    mode_loc_3 = modes_loc[2][1] if len(modes_loc) > 2 else mode_loc_2

    l_dist = fsm_res.l_distortional if fsm_res.l_distortional > 0 else 250.0
    ke_dist, kg_dist = assembler.assemble_matrices(half_wavelength=l_dist)
    modes_dist = FSMEigenSolver.solve_eigenvalues(ke_dist, kg_dist, num_modes=3)
    mode_dist_1 = modes_dist[0][1] if len(modes_dist) > 0 else None
    mode_dist_2 = modes_dist[1][1] if len(modes_dist) > 1 else mode_dist_1
    mode_dist_3 = modes_dist[2][1] if len(modes_dist) > 2 else mode_dist_2

    l_glob = member_length if member_length > 0 else 3000.0
    ke_glob, kg_glob = assembler.assemble_matrices(half_wavelength=l_glob)
    modes_glob = FSMEigenSolver.solve_eigenvalues(ke_glob, kg_glob, num_modes=3)
    mode_glob_1 = modes_glob[0][1] if len(modes_glob) > 0 else None
    mode_glob_2 = modes_glob[1][1] if len(modes_glob) > 1 else mode_glob_1
    mode_glob_3 = modes_glob[2][1] if len(modes_glob) > 2 else mode_glob_2

    nodes_data = []
    for node_idx, n in enumerate(assembler.nodes):
        dof_start = node_idx * 4
        loc_disp_1 = mode_loc_1[dof_start:dof_start+4].tolist() if mode_loc_1 is not None else [0, 0, 0, 0]
        loc_disp_2 = mode_loc_2[dof_start:dof_start+4].tolist() if mode_loc_2 is not None else loc_disp_1
        loc_disp_3 = mode_loc_3[dof_start:dof_start+4].tolist() if mode_loc_3 is not None else loc_disp_2

        dist_disp_1 = mode_dist_1[dof_start:dof_start+4].tolist() if mode_dist_1 is not None else [0, 0, 0, 0]
        dist_disp_2 = mode_dist_2[dof_start:dof_start+4].tolist() if mode_dist_2 is not None else dist_disp_1
        dist_disp_3 = mode_dist_3[dof_start:dof_start+4].tolist() if mode_dist_3 is not None else dist_disp_2

        glob_disp_1 = mode_glob_1[dof_start:dof_start+4].tolist() if mode_glob_1 is not None else [0, 0, 0, 0]
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

    return nodes_data, strips_data


def build_signature_chart_data(fsm_res):
    """
    Converts FSM result points into chart-compatible JSON data with multi-mode curves.
    Returns (chart_points, mode_1_curve, mode_2_curve, mode_3_curve).
    """
    chart_points = []
    mode_1_curve = []
    mode_2_curve = []
    mode_3_curve = []

    for pt in fsm_res.points:
        chart_points.append({
            "length": round(pt.length, 2),
            "load_factor": round(pt.load_factor, 4),
            "p_cr": round(pt.critical_load / 1000.0, 2),
            "m_cr": round(pt.critical_moment / 1e6, 3),
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

    return chart_points, mode_1_curve, mode_2_curve, mode_3_curve
