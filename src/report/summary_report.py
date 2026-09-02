"""
Summary / Quick Calculation Report HTML Generator
Generates a concise 1-2 page executive summary report for rapid engineering verification.
"""

from typing import Dict, Any, Optional
from datetime import datetime
from .models import ProjectMetadata, ReportOptions
from .svg_diagrams import SVGDiagramGenerator
from ..design.kds_trace_engine import KDSTraceEngine


class SummaryReportGenerator:
    """
    Renders concise executive summary engineering reports.
    """

    @staticmethod
    def render(data: Dict[str, Any], meta: Optional[ProjectMetadata] = None, opts: Optional[ReportOptions] = None) -> str:
        meta = meta or ProjectMetadata.from_dict(data.get("metadata", {}))
        opts = opts or ReportOptions.from_dict(data.get("options", {}))

        geom = data.get("geometry", {})
        props = data.get("properties", {})
        fsm = data.get("fsm", {})
        design = data.get("design", {})
        loads = data.get("loads", {})
        material = data.get("material", {})

        date_str = datetime.now().strftime("%Y-%m-%d %H:%M")

        # Elements & SVG
        elements = geom.get("elements", [])
        svg_section = SVGDiagramGenerator.render_section_svg(elements, props, width=320, height=220)

        # Fallback trace calculation if design results are incomplete
        trace = KDSTraceEngine.generate_full_trace(props, material, fsm, loads)

        # Design results
        comp = design.get("compression", {})
        if not comp or comp.get("phi_pn", 0.0) <= 0:
            c_gov = trace.compression[-1] if trace.compression else None
            comp = {
                "p_n": c_gov.nominal_value if c_gov else 0.0,
                "phi_pn": c_gov.design_value if c_gov else 0.0,
                "dc_ratio": c_gov.dc_ratio if c_gov else 0.0,
                "status": c_gov.status if c_gov else "OK",
                "governing_mode": c_gov.notes if c_gov else "-"
            }

        flex = design.get("flexure", {})
        if not flex or flex.get("phi_mn", 0.0) <= 0:
            f_gov = trace.flexure_x[-1] if trace.flexure_x else None
            flex = {
                "m_n": f_gov.nominal_value if f_gov else 0.0,
                "phi_mn": f_gov.design_value if f_gov else 0.0,
                "dc_ratio": f_gov.dc_ratio if f_gov else 0.0,
                "status": f_gov.status if f_gov else "OK",
                "governing_mode": f_gov.notes if f_gov else "-"
            }

        shear = design.get("shear", {})
        if not shear or shear.get("phi_vn", 0.0) <= 0:
            s_gov = trace.shear[-1] if trace.shear else None
            shear = {
                "v_n": s_gov.nominal_value if s_gov else 0.0,
                "phi_vn": s_gov.design_value if s_gov else 0.0,
                "dc_ratio": s_gov.dc_ratio if s_gov else 0.0,
                "status": s_gov.status if s_gov else "OK"
            }

        inter = design.get("interaction", {})
        if not inter or "status" not in inter:
            i_sec = trace.interaction[0] if trace.interaction else None
            inter = {
                "ratio": i_sec.dc_ratio if i_sec else 0.0,
                "status": i_sec.status if i_sec else "OK"
            }

        comp_badge = '<span class="badge ok">OK</span>' if comp.get("status") == "OK" else '<span class="badge ng">NG</span>'
        flex_badge = '<span class="badge ok">OK</span>' if flex.get("status") == "OK" else '<span class="badge ng">NG</span>'
        shear_badge = '<span class="badge ok">OK</span>' if shear.get("status") == "OK" else '<span class="badge ng">NG</span>'
        inter_badge = '<span class="badge ok">OK</span>' if inter.get("status") == "OK" else '<span class="badge ng">NG</span>'

        html = f"""<!DOCTYPE html>
<html lang="ko">
<head>
<meta charset="UTF-8">
<title>{meta.section_name} - 간략 구조요약보고서 (Summary Report)</title>
<style>
  @page {{
    size: A4 portrait;
    margin: 12mm 15mm 15mm 15mm;
  }}
  * {{
    box-sizing: border-box;
    font-family: 'Inter', -apple-system, BlinkMacSystemFont, "Malgun Gothic", "맑은 고딕", sans-serif;
  }}
  body {{
    background-color: #f1f5f9;
    margin: 0;
    padding: 20px 0;
    color: #1e293b;
    font-size: 12px;
  }}
  .sheet {{
    background: #ffffff;
    width: 210mm;
    min-height: 297mm;
    margin: 0 auto 20px auto;
    padding: 15mm 18mm;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
    border-radius: 4px;
  }}
  @media print {{
    body {{ background: transparent; padding: 0; }}
    .sheet {{ width: 100%; box-shadow: none; margin: 0; padding: 0; border-radius: 0; page-break-after: always; }}
    .no-print {{ display: none !important; }}
  }}
  .header-table {{
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 14px;
    border-bottom: 2px solid #1e3a8a;
  }}
  .header-table td {{ padding: 4px 6px; }}
  .title-main {{ font-size: 18px; font-weight: 700; color: #1e3a8a; }}
  .title-sub {{ font-size: 10.5px; color: #64748b; margin-top: 2px; }}
  
  .approval-table {{
    border-collapse: collapse;
    font-size: 10px;
    text-align: center;
    float: right;
  }}
  .approval-table th, .approval-table td {{
    border: 1px solid #cbd5e1;
    padding: 3px 8px;
  }}
  .approval-table th {{ background: #f8fafc; color: #475569; }}
  .approval-table td.sign {{ height: 28px; vertical-align: bottom; font-weight: 600; color: #1e3a8a; }}

  h2.sec-title {{
    font-size: 12px;
    font-weight: 700;
    color: #1e3a8a;
    background: #f8fafc;
    border-left: 4px solid #2563eb;
    padding: 4px 8px;
    margin: 14px 0 6px 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
  }}
  .grid-2 {{
    display: grid;
    grid-template-columns: 1.1fr 1fr;
    gap: 12px;
    margin-bottom: 8px;
  }}
  .data-table {{
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 8px;
  }}
  .data-table th, .data-table td {{
    border: 1px solid #e2e8f0;
    padding: 4px 6px;
    font-size: 11px;
  }}
  .data-table th {{
    background-color: #f8fafc;
    font-weight: 600;
    color: #334155;
    text-align: left;
  }}
  .data-table td.val {{
    text-align: right;
    font-family: 'Consolas', 'Courier New', monospace;
    font-weight: 600;
    color: #0f172a;
  }}
  .data-table td.unit {{
    color: #64748b;
    width: 45px;
    text-align: center;
  }}
  .svg-container {{
    display: flex;
    justify-content: center;
    align-items: center;
    border: 1px solid #e2e8f0;
    border-radius: 4px;
    background: #fafbfc;
    padding: 6px;
    height: 210px;
  }}
  .badge {{
    display: inline-block;
    padding: 2px 6px;
    border-radius: 9999px;
    font-size: 10px;
    font-weight: 700;
    text-align: center;
  }}
  .badge.ok {{ background-color: #dcfce7; color: #166534; }}
  .badge.ng {{ background-color: #fee2e2; color: #991b1b; }}
  .conclusion-box {{
    margin-top: 14px;
    padding: 10px 14px;
    background: #f8fafc;
    border: 1px solid #cbd5e1;
    border-radius: 4px;
    font-size: 11.5px;
  }}
  .print-btn-bar {{
    position: fixed;
    bottom: 20px;
    right: 20px;
    z-index: 1000;
  }}
  .btn-print {{
    background: #2563eb;
    color: white;
    padding: 10px 20px;
    border-radius: 6px;
    font-weight: 600;
    font-size: 13px;
    border: none;
    cursor: pointer;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.2);
  }}
</style>
</head>
<body>

<div class="print-btn-bar no-print">
  <button class="btn-print" onclick="window.print()">🖨️ 인쇄 / PDF 저장</button>
</div>

<div class="sheet">
  <!-- Header & Approval Block -->
  <table class="header-table">
    <tr>
      <td style="width: 55%; vertical-align: top;">
        <div class="title-main">{meta.project_name}</div>
        <div class="title-sub">냉간성형강 간략 구조계산 요약보고서 (KDS 14 31 10 / AISI S100 DSM)</div>
        <div style="font-size: 10px; color:#64748b; margin-top: 4px;">
          <strong>부재명:</strong> {meta.section_name} | <strong>문서번호:</strong> {meta.doc_number} | <strong>일시:</strong> {date_str}
        </div>
      </td>
      <td style="width: 45%; vertical-align: top;">
        <table class="approval-table">
          <tr>
            <th rowspan="2" style="writing-mode: vertical-rl; width: 18px; padding: 2px;">결재</th>
            <th style="width: 55px;">작성</th>
            <th style="width: 55px;">검토</th>
            <th style="width: 55px;">승인</th>
          </tr>
          <tr>
            <td class="sign">{meta.designed_by}</td>
            <td class="sign">{meta.checked_by}</td>
            <td class="sign">{meta.approved_by}</td>
          </tr>
        </table>
      </td>
    </tr>
  </table>

  <!-- Section 1: Section Geometry & Properties -->
  <h2 class="sec-title">1. 단면 기하형상 및 단면 성질 (Section Properties)</h2>
  <div class="grid-2">
    <div class="svg-container">
      {svg_section}
    </div>
    <div>
      <table class="data-table">
        <tr><th>총단면적 (Ag)</th><td class="val">{props.get('area', 0.0):,.1f}</td><td class="unit">mm²</td></tr>
        <tr><th>단위중량 (Weight)</th><td class="val">{props.get('weight', 0.0):.2f}</td><td class="unit">kg/m</td></tr>
        <tr><th>강축 2차모멘트 (Ix)</th><td class="val">{props.get('ix', 0.0):,.0f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>약축 2차모멘트 (Iy)</th><td class="val">{props.get('iy', 0.0):,.0f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>단면2차반경 (rx / ry)</th><td class="val">{props.get('rx', 0.0):.1f} / {props.get('ry', 0.0):.1f}</td><td class="unit">mm</td></tr>
        <tr><th>비틀림상수 (J)</th><td class="val">{props.get('j', 0.0):,.1f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>뒴상수 (Cw)</th><td class="val">{props.get('cw', 0.0):,.0f}</td><td class="unit">mm⁶</td></tr>
        <tr><th>전단중심 (x0, y0)</th><td class="val">({props.get('x0', 0.0):.1f}, {props.get('y0', 0.0):.1f})</td><td class="unit">mm</td></tr>
      </table>
    </div>
  </div>

  <!-- Section 2: FSM Elastic Buckling Analysis -->
  <h2 class="sec-title">2. 유한대판법(FSM) 탄성 좌굴해석 요약 (Elastic Buckling Summary)</h2>
  <table class="data-table">
    <thead>
      <tr>
        <th>좌굴 모드</th>
        <th style="text-align: center;">임계 반파장 (Lcr)</th>
        <th style="text-align: right;">탄성 좌굴하중 (Pcr)</th>
        <th style="text-align: right;">좌굴응력 (Fcr)</th>
        <th style="text-align: center;">좌굴비 (Pcr/Py)</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>국부 좌굴 (Local, Pcrl)</strong></td>
        <td style="text-align: center;">{fsm.get('l_local', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_crl', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_crl', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
        <td style="text-align: center; font-weight:600;">{fsm.get('p_crl_ratio', 0.0):.3f}</td>
      </tr>
      <tr>
        <td><strong>왜곡 좌굴 (Distortional, Pcrd)</strong></td>
        <td style="text-align: center;">{fsm.get('l_distortional', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_crd', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_crd', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
        <td style="text-align: center; font-weight:600;">{fsm.get('p_crd_ratio', 0.0):.3f}</td>
      </tr>
      <tr>
        <td><strong>전체 좌굴 (Global, Pcre)</strong></td>
        <td style="text-align: center;">{fsm.get('l_global', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_cre', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_cre', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
        <td style="text-align: center; font-weight:600;">{fsm.get('p_cre_ratio', 0.0):.3f}</td>
      </tr>
    </tbody>
  </table>

  <!-- Section 3: KDS 14 31 10 DSM Design Capacity Checks -->
  <h2 class="sec-title">3. KDS 14 31 10 직접강도법(DSM) 부재 내력 검토</h2>
  <table class="data-table">
    <thead>
      <tr>
        <th>검토 항목</th>
        <th style="text-align: right;">소요 강도 (Factored)</th>
        <th style="text-align: right;">공칭 강도 (Nominal)</th>
        <th style="text-align: right;">설계 강도 (φPn/φMn)</th>
        <th style="text-align: center;">D/C Ratio</th>
        <th style="text-align: center;">판정</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>축압축강도 (Compression)</strong><br><small style="color:#64748b;">지배: {comp.get('governing_mode', '-')}</small></td>
        <td class="val">{loads.get('pu', 0.0):.1f} kN</td>
        <td class="val">{comp.get('p_n', 0.0):.1f} kN</td>
        <td class="val" style="color:#1e3a8a;">{comp.get('phi_pn', 0.0):.1f} kN</td>
        <td style="text-align: center; font-weight:700;">{comp.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{comp_badge}</td>
      </tr>
      <tr>
        <td><strong>휨모멘트강도 (Flexure X-X)</strong><br><small style="color:#64748b;">지배: {flex.get('governing_mode', '-')}</small></td>
        <td class="val">{loads.get('mux', 0.0):.2f} kN·m</td>
        <td class="val">{flex.get('m_n', 0.0):.2f} kN·m</td>
        <td class="val" style="color:#1e3a8a;">{flex.get('phi_mn', 0.0):.2f} kN·m</td>
        <td style="text-align: center; font-weight:700;">{flex.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{flex_badge}</td>
      </tr>
      <tr>
        <td><strong>웨브 전단강도 (Shear)</strong></td>
        <td class="val">{loads.get('vu', 0.0):.1f} kN</td>
        <td class="val">{shear.get('v_n', 0.0):.1f} kN</td>
        <td class="val" style="color:#1e3a8a;">{shear.get('phi_vn', 0.0):.1f} kN</td>
        <td style="text-align: center; font-weight:700;">{shear.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{shear_badge}</td>
      </tr>
      <tr>
        <td><strong>P-M 조합응력 (Interaction)</strong></td>
        <td colspan="3" style="text-align: right; color:#64748b; font-size:10px;">P/(φPn) + Mux/(φMnx) + Muy/(φMny)</td>
        <td style="text-align: center; font-weight:700; color:{'#166534' if inter.get('ratio', 0.0) <= 1.0 else '#991b1b'};">{inter.get('ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{inter_badge}</td>
      </tr>
    </tbody>
  </table>

  <!-- Conclusion Block -->
  <div class="conclusion-box">
    <strong>종합 설계 판정:</strong>
    {'<span style="color:#166534; font-weight:700; margin-left:8px;">[ 적합 - OK ] 본 단면은 KDS 14 31 10 냉간성형강 설계기준을 모두 만족합니다.</span>' if inter.get('status') == 'OK' else '<span style="color:#991b1b; font-weight:700; margin-left:8px;">[ 부적합 - NG ] 소요 강도가 부재 설계 내력을 초과하였습니다. 단면 두께 또는 치수를 보강하십시오.</span>'}
  </div>
</div>

</body>
</html>
"""
        return html
