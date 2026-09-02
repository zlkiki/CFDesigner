/**
 * Effective Width Module: Winter Effective Width Overlay Modal
 * Extends CFDesignerApp with Phase 3/9 effective section methods.
 */

export function applyEffectiveWidthMixin(AppClass) {

  AppClass.prototype.toggleEffectiveWidthToolbar = function() {
    if (this.canvas2d.showEffective) {
      this.resetEffectiveState();
    } else {
      this.openEffectiveModal();
    }
  };

  AppClass.prototype.renderMathInEffectiveModal = function() {
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
  };

  AppClass.prototype.openEffectiveModal = function() {
    document.getElementById('effectiveModal').classList.add('active');
    this.renderMathInEffectiveModal();
    this.computeEffectiveModalValues(false);
  };

  AppClass.prototype.closeEffectiveModal = function() {
    document.getElementById('effectiveModal').classList.remove('active');
  };

  AppClass.prototype.computeEffectiveModalValues = async function(applyToCanvas = false) {
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

      const elAe = document.getElementById('valAe');
      if (elAe) elAe.textContent = `${data.ae} mm² (Gross: ${data.ag} mm²)`;
      const elAeRatio = document.getElementById('valAeRatio');
      if (elAeRatio) elAeRatio.textContent = `${(data.area_ratio * 100.0).toFixed(1)}%`;
      const elIxe = document.getElementById('valIxe');
      if (elIxe) elIxe.textContent = `${data.ixe} mm⁴`;
      const elDeltaY = document.getElementById('valDeltaY');
      if (elDeltaY) elDeltaY.textContent = `${data.delta_y > 0 ? '+' : ''}${data.delta_y} mm`;

      if (applyToCanvas) {
        this.canvas2d.setEffectiveSegments(data.segments);
        this.canvas2d.toggleEffective(true);

        const btn = document.getElementById('btnToggleEffective');
        if (btn) btn.classList.add('active');

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
  };

  AppClass.prototype.applyEffectiveOverlayToCanvas = function() {
    this.computeEffectiveModalValues(true);
  };

  AppClass.prototype.resetEffectiveState = function() {
    if (this.canvas2d) {
      this.canvas2d.toggleEffective(false);
      this.canvas2d.setEffectiveSegments([]);
    }
    const btn = document.getElementById('btnToggleEffective');
    if (btn) btn.classList.remove('active');
    const effCard = document.getElementById('cardEffectiveProps');
    if (effCard) effCard.style.display = 'none';
    this.lastEffectiveData = null;
  };
}
