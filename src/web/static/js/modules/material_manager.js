/**
 * Material Manager Module: Material Presets, Cold-Work Calculations
 * Extends CFDesignerApp with Phase 2 material management methods.
 */

export function applyMaterialManagerMixin(AppClass) {

  AppClass.prototype.openMaterialModal = async function() {
    document.getElementById('materialModal').classList.add('active');

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
  };

  AppClass.prototype.closeMaterialModal = function() {
    document.getElementById('materialModal').classList.remove('active');
  };

  AppClass.prototype.onMaterialPresetChanged = function(code) {
    const sel = document.getElementById('matPresetSelect');
    const opt = sel.options[sel.selectedIndex];
    if (opt) {
      document.getElementById('matFyInput').value = opt.dataset.fy || 345;
      document.getElementById('matFuInput').value = opt.dataset.fu || 450;
      document.getElementById('matEInput').value = opt.dataset.e || 205000;
      document.getElementById('matNuInput').value = opt.dataset.nu || 0.3;
      this.recalcColdWork();
    }
  };

  AppClass.prototype.recalcColdWork = async function() {
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
  };

  AppClass.prototype.applyMaterialToDesign = function() {
    const enabled = document.getElementById('matColdWorkCheck').checked;
    const baseFy = parseFloat(document.getElementById('matFyInput').value) || 345.0;
    const fya = parseFloat(document.getElementById('valFya').textContent) || baseFy;
    const designFy = enabled ? fya : baseFy;

    document.getElementById('yieldStress').value = designFy;
    this.runDesignCheck();
    this.closeMaterialModal();
  };
}
