"""
CFDesigner - Cold-Formed Section Analyzer & Designer
Standalone Application Main Entrypoint for PyInstaller Packaging
"""

import sys
import os
import time
import threading
import webbrowser
import uvicorn
import multiprocessing

# Add project root to sys.path
BASE_DIR = os.path.dirname(os.path.abspath(__file__))
if BASE_DIR not in sys.path:
    sys.path.insert(0, BASE_DIR)

from src.api.server import app


if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8")

def open_browser():
    """Opens the default browser to the CFDesigner web application after a short delay."""
    time.sleep(1.2)
    url = "http://127.0.0.1:8000/"
    print(f"[*] Opening browser: {url}")
    try:
        webbrowser.open(url)
    except Exception as e:
        print(f"[!] Could not open browser automatically: {e}")


def main():
    multiprocessing.freeze_support()

    print("=" * 70)
    print("  [CFDesigner] Cold-Formed Section Analyzer & Designer")
    print("  KDS 14 31 10 / AISI S100 Structural Design Platform (Standalone)")
    print("=" * 70)
    print("[*] Dashboard URL : http://127.0.0.1:8000/")
    print("[*] Online Manual : http://127.0.0.1:8000/manual")
    print("[*] Press Ctrl+C at any time to terminate the server.")
    print("=" * 70)

    # Launch browser in a background thread
    threading.Thread(target=open_browser, daemon=True).start()

    # Start FastAPI server via Uvicorn
    uvicorn.run(
        app,
        host="127.0.0.1",
        port=8000,
        log_level="info",
        access_log=False,
    )


if __name__ == "__main__":
    main()
