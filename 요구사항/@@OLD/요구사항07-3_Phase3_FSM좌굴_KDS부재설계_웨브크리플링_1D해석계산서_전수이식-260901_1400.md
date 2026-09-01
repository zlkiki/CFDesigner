# [요구사항 07-3] Phase 3: FSM 좌굴·KDS 부재설계·웨브 크리플링·1D 해석 계산서 전수 이식 및 종합 검증

> **문서 상태**: ⏳ **대기 (Phase 3)**  
> **상위 마스터 요구사항**: [`요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md)  
> **관련 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs) (`rptDSMData`, `rptMemberCheck`, `rptWebCrippling`, `rptAnlInp`, `rptDiagrams`, `rptTorsionDiagrams`, `rptEnvelopes`, `rptTorsionEnvelopes`, `rptMemberCheckAnl`, `rptWebCripplingAnl`)
> - [`decompiled_src/RSG/CFS/PrintRoutines.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/PrintRoutines.cs) (`PrintBuckling`, `PrintDiagrams`, `PrintDiagEnv`, `PrintTorsionDiag`, `PrintTorsionEnv`)

---

## 1. Phase 목표 및 배경

CFS 원본의 FSM 탄성 좌굴해석, KDS 14 31 10 / AISI S100 직접강도법(DSM) 부재설계, 웨브 크리플링(Web Crippling) 및 1D 보/기둥 구조해석 다이어그램 수치 출력 루틴을 전수 이식하여, 실무 제출이 가능한 최고 수준의 정식 구조계산서를 완성합니다.

---

## 2. 세부 구현 요구사항

### 2.1 FSM 유한대판 탄성 좌굴 및 DSM 파라미터 리포트 (`rptDSMData` & `PrintBuckling`)
1. **FSM 시그니처 커브 최소점(Minima) 수치표**:
   - 하중 조건별(순수 압축, $X$축 정/부휨, $Y$축 정/부휨, 전단) 3대 임계 좌굴 모드:
     * **국부 좌굴 (Local Buckling)**: 임계 반파장 길이 ($L_{crl}$), 탄성 좌굴 하중 ($P_{crl}$), 무차원 좌굴비 ($P_{crl}/P_y, M_{crl}/M_y$), 좌굴응력 ($F_{crl}$).
     * **왜곡 좌굴 (Distortional Buckling)**: 임계 반파장 길이 ($L_{crd}$), 탄성 좌굴 하중 ($P_{crd}$), 무차원 좌굴비 ($P_{crd}/P_y, M_{crd}/M_y$), 좌굴응력 ($F_{crd}$).
     * **전역 좌굴 (Global Buckling)**: 임계 반파장 길이 ($L_{cre}$), 탄성 좌굴 하중 ($P_{cre}$), 무차원 좌굴비 ($P_{cre}/P_y, M_{cre}/M_y$), 좌굴응력 ($F_{cre}$).
2. **사전검증 단면 (Prequalified Section) 판정 체크리스트**:
   - KDS 14 31 10 / AISI S100 기준에 따른 판폭두께비($w/t, d/t, b/t$) 한계 검토 및 사전검증 적합성(Yes/No) 판정표.
3. **고해상도 FSM 시그니처 커브 & 좌굴 형상도 SVG 인쇄**:
   - 로그 스케일 시그니처 커브 그래프 ($L$ vs $P_{cr}/P_y$).
   - 국부, 왜곡, 전역 모드의 2D 단면 변형도 및 3D 좌굴 형상 렌더링.

---

### 2.2 KDS 14 31 10 / AISI S100 부재설계 상세 계산서 (`rptMemberCheck` 전수 이식)
1. **설계 조건 및 부재 파라미터**:
   - 부재 길이 ($L$), 비지지길이 ($K_x L_x, K_y L_y, K_t L_t, L_b$).
   - 휨모멘트 구배계수 ($C_b$), 2차효과 모멘트 확대계수 ($B_1, B_2$).
   - 설계 하중 조합: 소요 축력 ($P_u$), 소요 휨모멘트 ($M_{ux}, M_{uy}$), 소요 전단력 ($V_{ux}, V_{uy}$), 비틀림 ($T_u, B_u$).
2. **축압축강도 ($P_n$) 상세 계산식 전개**:
   - 전역 좌굴강도 $P_{ne} = A_g F_n$ (비탄성/탄성 좌굴 수식 구분).
   - 국부 좌굴강도 $P_{nl} = f(P_{ne}, P_{crl})$ 및 왜곡 좌굴강도 $P_{nd} = f(P_y, P_{crd})$.
   - 공칭압축강도 $P_n = \min(P_{ne}, P_{nl}, P_{nd})$, 설계강도 $\phi P_n$ ($\phi = 0.85$), D/C Ratio 및 지배 모드.
3. **휨모멘트강도 ($M_{nx}, M_{ny}$) 상세 계산식 전개**:
   - 횡비틀림좌굴(LTB) 강도 $M_{ne} = f(M_{cre})$.
   - 국부 좌굴강도 $M_{nl} = f(M_{ne}, M_{crl})$, 왜곡 좌굴강도 $M_{nd} = f(M_y, M_{crd})$.
   - 공칭휨강도 $M_n = \min(M_{ne}, M_{nl}, M_{nd})$, 설계강도 $\phi M_n$ ($\phi = 0.90$), D/C Ratio 및 지배 모드.
4. **전단 강도 ($V_n$) 및 비틀림 검토**:
   - 웨브 전단 항복강도 $V_y$ 및 탄성 전단좌굴강도 $V_{cr}$, 공칭 전단강도 $V_n$, 설계강도 $\phi V_n$.
5. **P-M 조합응력 (Combined Interaction) 상세 검토**:
   - KDS 14 31 10 식:
     $$\frac{P_u}{\phi_c P_n} + \frac{B_1 M_{ux}}{\phi_b M_{nx}} + \frac{B_2 M_{uy}}{\phi_b M_{ny}} \le 1.0$$
   - 각 항별 수치 대입 과정, 최종 합산비 및 OK/NG 판정.

---

### 2.3 웨브 크리플링 검토 리포트 (`rptWebCrippling` & `rptWebCripplingAnl` 전수 이식)
1. **지지 조건 및 파라미터**:
   - 받침점 지지길이 ($N$), 재하폭, 단부/내부 재하(EOF, ETF, IOF, ITF) 유형.
   - 단일 웨브(Single Web) vs 조립 웨브(Built-up Web), 플랜지 체결 여부.
2. **크리플링 내력 및 휨 조합 검토**:
   - 공칭 크리플링 강도 $P_n = C t^2 F_y \sin\theta (1 - C_R \sqrt{R/t})(1 + C_N \sqrt{N/t})(1 - C_h \sqrt{h/t})$.
   - 설계 강도 $\phi P_n$, 소요 반력 $R_u$, D/C Ratio.
   - 휨-크리플링 조합 검토식:
     $$0.91 \frac{P_u}{\phi_w P_n} + \frac{M_u}{\phi_b M_n} \le 1.33 \quad (\text{또는 규준 지정 조합식})$$

---

### 2.4 1D 보/기둥 구조해석 및 단면력 다이어그램 리포트 (`rptAnlInp`, `rptDiagrams`, `rptEnvelopes`)
1. **해석 입력 제원표 (`rptAnlInp`)**:
   - 부재 방향, 단면 속성, 지점 및 경계조건(스팬 길이, 롤러/힌지/고정, 스프링 강성), 재하 하중(집중/분포/모멘트), 하중 조합.
2. **위치($Z$)별 단면력 및 변위 수치표 (`rptDiagrams`, `rptTorsionDiagrams`)**:
   - 부재 축을 따라 등간격 분할 위치($Z$)에서의 $M_x, M_y, V_x, V_y, P, T, B$ 및 처짐($\delta_x, \delta_y, \theta$).
3. **포락선(Envelope) 및 전 구간 연속 부재검토표 (`rptEnvelopes`, `rptMemberCheckAnl`)**:
   - 최대/최소 단면력 포락선 수치표.
   - 전 구간 위험 단면(Critical Section) 부재 내력 검토 및 D/C Ratio 요약표.
4. **단면력 다이어그램 그래픽 인쇄**:
   - BMD(휨모멘트도), SFD(전단력도), Deflection(처짐곡선), 비틀림 모멘트도 SVG 렌더링.

---

## 3. 검증 기준 (Acceptance Criteria)

- [x] **AC 7-3-1**: FSM 시그니처 커브 최소치 일람표 및 2D/3D 좌굴 형상도가 계산서에 완벽히 렌더링될 것.
- [x] **AC 7-3-2**: KDS 14 31 10 직접강도법(DSM)의 $P_n, M_n, V_n$ 상세 수식 전개 과정 및 P-M 조합식이 KaTeX 수식으로 정확히 표출될 것.
- [x] **AC 7-3-3**: 웨브 크리플링 조건별 내력 및 휨-크리플링 조합 검토가 누락 없이 수록될 것.
- [x] **AC 7-3-4**: 1D 해석 모델에 대해 위치별 단면력 수치표, 포락선 테이블, BMD/SFD 그래프가 정상 인쇄될 것.
- [x] **AC 7-3-5**: 전체 단위 및 통합 테스트 `pytest tests/`가 100% 통과할 것.
