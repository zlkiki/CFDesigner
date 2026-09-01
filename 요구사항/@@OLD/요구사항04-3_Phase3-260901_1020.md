# [요구사항 04-3] Phase 3: 해석 및 부재설계 고도화 사양서

---

## 1. 개요 및 목적

* **문서 번호**: `요구사항04-3` (Phase 3)
* **목적**: KDS 14 31 10 / AISI S100 기준에 따른 부재설계 및 FSM 수치해석의 세부 고급 기능(웨브 크리플링 4대 지지조건 상세 폼, 최적 단면 자동 추천 Quick Design, FSM 스윕 파라미터 세부 제어, Winter 유효폭 반복 수치해석)을 웹으로 포팅.
* **대상 레거시 C# 폼 및 모듈**:
  * [`decompiled_src/_Global/frmWebCrippling.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmWebCrippling.cs) (웨브 크리플링 지압 강도 검토)
  * [`decompiled_src/_Global/frmQuickDesign.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmQuickDesign.cs) (목표 하중 만족 단면 자동 탐색)
  * [`decompiled_src/_Global/frmBuckleParam.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmBuckleParam.cs), [`frmBuckleValue.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmBuckleValue.cs) (FSM 해석 파라미터 및 수치 그리드)
  * [`decompiled_src/_Global/frmEffProp.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmEffProp.cs) (유효단면 응력 수치해석 및 뷰어)

---

## 2. 세부 기능 요구사항 (Functional Requirements)

### 2.1 웨브 크리플링(Web Crippling) 상세 설정 패널 (`frmWebCrippling.cs` 대응)
1. **설계 폼 UI 확장**:
   * 부재설계 탭에 `[🛡️ 웨브 크리플링 상세 검토]` 서브섹션 배치.
2. **파라미터 입력 필드**:
   * **지지 길이 ($N$, mm)**: 지압판 또는 받침대 지지폭 입력 (기본값: $50\text{mm}$).
   * **재하 조건 (Loading Condition)**:
     * `End-One-Flange (EOF)`: 단부 1플랜지 재하
     * `Interior-One-Flange (IOF)`: 내부 1플랜지 재하
     * `End-Two-Flange (ETF)`: 단부 2플랜지 재하
     * `Interior-Two-Flange (ITF)`: 내부 2플랜지 재하
   * **플랜지 부착 상태 (Flange Fastened / Unfastened)**: 지지부 볼트/패스너 결합 여부 라디오 버튼.
3. **결과 출력**:
   * 공칭 지압강도 $P_{nc}$, 설계 지압강도 $\phi P_{nc}$, 소요 반력 $R_u$에 대한 D/C Ratio 및 계산 근거 수식 표출.

### 2.2 퀵 디자인 (Quick Design) 최적 단면 자동 탐색 모달 (`frmQuickDesign.cs` 대응)
1. **모달 UI 구성**:
   * 상단 툴바에 `[⚡ 퀵 디자인 (Quick Design)]` 버튼 배치.
2. **목표 하중 및 구속 조건 입력**:
   * 설계 소요 축력 $P_u$ (kN), 휨모멘트 $M_{ux}, M_{uy}$ (kN·m), 전단력 $V_u$ (kN).
   * 비지지길이 $L$ (mm), 최대 허용 높이 $H_{max}$, 최대 허용 중량 $W_{max}$.
   * 대상 단면 라이브러리(예: AISI C형강 전체 또는 사용자 지정 파라메트릭 범위).
3. **최적화 탐색 및 추천 결과 그리드**:
   * $D/C \le 1.0$을 만족하는 후보 단면들을 **단위중량(Weight) 오름차순**으로 랭킹 정렬.
   * 각 후보별 $D/C$ 압축, $D/C$ 휨, $D/C$ 조합, 총 중량, 예상 절감률 표시.
   * `[이 단면으로 적용]` 클릭 시 메인 단면 모델로 즉시 전환.

### 2.3 FSM 좌굴해석 세부 파라미터 모달 & 수치 그리드 (`frmBuckleParam`, `frmBuckleValue`)
1. **FSM 파라미터 설정 모달**:
   * 반파장 스윕 범위: $L_{min}$ (기본 10mm), $L_{max}$ (기본 10,000mm), 스텝 수(기본 60스텝, 로그 스케일).
   * 고유치 해석 모드 수(기본 1모드, 다중 모드 3차까지 선택).
   * 응력 분포 상태: 순수 압축, 순수 휨, 축력+휨 편심 응력 분포.
2. **좌굴 수치 데이터 뷰어 (`frmBuckleValue.cs` 대응)**:
   * 반파장($L$) vs 좌굴하중계수($\beta$) 전체 60개 데이터 포인트 테이블 팝업.
   * `[CSV 다운로드]` 기능 제공.

### 2.4 Winter 유효단면(Effective Properties) 수치해석 및 뷰어 (`frmEffProp.cs` 대응)
1. **유효단면 반복 솔버**:
   * 주어진 응력 수준 $f \le F_y$ 또는 설계 하중에 대해 각 평판 요소의 세장비 $\lambda$ 및 Winter 유효폭 계수 $\rho$ 수렴 반복 계산.
   * 유효단면적 $A_e$, 유효 단면2차모멘트 $I_{xe}, I_{ye}$, 중립축 이동량($\Delta y$) 산출.
2. **2D 유효단면 렌더링**:
   * 2D 캔버스에 유효 단면부를 실선, 무효화(좌굴 손실)된 영역을 점선/반투명으로 오버레이 표시.

---

## 3. 백엔드 API 명세

| Method | Endpoint | 설명 | 요청/응답 페이로드 |
|---|---|---|---|
| `POST` | `/api/design/web-crippling` | 웨브 크리플링 지압강도 정밀 계산 | `Req: { condition: "IOF", n_length: 50, fastened: true, ru: 25.0 }`<br>`Res: { pnc: 48.5, phi_pnc: 36.375, dc_ratio: 0.687 }` |
| `POST` | `/api/design/quick-design` | 최적 단면 자동 탐색 및 추천 | `Req: { pu: 50, mux: 5.0, l: 3000, max_h: 200 }`<br>`Res: [ { rank: 1, name: "600S162-43", weight: 3.8, max_dc: 0.85 }, ... ]` |
| `POST` | `/api/fsm/parameters` | FSM 커스텀 파라미터 스윕 해석 | `Req: { l_min: 10, l_max: 5000, steps: 80, stress_type: "combined", ... }`<br>`Res: { curve: [...], modes: {...} }` |
| `POST` | `/api/section/effective` | Winter 식 기반 유효단면 수치해석 | `Req: { stress_f: 300, moment_axis: "X" }`<br>`Res: { ae: 450.2, ixe: 1.2e6, effective_elements: [...] }` |

---

## 4. 검증 기준 (Acceptance Criteria)

- [ ] **AC 3-1**: 웨브 크리플링 IOF 조건에서 지지길이 $N$을 50mm에서 100mm로 증가시켰을 때 공칭지압강도 $P_{nc}$가 비례하여 증가하는가?
- [ ] **AC 3-2**: Quick Design 모달에서 축력 50kN, 모멘트 5kNm 입력 시 D/C < 1.0을 만족하는 가장 가벼운 상위 5개 단면이 1초 이내에 리스트업되는가?
- [ ] **AC 3-3**: FSM 세부 설정에서 100스텝을 지정했을 때 차트에 100개 포인트가 조밀하게 렌더링되고 CSV 내보내기가 정상 동작하는가?
- [ ] **AC 3-4**: 유효단면 해석 시 압축 플랜지의 중앙부가 무효폭으로 깎인 2D 형상이 캔버스에 정확히 시각화되는가?
