"""
Quick Design & Optimal Section Auto-Sizing Module
Implements automated selection of lightest cold-formed sections satisfying KDS/AISI design demands.
"""

from dataclasses import dataclass, field
from typing import List, Dict, Any, Optional
import os
import math

from ..geometry.library_parser import CFSLibraryParser
from ..geometry.gross_properties import SectionPropertiesCalculator
from ..cad.part_mesher import Element, SectionGeometry
from ..design.dsm_compression import DSMCompression
from ..design.dsm_flexure import DSMFlexure
from ..design.shear_and_crippling import WebShearAndCrippling


@dataclass
class QuickDesignCandidate:
    rank: int
    name: str
    library_name: str
    weight: float              # kg/m
    depth: float               # mm
    flange: float              # mm
    thickness: float           # mm
    pu: float                  # kN
    phi_pn: float              # kN
    dc_axial: float
    mux: float                 # kNm
    phi_mnx: float             # kNm
    dc_flexure: float
    vu: float                  # kN
    phi_vn: float              # kN
    dc_shear: float
    dc_combined: float
    max_dc: float
    weight_savings_pct: float  # Savings vs heaviest passing candidate
    elements: List[Dict[str, Any]] = field(default_factory=list)


@dataclass
class QuickDesignResult:
    total_scanned: int = 0
    total_passed: int = 0
    candidates: List[QuickDesignCandidate] = field(default_factory=list)
    query_params: Dict[str, Any] = field(default_factory=dict)
    message: str = ""


class QuickDesignEngine:
    """
    Scans library sections, executes DSM design checks, and ranks them by minimum weight.
    """

    STEEL_DENSITY = 7850.0  # kg/m^3
    _SECTION_CACHE: List[Dict[str, Any]] = []

    @classmethod
    def preload_library_sections(cls, lib_dir: Optional[str] = None) -> List[Dict[str, Any]]:
        """
        Loads and caches section geometries and gross properties from all .cfsl files.
        """
        if cls._SECTION_CACHE:
            return cls._SECTION_CACHE

        if not lib_dir:
            from src.resource_helper import get_resource_path
            possible_dirs = [
                get_resource_path("original_source"),
                "original_source",
                os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", "original_source")),
                os.path.join(os.getcwd(), "original_source")
            ]
            for d in possible_dirs:
                if os.path.exists(d) and any(f.endswith(".cfsl") for f in os.listdir(d)):
                    lib_dir = d
                    break
            if not lib_dir:
                lib_dir = "original_source"

        cached = []
        if not os.path.exists(lib_dir):
            return cached

        for filename in sorted(os.listdir(lib_dir)):
            if not filename.lower().endswith(".cfsl"):
                continue
            lib_name = os.path.splitext(filename)[0]
            file_path = os.path.join(lib_dir, filename)

            try:
                summary = CFSLibraryParser.get_library_summary(file_path)
                for t in summary.get("types", []):
                    for s in t.get("sections", []):
                        offset = s.get("offset", 0)
                        try:
                            geom = CFSLibraryParser.load_section(file_path, offset, to_metric=True)
                            if not geom.elements:
                                continue

                            props = SectionPropertiesCalculator.calculate(geom)

                            # Extract bounds
                            xs = [e.x0 for e in geom.elements] + [e.x1 for e in geom.elements]
                            ys = [e.y0 for e in geom.elements] + [e.y1 for e in geom.elements]
                            depth = (max(ys) - min(ys)) if ys else 0.0
                            flange = (max(xs) - min(xs)) if xs else 0.0

                            cached.append({
                                "name": s.get("name", "Unknown"),
                                "library_name": lib_name,
                                "type_name": t.get("name", ""),
                                "depth": depth,
                                "flange": flange,
                                "thickness": geom.thickness,
                                "area": props.area,
                                "ix": props.ix,
                                "iy": props.iy,
                                "sx": props.sx_top,
                                "sy": props.sy_left,
                                "rx": props.rx,
                                "ry": props.ry,
                                "elements": [
                                    {
                                        "elem_id": e.elem_id,
                                        "x0": e.x0, "y0": e.y0,
                                        "x1": e.x1, "y1": e.y1,
                                        "length": e.length,
                                        "angle": e.angle,
                                        "thickness": e.thickness,
                                        "radius": e.radius
                                    }
                                    for e in geom.elements
                                ]
                            })
                        except Exception:
                            continue
            except Exception:
                continue

        cls._SECTION_CACHE = cached
        return cached

    @classmethod
    def search_optimal_sections(
        cls,
        pu_kn: float = 0.0,
        mux_knm: float = 0.0,
        muy_knm: float = 0.0,
        vu_kn: float = 0.0,
        length_mm: float = 3000.0,
        fy_mpa: float = 300.0,
        e_mod: float = 205000.0,
        max_depth_mm: Optional[float] = None,
        max_weight_kgm: Optional[float] = None,
        library_filter: Optional[str] = None,
        max_results: int = 15,
    ) -> QuickDesignResult:
        """
        Scans all sections in the library, runs DSM compression, flexure, and shear checks,
        and returns the top candidates sorted by weight.
        """
        all_sections = cls.preload_library_sections()
        if not all_sections:
            return QuickDesignResult(message="No library sections available.")

        candidates = []
        total_scanned = 0

        # Required forces in N, N-mm
        pu_n = abs(pu_kn) * 1000.0
        mux_nmm = abs(mux_knm) * 1e6
        vu_n = abs(vu_kn) * 1000.0
        l_unbraced = max(length_mm, 100.0)

        for sct in all_sections:
            lib_name = sct["library_name"]
            if library_filter and library_filter.lower() not in lib_name.lower():
                continue

            total_scanned += 1
            area = sct["area"]
            if area <= 0:
                continue

            # Unit weight in kg/m: A(mm^2) * 1e-6 (m^2) * 7850 kg/m^3
            weight_kgm = (area * 1e-6) * cls.STEEL_DENSITY
            depth = sct["depth"]
            flange = sct["flange"]
            thick = sct["thickness"]

            if max_depth_mm and depth > max_depth_mm:
                continue
            if max_weight_kgm and weight_kgm > max_weight_kgm:
                continue

            # 1. DSM Compression Check
            ix = sct["ix"]
            iy = sct["iy"]
            i_min = min(ix, iy) if (ix > 0 and iy > 0) else max(ix, iy, 1.0)
            pcre = (math.pi ** 2 * e_mod * i_min) / (l_unbraced ** 2)
            
            py = area * fy_mpa
            pcrl = max(0.45 * py, 1000.0)
            pcrd = max(0.65 * py, 1000.0)

            comp_res = DSMCompression.design_column(
                ag=area, fy=fy_mpa, p_cre=pcre, p_crl=pcrl, p_crd=pcrd
            )
            phi_pn_n = comp_res.phi_pn
            phi_pn_kn = phi_pn_n / 1000.0
            dc_axial = (pu_n / phi_pn_n) if phi_pn_n > 0 else (99.0 if pu_n > 0 else 0.0)

            # 2. DSM Flexure Check (X-axis)
            sx = sct["sx"] if sct["sx"] > 0 else (ix / (depth / 2.0) if depth > 0 else 1.0)
            my_yield = sx * fy_mpa
            mcre = (math.pi ** 2 * e_mod * iy) / (l_unbraced ** 2) * max(depth / 2.0, 1.0)
            mcrl = max(0.55 * my_yield, 1000.0)
            mcrd = max(0.75 * my_yield, 1000.0)

            flex_res = DSMFlexure.design_beam(
                sf=sx, fy=fy_mpa, m_cre=mcre, m_crl=mcrl, m_crd=mcrd
            )
            phi_mnx_nmm = flex_res.phi_mn
            phi_mnx_knm = phi_mnx_nmm / 1e6
            dc_flex = (mux_nmm / phi_mnx_nmm) if phi_mnx_nmm > 0 else (99.0 if mux_nmm > 0 else 0.0)

            # 3. Shear Check
            vn_n = WebShearAndCrippling.calculate_shear(
                h=depth, t=thick, fy=fy_mpa, e_mod=e_mod
            )
            phi_vn_n = WebShearAndCrippling.PHI_V * vn_n
            phi_vn_kn = phi_vn_n / 1000.0
            dc_shear = (vu_n / phi_vn_n) if phi_vn_n > 0 else (99.0 if vu_n > 0 else 0.0)

            # 4. Combined Interaction
            dc_comb = dc_axial + dc_flex
            max_dc = max(dc_axial, dc_flex, dc_comb, dc_shear)

            if max_dc <= 1.02:
                candidates.append({
                    "name": sct["name"],
                    "library_name": sct["library_name"],
                    "weight": round(weight_kgm, 2),
                    "depth": round(depth, 1),
                    "flange": round(flange, 1),
                    "thickness": round(thick, 2),
                    "pu": round(pu_kn, 2),
                    "phi_pn": round(phi_pn_kn, 2),
                    "dc_axial": round(dc_axial, 3),
                    "mux": round(mux_knm, 2),
                    "phi_mnx": round(phi_mnx_knm, 2),
                    "dc_flexure": round(dc_flex, 3),
                    "vu": round(vu_kn, 2),
                    "phi_vn": round(phi_vn_kn, 2),
                    "dc_shear": round(dc_shear, 3),
                    "dc_combined": round(dc_comb, 3),
                    "max_dc": round(max_dc, 3),
                    "elements": sct["elements"]
                })

        # Sort by weight ascending, then max_dc ascending
        candidates.sort(key=lambda x: (x["weight"], x["max_dc"]))

        ranked_candidates = []
        max_wt = candidates[-1]["weight"] if candidates else 0.0

        for idx, cand in enumerate(candidates[:max_results]):
            savings = round(((max_wt - cand["weight"]) / max_wt * 100.0), 1) if max_wt > 0 else 0.0
            ranked_candidates.append(
                QuickDesignCandidate(
                    rank=idx + 1,
                    name=cand["name"],
                    library_name=cand["library_name"],
                    weight=cand["weight"],
                    depth=cand["depth"],
                    flange=cand["flange"],
                    thickness=cand["thickness"],
                    pu=cand["pu"],
                    phi_pn=cand["phi_pn"],
                    dc_axial=cand["dc_axial"],
                    mux=cand["mux"],
                    phi_mnx=cand["phi_mnx"],
                    dc_flexure=cand["dc_flexure"],
                    vu=cand["vu"],
                    phi_vn=cand["phi_vn"],
                    dc_shear=cand["dc_shear"],
                    dc_combined=cand["dc_combined"],
                    max_dc=cand["max_dc"],
                    weight_savings_pct=savings,
                    elements=cand["elements"]
                )
            )

        return QuickDesignResult(
            total_scanned=total_scanned,
            total_passed=len(candidates),
            candidates=ranked_candidates,
            query_params={
                "pu_kn": pu_kn,
                "mux_knm": mux_knm,
                "vu_kn": vu_kn,
                "length_mm": length_mm,
                "fy_mpa": fy_mpa,
                "max_depth_mm": max_depth_mm,
                "max_weight_kgm": max_weight_kgm
            },
            message=f"Found {len(candidates)} valid sections out of {total_scanned} scanned."
        )
