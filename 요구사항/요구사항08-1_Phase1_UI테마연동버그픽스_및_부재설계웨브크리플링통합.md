# [요구사항 08-1] Phase 1: 중앙 그래픽 영역 UI 테마 연동 버그픽스 및 부재설계-웨브크리플링 통합

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **관련 파일**:
> - `src/web/static/js/viewer_3d.js`
> - `src/web/static/js/canvas_2d.js`
> - `src/web/static/css/style.css`
> - `src/web/static/js/app.js`
> - `src/web/index.html`

---

## 1. 구현 목표

1. **중앙 그래픽 영역의 테마(Light/Dark) 토글 버그를 100% 수정**하여, 테마 변경 시 3D 화면 배경, 2D 원점 원 내부, 도구박스(Toolbar)가 즉시 동기화되도록 조치.
2. **좌측 제어패널의 부재설계(P-M 조합)와 웨브 크리플링(Web Crippling) UI를 단일 일원화 구조로 통합**하여 설계 편의성을 극대화.

---

## 2. 세부 개발 명세

### 2.1 3D 좌굴모드 뷰어 테마 연동 (`viewer_3d.js`)
* **Three.js 배경색 동적 전환**:
  - `setTheme(theme)` 메서드 추가: `theme === 'light'`일 때 `scene.background = new THREE.Color(0xf8fafc)`, `dark`일 때 `0x0f172a`.
  - 바닥 그리드(`GridHelper`) 색상: Light 모드 시 밝은 회색(`0xcbd5e1`, `0xe2e8f0`), Dark 모드 시 어두운 색(`0x334155`, `0x1e293b`).
  - 조명(`AmbientLight`, `DirectionalLight`) 밝기 동적 보정.

### 2.2 2D 단면도 캔버스 테마 연동 (`canvas_2d.js`, `style.css`)
* **X-Y 원점 좌표계 원 내부 배경색**:
  - 캔버스 원점 마커 렌더링 시 현재 활성 테마 색상(`getComputedStyle` 또는 `app.theme`)을 참조하여 원 내부 채우기 색상(Light: `#ffffff`, Dark: `#1e293b`) 자동 전환.
* **캔버스 도구박스(Toolbar) 스타일**:
  - `.canvas-toolbar` 배경색 및 테두리를 CSS 변수(`var(--bg-secondary)`, `var(--border-color)`)로 바인딩하여 Light 모드 시 깔끔한 화이트/슬레이트 배경 유지.

### 2.3 부재설계 & 웨브 크리플링 UI 통합 (`index.html`, `app.js`)
* **좌측 패널 설계 섹션 일원화**:
  - `[부재 내력 검토 (P-M)]`과 `[웨브 크리플링 (Web Crippling)]`을 서브 탭 또는 아코디언 카드 일원화 레이아웃으로 통합.
  - 상단 설계 조건(강종, 부재길이, 하중 $P_u, M_{ux}, M_{uy}, V_u$) 입력 시 웨브 크리플링 소요 지압력($P_{wc} = V_u$) 자동 연계.
  - 종합 안전율(D/C Ratio) 게이지에 축력, 휨, 전단, 크리플링 4대 핵심 지표를 통합 시각화.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [ ] **AC 1-1**: 우측 상단 테마 토글(Dark $\leftrightarrow$ Light) 클릭 시 3D 좌굴모드 뷰어의 배경색이 즉시 라이트/다크로 전환되는가?
- [ ] **AC 1-2**: 2D 단면도 캔버스의 X-Y 원점 원 및 캔버스 툴바 컨트롤 박스가 라이트 모드에서 검은색으로 남지 않고 정상 전환되는가?
- [ ] **AC 1-3**: 좌측 부재설계 패널 내에서 부재력 검토와 웨브 크리플링이 분리되지 않고 하나의 통합 탭/패널에서 직관적으로 검토되는가?
