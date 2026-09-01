/**
 * CFDesigner Main Application Controller
 * Handles user interactions, API synchronization, 2D/3D viewers, and report generation.
 */

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
          this.showStatus(cancelMessage, 'busy');
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
    this.fsmChart = new FSMSignatureChart('fsmChartCanvas', (lVal, pVal) => {
      console.log(`Selected Wavelength L: ${lVal} mm, Pcr: ${pVal} kN`);
    });
    this.diagramViewer = new FrameDiagramViewer('canvasBeamModel', 'canvasSfd', 'canvasBmd', 'canvasDefl');

    // 2. Bind DOM Events
    this.bindEvents();

    // 3. Load Initial C-Section
    this.runWizard();
  }

  bindEvents() {
    // Theme Toggle
    document.getElementById('btnThemeToggle').addEventListener('click', () => {
      const isLight = document.body.getAttribute('data-theme') === 'light';
      document.body.setAttribute('data-theme', isLight ? 'dark' : 'light');
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

    // 3D Mode Selector Buttons
    document.querySelectorAll('.btn-mode-select').forEach(btn => {
      btn.addEventListener('click', () => {
        document.querySelectorAll('.btn-mode-select').forEach(b => b.classList.remove('btn-primary'));
        btn.classList.add('btn-primary');
        const modeKey = btn.getAttribute('data-mode-key');
        this.viewer3d.setMode(modeKey);
      });
    });

    // Amplitude Slider
    const ampSlider = document.getElementById('ampSlider');
    if (ampSlider) {
      ampSlider.addEventListener('input', (e) => {
        this.viewer3d.amplitude = parseFloat(e.target.value);
        this.viewer3d.buildGeometry();
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

    // Phase 3: Winter Effective Width Overlay Events
    const btnToggleEff = document.getElementById('btnToggleEffective');
    if (btnToggleEff) btnToggleEff.addEventListener('click', () => this.toggleEffectiveWidth());
    const btnCloseEff = document.getElementById('btnCloseEffectiveModal');
    if (btnCloseEff) btnCloseEff.addEventListener('click', () => this.closeEffectiveModal());
    const btnComputeEff = document.getElementById('btnComputeEffective');
    if (btnComputeEff) btnComputeEff.addEventListener('click', () => this.computeEffectiveWidth());

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

    document.getElementById('btnOpenReport').addEventListener('click', () => this.openReportModal());
    document.getElementById('btnCloseReport').addEventListener('click', () => this.closeReportModal());
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
    }
  }

  async uploadDXF(file) {
    const t = parseFloat(document.getElementById('wizT').value) || 2.0;
    const formData = new FormData();
    formData.append('file', file);
    formData.append('default_thickness', t);
    formData.append('unit', 'mm');

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

    // 1. Update 2D Canvas immediately
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);

    // 2. Update Properties Table immediately
    this.renderPropertiesTable(this.currentProperties);

    // 3. Trigger FSM Buckling Analysis & Design Check asynchronously with debouncing
    this.runFSM();
    this.runDesignCheck();
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

      this.showStatus('🔬 FSM 탄성 좌굴해석 연산 중 (35개 스윕)...', 'busy');
      const signal = this.getAbortSignal('fsm', '이전 FSM 연산 취소 후 최신 단면 재해석 중...');

      try {
        const res = await fetch('/api/fsm/solve', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            elements: this.currentGeometry.elements,
            thickness: this.currentGeometry.thickness,
            yield_stress: fy,
            member_length: lMem,
            num_points: 35
          }),
          signal: signal
        });
        if (!res.ok) return;
        const data = await res.json();
        this.currentFsmResult = data;

        // Update FSM Signature Chart
        this.fsmChart.updateData(data.signature_curve);

        // Update 3D Viewer Mesh & Modes
        this.viewer3d.setData(data.nodes, data.strips, 'local_mode');

        // Update FSM Key Indicator Labels
        const modes = data.critical_modes;
        document.getElementById('valPcrl').innerText = `${modes.p_crl} kN (${modes.l_local} mm)`;
        document.getElementById('valPcrd').innerText = `${modes.p_crd} kN (${modes.l_distortional} mm)`;
        document.getElementById('valPcre').innerText = `${modes.p_cre} kN (${modes.l_global} mm)`;

        const elapsed = ((performance.now() - startTime) / 1000).toFixed(2);
        this.showStatus(`✅ 해석 및 부재설계 완료 (${elapsed}s)`, 'success', 3500);
      } catch (err) {
        if (err.name === 'AbortError') return;
        console.error('FSM solve error:', err);
        this.showStatus('FSM 좌굴해석 실패', 'warning', 3000);
      }
    }, 50);
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
  }

  async openReportModal() {
    if (!this.currentGeometry || !this.currentProperties) return;

    const shape = document.getElementById('wizardShape').value;
    const pu = parseFloat(document.getElementById('loadPu').value) || 50;
    const mux = parseFloat(document.getElementById('loadMux').value) || 5.0;
    const vu = parseFloat(document.getElementById('loadVu').value) || 15.0;

    const payload = {
      section_name: `CFS-${shape.toUpperCase()}-${document.getElementById('wizH').value}x${document.getElementById('wizB').value}x${document.getElementById('wizT').value}`,
      project_name: "CFDesigner 구조계산서",
      geometry: this.currentGeometry,
      properties: this.currentProperties,
      fsm: this.currentFsmResult ? this.currentFsmResult.critical_modes : {},
      design: this.currentDesignResult || {},
      loads: { pu, mux, vu }
    };

    try {
      const res = await fetch('/api/report/html', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      const data = await res.json();

      const iframe = document.getElementById('reportIframe');
      iframe.srcdoc = data.html;

      document.getElementById('reportModal').classList.add('active');
    } catch (err) {
      console.error('Report generation error:', err);
    }
  }

  closeReportModal() {
    document.getElementById('reportModal').classList.remove('active');
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
    btn.textContent = '⏳ 최적 단면 탐색 중...';

    const pu = parseFloat(document.getElementById('qdPu').value) || 0.0;
    const mux = parseFloat(document.getElementById('qdMux').value) || 0.0;
    const vu = parseFloat(document.getElementById('qdVu').value) || 0.0;
    const length = parseFloat(document.getElementById('qdLength').value) || 3000.0;
    const maxH = parseFloat(document.getElementById('qdMaxH').value) || null;
    const maxW = parseFloat(document.getElementById('qdMaxW').value) || null;
    const lib = document.getElementById('qdLibrarySelect').value || null;
    const fy = parseFloat(document.getElementById('yieldStress').value) || 345.0;

    try {
      const res = await fetch('/api/design/quick-design', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          pu: pu,
          mux: mux,
          vu: vu,
          length: length,
          fy: fy,
          max_depth: maxH,
          max_weight: maxW,
          library: lib,
          max_results: 15
        })
      });

      const data = await res.json();
      this.quickDesignCandidates = data.candidates || [];
      document.getElementById('qdResultCount').textContent = data.total_passed || 0;

      const tbody = document.getElementById('quickDesignTableBody');
      tbody.innerHTML = '';

      if (this.quickDesignCandidates.length === 0) {
        tbody.innerHTML = `<tr><td colspan="11" style="text-align:center; color: var(--accent-warning); padding: 20px;">조건을 만족하는 단면이 없습니다. 하중이나 제약조건을 완화해 보세요.</td></tr>`;
        return;
      }

      this.quickDesignCandidates.forEach((cand, idx) => {
        const tr = document.createElement('tr');
        const rankBadge = cand.rank === 1 ? '🥇 1' : (cand.rank === 2 ? '🥈 2' : (cand.rank === 3 ? '🥉 3' : cand.rank));
        const savingsBadge = cand.weight_savings_pct > 0 ? `<span style="color: var(--accent-success); font-weight: 600;">-${cand.weight_savings_pct}%</span>` : '-';
        
        tr.innerHTML = `
          <td style="text-align: center; font-weight: 600;">${rankBadge}</td>
          <td style="font-weight: 600; color: var(--accent-primary);">${cand.name}</td>
          <td><span class="brand-badge">${cand.library_name}</span></td>
          <td><strong>${cand.weight}</strong> kg/m</td>
          <td style="font-size: 11px;">${cand.depth} × ${cand.flange} × ${cand.thickness}</td>
          <td>${cand.dc_axial}</td>
          <td>${cand.dc_flexure}</td>
          <td>${cand.dc_combined}</td>
          <td style="font-weight: 600; color: ${cand.max_dc <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)'};">${cand.max_dc}</td>
          <td>${savingsBadge}</td>
          <td>
            <button class="btn btn-outline" onclick="window.app.applyQuickDesignCandidate(${idx})" style="padding: 3px 8px; font-size: 11px; width: 100%;">
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
      btn.textContent = '⚡ 최적 경량 단면 자동 탐색 실행 (Find Lightest Sections)';
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
      this.updateSectionData({ geometry: geometry });
      this.closeQuickDesignModal();
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
      this.chartFsm.updateData(data.curve.lengths, data.curve.load_factors);

      document.getElementById('valPcrl').innerText = `${(data.modes.p_crl / 1000.0).toFixed(1)} kN`;
      document.getElementById('valPcrd').innerText = `${(data.modes.p_crd / 1000.0).toFixed(1)} kN`;
      document.getElementById('valPcre').innerText = `${(data.modes.p_cre / 1000.0).toFixed(1)} kN`;

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
      tbody.innerHTML = `<tr><td colspan="5" style="text-align: center; color: var(--text-muted); padding: 20px;">좌굴 데이터가 없습니다. 먼저 단면을 생성하거나 FSM 해석을 실행하세요.</td></tr>`;
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
      alert('내보낼 FSM 좌굴 데이터가 없습니다.');
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

  // ================= Phase 3: Winter Effective Width =================
  async toggleEffectiveWidth() {
    if (!this.canvas2d.showEffective) {
      // Open modal to configure stress or directly compute
      this.openEffectiveModal();
    } else {
      this.canvas2d.toggleEffective(false);
      const btn = document.getElementById('btnToggleEffective');
      if (btn) btn.classList.remove('active');
    }
  }

  openEffectiveModal() {
    document.getElementById('effectiveModal').classList.add('active');
    this.computeEffectiveWidth();
  }

  closeEffectiveModal() {
    document.getElementById('effectiveModal').classList.remove('active');
  }

  async computeEffectiveWidth() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const stressF = parseFloat(document.getElementById('effStressInput').value) || 345.0;
    const momentAxis = document.getElementById('effAxisSelect').value || 'X';
    const fy = parseFloat(document.getElementById('yieldStress').value) || 345.0;

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

      const data = await res.json();
      document.getElementById('valAe').textContent = `${data.ae} mm² (Gross: ${data.ag} mm²)`;
      document.getElementById('valAeRatio').textContent = `${(data.area_ratio * 100.0).toFixed(1)}%`;
      document.getElementById('valIxe').textContent = `${data.ixe} mm⁴`;
      document.getElementById('valDeltaY').textContent = `${data.delta_y > 0 ? '+' : ''}${data.delta_y} mm`;

      // Set segments in Canvas2D and enable overlay
      this.canvas2d.setEffectiveSegments(data.segments);
      this.canvas2d.toggleEffective(true);

      const btn = document.getElementById('btnToggleEffective');
      if (btn) btn.classList.add('active');
    } catch (err) {
      console.error('Compute effective width error:', err);
    }
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
    if (inpVu) inpVu.value = vu;
    if (inpL && this.frameSpans[0]) inpL.value = this.frameSpans[0].length;

    // Switch to Member Check Tab and Run Check
    const tabMemberBtn = document.querySelector('[data-target="tabMember"]');
    if (tabMemberBtn) tabMemberBtn.click();

    this.closeFrameAnalysisModal();
    await this.runDesignCheck();

    alert(`✅ 구조해석 최대 부재력이 부재설계(Member Check)로 연동되었습니다!\n• Mux = ${mux} kN·m\n• Vu = ${vu} kN\n• Pu = ${pu} kN`);
  }
}

// Instantiate on DOM Load
window.addEventListener('DOMContentLoaded', () => {
  window.app = new CFDesignerApp();
});

