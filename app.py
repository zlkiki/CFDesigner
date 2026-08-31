"""
CFDesigner - Cold-Formed Section Analyzer & Designer
Main Application Entrypoint & Launcher (AltDP Style)
"""

import os
import sys
import webbrowser
import threading
import time
import uvicorn

# Ensure project root is in sys.path
PROJECT_ROOT = os.path.dirname(os.path.abspath(__file__))
if PROJECT_ROOT not in sys.path:
    sys.path.insert(0, PROJECT_ROOT)


def open_browser(url: str, delay: float = 1.2):
    """Opens the user's default browser after a short startup delay."""
    time.sleep(delay)
    try:
        webbrowser.open(url)
    except Exception as e:
        print(f"[Warning] Failed to launch web browser automatically: {e}")


def main():
    host = "127.0.0.1"
    port = 8000
    url = f"http://{host}:{port}/"

    print("\n" + "=" * 65)
    print("  🚀 CFDesigner (Cold-Formed Section Analyzer & Designer)")
    print("     KDS 14 31 10 / AISI S100 Structural Engineering Platform")
    print("=" * 65)
    print(f"  • Main Dashboard : {url}")
    print(f"  • Online Manual  : {url}manual")
    print(f"  • API Swagger    : {url}docs")
    print("=" * 65)
    print("  💡 Initializing server and opening browser window...\n")

    # Start browser launcher in background thread
    threading.Thread(target=open_browser, args=(url, 1.2), daemon=True).start()

    # Launch FastAPI application using Uvicorn
    uvicorn.run("src.api.server:app", host=host, port=port, reload=False)


if __name__ == "__main__":
    main()
