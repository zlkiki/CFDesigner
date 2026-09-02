"""
Report Router: /api/report/*
Handles HTML, summary, and detailed structural calculation report generation.
"""

from fastapi import APIRouter
from typing import Dict, Any

from ._deps import HTMLReportGenerator

router = APIRouter(prefix="/api")


@router.post("/report/html")
async def generate_report_html(data: Dict[str, Any]):
    """
    Generates high-quality A4 Engineering Calculation Sheet in HTML format.
    Dispatches to summary or detailed report based on options.report_mode.
    """
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}


@router.post("/report/summary")
async def generate_report_summary(data: Dict[str, Any]):
    """
    Generates 1-2 page executive summary report HTML.
    """
    data["options"] = data.get("options", {})
    data["options"]["report_mode"] = "summary"
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}


@router.post("/report/detailed")
async def generate_report_detailed(data: Dict[str, Any]):
    """
    Generates multi-page formal detailed calculation sheet HTML.
    """
    data["options"] = data.get("options", {})
    data["options"]["report_mode"] = "detailed"
    html_content = HTMLReportGenerator.render_report(data)
    return {"html": html_content}
