"""
Pytest Suite for Calculation Report Generation Engine and API (Phase 7-1, 7-2, 7-3)
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app
from src.report import (
    SummaryReportGenerator,
    DetailedReportGenerator,
    HTMLReportGenerator,
    SVGDiagramGenerator,
    ProjectMetadata,
    ReportOptions,
)


@pytest.fixture
def client():
    return TestClient(app)


@pytest.fixture
def sample_report_payload():
    return {
        "section_name": "CFS-C-150x50x20x2.0",
        "project_name": "Standard Cold-Formed Steel Building Project",
        "metadata": {
            "project_name": "Sample Building Project",
            "section_name": "C-150x50x20x2.0",
            "doc_number": "CALC-2026-001",
            "company": "K-Engineering Corp.",
            "designed_by": "Structural Engineer",
            "checked_by": "Senior PE",
            "approved_by": "Lead SE",
            "remarks": "Cold-Formed Channel Design per KDS 14 31 10",
        },
        "options": {
            "report_mode": "detailed",
            "include_section_inputs": True,
            "include_gross_properties": True,
            "include_torsion_properties": True,
            "include_effective_properties": True,
            "include_fully_braced_strength": True,
            "include_fsm_buckling": True,
            "include_member_design": True,
            "include_web_crippling": True,
            "include_1d_analysis": False,
        },
        "geometry": {
            "elements": [
                {"length": 20.0, "angle": 90.0, "radius": 3.0, "thickness": 2.0, "web_type": "Stiffened", "k": 4.0, "x0": 50.0, "y0": 0.0, "x1": 50.0, "y1": 20.0},
                {"length": 50.0, "angle": 0.0, "radius": 3.0, "thickness": 2.0, "web_type": "Flat", "k": 4.0, "x0": 0.0, "y0": 0.0, "x1": 50.0, "y1": 0.0},
                {"length": 150.0, "angle": 90.0, "radius": 3.0, "thickness": 2.0, "web_type": "Flat", "k": 4.0, "x0": 0.0, "y0": 0.0, "x1": 0.0, "y1": 150.0},
                {"length": 50.0, "angle": 0.0, "radius": 3.0, "thickness": 2.0, "web_type": "Flat", "k": 4.0, "x0": 0.0, "y0": 150.0, "x1": 50.0, "y1": 150.0},
                {"length": 20.0, "angle": 90.0, "radius": 3.0, "thickness": 2.0, "web_type": "Stiffened", "k": 4.0, "x0": 50.0, "y0": 130.0, "x1": 50.0, "y1": 150.0},
            ]
        },
        "properties": {
            "area": 560.0,
            "weight": 4.40,
            "ix": 1820000.0,
            "iy": 215000.0,
            "ixy": 0.0,
            "rx": 57.0,
            "ry": 19.6,
            "sxt": 24266.0,
            "sxb": 24266.0,
            "syl": 7200.0,
            "syr": 9800.0,
            "xcg": 16.5,
            "ycg": 75.0,
            "x0": -28.4,
            "y0": 75.0,
            "j": 746.0,
            "cw": 980000000.0,
            "ro": 84.5,
            "beta_w": 0.0,
            "beta_y": 0.0,
            "theta": 0.0,
        },
        "material": {
            "name": "SS275 / S280GD",
            "fy": 275.0,
            "fu": 410.0,
            "e": 205000.0,
            "cold_work": False,
            "inelastic_reserve": False,
        },
        "fsm": {
            "l_local": 65.0,
            "p_crl": 52.4,
            "p_crl_ratio": 0.34,
            "l_distortional": 320.0,
            "p_crd": 68.2,
            "p_crd_ratio": 0.44,
            "l_global": 1800.0,
            "p_cre": 42.0,
            "p_cre_ratio": 0.27,
            "signature_curve": [
                {"length": 20, "load_factor": 1.8},
                {"length": 65, "load_factor": 0.34},
                {"length": 150, "load_factor": 0.8},
                {"length": 320, "load_factor": 0.44},
                {"length": 800, "load_factor": 0.95},
                {"length": 1800, "load_factor": 0.27},
            ],
        },
        "design": {
            "compression": {
                "p_n": 38.5,
                "phi_pn": 32.7,
                "dc_ratio": 0.765,
                "status": "OK",
                "governing_mode": "전역 휨좌굴 (Global Flexural)",
            },
            "flexure": {
                "m_n": 6.2,
                "phi_mn": 5.58,
                "dc_ratio": 0.896,
                "status": "OK",
                "governing_mode": "국부-왜곡 상호작용 (Local-Distortional)",
            },
            "shear": {
                "v_n": 32.0,
                "phi_vn": 28.8,
                "dc_ratio": 0.521,
                "status": "OK",
            },
            "interaction": {
                "ratio": 0.925,
                "status": "OK",
                "formula_type": "KDS 14 31 10 식 (4.4-1)",
            },
            "web_crippling": {
                "pn": 28.5,
                "phi_pn": 22.8,
            },
        },
        "loads": {
            "pu": 25.0,
            "mux": 5.0,
            "muy": 0.0,
            "vu": 15.0,
        },
    }


def test_summary_report_generation(sample_report_payload):
    """Verify 1-2 page summary calculation report generator."""
    html = SummaryReportGenerator.render(sample_report_payload)
    assert "<!DOCTYPE html>" in html
    assert "간략 구조요약보고서" in html
    assert "Sample Building Project" in html
    assert "C-150x50x20x2.0" in html
    assert "560.0" in html  # Ag
    assert "OK" in html
    assert "svg" in html.lower()


def test_detailed_report_generation(sample_report_payload):
    """Verify multi-page formal detailed structural calculation book generator."""
    html = DetailedReportGenerator.render(sample_report_payload)
    assert "<!DOCTYPE html>" in html
    assert "제1장. 설계 개요 및 단면 입력 제원" in html
    assert "제2장. 단면 기하학적 성질" in html
    assert "제3장. 비틀림 및 뒴(Warping) 특성" in html
    assert "제4장. 유효단면 성질 및 Winter 유효폭 해석" in html
    assert "제5장. 완전지지 단면 강도" in html
    assert "제6장. 유한대판법(FSM) 탄성 좌굴해석" in html
    assert "제7장. KDS 14 31 10 직접강도법(DSM) 부재 내력 검토" in html
    assert "제8장. 웨브 크리플링(Web Crippling)" in html
    assert "Sample Building Project" in html
    assert "CALC-2026-001" in html
    assert "SS275 / S280GD" in html
    assert "1,820,000" in html  # Ix


def test_svg_diagram_generator(sample_report_payload):
    """Verify SVG diagram generator for section and signature curve."""
    elements = sample_report_payload["geometry"]["elements"]
    props = sample_report_payload["properties"]
    fsm = sample_report_payload["fsm"]

    sec_svg = SVGDiagramGenerator.render_section_svg(elements, props)
    assert "<svg" in sec_svg
    assert "CG (" in sec_svg
    assert "SC (" in sec_svg
    assert "line" in sec_svg

    curve_svg = SVGDiagramGenerator.render_signature_curve_svg(fsm)
    assert "<svg" in curve_svg
    assert "Half-Wavelength" in curve_svg
    assert "Local (" in curve_svg


def test_html_report_dispatcher(sample_report_payload):
    """Verify HTMLReportGenerator dispatching."""
    sample_report_payload["options"]["report_mode"] = "summary"
    html_sum = HTMLReportGenerator.render_report(sample_report_payload)
    assert "간략 구조요약보고서" in html_sum

    sample_report_payload["options"]["report_mode"] = "detailed"
    html_det = HTMLReportGenerator.render_report(sample_report_payload)
    assert "제1장. 설계 개요" in html_det


def test_api_report_endpoints(client, sample_report_payload):
    """Verify /api/report/html, /api/report/summary, /api/report/detailed."""
    res_html = client.post("/api/report/html", json=sample_report_payload)
    assert res_html.status_code == 200
    assert "html" in res_html.json()
    assert len(res_html.json()["html"]) > 500

    res_sum = client.post("/api/report/summary", json=sample_report_payload)
    assert res_sum.status_code == 200
    assert "간략 구조요약보고서" in res_sum.json()["html"]

    res_det = client.post("/api/report/detailed", json=sample_report_payload)
    assert res_det.status_code == 200
    assert "제1장. 설계 개요" in res_det.json()["html"]
