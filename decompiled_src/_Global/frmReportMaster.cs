// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmReportMaster : Form
{
	private IContainer components;

	private short Shift;

	internal virtual RichTextBox rtfReport {
		[CompilerGenerated]
		get {
			return _rtfReport;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			MouseEventHandler value2 = rtfReport_MouseDown;
			RichTextBox richTextBox = _rtfReport;
			if (richTextBox != null) {
				richTextBox.MouseDown -= value2;
			}
			_rtfReport = value;
			richTextBox = _rtfReport;
			if (richTextBox != null) {
				richTextBox.MouseDown += value2;
			}
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmReportMaster));
		this.rtfReport = new System.Windows.Forms.RichTextBox ();
		base.SuspendLayout ();
		this.rtfReport.BackColor = System.Drawing.SystemColors.Window;
		this.rtfReport.Font = new System.Drawing.Font ("Consolas", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rtfReport.HideSelection = false;
		this.rtfReport.Location = new System.Drawing.Point (0, 0);
		this.rtfReport.Name = "rtfReport";
		this.rtfReport.ReadOnly = true;
		this.rtfReport.Size = new System.Drawing.Size (412, 305);
		this.rtfReport.TabIndex = 0;
		this.rtfReport.Text = "";
		this.rtfReport.WordWrap = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (485, 361);
		base.Controls.Add (this.rtfReport);
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size (100, 100);
		base.Name = "frmReportMaster";
		this.Text = "Report";
		base.ResumeLayout (false);
	}

	public frmReportMaster (byte Index)
	{
		base.Activated += frmReportMaster_Activated;
		base.FormClosing += frmReportMaster_FormClosing;
		base.KeyDown += frmReportMaster_KeyDown;
		base.KeyUp += frmReportMaster_KeyUp;
		base.Resize += frmReportMaster_Resize;
		base.MdiParent = My.MyProject.Forms.mdiCFS;
		base.Tag = Conversions.ToString (Index);
		InitializeComponent ();
	}

	private void frmReportMaster_Activated (object sender, EventArgs e)
	{
		CFSInterface.SetMenuFile ();
		CFSInterface.SetMenuEdit ();
		CFSInterface.SetMenuCompute ();
	}

	private void frmReportMaster_FormClosing (object sender, FormClosingEventArgs e)
	{
		CFS.hdgReport [Conversions.ToByte (base.Tag)].Initialize ();
		CFS.frmReport [Conversions.ToByte (base.Tag)] = null;
		if (e.CloseReason == CloseReason.UserClosing && My.MyProject.Forms.mdiCFS.MdiChildren.Count () == 0) {
			base.Tag = string.Empty;
			CFSInterface.SetMenuFile ();
			CFSInterface.SetMenuEdit ();
			CFSInterface.SetMenuCompute ();
		}
	}

	private void frmReportMaster_KeyDown (object sender, KeyEventArgs e)
	{
		Shift = 0;
		checked {
			if (e.Shift) {
				ref short shift = ref Shift;
				shift = (short)unchecked(shift + 1);
			}
			if (e.Control) {
				ref short shift2 = ref Shift;
				shift2 = (short)unchecked(shift2 + 2);
			}
			if (e.Alt) {
				ref short shift3 = ref Shift;
				shift3 = (short)unchecked(shift3 + 4);
			}
			if (e.KeyCode == Keys.F1) {
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "reports.htm");
				e.Handled = true;
			}
		}
	}

	private void frmReportMaster_KeyUp (object sender, KeyEventArgs e)
	{
		Shift = 0;
		checked {
			if (e.Shift) {
				ref short shift = ref Shift;
				shift = (short)unchecked(shift + 1);
			}
			if (e.Control) {
				ref short shift2 = ref Shift;
				shift2 = (short)unchecked(shift2 + 2);
			}
			if (e.Alt) {
				ref short shift3 = ref Shift;
				shift3 = (short)unchecked(shift3 + 4);
			}
		}
	}

	private void frmReportMaster_Resize (object sender, EventArgs e)
	{
		rtfReport.Width = base.ClientSize.Width;
		rtfReport.Height = base.ClientSize.Height;
	}

	private void rtfReport_MouseDown (object sender, MouseEventArgs e)
	{
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild == this && ((e.Button == MouseButtons.Right) & (Shift == 0))) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}
}
