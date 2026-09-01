# [요구사항 07-1] Phase 1: 간략 요약 보고서 vs 정식 상세 계산서 이원화 및 인쇄 선택 UI 구축

> **문서 상태**: 🚀 **활성 진행 과제 (Phase 1)**  
> **상위 마스터 요구사항**: [`요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항07_구조계산서_고도화_및_CFS_원본리포트_전수이식.md)  
> **관련 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs) (`rptHeading`, `rptTitle`, `AppendRTF`)
> - [`decompiled_src/RSG/CFS/PrintRoutines.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/PrintRoutines.cs) (`PrintHeader`, `PrintFooter`, `InitializePage`)
> - [`decompiled_src/_Global/frmPrint.cs`](file:///f:/PyProject/CFDesigner/_Global/frmPrint.cs) (`lstPrint`, `cmdSelectAll`, `cmdUnselectAll`, `cmdHeading`)

---

## 1. Phase 목표 및 배경

1. **리포트 듀얼 모드(Dual Mode) 시스템 구축**:
   - 기존의 단일 페이지 계산서를 **"간략 요약 보고서 (Summary / Quick Report)"**로 리팩토링하고,
   - 다중 페이지 실무 제출용 **"정식 상세 구조계산서 (Detailed Engineering Calculation Sheet)"** 파이프라인의 기반 아키텍처를 신설.
2. **`frmPrint` 대응 모던 웹 인쇄 설정 모달 UI 개발**:
   - 보고서 모드 전환 탭(간략 보고서 vs 상세 계산서).
   - 계산서 수록 항목 다중 선택 체크박스 (전체 선택/해제, 개별 항목 온/오프).
   - 프로젝트 메타데이터 및 엔지니어링 결재란(Review/Approval Block) 설정 패널.
3. **A4 표준 페이지네이션 & 헤더/푸터/결재란 프레임워크 구현**:
   - A4 인쇄 규격 CSS(`@page`, `@media print`, `page-break`).
   - 머리말(회사 로고, 프로젝트명, 부재명, 문서번호) 및 꼬리말(페이지 번호 `Page X of Y`, 출력일시).
   - 표준 엔지니어링 결재란(작성자, 검토자, 승인자, 날짜).
4. **SVG 엔지니어링 그래픽 생성기 기반 모듈화**:
   - 단면 형상 SVG에 치수선, 판 두께(t), 도심(CG: 빨강), 전단중심(SC: 파랑), 주축 1-2(녹색 파선) 오버레이 고도화.

---

## 2. 세부 구현 요구사항

### 2.1 백엔드 리포트 아키텍처 재편 (`src/report/`)
1. **모듈 분리**:
   - `src/report/models.py`: 리포트 설정 및 메타데이터 데이터클래스 (`ReportOptions`, `ProjectMetadata`, `ApprovalBlock`).
   - `src/report/summary_report.py`: 1~2페이지 간략 요약 보고서 HTML 렌더러.
   - `src/report/detailed_report.py`: 다중 페이지 상세 구조계산서 베이스 HTML 프레임워크 렌더러.
   - `src/report/svg_diagrams.py`: 고품질 SVG 단면도, 축계도, 마커 렌더링 모듈.
2. **API 엔드포인트 확장 (`src/api/routes.py`)**:
   - `POST /api/report/summary`: 간략 요약 보고서 HTML 생성.
   - `POST /api/report/detailed`: 사용자 지정 옵션이 반영된 정식 상세 구조계산서 HTML 생성.
   - 요청 Body에 `options` (선택된 섹션 목록), `project_meta` (프로젝트명, 부재명, 작성자, 검토자, 회사정보 등) 수용.

---

### 2.2 프론트엔드 인쇄 설정 모달 UI (`src/web/`)
1. **리포트 모달 상단 툴바 개선 (`src/web/index.html` & `src/web/static/js/app.js`)**:
   - **모드 전환 세그먼트 버튼**: `[ 📋 간략 요약 보고서 ]` / `[ 📑 정식 상세 구조계산서 ]`
   - **설정 버튼**: `⚙️ 계산서 옵션 및 결재란 설정`
   - **액션 버튼**: `🖨️ 인쇄 / PDF 저장`, `📥 HTML 다운로드`, `✕ 닫기`
2. **인쇄 옵션 설정 패널 (`frmPrint` 대응)**:
   - **프로젝트 및 결재란 입력 폼**:
     * 프로젝트명 (Project Name)
     * 부재명 / 부재번호 (Member / Section ID)
     * 작성자 (Designed / Drawn By)
     * 검토자 (Checked By)
     * 승인자 (Approved By)
     * 회사명 (Company) 및 비고 (Remarks)
   - **수록 항목 체크박스 그룹**:
     * [전체 선택 (Select All)] / [전체 해제 (Unselect All)] 버튼
     * ☑️ 1. 단면 기하형상 및 요소 명세표 (Section Geometry & Elements)
     * ☑️ 2. 단면 기하학적 성질 (Gross & Net Properties)
     * ☑️ 3. 비틀림 및 뒴 특성 (Torsion & Warping)
     * ☑️ 4. 유효단면 성질 및 유효폭 (Effective Properties)
     * ☑️ 5. 완전지지 부재강도 (Fully Braced Strength)
     * ☑️ 6. FSM 탄성 좌굴해석 (Elastic Buckling & DSM)
     * ☑️ 7. KDS 14 31 10 부재 내력 검토 (Member Design Checks)
     * ☑️ 8. 웨브 크리플링 검토 (Web Crippling Check)
     * ☑️ 9. 1D 구조해석 및 단면력도 (1D Analysis & Diagrams)
3. **실시간 미리보기 연동**:
   - 옵션 변경 시 `iframe`에 즉시 반영되어 실시간으로 업데이트된 계산서를 미리보기 제공.

---

### 2.3 A4 인쇄 스타일 및 페이징 CSS 최적화
1. **A4 Portrait 인쇄 규격**:
   ```css
   @page {
     size: A4 portrait;
     margin: 15mm 15mm 15mm 15mm;
   }
   @media print {
     body { background: white; margin: 0; padding: 0; }
     .sheet-page {
       width: 100%;
       min-height: auto;
       margin: 0;
       padding: 0;
       box-shadow: none;
       page-break-after: always;
     }
     .no-print { display: none !important; }
   }
   ```
2. **반복 머리말/꼬리말 및 결재란**:
   - 각 페이지 상단: 좌측(프로젝트명/부재명), 우측(CFDesigner KDS 14 31 10).
   - 각 페이지 하단: 좌측(출력일시), 우측(Page X of Y).
   - 첫 페이지 상단: 표준 3단 엔지니어링 결재란(작성 / 검토 / 승인).

---

## 3. 검증 기준 (Acceptance Criteria)

- [x] **AC 7-1-1**: 리포트 모달에서 [간략 요약 보고서]와 [정식 상세 구조계산서] 탭 전환이 부드럽게 작동할 것.
- [x] **AC 7-1-2**: 인쇄 설정 패널에서 프로젝트명, 부재명, 작성자/검토자/승인자 입력 값이 계산서 표지 및 결재란에 정확히 반영될 것.
- [x] **AC 7-1-3**: 출력 항목 체크박스 선택/해제에 따라 해당 섹션이 계산서에서 동적으로 추가/제외될 것.
- [x] **AC 7-1-4**: 브라우저 인쇄(`Ctrl+P` 또는 인쇄 버튼 클릭) 시 A4 규격에 맞추어 페이지 나눔이 깔끔하게 이루어질 것.
- [x] **AC 7-1-5**: `pytest tests/test_report.py` 및 관련 테스트가 100% 통과할 것.
