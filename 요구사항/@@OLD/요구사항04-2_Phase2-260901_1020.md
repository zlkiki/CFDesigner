# [요구사항 04-2] Phase 2: 단면 및 재료 라이브러리 브라우저 사양서

---

## 1. 개요 및 목적

* **문서 번호**: `요구사항04-2` (Phase 2)
* **목적**: 기존 CFS에 내장된 표준 단면 라이브러리(`AISI.cfsl`, `LGSI.cfsl`, `SFIA.cfsl`, `SSMA.cfsl`, `HUD.cfsl`) 및 재료 물성치 DB(`CFS14.mtl`)를 웹 애플리케이션에서 직접 탐색, 검색 및 불러오기(Import)할 수 있는 모던 브라우저 시스템 구축.
* **대상 레거시 C# 폼 및 모듈**:
  * [`decompiled_src/_Global/frmSctLib.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmSctLib.cs), [`frmOpenLibSct.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmOpenLibSct.cs) (단면 라이브러리 탐색기)
  * [`decompiled_src/_Global/frmMaterial.cs`](file:///f:/PyProject/CFDesigner/decompiled_src/_Global/frmMaterial.cs) (재료 DB 및 커스텀 강재)
  * [`decompiled_src/RSG/Data/DataAnalysis.cs`](file:///f:/PyProject/CFT/decompiled_src/RSG/Data/DataAnalysis.cs) (`*.cfsl` 바이너리 단면 파서)
  * [`original_source/*.cfsl`](file:///f:/PyProject/CFT/original_source/AISI.cfsl), [`original_source/CFS14.mtl`](file:///f:/PyProject/CFT/original_source/CFS14.mtl)

---

## 2. 세부 기능 요구사항 (Functional Requirements)

### 2.1 단면 라이브러리 브라우저 모달 (Section Library Browser Modal)
1. **상단 네비게이션 또는 좌측 사이드바에 `[📚 단면 라이브러리]` 버튼 배치**:
   * 클릭 시 고성능 단면 라이브러리 브라우저 모달 팝업.
2. **라이브러리 분류 및 필터 트리**:
   * **라이브러리 카테고리**:
     * `AISI Standard` (`AISI.cfsl` - C형강, Z형강, 트랙, 스터드 등)
     * `SSMA` (Steel Stud Manufacturers Association)
     * `SFIA` (Steel Framing Industry Association)
     * `LGSI` (Light Gauge Steel Institute)
     * `HUD` (Housing & Urban Development)
   * **형상 필터**: `Stud / Joist (S)`, `Track (T)`, `Channel (U)`, `Angle (L)`, `Z-Section`
3. **단면 목록 테이블 및 실시간 검색**:
   * 규격명(Name, 예: `600S162-54`), 높이($H$), 너비($B$), 두께($t$), 단면적($A$), 단위중량($W$) 표시.
   * 실시간 텍스트 필터링 (예: `600S` 입력 시 즉시 필터링).
4. **미리보기 및 선택 로드**:
   * 단면 클릭 시 우측에 2D 단면 형상 및 주요 단면 성질($I_x, I_y, r_x, r_y$) 미니 프리뷰.
   * `[단면 적용하기 (Load Section)]` 클릭 시 메인 캔버스, FSM 해석, KDS 부재설계로 즉시 로드.

### 2.2 재료 물성치 DB 및 가공경화 계산기 (Material Properties Modal)
1. **재료 DB 브라우저 (`frmMaterial.cs` 대응)**:
   * **표준 강종 프리셋 선택**:
     * **KDS / KS 강종**: `SSC275`, `SSC355`, `SSC400`, `SSC490`
     * **ASTM 표준 강종**: `ASTM A1008 (Grade 33, 40, 50)`, `ASTM A653 (Grade 33, 50, 80)`, `ASTM A1011`
     * **스테인리스강 (Stainless Steel)**: `Type 304`, `Type 316`, `Type 430`
   * 프리셋 선택 시 $F_y$(항복강도), $F_u$(인장강도), $E$(탄성계수), $\nu$(포아송비) 자동 주입.
2. **가공경화 강도 증가 효과 계산기 (Cold-Work Forming Calculator)**:
   * AISI S100 / KDS 14 31 10 기준 모서리 성형 가공경화에 따른 유효항복강도($F_{ya}$) 증가 옵션 체크박스.
   * $F_{ya} = C F_{yc} + (1-C) F_{yf}$ 자동 산정 및 설계 강도 반영.

---

## 3. 백엔드 API 명세

| Method | Endpoint | 설명 | 요청/응답 페이로드 |
|---|---|---|---|
| `GET` | `/api/library/sections` | 단면 라이브러리 목록 조회 및 검색 | `Query: { lib: "AISI", shape: "S", query: "600" }`<br>`Res: [ { id, name, h, b, t, a, ix, iy }, ... ]` |
| `GET` | `/api/library/sections/{id}` | 특정 라이브러리 단면 상세 지오메트리 로드 | `Res: { name, parts: [...], elements: [...], properties: {...} }` |
| `GET` | `/api/library/materials` | 표준 강종 물성치 DB 목록 | `Res: [ { code: "SSC275", fy: 275, fu: 410, e: 205000 }, ... ]` |
| `POST` | `/api/material/cold-work` | 코너 가공경화 유효항복강도 계산 | `Req: { base_fy: 345, base_fu: 450, r: 2.0, t: 1.5, corners: 4 }`<br>`Res: { fya: 382.5, percent_increase: 10.8 }` |

---

## 4. 검증 기준 (Acceptance Criteria) - [100% 만족 ✅]

- [x] **AC 2-1**: `original_source/AISI.cfsl` 바이너리 파일이 파이썬 엔진에서 에러 없이 100% 디코딩되어 단면 목록을 반환하는가?
- [x] **AC 2-2**: 라이브러리 브라우저에서 `362S162-33` 선택 시 치수($H=92.1\text{mm}, B=41.3\text{mm}, t=0.88\text{mm}$)와 2D 형상이 메인 캔버스에 즉시 로드되는가?
- [x] **AC 2-3**: 재료 모달에서 `SSC275` 강종 선택 시 항복강도 275 MPa 및 탄성계수 205,000 MPa가 부재설계 패널에 정확히 반영되는가?
- [x] **AC 2-4**: 가공경화 옵션 활성화 시 $F_{ya}$가 이론식에 맞게 증가하여 공칭압축강도 $P_n$에 반영되는가?
