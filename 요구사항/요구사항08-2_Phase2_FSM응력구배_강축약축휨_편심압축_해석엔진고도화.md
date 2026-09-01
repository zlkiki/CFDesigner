# [요구사항 08-2] Phase 2: FSM 응력구배(강축/약축 휨, 편심압축) 고유치 해석 고도화, 코너 곡선 표현 및 폐구단면/리브 3D 절점 거동 무결성 검증

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (`FiniteStripAnalysis`, `BuildKeKg`, `CoincidentNodes`)
> **관련 파일**:
> - `src/solver/strip_assembler.py`
> - `src/solver/eigen_solver.py`
> - `src/solver/signature_curve.py`
> - `src/api/routes.py`
> - `src/web/static/js/viewer_3d.js`
> - `src/web/static/js/canvas_2d.js`
> - `tests/engine/test_fsm_engine.py`

---

## 1. 구현 목표

1. FSM 좌굴해석 세부설정에서 응력분포를 **순수 축압축(`compression`) 외에 강축 휨(`bending_x`), 약축 휨(`bending_y`), 편심 압축(`combined`)**으로 변경했을 때 발생하는 오류를 근본적으로 수정.
2. 휨 모드 해석 시의 탄성 좌굴 모멘트 $M_{cr}$ 및 임계 반파장($L_{crl}, L_{crd}, L_{cre}$)을 수치해석적으로 무결하게 계산하여 시그니처 커브와 모달 요약 지표에 정상 반영.
3. **각 단면 접힌 부분(코너 Fillet R)의 곡선(Arc) 표현을 2D 및 3D 캔버스에 정확히 렌더링**.
4. **폐쇄형 단면(Tube)이나 리브가 추가된 면이 3D 해석 시 분리되지 않고 동일 절점의 경계조건을 공유하여 일체 거동**하는지 원본 C#(`FiniteStrip.cs`)과 100% 교차 검증 및 무결성 확보.

---

## 2. 세부 개발 명세

### 2.1 휨 응력 구배 하 기하강성행렬 $[K_g]$ 조립 안정화 (`strip_assembler.py`)
* **선형 응력 구배 수식 보정**:
  - 강축 휨 ($M_y$): $\sigma(y) = F_y \cdot \frac{y - \bar{y}}{y_{max} - \bar{y}}$ (상단 압축 $+F_y$, 하단 인장 $-F_y$).
  - 약축 휨 ($M_x$): $\sigma(x) = F_y \cdot \frac{x - \bar{x}}{x_{max} - \bar{x}}$.
  - 편심 압축: $\sigma(x, y) = \frac{P}{A} + \frac{M_x y}{I_x} + \frac{M_y x}{I_y}$.
* **스트립별 평균 응력 및 응력 구배 항 조립**:
  - 인장 영역 노드가 포함된 스트립의 경우 기하강성행렬 $[k_g]$의 부호가 음수가 되더라도 전역 $[K_g]$ 행렬이 대칭성을 유지하도록 조립식 정밀화.

### 2.2 비대칭/부정부호 $[K_g]$ 일반 고유치 해석기 고도화 (`eigen_solver.py`)
* **일반 고유치 $[K_e]\Phi = \lambda [K_g]\Phi$ 해석 안정화**:
  - $[K_g]$가 양의 정부호(positive definite)가 아닌 경우(휨/인장 복합 상태)에도 `scipy.linalg.eig` 해석 후 **양의 실수 고유치($\lambda > 10^{-4}$)**만을 정확히 필터링하고 최소 하중계수($LF_{min}$)를 안정적으로 추출.
  - 고유치 역행렬 폴백(`pinv(Ke) @ Kg`) 알고리즘을 휨 응력장에 최적화하여 수치 발산(`inf` 또는 `nan`) 방지.

### 2.3 단면 코너 곡선(Fillet R) 렌더링 (`canvas_2d.js`, `viewer_3d.js`)
* **2D 캔버스 코너 호 표현**:
  - 코너 요소에 대해 직선 대신 원호(`ctx.arc` 또는 베지어 곡선)를 사용하여 부드러운 코너 라운딩 렌더링.
* **3D 뷰어 코너 곡면 메싱**:
  - Three.js 3D 압출 메쉬 생성 시 코너 분할점들을 부드러운 곡면 노말로 연결하여 실제 절곡 판재의 굽힘 형상 시각화.

### 2.4 폐쇄형 단면(Tube) & 리브 면 절점 공유(Node Coincidence) 일체 거동 검증
* **절점 일치(Coincident Nodes) 결합 검증 (`strip_assembler.py`)**:
  - 사각파이프 등 폐구단면의 시작 노드와 끝 노드, 리브 연결 노드가 동일 좌표일 때 단일 자유도(Shared Node ID)로 완전 결합되는지 검증.
  - 3D 모드 형상 변위 벡터 추출 시 연결 노드의 자유도($u, v, w, \theta$)가 분리되지 않고 연속적으로 일체 거동함을 입증.
* **엔진 수정 시 원본 동일성 검증 의무**:
  - CFS 원본(`FiniteStrip.cs`)의 계산 결과와 대조하여 0.1% 오차 이내의 일치성을 확인.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [ ] **AC 2-1**: FSM 세부설정 모달에서 [강축 휨 (Major Bending X-X)] 선택 후 [재해석 실행] 시 오류 팝업 없이 시그니처 커브가 즉시 렌더링되는가?
- [ ] **AC 2-2**: [약축 휨 (Minor Bending Y-Y)] 선택 후에도 고유치 발산 없이 안정적으로 곡선과 $M_{crl}, M_{crd}, M_{cre}$가 계산되는가?
- [ ] **AC 2-3**: 2D 및 3D 캔버스에서 단면의 절곡 코너 부분이 각진 직선이 아닌 부드러운 곡선(호)으로 표현되는가?
- [ ] **AC 2-4**: 사각파이프(Tube) 및 리브 추가 단면의 3D 좌굴 모드 렌더링 시 면이 따로 떨어져 독립 거동하지 않고 일체로 연속 변형하는가?
- [ ] **AC 2-5**: `pytest tests/engine/test_fsm_engine.py` 테스트가 100% Pass 통과하는가?
