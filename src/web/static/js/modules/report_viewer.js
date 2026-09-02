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
}
