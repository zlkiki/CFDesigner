# -*- mode: python ; coding: utf-8 -*-
import sys
import os

block_cipher = None

# In PyInstaller spec files, SPECPATH gives the directory of the spec file
project_dir = os.path.abspath(SPECPATH)

added_datas = [
    (os.path.join(project_dir, 'src', 'web'), os.path.join('src', 'web')),
    (os.path.join(project_dir, 'original_source'), 'original_source'),
]

hidden_imports = [
    'uvicorn',
    'uvicorn.logging',
    'uvicorn.loops',
    'uvicorn.loops.auto',
    'uvicorn.protocols',
    'uvicorn.protocols.http',
    'uvicorn.protocols.http.auto',
    'uvicorn.protocols.websockets',
    'uvicorn.protocols.websockets.auto',
    'uvicorn.lifespans',
    'uvicorn.lifespans.on',
    'uvicorn.lifespans.auto',
    'fastapi',
    'fastapi.staticfiles',
    'fastapi.responses',
    'fastapi.middleware.cors',
    'starlette',
    'starlette.staticfiles',
    'starlette.responses',
    'starlette.middleware.cors',
    'pydantic',
    'scipy',
    'scipy.spatial',
    'scipy.spatial.transform._rotation_groups',
    'scipy.special',
    'numpy',
    'ezdxf',
    'shapely',
    'src.api.server',
    'src.api.routes',
    'src.api.manual_routes',
    'src.web.manual.topics',
    'src.report.models',
    'src.report.detailed_report',
    'src.report.summary_report',
    'src.report.svg_diagrams',
    'src.report.html_report',
    'src.design.quick_design',
    'src.geometry.library_parser',
]

a = Analysis(
    ['app_entry.py'],
    pathex=[project_dir],
    binaries=[],
    datas=added_datas,
    hiddenimports=hidden_imports,
    hookspath=[],
    hooksconfig={},
    runtime_hooks=[],
    excludes=['tkinter', 'unittest', 'pytest'],
    win_no_prefer_redirects=False,
    win_private_assemblies=False,
    cipher=block_cipher,
    noarchive=False,
)

pyz = PYZ(a.pure, a.zipped_data, cipher=block_cipher)

exe = EXE(
    pyz,
    a.scripts,
    a.binaries,
    a.zipfiles,
    a.datas,
    [],
    name='CFDesigner',
    debug=False,
    bootloader_ignore_signals=False,
    strip=False,
    upx=True,
    upx_exclude=[],
    runtime_tmpdir=None,
    console=True,
    disable_windowed_traceback=False,
    argv_emulation=False,
    target_arch=None,
    codesign_identity=None,
    entitlements_file=None,
)
