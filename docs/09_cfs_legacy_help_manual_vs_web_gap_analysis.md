# [CFS 레거시 도움말 vs 웹 도움말 전수 Gap 분석서] Legacy Help Manual vs Modern Web Help Matrix

> **문서 상태**: 🌟 Single Source of Truth (SSOT)  
> **문서 버전**: v1.0 (CFS 14.0 원본 도움말 79개 문서 + 13종 이미지 vs CFDesigner 웹 25개 토픽 전수 대조)  
> **원본 레퍼런스**: [`decompiled_src/cfs_help_manual/`](file:///f:/PyProject/CFDesigner/decompiled_src/cfs_help_manual/overview.htm) (79개 HTML, 13개 이미지, 95개 전체 자산)  
> **대응 엔드포인트**: `/manual` (SPA 웹 뷰어) & `src/web/manual/topics.py`

---

## 1. 개요 및 분석 목적

본 문서는 상용 프로그램 **CFS 14.0 오리지널 도움말 자산(`decompiled_src/cfs_help_manual/`)**의 모든 토픽(79개)과 시각 도해(13종), 튜토리얼 예제 및 전문 용어사전을 **CFDesigner 모던 웹 도움말 시스템(`src/web/manual/topics.py`)**과 1:1로 전수 대조하여, **누락 항목(Gap)을 체계적으로 식별하고 완전 이식(100% Coverage)하기 위한 기술 기준서**입니다.

```mermaid
graph LR
    Legacy["🏛️ CFS 14.0 원본 도움말<br>79개 HTML + 13종 이미지<br>(decompiled_src/cfs_help_manual/)"]
    Gap["🔍 1:1 전수 Gap 분석<br>(09_cfs_legacy_help_manual_vs_web_gap_analysis.md)"]
    Web["🌐 CFDesigner 웹 도움말<br>6대 카테고리 25개 토픽 완비<br>(src/web/manual/topics.py)"]
    Legacy --> Gap --> Web
```

---

## 2. 8대 도메인별 79개 토픽 전수 비교 매트릭스

### 2.1 시작하기 & 일반 UI/UX (General Interface & Window Layout) - 16개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `introduction.htm` | CFS 시스템 소개 및 연혁 | - | `intro` | 🟢 **반영 완료** (모던 SaaS 웹 구조로 현대화) |
| `overview.htm` | 단면/해석/설계 3단계 개요 | - | `intro` | 🟢 **반영 완료** (파이프라인 흐름도 수록) |
| `interface.htm` | 윈도우 인터페이스 조작법 | - | `ui_layout` | 🟡 **부분 반영**: 텍스트 설명만 존재, 창 도해 누락 |
| `section-window.htm` | 단면 메인 윈도우 구성 | `section.png` | `ui_layout` | 🔴 **도해 누락**: 원본 `section.png` 및 영역별 조작 가이드 누락 |
| `analysis-window.htm` | 1D 해석 메인 윈도우 구성 | `analysis.png` | `ui_layout`, `diagrams_viewer` | 🔴 **도해 누락**: 원본 `analysis.png` 및 다이어그램 제어 가이드 누락 |
| `file-menu.htm` | 파일 메뉴 (새로만들기, 열기, 저장) | - | `ui_layout` | 🟡 **부분 반영**: 웹 프로젝트 가져오기/내보내기 가이드 보강 필요 |
| `edit-menu.htm` | 편집 메뉴 (실행취소, 잘라내기 등) | - | `ui_layout`, `element_grid` | 🟡 **부분 반영**: 웹 단축키 및 Undo 가이드 보강 필요 |
| `view-menu.htm` | 뷰 메뉴 (확대, 축소, 3D 뷰) | - | `ui_layout` | 🟡 **부분 반영**: 2D/3D 캔버스 인터랙션(회전/줌/팬) 가이드 보강 필요 |
| `compute-menu.htm` | 연산 메뉴 (단면성질, FSM, 설계) | - | `ui_layout` | 🟢 **반영 완료** (웹 원클릭 자동 해석 파이프라인) |
| `tools-menu.htm` | 도구 메뉴 (마법사, 라이브러리) | - | `ui_layout` | 🟢 **반영 완료** |
| `windows-menu.htm` | 창 분할 및 정렬 메뉴 | - | `ui_layout` | 🟢 **반영 완료** (AltDP 4분할 그리드) |
| `cut-copy-paste.htm` | 요소 클립보드 복사/붙여넣기 | - | `element_grid` | 🟡 **부분 반영**: 요소 스프레드시트 클립보드 연동 예제 보강 필요 |
| `undo.htm` | 실행취소 및 다시실행 | - | `ui_layout` | 🟡 **부분 반영**: 텍스트 가이드 보강 필요 |
| `copy-image.htm` | 캔버스 이미지 복사 | - | `ui_layout` | 🟡 **부분 반영**: 캔버스 캡처/저장 가이드 보강 필요 |
| `print.htm` | 인쇄 및 PDF 출력 | - | `report_guide` | 🟡 **부분 반영**: 브라우저 A4 인쇄 설정 팁 보강 필요 |
| `recent-files.htm` | 최근 작업 파일 관리 | - | `ui_layout` | 🟡 **부분 반영**: 로컬 저장소 세션 복원 설명 필요 |

---

### 2.2 단면 기하 모델링 & 마법사 (Section Modeling & Wizards) - 15개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `sections.htm` | 단면 모델링 기본 개념 | - | `intro` | 🟢 **반영 완료** |
| `section-wizard-1.htm` | 단면 마법사 1단계 (단면형상 선택) | - | `wizard` | 🔴 **예제 누락**: 6대 기본 단면 파라메터 실무 튜토리얼 누락 |
| `section-wizard-2.htm` | 단면 마법사 2단계 (치수/립/R 설정) | - | `wizard` | 🔴 **예제 누락**: 플랜지 립 각도, 코너 Fillet R 설정 튜토리얼 누락 |
| `import-dxf.htm` | AutoCAD DXF 가져오기 | - | `dxf_import` | 🟡 **부분 반영**: 폴리라인 중심선 작도 규칙 실무 팁 보강 필요 |
| `section-inputs-section.htm` | 단면 기본 정보 탭 | - | `element_grid` | 🟢 **반영 완료** |
| `section-inputs-part.htm` | 파트(Part) 관리 및 복합단면 | - | `element_grid` | 🟢 **반영 완료** |
| `section-inputs-elements.htm`| 요소(Element) 스프레드시트 입력 | - | `element_grid` | 🟢 **반영 완료** (웹 스프레드시트 모달 구현) |
| `section-inputs-dsm.htm` | 직접강도법(DSM) 단면 파라메터 | - | `kds_dsm_comp` | 🟢 **반영 완료** |
| `element-behavior.htm` | 직선 요소 및 코너 굽힘 거동 상세 | - | `element_grid` | 🟡 **부분 반영**: 코너 곡선 분할 메싱 수식 심화 보강 필요 |
| `insert-delete.htm` | 요소 행 삽입/삭제 | - | `element_grid` | 🟢 **반영 완료** |
| `insert-ribs.htm` | V형/U형 중간 보강 리브 삽입 | - | `geom_transform` | 🟢 **반영 완료** |
| `rotate-mirror.htm` | 90° 회전 및 대칭 미러링 | - | `geom_transform` | 🟢 **반영 완료** |
| `center-section.htm` | 단면 원점 정렬 | - | `geom_transform` | 🟢 **반영 완료** |
| `complete-part-symmetry.htm`| 파트 대칭 자동 완성 | - | `geom_transform` | 🟢 **반영 완료** |
| `origin.htm` | 좌표 원점 정의 기준 | - | `geom_transform` | 🟢 **반영 완료** |

---

### 2.3 단면 라이브러리 & 재료 물성치 (Library & Materials) - 9개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `open-library-section.htm` | 표준 단면 라이브러리 열기 | - | `section_lib` | 🟢 **반영 완료** (1,000+개 AISI/SSMA/SFIA DB) |
| `library-builder.htm` | 커스텀 라이브러리 빌더 | 폴더 아이콘 | `section_lib` | 🟡 **부분 반영**: 폴더 트리 아이콘 및 사용자 DB 구축 가이드 |
| `custom-material-cs.htm` | 탄소강 커스텀 물성치 설정 | - | `material_db` | 🟢 **반영 완료** |
| `custom-material-ss.htm` | 스테인리스강 커스텀 물성치 | - | `material_db` | 🟢 **반영 완료** |
| `options-material.htm` | 기본 강종 프리셋 옵션 | - | `material_db` | 🟢 **반영 완료** (KS SSC275/SGC 및 ASTM 프리셋) |
| `options-thicknesses.htm` | 표준 판두께 프리셋 | - | `material_db` | 🟡 **부분 반영**: 미국 게이지(Gauge) vs mm 두께표 보강 필요 |
| `options-units.htm` | 단위계 설정 (SI/US/MKS) | - | `material_db` | 🟡 **부분 반영**: 단위계 환산표 보강 필요 |
| `options-heading.htm` | 계산서 프로젝트 표제 옵션 | - | `report_guide` | 🟡 **부분 반영**: 계산서 커스텀 헤더 가이드 보강 필요 |
| `options-combinations.htm` | 하중조합 계수 설정 | - | `analysis_wizard` | 🟢 **반영 완료** |

---

### 2.4 단면 기하 성질 & 유효단면 (Section Properties & Effective Stress) - 7개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `properties-report.htm` | 총단면 기하학적 성질 리포트 | - | `gross_props` | 🟢 **반영 완료** ($A_g, I_x, I_y, C_G$) |
| `effective-properties.htm` | Winter 식 기반 유효단면 해석 | - | `effective_props` | 🟢 **반영 완료** (압축/휨 유효폭 2D 시각화) |
| `torsion-analysis.htm` | 비틀림 응력 및 뒤틀림 해석 이론 | `torsion-section1.png`, `section2.png` | `torsion_props` | 🔴 **도해 누락**: 전단중심($x_0, y_0$), 뒴상수($C_w$) 좌표계 도해 2종 누락 |
| `torsion-design.htm` | 비틀림 부재설계 기준 | - | `torsion_props` | 🟢 **반영 완료** |
| `torsion-properties-report.htm`| 비틀림 성질 출력표 | - | `torsion_props` | 🟢 **반영 완료** |
| `torsion-diagrams.htm` | 비틀림각/바이모멘트 다이어그램 | `torsion-direction.png`, `diagrams.png` | `torsion_props` | 🔴 **도해 누락**: 비틀림 회전각 방향성 및 모멘트 도해 2종 누락 |
| `torsion-diagrams-report.htm` | 비틀림 다이어그램 리포트 | - | `torsion_props` | 🟢 **반영 완료** |

---

### 2.5 유한대판법(FSM) 탄성 좌굴해석 (FSM Elastic Buckling) - 2개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `buckling-parameters.htm` | FSM 반파장 스윕 및 하중 조건 | - | `fsm_params` | 🟢 **반영 완료** ($L_{min} \sim L_{max}$, 스텝 수) |
| `buckling-results.htm` | 좌굴 모드 판별 및 시그니처 커브 | `buckle-profile.png`, `shape.png`, `shapes.png`, `renders.png` | `buckling_modes`, `signature_curve` | 🔴 **도해 누락**: 국부($P_{crl}$)/왜곡($P_{crd}$)/전체($P_{cre}$) 2D/3D 변형 모드 도해 4종 전수 누락 |

---

### 2.6 KDS 부재설계 & 계산서 출력 (Member Design & Reports) - 9개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `member-check-parameters.htm`| 부재 지지길이($L_x, L_y, L_t$) 및 $K, C_b$ | - | `kds_dsm_comp`, `kds_dsm_flex` | 🟢 **반영 완료** |
| `locations.htm` | 모멘트/축력 검토 위치 지정법 | - | `kds_dsm_comp` | 🟡 **부분 반영**: 단면력 검토 위치 실무 가이드 보강 필요 |
| `strength-report.htm` | 직접강도법(DSM) 공칭강도 계산서 | - | `report_guide` | 🟢 **반영 완료** |
| `member-check-report.htm` | P-M 조합응력 안전율 검토서 | - | `report_guide` | 🟢 **반영 완료** |
| `quick-design.htm` | 퀵 디자인 (최적 단면 자동 추천) | `quick-design.png` | `quick_design` | 🔴 **도해 누락**: 원본 `quick-design.png` 대화상자 도해 누락 |
| `web-crippling-parameters.htm`| 웨브 크리플링 지지조건(4대 플랜지) | - | `kds_shear_crip` | 🟢 **반영 완료** (EOF/IOF/ETF/ITF) |
| `web-crippling-report.htm` | 웨브 크리플링 강도 리포트 | - | `report_guide` | 🟢 **반영 완료** |
| `reports.htm` | 리포트 생성 및 인쇄 관리 | - | `report_guide` | 🟢 **반영 완료** |
| `diagrams-report.htm` | 단면력 다이어그램 출력표 | - | `report_guide` | 🟢 **반영 완료** |

---

### 2.7 1D 뼈대 구조해석 & 마법사 (1D Frame Analysis & Wizards) - 12개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 포함 도해/이미지 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `analyses.htm` | 구조해석 모델링 관리 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-wizard-1.htm` | 해석 마법사 1단계 (경간 Span 설정) | - | `analysis_wizard` | 🔴 **예제 누락**: 단순보/연속보 4단계 마법사 실무 튜토리얼 누락 |
| `analysis-wizard-2.htm` | 해석 마법사 2단계 (지점 Support 설정) | - | `analysis_wizard` | 🔴 **예제 누락**: 핀/롤러/고정단 지점 및 부재 지정 예제 누락 |
| `analysis-wizard-3.htm` | 해석 마법사 3단계 (하중 Loadings 입력) | - | `analysis_wizard` | 🔴 **예제 누락**: 등분포/집중하중/모멘트 입력 실무 예제 누락 |
| `analysis-wizard-4.htm` | 해석 마법사 4단계 (하중조합 및 완료) | - | `analysis_wizard` | 🔴 **예제 누락**: 하중조합 생성 및 해석 실행 예제 누락 |
| `analysis-inputs-general.htm`| 해석 일반 옵션 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-inputs-members.htm`| 부재 단면 배치 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-inputs-supports.htm`| 지점 경계조건 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-inputs-loadings.htm`| 하중 케이스 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-inputs-combinations.htm`| 하중 조합 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-inputs-notes.htm` | 설계자 메모 탭 | - | `analysis_wizard` | 🟢 **반영 완료** |
| `analysis-diagrams.htm` | SFD / BMD / 처짐 선도 | - | `diagrams_viewer` | 🟢 **반영 완료** (차트 인터랙션 구현) |

---

### 2.8 용어사전, 기호집 및 라이선스 (Glossary, Symbols & Misc) - 9개 항목

| 원본 도움말 파일명 | 원본 표제 및 내용 | 분량/특징 | 현재 웹 토픽 매핑 | 반영 상태 및 누락 내역 (Gap) |
|---|---|:---:|---|---|
| `glossary.htm` | 냉간성형강 전문 용어사전 | **18,663자** (A~Z 전수) | 전 토픽 툴팁 | 🔴 **전문 누락**: 일부 툴팁만 존재, 용어사전 전문 페이지/목차 부재 |
| `symbols.htm` | 공학 기호 및 약어 정의집 | **6,673자** | 전 토픽 | 🔴 **전문 누락**: 수식 기호집 전문 부재 |
| `technical-assistance.htm` | 기술지원 안내 | 2,824자 | `intro` | 🟢 **반영 완료** |
| `license-activation.htm` 등 6개 | 레거시 C# 라이선스 문서 | 6개 파일 | - | ⚪ **제외 대상** (웹 SaaS/오픈소스 환경에 불필요) |

---

## 3. 핵심 포팅 타겟 및 자산화 전략

### 3.1 원본 도해 이미지(13종) 및 [레거시 vs 모던 웹] 1:1 대조 UI 캡처 자산화

```
[1. 원본 레거시 자산] decompiled_src/cfs_help_manual/ ──> src/web/static/images/manual/
├── section.png                 ──> section.png (레거시 단면 메인 창)
├── analysis.png                ──> analysis.png (레거시 1D 해석 창)
├── quick-design.png            ──> quick-design.png (레거시 퀵 디자인)
├── buckle-profile.png          ──> buckle-profile.png (FSM 시그니처 이론)
├── buckle-shape.png            ──> buckle-shape.png (좌굴 모드 형상 이론)
├── buckle-shapes.png           ──> buckle-shapes.png (모드 다이어그램 이론)
├── buckle-renders.png          ──> buckle-renders.png (3D 렌더링 이론)
├── torsion-section1.png        ──> torsion-section1.png (비틀림 좌표계 1)
├── torsion-section2.png        ──> torsion-section2.png (비틀림 좌표계 2)
├── torsion-direction.png       ──> torsion-direction.png (회전 방향)
├── torsion-diagrams.png        ──> torsion-diagrams.png (비틀림 모멘트도)
├── folder-open.jpg             ──> folder-open.jpg (트리 아이콘)
└── folder-closed.jpg           ──> folder-closed.jpg (트리 아이콘)

[2. 신규 모던 웹 UI 캡처 자산] (AltDP 웹 뷰어 2열 대조용) ──> src/web/static/images/manual/
├── web-section-ui.png          ──> AltDP 4분할 모던 레이아웃 (제어판, 2D/3D 캔버스, FSM, D/C)
├── web-analysis-ui.png         ──> 1D 뼈대해석 마법사 및 인터랙티브 SFD/BMD/처짐 차트
└── web-quick-design.png        ──> 소요하중 입력 ──> 표준 단면 최적 경량 자동 추천 모달
```

### 3.2 단계별 마법사 튜토리얼(Walkthrough) 이식
* **단면 마법사 2단계 (`wizard`)**: C형강/Z형강 립 및 코너 Fillet R 설정 튜토리얼 예제
* **1D 구조해석 마법사 4단계 (`analysis_wizard`)**: 경간 $\rightarrow$ 지점 $\rightarrow$ 하중 $\rightarrow$ 조합 4단계 예제
* **DXF 메싱 가이드 (`dxf_import`)**: 폴리라인 중심선 및 분할 실무 팁

### 3.3 용어사전 & 기호집 전문 이식
* `glossary.htm`(18,663자) 및 `symbols.htm`(6,673자)을 `/manual`의 독립 색인 뷰 및 검색 인덱스에 통합.
