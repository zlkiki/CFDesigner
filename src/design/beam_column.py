"""
Beam-Column Interaction (P-M Interaction) Design Module
Implements KDS 14 31 10 4.5 & AISI S100-16 Chapter H.
"""

from dataclasses import dataclass


@dataclass
class InteractionResult:
    dcr_overall: float = 0.0     # Overall stability interaction ratio
    dcr_cross_section: float = 0.0 # Section strength interaction ratio
    is_safe: bool = True
    controlling_dcr: float = 0.0


class BeamColumnInteraction:
    """
    Evaluates combined compressive axial load and biaxial bending moments.
    """

    @staticmethod
    def check_interaction(
        pu: float,           # Factored axial compressive force
        phi_pn: float,       # Design axial strength
        mux: float,          # Factored bending moment X
        phi_mnx: float,      # Design bending moment strength X
        muy: float,          # Factored bending moment Y
        phi_mny: float,      # Design bending moment strength Y
        cmx: float = 1.0,    # Moment gradient factor
        cmy: float = 1.0,
    ) -> InteractionResult:
        res = InteractionResult()

        ratio_p = pu / phi_pn if phi_pn > 1e-6 else 0.0
        ratio_mx = (cmx * mux) / phi_mnx if phi_mnx > 1e-6 else 0.0
        ratio_my = (cmy * muy) / phi_mny if phi_mny > 1e-6 else 0.0

        # Overall member stability interaction
        res.dcr_overall = ratio_p + ratio_mx + ratio_my
        # Cross-section yield interaction at support
        res.dcr_cross_section = ratio_p + (mux / phi_mnx if phi_mnx > 0 else 0) + (muy / phi_mny if phi_mny > 0 else 0)

        res.controlling_dcr = max(res.dcr_overall, res.dcr_cross_section)
        res.is_safe = res.controlling_dcr <= 1.0
        return res
