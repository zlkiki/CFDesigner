# [기술 문서 02] CAD(DXF) 비정형 단면 정의 규칙 및 파싱 명세 (02_cad_dxf_specification.md)

---

## 1. DXF 도면 작성 규칙 (CAD Drawing Specification)

AutoCAD 등 CAD 소프트웨어에서 냉간성형강 단면을 작성할 때 준수해야 하는 표준 규약입니다 (`scratch/help_html/import-dxf.htm` 및 `RSG.CFS.Section.ImportDXF` 기반).

1. **중심선(Centerline) 기준 연속 2D 폴리라인 (2D Polyline / LWPolyline)**:
   - 각 부재 파트는 재료 두께의 **중심선(Centerline)**을 따라 끊김 없이 이어진 하나의 폴리라인으로 작도합니다.
   - 평면은 반드시 **XY 평면 ($Z=0$)** 상에 위치해야 합니다.
2. **선 가중치/폭(Width) = 판 두께 ($T$)**:
   - 폴리라인의 전체 선폭(Global Width, 그룹코드 `43`)이 부재의 두께($T$)를 의미합니다.
   - 단일 폴리라인 내에서 폭은 일정(Uniform)해야 하며, $0 < T \le 1.0\text{ inch } (25.4\text{ mm})$ 범위여야 합니다.
3. **직선과 곡선(Arc)의 교대 배치**:
   - 직선 구간(Line)과 코너 라운딩(Arc, Fillet)이 교대로 배치되어야 합니다.
   - 코너 꺾임부는 직각으로 그린 후 CAD의 `FILLET` 명령어로 벤딩 반경을 입력하는 방식을 권장합니다.
   - 곡선 요소의 중심각은 $180^\circ$ 미만이어야 합니다.
4. **폐곡선(Closed Polyline)**:
   - 닫힌 폴리라인(Closed flag = 1)은 각형강관(Tube)과 같은 폐단면으로 자동 인식됩니다.

---

## 2. DXF 그룹코드 파싱 알고리즘 (`RSG.CFS.Section.cs`)

`Section.ImportDXF`에서 처리하는 DXF 핵심 그룹코드 매핑 테이블입니다:

| DXF 그룹코드 | 데이터 타입 | 설명 및 파싱 처리 |
|---|---|---|
| `0` | String | 엔티티 타입 (`SECTION`, `HEADER`, `POLYLINE`, `LWPOLYLINE`, `VERTEX`, `ENDSEC`) |
| `2` | String | 섹션 이름 (`HEADER`, `ENTITIES`) |
| `9` | String | 헤더 변수 (`$INSUNITS`) |
| `70` | Integer | 단위계 코드 또는 폴리라인 Closed 플래그 (`bit 0 == 1`이면 폐곡선) |
| `10`, `20`, `30` | Double | 정점 좌표 ($X, Y, Z$) - 단위계 계수 스케일링 적용 |
| `40`, `41`, `43` | Double | 시작 폭, 끝 폭, 전체 폭 $\rightarrow$ 부재 두께 $T$로 인식 |
| `42` | Double | **Bulge 값**: 호(Arc)의 굽힘 정도 $\rightarrow$ 중심각 $\theta = 4 \cdot \arctan(\text{Bulge})$ |

---

## 3. 정점 $\rightarrow$ 구조 요소 자동 변환 알고리즘 (`DXFPart`)

`DXFPart` 함수는 $N$개의 정점 좌표 배열(`array[i].X, array[i].Y, array[i].Arc`)을 유한대판 요소(`Element[k].Len, Element[k].Ang, Element[k].Rad`)로 변환합니다:

### 3.1. 기하학적 수식 및 분할 원리

1. **정점 간 거리 및 기하 계산**:
   두 정점 $P_i(x_i, y_i)$와 $P_{i+1}(x_{i+1}, y_{i+1})$ 사이의 현 길이(Chord Length) $L_c$:
   $$L_c = \sqrt{(x_{i+1} - x_i)^2 + (y_{i+1} - y_i)^2}$$

2. **호(Arc) 요소의 반경 및 접선 길이**:
   정점에 Arc(중심각 $\theta = 4 \arctan(\text{Bulge})$)가 존재하는 경우:
   - 중심선 반경 $R_c = \frac{L_c / 2}{\sin(|\theta| / 2)}$
   - 접선 연장 길이 $L_t = R_c \cdot \tan(|\theta| / 2)$
   - 내측 코너 반경 $R_{in} = \max(R_c - T/2, 0.0)$

3. **요소 길이($\text{Len}$) 및 회전각($\text{Ang}$) 조립**:
   - 직선 요소인 경우: $\text{Len} = L_t + L_c$, $\text{Ang} = \operatorname{atan2}(y_{i+1}-y_i, x_{i+1}-x_i)$
   - 곡선 요소인 경우: $\text{Ang} = \operatorname{atan2}(y_{i+1}-y_i, x_{i+1}-x_i) - \theta/2$, $\text{Rad} = R_{in}$

4. **도심(CG) 자동 원점 정렬 (Centering)**:
   단면 형상 조립 후 전체 단면의 도심 $(X_{cg}, Y_{cg})$를 계산하여 모든 파트 좌표를 원점 $(0, 0)$ 기준으로 자동 평행이동시킵니다.
