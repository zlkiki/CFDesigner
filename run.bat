@echo off
@chcp 65001 > nul
title CFDesigner - Cold-Formed Section Analyzer & Designer

echo =======================================================================
echo   🚀 CFDesigner - Cold-Formed Section Analyzer & Designer
echo      KDS 14 31 10 / AISI S100 Structural Design System (AltDP Edition)
echo =======================================================================
echo.

cd /d "%~dp0"

if exist ".venv\Scripts\python.exe" (
    echo [*] Python virtual environment (.venv) detected.
    set "PYTHON_CMD=.venv\Scripts\python.exe"
) else (
    echo [*] Virtual environment not found. Using system python...
    set "PYTHON_CMD=python"
)

echo [*] Launching CFDesigner application...
echo.

"%PYTHON_CMD%" app.py

if errorlevel 1 (
    echo.
    echo [!] Application exited with an error.
    pause
)
