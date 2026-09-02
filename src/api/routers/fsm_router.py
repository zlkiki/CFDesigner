"""
FSM Router: /api/fsm/*
Handles Finite Strip Method elastic buckling signature curve analysis
and custom wavelength sweep with multi-mode shape extraction.
"""

from fastapi import APIRouter

from ._deps import (
    FSMRequest, FSMCustomSweepRequest,
    elements_from_dto, extract_mode_shapes, build_signature_chart_data,
    SectionPropertiesCalculator, StripAssembler, SignatureCurveAnalyzer,
)

router = APIRouter(prefix="/api")


@router.post("/fsm/solve")
async def solve_fsm(req: FSMRequest):
    """
    Performs FSM elastic buckling signature curve analysis.
    Also extracts 3D mode shape displacements for Local, Distortional, and Global modes.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(
        geom=geom,
        props=props,
        e_modulus=req.elastic_modulus,
        poisson=req.poisson_ratio
    )

    analyzer = SignatureCurveAnalyzer(assembler)
    result = analyzer.analyze(
        l_min=req.l_min,
        l_max=req.l_max,
        num_points=req.num_points,
        load_type=req.load_type,
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    nodes_data, strips_data = extract_mode_shapes(assembler, result, req.member_length)
    chart_points, mode_1_curve, mode_2_curve, mode_3_curve = build_signature_chart_data(result)

    return {
        "signature_curve": chart_points,
        "curves": {
            "mode_1": mode_1_curve,
            "mode_2": mode_2_curve,
            "mode_3": mode_3_curve,
        },
        "critical_modes": {
            "load_type": req.load_type,
            "p_crl": round(result.p_crl / 1000.0, 2),
            "l_local": round(result.l_local, 1),
            "p_crd": round(result.p_crd / 1000.0, 2),
            "l_distortional": round(result.l_distortional, 1),
            "p_cre": round(result.p_cre / 1000.0, 2),
            "l_global": round(result.l_global, 1),
            "m_crl": round(result.m_crl / 1e6, 3),
            "m_crd": round(result.m_crd / 1e6, 3),
            "m_cre": round(result.m_cre / 1e6, 3),
            "lf_local": round(result.lf_local, 4),
            "lf_distortional": round(result.lf_distortional, 4),
            "lf_global": round(result.lf_global, 4),
        },
        "nodes": nodes_data,
        "strips": strips_data,
    }


@router.post("/fsm/parameters")
async def fsm_custom_sweep_api(req: FSMCustomSweepRequest):
    """
    Executes FSM elastic buckling analysis with customized half-wavelength sweep range,
    number of steps, and stress distribution.
    Also extracts multi-mode curves (Mode 1, Mode 2, Mode 3) and 3D mode shape displacements.
    """
    geom = elements_from_dto(req.elements, req.thickness)
    gross_props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(
        geom=geom,
        props=gross_props,
        e_modulus=req.elastic_modulus,
        poisson=req.poisson_ratio
    )

    analyzer = SignatureCurveAnalyzer(assembler)
    fsm_res = analyzer.analyze(
        l_min=req.l_min,
        l_max=req.l_max,
        num_points=req.steps,
        load_type=req.load_type,
        yield_stress=req.yield_stress,
        member_length=req.member_length
    )

    nodes_data, strips_data = extract_mode_shapes(assembler, fsm_res, req.member_length)

    # Build chart points with additional fields for custom sweep
    chart_points = []
    mode_1_curve = []
    mode_2_curve = []
    mode_3_curve = []

    for pt in fsm_res.points:
        p_cr_kn = round(pt.critical_load / 1000.0, 2)
        m_cr_knm = round(pt.critical_moment / 1e6, 3)
        m_pcrs = [round(p / 1000.0, 2) for p in pt.mode_critical_loads]
        m_mcrs = [round(m / 1e6, 3) for m in pt.mode_critical_moments]
        m_lfs = [round(lf, 4) for lf in pt.mode_load_factors]

        chart_points.append({
            "length": round(pt.length, 2),
            "load_factor": round(pt.load_factor, 4),
            "p_cr": p_cr_kn,
            "m_cr": m_cr_knm,
            "critical_load": round(pt.critical_load, 1),
            "critical_moment": round(pt.critical_moment, 1),
            "mode_lfs": m_lfs,
            "mode_pcrs": m_pcrs,
            "mode_mcrs": m_mcrs,
        })

        if pt.mode_load_factors:
            mode_1_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[0], 4)})
            if len(pt.mode_load_factors) > 1:
                mode_2_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[1], 4)})
            if len(pt.mode_load_factors) > 2:
                mode_3_curve.append({"x": round(pt.length, 2), "y": round(pt.mode_load_factors[2], 4)})

    critical_modes_data = {
        "load_type": req.load_type,
        "p_crl": round(fsm_res.p_crl / 1000.0, 2),
        "l_local": round(fsm_res.l_local, 1),
        "p_crd": round(fsm_res.p_crd / 1000.0, 2),
        "l_distortional": round(fsm_res.l_distortional, 1),
        "p_cre": round(fsm_res.p_cre / 1000.0, 2),
        "l_global": round(fsm_res.l_global, 1),
        "m_crl": round(fsm_res.m_crl / 1e6, 3),
        "m_crd": round(fsm_res.m_crd / 1e6, 3),
        "m_cre": round(fsm_res.m_cre / 1e6, 3),
        "lf_local": round(fsm_res.lf_local, 4),
        "lf_distortional": round(fsm_res.lf_distortional, 4),
        "lf_global": round(fsm_res.lf_global, 4),
    }

    return {
        "signature_curve": chart_points,
        "curve": {
            "lengths": fsm_res.lengths,
            "load_factors": fsm_res.load_factors,
            "points": chart_points
        },
        "curves": {
            "mode_1": mode_1_curve,
            "mode_2": mode_2_curve,
            "mode_3": mode_3_curve,
        },
        "modes": critical_modes_data,
        "critical_modes": critical_modes_data,
        "nodes": nodes_data,
        "strips": strips_data,
    }
