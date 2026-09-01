"""
Pytest Unit Tests for FSM Elastic Buckling Engine
Covers StripAssembler stress distributions, FSMEigenSolver eigenvalue robustness,
and SignatureCurveAnalyzer under Compression, Major-axis Bending, and Minor-axis Bending.
"""

import pytest
import numpy as np
from src.geometry.section_wizard import SectionWizard
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.eigen_solver import FSMEigenSolver
from src.solver.signature_curve import SignatureCurveAnalyzer


def test_fsm_pure_compression():
    """Test FSM under pure compression."""
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    assembler.apply_loading(load_type="compression")

    # Verify all node stresses are 1.0
    for node in assembler.nodes:
        assert node.stress == pytest.approx(1.0, rel=1e-5)

    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(
        l_min=10.0,
        l_max=5000.0,
        num_points=25,
        load_type="compression",
        yield_stress=345.0,
        member_length=3000.0
    )

    assert len(res.points) == 25
    assert res.p_crl > 0.0
    assert res.p_crd > 0.0
    assert res.p_cre > 0.0
    assert res.l_local > 0.0
    assert res.l_distortional > 0.0


def test_fsm_major_axis_bending():
    """Test FSM under major-axis bending (bending_x / My)."""
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    assembler.apply_loading(load_type="bending_x")

    # Verify stress gradient (top is positive/compression, bottom is negative/tension)
    ycg = props.ycg
    top_nodes = [n for n in assembler.nodes if n.y > ycg + 10]
    bot_nodes = [n for n in assembler.nodes if n.y < ycg - 10]
    assert len(top_nodes) > 0 and len(bot_nodes) > 0
    assert all(n.stress > 0 for n in top_nodes)
    assert all(n.stress < 0 for n in bot_nodes)

    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(
        l_min=10.0,
        l_max=5000.0,
        num_points=25,
        load_type="bending_x",
        yield_stress=345.0,
        member_length=3000.0
    )

    assert len(res.points) == 25
    assert res.load_type == "bending_x"
    assert res.m_crl > 0.0
    assert res.m_crd > 0.0
    assert res.m_cre > 0.0
    assert res.lf_local > 0.0


def test_fsm_minor_axis_bending():
    """Test FSM under minor-axis bending (bending_y / Mx)."""
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    assembler.apply_loading(load_type="bending_y")

    xcg = props.xcg
    right_nodes = [n for n in assembler.nodes if n.x > xcg + 5]
    left_nodes = [n for n in assembler.nodes if n.x < xcg - 5]
    assert len(right_nodes) > 0 and len(left_nodes) > 0
    assert all(n.stress > 0 for n in right_nodes)
    assert all(n.stress < 0 for n in left_nodes)

    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(
        l_min=10.0,
        l_max=5000.0,
        num_points=25,
        load_type="bending_y",
        yield_stress=345.0,
        member_length=3000.0
    )

    assert len(res.points) == 25
    assert res.load_type == "bending_y"
    assert res.m_crl > 0.0
    assert res.m_crd > 0.0
    assert res.m_cre > 0.0


def test_eigen_solver_indefinite_kg():
    """Test FSMEigenSolver with indefinite Kg matrix."""
    # Synthetic problem with tension & compression
    ke = np.diag([100.0, 150.0, 200.0, 250.0])
    kg = np.diag([1.0, -0.5, 2.0, -1.0])

    lf, mode = FSMEigenSolver.solve_min_eigenvalue(ke, kg)
    assert lf > 0.0
    assert not np.isinf(lf)
    # Lowest positive eigenvalue: 100/1 = 100, 200/2 = 100 -> lf = 100.0
    assert lf == pytest.approx(100.0, rel=1e-3)
    assert mode is not None


def test_fsm_closed_tube_node_coincidence():
    """Test that closed box tube section correctly merges start and end nodes."""
    geom = SectionWizard.create_tube_section(h=100.0, b=100.0, t=3.0)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    
    # Check that corner nodes are shared (every node is connected to at least 2 strips)
    node_connections = {node.node_id: 0 for node in assembler.nodes}
    for strip in assembler.strips:
        node_connections[strip.node_i] += 1
        node_connections[strip.node_j] += 1

    # In a closed loop tube, all nodes must have degree 2
    assert all(count == 2 for count in node_connections.values())

    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(
        l_min=10.0,
        l_max=3000.0,
        num_points=20,
        load_type="compression",
        yield_stress=345.0,
        member_length=2000.0
    )

    assert len(res.points) == 20
    assert res.p_crl > 0.0
    assert res.p_cre > 0.0


def test_fsm_multi_mode_eigenvalues_ascending():
    """AC 10-1: Test that FSMEigenSolver and SignatureCurveAnalyzer produce multiple positive eigenvalues in ascending order."""
    geom = SectionWizard.create_c_section(h=150.0, b=65.0, c=20.0, t=2.0, r=2.0)
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    assembler.apply_loading(load_type="compression")

    ke, kg = assembler.assemble_matrices(half_wavelength=100.0)
    modes = FSMEigenSolver.solve_eigenvalues(ke, kg, num_modes=3)

    assert len(modes) == 3
    # Check ascending order: lambda_1 <= lambda_2 <= lambda_3
    lf1, v1 = modes[0]
    lf2, v2 = modes[1]
    lf3, v3 = modes[2]

    assert 0.0 < lf1 <= lf2 <= lf3
    assert v1.shape == v2.shape == v3.shape
    assert np.max(np.abs(v1)) == pytest.approx(1.0, rel=1e-3)
    assert np.max(np.abs(v2)) == pytest.approx(1.0, rel=1e-3)
    assert np.max(np.abs(v3)) == pytest.approx(1.0, rel=1e-3)

    # Check multi-mode signature curve arrays
    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(l_min=20.0, l_max=2000.0, num_points=10)
    assert len(res.mode_1_lfs) == 10
    assert len(res.mode_2_lfs) == 10
    assert len(res.mode_3_lfs) == 10
    assert all(m1 <= m2 for m1, m2 in zip(res.mode_1_lfs, res.mode_2_lfs))


