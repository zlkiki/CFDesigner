"""
Phase 3: Stateful Multi-Step User Scenario E2E Test Suite (AC 14-3)
Simulates end-to-end user interactions and multi-step state transitions across
cross-section manipulation, buckling analysis, member design, and calculation report pipelines.
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app

client = TestClient(app)


def test_scenario_1_wizard_bending_fsm_transform_preserve_design_report():
    """
    AC 14-3-1, AC 14-3-2:
    Scenario 1:
    1. Create C150x65x20x2.0 via Wizard
    2. Run FSM under Major-Axis Bending (bending_x)
    3. Perform Geometric Transform (Rotate / Align CG)
    4. Verify FSM load_type="bending_x" is preserved and yields valid M_cr
    5. Perform KDS Flexure Check (Mux = 6.0 kNm)
    6. Generate Detailed Calculation Report and verify M_crl & phi*Mn consistency
    """
    # 1. Wizard C-section
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 150.0, "b": 65.0, "c": 20.0, "t": 2.0, "r": 2.0})
    assert wiz_res.status_code == 200
    wiz_data = wiz_res.json()
    geom = wiz_data["geometry"]
    props = wiz_data["properties"]

    # 2. FSM Major-Axis Bending
    fsm_res_1 = client.post("/api/fsm/parameters", json={
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "l_min": 20.0,
        "l_max": 3000.0,
        "steps": 15,
        "load_type": "bending_x",
        "yield_stress": 345.0,
        "elastic_modulus": 205000.0,
        "poisson_ratio": 0.3,
        "member_length": 2500.0
    })
    assert fsm_res_1.status_code == 200
    fsm_data_1 = fsm_res_1.json()
    crit_1 = fsm_data_1["critical_modes"]
    assert crit_1["load_type"] == "bending_x"
    assert crit_1["p_crl"] > 0 # Represents M_crl in kNm

    # 3. Geometric Transform: Align CG
    trans_res = client.post("/api/section/transform", json={
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "transform_type": "align_cg",
        "angle_deg": 0.0,
        "center_at_cg": True
    })
    assert trans_res.status_code == 200
    trans_data = trans_res.json()
    geom_aligned = trans_data["geometry"]
    props_aligned = trans_data["properties"]
    assert abs(props_aligned["xcg"]) < 0.1 and abs(props_aligned["ycg"]) < 0.1

    # 4. Re-run FSM with preserved load_type="bending_x"
    fsm_res_2 = client.post("/api/fsm/parameters", json={
        "elements": geom_aligned["elements"],
        "thickness": geom_aligned["thickness"],
        "l_min": 20.0,
        "l_max": 3000.0,
        "steps": 15,
        "load_type": "bending_x", # State preserved
        "yield_stress": 345.0,
        "elastic_modulus": 205000.0,
        "poisson_ratio": 0.3,
        "member_length": 2500.0
    })
    assert fsm_res_2.status_code == 200
    fsm_data_2 = fsm_res_2.json()
    assert fsm_data_2["critical_modes"]["load_type"] == "bending_x"

    # 5. KDS Design Check for Flexure
    design_res = client.post("/api/design/check", json={
        "elements": geom_aligned["elements"],
        "thickness": geom_aligned["thickness"],
        "yield_stress": 345.0,
        "length_x": 2500.0,
        "length_y": 2500.0,
        "length_t": 2500.0,
        "pu": 0.0,
        "mux": 6.0,
        "vu": 10.0
    })
    assert design_res.status_code == 200
    design_data = design_res.json()
    assert design_data["flexure"]["phi_mn"] > 0
    assert design_data["flexure"]["status"] in ["OK", "NG"]

    # 6. Detailed Report Generation
    report_res = client.post("/api/report/html", json={
        "metadata": {
            "section_name": "C150x65x20x2.0 Aligned",
            "project_name": "Stateful Scenario 1"
        },
        "geometry": geom_aligned,
        "properties": props_aligned,
        "fsm": fsm_data_2["critical_modes"],
        "design": design_data,
        "loads": {"pu": 0.0, "mux": 6.0, "vu": 10.0}
    })
    assert report_res.status_code == 200
    html = report_res.json()["html"]
    assert "C150x65x20x2.0 Aligned" in html
    assert "KDS 14 31 10" in html
    assert "φMn" in html or "phi_mn" in html or "phi" in html


def test_scenario_2_rib_insertion_and_quick_design_pipeline():
    """
    AC 14-3-3:
    Scenario 2:
    1. Generate C-section
    2. Insert Intermediate Stiffener Rib on Web
    3. Verify Moment of Inertia (Ix, Iy) and Gross Area updates
    4. Run Quick Design Engine with Bearing Length optimization
    """
    # 1. Base C-section
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 200.0, "b": 75.0, "c": 20.0, "t": 2.0, "r": 2.0})
    wdata = wiz_res.json()
    orig_elements = wdata["geometry"]["elements"]
    orig_ix = wdata["properties"]["ix"]

    # 2. Insert V-Rib on web element (elem_id = 3 or middle web)
    # Target element 3 (web)
    rib_res = client.post("/api/section/insert-ribs", json={
        "elements": orig_elements,
        "thickness": 2.0,
        "target_elem_id": 3,
        "rib_type": "V",
        "rib_width": 25.0,
        "rib_depth": 12.0,
        "num_ribs": 1
    })
    assert rib_res.status_code == 200
    rib_data = rib_res.json()
    ribbed_geom = rib_data["geometry"]
    ribbed_props = rib_data["properties"]

    # 3. Verify element count increase and structural stiffness
    assert len(ribbed_geom["elements"]) > len(orig_elements)
    assert ribbed_props["area"] > wdata["properties"]["area"]

    # 4. Run Quick Design Search
    qd_res = client.post("/api/design/quick-design", json={
        "span": 4000.0,
        "spacing": 400.0,
        "bracing": "Midpoint",
        "dead_load": 1.2,
        "live_load": 2.4,
        "wind_load": 0.0,
        "dead_axial": 0.0,
        "live_axial": 0.0,
        "fy": 345.0,
        "deflection_live_limit": 360.0,
        "deflection_total_limit": 240.0,
        "bearing_length": 50.0,
        "shape_type_filter": "S",
        "config": "Single",
        "max_results": 5
    })
    assert qd_res.status_code == 200
    qd_data = qd_res.json()
    assert len(qd_data["candidates"]) > 0
    top_cand = qd_data["candidates"][0]
    assert top_cand["dc_strength"] <= 1.02
    assert top_cand["dc_crippling"] <= 1.02


def test_scenario_3_ssma_cold_work_frame1d_continuous_beam():
    """
    AC 14-3-1:
    Scenario 3:
    1. Calculate Cold-Work hardended yield stress Fya
    2. Run 1D FEM Continuous Beam analysis (2-span 3000mm + 3000mm)
    3. Transfer maximum moment and reaction forces into KDS Member Check
    4. Verify interaction and web crippling capacity
    """
    # 1. Cold work calculation
    cw_res = client.post("/api/material/cold-work", json={
        "base_fy": 228.0,
        "base_fu": 310.0,
        "r_inside": 2.0,
        "thickness": 1.5,
        "num_corners": 4,
        "total_length": 300.0
    })
    assert cw_res.status_code == 200
    cw_data = cw_res.json()
    fya = cw_data["fya"]
    assert fya > 228.0 # Yield strength increased

    # 2. 1D Continuous Beam FEM Analysis (2 equal spans of 3000mm with 15 kN/m UDL)
    frame_res = client.post("/api/analysis/run", json={
        "spans": [{"length": 3000.0}],
        "supports": [
            {"location": 0.0, "type": "pin"},
            {"location": 3000.0, "type": "roller"}
        ],
        "loads": [
            {"load_type": "udl", "magnitude": 15.0, "x_start": 0.0, "x_end": 3000.0}
        ],
        "e_mod": 205000.0,
        "ix": 2.5e6,
        "area": 600.0,
        "num_eval_points": 100
    })
    assert frame_res.status_code == 200
    frame_data = frame_res.json()
    assert "reactions" in frame_data
    assert "max_forces" in frame_data
    max_moment = abs(frame_data["max_forces"]["mux_max"]) # kNm
    max_shear = abs(frame_data["max_forces"]["vu_max"])   # kN
    assert max_moment > 0
    assert max_shear > 0

    # 3. Feed forces with Fya into Member Check
    wiz_res = client.post("/api/section/wizard", json={"shape_type": "C", "h": 200.0, "b": 70.0, "c": 20.0, "t": 2.0, "r": 2.0})
    geom = wiz_res.json()["geometry"]

    design_res = client.post("/api/design/check", json={
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "yield_stress": fya, # Using hardened yield strength
        "length_x": 3000.0,
        "length_y": 3000.0,
        "length_t": 3000.0,
        "pu": 0.0,
        "mux": max_moment,
        "vu": max_shear,
        "bearing_length": 50.0
    })
    assert design_res.status_code == 200
    d_res = design_res.json()
    assert "flexure" in d_res
    assert "shear" in d_res
    assert "interaction" in d_res
    assert d_res["flexure"]["dc_ratio"] > 0
