/**
 * Library Browser Module: Section Library Modal, Library Preview Canvas
 * Extends CFDesignerApp with Phase 2 section library browsing methods.
 */

export function applyLibraryBrowserMixin(AppClass) {

  AppClass.prototype.openLibraryModal = function() {
    this.currentLibName = this.currentLibName || "SSMA";
    document.getElementById('sectionLibraryModal').classList.add('active');
    this.loadLibrary(this.currentLibName);
  };

  AppClass.prototype.closeLibraryModal = function() {
    document.getElementById('sectionLibraryModal').classList.remove('active');
  };

  AppClass.prototype.searchLibrary = function() {
    const q = document.getElementById('libSearchInput').value.trim();
    this.loadLibrary(this.currentLibName || "SSMA", q);
  };

  AppClass.prototype.loadLibrary = async function(libName, query = "") {
    const container = document.getElementById('libSectionListContainer');
    container.innerHTML = '<div style="font-size:12px; color:var(--text-muted); padding:10px;">라이브러리 불러오는 중...</div>';

    try {
      const url = `/api/library/sections?lib=${libName}&query=${encodeURIComponent(query)}`;
      const res = await fetch(url);
      const data = await res.json();

      container.innerHTML = '';
      if (!data.types || data.types.length === 0) {
        container.innerHTML = '<div style="font-size:12px; color:var(--text-muted); padding:10px;">검색된 단면이 없습니다.</div>';
        return;
      }

      data.types.forEach(t => {
        if (t.sections.length === 0) return;

        const header = document.createElement('div');
        header.className = 'lib-type-header';
        header.innerHTML = `<span>${t.name}</span><span>${t.sections.length}개</span>`;
        container.appendChild(header);

        t.sections.forEach(s => {
          const item = document.createElement('div');
          item.className = 'lib-section-item';
          item.innerHTML = `<span>${s.name}</span><span style="color:var(--text-muted); font-size:11px;">${s.type}</span>`;
          item.addEventListener('click', () => {
            document.querySelectorAll('.lib-section-item').forEach(el => el.classList.remove('selected'));
            item.classList.add('selected');
            this.previewLibrarySection(libName, s.offset, s.name);
          });
          container.appendChild(item);
        });
      });
    } catch (err) {
      console.error('Load Library error:', err);
      container.innerHTML = '<div style="font-size:12px; color:var(--accent-danger); padding:10px;">라이브러리 로드 실패</div>';
    }
  };

  AppClass.prototype.previewLibrarySection = async function(libName, offset, sctName) {
    document.getElementById('libSelectedName').textContent = `${libName} - ${sctName}`;
    const btnLoad = document.getElementById('btnLoadLibSection');
    btnLoad.disabled = true;

    try {
      const res = await fetch(`/api/library/sections/${libName}/${offset}`);
      const data = await res.json();
      this.selectedLibSectionData = data;

      const p = data.properties;
      document.getElementById('libPropAg').textContent = p.area.toLocaleString();
      document.getElementById('libPropIx').textContent = p.ix.toLocaleString();
      document.getElementById('libPropIy').textContent = p.iy.toLocaleString();
      document.getElementById('libPropT').textContent = data.geometry.thickness;

      this.drawLibPreview(data.geometry);
      btnLoad.disabled = false;
    } catch (err) {
      console.error('Preview error:', err);
    }
  };

  AppClass.prototype.drawLibPreview = function(geometry) {
    const canvas = document.getElementById('libPreviewCanvas');
    const ctx = canvas.getContext('2d');
    canvas.width = canvas.parentElement.clientWidth;
    canvas.height = canvas.parentElement.clientHeight;

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    const elements = geometry.elements || [];
    if (elements.length === 0) return;

    let minX = 1e9, maxX = -1e9, minY = 1e9, maxY = -1e9;
    elements.forEach(e => {
      minX = Math.min(minX, e.x0, e.x1);
      maxX = Math.max(maxX, e.x0, e.x1);
      minY = Math.min(minY, e.y0, e.y1);
      maxY = Math.max(maxY, e.y0, e.y1);
    });

    const w = Math.max(maxX - minX, 10);
    const h = Math.max(maxY - minY, 10);
    const pad = 24;
    const scale = Math.min((canvas.width - pad * 2) / w, (canvas.height - pad * 2) / h);
    const midX = (minX + maxX) / 2;
    const midY = (minY + maxY) / 2;

    ctx.save();
    ctx.translate(canvas.width / 2, canvas.height / 2);
    ctx.scale(scale, -scale);
    ctx.translate(-midX, -midY);

    ctx.strokeStyle = 'rgba(59, 130, 246, 0.4)';
    ctx.lineWidth = geometry.thickness;
    ctx.lineCap = 'round';
    ctx.beginPath();
    elements.forEach(e => { ctx.moveTo(e.x0, e.y0); ctx.lineTo(e.x1, e.y1); });
    ctx.stroke();

    ctx.strokeStyle = '#38bdf8';
    ctx.lineWidth = 1.5 / scale;
    ctx.beginPath();
    elements.forEach(e => { ctx.moveTo(e.x0, e.y0); ctx.lineTo(e.x1, e.y1); });
    ctx.stroke();

    ctx.restore();
  };

  AppClass.prototype.loadSelectedLibSection = function() {
    if (!this.selectedLibSectionData) return;
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 라이브러리 단면 로드 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.updateSectionData(this.selectedLibSectionData);
    this.closeLibraryModal();
  };
}
