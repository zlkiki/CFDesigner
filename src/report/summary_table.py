"""
Calculation Report and Summary Table Generator
Generates clean A4-style text/markdown structural design calculation sheets.
"""

from ..geometry.gross_properties import GrossProperties
from ..solver.signature_curve import BucklingCurveResult
from ..design.dsm_compression import CompressionDesignResult
from ..design.dsm_flexure import FlexureDesignResult


class CalculationReportGenerator:
    """
    Formats complete section properties and KDS / AISI DSM design checks into markdown reports.
    """

    @staticmethod
    def generate_markdown_report(
        section_name: str,
        props: GrossProperties,
        buckle_res: BucklingCurveResult,
        comp_res: CompressionDesignResult,
        flex_res: FlexureDesignResult,
        fy: float = 345.0,
    ) -> str:
        md = []
        md.append(f"# [구조계산서] 냉간성형강 단면 해석 및 부재설계서 - {section_name}\n")
        md.append("> **설계 기준**: KDS 14 31 10 (냉간성형강구조설계기준) / AISI S100-16 (DSM 직접강도법)\n")

        md.append("## 1. 단면 기하학적 성능 (Gross Cross-Section Properties)")
        md.append("| 항목 (Property) | 기호 | 계산 결과치 | 단위 |")
        md.append("|---|:---:|:---:|:---:|")
        md.append(f"| 총 단면적 (Gross Area) | $A_g$ | {props.area:.2f} | $\\text{{mm}}^2$ |")
        md.append(f"| X축 단면이차모멘트 | $I_x$ | {props.ix:.2e} | $\\text{{mm}}^4$ |")
        md.append(f"| Y축 단면이차모멘트 | $I_y$ | {props.iy:.2e} | $\\text{{mm}}^4$ |")
        md.append(f"| X축 회전반경 | $r_x$ | {props.rx:.2f} | $\\text{{mm}}$ |")
        md.append(f"| Y축 회전반경 | $r_y$ | {props.ry:.2f} | $\\text{{mm}}$ |")
        md.append(f"| 상단 단면계수 | $S_{{xt}}$ | {props.sx_top:.2f} | $\\text{{mm}}^3$ |")
        md.append(f"| 생브낭 비틀림상수 | $J$ | {props.j:.2f} | $\\text{{mm}}^4$ |")
        md.append(f"| 와핑 뒴 상수 | $C_w$ | {props.cw:.2e} | $\\text{{mm}}^6$ |")
        md.append(f"| 전단중심 좌표 | $x_o, y_o$ | ({props.x0:.2f}, {props.y0:.2f}) | $\\text{{mm}}$ |")
        md.append(f"| 극회전반경 | $r_o$ | {props.ro:.2f} | $\\text{{mm}}$ |\n")

        md.append("## 2. 유한대판법(FSM) 탄성 좌굴해석 결과 (Elastic Buckling)")
        md.append("| 좌굴 모드 (Buckling Mode) | 임계 반파장 ($L$) | 탄성 좌굴하중 ($P_{{cr}}$) | 좌굴 하중계수 ($LF$) |")
        md.append("|---|:---:|:---:|:---:|")
        md.append(f"| **국부 좌굴 (Local, $P_{{crl}}$)** | {buckle_res.l_local:.1f} mm | {buckle_res.p_crl / 1000.0:.2f} kN | {buckle_res.p_crl / (props.area * fy):.3f} |")
        md.append(f"| **왜곡 좌굴 (Distortional, $P_{{crd}}$)** | {buckle_res.l_distortional:.1f} mm | {buckle_res.p_crd / 1000.0:.2f} kN | {buckle_res.p_crd / (props.area * fy):.3f} |")
        md.append(f"| **전체 좌굴 (Global, $P_{{cre}}$)** | {buckle_res.l_global:.1f} mm | {buckle_res.p_cre / 1000.0:.2f} kN | {buckle_res.p_cre / (props.area * fy):.3f} |\n")

        md.append("## 3. 부재 설계 강도 검토 (KDS / AISI Direct Strength Method)")
        md.append("### 3.1. 압축재 설계강도 (Compression)")
        md.append("| 검토 항목 | 계산 강도 (kN) | 비고 |")
        md.append("|---|:---:|---|")
        md.append(f"| 전체 좌굴 강도 ($P_{{ne}}$) | {comp_res.pne / 1000.0:.2f} kN | $\\lambda_c = {comp_res.lambda_c:.3f}$ |")
        md.append(f"| 국부 좌굴 강도 ($P_{{nl}}$) | {comp_res.pnl / 1000.0:.2f} kN | $\\lambda_l = {comp_res.lambda_l:.3f}$ |")
        md.append(f"| 왜곡 좌굴 강도 ($P_{{nd}}$) | {comp_res.pnd / 1000.0:.2f} kN | $\\lambda_d = {comp_res.lambda_d:.3f}$ |")
        md.append(f"| **공칭 압축강도 ($P_n$)** | **{comp_res.pn / 1000.0:.2f} kN** | 지배 모드: **{comp_res.governing_mode}** |")
        md.append(f"| **설계 압축강도 ($\\phi_c P_n$)** | **{comp_res.phi_pn / 1000.0:.2f} kN** | $\\phi_c = 0.85$ (한계상태/LRFD) |\n")

        md.append("### 3.2. 휨재 설계강도 (Flexure)")
        md.append("| 검토 항목 | 계산 강도 (kN·m) | 비고 |")
        md.append("|---|:---:|---|")
        md.append(f"| 횡비틀림좌굴 휨강도 ($M_{{ne}}$) | {flex_res.mne / 1e6:.2f} kN·m | LTB 검토 |")
        md.append(f"| 국부 좌굴 휨강도 ($M_{{nl}}$) | {flex_res.mnl / 1e6:.2f} kN·m | Local 휨강도 |")
        md.append(f"| 왜곡 좌굴 휨강도 ($M_{{nd}}$) | {flex_res.mnd / 1e6:.2f} kN·m | Distortional 휨강도 |")
        md.append(f"| **공칭 휨강도 ($M_n$)** | **{flex_res.mn / 1e6:.2f} kN·m** | 지배 모드: **{flex_res.governing_mode}** |")
        md.append(f"| **설계 휨강도 ($\\phi_b M_n$)** | **{flex_res.phi_mn / 1e6:.2f} kN·m** | $\\phi_b = 0.90$ (한계상태/LRFD) |\n")

        return "\n".join(md)
