"""
Winter Effective Width & Section Properties Calculation Module
Implements AISI S100 Section 1.1 / KDS 14 31 10 4.1.1.1 Effective Width Method.
"""

from dataclasses import dataclass, field
from typing import List, Dict, Any, Tuple, Optional
import math


@dataclass
class EffectiveSegment:
    x1: float
    y1: float
    x2: float
    y2: float
    thickness: float
    is_effective: bool  # True for effective portion, False for void (buckled) portion
    stress: float = 0.0
    rho: float = 1.0


@dataclass
class EffectivePropertiesResult:
    ae: float = 0.0                # Effective Area (mm^2)
    ag: float = 0.0                # Gross Area (mm^2)
    area_ratio: float = 1.0        # Ae / Ag
    
    ixe: float = 0.0               # Effective Moment of Inertia X (mm^4)
    ixg: float = 0.0               # Gross Moment of Inertia X (mm^4)
    
    iye: float = 0.0               # Effective Moment of Inertia Y (mm^4)
    iyg: float = 0.0               # Gross Moment of Inertia Y (mm^4)
    
    xcg_e: float = 0.0             # Effective Centroid X (mm)
    ycg_e: float = 0.0             # Effective Centroid Y (mm)
    delta_x: float = 0.0           # Centroid shift X (mm)
    delta_y: float = 0.0           # Centroid shift Y (mm)
    
    stress_applied: float = 0.0    # Applied stress (MPa)
    moment_axis: str = "X"         # "X", "Y", or "AXIAL"
    
    segments: List[Dict[str, Any]] = field(default_factory=list)
    element_summaries: List[Dict[str, Any]] = field(default_factory=list)


class EffectiveWidthSolver:
    """
    Computes effective width and reduced section properties using Winter's Equation.
    """

    E_MOD = 205000.0  # MPa
    NU = 0.3

    @classmethod
    def calculate_winter_rho(cls, stress: float, width: float, thickness: float, k: float = 4.0) -> Tuple[float, float, float]:
        """
        Calculates Winter's reduction factor rho.
        Returns: (rho, lambda_slenderness, sigma_cr)
        """
        if width <= 0 or thickness <= 0 or stress <= 0:
            return 1.0, 0.0, 0.0

        # Elastic plate buckling stress sigma_cr (MPa)
        # sigma_cr = k * pi^2 * E / (12 * (1 - nu^2)) * (t / w)^2
        coeff = (k * (math.pi ** 2) * cls.E_MOD) / (12.0 * (1.0 - cls.NU ** 2))
        sigma_cr = coeff * ((thickness / width) ** 2)

        if sigma_cr <= 0:
            return 1.0, 0.0, 0.0

        # Slenderness lambda = sqrt(f / sigma_cr)
        lambda_s = math.sqrt(max(stress, 0.0) / sigma_cr)

        if lambda_s <= 0.673:
            rho = 1.0
        else:
            rho = (1.0 - 0.22 / lambda_s) / lambda_s
            rho = max(min(rho, 1.0), 0.0)

        return rho, lambda_s, sigma_cr

    @classmethod
    def analyze_section_effective(
        cls,
        elements: List[Dict[str, Any]],
        gross_props: Optional[Dict[str, Any]] = None,
        stress_f: float = 300.0,
        moment_axis: str = "X",
        fy: float = 300.0,
    ) -> EffectivePropertiesResult:
        """
        Analyzes a multi-element cold-formed section for effective width.
        elements: list of dicts with keys [x1, y1, x2, y2, thickness, (type)]
        """
        if not elements:
            return EffectivePropertiesResult()

        f_applied = min(max(stress_f, 1.0), fy)

        # Calculate Gross Section Properties if not provided
        total_ag = 0.0
        sum_ax = 0.0
        sum_ay = 0.0

        parsed_elems = []
        for i, el in enumerate(elements):
            x1 = float(el.get("x1", 0.0))
            y1 = float(el.get("y1", 0.0))
            x2 = float(el.get("x2", 0.0))
            y2 = float(el.get("y2", 0.0))
            t = float(el.get("thickness", el.get("t", 1.0)))
            dx = x2 - x1
            dy = y2 - y1
            length = math.hypot(dx, dy)
            if length <= 1e-6:
                continue

            mx = (x1 + x2) / 2.0
            my = (y1 + y2) / 2.0
            area = length * t
            total_ag += area
            sum_ax += area * mx
            sum_ay += area * my

            parsed_elems.append({
                "id": i + 1,
                "x1": x1, "y1": y1, "x2": x2, "y2": y2,
                "dx": dx, "dy": dy,
                "length": length, "t": t, "area": area,
                "mx": mx, "my": my
            })

        if total_ag <= 0:
            return EffectivePropertiesResult()

        xcg_g = sum_ax / total_ag
        ycg_g = sum_ay / total_ag

        # Calculate Gross Inertia
        ix_g = 0.0
        iy_g = 0.0
        for pe in parsed_elems:
            # Line element moment of inertia
            l = pe["length"]
            t = pe["t"]
            dx = pe["dx"]
            dy = pe["dy"]
            cos_a = dx / l
            sin_a = dy / l
            # local inertia about element center
            i_local_x = (l ** 3 * t * (sin_a ** 2)) / 12.0
            i_local_y = (l ** 3 * t * (cos_a ** 2)) / 12.0
            # parallel axis theorem
            ix_g += i_local_x + pe["area"] * ((pe["my"] - ycg_g) ** 2)
            iy_g += i_local_y + pe["area"] * ((pe["mx"] - xcg_g) ** 2)

        # Now evaluate compression state and effective width for each element
        effective_segments = []
        element_summaries = []

        total_ae = 0.0
        sum_aex = 0.0
        sum_aey = 0.0

        for pe in parsed_elems:
            l = pe["length"]
            t = pe["t"]
            x1, y1 = pe["x1"], pe["y1"]
            x2, y2 = pe["x2"], pe["y2"]
            dx, dy = pe["dx"], pe["dy"]

            # Determine stress profile on this element based on loading axis
            if moment_axis.upper() == "X":
                # Bending about X-axis: top in compression (y > ycg)
                stress_mid = f_applied * ((pe["my"] - ycg_g) / max(abs(ycg_g), 1.0))
                is_comp = stress_mid > 0
                comp_stress = f_applied if is_comp else 0.0
            elif moment_axis.upper() == "Y":
                # Bending about Y-axis: right or left in compression
                stress_mid = f_applied * ((pe["mx"] - xcg_g) / max(abs(xcg_g), 1.0))
                is_comp = stress_mid > 0
                comp_stress = f_applied if is_comp else 0.0
            else:
                # Uniform axial compression
                is_comp = True
                comp_stress = f_applied

            # Buckling coefficient k
            # If element is web/flange supported both edges -> k=4.0; unstiffened edge -> k=0.43
            k_plate = 4.0

            if is_comp and comp_stress > 1.0:
                rho, lambda_s, sigma_cr = cls.calculate_winter_rho(comp_stress, l, t, k=k_plate)
            else:
                rho, lambda_s, sigma_cr = 1.0, 0.0, 0.0

            be = rho * l
            b_void = max(l - be, 0.0)

            # Split element into effective and ineffective (void) segments
            if rho >= 0.999 or b_void <= 1e-4:
                # Fully effective
                effective_segments.append({
                    "x1": x1, "y1": y1, "x2": x2, "y2": y2,
                    "thickness": t, "is_effective": True, "rho": 1.0, "stress": comp_stress
                })
                ae_elem = pe["area"]
                total_ae += ae_elem
                sum_aex += ae_elem * pe["mx"]
                sum_aey += ae_elem * pe["my"]
            else:
                # Ineffective center portion (Winter 2-edge support reduction)
                # Left effective part: 0 to be/2
                # Void middle part: be/2 to l - be/2
                # Right effective part: l - be/2 to l
                be_half = be / 2.0
                t1 = be_half / l
                t2 = (l - be_half) / l

                p1_x, p1_y = x1, y1
                pa_x = x1 + dx * t1
                pa_y = y1 + dy * t1
                pb_x = x1 + dx * t2
                pb_y = y1 + dy * t2
                p2_x, p2_y = x2, y2

                # Effective part 1
                effective_segments.append({
                    "x1": p1_x, "y1": p1_y, "x2": pa_x, "y2": pa_y,
                    "thickness": t, "is_effective": True, "rho": round(rho, 4), "stress": comp_stress
                })
                # Void part (middle)
                effective_segments.append({
                    "x1": pa_x, "y1": pa_y, "x2": pb_x, "y2": pb_y,
                    "thickness": t, "is_effective": False, "rho": round(rho, 4), "stress": comp_stress
                })
                # Effective part 2
                effective_segments.append({
                    "x1": pb_x, "y1": pb_y, "x2": p2_x, "y2": p2_y,
                    "thickness": t, "is_effective": True, "rho": round(rho, 4), "stress": comp_stress
                })

                ae1 = be_half * t
                m1x = (p1_x + pa_x) / 2.0
                m1y = (p1_y + pa_y) / 2.0
                ae2 = be_half * t
                m2x = (pb_x + p2_x) / 2.0
                m2y = (pb_y + p2_y) / 2.0

                total_ae += ae1 + ae2
                sum_aex += ae1 * m1x + ae2 * m2x
                sum_aey += ae1 * m1y + ae2 * m2y

            element_summaries.append({
                "elem_id": pe["id"],
                "width": round(l, 2),
                "be": round(be, 2),
                "rho": round(rho, 4),
                "lambda": round(lambda_s, 4),
                "sigma_cr": round(sigma_cr, 2),
                "is_compressed": is_comp
            })

        xcg_e = (sum_aex / total_ae) if total_ae > 0 else xcg_g
        ycg_e = (sum_aey / total_ae) if total_ae > 0 else ycg_g

        # Calculate Effective Inertia
        ix_e = 0.0
        iy_e = 0.0
        for seg in effective_segments:
            if not seg["is_effective"]:
                continue
            sx1, sy1 = seg["x1"], seg["y1"]
            sx2, sy2 = seg["x2"], seg["y2"]
            st = seg["thickness"]
            sdx = sx2 - sx1
            sdy = sy2 - sy1
            sl = math.hypot(sdx, sdy)
            if sl <= 1e-6:
                continue
            smx = (sx1 + sx2) / 2.0
            smy = (sy1 + sy2) / 2.0
            s_area = sl * st
            sin_a = sdy / sl
            cos_a = sdx / sl
            i_lx = (sl ** 3 * st * (sin_a ** 2)) / 12.0
            i_ly = (sl ** 3 * st * (cos_a ** 2)) / 12.0
            ix_e += i_lx + s_area * ((smy - ycg_e) ** 2)
            iy_e += i_ly + s_area * ((smx - xcg_e) ** 2)

        return EffectivePropertiesResult(
            ae=round(total_ae, 2),
            ag=round(total_ag, 2),
            area_ratio=round(total_ae / total_ag, 4) if total_ag > 0 else 1.0,
            ixe=round(ix_e, 2),
            ixg=round(ix_g, 2),
            iye=round(iy_e, 2),
            iyg=round(iy_g, 2),
            xcg_e=round(xcg_e, 2),
            ycg_e=round(ycg_e, 2),
            delta_x=round(xcg_e - xcg_g, 3),
            delta_y=round(ycg_e - ycg_g, 3),
            stress_applied=round(f_applied, 2),
            moment_axis=moment_axis.upper(),
            segments=effective_segments,
            element_summaries=element_summaries
        )
