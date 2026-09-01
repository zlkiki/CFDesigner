"""
Web Shear and Web Crippling Design Module
Implements KDS 14 31 10 4.3 (Shear) & 4.4 (Web Crippling) / AISI S100 Section G5.
"""

from dataclasses import dataclass, field
from typing import Dict, Any, Optional
import math


@dataclass
class WebCripplingResult:
    pnc: float = 0.0          # Nominal web crippling strength (N)
    phi_pnc: float = 0.0      # LRFD Design web crippling strength (N)
    omega_pnc: float = 0.0    # ASD Allowable web crippling strength (N)
    phi: float = 0.85         # LRFD Resistance factor
    omega: float = 1.75       # ASD Safety factor
    dc_ratio: float = 0.0     # Demand/Capacity ratio (Ru / phi_Pnc)
    coefficients: Dict[str, float] = field(default_factory=dict)
    formula: str = ""
    notes: str = ""


@dataclass
class ShearCripplingResult:
    vn: float = 0.0          # Nominal shear strength (N)
    phi_vn: float = 0.0      # LRFD Design shear strength (phi_v = 0.90)
    
    pnc: float = 0.0         # Nominal web crippling strength (N)
    phi_pnc: float = 0.0     # LRFD Design web crippling strength
    crippling_details: Optional[WebCripplingResult] = None


class WebShearAndCrippling:
    """
    Evaluates web shear and concentrated load web crippling strength.
    Supports 4 loading conditions: EOF, IOF, ETF, ITF
    Supports Flange Fastened vs Unfastened, Stiffened vs Unstiffened flanges.
    """

    PHI_V = 0.90
    PHI_W = 0.85

    # AISI S100 Table G5-1 / KDS 14 31 10 Table C3.4.1-1 Coefficients
    # Key: (condition, fastened, stiffened) -> (C, C_R, C_N, C_h, phi, omega)
    CRIPPLING_COEFFS = {
        # End-One-Flange (EOF)
        ("EOF", True, True):   (4.0, 0.14, 0.35, 0.02, 0.85, 1.75),
        ("EOF", False, True):  (4.0, 0.40, 0.60, 0.03, 0.85, 1.80),
        ("EOF", True, False):  (4.0, 0.14, 0.35, 0.02, 0.80, 1.85),
        ("EOF", False, False): (4.0, 0.40, 0.60, 0.03, 0.85, 1.80),

        # Interior-One-Flange (IOF)
        ("IOF", True, True):   (13.0, 0.23, 0.14, 0.01, 0.90, 1.65),
        ("IOF", False, True):  (13.0, 0.32, 0.10, 0.01, 0.85, 1.80),
        ("IOF", True, False):  (13.0, 0.23, 0.14, 0.01, 0.90, 1.65),
        ("IOF", False, False): (13.0, 0.32, 0.10, 0.01, 0.85, 1.80),

        # End-Two-Flange (ETF)
        ("ETF", True, True):   (7.5, 0.08, 0.12, 0.048, 0.85, 1.75),
        ("ETF", False, True):  (2.0, 0.11, 0.37, 0.010, 0.75, 2.00),
        ("ETF", True, False):  (13.0, 0.32, 0.05, 0.040, 0.90, 1.65),
        ("ETF", False, False): (2.0, 0.11, 0.37, 0.010, 0.75, 2.00),

        # Interior-Two-Flange (ITF)
        ("ITF", True, True):   (20.0, 0.10, 0.08, 0.031, 0.85, 1.75),
        ("ITF", False, True):  (13.0, 0.47, 0.25, 0.040, 0.80, 1.90),
        ("ITF", True, False):  (24.0, 0.52, 0.15, 0.001, 0.80, 1.90),
        ("ITF", False, False): (13.0, 0.32, 0.10, 0.010, 0.85, 1.80),
    }

    @staticmethod
    def calculate_shear(
        h: float,           # Web depth (mm)
        t: float,           # Web thickness (mm)
        fy: float,          # Yield strength (MPa)
        e_mod: float = 205000.0,
        kv: float = 5.34,   # Shear buckling coefficient
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

    @classmethod
    def calculate_web_crippling_advanced(
        cls,
        h: float,                # Web depth (flat portion, mm)
        t: float,                # Web thickness (mm)
        r: float,                # Inside bend radius (mm)
        n_bearing: float,        # Bearing length (mm)
        fy: float,               # Yield strength (MPa)
        condition: str = "IOF",  # "EOF", "IOF", "ETF", "ITF"
        fastened: bool = True,   # Flange fastened to support
        stiffened: bool = True,  # Stiffened flange (with lip)
        theta_deg: float = 90.0, # Web inclination angle (degrees)
        ru: float = 0.0,         # Required reaction / load (kN)
    ) -> WebCripplingResult:
        """
        Calculates Web Crippling Nominal and Design strengths according to
        KDS 14 31 10 (4.4) / AISI S100 Eq. G5-1.
        """
        cond_upper = condition.upper().strip()
        if "INTERIOR" in cond_upper and "TWO" in cond_upper or cond_upper == "ITF":
            cond_upper = "ITF"
        elif "END" in cond_upper and "TWO" in cond_upper or cond_upper == "ETF":
            cond_upper = "ETF"
        elif "INTERIOR" in cond_upper or cond_upper == "IOF":
            cond_upper = "IOF"
        else:
            cond_upper = "EOF"

        lookup_key = (cond_upper, fastened, stiffened)
        if lookup_key in cls.CRIPPLING_COEFFS:
            c, cr, cn, ch, phi, omega = cls.CRIPPLING_COEFFS[lookup_key]
        else:
            # Fallback default
            c, cr, cn, ch, phi, omega = (13.0, 0.23, 0.14, 0.01, 0.90, 1.65) if cond_upper in ["IOF", "ITF"] else (4.0, 0.14, 0.35, 0.02, 0.85, 1.75)

        r_eff = max(r, 0.0)
        t_eff = max(t, 0.1)
        h_eff = max(h, 1.0)
        n_eff = max(n_bearing, 1.0)
        theta_rad = math.radians(max(min(theta_deg, 90.0), 45.0))

        # Pnc = C * t^2 * Fy * sin(theta) * (1 - C_R*sqrt(R/t)) * (1 + C_N*sqrt(N/t)) * (1 - C_h*sqrt(h/t))
        factor_r = max(1.0 - cr * math.sqrt(r_eff / t_eff), 0.01)
        factor_n = max(1.0 + cn * math.sqrt(n_eff / t_eff), 1.0)
        factor_h = max(1.0 - ch * math.sqrt(h_eff / t_eff), 0.01)

        pnc_n = c * (t_eff ** 2) * fy * math.sin(theta_rad) * factor_r * factor_n * factor_h
        pnc_n = max(pnc_n, 0.0)

        phi_pnc_n = phi * pnc_n
        omega_pnc_n = pnc_n / omega

        # Demand / Capacity
        ru_n = ru * 1000.0  # kN -> N
        dc = (ru_n / phi_pnc_n) if phi_pnc_n > 0 and ru_n > 0 else 0.0

        formula_str = f"Pnc = {c} × t² × Fy × sin({theta_deg}°) × (1 - {cr}√(R/t)) × (1 + {cn}√(N/t)) × (1 - {ch}√(h/t))"

        return WebCripplingResult(
            pnc=pnc_n,
            phi_pnc=phi_pnc_n,
            omega_pnc=omega_pnc_n,
            phi=phi,
            omega=omega,
            dc_ratio=round(dc, 4),
            coefficients={
                "C": c, "C_R": cr, "C_N": cn, "C_h": ch,
                "factor_R": round(factor_r, 4),
                "factor_N": round(factor_n, 4),
                "factor_h": round(factor_h, 4),
            },
            formula=formula_str,
            notes=f"{cond_upper} | {'Fastened' if fastened else 'Unfastened'} | {'Stiffened' if stiffened else 'Unstiffened'}"
        )

    @classmethod
    def calculate_web_crippling(
        cls,
        h: float,
        t: float,
        r: float,
        n_bearing: float,
        fy: float,
        condition: str = "end_one_flange",
    ) -> float:
        """Legacy-compatible interface returning nominal Pnc in N."""
        cond_map = {
            "end_one_flange": "EOF",
            "interior_one_flange": "IOF",
            "end_two_flange": "ETF",
            "interior_two_flange": "ITF",
        }
        c_code = cond_map.get(condition.lower(), "EOF")
        res = cls.calculate_web_crippling_advanced(
            h=h, t=t, r=r, n_bearing=n_bearing, fy=fy, condition=c_code, fastened=True, stiffened=True
        )
        return res.pnc
