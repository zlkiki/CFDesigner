/**
 * Section Editor Module: Element Spreadsheet Editor, Geometric Transforms, Insert Ribs
 * Extends CFDesignerApp with Phase 1 section editing methods.
 * Attaches methods via prototype mixin pattern.
 */

export function applySectionEditorMixin(AppClass) {

  // ================= Phase 1: Element Spreadsheet Editor =================

  AppClass.prototype.openElementEditorModal = function() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const tbody = document.getElementById('elementTableBody');
    tbody.innerHTML = '';

    this.currentGeometry.elements.forEach((e, idx) => {
      const tr = this.createElementRowHTML(e, idx + 1);
      tbody.appendChild(tr);
    });

    document.getElementById('elementEditorModal').classList.add('active');
  };

  AppClass.prototype.closeElementEditorModal = function() {
    document.getElementById('elementEditorModal').classList.remove('active');
    this.canvas2d.setHighlightElement(null);
  };

  AppClass.prototype.createElementRowHTML = function(e, id) {
    const tr = document.createElement('tr');
    tr.dataset.elemId = id;

    tr.addEventListener('mouseenter', () => this.canvas2d.setHighlightElement(id));
    tr.addEventListener('mouseleave', () => this.canvas2d.setHighlightElement(null));

    const deg = Math.round(((e.angle || 0) * 180 / Math.PI) * 10) / 10;

    tr.innerHTML = `
      <td style="font-weight: bold; color: var(--accent-primary);">${id}</td>
      <td><input type="number" class="elem-x0" value="${e.x0 !== undefined ? e.x0 : 0}" step="1"></td>
      <td><input type="number" class="elem-y0" value="${e.y0 !== undefined ? e.y0 : 0}" step="1"></td>
      <td><input type="number" class="elem-x1" value="${e.x1 !== undefined ? e.x1 : 0}" step="1"></td>
      <td><input type="number" class="elem-y1" value="${e.y1 !== undefined ? e.y1 : 0}" step="1"></td>
      <td><input type="number" class="elem-len" value="${e.length || 10}" step="1"></td>
      <td><input type="number" class="elem-ang" value="${deg}" step="1"></td>
      <td><input type="number" class="elem-t" value="${e.thickness || this.currentGeometry.thickness || 2.0}" step="0.1"></td>
      <td><input type="number" class="elem-r" value="${e.radius || 0.0}" step="0.5"></td>
      <td><button class="btn-row-del" title="삭제">✕</button></td>
    `;

    tr.querySelector('.btn-row-del').addEventListener('click', (ev) => {
      ev.stopPropagation();
      tr.remove();
      this.reindexElementRows();
    });

    return tr;
  };

  AppClass.prototype.reindexElementRows = function() {
    const rows = document.querySelectorAll('#elementTableBody tr');
    rows.forEach((r, idx) => {
      r.dataset.elemId = idx + 1;
      r.cells[0].textContent = idx + 1;
    });
  };

  AppClass.prototype.addElementRow = function() {
    const tbody = document.getElementById('elementTableBody');
    const newId = tbody.children.length + 1;
    const defaultElem = {
      elem_id: newId,
      x0: 0, y0: 0, x1: 50, y1: 0,
      length: 50, angle: 0,
      thickness: this.currentGeometry ? this.currentGeometry.thickness : 2.0,
      radius: 0.0
    };
    const tr = this.createElementRowHTML(defaultElem, newId);
    tbody.appendChild(tr);
  };

  AppClass.prototype.applyElementsEditor = async function() {
    const rows = document.querySelectorAll('#elementTableBody tr');
    const elements = [];
    let defaultT = 2.0;

    rows.forEach((r, idx) => {
      const x0 = parseFloat(r.querySelector('.elem-x0').value) || 0;
      const y0 = parseFloat(r.querySelector('.elem-y0').value) || 0;
      const x1 = parseFloat(r.querySelector('.elem-x1').value) || 0;
      const y1 = parseFloat(r.querySelector('.elem-y1').value) || 0;
      const length = parseFloat(r.querySelector('.elem-len').value) || Math.sqrt((x1 - x0) ** 2 + (y1 - y0) ** 2);
      const angleDeg = parseFloat(r.querySelector('.elem-ang').value) || 0;
      const t = parseFloat(r.querySelector('.elem-t').value) || 2.0;
      const radius = parseFloat(r.querySelector('.elem-r').value) || 0.0;
      defaultT = t;

      elements.push({
        elem_id: idx + 1,
        x0, y0, x1, y1,
        length,
        angle: angleDeg * Math.PI / 180,
        thickness: t,
        radius
      });
    });

    if (elements.length === 0) return;

    try {
      const res = await fetch('/api/section/elements', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ elements, thickness: defaultT })
      });
      const data = await res.json();
      this.updateSectionData(data);
      this.closeElementEditorModal();
    } catch (err) {
      console.error('Apply Elements error:', err);
    }
  };

  // ================= Phase 1: Geometric Transforms =================

  AppClass.prototype.transformSection = async function(transformType, angleDeg = 0) {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const originalElements = this.currentGeometry.elements;
    const optimisticElements = this.applyOptimisticTransform(originalElements, transformType, angleDeg);
    const optimisticGeom = { ...this.currentGeometry, elements: optimisticElements };
    this.currentGeometry = optimisticGeom;
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 단면 성질 재계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

    const typeNames = {
      rotate_90_cw: '90° 시계방향 회전',
      rotate_90_ccw: '90° 반시계방향 회전',
      mirror_h: '상하 대칭 (Mirror X)',
      mirror_v: '좌우 대칭 (Mirror Y)',
      align_cg: '도심 원점 정렬',
      rotate_angle: `${angleDeg}° 회전`
    };
    const desc = typeNames[transformType] || '단면 변환';
    this.showStatus(`🔄 ${desc} 적용 및 정밀 단면해석 중...`, 'busy');

    const signal = this.getAbortSignal('transform', `이전 변환 취소 후 ${desc} 재연산 중...`);

    const payload = {
      elements: originalElements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: transformType,
      angle_deg: angleDeg,
      center_at_cg: true
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Transform error:', err);
      this.showStatus('단면 변환 오류 발생', 'warning', 3000);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  };

  AppClass.prototype.openRotateModal = function() {
    document.getElementById('rotateModal').classList.add('active');
  };

  AppClass.prototype.closeRotateModal = function() {
    document.getElementById('rotateModal').classList.remove('active');
  };

  AppClass.prototype.submitRotate = async function() {
    const angle = parseFloat(document.getElementById('rotateAngleInput').value) || 0;
    const centerCg = document.getElementById('rotateCenterCg').checked;

    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const originalElements = this.currentGeometry.elements;
    const optimisticElements = this.applyOptimisticTransform(originalElements, 'rotate_angle', angle);
    const optimisticGeom = { ...this.currentGeometry, elements: optimisticElements };
    this.currentGeometry = optimisticGeom;
    this.canvas2d.setData(this.currentGeometry, this.currentProperties);
    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 단면 성질 재계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');
    this.closeRotateModal();

    this.showStatus(`🔄 ${angle}° 임의각도 회전 적용 및 정밀 단면해석 중...`, 'busy');
    const signal = this.getAbortSignal('transform', `이전 회전 취소 후 ${angle}° 재회전 중...`);

    const payload = {
      elements: originalElements,
      thickness: this.currentGeometry.thickness || 2.0,
      transform_type: 'rotate_angle',
      angle_deg: angle,
      center_at_cg: centerCg
    };

    try {
      const res = await fetch('/api/section/transform', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
        signal: signal
      });
      if (!res.ok) return;
      const data = await res.json();
      this.updateSectionData(data);
    } catch (err) {
      if (err.name === 'AbortError') return;
      console.error('Rotate submit error:', err);
      this.showStatus('회전 연산 실패', 'warning', 3000);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  };

  // ================= Phase 1: Insert Ribs Wizard =================

  AppClass.prototype.openInsertRibsModal = function() {
    if (!this.currentGeometry || !this.currentGeometry.elements) return;

    const sel = document.getElementById('ribTargetElementSelect');
    sel.innerHTML = '';

    this.currentGeometry.elements.forEach(e => {
      const opt = document.createElement('option');
      opt.value = e.elem_id;
      opt.textContent = `요소 ${e.elem_id} (L = ${Math.round(e.length)} mm, θ = ${Math.round(e.angle * 180 / Math.PI)}°)`;
      sel.appendChild(opt);
    });

    if (this.currentGeometry.elements.length >= 3) {
      sel.selectedIndex = 2;
    }

    document.getElementById('insertRibsModal').classList.add('active');
  };

  AppClass.prototype.closeInsertRibsModal = function() {
    document.getElementById('insertRibsModal').classList.remove('active');
  };

  AppClass.prototype.submitInsertRibs = async function() {
    const targetId = parseInt(document.getElementById('ribTargetElementSelect').value) || 1;
    const ribType = document.getElementById('ribTypeSelect').value;
    const ribWidth = parseFloat(document.getElementById('ribWidthInput').value) || 25.0;
    const ribDepth = parseFloat(document.getElementById('ribDepthInput').value) || 12.0;
    const numRibs = parseInt(document.getElementById('ribCountInput').value) || 1;
    const ribRadius = parseFloat(document.getElementById('ribRadiusInput').value) || 0.0;

    this.canvas2d.clearPropertiesMarkers();
    this.canvas2d.showLoading('⏳ 리브 추가 계산 중...');
    if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

    const payload = {
      elements: this.currentGeometry.elements,
      thickness: this.currentGeometry.thickness || 2.0,
      target_elem_id: targetId,
      rib_type: ribType,
      rib_width: ribWidth,
      rib_depth: ribDepth,
      num_ribs: numRibs,
      rib_radius: ribRadius
    };

    try {
      const res = await fetch('/api/section/insert-ribs', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });
      const data = await res.json();
      this.updateSectionData(data);
      this.closeInsertRibsModal();
    } catch (err) {
      console.error('Insert Ribs error:', err);
      this.canvas2d.hideLoading();
      if (this.viewer3d) this.viewer3d.hideLoading();
    }
  };
}
