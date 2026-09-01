# [요구사항 10-3] Phase 3: 2D 단면 변형(도해3) Hermite 3차 보간 곡선 & 3D 뷰어(도해4) 다중 모드 파형 연동

> **요구사항 번호**: `요구사항10-3`  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 3)`  
> **부모 요구사항**: [`요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md`](file:///d:/PyProject/CFDesigner/요구사항/요구사항10_FSM다중버클링모드_도해심층구현_Hermite3차곡선_고차모드시각화.md)  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs) (라인 1416~1605: `PlotModeShape`, Hermite 3차 보간 곡선 공식 및 240분할 3D 와이어프레임 투영)
> - [`src/web/static/js/canvas_2d.js`](file:///d:/PyProject/CFDesigner/src/web/static/js/canvas_2d.js)
> - [`src/web/static/js/viewer_3d.js`](file:///d:/PyProject/CFDesigner/src/web/static/js/viewer_3d.js)

---

## 1. 개요 및 목적

원본 CFS C# 구현의 핵심 시각화 알고리즘인 **Hermite 3차 보간(Cubic Hermite Interpolation)**을 2D 캔버스에 100% 이식하여 스트립 요소 내부의 면외 휨 변형을 부드러운 3차 곡선(도해 3)으로 렌더링하고, 3D 뷰어(도해 4)에서는 선택된 다중 모드(Mode 1, Mode 2, Mode 3)의 파형 및 셰이딩을 동적으로 전환하는 심층 시각화 파이프라인을 완성합니다.

---

## 2. 세부 개발 범위

1. **2D 캔버스 Hermite 3차 곡선 보간 구현 (`src/web/static/js/canvas_2d.js`)**:
   - 원본 C# [`FiniteStrip.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/FiniteStrip.cs)의 `PlotModeShape` 수식 엄밀 적용:
     - 각 스트립 요소 $e(i \rightarrow j)$에 대해 길이 $b$, 양단 절점 변위 $(u_i, w_i, \theta_i), (u_j, w_j, \theta_j)$ 획득.
     - 면내 변위 선형 보간: $u(s) = (1 - s/b) u_i + (s/b) u_j$
     - 면외 변위 Hermite 3차 보간:
       $$w(s) = (1 - 3\xi^2 + 2\xi^3) w_i + (\xi - 2\xi^2 + \xi^3) b \theta_i + (3\xi^2 - 2\xi^3) w_j + (-\xi^2 + \xi^3) b \theta_j \quad (\xi = s/b)$$
     - 스트립당 $N_{sub} = 10 \sim 20$개 세그먼트로 분할하여 캔버스 Path 연결.
   - 변형 전 원단면(연회색)과 변형 후 모드 단면(모드별 강조 색상) 듀얼 오버레이 렌더링.
   - 2D 캔버스 상단에 `[Mode 1]`, `[Mode 2]`, `[Mode 3]` 토글 탭 버튼 배치 및 즉시 전환.

2. **Three.js 3D 뷰어 다중 모드 파형 렌더링 (`src/web/static/js/viewer_3d.js`)**:
   - 현재 선택된 모드($m=1, 2, 3$)의 변위 벡터를 3D 파형 메쉬($z$축 방향 $\sin(\pi z / L)$)에 반영.
   - 모드 전환 시 부드러운 애니메이션 트랜지션 또는 즉각적인 메쉬 지오메트리 갱신.
   - 상단 오버레이 HUD에 현재 표시 모드 번호 및 하중비(`Mode 2 (Distortional): P_cr = 145.2 kN`) 표출.

---

## 3. 수용 기준 (Acceptance Criteria)

- [ ] **AC 10-3-1**: 2D 캔버스에서 FSM 변형 모드 표출 시, 절점 간 직선 연결이 아닌 Hermite 3차 보간 다항식에 의한 부드러운 곡선 처짐이 렌더링되어야 한다.
- [ ] **AC 10-3-2**: 2D 뷰어 툴바의 `[Mode 1]`, `[Mode 2]`, `[Mode 3]` 버튼 클릭 시 해당 모드의 형상으로 즉각 전환되어야 한다.
- [ ] **AC 10-3-3**: 3D 뷰어에서 선택된 모드의 고유벡터를 기반으로 정확한 3D 파형 메쉬가 생성되고 HUD에 모드 정보가 갱신되어야 한다.
