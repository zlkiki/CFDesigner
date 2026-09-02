# [요구사항 10] FSM 다중 버클링 모드(Higher Modes) 수치해석 엔진 확장, 2D Hermite 3차 곡선 변형 도해(도해3) 및 3D 사인파 파형(도해4) 심층 구현, 시그니처 커브 다중 모드 오버레이

> **요구사항 번호**: `요구사항10`  
> **상태**: 🚀 `계획 완료 및 대기 (Active Master)`  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (라인 750~850: `SturmSolve`/`Jacobi` 고유치 해석, 라인 1416~1605: `PlotModeShape` Hermite 3차 보간 및 240분할 파형 렌더링, 라인 1361~1415: `PlotLabels`)
> - [`decompiled_src/RSG/Math/Sturm.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/Math/Sturm.cs) (다중 고유치 $\lambda_1, \lambda_2, \dots, \lambda_m$ 및 고유벡터 배열 $Y1$)
> - [`docs/04_finite_strip_method.md`](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md) (유한대판법 FSM 이론 및 형상함수)

---

## 1. 배경 및 추진 목적

기존 상용 CFS 프로그램 및 이론적 유한대판법(FSM)에서는 특정 반파장($L$)에서 최저차수(1차) 버클링 하중뿐만 아니라 **2차, 3차 등의 고차 버클링 모드(Higher Eigenvalue Modes: Mode 1, Mode 2, Mode 3...)**가 물리적으로 존재하며, 대칭/반대칭 모드나 복합 변형 거동을 정밀하게 분석하기 위해 다중 모드 해석 및 시각화가 필수적입니다.

또한 원본 C# [`FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs)의 `PlotModeShape` 구현을 정밀 역추적한 결과:
1. **도해 3 (2D 단면 변형 모드)**: 각 스트립 요소의 절점 변위($(u_i, v_i, w_i, \theta_i), (u_j, v_j, w_j, \theta_j)$)뿐만 아니라 **3차 에르미트 보간(Hermite Cubic Interpolation)**을 적용하여 요소 내부의 면외 처짐 곡선을 부드러운 3차 곡선으로 엄밀하게 렌더링하고 있음.
2. **도해 4 (3D 길이방향 사인파 렌더링)**: $z$축 방향으로 $\sin(\pi z / L)$ 파형 투영 및 240분할 원근/음영(Shading)을 적용하여 깊이감 있는 3D 파형을 구현하고 있음.
3. **다중 모드 스펙트럼(Multiple Modes Signature Curve)**: Mode 1뿐만 아니라 Mode 2, Mode 3의 시그니처 커브를 동시 플롯하여 고차 모드 분기점을 분석할 수 있음.

이에 따라 **CFDesigner의 FSM 엔진, 2D 캔버스, Three.js 3D 뷰어, 시그니처 차트, 구조계산서 및 온라인 매뉴얼**에 걸쳐 다중 버클링 모드 수치해석 및 심층 도해 렌더링 시스템을 완성합니다.

---

## 2. 세부 구현 요구사항 (5대 영역)

### 2.1 FSM 수치해석 엔진 다중 고유치(Mode 1~3+) 산정 확장 (`src/solver/fsm_engine.py`)
1. **다중 고유치 및 고유모드 벡터 동시 산출**:
   - `FiniteStripEngine.solve()`에서 각 반파장($L_k$)별로 최저 고유치 1개만 저장하던 구조를 개선하여, 상위 **$M$개(기본 3개: Mode 1, Mode 2, Mode 3)**의 고유치($\lambda^{(m)}$) 및 정규화된 고유벡터($\{\Delta\}^{(m)} = [u, v, w, \theta]^T$)를 산정하여 반환.
   - 고유치 순서대로 오름차순 정렬($\lambda^{(1)} \le \lambda^{(2)} \le \lambda^{(3)}$) 보장.
2. **모드별 단면 변형 에너지 및 Work Ratio 산정**:
   - 각 고유모드($m=1, 2, 3$)에 대해 로컬/디스토셔널/글로벌 판별을 위한 Work Ratio 및 모드형상 분류(Classification)를 독립 산정.
3. **API 응답 스키마 확장 (`src/web/app.py`)**:
   - `/api/fsm/solve` 응답의 `modes` 필드에 각 반파장별 `[mode_1, mode_2, mode_3]` 배열 및 모드별 `eigenvalue, P_cr, M_cr, work_ratio, displacements` 구조 제공.

---

### 2.2 시그니처 커브(Signature Curve) 다중 모드 오버레이 & 인터랙션 (`src/web/static/js/chart_fsm.js`)
1. **다중 모드 곡선(Mode 1, Mode 2, Mode 3) 동시 플롯**:
   - **Mode 1**: 주황색/파란색 실선 (Primary Mode Curve)
   - **Mode 2**: 녹색/청록색 대시선 (2nd Mode Curve, `borderDash: [5, 5]`)
   - **Mode 3**: 보라색 점선 (3rd Mode Curve, `borderDash: [2, 2]`)
   - 차트 범례(Legend) 클릭으로 모드별 On/Off 토글 지원.
2. **모드 선택 클릭 인터랙션**:
   - 특정 반파장 포인트 클릭 시, 해당 반파장에서 Mode 1 / Mode 2 / Mode 3 중 원하는 모드를 선택할 수 있는 팝업 또는 툴팁 제공.
   - 선택된 모드의 형상이 상단 2D/3D 뷰어에 즉시 연동.

---

### 2.3 2D 단면 변형 도해(도해 3) Hermite 3차 곡선 정밀 이식 (`src/web/static/js/canvas_2d.js`)
1. **원본 CFS 14.0 Hermite 3차 보간 공식 1:1 완벽 이식**:
   - 원본 [`FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs)의 `PlotModeShape` 수식에 따라, 스트립 요소 $i \rightarrow j$의 변위 $w_i, w_j$ 및 회전각 $\theta_i, \theta_j$, 스트립 폭 $b$로부터 3차 다항식 계수 산정:
     $$\Delta(s) = a_0 + a_1 s + a_2 s^2 + a_3 s^3 \quad (0 \le s \le b)$$
   - 각 스트립 요소를 10~20개 서브 세그먼트로 세분화하여 부드러운 3차 휨 변형 곡선 렌더링.
2. **초기 단면(회색) vs 변형 단면(모드별 색상) 듀얼 오버레이**:
   - 변형 전 원단면(연회색 점선/실선)과 변형 후 단면(선택 모드별 강조선)을 겹쳐서 변위 양상을 명확히 시각화.
3. **2D 뷰어 내 모드 스위처(Mode 1 / Mode 2 / Mode 3) UI 버튼군 제공**:
   - 2D 캔버스 툴바에 `[Mode 1]`, `[Mode 2]`, `[Mode 3]` 토글 탭 추가.

---

### 2.4 Three.js 3D 뷰어(도해 4) 다중 모드 파형 & 셰이딩 고도화 (`src/web/static/js/viewer_3d.js`)
1. **다중 모드 3D 파형 메쉬 렌더링**:
   - 선택된 모드(Mode 1, Mode 2, Mode 3)의 고유벡터를 반영하여 $z$축 방향 $\sin(\pi z / L)$ 파형 메쉬 생성.
2. **길이방향 파형 분할 및 원근 셰이딩(Depth Shading) 강화**:
   - 원본 C#의 240분할 파형 투영과 부합하는 고품질 Three.js 지오메트리 및 음영 처리.
3. **3D 상단 정보창 다중 모드 라벨 연동**:
   - 상단 오버레이 정보창에 현재 표출 중인 모드 번호(`Mode 1 (Local)`, `Mode 2 (Distortional)`, etc.) 명시.

---

### 2.5 온라인 도움말, 구조계산서 및 테스트 동기화
1. **온라인 도움말 5-2 (`buckling_modes`) 및 5-3 (`signature_curve`) 고도화**:
   - 다중 고유치 버클링 모드의 물리적 의미, Hermite 3차 보간 이론 및 다중 모드 시그니처 커브 해석법 상세 수록 (한·영 1:1 완비).
2. **구조계산서 다중 모드 수치 및 SVG 다이어그램 반영 (`html_report.py`)**:
   - 상세 보고서 6장(FSM 해석)에 Mode 1~3의 임계하중 요약표 및 2D 변형 형상 도해 수록.
3. **단위 및 통합 테스트 (`tests/engine/`, `tests/ui/`, `tests/manual/`)**:
   - 다중 모드 고유치 정렬 및 직교성 테스트, API 엔드포인트 응답 검증, 2D/3D 모드 전환 테스트 작성.

---

## 3. 하위 작업 분할 (Scope Partitioning 제안)

작업의 무결성과 단계별 검증을 위해 아래와 같이 4개 하위 Phase로 분할하여 순차 진행을 권장합니다:

| Phase | 세부 작업 내용 | 주요 파일 | 검증 기준 |
|---|---|---|---|
| **Phase 10-1** | FSM 엔진 다중 고유치(Mode 1~3) 산정 및 API 스키마 확장 | `fsm_engine.py`, `app.py` | `pytest tests/engine/` (다중 고유치 정렬 및 고유벡터 검증) |
| **Phase 10-2** | 시그니처 커브 Chart.js 다중 모드 곡선 오버레이 및 모드 선택 UI | `chart_fsm.js`, `index.html` | UI 다중 모드 라인 렌더링 및 클릭 인터랙션 검증 |
| **Phase 10-3** | 2D 단면 변형(도해3) Hermite 3차 보간 곡선 & 3D 뷰어 다중 모드 연동 | `canvas_2d.js`, `viewer_3d.js` | 2D Hermite 곡선 및 3D 다중 모드 파형 전환 검증 |
| **Phase 10-4** | 구조계산서 다중 모드 수록, 온라인 도움말 동기화 및 전수 회귀 테스트 | `html_report.py`, `topics.py` | `pytest` 전체 80+개 테스트 100% 통과 |

---

## 4. 수용 기준 (Acceptance Criteria)

1. [ ] **AC 10-1**: FSM 엔진이 각 반파장($L$)별로 Mode 1, Mode 2, Mode 3의 3대 고유치 및 고유벡터를 오름차순으로 정확히 산출해야 한다.
2. [ ] **AC 10-2**: 시그니처 커브 차트에 Mode 1(실선), Mode 2(대시선), Mode 3(점선)이 동시에 표출되고 범례로 개별 토글이 가능해야 한다.
3. [ ] **AC 10-3**: 2D 캔버스 변형 모드(도해 3)에서 원본 CFS와 동일한 Hermite 3차 다항식 보간으로 요소 내부의 곡선 처짐이 매끄럽게 렌더링되어야 한다.
4. [ ] **AC 10-4**: 2D/3D 뷰어에서 Mode 1 / Mode 2 / Mode 3 스위처 버튼을 클릭하여 각 고유모드의 형상으로 즉시 전환 렌더링되어야 한다.
5. [ ] **AC 10-5**: 온라인 도움말 및 상세 구조계산서에 다중 버클링 모드 해석 이론 및 모드별 수치/도해가 완벽히 동기화되어야 한다.
6. [ ] **AC 10-6**: 전체 pytest 테스트 스위트가 오류 없이 100% 통과해야 한다.
