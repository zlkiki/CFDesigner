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
public class frmBuckleValue : Form
{
	private IContainer components;

	private short intLengthNow;

	private float DSMValue;

	[field: AccessedThroughProperty ("lblDSMValue")]
	internal virtual Label lblDSMValue {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual RadioButton optLocalBuckling {
		[CompilerGenerated]
		get {
			return _optLocalBuckling;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = opt_Click;
			RadioButton radioButton = _optLocalBuckling;
			if (radioButton != null) {
				radioButton.Click -= value2;
			}
			_optLocalBuckling = value;
			radioButton = _optLocalBuckling;
			if (radioButton != null) {
				radioButton.Click += value2;
			}
		}
	}

	internal virtual RadioButton optDistortionalBuckling {
		[CompilerGenerated]
		get {
			return _optDistortionalBuckling;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = opt_Click;
			RadioButton radioButton = _optDistortionalBuckling;
			if (radioButton != null) {
				radioButton.Click -= value2;
			}
			_optDistortionalBuckling = value;
			radioButton = _optDistortionalBuckling;
			if (radioButton != null) {
				radioButton.Click += value2;
			}
		}
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

	[field: AccessedThroughProperty ("lblWorkRatio")]
	internal virtual Label lblWorkRatio {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmBuckleValue ()
	{
		base.Load += frmBuckleValue_Load;
		base.Shown += frmBuckleValue_Shown;
		base.KeyDown += frmBuckleValue_KeyDown;
		base.HelpButtonClicked += frmBuckleValue_HelpButtonClicked;
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
		this.lblDSMValue = new System.Windows.Forms.Label ();
		this.optLocalBuckling = new System.Windows.Forms.RadioButton ();
		this.optDistortionalBuckling = new System.Windows.Forms.RadioButton ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblWorkRatio = new System.Windows.Forms.Label ();
		base.SuspendLayout ();
		this.lblDSMValue.Location = new System.Drawing.Point (12, 5);
		this.lblDSMValue.Name = "lblDSMValue";
		this.lblDSMValue.Size = new System.Drawing.Size (327, 20);
		this.lblDSMValue.TabIndex = 0;
		this.lblDSMValue.Text = "Pcr/Py = 0.000";
		this.optLocalBuckling.Location = new System.Drawing.Point (15, 48);
		this.optLocalBuckling.Name = "optLocalBuckling";
		this.optLocalBuckling.Size = new System.Drawing.Size (324, 20);
		this.optLocalBuckling.TabIndex = 2;
		this.optLocalBuckling.Tag = "Replace local buckling value of ";
		this.optLocalBuckling.Text = "Replace local buckling value of ";
		this.optLocalBuckling.UseVisualStyleBackColor = true;
		this.optDistortionalBuckling.Location = new System.Drawing.Point (15, 74);
		this.optDistortionalBuckling.Name = "optDistortionalBuckling";
		this.optDistortionalBuckling.Size = new System.Drawing.Size (324, 20);
		this.optDistortionalBuckling.TabIndex = 3;
		this.optDistortionalBuckling.Tag = "Replace distortional buckling value of ";
		this.optDistortionalBuckling.Text = "Replace distortional buckling value of ";
		this.optDistortionalBuckling.UseVisualStyleBackColor = true;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (81, 109);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 4;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (186, 109);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 5;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblWorkRatio.Location = new System.Drawing.Point (12, 25);
		this.lblWorkRatio.Name = "lblWorkRatio";
		this.lblWorkRatio.Size = new System.Drawing.Size (327, 20);
		this.lblWorkRatio.TabIndex = 6;
		this.lblWorkRatio.Text = "Work ratio = 0.000";
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (342, 145);
		base.Controls.Add (this.lblWorkRatio);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.optDistortionalBuckling);
		base.Controls.Add (this.optLocalBuckling);
		base.Controls.Add (this.lblDSMValue);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBuckleValue";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Apply Direct Strength Value";
		base.ResumeLayout (false);
	}

	private void frmBuckleValue_Load (object sender, EventArgs e)
	{
		Section section = CFS.Sections [CFS.intSctNow];
		intLengthNow = checked((short)Math.Round (Conversion.Val (RuntimeHelpers.GetObjectValue (base.Tag))));
		lblWorkRatio.Text = "Work ratio = " + Units.DisplayNone (FiniteStrip.Buckle [intLengthNow].WorkRatio, "", 0, 0);
		DSMValue = FiniteStrip.Buckle [intLengthNow].LF / section.Material.Fy [2];
		if (CFSInterface.BuckleParametersNow.Fc == 1f) {
			lblDSMValue.Text = "Compression: Pcr/Py = " + Units.DisplayNone (DSMValue, "", 0, 0);
			optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Pcrl, "", 0, 0)));
			optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Pcrd, "", 0, 0)));
		} else if (Math.Abs (CFSInterface.BuckleParametersNow.Fbx) == 1f) {
			if (section.HasSymmetry (Symmetry.PrincipalX) & section.HasSymmetryNet (Symmetry.PrincipalX)) {
				lblDSMValue.Text = "Positive and Negative Mx: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlxp, "", 0, 0)), " and "), Units.DisplayNone (section.DSM.Mcrlxn, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdxp, "", 0, 0)), " and "), Units.DisplayNone (section.DSM.Mcrdxn, "", 0, 0)));
			} else if (CFSInterface.BuckleParametersNow.Fbx == 1f) {
				lblDSMValue.Text = "Positive Mx: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlxp, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdxp, "", 0, 0)));
			} else {
				lblDSMValue.Text = "Negative Mx: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlxn, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdxn, "", 0, 0)));
			}
		} else if (Math.Abs (CFSInterface.BuckleParametersNow.Fby) == 1f) {
			if (section.HasSymmetry (Symmetry.PrincipalY) & section.HasSymmetryNet (Symmetry.PrincipalY)) {
				lblDSMValue.Text = "Positive and Negative My: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlyp, "", 0, 0)), " and "), Units.DisplayNone (section.DSM.Mcrlyn, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdyp, "", 0, 0)), " and "), Units.DisplayNone (section.DSM.Mcrdyn, "", 0, 0)));
			} else if (CFSInterface.BuckleParametersNow.Fby == 1f) {
				lblDSMValue.Text = "Positive My: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlyp, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdyp, "", 0, 0)));
			} else {
				lblDSMValue.Text = "Negative My: Mcr/My = " + Units.DisplayNone (DSMValue, "", 0, 0);
				optLocalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optLocalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrlyn, "", 0, 0)));
				optDistortionalBuckling.Text = Conversions.ToString (Operators.ConcatenateObject (optDistortionalBuckling.Tag, Units.DisplayNone (section.DSM.Mcrdyn, "", 0, 0)));
			}
		} else {
			lblDSMValue.Text = "Stress distribution prevents assignment to Direct Strength.";
			optLocalBuckling.Visible = false;
			optDistortionalBuckling.Visible = false;
		}
		section = null;
		cmdOK.Enabled = false;
	}

	private void frmBuckleValue_Shown (object sender, EventArgs e)
	{
		_ = CFS.Sections [CFS.intSctNow];
		optLocalBuckling.Checked = false;
		optDistortionalBuckling.Checked = false;
		if (FiniteStrip.IsLocalBuckling (FiniteStrip.Buckle [intLengthNow].WorkRatio)) {
			optLocalBuckling.Checked = true;
			cmdOK.Enabled = true;
		} else if (FiniteStrip.IsDistortionalBuckling (FiniteStrip.Buckle [intLengthNow].WorkRatio)) {
			optDistortionalBuckling.Checked = true;
			cmdOK.Enabled = true;
		}
		_ = null;
	}

	private void frmBuckleValue_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-results.htm");
			e.Handled = true;
		}
	}

	private void frmBuckleValue_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-results.htm");
		e.Cancel = true;
	}

	private void opt_Click (object sender, EventArgs e)
	{
		cmdOK.Enabled = true;
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		CFSInterface.StoreUndoSct ("Direct Strength Value");
		Section section = CFS.Sections [CFS.intSctNow];
		if (CFSInterface.BuckleParametersNow.Fc == 1f) {
			if (optLocalBuckling.Checked) {
				section.DSM.Pcrl = DSMValue;
			} else {
				section.DSM.Pcrd = DSMValue;
			}
		} else if (Math.Abs (CFSInterface.BuckleParametersNow.Fbx) == 1f) {
			if ((CFSInterface.BuckleParametersNow.Fbx == 1f) | (section.HasSymmetry (Symmetry.PrincipalX) & section.HasSymmetryNet (Symmetry.PrincipalX))) {
				if (optLocalBuckling.Checked) {
					section.DSM.Mcrlxp = DSMValue;
				} else {
					section.DSM.Mcrdxp = DSMValue;
				}
			}
			if ((CFSInterface.BuckleParametersNow.Fbx == -1f) | (section.HasSymmetry (Symmetry.PrincipalX) & section.HasSymmetryNet (Symmetry.PrincipalX))) {
				if (optLocalBuckling.Checked) {
					section.DSM.Mcrlxn = DSMValue;
				} else {
					section.DSM.Mcrdxn = DSMValue;
				}
			}
		} else if (Math.Abs (CFSInterface.BuckleParametersNow.Fby) == 1f) {
			if ((CFSInterface.BuckleParametersNow.Fby == 1f) | (section.HasSymmetry (Symmetry.PrincipalY) & section.HasSymmetryNet (Symmetry.PrincipalY))) {
				if (optLocalBuckling.Checked) {
					section.DSM.Mcrlyp = DSMValue;
				} else {
					section.DSM.Mcrdyp = DSMValue;
				}
			}
			if ((CFSInterface.BuckleParametersNow.Fby == -1f) | (section.HasSymmetry (Symmetry.PrincipalY) & section.HasSymmetryNet (Symmetry.PrincipalY))) {
				if (optLocalBuckling.Checked) {
					section.DSM.Mcrlyn = DSMValue;
				} else {
					section.DSM.Mcrdyn = DSMValue;
				}
			}
		}
		section.GeomChangeDSM = false;
		section.Saved = false;
		section.RevDate = DateAndTime.Now;
		section.RevBy = CFS.User.Name;
		CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
		CFSInterface.SetMenuEdit ();
		section = null;
		CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		Close ();
	}
}
