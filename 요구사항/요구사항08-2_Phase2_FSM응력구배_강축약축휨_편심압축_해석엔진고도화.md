# [요구사항 08-2] Phase 2: FSM 응력구배(강축/약축 휨, 편심압축) 고유치 해석 엔진 고도화 및 오류 수정

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **관련 파일**:
> - `src/solver/strip_assembler.py`
> - `src/solver/eigen_solver.py`
> - `src/solver/signature_curve.py`
> - `src/api/routes.py`
> - `src/web/static/js/app.js`
> - `src/web/static/js/chart_fsm.js`
> - `tests/engine/test_fsm_engine.py`

---

## 1. 구현 목표

1. FSM 좌굴해석 세부설정에서 응력분포를 **순수 축압축(`compression`) 외에 강축 휨(`bending_x`), 약축 휨(`bending_y`), 편심 압축(`combined`)**으로 변경했을 때 발생하는 오류를 근본적으로 수정.
2. 휨 모드 해석 시의 탄성 좌굴 모멘트 $M_{cr}$ 및 임계 반파장($L_{crl}, L_{crd}, L_{cre}$)을 수치해석적으로 무결하게 계산하여 시그니처 커브와 모달 요약 지표에 정상 반영.

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

### 2.3 휨 좌굴 모멘트 $M_{cr}$ 및 프론트엔드 연동 (`signature_curve.py`, `routes.py`, `app.js`)
* **임계 좌굴치 환산**:
  - 압축 모드: $P_{cr} = LF \times P_y = LF \times (A_g F_y)$ ($\text{kN}$)
  - 휨 모드: $M_{cr} = LF \times M_y = LF \times (S_{xe} F_y)$ ($\text{kN}\cdot\text{m}$)
* **API 및 UI 렌더링**:
  - `/api/fsm/parameters` 응답에 `stress_type`이 `bending_x` 또는 `bending_y`일 때 $M_{crl}, M_{crd}, M_{cre}$ 수치를 함께 반환.
  - UI 상단 배지에 "국부좌굴 $M_{crl}$", "왜곡좌굴 $M_{crd}$", "전역좌굴 $M_{cre}$" 단위를 $\text{kN}\cdot\text{m}$로 자동 전환 렌더링.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [ ] **AC 2-1**: FSM 세부설정 모달에서 [강축 휨 (Major Bending X-X)] 선택 후 [재해석 실행] 시 오류 팝업 없이 시그니처 커브가 즉시 렌더링되는가?
- [ ] **AC 2-2**: [약축 휨 (Minor Bending Y-Y)] 선택 후에도 고유치 발산 없이 안정적으로 곡선과 $M_{crl}, M_{crd}, M_{cre}$가 계산되는가?
- [ ] **AC 2-3**: `pytest tests/engine/test_fsm_engine.py` 테스트에서 휨 응력 구배 조건 테스트 케이스가 100% 통과하는가?
