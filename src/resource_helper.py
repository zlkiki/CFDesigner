"""
CFDesigner Resource Path Helper
Provides unified resource path resolution for both development mode and PyInstaller onefile standalone binary.
"""

import os
import sys


def get_base_dir() -> str:
    """
    Returns the base directory of the application.
    - In PyInstaller frozen bundle: returns sys._MEIPASS or exe directory
    - In development mode: returns project root directory
    """
    if getattr(sys, "frozen", False):
        if hasattr(sys, "_MEIPASS") and os.path.exists(sys._MEIPASS):
            return sys._MEIPASS
        return os.path.dirname(sys.executable)
    # When running as normal Python script: 1 level up from src/
    return os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))


def get_resource_path(*relative_paths: str) -> str:
    """
    Resolves relative path against project base directory.
    Example: get_resource_path("src", "web", "static")
    """
    return os.path.join(get_base_dir(), *relative_paths)
