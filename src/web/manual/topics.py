"""
CFDesigner Online Help Manual Content Dataset
KDS 14 31 10 & AISI S100 based Engineering Manual (15 Topics across 4 Categories)
Bilingual Dataset: Korean (KDS Modernized) & English (AISI / CFS Ground Truth Reference)
"""

CATEGORIES = [
    {
        "id": "getting_started",
        "title": "1. 시작하기 & 웹 UI 가이드",
        "title_en": "1. Getting Started & Web UI Guide",
        "icon": "🚀",
        "topics": ["intro", "ui_layout", "wizard", "dxf_import"]
    },
    {
        "id": "section_properties",
        "title": "2. 단면 기하학적 성질 이론",
        "title_en": "2. Section Properties Theory",
        "icon": "📐",
        "topics": ["gross_props", "torsion_props", "principal_axes"]
    },
    {
        "id": "fsm_buckling",
        "title": "3. FSM 탄성 좌굴해석 이론",
        "title_en": "3. Finite Strip Method (FSM) Buckling",
        "icon": "🔬",
        "topics": ["fsm_theory", "buckling_modes", "signature_curve"]
    },
    {
        "id": "kds_design",
        "title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title_en": "4. KDS 14 31 10 Member Design & Reports",
        "icon": "🏛️",
        "topics": ["kds_dsm_comp", "kds_dsm_flex", "kds_shear_crip", "kds_interaction", "report_guide"]
    }
]

TOPICS = {
    # =========================================================================
    # 1. 시작하기 & 웹 UI 가이드 (Getting Started)
    # =========================================================================
    "intro": {
        "id": "intro",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "시스템 소개 및 특징",
        "title_en": "System Overview & Features",
        "summary": "CFDesigner는 냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS 14 31 10 / AISI S100 부재설계 클라우드 시스템입니다.",
        "summary_en": "CFDesigner is a cloud-based engineering system for cold-formed steel section analysis, FSM buckling, and KDS 14 31 10 / AISI S100 design.",
        "tags": ["소개", "FSM", "KDS 14 31 10", "AISI S100", "AltDP", "Overview"],
        "content_html": """
<div class="manual-article">
  <h1>시스템 소개 및 특징</h1>
  <p class="lead"><strong>CFDesigner</strong>는 냉간성형강(<span class="glossary-term" data-en="Cold-Formed Steel (CFS)" data-def="Steel products shaped at ambient temperature by roll forming or press braking.">Cold-Formed Steel</span>)의 임의 형상 비정형 단면에 대해 <strong>유한대판법(<span class="glossary-term" data-en="Finite Strip Method (FSM)" data-def="A specialized semi-analytical numerical method combining finite elements across the section with Fourier series along the length.">Finite Strip Method, FSM</span>)</strong> 탄성 좌굴해석과 <strong>KDS 14 31 10(냉간성형강구조설계기준)</strong> 및 <strong>AISI S100 직접강도법(<span class="glossary-term" data-en="Direct Strength Method (DSM)" data-def="Design method using elastic buckling loads of the full cross section instead of effective widths.">DSM</span>)</strong> 설계를 원클릭으로 수행하는 차세대 SaaS 웹 엔지니어링 솔루션입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p><strong>CFDesigner</strong> is a comprehensive software package for cross section property calculation, elastic buckling analysis via Finite Strip Method (FSM), and member strength design in accordance with AISI S100 and KDS 14 31 10 specifications.</p>
      </div>
    </div>
  </div>

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
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>System Overview & Features</h1>
  <p class="lead"><strong>CFDesigner</strong> is a state-of-the-art cloud-based SaaS engineering platform designed for cross-section property computation, <strong>Finite Strip Method (FSM)</strong> elastic buckling analysis, and member strength verification under <strong>KDS 14 31 10</strong> and <strong>AISI S100 (Direct Strength Method, DSM)</strong> specifications.</p>

  <div class="callout callout-info">
    <h4>💡 Core Philosophy & Objective</h4>
    <p>By overcoming the limitations of legacy desktop CFS software, CFDesigner delivers a modern AltDP web interface (2D CAD Canvas, Three.js 3D Buckling Visualization, and Chart.js Signature Curves) with exact Ground Truth numerical compliance.</p>
  </div>

  <h2>Key Features & Capabilities</h2>
  <div class="feature-grid">
    <div class="feature-card">
      <div class="feature-icon">📐</div>
      <h3>AutoCAD DXF & Section Wizard</h3>
      <p>Parametric templates for 6 standard shapes (C, Z, Hat, Tube, Angle, Deck) and automatic meshing for arbitrary 2D DXF polylines.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">⚙️</div>
      <h3>Exact Section Properties</h3>
      <p>Gross Area ($A_g$), Centroid ($C_G$), Saint-Venant Torsion ($J$), Sectorial Warping Constant ($C_w$), Shear Center ($S_C$), and Principal Axes ($I_1, I_2$).</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">🔬</div>
      <h3>FSM Elastic Buckling Analysis</h3>
      <p>Harmonic Fourier series expansion along member length with rigorous stiffness assemblies ($[K_e], [K_g]$) to evaluate local, distortional, and global buckling loads.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">🏛️</div>
      <h3>KDS 14 31 10 Member Design</h3>
      <p>Direct Strength Method (DSM) evaluation for compression ($P_n$), flexure ($M_n$), shear ($V_n$), web crippling ($P_{nc}$), P-M interaction, and formal A4 engineering reports.</p>
    </div>
  </div>

  <h2>System Architecture Overview</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>Layer</th>
        <th>Tech Stack</th>
        <th>Responsibilities & Functions</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>Frontend UI</strong></td>
        <td>HTML5, Vanilla CSS (AltDP Theme), Chart.js, Three.js</td>
        <td>2D CAD drafting canvas, 3D buckling mode viewer, D/C gauges, and responsive dashboard.</td>
      </tr>
      <tr>
        <td><strong>Backend API</strong></td>
        <td>FastAPI, Uvicorn (Python 3.10+)</td>
        <td>Section analysis, numerical FSM solvers, KDS member check routines, and JSON REST API.</td>
      </tr>
      <tr>
        <td><strong>Core Solvers</strong></td>
        <td>NumPy, SciPy, ezdxf</td>
        <td>Eigenvalue generalized solvers ($[K_e]\\{\\delta\\} = \\lambda [K_g]\\{\\delta\\}$), contour integrals, and DXF processing.</td>
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
        "title": "웹 UI 4분할 레이아웃 가이드",
        "title_en": "Web UI 4-Quadrant Layout Guide",
        "summary": "단면 입력 패널, 2D/3D 그래픽 뷰어, 시그니처 커브, KDS 설계 결과 패널로 구성된 AltDP 4분할 화면 구조를 설명합니다.",
        "summary_en": "Explains the AltDP 4-quadrant workspace: Section Input Panel, 2D/3D Graphic Viewer, Signature Curve, and KDS Design Result Panel.",
        "tags": ["UI", "레이아웃", "작업공간", "AltDP", "Workspace"],
        "content_html": """
<div class="manual-article">
  <h1>웹 UI 4분할 레이아웃 가이드</h1>
  <p class="lead">CFDesigner의 메인 작업공간은 엔지니어의 구조해석 및 설계 워크플로우를 최적화하기 위해 <strong>4분할 반응형 그리드(4-Quadrant Grid)</strong>로 구성되어 있습니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>The CFDesigner workspace is organized into four interactive quadrants designed to streamline structural modeling, graphic visualization, buckling spectrum analysis, and code checking.</p>
      </div>
    </div>
  </div>

  <h2>4대 핵심 작업 영역</h2>
  <div class="feature-grid">
    <div class="feature-card">
      <div class="feature-icon">1️⃣</div>
      <h3>좌측 상단: 단면 입력 및 마법사</h3>
      <p>단면 템플릿 선택, 치수 파라미터($B_1, H, B_2, D, t, R$), 강재 물성치($F_y, E, \nu$) 설정 및 DXF 파일 업로드.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">2️⃣</div>
      <h3>우측 상단: 2D CAD / 3D 그래픽 뷰어</h3>
      <p>Canvas 2D 단면 및 도심/주축/전단중심 렌더링, Three.js 3D 유한대판 메시 및 좌굴 변형 형상 실시간 시각화.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">3️⃣</div>
      <h3>좌측 하단: FSM 시그니처 커브</h3>
      <p>부재 길이($L$) 대비 임계 탄성 좌굴응력($\sigma_{cr}$) 곡선(Chart.js)과 국부/왜곡/전체 최저점 자동 태깅.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">4️⃣</div>
      <h3>우측 하단: KDS 부재설계 & D/C 게이지</h3>
      <p>KDS 14 31 10 직접강도법 공칭강도($P_n, M_n, V_n$), D/C Ratio 원형 게이지, A4 계산서 미리보기 및 PDF 인쇄.</p>
    </div>
  </div>

  <h2>상단 툴바 및 컨트롤 버튼</h2>
  <ul>
    <li><strong>[▶ 해석 및 설계 실행]</strong>: 단면 기하학 해석 $\rightarrow$ FSM 좌굴해석 $\rightarrow$ KDS 부재설계를 순차 실행합니다.</li>
    <li><strong>[📄 A4 구조계산서]</strong>: 엔지니어링 심의용 공식 A4 계산서 모달을 호출하고 PDF 인쇄를 지원합니다.</li>
    <li><strong>[❓ 온라인 매뉴얼]</strong>: 현재 보고 계시는 공학 이론 및 사용자 가이드 매뉴얼 뷰어를 엽니다.</li>
    <li><strong>[🌓 다크/라이트 테마]</strong>: 작업 환경에 맞는 고대비 다크 모드 및 문서 작성용 라이트 모드를 토글합니다.</li>
  </ul>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Web UI 4-Quadrant Layout Guide</h1>
  <p class="lead">The CFDesigner workspace is organized into a streamlined <strong>4-quadrant responsive grid</strong> to maximize engineering efficiency throughout modeling, analysis, and verification.</p>

  <h2>The 4 Core Interactive Quadrants</h2>
  <div class="feature-grid">
    <div class="feature-card">
      <div class="feature-icon">1️⃣</div>
      <h3>Top-Left: Section Input & Wizard</h3>
      <p>Standard shape selection, parametric dimension inputs ($B_1, H, B_2, D, t, R$), material properties ($F_y, E, \nu$), and DXF file upload.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">2️⃣</div>
      <h3>Top-Right: 2D CAD & 3D Viewer</h3>
      <p>Interactive 2D section canvas displaying centroid, shear center, principal axes, and Three.js 3D buckling mode deformation.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">3️⃣</div>
      <h3>Bottom-Left: FSM Signature Curve</h3>
      <p>Critical buckling stress spectrum ($\sigma_{cr}$ vs. Half-wavelength $L$) with automated identification of local, distortional, and global minima.</p>
    </div>
    <div class="feature-card">
      <div class="feature-icon">4️⃣</div>
      <h3>Bottom-Right: KDS Design & D/C Gauge</h3>
      <p>KDS 14 31 10 DSM nominal capacities ($P_n, M_n, V_n$), demand-to-capacity gauge, and formal A4 calculation report generation.</p>
    </div>
  </div>

  <h2>Top Navigation Toolbar</h2>
  <ul>
    <li><strong>[▶ Run Analysis & Design]</strong>: Executes full pipeline: Section Properties $\rightarrow$ FSM Solvers $\rightarrow$ KDS Design Verification.</li>
    <li><strong>[📄 A4 Calculation Report]</strong>: Opens formal multi-page engineering calculation sheet with browser print support.</li>
    <li><strong>[❓ Online Manual]</strong>: Launches this comprehensive engineering theory & user guide documentation viewer.</li>
    <li><strong>[🌓 Dark/Light Theme]</strong>: Toggles high-contrast dark mode and clean paper-like light theme.</li>
  </ul>
</div>
"""
    },

    "wizard": {
        "id": "wizard",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "단면 마법사 파라메트릭 생성",
        "title_en": "Parametric Section Wizard",
        "summary": "C형강, Z형강, 모자형, 각형관, L형강, 데크 플레이트 등 6대 표준 형상의 파라메트릭 생성 원리와 노드 메싱을 설명합니다.",
        "summary_en": "Details parametric generation, corner radius handling, and node discretization for 6 standard cold-formed shapes.",
        "tags": ["마법사", "C형강", "Z형강", "데크", "Wizard", "Template"],
        "content_html": """
<div class="manual-article">
  <h1>단면 마법사 파라메트릭 생성</h1>
  <p class="lead">단면 마법사는 냉간성형강 구조물에서 가장 빈번하게 사용되는 <strong>6대 표준 단면 형상</strong>을 몇 가지 주요 치수 입력만으로 정밀 2D 유한대판 메시로 자동 생성합니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>The Section Wizard allows quick generation of standard cold-formed cross sections including Cee, Zee, Hat, Rectangular Tube, Angle, and Deck profiles by specifying core dimensions and inner corner bend radii.</p>
      </div>
    </div>
  </div>

  <h2>지원 표준 단면 유형</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>형상명</th>
        <th>주요 입력 파라미터</th>
        <th>모서리 절곡($R$) 메싱</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>C형강 (Lipped Cee)</strong></td>
        <td>$H$(웨브), $B$(플랜지), $D$(립), $t$(두께), $R$(내경반경)</td>
        <td>모서리 4개소 $90^\circ$ 원호 분할</td>
      </tr>
      <tr>
        <td><strong>Z형강 (Lipped Zee)</strong></td>
        <td>$H, B_1, B_2, D_1, D_2, t, R, \theta$(립 경사각)</td>
        <td>비대칭/점대칭 플랜지 및 경사 립 메싱</td>
      </tr>
      <tr>
        <td><strong>모자형강 (Hat Channel)</strong></td>
        <td>$H, B$(상부 플랜지), $B_L$(하부 립), $t, R$</td>
        <td>상/하부 절곡부 원호 세그먼트 생성</td>
      </tr>
      <tr>
        <td><strong>각형 강관 (Rectangular Tube)</strong></td>
        <td>$H, B, t, R$</td>
        <td>폐단면 4개소 코너 곡률 완전 메싱</td>
      </tr>
      <tr>
        <td><strong>L형강 (Angle)</strong></td>
        <td>$H, B, t, R$ (립 유무 선택)</td>
        <td>단일 모서리 절곡부 생성</td>
      </tr>
      <tr>
        <td><strong>데크 플레이트 (Deck)</strong></td>
        <td>$H, W_t, W_b, P$(피치), $t$</td>
        <td>반복 주기 파형 리브 자동 전개</td>
      </tr>
    </tbody>
  </table>

  <h2>모서리 라운딩($R$) 처리 원칙</h2>
  <p>실제 롤포밍(Roll-Forming) 및 프레스 가공 냉간성형강 부재는 모서리에 내부 반경($R$)이 형성됩니다. CFDesigner는 모서리를 날카로운 각도로 근사하지 않고, <strong>$90^\circ$ 원호를 균일 호 세그먼트 스트립으로 분할</strong>하여 단면 2차모멘트($I$) 및 뒴상수($C_w$) 계산의 오차를 0.1% 미만으로 억제합니다.</p>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Parametric Section Wizard</h1>
  <p class="lead">The Section Wizard facilitates rapid, high-precision generation of <strong>6 standard cold-formed cross-section profiles</strong> by parameterizing key dimensions and corner bend radii.</p>

  <h2>Supported Standard Section Types</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>Shape Type</th>
        <th>Primary Parameters</th>
        <th>Corner Bend ($R$) Meshing</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>Lipped Cee</strong></td>
        <td>$H$ (Web), $B$ (Flange), $D$ (Lip), $t$ (Thickness), $R$ (Inside Radius)</td>
        <td>4 corner $90^\circ$ circular arc subdivisions</td>
      </tr>
      <tr>
        <td><strong>Lipped Zee</strong></td>
        <td>$H, B_1, B_2, D_1, D_2, t, R, \theta$ (Lip Angle)</td>
        <td>Point-symmetric flanges & inclined lips</td>
      </tr>
      <tr>
        <td><strong>Hat Channel</strong></td>
        <td>$H, B$ (Top Flange), $B_L$ (Bottom Lip), $t, R$</td>
        <td>Upper and lower corner circular strip assemblies</td>
      </tr>
      <tr>
        <td><strong>Rectangular Tube</strong></td>
        <td>$H, B, t, R$</td>
        <td>Closed-loop 4 corner radius discretization</td>
      </tr>
      <tr>
        <td><strong>Angle (L-Shape)</strong></td>
        <td>$H, B, t, R$ (Plain or Lipped)</td>
        <td>Single corner curved strip generation</td>
      </tr>
      <tr>
        <td><strong>Deck Profile</strong></td>
        <td>$H, W_t, W_b, P$ (Pitch), $t$</td>
        <td>Repetitive wave-rib flutes discretization</td>
      </tr>
    </tbody>
  </table>

  <h2>Corner Radius Modeling Principles</h2>
  <p>Cold-formed sections feature distinct inside bend radii ($R$) produced by roll forming or press braking. CFDesigner discretizes corner bends into <strong>curved circular arc strip elements</strong>, ensuring less than 0.1% error in torsional and warping properties ($J, C_w$) compared to sharp-corner approximations.</p>
</div>
"""
    },

    "dxf_import": {
        "id": "dxf_import",
        "category_id": "getting_started",
        "category_title": "1. 시작하기 & 웹 UI 가이드",
        "title": "AutoCAD DXF 가져오기 및 메싱",
        "title_en": "AutoCAD DXF Import & Auto-Meshing",
        "summary": "AutoCAD 2D Polyline(DXF) 파일의 단면 중심선(Centerline) 추출, 꼭짓점 정렬 및 유한대판 노드 자동 생성 규칙을 설명합니다.",
        "summary_en": "Specifies 2D DXF polyline rules, centerline extraction, vertex sequencing, and automated FSM strip meshing.",
        "tags": ["CAD", "DXF", "AutoCAD", "메싱", "Polyline", "Meshing"],
        "content_html": """
<div class="manual-article">
  <h1>AutoCAD DXF 가져오기 및 메싱</h1>
  <p class="lead">표준 마법사 형상을 벗어난 임의 형상의 비정형 단면이나 다중 절곡 보강 리브(Stiffener)가 포함된 단면은 <strong>AutoCAD DXF(Drawing Exchange Format)</strong> 파일을 업로드하여 즉시 해석할 수 있습니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Arbitrary custom cross sections can be imported via 2D DXF files. The parser extracts LWPOLYLINE entities, validates continuity, and automatically constructs finite strip elements along the section centerline.</p>
      </div>
    </div>
  </div>

  <h2>DXF 파일 작성 시 준수 규칙</h2>
  <div class="callout callout-warning">
    <h4>⚠️ DXF 작도 필수 지침</h4>
    <ul>
      <li><strong>엔티티 종류</strong>: <code>LWPOLYLINE</code> (Lightweight Polyline) 또는 <code>POLYLINE</code>으로 작도합니다.</li>
      <li><strong>선 위치</strong>: 판 두께의 <strong>중심선(Centerline)</strong>을 기준으로 작도하거나, 외곽선을 그릴 경우 업로드 후 판 두께($t$)를 지정합니다.</li>
      <li><strong>좌표계</strong>: 2D 평면 ($X-Y$ 평면, $Z=0$) 상에 단면이 위치해야 합니다.</li>
      <li><strong>단위계</strong>: 밀리미터($\\text{mm}$) 단위를 권장합니다.</li>
    </ul>
  </div>

  <h2>자동 메싱(Auto-Meshing) 알고리즘</h2>
  <ol>
    <li><strong>폴리라인 파싱</strong>: <code>ezdxf</code> 엔진을 통해 폴리라인의 각 정점(Vertex)과 원호 벌지(Bulge)를 추출합니다.</li>
    <li><strong>정점 순서 정렬</strong>: 개단면의 시작점부터 끝점까지 연속된 노드 번호($1, 2, \\dots, N$)를 부여합니다.</li>
    <li><strong>곡선부 세분화</strong>: 모서리 원호 구간을 지정된 분할수(기본 3~4개 스트립)로 자동 분할합니다.</li>
    <li><strong>요소 강성 생성</strong>: 인접한 노드 쌍 $(i, j)$을 하나의 평판 대판(Strip Element)으로 조립합니다.</li>
  </ol>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>AutoCAD DXF Import & Auto-Meshing</h1>
  <p class="lead">Custom non-standard shapes, multi-stiffened webs, and complex open/closed sections can be directly imported and analyzed by uploading <strong>AutoCAD 2D DXF</strong> files.</p>

  <h2>DXF CAD Modeling Guidelines</h2>
  <div class="callout callout-warning">
    <h4>⚠️ Mandatory Drafting Rules</h4>
    <ul>
      <li><strong>Entity Type</strong>: Must be drawn as <code>LWPOLYLINE</code> or continuous <code>POLYLINE</code>.</li>
      <li><strong>Reference Line</strong>: Draw along the cross-section <strong>Centerline</strong>. When drawing outer contours, specify uniform thickness ($t$).</li>
      <li><strong>Coordinate System</strong>: Section geometry must lie on the $X-Y$ plane with $Z=0$.</li>
      <li><strong>Units</strong>: Millimeters ($\\text{mm}$) are strongly recommended.</li>
    </ul>
  </div>

  <h2>Automated Meshing Pipeline</h2>
  <ol>
    <li><strong>Polyline Extraction</strong>: Extracts sequential vertices and arc bulge parameters using the <code>ezdxf</code> engine.</li>
    <li><strong>Vertex Ordering</strong>: Chains elements into continuous topological node sequences ($1, 2, \\dots, N$).</li>
    <li><strong>Arc Discretization</strong>: Automatically subdivides curved segments into refined sub-strips.</li>
    <li><strong>Strip Assembly</strong>: Builds interconnected 2-node plate strip elements between node pairs $(i, j)$.</li>
  </ol>
</div>
"""
    },

    # =========================================================================
    # 2. 단면 기하학적 성질 이론 (Section Properties Theory)
    # =========================================================================
    "gross_props": {
        "id": "gross_props",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "총단면 기하학적 성질 (Gross Properties)",
        "title_en": "Gross Section Properties",
        "summary": "총단면적(Ag), 도심(CG), 단면 2차모멘트(Ix, Iy), 단면상승모멘트(Ixy), 단면2차반경(rx, ry)의 엄밀 선적분 수식을 다룹니다.",
        "summary_en": "Formulates contour line integral equations for gross area (Ag), centroid (CG), moments of inertia (Ix, Iy, Ixy), and radii of gyration (rx, ry).",
        "tags": ["단면성질", "Ag", "Ix", "Iy", "도심", "Gross Properties", "Inertia"],
        "content_html": """
<div class="manual-article">
  <h1>총단면 기하학적 성질 (Gross Properties)</h1>
  <p class="lead">냉간성형강 박판 부재의 총단면 기하학적 성질은 단면 중심선(Centerline)을 따라 두께($t$)를 적분하는 <strong>선적분(Line Integral) 기법</strong>을 통해 정밀하게 계산됩니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Gross cross-section properties of thin-walled cold-formed shapes are determined by line integrals along the wall centerline. Linear strip segments and circular arc corners are integrated to obtain area, centroid, and moments of inertia.</p>
      </div>
    </div>
  </div>

  <h2>1. 총단면적 ($A_g$) 및 도심 ($x_c, y_c$)</h2>
  <p>단면을 구성하는 $M$개의 직선 및 곡선 세그먼트에 대해 총단면적은 다음과 같습니다:</p>
  $$A_g = \\sum_{k=1}^{M} t_k \\cdot L_k$$
  <p>원점 기준 도심(<span class="glossary-term" data-en="Centroid (CG)" data-def="The center of mass of the geometric cross section.">Centroid, $C_G$</span>) 좌표는 1차 단면모멘트($Q_y, Q_x$)로부터 산정됩니다:</p>
  $$x_c = \\frac{\\sum t_k L_k \\bar{x}_k}{A_g}, \\quad y_c = \\frac{\\sum t_k L_k \\bar{y}_k}{A_g}$$

  <h2>2. 단면 2차모멘트 ($I_x, I_y$) 및 상승모멘트 ($I_{xy}$)</h2>
  <p>도심축 기준의 단면 2차모멘트는 각 세그먼트 자체의 관성모멘트와 평행축 정리(Parallel Axis Theorem)를 합산합니다:</p>
  $$I_x = \\sum_{k=1}^{M} \\left( I_{x,k} + A_k (\\bar{y}_k - y_c)^2 \\right)$$
  $$I_y = \\sum_{k=1}^{M} \\left( I_{y,k} + A_k (\\bar{x}_k - x_c)^2 \\right)$$
  $$I_{xy} = \\sum_{k=1}^{M} \\left( I_{xy,k} + A_k (\\bar{x}_k - x_c)(\\bar{y}_k - y_c) \\right)$$

  <h2>3. 단면 2차반경 ($r_x, r_y$) 및 탄성단면계수 ($S_x, S_y$)</h2>
  $$r_x = \\sqrt{\\frac{I_x}{A_g}}, \\quad r_y = \\sqrt{\\frac{I_y}{A_g}}$$
  $$S_{x,\\text{top}} = \\frac{I_x}{|y_{\\max} - y_c|}, \\quad S_{x,\\text{bot}} = \\frac{I_x}{|y_{\\min} - y_c|}$$
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Gross Section Properties</h1>
  <p class="lead">Gross properties of thin-walled cold-formed steel members are computed using exact <strong>contour line integrals</strong> along the profile centerline with nominal wall thickness ($t$).</p>

  <h2>1. Gross Area ($A_g$) and Centroid ($x_c, y_c$)</h2>
  <p>For a section discretized into $M$ flat and curved strip segments:</p>
  $$A_g = \\sum_{k=1}^{M} t_k \\cdot L_k$$
  <p>The centroid coordinates ($C_G$) with respect to the origin are evaluated via first moments of area ($Q_y, Q_x$):</p>
  $$x_c = \\frac{\\sum t_k L_k \\bar{x}_k}{A_g}, \\quad y_c = \\frac{\\sum t_k L_k \\bar{y}_k}{A_g}$$

  <h2>2. Moments of Inertia ($I_x, I_y, I_{xy}$)</h2>
  <p>Centroidal moments of inertia are assembled using segment local inertias and the parallel axis theorem:</p>
  $$I_x = \\sum_{k=1}^{M} \\left( I_{x,k} + A_k (\\bar{y}_k - y_c)^2 \\right)$$
  $$I_y = \\sum_{k=1}^{M} \\left( I_{y,k} + A_k (\\bar{x}_k - x_c)^2 \\right)$$
  $$I_{xy} = \\sum_{k=1}^{M} \\left( I_{xy,k} + A_k (\\bar{x}_k - x_c)(\\bar{y}_k - y_c) \\right)$$

  <h2>3. Radii of Gyration ($r_x, r_y$) & Section Moduli ($S_x, S_y$)</h2>
  $$r_x = \\sqrt{\\frac{I_x}{A_g}}, \\quad r_y = \\sqrt{\\frac{I_y}{A_g}}$$
  $$S_{x,\\text{top}} = \\frac{I_x}{|y_{\\max} - y_c|}, \\quad S_{x,\\text{bot}} = \\frac{I_x}{|y_{\\min} - y_c|}$$
</div>
"""
    },

    "torsion_props": {
        "id": "torsion_props",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "비틀림 및 뒴 성질 (Torsion & Warping)",
        "title_en": "Torsional & Warping Properties",
        "summary": "생브낭 비틀림상수(J), 섹터면적(Sectorial Area) 기반 전단중심(x0, y0), 뒴상수(Cw), 극단면2차반경(r0), 단면비대칭인자(βw) 수식을 설명합니다.",
        "summary_en": "Formulates Saint-Venant torsion constant (J), sectorial area warping constant (Cw), shear center (x0, y0), and polar radius (r0).",
        "tags": ["비틀림", "J", "Cw", "전단중심", "r0", "Warping", "Shear Center", "Torsion"],
        "content_html": """
<div class="manual-article">
  <h1>비틀림 및 뒴 성질 (Torsion & Warping)</h1>
  <p class="lead">냉간성형강 박판 개단면 부재는 휨-비틀림 좌굴(<span class="glossary-term" data-en="Flexural-Torsional Buckling (FTB)" data-def="A buckling mode where a member bends and twists simultaneously due to eccentricity between centroid and shear center.">Flexural-Torsional Buckling</span>)에 매우 취약하므로, <strong>생브낭 비틀림상수($J$)</strong>와 <strong>섹터좌표계 기반 뒴상수($C_w$)</strong>, <strong>전단중심($S_C$)</strong>의 엄밀 산정이 필수적입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Open thin-walled sections have low torsional rigidity. Saint-Venant torsion constant ($J$), warping constant ($C_w$), and shear center coordinates ($x_0, y_0$) are calculated using Vlasov's thin-walled beam theory with sectorial coordinate integration.</p>
      </div>
    </div>
  </div>

  <h2>1. 생브낭 비틀림 상수 ($J$)</h2>
  <p>박판 개단면(Open Section)의 경우 각 요소의 폭과 두께 3승의 곱을 합산합니다:</p>
  $$J = \\sum_{k=1}^{M} \\frac{1}{3} L_k t_k^3$$

  <h2>2. 섹터좌표($\\omega$)와 전단중심 ($x_0, y_0$)</h2>
  <p>도심 $C_G$를 기준극으로 잡은 주섹터좌표($\\omega_n$)를 정의하고, 전단중심(<span class="glossary-term" data-en="Shear Center" data-def="Point through which an applied shear load produces bending without any torsion.">Shear Center, $S_C$</span>) 좌표 $(x_0, y_0)$를 다음과 같이 구합니다:</p>
  $$x_0 = \\frac{I_{y\\omega} I_x - I_{x\\omega} I_{xy}}{I_x I_y - I_{xy}^2}, \\quad y_0 = -\\frac{I_{x\\omega} I_y - I_{y\\omega} I_{xy}}{I_x I_y - I_{xy}^2}$$
  <p>여기서 $I_{x\\omega} = \\int x \\omega \\, dA$, $I_{y\\omega} = \\int y \\omega \\, dA$는 섹터-단면 1차 모멘트입니다.</p>

  <h2>3. 뒴상수 ($C_w$, Warping Constant)</h2>
  <p>전단중심을 극으로 하는 정규화 주섹터좌표($\\omega_s$)에 대한 면적 적분으로 뒴상수($C_w$)를 산정합니다:</p>
  $$C_w = \\int_A \\omega_s^2 \\, dA = \\sum_{k=1}^{M} \\frac{t_k L_k}{3} \\left( \\omega_{s,i}^2 + \\omega_{s,i}\\omega_{s,j} + \\omega_{s,j}^2 \\right)$$

  <h2>4. 극단면 2차반경 ($r_0$) 및 비대칭인자 ($\\beta_w$)</h2>
  $$r_0 = \\sqrt{r_x^2 + r_y^2 + x_0^2 + y_0^2}$$
  $$\\beta_w = \\frac{1}{I_y} \\int_A y (x^2 + y^2) \\, dA - 2 y_0$$
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Torsional & Warping Properties</h1>
  <p class="lead">Because thin-walled open sections are highly susceptible to <strong>flexural-torsional buckling</strong>, exact evaluation of <strong>Saint-Venant torsion ($J$)</strong>, <strong>warping constant ($C_w$)</strong>, and <strong>shear center ($S_C$)</strong> is essential.</p>

  <h2>1. Saint-Venant Torsion Constant ($J$)</h2>
  <p>For thin-walled open cross sections:</p>
  $$J = \\sum_{k=1}^{M} \\frac{1}{3} L_k t_k^3$$

  <h2>2. Sectorial Coordinates ($\\omega$) & Shear Center ($x_0, y_0$)</h2>
  <p>Using Vlasov sectorial area integration with centroid $C_G$ as the pole:</p>
  $$x_0 = \\frac{I_{y\\omega} I_x - I_{x\\omega} I_{xy}}{I_x I_y - I_{xy}^2}, \\quad y_0 = -\\frac{I_{x\\omega} I_y - I_{y\\omega} I_{xy}}{I_x I_y - I_{xy}^2}$$
  <p>where $I_{x\\omega} = \\int x \\omega \\, dA$ and $I_{y\\omega} = \\int y \\omega \\, dA$ are sectorial product moments.</p>

  <h2>3. Warping Constant ($C_w$)</h2>
  <p>Computed by integrating normalized principal sectorial coordinates ($\\omega_s$) referenced to the shear center:</p>
  $$C_w = \\int_A \\omega_s^2 \\, dA = \\sum_{k=1}^{M} \\frac{t_k L_k}{3} \\left( \\omega_{s,i}^2 + \\omega_{s,i}\\omega_{s,j} + \\omega_{s,j}^2 \\right)$$

  <h2>4. Polar Radius of Gyration ($r_0$) & Monosymmetry Factor ($\\beta_w$)</h2>
  $$r_0 = \\sqrt{r_x^2 + r_y^2 + x_0^2 + y_0^2}$$
  $$\\beta_w = \\frac{1}{I_y} \\int_A y (x^2 + y^2) \\, dA - 2 y_0$$
</div>
"""
    },

    "principal_axes": {
        "id": "principal_axes",
        "category_id": "section_properties",
        "category_title": "2. 단면 기하학적 성질 이론",
        "title": "주축 및 주단면 2차모멘트 (Principal Axes)",
        "title_en": "Principal Axes & Principal Moments",
        "summary": "비대칭/점대칭 단면의 주축 회전각(θp), 최대/최소 주단면 2차모멘트(I1, I2), 주단면 2차반경(r1, r2) 유도 수식을 설명합니다.",
        "summary_en": "Derives principal axis orientation angle (theta_p), major/minor principal moments of inertia (I1, I2), and principal radii of gyration.",
        "tags": ["주축", "회전각", "I1", "I2", "Principal Axes", "Rotation"],
        "content_html": """
<div class="manual-article">
  <h1>주축 및 주단면 2차모멘트 (Principal Axes)</h1>
  <p class="lead">Z형강이나 부등변 L형강과 같은 비대칭·점대칭 단면은 기하학적 직교축($X, Y$)과 주축($1, 2$)이 일치하지 않으므로, <strong>주축 회전각($\\theta_p$)</strong>과 <strong>주단면 2차모멘트($I_1, I_2$)</strong>를 도출하여 정확한 휨 해석을 수행해야 합니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>For asymmetric or point-symmetric sections (such as Zees and Angles), principal axes 1 and 2 are rotated by angle $\\theta_p$. Principal moments of inertia ($I_1, I_2$) eliminate product moment of inertia ($I_{12} = 0$).</p>
      </div>
    </div>
  </div>

  <h2>1. 주축 회전각 ($\\theta_p$, Principal Axis Angle)</h2>
  <p>단면상승모멘트($I_{xy}$)가 0이 되는 주축 각도는 다음과 같습니다:</p>
  $$\\tan(2\\theta_p) = \\frac{-2 I_{xy}}{I_x - I_y} \\quad \\implies \\quad \\theta_p = \\frac{1}{2} \\operatorname{atan2}(-2 I_{xy}, I_x - I_y)$$

  <h2>2. 주단면 2차모멘트 ($I_1, I_2$)</h2>
  <p>강축(Major axis) 관성모멘트 $I_1$과 약축(Minor axis) 관성모멘트 $I_2$:</p>
  $$I_1 = \\frac{I_x + I_y}{2} + \\sqrt{\\left( \\frac{I_x - I_y}{2} \\right)^2 + I_{xy}^2}$$
  $$I_2 = \\frac{I_x + I_y}{2} - \\sqrt{\\left( \\frac{I_x - I_y}{2} \\right)^2 + I_{xy}^2}$$

  <h2>3. 모어의 관성원 (Mohr's Circle of Inertia)</h2>
  <p>모어 관성원의 중심은 $C = \\frac{I_x + I_y}{2}$ 이며, 반경은 $R_M = \\sqrt{\\left(\\frac{I_x - I_y}{2}\\right)^2 + I_{xy}^2}$ 입니다. 임의 각도 $\\alpha$만큼 회전된 축에 대한 관성모멘트 변환 공식은 다음과 같습니다:</p>
  $$I_{x'} = \\frac{I_x + I_y}{2} + \\frac{I_x - I_y}{2} \\cos(2\\alpha) - I_{xy} \\sin(2\\alpha)$$
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Principal Axes & Principal Moments</h1>
  <p class="lead">For asymmetric or point-symmetric sections (e.g., Z-sections, unsymmetric angles), the geometric $X-Y$ coordinate axes do not coincide with the principal axes. Evaluating <strong>principal axis angle ($\\theta_p$)</strong> and <strong>principal moments ($I_1, I_2$)</strong> is vital for true biaxial flexural design.</p>

  <h2>1. Principal Axis Rotation Angle ($\\theta_p$)</h2>
  <p>The orientation angle where the product moment of inertia becomes zero ($I_{12} = 0$):</p>
  $$\\tan(2\\theta_p) = \\frac{-2 I_{xy}}{I_x - I_y} \\quad \\implies \\quad \\theta_p = \\frac{1}{2} \\operatorname{atan2}(-2 I_{xy}, I_x - I_y)$$

  <h2>2. Principal Moments of Inertia ($I_1, I_2$)</h2>
  <p>Major principal moment $I_1$ and minor principal moment $I_2$:</p>
  $$I_1 = \\frac{I_x + I_y}{2} + \\sqrt{\\left( \\frac{I_x - I_y}{2} \\right)^2 + I_{xy}^2}$$
  $$I_2 = \\frac{I_x + I_y}{2} - \\sqrt{\\left( \\frac{I_x - I_y}{2} \\right)^2 + I_{xy}^2}$$

  <h2>3. Mohr's Circle of Inertia</h2>
  <p>The center of Mohr's circle is $C = \\frac{I_x + I_y}{2}$ with radius $R_M = \\sqrt{\\left(\\frac{I_x - I_y}{2}\\right)^2 + I_{xy}^2}$. Transformed inertias at arbitrary angle $\\alpha$:</p>
  $$I_{x'} = \\frac{I_x + I_y}{2} + \\frac{I_x - I_y}{2} \\cos(2\\alpha) - I_{xy} \\sin(2\\alpha)$$
</div>
"""
    },

    # =========================================================================
    # 3. FSM 탄성 좌굴해석 이론 (Finite Strip Method Buckling)
    # =========================================================================
    "fsm_theory": {
        "id": "fsm_theory",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "유한대판법(FSM) 탄성 좌굴 해석 이론",
        "title_en": "Finite Strip Method (FSM) Elastic Buckling Theory",
        "summary": "종방향 사인 조화함수 변위 전개, 2노드 박판 대판 요소의 탄성강성행렬([Ke]) 및 기하강성행렬([Kg]), 일반화 고유치 문제 해법을 설명합니다.",
        "summary_en": "Covers longitudinal Fourier series displacement fields, 2-node plate strip elastic stiffness [Ke], geometric stiffness [Kg], and eigenvalue solvers.",
        "tags": ["FSM", "유한대판법", "강성행렬", "고유치해석", "Stiffness", "Eigenvalue"],
        "content_html": """
<div class="manual-article">
  <h1>유한대판법(FSM) 탄성 좌굴 해석 이론</h1>
  <p class="lead"><strong>유한대판법(<span class="glossary-term" data-en="Finite Strip Method (FSM)" data-def="A semi-analytical numerical tool for thin-walled prismatic members, discretizing the cross section into strips and using harmonic Fourier series along the length.">Finite Strip Method, FSM</span>)</strong>은 냉간성형강과 같은 등단면 박판 구조물의 탄성 좌굴거동을 매우 효율적이고 엄밀하게 해석하는 반해석적(Semi-Analytical) 수치해석 기법입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>The Finite Strip Method (Cheung 1976, Schafer 2002) discretizes cross-sections into 2-node longitudinal strips. Displacements are modeled via polynomial shape functions across the width and Fourier sinusoidal series along the length.</p>
      </div>
    </div>
  </div>

  <h2>1. 변위장 모델링 (Displacement Field)</h2>
  <p>단면 횡방향($x$)으로는 1차(면내 $u, v$) 및 3차(면외 $w, \theta$) 에르미트 다항식 형상함수를 사용하고, 길이방향($z$)으로는 단순지지 경계조건을 만족하는 사인(Sine) 급수를 전개합니다:</p>
  $$u(x, z) = \\sum_{m=1}^{N_m} N_u(x) \\cdot \\mathbf{u}_m \\cdot \\sin\\left(\\frac{m\\pi z}{L}\\right)$$
  $$w(x, z) = \\sum_{m=1}^{N_m} N_w(x) \\cdot \\mathbf{w}_m \\cdot \\sin\\left(\\frac{m\\pi z}{L}\\right)$$

  <h2>2. 요소 탄성강성행렬 ($[K_e]$) 및 기하강성행렬 ($[K_g]$)</h2>
  <p>평면응력(막 거동, Membrane)과 평판 휨(Bending) 거동의 변형에너지를 정식화하여 8자유도(노드당 4자유도: $u, v, w, \\theta_z$) 대판 요소 행렬을 유도합니다:</p>
  $$[k_e] = \\int_0^L \\int_0^b [B]^T [D] [B] \\, dx \\, dz, \\quad [k_g] = \\int_0^L \\int_0^b [G]^T [\\sigma^0] [G] \\, dx \\, dz$$

  <h2>3. 일반화 고유치 문제 (Generalized Eigenvalue Problem)</h2>
  <p>전체 단면에 대해 강성행렬을 조립한 후, 주어진 반파장($L$)에서 임계하중 계수($\\lambda = \\sigma_{cr} / \\sigma_0$)와 좌굴모드 벡터($\\{\\delta\\}$)를 구합니다:</p>
  $$\\mathbf{[K_e] \\{\\delta\\} = \\lambda [K_g] \\{\\delta\\}}$$
  <p>CFDesigner는 SciPy의 희소 대칭 고유치 해석기(<code>scipy.sparse.linalg.eigsh</code>)를 적용하여 초당 수십 개의 반파장 해석을 실시간으로 수행합니다.</p>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Finite Strip Method (FSM) Elastic Buckling Theory</h1>
  <p class="lead">The <strong>Finite Strip Method (FSM)</strong> is an exact, highly efficient semi-analytical numerical tool formulated specifically for thin-walled prismatic structural members.</p>

  <h2>1. Displacement Field Formulation</h2>
  <p>The displacement fields combine polynomial shape functions across the strip width with harmonic Fourier series along the longitudinal axis ($z$):</p>
  $$u(x, z) = \\sum_{m=1}^{N_m} N_u(x) \\cdot \\mathbf{u}_m \\cdot \\sin\\left(\\frac{m\\pi z}{L}\\right)$$
  $$w(x, z) = \\sum_{m=1}^{N_m} N_w(x) \\cdot \\mathbf{w}_m \\cdot \\sin\\left(\\frac{m\\pi z}{L}\\right)$$

  <h2>2. Element Elastic ($[K_e]$) and Geometric ($[K_g]$) Stiffness</h2>
  <p>Combining membrane plane-stress and Kirchhoff plate-bending strain energies yields an 8-DOF (4 DOFs per node: $u, v, w, \\theta$) strip element:</p>
  $$[k_e] = \\int_0^L \\int_0^b [B]^T [D] [B] \\, dx \\, dz, \\quad [k_g] = \\int_0^L \\int_0^b [G]^T [\\sigma^0] [G] \\, dx \\, dz$$

  <h2>3. Generalized Eigenvalue Problem</h2>
  <p>Assembling global stiffness matrices gives the governing eigenvalue equation for critical load factor $\\lambda = \\sigma_{cr} / \\sigma_0$ and mode shape $\\{\\delta\\}$:</p>
  $$\\mathbf{[K_e] \\{\\delta\\} = \\lambda [K_g] \\{\\delta\\}}$$
  <p>CFDesigner leverages optimized SciPy sparse symmetric solvers (<code>eigsh</code>) to solve buckling spectra across dozens of half-wavelengths in real time.</p>
</div>
"""
    },

    "buckling_modes": {
        "id": "buckling_modes",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "좌굴 모드 판별: 국부, 왜곡, 전체 좌굴",
        "title_en": "Buckling Mode Classification: Local, Distortional, Global",
        "summary": "국부좌굴(Local, P_crl), 왜곡좌굴(Distortional, P_crd), 전체좌굴(Global, P_cre)의 물리적 변형 특성, 반파장 범위 및 판별 알고리즘을 설명합니다.",
        "summary_en": "Characterizes physical deformation modes, wavelength ranges, and automated identification for local (P_crl), distortional (P_crd), and global (P_cre) buckling.",
        "tags": ["좌굴모드", "국부좌굴", "왜곡좌굴", "전체좌굴", "Local", "Distortional", "Global"],
        "content_html": """
<div class="manual-article">
  <h1>좌굴 모드 판별: 국부, 왜곡, 전체 좌굴</h1>
  <p class="lead">직접강도법(DSM)의 핵심은 단면의 3대 독립 탄성 좌굴모드인 <strong>국부좌굴($L$)</strong>, <strong>왜곡좌굴($D$)</strong>, <strong>전체좌굴($G$)</strong>의 임계하중을 정확히 분리·식별하는 것입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>The Direct Strength Method (DSM) requires distinct determination of three elastic buckling modes: Local buckling ($P_{crl}, M_{crl}$), Distortional buckling ($P_{crd}, M_{crd}$), and Global buckling ($P_{cre}, M_{cre}$).</p>
      </div>
    </div>
  </div>

  <h2>3대 탄성 좌굴모드 비교표</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>좌굴 모드</th>
        <th>대표적 반파장 ($L$)</th>
        <th>절곡 모서리(Fold-Line) 거동</th>
        <th>단면 형상 변화</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>국부 좌굴 (Local, $L$)</strong></td>
        <td>단면 판폭 수준 ($10 \\sim 150\\,\\text{mm}$)</td>
        <td><strong>변위 없음 (고정)</strong>, 판요소만 면외 휨파동</td>
        <td>모서리 접합선 유지, 판면 물결 변형</td>
      </tr>
      <tr>
        <td><strong>왜곡 좌굴 (Distortional, $D$)</strong></td>
        <td>중간 길이 ($150 \\sim 800\\,\\text{mm}$)</td>
        <td><strong>모서리 및 립(Lip) 회전/변위 발생</strong></td>
        <td>플랜지/립이 개방 또는 내측으로 왜곡 회전</td>
      </tr>
      <tr>
        <td><strong>전체 좌굴 (Global, $G$)</strong></td>
        <td>부재 전체 길이 ($1,000\\,\\text{mm}$ 이상)</td>
        <td>단면 형상 왜곡 없이 <strong>부재 전체 거동</strong></td>
        <td>오일러 휨좌굴, 비틀림좌굴, 휨-비틀림 좌굴</td>
      </tr>
    </tbody>
  </table>

  <h2>모드 판별 자동화 알고리즘</h2>
  <ol>
    <li><strong>시그니처 커브 국소 극소점(Local Minima) 탐색</strong>: 반파장 로그 스케일에서 첫 번째 극소점을 국부좌굴($P_{crl}$), 두 번째 극소점을 왜곡좌굴($P_{crd}$)로 자동 할당합니다.</li>
    <li><strong>모드 형상 참여도 판정</strong>: 절곡선 절점의 변위량($\\sqrt{u^2+w^2}$)을 분석하여 판별의 신뢰성을 보증합니다.</li>
  </ol>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Buckling Mode Classification: Local, Distortional, Global</h1>
  <p class="lead">The fundamental premise of the Direct Strength Method (DSM) is identifying the critical elastic buckling capacities for three primary independent modes: <strong>Local ($L$)</strong>, <strong>Distortional ($D$)</strong>, and <strong>Global ($G$)</strong>.</p>

  <h2>Comparison of the 3 Buckling Modes</h2>
  <table class="manual-table">
    <thead>
      <tr>
        <th>Buckling Mode</th>
        <th>Typical Half-Wavelength ($L$)</th>
        <th>Fold-Line / Corner Line Behavior</th>
        <th>Cross-Section Distortion</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>Local Buckling ($L$)</strong></td>
        <td>Comparable to plate width ($10 \\sim 150\\,\\text{mm}$)</td>
        <td><strong>Zero translation (Fixed fold lines)</strong></td>
        <td>Plate ripples between corners without corner motion.</td>
      </tr>
      <tr>
        <td><strong>Distortional Buckling ($D$)</strong></td>
        <td>Intermediate length ($150 \\sim 800\\,\\text{mm}$)</td>
        <td><strong>Flange-lip corner rotation & translation</strong></td>
        <td>Flanges/stiffeners rotate inward or outward.</td>
      </tr>
      <tr>
        <td><strong>Global Buckling ($G$)</strong></td>
        <td>Long member length ($> 1,000\\,\\text{mm}$)</td>
        <td><strong>Rigid-body translation and twist</strong></td>
        <td>Euler flexural, torsional, or flexural-torsional buckling.</td>
      </tr>
    </tbody>
  </table>

  <h2>Automated Identification Algorithm</h2>
  <ol>
    <li><strong>Signature Curve Minima Tracking</strong>: Identifies the first valley as Local ($P_{crl}, M_{crl}$) and the second valley as Distortional ($P_{crd}, M_{crd}$).</li>
    <li><strong>Cross-Section Displacement Decomposition</strong>: Assesses fold-line translation norms to verify physical mode purity.</li>
  </ol>
</div>
"""
    },

    "signature_curve": {
        "id": "signature_curve",
        "category_id": "fsm_buckling",
        "category_title": "3. FSM 탄성 좌굴해석 이론",
        "title": "시그니처 커브 및 3D 좌굴모드 시각화",
        "title_en": "Signature Curve & 3D Buckling Visualization",
        "summary": "Chart.js 기반 시그니처 커브(Signature Curve) 판독법, 반파장 스펙트럼 해석, Three.js 3D 모드 형상 렌더링을 설명합니다.",
        "summary_en": "Interpreting the signature curve buckling spectrum and exploring Three.js interactive 3D buckling mode visualizations.",
        "tags": ["시그니처커브", "3D뷰어", "Chart.js", "Three.js", "Signature Curve", "Visualization"],
        "content_html": """
<div class="manual-article">
  <h1>시그니처 커브 및 3D 좌굴모드 시각화</h1>
  <p class="lead"><strong>시그니처 커브(Signature Curve)</strong>는 부재의 반파장(Half-Wavelength, $L$) 변화에 따른 임계 탄성 좌굴하중 계수($\\lambda$)를 연속 곡선으로 표현한 공학 스펙트럼 차트입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>The signature curve plots critical elastic buckling load factor $\\lambda$ against half-wavelength $L$ on a logarithmic scale. Valleys represent local and distortional buckling limits.</p>
      </div>
    </div>
  </div>

  <h2>시그니처 커브 그래프 판독법</h2>
  <ul>
    <li><strong>X축 (반파장, $L$)</strong>: $10\\,\\text{mm}$부터 $10,000\\,\\text{mm}$까지 로그 스케일(Logarithmic Scale)로 표현됩니다.</li>
    <li><strong>Y축 (임계하중 계수, $\\lambda$)</strong>: 기준 항복하중에 대한 탄성 좌굴하중 비($P_{cr} / P_y$ 또는 $M_{cr} / M_y$)입니다.</li>
    <li><strong>첫 번째 최저점 ($\text{Min}_1$)</strong>: 국부좌굴 임계치 ($L_{crl}, P_{crl}$ 또는 $M_{crl}$)</li>
    <li><strong>두 번째 최저점 ($\text{Min}_2$)</strong>: 왜곡좌굴 임계치 ($L_{crd}, P_{crd}$ 또는 $M_{crd}$)</li>
    <li><strong>우측 하강 곡선</strong>: 부재 길이에 반비례하여 감소하는 전체 오일러/휨-비틀림 좌굴 영역</li>
  </ul>

  <h2>Three.js 기반 3D 좌굴모드 뷰어 인터랙션</h2>
  <div class="callout callout-success">
    <h4>🎮 3D 뷰어 조작 가이드</h4>
    <ul>
      <li><strong>마우스 좌클릭 드래그</strong>: 3D 모델 자유 궤도 회전 (Orbit Rotate)</li>
      <li><strong>마우스 우클릭 드래그</strong>: 화면 평행 이동 (Pan)</li>
      <li><strong>마우스 휠 스크롤</strong>: 줌 인 / 줌 아웃 (Zoom In/Out)</li>
      <li><strong>[애니메이션 재생/정지]</strong>: 좌굴 모드의 주기적 조화 진동 형상 실시간 재생</li>
    </ul>
  </div>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>Signature Curve & 3D Buckling Visualization</h1>
  <p class="lead">The <strong>Signature Curve</strong> provides a complete elastic buckling spectrum by plotting critical buckling load factors ($\\lambda$) against strip half-wavelengths ($L$).</p>

  <h2>Reading the Signature Curve</h2>
  <ul>
    <li><strong>X-Axis (Half-Wavelength $L$)</strong>: Spans $10\\,\\text{mm}$ to $10,000\\,\\text{mm}$ on a logarithmic scale.</li>
    <li><strong>Y-Axis (Load Factor $\\lambda$)</strong>: Non-dimensional ratio of elastic buckling capacity to yield capacity ($P_{cr}/P_y$ or $M_{cr}/M_y$).</li>
    <li><strong>First Local Valley ($\text{Min}_1$)</strong>: Critical Local Buckling ($L_{crl}, P_{crl}$ or $M_{crl}$).</li>
    <li><strong>Second Local Valley ($\text{Min}_2$)</strong>: Critical Distortional Buckling ($L_{crd}, P_{crd}$ or $M_{crd}$).</li>
    <li><strong>Ascending/Descending Tail</strong>: Global flexural-torsional buckling governed by overall member length.</li>
  </ul>

  <h2>Interactive Three.js 3D Viewer Navigation</h2>
  <div class="callout callout-success">
    <h4>🎮 3D Canvas Controls</h4>
    <ul>
      <li><strong>Left Mouse Drag</strong>: Orbit camera rotation around 3D section mesh.</li>
      <li><strong>Right Mouse Drag</strong>: Pan camera view across the screen.</li>
      <li><strong>Mouse Wheel</strong>: Dynamic zoom in / zoom out.</li>
      <li><strong>[Play/Pause Animation]</strong>: Triggers sinusoidal dynamic wave vibration of the buckling shape.</li>
    </ul>
  </div>
</div>
"""
    },

    # =========================================================================
    # 4. KDS 14 31 10 부재설계 & 계산서 (KDS Member Design & Reports)
    # =========================================================================
    "kds_dsm_comp": {
        "id": "kds_dsm_comp",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "KDS 14 31 10 압축부재 설계 (DSM Pn)",
        "title_en": "KDS 14 31 10 Compression Member Design (DSM Pn)",
        "summary": "KDS 14 31 10(AISI S100) 직접강도법(DSM) 압축공칭강도(Pn) 산정: 전체좌굴(Pne), 국부좌굴(Pnl), 왜곡좌굴(Pnd) 통합 설계식.",
        "summary_en": "Direct Strength Method nominal axial compressive strength (Pn) per KDS 14 31 10 / AISI S100: Global (Pne), Local (Pnl), and Distortional (Pnd).",
        "tags": ["KDS 14 31 10", "압축강도", "Pn", "DSM", "Pne", "Pnl", "Pnd", "Compression"],
        "content_html": """
<div class="manual-article">
  <h1>KDS 14 31 10 압축부재 설계 (DSM Pn)</h1>
  <p class="lead"><strong>KDS 14 31 10 (4.1.3)</strong> 및 <strong>AISI S100 Section E</strong>에 따른 직접강도법(DSM) 압축부재 공칭강도($P_n$)는 전체좌굴($P_{ne}$), 국부좌굴($P_{nl}$), 왜곡좌굴($P_{nd}$)의 최솟값으로 결정됩니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Nominal axial compressive strength $P_n$ under AISI S100 and KDS 14 31 10 is taken as the minimum of global buckling strength ($P_{ne}$), local buckling strength ($P_{nl}$), and distortional buckling strength ($P_{nd}$).</p>
      </div>
    </div>
  </div>

  <h2>1. 전체 휨/휨-비틀림 좌굴강도 ($P_{ne}$)</h2>
  <p>항복하중 $P_y = A_g F_y$ 및 탄성 전체좌굴하중 $P_{cre}$에 대해 세장비 계수 $\\lambda_c = \\sqrt{P_y / P_{cre}}$:</p>
  $$P_{ne} = \\begin{cases} 
  \\left( 0.658^{\\lambda_c^2} \\right) P_y & \\text{for } \\lambda_c \\le 1.5 \\\\
  \\left( \\frac{0.877}{\\lambda_c^2} \\right) P_y & \\text{for } \\lambda_c > 1.5 
  \\end{cases}$$

  <h2>2. 국부 좌굴강도 ($P_{nl}$)</h2>
  <p>세장비 계수 $\\lambda_l = \\sqrt{P_{ne} / P_{crl}}$:</p>
  $$P_{nl} = \\begin{cases} 
  P_{ne} & \\text{for } \\lambda_l \\le 0.776 \\\\
  \\left[ 1 - 0.15 \\left( \\frac{P_{crl}}{P_{ne}} \\right)^{0.4} \\right] \\left( \\frac{P_{crl}}{P_{ne}} \\right)^{0.4} P_{ne} & \\text{for } \\lambda_l > 0.776 
  \\end{cases}$$

  <h2>3. 왜곡 좌굴강도 ($P_{nd}$)</h2>
  <p>세장비 계수 $\\lambda_d = \\sqrt{P_y / P_{crd}}$:</p>
  $$P_{nd} = \\begin{cases} 
  P_y & \\text{for } \\lambda_d \\le 0.561 \\\\
  \\left[ 1 - 0.25 \\left( \\frac{P_{crd}}{P_y} \\right)^{0.6} \\right] \\left( \\frac{P_{crd}}{P_y} \\right)^{0.6} P_y & \\text{for } \\lambda_d > 0.561 
  \\end{cases}$$

  <h2>4. 최종 설계 압축강도 (Design Strength)</h2>
  $$P_n = \\min(P_{ne}, P_{nl}, P_{nd})$$
  $$\\phi_c P_n = 0.85 P_n \\quad (\\text{LRFD / LSD}), \\quad P_n / \\Omega_c = \\frac{P_n}{1.80} \\quad (\\text{ASD})$$
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>KDS 14 31 10 Compression Member Design (DSM Pn)</h1>
  <p class="lead">Under <strong>KDS 14 31 10 (Clause 4.1.3)</strong> and <strong>AISI S100 Section E</strong>, the nominal compressive capacity ($P_n$) is governed by the lower bound of global ($P_{ne}$), local ($P_{nl}$), and distortional ($P_{nd}$) buckling strengths.</p>

  <h2>1. Global Buckling Strength ($P_{ne}$)</h2>
  <p>With yield capacity $P_y = A_g F_y$ and non-dimensional slenderness $\\lambda_c = \\sqrt{P_y / P_{cre}}$:</p>
  $$P_{ne} = \\begin{cases} 
  \\left( 0.658^{\\lambda_c^2} \\right) P_y & \\text{for } \\lambda_c \\le 1.5 \\\\
  \\left( \\frac{0.877}{\\lambda_c^2} \\right) P_y & \\text{for } \\lambda_c > 1.5 
  \\end{cases}$$

  <h2>2. Local Buckling Strength ($P_{nl}$)</h2>
  <p>With local slenderness $\\lambda_l = \\sqrt{P_{ne} / P_{crl}}$:</p>
  $$P_{nl} = \\begin{cases} 
  P_{ne} & \\text{for } \\lambda_l \\le 0.776 \\\\
  \\left[ 1 - 0.15 \\left( \\frac{P_{crl}}{P_{ne}} \\right)^{0.4} \\right] \\left( \\frac{P_{crl}}{P_{ne}} \\right)^{0.4} P_{ne} & \\text{for } \\lambda_l > 0.776 
  \\end{cases}$$

  <h2>3. Distortional Buckling Strength ($P_{nd}$)</h2>
  <p>With distortional slenderness $\\lambda_d = \\sqrt{P_y / P_{crd}}$:</p>
  $$P_{nd} = \\begin{cases} 
  P_y & \\text{for } \\lambda_d \\le 0.561 \\\\
  \\left[ 1 - 0.25 \\left( \\frac{P_{crd}}{P_y} \\right)^{0.6} \\right] \\left( \\frac{P_{crd}}{P_y} \\right)^{0.6} P_y & \\text{for } \\lambda_d > 0.561 
  \\end{cases}$$

  <h2>4. Final Design Compressive Capacity</h2>
  $$P_n = \\min(P_{ne}, P_{nl}, P_{nd})$$
  $$\\phi_c P_n = 0.85 P_n \\quad (\\text{LRFD}), \\quad P_n / \\Omega_c = \\frac{P_n}{1.80} \\quad (\\text{ASD})$$
</div>
"""
    },

    "kds_dsm_flex": {
        "id": "kds_dsm_flex",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "KDS 14 31 10 휨부재 설계 (DSM Mn)",
        "title_en": "KDS 14 31 10 Flexural Member Design (DSM Mn)",
        "summary": "KDS 14 31 10 휨재 공칭강도(Mn) 산정: 횡비틀림좌굴(Mne), 국부좌굴(Mnl), 왜곡좌굴(Mnd) 및 비탄성 모멘트 증대 효과.",
        "summary_en": "Direct Strength Method nominal flexural strength (Mn) per KDS 14 31 10 / AISI S100: Lateral-torsional (Mne), Local (Mnl), and Distortional (Mnd).",
        "tags": ["KDS 14 31 10", "휨강도", "Mn", "DSM", "LTB", "Mne", "Mnl", "Mnd", "Flexure"],
        "content_html": """
<div class="manual-article">
  <h1>KDS 14 31 10 휨부재 설계 (DSM Mn)</h1>
  <p class="lead"><strong>KDS 14 31 10 (4.1.4)</strong> 및 <strong>AISI S100 Section F</strong>에 따른 직접강도법(DSM) 휨부재 공칭강도($M_n$)는 횡비틀림좌굴(<span class="glossary-term" data-en="Lateral-Torsional Buckling (LTB)" data-def="Global buckling mode where a beam deflects laterally and twists under flexure.">LTB, $M_{ne}$</span>), 국부좌굴($M_{nl}$), 왜곡좌굴($M_{nd}$) 중 최솟값으로 산정됩니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Nominal flexural capacity $M_n$ under AISI S100 and KDS 14 31 10 is taken as the minimum of lateral-torsional buckling ($M_{ne}$), local buckling ($M_{nl}$), and distortional buckling ($M_{nd}$).</p>
      </div>
    </div>
  </div>

  <h2>1. 횡비틀림 좌굴강도 ($M_{ne}$)</h2>
  <p>항복모멘트 $M_y = S_f F_y$ 및 탄성 LTB 모멘트 $M_{cre}$에 대해:</p>
  $$M_{ne} = \\begin{cases} 
  M_{cre} & \\text{for } M_{cre} < 0.56 M_y \\\\
  \\frac{10}{9} M_y \\left( 1 - \\frac{10 M_y}{36 M_{cre}} \\right) \\le M_y & \\text{for } 0.56 M_y \\le M_{cre} \\le 2.78 M_y \\\\
  M_y & \\text{for } M_{cre} > 2.78 M_y 
  \\end{cases}$$

  <h2>2. 국부 좌굴강도 ($M_{nl}$)</h2>
  <p>세장비 계수 $\\lambda_l = \\sqrt{M_{ne} / M_{crl}}$:</p>
  $$M_{nl} = \\begin{cases} 
  M_{ne} & \\text{for } \\lambda_l \\le 0.776 \\\\
  \\left[ 1 - 0.15 \\left( \\frac{M_{crl}}{M_{ne}} \\right)^{0.4} \\right] \\left( \\frac{M_{crl}}{M_{ne}} \\right)^{0.4} M_{ne} & \\text{for } \\lambda_l > 0.776 
  \\end{cases}$$

  <h2>3. 왜곡 좌굴강도 ($M_{nd}$)</h2>
  <p>세장비 계수 $\\lambda_d = \\sqrt{M_y / M_{crd}}$:</p>
  $$M_{nd} = \\begin{cases} 
  M_y & \\text{for } \\lambda_d \\le 0.673 \\\\
  \\left[ 1 - 0.22 \\left( \\frac{M_{crd}}{M_y} \\right)^{0.5} \\right] \\left( \\frac{M_{crd}}{M_y} \\right)^{0.5} M_y & \\text{for } \\lambda_d > 0.673 
  \\end{cases}$$

  <h2>4. 최종 설계 휨강도 (Design Flexural Strength)</h2>
  $$M_n = \\min(M_{ne}, M_{nl}, M_{nd})$$
  $$\\phi_b M_n = 0.90 M_n \\quad (\\text{LRFD / LSD}), \\quad M_n / \\Omega_b = \\frac{M_n}{1.67} \\quad (\\text{ASD})$$
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>KDS 14 31 10 Flexural Member Design (DSM Mn)</h1>
  <p class="lead">Per <strong>KDS 14 31 10 (Clause 4.1.4)</strong> and <strong>AISI S100 Section F</strong>, nominal flexural capacity ($M_n$) is governed by the minimum of lateral-torsional ($M_{ne}$), local ($M_{nl}$), and distortional ($M_{nd}$) buckling strengths.</p>

  <h2>1. Lateral-Torsional Buckling Strength ($M_{ne}$)</h2>
  <p>With yield moment $M_y = S_f F_y$ and elastic LTB moment $M_{cre}$:</p>
  $$M_{ne} = \\begin{cases} 
  M_{cre} & \\text{for } M_{cre} < 0.56 M_y \\\\
  \\frac{10}{9} M_y \\left( 1 - \\frac{10 M_y}{36 M_{cre}} \\right) \\le M_y & \\text{for } 0.56 M_y \\le M_{cre} \\le 2.78 M_y \\\\
  M_y & \\text{for } M_{cre} > 2.78 M_y 
  \\end{cases}$$

  <h2>2. Local Buckling Strength ($M_{nl}$)</h2>
  <p>With local slenderness $\\lambda_l = \\sqrt{M_{ne} / M_{crl}}$:</p>
  $$M_{nl} = \\begin{cases} 
  M_{ne} & \\text{for } \\lambda_l \\le 0.776 \\\\
  \\left[ 1 - 0.15 \\left( \\frac{M_{crl}}{M_{ne}} \\right)^{0.4} \\right] \\left( \\frac{M_{crl}}{M_{ne}} \\right)^{0.4} M_{ne} & \\text{for } \\lambda_l > 0.776 
  \\end{cases}$$

  <h2>3. Distortional Buckling Strength ($M_{nd}$)</h2>
  <p>With distortional slenderness $\\lambda_d = \\sqrt{M_y / M_{crd}}$:</p>
  $$M_{nd} = \\begin{cases} 
  M_y & \\text{for } \\lambda_d \\le 0.673 \\\\
  \\left[ 1 - 0.22 \\left( \\frac{M_{crd}}{M_y} \\right)^{0.5} \\right] \\left( \\frac{M_{crd}}{M_y} \\right)^{0.5} M_y & \\text{for } \\lambda_d > 0.673 
  \\end{cases}$$

  <h2>4. Final Design Flexural Capacity</h2>
  $$M_n = \\min(M_{ne}, M_{nl}, M_{nd})$$
  $$\\phi_b M_n = 0.90 M_n \\quad (\\text{LRFD}), \\quad M_n / \\Omega_b = \\frac{M_n}{1.67} \\quad (\\text{ASD})$$
</div>
"""
    },

    "kds_shear_crip": {
        "id": "kds_shear_crip",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "KDS 전단강도(Vn) 및 웨브 크리플링(Pnc)",
        "title_en": "KDS Shear Strength (Vn) & Web Crippling (Pnc)",
        "summary": "웨브 탄성전단좌굴(Vn), 전단좌굴계수(kv), 집중지압하중에 대한 웨브 크리플링(Pnc) 4대 지지조건별 계수(C, CR, CN, Ch) 산정식.",
        "summary_en": "Covers shear capacity (Vn) via web shear buckling and web crippling (Pnc) under 4 loading conditions (EOF, IOF, ETF, ITF).",
        "tags": ["전단강도", "Vn", "웨브크리플링", "Pnc", "지압", "Shear", "Web Crippling"],
        "content_html": """
<div class="manual-article">
  <h1>KDS 전단강도(Vn) 및 웨브 크리플링(Pnc)</h1>
  <p class="lead">냉간성형강 박판 웨브 부재는 전단력에 의한 <strong>전단좌굴강도($V_n$)</strong> 및 집중 반력 작용부에서의 <strong>웨브 크리플링(<span class="glossary-term" data-en="Web Crippling (Pnc)" data-def="Local failure of thin webs under heavy concentrated transverse loads or support reactions.">Web Crippling, $P_{nc}$</span>)</strong>에 대한 안전성 검토가 필수적입니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Shear strength $V_n$ and web crippling strength $P_{nc}$ are calculated per AISI S100 and KDS 14 31 10 Chapter 4. Web crippling considers 4 loading conditions: End-One-Flange (EOF), Interior-One-Flange (IOF), End-Two-Flange (ETF), and Interior-Two-Flange (ITF).</p>
      </div>
    </div>
  </div>

  <h2>1. 공칭 전단강도 ($V_n$)</h2>
  <p>웨브 높이 $h$ 및 두께 $t$, 전단좌굴계수 $k_v = 5.34$에 대해 전단 세장비 $\\lambda_v = \\frac{h/t}{\\sqrt{E k_v / F_y}}$:</p>
  $$V_n = \\begin{cases} 
  A_w (0.60 F_y) & \\text{for } \\lambda_v \\le 0.815 \\\\
  A_w \\left( \\frac{0.489 F_y}{\\lambda_v} \\right) & \\text{for } 0.815 < \\lambda_v \\le 1.227 \\\\
  A_w \\left( \\frac{0.60 F_y}{\\lambda_v^2} \\right) & \\text{for } \\lambda_v > 1.227 
  \\end{cases}$$

  <h2>2. 웨브 크리플링 공칭강도 ($P_{nc}$)</h2>
  <p>집중하중 폭 $N$, 내부 절곡반경 $R$, 웨브 높이 $h$에 대한 KDS 표준 통일 경험식:</p>
  $$P_{nc} = C \\cdot t^2 \\cdot F_y \\cdot \\sin\\theta \\cdot \\left[ 1 - C_R \\sqrt{\\frac{R}{t}} \\right] \\left[ 1 + C_N \\sqrt{\\frac{N}{t}} \\right] \\left[ 1 - C_h \\sqrt{\\frac{h}{t}} \\right]$$

  <h3>4대 하중/지지 조건 계수</h3>
  <table class="manual-table">
    <thead>
      <tr>
        <th>하중 조건</th>
        <th>$C$</th>
        <th>$C_R$</th>
        <th>$C_N$</th>
        <th>$C_h$</th>
      </tr>
    </thead>
    <tbody>
      <tr><td>단부 1-플랜지 하중 (EOF)</td><td>4.0</td><td>0.14</td><td>0.35</td><td>0.02</td></tr>
      <tr><td>내부 1-플랜지 하중 (IOF)</td><td>13.0</td><td>0.23</td><td>0.14</td><td>0.01</td></tr>
      <tr><td>단부 2-플랜지 하중 (ETF)</td><td>7.5</td><td>0.08</td><td>0.12</td><td>0.048</td></tr>
      <tr><td>내부 2-플랜지 하중 (ITF)</td><td>20.0</td><td>0.10</td><td>0.08</td><td>0.031</td></tr>
    </tbody>
  </table>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>KDS Shear Strength (Vn) & Web Crippling (Pnc)</h1>
  <p class="lead">Thin webs in cold-formed members must be verified against <strong>shear buckling ($V_n$)</strong> and local transverse concentrated reaction failure known as <strong>web crippling ($P_{nc}$)</strong>.</p>

  <h2>1. Nominal Shear Strength ($V_n$)</h2>
  <p>For clear web height $h$, thickness $t$, and shear buckling coefficient $k_v = 5.34$:</p>
  $$V_n = \\begin{cases} 
  A_w (0.60 F_y) & \\text{for } \\lambda_v \\le 0.815 \\\\
  A_w \\left( \\frac{0.489 F_y}{\\lambda_v} \\right) & \\text{for } 0.815 < \\lambda_v \\le 1.227 \\\\
  A_w \\left( \\frac{0.60 F_y}{\\lambda_v^2} \\right) & \\text{for } \\lambda_v > 1.227 
  \\end{cases}$$

  <h2>2. Nominal Web Crippling Strength ($P_{nc}$)</h2>
  <p>Unified semi-empirical equation per AISI S100 and KDS 14 31 10:</p>
  $$P_{nc} = C \\cdot t^2 \\cdot F_y \\cdot \\sin\\theta \\cdot \\left[ 1 - C_R \\sqrt{\\frac{R}{t}} \\right] \\left[ 1 + C_N \\sqrt{\\frac{N}{t}} \\right] \\left[ 1 - C_h \\sqrt{\\frac{h}{t}} \\right]$$

  <h3>Coefficients for the 4 Loading Conditions</h3>
  <table class="manual-table">
    <thead>
      <tr>
        <th>Loading Condition</th>
        <th>$C$</th>
        <th>$C_R$</th>
        <th>$C_N$</th>
        <th>$C_h$</th>
      </tr>
    </thead>
    <tbody>
      <tr><td>End-One-Flange (EOF)</td><td>4.0</td><td>0.14</td><td>0.35</td><td>0.02</td></tr>
      <tr><td>Interior-One-Flange (IOF)</td><td>13.0</td><td>0.23</td><td>0.14</td><td>0.01</td></tr>
      <tr><td>End-Two-Flange (ETF)</td><td>7.5</td><td>0.08</td><td>0.12</td><td>0.048</td></tr>
      <tr><td>Interior-Two-Flange (ITF)</td><td>20.0</td><td>0.10</td><td>0.08</td><td>0.031</td></tr>
    </tbody>
  </table>
</div>
"""
    },

    "kds_interaction": {
        "id": "kds_interaction",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "P-M 조합응력 및 2축 휨-압축 검토",
        "title_en": "P-M Interaction & Biaxial Bending Check",
        "summary": "KDS 14 31 10 휨-압축 조합부재(Beam-Column) 상관식(Interaction Equations), 모멘트 증대계수(B1, B2) 및 D/C Ratio 판정 원리.",
        "summary_en": "Formulates beam-column interaction equations under axial compression and biaxial bending per KDS 14 31 10 / AISI S100.",
        "tags": ["조합응력", "P-M", "2축휨", "DC Ratio", "Beam-Column", "Interaction"],
        "content_html": """
<div class="manual-article">
  <h1>P-M 조합응력 및 2축 휨-압축 검토</h1>
  <p class="lead">축압축력($P_u$)과 2축 휨모멘트($M_{ux}, M_{uy}$)가 동시에 작용하는 부재는 <strong>KDS 14 31 10 (4.1.5)</strong>의 휨-압축 상관곡선(P-M Interaction Equation)을 통해 D/C Ratio($\\le 1.0$)를 검증합니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>Combined axial compression and biaxial flexure are checked using the AISI S100 and KDS 14 31 10 beam-column interaction formulas including moment amplification factors $B_1$ and $B_2$.</p>
      </div>
    </div>
  </div>

  <h2>1. 휨-압축 상관 지배방정식</h2>
  <p>축력비와 2차 효과 모멘트 증대계수($B_1$)를 고려한 3차원 상호작용 검토식:</p>
  $$\\frac{P_u}{\\phi_c P_n} + \\frac{C_{mx} M_{ux}}{\\phi_b M_{nx} \\left(1 - \\frac{P_u}{P_{E1x}}\\right)} + \\frac{C_{my} M_{uy}}{\\phi_b M_{ny} \\left(1 - \\frac{P_u}{P_{E1y}}\\right)} \\le 1.0$$
  <p>여기서 $P_{E1} = \\frac{\\pi^2 E I}{(K_1 L)^2}$ 은 해당 축에 대한 오일러 탄성좌굴하중이며, $C_m = 0.6 - 0.4(M_1/M_2)$ 는 모멘트 구배 보정계수입니다.</p>

  <h2>2. 단면 내력 검토 (Cross-Section Strength)</h2>
  <p>전체 좌굴 효과를 배제하고 국부 항복 및 국부좌굴에 대한 단면 자체의 내력을 검증합니다:</p>
  $$\\frac{P_u}{\\phi_c P_{n0}} + \\frac{M_{ux}}{\\phi_b M_{nx0}} + \\frac{M_{uy}}{\\phi_b M_{ny0}} \\le 1.0$$

  <h2>3. D/C Ratio 및 안전율 판정 기준</h2>
  <ul>
    <li><strong>$\text{D/C Ratio} \\le 1.00$</strong>: <span style="color:var(--accent-success); font-weight:700;">[OK] 구조적 안전성 만족</span></li>
    <li><strong>$\text{D/C Ratio} > 1.00$</strong>: <span style="color:var(--accent-danger); font-weight:700;">[NG] 내력 초과 (단면 보강 또는 두께 증가 필요)</span></li>
  </ul>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>P-M Interaction & Biaxial Bending Check</h1>
  <p class="lead">Members subjected to simultaneous axial compression ($P_u$) and biaxial bending moments ($M_{ux}, M_{uy}$) are evaluated using the <strong>KDS 14 31 10 (Clause 4.1.5)</strong> and <strong>AISI S100 Section H</strong> interaction equations.</p>

  <h2>1. Beam-Column Governing Interaction Formula</h2>
  <p>Accounting for second-order P-delta moment magnification factors ($B_1$):</p>
  $$\\frac{P_u}{\\phi_c P_n} + \\frac{C_{mx} M_{ux}}{\\phi_b M_{nx} \\left(1 - \\frac{P_u}{P_{E1x}}\\right)} + \\frac{C_{my} M_{uy}}{\\phi_b M_{ny} \\left(1 - \\frac{P_u}{P_{E1y}}\\right)} \\le 1.0$$
  <p>where $P_{E1} = \\frac{\\pi^2 E I}{(K_1 L)^2}$ is the Euler elastic buckling capacity and $C_m = 0.6 - 0.4(M_1/M_2)$ is the moment gradient factor.</p>

  <h2>2. Cross-Section Yield & Local Strength Check</h2>
  $$\\frac{P_u}{\\phi_c P_{n0}} + \\frac{M_{ux}}{\\phi_b M_{nx0}} + \\frac{M_{uy}}{\\phi_b M_{ny0}} \\le 1.0$$

  <h2>3. Demand-to-Capacity (D/C) Evaluation</h2>
  <ul>
    <li><strong>$\text{D/C Ratio} \\le 1.00$</strong>: <span style="color:var(--accent-success); font-weight:700;">[OK] Satisfies structural design limits.</span></li>
    <li><strong>$\text{D/C Ratio} > 1.00$</strong>: <span style="color:var(--accent-danger); font-weight:700;">[NG] Overstressed. Requires increased thickness or stiffeners.</span></li>
  </ul>
</div>
"""
    },

    "report_guide": {
        "id": "report_guide",
        "category_id": "kds_design",
        "category_title": "4. KDS 14 31 10 부재설계 & 계산서",
        "title": "A4 구조계산서 출력 및 인쇄 가이드",
        "title_en": "A4 Engineering Calculation Report Guide",
        "summary": "구조 인허가 및 심의용 A4 계산서 모달, 단면 제원표, FSM 좌굴 해석 결과, KDS 설계식 산출근거 및 브라우저 PDF 인쇄 최적화 가이드.",
        "summary_en": "Guidelines for formal multi-page A4 engineering reports, design code references, and browser PDF printing optimizations.",
        "tags": ["계산서", "인쇄", "PDF", "A4", "심의", "Report", "Print"],
        "content_html": """
<div class="manual-article">
  <h1>A4 구조계산서 출력 및 인쇄 가이드</h1>
  <p class="lead">CFDesigner는 구조기술사 심의 및 인허가 제출에 즉시 활용할 수 있는 <strong>공식 A4 구조계산서(Engineering Calculation Sheet)</strong> 생성 엔진을 내장하고 있습니다.</p>

  <div class="en-toggle-wrapper">
    <button class="btn-toggle-en" onclick="window.manualViewer.toggleInlineEn(this)">🌐 원문 보기 (View Original)</button>
    <div class="inline-en-box" style="display: none;">
      <div class="en-box-header"><span class="en-badge">ORIGINAL REFERENCE</span></div>
      <div class="en-box-content">
        <p>CFDesigner generates comprehensive, submission-ready A4 calculation reports containing section geometry tables, FSM buckling spectra, step-by-step KDS/AISI design equations, and formal engineering stamp headers.</p>
      </div>
    </div>
  </div>

  <h2>계산서 구성 체계</h2>
  <ol>
    <li><strong>문서 헤더 및 프로젝트 정보</strong>: 프로젝트명, 부재명, 검토일자, 구조설계 기준(KDS 14 31 10: 2021).</li>
    <li><strong>단면 기하학적 성질 요약표</strong>: 단면 형상 2D 다이어그램, $A_g, I_x, I_y, I_{xy}, C_w, J, x_0, y_0, r_0$.</li>
    <li><strong>FSM 탄성 좌굴해석 스펙트럼</strong>: 시그니처 커브 차트, 국부/왜곡/전체 임계좌굴하중($P_{crl}, P_{crd}, P_{cre}$).</li>
    <li><strong>KDS 부재설계 상세 산출근거</strong>: 압축강도($P_n$), 휨강도($M_n$), 전단강도($V_n$), D/C Ratio 및 판정.</li>
    <li><strong>서명란</strong>: 작성자 및 구조기술사(PE) 날인 란.</li>
  </ol>

  <h2>PDF 인쇄 및 저장 방법</h2>
  <div class="callout callout-info">
    <h4>🖨️ 인쇄 가이드</h4>
    <p>상단 헤더의 <strong>[📄 A4 구조계산서]</strong> 버튼을 누른 후, 모달 우측 상단의 <strong>[🖨️ PDF 인쇄/저장]</strong>을 클릭하면 브라우저 인쇄 대화상자에서 'PDF로 저장'을 선택할 수 있습니다. 페이지 분할(Page Break) CSS가 적용되어 A4 용지 규격에 정확히 맞추어 출력됩니다.</p>
  </div>
</div>
""",
        "content_en_html": """
<div class="manual-article en-article">
  <h1>A4 Engineering Calculation Report Guide</h1>
  <p class="lead">CFDesigner features an automated formal <strong>A4 Engineering Calculation Sheet</strong> generator formatted for structural peer reviews, building permit submissions, and client deliverables.</p>

  <h2>Report Structure & Components</h2>
  <ol>
    <li><strong>Project Header & Metadata</strong>: Project name, member mark, design date, and governing code (KDS 14 31 10 / AISI S100).</li>
    <li><strong>Cross-Section Property Summary</strong>: 2D dimensioned section graphic, $A_g, I_x, I_y, C_w, J, S_C(x_0, y_0), r_0$.</li>
    <li><strong>FSM Elastic Buckling Spectrum</strong>: Signature curve plot and critical buckling loads ($P_{crl}, P_{crd}, P_{cre}$).</li>
    <li><strong>Design Strength Calculations</strong>: Step-by-step nominal strengths ($P_n, M_n, V_n$), safety factors, and D/C ratios.</li>
    <li><strong>Professional Engineering Seal</strong>: Designer review and PE stamp approval blocks.</li>
  </ol>

  <h2>PDF Export & Print Instructions</h2>
  <div class="callout callout-info">
    <h4>🖨️ Print Setup</h4>
    <p>Click the <strong>[📄 A4 Calculation Report]</strong> button on the top toolbar, then click <strong>[🖨️ Print / Save as PDF]</strong>. Built-in print CSS page-break rules automatically format clean, multi-page A4 documents without element clipping.</p>
  </div>
</div>
"""
    }
}
