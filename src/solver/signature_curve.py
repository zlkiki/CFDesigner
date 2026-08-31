"""
Signature Curve Analyzer
Performs half-wavelength sweep to construct the elastic buckling signature curve
and automatically identifies Local (Pcrl), Distortional (Pcrd), and Global (Pcre) buckling modes.
"""

from dataclasses import dataclass, field
from typing import List, Tuple, Dict
import numpy as np
from .strip_assembler import StripAssembler
from .eigen_solver import FSMEigenSolver


@dataclass
class BucklingPoint:
    length: float       # Half-wavelength L
    load_factor: float  # Critical load factor (LF = Pcr / Py)
    critical_load: float = 0.0 # Pcr (N or kips)
    critical_moment: float = 0.0 # Mcr (N-mm or kip-in)


@dataclass
class BucklingCurveResult:
    lengths: List[float] = field(default_factory=list)
    load_factors: List[float] = field(default_factory=list)
    points: List[BucklingPoint] = field(default_factory=list)

    # Key Buckling Modes
    p_crl: float = 0.0  # Elastic local buckling load
    l_local: float = 0.0 # Half-wavelength for local mode
    
    p_crd: float = 0.0  # Elastic distortional buckling load
    l_distortional: float = 0.0 # Half-wavelength for distortional mode

    p_cre: float = 0.0  # Elastic global buckling load (at specified member length)
    l_global: float = 0.0


class SignatureCurveAnalyzer:
    """
    Sweeps half-wavelengths across logarithmic intervals and classifies buckling modes.
    """

    def __init__(self, assembler: StripAssembler):
        self.assembler = assembler

    def analyze(
        self,
        l_min: float = 10.0,
        l_max: float = 5000.0,
        num_points: int = 35,
        load_type: str = "compression",
        yield_stress: float = 345.0,  # MPa (Fy)
        member_length: float = 3000.0, # Unbraced length for global mode
    ) -> BucklingCurveResult:
        """
        Runs the full FSM sweep and extracts critical buckling modes.
        """
        self.assembler.apply_loading(load_type=load_type)
        sweep_lengths = np.logspace(np.log10(l_min), np.log10(l_max), num_points)

        res = BucklingCurveResult()
        p_y = self.assembler.props.area * yield_stress
        m_y = self.assembler.props.sx_top * yield_stress

        for l_val in sweep_lengths:
            ke, kg = self.assembler.assemble_matrices(half_wavelength=float(l_val))
            lf, _ = FSMEigenSolver.solve_min_eigenvalue(ke, kg)

            if not np.isinf(lf) and lf > 0:
                p_cr = lf * p_y
                m_cr = lf * m_y
                pt = BucklingPoint(length=float(l_val), load_factor=float(lf), critical_load=float(p_cr), critical_moment=float(m_cr))
                res.lengths.append(float(l_val))
                res.load_factors.append(float(lf))
                res.points.append(pt)

        # Detect Local and Distortional minima
        self._classify_modes(res, p_y, member_length)
        return res

    def _classify_modes(self, res: BucklingCurveResult, p_y: float, target_l_global: float):
        """
        Identifies local (1st valley), distortional (2nd valley), and global buckling values.
        """
        if len(res.load_factors) < 3:
            return

        lfs = np.array(res.load_factors)
        lens = np.array(res.lengths)

        # Find local minima (valleys in signature curve)
        minima_indices = []
        for i in range(1, len(lfs) - 1):
            if lfs[i] <= lfs[i - 1] and lfs[i] <= lfs[i + 1]:
                minima_indices.append(i)

        if len(minima_indices) == 0:
            # Monotonically increasing or decreasing
            res.p_crl = float(lfs[0] * p_y)
            res.l_local = float(lens[0])
            res.p_crd = float(lfs[0] * p_y)
            res.l_distortional = float(lens[0])
        elif len(minima_indices) == 1:
            idx = minima_indices[0]
            res.p_crl = float(lfs[idx] * p_y)
            res.l_local = float(lens[idx])
            # If length is large, it could be distortional; if small, local
            if lens[idx] < 150.0:
                res.p_crd = float(lfs[idx] * p_y)
                res.l_distortional = float(lens[idx])
            else:
                res.p_crd = float(lfs[idx] * p_y)
                res.l_distortional = float(lens[idx])
        else:
            # 1st minimum: Local, 2nd minimum: Distortional
            idx1 = minima_indices[0]
            idx2 = minima_indices[1]
            res.p_crl = float(lfs[idx1] * p_y)
            res.l_local = float(lens[idx1])
            res.p_crd = float(lfs[idx2] * p_y)
            res.l_distortional = float(lens[idx2])

        # Global buckling at member length
        ke_g, kg_g = self.assembler.assemble_matrices(half_wavelength=target_l_global)
        lf_g, _ = FSMEigenSolver.solve_min_eigenvalue(ke_g, kg_g)
        res.p_cre = float(lf_g * p_y) if not np.isinf(lf_g) else float(p_y)
        res.l_global = target_l_global
