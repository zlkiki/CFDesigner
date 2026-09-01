"""
CFS Binary Section Library (*.cfsl) and Material Library (*.mtl) Parser for CFDesigner
Ports CFS.exe Section.cs binary loader and DataAnalysis.cs.
Supports AISI.cfsl, SSMA.cfsl, SFIA.cfsl, LGSI.cfsl, HUD.cfsl, and CFS14.mtl.
"""

import struct
import os
import math
from typing import List, Dict, Any, Optional
from dataclasses import dataclass
from ..cad.part_mesher import Element, SectionGeometry
from ..geometry.gross_properties import SectionPropertiesCalculator


@dataclass
class LibrarySectionSummary:
    lib_name: str
    section_type: str
    section_name: str
    offset: int
    h: float = 0.0
    b: float = 0.0
    t: float = 0.0
    area: float = 0.0
    ix: float = 0.0
    iy: float = 0.0


class CFSLibraryParser:
    """
    Parser for CFS binary section libraries (.cfsl / .scl).
    """

    @staticmethod
    def _read_pascal_string(f) -> str:
        raw_len = f.read(1)
        if not raw_len:
            return ""
        length = struct.unpack("B", raw_len)[0]
        if length == 0:
            return ""
        return f.read(length).decode("latin-1", errors="ignore").strip()

    @staticmethod
    def get_library_summary(file_path: str) -> Dict[str, Any]:
        """
        Parses the header and directory table of a .cfsl file.
        """
        if not os.path.exists(file_path):
            raise FileNotFoundError(f"Library file not found: {file_path}")

        lib_name = os.path.splitext(os.path.basename(file_path))[0]
        result = {
            "library_name": lib_name,
            "company": "",
            "address": [],
            "types": []
        }

        with open(file_path, "rb") as f:
            # 5 Pascal strings (Company, Addr1..4)
            result["company"] = CFSLibraryParser._read_pascal_string(f)
            for _ in range(4):
                result["address"].append(CFSLibraryParser._read_pascal_string(f))

            raw_ntypes = f.read(2)
            if not raw_ntypes:
                return result
            n_types = struct.unpack("<h", raw_ntypes)[0]

            types_info = []
            for _ in range(n_types):
                type_name = CFSLibraryParser._read_pascal_string(f)
                seek_offset = struct.unpack("<i", f.read(4))[0]
                num_sct = struct.unpack("<h", f.read(2))[0]
                types_info.append({
                    "name": type_name,
                    "offset": seek_offset,
                    "count": num_sct,
                    "sections": []
                })

            # Read section names for each type
            for t_info in types_info:
                # Seek offset is 1-indexed in VB Binary
                f.seek(max(0, t_info["offset"] - 1))
                sections = []
                for _ in range(t_info["count"]):
                    sct_name = CFSLibraryParser._read_pascal_string(f)
                    sct_offset = struct.unpack("<i", f.read(4))[0]
                    clean_name = sct_name
                    for ext in (".sct", ".cfss"):
                        if clean_name.lower().endswith(ext):
                            clean_name = clean_name[:-len(ext)]
                    sections.append({
                        "name": clean_name,
                        "raw_name": sct_name,
                        "offset": sct_offset,
                        "type": t_info["name"],
                        "lib": lib_name
                    })
                t_info["sections"] = sections

            result["types"] = types_info
            return result

    @staticmethod
    def load_section(file_path: str, offset: int, to_metric: bool = True) -> SectionGeometry:
        """
        Parses section geometry from a binary offset in .cfsl file.
        Converts Imperial (inches) to Metric (mm) by default (factor 25.4).
        """
        unit_scale = 25.4 if to_metric else 1.0

        with open(file_path, "rb") as f:
            # 1-indexed offset
            f.seek(max(0, offset - 1))

            b0, b1 = struct.unpack("BB", f.read(2))
            app_ver = b0 * 100 + b1

            # RevDate (8 bytes Date)
            if app_ver <= 100:
                f.read(18)
            else:
                f.read(8)

            # Metadata strings
            if app_ver >= 100:
                rev_by_len = 40 if app_ver >= 410 else 16
                f.read(rev_by_len)  # RevBy
                f.read(40)          # Description
                f.read(40)          # Project

            if app_ver <= 100:
                f.read(4)  # Fy
                if app_ver == 100:
                    f.read(4)  # Fu
                f.read(4)  # Eo
                f.read(4)  # Value2
                f.read(4)  # Value7
            else:
                # VB Boolean (2 bytes)
                struct.unpack("<h", f.read(2))  # ColdWork
                if app_ver >= 1100:
                    struct.unpack("<h", f.read(2))  # Reserve
                f.read(24)  # Material Name
                if app_ver >= 1400:
                    f.read(1)  # Family
                f.read(20)  # 5 x Eo
                f.read(20)  # 5 x Fy
                f.read(20)  # 5 x N
                f.read(4)   # Fu
                f.read(4)   # FyMin
                f.read(4)   # FuMin
                f.read(4)   # FuMax
                if app_ver >= 1400:
                    f.read(12)  # Elong, ElongThin, ThkMin

            # Overrides & DSM
            f.read(4)  # CwOverride
            f.read(4)  # JOverride
            if app_ver >= 400:
                f.read(4)  # ConnSpacing
            if app_ver >= 1000:
                f.read(4)  # HoleLength
            if app_ver >= 1100:
                f.read(4)  # HoleSpacing

            if app_ver >= 500:
                f.read(2)   # UseDSM
                f.read(2)   # PreQualified
                f.read(40)  # 10 x DSM curves
                if app_ver >= 800:
                    f.read(8)  # Vcry, Vcrx

            # Number of Parts (1 byte in Section.cs)
            n_part = struct.unpack("B", f.read(1))[0]
            if n_part <= 0:
                n_part = 1

            all_elements: List[Element] = []
            elem_counter = 1
            main_thickness = 2.0

            for p_idx in range(n_part):
                if app_ver > 100:
                    f.read(20)  # Part Name
                    struct.unpack("<h", f.read(2))  # Centerline
                    struct.unpack("<h", f.read(2))  # Closed
                    def_rad = struct.unpack("<f", f.read(4))[0] * unit_scale
                    f.read(1)   # val8
                    f.read(1)   # val9
                else:
                    def_rad = 0.0

                x_pos = struct.unpack("<f", f.read(4))[0] * unit_scale
                y_pos = struct.unpack("<f", f.read(4))[0] * unit_scale
                thickness = struct.unpack("<f", f.read(4))[0] * unit_scale
                if thickness > 0:
                    main_thickness = thickness

                n_elem = struct.unpack("B", f.read(1))[0]

                cur_x = x_pos
                cur_y = y_pos

                for e_idx in range(n_elem):
                    length = struct.unpack("<f", f.read(4))[0] * unit_scale
                    angle = struct.unpack("<f", f.read(4))[0]  # Radians
                    if app_ver <= 100:
                        angle = angle * math.pi / 180.0
                    rad = struct.unpack("<f", f.read(4))[0] * unit_scale
                    web_flag = struct.unpack("B", f.read(1))[0]
                    k_val = struct.unpack("<f", f.read(4))[0]

                    if app_ver >= 100:
                        hole = struct.unpack("<f", f.read(4))[0]
                        dist = struct.unpack("<f", f.read(4))[0]

                    x0 = cur_x
                    y0 = cur_y
                    x1 = cur_x + length * math.cos(angle)
                    y1 = cur_y + length * math.sin(angle)
                    cur_x, cur_y = x1, y1

                    all_elements.append(
                        Element(
                            elem_id=elem_counter,
                            length=length,
                            angle=angle,
                            radius=rad,
                            thickness=thickness,
                            x0=x0,
                            y0=y0,
                            x1=x1,
                            y1=y1
                        )
                    )
                    elem_counter += 1

            total_len = sum(e.length for e in all_elements)
            geom = SectionGeometry(
                elements=all_elements,
                thickness=main_thickness,
                is_closed=False,
                total_length=total_len
            )
            return geom


class ColdWorkCalculator:
    """
    Calculates cold-work forming yield strength increase (Fya)
    according to AISI S100 Section A3.3.2 and KDS 14 31 10 3.3.2.
    """

    @staticmethod
    def calculate(
        base_fy: float,
        base_fu: float,
        r_inside: float,
        thickness: float,
        num_corners: int,
        total_length: float
    ) -> Dict[str, Any]:
        """
        :param base_fy: Virgin yield stress (MPa)
        :param base_fu: Virgin tensile strength (MPa)
        :param r_inside: Inside bend radius (mm)
        :param thickness: Design thickness (mm)
        :param num_corners: Number of 90-degree corners
        :param total_length: Total centerline length of cross-section (mm)
        """
        if base_fy <= 0 or base_fu <= base_fy:
            return {"fya": base_fy, "fyc": base_fy, "percent_increase": 0.0, "c_ratio": 0.0}

        ratio_fu_fy = base_fu / base_fy
        # Bc = 3.69 * (Fu/Fy) - 0.819 * (Fu/Fy)^2 - 1.79
        bc = 3.69 * ratio_fu_fy - 0.819 * (ratio_fu_fy ** 2) - 1.79
        # m = 0.192 * (Fu/Fy) - 0.068
        m_exp = 0.192 * ratio_fu_fy - 0.068

        r_over_t = max(r_inside / thickness, 0.1) if thickness > 0 else 1.0
        # Fyc = Bc * Fy / (R/t)^m
        fyc = min((bc * base_fy) / (r_over_t ** m_exp), base_fu)

        # C = Corner area ratio
        r_mid = r_inside + thickness / 2.0
        corner_arc_len = (math.pi / 2.0) * r_mid
        total_corner_len = num_corners * corner_arc_len
        c_ratio = min(max(total_corner_len / total_length, 0.0), 1.0) if total_length > 0 else 0.0

        # Fya = C * Fyc + (1 - C) * Fy
        fya = c_ratio * fyc + (1.0 - c_ratio) * base_fy
        fya = min(max(fya, base_fy), base_fu)
        percent_increase = ((fya - base_fy) / base_fy) * 100.0

        return {
            "base_fy": round(base_fy, 2),
            "base_fu": round(base_fu, 2),
            "fyc": round(fyc, 2),
            "fya": round(fya, 2),
            "c_ratio": round(c_ratio, 4),
            "percent_increase": round(percent_increase, 2)
        }


# Standard Material Presets
STANDARD_MATERIALS = [
    {"code": "SSC275", "name": "KDS 냉간성형 탄소강 SSC275", "fy": 275.0, "fu": 410.0, "e": 205000.0, "nu": 0.3, "category": "KDS/KS"},
    {"code": "SSC355", "name": "KDS 고강도 냉간성형강 SSC355", "fy": 355.0, "fu": 490.0, "e": 205000.0, "nu": 0.3, "category": "KDS/KS"},
    {"code": "SSC400", "name": "KDS 구조용 냉간성형강 SSC400", "fy": 235.0, "fu": 400.0, "e": 205000.0, "nu": 0.3, "category": "KDS/KS"},
    {"code": "SSC490", "name": "KDS 고인장 냉간성형강 SSC490", "fy": 315.0, "fu": 490.0, "e": 205000.0, "nu": 0.3, "category": "KDS/KS"},
    {"code": "A1008_33", "name": "ASTM A1008 Grade 33", "fy": 228.0, "fu": 359.0, "e": 203000.0, "nu": 0.3, "category": "ASTM"},
    {"code": "A1008_50", "name": "ASTM A1008 Grade 50", "fy": 345.0, "fu": 448.0, "e": 203000.0, "nu": 0.3, "category": "ASTM"},
    {"code": "A653_33", "name": "ASTM A653 HSLAS Grade 33", "fy": 228.0, "fu": 359.0, "e": 203000.0, "nu": 0.3, "category": "ASTM"},
    {"code": "A653_50", "name": "ASTM A653 HSLAS Grade 50", "fy": 345.0, "fu": 448.0, "e": 203000.0, "nu": 0.3, "category": "ASTM"},
    {"code": "A653_80", "name": "ASTM A653 Grade 80 (Full Hard)", "fy": 552.0, "fu": 565.0, "e": 203000.0, "nu": 0.3, "category": "ASTM"},
    {"code": "STS304", "name": "스테인리스강 SUS304 / 304", "fy": 205.0, "fu": 520.0, "e": 193000.0, "nu": 0.3, "category": "Stainless"},
    {"code": "STS316", "name": "스테인리스강 SUS316 / 316", "fy": 205.0, "fu": 520.0, "e": 193000.0, "nu": 0.3, "category": "Stainless"}
]
