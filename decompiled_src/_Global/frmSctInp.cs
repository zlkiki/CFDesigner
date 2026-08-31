// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FlexCell;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmSctInp : Form
{
	private IContainer components;

	private bool blnTabSct;

	private bool blnStoreUndo;

	private bool blnValidating;

	public bool blnCodeChange;

	internal virtual TabControl tabSct {
		[CompilerGenerated]
		get {
			return _tabSct;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tabSct_SelectedIndexChanged;
			TabControl tabControl = _tabSct;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged -= value2;
			}
			_tabSct = value;
			tabControl = _tabSct;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tabSection")]
	internal virtual TabPage tabSection {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabPart")]
	internal virtual TabPage tabPart {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboConnSpacing {
		[CompilerGenerated]
		get {
			return _cboConnSpacing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboConnSpacing;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboConnSpacing = value;
			comboBox = _cboConnSpacing;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblConnSpacing")]
	internal virtual Label lblConnSpacing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboCwOverride {
		[CompilerGenerated]
		get {
			return _cboCwOverride;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboCwOverride;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboCwOverride = value;
			comboBox = _cboCwOverride;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCwOverride")]
	internal virtual Label lblCwOverride {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboJOverride {
		[CompilerGenerated]
		get {
			return _cboJOverride;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboJOverride;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboJOverride = value;
			comboBox = _cboJOverride;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblJOverride")]
	internal virtual Label lblJOverride {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboTensile {
		[CompilerGenerated]
		get {
			return _cboTensile;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboTensile;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboTensile = value;
			comboBox = _cboTensile;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblTensile")]
	internal virtual Label lblTensile {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboYield {
		[CompilerGenerated]
		get {
			return _cboYield;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboYield;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboYield = value;
			comboBox = _cboYield;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblYield")]
	internal virtual Label lblYield {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkColdWork {
		[CompilerGenerated]
		get {
			return _chkColdWork;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkColdWork_CheckedChanged;
			CheckBox checkBox = _chkColdWork;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkColdWork = value;
			checkBox = _chkColdWork;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button cmdCustom {
		[CompilerGenerated]
		get {
			return _cmdCustom;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCustom_Click;
			Button button = _cmdCustom;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCustom = value;
			button = _cmdCustom;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboMaterial {
		[CompilerGenerated]
		get {
			return _cboMaterial;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboMaterial_GotFocus;
			EventHandler value3 = cboMaterial_LostFocus;
			EventHandler value4 = cboMaterial_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.LostFocus -= value3;
				comboBox.SelectedIndexChanged -= value4;
			}
			_cboMaterial = value;
			comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.LostFocus += value3;
				comboBox.SelectedIndexChanged += value4;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMaterial")]
	internal virtual Label lblMaterial {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRevised")]
	internal virtual TextBox txtRevised {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblRevised")]
	internal virtual Label lblRevised {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtProject {
		[CompilerGenerated]
		get {
			return _txtProject;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtGeneral_GotFocus;
			KeyPressEventHandler value3 = txtGeneral_KeyPress;
			CancelEventHandler value4 = txtGeneral_Validating;
			TextBox textBox = _txtProject;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.Validating -= value4;
			}
			_txtProject = value;
			textBox = _txtProject;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.Validating += value4;
			}
		}
	}

	[field: AccessedThroughProperty ("lblProject")]
	internal virtual Label lblProject {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtDescription {
		[CompilerGenerated]
		get {
			return _txtDescription;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtGeneral_GotFocus;
			KeyPressEventHandler value3 = txtGeneral_KeyPress;
			CancelEventHandler value4 = txtGeneral_Validating;
			TextBox textBox = _txtDescription;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.Validating -= value4;
			}
			_txtDescription = value;
			textBox = _txtDescription;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.Validating += value4;
			}
		}
	}

	[field: AccessedThroughProperty ("lblDescription")]
	internal virtual Label lblDescription {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabElements")]
	internal virtual TabPage tabElements {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabDSM")]
	internal virtual TabPage tabDSM {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("grpCG")]
	internal virtual GroupBox grpCG {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtY2")]
	internal virtual TextBox txtY2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtY1")]
	internal virtual TextBox txtY1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblYcg")]
	internal virtual Label lblYcg {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtX2")]
	internal virtual TextBox txtX2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtX1")]
	internal virtual TextBox txtX1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblXcg")]
	internal virtual Label lblXcg {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblCorner2")]
	internal virtual Label lblCorner2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblCorner1")]
	internal virtual Label lblCorner1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("grpPlacement")]
	internal virtual GroupBox grpPlacement {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboY {
		[CompilerGenerated]
		get {
			return _cboY;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboXY_GotFocus;
			KeyPressEventHandler value3 = cboXY_KeyPress;
			EventHandler value4 = cboXY_DropDown;
			EventHandler value5 = cboXY_SelectedIndexChanged;
			CancelEventHandler value6 = cboXY_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboY;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboY = value;
			comboBox = _cboY;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboReferenceY {
		[CompilerGenerated]
		get {
			return _cboReferenceY;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboReferenceXY_GotFocus;
			EventHandler value3 = cboReferenceXY_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboReferenceY;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			_cboReferenceY = value;
			comboBox = _cboReferenceY;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("lblY")]
	internal virtual Label lblY {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboX {
		[CompilerGenerated]
		get {
			return _cboX;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboXY_GotFocus;
			KeyPressEventHandler value3 = cboXY_KeyPress;
			EventHandler value4 = cboXY_DropDown;
			EventHandler value5 = cboXY_SelectedIndexChanged;
			CancelEventHandler value6 = cboXY_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboX;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboX = value;
			comboBox = _cboX;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboReferenceX {
		[CompilerGenerated]
		get {
			return _cboReferenceX;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboReferenceXY_GotFocus;
			EventHandler value3 = cboReferenceXY_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboReferenceX;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			_cboReferenceX = value;
			comboBox = _cboReferenceX;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("lblX")]
	internal virtual Label lblX {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkClosed {
		[CompilerGenerated]
		get {
			return _chkClosed;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkClosed_CheckedChanged;
			CheckBox checkBox = _chkClosed;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkClosed = value;
			checkBox = _chkClosed;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkCenterline {
		[CompilerGenerated]
		get {
			return _chkCenterline;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkCenterline_CheckedChanged;
			CheckBox checkBox = _chkCenterline;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkCenterline = value;
			checkBox = _chkCenterline;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboRadius {
		[CompilerGenerated]
		get {
			return _cboRadius;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboPart_GotFocus;
			KeyPressEventHandler value3 = cboPart_KeyPress;
			EventHandler value4 = cboPart_DropDown;
			EventHandler value5 = cboPart_SelectedIndexChanged;
			CancelEventHandler value6 = cboPart_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboRadius;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboRadius = value;
			comboBox = _cboRadius;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRadius")]
	internal virtual Label lblRadius {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboThickness {
		[CompilerGenerated]
		get {
			return _cboThickness;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboPart_GotFocus;
			KeyPressEventHandler value3 = cboPart_KeyPress;
			EventHandler value4 = cboPart_DropDown;
			EventHandler value5 = cboPart_SelectedIndexChanged;
			CancelEventHandler value6 = cboPart_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboThickness;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboThickness = value;
			comboBox = _cboThickness;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboThicknessName {
		[CompilerGenerated]
		get {
			return _cboThicknessName;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboThicknessName_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboThicknessName;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboThicknessName = value;
			comboBox = _cboThicknessName;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblThickness")]
	internal virtual Label lblThickness {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboPartName {
		[CompilerGenerated]
		get {
			return _cboPartName;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboPart_GotFocus;
			KeyPressEventHandler value3 = cboPart_KeyPress;
			EventHandler value4 = cboPart_DropDown;
			EventHandler value5 = cboPart_SelectedIndexChanged;
			CancelEventHandler value6 = cboPart_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboPartName;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboPartName = value;
			comboBox = _cboPartName;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblPartName")]
	internal virtual Label lblPartName {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboPartList {
		[CompilerGenerated]
		get {
			return _cboPartList;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboPartList_GotFocus;
			EventHandler value3 = cboPartList_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboPartList;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.SelectedIndexChanged -= value3;
			}
			_cboPartList = value;
			comboBox = _cboPartList;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.SelectedIndexChanged += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("lblPartName2")]
	internal virtual Label lblPartName2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkPrequalified {
		[CompilerGenerated]
		get {
			return _chkPrequalified;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkPrequalified_CheckedChanged;
			CheckBox checkBox = _chkPrequalified;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkPrequalified = value;
			checkBox = _chkPrequalified;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkUseDSM {
		[CompilerGenerated]
		get {
			return _chkUseDSM;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkUseDSM_CheckedChanged;
			CheckBox checkBox = _chkUseDSM;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkUseDSM = value;
			checkBox = _chkUseDSM;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditElm")]
	internal virtual TextBox txtEditElm {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Grid grdElements {
		[CompilerGenerated]
		get {
			return _grdElements;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangeEventHandler obj = grdElements_CellChange;
			Grid.KeyDownEventHandler obj2 = grdElements_KeyDown;
			Grid.MouseDownEventHandler obj3 = grdElements_MouseDown;
			Grid.SelChangeEventHandler obj4 = grdElements_SelChange;
			Grid grid = _grdElements;
			if (grid != null) {
				grid.CellChange -= obj;
				grid.KeyDown -= obj2;
				grid.MouseDown -= obj3;
				grid.SelChange -= obj4;
			}
			_grdElements = value;
			grid = _grdElements;
			if (grid != null) {
				grid.CellChange += obj;
				grid.KeyDown += obj2;
				grid.MouseDown += obj3;
				grid.SelChange += obj4;
			}
		}
	}

	internal virtual Grid grdDSM {
		[CompilerGenerated]
		get {
			return _grdDSM;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangeEventHandler obj = grdDSM_CellChange;
			Grid grid = _grdDSM;
			if (grid != null) {
				grid.CellChange -= obj;
			}
			_grdDSM = value;
			grid = _grdDSM;
			if (grid != null) {
				grid.CellChange += obj;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditDSM")]
	internal virtual TextBox txtEditDSM {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdDSM {
		[CompilerGenerated]
		get {
			return _cmdDSM;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdDSM_Click;
			Button button = _cmdDSM;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdDSM = value;
			button = _cmdDSM;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblHoleLength")]
	internal virtual Label lblHoleLength {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkReserve {
		[CompilerGenerated]
		get {
			return _chkReserve;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkReserve_CheckedChanged;
			CheckBox checkBox = _chkReserve;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkReserve = value;
			checkBox = _chkReserve;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboHoleSpacing {
		[CompilerGenerated]
		get {
			return _cboHoleSpacing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboHoleSpacing;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboHoleSpacing = value;
			comboBox = _cboHoleSpacing;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboHoleLength {
		[CompilerGenerated]
		get {
			return _cboHoleLength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_GotFocus;
			KeyPressEventHandler value3 = cboSection_KeyPress;
			EventHandler value4 = cboSection_DropDown;
			EventHandler value5 = cboSection_SelectedIndexChanged;
			CancelEventHandler value6 = cboSection_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboHoleLength;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboHoleLength = value;
			comboBox = _cboHoleLength;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblHoleSpacing")]
	internal virtual Label lblHoleSpacing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmSctInp ()
	{
		base.Load += frmSctInp_Load;
		base.Activated += frmSctInp_Activated;
		base.Deactivate += frmSctInp_Deactivate;
		base.Resize += frmSctInp_Resize;
		base.KeyDown += frmSctInp_KeyDown;
		base.FormClosing += frmSctInp_FormClosing;
		base.FormClosed += frmSctInp_FormClosed;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmSctInp));
		this.tabSct = new System.Windows.Forms.TabControl ();
		this.tabSection = new System.Windows.Forms.TabPage ();
		this.cboHoleSpacing = new System.Windows.Forms.ComboBox ();
		this.cboHoleLength = new System.Windows.Forms.ComboBox ();
		this.lblHoleSpacing = new System.Windows.Forms.Label ();
		this.chkReserve = new System.Windows.Forms.CheckBox ();
		this.lblHoleLength = new System.Windows.Forms.Label ();
		this.cboConnSpacing = new System.Windows.Forms.ComboBox ();
		this.lblConnSpacing = new System.Windows.Forms.Label ();
		this.cboCwOverride = new System.Windows.Forms.ComboBox ();
		this.lblCwOverride = new System.Windows.Forms.Label ();
		this.cboJOverride = new System.Windows.Forms.ComboBox ();
		this.lblJOverride = new System.Windows.Forms.Label ();
		this.cboTensile = new System.Windows.Forms.ComboBox ();
		this.lblTensile = new System.Windows.Forms.Label ();
		this.cboYield = new System.Windows.Forms.ComboBox ();
		this.lblYield = new System.Windows.Forms.Label ();
		this.chkColdWork = new System.Windows.Forms.CheckBox ();
		this.cmdCustom = new System.Windows.Forms.Button ();
		this.cboMaterial = new System.Windows.Forms.ComboBox ();
		this.lblMaterial = new System.Windows.Forms.Label ();
		this.txtRevised = new System.Windows.Forms.TextBox ();
		this.lblRevised = new System.Windows.Forms.Label ();
		this.txtProject = new System.Windows.Forms.TextBox ();
		this.lblProject = new System.Windows.Forms.Label ();
		this.txtDescription = new System.Windows.Forms.TextBox ();
		this.lblDescription = new System.Windows.Forms.Label ();
		this.tabPart = new System.Windows.Forms.TabPage ();
		this.grpCG = new System.Windows.Forms.GroupBox ();
		this.txtY2 = new System.Windows.Forms.TextBox ();
		this.txtY1 = new System.Windows.Forms.TextBox ();
		this.lblYcg = new System.Windows.Forms.Label ();
		this.txtX2 = new System.Windows.Forms.TextBox ();
		this.txtX1 = new System.Windows.Forms.TextBox ();
		this.lblXcg = new System.Windows.Forms.Label ();
		this.lblCorner2 = new System.Windows.Forms.Label ();
		this.lblCorner1 = new System.Windows.Forms.Label ();
		this.grpPlacement = new System.Windows.Forms.GroupBox ();
		this.cboY = new System.Windows.Forms.ComboBox ();
		this.cboReferenceY = new System.Windows.Forms.ComboBox ();
		this.lblY = new System.Windows.Forms.Label ();
		this.cboX = new System.Windows.Forms.ComboBox ();
		this.cboReferenceX = new System.Windows.Forms.ComboBox ();
		this.lblX = new System.Windows.Forms.Label ();
		this.chkClosed = new System.Windows.Forms.CheckBox ();
		this.chkCenterline = new System.Windows.Forms.CheckBox ();
		this.cboRadius = new System.Windows.Forms.ComboBox ();
		this.lblRadius = new System.Windows.Forms.Label ();
		this.cboThickness = new System.Windows.Forms.ComboBox ();
		this.cboThicknessName = new System.Windows.Forms.ComboBox ();
		this.lblThickness = new System.Windows.Forms.Label ();
		this.cboPartName = new System.Windows.Forms.ComboBox ();
		this.lblPartName = new System.Windows.Forms.Label ();
		this.tabElements = new System.Windows.Forms.TabPage ();
		this.txtEditElm = new System.Windows.Forms.TextBox ();
		this.grdElements = new FlexCell.Grid ();
		this.cboPartList = new System.Windows.Forms.ComboBox ();
		this.lblPartName2 = new System.Windows.Forms.Label ();
		this.tabDSM = new System.Windows.Forms.TabPage ();
		this.cmdDSM = new System.Windows.Forms.Button ();
		this.txtEditDSM = new System.Windows.Forms.TextBox ();
		this.grdDSM = new FlexCell.Grid ();
		this.chkPrequalified = new System.Windows.Forms.CheckBox ();
		this.chkUseDSM = new System.Windows.Forms.CheckBox ();
		this.tabSct.SuspendLayout ();
		this.tabSection.SuspendLayout ();
		this.tabPart.SuspendLayout ();
		this.grpCG.SuspendLayout ();
		this.grpPlacement.SuspendLayout ();
		this.tabElements.SuspendLayout ();
		this.tabDSM.SuspendLayout ();
		base.SuspendLayout ();
		this.tabSct.Controls.Add (this.tabSection);
		this.tabSct.Controls.Add (this.tabPart);
		this.tabSct.Controls.Add (this.tabElements);
		this.tabSct.Controls.Add (this.tabDSM);
		this.tabSct.Location = new System.Drawing.Point (0, 0);
		this.tabSct.Name = "tabSct";
		this.tabSct.SelectedIndex = 0;
		this.tabSct.Size = new System.Drawing.Size (303, 376);
		this.tabSct.TabIndex = 0;
		this.tabSection.Controls.Add (this.cboHoleSpacing);
		this.tabSection.Controls.Add (this.cboHoleLength);
		this.tabSection.Controls.Add (this.lblHoleSpacing);
		this.tabSection.Controls.Add (this.chkReserve);
		this.tabSection.Controls.Add (this.lblHoleLength);
		this.tabSection.Controls.Add (this.cboConnSpacing);
		this.tabSection.Controls.Add (this.lblConnSpacing);
		this.tabSection.Controls.Add (this.cboCwOverride);
		this.tabSection.Controls.Add (this.lblCwOverride);
		this.tabSection.Controls.Add (this.cboJOverride);
		this.tabSection.Controls.Add (this.lblJOverride);
		this.tabSection.Controls.Add (this.cboTensile);
		this.tabSection.Controls.Add (this.lblTensile);
		this.tabSection.Controls.Add (this.cboYield);
		this.tabSection.Controls.Add (this.lblYield);
		this.tabSection.Controls.Add (this.chkColdWork);
		this.tabSection.Controls.Add (this.cmdCustom);
		this.tabSection.Controls.Add (this.cboMaterial);
		this.tabSection.Controls.Add (this.lblMaterial);
		this.tabSection.Controls.Add (this.txtRevised);
		this.tabSection.Controls.Add (this.lblRevised);
		this.tabSection.Controls.Add (this.txtProject);
		this.tabSection.Controls.Add (this.lblProject);
		this.tabSection.Controls.Add (this.txtDescription);
		this.tabSection.Controls.Add (this.lblDescription);
		this.tabSection.Location = new System.Drawing.Point (4, 22);
		this.tabSection.Name = "tabSection";
		this.tabSection.Padding = new System.Windows.Forms.Padding (3);
		this.tabSection.Size = new System.Drawing.Size (295, 350);
		this.tabSection.TabIndex = 0;
		this.tabSection.Tag = "section-inputs-section.htm";
		this.tabSection.Text = "Section";
		this.tabSection.UseVisualStyleBackColor = true;
		this.cboHoleSpacing.FormattingEnabled = true;
		this.cboHoleSpacing.Location = new System.Drawing.Point (134, 322);
		this.cboHoleSpacing.Name = "cboHoleSpacing";
		this.cboHoleSpacing.Size = new System.Drawing.Size (154, 21);
		this.cboHoleSpacing.TabIndex = 24;
		this.cboHoleLength.FormattingEnabled = true;
		this.cboHoleLength.Location = new System.Drawing.Point (134, 295);
		this.cboHoleLength.Name = "cboHoleLength";
		this.cboHoleLength.Size = new System.Drawing.Size (154, 21);
		this.cboHoleLength.TabIndex = 22;
		this.lblHoleSpacing.Location = new System.Drawing.Point (8, 325);
		this.lblHoleSpacing.Name = "lblHoleSpacing";
		this.lblHoleSpacing.Size = new System.Drawing.Size (120, 17);
		this.lblHoleSpacing.TabIndex = 23;
		this.lblHoleSpacing.Text = "Hole Spacing";
		this.chkReserve.AutoSize = true;
		this.chkReserve.Location = new System.Drawing.Point (11, 133);
		this.chkReserve.Name = "chkReserve";
		this.chkReserve.Size = new System.Drawing.Size (215, 17);
		this.chkReserve.TabIndex = 10;
		this.chkReserve.Text = "Apply inelastic reserve strength increase";
		this.chkReserve.UseVisualStyleBackColor = true;
		this.lblHoleLength.Location = new System.Drawing.Point (8, 298);
		this.lblHoleLength.Name = "lblHoleLength";
		this.lblHoleLength.Size = new System.Drawing.Size (120, 17);
		this.lblHoleLength.TabIndex = 21;
		this.lblHoleLength.Text = "Hole Length";
		this.cboConnSpacing.FormattingEnabled = true;
		this.cboConnSpacing.Location = new System.Drawing.Point (134, 268);
		this.cboConnSpacing.Name = "cboConnSpacing";
		this.cboConnSpacing.Size = new System.Drawing.Size (154, 21);
		this.cboConnSpacing.TabIndex = 20;
		this.lblConnSpacing.Location = new System.Drawing.Point (8, 265);
		this.lblConnSpacing.Name = "lblConnSpacing";
		this.lblConnSpacing.Size = new System.Drawing.Size (120, 32);
		this.lblConnSpacing.TabIndex = 19;
		this.lblConnSpacing.Text = "Connector Spacing (built-up sections)";
		this.cboCwOverride.FormattingEnabled = true;
		this.cboCwOverride.Location = new System.Drawing.Point (134, 241);
		this.cboCwOverride.Name = "cboCwOverride";
		this.cboCwOverride.Size = new System.Drawing.Size (154, 21);
		this.cboCwOverride.TabIndex = 18;
		this.lblCwOverride.Location = new System.Drawing.Point (8, 244);
		this.lblCwOverride.Name = "lblCwOverride";
		this.lblCwOverride.Size = new System.Drawing.Size (120, 17);
		this.lblCwOverride.TabIndex = 17;
		this.lblCwOverride.Text = "Cw Override";
		this.cboJOverride.FormattingEnabled = true;
		this.cboJOverride.Location = new System.Drawing.Point (134, 214);
		this.cboJOverride.Name = "cboJOverride";
		this.cboJOverride.Size = new System.Drawing.Size (154, 21);
		this.cboJOverride.TabIndex = 16;
		this.lblJOverride.Location = new System.Drawing.Point (8, 217);
		this.lblJOverride.Name = "lblJOverride";
		this.lblJOverride.Size = new System.Drawing.Size (120, 17);
		this.lblJOverride.TabIndex = 15;
		this.lblJOverride.Text = "J Override";
		this.cboTensile.FormattingEnabled = true;
		this.cboTensile.Location = new System.Drawing.Point (134, 187);
		this.cboTensile.Name = "cboTensile";
		this.cboTensile.Size = new System.Drawing.Size (154, 21);
		this.cboTensile.TabIndex = 14;
		this.lblTensile.Location = new System.Drawing.Point (8, 190);
		this.lblTensile.Name = "lblTensile";
		this.lblTensile.Size = new System.Drawing.Size (120, 17);
		this.lblTensile.TabIndex = 13;
		this.lblTensile.Text = "Tensile Strength, Fu";
		this.cboYield.FormattingEnabled = true;
		this.cboYield.Location = new System.Drawing.Point (134, 160);
		this.cboYield.Name = "cboYield";
		this.cboYield.Size = new System.Drawing.Size (154, 21);
		this.cboYield.TabIndex = 12;
		this.lblYield.Location = new System.Drawing.Point (8, 164);
		this.lblYield.Name = "lblYield";
		this.lblYield.Size = new System.Drawing.Size (120, 17);
		this.lblYield.TabIndex = 11;
		this.lblYield.Text = "Yield Strength, Fy";
		this.chkColdWork.AutoSize = true;
		this.chkColdWork.Location = new System.Drawing.Point (11, 110);
		this.chkColdWork.Name = "chkColdWork";
		this.chkColdWork.Size = new System.Drawing.Size (234, 17);
		this.chkColdWork.TabIndex = 9;
		this.chkColdWork.Text = "Apply cold work of forming strength increase";
		this.chkColdWork.UseVisualStyleBackColor = true;
		this.cmdCustom.Location = new System.Drawing.Point (263, 82);
		this.cmdCustom.Name = "cmdCustom";
		this.cmdCustom.Size = new System.Drawing.Size (25, 21);
		this.cmdCustom.TabIndex = 8;
		this.cmdCustom.Text = "...";
		this.cmdCustom.UseVisualStyleBackColor = true;
		this.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboMaterial.FormattingEnabled = true;
		this.cboMaterial.Location = new System.Drawing.Point (100, 83);
		this.cboMaterial.Name = "cboMaterial";
		this.cboMaterial.Size = new System.Drawing.Size (157, 21);
		this.cboMaterial.TabIndex = 7;
		this.lblMaterial.Location = new System.Drawing.Point (8, 86);
		this.lblMaterial.Name = "lblMaterial";
		this.lblMaterial.Size = new System.Drawing.Size (86, 17);
		this.lblMaterial.TabIndex = 6;
		this.lblMaterial.Text = "Material Type";
		this.txtRevised.Location = new System.Drawing.Point (82, 56);
		this.txtRevised.Name = "txtRevised";
		this.txtRevised.ReadOnly = true;
		this.txtRevised.Size = new System.Drawing.Size (206, 20);
		this.txtRevised.TabIndex = 5;
		this.lblRevised.Location = new System.Drawing.Point (8, 59);
		this.lblRevised.Name = "lblRevised";
		this.lblRevised.Size = new System.Drawing.Size (68, 17);
		this.lblRevised.TabIndex = 4;
		this.lblRevised.Text = "Revised";
		this.txtProject.Location = new System.Drawing.Point (82, 30);
		this.txtProject.MaxLength = 40;
		this.txtProject.Name = "txtProject";
		this.txtProject.Size = new System.Drawing.Size (206, 20);
		this.txtProject.TabIndex = 3;
		this.lblProject.Location = new System.Drawing.Point (8, 33);
		this.lblProject.Name = "lblProject";
		this.lblProject.Size = new System.Drawing.Size (68, 17);
		this.lblProject.TabIndex = 2;
		this.lblProject.Text = "Project";
		this.txtDescription.Location = new System.Drawing.Point (82, 4);
		this.txtDescription.MaxLength = 40;
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.Size = new System.Drawing.Size (206, 20);
		this.txtDescription.TabIndex = 1;
		this.lblDescription.Location = new System.Drawing.Point (8, 7);
		this.lblDescription.Name = "lblDescription";
		this.lblDescription.Size = new System.Drawing.Size (68, 17);
		this.lblDescription.TabIndex = 0;
		this.lblDescription.Text = "Description";
		this.tabPart.Controls.Add (this.grpCG);
		this.tabPart.Controls.Add (this.grpPlacement);
		this.tabPart.Controls.Add (this.chkClosed);
		this.tabPart.Controls.Add (this.chkCenterline);
		this.tabPart.Controls.Add (this.cboRadius);
		this.tabPart.Controls.Add (this.lblRadius);
		this.tabPart.Controls.Add (this.cboThickness);
		this.tabPart.Controls.Add (this.cboThicknessName);
		this.tabPart.Controls.Add (this.lblThickness);
		this.tabPart.Controls.Add (this.cboPartName);
		this.tabPart.Controls.Add (this.lblPartName);
		this.tabPart.Location = new System.Drawing.Point (4, 22);
		this.tabPart.Name = "tabPart";
		this.tabPart.Padding = new System.Windows.Forms.Padding (3);
		this.tabPart.Size = new System.Drawing.Size (295, 350);
		this.tabPart.TabIndex = 1;
		this.tabPart.Tag = "section-inputs-part.htm";
		this.tabPart.Text = "Part";
		this.tabPart.UseVisualStyleBackColor = true;
		this.grpCG.Controls.Add (this.txtY2);
		this.grpCG.Controls.Add (this.txtY1);
		this.grpCG.Controls.Add (this.lblYcg);
		this.grpCG.Controls.Add (this.txtX2);
		this.grpCG.Controls.Add (this.txtX1);
		this.grpCG.Controls.Add (this.lblXcg);
		this.grpCG.Controls.Add (this.lblCorner2);
		this.grpCG.Controls.Add (this.lblCorner1);
		this.grpCG.Location = new System.Drawing.Point (8, 202);
		this.grpCG.Name = "grpCG";
		this.grpCG.Size = new System.Drawing.Size (280, 95);
		this.grpCG.TabIndex = 11;
		this.grpCG.TabStop = false;
		this.grpCG.Text = "Distance from Center of Gravity";
		this.txtY2.Location = new System.Drawing.Point (96, 16);
		this.txtY2.Name = "txtY2";
		this.txtY2.ReadOnly = true;
		this.txtY2.Size = new System.Drawing.Size (80, 20);
		this.txtY2.TabIndex = 10;
		this.txtY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtY1.Location = new System.Drawing.Point (96, 65);
		this.txtY1.Name = "txtY1";
		this.txtY1.ReadOnly = true;
		this.txtY1.Size = new System.Drawing.Size (80, 20);
		this.txtY1.TabIndex = 9;
		this.txtY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.lblYcg.Location = new System.Drawing.Point (30, 68);
		this.lblYcg.Name = "lblYcg";
		this.lblYcg.Size = new System.Drawing.Size (60, 17);
		this.lblYcg.TabIndex = 8;
		this.lblYcg.Text = "Bottom";
		this.lblYcg.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.txtX2.Location = new System.Drawing.Point (140, 40);
		this.txtX2.Name = "txtX2";
		this.txtX2.ReadOnly = true;
		this.txtX2.Size = new System.Drawing.Size (80, 20);
		this.txtX2.TabIndex = 6;
		this.txtX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtX1.Location = new System.Drawing.Point (54, 40);
		this.txtX1.Name = "txtX1";
		this.txtX1.ReadOnly = true;
		this.txtX1.Size = new System.Drawing.Size (80, 20);
		this.txtX1.TabIndex = 5;
		this.txtX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.lblXcg.Location = new System.Drawing.Point (23, 43);
		this.lblXcg.Name = "lblXcg";
		this.lblXcg.Size = new System.Drawing.Size (25, 17);
		this.lblXcg.TabIndex = 4;
		this.lblXcg.Text = "Left";
		this.lblXcg.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lblCorner2.Location = new System.Drawing.Point (226, 43);
		this.lblCorner2.Name = "lblCorner2";
		this.lblCorner2.Size = new System.Drawing.Size (40, 17);
		this.lblCorner2.TabIndex = 3;
		this.lblCorner2.Text = "Right";
		this.lblCorner1.Location = new System.Drawing.Point (30, 19);
		this.lblCorner1.Name = "lblCorner1";
		this.lblCorner1.Size = new System.Drawing.Size (60, 17);
		this.lblCorner1.TabIndex = 2;
		this.lblCorner1.Text = "Top";
		this.lblCorner1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.grpPlacement.Controls.Add (this.cboY);
		this.grpPlacement.Controls.Add (this.cboReferenceY);
		this.grpPlacement.Controls.Add (this.lblY);
		this.grpPlacement.Controls.Add (this.cboX);
		this.grpPlacement.Controls.Add (this.cboReferenceX);
		this.grpPlacement.Controls.Add (this.lblX);
		this.grpPlacement.Location = new System.Drawing.Point (6, 118);
		this.grpPlacement.Name = "grpPlacement";
		this.grpPlacement.Size = new System.Drawing.Size (282, 78);
		this.grpPlacement.TabIndex = 10;
		this.grpPlacement.TabStop = false;
		this.grpPlacement.Text = "Placement of Part from Origin";
		this.cboY.FormattingEnabled = true;
		this.cboY.Location = new System.Drawing.Point (177, 46);
		this.cboY.Name = "cboY";
		this.cboY.Size = new System.Drawing.Size (99, 21);
		this.cboY.TabIndex = 9;
		this.cboReferenceY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboReferenceY.FormattingEnabled = true;
		this.cboReferenceY.Location = new System.Drawing.Point (37, 46);
		this.cboReferenceY.Name = "cboReferenceY";
		this.cboReferenceY.Size = new System.Drawing.Size (134, 21);
		this.cboReferenceY.TabIndex = 8;
		this.lblY.Location = new System.Drawing.Point (6, 49);
		this.lblY.Name = "lblY";
		this.lblY.Size = new System.Drawing.Size (25, 17);
		this.lblY.TabIndex = 7;
		this.lblY.Text = "Y";
		this.lblY.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.cboX.FormattingEnabled = true;
		this.cboX.Location = new System.Drawing.Point (177, 19);
		this.cboX.Name = "cboX";
		this.cboX.Size = new System.Drawing.Size (99, 21);
		this.cboX.TabIndex = 6;
		this.cboReferenceX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboReferenceX.FormattingEnabled = true;
		this.cboReferenceX.Location = new System.Drawing.Point (37, 19);
		this.cboReferenceX.Name = "cboReferenceX";
		this.cboReferenceX.Size = new System.Drawing.Size (134, 21);
		this.cboReferenceX.TabIndex = 5;
		this.lblX.Location = new System.Drawing.Point (6, 22);
		this.lblX.Name = "lblX";
		this.lblX.Size = new System.Drawing.Size (25, 17);
		this.lblX.TabIndex = 2;
		this.lblX.Text = "X";
		this.lblX.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.chkClosed.AutoSize = true;
		this.chkClosed.Location = new System.Drawing.Point (189, 90);
		this.chkClosed.Name = "chkClosed";
		this.chkClosed.Size = new System.Drawing.Size (80, 17);
		this.chkClosed.TabIndex = 9;
		this.chkClosed.Text = "Closed Part";
		this.chkClosed.UseVisualStyleBackColor = true;
		this.chkCenterline.AutoSize = true;
		this.chkCenterline.Location = new System.Drawing.Point (11, 90);
		this.chkCenterline.Name = "chkCenterline";
		this.chkCenterline.Size = new System.Drawing.Size (130, 17);
		this.chkCenterline.TabIndex = 8;
		this.chkCenterline.Text = "Centerline Dimensions";
		this.chkCenterline.UseVisualStyleBackColor = true;
		this.cboRadius.FormattingEnabled = true;
		this.cboRadius.Location = new System.Drawing.Point (190, 58);
		this.cboRadius.Name = "cboRadius";
		this.cboRadius.Size = new System.Drawing.Size (99, 21);
		this.cboRadius.TabIndex = 7;
		this.lblRadius.Location = new System.Drawing.Point (63, 61);
		this.lblRadius.Name = "lblRadius";
		this.lblRadius.Size = new System.Drawing.Size (121, 17);
		this.lblRadius.TabIndex = 6;
		this.lblRadius.Text = "Default Inside Radius";
		this.lblRadius.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.cboThickness.FormattingEnabled = true;
		this.cboThickness.Location = new System.Drawing.Point (190, 31);
		this.cboThickness.Name = "cboThickness";
		this.cboThickness.Size = new System.Drawing.Size (99, 21);
		this.cboThickness.TabIndex = 5;
		this.cboThicknessName.DropDownHeight = 120;
		this.cboThicknessName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboThicknessName.FormattingEnabled = true;
		this.cboThicknessName.IntegralHeight = false;
		this.cboThicknessName.Location = new System.Drawing.Point (82, 31);
		this.cboThicknessName.Name = "cboThicknessName";
		this.cboThicknessName.Size = new System.Drawing.Size (102, 21);
		this.cboThicknessName.TabIndex = 4;
		this.lblThickness.Location = new System.Drawing.Point (8, 34);
		this.lblThickness.Name = "lblThickness";
		this.lblThickness.Size = new System.Drawing.Size (68, 17);
		this.lblThickness.TabIndex = 3;
		this.lblThickness.Text = "Thickness";
		this.cboPartName.FormattingEnabled = true;
		this.cboPartName.Location = new System.Drawing.Point (82, 4);
		this.cboPartName.MaxLength = 20;
		this.cboPartName.Name = "cboPartName";
		this.cboPartName.Size = new System.Drawing.Size (206, 21);
		this.cboPartName.TabIndex = 2;
		this.lblPartName.Location = new System.Drawing.Point (8, 7);
		this.lblPartName.Name = "lblPartName";
		this.lblPartName.Size = new System.Drawing.Size (68, 17);
		this.lblPartName.TabIndex = 1;
		this.lblPartName.Text = "Part Name";
		this.tabElements.Controls.Add (this.txtEditElm);
		this.tabElements.Controls.Add (this.grdElements);
		this.tabElements.Controls.Add (this.cboPartList);
		this.tabElements.Controls.Add (this.lblPartName2);
		this.tabElements.Location = new System.Drawing.Point (4, 22);
		this.tabElements.Name = "tabElements";
		this.tabElements.Size = new System.Drawing.Size (295, 350);
		this.tabElements.TabIndex = 2;
		this.tabElements.Tag = "section-inputs-elements.htm";
		this.tabElements.Text = "Elements";
		this.tabElements.UseVisualStyleBackColor = true;
		this.txtEditElm.Location = new System.Drawing.Point (12, 259);
		this.txtEditElm.Name = "txtEditElm";
		this.txtEditElm.Size = new System.Drawing.Size (105, 20);
		this.txtEditElm.TabIndex = 6;
		this.txtEditElm.Visible = false;
		this.grdElements.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdElements.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdElements.BoldFixedCell = false;
		this.grdElements.Cols = 8;
		this.grdElements.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdElements.Location = new System.Drawing.Point (6, 31);
		this.grdElements.Name = "grdElements";
		this.grdElements.Rows = 3;
		this.grdElements.Size = new System.Drawing.Size (281, 215);
		this.grdElements.TabIndex = 5;
		this.cboPartList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboPartList.FormattingEnabled = true;
		this.cboPartList.Location = new System.Drawing.Point (82, 4);
		this.cboPartList.Name = "cboPartList";
		this.cboPartList.Size = new System.Drawing.Size (206, 21);
		this.cboPartList.TabIndex = 4;
		this.lblPartName2.Location = new System.Drawing.Point (8, 7);
		this.lblPartName2.Name = "lblPartName2";
		this.lblPartName2.Size = new System.Drawing.Size (68, 17);
		this.lblPartName2.TabIndex = 3;
		this.lblPartName2.Text = "Part Name";
		this.tabDSM.Controls.Add (this.cmdDSM);
		this.tabDSM.Controls.Add (this.txtEditDSM);
		this.tabDSM.Controls.Add (this.grdDSM);
		this.tabDSM.Controls.Add (this.chkPrequalified);
		this.tabDSM.Controls.Add (this.chkUseDSM);
		this.tabDSM.Location = new System.Drawing.Point (4, 22);
		this.tabDSM.Name = "tabDSM";
		this.tabDSM.Size = new System.Drawing.Size (295, 350);
		this.tabDSM.TabIndex = 3;
		this.tabDSM.Tag = "section-inputs-dsm.htm";
		this.tabDSM.Text = "Direct Strength";
		this.tabDSM.UseVisualStyleBackColor = true;
		this.cmdDSM.Location = new System.Drawing.Point (190, 28);
		this.cmdDSM.Name = "cmdDSM";
		this.cmdDSM.Size = new System.Drawing.Size (95, 25);
		this.cmdDSM.TabIndex = 2;
		this.cmdDSM.Text = "Generate";
		this.cmdDSM.UseVisualStyleBackColor = true;
		this.txtEditDSM.Location = new System.Drawing.Point (190, 4);
		this.txtEditDSM.Name = "txtEditDSM";
		this.txtEditDSM.Size = new System.Drawing.Size (95, 20);
		this.txtEditDSM.TabIndex = 4;
		this.txtEditDSM.Visible = false;
		this.grdDSM.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdDSM.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdDSM.BoldFixedCell = false;
		this.grdDSM.Cols = 3;
		this.grdDSM.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdDSM.Location = new System.Drawing.Point (8, 61);
		this.grdDSM.MultiSelect = false;
		this.grdDSM.Name = "grdDSM";
		this.grdDSM.Rows = 10;
		this.grdDSM.Size = new System.Drawing.Size (277, 233);
		this.grdDSM.TabIndex = 3;
		this.chkPrequalified.AutoSize = true;
		this.chkPrequalified.Location = new System.Drawing.Point (8, 33);
		this.chkPrequalified.Name = "chkPrequalified";
		this.chkPrequalified.Size = new System.Drawing.Size (120, 17);
		this.chkPrequalified.TabIndex = 1;
		this.chkPrequalified.Text = "Prequalified Section";
		this.chkPrequalified.UseVisualStyleBackColor = true;
		this.chkUseDSM.AutoSize = true;
		this.chkUseDSM.Location = new System.Drawing.Point (8, 6);
		this.chkUseDSM.Name = "chkUseDSM";
		this.chkUseDSM.Size = new System.Drawing.Size (158, 17);
		this.chkUseDSM.TabIndex = 0;
		this.chkUseDSM.Text = "Use Direct Strength Method";
		this.chkUseDSM.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (304, 377);
		base.Controls.Add (this.tabSct);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size (320, 416);
		base.Name = "frmSctInp";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Section Inputs";
		this.tabSct.ResumeLayout (false);
		this.tabSection.ResumeLayout (false);
		this.tabSection.PerformLayout ();
		this.tabPart.ResumeLayout (false);
		this.tabPart.PerformLayout ();
		this.grpCG.ResumeLayout (false);
		this.grpCG.PerformLayout ();
		this.grpPlacement.ResumeLayout (false);
		this.tabElements.ResumeLayout (false);
		this.tabElements.PerformLayout ();
		this.tabDSM.ResumeLayout (false);
		this.tabDSM.PerformLayout ();
		base.ResumeLayout (false);
	}

	public void SetControlData ()
	{
		txtDescription.Tag = new ControlData (byte.MaxValue);
		txtProject.Tag = new ControlData (byte.MaxValue);
		cboYield.Tag = new ControlData (5, 0f, 120f);
		cboTensile.Tag = new ControlData (5, 0f, 120f);
		cboJOverride.Tag = new ControlData (9, 0f, 1E+08f);
		cboCwOverride.Tag = new ControlData (10, 0f, 1E+08f);
		cboConnSpacing.Tag = new ControlData (1, 0f, 1200f);
		cboHoleLength.Tag = new ControlData (1, 0f, 8f);
		cboHoleSpacing.Tag = new ControlData (1, 4f, 1200f);
		cboPartName.Tag = new ControlData (byte.MaxValue);
		cboThickness.Tag = new ControlData (1, 0.001f, 1f);
		cboRadius.Tag = new ControlData (1, 0f, 10f);
		cboX.Tag = new ControlData (1, -100f, 100f);
		cboY.Tag = new ControlData (1, -100f, 100f);
		txtEditElm.Tag = new ControlData (1);
		txtEditDSM.Tag = new ControlData (0, 0f, 1000f);
	}

	public void SetGridTitles ()
	{
		blnCodeChange = true;
		Grid grid = grdElements;
		grid.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid.Column (1).Alignment = AlignmentEnum.RightCenter;
		grid.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid.Column (3).Alignment = AlignmentEnum.RightCenter;
		grid.Column (4).Alignment = AlignmentEnum.LeftCenter;
		grid.Column (5).Alignment = AlignmentEnum.RightCenter;
		grid.Column (6).Alignment = AlignmentEnum.RightCenter;
		grid.Column (7).Alignment = AlignmentEnum.RightCenter;
		grid.Column (4).CellType = CellTypeEnum.ComboBox;
		grid.ComboBox (4).Locked = true;
		grid.ComboBox (4).AutoComplete = true;
		grid.ComboBox (4).Items.Clear ();
		grid.ComboBox (4).Items.Add ("None");
		grid.ComboBox (4).Items.Add ("Single");
		grid.ComboBox (4).Items.Add ("Double");
		grid.ComboBox (4).Items.Add ("Nested");
		grid.ComboBox (4).Items.Add ("Cee");
		grid.ComboBox (4).Items.Add ("Zee");
		grid.ComboBox (4).Items.Add ("Hat");
		grid.ComboBox (4).Items.Add ("Deck");
		grid.Cell (0, 0).Text = "999";
		grid.Column (0).AutoFit ();
		grid.Cell (0, 0).Text = string.Empty;
		grid.Cell (0, 1).Text = "Hole Size";
		grid.Column (1).AutoFit ();
		grid.Cell (0, 1).Text = string.Empty;
		grid.Column (2).Width = grid.Column (1).Width;
		grid.Column (3).Width = grid.Column (1).Width;
		grid.Column (4).Width = grid.Column (1).Width;
		grid.Column (5).Width = grid.Column (1).Width;
		grid.Column (6).Width = grid.Column (1).Width;
		grid.Column (7).Width = grid.Column (1).Width;
		grid.Range (0, 1, 0, 7).WrapText = true;
		grid.Range (0, 1, 0, 7).Alignment = AlignmentEnum.CenterTop;
		grid.Cell (0, 1).Text = "Length\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Cell (0, 2).Text = "Angle\n(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")";
		grid.Cell (0, 3).Text = "Radius\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Cell (0, 4).Text = "Web";
		grid.Cell (0, 5).Text = "k Coef.";
		grid.Cell (0, 6).Text = "Hole Size\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Cell (0, 7).Text = "Distance\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Row (0).AutoFit ();
		grid = null;
		CFS.blnRefreshGrdElements = true;
		blnCodeChange = false;
		blnCodeChange = true;
		Grid grid2 = grdDSM;
		grid2.Cell (0, 0).Text = "Axial";
		grid2.Cell (1, 0).Text = "Compression";
		grid2.Cell (2, 0).Text = "Bending";
		grid2.Cell (3, 0).Text = "Positive Mx";
		grid2.Cell (4, 0).Text = "Negative Mx";
		grid2.Cell (5, 0).Text = "Positive My";
		grid2.Cell (6, 0).Text = "Negative My";
		grid2.Cell (7, 0).Text = "Shear";
		grid2.Cell (8, 0).Text = "Vertical (Y)";
		grid2.Cell (9, 0).Text = "Horizontal (X)";
		grid2.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid2.Column (0).AutoFit ();
		grid2.Column (1).Alignment = AlignmentEnum.RightCenter;
		grid2.Column (1).Width = grid2.Column (0).Width;
		grid2.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid2.Column (2).Width = grid2.Column (0).Width;
		grid2.Cell (0, 1).Text = "Pcrl/Py";
		grid2.Cell (0, 1).Alignment = AlignmentEnum.CenterCenter;
		grid2.Cell (0, 2).Text = "Pcrd/Py";
		grid2.Cell (0, 2).Alignment = AlignmentEnum.CenterCenter;
		grid2.Cell (2, 1).Text = "Mcrl/My";
		grid2.Cell (2, 1).Alignment = AlignmentEnum.CenterCenter;
		grid2.Cell (2, 1).Locked = true;
		grid2.Cell (2, 1).BackColor = grid2.Cell (0, 0).BackColor;
		grid2.Cell (2, 2).Text = "Mcrd/My";
		grid2.Cell (2, 2).Alignment = AlignmentEnum.CenterCenter;
		grid2.Cell (2, 2).Locked = true;
		grid2.Cell (2, 2).BackColor = grid2.Cell (0, 0).BackColor;
		grid2.Cell (7, 1).Text = "Vcr/Vy";
		grid2.Cell (7, 1).Alignment = AlignmentEnum.CenterCenter;
		grid2.Cell (7, 1).Locked = true;
		grid2.Cell (7, 1).BackColor = grid2.Cell (0, 0).BackColor;
		grid2.Cell (7, 2).Locked = true;
		grid2.Cell (7, 2).BackColor = grid2.Cell (0, 0).BackColor;
		grid2.Cell (8, 2).Locked = true;
		grid2.Cell (8, 2).BackColor = grid2.Cell (0, 0).BackColor;
		grid2.Cell (9, 2).Locked = true;
		grid2.Cell (9, 2).BackColor = grid2.Cell (0, 0).BackColor;
		grid2 = null;
		blnCodeChange = false;
	}

	public void AddPart (System.Windows.Forms.ComboBox cboName)
	{
		Section section = CFS.Sections [CFS.intSctNow];
		checked {
			if (cboName.Items.Count - unchecked((int)section.nPart) > 0 || unchecked((uint)section.nPart) >= 255u) {
				return;
			}
			short num = 0;
			string text;
			short num2;
			do {
				num = (short)(num + 1);
				short nPart;
				unchecked {
					text = "Part " + Conversions.ToString ((int)checked((short)unchecked(section.nPart + num)));
					nPart = section.nPart;
					num2 = 1;
				}
				while (num2 <= nPart && Strings.StrComp (section.Part [num2].Name, text, CompareMethod.Text) != 0) {
					num2 = (short)unchecked(num2 + 1);
				}
			} while (num2 <= section.nPart);
			section = null;
			cboName.Items.Add (text);
		}
	}

	private void RenamePart (bool blnSetListIndex = true)
	{
		string text = Strings.Trim (cboPartName.Text);
		if (Strings.StrComp (text, Conversions.ToString (NewLateBinding.LateGet (cboPartName.Tag, null, "Text", new object[0], null, null, null))) == 0) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		if (((uint)section.iPart > (uint)section.nPart) & (Strings.Len (text) == 0)) {
			text = Conversions.ToString (NewLateBinding.LateGet (cboPartName.Tag, null, "Text", new object[0], null, null, null));
		}
		NewLateBinding.LateSetComplex (cboPartName.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			short num = (short)(cboPartName.Items.Count - 1);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Strings.StrComp (cboPartName.Items [num2].ToString (), text, CompareMethod.Text) == 0) {
					text = string.Empty;
					cboPartName.SelectedIndex = num2;
					return;
				}
			}
			if (Strings.Len (text) == 0) {
				CFSInterface.StoreUndoSct ("Delete Part");
				cboPartName.Items.RemoveAt (unchecked((int)section.iPart) - 1);
				short num3 = (short)(unchecked((int)section.iPart) + 1);
				short nPart = section.nPart;
				short num4;
				for (num4 = num3; num4 <= nPart; num4 = (short)unchecked(num4 + 1)) {
					section.Part [num4 - 1] = section.Part [num4];
				}
				section.Part [num4 - 1].Initialize (10);
				if (section.nPart > 0) {
					section.nPart--;
				}
				if (section.iPart > 1) {
					section.iPart--;
				}
				if (section.nPart == 0) {
					section.Part [section.iPart].Name = "Part 1";
				}
				section.SctProp = false;
				CFS.blnRefreshGrdElements = true;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			} else {
				CFSInterface.StoreUndoSct ("Part Name");
				text = Strings.Left (text, 20);
				section.Part [section.iPart].Name = text;
				if (unchecked((uint)section.iPart > (uint)section.nPart)) {
					section.nPart = section.iPart;
				}
				cboPartName.Items [unchecked((int)section.iPart) - 1] = text;
				text = string.Empty;
				if (blnSetListIndex) {
					cboPartName.SelectedIndex = unchecked((int)section.iPart) - 1;
				}
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void SetRadii (Part Part1, float DefRadPrev)
	{
		Part part = Part1;
		string @string = Units.DisplayValue (DefRadPrev, Units.untLength [Units.DefaultUnitIndex [1]], blnShowUnit: false, "", 0, 0);
		short nElem = part.nElem;
		checked {
			for (short num = 1; num <= nElem; num = (short)unchecked(num + 1)) {
				if (Strings.StrComp (Units.DisplayValue (part.Element [num].Rad, Units.untLength [Units.DefaultUnitIndex [1]], blnShowUnit: false, "", 0, 0), @string) == 0) {
					part.Element [num].Rad = part.DefRad;
				}
			}
			part = null;
		}
	}

	private void frmSctInp_Load (object sender, EventArgs e)
	{
		CFS.blnSctInpLoaded = true;
		checked {
			if (CFSInterface.SctInpWidth == 0f) {
				CFSInterface.SctInpWidth = base.Width;
				CFSInterface.SctInpHeight = base.Height;
				CFSInterface.SctInpLeft = (float)((double)((float)(My.MyProject.Forms.mdiCFS.Left + My.MyProject.Forms.mdiCFS.Width) - CFSInterface.SctInpWidth) - (double)(My.MyProject.Forms.mdiCFS.Width - My.MyProject.Forms.mdiCFS.ClientSize.Width) / 2.0);
				CFSInterface.SctInpTop = (float)((double)(My.MyProject.Forms.mdiCFS.Top + (My.MyProject.Forms.mdiCFS.Height - My.MyProject.Forms.mdiCFS.ClientSize.Height)) - (double)(My.MyProject.Forms.mdiCFS.Width - My.MyProject.Forms.mdiCFS.ClientSize.Width) / 2.0);
			}
			Rectangle workingArea = Screen.GetWorkingArea (new Point (0, 0));
			if (CFSInterface.SctInpLeft < 0f) {
				CFSInterface.SctInpLeft = 0f;
			} else if (CFSInterface.SctInpLeft + CFSInterface.SctInpWidth > (float)workingArea.Width) {
				CFSInterface.SctInpLeft = (float)workingArea.Width - CFSInterface.SctInpWidth;
			}
			if (CFSInterface.SctInpTop < 0f) {
				CFSInterface.SctInpTop = 0f;
			} else if (CFSInterface.SctInpTop + CFSInterface.SctInpHeight > (float)workingArea.Height) {
				CFSInterface.SctInpTop = (float)workingArea.Height - CFSInterface.SctInpHeight;
			}
			base.Left = (int)Math.Round (CFSInterface.SctInpLeft);
			base.Top = (int)Math.Round (CFSInterface.SctInpTop);
			base.Width = (int)Math.Round (CFSInterface.SctInpWidth);
			base.Height = (int)Math.Round (CFSInterface.SctInpHeight);
			SetControlData ();
			short num = (short)Information.UBound (CFS.Materials);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (CFS.Materials [num2].Eo [2] > 0f) {
					cboMaterial.Items.Add (new ListItem (Strings.Trim (CFS.Materials [num2].Name), num2));
				}
			}
			cboReferenceX.Items.Add ("To Left Edge");
			cboReferenceX.Items.Add ("To Center of Gravity");
			cboReferenceX.Items.Add ("To Right Edge");
			cboReferenceY.Items.Add ("To Top Edge");
			cboReferenceY.Items.Add ("To Center of Gravity");
			cboReferenceY.Items.Add ("To Bottom Edge");
			short num3 = (short)Information.UBound (CFS.Thicknesses);
			for (short num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				cboThicknessName.Items.Add (CFS.Thicknesses [num2].Name);
			}
			SetGridTitles ();
			blnTabSct = true;
			tabSct.SelectedIndex = CFS.intSctTabNow;
			CFS.blnRefreshGrdElements = true;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		}
	}

	private void frmSctInp_Activated (object sender, EventArgs e)
	{
		int try0000_dispatch = -1;
		int num3 = default(int);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_0007;
				case 120:
					{
						num2 = num;
						switch (num3) {
						case 1:
							break;
						default:
							goto end_IL_0000;
						}
						int num4 = num2 + 1;
						num2 = 0;
						switch (num4) {
						case 1:
							break;
						case 2:
							goto IL_0007;
						case 3:
							goto IL_0015;
						case 4:
							goto IL_0029;
						case 5:
							goto IL_003b;
						case 6:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 7:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_003b:
					num = 5;
					Application.DoEvents ();
					break;
					IL_0007:
					num = 2;
					tabSct.Enabled = true;
					goto IL_0015;
					IL_0015:
					num = 3;
					if (CFS.frmSctPic [CFS.intSctNow] == Form.ActiveForm) {
						goto end_IL_0000_3;
					}
					goto IL_0029;
					IL_0029:
					num = 4;
					CFS.frmSctPic [CFS.intSctNow].BringToFront ();
					goto IL_003b;
					end_IL_0000_2:
					break;
				}
				num = 6;
				Activate ();
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 120;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000_3:
			break;
		}
		if (num2 != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private void frmSctInp_Deactivate (object sender, EventArgs e)
	{
		if (!blnValidating) {
			Control control = base.ActiveControl;
			tabSct.Select ();
			Application.DoEvents ();
			control.Select ();
		}
	}

	private void frmSctInp_Resize (object sender, EventArgs e)
	{
		tabSct.Width = base.ClientSize.Width;
		tabSct.Height = base.ClientSize.Height;
		checked {
			grdElements.Width = tabSct.Width - 20;
			grdElements.Height = tabSct.Height - 60;
			grdDSM.Width = tabSct.Width - 20;
			grdDSM.Height = tabSct.Height - 90;
		}
	}

	private void frmSctInp_KeyDown (object sender, KeyEventArgs e)
	{
		byte b = 0;
		checked {
			if (e.Shift) {
				b = (byte)unchecked((uint)(b + 1));
			}
			if (e.Control) {
				b = (byte)unchecked((uint)(b + 2));
			}
			if (e.Alt) {
				b = (byte)unchecked((uint)(b + 4));
			}
		}
		if (e.KeyCode == Keys.Z && b == 2) {
			if (CFS.intSctNow > 0 && CFS.Sections [CFS.intSctNow].strUndo.Length > 0) {
				CFSInterface.UndoSct ();
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.Y && b == 2) {
			if (CFS.intSctNow > 0 && CFS.Sections [CFS.intSctNow].strRedo.Length > 0) {
				CFSInterface.RedoSct ();
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.F1 && b == 0) {
			Type typeFromHandle = typeof(Help);
			TabPage selectedTab;
			object[] obj = new object[3] {
				this,
				CFS.strAppPath + "CFS.chm",
				(selectedTab = tabSct.SelectedTab).Tag
			};
			object[] array = obj;
			bool[] obj2 = new bool[3] { false, false, true };
			bool[] array2 = obj2;
			NewLateBinding.LateCall (null, typeFromHandle, "ShowHelp", obj, null, null, obj2, IgnoreReturn: true);
			if (array2 [2]) {
				selectedTab.Tag = RuntimeHelpers.GetObjectValue (RuntimeHelpers.GetObjectValue (array [2]));
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.F4 && b == 0) {
			if (CFS.intAnlNow > 0) {
				My.MyProject.Forms.mdiCFS.mnuViewAnalysisInputs_Click (My.MyProject.Forms.mdiCFS.mnuViewAnalysisInputs, null);
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.F && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuFile.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.E && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuEdit.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.V && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuView.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.C && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuCompute.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.T && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuTools.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.W && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuWindows.ShowDropDown ();
			e.Handled = true;
		} else if (e.KeyCode == Keys.H && b == 4) {
			My.MyProject.Forms.mdiCFS.Select ();
			My.MyProject.Forms.mdiCFS.mnuHelp.ShowDropDown ();
			e.Handled = true;
		}
	}

	private void frmSctInp_FormClosing (object sender, FormClosingEventArgs e)
	{
		if (tabSct.Enabled) {
			tabSct.Select ();
		}
	}

	private void frmSctInp_FormClosed (object sender, FormClosedEventArgs e)
	{
		CFSInterface.SctInpLeft = base.Left;
		CFSInterface.SctInpTop = base.Top;
		CFSInterface.SctInpWidth = base.Width;
		CFSInterface.SctInpHeight = base.Height;
		CFS.blnSctInpLoaded = false;
		My.MyProject.Forms.mdiCFS.Activate ();
	}

	private void tabSct_SelectedIndexChanged (object sender, EventArgs e)
	{
		CFS.intSctTabNow = checked((short)tabSct.SelectedIndex);
		CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		if (blnTabSct) {
			switch (tabSct.SelectedIndex) {
			case 0:
				txtDescription.Select ();
				break;
			case 1:
				cboPartName.Select ();
				break;
			case 2:
				grdElements.Select ();
				break;
			case 3:
				if (grdDSM.Enabled) {
					grdDSM.Select ();
				}
				break;
			}
		} else {
			tabSct.Select ();
			blnTabSct = true;
		}
	}

	private void txtGeneral_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void txtGeneral_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r') {
			txtGeneral_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			txtGeneral_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			e.Handled = true;
		}
	}

	private void txtGeneral_Validating (object sender, CancelEventArgs e)
	{
		blnValidating = true;
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		} else if (CFSInterface.Validate ((Control)sender)) {
			string text = Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)));
			Section section = CFS.Sections [CFS.intSctNow];
			bool flag = true;
			if (flag == (sender == txtDescription)) {
				CFSInterface.StoreUndoSct ("Description");
				section.Description = text;
				NewLateBinding.LateSet (sender, null, "Text", new object[1] { text }, null, null);
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { text }, null, null, OptimisticSet: false, RValueBase: true);
				CFSInterface.SetSelection ((Control)sender, blnNumeric: false);
			} else if (flag == (sender == txtProject)) {
				CFSInterface.StoreUndoSct ("Project");
				section.Project = text;
				NewLateBinding.LateSet (sender, null, "Text", new object[1] { text }, null, null);
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { text }, null, null, OptimisticSet: false, RValueBase: true);
				CFSInterface.SetSelection ((Control)sender, blnNumeric: false);
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			CFSInterface.SetMenuEdit ();
			section = null;
		} else {
			e.Cancel = true;
		}
		blnValidating = false;
	}

	private void cboMaterial_GotFocus (object sender, EventArgs e)
	{
		blnStoreUndo = true;
	}

	private void cboMaterial_LostFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (Operators.AndObject (CFS.Sections [CFS.intSctNow].MaterialIndex > 0, Operators.CompareObjectEqual (NewLateBinding.LateGet (cboMaterial.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)))) {
			cboMaterial.Items.RemoveAt (0);
		}
	}

	private void cboMaterial_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		if (blnStoreUndo) {
			CFSInterface.StoreUndoSct ("Material");
			blnStoreUndo = false;
			CFS.Materials [0] = section.Material.Clone ();
		}
		CFS.blnValidate = false;
		section.MaterialIndex = Conversions.ToShort (NewLateBinding.LateGet (cboMaterial.Items [cboMaterial.SelectedIndex], null, "ItemData", new object[0], null, null, null));
		CFS.ModifyDSMValues (CFS.Sections [CFS.intSctNow], CFS.Materials [section.MaterialIndex].Fy [2]);
		int num = 1;
		checked {
			do {
				if (section.Material.Eo [num] != CFS.Materials [section.MaterialIndex].Eo [num]) {
					section.GeomChangeDSM = true;
				}
				num++;
			} while (num <= 5);
			section.Material = CFS.Materials [section.MaterialIndex].Clone ();
			cboYield.Enabled = section.Material.IsCarbon ();
			cboTensile.Enabled = section.Material.IsCarbon ();
			NewLateBinding.LateSetComplex (cboYield.Tag, null, "Min", new object[1] { section.Material.FyMin }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (cboYield.Tag, null, "Max", new object[1] { section.Material.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (cboTensile.Tag, null, "Min", new object[1] { section.Material.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (cboTensile.Tag, null, "Max", new object[1] { section.Material.FuMax }, null, null, OptimisticSet: false, RValueBase: true);
			CFSInterface.SetText (cboYield, section.Material.Fy [2]);
			CFSInterface.SetText (cboTensile, section.Material.Fu);
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.SetMenuEdit ();
			CFS.blnValidate = true;
			section = null;
		}
	}

	private void cboSection_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboSection_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is System.Windows.Forms.ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboSection_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboSection_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void cboSection_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((System.Windows.Forms.ComboBox)sender);
	}

	private void cboSection_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboSection_Validating (object sender, CancelEventArgs e)
	{
		blnValidating = true;
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		} else if (CFSInterface.Validate ((Control)sender)) {
			Section section = CFS.Sections [CFS.intSctNow];
			bool flag = true;
			if (flag == (sender == cboYield)) {
				CFSInterface.StoreUndoSct ("Yield Strength");
				CFS.ModifyDSMValues (CFS.Sections [CFS.intSctNow], Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null)));
				section.Material.Fy [1] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.Material.Fy [2] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.Material.Fy [3] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.Material.Fy [4] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.Material.Fy [5] = Conversions.ToSingle (Operators.MultiplyObject (0.6, NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null)));
			} else if (flag == (sender == cboTensile)) {
				CFSInterface.StoreUndoSct ("Tensile Strength");
				section.Material.Fu = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboJOverride)) {
				CFSInterface.StoreUndoSct ("J Override");
				section.JOverride = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.GeomChange = false;
			} else if (flag == (sender == cboCwOverride)) {
				CFSInterface.StoreUndoSct ("Cw Override");
				section.CwOverride = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				section.GeomChange = false;
			} else if (flag == (sender == cboConnSpacing)) {
				CFSInterface.StoreUndoSct ("Connector Spacing");
				section.ConnSpacing = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboHoleLength)) {
				CFSInterface.StoreUndoSct ("Hole Length");
				section.HoleLength = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "tag", new object[0], null, null, null), null, "value", new object[0], null, null, null));
			} else if (flag == (sender == cboHoleSpacing)) {
				CFSInterface.StoreUndoSct ("Hole Spacing");
				section.HoleSpacing = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "tag", new object[0], null, null, null), null, "value", new object[0], null, null, null));
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			if ((sender == cboJOverride) | (sender == cboCwOverride)) {
				section.SctProp = false;
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			}
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			CFSInterface.SetMenuEdit ();
			section = null;
		} else {
			e.Cancel = true;
		}
		blnValidating = false;
	}

	private void cboPart_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		if (sender == cboPartName) {
			AddPart (cboPartName);
		} else {
			CFSInterface.SetSelection ((Control)sender);
		}
	}

	private void cboPart_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is System.Windows.Forms.ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		checked {
			if (e.KeyChar == '\r') {
				cboPart_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
				cboPart_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
				e.Handled = true;
			} else if (e.KeyChar == '\u001b') {
				if (sender == cboPartName) {
					NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
					cboPartName.SelectedIndex = unchecked((int)CFS.Sections [CFS.intSctNow].iPart) - 1;
					return;
				}
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				CFS.blnValidate = false;
				NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
				CFS.blnValidate = true;
				CFSInterface.SetSelection ((Control)sender);
				e.Handled = true;
			}
		}
	}

	private void cboPart_DropDown (object sender, EventArgs e)
	{
		if (sender == cboPartName) {
			RenamePart ();
		} else {
			CFSInterface.BuildList ((System.Windows.Forms.ComboBox)sender);
		}
	}

	private void cboPart_SelectedIndexChanged (object sender, EventArgs e)
	{
		_ = string.Empty;
		if (!CFS.blnValidate) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		checked {
			if (sender == cboPartName) {
				RenamePart (blnSetListIndex: false);
				NewLateBinding.LateSetComplex (cboPartName.Tag, null, "Text", new object[1] { cboPartName.Text }, null, null, OptimisticSet: false, RValueBase: true);
				if (cboPartName.SelectedIndex > -1) {
					short num = (short)(cboPartName.SelectedIndex + 1);
					if (num > Information.UBound (section.Part)) {
						ref Part[] part = ref section.Part;
						part = (Part[])Utils.CopyArray (part, new Part[num + 1]);
						section.Part [num] = new Part ();
					}
					CFSInterface.SelectElements (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow], (byte)num, 0, 0);
				}
				if (Strings.StrComp (section.Part [section.iPart].Name, Strings.Trim (cboPartName.Text)) != 0) {
					section.Part [section.iPart].Name = Strings.Trim (cboPartName.Text);
				}
				CFS.blnRefreshGrdElements = true;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
			} else if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			}
			section = null;
		}
	}

	private void cboPart_Validating (object sender, CancelEventArgs e)
	{
		string strMsg = string.Empty;
		if (sender == cboPartName) {
			RenamePart ();
			return;
		}
		blnValidating = true;
		Section section = CFS.Sections [CFS.intSctNow];
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		} else if (CFSInterface.Validate ((Control)sender)) {
			if ((uint)section.iPart > (uint)section.nPart) {
				section.nPart = section.iPart;
			}
			float defRad = section.Part [section.iPart].DefRad;
			bool flag = true;
			checked {
				if (flag == (sender == cboThickness)) {
					CFSInterface.StoreUndoSct ("Thickness");
					section.Part [section.iPart].Thickness = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
					short num = (short)Information.UBound (CFS.Thicknesses);
					short num2;
					for (num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
						if (section.Part [section.iPart].Thickness == CFS.Thicknesses [num2].Thickness) {
							section.Part [section.iPart].ThicknessIndex = num2;
							section.Part [section.iPart].DefRad = CFS.Thicknesses [num2].DefRad;
							CFS.iThickness = num2;
							break;
						}
					}
					if (num2 > Information.UBound (CFS.Thicknesses)) {
						section.Part [section.iPart].ThicknessIndex = -1;
						if (section.Part [section.iPart].DefRad < section.Part [section.iPart].Thickness) {
							section.Part [section.iPart].DefRad = section.Part [section.iPart].Thickness;
						}
					}
				} else if (flag == (sender == cboRadius)) {
					CFSInterface.StoreUndoSct ("Default Radius");
					section.Part [section.iPart].DefRad = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				}
				SetRadii (section.Part [section.iPart], defRad);
				section.GeomChange = true;
				section.GeomChangeDSM = true;
				section.Saved = false;
				section.RevDate = DateAndTime.Now;
				section.RevBy = CFS.User.Name;
				section.SctProp = false;
				section.iPt = 0;
				bool blnChg = default(bool);
				section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
				if (Strings.Len (strMsg) != 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
				CFS.blnRefreshGrdElements = true;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
			}
		} else {
			e.Cancel = true;
		}
		section = null;
		blnValidating = false;
	}

	private void cboThicknessName_SelectedIndexChanged (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!CFS.blnValidate) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		if (cboThicknessName.SelectedIndex > -1) {
			CFSInterface.StoreUndoSct ("Thickness");
			if ((uint)section.iPart > (uint)section.nPart) {
				section.nPart = section.iPart;
			}
			float defRad = section.Part [section.iPart].DefRad;
			checked {
				section.Part [section.iPart].ThicknessIndex = (short)(cboThicknessName.SelectedIndex + 1);
				section.Part [section.iPart].Thickness = CFS.Thicknesses [section.Part [section.iPart].ThicknessIndex].Thickness;
				section.Part [section.iPart].DefRad = CFS.Thicknesses [section.Part [section.iPart].ThicknessIndex].DefRad;
				CFS.iThickness = section.Part [section.iPart].ThicknessIndex;
				SetRadii (section.Part [section.iPart], defRad);
				CFS.blnValidate = false;
				section.GeomChange = true;
				section.GeomChangeDSM = true;
				section.Saved = false;
				section.RevDate = DateAndTime.Now;
				section.RevBy = CFS.User.Name;
				section.SctProp = false;
				section.iPt = 0;
				bool blnChg = default(bool);
				section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
				if (Strings.Len (strMsg) != 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
				CFS.blnRefreshGrdElements = true;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
				CFS.blnValidate = true;
			}
		}
		section = null;
	}

	private void cboReferenceXY_GotFocus (object sender, EventArgs e)
	{
		blnStoreUndo = true;
	}

	private void cboReferenceXY_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			Section section = CFS.Sections [CFS.intSctNow];
			if (blnStoreUndo) {
				CFSInterface.StoreUndoSct ("Placement");
				blnStoreUndo = false;
			}
			if ((uint)section.iPart > (uint)section.nPart) {
				section.nPart = section.iPart;
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			checked {
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
				bool flag = true;
				if (flag == (sender == cboReferenceX)) {
					section.Part [section.iPart].iXPosition = (byte)cboReferenceX.SelectedIndex;
				} else if (flag == (sender == cboReferenceY)) {
					section.Part [section.iPart].iYPosition = (byte)cboReferenceY.SelectedIndex;
				}
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
				section = null;
			}
		}
	}

	private void cboXY_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboXY_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is System.Windows.Forms.ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboXY_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboXY_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void cboXY_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((System.Windows.Forms.ComboBox)sender);
	}

	private void cboXY_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboXY_Validating (object sender, CancelEventArgs e)
	{
		string strMsg = string.Empty;
		blnValidating = true;
		Section section = CFS.Sections [CFS.intSctNow];
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		} else if (CFSInterface.Validate ((Control)sender)) {
			CFSInterface.StoreUndoSct ("Placement");
			if ((uint)section.iPart > (uint)section.nPart) {
				section.nPart = section.iPart;
			}
			bool flag = true;
			float num = default(float);
			if (flag == (sender == cboX)) {
				switch (section.Part [section.iPart].iXPosition) {
				case 0:
					num = section.Part [section.iPart].Xleft;
					break;
				case 1:
					num = 0f;
					break;
				case 2:
					num = 0f - section.Part [section.iPart].Xright;
					break;
				}
				section.Part [section.iPart].XPosition = Conversions.ToSingle (Operators.AddObject (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null), num));
			} else if (flag == (sender == cboY)) {
				switch (section.Part [section.iPart].iYPosition) {
				case 0:
					num = 0f - section.Part [section.iPart].Ytop;
					break;
				case 1:
					num = 0f;
					break;
				case 2:
					num = section.Part [section.iPart].Ybottom;
					break;
				}
				section.Part [section.iPart].YPosition = Conversions.ToSingle (Operators.AddObject (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null), num));
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			section.GeomChange = true;
			section.GeomChangeDSM = true;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			bool blnChg = default(bool);
			section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			CFSInterface.SetMenuEdit ();
		} else {
			e.Cancel = true;
		}
		section = null;
		blnValidating = false;
	}

	private void cboPartList_GotFocus (object sender, EventArgs e)
	{
		AddPart (cboPartList);
	}

	private void cboPartList_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		checked {
			if (cboPartList.SelectedIndex > -1) {
				short num = (short)(cboPartList.SelectedIndex + 1);
				if (num > Information.UBound (section.Part)) {
					ref Part[] part = ref section.Part;
					part = (Part[])Utils.CopyArray (part, new Part[num + 1]);
					section.Part [num] = new Part ();
				}
				CFSInterface.SelectElements (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow], (byte)num, 0, 0);
			}
			if (Strings.StrComp (section.Part [section.iPart].Name, Strings.Trim (cboPartList.Text)) != 0) {
				section.Part [section.iPart].Name = Strings.Trim (cboPartList.Text);
			}
			section = null;
			CFS.blnRefreshGrdElements = true;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		}
	}

	private void chkCenterline_CheckedChanged (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!CFS.blnValidate) {
			return;
		}
		CFSInterface.StoreUndoSct ("Centerline");
		Section section = CFS.Sections [CFS.intSctNow];
		if ((uint)section.iPart > (uint)section.nPart) {
			section.nPart = section.iPart;
		}
		section = null;
		Part part = CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart];
		checked {
			if (chkCenterline.Checked) {
				part.Centerline = true;
				short nElem = part.nElem;
				for (short num = 1; num <= nElem; num = (short)unchecked(num + 1)) {
					unchecked {
						short num2 = (short)((num >= part.nElem) ? 1 : checked((short)(num + 1)));
						part.Element [num].Len = (float)((double)part.Element [num].Len - (double)(part.Thickness / 2f) * (Math.Tan (Math.Abs (part.Element [num].Arc) / 2f) + Math.Tan (Math.Abs (part.Element [num2].Arc) / 2f)));
						part.Element [num].Dist = (float)((double)part.Element [num].Dist - (double)(part.Thickness / 2f) * Math.Tan (Math.Abs (part.Element [num].Arc) / 2f));
					}
				}
			} else {
				part.Centerline = false;
				short nElem2 = part.nElem;
				for (short num = 1; num <= nElem2; num = (short)unchecked(num + 1)) {
					unchecked {
						short num2 = (short)((num >= part.nElem) ? 1 : checked((short)(num + 1)));
						part.Element [num].Len = (float)((double)part.Element [num].Len + (double)(part.Thickness / 2f) * (Math.Tan (Math.Abs (part.Element [num].Arc) / 2f) + Math.Tan (Math.Abs (part.Element [num2].Arc) / 2f)));
						part.Element [num].Dist = (float)((double)part.Element [num].Dist + (double)(part.Thickness / 2f) * Math.Tan (Math.Abs (part.Element [num].Arc) / 2f));
					}
				}
			}
			part = null;
			Section section2 = CFS.Sections [CFS.intSctNow];
			section2.Saved = false;
			section2.RevDate = DateAndTime.Now;
			section2.RevBy = CFS.User.Name;
			bool blnChg = default(bool);
			section2.Part [section2.iPart].Geometry (ref blnChg, ref strMsg);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			section2 = null;
			CFS.blnRefreshGrdElements = true;
		}
	}

	private void chkClosed_CheckedChanged (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!CFS.blnValidate) {
			return;
		}
		CFSInterface.StoreUndoSct ("Closed Part");
		Section section = CFS.Sections [CFS.intSctNow];
		if ((uint)section.iPart > (uint)section.nPart) {
			section.nPart = section.iPart;
		}
		checked {
			if (chkClosed.Checked) {
				section.Part [section.iPart].Closed = true;
				if (!CFSInterface.AddElement (section.Part [section.iPart])) {
					section.Part [section.iPart].Closed = false;
					CFS.blnValidate = false;
					chkClosed.Checked = false;
					CFS.blnValidate = true;
					return;
				}
			} else {
				section.Part [section.iPart].Closed = false;
				if (section.Part [section.iPart].nElem > 0) {
					section.Part [section.iPart].nElem = (byte)(unchecked((int)section.Part [section.iPart].nElem) - 1);
				}
				CFS.blnRefreshGrdElements = true;
			}
			section.GeomChange = true;
			section.GeomChangeDSM = true;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			bool blnChg = default(bool);
			section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow], blnPartList: false);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void chkColdWork_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoSct ("Cold Work of Forming");
			Section section = CFS.Sections [CFS.intSctNow];
			CFS.Sections [CFS.intSctNow].ColdWork = chkColdWork.Checked;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void chkReserve_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoSct ("Inelastic Reserve");
			Section section = CFS.Sections [CFS.intSctNow];
			CFS.Sections [CFS.intSctNow].Reserve = chkReserve.Checked;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void chkUseDSM_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoSct ("Use Direct Strength");
			Section section = CFS.Sections [CFS.intSctNow];
			section.DSM.UseDSM = chkUseDSM.Checked;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void chkPrequalified_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoSct ("Prequalified Section");
			Section section = CFS.Sections [CFS.intSctNow];
			CFS.Sections [CFS.intSctNow].DSM.PreQualified = chkPrequalified.Checked;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
			txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void cmdCustom_Click (object sender, EventArgs e)
	{
		checked {
			if (My.MyProject.Forms.frmMaterial.ShowDialog (this) == DialogResult.OK) {
				MaterialType materialType = (MaterialType)My.MyProject.Forms.frmMaterial.Tag;
				CFSInterface.StoreUndoSct ("Material");
				CFS.ModifyDSMValues (CFS.Sections [CFS.intSctNow], materialType.Fy [2]);
				Section section = CFS.Sections [CFS.intSctNow];
				int num = 1;
				do {
					if (materialType.Eo [num] != section.Material.Eo [num]) {
						section.GeomChangeDSM = true;
					}
					num++;
				} while (num <= 5);
				section.Material = materialType.Clone ();
				section.MaterialIndex = CFS.MatchMaterial (section.Material);
				section.Saved = false;
				section.RevDate = DateAndTime.Now;
				section.RevBy = CFS.User.Name;
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
				section = null;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			}
			My.MyProject.Forms.frmMaterial.Dispose ();
		}
	}

	private void grdElements_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		string strMsg = string.Empty;
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditElm.Tag;
		switch (e.Col) {
		case 1:
		case 6:
		case 7:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.AngleUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [3] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -Math.PI }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { Math.PI * 2.0 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 3:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 10 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 4:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdElements.ComboBox (e.Col).FindItem (grdElements.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { checked(grdElements.ComboBox (e.Col).Items.Count - 1) }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 5:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.NoUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [0] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 4 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEditElm.Text = grdElements.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEditElm, blnShowUnit: false)) {
			CFSInterface.StoreUndoSct ("Element");
			if (e.Row == CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].nElem) {
				if ((CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].Closed & ((e.Col == 1) | (e.Col == 2))) && !CFSInterface.AddElement (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart])) {
					return;
				}
			} else if (e.Row > CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].nElem && !CFSInterface.AddElement (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart])) {
				return;
			}
			ref Element reference = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].Element [e.Row];
			switch (e.Col) {
			case 1:
				reference.Len = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				reference.Dist = reference.Len / 2f;
				CFS.Sections [CFS.intSctNow].GeomChange = true;
				CFS.Sections [CFS.intSctNow].GeomChangeDSM = true;
				break;
			case 2:
				reference.Ang = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				CFS.Sections [CFS.intSctNow].GeomChange = true;
				CFS.Sections [CFS.intSctNow].GeomChangeDSM = true;
				break;
			case 3:
				reference.Rad = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				CFS.Sections [CFS.intSctNow].GeomChange = true;
				CFS.Sections [CFS.intSctNow].GeomChangeDSM = true;
				break;
			case 4:
				reference.Web = Conversions.ToByte (Operators.AddObject (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null), 1));
				break;
			case 5:
				reference.K = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				if (reference.K != 0f) {
					reference.Hole = 0f;
				}
				break;
			case 6:
				reference.Hole = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				if (reference.Hole != 0f) {
					reference.K = 0f;
				}
				CFS.Sections [CFS.intSctNow].GeomChangeDSM = true;
				break;
			case 7:
				reference.Dist = Conversions.ToSingle (NewLateBinding.LateGet (txtEditElm.Tag, null, "Value", new object[0], null, null, null));
				CFS.Sections [CFS.intSctNow].GeomChangeDSM = true;
				break;
			}
			Section section = CFS.Sections [CFS.intSctNow];
			if ((uint)section.iPart > (uint)section.nPart) {
				section.nPart = section.iPart;
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			bool blnChg = default(bool);
			section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (blnChg) {
				CFS.blnRefreshGrdElements = true;
			}
			checked {
				if (CFS.blnRefreshGrdElements) {
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				} else if ((e.Col == 1) | (e.Col == 5) | (e.Col == 6)) {
					CFSInterface.RefreshElem (CFS.Sections [CFS.intSctNow], (short)e.Row);
				} else {
					grdElements.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditElm.Tag, null, "Text", new object[0], null, null, null));
				}
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
				section = null;
			}
		} else {
			ref Element reference2 = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].Element [e.Row];
			string text = string.Empty;
			switch (e.Col) {
			case 1:
				text = Units.DisplayLen1 (reference2.Len, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 2:
				text = Units.DisplayAngle (reference2.Ang, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 3:
				text = Units.DisplayLen1 (reference2.Rad, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 4:
				text = CFSInterface.DisplayWeb ((WebTypes)reference2.Web);
				break;
			case 5:
				text = Units.DisplayNone (reference2.K, "", 0, 0);
				break;
			case 6:
				text = Units.DisplayLen1 (reference2.Hole, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 7:
				text = Units.DisplayLen1 (reference2.Dist, 0, blnShowUnit: false, "", 0, 0);
				break;
			}
			grdElements.Cell (e.Row, e.Col).Text = text;
		}
		blnCodeChange = false;
	}

	private void grdElements_KeyDown (object sender, KeyEventArgs e)
	{
		checked {
			if (!grdElements.EditorVisible) {
				byte b = 0;
				if (e.Shift) {
					b = (byte)unchecked((uint)(b + 1));
				}
				if (e.Control) {
					b = (byte)unchecked((uint)(b + 2));
				}
				if (e.Alt) {
					b = (byte)unchecked((uint)(b + 4));
				}
				_ = CFS.Sections [CFS.intSctNow];
				if (unchecked(e.KeyCode == Keys.Insert && b == 1)) {
					CFSInterface.InsertElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Delete && (b == 0 || b == 1))) {
					CFSInterface.DeleteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.X && b == 2)) {
					CFSInterface.CopyElements (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart], (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					CFSInterface.DeleteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.C && b == 2)) {
					CFSInterface.CopyElements (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart], (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.V && b == 2)) {
					CFSInterface.PasteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
					e.Handled = true;
				}
				_ = null;
			}
		}
	}

	private void grdElements_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}

	private void grdElements_SelChange (object sender, Grid.SelChangeEventArgs e)
	{
		checked {
			if (CFS.blnValidate) {
				ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
				elemGrid.TopRow = (byte)grdElements.TopRow;
				elemGrid.LeftCol = (byte)grdElements.LeftCol;
				elemGrid.ColStart = (byte)grdElements.Selection.FirstCol;
				elemGrid.ColEnd = (byte)grdElements.Selection.LastCol;
				if (unchecked((uint)elemGrid.ColStart > (uint)elemGrid.ColEnd)) {
					CFS.Swap (ref elemGrid.ColStart, ref elemGrid.ColEnd);
				}
				elemGrid.Corner = 0;
				if (grdElements.ActiveCell.Col > grdElements.Selection.FirstCol) {
					elemGrid.Corner = (byte)(elemGrid.Corner | 1);
				}
				if (grdElements.ActiveCell.Row > grdElements.Selection.FirstRow) {
					elemGrid.Corner = (byte)(elemGrid.Corner | 2);
				}
				if ((grdElements.Selection.FirstRow != elemGrid.RowStart) | (grdElements.Selection.LastRow != elemGrid.RowEnd)) {
					CFSInterface.SelectElements (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)grdElements.Selection.FirstRow, (byte)grdElements.Selection.LastRow);
				}
			}
		}
	}

	private void grdDSM_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		blnCodeChange = true;
		txtEditDSM.Text = grdDSM.Cell (e.Row, e.Col).Text;
		checked {
			if (CFSInterface.Validate (txtEditDSM, blnShowUnit: false)) {
				CFSInterface.StoreUndoSct ("Direct Strength Value");
				ref Section.DSMType dSM = ref CFS.Sections [CFS.intSctNow].DSM;
				switch (2 * (e.Row - 1) + (e.Col - 1)) {
				case 0:
					dSM.Pcrl = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 1:
					dSM.Pcrd = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 4:
					dSM.Mcrlxp = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 5:
					dSM.Mcrdxp = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 6:
					dSM.Mcrlxn = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 7:
					dSM.Mcrdxn = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 8:
					dSM.Mcrlyp = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 9:
					dSM.Mcrdyp = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 10:
					dSM.Mcrlyn = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 11:
					dSM.Mcrdyn = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 14:
					dSM.Vcry = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 16:
					dSM.Vcrx = Conversions.ToSingle (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Value", new object[0], null, null, null));
					break;
				}
				grdDSM.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditDSM.Tag, null, "Text", new object[0], null, null, null));
				Section obj = CFS.Sections [CFS.intSctNow];
				obj.GeomChangeDSM = false;
				obj.Saved = false;
				obj.RevDate = DateAndTime.Now;
				obj.RevBy = CFS.User.Name;
				obj.SctProp = false;
				CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
				CFSInterface.SetMenuEdit ();
				_ = null;
			} else {
				ref Section.DSMType dSM2 = ref CFS.Sections [CFS.intSctNow].DSM;
				float sngValue = default(float);
				switch (2 * (e.Row - 1) + (e.Col - 1)) {
				case 0:
					sngValue = dSM2.Pcrl;
					break;
				case 1:
					sngValue = dSM2.Pcrd;
					break;
				case 4:
					sngValue = dSM2.Mcrlxp;
					break;
				case 5:
					sngValue = dSM2.Mcrdxp;
					break;
				case 6:
					sngValue = dSM2.Mcrlxn;
					break;
				case 7:
					sngValue = dSM2.Mcrdxn;
					break;
				case 8:
					sngValue = dSM2.Mcrlyp;
					break;
				case 9:
					sngValue = dSM2.Mcrdyp;
					break;
				case 10:
					sngValue = dSM2.Mcrlyn;
					break;
				case 11:
					sngValue = dSM2.Mcrdyn;
					break;
				case 14:
					sngValue = dSM2.Vcry;
					break;
				case 16:
					sngValue = dSM2.Vcrx;
					break;
				}
				grdDSM.Cell (e.Row, e.Col).Text = Units.DisplayNone (sngValue, "", 0, 0);
			}
			blnCodeChange = false;
		}
	}

	internal void cmdDSM_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		BuckleParameters buckleParametersNow = CFSInterface.BuckleParametersNow;
		FiniteStrip.DSMData[] array = new FiniteStrip.DSMData[10];
		Cursor.Current = Cursors.WaitCursor;
		CFS.Sections [CFS.intSctNow].GeomChangeDSM = false;
		CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg);
		if (sender != null) {
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		}
		Cursor.Current = Cursors.Default;
		if (Strings.Len (strMsg) != 0) {
			Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
		}
		if (!CFS.Sections [CFS.intSctNow].SctProp) {
			return;
		}
		CFSInterface.BuckleParametersNow.AltMethod = false;
		CFSInterface.BuckleParametersNow.Constrained = false;
		CFSInterface.BuckleParametersNow.Repeat = false;
		CFSInterface.BuckleParametersNow.Lmin = (float)(0.15 * (double)CFS.Sections [CFS.intSctNow].Prop.Rc);
		CFSInterface.BuckleParametersNow.Lmax = 50f * CFS.Sections [CFS.intSctNow].Prop.Rc;
		CFSInterface.BuckleParametersNow.Resolution = 1;
		CFSInterface.BuckleParametersNow.intSection = 0;
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			CFS.LicenseRequired ("This calculation requires a full CFS license.");
			CFSInterface.BuckleParametersNow = buckleParametersNow;
			return;
		}
		CFSInterface.StoreUndoSct ("DSM Values");
		Section section = CFS.Sections [CFS.intSctNow];
		section.DSM.Pcrl = 0f;
		section.DSM.Pcrd = 0f;
		section.DSM.Mcrlxp = 0f;
		section.DSM.Mcrdxp = 0f;
		section.DSM.Mcrlxn = 0f;
		section.DSM.Mcrdxn = 0f;
		section.DSM.Mcrlyp = 0f;
		section.DSM.Mcrdyp = 0f;
		section.DSM.Mcrlyn = 0f;
		section.DSM.Mcrdyn = 0f;
		section.GeomChangeDSM = false;
		section.Saved = false;
		section.RevDate = DateAndTime.Now;
		section.RevBy = CFS.User.Name;
		CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		float num = section.Material.Fy [2];
		CFSInterface.BuckleParametersNow.Fc = 1f;
		CFSInterface.BuckleParametersNow.Fbx = 0f;
		CFSInterface.BuckleParametersNow.Fby = 0f;
		if (My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS) != DialogResult.Cancel) {
			My.MyProject.Forms.frmBuckleProgress.Dispose ();
			GetDSMData (num, ref array [0], ref array [1]);
			section.DSM.Pcrl = array [0].Stress / num;
			section.DSM.Pcrd = array [1].Stress / num;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			CFSInterface.BuckleParametersNow.Fc = 0f;
			CFSInterface.BuckleParametersNow.Fbx = 1f;
			CFSInterface.BuckleParametersNow.Fby = 0f;
			if (My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS) != DialogResult.Cancel) {
				My.MyProject.Forms.frmBuckleProgress.Dispose ();
				GetDSMData (num, ref array [2], ref array [3]);
				section.DSM.Mcrlxp = array [2].Stress / num;
				section.DSM.Mcrdxp = array [3].Stress / num;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				if (section.HasSymmetry (Symmetry.PrincipalX) & section.HasSymmetryNet (Symmetry.PrincipalX)) {
					section.DSM.Mcrlxn = section.DSM.Mcrlxp;
					section.DSM.Mcrdxn = section.DSM.Mcrdxp;
					array [4] = array [2];
					array [5] = array [3];
				} else {
					CFSInterface.BuckleParametersNow.Fc = 0f;
					CFSInterface.BuckleParametersNow.Fbx = -1f;
					CFSInterface.BuckleParametersNow.Fby = 0f;
					if (My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS) == DialogResult.Cancel) {
						goto IL_06c2;
					}
					My.MyProject.Forms.frmBuckleProgress.Dispose ();
					GetDSMData (num, ref array [4], ref array [5]);
					section.DSM.Mcrlxn = array [4].Stress / num;
					section.DSM.Mcrdxn = array [5].Stress / num;
				}
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				CFSInterface.BuckleParametersNow.Fc = 0f;
				CFSInterface.BuckleParametersNow.Fbx = 0f;
				CFSInterface.BuckleParametersNow.Fby = 1f;
				if (My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS) != DialogResult.Cancel) {
					My.MyProject.Forms.frmBuckleProgress.Dispose ();
					GetDSMData (num, ref array [6], ref array [7]);
					section.DSM.Mcrlyp = array [6].Stress / num;
					section.DSM.Mcrdyp = array [7].Stress / num;
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					if (section.HasSymmetry (Symmetry.PrincipalY) & section.HasSymmetryNet (Symmetry.PrincipalY)) {
						section.DSM.Mcrlyn = section.DSM.Mcrlyp;
						section.DSM.Mcrdyn = section.DSM.Mcrdyp;
						array [8] = array [6];
						array [9] = array [7];
					} else {
						CFSInterface.BuckleParametersNow.Fc = 0f;
						CFSInterface.BuckleParametersNow.Fbx = 0f;
						CFSInterface.BuckleParametersNow.Fby = -1f;
						if (My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS) == DialogResult.Cancel) {
							goto IL_06c2;
						}
						My.MyProject.Forms.frmBuckleProgress.Dispose ();
						GetDSMData (num, ref array [8], ref array [9]);
						section.DSM.Mcrlyn = array [8].Stress / num;
						section.DSM.Mcrdyn = array [9].Stress / num;
					}
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					section = null;
					if (sender != null) {
						Report.rptDSMData (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow], array);
						My.MyProject.Forms.frmReportDialog.Tag = "1";
						My.MyProject.Forms.frmReportDialog.ShowDialog (this);
						My.MyProject.Forms.frmReportDialog.Dispose ();
					}
				}
			}
		}
		goto IL_06c2;
		IL_06c2:
		My.MyProject.Forms.frmBuckleProgress.Dispose ();
		CFSInterface.BuckleParametersNow = buckleParametersNow;
		CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
		CFSInterface.SetMenuEdit ();
	}

	private void GetDSMData (float Fy, ref FiniteStrip.DSMData DSMLB, ref FiniteStrip.DSMData DSMDB)
	{
		DSMLB.Stress = 1000f * Fy;
		DSMDB.Stress = 1000f * Fy;
		int num = Information.UBound (FiniteStrip.Buckle);
		checked {
			FiniteStrip.DSMData dSMData = default(FiniteStrip.DSMData);
			for (int i = 1; i <= num; i++) {
				float lF = FiniteStrip.Buckle [i].LF;
				if ((lF == 0f) & (FiniteStrip.Buckle [i].HoleMode == FiniteStrip.HoleMode.Gross)) {
					DSMLB = dSMData;
					DSMDB = dSMData;
					break;
				}
				if ((FiniteStrip.Buckle [i].HoleMode == FiniteStrip.HoleMode.Gross) & FiniteStrip.IsLocalBuckling (FiniteStrip.Buckle [i].WorkRatio)) {
					if (lF < DSMLB.Stress) {
						DSMLB.Stress = lF;
						DSMLB.Length = FiniteStrip.Buckle [i].Length;
						DSMLB.WorkRatio = FiniteStrip.Buckle [i].WorkRatio;
					}
				} else if (!((FiniteStrip.Buckle [i].HoleMode == FiniteStrip.HoleMode.Gross) & FiniteStrip.IsDistortionalBuckling (FiniteStrip.Buckle [i].WorkRatio))) {
					if (FiniteStrip.Buckle [i].HoleMode == FiniteStrip.HoleMode.Local) {
						if (lF < DSMLB.Stress) {
							DSMLB.Stress = lF;
							DSMLB.Length = FiniteStrip.Buckle [i].Length;
							DSMLB.WorkRatio = FiniteStrip.Buckle [i].WorkRatio;
						}
					} else if (FiniteStrip.Buckle [i].HoleMode == FiniteStrip.HoleMode.Distortional && lF < DSMDB.Stress) {
						DSMDB.Stress = lF;
						DSMDB.Length = FiniteStrip.Buckle [i].Length;
						DSMDB.WorkRatio = FiniteStrip.Buckle [i].WorkRatio;
					}
				}
				if (!((i > 1) & (i < Information.UBound (FiniteStrip.Buckle))) || !((FiniteStrip.Buckle [i - 1].HoleMode == FiniteStrip.HoleMode.Gross) & (FiniteStrip.Buckle [i + 1].HoleMode == FiniteStrip.HoleMode.Gross)) || !((FiniteStrip.Buckle [i].LF < FiniteStrip.Buckle [i - 1].LF) & (FiniteStrip.Buckle [i].LF < FiniteStrip.Buckle [i + 1].LF))) {
					continue;
				}
				PointF pointF = FiniteStrip.Minimum ((float)Math.Log (FiniteStrip.Buckle [i - 1].Length), FiniteStrip.Buckle [i - 1].LF, (float)Math.Log (FiniteStrip.Buckle [i].Length), FiniteStrip.Buckle [i].LF, (float)Math.Log (FiniteStrip.Buckle [i + 1].Length), FiniteStrip.Buckle [i + 1].LF);
				if (FiniteStrip.IsLocalBuckling (FiniteStrip.Buckle [i].WorkRatio)) {
					if (pointF.Y < DSMLB.Stress) {
						DSMLB.Stress = pointF.Y;
						DSMLB.Length = (float)Math.Exp (pointF.X);
						DSMLB.WorkRatio = FiniteStrip.Buckle [i].WorkRatio;
					}
				} else if (FiniteStrip.IsDistortionalBuckling (FiniteStrip.Buckle [i].WorkRatio) && pointF.Y < DSMDB.Stress) {
					DSMDB.Stress = pointF.Y;
					DSMDB.Length = (float)Math.Exp (pointF.X);
					DSMDB.WorkRatio = FiniteStrip.Buckle [i].WorkRatio;
				}
			}
			short num2 = 0;
			int num3 = Information.UBound (FiniteStrip.Buckle) - 1;
			bool flag = default(bool);
			float num7 = default(float);
			float num8 = default(float);
			short num9 = default(short);
			for (int j = 2; j <= num3 && FiniteStrip.Buckle [j + 1].HoleMode == FiniteStrip.HoleMode.Gross; j++) {
				if (FiniteStrip.IsDistortionalBuckling (FiniteStrip.Buckle [j].WorkRatio)) {
					if (num2 == 0) {
						num2 = (short)j;
					}
					if ((FiniteStrip.Buckle [j].LF < FiniteStrip.Buckle [j - 1].LF) & (FiniteStrip.Buckle [j].LF < FiniteStrip.Buckle [j + 1].LF)) {
						num2 = -1;
					}
				} else if (num2 > 0) {
					int num4 = num2 + 1;
					int num5 = j - 1;
					for (int k = num4; k <= num5; k++) {
						float num6 = (float)((double)(FiniteStrip.Buckle [k].LF - FiniteStrip.Buckle [k - 1].LF) / Math.Log10 (FiniteStrip.Buckle [k].Length / FiniteStrip.Buckle [k - 1].Length));
						if (num6 < 0f) {
							break;
						}
						if (!flag) {
							unchecked {
								if (k == checked(num2 + 1) || num6 > num7) {
									num7 = num6;
								}
							}
							if (((double)num6 < 0.9 * (double)num7) & (num6 / FiniteStrip.Buckle [j].LF < 1f)) {
								flag = true;
								num8 = num6;
								num9 = (short)k;
							}
							continue;
						}
						if (num6 < num8) {
							num8 = num6;
							num9 = (short)k;
						}
						if ((double)num6 > 1.1 * (double)num8) {
							if (FiniteStrip.Buckle [num9].LF < DSMDB.Stress) {
								DSMDB.Stress = FiniteStrip.Buckle [num9].LF;
								DSMDB.Length = FiniteStrip.Buckle [num9].Length;
								DSMDB.WorkRatio = FiniteStrip.Buckle [num9].WorkRatio;
							}
							break;
						}
					}
					num2 = 0;
				} else if (num2 < 0) {
					num2 = 0;
				}
			}
		}
	}
}
