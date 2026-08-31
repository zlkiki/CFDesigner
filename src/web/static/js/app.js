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

    // Report Modal
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
}

// Instantiate on DOM Load
window.addEventListener('DOMContentLoaded', () => {
  window.app = new CFDesignerApp();
});
