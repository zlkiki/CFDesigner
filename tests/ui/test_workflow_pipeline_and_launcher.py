"""
Tests for Requirements 15: Guided Engineering Workflow Stepper, Quick Start Launcher,
Smart Contextual Assistant, and Delivery Hub Integration.
"""
import pytest
from pathlib import Path
from bs4 import BeautifulSoup
from fastapi.testclient import TestClient
from src.api.server import app

client = TestClient(app)

@pytest.fixture
def index_soup():
    """Parse src/web/index.html to inspect UI elements and attributes."""
    index_path = Path("src/web/index.html")
    assert index_path.exists(), "src/web/index.html must exist"
    content = index_path.read_text(encoding="utf-8")
    return BeautifulSoup(content, "html.parser")


def test_phase1_workflow_stepper_dom_structure(index_soup):
    """Phase 1: Verify 5-step workflow stepper bar and preset data attributes."""
    stepper_bar = index_soup.find(id="workflowStepperBar")
    assert stepper_bar is not None, "workflowStepperBar element must exist"

    stepper_track = index_soup.find(id="workflowStepper")
    assert stepper_track is not None, "workflowStepper track must exist"

    items = stepper_track.find_all("div", class_="stepper-item")
    assert len(items) == 5, "Stepper must contain exactly 5 step items"

    expected_steps = [
        (1, "단면 모델링", "Modeling"),
        (2, "단면 성질", "Properties"),
        (3, "FSM 좌굴해석", "Buckling"),
        (4, "KDS 부재설계", "Member Design"),
        (5, "구조계산서 출력", "Report & Export"),
    ]

    for item, (step_num, title, sub) in zip(items, expected_steps):
        assert item.get("data-step") == str(step_num)
        assert title in item.text
        assert sub in item.text

    # Verify Prev & Next Step buttons
    btn_prev = index_soup.find(id="btnPrevStep")
    btn_next = index_soup.find(id="btnNextStep")
    assert btn_prev is not None, "btnPrevStep must exist"
    assert btn_next is not None, "btnNextStep must exist"

    # Verify container data-step attribute
    container = index_soup.find(id="mainAppContainer")
    assert container is not None, "mainAppContainer must exist"
    assert container.get("data-step") == "1", "Default data-step should be 1"


def test_phase2_quick_start_launcher_modal_dom(index_soup):
    """Phase 2: Verify Quick Start Launcher Hub modal and 4 scenario cards."""
    qs_modal = index_soup.find(id="quickStartModal")
    assert qs_modal is not None, "quickStartModal must exist"

    # Verify 4 cards
    card_standard = index_soup.find(id="qsCardStandard")
    card_dxf = index_soup.find(id="qsCardDxf")
    card_qd = index_soup.find(id="qsCardQuickDesign")
    card_frame = index_soup.find(id="qsCardFrame")

    assert card_standard is not None, "qsCardStandard must exist"
    assert card_dxf is not None, "qsCardDxf must exist"
    assert card_qd is not None, "qsCardQuickDesign must exist"
    assert card_frame is not None, "qsCardFrame must exist"

    # Verify Action Buttons
    assert index_soup.find(id="btnQsStartStandard") is not None
    assert index_soup.find(id="btnQsStartDxf") is not None
    assert index_soup.find(id="btnQsStartQuickDesign") is not None
    assert index_soup.find(id="btnQsStartFrame") is not None
    assert index_soup.find(id="btnOpenQuickStart") is not None
    assert index_soup.find(id="chkDontShowQuickStartAgain") is not None


def test_phase3_smart_action_assistant_bar(index_soup):
    """Phase 3: Verify Contextual Smart Action Assistant Bar markup."""
    sab = index_soup.find(id="smartActionBar")
    assert sab is not None, "smartActionBar element must exist"

    assert index_soup.find(id="sabIcon") is not None
    assert index_soup.find(id="sabTag") is not None
    assert index_soup.find(id="sabText") is not None
    assert index_soup.find(id="btnSabPrimaryAction") is not None


def test_phase4_delivery_hub_report_export_buttons(index_soup):
    """Phase 4: Verify Delivery Hub actions in structural calculation report viewer modal."""
    btn_dxf = index_soup.find(id="btnExportDxfFromReport")
    btn_csv = index_soup.find(id="btnExportCsvFromReport")
    btn_copy = index_soup.find(id="btnCopySummaryTableFromReport")
    btn_print = index_soup.find(id="btnPrintReportFrame")

    assert btn_dxf is not None, "btnExportDxfFromReport must exist in report toolbar"
    assert btn_csv is not None, "btnExportCsvFromReport must exist in report toolbar"
    assert btn_copy is not None, "btnCopySummaryTableFromReport must exist in report toolbar"
    assert btn_print is not None, "btnPrintReportFrame must exist in report toolbar"


def test_e2e_scenario_1_standard_design_flow():
    """E2E Scenario 1: Standard section wizard -> FSM solve -> Design check -> Report HTML."""
    # 1. Wizard C-Section
    wiz_res = client.post("/api/section/wizard", json={
        "shape_type": "C", "h": 150.0, "b": 65.0, "c": 20.0, "t": 2.0, "r": 2.0
    })
    assert wiz_res.status_code == 200
    wiz_data = wiz_res.json()
    geom = wiz_data["geometry"]
    props = wiz_data["properties"]
    assert props["area"] > 0

    # 2. FSM Buckling Solve
    fsm_res = client.post("/api/fsm/solve", json={
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "load_type": "compression",
        "yield_stress": 345.0,
        "member_length": 3000.0,
        "num_points": 25
    })
    assert fsm_res.status_code == 200
    fsm_data = fsm_res.json()
    assert len(fsm_data["signature_curve"]) > 0

    # 3. KDS DSM Design Check
    des_res = client.post("/api/design/check", json={
        "elements": geom["elements"],
        "thickness": geom["thickness"],
        "yield_stress": 345.0,
        "length_x": 3000.0,
        "length_y": 3000.0,
        "length_t": 3000.0,
        "pu": 40.0,
        "mux": 4.0,
        "muy": 0.0,
        "vu": 10.0
    })
    assert des_res.status_code == 200
    des_data = des_res.json()
    assert des_data["compression"]["dc_ratio"] > 0

    # 4. Report Generation
    rpt_res = client.post("/api/report/html", json={
        "section_name": "C150x65x20x2.0",
        "project_name": "E2E Guided Workflow Test",
        "metadata": {"doc_number": "E2E-001"},
        "options": {"report_mode": "detailed", "include_trace_details": True},
        "geometry": geom,
        "properties": props,
        "material": {"fy": 345.0, "fu": 450.0, "e": 205000.0, "name": "SS275"},
        "fsm": fsm_data,
        "design": des_data,
        "loads": {"pu": 40.0, "mux": 4.0, "muy": 0.0, "vu": 10.0, "ru": 10.0}
    })
    assert rpt_res.status_code == 200
    assert "html" in rpt_res.json()
