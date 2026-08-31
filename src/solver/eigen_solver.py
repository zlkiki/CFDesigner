"""
FSM Generalized Eigenvalue Solver
Solves [Ke] Phi = lambda [Kg] Phi for minimum positive eigenvalue (Load Factor).
"""

from typing import Tuple, Optional
import numpy as np
import scipy.linalg


class FSMEigenSolver:
    """
    Robust generalized eigenvalue solver for thin-walled strip assemblies.
    """

    @staticmethod
    def solve_min_eigenvalue(ke: np.ndarray, kg: np.ndarray) -> Tuple[float, Optional[np.ndarray]]:
        """
        Computes the lowest positive load factor lambda and corresponding mode shape.
        """
        # Ensure symmetric matrices
        ke = (ke + ke.T) / 2.0
        kg = (kg + kg.T) / 2.0

        # Remove zero DOFs / fix rigid body translations if needed
        dof_count = ke.shape[0]
        diag_ke = np.diag(ke)
        active_dofs = np.where(diag_ke > 1e-12)[0]

        if len(active_dofs) < 4:
            return float("inf"), None

        ke_act = ke[np.ix_(active_dofs, active_dofs)]
        kg_act = kg[np.ix_(active_dofs, active_dofs)]

        try:
            # Solve generalized eigenvalue problem: Ke * v = lambda * Kg * v
            # Using scipy.linalg.eig
            eigenvalues, eigenvectors = scipy.linalg.eig(ke_act, kg_act)
            
            # Filter real, positive eigenvalues
            pos_eigs = []
            for idx, eig in enumerate(eigenvalues):
                if abs(eig.imag) < 1e-5 and eig.real > 1e-5:
                    pos_eigs.append((eig.real, eigenvectors[:, idx].real))

            if not pos_eigs:
                return float("inf"), None

            # Sort by lowest eigenvalue
            pos_eigs.sort(key=lambda x: x[0])
            min_lf, mode_act = pos_eigs[0]

            # Reconstruct full mode shape vector
            full_mode = np.zeros(dof_count, dtype=float)
            full_mode[active_dofs] = mode_act
            # Normalize mode shape
            max_disp = np.max(np.abs(full_mode))
            if max_disp > 1e-9:
                full_mode /= max_disp

            return float(min_lf), full_mode

        except Exception:
            # Fallback using regularized inverse: inv(Ke) * Kg
            try:
                inv_ke_kg = np.linalg.pinv(ke_act) @ kg_act
                eigs, vecs = np.linalg.eig(inv_ke_kg)
                
                pos_lfs = []
                for idx, val in enumerate(eigs):
                    if abs(val.imag) < 1e-5 and val.real > 1e-6:
                        lf = 1.0 / val.real
                        pos_lfs.append((lf, vecs[:, idx].real))

                if not pos_lfs:
                    return float("inf"), None

                pos_lfs.sort(key=lambda x: x[0])
                min_lf, mode_act = pos_lfs[0]

                full_mode = np.zeros(dof_count, dtype=float)
                full_mode[active_dofs] = mode_act
                max_disp = np.max(np.abs(full_mode))
                if max_disp > 1e-9:
                    full_mode /= max_disp
                return float(min_lf), full_mode
            except Exception:
                return float("inf"), None
