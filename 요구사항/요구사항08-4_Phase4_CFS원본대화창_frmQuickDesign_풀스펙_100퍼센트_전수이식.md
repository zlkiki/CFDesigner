# [요구사항 08-4] Phase 4: CFS 원본 대화창(frmQuickDesign.cs) 100% 풀스펙 UI 및 최적설계 엔진 전수 이식

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/_Global/frmQuickDesign.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmQuickDesign.cs) (2,268줄 오리지널 C# 대화상자 전체)
> **관련 파일**:
> - `src/design/quick_design.py`
> - `src/geometry/library_parser.py`
> - `src/api/routes.py`
> - `src/web/index.html`
> - `src/web/static/js/app.js`
> - `tests/ui/test_quick_design.py`

---

## 1. 구현 목표

1. 원본 상용 프로그램의 **`frmQuickDesign.cs` 대화상자에 존재하는 모든 입력 파라메터(단면 필터, 재료 옵션, 경간/배치, 설계 하중, 횡지지, 처짐 한계 등)를 100% 빠짐없이 웹 UI로 이식**.
2. **강도(Strength), 처짐(Deflection), 웨브 크리플링(Web Crippling) 3대 통합 D/C 검토 엔진**을 완성하여 최적의 표준 단면을 실시간 자동 추천.

---

## 2. CFS 원본 `frmQuickDesign.cs` 전수 파라메터 매핑

| 카테고리 | CFS 원본 C# 컨트롤 | 파라메터 설명 | 기본값 / 옵션 범위 |
|---|---|---|---|
| **Section Filtering** | `cboDepth` | 단면 춤 (Web Depth) | All, 3.5" (90mm) ~ 14" (350mm) |
| | `cboType` | 단면 형태 (Type) | S (Stud with lip), T (Track without lip) |
| | `cboFlange` | 플랜지 폭 (Flange Width) | All, 1.25", 1.375", 1.625", 2.0", 2.5", 3.0", 3.5" |
| | `cboThickness` | 판두께 (Mil Thickness) | All, 18, 27, 30, 33, 43, 54, 68, 97, 118 mil |
| | `chkPunched` | 웨브 펀칭 홀 유무 | Checkbox (타공 유무 고려) |
| | `cboConfig` | 형상 조립 배치 | Single, Back-to-Back, Face-to-Face |
| **Material Options** | `cboYield` | 강종 항복강도 ($F_y$) | 33 ksi (230 MPa), 50 ksi (345 MPa), 사용자 정의 |
| | `chkColdWork` | 성형 가공경화 강도 증가 | Checkbox ($F_{ya}$ 적용) |
| | `chkReserve` | 비탄성 예비강도 고려 | Checkbox (Inelastic Reserve) |
| **Span & Spacing** | `cboSpan` | 부재 경간 길이 (Span) | 6 ft ~ 30 ft (1,800 ~ 9,000 mm) |
| | `cboSpacing` | 부재 중심 간격 (Spacing) | 12", 16", 19.2", 24", 48" (300 ~ 1,200 mm) |
| | `cboBracing` | 횡좌굴 지지 간격 (Bracing) | None, Mid-span, 1/3-points, 1/4-points, Continuous |
| **Applied Loads** | `txtDead` / `txtLive` | 등분포 하중 (psf / $\text{kN/m}^2$) | 바닥/지붕 마감 하중 |
| | `txtWind` | 횡방향 풍하중 (psf / $\text{kN/m}^2$) | 외벽 풍하중 |
| | `txtDeadAxial` / `txtLiveAxial` | 상부 축하중 (kips / $\text{kN}$) | 기둥 축력 |
| **Deflection & Bearing** | `cboDeflection` | 처짐 허용 한계 | Live $L/360$, Total $L/240$, $L/600$, $L/180$ |
| | `txtBearing` | 지점 지압길이 ($N$) | 1.0" ~ 6.0" (25 ~ 150 mm) |

---

## 3. 세부 개발 명세

### 3.1 퀵 디자인 웹 모달 풀스펙 재설계 (`index.html`)
* **3열 그리드 레이아웃**:
  - 좌측 컬럼: **[단면 및 재료 필터]** (Depth, Type, Flange, Thickness, Punched, Config, Fy, ColdWork, Reserve).
  - 중앙 컬럼: **[경간 및 설계 하중]** (Span, Spacing, Bracing, Dead, Live, Wind, Axial Dead/Live, Deflection Limit, Bearing Length).
  - 우측 컬럼: **[최적 단면 추천 랭킹 리스트 및 3대 D/C 게이지]** (Strength, Deflection, Web Crippling).

### 3.2 3대 다축 검토 엔진 확장 (`quick_design.py`)
* **1. 강도 검토 (Strength)**:
  - 축압축 + 이축휨 P-M 조합 D/C ratio 계산.
* **2. 사용성 처짐 검토 (Deflection)**:
  - 활하중 처짐 $\delta_L = \frac{5 w_L L^4}{384 E I_{xe}} \le \frac{L}{360}$, 총하중 처짐 $\delta_{total} \le \frac{L}{240}$.
* **3. 웨브 크리플링 검토 (Web Crippling)**:
  - 지압길이 $N$ 및 지점 반력 $R$에 대한 $\phi P_n$ 및 D/C ratio 계산.
* **최적화 랭킹 정렬**:
  - $\max(\text{Strength D/C}, \text{Deflection D/C}, \text{Crippling D/C}) \le 1.0$을 만족하는 단면들을 단위중량($\text{kg/m}$) 오름차순으로 1위~10위 정렬하여 추천.

---

## 4. 1:1 수용 기준 (Acceptance Criteria)

- [ ] **AC 4-1**: 퀵 디자인 모달 열기 시 CFS 원본 `frmQuickDesign.cs`의 모든 입력 항목(단면 6종 필터, 하중 5종, 지지/처짐/지압길이)이 충실히 제공되는가?
- [ ] **AC 4-2**: 소요 설계조건 입력 후 [⚡ 최적 단면 자동 추천] 클릭 시 강도, 처짐, 웨브 크리플링 3대 D/C를 모두 만족하는 최적 경량 단면 목록이 정상 출력되는가?
- [ ] **AC 4-3**: 추천된 단면 중 하나를 클릭했을 때 메인 캔버스와 설계 화면으로 해당 단면의 제원과 물성치가 원클릭 로드되는가?
- [ ] **AC 4-4**: `pytest tests/ui/test_quick_design.py` 단위 테스트가 100% Pass 통과하는가?
