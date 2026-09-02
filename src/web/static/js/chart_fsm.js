/**
 * FSM Buckling Signature Curve Chart Component (Chart.js)
 * Visualizes Half-Wavelength L vs Critical Load Pcr with interactive multi-mode curves (Mode 1, Mode 2, Mode 3).
 */

class FSMSignatureChart {
  constructor(canvasId, onPointSelected) {
    this.canvas = document.getElementById(canvasId);
    this.chart = null;
    this.onPointSelected = onPointSelected;
    this.currentPoints = [];
    this.currentLoadType = 'compression';
    this.initChart();
  }

  initChart() {
    const ctx = this.canvas.getContext('2d');
    this.chart = new Chart(ctx, {
      type: 'line',
      data: {
        datasets: [
          {
            label: 'Mode 1 (1차 모드)',
            data: [],
            borderColor: '#38bdf8', // Sky blue
            backgroundColor: 'rgba(56, 189, 248, 0.08)',
            borderWidth: 2.5,
            fill: true,
            tension: 0.3,
            pointRadius: 3.5,
            pointHoverRadius: 7,
            pointBackgroundColor: '#38bdf8',
          },
          {
            label: 'Mode 2 (2차 모드)',
            data: [],
            borderColor: '#10b981', // Emerald green
            backgroundColor: 'rgba(16, 185, 129, 0.05)',
            borderWidth: 2.0,
            borderDash: [5, 5],
            fill: false,
            tension: 0.3,
            pointRadius: 3,
            pointHoverRadius: 6,
            pointStyle: 'rect',
            pointBackgroundColor: '#10b981',
          },
          {
            label: 'Mode 3 (3차 모드)',
            data: [],
            borderColor: '#a855f7', // Purple
            backgroundColor: 'rgba(168, 85, 247, 0.05)',
            borderWidth: 1.8,
            borderDash: [2, 3],
            fill: false,
            tension: 0.3,
            pointRadius: 3,
            pointHoverRadius: 6,
            pointStyle: 'triangle',
            pointBackgroundColor: '#a855f7',
          }
        ]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        interaction: {
          mode: 'nearest',
          intersect: false,
        },
        onClick: (e, elements) => {
          if (elements && elements.length > 0) {
            const el = elements[0];
            const datasetIndex = el.datasetIndex;
            const idx = el.index;
            const pt = this.chart.data.datasets[datasetIndex].data[idx];
            const fullPt = this.currentPoints[idx];
            const modeIndex = datasetIndex + 1; // 1, 2, or 3
            if (this.onPointSelected && pt) {
              this.onPointSelected(pt.x, pt.y, modeIndex, fullPt);
            }
          }
        },
        scales: {
          x: {
            type: 'logarithmic',
            title: {
              display: true,
              text: '반파장 길이 L (mm, log scale)',
              color: '#94a3b8',
              font: { size: 11, weight: 'bold' }
            },
            grid: {
              color: 'rgba(255, 255, 255, 0.05)',
            },
            ticks: {
              color: '#64748b',
              callback: function(val) {
                return Number(val).toLocaleString();
              }
            }
          },
          y: {
            title: {
              display: true,
              text: '탄성 버클링하중 P_cr (kN)',
              color: '#94a3b8',
              font: { size: 11, weight: 'bold' }
            },
            grid: {
              color: 'rgba(255, 255, 255, 0.05)',
            },
            ticks: {
              color: '#64748b'
            }
          }
        },
        plugins: {
          legend: {
            display: true,
            position: 'top',
            labels: {
              color: '#94a3b8',
              boxWidth: 14,
              boxHeight: 2,
              font: { size: 11 }
            }
          },
          tooltip: {
            backgroundColor: '#1e293b',
            titleColor: '#38bdf8',
            bodyColor: '#f8fafc',
            borderColor: '#475569',
            borderWidth: 1,
            padding: 10,
            callbacks: {
              title: (contexts) => {
                if (contexts && contexts.length > 0) {
                  return `반파장 L = ${contexts[0].raw.x.toLocaleString()} mm`;
                }
                return '';
              },
              label: (context) => {
                const pt = context.raw;
                const dsLabel = context.dataset.label || `Mode ${context.datasetIndex + 1}`;
                const isBending = this.currentLoadType && this.currentLoadType.startsWith('bending');
                const unit = isBending ? 'kN·m' : 'kN';
                const varName = isBending ? 'M_cr' : 'P_cr';
                return `${dsLabel}: ${varName} = ${pt.y.toFixed(3)} ${unit}`;
              }
            }
          }
        }
      }
    });
  }

  updateData(points, loadType = 'compression', curves = null) {
    if (!this.chart) return;
    this.currentPoints = points || [];
    this.currentLoadType = loadType;
    const isBending = loadType && loadType.startsWith('bending');
    const yTitle = isBending ? '탄성 버클링모멘트 M_cr (kN·m)' : '탄성 버클링하중 P_cr (kN)';
    this.chart.options.scales.y.title.text = yTitle;

    // Mode 1 dataset
    const m1_data = (points || []).map(p => {
      let val = 0;
      if (p.mode_pcrs && p.mode_pcrs.length > 0) {
        val = isBending ? ((p.mode_mcrs && p.mode_mcrs.length > 0 ? p.mode_mcrs[0] : p.m_cr) || 0) : p.mode_pcrs[0];
      } else {
        val = isBending ? (p.m_cr !== undefined ? p.m_cr : p.critical_moment) : (p.p_cr !== undefined ? p.p_cr : (p.critical_load / 1000.0));
      }
      return { x: p.length, y: Number(val) };
    }).filter(d => !isNaN(d.y) && d.y > 0);

    const validM1Vals = m1_data.map(d => d.y);
    const maxM1 = validM1Vals.length > 0 ? Math.max(...validM1Vals) : 1000.0;
    const upperLimit = maxM1 * 4.0; // Reasonable visual scale upper bound

    // Mode 2 dataset
    const m2_data = (points || []).map(p => {
      if (!p.mode_pcrs || p.mode_pcrs.length < 2) return null;
      const val = isBending ? (p.mode_mcrs && p.mode_mcrs.length > 1 ? p.mode_mcrs[1] : null) : p.mode_pcrs[1];
      if (val === null || val === undefined || isNaN(val) || val <= 0 || val > upperLimit) return null;
      return { x: p.length, y: Number(val) };
    }).filter(d => d !== null);

    // Mode 3 dataset
    const m3_data = (points || []).map(p => {
      if (!p.mode_pcrs || p.mode_pcrs.length < 3) return null;
      const val = isBending ? (p.mode_mcrs && p.mode_mcrs.length > 2 ? p.mode_mcrs[2] : null) : p.mode_pcrs[2];
      if (val === null || val === undefined || isNaN(val) || val <= 0 || val > upperLimit) return null;
      return { x: p.length, y: Number(val) };
    }).filter(d => d !== null);

    this.chart.data.datasets[0].data = m1_data;
    this.chart.data.datasets[0].label = isBending ? 'Mode 1 (1차 Mcr)' : 'Mode 1 (1차 Pcr)';

    if (this.chart.data.datasets[1]) {
      this.chart.data.datasets[1].data = m2_data;
      this.chart.data.datasets[1].label = isBending ? 'Mode 2 (2차 Mcr)' : 'Mode 2 (2차 Pcr)';
      this.chart.data.datasets[1].hidden = m2_data.length === 0;
    }

    if (this.chart.data.datasets[2]) {
      this.chart.data.datasets[2].data = m3_data;
      this.chart.data.datasets[2].label = isBending ? 'Mode 3 (3차 Mcr)' : 'Mode 3 (3차 Pcr)';
      this.chart.data.datasets[2].hidden = m3_data.length === 0;
    }

    this.chart.update();
  }
}

