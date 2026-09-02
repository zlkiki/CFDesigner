# 요구사항 14-1: [Phase 1] API 계약(Contract) 및 Pydantic 완결형 스키마 전수 검증

## 1. 목적 및 범위
FastAPI 백엔드가 반환하는 모든 JSON 응답이 프론트엔드 UI 컴포넌트(`app.js`, `chart_fsm.js`, `canvas_2d.js`, `viewer_3d.js`)가 요구하는 필수 데이터 구조 및 필드 명칭을 100% 만족하는지 엄격히 검증하여, 응답 서브필드 결측으로 인한 프론트엔드 렌더링 중단을 원천 차단합니다.

---

## 2. 세부 구현 요구사항

### 2.1 신규 테스트 파일 작성 (`tests/ui/test_api_contract_schema.py`)
1. **`/api/section/wizard` 전 단면 스키마 완전성 검증**:
   - 단면 형태: `C`, `Z`, `Hat`, `Tube`, `Channel` 5종 전수 테스트.
   - 응답 스키마 필수 필드 검증:
     - `geometry`: `elements` (각 element 내 `id`, `x1`, `y1`, `x2`, `y2`, `t`), `thickness`, `total_length`
     - `properties`: `area`, `ix`, `iy`, `rx`, `ry`, `cw`, `j`, `xcg`, `ycg`, `x0`, `y0`, `sx_top`, `sx_bot`, `sy_left`, `sy_right`
   - 단 하나의 필드라도 `None`이거나 누락 시 즉각 Fail.

2. **`/api/fsm/solve` vs `/api/fsm/parameters` 100% 스키마 대칭성 검증**:
   - 두 엔드포인트의 응답 데이터셋이 동일한 다중 모드 및 3D 렌더링 필드를 보유하고 있는지 교차 검증:
     - `curves`: `mode_1`, `mode_2`, `mode_3` (각 모드별 `lengths`, `lfs`, `pcrs`/`mcrs`)
     - `signature_curve`: 각 포인트마다 `mode_lfs`, `mode_pcrs`, `mode_mcrs`, `eigenvectors` 보유 여부
     - `critical_modes`: `p_crl`, `l_local`, `p_crd`, `l_distortional`, `p_cre`, `l_global`
     - `nodes`: 각 노드별 `node_id`, `x`, `y`, `stress`
     - `strips`: 각 스트립별 `strip_id`, `node_i`, `node_j`, `thickness`

3. **`/api/design/check` KDS DSM 부재검토 스키마 검증**:
   - `compression`: `p_n`, `phi_pn`, `dc_ratio`, `status`, `governing_mode`, `p_ne`, `p_nl`, `p_nd`
   - `flexure`: `m_n`, `phi_mn`, `dc_ratio`, `status`, `governing_mode`, `m_ne`, `m_nl`, `m_nd`
   - `shear`: `v_n`, `phi_vn`, `dc_ratio`, `status`
   - `interaction`: `ratio`, `status`, `formula_type`

4. **`/api/report/html` 및 `/api/design/quick-design` 스키마 검증**:
   - 계산서 HTML 응답 내 KaTeX 수식(`katex.min.css`, `\phi P_n`), SVG 단면 다이어그램 태그 존재 검증.
   - 퀵디자인 응답 내 `candidates` 배열의 각 후보가 `rank`, `name`, `weight`, `dc_strength`, `dc_deflection`, `dc_crippling`, `max_dc`, `elements`를 완비하고 있는지 검증.

---

## 3. 검증 기준 (Acceptance Criteria)

- [x] **AC 14-1-1**: `tests/ui/test_api_contract_schema.py`가 생성되고, 5대 주요 API 엔드포인트에 대한 완결형 스키마 검증 테스트가 작성될 것.
- [x] **AC 14-1-2**: 단면 마법사 5종(C, Z, Hat, Tube, Channel)의 기하학적 성질 및 요소 데이터가 결측 없이 검증될 것.
- [x] **AC 14-1-3**: `/api/fsm/solve`와 `/api/fsm/parameters` 간의 다중 모드 및 3D 절점 데이터 스키마가 100% 일치함을 보증할 것.
- [x] **AC 14-1-4**: `pytest tests/ui/test_api_contract_schema.py` 실행 시 100% Pass할 것.
