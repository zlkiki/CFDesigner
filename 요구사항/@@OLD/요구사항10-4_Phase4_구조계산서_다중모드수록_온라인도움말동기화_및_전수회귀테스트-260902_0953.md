# [요구사항 10-4] Phase 4: 구조계산서 다중 모드 수록, 온라인 도움말 동기화 및 전수 회귀 테스트

> **요구사항 번호**: `요구사항10-4`  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 4)`  
> **부모 요구사항**: [`요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md`](file:///d:/PyProject/CFDesigner/요구사항/요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md)  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)
> - [`src/web/routes/manual_topics/`](file:///f:/PyProject/CFDesigner/src/web/routes/manual_topics/)
> - [`src/report/html_report.py`](file:///f:/PyProject/CFDesigner/src/report/html_report.py)

---

## 1. 개요 및 목적

FSM 다중 모드 수치해석 및 Hermite 3차 도해 기능 추가에 맞춰, 구조계산서(HTML/인쇄) 내 FSM 해석 장(Chapter 6)에 Mode 1~3의 임계하중 요약표 및 2D Hermite 변형 형상 다이어그램을 반영하고, 온라인 도움말의 버클링 모드 및 시그니처 커브 토픽(한·영 대칭)을 고도화한 후 전체 테스트 스위트 회귀 검증을 완수합니다.

---

## 2. 세부 개발 범위

1. **구조계산서 다중 모드 요약표 및 SVG 다이어그램 반영 (`src/report/html_report.py`, `src/report/svg_charts.py`)**:
   - 상세 리포트 6장(유한대판법 탄성 좌굴해석)에 각 임계 반파장별 Mode 1, Mode 2, Mode 3의 임계하중($P_{cr}$/$M_{cr}$) 및 모드 분류 비교표 추가.
   - 2D SVG 단면 변형 다이어그램 생성 시 Hermite 3차 보간 Path를 적용하여 고품질 인쇄 벡터 출력.

2. **온라인 도움말 한·영 대칭 동기화 (`src/web/routes/manual_topics/` 또는 `src/manual/`)**:
   - `buckling_modes` (5-2 좌굴 모드 판별 및 고차 모드 이론) 토픽 갱신: 고차 모드(Higher Modes)의 물리적 거동 및 Hermite 3차 다항식 보간 이론 수록 (한/영 완비).
   - `signature_curve` (5-3 시그니처 커브 해석 및 다중 모드 곡선) 토픽 갱신: Mode 1/2/3 다중 커브 해석법 및 교차점 분석 가이드 보강.

3. **도메인별 3대 테스트 및 전수 회귀 테스트 작성**:
   - `tests/engine/test_fsm_engine.py`: 다중 고유치 및 에너지 비율 검증.
   - `tests/ui/test_fsm_ui.py` 또는 관련 UI 테스트: 다중 모드 API 응답 및 렌더링 파라미터 검증.
   - `tests/manual/test_manual_api.py`: 27개 토픽 한/영 이중언어 무결성 재검증.
   - `pytest`: 전체 80+개 테스트 100% 통과 입증.

---

## 3. 수용 기준 (Acceptance Criteria)

- [ ] **AC 10-4-1**: 상세 구조계산서에 FSM Mode 1~3 임계하중 비교표 및 Hermite 3차 곡선 SVG 다이어그램이 정상 렌더링되어야 한다.
- [ ] **AC 10-4-2**: 온라인 도움말 5-2, 5-3 토픽에 다중 고유치 및 Hermite 3차 보간 이론이 한·영 완벽 대칭으로 반영되어야 한다.
- [ ] **AC 10-4-3**: `pytest` 실행 시 모든 도메인(엔진/도움말/UI) 테스트가 100% 통과(Pass)해야 한다.
