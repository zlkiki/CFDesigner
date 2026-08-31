# [TODO 및 로드맵] AISI S100 복원 및 KDS 14 31 10 비교 검증 계획

> **문서 상태**: 📌 메모 / 추후 실행 로드맵  
> **관련 모듈**: `RSG.CFS.MemberCheck`, `RSG.CFS.BuckleParameters`, `RSG.CFS.Section`  
> **관련 기준**: AISI S100 (북미 냉간성형강 설계기준) $\leftrightarrow$ KDS 14 31 10 (국내 냉간성형강구조설계기준)

---

## 1. 배경 및 핵심 맥락

* **`CFS.exe` 내장 기준**: 
  - 본 프로그램 내부에는 AISI S100 (North American Specification for the Design of Cold-Formed Steel Structural Members) 기준이 내장되어 있습니다.
* **국내 기준과의 관계**: 
  - 국내 **KDS 14 31 10(냉간성형강구조설계기준)**은 AISI S100을 모태로 하여 국내 건설 환경 및 한계상태설계법/허용응력설계법 체계에 맞춰 도입·정립된 기준입니다.
* **필요성**: 
  - `CFS.exe`의 C# 소스에서 AISI S100 부재검토 알고리즘을 완전 복원한 뒤, KDS 14 31 10과의 수식적/계수적 차이점을 정밀 대조하여 국내 기준에 100% 부합하는 자체 설계 엔진으로 전환해야 합니다.

---

## 2. 추후 진행할 핵심 작업 항목 (TODO Checklist)

### 2.1. AISI S100 원본 설계 알고리즘 복원 (`decompiled_src/`)
- [ ] `RSG.CFS.MemberCheck.cs` 클래스에서 압축재, 휨재, 전단, 웨브 크리플링, 조합응력 계산 로직 역추적
- [ ] 직접강도법(DSM: Direct Strength Method) 강도 산정 함수 복원:
  - 기둥 공칭 압축강도 $P_n = \min(P_{ne}, P_{nl}, P_{nd})$
  - 보 공칭 휨강도 $M_n = \min(M_{ne}, M_{nl}, M_{nd})$
  - 전단강도 $V_n$ 및 조합응력 상관방정식

### 2.2. KDS 14 31 10 vs AISI S100 상세 차이점 분석
- [ ] **저항계수($\phi$) 및 안전율($\Omega$) 체계 비교**:
  - LRFD(한계상태설계법) 및 ASD(허용응력설계법)에서의 부재별 저항계수 차이 대조
- [ ] **국내 강재 규격(KS) 매핑**:
  - ASTM 규격 강재(A653, A1003 등)와 KS 규격 강재(SGC, SSC, SHN 등)의 항복강도($F_y$), 인장강도($F_u$), 냉간가공 강도증가 효과($F_{ya}$) 계산식 비교
- [ ] **유효폭법(EWM) vs 직접강도법(DSM) 적용 범위 및 조항 매핑**:
  - KDS 14 31 10 제4장(부재설계)의 조항 번호와 AISI S100 Chapter C/D/E/F 1:1 매핑 테이블 작성

### 2.3. 교차 검증 (Cross-Validation) 파이프라인
- [ ] 상위 프로젝트 `kcsc2md`의 KDS 14 31 10 마크다운 원문 및 강구조학회 공인 예제집 데이터 대조
- [ ] 표준 C형강 및 Z형강 샘플 단면에 대해:
  1. `CFS.exe`의 AISI S100 계산 결과
  2. KDS 14 31 10 수계산/예제집 결과
  3. 신규 자체 Python 엔진 계산 결과
  - 3자 간의 수치 비교 검증(허용 오차 0.1% 이내) 수행

---

## 3. 참조 링크 및 연계 문서

* 🏛️ **KDS 국가건설기준 Ground Truth**: `../../kcsc2md/output/kds_md/KDS 14 31 10/`
* 📐 **[KDS / AISI 설계 기준서](./05_kds_aisi_design_rules.md)** (향후 상세 수식 정리 예정)
* 🔬 **[FSM 유한대판법 해석 명세](./04_finite_strip_method.md)** (탄성 좌굴하중 $P_{cr}, M_{cr}$ 연계)
