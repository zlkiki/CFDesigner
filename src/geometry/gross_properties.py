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

        # 1. Total Area & Moments of Inertia
        total_a = 0.0
        sum_ix = 0.0
        sum_iy = 0.0
        sum_ixy = 0.0

        min_x, max_x = 1e9, -1e9
        min_y, max_y = 1e9, -1e9

        for elem in geom.elements:
            l = elem.length
            elem_a = l * t
            total_a += elem_a

            dx = elem.x1 - elem.x0
            dy = elem.y1 - elem.y0
            mid_x = (elem.x0 + elem.x1) / 2.0
            mid_y = (elem.y0 + elem.y1) / 2.0

            min_x = min(min_x, elem.x0, elem.x1)
            max_x = max(max_x, elem.x0, elem.x1)
            min_y = min(min_y, elem.y0, elem.y1)
            max_y = max(max_y, elem.y0, elem.y1)

            # Local moments of inertia (Thin-walled bar element formula)
            sum_ix += (t * dy * dy * l / 12.0) + elem_a * mid_y * mid_y
            sum_iy += (t * dx * dx * l / 12.0) + elem_a * mid_x * mid_x
            sum_ixy += (t * dx * dy * l / 12.0) + elem_a * mid_x * mid_y

        props.area = total_a
        props.ix = sum_ix
        props.iy = sum_iy
        props.ixy = sum_ixy

        # Radii of Gyration
        props.rx = math.sqrt(max(props.ix / total_a, 0.0))
        props.ry = math.sqrt(max(props.iy / total_a, 0.0))

        # Principal Properties
        diff = (props.ix - props.iy) / 2.0
        r_mohr = math.sqrt(diff * diff + props.ixy * props.ixy)
        props.i1 = (props.ix + props.iy) / 2.0 + r_mohr
        props.i2 = (props.ix + props.iy) / 2.0 - r_mohr
        props.r1 = math.sqrt(max(props.i1 / total_a, 0.0))
        props.r2 = math.sqrt(max(props.i2 / total_a, 0.0))

        if abs(diff) > 1e-9 or abs(props.ixy) > 1e-9:
            alpha_rad = 0.5 * math.atan2(-2.0 * props.ixy, props.ix - props.iy)
            props.theta_p = math.degrees(alpha_rad)
        else:
            alpha_rad = 0.0
            props.theta_p = 0.0

        # Section Moduli
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
            nodes = [(elem.x0, elem.y0) for elem in geom.elements]
            n_n = len(nodes)
            am = 0.5 * abs(sum(nodes[i][0] * nodes[(i + 1) % n_n][1] - nodes[(i + 1) % n_n][0] * nodes[i][1] for i in range(n_n)))
            sum_ds_t = sum(elem.length / elem.thickness for elem in geom.elements)
            props.j = 4.0 * am * am / sum_ds_t if sum_ds_t > 1e-9 else 0.0
        else:
            props.j = sum((1.0 / 3.0) * elem.length * (elem.thickness ** 3) for elem in geom.elements)

        # Check Point Symmetry: sum(mid_x) ~ 0 and sum(mid_y) ~ 0 for point symmetric pairs
        is_point_sym = False
        if len(geom.elements) >= 3:
            # Check if each element has a point-symmetric counterpart
            matched = 0
            for e1 in geom.elements:
                m1x, m1y = (e1.x0 + e1.x1)/2.0, (e1.y0 + e1.y1)/2.0
                for e2 in geom.elements:
                    m2x, m2y = (e2.x0 + e2.x1)/2.0, (e2.y0 + e2.y1)/2.0
                    if abs(m1x + m2x) < 1e-3 and abs(m1y + m2y) < 1e-3 and abs(e1.length - e2.length) < 1e-3:
                        matched += 1
                        break
            if matched == len(geom.elements):
                is_point_sym = True

        if is_point_sym:
            props.x0 = 0.0
            props.y0 = 0.0
            SectionPropertiesCalculator._compute_cw_only(geom, props)
        else:
            SectionPropertiesCalculator._compute_warping_principal(geom, props, alpha_rad)

        # Polar radius of gyration
        props.ro = math.sqrt(props.rx * props.rx + props.ry * props.ry + props.x0 * props.x0 + props.y0 * props.y0)
        return props

    @staticmethod
    def _compute_cw_only(geom: SectionGeometry, props: GrossProperties):
        """
        Computes Cw for point symmetric sections where shear center is at the centroid (0,0).
        """
        t = geom.thickness
        w_accum = 0.0
        w_vals = [0.0]
        for elem in geom.elements:
            h_p = elem.x0 * math.sin(elem.angle) - elem.y0 * math.cos(elem.angle)
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
    def _compute_warping_principal(geom: SectionGeometry, props: GrossProperties, alpha: float):
        """
        Computes Shear Center and Warping Constant in the Principal Axis coordinate system for singly/asymmetric sections.
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
        for elem in geom.elements:
            px0 = elem.x0 * cos_a - elem.y0 * sin_a
            py0 = elem.x0 * sin_a + elem.y0 * cos_a
            px1 = elem.x1 * cos_a - elem.y1 * sin_a
            py1 = elem.x1 * sin_a + elem.y1 * cos_a
            ang_p = elem.angle - alpha
            p_elems.append((px0, py0, px1, py1, elem.length, ang_p))

            dx = px1 - px0
            dy = py1 - py0
            mid_x = (px0 + px1) / 2.0
            mid_y = (py0 + py1) / 2.0
            p_ix += (t * dy * dy * elem.length / 12.0) + elem.length * t * mid_y * mid_y
            p_iy += (t * dx * dx * elem.length / 12.0) + elem.length * t * mid_x * mid_x

        sum_x_int = 0.0
        sum_y_int = 0.0
        w_accum = 0.0

        for px0, py0, px1, py1, l, ang_p in p_elems:
            sin_p = math.sin(ang_p)
            cos_p = math.cos(ang_p)
            h_p = px0 * sin_p - py0 * cos_p

            sum_x_int += (w_accum * py0 * l + (w_accum * sin_p + h_p * py0) * (l ** 2) / 2.0 + (h_p * sin_p) * (l ** 3) / 3.0)
            sum_y_int += (w_accum * px0 * l + (w_accum * cos_p + h_p * px0) * (l ** 2) / 2.0 + (h_p * cos_p) * (l ** 3) / 3.0)
            w_accum += h_p * l

        x0_p = (sum_x_int / p_iy) if p_iy > 1e-9 else 0.0
        y0_p = (-sum_y_int / p_ix) if p_ix > 1e-9 else 0.0

        props.x0 = x0_p * cos_a - y0_p * sin_a
        props.y0 = x0_p * sin_a + y0_p * cos_a

        cw_sum = 0.0
        w_p_accum = 0.0
        w_avg = 0.0
        total_l = sum(l for _, _, _, _, l, _ in p_elems)

        for px0, py0, px1, py1, l, ang_p in p_elems:
            sin_p = math.sin(ang_p)
            cos_p = math.cos(ang_p)
            rx0 = px0 - x0_p
            ry0 = py0 - y0_p
            h_sc = rx0 * sin_p - ry0 * cos_p

            cw_sum += (w_p_accum ** 2) * l + (w_p_accum * h_sc) * (l ** 2) + (h_sc ** 2) * (l ** 3) / 3.0
            w_avg += w_p_accum * l + h_sc * (l ** 2) / 2.0
            w_p_accum += h_sc * l

        w_0 = w_avg / total_l if total_l > 1e-9 else 0.0
        props.cw = max(t * (cw_sum - total_l * (w_0 ** 2)), 0.0)
