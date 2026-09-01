# [요구사항 10-1] Phase 1: FSM 수치해석 엔진 다중 고유치(Mode 1~3) 산정 확장 및 API 스키마 고도화

> **요구사항 번호**: `요구사항10-1`  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 1)`  
> **부모 요구사항**: [`요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md`](file:///d:/PyProject/CFDesigner/요구사항/요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md)  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (라인 750~850: `SturmSolve`/`Jacobi` 고유치 해석 루프 및 상위 모드 추출)
> - [`decompiled_src/RSG/Math/Sturm.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/Math/Sturm.cs) (다중 고유치 $\lambda_1, \lambda_2, \lambda_3$ 및 고유벡터 분리)
> - [`docs/04_finite_strip_method.md`](file:///f:/PyProject/CFDesigner/docs/04_finite_strip_method.md)

---

## 1. 개요 및 목적

반파장 $L_k$별 단일 최저 고유치 산출 방식에서 탈피하여, 고유방정식 $([K_e] - \lambda [K_g])\{\Delta\} = 0$으로부터 상위 3개 고유모드(Mode 1, Mode 2, Mode 3)의 고유치 $\lambda^{(m)}$와 정규화된 4-DOF 고유변위 벡터 $\{\Delta\}^{(m)} = [u, v, w, \theta]^T$를 동시 산정하고, 모드별 변형 에너지 및 임계하중($P_{cr}^{(m)}, M_{cr}^{(m)}$)을 API로 완전 제공합니다.

---

## 2. 세부 개발 범위

1. **FSM 수치해석 엔진 다중 고유치 추출 (`src/solver/fsm_engine.py`)**:
   - `FiniteStripEngine.solve_half_wavelength()` 내부에서 `scipy.linalg.eigh` 또는 일반화 고유치 풀이 시 `eigvals=(0, 2)` (또는 양수 최소 3개 고유치) 추출.
   - 고유치 $\lambda^{(1)} \le \lambda^{(2)} \le \lambda^{(3)}$ 오름차순 정렬 및 고유벡터 정규화.
   - 각 모드 $m \in \{1, 2, 3\}$에 대해:
     - 임계하중 $P_{cr}^{(m)} = \lambda^{(m)} P_{ref}$ 또는 $M_{cr}^{(m)} = \lambda^{(m)} M_{ref}$
     - 모드 형상 벡터 및 최대 절점 변위로 정규화된 변위 배열 생성 ($[u_i, v_i, w_i, \theta_i]$)
     - 스트립별 변형 에너지 기반 Work Ratio 및 버클링 모드 판별(Local / Distortional / Global).
   - 각 반파장별 `modes: [mode_1_dict, mode_2_dict, mode_3_dict]` 딕셔너리 구조 생성.

2. **API 엔드포인트 및 Pydantic 스키마 확장 (`src/api/routes/fsm.py` 또는 `src/api/server.py`)**:
   - `/api/fsm/solve` 응답에 `curve` (Mode 1 기본 시그니처 커브) 외에 `curves`: `{"mode_1": [...], "mode_2": [...], "mode_3": [...]}` 배열 제공.
   - 반파장별 세부 데이터에 `modes` 배열 포함하여 프론트엔드가 즉시 2D/3D 렌더링에 사용할 수 있도록 직렬화.

3. **엔진 단위 테스트 (`tests/engine/test_fsm_engine.py`)**:
   - 표준 C형강 및 Z형강에 대해 3대 고유치가 양수이고 오름차순($\lambda_1 \le \lambda_2 \le \lambda_3$)으로 산정되는지 검증.
   - 각 모드의 고유벡터가 영벡터가 아니며 4-DOF 성분을 모두 포함하는지 검증.

---

## 3. 수용 기준 (Acceptance Criteria)

- [ ] **AC 10-1-1**: `FiniteStripEngine.solve()` 실행 시 각 반파장 포인트마다 3개의 유효 고유치 및 모드별 변위 벡터가 산출되어야 한다.
- [ ] **AC 10-1-2**: 산출된 고유치는 $\lambda_1 \le \lambda_2 \le \lambda_3$ 관계를 엄격히 만족해야 한다.
- [ ] **AC 10-1-3**: `/api/fsm/solve` API 호출 시 `modes` 필드에 각 모드의 임계하중, work ratio, 절점 변위 목록이 JSON으로 정상 응답되어야 한다.
- [ ] **AC 10-1-4**: `pytest tests/engine/test_fsm_engine.py` 테스트가 100% 통과해야 한다.
