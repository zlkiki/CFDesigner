// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RSG.CFS;

[DesignerGenerated]
public class frmReportDialog : Form
{
	private IContainer components;

	private short hIndex;

	[field: AccessedThroughProperty ("rtfDialog")]
	internal virtual RichTextBox rtfDialog {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdOK {
		[CompilerGenerated]
		get {
			return _cmdOK;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdOK_Click;
			Button button = _cmdOK;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdOK = value;
			button = _cmdOK;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("cmdCancel")]
	internal virtual Button cmdCancel {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblDialog")]
	internal virtual Label lblDialog {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmReportDialog ()
	{
		base.Shown += frmReportDialog_Shown;
		base.Resize += frmReportDialog_Resize;
		base.KeyDown += frmReportDialog_KeyDown;
		base.HelpButtonClicked += frmReportDialog_HelpButtonClicked;
		InitializeComponent ();
	}

	[DebuggerNonUserCode]
	protected override void Dispose (bool disposing)
	{
		try {
			if (disposing && components != null) {
				components.Dispose ();
			}
		} finally {
			base.Dispose (disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent ()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmReportDialog));
		this.rtfDialog = new System.Windows.Forms.RichTextBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblDialog = new System.Windows.Forms.Label ();
		base.SuspendLayout ();
		this.rtfDialog.BackColor = System.Drawing.SystemColors.Window;
		this.rtfDialog.Font = new System.Drawing.Font ("Consolas", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rtfDialog.Location = new System.Drawing.Point (0, 0);
		this.rtfDialog.Name = "rtfDialog";
		this.rtfDialog.ReadOnly = true;
		this.rtfDialog.Size = new System.Drawing.Size (644, 300);
		this.rtfDialog.TabIndex = 0;
		this.rtfDialog.Text = "";
		this.rtfDialog.WordWrap = false;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (460, 306);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 23);
		this.cmdOK.TabIndex = 1;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (541, 306);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 23);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblDialog.Location = new System.Drawing.Point (0, 310);
		this.lblDialog.Name = "lblDialog";
		this.lblDialog.Size = new System.Drawing.Size (440, 16);
		this.lblDialog.TabIndex = 3;
		this.lblDialog.Text = "Select OK to create a report.";
		this.lblDialog.TextAlign = System.Drawing.ContentAlignment.TopRight;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (644, 341);
		base.Controls.Add (this.lblDialog);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.rtfDialog);
		base.HelpButton = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size (660, 1080);
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size (660, 80);
		base.Name = "frmReportDialog";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Computation Results";
		base.ResumeLayout (false);
	}

	private void frmReportDialog_Shown (object sender, EventArgs e)
	{
		if (Conversions.ToByte (base.Tag) == 1) {
			Text = "Computation Results: " + CFSInterface.GetFileNameWithoutExtension (CFS.Sections [CFS.intSctNow].Filename);
			hIndex = CFSInterface.FindSctRptIndex (CFS.Sections [CFS.intSctNow]);
		} else {
			Text = "Computation Results: " + CFSInterface.GetFileNameWithoutExtension (CFS.Analyses [CFS.intAnlNow].Filename);
			hIndex = CFSInterface.FindAnlRptIndex (CFS.Analyses [CFS.intAnlNow]);
		}
		if (hIndex > 0) {
			lblDialog.Text = "Select OK to add to the existing report.";
		}
		rtfDialog.SelectionStart = 0;
		frmReportDialog_Resize (this, null);
	}

	private void frmReportDialog_Resize (object sender, EventArgs e)
	{
		checked {
			rtfDialog.Height = base.ClientSize.Height - 42;
			lblDialog.Top = rtfDialog.Height + 10;
			cmdOK.Top = rtfDialog.Height + 6;
			cmdCancel.Top = rtfDialog.Height + 6;
		}
	}

	private void frmReportDialog_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "reports.htm");
			e.Handled = true;
		}
	}

	private void frmReportDialog_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "reports.htm");
		e.Cancel = true;
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		Hide ();
		bool flag = false;
		if (Conversions.ToByte (base.Tag) == 1) {
			Section section = CFS.Sections [CFS.intSctNow];
			if (hIndex == 0) {
				hIndex = CFSInterface.NewReport ();
				CFS.hdgReport [hIndex].Parent = Conversions.ToByte (base.Tag);
				CFS.hdgReport [hIndex].Filename = section.Filename;
				CFS.hdgReport [hIndex].RevDate = section.RevDate;
				CFS.hdgReport [hIndex].RevBy = section.RevBy;
				CFS.hdgReport [hIndex].Description = section.Description;
				CFS.hdgReport [hIndex].Project = section.Project;
				CFS.hdgReport [hIndex].AppVer = 1400;
				flag = true;
				CFS.frmReport [hIndex].Text = "Report: " + CFSInterface.GetFileNameWithoutExtension (section.Filename) + Strings.Space (1) + Conversions.ToString (section.RevDate);
				CFS.frmReport [hIndex].Tag = Conversions.ToString ((int)hIndex);
				CFS.frmReport [hIndex].Show ();
			} else {
				CFS.frmReport [hIndex].rtfReport.SelectionStart = Strings.Len (CFS.frmReport [hIndex].rtfReport.Text);
				CFS.frmReport [hIndex].rtfReport.SelectedText = Report.strPage;
			}
			section = null;
		} else {
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			if (hIndex == 0) {
				hIndex = CFSInterface.NewReport ();
				CFS.hdgReport [hIndex].Parent = Conversions.ToByte (base.Tag);
				CFS.hdgReport [hIndex].Filename = analysis.Filename;
				CFS.hdgReport [hIndex].RevDate = analysis.RevDate;
				CFS.hdgReport [hIndex].RevBy = analysis.RevBy;
				CFS.hdgReport [hIndex].Description = analysis.Description;
				CFS.hdgReport [hIndex].Project = analysis.Project;
				CFS.hdgReport [hIndex].AppVer = 1400;
				flag = true;
				CFS.frmReport [hIndex].Text = "Report: " + CFSInterface.GetFileNameWithoutExtension (analysis.Filename) + Strings.Space (1) + Conversions.ToString (analysis.RevDate);
				CFS.frmReport [hIndex].Tag = Conversions.ToString ((int)hIndex);
				CFS.frmReport [hIndex].Show ();
			} else {
				CFS.frmReport [hIndex].rtfReport.SelectionStart = Strings.Len (CFS.frmReport [hIndex].rtfReport.Text);
				CFS.frmReport [hIndex].rtfReport.SelectedText = Report.strPage;
			}
			analysis = null;
		}
		CFS.hdgReport [hIndex].AppVer = 1400;
		if (CFS.frmReport [hIndex].WindowState == FormWindowState.Minimized) {
			CFS.frmReport [hIndex].WindowState = FormWindowState.Normal;
		}
		CFS.frmReport [hIndex].Activate ();
		if (flag & (CFS.frmReport [hIndex].WindowState != FormWindowState.Maximized)) {
			CFS.frmReport [hIndex].Width = checked((int)Math.Round ((float)(CFS.frmReport [hIndex].Width - CFS.frmReport [hIndex].ClientSize.Width) + 601f));
		}
		Report.AppendRTF (CFS.frmReport [hIndex].rtfReport, rtfDialog);
		Close ();
		Cursor.Current = Cursors.Default;
	}
}
