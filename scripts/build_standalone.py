"""
CFDesigner Standalone Binary Build Script
Runs PyInstaller to compile CFDesigner into a single executable file.
"""

import os
import sys
import subprocess
import shutil

# Ensure UTF-8 output encoding for console
if hasattr(sys.stdout, "reconfigure"):
    sys.stdout.reconfigure(encoding="utf-8")

ROOT_DIR = os.path.abspath(os.path.join(os.path.dirname(__file__), ".."))


def build():
    print("=======================================================================")
    print("  [BUILD] CFDesigner Standalone Executable Build Pipeline")
    print("=======================================================================")
    
    spec_file = os.path.join(ROOT_DIR, "CFDesigner.spec")
    if not os.path.exists(spec_file):
        print(f"[!] Spec file not found: {spec_file}")
        sys.exit(1)

    pyinstaller_exe = os.path.join(ROOT_DIR, ".venv", "Scripts", "pyinstaller.exe")
    if not os.path.exists(pyinstaller_exe):
        pyinstaller_exe = "pyinstaller"

    cmd = [
        pyinstaller_exe,
        "--clean",
        "-y",
        spec_file
    ]

    print(f"[*] Executing command: {' '.join(cmd)}")
    print("[*] Working directory:", ROOT_DIR)
    print("-----------------------------------------------------------------------")

    ret = subprocess.call(cmd, cwd=ROOT_DIR)
    
    if ret == 0:
        dist_exe = os.path.join(ROOT_DIR, "dist", "CFDesigner.exe")
        if os.path.exists(dist_exe):
            size_mb = os.path.getsize(dist_exe) / (1024 * 1024)
            print("=======================================================================")
            print("  [SUCCESS] Build Succeeded!")
            print(f"  [OUTPUT]  Executable : {dist_exe}")
            print(f"  [SIZE]    File Size  : {size_mb:.2f} MB")
            print("=======================================================================")
        else:
            print("[!] Build finished but output exe was not found in dist/")
    else:
        print(f"[!] Build failed with exit code: {ret}")
        sys.exit(ret)


if __name__ == "__main__":
    build()
