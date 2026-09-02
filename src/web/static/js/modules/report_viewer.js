/**
 * Report Viewer Module: Structural Calculation Report Generation & Trace Viewer
 * Extends CFDesignerApp with Phase 7 & 11 report viewer methods.
 */

export function applyReportViewerMixin(AppClass) {

  AppClass.prototype.openReportModal = function() {
    const modal = document.getElementById('reportModal');
    if (modal) {
      modal.classList.add('active');
      this.refreshReport();
    }
  };

  AppClass.prototype.closeReportModal = function() {
    const modal = document.getElementById('reportModal');
    if (modal) {
      modal.classList.remove('active');
    }
  };

  AppClass.prototype.toggleAllTraceDetails = function() {
    const iframe = document.getElementById('reportViewerFrame');
    if (!iframe || !iframe.contentDocument) return;

    const doc = iframe.contentDocument;
    const accordions = doc.querySelectorAll('details.trace-accordion');
    if (!accordions || accordions.length === 0) return;

    const anyClosed = Array.from(accordions).some(acc => !acc.open);
    accordions.forEach(acc => { acc.open = anyClosed; });

    const btn = document.getElementById('btnToggleAllTrace');
    if (btn) {
      btn.textContent = anyClosed ? '📁 수식 전체 접기' : '📂 수식 전체 펼치기';
    }
  };

  AppClass.prototype.refreshReport = async function() {
    const iframe = document.getElementById('reportViewerFrame');
    if (!iframe) return;

    this.showStatus('📑 구조계산서 및 수식 전개(Trace) 생성 중...', 'busy');

    const mode = this.reportMode || 'detailed';
    const opts = {
      report_mode: mode,
      include_section_inputs: document.getElementById('chkReportSectionInputs')?.checked ?? true,
      include_gross_properties: document.getElementById('chkReportGrossProps')?.checked ?? true,
      include_torsion_properties: document.getElementById('chkReportTorsionProps')?.checked ?? true,
      include_effective_properties: document.getElementById('chkReportEffectiveProps')?.checked ?? true,
      include_fully_braced_strength: document.getElementById('chkReportFullyBraced')?.checked ?? true,
      include_fsm_buckling: document.getElementById('chkReportFsmBuckling')?.checked ?? true,
      include_member_design: document.getElementById('chkReportMemberDesign')?.checked ?? true,
      include_web_crippling: document.getElementById('chkReportWebCrippling')?.checked ?? true,
      include_1d_analysis: document.getElementById('chkReport1dAnalysis')?.checked ?? false,
      include_trace_details: document.getElementById('chkReportTraceDetails')?.checked ?? true,
      unit_system: 'SI'
    };

    const payload = {
      section_name: this.currentSectionName || 'CFS Custom Section',
      project_name: 'Cold-Formed Steel Structure Design Project',
      metadata: {
        project_name: 'CFDesigner Engineering Project',
        section_name: this.currentSectionName || 'CFS-C150',
        doc_number: 'CALC-CFS-001',
        company: 'Structural Engineering & Design Corp.',
        designed_by: 'Structural Engineer',
        checked_by: 'Senior PE',
        approved_by: 'Lead SE',
        remarks: 'Cold-Formed Steel Design per KDS 14 31 10:2017 & AISI S100-16 DSM'
      },
      options: opts,
      geometry: this.currentGeometry || { elements: [] },
      properties: this.currentProperties || {},
      material: this.currentMaterial || { fy: 275.0, fu: 410.0, e: 205000.0, name: 'SS275' },
      fsm: this.currentFsmResult || this.lastFsmResult || {},
      design: this.currentDesignResult || this.lastDesignResult || {},
      loads: {
        pu: parseFloat(document.getElementById('loadPu')?.value) || 0,
        mux: parseFloat(document.getElementById('loadMux')?.value) || 0,
        muy: parseFloat(document.getElementById('loadMuy')?.value) || 0,
        vu: parseFloat(document.getElementById('loadVu')?.value) || 0,
        ru: parseFloat(document.getElementById('cripRuInput')?.value) || 0
      },
      analysis_1d: this.lastFrameResult || {}
    };

    try {
      const res = await fetch('/api/report/html', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(payload)
      });

      if (!res.ok) {
        throw new Error(`Report API Error: ${res.statusText}`);
      }

      const data = await res.json();
      const html = data.html || '';

      iframe.srcdoc = html;
      this.showStatus('✅ 구조계산서 렌더링 완료', 'ready', 2000);

    } catch (err) {
      console.error('Report Generation Error:', err);
      this.showStatus('❌ 구조계산서 생성 오류', 'warning', 3000);
    }
  };

  AppClass.prototype.exportSectionDxf = function() {
    if (!this.currentGeometry || !this.currentGeometry.elements) {
      alert('내보낼 단면 기하 데이터가 없습니다.');
      return;
    }

    let dxf = "0\nSECTION\n2\nENTITIES\n";
    this.currentGeometry.elements.forEach(el => {
      const x0 = el.x0 !== undefined ? el.x0 : el[1];
      const y0 = el.y0 !== undefined ? el.y0 : el[2];
      const x1 = el.x1 !== undefined ? el.x1 : el[3];
      const y1 = el.y1 !== undefined ? el.y1 : el[4];
      dxf += `0\nLINE\n8\nCFS_SECTION\n10\n${x0}\n20\n${y0}\n30\n0.0\n11\n${x1}\n21\n${y1}\n31\n0.0\n`;
    });
    dxf += "0\nENDSEC\n0\nEOF\n";

    const blob = new Blob([dxf], { type: 'application/dxf' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `CFS_Section_${Date.now()}.dxf`;
    a.click();
    URL.revokeObjectURL(url);
    this.showStatus('✅ CAD DXF 파일 다운로드 완료', 'ready', 2500);
  };

  AppClass.prototype.exportSectionCsv = function() {
    let csv = "Category,Property,Value,Unit\n";
    if (this.currentProperties) {
      const p = this.currentProperties;
      csv += `Gross Properties,Area (Ag),${p.area || 0},mm2\n`;
      csv += `Gross Properties,Weight,${p.weight || 0},kg/m\n`;
      csv += `Gross Properties,Ix,${p.ix || 0},mm4\n`;
      csv += `Gross Properties,Iy,${p.iy || 0},mm4\n`;
      csv += `Gross Properties,rx,${p.rx || 0},mm\n`;
      csv += `Gross Properties,ry,${p.ry || 0},mm\n`;
      csv += `Gross Properties,J,${p.j || 0},mm4\n`;
      csv += `Gross Properties,Cw,${p.cw || 0},mm6\n`;
    }

    if (this.currentFsmResult && this.currentFsmResult.signature_curve) {
      csv += "\nFSM Curve,Half-Wavelength L (mm),Buckling Load Ratio (Beta),Critical Load Pcr (kN),Mcr (kNm)\n";
      this.currentFsmResult.signature_curve.forEach(pt => {
        csv += `FSM,${pt.length || pt.l},${pt.beta},${pt.p_cr || pt.pcr || ''},${pt.m_cr || pt.mcr || ''}\n`;
      });
    }

    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `CFS_Analysis_Results_${Date.now()}.csv`;
    a.click();
    URL.revokeObjectURL(url);
    this.showStatus('✅ 수치 데이터 CSV 다운로드 완료', 'ready', 2500);
  };

  AppClass.prototype.copySummaryTable = function() {
    let text = "=== CFDesigner 단면 및 부재설계 요약표 ===\n";
    if (this.currentProperties) {
      const p = this.currentProperties;
      text += `[단면 기하성질]\n`;
      text += `Ag: ${p.area} mm² | Ix: ${p.ix} mm⁴ | Iy: ${p.iy} mm⁴ | J: ${p.j} mm⁴ | Cw: ${p.cw} mm⁶\n\n`;
    }
    if (this.currentDesignResult) {
      const d = this.currentDesignResult;
      text += `[KDS 14 31 10 부재설계 D/C]\n`;
      text += `압축: φPn=${d.compression?.phi_pn} kN (D/C = ${d.compression?.dc_ratio})\n`;
      text += `휨: φMn=${d.flexure?.phi_mn} kN·m (D/C = ${d.flexure?.dc_ratio})\n`;
      text += `전단: φVn=${d.shear?.phi_vn} kN (D/C = ${d.shear?.dc_ratio})\n`;
      text += `P-M 조합비: ${d.interaction?.ratio} (${d.interaction?.status})\n`;
    }

    if (navigator.clipboard) {
      navigator.clipboard.writeText(text).then(() => {
        alert('요약표가 클립보드에 복사되었습니다. (엑셀 및 보고서에 붙여넣기 가능)');
        this.showStatus('📋 요약표 클립보드 복사 완료', 'ready', 2500);
      });
    } else {
      prompt('아래 텍스트를 복사하세요:', text);
    }
  };
}
