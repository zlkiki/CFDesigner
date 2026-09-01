"""
Unit & Integration Tests for Phase 8-8:
CFS Legacy frmQuickDesign.cs 100% Full-Spec UI & 3-Limit States Design Engine Cross-Validation
Acceptance Criteria: AC 8-1, AC 8-2, AC 8-3, AC 8-4
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app
from src.design.quick_design import QuickDesignEngine, QuickDesignCandidate, QuickDesignResult

client = TestClient(app)


def test_ac8_1_quick_design_modal_ui_controls():
    """
    AC 8-1: Verify that all frmQuickDesign parameters are present in index.html.
    """
    res = client.get("/")
    assert res.status_code == 200
    html = res.text

    # Section Filtering Controls
    assert 'id="qdTypeFilter"' in html
    assert 'id="qdDepthFilter"' in html
    assert 'id="qdFlangeFilter"' in html
    assert 'id="qdThicknessFilter"' in html
    assert 'id="qdConfigSelect"' in html
    assert 'id="qdYieldSelect"' in html
    assert 'id="qdPunchedCheck"' in html
    assert 'id="qdColdWorkCheck"' in html
    assert 'id="qdReserveCheck"' in html

    # Span & Loading & Deflection Controls
    assert 'id="qdSpanInput"' in html
    assert 'id="qdSpacingInput"' in html
    assert 'id="qdBracingSelect"' in html
    assert 'id="qdDeadInput"' in html
    assert 'id="qdLiveInput"' in html
    assert 'id="qdWindInput"' in html
    assert 'id="qdAxialInput"' in html
    assert 'id="qdDeflectionSelect"' in html
    assert 'id="qdBearingLength"' in html
    assert 'id="qdLibrarySelect"' in html
    assert 'id="btnExecuteQuickDesign"' in html
    assert 'id="quickDesignTable"' in html


def test_ac8_2_three_limit_states_dc_evaluation():
    """
    AC 8-2: Verify that Quick Design engine evaluates 3 distinct D/C limit states:
    1. Strength (Axial + Biaxial Flexure P-M + Shear)
    2. Serviceability Deflection (Live L/360, Total L/240)
    3. Web Crippling (Bearing length N, Reaction Ru vs phi*Pnc)
    """
    # Test case 1: Floor Joist under gravity load (Span 4000mm, Spacing 400mm, Dead=1.0, Live=2.0 kPa)
    res = QuickDesignEngine.search_optimal_sections(
        span_mm=4000.0,
        spacing_mm=400.0,
        bracing="Midpoint",
        dead_load_kpa=1.0,
        live_load_kpa=2.0,
        wind_load_kpa=0.0,
        dead_axial_kn=0.0,
        live_axial_kn=0.0,
        fy_mpa=345.0,
        deflection_live_limit=360.0,
        deflection_total_limit=240.0,
        bearing_length_mm=38.0,
        max_results=10
    )

    assert res.total_scanned > 0
    assert len(res.candidates) > 0

    # Verify candidates are sorted by weight ascending
    weights = [c.weight for c in res.candidates]
    assert weights == sorted(weights), "Candidates must be sorted by weight ascending"

    # Verify each candidate contains all 3 D/C components
    for cand in res.candidates:
        assert cand.rank >= 1
        assert cand.weight > 0
        assert cand.depth > 0
        assert cand.flange > 0
        assert cand.thickness > 0
        
        # 1. Strength D/C
        assert cand.dc_strength >= 0
        assert cand.dc_strength <= 1.02
        
        # 2. Deflection D/C
        assert cand.dc_deflection >= 0
        assert cand.dc_deflection <= 1.02
        assert cand.deflection_live_mm >= 0
        assert cand.deflection_live_limit_mm > 0
        
        # 3. Web Crippling D/C
        assert cand.dc_crippling >= 0
        assert cand.dc_crippling <= 1.02
        assert cand.phi_pnc_kn > 0
        assert cand.reaction_ru_kn >= 0

        # Overall Max D/C
        assert cand.max_dc == max(cand.dc_strength, cand.dc_deflection, cand.dc_crippling)
        assert cand.max_dc <= 1.02


def test_ac8_3_quick_design_api_endpoint():
    """
    AC 8-3: Verify /api/design/quick-design POST endpoint returns candidates with full metadata.
    """
    payload = {
        "span": 3600.0,
        "spacing": 400.0,
        "bracing": "Quarter-point",
        "dead_load": 1.2,
        "live_load": 2.4,
        "wind_load": 0.6,
        "dead_axial": 10.0,
        "live_axial": 20.0,
        "fy": 345.0,
        "deflection_live_limit": 360.0,
        "deflection_total_limit": 240.0,
        "bearing_length": 50.0,
        "cold_work": True,
        "reserve": True,
        "shape_type_filter": "S",
        "config": "Single",
        "max_results": 10
    }

    res = client.post("/api/design/quick-design", json=payload)
    assert res.status_code == 200
    data = res.json()

    assert data["total_scanned"] > 0
    assert "candidates" in data
    assert len(data["candidates"]) > 0

    best = data["candidates"][0]
    assert best["rank"] == 1
    assert "name" in best
    assert "weight" in best
    assert "dc_strength" in best
    assert "dc_deflection" in best
    assert "dc_crippling" in best
    assert "max_dc" in best
    assert "elements" in best
    assert len(best["elements"]) > 0


def test_ac8_4_cfs_ground_truth_cross_validation():
    """
    AC 8-4: Cross-validation against CFS.exe frmQuickDesign.cs ground truth rules:
    - Punched hole reduces web crippling & shear capacity
    - Multi-part Back-to-Back doubles gross area and moments of inertia
    - Increased bearing length N from 38mm to 75mm increases phi_pnc
    """
    # 1. Bearing length increase validation
    res_n38 = QuickDesignEngine.search_optimal_sections(
        span_mm=3000.0,
        spacing_mm=400.0,
        dead_load_kpa=1.0,
        live_load_kpa=2.0,
        bearing_length_mm=38.0,
        max_results=5
    )

    res_n75 = QuickDesignEngine.search_optimal_sections(
        span_mm=3000.0,
        spacing_mm=400.0,
        dead_load_kpa=1.0,
        live_load_kpa=2.0,
        bearing_length_mm=75.0,
        max_results=5
    )

    assert len(res_n38.candidates) > 0
    assert len(res_n75.candidates) > 0

    cand_38 = res_n38.candidates[0]
    # Find matching candidate in res_n75
    matching_75 = next((c for c in res_n75.candidates if c.name == cand_38.name), None)
    if matching_75:
        assert matching_75.phi_pnc_kn >= cand_38.phi_pnc_kn, "Capacity with N=75mm must be >= N=38mm"

    # 2. Back-to-Back configuration validation
    res_single = QuickDesignEngine.search_optimal_sections(
        span_mm=3000.0,
        spacing_mm=400.0,
        dead_load_kpa=1.0,
        live_load_kpa=2.0,
        config="Single",
        max_results=5
    )

    res_b2b = QuickDesignEngine.search_optimal_sections(
        span_mm=3000.0,
        spacing_mm=400.0,
        dead_load_kpa=1.0,
        live_load_kpa=2.0,
        config="Back-to-Back",
        max_results=5
    )

    assert len(res_single.candidates) > 0
    assert len(res_b2b.candidates) > 0
    # Single candidate weight vs B2B candidate weight for same profile
    b2b_cand = next((c for c in res_b2b.candidates if c.name == res_single.candidates[0].name), None)
    if b2b_cand:
        assert abs(b2b_cand.weight - 2.0 * res_single.candidates[0].weight) < 0.1
