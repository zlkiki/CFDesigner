# [요구사항 04-4] Phase 4: 1D 뼈대 구조해석 엔진 및 다이어그램 사양서

---

## 1. 개요 및 목적

* **문서 번호**: `요구사항04-4` (Phase 4)
* **목적**: 기존 CFS 14.0의 1D 보/기둥 구조해석 모듈(`frmAnlInp`, `frmAnlWizard`, `frmDiagrams`)을 웹으로 포팅하여, 임의 경간의 단순보, 연속보, 캔틸레버에 대한 유한요소 해석(FEM)을 수행하고, 전단력도(SFD), 휨모멘트도(BMD), 처짐(Deflection) 곡선을 인터랙티브하게 시각화하며 단면 부재설계(Member Check)와 자동 연동.
* **대상 레거시 C# 폼 및 모듈**:
  * [`decompiled_src/_Global/frmAnlInp.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmAnlInp.cs) (구조해석 입력 및 하중조합)
  * [`decompiled_src/_Global/frmAnlWizard.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmAnlWizard.cs) (구조해석 마법사)
  * [`decompiled_src/_Global/frmDiagrams.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmDiagrams.cs) (SFD, BMD, 처짐 다이어그램 뷰어)
  * [`decompiled_src/_Global/frmAnlPicMaster.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmAnlPicMaster.cs) (1D 뼈대 모델 그래픽)
  * [`decompiled_src/RSG/CFS/Analysis.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Analysis.cs) (1D 매트릭스 해석 솔버 엔진)

---

## 2. 세부 기능 요구사항 (Functional Requirements)

### 2.1 구조해석 마법사 모달 (Analysis Wizard Modal)
1. **상단 네비게이션에 `[🏗️ 1D 구조해석 (Beam/Column Analysis)]` 탭/버튼 신설**:
2. **해석 타입 프리셋 선택**:
   * `단순보 (Simple Span Beam)`
   * `연속보 (Continuous Beam - 2~5 경간)`
   * `캔틸레버 (Cantilever Beam)`
   * `기둥 / 축력+휨 부재 (Column / Beam-Column)`
3. **경간 및 지점 조건 입력**:
   * 각 경간 길이 $L_1, L_2, \dots$ (mm).
   * 지점 구속조건: 롤러(Pin/Roller), 고정단(Fixed), 스프링 지점.
4. **하중 조건 (Loads) 입력**:
   * 등분포하중 ($w, \text{kN/m}$), 집중하중 ($P, \text{kN}$, 위치 $x$), 모멘트 하중 ($M, \text{kN}\cdot\text{m}$).
   * 자중 자동 계산 옵션 (현재 단면의 단위중량 $W$ 연동).
   * 하중조합 ($1.2D + 1.6L$ 등 KDS 설계기준 자동 적용).

### 2.2 1D FEM 구조해석 엔진 (`src/solver/frame1d.py`)
1. **1차원 티모셴코/오일러-베르누이 보 요소 행렬 해석**:
   * 절점 변위, 지점 반력($R$), 부재력 산정.
   * 부재 길이 방향 100개 분할점에 대한 $V(x)$ (전단력), $M(x)$ (휨모멘트), $\delta(x)$ (처짐) 수치 배열 계산.
   * 최대 부재력 위치 ($x_{max}$) 및 극값 ($V_{max}, M_{max}, \delta_{max}$) 자동 검출.

### 2.3 인터랙티브 다이어그램 뷰어 (SFD / BMD / Deflection Diagram Viewer)
1. **3단 스택 인터랙티브 Chart.js 다이어그램 패널 (`frmDiagrams.cs` 대응)**:
   * ① **하중 및 부재 모델 뷰**: 보 형상, 지점 삼각형/사각형 마커, 하중 화살표 렌더링.
   * ② **전단력도 (SFD, Shear Force Diagram)**: 전단력 분포 곡선 및 최대/최소 $V$ 표기.
   * ③ **휨모멘트도 (BMD, Bending Moment Diagram)**: 휨모멘트 분포 곡선 및 최대 정/부 모멘트 ($+M_{max}, -M_{max}$) 표기.
   * ④ **처짐 곡선 (Deflection Curve)**: 최대 처짐량($\delta_{max}$) 및 허용 처짐 기준($L/300, L/240$) 초과 여부 판정.
2. **마우스 커서 인터랙션**:
   * 마우스 오버 시 특정 위치 $x$에서의 정확한 $V(x), M(x), \delta(x)$ 수치 툴팁 표시.
3. **원클릭 부재설계 연동 버튼 (`[설계 검토로 가져오기]`)**:
   * 해석에서 산출된 최대 부재력($P_u = P_{max}, M_u = M_{max}, V_u = V_{max}$)을 메인 화면의 부재설계(Member Check) 폼으로 자동 주입하여 실시간 D/C Ratio 검토.

---

## 3. 백엔드 API 명세

| Method | Endpoint | 설명 | 요청/응답 페이로드 |
|---|---|---|---|
| `POST` | `/api/analysis/run` | 1D 보/기둥 구조해석 실행 | `Req: { spans: [3000, 3000], supports: ["pin", "roller", "roller"], loads: [...] }`<br>`Res: { reactions: [...], sfd: [...], bmd: [...], deflection: [...], max_forces: {...} }` |
| `POST` | `/api/analysis/transfer-to-design` | 구조해석 결과를 단면 부재설계로 연동 | `Req: { section_id: "...", max_forces: {...} }`<br>`Res: { member_check_result: {...} }` |

---

## 4. 검증 기준 (Acceptance Criteria)

- [ ] **AC 4-1**: 경간 4,000mm 단순보에 등분포하중 10 kN/m 재하 시 최대 휨모멘트 $M_{max} = \frac{wL^2}{8} = 20.0\,\text{kN}\cdot\text{m}$, 최대 전단력 $V_{max} = 20.0\,\text{kN}$이 정확히 계산되는가?
- [ ] **AC 4-2**: SFD, BMD, 처짐 다이어그램이 브라우저에서 매끄럽게 렌더링되고 마우스 호버 시 실시간 좌표/부재력이 툴팁으로 표시되는가?
- [ ] **AC 4-3**: 2경간 연속보에서 지점 부모멘트 및 경간 중앙 정모멘트가 C# `Analysis.cs` 결과와 0.1% 오차 미만으로 일치하는가?
- [ ] **AC 4-4**: `[설계 검토로 가져오기]` 클릭 시 계산된 $M_u, V_u$가 즉시 D/C 대시보드에 반영되는가?
- [ ] **AC 4-5**: A4 구조계산서 출력 시 SFD/BMD 다이어그램 이미지가 리포트에 포함되어 인쇄되는가?
