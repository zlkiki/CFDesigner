# [요구사항 05-2] Phase 5-2: 마법사 단계별 튜토리얼 & 실무 예제(Walkthrough) 전수 이식

> **문서 상태**: 🚀 **활성 진행 과제 (Phase 5-2)**  
> **상위 마스터 문서**: [`요구사항05_레거시_UI도해_및_실무예제_전수이식.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항05_레거시_UI도해_및_실무예제_전수이식.md)  
> **관련 기술 문서 (SSOT)**:
> - [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)
> - [`docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md`](file:///f:/PyProject/CFDesigner/docs/09_cfs_legacy_help_manual_vs_web_gap_analysis.md)

---

## 1. 개요 및 구현 목표
원본 CFS 14.0 도움말의 **단면 마법사 2단계(`section-wizard-1, 2.htm`)**, **1D 구조해석 마법사 4단계(`analysis-wizard-1 ~ 4.htm`)**, 그리고 **AutoCAD DXF Auto-Meshing 실무 가이드(`import-dxf.htm`)**의 단계별 튜토리얼 예제(Walkthrough)를 웹 매뉴얼에 전수 이식합니다.

---

## 2. 작업 상세 내용

1. **단면 생성 마법사 실무 튜토리얼 (`wizard`)**:
   - 원본 `section-wizard-1.htm`, `section-wizard-2.htm`의 2단계 워크플로우 이식:
     - 1단계: 6대 기본 단면형상(C, Z, Hat, Deck, Tube, Angle) 선택 및 파라메터 특성
     - 2단계: 웹 높이($H$), 플랜지 폭($B$), 립 길이($D$) 및 립 각도($\theta$), 코너 내부 반경($R$) 설정 실무 팁과 유효성 검증 규칙
2. **1D 구조해석 마법사 4단계 실무 튜토리얼 (`analysis_wizard`)**:
   - 원본 `analysis-wizard-1.htm` ~ `4.htm`의 4단계 워크플로우 전수 이식:
     - **1단계 (경간 Span)**: 단순보/2~3경간 연속보/캔틸레버 경간 길이 및 분할 설정
     - **2단계 (지점 및 부재)**: 핀(Pinned), 롤러(Roller), 고정(Fixed) 지점 조건 및 단면 라이브러리 할당
     - **3단계 (하중 Loadings)**: 전 경간 균일분포하중($w$), 절점 집중하중($P$), 외력 모멘트($M$) 입력법
     - **4단계 (하중조합 Combinations)**: LRFD(1.2D + 1.6L) / ASD(D + L) 조합 생성 및 해석 실행
3. **DXF Auto-Meshing 실무 가이드 (`dxf_import`)**:
   - 원본 `import-dxf.htm` 기반: AutoCAD 폴리라인 중심선 작도, 곡선 호(Arc) 세그먼트 분할 오차 제어 및 일괄 두께 지정 실무 가이드 보강.

---

## 3. 세부 파일별 변경 계획

| 파일 경로 | 변경 내용 |
|---|---|
| [`src/web/manual/topics.py`](file:///f:/PyProject/CFDesigner/src/web/manual/topics.py) | `wizard`, `analysis_wizard`, `dxf_import` 토픽에 단계별 튜토리얼 예제(한·영 병기) 수록 |
| [`tests/test_manual_api.py`](file:///f:/PyProject/CFDesigner/tests/test_manual_api.py) | 마법사 단계별 튜토리얼 키워드 및 예제 수록 여부 검증 테스트 추가 |

---

## 4. Acceptance Criteria (수용 기준)

- [ ] **AC 5-2-1**: `wizard` 토픽에 단면 마법사 1~2단계 튜토리얼(C/Z형강 립 및 코너 R 설정법)이 한·영 병기로 수록될 것.
- [ ] **AC 5-2-2**: `analysis_wizard` 토픽에 1D 해석 마법사 1~4단계(경간 $\rightarrow$ 지점 $\rightarrow$ 하중 $\rightarrow$ 조합) 실무 예제가 한·영 병기로 수록될 것.
- [ ] **AC 5-2-3**: `dxf_import` 토픽에 폴리라인 중심선 및 호 분할 오차 제어 실무 가이드가 보강될 것.
- [ ] **AC 5-2-4**: `pytest tests/test_manual_api.py`가 100% 통과할 것.
