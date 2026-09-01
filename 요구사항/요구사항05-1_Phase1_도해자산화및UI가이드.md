# [요구사항 05-1] Phase 5-1: 원본 도해 이미지 자산화 & [레거시 vs 모던 웹] UI 창 조작 가이드 이식

> **문서 상태**: 🚀 **활성 진행 과제 (Phase 5-1)**  
> **상위 마스터 문서**: [`요구사항05_레거시_UI도해_및_실무예제_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항05_레거시_UI도해_및_실무예제_전수이식.md)  
> **관련 기술 문서 (SSOT)**:
> - [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)
> - [`docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md)
> - [`docs/10_cfs_legacy_ui_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/10_cfs_legacy_ui_vs_web_gap_analysis.md)

---

## 1. 개요 및 구현 목표
1. 원본 CFS 14.0 도움말(`decompiled_src/cfs_help_manual/`)의 **13종 고화질 도해 이미지**를 웹 정적 자산으로 배포합니다.
2. UI/UX가 모던 AltDP 웹 환경으로 전면 현대화됨에 따라, **[레거시 CFS 14.0 원본 UI 샷 vs CFDesigner 모던 웹 UI 캡처] 2열 대조 체계**를 구축합니다.
   - 단면 메인창 (`section.png` $\leftrightarrow$ `web-section-ui.png`)
   - 1D 구조해석창 (`analysis.png` $\leftrightarrow$ `web-analysis-ui.png`)
   - 퀵 디자인 최적화창 (`quick-design.png` $\leftrightarrow$ `web-quick-design.png`)
3. 도해 이미지를 선명하게 확대 열람할 수 있는 **라이트박스(Lightbox) 줌 뷰어**를 구축합니다.

---

## 2. 작업 상세 내용

### 2.1 정적 이미지 자산 배포 및 신규 모던 웹 UI 캡처 자산화 (`src/web/static/images/manual/`)
* **원본 이미지 13종 전수 배포**:
  - `section.png`, `analysis.png`, `quick-design.png` (레거시 UI 3종)
  - `buckle-profile.png`, `buckle-shape.png`, `buckle-shapes.png`, `buckle-renders.png` (좌굴 이론 4종)
  - `torsion-section1.png`, `torsion-section2.png`, `torsion-direction.png`, `torsion-diagrams.png` (비틀림 이론 4종)
  - `folder-open.jpg`, `folder-closed.jpg` (트리 아이콘 2종)
* **신규 모던 웹 UI 캡처 3종 자산화**:
  - `web-section-ui.png`: AltDP 4분할 레이아웃 (제어판, 2D/3D 캔버스, FSM 차트, D/C 검토)
  - `web-analysis-ui.png`: 1D 해석 마법사 및 인터랙티브 SFD/BMD/처짐 다이어그램 차트
  - `web-quick-design.png`: 소요하중 입력 $\rightarrow$ 표준 단면 실시간 필터/소팅 모달

### 2.2 반응형 도해 카드 & 라이트박스 줌 UI (`manual.css`, `manual.js`, `manual.html`)
* 다크/라이트 테마에 최적화된 `.manual-img-card`, `.img-comparison-grid`(2열 대조 그리드) 및 캡션 스타일.
* 도해 클릭 시 화면 전체에 선명하게 확대되는 라이트박스(Lightbox Modal) 팝업 및 ESC/배경 클릭 닫기 인터랙션 구현.

### 2.3 [레거시 vs 모던 웹] 1:1 대조 UI 가이드 토픽 보강 (`topics.py`)
* `ui_layout` 토픽: 레거시 `section.png` / `analysis.png` vs 모던 `web-section-ui.png` / `web-analysis-ui.png` 2열 대조 도해 및 영역별 조작 가이드 수록.
* `element_grid`, `geom_transform` 토픽: 원본 단면 요소 테이블 및 변환 조작법 상세 도해 설명 추가.
* `quick_design` 토픽: 레거시 `quick-design.png` vs 모던 `web-quick-design.png` 대화상자 대조 도해 및 최적화 탐색 워크플로우 이식.

---

## 3. 세부 파일별 변경 계획

| 파일 경로 | 변경 내용 |
|---|---|
| [`src/web/static/images/manual/*`](file:///f:/PyProject/CFDesigner/src/web/static/images/manual/) | 원본 13종 + 모던 웹 UI 캡처 3종 (`web-*.png`) 총 16개 정적 이미지 자산 배포 |
| [`src/web/manual.html`](file:///f:/PyProject/CFDesigner/src/web/manual.html) | 라이트박스 모달 팝업 마크업 추가 |
| [`src/web/static/css/manual.css`](file:///f:/PyProject/CFDesigner/src/web/static/css/manual.css) | `.manual-img-card`, `.img-comparison-grid`, `.lightbox-modal` 스타일링 |
| [`src/web/static/js/manual.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/manual.js) | 이미지 클릭 시 라이트박스 오픈/클로즈 이벤트 바인딩 |
| [`src/web/manual/topics.py`](file:///f:/PyProject/CFDesigner/src/web/manual/topics.py) | `ui_layout`, `element_grid`, `geom_transform`, `quick_design` 토픽에 2열 대조 도해 카드 태그 및 조작 가이드 추가 |
| [`tests/test_manual_api.py`](file:///f:/PyProject/CFDesigner/tests/test_manual_api.py) | 원본 13종 + 웹 UI 3종 이미지 200 OK 서빙 및 도해 태그 검증 단위 테스트 추가 |

---

## 4. Acceptance Criteria (수용 기준)

- [ ] **AC 5-1-1**: `src/web/static/images/manual/`에 원본 13종 및 모던 웹 UI 3종(`web-section-ui.png`, `web-analysis-ui.png`, `web-quick-design.png`)이 존재하고 200 OK로 정상 서빙될 것.
- [ ] **AC 5-1-2**: 도움말 본문 내 도해 이미지 클릭 시 라이트박스 팝업으로 선명하게 확대되고 닫힐 것.
- [ ] **AC 5-1-3**: `ui_layout`, `quick_design` 토픽에 [레거시 vs 모던 웹] 2열 대조 카드 및 영역별 조작 가이드가 한·영 병기로 수록될 것.
- [ ] **AC 5-1-4**: `pytest tests/test_manual_api.py` 및 전체 테스트 suite가 100% 통과할 것.
