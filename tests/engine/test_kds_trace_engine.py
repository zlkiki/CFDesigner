"""
Unit Tests for KDS 14 31 10 & AISI S100 Structural Calculation Trace Engine.
Tests all limit states: Tension, Compression, Flexure, Shear, Crippling, and Multi-Axis Interaction.
"""

import pytest
from src.design.kds_trace_engine import KDSTraceEngine, TraceItem, DesignTraceResult


def test_tension_trace():
    ag = 1200.0  # mm²
    an = 1000.0  # mm²
    fy = 250.0   # MPa
    fu = 400.0   # MPa
    tu = 150.0   # kN

    traces = KDSTraceEngine.trace_tension(ag, an, fy, fu, tu)
    assert len(traces) == 2

    # Gross section yield
    t_yield = traces[0]
    assert t_yield.id == "tension_yield"
    assert t_yield.clause_kds == "KDS 14 31 10 (4.1.1)"
    assert t_yield.nominal_value == pytest.approx(300.0, 0.1)  # 1200 * 250 / 1000
    assert t_yield.design_value == pytest.approx(270.0, 0.1)   # 0.90 * 300
    assert t_yield.dc_ratio == pytest.approx(150.0 / 270.0, 0.01)
    assert t_yield.status == "OK"
    assert "T_n = A_g" in t_yield.formula_latex

    # Net section rupture
    t_rupture = traces[1]
    assert t_rupture.id == "tension_rupture"
    assert t_rupture.nominal_value == pytest.approx(400.0, 0.1) # 1000 * 400 / 1000
    assert t_rupture.design_value == pytest.approx(300.0, 0.1)  # 0.75 * 400
    assert t_rupture.dc_ratio == pytest.approx(150.0 / 300.0, 0.01)


def test_compression_trace():
    ag = 1000.0  # mm²
    fy = 345.0   # MPa
    p_cre = 200000.0  # N (200 kN)
    p_crl = 150000.0  # N (150 kN)
    p_crd = 180000.0  # N (180 kN)
    pu = 100.0        # kN

    traces = KDSTraceEngine.trace_compression(ag, fy, p_cre, p_crl, p_crd, pu)
    assert len(traces) == 5  # Squash, Global, Local, Distortional, Governing

    squash = traces[0]
    assert squash.nominal_value == pytest.approx(345.0, 0.1)

    global_item = traces[1]
    assert global_item.id == "comp_global"
    assert global_item.clause_kds == "KDS 14 31 10 (4.1.2.1)"
    assert global_item.parameters["lambda_c"] == pytest.approx((345.0 / 200.0) ** 0.5, 0.01)

    local_item = traces[2]
    assert local_item.id == "comp_local"
    assert "lambda_l" in local_item.parameters

    dist_item = traces[3]
    assert dist_item.id == "comp_distortional"
    assert "lambda_d" in dist_item.parameters

    gov_item = traces[4]
    assert gov_item.id == "comp_governing"
    assert gov_item.nominal_value <= min(global_item.nominal_value, local_item.nominal_value, dist_item.nominal_value)
    assert gov_item.design_value == pytest.approx(gov_item.nominal_value * 0.85, 0.1)
    assert gov_item.status == "OK"


def test_flexure_trace():
    sf = 40000.0  # mm³
    fy = 240.0    # MPa
    m_cre = 15.0 * 1e6 # N-mm (15 kN-m)
    m_crl = 12.0 * 1e6 # N-mm (12 kN-m)
    m_crd = 10.0 * 1e6 # N-mm (10 kN-m)
    mu = 5.0      # kN-m

    traces = KDSTraceEngine.trace_flexure(sf, fy, m_cre, m_crl, m_crd, "X", mu)
    assert len(traces) == 5

    yield_item = traces[0]
    assert yield_item.nominal_value == pytest.approx(9.6, 0.1)  # 40000 * 240 / 1e6

    gov_item = traces[4]
    assert gov_item.id == "flex_governing_x"
    assert gov_item.design_value == pytest.approx(gov_item.nominal_value * 0.90, 0.01)
    assert gov_item.dc_ratio == pytest.approx(mu / gov_item.design_value, 0.01)
    assert gov_item.status == "OK"


def test_shear_and_crippling_trace():
    # Shear
    h = 200.0
    t = 2.0
    fy = 300.0
    vu = 30.0
    shear_traces = KDSTraceEngine.trace_shear(h, t, fy, vu)
    assert len(shear_traces) == 1
    assert shear_traces[0].id == "shear_web"
    assert shear_traces[0].clause_kds == "KDS 14 31 10 (4.3.1)"
    assert shear_traces[0].nominal_value > 0

    # Crippling
    crip_traces = KDSTraceEngine.trace_web_crippling(
        c=13.0, cr=0.23, cn=0.14, ch=0.01,
        t=2.0, fy=300.0, r=3.0, n=50.0, h=200.0,
        condition="IOF", ru=15.0
    )
    assert len(crip_traces) == 1
    assert crip_traces[0].id == "web_crippling"
    assert crip_traces[0].clause_kds == "KDS 14 31 10 (4.4.1)"
    assert crip_traces[0].nominal_value > 0


def test_interaction_trace():
    pu = 50.0
    phi_pn = 150.0
    mux = 4.0
    phi_mnx = 10.0
    muy = 1.0
    phi_mny = 4.0
    vu = 15.0
    phi_vn = 45.0
    ru = 8.0
    phi_pnc = 25.0

    traces = KDSTraceEngine.trace_interaction(
        pu, phi_pn, mux, phi_mnx, muy, phi_mny,
        vu=vu, phi_vn=phi_vn, ru=ru, phi_pnc=phi_pnc
    )
    assert len(traces) == 4

    sec_inter = traces[0]
    assert sec_inter.id == "inter_cross_section"
    expected_dc = (50.0 / 150.0) + (4.0 / 10.0) + (1.0 / 4.0)
    assert sec_inter.dc_ratio == pytest.approx(expected_dc, 0.01)

    stab_inter = traces[1]
    assert stab_inter.id == "inter_member_stability"
    assert stab_inter.dc_ratio == pytest.approx(expected_dc, 0.01)

    shear_inter = traces[2]
    assert shear_inter.id == "inter_bending_shear"
    expected_m_v = ((4.0 / 10.0) ** 2 + (15.0 / 45.0) ** 2) ** 0.5
    assert shear_inter.dc_ratio == pytest.approx(expected_m_v, 0.01)

    crip_inter = traces[3]
    assert crip_inter.id == "inter_bending_crippling"


def test_full_trace_generator():
    props = {"area": 850.0, "sxt": 42000.0, "sxb": 42000.0, "syl": 18000.0, "syr": 18000.0, "depth": 150.0, "thickness": 1.5}
    material = {"fy": 275.0, "fu": 410.0}
    fsm = {
        "p_cre": 180000.0, "p_crl": 120000.0, "p_crd": 140000.0,
        "m_cre_x": 12.0 * 1e6, "m_crl_x": 9.0 * 1e6, "m_crd_x": 10.0 * 1e6
    }
    loads = {"pu": 40.0, "mux": 3.0, "muy": 0.5, "vu": 10.0, "ru": 5.0}

    res = KDSTraceEngine.generate_full_trace(props, material, fsm, loads)
    assert isinstance(res, DesignTraceResult)
    assert len(res.tension) > 0
    assert len(res.compression) > 0
    assert len(res.flexure_x) > 0
    assert len(res.flexure_y) > 0
    assert len(res.shear) > 0
    assert len(res.web_crippling) > 0
    assert len(res.interaction) > 0
    assert len(res.summary_logs) > 0
    assert len(res.equations_cfs) > 0

    res_dict = res.to_dict()
    assert "tension" in res_dict
    assert "summary_logs" in res_dict
