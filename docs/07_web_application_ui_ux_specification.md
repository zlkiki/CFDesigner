# [기술 문서 07] CFDesigner 웹 애플리케이션 및 UI/UX 구조 명세서 (07_web_application_ui_ux_specification.md)

> **문서 상태**: 🌟 Single Source of Truth (SSOT)  
> **문서 버전**: v2.0 (Phase 1~5 전체 구현 및 UI/UX 인터랙션 완전 통합판)  
> **대상 시스템**: CFDesigner (냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS/AISI 부재설계 웹 애플리케이션)  
> **접속 URL**: `http://127.0.0.1:8000/` (메인 대시보드) & `http://127.0.0.1:8000/manual` (온라인 매뉴얼)

---

## 1. 시스템 개요 및 디자인 철학

CFDesigner는 데스크톱 전용 상용 프로그램(`CFS.exe v14.0`)의 공학적 알고리즘(기하특성 선적분, FSM 탄성 좌굴해석, Winter 유효폭 반복해석, KDS 14 31 10 / AISI S100 직접강도법 설계)을 **AltDP 스타일의 모던 웹 엔지니어링 SaaS**로 전면 전환한 시스템입니다.

### 1.1 핵심 디자인 및 UX 철학
1. **반응형 리액티브 컴퓨팅 (Reactive Engineering Workflow)**:
   - 사용자가 단면 치수 변경, DXF 업로드, 기하 변환, 하중 조건을 변경할 때 별도의 복잡한 절차 없이 **단면 기하특성 $\rightarrow$ FSM 좌굴해석 $\rightarrow$ KDS 부재강도 및 D/C 내력비가 50ms 이내에 즉각 실시간 동기화**됩니다.
2. **다중 뷰포트 시각화 (Multi-Viewport Visual Interaction)**:
   - 2D Canvas 단면 작도, 3D WebGL 좌굴모드 애니메이션, Chart.js FSM 시그니처 커브가 유기적으로 연동되어 시각적 직관성을 제공합니다.
3. **단절 없는 워크플로우 (Seamless Modals & Data Pipeline)**:
   - 단면 라이브러리, 재료 DB, 1D 구조해석, 퀵 디자인 등 모든 보조 기능이 모달 기반으로 동작하며, 작업 결과가 원클릭으로 메인 설계 엔진에 주입됩니다.

---

## 2. 전체 시스템 아키텍처 및 컴포넌트 구조

```mermaid
graph TD
    subgraph Client ["프론트엔드 계층 (AltDP Web Client UI)"]
        Header["상단 글로벌 헤더<br>(상태바, 테마, 모달 호출 툴바)"]
        Sidebar["좌측 제어 사이드바<br>(단면 마법사 / DXF / 재료 / 지점 / 크리플링)"]
        Center["중앙 워크스페이스<br>(2D CAD 캔버스 / 3D WebGL 뷰어 / FSM 차트)"]
        Dashboard["우측 결과 대시보드<br>(Gross 성질 / KDS 내력 검토 / D/C 게이지)"]
        Modals["10대 전문 모달 다이얼로그<br>(라이브러리, 1D해석, 퀵디자인, 요소편집, 리포트 등)"]
    end

    subgraph Server ["백엔드 계층 (FastAPI 비동기 엔진)"]
        Router["REST API 라우터 (/api/*, /api/manual/*)"]
        CadMod["CAD/DXF 파서 & 메셔 (ezdxf, shapely)"]
        GeomMod["단면 기하특성 & Winter 유효폭 솔버"]
        FSMMod["FSM 유한대판법 탄성좌굴 솔버 (NumPy, SciPy)"]
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
* **브랜드 그룹**: CFDesigner 로고 및 기준 규준 뱃지(`KDS 14 31 10 / AISI S100`)
* **실시간 글로벌 상태 표시줄 (Status Indicator Bar)**:
  - ⚡ **준비 완료 (Ready)**: 정상 대기 상태 (그린 펄스)
  - ⏳ **해석 연산 중 (Calculating)**: FSM / 1D FEM 수치해석 연산 중 (블루 스핀)
  - ❌ **오류 발생 (Error)**: 유효하지 않은 기하 형상 또는 서버 예외 알림
* **글로벌 액션 버튼 그룹**:
  - `🌓 테마`: 다크 / 라이트 모드 즉시 전환 (`localStorage` 영속화)
  - `🏗️ 1D 구조해석`: 1D 보/연속보 FEM 구조해석 다이얼로그 호출
  - `⚡ 퀵 디자인`: 목표 하중 기반 최적 경량 단면 자동 탐색 모달 호출
  - `📚 단면 라이브러리`: 1,000+개 북미/한국 표준 단면 브라우저 호출
  - `🧪 재료 DB / 가공경화`: 강종 DB 및 코너 가공경화 강도 증가 모달 호출
  - `❓ 온라인 매뉴얼`: 한·영 3-Way 공학 도움말 시스템(`/manual`) 새 탭 호출
  - `📄 A4 구조계산서 출력`: KDS 14 31 10 A4 표준 계산서 팝업 출력

### 3.2 좌측 제어 사이드바 (Left Control Sidebar / 320px)
* **2-Tab 네비게이션**:
  1. **📐 단면 생성 (Section Modeling)**:
     - **단면 마법사 (Parametric Wizard)**: 6대 기본 형상(C, Z, Hat, Tube, Angle, Deck) 치수($H, B, C, t, R$) 입력
     - **AutoCAD DXF 드롭존**: 2D Polyline DXF 파일 드래그 & 드롭 및 파일 선택
  2. **⚙️ 부재 설계 (Member Design)**:
     - **강종 및 재료 특성**: $F_y$(항복강도), $E$(탄성계수)
     - **부재 길이 및 지점 조건**: 비지지길이 $L$, 유효좌굴길이계수 $K_x, K_y$
     - **설계 소요 하중**: 축압축력 $P_u$, 강축 휨모멘트 $M_{ux}$, 전단력 $V_u$
     - **웨브 크리플링 (Web Crippling / KDS 4.4)**: 재하조건(IOF, EOF, ITF, ETF), 지지길이 $N$, 플랜지 체결 및 립 보강 여부, 소요반력 $R_u$, 공칭지압강도 $P_{nc}$, 설계지압강도 $\phi P_{nc}$, 지압 D/C 실시간 표시

### 3.3 중앙 CAD & FSM 작업공간 (Center Workspace)
* **상단 뷰어 영역 (2D Canvas / 3D WebGL 탭 전환)**:
  - **📐 2D 단면 형상 뷰어 ([`canvas_2d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/canvas_2d.js))**:
    - 단면 외곽선, 요소 중심선, 노드 번호, 요소 번호 렌더링
    - 도심($C_G$, 적색 십자), 전단중심($S_C$, 청색 십자), 주축($X_1-X_2$, 점선) 오버레이
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
    - Three.js WebGL 기반 3D 부재 좌굴 변형 애니메이션
    - 모드 선택 버튼: 국부(Local), 왜곡(Distortional), 전체(Global)
    - 진폭(Amplitude) 조절 슬라이더 ($1 \sim 40\times$)
* **하단 FSM 시그니처 커브 영역 ([`chart_fsm.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/chart_fsm.js))**:
  - 반파장 길이 $L$(10 ~ 10,000 mm, 로그 스케일)에 따른 탄성좌굴하중계수 $\beta$ 반응형 곡선
  - 국부($P_{crl}$), 왜곡($P_{crd}$), 전체($P_{cre}$) 극소점 자동 탐지 및 뱃지 표시
  - 커브 클릭 시 해당 파장의 3D 좌굴 모드로 즉시 동기화
  - `⚙️ 세부설정`: 파장 범위($L_{min} \sim L_{max}$), 스텝수, 응력분포(압축/휨) 변경 모달
  - `📊 수치데이터`: 파장별 수치 테이블 조회 및 CSV 파일 내보내기

### 3.4 우측 분석 결과 대시보드 (Right Dashboard / 360px)
* **단면 기하학적 성질 (Gross Properties Table)**:
  - 총단면적 $A_g$, 단위중량 $\text{Weight}$, 단면2차모멘트 $I_x, I_y$, 단면2차반경 $r_x, r_y$
  - 주축회전각 $\theta_p$, 비틀림상수 $J$, 뒴상수 $C_w$, 전단중심 $X_0, Y_0$, 극단면2차반경 $r_0$
* **KDS 14 31 10 부재 내력 검토 카드 (Design Check & Gauges)**:
  - **축압축강도 (Compression)**: $\phi P_n$, D/C 게이지 바, 상태 뱃지 (OK / NG)
  - **휨모멘트강도 (Flexure X-X)**: $\phi M_n$, D/C 게이지 바, 상태 뱃지 (OK / NG)
  - **웨브 전단강도 (Shear)**: $\phi V_n$, D/C 게이지 바, 상태 뱃지 (OK / NG)
  - **P-M 조합응력 (Interaction)**: 상관비(Ratio), 조합응력 게이지 바, 최종 판정

---

## 4. 10대 전문 모달 다이얼로그 명세

| 모달 ID | 명칭 | 주요 기능 및 인터랙션 | 연동 파일 |
|---|---|---|---|
| `reportModal` | **A4 구조계산서 미리보기** | KDS 14 31 10 표준 A4 계산서 iframe 렌더링, `Ctrl+P` 인쇄 최적화 | [`routes.py`](file:///f:/PyProject/CFDesigner/src/api/routes.py) |
| `elementEditorModal` | **요소 스프레드시트 편집기** | 요소별 $X_0, Y_0, X_1, Y_1, L, \theta, t, R$ 표 편집, 행 추가/삭제, 재해석 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `rotateModal` | **임의 각도 단면 회전** | 사용자 지정 각도($\theta^\circ$) 및 도심($C_G$) 기준 회전 변환 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `insertRibsModal` | **중간 보강 리브 추가** | 대상 요소에 V형/사다리꼴 리브($w_r, d_r, \text{count}$) 파라메트릭 삽입 | [`geometry_editor.py`](file:///f:/PyProject/CFDesigner/src/geometry/geometry_editor.py) |
| `sectionLibraryModal` | **표준 단면 라이브러리** | SSMA, SFIA, AISI, LGSI, HUD 1,000+개 단면 검색, 2D 미니 프리뷰, 원클릭 로드 | [`library_parser.py`](file:///f:/PyProject/CFDesigner/src/geometry/library_parser.py) |
| `materialModal` | **재료 DB & 가공경화 계산기** | KS/ASTM 강종 프리셋, 코너 가공경화 유효항복강도($F_{ya}$) 자동 산정 및 적용 | [`library_parser.py`](file:///f:/PyProject/CFDesigner/src/geometry/library_parser.py) |
| `quickDesignModal` | **퀵 디자인 최적 단면 추천** | $P_u, M_u, V_u, L$ 입력 시 D/C $\le 1.0$ 만족 최경량 단면 자동 탐색 및 적용 | [`dsm.py`](file:///f:/PyProject/CFDesigner/src/design/dsm.py) |
| `fsmParamsModal` | **FSM 해석 세부 설정** | $L_{min}, L_{max}$, 스텝수(15~150), 응력형태(압축/강축휨/약축휨) 재해석 | [`fsm.py`](file:///f:/PyProject/CFDesigner/src/solver/fsm.py) |
| `fsmDataModal` | **FSM 수치 데이터 & CSV** | 파장별 $L, \beta, P_{cr}, M_{cr}$ 테이블 조회 및 원클릭 CSV 파일 다운로드 | [`app.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/app.js) |
| `effectiveModal` | **Winter 유효단면 해석** | 임의 응력 수준 $f$ 및 휨/압축 모드별 $A_e, I_{xe}, \Delta y$ 산정 및 2D 캔버스 표시 | [`effective_width.py`](file:///f:/PyProject/CFDesigner/src/geometry/effective_width.py) |
| `frameAnalysisModal` | **1D 구조해석 & 다이어그램** | 단순보/연속보/캔틸레버 지점·하중 설정, SFD/BMD/처짐 실시간 연산, 부재설계 연동 | [`frame1d.py`](file:///f:/PyProject/CFDesigner/src/solver/frame1d.py) |

---

## 5. 상세 UX(사용자 경험) 인터랙션 및 피드백 설계

### 5.1 2D CAD 캔버스 인터랙션 ([`canvas_2d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/canvas_2d.js))
- **마우스 휠 줌 (Zoom In/Out)**: 커서 위치를 중심으로 부드러운 스케일링 ($0.2\times \sim 15\times$).
- **드래그 이동 (Pan)**: 마우스 좌클릭 드래그로 뷰포트 자유 이동.
- **화면 맞춤 (Fit View)**: 캔버스 크기 및 단면 바운딩 박스를 계산하여 여백 20%를 포함한 최적 뷰 자동 정렬.
- **도심($C_G$), 전단중심($S_C$), 주축 렌더링**: 시각적 식별성을 위해 색상 및 기호 분리.
- **Winter 유효단면 오버레이**: 비유효 영역을 점선(Dashed Red Line)으로 표시하여 압축 좌굴에 따른 유효폭 감소 직관화.

### 5.2 3D 좌굴모드 WebGL 인터랙션 ([`viewer_3d.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/viewer_3d.js))
- **3D 궤도 제어 (OrbitControls)**: 좌클릭 회전, 우클릭 패닝, 휠 줌.
- **변형 애니메이션 (Buckling Oscillation)**: 사인파 기반 모드 변형 실시간 진동 애니메이션.
- **진폭 제어**: 슬라이더를 통해 과장 배율($1 \sim 40$)을 즉시 조정.
- **FSM 곡선 연동**: FSM 차트에서 모드 마커 클릭 시 해당 반파장과 고유벡터로 3D 형상 즉각 재구성.

### 5.3 1D 구조해석 $\rightarrow$ 부재설계 원클릭 데이터 파이프라인 UX
1. 사용자가 `1D 구조해석` 모달에서 지점 및 하중을 설정하고 `[⚡ 1D 구조해석 실행]` 클릭.
2. SFD, BMD, 처짐 곡선이 4단 스택 차트([`chart_diagrams.js`](file:///f:/PyProject/CFDesigner/src/web/static/js/chart_diagrams.js))로 즉각 렌더링.
3. `[⚡ 최대 부재력을 단면 부재설계로 연동하기]` 클릭 시:
   - $M_{max} \rightarrow M_{ux}$, $V_{max} \rightarrow V_u$, 경간 $L \rightarrow$ 비지지길이 $L$로 메인 사이드바에 즉시 주입.
   - 메인 D/C 대시보드가 자동으로 재계산되어 즉시 구조 안전성 검토 완료.

### 5.4 시각적 상태 피드백 및 컬러 토큰 시스템
* **D/C 내력비 게이지 색상 규칙**:
  - `D/C < 0.80`: **안전 (Safe)** $\rightarrow$ 그린 컬러 (`#10b981`)
  - `0.80 ≤ D/C ≤ 1.00`: **주의 (Warning)** $\rightarrow$ 황색 컬러 (`#f59e0b`)
  - `D/C > 1.00`: **위험/초과 (NG/Overstress)** $\rightarrow$ 적색 컬러 (`#ef4444`)
* **다크/라이트 모드 토큰 동기화**:
  - Dark Mode: 배경 `#0f172a`, 패널 `#1e293b`, 텍스트 `#f8fafc`
  - Light Mode: 배경 `#f8fafc`, 패널 `#ffffff`, 텍스트 `#0f172a`

---

## 6. 백엔드 REST API 엔드포인트 전수 명세

| 엔드포인트 | 메서드 | 설명 | 요청 본문 (Payload) | 반환 데이터 (Response) |
|---|---|---|---|---|
| `/api/section/wizard` | `POST` | 단면 마법사 생성 & 자동 해석 | `{ shape, H, B, C, t, R }` | 노드, 세그먼트, Gross 성질, FSM, D/C |
| `/api/section/upload-dxf` | `POST` | DXF 파일 업로드 및 자동 메싱 | Multipart Form Data (`.dxf`) | 폴리라인 세그먼트, 해석 결과 일체 |
| `/api/section/properties` | `POST` | 단면 기하학적 성질 산정 | `{ elements, t, r }` | $A_g, I_x, I_y, r_x, r_y, J, C_w, X_0, Y_0$ |
| `/api/section/transform` | `POST` | 단면 기하 변환 (회전/대칭/정렬) | `{ elements, op, angle, align_cg }` | 변환된 요소 배열 및 기하특성 |
| `/api/section/insert-ribs` | `POST` | 중간 보강 리브 삽입 | `{ elements, target_idx, rib_type, ... }` | 리브가 추가된 신규 요소 배열 |
| `/api/section/effective` | `POST` | Winter 식 기반 유효단면 산정 | `{ elements, f_stress, axis }` | $A_e, I_{xe}, \Delta y$, 유효 세그먼트 형상 |
| `/api/fsm/solve` | `POST` | FSM 탄성 좌굴해석 | `{ elements, t, L_min, L_max, steps }` | 파장별 $P_{cr}$, $P_{crl}, P_{crd}, P_{cre}$, 모드변위 |
| `/api/design/check` | `POST` | KDS 14 31 10 DSM 부재 내력 검토 | `{ props, fsm, length, Kx, Ky, Pu, Mu }` | $\phi P_n, \phi M_n, \phi V_n$, P-M 조합비, OK/NG |
| `/api/design/web-crippling`| `POST` | KDS 웨브 크리플링 지압 강도 | `{ condition, N, Ru, fastened, ... }` | $P_{nc}, \phi P_{nc}$, D/C, 적용 산정식 |
| `/api/design/quick-design` | `POST` | 퀵 디자인 최적 경량 단면 탐색 | `{ Pu, Mux, Vu, L, max_H, max_W, lib }` | 만족 단면 목록 (중량순 정렬, D/C 정보) |
| `/api/library/sections` | `GET` | 표준 단면 DB 목록 조회 | `?lib=SSMA&search=362S` | 규격 목록, 치수, 단면특성 |
| `/api/library/materials` | `GET` | 표준 강종 물성치 DB | - | KS/ASTM 강종 프리셋 리스트 |
| `/api/library/cold-work` | `POST` | 코너 가공경화 강도 증가 산정 | `{ elements, Fy, Fu, R }` | $F_{yc}$, 유효항복강도 $F_{ya}$, 증가율(%) |
| `/api/frame/solve` | `POST` | 1D 보/연속보 FEM 구조해석 | `{ spans, supports, loads, Ag, Ix, E }` | SFD, BMD, 처짐 데이터, $M_{max}, V_{max}$ |
| `/api/report/html` | `POST` | KDS A4 구조계산서 HTML 서빙 | 전체 해석 및 설계 모델 JSON | 렌더링된 A4 구조계산서 HTML 페이지 |
| `/api/manual/*` | `GET` | 온라인 도움말 TOC/토픽/검색 API | `topic_id`, `q` | 다국어 매뉴얼 본문 및 검색 결과 |
