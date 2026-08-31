"""
Matplotlib-based Cross-Section & FSM Signature Curve Plotter
"""

import matplotlib.pyplot as plt
import numpy as np
from typing import Optional
from ..cad.part_mesher import SectionGeometry
from ..solver.signature_curve import BucklingCurveResult


class SectionPlotter:
    """
    Renders 2D Cross-section geometry and FSM Buckling Curves.
    """

    @staticmethod
    def plot_section(geom: SectionGeometry, title: str = "Cross-Section Geometry", save_path: Optional[str] = None):
        fig, ax = plt.subplots(figsize=(6, 6))
        
        for elem in geom.elements:
            # Draw centerline
            ax.plot([elem.x0, elem.x1], [elem.y0, elem.y1], "b-", linewidth=elem.thickness * 1.5)
            # Draw node points
            ax.plot([elem.x0, elem.x1], [elem.y0, elem.y1], "ro", markersize=3)

        # Plot origin & CG
        ax.plot(0, 0, "k+", markersize=10, label="CG (0,0)")
        ax.set_aspect("equal", "box")
        ax.grid(True, linestyle="--", alpha=0.6)
        ax.set_title(title, fontsize=12, fontweight="bold")
        ax.set_xlabel("X (mm)")
        ax.set_ylabel("Y (mm)")
        ax.legend()

        if save_path:
            plt.savefig(save_path, dpi=200, bbox_inches="tight")
            plt.close(fig)
        else:
            plt.close(fig)
        return fig

    @staticmethod
    def plot_signature_curve(curve_res: BucklingCurveResult, title: str = "FSM Elastic Buckling Curve", save_path: Optional[str] = None):
        fig, ax = plt.subplots(figsize=(8, 5))

        lengths = np.array(curve_res.lengths)
        lfs = np.array(curve_res.load_factors)

        ax.semilogx(lengths, lfs, "b-o", markersize=4, label="Signature Curve (LF)")
        
        # Mark local and distortional minima
        if curve_res.l_local > 0:
            lf_local = curve_res.p_crl / (curve_res.points[0].critical_load / curve_res.points[0].load_factor) if curve_res.points else 1.0
            ax.plot(curve_res.l_local, lf_local, "rs", markersize=8, label=f"Local: L={curve_res.l_local:.1f}mm")

        if curve_res.l_distortional > 0 and curve_res.l_distortional != curve_res.l_local:
            lf_dist = curve_res.p_crd / (curve_res.points[0].critical_load / curve_res.points[0].load_factor) if curve_res.points else 1.0
            ax.plot(curve_res.l_distortional, lf_dist, "g^", markersize=8, label=f"Distortional: L={curve_res.l_distortional:.1f}mm")

        ax.grid(True, which="both", linestyle="--", alpha=0.6)
        ax.set_title(title, fontsize=12, fontweight="bold")
        ax.set_xlabel("Half-Wavelength L (mm)")
        ax.set_ylabel("Critical Load Factor (LF = Pcr / Py)")
        ax.legend()

        if save_path:
            plt.savefig(save_path, dpi=200, bbox_inches="tight")
            plt.close(fig)
        else:
            plt.close(fig)
        return fig
