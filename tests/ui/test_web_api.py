"""
E2E & Unit Tests for CFDesigner FastAPI Web Endpoints
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app

client = TestClient(app)


def test_index_page():
    res = client.get("/")
    assert res.status_code == 200
    assert "CFDesigner" in res.text


def test_wizard_api():
    payload = {
        "shape_type": "C",
        "h": 150.0,
        "b": 65.0,
        "c": 20.0,
        "t": 2.0,
        "r": 2.0
    }
    res = client.post("/api/section/wizard", json=payload)
    assert res.status_code == 200
    data = res.json()
    assert "geometry" in data
    assert "properties" in data
    assert len(data["geometry"]["elements"]) > 0
    props = data["properties"]
    assert props["area"] > 500 # mm2
    assert props["ix"] > 1e6   # mm4


def test_fsm_solve_api():
    # 1. Generate section
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    geom = wiz_res.json()["geometry"]

    # 2. Solve FSM
    fsm_payload = {
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "yield_stress": 345.0,
        "member_length": 3000.0,
        "num_points": 15
    }
    res = client.post("/api/fsm/solve", json=fsm_payload)
    assert res.status_code == 200
    data = res.json()
    assert "signature_curve" in data
    assert "critical_modes" in data
    assert len(data["signature_curve"]) > 0
    assert data["critical_modes"]["p_crl"] > 0


def test_fsm_parameters_custom_sweep_api():
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    geom = wiz_res.json()["geometry"]

    fsm_custom_payload = {
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "l_min": 10.0,
        "l_max": 5000.0,
        "steps": 20,
        "load_type": "bending_x",
        "yield_stress": 345.0,
        "elastic_modulus": 205000.0,
        "poisson_ratio": 0.3,
        "member_length": 3000.0
    }
    res = client.post("/api/fsm/parameters", json=fsm_custom_payload)
    assert res.status_code == 200
    data = res.json()

    assert "signature_curve" in data
    assert "curves" in data
    assert "mode_1" in data["curves"]
    assert "mode_2" in data["curves"]
    assert "mode_3" in data["curves"]
    assert "nodes" in data
    assert "strips" in data
    assert len(data["nodes"]) > 0
    assert len(data["strips"]) > 0

    # Verify each point has multi-mode values for Chart.js
    first_pt = data["signature_curve"][0]
    assert "mode_pcrs" in first_pt
    assert "mode_mcrs" in first_pt
    assert "mode_lfs" in first_pt
    assert len(first_pt["mode_pcrs"]) >= 1


def test_design_check_api():
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    geom = wiz_res.json()["geometry"]

    design_payload = {
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "yield_stress": 345.0,
        "length_x": 3000.0,
        "length_y": 3000.0,
        "length_t": 3000.0,
        "pu": 50.0,
        "mux": 5.0,
        "vu": 15.0
    }
    res = client.post("/api/design/check", json=design_payload)
    assert res.status_code == 200
    data = res.json()
    assert "compression" in data
    assert "flexure" in data
    assert "shear" in data
    assert "interaction" in data
    assert data["compression"]["phi_pn"] > 0
    assert data["compression"]["dc_ratio"] > 0


def test_report_html_api():
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    data = wiz_res.json()

    report_payload = {
        "section_name": "C150x65x20x2.0",
        "project_name": "Test Project",
        "geometry": data["geometry"],
        "properties": data["properties"],
        "fsm": {"p_crl": 120.0, "l_local": 65.0, "p_crd": 95.0, "l_distortional": 280.0, "p_cre": 80.0, "l_global": 3000.0},
        "design": {
            "compression": {"p_n": 100.0, "phi_pn": 85.0, "dc_ratio": 0.588, "status": "OK", "governing_mode": "Local"},
            "flexure": {"m_n": 8.0, "phi_mn": 7.2, "dc_ratio": 0.694, "status": "OK", "governing_mode": "Local"},
            "shear": {"v_n": 30.0, "phi_vn": 27.0, "dc_ratio": 0.556, "status": "OK"},
            "interaction": {"ratio": 0.75, "status": "OK", "formula_type": "식 (1.4-1)"}
        },
        "loads": {"pu": 50.0, "mux": 5.0, "vu": 15.0}
    }
    res = client.post("/api/report/html", json=report_payload)
    assert res.status_code == 200
    assert "html" in res.json()
    assert "KDS 14 31 10" in res.json()["html"]
