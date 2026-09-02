"""
Analysis Router: /api/analysis/*
Handles 1D Frame & Beam FEM Analysis and transfer of results to DSM design checks.
"""

from fastapi import APIRouter

from ._deps import (
    Frame1DRunRequest, TransferToDesignRequest,
    elements_from_dto,
    SectionPropertiesCalculator, StripAssembler, SignatureCurveAnalyzer,
    DSMCompression, DSMFlexure, WebShearAndCrippling, BeamColumnInteraction,
    Frame1DSolver,
)

router = APIRouter(prefix="/api")


@router.post("/analysis/run")
async def run_frame1d_analysis_api(req: Frame1DRunRequest):
    """
    Executes 1D FEM matrix analysis for single span, continuous beams, and cantilevers.
    Returns reactions, continuous SFD, BMD, Deflection, and max forces.
    """
    res = Frame1DSolver.analyze(
        spans=req.spans,
        supports=req.supports,
        loads=req.loads,
        default_e=req.e_mod,
        default_ix=req.ix,
        default_area=req.area,
        self_weight_w=req.self_weight_w,
        num_eval_points=req.num_eval_points
    )
    return res


@router.post("/analysis/transfer-to-design")
async def transfer_to_design_api(req: TransferToDesignRequest):
    """
    Transfers maximum internal forces from 1D structural analysis directly into
    KDS 14 31 10 DSM member design check.
    """
    mf = req.max_forces
    pu_val = float(mf.get("pu_max", 0.0))
    mux_val = float(mf.get("mux_max", 0.0))
    vu_val = float(mf.get("vu_max", 0.0))

    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    # 1. FSM Buckling loads
    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0)
    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    # 2. DSM Checks
    comp_res = DSMCompression.design_column(
        ag=props.area,
        fy=req.yield_stress,
        p_cre=fsm_res.p_cre,
        p_crl=fsm_res.p_crl,
        p_crd=fsm_res.p_crd
    )
    comp_dc = (pu_val * 1000.0) / comp_res.phi_pn if comp_res.phi_pn > 1e-6 else 0.0

    py = props.area * req.yield_stress
    m_y = props.sx_top * req.yield_stress
    m_crl = (fsm_res.p_crl / py) * m_y if py > 0 else m_y
    m_crd = (fsm_res.p_crd / py) * m_y if py > 0 else m_y
    m_cre = (fsm_res.p_cre / py) * m_y if py > 0 else m_y

    flex_res = DSMFlexure.design_beam(
        sf=props.sx_top,
        fy=req.yield_stress,
        m_cre=m_cre,
        m_crl=m_crl,
        m_crd=m_crd
    )
    flex_dc = (mux_val * 1e6) / flex_res.phi_mn if flex_res.phi_mn > 1e-6 else 0.0

    # Shear
    hw = max([abs(e.y1 - e.y0) for e in geom.elements] + [100.0])
    vn = WebShearAndCrippling.calculate_shear(
        h=hw, t=req.thickness, fy=req.yield_stress, e_mod=205000.0
    )
    phi_vn = WebShearAndCrippling.PHI_V * vn
    shear_dc = (vu_val * 1000.0) / phi_vn if phi_vn > 1e-6 else 0.0

    inter_res = BeamColumnInteraction.check_interaction(
        pu=pu_val * 1000.0,
        phi_pn=comp_res.phi_pn,
        mux=mux_val * 1e6,
        phi_mnx=flex_res.phi_mn,
        muy=0.0,
        phi_mny=1e9
    )

    return {
        "applied_forces": {"pu": pu_val, "mux": mux_val, "vu": vu_val},
        "compression": {
            "phi_pn": round(comp_res.phi_pn / 1000.0, 2),
            "dc_ratio": round(comp_dc, 3),
            "status": "OK" if comp_dc <= 1.0 else "NG",
            "governing_mode": comp_res.governing_mode
        },
        "flexure": {
            "phi_mn": round(flex_res.phi_mn / 1e6, 2),
            "dc_ratio": round(flex_dc, 3),
            "status": "OK" if flex_dc <= 1.0 else "NG",
            "governing_mode": flex_res.governing_mode
        },
        "shear": {
            "phi_vn": round(phi_vn / 1000.0, 2),
            "dc_ratio": round(shear_dc, 3),
            "status": "OK" if shear_dc <= 1.0 else "NG"
        },
        "interaction": {
            "ratio": round(inter_res.controlling_dcr, 3),
            "status": "OK" if inter_res.is_safe else "NG"
        }
    }
