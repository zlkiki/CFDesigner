// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using RSG.CFS;

[DesignerGenerated]
public class frmBuckleProgress : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("lblLength")]
	internal virtual Label lblLength {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("prgBuckle")]
	internal virtual ProgressBar prgBuckle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("cmdCancel")]
	internal virtual Button cmdCancel {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmBuckleProgress ()
	{
		base.Shown += frmBuckleProgress_Shown;
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
		this.lblLength = new System.Windows.Forms.Label ();
		this.prgBuckle = new System.Windows.Forms.ProgressBar ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.lblLength.Location = new System.Drawing.Point (6, 6);
		this.lblLength.Name = "lblLength";
		this.lblLength.Size = new System.Drawing.Size (296, 17);
		this.lblLength.TabIndex = 0;
		this.lblLength.Text = "Length";
		this.prgBuckle.Location = new System.Drawing.Point (9, 35);
		this.prgBuckle.Name = "prgBuckle";
		this.prgBuckle.Size = new System.Drawing.Size (293, 17);
		this.prgBuckle.TabIndex = 1;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (117, 68);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (309, 105);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.prgBuckle);
		base.Controls.Add (this.lblLength);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBuckleProgress";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Elastic Buckling Progress";
		base.ResumeLayout (false);
	}

	private void frmBuckleProgress_Shown (object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.None;
		Cursor.Current = Cursors.WaitCursor;
		FiniteStrip.FiniteStripAnalysis (CFS.Sections [CFS.intSctNow], CFSInterface.BuckleParametersNow);
		Cursor.Current = Cursors.Default;
		if (base.DialogResult != DialogResult.Cancel) {
			base.DialogResult = DialogResult.OK;
		}
		Close ();
	}
}
