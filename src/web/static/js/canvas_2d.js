/**
 * 2D Interactive CAD Section Viewer (HTML5 Canvas)
 * Supports pan, zoom, centerlines, thickness outlines, CG, SC, Principal axes, and node labels.
 */

class SectionCanvas2D {
  constructor(canvasId) {
    this.canvas = document.getElementById(canvasId);
    this.ctx = this.canvas.getContext('2d');
    this.elements = [];
    this.properties = null;
    this.thickness = 2.0;

    // Viewport transform
    this.scale = 2.0;
    this.panX = 0;
    this.panY = 0;
    this.isDragging = false;
    this.dragStartX = 0;
    this.dragStartY = 0;

    // Display options
    this.showNodes = true;
    this.showThickness = true;
    this.showCG = true;
    this.showSC = true;
    this.showPrincipal = true;

    this.initEvents();
    this.resize();
  }

  initEvents() {
    window.addEventListener('resize', () => this.resize());

    // Mouse drag pan
    this.canvas.addEventListener('mousedown', (e) => {
      this.isDragging = true;
      this.dragStartX = e.clientX - this.panX;
      this.dragStartY = e.clientY - this.panY;
    });

    window.addEventListener('mousemove', (e) => {
      if (this.isDragging) {
        this.panX = e.clientX - this.dragStartX;
        this.panY = e.clientY - this.dragStartY;
        this.render();
      }
    });

    window.addEventListener('mouseup', () => {
      this.isDragging = false;
    });

    // Mouse wheel zoom
    this.canvas.addEventListener('wheel', (e) => {
      e.preventDefault();
      const zoomFactor = e.deltaY < 0 ? 1.15 : 0.87;
      const rect = this.canvas.getBoundingClientRect();
      const mouseX = e.clientX - rect.left;
      const mouseY = e.clientY - rect.top;

      this.panX = mouseX - (mouseX - this.panX) * zoomFactor;
      this.panY = mouseY - (mouseY - this.panY) * zoomFactor;
      this.scale *= zoomFactor;
      this.render();
    });
  }

  resize() {
    const parent = this.canvas.parentElement;
    if (parent) {
      this.canvas.width = parent.clientWidth;
      this.canvas.height = parent.clientHeight;
      this.render();
    }
  }

  setData(geometryData, propertiesData) {
    this.elements = geometryData.elements || [];
    this.thickness = geometryData.thickness || 2.0;
    this.properties = propertiesData;
    this.fitToView();
  }

  fitToView() {
    if (!this.elements || this.elements.length === 0) return;

    let minX = 1e9, maxX = -1e9, minY = 1e9, maxY = -1e9;
    this.elements.forEach(e => {
      minX = Math.min(minX, e.x0, e.x1);
      maxX = Math.max(maxX, e.x0, e.x1);
      minY = Math.min(minY, e.y0, e.y1);
      maxY = Math.max(maxY, e.y0, e.y1);
    });

    const secW = Math.max(maxX - minX, 20);
    const secH = Math.max(maxY - minY, 20);
    const midX = (minX + maxX) / 2;
    const midY = (minY + maxY) / 2;

    const pad = 60;
    const scaleX = (this.canvas.width - pad * 2) / secW;
    const scaleY = (this.canvas.height - pad * 2) / secH;
    this.scale = Math.min(scaleX, scaleY);

    this.panX = this.canvas.width / 2 - midX * this.scale;
    this.panY = this.canvas.height / 2 + midY * this.scale; // Flip Y

    this.render();
  }

  render() {
    const ctx = this.ctx;
    const w = this.canvas.width;
    const h = this.canvas.height;

    ctx.clearRect(0, 0, w, h);

    // Draw Grid
    this.drawGrid();

    if (!this.elements || this.elements.length === 0) {
      ctx.fillStyle = '#64748b';
      ctx.font = '14px sans-serif';
      ctx.textAlign = 'center';
      ctx.fillText('단면을 생성하거나 DXF 파일을 업로드하세요.', w / 2, h / 2);
      return;
    }

    ctx.save();
    ctx.translate(this.panX, this.panY);
    ctx.scale(this.scale, -this.scale); // Math coordinates (Y up)

    // 1. Draw Global Axes Origin
    ctx.lineWidth = 1 / this.scale;
    ctx.strokeStyle = 'rgba(100, 116, 139, 0.4)';
    ctx.setLineDash([4 / this.scale, 4 / this.scale]);
    ctx.beginPath();
    ctx.moveTo(-1000, 0); ctx.lineTo(1000, 0);
    ctx.moveTo(0, -1000); ctx.lineTo(0, 1000);
    ctx.stroke();
    ctx.setLineDash([]);

    // 2. Draw Thickness Outlines
    if (this.showThickness) {
      ctx.strokeStyle = 'rgba(59, 130, 246, 0.35)';
      ctx.lineWidth = this.thickness;
      ctx.lineCap = 'round';
      ctx.beginPath();
      this.elements.forEach(e => {
        ctx.moveTo(e.x0, e.y0);
        ctx.lineTo(e.x1, e.y1);
      });
      ctx.stroke();
    }

    // 3. Draw Centerlines
    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 1.5 / this.scale;
    ctx.lineCap = 'round';
    ctx.beginPath();
    this.elements.forEach(e => {
      ctx.moveTo(e.x0, e.y0);
      ctx.lineTo(e.x1, e.y1);
    });
    ctx.stroke();

    // 4. Draw Nodes
    if (this.showNodes) {
      this.elements.forEach((e, idx) => {
        ctx.fillStyle = '#38bdf8';
        ctx.beginPath();
        ctx.arc(e.x0, e.y0, 2.5 / this.scale, 0, Math.PI * 2);
        ctx.fill();

        if (idx === this.elements.length - 1) {
          ctx.beginPath();
          ctx.arc(e.x1, e.y1, 2.5 / this.scale, 0, Math.PI * 2);
          ctx.fill();
        }
      });
    }

    // 5. Draw Principal Axes
    if (this.showPrincipal && this.properties) {
      const alphaRad = (this.properties.theta_p || 0) * Math.PI / 180;
      const axLen = 60;
      const cosA = Math.cos(alphaRad);
      const sinA = Math.sin(alphaRad);

      ctx.strokeStyle = '#10b981';
      ctx.lineWidth = 1.2 / this.scale;
      ctx.setLineDash([3 / this.scale, 3 / this.scale]);
      ctx.beginPath();
      // Axis 1 (Major)
      ctx.moveTo(-axLen * cosA, -axLen * sinA);
      ctx.lineTo(axLen * cosA, axLen * sinA);
      // Axis 2 (Minor)
      ctx.moveTo(axLen * sinA, -axLen * cosA);
      ctx.lineTo(-axLen * sinA, axLen * cosA);
      ctx.stroke();
      ctx.setLineDash([]);
    }

    // 6. Draw CG (Centroid) Marker
    if (this.showCG && this.properties) {
      ctx.fillStyle = '#ef4444';
      ctx.beginPath();
      ctx.arc(0, 0, 3.5 / this.scale, 0, Math.PI * 2);
      ctx.fill();
    }

    // 7. Draw SC (Shear Center) Marker
    if (this.showSC && this.properties) {
      const scX = this.properties.x0 || 0;
      const scY = this.properties.y0 || 0;
      ctx.fillStyle = '#8b5cf6';
      ctx.beginPath();
      ctx.arc(scX, scY, 3.5 / this.scale, 0, Math.PI * 2);
      ctx.fill();
    }

    ctx.restore();

    // 8. Screen-space Legends (CG / SC labels)
    if (this.showCG) {
      const cgScreenX = this.panX;
      const cgScreenY = this.panY;
      ctx.fillStyle = '#ef4444';
      ctx.font = 'bold 11px sans-serif';
      ctx.fillText('CG (도심)', cgScreenX + 8, cgScreenY - 6);
    }

    if (this.showSC && this.properties) {
      const scScreenX = this.panX + (this.properties.x0 || 0) * this.scale;
      const scScreenY = this.panY - (this.properties.y0 || 0) * this.scale;
      ctx.fillStyle = '#8b5cf6';
      ctx.font = 'bold 11px sans-serif';
      ctx.fillText('SC (전단중심)', scScreenX + 8, scScreenY - 6);
    }
  }

  drawGrid() {
    const ctx = this.ctx;
    const w = this.canvas.width;
    const h = this.canvas.height;
    const gridSize = 30;

    ctx.lineWidth = 0.5;
    ctx.strokeStyle = 'rgba(255, 255, 255, 0.03)';
    ctx.beginPath();
    for (let x = 0; x < w; x += gridSize) {
      ctx.moveTo(x, 0); ctx.lineTo(x, h);
    }
    for (let y = 0; y < h; y += gridSize) {
      ctx.moveTo(0, y); ctx.lineTo(w, y);
    }
    ctx.stroke();
  }
}
