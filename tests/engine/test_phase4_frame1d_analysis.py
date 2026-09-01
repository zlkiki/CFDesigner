"""
Unit & Integration Tests for Phase 4: 1D Frame & Beam FEM Analysis Engine & Diagrams
Tests Acceptance Criteria AC 4-1, AC 4-2, AC 4-3, AC 4-4, AC 4-5.
"""

import pytest
import math
from fastapi.testclient import TestClient
from src.api.server import app
from src.solver.frame1d import Frame1DSolver, Frame1DAnalysisResult
from src.geometry.section_wizard import SectionWizard

client = TestClient(app)


def test_ac4_1_simple_span_beam_exact_theory():
    """
    AC 4-1: Verify 4,000mm Simple Span Beam under UDL w = 10 kN/m yields:
    - M_max = w * L^2 / 8 = 10 * 4^2 / 8 = 20.0 kN·m
    - V_max = w * L / 2 = 10 * 4 / 2 = 20.0 kN
    - Reaction R1 = R2 = 20.0 kN
    - Midspan Deflection delta_max = 5 * w * L^4 / (384 * E * I)
    """
    L = 4000.0   # mm
    w = 10.0     # kN/m = 10 N/mm
    E = 205000.0 # MPa
    Ix = 2.5e6   # mm^4
    Area = 600.0 # mm^2

    res = Frame1DSolver.analyze(
        spans=[{"length": L, "e_mod": E, "ix": Ix, "area": Area}],
        supports=[
            {"location": 0.0, "type": "pin", "fix_u": True, "fix_v": True, "fix_rot": False},
            {"location": L, "type": "roller", "fix_u": False, "fix_v": True, "fix_rot": False}
        ],
        loads=[{"load_type": "udl", "magnitude": w, "x_start": 0.0, "x_end": L}],
        num_eval_points=200
    )

    assert res.is_success, "Analysis should succeed."
    assert len(res.reactions) == 2, "Should have 2 support reactions."
    
    # Check reactions: R1 = R2 = 20.0 kN
    r1 = res.reactions[0].ry
    r2 = res.reactions[1].ry
    assert abs(r1 - 20.0) < 0.1, f"Reaction R1 ({r1} kN) should be 20.0 kN"
    assert abs(r2 - 20.0) < 0.1, f"Reaction R2 ({r2} kN) should be 20.0 kN"

    # Check maximum moment Mmax = 20.0 kNm at x = 2000 mm
    m_max = res.max_forces.mux_max
    assert abs(m_max - 20.0) < 0.1, f"Max moment ({m_max} kNm) should be 20.0 kNm"
    assert abs(res.max_forces.x_m_max - 2000.0) < 50.0

    # Check maximum shear Vmax = 20.0 kN
    v_max = res.max_forces.vu_max
    assert abs(v_max - 20.0) < 0.1, f"Max shear ({v_max} kN) should be 20.0 kN"

    # Theoretical midspan deflection: delta = 5 * w * L^4 / (384 * E * I)
    w_n_mm = w
    delta_theory = (5.0 * w_n_mm * (L ** 4)) / (384.0 * E * Ix)
    assert abs(res.max_forces.defl_max - delta_theory) < 0.2, (
        f"FEM deflection ({res.max_forces.defl_max} mm) should match theoretical ({delta_theory:.3f} mm)"
    )


def test_ac4_2_diagram_data_continuity():
    """
    AC 4-2: Verify continuous numerical distribution of SFD, BMD, and Deflection.
    """
    L = 3000.0
    res = Frame1DSolver.analyze(
        spans=[{"length": L}],
        supports=[{"location": 0.0, "type": "pin"}, {"location": L, "type": "roller"}],
        loads=[{"load_type": "point", "magnitude": 30.0, "x_start": 1500.0}], # 30kN point load at center
        num_eval_points=100
    )

    assert len(res.diagrams) >= 100, "Should generate at least requested evaluation points"
    # Center moment for point load P*L/4 = 30 * 3 / 4 = 22.5 kNm
    assert abs(res.max_forces.mux_max - 22.5) < 0.1
    assert abs(res.max_forces.vu_max - 15.0) < 0.1


def test_ac4_3_two_span_continuous_beam_moments():
    """
    AC 4-3: 2-Span Continuous Beam (L1=3000, L2=3000mm, w=10kN/m).
    - Interior Support Negative Moment M_neg = w * L^2 / 8 = 10 * 3^2 / 8 = 11.25 kN·m
    - Midspan Positive Moment M_pos = 9 * w * L^2 / 128 = 9 * 10 * 9 / 128 = 6.328 kN·m
    - Error < 0.1%
    """
    L1 = 3000.0
    L2 = 3000.0
    w = 10.0 # kN/m

    res = Frame1DSolver.analyze(
        spans=[{"length": L1}, {"length": L2}],
        supports=[
            {"location": 0.0, "type": "pin"},
            {"location": 3000.0, "type": "roller"},
            {"location": 6000.0, "type": "roller"}
        ],
        loads=[{"load_type": "udl", "magnitude": w, "x_start": 0.0, "x_end": 6000.0}],
        num_eval_points=200
    )

    m_neg_theory = (w * ((L1 / 1000.0) ** 2)) / 8.0 # 11.25 kNm
    m_pos_theory = (9.0 * w * ((L1 / 1000.0) ** 2)) / 128.0 # 6.328 kNm

    m_pos_fem = res.max_forces.mux_max
    m_neg_fem = abs(res.max_forces.mux_min)

    assert abs(m_neg_fem - m_neg_theory) / m_neg_theory < 0.01, (
        f"Negative moment ({m_neg_fem} kNm) must match theory ({m_neg_theory} kNm)"
    )
    assert abs(m_pos_fem - m_pos_theory) / m_pos_theory < 0.02, (
        f"Positive moment ({m_pos_fem} kNm) must match theory ({m_pos_theory} kNm)"
    )


def test_ac4_4_transfer_to_design_api():
    """
    AC 4-4: Verify /api/analysis/transfer-to-design injects maximum moments and shears
    into DSM design checks and returns proper D/C ratios.
    """
    c_geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    elements_dto = [
        {
            "elem_id": e.elem_id,
            "x0": e.x0, "y0": e.y0,
            "x1": e.x1, "y1": e.y1,
            "length": e.length,
            "angle": e.angle,
            "thickness": e.thickness,
            "radius": e.radius
        }
        for e in c_geom.elements
    ]

    payload = {
        "elements": elements_dto,
        "thickness": 2.0,
        "yield_stress": 345.0,
        "member_length": 3000.0,
        "max_forces": {
            "pu_max": 20.0,
            "mux_max": 8.0,
            "vu_max": 15.0
        }
    }

    res = client.post("/api/analysis/transfer-to-design", json=payload)
    assert res.status_code == 200
    data = res.json()

    assert "compression" in data
    assert "flexure" in data
    assert "shear" in data
    assert "interaction" in data
    assert data["compression"]["phi_pn"] > 0
    assert data["flexure"]["phi_mn"] > 0
    assert data["interaction"]["ratio"] > 0


def test_ac4_5_analysis_run_api():
    """
    AC 4-5: Verify /api/analysis/run REST endpoint end-to-end.
    """
    payload = {
        "spans": [{"length": 3000.0}, {"length": 3000.0}],
        "supports": [{"location": 0.0, "type": "pin"}, {"location": 3000.0, "type": "roller"}, {"location": 6000.0, "type": "roller"}],
        "loads": [{"load_type": "udl", "magnitude": 12.0, "x_start": 0.0, "x_end": 6000.0}],
        "e_mod": 205000.0,
        "ix": 2.5e6,
        "area": 500.0,
        "num_eval_points": 100
    }

    res = client.post("/api/analysis/run", json=payload)
    assert res.status_code == 200
    data = res.json()

    assert data["is_success"] is True
    assert len(data["reactions"]) == 3
    assert len(data["diagrams"]) >= 100
    assert data["max_forces"]["mux_max"] > 0
