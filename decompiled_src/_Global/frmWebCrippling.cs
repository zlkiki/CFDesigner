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
public class frmWebCrippling : Form
{
	private IContainer components;

	private WebCripParameters WebCripParametersTmp;

	[field: AccessedThroughProperty ("PictureBox1")]
	internal virtual PictureBox PictureBox1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblFlange")]
	internal virtual Label lblFlange {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboFlange {
		[CompilerGenerated]
		get {
			return _cboFlange;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboFlange_SelectedIndexChanged;
			ComboBox comboBox = _cboFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboFlange = value;
			comboBox = _cboFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblLoad")]
	internal virtual Label lblLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLoad {
		[CompilerGenerated]
		get {
			return _cboLoad;
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
			ComboBox comboBox = _cboLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLoad = value;
			comboBox = _cboLoad;
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

	[field: AccessedThroughProperty ("lblMoment")]
	internal virtual Label lblMoment {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboMoment {
		[CompilerGenerated]
		get {
			return _cboMoment;
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
			ComboBox comboBox = _cboMoment;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboMoment = value;
			comboBox = _cboMoment;
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

	[field: AccessedThroughProperty ("lblBearing")]
	internal virtual Label lblBearing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboBearing {
		[CompilerGenerated]
		get {
			return _cboBearing;
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
			ComboBox comboBox = _cboBearing;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboBearing = value;
			comboBox = _cboBearing;
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

	[field: AccessedThroughProperty ("lblFastened")]
	internal virtual Label lblFastened {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboFastened {
		[CompilerGenerated]
		get {
			return _cboFastened;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboFastened_SelectedIndexChanged;
			ComboBox comboBox = _cboFastened;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboFastened = value;
			comboBox = _cboFastened;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblDistanceEnd")]
	internal virtual Label lblDistanceEnd {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboDistanceEnd {
		[CompilerGenerated]
		get {
			return _cboDistanceEnd;
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
			ComboBox comboBox = _cboDistanceEnd;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboDistanceEnd = value;
			comboBox = _cboDistanceEnd;
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

	[field: AccessedThroughProperty ("lblOpposingLoad")]
	internal virtual Label lblOpposingLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboOpposingLoad {
		[CompilerGenerated]
		get {
			return _cboOpposingLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboOpposingLoad_SelectedIndexChanged;
			ComboBox comboBox = _cboOpposingLoad;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboOpposingLoad = value;
			comboBox = _cboOpposingLoad;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblDistanceLoad")]
	internal virtual Label lblDistanceLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboDistanceLoad {
		[CompilerGenerated]
		get {
			return _cboDistanceLoad;
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
			ComboBox comboBox = _cboDistanceLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboDistanceLoad = value;
			comboBox = _cboDistanceLoad;
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

	public frmWebCrippling ()
	{
		base.Load += frmWebCrippling_Load;
		base.KeyDown += frmWebCrippling_KeyDown;
		base.HelpButtonClicked += frmWebCrippling_HelpButtonClicked;
		base.FormClosing += frmWebCrippling_FormClosing;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmWebCrippling));
		this.PictureBox1 = new System.Windows.Forms.PictureBox ();
		this.lblFlange = new System.Windows.Forms.Label ();
		this.cboFlange = new System.Windows.Forms.ComboBox ();
		this.lblLoad = new System.Windows.Forms.Label ();
		this.cboLoad = new System.Windows.Forms.ComboBox ();
		this.lblMoment = new System.Windows.Forms.Label ();
		this.cboMoment = new System.Windows.Forms.ComboBox ();
		this.lblBearing = new System.Windows.Forms.Label ();
		this.cboBearing = new System.Windows.Forms.ComboBox ();
		this.lblFastened = new System.Windows.Forms.Label ();
		this.cboFastened = new System.Windows.Forms.ComboBox ();
		this.lblDistanceEnd = new System.Windows.Forms.Label ();
		this.cboDistanceEnd = new System.Windows.Forms.ComboBox ();
		this.lblOpposingLoad = new System.Windows.Forms.Label ();
		this.cboOpposingLoad = new System.Windows.Forms.ComboBox ();
		this.lblDistanceLoad = new System.Windows.Forms.Label ();
		this.cboDistanceLoad = new System.Windows.Forms.ComboBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit ();
		base.SuspendLayout ();
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject ("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point (8, 9);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size (52, 132);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.lblFlange.Location = new System.Drawing.Point (66, 15);
		this.lblFlange.Name = "lblFlange";
		this.lblFlange.Size = new System.Drawing.Size (170, 17);
		this.lblFlange.TabIndex = 1;
		this.lblFlange.Text = "Load Applied To";
		this.cboFlange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFlange.FormattingEnabled = true;
		this.cboFlange.Location = new System.Drawing.Point (242, 12);
		this.cboFlange.Name = "cboFlange";
		this.cboFlange.Size = new System.Drawing.Size (100, 21);
		this.cboFlange.TabIndex = 2;
		this.lblLoad.Location = new System.Drawing.Point (66, 42);
		this.lblLoad.Name = "lblLoad";
		this.lblLoad.Size = new System.Drawing.Size (170, 17);
		this.lblLoad.TabIndex = 3;
		this.lblLoad.Text = "Concentrated Load or Reaction";
		this.cboLoad.FormattingEnabled = true;
		this.cboLoad.Location = new System.Drawing.Point (242, 39);
		this.cboLoad.Name = "cboLoad";
		this.cboLoad.Size = new System.Drawing.Size (100, 21);
		this.cboLoad.TabIndex = 4;
		this.lblMoment.Location = new System.Drawing.Point (66, 69);
		this.lblMoment.Name = "lblMoment";
		this.lblMoment.Size = new System.Drawing.Size (170, 17);
		this.lblMoment.TabIndex = 5;
		this.lblMoment.Text = "Moment at Location of Load";
		this.cboMoment.FormattingEnabled = true;
		this.cboMoment.Location = new System.Drawing.Point (242, 66);
		this.cboMoment.Name = "cboMoment";
		this.cboMoment.Size = new System.Drawing.Size (100, 21);
		this.cboMoment.TabIndex = 6;
		this.lblBearing.Location = new System.Drawing.Point (66, 96);
		this.lblBearing.Name = "lblBearing";
		this.lblBearing.Size = new System.Drawing.Size (170, 17);
		this.lblBearing.TabIndex = 7;
		this.lblBearing.Text = "Bearing Length";
		this.cboBearing.FormattingEnabled = true;
		this.cboBearing.Location = new System.Drawing.Point (242, 93);
		this.cboBearing.Name = "cboBearing";
		this.cboBearing.Size = new System.Drawing.Size (100, 21);
		this.cboBearing.TabIndex = 8;
		this.lblFastened.Location = new System.Drawing.Point (66, 123);
		this.lblFastened.Name = "lblFastened";
		this.lblFastened.Size = new System.Drawing.Size (170, 17);
		this.lblFastened.TabIndex = 9;
		this.lblFastened.Text = "Flange Fastened to Support";
		this.cboFastened.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFastened.FormattingEnabled = true;
		this.cboFastened.Location = new System.Drawing.Point (242, 120);
		this.cboFastened.Name = "cboFastened";
		this.cboFastened.Size = new System.Drawing.Size (100, 21);
		this.cboFastened.TabIndex = 10;
		this.lblDistanceEnd.Location = new System.Drawing.Point (66, 147);
		this.lblDistanceEnd.Name = "lblDistanceEnd";
		this.lblDistanceEnd.Size = new System.Drawing.Size (170, 31);
		this.lblDistanceEnd.TabIndex = 11;
		this.lblDistanceEnd.Text = "Distance from edge of bearing to end of member";
		this.cboDistanceEnd.FormattingEnabled = true;
		this.cboDistanceEnd.Location = new System.Drawing.Point (242, 147);
		this.cboDistanceEnd.Name = "cboDistanceEnd";
		this.cboDistanceEnd.Size = new System.Drawing.Size (100, 21);
		this.cboDistanceEnd.TabIndex = 12;
		this.lblOpposingLoad.Location = new System.Drawing.Point (66, 181);
		this.lblOpposingLoad.Name = "lblOpposingLoad";
		this.lblOpposingLoad.Size = new System.Drawing.Size (170, 17);
		this.lblOpposingLoad.TabIndex = 13;
		this.lblOpposingLoad.Text = "Opposing Load Type";
		this.cboOpposingLoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboOpposingLoad.FormattingEnabled = true;
		this.cboOpposingLoad.Location = new System.Drawing.Point (242, 178);
		this.cboOpposingLoad.Name = "cboOpposingLoad";
		this.cboOpposingLoad.Size = new System.Drawing.Size (100, 21);
		this.cboOpposingLoad.TabIndex = 14;
		this.lblDistanceLoad.Location = new System.Drawing.Point (66, 205);
		this.lblDistanceLoad.Name = "lblDistanceLoad";
		this.lblDistanceLoad.Size = new System.Drawing.Size (170, 31);
		this.lblDistanceLoad.TabIndex = 15;
		this.lblDistanceLoad.Text = "Distance from edge of bearing to edge of opposite load";
		this.cboDistanceLoad.FormattingEnabled = true;
		this.cboDistanceLoad.Location = new System.Drawing.Point (242, 205);
		this.cboDistanceLoad.Name = "cboDistanceLoad";
		this.cboDistanceLoad.Size = new System.Drawing.Size (100, 21);
		this.cboDistanceLoad.TabIndex = 16;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (186, 244);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 17;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (267, 244);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 18;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (354, 281);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.cboDistanceLoad);
		base.Controls.Add (this.lblDistanceLoad);
		base.Controls.Add (this.cboOpposingLoad);
		base.Controls.Add (this.lblOpposingLoad);
		base.Controls.Add (this.cboDistanceEnd);
		base.Controls.Add (this.lblDistanceEnd);
		base.Controls.Add (this.cboFastened);
		base.Controls.Add (this.lblFastened);
		base.Controls.Add (this.cboBearing);
		base.Controls.Add (this.lblBearing);
		base.Controls.Add (this.cboMoment);
		base.Controls.Add (this.lblMoment);
		base.Controls.Add (this.cboLoad);
		base.Controls.Add (this.lblLoad);
		base.Controls.Add (this.cboFlange);
		base.Controls.Add (this.lblFlange);
		base.Controls.Add (this.PictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmWebCrippling";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Web Crippling Parameters";
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit ();
		base.ResumeLayout (false);
	}

	private void frmWebCrippling_Load (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		Text = "Web Crippling Parameters: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		cboLoad.Tag = new ControlData (4, 0f, 1000f);
		cboMoment.Tag = new ControlData (6, -100000f, 100000f);
		cboBearing.Tag = new ControlData (1, 0.75f, 100f);
		cboDistanceEnd.Tag = new ControlData (2, 0f, 1200f);
		cboDistanceLoad.Tag = new ControlData (2, 0f, 1200f);
		WebCripParametersTmp = CFSInterface.WebCripParametersNow;
		WebCripParametersTmp.Spec = (Specifications)CFS.intSpecNow;
		cboFlange.Items.Add ("Bottom Flange");
		cboFlange.Items.Add ("Top Flange");
		cboFlange.Items.Add ("Left Flange");
		cboFlange.Items.Add ("Right Flange");
		cboFastened.Items.Add ("Yes");
		cboFastened.Items.Add ("No");
		cboOpposingLoad.Items.Add ("Concentrated");
		cboOpposingLoad.Items.Add ("Distributed");
		CFS.blnValidate = false;
		ref WebCripParameters webCripParametersTmp = ref WebCripParametersTmp;
		short selectedIndex = default(short);
		if (webCripParametersTmp.Dir == LoadDirections.dirY) {
			selectedIndex = ((!(webCripParametersTmp.P >= 0f)) ? ((short)1) : ((short)0));
		} else if (webCripParametersTmp.Dir == LoadDirections.dirX) {
			selectedIndex = (short)((!(webCripParametersTmp.P >= 0f)) ? 3 : 2);
		}
		webCripParametersTmp.P = Math.Abs (webCripParametersTmp.P);
		if ((double)webCripParametersTmp.P <= 1E-06) {
			webCripParametersTmp.P = 0f;
		}
		cboFlange.SelectedIndex = selectedIndex;
		CFSInterface.SetText (cboLoad, webCripParametersTmp.P);
		CFSInterface.SetText (cboMoment, webCripParametersTmp.M);
		CFSInterface.SetText (cboBearing, webCripParametersTmp.N);
		CFSInterface.SetText (cboDistanceEnd, webCripParametersTmp.Zend);
		if (webCripParametersTmp.Zload < 1200f) {
			cboOpposingLoad.SelectedIndex = 0;
			CFSInterface.SetText (cboDistanceLoad, webCripParametersTmp.Zload);
			cboDistanceLoad.Enabled = true;
		} else {
			cboOpposingLoad.SelectedIndex = 1;
			cboDistanceLoad.Text = string.Empty;
			cboDistanceLoad.Enabled = false;
			webCripParametersTmp.Zload = 0f;
		}
		cboFastened.SelectedIndex = Conversions.ToInteger (Interaction.IIf (webCripParametersTmp.Fastened, 0, 1));
		CFS.blnValidate = true;
		Cursor.Current = Cursors.WaitCursor;
	}

	private void frmWebCrippling_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "web-crippling-parameters.htm");
			e.Handled = true;
		}
	}

	private void frmWebCrippling_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "web-crippling-parameters.htm");
		e.Cancel = true;
	}

	private void frmWebCrippling_FormClosing (object sender, FormClosingEventArgs e)
	{
		cboFlange.Select ();
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
			ref WebCripParameters webCripParametersTmp = ref WebCripParametersTmp;
			bool flag = true;
			if (flag == (sender == cboLoad)) {
				webCripParametersTmp.P = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboMoment)) {
				webCripParametersTmp.M = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboBearing)) {
				webCripParametersTmp.N = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboDistanceEnd)) {
				webCripParametersTmp.Zend = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboDistanceLoad)) {
				webCripParametersTmp.Zload = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void cboFlange_SelectedIndexChanged (object sender, EventArgs e)
	{
		switch (cboFlange.SelectedIndex) {
		case 0:
		case 1:
			WebCripParametersTmp.Dir = LoadDirections.dirY;
			break;
		case 2:
		case 3:
			WebCripParametersTmp.Dir = LoadDirections.dirX;
			break;
		}
	}

	private void cboFastened_SelectedIndexChanged (object sender, EventArgs e)
	{
		switch (cboFastened.SelectedIndex) {
		case 0:
			WebCripParametersTmp.Fastened = true;
			break;
		case 1:
			WebCripParametersTmp.Fastened = false;
			break;
		}
	}

	private void cboOpposingLoad_SelectedIndexChanged (object sender, EventArgs e)
	{
		switch (cboOpposingLoad.SelectedIndex) {
		case 0:
			CFSInterface.SetText (cboDistanceLoad, WebCripParametersTmp.Zload);
			cboDistanceLoad.Enabled = true;
			break;
		case 1:
			cboDistanceLoad.Text = string.Empty;
			cboDistanceLoad.Enabled = false;
			break;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		Hide ();
		if (WebCripParametersTmp.P == 0f) {
			WebCripParametersTmp.P = 1E-06f;
		}
		if ((cboFlange.SelectedIndex == 1) | (cboFlange.SelectedIndex == 3)) {
			WebCripParametersTmp.P = 0f - WebCripParametersTmp.P;
		}
		if (cboOpposingLoad.SelectedIndex == 1) {
			WebCripParametersTmp.Zload = 1200f;
		}
		CFSInterface.WebCripParametersNow = WebCripParametersTmp;
		if (Report.rptWebCrippling (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow], CFSInterface.WebCripParametersNow)) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (My.MyProject.Forms.mdiCFS);
			My.MyProject.Forms.frmReportDialog.Dispose ();
		}
		Close ();
	}
}
