/**
 * FSM Buckling Signature Curve Chart Component (Chart.js)
 * Visualizes Half-Wavelength L vs Critical Load Pcr with interactive point selection.
 */

class FSMSignatureChart {
  constructor(canvasId, onPointSelected) {
    this.canvas = document.getElementById(canvasId);
    this.chart = null;
    this.onPointSelected = onPointSelected;
    this.initChart();
  }

  initChart() {
    const ctx = this.canvas.getContext('2d');
    this.chart = new Chart(ctx, {
      type: 'line',
      data: {
        datasets: [
          {
            label: 'FSM Signature Curve',
            data: [],
            borderColor: '#38bdf8',
            backgroundColor: 'rgba(56, 189, 248, 0.1)',
            borderWidth: 2.5,
            fill: true,
            tension: 0.3,
            pointRadius: 3,
            pointHoverRadius: 6,
            pointBackgroundColor: '#38bdf8',
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
            const idx = elements[0].index;
            const pt = this.chart.data.datasets[0].data[idx];
            if (this.onPointSelected && pt) {
              this.onPointSelected(pt.x, pt.y);
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
            display: false
          },
          tooltip: {
            backgroundColor: '#1e293b',
            titleColor: '#38bdf8',
            bodyColor: '#f8fafc',
            borderColor: '#475569',
            borderWidth: 1,
            padding: 10,
            callbacks: {
              label: (context) => {
                const pt = context.raw;
                const isBending = this.currentLoadType && this.currentLoadType.startsWith('bending');
                const unit = isBending ? 'kN·m' : 'kN';
                const varName = isBending ? 'M_cr' : 'P_cr';
                return `L = ${pt.x.toLocaleString()} mm : ${varName} = ${pt.y.toFixed(3)} ${unit}`;
              }
            }
          }
        }
      }
    });
  }

  updateData(points, loadType = 'compression') {
    if (!this.chart) return;
    this.currentLoadType = loadType;
    const isBending = loadType && loadType.startsWith('bending');

    const formatted = (points || []).map(p => ({
      x: p.length,
      y: isBending ? (p.m_cr !== undefined ? p.m_cr : p.critical_moment) : (p.p_cr !== undefined ? p.p_cr : (p.critical_load / 1000.0))
    }));

    this.chart.data.datasets[0].data = formatted;
    this.chart.data.datasets[0].label = isBending ? 'FSM Signature Curve (Mcr)' : 'FSM Signature Curve (Pcr)';
    this.chart.options.scales.y.title.text = isBending ? '탄성 버클링모멘트 M_cr (kN·m)' : '탄성 버클링하중 P_cr (kN)';
    this.chart.update();
  }
}
