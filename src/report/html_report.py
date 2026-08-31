"""
A4 Engineering Calculation Sheet HTML Generator
Renders standard KDS 14 31 10 & AISI S100 structural calculation reports with SVG section diagrams.
"""

from typing import Dict, Any
from datetime import datetime


class HTMLReportGenerator:
    """
    Renders A4 printable structural calculation sheets.
    """

    @staticmethod
    def render_report(data: Dict[str, Any]) -> str:
        geom = data.get("geometry", {})
        props = data.get("properties", {})
        fsm = data.get("fsm", {})
        design = data.get("design", {})
        section_name = data.get("section_name", "Cold-Formed Section")
        project_name = data.get("project_name", "CFDesigner Project")
        engineer = data.get("engineer", "Structural Engineer")
        date_str = datetime.now().strftime("%Y-%m-%d %H:%M")

        # Extract Elements for SVG diagram
        elements = geom.get("elements", [])
        svg_content = HTMLReportGenerator._generate_svg(elements, props)

        # Extraction for Design Results
        comp = design.get("compression", {})
        flex = design.get("flexure", {})
        shear = design.get("shear", {})
        inter = design.get("interaction", {})

        comp_status_badge = '<span class="badge ok">OK</span>' if comp.get("status") == "OK" else '<span class="badge ng">NG</span>'
        flex_status_badge = '<span class="badge ok">OK</span>' if flex.get("status") == "OK" else '<span class="badge ng">NG</span>'
        shear_status_badge = '<span class="badge ok">OK</span>' if shear.get("status") == "OK" else '<span class="badge ng">NG</span>'
        inter_status_badge = '<span class="badge ok">OK</span>' if inter.get("status") == "OK" else '<span class="badge ng">NG</span>'

        html = f"""<!DOCTYPE html>
<html lang="ko">
<head>
<meta charset="UTF-8">
<title>{section_name} - KDS 14 31 10 구조계산서</title>
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
    background-color: #f3f4f6;
    margin: 0;
    padding: 20px 0;
    color: #1f2937;
    font-size: 13px;
  }}
  .sheet {{
    background: #ffffff;
    width: 210mm;
    min-height: 297mm;
    margin: 0 auto 20px auto;
    padding: 15mm 20mm;
    box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
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
    margin-bottom: 20px;
    border-bottom: 2px solid #1e3a8a;
  }}
  .header-table td {{
    padding: 6px 8px;
  }}
  .title-main {{
    font-size: 20px;
    font-weight: 700;
    color: #1e3a8a;
    letter-spacing: -0.5px;
  }}
  .title-sub {{
    font-size: 11px;
    color: #6b7280;
    margin-top: 3px;
  }}
  .meta-box {{
    text-align: right;
    font-size: 11px;
    color: #4b5563;
    line-height: 1.5;
  }}
  h2.sec-title {{
    font-size: 13px;
    font-weight: 700;
    color: #1e3a8a;
    background: #f0fdf4;
    border-left: 4px solid #059669;
    padding: 5px 10px;
    margin: 16px 0 8px 0;
    display: flex;
    justify-content: space-between;
    align-items: center;
  }}
  .grid-2 {{
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 15px;
    margin-bottom: 12px;
  }}
  .data-table {{
    width: 100%;
    border-collapse: collapse;
    margin-bottom: 10px;
  }}
  .data-table th, .data-table td {{
    border: 1px solid #e5e7eb;
    padding: 5px 8px;
    font-size: 11.5px;
  }}
  .data-table th {{
    background-color: #f9fafb;
    font-weight: 600;
    color: #374151;
    text-align: left;
  }}
  .data-table td.val {{
    text-align: right;
    font-family: 'Consolas', 'Courier New', monospace;
    font-weight: 600;
    color: #111827;
  }}
  .data-table td.unit {{
    color: #6b7280;
    width: 50px;
    text-align: center;
  }}
  .svg-container {{
    display: flex;
    justify-content: center;
    align-items: center;
    border: 1px solid #e5e7eb;
    border-radius: 4px;
    background: #fafafa;
    padding: 10px;
    height: 220px;
  }}
  .badge {{
    display: inline-block;
    padding: 2px 8px;
    border-radius: 9999px;
    font-size: 11px;
    font-weight: 700;
    text-align: center;
  }}
  .badge.ok {{ background-color: #d1fae5; color: #065f46; }}
  .badge.ng {{ background-color: #fee2e2; color: #991b1b; }}
  .progress-bar-bg {{
    background: #e5e7eb;
    height: 8px;
    border-radius: 4px;
    overflow: hidden;
    margin-top: 4px;
  }}
  .progress-bar-fill {{
    height: 100%;
    background: #10b981;
  }}
  .progress-bar-fill.danger {{
    background: #ef4444;
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
    padding: 12px 24px;
    border-radius: 8px;
    font-weight: 600;
    font-size: 14px;
    border: none;
    cursor: pointer;
    box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.2);
    display: flex;
    align-items: center;
    gap: 8px;
  }}
  .btn-print:hover {{ background: #1d4ed8; }}
</style>
</head>
<body>

<div class="print-btn-bar no-print">
  <button class="btn-print" onclick="window.print()">
    🖨️ 계산서 인쇄 / PDF 저장
  </button>
</div>

<div class="sheet">
  <!-- Header -->
  <table class="header-table">
    <tr>
      <td>
        <div class="title-main">{project_name}</div>
        <div class="title-sub">KDS 14 31 10 / AISI S100 직접강도법(DSM) 냉간성형강 구조계산서</div>
      </td>
      <td class="meta-box">
        <div><strong>부재명:</strong> {section_name}</div>
        <div><strong>설계자:</strong> {engineer}</div>
        <div><strong>작성일시:</strong> {date_str}</div>
      </td>
    </tr>
  </table>

  <!-- Section 1: Section Geometry & Properties -->
  <h2 class="sec-title">1. 단면 기하 형상 및 단면 성질 (Section Properties)</h2>
  <div class="grid-2">
    <div class="svg-container">
      {svg_content}
    </div>
    <div>
      <table class="data-table">
        <tr><th>총단면적 (Ag)</th><td class="val">{props.get('area', 0.0):,.1f}</td><td class="unit">mm²</td></tr>
        <tr><th>단위중량 (Weight)</th><td class="val">{props.get('weight', 0.0):.2f}</td><td class="unit">kg/m</td></tr>
        <tr><th>강축 2차모멘트 (Ix)</th><td class="val">{props.get('ix', 0.0):,.0f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>약축 2차모멘트 (Iy)</th><td class="val">{props.get('iy', 0.0):,.0f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>강축 단면2차반경 (rx)</th><td class="val">{props.get('rx', 0.0):.2f}</td><td class="unit">mm</td></tr>
        <tr><th>약축 단면2차반경 (ry)</th><td class="val">{props.get('ry', 0.0):.2f}</td><td class="unit">mm</td></tr>
        <tr><th>비틀림상수 (J)</th><td class="val">{props.get('j', 0.0):,.1f}</td><td class="unit">mm⁴</td></tr>
        <tr><th>뒴(Warping)상수 (Cw)</th><td class="val">{props.get('cw', 0.0):,.0f}</td><td class="unit">mm⁶</td></tr>
        <tr><th>전단중심 (x0, y0)</th><td class="val">({props.get('x0', 0.0):.1f}, {props.get('y0', 0.0):.1f})</td><td class="unit">mm</td></tr>
      </table>
    </div>
  </div>

  <!-- Section 2: FSM Elastic Buckling Analysis -->
  <h2 class="sec-title">2. 유한대판법(FSM) 탄성 좌굴해석 (Elastic Buckling Analysis)</h2>
  <table class="data-table">
    <thead>
      <tr>
        <th>좌굴 모드 (Buckling Mode)</th>
        <th style="text-align: center;">임계 반파장 길이 (L_cr)</th>
        <th style="text-align: right;">탄성 좌굴하중 (P_cr)</th>
        <th style="text-align: right;">좌굴응력 (F_cr)</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>국부 좌굴 (Local Buckling, Pcrl)</strong></td>
        <td style="text-align: center;">{fsm.get('l_local', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_crl', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_crl', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
      </tr>
      <tr>
        <td><strong>왜곡 좌굴 (Distortional Buckling, Pcrd)</strong></td>
        <td style="text-align: center;">{fsm.get('l_distortional', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_crd', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_crd', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
      </tr>
      <tr>
        <td><strong>전체 좌굴 (Global Buckling, Pcre)</strong></td>
        <td style="text-align: center;">{fsm.get('l_global', 0.0):.1f} mm</td>
        <td class="val">{fsm.get('p_cre', 0.0):.2f} kN</td>
        <td class="val">{((fsm.get('p_cre', 0.0)*1000.0) / max(props.get('area', 1.0), 1.0)):.1f} MPa</td>
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
        <th style="text-align: right;">설계 강도 (Design, φ=0.85/0.9)</th>
        <th style="text-align: center;">D/C Ratio</th>
        <th style="text-align: center;">판정</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><strong>축압축강도 (Compression)</strong><br><small style="color:#6b7280;">지배모드: {comp.get('governing_mode', '-')}</small></td>
        <td class="val">{data.get('loads', {}).get('pu', 0.0):.1f} kN</td>
        <td class="val">{comp.get('p_n', 0.0):.1f} kN</td>
        <td class="val" style="color:#1e3a8a;">{comp.get('phi_pn', 0.0):.1f} kN</td>
        <td style="text-align: center; font-weight:700;">{comp.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{comp_status_badge}</td>
      </tr>
      <tr>
        <td><strong>휨모멘트강도 (Flexure X-X)</strong><br><small style="color:#6b7280;">지배모드: {flex.get('governing_mode', '-')}</small></td>
        <td class="val">{data.get('loads', {}).get('mux', 0.0):.2f} kN·m</td>
        <td class="val">{flex.get('m_n', 0.0):.2f} kN·m</td>
        <td class="val" style="color:#1e3a8a;">{flex.get('phi_mn', 0.0):.2f} kN·m</td>
        <td style="text-align: center; font-weight:700;">{flex.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{flex_status_badge}</td>
      </tr>
      <tr>
        <td><strong>웨브 전단강도 (Shear)</strong></td>
        <td class="val">{data.get('loads', {}).get('vu', 0.0):.1f} kN</td>
        <td class="val">{shear.get('v_n', 0.0):.1f} kN</td>
        <td class="val" style="color:#1e3a8a;">{shear.get('phi_vn', 0.0):.1f} kN</td>
        <td style="text-align: center; font-weight:700;">{shear.get('dc_ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{shear_status_badge}</td>
      </tr>
      <tr>
        <td><strong>P-M 조합응력 (Interaction)</strong><br><small style="color:#6b7280;">{inter.get('formula_type', '식 (1.4-1)')}</small></td>
        <td colspan="3" style="text-align: right; color:#4b5563;">P/(φPn) + Mux/(φMnx) + Muy/(φMny)</td>
        <td style="text-align: center; font-weight:700; color:{'#059669' if inter.get('ratio', 0.0) <= 1.0 else '#dc2626'};">{inter.get('ratio', 0.0):.3f}</td>
        <td style="text-align: center;">{inter_status_badge}</td>
      </tr>
    </tbody>
  </table>

  <!-- Footer / Conclusion -->
  <div style="margin-top: 20px; padding: 12px; background: #f8fafc; border: 1px solid #cbd5e1; border-radius: 4px;">
    <strong>종합 설계 판정:</strong>
    {'<span style="color:#059669; font-weight:700; margin-left:8px;">[ 적합 - OK ] 본 단면은 KDS 14 31 10 냉간성형강 설계기준을 모두 만족합니다.</span>' if inter.get('status') == 'OK' else '<span style="color:#dc2626; font-weight:700; margin-left:8px;">[ 부적합 - NG ] 소요 강도가 부재 설계 내력을 초과하였습니다. 단면 두께 또는 치수를 보강하십시오.</span>'}
  </div>
</div>

</body>
</html>
"""
        return html

    @staticmethod
    def _generate_svg(elements: list, props: dict) -> str:
        if not elements:
            return '<svg width="200" height="200"><text x="50" y="100" fill="#999">No Section</text></svg>'

        # Compute bounding box
        xs = [e.get("x0", 0.0) for e in elements] + [e.get("x1", 0.0) for e in elements]
        ys = [e.get("y0", 0.0) for e in elements] + [e.get("y1", 0.0) for e in elements]
        min_x, max_x = min(xs), max(xs)
        min_y, max_y = min(ys), max(ys)

        w = max(max_x - min_x, 20.0)
        h = max(max_y - min_y, 20.0)
        pad = max(w, h) * 0.25

        view_min_x = min_x - pad
        view_min_y = min_y - pad
        view_w = w + 2 * pad
        view_h = h + 2 * pad

        # Flip Y for SVG
        lines_svg = []
        for e in elements:
            x0 = e.get("x0", 0.0)
            y0 = -e.get("y0", 0.0)
            x1 = e.get("x1", 0.0)
            y1 = -e.get("y1", 0.0)
            t = e.get("thickness", 2.0)
            lines_svg.append(f'<line x1="{x0:.2f}" y1="{y0:.2f}" x2="{x1:.2f}" y2="{y1:.2f}" stroke="#1e3a8a" stroke-width="{max(t, 1.5):.2f}" stroke-linecap="round"/>')

        # Add CG marker
        cg_x = props.get("xcg", 0.0)
        cg_y = -props.get("ycg", 0.0)
        marker_cg = f'<circle cx="{cg_x:.2f}" cy="{cg_y:.2f}" r="3" fill="#dc2626" /><text x="{cg_x+5:.2f}" y="{cg_y-5:.2f}" font-size="8" fill="#dc2626" font-weight="bold">CG</text>'

        # Add SC marker
        sc_x = props.get("x0", 0.0)
        sc_y = -props.get("y0", 0.0)
        marker_sc = f'<circle cx="{sc_x:.2f}" cy="{sc_y:.2f}" r="3" fill="#2563eb" /><text x="{sc_x+5:.2f}" y="{sc_y-5:.2f}" font-size="8" fill="#2563eb" font-weight="bold">SC</text>'

        svg = f'''<svg viewBox="{view_min_x:.2f} {-view_min_y - view_h:.2f} {view_w:.2f} {view_h:.2f}" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg">
          <g>
            {''.join(lines_svg)}
            {marker_cg}
            {marker_sc}
          </g>
        </svg>'''
        return svg
