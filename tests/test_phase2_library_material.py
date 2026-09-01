"""
Unit and Integration Tests for Phase 2: Section & Material Library Browser
Covers Acceptance Criteria AC 2-1, AC 2-2, AC 2-3, and AC 2-4.
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app
from src.geometry.library_parser import CFSLibraryParser, ColdWorkCalculator, STANDARD_MATERIALS


@pytest.fixture
def client():
    return TestClient(app)


def test_ac2_1_cfsl_binary_parsing():
    """
    AC 2-1: original_source/AISI.cfsl and SSMA.cfsl are decoded without errors
    and return company info and section type directory.
    """
    aisi_summary = CFSLibraryParser.get_library_summary("original_source/AISI.cfsl")
    assert aisi_summary["library_name"] == "AISI"
    assert "American Iron and Steel Institute" in aisi_summary["company"]
    assert len(aisi_summary["types"]) > 0

    ssma_summary = CFSLibraryParser.get_library_summary("original_source/SSMA.cfsl")
    assert ssma_summary["library_name"] == "SSMA"
    assert len(ssma_summary["types"]) >= 5
    total_ssma_sections = sum(len(t["sections"]) for t in ssma_summary["types"])
    assert total_ssma_sections > 500


def test_ac2_2_ssma_section_load(client):
    """
    AC 2-2: Selecting a section (e.g. 362S162-33) loads precise dimensions
    (H ≈ 92.1 mm, B ≈ 41.3 mm, t ≈ 0.88 mm) and valid geometry.
    """
    # 1. Query section list from API
    res = client.get("/api/library/sections?lib=SSMA&query=362S162-33")
    assert res.status_code == 200
    data = res.json()
    
    found_sct = None
    for t in data["types"]:
        for s in t["sections"]:
            if "362S162-33" in s["name"]:
                found_sct = s
                break
        if found_sct:
            break
            
    assert found_sct is not None, "362S162-33 not found in SSMA library"

    # 2. Load section details by offset
    load_res = client.get(f"/api/library/sections/SSMA/{found_sct['offset']}")
    assert load_res.status_code == 200
    sec_data = load_res.json()

    geom = sec_data["geometry"]
    props = sec_data["properties"]
    elements = geom["elements"]

    assert len(elements) == 5  # Lip, Flange, Web, Flange, Lip
    assert pytest.approx(geom["thickness"], rel=0.01) == 0.879  # 33 mil = 0.0346 in = 0.879 mm
    assert pytest.approx(elements[2]["length"], rel=0.01) == 92.07  # Web H = 3.625 in = 92.07 mm
    assert pytest.approx(elements[1]["length"], rel=0.01) == 41.27  # Flange B = 1.625 in = 41.27 mm
    assert pytest.approx(elements[0]["length"], rel=0.01) == 12.70  # Lip C = 0.500 in = 12.70 mm
    assert props["area"] > 0
    assert props["ix"] > 0
    assert props["iy"] > 0


def test_ac2_3_standard_material_presets(client):
    """
    AC 2-3: Standard steel grades (SSC275, SSC355, A1008, etc.) are available
    with correct engineering properties.
    """
    res = client.get("/api/library/materials")
    assert res.status_code == 200
    materials = res.json()["materials"]

    mat_map = {m["code"]: m for m in materials}
    assert "SSC275" in mat_map
    assert mat_map["SSC275"]["fy"] == 275.0
    assert mat_map["SSC275"]["fu"] == 410.0
    assert mat_map["SSC275"]["e"] == 205000.0

    assert "SSC355" in mat_map
    assert mat_map["SSC355"]["fy"] == 355.0
    assert mat_map["SSC355"]["fu"] == 490.0

    assert "A1008_50" in mat_map
    assert mat_map["A1008_50"]["fy"] == 345.0


def test_ac2_4_cold_work_calculator(client):
    """
    AC 2-4: Cold-work forming calculator increases Fya above virgin Fy
    according to AISI S100 Section A3.3.2 / KDS 14 31 10.
    """
    payload = {
        "base_fy": 345.0,
        "base_fu": 450.0,
        "r_inside": 2.0,
        "thickness": 1.5,
        "num_corners": 4,
        "total_length": 250.0
    }
    res = client.post("/api/material/cold-work", json=payload)
    assert res.status_code == 200
    data = res.json()

    assert data["fya"] > payload["base_fy"]
    assert data["fya"] <= payload["base_fu"]
    assert data["percent_increase"] > 0.0
    assert data["c_ratio"] > 0.0
