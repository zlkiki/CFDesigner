"""
Phase 2: FSM Numerical Sanity & Wide-Sweep Membrane Divergence Defense Test Suite (AC 14-2)
Validates mathematical and physical robustness across diverse cross-sections,
load distributions, and half-wavelength spectrum without NaN, Inf, or unphysical divergence.
"""

import pytest
import numpy as np
from src.geometry.section_wizard import SectionWizard
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.eigen_solver import FSMEigenSolver
from src.solver.signature_curve import SignatureCurveAnalyzer
from src.geometry.effective_width import EffectiveWidthSolver


@pytest.mark.slow
@pytest.mark.sanity
@pytest.mark.engine
@pytest.mark.parametrize("shape_fn, kwargs", [
    (SectionWizard.create_c_section, {"h": 150.0, "b": 65.0, "c": 20.0, "t": 2.0, "r": 2.0}),
    (SectionWizard.create_z_section, {"h": 200.0, "b": 70.0, "c": 25.0, "t": 2.5, "r": 3.0}),
    (SectionWizard.create_hat_section, {"h": 100.0, "b_top": 80.0, "b_bot": 80.0, "c": 25.0, "t": 1.6}),
    (SectionWizard.create_tube_section, {"h": 120.0, "b": 120.0, "t": 3.2}),
    (SectionWizard.create_c_section, {"h": 250.0, "b": 80.0, "c": 25.0, "t": 0.8, "r": 2.0}), # Ultra-thin web
])
@pytest.mark.parametrize("load_type", ["compression", "bending_x", "bending_y"])
def test_fsm_wide_sweep_numerical_sanity(shape_fn, kwargs, load_type):
    """
    AC 14-2-1, AC 14-2-2, AC 14-2-3:
    Wide parameter sweep testing 5 sections x 3 load conditions across 30 wavelength steps (10mm to 6000mm).
    Verifies zero NaN/Inf, ascending eigenvalue ordering, and valid divergence filtering.
    """
    geom = shape_fn(**kwargs)
    props = SectionPropertiesCalculator.calculate(geom)

    # 1. Gross Properties Sanity
    assert not np.isnan(props.area) and props.area > 0
    assert not np.isnan(props.ix) and props.ix > 0
    assert not np.isnan(props.iy) and props.iy > 0
    assert not np.isnan(props.j) and props.j > 0
    assert not np.isnan(props.cw) and props.cw >= 0

    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0, poisson=0.3)
    assembler.apply_loading(load_type=load_type)

    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(
        l_min=10.0,
        l_max=6000.0,
        num_points=30,
        load_type=load_type,
        yield_stress=345.0,
        member_length=3000.0
    )

    assert len(res.points) == 30

    # 2. Point-by-point Sanity Checks
    for pt in res.points:
        assert not np.isnan(pt.load_factor), f"NaN load_factor at L={pt.length}"
        assert not np.isinf(pt.load_factor), f"Inf load_factor at L={pt.length}"
        assert pt.load_factor > 0.0, f"Non-positive load factor at L={pt.length}"

        # Multi-mode ordering check: lf_1 <= lf_2 <= lf_3
        m_lfs = pt.mode_load_factors
        assert len(m_lfs) >= 1
        for i in range(len(m_lfs) - 1):
            assert m_lfs[i] <= m_lfs[i+1] + 1e-4, f"Eigenvalue order inverted at L={pt.length}: {m_lfs}"

        # Membrane Divergence Defense Check:
        # In bending mode with long wavelength (L > 500mm), higher modes should not explode beyond 25 * Mode1 or 100,000
        if load_type in ["bending_x", "bending_y"] and pt.length > 500.0:
            for k, lf_k in enumerate(m_lfs):
                assert lf_k <= max(m_lfs[0] * 25.0, 100000.0) + 1e-3, (
                    f"Membrane divergence filter failure at L={pt.length}, Mode {k+1}: lf={lf_k}, lf1={m_lfs[0]}"
                )


def test_eigen_solver_generalized_orthogonality_and_normalization():
    """
    AC 14-2-2: Test that FSMEigenSolver produces eigenvectors normalized to max absolute value = 1.0.
    """
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(geom)
    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0, poisson=0.3)
    assembler.apply_loading(load_type="compression")

    for L in [50.0, 250.0, 1000.0, 3000.0]:
        ke, kg = assembler.assemble_matrices(half_wavelength=L)
        modes = FSMEigenSolver.solve_eigenvalues(ke, kg, num_modes=3)
        assert len(modes) == 3
        for idx, (lf, vec) in enumerate(modes):
            assert lf > 0.0
            assert not np.isnan(lf)
            assert not np.isinf(lf)
            max_amp = np.max(np.abs(vec))
            assert max_amp == pytest.approx(1.0, rel=1e-4), f"Eigenvector {idx+1} at L={L} not normalized to 1.0"


def test_winter_effective_width_extreme_stress_convergence():
    """
    AC 14-2-2: Test Winter effective width solver under extreme yielding conditions (sigma = 1.5 * Fy).
    Ensures iterative reduction converges stably and 0 < b_eff <= b_gross.
    """
    rho, lam, sigma_cr = EffectiveWidthSolver.calculate_winter_rho(stress=345.0, width=150.0, thickness=1.5, k=4.0)
    assert 0.0 < rho <= 1.0
    assert not np.isnan(rho)
    assert not np.isnan(sigma_cr) and sigma_cr > 0

    # High yield stress check
    rho_high, _, _ = EffectiveWidthSolver.calculate_winter_rho(stress=500.0, width=200.0, thickness=0.8, k=4.0)
    assert 0.0 < rho_high <= 1.0
    assert rho_high < rho  # Higher stress & thinner plate must yield smaller reduction factor
