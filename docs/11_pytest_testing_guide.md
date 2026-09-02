# CFDesigner - Pytest 도메인별 3대 테스트 가이드 (11_pytest_testing_guide.md)

본 문서는 **CFDesigner (냉간성형강 구조해석 및 설계 시스템)**의 신속하고 무결한 검증을 위한 **수정 소스별 초고속 분할 시험 매핑 맵, 도메인별 Pytest 스위트 구조 및 실행 규칙**을 정의합니다.

---

## 1. 수정 소스별 0.1s~2s 초고속 타겟팅 실행 맵 (Fast Targeted Execution Matrix)

> 💡 **핵심 원칙**: 코드를 수정한 후 전체 113개 테스트(약 2분 소요)를 매번 돌리지 않고, **수정된 소스가 영향을 받는 타겟 테스트 파일 1~2개만 즉시 실행하여 0.1~3초 내에 검증**합니다.

| 내가 수정한 소스 코드 영역 | 타겟 실행 명령어 (`pytest ...`) | 검증 대상 및 내용 | 예상 소요 시간 |
|---|---|---|:---:|
| **프론트엔드 UI / JS 로직**<br>(`app.js`, `viewer_3d.js`, `canvas_2d.js`, `index.html`) | `pytest tests/ui/test_frontend_integrity.py` | HTML 247개 DOM ID 매칭, JS 클래스 메서드 실재(`TypeError` 방어), 이미지 링크 | **0.03초** |
| **KDS 부재설계 & 수식 Trace**<br>(`src/design/`, `kds_trace_engine.py`) | `pytest tests/engine/test_kds_trace_engine.py` | KDS 14 31 10 압축/휨/전단/조합응력 LaTeX 수식 및 수치 대입식 | **0.6초** |
| **1D 뼈대 유한요소 해석 (FEM)**<br>(`src/solver/frame1d.py`, `analysis_router.py`) | `pytest tests/engine/test_phase4_frame1d_analysis.py` | 단순보, 2경간 연속보, 캔틸레버 SFD/BMD/처짐/반력 이론해 일치성 | **0.5초** |
| **단면 편집, 변환 및 라이브러리**<br>(`src/geometry/`, `src/library/`) | `pytest tests/ui/test_phase1_geometry_edit.py tests/ui/test_phase2_library_material.py` | 스프레드시트 편집, 2D 회전/대칭/리브 삽입, SSMA DB, 가공경화($F_{ya}$) | **0.8초** |
| **FSM 좌굴 해석 엔진 알고리즘**<br>(`src/solver/strip_assembler.py`, `eigen_solver.py`) | `pytest tests/engine/test_fsm_engine.py` | FSM 순수압축, 강축/약축 휨 응력구배, Indefinite $[K_g]$, 폐구단면 절점공유 | **1.2초** |
| **CAD / DXF 수입 & 메싱 파이프라인**<br>(`src/cad/`, `part_mesher.py`) | `pytest tests/engine/test_dxf_integration.py` | 2D Polyline DXF 수입 $\rightarrow$ 중심선 메싱 $\rightarrow$ FSM $\rightarrow$ KDS 설계 | **1.5초** |
| **퀵디자인 최적화 탐색 엔진**<br>(`src/design/quick_design.py`, `frmQuickDesign`) | `pytest tests/ui/test_quick_design.py` | 3열 UI 컨트롤, 강도/처짐/지압 3대 D/C 한계상태 및 CFS 원본 교차검증 | **1.8초** |
| **FastAPI 백엔드 API 엔드포인트**<br>(`src/api/routers/`, Pydantic DTO) | `pytest tests/ui/test_api_contract_schema.py` | 마법사 5종, FSM solve/params 다중모드 스키마 대칭성, 부재검토 스키마 | **2.5초** |
| **다단계 사용자 상태 전이 & 워크플로우**<br>(단면변경 $\rightarrow$ 휨FSM $\rightarrow$ 도심정렬 $\rightarrow$ 계산서) | `pytest tests/ui/test_stateful_workflows.py` | 연속 조작 시 응력 상태(`load_type`) 지속 보존 및 E2E 데이터 파이프라인 | **3.0초** |
| **온라인 도움말 & 한/영 매뉴얼**<br>(`src/manual/`, `manual_routes.py`) | `pytest tests/manual/` | 8대 트리 구조, 27개 토픽 한/영 1:1 대칭, LaTeX 수식, 도해 이미지 실재 | **1.2초** |

---

## 2. 도메인 및 속도별 마커(Marker) 기반 실행 옵션

| 실행 목적 | 추천 명령어 | 포함 테스트 | 소요 시간 |
|---|---|---|:---:|
| **⚡ 일상 개발 초고속 회귀 검증**<br>(무거운 광대역 스윕 제외) | `pytest -m "not slow"` | 전체 98개 핵심 단위/통합 테스트 | **~40초** |
| **⚙️ 엔진 도메인 고속 검증** | `pytest tests/engine/ -m "not slow"` | 엔진 영역 17개 단위 테스트 | **~3초** |
| **💻 UI / API / 프론트엔드 검증** | `pytest tests/ui/` | 웹 API, 스키마, 상태전이, DOM Linter 44개 테스트 | **~15초** |
| **📖 온라인 도움말 전체 검증** | `pytest tests/manual/` | 27개 토픽 한영 원문 및 정적 자산 37개 테스트 | **~1.2초** |
| **🔬 릴리즈 직전 심층 광대역 수치 Sanity** | `pytest -m slow` | 5종 단면 $\times$ 3종 하중 $\times$ 30스텝 (450회 FSM 스윕) | **~88초** |
| **🏆 마스터 완료 직전 전수 회귀 테스트** | `pytest` | 전체 113개 테스트 전수 100% 무결성 검증 | **~125초** |

---

## 3. 고도화된 엄밀한 단언(Strict Assertions) 작성 규칙

1. **`assert > 0` 무조건적 금지**:
   - 단순 양수 체크 대신 물리적 기대 범위(`assert 0.1 <= val <= 1.05 * Fy * Ag`) 및 공학적 차원(Dimension)을 명시적으로 단언합니다.
2. **C# Ground Truth 0.1% 오차 검증 (`pytest.approx`)**:
   - 표준 단면(C, Z)에 대해 CFS.exe 원본 계산치와 신규 엔진 계산치를 `pytest.approx(expected, rel=1e-3)`로 검증합니다.
3. **API 완결형 스키마 검증**:
   - 최상위 키뿐만 아니라 서브필드, 노드/스트립 배열, 차트 포인트의 결측/Null 여부를 강제합니다.
4. **프론트엔드 정적 무결성 동기화**:
   - `index.html`의 ID 또는 JS 클래스 메서드를 변경할 때는 반드시 `pytest tests/ui/test_frontend_integrity.py`를 실행하여 0.03초 내에 정합성을 확인합니다.
