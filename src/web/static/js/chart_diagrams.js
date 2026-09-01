/**
 * 1D Beam & Frame Structural Diagram Viewer
 * Renders Beam Physical Model (Supports & Loads), SFD (Shear), BMD (Moment), and Deflection curves.
 */

class FrameDiagramViewer {
  constructor(modelCanvasId, sfdCanvasId, bmdCanvasId, deflCanvasId) {
    this.modelCanvas = document.getElementById(modelCanvasId);
    this.sfdCanvas = document.getElementById(sfdCanvasId);
    this.bmdCanvas = document.getElementById(bmdCanvasId);
    this.deflCanvas = document.getElementById(deflCanvasId);

    this.sfdChart = null;
    this.bmdChart = null;
    this.deflChart = null;
  }

  renderAll(analysisData, loadsData, supportsData) {
    if (!analysisData || !analysisData.diagrams) return;

    this.drawBeamModel(analysisData.total_length, supportsData, loadsData);
    this.drawSfdChart(analysisData.diagrams);
    this.drawBmdChart(analysisData.diagrams);
    this.drawDeflChart(analysisData.diagrams);
  }

  drawBeamModel(totalLen, supports, loads) {
    if (!this.modelCanvas) return;
    const ctx = this.modelCanvas.getContext('2d');
    const w = (this.modelCanvas.width = this.modelCanvas.parentElement.clientWidth);
    const h = (this.modelCanvas.height = 100);

    ctx.clearRect(0, 0, w, h);
    if (!totalLen || totalLen <= 0) return;

    const padX = 40;
    const beamY = 60;
    const drawW = w - padX * 2;
    const scaleX = drawW / totalLen;

    const toScreenX = (x) => padX + x * scaleX;

    // 1. Draw Beam Baseline (Thick)
    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 6;
    ctx.lineCap = 'round';
    ctx.beginPath();
    ctx.moveTo(padX, beamY);
    ctx.lineTo(padX + drawW, beamY);
    ctx.stroke();

    // 2. Draw Supports
    (supports || []).forEach(sup => {
      const sx = toScreenX(sup.location || sup.x || 0);
      const stype = (sup.type || 'roller').toLowerCase();

      ctx.fillStyle = '#10b981';
      ctx.strokeStyle = '#059669';
      ctx.lineWidth = 1.5;

      if (stype.includes('fixed')) {
        // Fixed wall hash
        ctx.strokeStyle = '#ef4444';
        ctx.lineWidth = 4;
        ctx.beginPath();
        ctx.moveTo(sx, beamY - 18);
        ctx.lineTo(sx, beamY + 18);
        ctx.stroke();
      } else {
        // Pin / Roller Triangle
        ctx.beginPath();
        ctx.moveTo(sx, beamY);
        ctx.lineTo(sx - 9, beamY + 16);
        ctx.lineTo(sx + 9, beamY + 16);
        ctx.closePath();
        ctx.fill();
        ctx.stroke();

        if (stype.includes('roller')) {
          // Small roller line at bottom
          ctx.strokeStyle = '#10b981';
          ctx.lineWidth = 2;
          ctx.beginPath();
          ctx.moveTo(sx - 11, beamY + 20);
          ctx.lineTo(sx + 11, beamY + 20);
          ctx.stroke();
        }
      }
    });

    // 3. Draw Loads
    (loads || []).forEach(ld => {
      const ltype = (ld.load_type || ld.type || 'udl').toLowerCase();
      const mag = ld.magnitude || ld.mag || 0;
      const xs = ld.x_start !== undefined ? ld.x_start : (ld.x || 0);
      const xe = ld.x_end !== undefined ? ld.x_end : totalLen;

      if (ltype === 'udl') {
        const sx1 = toScreenX(xs);
        const sx2 = toScreenX(xe);
        // UDL Top bar & down arrows
        ctx.fillStyle = 'rgba(239, 68, 68, 0.2)';
        ctx.strokeStyle = '#ef4444';
        ctx.lineWidth = 1.5;
        ctx.fillRect(sx1, beamY - 26, sx2 - sx1, 24);
        ctx.strokeRect(sx1, beamY - 26, sx2 - sx1, 24);

        // Arrows
        ctx.fillStyle = '#ef4444';
        const numArrows = Math.max(Math.floor((sx2 - sx1) / 25), 2);
        for (let i = 0; i <= numArrows; i++) {
          const ax = sx1 + (i / numArrows) * (sx2 - sx1);
          ctx.beginPath();
          ctx.moveTo(ax, beamY - 24);
          ctx.lineTo(ax, beamY - 4);
          ctx.stroke();
          // Arrowhead
          ctx.beginPath();
          ctx.moveTo(ax, beamY - 2);
          ctx.lineTo(ax - 3, beamY - 8);
          ctx.lineTo(ax + 3, beamY - 8);
          ctx.closePath();
          ctx.fill();
        }

        // Label
        ctx.font = '10.5px sans-serif';
        ctx.fillText(`w = ${mag} kN/m`, (sx1 + sx2) / 2 - 25, beamY - 30);

      } else if (ltype === 'point' || ltype === 'concentrated') {
        const px = toScreenX(xs);
        ctx.strokeStyle = '#f59e0b';
        ctx.fillStyle = '#f59e0b';
        ctx.lineWidth = 2.5;

        // Big Point Load Arrow
        ctx.beginPath();
        ctx.moveTo(px, beamY - 38);
        ctx.lineTo(px, beamY - 6);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(px, beamY - 2);
        ctx.lineTo(px - 5, beamY - 12);
        ctx.lineTo(px + 5, beamY - 12);
        ctx.closePath();
        ctx.fill();

        ctx.font = 'bold 11px sans-serif';
        ctx.fillText(`P = ${mag} kN`, px - 18, beamY - 42);
      }
    });
  }

  drawSfdChart(diagrams) {
    if (!this.sfdCanvas) return;
    const labels = diagrams.map(d => `${d.x}mm`);
    const dataV = diagrams.map(d => d.v);

    if (this.sfdChart) this.sfdChart.destroy();

    this.sfdChart = new Chart(this.sfdCanvas, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [{
          label: '전단력 V(x) (kN)',
          data: dataV,
          borderColor: '#38bdf8',
          backgroundColor: 'rgba(56, 189, 248, 0.15)',
          fill: true,
          borderWidth: 2,
          pointRadius: 0,
          tension: 0.1
        }]
      },
      options: this.getChartOptions('전단력도 SFD (kN)', 'kN')
    });
  }

  drawBmdChart(diagrams) {
    if (!this.bmdCanvas) return;
    const labels = diagrams.map(d => `${d.x}mm`);
    const dataM = diagrams.map(d => d.m);

    if (this.bmdChart) this.bmdChart.destroy();

    this.bmdChart = new Chart(this.bmdCanvas, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [{
          label: '휨모멘트 M(x) (kN·m)',
          data: dataM,
          borderColor: '#10b981',
          backgroundColor: 'rgba(16, 185, 129, 0.15)',
          fill: true,
          borderWidth: 2,
          pointRadius: 0,
          tension: 0.1
        }]
      },
      options: this.getChartOptions('휨모멘트도 BMD (kN·m)', 'kN·m')
    });
  }

  drawDeflChart(diagrams) {
    if (!this.deflCanvas) return;
    const labels = diagrams.map(d => `${d.x}mm`);
    const dataDefl = diagrams.map(d => d.deflection);

    if (this.deflChart) this.deflChart.destroy();

    this.deflChart = new Chart(this.deflCanvas, {
      type: 'line',
      data: {
        labels: labels,
        datasets: [{
          label: '처짐 δ(x) (mm)',
          data: dataDefl,
          borderColor: '#f59e0b',
          backgroundColor: 'rgba(245, 158, 11, 0.15)',
          fill: true,
          borderWidth: 2,
          pointRadius: 0,
          tension: 0.1
        }]
      },
      options: this.getChartOptions('처짐 곡선 Deflection (mm)', 'mm')
    });
  }

  getChartOptions(title, unit) {
    return {
      responsive: true,
      maintainAspectRatio: false,
      interaction: {
        mode: 'index',
        intersect: false
      },
      plugins: {
        legend: { display: false },
        title: {
          display: true,
          text: title,
          color: '#94a3b8',
          font: { size: 11.5, weight: '600' },
          padding: { top: 4, bottom: 6 }
        },
        tooltip: {
          backgroundColor: 'rgba(15, 23, 42, 0.9)',
          titleColor: '#38bdf8',
          bodyColor: '#f8fafc',
          callbacks: {
            label: (context) => ` ${context.dataset.label}: ${context.parsed.y} ${unit}`
          }
        }
      },
      scales: {
        x: {
          display: false,
          grid: { color: 'rgba(255, 255, 255, 0.05)' }
        },
        y: {
          grid: { color: 'rgba(255, 255, 255, 0.06)' },
          ticks: { color: '#94a3b8', font: { size: 10 } }
        }
      }
    };
  }
}
