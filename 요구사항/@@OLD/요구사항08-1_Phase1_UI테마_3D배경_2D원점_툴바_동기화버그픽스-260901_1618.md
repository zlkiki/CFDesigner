# [요구사항 08-1] Phase 1: 중앙 그래픽 영역 UI 테마(3D 배경, 2D 원점, 툴바) 동기화 버그 픽스

> **상위 마스터**: [`요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항08_UI테마_FSM응력구배_온라인도움말전수동기화_퀵디자인풀스펙이식.md)  
> **상태**: 🚀 `진행 중 (Active)`  
> **작성 일자**: 2026-09-01  
> **관련 파일**:
> - `src/web/static/js/viewer_3d.js`
> - `src/web/static/js/canvas_2d.js`
> - `src/web/static/css/style.css`
> - `src/web/static/js/app.js`

---

## 1. 구현 목표 (1이슈 단일 집중)

* **이슈 내용**: 테마(Dark $\leftrightarrow$ Light) 토글 시 3D 화면 배경이 어두운 색으로 유지되고, 2D 좌측 X-Y 원점 좌표계 원 내부 및 캔버스 툴바가 검은색으로 고정되는 결함 수정.
* **목표**: 테마 토글 즉시 3D Three.js 배경/그리드, 2D 원점 원 내부, 툴바 컨트롤 박스가 라이트/다크 테마에 100% 동기화되도록 조치.

---

## 2. 세부 개발 명세

1. **3D 뷰어 Three.js 테마 동기화 (`viewer_3d.js`)**:
   - `setTheme(theme)` 메서드 추가:
     - `light`: `scene.background = new THREE.Color(0xf8fafc)`, 그리드 색상 `0xcbd5e1`, `0xe2e8f0`
     - `dark`: `scene.background = new THREE.Color(0x0f172a)`, 그리드 색상 `0x334155`, `0x1e293b`
   - 조명(`DirectionalLight`, `AmbientLight`) 세기 및 그림자 대비 동적 보정.
2. **2D 캔버스 원점 좌표계 테마 동기화 (`canvas_2d.js`)**:
   - 좌측 하단 X-Y 원점 마커 렌더링 시 채우기 색상을 하드코딩된 다크 색상 대신 현재 테마(Light: `#ffffff`, Dark: `#1e293b`)로 분기 처리.
3. **캔버스 툴바 컨트롤 박스 스타일 (`style.css`)**:
   - `.canvas-toolbar`의 배경색(`var(--bg-secondary)`), 테두리(`var(--border-color)`), 버튼 아이콘 색상을 CSS 변수와 완전 연동하여 라이트 모드에서 검은 배경이 남지 않도록 교정.

---

## 3. 1:1 수용 기준 (Acceptance Criteria)

- [x] **AC 1-1**: 우측 상단 테마 토글 버튼 클릭 시 3D 뷰어 배경색이 라이트 모드(`0xf8fafc`)와 다크 모드(`0x0f172a`)로 즉시 동적 전환되는가?
- [x] **AC 1-2**: 라이트 모드에서 2D 캔버스 X-Y 원점 원 내부가 흰색 계열로 정상 표시되는가?
- [x] **AC 1-3**: 라이트 모드에서 2D/3D 캔버스 상단 툴바(확대, 축소, 리셋, 그리드) 박스가 검은색이 아닌 테마 CSS 변수에 맞게 밝은 카드로 표시되는가?
