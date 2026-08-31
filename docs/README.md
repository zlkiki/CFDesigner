# CFDesigner - 기술 문서 관리소 (SSOT: Single Source of Truth)

본 디렉토리(`docs/`)는 **CFDesigner 시스템의 단일 진실 공급원(SSOT)**으로서, 역공학 분석 데이터, 시스템 아키텍처, 공학 이론 수식, KDS/AISI 설계 기준, 그리고 기술 사양서를 영구 보존 및 실시간 동기화하여 관리합니다.

---

## 📑 SSOT 기술 문서 인벤토리

| 번호 / 파일명 | 문서 제목 | 핵심 내용 |
|---|---|---|
| **[`프로젝트_구조_및_파일_인벤토리_명세.md`](file:///f:/PyProject/CFDesigner/docs/프로젝트_구조_및_파일_인벤토리_명세.md)** | 프로젝트 구조 및 108개 파일 인벤토리 명세 | 역공학 C# 소스코드 108개 클래스 역할 및 매핑 맵 |
| **[`00_todo_and_roadmap.md`](file:///f:/PyProject/CFDesigner/docs/00_todo_and_roadmap.md)** | 전체 개발 로드맵 및 규준 비교 인덱스 | 단계별 포팅 로드맵 및 KDS 14 31 10 매핑 |
| **[`01_system_architecture.md`](file:///f:/PyProject/CFDesigner/docs/01_system_architecture.md)** | 전체 시스템 아키텍처 명세 | 5대 계층(입력, 기하, 해석, 설계, 출력) 아키텍처 |
| **[`02_cad_dxf_specification.md`](file:///f:/PyProject/CFDesigner/docs/02_cad_dxf_specification.md)** | CAD (DXF) 파싱 및 기하 메싱 사양서 | Polyline, Arc, Width, Fillet R 메싱 규칙 |
| **[`03_section_properties.md`](file:///f:/PyProject/CFDesigner/docs/03_section_properties.md)** | 단면 기하학적 성질 수식집 | Gross/Effective 특성치($A, I, J, C_w, x_o, y_o, \alpha$) 공식 |
| **[`04_finite_strip_method.md`](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md)** | 유한대판법 (FSM) 탄성 좌굴해석 이론 | $[K_e], [K_g]$ 강성행렬 유도 및 고유치 판별식 |
| **[`05_kds_aisi_design_rules.md`](file:///f:/PyProject/CFDesigner/docs/05_kds_aisi_design_rules.md)** | KDS 14 31 10 / AISI S100 부재설계 기준서 | 직접강도법(DSM) $P_n, M_n, V_n, P_{nc}$, P-M 조합식 |
| **[`06_python_engine_migration_plan.md`](file:///f:/PyProject/CFDesigner/docs/06_python_engine_migration_plan.md)** | Python 독립 엔진 아키텍처 설계서 | 4대 계층 독립 Python 엔진 구조 및 API 사양 |
| **[`07_altdp_web_app_specification.md`](file:///f:/PyProject/CFDesigner/docs/07_altdp_web_app_specification.md)** | AltDP 스타일 웹 SaaS 애플리케이션 사양서 | FastAPI 백엔드, 2D Canvas, 3D Three.js, A4 계산서 사양 |
| **[`08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)** | 온라인 도움말 시스템 사양서 (한글화 & KDS 기준) | 4대 카테고리 목차, KDS 14 31 10 용어 매핑, 웹 매뉴얼 뷰어 사양 |
| **[`cfs_help_manual/`](file:///f:/PyProject/CFDesigner/docs/cfs_help_manual/overview.htm)** | CFS 14.0 공식 매뉴얼 원문 아카이브 | 95개 HTML 공식 이론 및 인터페이스 도움말 |

---

## 📌 문서 작성 및 관리 원칙
1. **SSOT 원칙**: 모든 수치해석 공식, 설계 기준식, 시스템 아키텍처의 기준은 본 `docs/` 문서를 따릅니다.
2. **개발 요구사항 분리**: 개별 구현 작업, 기능 추가 요구사항, 태스크 목록은 `요구사항/` 디렉토리에서 관리합니다.
