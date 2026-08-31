"""
Section Wizard: Parametric standard cold-formed shape generator
Generates C-channels, Z-shapes, Hat channels, Decks, Tubes, Angles, and I-sections.
"""

from typing import Dict, List, Any, Optional
import math
from ..cad.dxf_reader import DXFPolyline, DXFVertex
from ..cad.part_mesher import PartMesher, SectionGeometry


class SectionWizard:
    """
    Parametric geometry generator for common cold-formed steel cross sections.
    """

    @staticmethod
    def create_c_section(h: float, b: float, c: float, t: float, r: float = 0.0) -> SectionGeometry:
        """
        Creates a Lipped C-Channel.
        :param h: Total depth (outer dimension)
        :param b: Flange width (outer dimension)
        :param c: Lip length (outer dimension)
        :param t: Design thickness
        :param r: Inside bend radius
        """
        # Centerline dimensions
        h_c = h - t
        b_c = b - t
        c_c = c - t / 2.0

        # Centerline vertices: Start from top lip to bottom lip
        # Top lip tip -> Top flange-lip corner -> Web-top flange corner -> Web-bot flange corner -> Bot flange-lip corner -> Bot lip tip
        vertices = [
            DXFVertex(x=b_c, y=h_c / 2.0 - c_c),
            DXFVertex(x=b_c, y=h_c / 2.0),
            DXFVertex(x=0.0, y=h_c / 2.0),
            DXFVertex(x=0.0, y=-h_c / 2.0),
            DXFVertex(x=b_c, y=-h_c / 2.0),
            DXFVertex(x=b_c, y=-h_c / 2.0 + c_c),
        ]
        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=False)
        return PartMesher.mesh_polyline(poly, default_thickness=t)

    @staticmethod
    def create_z_section(h: float, b: float, c: float, t: float, r: float = 0.0) -> SectionGeometry:
        """
        Creates a Lipped Z-Section.
        """
        h_c = h - t
        b_c = b - t
        c_c = c - t / 2.0

        vertices = [
            DXFVertex(x=b_c, y=h_c / 2.0 - c_c),
            DXFVertex(x=b_c, y=h_c / 2.0),
            DXFVertex(x=0.0, y=h_c / 2.0),
            DXFVertex(x=0.0, y=-h_c / 2.0),
            DXFVertex(x=-b_c, y=-h_c / 2.0),
            DXFVertex(x=-b_c, y=-h_c / 2.0 + c_c),
        ]
        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=False)
        return PartMesher.mesh_polyline(poly, default_thickness=t)

    @staticmethod
    def create_hat_section(h: float, b_top: float, b_bot: float, c: float, t: float) -> SectionGeometry:
        """
        Creates a Hat (Top-Hat) Channel.
        """
        h_c = h - t
        b_top_c = b_top - t
        b_bot_c = b_bot - t
        c_c = c - t / 2.0

        # Symmetrical hat section
        half_top = b_top_c / 2.0
        half_bot = half_top + b_bot_c

        vertices = [
            DXFVertex(x=-half_bot - c_c, y=-h_c / 2.0),
            DXFVertex(x=-half_bot, y=-h_c / 2.0),
            DXFVertex(x=-half_top, y=h_c / 2.0),
            DXFVertex(x=half_top, y=h_c / 2.0),
            DXFVertex(x=half_bot, y=-h_c / 2.0),
            DXFVertex(x=half_bot + c_c, y=-h_c / 2.0),
        ]
        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=False)
        return PartMesher.mesh_polyline(poly, default_thickness=t)

    @staticmethod
    def create_tube_section(h: float, b: float, t: float) -> SectionGeometry:
        """
        Creates a Closed Rectangular Tube (Box section).
        """
        h_c = h - t
        b_c = b - t

        vertices = [
            DXFVertex(x=-b_c / 2.0, y=-h_c / 2.0),
            DXFVertex(x=b_c / 2.0, y=-h_c / 2.0),
            DXFVertex(x=b_c / 2.0, y=h_c / 2.0),
            DXFVertex(x=-b_c / 2.0, y=h_c / 2.0),
            DXFVertex(x=-b_c / 2.0, y=-h_c / 2.0),
        ]
        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=True)
        return PartMesher.mesh_polyline(poly, default_thickness=t)

    @staticmethod
    def create_angle_section(h: float, b: float, t: float) -> SectionGeometry:
        """
        Creates an Angle (L-shape) Section.
        """
        h_c = h - t / 2.0
        b_c = b - t / 2.0

        vertices = [
            DXFVertex(x=0.0, y=h_c),
            DXFVertex(x=0.0, y=0.0),
            DXFVertex(x=b_c, y=0.0),
        ]
        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=False)
        return PartMesher.mesh_polyline(poly, default_thickness=t)

    @staticmethod
    def create_deck_section(h: float, pitch: float, b_top: float, b_bot: float, t: float, repeats: int = 2) -> SectionGeometry:
        """
        Creates a Repeating Trapezoidal Deck Profile.
        """
        h_c = h - t
        half_top = b_top / 2.0
        half_bot = b_bot / 2.0
        slope_w = (pitch - b_top - b_bot) / 2.0

        vertices: List[DXFVertex] = []
        cur_x = 0.0

        for r in range(repeats):
            if r == 0:
                vertices.append(DXFVertex(x=cur_x, y=h_c / 2.0))
            cur_x += half_top
            vertices.append(DXFVertex(x=cur_x, y=h_c / 2.0))
            cur_x += slope_w
            vertices.append(DXFVertex(x=cur_x, y=-h_c / 2.0))
            cur_x += b_bot
            vertices.append(DXFVertex(x=cur_x, y=-h_c / 2.0))
            cur_x += slope_w
            vertices.append(DXFVertex(x=cur_x, y=h_c / 2.0))
            cur_x += half_top
            vertices.append(DXFVertex(x=cur_x, y=h_c / 2.0))

        poly = DXFPolyline(vertices=vertices, thickness=t, is_closed=False)
        return PartMesher.mesh_polyline(poly, default_thickness=t)
