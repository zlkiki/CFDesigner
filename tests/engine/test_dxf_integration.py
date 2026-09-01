"""
End-to-End Integration Test for CAD (DXF) -> FSM Analysis -> KDS DSM Design -> Report Generation.
"""

import sys
import os
import math
import ezdxf

sys.path.insert(0, os.path.abspath(os.path.join(os.path.dirname(__file__), "..")))

from src.cad.dxf_reader import DXFReader
from src.cad.part_mesher import PartMesher
from src.geometry.gross_properties import SectionPropertiesCalculator
from src.solver.strip_assembler import StripAssembler
from src.solver.signature_curve import SignatureCurveAnalyzer
from src.design.dsm_compression import DSMCompression
from src.design.dsm_flexure import DSMFlexure
from src.report.plotter import SectionPlotter
from src.report.summary_table import CalculationReportGenerator


def create_sample_dxf(file_path: str):
    """
    Generates a sample DXF file with a lipped C-channel polyline.
    """
    doc = ezdxf.new("R2010")
    doc.header["$INSUNITS"] = 4  # Millimeters
    msp = doc.modelspace()

    # C 120x60x20x2.0 (t = 2.0 mm)
    # Points with Fillet Arc (Bulge = tan(theta/4) = tan(90/4) = 0.41421356)
    # Start: Top Lip tip -> Flange -> Web -> Bottom Flange -> Bottom Lip tip
    points = [
        (0.0, -20.0, 2.0, 2.0, 0.0),       # Top Lip
        (0.0, 0.0, 2.0, 2.0, 0.0),         # Corner 1
        (60.0, 0.0, 2.0, 2.0, 0.0),        # Top Flange to Web corner
        (60.0, -120.0, 2.0, 2.0, 0.0),     # Web to Bottom Flange corner
        (0.0, -120.0, 2.0, 2.0, 0.0),      # Bottom Flange to Lip corner
        (0.0, -100.0, 2.0, 2.0, 0.0),      # Bottom Lip tip
    ]
    msp.add_lwpolyline(points, dxfattribs={"const_width": 2.0, "layer": "CFT_SECTION"})
    doc.saveas(file_path)


def test_dxf_end_to_end():
    test_dxf_path = os.path.join(os.path.dirname(__file__), "sample_c_section.dxf")
    create_sample_dxf(test_dxf_path)

    print("\n[End-to-End DXF Pipeline Test]")
    print(f"1. Reading DXF file: {test_dxf_path}")
    reader = DXFReader(target_unit="mm")
    polylines = reader.read_file(test_dxf_path)
    assert len(polylines) > 0
    print(f"   -> Successfully parsed {len(polylines)} polyline(s).")

    print("2. Meshing Polyline to Structural Elements...")
    geom = PartMesher.mesh_polyline(polylines[0], default_thickness=2.0)
    assert len(geom.elements) == 5
    print(f"   -> Total Elements = {len(geom.elements)}, Total Length = {geom.total_length:.2f} mm")

    print("3. Calculating Gross Cross-Section Properties...")
    props = SectionPropertiesCalculator.calculate(geom)
    print(f"   -> Ag = {props.area:.2f} mm^2, Ix = {props.ix:.2e} mm^4, Iy = {props.iy:.2e} mm^4")
    print(f"   -> rx = {props.rx:.2f} mm, ry = {props.ry:.2f} mm, J = {props.j:.2f} mm^4")
    assert props.area > 0

    print("4. Executing FSM Elastic Buckling Analysis...")
    assembler = StripAssembler(geom=geom, props=props, e_modulus=205000.0, poisson=0.3)
    analyzer = SignatureCurveAnalyzer(assembler)
    buckle_res = analyzer.analyze(l_min=20.0, l_max=4000.0, num_points=25, yield_stress=345.0, member_length=2500.0)
    print(f"   -> Local Pcrl = {buckle_res.p_crl/1000.0:.2f} kN, Distortional Pcrd = {buckle_res.p_crd/1000.0:.2f} kN")

    print("5. Performing KDS 14 31 10 / AISI S100 DSM Member Design...")
    comp_res = DSMCompression.design_column(ag=props.area, fy=345.0, p_cre=buckle_res.p_cre, p_crl=buckle_res.p_crl, p_crd=buckle_res.p_crd)
    flex_res = DSMFlexure.design_beam(sf=props.sx_top, fy=345.0, m_cre=buckle_res.p_cre, m_crl=buckle_res.p_crl, m_crd=buckle_res.p_crd)
    print(f"   -> Design Compressive Strength phi*Pn = {comp_res.phi_pn/1000.0:.2f} kN (Governing: {comp_res.governing_mode})")
    print(f"   -> Design Flexural Strength phi*Mn = {flex_res.phi_mn/1e6:.2f} kN-m (Governing: {flex_res.governing_mode})")

    print("6. Generating Markdown Report & Plots...")
    report_md = CalculationReportGenerator.generate_markdown_report(
        section_name="C 120x60x20x2.0 (DXF Imported)",
        props=props,
        buckle_res=buckle_res,
        comp_res=comp_res,
        flex_res=flex_res,
        fy=345.0,
    )
    report_path = os.path.join(os.path.dirname(__file__), "calculation_report_sample.md")
    with open(report_path, "w", encoding="utf-8") as f:
        f.write(report_md)
    print(f"   -> Calculation Report saved to: {report_path}")

    # Clean up test dxf
    if os.path.exists(test_dxf_path):
        os.remove(test_dxf_path)


if __name__ == "__main__":
    test_dxf_end_to_end()
    print("\n[PASS] End-to-End DXF -> FSM -> KDS DSM pipeline test PASSED successfully!")
