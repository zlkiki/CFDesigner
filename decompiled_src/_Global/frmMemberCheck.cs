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
public class frmMemberCheck : Form
{
	private IContainer components;

	private MemberParameters MemberParametersTmp;

	[field: AccessedThroughProperty ("lblLengths")]
	internal virtual Label lblLengths {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblLx")]
	internal virtual Label lblLx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLx {
		[CompilerGenerated]
		get {
			return _cboLx;
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
			ComboBox comboBox = _cboLx;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLx = value;
			comboBox = _cboLx;
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

	[field: AccessedThroughProperty ("lblLy")]
	internal virtual Label lblLy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLy {
		[CompilerGenerated]
		get {
			return _cboLy;
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
			ComboBox comboBox = _cboLy;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLy = value;
			comboBox = _cboLy;
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

	[field: AccessedThroughProperty ("lblLt")]
	internal virtual Label lblLt {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLt {
		[CompilerGenerated]
		get {
			return _cboLt;
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
			ComboBox comboBox = _cboLt;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLt = value;
			comboBox = _cboLt;
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

	[field: AccessedThroughProperty ("lblKx")]
	internal virtual Label lblKx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtKx {
		[CompilerGenerated]
		get {
			return _txtKx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtKx;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtKx = value;
			textBox = _txtKx;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblKy")]
	internal virtual Label lblKy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtKy {
		[CompilerGenerated]
		get {
			return _txtKy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtKy;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtKy = value;
			textBox = _txtKy;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblKt")]
	internal virtual Label lblKt {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtKt {
		[CompilerGenerated]
		get {
			return _txtKt;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtKt;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtKt = value;
			textBox = _txtKt;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblLm")]
	internal virtual Label lblLm {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLm {
		[CompilerGenerated]
		get {
			return _cboLm;
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
			ComboBox comboBox = _cboLm;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLm = value;
			comboBox = _cboLm;
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

	[field: AccessedThroughProperty ("lblCbx")]
	internal virtual Label lblCbx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtCbx {
		[CompilerGenerated]
		get {
			return _txtCbx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtCbx;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtCbx = value;
			textBox = _txtCbx;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCby")]
	internal virtual Label lblCby {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtCby {
		[CompilerGenerated]
		get {
			return _txtCby;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtCby;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtCby = value;
			textBox = _txtCby;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCmx")]
	internal virtual Label lblCmx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtCmx {
		[CompilerGenerated]
		get {
			return _txtCmx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtCmx;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtCmx = value;
			textBox = _txtCmx;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCmy")]
	internal virtual Label lblCmy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtCmy {
		[CompilerGenerated]
		get {
			return _txtCmy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtCmy;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtCmy = value;
			textBox = _txtCmy;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblBracedFlange")]
	internal virtual Label lblBracedFlange {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboBracedFlange {
		[CompilerGenerated]
		get {
			return _cboBracedFlange;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboBracedFlange_SelectedIndexChanged;
			ComboBox comboBox = _cboBracedFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboBracedFlange = value;
			comboBox = _cboBracedFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRedFactor")]
	internal virtual Label lblRedFactor {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtRedFactor {
		[CompilerGenerated]
		get {
			return _txtRedFactor;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtRedFactor;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtRedFactor = value;
			textBox = _txtRedFactor;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblStiffness")]
	internal virtual Label lblStiffness {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboStiffness {
		[CompilerGenerated]
		get {
			return _cboStiffness;
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
			ComboBox comboBox = _cboStiffness;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboStiffness = value;
			comboBox = _cboStiffness;
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

	[field: AccessedThroughProperty ("lblCoefficients")]
	internal virtual Label lblCoefficients {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblP")]
	internal virtual Label lblP {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblForces")]
	internal virtual Label lblForces {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

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

	[field: AccessedThroughProperty ("lblEx")]
	internal virtual Label lblEx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboEx {
		[CompilerGenerated]
		get {
			return _cboEx;
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
			ComboBox comboBox = _cboEx;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboEx = value;
			comboBox = _cboEx;
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

	[field: AccessedThroughProperty ("lblEy")]
	internal virtual Label lblEy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboEy {
		[CompilerGenerated]
		get {
			return _cboEy;
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
			ComboBox comboBox = _cboEy;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboEy = value;
			comboBox = _cboEy;
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

	[field: AccessedThroughProperty ("lblVy")]
	internal virtual Label lblVy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboVy {
		[CompilerGenerated]
		get {
			return _cboVy;
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
			ComboBox comboBox = _cboVy;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboVy = value;
			comboBox = _cboVy;
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

	[field: AccessedThroughProperty ("lblVx")]
	internal virtual Label lblVx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboVx {
		[CompilerGenerated]
		get {
			return _cboVx;
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
			ComboBox comboBox = _cboVx;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboVx = value;
			comboBox = _cboVx;
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

	[field: AccessedThroughProperty ("lblB")]
	internal virtual Label lblB {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboB {
		[CompilerGenerated]
		get {
			return _cboB;
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
			ComboBox comboBox = _cboB;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboB = value;
			comboBox = _cboB;
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

	internal virtual CheckBox chkPdelta {
		[CompilerGenerated]
		get {
			return _chkPdelta;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkPdelta_CheckedChanged;
			CheckBox checkBox = _chkPdelta;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkPdelta = value;
			checkBox = _chkPdelta;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	public frmMemberCheck ()
	{
		base.Load += frmMemberCheck_Load;
		base.KeyDown += frmMemberCheck_KeyDown;
		base.HelpButtonClicked += frmMemberCheck_HelpButtonClicked;
		base.FormClosing += frmMemberCheck_FormClosing;
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
		this.lblLengths = new System.Windows.Forms.Label ();
		this.lblLx = new System.Windows.Forms.Label ();
		this.cboLx = new System.Windows.Forms.ComboBox ();
		this.lblLy = new System.Windows.Forms.Label ();
		this.cboLy = new System.Windows.Forms.ComboBox ();
		this.lblLt = new System.Windows.Forms.Label ();
		this.cboLt = new System.Windows.Forms.ComboBox ();
		this.lblKx = new System.Windows.Forms.Label ();
		this.txtKx = new System.Windows.Forms.TextBox ();
		this.lblKy = new System.Windows.Forms.Label ();
		this.txtKy = new System.Windows.Forms.TextBox ();
		this.lblKt = new System.Windows.Forms.Label ();
		this.txtKt = new System.Windows.Forms.TextBox ();
		this.lblLm = new System.Windows.Forms.Label ();
		this.cboLm = new System.Windows.Forms.ComboBox ();
		this.lblCbx = new System.Windows.Forms.Label ();
		this.txtCbx = new System.Windows.Forms.TextBox ();
		this.lblCby = new System.Windows.Forms.Label ();
		this.txtCby = new System.Windows.Forms.TextBox ();
		this.lblCmx = new System.Windows.Forms.Label ();
		this.txtCmx = new System.Windows.Forms.TextBox ();
		this.lblCmy = new System.Windows.Forms.Label ();
		this.txtCmy = new System.Windows.Forms.TextBox ();
		this.lblBracedFlange = new System.Windows.Forms.Label ();
		this.cboBracedFlange = new System.Windows.Forms.ComboBox ();
		this.lblRedFactor = new System.Windows.Forms.Label ();
		this.txtRedFactor = new System.Windows.Forms.TextBox ();
		this.lblStiffness = new System.Windows.Forms.Label ();
		this.cboStiffness = new System.Windows.Forms.ComboBox ();
		this.lblCoefficients = new System.Windows.Forms.Label ();
		this.lblP = new System.Windows.Forms.Label ();
		this.lblForces = new System.Windows.Forms.Label ();
		this.cboP = new System.Windows.Forms.ComboBox ();
		this.lblEx = new System.Windows.Forms.Label ();
		this.cboEx = new System.Windows.Forms.ComboBox ();
		this.lblEy = new System.Windows.Forms.Label ();
		this.cboEy = new System.Windows.Forms.ComboBox ();
		this.lblMx = new System.Windows.Forms.Label ();
		this.cboMx = new System.Windows.Forms.ComboBox ();
		this.lblVy = new System.Windows.Forms.Label ();
		this.cboVy = new System.Windows.Forms.ComboBox ();
		this.lblMy = new System.Windows.Forms.Label ();
		this.cboMy = new System.Windows.Forms.ComboBox ();
		this.lblVx = new System.Windows.Forms.Label ();
		this.cboVx = new System.Windows.Forms.ComboBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblB = new System.Windows.Forms.Label ();
		this.cboB = new System.Windows.Forms.ComboBox ();
		this.chkPdelta = new System.Windows.Forms.CheckBox ();
		base.SuspendLayout ();
		this.lblLengths.Location = new System.Drawing.Point (54, 9);
		this.lblLengths.Name = "lblLengths";
		this.lblLengths.Size = new System.Drawing.Size (100, 17);
		this.lblLengths.TabIndex = 0;
		this.lblLengths.Text = "Unbraced Lengths";
		this.lblLengths.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblLx.Location = new System.Drawing.Point (12, 34);
		this.lblLx.Name = "lblLx";
		this.lblLx.Size = new System.Drawing.Size (36, 17);
		this.lblLx.TabIndex = 1;
		this.lblLx.Text = "&Lx";
		this.cboLx.FormattingEnabled = true;
		this.cboLx.Location = new System.Drawing.Point (54, 31);
		this.cboLx.Name = "cboLx";
		this.cboLx.Size = new System.Drawing.Size (100, 21);
		this.cboLx.TabIndex = 2;
		this.lblLy.Location = new System.Drawing.Point (12, 61);
		this.lblLy.Name = "lblLy";
		this.lblLy.Size = new System.Drawing.Size (36, 17);
		this.lblLy.TabIndex = 3;
		this.lblLy.Text = "Ly";
		this.cboLy.FormattingEnabled = true;
		this.cboLy.Location = new System.Drawing.Point (54, 58);
		this.cboLy.Name = "cboLy";
		this.cboLy.Size = new System.Drawing.Size (100, 21);
		this.cboLy.TabIndex = 4;
		this.lblLt.Location = new System.Drawing.Point (12, 88);
		this.lblLt.Name = "lblLt";
		this.lblLt.Size = new System.Drawing.Size (36, 17);
		this.lblLt.TabIndex = 5;
		this.lblLt.Text = "Lt";
		this.cboLt.FormattingEnabled = true;
		this.cboLt.Location = new System.Drawing.Point (54, 85);
		this.cboLt.Name = "cboLt";
		this.cboLt.Size = new System.Drawing.Size (100, 21);
		this.cboLt.TabIndex = 6;
		this.lblKx.Location = new System.Drawing.Point (12, 115);
		this.lblKx.Name = "lblKx";
		this.lblKx.Size = new System.Drawing.Size (36, 17);
		this.lblKx.TabIndex = 7;
		this.lblKx.Text = "Kx";
		this.txtKx.Location = new System.Drawing.Point (54, 112);
		this.txtKx.Name = "txtKx";
		this.txtKx.Size = new System.Drawing.Size (100, 20);
		this.txtKx.TabIndex = 8;
		this.lblKy.Location = new System.Drawing.Point (12, 142);
		this.lblKy.Name = "lblKy";
		this.lblKy.Size = new System.Drawing.Size (36, 17);
		this.lblKy.TabIndex = 9;
		this.lblKy.Text = "Ky";
		this.txtKy.Location = new System.Drawing.Point (54, 139);
		this.txtKy.Name = "txtKy";
		this.txtKy.Size = new System.Drawing.Size (100, 20);
		this.txtKy.TabIndex = 10;
		this.lblKt.Location = new System.Drawing.Point (12, 169);
		this.lblKt.Name = "lblKt";
		this.lblKt.Size = new System.Drawing.Size (36, 17);
		this.lblKt.TabIndex = 11;
		this.lblKt.Text = "Kt";
		this.txtKt.Location = new System.Drawing.Point (54, 166);
		this.txtKt.Name = "txtKt";
		this.txtKt.Size = new System.Drawing.Size (100, 20);
		this.txtKt.TabIndex = 12;
		this.lblLm.Location = new System.Drawing.Point (12, 196);
		this.lblLm.Name = "lblLm";
		this.lblLm.Size = new System.Drawing.Size (36, 17);
		this.lblLm.TabIndex = 13;
		this.lblLm.Text = "Lm";
		this.cboLm.FormattingEnabled = true;
		this.cboLm.Location = new System.Drawing.Point (54, 193);
		this.cboLm.Name = "cboLm";
		this.cboLm.Size = new System.Drawing.Size (100, 21);
		this.cboLm.TabIndex = 14;
		this.lblCbx.Location = new System.Drawing.Point (182, 34);
		this.lblCbx.Name = "lblCbx";
		this.lblCbx.Size = new System.Drawing.Size (36, 17);
		this.lblCbx.TabIndex = 16;
		this.lblCbx.Text = "&Cbx";
		this.txtCbx.Location = new System.Drawing.Point (246, 31);
		this.txtCbx.Name = "txtCbx";
		this.txtCbx.Size = new System.Drawing.Size (100, 20);
		this.txtCbx.TabIndex = 17;
		this.lblCby.Location = new System.Drawing.Point (182, 61);
		this.lblCby.Name = "lblCby";
		this.lblCby.Size = new System.Drawing.Size (36, 17);
		this.lblCby.TabIndex = 18;
		this.lblCby.Text = "Cby";
		this.txtCby.Location = new System.Drawing.Point (246, 58);
		this.txtCby.Name = "txtCby";
		this.txtCby.Size = new System.Drawing.Size (100, 20);
		this.txtCby.TabIndex = 19;
		this.lblCmx.Location = new System.Drawing.Point (182, 88);
		this.lblCmx.Name = "lblCmx";
		this.lblCmx.Size = new System.Drawing.Size (36, 17);
		this.lblCmx.TabIndex = 20;
		this.lblCmx.Text = "Cmx";
		this.txtCmx.Location = new System.Drawing.Point (246, 85);
		this.txtCmx.Name = "txtCmx";
		this.txtCmx.Size = new System.Drawing.Size (100, 20);
		this.txtCmx.TabIndex = 21;
		this.lblCmy.Location = new System.Drawing.Point (182, 115);
		this.lblCmy.Name = "lblCmy";
		this.lblCmy.Size = new System.Drawing.Size (36, 17);
		this.lblCmy.TabIndex = 22;
		this.lblCmy.Text = "Cmy";
		this.txtCmy.Location = new System.Drawing.Point (246, 112);
		this.txtCmy.Name = "txtCmy";
		this.txtCmy.Size = new System.Drawing.Size (100, 20);
		this.txtCmy.TabIndex = 23;
		this.lblBracedFlange.Location = new System.Drawing.Point (160, 142);
		this.lblBracedFlange.Name = "lblBracedFlange";
		this.lblBracedFlange.Size = new System.Drawing.Size (80, 17);
		this.lblBracedFlange.TabIndex = 24;
		this.lblBracedFlange.Text = "Braced Flange";
		this.cboBracedFlange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBracedFlange.FormattingEnabled = true;
		this.cboBracedFlange.Location = new System.Drawing.Point (246, 139);
		this.cboBracedFlange.Name = "cboBracedFlange";
		this.cboBracedFlange.Size = new System.Drawing.Size (100, 21);
		this.cboBracedFlange.TabIndex = 25;
		this.lblRedFactor.Location = new System.Drawing.Point (160, 169);
		this.lblRedFactor.Name = "lblRedFactor";
		this.lblRedFactor.Size = new System.Drawing.Size (80, 17);
		this.lblRedFactor.TabIndex = 26;
		this.lblRedFactor.Text = "Red. Factor, R";
		this.txtRedFactor.Location = new System.Drawing.Point (246, 166);
		this.txtRedFactor.Name = "txtRedFactor";
		this.txtRedFactor.Size = new System.Drawing.Size (100, 20);
		this.txtRedFactor.TabIndex = 27;
		this.lblStiffness.Location = new System.Drawing.Point (160, 196);
		this.lblStiffness.Name = "lblStiffness";
		this.lblStiffness.Size = new System.Drawing.Size (80, 17);
		this.lblStiffness.TabIndex = 28;
		this.lblStiffness.Text = "Stiffness, kϕ";
		this.cboStiffness.FormattingEnabled = true;
		this.cboStiffness.Location = new System.Drawing.Point (246, 193);
		this.cboStiffness.Name = "cboStiffness";
		this.cboStiffness.Size = new System.Drawing.Size (100, 21);
		this.cboStiffness.TabIndex = 29;
		this.lblCoefficients.Location = new System.Drawing.Point (246, 9);
		this.lblCoefficients.Name = "lblCoefficients";
		this.lblCoefficients.Size = new System.Drawing.Size (100, 17);
		this.lblCoefficients.TabIndex = 15;
		this.lblCoefficients.Text = "Coefficients";
		this.lblCoefficients.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblP.Location = new System.Drawing.Point (367, 34);
		this.lblP.Name = "lblP";
		this.lblP.Size = new System.Drawing.Size (36, 17);
		this.lblP.TabIndex = 32;
		this.lblP.Text = "&P";
		this.lblForces.Location = new System.Drawing.Point (409, 9);
		this.lblForces.Name = "lblForces";
		this.lblForces.Size = new System.Drawing.Size (100, 17);
		this.lblForces.TabIndex = 31;
		this.lblForces.Text = "Internal Forces";
		this.lblForces.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.cboP.FormattingEnabled = true;
		this.cboP.Location = new System.Drawing.Point (409, 31);
		this.cboP.Name = "cboP";
		this.cboP.Size = new System.Drawing.Size (100, 21);
		this.cboP.TabIndex = 33;
		this.lblEx.Location = new System.Drawing.Point (367, 61);
		this.lblEx.Name = "lblEx";
		this.lblEx.Size = new System.Drawing.Size (36, 17);
		this.lblEx.TabIndex = 34;
		this.lblEx.Text = "ex";
		this.cboEx.FormattingEnabled = true;
		this.cboEx.Location = new System.Drawing.Point (426, 58);
		this.cboEx.Name = "cboEx";
		this.cboEx.Size = new System.Drawing.Size (83, 21);
		this.cboEx.TabIndex = 35;
		this.lblEy.Location = new System.Drawing.Point (367, 88);
		this.lblEy.Name = "lblEy";
		this.lblEy.Size = new System.Drawing.Size (36, 17);
		this.lblEy.TabIndex = 36;
		this.lblEy.Text = "ey";
		this.cboEy.FormattingEnabled = true;
		this.cboEy.Location = new System.Drawing.Point (426, 85);
		this.cboEy.Name = "cboEy";
		this.cboEy.Size = new System.Drawing.Size (83, 21);
		this.cboEy.TabIndex = 37;
		this.lblMx.Location = new System.Drawing.Point (367, 115);
		this.lblMx.Name = "lblMx";
		this.lblMx.Size = new System.Drawing.Size (36, 17);
		this.lblMx.TabIndex = 38;
		this.lblMx.Text = "Mx";
		this.cboMx.FormattingEnabled = true;
		this.cboMx.Location = new System.Drawing.Point (409, 112);
		this.cboMx.Name = "cboMx";
		this.cboMx.Size = new System.Drawing.Size (100, 21);
		this.cboMx.TabIndex = 39;
		this.lblVy.Location = new System.Drawing.Point (367, 142);
		this.lblVy.Name = "lblVy";
		this.lblVy.Size = new System.Drawing.Size (36, 17);
		this.lblVy.TabIndex = 40;
		this.lblVy.Text = "Vy";
		this.cboVy.FormattingEnabled = true;
		this.cboVy.Location = new System.Drawing.Point (409, 139);
		this.cboVy.Name = "cboVy";
		this.cboVy.Size = new System.Drawing.Size (100, 21);
		this.cboVy.TabIndex = 41;
		this.lblMy.Location = new System.Drawing.Point (367, 169);
		this.lblMy.Name = "lblMy";
		this.lblMy.Size = new System.Drawing.Size (36, 17);
		this.lblMy.TabIndex = 42;
		this.lblMy.Text = "My";
		this.cboMy.FormattingEnabled = true;
		this.cboMy.Location = new System.Drawing.Point (409, 166);
		this.cboMy.Name = "cboMy";
		this.cboMy.Size = new System.Drawing.Size (100, 21);
		this.cboMy.TabIndex = 43;
		this.lblVx.Location = new System.Drawing.Point (367, 196);
		this.lblVx.Name = "lblVx";
		this.lblVx.Size = new System.Drawing.Size (36, 17);
		this.lblVx.TabIndex = 44;
		this.lblVx.Text = "Vx";
		this.cboVx.FormattingEnabled = true;
		this.cboVx.Location = new System.Drawing.Point (409, 193);
		this.cboVx.Name = "cboVx";
		this.cboVx.Size = new System.Drawing.Size (100, 21);
		this.cboVx.TabIndex = 45;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (353, 258);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 48;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (434, 258);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 49;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblB.Location = new System.Drawing.Point (367, 223);
		this.lblB.Name = "lblB";
		this.lblB.Size = new System.Drawing.Size (36, 17);
		this.lblB.TabIndex = 46;
		this.lblB.Text = "B";
		this.cboB.FormattingEnabled = true;
		this.cboB.Location = new System.Drawing.Point (409, 220);
		this.cboB.Name = "cboB";
		this.cboB.Size = new System.Drawing.Size (100, 21);
		this.cboB.TabIndex = 47;
		this.chkPdelta.AutoSize = true;
		this.chkPdelta.Location = new System.Drawing.Point (163, 222);
		this.chkPdelta.Name = "chkPdelta";
		this.chkPdelta.Size = new System.Drawing.Size (169, 17);
		this.chkPdelta.TabIndex = 30;
		this.chkPdelta.Text = "Mx and My include P-δ effects";
		this.chkPdelta.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (524, 298);
		base.Controls.Add (this.chkPdelta);
		base.Controls.Add (this.cboB);
		base.Controls.Add (this.lblB);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.cboVx);
		base.Controls.Add (this.lblVx);
		base.Controls.Add (this.cboMy);
		base.Controls.Add (this.lblMy);
		base.Controls.Add (this.cboVy);
		base.Controls.Add (this.lblVy);
		base.Controls.Add (this.cboMx);
		base.Controls.Add (this.lblMx);
		base.Controls.Add (this.cboEy);
		base.Controls.Add (this.lblEy);
		base.Controls.Add (this.cboEx);
		base.Controls.Add (this.lblEx);
		base.Controls.Add (this.cboP);
		base.Controls.Add (this.lblForces);
		base.Controls.Add (this.lblP);
		base.Controls.Add (this.lblCoefficients);
		base.Controls.Add (this.cboStiffness);
		base.Controls.Add (this.lblStiffness);
		base.Controls.Add (this.txtRedFactor);
		base.Controls.Add (this.lblRedFactor);
		base.Controls.Add (this.cboBracedFlange);
		base.Controls.Add (this.lblBracedFlange);
		base.Controls.Add (this.txtCmy);
		base.Controls.Add (this.lblCmy);
		base.Controls.Add (this.txtCmx);
		base.Controls.Add (this.lblCmx);
		base.Controls.Add (this.txtCby);
		base.Controls.Add (this.lblCby);
		base.Controls.Add (this.txtCbx);
		base.Controls.Add (this.lblCbx);
		base.Controls.Add (this.cboLm);
		base.Controls.Add (this.lblLm);
		base.Controls.Add (this.txtKt);
		base.Controls.Add (this.lblKt);
		base.Controls.Add (this.txtKy);
		base.Controls.Add (this.lblKy);
		base.Controls.Add (this.txtKx);
		base.Controls.Add (this.lblKx);
		base.Controls.Add (this.cboLt);
		base.Controls.Add (this.lblLt);
		base.Controls.Add (this.cboLy);
		base.Controls.Add (this.lblLy);
		base.Controls.Add (this.cboLx);
		base.Controls.Add (this.lblLx);
		base.Controls.Add (this.lblLengths);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmMemberCheck";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "frmMemberCheck";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmMemberCheck_Load (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		Text = "Member Parameters: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		cboLx.Tag = new ControlData (2, 0f, 1200f);
		cboLy.Tag = new ControlData (2, 0f, 1200f);
		cboLt.Tag = new ControlData (2, 0f, 1200f);
		cboP.Tag = new ControlData (4, -1000f, 1000f);
		cboEx.Tag = new ControlData (1, -100f, 100f);
		cboEy.Tag = new ControlData (1, -100f, 100f);
		cboMx.Tag = new ControlData (6, -100000f, 100000f);
		cboVy.Tag = new ControlData (4, -1000f, 1000f);
		cboMy.Tag = new ControlData (6, -100000f, 100000f);
		cboVx.Tag = new ControlData (4, -1000f, 1000f);
		cboB.Tag = new ControlData (13, -1000000f, 1000000f);
		cboStiffness.Tag = new ControlData (4, 0f, 1000f);
		cboLm.Tag = new ControlData (2, 0f, 1200f);
		txtKx.Tag = new ControlData (0, 0f, 5f);
		txtKy.Tag = new ControlData (0, 0f, 5f);
		txtKt.Tag = new ControlData (0, 0f, 5f);
		txtCbx.Tag = new ControlData (0, 1f, 5f);
		txtCby.Tag = new ControlData (0, 1f, 5f);
		txtCmx.Tag = new ControlData (0, 0.2f, 1f);
		txtCmy.Tag = new ControlData (0, 0.2f, 1f);
		txtRedFactor.Tag = new ControlData (0, 0f, 1f);
		cboBracedFlange.Items.Add ("None");
		cboBracedFlange.Items.Add ("Bottom Flange");
		cboBracedFlange.Items.Add ("Top Flange");
		cboBracedFlange.Items.Add ("Left Flange");
		cboBracedFlange.Items.Add ("Right Flange");
		MemberParametersTmp = CFSInterface.MemberParametersNow;
		ref MemberParameters memberParametersTmp = ref MemberParametersTmp;
		memberParametersTmp.Spec = (Specifications)CFS.intSpecNow;
		memberParametersTmp.BucklingTheory = CFS.blnBucklingTheory;
		if ((memberParametersTmp.P > 0f) & CFS.IsSpec1999 ((short)memberParametersTmp.Spec)) {
			memberParametersTmp.Cbx1 = 1f;
			memberParametersTmp.Cby1 = 1f;
		}
		CFS.blnValidate = false;
		ref MemberParameters memberParametersTmp2 = ref MemberParametersTmp;
		CFSInterface.SetText (cboLx, memberParametersTmp2.Lx);
		CFSInterface.SetText (cboLy, memberParametersTmp2.Ly);
		CFSInterface.SetText (cboLt, memberParametersTmp2.Lt);
		cboBracedFlange.SelectedIndex = (int)memberParametersTmp2.iBrcFlg;
		CFSInterface.SetText (cboP, memberParametersTmp2.P);
		CFSInterface.SetText (cboEx, memberParametersTmp2.ex);
		CFSInterface.SetText (cboEy, memberParametersTmp2.ey);
		CFSInterface.SetText (cboMx, memberParametersTmp2.Mx);
		CFSInterface.SetText (cboVy, memberParametersTmp2.Vy);
		CFSInterface.SetText (cboMy, memberParametersTmp2.My);
		CFSInterface.SetText (cboVx, memberParametersTmp2.Vx);
		CFSInterface.SetText (cboB, memberParametersTmp2.B);
		CFSInterface.SetText (cboStiffness, memberParametersTmp2.Kf);
		CFSInterface.SetText (cboLm, memberParametersTmp2.Lm);
		CFSInterface.SetText (txtKx, memberParametersTmp2.Kx);
		CFSInterface.SetText (txtKy, memberParametersTmp2.Ky);
		CFSInterface.SetText (txtKt, memberParametersTmp2.Kt);
		CFSInterface.SetText (txtCbx, memberParametersTmp2.Cbx1);
		CFSInterface.SetText (txtCby, memberParametersTmp2.Cby1);
		CFSInterface.SetText (txtCmx, memberParametersTmp2.Cmx);
		CFSInterface.SetText (txtCmy, memberParametersTmp2.Cmy);
		CFSInterface.SetText (txtRedFactor, memberParametersTmp2.R);
		chkPdelta.Checked = memberParametersTmp2.Pdelta;
		CFS.blnValidate = true;
		Cursor.Current = Cursors.Default;
	}

	private void frmMemberCheck_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "member-check-parameters.htm");
			e.Handled = true;
		}
	}

	private void frmMemberCheck_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "member-check-parameters.htm");
		e.Cancel = true;
	}

	private void frmMemberCheck_FormClosing (object sender, FormClosingEventArgs e)
	{
		cboLx.Select ();
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
			ref MemberParameters memberParametersTmp = ref MemberParametersTmp;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboLx)) {
				memberParametersTmp.Lx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLy)) {
				memberParametersTmp.Ly = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLt)) {
				memberParametersTmp.Lt = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboP)) {
				memberParametersTmp.P = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				if ((memberParametersTmp.P > 0f) & CFS.IsSpec1999 ((short)memberParametersTmp.Spec)) {
					memberParametersTmp.Cbx1 = 1f;
					txtCbx.Text = Units.DisplayNone (memberParametersTmp.Cbx1, "", 0, 0);
					memberParametersTmp.Cby1 = 1f;
					txtCby.Text = Units.DisplayNone (memberParametersTmp.Cby1, "", 0, 0);
				}
			} else if (flag == (sender == cboEx)) {
				memberParametersTmp.ex = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboEy)) {
				memberParametersTmp.ey = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboMx)) {
				memberParametersTmp.Mx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboVy)) {
				memberParametersTmp.Vy = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboMy)) {
				memberParametersTmp.My = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboVx)) {
				memberParametersTmp.Vx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboB)) {
				memberParametersTmp.B = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				memberParametersTmp.Torsion = memberParametersTmp.B != 0f;
			} else if (flag == (sender == cboStiffness)) {
				memberParametersTmp.Kf = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLm)) {
				memberParametersTmp.Lm = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void cboBracedFlange_SelectedIndexChanged (object sender, EventArgs e)
	{
		MemberParametersTmp.iBrcFlg = (Flanges)checked((byte)cboBracedFlange.SelectedIndex);
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
			ref MemberParameters memberParametersTmp = ref MemberParametersTmp;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == txtKx)) {
				memberParametersTmp.Kx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtKy)) {
				memberParametersTmp.Ky = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtKt)) {
				memberParametersTmp.Kt = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtCbx)) {
				memberParametersTmp.Cbx1 = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				if ((memberParametersTmp.Cbx1 > 1f) & (memberParametersTmp.P > 0f) & CFS.IsSpec1999 ((short)memberParametersTmp.Spec)) {
					memberParametersTmp.P = 0f;
					CFSInterface.SetText (cboP, memberParametersTmp.P);
				}
			} else if (flag == (sender == txtCby)) {
				memberParametersTmp.Cby1 = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				if ((memberParametersTmp.Cby1 > 1f) & (memberParametersTmp.P > 0f) & CFS.IsSpec1999 ((short)memberParametersTmp.Spec)) {
					memberParametersTmp.P = 0f;
					CFSInterface.SetText (cboP, memberParametersTmp.P);
				}
			} else if (flag == (sender == txtCmx)) {
				memberParametersTmp.Cmx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtCmy)) {
				memberParametersTmp.Cmy = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtRedFactor)) {
				memberParametersTmp.R = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void chkPdelta_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			MemberParametersTmp.Pdelta = chkPdelta.Checked;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		Hide ();
		CFSInterface.MemberParametersNow = MemberParametersTmp;
		if (Report.rptMemberCheck (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow], CFSInterface.MemberParametersNow)) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (My.MyProject.Forms.mdiCFS);
			My.MyProject.Forms.frmReportDialog.Dispose ();
			Close ();
		}
	}
}
