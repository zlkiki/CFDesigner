# [기술 문서 07] AltDP 스타일 웹 엔지니어링 애플리케이션 사양서 (07_altdp_web_app_specification.md)

---

## 1. 개요 및 시스템 목적

본 문서는 **CFDesigner (냉간성형강 비정형 단면 CAD 연동 구조해석 및 KDS/AISI 부재설계 시스템)**을 상용 CFS.exe(v14.0)의 모든 역공학 핵심 기능과 결합하여, **AltDP 특유의 세련되고 직관적인 엔지니어링 웹 SaaS 애플리케이션**으로 구축하기 위한 기술 명세 및 UI/UX 구조를 정의합니다.

---

## 2. 전체 시스템 아키텍처

```mermaid
graph TD
    subgraph Client ["클라이언트 계층 (AltDP 스타일 프론트엔드 Web UI)"]
        TopNav["상단 툴바 (프로젝트 저장/불러오기, 테마 토글, 리포트 출력)"]
        Sidebar["좌측 사이드바 (Section Wizard / DXF Import / Material / Member Design)"]
        Canvas2D["2D 단면 CAD 인터랙티브 뷰어 (HTML5 Canvas)"]
        ChartFSM["FSM 시그니처 커브 차트 (Chart.js)"]
        Viewer3D["3D 좌굴 모드형상 뷰어 (Three.js WebGL)"]
        DashDC["부재설계 내력비(D/C Ratio) 게이지 & 결과 카드"]
        ReportModal["A4 구조계산서 미리보기 & PDF 출력 모달"]
    end

    subgraph Server ["서버 계층 (FastAPI 고성능 비동기 백엔드)"]
        Router["REST API 엔드포인트 (/api/*)"]
        DXFMod["CAD DXF 파서 & 세그먼트 메셔 (ezdxf, shapely)"]
        GeomMod["단면 기하학적 성질 산정기 (Gross, Principal, Torsion)"]
        FSMMod["FSM 유한대판법 탄성 좌굴 솔버 (NumPy, SciPy)"]
        DSMMod["KDS 14 31 10 / AISI S100 부재설계기"]
        ReportMod["A4 구조계산서 HTML/CSS 템플릿 렌더러"]
    end

    Client <-->|비동기 REST API (JSON, 0.1s 이하)| Server
    Router --> DXFMod & GeomMod & FSMMod & DSMMod & ReportMod
```

---

## 3. 핵심 UI/UX 레이아웃 명세 (AltDP 스타일)

1. **상단 네비게이션 (Header Bar)**
   - 프로젝트 타이틀 및 상태 인디케이터
   - 단면 단위계 전환 (`mm`, `inch`)
   - 다크 모드 / 라이트 모드 실시간 토글
   - **[A4 구조계산서 출력]** 버튼
2. **좌측 컨트롤 패널 (Sidebar / 320px)**
   - **Tab 1: 단면 생성 (Section Modeling)**:
     - 단면 마법사 (C형강, Z형강, 모자형, 데크, 각형강관 등 파라메트릭 입력)
     - DXF 드래그 & 드롭 업로더
     - 강종 선택 (SS275, SM355, A36, A653 등 $F_y, E, \nu$)
   - **Tab 2: 부재설계 조건 (Member Parameters)**:
     - 부재 길이 ($L_x, L_y, L_t$), 유효좌굴길이계수 ($K_x, K_y, K_t$)
     - 설계 외력 입력 ($P_u, M_{ux}, M_{uy}, V_{ux}, V_{uy}$)
     - 모멘트 구배계수 ($C_b, C_{mx}, C_{my}$)
3. **중앙 작업 영역 (Main Workspace / 2-Row Split)**
   - **상단: 2D 단면 인터랙티브 CAD 뷰어 & 3D 좌굴 모드 뷰어 (탭 전환)**
     - 2D: 노드, 세그먼트 번호, 두께 외곽선, 도심($C_G$), 전단중심($S_C$), 주축($X_1-X_2$) 오버레이, 마우스 휠 줌/팬
     - 3D: Three.js 기반 길이방향 좌굴 모드 형상 3D 렌더링, 와이어프레임 & 응력 등고선 애니메이션
   - **하단: FSM 탄성 좌굴 시그니처 커브 (Signature Curve)**
     - 반파장 길이($L$) vs 좌굴하중($P_{cr}$) 반응형 그래프
     - 국부 좌굴(Local, $P_{crl}$), 왜곡 좌굴(Distortional, $P_{crd}$), 전체 좌굴(Global, $P_{cre}$) 최소점 마커 및 클릭 시 해당 모드 3D 뷰어 자동 동기화
4. **우측 분석 결과 대시보드 (Right Panel / 360px)**
   - **단면 특성치 카드**: $A, I_x, I_y, r_x, r_y, J, C_w, x_o, y_o, \beta_w, I_1, I_2, \alpha$
   - **KDS 14 31 10 부재 검토 카드**:
     - 축압축 강도 ($P_n, \phi P_n, P_u/\phi P_n$)
     - 휨모멘트 강도 ($M_{nx}, M_{ny}, \phi M_n, M_u/\phi M_n$)
     - 전단 및 크리플링 강도 ($V_n, P_{nc}$)
     - P-M 조합응력 게이지 바 및 최종 판정 (OK / NG)
5. **A4 구조계산서 모달 (Report Master)**
   - 표준 A4 엔지니어링 계산서 포맷
   - 단면 기하도, FSM 좌굴곡선, 설계 수식, 안전율/내력비 테이블 포함
   - 브라우저 인쇄(`Ctrl+P`) 및 PDF 내보내기 최적화

---

## 4. REST API 명세서

| 엔드포인트 | 메서드 | 설명 | 요청 데이터 | 응답 데이터 |
|---|---|---|---|---|
| `/api/section/wizard` | `POST` | 단면 마법사로 단면 생성 | 단면 타입, 치수(H, B, C, t, R) | 노드/세그먼트 좌표, 두께 |
| `/api/section/upload-dxf` | `POST` | CAD DXF 파일 업로드 & 파싱 | `.dxf` 파일 | 파싱된 폴리라인, 두께, 메쉬 |
| `/api/section/properties` | `POST` | 단면 기하학적 성질 산정 | 노드, 세그먼트 데이터 | $A, I, r, J, C_w, x_o, y_o, \alpha$ 등 |
| `/api/fsm/solve` | `POST` | FSM 좌굴해석 및 시그니처 커브 | 노드, 두께, 하중 형태, 파장 범위 | $L$별 $P_{cr}$, $P_{crl}, P_{crd}, P_{cre}$, 3D 변위장 |
| `/api/design/check` | `POST` | KDS 14 31 10 DSM 부재 강도 검토 | 단면성질, FSM좌굴하중, 부재길이, 하중 | $P_n, M_n, V_n, P_{nc}$, D/C 비율, OK/NG |
| `/api/report/html` | `POST` | A4 구조계산서 HTML 렌더링 | 전체 해석 및 설계 결과 객체 | 렌더링된 A4 구조계산서 HTML |

---

## 5. 단계별 개발 일정 및 마일스톤

- **Phase 1**: FastAPI 백엔드 API 라우터 구축 및 기존 수치해석 엔진 연동 (완료 검증)
- **Phase 2**: AltDP 스타일 HTML/CSS/JS 프론트엔드 UI 구축 (2D Canvas, 3D Three.js, Chart.js)
- **Phase 3**: KDS 14 31 10 맞춤형 A4 구조계산서 렌더러 및 리포트 출력 기능 완성
- **Phase 4**: 엔드투엔드 통합 테스트 및 브라우저 E2E 무결성 검증
