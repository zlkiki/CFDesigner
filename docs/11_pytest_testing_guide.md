# CFDesigner - Pytest 도메인별 3대 테스트 가이드 (11_pytest_testing_guide.md)

본 문서는 **CFDesigner (냉간성형강 구조해석 및 설계 시스템)**의 신속하고 무결한 검증을 위한 **3대 도메인별 Pytest 스위트 구조, 초고속 실행 명령 및 테스트 작성 규칙**을 정의합니다.

---

## 1. 3대 도메인 분리 목적 및 아키텍처

개발 작업 시 전체 77개 테스트를 매번 실행하는 오버헤드를 줄이고, **작업 중인 도메인에만 집중하여 0.5~2초 내에 즉각적인 피드백**을 얻을 수 있도록 테스트 스위트를 3대 영역으로 분리 운영합니다.

```text
tests/
├── engine/          # ⚙️ [도메인 1] 순수 공학/수치해석/설계식 엔진 검증 (18 tests)
│   ├── test_c_section.py                # C형강 단면성질, FSM 고유치, KDS DSM 내력 검증
│   ├── test_z_section.py                # Z형강 주축(Principal Axis) 회전 및 비대칭 성질 검증
│   ├── test_dxf_integration.py          # DXF 2D Polyline 수입 -> 중심선 메싱 -> 해석 파이프라인
│   ├── test_fsm_engine.py               # FSM 휨/편심 응력구배, Indefinite Kg 고유치, 폐구단면(Tube) 절점 공유
│   ├── test_phase3_advanced_design.py   # 웨브 크리플링, 퀵 디자인 최적화, Winter 유효폭
│   └── test_phase4_frame1d_analysis.py  # 1D 뼈대 연속보 유한요소 해석 및 SFD/BMD 다이어그램
│
├── ui/              # 💻 [도메인 2] 웹 UI 연동, API 엔드포인트 및 JSON 스키마 (22 tests)
│   ├── test_web_api.py                  # 메인 페이지, 마법사 API, FSM 해석/설계 API, 계산서 HTML
│   ├── test_quick_design.py             # CFS 원본 frmQuickDesign 3열 UI, 3대 D/C 한계상태 및 교차 검증
│   ├── test_report_generation.py        # 요약/상세 보고서, SVG 다이어그램, Jinja2 템플릿 디스패치
│   ├── test_phase1_geometry_edit.py     # 단면 스프레드시트 편집, 2D 회전/대칭 변환, 보강 리브 삽입
│   └── test_phase2_library_material.py  # SSMA 단면 라이브러리(1000+개), 재료 DB, 가공경화(Fya) 계산기
│
└── manual/          # 📖 [도메인 3] 온라인 도움말 시스템 및 정적 자산 무결성 (37 tests)
    └── test_manual_api.py               # 8대 카테고리 트리, 27개 토픽 한/영 원문 1:1 대칭성, KaTeX 수식, 도해 링크
```

---

## 2. 초고속 도메인별 실행 명령어 치트시트

| 개발 작업 도메인 | 추천 실행 명령 | 검증 대상 | 평균 소요 시간 |
|---|---|---|:---:|
| **엔진 / 공학 수식 작업** | `pytest tests/engine/` | 단면 특성치($A, I, J, C_w$), FSM 좌굴하중계수, KDS 공칭강도, 1D FEM | **~1.5초** |
| **웹 UI / API 라우트 작업** | `pytest tests/ui/` | FastAPI 엔드포인트, 퀵디자인 3대 D/C, 구조계산서 HTML, 기하 편집 | **~1.2초** |
| **온라인 도움말 / 문서 작업** | `pytest tests/manual/` | 한/영 8대 트리 구조, 27개 토픽 1:1 대칭, 도해 이미지, 수식($$) 렌더링 | **~1.2초** |
| **마스터 요구사항 완료 직전** | `pytest` | 전체 3대 영역 일괄 회귀 방지 통합 검증 (총 77 tests) | **~25초** |

### 마커(Marker) 기반 실행 옵션
`pytest.ini`에 사전 등록된 마커를 사용하여 실행할 수도 있습니다:
```bash
pytest -m engine    # 엔진 테스트만 실행
pytest -m ui        # UI/API 테스트만 실행
pytest -m manual    # 도움말 테스트만 실행
```

---

## 3. 도메인별 테스트 배치 및 작성 규칙

1. **엔진 테스트 (`tests/engine/`)**:
   - `RSG/CFS/` C# Ground Truth 계산치 대비 **오차 0.1% 미만 무결성**을 검증하는 단언문(`assert pytest.approx(expected, rel=1e-3)`)을 작성합니다.
   - 외부 UI나 HTTP 네트워크에 의존하지 않는 순수 Python 함수/클래스 단위 테스트로 작성합니다.

2. **웹 UI / API 테스트 (`tests/ui/`)**:
   - `fastapi.testclient.TestClient`를 사용하여 백엔드 라우터(`src/api/`)의 HTTP 상태 코드(200 OK) 및 JSON 응답 필드를 검증합니다.
   - 단면 편집, 회전, 대칭, SSMA 라이브러리 선택, 퀵디자인 탐색 등 사용자의 UI 액션에 대응하는 API 흐름을 검증합니다.

3. **온라인 도움말 테스트 (`tests/manual/`)**:
   - 8대 대분류 트리와 27개 개별 토픽의 한/영 대조(`content_ko`, `content_en`) 누락 여부를 검증합니다.
   - 본문에 포함된 도해 이미지(`/static/images/manual/...`)의 파일 시스템 실재 여부 및 LaTeX 수식(`$$...$$`)의 유효성을 검증합니다.
