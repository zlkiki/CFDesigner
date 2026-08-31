"""
DXF Reader for Cold-Formed Steel Sections
Reads 2D Polylines, Bulge (Arc), Global Width (Thickness), and Header Units from DXF files.
"""

from dataclasses import dataclass, field
from typing import List, Optional
import math
import ezdxf


@dataclass
class DXFVertex:
    x: float
    y: float
    bulge: float = 0.0  # DXF Bulge parameter
    arc_angle: float = 0.0  # 4 * atan(bulge) in radians


@dataclass
class DXFPolyline:
    vertices: List[DXFVertex] = field(default_factory=list)
    thickness: float = 0.0  # Width of polyline
    is_closed: bool = False
    layer: str = "0"


class DXFReader:
    """
    Parses AutoCAD DXF files to extract centerline polylines and thicknesses for CFS sections.
    """

    # Mapping of $INSUNITS to scaling factor relative to inches
    # 1=inches, 2=feet, 4=mm, 5=cm, 6=meters
    INSUNITS_TO_INCHES = {
        0: 1.0,      # Unspecified -> default 1.0 (or mm depending on scale)
        1: 1.0,      # Inches
        2: 12.0,     # Feet
        3: 63360.0,  # Miles
        4: 0.03937007874015748,   # Millimeters -> Inches (1/25.4)
        5: 0.39370078740157483,   # Centimeters -> Inches
        6: 39.370078740157481,    # Meters -> Inches
        7: 39370.078740157485,    # Kilometers
        8: 1e-6,     # Microinches
        9: 0.001,    # Mils
        10: 36.0,    # Yards
    }

    # Mapping to millimeters
    INSUNITS_TO_MM = {
        0: 1.0,
        1: 25.4,
        2: 304.8,
        4: 1.0,
        5: 10.0,
        6: 1000.0,
    }

    def __init__(self, target_unit: str = "mm"):
        """
        :param target_unit: 'mm' or 'inch'
        """
        self.target_unit = target_unit.lower()

    def read_file(self, file_path: str) -> List[DXFPolyline]:
        """
        Reads a DXF file and returns a list of DXFPolyline objects.
        """
        doc = ezdxf.readfile(file_path)
        msp = doc.modelspace()

        # Determine unit scale factor
        insunits = doc.header.get("$INSUNITS", 0)
        
        if self.target_unit == "inch":
            scale = self.INSUNITS_TO_INCHES.get(insunits, 1.0)
        else:  # default mm
            scale = self.INSUNITS_TO_MM.get(insunits, 1.0)

        polylines: List[DXFPolyline] = []

        # 1. Parse LWPOLYLINE entities
        for entity in msp.query("LWPOLYLINE"):
            vertices: List[DXFVertex] = []
            is_closed = entity.is_closed
            width = entity.dxf.get("const_width", 0.0)

            # Get points: (x, y, start_width, end_width, bulge)
            points = entity.get_points()
            for pt in points:
                x = pt[0] * scale
                y = pt[1] * scale
                bulge = pt[4] if len(pt) > 4 else 0.0
                arc_ang = 4.0 * math.atan(bulge) if abs(bulge) > 1e-9 else 0.0
                vertices.append(DXFVertex(x=x, y=y, bulge=bulge, arc_angle=arc_ang))

                # If width was specified per vertex and const_width was 0
                if width == 0.0 and len(pt) > 2 and pt[2] > 0.0:
                    width = pt[2]

            scaled_width = width * scale
            if len(vertices) >= 2:
                polylines.append(
                    DXFPolyline(
                        vertices=vertices,
                        thickness=scaled_width,
                        is_closed=is_closed,
                        layer=entity.dxf.layer,
                    )
                )

        # 2. Parse POLYLINE (2D) entities
        for entity in msp.query("POLYLINE"):
            if not entity.is_2d_polyline:
                continue
            vertices = []
            is_closed = entity.is_closed
            width = entity.dxf.get("default_start_width", 0.0)

            for v in entity.vertices:
                x = v.dxf.location.x * scale
                y = v.dxf.location.y * scale
                bulge = v.dxf.get("bulge", 0.0)
                arc_ang = 4.0 * math.atan(bulge) if abs(bulge) > 1e-9 else 0.0
                vertices.append(DXFVertex(x=x, y=y, bulge=bulge, arc_angle=arc_ang))

            scaled_width = width * scale
            if len(vertices) >= 2:
                polylines.append(
                    DXFPolyline(
                        vertices=vertices,
                        thickness=scaled_width,
                        is_closed=is_closed,
                        layer=entity.dxf.layer,
                    )
                )

        return polylines
