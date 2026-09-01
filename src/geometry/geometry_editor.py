"""
Geometry Editor and Transforms for CFDesigner
Handles element spreadsheet updates, geometric transformations (Rotate, Mirror, Align),
and intermediate stiffener / rib insertions.
Ports algorithms from CFS.exe frmAngle.cs, frmRibs.cs, and frmLocation.cs.
"""

from typing import List, Tuple, Dict, Any, Optional
import math
from dataclasses import dataclass
from ..cad.part_mesher import Element, SectionGeometry
from .gross_properties import SectionPropertiesCalculator, GrossProperties


class GeometryEditor:
    """
    Provides editing, geometric transformations, and rib insertion utilities.
    """

    @staticmethod
    def update_elements(elements_data: List[Dict[str, Any]], thickness: float) -> SectionGeometry:
        """
        Reconstructs SectionGeometry from element spreadsheet input.
        """
        elements: List[Element] = []
        total_len = 0.0

        for idx, item in enumerate(elements_data):
            elem_id = item.get("elem_id", idx + 1)
            t = float(item.get("thickness", thickness))
            rad = float(item.get("radius", 0.0))
            
            # If coordinates are given directly
            if "x0" in item and "y0" in item and "x1" in item and "y1" in item:
                x0 = float(item["x0"])
                y0 = float(item["y0"])
                x1 = float(item["x1"])
                y1 = float(item["y1"])
                dx = x1 - x0
                dy = y1 - y0
                length = float(item.get("length", math.sqrt(dx * dx + dy * dy)))
                angle = float(item.get("angle", math.atan2(dy, dx)))
            else:
                length = float(item.get("length", 10.0))
                angle = float(item.get("angle", 0.0))
                x0 = 0.0
                y0 = 0.0
                x1 = length * math.cos(angle)
                y1 = length * math.sin(angle)

            elements.append(
                Element(
                    elem_id=elem_id,
                    length=length,
                    angle=angle,
                    radius=rad,
                    thickness=t,
                    x0=x0,
                    y0=y0,
                    x1=x1,
                    y1=y1
                )
            )
            total_len += length

        # Chain connect if elements start from (0,0) and have (length, angle)
        if len(elements) > 1 and all(e.x0 == 0 and e.y0 == 0 for e in elements[1:]):
            cur_x = elements[0].x0
            cur_y = elements[0].y0
            for e in elements:
                e.x0 = cur_x
                e.y0 = cur_y
                cur_x += e.length * math.cos(e.angle)
                cur_y += e.length * math.sin(e.angle)
                e.x1 = cur_x
                e.y1 = cur_y

        geom = SectionGeometry(elements=elements, thickness=thickness, total_length=total_len)
        return geom

    @staticmethod
    def rotate_section(geom: SectionGeometry, angle_rad: float, center_at_cg: bool = True) -> SectionGeometry:
        """
        Rotates the section geometry by angle_rad around centroid (or origin).
        """
        if not geom.elements:
            return geom

        # Calculate current properties for CG
        props = SectionPropertiesCalculator.calculate(geom)
        cx = props.xcg if center_at_cg else 0.0
        cy = props.ycg if center_at_cg else 0.0

        cos_a = math.cos(angle_rad)
        sin_a = math.sin(angle_rad)

        new_elements: List[Element] = []
        for elem in geom.elements:
            # Rotate start point relative to center
            dx0 = elem.x0 - cx
            dy0 = elem.y0 - cy
            nx0 = dx0 * cos_a - dy0 * sin_a + cx
            ny0 = dx0 * sin_a + dy0 * cos_a + cy

            # Rotate end point relative to center
            dx1 = elem.x1 - cx
            dy1 = elem.y1 - cy
            nx1 = dx1 * cos_a - dy1 * sin_a + cx
            ny1 = dx1 * sin_a + dy1 * cos_a + cy

            new_angle = (elem.angle + angle_rad) % (2.0 * math.pi)
            if new_angle > math.pi:
                new_angle -= 2.0 * math.pi

            new_elements.append(
                Element(
                    elem_id=elem.elem_id,
                    length=elem.length,
                    angle=new_angle,
                    radius=elem.radius,
                    thickness=elem.thickness,
                    x0=nx0,
                    y0=ny0,
                    x1=nx1,
                    y1=ny1
                )
            )

        return SectionGeometry(
            elements=new_elements,
            thickness=geom.thickness,
            is_closed=geom.is_closed,
            total_length=geom.total_length
        )

    @staticmethod
    def mirror_section(geom: SectionGeometry, axis: str = "horizontal", center_at_cg: bool = True) -> SectionGeometry:
        """
        Mirrors the section geometry.
        axis: "horizontal" (flips Y across CG / X-axis) or "vertical" (flips X across CG / Y-axis)
        """
        if not geom.elements:
            return geom

        props = SectionPropertiesCalculator.calculate(geom)
        cx = props.xcg if center_at_cg else 0.0
        cy = props.ycg if center_at_cg else 0.0

        new_elements: List[Element] = []
        for elem in geom.elements:
            if axis.lower() in ("horizontal", "h", "x"):
                # Flip Y
                nx0 = elem.x0
                ny0 = 2.0 * cy - elem.y0
                nx1 = elem.x1
                ny1 = 2.0 * cy - elem.y1
                new_angle = -elem.angle
            else:
                # Flip X
                nx0 = 2.0 * cx - elem.x0
                ny0 = elem.y0
                nx1 = 2.0 * cx - elem.x1
                ny1 = elem.y1
                new_angle = math.pi - elem.angle

            new_angle = new_angle % (2.0 * math.pi)
            if new_angle > math.pi:
                new_angle -= 2.0 * math.pi

            new_elements.append(
                Element(
                    elem_id=elem.elem_id,
                    length=elem.length,
                    angle=new_angle,
                    radius=elem.radius,
                    thickness=elem.thickness,
                    x0=nx0,
                    y0=ny0,
                    x1=nx1,
                    y1=ny1
                )
            )

        return SectionGeometry(
            elements=new_elements,
            thickness=geom.thickness,
            is_closed=geom.is_closed,
            total_length=geom.total_length
        )

    @staticmethod
    def align_to_origin(geom: SectionGeometry, align_type: str = "cg") -> SectionGeometry:
        """
        Translates geometry to align Centroid or Bounding Box minimum to (0,0).
        """
        if not geom.elements:
            return geom

        props = SectionPropertiesCalculator.calculate(geom)
        if align_type.lower() == "cg":
            dx = -props.xcg
            dy = -props.ycg
        elif align_type.lower() == "min":
            min_x = min(min(e.x0, e.x1) for e in geom.elements)
            min_y = min(min(e.y0, e.y1) for e in geom.elements)
            dx = -min_x
            dy = -min_y
        else:
            dx, dy = 0.0, 0.0

        new_elements: List[Element] = []
        for elem in geom.elements:
            new_elements.append(
                Element(
                    elem_id=elem.elem_id,
                    length=elem.length,
                    angle=elem.angle,
                    radius=elem.radius,
                    thickness=elem.thickness,
                    x0=elem.x0 + dx,
                    y0=elem.y0 + dy,
                    x1=elem.x1 + dx,
                    y1=elem.y1 + dy
                )
            )

        return SectionGeometry(
            elements=new_elements,
            thickness=geom.thickness,
            is_closed=geom.is_closed,
            total_length=geom.total_length
        )

    @staticmethod
    def insert_rib(
        geom: SectionGeometry,
        target_elem_id: int,
        rib_type: str = "V",
        rib_width: float = 20.0,
        rib_depth: float = 10.0,
        num_ribs: int = 1,
        rib_radius: float = 0.0
    ) -> SectionGeometry:
        """
        Inserts intermediate stiffener ribs into the specified element.
        Ports CFS.exe frmRibs.cs algorithm.
        """
        target_idx = -1
        for idx, e in enumerate(geom.elements):
            if e.elem_id == target_elem_id:
                target_idx = idx
                break

        if target_idx == -1:
            # Fallback to first long element
            target_idx = max(range(len(geom.elements)), key=lambda i: geom.elements[i].length)

        target_elem = geom.elements[target_idx]
        total_len = target_elem.length

        # Check rib width constraints
        total_rib_span = rib_width * num_ribs
        if total_rib_span >= total_len:
            # Scale down rib width to fit within 80% of element
            rib_width = (total_len * 0.8) / num_ribs

        # Segment flat spacing
        flat_rem = total_len - (rib_width * num_ribs)
        flat_seg_len = flat_rem / (num_ribs + 1)

        # Orientation normal to element angle
        elem_ang = target_elem.angle
        normal_ang = elem_ang + math.pi / 2.0

        # Build sub-elements replacing target_elem
        new_sub_elements: List[Element] = []
        cur_x = target_elem.x0
        cur_y = target_elem.y0
        t = target_elem.thickness

        for r_idx in range(num_ribs):
            # 1. Preceding flat segment
            next_x = cur_x + flat_seg_len * math.cos(elem_ang)
            next_y = cur_y + flat_seg_len * math.sin(elem_ang)
            new_sub_elements.append(
                Element(
                    elem_id=0,
                    length=flat_seg_len,
                    angle=elem_ang,
                    radius=0.0,
                    thickness=t,
                    x0=cur_x,
                    y0=cur_y,
                    x1=next_x,
                    y1=next_y
                )
            )
            cur_x, cur_y = next_x, next_y

            # 2. Rib profile
            if rib_type.upper() == "V":
                # Triangular V-Rib: Leg 1 (inward), Leg 2 (outward)
                half_w = rib_width / 2.0
                leg_len = math.sqrt(half_w * half_w + rib_depth * rib_depth)
                
                # Apex point
                apex_x = cur_x + half_w * math.cos(elem_ang) + rib_depth * math.cos(normal_ang)
                apex_y = cur_y + half_w * math.sin(elem_ang) + rib_depth * math.sin(normal_ang)
                leg1_ang = math.atan2(apex_y - cur_y, apex_x - cur_x)
                
                new_sub_elements.append(
                    Element(
                        elem_id=0,
                        length=leg_len,
                        angle=leg1_ang,
                        radius=rib_radius,
                        thickness=t,
                        x0=cur_x,
                        y0=cur_y,
                        x1=apex_x,
                        y1=apex_y
                    )
                )

                # Leg 2: Apex to base end
                base_end_x = cur_x + rib_width * math.cos(elem_ang)
                base_end_y = cur_y + rib_width * math.sin(elem_ang)
                leg2_ang = math.atan2(base_end_y - apex_y, base_end_x - apex_x)

                new_sub_elements.append(
                    Element(
                        elem_id=0,
                        length=leg_len,
                        angle=leg2_ang,
                        radius=rib_radius,
                        thickness=t,
                        x0=apex_x,
                        y0=apex_y,
                        x1=base_end_x,
                        y1=base_end_y
                    )
                )
                cur_x, cur_y = base_end_x, base_end_y

            elif rib_type.upper() == "TRAPEZOID":
                # Trapezoidal Rib: Leg1 (inward), Flat top, Leg2 (outward)
                w_leg = rib_width * 0.3
                w_top = rib_width * 0.4
                leg_len = math.sqrt(w_leg * w_leg + rib_depth * rib_depth)

                # Point 1: top start
                p1_x = cur_x + w_leg * math.cos(elem_ang) + rib_depth * math.cos(normal_ang)
                p1_y = cur_y + w_leg * math.sin(elem_ang) + rib_depth * math.sin(normal_ang)
                leg1_ang = math.atan2(p1_y - cur_y, p1_x - cur_x)
                new_sub_elements.append(Element(elem_id=0, length=leg_len, angle=leg1_ang, radius=rib_radius, thickness=t, x0=cur_x, y0=cur_y, x1=p1_x, y1=p1_y))

                # Point 2: top end
                p2_x = p1_x + w_top * math.cos(elem_ang)
                p2_y = p1_y + w_top * math.sin(elem_ang)
                new_sub_elements.append(Element(elem_id=0, length=w_top, angle=elem_ang, radius=rib_radius, thickness=t, x0=p1_x, y0=p1_y, x1=p2_x, y1=p2_y))

                # Point 3: base end
                p3_x = cur_x + rib_width * math.cos(elem_ang)
                p3_y = cur_y + rib_width * math.sin(elem_ang)
                leg2_ang = math.atan2(p3_y - p2_y, p3_x - p2_x)
                new_sub_elements.append(Element(elem_id=0, length=leg_len, angle=leg2_ang, radius=rib_radius, thickness=t, x0=p2_x, y0=p2_y, x1=p3_x, y1=p3_y))
                cur_x, cur_y = p3_x, p3_y
            else:
                # Default V-Rib
                half_w = rib_width / 2.0
                leg_len = math.sqrt(half_w * half_w + rib_depth * rib_depth)
                apex_x = cur_x + half_w * math.cos(elem_ang) + rib_depth * math.cos(normal_ang)
                apex_y = cur_y + half_w * math.sin(elem_ang) + rib_depth * math.sin(normal_ang)
                leg1_ang = math.atan2(apex_y - cur_y, apex_x - cur_x)
                new_sub_elements.append(Element(elem_id=0, length=leg_len, angle=leg1_ang, radius=rib_radius, thickness=t, x0=cur_x, y0=cur_y, x1=apex_x, y1=apex_y))
                base_end_x = cur_x + rib_width * math.cos(elem_ang)
                base_end_y = cur_y + rib_width * math.sin(elem_ang)
                leg2_ang = math.atan2(base_end_y - apex_y, base_end_x - apex_x)
                new_sub_elements.append(Element(elem_id=0, length=leg_len, angle=leg2_ang, radius=rib_radius, thickness=t, x0=apex_x, y0=apex_y, x1=base_end_x, y1=base_end_y))
                cur_x, cur_y = base_end_x, base_end_y

        # 3. Final trailing flat segment
        next_x = cur_x + flat_seg_len * math.cos(elem_ang)
        next_y = cur_y + flat_seg_len * math.sin(elem_ang)
        new_sub_elements.append(
            Element(
                elem_id=0,
                length=flat_seg_len,
                angle=elem_ang,
                radius=0.0,
                thickness=t,
                x0=cur_x,
                y0=cur_y,
                x1=next_x,
                y1=next_y
            )
        )

        # Assemble full list of elements
        full_elements: List[Element] = []
        for i, elem in enumerate(geom.elements):
            if i == target_idx:
                full_elements.extend(new_sub_elements)
            else:
                full_elements.append(elem)

        # Re-index all elements sequentially
        tot_len = 0.0
        for idx, elem in enumerate(full_elements):
            elem.elem_id = idx + 1
            tot_len += elem.length

        return SectionGeometry(
            elements=full_elements,
            thickness=geom.thickness,
            is_closed=geom.is_closed,
            total_length=tot_len
        )
