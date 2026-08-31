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
public class frmOptions : Form
{
	private IContainer components;

	private bool blnTabOptions;

	private byte[] DefaultUnitIndexTmp;

	private byte iUnitSysTmp;

	private Thickness[] ThicknessTmp;

	private LoadCombination[] UserCombTmp;

	private short intUserCombsTmp;

	private short intCancel;

	private short iMaterialTmp;

	private MaterialType MaterialTmp;

	private bool[] blnTabChange;

	private CFS.UserInfo UserTmp;

	private bool blnColdWorkTmp;

	private bool blnReserveTmp;

	private short intComb;

	private bool blnCodeChange;

	internal virtual TabControl tabOptions {
		[CompilerGenerated]
		get {
			return _tabOptions;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tabOptions_SelectedIndexChanged;
			TabControl tabControl = _tabOptions;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged -= value2;
			}
			_tabOptions = value;
			tabControl = _tabOptions;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tabUnits")]
	internal virtual TabPage tabUnits {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabMaterial")]
	internal virtual TabPage tabMaterial {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabThicknesses")]
	internal virtual TabPage tabThicknesses {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabHeading")]
	internal virtual TabPage tabHeading {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabCombinations")]
	internal virtual TabPage tabCombinations {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblUnitSystem")]
	internal virtual Label lblUnitSystem {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboUnitSystem {
		[CompilerGenerated]
		get {
			return _cboUnitSystem;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboUnitSystem;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboUnitSystem = value;
			comboBox = _cboUnitSystem;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboMomentUnit {
		[CompilerGenerated]
		get {
			return _cboMomentUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboMomentUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboMomentUnit = value;
			comboBox = _cboMomentUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMoment")]
	internal virtual Label lblMoment {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboStressUnit {
		[CompilerGenerated]
		get {
			return _cboStressUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboStressUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboStressUnit = value;
			comboBox = _cboStressUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblStress")]
	internal virtual Label lblStress {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboForceUnit {
		[CompilerGenerated]
		get {
			return _cboForceUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboForceUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboForceUnit = value;
			comboBox = _cboForceUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblForce")]
	internal virtual Label lblForce {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboAngleUnit {
		[CompilerGenerated]
		get {
			return _cboAngleUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboAngleUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboAngleUnit = value;
			comboBox = _cboAngleUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblAngle")]
	internal virtual Label lblAngle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboLengthUnit {
		[CompilerGenerated]
		get {
			return _cboLengthUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboLengthUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboLengthUnit = value;
			comboBox = _cboLengthUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblLength")]
	internal virtual Label lblLength {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboSectionUnit {
		[CompilerGenerated]
		get {
			return _cboSectionUnit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboUnits_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboSectionUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSectionUnit = value;
			comboBox = _cboSectionUnit;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblSection")]
	internal virtual Label lblSection {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboMaterial {
		[CompilerGenerated]
		get {
			return _cboMaterial;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboMaterial_SelectedIndexChanged;
			CancelEventHandler value3 = cboMaterial_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
				comboBox.Validating -= value3;
			}
			_cboMaterial = value;
			comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
				comboBox.Validating += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMaterial")]
	internal virtual Label lblMaterial {
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
			EventHandler value2 = cboMaterial_GotFocus;
			KeyPressEventHandler value3 = cboMaterial_KeyPress;
			EventHandler value4 = cboMaterial_TextChanged;
			EventHandler value5 = cboMaterial_DropDown;
			EventHandler value6 = cboMaterial_SelectedIndexChanged;
			CancelEventHandler value7 = cboMaterial_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboTensile;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboTensile = value;
			comboBox = _cboTensile;
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
			EventHandler value2 = cboMaterial_GotFocus;
			KeyPressEventHandler value3 = cboMaterial_KeyPress;
			EventHandler value4 = cboMaterial_TextChanged;
			EventHandler value5 = cboMaterial_DropDown;
			EventHandler value6 = cboMaterial_SelectedIndexChanged;
			CancelEventHandler value7 = cboMaterial_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboYield;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboYield = value;
			comboBox = _cboYield;
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
			EventHandler value2 = chkColdWork_Click;
			CheckBox checkBox = _chkColdWork;
			if (checkBox != null) {
				checkBox.Click -= value2;
			}
			_chkColdWork = value;
			checkBox = _chkColdWork;
			if (checkBox != null) {
				checkBox.Click += value2;
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

	internal virtual Button cmdReset {
		[CompilerGenerated]
		get {
			return _cmdReset;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdReset_Click;
			Button button = _cmdReset;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdReset = value;
			button = _cmdReset;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblAddress2")]
	internal virtual Label lblAddress2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtAddress1 {
		[CompilerGenerated]
		get {
			return _txtAddress1;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtAddress1;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtAddress1 = value;
			textBox = _txtAddress1;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblAddress1")]
	internal virtual Label lblAddress1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtCompany {
		[CompilerGenerated]
		get {
			return _txtCompany;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtCompany;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtCompany = value;
			textBox = _txtCompany;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCompany")]
	internal virtual Label lblCompany {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtUser {
		[CompilerGenerated]
		get {
			return _txtUser;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtUser;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtUser = value;
			textBox = _txtUser;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblUser")]
	internal virtual Label lblUser {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtFax {
		[CompilerGenerated]
		get {
			return _txtFax;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtFax;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtFax = value;
			textBox = _txtFax;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblFax")]
	internal virtual Label lblFax {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtPhone {
		[CompilerGenerated]
		get {
			return _txtPhone;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtPhone;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtPhone = value;
			textBox = _txtPhone;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblPhone")]
	internal virtual Label lblPhone {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtEmail {
		[CompilerGenerated]
		get {
			return _txtEmail;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtEmail;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtEmail = value;
			textBox = _txtEmail;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblEmail")]
	internal virtual Label lblEmail {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtAddress2 {
		[CompilerGenerated]
		get {
			return _txtAddress2;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtHeading_GotFocus;
			KeyPressEventHandler value3 = txtHeading_KeyPress;
			EventHandler value4 = txtHeading_TextChanged;
			CancelEventHandler value5 = txtHeading_Validating;
			TextBox textBox = _txtAddress2;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtAddress2 = value;
			textBox = _txtAddress2;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	internal virtual System.Windows.Forms.ComboBox cboSpec {
		[CompilerGenerated]
		get {
			return _cboSpec;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSpec_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboSpec;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSpec = value;
			comboBox = _cboSpec;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblSpec")]
	internal virtual Label lblSpec {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboComb {
		[CompilerGenerated]
		get {
			return _cboComb;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboComb_GotFocus;
			KeyPressEventHandler value3 = cboComb_KeyPress;
			EventHandler value4 = cboComb_TextChanged;
			EventHandler value5 = cboComb_DropDown;
			EventHandler value6 = cboComb_SelectedIndexChanged;
			CancelEventHandler value7 = cboComb_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboComb;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboComb = value;
			comboBox = _cboComb;
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

	[field: AccessedThroughProperty ("lblCombination")]
	internal virtual Label lblCombination {
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

	internal virtual Grid grdCombs {
		[CompilerGenerated]
		get {
			return _grdCombs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangingEventHandler obj = grdCombs_CellChanging;
			Grid.CellChangeEventHandler obj2 = grdCombs_CellChange;
			Grid.SelChangeEventHandler obj3 = grdCombs_SelChange;
			Grid grid = _grdCombs;
			if (grid != null) {
				grid.CellChanging -= obj;
				grid.CellChange -= obj2;
				grid.SelChange -= obj3;
			}
			_grdCombs = value;
			grid = _grdCombs;
			if (grid != null) {
				grid.CellChanging += obj;
				grid.CellChange += obj2;
				grid.SelChange += obj3;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditComb")]
	internal virtual TextBox txtEditComb {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtEditThickness")]
	internal virtual TextBox txtEditThickness {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Grid grdThickness {
		[CompilerGenerated]
		get {
			return _grdThickness;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangingEventHandler obj = grdThickness_CellChanging;
			Grid.CellChangeEventHandler obj2 = grdThickness_CellChange;
			Grid.KeyDownEventHandler obj3 = grdThickness_KeyDown;
			Grid.LeaveCellEventHandler obj4 = grdThickness_LeaveCell;
			Grid grid = _grdThickness;
			if (grid != null) {
				grid.CellChanging -= obj;
				grid.CellChange -= obj2;
				grid.KeyDown -= obj3;
				grid.LeaveCell -= obj4;
			}
			_grdThickness = value;
			grid = _grdThickness;
			if (grid != null) {
				grid.CellChanging += obj;
				grid.CellChange += obj2;
				grid.KeyDown += obj3;
				grid.LeaveCell += obj4;
			}
		}
	}

	internal virtual CheckBox chkReserve {
		[CompilerGenerated]
		get {
			return _chkReserve;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkReserve_Click;
			CheckBox checkBox = _chkReserve;
			if (checkBox != null) {
				checkBox.Click -= value2;
			}
			_chkReserve = value;
			checkBox = _chkReserve;
			if (checkBox != null) {
				checkBox.Click += value2;
			}
		}
	}

	public frmOptions ()
	{
		base.Load += frmOptions_Load;
		base.KeyDown += frmOptions_KeyDown;
		base.HelpButtonClicked += frmOptions_HelpButtonClicked;
		base.FormClosing += frmOptions_FormClosing;
		blnTabChange = new bool[5];
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
		this.tabOptions = new System.Windows.Forms.TabControl ();
		this.tabUnits = new System.Windows.Forms.TabPage ();
		this.cboMomentUnit = new System.Windows.Forms.ComboBox ();
		this.lblMoment = new System.Windows.Forms.Label ();
		this.cboStressUnit = new System.Windows.Forms.ComboBox ();
		this.lblStress = new System.Windows.Forms.Label ();
		this.cboForceUnit = new System.Windows.Forms.ComboBox ();
		this.lblForce = new System.Windows.Forms.Label ();
		this.cboAngleUnit = new System.Windows.Forms.ComboBox ();
		this.lblAngle = new System.Windows.Forms.Label ();
		this.cboLengthUnit = new System.Windows.Forms.ComboBox ();
		this.lblLength = new System.Windows.Forms.Label ();
		this.cboSectionUnit = new System.Windows.Forms.ComboBox ();
		this.lblSection = new System.Windows.Forms.Label ();
		this.cboUnitSystem = new System.Windows.Forms.ComboBox ();
		this.lblUnitSystem = new System.Windows.Forms.Label ();
		this.tabMaterial = new System.Windows.Forms.TabPage ();
		this.chkReserve = new System.Windows.Forms.CheckBox ();
		this.cboTensile = new System.Windows.Forms.ComboBox ();
		this.lblTensile = new System.Windows.Forms.Label ();
		this.cboYield = new System.Windows.Forms.ComboBox ();
		this.lblYield = new System.Windows.Forms.Label ();
		this.chkColdWork = new System.Windows.Forms.CheckBox ();
		this.cmdCustom = new System.Windows.Forms.Button ();
		this.cboMaterial = new System.Windows.Forms.ComboBox ();
		this.lblMaterial = new System.Windows.Forms.Label ();
		this.tabThicknesses = new System.Windows.Forms.TabPage ();
		this.txtEditThickness = new System.Windows.Forms.TextBox ();
		this.grdThickness = new FlexCell.Grid ();
		this.cmdReset = new System.Windows.Forms.Button ();
		this.tabHeading = new System.Windows.Forms.TabPage ();
		this.txtFax = new System.Windows.Forms.TextBox ();
		this.lblFax = new System.Windows.Forms.Label ();
		this.txtPhone = new System.Windows.Forms.TextBox ();
		this.lblPhone = new System.Windows.Forms.Label ();
		this.txtEmail = new System.Windows.Forms.TextBox ();
		this.lblEmail = new System.Windows.Forms.Label ();
		this.txtAddress2 = new System.Windows.Forms.TextBox ();
		this.lblAddress2 = new System.Windows.Forms.Label ();
		this.txtAddress1 = new System.Windows.Forms.TextBox ();
		this.lblAddress1 = new System.Windows.Forms.Label ();
		this.txtCompany = new System.Windows.Forms.TextBox ();
		this.lblCompany = new System.Windows.Forms.Label ();
		this.txtUser = new System.Windows.Forms.TextBox ();
		this.lblUser = new System.Windows.Forms.Label ();
		this.tabCombinations = new System.Windows.Forms.TabPage ();
		this.txtEditComb = new System.Windows.Forms.TextBox ();
		this.grdCombs = new FlexCell.Grid ();
		this.cboSpec = new System.Windows.Forms.ComboBox ();
		this.lblSpec = new System.Windows.Forms.Label ();
		this.cboComb = new System.Windows.Forms.ComboBox ();
		this.lblCombination = new System.Windows.Forms.Label ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.tabOptions.SuspendLayout ();
		this.tabUnits.SuspendLayout ();
		this.tabMaterial.SuspendLayout ();
		this.tabThicknesses.SuspendLayout ();
		this.tabHeading.SuspendLayout ();
		this.tabCombinations.SuspendLayout ();
		base.SuspendLayout ();
		this.tabOptions.Controls.Add (this.tabUnits);
		this.tabOptions.Controls.Add (this.tabMaterial);
		this.tabOptions.Controls.Add (this.tabThicknesses);
		this.tabOptions.Controls.Add (this.tabHeading);
		this.tabOptions.Controls.Add (this.tabCombinations);
		this.tabOptions.Location = new System.Drawing.Point (5, 5);
		this.tabOptions.Name = "tabOptions";
		this.tabOptions.SelectedIndex = 0;
		this.tabOptions.Size = new System.Drawing.Size (321, 238);
		this.tabOptions.TabIndex = 0;
		this.tabUnits.Controls.Add (this.cboMomentUnit);
		this.tabUnits.Controls.Add (this.lblMoment);
		this.tabUnits.Controls.Add (this.cboStressUnit);
		this.tabUnits.Controls.Add (this.lblStress);
		this.tabUnits.Controls.Add (this.cboForceUnit);
		this.tabUnits.Controls.Add (this.lblForce);
		this.tabUnits.Controls.Add (this.cboAngleUnit);
		this.tabUnits.Controls.Add (this.lblAngle);
		this.tabUnits.Controls.Add (this.cboLengthUnit);
		this.tabUnits.Controls.Add (this.lblLength);
		this.tabUnits.Controls.Add (this.cboSectionUnit);
		this.tabUnits.Controls.Add (this.lblSection);
		this.tabUnits.Controls.Add (this.cboUnitSystem);
		this.tabUnits.Controls.Add (this.lblUnitSystem);
		this.tabUnits.Location = new System.Drawing.Point (4, 22);
		this.tabUnits.Name = "tabUnits";
		this.tabUnits.Padding = new System.Windows.Forms.Padding (3);
		this.tabUnits.Size = new System.Drawing.Size (313, 212);
		this.tabUnits.TabIndex = 0;
		this.tabUnits.Tag = "options-units.htm";
		this.tabUnits.Text = "Units";
		this.tabUnits.UseVisualStyleBackColor = true;
		this.cboMomentUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboMomentUnit.FormattingEnabled = true;
		this.cboMomentUnit.Location = new System.Drawing.Point (129, 176);
		this.cboMomentUnit.Name = "cboMomentUnit";
		this.cboMomentUnit.Size = new System.Drawing.Size (140, 21);
		this.cboMomentUnit.TabIndex = 14;
		this.lblMoment.Location = new System.Drawing.Point (23, 179);
		this.lblMoment.Name = "lblMoment";
		this.lblMoment.Size = new System.Drawing.Size (100, 17);
		this.lblMoment.TabIndex = 13;
		this.lblMoment.Text = "Moment";
		this.cboStressUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboStressUnit.FormattingEnabled = true;
		this.cboStressUnit.Location = new System.Drawing.Point (129, 149);
		this.cboStressUnit.Name = "cboStressUnit";
		this.cboStressUnit.Size = new System.Drawing.Size (140, 21);
		this.cboStressUnit.TabIndex = 12;
		this.lblStress.Location = new System.Drawing.Point (23, 152);
		this.lblStress.Name = "lblStress";
		this.lblStress.Size = new System.Drawing.Size (100, 17);
		this.lblStress.TabIndex = 11;
		this.lblStress.Text = "Stress";
		this.cboForceUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboForceUnit.FormattingEnabled = true;
		this.cboForceUnit.Location = new System.Drawing.Point (129, 122);
		this.cboForceUnit.Name = "cboForceUnit";
		this.cboForceUnit.Size = new System.Drawing.Size (140, 21);
		this.cboForceUnit.TabIndex = 10;
		this.lblForce.Location = new System.Drawing.Point (23, 125);
		this.lblForce.Name = "lblForce";
		this.lblForce.Size = new System.Drawing.Size (100, 17);
		this.lblForce.TabIndex = 9;
		this.lblForce.Text = "Force";
		this.cboAngleUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboAngleUnit.FormattingEnabled = true;
		this.cboAngleUnit.Location = new System.Drawing.Point (129, 95);
		this.cboAngleUnit.Name = "cboAngleUnit";
		this.cboAngleUnit.Size = new System.Drawing.Size (140, 21);
		this.cboAngleUnit.TabIndex = 8;
		this.lblAngle.Location = new System.Drawing.Point (23, 98);
		this.lblAngle.Name = "lblAngle";
		this.lblAngle.Size = new System.Drawing.Size (100, 17);
		this.lblAngle.TabIndex = 7;
		this.lblAngle.Text = "Angle";
		this.cboLengthUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboLengthUnit.FormattingEnabled = true;
		this.cboLengthUnit.Location = new System.Drawing.Point (129, 68);
		this.cboLengthUnit.Name = "cboLengthUnit";
		this.cboLengthUnit.Size = new System.Drawing.Size (140, 21);
		this.cboLengthUnit.TabIndex = 6;
		this.lblLength.Location = new System.Drawing.Point (23, 71);
		this.lblLength.Name = "lblLength";
		this.lblLength.Size = new System.Drawing.Size (100, 17);
		this.lblLength.TabIndex = 5;
		this.lblLength.Text = "Length";
		this.cboSectionUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSectionUnit.FormattingEnabled = true;
		this.cboSectionUnit.Location = new System.Drawing.Point (129, 41);
		this.cboSectionUnit.Name = "cboSectionUnit";
		this.cboSectionUnit.Size = new System.Drawing.Size (140, 21);
		this.cboSectionUnit.TabIndex = 4;
		this.lblSection.Location = new System.Drawing.Point (23, 44);
		this.lblSection.Name = "lblSection";
		this.lblSection.Size = new System.Drawing.Size (100, 17);
		this.lblSection.TabIndex = 3;
		this.lblSection.Text = "Section";
		this.cboUnitSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboUnitSystem.FormattingEnabled = true;
		this.cboUnitSystem.Location = new System.Drawing.Point (129, 14);
		this.cboUnitSystem.Name = "cboUnitSystem";
		this.cboUnitSystem.Size = new System.Drawing.Size (140, 21);
		this.cboUnitSystem.TabIndex = 2;
		this.lblUnitSystem.Location = new System.Drawing.Point (23, 17);
		this.lblUnitSystem.Name = "lblUnitSystem";
		this.lblUnitSystem.Size = new System.Drawing.Size (100, 17);
		this.lblUnitSystem.TabIndex = 1;
		this.lblUnitSystem.Text = "System of Units";
		this.tabMaterial.Controls.Add (this.chkReserve);
		this.tabMaterial.Controls.Add (this.cboTensile);
		this.tabMaterial.Controls.Add (this.lblTensile);
		this.tabMaterial.Controls.Add (this.cboYield);
		this.tabMaterial.Controls.Add (this.lblYield);
		this.tabMaterial.Controls.Add (this.chkColdWork);
		this.tabMaterial.Controls.Add (this.cmdCustom);
		this.tabMaterial.Controls.Add (this.cboMaterial);
		this.tabMaterial.Controls.Add (this.lblMaterial);
		this.tabMaterial.Location = new System.Drawing.Point (4, 22);
		this.tabMaterial.Name = "tabMaterial";
		this.tabMaterial.Padding = new System.Windows.Forms.Padding (3);
		this.tabMaterial.Size = new System.Drawing.Size (313, 212);
		this.tabMaterial.TabIndex = 1;
		this.tabMaterial.Tag = "options-material.htm";
		this.tabMaterial.Text = "Material";
		this.tabMaterial.UseVisualStyleBackColor = true;
		this.chkReserve.Location = new System.Drawing.Point (9, 75);
		this.chkReserve.Name = "chkReserve";
		this.chkReserve.Size = new System.Drawing.Size (298, 20);
		this.chkReserve.TabIndex = 5;
		this.chkReserve.Text = "Apply inelastic reserve strength increase";
		this.chkReserve.UseVisualStyleBackColor = true;
		this.cboTensile.FormattingEnabled = true;
		this.cboTensile.Location = new System.Drawing.Point (146, 137);
		this.cboTensile.Name = "cboTensile";
		this.cboTensile.Size = new System.Drawing.Size (133, 21);
		this.cboTensile.TabIndex = 9;
		this.lblTensile.Location = new System.Drawing.Point (26, 140);
		this.lblTensile.Name = "lblTensile";
		this.lblTensile.Size = new System.Drawing.Size (114, 17);
		this.lblTensile.TabIndex = 8;
		this.lblTensile.Text = "Tensile Strength, Fu";
		this.cboYield.FormattingEnabled = true;
		this.cboYield.Location = new System.Drawing.Point (146, 110);
		this.cboYield.Name = "cboYield";
		this.cboYield.Size = new System.Drawing.Size (133, 21);
		this.cboYield.TabIndex = 7;
		this.lblYield.Location = new System.Drawing.Point (26, 113);
		this.lblYield.Name = "lblYield";
		this.lblYield.Size = new System.Drawing.Size (114, 17);
		this.lblYield.TabIndex = 6;
		this.lblYield.Text = "Yield Strength, Fy";
		this.chkColdWork.Location = new System.Drawing.Point (9, 53);
		this.chkColdWork.Name = "chkColdWork";
		this.chkColdWork.Size = new System.Drawing.Size (298, 20);
		this.chkColdWork.TabIndex = 4;
		this.chkColdWork.Text = "Apply cold work of forming strength increase";
		this.chkColdWork.UseVisualStyleBackColor = true;
		this.cmdCustom.Location = new System.Drawing.Point (285, 26);
		this.cmdCustom.Name = "cmdCustom";
		this.cmdCustom.Size = new System.Drawing.Size (25, 21);
		this.cmdCustom.TabIndex = 3;
		this.cmdCustom.Text = "...";
		this.cmdCustom.UseVisualStyleBackColor = true;
		this.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboMaterial.FormattingEnabled = true;
		this.cboMaterial.Location = new System.Drawing.Point (93, 26);
		this.cboMaterial.Name = "cboMaterial";
		this.cboMaterial.Size = new System.Drawing.Size (186, 21);
		this.cboMaterial.TabIndex = 2;
		this.lblMaterial.Location = new System.Drawing.Point (6, 29);
		this.lblMaterial.Name = "lblMaterial";
		this.lblMaterial.Size = new System.Drawing.Size (89, 17);
		this.lblMaterial.TabIndex = 1;
		this.lblMaterial.Text = "Default Material";
		this.tabThicknesses.Controls.Add (this.txtEditThickness);
		this.tabThicknesses.Controls.Add (this.grdThickness);
		this.tabThicknesses.Controls.Add (this.cmdReset);
		this.tabThicknesses.Location = new System.Drawing.Point (4, 22);
		this.tabThicknesses.Name = "tabThicknesses";
		this.tabThicknesses.Size = new System.Drawing.Size (313, 212);
		this.tabThicknesses.TabIndex = 2;
		this.tabThicknesses.Tag = "options-thicknesses.htm";
		this.tabThicknesses.Text = "Thicknesses";
		this.tabThicknesses.UseVisualStyleBackColor = true;
		this.txtEditThickness.Location = new System.Drawing.Point (6, 185);
		this.txtEditThickness.Name = "txtEditThickness";
		this.txtEditThickness.Size = new System.Drawing.Size (131, 20);
		this.txtEditThickness.TabIndex = 3;
		this.txtEditThickness.Visible = false;
		this.grdThickness.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdThickness.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdThickness.BoldFixedCell = false;
		this.grdThickness.CheckedImage = null;
		this.grdThickness.Cols = 4;
		this.grdThickness.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.grdThickness.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdThickness.Location = new System.Drawing.Point (6, 6);
		this.grdThickness.MultiSelect = false;
		this.grdThickness.Name = "grdThickness";
		this.grdThickness.Rows = 3;
		this.grdThickness.Size = new System.Drawing.Size (297, 173);
		this.grdThickness.TabIndex = 1;
		this.grdThickness.UncheckedImage = null;
		this.cmdReset.Location = new System.Drawing.Point (228, 183);
		this.cmdReset.Name = "cmdReset";
		this.cmdReset.Size = new System.Drawing.Size (75, 25);
		this.cmdReset.TabIndex = 2;
		this.cmdReset.Text = "&Reset";
		this.cmdReset.UseVisualStyleBackColor = true;
		this.tabHeading.Controls.Add (this.txtFax);
		this.tabHeading.Controls.Add (this.lblFax);
		this.tabHeading.Controls.Add (this.txtPhone);
		this.tabHeading.Controls.Add (this.lblPhone);
		this.tabHeading.Controls.Add (this.txtEmail);
		this.tabHeading.Controls.Add (this.lblEmail);
		this.tabHeading.Controls.Add (this.txtAddress2);
		this.tabHeading.Controls.Add (this.lblAddress2);
		this.tabHeading.Controls.Add (this.txtAddress1);
		this.tabHeading.Controls.Add (this.lblAddress1);
		this.tabHeading.Controls.Add (this.txtCompany);
		this.tabHeading.Controls.Add (this.lblCompany);
		this.tabHeading.Controls.Add (this.txtUser);
		this.tabHeading.Controls.Add (this.lblUser);
		this.tabHeading.Location = new System.Drawing.Point (4, 22);
		this.tabHeading.Name = "tabHeading";
		this.tabHeading.Size = new System.Drawing.Size (313, 212);
		this.tabHeading.TabIndex = 3;
		this.tabHeading.Tag = "options-heading.htm";
		this.tabHeading.Text = "Heading";
		this.tabHeading.UseVisualStyleBackColor = true;
		this.txtFax.Location = new System.Drawing.Point (95, 166);
		this.txtFax.MaxLength = 16;
		this.txtFax.Name = "txtFax";
		this.txtFax.Size = new System.Drawing.Size (209, 20);
		this.txtFax.TabIndex = 13;
		this.lblFax.Location = new System.Drawing.Point (9, 169);
		this.lblFax.Name = "lblFax";
		this.lblFax.Size = new System.Drawing.Size (80, 17);
		this.lblFax.TabIndex = 12;
		this.lblFax.Text = "Fax";
		this.txtPhone.Location = new System.Drawing.Point (95, 140);
		this.txtPhone.MaxLength = 16;
		this.txtPhone.Name = "txtPhone";
		this.txtPhone.Size = new System.Drawing.Size (209, 20);
		this.txtPhone.TabIndex = 11;
		this.lblPhone.Location = new System.Drawing.Point (9, 143);
		this.lblPhone.Name = "lblPhone";
		this.lblPhone.Size = new System.Drawing.Size (80, 17);
		this.lblPhone.TabIndex = 10;
		this.lblPhone.Text = "Phone";
		this.txtEmail.Location = new System.Drawing.Point (95, 114);
		this.txtEmail.MaxLength = 40;
		this.txtEmail.Name = "txtEmail";
		this.txtEmail.Size = new System.Drawing.Size (209, 20);
		this.txtEmail.TabIndex = 9;
		this.lblEmail.Location = new System.Drawing.Point (9, 117);
		this.lblEmail.Name = "lblEmail";
		this.lblEmail.Size = new System.Drawing.Size (80, 17);
		this.lblEmail.TabIndex = 8;
		this.lblEmail.Text = "Email";
		this.txtAddress2.Location = new System.Drawing.Point (95, 88);
		this.txtAddress2.MaxLength = 40;
		this.txtAddress2.Name = "txtAddress2";
		this.txtAddress2.Size = new System.Drawing.Size (209, 20);
		this.txtAddress2.TabIndex = 7;
		this.lblAddress2.Location = new System.Drawing.Point (9, 91);
		this.lblAddress2.Name = "lblAddress2";
		this.lblAddress2.Size = new System.Drawing.Size (80, 17);
		this.lblAddress2.TabIndex = 6;
		this.lblAddress2.Text = "Address";
		this.txtAddress1.Location = new System.Drawing.Point (95, 62);
		this.txtAddress1.MaxLength = 40;
		this.txtAddress1.Name = "txtAddress1";
		this.txtAddress1.Size = new System.Drawing.Size (209, 20);
		this.txtAddress1.TabIndex = 5;
		this.lblAddress1.Location = new System.Drawing.Point (9, 65);
		this.lblAddress1.Name = "lblAddress1";
		this.lblAddress1.Size = new System.Drawing.Size (80, 17);
		this.lblAddress1.TabIndex = 4;
		this.lblAddress1.Text = "Address";
		this.txtCompany.Location = new System.Drawing.Point (95, 36);
		this.txtCompany.MaxLength = 40;
		this.txtCompany.Name = "txtCompany";
		this.txtCompany.Size = new System.Drawing.Size (209, 20);
		this.txtCompany.TabIndex = 3;
		this.lblCompany.Location = new System.Drawing.Point (9, 39);
		this.lblCompany.Name = "lblCompany";
		this.lblCompany.Size = new System.Drawing.Size (80, 17);
		this.lblCompany.TabIndex = 2;
		this.lblCompany.Text = "Company";
		this.txtUser.Location = new System.Drawing.Point (95, 10);
		this.txtUser.MaxLength = 40;
		this.txtUser.Name = "txtUser";
		this.txtUser.Size = new System.Drawing.Size (209, 20);
		this.txtUser.TabIndex = 1;
		this.lblUser.Location = new System.Drawing.Point (9, 13);
		this.lblUser.Name = "lblUser";
		this.lblUser.Size = new System.Drawing.Size (80, 17);
		this.lblUser.TabIndex = 0;
		this.lblUser.Text = "User Name";
		this.tabCombinations.Controls.Add (this.txtEditComb);
		this.tabCombinations.Controls.Add (this.grdCombs);
		this.tabCombinations.Controls.Add (this.cboSpec);
		this.tabCombinations.Controls.Add (this.lblSpec);
		this.tabCombinations.Controls.Add (this.cboComb);
		this.tabCombinations.Controls.Add (this.lblCombination);
		this.tabCombinations.Location = new System.Drawing.Point (4, 22);
		this.tabCombinations.Name = "tabCombinations";
		this.tabCombinations.Size = new System.Drawing.Size (313, 212);
		this.tabCombinations.TabIndex = 4;
		this.tabCombinations.Tag = "options-combinations.htm";
		this.tabCombinations.Text = "Combinations";
		this.tabCombinations.UseVisualStyleBackColor = true;
		this.txtEditComb.Location = new System.Drawing.Point (176, 171);
		this.txtEditComb.Name = "txtEditComb";
		this.txtEditComb.Size = new System.Drawing.Size (98, 20);
		this.txtEditComb.TabIndex = 5;
		this.txtEditComb.Visible = false;
		this.grdCombs.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdCombs.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdCombs.BoldFixedCell = false;
		this.grdCombs.CheckedImage = null;
		this.grdCombs.Cols = 2;
		this.grdCombs.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.grdCombs.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdCombs.Location = new System.Drawing.Point (6, 69);
		this.grdCombs.MultiSelect = false;
		this.grdCombs.Name = "grdCombs";
		this.grdCombs.Rows = 9;
		this.grdCombs.Size = new System.Drawing.Size (297, 138);
		this.grdCombs.TabIndex = 4;
		this.grdCombs.UncheckedImage = null;
		this.cboSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSpec.FormattingEnabled = true;
		this.cboSpec.Location = new System.Drawing.Point (126, 39);
		this.cboSpec.Name = "cboSpec";
		this.cboSpec.Size = new System.Drawing.Size (177, 21);
		this.cboSpec.TabIndex = 3;
		this.lblSpec.Location = new System.Drawing.Point (6, 42);
		this.lblSpec.Name = "lblSpec";
		this.lblSpec.Size = new System.Drawing.Size (114, 17);
		this.lblSpec.TabIndex = 2;
		this.lblSpec.Text = "Specification";
		this.cboComb.FormattingEnabled = true;
		this.cboComb.Location = new System.Drawing.Point (126, 10);
		this.cboComb.MaxLength = 30;
		this.cboComb.Name = "cboComb";
		this.cboComb.Size = new System.Drawing.Size (177, 21);
		this.cboComb.TabIndex = 1;
		this.lblCombination.Location = new System.Drawing.Point (6, 13);
		this.lblCombination.Name = "lblCombination";
		this.lblCombination.Size = new System.Drawing.Size (114, 17);
		this.lblCombination.TabIndex = 0;
		this.lblCombination.Text = "Custom Combination";
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (165, 249);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 1;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (246, 249);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (333, 284);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.tabOptions);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmOptions";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Options";
		this.tabOptions.ResumeLayout (false);
		this.tabUnits.ResumeLayout (false);
		this.tabMaterial.ResumeLayout (false);
		this.tabThicknesses.ResumeLayout (false);
		this.tabThicknesses.PerformLayout ();
		this.tabHeading.ResumeLayout (false);
		this.tabHeading.PerformLayout ();
		this.tabCombinations.ResumeLayout (false);
		this.tabCombinations.PerformLayout ();
		base.ResumeLayout (false);
	}

	private void AddComb (System.Windows.Forms.ComboBox cboName)
	{
		checked {
			if (cboName.Items.Count - intUserCombsTmp > 0) {
				return;
			}
			short num = 0;
			string text;
			short num3;
			do {
				num = (short)(num + 1);
				short num2;
				unchecked {
					text = "Combination " + Conversions.ToString ((int)checked((short)unchecked(intUserCombsTmp + num)));
					num2 = intUserCombsTmp;
					num3 = 1;
				}
				while (num3 <= num2 && Strings.StrComp (UserCombTmp [num3].Description, text, CompareMethod.Text) != 0) {
					num3 = (short)unchecked(num3 + 1);
				}
			} while (num3 <= intUserCombsTmp);
			cboName.Items.Add (text);
		}
	}

	private void DeleteThickness (byte iDelThickness)
	{
		checked {
			byte b = (byte)Information.UBound (ThicknessTmp);
			if (b > 1 && unchecked((uint)iDelThickness <= (uint)b)) {
				int num = unchecked((int)b) - 1;
				for (int i = iDelThickness; i <= num; i++) {
					ThicknessTmp [i] = ThicknessTmp [i + 1];
				}
				ref Thickness[] thicknessTmp = ref ThicknessTmp;
				thicknessTmp = (Thickness[])Utils.CopyArray (thicknessTmp, new Thickness[unchecked((int)b) - 1 + 1]);
				blnTabChange [tabOptions.SelectedIndex] = true;
				RefreshThickness ();
			}
		}
	}

	private void MatchUnits ()
	{
		short num = 3;
		int num2 = Information.UBound (Units.UnitSys [1].UnitIndex);
		checked {
			for (int i = 1; i <= num2; i++) {
				if (DefaultUnitIndexTmp [i] != Units.UnitSys [1].UnitIndex [i]) {
					num = (short)(num & -2);
				}
				if (DefaultUnitIndexTmp [i] != Units.UnitSys [2].UnitIndex [i]) {
					num = (short)(num & -3);
				}
			}
			if ((num & 1) == 1) {
				CFSInterface.SetSelectedItem (cboUnitSystem, Units.UnitSys [1].Name);
				iUnitSysTmp = 1;
			} else if ((num & 2) == 2) {
				CFSInterface.SetSelectedItem (cboUnitSystem, Units.UnitSys [2].Name);
				iUnitSysTmp = 2;
			} else {
				CFSInterface.SetSelectedItem (cboUnitSystem, Units.UnitSys [3].Name);
				iUnitSysTmp = 3;
			}
		}
	}

	private void RefreshComb ()
	{
		CFS.blnValidate = false;
		blnCodeChange = true;
		cboComb.Items.Clear ();
		int num = intUserCombsTmp;
		checked {
			for (int i = 1; i <= num; i++) {
				cboComb.Items.Add (UserCombTmp [i].Description);
			}
			AddComb (cboComb);
			cboComb.SelectedIndex = intComb - 1;
			cboSpec.SelectedIndex = -1;
			if (intComb <= Information.UBound (UserCombTmp)) {
				int num2 = cboSpec.Items.Count - 1;
				for (int j = 0; j <= num2; j++) {
					if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboSpec.Items [j], null, "ItemData", new object[0], null, null, null), UserCombTmp [intComb].Spec, TextCompare: false)) {
						cboSpec.SelectedIndex = j;
						break;
					}
				}
				int nLF = UserCombTmp [intComb].nLF;
				for (int k = 1; k <= nLF; k++) {
					grdCombs.Cell (k, 1).Text = Units.FormatNum (UserCombTmp [intComb].LF [k].fLdg);
				}
				CFSInterface.SetGrid (grdCombs, UserCombTmp [intComb].LFGrid);
			}
			blnCodeChange = false;
			CFS.blnValidate = true;
		}
	}

	private void RefreshMtl ()
	{
		CFS.blnValidate = false;
		MaterialType materialTmp = MaterialTmp;
		cboYield.Enabled = materialTmp.IsCarbon ();
		cboTensile.Enabled = materialTmp.IsCarbon ();
		chkColdWork.Checked = blnColdWorkTmp;
		chkReserve.Checked = blnReserveTmp;
		NewLateBinding.LateSetComplex (cboYield.Tag, null, "Min", new object[1] { materialTmp.FyMin }, null, null, OptimisticSet: false, RValueBase: true);
		NewLateBinding.LateSetComplex (cboYield.Tag, null, "Max", new object[1] { materialTmp.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
		NewLateBinding.LateSetComplex (cboTensile.Tag, null, "Min", new object[1] { materialTmp.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
		NewLateBinding.LateSetComplex (cboTensile.Tag, null, "Max", new object[1] { materialTmp.FuMax }, null, null, OptimisticSet: false, RValueBase: true);
		CFSInterface.SetText (cboYield, materialTmp.Fy [2]);
		CFSInterface.SetText (cboTensile, materialTmp.Fu);
		materialTmp = null;
		CFS.blnValidate = true;
	}

	private void RefreshThickness ()
	{
		_ = string.Empty;
		checked {
			byte b = (byte)Information.UBound (ThicknessTmp);
			CFS.blnValidate = false;
			blnCodeChange = true;
			grdThickness.Rows = unchecked((int)b) + 2;
			grdThickness.Range (1, 0, grdThickness.Rows - 1, 3).Locked = false;
			grdThickness.Range (1, 0, grdThickness.Rows - 1, 3).ClearText ();
			grdThickness.Range (unchecked((int)b) + 1, 2, unchecked((int)b) + 1, 3).Locked = true;
			if (unchecked((int)b) + 1 >= 255) {
				grdThickness.Range (255, 1, 255, 1).Locked = true;
			}
			int num = b;
			for (int i = 1; i <= num; i++) {
				ref Thickness reference = ref ThicknessTmp [i];
				grdThickness.Cell (i, 1).Text = reference.Name;
				grdThickness.Cell (i, 2).Text = Units.DisplayLen1 (reference.Thickness, 0, blnShowUnit: false, "", 0, 0);
				grdThickness.Cell (i, 3).Text = Units.DisplayLen1 (reference.DefRad, 0, blnShowUnit: false, "", 0, 0);
			}
			grdThickness.Cell (grdThickness.ActiveCell.Row, 0).Text = ">>";
			blnCodeChange = false;
			CFS.blnValidate = true;
		}
	}

	private void RenameComb (bool blnSetListIndex = true)
	{
		string text = Strings.Trim (cboComb.Text);
		if (Strings.StrComp (text, Conversions.ToString (NewLateBinding.LateGet (cboComb.Tag, null, "Text", new object[0], null, null, null))) == 0) {
			return;
		}
		if ((intComb > intUserCombsTmp) & (Strings.Len (text) == 0)) {
			text = Conversions.ToString (NewLateBinding.LateGet (cboComb.Tag, null, "Text", new object[0], null, null, null));
		}
		NewLateBinding.LateSetComplex (cboComb.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			short num = (short)(cboComb.Items.Count - 1);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Strings.StrComp (Conversions.ToString (cboComb.Items [num2]), text, CompareMethod.Text) == 0) {
					text = string.Empty;
					cboComb.SelectedIndex = num2;
					return;
				}
			}
			if (Strings.Len (text) == 0) {
				cboComb.Items.RemoveAt (intComb - 1);
				short num3 = (short)(intComb + 1);
				short num4 = intUserCombsTmp;
				short num2;
				for (num2 = num3; num2 <= num4; num2 = (short)unchecked(num2 + 1)) {
					UserCombTmp [num2 - 1] = UserCombTmp [num2];
				}
				UserCombTmp [num2 - 1].Initialize (string.Empty, 10);
				ref LoadCombination reference = ref UserCombTmp [num2 - 1];
				reference.nLF = 8;
				reference.LF [1].iLdg = 0;
				reference.LF [2].iLdg = 1;
				reference.LF [3].iLdg = 2;
				reference.LF [4].iLdg = 3;
				reference.LF [5].iLdg = 4;
				reference.LF [6].iLdg = 5;
				reference.LF [7].iLdg = 6;
				reference.LF [8].iLdg = 7;
				if (intUserCombsTmp > 0) {
					intUserCombsTmp--;
				}
				if (intComb > 1) {
					intComb--;
				}
				if (intUserCombsTmp == 0) {
					UserCombTmp [intComb].Description = "Combination 1";
				}
				RefreshComb ();
			} else {
				text = Strings.Left (text, 30);
				UserCombTmp [intComb].Description = text;
				if (intComb > intUserCombsTmp) {
					intUserCombsTmp = intComb;
				}
				cboComb.Items [intComb - 1] = text;
				text = string.Empty;
				if (blnSetListIndex) {
					cboComb.SelectedIndex = intComb - 1;
				}
			}
			blnTabChange [tabOptions.SelectedIndex] = true;
		}
	}

	private void frmOptions_Load (object sender, EventArgs e)
	{
		checked {
			DefaultUnitIndexTmp = new byte[Information.UBound (Units.DefaultUnitIndex) + 1];
			ThicknessTmp = new Thickness[Information.UBound (CFS.Thicknesses) + 1];
			UserCombTmp = new LoadCombination[Information.UBound (CFS.UserComb) + 1];
			Cursor.Current = Cursors.WaitCursor;
			CFS.blnOptionsLoaded = true;
			txtUser.Tag = new ControlData (byte.MaxValue);
			txtCompany.Tag = new ControlData (byte.MaxValue);
			txtAddress1.Tag = new ControlData (byte.MaxValue);
			txtAddress2.Tag = new ControlData (byte.MaxValue);
			txtEmail.Tag = new ControlData (byte.MaxValue);
			txtPhone.Tag = new ControlData (byte.MaxValue);
			txtFax.Tag = new ControlData (byte.MaxValue);
			cboYield.Tag = new ControlData (5, 0f, 120f);
			cboTensile.Tag = new ControlData (5, 0f, 120f);
			txtEditThickness.Tag = new ControlData (byte.MaxValue);
			cboComb.Tag = new ControlData (byte.MaxValue);
			txtEditComb.Tag = new ControlData (0, -10f, 10f);
			iMaterialTmp = CFS.iMaterial;
			MaterialTmp = CFS.MaterialDefault.Clone ();
			CFS.Materials [0] = MaterialTmp.Clone ();
			blnColdWorkTmp = CFS.blnColdWork;
			blnReserveTmp = CFS.blnReserve;
			iUnitSysTmp = Units.iUnitSys;
			short num = (short)Information.UBound (DefaultUnitIndexTmp);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				DefaultUnitIndexTmp [num2] = Units.DefaultUnitIndex [num2];
			}
			short num3 = (short)Information.UBound (ThicknessTmp);
			for (short num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				ThicknessTmp [num2] = CFS.Thicknesses [num2];
			}
			intUserCombsTmp = CFS.intUserCombs;
			short num4 = (short)Information.UBound (UserCombTmp);
			for (short num2 = 1; num2 <= num4; num2 = (short)unchecked(num2 + 1)) {
				UserCombTmp [num2] = CFS.UserComb [num2].Clone ();
			}
			intComb = 1;
			UserTmp = CFS.User;
			short num5 = (short)Information.UBound (Units.untLength);
			for (short num2 = 1; num2 <= num5; num2 = (short)unchecked(num2 + 1)) {
				if (Units.untLength [num2].Mult > 0f) {
					cboSectionUnit.Items.Add (new ListItem (Units.untLength [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [1]) {
						cboSectionUnit.SelectedIndex = num2 - 1;
					}
					cboLengthUnit.Items.Add (new ListItem (Units.untLength [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [2]) {
						cboLengthUnit.SelectedIndex = num2 - 1;
					}
				}
			}
			short num6 = (short)Information.UBound (Units.untAngle);
			for (short num2 = 1; num2 <= num6; num2 = (short)unchecked(num2 + 1)) {
				if (Units.untAngle [num2].Mult > 0f) {
					cboAngleUnit.Items.Add (new ListItem (Units.untAngle [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [3]) {
						cboAngleUnit.SelectedIndex = num2 - 1;
					}
				}
			}
			short num7 = (short)Information.UBound (Units.untForce);
			for (short num2 = 1; num2 <= num7; num2 = (short)unchecked(num2 + 1)) {
				if (Units.untForce [num2].Mult > 0f) {
					cboForceUnit.Items.Add (new ListItem (Units.untForce [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [4]) {
						cboForceUnit.SelectedIndex = num2 - 1;
					}
				}
			}
			short num8 = (short)Information.UBound (Units.untStress);
			for (short num2 = 1; num2 <= num8; num2 = (short)unchecked(num2 + 1)) {
				if (Units.untStress [num2].Mult > 0f) {
					cboStressUnit.Items.Add (new ListItem (Units.untStress [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [5]) {
						cboStressUnit.SelectedIndex = num2 - 1;
					}
				}
			}
			short num9 = (short)Information.UBound (Units.untMoment);
			for (short num2 = 1; num2 <= num9; num2 = (short)unchecked(num2 + 1)) {
				if (Units.untMoment [num2].Mult > 0f) {
					cboMomentUnit.Items.Add (new ListItem (Units.untMoment [num2].Name, num2));
					if (num2 == DefaultUnitIndexTmp [6]) {
						cboMomentUnit.SelectedIndex = num2 - 1;
					}
				}
			}
			blnCodeChange = true;
			Grid grid = grdThickness;
			grid.Column (0).Alignment = AlignmentEnum.CenterCenter;
			grid.Column (1).Alignment = AlignmentEnum.LeftCenter;
			grid.Column (2).Alignment = AlignmentEnum.RightCenter;
			grid.Column (3).Alignment = AlignmentEnum.RightCenter;
			grid.Range (0, 1, 0, 3).WrapText = true;
			grid.Range (0, 1, 0, 3).Alignment = AlignmentEnum.CenterTop;
			grid.Cell (0, 0).Text = ">>";
			grid.Column (0).AutoFit ();
			grid.Cell (0, 0).Text = string.Empty;
			grid.Cell (0, 1).Text = "Name";
			grid.Column (1).Width = 100;
			grid.Cell (0, 2).Text = "Thickness";
			grid.Column (2).AutoFit ();
			Cell cell;
			(cell = grid.Cell (0, 2)).Text = cell.Text + "\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
			grid.Cell (0, 3).Text = "Radius (mm)";
			grid.Column (3).AutoFit ();
			grid.Cell (0, 3).Text = "Inside\nRadius (" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
			grid.Row (0).AutoFit ();
			grid.Rows = Information.UBound (CFS.Thicknesses) + 2;
			grid.Range (CFS.iThickness, 1, CFS.iThickness, 1).SelectCells ();
			_ = null;
			blnCodeChange = false;
			CFS.blnValidate = false;
			short num10 = (short)Information.UBound (Units.UnitSys);
			for (short num2 = 1; num2 <= num10; num2 = (short)unchecked(num2 + 1)) {
				cboUnitSystem.Items.Add (new ListItem (Units.UnitSys [num2].Name, num2));
				if (num2 == Units.iUnitSys) {
					cboUnitSystem.SelectedIndex = num2 - 1;
				}
			}
			if (iMaterialTmp == 0) {
				cboMaterial.Items.Add (new ListItem (Strings.Trim (MaterialTmp.Name), 0));
				cboMaterial.SelectedIndex = 0;
			}
			short num11 = (short)Information.UBound (CFS.Materials);
			for (short num2 = 1; num2 <= num11; num2 = (short)unchecked(num2 + 1)) {
				if (CFS.Materials [num2].Eo [2] > 0f) {
					cboMaterial.Items.Add (new ListItem (Strings.Trim (CFS.Materials [num2].Name), num2));
					if (iMaterialTmp == num2) {
						cboMaterial.SelectedIndex = cboMaterial.Items.Count - 1;
					}
				}
			}
			txtUser.Text = UserTmp.Name;
			txtUser.SelectAll ();
			txtCompany.Text = UserTmp.Company;
			txtCompany.SelectAll ();
			txtAddress1.Text = UserTmp.Address1;
			txtAddress1.SelectAll ();
			txtAddress2.Text = UserTmp.Address2;
			txtAddress2.SelectAll ();
			txtEmail.Text = UserTmp.Email;
			txtEmail.SelectAll ();
			txtPhone.Text = UserTmp.Phone;
			txtPhone.SelectAll ();
			txtFax.Text = UserTmp.Fax;
			txtFax.SelectAll ();
			CFS.blnValidate = true;
			if (CFS.intLicenseType == CFS.LicenseTypes.Semaphore) {
				txtCompany.ReadOnly = true;
			}
			RefreshMtl ();
			RefreshThickness ();
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [37], 37));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [38], 38));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [39], 39));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [40], 40));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [41], 41));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [32], 32));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [33], 33));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [34], 34));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [35], 35));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [36], 36));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [27], 27));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [28], 28));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [29], 29));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [30], 30));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [31], 31));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [22], 22));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [23], 23));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [24], 24));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [25], 25));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [26], 26));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [17], 17));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [18], 18));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [19], 19));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [20], 20));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [21], 21));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [12], 12));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [13], 13));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [14], 14));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [15], 15));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [16], 16));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [7], 7));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [8], 8));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [9], 9));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [10], 10));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [11], 11));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [2], 2));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [3], 3));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [4], 4));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [5], 5));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [6], 6));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [0], 0));
			cboSpec.Items.Add (new ListItem (CFS.strCSspec [1], 1));
			blnCodeChange = true;
			Grid grid2 = grdCombs;
			grid2.Column (0).Alignment = AlignmentEnum.LeftCenter;
			grid2.Column (1).Alignment = AlignmentEnum.RightCenter;
			grid2.Range (0, 0, 0, 1).Alignment = AlignmentEnum.CenterTop;
			grid2.Cell (0, 0).Text = "Loading";
			grid2.Cell (0, 1).Text = "Load Factor";
			grid2.Cell (1, 0).Text = "Beam Self Weight";
			grid2.Cell (2, 0).Text = "Dead Load (D)";
			grid2.Cell (3, 0).Text = "Live Load (L)";
			grid2.Cell (4, 0).Text = "Product Load (P)";
			grid2.Cell (5, 0).Text = "Roof Live Load (Lr)";
			grid2.Cell (6, 0).Text = "Snow Load (S)";
			grid2.Cell (7, 0).Text = "Wind Load (W)";
			grid2.Cell (8, 0).Text = "Earthquake Load (E)";
			grid2.Column (0).AutoFit ();
			grid2.Column (1).AutoFit ();
			grid2.Range (1, 1, 1, 1).SelectCells ();
			_ = null;
			blnCodeChange = false;
			RefreshComb ();
			blnTabOptions = true;
			short num12 = (short)Information.UBound (blnTabChange);
			for (short num2 = 0; num2 <= num12; num2 = (short)unchecked(num2 + 1)) {
				blnTabChange [num2] = false;
			}
			tabOptions.SelectedIndex = CFS.bytOptionsTab;
			Cursor.Current = Cursors.Default;
		}
	}

	private void frmOptions_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Type typeFromHandle = typeof(Help);
			TabPage selectedTab;
			object[] obj = new object[3] {
				this,
				CFS.strAppPath + "CFS.chm",
				(selectedTab = tabOptions.SelectedTab).Tag
			};
			object[] array = obj;
			bool[] obj2 = new bool[3] { false, false, true };
			bool[] array2 = obj2;
			NewLateBinding.LateCall (null, typeFromHandle, "ShowHelp", obj, null, null, obj2, IgnoreReturn: true);
			if (array2 [2]) {
				selectedTab.Tag = RuntimeHelpers.GetObjectValue (RuntimeHelpers.GetObjectValue (array [2]));
			}
			e.Handled = true;
		}
	}

	private void frmOptions_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Type typeFromHandle = typeof(Help);
		TabPage selectedTab;
		object[] obj = new object[3] {
			this,
			CFS.strAppPath + "CFS.chm",
			(selectedTab = tabOptions.SelectedTab).Tag
		};
		object[] array = obj;
		bool[] obj2 = new bool[3] { false, false, true };
		bool[] array2 = obj2;
		NewLateBinding.LateCall (null, typeFromHandle, "ShowHelp", obj, null, null, obj2, IgnoreReturn: true);
		if (array2 [2]) {
			selectedTab.Tag = RuntimeHelpers.GetObjectValue (RuntimeHelpers.GetObjectValue (array [2]));
		}
		e.Cancel = true;
	}

	private void frmOptions_FormClosing (object sender, FormClosingEventArgs e)
	{
		CFS.bytOptionsTab = checked((byte)tabOptions.SelectedIndex);
		CFS.blnOptionsLoaded = false;
	}

	private void tabOptions_SelectedIndexChanged (object sender, EventArgs e)
	{
		switch (tabOptions.SelectedIndex) {
		case 0:
			cboUnitSystem.Select ();
			break;
		case 1:
			cboMaterial.Select ();
			break;
		case 2:
			grdThickness.Select ();
			break;
		case 3:
			if (!txtUser.ReadOnly) {
				txtUser.Select ();
			} else {
				txtAddress1.Select ();
			}
			break;
		case 4:
			if (cboComb.Visible) {
				cboComb.Select ();
			} else {
				tabOptions.Select ();
			}
			break;
		}
	}

	private void chkColdWork_Click (object sender, EventArgs e)
	{
		blnTabChange [tabOptions.SelectedIndex] = true;
		blnColdWorkTmp = chkColdWork.Checked;
	}

	private void chkReserve_Click (object sender, EventArgs e)
	{
		blnTabChange [tabOptions.SelectedIndex] = true;
		blnReserveTmp = chkReserve.Checked;
	}

	private void cmdCustom_Click (object sender, EventArgs e)
	{
		CFS.Materials [0] = MaterialTmp.Clone ();
		if (My.MyProject.Forms.frmMaterial.ShowDialog (My.MyProject.Forms.mdiCFS) == DialogResult.OK) {
			CFS.Materials [0] = (MaterialType)My.MyProject.Forms.frmMaterial.Tag;
			blnTabChange [tabOptions.SelectedIndex] = true;
			Refresh ();
			MaterialTmp = CFS.Materials [0].Clone ();
			iMaterialTmp = CFS.MatchMaterial (MaterialTmp);
			CFS.blnValidate = false;
			CFSInterface.RebuildMtlList (MaterialTmp, iMaterialTmp, cboMaterial);
			CFS.blnValidate = true;
			RefreshMtl ();
		}
		My.MyProject.Forms.frmMaterial.Dispose ();
	}

	private void cmdReset_Click (object sender, EventArgs e)
	{
		if (checked((short)Interaction.MsgBox ("Replace currently defined thicknesses with program defaults?", MsgBoxStyle.OkCancel | MsgBoxStyle.Question)) == 1) {
			CFS.ResetThicknesses (ref ThicknessTmp);
			RefreshThickness ();
			blnTabChange [tabOptions.SelectedIndex] = true;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		if (MaterialTmp.Fu > 3f * MaterialTmp.Fy [2]) {
			Interaction.MsgBox ("Tensile strength exceeds 3Fy.", MsgBoxStyle.Information);
			return;
		}
		Cursor.Current = Cursors.Default;
		Hide ();
		checked {
			if (blnTabChange [0]) {
				CFSInterface.DepedentUnits (ref DefaultUnitIndexTmp);
				Units.iUnitSys = iUnitSysTmp;
				short num = (short)Information.UBound (Units.DefaultUnitIndex);
				for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					Units.DefaultUnitIndex [num2] = DefaultUnitIndexTmp [num2];
				}
				if (Units.iUnitSys == 3) {
					short num3 = (short)Information.LBound (Units.UnitSys [Units.iUnitSys].UnitIndex);
					short num4 = (short)Information.UBound (Units.UnitSys [Units.iUnitSys].UnitIndex);
					for (short num2 = num3; num2 <= num4; num2 = (short)unchecked(num2 + 1)) {
						Units.UnitSys [3].UnitIndex [num2] = Units.DefaultUnitIndex [num2];
					}
				}
				CFSInterface.RegistryUnits (1);
				if (CFS.blnSctInpLoaded) {
					My.MyProject.Forms.frmSctInp.SetControlData ();
					My.MyProject.Forms.frmSctInp.SetGridTitles ();
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				}
				if (CFS.blnAnlInpLoaded) {
					My.MyProject.Forms.frmAnlInp.SetControlData ();
					My.MyProject.Forms.frmAnlInp.SetGridTitles ();
					CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
				}
			}
			if (blnTabChange [1]) {
				CFS.iMaterial = iMaterialTmp;
				CFS.MaterialDefault = MaterialTmp.Clone ();
				CFS.blnColdWork = blnColdWorkTmp;
				CFS.blnReserve = blnReserveTmp;
				CFSInterface.RegistryMaterial (1);
			}
			if (blnTabChange [2]) {
				byte b = (byte)Information.UBound (ThicknessTmp);
				short num5 = ((grdThickness.ActiveCell.Row >= grdThickness.Rows - 1) ? ((short)(grdThickness.Rows - 2)) : ((short)grdThickness.ActiveCell.Row));
				short num6 = (short)(unchecked((int)b) - 1);
				for (short num2 = 1; num2 <= num6; num2 = (short)unchecked(num2 + 1)) {
					if (ThicknessTmp [num2].Thickness > ThicknessTmp [num2 + 1].Thickness) {
						if (num5 == num2) {
							num5 = (short)(num2 + 1);
						} else if (num5 == num2 + 1) {
							num5 = num2;
						}
						Thickness thickness = ThicknessTmp [num2];
						ThicknessTmp [num2] = ThicknessTmp [num2 + 1];
						ThicknessTmp [num2 + 1] = thickness;
						if (num2 > 1) {
							num2 = (short)(num2 - 2);
						}
					}
				}
				CFS.iThickness = num5;
				CFS.Thicknesses = new Thickness[unchecked((int)b) + 1];
				short num7 = b;
				for (short num2 = 1; num2 <= num7; num2 = (short)unchecked(num2 + 1)) {
					CFS.Thicknesses [num2] = ThicknessTmp [num2];
				}
				short num8 = (short)Information.UBound (CFS.hdgSctPic);
				for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
					if (!CFS.hdgSctPic [num9].Deleted) {
						Section section = CFS.Sections [num9];
						short nPart = section.nPart;
						for (short num10 = 1; num10 <= nPart; num10 = (short)unchecked(num10 + 1)) {
							CFS.SetThicknessIndex (section.Part [num10]);
						}
						section = null;
					}
				}
				if (CFS.blnSctInpLoaded) {
					My.MyProject.Forms.frmSctInp.cboThicknessName.Items.Clear ();
					short num11 = (short)Information.UBound (CFS.Thicknesses);
					for (short num2 = 1; num2 <= num11; num2 = (short)unchecked(num2 + 1)) {
						My.MyProject.Forms.frmSctInp.cboThicknessName.Items.Add (CFS.Thicknesses [num2].Name);
					}
					CFS.blnValidate = false;
					Section section2 = CFS.Sections [CFS.intSctNow];
					if (section2.Part [section2.iPart].ThicknessIndex == -1) {
						My.MyProject.Forms.frmSctInp.cboThicknessName.SelectedIndex = -1;
					} else {
						My.MyProject.Forms.frmSctInp.cboThicknessName.SelectedIndex = section2.Part [section2.iPart].ThicknessIndex - 1;
					}
					section2 = null;
					CFS.blnValidate = true;
				}
				CFSInterface.RegistryThickness (1);
			}
			if (blnTabChange [3]) {
				CFS.User = UserTmp;
				CFSInterface.RegistryHeading (1);
			}
			if (blnTabChange [4]) {
				CFS.intUserCombs = intUserCombsTmp;
				CFS.UserComb = new LoadCombination[Information.UBound (UserCombTmp) + 1];
				short num12 = (short)Information.UBound (CFS.UserComb);
				for (short num2 = 1; num2 <= num12; num2 = (short)unchecked(num2 + 1)) {
					CFS.UserComb [num2] = UserCombTmp [num2].Clone ();
				}
				CFSInterface.RegistryCombinations (1);
			}
			Close ();
			Cursor.Current = Cursors.Default;
		}
	}

	private void cboComb_GotFocus (object sender, EventArgs e)
	{
		AddComb ((System.Windows.Forms.ComboBox)sender);
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboComb_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r') {
			cboComb_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboComb_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			cboComb.SelectedIndex = checked(intComb - 1);
			CFS.blnValidate = true;
			e.Handled = true;
		}
	}

	private void cboComb_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboComb_DropDown (object sender, EventArgs e)
	{
		RenameComb ();
	}

	private void cboComb_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		RenameComb (blnSetListIndex: false);
		NewLateBinding.LateSetComplex (cboComb.Tag, null, "Text", new object[1] { Strings.Trim (cboComb.Text) }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			if (cboComb.SelectedIndex > -1) {
				intComb = (short)(cboComb.SelectedIndex + 1);
				if (intComb > Information.UBound (UserCombTmp)) {
					ref LoadCombination[] userCombTmp = ref UserCombTmp;
					userCombTmp = (LoadCombination[])Utils.CopyArray (userCombTmp, new LoadCombination[intComb + 1]);
					UserCombTmp [intComb].Initialize (string.Empty, 10);
					ref LoadCombination reference = ref UserCombTmp [intComb];
					reference.nLF = 8;
					reference.LF [1].iLdg = 0;
					reference.LF [2].iLdg = 1;
					reference.LF [3].iLdg = 2;
					reference.LF [4].iLdg = 3;
					reference.LF [5].iLdg = 4;
					reference.LF [6].iLdg = 5;
					reference.LF [7].iLdg = 6;
					reference.LF [8].iLdg = 7;
				}
			}
			UserCombTmp [intComb].Description = Strings.Trim (cboComb.Text);
			RefreshComb ();
		}
	}

	private void cboComb_Validating (object sender, CancelEventArgs e)
	{
		base.AcceptButton = cmdOK;
		base.CancelButton = cmdCancel;
		RenameComb ();
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
	}

	private void cboMaterial_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboMaterial_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is System.Windows.Forms.ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboMaterial_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboMaterial_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
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

	private void cboMaterial_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboMaterial_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((System.Windows.Forms.ComboBox)sender);
	}

	private void cboMaterial_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			if (sender == cboMaterial) {
				blnTabChange [tabOptions.SelectedIndex] = true;
				iMaterialTmp = Conversions.ToShort (NewLateBinding.LateGet (cboMaterial.SelectedItem, null, "ItemData", new object[0], null, null, null));
				MaterialTmp = CFS.Materials [iMaterialTmp].Clone ();
				RefreshMtl ();
			} else if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			}
		}
	}

	private void cboMaterial_Validating (object sender, CancelEventArgs e)
	{
		if (sender == cboMaterial) {
			if (Conversions.ToBoolean (Operators.AndObject (iMaterialTmp > 0, Operators.CompareObjectEqual (NewLateBinding.LateGet (cboMaterial.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)))) {
				cboMaterial.Items.RemoveAt (0);
			}
		} else if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			blnTabChange [tabOptions.SelectedIndex] = true;
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			MaterialType materialTmp = MaterialTmp;
			bool flag = true;
			if (flag == (sender == cboYield)) {
				materialTmp.Fy [1] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [2] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [3] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [4] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [5] = Conversions.ToSingle (Operators.MultiplyObject (0.6, NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null)));
			} else if (flag == (sender == cboTensile)) {
				materialTmp.Fu = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFS.Materials [0] = MaterialTmp.Clone ();
			materialTmp = null;
		} else {
			e.Cancel = true;
		}
	}

	private void cboSpec_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			blnTabChange [tabOptions.SelectedIndex] = true;
			UserCombTmp [intComb].Spec = Conversions.ToShort (NewLateBinding.LateGet (cboSpec.SelectedItem, null, "ItemData", new object[0], null, null, null));
			if (intComb > intUserCombsTmp) {
				intUserCombsTmp = intComb;
			}
			RefreshComb ();
		}
	}

	private void cboUnits_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		CFS.blnValidate = false;
		blnTabChange [tabOptions.SelectedIndex] = true;
		bool flag = true;
		checked {
			if (flag == (sender == cboUnitSystem)) {
				short num = Conversions.ToShort (NewLateBinding.LateGet (cboUnitSystem.SelectedItem, null, "ItemData", new object[0], null, null, null));
				if (num > 0) {
					iUnitSysTmp = (byte)num;
					short num2 = (short)Information.LBound (Units.UnitSys [num].UnitIndex);
					short num3 = (short)Information.UBound (Units.UnitSys [num].UnitIndex);
					for (short num4 = num2; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
						DefaultUnitIndexTmp [num4] = Units.UnitSys [num].UnitIndex [num4];
					}
					CFSInterface.SetSelectedItem (cboSectionUnit, Units.untLength [Units.UnitSys [num].UnitIndex [1]].Name);
					CFSInterface.SetSelectedItem (cboLengthUnit, Units.untLength [Units.UnitSys [num].UnitIndex [2]].Name);
					CFSInterface.SetSelectedItem (cboAngleUnit, Units.untAngle [Units.UnitSys [num].UnitIndex [3]].Name);
					CFSInterface.SetSelectedItem (cboForceUnit, Units.untForce [Units.UnitSys [num].UnitIndex [4]].Name);
					CFSInterface.SetSelectedItem (cboStressUnit, Units.untStress [Units.UnitSys [num].UnitIndex [5]].Name);
					CFSInterface.SetSelectedItem (cboMomentUnit, Units.untMoment [Units.UnitSys [num].UnitIndex [6]].Name);
				}
			} else if (flag == (sender == cboSectionUnit)) {
				DefaultUnitIndexTmp [1] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboLengthUnit)) {
				DefaultUnitIndexTmp [2] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboAngleUnit)) {
				DefaultUnitIndexTmp [3] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboForceUnit)) {
				DefaultUnitIndexTmp [4] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboStressUnit)) {
				DefaultUnitIndexTmp [5] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboMomentUnit)) {
				DefaultUnitIndexTmp [6] = Conversions.ToByte (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			}
			if (sender != cboUnitSystem) {
				MatchUnits ();
			}
			CFS.blnValidate = true;
		}
	}

	private void txtHeading_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void txtHeading_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r') {
			txtHeading_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			txtHeading_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			e.Handled = true;
		}
	}

	private void txtHeading_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void txtHeading_Validating (object sender, CancelEventArgs e)
	{
		base.AcceptButton = cmdOK;
		base.CancelButton = cmdCancel;
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) != 0) {
			blnTabChange [tabOptions.SelectedIndex] = true;
			string text = Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)));
			bool flag = true;
			if (flag == (sender == txtUser)) {
				UserTmp.Name = text;
			} else if (flag == (sender == txtCompany)) {
				UserTmp.Company = text;
			} else if (flag == (sender == txtAddress1)) {
				UserTmp.Address1 = text;
			} else if (flag == (sender == txtAddress2)) {
				UserTmp.Address2 = text;
			} else if (flag == (sender == txtEmail)) {
				UserTmp.Email = text;
			} else if (flag == (sender == txtPhone)) {
				UserTmp.Phone = text;
			} else if (flag == (sender == txtFax)) {
				UserTmp.Fax = text;
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { text }, null, null);
			CFS.blnValidate = true;
		}
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		CFSInterface.SetSelection ((Control)sender, blnNumeric: false);
	}

	private void grdThickness_CellChanging (object Sender, Grid.CellChangingEventArgs e)
	{
		if (!blnCodeChange) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void grdThickness_CellChange (object Sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditThickness.Tag;
		switch (e.Col) {
		case 1:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0.001f }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1f }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 3:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 10f }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEditThickness.Text = grdThickness.Cell (e.Row, e.Col).Text;
		checked {
			if (CFSInterface.Validate (txtEditThickness, blnShowUnit: false)) {
				blnTabChange [tabOptions.SelectedIndex] = true;
				byte b = (byte)Information.UBound (ThicknessTmp);
				if (e.Row > b) {
					if (b > 254) {
						Interaction.MsgBox ("Limit " + Conversions.ToString (unchecked((int)b) - 1) + " thicknesses.", MsgBoxStyle.Information);
					}
					b = (byte)(unchecked((int)b) + 1);
					ref Thickness[] thicknessTmp = ref ThicknessTmp;
					thicknessTmp = (Thickness[])Utils.CopyArray (thicknessTmp, new Thickness[unchecked((int)b) + 1]);
					ThicknessTmp [b].Thickness = 0.001f;
					ThicknessTmp [b].DefRad = 0f;
				}
				ref Thickness reference = ref ThicknessTmp [e.Row];
				switch (e.Col) {
				case 1:
					NewLateBinding.LateSetComplex (txtEditThickness.Tag, null, "Text", new object[1] { Strings.Left (Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (txtEditThickness.Tag, null, "Text", new object[0], null, null, null))), 12) }, null, null, OptimisticSet: false, RValueBase: true);
					reference.Name = Conversions.ToString (NewLateBinding.LateGet (txtEditThickness.Tag, null, "Text", new object[0], null, null, null));
					break;
				case 2:
					reference.Thickness = Conversions.ToSingle (NewLateBinding.LateGet (txtEditThickness.Tag, null, "Value", new object[0], null, null, null));
					break;
				case 3:
					reference.DefRad = Conversions.ToSingle (NewLateBinding.LateGet (txtEditThickness.Tag, null, "Value", new object[0], null, null, null));
					break;
				}
				grdThickness.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditThickness.Tag, null, "Text", new object[0], null, null, null));
				if (e.Row == grdThickness.Rows - 1) {
					RefreshThickness ();
				}
			} else {
				string text = string.Empty;
				switch (e.Col) {
				case 1:
					text = ThicknessTmp [e.Row].Name;
					break;
				case 2:
					text = Units.DisplayStress (ThicknessTmp [e.Row].Thickness, 0, blnShowUnit: false, "", 0, 0);
					break;
				case 3:
					text = Units.DisplayNone (ThicknessTmp [e.Row].DefRad, "", 0, 0);
					break;
				}
				grdThickness.Cell (e.Row, e.Col).Text = text;
			}
			blnCodeChange = false;
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		}
	}

	private void grdThickness_KeyDown (object Sender, KeyEventArgs e)
	{
		checked {
			if (!grdThickness.EditorVisible) {
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
				if (unchecked(e.KeyCode == Keys.Delete && b == 0)) {
					DeleteThickness ((byte)grdThickness.ActiveCell.Row);
					e.Handled = true;
				}
			}
		}
	}

	private void grdThickness_LeaveCell (object Sender, Grid.LeaveCellEventArgs e)
	{
		if (!blnCodeChange) {
			blnCodeChange = true;
			if (e.NewRow != e.Row) {
				grdThickness.Cell (e.Row, 0).Text = string.Empty;
				grdThickness.Cell (e.NewRow, 0).Text = ">>";
				blnTabChange [tabOptions.SelectedIndex] = true;
			}
			blnCodeChange = false;
		}
	}

	private void grdCombs_CellChanging (object sender, Grid.CellChangingEventArgs e)
	{
		if (!blnCodeChange) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void grdCombs_CellChange (object Sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		blnCodeChange = true;
		txtEditComb.Text = grdCombs.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEditComb, blnShowUnit: false)) {
			blnTabChange [tabOptions.SelectedIndex] = true;
			UserCombTmp [intComb].LF [e.Row].fLdg = Conversions.ToSingle (NewLateBinding.LateGet (txtEditComb.Tag, null, "Value", new object[0], null, null, null));
			grdCombs.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditComb.Tag, null, "Text", new object[0], null, null, null));
			if (intComb > intUserCombsTmp) {
				intUserCombsTmp = intComb;
			}
			RefreshComb ();
		} else {
			grdCombs.Cell (e.Row, e.Col).Text = Units.FormatNum (UserCombTmp [intComb].LF [e.Row].fLdg);
		}
		blnCodeChange = false;
		base.AcceptButton = cmdOK;
		base.CancelButton = cmdCancel;
	}

	private void grdCombs_SelChange (object Sender, Grid.SelChangeEventArgs e)
	{
		if (CFS.blnValidate) {
			ref GridState lFGrid = ref UserCombTmp [intComb].LFGrid;
			checked {
				lFGrid.TopRow = (byte)grdCombs.TopRow;
				lFGrid.LeftCol = (byte)grdCombs.LeftCol;
				lFGrid.ColStart = (byte)grdCombs.Selection.FirstCol;
				lFGrid.ColEnd = (byte)grdCombs.Selection.LastCol;
				if (unchecked((uint)lFGrid.ColStart > (uint)lFGrid.ColEnd)) {
					CFS.Swap (ref lFGrid.ColStart, ref lFGrid.ColEnd);
				}
				lFGrid.Corner = 0;
				if (grdCombs.ActiveCell.Col > grdCombs.Selection.FirstCol) {
					lFGrid.Corner = (byte)(lFGrid.Corner | 1);
				}
				if (grdCombs.ActiveCell.Row > grdCombs.Selection.FirstRow) {
					lFGrid.Corner = (byte)(lFGrid.Corner | 2);
				}
				lFGrid.RowStart = (byte)grdCombs.Selection.FirstRow;
				lFGrid.RowEnd = (byte)grdCombs.Selection.LastRow;
			}
			if ((uint)lFGrid.RowStart > (uint)lFGrid.RowEnd) {
				CFS.Swap (ref lFGrid.RowStart, ref lFGrid.RowEnd);
			}
		}
	}
}
