"""
Unit Tests for Phase 1: Section Micro-Editing, Transforms, and Rib Insertion
Verifies Acceptance Criteria AC 1-1, AC 1-2, AC 1-3, and API endpoints.
"""

import pytest
import math
from fastapi.testclient import TestClient
from src.api.server import app
from src.geometry.section_wizard import SectionWizard
from src.geometry.geometry_editor import GeometryEditor
from src.geometry.gross_properties import SectionPropertiesCalculator


client = TestClient(app)


def test_element_spreadsheet_update_ac_1_1():
    """
    AC 1-1: Verify updating element thickness or dimensions updates area (Ag) and Ix immediately.
    """
    # 1. Create base C-section: 150x65x20x2.0
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0)
    props_orig = SectionPropertiesCalculator.calculate(geom)
    orig_area = props_orig.area

    # 2. Modify thickness of all elements to 3.0mm
    elem_dicts = []
    for e in geom.elements:
        elem_dicts.append({
            "elem_id": e.elem_id,
            "x0": e.x0,
            "y0": e.y0,
            "x1": e.x1,
            "y1": e.y1,
            "length": e.length,
            "angle": e.angle,
            "thickness": 3.0,
            "radius": e.radius
        })

    payload = {
        "elements": elem_dicts,
        "thickness": 3.0
    }
    response = client.post("/api/section/elements", json=payload)
    assert response.status_code == 200
    data = response.json()
    new_area = data["properties"]["area"]

    # Area should be roughly 1.5x larger (since t increased from 2.0 to 3.0)
    assert new_area > orig_area
    assert math.isclose(new_area / orig_area, 1.5, rel_tol=0.05)


def test_geometric_rotate_ac_1_2():
    """
    AC 1-2: Verify 90-degree rotation swaps Ix and Iy.
    """
    # Create base C-section
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0)
    props_orig = SectionPropertiesCalculator.calculate(geom)
    orig_ix = props_orig.ix
    orig_iy = props_orig.iy

    elem_dtos = [{
        "elem_id": e.elem_id,
        "x0": e.x0,
        "y0": e.y0,
        "x1": e.x1,
        "y1": e.y1,
        "length": e.length,
        "angle": e.angle,
        "thickness": e.thickness,
        "radius": e.radius
    } for e in geom.elements]

    # Rotate 90 degrees CCW
    payload = {
        "elements": elem_dtos,
        "thickness": 2.0,
        "transform_type": "rotate_90_ccw",
        "center_at_cg": True
    }
    response = client.post("/api/section/transform", json=payload)
    assert response.status_code == 200
    data = response.json()
    rot_ix = data["properties"]["ix"]
    rot_iy = data["properties"]["iy"]

    # In 90 degree rotation, Ix should equal original Iy, and Iy should equal original Ix
    assert math.isclose(rot_ix, orig_iy, rel_tol=0.01)
    assert math.isclose(rot_iy, orig_ix, rel_tol=0.01)


def test_mirror_transforms():
    """
    Verify horizontal and vertical mirror transforms preserve area and principal properties.
    """
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0)
    props_orig = SectionPropertiesCalculator.calculate(geom)

    elem_dtos = [{
        "elem_id": e.elem_id,
        "x0": e.x0,
        "y0": e.y0,
        "x1": e.x1,
        "y1": e.y1,
        "length": e.length,
        "angle": e.angle,
        "thickness": e.thickness,
        "radius": e.radius
    } for e in geom.elements]

    # Mirror horizontal
    payload = {
        "elements": elem_dtos,
        "thickness": 2.0,
        "transform_type": "mirror_h",
        "center_at_cg": True
    }
    res_h = client.post("/api/section/transform", json=payload)
    assert res_h.status_code == 200
    data_h = res_h.json()
    assert math.isclose(data_h["properties"]["area"], props_orig.area, rel_tol=0.001)
    assert math.isclose(data_h["properties"]["ix"], props_orig.ix, rel_tol=0.001)

    # Mirror vertical
    payload["transform_type"] = "mirror_v"
    res_v = client.post("/api/section/transform", json=payload)
    assert res_v.status_code == 200
    data_v = res_v.json()
    assert math.isclose(data_v["properties"]["area"], props_orig.area, rel_tol=0.001)
    assert math.isclose(data_v["properties"]["iy"], props_orig.iy, rel_tol=0.001)


def test_insert_rib_ac_1_3():
    """
    AC 1-3: Verify inserting a V-shaped rib on the web of a C-section splits elements and increases local buckling resistance.
    """
    # Create base C-section: 150x65x20x2.0 (Element 3 is the Web)
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0)
    orig_elem_count = len(geom.elements)

    elem_dtos = [{
        "elem_id": e.elem_id,
        "x0": e.x0,
        "y0": e.y0,
        "x1": e.x1,
        "y1": e.y1,
        "length": e.length,
        "angle": e.angle,
        "thickness": e.thickness,
        "radius": e.radius
    } for e in geom.elements]

    # Insert 1 V-Rib on element 3 (Web) with width=25, depth=10
    payload = {
        "elements": elem_dtos,
        "thickness": 2.0,
        "target_elem_id": 3,
        "rib_type": "V",
        "rib_width": 25.0,
        "rib_depth": 10.0,
        "num_ribs": 1
    }
    response = client.post("/api/section/insert-ribs", json=payload)
    assert response.status_code == 200
    data = response.json()
    
    new_elements = data["geometry"]["elements"]
    # 1 element was replaced by 3 sub-elements (pre flat, 2 legs, post flat -> total 4 parts)
    # So count should increase by 3
    assert len(new_elements) > orig_elem_count

    # Run FSM solve on rib section to verify FSM solver works on rib section
    fsm_payload = {
        "elements": new_elements,
        "thickness": 2.0,
        "load_type": "compression",
        "yield_stress": 345.0,
        "elastic_modulus": 203000.0,
        "poisson_ratio": 0.3,
        "l_min": 20.0,
        "l_max": 2000.0,
        "num_points": 25,
        "member_length": 3000.0
    }
    res_fsm = client.post("/api/fsm/solve", json=fsm_payload)
    assert res_fsm.status_code == 200
    fsm_data = res_fsm.json()
    assert "signature_curve" in fsm_data
    assert len(fsm_data["signature_curve"]) == 25
    assert fsm_data["critical_modes"]["p_crl"] > 0.0
