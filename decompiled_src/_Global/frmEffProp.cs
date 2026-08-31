// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmEffProp : Form
{
	private IContainer components;

	private float fP;

	private float RP;

	private float Pn;

	private float Tn;

	private float fMx;

	private float RMx;

	private float Mnxp;

	private float Mnxn;

	private float fMy;

	private float RMy;

	private float Mnyp;

	private float Mnyn;

	internal virtual ComboBox cboP {
		[CompilerGenerated]
		get {
			return _cboP;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cbo_GotFocus;
			KeyPressEventHandler value3 = cbo_KeyPress;
			EventHandler value4 = cbo_TextChanged;
			EventHandler value5 = cbo_DropDown;
			EventHandler value6 = cbo_SelectedIndexChanged;
			CancelEventHandler value7 = cbo_Validating;
			ComboBox comboBox = _cboP;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboP = value;
			comboBox = _cboP;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblP")]
	internal virtual Label lblP {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblMx")]
	internal virtual Label lblMx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboMx {
		[CompilerGenerated]
		get {
			return _cboMx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cbo_GotFocus;
			KeyPressEventHandler value3 = cbo_KeyPress;
			EventHandler value4 = cbo_TextChanged;
			EventHandler value5 = cbo_DropDown;
			EventHandler value6 = cbo_SelectedIndexChanged;
			CancelEventHandler value7 = cbo_Validating;
			ComboBox comboBox = _cboMx;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboMx = value;
			comboBox = _cboMx;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMy")]
	internal virtual Label lblMy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboMy {
		[CompilerGenerated]
		get {
			return _cboMy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cbo_GotFocus;
			KeyPressEventHandler value3 = cbo_KeyPress;
			EventHandler value4 = cbo_TextChanged;
			EventHandler value5 = cbo_DropDown;
			EventHandler value6 = cbo_SelectedIndexChanged;
			CancelEventHandler value7 = cbo_Validating;
			ComboBox comboBox = _cboMy;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboMy = value;
			comboBox = _cboMy;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRP")]
	internal virtual Label lblRP {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtRP {
		[CompilerGenerated]
		get {
			return _txtRP;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtRP;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtRP = value;
			textBox = _txtRP;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRMx")]
	internal virtual Label lblRMx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtRMx {
		[CompilerGenerated]
		get {
			return _txtRMx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtRMx;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtRMx = value;
			textBox = _txtRMx;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRMy")]
	internal virtual Label lblRMy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtRMy {
		[CompilerGenerated]
		get {
			return _txtRMy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtRMy;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtRMy = value;
			textBox = _txtRMy;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("cmdCancel")]
	internal virtual Button cmdCancel {
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

	public frmEffProp ()
	{
		base.Load += frmEffProp_Load;
		base.KeyDown += frmEffProp_KeyDown;
		base.HelpButtonClicked += frmEffProp_HelpButtonClicked;
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
		this.cboP = new System.Windows.Forms.ComboBox ();
		this.lblP = new System.Windows.Forms.Label ();
		this.lblMx = new System.Windows.Forms.Label ();
		this.cboMx = new System.Windows.Forms.ComboBox ();
		this.lblMy = new System.Windows.Forms.Label ();
		this.cboMy = new System.Windows.Forms.ComboBox ();
		this.lblRP = new System.Windows.Forms.Label ();
		this.txtRP = new System.Windows.Forms.TextBox ();
		this.lblRMx = new System.Windows.Forms.Label ();
		this.txtRMx = new System.Windows.Forms.TextBox ();
		this.lblRMy = new System.Windows.Forms.Label ();
		this.txtRMy = new System.Windows.Forms.TextBox ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.cmdOK = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.cboP.FormattingEnabled = true;
		this.cboP.Location = new System.Drawing.Point (214, 16);
		this.cboP.Name = "cboP";
		this.cboP.Size = new System.Drawing.Size (100, 21);
		this.cboP.TabIndex = 7;
		this.lblP.Location = new System.Drawing.Point (172, 19);
		this.lblP.Name = "lblP";
		this.lblP.Size = new System.Drawing.Size (36, 17);
		this.lblP.TabIndex = 6;
		this.lblP.Text = "P";
		this.lblMx.Location = new System.Drawing.Point (172, 46);
		this.lblMx.Name = "lblMx";
		this.lblMx.Size = new System.Drawing.Size (36, 17);
		this.lblMx.TabIndex = 8;
		this.lblMx.Text = "Mx";
		this.cboMx.FormattingEnabled = true;
		this.cboMx.Location = new System.Drawing.Point (214, 43);
		this.cboMx.Name = "cboMx";
		this.cboMx.Size = new System.Drawing.Size (100, 21);
		this.cboMx.TabIndex = 9;
		this.lblMy.Location = new System.Drawing.Point (172, 73);
		this.lblMy.Name = "lblMy";
		this.lblMy.Size = new System.Drawing.Size (36, 17);
		this.lblMy.TabIndex = 10;
		this.lblMy.Text = "My";
		this.cboMy.FormattingEnabled = true;
		this.cboMy.Location = new System.Drawing.Point (214, 70);
		this.cboMy.Name = "cboMy";
		this.cboMy.Size = new System.Drawing.Size (100, 21);
		this.cboMy.TabIndex = 11;
		this.lblRP.Location = new System.Drawing.Point (12, 19);
		this.lblRP.Name = "lblRP";
		this.lblRP.Size = new System.Drawing.Size (48, 17);
		this.lblRP.TabIndex = 0;
		this.lblRP.Text = "P/Pn";
		this.txtRP.Location = new System.Drawing.Point (74, 16);
		this.txtRP.Name = "txtRP";
		this.txtRP.Size = new System.Drawing.Size (80, 20);
		this.txtRP.TabIndex = 1;
		this.txtRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.lblRMx.Location = new System.Drawing.Point (12, 46);
		this.lblRMx.Name = "lblRMx";
		this.lblRMx.Size = new System.Drawing.Size (48, 17);
		this.lblRMx.TabIndex = 2;
		this.lblRMx.Text = "Mx/Mnx";
		this.txtRMx.Location = new System.Drawing.Point (74, 43);
		this.txtRMx.Name = "txtRMx";
		this.txtRMx.Size = new System.Drawing.Size (80, 20);
		this.txtRMx.TabIndex = 3;
		this.txtRMx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.lblRMy.Location = new System.Drawing.Point (12, 73);
		this.lblRMy.Name = "lblRMy";
		this.lblRMy.Size = new System.Drawing.Size (48, 17);
		this.lblRMy.TabIndex = 4;
		this.lblRMy.Text = "My/Mny";
		this.txtRMy.Location = new System.Drawing.Point (74, 70);
		this.txtRMy.Name = "txtRMy";
		this.txtRMy.Size = new System.Drawing.Size (80, 20);
		this.txtRMy.TabIndex = 5;
		this.txtRMy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (239, 107);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 13;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (158, 107);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 12;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (346, 141);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.txtRMy);
		base.Controls.Add (this.lblRMy);
		base.Controls.Add (this.txtRMx);
		base.Controls.Add (this.lblRMx);
		base.Controls.Add (this.txtRP);
		base.Controls.Add (this.lblRP);
		base.Controls.Add (this.cboMy);
		base.Controls.Add (this.lblMy);
		base.Controls.Add (this.cboMx);
		base.Controls.Add (this.lblMx);
		base.Controls.Add (this.lblP);
		base.Controls.Add (this.cboP);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmEffProp";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "frmEffProp";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmEffProp_Load (object sender, EventArgs e)
	{
		Text = "Internal Forces: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		ref Section.StrengthType strength = ref CFS.Sections [CFS.intSctNow].Strength;
		Pn = strength.Pno;
		Tn = strength.Tn;
		Mnxp = strength.Mnxop;
		Mnxn = strength.Mnxon;
		Mnyp = strength.Mnyop;
		Mnyn = strength.Mnyon;
		fP = CFSInterface.MemberParametersNow.P;
		fMx = CFSInterface.MemberParametersNow.Mx;
		fMy = CFSInterface.MemberParametersNow.My;
		RP = Conversions.ToSingle (Interaction.IIf (fP >= 0f, fP / Pn, fP / Tn));
		RMx = Conversions.ToSingle (Interaction.IIf (fMx >= 0f, fMx / Mnxp, fMx / Mnxn));
		RMy = Conversions.ToSingle (Interaction.IIf (fMy >= 0f, fMy / Mnyp, fMy / Mnyn));
		if ((fP == 0f) & (fMx == 0f) & (fMy == 0f)) {
			RMx = 0.6f;
			fMx = RMx * Mnxp;
		}
		cboP.Tag = new ControlData (4, -1000f, 1000f);
		cboMx.Tag = new ControlData (6, -100000f, 100000f);
		cboMy.Tag = new ControlData (6, -100000f, 100000f);
		txtRP.Tag = new ControlData (0, -1000f / Tn, 1000f / Pn);
		txtRMx.Tag = new ControlData (0, -1000f / Mnxn, 1000f / Mnxp);
		txtRMy.Tag = new ControlData (0, -1000f / Mnyn, 1000f / Mnyp);
		CFS.blnValidate = false;
		CFSInterface.SetText (cboP, fP);
		CFSInterface.SetText (cboMx, fMx);
		CFSInterface.SetText (cboMy, fMy);
		CFSInterface.SetText (txtRP, RP);
		CFSInterface.SetText (txtRMx, RMx);
		CFSInterface.SetText (txtRMy, RMy);
		CFS.blnValidate = true;
	}

	private void frmEffProp_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "effective-properties.htm");
			e.Handled = true;
		}
	}

	private void frmEffProp_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "effective-properties.htm");
		e.Cancel = true;
	}

	private void cbo_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cbo_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cbo_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cbo_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void cbo_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cbo_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void cbo_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cbo_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboP)) {
				fP = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				RP = Conversions.ToSingle (Interaction.IIf (fP >= 0f, fP / Pn, fP / Tn));
				CFSInterface.SetText (txtRP, RP);
			} else if (flag == (sender == cboMx)) {
				fMx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				RMx = Conversions.ToSingle (Interaction.IIf (fMx >= 0f, fMx / Mnxp, fMx / Mnxn));
				CFSInterface.SetText (txtRMx, RMx);
			} else if (flag == (sender == cboMy)) {
				fMy = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				RMy = Conversions.ToSingle (Interaction.IIf (fMy >= 0f, fMy / Mnyp, fMy / Mnyn));
				CFSInterface.SetText (txtRMy, RMy);
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void txt_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void txt_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			txt_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			txt_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void txt_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void txt_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == txtRP)) {
				RP = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				fP = Conversions.ToSingle (Interaction.IIf (RP >= 0f, RP * Pn, RP * Tn));
				CFSInterface.SetText (cboP, fP);
			} else if (flag == (sender == txtRMx)) {
				RMx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				fMx = Conversions.ToSingle (Interaction.IIf (RMx >= 0f, RMx * Mnxp, RMx * Mnxn));
				CFSInterface.SetText (cboMx, fMx);
			} else if (flag == (sender == txtRMy)) {
				RMy = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				fMy = Conversions.ToSingle (Interaction.IIf (RMy >= 0f, RMy * Mnyp, RMy * Mnyn));
				CFSInterface.SetText (cboMy, fMy);
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		Hide ();
		CFSInterface.MemberParametersNow.P = fP;
		CFSInterface.MemberParametersNow.Mx = fMx;
		CFSInterface.MemberParametersNow.My = fMy;
		if (Report.rptEffProperties (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow], fP, fMx, fMy, CFS.intSpecNow)) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (My.MyProject.Forms.mdiCFS);
			My.MyProject.Forms.frmReportDialog.Dispose ();
			Close ();
		}
	}
}
