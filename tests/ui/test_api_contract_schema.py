"""
Phase 1: API Contract & Strict Schema Completeness Test Suite (AC 14-1)
Verifies that all FastAPI endpoints return 100% complete, non-null, typed JSON responses
matching frontend UI requirements with zero missing subfields.
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app

client = TestClient(app)


def test_section_wizard_all_5_shapes_schema():
    """
    AC 14-1-2: Test /api/section/wizard across all 5 shape types:
    C, Z, Hat, Tube, Channel.
    Ensures complete geometry and gross properties schema.
    """
    shapes = [
        {"shape_type": "C", "h": 150.0, "b": 65.0, "c": 20.0, "t": 2.0, "r": 2.0},
        {"shape_type": "Z", "h": 200.0, "b": 70.0, "c": 25.0, "t": 2.5, "r": 3.0},
        {"shape_type": "Hat", "h": 100.0, "b": 80.0, "c": 30.0, "t": 1.6, "r": 2.0},
        {"shape_type": "Tube", "h": 100.0, "b": 100.0, "c": 0.0, "t": 3.0, "r": 0.0},
        {"shape_type": "Channel", "h": 120.0, "b": 50.0, "c": 0.0, "t": 2.0, "r": 2.0},
    ]

    for payload in shapes:
        res = client.post("/api/section/wizard", json=payload)
        assert res.status_code == 200, f"Failed for shape: {payload['shape_type']}"
        data = res.json()

        # 1. Geometry Schema Check
        assert "geometry" in data
        geom = data["geometry"]
        assert "elements" in geom
        assert "thickness" in geom
        assert "total_length" in geom
        assert len(geom["elements"]) >= 3
        assert geom["thickness"] > 0
        assert geom["total_length"] > 0

        for elem in geom["elements"]:
            for key in ["elem_id", "x0", "y0", "x1", "y1", "length", "angle", "thickness"]:
                assert key in elem, f"Missing element key '{key}' in shape {payload['shape_type']}"
                assert elem[key] is not None

        # 2. Properties Schema Check
        assert "properties" in data
        props = data["properties"]
        required_props = [
            "area", "ix", "iy", "rx", "ry", "j", "cw",
            "xcg", "ycg", "x0", "y0", "sx_top", "sx_bot", "sy_left", "sy_right"
        ]
        for p_key in required_props:
            assert p_key in props, f"Missing property key '{p_key}' in shape {payload['shape_type']}"
            assert props[p_key] is not None
            assert not isinstance(props[p_key], str)

        assert props["area"] > 0
        assert props["ix"] > 0
        assert props["iy"] > 0
        assert props["rx"] > 0
        assert props["ry"] > 0
        assert props["j"] > 0


def test_fsm_solve_and_parameters_schema_symmetry():
    """
    AC 14-1-3: Verify 100% schema symmetry between /api/fsm/solve and /api/fsm/parameters.
    Both endpoints must provide identical multi-mode, 3D nodes, and strips datasets.
    """
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    geom = wiz_res.json()["geometry"]

    # 1. /api/fsm/solve call
    solve_payload = {
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "yield_stress": 345.0,
        "member_length": 3000.0,
        "num_points": 15,
        "load_type": "compression"
    }
    solve_res = client.post("/api/fsm/solve", json=solve_payload)
    assert solve_res.status_code == 200
    solve_data = solve_res.json()

    # 2. /api/fsm/parameters call
    param_payload = {
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "l_min": 10.0,
        "l_max": 4000.0,
        "steps": 15,
        "load_type": "compression",
        "yield_stress": 345.0,
        "elastic_modulus": 205000.0,
        "poisson_ratio": 0.3,
        "member_length": 3000.0
    }
    param_res = client.post("/api/fsm/parameters", json=param_payload)
    assert param_res.status_code == 200
    param_data = param_res.json()

    # Required common top-level keys
    common_keys = ["signature_curve", "critical_modes", "curves", "nodes", "strips"]
    for key in common_keys:
        assert key in solve_data, f"Key '{key}' missing in /api/fsm/solve"
        assert key in param_data, f"Key '{key}' missing in /api/fsm/parameters"

    # Verify curves schema (Mode 1, 2, 3 Chart.js point lists)
    for data_set, ep_name in [(solve_data, "solve"), (param_data, "parameters")]:
        curves = data_set["curves"]
        assert "mode_1" in curves, f"mode_1 missing in {ep_name}"
        assert "mode_2" in curves, f"mode_2 missing in {ep_name}"
        assert "mode_3" in curves, f"mode_3 missing in {ep_name}"
        for m_name in ["mode_1", "mode_2", "mode_3"]:
            m_list = curves[m_name]
            assert isinstance(m_list, list) and len(m_list) > 0
            for pt in m_list:
                assert "x" in pt and "y" in pt
                assert pt["x"] > 0
                assert pt["y"] > 0

        # Verify critical modes
        crit = data_set["critical_modes"]
        for c_key in ["p_crl", "l_local", "p_crd", "l_distortional", "p_cre", "l_global"]:
            assert c_key in crit, f"Critical mode key '{c_key}' missing in {ep_name}"

        # Verify nodes & strips for 3D visualization
        nodes = data_set["nodes"]
        strips = data_set["strips"]
        assert len(nodes) > 0, f"Nodes empty in {ep_name}"
        assert len(strips) > 0, f"Strips empty in {ep_name}"
        for node in nodes:
            for nk in ["node_idx", "x", "y", "local_mode", "dist_mode", "glob_mode"]:
                assert nk in node, f"Node key '{nk}' missing in {ep_name}"
        for strip in strips:
            for sk in ["elem_id", "node_i", "node_j", "thickness"]:
                assert sk in strip, f"Strip key '{sk}' missing in {ep_name}"

        # Verify signature_curve item structure
        for pt in data_set["signature_curve"]:
            for pk in ["length", "load_factor", "p_cr", "m_cr", "mode_lfs", "mode_pcrs", "mode_mcrs"]:
                assert pk in pt, f"Point key '{pk}' missing in {ep_name}"
            assert len(pt["mode_lfs"]) >= 1


def test_design_check_schema_completeness():
    """
    AC 14-1-1: Verify /api/design/check response schema completeness for all limit states.
    """
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
        "vu": 15.0,
        "bearing_length": 50.0
    }
    res = client.post("/api/design/check", json=design_payload)
    assert res.status_code == 200
    data = res.json()

    # 1. Compression
    assert "compression" in data
    comp = data["compression"]
    for ck in ["p_n", "phi_pn", "dc_ratio", "status", "governing_mode", "p_ne", "p_nl", "p_nd"]:
        assert ck in comp, f"Compression key '{ck}' missing"
        assert comp[ck] is not None

    # 2. Flexure
    assert "flexure" in data
    flex = data["flexure"]
    for fk in ["m_n", "phi_mn", "dc_ratio", "status", "governing_mode", "m_ne", "m_nl", "m_nd"]:
        assert fk in flex, f"Flexure key '{fk}' missing"
        assert flex[fk] is not None

    # 3. Shear
    assert "shear" in data
    shear = data["shear"]
    for sk in ["v_n", "phi_vn", "dc_ratio", "status"]:
        assert sk in shear, f"Shear key '{sk}' missing"
        assert shear[sk] is not None

    # 4. Interaction
    assert "interaction" in data
    inter = data["interaction"]
    for ik in ["ratio", "status", "formula_type"]:
        assert ik in inter, f"Interaction key '{ik}' missing"
        assert inter[ik] is not None


def test_quick_design_and_report_html_schema():
    """
    AC 14-1-4: Verify /api/design/quick-design and /api/report/html schemas.
    """
    # Quick design schema
    qd_res = client.post("/api/design/quick-design", json={
        "span": 3000.0, "spacing": 400.0, "bracing": "Midpoint",
        "dead_load": 1.0, "live_load": 2.0, "wind_load": 0.0,
        "dead_axial": 0.0, "live_axial": 0.0, "fy": 345.0,
        "deflection_live_limit": 360.0, "deflection_total_limit": 240.0,
        "bearing_length": 38.0, "shape_type_filter": "S", "config": "Single", "max_results": 5
    })
    assert qd_res.status_code == 200
    qd_data = qd_res.json()
    assert "candidates" in qd_data
    assert "total_scanned" in qd_data
    assert len(qd_data["candidates"]) > 0

    cand = qd_data["candidates"][0]
    for k in ["rank", "name", "weight", "dc_strength", "dc_deflection", "dc_crippling", "max_dc", "elements"]:
        assert k in cand, f"Candidate key '{k}' missing"
        assert cand[k] is not None

    # Report HTML schema
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150, "b": 65, "c": 20, "t": 2.0, "r": 2.0})
    wdata = wiz_res.json()
    report_res = client.post("/api/report/html", json={
        "metadata": {
            "section_name": "C150x65x20x2.0",
            "project_name": "Contract Test Project"
        },
        "geometry": wdata["geometry"],
        "properties": wdata["properties"],
        "fsm": {"p_crl": 120.0, "l_local": 65.0, "p_crd": 95.0, "l_distortional": 280.0, "p_cre": 80.0, "l_global": 3000.0},
        "design": {
            "compression": {"p_n": 100.0, "phi_pn": 85.0, "dc_ratio": 0.588, "status": "OK", "governing_mode": "Local"},
            "flexure": {"m_n": 8.0, "phi_mn": 7.2, "dc_ratio": 0.694, "status": "OK", "governing_mode": "Local"},
            "shear": {"v_n": 30.0, "phi_vn": 27.0, "dc_ratio": 0.556, "status": "OK"},
            "interaction": {"ratio": 0.75, "status": "OK", "formula_type": "식 (1.4-1)"}
        },
        "loads": {"pu": 50.0, "mux": 5.0, "vu": 15.0}
    })
    assert report_res.status_code == 200
    r_json = report_res.json()
    assert "html" in r_json
    html_content = r_json["html"]
    assert "KDS 14 31 10" in html_content
    assert "<svg" in html_content
    assert "C150x65x20x2.0" in html_content
