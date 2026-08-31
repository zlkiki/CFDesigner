# [기술 문서 03] 단면 기하학적 성질 계산 공식 및 알고리즘 (03_section_properties.md)

---

## 1. 개요
본 문서는 CFS.exe의 `RSG.CFS.Section` 및 `Part.Geometry`에 구현된 냉간성형강 박판 단면의 **총단면(Gross) 및 유효단면(Effective) 기하학적 성질 산정 공식**을 정리합니다.

---

## 2. 총단면 성질 (Gross Section Properties)

### 2.1. 평판 요소 및 코너 원호 요소의 면적과 도심
박판 단면은 여러 개의 평판 요소(Flat Segment)와 원호 코너 요소(Corner Arc Segment)의 조합으로 구성됩니다:

1. **평판 요소 (Flat Segment, 길이 $L$, 두께 $t$, 각도 $\theta$)**:
   - 단면적: $A_i = L \cdot t$
   - 자체 단면이차모멘트:
     $$I_{x0} = \frac{t L^3 \sin^2\theta + L t^3 \cos^2\theta}{12}, \quad I_{y0} = \frac{t L^3 \cos^2\theta + L t^3 \sin^2\theta}{12}$$
     $$I_{xy0} = \frac{(L^2 - t^2) L t \sin\theta \cos\theta}{12}$$

2. **코너 원호 요소 (Corner Arc, 내측반경 $R$, 중심선반경 $R_c = R + t/2$, 중심각 $\alpha$)**:
   - 중심선 호 길이: $L_{arc} = R_c \cdot \alpha$
   - 단면적: $A_{arc} = L_{arc} \cdot t$

### 2.2. 전체 단면 특성치 조립 (평행축 정리)
전체 단면적 $A = \sum A_i$

1. **도심 좌표 (Center of Gravity, CG)**:
   $$X_{cg} = \frac{\sum A_i x_i}{A}, \quad Y_{cg} = \frac{\sum A_i y_i}{A}$$

2. **도심축 기준 단면이차모멘트 ($I_x, I_y, I_{xy}$)**:
   $$I_x = \sum \left( I_{x0,i} + A_i (y_i - Y_{cg})^2 \right)$$
   $$I_y = \sum \left( I_{y0,i} + A_i (x_i - X_{cg})^2 \right)$$
   $$I_{xy} = \sum \left( I_{xy0,i} + A_i (x_i - X_{cg})(y_i - Y_{cg}) \right)$$

3. **주축 단면이차모멘트 ($I_1, I_2$) 및 주축 회전각 ($\theta_p$)**:
   $$\theta_p = \frac{1}{2} \operatorname{atan2}(-2 I_{xy}, I_x - I_y)$$
   $$I_1, I_2 = \frac{I_x + I_y}{2} \pm \sqrt{\left(\frac{I_x - I_y}{2}\right)^2 + I_{xy}^2}$$

4. **단면회전반경 ($r_x, r_y, r_1, r_2, r_o$)**:
   $$r_x = \sqrt{\frac{I_x}{A}}, \quad r_y = \sqrt{\frac{I_y}{A}}, \quad r_o = \sqrt{r_x^2 + r_y^2 + x_o^2 + y_o^2}$$

---

## 3. 비틀림 및 뒴 성질 (Torsional & Warping Properties)

### 3.1. 생브낭 비틀림 상수 ($J$)
1. **개구단면 (Open Section)**:
   $$J = \sum \frac{1}{3} L_i t_i^3$$
2. **폐구단면 (Closed Section, 1실 박판 브레트-바스 공식)**:
   $$J = \frac{4 A_m^2}{\oint \frac{ds}{t}} = \frac{4 A_m^2}{\sum \frac{L_i}{t_i}}$$
   *(여기서 $A_m$은 중심선으로 둘러싸인 면적)*

### 3.2. 전단중심 (Shear Center: $x_o, y_o$) 및 뒴 상수 (Warping Constant: $C_w$)
개구단면에서 단위 전단류(Shear Flow) 적분을 통해 섹터 면적 함수 $\omega_n(s)$(정규화 뒴 함수)를 유도:
1. **주 섹터 좌표 (Principal Sectorial Coordinate $\omega_n$)**:
   $$\omega(s) = \int_0^s h_c(s') ds', \quad \omega_0 = \frac{1}{A} \int \omega t ds$$
   $$\omega_n(s) = \omega(s) - \omega_0 - \frac{I_{\omega y}}{I_y} x(s) - \frac{I_{\omega x}}{I_x} y(s)$$

2. **전단중심 좌표 ($x_o, y_o$)**:
   $$x_o = -\frac{I_{\omega y}}{I_x}, \quad y_o = \frac{I_{\omega x}}{I_y}$$

3. **와핑 비틀림 상수 (뒴 상수 $C_w$)**:
   $$C_w = \int_A \omega_n(s)^2 t ds = \sum \frac{t_i L_i}{3} (\omega_{n,i}^2 + \omega_{n,i} \omega_{n,j} + \omega_{n,j}^2)$$

4. **비대칭 단면 모노시메트리 계수 ($\beta_w, \beta_x, \beta_y$)**:
   $$\beta_x = \frac{1}{I_x} \int_A y (x^2 + y^2) dA - 2 y_o, \quad \beta_y = \frac{1}{I_y} \int_A x (x^2 + y^2) dA - 2 x_o$$
