"""
Section Router: /api/section/*, /api/library/*, /api/material/*
Handles cross-section geometry creation, DXF upload, transforms, ribs,
section library browsing, material presets, and cold-work calculations.
"""

from fastapi import APIRouter, HTTPException, UploadFile, File, Form
from typing import List, Optional
import os
import math
import tempfile

from ._deps import (
    WizardRequest, ElementDTO, ElementsUpdateRequest,
    TransformRequest, InsertRibsRequest, ColdWorkRequest,
    EffectiveWidthRequest,
    elements_from_dto, serialize_geometry, _calculate_and_bundle_section,
    SectionWizard, SectionPropertiesCalculator, GeometryEditor,
    DXFReader, PartMesher,
    CFSLibraryParser, ColdWorkCalculator, STANDARD_MATERIALS,
    EffectiveWidthSolver,
    get_resource_path,
)

router = APIRouter(prefix="/api")


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
    Reconstructs section geometry from modified element table, calculates properties,
    and returns updated geometry.
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
# Section & Material Library Endpoints
# ---------------------------------------------------------

@router.get("/library/files")
async def get_library_files():
    """
    Returns the list of available .cfsl library files in original_source.
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
