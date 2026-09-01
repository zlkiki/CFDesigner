"""
A4 Engineering Calculation Sheet HTML Generator (Compatibility Layer & Dispatcher)
"""

from typing import Dict, Any, Optional
from .models import ProjectMetadata, ReportOptions
from .summary_report import SummaryReportGenerator
from .detailed_report import DetailedReportGenerator


class HTMLReportGenerator:
    """
    Dispatches report generation to either SummaryReportGenerator or DetailedReportGenerator.
    """

    @staticmethod
    def render_report(data: Dict[str, Any], meta: Optional[ProjectMetadata] = None, opts: Optional[ReportOptions] = None) -> str:
        opts = opts or ReportOptions.from_dict(data.get("options", {}))
        meta = meta or ProjectMetadata.from_dict(data.get("metadata", {}))

        if opts.report_mode == "summary":
            return SummaryReportGenerator.render(data, meta, opts)
        else:
            return DetailedReportGenerator.render(data, meta, opts)
