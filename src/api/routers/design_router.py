"""
Design Router: /api/design/*
Handles KDS 14 31 10 / AISI S100 DSM member design checks,
web crippling detailed calculation, and quick design (auto-sizing).
"""

from fastapi import APIRouter

from ._deps import (
    DesignCheckRequest, WebCripplingDetailedRequest, QuickDesignSearchRequest,
    elements_from_dto,
    SectionPropertiesCalculator, StripAssembler, SignatureCurveAnalyzer,
    DSMCompression, DSMFlexure, WebShearAndCrippling, BeamColumnInteraction,
    QuickDesignEngine,
)

router = APIRouter(prefix="/api")


@router.post("/design/check")
async def check_design(req: DesignCheckRequest):
    """
    Performs comprehensive KDS 14 31 10 & AISI S100 Direct Strength Method (DSM) design checks.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    # 1. FSM Buckling Loads (Compute if not provided)
    assembler = StripAssembler(geom=geom, props=props, e_modulus=req.elastic_modulus)
    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        yield_stress=req.yield_stress,
        member_length=max(req.length_x, req.length_y, req.length_t)
    )

    p_crl = req.p_crl * 1000.0 if (req.p_crl and req.p_crl > 0) else fsm_res.p_crl
    p_crd = req.p_crd * 1000.0 if (req.p_crd and req.p_crd > 0) else fsm_res.p_crd
    p_cre = req.p_cre * 1000.0 if (req.p_cre and req.p_cre > 0) else fsm_res.p_cre

    # 2. Compression Check
    comp_res = DSMCompression.design_column(
        ag=props.area,
        fy=req.yield_stress,
        p_cre=p_cre,
        p_crl=p_crl,
        p_crd=p_crd
    )
    comp_dc = (req.pu * 1000.0) / comp_res.phi_pn if comp_res.phi_pn > 1e-6 else 0.0

    # 3. Flexure Check
    py = props.area * req.yield_stress
    m_y = props.sx_top * req.yield_stress
    m_crl = (p_crl / py) * m_y if py > 0 else m_y
    m_crd = (p_crd / py) * m_y if py > 0 else m_y
    m_cre = (p_cre / py) * m_y if py > 0 else m_y

    flex_res = DSMFlexure.design_beam(
        sf=props.sx_top,
        fy=req.yield_stress,
        m_cre=m_cre,
        m_crl=m_crl,
        m_crd=m_crd
    )
    flex_dc = (req.mux * 1e6) / flex_res.phi_mn if flex_res.phi_mn > 1e-6 else 0.0

    # 4. Shear & Web Crippling Check
    h_w = 0.0
    for elem in geom.elements:
        dy = abs(elem.y1 - elem.y0)
        if dy > h_w:
            h_w = dy

    v_n = WebShearAndCrippling.calculate_shear(
        h=h_w if h_w > 0 else 100.0,
        t=req.thickness,
        fy=req.yield_stress,
        e_mod=req.elastic_modulus
    )
    phi_vn = WebShearAndCrippling.PHI_V * v_n
    shear_dc = (req.vu * 1000.0) / phi_vn if phi_vn > 1e-6 else 0.0

    p_nc = WebShearAndCrippling.calculate_web_crippling(
        h=h_w if h_w > 0 else 100.0,
        t=req.thickness,
        r=2.0,
        n_bearing=50.0,
        fy=req.yield_stress
    )
    phi_pnc = WebShearAndCrippling.PHI_W * p_nc

    # 5. P-M Interaction Check
    interaction = BeamColumnInteraction.check_interaction(
        pu=req.pu * 1000.0,
        phi_pn=comp_res.phi_pn,
        mux=req.mux * 1e6,
        phi_mnx=flex_res.phi_mn,
        muy=req.muy * 1e6,
        phi_mny=flex_res.phi_mn * 0.3,
        cmx=1.0,
        cmy=1.0
    )

    return {
        "compression": {
            "p_ne": round(comp_res.pne / 1000.0, 2),
            "p_nl": round(comp_res.pnl / 1000.0, 2),
            "p_nd": round(comp_res.pnd / 1000.0, 2),
            "p_n": round(comp_res.pn / 1000.0, 2),
            "phi_pn": round(comp_res.phi_pn / 1000.0, 2),
            "dc_ratio": round(comp_dc, 3),
            "status": "OK" if comp_dc <= 1.0 else "NG",
            "governing_mode": comp_res.governing_mode,
        },
        "flexure": {
            "m_ne": round(flex_res.mne / 1e6, 3),
            "m_nl": round(flex_res.mnl / 1e6, 3),
            "m_nd": round(flex_res.mnd / 1e6, 3),
            "m_n": round(flex_res.mn / 1e6, 3),
            "phi_mn": round(flex_res.phi_mn / 1e6, 3),
            "dc_ratio": round(flex_dc, 3),
            "status": "OK" if flex_dc <= 1.0 else "NG",
            "governing_mode": flex_res.governing_mode,
        },
        "shear": {
            "v_n": round(v_n / 1000.0, 2),
            "phi_vn": round(phi_vn / 1000.0, 2),
            "dc_ratio": round(shear_dc, 3),
            "status": "OK" if shear_dc <= 1.0 else "NG",
        },
        "web_crippling": {
            "p_nc": round(p_nc / 1000.0, 2),
            "phi_pnc": round(phi_pnc / 1000.0, 2),
        },
        "interaction": {
            "ratio": round(interaction.controlling_dcr, 3),
            "status": "OK" if interaction.is_safe else "NG",
            "formula_type": "식 (1.4-1)",
        }
    }


@router.post("/design/web-crippling")
async def calculate_web_crippling_api(req: WebCripplingDetailedRequest):
    """
    Computes web crippling nominal and design capacities for 4 support conditions
    (EOF, IOF, ETF, ITF) per KDS 14 31 10 4.4 and AISI S100 G5.
    """
    res = WebShearAndCrippling.calculate_web_crippling_advanced(
        h=req.h,
        t=req.t,
        r=req.r,
        n_bearing=req.n_bearing,
        fy=req.fy,
        condition=req.condition,
        fastened=req.fastened,
        stiffened=req.stiffened,
        theta_deg=req.theta_deg,
        ru=req.ru
    )
    return res


@router.post("/design/quick-design")
async def quick_design_search_api(req: QuickDesignSearchRequest):
    """
    Scans library sections, executes DSM compression, flexure, shear,
    serviceability deflection, and web crippling design checks,
    and returns top candidates sorted by weight ascending.
    """
    res = QuickDesignEngine.search_optimal_sections(
        pu_kn=req.pu,
        mux_knm=req.mux,
        muy_knm=req.muy,
        vu_kn=req.vu,
        length_mm=req.length,
        fy_mpa=req.fy,
        depth_filter=req.depth_filter,
        shape_type_filter=req.shape_type_filter,
        flange_filter=req.flange_filter,
        thickness_filter=req.thickness_filter,
        punched=req.punched,
        config=req.config,
        cold_work=req.cold_work,
        reserve=req.reserve,
        span_mm=req.span if req.span is not None else req.length,
        spacing_mm=req.spacing,
        bracing=req.bracing,
        dead_load_kpa=req.dead_load,
        live_load_kpa=req.live_load,
        wind_load_kpa=req.wind_load,
        dead_axial_kn=req.dead_axial,
        live_axial_kn=req.live_axial,
        deflection_live_limit=req.deflection_live_limit,
        deflection_total_limit=req.deflection_total_limit,
        bearing_length_mm=req.bearing_length,
        bearing_condition=req.bearing_condition,
        max_depth_mm=req.max_depth,
        max_weight_kgm=req.max_weight,
        library_filter=req.library,
        max_results=req.max_results
    )
    return res
