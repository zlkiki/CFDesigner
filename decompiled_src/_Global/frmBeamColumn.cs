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
public class frmBeamColumn : Form
{
	private IContainer components;

	private float P;

	private float Mx;

	private float My;

	private float Fy;

	private float Py;

	private float Bs;

	private float M1;

	private float M2;

	private float B;

	private float M1y;

	private float M2y;

	private float By;

	private float M1p;

	private float M2p;

	private float Bp;

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

	[field: AccessedThroughProperty ("lblAlpha")]
	internal virtual Label lblAlpha {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtAlpha")]
	internal virtual TextBox txtAlpha {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM1")]
	internal virtual Label lblM1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM1")]
	internal virtual TextBox txtM1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM2")]
	internal virtual Label lblM2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM2")]
	internal virtual TextBox txtM2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblR")]
	internal virtual Label lblR {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtR")]
	internal virtual TextBox txtR {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRy")]
	internal virtual TextBox txtRy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblRy")]
	internal virtual Label lblRy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM2y")]
	internal virtual TextBox txtM2y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM2y")]
	internal virtual Label lblM2y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM1y")]
	internal virtual TextBox txtM1y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM1y")]
	internal virtual Label lblM1y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtPy")]
	internal virtual TextBox txtPy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblPy")]
	internal virtual Label lblPy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRp")]
	internal virtual TextBox txtRp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblRp")]
	internal virtual Label lblRp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM2p")]
	internal virtual TextBox txtM2p {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM2p")]
	internal virtual Label lblM2p {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM1p")]
	internal virtual TextBox txtM1p {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM1p")]
	internal virtual Label lblM1p {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtPp")]
	internal virtual TextBox txtPp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblPp")]
	internal virtual Label lblPp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRpRy")]
	internal virtual TextBox txtRpRy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblRpRy")]
	internal virtual Label lblRpRy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM2pM2y")]
	internal virtual TextBox txtM2pM2y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM2pM2y")]
	internal virtual Label lblM2pM2y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtM1pM1y")]
	internal virtual TextBox txtM1pM1y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblM1pM1y")]
	internal virtual Label lblM1pM1y {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtPpPy")]
	internal virtual TextBox txtPpPy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblPpPy")]
	internal virtual Label lblPpPy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtPhi")]
	internal virtual TextBox txtPhi {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblPhi")]
	internal virtual Label lblPhi {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtTheta")]
	internal virtual TextBox txtTheta {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblTheta")]
	internal virtual Label lblTheta {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblBetas")]
	internal virtual Label lblBetas {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtBetas")]
	internal virtual TextBox txtBetas {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmBeamColumn ()
	{
		base.Load += frmBeamColumn_Load;
		base.FormClosing += frmBeamColumn_FormClosing;
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
		this.lblAlpha = new System.Windows.Forms.Label ();
		this.txtAlpha = new System.Windows.Forms.TextBox ();
		this.lblM1 = new System.Windows.Forms.Label ();
		this.txtM1 = new System.Windows.Forms.TextBox ();
		this.lblM2 = new System.Windows.Forms.Label ();
		this.txtM2 = new System.Windows.Forms.TextBox ();
		this.lblR = new System.Windows.Forms.Label ();
		this.txtR = new System.Windows.Forms.TextBox ();
		this.txtRy = new System.Windows.Forms.TextBox ();
		this.lblRy = new System.Windows.Forms.Label ();
		this.txtM2y = new System.Windows.Forms.TextBox ();
		this.lblM2y = new System.Windows.Forms.Label ();
		this.txtM1y = new System.Windows.Forms.TextBox ();
		this.lblM1y = new System.Windows.Forms.Label ();
		this.txtPy = new System.Windows.Forms.TextBox ();
		this.lblPy = new System.Windows.Forms.Label ();
		this.txtRp = new System.Windows.Forms.TextBox ();
		this.lblRp = new System.Windows.Forms.Label ();
		this.txtM2p = new System.Windows.Forms.TextBox ();
		this.lblM2p = new System.Windows.Forms.Label ();
		this.txtM1p = new System.Windows.Forms.TextBox ();
		this.lblM1p = new System.Windows.Forms.Label ();
		this.txtPp = new System.Windows.Forms.TextBox ();
		this.lblPp = new System.Windows.Forms.Label ();
		this.txtRpRy = new System.Windows.Forms.TextBox ();
		this.lblRpRy = new System.Windows.Forms.Label ();
		this.txtM2pM2y = new System.Windows.Forms.TextBox ();
		this.lblM2pM2y = new System.Windows.Forms.Label ();
		this.txtM1pM1y = new System.Windows.Forms.TextBox ();
		this.lblM1pM1y = new System.Windows.Forms.Label ();
		this.txtPpPy = new System.Windows.Forms.TextBox ();
		this.lblPpPy = new System.Windows.Forms.Label ();
		this.txtPhi = new System.Windows.Forms.TextBox ();
		this.lblPhi = new System.Windows.Forms.Label ();
		this.txtTheta = new System.Windows.Forms.TextBox ();
		this.lblTheta = new System.Windows.Forms.Label ();
		this.lblBetas = new System.Windows.Forms.Label ();
		this.txtBetas = new System.Windows.Forms.TextBox ();
		base.SuspendLayout ();
		this.cboP.FormattingEnabled = true;
		this.cboP.Location = new System.Drawing.Point (72, 6);
		this.cboP.Name = "cboP";
		this.cboP.Size = new System.Drawing.Size (100, 21);
		this.cboP.TabIndex = 4;
		this.lblP.Location = new System.Drawing.Point (12, 9);
		this.lblP.Name = "lblP";
		this.lblP.Size = new System.Drawing.Size (54, 17);
		this.lblP.TabIndex = 3;
		this.lblP.Text = "&P";
		this.lblMx.Location = new System.Drawing.Point (178, 9);
		this.lblMx.Name = "lblMx";
		this.lblMx.Size = new System.Drawing.Size (54, 17);
		this.lblMx.TabIndex = 5;
		this.lblMx.Text = "&Mx";
		this.cboMx.FormattingEnabled = true;
		this.cboMx.Location = new System.Drawing.Point (238, 6);
		this.cboMx.Name = "cboMx";
		this.cboMx.Size = new System.Drawing.Size (100, 21);
		this.cboMx.TabIndex = 6;
		this.lblMy.Location = new System.Drawing.Point (344, 9);
		this.lblMy.Name = "lblMy";
		this.lblMy.Size = new System.Drawing.Size (54, 17);
		this.lblMy.TabIndex = 7;
		this.lblMy.Text = "My";
		this.cboMy.FormattingEnabled = true;
		this.cboMy.Location = new System.Drawing.Point (404, 6);
		this.cboMy.Name = "cboMy";
		this.cboMy.Size = new System.Drawing.Size (100, 21);
		this.cboMy.TabIndex = 8;
		this.lblAlpha.Font = new System.Drawing.Font ("Symbol", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 2);
		this.lblAlpha.Location = new System.Drawing.Point (12, 36);
		this.lblAlpha.Name = "lblAlpha";
		this.lblAlpha.Size = new System.Drawing.Size (54, 17);
		this.lblAlpha.TabIndex = 9;
		this.lblAlpha.Text = "a";
		this.txtAlpha.Location = new System.Drawing.Point (72, 33);
		this.txtAlpha.Name = "txtAlpha";
		this.txtAlpha.ReadOnly = true;
		this.txtAlpha.Size = new System.Drawing.Size (100, 20);
		this.txtAlpha.TabIndex = 11;
		this.lblM1.Location = new System.Drawing.Point (178, 36);
		this.lblM1.Name = "lblM1";
		this.lblM1.Size = new System.Drawing.Size (54, 17);
		this.lblM1.TabIndex = 12;
		this.lblM1.Text = "M1";
		this.txtM1.Location = new System.Drawing.Point (238, 33);
		this.txtM1.Name = "txtM1";
		this.txtM1.ReadOnly = true;
		this.txtM1.Size = new System.Drawing.Size (100, 20);
		this.txtM1.TabIndex = 13;
		this.lblM2.Location = new System.Drawing.Point (344, 36);
		this.lblM2.Name = "lblM2";
		this.lblM2.Size = new System.Drawing.Size (54, 17);
		this.lblM2.TabIndex = 14;
		this.lblM2.Text = "M2";
		this.txtM2.Location = new System.Drawing.Point (404, 33);
		this.txtM2.Name = "txtM2";
		this.txtM2.ReadOnly = true;
		this.txtM2.Size = new System.Drawing.Size (100, 20);
		this.txtM2.TabIndex = 15;
		this.lblR.Location = new System.Drawing.Point (510, 36);
		this.lblR.Name = "lblR";
		this.lblR.Size = new System.Drawing.Size (54, 17);
		this.lblR.TabIndex = 16;
		this.lblR.Text = "β";
		this.txtR.Location = new System.Drawing.Point (570, 33);
		this.txtR.Name = "txtR";
		this.txtR.ReadOnly = true;
		this.txtR.Size = new System.Drawing.Size (100, 20);
		this.txtR.TabIndex = 17;
		this.txtRy.Location = new System.Drawing.Point (570, 59);
		this.txtRy.Name = "txtRy";
		this.txtRy.ReadOnly = true;
		this.txtRy.Size = new System.Drawing.Size (100, 20);
		this.txtRy.TabIndex = 25;
		this.lblRy.Location = new System.Drawing.Point (510, 62);
		this.lblRy.Name = "lblRy";
		this.lblRy.Size = new System.Drawing.Size (54, 17);
		this.lblRy.TabIndex = 24;
		this.lblRy.Text = "βy";
		this.txtM2y.Location = new System.Drawing.Point (404, 59);
		this.txtM2y.Name = "txtM2y";
		this.txtM2y.ReadOnly = true;
		this.txtM2y.Size = new System.Drawing.Size (100, 20);
		this.txtM2y.TabIndex = 23;
		this.lblM2y.Location = new System.Drawing.Point (344, 62);
		this.lblM2y.Name = "lblM2y";
		this.lblM2y.Size = new System.Drawing.Size (54, 17);
		this.lblM2y.TabIndex = 22;
		this.lblM2y.Text = "M2y";
		this.txtM1y.Location = new System.Drawing.Point (238, 59);
		this.txtM1y.Name = "txtM1y";
		this.txtM1y.ReadOnly = true;
		this.txtM1y.Size = new System.Drawing.Size (100, 20);
		this.txtM1y.TabIndex = 21;
		this.lblM1y.Location = new System.Drawing.Point (178, 62);
		this.lblM1y.Name = "lblM1y";
		this.lblM1y.Size = new System.Drawing.Size (54, 17);
		this.lblM1y.TabIndex = 20;
		this.lblM1y.Text = "M1y";
		this.txtPy.Location = new System.Drawing.Point (72, 59);
		this.txtPy.Name = "txtPy";
		this.txtPy.ReadOnly = true;
		this.txtPy.Size = new System.Drawing.Size (100, 20);
		this.txtPy.TabIndex = 19;
		this.lblPy.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPy.Location = new System.Drawing.Point (12, 62);
		this.lblPy.Name = "lblPy";
		this.lblPy.Size = new System.Drawing.Size (54, 17);
		this.lblPy.TabIndex = 18;
		this.lblPy.Text = "Py";
		this.txtRp.Location = new System.Drawing.Point (570, 85);
		this.txtRp.Name = "txtRp";
		this.txtRp.ReadOnly = true;
		this.txtRp.Size = new System.Drawing.Size (100, 20);
		this.txtRp.TabIndex = 33;
		this.lblRp.Location = new System.Drawing.Point (510, 88);
		this.lblRp.Name = "lblRp";
		this.lblRp.Size = new System.Drawing.Size (54, 17);
		this.lblRp.TabIndex = 32;
		this.lblRp.Text = "βp";
		this.txtM2p.Location = new System.Drawing.Point (404, 85);
		this.txtM2p.Name = "txtM2p";
		this.txtM2p.ReadOnly = true;
		this.txtM2p.Size = new System.Drawing.Size (100, 20);
		this.txtM2p.TabIndex = 31;
		this.lblM2p.Location = new System.Drawing.Point (344, 88);
		this.lblM2p.Name = "lblM2p";
		this.lblM2p.Size = new System.Drawing.Size (54, 17);
		this.lblM2p.TabIndex = 30;
		this.lblM2p.Text = "M2p";
		this.txtM1p.Location = new System.Drawing.Point (238, 85);
		this.txtM1p.Name = "txtM1p";
		this.txtM1p.ReadOnly = true;
		this.txtM1p.Size = new System.Drawing.Size (100, 20);
		this.txtM1p.TabIndex = 29;
		this.lblM1p.Location = new System.Drawing.Point (178, 88);
		this.lblM1p.Name = "lblM1p";
		this.lblM1p.Size = new System.Drawing.Size (54, 17);
		this.lblM1p.TabIndex = 28;
		this.lblM1p.Text = "M1p";
		this.txtPp.Location = new System.Drawing.Point (72, 85);
		this.txtPp.Name = "txtPp";
		this.txtPp.ReadOnly = true;
		this.txtPp.Size = new System.Drawing.Size (100, 20);
		this.txtPp.TabIndex = 27;
		this.lblPp.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPp.Location = new System.Drawing.Point (12, 88);
		this.lblPp.Name = "lblPp";
		this.lblPp.Size = new System.Drawing.Size (54, 17);
		this.lblPp.TabIndex = 26;
		this.lblPp.Text = "Pp";
		this.txtRpRy.Location = new System.Drawing.Point (570, 111);
		this.txtRpRy.Name = "txtRpRy";
		this.txtRpRy.ReadOnly = true;
		this.txtRpRy.Size = new System.Drawing.Size (100, 20);
		this.txtRpRy.TabIndex = 41;
		this.lblRpRy.Location = new System.Drawing.Point (510, 114);
		this.lblRpRy.Name = "lblRpRy";
		this.lblRpRy.Size = new System.Drawing.Size (54, 17);
		this.lblRpRy.TabIndex = 40;
		this.lblRpRy.Text = "βp/βy";
		this.txtM2pM2y.Location = new System.Drawing.Point (404, 111);
		this.txtM2pM2y.Name = "txtM2pM2y";
		this.txtM2pM2y.ReadOnly = true;
		this.txtM2pM2y.Size = new System.Drawing.Size (100, 20);
		this.txtM2pM2y.TabIndex = 39;
		this.lblM2pM2y.Location = new System.Drawing.Point (344, 114);
		this.lblM2pM2y.Name = "lblM2pM2y";
		this.lblM2pM2y.Size = new System.Drawing.Size (54, 17);
		this.lblM2pM2y.TabIndex = 38;
		this.lblM2pM2y.Text = "M2p/M2y";
		this.txtM1pM1y.Location = new System.Drawing.Point (238, 111);
		this.txtM1pM1y.Name = "txtM1pM1y";
		this.txtM1pM1y.ReadOnly = true;
		this.txtM1pM1y.Size = new System.Drawing.Size (100, 20);
		this.txtM1pM1y.TabIndex = 37;
		this.lblM1pM1y.Location = new System.Drawing.Point (178, 114);
		this.lblM1pM1y.Name = "lblM1pM1y";
		this.lblM1pM1y.Size = new System.Drawing.Size (54, 17);
		this.lblM1pM1y.TabIndex = 36;
		this.lblM1pM1y.Text = "M1p/M1y";
		this.txtPpPy.Location = new System.Drawing.Point (72, 111);
		this.txtPpPy.Name = "txtPpPy";
		this.txtPpPy.ReadOnly = true;
		this.txtPpPy.Size = new System.Drawing.Size (100, 20);
		this.txtPpPy.TabIndex = 35;
		this.lblPpPy.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPpPy.Location = new System.Drawing.Point (12, 114);
		this.lblPpPy.Name = "lblPpPy";
		this.lblPpPy.Size = new System.Drawing.Size (54, 17);
		this.lblPpPy.TabIndex = 34;
		this.lblPpPy.Text = "Pp/Py";
		this.txtPhi.Location = new System.Drawing.Point (72, 137);
		this.txtPhi.Name = "txtPhi";
		this.txtPhi.ReadOnly = true;
		this.txtPhi.Size = new System.Drawing.Size (100, 20);
		this.txtPhi.TabIndex = 43;
		this.lblPhi.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPhi.Location = new System.Drawing.Point (12, 140);
		this.lblPhi.Name = "lblPhi";
		this.lblPhi.Size = new System.Drawing.Size (54, 17);
		this.lblPhi.TabIndex = 42;
		this.lblPhi.Text = "ϕPM";
		this.txtTheta.Location = new System.Drawing.Point (238, 137);
		this.txtTheta.Name = "txtTheta";
		this.txtTheta.ReadOnly = true;
		this.txtTheta.Size = new System.Drawing.Size (100, 20);
		this.txtTheta.TabIndex = 45;
		this.lblTheta.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTheta.Location = new System.Drawing.Point (178, 140);
		this.lblTheta.Name = "lblTheta";
		this.lblTheta.Size = new System.Drawing.Size (54, 17);
		this.lblTheta.TabIndex = 44;
		this.lblTheta.Text = "θ12";
		this.lblBetas.Location = new System.Drawing.Point (510, 140);
		this.lblBetas.Name = "lblBetas";
		this.lblBetas.Size = new System.Drawing.Size (54, 17);
		this.lblBetas.TabIndex = 46;
		this.lblBetas.Text = "βs";
		this.lblBetas.Visible = false;
		this.txtBetas.Location = new System.Drawing.Point (570, 137);
		this.txtBetas.Name = "txtBetas";
		this.txtBetas.ReadOnly = true;
		this.txtBetas.Size = new System.Drawing.Size (100, 20);
		this.txtBetas.TabIndex = 47;
		this.txtBetas.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (684, 169);
		base.Controls.Add (this.txtBetas);
		base.Controls.Add (this.lblBetas);
		base.Controls.Add (this.txtTheta);
		base.Controls.Add (this.lblTheta);
		base.Controls.Add (this.txtPhi);
		base.Controls.Add (this.lblPhi);
		base.Controls.Add (this.txtRpRy);
		base.Controls.Add (this.lblRpRy);
		base.Controls.Add (this.txtM2pM2y);
		base.Controls.Add (this.lblM2pM2y);
		base.Controls.Add (this.txtM1pM1y);
		base.Controls.Add (this.lblM1pM1y);
		base.Controls.Add (this.txtPpPy);
		base.Controls.Add (this.lblPpPy);
		base.Controls.Add (this.txtRp);
		base.Controls.Add (this.lblRp);
		base.Controls.Add (this.txtM2p);
		base.Controls.Add (this.lblM2p);
		base.Controls.Add (this.txtM1p);
		base.Controls.Add (this.lblM1p);
		base.Controls.Add (this.txtPp);
		base.Controls.Add (this.lblPp);
		base.Controls.Add (this.txtRy);
		base.Controls.Add (this.lblRy);
		base.Controls.Add (this.txtM2y);
		base.Controls.Add (this.lblM2y);
		base.Controls.Add (this.txtM1y);
		base.Controls.Add (this.lblM1y);
		base.Controls.Add (this.txtPy);
		base.Controls.Add (this.lblPy);
		base.Controls.Add (this.txtR);
		base.Controls.Add (this.lblR);
		base.Controls.Add (this.txtM2);
		base.Controls.Add (this.lblM2);
		base.Controls.Add (this.txtM1);
		base.Controls.Add (this.lblM1);
		base.Controls.Add (this.txtAlpha);
		base.Controls.Add (this.lblAlpha);
		base.Controls.Add (this.cboMy);
		base.Controls.Add (this.lblMy);
		base.Controls.Add (this.cboMx);
		base.Controls.Add (this.lblMx);
		base.Controls.Add (this.cboP);
		base.Controls.Add (this.lblP);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBeamColumn";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Beam-Column";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmBeamColumn_Load (object sender, EventArgs e)
	{
		Text = "Beam-Column: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		cboP.Tag = new ControlData (4, -1000f, 1000f);
		cboMx.Tag = new ControlData (6, -100000f, 100000f);
		cboMy.Tag = new ControlData (6, -100000f, 100000f);
		string strMsg = string.Empty;
		CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg, blnCheckLicense: false);
		CFS.Sections [CFS.intSctNow].PlasticSurface ();
		Section section = CFS.Sections [CFS.intSctNow].Clone ();
		Fy = section.Material.Fy [2];
		Py = Fy * section.Prop.A;
		if ((double)Math.Abs (section.Prop.Alpha) > 0.0001) {
			section.Rotate (0f - section.Prop.Alpha);
			section.CalcProperties (ref strMsg, blnCheckLicense: false);
		}
		M1y = Fy * section.Prop.Sx;
		M1p = Fy * section.Prop.Zx;
		M2y = Fy * section.Prop.Sy;
		M2p = Fy * section.Prop.Zy;
		if (section.Prop.An == section.Prop.A) {
			M1p = M1y * section.BetaP (0f, 1f, 0f);
			M2p = M2y * section.BetaP (0f, 0f, 1f);
		}
		section = null;
		P = 0f;
		Mx = 0f;
		My = 0f;
		CFS.blnValidate = false;
		CFSInterface.SetText (cboP, P);
		CFSInterface.SetText (cboMx, Mx);
		CFSInterface.SetText (cboMy, My);
		CFS.blnValidate = true;
		txtAlpha.Text = Units.DisplayAngle (CFS.Sections [CFS.intSctNow].Prop.Alpha, 0, blnShowUnit: true, "", 0, 0);
		txtPy.Text = Units.DisplayForce (Py, 0, blnShowUnit: true, "", 0, 0);
		txtPp.Text = Units.DisplayForce (Py, 0, blnShowUnit: true, "", 0, 0);
		txtPpPy.Text = Units.DisplayNone (1f, "", 0, 0);
		txtM1y.Text = Units.DisplayMoment (M1y, 0, blnShowUnit: true, "", 0, 0);
		txtM1p.Text = Units.DisplayMoment (M1p, 0, blnShowUnit: true, "", 0, 0);
		txtM1pM1y.Text = Units.DisplayNone (M1p / M1y, "", 0, 0);
		txtM2y.Text = Units.DisplayMoment (M2y, 0, blnShowUnit: true, "", 0, 0);
		txtM2p.Text = Units.DisplayMoment (M2p, 0, blnShowUnit: true, "", 0, 0);
		txtM2pM2y.Text = Units.DisplayNone (M2p / M2y, "", 0, 0);
		RefreshBeamColumn ();
	}

	private void RefreshBeamColumn ()
	{
		Section section = CFS.Sections [CFS.intSctNow];
		M1 = (float)((double)Mx * Math.Cos (section.Prop.Alpha) - (double)My * Math.Sin (section.Prop.Alpha));
		M2 = (float)((double)My * Math.Cos (section.Prop.Alpha) + (double)Mx * Math.Sin (section.Prop.Alpha));
		float sngValue;
		float sngValue2;
		if ((M1 == 0f) & (M2 == 0f)) {
			sngValue = 0f;
			B = Math.Abs (P / Py);
			sngValue2 = Conversions.ToSingle (Interaction.IIf (P >= 0f, 0, Math.PI));
		} else {
			sngValue = (float)Math.Atan2 (M2 / M2y, M1 / M1y);
			B = (float)Math.Sqrt (Math.Pow (P / Py, 2.0) + Math.Pow (M1 / M1y, 2.0) + Math.Pow (M2 / M2y, 2.0));
			sngValue2 = (float)Math.Acos (P / Py / B);
		}
		By = section.BetaY (P, Mx, My);
		Bp = section.BetaP (P, Mx, My);
		if (Bp < By) {
			Bp = By;
		}
		Bs = section.BetaS (P, Mx, My);
		txtM1.Text = Units.DisplayMoment (M1, 0, blnShowUnit: true, "", 0, 0);
		txtM2.Text = Units.DisplayMoment (M2, 0, blnShowUnit: true, "", 0, 0);
		txtR.Text = Units.DisplayNone (B, "", 0, 0);
		txtRy.Text = Units.DisplayNone (By, "", 0, 0);
		txtRp.Text = Units.DisplayNone (Bp, "", 0, 0);
		txtRpRy.Text = Units.DisplayNone (Bp / By, "", 0, 0);
		txtTheta.Text = Units.DisplayAngle (sngValue, 0, blnShowUnit: true, "", 0, 0);
		txtPhi.Text = Units.DisplayAngle (sngValue2, 0, blnShowUnit: true, "", 0, 0);
		txtBetas.Text = Units.DisplayNone (Bs, "", 0, 0);
		section = null;
	}

	private void frmBeamColumn_FormClosing (object sender, FormClosingEventArgs e)
	{
		cboP.Select ();
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
		} else if (CFSInterface.Validate ((Control)sender)) {
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboP)) {
				P = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboMx)) {
				Mx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboMy)) {
				My = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			RefreshBeamColumn ();
		} else {
			e.Cancel = true;
		}
	}
}
