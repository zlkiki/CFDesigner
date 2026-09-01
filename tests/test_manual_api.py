"""
Unit & Integration Tests for CFDesigner Online Manual APIs (Bilingual Edition - 25 Topics / 6 Categories)
"""

import pytest
from fastapi.testclient import TestClient
from src.api.server import app
from src.web.manual.topics import TOPICS, CATEGORIES

client = TestClient(app)


def test_manual_html_page():
    res = client.get("/manual")
    assert res.status_code == 200
    assert "CFDesigner" in res.text
    assert "온라인 공학 매뉴얼" in res.text
    assert "viewModeGroup" in res.text


def test_manual_categories_api():
    res = client.get("/api/manual/categories")
    assert res.status_code == 200
    data = res.json()
    assert len(data) == 6  # 6 main categories in Phase 5
    cat_ids = [c["id"] for c in data]
    assert "getting_started" in cat_ids
    assert "section_library" in cat_ids
    assert "section_properties" in cat_ids
    assert "fsm_buckling" in cat_ids
    assert "kds_design" in cat_ids
    assert "frame_analysis" in cat_ids
    
    # Check English titles in categories and topics
    total_topics = 0
    for cat in data:
        assert "title_en" in cat and len(cat["title_en"]) > 0
        assert "icon" in cat and len(cat["icon"]) > 0
        for topic in cat["topics"]:
            total_topics += 1
            assert "title_en" in topic
            assert len(topic["title_en"]) > 0
            assert "summary_en" in topic
    assert total_topics == 25


def test_manual_all_25_topics_bilingual_completeness():
    """Verify all 25 topics have complete Korean and English content without omissions."""
    assert len(TOPICS) == 25
    for tid, topic in TOPICS.items():
        assert topic["id"] == tid
        assert "title" in topic and len(topic["title"]) > 0
        assert "title_en" in topic and len(topic["title_en"]) > 0
        assert "summary" in topic and len(topic["summary"]) > 0
        assert "summary_en" in topic and len(topic["summary_en"]) > 0
        assert "content_html" in topic and len(topic["content_html"]) > 100
        assert "content_en_html" in topic and len(topic["content_en_html"]) > 100
        assert "btn-toggle-en" in topic["content_html"]
        assert "inline-en-box" in topic["content_html"]


@pytest.mark.parametrize("topic_id", [
    "intro", "ui_layout", "wizard", "dxf_import", "element_grid", "geom_transform",
    "section_lib", "material_db", "cold_work",
    "gross_props", "torsion_props", "principal_axes", "effective_props",
    "fsm_theory", "buckling_modes", "signature_curve", "fsm_params",
    "kds_dsm_comp", "kds_dsm_flex", "kds_shear_crip", "quick_design", "kds_interaction", "report_guide",
    "analysis_wizard", "diagrams_viewer"
])
def test_manual_each_topic_detail_api(topic_id):
    res = client.get(f"/api/manual/topic/{topic_id}")
    assert res.status_code == 200
    data = res.json()
    assert data["id"] == topic_id
    assert "content_html" in data
    assert "content_en_html" in data


def test_manual_multilingual_search_api():
    # Korean query: '보강 리브' (Phase 1 신규)
    res_rib = client.get("/api/manual/search?q=보강 리브")
    assert res_rib.status_code == 200
    results_rib = res_rib.json()
    assert len(results_rib) > 0
    assert any(r["id"] == "geom_transform" for r in results_rib)

    # Korean query: '연속보' (Phase 4 신규)
    res_beam = client.get("/api/manual/search?q=연속보")
    assert res_beam.status_code == 200
    results_beam = res_beam.json()
    assert len(results_beam) > 0
    assert any(r["id"] in ["analysis_wizard", "diagrams_viewer"] for r in results_beam)

    # English query: 'SFD' (Phase 4 신규)
    res_sfd = client.get("/api/manual/search?q=SFD")
    assert res_sfd.status_code == 200
    results_sfd = res_sfd.json()
    assert len(results_sfd) > 0
    assert any(r["id"] == "diagrams_viewer" for r in results_sfd)

    # English query: 'Quick Design' (Phase 3 신규)
    res_qd = client.get("/api/manual/search?q=Quick Design")
    assert res_qd.status_code == 200
    results_qd = res_qd.json()
    assert len(results_qd) > 0
    assert any(r["id"] == "quick_design" for r in results_qd)

    # Korean query: '웨브 크리플링' (Phase 3 개편)
    res_crip = client.get("/api/manual/search?q=웨브 크리플링")
    assert res_crip.status_code == 200
    results_crip = res_crip.json()
    assert len(results_crip) > 0
    assert any(r["id"] == "kds_shear_crip" for r in results_crip)

    # English query: 'Cold Work' (Phase 2 신규)
    res_cw = client.get("/api/manual/search?q=Cold Work")
    assert res_cw.status_code == 200
    results_cw = res_cw.json()
    assert len(results_cw) > 0
    assert any(r["id"] == "cold_work" for r in results_cw)

    # English query: 'Winter' (Phase 3 신규)
    res_winter = client.get("/api/manual/search?q=Winter")
    assert res_winter.status_code == 200
    results_winter = res_winter.json()
    assert len(results_winter) > 0
    assert any(r["id"] == "effective_props" for r in results_winter)
