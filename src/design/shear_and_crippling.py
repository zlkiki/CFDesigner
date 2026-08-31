"""
Web Shear and Web Crippling Design Module
Implements KDS 14 31 10 4.3 (Shear) & 4.4 (Web Crippling).
"""

from dataclasses import dataclass
import math


@dataclass
class ShearCripplingResult:
    vn: float = 0.0          # Nominal shear strength (N or kips)
    phi_vn: float = 0.0      # LRFD Design shear strength (phi_v = 0.90)
    
    pnc: float = 0.0         # Nominal web crippling strength (N or kips)
    phi_pnc: float = 0.0     # LRFD Design web crippling strength (phi_w = 0.85)


class WebShearAndCrippling:
    """
    Evaluates web shear and concentrated load web crippling strength.
    """

    PHI_V = 0.90
    PHI_W = 0.85

    @staticmethod
    def calculate_shear(
        h: float,           # Web depth
        t: float,           # Web thickness
        fy: float,          # Yield strength
        e_mod: float = 205000.0,
        kv: float = 5.34,   # Shear buckling coefficient (unreinforced web = 5.34)
    ) -> float:
        if h <= 0 or t <= 0:
            return 0.0

        aw = h * t
        h_over_t = h / t
        limit1 = math.sqrt(e_mod * kv / fy)
        limit2 = 1.51 * limit1

        if h_over_t <= limit1:
            vn = 0.60 * aw * fy
        elif h_over_t <= limit2:
            vn = 0.60 * aw * math.sqrt(e_mod * kv * fy) / h_over_t
        else:
            f_crv = (math.pi ** 2 * e_mod * kv) / (12.0 * (1.0 - 0.3 ** 2) * (h_over_t ** 2))
            vn = aw * f_crv

        return vn

    @staticmethod
    def calculate_web_crippling(
        h: float,           # Web depth
        t: float,           # Web thickness
        r: float,           # Inside bend radius
        n_bearing: float,   # Bearing length
        fy: float,          # Yield strength
        condition: str = "end_one_flange", # "end_one_flange", "interior_one_flange"
    ) -> float:
        # Standard coefficients from KDS / AISI Table C3.4.1-1 (Fastened/Unfastened C-sections)
        if condition == "interior_one_flange":
            c, c_r, c_n, c_h = 13.0, 0.23, 0.14, 0.01
        else:  # end_one_flange
            c, c_r, c_n, c_h = 4.0, 0.14, 0.35, 0.02

        theta = math.radians(90.0) # 90 degree web
        pnc = c * (t ** 2) * fy * math.sin(theta) * (
            1.0 - c_r * math.sqrt(r / t)
        ) * (
            1.0 + c_n * math.sqrt(n_bearing / t)
        ) * (
            1.0 - c_h * math.sqrt(h / t)
        )
        return max(pnc, 0.0)
