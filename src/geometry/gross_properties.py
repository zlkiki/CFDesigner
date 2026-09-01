"""
Gross Cross-Sectional Properties Calculation Engine
Computes Area (A), Moments of Inertia (Ix, Iy, Ixy), Principal axes (I1, I2, theta),
Radii of Gyration (rx, ry, ro), Torsion Constant (J), Warping Constant (Cw), and Shear Center (x0, y0).
"""

from dataclasses import dataclass
import math
from typing import List, Tuple
from ..cad.part_mesher import SectionGeometry, Element


@dataclass
class GrossProperties:
    # Basic properties
    area: float = 0.0          # Ag (mm² or in²)
    weight: float = 0.0        # kg/m or lb/ft
    xcg: float = 0.0           # Global CG X
    ycg: float = 0.0           # Global CG Y

    # Moments of Inertia
    ix: float = 0.0            # Ix (mm⁴ or in⁴)
    iy: float = 0.0            # Iy
    ixy: float = 0.0           # Ixy
    rx: float = 0.0            # Radius of gyration rx (mm or in)
    ry: float = 0.0            # Radius of gyration ry

    # Principal Axis Properties
    theta_p: float = 0.0       # Principal angle (deg)
    i1: float = 0.0            # Major principal moment of inertia
    i2: float = 0.0            # Minor principal moment of inertia
    r1: float = 0.0            # Major principal radius of gyration
    r2: float = 0.0            # Minor principal radius of gyration

    # Section Moduli
    sx_top: float = 0.0        # Elastic section modulus top
    sx_bot: float = 0.0        # Elastic section modulus bottom
    sy_left: float = 0.0       # Elastic section modulus left
    sy_right: float = 0.0      # Elastic section modulus right

    # Torsional & Warping Properties
    j: float = 0.0             # Saint-Venant Torsion Constant (J)
    cw: float = 0.0            # Warping Constant (Cw)
    x0: float = 0.0            # Shear Center X relative to CG
    y0: float = 0.0            # Shear Center Y relative to CG
    ro: float = 0.0            # Polar radius of gyration sqrt(rx² + ry² + x0² + y0²)
    beta_w: float = 0.0        # Monosymmetry parameter


class SectionPropertiesCalculator:
    """
    Calculates all geometric and sectorial properties of cold-formed sections.
    """

    @staticmethod
    def calculate(geom: SectionGeometry) -> GrossProperties:
        if not geom.elements:
            return GrossProperties()

        props = GrossProperties()
        t = geom.thickness

        # 1. Total Area & Centroid (xcg, ycg)
        total_a = 0.0
        sum_x_a = 0.0
        sum_y_a = 0.0

        for elem in geom.elements:
            l = elem.length
            elem_a = l * t
            total_a += elem_a
            mid_x = (elem.x0 + elem.x1) / 2.0
            mid_y = (elem.y0 + elem.y1) / 2.0
            sum_x_a += elem_a * mid_x
            sum_y_a += elem_a * mid_y

        xcg = (sum_x_a / total_a) if total_a > 1e-9 else 0.0
        ycg = (sum_y_a / total_a) if total_a > 1e-9 else 0.0
        props.area = total_a
        props.weight = total_a * 7.85e-3  # kg/m for steel (density = 7.85 g/cm³)
        props.xcg = xcg
        props.ycg = ycg

        # 2. Centroidal Moments of Inertia (Parallel Axis Theorem)
        sum_ix = 0.0
        sum_iy = 0.0
        sum_ixy = 0.0

        min_x, max_x = 1e9, -1e9
        min_y, max_y = 1e9, -1e9

        for elem in geom.elements:
            l = elem.length
            elem_a = l * t
            dx = elem.x1 - elem.x0
            dy = elem.y1 - elem.y0
            
            # Centroid-relative midpoint
            mid_xc = ((elem.x0 + elem.x1) / 2.0) - xcg
            mid_yc = ((elem.y0 + elem.y1) / 2.0) - ycg

            min_x = min(min_x, elem.x0 - xcg, elem.x1 - xcg)
            max_x = max(max_x, elem.x0 - xcg, elem.x1 - xcg)
            min_y = min(min_y, elem.y0 - ycg, elem.y1 - ycg)
            max_y = max(max_y, elem.y0 - ycg, elem.y1 - ycg)

            # Local moments of inertia (Thin-walled bar element formula with centroidal shift)
            sum_ix += (t * dy * dy * l / 12.0) + elem_a * mid_yc * mid_yc
            sum_iy += (t * dx * dx * l / 12.0) + elem_a * mid_xc * mid_xc
            sum_ixy += (t * dx * dy * l / 12.0) + elem_a * mid_xc * mid_yc

        props.ix = sum_ix
        props.iy = sum_iy
        props.ixy = sum_ixy

        # Radii of Gyration
        props.rx = math.sqrt(max(props.ix / total_a, 0.0))
        props.ry = math.sqrt(max(props.iy / total_a, 0.0))

        # Principal Properties & Alpha
        if abs(props.ix - props.iy) < 1e-5:
            if abs(props.ixy) / (props.ix + props.iy + 1e-9) < 1e-4:
                alpha_rad = 0.0
            else:
                alpha_rad = -math.copysign(1.0, props.ixy) * math.pi / 4.0
        else:
            alpha_rad = math.atan2(2.0 * props.ixy, props.iy - props.ix) / 2.0
            if props.ix < props.iy:
                alpha_rad += math.pi / 2.0
            if alpha_rad > math.pi / 2.0:
                alpha_rad -= math.pi

        props.theta_p = math.degrees(alpha_rad)

        diff = (props.ix - props.iy) / 2.0
        r_mohr = math.sqrt(diff * diff + props.ixy * props.ixy)
        props.i1 = (props.ix + props.iy) / 2.0 + r_mohr
        props.i2 = (props.ix + props.iy) / 2.0 - r_mohr
        props.r1 = math.sqrt(max(props.i1 / total_a, 0.0))
        props.r2 = math.sqrt(max(props.i2 / total_a, 0.0))

        # Section Moduli (relative to Centroid)
        c_top = max_y + t / 2.0
        c_bot = abs(min_y - t / 2.0)
        c_right = max_x + t / 2.0
        c_left = abs(min_x - t / 2.0)

        props.sx_top = props.ix / c_top if c_top > 1e-6 else 0.0
        props.sx_bot = props.ix / c_bot if c_bot > 1e-6 else 0.0
        props.sy_right = props.iy / c_right if c_right > 1e-6 else 0.0
        props.sy_left = props.iy / c_left if c_left > 1e-6 else 0.0

        # Torsion Constant (J)
        if geom.is_closed:
            nodes = [(elem.x0 - xcg, elem.y0 - ycg) for elem in geom.elements]
            n_n = len(nodes)
            am = 0.5 * abs(sum(nodes[i][0] * nodes[(i + 1) % n_n][1] - nodes[(i + 1) % n_n][0] * nodes[i][1] for i in range(n_n)))
            sum_ds_t = sum(elem.length / elem.thickness for elem in geom.elements)
            props.j = 4.0 * am * am / sum_ds_t if sum_ds_t > 1e-9 else 0.0
        else:
            props.j = sum((1.0 / 3.0) * elem.length * (elem.thickness ** 3) for elem in geom.elements)

        # Check Point Symmetry relative to Centroid
        is_point_sym = False
        if len(geom.elements) >= 3:
            matched = 0
            for e1 in geom.elements:
                m1x = (e1.x0 + e1.x1)/2.0 - xcg
                m1y = (e1.y0 + e1.y1)/2.0 - ycg
                for e2 in geom.elements:
                    m2x = (e2.x0 + e2.x1)/2.0 - xcg
                    m2y = (e2.y0 + e2.y1)/2.0 - ycg
                    if abs(m1x + m2x) < 1e-3 and abs(m1y + m2y) < 1e-3 and abs(e1.length - e2.length) < 1e-3:
                        matched += 1
                        break
            if matched == len(geom.elements):
                is_point_sym = True

        if is_point_sym:
            props.x0 = 0.0
            props.y0 = 0.0
            SectionPropertiesCalculator._compute_cw_only(geom, props, xcg, ycg)
        else:
            SectionPropertiesCalculator._compute_warping_principal(geom, props, alpha_rad, xcg, ycg)

        # Polar radius of gyration
        props.ro = math.sqrt(props.rx * props.rx + props.ry * props.ry + props.x0 * props.x0 + props.y0 * props.y0)
        return props

    @staticmethod
    def _compute_cw_only(geom: SectionGeometry, props: GrossProperties, xcg: float = 0.0, ycg: float = 0.0):
        """
        Computes Cw for point symmetric sections where shear center is at the centroid.
        """
        t = geom.thickness
        w_accum = 0.0
        w_vals = [0.0]
        for elem in geom.elements:
            ex0 = elem.x0 - xcg
            ey0 = elem.y0 - ycg
            h_p = ex0 * math.sin(elem.angle) - ey0 * math.cos(elem.angle)
            w_accum += h_p * elem.length
            w_vals.append(w_accum)

        w_avg = sum((w_vals[i] + w_vals[i+1])/2.0 * elem.length for i, elem in enumerate(geom.elements)) / geom.total_length
        cw = 0.0
        for i, elem in enumerate(geom.elements):
            w_i = w_vals[i] - w_avg
            w_j = w_vals[i+1] - w_avg
            cw += (elem.length * t / 3.0) * (w_i**2 + w_i*w_j + w_j**2)
        props.cw = max(cw, 0.0)

    @staticmethod
    def _compute_warping_principal(geom: SectionGeometry, props: GrossProperties, alpha: float, xcg: float = 0.0, ycg: float = 0.0):
        """
        Computes Shear Center (x0, y0) and Warping Constant (Cw) in the Principal Axis
        coordinate system for open thin-walled sections (ported from CFS.exe RSG.CFS.Part.TorsionProp).
        """
        if geom.is_closed or len(geom.elements) < 2:
            props.x0 = 0.0
            props.y0 = 0.0
            props.cw = 0.0
            return

        cos_a = math.cos(alpha)
        sin_a = math.sin(alpha)
        t = geom.thickness

        p_elems = []
        p_ix = 0.0
        p_iy = 0.0
        total_l = 0.0

        for elem in geom.elements:
            ex0 = elem.x0 - xcg
            ey0 = elem.y0 - ycg
            ex1 = elem.x1 - xcg
            ey1 = elem.y1 - ycg

            # Rotate element coordinates into Principal axes
            px0 = ex0 * cos_a + ey0 * sin_a
            py0 = -ex0 * sin_a + ey0 * cos_a
            px1 = ex1 * cos_a + ey1 * sin_a
            py1 = -ex1 * sin_a + ey1 * cos_a
            p_ang = elem.angle - alpha
            l = elem.length
            ea = l * t
            total_l += l

            dx = px1 - px0
            dy = py1 - py0
            mid_x = (px0 + px1) / 2.0
            mid_y = (py0 + py1) / 2.0
            p_ix += (t * dy * dy * l / 12.0) + ea * mid_y * mid_y
            p_iy += (t * dx * dx * l / 12.0) + ea * mid_x * mid_x
            p_elems.append((px0, py0, px1, py1, l, p_ang))

        # Integrate sectorial moments (including thickness t)
        sum_y_int = 0.0  # I_w_py (for xo_p)
        sum_x_int = 0.0  # I_w_px (for yo_p)
        w = 0.0

        for px0, py0, px1, py1, l, p_ang in p_elems:
            sin_p = math.sin(p_ang)
            cos_p = math.cos(p_ang)
            hp = px0 * sin_p - py0 * cos_p

            sum_y_int += t * (w * py0 * l + (w * sin_p + hp * py0) * (l ** 2) / 2.0 + (hp * sin_p) * (l ** 3) / 3.0)
            sum_x_int += t * (w * px0 * l + (w * cos_p + hp * px0) * (l ** 2) / 2.0 + (hp * cos_p) * (l ** 3) / 3.0)
            w += hp * l

        xo_p = (sum_y_int / p_ix) if p_ix > 1e-9 else 0.0
        yo_p = (-sum_x_int / p_iy) if p_iy > 1e-9 else 0.0

        # Transform Shear Center back to original section coordinate system relative to CG
        props.x0 = xo_p * cos_a - yo_p * sin_a
        props.y0 = xo_p * sin_a + yo_p * cos_a

        # Clean numerical jitter near zero for symmetric axes
        if abs(props.x0) < 1e-4:
            props.x0 = 0.0
        if abs(props.y0) < 1e-4:
            props.y0 = 0.0

        # Sectorial coordinate & Warping constant Cw about SC
        cw_sum = 0.0
        w_sc_accum = 0.0
        w_avg = 0.0

        for px0, py0, px1, py1, l, p_ang in p_elems:
            sin_p = math.sin(p_ang)
            cos_p = math.cos(p_ang)
            rx0 = px0 - xo_p
            ry0 = py0 - yo_p
            h_sc = rx0 * sin_p - ry0 * cos_p

            cw_sum += (w_sc_accum ** 2) * l + (w_sc_accum * h_sc) * (l ** 2) + (h_sc ** 2) * (l ** 3) / 3.0
            w_avg += w_sc_accum * l + h_sc * (l ** 2) / 2.0
            w_sc_accum += h_sc * l

        w_0 = w_avg / total_l if total_l > 1e-9 else 0.0
        props.cw = max(t * (cw_sum - total_l * (w_0 ** 2)), 0.0)
