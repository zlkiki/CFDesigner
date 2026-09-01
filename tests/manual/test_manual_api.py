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
    assert len(data) == 8  # 8 categories matching CFS.chm tree
    cat_ids = [c["id"] for c in data]
    assert "getting_started" in cat_ids
    assert "section_modeling" in cat_ids
    assert "section_library" in cat_ids
    assert "section_properties" in cat_ids
    assert "fsm_buckling" in cat_ids
    assert "kds_design" in cat_ids
    assert "frame_analysis" in cat_ids
    assert "appendix" in cat_ids
    
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
    assert total_topics == 27


def test_manual_all_27_topics_bilingual_completeness():
    """Verify all 27 topics have complete Korean and English content without omissions."""
    assert len(TOPICS) == 27
    for tid, topic in TOPICS.items():
        assert topic["id"] == tid
        assert "title" in topic and len(topic["title"]) > 0
        assert "title_en" in topic and len(topic["title_en"]) > 0
        assert "summary" in topic and len(topic["summary"]) > 0
        assert "summary_en" in topic and len(topic["summary_en"]) > 0
        assert "content_html" in topic and len(topic["content_html"]) > 100
        assert "content_en_html" in topic and len(topic["content_en_html"]) > 100
        if tid not in ["glossary", "symbols"]:
            assert "btn-toggle-en" in topic["content_html"]
            assert "inline-en-box" in topic["content_html"]


@pytest.mark.parametrize("topic_id", [
    "intro", "ui_layout", "wizard", "dxf_import", "element_grid", "geom_transform",
    "section_lib", "material_db", "cold_work",
    "gross_props", "torsion_props", "principal_axes", "effective_props",
    "fsm_theory", "buckling_modes", "signature_curve", "fsm_params",
    "kds_dsm_comp", "kds_dsm_flex", "kds_shear_crip", "quick_design", "kds_interaction", "report_guide",
    "analysis_wizard", "diagrams_viewer",
    "glossary", "symbols"
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


def test_manual_phase5_1_images_and_comparison_ui():
    """AC 6-1-1 ~ AC 6-1-3: Verify 16 images serve 200 OK and independent image placement (KO: Web, EN: Legacy)."""
    # 1. Check Lightbox in manual.html
    res_html = client.get("/manual")
    assert res_html.status_code == 200
    assert "imageLightboxModal" in res_html.text
    assert "lightbox-modal" in res_html.text

    # 2. Check All 16 images serve with HTTP 200
    expected_images = [
        "section.png", "analysis.png", "quick-design.png",
        "buckle-profile.png", "buckle-shape.png", "buckle-shapes.png", "buckle-renders.png",
        "torsion-section1.png", "torsion-section2.png", "torsion-direction.png", "torsion-diagrams.png",
        "folder-open.jpg", "folder-closed.jpg",
        "web-section-ui.png", "web-analysis-ui.png", "web-quick-design.png"
    ]
    for img_name in expected_images:
        res_img = client.get(f"/static/images/manual/{img_name}")
        assert res_img.status_code == 200, f"Failed to serve image: {img_name}"
        assert len(res_img.content) > 100

    # 3. Check ui_layout topic has independent image placement (KO: Web, EN: Legacy)
    topic_ui = TOPICS["ui_layout"]
    assert "web-section-ui.png" in topic_ui["content_html"]
    assert "web-analysis-ui.png" in topic_ui["content_html"]
    assert "section.png" in topic_ui["content_en_html"]
    assert "analysis.png" in topic_ui["content_en_html"]
    assert "manual-img-card" in topic_ui["content_html"]
    assert "manual-img-card" in topic_ui["content_en_html"]

    # 4. Check quick_design topic has independent image placement
    topic_qd = TOPICS["quick_design"]
    assert "web-quick-design.png" in topic_qd["content_html"]
    assert "quick-design.png" in topic_qd["content_en_html"]



def test_manual_phase6_2_modeling_and_properties_tables_and_math():
    """AC 6-2-1 ~ AC 6-2-3: Verify categories 2-4 English content contains tables and math equations."""
    # 1. Wizard English tables
    w = TOPICS["wizard"]
    assert "<table" in w["content_en_html"]
    assert "Flange Width" in w["content_en_html"]
    assert "Bend Radius" in w["content_en_html"]

    # 2. DXF Import English table
    dxf = TOPICS["dxf_import"]
    assert "<table" in dxf["content_en_html"]
    assert "Centerline" in dxf["content_en_html"]
    assert "Polyline Width" in dxf["content_en_html"]

    # 3. Cold Work English formulas
    cw = TOPICS["cold_work"]
    assert "$$" in cw["content_en_html"]
    assert "F_{ya}" in cw["content_en_html"]
    assert "F_{yc}" in cw["content_en_html"]
    assert "<table" in cw["content_en_html"]

    # 4. Gross properties & Torsion properties English formulas & tables
    gp = TOPICS["gross_props"]
    assert "<table" in gp["content_en_html"]
    assert "$$" in gp["content_en_html"]

    tp = TOPICS["torsion_props"]
    assert "<table" in tp["content_en_html"]
    assert "Saint-Venant Torsion" in tp["content_en_html"]
    assert "Warping Constant" in tp["content_en_html"]
    assert "torsion-section1.png" in tp["content_en_html"]

    # 5. Effective properties Winter equation
    ep = TOPICS["effective_props"]
    assert "$$" in ep["content_en_html"]
    assert "\\rho" in ep["content_en_html"]
    assert "b_{eff}" in ep["content_en_html"]



def test_manual_phase5_3_buckling_torsion_glossary_symbols():
    """AC 5-3-1 ~ AC 5-3-4: Verify buckling/torsion diagrams and glossary/symbols topics."""
    # 1. Torsion properties topic diagrams
    tp = TOPICS["torsion_props"]
    assert "torsion-section1.png" in tp["content_html"]
    assert "torsion-section2.png" in tp["content_html"]
    assert "torsion-direction.png" in tp["content_html"]
    assert "torsion-diagrams.png" in tp["content_html"]
    assert "생브낭" in tp["content_html"]
    assert "뒴상수" in tp["content_html"]

    # 2. Buckling modes topic diagrams
    bm = TOPICS["buckling_modes"]
    assert "buckle-profile.png" in bm["content_html"]
    assert "buckle-shape.png" in bm["content_html"]
    assert "buckle-shapes.png" in bm["content_html"]
    assert "buckle-renders.png" in bm["content_html"]
    assert "국부 좌굴" in bm["content_html"]
    assert "왜곡 좌굴" in bm["content_html"]
    assert "전체 좌굴" in bm["content_html"]

    # 3. Glossary topic & search API
    assert "glossary" in TOPICS
    g = TOPICS["glossary"]
    assert "Applicable Building Code" in g["content_html"]
    assert "Direct Strength Method" in g["content_html"]
    assert "Distortional Buckling" in g["content_html"]
    assert "Warping Constant" in g["content_html"]
    
    res_g_search = client.get("/api/manual/search?q=Vlasov")
    assert res_g_search.status_code == 200
    assert any(r["id"] == "glossary" for r in res_g_search.json())

    # 4. Symbols topic & search API
    assert "symbols" in TOPICS
    sym = TOPICS["symbols"]
    assert "Gross Cross-Sectional Area" in sym["content_html"]
    assert "Moment of Inertia" in sym["content_html"]
    assert "Resistance Factor" in sym["content_html"]
    
    res_s_search = client.get("/api/manual/search?q=전단 탄성계수")
    assert res_s_search.status_code == 200
    assert len(res_s_search.json()) > 0
    assert any(r["id"] == "symbols" for r in res_s_search.json())


def test_manual_phase6_3_fsm_design_and_frame_english_symmetry():
    """AC 6-3-1 ~ AC 6-3-3: Verify FSM, KDS/AISI design, and Frame analysis English formulas & tables."""
    # 1. FSM Theory English equations & table
    ft = TOPICS["fsm_theory"]
    assert "$$" in ft["content_en_html"]
    assert "[K_e]" in ft["content_en_html"]
    assert "[K_g]" in ft["content_en_html"]
    assert "<table" in ft["content_en_html"]

    # 2. Buckling modes English table and diagrams
    bm = TOPICS["buckling_modes"]
    assert "<table" in bm["content_en_html"]
    assert "buckle-profile.png" in bm["content_en_html"]
    assert "Local Buckling" in bm["content_en_html"]

    # 3. Compression DSM English AISI S100 formulas
    comp = TOPICS["kds_dsm_comp"]
    assert "$$" in comp["content_en_html"]
    assert "P_{ne}" in comp["content_en_html"]
    assert "P_{nl}" in comp["content_en_html"]
    assert "P_{nd}" in comp["content_en_html"]
    assert "\\phi_c" in comp["content_en_html"]
    assert "\\Omega_c" in comp["content_en_html"]

    # 4. Flexure DSM English AISI S100 formulas
    flex = TOPICS["kds_dsm_flex"]
    assert "$$" in flex["content_en_html"]
    assert "M_{ne}" in flex["content_en_html"]
    assert "M_{nl}" in flex["content_en_html"]
    assert "M_{nd}" in flex["content_en_html"]

    # 5. Shear & Web Crippling English table & formulas
    crip = TOPICS["kds_shear_crip"]
    assert "$$" in crip["content_en_html"]
    assert "<table" in crip["content_en_html"]
    assert "EOF" in crip["content_en_html"]
    assert "ITF" in crip["content_en_html"]

    # 6. 1D Frame Analysis Wizard English 4-stage workflow
    aw = TOPICS["analysis_wizard"]
    assert "Page 1" in aw["content_en_html"]
    assert "Page 2" in aw["content_en_html"]
    assert "Page 3" in aw["content_en_html"]
    assert "Page 4" in aw["content_en_html"]


def test_manual_phase8_6_ui_layout_and_11_topics_bilingual_sync():
    """Phase 8-6 AC 6-1 ~ AC 6-3: Verify 4-quadrant layout guide, real-time pipeline, and 11 topics 1:1 symmetry."""
    # 1. UI Layout 4-quadrant guide
    ui = TOPICS["ui_layout"]
    assert "좌측 제어 패널" in ui["content_html"]
    assert "2D/3D 단면 뷰어" in ui["content_html"]
    assert "FSM 시그니처 커브" in ui["content_html"]
    assert "Section Properties & Design D/C Gauges" in ui["content_html"] or "D/C 게이지" in ui["content_html"]
    assert "무중단 연산 아키텍처" in ui["content_html"] or "데이터 연동 파이프라인" in ui["content_html"]
    
    # 2. Check 11 target topics have robust Korean and English content
    target_11 = [
        "intro", "dxf_import", "geom_transform", "material_db",
        "principal_axes", "fsm_theory", "kds_dsm_comp", "kds_dsm_flex",
        "kds_shear_crip", "kds_interaction", "analysis_wizard"
    ]
    for tid in target_11:
        t = TOPICS[tid]
        assert len(t["content_html"]) > 200, f"Topic {tid} KO content too short"
        assert len(t["content_en_html"]) > 200, f"Topic {tid} EN content too short"
        assert "manual-article" in t["content_html"]
        assert "manual-article" in t["content_en_html"]


def test_manual_phase8_7_diagrams_tables_and_kds_aisi_symmetry():
    """Phase 8-7 AC 7-1 ~ AC 7-6: Verify diagrams, table/math symmetry, walkthrough subsections, and KDS/AISI."""
    # 1. SFD/BMD/Deflection caption in 1-2
    ui = TOPICS["ui_layout"]
    assert "SFD / BMD / 처짐 다이어그램" in ui["content_html"]
    assert "web-analysis-ui.png" in ui["content_html"]

    # 2. Table & KaTeX math symmetry in 3-3, 5-4, 2-3
    cw = TOPICS["cold_work"]
    assert "<table" in cw["content_html"] and "<table" in cw["content_en_html"]
    assert "B_c" in cw["content_html"] and "B_c" in cw["content_en_html"]

    fp = TOPICS["fsm_params"]
    assert "<table" in fp["content_html"] and "<table" in fp["content_en_html"]
    assert "L_{min}" in fp["content_html"] and "L_{min}" in fp["content_en_html"]

    eg = TOPICS["element_grid"]
    assert "$$" in eg["content_html"] and "$$" in eg["content_en_html"]
    assert "\\int" in eg["content_html"] and "\\int" in eg["content_en_html"]

    # 3. Walkthrough subsections in 2-1, 2-2, 7-1
    for tid in ["wizard", "dxf_import", "analysis_wizard"]:
        t = TOPICS[tid]
        assert "Step-by-Step Walkthrough" in t["content_html"] or "실무 적용 튜토리얼 예제" in t["content_html"]
        assert "Step-by-Step Walkthrough" in t["content_en_html"]

    # 4. KDS vs AISI factors in compression & flexure
    comp = TOPICS["kds_dsm_comp"]
    assert "\\phi_c" in comp["content_html"]
    assert "\\Omega_c" in comp["content_html"]
    assert "\\phi_c" in comp["content_en_html"]
    assert "\\Omega_c" in comp["content_en_html"]

    flex = TOPICS["kds_dsm_flex"]
    assert "\\phi_b" in flex["content_html"]
    assert "\\Omega_b" in flex["content_html"]
    assert "\\phi_b" in flex["content_en_html"]
    assert "\\Omega_b" in flex["content_en_html"]






