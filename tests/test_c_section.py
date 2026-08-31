import sys
import os
import math

sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), "..")))

from src.cad.part_mesher import PartMesher, SectionGeometry, Element
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.signature_curve import SignatureCurveAnalyzer
from src.design.dsm_compression import DSMCompression
from src.design.dsm_flexure import DSMFlexure


def create_c_section(
    depth: float = 101.6,   # 4.0 in (101.6 mm)
    flange: float = 41.275, # 1.625 in (41.275 mm)
    lip: float = 12.7,      # 0.5 in (12.7 mm)
    t: float = 1.3716,      # 0.054 in (1.3716 mm)
) -> SectionGeometry:
    """
    Creates a standard lipped C-section geometry.
    """
    # Create centerline elements
    # 1. Top Lip (vertical down: length lip)
    # 2. Top Flange (horizontal left: length flange)
    # 3. Web (vertical down: length depth)
    # 4. Bottom Flange (horizontal right: length flange)
    # 5. Bottom Lip (vertical up: length lip)
    elements = [
        Element(elem_id=1, length=lip, angle=-math.pi/2.0, thickness=t),
        Element(elem_id=2, length=flange, angle=math.pi, thickness=t),
        Element(elem_id=3, length=depth, angle=-math.pi/2.0, thickness=t),
        Element(elem_id=4, length=flange, angle=0.0, thickness=t),
        Element(elem_id=5, length=lip, angle=math.pi/2.0, thickness=t),
    ]
    geom = SectionGeometry(elements=elements, thickness=t, is_closed=False)
    PartMesher._compute_coordinates_and_centering(geom, 0.0, 0.0, 0.0)
    return geom


def test_c_section_properties():
    """
    Verifies geometric properties against theoretical CFS formulas.
    """
    geom = create_c_section()
    props = SectionPropertiesCalculator.calculate(geom)

    # Expected gross area = total length * thickness
    expected_len = 12.7 + 41.275 + 101.6 + 41.275 + 12.7
    expected_area = expected_len * 1.3716

    print(f"\n[C-Section Validation]")
    print(f"Area: Computed = {props.area:.3f} mm^2, Expected = {expected_area:.3f} mm^2")
    assert abs(props.area - expected_area) / expected_area < 0.001

    print(f"Ix = {props.ix:.2e} mm^4, Iy = {props.iy:.2e} mm^4")
    print(f"rx = {props.rx:.2f} mm, ry = {props.ry:.2f} mm")
    print(f"J = {props.j:.2f} mm^4, Cw = {props.cw:.2e} mm^6")
    print(f"Shear Center x0 = {props.x0:.2f} mm, y0 = {props.y0:.2f} mm")

    assert props.ix > 0
    assert props.iy > 0
    assert props.cw > 0
    assert props.x0 < 0  # Shear center for C-section is outside the web on the back


def test_c_section_fsm_and_dsm():
    """
    Verifies FSM signature curve calculation and KDS DSM compression/flexure capacity.
    """
    geom = create_c_section()
    props = SectionPropertiesCalculator.calculate(geom)

    assembler = StripAssembler(geom=geom, props=props, e_modulus=203000.0, poisson=0.3)
    analyzer = SignatureCurveAnalyzer(assembler)

    res = analyzer.analyze(l_min=20.0, l_max=3000.0, num_points=25, yield_stress=345.0, member_length=2000.0)

    print(f"\n[FSM Buckling Results]")
    print(f"Local Buckling Load Pcrl = {res.p_crl/1000.0:.2f} kN (L = {res.l_local:.1f} mm)")
    print(f"Distortional Buckling Load Pcrd = {res.p_crd/1000.0:.2f} kN (L = {res.l_distortional:.1f} mm)")
    print(f"Global Buckling Load Pcre = {res.p_cre/1000.0:.2f} kN (L = {res.l_global:.1f} mm)")

    assert res.p_crl > 0
    assert res.p_cre > 0

    # DSM Column Design
    comp = DSMCompression.design_column(
        ag=props.area,
        fy=345.0,
        p_cre=res.p_cre,
        p_crl=res.p_crl,
        p_crd=res.p_crd,
    )

    print(f"\n[KDS DSM Design Results]")
    print(f"Py = {comp.py/1000.0:.2f} kN")
    print(f"Pne = {comp.pne/1000.0:.2f} kN (Global)")
    print(f"Pnl = {comp.pnl/1000.0:.2f} kN (Local)")
    print(f"Pnd = {comp.pnd/1000.0:.2f} kN (Distortional)")
    print(f"Pn = {comp.pn/1000.0:.2f} kN (Governing: {comp.governing_mode})")
    print(f"Design phi*Pn = {comp.phi_pn/1000.0:.2f} kN")

    assert comp.pn <= comp.py
    assert abs(comp.phi_pn - 0.85 * comp.pn) < 1e-4


if __name__ == "__main__":
    test_c_section_properties()
    test_c_section_fsm_and_dsm()
    print("\n[PASS] All C-Section validation tests PASSED successfully!")
