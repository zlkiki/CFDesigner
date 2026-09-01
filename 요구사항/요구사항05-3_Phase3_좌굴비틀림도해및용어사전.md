# [요구사항 05-3] Phase 5-3: 비틀림/좌굴 모드 그래픽 해설 & 용어사전/기호집 전수 통합

> **문서 상태**: 🚀 **활성 진행 과제 (Phase 5-3)**  
> **상위 마스터 문서**: [`요구사항05_레거시_UI도해_및_실무예제_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항05_레거시_UI도해_및_실무예제_전수이식.md)  
> **관련 기술 문서 (SSOT)**:
> - [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)
> - [`docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md)

---

## 1. 개요 및 구현 목표
원본 CFS 14.0 도움말의 **FSM 좌굴 모드 4대 도해(`buckling-results.htm`)**, **비틀림 좌표계 및 모멘트 선도 4대 도해(`torsion-analysis.htm`, `torsion-diagrams.htm`)**, 그리고 **전문 용어사전(`glossary.htm`, 18,663자)** 및 **공학 기호집(`symbols.htm`, 6,673자)**을 웹 도움말 시스템에 전수 이식·통합합니다.

---

## 2. 작업 상세 내용

1. **FSM 좌굴 모드 및 3D 형상 그래픽 해설 (`buckling_modes`, `signature_curve`)**:
   - `buckle-profile.png`, `buckle-shape.png`, `buckle-shapes.png`, `buckle-renders.png` 4종 도해 수록.
   - 반파장($L$) 스펙트럼 곡선과 결합하여 국부 좌굴($P_{crl}$), 왜곡 좌굴($P_{crd}$), 전체 좌굴($P_{cre}$)의 단면 변형 형상 판별법 심화 해설.
2. **비틀림 및 뒤틀림 해석 그래픽 해설 (`torsion_props`)**:
   - `torsion-section1.png`, `torsion-section2.png`, `torsion-direction.png`, `torsion-diagrams.png` 4종 도해 수록.
   - 전단중심($x_0, y_0$), 뒴상수($C_w$), 생브낭 비틀림($J$), 비틀림 회전각 및 바이모멘트($B$) 방향성 기준 해설.
3. **공학 기호집 & 1.8만자 전문 용어사전 통합 (`src/web/manual/topics.py`)**:
   - 원본 `glossary.htm`(18,663자) A~Z 전문 용어사전 및 `symbols.htm`(6,673자) 공학 기호/약어집을 데이터셋으로 통합.
   - 웹 도움말 목차(TOC)에 '부록: 전문 용어사전 & 공학 기호집' 섹션을 추가하고, 다국어 실시간 검색 엔진과 연동.

---

## 3. 세부 파일별 변경 계획

| 파일 경로 | 변경 내용 |
|---|---|
| [`src/web/manual/topics.py`](file:///f:/PyProject/CFDesigner/src/web/manual/topics.py) | `buckling_modes`, `signature_curve`, `torsion_props` 도해 수록 및 `glossary`, `symbols` 토픽 전수 확충 |
| [`src/web/manual.html`](file:///f:/PyProject/CFDesigner/src/web/manual.html) | 목차 트리에 용어사전 및 기호집 부록 뱃지 추가 |
| [`tests/test_manual_api.py`](file:///f:/PyProject/CFDesigner/tests/test_manual_api.py) | 좌굴/비틀림 도해 태그 검증 및 용어사전/기호집 검색/조회 API 단위 테스트 추가 |

---

## 4. Acceptance Criteria (수용 기준)

- [ ] **AC 5-3-1**: `buckling_modes`, `signature_curve`에 좌굴 모드 4대 도해(`buckle-*.png`)가 수록되고 판별법이 기술될 것.
- [ ] **AC 5-3-2**: `torsion_props`에 비틀림 좌표계 4대 도해(`torsion-*.png`)가 수록되고 수식 해설이 기술될 것.
- [ ] **AC 5-3-3**: 원본 18,663자 용어사전 및 6,673자 기호집이 `glossary`, `symbols` 토픽으로 웹에 통합되고 다국어 검색될 것.
- [ ] **AC 5-3-4**: `pytest tests/test_manual_api.py` 및 전체 테스트 suite가 100% 통과할 것.
