# [기술 문서 05] KDS 14 31 10 및 AISI S100 설계 기준서 (05_kds_aisi_design_rules.md)

---

## 1. 적용 규준 체계 및 설계법

| 규준명 | 표준 코드 | 설계 철학 | 주요 특징 |
|---|---|---|---|
| **북미 기준 (CFS 내장)** | AISI S100-16 (ASCE 8-02) | LRFD / ASD / LSD | 직접강도법(DSM) 및 유효폭법(EWM) 전면 지원 |
| **한국 기준 (KDS)** | KDS 14 31 10 (냉간성형강) | 한계상태설계법 / 허용응력설계법 | AISI S100 모태 도입, KS 강재 규격 반영 |

---

## 2. 직접강도법 (DSM: Direct Strength Method) 설계 공식

DSM은 FSM 해석 결과인 탄성 좌굴하중($P_{cre}, P_{crl}, P_{crd}$ 및 $M_{cre}, M_{crl}, M_{crd}$)을 입력받아 부재의 공칭강도를 직접 산정합니다.

### 2.1. 압축재 공칭강도 ($P_n$)
$$P_n = \min(P_{ne}, P_{nl}, P_{nd})$$

1. **전체 좌굴 강도 ($P_{ne}$)**:
   - 세장비 파라미터 $\lambda_c = \sqrt{P_y / P_{cre}}$ ($P_y = A_g F_y$)
   - $\lambda_c \le 1.5$ 일 때:
     $$P_{ne} = (0.658^{\lambda_c^2}) P_y$$
   - $\lambda_c > 1.5$ 일 때:
     $$P_{ne} = \left(\frac{0.877}{\lambda_c^2}\right) P_y$$

2. **국부 좌굴 강도 ($P_{nl}$)**:
   - 세장비 파라미터 $\lambda_l = \sqrt{P_{ne} / P_{crl}}$
   - $\lambda_l \le 0.776$ 일 때:
     $$P_{nl} = P_{ne}$$
   - $\lambda_l > 0.776$ 일 때:
     $$P_{nl} = \left[ 1 - 0.15 \left(\frac{P_{crl}}{P_{ne}}\right)^{0.4} \right] \left(\frac{P_{crl}}{P_{ne}}\right)^{0.4} P_{ne}$$

3. **왜곡 좌굴 강도 ($P_{nd}$)**:
   - 세장비 파라미터 $\lambda_d = \sqrt{P_y / P_{crd}}$
   - $\lambda_d \le 0.561$ 일 때:
     $$P_{nd} = P_y$$
   - $\lambda_d > 0.561$ 일 때:
     $$P_{nd} = \left[ 1 - 0.25 \left(\frac{P_{crd}}{P_y}\right)^{0.6} \right] \left(\frac{P_{crd}}{P_y}\right)^{0.6} P_y$$

---

### 2.2. 휨재 공칭강도 ($M_n$)
$$M_n = \min(M_{ne}, M_{nl}, M_{nd})$$

1. **전체 횡비틀림좌굴(LTB) 강도 ($M_{ne}$)**:
   - $M_{cre} < 0.56 M_y$: $M_{ne} = M_{cre}$
   - $0.56 M_y \le M_{cre} \le 2.78 M_y$: $M_{ne} = \frac{10}{9} M_y \left(1 - \frac{10 M_y}{36 M_{cre}}\right)$
   - $M_{cre} > 2.78 M_y$: $M_{ne} = M_y$ ($M_y = S_f F_y$)

2. **국부 좌굴 휨강도 ($M_{nl}$)**:
   - $\lambda_l = \sqrt{M_{ne} / M_{crl}}$
   - $\lambda_l \le 0.776$: $M_{nl} = M_{ne}$
   - $\lambda_l > 0.776$: $M_{nl} = \left[1 - 0.15 \left(\frac{M_{crl}}{M_{ne}}\right)^{0.4}\right] \left(\frac{M_{crl}}{M_{ne}}\right)^{0.4} M_{ne}$

3. **왜곡 좌굴 휨강도 ($M_{nd}$)**:
   - $\lambda_d = \sqrt{M_y / M_{crd}}$
   - $\lambda_d \le 0.673$: $M_{nd} = M_y$
   - $\lambda_d > 0.673$: $M_{nd} = \left[1 - 0.22 \left(\frac{M_{crd}}{M_y}\right)^{0.5}\right] \left(\frac{M_{crd}}{M_y}\right)^{0.5} M_y$

---

## 3. 전단강도 ($V_n$) 및 웨브 크리플링 ($P_{nc}$)

### 3.1. 복부판 전단강도 ($V_n$)
- 탄성 전단좌굴응력 $F_{crv} = \frac{k_v \pi^2 E}{12(1-\nu^2)(h/t)^2}$
- $h/t \le \sqrt{E k_v / F_y}$: $V_n = 0.60 A_w F_y$
- 비탄성 전단좌굴 구간: $V_n = 0.60 A_w \sqrt{E k_v F_y} / (h/t)$
- 탄성 전단좌굴 구간: $V_n = A_w F_{crv}$

### 3.2. 웨브 크리플링 강도 ($P_{nc}$)
집중하중 및 받침 지압 폭 $N$, 굽힘 내측반경 $R$, 경사각 $\theta$:
$$P_{nc} = C t^2 F_y \sin\theta \left(1 - C_R \sqrt{\frac{R}{t}}\right) \left(1 + C_N \sqrt{\frac{N}{t}}\right) \left(1 - C_h \sqrt{\frac{h}{t}}\right)$$
*(지지 조건: 1-Flange Loading, 2-Flange Loading, End/Interior 지점별 $C, C_R, C_N, C_h$ 계수 적용)*

---

## 4. 휨-압축 조합응력 P-M 상관식 (Beam-Column Interaction)

축력 $P_u$ 및 이축 휨모멘트 $M_{ux}, M_{uy}$ 동시 작용 시 검토:

$$\frac{P_u}{\phi_c P_n} + \frac{C_{mx} M_{ux}}{\phi_b M_{nx} \left(1 - \frac{P_u}{P_{Ex}}\right)} + \frac{C_{my} M_{uy}}{\phi_b M_{ny} \left(1 - \frac{P_u}{P_{Ey}}\right)} \le 1.0$$

단면 강도 검토 (지점부):
$$\frac{P_u}{\phi_c P_{n0}} + \frac{M_{ux}}{\phi_b M_{nx0}} + \frac{M_{uy}}{\phi_b M_{ny0}} \le 1.0$$

---

## 5. AISI S100 vs KDS 14 31 10 주요 차이점 대조표

| 항목 | AISI S100-16 | KDS 14 31 10 (국내 기준) |
|---|---|---|
| **설계 철학** | LRFD ($\phi$) / ASD ($\Omega$) | 한계상태설계법 ($\phi$) / 허용응력설계법 |
| **압축 저항계수 ($\phi_c$)** | LRFD: $\phi_c = 0.85$ (전체/국부), $0.85$ (왜곡) | 한계상태: $\phi_c = 0.85$ |
| **휨 저항계수 ($\phi_b$)** | LRFD: $\phi_b = 0.90$ (전체/국부), $0.90$ (왜곡) | 한계상태: $\phi_b = 0.90$ |
| **전단 저항계수 ($\phi_v$)** | LRFD: $\phi_v = 0.95 \sim 0.90$ | 한계상태: $\phi_v = 0.90$ |
| **적용 강재 규격** | ASTM A653, A1003, A1008 등 | KS D 3506 (SGC), KS D 3530 (SSC), KS D 3864 (SHN) |
| **냉간가공 강도증가** | 코너부 $F_{ya}$ 허용 ($B_c, m$ 계수식) | KDS 4.1.2 동일 수식 수용 |
