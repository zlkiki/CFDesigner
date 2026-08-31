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
public class frmMaterial : Form
{
	private IContainer components;

	private bool blnTabMaterial;

	private short intCancel;

	private short iMaterialTmp;

	private MaterialType MaterialPrev;

	private MaterialType MaterialTmp;

	private MaterialType MaterialDefTmp;

	private bool blnCodeChange;

	internal virtual TabControl tabMaterial {
		[CompilerGenerated]
		get {
			return _tabMaterial;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tabMaterial_SelectedIndexChanged;
			TabControl tabControl = _tabMaterial;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged -= value2;
			}
			_tabMaterial = value;
			tabControl = _tabMaterial;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tabCarbon")]
	internal virtual TabPage tabCarbon {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboTensileMax {
		[CompilerGenerated]
		get {
			return _cboTensileMax;
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
			System.Windows.Forms.ComboBox comboBox = _cboTensileMax;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboTensileMax = value;
			comboBox = _cboTensileMax;
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

	[field: AccessedThroughProperty ("lblTensileMax")]
	internal virtual Label lblTensileMax {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboTensileDefault {
		[CompilerGenerated]
		get {
			return _cboTensileDefault;
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
			System.Windows.Forms.ComboBox comboBox = _cboTensileDefault;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboTensileDefault = value;
			comboBox = _cboTensileDefault;
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

	[field: AccessedThroughProperty ("lblTensileDefault")]
	internal virtual Label lblTensileDefault {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboTensileMin {
		[CompilerGenerated]
		get {
			return _cboTensileMin;
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
			System.Windows.Forms.ComboBox comboBox = _cboTensileMin;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboTensileMin = value;
			comboBox = _cboTensileMin;
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

	[field: AccessedThroughProperty ("lblTensileMin")]
	internal virtual Label lblTensileMin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboYieldDefault {
		[CompilerGenerated]
		get {
			return _cboYieldDefault;
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
			System.Windows.Forms.ComboBox comboBox = _cboYieldDefault;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboYieldDefault = value;
			comboBox = _cboYieldDefault;
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

	[field: AccessedThroughProperty ("lblYieldDefault")]
	internal virtual Label lblYieldDefault {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboYieldMin {
		[CompilerGenerated]
		get {
			return _cboYieldMin;
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
			System.Windows.Forms.ComboBox comboBox = _cboYieldMin;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboYieldMin = value;
			comboBox = _cboYieldMin;
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

	[field: AccessedThroughProperty ("lblYieldMin")]
	internal virtual Label lblYieldMin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboModulus {
		[CompilerGenerated]
		get {
			return _cboModulus;
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
			System.Windows.Forms.ComboBox comboBox = _cboModulus;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboModulus = value;
			comboBox = _cboModulus;
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

	[field: AccessedThroughProperty ("lblModulus")]
	internal virtual Label lblModulus {
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
			EventHandler value2 = cboMaterial_GotFocus;
			KeyPressEventHandler value3 = cboMaterial_KeyPress;
			EventHandler value4 = cboMaterial_SelectedIndexChanged;
			EventHandler value5 = cboMaterial_TextChanged;
			CancelEventHandler value6 = cboMaterial_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.SelectedIndexChanged -= value4;
				comboBox.TextChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboMaterial = value;
			comboBox = _cboMaterial;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.SelectedIndexChanged += value4;
				comboBox.TextChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMaterial")]
	internal virtual Label lblMaterial {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tabStainless")]
	internal virtual TabPage tabStainless {
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
			EventHandler value2 = cbo_GotFocus;
			KeyPressEventHandler value3 = cbo_KeyPress;
			EventHandler value4 = cbo_TextChanged;
			EventHandler value5 = cbo_DropDown;
			EventHandler value6 = cbo_SelectedIndexChanged;
			CancelEventHandler value7 = cbo_Validating;
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

	internal virtual System.Windows.Forms.ComboBox cboMaterialSS {
		[CompilerGenerated]
		get {
			return _cboMaterialSS;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboMaterial_GotFocus;
			KeyPressEventHandler value3 = cboMaterial_KeyPress;
			EventHandler value4 = cboMaterial_SelectedIndexChanged;
			EventHandler value5 = cboMaterial_TextChanged;
			CancelEventHandler value6 = cboMaterial_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboMaterialSS;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.SelectedIndexChanged -= value4;
				comboBox.TextChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboMaterialSS = value;
			comboBox = _cboMaterialSS;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.SelectedIndexChanged += value4;
				comboBox.TextChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	[field: AccessedThroughProperty ("lblMaterialSS")]
	internal virtual Label lblMaterialSS {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdDefault {
		[CompilerGenerated]
		get {
			return _cmdDefault;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdDefault_Click;
			Button button = _cmdDefault;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdDefault = value;
			button = _cmdDefault;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdCustomize {
		[CompilerGenerated]
		get {
			return _cmdCustomize;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCustomize_Click;
			Button button = _cmdCustomize;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCustomize = value;
			button = _cmdCustomize;
			if (button != null) {
				button.Click += value2;
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

	internal virtual Grid grdMaterial {
		[CompilerGenerated]
		get {
			return _grdMaterial;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangingEventHandler obj = grdMaterial_CellChanging;
			Grid.CellChangeEventHandler obj2 = grdMaterial_CellChange;
			Grid grid = _grdMaterial;
			if (grid != null) {
				grid.CellChanging -= obj;
				grid.CellChange -= obj2;
			}
			_grdMaterial = value;
			grid = _grdMaterial;
			if (grid != null) {
				grid.CellChanging += obj;
				grid.CellChange += obj2;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEdit")]
	internal virtual TextBox txtEdit {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtElong {
		[CompilerGenerated]
		get {
			return _txtElong;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtElong;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtElong = value;
			textBox = _txtElong;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblElong")]
	internal virtual Label lblElong {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblThkMin")]
	internal virtual Label lblThkMin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtElongThin {
		[CompilerGenerated]
		get {
			return _txtElongThin;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txt_GotFocus;
			KeyPressEventHandler value3 = txt_KeyPress;
			EventHandler value4 = txt_TextChanged;
			CancelEventHandler value5 = txt_Validating;
			TextBox textBox = _txtElongThin;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtElongThin = value;
			textBox = _txtElongThin;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblElongThin")]
	internal virtual Label lblElongThin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboThkMin {
		[CompilerGenerated]
		get {
			return _cboThkMin;
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
			System.Windows.Forms.ComboBox comboBox = _cboThkMin;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboThkMin = value;
			comboBox = _cboThkMin;
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

	internal virtual System.Windows.Forms.ComboBox cboSSFamily {
		[CompilerGenerated]
		get {
			return _cboSSFamily;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSSFamily_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboSSFamily;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSSFamily = value;
			comboBox = _cboSSFamily;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblSSFamily")]
	internal virtual Label lblSSFamily {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmMaterial ()
	{
		base.Load += frmMaterial_Load;
		base.KeyDown += frmMaterial_KeyDown;
		base.HelpButtonClicked += frmMaterial_HelpButtonClicked;
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
		this.tabMaterial = new System.Windows.Forms.TabControl ();
		this.tabCarbon = new System.Windows.Forms.TabPage ();
		this.cboThkMin = new System.Windows.Forms.ComboBox ();
		this.lblThkMin = new System.Windows.Forms.Label ();
		this.txtElongThin = new System.Windows.Forms.TextBox ();
		this.lblElongThin = new System.Windows.Forms.Label ();
		this.txtElong = new System.Windows.Forms.TextBox ();
		this.lblElong = new System.Windows.Forms.Label ();
		this.cboTensileMax = new System.Windows.Forms.ComboBox ();
		this.lblTensileMax = new System.Windows.Forms.Label ();
		this.cboTensileDefault = new System.Windows.Forms.ComboBox ();
		this.lblTensileDefault = new System.Windows.Forms.Label ();
		this.cboTensileMin = new System.Windows.Forms.ComboBox ();
		this.lblTensileMin = new System.Windows.Forms.Label ();
		this.cboYieldDefault = new System.Windows.Forms.ComboBox ();
		this.lblYieldDefault = new System.Windows.Forms.Label ();
		this.cboYieldMin = new System.Windows.Forms.ComboBox ();
		this.lblYieldMin = new System.Windows.Forms.Label ();
		this.cboModulus = new System.Windows.Forms.ComboBox ();
		this.lblModulus = new System.Windows.Forms.Label ();
		this.cboMaterial = new System.Windows.Forms.ComboBox ();
		this.lblMaterial = new System.Windows.Forms.Label ();
		this.tabStainless = new System.Windows.Forms.TabPage ();
		this.txtEdit = new System.Windows.Forms.TextBox ();
		this.grdMaterial = new FlexCell.Grid ();
		this.cboTensile = new System.Windows.Forms.ComboBox ();
		this.lblTensile = new System.Windows.Forms.Label ();
		this.cboMaterialSS = new System.Windows.Forms.ComboBox ();
		this.lblMaterialSS = new System.Windows.Forms.Label ();
		this.cmdDefault = new System.Windows.Forms.Button ();
		this.cmdCustomize = new System.Windows.Forms.Button ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblSSFamily = new System.Windows.Forms.Label ();
		this.cboSSFamily = new System.Windows.Forms.ComboBox ();
		this.tabMaterial.SuspendLayout ();
		this.tabCarbon.SuspendLayout ();
		this.tabStainless.SuspendLayout ();
		base.SuspendLayout ();
		this.tabMaterial.Controls.Add (this.tabCarbon);
		this.tabMaterial.Controls.Add (this.tabStainless);
		this.tabMaterial.Location = new System.Drawing.Point (6, 5);
		this.tabMaterial.Name = "tabMaterial";
		this.tabMaterial.SelectedIndex = 0;
		this.tabMaterial.Size = new System.Drawing.Size (473, 308);
		this.tabMaterial.TabIndex = 0;
		this.tabCarbon.Controls.Add (this.cboThkMin);
		this.tabCarbon.Controls.Add (this.lblThkMin);
		this.tabCarbon.Controls.Add (this.txtElongThin);
		this.tabCarbon.Controls.Add (this.lblElongThin);
		this.tabCarbon.Controls.Add (this.txtElong);
		this.tabCarbon.Controls.Add (this.lblElong);
		this.tabCarbon.Controls.Add (this.cboTensileMax);
		this.tabCarbon.Controls.Add (this.lblTensileMax);
		this.tabCarbon.Controls.Add (this.cboTensileDefault);
		this.tabCarbon.Controls.Add (this.lblTensileDefault);
		this.tabCarbon.Controls.Add (this.cboTensileMin);
		this.tabCarbon.Controls.Add (this.lblTensileMin);
		this.tabCarbon.Controls.Add (this.cboYieldDefault);
		this.tabCarbon.Controls.Add (this.lblYieldDefault);
		this.tabCarbon.Controls.Add (this.cboYieldMin);
		this.tabCarbon.Controls.Add (this.lblYieldMin);
		this.tabCarbon.Controls.Add (this.cboModulus);
		this.tabCarbon.Controls.Add (this.lblModulus);
		this.tabCarbon.Controls.Add (this.cboMaterial);
		this.tabCarbon.Controls.Add (this.lblMaterial);
		this.tabCarbon.Location = new System.Drawing.Point (4, 22);
		this.tabCarbon.Name = "tabCarbon";
		this.tabCarbon.Padding = new System.Windows.Forms.Padding (3);
		this.tabCarbon.Size = new System.Drawing.Size (465, 282);
		this.tabCarbon.TabIndex = 0;
		this.tabCarbon.Tag = "custom-material-cs.htm";
		this.tabCarbon.Text = "Carbon Steel";
		this.tabCarbon.UseVisualStyleBackColor = true;
		this.cboThkMin.FormattingEnabled = true;
		this.cboThkMin.Location = new System.Drawing.Point (235, 226);
		this.cboThkMin.Name = "cboThkMin";
		this.cboThkMin.Size = new System.Drawing.Size (158, 21);
		this.cboThkMin.TabIndex = 18;
		this.lblThkMin.Location = new System.Drawing.Point (41, 229);
		this.lblThkMin.Name = "lblThkMin";
		this.lblThkMin.Size = new System.Drawing.Size (188, 18);
		this.lblThkMin.TabIndex = 17;
		this.lblThkMin.Text = "Minimum thickness for this elongation";
		this.txtElongThin.Location = new System.Drawing.Point (235, 253);
		this.txtElongThin.Name = "txtElongThin";
		this.txtElongThin.Size = new System.Drawing.Size (158, 20);
		this.txtElongThin.TabIndex = 20;
		this.lblElongThin.Location = new System.Drawing.Point (41, 256);
		this.lblElongThin.Name = "lblElongThin";
		this.lblElongThin.Size = new System.Drawing.Size (188, 18);
		this.lblElongThin.TabIndex = 19;
		this.lblElongThin.Text = "Min elongation for thinner steel (%)";
		this.txtElong.Location = new System.Drawing.Point (235, 200);
		this.txtElong.Name = "txtElong";
		this.txtElong.Size = new System.Drawing.Size (158, 20);
		this.txtElong.TabIndex = 16;
		this.lblElong.Location = new System.Drawing.Point (41, 203);
		this.lblElong.Name = "lblElong";
		this.lblElong.Size = new System.Drawing.Size (188, 18);
		this.lblElong.TabIndex = 15;
		this.lblElong.Text = "Minimum elongation in 2 inches (%)";
		this.cboTensileMax.FormattingEnabled = true;
		this.cboTensileMax.Location = new System.Drawing.Point (235, 173);
		this.cboTensileMax.Name = "cboTensileMax";
		this.cboTensileMax.Size = new System.Drawing.Size (158, 21);
		this.cboTensileMax.TabIndex = 14;
		this.lblTensileMax.Location = new System.Drawing.Point (41, 176);
		this.lblTensileMax.Name = "lblTensileMax";
		this.lblTensileMax.Size = new System.Drawing.Size (188, 18);
		this.lblTensileMax.TabIndex = 13;
		this.lblTensileMax.Text = "Maximum Tensile Strength, Fu";
		this.cboTensileDefault.FormattingEnabled = true;
		this.cboTensileDefault.Location = new System.Drawing.Point (235, 146);
		this.cboTensileDefault.Name = "cboTensileDefault";
		this.cboTensileDefault.Size = new System.Drawing.Size (158, 21);
		this.cboTensileDefault.TabIndex = 12;
		this.lblTensileDefault.Location = new System.Drawing.Point (41, 149);
		this.lblTensileDefault.Name = "lblTensileDefault";
		this.lblTensileDefault.Size = new System.Drawing.Size (188, 18);
		this.lblTensileDefault.TabIndex = 11;
		this.lblTensileDefault.Text = "Default Tensile Strength, Fu";
		this.cboTensileMin.FormattingEnabled = true;
		this.cboTensileMin.Location = new System.Drawing.Point (235, 119);
		this.cboTensileMin.Name = "cboTensileMin";
		this.cboTensileMin.Size = new System.Drawing.Size (158, 21);
		this.cboTensileMin.TabIndex = 10;
		this.lblTensileMin.Location = new System.Drawing.Point (41, 122);
		this.lblTensileMin.Name = "lblTensileMin";
		this.lblTensileMin.Size = new System.Drawing.Size (188, 18);
		this.lblTensileMin.TabIndex = 9;
		this.lblTensileMin.Text = "Minimum Tensile Strength, Fu";
		this.cboYieldDefault.FormattingEnabled = true;
		this.cboYieldDefault.Location = new System.Drawing.Point (235, 92);
		this.cboYieldDefault.Name = "cboYieldDefault";
		this.cboYieldDefault.Size = new System.Drawing.Size (158, 21);
		this.cboYieldDefault.TabIndex = 8;
		this.lblYieldDefault.Location = new System.Drawing.Point (41, 95);
		this.lblYieldDefault.Name = "lblYieldDefault";
		this.lblYieldDefault.Size = new System.Drawing.Size (188, 18);
		this.lblYieldDefault.TabIndex = 7;
		this.lblYieldDefault.Text = "Default Yield Strength, Fy";
		this.cboYieldMin.FormattingEnabled = true;
		this.cboYieldMin.Location = new System.Drawing.Point (235, 65);
		this.cboYieldMin.Name = "cboYieldMin";
		this.cboYieldMin.Size = new System.Drawing.Size (158, 21);
		this.cboYieldMin.TabIndex = 6;
		this.lblYieldMin.Location = new System.Drawing.Point (41, 68);
		this.lblYieldMin.Name = "lblYieldMin";
		this.lblYieldMin.Size = new System.Drawing.Size (188, 18);
		this.lblYieldMin.TabIndex = 5;
		this.lblYieldMin.Text = "Minimum Yield Strength, Fy";
		this.cboModulus.FormattingEnabled = true;
		this.cboModulus.Location = new System.Drawing.Point (235, 38);
		this.cboModulus.Name = "cboModulus";
		this.cboModulus.Size = new System.Drawing.Size (158, 21);
		this.cboModulus.TabIndex = 4;
		this.lblModulus.Location = new System.Drawing.Point (41, 41);
		this.lblModulus.Name = "lblModulus";
		this.lblModulus.Size = new System.Drawing.Size (188, 18);
		this.lblModulus.TabIndex = 3;
		this.lblModulus.Text = "Modulus of Elasticity, E";
		this.cboMaterial.FormattingEnabled = true;
		this.cboMaterial.Location = new System.Drawing.Point (150, 11);
		this.cboMaterial.MaxLength = 24;
		this.cboMaterial.Name = "cboMaterial";
		this.cboMaterial.Size = new System.Drawing.Size (243, 21);
		this.cboMaterial.TabIndex = 1;
		this.lblMaterial.Location = new System.Drawing.Point (41, 14);
		this.lblMaterial.Name = "lblMaterial";
		this.lblMaterial.Size = new System.Drawing.Size (103, 18);
		this.lblMaterial.TabIndex = 0;
		this.lblMaterial.Text = "Material Type";
		this.tabStainless.Controls.Add (this.cboSSFamily);
		this.tabStainless.Controls.Add (this.lblSSFamily);
		this.tabStainless.Controls.Add (this.txtEdit);
		this.tabStainless.Controls.Add (this.grdMaterial);
		this.tabStainless.Controls.Add (this.cboTensile);
		this.tabStainless.Controls.Add (this.lblTensile);
		this.tabStainless.Controls.Add (this.cboMaterialSS);
		this.tabStainless.Controls.Add (this.lblMaterialSS);
		this.tabStainless.Location = new System.Drawing.Point (4, 22);
		this.tabStainless.Name = "tabStainless";
		this.tabStainless.Padding = new System.Windows.Forms.Padding (3);
		this.tabStainless.Size = new System.Drawing.Size (465, 282);
		this.tabStainless.TabIndex = 1;
		this.tabStainless.Tag = "custom-material-ss.htm";
		this.tabStainless.Text = "Stainless Steel";
		this.tabStainless.UseVisualStyleBackColor = true;
		this.txtEdit.Location = new System.Drawing.Point (17, 221);
		this.txtEdit.Name = "txtEdit";
		this.txtEdit.Size = new System.Drawing.Size (93, 20);
		this.txtEdit.TabIndex = 8;
		this.txtEdit.Visible = false;
		this.grdMaterial.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdMaterial.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdMaterial.BoldFixedCell = false;
		this.grdMaterial.Cols = 4;
		this.grdMaterial.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdMaterial.Location = new System.Drawing.Point (17, 65);
		this.grdMaterial.MultiSelect = false;
		this.grdMaterial.Name = "grdMaterial";
		this.grdMaterial.Rows = 6;
		this.grdMaterial.Size = new System.Drawing.Size (427, 150);
		this.grdMaterial.TabIndex = 5;
		this.cboTensile.FormattingEnabled = true;
		this.cboTensile.Location = new System.Drawing.Point (235, 241);
		this.cboTensile.Name = "cboTensile";
		this.cboTensile.Size = new System.Drawing.Size (158, 21);
		this.cboTensile.TabIndex = 7;
		this.lblTensile.Location = new System.Drawing.Point (41, 244);
		this.lblTensile.Name = "lblTensile";
		this.lblTensile.Size = new System.Drawing.Size (188, 18);
		this.lblTensile.TabIndex = 6;
		this.lblTensile.Text = "Tensile Strength, Fu";
		this.cboMaterialSS.FormattingEnabled = true;
		this.cboMaterialSS.Location = new System.Drawing.Point (150, 11);
		this.cboMaterialSS.MaxLength = 24;
		this.cboMaterialSS.Name = "cboMaterialSS";
		this.cboMaterialSS.Size = new System.Drawing.Size (243, 21);
		this.cboMaterialSS.TabIndex = 2;
		this.lblMaterialSS.Location = new System.Drawing.Point (41, 14);
		this.lblMaterialSS.Name = "lblMaterialSS";
		this.lblMaterialSS.Size = new System.Drawing.Size (103, 18);
		this.lblMaterialSS.TabIndex = 1;
		this.lblMaterialSS.Text = "Material Type";
		this.cmdDefault.Location = new System.Drawing.Point (12, 320);
		this.cmdDefault.Name = "cmdDefault";
		this.cmdDefault.Size = new System.Drawing.Size (75, 25);
		this.cmdDefault.TabIndex = 1;
		this.cmdDefault.Text = "&Default";
		this.cmdDefault.UseVisualStyleBackColor = true;
		this.cmdCustomize.Location = new System.Drawing.Point (93, 320);
		this.cmdCustomize.Name = "cmdCustomize";
		this.cmdCustomize.Size = new System.Drawing.Size (75, 25);
		this.cmdCustomize.TabIndex = 2;
		this.cmdCustomize.Text = "C&ustomize";
		this.cmdCustomize.UseVisualStyleBackColor = true;
		this.cmdOK.Location = new System.Drawing.Point (319, 320);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 3;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (400, 320);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 4;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblSSFamily.Location = new System.Drawing.Point (41, 41);
		this.lblSSFamily.Name = "lblSSFamily";
		this.lblSSFamily.Size = new System.Drawing.Size (103, 18);
		this.lblSSFamily.TabIndex = 3;
		this.lblSSFamily.Text = "Alloy Family";
		this.cboSSFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSSFamily.FormattingEnabled = true;
		this.cboSSFamily.Location = new System.Drawing.Point (150, 38);
		this.cboSSFamily.MaxLength = 24;
		this.cboSSFamily.Name = "cboSSFamily";
		this.cboSSFamily.Size = new System.Drawing.Size (243, 21);
		this.cboSSFamily.TabIndex = 4;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (487, 357);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.cmdCustomize);
		base.Controls.Add (this.cmdDefault);
		base.Controls.Add (this.tabMaterial);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmMaterial";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Custom Material Properties";
		this.tabMaterial.ResumeLayout (false);
		this.tabCarbon.ResumeLayout (false);
		this.tabCarbon.PerformLayout ();
		this.tabStainless.ResumeLayout (false);
		this.tabStainless.PerformLayout ();
		base.ResumeLayout (false);
	}

	private void RefreshMtl ()
	{
		checked {
			short num = (short)tabMaterial.SelectedIndex;
			System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)Interaction.IIf (num == 0, cboMaterial, cboMaterialSS);
			CFS.blnValidate = false;
			MaterialType materialTmp = MaterialTmp;
			if (comboBox.SelectedIndex == -1) {
				switch (num) {
				case 0:
					lblModulus.Enabled = false;
					cboModulus.Enabled = false;
					cboModulus.Text = string.Empty;
					lblYieldMin.Enabled = false;
					cboYieldMin.Enabled = false;
					cboYieldMin.Text = string.Empty;
					lblYieldDefault.Enabled = false;
					cboYieldDefault.Enabled = false;
					cboYieldDefault.Text = string.Empty;
					lblTensileMin.Enabled = false;
					cboTensileMin.Enabled = false;
					cboTensileMin.Text = string.Empty;
					lblTensileDefault.Enabled = false;
					cboTensileDefault.Enabled = false;
					cboTensileDefault.Text = string.Empty;
					lblTensileMax.Enabled = false;
					cboTensileMax.Enabled = false;
					cboTensileMax.Text = string.Empty;
					lblElong.Enabled = false;
					txtElong.Enabled = false;
					txtElong.Text = string.Empty;
					lblThkMin.Enabled = false;
					cboThkMin.Enabled = false;
					cboThkMin.Text = string.Empty;
					lblElongThin.Enabled = false;
					txtElongThin.Enabled = false;
					txtElongThin.Text = string.Empty;
					break;
				case 1: {
					blnCodeChange = true;
					Grid grid = grdMaterial;
					grid.Range (1, 1, 5, 3).ClearText ();
					grid.Range (1, 1, 5, 3).BackColor = grid.Cell (0, 0).BackColor;
					grid.Range (1, 1, 1, 1).SelectCells ();
					grid.Enabled = false;
					grid = null;
					blnCodeChange = false;
					lblSSFamily.Enabled = false;
					cboSSFamily.Enabled = false;
					cboSSFamily.SelectedIndex = -1;
					lblTensile.Enabled = false;
					cboTensile.Enabled = false;
					cboTensile.Text = string.Empty;
					break;
				}
				}
				cmdCustomize.Enabled = false;
			} else {
				if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectEqual (NewLateBinding.LateGet (comboBox.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false), iMaterialTmp == 0))) {
					switch (num) {
					case 0:
						lblModulus.Enabled = true;
						cboModulus.Enabled = true;
						lblYieldMin.Enabled = true;
						cboYieldMin.Enabled = true;
						lblYieldDefault.Enabled = true;
						cboYieldDefault.Enabled = true;
						lblTensileMin.Enabled = true;
						cboTensileMin.Enabled = true;
						lblTensileDefault.Enabled = true;
						cboTensileDefault.Enabled = true;
						lblTensileMax.Enabled = true;
						cboTensileMax.Enabled = true;
						lblElong.Enabled = true;
						txtElong.Enabled = true;
						lblThkMin.Enabled = true;
						cboThkMin.Enabled = true;
						lblElongThin.Enabled = true;
						txtElongThin.Enabled = true;
						break;
					case 1:
						grdMaterial.Enabled = true;
						grdMaterial.Range (1, 1, 5, 3).ClearBackColor ();
						lblSSFamily.Enabled = true;
						cboSSFamily.Enabled = true;
						lblTensile.Enabled = true;
						cboTensile.Enabled = true;
						break;
					}
					cmdCustomize.Enabled = false;
				} else {
					switch (num) {
					case 0:
						lblModulus.Enabled = false;
						cboModulus.Enabled = false;
						lblYieldMin.Enabled = false;
						cboYieldMin.Enabled = false;
						lblYieldDefault.Enabled = true;
						cboYieldDefault.Enabled = true;
						lblTensileMin.Enabled = false;
						cboTensileMin.Enabled = false;
						lblTensileDefault.Enabled = true;
						cboTensileDefault.Enabled = true;
						lblTensileMax.Enabled = false;
						cboTensileMax.Enabled = false;
						lblElong.Enabled = false;
						txtElong.Enabled = false;
						lblThkMin.Enabled = false;
						cboThkMin.Enabled = false;
						lblElongThin.Enabled = false;
						txtElongThin.Enabled = false;
						break;
					case 1: {
						Grid grid2 = grdMaterial;
						grid2.Range (1, 1, 5, 3).BackColor = grid2.Cell (0, 0).BackColor;
						grid2.Range (1, 1, 1, 1).SelectCells ();
						grid2.Enabled = false;
						grid2 = null;
						lblSSFamily.Enabled = false;
						cboSSFamily.Enabled = false;
						lblTensile.Enabled = false;
						cboTensile.Enabled = false;
						break;
					}
					}
					cmdCustomize.Enabled = true;
				}
				switch (num) {
				case 0:
					cboModulus.Text = Units.DisplayStress (materialTmp.Eo [2], 0, blnShowUnit: true, "", 0, 0);
					cboYieldMin.Text = Units.DisplayStress (materialTmp.FyMin, 0, blnShowUnit: true, "", 0, 0);
					cboYieldDefault.Text = Units.DisplayStress (materialTmp.Fy [2], 0, blnShowUnit: true, "", 0, 0);
					cboTensileMin.Text = Units.DisplayStress (materialTmp.FuMin, 0, blnShowUnit: true, "", 0, 0);
					cboTensileDefault.Text = Units.DisplayStress (materialTmp.Fu, 0, blnShowUnit: true, "", 0, 0);
					cboTensileMax.Text = Units.DisplayStress (materialTmp.FuMax, 0, blnShowUnit: true, "", 0, 0);
					txtElong.Text = Units.DisplayNone (materialTmp.Elong, "", 0, 0);
					cboThkMin.Text = Units.DisplayLen1 (materialTmp.ThkMin, 0, blnShowUnit: true, "", 0, 0);
					txtElongThin.Text = Units.DisplayNone (materialTmp.ElongThin, "", 0, 0);
					break;
				case 1: {
					blnCodeChange = true;
					int num2 = 1;
					do {
						grdMaterial.Cell (num2, 1).Text = Units.DisplayStress (materialTmp.Eo [num2], 0, blnShowUnit: false, "", 0, 0);
						grdMaterial.Cell (num2, 2).Text = Units.DisplayStress (materialTmp.Fy [num2], 0, blnShowUnit: false, "", 0, 0);
						grdMaterial.Cell (num2, 3).Text = Units.DisplayNone (materialTmp.N [num2], "", 0, 0);
						num2++;
					} while (num2 <= 5);
					if (MaterialTmp.IsAustenitic ()) {
						cboSSFamily.SelectedIndex = 0;
					}
					if (MaterialTmp.IsFerritic ()) {
						cboSSFamily.SelectedIndex = 1;
					}
					if (MaterialTmp.IsDuplex ()) {
						cboSSFamily.SelectedIndex = 2;
					}
					blnCodeChange = false;
					cboTensile.Text = Units.DisplayStress (MaterialTmp.Fu, 0, blnShowUnit: true, "", 0, 0);
					break;
				}
				}
			}
			materialTmp = null;
			CFS.blnValidate = true;
		}
	}

	private void SetMaterial (short Index)
	{
		System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)Interaction.IIf (Index == 0, cboMaterial, cboMaterialSS);
		CFS.blnValidate = false;
		checked {
			if (iMaterialTmp == 0) {
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (comboBox.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
					NewLateBinding.LateSetComplex (comboBox.Items [0], null, "Text", new object[1] { Strings.Trim (MaterialTmp.Name) }, null, null, OptimisticSet: false, RValueBase: true);
				} else {
					comboBox.Items.Clear ();
					comboBox.Items.Add (new ListItem (Strings.Trim (MaterialTmp.Name), 0));
					switch (Index) {
					case 0: {
						int num2 = Information.UBound (CFS.Materials);
						for (int j = 1; j <= num2; j++) {
							if (CFS.Materials [j].IsCarbon ()) {
								comboBox.Items.Add (new ListItem (Strings.Trim (CFS.Materials [j].Name), j));
							}
						}
						break;
					}
					case 1: {
						int num = Information.UBound (CFS.Materials);
						for (int i = 1; i <= num; i++) {
							if (CFS.Materials [i].IsStainless ()) {
								comboBox.Items.Add (new ListItem (Strings.Trim (CFS.Materials [i].Name), i));
							}
						}
						break;
					}
					}
				}
				comboBox.SelectedIndex = 0;
				switch (Index) {
				case 0:
					if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterialSS.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
						cboMaterialSS.Items.RemoveAt (0);
					}
					break;
				case 1:
					if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterial.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
						cboMaterial.Items.RemoveAt (0);
					}
					break;
				}
			} else {
				int num3 = comboBox.Items.Count - 1;
				for (int k = 0; k <= num3; k++) {
					if (Operators.ConditionalCompareObjectEqual (iMaterialTmp, NewLateBinding.LateGet (comboBox.Items [k], null, "ItemData", new object[0], null, null, null), TextCompare: false)) {
						comboBox.SelectedIndex = k;
						break;
					}
				}
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterial.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
					cboMaterial.Items.RemoveAt (0);
				}
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterialSS.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
					cboMaterialSS.Items.RemoveAt (0);
				}
			}
			CFS.blnValidate = true;
			switch (Index) {
			case 0:
				cboMaterialSS.SelectedIndex = -1;
				break;
			case 1:
				cboMaterial.SelectedIndex = -1;
				break;
			}
			if (Index == tabMaterial.SelectedIndex) {
				RefreshMtl ();
			} else {
				tabMaterial.SelectedIndex = Index;
			}
		}
	}

	private void frmMaterial_Load (object sender, EventArgs e)
	{
		base.Tag = Conversions.ToString (Value: false);
		lblElong.Text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Minimum Elongation in ", Interaction.IIf (Units.DefaultUnitIndex [1] <= 2, "2 inches", "50 mm")), " (%)"));
		cboMaterial.Tag = new ControlData (byte.MaxValue);
		cboMaterialSS.Tag = new ControlData (byte.MaxValue);
		cboModulus.Tag = new ControlData (5, 1000f, 50000f);
		cboYieldMin.Tag = new ControlData (5, 1f, 200f);
		cboYieldDefault.Tag = new ControlData (5, 1f, 200f);
		cboTensileMin.Tag = new ControlData (5, 1f, 500f);
		cboTensileDefault.Tag = new ControlData (5, 1f, 500f);
		cboTensileMax.Tag = new ControlData (5, 1f, 500f);
		cboTensile.Tag = new ControlData (5, 1f, 500f);
		txtElong.Tag = new ControlData (0, 0f, 100f);
		cboThkMin.Tag = new ControlData (1, 0f, 1f);
		txtElongThin.Tag = new ControlData (0, 0f, 100f);
		txtEdit.Tag = new ControlData (5);
		blnCodeChange = true;
		Grid grid = grdMaterial;
		grid.Column (0).Alignment = AlignmentEnum.LeftCenter;
		grid.Column (1).Alignment = AlignmentEnum.RightCenter;
		grid.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid.Column (3).Alignment = AlignmentEnum.RightCenter;
		grid.Cell (0, 1).Text = "Modulus space";
		grid.Column (1).AutoFit ();
		grid.Cell (0, 2).Text = "Yield Strength";
		grid.Column (2).AutoFit ();
		grid.Cell (0, 3).Text = "Strain-Hardening";
		grid.Column (3).AutoFit ();
		grid.Range (0, 1, 0, 3).WrapText = true;
		grid.Range (0, 1, 0, 3).Alignment = AlignmentEnum.CenterTop;
		grid.Cell (0, 1).Text = "Modulus\nE (" + Units.untStress [Units.DefaultUnitIndex [5]].Name + ")";
		grid.Cell (0, 2).Text = "Yield Strength\nFy (" + Units.untStress [Units.DefaultUnitIndex [5]].Name + ")";
		grid.Cell (0, 3).Text = "Strain-Hardening\nCoefficient, n";
		grid.Row (0).AutoFit ();
		grid.Cell (0, 0).Text = "Material Properties";
		grid.Cell (1, 0).Text = "Longitudinal Tension";
		grid.Cell (2, 0).Text = "Longitudinal Compression";
		grid.Cell (3, 0).Text = "Transverse Tension";
		grid.Cell (4, 0).Text = "Transverse Compression";
		grid.Cell (5, 0).Text = "Shear";
		grid.Column (0).AutoFit ();
		grid.Range (1, 1, 1, 1).SelectCells ();
		_ = null;
		blnCodeChange = false;
		blnTabMaterial = true;
		if (CFS.blnOptionsLoaded) {
			iMaterialTmp = Conversions.ToShort (NewLateBinding.LateGet (My.MyProject.Forms.frmOptions.cboMaterial.Items [My.MyProject.Forms.frmOptions.cboMaterial.SelectedIndex], null, "ItemData", new object[0], null, null, null));
			MaterialTmp = CFS.Materials [0].Clone ();
			MaterialDefTmp = MaterialTmp.Clone ();
		} else {
			iMaterialTmp = CFS.Sections [CFS.intSctNow].MaterialIndex;
			MaterialTmp = CFS.Sections [CFS.intSctNow].Material.Clone ();
			MaterialDefTmp = CFS.MaterialDefault.Clone ();
		}
		if (iMaterialTmp == 0) {
			MaterialPrev = MaterialTmp.Clone ();
			if (MaterialTmp.IsCarbon ()) {
				cboMaterial.Items.Add (new ListItem (Strings.Trim (MaterialTmp.Name), 0));
			} else {
				cboMaterialSS.Items.Add (new ListItem (Strings.Trim (MaterialTmp.Name), 0));
			}
		}
		int num = Information.UBound (CFS.Materials);
		checked {
			for (int i = 1; i <= num; i++) {
				if (CFS.Materials [i].IsCarbon ()) {
					cboMaterial.Items.Add (new ListItem (Strings.Trim (CFS.Materials [i].Name), i));
				}
			}
			int num2 = Information.UBound (CFS.Materials);
			for (int j = 1; j <= num2; j++) {
				if ((CFS.Materials [j].Eo [2] > 0f) & CFS.Materials [j].IsStainless ()) {
					cboMaterialSS.Items.Add (new ListItem (Strings.Trim (CFS.Materials [j].Name), j));
				}
			}
			System.Windows.Forms.ComboBox.ObjectCollection items = cboSSFamily.Items;
			items.Clear ();
			items.Add ("Austenitic");
			items.Add ("Ferritic");
			items.Add ("Duplex");
			_ = null;
			if (MaterialTmp.IsCarbon ()) {
				SetMaterial (0);
			} else {
				SetMaterial (1);
			}
		}
	}

	private void frmMaterial_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Type typeFromHandle = typeof(Help);
			TabPage selectedTab;
			object[] obj = new object[3] {
				this,
				CFS.strAppPath + "CFS.chm",
				(selectedTab = tabMaterial.SelectedTab).Tag
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

	private void frmMaterial_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Type typeFromHandle = typeof(Help);
		TabPage selectedTab;
		object[] obj = new object[3] {
			this,
			CFS.strAppPath + "CFS.chm",
			(selectedTab = tabMaterial.SelectedTab).Tag
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

	private void cmdCustomize_Click (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		object objectValue = RuntimeHelpers.GetObjectValue (Interaction.IIf (tabMaterial.SelectedIndex == 0, cboMaterial, cboMaterialSS));
		MaterialTmp.Name = "[" + Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (objectValue, null, "Text", new object[0], null, null, null))) + "]";
		MaterialPrev = MaterialTmp.Clone ();
		iMaterialTmp = 0;
		SetMaterial (checked((short)tabMaterial.SelectedIndex));
		NewLateBinding.LateCall (objectValue, null, "Select", new object[0], null, null, null, IgnoreReturn: true);
		Cursor.Current = Cursors.Default;
	}

	private void cmdDefault_Click (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		MaterialTmp = MaterialDefTmp.Clone ();
		MaterialPrev = MaterialTmp.Clone ();
		iMaterialTmp = CFS.MatchMaterial (MaterialTmp);
		if (MaterialTmp.IsCarbon ()) {
			SetMaterial (0);
			cboMaterial.Select ();
		} else {
			SetMaterial (1);
			cboMaterialSS.Select ();
		}
		Cursor.Current = Cursors.Default;
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		string text = string.Empty;
		MaterialType materialTmp = MaterialTmp;
		checked {
			if (materialTmp.IsCarbon ()) {
				if (materialTmp.Fy [2] < materialTmp.FyMin) {
					text += "Default Fy less than Minimum Fy.\r\n";
				}
				if (materialTmp.Fy [2] > materialTmp.FuMin) {
					text += "Default Fy greater than Minimum Fu.\r\n";
				}
				if (materialTmp.Fu < materialTmp.FuMin) {
					text += "Default Fu less than Minimum Fu.\r\n";
				}
				if (materialTmp.Fu > materialTmp.FuMax) {
					text += "Default Fu greater than Maximum Fu.\r\n";
				}
			} else {
				int num = 1;
				do {
					if ((double)materialTmp.Fu < 1.1 * (double)materialTmp.Fy [num]) {
						text += "Fu less than 1.1Fy.\r\n";
						break;
					}
					num++;
				} while (num <= 4);
			}
			if (materialTmp.Fu > 3f * materialTmp.FyMin) {
				text += "Fu greater than 3Fy.\r\n";
			}
			int num2 = 1;
			do {
				if ((double)materialTmp.Fy [num2] > 0.01 * (double)materialTmp.Eo [num2]) {
					text += "Yield strain exceeds 0.01.\r\n";
					break;
				}
				num2++;
			} while (num2 <= 4);
			if (materialTmp.IsStainless () & ((double)materialTmp.Fy [5] > 0.8 * (double)materialTmp.FyMin)) {
				text += "Shear yield greater than 0.8Fy.\r\n";
			}
			materialTmp = null;
			if (Strings.Len (text) != 0) {
				Interaction.MsgBox (text, MsgBoxStyle.Information);
				return;
			}
			base.DialogResult = DialogResult.OK;
			base.Tag = MaterialTmp;
			Hide ();
		}
	}

	private void cboMaterial_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboMaterial_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectEqual (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[1] { 0 }, null, null, null), null, "ItemData", new object[0], null, null, null), 0, TextCompare: false), iMaterialTmp == 0))) {
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
				e.Handled = true;
			}
		} else {
			if (e.KeyChar == '\r') {
				base.AcceptButton = cmdOK;
			}
			e.Handled = true;
		}
	}

	private void cboMaterial_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		if (Operators.ConditionalCompareObjectGreater (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), -1, TextCompare: false)) {
			iMaterialTmp = Conversions.ToShort (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null));
			if (iMaterialTmp == 0) {
				MaterialTmp = MaterialPrev.Clone ();
			} else {
				MaterialTmp = CFS.Materials [iMaterialTmp].Clone ();
			}
			if (sender == cboMaterial) {
				cboMaterialSS.SelectedIndex = -1;
			}
			if (sender == cboMaterialSS) {
				cboMaterial.SelectedIndex = -1;
			}
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		}
		RefreshMtl ();
	}

	private void cboMaterial_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboMaterial_Validating (object sender, CancelEventArgs e)
	{
		if (iMaterialTmp == 0) {
			if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[1] { 0 }, null, null, null), null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
				base.AcceptButton = cmdOK;
				base.CancelButton = cmdCancel;
				if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) != 0) {
					string text = Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)));
					if (Operators.CompareString (Strings.Left (text, 1), "[", TextCompare: false) != 0) {
						text = "[" + text;
					}
					if (Operators.CompareString (Strings.Right (text, 1), "]", TextCompare: false) != 0) {
						text += "]";
					}
					if (Strings.Len (text) > 24) {
						text = Strings.Left (text, 23) + "]";
					}
					MaterialTmp.Name = text;
					MaterialPrev.Name = MaterialTmp.Name;
					NewLateBinding.LateSet (sender, null, "items", new object[2] {
						0,
						new ListItem (text, 0)
					}, null, null);
					CFS.blnValidate = false;
					NewLateBinding.LateSet (sender, null, "SelectedIndex", new object[1] { 0 }, null, null);
					CFS.blnValidate = true;
				}
			}
		} else {
			if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterial.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
				cboMaterial.Items.RemoveAt (0);
			}
			if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboMaterialSS.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
				cboMaterialSS.Items.RemoveAt (0);
			}
		}
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
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
		if (sender is System.Windows.Forms.ComboBox) {
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
		CFSInterface.BuildList ((System.Windows.Forms.ComboBox)sender);
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
			MaterialType materialTmp = MaterialTmp;
			bool flag = true;
			if (flag == (sender == cboModulus)) {
				materialTmp.Eo [1] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Eo [2] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Eo [3] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Eo [4] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Eo [5] = Conversions.ToSingle (Operators.MultiplyObject (Operators.DivideObject (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null), 29500.0), 11300.0));
			} else if (flag == (sender == cboYieldMin)) {
				materialTmp.FyMin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboYieldDefault)) {
				materialTmp.Fy [1] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [2] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [3] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [4] = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.Fy [5] = Conversions.ToSingle (Operators.MultiplyObject (0.6, NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null)));
			} else if (flag == (sender == cboTensileMin)) {
				materialTmp.FuMin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboTensileDefault)) {
				materialTmp.Fu = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboTensileMax)) {
				materialTmp.FuMax = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboTensile)) {
				materialTmp.Fu = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.FuMin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				materialTmp.FuMax = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboThkMin)) {
				materialTmp.ThkMin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			materialTmp = null;
			MaterialPrev = MaterialTmp.Clone ();
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
			MaterialType materialTmp = MaterialTmp;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == txtElong)) {
				materialTmp.Elong = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtElongThin)) {
				materialTmp.ElongThin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			materialTmp = null;
		} else {
			e.Cancel = true;
		}
	}

	private void tabMaterial_SelectedIndexChanged (object sender, EventArgs e)
	{
		switch (tabMaterial.SelectedIndex) {
		case 0:
			cboMaterial.Select ();
			break;
		case 1:
			cboMaterialSS.Select ();
			break;
		}
		RefreshMtl ();
	}

	private void cboSSFamily_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			switch (cboSSFamily.SelectedIndex) {
			case 0:
				MaterialTmp.SetAustenitic ();
				break;
			case 1:
				MaterialTmp.SetFerritic ();
				break;
			case 2:
				MaterialTmp.SetDuplex ();
				break;
			}
		}
	}

	private void grdMaterial_CellChanging (object Sender, Grid.CellChangingEventArgs e)
	{
		if (!blnCodeChange) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void grdMaterial_CellChange (object Sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEdit.Tag;
		switch (e.Col) {
		case 1:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [5] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 5000 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 50000 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [5] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 1 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 200 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 3:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.NoUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [0] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 1 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEdit.Text = grdMaterial.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEdit, blnShowUnit: false)) {
			MaterialType materialTmp = MaterialTmp;
			switch (e.Col) {
			case 1:
				materialTmp.Eo [e.Row] = Conversions.ToSingle (NewLateBinding.LateGet (txtEdit.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 2:
				materialTmp.Fy [e.Row] = Conversions.ToSingle (NewLateBinding.LateGet (txtEdit.Tag, null, "Value", new object[0], null, null, null));
				if (e.Row <= 4) {
					materialTmp.FyMin = materialTmp.Fy [1];
					if (materialTmp.Fy [2] < materialTmp.FyMin) {
						materialTmp.FyMin = materialTmp.Fy [2];
					}
					if (materialTmp.Fy [3] < materialTmp.FyMin) {
						materialTmp.FyMin = materialTmp.Fy [3];
					}
					if (materialTmp.Fy [4] < materialTmp.FyMin) {
						materialTmp.FyMin = materialTmp.Fy [4];
					}
				}
				break;
			case 3:
				materialTmp.N [e.Row] = Conversions.ToSingle (NewLateBinding.LateGet (txtEdit.Tag, null, "Value", new object[0], null, null, null));
				break;
			}
			materialTmp = null;
			grdMaterial.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEdit.Tag, null, "Text", new object[0], null, null, null));
			MaterialPrev = MaterialTmp.Clone ();
		} else {
			string text = string.Empty;
			switch (e.Col) {
			case 1:
				text = Units.DisplayStress (MaterialTmp.Eo [e.Row], 0, blnShowUnit: false, "", 0, 0);
				break;
			case 2:
				text = Units.DisplayStress (MaterialTmp.Fy [e.Row], 0, blnShowUnit: false, "", 0, 0);
				break;
			case 3:
				text = Units.DisplayNone (MaterialTmp.N [e.Row], "", 0, 0);
				break;
			}
			grdMaterial.Cell (e.Row, e.Col).Text = text;
		}
		blnCodeChange = false;
		base.AcceptButton = cmdOK;
		base.CancelButton = cmdCancel;
	}
}
