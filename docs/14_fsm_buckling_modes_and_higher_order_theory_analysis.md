# FSM 버클링 모드 해석, 고차 모드 거동 및 수치 발산 방어 이론 분석 명세서 (SSOT)

본 문서는 상용 냉간성형강 구조해석 프로그램(`CFS.exe`)의 원본 소스코드(`decompiled_src/RSG/CFS/FiniteStrip.cs`, `decompiled_src/RSG/Math/Sturm.cs`) 역공학 분석을 바탕으로, **탄성 버클링 곡선(Signature Curve)의 다중/고차 모드 작성 여부, 고차 모드 수치 발산 처리 기법, 그리고 변형 모드 판별 및 검토 차수**에 대한 정밀 분석 결과를 정리한 표준 기술 문서입니다.

---

## 1. 탄성 버클링 시그니처 곡선(Signature Curve)의 모드 작성 체계

### 1.1 CFS.exe 원본의 동작 분석
- **단일 최소 고유치(Lowest Mode) 추적**:
  - `RSG.CFS.FiniteStrip.cs`의 `FiniteStripAnalysis` 루프에서 각 반파장 길이 $L$마다 `Sturm.SturmSolve(K, KG, nDOF, LF, Y1, ref NR)`를 호출할 때, `NR = 1`로 설정하여 **오직 가장 낮은 최소 양의 고유치 1개($\lambda_{\min} > 0$)만을 산출**합니다.
  ```csharp
  // RSG.CFS.FiniteStrip.cs lines 767-786
  short nDOF = num49;
  NR = 1;
  Sturm.SturmSolve(array13, array14, nDOF, array8, array9, ref NR);
  ...
  Buckle[num62].Length = num27;
  Buckle[num62].LF = (float)array8[num90]; // 최소 양의 고유치 1개만 저장
  Buckle[num62].P = Buckle[num62].LF * num9 * num;
  Buckle[num62].Mx = Buckle[num62].LF * (num10 * num2 + num11 * num3 * num6 / num5);
  Buckle[num62].My = Buckle[num62].LF * (num11 * num3 + num10 * num2 * num6 / num4);
  ```
  - 따라서 **CFS.exe 원본의 시그니처 곡선은 전 구간에 걸쳐 오직 1차 모드(Lowest Mode) 단일 라인으로만 플롯**됩니다.

### 1.2 CFDesigner의 다중 모드(Multi-Mode) 확장 구현
- CFDesigner는 AISI S100 직접강도법(DSM)의 최신 연구 및 상세 분석 요구를 수용하여, 기본 1차 모드 곡선 외에 **2차(Mode 2), 3차(Mode 3) 고유치 곡선 오버레이**를 추가 제공합니다.
- Generalized Eigenvalue Solver(`scipy.linalg.eig` 및 정규화 의사역행렬)를 통해 각 파장별로 정렬된 상위 3개 양의 고유치를 동시에 추출하여 다중 곡선(`curves.mode_1`, `curves.mode_2`, `curves.mode_3`)을 제공합니다.

---

## 2. 휨(Bending) 상태에서의 고차 모드 수치 발산 및 방어 메커니즘

### 2.1 고차 모드 수치 발산의 원인 (Physical vs Numerical Divergence)
1. **순수 압축(Compression) vs 휨(Bending)의 기하 강성행렬 차이**:
   - **압축 상태**: 단면 전체의 수직응력이 균일 양수($\sigma = +1.0$)이므로 기하 강성행렬 $[K_g]$가 양의 정부호(Positive-Definite)에 가까워 모든 고차 고유치가 완만하게 분포합니다.
   - **휨 상태**: 상부 플랜지는 압축($+1.0$), 하부 플랜지는 인장($-1.0$)이므로 $[K_g]$는 **부정부호(Indefinite) 행렬**이 됩니다.
2. **긴 반파장($L > 500\text{ mm}$)에서의 비좌굴 막 모드(Non-buckling Membrane Mode)**:
   - 종방향 반파장 $L$이 길어질수록 탄성 강성행렬 $[K_e]$의 종방향 파수 $k_m = \pi/L$ 성분이 $1/L$로 감소합니다.
   - 이때 단면의 인장부 또는 무응력 부위의 면내 막 변형(In-plane Membrane Deformation) 자유도에서는 기하 강성이 0에 수렴하므로, 일반화 고유치 문제 $[K_e]\Phi = \lambda [K_g]\Phi$에서 **$\lambda \sim O(L^2) \rightarrow 10^5 \sim 10^6$ 수준의 비물리적 초거대 고유치가 3번째 양의 고유치로 검출**됩니다.
   - 이 거대한 수치(예: $M_{cr3} \approx 1,749,331\text{ kN}\cdot\text{m}$)가 차트에 그대로 입력되면, 차트 Y축 상한이 수백만으로 치솟아 **실제 물리적으로 중요한 1차 모드(약 $2,000\text{ kN}\cdot\text{m}$) 곡선이 차트 바닥(0선)에 완전히 찌그러지는 스케일 왜곡 현상**이 발생합니다.

### 2.2 원본 CFS.exe의 처리 방식
- 원본 CFS.exe는 `SturmSolve`에서 시프트 역반복법(Inverse Iteration with Shift)을 통해 **가장 작은 1개의 양의 고유치 $\lambda_{\min}$만을 단일 수렴**시키므로, 고차 모드의 수치적 발산이 시그니처 곡선과 UI에 전혀 영향을 주지 않습니다.

### 2.3 CFDesigner의 수치 정제 및 차트 스케일 보호 메커니즘
CFDesigner는 다중 모드를 제공하면서도 차트 왜곡을 방지하기 위해 2단계 방어 체계를 적용합니다:

1. **엔진 레이어 (`src/solver/signature_curve.py`)**:
   - 고차 모드 추출 시, Mode 1 대비 과도하게 폭증하는 비좌굴 모드를 필터링합니다:
     $$\text{Filter Condition: } \lambda_k > 25 \times \lambda_1 \quad \text{or} \quad \lambda_k > 100,000$$
   - 해당 조건을 만족하는 고차 고유치는 물리적 좌굴 영역을 벗어난 노이즈로 간주하여 차트 플롯 대상에서 안전하게 제외합니다.
2. **차트 레이어 (`src/web/static/js/chart_fsm.js`)**:
   - Mode 1의 최대값($\max M_{cr1}$ 또는 $\max P_{cr1}$)을 기준으로 가시 범위 상한을 설정합니다:
     $$\text{Upper Limit} = \max(\text{Mode 1}) \times 4.0$$
   - 상한을 초과하는 Mode 2, Mode 3 포인트는 차트 렌더링에서 스킵 처리하여, **Mode 1, Mode 2, Mode 3의 실제 물리적 좌굴 곡선(Local, Distortional, Global)이 항상 선명하고 왜곡 없이 플롯**되도록 보장합니다.

---

## 3. 변형 모드 형상(Mode Shape) 판별 및 검토 차수

### 3.1 CFS.exe 원본의 3대 핵심 좌굴 모드 판별 이론
원본 CFS.exe는 길이 $L$ 전체에 걸쳐 최소 고유벡터의 변형 에너지 비인 **`WorkRatio` ($\sqrt{W_{\text{flex}} / W_{\text{trans}}}$)**를 계산하여 다음과 같이 3대 핵심 좌굴 모드를 자동으로 분류합니다:

```csharp
// RSG.CFS.FiniteStrip.cs lines 2114-2127
public static bool IsLocalBuckling (float WorkRatio)
{
    return WorkRatio > 3f; // 휨 변형 에너지가 지배적 (로컬 좌굴)
}

public static bool IsDistortionalBuckling (float WorkRatio)
{
    return (double)WorkRatio > 0.2 && WorkRatio <= 3f; // 휨-횡변위 복합 (디스토셔널 좌굴)
}

public static bool IsGlobalBuckling (float WorkRatio)
{
    return (double)WorkRatio <= 0.2; // 횡변위/비틀림 지배적 (글로벌 좌굴)
}
```

| 좌굴 모드 (Buckling Mode) | WorkRatio 판별 기준 | 물리적 의미 및 특성 |
|---|---|---|
| **로컬 좌굴 (Local)** | $\text{WorkRatio} > 3.0$ | 판 요소 내부의 순수 면외 휨 변형 (절점 선 이동 없음) |
| **디스토셔널 좌굴 (Distortional)** | $0.2 < \text{WorkRatio} \le 3.0$ | 플랜지-립 꺾임 및 웨브 면외 변형 복합 (단면 회전/왜곡) |
| **글로벌 좌굴 (Global)** | $\text{WorkRatio} \le 0.2$ | 단면 왜곡 없이 부재 전체의 횡비틀림/휨좌굴 (Euler / FTB) |

### 3.2 2D/3D 변형 형상 렌더링 차수
1. **CFS.exe 원본의 도해 차수**:
   - 원본은 각 파장 $L$에서의 **1차 고유벡터 1개만을 `ModeShape[node, mode]`에 저장**합니다.
   - `PlotModeShape`에서 판 폭 $b$를 16분할하여 **Hermite 3차 보간 다항식**으로 면외 처짐을 계산합니다:
     $$w(s) = a_0 + a_1 s + a_2 s^2 + a_3 s^3$$
   - 3D 파형은 $z$축 방향으로 240분할하여 원근 음영(Depth Shading)을 적용합니다.
2. **CFDesigner의 다차수(Multi-Eigenmode) 변형 모드 지원**:
   - CFDesigner는 위 3대 좌굴 모드(Local, Distortional, Global) 각각에 대해 **Mode 1(1차), Mode 2(2차), Mode 3(3차)의 다중 고유벡터**를 모두 추출하여 보존합니다.
   - 사용자가 툴바에서 `Mode 1`, `Mode 2`, `Mode 3` 버튼을 선택하면, 해당 차수의 고유벡터를 반영한 2D Hermite 보간 형상 및 Three.js 3D 파동 메쉬가 실시간으로 동기화되어 전환 렌더링됩니다.

---

## 4. 요약 및 대조 비교표

| 비교 항목 | CFS.exe 레거시 원본 (C# Ground Truth) | CFDesigner 신규 웹 엔진 (Python / JS) |
|---|---|---|
| **시그니처 커브 작성 차수** | **오직 1차 모드(Lowest Mode) 단일 곡선** 작성 | **1차 기본 곡선 + 2차, 3차 다중 모드 오버레이** 곡선 작성 |
| **고차 모드 발산 처리** | `NR = 1`로 최소 양의 고유치 1개만 수렴 추적하여 발산 노이즈 원천 배제 | $\lambda_k > 25\lambda_1$ 필터링 및 Chart.js Y축 상한 보호(`maxM1 * 4.0`) |
| **변형 모드 판별 체계** | `WorkRatio` 기준 3대 모드 (Local, Distortional, Global) | 원본과 100% 동일한 `WorkRatio` 3대 모드 분류 및 임계값 산정 |
| **2D 변형 형상 도해** | 1차 모드 형상 대상 Hermite 3차 보간 다항식 (16분할) | **Mode 1, Mode 2, Mode 3 선택식 Hermite 3차 보간 다항식** (16분할) |
| **3D 파형 렌더링** | 1차 모드 형상 240분할 원근 음영 렌더링 | **Mode 1, Mode 2, Mode 3 선택식 Three.js 3D 실시간 셰이딩** 및 애니메이션 |
