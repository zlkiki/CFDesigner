"""
SVG Engineering Diagrams Generator for Calculation Reports
Provides high-resolution vector diagrams for Cross Sections, Principal Axes,
FSM Signature Curves, and Buckling Mode Profiles.
"""

import math
from typing import List, Dict, Any, Optional


class SVGDiagramGenerator:
    """
    Renders SVG diagrams for structural engineering calculation sheets.
    """

    @staticmethod
    def render_section_svg(elements: List[Dict[str, Any]], props: Dict[str, Any], width: int = 400, height: int = 280) -> str:
        """
        Renders complete cross-section with Centerline, Thickness, CG, SC, and Principal Axes.
        """
        if not elements:
            return f'<svg viewBox="0 0 {width} {height}" width="100%" height="100%"><text x="{width/2}" y="{height/2}" fill="#999" text-anchor="middle" font-family="sans-serif">No Section Geometry</text></svg>'

        # Bounding box
        xs = [float(e.get("x0", 0.0)) for e in elements] + [float(e.get("x1", 0.0)) for e in elements]
        ys = [float(e.get("y0", 0.0)) for e in elements] + [float(e.get("y1", 0.0)) for e in elements]
        min_x, max_x = min(xs), max(xs)
        min_y, max_y = min(ys), max(ys)

        span_x = max(max_x - min_x, 20.0)
        span_y = max(max_y - min_y, 20.0)
        max_span = max(span_x, span_y)

        # Padding for axes and dimension lines
        pad = max_span * 0.35
        view_min_x = min_x - pad
        view_min_y = min_y - pad
        view_w = span_x + 2 * pad
        view_h = span_y + 2 * pad

        lines_svg = []
        elem_labels = []

        for idx, e in enumerate(elements, 1):
            x0 = float(e.get("x0", 0.0))
            y0 = -float(e.get("y0", 0.0))  # Invert Y for SVG
            x1 = float(e.get("x1", 0.0))
            y1 = -float(e.get("y1", 0.0))
            t = float(e.get("thickness", 2.0))
            
            # Element line
            lines_svg.append(
                f'<line x1="{x0:.2f}" y1="{y0:.2f}" x2="{x1:.2f}" y2="{y1:.2f}" '
                f'stroke="#1e3a8a" stroke-width="{max(t, 2.0):.2f}" stroke-linecap="round" />'
            )

            # Element number badge at midpoint
            mx = (x0 + x1) / 2.0
            my = (y0 + y1) / 2.0
            elem_labels.append(
                f'<circle cx="{mx:.2f}" cy="{my:.2f}" r="4.5" fill="#f8fafc" stroke="#2563eb" stroke-width="1"/>'
                f'<text x="{mx:.2f}" y="{my+2.5:.2f}" font-size="6" font-family="Consolas, monospace" font-weight="bold" fill="#1e3a8a" text-anchor="middle">{idx}</text>'
            )

        # CG (Center of Gravity) marker
        cg_x = float(props.get("xcg", props.get("x_cg", 0.0)))
        cg_y = -float(props.get("ycg", props.get("y_cg", 0.0)))
        marker_cg = (
            f'<circle cx="{cg_x:.2f}" cy="{cg_y:.2f}" r="4" fill="#dc2626" stroke="#ffffff" stroke-width="1.5"/>'
            f'<text x="{cg_x+6:.2f}" y="{cg_y-4:.2f}" font-size="8" font-family="sans-serif" font-weight="bold" fill="#dc2626">CG ({cg_x:.1f}, {-cg_y:.1f})</text>'
        )

        # SC (Shear Center) marker
        sc_x = float(props.get("x0", props.get("x_sc", 0.0)))
        sc_y = -float(props.get("y0", props.get("y_sc", 0.0)))
        marker_sc = (
            f'<circle cx="{sc_x:.2f}" cy="{sc_y:.2f}" r="4" fill="#2563eb" stroke="#ffffff" stroke-width="1.5"/>'
            f'<text x="{sc_x+6:.2f}" y="{sc_y+10:.2f}" font-size="8" font-family="sans-serif" font-weight="bold" fill="#2563eb">SC ({sc_x:.1f}, {-sc_y:.1f})</text>'
        )

        # Principal axes lines (1-1 and 2-2) passing through CG
        theta_rad = math.radians(float(props.get("theta", props.get("principal_angle", 0.0))))
        axis_len = max_span * 0.6
        # Axis 1 (Major)
        ax1_x0 = cg_x - axis_len * math.cos(theta_rad)
        ax1_y0 = cg_y + axis_len * math.sin(theta_rad)  # Inverted Y
        ax1_x1 = cg_x + axis_len * math.cos(theta_rad)
        ax1_y1 = cg_y - axis_len * math.sin(theta_rad)
        # Axis 2 (Minor)
        ax2_x0 = cg_x + axis_len * math.sin(theta_rad)
        ax2_y0 = cg_y + axis_len * math.cos(theta_rad)
        ax2_x1 = cg_x - axis_len * math.sin(theta_rad)
        ax2_y1 = cg_y - axis_len * math.cos(theta_rad)

        axes_svg = (
            f'<line x1="{ax1_x0:.2f}" y1="{ax1_y0:.2f}" x2="{ax1_x1:.2f}" y2="{ax1_y1:.2f}" stroke="#059669" stroke-width="1.2" stroke-dasharray="4,3"/>'
            f'<text x="{ax1_x1+4:.2f}" y="{ax1_y1+3:.2f}" font-size="7" font-weight="bold" fill="#059669">1</text>'
            f'<line x1="{ax2_x0:.2f}" y1="{ax2_y0:.2f}" x2="{ax2_x1:.2f}" y2="{ax2_y1:.2f}" stroke="#059669" stroke-width="1.2" stroke-dasharray="4,3"/>'
            f'<text x="{ax2_x1+4:.2f}" y="{ax2_y1+3:.2f}" font-size="7" font-weight="bold" fill="#059669">2</text>'
        )

        svg = f'''<svg viewBox="{view_min_x:.2f} {-view_min_y - view_h:.2f} {view_w:.2f} {view_h:.2f}" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg" style="max-height:{height}px;">
  <defs>
    <pattern id="grid" width="20" height="20" patternUnits="userSpaceOnUse">
      <path d="M 20 0 L 0 0 0 20" fill="none" stroke="#f1f5f9" stroke-width="1"/>
    </pattern>
  </defs>
  <rect x="{view_min_x:.2f}" y="{-view_min_y - view_h:.2f}" width="{view_w:.2f}" height="{view_h:.2f}" fill="#fafbfc" />
  <g id="axes">{axes_svg}</g>
  <g id="elements">{''.join(lines_svg)}</g>
  <g id="element_labels">{''.join(elem_labels)}</g>
  <g id="markers">{marker_cg}{marker_sc}</g>
</svg>'''
        return svg

    @staticmethod
    def render_signature_curve_svg(fsm_data: Dict[str, Any], width: int = 500, height: int = 220) -> str:
        """
        Renders log-scale FSM signature curve (Half-wavelength vs Load factor).
        """
        curve_points = fsm_data.get("signature_curve", [])
        if not curve_points or len(curve_points) < 3:
            # Fallback placeholder curve
            curve_points = [
                {"length": 20, "load_factor": 2.5},
                {"length": 60, "load_factor": 0.85},  # Local min
                {"length": 150, "load_factor": 1.4},
                {"length": 350, "load_factor": 0.72},  # Distortional min
                {"length": 800, "load_factor": 1.2},
                {"length": 2000, "load_factor": 0.45},  # Global
            ]

        # Extract lengths and load factors
        lens = [p.get("length", 10.0) for p in curve_points]
        factors = [p.get("load_factor", 1.0) for p in curve_points]

        min_l, max_l = max(min(lens), 1.0), max(max(lens), 100.0)
        log_min_l = math.log10(min_l)
        log_max_l = math.log10(max_l)
        if log_max_l == log_min_l:
            log_max_l += 1.0

        min_f = 0.0
        max_f = max(max(factors) * 1.25, 1.5)

        pad_left = 50
        pad_right = 30
        pad_top = 25
        pad_bottom = 35

        plot_w = width - pad_left - pad_right
        plot_h = height - pad_top - pad_bottom

        # Coordinate transforms
        def map_x(l_val):
            val = max(l_val, 1.0)
            log_v = math.log10(val)
            ratio = (log_v - log_min_l) / (log_max_l - log_min_l)
            return pad_left + ratio * plot_w

        def map_y(f_val):
            ratio = (f_val - min_f) / (max_f - min_f)
            return pad_top + (1.0 - ratio) * plot_h

        # Build path
        pts_svg = [f"{map_x(p.get('length', 1.0)):.1f},{map_y(p.get('load_factor', 1.0)):.1f}" for p in curve_points]
        path_d = "M " + " L ".join(pts_svg)

        # Minima points (Local, Distortional, Global)
        l_local = float(fsm_data.get("l_local", 60.0))
        p_crl_ratio = float(fsm_data.get("p_crl_ratio", fsm_data.get("min_local", 0.85)))
        l_dist = float(fsm_data.get("l_distortional", 350.0))
        p_crd_ratio = float(fsm_data.get("p_crd_ratio", fsm_data.get("min_distortional", 0.72)))
        l_glob = float(fsm_data.get("l_global", 1500.0))
        p_cre_ratio = float(fsm_data.get("p_cre_ratio", fsm_data.get("min_global", 0.45)))

        minima_markers = []
        if min_l <= l_local <= max_l:
            mx, my = map_x(l_local), map_y(p_crl_ratio)
            minima_markers.append(
                f'<circle cx="{mx:.1f}" cy="{my:.1f}" r="5" fill="#dc2626" stroke="#fff" stroke-width="1.5"/>'
                f'<text x="{mx:.1f}" y="{my-8:.1f}" font-size="8" font-weight="bold" fill="#dc2626" text-anchor="middle">Local ({l_local:.0f}mm, {p_crl_ratio:.2f})</text>'
            )
        if min_l <= l_dist <= max_l:
            mx, my = map_x(l_dist), map_y(p_crd_ratio)
            minima_markers.append(
                f'<circle cx="{mx:.1f}" cy="{my:.1f}" r="5" fill="#2563eb" stroke="#fff" stroke-width="1.5"/>'
                f'<text x="{mx:.1f}" y="{my-8:.1f}" font-size="8" font-weight="bold" fill="#2563eb" text-anchor="middle">Dist ({l_dist:.0f}mm, {p_crd_ratio:.2f})</text>'
            )

        # Grid and axes
        grid_lines = []
        for p10 in [10, 50, 100, 500, 1000, 5000]:
            if min_l <= p10 <= max_l:
                gx = map_x(p10)
                grid_lines.append(f'<line x1="{gx:.1f}" y1="{pad_top}" x2="{gx:.1f}" y2="{pad_top+plot_h}" stroke="#e2e8f0" stroke-dasharray="2,2"/>')
                grid_lines.append(f'<text x="{gx:.1f}" y="{pad_top+plot_h+14}" font-size="8" fill="#64748b" text-anchor="middle">{p10}</text>')

        for f_val in [0.5, 1.0, 1.5, 2.0, 2.5]:
            if min_f <= f_val <= max_f:
                gy = map_y(f_val)
                grid_lines.append(f'<line x1="{pad_left}" y1="{gy:.1f}" x2="{pad_left+plot_w}" y2="{gy:.1f}" stroke="#e2e8f0" stroke-dasharray="2,2"/>')
                grid_lines.append(f'<text x="{pad_left-6}" y="{gy+3:.1f}" font-size="8" fill="#64748b" text-anchor="end">{f_val:.1f}</text>')

        svg = f'''<svg viewBox="0 0 {width} {height}" width="100%" height="100%" xmlns="http://www.w3.org/2000/svg" style="max-height:{height}px;">
  <rect x="0" y="0" width="{width}" height="{height}" fill="#fafbfc" rx="4"/>
  <rect x="{pad_left}" y="{pad_top}" width="{plot_w}" height="{plot_h}" fill="#ffffff" stroke="#cbd5e1"/>
  {''.join(grid_lines)}
  <path d="{path_d}" fill="none" stroke="#1e3a8a" stroke-width="2.2" stroke-linejoin="round"/>
  {''.join(minima_markers)}
  <text x="{pad_left + plot_w/2}" y="{height - 6}" font-size="9" font-weight="bold" fill="#334155" text-anchor="middle">Half-Wavelength L (mm, Log Scale)</text>
  <text x="12" y="{pad_top + plot_h/2}" font-size="9" font-weight="bold" fill="#334155" transform="rotate(-90 12 {pad_top + plot_h/2})" text-anchor="middle">Elastic Buckling Ratio Pcr/Py</text>
</svg>'''
        return svg
