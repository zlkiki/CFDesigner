# [요구사항 07] 구조계산서(Report) 고도화 및 CFS 원본 리포트 전수 이식

> **문서 상태**: 🚀 **활성 진행 과제 (요구사항 07)**  
> **관련 기술 문서 (SSOT)**:
> - [`docs/06_python_engine_architecture_specification.md`](file:///f:/PyProject/CFDesigner/docs/06_python_engine_architecture_specification.md) (Python 독립 엔진 아키텍처)
> - [`docs/07_web_application_ui_ux_specification.md`](file:///f:/PyProject/CFDesigner/docs/07_web_application_ui_ux_specification.md) (웹 UI/UX 명세서)
> - [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md) (온라인 도움말 시스템 통합 명세서)
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs) (`rptHeading`, `rptSctInp`, `rptProperties`, `rptEffProperties`, `rptStrength`, `rptMemberCheck`, `rptTorsionProp`, `rptWebCrippling`, `rptDSMData`, `rptAnlInp`, `rptDiagrams` 등 2,090줄)
> - [`decompiled_src/RSG/CFS/PrintRoutines.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/PrintRoutines.cs) (`PrintReports`, `PrintBuckling`, `PrintDiagrams`, `PrintDiagEnv`, `PrintHeader`, `PrintFooter` 등 1,600줄)
> - [`decompiled_src/_Global/frmPrint.cs`](file:///f:/PyProject/CFDesigner/_Global/frmPrint.cs) (인쇄 항목 선택 다이얼로그)

---

## 1. 개요 및 배경

현재 CFDesigner의 구조계산서 출력 시스템(`src/report/html_report.py`)은 1페이지 분량의 간략 요약 수준으로 구성되어 있어 다음의 중대한 한계가 식별되었습니다:

1. **수록 내용의 심각한 부족 (공학적 근거 결여)**:
   - 요소별 상세 기하제원(길이, 각도, 곡률반경, 웨브유형), 재료 비선형 특성, 순단면(Net) 특성, 비틀림 뒴(Warping) 특성 수치($W_n, S_w, R_o$), Winter 유효폭 반복 계산 상세과정, 완전지지 강도 세부항목, 부재설계 상세 계산식(LTB, 왜곡, 국부, P-M 상호작용 세부항), 웨브 크리플링 계산 근거, FSM 임계 반파장 수치표 등이 대거 누락되어 실무 인허가 및 상세 구조검토용 계산서로 활용하기 어려움.
2. **CFS 원본 리포트 시스템과의 거대한 기능 격차 (Gap)**:
   - 원본 상용 프로그램(`CFS.exe`)은 `Report.cs`(2,090줄), `PrintRoutines.cs`(1,600줄) 및 `frmPrint.cs`를 통해 **14종 이상의 전문 구조계산서 섹션, 세부 수치 데이터 테이블, 중간 계산식 Trace 로그, 대형 단면도/좌굴모드도/해석다이어그램 인쇄**를 완벽히 지원함.
3. **리포트 포맷의 이원화 필요성**:
   - 기존의 1~2페이지 출력 양식은 **"간략 요약 보고서 (Summary / Quick Report)"**로 정립하고,
   - 실무 제출용 **"정식 상세 구조계산서 (Detailed Engineering Calculation Sheet)"** 체계를 신설하여 사용자가 필요한 항목을 선택 조합하여 출력할 수 있도록 구성해야 함.

---

## 2. CFS 원본 리포트 vs 웹 구현 1:1 전수 대조 매트릭스

| CFS 원본 리포트 모듈 | 원본 C# 함수 / 클래스 | 수록 주요 데이터 및 공학 수식 | 신규 웹 계산서 수록 목표 |
|---|---|---|---|
| **프로젝트 메타 & 헤더** | `Report.rptHeading`<br>`PrintRoutines.PrintHeader` | CFS 버전, 부재/해석 파일명, 프로젝트명, 설계자/검토자, 회사명, 로고, 개정일자, 연락처, 출력일시, 결재란 | **완전 구현** (표준 엔지니어링 결재란 및 프로젝트 정보 카드) |
| **단면 입력 제원** | `Report.rptSctInp` | 재료 물성($E, F_y, F_u$, 연신율, 가공경화, 비탄성예비), 파트 배치/원점, 요소별 전수 제원($L, \theta, R$, Web Coef, $k$, Hole, Dist), DSM 입력 파라미터 | **완전 구현** (재료 물성 카드 + 요소 전수 명세표 + DSM 파라미터) |
| **단면 특성치 (Gross/Net)** | `Report.rptProperties` | $A, W, \bar{x}, \bar{y}, I_x, I_y, I_{xy}, r_x, r_y, S_{xt}, S_{xb}, S_{yl}, S_{yr}$, 주축($\theta_p, I_1, I_2, r_1, r_2, S_1, S_2$), 비틀림($x_o, y_o, C_w, J, r_o, \beta_w, \beta_y$), Net 특성치($A_n, I_{xn}, I_{yn}, C_{wn}, J_n$) | **완전 구현** (총단면 + 주축 + 비틀림 + 순단면 4대 특성치 테이블) |
| **비틀림 & 뒴 특성** | `Report.rptTorsionProp` | 요소별 위치(Loc), 전단중심 거리($R_o$), 정규화 단위 뒴함수($W_n$), 뒴 단면 1차 모멘트($S_w$), Gross/Net $x_o, y_o, C_w, J$ | **완전 구현** (요소별 $R_o, W_n, S_w$ 수치표 및 비틀림 성질 설명) |
| **유효단면 성질** | `Report.rptEffProperties` | 주어진 $P, M_x, M_y$ 하에서의 $A_e, I_{xe}, I_{ye}, x_c, y_c, S_{xe}, S_{ye}$, 요소별 Winter 유효폭($f_1, f_2, \psi, k, w/t, \lambda, \rho, b_e, b_1, b_2$, 무효폭) | **완전 구현** (Winter 유효폭 반복 계산 상세 과정 및 요소별 $b_e$ 표) |
| **완전지지 부재강도** | `Report.rptStrength` | KDS/LRFD ($\phi P_{no}, \phi M_{nxo}, \phi M_{nyo}, \phi T_n, \phi V_n, \phi B_n$) 및 ASD ($P_{ao}, M_{axo}, M_{ayo}, T_a, V_a, B_a$), 정/부 휨 강도, 상세 Trace 로그 | **완전 구현** (완전지지 설계강도표 + 정/부 휨 비교 + 상세 계산 과정 Trace) |
| **KDS / AISI 부재설계** | `Report.rptMemberCheck` | 부재 비지지길이($K_x L_x, K_y L_y, K_t L_t, L_b$), $C_b, B_1, B_2$, 압축($P_{cre}, P_{crl}, P_{crd}, P_n, \phi P_n$), 휨($M_{cre}, M_{crl}, M_{crd}, M_n, \phi M_n$), 전단/인장/비틀림, P-M 상호작용식 세부 항 및 D/C Ratio | **완전 구현** (하중조건 + 세장비/비지지길이 + 압축/휨/전단 세부식 + P-M 검토) |
| **웨브 크리플링** | `Report.rptWebCrippling`<br>`Report.rptWebCripplingAnl` | 지지길이 $N$, 재하조건(EOF, ETF, IOF, ITF), 플랜지 부착, 단일/다중 웨브, 공칭 크리플링 강도 $P_n, \phi P_n$, 휨-크리플링 조합 검토식($\frac{M}{\phi M_n} + \frac{P}{\phi P_n} \le 1.3/1.5$) | **완전 구현** (웨브 크리플링 지지조건 + 내력 검토 + 모멘트 조합 검토) |
| **FSM 탄성좌굴 / DSM** | `Report.rptDSMData`<br>`PrintRoutines.PrintBuckling` | FSM 시그니처 커브 최소점(Local, Distortional, Global) 반파장 및 $P_{cr}/P_y, M_{cr}/M_y, V_{cr}/V_y$, 사전검증(Prequalified) 단면 판정 한계비 | **완전 구현** (시그니처 커브 최소치 일람표 + 사전검증 체크리스트 + 좌굴곡선 그래프) |
| **1D 구조해석 입력** | `Report.rptAnlInp` | 부재 방향(수직/수평), 지점 조건(경계조건, 스프링), 단면 지정, 하중 조건(P, w, M, T), 하중 조합 | **완전 구현** (1D 프레임/보 해석 입력 제원표) |
| **단면력 다이어그램** | `Report.rptDiagrams`<br>`Report.rptTorsionDiagrams` | 위치($Z$)별 단면력($M_x, M_y, V_x, V_y, P, T, B$) 및 변위($\delta_x, \delta_y, \theta$) 수치 데이터 테이블 | **완전 구현** (위치별 수치 일람표 및 BMD/SFD/비틀림 그래프) |
| **하중조합 포락선** | `Report.rptEnvelopes`<br>`Report.rptTorsionEnvelopes` | 하중조합에 대한 최대/최소 포락선(Envelope) 수치 테이블 | **완전 구현** (포락선 수치 데이터 테이블) |
| **해석기반 부재검토** | `Report.rptMemberCheckAnl` | 해석 모델 전체 구간(위치별) 부재 내력 검토 및 크리플링 검토 일람표 | **완전 구현** (전 구간 연속 검토 요약표) |
| **엔지니어링 그래픽** | `PrintRoutines.PrintArc`<br>`PrintRoutines.PrintDiag` | 대형 단면도(치수선, 두께, CG, SC, 주축), 좌굴 모드도(2D/3D 변형형상), 시그니처 커브 그래프, 단면력도 | **완전 구현** (고해상도 SVG 기반 단면도, FSM 커브, 좌굴 모드도, 단면력 다이어그램) |
| **인쇄 관리 다이얼로그** | `_Global/frmPrint.cs` | 출력 항목 다중 선택(`lstPrint`), 전체선택/해제(`cmdSelectAll`), 머리말 설정(`cmdHeading`), 인쇄 미리보기 | **완전 구현** (웹 모달 내 인쇄 항목 다중 선택, 보고서 모드 전환, 프로젝트 메타 입력) |

---

## 3. 핵심 요구사항 및 상세 규약

### 3.1 듀얼 리포트 모드 아키텍처 (Dual Report Mode)
1. **모드 1: 간략 요약 보고서 (Summary / Quick Report)**:
   - **용도**: 빠른 의사결정, 설계 화면 내 즉시 확인, 1~2페이지 분량의 핵심 결과 요약.
   - **구성**: 프로젝트 정보 $\rightarrow$ 단면 형상 SVG & 주요 특성치 $\rightarrow$ FSM 탄성 좌굴 요약 $\rightarrow$ KDS 부재 내력(D/C Ratio, OK/NG) 종합 판정.
2. **모드 2: 정식 상세 구조계산서 (Detailed Engineering Calculation Sheet)**:
   - **용도**: 관공서/인허가 제출, 구조기술사 심의, 세부 계산 근거 보존용 다중 페이지 정식 계산서.
   - **구성**:
     * **표지 / 프로젝트 결재란 (Cover & Approval Block)**: 프로젝트명, 구조물명, 작성자, 검토자, 책임기술사 서명란.
     * **제1장. 설계 개요 및 적용 기준 (General & Design Criteria)**: 적용 규준(KDS 14 31 10, AISI S100), 설계법(LRFD/ASD), 재료 물성($E, F_y, F_u$, 가공경화, 비선형 상수).
     * **제2장. 단면 기하 형상 및 요소 명세 (Section Geometry & Elements)**: 단면도(치수선, CG, SC, 주축), 파트 배치, 요소 전수 명세표($L, \theta, R, k$, Hole, Dist).
     * **제3장. 단면 특성치 계산서 (Section Properties Calculation)**: 총단면(Gross), 주축(Principal), 비틀림/뒴($W_n, S_w, C_w, J$), 순단면(Net) 특성치 일람표.
     * **제4장. 유효단면 성질 및 유효폭 해석 (Effective Properties & Winter Iteration)**: 하중 조건별 요소 유효폭 반복 계산표($f_1, f_2, \psi, k, w/t, \lambda, \rho, b_e$).
     * **제5장. 완전지지 부재 강도 (Fully Braced Strength)**: 단면 공칭/설계 강도($\phi P_{no}, \phi M_{nxo}, \phi M_{nyo}, \phi T_n, \phi V_n, \phi B_n$), 정/부 휨 비교, 상세 계산 Trace.
     * **제6장. FSM 유한대판 탄성 좌굴 해석 (Elastic Buckling & DSM Parameters)**: 반파장별 시그니처 커브 그래프, 국부/왜곡/전역 좌굴 특성치, 2D/3D 좌굴 모드 형상도, 사전검증 단면 체크리스트.
     * **제7장. KDS 14 31 10 / AISI 부재 내력 검토 (Member Design Capacity Checks)**: 세장비/비지지길이, 압축/휨/전단/인장/비틀림 상세 수식 대입 과정, P-M 상호작용 검토, 종합 판정.
     * **제8장. 웨브 크리플링 검토 (Web Crippling Check)**: 지지 조건, 크리플링 공칭/설계 강도, 휨-크리플링 조합응력 검토.
     * **제9장. 1D 구조해석 및 단면력 다이어그램 (1D Frame Analysis & Force Diagrams)** (해석 모델 활성화 시): 지점/하중 조건, 위치별 단면력 수치표, BMD/SFD/변위도, 포락선 데이터.

---

### 3.2 리포트 생성 및 인쇄 관리 UI/UX (`frmPrint` 모던 웹 구현)
1. **리포트 설정 및 출력 모달 (`reportModal`) 확장**:
   - **상단 툴바**:
     * 리포트 유형 토글: `[ 간략 요약 보고서 ]` / `[ 정식 상세 구조계산서 ]`
     * 프로젝트 정보 수정 버튼 (`프로젝트/결재란 설정`)
     * 출력 항목 선택 드롭다운/체크박스 패널 (`출력 항목 커스텀 선택`)
     * `🖨️ 인쇄 / PDF 저장` 버튼, `📥 HTML 다운로드` 버튼
2. **출력 항목 다중 선택 (Item Selector)**:
   - 원본 `frmPrint`의 기능 완벽 지원: [전체 선택], [전체 해제], [기본값 복원].
   - 체크박스 목록:
     * ☑️ 단면 기하도 및 요소 명세 (Section Geometry & Elements)
     * ☑️ 단면 기하학적 성질 (Gross / Net Properties)
     * ☑️ 비틀림 및 뒴 특성 (Torsion & Warping Properties)
     * ☑️ 유효 단면 특성치 (Effective Section Properties)
     * ☑️ 완전지지 단면 강도 (Fully Braced Strength)
     * ☑️ FSM 탄성 좌굴 및 시그니처 커브 (FSM Elastic Buckling)
     * ☑️ KDS 14 31 10 부재설계 검토 (Member Design Checks)
     * ☑️ 웨브 크리플링 검토 (Web Crippling Check)
     * ☑️ 1D 구조해석 결과 및 다이어그램 (1D Analysis & Diagrams)
3. **A4 인쇄 표준화 및 페이징 CSS 최적화**:
   - 표준 A4 Portrait 규격 (`@page { size: A4 portrait; margin: 15mm 15mm 15mm 15mm; }`).
   - 페이지 번호 자동 매김 (`Page X of Y`), 머리말/꼬리말 반복 인쇄.
   - 단락 및 테이블 분할 방지 (`page-break-inside: avoid;`).
   - 장(Chapter)별 페이지 나눔 (`page-break-before: always;`).

---

### 3.3 백엔드 리포트 생성 엔진 고도화 (`src/report/`)
1. **모듈 분리 및 구조화**:
   - `src/report/summary_report.py`: 간략 요약 보고서 생성기.
   - `src/report/detailed_report.py`: 정식 상세 구조계산서 생성기 (HTML + SVG + KaTeX).
   - `src/report/report_builder.py`: 리포트 데이터 모델 조합 및 섹션별 렌더링 파이프라인.
   - `src/report/svg_diagrams.py`: 고해상도 단면도, 주축도, 비틀림 도해, 좌굴 모드도, FSM 커브, 단면력도 SVG 생성기.
2. **수식 표기 및 공학 단위 무결성**:
   - 모든 공식은 KaTeX 표준 수식 및 국내 KDS 14 31 10 / AISI S100 표준 기호로 미려하게 렌더링.
   - SI 단위계($\text{mm}, \text{mm}^2, \text{mm}^4, \text{kN}, \text{kN}\cdot\text{m}, \text{MPa}$)를 엄격히 적용하고 유효숫자 표준 포맷팅 준수.

---

## 4. Phase별 단계적 세분화 및 개발 계획 (Scope Partitioning)

본 마스터 요구사항은 범위의 방대함과 무결성 검증을 위해 3대 Phase로 세분화하여 순차 구현됩니다:

| Phase | 세분화 문서명 | 주요 목표 및 개발 범위 | 상태 |
|---|---|---|:---:|
| **Phase 7-1** | [`요구사항07-1_Phase1_간략요약_및_상세계산서_선택UI_와_헤더설계.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07-1_Phase1_간략요약_및_상세계산서_선택UI_와_헤더설계.md) | 리포트 듀얼 모드 아키텍처, `frmPrint` 대응 인쇄 설정 모달 UI, 프로젝트/결재란 메타데이터 헤더, SVG 다이어그램 모듈화 | ✅ **완료 (Phase 1)** |
| **Phase 7-2** | [`요구사항07-2_Phase2_단면성질_유효단면_비틀림_강도상세계산서_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07-2_Phase2_단면성질_유효단면_비틀림_강도상세계산서_전수이식.md) | `rptSctInp`, `rptProperties`, `rptTorsionProp`, `rptEffProperties`, `rptStrength` 전수 이식 (요소 명세표, 비틀림 뒴 $W_n/S_w$, Winter 유효폭 반복계산표, 완전지지 강도) | ✅ **완료 (Phase 2)** |
| **Phase 7-3** | [`요구사항07-3_Phase3_FSM좌굴_KDS부재설계_웨브크리플링_1D해석계산서_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07-3_Phase3_FSM좌굴_KDS부재설계_웨브크리플링_1D해석계산서_전수이식.md) | `rptDSMData`, `rptMemberCheck`, `rptWebCrippling`, `rptAnlInp/Diagrams` 전수 이식 (FSM 시그니처 커브/좌굴도, KDS 상세 설계식 대입 과정, 크리플링 조합, 1D 해석 단면력표) 및 종합 검증 | ✅ **완료 (Phase 3)** |

---

## 5. Acceptance Criteria (마스터 종합 검증 기준)

- [x] **AC 7-1**: 리포트 모드가 **[간략 요약 보고서]**와 **[정식 상세 구조계산서]**로 완벽히 분리되어 동작할 것.
- [x] **AC 7-2**: 원본 `frmPrint.cs`에 대응하는 인쇄 설정 UI에서 출력 항목 다중 선택, 전체선택/해제, 프로젝트/결재란 정보 입력이 정상 작동할 것.
- [x] **AC 7-3**: 원본 `Report.cs`의 핵심 리포트 섹션 10종(`rptHeading`, `rptSctInp`, `rptProperties`, `rptTorsionProp`, `rptEffProperties`, `rptStrength`, `rptDSMData`, `rptMemberCheck`, `rptWebCrippling`, `rptDiagrams`)의 데이터와 서식이 누락 없이 계산서에 수록될 것.
- [x] **AC 7-4**: 요소별 전수 제원표, Winter 유효폭 반복 계산 상세표, 비틀림 뒴함수($W_n, S_w$) 표, KDS DSM 수식 대입 과정이 체계적인 엔지니어링 테이블 및 KaTeX 수식으로 렌더링될 것.
- [x] **AC 7-5**: 고해상도 SVG 단면도(치수선, CG, SC, 주축), FSM 시그니처 커브 그래프, 좌굴 모드도, 단면력도가 계산서 내에 선명하게 인쇄될 것.
- [x] **AC 7-6**: A4 규격(`@page`)에 맞추어 페이지 나눔(`page-break`), 머리말/꼬리말(페이지 번호 `Page X of Y`), 브라우저 인쇄(`window.print()`) 및 PDF 저장이 무결하게 작동할 것.
- [x] **AC 7-7**: `pytest tests/` 단위 및 통합 테스트가 100% 통과할 것.
