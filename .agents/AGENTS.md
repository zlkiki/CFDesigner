# CFDesigner (Cold-Formed Section Analyzer & Designer) - Master Agent Guide (AGENTS.md)

본 문서는 **CFDesigner (냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS/AISI 부재설계 시스템)** 프로젝트에서 작업하는 AI 에이전트(Antigravity / Gemini)의 핵심 원칙, 규약 및 워크플로우를 정의합니다.

---

## 1. 프로젝트 목적 및 에이전트 미션

* **프로젝트명**: CFDesigner (Cold-Formed Section Analyzer & Designer)
* **에이전트 미션**:
  1. 상용 프로그램(`CFS.exe`)의 **C# 소스코드를 Ground Truth(정답 기준)로 삼아 엣지 케이스 수식 및 수치해석 노하우를 무결하게 참조**.
  2. AutoCAD 2D Polyline(DXF) 입력 기반의 **비정형 단면 기하 모델링 $\rightarrow$ FSM(유한대판법) 탄성 좌굴해석 $\rightarrow$ KDS 14 31 10 / AISI S100 직접강도법(DSM) 설계 파이프라인** 구축.

---

## 2. 초고속 파일 라우팅 맵 (0.1s Fast Routing Index)

> 💡 기능 구현 및 수식 분석 시 전체 검색(Grep)을 최소화하고 아래 지정된 대상 파일로 즉시 직행합니다.

| 도메인 / 기능 | 원본 레퍼런스 (C#) | 기술 문서 (SSOT) | 주요 심볼 및 역할 |
|---|---|---|---|
| **CAD / DXF 파싱** | [`RSG/CFS/DXF.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/DXF.cs)<br>[`RSG/CFS/Section.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/Section.cs#L1059) | [`docs/02_cad_dxf_specification.md`](file:///f:/PyProject/CFT/docs/02_cad_dxf_specification.md) | `ImportDXF`, `DXFPart` (Polyline, Arc, Width 메싱) |
| **단면 기하학적 성질** | [`RSG/CFS/Section.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/Section.cs)<br>[`RSG/CFS/Part.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/Part.cs) | [`docs/03_section_properties.md`](file:///f:/PyProject/CFT/docs/03_section_properties.md) | `CalcProperties`, `Geometry` ($A, I, J, C_w, x_o, y_o$) |
| **유한대판법 (FSM)** | [`RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/FiniteStrip.cs)<br>[`RSG/Math/Sturm.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/Math/Sturm.cs) | [`docs/04_finite_strip_method.md`](file:///f:/PyProject/CFT/docs/04_finite_strip_method.md) | `FiniteStripAnalysis` ($[K_e], [K_g]$ 조립, 고유치 해석) |
| **KDS / AISI 부재설계** | [`RSG/CFS/MemberCheck.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/MemberCheck.cs)<br>[`RSG/CFS/Section.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/Section.cs#L4080) | [`docs/05_kds_aisi_design_rules.md`](file:///f:/PyProject/CFT/docs/05_kds_aisi_design_rules.md)<br>[`docs/00_todo_and_roadmap.md`](file:///f:/PyProject/CFT/docs/00_todo_and_roadmap.md) | `MemberCheck` ($P_n, M_n, V_n, P_{nc}$, P-M 조합) |
| **유효단면 응력해석** | [`RSG/CFS/EffectiveProperties.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/CFS/EffectiveProperties.cs) | [`docs/03_section_properties.md`](file:///f:/PyProject/CFT/docs/03_section_properties.md) | `EffectiveProperties` (Winter 유효폭 반복 계산) |

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

### 3.3. 디렉토리 수명 및 스크래치 관리 규칙 (Scratch Rule)
* **`scratch/` 폴더 휘발성 원칙**:
  * `scratch/` 디렉토리는 사용자에 의해 언제든 수시로 전체 삭제될 수 있는 임시 공간입니다.
  * 영구 보존해야 하는 매뉴얼, 공식 데이터, 문서는 반드시 `docs/` 또는 `src/`에 배치합니다.

### 3.4. SSOT(docs/) vs 요구사항(요구사항/) 폴더 분리 및 라이프사이클 규약
* **`docs/` (SSOT: Single Source of Truth)**:
  * 시스템 아키텍처, 공학 수식집, 설계 규준(KDS/AISI), 유한대판법(FSM) 수치해석 이론, 역공학 인벤토리 등 **불변의 엔지니어링 기술 기준점**을 영구 관리합니다.
  * 새로운 수식 분석이나 아키텍처 변경 사항은 `docs/` 내 해당 번호 문서에 실시간 동기화합니다.
* **`요구사항/` (개발 요구사항 및 태스크 관리)**:
  * 실제 기능 구현 단위, 스프린트 계획, 마일스톤, 개발 TODO 및 수용 기준(Acceptance Criteria)을 `요구사항/요구사항XX_[기능명].md` 형식으로 관리합니다.
  * 사용자가 "요구사항 문서 만들어줘" 등을 요청할 때는 별도의 Implementation Plan 아티팩트를 생성하지 않고 `요구사항/요구사항XX.md` 생성에 집중합니다.
* **Atomic Phase 분할**:
  * 범위가 넓은 작업은 3~4개의 독립 Phase로 분할하여 단계별 검증을 완료하며 진행합니다.
* **명시적 요청 시에만 아카이빙/커밋**:
  * `요구사항/@@OLD/` 아카이빙 및 Git 커밋/푸시는 사용자 명시적 요청 시에만 수행합니다.

### 3.5. 작업별 모델 활용 전략 (Model Tier Guidelines)
1. **High 모델 (Flash High / Pro)**: FSM 수치해석 행렬 분석, 비정형 CAD 메싱 알고리즘 역추적, KDS DSM 설계식 유도
2. **Medium 모델 (Flash Medium)**: 파이썬 모듈 구현, 단위 테스트 작성, 디컴파일/데이터 파싱
3. **Low 모델 (Flash Low / Lite)**: 단순 파일 조회, Git 커밋/푸시 명령 실행

---

## 4. 세부 기술 문서 및 인벤토리 맵 (Documentation References)

* 📑 **[프로젝트 구조 및 파일 인벤토리 명세 (SSOT)](../docs/프로젝트_구조_및_파일_인벤토리_명세.md)**: 108개 복원 C# 클래스 및 파일별 역할 상세 명세
* 📌 **[TODO 및 로드맵](../docs/00_todo_and_roadmap.md)**: AISI S100 복원 및 KDS 14 31 10 비교 로드맵
* 📐 **[전체 시스템 아키텍처](../docs/01_system_architecture.md)**: 전체 시스템 구조 및 5대 계층 흐름도
* 📏 **[CAD(DXF) 파싱 명세](../docs/02_cad_dxf_specification.md)**: 2D Polyline 규칙 및 `DXFPart` 메싱 알고리즘
* ⚙️ **[단면 기하학적 성질 계산서](../docs/03_section_properties.md)**: Gross/Effective 특성치($A, I, J, C_w, x_o, y_o$) 수식집
* 🔬 **[유한대판법(FSM) 해석 명세](../docs/04_finite_strip_method.md)**: $[K_e], [K_g]$ 강성행렬 및 좌굴 모드 판별 이론
* 🏛️ **[KDS / AISI 부재설계 기준서](../docs/05_kds_aisi_design_rules.md)**: 직접강도법(DSM) 공칭강도 수식집
* 🚀 **[Python 독립 엔진 개발 로드맵](../docs/06_python_engine_migration_plan.md)**: Python 포팅 전략 및 4대 계층 아키텍처 명세
* 🔗 **[KDS 국가건설기준 연동 가이드 (kcsc2md)](../../kcsc2md/docs/외부프로젝트_연동_및_조회_가이드.md)**: KDS 기준 Ground Truth 조회 표준

