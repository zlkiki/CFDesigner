"""
CFDesigner Online Help Manual Content Dataset
KDS 14 31 10 & AISI S100 based Engineering Manual (25 Topics across 6 Categories)
Bilingual Dataset: Korean (KDS Modernized & AltDP Web UX) & English (CFS 14.0 Ground Truth Reference)
"""

CATEGORIES = [   {   'id': 'getting_started',
        'title': '1. 시작하기 & 웹 UI 가이드',
        'title_en': '1. Getting Started & Web UI Guide',
        'icon': '🚀',
        'topics': [   'intro',
                      'ui_layout',
                      'wizard',
                      'dxf_import',
                      'element_grid',
                      'geom_transform']},
    {   'id': 'section_library',
        'title': '2. 단면 라이브러리 & 재료 물성치',
        'title_en': '2. Section Library & Material DB',
        'icon': '📚',
        'topics': ['section_lib', 'material_db', 'cold_work']},
    {   'id': 'section_properties',
        'title': '3. 단면 기하학적 성질 & 유효단면',
        'title_en': '3. Section Properties & Effective Stress',
        'icon': '📐',
        'topics': [   'gross_props',
                      'torsion_props',
                      'principal_axes',
                      'effective_props']},
    {   'id': 'fsm_buckling',
        'title': '4. FSM 탄성 좌굴해석 이론',
        'title_en': '4. Finite Strip Method (FSM) Buckling',
        'icon': '🔬',
        'topics': [   'fsm_theory',
                      'buckling_modes',
                      'signature_curve',
                      'fsm_params']},
    {   'id': 'kds_design',
        'title': '5. KDS 14 31 10 부재설계 & 계산서',
        'title_en': '5. KDS 14 31 10 Member Design & Reports',
        'icon': '🏛️',
        'topics': [   'kds_dsm_comp',
                      'kds_dsm_flex',
                      'kds_shear_crip',
                      'quick_design',
                      'kds_interaction',
                      'report_guide']},
    {   'id': 'frame_analysis',
        'title': '6. 1D 뼈대 구조해석',
        'title_en': '6. 1D Frame Structural Analysis',
        'icon': '🌉',
        'topics': ['analysis_wizard', 'diagrams_viewer']}]

TOPICS = {   'intro': {   'id': 'intro',
                 'category_id': 'getting_started',
                 'category_title': '1. 시작하기 & 웹 UI 가이드',
                 'title': '시스템 소개 및 특징',
                 'title_en': 'System Overview & Features',
                 'summary': 'CFDesigner는 냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS 14 31 '
                            '10 / AISI S100 부재설계 클라우드 시스템입니다.',
                 'summary_en': 'CFDesigner is a cloud-based engineering system '
                               'for cold-formed steel section analysis, FSM '
                               'buckling, and KDS 14 31 10 / AISI S100 design.',
                 'tags': [   '소개',
                             'FSM',
                             'KDS 14 31 10',
                             'AISI S100',
                             'AltDP',
                             'Overview',
                             'Web UI'],
                 'content_html': '\n'
                                 '<div class="manual-article">\n'
                                 '  <h1>시스템 소개 및 특징</h1>\n'
                                 '  <p '
                                 'class="lead"><strong>CFDesigner</strong>는 '
                                 '냉간성형강(<span class="glossary-term" '
                                 'data-en="Cold-Formed Steel (CFS)" '
                                 'data-def="Steel products shaped at ambient '
                                 'temperature by roll forming or press '
                                 'braking.">Cold-Formed Steel</span>)의 임의 형상 '
                                 '비정형 단면에 대해 <strong>유한대판법(<span '
                                 'class="glossary-term" data-en="Finite Strip '
                                 'Method (FSM)" data-def="A specialized '
                                 'semi-analytical numerical method combining '
                                 'finite elements across the section with '
                                 'Fourier series along the length.">Finite '
                                 'Strip Method, FSM</span>)</strong> 탄성 좌굴해석과 '
                                 '<strong>KDS 14 31 10(냉간성형강구조설계기준)</strong> 및 '
                                 '<strong>AISI S100 직접강도법(<span '
                                 'class="glossary-term" data-en="Direct '
                                 'Strength Method (DSM)" data-def="Design '
                                 'method using elastic buckling loads of the '
                                 'full cross section instead of effective '
                                 'widths.">DSM</span>)</strong> 설계를 원클릭으로 수행하는 '
                                 '차세대 SaaS 웹 엔지니어링 솔루션입니다.</p>\n'
                                 '\n'
                                 '  <div class="en-toggle-wrapper">\n'
                                 '    <button class="btn-toggle-en" '
                                 'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                 '원문 보기 (View Original)</button>\n'
                                 '    <div class="inline-en-box" '
                                 'style="display: none;">\n'
                                 '      <div class="en-box-header"><span '
                                 'class="en-badge">ORIGINAL '
                                 'REFERENCE</span></div>\n'
                                 '      <div class="en-box-content">\n'
                                 '        <p><strong>CFDesigner</strong> is a '
                                 'comprehensive software package for cross '
                                 'section property calculation, elastic '
                                 'buckling analysis via Finite Strip Method '
                                 '(FSM), and member strength design in '
                                 'accordance with AISI S100 and KDS 14 31 10 '
                                 'specifications.</p>\n'
                                 '      </div>\n'
                                 '    </div>\n'
                                 '  </div>\n'
                                 '\n'
                                 '  <div class="callout callout-info">\n'
                                 '    <h4>💡 핵심 개발 배경 및 목표</h4>\n'
                                 '    <p>기존 북미 중심의 상용 CFS 프로그램의 로컬 환경 종속성을 '
                                 '극복하고, 현대적인 AltDP 웹 인터페이스(2D CAD 캔버스, '
                                 'Three.js 3D 좌굴 형상 뷰어, Chart.js 시그니처 커브) 및 '
                                 'KDS 한글 기준을 완벽하게 통합하였습니다.</p>\n'
                                 '  </div>\n'
                                 '\n'
                                 '  <h2>주요 기능 및 시스템 특징</h2>\n'
                                 '  <div class="feature-grid">\n'
                                 '    <div class="feature-card">\n'
                                 '      <div class="feature-icon">📐</div>\n'
                                 '      <h3>AutoCAD DXF & 마법사</h3>\n'
                                 '      <p>표준 6종 단면(C, Z, 모자형, 각형관, L형강, 데크) '
                                 '파라메트릭 생성 및 비정형 DXF 폴리라인 자동 메싱.</p>\n'
                                 '    </div>\n'
                                 '    <div class="feature-card">\n'
                                 '      <div class="feature-icon">⚙️</div>\n'
                                 '      <h3>단면 성질 정밀 해석</h3>\n'
                                 '      <p>총단면적($A_g$), 도심($C_G$), 생브낭 '
                                 '비틀림($J$), 섹터모멘트 기반 뒴상수($C_w$), 전단중심($S_C$), '
                                 '주축($I_1, I_2$).</p>\n'
                                 '    </div>\n'
                                 '    <div class="feature-card">\n'
                                 '      <div class="feature-icon">🔬</div>\n'
                                 '      <h3>FSM 탄성 좌굴 해석</h3>\n'
                                 '      <p>길이방향 사인 조화급수 전개와 엄밀 강성행렬($[K_e], '
                                 '[K_g]$) 조립을 통한 국부/왜곡/전체 좌굴하중 산정.</p>\n'
                                 '    </div>\n'
                                 '    <div class="feature-card">\n'
                                 '      <div class="feature-icon">🏛️</div>\n'
                                 '      <h3>KDS 14 31 10 부재 설계</h3>\n'
                                 '      <p>직접강도법(DSM) 기반 압축($P_n$), 휨($M_n$), '
                                 '전단($V_n$), 웨브 크리플링($P_{nc}$), P-M 조합응력 및 A4 '
                                 '계산서 출력.</p>\n'
                                 '    </div>\n'
                                 '  </div>\n'
                                 '</div>\n',
                 'content_en_html': '\n'
                                    '<div class="manual-article en-article">\n'
                                    '  <h1>System Overview & Features</h1>\n'
                                    '  <p '
                                    'class="lead"><strong>CFDesigner</strong> '
                                    'is a state-of-the-art cloud-based SaaS '
                                    'engineering platform designed for '
                                    'cross-section property computation, '
                                    '<strong>Finite Strip Method '
                                    '(FSM)</strong> elastic buckling analysis, '
                                    'and member strength verification under '
                                    '<strong>KDS 14 31 10</strong> and '
                                    '<strong>AISI S100 (Direct Strength '
                                    'Method, DSM)</strong> '
                                    'specifications.</p>\n'
                                    '\n'
                                    '  <div class="callout callout-info">\n'
                                    '    <h4>💡 Core Philosophy & '
                                    'Objective</h4>\n'
                                    '    <p>By overcoming the limitations of '
                                    'legacy desktop CFS software, CFDesigner '
                                    'delivers a modern AltDP web interface (2D '
                                    'CAD Canvas, Three.js 3D Buckling '
                                    'Visualization, and Chart.js Signature '
                                    'Curves) with exact Ground Truth numerical '
                                    'compliance.</p>\n'
                                    '  </div>\n'
                                    '</div>\n'},
    'ui_layout': {   'id': 'ui_layout',
                     'category_id': 'getting_started',
                     'category_title': '1. 시작하기 & 웹 UI 가이드',
                     'title': '웹 UI 4분할 레이아웃 가이드',
                     'title_en': 'Web UI 4-Quadrant Layout Guide',
                     'summary': 'CFDesigner 메인 대시보드의 반응형 4분할 워크스페이스 레이아웃 구성 및 '
                                '조작법을 설명합니다.',
                     'summary_en': 'Explains the responsive 4-quadrant '
                                   'workspace layout and navigation controls '
                                   'of the CFDesigner web UI.',
                     'tags': [   'UI',
                                 '레이아웃',
                                 '대시보드',
                                 '캔버스',
                                 'Workspace',
                                 'Layout'],
                     'content_html': '\n'
                                     '<div class="manual-article">\n'
                                     '  <h1>웹 UI 4분할 레이아웃 가이드</h1>\n'
                                     '  <p class="lead">CFDesigner는 엔지니어링 작업 '
                                     '효율을 극대화하기 위해 <strong>반응형 4분할 '
                                     '워크스페이스(4-Quadrant Layout)</strong> 구조를 '
                                     '채택하고 있습니다.</p>\n'
                                     '\n'
                                     '  <div class="en-toggle-wrapper">\n'
                                     '    <button class="btn-toggle-en" '
                                     'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                     '원문 보기 (View Original)</button>\n'
                                     '    <div class="inline-en-box" '
                                     'style="display: none;">\n'
                                     '      <div class="en-box-header"><span '
                                     'class="en-badge">ORIGINAL '
                                     'REFERENCE</span></div>\n'
                                     '      <div class="en-box-content">\n'
                                     '        <p>The CFS interface is divided '
                                     'into primary workspace areas: the '
                                     'Section Window for geometry and '
                                     'properties, the Analysis Window for '
                                     'buckling curves, and Member Check panels '
                                     'for design results.</p>\n'
                                     '      </div>\n'
                                     '    </div>\n'
                                     '  </div>\n'
                                     '\n'
                                     '  <h2>4대 핵심 작업 영역</h2>\n'
                                     '  <ul>\n'
                                     '    <li><strong>좌측 패널 (단면 및 해석 '
                                     '제어)</strong>: 단면 생성 마법사, DXF 업로드, 재료 물성치 '
                                     '설정, FSM 파라미터 및 설계 변수 입력.</li>\n'
                                     '    <li><strong>중앙 상단 패널 (2D/3D 단면 '
                                     '뷰어)</strong>: HTML5 Canvas 기반의 단면 기하 작도, '
                                     '두께/중심선 표시, Three.js 기반 3D 단면 및 좌굴 모드 '
                                     '렌더링.</li>\n'
                                     '    <li><strong>중앙 하단 패널 (FSM 시그니처 '
                                     '커브)</strong>: Chart.js 기반 반파장 길이별 임계하중 '
                                     '계수($\\lambda$) 로그 곡선 및 모드 식별점 표시.</li>\n'
                                     '    <li><strong>우측 패널 (성질표 및 D/C 상태 '
                                     '게이지)</strong>: Gross/Torsion 단면 특성치, '
                                     '압축/휨 강도 및 D/C 바 검토 결과 실시간 표시.</li>\n'
                                     '  </ul>\n'
                                     '</div>\n',
                     'content_en_html': '\n'
                                        '<div class="manual-article '
                                        'en-article">\n'
                                        '  <h1>Web UI 4-Quadrant Layout '
                                        'Guide</h1>\n'
                                        '  <p class="lead">CFDesigner '
                                        'organizes structural engineering '
                                        'tasks into a high-productivity '
                                        '<strong>4-Quadrant Layout</strong> '
                                        'responsive workspace.</p>\n'
                                        '  <h2>Quadrant Structure</h2>\n'
                                        '  <ul>\n'
                                        '    <li><strong>Left Control '
                                        'Panel</strong>: Section creation '
                                        'wizard, DXF upload, material inputs, '
                                        'and design settings.</li>\n'
                                        '    <li><strong>Center Top (2D/3D '
                                        'Canvas)</strong>: Cross-section '
                                        'visualization and interactive 3D '
                                        'buckling mode rendering.</li>\n'
                                        '    <li><strong>Center Bottom (FSM '
                                        'Chart)</strong>: Interactive '
                                        'signature curve plotting critical '
                                        'buckling load factors.</li>\n'
                                        '    <li><strong>Right Summary '
                                        'Panel</strong>: Section property '
                                        'table and real-time Demand/Capacity '
                                        '(D/C) ratio indicators.</li>\n'
                                        '  </ul>\n'
                                        '</div>\n'},
    'wizard': {   'id': 'wizard',
                  'category_id': 'getting_started',
                  'category_title': '1. 시작하기 & 웹 UI 가이드',
                  'title': '단면 마법사 파라메트릭 생성',
                  'title_en': 'Parametric Section Wizard',
                  'summary': 'C형, Z형, 모자형, 각형관, L형강, 데크 플레이트 등 6대 표준 단면의 파라메트릭 '
                             '생성 절차를 안내합니다.',
                  'summary_en': 'Guides parametric section creation for '
                                'standard shapes: Cee, Zee, Hat, Tube, Angle, '
                                'and Deck.',
                  'tags': ['마법사', 'Wizard', 'C형강', 'Z형강', '모자형', 'Parametric'],
                  'content_html': '\n'
                                  '<div class="manual-article">\n'
                                  '  <h1>단면 마법사 파라메트릭 생성</h1>\n'
                                  '  <p class="lead">단면 마법사는 냉간성형강 구조물에서 가장 '
                                  '빈번하게 사용되는 <strong>6대 대표 형상</strong>의 치수를 '
                                  '입력하여 중심선 요소를 즉시 자동 생성합니다.</p>\n'
                                  '\n'
                                  '  <div class="en-toggle-wrapper">\n'
                                  '    <button class="btn-toggle-en" '
                                  'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                  '원문 보기 (View Original)</button>\n'
                                  '    <div class="inline-en-box" '
                                  'style="display: none;">\n'
                                  '      <div class="en-box-header"><span '
                                  'class="en-badge">ORIGINAL '
                                  'REFERENCE</span></div>\n'
                                  '      <div class="en-box-content">\n'
                                  '        <p>The Section Wizard provides a '
                                  'fast and convenient way to create standard '
                                  'cold-formed steel shapes (Cee, Zee, Hat, '
                                  'Tube, Angle, and Deck) by entering basic '
                                  'dimensional parameters.</p>\n'
                                  '      </div>\n'
                                  '    </div>\n'
                                  '  </div>\n'
                                  '\n'
                                  '  <h2>지원 단면 템플릿</h2>\n'
                                  '  <table class="manual-table">\n'
                                  '    <thead>\n'
                                  '      <tr><th>단면 유형</th><th>기본 '
                                  '매개변수</th><th>주요 용도</th></tr>\n'
                                  '    </thead>\n'
                                  '    <tbody>\n'
                                  '      <tr><td><strong>C-Section '
                                  '(C형강)</strong></td><td>높이($H$), 플랜지폭($B$), '
                                  '립($D$), 두께($t$), '
                                  '내부반경($r$)</td><td>스터드(Stud), 조이스트(Joist), '
                                  '도리(Purlin)</td></tr>\n'
                                  '      <tr><td><strong>Z-Section '
                                  '(Z형강)</strong></td><td>높이($H$), 상하 '
                                  '플랜지($B_1, B_2$), 립($D$), 플랜지 경사각</td><td>지붕 '
                                  '중도리(Roof Purlin), 벽체 띠장(Girt)</td></tr>\n'
                                  '      <tr><td><strong>Hat Section '
                                  '(모자형)</strong></td><td>높이($H$), 상부폭($B_t$), '
                                  '하부플랜지($B_b$), 립($D$)</td><td>퍼링 채널(Furring '
                                  'Channel), 보강재</td></tr>\n'
                                  '      <tr><td><strong>Deck Section '
                                  '(데크)</strong></td><td>리브 높이, 상하 피치폭, 경사각, '
                                  '모듈 수</td><td>바닥 데크, 지붕 데크 플레이트</td></tr>\n'
                                  '    </tbody>\n'
                                  '  </table>\n'
                                  '</div>\n',
                  'content_en_html': '\n'
                                     '<div class="manual-article en-article">\n'
                                     '  <h1>Parametric Section Wizard</h1>\n'
                                     '  <p class="lead">The Section Wizard '
                                     'provides an instant way to generate '
                                     'standard cold-formed steel cross '
                                     'sections by specifying basic dimensional '
                                     'parameters.</p>\n'
                                     '</div>\n'},
    'dxf_import': {   'id': 'dxf_import',
                      'category_id': 'getting_started',
                      'category_title': '1. 시작하기 & 웹 UI 가이드',
                      'title': 'AutoCAD DXF 가져오기 & 메싱',
                      'title_en': 'AutoCAD DXF Import & Auto-Meshing',
                      'summary': 'AutoCAD 2D DXF 도면 파일의 폴리라인을 파싱하여 비정형 냉간성형강 '
                                 '단면으로 자동 메싱하는 방법을 안내합니다.',
                      'summary_en': 'Explains how to import AutoCAD 2D DXF '
                                    'files and auto-mesh polylines into '
                                    'cold-formed steel cross sections.',
                      'tags': [   'DXF',
                                  'CAD',
                                  'Polyline',
                                  '메싱',
                                  '가져오기',
                                  'Auto-Meshing'],
                      'content_html': '\n'
                                      '<div class="manual-article">\n'
                                      '  <h1>AutoCAD DXF 가져오기 & 메싱</h1>\n'
                                      '  <p class="lead">복잡한 비정형 리브, 엠보싱 또는 특수 '
                                      '절곡 형상을 갖는 냉간성형강 단면은 <strong>AutoCAD DXF '
                                      '파일(2D LWPOLYLINE)</strong>을 통해 손쉽게 불러와 '
                                      '자동 메싱할 수 있습니다.</p>\n'
                                      '\n'
                                      '  <div class="en-toggle-wrapper">\n'
                                      '    <button class="btn-toggle-en" '
                                      'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                      '원문 보기 (View Original)</button>\n'
                                      '    <div class="inline-en-box" '
                                      'style="display: none;">\n'
                                      '      <div class="en-box-header"><span '
                                      'class="en-badge">ORIGINAL '
                                      'REFERENCE</span></div>\n'
                                      '      <div class="en-box-content">\n'
                                      '        <p>The Import DXF command '
                                      'converts 2D CAD polyline drawings into '
                                      'CFS cross section elements, '
                                      'automatically meshing straight and '
                                      'curved segments based on centerline '
                                      'alignment.</p>\n'
                                      '      </div>\n'
                                      '    </div>\n'
                                      '  </div>\n'
                                      '\n'
                                      '  <h2>DXF 작도 및 가져오기 규칙</h2>\n'
                                      '  <ol>\n'
                                      '    <li><strong>중심선(Centerline) '
                                      '작도</strong>: 단면의 판재 중심선을 따라 단일 연속 '
                                      '폴리라인(LWPOLYLINE)으로 작도합니다.</li>\n'
                                      '    <li><strong>코너 '
                                      '아크(Arc/Fillet)</strong>: 코너 라운딩은 호(Arc) '
                                      '또는 폴리라인 벌지(Bulge)로 작도하면 곡선 요소로 자동 '
                                      '분할됩니다.</li>\n'
                                      '    <li><strong>드래그 & 드롭</strong>: 웹 '
                                      '브라우저 중앙 캔버스 영역으로 <code>.dxf</code> 파일을 '
                                      '드래그하여 즉시 로드합니다.</li>\n'
                                      '  </ol>\n'
                                      '</div>\n',
                      'content_en_html': '\n'
                                         '<div class="manual-article '
                                         'en-article">\n'
                                         '  <h1>AutoCAD DXF Import & '
                                         'Auto-Meshing</h1>\n'
                                         '  <p class="lead">Import custom '
                                         'cold-formed steel profiles directly '
                                         'from AutoCAD 2D DXF drawing files '
                                         'with automatic discretization into '
                                         'finite strips.</p>\n'
                                         '</div>\n'},
    'element_grid': {   'id': 'element_grid',
                        'category_id': 'getting_started',
                        'category_title': '1. 시작하기 & 웹 UI 가이드',
                        'title': '단면 요소 테이블 직접 편집',
                        'title_en': 'Element Table Spreadsheet Editor',
                        'summary': '단면을 구성하는 절점 좌표, 요소 길이, 경사각, 두께를 스프레드시트 '
                                   '테이블에서 직접 추가·수정·삭제하는 편집기 기능입니다.',
                        'summary_en': 'Explains spreadsheet-based direct '
                                      'editing of nodal coordinates, element '
                                      'lengths, angles, and thicknesses.',
                        'tags': [   '요소편집',
                                    '스프레드시트',
                                    '테이블',
                                    'Element',
                                    'Grid',
                                    'Spreadsheet',
                                    'Phase 1'],
                        'content_html': '\n'
                                        '<div class="manual-article">\n'
                                        '  <h1>단면 요소 테이블 직접 편집</h1>\n'
                                        '  <p class="lead">CFDesigner는 단면을 '
                                        '구성하는 각 요소(Element)의 기하 데이터를 엑셀 스타일의 '
                                        '<strong>스프레드시트 테이블 모달</strong>에서 직접 '
                                        '정밀 편집할 수 있는 기능을 제공합니다.</p>\n'
                                        '\n'
                                        '  <div class="en-toggle-wrapper">\n'
                                        '    <button class="btn-toggle-en" '
                                        'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                        '원문 보기 (View Original)</button>\n'
                                        '    <div class="inline-en-box" '
                                        'style="display: none;">\n'
                                        '      <div '
                                        'class="en-box-header"><span '
                                        'class="en-badge">ORIGINAL '
                                        'REFERENCE</span></div>\n'
                                        '      <div class="en-box-content">\n'
                                        '        <p>The Element Table input '
                                        'window displays the node connections, '
                                        'segment lengths, angles, thicknesses, '
                                        'and radii for each element in the '
                                        'section. Rows can be inserted, '
                                        'deleted, or edited directly.</p>\n'
                                        '      </div>\n'
                                        '    </div>\n'
                                        '  </div>\n'
                                        '\n'
                                        '  <h2>테이블 열(Column) 구성 및 편집 항목</h2>\n'
                                        '  <table class="manual-table">\n'
                                        '    <thead>\n'
                                        '      <tr><th>열 '
                                        '이름</th><th>설명</th><th>편집 '
                                        '방식</th></tr>\n'
                                        '    </thead>\n'
                                        '    <tbody>\n'
                                        '      <tr><td><strong>ID '
                                        '(#)</strong></td><td>요소 순번 '
                                        '식별자</td><td>자동 부여</td></tr>\n'
                                        '      <tr><td><strong>Node I / '
                                        'J</strong></td><td>시작 절점 및 끝 절점 '
                                        '번호</td><td>좌표 자동 연동</td></tr>\n'
                                        '      <tr><td><strong>길이 '
                                        '($L$)</strong></td><td>선분 요소의 길이 '
                                        '(mm)</td><td>직접 수치 입력 시 끝점 좌표 자동 '
                                        '갱신</td></tr>\n'
                                        '      <tr><td><strong>각도 '
                                        '($\\theta$)</strong></td><td>수평축 대비 '
                                        '요소의 경사각 (deg)</td><td>-180° ~ +180° '
                                        '범위 설정</td></tr>\n'
                                        '      <tr><td><strong>두께 '
                                        '($t$)</strong></td><td>해당 요소의 설계 두께 '
                                        '(mm)</td><td>요소별 차등 두께 설정 '
                                        '가능</td></tr>\n'
                                        '    </tbody>\n'
                                        '  </table>\n'
                                        '\n'
                                        '  <h2>조작 툴바 가이드</h2>\n'
                                        '  <ul>\n'
                                        '    <li><strong>[➕ 행 추가]</strong>: '
                                        '테이블 하단에 새로운 직선 요소를 추가합니다.</li>\n'
                                        '    <li><strong>[🗑️ 선택 삭제]</strong>: '
                                        '체크된 요소를 제거하고 연결 절점을 재정렬합니다.</li>\n'
                                        '    <li><strong>[⚡ 실시간 반영]</strong>: '
                                        '편집 내용을 닫는 즉시 2D 캔버스 및 단면 성질 계산에 즉시 '
                                        '동기화됩니다.</li>\n'
                                        '  </ul>\n'
                                        '</div>\n',
                        'content_en_html': '\n'
                                           '<div class="manual-article '
                                           'en-article">\n'
                                           '  <h1>Element Table Spreadsheet '
                                           'Editor</h1>\n'
                                           '  <p class="lead">Directly inspect '
                                           'and modify nodal connectivity, '
                                           'segment lengths, angles, and '
                                           'individual thickness values using '
                                           'a spreadsheet-style '
                                           'interface.</p>\n'
                                           '  <h2>Spreadsheet Columns</h2>\n'
                                           '  <ul>\n'
                                           '    <li><strong>Element '
                                           'ID</strong>: Sequential index of '
                                           'the cross-section strip '
                                           'element.</li>\n'
                                           '    <li><strong>Nodes I & '
                                           'J</strong>: Start and end node '
                                           'connectivity.</li>\n'
                                           '    <li><strong>Length '
                                           '(L)</strong>: Centerline element '
                                           'length in millimeters.</li>\n'
                                           '    <li><strong>Angle '
                                           '(&theta;)</strong>: Element '
                                           'orientation angle in '
                                           'degrees.</li>\n'
                                           '    <li><strong>Thickness '
                                           '(t)</strong>: Design thickness '
                                           'assigned to the specific '
                                           'strip.</li>\n'
                                           '  </ul>\n'
                                           '</div>\n'},
    'geom_transform': {   'id': 'geom_transform',
                          'category_id': 'getting_started',
                          'category_title': '1. 시작하기 & 웹 UI 가이드',
                          'title': '단면 기하 변환 및 중간 리브',
                          'title_en': 'Geometric Transforms & Intermediate '
                                      'Ribs',
                          'summary': '단면 전체의 회전, 대칭 미러링, 원점 정렬 및 플랜지/웨브 중간 보강 '
                                     '리브(V형·U형) 자동 삽입 기능을 설명합니다.',
                          'summary_en': 'Covers whole-section rotation, '
                                        'mirroring, centroid alignment, and '
                                        'automatic insertion of V/U stiffening '
                                        'ribs.',
                          'tags': [   '기하변환',
                                      '회전',
                                      '미러링',
                                      '보강리브',
                                      '리브',
                                      'Rib',
                                      'Transform',
                                      'Phase 1'],
                          'content_html': '\n'
                                          '<div class="manual-article">\n'
                                          '  <h1>단면 기하 변환 및 중간 리브</h1>\n'
                                          '  <p class="lead">복잡한 절곡 형상을 효율적으로 '
                                          '모델링할 수 있도록 <strong>기하 변환 '
                                          '도구(회전/대칭/원점 이동)</strong> 및 '
                                          '<strong>중간 보강 리브(Intermediate '
                                          'Stiffeners) 자동 삽입 도구</strong>를 '
                                          '제공합니다.</p>\n'
                                          '\n'
                                          '  <div class="en-toggle-wrapper">\n'
                                          '    <button class="btn-toggle-en" '
                                          'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                          '원문 보기 (View Original)</button>\n'
                                          '    <div class="inline-en-box" '
                                          'style="display: none;">\n'
                                          '      <div '
                                          'class="en-box-header"><span '
                                          'class="en-badge">ORIGINAL '
                                          'REFERENCE</span></div>\n'
                                          '      <div class="en-box-content">\n'
                                          '        <p>The Transform and Insert '
                                          'Ribs tools allow users to rotate '
                                          'the section by arbitrary angles, '
                                          'mirror about major/minor axes, '
                                          'center coordinates, and insert '
                                          'intermediate stiffeners along flat '
                                          'elements.</p>\n'
                                          '      </div>\n'
                                          '    </div>\n'
                                          '  </div>\n'
                                          '\n'
                                          '  <h2>1. 기하 변환 도구 '
                                          '(Transforms)</h2>\n'
                                          '  <ul>\n'
                                          '    <li><strong>90° 회전 / 임의 각도 '
                                          '회전</strong>: 단면의 기준 자세를 90° 단위 또는 '
                                          '임의 각도로 신속하게 회전합니다.</li>\n'
                                          '    <li><strong>대칭 미러링 (Mirror X / '
                                          'Y)</strong>: 좌우 또는 상하 대칭 복사를 통해 대칭 '
                                          '단면을 신속하게 생성합니다.</li>\n'
                                          '    <li><strong>원점 도심 정렬 (Center to '
                                          'CG)</strong>: 단면의 도심($C_G$)을 글로벌 '
                                          '좌표계 원점 $(0,0)$으로 일괄 이동합니다.</li>\n'
                                          '  </ul>\n'
                                          '\n'
                                          '  <h2>2. 중간 보강 리브 삽입 (Insert '
                                          'Ribs)</h2>\n'
                                          '  <p>평판 요소(Web 또는 Flange)의 국부 좌굴 '
                                          '강도를 향상시키기 위해 지정된 위치에 보강 리브를 '
                                          '삽입합니다.</p>\n'
                                          '  <ul>\n'
                                          '    <li><strong>V-형 리브 '
                                          '(V-Stiffener)</strong>: 지정된 '
                                          '깊이($d_r$)와 경사각으로 삼각 형상 리브 생성.</li>\n'
                                          '    <li><strong>U-형 리브 '
                                          '(U-Stiffener)</strong>: 평탄 바닥과 양측 '
                                          '경사 벽을 갖는 사다리꼴 형상 리브 생성.</li>\n'
                                          '  </ul>\n'
                                          '</div>\n',
                          'content_en_html': '\n'
                                             '<div class="manual-article '
                                             'en-article">\n'
                                             '  <h1>Geometric Transforms & '
                                             'Intermediate Ribs</h1>\n'
                                             '  <p class="lead">Provides '
                                             'powerful tools to rotate, '
                                             'mirror, and center sections, as '
                                             'well as automatically generate '
                                             'intermediate stiffening ribs '
                                             'along flat elements.</p>\n'
                                             '</div>\n'},
    'section_lib': {   'id': 'section_lib',
                       'category_id': 'section_library',
                       'category_title': '2. 단면 라이브러리 & 재료 물성치',
                       'title': '표준 단면 라이브러리 브라우저',
                       'title_en': 'Section Library Browser (AISI/SSMA)',
                       'summary': '1,000개 이상의 북미 및 국내 표준 냉간성형강(SSMA, SFIA, '
                                  'LGSI) 라이브러리 검색 및 원클릭 로드 가이드입니다.',
                       'summary_en': 'Search, filter, and load over 1,000 '
                                     'standard cold-formed steel sections from '
                                     'SSMA, SFIA, and LGSI databases.',
                       'tags': [   '라이브러리',
                                   '단면DB',
                                   'SSMA',
                                   'SFIA',
                                   '표준단면',
                                   'Library',
                                   'Phase 2'],
                       'content_html': '\n'
                                       '<div class="manual-article">\n'
                                       '  <h1>표준 단면 라이브러리 브라우저</h1>\n'
                                       '  <p class="lead">상단 툴바의 <strong>[📚 단면 '
                                       '라이브러리]</strong> 버튼을 통해 북미 SSMA, SFIA, '
                                       'LGSI 등 공인 규격의 <strong>1,000여 종 표준 '
                                       '냉간성형강 단면 DB</strong>를 실시간으로 검색하고 즉시 작업 '
                                       '영역으로 로드할 수 있습니다.</p>\n'
                                       '\n'
                                       '  <div class="en-toggle-wrapper">\n'
                                       '    <button class="btn-toggle-en" '
                                       'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                       '원문 보기 (View Original)</button>\n'
                                       '    <div class="inline-en-box" '
                                       'style="display: none;">\n'
                                       '      <div class="en-box-header"><span '
                                       'class="en-badge">ORIGINAL '
                                       'REFERENCE</span></div>\n'
                                       '      <div class="en-box-content">\n'
                                       '        <p>The Open Library Section '
                                       'dialog allows browsing comprehensive '
                                       'product databases (SSMA, SFIA, LGSI). '
                                       'Selecting any entry loads its exact '
                                       'centerline geometry and nominal '
                                       'thickness into the workspace.</p>\n'
                                       '      </div>\n'
                                       '    </div>\n'
                                       '  </div>\n'
                                       '\n'
                                       '  <h2>단면 명명법 규칙 (AISI S201 '
                                       'Designation)</h2>\n'
                                       '  <div class="callout callout-info">\n'
                                       '    <h4>예시: '
                                       '<code>600S162-54</code></h4>\n'
                                       '    <ul>\n'
                                       '      <li><strong>600</strong>: 웨브 '
                                       '깊이(Web Depth) = $6.00\\text{ in} = '
                                       '152.4\\text{ mm}$ ($1/100\\text{ in}$ '
                                       '단위)</li>\n'
                                       '      <li><strong>S</strong>: 단면 유형 '
                                       '(S: Stud/C-Section, T: Track, U: '
                                       'Channel, F: Furring Hat)</li>\n'
                                       '      <li><strong>162</strong>: 플랜지 '
                                       '폭(Flange Width) = $1.625\\text{ in} = '
                                       '41.3\\text{ mm}$</li>\n'
                                       '      <li><strong>54</strong>: 공칭 '
                                       '두께(Mils) = $54\\text{ mils} = '
                                       '0.054\\text{ in} = 1.37\\text{ '
                                       'mm}$</li>\n'
                                       '    </ul>\n'
                                       '  </div>\n'
                                       '</div>\n',
                       'content_en_html': '\n'
                                          '<div class="manual-article '
                                          'en-article">\n'
                                          '  <h1>Section Library Browser '
                                          '(AISI/SSMA)</h1>\n'
                                          '  <p class="lead">Access over 1,000 '
                                          'pre-defined cold-formed steel '
                                          'framing sections conforming to '
                                          'standard AISI/SSMA/SFIA '
                                          'nomenclature.</p>\n'
                                          '</div>\n'},
    'material_db': {   'id': 'material_db',
                       'category_id': 'section_library',
                       'category_title': '2. 단면 라이브러리 & 재료 물성치',
                       'title': '강재 재료 DB 및 물성치 설정',
                       'title_en': 'Material Properties & Custom Steel',
                       'summary': 'KS 규격(SSC275, SSC355, SSC400 등) 및 '
                                  'ASTM(A1008, A653) 강종 프리셋 선택과 물성치(Fy, Fu, E) '
                                  '커스터마이징을 안내합니다.',
                       'summary_en': 'Guides selection of KS and ASTM steel '
                                     'grades and customization of Fy, Fu, and '
                                     "Young's modulus E.",
                       'tags': [   '재료',
                                   '물성치',
                                   'KS',
                                   'ASTM',
                                   '항복강도',
                                   '탄성계수',
                                   'Material',
                                   'Phase 2'],
                       'content_html': '\n'
                                       '<div class="manual-article">\n'
                                       '  <h1>강재 재료 DB 및 물성치 설정</h1>\n'
                                       '  <p class="lead">부재의 내력 계산 및 FSM '
                                       '좌굴해석에 사용되는 강재의 기계적 물성치(항복강도 $F_y$, '
                                       '인장강도 $F_u$, 탄성계수 $E$, 포아송비 $\\nu$)를 표준 '
                                       'DB에서 선택하거나 직접 입력합니다.</p>\n'
                                       '\n'
                                       '  <div class="en-toggle-wrapper">\n'
                                       '    <button class="btn-toggle-en" '
                                       'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                       '원문 보기 (View Original)</button>\n'
                                       '    <div class="inline-en-box" '
                                       'style="display: none;">\n'
                                       '      <div class="en-box-header"><span '
                                       'class="en-badge">ORIGINAL '
                                       'REFERENCE</span></div>\n'
                                       '      <div class="en-box-content">\n'
                                       '        <p>The Material Options dialog '
                                       'defines the yield strength (Fy), '
                                       'ultimate tensile strength (Fu), '
                                       'modulus of elasticity (E), and '
                                       "Poisson's ratio (&nu;) used for design "
                                       'calculations.</p>\n'
                                       '      </div>\n'
                                       '    </div>\n'
                                       '  </div>\n'
                                       '\n'
                                       '  <h2>주요 강종 표준 물성치 표</h2>\n'
                                       '  <table class="manual-table">\n'
                                       '    <thead>\n'
                                       '      <tr><th>규격 및 강종</th><th>항복강도 '
                                       '$F_y$ (MPa)</th><th>인장강도 $F_u$ '
                                       '(MPa)</th><th>탄성계수 $E$ '
                                       '(GPa)</th></tr>\n'
                                       '    </thead>\n'
                                       '    <tbody>\n'
                                       '      <tr><td><strong>KS SSC275 (구 '
                                       'SGC400)</strong></td><td>275</td><td>400</td><td>205</td></tr>\n'
                                       '      <tr><td><strong>KS SSC355 (구 '
                                       'SGC490)</strong></td><td>355</td><td>490</td><td>205</td></tr>\n'
                                       '      <tr><td><strong>ASTM A653 '
                                       'Gr.33</strong></td><td>228</td><td>310</td><td>203</td></tr>\n'
                                       '      <tr><td><strong>ASTM A653 '
                                       'Gr.50</strong></td><td>345</td><td>450</td><td>203</td></tr>\n'
                                       '    </tbody>\n'
                                       '  </table>\n'
                                       '</div>\n',
                       'content_en_html': '\n'
                                          '<div class="manual-article '
                                          'en-article">\n'
                                          '  <h1>Material Properties & Custom '
                                          'Steel</h1>\n'
                                          '  <p class="lead">Configure design '
                                          'mechanical properties including '
                                          'yield stress ($F_y$), tensile '
                                          'strength ($F_u$), and elastic '
                                          'modulus ($E$).</p>\n'
                                          '</div>\n'},
    'cold_work': {   'id': 'cold_work',
                     'category_id': 'section_library',
                     'category_title': '2. 단면 라이브러리 & 재료 물성치',
                     'title': '코너 성형 가공경화 강도 증가',
                     'title_en': 'Cold-Work Forming Strength Calculation',
                     'summary': 'AISI S100 Appendix 1 및 KDS 14 31 10 기준에 따른 코너 '
                                '절곡부 가공경화 유효항복강도(Fya) 산정 이론입니다.',
                     'summary_en': 'Details the increase in yield strength '
                                   'from cold-work of forming (Fya) according '
                                   'to AISI S100 Appendix 1 and KDS 14 31 10.',
                     'tags': [   '가공경화',
                                 'Fya',
                                 'Cold Work',
                                 '코너강도',
                                 'KDS 14 31 10',
                                 'AISI S100',
                                 'Phase 2'],
                     'content_html': '\n'
                                     '<div class="manual-article">\n'
                                     '  <h1>코너 성형 가공경화 강도 증가</h1>\n'
                                     '  <p class="lead">냉간 롤포밍 또는 프레스 브레이킹 가공 '
                                     '시 절곡 코너부에 발생하는 <strong>가공경화(Cold-Work of '
                                     'Forming)</strong> 현상으로 인해 항복강도가 상승하며, '
                                     '규준에 따라 단면 전체의 유효항복강도($F_{ya}$)를 증대 적용할 수 '
                                     '있습니다.</p>\n'
                                     '\n'
                                     '  <div class="en-toggle-wrapper">\n'
                                     '    <button class="btn-toggle-en" '
                                     'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                     '원문 보기 (View Original)</button>\n'
                                     '    <div class="inline-en-box" '
                                     'style="display: none;">\n'
                                     '      <div class="en-box-header"><span '
                                     'class="en-badge">ORIGINAL '
                                     'REFERENCE</span></div>\n'
                                     '      <div class="en-box-content">\n'
                                     '        <p>AISI S100 Appendix 1 permits '
                                     'the utilization of increased yield '
                                     'strength obtained through cold work of '
                                     'forming. The corner yield strength Fyc '
                                     'and average yield strength Fya are '
                                     'computed based on the ratio of corner '
                                     'area to full cross-sectional area.</p>\n'
                                     '      </div>\n'
                                     '    </div>\n'
                                     '  </div>\n'
                                     '\n'
                                     '  <h2>1. 코너부 항복강도 산정식 ($F_{yc}$)</h2>\n'
                                     '  $$F_{yc} = \\frac{B_c \\cdot '
                                     'F_y}{(r/t)^m} \\le F_u$$\n'
                                     '  <p>여기서 계수 $B_c$ 및 $m$은 다음과 같습니다:</p>\n'
                                     '  $$B_c = 3.69 \\cdot '
                                     '\\left(\\frac{F_u}{F_y}\\right) - 0.819 '
                                     '\\cdot \\left(\\frac{F_u}{F_y}\\right)^2 '
                                     '- 1.79$$\n'
                                     '  $$m = 0.192 \\cdot '
                                     '\\left(\\frac{F_u}{F_y}\\right) - '
                                     '0.068$$\n'
                                     '\n'
                                     '  <h2>2. 단면 평균 유효항복강도 ($F_{ya}$)</h2>\n'
                                     '  $$F_{ya} = C \\cdot F_{yc} + (1 - C) '
                                     '\\cdot F_{yf} \\le F_u$$\n'
                                     '  <p>($C$: 총 단면적 중 코너 면적이 차지하는 비율 '
                                     '$A_{corner} / A_g$, $F_{yf}$: 평판부 모재 '
                                     '항복강도 $F_y$)</p>\n'
                                     '</div>\n',
                     'content_en_html': '\n'
                                        '<div class="manual-article '
                                        'en-article">\n'
                                        '  <h1>Cold-Work Forming Strength '
                                        'Calculation</h1>\n'
                                        '  <p class="lead">Cold-forming '
                                        'operations cause localized strain '
                                        'hardening in the corners, '
                                        'significantly elevating yield '
                                        'strength from $F_y$ to $F_{yc}$, '
                                        'which can be accounted for via '
                                        'average section strength '
                                        '$F_{ya}$.</p>\n'
                                        '</div>\n'},
    'gross_props': {   'id': 'gross_props',
                       'category_id': 'section_properties',
                       'category_title': '3. 단면 기하학적 성질 & 유효단면',
                       'title': '총단면 기하학적 성질 (Gross)',
                       'title_en': 'Gross Section Properties',
                       'summary': '총단면적(Ag), 도심(CG), 단면 2차모멘트(Ix, Iy), '
                                  '단면상승모멘트(Ixy), 회전반경(rx, ry)의 엄밀 선적분 수식입니다.',
                       'summary_en': 'Rigorous line-integral formulas for '
                                     'Gross Area (Ag), Centroid (CG), Moments '
                                     'of Inertia (Ix, Iy), and Radii of '
                                     'Gyration (rx, ry).',
                       'tags': [   '단면성질',
                                   'Ag',
                                   'Ix',
                                   'Iy',
                                   '도심',
                                   'Gross Properties'],
                       'content_html': '\n'
                                       '<div class="manual-article">\n'
                                       '  <h1>총단면 기하학적 성질 (Gross)</h1>\n'
                                       '  <p class="lead">판 두께가 얇은 냉간성형강의 특성을 '
                                       '반영하여 박판 선적분(Line Integral '
                                       'Formulation)에 기반한 <strong>총단면 기하학적 '
                                       '성질</strong>을 정밀하게 산정합니다.</p>\n'
                                       '\n'
                                       '  <div class="en-toggle-wrapper">\n'
                                       '    <button class="btn-toggle-en" '
                                       'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                       '원문 보기 (View Original)</button>\n'
                                       '    <div class="inline-en-box" '
                                       'style="display: none;">\n'
                                       '      <div class="en-box-header"><span '
                                       'class="en-badge">ORIGINAL '
                                       'REFERENCE</span></div>\n'
                                       '      <div class="en-box-content">\n'
                                       '        <p>Gross section properties '
                                       '(Area, Centroid, Ix, Iy, Ixy, rx, ry) '
                                       'are calculated by integrating '
                                       'thin-walled line elements along the '
                                       'profile centerline and multiplying by '
                                       'nominal thicknesses.</p>\n'
                                       '      </div>\n'
                                       '    </div>\n'
                                       '  </div>\n'
                                       '\n'
                                       '  <h2>주요 계산 수식</h2>\n'
                                       '  <ul>\n'
                                       '    <li><strong>총단면적</strong>: $A_g = '
                                       '\\sum_{i=1}^n L_i \\cdot t_i$</li>\n'
                                       '    <li><strong>도심 좌표</strong>: '
                                       '$\\bar{x} = \\frac{1}{A_g} \\sum L_i '
                                       't_i x_{c,i}, \\quad \\bar{y} = '
                                       '\\frac{1}{A_g} \\sum L_i t_i '
                                       'y_{c,i}$</li>\n'
                                       '    <li><strong>단면 2차모멘트</strong>: '
                                       '$I_x = \\sum \\left( \\frac{t_i L_i^3 '
                                       '\\sin^2 \\theta_i}{12} + L_i t_i '
                                       'y_{c,i}^2 \\right), \\quad I_y = \\sum '
                                       '\\left( \\frac{t_i L_i^3 \\cos^2 '
                                       '\\theta_i}{12} + L_i t_i x_{c,i}^2 '
                                       '\\right)$</li>\n'
                                       '  </ul>\n'
                                       '</div>\n',
                       'content_en_html': '\n'
                                          '<div class="manual-article '
                                          'en-article">\n'
                                          '  <h1>Gross Section '
                                          'Properties</h1>\n'
                                          '  <p class="lead">Computes the '
                                          'geometric properties of thin-walled '
                                          'cold-formed steel sections using '
                                          'closed-form line integrals along '
                                          'the element centerline.</p>\n'
                                          '</div>\n'},
    'torsion_props': {   'id': 'torsion_props',
                         'category_id': 'section_properties',
                         'category_title': '3. 단면 기하학적 성질 & 유효단면',
                         'title': '비틀림 및 뒴 성질 (Torsion)',
                         'title_en': 'Torsional & Warping Properties',
                         'summary': '생브낭 비틀림 상수(J), 섹터모멘트 기반 뒴상수(Cw), '
                                    '전단중심(SC), 극회전반경(ro)의 해석 이론입니다.',
                         'summary_en': 'Theory for Saint-Venant Torsion (J), '
                                       'Sectorial Warping Constant (Cw), Shear '
                                       'Center (SC), and Polar Radius of '
                                       'Gyration (ro).',
                         'tags': [   '비틀림',
                                     '뒴상수',
                                     'Cw',
                                     '전단중심',
                                     'J',
                                     'Torsion',
                                     'Warping'],
                         'content_html': '\n'
                                         '<div class="manual-article">\n'
                                         '  <h1>비틀림 및 뒴 성질 (Torsion)</h1>\n'
                                         '  <p class="lead">개단면(Open Section) '
                                         '냉간성형강의 횡-비틀림 좌굴(LTB) 및 비틀림-휨 좌굴 거동을 '
                                         '지배하는 <strong>생브낭 비틀림 '
                                         '상수($J$)</strong>와 '
                                         '<strong>뒴상수($C_w$)</strong>, '
                                         '<strong>전단중심($S_C$)</strong>을 '
                                         '산정합니다.</p>\n'
                                         '\n'
                                         '  <div class="en-toggle-wrapper">\n'
                                         '    <button class="btn-toggle-en" '
                                         'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                         '원문 보기 (View Original)</button>\n'
                                         '    <div class="inline-en-box" '
                                         'style="display: none;">\n'
                                         '      <div '
                                         'class="en-box-header"><span '
                                         'class="en-badge">ORIGINAL '
                                         'REFERENCE</span></div>\n'
                                         '      <div class="en-box-content">\n'
                                         '        <p>Torsional and warping '
                                         'properties are computed based on '
                                         'Vlasov thin-walled beam theory, '
                                         'evaluating the principal sectorial '
                                         'coordinate (&omega;) distribution to '
                                         'find the shear center (xo, yo) and '
                                         'warping constant (Cw).</p>\n'
                                         '      </div>\n'
                                         '    </div>\n'
                                         '  </div>\n'
                                         '\n'
                                         '  <h2>1. 생브낭 비틀림 상수 ($J$)</h2>\n'
                                         '  $$J = \\sum_{i=1}^n \\frac{1}{3} '
                                         'L_i \\cdot t_i^3$$\n'
                                         '\n'
                                         '  <h2>2. 뒴상수 ($C_w$) 및 전단중심 ($x_o, '
                                         'y_o$)</h2>\n'
                                         '  $$C_w = \\int_A \\omega_n^2 \\, dA '
                                         '= \\sum_{i=1}^n \\frac{t_i L_i}{3} '
                                         '(\\omega_{1}^2 + \\omega_1 \\omega_2 '
                                         '+ \\omega_2^2)$$\n'
                                         '</div>\n',
                         'content_en_html': '\n'
                                            '<div class="manual-article '
                                            'en-article">\n'
                                            '  <h1>Torsional & Warping '
                                            'Properties</h1>\n'
                                            '  <p class="lead">Evaluates '
                                            'Saint-Venant torsional constant '
                                            '($J$), warping constant ($C_w$), '
                                            'and shear center coordinates '
                                            '($x_o, y_o$) using sectorial area '
                                            'integration according to Vlasov '
                                            'beam theory.</p>\n'
                                            '</div>\n'},
    'principal_axes': {   'id': 'principal_axes',
                          'category_id': 'section_properties',
                          'category_title': '3. 단면 기하학적 성질 & 유효단면',
                          'title': '주축 및 주단면 2차모멘트',
                          'title_en': 'Principal Axes & Principal Moments',
                          'summary': '주축 회전각(θp) 및 주단면 2차모멘트(I1, I2), 최소 '
                                     '회전반경(r_min)의 좌표변환 이론입니다.',
                          'summary_en': 'Coordinate transformation theory for '
                                        'principal axis angle (&theta;p) and '
                                        'principal moments of inertia (I1, '
                                        'I2).',
                          'tags': ['주축', 'I1', 'I2', '회전각', 'Principal Axes'],
                          'content_html': '\n'
                                          '<div class="manual-article">\n'
                                          '  <h1>주축 및 주단면 2차모멘트</h1>\n'
                                          '  <p class="lead">비대칭 단면(예: Z형강, '
                                          '부등변 앵글)의 경우 기하축과 주축이 일치하지 않으므로, '
                                          '<strong>주축 '
                                          '회전각($\\theta_p$)</strong> 및 '
                                          '<strong>주단면 2차모멘트($I_1, '
                                          'I_2$)</strong>를 산정하여 부재 좌굴축을 '
                                          '결정합니다.</p>\n'
                                          '\n'
                                          '  <div class="en-toggle-wrapper">\n'
                                          '    <button class="btn-toggle-en" '
                                          'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                          '원문 보기 (View Original)</button>\n'
                                          '    <div class="inline-en-box" '
                                          'style="display: none;">\n'
                                          '      <div '
                                          'class="en-box-header"><span '
                                          'class="en-badge">ORIGINAL '
                                          'REFERENCE</span></div>\n'
                                          '      <div class="en-box-content">\n'
                                          '        <p>Principal axes represent '
                                          'the orthogonal orientation where '
                                          'the product moment of inertia Ixy '
                                          'becomes zero. The orientation angle '
                                          '&theta;p and extreme moments I1, I2 '
                                          'govern the directional buckling '
                                          'capacity.</p>\n'
                                          '      </div>\n'
                                          '    </div>\n'
                                          '  </div>\n'
                                          '\n'
                                          '  <h2>주축 회전각 및 주모멘트 수식</h2>\n'
                                          '  $$\\tan(2\\theta_p) = \\frac{-2 '
                                          'I_{xy}}{I_x - I_y}$$\n'
                                          '  $$I_{1,2} = \\frac{I_x + I_y}{2} '
                                          '\\pm \\sqrt{\\left(\\frac{I_x - '
                                          'I_y}{2}\\right)^2 + I_{xy}^2}$$\n'
                                          '</div>\n',
                          'content_en_html': '\n'
                                             '<div class="manual-article '
                                             'en-article">\n'
                                             '  <h1>Principal Axes & Principal '
                                             'Moments</h1>\n'
                                             '  <p class="lead">Computes the '
                                             'principal axis orientation angle '
                                             '($\theta_p$) and maximum/minimum '
                                             'principal moments of inertia '
                                             '($I_1, I_2$) for unsymmetric '
                                             'sections.</p>\n'
                                             '</div>\n'},
    'effective_props': {   'id': 'effective_props',
                           'category_id': 'section_properties',
                           'category_title': '3. 단면 기하학적 성질 & 유효단면',
                           'title': 'Winter 식 기반 유효단면 해석',
                           'title_en': 'Effective Section Properties (Winter '
                                       'Method)',
                           'summary': 'Winter 유효폭 감축 공식 및 압축/휨 응력 구배 하에서의 '
                                      '유효단면(Aeff, Ieff) 반복 해석과 2D 시각화 기법입니다.',
                           'summary_en': "Covers Winter's effective width "
                                         'method for local buckling reduction '
                                         'and iterative calculation of Aeff '
                                         'and Ieff.',
                           'tags': [   '유효단면',
                                       'Winter',
                                       '유효폭',
                                       'Aeff',
                                       'Ieff',
                                       'Effective Width',
                                       'Phase 3'],
                           'content_html': '\n'
                                           '<div class="manual-article">\n'
                                           '  <h1>Winter 식 기반 유효단면 해석</h1>\n'
                                           '  <p class="lead">판폭두께비($w/t$)가 큰 '
                                           '냉간성형강 압축 요소의 국부 좌굴 후 '
                                           '강도(Post-buckling Strength)를 고려하기 '
                                           '위해 <strong>Winter의 유효폭(Effective '
                                           'Width) 산정법</strong>을 적용하여 '
                                           '유효단면적($A_{eff}$)과 유효단면 '
                                           '2차모멘트($I_{eff}$)를 계산합니다.</p>\n'
                                           '\n'
                                           '  <div class="en-toggle-wrapper">\n'
                                           '    <button class="btn-toggle-en" '
                                           'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                           '원문 보기 (View Original)</button>\n'
                                           '    <div class="inline-en-box" '
                                           'style="display: none;">\n'
                                           '      <div '
                                           'class="en-box-header"><span '
                                           'class="en-badge">ORIGINAL '
                                           'REFERENCE</span></div>\n'
                                           '      <div '
                                           'class="en-box-content">\n'
                                           '        <p>Effective section '
                                           'properties account for local plate '
                                           "buckling using Winter's effective "
                                           'width equations. Under compressive '
                                           'stresses, inactive center portions '
                                           'of plates are reduced, resulting '
                                           'in effective properties Aeff and '
                                           'Ieff.</p>\n'
                                           '      </div>\n'
                                           '    </div>\n'
                                           '  </div>\n'
                                           '\n'
                                           '  <h2>1. Winter 유효폭 감소 계수 '
                                           '($\\rho$)</h2>\n'
                                           '  <p>판의 무차원 세장비 $\\lambda$에 따라 유효폭 '
                                           '$b = \\rho \\cdot w$를 산정합니다:</p>\n'
                                           '  $$\\lambda = '
                                           '\\sqrt{\\frac{f}{F_{cr}}} = '
                                           '\\frac{1.052}{\\sqrt{k}} \\cdot '
                                           '\\left(\\frac{w}{t}\\right) \\cdot '
                                           '\\sqrt{\\frac{f}{E}}$$\n'
                                           '  $$\\rho = \\begin{cases} 1.0 & '
                                           '(\\lambda \\le 0.673) \\\\ '
                                           '\\frac{(1 - '
                                           '0.22/\\lambda)}{\\lambda} & '
                                           '(\\lambda > 0.673) \\end{cases}$$\n'
                                           '\n'
                                           '  <h2>2. 2D 캔버스 유효단면 시각화</h2>\n'
                                           '  <p>CFDesigner 2D 캔버스에서 '
                                           '<strong>[유효단면 뷰]</strong> 활성화 시, '
                                           '국부 좌굴로 인해 무효화된 판재 중앙부가 점선으로 투명 '
                                           '처리되어 유효 지지 영역을 한눈에 파악할 수 '
                                           '있습니다.</p>\n'
                                           '</div>\n',
                           'content_en_html': '\n'
                                              '<div class="manual-article '
                                              'en-article">\n'
                                              '  <h1>Effective Section '
                                              'Properties (Winter '
                                              'Method)</h1>\n'
                                              '  <p class="lead">Computes '
                                              'reduced effective '
                                              'cross-sectional properties '
                                              '($A_{eff}, I_{eff}$) under '
                                              'axial compression and bending '
                                              "stresses using Winter's "
                                              'empirical reduction factor $\r'
                                              'ho$.</p>\n'
                                              '</div>\n'},
    'fsm_theory': {   'id': 'fsm_theory',
                      'category_id': 'fsm_buckling',
                      'category_title': '4. FSM 탄성 좌굴해석 이론',
                      'title': 'FSM 탄성 좌굴 해석 이론',
                      'title_en': 'FSM Elastic Buckling Theory',
                      'summary': '유한대판법(Finite Strip Method)의 강성행렬([Ke], [Kg]) '
                                 '유도와 일반화 고유치 수치해석 이론을 설명합니다.',
                      'summary_en': 'Formulation of elastic [Ke] and geometric '
                                    '[Kg] stiffness matrices and generalized '
                                    'eigenvalue problem in FSM.',
                      'tags': [   'FSM',
                                  '유한대판법',
                                  '강성행렬',
                                  '고유치',
                                  'Buckling Theory'],
                      'content_html': '\n'
                                      '<div class="manual-article">\n'
                                      '  <h1>FSM 탄성 좌굴 해석 이론</h1>\n'
                                      '  <p class="lead"><strong>유한대판법(Finite '
                                      'Strip Method, FSM)</strong>은 단면 횡방향은 '
                                      '1차원 유한요소 변위함수로 이산화하고, 부재 길이방향($z$)은 사인 '
                                      '조화급수(Fourier Sine Series)로 엄밀 모델링하는 '
                                      '반해석적(Semi-analytical) 수치해석 기법입니다.</p>\n'
                                      '\n'
                                      '  <div class="en-toggle-wrapper">\n'
                                      '    <button class="btn-toggle-en" '
                                      'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                      '원문 보기 (View Original)</button>\n'
                                      '    <div class="inline-en-box" '
                                      'style="display: none;">\n'
                                      '      <div class="en-box-header"><span '
                                      'class="en-badge">ORIGINAL '
                                      'REFERENCE</span></div>\n'
                                      '      <div class="en-box-content">\n'
                                      '        <p>The Finite Strip Method '
                                      'combines polynomial cross-sectional '
                                      'interpolation with longitudinal '
                                      'trigonometric functions. Buckling load '
                                      'factors are obtained by solving the '
                                      'generalized eigenvalue problem '
                                      '[Ke]{&delta;} = '
                                      '&lambda;[Kg]{&delta;}.</p>\n'
                                      '      </div>\n'
                                      '    </div>\n'
                                      '  </div>\n'
                                      '\n'
                                      '  <h2>일반화 고유치 문제 (Generalized '
                                      'Eigenvalue Problem)</h2>\n'
                                      '  $$[K_e] \\{\\delta\\} = \\lambda '
                                      '[K_g] \\{\\delta\\}$$\n'
                                      '  <ul>\n'
                                      '    <li>$[K_e]$: 탄성 강성행렬 (Elastic '
                                      'Stiffness Matrix) - 면내 평면응력 및 면외 휨 변형 '
                                      '결합</li>\n'
                                      '    <li>$[K_g]$: 기하 강성행렬 (Geometric '
                                      'Stiffness Matrix) - 작용 응력 상태 반영</li>\n'
                                      '    <li>$\\lambda$: 임계 좌굴하중 계수 '
                                      '(Buckling Load Factor) - 최소 고유치 '
                                      '$\\lambda_{cr} = P_{cr} / '
                                      'P_{ref}$</li>\n'
                                      '  </ul>\n'
                                      '</div>\n',
                      'content_en_html': '\n'
                                         '<div class="manual-article '
                                         'en-article">\n'
                                         '  <h1>FSM Elastic Buckling '
                                         'Theory</h1>\n'
                                         '  <p class="lead">Explains the '
                                         'semi-analytical Finite Strip Method '
                                         '(FSM) formulation combining '
                                         'polynomial transverse interpolation '
                                         'with longitudinal harmonic '
                                         'functions.</p>\n'
                                         '</div>\n'},
    'buckling_modes': {   'id': 'buckling_modes',
                          'category_id': 'fsm_buckling',
                          'category_title': '4. FSM 탄성 좌굴해석 이론',
                          'title': '좌굴 모드 판별 (국부/왜곡/전체)',
                          'title_en': 'Buckling Mode Classification',
                          'summary': '국부좌굴(Local, Pcrl), 왜곡좌굴(Distortional, '
                                     'Pcrd), 전체좌굴(Global, Pcre)의 특성 및 판별 기준을 '
                                     '안내합니다.',
                          'summary_en': 'Criteria for classifying Local '
                                        '(Pcrl), Distortional (Pcrd), and '
                                        'Global (Pcre) buckling modes from '
                                        'signature curves.',
                          'tags': [   '국부좌굴',
                                      '왜곡좌굴',
                                      '전체좌굴',
                                      'Pcrl',
                                      'Pcrd',
                                      'Pcre',
                                      'Buckling Modes'],
                          'content_html': '\n'
                                          '<div class="manual-article">\n'
                                          '  <h1>좌굴 모드 판별 (국부/왜곡/전체)</h1>\n'
                                          '  <p class="lead">직접강도법(DSM) 설계의 '
                                          '핵심은 단면의 <strong>3대 좌굴 모드(국부, 왜곡, '
                                          '전체)</strong>를 정확히 식별하고 각각의 임계 좌굴 '
                                          '하중($P_{crl}, P_{crd}, P_{cre}$)을 '
                                          '추출하는 것입니다.</p>\n'
                                          '\n'
                                          '  <div class="en-toggle-wrapper">\n'
                                          '    <button class="btn-toggle-en" '
                                          'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                          '원문 보기 (View Original)</button>\n'
                                          '    <div class="inline-en-box" '
                                          'style="display: none;">\n'
                                          '      <div '
                                          'class="en-box-header"><span '
                                          'class="en-badge">ORIGINAL '
                                          'REFERENCE</span></div>\n'
                                          '      <div class="en-box-content">\n'
                                          '        <p>Three distinct buckling '
                                          'modes must be identified for DSM '
                                          'design: Local Buckling (short '
                                          'half-wavelength, plate ripples), '
                                          'Distortional Buckling (intermediate '
                                          'half-wavelength, flange/lip '
                                          'rotation), and Global Buckling '
                                          '(long half-wavelength, '
                                          'flexural/torsional).</p>\n'
                                          '      </div>\n'
                                          '    </div>\n'
                                          '  </div>\n'
                                          '\n'
                                          '  <h2>3대 좌굴 모드 비교표</h2>\n'
                                          '  <table class="manual-table">\n'
                                          '    <thead>\n'
                                          '      <tr><th>좌굴 모드</th><th>대표 반파장 '
                                          '($L$)</th><th>변형 '
                                          '특징</th><th>기호</th></tr>\n'
                                          '    </thead>\n'
                                          '    <tbody>\n'
                                          '      <tr><td><strong>국부 좌굴 '
                                          '(Local)</strong></td><td>$20 \\sim '
                                          '150\\text{ mm}$ (판폭 수준)</td><td>절점 '
                                          '선의 이동 없이 판 요소만 물결 모양 '
                                          '굴곡</td><td>$P_{crl}, '
                                          'M_{crl}$</td></tr>\n'
                                          '      <tr><td><strong>왜곡 좌굴 '
                                          '(Distortional)</strong></td><td>$100 '
                                          '\\sim 600\\text{ mm}$ (중간 '
                                          '길이)</td><td>플랜지와 보강 립이 절곡 코너를 중심으로 '
                                          '회전/왜곡</td><td>$P_{crd}, '
                                          'M_{crd}$</td></tr>\n'
                                          '      <tr><td><strong>전체 좌굴 '
                                          '(Global)</strong></td><td>$1000\\text{ '
                                          'mm}$ 이상 (부재 경간)</td><td>단면 형상 유지 채 '
                                          '휨 또는 비틀림 횡좌굴 발생</td><td>$P_{cre}, '
                                          'M_{cre}$</td></tr>\n'
                                          '    </tbody>\n'
                                          '  </table>\n'
                                          '</div>\n',
                          'content_en_html': '\n'
                                             '<div class="manual-article '
                                             'en-article">\n'
                                             '  <h1>Buckling Mode '
                                             'Classification</h1>\n'
                                             '  <p class="lead">Distinguishes '
                                             'Local, Distortional, and Global '
                                             'elastic buckling modes based on '
                                             'half-wavelength and deformation '
                                             'features.</p>\n'
                                             '</div>\n'},
    'signature_curve': {   'id': 'signature_curve',
                           'category_id': 'fsm_buckling',
                           'category_title': '4. FSM 탄성 좌굴해석 이론',
                           'title': '시그니처 커브 및 3D 시각화',
                           'title_en': 'Signature Curve & 3D Visualization',
                           'summary': '반파장 길이(L)에 따른 좌굴 계수(λ) 스펙트럼 곡선 해석법과 '
                                      'Three.js 3D 모드 형상 렌더링 조작법입니다.',
                           'summary_en': 'Interpreting the half-wavelength '
                                         'buckling spectrum signature curve '
                                         'and manipulating 3D mode renders via '
                                         'Three.js.',
                           'tags': [   '시그니처커브',
                                       '3D뷰어',
                                       '반파장',
                                       'Three.js',
                                       'Signature Curve'],
                           'content_html': '\n'
                                           '<div class="manual-article">\n'
                                           '  <h1>시그니처 커브 및 3D 시각화</h1>\n'
                                           '  <p class="lead"><strong>시그니처 '
                                           '커브(Signature Curve)</strong>는 부재의 '
                                           '반파장 길이($L$)를 가로축(로그 스케일)으로, 해당 '
                                           '길이에서의 최소 임계하중 계수($\\lambda$)를 '
                                           '세로축으로 플롯한 고유 스펙트럼 곡선입니다.</p>\n'
                                           '\n'
                                           '  <div class="en-toggle-wrapper">\n'
                                           '    <button class="btn-toggle-en" '
                                           'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                           '원문 보기 (View Original)</button>\n'
                                           '    <div class="inline-en-box" '
                                           'style="display: none;">\n'
                                           '      <div '
                                           'class="en-box-header"><span '
                                           'class="en-badge">ORIGINAL '
                                           'REFERENCE</span></div>\n'
                                           '      <div '
                                           'class="en-box-content">\n'
                                           '        <p>The Signature Curve '
                                           'plots critical load factors '
                                           '(&lambda;) across a wide spectrum '
                                           'of half-wavelengths (L). Local '
                                           'minima on the curve pinpoint the '
                                           'critical local and distortional '
                                           'buckling loads.</p>\n'
                                           '      </div>\n'
                                           '    </div>\n'
                                           '  </div>\n'
                                           '\n'
                                           '  <h2>인터랙티브 3D 좌굴 형상 뷰어 조작법</h2>\n'
                                           '  <ul>\n'
                                           '    <li><strong>마우스 좌클릭 '
                                           '드래그</strong>: 3D 모델 자유 궤도 회전(Orbit '
                                           'Rotate).</li>\n'
                                           '    <li><strong>마우스 우클릭 '
                                           '드래그</strong>: 3D 화면 평면 '
                                           '이동(Pan).</li>\n'
                                           '    <li><strong>마우스 휠 '
                                           '스크롤</strong>: 줌 인 / 줌 아웃.</li>\n'
                                           '    <li><strong>시그니처 차트 '
                                           '클릭</strong>: 특정 반파장 $L$ 지점을 클릭하면 '
                                           '해당 좌굴 모드 형상이 3D 캔버스에 즉시 '
                                           '동기화됩니다.</li>\n'
                                           '  </ul>\n'
                                           '</div>\n',
                           'content_en_html': '\n'
                                              '<div class="manual-article '
                                              'en-article">\n'
                                              '  <h1>Signature Curve & 3D '
                                              'Visualization</h1>\n'
                                              '  <p class="lead">Understand '
                                              'the buckling signature curve '
                                              'and interact with real-time 3D '
                                              'rendered buckling mode '
                                              'deformations powered by '
                                              'Three.js.</p>\n'
                                              '</div>\n'},
    'fsm_params': {   'id': 'fsm_params',
                      'category_id': 'fsm_buckling',
                      'category_title': '4. FSM 탄성 좌굴해석 이론',
                      'title': 'FSM 해석 구간 및 하중조건 설정',
                      'title_en': 'Buckling Analysis Parameters & Results Grid',
                      'summary': '스윕 반파장 범위(Lmin~Lmax), 스텝 수, 편심 압축·휨 하중조건 설정 '
                                 '및 해석 결과 그리드 내보내기 가이드입니다.',
                      'summary_en': 'Configuring half-wavelength sweep limits '
                                    '(Lmin-Lmax), step count, stress '
                                    'distribution, and CSV export.',
                      'tags': [   'FSM파라미터',
                                  '스윕',
                                  '하중조건',
                                  'CSV',
                                  'Buckling Parameters',
                                  'Phase 3'],
                      'content_html': '\n'
                                      '<div class="manual-article">\n'
                                      '  <h1>FSM 해석 구간 및 하중조건 설정</h1>\n'
                                      '  <p class="lead">정밀한 시그니처 커브를 도출하기 위해 '
                                      '<strong>반파장 스윕 범위($L_{min} \\sim '
                                      'L_{max}$)</strong>, <strong>로그 분할 스텝 '
                                      '수</strong> 및 <strong>단면 작용 응력 '
                                      '상태(순수압축/단축휨/이축휨)</strong>를 세부 설정할 수 '
                                      '있습니다.</p>\n'
                                      '\n'
                                      '  <div class="en-toggle-wrapper">\n'
                                      '    <button class="btn-toggle-en" '
                                      'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                      '원문 보기 (View Original)</button>\n'
                                      '    <div class="inline-en-box" '
                                      'style="display: none;">\n'
                                      '      <div class="en-box-header"><span '
                                      'class="en-badge">ORIGINAL '
                                      'REFERENCE</span></div>\n'
                                      '      <div class="en-box-content">\n'
                                      '        <p>The Buckling Parameters '
                                      'dialog controls the minimum/maximum '
                                      'half-wavelength range, number of '
                                      'logarithmic calculation steps, and '
                                      'applied longitudinal stress gradient '
                                      '(Pure Axial, Major/Minor Bending, or '
                                      'Eccentric Stress).</p>\n'
                                      '      </div>\n'
                                      '    </div>\n'
                                      '  </div>\n'
                                      '\n'
                                      '  <h2>주요 해석 파라미터</h2>\n'
                                      '  <ul>\n'
                                      '    <li><strong>반파장 범위 ($L_{min}, '
                                      'L_{max}$)</strong>: 기본값 $10\\text{ mm} '
                                      '\\sim 5000\\text{ mm}$. 단면 크기 및 전체 부재 '
                                      '길이에 맞춰 조정.</li>\n'
                                      '    <li><strong>계산 스텝 수 '
                                      '($N_{steps}$)</strong>: 기본 50스텝(로그 '
                                      '등간격). 정밀 해석 시 100스텝으로 확장 가능.</li>\n'
                                      '    <li><strong>작용 하중 모드</strong>: 순수 '
                                      '압축($P$), 주축 휨($M_x$), 약축 휨($M_y$), 또는 '
                                      '임의 편심 하중 응력 구배 적용.</li>\n'
                                      '    <li><strong>CSV 내보내기</strong>: 전체 '
                                      '반파장별 임계하중 계수 $\\lambda$ 및 고유벡터 데이터를 CSV '
                                      '파일로 다운로드.</li>\n'
                                      '  </ul>\n'
                                      '</div>\n',
                      'content_en_html': '\n'
                                         '<div class="manual-article '
                                         'en-article">\n'
                                         '  <h1>Buckling Analysis Parameters & '
                                         'Results Grid</h1>\n'
                                         '  <p class="lead">Configure '
                                         'half-wavelength sweep bounds '
                                         '($L_{min}, L_{max}$), sampling '
                                         'density, stress distribution types, '
                                         'and export raw buckling analysis '
                                         'curves to CSV.</p>\n'
                                         '</div>\n'},
    'kds_dsm_comp': {   'id': 'kds_dsm_comp',
                        'category_id': 'kds_design',
                        'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                        'title': 'KDS 압축부재 설계 (DSM Pn)',
                        'title_en': 'KDS Compression Member Design (DSM Pn)',
                        'summary': 'KDS 14 31 10 직접강도법(DSM)에 따른 전체좌굴(Pne), '
                                   '국부좌굴(Pnl), 왜곡좌굴(Pnd) 및 공칭압축강도(Pn) 산정식입니다.',
                        'summary_en': 'KDS 14 31 10 Direct Strength Method '
                                      '(DSM) formulas for global (Pne), local '
                                      '(Pnl), and distortional (Pnd) '
                                      'compression strength.',
                        'tags': [   'KDS 14 31 10',
                                    '압축강도',
                                    'DSM',
                                    'Pn',
                                    'Pne',
                                    'Pnl',
                                    'Pnd',
                                    'Compression'],
                        'content_html': '\n'
                                        '<div class="manual-article">\n'
                                        '  <h1>KDS 압축부재 설계 (DSM Pn)</h1>\n'
                                        '  <p class="lead"><strong>KDS 14 31 '
                                        '10 냉간성형강구조설계기준</strong>의 직접강도법(DSM)에 '
                                        '따라 탄성 좌굴하중($P_{cre}, P_{crl}, '
                                        'P_{crd}$)과 항복하중($P_y = A_g F_y$)을 '
                                        '결합하여 공칭압축강도($P_n$)를 산정합니다.</p>\n'
                                        '\n'
                                        '  <div class="en-toggle-wrapper">\n'
                                        '    <button class="btn-toggle-en" '
                                        'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                        '원문 보기 (View Original)</button>\n'
                                        '    <div class="inline-en-box" '
                                        'style="display: none;">\n'
                                        '      <div '
                                        'class="en-box-header"><span '
                                        'class="en-badge">ORIGINAL '
                                        'REFERENCE</span></div>\n'
                                        '      <div class="en-box-content">\n'
                                        '        <p>Nominal axial compressive '
                                        'strength Pn is determined as the '
                                        'minimum of global flexural/torsional '
                                        'buckling (Pne), local buckling '
                                        'interaction (Pnl), and distortional '
                                        'buckling (Pnd) in accordance with KDS '
                                        '14 31 10 and AISI S100.</p>\n'
                                        '      </div>\n'
                                        '    </div>\n'
                                        '  </div>\n'
                                        '\n'
                                        '  <h2>1. 전체 좌굴 강도 ($P_{ne}$)</h2>\n'
                                        '  $$\\lambda_c = \\sqrt{P_y / '
                                        'P_{cre}}$$\n'
                                        '  $$P_{ne} = \\begin{cases} '
                                        '(0.658^{\\lambda_c^2}) P_y & '
                                        '(\\lambda_c \\le 1.5) \\\\ '
                                        '\\left(\\frac{0.877}{\\lambda_c^2}\\right) '
                                        'P_y & (\\lambda_c > 1.5) '
                                        '\\end{cases}$$\n'
                                        '\n'
                                        '  <h2>2. 국부 좌굴 강도 ($P_{nl}$)</h2>\n'
                                        '  $$\\lambda_l = \\sqrt{P_{ne} / '
                                        'P_{crl}}$$\n'
                                        '  $$P_{nl} = \\begin{cases} P_{ne} & '
                                        '(\\lambda_l \\le 0.776) \\\\ \\left[ '
                                        '1 - 0.15 '
                                        '\\left(\\frac{P_{crl}}{P_{ne}}\\right)^{0.4} '
                                        '\\right] '
                                        '\\left(\\frac{P_{crl}}{P_{ne}}\\right)^{0.4} '
                                        'P_{ne} & (\\lambda_l > 0.776) '
                                        '\\end{cases}$$\n'
                                        '\n'
                                        '  <h2>3. 왜곡 좌굴 강도 ($P_{nd}$)</h2>\n'
                                        '  $$\\lambda_d = \\sqrt{P_y / '
                                        'P_{crd}}$$\n'
                                        '  $$P_{nd} = \\begin{cases} P_y & '
                                        '(\\lambda_d \\le 0.561) \\\\ \\left[ '
                                        '1 - 0.25 '
                                        '\\left(\\frac{P_{crd}}{P_y}\\right)^{0.6} '
                                        '\\right] '
                                        '\\left(\\frac{P_{crd}}{P_y}\\right)^{0.6} '
                                        'P_y & (\\lambda_d > 0.561) '
                                        '\\end{cases}$$\n'
                                        '</div>\n',
                        'content_en_html': '\n'
                                           '<div class="manual-article '
                                           'en-article">\n'
                                           '  <h1>KDS Compression Member '
                                           'Design (DSM Pn)</h1>\n'
                                           '  <p class="lead">Evaluates the '
                                           'nominal axial compressive strength '
                                           '($P_n = \\min(P_{nl}, P_{nd})$) '
                                           'using direct strength method '
                                           'provisions.</p>\n'
                                           '</div>\n'},
    'kds_dsm_flex': {   'id': 'kds_dsm_flex',
                        'category_id': 'kds_design',
                        'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                        'title': 'KDS 휨부재 설계 (DSM Mn)',
                        'title_en': 'KDS Flexural Member Design (DSM Mn)',
                        'summary': '횡비틀림좌굴(Mne), 국부좌굴(Mnl), 왜곡좌굴(Mnd) 및 '
                                   '공칭휨강도(Mn) 산정 수식입니다.',
                        'summary_en': 'DSM flexural design equations for '
                                      'lateral-torsional (Mne), local (Mnl), '
                                      'and distortional (Mnd) bending '
                                      'strength.',
                        'tags': [   'KDS 14 31 10',
                                    '휨강도',
                                    'DSM',
                                    'Mn',
                                    'Mne',
                                    'Mnl',
                                    'Mnd',
                                    'Flexure'],
                        'content_html': '\n'
                                        '<div class="manual-article">\n'
                                        '  <h1>KDS 휨부재 설계 (DSM Mn)</h1>\n'
                                        '  <p class="lead"><strong>KDS 14 31 '
                                        '10</strong> 직접강도법에 따라 횡-비틀림 '
                                        '좌굴($M_{ne}$), 국부 좌굴($M_{nl}$), 왜곡 '
                                        '좌굴($M_{nd}$)을 종합 검토하여 공칭휨강도($M_n$)를 '
                                        '산정합니다.</p>\n'
                                        '\n'
                                        '  <div class="en-toggle-wrapper">\n'
                                        '    <button class="btn-toggle-en" '
                                        'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                        '원문 보기 (View Original)</button>\n'
                                        '    <div class="inline-en-box" '
                                        'style="display: none;">\n'
                                        '      <div '
                                        'class="en-box-header"><span '
                                        'class="en-badge">ORIGINAL '
                                        'REFERENCE</span></div>\n'
                                        '      <div class="en-box-content">\n'
                                        '        <p>Nominal flexural strength '
                                        'Mn is governed by the minimum of '
                                        'lateral-torsional buckling (Mne), '
                                        'local buckling interaction (Mnl), and '
                                        'distortional buckling (Mnd).</p>\n'
                                        '      </div>\n'
                                        '    </div>\n'
                                        '  </div>\n'
                                        '\n'
                                        '  <h2>1. 횡-비틀림 좌굴 강도 ($M_{ne}$)</h2>\n'
                                        '  $$M_{ne} = \\begin{cases} M_{cre} & '
                                        '(M_{cre} < 0.56 M_y) \\\\ '
                                        '\\frac{10}{9} M_y \\left( 1 - '
                                        '\\frac{10 M_y}{36 M_{cre}} \\right) & '
                                        '(0.56 M_y \\le M_{cre} < 2.78 M_y) '
                                        '\\\\ M_y & (M_{cre} \\ge 2.78 M_y) '
                                        '\\end{cases}$$\n'
                                        '</div>\n',
                        'content_en_html': '\n'
                                           '<div class="manual-article '
                                           'en-article">\n'
                                           '  <h1>KDS Flexural Member Design '
                                           '(DSM Mn)</h1>\n'
                                           '  <p class="lead">Calculates '
                                           'nominal flexural capacity ($M_n$) '
                                           'accounting for lateral-torsional, '
                                           'local, and distortional buckling '
                                           'modes under KDS 14 31 10.</p>\n'
                                           '</div>\n'},
    'kds_shear_crip': {   'id': 'kds_shear_crip',
                          'category_id': 'kds_design',
                          'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                          'title': 'KDS 전단강도 & 웨브 크리플링',
                          'title_en': 'KDS Shear & Web Crippling Strength',
                          'summary': '웨브 전단강도(Vn) 및 4대 재하/지지조건(EOF, IOF, ETF, '
                                     'ITF)에 따른 공칭 웨브 크리플링 강도(Pnc) 산정식입니다.',
                          'summary_en': 'KDS 14 31 10 formulas for web shear '
                                        'capacity (Vn) and web crippling (Pnc) '
                                        'under 4 loading conditions (EOF, IOF, '
                                        'ETF, ITF).',
                          'tags': [   '전단강도',
                                      '웨브크리플링',
                                      'Vn',
                                      'Pnc',
                                      'EOF',
                                      'IOF',
                                      'ETF',
                                      'ITF',
                                      'Web Crippling',
                                      'Phase 3'],
                          'content_html': '\n'
                                          '<div class="manual-article">\n'
                                          '  <h1>KDS 전단강도 & 웨브 크리플링</h1>\n'
                                          '  <p class="lead">집중 하중 또는 지점 반력이 '
                                          '작용하는 냉간성형강 웨브의 '
                                          '<strong>전단강도($V_n$)</strong>와 국부 '
                                          '찌그러짐을 방지하기 위한 <strong>웨브 크리플링(Web '
                                          'Crippling) 강도($P_{nc}$)</strong>를 '
                                          '산정합니다.</p>\n'
                                          '\n'
                                          '  <div class="en-toggle-wrapper">\n'
                                          '    <button class="btn-toggle-en" '
                                          'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                          '원문 보기 (View Original)</button>\n'
                                          '    <div class="inline-en-box" '
                                          'style="display: none;">\n'
                                          '      <div '
                                          'class="en-box-header"><span '
                                          'class="en-badge">ORIGINAL '
                                          'REFERENCE</span></div>\n'
                                          '      <div class="en-box-content">\n'
                                          '        <p>Web shear strength Vn '
                                          'and web crippling strength Pnc are '
                                          'evaluated per KDS 14 31 10. Web '
                                          'crippling incorporates empirical '
                                          'coefficients based on 4 '
                                          'standardized support and loading '
                                          'cases: EOF, IOF, ETF, and ITF.</p>\n'
                                          '      </div>\n'
                                          '    </div>\n'
                                          '  </div>\n'
                                          '\n'
                                          '  <h2>1. 4대 웨브 크리플링 지지 및 재하 '
                                          '조건</h2>\n'
                                          '  <table class="manual-table">\n'
                                          '    <thead>\n'
                                          '      <tr><th>재하 조건 '
                                          '코드</th><th>명칭</th><th>설명</th></tr>\n'
                                          '    </thead>\n'
                                          '    <tbody>\n'
                                          '      '
                                          '<tr><td><strong>EOF</strong></td><td>End-One-Flange</td><td>단부 '
                                          '지점 반력 작용 (단일 플랜지 재하)</td></tr>\n'
                                          '      '
                                          '<tr><td><strong>IOF</strong></td><td>Interior-One-Flange</td><td>내부 '
                                          '지점 반력 또는 중앙 집중하중 (단일 플랜지 '
                                          '재하)</td></tr>\n'
                                          '      '
                                          '<tr><td><strong>ETF</strong></td><td>End-Two-Flange</td><td>단부 '
                                          '지점에서 상하 플랜지 동시 압축 반력 작용</td></tr>\n'
                                          '      '
                                          '<tr><td><strong>ITF</strong></td><td>Interior-Two-Flange</td><td>내부 '
                                          '지점에서 상하 플랜지 동시 압축 집중하중 '
                                          '작용</td></tr>\n'
                                          '    </tbody>\n'
                                          '  </table>\n'
                                          '\n'
                                          '  <h2>2. 공칭 웨브 크리플링 강도 산정식 '
                                          '($P_{nc}$)</h2>\n'
                                          '  $$P_{nc} = C \\cdot t^2 \\cdot '
                                          'F_y \\cdot \\sin\\theta \\cdot '
                                          '\\left[ 1 - C_R '
                                          '\\sqrt{\\frac{R}{t}} \\right] '
                                          '\\cdot \\left[ 1 + C_N '
                                          '\\sqrt{\\frac{N}{t}} \\right] '
                                          '\\cdot \\left[ 1 - C_h '
                                          '\\sqrt{\\frac{h}{t}} \\right]$$\n'
                                          '  <p>($N$: 받침길이, $R$: 내부 코너반경, $h$: '
                                          '웨브 평판높이, $C, C_R, C_N, C_h$: 조건별 '
                                          '계수)</p>\n'
                                          '</div>\n',
                          'content_en_html': '\n'
                                             '<div class="manual-article '
                                             'en-article">\n'
                                             '  <h1>KDS Shear & Web Crippling '
                                             'Strength</h1>\n'
                                             '  <p class="lead">Computes '
                                             'nominal shear resistance ($V_n$) '
                                             'and localized web crippling '
                                             'capacity ($P_{nc}$) across EOF, '
                                             'IOF, ETF, and ITF loading '
                                             'configurations.</p>\n'
                                             '</div>\n'},
    'quick_design': {   'id': 'quick_design',
                        'category_id': 'kds_design',
                        'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                        'title': '퀵 디자인 (최적 단면 자동 추천)',
                        'title_en': 'Quick Design Optimization Tool',
                        'summary': '설계 소요 하중(Pu, Mu) 또는 등분포하중 입력 시 표준 단면 DB를 '
                                   '자동 전수 탐색하여 안전율을 만족하는 최경량 단면을 추천합니다.',
                        'summary_en': 'Quick Design automatically scans '
                                      'cross-section databases to recommend '
                                      'the lightest, most cost-effective '
                                      'profile satisfying demand loads.',
                        'tags': [   '퀵디자인',
                                    '최적설계',
                                    '단면추천',
                                    'Quick Design',
                                    'Optimization',
                                    'Phase 3'],
                        'content_html': '\n'
                                        '<div class="manual-article">\n'
                                        '  <h1>퀵 디자인 (최적 단면 자동 추천)</h1>\n'
                                        '  <p class="lead"><strong>퀵 디자인(Quick '
                                        'Design)</strong> 도구는 경간 길이, 지지 조건, 소요 '
                                        '설계 하중($P_u, M_{ux}, M_{uy}$)을 입력하면 '
                                        '<strong>표준 단면 '
                                        '라이브러리(1,000+개)</strong>를 실시간으로 전수 '
                                        '검토하여 강도비($D/C \\le 1.0$)를 만족하는 '
                                        '<strong>가장 경제적인(최경량) 단면을 자동 '
                                        '탐색·추천</strong>합니다.</p>\n'
                                        '\n'
                                        '  <div class="en-toggle-wrapper">\n'
                                        '    <button class="btn-toggle-en" '
                                        'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                        '원문 보기 (View Original)</button>\n'
                                        '    <div class="inline-en-box" '
                                        'style="display: none;">\n'
                                        '      <div '
                                        'class="en-box-header"><span '
                                        'class="en-badge">ORIGINAL '
                                        'REFERENCE</span></div>\n'
                                        '      <div class="en-box-content">\n'
                                        '        <p>The Quick Design tool '
                                        'allows you to quickly check or '
                                        'optimize a design for common '
                                        'cold-formed steel members and '
                                        'loadings. Wildcard searches cycle '
                                        'through all available catalog sizes '
                                        'to identify the lightest weight '
                                        'section meeting unity checks.</p>\n'
                                        '      </div>\n'
                                        '    </div>\n'
                                        '  </div>\n'
                                        '\n'
                                        '  <h2>퀵 디자인 활용 절차</h2>\n'
                                        '  <ol>\n'
                                        '    <li><strong>부재 유형 선택</strong>: '
                                        '보(Beam, 휨 부재) 또는 기둥(Column, 압축/조합 부재) '
                                        '선택.</li>\n'
                                        '    <li><strong>설계 조건 입력</strong>: 경간 '
                                        '길이($L$), 브레이싱 간격, 등분포 하중($w$) 또는 소요 '
                                        '단면력($P_u, M_u$) 입력.</li>\n'
                                        '    <li><strong>[⚡ 최적 단면 탐색] '
                                        '클릭</strong>: 백엔드 최적화 엔진이 $D/C$가 1.0 '
                                        '이하인 후보군을 단위중량($kg/m$) 오름차순으로 '
                                        '정렬.</li>\n'
                                        '    <li><strong>[적용 & 로드]</strong>: '
                                        '최적 단면을 선택하면 메인 워크스페이스로 즉시 형상 및 설계 '
                                        '데이터가 반영됩니다.</li>\n'
                                        '  </ol>\n'
                                        '</div>\n',
                        'content_en_html': '\n'
                                           '<div class="manual-article '
                                           'en-article">\n'
                                           '  <h1>Quick Design Optimization '
                                           'Tool</h1>\n'
                                           '  <p class="lead">The Quick Design '
                                           'tool rapidly evaluates member '
                                           'capacity across catalog databases, '
                                           'identifying the lightest, '
                                           'code-compliant cross section for '
                                           'given spans and loadings.</p>\n'
                                           '</div>\n'},
    'kds_interaction': {   'id': 'kds_interaction',
                           'category_id': 'kds_design',
                           'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                           'title': 'P-M 조합응력 & D/C 검토',
                           'title_en': 'P-M Interaction & Biaxial Bending',
                           'summary': '축력-휨 상관식(P-M Interaction), 모멘트 증대계수(B1, '
                                      'B2) 및 수요/용량비(D/C Ratio) 종합 판정 기준입니다.',
                           'summary_en': 'Combined axial compression and '
                                         'biaxial bending interaction '
                                         'equations with moment magnification '
                                         'factors B1 and B2.',
                           'tags': [   '조합응력',
                                       'P-M',
                                       '상관식',
                                       'DC비',
                                       'B1',
                                       'B2',
                                       'Interaction'],
                           'content_html': '\n'
                                           '<div class="manual-article">\n'
                                           '  <h1>P-M 조합응력 & D/C 검토</h1>\n'
                                           '  <p class="lead">압축력과 휨모멘트가 동시에 '
                                           '작용하는 보-기둥(Beam-Column) 부재에 대해 '
                                           '<strong>2차 P-$\\delta$ 및 '
                                           'P-$\\Delta$ 효과</strong>를 고려한 '
                                           '<strong>P-M 상관식</strong>을 '
                                           '검토합니다.</p>\n'
                                           '\n'
                                           '  <div class="en-toggle-wrapper">\n'
                                           '    <button class="btn-toggle-en" '
                                           'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                           '원문 보기 (View Original)</button>\n'
                                           '    <div class="inline-en-box" '
                                           'style="display: none;">\n'
                                           '      <div '
                                           'class="en-box-header"><span '
                                           'class="en-badge">ORIGINAL '
                                           'REFERENCE</span></div>\n'
                                           '      <div '
                                           'class="en-box-content">\n'
                                           '        <p>Combined axial and '
                                           'biaxial bending strength is '
                                           'checked using interaction unity '
                                           'equations with second-order moment '
                                           'amplification factors B1 and B2 '
                                           'per KDS 14 31 10.</p>\n'
                                           '      </div>\n'
                                           '    </div>\n'
                                           '  </div>\n'
                                           '\n'
                                           '  <h2>P-M 조합응력 상관식</h2>\n'
                                           '  $$\\frac{P_u}{\\phi_c P_n} + '
                                           '\\frac{C_{mx} M_{ux}}{\\phi_b '
                                           'M_{nx} \\left(1 - '
                                           '\\frac{P_u}{P_{E1x}}\\right)} + '
                                           '\\frac{C_{my} M_{uy}}{\\phi_b '
                                           'M_{ny} \\left(1 - '
                                           '\\frac{P_u}{P_{E1y}}\\right)} \\le '
                                           '1.0$$\n'
                                           '</div>\n',
                           'content_en_html': '\n'
                                              '<div class="manual-article '
                                              'en-article">\n'
                                              '  <h1>P-M Interaction & Biaxial '
                                              'Bending</h1>\n'
                                              '  <p class="lead">Evaluates '
                                              'combined axial compression and '
                                              'biaxial bending interaction '
                                              'equations incorporating '
                                              'second-order moment '
                                              'amplification.</p>\n'
                                              '</div>\n'},
    'report_guide': {   'id': 'report_guide',
                        'category_id': 'kds_design',
                        'category_title': '5. KDS 14 31 10 부재설계 & 계산서',
                        'title': 'A4 구조계산서 출력 & 인쇄',
                        'title_en': 'A4 Calculation Report Guide',
                        'summary': '단면 형상도, 제원표, FSM 좌굴곡선, 부재검토 결과를 A4 규격 '
                                   '구조계산서로 미리보기 및 PDF 인쇄하는 방법입니다.',
                        'summary_en': 'Formatting, previewing, and exporting '
                                      'full engineering calculation reports '
                                      'conforming to A4 paper standards.',
                        'tags': [   '계산서',
                                    '보고서',
                                    'A4인쇄',
                                    'PDF',
                                    'Report',
                                    'Print'],
                        'content_html': '\n'
                                        '<div class="manual-article">\n'
                                        '  <h1>A4 구조계산서 출력 & 인쇄</h1>\n'
                                        '  <p class="lead">상단 툴바의 <strong>[📄 '
                                        '계산서 생성]</strong> 버튼을 누르면 인허가 제출용 '
                                        '<strong>A4 표준 구조계산서</strong>가 실시간 '
                                        '생성되며 브라우저 인쇄(Ctrl+P)를 통해 PDF로 즉시 저장할 '
                                        '수 있습니다.</p>\n'
                                        '\n'
                                        '  <div class="en-toggle-wrapper">\n'
                                        '    <button class="btn-toggle-en" '
                                        'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                        '원문 보기 (View Original)</button>\n'
                                        '    <div class="inline-en-box" '
                                        'style="display: none;">\n'
                                        '      <div '
                                        'class="en-box-header"><span '
                                        'class="en-badge">ORIGINAL '
                                        'REFERENCE</span></div>\n'
                                        '      <div class="en-box-content">\n'
                                        '        <p>The Member Check Report '
                                        'formats all section geometry, '
                                        'gross/effective properties, elastic '
                                        'buckling curves, and design checks '
                                        'into clean, printable A4-ready '
                                        'documentation.</p>\n'
                                        '      </div>\n'
                                        '    </div>\n'
                                        '  </div>\n'
                                        '\n'
                                        '  <h2>계산서 수록 항목</h2>\n'
                                        '  <ul>\n'
                                        '    <li><strong>1. 프로젝트 개요 & 설계 '
                                        '기준</strong>: KDS 14 31 10 기준 명기 및 강재 '
                                        '물성치</li>\n'
                                        '    <li><strong>2. 단면 형상도 및 Gross '
                                        '성질표</strong>: 단면도, $A_g, I_x, I_y, J, '
                                        'C_w, S_C$ 등</li>\n'
                                        '    <li><strong>3. FSM 탄성 좌굴해석 '
                                        '결과</strong>: 시그니처 커브 차트 및 $P_{crl}, '
                                        'P_{crd}, P_{cre}$ 요약</li>\n'
                                        '    <li><strong>4. KDS 부재내력 산정 '
                                        '근거</strong>: $P_n, M_n, V_n, P_{nc}$ '
                                        '상세 산정식 및 단계별 중간값</li>\n'
                                        '    <li><strong>5. 종합 판정 '
                                        '요약표</strong>: 하중조건별 D/C 비율 및 최종 '
                                        '안전(OK/NG) 판정</li>\n'
                                        '  </ul>\n'
                                        '</div>\n',
                        'content_en_html': '\n'
                                           '<div class="manual-article '
                                           'en-article">\n'
                                           '  <h1>A4 Calculation Report '
                                           'Guide</h1>\n'
                                           '  <p class="lead">Generates formal '
                                           'structural calculation reports '
                                           'formatted for standard A4 printing '
                                           'and PDF submission.</p>\n'
                                           '</div>\n'},
    'analysis_wizard': {   'id': 'analysis_wizard',
                           'category_id': 'frame_analysis',
                           'category_title': '6. 1D 뼈대 구조해석',
                           'title': '1D 구조해석 마법사 & 하중입력',
                           'title_en': '1D Frame Analysis Wizard & Loadings',
                           'summary': '단순보, 2~3경간 연속보, 캔틸레버 모델 마법사 생성 및 등분포·집중 '
                                      '하중/모멘트 입력 인터페이스 가이드입니다.',
                           'summary_en': 'Setting up simple spans, continuous '
                                         'beams, and cantilevers with point, '
                                         'uniform, and moment loadings.',
                           'tags': [   '1D구조해석',
                                       '마법사',
                                       '연속보',
                                       '등분포하중',
                                       '집중하중',
                                       'Frame 1D',
                                       'Phase 4'],
                           'content_html': '\n'
                                           '<div class="manual-article">\n'
                                           '  <h1>1D 구조해석 마법사 & 하중입력</h1>\n'
                                           '  <p class="lead"><strong>1D 구조해석 '
                                           '모듈</strong>은 단일 경간 단순보, '
                                           '<strong>다경간 연속보(Continuous '
                                           'Beams)</strong>, 캔틸레버 등 다양한 보 부재 '
                                           '시스템을 FEM(유한요소법) 기반으로 정밀 해석할 수 있는 '
                                           '전용 마법사와 하중 입력 도구를 제공합니다.</p>\n'
                                           '\n'
                                           '  <div class="en-toggle-wrapper">\n'
                                           '    <button class="btn-toggle-en" '
                                           'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                           '원문 보기 (View Original)</button>\n'
                                           '    <div class="inline-en-box" '
                                           'style="display: none;">\n'
                                           '      <div '
                                           'class="en-box-header"><span '
                                           'class="en-badge">ORIGINAL '
                                           'REFERENCE</span></div>\n'
                                           '      <div '
                                           'class="en-box-content">\n'
                                           '        <p>The 1D Analysis Wizard '
                                           'simplifies the creation of '
                                           'structural frames, continuous '
                                           'beams, and cantilevers. Users can '
                                           'assign support boundary conditions '
                                           'and multiple load cases including '
                                           'uniform distributed loads, '
                                           'concentrated point loads, and '
                                           'applied moments.</p>\n'
                                           '      </div>\n'
                                           '    </div>\n'
                                           '  </div>\n'
                                           '\n'
                                           '  <h2>1. 지원 모델 템플릿</h2>\n'
                                           '  <ul>\n'
                                           '    <li><strong>단순보 (Simply '
                                           'Supported Beam)</strong>: 핀-롤러 2점 '
                                           '지지 기본 보.</li>\n'
                                           '    <li><strong>2~3경간 연속보 '
                                           '(Continuous Beam)</strong>: 다경간 중간 '
                                           '지점을 갖는 연속 빔 시스템.</li>\n'
                                           '    <li><strong>캔틸레버 '
                                           '(Cantilever)</strong>: 일단 고정 타단 자유 '
                                           '외팔보.</li>\n'
                                           '    <li><strong>양단 고정보 '
                                           '(Fixed-Fixed Beam)</strong>: 양단 '
                                           '모멘트 구속 보.</li>\n'
                                           '  </ul>\n'
                                           '\n'
                                           '  <h2>2. 하중 조건 입력</h2>\n'
                                           '  <ul>\n'
                                           '    <li><strong>등분포 하중 ($w, '
                                           '\\text{kN/m}$)</strong>: 전 경간 또는 '
                                           '특정 구간에 작용하는 중력 하중.</li>\n'
                                           '    <li><strong>집중 하중 ($P, '
                                           '\\text{kN}$)</strong>: 특정 위치($x$)에 '
                                           '작용하는 집중 점 하중.</li>\n'
                                           '    <li><strong>외력 모멘트 ($M, '
                                           '\\text{kN}\\cdot\\text{m}$)</strong>: '
                                           '특정 절점에 작용하는 집중 모멘트.</li>\n'
                                           '  </ul>\n'
                                           '</div>\n',
                           'content_en_html': '\n'
                                              '<div class="manual-article '
                                              'en-article">\n'
                                              '  <h1>1D Frame Analysis Wizard '
                                              '& Loadings</h1>\n'
                                              '  <p class="lead">Quickly '
                                              'construct and solve 1D beam and '
                                              'continuous framing models under '
                                              'distributed, concentrated, and '
                                              'moment loading conditions.</p>\n'
                                              '</div>\n'},
    'diagrams_viewer': {   'id': 'diagrams_viewer',
                           'category_id': 'frame_analysis',
                           'category_title': '6. 1D 뼈대 구조해석',
                           'title': 'SFD / BMD / 처짐 다이어그램',
                           'title_en': 'Shear, Moment & Deflection Diagrams',
                           'summary': '전단력도(SFD), 휨모멘트도(BMD), 처짐(Deflection) '
                                      '다이어그램 뷰어 및 부재설계(Member Check) 원클릭 연동 '
                                      '가이드입니다.',
                           'summary_en': 'Interactive SFD, BMD, and Deflection '
                                         'diagram visualization with one-click '
                                         'export to KDS member design.',
                           'tags': [   'SFD',
                                       'BMD',
                                       '처짐',
                                       '다이어그램',
                                       'Diagrams',
                                       'Deflection',
                                       'Phase 4'],
                           'content_html': '\n'
                                           '<div class="manual-article">\n'
                                           '  <h1>SFD / BMD / 처짐 다이어그램</h1>\n'
                                           '  <p class="lead">1D 구조해석 수행 완료 시, '
                                           '보 전 구간에 걸친 '
                                           '<strong>전단력도(SFD)</strong>, '
                                           '<strong>휨모멘트도(BMD)</strong>, '
                                           '<strong>처짐 '
                                           '곡선(Deflection)</strong>이 고해상도 차트로 '
                                           '즉시 렌더링되며, <strong>최대 소요 '
                                           '단면력($M_{max}, V_{max}$)</strong>이 '
                                           'KDS 부재설계 모듈로 자동 연동됩니다.</p>\n'
                                           '\n'
                                           '  <div class="en-toggle-wrapper">\n'
                                           '    <button class="btn-toggle-en" '
                                           'onclick="window.manualViewer.toggleInlineEn(this)">🌐 '
                                           '원문 보기 (View Original)</button>\n'
                                           '    <div class="inline-en-box" '
                                           'style="display: none;">\n'
                                           '      <div '
                                           'class="en-box-header"><span '
                                           'class="en-badge">ORIGINAL '
                                           'REFERENCE</span></div>\n'
                                           '      <div '
                                           'class="en-box-content">\n'
                                           '        <p>The Analysis Diagrams '
                                           'window displays continuous Shear '
                                           'Force Diagrams (SFD), Bending '
                                           'Moment Diagrams (BMD), and '
                                           'Deflection curves across the '
                                           'entire span. Critical peak forces '
                                           'are passed directly to Member '
                                           'Check.</p>\n'
                                           '      </div>\n'
                                           '    </div>\n'
                                           '  </div>\n'
                                           '\n'
                                           '  <h2>다이어그램 인터랙션 및 해석 기능</h2>\n'
                                           '  <ul>\n'
                                           '    <li><strong>마우스 호버 '
                                           '추적</strong>: 차트 위를 마우스로 이동하면 해당 '
                                           '위치($x$)의 정확한 전단력, 휨모멘트, 처짐 수치가 실시간 '
                                           '툴팁으로 표시됩니다.</li>\n'
                                           '    <li><strong>허용 처짐 검토</strong>: '
                                           '사용성 한계상태 기준($L/240, L/360$ 등) 대비 '
                                           '최대 처짐량($\\delta_{max}$) 자동 '
                                           '판정.</li>\n'
                                           '    <li><strong>[⚡ 부재설계로 '
                                           '연동]</strong>: 추출된 최대 정/부모멘트($M_u$) '
                                           '및 최대 전단력($V_u$)을 현재 단면의 KDS 부재검토 '
                                           '패널로 즉시 전송하여 단면 내력을 자동 검토합니다.</li>\n'
                                           '  </ul>\n'
                                           '</div>\n',
                           'content_en_html': '\n'
                                              '<div class="manual-article '
                                              'en-article">\n'
                                              '  <h1>Shear, Moment & '
                                              'Deflection Diagrams</h1>\n'
                                              '  <p class="lead">Visualize '
                                              'continuous Shear Force Diagrams '
                                              '(SFD), Bending Moment Diagrams '
                                              '(BMD), and Deflection profiles '
                                              'with direct parameter transfer '
                                              'to KDS Member Check.</p>\n'
                                              '</div>\n'}}
