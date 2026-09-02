# CFDesigner (Cold-Formed Section Analyzer & Designer) - Master Agent Guide (AGENTS.md)

본 문서는 **CFDesigner (냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS/AISI 부재설계 시스템)** 프로젝트에서 작업하는 AI 에이전트(Antigravity / Gemini)의 핵심 원칙, 규약 및 워크플로우를 정의합니다.

---

## 1. 프로젝트 목적 및 에이전트 미션

* **프로젝트명**: CFDesigner (Cold-Formed Section Analyzer & Designer)
* **프로젝트 핵심 목적**:
  * **기존 상용 CFS 프로그램(`CFS.exe`)의 모든 기능, 공학 해석/설계 알고리즘, 라이브러리 및 도움말 시스템을 모던 웹(Web) 애플리케이션으로 100% 포팅(Full Web Migration)**하는 것.
* **에이전트 미션**:
  1. 상용 프로그램(`CFS.exe`)의 **C# 소스코드 및 원본 자산을 Ground Truth(정답 기준)로 삼아 모든 기능과 엣지 케이스 수식, 수치해석 노하우를 무결하게 웹 엔진으로 포팅**.
  2. AutoCAD 2D Polyline(DXF) 입력 기반의 **비정형 단면 기하 모델링 $\rightarrow$ FSM(유한대판법) 탄성 좌굴해석 $\rightarrow$ KDS 14 31 10 / AISI S100 직접강도법(DSM) 설계 파이프라인**을 모던 AltDP 웹 UI로 완전 구현.
  3. 단면 해석, 시그니처 커브, 3D 좌굴모드 시각화, 부재검토, 계산서 출력 및 다국어 온라인 도움말 시스템 등 CFS의 전 영역을 웹 기반으로 완벽 서비스화.

---

## 2. 초고속 파일 라우팅 맵 (0.1s Fast Routing Index)

> 💡 기능 구현 및 수식 분석 시 전체 검색(Grep)을 최소화하고 아래 지정된 대상 파일로 즉시 직행합니다.

| 도메인 / 기능 | 원본 레퍼런스 (C#) | 기술 문서 (SSOT) | 주요 심볼 및 역할 |
|---|---|---|---|
| **CAD / DXF 파싱** | [`RSG/CFS/DXF.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/DXF.cs)<br>[`RSG/CFS/Section.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Section.cs#L1059) | [`docs/02_cad_dxf_specification.md`](file:///f:/PyProject/CFDesigner/docs/02_cad_dxf_specification.md) | `ImportDXF`, `DXFPart` (Polyline, Arc, Width 메싱) |
| **단면 기하학적 성질** | [`RSG/CFS/Section.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Section.cs)<br>[`RSG/CFS/Part.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Part.cs) | [`docs/03_section_properties.md`](file:///f:/PyProject/CFDesigner/docs/03_section_properties.md) | `CalcProperties`, `Geometry` ($A, I, J, C_w, x_o, y_o$) |
| **유한대판법 (FSM)** | [`RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs)<br>[`RSG/Math/Sturm.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/Math/Sturm.cs) | [`docs/04_finite_strip_method.md`](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md) | `FiniteStripAnalysis` ($[K_e], [K_g]$ 조립, 고유치 해석) |
| **KDS / AISI 부재설계** | [`RSG/CFS/MemberCheck.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/MemberCheck.cs)<br>[`RSG/CFS/Section.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Section.cs#L4080) | [`docs/05_kds_aisi_design_rules.md`](file:///f:/PyProject/CFDesigner/docs/05_kds_aisi_design_rules.md) | `MemberCheck` ($P_n, M_n, V_n, P_{nc}$, P-M 조합) |
| **유효단면 응력해석** | [`RSG/CFS/EffectiveProperties.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/EffectiveProperties.cs) | [`docs/03_section_properties.md`](file:///f:/PyProject/CFDesigner/docs/03_section_properties.md) | `EffectiveProperties` (Winter 유효폭 반복 계산) |

---

## 3. 핵심 개발 및 행동 원칙 (Core Rules)

### 3.1. 소스코드 격리 및 참조 원칙 (Isolation Rules)
* **`decompiled_src/`는 오직 읽기 전용(Read-Only) 레퍼런스**:
  * 복원된 C# 소스는 알고리즘 분석 및 수식 검증의 정답(Ground Truth)으로만 사용하며, 임의로 소스코드를 변형하지 않습니다.
* **신규 개발 엔진(`src/`)의 독립성**:
  * 신규 구현은 외부 라이선스(`PLUSManaged.dll` 등)에 의존하지 않는 순수 Python 기반의 모던 아키텍처로 독립 작성합니다.

### 3.2. KDS 국가건설기준 및 교차 검증 규약 (KDS Reference Protocol)
* **KDS 14 31 10(냉간성형강) 기준 준수**:
  * 국내 규준 KDS 14 31 10 및 모태 규준인 AISI S100을 준수합니다.
  * 국가건설기준 원문 대조 시 상위 워크스페이스의 **`kcsc2md` Ground Truth 자산(`../kcsc2md/output/kds_md/`)**을 활용합니다.
* **0.1% 오차 무결성 검증 (Cross-Validation)**:
  * 표준 단면(C, Z형강)에 대해 CFS.exe 원본 계산치와 신규 엔진 계산치를 대조하여 오차 0.1% 미만의 무결성을 입증합니다.
* **엔진 수정 시 원본(Ground Truth) 동일성 검증 의무**:
  * 엔진 구현 내용(`src/geometry/`, `src/solver/`, `src/design/`)은 원본 C# 구현의 신뢰도가 매우 높으므로, 엔진 관련 내용이 변경될 경우 반드시 원본 계산치 및 수식과 100% 동일한지 검증을 거칩니다.
* **도움말 영문 원본 보존 원칙 (English Help Fidelity)**:
  * 한·영 대조 조건을 맞춘다고 원본 영문 도움말 내용을 임의로 변경/변형하지 않고, 구성/배열/포맷팅만 일치시킵니다.

### 3.3. 디렉토리 수명 및 스크래치 관리 규칙 (Scratch Rule)
* **`scratch/` 폴더 휘발성 원칙**:
  * `scratch/` 디렉토리는 사용자에 의해 언제든 수시로 전체 삭제될 수 있는 임시 공간입니다.
  * 영구 보존해야 하는 매뉴얼, 공식 데이터, 문서는 반드시 `docs/` 또는 `src/`에 배치합니다.

### 3.4. 요구사항 & 문서 라이프사이클 (AltDP 표준 규약)
* **요구사항 문서 생성 규칙 (경량화)**: 
  * 사용자가 채팅으로 메모형식의 요청사항을 전달하며 "요구사항 문서 만들어줘" 등을 요청할 때는 **별도의 Implementation Plan 아티팩트나 구현 계획을 생성하지 않고**, 오직 요구사항 정리 및 `요구사항/요구사항XX.md` 파일 생성에만 집중합니다. (일련번호는 `요구사항/@@OLD/` 마지막 번호의 다음 번호 부여)
* **대규모 요구사항 사전 점검 및 하위 문서 세분화 제안 (Scope Partitioning)**:
  * 사용자가 요구사항 문서를 기반으로 "계획해줘" 또는 구현을 요청할 때, 작업 범위가 다수 모듈(3개 이상 레이어/파일 10개 이상 등)에 걸쳐 있어 구현 누락 위험이 높다고 판단되면:
    1. 사용자에게 대규모 구현에 따른 **누락 위험을 사전에 알리고 확인을 요청**.
    2. 단일 요구사항을 하위 문서(예: `요구사항XX-1.md`, `요구사항XX-2.md` 또는 명확한 독립 Phase)로 **세분화하여 단계별로 구분 진행할 것을 제안**.
* **요구사항 전수 체크리스트 검증 의무 (Zero-Omission Verification)**:
  * 요구사항 문서 작업 시 문서 내 세부 항목과 검증 기준(Acceptance Criteria)을 1:1 체크리스트로 대조 검증하고, 누락 항목이 0건임을 자체 확인한 후 완료 보고.
* **명시적 요청 시에만 완료/아카이빙**:
  * 사용자 요청 시에만 `요구사항/` 파일을 `요구사항/@@OLD/요구사항XX-YYMMDD_HHMM.md`로 이동 및 아카이빙.
* **README.md 일괄 업데이트**:
  * 중간에 임의 수정하지 않고 사용자 명시적 요청 시에만 일괄 갱신.
* **기술 문서는 실시간 최신화**:
  * `docs/` 내의 기술 문서는 아키텍처/구조 변경 시 지속 동기화.

### 3.5. Goal 주도형 단계적 연속 구현 규약 (Goal-Driven Continuous Partitioned Execution)
* **집중력 유지 및 토큰 효율성 극대화**:
  * 사용자가 마스터 요구사항(예: `요구사항05`)을 통째로 `/goal`로 지정하여 전체 작업을 지시할 때, 에이전트는 단일 컨텍스트 폭주와 누락을 방지하고 토큰 효율성을 추구하기 위해 **작은 단위로 분할된 하위 Phase 문서(`요구사항XX-1`, `XX-2` 등)를 순차적 실행 단위로 삼아 지속적으로 전체 구현을 완주**합니다.
* **단계별 무결성 자율 전진 (Phase-by-Phase Verification & Progression)**:
  1. 각 하위 Phase별로 지정된 파일과 컴포넌트만 정밀하게 구현/수정하여 컨텍스트 낭비를 최소화.
  2. 해당 Phase의 Acceptance Criteria(1:1 체크리스트) 및 단위 테스트(`pytest`) 100% 통과를 확인.
  3. 완료 즉시 다음 Phase로 중단 없이 자율 진입하여 마스터 요구사항의 모든 Phase가 끝날 때까지 연속 작업.
  4. 모든 하위 Phase 완료 후 마스터 요구사항의 종합 수용 기준을 최종 전수 검증하고 완수 보고.

### 3.6. 버그 수정 및 개별 이슈 대응 규약 (Bug Fix & Issue Resolution Protocol)
* **1이슈 1Phase 원칙 (One-by-One Resolution)**:
  * 버그 픽스 및 결함 조치는 원인 규명과 영향도 검증의 정확성을 위해 되도록 **1가지 이슈마다 독립된 Phase(또는 독립 작업 단위)로 구별**하여 구현 계획을 수립하고, 1가지씩 해결 및 동작 확인(`pytest`/UI 검증)을 완료합니다.
* **복잡도 기반 묶음 처리 제한**:
  * 복잡도가 매우 낮고 상호 연관성이 높은 경미한 버그의 경우 예외적으로 1~3개 정도를 한꺼번에 계획할 수 있으나, **원칙적으로는 개별 아이템으로 분리하여 순차 처리**합니다.
* **요구사항 내 버그 픽스 동일 적용**:
  * 일반 기능 요구사항 문서 내에 버그 수정(Bug Fix) 또는 오동작 개선 항목이 포함되어 있는 경우에도 동일하게 적용하여, 하위 Phase 분할 시 독립된 실행 단위로 분리하여 계획하고 검증합니다.

### 3.7. 도메인별 3대 Pytest 초고속 검증 규약 (Domain-Specific Pytest Protocol)
* **도메인별 타겟 테스트 원칙**:
  * 전체 테스트를 매번 실행하지 않고, 작업 도메인에 부합하는 디렉토리(`engine/`, `ui/`, `manual/`)만 타겟팅하여 0.5~1.5초 내에 신속 검증합니다.
  * 상세한 도메인별 테스트 목록 및 작성 규칙은 **[`docs/11_pytest_testing_guide.md`](file:///f:/PyProject/CFDesigner/docs/11_pytest_testing_guide.md)**를 참조합니다.
  * **엔진 작업 시**: `pytest tests/engine/` | **UI/API 작업 시**: `pytest tests/ui/` | **도움말 작업 시**: `pytest tests/manual/` | **마스터 완료 시**: `pytest`

### 3.8. 작업별 모델 활용 전략 (Model Tier Guidelines)
1. **High 모델 (Flash High / Pro)**: FSM 수치해석 행렬 분석, 비정형 CAD 메싱 알고리즘 역추적, KDS DSM 설계식 유도
2. **Medium 모델 (Flash Medium)**: 파이썬 모듈 구현, 단위 테스트 작성, 디컴파일/데이터 파싱
3. **Low 모델 (Flash Low / Lite)**: 단순 파일 조회, Git 커밋/푸시 명령 실행

---

## 4. 세부 기술 문서 및 인벤토리 맵 (Documentation References)

* 📑 **[프로젝트 구조 및 파일 인벤토리 명세 (SSOT)](file:///f:/PyProject/CFDesigner/docs/프로젝트_구조_및_파일_인벤토리_명세.md)**: 108개 복원 C# 클래스 및 파일별 역할 상세 명세
* 📐 **[전체 시스템 아키텍처](file:///f:/PyProject/CFDesigner/docs/01_system_architecture.md)**: 전체 시스템 구조 및 5대 계층 흐름도
* 📏 **[CAD(DXF) 파싱 명세](file:///f:/PyProject/CFDesigner/docs/02_cad_dxf_specification.md)**: 2D Polyline 규칙 및 `DXFPart` 메싱 알고리즘
* ⚙️ **[단면 기하학적 성질 계산서](file:///f:/PyProject/CFDesigner/docs/03_section_properties.md)**: Gross/Effective 특성치($A, I, J, C_w, x_o, y_o$) 수식집
* 🔬 **[유한대판법(FSM) 해석 명세](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md)**: $[K_e], [K_g]$ 강성행렬 및 좌굴 모드 판별 이론
* 🏛️ **[KDS / AISI 부재설계 기준서](file:///f:/PyProject/CFDesigner/docs/05_kds_aisi_design_rules.md)**: 직접강도법(DSM) 공칭강도 수식집
* 🚀 **[Python 독립 엔진 아키텍처 명세서](file:///f:/PyProject/CFDesigner/docs/06_python_engine_architecture_specification.md)**: 5대 계층 독립 Python 엔진 구조 및 API 사양
* 💻 **[CFDesigner 웹 앱 UI/UX 명세서](file:///f:/PyProject/CFDesigner/docs/07_web_application_ui_ux_specification.md)**: 4대 화면, 10대 전문 모달, 2D/3D 인터랙션 및 UX 파이프라인 규약
* 📖 **[온라인 도움말 시스템 통합 명세서](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)**: 한·영 Bilingual 3-Way 뷰, 8대 카테고리 27개 토픽 및 다국어 검색 통합 SSOT
* 📊 **[CFS 레거시 도움말 vs 웹 이식 검증서](file:///f:/PyProject/CFDesigner/docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md)**: 원본 도움말 79개 토픽 + 16종 이미지 vs 웹 27개 토픽 1:1 전수 대조 및 100% 이식 검증 (Gap 0건 완결판)
* 🔍 **[CFS Legacy UI vs Web Gap 분석서](file:///f:/PyProject/CFDesigner/docs/10_cfs_legacy_ui_vs_web_gap_analysis.md)**: CFS 원본 UI 기능 전수 대조 및 웹 구현 현황
* 🧪 **[Pytest 도메인별 3대 테스트 가이드](file:///f:/PyProject/CFDesigner/docs/11_pytest_testing_guide.md)**: 엔진 / UI / 도움말 3대 영역 분리 구조, 초고속 실행 치트시트 및 검증 규칙
* 📑 **[구조계산서 및 출력 시스템 명세서](file:///f:/PyProject/CFDesigner/docs/12_structural_calculation_report_specification.md)**: 듀얼 리포트 모드, CFS 원본 14종 리포트 전수 이식, 10대 장별 수식/테이블 및 SVG 다이어그램 사양
* 📊 **[요구사항 09 전수검증 및 대조비교표 보고서](file:///f:/PyProject/CFDesigner/docs/13_요구사항09_전수검증_및_대조비교표_보고서.md)**: 5대 도메인 22개 세부 요구사항 1:1 대조 비교표, 결함 보완 내역 및 77개 테스트 100% 무결성 검증서
* 🔬 **[FSM 버클링 모드 해석, 고차 모드 거동 및 수치 발산 방어 이론 분석서](file:///f:/PyProject/CFDesigner/docs/14_fsm_buckling_modes_and_higher_order_theory_analysis.md)**: CFS 원본 Sturm 수열 단일 모드 vs 웹 다중 모드 비교, 휨 상태 면내 막 발산 방어 메커니즘 및 3대 좌굴 모드 판별 SSOT
* 🔗 **[KDS 국가건설기준 연동 가이드 (kcsc2md)](file:///f:/PyProject/kcsc2md/docs/외부프로젝트_연동_및_조회_가이드.md)**: KDS 기준 Ground Truth 조회 표준


