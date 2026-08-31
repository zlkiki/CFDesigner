"""
CFDesigner Online Help Manual FastAPI Router
Endpoints for serving manual SPA, bilingual topic data, and multilingual search.
"""

from fastapi import APIRouter, HTTPException, Query
from fastapi.responses import HTMLResponse, FileResponse
import os
from typing import Optional, List, Dict, Any
from src.web.manual.topics import CATEGORIES, TOPICS

router = APIRouter(tags=["Manual"])

current_dir = os.path.dirname(os.path.abspath(__file__))
web_dir = os.path.join(os.path.dirname(current_dir), "web")
manual_html_path = os.path.join(web_dir, "manual.html")


@router.get("/manual", response_class=HTMLResponse)
async def serve_manual_page():
    """
    Serves the AltDP-style Online Help Manual SPA Viewer.
    """
    if os.path.exists(manual_html_path):
        return FileResponse(manual_html_path)
    return HTMLResponse("<h2>CFDesigner Online Manual loading...</h2>")


@router.get("/api/manual/categories")
async def get_categories() -> List[Dict[str, Any]]:
    """
    Returns the 4 main categories with topic metadata for building the TOC.
    """
    result = []
    for cat in CATEGORIES:
        cat_topics = []
        for tid in cat["topics"]:
            if tid in TOPICS:
                t = TOPICS[tid]
                cat_topics.append({
                    "id": t["id"],
                    "title": t["title"],
                    "title_en": t.get("title_en", t["title"]),
                    "summary": t["summary"],
                    "summary_en": t.get("summary_en", ""),
                    "tags": t.get("tags", [])
                })
        result.append({
            "id": cat["id"],
            "title": cat["title"],
            "title_en": cat.get("title_en", cat["title"]),
            "icon": cat["icon"],
            "topics": cat_topics
        })
    return result


@router.get("/api/manual/topic/{topic_id}")
async def get_topic(topic_id: str) -> Dict[str, Any]:
    """
    Returns the complete topic detail including Korean and English HTML content and metadata.
    """
    if topic_id not in TOPICS:
        raise HTTPException(status_code=404, detail=f"Topic '{topic_id}' not found.")
    return TOPICS[topic_id]


@router.get("/api/manual/search")
async def search_topics(q: str = Query(..., min_length=1, description="Search keyword (Korean or English)")) -> List[Dict[str, Any]]:
    """
    Searches topics by keyword across Korean & English titles, summaries, tags, and contents.
    """
    query = q.strip().lower()
    matches = []
    
    for tid, t in TOPICS.items():
        score = 0
        title_ko = t["title"].lower()
        title_en = t.get("title_en", "").lower()
        summary_ko = t["summary"].lower()
        summary_en = t.get("summary_en", "").lower()
        tags_lower = [tag.lower() for tag in t.get("tags", [])]
        content_ko = t.get("content_html", "").lower()
        content_en = t.get("content_en_html", "").lower()
        
        # Scoring: Title matches (highest)
        if query in title_ko or query in title_en:
            score += 15
        # Tag matches
        if any(query in tag for tag in tags_lower):
            score += 10
        # Summary matches
        if query in summary_ko or query in summary_en:
            score += 6
        # Content matches
        if query in content_ko or query in content_en:
            score += 3
            
        if score > 0:
            matches.append({
                "id": t["id"],
                "category_id": t["category_id"],
                "category_title": t["category_title"],
                "title": t["title"],
                "title_en": t.get("title_en", t["title"]),
                "summary": t["summary"],
                "summary_en": t.get("summary_en", ""),
                "tags": t.get("tags", []),
                "score": score
            })
            
    matches.sort(key=lambda x: x["score"], reverse=True)
    return matches
