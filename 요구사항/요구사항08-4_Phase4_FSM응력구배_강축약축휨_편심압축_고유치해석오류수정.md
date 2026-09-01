# [요구사항 08-4] Phase 4: FSM 좌굴해석 응력구배(강축/약축 휨, 편심압축) 고유치 해석 오류 수정 및 Mcr 수치 연동

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (`FiniteStripAnalysis`, `BuildKeKg`)
> **관련 파일**:
> - `src/solver/strip_assembler.py`
> - `src/solver/eigen_solver.py`
> - `src/solver/signature_curve.py`
> - `src/api/routes.py`
> - `src/web/static/js/app.js`
> - `src/web/static/js/chart_fsm.js`
> - `tests/engine/test_fsm_engine.py`

---

## 1. 구현 목표 (1이슈 단일 집중)

* **이슈 내용**: FSM 세부설정 모달에서 응력분포상태를 순수 축압축(`compression`) 외 강축 휨(`bending_x`), 약축 휨(`bending_y`), 편심압축으로 변경 시 수치해석 에러(고유치 역행렬/양의 정부호 불만족)로 오류 팝업 발생.
* **목표**:
  1. `strip_assembler.py`의 휨 응력 구배 하 기하강성행렬 $[K_g]$ 조립 안정화.
  2. `eigen_solver.py`의 일반 고유치 해석기에서 양의 실수 고유치 필터링 및 폴백 강화.
  3. 휨 모드 해석 시 탄성 좌굴 모멘트 $M_{crl}, M_{crd}, M_{cre}$ ($\text{kN}\cdot\text{m}$) 수치를 계산하여 시그니처 커브 및 UI 지표에 완벽 연동.
  4. 원본 C#(`FiniteStrip.cs`)의 휨 해석 결과와 0.1% 오차 미만의 동일성 검증.

---

## 2. 세부 개발 명세

1. **선형 응력 구배 하 $[K_g]$ 조립 안정화 (`strip_assembler.py`)**:
   - 강축 휨 ($M_y$): $\sigma(y) = F_y \cdot \frac{y - \bar{y}}{y_{max} - \bar{y}}$ (상단 압축 $+F_y$, 하단 인장 $-F_y$).
   - 약축 휨 ($M_x$): $\sigma(x) = F_y \cdot \frac{x - \bar{x}}{x_{max} - \bar{x}}$.
   - 편심 압축: $\sigma(x, y) = \frac{P}{A} + \frac{M_x y}{I_x} + \frac{M_y x}{I_y}$.
   - 인장 영역 스트립의 기하강성행렬 $[k_g]$ 기여분이 포함되어도 전역 $[K_g]$가 대칭 실수 행렬을 유지하도록 수치 안정화.
2. **일반 고유치 $[K_e]\Phi = \lambda [K_g]\Phi$ 해석기 고도화 (`eigen_solver.py`)**:
   - $[K_g]$가 부정부호(indefinite)인 상태에서도 `scipy.linalg.eig` 해석 후 허수부가 미소($|\Im(\lambda)| < 10^{-4}$)하고 실수부가 양수인 고유치($\Re(\lambda) > 10^{-4}$)를 정확히 추출.
   - 역행렬 폴백(`pinv(Ke) @ Kg`) 알고리즘에서 휨 모드의 최소 양의 고유치($LF_{min}$) 산출 보장.
3. **휨 탄성 좌굴 모멘트 $M_{cr}$ 계산 및 UI 연동 (`signature_curve.py`, `routes.py`, `app.js`)**:
   - $M_{cr} = LF \times M_y = LF \times (S_{xe} F_y)$ ($\text{kN}\cdot\text{m}$).
   - `bending_x` 또는 `bending_y` 모드 선택 시 시그니처 커브 Y축 및 요약 지표에 $M_{crl}, M_{crd}, M_{cre}$ ($\text{kN}\cdot\text{m}$) 단위 자동 전환 표시.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [x] **AC 4-1**: FSM 세부설정 모달에서 [강축 휨 (Major Bending X-X)] 선택 후 [재해석 실행] 시 오류 팝업 없이 시그니처 커브가 즉시 렌더링되는가?
- [x] **AC 4-2**: [약축 휨 (Minor Bending Y-Y)] 선택 후에도 고유치 발산 없이 안정적으로 곡선과 $M_{crl}, M_{crd}, M_{cre}$가 계산되는가?
- [x] **AC 4-3**: 휨 모드 시 UI 상단 배지에 "국부좌굴 $M_{crl}$", "왜곡좌굴 $M_{crd}$", "전역좌굴 $M_{cre}$" 지표가 $\text{kN}\cdot\text{m}$ 단위로 정상 표시되는가?
- [x] **AC 4-4**: `pytest tests/engine/test_fsm_engine.py` 테스트가 100% Pass 통과하는가?
