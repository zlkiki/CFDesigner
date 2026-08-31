# =======================================================================
#   🚀 CFDesigner - Cold-Formed Section Analyzer & Designer
#      PowerShell Application Launcher (run.ps1)
# =======================================================================

$Host.UI.RawUI.WindowTitle = "CFDesigner - Cold-Formed Section Analyzer & Designer"

Write-Host "=======================================================================" -ForegroundColor Cyan
Write-Host "  🚀 CFDesigner - Cold-Formed Section Analyzer & Designer" -ForegroundColor Green
Write-Host "     KDS 14 31 10 / AISI S100 Structural Design Platform" -ForegroundColor White
Write-Host "=======================================================================" -ForegroundColor Cyan
Write-Host ""

# Set working directory to script location
$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
if ($ScriptDir) {
    Set-Location $ScriptDir
}

# Detect Python Environment
$PythonExe = "$PSScriptRoot\.venv\Scripts\python.exe"
if (-not (Test-Path $PythonExe)) {
    $PythonExe = "python"
    Write-Host "[*] Virtual environment (.venv) not found. Using system python." -ForegroundColor Yellow
} else {
    Write-Host "[*] Python virtual environment (.venv) detected: $PythonExe" -ForegroundColor DarkGray
}

$ServerUrl = "http://127.0.0.1:8000/"
Write-Host "[*] Main Dashboard : $ServerUrl" -ForegroundColor Cyan
Write-Host "[*] Online Manual  : ${ServerUrl}manual" -ForegroundColor Cyan
Write-Host "[*] API Swagger    : ${ServerUrl}docs" -ForegroundColor Cyan
Write-Host ""
Write-Host "[*] Launching web browser automatically..." -ForegroundColor Gray
Write-Host "[*] Press Ctrl+C at any time to terminate the server." -ForegroundColor Yellow
Write-Host ""

# Open web browser after 1.5 seconds via background job
Start-Job -ScriptBlock {
    Start-Sleep -Milliseconds 1500
    Start-Process "http://127.0.0.1:8000/"
} | Out-Null

# Run Uvicorn server in foreground (supports graceful exit via Ctrl+C)
& $PythonExe -m uvicorn src.api.server:app --host 127.0.0.1 --port 8000
