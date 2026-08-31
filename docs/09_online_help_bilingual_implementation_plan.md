# [구현계획서] 온라인 도움말 영문 원문 병기 및 대조/토글 UI 개선 (요구사항 03)

> **문서 번호**: PLAN-03  
> **관련 요구사항**: [`요구사항/요구사항03_온라인_도움말_영문_원문_병기_및_토글_UI_개선.md`](file:///f:/PyProject/CFDesigner/요구사항/요구사항03_온라인_도움말_영문_원문_병기_및_토글_UI_개선.md)  
> **기술 명세서**: [`docs/08_online_help_manual_specification.md`](file:///f:/PyProject/CFDesigner/docs/08_online_help_manual_specification.md)  
> **작성 일시**: 2026-08-31  

---

## 1. 구현 목표 및 범위
사용자가 공학적 번역 오류나 용어 해석 차이를 우려하지 않고 언제든 원문(Original English Text)을 손쉽게 확인할 수 있도록, 다음 5대 핵심 기능을 완결성 있게 구축한다:

1. **15개 토픽 영문 원문 데이터셋 매핑 (`topics.py`)**: `title_en`, `summary_en`, `content_en_html`
2. **3-Way 글로벌 뷰 전환 스위처 (`manual.html`, `manual.js`)**: `[🇰🇷 한글]` / `[🌐 한-영 2열 대조 (Split)]` / `[🇺🇸 English]`
3. **단락/섹션별 인라인 원문 토글 (Accordion)**: 한글 뷰 모드에서 각 블록 옆 `[🌐 원문보기]` 버튼 클릭 시 원문 인라인 카드 펼침
4. **전문 공학 용어 호버 툴팁 (Term Tooltip & Peek)**: 용어 호버 시 원문 및 영문 정의 팝오버 표시
5. **다국어 통합 검색 & KaTeX 수식 양방향 렌더링**: 영문 키워드로도 토픽 검색 가능, 다크/라이트 테마 최적화

---

## 2. 세부 모듈별 아키텍처 및 구현 계획

### 2.1 데이터 계층 (`src/web/manual/topics.py`)
- 4대 카테고리 15개 전체 토픽에 다음 필드 추가:
  - `title_en`: 영문 토픽 제목
  - `summary_en`: 영문 토픽 요약
  - `content_en_html`: AISI S100 / CFS 레거시 기술문헌 기반 영문 원문 HTML
- 한글 `content_html` 내부에 인라인 토글 박스(`inline-en-box`)와 툴팁 타깃 태그(`glossary-term`) 구성.

### 2.2 백엔드 API 계층 (`src/api/manual_routes.py`)
- `GET /api/manual/topic/{topic_id}`: 영문 원문 필드 추가 반환
- `GET /api/manual/search`: 영문 텍스트(`title_en`, `summary_en`, `content_en_html`)도 검색 대상에 포함하여 다국어 검색 지원

### 2.3 프론트엔드 UI/UX 계층 (`src/web/`)
- `src/web/manual.html`: 상단 툴바에 3-Way 뷰 세그먼트 버튼 그룹 배치
- `src/web/static/css/manual.css`: 
  - 3-Way 세그먼트 컨트롤 스타일
  - 2열 스플릿 뷰(Side-by-Side Flex/Grid) 및 모바일 반응형 처리
  - 인라인 원문 토글 카드(`inline-en-box`) 및 부드러운 슬라이드 트랜지션
  - 전문 용어 툴팁 스타일 (`term-tooltip`)
- `src/web/static/js/manual.js`:
  - 뷰 모드 상태 관리 (`ko`, `split`, `en`) 및 `localStorage` 연동
  - 인라인 원문 토글 클릭 이벤트 위임
  - 스플릿 모드 좌/우 동기화 스크롤
  - KaTeX 수식 일괄 렌더링

### 2.4 테스트 및 검증 계층
- `tests/test_manual_api.py`: 영문 원문 데이터 및 다국어 검색 API 테스트 추가
- 브라우저 서브에이전트 E2E: 3-Way 모드 전환, 인라인 토글, KaTeX 수식, 테마 전환 상호작용 검증

---

## 3. 마일스톤 및 실행 순서

| 마일스톤 | 작업 내용 | 대상 파일 |
|---|---|---|
| **M1: 데이터셋 확장** | 15개 토픽 영문 원문 데이터 및 인라인 토글 마크업 구축 | `src/web/manual/topics.py` |
| **M2: 백엔드 API 확장** | 영문 필드 반환 및 다국어 검색 스코어링 추가 | `src/api/manual_routes.py` |
| **M3: UI/UX & CSS 스타일링** | 3-Way 뷰 모드, 스플릿 뷰, 인라인 토글, 툴팁 구현 | `manual.html`, `manual.css`, `manual.js` |
| **M4: 단위 테스트 & E2E 검증** | Pytest 100% 통과 & 브라우저 서브에이전트 검증 | `test_manual_api.py`, 브라우저 테스트 |
| **M5: 문서 최신화 & 완료** | 사양서 최신화 및 요구사항 체크리스트 완료 처리 | `docs/08_...`, `요구사항03.md` |
