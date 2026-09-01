# [요구사항 04-1] Phase 1: 단면 미세 편집 및 기하 조작 도구 사양서

---

## 1. 개요 및 목적

* **문서 번호**: `요구사항04-1` (Phase 1)
* **목적**: 파라메트릭 마법사 및 DXF 불러오기로 생성된 단면에 대해, 개별 요소(Element)의 길이/각도/두께/노드를 스프레드시트 형태로 정밀 수정하고, 회전/대칭 변환 및 중간 보강 리브(Ribs)를 추가할 수 있는 인터랙티브 편집 도구를 웹으로 포팅.
* **대상 레거시 C# 폼**:
  * [`decompiled_src/_Global/frmSctInp.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmSctInp.cs) (요소 그리드 편집기)
  * [`decompiled_src/_Global/frmAngle.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmAngle.cs) (회전 및 미러 대칭 변환)
  * [`decompiled_src/_Global/frmRibs.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmRibs.cs) (중간 리브 보강재 삽입)
  * [`decompiled_src/_Global/frmLocation.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmLocation.cs) (원점 이동 및 좌표 정렬)

---

## 2. 세부 기능 요구사항 (Functional Requirements)

### 2.1 단면 요소 스프레드시트 편집기 (Element Table Editor Modal)
1. **모달 또는 하단 슬라이드 패널 제공**:
   * 좌측 툴바 또는 2D 캔버스 상단에 `[📋 요소 편집 (Elements)]` 버튼 배치.
   * 클릭 시 현재 단면을 구성하는 모든 파트 및 요소(Element)의 테이블 그리드 모달 표시.
2. **테이블 편집 항목**:
   * `ID` (요소 번호), `시작 노드 (Node 1)`, `끝 노드 (Node 2)`
   * `길이 (Length, mm)` 또는 `폭 (Width, mm)`
   * `각도 (Angle, deg)` 또는 `시작점/끝점 좌표 (X1, Y1, X2, Y2)`
   * `두께 (Thickness, mm)`
   * `코너 반경 (Radius R, mm)`
3. **인터랙티브 기능**:
   * 행 추가(`+ Add Row`), 행 삭제(`- Delete Row`), 선택 요소 2D 캔버스 하이라이트.
   * `[적용 및 재해석]` 버튼 클릭 시 단면 성질, FSM 좌굴해석, DSM 부재설계 실시간 갱신.

### 2.2 2D 캔버스 기하 변환 도구 (Transform Toolbar)
1. **2D 뷰어 오버레이 툴바에 변환 버튼군 추가**:
   * 🔄 **90° 회전 (Rotate 90° CW / CCW)**: 단면을 도심 기준 90도 단위로 회전.
   * 🔀 **임의각도 회전 (Rotate Arbitrary Angle)**: 회전각 입력 다이얼로그(`frmAngle.cs` 대응).
   * 🪞 **좌우 대칭 (Mirror Horizontal)**: Y축 기준 좌우 대칭 변환.
   * 🪞 **상하 대칭 (Mirror Vertical)**: X축 기준 상하 대칭 변환.
   * 🎯 **원점 정렬 (Center to Origin)**: 도심($C_G$) 또는 좌하단 기준 원점 $(0,0)$ 정렬 (`frmLocation.cs` 대응).

### 2.3 중간 리브(Ribs) 보강재 삽입 마법사 (Insert Ribs Modal)
1. **리브 추가 대화상자 (`frmRibs.cs` 대응)**:
   * 리브를 추가할 대상 요소(예: 웹 판, 플랜지 판) 선택.
   * **리브 형태 선택**:
     * `V-Shape Rib` (삼각 리브: 폭 $w_r$, 깊이 $d_r$)
     * `Trapezoidal Rib` (사다리꼴 리브)
     * `Curved Rib` (원호 리브)
   * **배치 개수 및 간격**: 1개(중앙), 2개(3등분), 균등 분할 $N$개.
   * `[리브 생성]` 클릭 시 기존 평판 요소를 세부 분할하고 리브 지오메트리를 자동 생성하여 2D 캔버스 및 FSM 모델에 반영.

---

## 3. 백엔드 API 명세

| Method | Endpoint | 설명 | 요청/응답 페이로드 |
|---|---|---|---|
| `POST` | `/api/section/elements` | 요소 테이블 직접 수정을 통한 단면 갱신 | `Req: { parts: [...], elements: [...] }`<br>`Res: { properties: {...}, fsm_summary: {...} }` |
| `POST` | `/api/section/transform` | 기하 변환 (회전, 미러링, 이동) | `Req: { transform_type: "rotate"\|"mirror_h"\|"mirror_v", angle: 90, align: "cg" }` |
| `POST` | `/api/section/insert-ribs` | 중간 리브 보강재 삽입 | `Req: { element_index: 2, rib_type: "V", width: 15, depth: 8, count: 1 }` |

---

## 4. 검증 기준 (Acceptance Criteria) - [100% 만족 ✅]

- [x] **AC 1-1**: 단면 마법사로 생성된 C형강의 요소 테이블을 열어 플랜지 두께나 웹 높이를 수정한 후 [적용] 시 단면 형상 및 $A_g, I_x$가 즉시 재계산되는가?
- [x] **AC 1-2**: 90도 회전 시 $I_x$와 $I_y$의 값이 서로 교환되고, 도심 및 2D 캔버스 렌더링이 올바르게 회전하는가?
- [x] **AC 1-3**: C형강 웨브(Element 3)에 1개의 V형 리브를 추가했을 때 노드가 자동 분할되고 FSM 시그니처 커브에서 국부좌굴하중($P_{crl}$)이 상승하는가?
- [x] **AC 1-4**: 모든 UI가 다크/라이트 테마에 맞춰 미려하게 렌더링되는가?
