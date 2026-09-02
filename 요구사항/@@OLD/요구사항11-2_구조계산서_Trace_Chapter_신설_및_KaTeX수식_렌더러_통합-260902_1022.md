# [요구사항 11-2] 구조계산서 Trace Chapter 신설 및 KaTeX 수식 렌더러 통합

> **요구사항 번호**: `요구사항11-2`  
> **상위 마스터**: [`요구사항11_구조계산서_상세계산과정_Trace수식전개_기준조항_완전이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항11_구조계산서_상세계산과정_Trace수식전개_기준조항_완전이식.md)  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 11-2)`  
> **작성 일자**: 2026-09-02  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs) (`rptMemberCheck`, `rptStrength`, `rptTrace`)
> - [`docs/12_structural_calculation_report_specification.md`](file:///f:/PyProject/CFDesigner/docs/12_structural_calculation_report_specification.md)

---

## 1. 작업 목적
`src/report/detailed_report.py` 및 `src/report/models.py`를 확장하여, 구조계산서 내에 **"제5장: 완전지지 단면 강도 및 Trace"**, **"제7장: KDS 14 31 10 부재 내력 검토 및 상세 Trace"**, **"제8장: 웨브 크리플링 및 조합응력 Trace"** 섹션을 KaTeX 수식 렌더러와 연동하여 정밀 수식 블록 형태로 렌더링합니다.

---

## 2. 세부 구현 범위
1. **리포트 옵션 및 데이터 모델 확장 (`src/report/models.py`)**:
   - `ReportOptions.include_trace_details: bool = True` 기본값 및 직렬화 지원.
   - `DesignTraceData` 모델 또는 딕셔너리 구조체 정의.
2. **DetailedReportGenerator Trace 수식 블록 고도화 (`src/report/detailed_report.py`)**:
   - `_render_ch5_fully_braced_strength`: 인장 항복/파단, 압축 Squash, 휨 항복/소성, 전단 항복 수식 및 Trace 로그를 KaTeX 블록(`$$ ... $$`) 및 단계별 박스로 구성.
   - `_render_ch7_member_design`: 축압축 좌굴($P_{ne}, P_{nl}, P_{nd}$), 휨 좌굴($M_{ne}, M_{nl}, M_{nd}$), P-M 상관식의 중간 대입식 및 D/C 비 수식 렌더링.
   - `_render_ch8_web_crippling`: 크리플링 $P_{nc}$ 및 휨-전단, 휨-크리플링 상관식 대입 수식 블록 수록.
3. **KaTeX 수식 렌더링 최적화**:
   - KaTeX CDN 및 수식 자동 렌더링 스크립트(`renderMathInElement`) 포함.
   - 인쇄 시 KaTeX 폰트 및 수식 깨짐 방지 CSS 스타일 적용.

---

## 3. 대상 파일 및 모듈
- **수정 파일**: [`src/report/detailed_report.py`](file:///f:/PyProject/CFDesigner/src/report/detailed_report.py), [`src/report/models.py`](file:///f:/PyProject/CFDesigner/src/report/models.py), [`src/report/html_report.py`](file:///f:/PyProject/CFDesigner/src/report/html_report.py)
- **테스트 파일**: [`tests/ui/test_report_generation.py`](file:///f:/PyProject/CFDesigner/tests/ui/test_report_generation.py)

---

## 4. 검증 기준 (Acceptance Criteria)
- [ ] **AC 11-2.1**: 상세 구조계산서 HTML 생성 시 KaTeX 수식 블록과 기준 조항이 포함된 Trace 섹션이 정상 삽입된다.
- [ ] **AC 11-2.2**: `ReportOptions(include_trace_details=False)` 시 간략 모드로 전환되며, `True` 시 모든 상세 수식이 출력된다.
- [ ] **AC 11-2.3**: `pytest tests/ui/test_report_generation.py` 테스트가 100% 통과한다.
