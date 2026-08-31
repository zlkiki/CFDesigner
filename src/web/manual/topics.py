"""
CFDesigner Online Help Manual Content Dataset
KDS 14 31 10 & AISI S100 based Engineering Manual (15 Topics across 4 Categories)
"""

CATEGORIES = [
    {
        "id": "getting_started",
        "title": "1. 시작하기 & 웹 UI 가이드",
        "icon": "🚀",
        "topics": ["intro", "ui_layout", "wizard", "dxf_import"]
    },
    {
        "id": "section_properties",
        "title": "2. 단면 기하학적 성질 이론",
        "icon": "📐",
        "topics": ["gross_props", "torsion_props", "principal_axes"]
    },
    {
        "id": "fsm_buckling",
        "title": "3. FSM 탄성 좌굴해석 이론",
        "icon": "🔬",
        "topics": ["fsm_theory", "buckling_modes", "signature_curve"]
    },
    {
        "id": "kds_design",
        "title": "4. KDS 14 31 10 부재설계 & 계산서",
        "icon": "🏛️",
        "topics": ["kds_dsm_comp", "kds_dsm_flex", "kds_shear_crip", "kds_interaction", "report_guide"]
    }
]

TOPICS = {
    "intro": {
        "id": "intro",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "시스템 소개 및 특징",
        "summary": "CFDesigner는 냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS 14 31 10 / AISI S100 부재설계 클라우드 시스템입니다.",
        "tags": ["소개", "FSM", "KDS 14 31 10", "AISI S100", "AltDP"],
        "content_html": """
<div class="manual-article">
  <h1>시스템 소개 및 특징</h1>
  <p class="lead"><strong>CFDesigner</strong>는 냉간성형강(Cold-Formed Steel)의 임의 형상 비정형 단면에 대해 <strong>유한대판법(Finite Strip Method, FSM)</strong> 탄성 좌굴해석과 <strong>KDS 14 31 10(냉간성형강구조설계기준)</strong> 및 <strong>AISI S100 직접강도법(DSM)</strong> 설계를 원클릭으로 수행하는 차세대 SaaS 웹 엔지니어링 솔루션입니다.</p>

  <div class="callout callout-info">
    <h4>💡 핵심 개발 배경 및 목표</h4>
    <p>기존 북미 중심의 상용 CFS 프로그램의 복잡성과 로컬 환경 종속성을 극복하고, 국내 엔지니어가 친숙하게 사용할 수 있도록 현대적인 AltDP 웹 인터페이스(2D CAD 캔버스, Three.js 3D 좌굴 형상 뷰어, Chart.js 시그니처 커브) 및 KDS 한글 기준을 완벽하게 통합하였습니다.</p>
  </div>

  <h2>주요 기능 및 시스템 특징</h2>
  <div class="feature-grid">
    <div class="feature-card">
      <div class="feature-icon">📐</div>
      <h3>AutoCAD DXF & 마법사</h3>
      <p>표준 6종 단면(C, Z, 모자형, 각형관, L형강, 데크) 파라메트릭 생성 및 비정형 DXF 폴리라인 자동 메싱.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">⚙️</div>
      <h3>단면 성질 정밀 해석</h3>
      <p>총단면적($A_g$), 도심($C_G$), 생브낭 비틀림($J$), 섹터모멘트 기반 뒴상수($C_w$), 전단중심($S_C$), 주축($I_1, I_2$).</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">🔬</div>
      <h3>FSM 탄성 좌굴 해석</h3>
      <p>길이방향 사인 조화급수 전개와 엄밀 강성행렬($[K_e], [K_g]$) 조립을 통한 국부/왜곡/전체 좌굴하중 산정.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">🏛️</div>
      <h3>KDS 14 31 10 부재 설계</h3>
      <p>직접강도법(DSM) 기반 압축($P_n$), 휨($M_n$), 전단($V_n$), 웨브 크리플링($P_{nc}$), P-M 조합응력 및 A4 계산서 출력.</p>
    </div>
  </div>

  <h2>시스템 아키텍처 개요</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>계층 (Layer)</th>
        <th>기술 스택</th>
        <th>역할 및 기능</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>프론트엔드 UI</strong></td>
        <td>HTML5, Vanilla CSS (AltDP 테마), Chart.js, Three.js</td>
        <td>2D 단면 작도 캔버스, 3D 좌굴모드 시각화, D/C 게이지 및 반응형 대시보드</td>
      </tr>
      <tr>
        <td><strong>백엔드 API</strong></td>
        <td>FastAPI, Uvicorn (Python 3.10+)</td>
        <td>단면 해석, FSM 수치해석, KDS 설계식 연산 및 JSON REST API 서빙</td>
      </tr>
      <tr>
        <td><strong>공학 해석 엔진</strong></td>
        <td>NumPy, SciPy, ezdxf</td>
        <td>고유치 행렬 해석($[K_e]\\{\\delta\\} = \\lambda [K_g]\\{\\delta\\}$), 단면 적분 및 DXF 파싱</td>
      </tr>
    </tbody>
  </table>
</div>
"""
    },
    "ui_layout": {
        "id": "ui_layout",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "웹 대시보드 인터페이스 안내",
        "summary": "좌측 입력 패널, 상단 2D CAD 캔버스, 우측 3D 뷰어 및 하단 시그니처 커브/부재설계 D/C 패널로 구성된 4분할 레이아웃 가이드입니다.",
        "tags": ["UI", "레이아웃", "대시보드", "인터페이스", "단면뷰어"],
        "content_html": """
<div class="manual-article">
  <h1>웹 대시보드 인터페이스 안내</h1>
  <p class="lead">CFDesigner의 작업 화면은 고효율 구조 설계를 위해 <strong>4분할 인터랙티브 작업 공간</strong>으로 구성되어 있습니다.</p>

  <h2>4분할 화면 구성도</h2>
  <div class="ui-diagram-box">
    <div class="ui-block ui-sidebar-box">
      <strong>좌측 제어 사이드바</strong>
      <ul>
        <li>📐 단면 생성 탭 (마법사 / DXF)</li>
        <li>⚙️ 부재 설계 탭 (부재길이, 지점조건, 하중, 재질)</li>
      </ul>
    </div>
    <div class="ui-main-area">
      <div class="ui-block ui-canvas-box">
        <strong>2D 단면 캔버스</strong> (도심, 전단중심, 주축, 절점 번호 시각화)
      </div>
      <div class="ui-block ui-three-box">
        <strong>Three.js 3D 뷰어</strong> (부재 입체 압출 및 좌굴 변형 형상)
      </div>
      <div class="ui-block ui-chart-box">
        <strong>FSM 시그니처 커브 & KDS 부재설계 결과 패널</strong>
      </div>
    </div>
  </div>

  <h2>주요 인터페이스 영역 설명</h2>
  <ol class="step-list">
    <li>
      <strong>상단 헤더 (App Header)</strong>
      <p>시스템 로고, KDS 규준 배지, 테마 전환(다크/라이트) 버튼, <code>❓ 온라인 도움말</code> 및 <code>📄 A4 구조계산서 출력</code> 버튼이 배치되어 있습니다.</p>
    </li>
    <li>
      <strong>좌측 제어 사이드바 (Left Sidebar)</strong>
      <p><strong>[단면 생성]</strong> 탭에서 파라메트릭 형상 치수를 입력하거나 DXF 파일을 업로드하고, <strong>[부재 설계]</strong> 탭에서 부재 길이($L_x, L_y, L_t$), 유효좌굴길이계수($K_x, K_y, K_t$), 설계하중($P_u, M_{ux}, M_{uy}, V_u$), 강재 물성치($F_y, E$)를 설정합니다.</p>
    </li>
    <li>
      <strong>2D 단면 캔버스 (Canvas Section View)</strong>
      <p>단면의 절점(Node)과 요소(Element)를 실시간 렌더링하며, 도심(빨간 점), 전단중심(파란 점), 주축(점선)을 직관적으로 확인할 수 있습니다.</p>
    </li>
    <li>
      <strong>3D 뷰어 & 시그니처 커브</strong>
      <p>FSM 해석 실행 시 반파장($L$)에 따른 좌굴하중곡선(Chart.js)이 갱신되며, 국부/왜곡/전체 좌굴 모드의 3D 파동 변형 형상을 자유롭게 회전/확대하여 검토할 수 있습니다.</p>
    </li>
  </ol>
</div>
"""
    },
    "wizard": {
        "id": "wizard",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "단면 마법사 (Section Wizard)",
        "summary": "C형강, Z형강, 모자형, 각형강관, L형강, 데크플레이트 6종 표준 단면의 파라메트릭 생성 가이드입니다.",
        "tags": ["단면마법사", "C형강", "Z형강", "모자형강", "각형강관", "L형강", "데크플레이트"],
        "content_html": """
<div class="manual-article">
  <h1>단면 마법사 (Section Wizard)</h1>
  <p class="lead">단면 마법사는 냉간성형강에서 가장 널리 사용되는 6가지 표준 형상에 대해 치수 변수만 입력하여 즉시 절점 및 요소 모델을 생성하는 도구입니다.</p>

  <h2>지원 단면 형상 및 파라미터</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>단면 유형</th>
        <th>형상 명칭</th>
        <th>주요 입력 파라미터</th>
        <th>특징 및 용도</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>C</strong></td>
        <td>C형강 (Lipped Channel)</td>
        <td>$H$(높이), $B$(폭), $D$(립 길이), $t$(두께), $R$(모서리 반경)</td>
        <td>중도리(Purlin), 샛기둥(Stud), 도리용으로 가장 널리 사용</td>
      </tr>
      <tr>
        <td><strong>Z</strong></td>
        <td>Z형강 (Lipped Z-Section)</td>
        <td>$H$(높이), $B$(폭), $D$(립), $t$(두께), $\\theta$(플랜지 경사각)</td>
        <td>경사 지붕 중도리용으로 중첩(Lapping) 시공 용이</td>
      </tr>
      <tr>
        <td><strong>HAT</strong></td>
        <td>모자형강 (Hat Channel)</td>
        <td>$H$(높이), $B_{top}$(상부폭), $B_{bot}$(하부폭), $D$(립), $t$</td>
        <td>천장 받침재, 태양광 구조물 트랙</td>
      </tr>
      <tr>
        <td><strong>TUBE</strong></td>
        <td>폐단면 각형강관 (Box Tube)</td>
        <td>$H$(높이), $B$(폭), $t$(두께), $R$(외부 반경)</td>
        <td>비틀림 강성이 우수한 기둥 및 보 부재</td>
      </tr>
      <tr>
        <td><strong>ANGLE</strong></td>
        <td>L형강 (Angle Section)</td>
        <td>$H$(수직 레그), $B$(수평 레그), $t$(두께), $D$(립 옵션)</td>
        <td>트러스 사재, 가새(Bracing) 부재</td>
      </tr>
      <tr>
        <td><strong>DECK</strong></td>
        <td>골형 데크 (Deck Plate)</td>
        <td>$H$(골높이), $P$(피치), $W_{top}$(상골폭), $W_{bot}$(하골폭), $t$</td>
        <td>바닥 슬래브용 구조용 데크플레이트</td>
      </tr>
    </tbody>
  </table>

  <div class="callout callout-warning">
    <h4>⚠️ 절점 분할 및 곡률(Bend) 메싱 주의사항</h4>
    <p>곡률 반경($R$)이 있는 모서리부는 FSM 해석 정밀도를 위해 자동으로 원호 다각형(Bulge 분할)으로 메싱됩니다. 판 두께($t$)는 모든 요소에 균일하게 적용됩니다.</p>
  </div>
</div>
"""
    },
    "dxf_import": {
        "id": "dxf_import",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "AutoCAD DXF 가져오기",
        "summary": "2D Polyline 작도 규칙, 선폭(Global Width) 두께 자동 추출, 원호(Bulge) 분할 메싱 규칙을 안내합니다.",
        "tags": ["DXF", "AutoCAD", "폴리라인", "Polyline", "비정형단면", "CAD"],
        "content_html": """
<div class="manual-article">
  <h1>AutoCAD DXF 가져오기</h1>
  <p class="lead">AutoCAD 또는 일반 CAD 소프트웨어에서 작도한 <code>.dxf</code> 도면 파일을 업로드하여 복잡한 비정형 냉간성형강 단면을 해석 모델로 자동 변환할 수 있습니다.</p>

  <h2>CAD 작도 및 DXF 파일 작성 규칙</h2>
  <ol class="step-list">
    <li>
      <strong>2D 경량 폴리라인(LWPOLYLINE) 사용</strong>
      <p>단면의 중심선(Centerline)을 따라 연속된 단일 <code>LWPOLYLINE</code> 또는 <code>POLYLINE</code>으로 작도합니다.</p>
    </li>
    <li>
      <strong>전역 선폭(Global Width)을 통한 두께 지정</strong>
      <p>폴리라인의 특성(Properties)에서 <strong>전역 폭(Global Width)</strong>을 단면 두께($t$)로 지정하면, CFDesigner가 이를 자동으로 인식하여 요소 두께로 설정합니다. 지정되지 않은 경우 UI의 기본 두께가 적용됩니다.</p>
    </li>
    <li>
      <strong>곡선 구간(Arc / Bulge) 처리</strong>
      <p>폴리라인에 포함된 Bulge(원호 세그먼트)는 FSM 해석 요소 분할 기준에 따라 자동으로 $3\\sim 5$개의 선형 요소로 정밀 분할 메싱됩니다.</p>
    </li>
  </ol>

  <div class="callout callout-info">
    <h4>💡 DXF 파싱 및 절점 정규화</h4>
    <p>업로드된 CAD 도면의 절대 좌표계는 도심$(0,0)$ 기준으로 자동 평행이동되며, 중복 절점 제거(Tolerance 0.01mm) 및 위상 연결성 검증이 수행됩니다.</p>
  </div>
</div>
"""
    },
    "gross_props": {
        "id": "gross_props",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "총단면 성질 (Gross Properties)",
        "summary": "총단면적, 도심 좌표, 단면 2차모멘트, 단면회전반경의 수치해석 공식 및 알고리즘을 설명합니다.",
        "tags": ["총단면성질", "Gross", "단면적", "단면2차모멘트", "도심", "회전반경"],
        "content_html": """
<div class="manual-article">
  <h1>총단면 성질 (Gross Properties)</h1>
  <p class="lead">냉간성형강 단면은 얇은 박판 요소들의 조합으로 구성되므로, 중심선 기반 선적분 및 요소 두께($t$)의 고차항을 고려한 수치적분을 통해 총단면 기하 특성치를 산정합니다.</p>

  <h2>1. 총단면적 ($A_g$) 및 도심 ($x_{cg}, y_{cg}$)</h2>
  <p>각 요소 $i$의 길이 $L_i$, 두께 $t_i$, 중심 좌표 $(\\bar{x}_i, \\bar{y}_i)$에 대해:</p>
  <div class="math-block">
    $$A_g = \\sum_{i=1}^{N} L_i \\cdot t_i$$
    $$x_{cg} = \\frac{\\sum L_i t_i \\bar{x}_i}{A_g}, \\quad y_{cg} = \\frac{\\sum L_i t_i \\bar{y}_i}{A_g}$$
  </div>

  <h2>2. 단면 2차모멘트 ($I_x, I_y, I_{xy}$)</h2>
  <p>도심축에 대한 단면 2차모멘트는 평행축 정리(Parallel Axis Theorem)를 적용하여 산출합니다.</p>
  <div class="math-block">
    $$I_x = \\sum_{i=1}^{N} \\left( \\frac{t_i L_i^3 \\sin^2 \\theta_i}{12} + \\frac{L_i t_i^3 \\cos^2 \\theta_i}{12} + L_i t_i (\\bar{y}_i - y_{cg})^2 \\right)$$
    $$I_y = \\sum_{i=1}^{N} \\left( \\frac{t_i L_i^3 \\cos^2 \\theta_i}{12} + \\frac{L_i t_i^3 \\sin^2 \\theta_i}{12} + L_i t_i (\\bar{x}_i - x_{cg})^2 \\right)$$
    $$I_{xy} = \\sum_{i=1}^{N} \\left( \\frac{t_i L_i (L_i^2 - t_i^2) \\sin 2\\theta_i}{24} + L_i t_i (\\bar{x}_i - x_{cg})(\\bar{y}_i - y_{cg}) \\right)$$
  </div>

  <h2>3. 단면회전반경 ($r_x, r_y, r_o$)</h2>
  <div class="math-block">
    $$r_x = \\sqrt{\\frac{I_x}{A_g}}, \\quad r_y = \\sqrt{\\frac{I_y}{A_g}}, \\quad r_o = \\sqrt{r_x^2 + r_y^2 + x_o^2 + y_o^2}$$
  </div>
</div>
"""
    },
    "torsion_props": {
        "id": "torsion_props",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "비틀림 및 뒴상수 (J, Cw, xo, yo)",
        "summary": "생브낭 순수 비틀림상수(J), 섹터 모멘트 기반 뒴상수(Cw) 및 전단중심(Shear Center) 좌표 계산 이론입니다.",
        "tags": ["비틀림", "생브낭", "뒴상수", "전단중심", "J", "Cw", "ShearCenter"],
        "content_html": """
<div class="manual-article">
  <h1>비틀림 및 뒴상수 ($J, C_w, x_o, y_o$)</h1>
  <p class="lead">냉간성형강과 같은 개단면(Open section) 박판 구조물은 비틀림 및 뒴(Warping)에 취약하므로, 비틀림 상수 $J$와 뒴상수 $C_w$, 전단중심 $(x_o, y_o)$의 정밀 산정이 필수적입니다.</p>

  <h2>1. 생브낭 비틀림 상수 ($J$)</h2>
  <p>개단면 박판 요소 집합에 대해 다음과 같이 산정됩니다.</p>
  <div class="math-block">
    $$J = \\sum_{i=1}^{N} \\frac{L_i t_i^3}{3}$$
  </div>

  <h2>2. 섹터 면적 좌표 (Sectorial Coordinate, $\\omega$) 및 전단중심</h2>
  <p>단면 임의 절점을 기준점 $P_0$로 잡고 각 절점 $k$의 섹터 면적 $\\omega_k$를 누적 계산합니다:</p>
  <div class="math-block">
    $$\\omega_k = \\omega_{k-1} + (x_{k-1} y_k - x_k y_{k-1})$$
  </div>
  <p>전단중심 $(x_o, y_o)$는 굽힘과 비틀림의 연성이 발생하지 않는 하중 작용점으로서 다음과 같이 유도됩니다:</p>
  <div class="math-block">
    $$x_o = \\frac{I_y I_{\\omega x} - I_{xy} I_{\\omega y}}{I_x I_y - I_{xy}^2}, \\quad y_o = \\frac{I_x I_{\\omega y} - I_{xy} I_{\\omega x}}{I_x I_y - I_{xy}^2}$$
  </div>

  <h2>3. 뒴상수 (Warping Constant, $C_w$)</h2>
  <p>주섹터 면적 $\\omega_n = \\omega - \\bar{\\omega} - y_o x + x_o y$ 에 대해 단면을 따라 적분합니다:</p>
  <div class="math-block">
    $$C_w = \\int_{A} \\omega_n^2 \\, dA = \\sum_{i=1}^{N} \\frac{t_i L_i}{3} (\\omega_{n,i}^2 + \\omega_{n,i} \\omega_{n,i+1} + \\omega_{n,i+1}^2)$$
  </div>
</div>
"""
    },
    "principal_axes": {
        "id": "principal_axes",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "주축 회전 해석 (I1, I2, θp)",
        "summary": "Mohr 원에 기초한 비대칭 단면의 주축 각도(θp) 및 주단면 2차모멘트 산정 이론입니다.",
        "tags": ["주축", "Mohr원", "단면2차모멘트", "주축각도", "비대칭단면"],
        "content_html": """
<div class="manual-article">
  <h1>주축 회전 해석 ($I_1, I_2, \\theta_p$)</h1>
  <p class="lead">Z형강, L형강 및 비대칭 형상 단면은 기하학적 축($x, y$)과 주축($1, 2$)이 일치하지 않으므로, 주축 각도 $\\theta_p$만큼 단면을 회전하여 최대/최소 주단면 2차모멘트를 계산해야 합니다.</p>

  <h2>1. 주축 각도 (Principal Axis Angle, $\\theta_p$)</h2>
  <div class="math-block">
    $$\\tan 2\\theta_p = \\frac{-2 I_{xy}}{I_x - I_y} \\implies \\theta_p = \\frac{1}{2} \\text{atan2}(-2I_{xy}, I_x - I_y)$$
  </div>

  <h2>2. 주단면 2차모멘트 ($I_1, I_2$)</h2>
  <div class="math-block">
    $$I_1 = \\frac{I_x + I_y}{2} + \\sqrt{\\left(\\frac{I_x - I_y}{2}\\right)^2 + I_{xy}^2}$$
    $$I_2 = \\frac{I_x + I_y}{2} - \\sqrt{\\left(\\frac{I_x - I_y}{2}\\right)^2 + I_{xy}^2}$$
  </div>

  <div class="callout callout-info">
    <h4>💡 주축 기반 휨응력 해석의 중요성</h4>
    <p>KDS 14 31 10 및 AISI S100 기준에 따라 비대칭 단면의 휨 부재 검토 시에는 주축 $I_1, I_2$ 기준으로 응력을 분해하여 좌굴하중을 산정합니다.</p>
  </div>
</div>
"""
    },
    "fsm_theory": {
        "id": "fsm_theory",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "유한대판법(FSM) 원리 및 강성행렬",
        "summary": "FSM의 조화급수 전개, 탄성 강성행렬([Ke]) 및 기하 강성행렬([Kg]) 유도와 일반화 고유치 해석 원리입니다.",
        "tags": ["FSM", "유한대판법", "탄성강성행렬", "기하강성행렬", "고유치해석", "좌굴"],
        "content_html": """
<div class="manual-article">
  <h1>유한대판법(FSM) 원리 및 강성행렬</h1>
  <p class="lead"><strong>유한대판법(Finite Strip Method, FSM)</strong>은 일정 단면을 갖는 박판 구조물의 길이 방향 변위를 정현파(Sine series)로 전개하여 2차원 판 요소를 1차원 절선(Nodal Line) 문제로 단순화하는 수치해석 기법입니다.</p>

  <h2>1. 변위 함수 전개 (Displacement Function)</h2>
  <p>절선 $i$와 $j$로 둘러싸인 스트립 요소의 변위 필드는 면내 변위 $(u, v)$ 및 면외 휨 변위 $w$로 구성됩니다:</p>
  <div class="math-block">
    $$u(x, y) = \\sum_{m=1}^{M} N_u(x) \\cdot u_m \\sin\\left(\\frac{m \\pi y}{L}\\right)$$
    $$v(x, y) = \\sum_{m=1}^{M} N_v(x) \\cdot v_m \\cos\\left(\\frac{m \\pi y}{L}\\right)$$
    $$w(x, y) = \\sum_{m=1}^{M} N_w(x) \\cdot w_m \\sin\\left(\\frac{m \\pi y}{L}\\right)$$
  </div>

  <h2>2. 탄성 및 기하 강성행렬 ($[K_e], [K_g]$)</h2>
  <p>각 스트립 요소에 대해 가상일의 원리를 적용하여 탄성 강성행렬 $[K_e]$ 및 초기 응력에 의한 기하 강성행렬 $[K_g]$를 도출합니다.</p>
  <div class="math-block">
    $$[K_e] = \\int_V [B]^T [D] [B] \\, dV, \\quad [K_g] = \\int_V [G]^T [\\sigma_0] [G] \\, dV$$
  </div>

  <h2>3. 일반화 고유치 문제 (Generalized Eigenvalue Problem)</h2>
  <p>전체 구조 강성행렬을 조립한 후, 임계 좌굴 계수 $\\lambda_{cr}$ 및 좌굴 모드 형상 $\\{\\delta\\}$를 고유치 해석으로 구합니다:</p>
  <div class="math-block">
    $$([K_e] - \\lambda [K_g]) \\{\\delta\\} = \\mathbf{0} \\implies \\det([K_e] - \\lambda [K_g]) = 0$$
  </div>
</div>
"""
    },
    "buckling_modes": {
        "id": "buckling_modes",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "3대 탄성 좌굴모드 판별법",
        "summary": "국부 좌굴(Local), 왜곡 좌굴(Distortional), 전체 좌굴(Global)의 역학적 거동 특성과 자동 판별 알고리즘입니다.",
        "tags": ["국부좌굴", "왜곡좌굴", "전체좌굴", "좌굴모드", "Local", "Distortional", "Global"],
        "content_html": """
<div class="manual-article">
  <h1>3대 탄성 좌굴모드 판별법</h1>
  <p class="lead">냉간성형강의 직접강도법(DSM) 설계를 위해서는 FSM 시그니처 커브로부터 3대 탄성 좌굴하중 ($P_{crl}, P_{crd}, P_{cre}$)을 정확히 판별해야 합니다.</p>

  <h2>3대 좌굴모드 비교표</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>좌굴 모드</th>
        <th>기호 (하중/모멘트)</th>
        <th>반파장 범위 ($L$)</th>
        <th>변형 거동 및 특징</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>국부 좌굴 (Local)</strong></td>
        <td>$P_{crl}, M_{crl}$</td>
        <td>단면 판폭 수준 ($30 \\sim 150\\text{ mm}$)</td>
        <td>절점 선(Nodal Line) 이동 없이 개별 판요소만 면외 휨 변형 발생</td>
      </tr>
      <tr>
        <td><strong>왜곡 좌굴 (Distortional)</strong></td>
        <td>$P_{crd}, M_{crd}$</td>
        <td>중간 길이 ($150 \\sim 800\\text{ mm}$)</td>
        <td>보강 립(Lip) 및 플랜지가 회전하며 단면의 형상 자체가 왜곡</td>
      </tr>
      <tr>
        <td><strong>전체 좌굴 (Global)</strong></td>
        <td>$P_{cre}, M_{cre}$</td>
        <td>부재 전체 길이 ($1000\\text{ mm}\\sim$)</td>
        <td>단면 형상 변화 없이 휨좌굴(Euler), 비틀림좌굴, 횡비틀림좌굴(LTB) 발생</td>
      </tr>
    </tbody>
  </table>

  <div class="callout callout-info">
    <h4>💡 모드 판별 알고리즘 (Signature Curve 극소점)</h4>
    <p>CFDesigner는 반파장 $L$을 로그 스케일로 스위핑하며 생성된 시그니처 커브에서 첫 번째 극소점을 $P_{crl}$, 두 번째 극소점을 $P_{crd}$, 장파장 구간의 점근값을 $P_{cre}$로 자동 추출합니다.</p>
  </div>
</div>
"""
    },
    "signature_curve": {
        "id": "signature_curve",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "시그니처 커브 해석 및 3D 뷰어",
        "summary": "반파장 L에 따른 좌굴하중곡선 분석법 및 Three.js 기반 3차원 좌굴 모드 형상 시각화 도구 사용법입니다.",
        "tags": ["시그니처커브", "3D뷰어", "Three.js", "Chart.js", "좌굴곡선"],
        "content_html": """
<div class="manual-article">
  <h1>시그니처 커브 해석 및 3D 뷰어</h1>
  <p class="lead">FSM 해석을 수행하면 하단에 <strong>좌굴하중곡선(Signature Curve)</strong> 그래프가 생성되며, 그래프의 특정 파장을 클릭하여 <strong>Three.js 3D 뷰어</strong>에서 입체 좌굴 변형을 실시간으로 관찰할 수 있습니다.</p>

  <h2>1. 시그니처 커브 차트 해석</h2>
  <ul>
    <li><strong>X축 (반파장 $L$, mm)</strong>: $10\\text{ mm}$부터 $10,000\\text{ mm}$까지 로그 스케일로 연속 해석.</li>
    <li><strong>Y축 (좌굴하중비 $\\lambda = P_{cr}/P_y$)</strong>: 항복하중 대비 탄성 좌굴하중의 비율. $\\lambda < 1.0$인 경우 항복 전에 탄성 좌굴이 선행함을 의미.</li>
  </ul>

  <h2>2. Three.js 3D 모드 형상 시각화 인터랙션</h2>
  <div class="feature-grid">
    <div class="feature-card">
      <div class="feature-icon">🔄</div>
      <h3>3차원 회전 & 확대</h3>
      <p>마우스 좌클릭 드래그로 자유 회전, 휠 스크롤로 줌 인/아웃, 우클릭 드래그로 시점 이동(Pan).</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">🌊</div>
      <h3>정현파 변형 애니메이션</h3>
      <p>길이 방향 $\\sin(m\\pi y / L)$ 파동 함수를 반영하여 압축 및 휨 좌굴 시의 실시간 파형을 렌더링.</p>
    </div>
  </div>
</div>
"""
    },
    "kds_dsm_comp": {
        "id": "kds_dsm_comp",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "압축부재 설계 (KDS 14 31 10 4.1)",
        "summary": "KDS 14 31 10 4.1에 따른 공칭압축강도(Pn) 산정식 (전좌굴 Pne, 국부좌굴 Pnl, 왜곡좌굴 Pnd) 해설입니다.",
        "tags": ["KDS 14 31 10", "압축설계", "DSM", "직접강도법", "Pn", "Pne", "Pnl", "Pnd"],
        "content_html": """
<div class="manual-article">
  <h1>압축부재 설계 (KDS 14 31 10 4.1)</h1>
  <p class="lead">KDS 14 31 10 제4장 직접강도법(DSM)에 따른 중심압축재의 설계압축강도 $\\phi_c P_n$ ($\\\\phi_c = 0.85$)는 <strong>전좌굴강도($P_{ne}$), 국부좌굴강도($P_{nl}$), 왜곡좌굴강도($P_{nd}$)</strong>의 최솟값으로 산정됩니다.</p>

  <h2>1. 전체좌굴강도 ($P_{ne}$)</h2>
  <p>탄성 전체좌굴하중 $P_{cre}$에 대해 세장비 매개변수 $\\lambda_c = \\sqrt{P_y / P_{cre}}$ ($P_y = A_g F_y$):</p>
  <div class="math-block">
    $$P_{ne} = \\begin{cases} (0.658^{\\lambda_c^2}) P_y & (\\lambda_c \\le 1.5) \\\\[6pt] \\left(\\dfrac{0.877}{\\lambda_c^2}\\right) P_y & (\\lambda_c > 1.5) \\end{cases}$$
  </div>

  <h2>2. 국부좌굴강도 ($P_{nl}$)</h2>
  <p>탄성 국부좌굴하중 $P_{crl}$에 대해 $\\lambda_l = \\sqrt{P_{ne} / P_{crl}}$:</p>
  <div class="math-block">
    $$P_{nl} = \\begin{cases} P_{ne} & (\\lambda_l \\le 0.776) \\\\[6pt] \\left[1 - 0.15 \\left(\\dfrac{P_{crl}}{P_{ne}}\\right)^{0.4}\\right] \\left(\\dfrac{P_{crl}}{P_{ne}}\\right)^{0.4} P_{ne} & (\\lambda_l > 0.776) \\end{cases}$$
  </div>

  <h2>3. 왜곡좌굴강도 ($P_{nd}$)</h2>
  <p>탄성 왜곡좌굴하중 $P_{crd}$에 대해 $\\lambda_d = \\sqrt{P_y / P_{crd}}$:</p>
  <div class="math-block">
    $$P_{nd} = \\begin{cases} P_y & (\\lambda_d \\le 0.561) \\\\[6pt] \\left[1 - 0.25 \\left(\\dfrac{P_{crd}}{P_y}\\right)^{0.6}\\right] \\left(\\dfrac{P_{crd}}{P_y}\\right)^{0.6} P_y & (\\lambda_d > 0.561) \\end{cases}$$
  </div>

  <h2>4. 최종 공칭압축강도 ($P_n$)</h2>
  <div class="math-block">
    $$P_n = \\min(P_{ne}, P_{nl}, P_{nd})$$
    $$\\text{설계압축강도 } \\phi_c P_n = 0.85 \\cdot P_n$$
  </div>
</div>
"""
    },
    "kds_dsm_flex": {
        "id": "kds_dsm_flex",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "휨부재 설계 (KDS 14 31 10 4.2)",
        "summary": "KDS 14 31 10 4.2에 따른 공칭휨강도(Mn) 산정식 (횡비틀림좌굴 Mne, 국부좌굴 Mnl, 왜곡좌굴 Mnd) 해설입니다.",
        "tags": ["KDS 14 31 10", "휨설계", "DSM", "Mn", "Mne", "Mnl", "Mnd", "횡비틀림좌굴"],
        "content_html": """
<div class="manual-article">
  <h1>휨부재 설계 (KDS 14 31 10 4.2)</h1>
  <p class="lead">휨부재의 설계휨강도 $\\phi_b M_n$ ($\\\\phi_b = 0.90$)은 <strong>횡비틀림 전체좌굴강도($M_{ne}$), 국부좌굴강도($M_{nl}$), 왜곡좌굴강도($M_{nd}$)</strong> 중 최솟값으로 결정됩니다.</p>

  <h2>1. 횡비틀림 전체좌굴강도 ($M_{ne}$)</h2>
  <p>항복모멘트 $M_y = S_f F_y$ 및 탄성 횡비틀림좌굴모멘트 $M_{cre}$에 대해:</p>
  <div class="math-block">
    $$M_{ne} = \\begin{cases} M_y & (M_{cre} \\ge 2.78 M_y) \\\\[6pt] \\dfrac{10}{9} M_y \\left(1 - \\dfrac{10 M_y}{36 M_{cre}}\\right) & (2.78 M_y > M_{cre} > 0.56 M_y) \\\\[6pt] M_{cre} & (M_{cre} \\le 0.56 M_y) \\end{cases}$$
  </div>

  <h2>2. 국부좌굴강도 ($M_{nl}$)</h2>
  <p>탄성 국부좌굴모멘트 $M_{crl}$에 대해 $\\lambda_l = \\sqrt{M_{ne} / M_{crl}}$:</p>
  <div class="math-block">
    $$M_{nl} = \\begin{cases} M_{ne} & (\\lambda_l \\le 0.776) \\\\[6pt] \\left[1 - 0.15 \\left(\\dfrac{M_{crl}}{M_{ne}}\\right)^{0.4}\\right] \\left(\\dfrac{M_{crl}}{M_{ne}}\\right)^{0.4} M_{ne} & (\\lambda_l > 0.776) \\end{cases}$$
  </div>

  <h2>3. 왜곡좌굴강도 ($M_{nd}$)</h2>
  <p>탄성 왜곡좌굴모멘트 $M_{crd}$에 대해 $\\lambda_d = \\sqrt{M_y / M_{crd}}$:</p>
  <div class="math-block">
    $$M_{nd} = \\begin{cases} M_y & (\\lambda_d \\le 0.673) \\\\[6pt] \\left[1 - 0.22 \\left(\\dfrac{M_{crd}}{M_y}\\right)^{0.5}\\right] \\left(\\dfrac{M_{crd}}{M_y}\\right)^{0.5} M_y & (\\lambda_d > 0.673) \\end{cases}$$
  </div>
</div>
"""
    },
    "kds_shear_crip": {
        "id": "kds_shear_crip",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "복부판 전단 및 웨브 크리플링",
        "summary": "KDS 14 31 10 4.3 복부판 전단강도(Vn) 및 4.4 웨브 크리플링(Pnc) 집중하중 검토 수식집입니다.",
        "tags": ["전단강도", "웨브크리플링", "Vn", "Pnc", "KDS 14 31 10"],
        "content_html": """
<div class="manual-article">
  <h1>복부판 전단 및 웨브 크리플링</h1>
  <p class="lead">보 부재의 단부 지점 및 집중하중 작용점에서는 복부판의 <strong>전단강도($V_n$)</strong>와 <strong>웨브 크리플링(Web Crippling, $P_{nc}$)</strong>에 대한 국부 압궤 검토를 수행해야 합니다.</p>

  <h2>1. 복부판 공칭전단강도 ($V_n$, KDS 14 31 10 4.3)</h2>
  <p>복부판 높이 $h$, 두께 $t$, 전단좌굴계수 $k_v$에 대해 탄성 전단좌굴응력 $F_{crv}$를 산정합니다:</p>
  <div class="math-block">
    $$V_n = A_w F_v = (h \\cdot t) F_v$$
    $$F_v = \\begin{cases} 0.60 F_y & (\\lambda_v \\le 0.815) \\\\[6pt] 0.60 \\sqrt{E k_v F_y / (h/t)} & (0.815 < \\lambda_v \\le 1.227) \\\\[6pt] \\dfrac{\\pi^2 E k_v}{12(1-\\nu^2)(h/t)^2} & (\\lambda_v > 1.227) \\end{cases}$$
  </div>

  <h2>2. 웨브 크리플링 강도 ($P_{nc}$, KDS 14 31 10 4.4)</h2>
  <p>지압길이 $N$, 굽힘내부반경 $R$, 복부판 경사각 $\\theta$에 대해:</p>
  <div class="math-block">
    $$P_{nc} = C t^2 F_y \\sin\\theta \\left(1 - C_R \\sqrt{\\frac{R}{t}}\\right) \\left(1 + C_N \\sqrt{\\frac{N}{t}}\\right) \\left(1 - C_h \\sqrt{\\frac{h}{t}}\\right)$$
  </div>
</div>
"""
    },
    "kds_interaction": {
        "id": "kds_interaction",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "휨-압축 P-M 조합응력 검토",
        "summary": "KDS 14 31 10 4.5 식 (1.4-1)에 따른 휨-압축 2축 모멘트 조합응력 상관식 및 D/C 비 판별법입니다.",
        "tags": ["PM조합", "상관식", "조합응력", "DC비", "안전율", "KDS 14 31 10"],
        "content_html": """
<div class="manual-article">
  <h1>휨-압축 P-M 조합응력 검토</h1>
  <p class="lead">축력($P_u$)과 2축 휨모멘트($M_{ux}, M_{uy}$)가 동시에 작용하는 압축-휨 부재(Beam-Column)는 KDS 14 31 10 4.5 상관식에 의해 안전성을 검토합니다.</p>

  <h2>KDS 14 31 10 4.5 P-M 상관식</h2>
  <div class="math-block">
    $$\\text{D/C Ratio} = \\frac{P_u}{\\phi_c P_n} + \\frac{C_{mx} M_{ux}}{\\phi_b M_{nx} \\left(1 - \\dfrac{P_u}{P_{ex}}\\right)} + \\frac{C_{my} M_{uy}}{\\phi_b M_{ny} \\left(1 - \\dfrac{P_u}{P_{ey}}\\right)} \\le 1.0$$
  </div>

  <h2>D/C Ratio (소요강도/설계강도 비) 판정 기준</h2>
  <div class="status-box-grid">
    <div class="status-box status-safe">
      <h3>🟢 OK (안전)</h3>
      <p><strong>D/C $\\le 0.90$</strong>: 충분한 안전율을 확보한 경제적 단면</p>
    </div>
    <div class="status-box status-warn">
      <h3>🟡 WARNING (주의)</h3>
      <p><strong>$0.90 < \\text{D/C} \\le 1.00$</strong>: 허용 내력 한계에 근접</p>
    </div>
    <div class="status-box status-ng">
      <h3>🔴 NG (초과/위험)</h3>
      <p><strong>D/C $> 1.00$</strong>: 단면 증대 또는 보강 립/지지 조건 보강 필요</p>
    </div>
  </div>
</div>
"""
    },
    "report_guide": {
        "id": "report_guide",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "A4 구조계산서 출력 가이드",
        "summary": "구조감리 제출용 A4 표준 구조계산서 서식 구조, 단면도 SVG 벡터 렌더링 및 PDF 인쇄(Ctrl+P) 가이드입니다.",
        "tags": ["구조계산서", "A4", "보고서", "인쇄", "PDF", "SVG"],
        "content_html": """
<div class="manual-article">
  <h1>A4 구조계산서 출력 가이드</h1>
  <p class="lead">CFDesigner는 해석 및 부재설계 결과를 인허가 관공서 및 구조감리 제출용 <strong>A4 표준 구조계산서</strong> 서식으로 즉시 변환하여 인쇄 또는 PDF 저장할 수 있습니다.</p>

  <h2>계산서 포함 항목</h2>
  <ol class="step-list">
    <li><strong>프로젝트 기본 정보</strong>: 부재명, 작성자, 설계기준(KDS 14 31 10 / AISI S100), 강재 등급($F_y, E$)</li>
    <li><strong>단면 형상 및 기하 특성치</strong>: 정밀 벡터 SVG 단면도(도심, 주축 표시) 및 기하학적 성질표($A_g, I_x, I_y, J, C_w, S_C$)</li>
    <li><strong>FSM 탄성 좌굴해석 결과</strong>: 국부($P_{crl}$), 왜곡($P_{crd}$), 전체($P_{cre}$) 좌굴하중</li>
    <li><strong>KDS 부재 설계 내력 및 검토서</strong>: 압축($P_n$), 휨($M_n$), 전단($V_n$), P-M 상관식 및 최종 판정(OK/NG)</li>
  </ol>

  <h2>인쇄 및 PDF 저장 방법</h2>
  <div class="callout callout-info">
    <h4>💡 브라우저 인쇄 단축키</h4>
    <p>메인 화면 상단의 <strong>[📄 A4 구조계산서 출력]</strong> 버튼을 누르면 새 창으로 계산서 뷰어가 열립니다. 키보드의 <code>Ctrl + P</code>를 눌러 대상을 <strong>'PDF로 저장'</strong>으로 선택하여 저장하십시오.</p>
  </div>
</div>
"""
    }
}
