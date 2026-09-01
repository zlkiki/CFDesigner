# [기술 문서 07] CFDesigner 웹 애플리케이션 및 UI/UX 구조 명세서 (07_web_application_ui_ux_specification.md)

> **문서 상태**: 🌟 Single Source of Truth (SSOT)  
> **문서 버전**: v3.0 (Phase 1~8 전체 구현, 3열 풀스펙 퀵디자인, FSM 응력구배, 코너 Fillet 및 테마/로딩 반응형 UX 완전 통합판)  
> **대상 시스템**: CFDesigner (냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS/AISI 부재설계 웹 애플리케이션)  
> **접속 URL**: `http://127.0.0.1:8000/` (메인 대시보드) & `http://127.0.0.1:8000/manual` (온라인 매뉴얼)

---

## 1. 시스템 개요 및 디자인 철학

CFDesigner는 데스크톱 전용 상용 프로그램(`CFS.exe v14.0`)의 공학적 알고리즘(기하특성 선적분, FSM 탄성 좌굴해석, Winter 유효폭 반복해석, KDS 14 31 10 / AISI S100 직접강도법 설계, 1D 뼈대 FEM 해석)을 **AltDP 스타일의 모던 웹 엔지니어링 SaaS**로 100% 완전 포팅한 차세대 구조설계 시스템입니다.

### 1.1 핵심 디자인 및 UX 원칙
1. **AltDP 4분면 반응형 레이아웃 (4-Quadrant Reactive Workflow)**:
   - 좌측(단면/부재 제어) $\rightarrow$ 중앙 상단(2D CAD / 3D WebGL 뷰어) $\rightarrow$ 중앙 하단(FSM 시그니처 커브) $\rightarrow$ 우측(Gross 단면성질 및 KDS 5대 D/C 게이지)으로 이어지는 4분면 일체형 구조.
   - 단면 치수 변경, DXF 업로드, 기하 변환, 하중 조건 변경 시 **기하특성 $\rightarrow$ FSM 좌굴해석 $\rightarrow$ KDS 부재강도 및 D/C 내력비가 50ms 이내에 즉각 실시간 동기화**됩니다.
2. **다크/라이트 듀얼 테마 & 고대비 시각화 (Dual Theme & Contrast Engine)**:
   - `[data-theme="dark"]` (`#0f172a`, `#1e293b`) 및 `[data-theme="light"]` (`#ffffff`, `#f8fafc`) 전역 변수 일괄 동기화.
   - 3D 뷰어 씬 배경색(`scene.background`: Dark `#0d1117`, Light `#e2e8f0`) 및 바닥면 그리드, 2D 캔버스 원점 마커, 툴바가 테마에 맞춰 고대비로 정밀 전환.
3. **논블로킹 플로팅 피드백 UX (Non-Blocking Floating Loaders)**:
   - 단면 변경 및 FSM 수치해석 시 화면 전체를 잠그지 않고, 2D 캔버스 및 3D 뷰어 뷰포트 정중앙에 반투명 글래스모피즘 로딩 스피너("⏳ 단면 성질 재계산 중...", "⏳ FSM 좌굴해석 재계산 중...")를 띄워 사용자 피드백 제공.
   - 백그라운드 요청 취소(`AbortController`) 시 상태바에 불필요한 오류 알림 없이 조용히 디버그 콘솔로만 기록.
4. **CFS 원본 대화창 100% 풀스펙 모달 아키텍처**:
   - 10대 전문 모달 다이얼로그(3열 풀스펙 퀵디자인, 1D 구조해석, 표준 라이브러리, 재료 DB/가공경화, 유효단면, FSM 파라미터 등)를 갖추어 레거시 데스크톱 기능을 웹 브라우저에서 무결하게 지원.

---

## 2. 전체 시스템 아키텍처 및 컴포넌트 구조

```mermaid
graph TD
    subgraph Client ["프론트엔드 계층 (AltDP Web Client UI)"]
        Header["상단 글로벌 헤더<br>(상태 인디케이터, 테마 토글, 6대 전문 모달 버튼)"]
        Sidebar["좌측 제어 사이드바 (320px)<br>(📐 단면 마법사 / DXF 업로드 / ⚙️ 부재설계 & 웨브크리플링 통합)"]
        Center["중앙 2D/3D 워크스페이스<br>(2D CAD 캔버스 / 3D WebGL 좌굴모드 / FSM 시그니처 차트)"]
        Dashboard["우측 분석 대시보드 (360px)<br>(Gross 단면성질 / KDS 5대 D/C 게이지 바 / P-M 조합응력)"]
        Modals["10대 전문 모달 다이얼로그<br>(3열 퀵디자인, 1D 구조해석, 라이브러리, 재료DB, 리포트 등)"]
    end

    subgraph Server ["백엔드 계층 (FastAPI 비동기 엔진)"]
        Router["REST API 라우터 (/api/*, /api/manual/*)"]
        CadMod["CAD/DXF 파서 & 메셔 (ezdxf, shapely)"]
        GeomMod["단면 기하특성 선적분 & Winter 유효폭 솔버"]
        FSMMod["FSM 유한대판 탄성좌굴 & 고유치 솔버 (NumPy, SciPy)"]
        FrameMod["1D 보/연속보 FEM 구조해석 솔버"]
        DSMMod["KDS 14 31 10 / AISI S100 부재설계 & 퀵디자인 엔진"]
        ReportMod["A4 엔지니어링 계산서 렌더러 (Jinja2/HTML)"]
    end

    Client <-->|비동기 REST API (JSON, < 50ms)| Server
    Router --> CadMod & GeomMod & FSMMod & FrameMod & DSMMod & ReportMod
```

---

## 3. 화면 레이아웃 및 4대 영역 구성 명세

### 3.1 상단 글로벌 헤더 (Global Header Bar)
* **브랜드 로고 & 기준 뱃지**: `CFDesigner` 로고 및 `KDS 14 31 10 / AISI S100` 기준 표기.
* **실시간 글로벌 상태 표시줄 (Status Indicator Bar)**:
  - ⚡ **준비 완료 (Ready)**: 정상 대기 상태 (그린 펄스)
  - 🔄 **연산 중 (Busy)**: FSM / 1D FEM 수치해석 연산 중 (블루 스핀)
  - ✅ **성공 (Success)**: 모델 로드 또는 최적설계 완료 알림
  - ⚠️ **주의 / 오류 (Warning / Error)**: 기하 결함 또는 입력값 초과 경고
* **글로벌 액션 버튼 그룹**:
  - `🌓 테마`: 다크 / 라이트 모드 즉시 전환 (`localStorage` 영속화)
  - `🏗️ 1D 구조해석`: 1D 보/연속보 FEM 구조해석 모달 호출 (`frameAnalysisModal`)
  - `⚡ 퀵 디자인`: 3열 풀스펙 최적 경량 단면 자동 탐색 모달 호출 (`quickDesignModal`)
  - `📚 단면 라이브러리`: 1,000+개 북미/한국 표준 단면 브라우저 호출 (`sectionLibraryModal`)
  - `🧪 재료 DB / 가공경화`: 강종 DB 및 코너 가공경화($F_{ya}$) 계산기 호출 (`materialModal`)
  - `❓ 온라인 매뉴얼`: 한·영 3-Way 공학 도움말 시스템(`/manual`) 새 탭 호출
  - `📄 A4 구조계산서 출력`: 요약/상세 듀얼 모드 구조계산서 팝업 호출 (`reportModal`)

### 3.2 좌측 제어 사이드바 (Left Control Sidebar / 320px)
* **2-Tab 네비게이션**:
  1. **📐 단면 생성 (Section Modeling)**:
     - **단면 마법사 (Parametric Wizard)**: 6대 기본 형상(C, Z, Hat, Tube, Angle, Deck) 치수($H, B, C, t, R$) 입력 및 갱신.
     - **AutoCAD DXF 드롭존**: 2D Polyline DXF 파일 드래그 & 드롭 및 파일 선택.
  2. **⚙️ 부재 설계 (Member Design - 웨브 크리플링 통합)**:
     - **강종 및 재료 특성**: 항복강도 $F_y$(MPa), 탄성계수 $E$(MPa), 포아송비 $\nu$.
     - **부재 길이 및 지점 구속조건**: 비지지길이 $L_x, L_y, L_t$(mm), 유효좌굴길이계수 $K_x, K_y, K_t$, 모멘트계수 $C_b$.
     - **설계 소요 하중 (LRFD Factored Loads)**: 축압축력 $P_u$(kN), 강축 휨모멘트 $M_{ux}$(kN·m), 약축 휨모멘트 $M_{uy}$(kN·m), 소요 전단력 $V_u$(kN).
     - **웨브 크리플링 (Web Crippling / KDS 4.4)**:
       - 4대 지지조건 선택 (IOF, EOF, ITF, ETF)
       - 지압길이 $N$(mm), 플랜지 체결 및 립 보강 여부 체크박스
       - 소요 지점반력 $R_u$(kN), 공칭지압강도 $P_{nc}$, 설계지압강도 $\phi P_{nc}$, 지압 D/C 실시간 표시.

### 3.3 중앙 2D/3D 그래픽 & FSM 작업공간 (Center Workspace)
* **상단 뷰어 영역 (2D Canvas / 3D WebGL 탭 전환)**:
  - **📐 2D 단면 형상 뷰어 ([`canvas_2d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/canvas_2d.js))**:
    - 단면 외곽선, 요소 중심선, 노드 번호, 요소 번호 렌더링.
    - 코너 Fillet 곡선(Arc) 렌더링 (각진 모서리 $\rightarrow$ 부드러운 곡선 표현).
    - 도심($C_G$, 적색 십자), 전단중심($S_C$, 청색 십자), 주축($X_1-X_2$, 점선), 원점($(0,0)$ 십자 마커) 오버레이.
    - **2D 플로팅 오버레이 툴바**:
      - `⛶`: 화면 맞춤 (Fit View)
      - `👁️ 유효단면`: Winter 유효단면 점선 오버레이 토글
      - `📋 요소편집`: 요소 좌표/치수 스프레드시트 편집기 열기
      - `↻ 90°` / `↺ 90°`: 직교 회전
      - `🔀 회전`: 임의 각도 회전 모달 호출
      - `🪞 상하` / `🪞 좌우`: 대칭 미러링
      - `🎯 도심정렬`: $(0, 0)$ 원점을 도심($C_G$)으로 일괄 평행이동
      - `⚡ 리브추가`: 웨브/플랜지 중간 보강 리브 삽입 모달
  - **🌀 3D 좌굴 모드형상 뷰어 ([`viewer_3d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/viewer_3d.js))**:
    - Three.js WebGL 기반 3D 부재 좌굴 변형 애니메이션.
    - 다크/라이트 테마 자동 명암비 제어 (배경색, 조명, 바닥 그리드).
    - 모드 선택 버튼: 로컬 버클링(Local), 디스토셔널 버클링(Distortional), 글로벌 버클링(Global) 활성 상태 유지.
    - 진폭(Amplitude) 조절 슬라이더 ($1 \sim 40\times$).
    - 사각파이프(Tube) 등 폐구단면 3D 절점 일체거동 지원.
* **하단 FSM 시그니처 커브 영역 ([`chart_fsm.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/chart_fsm.js))**:
  - 반파장 길이 $L$(10 ~ 10,000 mm, 로그 스케일)에 따른 탄성좌굴하중계수 $\beta$ 반응형 곡선.
  - 순수 압축 외에 강축 휨, 약축 휨, 편심압축 응력구배 하 기하강성행렬 $[K_g]$ 정밀 수치해석.
  - 로컬($P_{crl}$), 디스토셔널($P_{crd}$), 글로벌($P_{cre}$) 극소점 자동 탐지 및 뱃지 표시.
  - 커브 클릭 시 해당 파장의 3D 좌굴 모드로 즉시 동기화.
  - `⚙️ 세부설정`: 파장 범위($L_{min} \sim L_{max}$), 스텝수, 응력분포(압축/휨) 변경 모달.
  - `📊 수치데이터`: 파장별 수치 테이블 조회 및 CSV 파일 내보내기.

### 3.4 우측 분석 결과 대시보드 (Right Dashboard / 360px)
* **단면 기하학적 성질 (Gross Properties Table)**:
  - 총단면적 $A_g$, 단위중량 $\text{Weight}$, 단면2차모멘트 $I_x, I_y$, 단면2차반경 $r_x, r_y$.
  - 주축회전각 $\theta_p$, 비틀림상수 $J$, 뒴상수 $C_w$, 전단중심 $X_0, Y_0$, 극단면2차반경 $r_0$.
* **KDS 14 31 10 부재 내력 검토 카드 (Design Check & Gauges)**:
  - **축압축강도 (Compression)**: $\phi P_n$, D/C 게이지 바, 상태 뱃지 (OK / NG), 지배 좌굴모드.
  - **휨모멘트강도 (Flexure X-X)**: $\phi M_n$, D/C 게이지 바, 상태 뱃지 (OK / NG), 지배 좌굴모드.
  - **웨브 전단강도 (Shear)**: $\phi V_n$, D/C 게이지 바, 상태 뱃지 (OK / NG).
  - **웨브 크리플링 (Web Crippling)**: $\phi P_{nc}$, 지압 D/C 게이지 바, 상태 뱃지 (OK / NG).
  - **P-M 조합응력 (Interaction)**: 상관비(Ratio), 조합응력 게이지 바, 식 (1.4-1) 최종 판정.

---

## 4. 10대 전문 모달 다이얼로그 명세

| 모달 ID | 명칭 | 주요 기능 및 인터랙션 | 연동 모듈 |
|---|---|---|---|
| `quickDesignModal` | **퀵 디자인 3열 풀스펙 모달** | 6대 단면/재료 필터, 경간/하중/처짐/지압 입력, 강도·처짐·크리플링 3대 D/C 만족 최경량 단면 자동 탐색 및 원클릭 단면 로드 | [`quick_design.py`](file:///f:/PyProject/CFDesigner/src/design/quick_design.py) |
| `frameAnalysisModal` | **1D 구조해석 & 다이어그램** | 단순보/2경간/3경간/캔틸레버 지점·하중 설정, SFD/BMD/처짐 실시간 연산, $M_{max}, V_{max}$ 부재설계 연동 | [`frame1d.py`](file:///f:/PyProject/CFDesigner/src/solver/frame1d.py) |
| `reportModal` | **A4 구조계산서 뷰어** | "요약 보고서" / "상세 보고서" 듀얼 모드 선택, 헤더 인쇄/PDF 저장 단일화 | [`html_report.py`](file:///f:/PyProject/CFDesigner/src/report/html_report.py) |
| `effectiveModal` | **Winter 유효단면 해석** | KaTeX 수식 렌더링, 모달 내 실시간 연산 완결, 2D 오버레이 전용 버튼 & 우측 단면성질 연동 | [`effective_width.py`](file:///f:/PyProject/CFDesigner/src/geometry/effective_width.py) |
| `sectionLibraryModal` | **표준 단면 라이브러리** | SSMA, SFIA, AISI, LGSI, HUD 1,000+개 단면 검색, 2D 미니 프리뷰, 원클릭 로드 | [`library_parser.py`](file:///f:/PyProject/CFDesigner/src/geometry/library_parser.py) |
| `materialModal` | **재료 DB & 가공경화 계산기** | KS/ASTM 강종 프리셋, 코너 가공경화 유효항복강도($F_{ya}$) 자동 산정 및 적용 | [`library_parser.py`](file:///f:/PyProject/CFDesigner/src/geometry/library_parser.py) |
| `elementEditorModal` | **요소 스프레드시트 편집기** | 요소별 $X_0, Y_0, X_1, Y_1, L, \theta, t, R$ 표 편집, 행 추가/삭제, 재해석 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `rotateModal` | **임의 각도 단면 회전** | 사용자 지정 각도($\theta^\circ$) 및 도심($C_G$) 기준 회전 변환 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `insertRibsModal` | **중간 보강 리브 추가** | 대상 요소에 V형/사다리꼴 리브($w_r, d_r, \text{count}$) 파라메트릭 삽입 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `fsmParamsModal` | **FSM 해석 세부 설정** | $L_{min}, L_{max}$, 스텝수(15~150), 응력형태(압축/강축휨/약축휨) 재해석 | [`strip_assembler.py`](file:///f:/PyProject/CFDesigner/src/solver/strip_assembler.py) |
| `fsmDataModal` | **FSM 수치 데이터 & CSV** | 파장별 $L, \beta, P_{cr}, M_{cr}$ 테이블 조회 및 원클릭 CSV 파일 다운로드 | [`app.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/app.js) |

---

## 5. 상세 UX 인터랙션 및 데이터 파이프라인

### 5.1 2D CAD 캔버스 인터랙션 ([`canvas_2d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/canvas_2d.js))
- **마우스 휠 줌 (Zoom In/Out)**: 커서 위치를 중심으로 부드러운 스케일링 ($0.2\times \sim 15\times$).
- **드래그 이동 (Pan)**: 마우스 좌클릭 드래그로 뷰포트 자유 이동.
- **화면 맞춤 (Fit View)**: 캔버스 크기 및 단면 바운딩 박스를 계산하여 여백 20%를 포함한 최적 뷰 자동 정렬.
- **코너 Fillet 렌더링**: 각진 모서리가 아닌 실제 반경 $R$을 반영한 부드러운 호(Arc) 곡선 표현.
- **도심($C_G$), 전단중심($S_C$), 주축, 원점($(0,0)$) 렌더링**: 시각적 식별성을 위해 색상 및 기호 분리.
- **Winter 유효단면 오버레이**: 비유효 영역을 파란 점선(Dashed Line)으로 표시하여 압축 좌굴에 따른 유효폭 감소 직관화.

### 5.2 3D 좌굴모드 WebGL 인터랙션 ([`viewer_3d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/viewer_3d.js))
- **3D 궤도 제어 (OrbitControls)**: 좌클릭 회전, 우클릭 패닝, 휠 줌.
- **다크/라이트 테마 자동 명암비**: 테마 전환 시 씬 배경색 및 바닥 그리드 즉시 전환.
- **변형 애니메이션 (Buckling Oscillation)**: 사인파 기반 모드 변형 실시간 진동 애니메이션.
- **진폭 제어**: 슬라이더를 통해 과장 배율($1 \sim 40\times$) 즉시 조정.
- **FSM 곡선 연동**: FSM 차트에서 모드 마커 클릭 시 해당 반파장과 고유벡터로 3D 형상 즉각 재구성.

### 5.3 퀵 디자인 $\rightarrow$ 메인 작업공간 원클릭 연동 파이프라인
1. 사용자가 퀵디자인 모달에서 하중 및 구속조건을 입력하고 [⚡ 최적 단면 자동 탐색] 실행.
2. 강도, 처짐, 웨브 크리플링 3대 D/C를 모두 만족하는 최경량 단면 후보 목록(1~15위)이 3열 테이블에 렌더링.
3. 임의 단면의 **[⚡ 적용]** 버튼 클릭 시:
   - 해당 단면의 요소 기하 데이터가 메인 2D 캔버스와 3D 뷰어로 즉시 주입.
   - 부재설계 탭의 비지지길이($L_x, L_y, L_t$)가 퀵디자인 경간 길이로 동기화.
   - FSM 탄성 좌굴해석 및 KDS 부재내력 검토가 백그라운드에서 자동 재연산되어 화면 전체가 갱신됨.
