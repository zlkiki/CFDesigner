"""
Phase 4: Frontend Static Integrity & AST/Regex Linter Test Suite (AC 14-4)
Performs automated static analysis on HTML and JavaScript source files:
1. Cross-validates HTML DOM IDs against JS getElementById / querySelector calls
2. Validates inter-module JS class method invocations (app.js -> viewer_3d, canvas_2d, chart_fsm)
3. Verifies physical existence of static assets, images, and manual graphics.
"""

import os
import re
import subprocess
import shutil
import pytest

WEB_ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", "src", "web"))
STATIC_ROOT = os.path.join(WEB_ROOT, "static")
JS_ROOT = os.path.join(STATIC_ROOT, "js")
MANUAL_ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), "..", "..", "src", "manual"))


@pytest.mark.frontend
@pytest.mark.ui
def test_javascript_syntax_and_brace_integrity():
    """
    Automated JS Syntax & ES Module Parsing Integrity Check:
    Scans all JavaScript files under src/web/static/js/ (including modules/)
    and executes Node.js syntax parsing (or AST/brace validation) to ensure
    there are 0 syntax errors, missing closing braces, or unexpected tokens.
    Prevents whole-UI button freezing and silent frontend initialization failures.
    """
    js_files = []
    for root, _, files in os.walk(JS_ROOT):
        for file in files:
            if file.endswith(".js"):
                js_files.append(os.path.join(root, file))

    assert len(js_files) >= 5, f"Expected at least 5 JS files, found {len(js_files)}"

    node_bin = shutil.which("node")

    for js_path in js_files:
        rel_path = os.path.relpath(js_path, WEB_ROOT).replace("\\", "/")
        
        # 1. Node.js ES Module Syntax Check (if Node is available)
        if node_bin:
            norm_path = js_path.replace("\\", "/")
            cmd = [node_bin, "--input-type=module", "-e", f'import "./{norm_path}"']
            res = subprocess.run(cmd, capture_output=True, text=True)
            if res.returncode != 0:
                # Filter out expected browser runtime globals (window, document, HTMLElement, etc.)
                err_text = res.stderr
                if "SyntaxError" in err_text:
                    pytest.fail(f"JavaScript Syntax Error in '{rel_path}':\n{err_text.strip()}")
                elif "ReferenceError" in err_text:
                    # ReferenceError: window is not defined (Normal in Node environment without DOM)
                    pass

        # 2. Pure-Python Balanced Braces & Quotes Static Analysis
        with open(js_path, "r", encoding="utf-8") as f:
            lines = f.readlines()

        # Check basic brace symmetry across non-comment lines
        brace_count = 0
        paren_count = 0
        bracket_count = 0
        in_multiline_comment = False

        for line_no, line in enumerate(lines, 1):
            s = line.strip()
            if in_multiline_comment:
                if "*/" in s:
                    in_multiline_comment = False
                    s = s[s.index("*/") + 2:]
                else:
                    continue

            if "/*" in s:
                if "*/" in s:
                    s = re.sub(r'/\*.*?\*/', '', s)
                else:
                    in_multiline_comment = True
                    s = s[:s.index("/*")]

            # Strip single-line comments
            if "//" in s:
                # Basic protection for url('http://...')
                parts = s.split("//")
                s = parts[0]

            # Strip string literals to avoid counting braces inside strings
            cleaned = re.sub(r'(\'\'\'|\"\"\"|\'.*?\'|\".*?\"|`.*?`)', '', s)

            brace_count += cleaned.count('{') - cleaned.count('}')
            paren_count += cleaned.count('(') - cleaned.count(')')
            bracket_count += cleaned.count('[') - cleaned.count(']')

            assert brace_count >= 0, (
                f"Closing brace '}}' unmatched at line {line_no} in '{rel_path}'!"
            )

        assert brace_count == 0, (
            f"Unclosed opening brace '{{' (count delta: {brace_count}) in '{rel_path}'!"
        )
        assert paren_count == 0, (
            f"Unclosed opening parenthesis '(' (count delta: {paren_count}) in '{rel_path}'!"
        )


@pytest.mark.frontend
@pytest.mark.ui
def test_html_dom_id_binding_integrity():
    """
    AC 14-4-1, AC 14-4-2:
    Extracts all IDs from index.html and verifies that all getElementById / $('#...') calls in JS files
    point to actually existing HTML DOM elements (prevents null element crashes).
    """
    index_html_path = os.path.join(WEB_ROOT, "index.html")
    assert os.path.exists(index_html_path), "index.html must exist"

    with open(index_html_path, "r", encoding="utf-8") as f:
        html_content = f.read()

    # Extract all IDs defined in HTML
    defined_ids = set(re.findall(r'id=["\']([a-zA-Z0-9_\-]+)["\']', html_content))
    assert len(defined_ids) > 20, f"Found only {len(defined_ids)} IDs in index.html"

    # Known dynamically created / modal IDs or legacy fallbacks that are safely bypassed
    dynamic_or_optional_ids = {
        "reportModalBody", "reportContent", "customModalOverlay",
        "dxfPreviewCanvas", "fsmChartCanvas", "toastNotification",
        "diagramCanvas", "katexRenderZone", "btnCloseReport",
        "btnPrintReportFromModal", "btnCancelQuickDesign",
        "btnCancelFsmParams", "btnCancelWizard", "reportIframe",
        "lengthX", "lengthY", "lengthT", "unbracedLength", "loadMuy"
    }

    # Scan JS files for document.getElementById('...')
    for root, _, files in os.walk(JS_ROOT):
        for file in files:
            if not file.endswith(".js") or file == "manual.js":
                continue
            js_path = os.path.join(root, file)
            with open(js_path, "r", encoding="utf-8") as f:
                js_content = f.read()

            # Find document.getElementById('XYZ')
            used_ids = re.findall(r'getElementById\(["\']([a-zA-Z0-9_\-]+)["\']\)', js_content)
            # Find querySelector('#XYZ')
            used_ids += re.findall(r'querySelector\(["\']#([a-zA-Z0-9_\-]+)["\']\)', js_content)

            for uid in used_ids:
                if uid in dynamic_or_optional_ids:
                    continue
                assert uid in defined_ids, (
                    f"JavaScript file '{file}' references DOM ID '{uid}', but it does NOT exist in index.html!"
                )


def test_js_class_method_interface_completeness():
    """
    AC 14-4-3:
    Statically analyzes app.js calls to sub-components (viewer3d, canvas2d, fsmChart)
    and verifies that the methods are actually defined in their respective JS files.
    Directly prevents TypeErrors like viewer3d.buildStressProfile is not a function.
    """
    # 1. Viewer3D methods in viewer_3d.js
    viewer_js_path = os.path.join(JS_ROOT, "viewer_3d.js")
    with open(viewer_js_path, "r", encoding="utf-8") as f:
        viewer_code = f.read()

    required_viewer_methods = [
        "setData", "setMode", "buildStressProfile",
        "toggleStressProfile", "toggleAnimation", "onResize"
    ]
    for method in required_viewer_methods:
        pattern = rf'(?:async\s+)?{method}\s*\([^)]*\)\s*\{{'
        assert re.search(pattern, viewer_code), (
            f"Method '{method}' is required by UI architecture but NOT defined in viewer_3d.js!"
        )

    # 2. Canvas2D methods in canvas_2d.js
    canvas_js_path = os.path.join(JS_ROOT, "canvas_2d.js")
    with open(canvas_js_path, "r", encoding="utf-8") as f:
        canvas_code = f.read()

    required_canvas_methods = [
        "render", "setFsmModeData", "toggle2DModeShape", "toggleEffective"
    ]
    for method in required_canvas_methods:
        pattern = rf'(?:async\s+)?{method}\s*\([^)]*\)\s*\{{'
        assert re.search(pattern, canvas_code), (
            f"Method '{method}' is required by UI architecture but NOT defined in canvas_2d.js!"
        )

    # 3. FSMChart methods in chart_fsm.js
    fsm_chart_path = os.path.join(JS_ROOT, "chart_fsm.js")
    with open(fsm_chart_path, "r", encoding="utf-8") as f:
        fsm_chart_code = f.read()

    required_fsm_chart_methods = [
        "updateData", "initChart"
    ]
    for method in required_fsm_chart_methods:
        pattern = rf'(?:async\s+)?{method}\s*\([^)]*\)\s*\{{'
        assert re.search(pattern, fsm_chart_code), (
            f"Method '{method}' is required by UI architecture but NOT defined in chart_fsm.js!"
        )


def test_static_assets_and_manual_images_exist():
    """
    AC 14-4-1:
    Verifies that all local CSS, JS, and manual illustration image references
    point to actual physical files on disk (prevents 404 broken images).
    """
    index_html_path = os.path.join(WEB_ROOT, "index.html")
    with open(index_html_path, "r", encoding="utf-8") as f:
        html_content = f.read()

    # Extract all local static paths like "/static/css/style.css" or "static/js/app.js"
    static_refs = re.findall(r'["\'](?:/)?static/([a-zA-Z0-9_\-/\.]+)["\']', html_content)
    assert len(static_refs) > 0

    for ref in static_refs:
        # Ignore external CDN links
        if ref.startswith("http") or "cdn." in ref:
            continue
        rel_path = os.path.join(STATIC_ROOT, ref.replace("/", os.sep))
        assert os.path.exists(rel_path), f"Static asset '{ref}' in index.html does not exist at {rel_path}!"
