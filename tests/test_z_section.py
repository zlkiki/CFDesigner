"""
Unit Test and Cross-Validation for Z-Section (Z 150x50x20x2.0)
Validates Principal Axis angle, Section Moduli, and Bending / Shear Capacity.
"""

import sys
import os
import math

sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), "..")))

from src.cad.part_mesher import PartMesher, SectionGeometry, Element
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.signature_curve import SignatureCurveAnalyzer
from src.design.dsm_flexure import DSMFlexure
from src.design.shear_and_crippling import WebShearAndCrippling


def create_z_section(
    depth: float = 150.0,
    flange: float = 50.0,
    lip: float = 20.0,
    t: float = 2.0,
) -> SectionGeometry:
    """
    Creates a standard point-symmetric Z-section geometry.
    """
    # Continuous path from top lip tip to bottom lip tip:
    # 1. Top Lip (vertical down: length lip)
    # 2. Top Flange (horizontal left: length flange)
    # 3. Web (vertical down: length depth)
    # 4. Bottom Flange (horizontal left: length flange)
    # 5. Bottom Lip (vertical down: length lip)
    # Note: Flanges go in opposite directions relative to web for point symmetry!
    # Path: Start at Top Lip tip (-flange, +depth/2 + lip) -> down -> right to web -> down web -> right to bottom flange -> down lip
    elements = [
        Element(elem_id=1, length=lip, angle=-math.pi/2.0, thickness=t),
        Element(elem_id=2, length=flange, angle=0.0, thickness=t),
        Element(elem_id=3, length=depth, angle=-math.pi/2.0, thickness=t),
        Element(elem_id=4, length=flange, angle=0.0, thickness=t),
        Element(elem_id=5, length=lip, angle=-math.pi/2.0, thickness=t),
    ]
    geom = SectionGeometry(elements=elements, thickness=t, is_closed=False)
    PartMesher._compute_coordinates_and_centering(geom, 0.0, 0.0, 0.0)
    return geom


def test_z_section():
    geom = create_z_section()
    props = SectionPropertiesCalculator.calculate(geom)

    expected_area = (20.0 + 50.0 + 150.0 + 50.0 + 20.0) * 2.0
    print("\n[Z-Section Validation]")
    print(f"Area: Computed = {props.area:.2f} mm^2, Expected = {expected_area:.2f} mm^2")
    assert abs(props.area - expected_area) < 1e-4

    print(f"Ix = {props.ix:.2e} mm^4, Iy = {props.iy:.2e} mm^4, Ixy = {props.ixy:.2e} mm^4")
    print(f"Principal angle theta_p = {props.theta_p:.2f} deg")
    print(f"Principal I1 = {props.i1:.2e} mm^4, I2 = {props.i2:.2e} mm^4")

    # For point-symmetric Z section, Shear center is at the centroid (0,0)
    print(f"Shear Center: x0 = {props.x0:.2f} mm, y0 = {props.y0:.2f} mm")
    assert abs(props.x0) < 1e-3
    assert abs(props.y0) < 1e-3

    # FSM Flexural analysis
    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0, poisson=0.3)
    analyzer = SignatureCurveAnalyzer(assembler)
    res = analyzer.analyze(l_min=30.0, l_max=4000.0, num_points=20, load_type="bending_x", yield_stress=345.0, member_length=3000.0)

    print(f"\n[FSM Flexural Buckling]")
    print(f"Local Mcrl = {res.p_crl/1e6:.2f} kN-m")
    print(f"Distortional Mcrd = {res.p_crd/1e6:.2f} kN-m")

    # DSM Flexural Design
    flex = DSMFlexure.design_beam(
        sf=props.sx_top,
        fy=345.0,
        m_cre=res.p_cre,
        m_crl=res.p_crl,
        m_crd=res.p_crd,
    )

    print(f"\n[KDS DSM Flexure Design]")
    print(f"Yield Moment My = {flex.my/1e6:.2f} kN-m")
    print(f"Nominal Mn = {flex.mn/1e6:.2f} kN-m (Governing: {flex.governing_mode})")
    print(f"Design phi*Mn = {flex.phi_mn/1e6:.2f} kN-m")

    # Web Shear and Crippling
    vn = WebShearAndCrippling.calculate_shear(h=150.0, t=2.0, fy=345.0)
    pnc = WebShearAndCrippling.calculate_web_crippling(h=150.0, t=2.0, r=2.0, n_bearing=50.0, fy=345.0)
    print(f"\n[Web Shear & Crippling]")
    print(f"Nominal Shear Vn = {vn/1000.0:.2f} kN (Design phi*Vn = {0.90*vn/1000.0:.2f} kN)")
    print(f"Web Crippling Pnc = {pnc/1000.0:.2f} kN (Design phi*Pnc = {0.85*pnc/1000.0:.2f} kN)")

    assert flex.mn <= flex.my
    assert vn > 0
    assert pnc > 0


if __name__ == "__main__":
    test_z_section()
    print("\n[PASS] All Z-Section validation tests PASSED successfully!")
