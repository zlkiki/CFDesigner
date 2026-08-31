"""
Unit & Integration Tests for CFDesigner Online Manual APIs (Bilingual Edition)
"""

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
    assert len(data) == 4  # 4 main categories
    cat_ids = [c["id"] for c in data]
    assert "getting_started" in cat_ids
    assert "section_properties" in cat_ids
    assert "fsm_buckling" in cat_ids
    assert "kds_design" in cat_ids
    
    # Check English titles in categories and topics
    for cat in data:
        assert "title_en" in cat
        for topic in cat["topics"]:
            assert "title_en" in topic
            assert len(topic["title_en"]) > 0


def test_manual_topic_detail_bilingual_api():
    # Test Gross Properties topic
    res = client.get("/api/manual/topic/gross_props")
    assert res.status_code == 200
    data = res.json()
    assert data["id"] == "gross_props"
    assert "총단면" in data["title"]
    assert "Gross Section Properties" in data["title_en"]
    assert "content_html" in data
    assert "content_en_html" in data
    assert len(data["content_html"]) > 100
    assert len(data["content_en_html"]) > 100
    assert "btn-toggle-en" in data["content_html"]


def test_manual_all_15_topics_bilingual_completeness():
    """Verify all 15 topics have complete Korean and English content without omissions."""
    assert len(TOPICS) == 15
    for tid, topic in TOPICS.items():
        assert topic["id"] == tid
        assert "title" in topic and len(topic["title"]) > 0
        assert "title_en" in topic and len(topic["title_en"]) > 0
        assert "summary" in topic and len(topic["summary"]) > 0
        assert "summary_en" in topic and len(topic["summary_en"]) > 0
        assert "content_html" in topic and len(topic["content_html"]) > 100
        assert "content_en_html" in topic and len(topic["content_en_html"]) > 100


def test_manual_multilingual_search_api():
    # Korean query: '좌굴'
    res_ko = client.get("/api/manual/search?q=좌굴")
    assert res_ko.status_code == 200
    results_ko = res_ko.json()
    assert len(results_ko) > 0
    assert any("fsm" in r["id"] or "buckling" in r["id"] or "comp" in r["id"] for r in results_ko)

    # Korean query: 'KDS'
    res_kds = client.get("/api/manual/search?q=KDS")
    assert res_kds.status_code == 200
    assert len(res_kds.json()) > 0

    # English query: 'warping'
    res_en_warp = client.get("/api/manual/search?q=warping")
    assert res_en_warp.status_code == 200
    results_warp = res_en_warp.json()
    assert len(results_warp) > 0
    assert any(r["id"] == "torsion_props" for r in results_warp)

    # English query: 'distortional'
    res_en_dist = client.get("/api/manual/search?q=distortional")
    assert res_en_dist.status_code == 200
    results_dist = res_en_dist.json()
    assert len(results_dist) > 0
    assert any(r["id"] == "buckling_modes" for r in results_dist)

    # English query: 'shear center'
    res_en_sc = client.get("/api/manual/search?q=shear center")
    assert res_en_sc.status_code == 200
    assert len(res_en_sc.json()) > 0
