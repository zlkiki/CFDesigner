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
    load_factor: float  # Critical load factor (LF = Pcr / Py) for Mode 1
    critical_load: float = 0.0 # Pcr (N or kips) for Mode 1
    critical_moment: float = 0.0 # Mcr (N-mm or kip-in) for Mode 1
    # Multi-mode extensions (Mode 1, Mode 2, Mode 3, ...)
    mode_load_factors: List[float] = field(default_factory=list)
    mode_critical_loads: List[float] = field(default_factory=list)
    mode_critical_moments: List[float] = field(default_factory=list)


@dataclass
class BucklingCurveResult:
    lengths: List[float] = field(default_factory=list)
    load_factors: List[float] = field(default_factory=list) # Mode 1 load factors
    points: List[BucklingPoint] = field(default_factory=list)
    load_type: str = "compression"
    
    # Multi-mode curves (mode_index -> list of load factors)
    mode_1_lfs: List[float] = field(default_factory=list)
    mode_2_lfs: List[float] = field(default_factory=list)
    mode_3_lfs: List[float] = field(default_factory=list)

    # Key Buckling Modes (Loads in N)
    p_crl: float = 0.0  # Elastic local buckling load
    l_local: float = 0.0 # Half-wavelength for local mode
    lf_local: float = 0.0
    
    p_crd: float = 0.0  # Elastic distortional buckling load
    l_distortional: float = 0.0 # Half-wavelength for distortional mode
    lf_distortional: float = 0.0

    p_cre: float = 0.0  # Elastic global buckling load (at specified member length)
    l_global: float = 0.0
    lf_global: float = 0.0

    # Key Buckling Moments (N-mm)
    m_crl: float = 0.0
    m_crd: float = 0.0
    m_cre: float = 0.0


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

        res = BucklingCurveResult(load_type=load_type)
        p_y = self.assembler.props.area * yield_stress if self.assembler.props else 1000.0
        
        # Determine Reference Yield Moment My based on load_type
        if load_type == "bending_y":
            m_y = (self.assembler.props.sy_right if (self.assembler.props and self.assembler.props.sy_right > 0) else (self.assembler.props.iy / max(1.0, self.assembler.props.xcg))) * yield_stress
        else:
            m_y = (self.assembler.props.sx_top if (self.assembler.props and self.assembler.props.sx_top > 0) else (self.assembler.props.ix / max(1.0, self.assembler.props.ycg))) * yield_stress

        for l_val in sweep_lengths:
            ke, kg = self.assembler.assemble_matrices(half_wavelength=float(l_val))
            modes = FSMEigenSolver.solve_eigenvalues(ke, kg, num_modes=3)

            if modes:
                lf_1 = modes[0][0]
                if not np.isinf(lf_1) and lf_1 > 0:
                    p_cr_1 = lf_1 * p_y
                    m_cr_1 = lf_1 * m_y

                    m_lfs = [float(m[0]) for m in modes]
                    m_pcrs = [float(m[0] * p_y) for m in modes]
                    m_mcrs = [float(m[0] * m_y) for m in modes]

                    pt = BucklingPoint(
                        length=float(l_val),
                        load_factor=float(lf_1),
                        critical_load=float(p_cr_1),
                        critical_moment=float(m_cr_1),
                        mode_load_factors=m_lfs,
                        mode_critical_loads=m_pcrs,
                        mode_critical_moments=m_mcrs,
                    )
                    res.lengths.append(float(l_val))
                    res.load_factors.append(float(lf_1))
                    res.points.append(pt)

                    res.mode_1_lfs.append(m_lfs[0] if len(m_lfs) > 0 else float(lf_1))
                    res.mode_2_lfs.append(m_lfs[1] if len(m_lfs) > 1 else float(lf_1))
                    res.mode_3_lfs.append(m_lfs[2] if len(m_lfs) > 2 else (m_lfs[1] if len(m_lfs) > 1 else float(lf_1)))

        # Detect Local and Distortional minima
        self._classify_modes(res, p_y, m_y, member_length)
        return res

    def _classify_modes(self, res: BucklingCurveResult, p_y: float, m_y: float, target_l_global: float):
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
            res.lf_local = float(lfs[0])
            res.p_crl = float(lfs[0] * p_y)
            res.m_crl = float(lfs[0] * m_y)
            res.l_local = float(lens[0])

            res.lf_distortional = float(lfs[0])
            res.p_crd = float(lfs[0] * p_y)
            res.m_crd = float(lfs[0] * m_y)
            res.l_distortional = float(lens[0])
        elif len(minima_indices) == 1:
            idx = minima_indices[0]
            res.lf_local = float(lfs[idx])
            res.p_crl = float(lfs[idx] * p_y)
            res.m_crl = float(lfs[idx] * m_y)
            res.l_local = float(lens[idx])

            res.lf_distortional = float(lfs[idx])
            res.p_crd = float(lfs[idx] * p_y)
            res.m_crd = float(lfs[idx] * m_y)
            res.l_distortional = float(lens[idx])
        else:
            # 1st minimum: Local, 2nd minimum: Distortional
            idx1 = minima_indices[0]
            idx2 = minima_indices[1]
            res.lf_local = float(lfs[idx1])
            res.p_crl = float(lfs[idx1] * p_y)
            res.m_crl = float(lfs[idx1] * m_y)
            res.l_local = float(lens[idx1])

            res.lf_distortional = float(lfs[idx2])
            res.p_crd = float(lfs[idx2] * p_y)
            res.m_crd = float(lfs[idx2] * m_y)
            res.l_distortional = float(lens[idx2])

        # Global buckling at member length
        ke_g, kg_g = self.assembler.assemble_matrices(half_wavelength=target_l_global)
        lf_g, _ = FSMEigenSolver.solve_min_eigenvalue(ke_g, kg_g)
        res.lf_global = float(lf_g) if not np.isinf(lf_g) else 1.0
        res.p_cre = float(lf_g * p_y) if not np.isinf(lf_g) else float(p_y)
        res.m_cre = float(lf_g * m_y) if not np.isinf(lf_g) else float(m_y)
        res.l_global = target_l_global
