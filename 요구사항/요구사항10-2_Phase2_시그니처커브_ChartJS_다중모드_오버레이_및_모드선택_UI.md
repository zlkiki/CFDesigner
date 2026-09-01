# [요구사항 10-2] Phase 2: 시그니처 커브 Chart.js 다중 모드 오버레이 및 모드 선택 인터랙션

> **요구사항 번호**: `요구사항10-2`  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 2)`  
> **부모 요구사항**: [`요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md`](file:///d:/PyProject/CFDesigner/요구사항/요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md)  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (라인 1361~1415: `PlotLabels`, 다중 모드 곡선 라벨 및 반파장 마커)
> - [`src/web/static/js/chart_fsm.js`](file:///d:/PyProject/CFDesigner/src/web/static/js/chart_fsm.js)

---

## 1. 개요 및 목적

Chart.js 기반의 FSM 시그니처 커브 컴포넌트를 확장하여, Mode 1(기본), Mode 2(2차), Mode 3(3차) 곡선을 서로 다른 스타일(실선/대시선/점선)로 동시 표출하고, 범례(Legend) 토글 및 포인트 클릭 시 특정 모드를 선택하여 상단 2D/3D 뷰어와 연동할 수 있는 인터랙션을 구축합니다.

---

## 2. 세부 개발 범위

1. **Chart.js 다중 데이터셋(Datasets) 구성 (`src/web/static/js/chart_fsm.js`)**:
   - **Mode 1 (1차 모드)**: `#f97316` (오렌지) 또는 `#3b82f6` (블루) 실선, 두께 2.5px, 원형 포인트
   - **Mode 2 (2차 모드)**: `#10b981` (에메랄드/그린) 대시선 (`borderDash: [5, 5]`), 사각형 포인트
   - **Mode 3 (3차 모드)**: `#a855f7` (퍼플) 점선 (`borderDash: [2, 2]`), 삼각형/다이아몬드 포인트
   - 상단 범례(Legend) 클릭 시 각 모드별 곡선 표시/숨김 독립 제어.

2. **차트 클릭 및 툴팁 인터랙션 고도화**:
   - 사용자가 차트의 특정 반파장 지점을 클릭했을 때, 해당 반파장의 Mode 1, Mode 2, Mode 3 임계하중($P_{cr}$ 또는 $M_{cr}$)과 모드 분류를 툴팁/팝업에 동시 표시.
   - 클릭된 모드의 인덱스(Mode 1/2/3)를 전역 상태(`currentFsmModeIndex = 0, 1, 2`)로 설정하고 `render2DModeShape()` 및 `render3DModeWave()` 이벤트 브로드캐스트.

3. **시그니처 커브 상단 툴바 UI 보강 (`src/web/templates/index.html` 또는 관련 JS)**:
   - 시그니처 커브 카드 헤더에 `[모드 1]`, `[모드 2]`, `[모드 3]` 활성 상태 뱃지 및 현재 선택된 모드 강조 표시.

---

## 3. 수용 기준 (Acceptance Criteria)

- [ ] **AC 10-2-1**: FSM 해석 완료 후 시그니처 커브에 Mode 1, Mode 2, Mode 3의 3가지 곡선이 구별되는 스타일(실선/대시선/점선)로 동시 렌더링되어야 한다.
- [ ] **AC 10-2-2**: 범례를 클릭하여 각 모드 곡선을 개별적으로 On/Off 토글할 수 있어야 한다.
- [ ] **AC 10-2-3**: 차트의 데이터 포인트를 클릭했을 때 3개 모드의 정보가 표시되고, 선택된 모드가 2D/3D 뷰어 갱신 이벤트로 정상 전파되어야 한다.
