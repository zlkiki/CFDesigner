"""
Quick Design & Optimal Section Auto-Sizing Engine (100% Full-Spec frmQuickDesign.cs Migration)
Implements automated selection of lightest cold-formed sections satisfying 3 major Limit States:
1. Strength (Axial P-M Biaxial Interaction & Shear per KDS 14 31 10 / AISI S100)
2. Serviceability Deflection (Live Load L/360, Total Load L/240 limits)
3. Web Crippling (Bearing Length N, End/Interior Reaction Ru vs phi*Pnc)
"""

from dataclasses import dataclass, field
from typing import List, Dict, Any, Optional
import os
import math

from ..geometry.library_parser import CFSLibraryParser, ColdWorkCalculator
from ..geometry.gross_properties import SectionPropertiesCalculator
from ..cad.part_mesher import Element, SectionGeometry
from ..design.dsm_compression import DSMCompression
from ..design.dsm_flexure import DSMFlexure
from ..design.shear_and_crippling import WebShearAndCrippling
from ..design.beam_column import BeamColumnInteraction


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
    dc_combined: float         # Strength P-M D/C
    dc_strength: float         # Max strength D/C
    deflection_live_mm: float  # mm
    deflection_live_limit_mm: float # mm
    dc_deflection_live: float
    deflection_total_mm: float # mm
    deflection_total_limit_mm: float # mm
    dc_deflection_total: float
    dc_deflection: float       # Max deflection D/C
    reaction_ru_kn: float      # kN
    phi_pnc_kn: float          # kN
    dc_crippling: float        # Web crippling D/C
    max_dc: float              # Overall controlling D/C ratio
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
    Scans library sections, executes multi-axis DSM strength, deflection, and web crippling checks,
    and ranks valid candidates by minimum steel unit weight (kg/m).
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
                    type_str = t.get("name", "")
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

                            # Determine shape code: "S" (Stud/Lipped) vs "T" (Track/Unlipped)
                            # Studs have lip return elements (typically > 3 elements or non-zero lip)
                            has_lip = len(geom.elements) >= 5
                            shape_code = "S" if has_lip else "T"

                            cached.append({
                                "name": s.get("name", "Unknown"),
                                "library_name": lib_name,
                                "type_name": type_str,
                                "shape_code": shape_code,
                                "depth": depth,
                                "flange": flange,
                                "thickness": geom.thickness,
                                "area": props.area,
                                "ix": props.ix,
                                "iy": props.iy,
                                "sx": props.sx_top if props.sx_top > 0 else (props.ix / (depth / 2.0) if depth > 0 else 1.0),
                                "sy": props.sy_left if props.sy_left > 0 else (props.iy / (flange / 2.0) if flange > 0 else 1.0),
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
        # Direct Load Overrides (legacy compatibility)
        pu_kn: float = 0.0,
        mux_knm: float = 0.0,
        muy_knm: float = 0.0,
        vu_kn: float = 0.0,
        length_mm: float = 3000.0,
        fy_mpa: float = 345.0,
        e_mod: float = 205000.0,
        # Section Filtering (CFS frmQuickDesign)
        depth_filter: Optional[float] = None,
        shape_type_filter: str = "All",       # "All", "S", "T"
        flange_filter: Optional[float] = None,
        thickness_filter: Optional[float] = None,
        punched: bool = False,                # Web punching hole
        config: str = "Single",               # "Single", "Back-to-Back", "Face-to-Face"
        # Material Options
        cold_work: bool = False,
        reserve: bool = False,
        # Span & Spacing & Bracing
        span_mm: Optional[float] = None,
        spacing_mm: float = 400.0,            # mm (16" default)
        bracing: str = "Unbraced",            # "Unbraced", "Midpoint", "Third-point", "Quarter-point", "Fully Braced"
        # Applied Surface Loads
        dead_load_kpa: float = 0.0,           # kN/m2 (psf)
        live_load_kpa: float = 0.0,           # kN/m2 (psf)
        wind_load_kpa: float = 0.0,           # kN/m2 (psf)
        dead_axial_kn: float = 0.0,           # kN (kips)
        live_axial_kn: float = 0.0,           # kN (kips)
        # Deflection & Bearing
        deflection_live_limit: float = 360.0, # L/360
        deflection_total_limit: float = 240.0,# L/240
        bearing_length_mm: float = 38.0,      # N = 1.5" (38mm)
        bearing_condition: str = "EOF",       # "EOF", "IOF", "ETF", "ITF"
        # Limits & Result count
        max_depth_mm: Optional[float] = None,
        max_weight_kgm: Optional[float] = None,
        library_filter: Optional[str] = None,
        max_results: int = 15,
    ) -> QuickDesignResult:
        """
        Scans all sections in the library, runs DSM compression, flexure, shear,
        serviceability deflection, and web crippling checks per KDS 14 31 10 & AISI S100.
        """
        all_sections = cls.preload_library_sections()
        if not all_sections:
            return QuickDesignResult(message="No library sections available.")

        # Span configuration
        actual_span_mm = span_mm if span_mm is not None else length_mm
        span_m = max(actual_span_mm / 1000.0, 0.1)
        spacing_m = max(spacing_mm / 1000.0, 0.05)

        # Unbraced length L_b
        bracing_lower = bracing.lower()
        if "full" in bracing_lower or "continuous" in bracing_lower:
            l_unbraced = 50.0
        elif "quarter" in bracing_lower:
            l_unbraced = actual_span_mm / 4.0
        elif "third" in bracing_lower:
            l_unbraced = actual_span_mm / 3.0
        elif "mid" in bracing_lower:
            l_unbraced = actual_span_mm / 2.0
        else:
            l_unbraced = actual_span_mm

        # Determine applied design loads
        # If surface loads or axial loads are given, compute line load and moments
        has_surface_loads = (dead_load_kpa > 0 or live_load_kpa > 0 or wind_load_kpa > 0 or dead_axial_kn > 0 or live_axial_kn > 0)
        
        if has_surface_loads:
            w_dead_line = dead_load_kpa * spacing_m     # kN/m
            w_live_line = live_load_kpa * spacing_m     # kN/m
            w_wind_line = wind_load_kpa * spacing_m     # kN/m
            
            # Factored uniform load (LRFD: 1.2D + 1.6L + 1.0W)
            w_factored = 1.2 * w_dead_line + 1.6 * w_live_line + 1.0 * w_wind_line # kN/m
            
            # Factored axial load
            calc_pu_kn = 1.2 * dead_axial_kn + 1.6 * live_axial_kn
            calc_mux_knm = (w_factored * (span_m ** 2)) / 8.0
            calc_vu_kn = (w_factored * span_m) / 2.0
            calc_muy_knm = muy_knm
        else:
            calc_pu_kn = pu_kn
            calc_mux_knm = mux_knm
            calc_muy_knm = muy_knm
            calc_vu_kn = vu_kn
            # Infer unfactored loads for deflection if direct Mux was provided
            w_factored = (8.0 * calc_mux_knm) / (span_m ** 2) if span_m > 0 else 0.0
            w_dead_line = w_factored * 0.4
            w_live_line = w_factored * 0.6

        # Effective material yield strength (considering cold work)
        effective_fy = (fy_mpa * 1.12) if cold_work else fy_mpa

        # Multi-part Configuration multiplier
        config_lower = config.lower()
        part_multiplier = 2.0 if ("back" in config_lower or "face" in config_lower or "double" in config_lower) else 1.0

        candidates = []
        total_scanned = 0

        # Target depth filter
        effective_max_depth = max_depth_mm if max_depth_mm else (depth_filter if depth_filter else None)

        for sct in all_sections:
            lib_name = sct["library_name"]
            if library_filter and library_filter.lower() not in lib_name.lower():
                continue

            # Shape Type Filter ("S" vs "T")
            if shape_type_filter in ["S", "T"] and sct.get("shape_code") != shape_type_filter:
                continue

            # Flange Filter
            if flange_filter and abs(sct["flange"] - flange_filter) > 3.0:
                continue

            # Thickness Filter (mm or mil)
            if thickness_filter:
                target_t_mm = (thickness_filter * 0.0254) if thickness_filter > 10 else thickness_filter
                if abs(sct["thickness"] - target_t_mm) > 0.15:
                    continue

            total_scanned += 1
            raw_area = sct["area"]
            if raw_area <= 0:
                continue

            area = raw_area * part_multiplier
            raw_weight = (raw_area * 1e-6) * cls.STEEL_DENSITY
            weight_kgm = raw_weight * part_multiplier
            depth = sct["depth"]
            flange = sct["flange"]
            thick = sct["thickness"]

            if effective_max_depth and depth > (effective_max_depth + 2.0):
                continue
            if max_weight_kgm and weight_kgm > max_weight_kgm:
                continue

            # Multi-part properties
            ix = sct["ix"] * part_multiplier
            iy = sct["iy"] * part_multiplier
            sx = sct["sx"] * part_multiplier
            sy = sct["sy"] * part_multiplier

            # Punched hole reduction factor
            net_area_factor = 0.85 if punched else 1.0
            net_shear_factor = 0.70 if punched else 1.0
            crip_punch_factor = 0.80 if punched else 1.0

            # -------------------------------------------------------------
            # 1. DSM Compression Check
            # -------------------------------------------------------------
            pu_n = abs(calc_pu_kn) * 1000.0
            i_min = min(ix, iy) if (ix > 0 and iy > 0) else max(ix, iy, 1.0)
            pcre = (math.pi ** 2 * e_mod * i_min) / (l_unbraced ** 2)
            
            py = area * effective_fy * net_area_factor
            pcrl = max(0.45 * py, 1000.0)
            pcrd = max(0.65 * py, 1000.0)

            comp_res = DSMCompression.design_column(
                ag=area * net_area_factor, fy=effective_fy, p_cre=pcre, p_crl=pcrl, p_crd=pcrd
            )
            phi_pn_n = comp_res.phi_pn
            phi_pn_kn = phi_pn_n / 1000.0
            dc_axial = (pu_n / phi_pn_n) if phi_pn_n > 0 else (99.0 if pu_n > 0 else 0.0)

            # -------------------------------------------------------------
            # 2. DSM Flexure Check (X-axis)
            # -------------------------------------------------------------
            mux_nmm = abs(calc_mux_knm) * 1e6
            my_yield = sx * effective_fy * (1.10 if reserve else 1.0)
            mcre = (math.pi ** 2 * e_mod * iy) / (l_unbraced ** 2) * max(depth / 2.0, 1.0)
            mcrl = max(0.55 * my_yield, 1000.0)
            mcrd = max(0.75 * my_yield, 1000.0)

            flex_res = DSMFlexure.design_beam(
                sf=sx, fy=effective_fy, m_cre=mcre, m_crl=mcrl, m_crd=mcrd
            )
            phi_mnx_nmm = flex_res.phi_mn
            phi_mnx_knm = phi_mnx_nmm / 1e6
            dc_flex = (mux_nmm / phi_mnx_nmm) if phi_mnx_nmm > 0 else (99.0 if mux_nmm > 0 else 0.0)

            # -------------------------------------------------------------
            # 3. Shear Check
            # -------------------------------------------------------------
            vu_n = abs(calc_vu_kn) * 1000.0
            vn_single = WebShearAndCrippling.calculate_shear(
                h=depth, t=thick, fy=effective_fy, e_mod=e_mod
            )
            vn_n = vn_single * part_multiplier * net_shear_factor
            phi_vn_n = WebShearAndCrippling.PHI_V * vn_n
            phi_vn_kn = phi_vn_n / 1000.0
            dc_shear = (vu_n / phi_vn_n) if phi_vn_n > 0 else (99.0 if vu_n > 0 else 0.0)

            # -------------------------------------------------------------
            # 4. Strength Combined P-M Interaction
            # -------------------------------------------------------------
            interaction = BeamColumnInteraction.check_interaction(
                pu=pu_n,
                phi_pn=phi_pn_n,
                mux=mux_nmm,
                phi_mnx=phi_mnx_nmm,
                muy=abs(calc_muy_knm) * 1e6,
                phi_mny=max(phi_mnx_nmm * 0.3, 1000.0),
                cmx=1.0,
                cmy=1.0
            )
            dc_combined = interaction.controlling_dcr
            dc_strength = max(dc_combined, dc_shear)

            # -------------------------------------------------------------
            # 5. Serviceability Deflection Check (Live & Total)
            # -------------------------------------------------------------
            # delta = 5 * w * L^4 / (384 * E * Ix)
            # w in N/mm, L in mm, E in MPa (N/mm2), Ix in mm4
            w_live_n_per_mm = w_live_line  # 1 kN/m = 1 N/mm
            w_total_n_per_mm = (w_dead_line + w_live_line)

            if ix > 0 and e_mod > 0:
                defl_live_mm = (5.0 * w_live_n_per_mm * (actual_span_mm ** 4)) / (384.0 * e_mod * ix)
                defl_total_mm = (5.0 * w_total_n_per_mm * (actual_span_mm ** 4)) / (384.0 * e_mod * ix)
            else:
                defl_live_mm = 0.0
                defl_total_mm = 0.0

            allow_live_defl_mm = actual_span_mm / max(deflection_live_limit, 1.0)
            allow_total_defl_mm = actual_span_mm / max(deflection_total_limit, 1.0)

            dc_defl_live = (defl_live_mm / allow_live_defl_mm) if allow_live_defl_mm > 0 else 0.0
            dc_defl_total = (defl_total_mm / allow_total_defl_mm) if allow_total_defl_mm > 0 else 0.0
            dc_deflection = max(dc_defl_live, dc_defl_total)

            # -------------------------------------------------------------
            # 6. Web Crippling Check (Bearing N vs Reaction Ru)
            # -------------------------------------------------------------
            ru_kn = calc_vu_kn  # End reaction Ru = Vu
            crip_adv = WebShearAndCrippling.calculate_web_crippling_advanced(
                h=depth,
                t=thick,
                r=thick,
                n_bearing=bearing_length_mm,
                fy=effective_fy,
                condition=bearing_condition,
                fastened=True,
                stiffened=(sct.get("shape_code") == "S"),
                ru=ru_kn
            )
            phi_pnc_kn = (crip_adv.phi_pnc / 1000.0) * part_multiplier * crip_punch_factor
            dc_crippling = (ru_kn / phi_pnc_kn) if phi_pnc_kn > 0 else (99.0 if ru_kn > 0 else 0.0)

            # -------------------------------------------------------------
            # Overall Governing D/C Ratio
            # -------------------------------------------------------------
            max_dc = max(dc_strength, dc_deflection, dc_crippling)

            if max_dc <= 1.02:
                candidates.append({
                    "name": sct["name"],
                    "library_name": sct["library_name"],
                    "weight": round(weight_kgm, 2),
                    "depth": round(depth, 1),
                    "flange": round(flange, 1),
                    "thickness": round(thick, 2),
                    "pu": round(calc_pu_kn, 2),
                    "phi_pn": round(phi_pn_kn, 2),
                    "dc_axial": round(dc_axial, 3),
                    "mux": round(calc_mux_knm, 2),
                    "phi_mnx": round(phi_mnx_knm, 2),
                    "dc_flexure": round(dc_flex, 3),
                    "vu": round(calc_vu_kn, 2),
                    "phi_vn": round(phi_vn_kn, 2),
                    "dc_shear": round(dc_shear, 3),
                    "dc_combined": round(dc_combined, 3),
                    "dc_strength": round(dc_strength, 3),
                    "deflection_live_mm": round(defl_live_mm, 2),
                    "deflection_live_limit_mm": round(allow_live_defl_mm, 2),
                    "dc_deflection_live": round(dc_defl_live, 3),
                    "deflection_total_mm": round(defl_total_mm, 2),
                    "deflection_total_limit_mm": round(allow_total_defl_mm, 2),
                    "dc_deflection_total": round(dc_defl_total, 3),
                    "dc_deflection": round(dc_deflection, 3),
                    "reaction_ru_kn": round(ru_kn, 2),
                    "phi_pnc_kn": round(phi_pnc_kn, 2),
                    "dc_crippling": round(dc_crippling, 3),
                    "max_dc": round(max_dc, 3),
                    "elements": sct["elements"]
                })

        # Sort by unit weight ascending, then max_dc ascending
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
                    dc_strength=cand["dc_strength"],
                    deflection_live_mm=cand["deflection_live_mm"],
                    deflection_live_limit_mm=cand["deflection_live_limit_mm"],
                    dc_deflection_live=cand["dc_deflection_live"],
                    deflection_total_mm=cand["deflection_total_mm"],
                    deflection_total_limit_mm=cand["deflection_total_limit_mm"],
                    dc_deflection_total=cand["dc_deflection_total"],
                    dc_deflection=cand["dc_deflection"],
                    reaction_ru_kn=cand["reaction_ru_kn"],
                    phi_pnc_kn=cand["phi_pnc_kn"],
                    dc_crippling=cand["dc_crippling"],
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
                "span_mm": actual_span_mm,
                "spacing_mm": spacing_mm,
                "bracing": bracing,
                "pu_kn": calc_pu_kn,
                "mux_knm": calc_mux_knm,
                "vu_kn": calc_vu_kn,
                "fy_mpa": effective_fy,
                "deflection_live_limit": deflection_live_limit,
                "deflection_total_limit": deflection_total_limit,
                "bearing_length_mm": bearing_length_mm,
                "config": config,
                "punched": punched
            },
            message=f"Found {len(candidates)} valid sections satisfying Strength, Deflection, and Web Crippling out of {total_scanned} scanned."
        )
