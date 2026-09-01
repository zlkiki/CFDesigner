"""
Writes out src/web/manual/topics.py directly from the structured dataset.
"""

import os
import pprint
from scripts.make_topics import build_dataset

def main():
    target_path = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "src", "web", "manual", "topics.py"))
    topics = build_dataset()

    categories = [
        {
            "id": "getting_started",
            "title": "1. 시작하기 & 웹 UI 가이드",
            "title_en": "1. Getting Started & Web UI Guide",
            "icon": "🚀",
            "topics": ["intro", "ui_layout", "wizard", "dxf_import", "element_grid", "geom_transform"]
        },
        {
            "id": "section_library",
            "title": "2. 단면 라이브러리 & 재료 물성치",
            "title_en": "2. Section Library & Material DB",
            "icon": "📚",
            "topics": ["section_lib", "material_db", "cold_work"]
        },
        {
            "id": "section_properties",
            "title": "3. 단면 기하학적 성질 & 유효단면",
            "title_en": "3. Section Properties & Effective Stress",
            "icon": "📐",
            "topics": ["gross_props", "torsion_props", "principal_axes", "effective_props"]
        },
        {
            "id": "fsm_buckling",
            "title": "4. FSM 탄성 좌굴해석 이론",
            "title_en": "4. Finite Strip Method (FSM) Buckling",
            "icon": "🔬",
            "topics": ["fsm_theory", "buckling_modes", "signature_curve", "fsm_params"]
        },
        {
            "id": "kds_design",
            "title": "5. KDS 14 31 10 부재설계 & 계산서",
            "title_en": "5. KDS 14 31 10 Member Design & Reports",
            "icon": "🏛️",
            "topics": ["kds_dsm_comp", "kds_dsm_flex", "kds_shear_crip", "quick_design", "kds_interaction", "report_guide"]
        },
        {
            "id": "frame_analysis",
            "title": "6. 1D 뼈대 구조해석",
            "title_en": "6. 1D Frame Structural Analysis",
            "icon": "🌉",
            "topics": ["analysis_wizard", "diagrams_viewer"]
        }
    ]

    with open(target_path, "w", encoding="utf-8") as f:
        f.write('"""\n')
        f.write('CFDesigner Online Help Manual Content Dataset\n')
        f.write('KDS 14 31 10 & AISI S100 based Engineering Manual (25 Topics across 6 Categories)\n')
        f.write('Bilingual Dataset: Korean (KDS Modernized & AltDP Web UX) & English (CFS 14.0 Ground Truth Reference)\n')
        f.write('"""\n\n')
        
        f.write("CATEGORIES = " + pprint.pformat(categories, indent=4, sort_dicts=False) + "\n\n")
        f.write("TOPICS = " + pprint.pformat(topics, indent=4, sort_dicts=False) + "\n")

    print(f"Successfully generated {target_path} with {len(topics)} topics across {len(categories)} categories.")

if __name__ == "__main__":
    main()
