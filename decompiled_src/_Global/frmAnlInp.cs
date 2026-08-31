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
public class frmAnlInp : Form
{
	private IContainer components;

	private bool blnTabAnl;

	private bool blnStoreUndo;

	private bool blnValidating;

	public bool blnCodeChange;

	internal virtual TabControl tabAnl {
		[CompilerGenerated]
		get {
			return _tabAnl;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tabAnl_SelectedIndexChanged;
			TabControl tabControl = _tabAnl;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged -= value2;
			}
			_tabAnl = value;
			tabControl = _tabAnl;
			if (tabControl != null) {
				tabControl.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("Tab1")]
	internal virtual TabPage Tab1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRevised")]
	internal virtual TextBox txtRevised {
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

	[field: AccessedThroughProperty ("lblGeneral3")]
	internal virtual Label lblGeneral3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblGeneral2")]
	internal virtual Label lblGeneral2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblGeneral1")]
	internal virtual Label lblGeneral1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Tab2")]
	internal virtual TabPage Tab2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Tab3")]
	internal virtual TabPage Tab3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Tab4")]
	internal virtual TabPage Tab4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Tab5")]
	internal virtual TabPage Tab5 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Tab6")]
	internal virtual TabPage Tab6 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboLoading {
		[CompilerGenerated]
		get {
			return _cboLoading;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboLoading_GotFocus;
			KeyPressEventHandler value3 = cboLoading_KeyPress;
			EventHandler value4 = cboLoading_DropDown;
			EventHandler value5 = cboLoading_SelectedIndexChanged;
			CancelEventHandler value6 = cboLoading_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboLoading;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboLoading = value;
			comboBox = _cboLoading;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual CheckBox chkInflectionPoint {
		[CompilerGenerated]
		get {
			return _chkInflectionPoint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkInflectionPoint_CheckedChanged;
			CheckBox checkBox = _chkInflectionPoint;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkInflectionPoint = value;
			checkBox = _chkInflectionPoint;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
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
			EventHandler value4 = cboComb_DropDown;
			EventHandler value5 = cboComb_SelectedIndexChanged;
			CancelEventHandler value6 = cboComb_Validating;
			System.Windows.Forms.ComboBox comboBox = _cboComb;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.DropDown -= value4;
				comboBox.SelectedIndexChanged -= value5;
				comboBox.Validating -= value6;
			}
			_cboComb = value;
			comboBox = _cboComb;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.DropDown += value4;
				comboBox.SelectedIndexChanged += value5;
				comboBox.Validating += value6;
			}
		}
	}

	internal virtual TextBox txtNotes {
		[CompilerGenerated]
		get {
			return _txtNotes;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtNotes_TextChanged;
			TextBox textBox = _txtNotes;
			if (textBox != null) {
				textBox.TextChanged -= value2;
			}
			_txtNotes = value;
			textBox = _txtNotes;
			if (textBox != null) {
				textBox.TextChanged += value2;
			}
		}
	}

	internal virtual Grid grdBeams {
		[CompilerGenerated]
		get {
			return _grdBeams;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangeEventHandler obj = grdBeams_CellChange;
			Grid.KeyDownEventHandler obj2 = grdBeams_KeyDown;
			Grid.MouseDownEventHandler obj3 = grdBeams_MouseDown;
			Grid.SelChangeEventHandler obj4 = grdBeams_SelChange;
			Grid grid = _grdBeams;
			if (grid != null) {
				grid.CellChange -= obj;
				grid.KeyDown -= obj2;
				grid.MouseDown -= obj3;
				grid.SelChange -= obj4;
			}
			_grdBeams = value;
			grid = _grdBeams;
			if (grid != null) {
				grid.CellChange += obj;
				grid.KeyDown += obj2;
				grid.MouseDown += obj3;
				grid.SelChange += obj4;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditBeam")]
	internal virtual TextBox txtEditBeam {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtEditSup")]
	internal virtual TextBox txtEditSup {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Grid grdSupports {
		[CompilerGenerated]
		get {
			return _grdSupports;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangeEventHandler obj = grdSupports_CellChange;
			Grid.KeyDownEventHandler obj2 = grdSupports_KeyDown;
			Grid.MouseDownEventHandler obj3 = grdSupports_MouseDown;
			Grid.SelChangeEventHandler obj4 = grdSupports_SelChange;
			Grid grid = _grdSupports;
			if (grid != null) {
				grid.CellChange -= obj;
				grid.KeyDown -= obj2;
				grid.MouseDown -= obj3;
				grid.SelChange -= obj4;
			}
			_grdSupports = value;
			grid = _grdSupports;
			if (grid != null) {
				grid.CellChange += obj;
				grid.KeyDown += obj2;
				grid.MouseDown += obj3;
				grid.SelChange += obj4;
			}
		}
	}

	internal virtual Grid grdLoads {
		[CompilerGenerated]
		get {
			return _grdLoads;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			Grid.CellChangeEventHandler obj = grdLoads_CellChange;
			Grid.KeyDownEventHandler obj2 = grdLoads_KeyDown;
			Grid.MouseDownEventHandler obj3 = grdLoads_MouseDown;
			Grid.SelChangeEventHandler obj4 = grdLoads_SelChange;
			Grid grid = _grdLoads;
			if (grid != null) {
				grid.CellChange -= obj;
				grid.KeyDown -= obj2;
				grid.MouseDown -= obj3;
				grid.SelChange -= obj4;
			}
			_grdLoads = value;
			grid = _grdLoads;
			if (grid != null) {
				grid.CellChange += obj;
				grid.KeyDown += obj2;
				grid.MouseDown += obj3;
				grid.SelChange += obj4;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditLoad")]
	internal virtual TextBox txtEditLoad {
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
			Grid.CellChangeEventHandler obj = grdCombs_CellChange;
			Grid.KeyDownEventHandler obj2 = grdCombs_KeyDown;
			Grid.MouseDownEventHandler obj3 = grdCombs_MouseDown;
			Grid.SelChangeEventHandler obj4 = grdCombs_SelChange;
			Grid grid = _grdCombs;
			if (grid != null) {
				grid.CellChange -= obj;
				grid.KeyDown -= obj2;
				grid.MouseDown -= obj3;
				grid.SelChange -= obj4;
			}
			_grdCombs = value;
			grid = _grdCombs;
			if (grid != null) {
				grid.CellChange += obj;
				grid.KeyDown += obj2;
				grid.MouseDown += obj3;
				grid.SelChange += obj4;
			}
		}
	}

	[field: AccessedThroughProperty ("txtEditComb")]
	internal virtual TextBox txtEditComb {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual System.Windows.Forms.ComboBox cboOrientation {
		[CompilerGenerated]
		get {
			return _cboOrientation;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboOrientation_SelectedIndexChanged;
			System.Windows.Forms.ComboBox comboBox = _cboOrientation;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboOrientation = value;
			comboBox = _cboOrientation;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblGeneral4")]
	internal virtual Label lblGeneral4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkAllCombos {
		[CompilerGenerated]
		get {
			return _chkAllCombos;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkAllCombos_CheckedChanged;
			CheckBox checkBox = _chkAllCombos;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkAllCombos = value;
			checkBox = _chkAllCombos;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkTorsion {
		[CompilerGenerated]
		get {
			return _chkTorsion;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkTorsion_CheckedChanged;
			CheckBox checkBox = _chkTorsion;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkTorsion = value;
			checkBox = _chkTorsion;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkBucklingTheory {
		[CompilerGenerated]
		get {
			return _chkBucklingTheory;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkBucklingTheory_CheckedChanged;
			CheckBox checkBox = _chkBucklingTheory;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkBucklingTheory = value;
			checkBox = _chkBucklingTheory;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	public frmAnlInp ()
	{
		base.Load += frmAnlInp_Load;
		base.Activated += frmAnlInp_Activated;
		base.Deactivate += frmAnlInp_Deactivate;
		base.Resize += frmAnlInp_Resize;
		base.KeyDown += frmAnlInp_KeyDown;
		base.FormClosing += frmAnlInp_FormClosing;
		base.FormClosed += frmAnlInp_FormClosed;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmAnlInp));
		this.tabAnl = new System.Windows.Forms.TabControl ();
		this.Tab1 = new System.Windows.Forms.TabPage ();
		this.chkBucklingTheory = new System.Windows.Forms.CheckBox ();
		this.chkTorsion = new System.Windows.Forms.CheckBox ();
		this.cboOrientation = new System.Windows.Forms.ComboBox ();
		this.lblGeneral4 = new System.Windows.Forms.Label ();
		this.txtRevised = new System.Windows.Forms.TextBox ();
		this.txtProject = new System.Windows.Forms.TextBox ();
		this.txtDescription = new System.Windows.Forms.TextBox ();
		this.lblGeneral3 = new System.Windows.Forms.Label ();
		this.lblGeneral2 = new System.Windows.Forms.Label ();
		this.lblGeneral1 = new System.Windows.Forms.Label ();
		this.Tab2 = new System.Windows.Forms.TabPage ();
		this.txtEditBeam = new System.Windows.Forms.TextBox ();
		this.grdBeams = new FlexCell.Grid ();
		this.Tab3 = new System.Windows.Forms.TabPage ();
		this.txtEditSup = new System.Windows.Forms.TextBox ();
		this.grdSupports = new FlexCell.Grid ();
		this.Tab4 = new System.Windows.Forms.TabPage ();
		this.txtEditLoad = new System.Windows.Forms.TextBox ();
		this.grdLoads = new FlexCell.Grid ();
		this.cboLoading = new System.Windows.Forms.ComboBox ();
		this.Tab5 = new System.Windows.Forms.TabPage ();
		this.chkAllCombos = new System.Windows.Forms.CheckBox ();
		this.txtEditComb = new System.Windows.Forms.TextBox ();
		this.grdCombs = new FlexCell.Grid ();
		this.chkInflectionPoint = new System.Windows.Forms.CheckBox ();
		this.cboSpec = new System.Windows.Forms.ComboBox ();
		this.lblSpec = new System.Windows.Forms.Label ();
		this.cboComb = new System.Windows.Forms.ComboBox ();
		this.Tab6 = new System.Windows.Forms.TabPage ();
		this.txtNotes = new System.Windows.Forms.TextBox ();
		this.tabAnl.SuspendLayout ();
		this.Tab1.SuspendLayout ();
		this.Tab2.SuspendLayout ();
		this.Tab3.SuspendLayout ();
		this.Tab4.SuspendLayout ();
		this.Tab5.SuspendLayout ();
		this.Tab6.SuspendLayout ();
		base.SuspendLayout ();
		this.tabAnl.Controls.Add (this.Tab1);
		this.tabAnl.Controls.Add (this.Tab2);
		this.tabAnl.Controls.Add (this.Tab3);
		this.tabAnl.Controls.Add (this.Tab4);
		this.tabAnl.Controls.Add (this.Tab5);
		this.tabAnl.Controls.Add (this.Tab6);
		this.tabAnl.Location = new System.Drawing.Point (0, 0);
		this.tabAnl.Name = "tabAnl";
		this.tabAnl.SelectedIndex = 0;
		this.tabAnl.Size = new System.Drawing.Size (442, 222);
		this.tabAnl.TabIndex = 0;
		this.Tab1.Controls.Add (this.chkBucklingTheory);
		this.Tab1.Controls.Add (this.chkTorsion);
		this.Tab1.Controls.Add (this.cboOrientation);
		this.Tab1.Controls.Add (this.lblGeneral4);
		this.Tab1.Controls.Add (this.txtRevised);
		this.Tab1.Controls.Add (this.txtProject);
		this.Tab1.Controls.Add (this.txtDescription);
		this.Tab1.Controls.Add (this.lblGeneral3);
		this.Tab1.Controls.Add (this.lblGeneral2);
		this.Tab1.Controls.Add (this.lblGeneral1);
		this.Tab1.Location = new System.Drawing.Point (4, 22);
		this.Tab1.Name = "Tab1";
		this.Tab1.Padding = new System.Windows.Forms.Padding (3);
		this.Tab1.Size = new System.Drawing.Size (434, 196);
		this.Tab1.TabIndex = 0;
		this.Tab1.Tag = "analysis-inputs-general.htm";
		this.Tab1.Text = "General";
		this.Tab1.UseVisualStyleBackColor = true;
		this.chkBucklingTheory.AutoSize = true;
		this.chkBucklingTheory.Location = new System.Drawing.Point (14, 122);
		this.chkBucklingTheory.Name = "chkBucklingTheory";
		this.chkBucklingTheory.Size = new System.Drawing.Size (237, 17);
		this.chkBucklingTheory.TabIndex = 9;
		this.chkBucklingTheory.Text = "Calculate global buckling using elastic theory";
		this.chkBucklingTheory.UseVisualStyleBackColor = true;
		this.chkTorsion.AutoSize = true;
		this.chkTorsion.Location = new System.Drawing.Point (14, 145);
		this.chkTorsion.Name = "chkTorsion";
		this.chkTorsion.Size = new System.Drawing.Size (184, 17);
		this.chkTorsion.TabIndex = 8;
		this.chkTorsion.Text = "Include torsion in member checks";
		this.chkTorsion.UseVisualStyleBackColor = true;
		this.cboOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboOrientation.FormattingEnabled = true;
		this.cboOrientation.Location = new System.Drawing.Point (131, 95);
		this.cboOrientation.Name = "cboOrientation";
		this.cboOrientation.Size = new System.Drawing.Size (173, 21);
		this.cboOrientation.TabIndex = 7;
		this.lblGeneral4.Location = new System.Drawing.Point (11, 98);
		this.lblGeneral4.Name = "lblGeneral4";
		this.lblGeneral4.Size = new System.Drawing.Size (114, 19);
		this.lblGeneral4.TabIndex = 6;
		this.lblGeneral4.Text = "Member Orientation";
		this.txtRevised.Location = new System.Drawing.Point (88, 69);
		this.txtRevised.Name = "txtRevised";
		this.txtRevised.ReadOnly = true;
		this.txtRevised.Size = new System.Drawing.Size (216, 20);
		this.txtRevised.TabIndex = 5;
		this.txtProject.Location = new System.Drawing.Point (88, 43);
		this.txtProject.MaxLength = 40;
		this.txtProject.Name = "txtProject";
		this.txtProject.Size = new System.Drawing.Size (216, 20);
		this.txtProject.TabIndex = 3;
		this.txtDescription.Location = new System.Drawing.Point (88, 17);
		this.txtDescription.MaxLength = 40;
		this.txtDescription.Name = "txtDescription";
		this.txtDescription.Size = new System.Drawing.Size (216, 20);
		this.txtDescription.TabIndex = 1;
		this.lblGeneral3.Location = new System.Drawing.Point (11, 72);
		this.lblGeneral3.Name = "lblGeneral3";
		this.lblGeneral3.Size = new System.Drawing.Size (71, 19);
		this.lblGeneral3.TabIndex = 4;
		this.lblGeneral3.Text = "Revised";
		this.lblGeneral2.Location = new System.Drawing.Point (11, 46);
		this.lblGeneral2.Name = "lblGeneral2";
		this.lblGeneral2.Size = new System.Drawing.Size (71, 19);
		this.lblGeneral2.TabIndex = 2;
		this.lblGeneral2.Text = "Project";
		this.lblGeneral1.Location = new System.Drawing.Point (11, 20);
		this.lblGeneral1.Name = "lblGeneral1";
		this.lblGeneral1.Size = new System.Drawing.Size (71, 19);
		this.lblGeneral1.TabIndex = 0;
		this.lblGeneral1.Text = "Description";
		this.Tab2.Controls.Add (this.txtEditBeam);
		this.Tab2.Controls.Add (this.grdBeams);
		this.Tab2.Location = new System.Drawing.Point (4, 22);
		this.Tab2.Name = "Tab2";
		this.Tab2.Padding = new System.Windows.Forms.Padding (3);
		this.Tab2.Size = new System.Drawing.Size (434, 196);
		this.Tab2.TabIndex = 1;
		this.Tab2.Tag = "analysis-inputs-members.htm";
		this.Tab2.Text = "Members";
		this.Tab2.UseVisualStyleBackColor = true;
		this.txtEditBeam.Location = new System.Drawing.Point (8, 168);
		this.txtEditBeam.Name = "txtEditBeam";
		this.txtEditBeam.Size = new System.Drawing.Size (117, 20);
		this.txtEditBeam.TabIndex = 2;
		this.txtEditBeam.Visible = false;
		this.grdBeams.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdBeams.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdBeams.BoldFixedCell = false;
		this.grdBeams.Cols = 10;
		this.grdBeams.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdBeams.Location = new System.Drawing.Point (6, 6);
		this.grdBeams.Name = "grdBeams";
		this.grdBeams.Rows = 3;
		this.grdBeams.Size = new System.Drawing.Size (402, 156);
		this.grdBeams.TabIndex = 1;
		this.Tab3.Controls.Add (this.txtEditSup);
		this.Tab3.Controls.Add (this.grdSupports);
		this.Tab3.Location = new System.Drawing.Point (4, 22);
		this.Tab3.Name = "Tab3";
		this.Tab3.Padding = new System.Windows.Forms.Padding (3);
		this.Tab3.Size = new System.Drawing.Size (434, 196);
		this.Tab3.TabIndex = 2;
		this.Tab3.Tag = "analysis-inputs-supports.htm";
		this.Tab3.Text = "Supports";
		this.Tab3.UseVisualStyleBackColor = true;
		this.txtEditSup.Location = new System.Drawing.Point (6, 168);
		this.txtEditSup.Name = "txtEditSup";
		this.txtEditSup.Size = new System.Drawing.Size (117, 20);
		this.txtEditSup.TabIndex = 2;
		this.txtEditSup.Visible = false;
		this.grdSupports.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdSupports.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdSupports.BoldFixedCell = false;
		this.grdSupports.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdSupports.Location = new System.Drawing.Point (6, 6);
		this.grdSupports.Name = "grdSupports";
		this.grdSupports.Rows = 3;
		this.grdSupports.Size = new System.Drawing.Size (402, 156);
		this.grdSupports.TabIndex = 1;
		this.Tab4.Controls.Add (this.txtEditLoad);
		this.Tab4.Controls.Add (this.grdLoads);
		this.Tab4.Controls.Add (this.cboLoading);
		this.Tab4.Location = new System.Drawing.Point (4, 22);
		this.Tab4.Name = "Tab4";
		this.Tab4.Padding = new System.Windows.Forms.Padding (3);
		this.Tab4.Size = new System.Drawing.Size (434, 196);
		this.Tab4.TabIndex = 3;
		this.Tab4.Tag = "analysis-inputs-loadings.htm";
		this.Tab4.Text = "Loadings";
		this.Tab4.UseVisualStyleBackColor = true;
		this.txtEditLoad.Location = new System.Drawing.Point (271, 8);
		this.txtEditLoad.Name = "txtEditLoad";
		this.txtEditLoad.Size = new System.Drawing.Size (137, 20);
		this.txtEditLoad.TabIndex = 3;
		this.txtEditLoad.Visible = false;
		this.grdLoads.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdLoads.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdLoads.BoldFixedCell = false;
		this.grdLoads.Cols = 9;
		this.grdLoads.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdLoads.Location = new System.Drawing.Point (6, 35);
		this.grdLoads.Name = "grdLoads";
		this.grdLoads.Rows = 3;
		this.grdLoads.Size = new System.Drawing.Size (402, 156);
		this.grdLoads.TabIndex = 2;
		this.cboLoading.FormattingEnabled = true;
		this.cboLoading.Location = new System.Drawing.Point (8, 8);
		this.cboLoading.MaxLength = 20;
		this.cboLoading.Name = "cboLoading";
		this.cboLoading.Size = new System.Drawing.Size (207, 21);
		this.cboLoading.TabIndex = 1;
		this.Tab5.Controls.Add (this.chkAllCombos);
		this.Tab5.Controls.Add (this.txtEditComb);
		this.Tab5.Controls.Add (this.grdCombs);
		this.Tab5.Controls.Add (this.chkInflectionPoint);
		this.Tab5.Controls.Add (this.cboSpec);
		this.Tab5.Controls.Add (this.lblSpec);
		this.Tab5.Controls.Add (this.cboComb);
		this.Tab5.Location = new System.Drawing.Point (4, 22);
		this.Tab5.Name = "Tab5";
		this.Tab5.Padding = new System.Windows.Forms.Padding (3);
		this.Tab5.Size = new System.Drawing.Size (434, 196);
		this.Tab5.TabIndex = 4;
		this.Tab5.Tag = "analysis-inputs-combinations.htm";
		this.Tab5.Text = "Combinations";
		this.Tab5.UseVisualStyleBackColor = true;
		this.chkAllCombos.AutoSize = true;
		this.chkAllCombos.Location = new System.Drawing.Point (223, 35);
		this.chkAllCombos.Name = "chkAllCombos";
		this.chkAllCombos.Size = new System.Drawing.Size (164, 17);
		this.chkAllCombos.TabIndex = 6;
		this.chkAllCombos.Text = "For All Strength Combinations";
		this.chkAllCombos.UseVisualStyleBackColor = true;
		this.txtEditComb.Location = new System.Drawing.Point (265, 69);
		this.txtEditComb.Name = "txtEditComb";
		this.txtEditComb.Size = new System.Drawing.Size (136, 20);
		this.txtEditComb.TabIndex = 5;
		this.txtEditComb.Visible = false;
		this.grdCombs.AllowUserPaste = FlexCell.ClipboardDataEnum.None;
		this.grdCombs.AllowUserResizing = FlexCell.ResizeEnum.Columns;
		this.grdCombs.BoldFixedCell = false;
		this.grdCombs.Cols = 3;
		this.grdCombs.GridColor = System.Drawing.Color.FromArgb (192, 192, 192);
		this.grdCombs.Location = new System.Drawing.Point (6, 60);
		this.grdCombs.Name = "grdCombs";
		this.grdCombs.Rows = 3;
		this.grdCombs.Size = new System.Drawing.Size (402, 130);
		this.grdCombs.TabIndex = 4;
		this.chkInflectionPoint.AutoSize = true;
		this.chkInflectionPoint.Location = new System.Drawing.Point (8, 35);
		this.chkInflectionPoint.Name = "chkInflectionPoint";
		this.chkInflectionPoint.Size = new System.Drawing.Size (157, 17);
		this.chkInflectionPoint.TabIndex = 3;
		this.chkInflectionPoint.Text = "Use Inflection Point Bracing";
		this.chkInflectionPoint.UseVisualStyleBackColor = true;
		this.cboSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSpec.FormattingEnabled = true;
		this.cboSpec.Location = new System.Drawing.Point (265, 8);
		this.cboSpec.Name = "cboSpec";
		this.cboSpec.Size = new System.Drawing.Size (166, 21);
		this.cboSpec.TabIndex = 2;
		this.lblSpec.Location = new System.Drawing.Point (220, 11);
		this.lblSpec.Name = "lblSpec";
		this.lblSpec.Size = new System.Drawing.Size (39, 18);
		this.lblSpec.TabIndex = 2;
		this.lblSpec.Text = "Spec.";
		this.cboComb.DropDownHeight = 197;
		this.cboComb.FormattingEnabled = true;
		this.cboComb.IntegralHeight = false;
		this.cboComb.Location = new System.Drawing.Point (8, 8);
		this.cboComb.MaxLength = 30;
		this.cboComb.Name = "cboComb";
		this.cboComb.Size = new System.Drawing.Size (207, 21);
		this.cboComb.TabIndex = 1;
		this.Tab6.Controls.Add (this.txtNotes);
		this.Tab6.Location = new System.Drawing.Point (4, 22);
		this.Tab6.Name = "Tab6";
		this.Tab6.Padding = new System.Windows.Forms.Padding (3);
		this.Tab6.Size = new System.Drawing.Size (434, 196);
		this.Tab6.TabIndex = 5;
		this.Tab6.Tag = "analysis-inputs-notes.htm";
		this.Tab6.Text = "Notes";
		this.Tab6.UseVisualStyleBackColor = true;
		this.txtNotes.AcceptsReturn = true;
		this.txtNotes.Location = new System.Drawing.Point (6, 6);
		this.txtNotes.Multiline = true;
		this.txtNotes.Name = "txtNotes";
		this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtNotes.Size = new System.Drawing.Size (402, 167);
		this.txtNotes.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (444, 224);
		base.Controls.Add (this.tabAnl);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size (460, 240);
		base.Name = "frmAnlInp";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Analysis Inputs";
		this.tabAnl.ResumeLayout (false);
		this.Tab1.ResumeLayout (false);
		this.Tab1.PerformLayout ();
		this.Tab2.ResumeLayout (false);
		this.Tab2.PerformLayout ();
		this.Tab3.ResumeLayout (false);
		this.Tab3.PerformLayout ();
		this.Tab4.ResumeLayout (false);
		this.Tab4.PerformLayout ();
		this.Tab5.ResumeLayout (false);
		this.Tab5.PerformLayout ();
		this.Tab6.ResumeLayout (false);
		this.Tab6.PerformLayout ();
		base.ResumeLayout (false);
	}

	public void SetControlData ()
	{
		txtDescription.Tag = new ControlData (byte.MaxValue);
		txtProject.Tag = new ControlData (byte.MaxValue);
		txtEditBeam.Tag = new ControlData (2);
		txtEditSup.Tag = new ControlData (2);
		txtEditLoad.Tag = new ControlData (3);
		cboLoading.Tag = new ControlData (byte.MaxValue);
		cboComb.Tag = new ControlData (byte.MaxValue);
		txtEditComb.Tag = new ControlData (0);
	}

	public void SetGridTitles ()
	{
		blnCodeChange = true;
		Grid grid = grdBeams;
		grid.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid.Column (1).Alignment = AlignmentEnum.LeftCenter;
		grid.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid.Column (3).Alignment = AlignmentEnum.RightCenter;
		grid.Column (4).Alignment = AlignmentEnum.LeftCenter;
		grid.Column (5).Alignment = AlignmentEnum.RightCenter;
		grid.Column (6).Alignment = AlignmentEnum.RightCenter;
		grid.Column (7).Alignment = AlignmentEnum.RightCenter;
		grid.Column (8).Alignment = AlignmentEnum.RightCenter;
		grid.Column (9).Alignment = AlignmentEnum.RightCenter;
		grid.Range (0, 1, 0, 9).WrapText = true;
		grid.Range (0, 1, 0, 9).Alignment = AlignmentEnum.CenterTop;
		grid.Cell (0, 0).Text = "999";
		grid.Column (0).AutoFit ();
		grid.Cell (0, 0).Text = string.Empty;
		grid.Cell (0, 1).Text = "Section";
		grid.Column (1).Width = 100;
		grid.Cell (0, 2).Text = " Location ";
		grid.Column (2).AutoFit ();
		Cell cell;
		(cell = grid.Cell (0, 2)).Text = cell.Text + "\nStart (" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid.Cell (0, 3).Text = " Location ";
		grid.Column (3).AutoFit ();
		(cell = grid.Cell (0, 3)).Text = cell.Text + "\nEnd (" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid.Cell (0, 4).Text = "  Braced  ";
		grid.Column (4).AutoFit ();
		grid.Cell (0, 4).Text += "\nFlange";
		grid.Cell (0, 5).Text = "Reduction";
		grid.Column (5).AutoFit ();
		grid.Cell (0, 5).Text += "\nFactor, R";
		grid.Cell (0, 6).Text = "Stiffness,";
		grid.Column (6).AutoFit ();
		(cell = grid.Cell (0, 6)).Text = cell.Text + "\nkϕ (" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
		grid.Cell (0, 7).Text = "Length Lm";
		grid.Column (7).AutoFit ();
		(cell = grid.Cell (0, 7)).Text = cell.Text + "\n(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid.Cell (0, 8).Text = "Load Point";
		grid.Column (8).AutoFit ();
		(cell = grid.Cell (0, 8)).Text = cell.Text + "\nex (" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Cell (0, 9).Text = "Load Point";
		grid.Column (9).AutoFit ();
		(cell = grid.Cell (0, 9)).Text = cell.Text + "\ney (" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid.Row (0).AutoFit ();
		grid.Column (1).CellType = CellTypeEnum.ComboBox;
		grid.ComboBox (1).Locked = true;
		grid.ComboBox (1).AutoComplete = true;
		grid.Column (4).CellType = CellTypeEnum.ComboBox;
		grid.ComboBox (4).Locked = true;
		grid.ComboBox (4).AutoComplete = true;
		grid.ComboBox (4).Items.Clear ();
		grid.ComboBox (4).Items.Add ("None");
		grid.ComboBox (4).Items.Add ("Bottom");
		grid.ComboBox (4).Items.Add ("Top");
		grid.ComboBox (4).Items.Add ("Left");
		grid.ComboBox (4).Items.Add ("Right");
		_ = null;
		CFS.blnRefreshGrdBeams = true;
		blnCodeChange = false;
		blnCodeChange = true;
		Grid grid2 = grdSupports;
		grid2.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid2.Column (1).Alignment = AlignmentEnum.LeftCenter;
		grid2.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid2.Column (3).Alignment = AlignmentEnum.RightCenter;
		grid2.Column (4).Alignment = AlignmentEnum.LeftCenter;
		grid2.Column (5).Alignment = AlignmentEnum.RightCenter;
		grid2.Range (0, 1, 0, 5).WrapText = true;
		grid2.Range (0, 1, 0, 5).Alignment = AlignmentEnum.CenterTop;
		grid2.Cell (0, 0).Text = "999";
		grid2.Column (0).AutoFit ();
		grid2.Cell (0, 0).Text = string.Empty;
		grid2.Cell (0, 1).Text = "Type";
		grid2.Column (1).Width = 80;
		grid2.Cell (0, 2).Text = "Location";
		grid2.Column (2).AutoFit ();
		(cell = grid2.Cell (0, 2)).Text = cell.Text + "\n(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid2.Cell (0, 3).Text = "Bearing";
		grid2.Column (3).AutoFit ();
		(cell = grid2.Cell (0, 3)).Text = cell.Text + "\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid2.Cell (0, 4).Text = "Fastened";
		grid2.Column (4).AutoFit ();
		grid2.Cell (0, 5).Text = "Effective Length";
		grid2.Column (5).AutoFit ();
		grid2.Cell (0, 5).Text += "\nFactor, K";
		grid2.Row (0).AutoFit ();
		grid2.Column (1).CellType = CellTypeEnum.ComboBox;
		grid2.ComboBox (1).Locked = true;
		grid2.ComboBox (1).AutoComplete = true;
		ListBox.ObjectCollection items = grid2.ComboBox (1).Items;
		items.Clear ();
		items.Add (new ListItem (CFSInterface.DisplaySup (Supports.supX), 1));
		items.Add (new ListItem (CFSInterface.DisplaySup (Supports.supY), 2));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)3), 3));
		items.Add (new ListItem (CFSInterface.DisplaySup (Supports.supT), 4));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)5), 5));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)6), 6));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)7), 7));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)10), 10));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)11), 11));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)14), 14));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)15), 15));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)17), 17));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)19), 19));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)21), 21));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)23), 23));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)27), 27));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)31), 31));
		items.Add (new ListItem (CFSInterface.DisplaySup (Supports.supHx), 32));
		items.Add (new ListItem (CFSInterface.DisplaySup (Supports.supHy), 64));
		items.Add (new ListItem (CFSInterface.DisplaySup ((Supports)96), 96));
		_ = null;
		grid2.Column (4).CellType = CellTypeEnum.CheckBox;
		_ = null;
		CFS.blnRefreshGrdSupports = true;
		blnCodeChange = false;
		blnCodeChange = true;
		Grid grid3 = grdLoads;
		grid3.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid3.Column (1).Alignment = AlignmentEnum.LeftCenter;
		grid3.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid3.Column (3).Alignment = AlignmentEnum.RightCenter;
		grid3.Column (4).Alignment = AlignmentEnum.RightCenter;
		grid3.Column (5).Alignment = AlignmentEnum.RightCenter;
		grid3.Column (6).Alignment = AlignmentEnum.RightCenter;
		grid3.Column (7).Alignment = AlignmentEnum.LeftCenter;
		grid3.Column (7).Locked = true;
		grid3.Column (8).Alignment = AlignmentEnum.RightCenter;
		grid3.Range (0, 1, 0, 8).WrapText = true;
		grid3.Range (0, 1, 0, 8).Alignment = AlignmentEnum.CenterTop;
		grid3.Cell (0, 0).Text = "999";
		grid3.Column (0).AutoFit ();
		grid3.Cell (0, 0).Text = string.Empty;
		grid3.Cell (0, 1).Text = "Concentrated   ";
		grid3.Column (1).AutoFit ();
		grid3.Cell (0, 1).Text = "Type";
		grid3.Cell (0, 2).Text = "Angle";
		grid3.Column (2).AutoFit ();
		(cell = grid3.Cell (0, 2)).Text = cell.Text + "\n(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")";
		grid3.Cell (0, 3).Text = " Location ";
		grid3.Column (3).AutoFit ();
		(cell = grid3.Cell (0, 3)).Text = cell.Text + "\nStart (" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid3.Cell (0, 4).Text = " Location ";
		grid3.Column (4).AutoFit ();
		(cell = grid3.Cell (0, 4)).Text = cell.Text + "\nEnd (" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		grid3.Cell (0, 5).Text = "Magnitude";
		grid3.Column (5).AutoFit ();
		grid3.Cell (0, 5).Text += "\nStart";
		grid3.Cell (0, 6).Text = "Magnitude";
		grid3.Column (6).AutoFit ();
		grid3.Cell (0, 6).Text += "\nEnd";
		grid3.Cell (0, 7).Text = "Units";
		grid3.Column (7).AutoFit ();
		grid3.Cell (0, 8).Text = "Width";
		grid3.Column (8).AutoFit ();
		(cell = grid3.Cell (0, 8)).Text = cell.Text + "\n(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		grid3.Row (0).AutoFit ();
		grid3.Column (1).CellType = CellTypeEnum.ComboBox;
		grid3.ComboBox (1).Locked = true;
		grid3.ComboBox (1).AutoComplete = true;
		ListBox.ObjectCollection items2 = grid3.ComboBox (1).Items;
		items2.Clear ();
		items2.Add ("Distributed");
		items2.Add ("Concentrated");
		items2.Add ("Axial");
		items2.Add ("Moment");
		_ = null;
		_ = null;
		CFS.blnRefreshGrdLoads = true;
		blnCodeChange = false;
		blnCodeChange = true;
		Grid grid4 = grdCombs;
		grid4.Column (0).Alignment = AlignmentEnum.CenterCenter;
		grid4.Column (1).Alignment = AlignmentEnum.LeftCenter;
		grid4.Column (2).Alignment = AlignmentEnum.RightCenter;
		grid4.Range (0, 1, 0, 2).Alignment = AlignmentEnum.CenterTop;
		grid4.Cell (0, 0).Text = "999";
		grid4.Column (0).AutoFit ();
		grid4.Cell (0, 0).Text = string.Empty;
		grid4.Cell (0, 1).Text = "Beam Self Weight";
		grid4.Column (1).AutoFit ();
		checked {
			grid4.Column (1).Width += 20;
			grid4.Cell (0, 1).Text = "Loading";
			grid4.Cell (0, 2).Text = "Load Factor";
			grid4.Column (2).AutoFit ();
			grid4.Column (1).CellType = CellTypeEnum.ComboBox;
			grid4.ComboBox (1).Locked = true;
			grid4.ComboBox (1).AutoComplete = true;
			_ = null;
			CFS.blnRefreshGrdCombs = true;
			blnCodeChange = false;
		}
	}

	public void AddComb (System.Windows.Forms.ComboBox cboName)
	{
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		checked {
			if (cboName.Items.Count - unchecked((int)analysis.nComb) > 0) {
				return;
			}
			short num = 0;
			string text;
			short num2;
			do {
				num = (short)(num + 1);
				short nComb;
				unchecked {
					text = "Combination " + Conversions.ToString ((int)checked((short)unchecked(analysis.nComb + num)));
					nComb = analysis.nComb;
					num2 = 1;
				}
				while (num2 <= nComb && Strings.StrComp (analysis.Comb [num2].Description, text, CompareMethod.Text) != 0) {
					num2 = (short)unchecked(num2 + 1);
				}
			} while (num2 <= analysis.nComb);
			analysis = null;
			cboName.Items.Add (text);
		}
	}

	public void AddLoading (System.Windows.Forms.ComboBox cboName)
	{
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		checked {
			if (cboName.Items.Count - unchecked((int)analysis.nLdg) > 0) {
				return;
			}
			short num = 0;
			string text;
			short num2;
			do {
				num = (short)(num + 1);
				short nLdg;
				unchecked {
					text = "Loading " + Conversions.ToString ((int)checked((short)unchecked(analysis.nLdg + num)));
					nLdg = analysis.nLdg;
					num2 = 1;
				}
				while (num2 <= nLdg && Strings.StrComp (analysis.Ldg [num2].Description, text, CompareMethod.Text) != 0) {
					num2 = (short)unchecked(num2 + 1);
				}
			} while (num2 <= analysis.nLdg);
			analysis = null;
			cboName.Items.Add (text);
		}
	}

	private void RenameComb (bool blnSetListIndex = true)
	{
		string text = Strings.Trim (cboComb.Text);
		if (Strings.StrComp (text, Conversions.ToString (NewLateBinding.LateGet (cboComb.Tag, null, "Text", new object[0], null, null, null))) == 0) {
			return;
		}
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		if (((uint)analysis.iComb > (uint)analysis.nComb) & (Strings.Len (text) == 0)) {
			text = Conversions.ToString (NewLateBinding.LateGet (cboComb.Tag, null, "Text", new object[0], null, null, null));
		}
		NewLateBinding.LateSetComplex (cboComb.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			short num = (short)(cboComb.Items.Count - 1);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Strings.StrComp (cboComb.Items [num2].ToString (), text, CompareMethod.Text) == 0) {
					text = string.Empty;
					cboComb.SelectedIndex = num2;
					return;
				}
			}
			if (Strings.Len (text) == 0) {
				CFSInterface.StoreUndoAnl ("Delete Combination");
				cboComb.Items.RemoveAt (unchecked((int)analysis.iComb) - 1);
				if (analysis.iCombSol == analysis.iComb) {
					analysis.iCombSol = 0;
				}
				if (unchecked((uint)analysis.iCombSol > (uint)analysis.iComb)) {
					analysis.iCombSol--;
				}
				short num3 = (short)(unchecked((int)analysis.iComb) + 1);
				short nComb = analysis.nComb;
				short num4;
				for (num4 = num3; num4 <= nComb; num4 = (short)unchecked(num4 + 1)) {
					analysis.Comb [num4 - 1] = analysis.Comb [num4];
				}
				analysis.Comb [num4 - 1].Initialize (string.Empty, 10);
				if (analysis.nComb > 0) {
					analysis.nComb--;
				}
				if (analysis.iComb > 1) {
					analysis.iComb--;
				}
				if (analysis.nComb == 0) {
					analysis.Comb [analysis.iComb].Description = "Combination 1";
				}
				CFS.blnRefreshGrdCombs = true;
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			} else {
				CFSInterface.StoreUndoAnl ("Combination Name");
				text = Strings.Left (text, 30);
				analysis.Comb [analysis.iComb].Description = text;
				if (unchecked((uint)analysis.iComb > (uint)analysis.nComb)) {
					analysis.nComb = analysis.iComb;
				}
				cboComb.Items [unchecked((int)analysis.iComb) - 1] = text;
				text = string.Empty;
				if (blnSetListIndex) {
					cboComb.SelectedIndex = unchecked((int)analysis.iComb) - 1;
				}
			}
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			CFSInterface.SetMenuEdit ();
			CFSInterface.SetMenuCompute ();
			analysis = null;
		}
	}

	private void RenameLoading (bool blnSetListIndex = true)
	{
		string text = Strings.Trim (cboLoading.Text);
		if (Strings.StrComp (text, Conversions.ToString (NewLateBinding.LateGet (cboLoading.Tag, null, "Text", new object[0], null, null, null))) == 0) {
			return;
		}
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		if (((uint)analysis.iLdg > (uint)analysis.nLdg) & (Strings.Len (text) == 0)) {
			text = Conversions.ToString (NewLateBinding.LateGet (cboLoading.Tag, null, "Text", new object[0], null, null, null));
		}
		NewLateBinding.LateSetComplex (cboLoading.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			short num = (short)(cboLoading.Items.Count - 1);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Strings.StrComp (cboLoading.Items [num2].ToString (), text, CompareMethod.Text) == 0) {
					text = string.Empty;
					cboLoading.SelectedIndex = num2;
					return;
				}
			}
			if (Strings.Len (text) == 0) {
				CFSInterface.StoreUndoAnl ("Delete Loading");
				CFSInterface.RemoveLdg (CFS.Analyses [CFS.intAnlNow], analysis.iLdg);
				CFS.blnRefreshGrdLoads = true;
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
				CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			} else {
				CFSInterface.StoreUndoAnl ("Loading Name");
				text = Strings.Left (text, 20);
				analysis.Ldg [analysis.iLdg].Description = text;
				if (unchecked((uint)analysis.iLdg > (uint)analysis.nLdg)) {
					analysis.nLdg = analysis.iLdg;
				}
				cboLoading.Items [unchecked((int)analysis.iLdg) - 1] = text;
				text = string.Empty;
				if (blnSetListIndex) {
					cboLoading.SelectedIndex = unchecked((int)analysis.iLdg) - 1;
				}
			}
			CFS.blnRefreshGrdCombs = true;
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			CFSInterface.SetMenuEdit ();
			analysis = null;
		}
	}

	private void frmAnlInp_Load (object sender, EventArgs e)
	{
		CFS.blnAnlInpLoaded = true;
		checked {
			if (CFSInterface.AnlInpWidth == 0f) {
				CFSInterface.AnlInpWidth = base.Width;
				CFSInterface.AnlInpHeight = base.Height;
				CFSInterface.AnlInpLeft = (float)((double)((float)(My.MyProject.Forms.mdiCFS.Left + My.MyProject.Forms.mdiCFS.Width) - CFSInterface.AnlInpWidth) - (double)(My.MyProject.Forms.mdiCFS.Width - My.MyProject.Forms.mdiCFS.ClientSize.Width) / 2.0);
				CFSInterface.AnlInpTop = (float)((double)((float)My.MyProject.Forms.mdiCFS.Top + ((float)My.MyProject.Forms.mdiCFS.Height - CFSInterface.AnlInpHeight)) - (double)(My.MyProject.Forms.mdiCFS.Width - My.MyProject.Forms.mdiCFS.ClientSize.Width) / 2.0);
			}
			Rectangle workingArea = Screen.GetWorkingArea (new Point (0, 0));
			if (CFSInterface.AnlInpLeft < 0f) {
				CFSInterface.AnlInpLeft = 0f;
			} else if (CFSInterface.AnlInpLeft + CFSInterface.AnlInpWidth > (float)workingArea.Width) {
				CFSInterface.AnlInpLeft = (float)workingArea.Width - CFSInterface.AnlInpWidth;
			}
			if (CFSInterface.AnlInpTop < 0f) {
				CFSInterface.AnlInpTop = 0f;
			} else if (CFSInterface.AnlInpTop + CFSInterface.AnlInpHeight > (float)workingArea.Height) {
				CFSInterface.AnlInpTop = (float)workingArea.Height - CFSInterface.AnlInpHeight;
			}
			base.Left = (int)Math.Round (CFSInterface.AnlInpLeft);
			base.Top = (int)Math.Round (CFSInterface.AnlInpTop);
			base.Width = (int)Math.Round (CFSInterface.AnlInpWidth);
			base.Height = (int)Math.Round (CFSInterface.AnlInpHeight);
			SetControlData ();
			cboOrientation.Items.Clear ();
			cboOrientation.Items.Add ("Horizontal");
			cboOrientation.Items.Add ("Vertical");
			cboSpec.Items.Clear ();
			cboSpec.Items.Add (new ListItem ("Deflection Only", -1));
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
			SetGridTitles ();
			blnTabAnl = true;
			CFS.blnRefreshGrdBeams = true;
			CFS.blnRefreshGrdSupports = true;
			CFS.blnRefreshGrdLoads = true;
			CFS.blnRefreshGrdCombs = true;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		}
	}

	private void frmAnlInp_Activated (object sender, EventArgs e)
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
					tabAnl.Enabled = true;
					goto IL_0015;
					IL_0015:
					num = 3;
					if (CFS.frmAnlPic [CFS.intAnlNow] == Form.ActiveForm) {
						goto end_IL_0000_3;
					}
					goto IL_0029;
					IL_0029:
					num = 4;
					CFS.frmAnlPic [CFS.intAnlNow].BringToFront ();
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

	private void frmAnlInp_Deactivate (object sender, EventArgs e)
	{
		if (!blnValidating) {
			Control control = base.ActiveControl;
			tabAnl.Select ();
			Application.DoEvents ();
			control.Select ();
		}
	}

	private void frmAnlInp_Resize (object sender, EventArgs e)
	{
		tabAnl.Width = base.ClientSize.Width;
		tabAnl.Height = base.ClientSize.Height;
		checked {
			grdBeams.Width = tabAnl.Width - 20;
			grdBeams.Height = tabAnl.Height - 38;
			grdSupports.Width = tabAnl.Width - 20;
			grdSupports.Height = tabAnl.Height - 38;
			grdLoads.Width = tabAnl.Width - 20;
			grdLoads.Height = tabAnl.Height - 67;
			grdCombs.Width = tabAnl.Width - 20;
			grdCombs.Height = tabAnl.Height - 92;
			cboSpec.Width = tabAnl.Width - 14 - cboSpec.Left;
			txtNotes.Width = tabAnl.Width - 20;
			txtNotes.Height = tabAnl.Height - 38;
		}
	}

	private void frmAnlInp_KeyDown (object sender, KeyEventArgs e)
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
			if (CFS.intAnlNow > 0 && CFS.Analyses [CFS.intAnlNow].strUndo.Length > 0) {
				CFSInterface.UndoAnl ();
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.Y && b == 2) {
			if (CFS.intAnlNow > 0 && CFS.Analyses [CFS.intAnlNow].strRedo.Length > 0) {
				CFSInterface.RedoAnl ();
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.F1 && b == 0) {
			Type typeFromHandle = typeof(Help);
			TabPage selectedTab;
			object[] obj = new object[3] {
				this,
				CFS.strAppPath + "CFS.chm",
				(selectedTab = tabAnl.SelectedTab).Tag
			};
			object[] array = obj;
			bool[] obj2 = new bool[3] { false, false, true };
			bool[] array2 = obj2;
			NewLateBinding.LateCall (null, typeFromHandle, "ShowHelp", obj, null, null, obj2, IgnoreReturn: true);
			if (array2 [2]) {
				selectedTab.Tag = RuntimeHelpers.GetObjectValue (RuntimeHelpers.GetObjectValue (array [2]));
			}
			e.Handled = true;
		} else if (e.KeyCode == Keys.F3 && b == 0) {
			if (CFS.intSctNow > 0) {
				My.MyProject.Forms.mdiCFS.mnuViewSectionInputs_Click (My.MyProject.Forms.mdiCFS.mnuViewSectionInputs, null);
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

	private void frmAnlInp_FormClosing (object sender, FormClosingEventArgs e)
	{
		if (tabAnl.Enabled) {
			tabAnl.Select ();
		}
	}

	private void frmAnlInp_FormClosed (object sender, FormClosedEventArgs e)
	{
		CFSInterface.AnlInpLeft = base.Left;
		CFSInterface.AnlInpTop = base.Top;
		CFSInterface.AnlInpWidth = base.Width;
		CFSInterface.AnlInpHeight = base.Height;
		CFS.blnAnlInpLoaded = false;
		if ((CFS.intAnlNow > 0) & (CFS.intAnlTabNow == 3)) {
			CFS.intAnlTabNow = 0;
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.SetMenuEdit ();
		}
		My.MyProject.Forms.mdiCFS.Activate ();
	}

	private void tabAnl_SelectedIndexChanged (object sender, EventArgs e)
	{
		CFS.intAnlTabNow = checked((short)tabAnl.SelectedIndex);
		if (blnTabAnl) {
			switch (tabAnl.SelectedIndex) {
			case 0:
				txtDescription.Select ();
				break;
			case 1:
				CFSInterface.SortBeams (CFS.Analyses [CFS.intAnlNow]);
				if (grdBeams.Enabled) {
					grdBeams.Select ();
				}
				break;
			case 2:
				CFSInterface.SortSups (CFS.Analyses [CFS.intAnlNow]);
				if (grdSupports.Enabled) {
					grdSupports.Select ();
				}
				break;
			case 3:
				CFSInterface.SortLoads (ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg]);
				if (grdLoads.Enabled) {
					grdLoads.Select ();
				}
				break;
			case 4:
				if (grdCombs.Enabled) {
					grdCombs.Select ();
				}
				break;
			case 5:
				txtNotes.Select ();
				break;
			}
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
		} else {
			tabAnl.Select ();
			blnTabAnl = true;
		}
		CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		CFSInterface.SetMenuEdit ();
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
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) != 0) {
			string text = Strings.Trim (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)));
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			bool flag = true;
			if (flag == (sender == txtDescription)) {
				CFSInterface.StoreUndoAnl ("Description");
				analysis.Description = text;
			} else if (flag == (sender == txtProject)) {
				CFSInterface.StoreUndoAnl ("Project");
				analysis.Project = text;
			}
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (analysis.RevDate) + " by " + analysis.RevBy;
			CFSInterface.SetMenuEdit ();
			analysis = null;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { text }, null, null);
		}
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		CFSInterface.SetSelection ((Control)sender, blnNumeric: false);
		blnValidating = false;
	}

	private void cboOrientation_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoAnl ("Orientation");
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			analysis.Vertical = cboOrientation.SelectedIndex == 1;
			analysis.iCombSol = 0;
			analysis.Zoom = 1;
			analysis.ZoomX = 0.5f;
			analysis.ZoomY = 0.5f;
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (analysis.RevDate) + " by " + analysis.RevBy;
			analysis = null;
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.SetMenuEdit ();
		}
	}

	private void chkBucklingTheory_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoAnl ("Buckling Theory");
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			analysis.BucklingTheory = chkBucklingTheory.Checked;
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (analysis.RevDate) + " by " + analysis.RevBy;
			analysis = null;
		}
	}

	private void chkTorsion_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			CFSInterface.StoreUndoAnl ("Include Torsion");
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			analysis.Torsion = chkTorsion.Checked;
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			txtRevised.Text = Conversions.ToString (analysis.RevDate) + " by " + analysis.RevBy;
			analysis = null;
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
		checked {
			if (e.KeyChar == '\r') {
				cboComb_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
				cboComb_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
				e.Handled = true;
			} else if (e.KeyChar == '\u001b') {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				cboComb.SelectedIndex = unchecked((int)CFS.Analyses [CFS.intAnlNow].iComb) - 1;
				e.Handled = true;
			}
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
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		RenameComb (blnSetListIndex: false);
		NewLateBinding.LateSetComplex (cboComb.Tag, null, "Text", new object[1] { Strings.Trim (cboComb.Text) }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			if (cboComb.SelectedIndex > -1) {
				analysis.iComb = (byte)(cboComb.SelectedIndex + 1);
				if (analysis.iComb > Information.UBound (analysis.Comb)) {
					ref LoadCombination[] comb = ref analysis.Comb;
					comb = (LoadCombination[])Utils.CopyArray (comb, new LoadCombination[unchecked((int)analysis.iComb) + 1]);
					analysis.Comb [analysis.iComb].Initialize (string.Empty, 10);
					if (analysis.AllCombos) {
						analysis.Comb [analysis.iComb].InflPt = analysis.Comb [0].InflPt;
						analysis.Comb [analysis.iComb].Spec = analysis.Comb [0].Spec;
					}
				}
				CFSInterface.SetMenuCompute ();
			}
			if (Strings.StrComp (analysis.Comb [analysis.iComb].Description, Strings.Trim (cboComb.Text)) != 0) {
				analysis.Comb [analysis.iComb].Description = Strings.Trim (cboComb.Text);
			}
			CFS.blnRefreshGrdCombs = true;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow], blnList: false);
			analysis = null;
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
		}
	}

	private void cboComb_Validating (object sender, CancelEventArgs e)
	{
		blnValidating = true;
		RenameComb ();
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		blnValidating = false;
	}

	private void cboLoading_GotFocus (object sender, EventArgs e)
	{
		AddLoading ((System.Windows.Forms.ComboBox)sender);
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboLoading_KeyPress (object sender, KeyPressEventArgs e)
	{
		checked {
			if (e.KeyChar == '\r') {
				cboLoading_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
				cboLoading_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
				e.Handled = true;
			} else if (e.KeyChar == '\u001b') {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				cboLoading.SelectedIndex = unchecked((int)CFS.Analyses [CFS.intAnlNow].iLdg) - 1;
				e.Handled = true;
			}
		}
	}

	private void cboLoading_DropDown (object sender, EventArgs e)
	{
		RenameLoading ();
	}

	private void cboLoading_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		RenameLoading (blnSetListIndex: false);
		NewLateBinding.LateSetComplex (cboLoading.Tag, null, "Text", new object[1] { Strings.Trim (cboLoading.Text) }, null, null, OptimisticSet: false, RValueBase: true);
		checked {
			if (cboLoading.SelectedIndex > -1) {
				analysis.iLdg = (byte)(cboLoading.SelectedIndex + 1);
				if (analysis.iLdg > Information.UBound (analysis.Ldg)) {
					ref Loading[] ldg = ref analysis.Ldg;
					ldg = (Loading[])Utils.CopyArray (ldg, new Loading[unchecked((int)analysis.iLdg) + 1]);
					analysis.Ldg [analysis.iLdg].Initialize (string.Empty, 10);
				}
				CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			}
			if (Strings.StrComp (analysis.Ldg [analysis.iLdg].Description, Strings.Trim (cboLoading.Text)) != 0) {
				analysis.Ldg [analysis.iLdg].Description = Strings.Trim (cboLoading.Text);
			}
			CFS.blnRefreshGrdLoads = true;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow], blnList: false);
			analysis = null;
		}
	}

	private void cboLoading_Validating (object sender, CancelEventArgs e)
	{
		blnValidating = true;
		RenameLoading ();
		NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
		blnValidating = false;
	}

	private void cboSpec_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		CFSInterface.StoreUndoAnl ("Specification");
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		analysis.Comb [analysis.iComb].Spec = Conversions.ToShort (NewLateBinding.LateGet (cboSpec.Items [cboSpec.SelectedIndex], null, "ItemData", new object[0], null, null, null));
		if (analysis.AllCombos & (analysis.Comb [analysis.iComb].Spec >= 0)) {
			analysis.Comb [0].Spec = analysis.Comb [analysis.iComb].Spec;
			int num = Information.UBound (analysis.Comb);
			for (int i = 1; i <= num; i = checked(i + 1)) {
				if (analysis.Comb [i].Spec >= 0) {
					analysis.Comb [i].Spec = analysis.Comb [0].Spec;
					analysis.Comb [i].InflPt = analysis.Comb [0].InflPt;
				}
			}
		}
		if ((uint)analysis.iComb > (uint)analysis.nComb) {
			analysis.nComb = analysis.iComb;
		}
		analysis.Saved = false;
		analysis.RevDate = DateAndTime.Now;
		analysis.RevBy = CFS.User.Name;
		analysis.iCombSol = 0;
		analysis = null;
		CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		CFSInterface.SetMenuEdit ();
		CFSInterface.SetMenuCompute ();
	}

	private void chkInflectionPoint_CheckedChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		CFSInterface.StoreUndoAnl ("Inflection Point");
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		analysis.Comb [analysis.iComb].InflPt = chkInflectionPoint.Checked;
		if (analysis.AllCombos & (analysis.Comb [analysis.iComb].Spec >= 0)) {
			analysis.Comb [0].InflPt = analysis.Comb [analysis.iComb].InflPt;
			int num = Information.UBound (analysis.Comb);
			for (int i = 1; i <= num; i = checked(i + 1)) {
				if (analysis.Comb [i].Spec >= 0) {
					analysis.Comb [i].Spec = analysis.Comb [0].Spec;
					analysis.Comb [i].InflPt = analysis.Comb [0].InflPt;
				}
			}
		}
		if ((uint)analysis.iComb > (uint)analysis.nComb) {
			analysis.nComb = analysis.iComb;
		}
		analysis.Saved = false;
		analysis.RevDate = DateAndTime.Now;
		analysis.RevBy = CFS.User.Name;
		analysis.iCombSol = 0;
		analysis = null;
		CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		CFSInterface.SetMenuEdit ();
		CFSInterface.SetMenuCompute ();
	}

	private void chkAllCombos_CheckedChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		CFSInterface.StoreUndoAnl ("All Load Combinations");
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		analysis.AllCombos = chkAllCombos.Checked;
		if (analysis.AllCombos & (analysis.Comb [analysis.iComb].Spec >= 0)) {
			analysis.Comb [0].Spec = analysis.Comb [analysis.iComb].Spec;
			analysis.Comb [0].InflPt = analysis.Comb [analysis.iComb].InflPt;
			int num = Information.UBound (analysis.Comb);
			for (int i = 1; i <= num; i = checked(i + 1)) {
				if (analysis.Comb [i].Spec >= 0) {
					analysis.Comb [i].Spec = analysis.Comb [0].Spec;
					analysis.Comb [i].InflPt = analysis.Comb [0].InflPt;
				}
			}
		}
		if ((uint)analysis.iComb > (uint)analysis.nComb) {
			analysis.nComb = analysis.iComb;
		}
		analysis.Saved = false;
		analysis.RevDate = DateAndTime.Now;
		analysis.RevBy = CFS.User.Name;
		analysis.iCombSol = 0;
		analysis = null;
	}

	private void txtNotes_TextChanged (object sender, EventArgs e)
	{
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		if (Operators.CompareString (txtNotes.Text, analysis.Notes, TextCompare: false) != 0) {
			analysis.Notes = txtNotes.Text;
			analysis.Saved = false;
		}
		analysis = null;
	}

	private void grdBeams_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditBeam.Tag;
		checked {
			switch (e.Col) {
			case 1:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdBeams.ComboBox (e.Col).FindItem (grdBeams.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { grdBeams.ComboBox (e.Col).Items.Count - 1 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 2:
			case 3:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.LengthUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [2] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -48000 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 48000 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 4:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdBeams.ComboBox (e.Col).FindItem (grdBeams.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { grdBeams.ComboBox (e.Col).Items.Count - 1 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 5:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.NoUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [0] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 6:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1000 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 7:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.LengthUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [2] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1200 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 8:
			case 9:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -100 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			}
			tag = null;
			blnCodeChange = true;
			txtEditBeam.Text = grdBeams.Cell (e.Row, e.Col).Text;
		}
		if (CFSInterface.Validate (txtEditBeam, blnShowUnit: false)) {
			CFSInterface.StoreUndoAnl ("Member");
			if (e.Row > CFS.Analyses [CFS.intAnlNow].nBeam && !CFSInterface.AddBeam (CFS.Analyses [CFS.intAnlNow])) {
				return;
			}
			ref Beam reference = ref CFS.Analyses [CFS.intAnlNow].Beam [e.Row];
			switch (e.Col) {
			case 1:
				reference.iSct = Conversions.ToByte (NewLateBinding.LateGet (grdBeams.ComboBox (1).Items [Conversions.ToInteger (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null))], null, "ItemData", new object[0], null, null, null));
				break;
			case 2:
				CheckMove (reference.Z0, Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null)));
				reference.Z0 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 3:
				CheckMove (reference.Z1, Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null)));
				reference.Z1 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 4:
				reference.iBrcFlg = Conversions.ToByte (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 5:
				reference.R = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 6:
				reference.Kf = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 7:
				reference.Lm = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 8:
				reference.ex = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 9:
				reference.ey = Conversions.ToSingle (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Value", new object[0], null, null, null));
				break;
			}
			Analysis obj = CFS.Analyses [CFS.intAnlNow];
			obj.Saved = false;
			obj.RevDate = DateAndTime.Now;
			obj.RevBy = CFS.User.Name;
			obj.iCombSol = 0;
			if (CFS.blnRefreshGrdBeams) {
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			} else {
				grdBeams.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditBeam.Tag, null, "Text", new object[0], null, null, null));
			}
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.SetMenuEdit ();
			_ = null;
		} else {
			ref Beam reference2 = ref CFS.Analyses [CFS.intAnlNow].Beam [e.Row];
			string text = string.Empty;
			switch (e.Col) {
			case 1:
				text = CFSInterface.GetFileNameWithoutExtension (CFS.Sections [reference2.iSct].Filename);
				break;
			case 2:
				text = Units.DisplayLength (reference2.Z0, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 3:
				text = Units.DisplayLength (reference2.Z1, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 4:
				text = CFSInterface.DisplayFlange ((Flanges)reference2.iBrcFlg);
				break;
			case 5:
				text = Units.FormatNum (reference2.R);
				break;
			case 6:
				text = Units.DisplayForce (reference2.Kf, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 7:
				text = Units.DisplayLength (reference2.Lm, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 8:
				text = Units.DisplayLen1 (reference2.ex, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 9:
				text = Units.DisplayLen1 (reference2.ey, 0, blnShowUnit: false, "", 0, 0);
				break;
			}
			grdBeams.Cell (e.Row, e.Col).Text = text;
		}
		blnCodeChange = false;
	}

	private void CheckMove (float Z, float Zmove)
	{
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		bool flag = false;
		int nSup = analysis.nSup;
		checked {
			for (int i = 1; i <= nSup; i++) {
				if (analysis.Sup [i].Z == Z) {
					flag = true;
				}
			}
			if (flag && Interaction.MsgBox ("Move matching support locations?", MsgBoxStyle.YesNo | MsgBoxStyle.Question) == MsgBoxResult.Yes) {
				int nSup2 = analysis.nSup;
				for (int j = 1; j <= nSup2; j++) {
					if (analysis.Sup [j].Z == Z) {
						analysis.Sup [j].Z = Zmove;
					}
				}
				CFS.blnRefreshGrdSupports = true;
			}
			flag = false;
			int nLdg = analysis.nLdg;
			for (int k = 1; k <= nLdg; k++) {
				int nLoad = analysis.Ldg [k].nLoad;
				for (int l = 1; l <= nLoad; l++) {
					ref Load reference = ref analysis.Ldg [k].Load [l];
					if ((reference.Z0 == Z) | (reference.Z1 == Z)) {
						flag = true;
					}
				}
			}
			if (flag && Interaction.MsgBox ("Move matching load locations?", MsgBoxStyle.YesNo | MsgBoxStyle.Question) == MsgBoxResult.Yes) {
				int nLdg2 = analysis.nLdg;
				for (int m = 1; m <= nLdg2; m++) {
					int nLoad2 = analysis.Ldg [m].nLoad;
					for (int n = 1; n <= nLoad2; n++) {
						ref Load reference2 = ref analysis.Ldg [m].Load [n];
						if (reference2.Z0 == Z) {
							reference2.Z0 = Zmove;
						}
						if (reference2.Z1 == Z) {
							reference2.Z1 = Zmove;
						}
					}
				}
				CFS.blnRefreshGrdLoads = true;
			}
			analysis = null;
		}
	}

	private void grdBeams_KeyDown (object sender, KeyEventArgs e)
	{
		checked {
			if (!grdBeams.EditorVisible) {
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
				_ = CFS.Analyses [CFS.intAnlNow];
				if (unchecked(e.KeyCode == Keys.Delete && (b == 0 || b == 1))) {
					CFSInterface.DeleteBeams (CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.X && b == 2)) {
					CFSInterface.CopyBeams (CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
					CFSInterface.DeleteBeams (CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.C && b == 2)) {
					CFSInterface.CopyBeams (CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.V && b == 2)) {
					CFSInterface.PasteBeams (CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Apps && b == 0)) {
					My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (grdBeams, (int)Math.Round ((double)grdBeams.Width / 2.0), (int)Math.Round ((double)grdBeams.Height / 2.0));
					e.Handled = true;
				}
				_ = null;
			}
		}
	}

	private void grdBeams_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}

	private void grdBeams_SelChange (object sender, Grid.SelChangeEventArgs e)
	{
		checked {
			if (CFS.blnValidate) {
				ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
				beamGrid.TopRow = (byte)grdBeams.TopRow;
				beamGrid.LeftCol = (byte)grdBeams.LeftCol;
				beamGrid.ColStart = (byte)grdBeams.Selection.FirstCol;
				beamGrid.ColEnd = (byte)grdBeams.Selection.LastCol;
				if (unchecked((uint)beamGrid.ColStart > (uint)beamGrid.ColEnd)) {
					CFS.Swap (ref beamGrid.ColStart, ref beamGrid.ColEnd);
				}
				beamGrid.Corner = 0;
				if (grdBeams.ActiveCell.Col > grdBeams.Selection.FirstCol) {
					beamGrid.Corner = (byte)(beamGrid.Corner | 1);
				}
				if (grdBeams.ActiveCell.Row > grdBeams.Selection.FirstRow) {
					beamGrid.Corner = (byte)(beamGrid.Corner | 2);
				}
				if ((grdBeams.Selection.FirstRow != beamGrid.RowStart) | (grdBeams.Selection.LastRow != beamGrid.RowEnd)) {
					CFSInterface.SelectAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow], (byte)grdBeams.Selection.FirstRow, (byte)grdBeams.Selection.LastRow);
				}
			}
		}
	}

	private void grdSupports_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditSup.Tag;
		switch (e.Col) {
		case 1:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdSupports.ComboBox (e.Col).FindItem (grdSupports.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { checked(grdSupports.ComboBox (e.Col).Items.Count - 1) }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.LengthUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [2] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -48000 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 48000 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 3:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0.75 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 4:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Interaction.IIf (Conversions.ToBoolean (grdSupports.Cell (e.Row, e.Col).Text), 1, 0) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 5:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.NoUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [0] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 5 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEditSup.Text = grdSupports.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEditSup, blnShowUnit: false)) {
			CFSInterface.StoreUndoAnl ("Support");
			if (e.Row > CFS.Analyses [CFS.intAnlNow].nSup && !CFSInterface.AddSup (CFS.Analyses [CFS.intAnlNow])) {
				return;
			}
			ref Support reference = ref CFS.Analyses [CFS.intAnlNow].Sup [e.Row];
			switch (e.Col) {
			case 1:
				reference.Type = Conversions.ToByte (NewLateBinding.LateGet (grdSupports.ComboBox (e.Col).Items [Conversions.ToInteger (NewLateBinding.LateGet (txtEditSup.Tag, null, "Value", new object[0], null, null, null))], null, "ItemData", new object[0], null, null, null));
				break;
			case 2:
				reference.Z = Conversions.ToSingle (NewLateBinding.LateGet (txtEditSup.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 3:
				reference.Wid = Conversions.ToSingle (NewLateBinding.LateGet (txtEditSup.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 4:
				reference.Fastened = Conversions.ToBoolean (NewLateBinding.LateGet (txtEditSup.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 5:
				reference.K = Conversions.ToSingle (NewLateBinding.LateGet (txtEditSup.Tag, null, "Value", new object[0], null, null, null));
				break;
			}
			Analysis obj = CFS.Analyses [CFS.intAnlNow];
			obj.Saved = false;
			obj.RevDate = DateAndTime.Now;
			obj.RevBy = CFS.User.Name;
			obj.iCombSol = 0;
			if (CFS.blnRefreshGrdSupports) {
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			} else {
				grdSupports.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditSup.Tag, null, "Text", new object[0], null, null, null));
			}
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.SetMenuEdit ();
			_ = null;
		} else {
			ref Support reference2 = ref CFS.Analyses [CFS.intAnlNow].Sup [e.Row];
			string text = string.Empty;
			switch (e.Col) {
			case 1:
				text = CFSInterface.DisplaySup ((Supports)reference2.Type);
				break;
			case 2:
				text = Units.DisplayLength (reference2.Z, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 3:
				text = Units.DisplayLen1 (reference2.Wid, 0, blnShowUnit: false, "", 0, 0);
				break;
			case 4:
				text = Conversions.ToString (reference2.Fastened);
				break;
			case 5:
				text = Units.FormatNum (reference2.K);
				break;
			}
			grdSupports.Cell (e.Row, e.Col).Text = text;
		}
		blnCodeChange = false;
	}

	private void grdSupports_KeyDown (object sender, KeyEventArgs e)
	{
		checked {
			if (!grdSupports.EditorVisible) {
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
				_ = CFS.Analyses [CFS.intAnlNow];
				if (unchecked(e.KeyCode == Keys.Delete && (b == 0 || b == 1))) {
					CFSInterface.DeleteSupports (CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.X && b == 2)) {
					CFSInterface.CopySupports (CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
					CFSInterface.DeleteSupports (CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.C && b == 2)) {
					CFSInterface.CopySupports (CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.V && b == 2)) {
					CFSInterface.PasteSupports (CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Apps && b == 0)) {
					My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (grdSupports, (int)Math.Round ((double)grdSupports.Width / 2.0), (int)Math.Round ((double)grdSupports.Height / 2.0));
					e.Handled = true;
				}
				_ = null;
			}
		}
	}

	private void grdSupports_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}

	private void grdSupports_SelChange (object sender, Grid.SelChangeEventArgs e)
	{
		checked {
			if (CFS.blnValidate) {
				ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
				supGrid.TopRow = (byte)grdSupports.TopRow;
				supGrid.LeftCol = (byte)grdSupports.LeftCol;
				supGrid.ColStart = (byte)grdSupports.Selection.FirstCol;
				supGrid.ColEnd = (byte)grdSupports.Selection.LastCol;
				if (unchecked((uint)supGrid.ColStart > (uint)supGrid.ColEnd)) {
					CFS.Swap (ref supGrid.ColStart, ref supGrid.ColEnd);
				}
				supGrid.Corner = 0;
				if (grdSupports.ActiveCell.Col > grdSupports.Selection.FirstCol) {
					supGrid.Corner = (byte)(supGrid.Corner | 1);
				}
				if (grdSupports.ActiveCell.Row > grdSupports.Selection.FirstRow) {
					supGrid.Corner = (byte)(supGrid.Corner | 2);
				}
				if ((grdSupports.Selection.FirstRow != supGrid.RowStart) | (grdSupports.Selection.LastRow != supGrid.RowEnd)) {
					CFSInterface.SelectAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow], (byte)grdSupports.Selection.FirstRow, (byte)grdSupports.Selection.LastRow);
				}
			}
		}
	}

	private void grdLoads_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditLoad.Tag;
		switch (e.Col) {
		case 1:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdLoads.ComboBox (e.Col).FindItem (grdLoads.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { checked(grdLoads.ComboBox (e.Col).Items.Count - 1) }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.AngleUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [3] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -Math.PI }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { Math.PI * 2.0 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 3:
		case 4:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.LengthUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [2] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -48000 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 48000 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 5:
		case 6:
			switch (CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].Load [e.Row].Type) {
			case 1:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.LoadUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [11] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -100 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			case 2:
			case 3:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -1000 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1000 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			default:
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.MomentUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [6] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -100000 }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100000 }, null, null, OptimisticSet: false, RValueBase: true);
				break;
			}
			break;
		case 8:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.Len1Unit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [1] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0.75 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEditLoad.Text = grdLoads.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEditLoad, blnShowUnit: false)) {
			CFSInterface.StoreUndoAnl ("Load");
			if (e.Row > CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].nLoad && !CFSInterface.AddLoad (CFS.Analyses [CFS.intAnlNow], ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg])) {
				return;
			}
			ref Load reference = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].Load [e.Row];
			switch (e.Col) {
			case 1: {
				if ((uint)CFS.Analyses [CFS.intAnlNow].iLdg > (uint)CFS.Analyses [CFS.intAnlNow].nLdg) {
					CFS.Analyses [CFS.intAnlNow].nLdg = CFS.Analyses [CFS.intAnlNow].iLdg;
				}
				byte b = Conversions.ToByte (Operators.AddObject (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null), 1));
				switch (reference.Type) {
				case 1:
					if (b == 2) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
						reference.Wid = 1f;
					}
					if (b == 3) {
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					if (b == 4) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					break;
				case 2:
					if (b == 1) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					if (b == 3) {
						reference.Z1 = reference.Z0;
						reference.W1 = reference.W0;
					}
					if (b == 4) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					break;
				case 3:
					if (b == 1) {
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					if (b == 2) {
						reference.Z1 = reference.Z0;
						reference.W1 = 0f;
						reference.Wid = 1f;
					}
					if (b == 4) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					break;
				case 4:
					if (b == 1) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					if (b == 2) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
						reference.Wid = 1f;
					}
					if (b == 3) {
						reference.Z1 = reference.Z0;
						reference.W0 = 0f;
						reference.W1 = 0f;
					}
					break;
				}
				reference.Type = b;
				break;
			}
			case 2:
				reference.Ang = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 3:
				reference.Z0 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				if (reference.Type == 2) {
					reference.Z1 = reference.Z0;
				}
				if (reference.Type == 4) {
					reference.Z1 = reference.Z0;
				}
				break;
			case 4:
				reference.Z1 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 5:
				reference.W0 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				if (reference.Type == 3) {
					reference.W1 = reference.W0;
				}
				break;
			case 6:
				reference.W1 = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				if (reference.Type == 3) {
					reference.W0 = reference.W1;
				}
				break;
			case 8:
				reference.Wid = Conversions.ToSingle (NewLateBinding.LateGet (txtEditLoad.Tag, null, "Value", new object[0], null, null, null));
				break;
			}
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			if (analysis.iCombSol > 0) {
				int nLF = analysis.Comb [analysis.iCombSol].nLF;
				for (int i = 1; i <= nLF; i = checked(i + 1)) {
					if (analysis.Comb [analysis.iCombSol].LF [i].iLdg == analysis.iLdg) {
						analysis.iCombSol = 0;
						break;
					}
				}
			}
			CFS.blnRefreshGrdLoads = true;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			CFSInterface.SetMenuEdit ();
			analysis = null;
		} else {
			CFS.blnRefreshGrdLoads = true;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		}
		blnCodeChange = false;
	}

	private void grdLoads_KeyDown (object sender, KeyEventArgs e)
	{
		checked {
			if (!grdLoads.EditorVisible) {
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
				if (unchecked(e.KeyCode == Keys.Delete && (b == 0 || b == 1))) {
					CFSInterface.DeleteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.X && b == 2)) {
					CFSInterface.CopyLoads (ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg], (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
					CFSInterface.DeleteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.C && b == 2)) {
					CFSInterface.CopyLoads (ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg], (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.V && b == 2)) {
					CFSInterface.PasteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Apps && b == 0)) {
					My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (grdLoads, (int)Math.Round ((double)grdLoads.Width / 2.0), (int)Math.Round ((double)grdLoads.Height / 2.0));
					e.Handled = true;
				}
			}
		}
	}

	private void grdLoads_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}

	private void grdLoads_SelChange (object sender, Grid.SelChangeEventArgs e)
	{
		checked {
			if (CFS.blnValidate) {
				ref GridState loadGrid = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].LoadGrid;
				loadGrid.TopRow = (byte)grdLoads.TopRow;
				loadGrid.LeftCol = (byte)grdLoads.LeftCol;
				loadGrid.ColStart = (byte)grdLoads.Selection.FirstCol;
				loadGrid.ColEnd = (byte)grdLoads.Selection.LastCol;
				if (unchecked((uint)loadGrid.ColStart > (uint)loadGrid.ColEnd)) {
					CFS.Swap (ref loadGrid.ColStart, ref loadGrid.ColEnd);
				}
				loadGrid.Corner = 0;
				if (grdLoads.ActiveCell.Col > grdLoads.Selection.FirstCol) {
					loadGrid.Corner = (byte)(loadGrid.Corner | 1);
				}
				if (grdLoads.ActiveCell.Row > grdLoads.Selection.FirstRow) {
					loadGrid.Corner = (byte)(loadGrid.Corner | 2);
				}
				if ((grdLoads.Selection.FirstRow != loadGrid.RowStart) | (grdLoads.Selection.LastRow != loadGrid.RowEnd)) {
					CFSInterface.SelectAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow], (byte)grdLoads.Selection.FirstRow, (byte)grdLoads.Selection.LastRow);
				}
			}
		}
	}

	private void grdCombs_CellChange (object sender, Grid.CellChangeEventArgs e)
	{
		if (blnCodeChange) {
			return;
		}
		object tag = txtEditComb.Tag;
		switch (e.Col) {
		case 1:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StringOnly }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { grdCombs.ComboBox (e.Col).FindItem (grdCombs.Cell (e.Row, e.Col).Text) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { 0 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { checked(grdCombs.ComboBox (e.Col).Items.Count - 1) }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		case 2:
			NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.NoUnit }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [0] }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Min", new object[1] { -10 }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 10 }, null, null, OptimisticSet: false, RValueBase: true);
			break;
		}
		tag = null;
		blnCodeChange = true;
		txtEditComb.Text = grdCombs.Cell (e.Row, e.Col).Text;
		if (CFSInterface.Validate (txtEditComb, blnShowUnit: false)) {
			CFSInterface.StoreUndoAnl ("Load Factor");
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			if (e.Row > analysis.Comb [analysis.iComb].nLF && !CFSInterface.AddLF (ref CFS.Analyses [CFS.intAnlNow].Comb [analysis.iComb])) {
				return;
			}
			if ((uint)analysis.iComb > (uint)analysis.nComb) {
				analysis.nComb = analysis.iComb;
			}
			switch (e.Col) {
			case 1:
				analysis.Comb [analysis.iComb].LF [e.Row].iLdg = Conversions.ToByte (NewLateBinding.LateGet (txtEditComb.Tag, null, "Value", new object[0], null, null, null));
				break;
			case 2:
				analysis.Comb [analysis.iComb].LF [e.Row].fLdg = Conversions.ToSingle (NewLateBinding.LateGet (txtEditComb.Tag, null, "Value", new object[0], null, null, null));
				break;
			}
			analysis.Saved = false;
			analysis.RevDate = DateAndTime.Now;
			analysis.RevBy = CFS.User.Name;
			if (analysis.iComb == analysis.iCombSol) {
				analysis.iCombSol = 0;
			}
			analysis = null;
			if (CFS.blnRefreshGrdCombs) {
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			} else {
				grdCombs.Cell (e.Row, e.Col).Text = Conversions.ToString (NewLateBinding.LateGet (txtEditComb.Tag, null, "Text", new object[0], null, null, null));
			}
			CFSInterface.SetMenuEdit ();
		} else {
			Analysis analysis2 = CFS.Analyses [CFS.intAnlNow];
			string text = string.Empty;
			switch (e.Col) {
			case 1:
				text = analysis2.Ldg [analysis2.Comb [analysis2.iComb].LF [e.Row].iLdg].Description;
				break;
			case 2:
				text = Units.FormatNum (analysis2.Comb [analysis2.iComb].LF [e.Row].fLdg);
				break;
			}
			grdCombs.Cell (e.Row, e.Col).Text = text;
			analysis2 = null;
		}
		blnCodeChange = false;
	}

	private void grdCombs_KeyDown (object sender, KeyEventArgs e)
	{
		checked {
			if (!grdCombs.EditorVisible) {
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
				if (unchecked(e.KeyCode == Keys.Delete && (b == 0 || b == 1))) {
					CFSInterface.DeleteLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, (byte)grdCombs.Selection.FirstRow, (byte)grdCombs.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.X && b == 2)) {
					CFSInterface.CopyLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, (byte)grdCombs.Selection.FirstRow, (byte)grdCombs.Selection.LastRow);
					CFSInterface.DeleteLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, (byte)grdCombs.Selection.FirstRow, (byte)grdCombs.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.C && b == 2)) {
					CFSInterface.CopyLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, (byte)grdCombs.Selection.FirstRow, (byte)grdCombs.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.V && b == 2)) {
					CFSInterface.PasteLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, (byte)grdCombs.Selection.FirstRow, (byte)grdCombs.Selection.LastRow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Apps && b == 0)) {
					My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (grdCombs, (int)Math.Round ((double)grdCombs.Width / 2.0), (int)Math.Round ((double)grdCombs.Height / 2.0));
					e.Handled = true;
				}
			}
		}
	}

	private void grdCombs_MouseDown (object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show ((Control)sender, e.X, e.Y);
		}
	}

	private void grdCombs_SelChange (object sender, Grid.SelChangeEventArgs e)
	{
		if (CFS.blnValidate) {
			ref GridState lFGrid = ref CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].LFGrid;
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
			CFSInterface.SetMenuEdit ();
		}
	}
}
