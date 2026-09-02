/**
 * Frame Analysis Module: 1D Frame & Beam FEM Analysis Modal
 * Extends CFDesignerApp with Phase 4 structural analysis methods.
 */

export function applyFrameAnalysisMixin(AppClass) {

  AppClass.prototype.openFrameAnalysisModal = function() {
    const modal = document.getElementById('frameAnalysisModal');
    modal.classList.add('active');
    this.renderFrameSpanTable();
    this.renderFrameLoadTable();
    this.executeFrameAnalysis();
  };

  AppClass.prototype.closeFrameAnalysisModal = function() {
    document.getElementById('frameAnalysisModal').classList.remove('active');
  };

  AppClass.prototype.loadFramePreset = function(presetName) {
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
  };

  AppClass.prototype.renderFrameSpanTable = function() {
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
  };

  AppClass.prototype.renderFrameLoadTable = function() {
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
      sel.addEventListener('change', (e) => { const idx = parseInt(e.target.dataset.idx); this.frameLoads[idx].load_type = e.target.value; });
    });
    tbody.querySelectorAll('.load-mag-inp').forEach(inp => {
      inp.addEventListener('change', (e) => { const idx = parseInt(e.target.dataset.idx); this.frameLoads[idx].magnitude = parseFloat(e.target.value) || 0; });
    });
    tbody.querySelectorAll('.load-xs-inp').forEach(inp => {
      inp.addEventListener('change', (e) => { const idx = parseInt(e.target.dataset.idx); this.frameLoads[idx].x_start = parseFloat(e.target.value) || 0; });
    });
    tbody.querySelectorAll('.load-xe-inp').forEach(inp => {
      inp.addEventListener('change', (e) => { const idx = parseInt(e.target.dataset.idx); this.frameLoads[idx].x_end = parseFloat(e.target.value) || 0; });
    });
    tbody.querySelectorAll('.btn-del-load').forEach(btn => {
      btn.addEventListener('click', (e) => {
        const idx = parseInt(e.currentTarget.dataset.idx);
        this.frameLoads.splice(idx, 1);
        this.renderFrameLoadTable();
      });
    });
  };

  AppClass.prototype.addFrameLoadRow = function() {
    let totLen = 0;
    this.frameSpans.forEach(s => totLen += (s.length || 3000));
    this.frameLoads.push({ load_type: 'point', magnitude: 20.0, x_start: totLen / 2.0, x_end: totLen / 2.0 });
    this.renderFrameLoadTable();
  };

  AppClass.prototype.executeFrameAnalysis = async function() {
    const btn = document.getElementById('btnExecuteFrameAnalysis');
    btn.disabled = true;
    btn.textContent = '⏳ FEM 매트릭스 연산 중...';

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
      ? (this.currentProperties.weight * 9.80665 / 1000.0)
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

      const mf = data.max_forces;
      document.getElementById('diagMaxM').textContent = `${mf.mux_max} kN·m (부: ${mf.mux_min})`;
      document.getElementById('diagMaxV').textContent = `${mf.vu_max} kN`;
      document.getElementById('diagMaxDefl').textContent = `${mf.defl_max} mm`;
      document.getElementById('diagDeflRatio').textContent = mf.defl_span_ratio;

      this.diagramViewer.renderAll(data, this.frameLoads, supports);

    } catch (err) {
      console.error('Frame analysis error:', err);
      alert('1D 구조해석 중 오류가 발생했습니다.');
    } finally {
      btn.disabled = false;
      btn.textContent = '⚡ 1D 구조해석 실행 (Solve FEM)';
    }
  };

  AppClass.prototype.transferFrameResultToDesign = async function() {
    if (!this.lastFrameResult || !this.lastFrameResult.max_forces) {
      alert('먼저 1D 구조해석을 실행하세요.');
      return;
    }

    const mf = this.lastFrameResult.max_forces;
    const pu = mf.pu_max || 0;
    const mux = mf.mux_max || 0;
    const vu = mf.vu_max || 0;

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

    const tabMemberBtn = document.querySelector('[data-target="tabMember"]');
    if (tabMemberBtn) tabMemberBtn.click();

    this.closeFrameAnalysisModal();
    await this.runDesignCheck();

    alert(`✅ 구조해석 최대 부재력이 부재설계(Member Check) 및 웨브크리플링으로 연동되었습니다!\n• Mux = ${mux} kN·m\n• Vu = ${vu} kN (소요반력 Ru = ${vu} kN)\n• Pu = ${pu} kN`);
  };
}
