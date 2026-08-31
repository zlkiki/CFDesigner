"""
Part Mesher and Geometry Builder for CFS Sections
Ports CFS DXFPart algorithm to convert polyline vertices with bulge to structural elements and discrete strips.
"""

from dataclasses import dataclass, field
from typing import List, Tuple
import math
from .dxf_reader import DXFPolyline, DXFVertex


@dataclass
class Element:
    """
    Represents a single straight or corner-arc segment of a cold-formed part.
    """
    elem_id: int
    length: float          # Centerline segment length
    angle: float           # Angle in radians relative to global X-axis
    radius: float = 0.0    # Inside bend radius (0 for straight element)
    thickness: float = 0.0 # Element thickness
    x0: float = 0.0        # Start X coordinate
    y0: float = 0.0        # Start Y coordinate
    x1: float = 0.0        # End X coordinate
    y1: float = 0.0        # End Y coordinate


@dataclass
class SectionGeometry:
    """
    Geometric container of the entire cross-section composed of multiple elements.
    """
    elements: List[Element] = field(default_factory=list)
    thickness: float = 0.0
    is_closed: bool = False
    xcg: float = 0.0
    ycg: float = 0.0
    total_length: float = 0.0


class PartMesher:
    """
    Converts CAD polylines into discrete structural elements and strip nodes.
    Faithfully reproduces CFS.exe DXFPart meshing algorithm.
    """

    @staticmethod
    def mesh_polyline(poly: DXFPolyline, default_thickness: float = 1.0) -> SectionGeometry:
        """
        Meshes a DXFPolyline into structural Elements.
        """
        vertices = poly.vertices
        n_vert = len(vertices)
        if n_vert < 2:
            return SectionGeometry()

        t = poly.thickness if poly.thickness > 0 else default_thickness
        is_closed = poly.is_closed and n_vert >= 4

        elements: List[Element] = []
        elem_idx = 1

        t_tan = 0.0
        r_c = 0.0
        r_close = 0.0

        if is_closed and abs(vertices[-1].arc_angle) > 1e-9:
            dx = vertices[0].x - vertices[-1].x
            dy = vertices[0].y - vertices[-1].y
            chord = math.sqrt(dx * dx + dy * dy)
            arc_ang = abs(vertices[-1].arc_angle)
            if math.sin(arc_ang / 2.0) > 1e-9:
                r_c = (chord / 2.0) / math.sin(arc_ang / 2.0)
                t_tan = r_c * math.tan(arc_ang / 2.0)
                r_close = t_tan

        for i in range(n_vert - 1):
            dx = vertices[i + 1].x - vertices[i].x
            dy = vertices[i + 1].y - vertices[i].y
            chord = math.sqrt(dx * dx + dy * dy)
            chord_ang = math.atan2(dy, dx)
            arc_ang = vertices[i].arc_angle

            if abs(arc_ang) < 1e-9:
                # Straight segment
                elem_len = t_tan + chord
                r_in = max(r_c - t / 2.0, 0.0)
                elements.append(
                    Element(
                        elem_id=elem_idx,
                        length=elem_len,
                        angle=chord_ang,
                        radius=r_in,
                        thickness=t
                    )
                )
                elem_idx += 1
                r_c = 0.0
                t_tan = 0.0
            else:
                # Corner arc segment
                if t_tan > 0.0 or i == 0:
                    r_in = max(r_c - t / 2.0, 0.0)
                    elements.append(
                        Element(
                            elem_id=elem_idx,
                            length=t_tan,
                            angle=chord_ang - arc_ang / 2.0,
                            radius=r_in,
                            thickness=t
                        )
                    )
                    elem_idx += 1

                if math.sin(abs(arc_ang) / 2.0) > 1e-9:
                    r_c = (chord / 2.0) / math.sin(abs(arc_ang) / 2.0)
                    t_tan = r_c * math.tan(abs(arc_ang) / 2.0)
                else:
                    r_c = 0.0
                    t_tan = 0.0

                if len(elements) > 0:
                    elements[-1].length += t_tan
                    if i == 0:
                        elements[-1].radius = max(r_c - t / 2.0, 0.0)

        if t_tan > 0.0 and len(elements) > 0:
            last_ang = elements[-1].angle + vertices[-2].arc_angle
            r_in = max(r_c - t / 2.0, 0.0)
            elements.append(
                Element(
                    elem_id=elem_idx,
                    length=t_tan,
                    angle=last_ang,
                    radius=r_in,
                    thickness=t
                )
            )
            elem_idx += 1

        # Calculate coordinates along the elements
        geom = SectionGeometry(elements=elements, thickness=t, is_closed=is_closed)
        PartMesher._compute_coordinates_and_centering(geom, vertices[0].x, vertices[0].y, r_close)
        return geom

    @staticmethod
    def _compute_coordinates_and_centering(geom: SectionGeometry, start_x: float, start_y: float, r_close: float):
        """
        Calculates node coordinates for elements and centers the geometry at (0,0).
        """
        if not geom.elements:
            return

        cur_x = start_x - r_close * math.cos(geom.elements[0].angle)
        cur_y = start_y - r_close * math.sin(geom.elements[0].angle)

        total_area = 0.0
        weighted_x = 0.0
        weighted_y = 0.0
        total_len = 0.0

        for elem in geom.elements:
            elem.x0 = cur_x
            elem.y0 = cur_y
            cur_x += elem.length * math.cos(elem.angle)
            cur_y += elem.length * math.sin(elem.angle)
            elem.x1 = cur_x
            elem.y1 = cur_y

            mid_x = (elem.x0 + elem.x1) / 2.0
            mid_y = (elem.y0 + elem.y1) / 2.0
            elem_area = elem.length * elem.thickness

            total_area += elem_area
            weighted_x += elem_area * mid_x
            weighted_y += elem_area * mid_y
            total_len += elem.length

        if total_area > 1e-9:
            geom.xcg = weighted_x / total_area
            geom.ycg = weighted_y / total_area
        geom.total_length = total_len

        # Center at (0, 0)
        for elem in geom.elements:
            elem.x0 -= geom.xcg
            elem.y0 -= geom.ycg
            elem.x1 -= geom.xcg
            elem.y1 -= geom.ycg
