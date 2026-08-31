"""
Direct Strength Method (DSM) Column Compression Design
Implements KDS 14 31 10 4.1 & AISI S100-16 Chapter E.
"""

from dataclasses import dataclass
import math


@dataclass
class CompressionDesignResult:
    py: float = 0.0          # Squash load Ag * Fy (N or kips)
    pne: float = 0.0         # Global buckling strength (N or kips)
    pnl: float = 0.0         # Local buckling strength (N or kips)
    pnd: float = 0.0         # Distortional buckling strength (N or kips)
    pn: float = 0.0          # Nominal compressive strength = min(pne, pnl, pnd)
    phi_pn: float = 0.0      # LRFD Design compressive strength (phi_c = 0.85)
    pn_omega: float = 0.0    # ASD Allowable compressive strength (Omega = 1.80)
    
    lambda_c: float = 0.0    # Global slenderness sqrt(Py / Pcre)
    lambda_l: float = 0.0    # Local slenderness sqrt(Pne / Pcrl)
    lambda_d: float = 0.0    # Distortional slenderness sqrt(Py / Pcrd)
    governing_mode: str = "" # "Global", "Local", or "Distortional"


class DSMCompression:
    """
    Evaluates nominal and design compressive axial strength under KDS / AISI DSM rules.
    """

    PHI_C = 0.85   # LRFD / KDS Resistance Factor
    OMEGA_C = 1.80 # ASD Safety Factor

    @staticmethod
    def design_column(
        ag: float,
        fy: float,
        p_cre: float,
        p_crl: float,
        p_crd: float,
        phi_c: float = PHI_C,
        omega_c: float = OMEGA_C,
    ) -> CompressionDesignResult:
        res = CompressionDesignResult()
        p_y = ag * fy
        res.py = p_y

        # 1. Global Buckling Strength (Pne)
        if p_cre > 1e-9:
            lambda_c = math.sqrt(p_y / p_cre)
        else:
            lambda_c = 10.0
        res.lambda_c = lambda_c

        if lambda_c <= 1.5:
            p_ne = (0.658 ** (lambda_c ** 2)) * p_y
        else:
            p_ne = (0.877 / (lambda_c ** 2)) * p_y
        res.pne = p_ne

        # 2. Local Buckling Strength (Pnl)
        if p_crl > 1e-9:
            lambda_l = math.sqrt(p_ne / p_crl)
        else:
            lambda_l = 0.0
        res.lambda_l = lambda_l

        if lambda_l <= 0.776:
            p_nl = p_ne
        else:
            ratio_l = p_crl / p_ne
            p_nl = (1.0 - 0.15 * (ratio_l ** 0.4)) * (ratio_l ** 0.4) * p_ne
        res.pnl = p_nl

        # 3. Distortional Buckling Strength (Pnd)
        if p_crd > 1e-9:
            lambda_d = math.sqrt(p_y / p_crd)
        else:
            lambda_d = 0.0
        res.lambda_d = lambda_d

        if lambda_d <= 0.561:
            p_nd = p_y
        else:
            ratio_d = p_crd / p_y
            p_nd = (1.0 - 0.25 * (ratio_d ** 0.6)) * (ratio_d ** 0.6) * p_y
        res.pnd = p_nd

        # 4. Controlling Nominal Strength
        p_n = min(p_ne, p_nl, p_nd)
        res.pn = p_n
        res.phi_pn = phi_c * p_n
        res.pn_omega = p_n / omega_c

        if p_n == p_nl:
            res.governing_mode = "Local Buckling (Pnl)"
        elif p_n == p_nd:
            res.governing_mode = "Distortional Buckling (Pnd)"
        else:
            res.governing_mode = "Global Buckling (Pne)"

        return res
