"""
Direct Strength Method (DSM) Beam Flexure Design
Implements KDS 14 31 10 4.2 & AISI S100-16 Chapter F.
"""

from dataclasses import dataclass
import math


@dataclass
class FlexureDesignResult:
    my: float = 0.0          # Yield moment Sf * Fy (N-mm or kip-in)
    mne: float = 0.0         # Lateral-torsional buckling strength
    mnl: float = 0.0         # Local buckling flexural strength
    mnd: float = 0.0         # Distortional buckling flexural strength
    mn: float = 0.0          # Nominal flexural strength = min(mne, mnl, mnd)
    phi_mn: float = 0.0      # LRFD Design flexural strength (phi_b = 0.90)
    mn_omega: float = 0.0    # ASD Allowable flexural strength (Omega = 1.67)
    
    governing_mode: str = "" # "Lateral-Torsional (Mne)", "Local (Mnl)", or "Distortional (Mnd)"


class DSMFlexure:
    """
    Evaluates nominal and design flexural bending strength under KDS / AISI DSM rules.
    """

    PHI_B = 0.90   # LRFD / KDS Resistance Factor
    OMEGA_B = 1.67 # ASD Safety Factor

    @staticmethod
    def design_beam(
        sf: float,
        fy: float,
        m_cre: float,
        m_crl: float,
        m_crd: float,
        phi_b: float = PHI_B,
        omega_b: float = OMEGA_B,
    ) -> FlexureDesignResult:
        res = FlexureDesignResult()
        m_y = sf * fy
        res.my = m_y

        # 1. Lateral-Torsional Buckling Strength (Mne)
        if m_cre < 0.56 * m_y:
            m_ne = m_cre
        elif m_cre <= 2.78 * m_y:
            m_ne = (10.0 / 9.0) * m_y * (1.0 - (10.0 * m_y) / (36.0 * m_cre))
        else:
            m_ne = m_y
        res.mne = m_ne

        # 2. Local Buckling Flexural Strength (Mnl)
        if m_crl > 1e-9:
            lambda_l = math.sqrt(m_ne / m_crl)
        else:
            lambda_l = 0.0

        if lambda_l <= 0.776:
            m_nl = m_ne
        else:
            ratio_l = m_crl / m_ne
            m_nl = (1.0 - 0.15 * (ratio_l ** 0.4)) * (ratio_l ** 0.4) * m_ne
        res.mnl = m_nl

        # 3. Distortional Buckling Flexural Strength (Mnd)
        if m_crd > 1e-9:
            lambda_d = math.sqrt(m_y / m_crd)
        else:
            lambda_d = 0.0

        if lambda_d <= 0.673:
            m_nd = m_y
        else:
            ratio_d = m_crd / m_y
            m_nd = (1.0 - 0.22 * (ratio_d ** 0.5)) * (ratio_d ** 0.5) * m_y
        res.mnd = m_nd

        # 4. Controlling Nominal Strength
        m_n = min(m_ne, m_nl, m_nd)
        res.mn = m_n
        res.phi_mn = phi_b * m_n
        res.mn_omega = m_n / omega_b

        if m_n == m_nl:
            res.governing_mode = "Local Buckling (Mnl)"
        elif m_n == m_nd:
            res.governing_mode = "Distortional Buckling (Mnd)"
        else:
            res.governing_mode = "Lateral-Torsional Buckling (Mne)"

        return res
