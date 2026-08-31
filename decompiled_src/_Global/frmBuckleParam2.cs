// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmBuckleParam2 : Form
{
	private IContainer components;

	private BuckleParameters BuckleParametersTmp;

	private float Fc;

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

	[field: AccessedThroughProperty ("chkConstrained")]
	internal virtual CheckBox chkConstrained {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("chkAltMethod")]
	internal virtual CheckBox chkAltMethod {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("chkRepeat")]
	internal virtual CheckBox chkRepeat {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmBuckleParam2 ()
	{
		base.Load += frmBuckleParam2_Load;
		base.KeyDown += frmBuckleParam2_KeyDown;
		base.HelpButtonClicked += frmBuckleParam2_HelpButtonClicked;
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
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.chkConstrained = new System.Windows.Forms.CheckBox ();
		this.chkAltMethod = new System.Windows.Forms.CheckBox ();
		this.chkRepeat = new System.Windows.Forms.CheckBox ();
		base.SuspendLayout ();
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (30, 90);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (91, 25);
		this.cmdOK.TabIndex = 17;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (127, 90);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (91, 25);
		this.cmdCancel.TabIndex = 18;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.chkConstrained.Location = new System.Drawing.Point (12, 38);
		this.chkConstrained.Name = "chkConstrained";
		this.chkConstrained.Size = new System.Drawing.Size (246, 20);
		this.chkConstrained.TabIndex = 7;
		this.chkConstrained.Text = "Constrained Bending";
		this.chkConstrained.UseVisualStyleBackColor = true;
		this.chkAltMethod.Location = new System.Drawing.Point (12, 12);
		this.chkAltMethod.Name = "chkAltMethod";
		this.chkAltMethod.Size = new System.Drawing.Size (246, 20);
		this.chkAltMethod.TabIndex = 6;
		this.chkAltMethod.Text = "Use Alternate Method (slower)";
		this.chkAltMethod.UseVisualStyleBackColor = true;
		this.chkRepeat.Location = new System.Drawing.Point (12, 64);
		this.chkRepeat.Name = "chkRepeat";
		this.chkRepeat.Size = new System.Drawing.Size (246, 20);
		this.chkRepeat.TabIndex = 19;
		this.chkRepeat.Text = "Repeating connected shape (e.g., panel)";
		this.chkRepeat.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (254, 127);
		base.Controls.Add (this.chkRepeat);
		base.Controls.Add (this.chkAltMethod);
		base.Controls.Add (this.chkConstrained);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBuckleParam2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Elastic Buckling Parameters";
		base.ResumeLayout (false);
	}

	private void frmBuckleParam2_Load (object sender, EventArgs e)
	{
		BuckleParametersTmp = CFSInterface.BuckleParametersNow;
		CFS.blnValidate = false;
		ref BuckleParameters buckleParametersTmp = ref BuckleParametersTmp;
		if (buckleParametersTmp.intSection != CFS.intSctNow) {
			buckleParametersTmp.intSection = CFS.intSctNow;
			buckleParametersTmp.Repeat = false;
		}
		chkConstrained.Checked = BuckleParametersTmp.Constrained;
		chkAltMethod.Checked = BuckleParametersTmp.AltMethod;
		if ((CFS.Sections [CFS.intSctNow].nPart > 1) | CFS.Sections [CFS.intSctNow].Part [1].Closed) {
			chkRepeat.Checked = false;
			chkRepeat.Enabled = false;
		} else {
			chkRepeat.Checked = BuckleParametersTmp.Repeat;
		}
		CFS.blnValidate = true;
	}

	private void frmBuckleParam2_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-parameters.htm");
			e.Handled = true;
		}
	}

	private void frmBuckleParam2_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-parameters.htm");
		e.Cancel = true;
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			CFS.LicenseRequired ("This calculation requires a full CFS license.");
			return;
		}
		BuckleParametersTmp.Constrained = chkConstrained.Checked;
		BuckleParametersTmp.AltMethod = chkAltMethod.Checked;
		BuckleParametersTmp.Repeat = chkRepeat.Checked;
		CFSInterface.BuckleParametersNow = BuckleParametersTmp;
		Hide ();
		My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS);
		if (My.MyProject.Forms.frmBuckleProgress.DialogResult != DialogResult.Cancel) {
			My.MyProject.Forms.frmBuckleProfile.ShowDialog (My.MyProject.Forms.mdiCFS);
			My.MyProject.Forms.frmBuckleProfile.Dispose ();
		}
		My.MyProject.Forms.frmBuckleProgress.Dispose ();
		Close ();
	}
}
