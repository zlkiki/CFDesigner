/**
 * CFDesigner Main Application Controller
 * Handles user interactions, API synchronization, 2D/3D viewers, and report generation.
 */

class CFDesignerApp {
  constructor() {
    this.canvas2d = null;
    this.viewer3d = null;
    this.fsmChart = null;

    this.currentGeometry = null;
    this.currentProperties = null;
    this.currentFsmResult = null;
    this.currentDesignResult = null;

    this.activeViewerTab = '2d'; // '2d' or '3d'

    this.init();
  }

  init() {
    // 1. Initialize Viewers
    this.canvas2d = new SectionCanvas2D('canvas2d');
    this.viewer3d = new BucklingViewer3D('viewer3dContainer');
    this.fsmChart = new FSMSignatureChart('fsmChartCanvas', (lVal, pVal) => {
      console.log(`Selected Wavelength L: ${lVal} mm, Pcr: ${pVal} kN`);
    });

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

    try {
      const res = await fetch('/api/section/wizard', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ shape_type: shape, h, b, c, t, r })
      });
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      console.error('Wizard API error:', err);
    }
  }

  async uploadDXF(file) {
    const t = parseFloat(document.getElementById('wizT').value) || 2.0;
    const formData = new FormData();
    formData.append('file', file);
    formData.append('default_thickness', t);
    formData.append('unit', 'mm');

    try {
      const res = await fetch('/api/section/upload-dxf', {
        method: 'POST',
        body: formData
      });
      if (!res.ok) {
        alert('DXF 파싱 실패: ' + (await res.json()).detail);
        return;
      }
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      console.error('DXF Upload Error:', err);
    }
  }

  updateSectionData(data) {
    this.currentGeometry = data.geometry;
    this.currentProperties = data.properties;

    // 1. Update 2D Canvas
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);

    // 2. Update Properties Table
    this.renderPropertiesTable(this.currentProperties);

    // 3. Trigger FSM Buckling Analysis & Design Check
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

    const fy = parseFloat(document.getElementById('yieldStress').value) || 345;
    const lMem = parseFloat(document.getElementById('memberLength').value) || 3000;

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
        })
      });
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
    } catch (err) {
      console.error('FSM solve error:', err);
    }
  }

  async runDesignCheck() {
    if (!this.currentGeometry) return;

    const fy = parseFloat(document.getElementById('yieldStress').value) || 345;
    const lMem = parseFloat(document.getElementById('memberLength').value) || 3000;
    const pu = parseFloat(document.getElementById('loadPu').value) || 50;
    const mux = parseFloat(document.getElementById('loadMux').value) || 5.0;
    const vu = parseFloat(document.getElementById('loadVu').value) || 15.0;

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
        })
      });
      const data = await res.json();
      this.currentDesignResult = data;
      this.renderDesignDashboard(data);
      this.calculateWebCrippling();
    } catch (err) {
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
  async transformSection(transformType, angleDeg = 0) {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const payload = {
      elements: this.currentGeometry.elements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: transformType,
      angle_deg: angleDeg,
      center_at_cg: true
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      console.error('Transform error:', err);
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

    const payload = {
      elements: this.currentGeometry.elements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: 'rotate_angle',
      angle_deg: angle,
      center_at_cg: centerCg
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      const data = await res.json();
      this.updateSectionData(data);
      this.closeRotateModal();
    } catch (err) {
      console.error('Rotate submit error:', err);
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
}

// Instantiate on DOM Load
window.addEventListener('DOMContentLoaded', () => {
  window.app = new CFDesignerApp();
});
