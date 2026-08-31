"""
Unit & Integration Tests for CFDesigner Online Manual APIs
"""

from fastapi.testclient import TestClient
from src.api.server import app

client = TestClient(app)


def test_manual_html_page():
    res = client.get("/manual")
    assert res.status_code == 200
    assert "CFDesigner" in res.text
    assert "온라인 공학 매뉴얼" in res.text


def test_manual_categories_api():
    res = client.get("/api/manual/categories")
    assert res.status_code == 200
    data = res.json()
    assert len(data) == 4 # 4 main categories
    cat_ids = [c["id"] for c in data]
    assert "getting_started" in cat_ids
    assert "section_properties" in cat_ids
    assert "fsm_buckling" in cat_ids
    assert "kds_design" in cat_ids


def test_manual_topic_detail_api():
    # Test Gross Properties topic
    res = client.get("/api/manual/topic/gross_props")
    assert res.status_code == 200
    data = res.json()
    assert data["id"] == "gross_props"
    assert "총단면 성질" in data["title"]
    assert "content_html" in data
    assert len(data["content_html"]) > 100


def test_manual_search_api():
    # Search for '좌굴'
    res = client.get("/api/manual/search?q=좌굴")
    assert res.status_code == 200
    results = res.json()
    assert len(results) > 0
    assert any("fsm" in r["id"] or "buckling" in r["id"] or "comp" in r["id"] for r in results)

    # Search for 'KDS'
    res_kds = client.get("/api/manual/search?q=KDS")
    assert res_kds.status_code == 200
    assert len(res_kds.json()) > 0
