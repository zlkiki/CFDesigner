# CFDesigner - 기술 문서 관리소 (SSOT: Single Source of Truth)

본 디렉토리(`docs/`)는 **CFDesigner 시스템의 단일 진실 공급원(SSOT)**으로서, 역공학 분석 데이터, 시스템 아키텍처, 공학 이론 수식, KDS/AISI 설계 기준, 그리고 기술 사양서를 영구 보존 및 실시간 동기화하여 관리합니다.

---

## 📑 SSOT 기술 문서 인벤토리

| 번호 / 파일명 | 문서 제목 | 핵심 내용 |
|---|---|---|
| **[`프로젝트_구조_및_파일_인벤토리_명세.md`](file:///f:/PyProject/CFDesigner/docs/프로젝트_구조_및_파일_인벤토리_명세.md)** | 프로젝트 구조 및 108개 파일 인벤토리 명세 | 역공학 C# 소스코드 108개 클래스 역할 및 매핑 맵 |
| **[`01_system_architecture.md`](file:///f:/PyProject/CFDesigner/docs/01_system_architecture.md)** | 전체 시스템 아키텍처 명세 | 5대 계층(입력, 기하, 해석, 설계, 출력) 아키텍처 |
| **[`02_cad_dxf_specification.md`](file:///f:/PyProject/CFDesigner/docs/02_cad_dxf_specification.md)** | CAD (DXF) 파싱 및 기하 메싱 사양서 | Polyline, Arc, Width, Fillet R 메싱 규칙 |
| **[`03_section_properties.md`](file:///f:/PyProject/CFDesigner/docs/03_section_properties.md)** | 단면 기하학적 성질 수식집 | Gross/Effective 특성치($A, I, J, C_w, x_o, y_o, \alpha$) 공식 |
| **[`04_finite_strip_method.md`](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md)** | 유한대판법 (FSM) 탄성 좌굴해석 이론 | $[K_e], [K_g]$ 강성행렬 유도 및 고유치 판별식 |
| **[`05_kds_aisi_design_rules.md`](file:///f:/PyProject/CFDesigner/docs/05_kds_aisi_design_rules.md)** | KDS 14 31 10 / AISI S100 부재설계 기준서 | 직접강도법(DSM) $P_n, M_n, V_n, P_{nc}$, P-M 조합식 |
| **[`06_python_engine_architecture_specification.md`](file:///f:/PyProject/CFDesigner/docs/06_python_engine_architecture_specification.md)** | Python 독립 수치해석 및 설계 엔진 아키텍처 명세서 | 5대 계층(CAD/기하/FSM/설계/리포트) 독립 Python 엔진 구조 및 API 사양 |
| **[`07_web_application_ui_ux_specification.md`](file:///f:/PyProject/CFDesigner/docs/07_web_application_ui_ux_specification.md)** | CFDesigner 웹 애플리케이션 및 UI/UX 구조 명세서 | 4대 화면 구성, 10대 전문 모달, 2D/3D 인터랙션, 반응형 연산 UX, 전수 API 사양 |
| **[`08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)** | 온라인 도움말 시스템 통합 명세서 (한·영 Bilingual) | 8대 카테고리 27개 토픽, 3-Way 뷰(한글/스플릿/영문), 인라인 토글, 다국어 검색 통합 SSOT |
| **[`11_pytest_testing_guide.md`](file:///f:/PyProject/CFDesigner/docs/11_pytest_testing_guide.md)** | Pytest 도메인별 3대 테스트 가이드 | 엔진 / UI / 도움말 3대 영역 분리 구조, 초고속 실행 치트시트 및 검증 규칙 |
| **[`12_structural_calculation_report_specification.md`](file:///f:/PyProject/CFDesigner/docs/12_structural_calculation_report_specification.md)** | 구조계산서 및 출력 시스템 명세서 | 듀얼 리포트 모드, CFS 원본 14종 리포트 전수 이식, 10대 장별 수식/테이블 및 SVG 다이어그램 사양 |
| **[`14_fsm_buckling_modes_and_higher_order_theory_analysis.md`](file:///f:/PyProject/CFDesigner/docs/14_fsm_buckling_modes_and_higher_order_theory_analysis.md)** | FSM 버클링 모드 해석 및 고차 모드 거동 분석서 | Sturm 수열 vs 다중 모드 비교, 휨 상태 면내 막 발산 방어 메커니즘 및 3대 좌굴 모드 판별 SSOT |
| **[`archive/09_cfs_legacy_help_manual_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/archive/09_cfs_legacy_help_manual_vs_web_gap_analysis.md)** | CFS 레거시 도움말 vs 웹 이식 검증서 (보관) | 원본 도움말 79개 토픽 + 16종 이미지 vs 웹 27개 토픽 1:1 전수 대조 및 100% 이식 검증 (Gap 0건) |
| **[`archive/10_cfs_legacy_ui_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/archive/10_cfs_legacy_ui_vs_web_gap_analysis.md)** | CFS 레거시 UI vs 웹 구현 Gap 분석서 (보관) | 상용 CFS 14.0 원본 기능 100% 전수 대조 및 Phase 1~5 웹 이식 검증 |
| **[`cfs_help_manual/`](file:///f:/PyProject/CFDesigner/decompiled_src/cfs_help_manual/overview.htm)** | CFS 14.0 공식 매뉴얼 원문 아카이브 | CFS.chm 추출 95개 HTML 공식 이론 및 인터페이스 도움말 (`decompiled_src/`) |

---

## 📌 문서 작성 및 관리 원칙
1. **SSOT 원칙**: 모든 수치해석 공식, 설계 기준식, 시스템 아키텍처의 기준은 본 `docs/` 문서를 따릅니다.
2. **개발 요구사항 분리**: 개별 구현 작업, 기능 추가 요구사항, 태스크 목록은 `요구사항/` 디렉토리에서 관리합니다.
