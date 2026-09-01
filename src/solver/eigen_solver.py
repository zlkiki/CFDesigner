"""
FSM Generalized Eigenvalue Solver
Solves [Ke] Phi = lambda [Kg] Phi for minimum positive eigenvalue (Load Factor).
"""

from typing import Tuple, Optional, List
import numpy as np
import scipy.linalg


class FSMEigenSolver:
    """
    Robust generalized eigenvalue solver for thin-walled strip assemblies.
    """

    @staticmethod
    def solve_eigenvalues(ke: np.ndarray, kg: np.ndarray, num_modes: int = 3) -> List[Tuple[float, np.ndarray]]:
        """
        Computes the lowest positive load factors (up to num_modes) and corresponding mode shapes.
        Returns a list of tuples: [(lf_1, mode_vec_1), (lf_2, mode_vec_2), ...] sorted by load factor ascending.
        """
        # Ensure symmetric matrices
        ke = (ke + ke.T) / 2.0
        kg = (kg + kg.T) / 2.0

        dof_count = ke.shape[0]
        diag_ke = np.diag(ke)
        active_dofs = np.where(diag_ke > 1e-12)[0]

        if len(active_dofs) < 4:
            return []

        ke_act = ke[np.ix_(active_dofs, active_dofs)]
        kg_act = kg[np.ix_(active_dofs, active_dofs)]

        results: List[Tuple[float, np.ndarray]] = []

        try:
            # Solve generalized eigenvalue problem: Ke * v = lambda * Kg * v
            eigenvalues, eigenvectors = scipy.linalg.eig(ke_act, kg_act)
            
            pos_eigs = []
            for idx, eig in enumerate(eigenvalues):
                if np.isnan(eig) or np.isinf(eig):
                    continue
                abs_real = abs(eig.real)
                abs_imag = abs(eig.imag)
                is_real_enough = (abs_imag < 1e-3) or (abs_real > 1e-4 and abs_imag / abs_real < 1e-2)
                
                if is_real_enough and eig.real > 1e-4:
                    pos_eigs.append((float(eig.real), eigenvectors[:, idx].real))

            if pos_eigs:
                pos_eigs.sort(key=lambda x: x[0])
                for lf, mode_act in pos_eigs[:num_modes]:
                    full_mode = np.zeros(dof_count, dtype=float)
                    full_mode[active_dofs] = mode_act
                    max_disp = np.max(np.abs(full_mode))
                    if max_disp > 1e-9:
                        full_mode /= max_disp
                    results.append((float(lf), full_mode))
                return results

        except Exception:
            pass

        # Fallback using regularized pseudoinverse: pinv(Ke) * Kg
        try:
            inv_ke_kg = np.linalg.pinv(ke_act) @ kg_act
            eigs, vecs = np.linalg.eig(inv_ke_kg)
            
            pos_lfs = []
            for idx, val in enumerate(eigs):
                if np.isnan(val) or np.isinf(val):
                    continue
                abs_real = abs(val.real)
                abs_imag = abs(val.imag)
                is_real_enough = (abs_imag < 1e-3) or (abs_real > 1e-5 and abs_imag / abs_real < 1e-2)
                
                if is_real_enough and val.real > 1e-6:
                    lf = 1.0 / val.real
                    if lf > 1e-4:
                        pos_lfs.append((float(lf), vecs[:, idx].real))

            if pos_lfs:
                pos_lfs.sort(key=lambda x: x[0])
                for lf, mode_act in pos_lfs[:num_modes]:
                    full_mode = np.zeros(dof_count, dtype=float)
                    full_mode[active_dofs] = mode_act
                    max_disp = np.max(np.abs(full_mode))
                    if max_disp > 1e-9:
                        full_mode /= max_disp
                    results.append((float(lf), full_mode))
                return results
        except Exception:
            pass

        return results

    @staticmethod
    def solve_min_eigenvalue(ke: np.ndarray, kg: np.ndarray) -> Tuple[float, Optional[np.ndarray]]:
        """
        Computes the lowest positive load factor lambda and corresponding mode shape.
        """
        modes = FSMEigenSolver.solve_eigenvalues(ke, kg, num_modes=1)
        if modes:
            return modes[0]
        return float("inf"), None

