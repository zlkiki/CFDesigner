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
    this.highlightElemId = null;
    this.showEffective = false;
    this.effectiveSegments = [];
    this.theme = 'dark';
    this.loadingMessage = null;

    this.initEvents();
    this.resize();
  }

  setTheme(theme) {
    this.theme = theme;
    this.render();
  }

  clearPropertiesMarkers() {
    this.properties = null;
    this.render();
  }

  showLoading(message = '⏳ 단면 성질 계산 중...') {
    this.loadingMessage = message;
    this.render();
  }

  hideLoading() {
    this.loadingMessage = null;
    this.render();
  }

  setHighlightElement(elemId) {
    this.highlightElemId = elemId;
    this.render();
  }

  setEffectiveSegments(segments) {
    this.effectiveSegments = segments || [];
    this.render();
  }

  toggleEffective(show) {
    this.showEffective = (show !== undefined) ? show : !this.showEffective;
    this.render();
    return this.showEffective;
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
    this.hideLoading();
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

    // 1. Draw Global Axes Origin with Arrows & Labels
    this.drawOriginAxes(ctx);

    // 2. Draw Thickness Outlines (Cold-formed rounded corner representation)
    if (this.showThickness) {
      ctx.strokeStyle = 'rgba(59, 130, 246, 0.35)';
      ctx.lineWidth = this.thickness;
      ctx.lineCap = 'round';
      ctx.lineJoin = 'round';
      ctx.beginPath();
      let lastX = null, lastY = null;
      this.elements.forEach(e => {
        if (lastX === null || Math.hypot(e.x0 - lastX, e.y0 - lastY) > 1e-3) {
          ctx.moveTo(e.x0, e.y0);
        }
        ctx.lineTo(e.x1, e.y1);
        lastX = e.x1;
        lastY = e.y1;
      });
      ctx.stroke();
    }

    // 3. Draw Centerlines (Smooth continuous path with round joints)
    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 1.6 / this.scale;
    ctx.lineCap = 'round';
    ctx.lineJoin = 'round';
    ctx.beginPath();
    let lastCx = null, lastCy = null;
    this.elements.forEach(e => {
      if (lastCx === null || Math.hypot(e.x0 - lastCx, e.y0 - lastCy) > 1e-3) {
        ctx.moveTo(e.x0, e.y0);
      }
      ctx.lineTo(e.x1, e.y1);
      lastCx = e.x1;
      lastCy = e.y1;
    });
    ctx.stroke();

    // 3.1 Draw Highlighted Element (if any)
    if (this.highlightElemId !== null) {
      const target = this.elements.find(e => e.elem_id === this.highlightElemId);
      if (target) {
        ctx.strokeStyle = '#f59e0b';
        ctx.lineWidth = Math.max(3.5 / this.scale, this.thickness * 1.4);
        ctx.lineCap = 'round';
        ctx.beginPath();
        ctx.moveTo(target.x0, target.y0);
        ctx.lineTo(target.x1, target.y1);
        ctx.stroke();

        ctx.fillStyle = '#f59e0b';
        ctx.beginPath();
        ctx.arc(target.x0, target.y0, 4.0 / this.scale, 0, Math.PI * 2);
        ctx.arc(target.x1, target.y1, 4.0 / this.scale, 0, Math.PI * 2);
        ctx.fill();
      }
    }

    // 4. Draw Effective / Ineffective Segments Overlay
    if (this.showEffective && this.effectiveSegments && this.effectiveSegments.length > 0) {
      this.effectiveSegments.forEach((seg) => {
        ctx.beginPath();
        ctx.moveTo(seg.x1, seg.y1);
        ctx.lineTo(seg.x2, seg.y2);

        if (seg.is_effective) {
          ctx.strokeStyle = '#06b6d4';
          ctx.lineWidth = Math.max(3.0 / this.scale, (seg.thickness || this.thickness) * 1.2);
          ctx.setLineDash([]);
        } else {
          ctx.strokeStyle = 'rgba(239, 68, 68, 0.7)';
          ctx.lineWidth = Math.max(2.0 / this.scale, (seg.thickness || this.thickness) * 0.8);
          ctx.setLineDash([4 / this.scale, 3 / this.scale]);
        }
        ctx.stroke();
      });
      ctx.setLineDash([]);
    }

    // 5. Draw Nodes
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

    const xcg = this.properties ? (this.properties.xcg || 0) : 0;
    const ycg = this.properties ? (this.properties.ycg || 0) : 0;
    const scRelX = this.properties ? (this.properties.x0 || 0) : 0;
    const scRelY = this.properties ? (this.properties.y0 || 0) : 0;
    const scAbsX = xcg + scRelX;
    const scAbsY = ycg + scRelY;

    // 6. Draw Principal Axes (Centered at CG)
    if (this.showPrincipal && this.properties) {
      const alphaRad = (this.properties.theta_p || 0) * Math.PI / 180;
      const axLen = 80;
      const cosA = Math.cos(alphaRad);
      const sinA = Math.sin(alphaRad);

      ctx.strokeStyle = '#10b981';
      ctx.lineWidth = 1.2 / this.scale;
      ctx.setLineDash([4 / this.scale, 3 / this.scale]);
      ctx.beginPath();
      // Axis 1 (Major)
      ctx.moveTo(xcg - axLen * cosA, ycg - axLen * sinA);
      ctx.lineTo(xcg + axLen * cosA, ycg + axLen * sinA);
      // Axis 2 (Minor)
      ctx.moveTo(xcg + axLen * sinA, ycg - axLen * cosA);
      ctx.lineTo(xcg - axLen * sinA, ycg + axLen * cosA);
      ctx.stroke();
      ctx.setLineDash([]);
    }

    // 7. Draw CG (Centroid) Marker at (xcg, ycg)
    if (this.showCG && this.properties) {
      ctx.fillStyle = '#ef4444';
      ctx.beginPath();
      ctx.arc(xcg, ycg, 4.0 / this.scale, 0, Math.PI * 2);
      ctx.fill();

      // Crosshair inside CG
      ctx.strokeStyle = '#ffffff';
      ctx.lineWidth = 1.0 / this.scale;
      ctx.beginPath();
      ctx.moveTo(xcg - 6.0 / this.scale, ycg);
      ctx.lineTo(xcg + 6.0 / this.scale, ycg);
      ctx.moveTo(xcg, ycg - 6.0 / this.scale);
      ctx.lineTo(xcg, ycg + 6.0 / this.scale);
      ctx.stroke();
    }

    // 8. Draw SC (Shear Center) Marker at (scAbsX, scAbsY)
    if (this.showSC && this.properties) {
      ctx.fillStyle = '#a855f7';
      ctx.beginPath();
      ctx.arc(scAbsX, scAbsY, 4.0 / this.scale, 0, Math.PI * 2);
      ctx.fill();

      // Diamond marker around SC
      ctx.strokeStyle = '#ffffff';
      ctx.lineWidth = 1.0 / this.scale;
      ctx.beginPath();
      ctx.moveTo(scAbsX, scAbsY + 6.0 / this.scale);
      ctx.lineTo(scAbsX + 6.0 / this.scale, scAbsY);
      ctx.lineTo(scAbsX, scAbsY - 6.0 / this.scale);
      ctx.lineTo(scAbsX - 6.0 / this.scale, scAbsY);
      ctx.closePath();
      ctx.stroke();
    }

    ctx.restore();

    // 9. Screen-space Legends (CG / SC labels)
    if (this.showCG && this.properties) {
      const cgScreenX = this.panX + xcg * this.scale;
      const cgScreenY = this.panY - ycg * this.scale;
      ctx.fillStyle = '#ef4444';
      ctx.font = 'bold 11px Inter, sans-serif';
      ctx.fillText(`CG 도심 (${xcg.toFixed(1)}, ${ycg.toFixed(1)})`, cgScreenX + 10, cgScreenY - 6);
    }

    if (this.showSC && this.properties) {
      const scScreenX = this.panX + scAbsX * this.scale;
      const scScreenY = this.panY - scAbsY * this.scale;
      ctx.fillStyle = '#a855f7';
      ctx.font = 'bold 11px Inter, sans-serif';
      ctx.fillText(`SC 전단중심 (${scAbsX.toFixed(1)}, ${scAbsY.toFixed(1)})`, scScreenX + 10, scScreenY - 6);
    }

    // 10. Fixed Viewport Coordinate Compass (WCS / UCS Widget at bottom-left)
    this.drawCoordinateCompass(ctx);

    // 11. Floating Loading Badge Overlay
    if (this.loadingMessage) {
      const badgeW = 200;
      const badgeH = 34;
      const bx = (w - badgeW) / 2;
      const by = 20;

      ctx.save();
      ctx.fillStyle = this.theme === 'light' ? 'rgba(255, 255, 255, 0.94)' : 'rgba(15, 23, 42, 0.90)';
      ctx.strokeStyle = '#3b82f6';
      ctx.lineWidth = 1.5;
      ctx.beginPath();
      if (ctx.roundRect) {
        ctx.roundRect(bx, by, badgeW, badgeH, 17);
      } else {
        ctx.rect(bx, by, badgeW, badgeH);
      }
      ctx.fill();
      ctx.stroke();

      ctx.fillStyle = this.theme === 'light' ? '#1e293b' : '#f8fafc';
      ctx.font = '600 12px Inter, sans-serif';
      ctx.textAlign = 'center';
      ctx.textBaseline = 'middle';
      ctx.fillText(this.loadingMessage, w / 2, by + badgeH / 2);
      ctx.restore();
    }
  }

  drawOriginAxes(ctx) {
    const axisLen = 1500;
    
    // Grid reference dashed lines
    ctx.lineWidth = 1 / this.scale;
    ctx.strokeStyle = 'rgba(148, 163, 184, 0.25)';
    ctx.setLineDash([4 / this.scale, 4 / this.scale]);
    ctx.beginPath();
    ctx.moveTo(-axisLen, 0); ctx.lineTo(axisLen, 0);
    ctx.moveTo(0, -axisLen); ctx.lineTo(0, axisLen);
    ctx.stroke();
    ctx.setLineDash([]);

    // X-Axis Line (+X in red)
    ctx.lineWidth = 1.8 / this.scale;
    ctx.strokeStyle = 'rgba(239, 68, 68, 0.75)';
    ctx.beginPath();
    ctx.moveTo(0, 0);
    ctx.lineTo(80 / this.scale, 0);
    ctx.stroke();

    // +X Arrow
    ctx.fillStyle = '#ef4444';
    ctx.beginPath();
    ctx.moveTo(80 / this.scale, 0);
    ctx.lineTo(72 / this.scale, 3.5 / this.scale);
    ctx.lineTo(72 / this.scale, -3.5 / this.scale);
    ctx.closePath();
    ctx.fill();

    // Y-Axis Line (+Y in green)
    ctx.lineWidth = 1.8 / this.scale;
    ctx.strokeStyle = 'rgba(34, 197, 94, 0.75)';
    ctx.beginPath();
    ctx.moveTo(0, 0);
    ctx.lineTo(0, 80 / this.scale);
    ctx.stroke();

    // +Y Arrow
    ctx.fillStyle = '#22c55e';
    ctx.beginPath();
    ctx.moveTo(0, 80 / this.scale);
    ctx.lineTo(-3.5 / this.scale, 72 / this.scale);
    ctx.lineTo(3.5 / this.scale, 72 / this.scale);
    ctx.closePath();
    ctx.fill();

    // Origin (0,0) circle
    ctx.fillStyle = 'rgba(255, 255, 255, 0.8)';
    ctx.beginPath();
    ctx.arc(0, 0, 2.5 / this.scale, 0, Math.PI * 2);
    ctx.fill();
  }

  drawCoordinateCompass(ctx) {
    const ox = 40;
    const oy = this.canvas.height - 40;
    const len = 32;

    ctx.save();
    
    // Background badge
    ctx.fillStyle = this.theme === 'light' ? 'rgba(255, 255, 255, 0.9)' : 'rgba(15, 23, 42, 0.75)';
    ctx.strokeStyle = this.theme === 'light' ? 'rgba(0, 0, 0, 0.15)' : 'rgba(255, 255, 255, 0.1)';
    ctx.lineWidth = 1;
    ctx.beginPath();
    ctx.arc(ox, oy, 26, 0, Math.PI * 2);
    ctx.fill();
    ctx.stroke();

    // X Axis (Red, right)
    ctx.strokeStyle = '#ef4444';
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(ox, oy);
    ctx.lineTo(ox + len, oy);
    ctx.stroke();

    ctx.fillStyle = '#ef4444';
    ctx.beginPath();
    ctx.moveTo(ox + len + 4, oy);
    ctx.lineTo(ox + len - 3, oy - 3.5);
    ctx.lineTo(ox + len - 3, oy + 3.5);
    ctx.closePath();
    ctx.fill();

    ctx.font = 'bold 11px Inter, sans-serif';
    ctx.fillText('X', ox + len + 8, oy + 4);

    // Y Axis (Green, up)
    ctx.strokeStyle = '#22c55e';
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(ox, oy);
    ctx.lineTo(ox, oy - len);
    ctx.stroke();

    ctx.fillStyle = '#22c55e';
    ctx.beginPath();
    ctx.moveTo(ox, oy - len - 4);
    ctx.lineTo(ox - 3.5, oy - len + 3);
    ctx.lineTo(ox + 3.5, oy - len + 3);
    ctx.closePath();
    ctx.fill();

    ctx.fillText('Y', ox - 4, oy - len - 8);

    // Center dot (0,0)
    ctx.fillStyle = this.theme === 'light' ? '#0f172a' : '#ffffff';
    ctx.beginPath();
    ctx.arc(ox, oy, 2.5, 0, Math.PI * 2);
    ctx.fill();

    ctx.restore();
  }

  drawGrid() {
    const ctx = this.ctx;
    const w = this.canvas.width;
    const h = this.canvas.height;
    const gridSize = 30;

    ctx.lineWidth = 0.5;
    ctx.strokeStyle = this.theme === 'light' ? 'rgba(0, 0, 0, 0.06)' : 'rgba(255, 255, 255, 0.03)';
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
