/**
 * CFDesigner Main Application Controller
 * Handles user interactions, API synchronization, 2D/3D viewers, and report generation.
 *
 * Architecture: ES Module entry point with mixin-based modularization.
 * Modularized feature mixins are imported from ./modules/ and applied after class definition.
 * Legacy method bodies remain in this file for fallback; modular versions take precedence.
 */

// ---------------------------------------------------------
// ES Module Imports: Feature Mixins
// Mixin functions extend CFDesignerApp.prototype after class definition.
// ---------------------------------------------------------
import { applySectionEditorMixin } from './modules/section_editor.js';
import { applyLibraryBrowserMixin } from './modules/library_browser.js';
import { applyMaterialManagerMixin } from './modules/material_manager.js';
import { applyQuickDesignMixin } from './modules/quick_design.js';
import { applyFsmToolsMixin } from './modules/fsm_tools.js';
import { applyEffectiveWidthMixin } from './modules/effective_width.js';
import { applyFrameAnalysisMixin } from './modules/frame_analysis.js';
import { applyReportViewerMixin } from './modules/report_viewer.js';

class CFDesignerApp {
  constructor() {
    this.canvas2d = null;
    this.viewer3d = null;
    this.fsmChart = null;
    this.diagramViewer = null;

    this.currentGeometry = null;
    this.currentProperties = null;
    this.currentFsmResult = null;
    this.currentModeShapes = null;
    this.lastFsmResult = null;
    this.lastFrameResult = null;

    // Async Request Controllers for Abort & Re-calculation
    this.abortControllers = {
      transform: null,
      fsm: null,
      design: null,
      wizard: null,
      quickDesign: null,
      frame: null
    };

    this.fsmDebounceTimer = null;
    this.statusTimer = null;

    // Frame Analysis State
    this.frameSpans = [{ length: 4000.0, left_sup: 'pin', right_sup: 'roller' }];
    this.frameLoads = [{ load_type: 'udl', magnitude: 10.0, x_start: 0.0, x_end: 4000.0 }];
    this.activeViewerTab = '2d'; // '2d' or '3d'
    this.currentWorkflowStep = 1;

    this.init();
  }

  showStatus(message, type = 'ready', timeoutMs = 0) {
    const bar = document.getElementById('globalStatusBar');
    const dot = document.getElementById('statusDot');
    const icon = document.getElementById('statusIcon');
    const text = document.getElementById('statusText');
    if (!bar || !text) return;

    if (this.statusTimer) {
      clearTimeout(this.statusTimer);
      this.statusTimer = null;
    }

    bar.className = 'status-indicator-bar ' + type;
    if (dot) dot.className = 'status-dot ' + type;
    text.innerText = message;

    const iconMap = {
      ready: '⚡',
      busy: '🔄',
      success: '✅',
      warning: '⚠️'
    };
    if (icon) icon.innerText = iconMap[type] || '⚡';

    if (timeoutMs > 0) {
      this.statusTimer = setTimeout(() => {
        this.showStatus('준비 완료 (Ready)', 'ready', 0);
      }, timeoutMs);
    }
  }

  getAbortSignal(key, cancelMessage = null) {
    if (this.abortControllers[key]) {
      try {
        this.abortControllers[key].abort();
        if (cancelMessage) {
          console.debug(`[AbortController] ${key}: ${cancelMessage}`);
        }
      } catch (e) {}
    }
    const controller = new AbortController();
    this.abortControllers[key] = controller;
    return controller.signal;
  }

  applyOptimisticTransform(elements, transformType, angleDeg = 0) {
    if (!elements || !elements.length) return elements;

    let sumX = 0, sumY = 0, totalL = 0;
    elements.forEach(el => {
      const isArr = Array.isArray(el);
      const x0 = isArr ? el[1] : (el.x0 !== undefined ? el.x0 : el[1]);
      const y0 = isArr ? el[2] : (el.y0 !== undefined ? el.y0 : el[2]);
      const x1 = isArr ? el[3] : (el.x1 !== undefined ? el.x1 : el[3]);
      const y1 = isArr ? el[4] : (el.y1 !== undefined ? el.y1 : el[4]);

      const len = Math.hypot(x1 - x0, y1 - y0);
      sumX += ((x0 + x1) / 2) * len;
      sumY += ((y0 + y1) / 2) * len;
      totalL += len;
    });
    const cx = totalL > 0 ? sumX / totalL : 0;
    const cy = totalL > 0 ? sumY / totalL : 0;

    const transformPoint = (x, y) => {
      let nx = x, ny = y;
      if (transformType === 'rotate_90_cw') {
        const dx = x - cx, dy = y - cy;
        nx = cx + dy;
        ny = cy - dx;
      } else if (transformType === 'rotate_90_ccw') {
        const dx = x - cx, dy = y - cy;
        nx = cx - dy;
        ny = cy + dx;
      } else if (transformType === 'rotate_angle') {
        const rad = (angleDeg * Math.PI) / 180.0;
        const dx = x - cx, dy = y - cy;
        nx = cx + dx * Math.cos(rad) - dy * Math.sin(rad);
        ny = cy + dx * Math.sin(rad) + dy * Math.cos(rad);
      } else if (transformType === 'mirror_h') {
        const dy = y - cy;
        nx = x;
        ny = cy - dy;
      } else if (transformType === 'mirror_v') {
        const dx = x - cx;
        nx = cx - dx;
        ny = y;
      } else if (transformType === 'align_cg') {
        nx = x - cx;
        ny = y - cy;
      }
      return [nx, ny];
    };

    return elements.map(el => {
      const isArr = Array.isArray(el);
      const x0 = isArr ? el[1] : (el.x0 !== undefined ? el.x0 : el[1]);
      const y0 = isArr ? el[2] : (el.y0 !== undefined ? el.y0 : el[2]);
      const x1 = isArr ? el[3] : (el.x1 !== undefined ? el.x1 : el[3]);
      const y1 = isArr ? el[4] : (el.y1 !== undefined ? el.y1 : el[4]);

      const [nx1, ny1] = transformPoint(x0, y0);
      const [nx2, ny2] = transformPoint(x1, y1);

      if (isArr) {
        const newEl = [...el];
        newEl[1] = nx1;
        newEl[2] = ny1;
        newEl[3] = nx2;
        newEl[4] = ny2;
        return newEl;
      } else {
        return {
          ...el,
          x0: nx1,
          y0: ny1,
          x1: nx2,
          y1: ny2
        };
      }
    });
  }

  init() {
    // 1. Initialize Viewers
    this.canvas2d = new SectionCanvas2D('canvas2d');
    this.viewer3d = new BucklingViewer3D('viewer3dContainer');
    this.currentFsmModeIndex = 1;
    this.currentFsmModeKey = 'local_mode';
    this.fsmChart = new FSMSignatureChart('fsmChartCanvas', (lVal, pVal, modeIdx, ptData) => {
      console.log(`Selected Mode ${modeIdx}, Wavelength L: ${lVal} mm, Value: ${pVal}`);
      this.setGlobalModeIndex(modeIdx);
      this.showStatus(`선택: Mode ${modeIdx} (L = ${lVal.toLocaleString()} mm, ${pVal.toFixed(2)})`, 'info', 2500);
    });
    this.diagramViewer = new FrameDiagramViewer('canvasBeamModel', 'canvasSfd', 'canvasBmd', 'canvasDefl');

    // 2. Bind DOM Events
    this.bindEvents();

    // 3. Load Initial C-Section
    this.runWizard();
  }

  setGlobalModeIndex(modeIdx) {
    this.currentFsmModeIndex = modeIdx;
    
    // Sync 3D buttons
    document.querySelectorAll('.btn-eigen-mode').forEach(b => {
      const idx = parseInt(b.getAttribute('data-mode-idx'), 10);
      b.classList.toggle('active', idx === modeIdx);
      b.classList.toggle('btn-primary', idx === modeIdx);
    });

    // Sync 2D buttons
    document.querySelectorAll('.btn-2d-mode-idx').forEach(b => {
      const idx = parseInt(b.getAttribute('data-idx'), 10);
      b.classList.toggle('active', idx === modeIdx);
      b.classList.toggle('btn-primary', idx === modeIdx);
    });

    // Update 3D viewer
    const modeKey = this.currentFsmModeKey || 'local_mode';
    if (this.viewer3d) {
      this.viewer3d.setMode(modeKey, modeIdx);
    }

    // Update 2D canvas
    if (this.canvas2d) {
      this.canvas2d.fsmModeIndex = modeIdx;
      if (this.canvas2d.showModeShape2D) {
        this.canvas2d.render();
      }
    }
  }

  setWorkflowStep(stepNum) {
    stepNum = Math.max(1, Math.min(5, parseInt(stepNum, 10)));
    this.currentWorkflowStep = stepNum;

    // 1. Update Stepper DOM UI
    document.querySelectorAll('.stepper-item').forEach(item => {
      const s = parseInt(item.getAttribute('data-step'), 10);
      item.classList.toggle('active', s === stepNum);
    });

    // 2. Update Layout Container Preset
    const container = document.getElementById('mainAppContainer');
    if (container) {
      container.setAttribute('data-step', String(stepNum));
    }

    // 3. Step-specific optimal transitions
    if (stepNum === 1) {
      // Step 1: Modeling Focus -> Activate tabSection, switch 2D
      this.activateSidebarTab('tabSection');
      this.switchViewerMode('2d');
    } else if (stepNum === 2) {
      // Step 2: Properties Focus -> Activate tabSection, 2D view
      this.activateSidebarTab('tabSection');
      this.switchViewerMode('2d');
    } else if (stepNum === 3) {
      // Step 3: FSM Buckling Focus -> 3D viewer & FSM chart
      this.switchViewerMode('3d');
    } else if (stepNum === 4) {
      // Step 4: Member Design Focus -> Activate tabMember, 2D view
      this.activateSidebarTab('tabMember');
      this.switchViewerMode('2d');
    } else if (stepNum === 5) {
      // Step 5: Report & Export Focus -> Open Report Modal
      if (document.getElementById('btnOpenReport')) {
        document.getElementById('btnOpenReport').click();
      }
    }

    // 4. Update Prev/Next Buttons
    const btnPrev = document.getElementById('btnPrevStep');
    const btnNext = document.getElementById('btnNextStep');
    if (btnPrev) {
      btnPrev.disabled = (stepNum === 1);
    }
    if (btnNext) {
      if (stepNum === 5) {
        btnNext.innerText = '✅ 설계 및 검토 완료';
      } else {
        const nextTitles = ['', '단면 성질 (Step 2) →', '좌굴 해석 (Step 3) →', '부재 설계 (Step 4) →', '계산서 출력 (Step 5) →'];
        btnNext.innerText = `다음: ${nextTitles[stepNum]}`;
      }
    }

    // 5. Trigger resize for all active canvases
    setTimeout(() => {
      if (this.canvas2d) this.canvas2d.render();
      if (this.viewer3d) this.viewer3d.onWindowResize();
      if (this.fsmChart && this.fsmChart.chart) this.fsmChart.chart.resize();
    }, 150);
  }

  updateSmartAssistant(stateKey, customData = {}) {
    const bar = document.getElementById('smartActionBar');
    const icon = document.getElementById('sabIcon');
    const tag = document.getElementById('sabTag');
    const text = document.getElementById('sabText');
    const btnPrimary = document.getElementById('btnSabPrimaryAction');
    const btnSecondary = document.getElementById('btnSabSecondaryAction');
    if (!bar || !text || !btnPrimary) return;

    bar.className = 'smart-action-bar';

    if (stateKey === 'section_ready' || stateKey === 'section_modified') {
      icon.innerText = '💡';
      tag.innerText = 'STEP 1 → STEP 2/3';
      text.innerText = '단면 치수가 갱신되었습니다. 단면성질 산정 및 FSM 좌굴해석을 실행하세요.';
      btnPrimary.innerText = '⚡ 원클릭 일괄 해석 실행';
      btnPrimary.onclick = async () => {
        this.showStatus('단면 성질 및 FSM 좌굴해석 일괄 수행 중...', 'busy');
        await this.runWizard();
        await this.solveFsm();
        this.setWorkflowStep(3);
      };
      if (btnSecondary) btnSecondary.style.display = 'none';
    } else if (stateKey === 'fsm_completed') {
      bar.classList.add('state-success');
      icon.innerText = '📈';
      tag.innerText = 'STEP 3 COMPLETED';
      const pcrl = customData.pcrl ? `${customData.pcrl.toFixed(1)} kN` : '산출됨';
      text.innerText = `국부/왜곡 좌굴 임계하중(Pcrl=${pcrl})이 산출되었습니다. 부재설계 검토로 이동하세요.`;
      btnPrimary.innerText = 'Step 4 KDS 부재설계 이동 →';
      btnPrimary.onclick = () => {
        this.setWorkflowStep(4);
        this.runDesignCheck();
      };
      if (btnSecondary) btnSecondary.style.display = 'none';
    } else if (stateKey === 'design_passed') {
      bar.classList.add('state-success');
      icon.innerText = '✅';
      tag.innerText = 'DESIGN PASSED (OK)';
      const maxRatio = customData.maxRatio !== undefined ? customData.maxRatio.toFixed(2) : '0.85';
      text.innerText = `모든 KDS 14 31 10 부재설계 검토를 통과했습니다. (최대 D/C = ${maxRatio})`;
      btnPrimary.innerText = '📄 Step 5 구조계산서 출력 및 PDF 저장 →';
      btnPrimary.onclick = () => {
        this.setWorkflowStep(5);
      };
      if (btnSecondary) btnSecondary.style.display = 'none';
    } else if (stateKey === 'design_failed') {
      bar.classList.add('state-danger');
      icon.innerText = '⚠️';
      tag.innerText = 'CAPACITY EXCEEDED (NG)';
      const maxRatio = customData.maxRatio !== undefined ? customData.maxRatio.toFixed(2) : '1.15';
      text.innerText = `부재 내력이 초과되었습니다 (최대 D/C = ${maxRatio}, NG). 단면 보강 또는 최적화가 필요합니다.`;
      btnPrimary.innerText = '⚡ 3열 퀵디자인 최적 탐색 →';
      btnPrimary.onclick = () => {
        const btnQd = document.getElementById('btnOpenQuickDesign');
        if (btnQd) btnQd.click();
      };
      if (btnSecondary) {
        btnSecondary.style.display = 'inline-block';
        btnSecondary.innerText = '두께 0.5mm 증가';
        btnSecondary.onclick = () => {
          const tInput = document.getElementById('wizT');
          if (tInput) {
            tInput.value = (parseFloat(tInput.value || 2.0) + 0.5).toFixed(1);
            this.runWizard();
          }
        };
      }
    }
  }

  activateSidebarTab(tabPaneId) {
    document.querySelectorAll('.tab-nav-btn').forEach(b => {
      b.classList.toggle('active', b.getAttribute('data-target') === tabPaneId);
    });
    document.querySelectorAll('.tab-pane').forEach(p => {
      p.style.display = (p.id === tabPaneId) ? 'block' : 'none';
    });
  }

  bindEvents() {
    // Workflow Stepper Item Clicks
    document.querySelectorAll('.stepper-item').forEach(item => {
      item.addEventListener('click', () => {
        const step = item.getAttribute('data-step');
        if (step) this.setWorkflowStep(step);
      });
    });

    const btnPrev = document.getElementById('btnPrevStep');
    if (btnPrev) {
      btnPrev.addEventListener('click', () => {
        this.setWorkflowStep(this.currentWorkflowStep - 1);
      });
    }

    const btnNext = document.getElementById('btnNextStep');
    if (btnNext) {
      btnNext.addEventListener('click', () => {
        if (this.currentWorkflowStep < 5) {
          this.setWorkflowStep(this.currentWorkflowStep + 1);
        } else {
          this.setWorkflowStep(5);
        }
      });
    }

    // Workflow Keyboard Shortcuts (Alt+1 ~ Alt+5, Alt+ArrowLeft/Right)
    window.addEventListener('keydown', (e) => {
      if (e.altKey) {
        if (e.key >= '1' && e.key <= '5') {
          e.preventDefault();
          this.setWorkflowStep(parseInt(e.key, 10));
        } else if (e.key === 'ArrowRight') {
          e.preventDefault();
          this.setWorkflowStep(this.currentWorkflowStep + 1);
        } else if (e.key === 'ArrowLeft') {
          e.preventDefault();
          this.setWorkflowStep(this.currentWorkflowStep - 1);
        }
      }
    });

    // Quick Start Launcher Modal Events
    const modalQs = document.getElementById('quickStartModal');
    const btnOpenQs = document.getElementById('btnOpenQuickStart');
    const btnCloseQs = document.getElementById('btnCloseQuickStart');
    const btnCloseQsBottom = document.getElementById('btnCloseQuickStartBottom');
    const chkDontShowQs = document.getElementById('chkDontShowQuickStartAgain');

    if (btnOpenQs && modalQs) {
      btnOpenQs.addEventListener('click', () => {
        modalQs.style.display = 'flex';
      });
    }

    const closeQsModal = () => {
      if (modalQs) modalQs.style.display = 'none';
    };

    if (btnCloseQs) btnCloseQs.addEventListener('click', closeQsModal);
    if (btnCloseQsBottom) btnCloseQsBottom.addEventListener('click', closeQsModal);

    if (chkDontShowQs) {
      chkDontShowQs.checked = (localStorage.getItem('cfdesigner_hide_quickstart') === 'true');
      chkDontShowQs.addEventListener('change', (e) => {
        localStorage.setItem('cfdesigner_hide_quickstart', e.target.checked ? 'true' : 'false');
      });
    }

    // 4 Quick Start Action Buttons
    const btnQsStandard = document.getElementById('btnQsStartStandard');
    if (btnQsStandard) {
      btnQsStandard.addEventListener('click', () => {
        closeQsModal();
        this.setWorkflowStep(1);
        this.runWizard();
        this.showStatus('🎯 표준 단면 설계 모드가 시작되었습니다.', 'ready', 3000);
      });
    }

    const btnQsDxf = document.getElementById('btnQsStartDxf');
    if (btnQsDxf) {
      btnQsDxf.addEventListener('click', () => {
        closeQsModal();
        this.setWorkflowStep(1);
        const fileInput = document.getElementById('dxfFileInput');
        if (fileInput) fileInput.click();
      });
    }

    const btnQsQuickDesign = document.getElementById('btnQsStartQuickDesign');
    if (btnQsQuickDesign) {
      btnQsQuickDesign.addEventListener('click', () => {
        closeQsModal();
        const btnQd = document.getElementById('btnOpenQuickDesign');
        if (btnQd) btnQd.click();
      });
    }

    const btnQsFrame = document.getElementById('btnQsStartFrame');
    if (btnQsFrame) {
      btnQsFrame.addEventListener('click', () => {
        closeQsModal();
        const btnFa = document.getElementById('btnOpenFrameAnalysis');
        if (btnFa) btnFa.click();
      });
    }

    // Theme Toggle
    document.getElementById('btnThemeToggle').addEventListener('click', () => {
      const isLight = document.body.getAttribute('data-theme') === 'light';
      const newTheme = isLight ? 'dark' : 'light';
      document.body.setAttribute('data-theme', newTheme);
      if (this.viewer3D && this.viewer3D.setTheme) {
        this.viewer3D.setTheme(newTheme);
      }
      if (this.canvas2D && this.canvas2D.setTheme) {
        this.canvas2D.setTheme(newTheme);
      }
    });

    // Sidebar Tab Navigation
    document.querySelectorAll('.tab-nav-btn').forEach(btn => {
      btn.addEventListener('click', (e) => {
        document.querySelectorAll('.tab-nav-btn').forEach(b => b.classList.remove('active'));
        document.querySelectorAll('.tab-pane').forEach(p => p.style.display = 'none');

        btn.classList.add('active');
        const targetId = btn.getAttribute('data-target');
        document.getElementById(targetId).style.display = 'block';
      });
    });

    // Center Viewer Tab (2D / 3D)
    document.querySelectorAll('.viewer-tab-btn').forEach(btn => {
      btn.addEventListener('click', (e) => {
        document.querySelectorAll('.viewer-tab-btn').forEach(b => b.classList.remove('active'));
        btn.classList.add('active');
        const mode = btn.getAttribute('data-mode');
        this.switchViewerMode(mode);
      });
    });

    // Section Wizard Change Events
    ['wizardShape', 'wizH', 'wizB', 'wizC', 'wizT', 'wizR'].forEach(id => {
      const el = document.getElementById(id);
      if (el) el.addEventListener('change', () => this.runWizard());
    });

    document.getElementById('btnRunWizard').addEventListener('click', () => this.runWizard());

    // DXF File Drop & Input
    const dropZone = document.getElementById('dxfDropZone');
    const fileInput = document.getElementById('dxfFileInput');

    dropZone.addEventListener('click', () => fileInput.click());
    dropZone.addEventListener('dragover', (e) => {
      e.preventDefault();
      dropZone.classList.add('dragover');
    });
    dropZone.addEventListener('dragleave', () => dropZone.classList.remove('dragover'));
    dropZone.addEventListener('drop', (e) => {
      e.preventDefault();
      dropZone.classList.remove('dragover');
      if (e.dataTransfer.files && e.dataTransfer.files.length > 0) {
        this.uploadDXF(e.dataTransfer.files[0]);
      }
    });
    fileInput.addEventListener('change', (e) => {
      if (e.target.files && e.target.files.length > 0) {
        this.uploadDXF(e.target.files[0]);
      }
    });

    // Member Parameters & Load Inputs -> Trigger Design Check
    ['memberLength', 'loadPu', 'loadMux', 'loadVu', 'yieldStress'].forEach(id => {
      const el = document.getElementById(id);
      if (el) el.addEventListener('change', () => this.runDesignCheck());
    });

    // Member Design Sub-tab Navigation (P-M vs Web Crippling)
    document.querySelectorAll('.sub-tab-btn').forEach(btn => {
      btn.addEventListener('click', () => {
        document.querySelectorAll('.sub-tab-btn').forEach(b => b.classList.remove('active'));
        document.querySelectorAll('.subtab-pane').forEach(p => p.style.display = 'none');
        btn.classList.add('active');
        const targetId = btn.getAttribute('data-subtab');
        const targetPane = document.getElementById(targetId);
        if (targetPane) targetPane.style.display = 'block';
      });
    });

    // Web Crippling Load Auto-Sync with Vu
    const loadVuEl = document.getElementById('loadVu');
    if (loadVuEl) {
      loadVuEl.addEventListener('input', (e) => {
        const cripRuEl = document.getElementById('cripRuInput');
        if (cripRuEl) {
          cripRuEl.value = e.target.value;
          this.calculateWebCrippling();
        }
      });
    }

    // 3D Mode Selector Buttons
    document.querySelectorAll('.btn-mode-select').forEach(btn => {
      btn.addEventListener('click', () => {
        document.querySelectorAll('.btn-mode-select').forEach(b => {
          b.classList.remove('btn-primary');
          b.classList.remove('active');
        });
        btn.classList.add('btn-primary');
        btn.classList.add('active');
        const modeKey = btn.getAttribute('data-mode-key');
        this.currentFsmModeKey = modeKey;
        const modeIdx = this.currentFsmModeIndex || 1;
        if (this.viewer3d) this.viewer3d.setMode(modeKey, modeIdx);
        if (this.canvas2d) {
          this.canvas2d.fsmModeIndex = modeIdx;
          this.canvas2d.setFsmModeData(this.lastFsmNodes, this.lastFsmStrips, modeKey, this.viewer3d ? this.viewer3d.amplitude : 20.0);
        }
        this.update3dOverlayInfo(modeKey, modeIdx);
      });
    });

    // 3D / 2D Eigen Mode Index Switcher (Mode 1, Mode 2, Mode 3)
    document.querySelectorAll('.btn-eigen-mode').forEach(btn => {
      btn.addEventListener('click', () => {
        document.querySelectorAll('.btn-eigen-mode').forEach(b => {
          b.classList.remove('btn-primary');
          b.classList.remove('active');
        });
        btn.classList.add('btn-primary');
        btn.classList.add('active');
        const modeIdx = parseInt(btn.getAttribute('data-mode-idx'), 10) || 1;
        this.setGlobalModeIndex(modeIdx);
      });
    });

    document.querySelectorAll('.btn-2d-mode-idx').forEach(btn => {
      btn.addEventListener('click', () => {
        const modeIdx = parseInt(btn.getAttribute('data-idx'), 10) || 1;
        this.setGlobalModeIndex(modeIdx);
      });
    });

    // 3D Animation Toggle
    const btnToggleAnim = document.getElementById('btnToggleAnim3d');
    if (btnToggleAnim) {
      btnToggleAnim.addEventListener('click', () => {
        if (!this.viewer3d) return;
        const isPlay = this.viewer3d.toggleAnimation();
        btnToggleAnim.innerText = isPlay ? '⏸️ 정지' : '▶️ 재생';
      });
    }

    // 3D Stress Profile Toggle
    const btnToggleStress = document.getElementById('btnToggleStress3d');
    if (btnToggleStress) {
      btnToggleStress.addEventListener('click', () => {
        if (!this.viewer3d) return;
        const isShow = this.viewer3d.toggleStressProfile();
        btnToggleStress.classList.toggle('active', isShow);
      });
    }

    // 3D Image Export & Print
    const btnExportImg = document.getElementById('btnExportImage3d');
    if (btnExportImg) btnExportImg.addEventListener('click', () => this.viewer3d && this.viewer3d.exportImage());
    const btnPrint3d = document.getElementById('btnPrint3d');
    if (btnPrint3d) btnPrint3d.addEventListener('click', () => this.viewer3d && this.viewer3d.printView());

    // 2D Mode Shape Toggle
    const btnToggle2dMode = document.getElementById('btnToggle2dModeShape');
    if (btnToggle2dMode) {
      btnToggle2dMode.addEventListener('click', () => {
        if (!this.canvas2d) return;
        const isShow = this.canvas2d.toggle2DModeShape();
        btnToggle2dMode.classList.toggle('active', isShow);
      });
    }

    // Amplitude Slider
    const ampSlider = document.getElementById('ampSlider');
    if (ampSlider) {
      ampSlider.addEventListener('input', (e) => {
        const amp = parseFloat(e.target.value);
        if (this.viewer3d) {
          this.viewer3d.amplitude = amp;
          this.viewer3d.buildGeometry();
        }
        if (this.canvas2d) {
          this.canvas2d.fsmAmplitude = amp;
          if (this.canvas2d.showModeShape2D) this.canvas2d.render();
        }
      });
    }

    // 2D Overlay Tools
    document.getElementById('btnFitView').addEventListener('click', () => this.canvas2d.fitToView());

    // Phase 1: Element Table Editor Events
    document.getElementById('btnOpenElementEditor').addEventListener('click', () => this.openElementEditorModal());
    document.getElementById('btnCloseElementEditor').addEventListener('click', () => this.closeElementEditorModal());
    document.getElementById('btnAddElementRow').addEventListener('click', () => this.addElementRow());
    document.getElementById('btnApplyElements').addEventListener('click', () => this.applyElementsEditor());

    // Phase 1: Geometric Transform Events
    document.getElementById('btnRotateCw').addEventListener('click', () => this.transformSection('rotate_90_cw'));
    document.getElementById('btnRotateCcw').addEventListener('click', () => this.transformSection('rotate_90_ccw'));
    document.getElementById('btnMirrorH').addEventListener('click', () => this.transformSection('mirror_h'));
    document.getElementById('btnMirrorV').addEventListener('click', () => this.transformSection('mirror_v'));
    document.getElementById('btnAlignCg').addEventListener('click', () => this.transformSection('align_cg'));

    // Phase 1: Rotate Modal Events
    document.getElementById('btnOpenRotateModal').addEventListener('click', () => this.openRotateModal());
    document.getElementById('btnCloseRotateModal').addEventListener('click', () => this.closeRotateModal());
    document.getElementById('btnSubmitRotate').addEventListener('click', () => this.submitRotate());

    // Phase 1: Insert Ribs Modal Events
    document.getElementById('btnOpenInsertRibsModal').addEventListener('click', () => this.openInsertRibsModal());
    document.getElementById('btnCloseRibsModal').addEventListener('click', () => this.closeInsertRibsModal());
    document.getElementById('btnSubmitInsertRibs').addEventListener('click', () => this.submitInsertRibs());

    // Phase 2: Section Library Browser Events
    document.getElementById('btnOpenLibrary').addEventListener('click', () => this.openLibraryModal());
    document.getElementById('btnCloseLibraryModal').addEventListener('click', () => this.closeLibraryModal());
    document.getElementById('btnSearchLib').addEventListener('click', () => this.searchLibrary());
    document.getElementById('libSearchInput').addEventListener('keyup', (e) => {
      if (e.key === 'Enter') this.searchLibrary();
    });
    document.querySelectorAll('.btn-lib-tab').forEach(btn => {
      btn.addEventListener('click', (e) => {
        document.querySelectorAll('.btn-lib-tab').forEach(b => b.classList.remove('active'));
        btn.classList.add('active');
        this.currentLibName = btn.getAttribute('data-lib');
        this.loadLibrary(this.currentLibName);
      });
    });
    document.getElementById('btnLoadLibSection').addEventListener('click', () => this.loadSelectedLibSection());

    // Phase 2: Material Properties & Cold-Work Events
    document.getElementById('btnOpenMaterial').addEventListener('click', () => this.openMaterialModal());
    document.getElementById('btnCloseMaterialModal').addEventListener('click', () => this.closeMaterialModal());
    document.getElementById('matPresetSelect').addEventListener('change', (e) => this.onMaterialPresetChanged(e.target.value));
    ['matFyInput', 'matFuInput', 'matColdWorkCheck'].forEach(id => {
      const el = document.getElementById(id);
      if (el) el.addEventListener('input', () => this.recalcColdWork());
    });
    document.getElementById('btnApplyMaterial').addEventListener('click', () => this.applyMaterialToDesign());

    // Phase 3: Quick Design Events
    const btnOpenQD = document.getElementById('btnOpenQuickDesign');
    if (btnOpenQD) btnOpenQD.addEventListener('click', () => this.openQuickDesignModal());
    const btnCloseQD = document.getElementById('btnCloseQuickDesignModal');
    if (btnCloseQD) btnCloseQD.addEventListener('click', () => this.closeQuickDesignModal());
    const btnExecQD = document.getElementById('btnExecuteQuickDesign');
    if (btnExecQD) btnExecQD.addEventListener('click', () => this.executeQuickDesign());

    // Phase 3: Web Crippling Detailed Form Events
    ['cripConditionSelect', 'cripBearingLength', 'cripRuInput', 'cripFastenedCheck', 'cripStiffenedCheck'].forEach(id => {
      const el = document.getElementById(id);
      if (el) {
        el.addEventListener('change', () => this.calculateWebCrippling());
        el.addEventListener('input', () => this.calculateWebCrippling());
      }
    });

    // Phase 3: FSM Parameters & Numerical Data Events
    const btnFsmParams = document.getElementById('btnOpenFsmParams');
    if (btnFsmParams) btnFsmParams.addEventListener('click', () => this.openFsmParamsModal());
    const btnCloseFsmParams = document.getElementById('btnCloseFsmParams');
    if (btnCloseFsmParams) btnCloseFsmParams.addEventListener('click', () => this.closeFsmParamsModal());
    const btnApplyFsmParams = document.getElementById('btnApplyFsmParams');
    if (btnApplyFsmParams) btnApplyFsmParams.addEventListener('click', () => this.applyFsmCustomParams());

    const btnFsmData = document.getElementById('btnOpenFsmData');
    if (btnFsmData) btnFsmData.addEventListener('click', () => this.openFsmDataModal());
    const btnCloseFsmData = document.getElementById('btnCloseFsmData');
    if (btnCloseFsmData) btnCloseFsmData.addEventListener('click', () => this.closeFsmDataModal());
    const btnExportCsv = document.getElementById('btnExportFsmCsv');
    if (btnExportCsv) btnExportCsv.addEventListener('click', () => this.exportFsmCsv());

    // Phase 3 / Phase 9: Winter Effective Width Overlay Events
    const btnToggleEff = document.getElementById('btnToggleEffective');
    if (btnToggleEff) btnToggleEff.addEventListener('click', () => this.toggleEffectiveWidthToolbar());
    const btnCloseEff = document.getElementById('btnCloseEffectiveModal');
    if (btnCloseEff) btnCloseEff.addEventListener('click', () => this.closeEffectiveModal());
    const btnComputeEff = document.getElementById('btnComputeEffective');
    if (btnComputeEff) btnComputeEff.addEventListener('click', () => this.applyEffectiveOverlayToCanvas());

    const effStressInput = document.getElementById('effStressInput');
    if (effStressInput) {
      effStressInput.addEventListener('input', () => {
        if (this.effDebounceTimer) clearTimeout(this.effDebounceTimer);
        this.effDebounceTimer = setTimeout(() => this.computeEffectiveModalValues(false), 150);
      });
    }
    const effAxisSelect = document.getElementById('effAxisSelect');
    if (effAxisSelect) {
      effAxisSelect.addEventListener('change', () => {
        if (this.effDebounceTimer) clearTimeout(this.effDebounceTimer);
        this.effDebounceTimer = setTimeout(() => this.computeEffectiveModalValues(false), 150);
      });
    }

    // Phase 4: 1D Frame & Beam Analysis Events
    const btnFrame = document.getElementById('btnOpenFrameAnalysis');
    if (btnFrame) btnFrame.addEventListener('click', () => this.openFrameAnalysisModal());
    const btnCloseFrame = document.getElementById('btnCloseFrameAnalysisModal');
    if (btnCloseFrame) btnCloseFrame.addEventListener('click', () => this.closeFrameAnalysisModal());
    const btnAddLoad = document.getElementById('btnAddFrameLoadRow');
    if (btnAddLoad) btnAddLoad.addEventListener('click', () => this.addFrameLoadRow());
    const btnExecFrame = document.getElementById('btnExecuteFrameAnalysis');
    if (btnExecFrame) btnExecFrame.addEventListener('click', () => this.executeFrameAnalysis());
    const btnTransfer = document.getElementById('btnTransferToDesign');
    if (btnTransfer) btnTransfer.addEventListener('click', () => this.transferFrameResultToDesign());

    document.querySelectorAll('.btn-frame-preset').forEach(btn => {
      btn.addEventListener('click', (e) => {
        document.querySelectorAll('.btn-frame-preset').forEach(b => b.classList.remove('active'));
        e.currentTarget.classList.add('active');
        this.loadFramePreset(e.currentTarget.dataset.preset);
      });
    });

    // Report Modal & Online Manual
    const btnManual = document.getElementById('btnOpenManual');
    if (btnManual) {
      btnManual.addEventListener('click', () => {
        window.open('/manual', '_blank');
      });
    }

    const btnOpenRpt = document.getElementById('btnOpenReport');
    if (btnOpenRpt) btnOpenRpt.addEventListener('click', () => this.openReportModal());
    const btnCloseRpt = document.getElementById('btnCloseReportModal') || document.getElementById('btnCloseReport');
    if (btnCloseRpt) btnCloseRpt.addEventListener('click', () => this.closeReportModal());

    // Report Dual Mode Buttons
    const btnModeSummary = document.getElementById('btnReportModeSummary');
    const btnModeDetailed = document.getElementById('btnReportModeDetailed');
    if (btnModeSummary && btnModeDetailed) {
      btnModeSummary.addEventListener('click', () => {
        btnModeSummary.classList.add('btn-primary');
        btnModeSummary.classList.remove('btn-outline');
        btnModeDetailed.classList.remove('btn-primary');
        btnModeDetailed.classList.add('btn-outline');
        this.reportMode = 'summary';
        this.refreshReport();
      });
      btnModeDetailed.addEventListener('click', () => {
        btnModeDetailed.classList.add('btn-primary');
        btnModeDetailed.classList.remove('btn-outline');
        btnModeSummary.classList.remove('btn-primary');
        btnModeSummary.classList.add('btn-outline');
        this.reportMode = 'detailed';
        this.refreshReport();
      });
    }

    // Toggle All Trace Details
    const btnToggleAllTrace = document.getElementById('btnToggleAllTrace');
    if (btnToggleAllTrace) {
      btnToggleAllTrace.addEventListener('click', () => this.toggleAllTraceDetails());
    }

    // Toggle Config Drawer
    const btnToggleConfig = document.getElementById('btnToggleReportConfig');
    if (btnToggleConfig) {
      btnToggleConfig.addEventListener('click', () => {
        const drawer = document.getElementById('reportConfigDrawer');
        if (drawer) {
          drawer.classList.toggle('open');
        }
      });
    }

    // Apply Config
    const btnApplyRpt = document.getElementById('btnApplyReportConfig');
    if (btnApplyRpt) {
      btnApplyRpt.addEventListener('click', () => {
        const drawer = document.getElementById('reportConfigDrawer');
        if (drawer) drawer.classList.remove('open');
        this.refreshReport();
      });
    }

    // Export Actions from Report
    const btnExpDxf = document.getElementById('btnExportDxfFromReport');
    if (btnExpDxf) {
      btnExpDxf.addEventListener('click', () => this.exportSectionDxf());
    }

    const btnExpCsv = document.getElementById('btnExportCsvFromReport');
    if (btnExpCsv) {
      btnExpCsv.addEventListener('click', () => this.exportSectionCsv());
    }

    const btnCopySummary = document.getElementById('btnCopySummaryTableFromReport');
    if (btnCopySummary) {
      btnCopySummary.addEventListener('click', () => this.copySummaryTable());
    }

    // Print from Modal
    const btnPrintModal = document.getElementById('btnPrintReportFrame') || document.getElementById('btnPrintReportFromModal');
    if (btnPrintModal) {
      btnPrintModal.addEventListener('click', () => {
        const iframe = document.getElementById('reportViewerFrame') || document.getElementById('reportIframe');
        if (iframe && iframe.contentWindow) {
          iframe.contentWindow.print();
        }
      });
    }
  }

  switchViewerMode(mode) {
    this.activeViewerTab = mode;
    if (mode === '2d') {
      document.getElementById('canvas2d').style.display = 'block';
      document.getElementById('viewer3dContainer').style.display = 'none';
      document.getElementById('modeSelectorBar').style.display = 'none';
      this.canvas2d.resize();
    } else {
      document.getElementById('canvas2d').style.display = 'none';
      document.getElementById('viewer3dContainer').style.display = 'block';
      document.getElementById('modeSelectorBar').style.display = 'flex';
      this.viewer3d.onResize();
    }
  }

  async runWizard() {
    const shape = document.getElementById('wizardShape').value;
    const h = parseFloat(document.getElementById('wizH').value) || 150;
    const b = parseFloat(document.getElementById('wizB').value) || 65;
    const c = parseFloat(document.getElementById('wizC').value) || 20;
    const t = parseFloat(document.getElementById('wizT').value) || 2.0;
    const r = parseFloat(document.getElementById('wizR').value) || 2.0;

    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 단면 성질 계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.showStatus('📐 단면 마법사 생성 및 기하 계산 중...', 'busy');
    const signal = this.getAbortSignal('wizard', '이전 마법사 생성 취소 후 재연산 중...');

    try {
      const res = await fetch('/api/section/wizard', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ shape_type: shape, h, b, c, t, r }),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Wizard API error:', err);
      this.showStatus('단면 마법사 생성 실패', 'warning', 3000);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  }

  async uploadDXF(file) {
    const t = parseFloat(document.getElementById('wizT').value) || 2.0;
    const formData = new FormData();
    formData.append('file', file);
    formData.append('default_thickness', t);
    formData.append('unit', 'mm');

    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ DXF 단면 분석 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.showStatus('📐 DXF 도면 파싱 및 중심선 메싱 중...', 'busy');
    const signal = this.getAbortSignal('wizard', '이전 DXF 파싱 취소 후 재연산 중...');

    try {
      const res = await fetch('/api/section/upload-dxf', {
        method: 'POST',
        body: formData,
        signal: signal
      });
      if (!res.ok) {
        alert('DXF 파싱 실패: ' + (await res.json()).detail);
        this.showStatus('DXF 파싱 오류', 'warning', 3000);
        return;
      }
      const data = await res.json();
      this.updateSectionData(data);
      this.showStatus('✅ DXF 단면 로드 완료', 'success', 3000);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('DXF Upload Error:', err);
      this.showStatus('DXF 업로드 실패', 'warning', 3000);
    }
  }

  updateSectionData(data) {
    this.currentGeometry = data.geometry;
    this.currentProperties = data.properties;

    // Reset effective properties overlay & card when geometry changes
    this.resetEffectiveState();

    // 1. Update 2D Canvas immediately
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);

    // 2. Update Properties Table immediately
    this.renderPropertiesTable(this.currentProperties);

    // Update Step 1 & 2 badges and assistant
    this.updateWorkflowBadge(1, 'ready', '생성완료');
    this.updateWorkflowBadge(2, 'ready', '해석완료');
    this.updateSmartAssistant('section_ready');

    // 3. Trigger FSM Buckling Analysis & Design Check asynchronously with debouncing
    this.runFSM();
    this.runDesignCheck();
  }

  updateWorkflowBadge(stepNum, type, text) {
    const badge = document.getElementById(`stepBadge${stepNum}`);
    if (!badge) return;
    badge.className = `step-badge badge-${type}`;
    badge.innerText = text;
  }

  renderPropertiesTable(props) {
    if (!props) return;
    const setVal = (id, val) => {
      const el = document.getElementById(id);
      if (el) el.innerText = typeof val === 'number' ? val.toLocaleString() : val;
    };

    setVal('propAg', props.area);
    setVal('propWeight', props.weight);
    setVal('propIx', props.ix);
    setVal('propIy', props.iy);
    setVal('propRx', props.rx);
    setVal('propRy', props.ry);
    setVal('propThetaP', props.theta_p + '°');
    setVal('propI1', props.i1);
    setVal('propI2', props.i2);
    setVal('propJ', props.j);
    setVal('propCw', props.cw);
    setVal('propX0', props.x0);
    setVal('propY0', props.y0);
    setVal('propRo', props.ro);
  }

  async runFSM() {
    if (!this.currentGeometry) return;

    if (this.fsmDebounceTimer) {
      clearTimeout(this.fsmDebounceTimer);
    }

    this.fsmDebounceTimer = setTimeout(async () => {
      const fy = parseFloat(document.getElementById('yieldStress').value) || 345;
      const lMem = parseFloat(document.getElementById('memberLength').value) || 3000;
      const startTime = performance.now();

      this.showStatus('🔬 FSM 탄성 버클링 해석 연산 중 (35개 스윕)...', 'busy');
      const signal = this.getAbortSignal('fsm', '이전 FSM 연산 취소 후 최신 단면 재해석 중...');

      const stressType = this.currentFsmStressType || document.getElementById('fsmStressType')?.value || 'compression';

      try {
        const res = await fetch('/api/fsm/solve', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            elements: this.currentGeometry.elements,
            thickness: this.currentGeometry.thickness,
            load_type: stressType,
            yield_stress: fy,
            member_length: lMem,
            num_points: 35
          }),
          signal: signal
        });
        if (!res.ok) {
          const errData = await res.json().catch(() => ({ detail: '서버 오류' }));
          this.showStatus(`⚠️ FSM 해석 오류: ${errData.detail || '응답 오류'}`, 'warning', 3500);
          return;
        }
        const data = await res.json();
        this.currentFsmResult = data;

        // 1. Update FSM Signature Chart
        try {
          if (this.fsmChart) {
            this.fsmChart.updateData(data.signature_curve, data.critical_modes.load_type);
          }
        } catch (chartErr) {
          console.error('FSM Chart update error:', chartErr);
        }

        // 2. Update 3D Viewer Mesh & Modes
        this.lastFsmNodes = data.nodes;
        this.lastFsmStrips = data.strips;
        try {
          if (this.viewer3d) {
            this.viewer3d.setData(data.nodes, data.strips, 'local_mode');
          }
        } catch (v3dErr) {
          console.error('3D Viewer update error:', v3dErr);
        }

        // 3. Update 2D Mode Shape
        try {
          if (this.canvas2d) {
            this.canvas2d.setFsmModeData(data.nodes, data.strips, 'local_mode', this.viewer3d ? this.viewer3d.amplitude : 15.0);
          }
        } catch (c2dErr) {
          console.error('2D Canvas Mode Shape update error:', c2dErr);
        }

        // 4. Update 3D Overlay Info
        try {
          this.update3dOverlayInfo('local_mode');
        } catch (ovErr) {
          console.error('Overlay Info update error:', ovErr);
        }

        // 5. Update FSM Key Indicator Labels
        try {
          const modes = data.critical_modes;
          if (modes) {
            const isBending = modes.load_type && modes.load_type.startsWith('bending');
            const elPcrl = document.getElementById('valPcrl');
            const elPcrd = document.getElementById('valPcrd');
            const elPcre = document.getElementById('valPcre');

            if (isBending) {
              if (elPcrl) elPcrl.innerText = `${modes.m_crl} kN·m (${modes.l_local} mm)`;
              if (elPcrd) elPcrd.innerText = `${modes.m_crd} kN·m (${modes.l_distortional} mm)`;
              if (elPcre) elPcre.innerText = `${modes.m_cre} kN·m (${modes.l_global} mm)`;
            } else {
              if (elPcrl) elPcrl.innerText = `${modes.p_crl} kN (${modes.l_local} mm)`;
              if (elPcrd) elPcrd.innerText = `${modes.p_crd} kN (${modes.l_distortional} mm)`;
              if (elPcre) elPcre.innerText = `${modes.p_cre} kN (${modes.l_global} mm)`;
            }
          }
        } catch (lblErr) {
          console.error('Label update error:', lblErr);
        }

        // Update Step 3 Badge & Assistant
        this.updateWorkflowBadge(3, 'ready', '해석완료');
        this.updateSmartAssistant('fsm_completed', {
          pcrl: data.critical_modes?.p_crl || data.critical_modes?.m_crl
        });

        const elapsed = ((performance.now() - startTime) / 1000).toFixed(2);
        this.showStatus(`✅ 해석 및 부재설계 완료 (${elapsed}s)`, 'success', 3500);
      } catch (err) {
        if (err.name === 'AbortError') return;
        console.error('FSM solve error:', err);
        this.showStatus('FSM 탄성 버클링 해석 통신 실패', 'warning', 3000);
      }
    }, 50);
  }

  update3dOverlayInfo(modeKey, modeIndex = 1) {
    if (!this.currentFsmResult || !this.currentFsmResult.critical_modes) return;
    const modes = this.currentFsmResult.critical_modes;
    const isBending = modes.load_type && modes.load_type.startsWith('bending');
    const modeIdxStr = modeIndex === 1 ? '1차' : (modeIndex === 2 ? '2차' : '3차');

    let title = `${modeIdxStr} 로컬 버클링 (Mode ${modeIndex} Local)`;
    let len = modes.l_local || 80.0;
    let beta = 1.0;
    let wr = 'Wflex: 68%, Wtrans: 32%';
    let cap = isBending ? `${modes.m_crl || '-'} kN·m` : `${modes.p_crl || '-'} kN`;

    if (modeKey === 'dist_mode') {
      title = `${modeIdxStr} 디스토셔널 버클링 (Mode ${modeIndex} Distortional)`;
      len = modes.l_distortional || 300.0;
      beta = 1.0;
      wr = 'Wflex: 52%, Wtrans: 48%';
      cap = isBending ? `${modes.m_crd || '-'} kN·m` : `${modes.p_crd || '-'} kN`;
    } else if (modeKey === 'glob_mode') {
      title = `${modeIdxStr} 글로벌 버클링 (Mode ${modeIndex} Global)`;
      len = modes.l_global || 3000.0;
      beta = 1.0;
      wr = 'Wflex: 12%, Wshear: 88%';
      cap = isBending ? `${modes.m_cre || '-'} kN·m` : `${modes.p_cre || '-'} kN`;
    }

    const overlay = document.getElementById('viewer3dOverlayInfo');
    if (overlay) overlay.style.display = 'block';

    const elTitle = document.getElementById('val3dModeTitle');
    if (elTitle) elTitle.textContent = title;
    const elLen = document.getElementById('val3dLength');
    if (elLen) elLen.textContent = `${len} mm`;
    const elBeta = document.getElementById('val3dBeta');
    if (elBeta) elBeta.textContent = `${beta.toFixed(3)}`;
    const elWr = document.getElementById('val3dWorkRatio');
    if (elWr) elWr.textContent = wr;
    const elCap = document.getElementById('val3dDsmCap');
    if (elCap) elCap.textContent = cap;
  }

  async runDesignCheck() {
    if (!this.currentGeometry) return;

    const fy = parseFloat(document.getElementById('yieldStress').value) || 345;
    const lMem = parseFloat(document.getElementById('memberLength').value) || 3000;
    const pu = parseFloat(document.getElementById('loadPu').value) || 50;
    const mux = parseFloat(document.getElementById('loadMux').value) || 5.0;
    const vu = parseFloat(document.getElementById('loadVu').value) || 15.0;

    const signal = this.getAbortSignal('design');

    try {
      const res = await fetch('/api/design/check', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          elements: this.currentGeometry.elements,
          thickness: this.currentGeometry.thickness,
          yield_stress: fy,
          length_x: lMem,
          length_y: lMem,
          length_t: lMem,
          pu: pu,
          mux: mux,
          muy: 0.0,
          vu: vu
        }),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.currentDesignResult = data;
      this.renderDesignDashboard(data);
      this.calculateWebCrippling();
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Design Check Error:', err);
    }
  }

  renderDesignDashboard(data) {
    if (!data) return;

    const updateGauge = (idPrefix, dcVal, status, capacityStr) => {
      const ratioEl = document.getElementById(idPrefix + 'Ratio');
      const badgeEl = document.getElementById(idPrefix + 'Badge');
      const barEl = document.getElementById(idPrefix + 'Bar');
      const capEl = document.getElementById(idPrefix + 'Cap');

      if (ratioEl) ratioEl.innerText = dcVal.toFixed(3);
      if (capEl && capacityStr) capEl.innerText = capacityStr;

      if (badgeEl) {
        badgeEl.className = 'badge-status ' + (status === 'OK' ? 'ok' : 'ng');
        badgeEl.innerText = status;
      }

      if (barEl) {
        const pct = Math.min(dcVal * 100, 100);
        barEl.style.width = pct + '%';
        barEl.className = 'gauge-fill ' + (dcVal > 1.0 ? 'danger' : dcVal > 0.8 ? 'warning' : '');
      }
    };

    // 1. Compression
    const comp = data.compression;
    updateGauge('comp', comp.dc_ratio, comp.status, `φPn = ${comp.phi_pn} kN (${comp.governing_mode})`);

    // 2. Flexure
    const flex = data.flexure;
    updateGauge('flex', flex.dc_ratio, flex.status, `φMn = ${flex.phi_mn} kN·m (${flex.governing_mode})`);

    // 3. Shear
    const shear = data.shear;
    updateGauge('shear', shear.dc_ratio, shear.status, `φVn = ${shear.phi_vn} kN`);

    // 4. P-M Interaction
    const inter = data.interaction;
    updateGauge('inter', inter.ratio, inter.status, `P-M 조합비 (${inter.formula_type})`);

    // Update Step 4 Badge & Assistant
    const maxRatio = Math.max(comp.dc_ratio || 0, flex.dc_ratio || 0, shear.dc_ratio || 0, inter.ratio || 0);
    if (maxRatio <= 1.0) {
      this.updateWorkflowBadge(4, 'ready', '검토합격');
      this.updateSmartAssistant('design_passed', { maxRatio });
    } else {
      this.updateWorkflowBadge(4, 'danger', '강도초과');
      this.updateSmartAssistant('design_failed', { maxRatio });
    }
  }

  // ================= Phase 1: Element Spreadsheet Editor =================
  openElementEditorModal() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const tbody = document.getElementById('elementTableBody');
    tbody.innerHTML = '';

    this.currentGeometry.elements.forEach((e, idx) => {
      const tr = this.createElementRowHTML(e, idx + 1);
      tbody.appendChild(tr);
    });

    document.getElementById('elementEditorModal').classList.add('active');
  }

  closeElementEditorModal() {
    document.getElementById('elementEditorModal').classList.remove('active');
    this.canvas2d.setHighlightElement(null);
  }

  createElementRowHTML(e, id) {
    const tr = document.createElement('tr');
    tr.dataset.elemId = id;

    // Hover highlight on 2D canvas
    tr.addEventListener('mouseenter', () => this.canvas2d.setHighlightElement(id));
    tr.addEventListener('mouseleave', () => this.canvas2d.setHighlightElement(null));

    const deg = Math.round(((e.angle || 0) * 180 / Math.PI) * 10) / 10;

    tr.innerHTML = `
      <td style="font-weight: bold; color: var(--accent-primary);">${id}</td>
      <td><input type="number" class="elem-x0" value="${e.x0 !== undefined ? e.x0 : 0}" step="1"></td>
      <td><input type="number" class="elem-y0" value="${e.y0 !== undefined ? e.y0 : 0}" step="1"></td>
      <td><input type="number" class="elem-x1" value="${e.x1 !== undefined ? e.x1 : 0}" step="1"></td>
      <td><input type="number" class="elem-y1" value="${e.y1 !== undefined ? e.y1 : 0}" step="1"></td>
      <td><input type="number" class="elem-len" value="${e.length || 10}" step="1"></td>
      <td><input type="number" class="elem-ang" value="${deg}" step="1"></td>
      <td><input type="number" class="elem-t" value="${e.thickness || this.currentGeometry.thickness || 2.0}" step="0.1"></td>
      <td><input type="number" class="elem-r" value="${e.radius || 0.0}" step="0.5"></td>
      <td><button class="btn-row-del" title="삭제">✕</button></td>
    `;

    tr.querySelector('.btn-row-del').addEventListener('click', (ev) => {
      ev.stopPropagation();
      tr.remove();
      this.reindexElementRows();
    });

    return tr;
  }

  reindexElementRows() {
    const rows = document.querySelectorAll('#elementTableBody tr');
    rows.forEach((r, idx) => {
      r.dataset.elemId = idx + 1;
      r.cells[0].textContent = idx + 1;
    });
  }

  addElementRow() {
    const tbody = document.getElementById('elementTableBody');
    const newId = tbody.children.length + 1;
    const defaultElem = {
      elem_id: newId,
      x0: 0, y0: 0, x1: 50, y1: 0,
      length: 50, angle: 0,
      thickness: this.currentGeometry ? this.currentGeometry.thickness : 2.0,
      radius: 0.0
    };
    const tr = this.createElementRowHTML(defaultElem, newId);
    tbody.appendChild(tr);
  }

  async applyElementsEditor() {
    const rows = document.querySelectorAll('#elementTableBody tr');
    const elements = [];
    let defaultT = 2.0;

    rows.forEach((r, idx) => {
      const x0 = parseFloat(r.querySelector('.elem-x0').value) || 0;
      const y0 = parseFloat(r.querySelector('.elem-y0').value) || 0;
      const x1 = parseFloat(r.querySelector('.elem-x1').value) || 0;
      const y1 = parseFloat(r.querySelector('.elem-y1').value) || 0;
      const length = parseFloat(r.querySelector('.elem-len').value) || Math.sqrt((x1 - x0) ** 2 + (y1 - y0) ** 2);
      const angleDeg = parseFloat(r.querySelector('.elem-ang').value) || 0;
      const t = parseFloat(r.querySelector('.elem-t').value) || 2.0;
      const radius = parseFloat(r.querySelector('.elem-r').value) || 0.0;
      defaultT = t;

      elements.push({
        elem_id: idx + 1,
        x0, y0, x1, y1,
        length,
        angle: angleDeg * Math.PI / 180,
        thickness: t,
        radius
      });
    });

    if (elements.length === 0) return;

    try {
      const res = await fetch('/api/section/elements', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ elements, thickness: defaultT })
      });
      const data = await res.json();
      this.updateSectionData(data);
      this.closeElementEditorModal();
    } catch (err) {
      console.error('Apply Elements error:', err);
    }
  }

  // ================= Phase 1: Geometric Transforms =================
  applyOptimisticTransform(elements, type, angleDeg = 0) {
    if (!elements || elements.length === 0) return [];

    let totA = 0, sumXA = 0, sumYA = 0;
    elements.forEach(e => {
      const ea = (e.length || 10) * (e.thickness || 2.0);
      totA += ea;
      sumXA += ea * (e.x0 + e.x1) / 2.0;
      sumYA += ea * (e.y0 + e.y1) / 2.0;
    });
    const cx = totA > 0 ? sumXA / totA : 0;
    const cy = totA > 0 ? sumYA / totA : 0;

    let rad = 0;
    if (type === 'rotate_90_cw') rad = -Math.PI / 2;
    else if (type === 'rotate_90_ccw') rad = Math.PI / 2;
    else if (type === 'rotate_angle') rad = (angleDeg * Math.PI) / 180;

    const cosA = Math.cos(rad);
    const sinA = Math.sin(rad);

    return elements.map((e, idx) => {
      let x0 = e.x0, y0 = e.y0, x1 = e.x1, y1 = e.y1, ang = e.angle || 0;

      if (type.startsWith('rotate')) {
        const dx0 = x0 - cx, dy0 = y0 - cy;
        const dx1 = x1 - cx, dy1 = y1 - cy;
        x0 = dx0 * cosA - dy0 * sinA + cx;
        y0 = dx0 * sinA + dy0 * cosA + cy;
        x1 = dx1 * cosA - dy1 * sinA + cx;
        y1 = dx1 * sinA + dy1 * cosA + cy;
        ang = (ang + rad) % (Math.PI * 2);
      } else if (type === 'mirror_h') {
        y0 = 2 * cy - y0;
        y1 = 2 * cy - y1;
        ang = -ang;
      } else if (type === 'mirror_v') {
        x0 = 2 * cx - x0;
        x1 = 2 * cx - x1;
        ang = Math.PI - ang;
      } else if (type === 'align_cg') {
        x0 -= cx; x1 -= cx;
        y0 -= cy; y1 -= cy;
      }

      return {
        ...e,
        elem_id: e.elem_id || (idx + 1),
        x0, y0, x1, y1,
        angle: ang
      };
    });
  }

  async transformSection(transformType, angleDeg = 0) {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    // 1. 기존 변환 전 원본 elements 보관
    const originalElements = this.currentGeometry.elements;

    // 2. [즉시 수행] 클라이언트 측 옵티미스틱 기하 변환 및 2D 캔버스 0ms 렌더링
    const optimisticElements = this.applyOptimisticTransform(originalElements, transformType, angleDeg);
    const optimisticGeom = {
      ...this.currentGeometry,
      elements: optimisticElements
    };
    this.currentGeometry = optimisticGeom;
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 단면 성질 재계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

    const typeNames = {
      rotate_90_cw: '90° 시계방향 회전',
      rotate_90_ccw: '90° 반시계방향 회전',
      mirror_h: '상하 대칭 (Mirror X)',
      mirror_v: '좌우 대칭 (Mirror Y)',
      align_cg: '도심 원점 정렬',
      rotate_angle: `${angleDeg}° 회전`
    };
    const desc = typeNames[transformType] || '단면 변환';
    this.showStatus(`🔄 ${desc} 적용 및 정밀 단면해석 중...`, 'busy');

    // 3. [연산 중단 후 최신 재연산] 서버에는 원본 originalElements를 전송하여 2중 변환 방지
    const signal = this.getAbortSignal('transform', `이전 변환 취소 후 ${desc} 재연산 중...`);

    const payload = {
      elements: originalElements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: transformType,
      angle_deg: angleDeg,
      center_at_cg: true
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Transform error:', err);
      this.showStatus('단면 변환 오류 발생', 'warning', 3000);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  }

  openRotateModal() {
    document.getElementById('rotateModal').classList.add('active');
  }

  closeRotateModal() {
    document.getElementById('rotateModal').classList.remove('active');
  }

  async submitRotate() {
    const angle = parseFloat(document.getElementById('rotateAngleInput').value) || 0;
    const centerCg = document.getElementById('rotateCenterCg').checked;

    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    // 1. 기존 변환 전 원본 elements 보관
    const originalElements = this.currentGeometry.elements;

    // 2. [즉시 수행] 클라이언트 측 0ms 캔버스 렌더링
    const optimisticElements = this.applyOptimisticTransform(originalElements, 'rotate_angle', angle);
    const optimisticGeom = {
      ...this.currentGeometry,
      elements: optimisticElements
    };
    this.currentGeometry = optimisticGeom;
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 단면 성질 재계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.closeRotateModal();

    this.showStatus(`🔄 ${angle}° 임의각도 회전 적용 및 정밀 단면해석 중...`, 'busy');
    const signal = this.getAbortSignal('transform', `이전 회전 취소 후 ${angle}° 재회전 중...`);

    const payload = {
      elements: originalElements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: 'rotate_angle',
      angle_deg: angle,
      center_at_cg: centerCg
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Rotate submit error:', err);
      this.showStatus('회전 연산 실패', 'warning', 3000);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  }

  // ================= Phase 1: Insert Ribs Wizard =================
  openInsertRibsModal() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const sel = document.getElementById('ribTargetElementSelect');
    sel.innerHTML = '';

    this.currentGeometry.elements.forEach(e => {
      const opt = document.createElement('option');
      opt.value = e.elem_id;
      opt.textContent = `요소 ${e.elem_id} (L = ${Math.round(e.length)} mm, θ = ${Math.round(e.angle * 180 / Math.PI)}°)`;
      sel.appendChild(opt);
    });

    // Default select web (longest element)
    if (this.currentGeometry.elements.length >= 3) {
      sel.selectedIndex = 2; // Web in C-section
    }

    document.getElementById('insertRibsModal').classList.add('active');
  }

  closeInsertRibsModal() {
    document.getElementById('insertRibsModal').classList.remove('active');
  }

  async submitInsertRibs() {
    const targetId = parseInt(document.getElementById('ribTargetElementSelect').value) || 1;
    const ribType = document.getElementById('ribTypeSelect').value;
    const ribWidth = parseFloat(document.getElementById('ribWidthInput').value) || 25.0;
    const ribDepth = parseFloat(document.getElementById('ribDepthInput').value) || 12.0;
    const numRibs = parseInt(document.getElementById('ribCountInput').value) || 1;
    const ribRadius = parseFloat(document.getElementById('ribRadiusInput').value) || 0.0;

    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 리브 추가 계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

    const payload = {
      elements: this.currentGeometry.elements,
      thickness: this.currentGeometry.thickness || 2.0,
      target_elem_id: targetId,
      rib_type: ribType,
      rib_width: ribWidth,
      rib_depth: ribDepth,
      num_ribs: numRibs,
      rib_radius: ribRadius
    };

    try {
      const res = await fetch('/api/section/insert-ribs', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      const data = await res.json();
      this.updateSectionData(data);
      this.closeInsertRibsModal();
    } catch (err) {
      console.error('Insert Ribs error:', err);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  }

  // ================= Phase 2: Section Library Browser =================
  openLibraryModal() {
    this.currentLibName = this.currentLibName || "SSMA";
    document.getElementById('sectionLibraryModal').classList.add('active');
    this.loadLibrary(this.currentLibName);
  }

  closeLibraryModal() {
    document.getElementById('sectionLibraryModal').classList.remove('active');
  }

  searchLibrary() {
    const q = document.getElementById('libSearchInput').value.trim();
    this.loadLibrary(this.currentLibName || "SSMA", q);
  }

  async loadLibrary(libName, query = "") {
    const container = document.getElementById('libSectionListContainer');
    container.innerHTML = '<div style="font-size:12px; color:var(--text-muted); padding:10px;">라이브러리 불러오는 중...</div>';

    try {
      const url = `/api/library/sections?lib=${libName}&query=${encodeURIComponent(query)}`;
      const res = await fetch(url);
      const data = await res.json();

      container.innerHTML = '';
      if (!data.types || data.types.length === 0) {
        container.innerHTML = '<div style="font-size:12px; color:var(--text-muted); padding:10px;">검색된 단면이 없습니다.</div>';
        return;
      }

      data.types.forEach(t => {
        if (t.sections.length === 0) return;

        const header = document.createElement('div');
        header.className = 'lib-type-header';
        header.innerHTML = `<span>${t.name}</span><span>${t.sections.length}개</span>`;
        container.appendChild(header);

        t.sections.forEach(s => {
          const item = document.createElement('div');
          item.className = 'lib-section-item';
          item.innerHTML = `<span>${s.name}</span><span style="color:var(--text-muted); font-size:11px;">${s.type}</span>`;
          item.addEventListener('click', () => {
            document.querySelectorAll('.lib-section-item').forEach(el => el.classList.remove('selected'));
            item.classList.add('selected');
            this.previewLibrarySection(libName, s.offset, s.name);
          });
          container.appendChild(item);
        });
      });
    } catch (err) {
      console.error('Load Library error:', err);
      container.innerHTML = '<div style="font-size:12px; color:var(--accent-danger); padding:10px;">라이브러리 로드 실패</div>';
    }
  }

  async previewLibrarySection(libName, offset, sctName) {
    document.getElementById('libSelectedName').textContent = `${libName} - ${sctName}`;
    const btnLoad = document.getElementById('btnLoadLibSection');
    btnLoad.disabled = true;

    try {
      const res = await fetch(`/api/library/sections/${libName}/${offset}`);
      const data = await res.json();
      this.selectedLibSectionData = data;

      const p = data.properties;
      document.getElementById('libPropAg').textContent = p.area.toLocaleString();
      document.getElementById('libPropIx').textContent = p.ix.toLocaleString();
      document.getElementById('libPropIy').textContent = p.iy.toLocaleString();
      document.getElementById('libPropT').textContent = data.geometry.thickness;

      this.drawLibPreview(data.geometry);
      btnLoad.disabled = false;
    } catch (err) {
      console.error('Preview error:', err);
    }
  }

  drawLibPreview(geometry) {
    const canvas = document.getElementById('libPreviewCanvas');
    const ctx = canvas.getContext('2d');
    canvas.width = canvas.parentElement.clientWidth;
    canvas.height = canvas.parentElement.clientHeight;

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    const elements = geometry.elements || [];
    if (elements.length === 0) return;

    let minX = 1e9, maxX = -1e9, minY = 1e9, maxY = -1e9;
    elements.forEach(e => {
      minX = Math.min(minX, e.x0, e.x1);
      maxX = Math.max(maxX, e.x0, e.x1);
      minY = Math.min(minY, e.y0, e.y1);
      maxY = Math.max(maxY, e.y0, e.y1);
    });

    const w = Math.max(maxX - minX, 10);
    const h = Math.max(maxY - minY, 10);
    const pad = 24;
    const scale = Math.min((canvas.width - pad * 2) / w, (canvas.height - pad * 2) / h);
    const midX = (minX + maxX) / 2;
    const midY = (minY + maxY) / 2;

    ctx.save();
    ctx.translate(canvas.width / 2, canvas.height / 2);
    ctx.scale(scale, -scale);
    ctx.translate(-midX, -midY);

    // Thickness stroke
    ctx.strokeStyle = 'rgba(59, 130, 246, 0.4)';
    ctx.lineWidth = geometry.thickness;
    ctx.lineCap = 'round';
    ctx.beginPath();
    elements.forEach(e => {
      ctx.moveTo(e.x0, e.y0);
      ctx.lineTo(e.x1, e.y1);
    });
    ctx.stroke();

    // Centerline
    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 1.5 / scale;
    ctx.beginPath();
    elements.forEach(e => {
      ctx.moveTo(e.x0, e.y0);
      ctx.lineTo(e.x1, e.y1);
    });
    ctx.stroke();

    ctx.restore();
  }

  loadSelectedLibSection() {
    if (!this.selectedLibSectionData) return;
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 라이브러리 단면 로드 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.updateSectionData(this.selectedLibSectionData);
    this.closeLibraryModal();
  }

  // ================= Phase 2: Material Properties & Cold-Work =================
  async openMaterialModal() {
    document.getElementById('materialModal').classList.add('active');
    
    // Load presets if empty
    const sel = document.getElementById('matPresetSelect');
    if (sel.options.length === 0) {
      try {
        const res = await fetch('/api/library/materials');
        const data = await res.json();
        sel.innerHTML = '';
        data.materials.forEach(m => {
          const opt = document.createElement('option');
          opt.value = m.code;
          opt.textContent = `[${m.category}] ${m.name} (Fy=${m.fy} MPa)`;
          opt.dataset.fy = m.fy;
          opt.dataset.fu = m.fu;
          opt.dataset.e = m.e;
          opt.dataset.nu = m.nu;
          sel.appendChild(opt);
        });
      } catch (err) {
        console.error('Load materials error:', err);
      }
    }

    this.recalcColdWork();
  }

  closeMaterialModal() {
    document.getElementById('materialModal').classList.remove('active');
  }

  onMaterialPresetChanged(code) {
    const sel = document.getElementById('matPresetSelect');
    const opt = sel.options[sel.selectedIndex];
    if (opt) {
      document.getElementById('matFyInput').value = opt.dataset.fy || 345;
      document.getElementById('matFuInput').value = opt.dataset.fu || 450;
      document.getElementById('matEInput').value = opt.dataset.e || 205000;
      document.getElementById('matNuInput').value = opt.dataset.nu || 0.3;
      this.recalcColdWork();
    }
  }

  async recalcColdWork() {
    const fy = parseFloat(document.getElementById('matFyInput').value) || 345.0;
    const fu = parseFloat(document.getElementById('matFuInput').value) || 450.0;
    const enabled = document.getElementById('matColdWorkCheck').checked;

    if (!enabled) {
      document.getElementById('valFyc').textContent = fy.toString();
      document.getElementById('valFya').textContent = fy.toString();
      document.getElementById('valPercentInc').textContent = '+0%';
      return;
    }

    const t = this.currentGeometry ? this.currentGeometry.thickness : 2.0;
    const totalLen = this.currentGeometry ? this.currentGeometry.total_length : 250.0;
    const numCorners = 4;
    const rInside = 2.0;

    try {
      const res = await fetch('/api/material/cold-work', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          base_fy: fy,
          base_fu: fu,
          r_inside: rInside,
          thickness: t,
          num_corners: numCorners,
          total_length: totalLen
        })
      });
      const data = await res.json();
      document.getElementById('valFyc').textContent = data.fyc;
      document.getElementById('valFya').textContent = data.fya;
      document.getElementById('valPercentInc').textContent = `+${data.percent_increase}%`;
    } catch (err) {
      console.error('Cold work error:', err);
    }
  }

  applyMaterialToDesign() {
    const enabled = document.getElementById('matColdWorkCheck').checked;
    const baseFy = parseFloat(document.getElementById('matFyInput').value) || 345.0;
    const fya = parseFloat(document.getElementById('valFya').textContent) || baseFy;
    const designFy = enabled ? fya : baseFy;

    document.getElementById('yieldStress').value = designFy;
    this.runDesignCheck();
    this.closeMaterialModal();
  }

  // ================= Phase 3: Quick Design (Auto Sizing) =================
  openQuickDesignModal() {
    document.getElementById('quickDesignModal').classList.add('active');
  }

  closeQuickDesignModal() {
    document.getElementById('quickDesignModal').classList.remove('active');
  }

  async executeQuickDesign() {
    const btn = document.getElementById('btnExecuteQuickDesign');
    btn.disabled = true;
    btn.textContent = '⏳ 3대 한계상태 검토 및 최적 단면 탐색 중...';

    const typeFilter = document.getElementById('qdTypeFilter') ? document.getElementById('qdTypeFilter').value : 'All';
    const depthFilter = document.getElementById('qdDepthFilter') && document.getElementById('qdDepthFilter').value ? parseFloat(document.getElementById('qdDepthFilter').value) : null;
    const flangeFilter = document.getElementById('qdFlangeFilter') && document.getElementById('qdFlangeFilter').value ? parseFloat(document.getElementById('qdFlangeFilter').value) : null;
    const thicknessFilter = document.getElementById('qdThicknessFilter') && document.getElementById('qdThicknessFilter').value ? parseFloat(document.getElementById('qdThicknessFilter').value) : null;
    const config = document.getElementById('qdConfigSelect') ? document.getElementById('qdConfigSelect').value : 'Single';
    const punched = document.getElementById('qdPunchedCheck') ? document.getElementById('qdPunchedCheck').checked : false;
    const coldWork = document.getElementById('qdColdWorkCheck') ? document.getElementById('qdColdWorkCheck').checked : false;
    const reserve = document.getElementById('qdReserveCheck') ? document.getElementById('qdReserveCheck').checked : false;

    const span = parseFloat(document.getElementById('qdSpanInput')?.value) || 3000.0;
    const spacing = parseFloat(document.getElementById('qdSpacingInput')?.value) || 400.0;
    const bracing = document.getElementById('qdBracingSelect') ? document.getElementById('qdBracingSelect').value : 'Unbraced';

    const deadLoad = parseFloat(document.getElementById('qdDeadInput')?.value) || 0.0;
    const liveLoad = parseFloat(document.getElementById('qdLiveInput')?.value) || 0.0;
    const windLoad = parseFloat(document.getElementById('qdWindInput')?.value) || 0.0;
    const deadAxial = parseFloat(document.getElementById('qdAxialInput')?.value) || 0.0;
    const deflLimit = parseFloat(document.getElementById('qdDeflectionSelect')?.value) || 360.0;
    const bearingLen = parseFloat(document.getElementById('qdBearingLength')?.value) || 38.0;
    const lib = document.getElementById('qdLibrarySelect')?.value || null;
    const fy = parseFloat(document.getElementById('qdYieldSelect')?.value) || 345.0;

    try {
      const res = await fetch('/api/design/quick-design', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          shape_type_filter: typeFilter,
          depth_filter: depthFilter,
          flange_filter: flangeFilter,
          thickness_filter: thicknessFilter,
          config: config,
          punched: punched,
          cold_work: coldWork,
          reserve: reserve,
          span: span,
          length: span,
          spacing: spacing,
          bracing: bracing,
          dead_load: deadLoad,
          live_load: liveLoad,
          wind_load: windLoad,
          dead_axial: deadAxial,
          deflection_live_limit: deflLimit,
          bearing_length: bearingLen,
          library: lib,
          fy: fy,
          max_results: 15
        })
      });

      const data = await res.json();
      this.quickDesignCandidates = data.candidates || [];
      document.getElementById('qdResultCount').textContent = data.total_passed || 0;

      const tbody = document.getElementById('quickDesignTableBody');
      tbody.innerHTML = '';

      if (this.quickDesignCandidates.length === 0) {
        tbody.innerHTML = `<tr><td colspan="11" style="text-align:center; color: var(--accent-warning); padding: 30px;">조건을 만족하는 단면이 없습니다. 하중이나 제약조건을 완화해 보세요.</td></tr>`;
        return;
      }

      this.quickDesignCandidates.forEach((cand, idx) => {
        const tr = document.createElement('tr');
        const rankBadge = cand.rank === 1 ? '🥇 1' : (cand.rank === 2 ? '🥈 2' : (cand.rank === 3 ? '🥉 3' : cand.rank));
        const savingsBadge = cand.weight_savings_pct > 0 ? `<span style="color: var(--accent-success); font-weight: 600;">-${cand.weight_savings_pct}%</span>` : '-';
        
        const strengthDcColor = cand.dc_strength <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const deflDcColor = cand.dc_deflection <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const cripDcColor = cand.dc_crippling <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const maxDcColor = cand.max_dc <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';

        tr.innerHTML = `
          <td style="text-align: center; font-weight: 700;">${rankBadge}</td>
          <td style="font-weight: 600; color: var(--accent-primary);">${cand.name}</td>
          <td><span class="brand-badge">${cand.library_name}</span></td>
          <td><strong>${cand.weight}</strong> kg/m</td>
          <td style="font-size: 11px;">${cand.depth} × ${cand.flange} × ${cand.thickness}</td>
          <td style="color: ${strengthDcColor}; font-weight: 600;" title="P-M 및 전단 강도 D/C">${cand.dc_strength}</td>
          <td style="color: ${deflDcColor}; font-weight: 600;" title="활하중/총하중 처짐 D/C (${cand.deflection_live_mm} mm)">${cand.dc_deflection}</td>
          <td style="color: ${cripDcColor}; font-weight: 600;" title="웨브 크리플링 D/C (Ru=${cand.reaction_ru_kn} kN)">${cand.dc_crippling}</td>
          <td style="font-weight: 700; color: ${maxDcColor};">${cand.max_dc}</td>
          <td>${savingsBadge}</td>
          <td style="text-align: center; min-width: 70px;">
            <button class="btn btn-outline" onclick="window.app.applyQuickDesignCandidate(${idx})" style="padding: 4px 8px; font-size: 11.5px; font-weight: 600; white-space: nowrap; width: 100%;">
              ⚡ 적용
            </button>
          </td>
        `;
        tbody.appendChild(tr);
      });
    } catch (err) {
      console.error('Quick design error:', err);
      alert('퀵 디자인 탐색 중 오류가 발생했습니다.');
    } finally {
      btn.disabled = false;
      btn.textContent = '⚡ 최적 경량 단면 자동 탐색 실행';
    }
  }

  applyQuickDesignCandidate(index) {
    if (!this.quickDesignCandidates || !this.quickDesignCandidates[index]) return;
    const cand = this.quickDesignCandidates[index];
    if (cand.elements && cand.elements.length > 0) {
      // Build geometry payload
      const geometry = {
        elements: cand.elements,
        thickness: cand.thickness,
        is_closed: false,
        total_length: cand.depth * 2 + cand.flange * 2
      };
      
      // Update Span Lengths
      const spanInput = document.getElementById('qdSpanInput');
      if (spanInput && spanInput.value) {
        const spanVal = parseFloat(spanInput.value);
        const lx = document.getElementById('lengthX');
        const ly = document.getElementById('lengthY');
        const lt = document.getElementById('lengthT');
        if (lx) lx.value = spanVal;
        if (ly) ly.value = spanVal;
        if (lt) lt.value = spanVal;
      }

      this.canvas2d.clearPropertiesMarkers();
      this.canvas2d.showLoading('⏳ 퀵 디자인 단면 로드 중...');
      if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

      this.updateSectionData({ geometry: geometry });
      this.closeQuickDesignModal();
      this.showStatus(`퀵 디자인 단면 [${cand.name}] (${cand.weight} kg/m) 적용 완료`, 'success', 4000);
    }
  }

  // ================= Phase 3: Web Crippling Detailed =================
  async calculateWebCrippling() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    // Find web height
    let hw = 0.0;
    this.currentGeometry.elements.forEach(el => {
      const dy = Math.abs(el.y1 - el.y0);
      if (dy > hw) hw = dy;
    });
    if (hw <= 0) hw = 150.0;

    const t = this.currentGeometry.thickness || 2.0;
    const r = 2.0;
    const nBearing = parseFloat(document.getElementById('cripBearingLength').value) || 50.0;
    const ru = parseFloat(document.getElementById('cripRuInput').value) || 0.0;
    const cond = document.getElementById('cripConditionSelect').value || 'IOF';
    const fastened = document.getElementById('cripFastenedCheck').checked;
    const stiffened = document.getElementById('cripStiffenedCheck').checked;
    const fy = parseFloat(document.getElementById('yieldStress').value) || 345.0;

    try {
      const res = await fetch('/api/design/web-crippling', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          h: hw,
          t: t,
          r: r,
          n_bearing: nBearing,
          fy: fy,
          condition: cond,
          fastened: fastened,
          stiffened: stiffened,
          theta_deg: 90.0,
          ru: ru
        })
      });

      const data = await res.json();
      const pncKn = (data.pnc / 1000.0).toFixed(2);
      const phiPncKn = (data.phi_pnc / 1000.0).toFixed(2);

      document.getElementById('valCripPnc').textContent = `${pncKn} kN`;
      document.getElementById('valCripPhiPnc').textContent = `${phiPncKn} kN`;
      
      const dcEl = document.getElementById('valCripDcRatio');
      dcEl.textContent = data.dc_ratio.toFixed(3);
      dcEl.style.color = data.dc_ratio <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';

      const formulaEl = document.getElementById('valCripFormula');
      if (formulaEl) formulaEl.textContent = data.formula || '';

      // Update Right Dashboard Web Crippling Gauge
      const dashRatioEl = document.getElementById('cripDashRatio');
      const dashBadgeEl = document.getElementById('cripDashBadge');
      const dashBarEl = document.getElementById('cripDashBar');
      const dashCapEl = document.getElementById('cripDashCap');

      if (dashRatioEl) dashRatioEl.innerText = data.dc_ratio.toFixed(3);
      if (dashCapEl) dashCapEl.innerText = `φPnc = ${phiPncKn} kN (${cond})`;
      if (dashBadgeEl) {
        const isOk = data.dc_ratio <= 1.0;
        dashBadgeEl.className = 'badge-status ' + (isOk ? 'ok' : 'ng');
        dashBadgeEl.innerText = isOk ? 'OK' : 'NG';
      }
      if (dashBarEl) {
        const pct = Math.min(data.dc_ratio * 100, 100);
        dashBarEl.style.width = pct + '%';
        dashBarEl.className = 'gauge-fill ' + (data.dc_ratio > 1.0 ? 'danger' : data.dc_ratio > 0.8 ? 'warning' : '');
      }
    } catch (err) {
      console.error('Web crippling error:', err);
    }
  }

  // ================= Phase 3: FSM Parameters & Custom Sweep =================
  openFsmParamsModal() {
    document.getElementById('fsmParamsModal').classList.add('active');
  }

  closeFsmParamsModal() {
    document.getElementById('fsmParamsModal').classList.remove('active');
  }

  async applyFsmCustomParams() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const lMin = parseFloat(document.getElementById('fsmLmin').value) || 10.0;
    const lMax = parseFloat(document.getElementById('fsmLmax').value) || 10000.0;
    const steps = parseInt(document.getElementById('fsmSteps').value) || 60;
    const stressType = document.getElementById('fsmStressType').value || 'compression';
    this.currentFsmStressType = stressType;
    const fy = parseFloat(document.getElementById('yieldStress').value) || 345.0;
    const lGlobal = parseFloat(document.getElementById('memberLength').value) || 3000.0;

    const btn = document.getElementById('btnApplyFsmParams');
    btn.disabled = true;
    btn.textContent = '⏳ 해석 중...';

    try {
      const res = await fetch('/api/fsm/parameters', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          elements: this.currentGeometry.elements,
          thickness: this.currentGeometry.thickness,
          l_min: lMin,
          l_max: lMax,
          steps: steps,
          load_type: stressType,
          yield_stress: fy,
          elastic_modulus: 205000.0,
          poisson_ratio: 0.3,
          member_length: lGlobal
        })
      });

      const data = await res.json();
      this.lastFsmResult = data;
      const pts = data.signature_curve || (data.curve && data.curve.points) || [];
      const modes = data.critical_modes || data.modes || {};

      this.lastFsmNodes = data.nodes || [];
      this.lastFsmStrips = data.strips || [];

      this.currentFsmResult = {
        signature_curve: pts,
        critical_modes: modes,
        nodes: this.lastFsmNodes,
        strips: this.lastFsmStrips
      };

      // 1. Update FSM Signature Chart with multi-mode curves
      try {
        if (this.fsmChart) {
          this.fsmChart.updateData(pts, modes.load_type);
        }
      } catch (cErr) {
        console.error('Chart update error:', cErr);
      }

      // 2. Update 3D Viewer with new mode shapes & stress profile
      const activeModeKey = this.currentFsmModeKey || 'local_mode';
      const activeModeIdx = this.currentFsmModeIndex || 1;
      try {
        if (this.viewer3d) {
          this.viewer3d.setData(this.lastFsmNodes, this.lastFsmStrips, activeModeKey);
        }
      } catch (vErr) {
        console.error('3D Viewer update error:', vErr);
      }

      // 3. Update 2D Canvas Mode Shape
      try {
        if (this.canvas2d) {
          this.canvas2d.fsmModeIndex = activeModeIdx;
          this.canvas2d.setFsmModeData(this.lastFsmNodes, this.lastFsmStrips, activeModeKey, this.viewer3d ? this.viewer3d.amplitude : 15.0);
        }
      } catch (c2dErr) {
        console.error('2D Canvas update error:', c2dErr);
      }

      // 4. Update 3D Overlay Info
      try {
        this.update3dOverlayInfo(activeModeKey, activeModeIdx);
      } catch (ovErr) {
        console.error('Overlay Info update error:', ovErr);
      }

      // 5. Update FSM Key Indicator Labels
      const isBending = modes.load_type && modes.load_type.startsWith('bending');
      const elPcrl = document.getElementById('valPcrl');
      const elPcrd = document.getElementById('valPcrd');
      const elPcre = document.getElementById('valPcre');

      if (isBending) {
        if (elPcrl) elPcrl.innerText = `${modes.m_crl} kN·m (${modes.l_local} mm)`;
        if (elPcrd) elPcrd.innerText = `${modes.m_crd} kN·m (${modes.l_distortional} mm)`;
        if (elPcre) elPcre.innerText = `${modes.m_cre} kN·m (${modes.l_global} mm)`;
      } else {
        if (elPcrl) elPcrl.innerText = `${modes.p_crl} kN (${modes.l_local} mm)`;
        if (elPcrd) elPcrd.innerText = `${modes.p_crd} kN (${modes.l_distortional} mm)`;
        if (elPcre) elPcre.innerText = `${modes.p_cre} kN (${modes.l_global} mm)`;
      }

      this.showStatus('✅ 커스텀 FSM 해석 완료', 'success', 3000);
      this.closeFsmParamsModal();
    } catch (err) {
      console.error('FSM custom sweep error:', err);
      alert('FSM 커스텀 파라미터 해석 중 오류가 발생했습니다.');
    } finally {
      btn.disabled = false;
      btn.textContent = '⚡ 커스텀 파라미터로 재해석 실행';
    }
  }

  // ================= Phase 3: FSM Numerical Data Table & CSV =================
  getFsmPoints() {
    if (this.lastFsmResult && this.lastFsmResult.curve && this.lastFsmResult.curve.points) {
      return this.lastFsmResult.curve.points;
    }
    if (this.currentFsmResult && this.currentFsmResult.signature_curve) {
      const sc = this.currentFsmResult.signature_curve;
      const lens = sc.lengths || [];
      const lfs = sc.load_factors || [];
      const pts = [];
      const fy = parseFloat(document.getElementById('yieldStress').value) || 345;
      const ag = (this.currentProperties && this.currentProperties.area) ? this.currentProperties.area : 500;
      const sx = (this.currentProperties && this.currentProperties.sx_top) ? this.currentProperties.sx_top : 20000;
      const py = ag * fy;
      const my = sx * fy;
      for (let i = 0; i < lens.length; i++) {
        const lf = lfs[i] || 0.0;
        pts.push({
          length: lens[i],
          load_factor: lf,
          critical_load: lf * py,
          critical_moment: lf * my
        });
      }
      return pts;
    }
    return [];
  }

  openFsmDataModal() {
    const modal = document.getElementById('fsmDataModal');
    modal.classList.add('active');

    const tbody = document.getElementById('fsmDataTableBody');
    tbody.innerHTML = '';

    const pts = this.getFsmPoints();
    if (pts.length === 0) {
      tbody.innerHTML = `<tr><td colspan="5" style="text-align: center; color: var(--text-muted); padding: 20px;">버클링 데이터가 없습니다. 먼저 단면을 생성하거나 FSM 해석을 실행하세요.</td></tr>`;
      return;
    }

    pts.forEach((pt, idx) => {
      const tr = document.createElement('tr');
      const pcrKn = (pt.critical_load / 1000.0).toFixed(2);
      const mcrKnm = (pt.critical_moment / 1e6).toFixed(2);
      tr.innerHTML = `
        <td style="text-align: center;">${idx + 1}</td>
        <td>${pt.length.toFixed(1)}</td>
        <td style="font-weight: 600; color: var(--accent-primary);">${pt.load_factor.toFixed(4)}</td>
        <td>${pcrKn}</td>
        <td>${mcrKnm}</td>
      `;
      tbody.appendChild(tr);
    });
  }

  closeFsmDataModal() {
    document.getElementById('fsmDataModal').classList.remove('active');
  }

  exportFsmCsv() {
    const pts = this.getFsmPoints();
    if (pts.length === 0) {
      alert('내보낼 FSM 버클링 데이터가 없습니다.');
      return;
    }

    let csvContent = 'No,Half_Wavelength_L_mm,Load_Factor_Beta,Pcr_kN,Mcr_kNm\n';
    pts.forEach((pt, idx) => {
      const pcrKn = (pt.critical_load / 1000.0).toFixed(3);
      const mcrKnm = (pt.critical_moment / 1e6).toFixed(3);
      csvContent += `${idx + 1},${pt.length.toFixed(2)},${pt.load_factor.toFixed(5)},${pcrKn},${mcrKnm}\n`;
    });

    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.setAttribute('href', url);
    link.setAttribute('download', `CFDesigner_FSM_Signature_Curve_${Date.now()}.csv`);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  }

  // ================= Phase 3 / Phase 9: Winter Effective Width =================
  toggleEffectiveWidthToolbar() {
    if (this.canvas2d.showEffective) {
      // Already active -> Turn off
      this.resetEffectiveState();
    } else {
      // Inactive -> Open modal to compute and overlay
      this.openEffectiveModal();
    }
  }

  renderMathInEffectiveModal() {
    if (window.renderMathInElement) {
      const modal = document.getElementById('effectiveModal');
      if (modal) {
        window.renderMathInElement(modal, {
          delimiters: [
            { left: '$$', right: '$$', display: true },
            { left: '$', right: '$', display: false }
          ],
          ignoredClasses: ['form-input', 'form-select']
        });
      }
    }
    if (window.katex) {
      document.querySelectorAll('#effectiveModal .math-tex').forEach(el => {
        const tex = el.getAttribute('data-tex');
        if (tex) {
          try {
            window.katex.render(tex, el, { throwOnError: false });
          } catch (e) {
            console.error('KaTeX render error:', e);
          }
        }
      });
    }
  }

  openEffectiveModal() {
    document.getElementById('effectiveModal').classList.add('active');
    this.renderMathInEffectiveModal();
    this.computeEffectiveModalValues(false);
  }

  closeEffectiveModal() {
    document.getElementById('effectiveModal').classList.remove('active');
  }

  async computeEffectiveModalValues(applyToCanvas = false) {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const stressF = parseFloat(document.getElementById('effStressInput')?.value) || 345.0;
    const momentAxis = document.getElementById('effAxisSelect')?.value || 'X';
    const fy = parseFloat(document.getElementById('yieldStress')?.value) || 345.0;

    try {
      const res = await fetch('/api/section/effective', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          elements: this.currentGeometry.elements,
          thickness: this.currentGeometry.thickness,
          stress_f: stressF,
          fy: fy,
          moment_axis: momentAxis
        })
      });

      if (!res.ok) return;
      const data = await res.json();
      this.lastEffectiveData = data;
      this.lastEffectiveStress = stressF;

      // 1. Update only internal modal summary fields
      const elAe = document.getElementById('valAe');
      if (elAe) elAe.textContent = `${data.ae} mm² (Gross: ${data.ag} mm²)`;
      const elAeRatio = document.getElementById('valAeRatio');
      if (elAeRatio) elAeRatio.textContent = `${(data.area_ratio * 100.0).toFixed(1)}%`;
      const elIxe = document.getElementById('valIxe');
      if (elIxe) elIxe.textContent = `${data.ixe} mm⁴`;
      const elDeltaY = document.getElementById('valDeltaY');
      if (elDeltaY) elDeltaY.textContent = `${data.delta_y > 0 ? '+' : ''}${data.delta_y} mm`;

      if (applyToCanvas) {
        // 2. Apply to 2D Canvas & Right properties panel
        this.canvas2d.setEffectiveSegments(data.segments);
        this.canvas2d.toggleEffective(true);

        const btn = document.getElementById('btnToggleEffective');
        if (btn) btn.classList.add('active');

        // Update Right Dashboard Effective Properties Card
        const effCard = document.getElementById('cardEffectiveProps');
        if (effCard) {
          effCard.style.display = 'block';
          const tag = document.getElementById('effCardStressTag');
          if (tag) tag.textContent = `f = ${stressF} MPa (${momentAxis === 'X' ? '강축 휨' : (momentAxis === 'Y' ? '약축 휨' : '축압축')})`;
          const propAe = document.getElementById('propAe');
          if (propAe) propAe.textContent = data.ae;
          const propAeRatio = document.getElementById('propAeRatio');
          if (propAeRatio) propAeRatio.textContent = (data.area_ratio * 100.0).toFixed(1) + '%';
          const propIxe = document.getElementById('propIxe');
          if (propIxe) propIxe.textContent = data.ixe;
          const propDeltaY = document.getElementById('propDeltaY');
          if (propDeltaY) propDeltaY.textContent = (data.delta_y > 0 ? '+' : '') + data.delta_y;
        }

        this.closeEffectiveModal();
        this.showStatus(`유효단면 2D 오버레이 적용 완료 (Ae = ${data.ae} mm²)`, 'success', 3000);
      }
    } catch (err) {
      console.error('Compute effective width error:', err);
    }
  }

  applyEffectiveOverlayToCanvas() {
    this.computeEffectiveModalValues(true);
  }

  resetEffectiveState() {
    if (this.canvas2d) {
      this.canvas2d.toggleEffective(false);
      this.canvas2d.setEffectiveSegments([]);
    }
    const btn = document.getElementById('btnToggleEffective');
    if (btn) btn.classList.remove('active');
    const effCard = document.getElementById('cardEffectiveProps');
    if (effCard) effCard.style.display = 'none';
    this.lastEffectiveData = null;
  }

  // ================= Phase 4: 1D Frame & Beam Analysis Methods =================
  openFrameAnalysisModal() {
    const modal = document.getElementById('frameAnalysisModal');
    modal.classList.add('active');
    this.renderFrameSpanTable();
    this.renderFrameLoadTable();
    this.executeFrameAnalysis();
  }

  closeFrameAnalysisModal() {
    document.getElementById('frameAnalysisModal').classList.remove('active');
  }

  loadFramePreset(presetName) {
    if (presetName === 'simple') {
      this.frameSpans = [{ length: 4000.0, left_sup: 'pin', right_sup: 'roller' }];
      this.frameLoads = [{ load_type: 'udl', magnitude: 10.0, x_start: 0.0, x_end: 4000.0 }];
    } else if (presetName === 'cont2') {
      this.frameSpans = [
        { length: 3000.0, left_sup: 'pin', right_sup: 'roller' },
        { length: 3000.0, left_sup: 'roller', right_sup: 'roller' }
      ];
      this.frameLoads = [{ load_type: 'udl', magnitude: 10.0, x_start: 0.0, x_end: 6000.0 }];
    } else if (presetName === 'cont3') {
      this.frameSpans = [
        { length: 3000.0, left_sup: 'pin', right_sup: 'roller' },
        { length: 3000.0, left_sup: 'roller', right_sup: 'roller' },
        { length: 3000.0, left_sup: 'roller', right_sup: 'roller' }
      ];
      this.frameLoads = [{ load_type: 'udl', magnitude: 12.0, x_start: 0.0, x_end: 9000.0 }];
    } else if (presetName === 'cantilever') {
      this.frameSpans = [{ length: 2500.0, left_sup: 'fixed', right_sup: 'free' }];
      this.frameLoads = [
        { load_type: 'udl', magnitude: 5.0, x_start: 0.0, x_end: 2500.0 },
        { load_type: 'point', magnitude: 15.0, x_start: 2500.0, x_end: 2500.0 }
      ];
    }
    this.renderFrameSpanTable();
    this.renderFrameLoadTable();
    this.executeFrameAnalysis();
  }

  renderFrameSpanTable() {
    const tbody = document.getElementById('frameSpanTableBody');
    tbody.innerHTML = '';

    this.frameSpans.forEach((sp, idx) => {
      const tr = document.createElement('tr');
      tr.innerHTML = `
        <td style="text-align: center; font-weight: 600;">Span ${idx + 1}</td>
        <td>
          <input type="number" class="span-len-input form-control" data-idx="${idx}" value="${sp.length}" step="100" style="padding: 2px 4px; font-size: 11px; width: 75px;">
        </td>
        <td>
          <select class="span-left-sup form-control" data-idx="${idx}" style="padding: 2px; font-size: 11px;">
            <option value="pin" ${sp.left_sup === 'pin' ? 'selected' : ''}>Pin (힌지)</option>
            <option value="roller" ${sp.left_sup === 'roller' ? 'selected' : ''}>Roller (롤러)</option>
            <option value="fixed" ${sp.left_sup === 'fixed' ? 'selected' : ''}>Fixed (고정)</option>
            <option value="free" ${sp.left_sup === 'free' ? 'selected' : ''}>Free (자유)</option>
          </select>
        </td>
        <td>
          <select class="span-right-sup form-control" data-idx="${idx}" style="padding: 2px; font-size: 11px;">
            <option value="roller" ${sp.right_sup === 'roller' ? 'selected' : ''}>Roller (롤러)</option>
            <option value="pin" ${sp.right_sup === 'pin' ? 'selected' : ''}>Pin (힌지)</option>
            <option value="fixed" ${sp.right_sup === 'fixed' ? 'selected' : ''}>Fixed (고정)</option>
            <option value="free" ${sp.right_sup === 'free' ? 'selected' : ''}>Free (자유)</option>
          </select>
        </td>
      `;
      tbody.appendChild(tr);
    });

    // Bind change events
    tbody.querySelectorAll('.span-len-input').forEach(inp => {
      inp.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameSpans[idx].length = parseFloat(e.target.value) || 3000;
      });
    });
    tbody.querySelectorAll('.span-left-sup').forEach(sel => {
      sel.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameSpans[idx].left_sup = e.target.value;
      });
    });
    tbody.querySelectorAll('.span-right-sup').forEach(sel => {
      sel.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameSpans[idx].right_sup = e.target.value;
      });
    });
  }

  renderFrameLoadTable() {
    const tbody = document.getElementById('frameLoadTableBody');
    tbody.innerHTML = '';

    this.frameLoads.forEach((ld, idx) => {
      const tr = document.createElement('tr');
      tr.innerHTML = `
        <td>
          <select class="load-type-sel form-control" data-idx="${idx}" style="padding: 2px; font-size: 11px;">
            <option value="udl" ${ld.load_type === 'udl' ? 'selected' : ''}>등분포 (UDL)</option>
            <option value="point" ${ld.load_type === 'point' ? 'selected' : ''}>집중 (Point)</option>
          </select>
        </td>
        <td>
          <input type="number" class="load-mag-inp form-control" data-idx="${idx}" value="${ld.magnitude}" step="1" style="padding: 2px 4px; font-size: 11px; width: 60px;">
        </td>
        <td>
          <input type="number" class="load-xs-inp form-control" data-idx="${idx}" value="${ld.x_start}" step="100" style="padding: 2px 4px; font-size: 11px; width: 60px;">
        </td>
        <td>
          <input type="number" class="load-xe-inp form-control" data-idx="${idx}" value="${ld.x_end}" step="100" style="padding: 2px 4px; font-size: 11px; width: 60px;">
        </td>
        <td style="text-align: center;">
          <button class="btn btn-outline btn-del-load" data-idx="${idx}" style="padding: 1px 5px; font-size: 10px; color: var(--accent-danger);">✕</button>
        </td>
      `;
      tbody.appendChild(tr);
    });

    tbody.querySelectorAll('.load-type-sel').forEach(sel => {
      sel.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameLoads[idx].load_type = e.target.value;
      });
    });
    tbody.querySelectorAll('.load-mag-inp').forEach(inp => {
      inp.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameLoads[idx].magnitude = parseFloat(e.target.value) || 0;
      });
    });
    tbody.querySelectorAll('.load-xs-inp').forEach(inp => {
      inp.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameLoads[idx].x_start = parseFloat(e.target.value) || 0;
      });
    });
    tbody.querySelectorAll('.load-xe-inp').forEach(inp => {
      inp.addEventListener('change', (e) => {
        const idx = parseInt(e.target.dataset.idx);
        this.frameLoads[idx].x_end = parseFloat(e.target.value) || 0;
      });
    });
    tbody.querySelectorAll('.btn-del-load').forEach(btn => {
      btn.addEventListener('click', (e) => {
        const idx = parseInt(e.currentTarget.dataset.idx);
        this.frameLoads.splice(idx, 1);
        this.renderFrameLoadTable();
      });
    });
  }

  addFrameLoadRow() {
    let totLen = 0;
    this.frameSpans.forEach(s => totLen += (s.length || 3000));
    this.frameLoads.push({
      load_type: 'point',
      magnitude: 20.0,
      x_start: totLen / 2.0,
      x_end: totLen / 2.0
    });
    this.renderFrameLoadTable();
  }

  async executeFrameAnalysis() {
    const btn = document.getElementById('btnExecuteFrameAnalysis');
    btn.disabled = true;
    btn.textContent = '⏳ FEM 매트릭스 연산 중...';

    // Calculate supports list from spans
    const supports = [];
    let curX = 0;
    this.frameSpans.forEach((sp, idx) => {
      if (idx === 0) {
        if (sp.left_sup !== 'free') supports.push({ location: 0, type: sp.left_sup });
      }
      curX += sp.length;
      if (sp.right_sup !== 'free') {
        supports.push({ location: curX, type: sp.right_sup });
      }
    });

    const ix = (this.currentProperties && this.currentProperties.ixx) ? this.currentProperties.ixx : 2.5e6;
    const area = (this.currentProperties && this.currentProperties.area) ? this.currentProperties.area : 500;
    const includeSelfWeight = document.getElementById('frameSelfWeightCheck').checked;
    const selfWeightW = (includeSelfWeight && this.currentProperties && this.currentProperties.weight)
      ? (this.currentProperties.weight * 9.80665 / 1000.0) // kg/m -> kN/m
      : 0.0;

    try {
      const res = await fetch('/api/analysis/run', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          spans: this.frameSpans.map(s => ({ length: s.length, ix: ix, area: area, e_mod: 205000 })),
          supports: supports,
          loads: this.frameLoads,
          ix: ix,
          area: area,
          self_weight_w: selfWeightW,
          num_eval_points: 150
        })
      });

      const data = await res.json();
      this.lastFrameResult = data;

      // Update Summary Cards
      const mf = data.max_forces;
      document.getElementById('diagMaxM').textContent = `${mf.mux_max} kN·m (부: ${mf.mux_min})`;
      document.getElementById('diagMaxV').textContent = `${mf.vu_max} kN`;
      document.getElementById('diagMaxDefl').textContent = `${mf.defl_max} mm`;
      document.getElementById('diagDeflRatio').textContent = mf.defl_span_ratio;

      // Render 4-Stack Diagrams
      this.diagramViewer.renderAll(data, this.frameLoads, supports);

    } catch (err) {
      console.error('Frame analysis error:', err);
      alert('1D 구조해석 중 오류가 발생했습니다.');
    } finally {
      btn.disabled = false;
      btn.textContent = '⚡ 1D 구조해석 실행 (Solve FEM)';
    }
  }

  async transferFrameResultToDesign() {
    if (!this.lastFrameResult || !this.lastFrameResult.max_forces) {
      alert('먼저 1D 구조해석을 실행하세요.');
      return;
    }

    const mf = this.lastFrameResult.max_forces;
    const pu = mf.pu_max || 0;
    const mux = mf.mux_max || 0;
    const vu = mf.vu_max || 0;

    // Inject values directly into Member Check UI Form
    const inpPu = document.getElementById('loadPu');
    const inpMux = document.getElementById('loadMux');
    const inpVu = document.getElementById('loadVu');
    const inpL = document.getElementById('unbracedLength');

    if (inpPu) inpPu.value = pu;
    if (inpMux) inpMux.value = mux;
    if (inpVu) {
      inpVu.value = vu;
      const cripRu = document.getElementById('cripRuInput');
      if (cripRu) cripRu.value = vu;
    }
    if (inpL && this.frameSpans[0]) inpL.value = this.frameSpans[0].length;

    // Switch to Member Check Tab and Run Check
    const tabMemberBtn = document.querySelector('[data-target="tabMember"]');
    if (tabMemberBtn) tabMemberBtn.click();

    this.closeFrameAnalysisModal();
    await this.runDesignCheck();

    alert(`✅ 구조해석 최대 부재력이 부재설계(Member Check) 및 웨브크리플링으로 연동되었습니다!\n• Mux = ${mux} kN·m\n• Vu = ${vu} kN (소요반력 Ru = ${vu} kN)\n• Pu = ${pu} kN`);
  }

  // =========================================================
  // Phase 7 & 11: Calculation Report & Trace Viewer Methods
  // =========================================================
  openReportModal() {
    const modal = document.getElementById('reportModal');
    if (modal) {
      modal.classList.add('active');
      this.refreshReport();
    }
  }

  closeReportModal() {
    const modal = document.getElementById('reportModal');
    if (modal) {
      modal.classList.remove('active');
    }
  }

  toggleAllTraceDetails() {
    const iframe = document.getElementById('reportViewerFrame');
    if (!iframe || !iframe.contentDocument) return;

    const doc = iframe.contentDocument;
    const accordions = doc.querySelectorAll('details.trace-accordion');
    if (!accordions || accordions.length === 0) return;

    // If at least one is closed, open all. Otherwise, close all.
    const anyClosed = Array.from(accordions).some(acc => !acc.open);
    accordions.forEach(acc => {
      acc.open = anyClosed;
    });

    const btn = document.getElementById('btnToggleAllTrace');
    if (btn) {
      btn.textContent = anyClosed ? '📁 수식 전체 접기' : '📂 수식 전체 펼치기';
    }
  }

  async refreshReport() {
    const iframe = document.getElementById('reportViewerFrame');
    if (!iframe) return;

    this.showStatus('📑 구조계산서 및 수식 전개(Trace) 생성 중...', 'busy');

    const mode = this.reportMode || 'detailed';
    const opts = {
      report_mode: mode,
      include_section_inputs: document.getElementById('chkReportSectionInputs')?.checked ?? true,
      include_gross_properties: document.getElementById('chkReportGrossProps')?.checked ?? true,
      include_torsion_properties: document.getElementById('chkReportTorsionProps')?.checked ?? true,
      include_effective_properties: document.getElementById('chkReportEffectiveProps')?.checked ?? true,
      include_fully_braced_strength: document.getElementById('chkReportFullyBraced')?.checked ?? true,
      include_fsm_buckling: document.getElementById('chkReportFsmBuckling')?.checked ?? true,
      include_member_design: document.getElementById('chkReportMemberDesign')?.checked ?? true,
      include_web_crippling: document.getElementById('chkReportWebCrippling')?.checked ?? true,
      include_1d_analysis: document.getElementById('chkReport1dAnalysis')?.checked ?? false,
      include_trace_details: document.getElementById('chkReportTraceDetails')?.checked ?? true,
      unit_system: 'SI'
    };

    const payload = {
      section_name: this.currentSectionName || 'CFS Custom Section',
      project_name: 'Cold-Formed Steel Structure Design Project',
      metadata: {
        project_name: 'CFDesigner Engineering Project',
        section_name: this.currentSectionName || 'CFS-C150',
        doc_number: 'CALC-CFS-001',
        company: 'Structural Engineering & Design Corp.',
        designed_by: 'Structural Engineer',
        checked_by: 'Senior PE',
        approved_by: 'Lead SE',
        remarks: 'Cold-Formed Steel Design per KDS 14 31 10:2017 & AISI S100-16 DSM'
      },
      options: opts,
      geometry: this.currentGeometry || { elements: [] },
      properties: this.currentProperties || {},
      material: this.currentMaterial || { fy: 275.0, fu: 410.0, e: 205000.0, name: 'SS275' },
      fsm: this.currentFsmResult || this.lastFsmResult || {},
      design: this.currentDesignResult || this.lastDesignResult || {},
      loads: {
        pu: parseFloat(document.getElementById('loadPu')?.value) || 0,
        mux: parseFloat(document.getElementById('loadMux')?.value) || 0,
        muy: parseFloat(document.getElementById('loadMuy')?.value) || 0,
        vu: parseFloat(document.getElementById('loadVu')?.value) || 0,
        ru: parseFloat(document.getElementById('cripRuInput')?.value) || 0
      },
      analysis_1d: this.lastFrameResult || {}
    };

    try {
      const res = await fetch('/api/report/html', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });

      if (!res.ok) {
        throw new Error(`Report API Error: ${res.statusText}`);
      }

      const data = await res.json();
      const html = data.html || '';

      // Load into iframe
      iframe.srcdoc = html;
      this.showStatus('✅ 구조계산서 렌더링 완료', 'ready', 2000);

    } catch (err) {
      console.error('Report Generation Error:', err);
      this.showStatus('❌ 구조계산서 생성 오류', 'warning', 3000);
    }
  }
}

// ---------------------------------------------------------
// Apply Feature Mixins to CFDesignerApp.prototype
// Mixin methods override legacy method bodies defined in this file.
// ---------------------------------------------------------
applySectionEditorMixin(CFDesignerApp);
applyLibraryBrowserMixin(CFDesignerApp);
applyMaterialManagerMixin(CFDesignerApp);
applyQuickDesignMixin(CFDesignerApp);
applyFsmToolsMixin(CFDesignerApp);
applyEffectiveWidthMixin(CFDesignerApp);
applyFrameAnalysisMixin(CFDesignerApp);
applyReportViewerMixin(CFDesignerApp);

// Instantiate on DOM Load
window.addEventListener('DOMContentLoaded', () => {
  window.app = new CFDesignerApp();
});


