"""
KDS 14 31 10 & AISI S100-16 Structural Calculation Trace Engine.
Full Port of CFS Legacy strTrace (Section.cs:2715~3600) and EqText (Section.cs:6660~7000).
Generates rigorous engineering formula definitions, actual substituted values,
intermediate parameters, and design code clause mappings for calculation sheets.
"""

from dataclasses import dataclass, field
from typing import List, Dict, Any, Optional
import math


@dataclass
class TraceItem:
    """Represents a single detailed calculation trace item with standard engineering notation."""
    id: str = ""
    title: str = ""
    clause_kds: str = ""
    clause_aisi: str = ""
    formula_raw: str = ""
    formula_latex: str = ""
    substituted_text: str = ""
    substituted_latex: str = ""
    parameters: Dict[str, Any] = field(default_factory=dict)
    nominal_value: float = 0.0
    phi: float = 1.0
    design_value: float = 0.0
    omega: float = 1.0
    allowable_value: float = 0.0
    demand_value: Optional[float] = None
    dc_ratio: Optional[float] = None
    status: str = "OK"  # "OK" or "NG"
    unit: str = ""
    notes: str = ""

    def to_dict(self) -> Dict[str, Any]:
        return {
            "id": self.id,
            "title": self.title,
            "clause_kds": self.clause_kds,
            "clause_aisi": self.clause_aisi,
            "formula_raw": self.formula_raw,
            "formula_latex": self.formula_latex,
            "substituted_text": self.substituted_text,
            "substituted_latex": self.substituted_latex,
            "parameters": self.parameters,
            "nominal_value": round(self.nominal_value, 2),
            "phi": round(self.phi, 2),
            "design_value": round(self.design_value, 2),
            "omega": round(self.omega, 2),
            "allowable_value": round(self.allowable_value, 2),
            "demand_value": round(self.demand_value, 2) if self.demand_value is not None else None,
            "dc_ratio": round(self.dc_ratio, 3) if self.dc_ratio is not None else None,
            "status": self.status,
            "unit": self.unit,
            "notes": self.notes,
        }


@dataclass
class DesignTraceResult:
    """Aggregates calculation traces across all structural limit states."""
    tension: List[TraceItem] = field(default_factory=list)
    compression: List[TraceItem] = field(default_factory=list)
    flexure_x: List[TraceItem] = field(default_factory=list)
    flexure_y: List[TraceItem] = field(default_factory=list)
    shear: List[TraceItem] = field(default_factory=list)
    web_crippling: List[TraceItem] = field(default_factory=list)
    interaction: List[TraceItem] = field(default_factory=list)
    summary_logs: List[str] = field(default_factory=list)
    equations_cfs: List[str] = field(default_factory=list)

    def to_dict(self) -> Dict[str, Any]:
        return {
            "tension": [item.to_dict() for item in self.tension],
            "compression": [item.to_dict() for item in self.compression],
            "flexure_x": [item.to_dict() for item in self.flexure_x],
            "flexure_y": [item.to_dict() for item in self.flexure_y],
            "shear": [item.to_dict() for item in self.shear],
            "web_crippling": [item.to_dict() for item in self.web_crippling],
            "interaction": [item.to_dict() for item in self.interaction],
            "summary_logs": self.summary_logs,
            "equations_cfs": self.equations_cfs,
        }


class KDSTraceEngine:
    """
    Core calculation trace engine producing rigorous equation traces conforming to
    KDS 14 31 10 and AISI S100-16 specifications.
    """

    # -------------------------------------------------------------
    # 1. Axial Tension Trace (Section.cs:2771~2803)
    # -------------------------------------------------------------
    @staticmethod
    def trace_tension(
        ag: float,
        an: float,
        fy: float,
        fu: float,
        tu: float = 0.0,
    ) -> List[TraceItem]:
        traces = []
        
        # 1.1 Gross section yielding
        # Tn = Ag * Fy, phi_t = 0.90, Omega_t = 1.67
        tn_yield = ag * fy / 1000.0  # kN
        phi_t_yield = 0.90
        omega_t_yield = 1.67
        phi_tn_yield = phi_t_yield * tn_yield
        ta_yield = tn_yield / omega_t_yield
        dc_yield = (tu / phi_tn_yield) if phi_tn_yield > 1e-6 else 0.0

        traces.append(TraceItem(
            id="tension_yield",
            title="인장 강도 - 총단면 항복 (Gross Section Yielding)",
            clause_kds="KDS 14 31 10 (4.1.1)",
            clause_aisi="AISI S100-16 Eq. C2-1",
            formula_raw="Tn = Ag * Fy, phi_t = 0.90, Omega_t = 1.67",
            formula_latex=r"T_n = A_g \cdot F_y \quad (\phi_t = 0.90, \; \Omega_t = 1.67)",
            substituted_text=f"Tn = {ag:,.1f} mm² * {fy:.1f} MPa = {tn_yield:,.1f} kN (phi*Tn = {phi_tn_yield:,.1f} kN)",
            substituted_latex=rf"T_n = {ag:,.1f} \text{{ mm}}^2 \times {fy:.1f} \text{{ MPa}} = {tn_yield:,.1f} \text{{ kN}} \quad (\phi_t T_n = {phi_tn_yield:,.1f} \text{{ kN}})",
            parameters={"Ag": ag, "Fy": fy},
            nominal_value=tn_yield,
            phi=phi_t_yield,
            design_value=phi_tn_yield,
            omega=omega_t_yield,
            allowable_value=ta_yield,
            demand_value=tu,
            dc_ratio=dc_yield,
            status="OK" if dc_yield <= 1.0 else "NG",
            unit="kN",
            notes="총단면 항복 한계상태 검토",
        ))

        # 1.2 Net section rupture
        # Tn = An * Fu, phi_t = 0.75, Omega_t = 2.00
        an_eff = an if an > 0 else ag
        tn_rupture = an_eff * fu / 1000.0  # kN
        phi_t_rupture = 0.75
        omega_t_rupture = 2.00
        phi_tn_rupture = phi_t_rupture * tn_rupture
        ta_rupture = tn_rupture / omega_t_rupture
        dc_rupture = (tu / phi_tn_rupture) if phi_tn_rupture > 1e-6 else 0.0

        traces.append(TraceItem(
            id="tension_rupture",
            title="인장 강도 - 순단면 파단 (Net Section Rupture)",
            clause_kds="KDS 14 31 10 (4.1.1)",
            clause_aisi="AISI S100-16 Eq. C2-2",
            formula_raw="Tn = An * Fu, phi_t = 0.75, Omega_t = 2.00",
            formula_latex=r"T_n = A_n \cdot F_u \quad (\phi_t = 0.75, \; \Omega_t = 2.00)",
            substituted_text=f"Tn = {an_eff:,.1f} mm² * {fu:.1f} MPa = {tn_rupture:,.1f} kN (phi*Tn = {phi_tn_rupture:,.1f} kN)",
            substituted_latex=rf"T_n = {an_eff:,.1f} \text{{ mm}}^2 \times {fu:.1f} \text{{ MPa}} = {tn_rupture:,.1f} \text{{ kN}} \quad (\phi_t T_n = {phi_tn_rupture:,.1f} \text{{ kN}})",
            parameters={"An": an_eff, "Fu": fu},
            nominal_value=tn_rupture,
            phi=phi_t_rupture,
            design_value=phi_tn_rupture,
            omega=omega_t_rupture,
            allowable_value=ta_rupture,
            demand_value=tu,
            dc_ratio=dc_rupture,
            status="OK" if dc_rupture <= 1.0 else "NG",
            unit="kN",
            notes="순단면 인장 파단 한계상태 검토",
        ))

        return traces

    # -------------------------------------------------------------
    # 2. Axial Compression Trace (Section.cs:2846~2950 & DSM Compression)
    # -------------------------------------------------------------
    @staticmethod
    def trace_compression(
        ag: float,
        fy: float,
        p_cre: float,
        p_crl: float,
        p_crd: float,
        pu: float = 0.0,
        phi_c: float = 0.85,
        omega_c: float = 1.80,
    ) -> List[TraceItem]:
        traces = []
        py_kn = ag * fy / 1000.0  # Squash load

        # 2.1 Squash load / Yield Capacity
        traces.append(TraceItem(
            id="comp_squash",
            title="단면 항복 축하중 (Squash Yield Load, Py)",
            clause_kds="KDS 14 31 10 (4.1.2)",
            clause_aisi="AISI S100-16 Section E2",
            formula_raw="Py = Ag * Fy",
            formula_latex=r"P_y = A_g \cdot F_y",
            substituted_text=f"Py = {ag:,.1f} mm² * {fy:.1f} MPa = {py_kn:,.1f} kN",
            substituted_latex=rf"P_y = {ag:,.1f} \text{{ mm}}^2 \times {fy:.1f} \text{{ MPa}} = {py_kn:,.1f} \text{{ kN}}",
            parameters={"Ag": ag, "Fy": fy},
            nominal_value=py_kn,
            phi=phi_c,
            design_value=phi_c * py_kn,
            omega=omega_c,
            allowable_value=py_kn / omega_c,
            unit="kN",
            notes="완전 지지 총단면 압축 항복내력",
        ))

        # 2.2 Global Buckling (Pne)
        p_cre_kn = p_cre / 1000.0 if p_cre > 0 else 1e-6
        lambda_c = math.sqrt(py_kn / p_cre_kn) if p_cre_kn > 1e-6 else 10.0
        if lambda_c <= 1.5:
            pne_kn = (0.658 ** (lambda_c ** 2)) * py_kn
            fn_desc = f"lambda_c = {lambda_c:.3f} <= 1.5 (비탄성): Pne = (0.658^(lambda_c²)) * Py"
            fn_latex = rf"\lambda_c = {lambda_c:.3f} \le 1.5 \implies P_{{ne}} = (0.658^{{\lambda_c^2}}) P_y"
        else:
            pne_kn = (0.877 / (lambda_c ** 2)) * py_kn
            fn_desc = f"lambda_c = {lambda_c:.3f} > 1.5 (탄성): Pne = (0.877 / lambda_c²) * Py"
            fn_latex = rf"\lambda_c = {lambda_c:.3f} > 1.5 \implies P_{{ne}} = \left(\frac{{0.877}}{{\lambda_c^2}}\right) P_y"

        traces.append(TraceItem(
            id="comp_global",
            title="전체 좌굴 공칭강도 (Global Column Buckling, Pne)",
            clause_kds="KDS 14 31 10 (4.1.2.1)",
            clause_aisi="AISI S100-16 Section E2",
            formula_raw="lambda_c = sqrt(Py / Pcre); Pne = (0.658^(lambda_c²))*Py or (0.877/lambda_c²)*Py",
            formula_latex=r"\lambda_c = \sqrt{\frac{P_y}{P_{cre}}}, \quad P_{ne} = " + (r"0.658^{\lambda_c^2} P_y" if lambda_c <= 1.5 else r"\frac{0.877}{\lambda_c^2} P_y"),
            substituted_text=f"Pcre = {p_cre_kn:,.1f} kN -> lambda_c = {lambda_c:.3f} -> Pne = {pne_kn:,.1f} kN ({fn_desc})",
            substituted_latex=rf"P_{{cre}} = {p_cre_kn:,.1f} \text{{ kN}} \implies {fn_latex} = {pne_kn:,.1f} \text{{ kN}}",
            parameters={"Pcre": p_cre_kn, "lambda_c": lambda_c, "Py": py_kn},
            nominal_value=pne_kn,
            phi=phi_c,
            design_value=phi_c * pne_kn,
            omega=omega_c,
            allowable_value=pne_kn / omega_c,
            unit="kN",
            notes="기둥 전체 휨/비틀림/휨-비틀림 좌굴 검토",
        ))

        # 2.3 Local Buckling (Pnl)
        p_crl_kn = p_crl / 1000.0 if p_crl > 0 else 1e-6
        lambda_l = math.sqrt(pne_kn / p_crl_kn) if p_crl_kn > 1e-6 else 0.0
        if lambda_l <= 0.776:
            pnl_kn = pne_kn
            pnl_latex = rf"\lambda_l = {lambda_l:.3f} \le 0.776 \implies P_{{nl}} = P_{{ne}}"
        else:
            ratio_l = p_crl_kn / pne_kn
            pnl_kn = (1.0 - 0.15 * (ratio_l ** 0.4)) * (ratio_l ** 0.4) * pne_kn
            pnl_latex = rf"\lambda_l = {lambda_l:.3f} > 0.776 \implies P_{{nl}} = [1 - 0.15 (P_{{crl}}/P_{{ne}})^{{0.4}}] (P_{{crl}}/P_{{ne}})^{{0.4}} P_{{ne}}"

        traces.append(TraceItem(
            id="comp_local",
            title="국부 좌굴 공칭강도 (Local Buckling, Pnl)",
            clause_kds="KDS 14 31 10 (4.1.2.2)",
            clause_aisi="AISI S100-16 Section E3",
            formula_raw="lambda_l = sqrt(Pne / Pcrl); Pnl = Pne or [1 - 0.15*(Pcrl/Pne)^0.4]*(Pcrl/Pne)^0.4*Pne",
            formula_latex=r"\lambda_l = \sqrt{\frac{P_{ne}}{P_{crl}}}, \quad P_{nl} = \left[1 - 0.15 \left(\frac{P_{crl}}{P_{ne}}\right)^{0.4}\right] \left(\frac{P_{crl}}{P_{ne}}\right)^{0.4} P_{ne}",
            substituted_text=f"Pcrl = {p_crl_kn:,.1f} kN -> lambda_l = {lambda_l:.3f} -> Pnl = {pnl_kn:,.1f} kN",
            substituted_latex=rf"P_{{crl}} = {p_crl_kn:,.1f} \text{{ kN}} \implies {pnl_latex} = {pnl_kn:,.1f} \text{{ kN}}",
            parameters={"Pcrl": p_crl_kn, "lambda_l": lambda_l, "Pne": pne_kn},
            nominal_value=pnl_kn,
            phi=phi_c,
            design_value=phi_c * pnl_kn,
            omega=omega_c,
            allowable_value=pnl_kn / omega_c,
            unit="kN",
            notes="판요소 국부좌굴과 전체좌굴의 상호작용 검토",
        ))

        # 2.4 Distortional Buckling (Pnd)
        p_crd_kn = p_crd / 1000.0 if p_crd > 0 else 1e-6
        lambda_d = math.sqrt(py_kn / p_crd_kn) if p_crd_kn > 1e-6 else 0.0
        if lambda_d <= 0.561:
            pnd_kn = py_kn
            pnd_latex = rf"\lambda_d = {lambda_d:.3f} \le 0.561 \implies P_{{nd}} = P_y"
        else:
            ratio_d = p_crd_kn / py_kn
            pnd_kn = (1.0 - 0.25 * (ratio_d ** 0.6)) * (ratio_d ** 0.6) * py_kn
            pnd_latex = rf"\lambda_d = {lambda_d:.3f} > 0.561 \implies P_{{nd}} = [1 - 0.25 (P_{{crd}}/P_y)^{{0.6}}] (P_{{crd}}/P_y)^{{0.6}} P_y"

        traces.append(TraceItem(
            id="comp_distortional",
            title="왜곡 좌굴 공칭강도 (Distortional Buckling, Pnd)",
            clause_kds="KDS 14 31 10 (4.1.2.3)",
            clause_aisi="AISI S100-16 Section E4",
            formula_raw="lambda_d = sqrt(Py / Pcrd); Pnd = Py or [1 - 0.25*(Pcrd/Py)^0.6]*(Pcrd/Py)^0.6*Py",
            formula_latex=r"\lambda_d = \sqrt{\frac{P_y}{P_{crd}}}, \quad P_{nd} = \left[1 - 0.25 \left(\frac{P_{crd}}{P_y}\right)^{0.6}\right] \left(\frac{P_{crd}}{P_y}\right)^{0.6} P_y",
            substituted_text=f"Pcrd = {p_crd_kn:,.1f} kN -> lambda_d = {lambda_d:.3f} -> Pnd = {pnd_kn:,.1f} kN",
            substituted_latex=rf"P_{{crd}} = {p_crd_kn:,.1f} \text{{ kN}} \implies {pnd_latex} = {pnd_kn:,.1f} \text{{ kN}}",
            parameters={"Pcrd": p_crd_kn, "lambda_d": lambda_d, "Py": py_kn},
            nominal_value=pnd_kn,
            phi=phi_c,
            design_value=phi_c * pnd_kn,
            omega=omega_c,
            allowable_value=pnd_kn / omega_c,
            unit="kN",
            notes="플랜지/립 왜곡 변형 좌굴 검토",
        ))

        # 2.5 Controlling Nominal Strength
        pn_kn = min(pne_kn, pnl_kn, pnd_kn)
        phi_pn_kn = phi_c * pn_kn
        pa_kn = pn_kn / omega_c
        dc_comp = (pu / phi_pn_kn) if phi_pn_kn > 1e-6 else 0.0

        gov_mode = "Global (Pne)" if pn_kn == pne_kn else ("Local (Pnl)" if pn_kn == pnl_kn else "Distortional (Pnd)")

        traces.append(TraceItem(
            id="comp_governing",
            title="최종 공칭 및 설계 압축강도 (Governing Compressive Strength, Pn)",
            clause_kds="KDS 14 31 10 (4.1.2)",
            clause_aisi="AISI S100-16 Section E1",
            formula_raw="Pn = min(Pne, Pnl, Pnd), phi_c*Pn = 0.85*Pn",
            formula_latex=r"P_n = \min(P_{ne}, P_{nl}, P_{nd}), \quad \phi_c P_n = 0.85 P_n",
            substituted_text=f"Pn = min({pne_kn:,.1f}, {pnl_kn:,.1f}, {pnd_kn:,.1f}) = {pn_kn:,.1f} kN (지배모드: {gov_mode}) -> phi*Pn = {phi_pn_kn:,.1f} kN",
            substituted_latex=rf"P_n = \min({pne_kn:,.1f}, {pnl_kn:,.1f}, {pnd_kn:,.1f}) = {pn_kn:,.1f} \text{{ kN}} \implies \phi_c P_n = {phi_pn_kn:,.1f} \text{{ kN}} \quad (\text{{{gov_mode}}})",
            parameters={"Pne": pne_kn, "Pnl": pnl_kn, "Pnd": pnd_kn, "governing": gov_mode},
            nominal_value=pn_kn,
            phi=phi_c,
            design_value=phi_pn_kn,
            omega=omega_c,
            allowable_value=pa_kn,
            demand_value=pu,
            dc_ratio=dc_comp,
            status="OK" if dc_comp <= 1.0 else "NG",
            unit="kN",
            notes=f"지배 좌굴 모드: {gov_mode}",
        ))

        return traces

    # -------------------------------------------------------------
    # 3. Flexure Trace (Section.cs:2950~3200 & DSM Flexure)
    # -------------------------------------------------------------
    @staticmethod
    def trace_flexure(
        sf: float,
        fy: float,
        m_cre: float,
        m_crl: float,
        m_crd: float,
        axis_name: str = "X",
        mu: float = 0.0,
        phi_b: float = 0.90,
        omega_b: float = 1.67,
    ) -> List[TraceItem]:
        traces = []
        my_knm = sf * fy / 1e6  # Yield moment kN-m

        # 3.1 Initial Yield Moment (My)
        traces.append(TraceItem(
            id=f"flex_yield_{axis_name.lower()}",
            title=f"{axis_name}축 초기 항복 모멘트 (Yield Moment, My{axis_name.lower()})",
            clause_kds="KDS 14 31 10 (4.2.1)",
            clause_aisi="AISI S100-16 Section F2",
            formula_raw=f"My = S{axis_name.lower()} * Fy",
            formula_latex=rf"M_{{y{axis_name.lower()}}} = S_{{f{axis_name.lower()}}} \cdot F_y",
            substituted_text=f"My = {sf:,.1f} mm³ * {fy:.1f} MPa = {my_knm:,.2f} kN·m",
            substituted_latex=rf"M_{{y{axis_name.lower()}}} = {sf:,.1f} \text{{ mm}}^3 \times {fy:.1f} \text{{ MPa}} = {my_knm:,.2f} \text{{ kN}}\cdot\text{{m}}",
            parameters={"Sf": sf, "Fy": fy},
            nominal_value=my_knm,
            phi=phi_b,
            design_value=phi_b * my_knm,
            omega=omega_b,
            allowable_value=my_knm / omega_b,
            unit="kN·m",
            notes=f"{axis_name}축 탄성 단면계수 기반 초기 항복 모멘트",
        ))

        # 3.2 Lateral-Torsional Buckling (Mne)
        m_cre_knm = m_cre / 1e6 if m_cre > 0 else 1e-6
        if m_cre_knm < 0.56 * my_knm:
            mne_knm = m_cre_knm
            ltb_desc = f"Mcre < 0.56*My: Mne = Mcre = {mne_knm:,.2f} kN·m (탄성 LTB)"
            ltb_latex = rf"M_{{cre}} < 0.56 M_y \implies M_{{ne}} = M_{{cre}} = {mne_knm:,.2f} \text{{ kN}}\cdot\text{{m}}"
        elif m_cre_knm <= 2.78 * my_knm:
            mne_knm = (10.0 / 9.0) * my_knm * (1.0 - (10.0 * my_knm) / (36.0 * m_cre_knm))
            ltb_desc = f"0.56*My <= Mcre <= 2.78*My: Mne = (10/9)*My*[1 - (10*My)/(36*Mcre)] = {mne_knm:,.2f} kN·m (비탄성 LTB)"
            ltb_latex = rf"0.56 M_y \le M_{{cre}} \le 2.78 M_y \implies M_{{ne}} = \frac{{10}}{{9}} M_y \left(1 - \frac{{10 M_y}}{{36 M_{{cre}}}}\right) = {mne_knm:,.2f} \text{{ kN}}\cdot\text{{m}}"
        else:
            mne_knm = my_knm
            ltb_desc = f"Mcre > 2.78*My: Mne = My = {mne_knm:,.2f} kN·m (항복 지배)"
            ltb_latex = rf"M_{{cre}} > 2.78 M_y \implies M_{{ne}} = M_y = {mne_knm:,.2f} \text{{ kN}}\cdot\text{{m}}"

        traces.append(TraceItem(
            id=f"flex_ltb_{axis_name.lower()}",
            title=f"{axis_name}축 횡-비틀림 좌굴 강도 (Lateral-Torsional Buckling, Mne)",
            clause_kds="KDS 14 31 10 (4.2.2.1)",
            clause_aisi="AISI S100-16 Section F2",
            formula_raw="Mne = Mcre or (10/9)*My*(1 - 10*My/(36*Mcre)) or My",
            formula_latex=r"M_{ne} = \begin{cases} M_{cre} & (M_{cre} < 0.56 M_y) \\ \frac{10}{9} M_y \left(1 - \frac{10 M_y}{36 M_{cre}}\right) & (0.56 M_y \le M_{cre} \le 2.78 M_y) \\ M_y & (M_{cre} > 2.78 M_y) \end{cases}",
            substituted_text=f"Mcre = {m_cre_knm:,.2f} kN·m -> {ltb_desc}",
            substituted_latex=rf"M_{{cre}} = {m_cre_knm:,.2f} \text{{ kN}}\cdot\text{{m}} \implies {ltb_latex}",
            parameters={"Mcre": m_cre_knm, "My": my_knm},
            nominal_value=mne_knm,
            phi=phi_b,
            design_value=phi_b * mne_knm,
            omega=omega_b,
            allowable_value=mne_knm / omega_b,
            unit="kN·m",
            notes="횡-비틀림 좌굴 및 횡방향 지지거리 영향 검토",
        ))

        # 3.3 Local Buckling (Mnl)
        m_crl_knm = m_crl / 1e6 if m_crl > 0 else 1e-6
        lambda_l = math.sqrt(mne_knm / m_crl_knm) if m_crl_knm > 1e-6 else 0.0
        if lambda_l <= 0.776:
            mnl_knm = mne_knm
            mnl_latex = rf"\lambda_l = {lambda_l:.3f} \le 0.776 \implies M_{{nl}} = M_{{ne}}"
        else:
            ratio_l = m_crl_knm / mne_knm
            mnl_knm = (1.0 - 0.15 * (ratio_l ** 0.4)) * (ratio_l ** 0.4) * mne_knm
            mnl_latex = rf"\lambda_l = {lambda_l:.3f} > 0.776 \implies M_{{nl}} = [1 - 0.15 (M_{{crl}}/M_{{ne}})^{{0.4}}] (M_{{crl}}/M_{{ne}})^{{0.4}} M_{{ne}}"

        traces.append(TraceItem(
            id=f"flex_local_{axis_name.lower()}",
            title=f"{axis_name}축 국부 좌굴 휨강도 (Local Buckling Flexure, Mnl)",
            clause_kds="KDS 14 31 10 (4.2.2.2)",
            clause_aisi="AISI S100-16 Section F3",
            formula_raw="lambda_l = sqrt(Mne / Mcrl); Mnl = Mne or [1 - 0.15*(Mcrl/Mne)^0.4]*(Mcrl/Mne)^0.4*Mne",
            formula_latex=r"\lambda_l = \sqrt{\frac{M_{ne}}{M_{crl}}}, \quad M_{nl} = \left[1 - 0.15 \left(\frac{M_{crl}}{M_{ne}}\right)^{0.4}\right] \left(\frac{M_{crl}}{M_{ne}}\right)^{0.4} M_{ne}",
            substituted_text=f"Mcrl = {m_crl_knm:,.2f} kN·m -> lambda_l = {lambda_l:.3f} -> Mnl = {mnl_knm:,.2f} kN·m",
            substituted_latex=rf"M_{{crl}} = {m_crl_knm:,.2f} \text{{ kN}}\cdot\text{{m}} \implies {mnl_latex} = {mnl_knm:,.2f} \text{{ kN}}\cdot\text{{m}}",
            parameters={"Mcrl": m_crl_knm, "lambda_l": lambda_l, "Mne": mne_knm},
            nominal_value=mnl_knm,
            phi=phi_b,
            design_value=phi_b * mnl_knm,
            omega=omega_b,
            allowable_value=mnl_knm / omega_b,
            unit="kN·m",
            notes="압축 플랜지 및 웨브 국부좌굴 상호작용 검토",
        ))

        # 3.4 Distortional Buckling (Mnd)
        m_crd_knm = m_crd / 1e6 if m_crd > 0 else 1e-6
        lambda_d = math.sqrt(my_knm / m_crd_knm) if m_crd_knm > 1e-6 else 0.0
        if lambda_d <= 0.673:
            mnd_knm = my_knm
            mnd_latex = rf"\lambda_d = {lambda_d:.3f} \le 0.673 \implies M_{{nd}} = M_y"
        else:
            ratio_d = m_crd_knm / my_knm
            mnd_knm = (1.0 - 0.22 * (ratio_d ** 0.5)) * (ratio_d ** 0.5) * my_knm
            mnd_latex = rf"\lambda_d = {lambda_d:.3f} > 0.673 \implies M_{{nd}} = [1 - 0.22 (M_{{crd}}/M_y)^{{0.5}}] (M_{{crd}}/M_y)^{{0.5}} M_y"

        traces.append(TraceItem(
            id=f"flex_distortional_{axis_name.lower()}",
            title=f"{axis_name}축 왜곡 좌굴 휨강도 (Distortional Buckling Flexure, Mnd)",
            clause_kds="KDS 14 31 10 (4.2.2.3)",
            clause_aisi="AISI S100-16 Section F4",
            formula_raw="lambda_d = sqrt(My / Mcrd); Mnd = My or [1 - 0.22*(Mcrd/My)^0.5]*(Mcrd/My)^0.5*My",
            formula_latex=r"\lambda_d = \sqrt{\frac{M_y}{M_{crd}}}, \quad M_{nd} = \left[1 - 0.22 \left(\frac{M_{crd}}{M_y}\right)^{0.5}\right] \left(\frac{M_{crd}}{M_y}\right)^{0.5} M_y",
            substituted_text=f"Mcrd = {m_crd_knm:,.2f} kN·m -> lambda_d = {lambda_d:.3f} -> Mnd = {mnd_knm:,.2f} kN·m",
            substituted_latex=rf"M_{{crd}} = {m_crd_knm:,.2f} \text{{ kN}}\cdot\text{{m}} \implies {mnd_latex} = {mnd_knm:,.2f} \text{{ kN}}\cdot\text{{m}}",
            parameters={"Mcrd": m_crd_knm, "lambda_d": lambda_d, "My": my_knm},
            nominal_value=mnd_knm,
            phi=phi_b,
            design_value=phi_b * mnd_knm,
            omega=omega_b,
            allowable_value=mnd_knm / omega_b,
            unit="kN·m",
            notes="압축 플랜지 보강 립의 횡방향 회전/변형 좌굴 검토",
        ))

        # 3.5 Controlling Nominal Flexural Strength
        mn_knm = min(mne_knm, mnl_knm, mnd_knm)
        phi_mn_knm = phi_b * mn_knm
        ma_knm = mn_knm / omega_b
        dc_flex = (mu / phi_mn_knm) if phi_mn_knm > 1e-6 else 0.0

        gov_mode = "LTB (Mne)" if mn_knm == mne_knm else ("Local (Mnl)" if mn_knm == mnl_knm else "Distortional (Mnd)")

        traces.append(TraceItem(
            id=f"flex_governing_{axis_name.lower()}",
            title=f"{axis_name}축 최종 공칭 및 설계 휨강도 (Governing Flexural Strength, Mn{axis_name.lower()})",
            clause_kds="KDS 14 31 10 (4.2.2)",
            clause_aisi="AISI S100-16 Section F1",
            formula_raw=f"Mn = min(Mne, Mnl, Mnd), phi_b*Mn = 0.90*Mn",
            formula_latex=rf"M_{{n{axis_name.lower()}}} = \min(M_{{ne}}, M_{{nl}}, M_{{nd}}), \quad \phi_b M_{{n{axis_name.lower()}}} = 0.90 M_{{n{axis_name.lower()}}}",
            substituted_text=f"Mn = min({mne_knm:,.2f}, {mnl_knm:,.2f}, {mnd_knm:,.2f}) = {mn_knm:,.2f} kN·m (지배모드: {gov_mode}) -> phi*Mn = {phi_mn_knm:,.2f} kN·m",
            substituted_latex=rf"M_{{n{axis_name.lower()}}} = \min({mne_knm:,.2f}, {mnl_knm:,.2f}, {mnd_knm:,.2f}) = {mn_knm:,.2f} \text{{ kN}}\cdot\text{{m}} \implies \phi_b M_{{n{axis_name.lower()}}} = {phi_mn_knm:,.2f} \text{{ kN}}\cdot\text{{m}}",
            parameters={"Mne": mne_knm, "Mnl": mnl_knm, "Mnd": mnd_knm, "governing": gov_mode},
            nominal_value=mn_knm,
            phi=phi_b,
            design_value=phi_mn_knm,
            omega=omega_b,
            allowable_value=ma_knm,
            demand_value=mu,
            dc_ratio=dc_flex,
            status="OK" if dc_flex <= 1.0 else "NG",
            unit="kN·m",
            notes=f"지배 휨 좌굴 모드: {gov_mode}",
        ))

        return traces

    # -------------------------------------------------------------
    # 4. Web Shear & Crippling Trace
    # -------------------------------------------------------------
    @staticmethod
    def trace_shear(
        h: float,
        t: float,
        fy: float,
        vu: float = 0.0,
        e_mod: float = 205000.0,
        kv: float = 5.34,
        phi_v: float = 0.90,
        omega_v: float = 1.60,
    ) -> List[TraceItem]:
        traces = []
        aw = h * t
        h_over_t = h / max(t, 0.1)
        limit1 = math.sqrt(e_mod * kv / fy)
        limit2 = 1.51 * limit1

        if h_over_t <= limit1:
            vn_n = 0.60 * aw * fy
            shear_case = "1구간 (전단 항복 지배): h/t <= sqrt(E*kv/Fy)"
            shear_latex = rf"\frac{{h}}{{t}} = {h_over_t:.1f} \le \sqrt{{\frac{{E k_v}}{{F_y}}}} = {limit1:.1f} \implies V_n = 0.60 A_w F_y"
        elif h_over_t <= limit2:
            vn_n = 0.60 * aw * math.sqrt(e_mod * kv * fy) / h_over_t
            shear_case = "2구간 (비탄성 전단 좌굴): sqrt(E*kv/Fy) < h/t <= 1.51*sqrt(E*kv/Fy)"
            shear_latex = rf"{limit1:.1f} < \frac{{h}}{{t}} = {h_over_t:.1f} \le {limit2:.1f} \implies V_n = 0.60 A_w \frac{{\sqrt{{E k_v F_y}}}}{{h/t}}"
        else:
            f_crv = (math.pi ** 2 * e_mod * kv) / (12.0 * (1.0 - 0.3 ** 2) * (h_over_t ** 2))
            vn_n = aw * f_crv
            shear_case = "3구간 (탄성 전단 좌굴): h/t > 1.51*sqrt(E*kv/Fy)"
            shear_latex = rf"\frac{{h}}{{t}} = {h_over_t:.1f} > {limit2:.1f} \implies V_n = A_w F_{{crv}} = A_w \frac{{\pi^2 E k_v}}{{12(1-\mu^2)(h/t)^2}}"

        vn_kn = vn_n / 1000.0
        phi_vn_kn = phi_v * vn_kn
        va_kn = vn_kn / omega_v
        dc_shear = (vu / phi_vn_kn) if phi_vn_kn > 1e-6 else 0.0

        traces.append(TraceItem(
            id="shear_web",
            title="웨브 전단강도 (Web Shear Strength, Vn)",
            clause_kds="KDS 14 31 10 (4.3.1)",
            clause_aisi="AISI S100-16 Section G2",
            formula_raw="Vn = 0.6*Aw*Fy or 0.6*Aw*sqrt(E*kv*Fy)/(h/t) or Aw*Fcrv",
            formula_latex=r"V_n = \begin{cases} 0.60 A_w F_y & (h/t \le \sqrt{E k_v / F_y}) \\ 0.60 A_w \frac{\sqrt{E k_v F_y}}{h/t} & (\sqrt{E k_v / F_y} < h/t \le 1.51\sqrt{E k_v / F_y}) \\ A_w \frac{\pi^2 E k_v}{12(1-\mu^2)(h/t)^2} & (h/t > 1.51\sqrt{E k_v / F_y}) \end{cases}",
            substituted_text=f"h/t = {h_over_t:.1f}, kv = {kv:.2f}, Aw = {aw:,.1f} mm² -> {shear_case} -> Vn = {vn_kn:,.1f} kN (phi*Vn = {phi_vn_kn:,.1f} kN)",
            substituted_latex=rf"Aw = {aw:,.1f} \text{{ mm}}^2, \; {shear_latex} \implies V_n = {vn_kn:,.1f} \text{{ kN}} \quad (\phi_v V_n = {phi_vn_kn:,.1f} \text{{ kN}})",
            parameters={"h": h, "t": t, "Aw": aw, "kv": kv, "h_over_t": h_over_t},
            nominal_value=vn_kn,
            phi=phi_v,
            design_value=phi_vn_kn,
            omega=omega_v,
            allowable_value=va_kn,
            demand_value=vu,
            dc_ratio=dc_shear,
            status="OK" if dc_shear <= 1.0 else "NG",
            unit="kN",
            notes=f"전단 해석 구간: {shear_case}",
        ))

        return traces

    @staticmethod
    def trace_web_crippling(
        c: float,
        cr: float,
        cn: float,
        ch: float,
        t: float,
        fy: float,
        r: float,
        n: float,
        h: float,
        condition: str = "IOF",
        fastened: bool = True,
        stiffened: bool = True,
        ru: float = 0.0,
        phi_w: float = 0.85,
        omega_w: float = 1.75,
    ) -> List[TraceItem]:
        traces = []
        term_r = max(1.0 - cr * math.sqrt(max(r / max(t, 0.1), 0.0)), 0.0)
        term_n = 1.0 + cn * math.sqrt(max(n / max(t, 0.1), 0.0))
        term_h = max(1.0 - ch * math.sqrt(max(h / max(t, 0.1), 0.0)), 0.0)

        pnc_n = c * (t ** 2) * fy * term_r * term_n * term_h
        pnc_kn = pnc_n / 1000.0
        phi_pnc_kn = phi_w * pnc_kn
        pa_kn = pnc_kn / omega_w
        dc_crip = (ru / phi_pnc_kn) if phi_pnc_kn > 1e-6 else 0.0

        traces.append(TraceItem(
            id="web_crippling",
            title=f"웨브 크리플링 강도 (Web Crippling, Pnc - {condition})",
            clause_kds="KDS 14 31 10 (4.4.1)",
            clause_aisi="AISI S100-16 Section G5",
            formula_raw="Pnc = C * t² * Fy * (1 - CR*sqrt(R/t)) * (1 + CN*sqrt(N/t)) * (1 - Ch*sqrt(h/t))",
            formula_latex=r"P_{nc} = C t^2 F_y \left(1 - C_R \sqrt{\frac{R}{t}}\right) \left(1 + C_N \sqrt{\frac{N}{t}}\right) \left(1 - C_h \sqrt{\frac{h}{t}}\right)",
            substituted_text=f"조건: {condition}, C={c}, CR={cr}, CN={cn}, Ch={ch}, t={t}mm, R={r}mm, N={n}mm, h={h}mm -> Pnc = {pnc_kn:,.1f} kN (phi*Pnc = {phi_pnc_kn:,.1f} kN)",
            substituted_latex=rf"P_{{nc}} = {c} \times {t}^2 \times {fy} \times \left(1 - {cr}\sqrt{{\frac{{{r}}}{{{t}}}}}\right) \left(1 + {cn}\sqrt{{\frac{{{n}}}{{{t}}}}}\right) \left(1 - {ch}\sqrt{{\frac{{{h}}}{{{t}}}}}\right) = {pnc_kn:,.1f} \text{{ kN}} \quad (\phi_w P_{{nc}} = {phi_pnc_kn:,.1f} \text{{ kN}})",
            parameters={"C": c, "CR": cr, "CN": cn, "Ch": ch, "t": t, "R": r, "N": n, "h": h, "condition": condition},
            nominal_value=pnc_kn,
            phi=phi_w,
            design_value=phi_pnc_kn,
            omega=omega_w,
            allowable_value=pa_kn,
            demand_value=ru,
            dc_ratio=dc_crip,
            status="OK" if dc_crip <= 1.0 else "NG",
            unit="kN",
            notes=f"재하조건: {condition} ({'플랜지 부착' if fastened else '비부착'}, {'보강' if stiffened else '비보강'})",
        ))

        return traces

    # -------------------------------------------------------------
    # 5. Combined Stress & Interaction Trace (Section.cs:6660~7000 & EqText)
    # -------------------------------------------------------------
    @staticmethod
    def trace_interaction(
        pu: float,
        phi_pn: float,
        mux: float,
        phi_mnx: float,
        muy: float = 0.0,
        phi_mny: float = 0.0,
        vu: float = 0.0,
        phi_vn: float = 0.0,
        ru: float = 0.0,
        phi_pnc: float = 0.0,
        b_bimoment: float = 0.0,
        phi_bn: float = 0.0,
        cmx: float = 1.0,
        cmy: float = 1.0,
    ) -> List[TraceItem]:
        traces = []

        ratio_p = pu / max(phi_pn, 1e-6)
        ratio_mx = mux / max(phi_mnx, 1e-6)
        ratio_my = muy / max(phi_mny, 1e-6) if phi_mny > 0 else 0.0

        # 5.1 Cross-section strength interaction (KDS Eq. 8-4 / AISI Eq. H1.2-1)
        dc_sec = ratio_p + ratio_mx + ratio_my
        traces.append(TraceItem(
            id="inter_cross_section",
            title="축압축-2축 휨 단면강도 상관방정식 (Cross-Section Strength)",
            clause_kds="KDS 14 31 10 (4.5.1)",
            clause_aisi="AISI S100-16 Eq. H1.2-1 / Eq. 8-4",
            formula_raw="Pu / (phi*Pn) + Mux / (phi*Mnx) + Muy / (phi*Mny) <= 1.0",
            formula_latex=r"\frac{P_u}{\phi_c P_n} + \frac{M_{ux}}{\phi_b M_{nx}} + \frac{M_{uy}}{\phi_b M_{ny}} \le 1.0",
            substituted_text=f"{pu:.1f}/{phi_pn:.1f} + {mux:.2f}/{phi_mnx:.2f} + {muy:.2f}/{max(phi_mny,1.0):.2f} = {ratio_p:.3f} + {ratio_mx:.3f} + {ratio_my:.3f} = {dc_sec:.3f}",
            substituted_latex=rf"\frac{{{pu:.1f}}}{{{phi_pn:.1f}}} + \frac{{{mux:.2f}}}{{{phi_mnx:.2f}}} + \frac{{{muy:.2f}}}{{{max(phi_mny,1.0):.2f}}} = {ratio_p:.3f} + {ratio_mx:.3f} + {ratio_my:.3f} = {dc_sec:.3f}",
            parameters={"Pu": pu, "phi_Pn": phi_pn, "Mux": mux, "phi_Mnx": phi_mnx, "Muy": muy, "phi_Mny": phi_mny},
            nominal_value=1.0,
            phi=1.0,
            design_value=1.0,
            demand_value=dc_sec,
            dc_ratio=dc_sec,
            status="OK" if dc_sec <= 1.0 else "NG",
            unit="",
            notes="지지점 및 브레이싱 위치에서의 단면 항복 상관식 검토",
        ))

        # 5.2 Member stability interaction (KDS Eq. 8-1 / AISI Eq. H1.1-1)
        ratio_mx_stab = (cmx * mux) / max(phi_mnx, 1e-6)
        ratio_my_stab = (cmy * muy) / max(phi_mny, 1e-6) if phi_mny > 0 else 0.0
        dc_stab = ratio_p + ratio_mx_stab + ratio_my_stab

        traces.append(TraceItem(
            id="inter_member_stability",
            title="부재 전체 안정성 상관방정식 (Member Overall Stability)",
            clause_kds="KDS 14 31 10 (4.5.2)",
            clause_aisi="AISI S100-16 Eq. H1.1-1 / Eq. 8-1",
            formula_raw="Pu / (phi*Pn) + (Cmx*Mux) / (phi*Mnx) + (Cmy*Muy) / (phi*Mny) <= 1.0",
            formula_latex=r"\frac{P_u}{\phi_c P_{ne}} + \frac{C_{mx} M_{ux}}{\phi_b M_{nx}} + \frac{C_{my} M_{uy}}{\phi_b M_{ny}} \le 1.0",
            substituted_text=f"{pu:.1f}/{phi_pn:.1f} + ({cmx:.2f}*{mux:.2f})/{phi_mnx:.2f} + ({cmy:.2f}*{muy:.2f})/{max(phi_mny,1.0):.2f} = {ratio_p:.3f} + {ratio_mx_stab:.3f} + {ratio_my_stab:.3f} = {dc_stab:.3f}",
            substituted_latex=rf"\frac{{{pu:.1f}}}{{{phi_pn:.1f}}} + \frac{{{cmx:.2f} \times {mux:.2f}}}{{{phi_mnx:.2f}}} + \frac{{{cmy:.2f} \times {muy:.2f}}}{{{max(phi_mny,1.0):.2f}}} = {dc_stab:.3f}",
            parameters={"Pu": pu, "phi_Pn": phi_pn, "Cmx": cmx, "Mux": mux, "phi_Mnx": phi_mnx, "Cmy": cmy, "Muy": muy, "phi_Mny": phi_mny},
            nominal_value=1.0,
            phi=1.0,
            design_value=1.0,
            demand_value=dc_stab,
            dc_ratio=dc_stab,
            status="OK" if dc_stab <= 1.0 else "NG",
            unit="",
            notes="P-delta 및 2차 효과 모멘트 증대계수 고려 부재 안정성 검토",
        ))

        # 5.3 Combined Bending and Shear (AISI Eq. H2-1 / Eq. 8-5)
        if vu > 0 and phi_vn > 0:
            ratio_v = vu / phi_vn
            dc_m_v = math.sqrt(ratio_mx ** 2 + ratio_v ** 2)
            traces.append(TraceItem(
                id="inter_bending_shear",
                title="휨-전단 조합 상관방정식 (Combined Bending and Shear)",
                clause_kds="KDS 14 31 10 (4.5.3)",
                clause_aisi="AISI S100-16 Eq. H2-1 / Eq. 8-5",
                formula_raw="Sqrt( (Mux / (phi*Mnx))² + (Vu / (phi*Vn))² ) <= 1.0",
                formula_latex=r"\sqrt{\left(\frac{M_{ux}}{\phi_b M_{nx}}\right)^2 + \left(\frac{V_u}{\phi_v V_n}\right)^2} \le 1.0",
                substituted_text=f"Sqrt( ({mux:.2f}/{phi_mnx:.2f})² + ({vu:.1f}/{phi_vn:.1f})² ) = Sqrt( {ratio_mx:.3f}² + {ratio_v:.3f}² ) = {dc_m_v:.3f}",
                substituted_latex=rf"\sqrt{{\left(\frac{{{mux:.2f}}}{{{phi_mnx:.2f}}}\right)^2 + \left(\frac{{{vu:.1f}}}{{{phi_vn:.1f}}}\right)^2}} = {dc_m_v:.3f}",
                parameters={"Mux": mux, "phi_Mnx": phi_mnx, "Vu": vu, "phi_Vn": phi_vn},
                nominal_value=1.0,
                phi=1.0,
                design_value=1.0,
                demand_value=dc_m_v,
                dc_ratio=dc_m_v,
                status="OK" if dc_m_v <= 1.0 else "NG",
                unit="",
                notes="웨브 최대 휨응력과 전단응력의 동시 작용 검토",
            ))

        # 5.4 Combined Bending and Web Crippling (AISI Eq. H3-1 / Eq. 8-6)
        if ru > 0 and phi_pnc > 0:
            ratio_crip = ru / phi_pnc
            dc_m_crip = (ratio_crip + ratio_mx) / 1.33  # Normalizes to <= 1.0 based on <= 1.33 limit
            val_raw = 0.91 * ratio_crip + ratio_mx
            traces.append(TraceItem(
                id="inter_bending_crippling",
                title="휨-웨브 크리플링 조합 상관방정식 (Combined Bending and Web Crippling)",
                clause_kds="KDS 14 31 10 (4.5.4)",
                clause_aisi="AISI S100-16 Eq. H3-1 / Section C3.5.2",
                formula_raw="0.91 * (Ru / (phi*Pnc)) + (Mux / (phi*Mnx)) <= 1.33",
                formula_latex=r"0.91 \left(\frac{R_u}{\phi_w P_{nc}}\right) + \frac{M_{ux}}{\phi_b M_{nx}} \le 1.33",
                substituted_text=f"0.91*({ru:.1f}/{phi_pnc:.1f}) + ({mux:.2f}/{phi_mnx:.2f}) = {val_raw:.3f} <= 1.33 (D/C: {val_raw/1.33:.3f})",
                substituted_latex=rf"0.91 \left(\frac{{{ru:.1f}}}{{{phi_pnc:.1f}}}\right) + \frac{{{mux:.2f}}}{{{phi_mnx:.2f}}} = {val_raw:.3f} \le 1.33",
                parameters={"Ru": ru, "phi_Pnc": phi_pnc, "Mux": mux, "phi_Mnx": phi_mnx},
                nominal_value=1.33,
                phi=1.0,
                design_value=1.33,
                demand_value=val_raw,
                dc_ratio=val_raw / 1.33,
                status="OK" if val_raw <= 1.33 else "NG",
                unit="",
                notes="지점 및 집중하중 작용부의 복합 크리플링-휨 검토",
            ))

        return traces

    # -------------------------------------------------------------
    # 6. Master Generator: generate_full_trace
    # -------------------------------------------------------------
    @classmethod
    def generate_full_trace(
        cls,
        props: Dict[str, Any],
        material: Dict[str, Any],
        fsm: Dict[str, Any],
        loads: Dict[str, Any],
        member_params: Optional[Dict[str, Any]] = None,
    ) -> DesignTraceResult:
        """
        Executes full-limit-state calculation trace generation.
        """
        res = DesignTraceResult()
        mp = member_params or {}

        ag = props.get("area", 1000.0)
        an = props.get("an", ag)
        fy = material.get("fy", 240.0)
        fu = material.get("fu", 400.0)
        sxt = props.get("sxt", 50000.0)
        sxb = props.get("sxb", sxt)
        syl = props.get("syl", 30000.0)
        syr = props.get("syr", syl)

        # Loads
        pu = loads.get("pu", 0.0)
        mux = loads.get("mux", 0.0)
        muy = loads.get("muy", 0.0)
        vu = loads.get("vu", loads.get("vy", 0.0))
        ru = loads.get("ru", 0.0)

        # FSM Elastic Buckling Loads & Moments
        p_cre = fsm.get("p_cre", 0.0)
        p_crl = fsm.get("p_crl", 0.0)
        p_crd = fsm.get("p_crd", 0.0)
        m_cre_x = fsm.get("m_cre_x", fsm.get("m_cre", 0.0))
        m_crl_x = fsm.get("m_crl_x", fsm.get("m_crl", 0.0))
        m_crd_x = fsm.get("m_crd_x", fsm.get("m_crd", 0.0))
        m_cre_y = fsm.get("m_cre_y", m_cre_x * 0.5)
        m_crl_y = fsm.get("m_crl_y", m_crl_x * 0.5)
        m_crd_y = fsm.get("m_crd_y", m_crd_x * 0.5)

        # 1. Tension
        res.tension = cls.trace_tension(ag, an, fy, fu, pu if pu < 0 else 0.0)

        # 2. Compression
        res.compression = cls.trace_compression(ag, fy, p_cre, p_crl, p_crd, pu if pu > 0 else 0.0)

        # 3. Flexure X & Y
        res.flexure_x = cls.trace_flexure(min(sxt, sxb), fy, m_cre_x, m_crl_x, m_crd_x, "X", mux)
        res.flexure_y = cls.trace_flexure(min(syl, syr), fy, m_cre_y, m_crl_y, m_crd_y, "Y", muy)

        # 4. Shear & Crippling
        h_web = props.get("depth", props.get("height", 150.0))
        t_web = props.get("thickness", 1.5)
        res.shear = cls.trace_shear(h_web, t_web, fy, vu)

        crip_c = mp.get("crip_c", 13.0)
        crip_cr = mp.get("crip_cr", 0.23)
        crip_cn = mp.get("crip_cn", 0.14)
        crip_ch = mp.get("crip_ch", 0.01)
        r_bend = mp.get("r_bend", 2.0)
        n_bearing = mp.get("n_bearing", 50.0)
        condition = mp.get("crip_condition", "IOF")
        res.web_crippling = cls.trace_web_crippling(
            crip_c, crip_cr, crip_cn, crip_ch, t_web, fy, r_bend, n_bearing, h_web,
            condition=condition, ru=ru
        )

        # 5. Interaction
        phi_pn = res.compression[-1].design_value if res.compression else 100.0
        phi_mnx = res.flexure_x[-1].design_value if res.flexure_x else 10.0
        phi_mny = res.flexure_y[-1].design_value if res.flexure_y else 5.0
        phi_vn = res.shear[-1].design_value if res.shear else 50.0
        phi_pnc = res.web_crippling[-1].design_value if res.web_crippling else 20.0

        res.interaction = cls.trace_interaction(
            pu=max(pu, 0.0), phi_pn=phi_pn,
            mux=mux, phi_mnx=phi_mnx,
            muy=muy, phi_mny=phi_mny,
            vu=vu, phi_vn=phi_vn,
            ru=ru, phi_pnc=phi_pnc,
            cmx=mp.get("cmx", 1.0), cmy=mp.get("cmy", 1.0)
        )

        # 6. Legacy strTrace formatting
        res.summary_logs = [
            f"[CFS strTrace Calculation Log - KDS 14 31 10 / AISI S100-16]",
            f"Material: Fy={fy:.1f} MPa, Fu={fu:.1f} MPa | Ag={ag:,.1f} mm²",
            f"Tension: Tn={res.tension[0].nominal_value:,.1f} kN (phi*Tn={res.tension[0].design_value:,.1f} kN)",
            f"Compression: Py={py_kn if 'py_kn' in locals() else (ag*fy/1000):,.1f} kN, Pn={res.compression[-1].nominal_value:,.1f} kN (phi*Pn={phi_pn:,.1f} kN)",
            f"Flexure X: My={res.flexure_x[0].nominal_value:,.2f} kNm, Mnx={res.flexure_x[-1].nominal_value:,.2f} kNm (phi*Mnx={phi_mnx:,.2f} kNm)",
            f"Flexure Y: My={res.flexure_y[0].nominal_value:,.2f} kNm, Mny={res.flexure_y[-1].nominal_value:,.2f} kNm (phi*Mny={phi_mny:,.2f} kNm)",
            f"Shear: Vn={res.shear[0].nominal_value:,.1f} kN (phi*Vn={phi_vn:,.1f} kN)",
            f"Interaction D/C: Cross-Section={res.interaction[0].dc_ratio:.3f}, Stability={res.interaction[1].dc_ratio:.3f}",
        ]

        # 7. Legacy EqText formatting
        res.equations_cfs = [
            f"Eq. H1.2-1 (P, Mx, My)   {res.interaction[0].substituted_text} <= 1.0  [{res.interaction[0].status}]",
            f"Eq. H1.1-1 (P, Mx, My)   {res.interaction[1].substituted_text} <= 1.0  [{res.interaction[1].status}]",
        ]
        if len(res.interaction) > 2:
            res.equations_cfs.append(f"Eq. H2-1   (Mx, Vy)       {res.interaction[2].substituted_text} <= 1.0  [{res.interaction[2].status}]")
        if len(res.interaction) > 3:
            res.equations_cfs.append(f"Eq. H3-1   (Mx, Ru)       {res.interaction[3].substituted_text} <= 1.33 [{res.interaction[3].status}]")

        return res
