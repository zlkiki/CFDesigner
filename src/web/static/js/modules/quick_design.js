/**
 * Quick Design Module: Auto Section Sizing (Quick Design Modal)
 * Extends CFDesignerApp with Phase 3 quick design methods.
 */

export function applyQuickDesignMixin(AppClass) {

  AppClass.prototype.openQuickDesignModal = function() {
    document.getElementById('quickDesignModal').classList.add('active');
  };

  AppClass.prototype.closeQuickDesignModal = function() {
    document.getElementById('quickDesignModal').classList.remove('active');
  };

  AppClass.prototype.executeQuickDesign = async function() {
    const btn = document.getElementById('btnExecuteQuickDesign');
    btn.disabled = true;
    btn.textContent = '⏳ 3대 한계상태 검토 및 최적 단면 탐색 중...';

    const typeFilter = document.getElementById('qdTypeFilter') ? document.getElementById('qdTypeFilter').value : 'All';
    const depthFilter = document.getElementById('qdDepthFilter') && document.getElementById('qdDepthFilter').value ? parseFloat(document.getElementById('qdDepthFilter').value) : null;
    const flangeFilter = document.getElementById('qdFlangeFilter') && document.getElementById('qdFlangeFilter').value ? parseFloat(document.getElementById('qdFlangeFilter').value) : null;
    const thicknessFilter = document.getElementById('qdThicknessFilter') && document.getElementById('qdThicknessFilter').value ? parseFloat(document.getElementById('qdThicknessFilter').value) : null;
    const config = document.getElementById('qdConfigSelect') ? document.getElementById('qdConfigSelect').value : 'Single';
    const punched = document.getElementById('qdPunchedCheck') ? document.getElementById('qdPunchedCheck').checked : false;
    const coldWork = document.getElementById('qdColdWorkCheck') ? document.getElementById('qdColdWorkCheck').checked : false;
    const reserve = document.getElementById('qdReserveCheck') ? document.getElementById('qdReserveCheck').checked : false;

    const span = parseFloat(document.getElementById('qdSpanInput')?.value) || 3000.0;
    const spacing = parseFloat(document.getElementById('qdSpacingInput')?.value) || 400.0;
    const bracing = document.getElementById('qdBracingSelect') ? document.getElementById('qdBracingSelect').value : 'Unbraced';

    const deadLoad = parseFloat(document.getElementById('qdDeadInput')?.value) || 0.0;
    const liveLoad = parseFloat(document.getElementById('qdLiveInput')?.value) || 0.0;
    const windLoad = parseFloat(document.getElementById('qdWindInput')?.value) || 0.0;
    const deadAxial = parseFloat(document.getElementById('qdAxialInput')?.value) || 0.0;
    const deflLimit = parseFloat(document.getElementById('qdDeflectionSelect')?.value) || 360.0;
    const bearingLen = parseFloat(document.getElementById('qdBearingLength')?.value) || 38.0;
    const lib = document.getElementById('qdLibrarySelect')?.value || null;
    const fy = parseFloat(document.getElementById('qdYieldSelect')?.value) || 345.0;

    try {
      const res = await fetch('/api/design/quick-design', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          shape_type_filter: typeFilter,
          depth_filter: depthFilter,
          flange_filter: flangeFilter,
          thickness_filter: thicknessFilter,
          config: config,
          punched: punched,
          cold_work: coldWork,
          reserve: reserve,
          span: span,
          length: span,
          spacing: spacing,
          bracing: bracing,
          dead_load: deadLoad,
          live_load: liveLoad,
          wind_load: windLoad,
          dead_axial: deadAxial,
          deflection_live_limit: deflLimit,
          bearing_length: bearingLen,
          library: lib,
          fy: fy,
          max_results: 15
        })
      });

      const data = await res.json();
      this.quickDesignCandidates = data.candidates || [];
      document.getElementById('qdResultCount').textContent = data.total_passed || 0;

      const tbody = document.getElementById('quickDesignTableBody');
      tbody.innerHTML = '';

      if (this.quickDesignCandidates.length === 0) {
        tbody.innerHTML = `<tr><td colspan="11" style="text-align:center; color: var(--accent-warning); padding: 30px;">조건을 만족하는 단면이 없습니다. 하중이나 제약조건을 완화해 보세요.</td></tr>`;
        return;
      }

      this.quickDesignCandidates.forEach((cand, idx) => {
        const tr = document.createElement('tr');
        const rankBadge = cand.rank === 1 ? '🥇 1' : (cand.rank === 2 ? '🥈 2' : (cand.rank === 3 ? '🥉 3' : cand.rank));
        const savingsBadge = cand.weight_savings_pct > 0 ? `<span style="color: var(--accent-success); font-weight: 600;">-${cand.weight_savings_pct}%</span>` : '-';

        const strengthDcColor = cand.dc_strength <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const deflDcColor = cand.dc_deflection <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const cripDcColor = cand.dc_crippling <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';
        const maxDcColor = cand.max_dc <= 1.0 ? 'var(--accent-success)' : 'var(--accent-danger)';

        tr.innerHTML = `
          <td style="text-align: center; font-weight: 700;">${rankBadge}</td>
          <td style="font-weight: 600; color: var(--accent-primary);">${cand.name}</td>
          <td><span class="brand-badge">${cand.library_name}</span></td>
          <td><strong>${cand.weight}</strong> kg/m</td>
          <td style="font-size: 11px;">${cand.depth} × ${cand.flange} × ${cand.thickness}</td>
          <td style="color: ${strengthDcColor}; font-weight: 600;" title="P-M 및 전단 강도 D/C">${cand.dc_strength}</td>
          <td style="color: ${deflDcColor}; font-weight: 600;" title="활하중/총하중 처짐 D/C (${cand.deflection_live_mm} mm)">${cand.dc_deflection}</td>
          <td style="color: ${cripDcColor}; font-weight: 600;" title="웨브 크리플링 D/C (Ru=${cand.reaction_ru_kn} kN)">${cand.dc_crippling}</td>
          <td style="font-weight: 700; color: ${maxDcColor};">${cand.max_dc}</td>
          <td>${savingsBadge}</td>
          <td style="text-align: center; min-width: 70px;">
            <button class="btn btn-outline" onclick="window.app.applyQuickDesignCandidate(${idx})" style="padding: 4px 8px; font-size: 11.5px; font-weight: 600; white-space: nowrap; width: 100%;">
              ⚡ 적용
            </button>
          </td>
        `;
        tbody.appendChild(tr);
      });
    } catch (err) {
      console.error('Quick design error:', err);
      alert('퀵 디자인 탐색 중 오류가 발생했습니다.');
    } finally {
      btn.disabled = false;
      btn.textContent = '⚡ 최적 경량 단면 자동 탐색 실행';
    }
  };

  AppClass.prototype.applyQuickDesignCandidate = function(index) {
    if (!this.quickDesignCandidates || !this.quickDesignCandidates[index]) return;
    const cand = this.quickDesignCandidates[index];
    if (cand.elements && cand.elements.length > 0) {
      const geometry = {
        elements: cand.elements,
        thickness: cand.thickness,
        is_closed: false,
        total_length: cand.depth * 2 + cand.flange * 2
      };

      const spanInput = document.getElementById('qdSpanInput');
      if (spanInput && spanInput.value) {
        const spanVal = parseFloat(spanInput.value);
        const lx = document.getElementById('lengthX');
        const ly = document.getElementById('lengthY');
        const lt = document.getElementById('lengthT');
        if (lx) lx.value = spanVal;
        if (ly) ly.value = spanVal;
        if (lt) lt.value = spanVal;
      }

      this.canvas2d.clearPropertiesMarkers();
      this.canvas2d.showLoading('⏳ 퀵 디자인 단면 로드 중...');
      if (this.viewer3d) this.viewer3d.showLoading('⏳ FSM 탄성 버클링 재계산 중...');

      this.updateSectionData({ geometry: geometry });
      this.closeQuickDesignModal();
      this.showStatus(`퀵 디자인 단면 [${cand.name}] (${cand.weight} kg/m) 적용 완료`, 'success', 4000);
    }
  };
}
