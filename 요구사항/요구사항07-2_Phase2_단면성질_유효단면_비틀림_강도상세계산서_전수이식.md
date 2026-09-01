# [요구사항 07-2] Phase 2: 단면 기하·특성치·유효단면·비틀림·완전지지 강도 상세 계산서 전수 이식

> **문서 상태**: ⏳ **대기 (Phase 2)**  
> **상위 마스터 요구사항**: [`요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md)  
> **관련 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs) (`rptSctInp`, `rptProperties`, `rptTorsionProp`, `rptEffProperties`, `rptStrength`)

---

## 1. Phase 목표 및 배경

CFS 원본 `Report.cs`의 단면 관련 핵심 계산서 섹션 5종(`rptSctInp`, `rptProperties`, `rptTorsionProp`, `rptEffProperties`, `rptStrength`)의 데이터 구조, 수치 테이블, 수식 및 중간 계산 과정을 웹 구조계산서로 100% 무결하게 전수 이식합니다.

---

## 2. 세부 구현 요구사항

### 2.1 단면 입력 제원 리포트 (`rptSctInp` 전수 이식)
1. **재료 특성치 테이블**:
   - 재료명(Material Name), 탄성계수($E = 205,000\,\text{MPa}$), 항복강도($F_y$), 인장강도($F_u$), 연신율(Elongation %).
   - 냉간가공경화(Cold-work of forming) 강도 증대 적용 여부 및 계산된 평균 항복강도 $F_{ya}$.
   - 비탄성 예비강도(Inelastic reserve capacity) 적용 여부.
   - 스테인리스강 등 비선형 재료의 경우 5대 방향별 $E_o, F_y, n$ 계수표 수록.
2. **파트 및 요소 전수 명세표 (Elements Table)**:
   - 파트명, 두께($t$), 게이지 번호, 원점 기준 배치 좌표($X_{pos}, Y_{pos}$), 폐구/개구 여부.
   - 요소 전수 일람표:
     * 요소 번호 (Elem #)
     * 길이 ($L$, mm)
     * 회전각도 ($\theta$, deg)
     * 굽힘 곡률반경 ($R$, mm)
     * 웨브 유형 (Web Type: Flat, Stiffened, Intermediate 등)
     * 국부좌굴계수 ($k$)
     * 홀/개구부 크기 ($d_h$, mm) 및 중심 거리 (Dist, mm)
3. **직접강도법(DSM) 사전 지정 파라미터**:
   - 사전검증 단면(Prequalified Section) 여부.
   - 무차원 탄성좌굴비: 압축($P_{crl}/P_y, P_{crd}/P_y$), $X$축 휨($M_{crlx}/M_y, M_{crdx}/M_y$), $Y$축 휨($M_{crly}/M_y, M_{crdy}/M_y$), 전단($V_{cry}/V_y, V_{crx}/V_y$).

---

### 2.2 단면 기하학적 성질 계산서 (`rptProperties` 전수 이식)
1. **총단면 성질 (Gross Section Properties)**:
   - 총단면적 ($A_g$), 단위중량 ($W, \text{kg/m}$).
   - 도심 좌표 ($\bar{x}, \bar{y}$), 외곽 경계 거리 ($x_{left}, x_{right}, y_{top}, y_{bottom}$).
   - 직교축 단면 2차모멘트 ($I_x, I_y, I_{xy}$), 단면 2차반경 ($r_x, r_y$).
   - 연단 단면계수 상/하/좌/우 ($S_{xt}, S_{xb}, S_{yl}, S_{yr}$).
2. **주축 성질 (Principal Axes Properties)**:
   - 주축 회전각 ($\theta_p$).
   - 주축 단면 2차모멘트 ($I_1, I_2$), 주축 단면 2차반경 ($r_1, r_2$).
   - 주축 연단 단면계수 ($S_{1t}, S_{1b}, S_{2l}, S_{2r}$).
3. **비틀림 및 뒴 성질 (Torsional & Warping Properties)**:
   - 전단중심 좌표 ($x_o, y_o$).
   - 세인트 버넌 비틀림 상수 ($J$), 뒴 비틀림 상수 ($C_w$).
   - 극단면 2차반경 ($r_o = \sqrt{r_x^2 + r_y^2 + x_o^2 + y_o^2}$).
   - 단면 비대칭 파라미터 ($\beta_w, \beta_y$).
4. **순단면 성질 (Net Section Properties - 홀/개구부 반영 시)**:
   - 순단면적 ($A_n$), 순단면 2차모멘트 ($I_{xn}, I_{yn}$), 순단면 전단중심 및 비틀림상수 ($x_{on}, y_{on}, C_{wn}, J_n$).

---

### 2.3 비틀림 특성치 수치 리포트 (`rptTorsionProp` 전수 이식)
1. **요소별 비틀림 수치 명세표**:
   - 요소 번호 (Elem #)
   - 요소 위치 (Location, mm)
   - 전단중심으로부터의 수직거리 ($R_o$, mm)
   - 정규화 단위 뒴함수 ($W_n, \text{mm}^2$) $\rightarrow$ 종방향 뒴 응력 계산 근거
   - 뒴 단면 1차 모멘트 ($S_w, \text{mm}^4$) $\rightarrow$ 전단 뒴 응력 계산 근거
2. **비틀림 용어 및 공학적 의미 해설 수록**:
   - $R_o, W_n, S_w, C_w, J$의 물리적 의미와 산정 공식 설명 포함.

---

### 2.4 유효단면 성질 및 Winter 유효폭 해석 리포트 (`rptEffProperties` 전수 이식)
1. **지정 하중 조건 하의 유효 단면 특성치**:
   - 하중 조건: 소요 축력 $P$, 휨모멘트 $M_x, M_y$.
   - 유효 단면적 ($A_e$), 유효 2차모멘트 ($I_{xe}, I_{ye}$), 이동된 도심 위치 ($x_c, y_c$), 유효 단면계수 ($S_{xe}, S_{ye}$).
2. **요소별 Winter 유효폭 반복 계산 상세표 (Winter Iteration Table)**:
   - 요소 번호 및 평판 폭 ($w$)
   - 연단 압축응력 ($f_1, f_2$) 및 응력비 ($\psi = f_2 / f_1$)
   - 평판 좌굴계수 ($k$)
   - 판폭두께비 ($w/t$) 및 한계 세장비 ($\lambda$)
   - 강도 감소계수 ($\rho$)
   - 산정된 유효폭 ($b_e, b_1, b_2$) 및 무효폭(Ineffective width)
   - 플랜지 컬링(Flange Curling) 검토 수치.

---

### 2.5 완전지지 부재 강도 리포트 (`rptStrength` 전수 이식)
1. **KDS 14 31 10 / LRFD 및 ASD 설계 강도 일람표**:
   - 축압축 강도: $\phi P_{no} / P_{ao}$
   - 인장 강도: $\phi T_n / T_a$
   - 정모멘트 강도 ($+M_x$): $\phi M_{nxo}^+ / M_{axo}^+$, 유효단면계수 $S_{xe(t)}, S_{xe(b)}$
   - 부모멘트 강도 ($-M_x$): $\phi M_{nxo}^- / M_{axon}^-$, 유효단면계수 $S_{xe(t)}, S_{xe(b)}$
   - $Y$축 휨 강도 ($\pm M_y$): $\phi M_{nyo} / M_{ayo}$, 유효단면계수 $S_{ye(l)}, S_{ye(r)}$
   - 웨브 전단 강도: $\phi V_{ny}, \phi V_{nx} / V_{ay}, V_{ax}$
   - 비틀림 뒴 강도: $\phi B_n / B_a$
2. **상세 계산 과정 Trace 로그 (Calculation Details Trace)**:
   - 항복 모멘트 $M_y = S_f F_y$, 유효단면 강도 $M_{ne} = S_e F_y$, 전단 항복 및 좌굴 수식 전개 과정.

---

## 3. 검증 기준 (Acceptance Criteria)

- [x] **AC 7-2-1**: 요소 전수 제원표($L, \theta, R, k$, Hole, Dist)가 계산서 테이블에 정확한 단위와 함께 완벽히 렌더링될 것.
- [x] **AC 7-2-2**: Gross/Net 및 직교축/주축/비틀림 4대 단면 성질이 0.1% 수치 오차 없이 정확히 표출될 것.
- [x] **AC 7-2-3**: 비틀림 특성 리포트에서 요소별 $R_o, W_n, S_w$ 수치표가 원본 C# 계산값과 1:1로 일치할 것.
- [x] **AC 7-2-4**: 유효단면 리포트에서 Winter 반복 계산 상세표($f_1, f_2, \psi, k, w/t, \lambda, \rho, b_e$)가 명확히 표출될 것.
- [x] **AC 7-2-5**: 완전지지 부재 강도 및 상세 Trace 로그가 KDS 기준식과 함께 체계적으로 렌더링될 것.
- [x] **AC 7-2-6**: `pytest tests/test_report.py` 단위 테스트가 100% 통과할 것.
