"""
FSM Strip Mesh Assembler
Assembles 8x8 Element Elastic Stiffness [Ke] and Geometric Stiffness [Kg] matrices.
Faithfully ports RSG.CFS.FiniteStrip.cs matrix formulations.
"""

from dataclasses import dataclass, field
from typing import List, Tuple
import math
import numpy as np
from ..cad.part_mesher import SectionGeometry, Element
from ..geometry.gross_properties import GrossProperties


@dataclass
class StripNode:
    node_id: int
    x: float
    y: float
    stress: float = 1.0  # Normalized applied stress (1.0 for pure compression)


@dataclass
class StripElement:
    elem_id: int
    node_i: int
    node_j: int
    thickness: float
    width: float
    alpha: float         # Orientation angle (radians)


class StripAssembler:
    """
    Subdivides section geometry into finite strips and builds global [Ke], [Kg] matrices.
    """

    def __init__(
        self,
        geom: SectionGeometry,
        props: GrossProperties,
        e_modulus: float = 205000.0,  # MPa (or psi)
        poisson: float = 0.3,
        g_modulus: float = 78846.0,   # MPa
    ):
        self.geom = geom
        self.props = props
        self.e = e_modulus
        self.nu = poisson
        self.g = g_modulus if g_modulus > 0 else e_modulus / (2.0 * (1.0 + poisson))

        self.nodes: List[StripNode] = []
        self.strips: List[StripElement] = []
        self._build_strip_mesh()

    def _build_strip_mesh(self, max_strip_width: float = 5.0):
        """
        Discretizes each element into fine sub-strips to capture local/distortional buckling accurately.
        """
        self.nodes = []
        self.strips = []
        node_idx = 0
        strip_idx = 0

        for elem in self.geom.elements:
            l = elem.length
            n_sub = max(1, int(math.ceil(l / max_strip_width)))

            start_x, start_y = elem.x0, elem.y0
            end_x, end_y = elem.x1, elem.y1
            dx = (end_x - start_x) / n_sub
            dy = (end_y - start_y) / n_sub

            sub_w = math.sqrt(dx * dx + dy * dy)
            sub_alpha = elem.angle

            for s in range(n_sub):
                if s == 0 and node_idx == 0:
                    self.nodes.append(StripNode(node_id=0, x=start_x, y=start_y))
                    node_idx += 1
                elif s == 0 and node_idx > 0:
                    # Check if starting point matches previous node
                    prev_node = self.nodes[-1]
                    dist_to_prev = math.hypot(start_x - prev_node.x, start_y - prev_node.y)
                    if dist_to_prev > 1e-4:
                        self.nodes.append(StripNode(node_id=node_idx, x=start_x, y=start_y))
                        node_idx += 1

                curr_x = start_x + (s + 1) * dx
                curr_y = start_y + (s + 1) * dy
                self.nodes.append(StripNode(node_id=node_idx, x=curr_x, y=curr_y))
                node_idx += 1

                self.strips.append(
                    StripElement(
                        elem_id=strip_idx,
                        node_i=node_idx - 2,
                        node_j=node_idx - 1,
                        thickness=elem.thickness,
                        width=sub_w,
                        alpha=sub_alpha,
                    )
                )
                strip_idx += 1

    def apply_loading(self, load_type: str = "compression", fbx: float = 0.0, fby: float = 0.0):
        """
        Calculates normal stress distribution across all nodes.
        :param load_type: 'compression', 'bending_x', 'bending_y', or 'combined'
        """
        for node in self.nodes:
            if load_type == "compression":
                node.stress = 1.0
            elif load_type == "bending_x":
                # Pure Major-axis bending (My): stress ~ y
                c_y = max(abs(n.y) for n in self.nodes)
                node.stress = node.y / c_y if c_y > 1e-6 else 0.0
            elif load_type == "bending_y":
                # Minor-axis bending (Mx): stress ~ x
                c_x = max(abs(n.x) for n in self.nodes)
                node.stress = node.x / c_x if c_x > 1e-6 else 0.0
            else:
                node.stress = 1.0 + fbx * node.y + fby * node.x

    def assemble_matrices(self, half_wavelength: float) -> Tuple[np.ndarray, np.ndarray]:
        """
        Assembles the global elastic stiffness matrix [Ke] and geometric stiffness matrix [Kg]
        for a given half-wavelength L.
        """
        l = half_wavelength
        km = math.pi / l
        num_nodes = len(self.nodes)
        dof_total = num_nodes * 4  # 4 DOFs per node: [u, v, w, theta]

        ke_global = np.zeros((dof_total, dof_total), dtype=float)
        kg_global = np.zeros((dof_total, dof_total), dtype=float)

        e = self.e
        nu = self.nu
        g = self.g

        # Plane stress and plate bending rigidities (Isotropic)
        d_m = e / (1.0 - nu * nu)
        d_1 = nu * d_m

        for strip in self.strips:
            t = strip.thickness
            b = strip.width
            if b < 1e-9 or t < 1e-9:
                continue

            # Plate bending rigidities
            d_b = (e * (t ** 3)) / (12.0 * (1.0 - nu * nu))
            d_b1 = nu * d_b
            d_bxy = (g * (t ** 3)) / 12.0

            # 1. Local Elastic Stiffness [ke_local] (8x8)
            ke_loc = np.zeros((8, 8), dtype=float)

            # Membrane terms (u, v): indices 0, 1 (node i) and 4, 5 (node j)
            # u_i, v_i, u_j, v_j
            k11 = t * ((l * d_m / (2.0 * b)) + (l * b * (km ** 2) * g / 6.0))
            k22 = t * ((l * b * (km ** 2) * d_m / 6.0) + (l * g / (2.0 * b)))
            k21 = t * (l * km * d_1 / 4.0 - l * km * g / 4.0)
            k31 = t * ((-l * d_m / (2.0 * b)) + (l * b * (km ** 2) * g / 12.0))
            k41 = t * (l * km * d_1 / 4.0 + l * km * g / 4.0)
            k32 = -k41
            k42 = t * ((l * b * (km ** 2) * d_m / 12.0) - (l * g / (2.0 * b)))
            k43 = -k21

            ke_loc[0, 0] = k11;  ke_loc[0, 1] = k21;  ke_loc[0, 4] = k31;  ke_loc[0, 5] = k41
            ke_loc[1, 0] = k21;  ke_loc[1, 1] = k22;  ke_loc[1, 4] = k32;  ke_loc[1, 5] = k42
            ke_loc[4, 0] = k31;  ke_loc[4, 1] = k32;  ke_loc[4, 4] = k11;  ke_loc[4, 5] = k43
            ke_loc[5, 0] = k41;  ke_loc[5, 1] = k42;  ke_loc[5, 4] = k43;  ke_loc[5, 5] = k22

            # Bending terms (w, theta): indices 2, 3 (node i) and 6, 7 (node j)
            k55 = (13.0 * l * b * (km ** 4) / 70.0) * d_b + (12.0 * l * (km ** 2) / (5.0 * b)) * d_bxy + (6.0 * l * (km ** 2) / (5.0 * b)) * d_b1 + (6.0 * l / (b ** 3)) * d_b
            k66 = (l * (b ** 3) * (km ** 4) / 210.0) * d_b + (4.0 * l * b * (km ** 2) / 15.0) * d_bxy + (2.0 * l * b * (km ** 2) / 15.0) * d_b1 + (2.0 * l / b) * d_b
            k65 = (3.0 * l * (km ** 2) / 5.0) * d_b1 + (l * (km ** 2) / 5.0) * d_bxy + (3.0 * l / (b ** 2)) * d_b + (11.0 * l * (b ** 2) * (km ** 4) / 420.0) * d_b
            k75 = (9.0 * l * b * (km ** 4) / 140.0) * d_b - (12.0 * l * (km ** 2) / (5.0 * b)) * d_bxy - (6.0 * l * (km ** 2) / (5.0 * b)) * d_b1 - (6.0 * l / (b ** 3)) * d_b
            k85 = (-13.0 * l * (b ** 2) * (km ** 4) / 840.0) * d_b + (l * (km ** 2) / 5.0) * d_bxy + (l * (km ** 2) / 10.0) * d_b1 + (3.0 * l / (b ** 2)) * d_b
            k76 = -k85
            k86 = (-3.0 * l * (b ** 3) * (km ** 4) / 840.0) * d_b - (l * b * (km ** 2) / 15.0) * d_bxy - (l * b * (km ** 2) / 30.0) * d_b1 + (l / b * d_b)
            k87 = -k65

            ke_loc[2, 2] = k55;  ke_loc[2, 3] = k65;  ke_loc[2, 6] = k75;  ke_loc[2, 7] = k85
            ke_loc[3, 2] = k65;  ke_loc[3, 3] = k66;  ke_loc[3, 6] = k76;  ke_loc[3, 7] = k86
            ke_loc[6, 2] = k75;  ke_loc[6, 3] = k76;  ke_loc[6, 6] = k55;  ke_loc[6, 7] = k87
            ke_loc[7, 2] = k85;  ke_loc[7, 3] = k86;  ke_loc[7, 6] = k87;  ke_loc[7, 7] = k66

            # 2. Local Geometric Stiffness [kg_local] (8x8)
            f_factor = (b * math.pi * math.pi) / (1680.0 * l)
            sigma_i = self.nodes[strip.node_i].stress
            sigma_j = self.nodes[strip.node_j].stress
            f1 = sigma_i * t * f_factor
            f2 = sigma_j * t * f_factor

            kg_loc = np.zeros((8, 8), dtype=float)
            # Membrane u, v geometric stiffness
            kg_loc[0, 0] = 70.0 * (3.0 * f1 + f2)
            kg_loc[1, 1] = kg_loc[0, 0]
            kg_loc[4, 4] = 70.0 * (f1 + 3.0 * f2)
            kg_loc[5, 5] = kg_loc[4, 4]
            kg_loc[4, 0] = 70.0 * (f1 + f2);  kg_loc[0, 4] = kg_loc[4, 0]
            kg_loc[5, 1] = kg_loc[4, 0];       kg_loc[1, 5] = kg_loc[5, 1]

            # Bending w, theta geometric stiffness
            kg_loc[2, 2] = 24.0 * (10.0 * f1 + 3.0 * f2)
            kg_loc[3, 3] = (b ** 2) * (5.0 * f1 + 3.0 * f2)
            kg_loc[6, 6] = 24.0 * (3.0 * f1 + 10.0 * f2)
            kg_loc[7, 7] = (b ** 2) * (3.0 * f1 + 5.0 * f2)
            kg_loc[3, 2] = 2.0 * b * (15.0 * f1 + 7.0 * f2);   kg_loc[2, 3] = kg_loc[3, 2]
            kg_loc[6, 2] = 54.0 * (f1 + f2);                   kg_loc[2, 6] = kg_loc[6, 2]
            kg_loc[6, 3] = 2.0 * b * (6.0 * f1 + 7.0 * f2);    kg_loc[3, 6] = kg_loc[6, 3]
            kg_loc[7, 2] = -2.0 * b * (7.0 * f1 + 6.0 * f2);   kg_loc[2, 7] = kg_loc[7, 2]
            kg_loc[7, 3] = -3.0 * (b ** 2) * (f1 + f2);        kg_loc[3, 7] = kg_loc[7, 3]
            kg_loc[7, 6] = -2.0 * b * (7.0 * f1 + 15.0 * f2);  kg_loc[6, 7] = kg_loc[7, 6]

            # 3. Coordinate Transformation (Alpha)
            # Local DOFs: [u, v, w, theta] -> Global DOFs: [u_g, v_g, w_g, theta_g]
            c = math.cos(strip.alpha)
            s = math.sin(strip.alpha)
            t_mat = np.zeros((8, 8), dtype=float)

            # Node i
            t_mat[0, 0] = c;   t_mat[0, 2] = s
            t_mat[1, 1] = 1.0
            t_mat[2, 0] = -s;  t_mat[2, 2] = c
            t_mat[3, 3] = 1.0

            # Node j
            t_mat[4, 4] = c;   t_mat[4, 6] = s
            t_mat[5, 5] = 1.0
            t_mat[6, 4] = -s;  t_mat[6, 6] = c
            t_mat[7, 7] = 1.0

            ke_elem = t_mat.T @ ke_loc @ t_mat
            kg_elem = t_mat.T @ kg_loc @ t_mat

            # Global assembly
            dofs = [
                strip.node_i * 4 + 0, strip.node_i * 4 + 1, strip.node_i * 4 + 2, strip.node_i * 4 + 3,
                strip.node_j * 4 + 0, strip.node_j * 4 + 1, strip.node_j * 4 + 2, strip.node_j * 4 + 3,
            ]

            for r in range(8):
                for col in range(8):
                    ke_global[dofs[r], dofs[col]] += ke_elem[r, col]
                    kg_global[dofs[r], dofs[col]] += kg_elem[r, col]

        return ke_global, kg_global
