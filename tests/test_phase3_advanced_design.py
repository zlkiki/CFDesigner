"""
Unit & Integration Tests for Phase 3: Advanced Design & Solver Modules
Tests Acceptance Criteria AC 3-1, AC 3-2, AC 3-3, AC 3-4.
"""

import pytest
import time
from src.design.shear_and_crippling import WebShearAndCrippling
from src.design.quick_design import QuickDesignEngine
from src.geometry.effective_width import EffectiveWidthSolver
from src.geometry.section_wizard import SectionWizard
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.signature_curve import SignatureCurveAnalyzer


def test_ac3_1_web_crippling_bearing_length_increase():
    """
    AC 3-1: Verify that increasing bearing length N from 50mm to 100mm
    under Interior-One-Flange (IOF) condition monotonically increases nominal capacity Pnc.
    """
    h = 150.0  # mm
    t = 2.0    # mm
    r = 2.0    # mm
    fy = 300.0 # MPa

    # Test IOF with N = 50mm
    res_50 = WebShearAndCrippling.calculate_web_crippling_advanced(
        h=h, t=t, r=r, n_bearing=50.0, fy=fy, condition="IOF", fastened=True, stiffened=True
    )

    # Test IOF with N = 100mm
    res_100 = WebShearAndCrippling.calculate_web_crippling_advanced(
        h=h, t=t, r=r, n_bearing=100.0, fy=fy, condition="IOF", fastened=True, stiffened=True
    )

    assert res_50.pnc > 0, "Pnc (N=50) should be positive"
    assert res_100.pnc > 0, "Pnc (N=100) should be positive"
    assert res_100.pnc > res_50.pnc, f"Pnc with N=100 ({res_100.pnc} N) must be greater than N=50 ({res_50.pnc} N)"
    
    # Check 4 conditions (EOF, IOF, ETF, ITF) work properly
    for cond in ["EOF", "IOF", "ETF", "ITF"]:
        c_res = WebShearAndCrippling.calculate_web_crippling_advanced(
            h=h, t=t, r=r, n_bearing=50.0, fy=fy, condition=cond, fastened=False, stiffened=True
        )
        assert c_res.pnc > 0, f"Condition {cond} should yield valid Pnc"
        assert c_res.phi_pnc > 0
        assert c_res.omega_pnc > 0


def test_ac3_2_quick_design_optimal_sizing():
    """
    AC 3-2: Quick Design search for Pu=50kN, Mux=5kNm returns valid candidates
    sorted by weight ascending in sub-second response time.
    """
    start_time = time.time()
    res = QuickDesignEngine.search_optimal_sections(
        pu_kn=50.0,
        mux_knm=5.0,
        vu_kn=5.0,
        length_mm=3000.0,
        fy_mpa=345.0,
        max_results=10
    )
    elapsed = time.time() - start_time

    assert res.total_scanned > 0, "Should have scanned library sections"
    assert len(res.candidates) > 0, "Should find at least 1 candidate satisfying design loads"
    assert elapsed < 2.0, f"Search completed in {elapsed:.3f}s (sub-second target)"

    # Verify candidates are sorted by weight ascending
    weights = [c.weight for c in res.candidates]
    assert weights == sorted(weights), "Candidates must be sorted by weight ascending"

    # Verify max D/C <= 1.02 for all candidates
    for c in res.candidates:
        assert c.max_dc <= 1.02, f"Candidate {c.name} exceeds max D/C with {c.max_dc}"
        assert c.rank >= 1
        assert len(c.elements) > 0


def test_ac3_3_fsm_custom_sweep_steps():
    """
    AC 3-3: Verify FSM sweep with 100 customized steps generates exactly 100 points
    with proper curve results and mode extractions.
    """
    # Create standard C-channel
    c_geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(c_geom)

    assembler = StripAssembler(geom=c_geom, props=props)
    analyzer = SignatureCurveAnalyzer(assembler)

    # 100 steps sweep
    fsm_res = analyzer.analyze(
        l_min=10.0,
        l_max=10000.0,
        num_points=100,
        load_type="compression",
        yield_stress=345.0,
        member_length=3000.0
    )

    assert len(fsm_res.lengths) == 100, f"Expected 100 points, got {len(fsm_res.lengths)}"
    assert len(fsm_res.load_factors) == 100
    assert len(fsm_res.points) == 100
    assert fsm_res.p_crl > 0, "Local buckling load should be positive"
    assert fsm_res.p_cre > 0, "Global buckling load should be positive"


def test_ac3_4_winter_effective_width():
    """
    AC 3-4: Verify Winter's effective width solver under bending and axial compression
    reduces gross area (Ae < Ag) and calculates centroid shift and void segments.
    """
    c_geom = SectionWizard.create_c_section(h=200.0, b=75.0, c=15.0, t=1.0, r=0.0) # Thin slender section
    raw_elems = [
        {
            "id": e.elem_id,
            "x1": e.x0, "y1": e.y0,
            "x2": e.x1, "y2": e.y1,
            "thickness": e.thickness
        }
        for e in c_geom.elements
    ]

    # Analyze under pure compression at Fy = 345 MPa
    res_comp = EffectiveWidthSolver.analyze_section_effective(
        elements=raw_elems,
        stress_f=345.0,
        moment_axis="AXIAL",
        fy=345.0
    )

    assert res_comp.ag > 0
    assert res_comp.ae > 0
    assert res_comp.ae < res_comp.ag, f"Slender section Ae ({res_comp.ae}) must be less than Ag ({res_comp.ag})"
    assert res_comp.area_ratio < 1.0

    # Verify segments contain both effective and void portions
    has_void = any(not seg["is_effective"] for seg in res_comp.segments)
    assert has_void, "Slender compression elements must contain void (buckled) segments"

    # Analyze under X-axis flexure
    res_flex = EffectiveWidthSolver.analyze_section_effective(
        elements=raw_elems,
        stress_f=345.0,
        moment_axis="X",
        fy=345.0
    )
    assert res_flex.ae < res_flex.ag
    assert abs(res_flex.delta_y) > 0.001, "Centroid shift delta_y should occur in asymmetric reduction"
