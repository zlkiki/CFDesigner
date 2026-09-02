# [요구사항 15-5] Phase 5: 4대 시나리오 E2E 통합검증 및 회귀테스트

> **문서 상태**: 🚀 작업 대기 (Ready for Implementation)  
> **상위 요구사항**: [`요구사항15_엔지니어링_워크플로우_가이드UI_및_목적기반_UX파이프라인_구축.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항15_엔지니어링_워크플로우_가이드UI_및_목적기반_UX파이프라인_구축.md)  
> **대상 파일**:
> * `tests/ui/test_workflow_pipeline.py` (5단계 워크플로우 Stepper 및 프리셋 전환 검증)
> * `tests/ui/test_quick_start_launcher.py` (4대 목적 런처 라우팅 검증)
> * `tests/ui/test_smart_assistant.py` (상태 머신 및 스마트 액션 트리거 검증)
> * `tests/ui/test_delivery_hub.py` (Step 5 성과물 내보내기 검증)

---

## 1. 개요 및 목표

* 새롭게 구축된 5단계 가이드 워크플로우 Stepper, 퀵 스타트 런처, 스마트 어시스턴트, 성과물 딜리버리 허브의 전체 사용자 여정(User Journey)을 E2E 단위/통합 테스트로 전수 검증합니다.
* 기존의 단면 기하, FSM 수치해석, KDS DSM 부재설계, 온라인 도움말 등 86개 이상의 전체 Pytest 테스트 슈트가 100% 무결하게 통과함을 입증합니다.

---

## 2. 세부 테스트 항목

### 2.1. 4대 작업 시나리오 E2E 파이프라인 검증
1. **시나리오 1 (표준 단면 설계 플로우)**:
   * 퀵 스타트 [표준 단면] $\rightarrow$ Step 1 C-Shape 파라메트릭 빌드 $\rightarrow$ Step 2 Gross/유효단면 확인 $\rightarrow$ Step 3 FSM 좌굴해석 완료 $\rightarrow$ Step 4 KDS 부재설계 통과 $\rightarrow$ Step 5 A4 계산서 출력
2. **시나리오 2 (비정형 DXF 임포트 플로우)**:
   * 퀵 스타트 [DXF 임포트] $\rightarrow$ 폴리라인 자동 메싱 $\rightarrow$ Step 2 성질 산정 $\rightarrow$ Step 3 다중 모드 좌굴 $\rightarrow$ Step 5 DXF 및 PDF 내보내기
3. **시나리오 3 (목표하중 퀵 디자인 역설계 플로우)**:
   * 퀵 스타트 [역설계] $\rightarrow$ 하중/경간 입력 $\rightarrow$ 3열 최적 단면 선택 $\rightarrow$ Step 4 D/C 검토 $\rightarrow$ Step 5 요약표 클립보드 복사
4. **시나리오 4 (1D 보 연속보 구조해석 플로우)**:
   * 퀵 스타트 [1D 보 해석] $\rightarrow$ 2경간 연속보 마법사 $\rightarrow$ SFD/BMD 산출 $\rightarrow$ 부재설계 연동

### 2.2. 전체 회귀 테스트 실행
* `pytest tests/engine/` (엔진 계층 무결성)
* `pytest tests/ui/` (UI/API 계층 무결성)
* `pytest tests/manual/` (도움말 계층 무결성)
* `pytest` (전체 테스트 100% 통과 확인)

---

## 3. 수용 기준 및 검증 체크리스트 (Acceptance Criteria)

- [ ] 신규 작성된 워크플로우 및 런처 관련 Pytest 테스트가 100% 통과하는가?
- [ ] 4대 엔지니어링 작업 시나리오가 끊김 없이 Step 1부터 Step 5까지 자연스럽게 완결되는가?
- [ ] 전체 Pytest 테스트(86개+)에 단 1건의 실패나 회귀 결함도 없는가?
