/**
 * FSM Tools Module: Web Crippling, FSM Parameters, FSM Data Table & CSV Export
 * Extends CFDesignerApp with Phase 3 advanced FSM/design tool methods.
 */

export function applyFsmToolsMixin(AppClass) {

  // ================= Phase 3: Web Crippling Detailed =================

  AppClass.prototype.calculateWebCrippling = async function() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

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
        body: JSON.stringify({ h: hw, t, r, n_bearing: nBearing, fy, condition: cond, fastened, stiffened, theta_deg: 90.0, ru })
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
  };

  // ================= Phase 3: FSM Parameters & Custom Sweep =================

  AppClass.prototype.openFsmParamsModal = function() {
    document.getElementById('fsmParamsModal').classList.add('active');
  };

  AppClass.prototype.closeFsmParamsModal = function() {
    document.getElementById('fsmParamsModal').classList.remove('active');
  };

  AppClass.prototype.applyFsmCustomParams = async function() {
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
          l_min: lMin, l_max: lMax, steps: steps,
          load_type: stressType, yield_stress: fy,
          elastic_modulus: 205000.0, poisson_ratio: 0.3,
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

      try { if (this.fsmChart) this.fsmChart.updateData(pts, modes.load_type); } catch (cErr) { console.error('Chart update error:', cErr); }

      const activeModeKey = this.currentFsmModeKey || 'local_mode';
      const activeModeIdx = this.currentFsmModeIndex || 1;
      try { if (this.viewer3d) this.viewer3d.setData(this.lastFsmNodes, this.lastFsmStrips, activeModeKey); } catch (vErr) { console.error('3D Viewer update error:', vErr); }
      try {
        if (this.canvas2d) {
          this.canvas2d.fsmModeIndex = activeModeIdx;
          this.canvas2d.setFsmModeData(this.lastFsmNodes, this.lastFsmStrips, activeModeKey, this.viewer3d ? this.viewer3d.amplitude : 15.0);
        }
      } catch (c2dErr) { console.error('2D Canvas update error:', c2dErr); }
      try { this.update3dOverlayInfo(activeModeKey, activeModeIdx); } catch (ovErr) { console.error('Overlay Info update error:', ovErr); }

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
  };

  // ================= Phase 3: FSM Numerical Data Table & CSV =================

  AppClass.prototype.getFsmPoints = function() {
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
        pts.push({ length: lens[i], load_factor: lf, critical_load: lf * py, critical_moment: lf * my });
      }
      return pts;
    }
    return [];
  };

  AppClass.prototype.openFsmDataModal = function() {
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
  };

  AppClass.prototype.closeFsmDataModal = function() {
    document.getElementById('fsmDataModal').classList.remove('active');
  };

  AppClass.prototype.exportFsmCsv = function() {
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
  };
}
