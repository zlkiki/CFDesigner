# [요구사항 08-5] Phase 5: 단면 코너(Fillet R) 곡선 렌더링 표현 및 폐구단면(Tube)/리브 3D 절점 공유 일체 거동 검증

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (`BuildKeKg`, `CoincidentNodes`, `DisplaceMesh`)
> **관련 파일**:
> - `src/web/static/js/canvas_2d.js`
> - `src/web/static/js/viewer_3d.js`
> - `src/solver/strip_assembler.py`
> - `src/api/routes.py`
> - `tests/engine/test_fsm_engine.py`

---

## 1. 구현 목표 (1이슈 단일 집중)

* **이슈 내용**:
  1. 2D/3D 그래픽 화면에서 단면의 접힌 부분(코너 곡선)이 둥근 곡선 없이 직선으로 각지게 표현됨.
  2. 폐쇄형 단면(사각파이프 Tube)이나 리브가 추가된 면이 3D 좌굴 시뮬레이션 시 다른 면과 연결되지 않고 혼자 독립적으로 떨어져서 거동하는 것처럼 보이는 현상 점검.
* **목표**:
  - 2D 및 3D 캔버스에서 절곡 코너 Fillet R을 부드러운 호(Arc) 곡면으로 정확히 렌더링.
  - `StripAssembler`의 절점 일치(Coincident Node) 결합 로직을 원본 C#(`FiniteStrip.cs`)과 전수 대조하여 폐구단면/리브 단면의 3D 일체 거동 무결성 입증.

---

## 2. 세부 개발 명세

1. **2D 캔버스 코너 호 렌더링 (`canvas_2d.js`)**:
   - `Element`가 원호(Arc) 요소(`radius > 0`)인 경우 직선 대신 `ctx.arc()` 또는 3점 베지어 곡선으로 중심선 및 판 두께(두께 옵셋)를 매끄러운 곡선으로 렌더링.
2. **3D 뷰어 절곡 코너 곡면 메싱 (`viewer_3d.js`)**:
   - 3D 단면 압출 지오메트리 생성 시 코너 분할점들에 대해 법선 벡터(Normal Vector)를 스무딩 처리하여 실제 냉간성형 롤포밍/프레스 절곡 단면의 둥근 코너 곡면 시각화.
3. **폐구단면(Tube) & 리브 면 3D 절점 공유(Node Coincidence) 검증 (`strip_assembler.py`, `viewer_3d.js`)**:
   - 사각파이프의 시작 노드와 끝 노드(좌표 동일점)가 단일 자유도(Shared Node ID)로 병합되어 경계조건을 공유하는지 확인.
   - Three.js 3D 모드 형상 변위 벡터 맵핑 시 노드 인덱스 매칭 오류를 교정하여 폐구단면의 각 판재가 모서리에서 벌어지지 않고 연속적으로 좌굴 변형하도록 조치.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [x] **AC 5-1**: 2D 단면도 화면에서 C형강/Z형강/사각파이프의 코너 접힌 부위가 직선이 아닌 부드러운 호(곡선)로 정확히 렌더링되는가?
- [x] **AC 5-2**: 3D 뷰어에서 단면의 절곡 코너가 각진 모서리가 아닌 둥근 곡면으로 표현되는가?
- [x] **AC 5-3**: 사각파이프(Tube) 및 보강 리브 단면의 3D 좌굴모드 시뮬레이션 시 면이 떨어져 독립 거동하지 않고 모든 모서리 연결부에서 절점을 공유하여 일체로 연속 변형하는가?
- [x] **AC 5-4**: `pytest tests/engine/test_fsm_engine.py` 테스트가 100% Pass 통과하는가?
