"""
Report Data Models and Configuration Classes
"""

from dataclasses import dataclass, field
from typing import List, Optional, Dict, Any


@dataclass
class ProjectMetadata:
    """Project, client, and engineering metadata for calculation reports."""
    project_name: str = "CFDesigner Project"
    section_name: str = "Cold-Formed Section"
    file_name: str = "Section1.cfs"
    company: str = "Structural Engineering Corp."
    designed_by: str = "Structural Engineer"
    checked_by: str = "PE / SE"
    approved_by: str = "Lead Engineer"
    doc_number: str = "CALC-CFS-001"
    rev_number: str = "Rev. 0"
    rev_date: str = ""
    remarks: str = "Cold-Formed Steel Section Design per KDS 14 31 10 / AISI S100"
    client: str = ""
    address: str = ""
    phone: str = ""
    email: str = ""

    @classmethod
    def from_dict(cls, d: Optional[Dict[str, Any]]) -> "ProjectMetadata":
        if not d:
            return cls()
        return cls(
            project_name=d.get("project_name", "CFDesigner Project"),
            section_name=d.get("section_name", "Cold-Formed Section"),
            file_name=d.get("file_name", "Section1.cfs"),
            company=d.get("company", "Structural Engineering Corp."),
            designed_by=d.get("designed_by", "Structural Engineer"),
            checked_by=d.get("checked_by", "PE / SE"),
            approved_by=d.get("approved_by", "Lead Engineer"),
            doc_number=d.get("doc_number", "CALC-CFS-001"),
            rev_number=d.get("rev_number", "Rev. 0"),
            rev_date=d.get("rev_date", ""),
            remarks=d.get("remarks", "Cold-Formed Steel Section Design per KDS 14 31 10 / AISI S100"),
            client=d.get("client", ""),
            address=d.get("address", ""),
            phone=d.get("phone", ""),
            email=d.get("email", ""),
        )


@dataclass
class ReportOptions:
    """Report sections to include in the generated report (corresponding to frmPrint.cs)."""
    report_mode: str = "detailed"  # 'summary' or 'detailed'
    include_cover: bool = True
    include_section_inputs: bool = True
    include_gross_properties: bool = True
    include_torsion_properties: bool = True
    include_effective_properties: bool = True
    include_fully_braced_strength: bool = True
    include_fsm_buckling: bool = True
    include_member_design: bool = True
    include_web_crippling: bool = True
    include_1d_analysis: bool = True
    include_trace_details: bool = True
    unit_system: str = "SI"  # 'SI' or 'US'

    @classmethod
    def from_dict(cls, d: Optional[Dict[str, Any]]) -> "ReportOptions":
        if not d:
            return cls()
        return cls(
            report_mode=d.get("report_mode", "detailed"),
            include_cover=d.get("include_cover", True),
            include_section_inputs=d.get("include_section_inputs", True),
            include_gross_properties=d.get("include_gross_properties", True),
            include_torsion_properties=d.get("include_torsion_properties", True),
            include_effective_properties=d.get("include_effective_properties", True),
            include_fully_braced_strength=d.get("include_fully_braced_strength", True),
            include_fsm_buckling=d.get("include_fsm_buckling", True),
            include_member_design=d.get("include_member_design", True),
            include_web_crippling=d.get("include_web_crippling", True),
            include_1d_analysis=d.get("include_1d_analysis", True),
            include_trace_details=d.get("include_trace_details", True),
            unit_system=d.get("unit_system", "SI"),
        )
