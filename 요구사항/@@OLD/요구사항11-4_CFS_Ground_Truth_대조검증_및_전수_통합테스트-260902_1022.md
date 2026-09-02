# [요구사항 11-4] CFS Ground Truth 대조검증 및 전수 통합 테스트

> **요구사항 번호**: `요구사항11-4`  
> **상위 마스터**: [`요구사항11_구조계산서_상세계산과정_Trace수식전개_기준조항_완전이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항11_구조계산서_상세계산과정_Trace수식전개_기준조항_완전이식.md)  
> **상태**: 🚀 `계획 완료 및 대기 (Phase 11-4)`  
> **작성 일자**: 2026-09-02  
> **원본 레퍼런스 (Ground Truth)**:
> - [`decompiled_src/RSG/CFS/Section.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Section.cs)
> - [`decompiled_src/RSG/CFS/Report.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/RSG/CFS/Report.cs)
> - [`docs/12_structural_calculation_report_specification.md`](file:///f:/PyProject/CFDesigner/docs/12_structural_calculation_report_specification.md)

---

## 1. 작업 목적
표준 C형강(SSMA 600S162-54) 및 Z형강 등 실제 CFS 예제 단면에 대해 원본 `CFS.strTrace` 출력값과 신규 웹 엔진의 Trace 계산 수치를 1:1 대조하여 오차 0.1% 미만의 무결성을 교차 검증하고, 전체 80개 이상의 Pytest 통합 테스트 스위트를 100% 통과하여 작업을 완결합니다.

---

## 2. 세부 구현 범위
1. **표준 단면 CFS Ground Truth 1:1 교차 검증**:
   - SSMA C형강(600S162-54) 인장, 압축($P_{ne}, P_{nl}, P_{nd}$), 휨($M_{ne}, M_{nl}, M_{nd}$), 전단($V_n$), 크리플링($P_{nc}$), P-M 상관식 계산 결과 및 Trace 로그 대조.
   - 오차 0.1% 미만 및 기준 조항 번호 100% 일치 확인.
2. **신규 단위/통합 테스트 스위트 작성**:
   - `tests/engine/test_kds_trace_engine.py` (Trace 엔진 전용 테스트)
   - `tests/ui/test_report_generation.py` (Trace 수식 렌더링 및 옵션 테스트 보강)
3. **전수 Pytest 무결성 확인**:
   - `pytest tests/engine/`, `pytest tests/ui/`, `pytest tests/manual/` 및 전체 `pytest` 무결성 검증.
4. **기술 문서 동기화**:
   - `docs/12_structural_calculation_report_specification.md` 최신화.
   - `docs/15_요구사항11_구조계산서_Trace_전수검증_보고서.md` 작성.

---

## 3. 대상 파일 및 모듈
- **신규/수정 문서**: [`docs/12_structural_calculation_report_specification.md`](file:///f:/PyProject/CFDesigner/docs/12_structural_calculation_report_specification.md), [`요구사항/요구사항11_구조계산서_Trace_전수검증_보고서.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항11_구조계산서_Trace_전수검증_보고서.md)

- **테스트 파일**: [`tests/engine/test_kds_trace_engine.py`](file:///f:/PyProject/CFDesigner/tests/engine/test_kds_trace_engine.py), [`tests/ui/test_report_generation.py`](file:///f:/PyProject/CFDesigner/tests/ui/test_report_generation.py)

---

## 4. 검증 기준 (Acceptance Criteria)
- [ ] **AC 11-4.1**: 원본 CFS 계산치 대비 신규 Trace 엔진의 수치 오차가 0.1% 미만임을 입증한다.
- [ ] **AC 11-4.2**: 전체 Pytest 테스트(80개 이상)가 100% 통과(0 failure, 0 error)한다.
- [ ] **AC 11-4.3**: 기술 문서 및 검증 보고서가 최신 상태로 동기화된다.
