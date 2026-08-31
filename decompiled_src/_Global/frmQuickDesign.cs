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
public class frmQuickDesign : Form
{
	private IContainer components;

	private bool blnLoaded;

	private float sngSpacing;

	private float sngSpan;

	private float sngDeadLoad;

	private float sngLiveLoad;

	private float sngDeadAxial;

	private float sngLiveAxial;

	private float sngWindLoad;

	private byte bytStressUnit;

	private const double psftoksi = 6.9444444444444448E-06;

	private short intMaterial33;

	private short intMaterial50;

	private string strS33;

	private string strS50;

	private string strT33;

	private string strT50;

	private Analysis AnalysisQD;

	private short intSct;

	internal virtual ComboBox cboDepth {
		[CompilerGenerated]
		get {
			return _cboDepth;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_SelectedIndexChanged;
			ComboBox comboBox = _cboDepth;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboDepth = value;
			comboBox = _cboDepth;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox cboType {
		[CompilerGenerated]
		get {
			return _cboType;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_SelectedIndexChanged;
			ComboBox comboBox = _cboType;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboType = value;
			comboBox = _cboType;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox cboFlange {
		[CompilerGenerated]
		get {
			return _cboFlange;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_SelectedIndexChanged;
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

	[field: AccessedThroughProperty ("lblDash")]
	internal virtual Label lblDash {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboThickness {
		[CompilerGenerated]
		get {
			return _cboThickness;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSection_SelectedIndexChanged;
			ComboBox comboBox = _cboThickness;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboThickness = value;
			comboBox = _cboThickness;
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

	[field: AccessedThroughProperty ("lblInfo")]
	internal virtual Label lblInfo {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkPunched {
		[CompilerGenerated]
		get {
			return _chkPunched;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkPunched_CheckedChanged;
			CheckBox checkBox = _chkPunched;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkPunched = value;
			checkBox = _chkPunched;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual ComboBox cboConfig {
		[CompilerGenerated]
		get {
			return _cboConfig;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboConfig_SelectedIndexChanged;
			ComboBox comboBox = _cboConfig;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboConfig = value;
			comboBox = _cboConfig;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
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

	[field: AccessedThroughProperty ("lblYield")]
	internal virtual Label lblYield {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboYield {
		[CompilerGenerated]
		get {
			return _cboYield;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboYield_SelectedIndexChanged;
			ComboBox comboBox = _cboYield;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboYield = value;
			comboBox = _cboYield;
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

	[field: AccessedThroughProperty ("lblSpan")]
	internal virtual Label lblSpan {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSpan {
		[CompilerGenerated]
		get {
			return _cboSpan;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDesign_GotFocus;
			KeyPressEventHandler value3 = cboDesign_KeyPress;
			EventHandler value4 = cboDesign_TextChanged;
			EventHandler value5 = cboDesign_DropDown;
			EventHandler value6 = cboDesign_SelectedIndexChanged;
			CancelEventHandler value7 = cboDesign_Validating;
			ComboBox comboBox = _cboSpan;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboSpan = value;
			comboBox = _cboSpan;
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

	[field: AccessedThroughProperty ("lblSpans")]
	internal virtual Label lblSpans {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSpans {
		[CompilerGenerated]
		get {
			return _cboSpans;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSpans_SelectedIndexChanged;
			ComboBox comboBox = _cboSpans;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSpans = value;
			comboBox = _cboSpans;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblBracing")]
	internal virtual Label lblBracing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboBracing {
		[CompilerGenerated]
		get {
			return _cboBracing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboBracing_SelectedIndexChanged;
			ComboBox comboBox = _cboBracing;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboBracing = value;
			comboBox = _cboBracing;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual RadioButton optBeam {
		[CompilerGenerated]
		get {
			return _optBeam;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optBeamColumn_CheckedChanged;
			RadioButton radioButton = _optBeam;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optBeam = value;
			radioButton = _optBeam;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton optColumn {
		[CompilerGenerated]
		get {
			return _optColumn;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optBeamColumn_CheckedChanged;
			RadioButton radioButton = _optColumn;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optColumn = value;
			radioButton = _optColumn;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblDeadLoad")]
	internal virtual Label lblDeadLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboDeadLoad {
		[CompilerGenerated]
		get {
			return _cboDeadLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDesign_GotFocus;
			KeyPressEventHandler value3 = cboDesign_KeyPress;
			EventHandler value4 = cboDesign_TextChanged;
			EventHandler value5 = cboDesign_DropDown;
			EventHandler value6 = cboDesign_SelectedIndexChanged;
			CancelEventHandler value7 = cboDesign_Validating;
			ComboBox comboBox = _cboDeadLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboDeadLoad = value;
			comboBox = _cboDeadLoad;
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

	[field: AccessedThroughProperty ("lblLiveLoad")]
	internal virtual Label lblLiveLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLiveLoad {
		[CompilerGenerated]
		get {
			return _cboLiveLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDesign_GotFocus;
			KeyPressEventHandler value3 = cboDesign_KeyPress;
			EventHandler value4 = cboDesign_TextChanged;
			EventHandler value5 = cboDesign_DropDown;
			EventHandler value6 = cboDesign_SelectedIndexChanged;
			CancelEventHandler value7 = cboDesign_Validating;
			ComboBox comboBox = _cboLiveLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLiveLoad = value;
			comboBox = _cboLiveLoad;
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

	[field: AccessedThroughProperty ("lblWindLoad")]
	internal virtual Label lblWindLoad {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboWindLoad {
		[CompilerGenerated]
		get {
			return _cboWindLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDesign_GotFocus;
			KeyPressEventHandler value3 = cboDesign_KeyPress;
			EventHandler value4 = cboDesign_TextChanged;
			EventHandler value5 = cboDesign_DropDown;
			EventHandler value6 = cboDesign_SelectedIndexChanged;
			CancelEventHandler value7 = cboDesign_Validating;
			ComboBox comboBox = _cboWindLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboWindLoad = value;
			comboBox = _cboWindLoad;
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

	[field: AccessedThroughProperty ("lblUnityAB")]
	internal virtual Label lblUnityAB {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtUnityAB")]
	internal virtual TextBox txtUnityAB {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblUnitySB")]
	internal virtual Label lblUnitySB {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtUnitySB")]
	internal virtual TextBox txtUnitySB {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdCalculate {
		[CompilerGenerated]
		get {
			return _cmdCalculate;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCalculate_Click;
			Button button = _cmdCalculate;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCalculate = value;
			button = _cmdCalculate;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdReport {
		[CompilerGenerated]
		get {
			return _cmdReport;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdReport_Click;
			Button button = _cmdReport;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdReport = value;
			button = _cmdReport;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdCreate {
		[CompilerGenerated]
		get {
			return _cmdCreate;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCreate_Click;
			Button button = _cmdCreate;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCreate = value;
			button = _cmdCreate;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("cmdClose")]
	internal virtual Button cmdClose {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblSpacing")]
	internal virtual Label lblSpacing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSpacing {
		[CompilerGenerated]
		get {
			return _cboSpacing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDesign_GotFocus;
			KeyPressEventHandler value3 = cboDesign_KeyPress;
			EventHandler value4 = cboDesign_TextChanged;
			EventHandler value5 = cboDesign_DropDown;
			EventHandler value6 = cboDesign_SelectedIndexChanged;
			CancelEventHandler value7 = cboDesign_Validating;
			ComboBox comboBox = _cboSpacing;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboSpacing = value;
			comboBox = _cboSpacing;
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

	[field: AccessedThroughProperty ("lblLine")]
	internal virtual Label lblLine {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblSpecNow")]
	internal virtual Label lblSpecNow {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Label1")]
	internal virtual Label Label1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmQuickDesign ()
	{
		base.Load += frmQuickDesign_Load;
		base.HelpButtonClicked += frmQuickDesign_HelpButtonClicked;
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
		this.cboDepth = new System.Windows.Forms.ComboBox ();
		this.cboType = new System.Windows.Forms.ComboBox ();
		this.cboFlange = new System.Windows.Forms.ComboBox ();
		this.lblDash = new System.Windows.Forms.Label ();
		this.cboThickness = new System.Windows.Forms.ComboBox ();
		this.lblSection = new System.Windows.Forms.Label ();
		this.lblInfo = new System.Windows.Forms.Label ();
		this.chkPunched = new System.Windows.Forms.CheckBox ();
		this.cboConfig = new System.Windows.Forms.ComboBox ();
		this.chkColdWork = new System.Windows.Forms.CheckBox ();
		this.chkReserve = new System.Windows.Forms.CheckBox ();
		this.lblYield = new System.Windows.Forms.Label ();
		this.cboYield = new System.Windows.Forms.ComboBox ();
		this.lblSpec = new System.Windows.Forms.Label ();
		this.lblSpan = new System.Windows.Forms.Label ();
		this.cboSpan = new System.Windows.Forms.ComboBox ();
		this.lblSpans = new System.Windows.Forms.Label ();
		this.cboSpans = new System.Windows.Forms.ComboBox ();
		this.lblBracing = new System.Windows.Forms.Label ();
		this.cboBracing = new System.Windows.Forms.ComboBox ();
		this.optBeam = new System.Windows.Forms.RadioButton ();
		this.optColumn = new System.Windows.Forms.RadioButton ();
		this.lblDeadLoad = new System.Windows.Forms.Label ();
		this.cboDeadLoad = new System.Windows.Forms.ComboBox ();
		this.lblLiveLoad = new System.Windows.Forms.Label ();
		this.cboLiveLoad = new System.Windows.Forms.ComboBox ();
		this.lblWindLoad = new System.Windows.Forms.Label ();
		this.cboWindLoad = new System.Windows.Forms.ComboBox ();
		this.lblUnityAB = new System.Windows.Forms.Label ();
		this.txtUnityAB = new System.Windows.Forms.TextBox ();
		this.lblUnitySB = new System.Windows.Forms.Label ();
		this.txtUnitySB = new System.Windows.Forms.TextBox ();
		this.cmdCalculate = new System.Windows.Forms.Button ();
		this.cmdReport = new System.Windows.Forms.Button ();
		this.cmdCreate = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.lblSpacing = new System.Windows.Forms.Label ();
		this.cboSpacing = new System.Windows.Forms.ComboBox ();
		this.lblLine = new System.Windows.Forms.Label ();
		this.lblSpecNow = new System.Windows.Forms.Label ();
		this.Label1 = new System.Windows.Forms.Label ();
		base.SuspendLayout ();
		this.cboDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDepth.FormattingEnabled = true;
		this.cboDepth.Location = new System.Drawing.Point (80, 8);
		this.cboDepth.Name = "cboDepth";
		this.cboDepth.Size = new System.Drawing.Size (48, 21);
		this.cboDepth.TabIndex = 3;
		this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboType.FormattingEnabled = true;
		this.cboType.Location = new System.Drawing.Point (130, 8);
		this.cboType.Name = "cboType";
		this.cboType.Size = new System.Drawing.Size (32, 21);
		this.cboType.TabIndex = 4;
		this.cboFlange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFlange.FormattingEnabled = true;
		this.cboFlange.Location = new System.Drawing.Point (164, 8);
		this.cboFlange.Name = "cboFlange";
		this.cboFlange.Size = new System.Drawing.Size (44, 21);
		this.cboFlange.TabIndex = 5;
		this.lblDash.AutoSize = true;
		this.lblDash.Location = new System.Drawing.Point (208, 11);
		this.lblDash.Name = "lblDash";
		this.lblDash.Size = new System.Drawing.Size (12, 13);
		this.lblDash.TabIndex = 6;
		this.lblDash.Text = "–";
		this.cboThickness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboThickness.FormattingEnabled = true;
		this.cboThickness.Location = new System.Drawing.Point (220, 8);
		this.cboThickness.Name = "cboThickness";
		this.cboThickness.Size = new System.Drawing.Size (42, 21);
		this.cboThickness.TabIndex = 7;
		this.lblSection.AutoSize = true;
		this.lblSection.Location = new System.Drawing.Point (15, 11);
		this.lblSection.Name = "lblSection";
		this.lblSection.Size = new System.Drawing.Size (43, 13);
		this.lblSection.TabIndex = 2;
		this.lblSection.Text = "Section";
		this.lblInfo.AutoSize = true;
		this.lblInfo.Location = new System.Drawing.Point (77, 32);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size (169, 13);
		this.lblInfo.TabIndex = 9;
		this.lblInfo.Text = "Reference AISI Standard S201-17";
		this.chkPunched.AutoSize = true;
		this.chkPunched.Location = new System.Drawing.Point (80, 78);
		this.chkPunched.Name = "chkPunched";
		this.chkPunched.Size = new System.Drawing.Size (69, 17);
		this.chkPunched.TabIndex = 12;
		this.chkPunched.Text = "Punched";
		this.chkPunched.UseVisualStyleBackColor = true;
		this.cboConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboConfig.FormattingEnabled = true;
		this.cboConfig.Location = new System.Drawing.Point (268, 8);
		this.cboConfig.Name = "cboConfig";
		this.cboConfig.Size = new System.Drawing.Size (92, 21);
		this.cboConfig.TabIndex = 8;
		this.chkColdWork.AutoSize = true;
		this.chkColdWork.Location = new System.Drawing.Point (220, 54);
		this.chkColdWork.Name = "chkColdWork";
		this.chkColdWork.Size = new System.Drawing.Size (122, 17);
		this.chkColdWork.TabIndex = 13;
		this.chkColdWork.Text = "Cold work of forming";
		this.chkColdWork.UseVisualStyleBackColor = true;
		this.chkReserve.AutoSize = true;
		this.chkReserve.Location = new System.Drawing.Point (220, 78);
		this.chkReserve.Name = "chkReserve";
		this.chkReserve.Size = new System.Drawing.Size (103, 17);
		this.chkReserve.TabIndex = 14;
		this.chkReserve.Text = "Inelastic reserve";
		this.chkReserve.UseVisualStyleBackColor = true;
		this.lblYield.AutoSize = true;
		this.lblYield.Location = new System.Drawing.Point (15, 55);
		this.lblYield.Name = "lblYield";
		this.lblYield.Size = new System.Drawing.Size (18, 13);
		this.lblYield.TabIndex = 10;
		this.lblYield.Text = "Fy";
		this.cboYield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboYield.FormattingEnabled = true;
		this.cboYield.Location = new System.Drawing.Point (80, 52);
		this.cboYield.Name = "cboYield";
		this.cboYield.Size = new System.Drawing.Size (114, 21);
		this.cboYield.TabIndex = 11;
		this.lblSpec.AutoSize = true;
		this.lblSpec.Location = new System.Drawing.Point (15, 225);
		this.lblSpec.Name = "lblSpec";
		this.lblSpec.Size = new System.Drawing.Size (68, 13);
		this.lblSpec.TabIndex = 32;
		this.lblSpec.Text = "Specification";
		this.lblSpan.AutoSize = true;
		this.lblSpan.Location = new System.Drawing.Point (15, 136);
		this.lblSpan.Name = "lblSpan";
		this.lblSpan.Size = new System.Drawing.Size (32, 13);
		this.lblSpan.TabIndex = 18;
		this.lblSpan.Text = "Span";
		this.cboSpan.FormattingEnabled = true;
		this.cboSpan.Location = new System.Drawing.Point (80, 133);
		this.cboSpan.Name = "cboSpan";
		this.cboSpan.Size = new System.Drawing.Size (114, 21);
		this.cboSpan.TabIndex = 19;
		this.lblSpans.AutoSize = true;
		this.lblSpans.Location = new System.Drawing.Point (15, 163);
		this.lblSpans.Name = "lblSpans";
		this.lblSpans.Size = new System.Drawing.Size (37, 13);
		this.lblSpans.TabIndex = 20;
		this.lblSpans.Text = "Spans";
		this.cboSpans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSpans.FormattingEnabled = true;
		this.cboSpans.Location = new System.Drawing.Point (80, 160);
		this.cboSpans.Name = "cboSpans";
		this.cboSpans.Size = new System.Drawing.Size (114, 21);
		this.cboSpans.TabIndex = 21;
		this.lblBracing.AutoSize = true;
		this.lblBracing.Location = new System.Drawing.Point (15, 190);
		this.lblBracing.Name = "lblBracing";
		this.lblBracing.Size = new System.Drawing.Size (43, 13);
		this.lblBracing.TabIndex = 22;
		this.lblBracing.Text = "Bracing";
		this.cboBracing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBracing.FormattingEnabled = true;
		this.cboBracing.Location = new System.Drawing.Point (80, 187);
		this.cboBracing.Name = "cboBracing";
		this.cboBracing.Size = new System.Drawing.Size (114, 21);
		this.cboBracing.TabIndex = 23;
		this.optBeam.AutoSize = true;
		this.optBeam.Location = new System.Drawing.Point (80, 107);
		this.optBeam.Name = "optBeam";
		this.optBeam.Size = new System.Drawing.Size (57, 17);
		this.optBeam.TabIndex = 16;
		this.optBeam.TabStop = true;
		this.optBeam.Text = "Beams";
		this.optBeam.UseVisualStyleBackColor = true;
		this.optColumn.AutoSize = true;
		this.optColumn.Location = new System.Drawing.Point (143, 107);
		this.optColumn.Name = "optColumn";
		this.optColumn.Size = new System.Drawing.Size (65, 17);
		this.optColumn.TabIndex = 17;
		this.optColumn.TabStop = true;
		this.optColumn.Text = "Columns";
		this.optColumn.UseVisualStyleBackColor = true;
		this.lblDeadLoad.AutoSize = true;
		this.lblDeadLoad.Location = new System.Drawing.Point (217, 136);
		this.lblDeadLoad.Name = "lblDeadLoad";
		this.lblDeadLoad.Size = new System.Drawing.Size (60, 13);
		this.lblDeadLoad.TabIndex = 26;
		this.lblDeadLoad.Text = "Dead Load";
		this.cboDeadLoad.FormattingEnabled = true;
		this.cboDeadLoad.Location = new System.Drawing.Point (282, 133);
		this.cboDeadLoad.Name = "cboDeadLoad";
		this.cboDeadLoad.Size = new System.Drawing.Size (114, 21);
		this.cboDeadLoad.TabIndex = 27;
		this.lblLiveLoad.AutoSize = true;
		this.lblLiveLoad.Location = new System.Drawing.Point (217, 163);
		this.lblLiveLoad.Name = "lblLiveLoad";
		this.lblLiveLoad.Size = new System.Drawing.Size (54, 13);
		this.lblLiveLoad.TabIndex = 28;
		this.lblLiveLoad.Text = "Live Load";
		this.cboLiveLoad.FormattingEnabled = true;
		this.cboLiveLoad.Location = new System.Drawing.Point (282, 160);
		this.cboLiveLoad.Name = "cboLiveLoad";
		this.cboLiveLoad.Size = new System.Drawing.Size (114, 21);
		this.cboLiveLoad.TabIndex = 29;
		this.lblWindLoad.AutoSize = true;
		this.lblWindLoad.Location = new System.Drawing.Point (217, 190);
		this.lblWindLoad.Name = "lblWindLoad";
		this.lblWindLoad.Size = new System.Drawing.Size (59, 13);
		this.lblWindLoad.TabIndex = 30;
		this.lblWindLoad.Text = "Wind Load";
		this.cboWindLoad.FormattingEnabled = true;
		this.cboWindLoad.Location = new System.Drawing.Point (282, 187);
		this.cboWindLoad.Name = "cboWindLoad";
		this.cboWindLoad.Size = new System.Drawing.Size (114, 21);
		this.cboWindLoad.TabIndex = 31;
		this.lblUnityAB.AutoSize = true;
		this.lblUnityAB.Location = new System.Drawing.Point (15, 244);
		this.lblUnityAB.Name = "lblUnityAB";
		this.lblUnityAB.Size = new System.Drawing.Size (73, 13);
		this.lblUnityAB.TabIndex = 34;
		this.lblUnityAB.Text = "Axial/Bending";
		this.txtUnityAB.Location = new System.Drawing.Point (99, 241);
		this.txtUnityAB.Name = "txtUnityAB";
		this.txtUnityAB.ReadOnly = true;
		this.txtUnityAB.Size = new System.Drawing.Size (94, 20);
		this.txtUnityAB.TabIndex = 35;
		this.txtUnityAB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.lblUnitySB.AutoSize = true;
		this.lblUnitySB.Location = new System.Drawing.Point (216, 244);
		this.lblUnitySB.Name = "lblUnitySB";
		this.lblUnitySB.Size = new System.Drawing.Size (79, 13);
		this.lblUnitySB.TabIndex = 36;
		this.lblUnitySB.Text = "Shear/Bending";
		this.txtUnitySB.Location = new System.Drawing.Point (301, 241);
		this.txtUnitySB.Name = "txtUnitySB";
		this.txtUnitySB.ReadOnly = true;
		this.txtUnitySB.Size = new System.Drawing.Size (94, 20);
		this.txtUnitySB.TabIndex = 37;
		this.txtUnitySB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.cmdCalculate.Location = new System.Drawing.Point (12, 277);
		this.cmdCalculate.Name = "cmdCalculate";
		this.cmdCalculate.Size = new System.Drawing.Size (80, 25);
		this.cmdCalculate.TabIndex = 38;
		this.cmdCalculate.Text = "&Calculate";
		this.cmdCalculate.UseVisualStyleBackColor = true;
		this.cmdReport.Location = new System.Drawing.Point (108, 277);
		this.cmdReport.Name = "cmdReport";
		this.cmdReport.Size = new System.Drawing.Size (80, 25);
		this.cmdReport.TabIndex = 39;
		this.cmdReport.Text = "&Report";
		this.cmdReport.UseVisualStyleBackColor = true;
		this.cmdCreate.Location = new System.Drawing.Point (202, 277);
		this.cmdCreate.Name = "cmdCreate";
		this.cmdCreate.Size = new System.Drawing.Size (100, 25);
		this.cmdCreate.TabIndex = 40;
		this.cmdCreate.Text = "Create &Analysis";
		this.cmdCreate.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (316, 277);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (80, 25);
		this.cmdClose.TabIndex = 41;
		this.cmdClose.Text = "Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.lblSpacing.AutoSize = true;
		this.lblSpacing.Location = new System.Drawing.Point (216, 109);
		this.lblSpacing.Name = "lblSpacing";
		this.lblSpacing.Size = new System.Drawing.Size (46, 13);
		this.lblSpacing.TabIndex = 24;
		this.lblSpacing.Text = "Spacing";
		this.cboSpacing.FormattingEnabled = true;
		this.cboSpacing.Location = new System.Drawing.Point (282, 106);
		this.cboSpacing.Name = "cboSpacing";
		this.cboSpacing.Size = new System.Drawing.Size (114, 21);
		this.cboSpacing.TabIndex = 25;
		this.lblLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblLine.Location = new System.Drawing.Point (15, 100);
		this.lblLine.Name = "lblLine";
		this.lblLine.Size = new System.Drawing.Size (380, 1);
		this.lblLine.TabIndex = 15;
		this.lblSpecNow.AutoSize = true;
		this.lblSpecNow.Location = new System.Drawing.Point (96, 225);
		this.lblSpecNow.Name = "lblSpecNow";
		this.lblSpecNow.Size = new System.Drawing.Size (68, 13);
		this.lblSpecNow.TabIndex = 33;
		this.lblSpecNow.Text = "Specification";
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.Location = new System.Drawing.Point (15, 215);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size (380, 1);
		this.Label1.TabIndex = 42;
		base.AcceptButton = this.cmdCalculate;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (414, 314);
		base.Controls.Add (this.Label1);
		base.Controls.Add (this.lblSpecNow);
		base.Controls.Add (this.lblLine);
		base.Controls.Add (this.cboSpacing);
		base.Controls.Add (this.lblSpacing);
		base.Controls.Add (this.cmdClose);
		base.Controls.Add (this.cmdCreate);
		base.Controls.Add (this.cmdReport);
		base.Controls.Add (this.cmdCalculate);
		base.Controls.Add (this.txtUnitySB);
		base.Controls.Add (this.lblUnitySB);
		base.Controls.Add (this.txtUnityAB);
		base.Controls.Add (this.lblUnityAB);
		base.Controls.Add (this.cboWindLoad);
		base.Controls.Add (this.lblWindLoad);
		base.Controls.Add (this.cboLiveLoad);
		base.Controls.Add (this.lblLiveLoad);
		base.Controls.Add (this.cboDeadLoad);
		base.Controls.Add (this.lblDeadLoad);
		base.Controls.Add (this.optColumn);
		base.Controls.Add (this.optBeam);
		base.Controls.Add (this.cboBracing);
		base.Controls.Add (this.lblBracing);
		base.Controls.Add (this.cboSpans);
		base.Controls.Add (this.lblSpans);
		base.Controls.Add (this.cboSpan);
		base.Controls.Add (this.lblSpan);
		base.Controls.Add (this.lblSpec);
		base.Controls.Add (this.cboYield);
		base.Controls.Add (this.lblYield);
		base.Controls.Add (this.chkReserve);
		base.Controls.Add (this.chkColdWork);
		base.Controls.Add (this.cboConfig);
		base.Controls.Add (this.chkPunched);
		base.Controls.Add (this.lblInfo);
		base.Controls.Add (this.lblSection);
		base.Controls.Add (this.cboThickness);
		base.Controls.Add (this.lblDash);
		base.Controls.Add (this.cboFlange);
		base.Controls.Add (this.cboType);
		base.Controls.Add (this.cboDepth);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmQuickDesign";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "CFS Quick Design";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void InitializeSections ()
	{
		strS33 = "|162S125-18|162S125-27|162S125-30|162S125-33|250S125-18|250S125-27|250S125-30|250S125-33|250S125-43|250S125-54|250S125-68|250S137-33|250S137-43|250S137-54|250S137-68|250S137-97|250S162-33|250S162-43|250S162-54|250S162-68|250S162-97|250S200-33|250S200-43|250S200-54|250S200-68|250S200-97|250S250-43|250S250-54|250S250-68|250S250-97|350S125-18|350S125-27|350S125-30|350S125-33|350S125-43|350S125-54|350S125-68|350S137-33|350S137-43|350S137-54|350S137-68|350S137-97|350S162-33|350S162-43|350S162-54|350S162-68|350S162-97|350S200-33|350S200-43|350S200-54|350S200-68|350S200-97|350S250-43|350S250-54|350S250-68|350S250-97|362S125-18|362S125-27|362S125-30|362S125-33|362S125-43|362S125-54|362S125-68|362S137-33|362S137-43|362S137-54|362S137-68|362S137-97|362S162-33|362S162-43|362S162-54|362S162-68|362S162-97|362S200-33|362S200-43|362S200-54|362S200-68|362S200-97|362S250-33|362S250-43|362S250-54|362S250-68|362S250-97|362S300-33|362S300-43|362S300-54|362S300-68|362S300-97|400S125-18|400S125-27|400S125-30|400S125-33|400S125-43|400S125-54|400S125-68|400S137-33|400S137-43|400S137-54|400S137-68|400S137-97|400S162-33|400S162-43|400S162-54|400S162-68|400S162-97|400S200-33|400S200-43|400S200-54|400S200-68|400S200-97|400S250-33|400S250-43|400S250-54|400S250-68|400S250-97|400S300-33|400S300-43|400S300-54|400S300-68|400S300-97|550S125-18|550S125-27|550S125-30|550S125-33|550S125-43|550S125-54|550S125-68|550S137-33|550S137-43|550S137-54|550S137-68|550S137-97|550S162-33|550S162-43|550S162-54|550S162-68|550S162-97|550S200-33|550S200-43|550S200-54|550S200-68|550S200-97|550S250-43|550S250-54|550S250-68|550S250-97|600S125-18|600S125-27|600S125-30|600S125-33|600S125-43|600S125-54|600S125-68|600S137-33|600S137-43|600S137-54|600S137-68|600S137-97|600S137-118|600S162-33|600S162-43|600S162-54|600S162-68|600S162-97|600S162-118|600S200-33|600S200-43|600S200-54|600S200-68|600S200-97|600S200-118|600S250-43|600S250-54|600S250-68|600S250-97|600S250-118|600S300-54|600S300-68|600S300-97|600S300-118|600S350-54|600S350-68|600S350-97|600S350-118|800S125-33|800S125-43|800S125-54|800S125-68|800S137-33|800S137-43|800S137-54|800S137-68|800S137-97|800S137-118|800S162-33|800S162-43|800S162-54|800S162-68|800S162-97|800S162-118|800S200-33|800S200-43|800S200-54|800S200-68|800S200-97|800S200-118|800S250-43|800S250-54|800S250-68|800S250-97|800S250-118|800S300-54|800S300-68|800S300-97|800S300-118|800S350-54|800S350-68|800S350-97|800S350-118|1000S162-43|1000S162-54|1000S162-68|1000S162-97|1000S162-118|1000S200-43|1000S200-54|1000S200-68|1000S200-97|1000S200-118|1000S250-43|1000S250-54|1000S250-68|1000S250-97|1000S250-118|1000S300-54|1000S300-68|1000S300-97|1000S300-118|1000S350-54|1000S350-68|1000S350-97|1000S350-118|1200S162-54|1200S162-68|1200S162-97|1200S162-118|1200S200-54|1200S200-68|1200S200-97|1200S200-118|1200S250-54|1200S250-68|1200S250-97|1200S250-118|1200S300-54|1200S300-68|1200S300-97|1200S300-118|1200S350-54|1200S350-68|1200S350-97|1200S350-118|1400S162-54|1400S162-68|1400S162-97|1400S162-118|1400S200-54|1400S200-68|1400S200-97|1400S200-118|1400S250-54|1400S250-68|1400S250-97|1400S250-118|1400S300-54|1400S300-68|1400S300-97|1400S300-118|1400S350-54|1400S350-68|1400S350-97|1400S350-118|1600S162-68|1600S162-97|1600S162-118|1600S200-68|1600S200-97|1600S200-118|1600S250-68|1600S250-97|1600S250-118|1600S300-68|1600S300-97|1600S300-118|1600S350-68|1600S350-97|1600S350-118|";
		strS50 = "|250S125-54|250S125-68|250S137-54|250S137-68|250S137-97|250S162-54|250S162-68|250S162-97|250S200-54|250S200-68|250S200-97|250S250-54|250S250-68|250S250-97|350S125-54|350S125-68|350S137-54|350S137-68|350S137-97|350S162-54|350S162-68|350S162-97|350S200-54|350S200-68|350S200-97|350S250-54|350S250-68|350S250-97|362S125-54|362S125-68|362S137-54|362S137-68|362S137-97|362S162-54|362S162-68|362S162-97|362S200-54|362S200-68|362S200-97|362S250-54|362S250-68|362S250-97|362S300-54|362S300-68|362S300-97|400S125-54|400S125-68|400S137-54|400S137-68|400S137-97|400S162-54|400S162-68|400S162-97|400S200-54|400S200-68|400S200-97|400S250-54|400S250-68|400S250-97|400S300-54|400S300-68|400S300-97|550S125-54|550S125-68|550S137-54|550S137-68|550S137-97|550S162-54|550S162-68|550S162-97|550S200-54|550S200-68|550S200-97|550S250-54|550S250-68|550S250-97|600S125-54|600S125-68|600S137-54|600S137-68|600S137-97|600S137-118|600S162-54|600S162-68|600S162-97|600S162-118|600S200-54|600S200-68|600S200-97|600S200-118|600S250-54|600S250-68|600S250-97|600S250-118|600S300-54|600S300-68|600S300-97|600S300-118|600S350-54|600S350-68|600S350-97|600S350-118|800S125-54|800S125-68|800S137-54|800S137-68|800S137-97|800S137-118|800S162-54|800S162-68|800S162-97|800S162-118|800S200-54|800S200-68|800S200-97|800S200-118|800S250-54|800S250-68|800S250-97|800S250-118|800S300-54|800S300-68|800S300-97|800S300-118|800S350-54|800S350-68|800S350-97|800S350-118|1000S162-54|1000S162-68|1000S162-97|1000S162-118|1000S200-54|1000S200-68|1000S200-97|1000S200-118|1000S250-54|1000S250-68|1000S250-97|1000S250-118|1000S300-54|1000S300-68|1000S300-97|1000S300-118|1000S350-54|1000S350-68|1000S350-97|1000S350-118|1200S162-54|1200S162-68|1200S162-97|1200S162-118|1200S200-54|1200S200-68|1200S200-97|1200S200-118|1200S250-54|1200S250-68|1200S250-97|1200S250-118|1200S300-54|1200S300-68|1200S300-97|1200S300-118|1200S350-54|1200S350-68|1200S350-97|1200S350-118|1400S162-54|1400S162-68|1400S162-97|1400S162-118|1400S200-54|1400S200-68|1400S200-97|1400S200-118|1400S250-54|1400S250-68|1400S250-97|1400S250-118|1400S300-54|1400S300-68|1400S300-97|1400S300-118|1400S350-54|1400S350-68|1400S350-97|1400S350-118|1600S162-68|1600S162-97|1600S162-118|1600S200-68|1600S200-97|1600S200-118|1600S250-68|1600S250-97|1600S250-118|1600S300-68|1600S300-97|1600S300-118|1600S350-68|1600S350-97|1600S350-118|";
		strT33 = "|162T125-18|162T125-27|162T125-30|162T125-33|250T125-18|250T125-27|250T125-30|250T125-33|250T125-43|250T125-54|250T125-68|250T125-97|250T150-27|250T150-30|250T150-33|250T150-43|250T150-54|250T150-68|250T150-97|250T200-33|250T200-43|250T200-54|250T200-68|250T200-97|350T125-18|350T125-27|350T125-30|350T125-33|350T125-43|350T125-54|350T125-68|350T125-97|350T150-27|350T150-30|350T150-33|350T150-43|350T150-54|350T150-68|350T150-97|350T200-33|350T200-43|350T200-54|350T200-68|350T200-97|350T250-43|350T250-54|350T250-68|350T250-97|362T125-18|362T125-27|362T125-30|362T125-33|362T125-43|362T125-54|362T125-68|362T125-97|362T150-27|362T150-30|362T150-33|362T150-43|362T150-54|362T150-68|362T150-97|362T200-33|362T200-43|362T200-54|362T200-68|362T200-97|362T250-43|362T250-54|362T250-68|362T250-97|400T125-18|400T125-27|400T125-30|400T125-33|400T125-43|400T125-54|400T125-68|400T125-97|400T150-27|400T150-30|400T150-33|400T150-43|400T150-54|400T150-68|400T150-97|400T200-33|400T200-43|400T200-54|400T200-68|400T200-97|400T250-43|400T250-54|400T250-68|400T250-97|550T125-18|550T125-27|550T125-30|550T125-33|550T125-43|550T125-54|550T125-68|550T125-97|550T150-27|550T150-30|550T150-33|550T150-43|550T150-54|550T150-68|550T150-97|550T200-33|550T200-43|550T200-54|550T200-68|550T200-97|550T250-43|550T250-54|550T250-68|550T250-97|600T125-18|600T125-27|600T125-30|600T125-33|600T125-43|600T125-54|600T125-68|600T125-97|600T150-27|600T150-30|600T150-33|600T150-43|600T150-54|600T150-68|600T150-97|600T200-33|600T200-43|600T200-54|600T200-68|600T200-97|600T250-43|600T250-54|600T250-68|600T250-97|600T250-118|800T125-33|800T125-43|800T125-54|800T125-68|800T125-97|800T150-33|800T150-43|800T150-54|800T150-68|800T150-97|800T200-33|800T200-43|800T200-54|800T200-68|800T200-97|800T250-43|800T250-54|800T250-68|800T250-97|800T250-118|1000T125-43|1000T125-54|1000T125-68|1000T125-97|1000T150-43|1000T150-54|1000T150-68|1000T150-97|1000T200-43|1000T200-54|1000T200-68|1000T200-97|1000T250-43|1000T250-54|1000T250-68|1000T250-97|1000T250-118|1200T125-54|1200T125-68|1200T125-97|1200T150-54|1200T150-68|1200T150-97|1200T200-54|1200T200-68|1200T200-97|1200T200-118|1200T250-54|1200T250-68|1200T250-97|1200T250-118|1400T125-54|1400T125-68|1400T125-97|1400T125-118|1400T150-54|1400T150-68|1400T150-97|1400T150-118|1400T200-54|1400T200-68|1400T200-97|1400T200-118|1400T250-54|1400T250-68|1400T250-97|1400T250-118|1600T125-54|1600T125-68|1600T125-97|1600T125-118|1600T150-54|1600T150-68|1600T150-97|1600T150-118|1600T200-54|1600T200-68|1600T200-97|1600T200-118|1600T250-68|1600T250-97|1600T250-118|";
		strT50 = "|250T125-54|250T125-68|250T125-97|250T150-54|250T150-68|250T150-97|250T200-54|250T200-68|250T200-97|350T125-54|350T125-68|350T125-97|350T150-54|350T150-68|350T150-97|350T200-54|350T200-68|350T200-97|350T250-54|350T250-68|350T250-97|362T125-54|362T125-68|362T125-97|362T150-54|362T150-68|362T150-97|362T200-54|362T200-68|362T200-97|362T250-54|362T250-68|362T250-97|400T125-54|400T125-68|400T125-97|400T150-54|400T150-68|400T150-97|400T200-54|400T200-68|400T200-97|400T250-54|400T250-68|400T250-97|550T125-54|550T125-68|550T125-97|550T150-54|550T150-68|550T150-97|550T200-54|550T200-68|550T200-97|550T250-54|550T250-68|550T250-97|600T125-54|600T125-68|600T125-97|600T125-118|600T150-54|600T150-68|600T150-97|600T150-118|600T200-54|600T200-68|600T200-97|600T200-118|600T250-54|600T250-68|600T250-97|600T250-118|800T125-54|800T125-68|800T125-97|800T125-118|800T150-54|800T150-68|800T150-97|800T150-118|800T200-54|800T200-68|800T200-97|800T200-118|800T250-54|800T250-68|800T250-97|800T250-118|1000T125-54|1000T125-68|1000T125-97|1000T125-118|1000T150-54|1000T150-68|1000T150-97|1000T150-118|1000T200-54|1000T200-68|1000T200-97|1000T200-118|1000T250-54|1000T250-68|1000T250-97|1000T250-118|1200T125-54|1200T125-68|1200T125-97|1200T125-118|1200T150-54|1200T150-68|1200T150-97|1200T150-118|1200T200-54|1200T200-68|1200T200-97|1200T200-118|1200T250-54|1200T250-68|1200T250-97|1200T250-118|1400T125-54|1400T125-68|1400T125-97|1400T125-118|1400T150-54|1400T150-68|1400T150-97|1400T150-118|1400T200-54|1400T200-68|1400T200-97|1400T200-118|1400T250-54|1400T250-68|1400T250-97|1400T250-118|1600T125-54|1600T125-68|1600T125-97|1600T125-118|1600T150-54|1600T150-68|1600T150-97|1600T150-118|1600T200-54|1600T200-68|1600T200-97|1600T200-118|1600T250-68|1600T250-97|1600T250-118|";
	}

	private void CheckAvailability ()
	{
		bool flag = false;
		float num = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboFlange.SelectedItem, null, "ItemData", new object[0], null, null, null), 1000));
		float num2 = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboThickness.SelectedItem, null, "ItemData", new object[0], null, null, null), 10000));
		float num3 = Conversions.ToSingle (NewLateBinding.LateGet (cboYield.SelectedItem, null, "ItemData", new object[0], null, null, null));
		if (num > 0f) {
			string text = "|" + cboDepth.Text + cboType.Text + cboFlange.Text + "-";
			if (num2 > 0f) {
				text = text + cboThickness.Text + "|";
			}
			string left = cboType.Text;
			if (Operators.CompareString (left, "S", TextCompare: false) != 0) {
				if (Operators.CompareString (left, "T", TextCompare: false) == 0) {
					if ((num3 == 0f || num3 == 33f) && Strings.InStr (strT33, text) > 0) {
						flag = true;
					}
					if ((num3 == 0f || num3 == 50f) && Strings.InStr (strT50, text) > 0) {
						flag = true;
					}
				}
			} else {
				if ((num3 == 0f || num3 == 33f) && Strings.InStr (strS33, text) > 0) {
					flag = true;
				}
				if ((num3 == 0f || num3 == 50f) && Strings.InStr (strS50, text) > 0) {
					flag = true;
				}
			}
		} else {
			flag = true;
		}
		if (flag) {
			lblInfo.Text = "Reference AISI Standard S201-17";
			lblInfo.ForeColor = SystemColors.ControlText;
		} else {
			lblInfo.Text = "This section may not be readily available";
			lblInfo.ForeColor = Color.Red;
		}
	}

	private void ClearResults ()
	{
		txtUnityAB.Text = string.Empty;
		txtUnitySB.Text = string.Empty;
		cmdReport.Enabled = false;
		cmdCreate.Enabled = false;
	}

	private void frmQuickDesign_Load (object sender, EventArgs e)
	{
		intSct = CFSInterface.NewSctIndex ();
		CFS.hdgSctPic [intSct].Initialize ();
		AnalysisQD = null;
		if (strS33 == null) {
			InitializeSections ();
		}
		lblSpecNow.Text = CFS.strCSspec [CFS.intSpecNow];
		if (Units.DefaultUnitIndex [4] < 3) {
			if (bytStressUnit != 3) {
				blnLoaded = false;
			}
			bytStressUnit = 3;
		} else {
			if (bytStressUnit != 6) {
				blnLoaded = false;
			}
			bytStressUnit = 6;
		}
		if (blnLoaded) {
			CFS.blnValidate = true;
			ClearResults ();
			CheckAvailability ();
			return;
		}
		int num = Information.UBound (CFS.Materials);
		checked {
			for (int i = 1; i <= num; i++) {
				if (CFS.Materials [i].Name.StartsWith ("A653 SS")) {
					if ((intMaterial33 == 0) & (CFS.Materials [i].Fy [2] == 33f)) {
						intMaterial33 = (short)i;
					}
					if ((intMaterial50 == 0) & (CFS.Materials [i].Fy [2] == 50f)) {
						intMaterial50 = (short)i;
					}
				}
			}
			CFS.blnValidate = false;
			ComboBox.ObjectCollection items = cboDepth.Items;
			items.Clear ();
			items.Add (new ListItem ("162", 1625));
			items.Add (new ListItem ("250", 2500));
			items.Add (new ListItem ("350", 3500));
			items.Add (new ListItem ("362", 3625));
			items.Add (new ListItem ("400", 4000));
			items.Add (new ListItem ("550", 5500));
			items.Add (new ListItem ("600", 6000));
			items.Add (new ListItem ("800", 8000));
			items.Add (new ListItem ("1000", 10000));
			items.Add (new ListItem ("1200", 12000));
			items.Add (new ListItem ("1400", 14000));
			items.Add (new ListItem ("1600", 16000));
			_ = null;
			cboDepth.SelectedIndex = 6;
			ComboBox.ObjectCollection items2 = cboType.Items;
			items2.Clear ();
			items2.Add ("S");
			items2.Add ("T");
			_ = null;
			cboType.SelectedIndex = 0;
			ComboBox.ObjectCollection items3 = cboFlange.Items;
			items3.Clear ();
			items3.Add (new ListItem ("  ?", 0));
			items3.Add (new ListItem ("125", 1250));
			items3.Add (new ListItem ("137", 1375));
			items3.Add (new ListItem ("150", 1500));
			items3.Add (new ListItem ("162", 1625));
			items3.Add (new ListItem ("200", 2000));
			items3.Add (new ListItem ("250", 2500));
			items3.Add (new ListItem ("300", 3000));
			items3.Add (new ListItem ("350", 3500));
			_ = null;
			cboFlange.SelectedIndex = 0;
			ComboBox.ObjectCollection items4 = cboThickness.Items;
			items4.Clear ();
			items4.Add (new ListItem (" ?", 0));
			items4.Add (new ListItem ("18", 188));
			items4.Add (new ListItem ("27", 283));
			items4.Add (new ListItem ("30", 312));
			items4.Add (new ListItem ("33", 346));
			items4.Add (new ListItem ("43", 451));
			items4.Add (new ListItem ("54", 566));
			items4.Add (new ListItem ("68", 713));
			items4.Add (new ListItem ("97", 1017));
			items4.Add (new ListItem ("118", 1242));
			_ = null;
			cboThickness.SelectedIndex = 0;
			ComboBox.ObjectCollection items5 = cboConfig.Items;
			items5.Clear ();
			items5.Add (new ListItem ("Single", 1));
			items5.Add (new ListItem ("Back-to-Back", 2));
			items5.Add (new ListItem ("Boxed", 3));
			_ = null;
			cboConfig.SelectedIndex = 0;
			ComboBox.ObjectCollection items6 = cboYield.Items;
			items6.Clear ();
			items6.Add (new ListItem (" ?", 0));
			items6.Add (new ListItem (Units.DisplayStress (33f, 0, blnShowUnit: true, "", 0, 0), 33));
			items6.Add (new ListItem (Units.DisplayStress (50f, 0, blnShowUnit: true, "", 0, 0), 50));
			_ = null;
			cboYield.SelectedIndex = 0;
			ComboBox.ObjectCollection items7 = cboSpans.Items;
			items7.Clear ();
			items7.Add (new ListItem ("1", 1));
			items7.Add (new ListItem ("2", 2));
			items7.Add (new ListItem ("3", 3));
			_ = null;
			cboSpans.SelectedIndex = 0;
			ComboBox.ObjectCollection items8 = cboBracing.Items;
			items8.Clear ();
			items8.Add (new ListItem ("None", 0));
			items8.Add (new ListItem ("Mid-Point", 1));
			items8.Add (new ListItem ("Third-Points", 2));
			items8.Add (new ListItem ("Quarter-Points", 3));
			items8.Add (new ListItem ("Fully Braced", 4));
			_ = null;
			cboBracing.SelectedIndex = 0;
			cboSpacing.Tag = new ControlData (1, 6f, 120f);
			cboSpan.Tag = new ControlData (2, 12f, 1200f);
			cboDeadLoad.Tag = new ControlData (5, 0f, 0.00138888892f);
			cboLiveLoad.Tag = new ControlData (5, 0f, 0.00138888892f);
			cboWindLoad.Tag = new ControlData (5, 0f, 0.00208333344f);
			NewLateBinding.LateSetComplex (cboWindLoad.Tag, null, "Index", new object[1] { bytStressUnit }, null, null, OptimisticSet: false, RValueBase: true);
			sngSpacing = 16f;
			sngSpan = 120f;
			sngDeadLoad = 6.94444461E-05f;
			sngLiveLoad = 0.000277777785f;
			sngWindLoad = 0.000138888892f;
			sngDeadAxial = 1f / 12f;
			sngLiveAxial = 1f / 3f;
			CFSInterface.SetText (cboSpacing, sngSpacing);
			CFSInterface.SetText (cboSpan, sngSpan);
			CFSInterface.SetText (cboWindLoad, sngWindLoad);
			blnLoaded = true;
			CFS.blnValidate = true;
			optBeam.Checked = true;
			ClearResults ();
			CheckAvailability ();
		}
	}

	private void frmQuickDesign_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "quick-design.htm");
		e.Cancel = true;
	}

	private void cboSection_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		if ((sender == cboThickness) & (cboYield.SelectedIndex > 0)) {
			float num = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboThickness.SelectedItem, null, "ItemData", new object[0], null, null, null), 10000));
			if (num > 0f) {
				cboYield.SelectedIndex = Conversions.ToInteger (Interaction.IIf ((double)num < 0.05, 1, 2));
			}
		}
		ClearResults ();
		CheckAvailability ();
	}

	private void cboConfig_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void cboYield_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
			CheckAvailability ();
		}
	}

	private void chkPunched_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void chkColdWork_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void chkReserve_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void optBeamColumn_CheckedChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			if ((sender == optBeam) & optBeam.Checked) {
				lblWindLoad.Text = "Wind Uplift";
				object tag = cboDeadLoad.Tag;
				NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { bytStressUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
				tag = null;
				object tag2 = cboLiveLoad.Tag;
				NewLateBinding.LateSetComplex (tag2, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag2, null, "Index", new object[1] { bytStressUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag2, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
				tag2 = null;
				CFS.blnValidate = false;
				CFSInterface.SetText (cboDeadLoad, sngDeadLoad);
				CFSInterface.SetText (cboLiveLoad, sngLiveLoad);
				CFS.blnValidate = true;
			} else if ((sender == optColumn) & optColumn.Checked) {
				lblWindLoad.Text = "Wind Load";
				object tag3 = cboDeadLoad.Tag;
				NewLateBinding.LateSetComplex (tag3, null, "UnitType", new object[1] { Units.UnitTypes.LoadUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag3, null, "Index", new object[1] { Units.DefaultUnitIndex [11] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag3, null, "Max", new object[1] { 20 }, null, null, OptimisticSet: false, RValueBase: true);
				tag3 = null;
				object tag4 = cboLiveLoad.Tag;
				NewLateBinding.LateSetComplex (tag4, null, "UnitType", new object[1] { Units.UnitTypes.LoadUnit }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag4, null, "Index", new object[1] { Units.DefaultUnitIndex [11] }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag4, null, "Max", new object[1] { 20 }, null, null, OptimisticSet: false, RValueBase: true);
				tag4 = null;
				CFS.blnValidate = false;
				CFSInterface.SetText (cboDeadLoad, sngDeadAxial);
				CFSInterface.SetText (cboLiveLoad, sngLiveAxial);
				CFS.blnValidate = true;
			}
			ClearResults ();
		}
	}

	private void cboSpans_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void cboBracing_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ClearResults ();
		}
	}

	private void cboDesign_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboDesign_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboDesign_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboDesign_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdCalculate;
			base.CancelButton = cmdClose;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void cboDesign_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboDesign_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void cboDesign_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboDesign_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdCalculate;
			base.CancelButton = cmdClose;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdCalculate;
			base.CancelButton = cmdClose;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboSpacing)) {
				sngSpacing = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboSpan)) {
				sngSpan = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboDeadLoad)) {
				if (optBeam.Checked) {
					sngDeadLoad = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				} else {
					sngDeadAxial = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				}
			} else if (flag == (sender == cboLiveLoad)) {
				if (optBeam.Checked) {
					sngLiveLoad = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				} else {
					sngLiveAxial = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				}
			} else if (flag == (sender == cboWindLoad)) {
				sngWindLoad = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			ClearResults ();
		} else {
			e.Cancel = true;
		}
	}

	private void cmdCalculate_Click (object sender, EventArgs e)
	{
		float h = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboDepth.SelectedItem, null, "ItemData", new object[0], null, null, null), 1000));
		float num = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboFlange.SelectedItem, null, "ItemData", new object[0], null, null, null), 1000));
		float num2 = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboThickness.SelectedItem, null, "ItemData", new object[0], null, null, null), 10000));
		float num3 = Conversions.ToSingle (NewLateBinding.LateGet (cboYield.SelectedItem, null, "ItemData", new object[0], null, null, null));
		short num4 = Conversions.ToShort (NewLateBinding.LateGet (cboSpans.SelectedItem, null, "ItemData", new object[0], null, null, null));
		short num5 = Conversions.ToShort (NewLateBinding.LateGet (cboBracing.SelectedItem, null, "ItemData", new object[0], null, null, null));
		string strMsg = string.Empty;
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			if (cboConfig.SelectedIndex > 0) {
				strMsg = "This calculation requires a full CFS license for sections with more than 1 part.";
			} else if (chkPunched.Checked) {
				strMsg = "This calculation requires a full CFS license for members with holes.";
			} else if (chkColdWork.Checked) {
				strMsg = "This calculation requires a full CFS license to use cold work of forming strength increase.";
			} else if (chkReserve.Checked) {
				strMsg = "This calculation requires a full CFS license to use inelastic reserve strength.";
			} else if (num == 0f || num2 == 0f || num3 == 0f) {
				strMsg = "This calculation requires a full CFS license for optimizing the section.";
			} else if (num4 > 1) {
				strMsg = "This feature requires a full CFS license for analyses with more than 1 span.";
			} else if (num5 > 1) {
				strMsg = "This feature requires a full CFS license for analyses with more than 1 brace.";
			}
		} else if (!CFS.CheckLicense ()) {
			strMsg = "License is no longer available.";
		}
		if (strMsg.Length > 0) {
			CFS.LicenseRequired (strMsg);
			return;
		}
		float num6 = 1000f;
		float num7 = 1000f;
		float num8 = 1000f;
		float[] Zchk = new float[11];
		short[] Schk = new short[11];
		MemberCheck Check = new MemberCheck (5);
		Cursor.Current = Cursors.WaitCursor;
		CreateAnalysis ();
		float num19 = default(float);
		float num20 = default(float);
		float num21 = default(float);
		checked {
			int num9 = cboFlange.Items.Count - 1;
			short nChk = default(short);
			for (int i = 1; i <= num9; i++) {
				float num10 = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboFlange.Items [i], null, "ItemData", new object[0], null, null, null), 1000));
				if (!unchecked(num10 == num || num == 0f)) {
					continue;
				}
				int num11 = cboThickness.Items.Count - 1;
				for (int j = 1; j <= num11; j++) {
					float num12 = Conversions.ToSingle (Operators.DivideObject (NewLateBinding.LateGet (cboThickness.Items [j], null, "ItemData", new object[0], null, null, null), 10000));
					if (!unchecked(num12 == num2 || num2 == 0f)) {
						continue;
					}
					int num13 = cboYield.Items.Count - 1;
					for (int k = 1; k <= num13; k++) {
						float num14 = Conversions.ToSingle (NewLateBinding.LateGet (cboYield.Items [k], null, "ItemData", new object[0], null, null, null));
						float num15;
						float num16;
						float num17;
						int nComb;
						Analysis analysisQD;
						unchecked {
							if (!(num14 == num3 || num3 == 0f)) {
								continue;
							}
							bool flag = false;
							string text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("|" + cboDepth.Text + cboType.Text, NewLateBinding.LateGet (cboFlange.Items [i], null, "Text", new object[0], null, null, null)), "-"), NewLateBinding.LateGet (cboThickness.Items [j], null, "Text", new object[0], null, null, null)), "|"));
							if (Operators.CompareString (cboType.Text, "S", TextCompare: false) == 0 && num14 == 33f && Strings.InStr (strS33, text) > 0) {
								flag = true;
							}
							if (Operators.CompareString (cboType.Text, "S", TextCompare: false) == 0 && num14 == 50f && Strings.InStr (strS50, text) > 0) {
								flag = true;
							}
							if (Operators.CompareString (cboType.Text, "T", TextCompare: false) == 0 && num14 == 33f && Strings.InStr (strT33, text) > 0) {
								flag = true;
							}
							if (Operators.CompareString (cboType.Text, "T", TextCompare: false) == 0 && num14 == 50f && Strings.InStr (strT50, text) > 0) {
								flag = true;
							}
							if (num > 0f && num2 > 0f && num3 > 0f) {
								flag = true;
							}
							text = text.Replace ("|", "");
							if (!flag || !CreateSection (text, h, num10, num12, num14)) {
								continue;
							}
							CFS.Sections [intSct].CalcProperties (ref strMsg, blnCheckLicense: false);
							CFS.Sections [intSct].CalcStrength (CFS.intSpecNow);
							num15 = 0f;
							num16 = 0f;
							analysisQD = AnalysisQD;
							analysisQD.iCombSol = 0;
							num17 = (float)((double)(analysisQD.Zmax - analysisQD.Zmin) * 1E-06);
							nComb = analysisQD.nComb;
						}
						for (int l = 1; l <= nComb; l++) {
							analysisQD.iComb = (byte)l;
							analysisQD.Analyze (ref strMsg, blnCheckLicense: false);
							if ((strMsg.Length == 0) & (analysisQD.iCombSol == l)) {
								analysisQD.MemberCheckPoints (ref nChk, ref Zchk, ref Schk);
								int num18 = nChk;
								for (int m = 1; m <= num18; m++) {
									float zchk = Zchk [m] + (float)Schk [m] * num17;
									MemberParameters[] array = analysisQD.MemberCheckParameters (zchk);
									CFS.Sections [intSct].MemberCheck (array [1], ref Check);
									num15 = (float)CFS.Max (num15, Check.Eq [1], Check.Eq [2]);
									num16 = (float)CFS.Max (num16, Check.Eq [3], Check.Eq [4]);
								}
							}
						}
						analysisQD = null;
						if ((Math.Max (num15, num16) <= 1f) & (CFS.Sections [intSct].Prop.A < num8)) {
							num6 = num15;
							num7 = num16;
							num19 = num10;
							num20 = num12;
							num21 = num14;
							num8 = CFS.Sections [intSct].Prop.A;
						} else if ((Math.Max (num15, num16) > 1f) & (Math.Max (num15, num16) < Math.Max (num6, num7))) {
							num6 = num15;
							num7 = num16;
							num19 = num10;
							num20 = num12;
							num21 = num14;
						}
					}
				}
			}
			Cursor.Current = Cursors.Default;
			if (num19 == 0f) {
				Interaction.MsgBox ("No available sections.", MsgBoxStyle.Exclamation);
				return;
			}
			CFS.blnValidate = false;
			if (num == 0f) {
				SetComboItem (cboFlange, (int)Math.Round (num19 * 1000f));
			}
			if (num2 == 0f) {
				SetComboItem (cboThickness, (int)Math.Round (num20 * 10000f));
			}
			if (num3 == 0f) {
				SetComboItem (cboYield, (int)Math.Round (num21));
			}
		}
		if (num == 0f || num2 == 0f || num3 == 0f) {
			string text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (cboDepth.Text + cboType.Text, NewLateBinding.LateGet (cboFlange.SelectedItem, null, "Text", new object[0], null, null, null)), "-"), NewLateBinding.LateGet (cboThickness.SelectedItem, null, "Text", new object[0], null, null, null)));
			CreateSection (text, h, num19, num20, num21);
		}
		txtUnityAB.Text = num6.ToString ("0.0000");
		txtUnityAB.BackColor = txtUnityAB.BackColor;
		TextBox textBox = txtUnityAB;
		object obj = Interaction.IIf (num6 <= 1f, SystemColors.ControlText, Color.Red);
		textBox.ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		txtUnitySB.Text = num7.ToString ("0.0000");
		txtUnitySB.BackColor = txtUnitySB.BackColor;
		TextBox textBox2 = txtUnitySB;
		object obj2 = Interaction.IIf (num7 <= 1f, SystemColors.ControlText, Color.Red);
		textBox2.ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		CFS.blnValidate = true;
		cmdReport.Enabled = true;
		cmdCreate.Enabled = true;
	}

	private void SetComboItem (ComboBox cbo, int ItemData)
	{
		checked {
			int num = cbo.Items.Count - 1;
			for (int i = 0; i <= num; i++) {
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cbo.Items [i], null, "ItemData", new object[0], null, null, null), ItemData, TextCompare: false)) {
					cbo.SelectedIndex = i;
					break;
				}
			}
		}
	}

	private void CreateAnalysis ()
	{
		short num = Conversions.ToShort (NewLateBinding.LateGet (cboSpans.SelectedItem, null, "ItemData", new object[0], null, null, null));
		short num2 = Conversions.ToShort (NewLateBinding.LateGet (cboBracing.SelectedItem, null, "ItemData", new object[0], null, null, null));
		if (AnalysisQD == null) {
			AnalysisQD = new Analysis ();
		} else {
			AnalysisQD.Initialize ();
		}
		Analysis analysisQD = AnalysisQD;
		switch (num) {
		case 1:
			analysisQD.Description = "Single Span";
			break;
		case 2:
			analysisQD.Description = "Two Span";
			break;
		case 3:
			analysisQD.Description = "Three Span";
			break;
		}
		ref string description = ref analysisQD.Description;
		description = Conversions.ToString (Operators.ConcatenateObject (description, Interaction.IIf (optBeam.Checked, " Beam", " Column")));
		analysisQD.Vertical = optColumn.Checked;
		analysisQD.Torsion = false;
		analysisQD.nBeam = 1;
		checked {
			analysisQD.Beam [1] = new Beam ((byte)intSct);
			analysisQD.Beam [1].Z0 = 0f;
			analysisQD.Beam [1].Z1 = (float)num * sngSpan;
			analysisQD.Beam [1].Lm = sngSpan;
			analysisQD.nSup = (byte)(1 + num);
			ref byte nSup = ref analysisQD.nSup;
			nSup = Conversions.ToByte (Operators.AddObject (nSup, Interaction.IIf (num2 < 4, (short)unchecked(num2 * num), 2)));
			analysisQD.Sup = new Support[unchecked((int)analysisQD.nSup) + 1];
			short num3 = 0;
			int num4 = num + 1;
			float num5 = default(float);
			for (int i = 1; i <= num4; i++) {
				num5 = sngSpan * (float)(i - 1);
				num3 = (short)(num3 + 1);
				ref Support reference = ref analysisQD.Sup [num3];
				reference.Type = Conversions.ToByte (Interaction.IIf (num2 < 4, (byte)7, Supports.supY));
				reference.Z = num5;
				reference.Wid = 2f;
				reference.K = 1f;
				if ((num2 == 4) & ((i == 1) | (i == num + 1))) {
					num3 = (short)(num3 + 1);
					ref Support reference2 = ref analysisQD.Sup [num3];
					reference2.Type = 5;
					reference2.Z = num5;
					reference2.Wid = 1f;
					reference2.K = 0f;
				}
				if (unchecked(num2 < 4 && i <= num)) {
					int num6 = num2;
					for (int j = 1; j <= num6; j++) {
						num3 = (short)(num3 + 1);
						ref Support reference3 = ref analysisQD.Sup [num3];
						reference3.Type = 5;
						reference3.Z = (float)((double)num5 + (double)j / (double)(num2 + 1) * (double)sngSpan);
						reference3.Wid = 1f;
						reference3.K = 1f;
					}
				}
			}
			analysisQD.Zmin = 0f;
			analysisQD.Zmax = num5;
			analysisQD.nLdg = 3;
			analysisQD.Ldg = new Loading[unchecked((int)analysisQD.nLdg) + 1];
			analysisQD.Ldg [0].Initialize ("Beam Self Weight", 10);
			analysisQD.Ldg [1].Initialize ("Dead Load", 10);
			analysisQD.Ldg [1].nLoad = 1;
			analysisQD.Ldg [2].Initialize ("Live Load", 10);
			analysisQD.Ldg [2].nLoad = 1;
			analysisQD.Ldg [3].Initialize ("Wind Load", 10);
			analysisQD.Ldg [3].nLoad = 1;
			if (optBeam.Checked) {
				ref Load reference4 = ref analysisQD.Ldg [1].Load [1];
				reference4.Type = 1;
				reference4.Ang = (float)Math.PI / 2f;
				reference4.Z0 = 0f;
				reference4.Z1 = num5;
				reference4.W0 = (0f - sngDeadLoad) * sngSpacing;
				reference4.W1 = reference4.W0;
				reference4.Wid = 1f;
				ref Load reference5 = ref analysisQD.Ldg [2].Load [1];
				reference5.Type = 1;
				reference5.Ang = (float)Math.PI / 2f;
				reference5.Z0 = 0f;
				reference5.Z1 = num5;
				reference5.W0 = (0f - sngLiveLoad) * sngSpacing;
				reference5.W1 = reference5.W0;
				reference5.Wid = 1f;
				ref Load reference6 = ref analysisQD.Ldg [3].Load [1];
				reference6.Type = 1;
				reference6.Ang = (float)Math.PI / 2f;
				reference6.Z0 = 0f;
				reference6.Z1 = num5;
				reference6.W0 = sngWindLoad * sngSpacing;
				reference6.W1 = reference6.W0;
				reference6.Wid = 1f;
			} else {
				ref Load reference7 = ref analysisQD.Ldg [1].Load [1];
				reference7.Type = 3;
				reference7.Z0 = 0f;
				reference7.Z1 = num5;
				reference7.W0 = sngDeadAxial * sngSpacing;
				reference7.W1 = reference7.W0;
				reference7.Wid = 1f;
				ref Load reference8 = ref analysisQD.Ldg [2].Load [1];
				reference8.Type = 3;
				reference8.Z0 = 0f;
				reference8.Z1 = num5;
				reference8.W0 = sngLiveAxial * sngSpacing;
				reference8.W1 = reference8.W0;
				reference8.Wid = 1f;
				ref Load reference9 = ref analysisQD.Ldg [3].Load [1];
				reference9.Type = 1;
				reference9.Ang = (float)Math.PI / 2f;
				reference9.Z0 = 0f;
				reference9.Z1 = num5;
				reference9.W0 = sngWindLoad * sngSpacing;
				reference9.W1 = reference9.W0;
				reference9.Wid = 1f;
			}
			analysisQD.nComb = 3;
			analysisQD.Comb = new LoadCombination[unchecked((int)analysisQD.nComb) + 1];
			analysisQD.AllCombos = true;
			if (CFS.IsSpecASD (CFS.intSpecNow)) {
				analysisQD.Comb [1].Initialize ("D", 10);
				analysisQD.Comb [1].nLF = 1;
				analysisQD.Comb [1].LF [1].Assign (1, 1f);
				analysisQD.Comb [2].Initialize ("D+L", 10);
				analysisQD.Comb [2].nLF = 2;
				analysisQD.Comb [2].LF [1].Assign (1, 1f);
				analysisQD.Comb [2].LF [2].Assign (2, 1f);
				if (optBeam.Checked) {
					analysisQD.Comb [3].Initialize ("0.6D+0.6W", 10);
					analysisQD.Comb [3].nLF = 2;
					analysisQD.Comb [3].LF [1].Assign (1, 0.6f);
					analysisQD.Comb [3].LF [2].Assign (3, 0.6f);
				} else {
					analysisQD.Comb [3].Initialize ("D+0.6W", 10);
					analysisQD.Comb [3].nLF = 2;
					analysisQD.Comb [3].LF [1].Assign (1, 1f);
					analysisQD.Comb [3].LF [2].Assign (3, 0.6f);
					analysisQD.nComb = 4;
					ref LoadCombination[] comb = ref analysisQD.Comb;
					comb = (LoadCombination[])Utils.CopyArray (comb, new LoadCombination[unchecked((int)analysisQD.nComb) + 1]);
					analysisQD.Comb [4].Initialize ("D+0.75(0.6W+L)", 10);
					analysisQD.Comb [4].nLF = 3;
					analysisQD.Comb [4].LF [1].Assign (1, 1f);
					analysisQD.Comb [4].LF [2].Assign (2, 0.75f);
					analysisQD.Comb [4].LF [3].Assign (3, 0.45f);
				}
			} else if (CFS.IsSpecLRFD (CFS.intSpecNow)) {
				analysisQD.Comb [1].Initialize ("1.4D", 10);
				analysisQD.Comb [1].nLF = 1;
				analysisQD.Comb [1].LF [1].Assign (1, 1.4f);
				analysisQD.Comb [2].Initialize ("1.2D+1.6L", 10);
				analysisQD.Comb [2].nLF = 2;
				analysisQD.Comb [2].LF [1].Assign (1, 1.2f);
				analysisQD.Comb [2].LF [2].Assign (2, 1.6f);
				if (optBeam.Checked) {
					analysisQD.Comb [3].Initialize ("0.9D+W", 10);
					analysisQD.Comb [3].nLF = 2;
					analysisQD.Comb [3].LF [1].Assign (1, 0.9f);
					analysisQD.Comb [3].LF [2].Assign (3, 1f);
				} else {
					analysisQD.Comb [3].Initialize ("1.2D+W+L", 10);
					analysisQD.Comb [3].nLF = 3;
					analysisQD.Comb [3].LF [1].Assign (1, 1.2f);
					analysisQD.Comb [3].LF [2].Assign (2, 1f);
					analysisQD.Comb [3].LF [3].Assign (3, 1f);
				}
			} else {
				analysisQD.Comb [1].Initialize ("1.4D", 10);
				analysisQD.Comb [1].nLF = 1;
				analysisQD.Comb [1].LF [1].Assign (1, 1.4f);
				if (optBeam.Checked) {
					analysisQD.Comb [2].Initialize ("1.25D+1.5L", 10);
					analysisQD.Comb [2].nLF = 2;
					analysisQD.Comb [2].LF [1].Assign (1, 1.25f);
					analysisQD.Comb [2].LF [2].Assign (2, 1.5f);
					analysisQD.Comb [3].Initialize ("0.9D+1.4W", 10);
					analysisQD.Comb [3].nLF = 2;
					analysisQD.Comb [3].LF [1].Assign (1, 0.9f);
					analysisQD.Comb [3].LF [2].Assign (3, 1.4f);
				} else {
					analysisQD.Comb [2].Initialize ("1.25D+1.5L+0.4W", 10);
					analysisQD.Comb [2].nLF = 3;
					analysisQD.Comb [2].LF [1].Assign (1, 1.25f);
					analysisQD.Comb [2].LF [2].Assign (2, 1.5f);
					analysisQD.Comb [2].LF [3].Assign (3, 0.4f);
					analysisQD.Comb [3].Initialize ("1.25D+1.4W+0.5L", 10);
					analysisQD.Comb [3].nLF = 3;
					analysisQD.Comb [3].LF [1].Assign (1, 1.25f);
					analysisQD.Comb [3].LF [2].Assign (2, 0.5f);
					analysisQD.Comb [3].LF [3].Assign (3, 1.4f);
				}
			}
			analysisQD = null;
		}
	}

	private bool CreateSection (string strSection, float H, float B, float T, float Fy)
	{
		float num = (float)Math.Max (3.0 / 32.0 - 0.5 * (double)T, 1.5 * (double)T);
		float len = LipLength (B, T, num);
		float len2 = H + 2f * T + num;
		Section section = CFS.Sections [intSct];
		section.Description = strSection + " " + cboConfig.Text;
		if ((Fy == 33f) & (intMaterial33 > 0)) {
			section.MaterialIndex = intMaterial33;
			section.Material = CFS.Materials [intMaterial33].Clone ();
		}
		if ((Fy == 50f) & (intMaterial50 > 0)) {
			section.MaterialIndex = intMaterial50;
			section.Material = CFS.Materials [intMaterial50].Clone ();
		}
		section.ColdWork = chkColdWork.Checked;
		section.Reserve = chkReserve.Checked;
		section.HoleLength = 4.5f;
		section.HoleSpacing = 24f;
		section.ConnSpacing = 2f * H;
		float num2 = default(float);
		if (chkPunched.Checked) {
			num2 = 2.5f;
		}
		if (num2 > H / 2f) {
			num2 = H / 2f;
		}
		switch (cboConfig.SelectedIndex) {
		case 0:
			section.Part = new Part[2];
			section.nPart = 1;
			section.Part [1] = new Part ();
			if (Operators.CompareString (cboType.Text, "S", TextCompare: false) == 0) {
				section.Part [1].Name = "Stud";
				section.Part [1].Element [1].Len = len;
				section.Part [1].Element [1].Ang = 4.712389f;
				section.Part [1].Element [1].Web = 1;
				section.Part [1].Element [2].Len = B;
				section.Part [1].Element [2].Ang = (float)Math.PI;
				section.Part [1].Element [2].Web = 2;
				section.Part [1].Element [3].Len = H;
				section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [3].Web = 5;
				section.Part [1].Element [4].Len = B;
				section.Part [1].Element [4].Ang = 0f;
				section.Part [1].Element [4].Web = 2;
				section.Part [1].Element [5].Len = len;
				section.Part [1].Element [5].Ang = -(float)Math.PI / 2f;
				section.Part [1].Element [5].Web = 1;
				section.Part [1].nElem = 5;
				if (num2 > 0f) {
					section.Part [1].Element [3].Hole = num2;
					section.Part [1].Element [3].Dist = H / 2f;
				}
			} else {
				section.Part [1].Name = "Track";
				section.Part [1].Element [1].Len = B;
				section.Part [1].Element [1].Ang = (float)Math.PI;
				section.Part [1].Element [1].Web = 2;
				section.Part [1].Element [2].Len = len2;
				section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [2].Web = 5;
				section.Part [1].Element [3].Len = B;
				section.Part [1].Element [3].Ang = 0f;
				section.Part [1].Element [3].Web = 2;
				section.Part [1].nElem = 3;
				if (num2 > 0f) {
					section.Part [1].Element [2].Hole = num2;
					section.Part [1].Element [2].Dist = H / 2f;
				}
			}
			break;
		case 1:
			section.Part = new Part[3];
			section.nPart = 2;
			section.Part [1] = new Part ();
			section.Part [2] = new Part ();
			if (Operators.CompareString (cboType.Text, "S", TextCompare: false) == 0) {
				section.Part [1].Name = "Right Stud";
				section.Part [1].Element [1].Len = len;
				section.Part [1].Element [1].Ang = 4.712389f;
				section.Part [1].Element [1].Web = 1;
				section.Part [1].Element [2].Len = B;
				section.Part [1].Element [2].Ang = (float)Math.PI;
				section.Part [1].Element [2].Web = 2;
				section.Part [1].Element [3].Len = H;
				section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [3].Web = 3;
				section.Part [1].Element [4].Len = B;
				section.Part [1].Element [4].Ang = 0f;
				section.Part [1].Element [4].Web = 2;
				section.Part [1].Element [5].Len = len;
				section.Part [1].Element [5].Ang = -(float)Math.PI / 2f;
				section.Part [1].Element [5].Web = 1;
				section.Part [1].nElem = 5;
				if (num2 > 0f) {
					section.Part [1].Element [3].Hole = num2;
					section.Part [1].Element [3].Dist = H / 2f;
				}
				section.Part [2].Name = "Left Stud";
				section.Part [2].Element [1].Len = len;
				section.Part [2].Element [1].Ang = -(float)Math.PI / 2f;
				section.Part [2].Element [1].Web = 1;
				section.Part [2].Element [2].Len = B;
				section.Part [2].Element [2].Ang = 0f;
				section.Part [2].Element [2].Web = 2;
				section.Part [2].Element [3].Len = H;
				section.Part [2].Element [3].Ang = (float)Math.PI / 2f;
				section.Part [2].Element [3].Web = 3;
				section.Part [2].Element [4].Len = B;
				section.Part [2].Element [4].Ang = (float)Math.PI;
				section.Part [2].Element [4].Web = 2;
				section.Part [2].Element [5].Len = len;
				section.Part [2].Element [5].Ang = 4.712389f;
				section.Part [2].Element [5].Web = 1;
				section.Part [2].nElem = 5;
				if (num2 > 0f) {
					section.Part [2].Element [3].Hole = num2;
					section.Part [2].Element [3].Dist = H / 2f;
				}
			} else {
				section.Part [1].Name = "Right Track";
				section.Part [1].Element [1].Len = B;
				section.Part [1].Element [1].Ang = (float)Math.PI;
				section.Part [1].Element [1].Web = 2;
				section.Part [1].Element [2].Len = len2;
				section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [2].Web = 3;
				section.Part [1].Element [3].Len = B;
				section.Part [1].Element [3].Ang = 0f;
				section.Part [1].Element [3].Web = 2;
				section.Part [1].nElem = 3;
				if (num2 > 0f) {
					section.Part [1].Element [2].Hole = num2;
					section.Part [1].Element [2].Dist = H / 2f;
				}
				section.Part [2].Name = "Left Track";
				section.Part [2].Element [1].Len = B;
				section.Part [2].Element [1].Ang = 0f;
				section.Part [2].Element [1].Web = 2;
				section.Part [2].Element [2].Len = len2;
				section.Part [2].Element [2].Ang = (float)Math.PI / 2f;
				section.Part [2].Element [2].Web = 3;
				section.Part [2].Element [3].Len = B;
				section.Part [2].Element [3].Ang = (float)Math.PI;
				section.Part [2].Element [3].Web = 2;
				section.Part [2].nElem = 3;
				if (num2 > 0f) {
					section.Part [2].Element [2].Hole = num2;
					section.Part [2].Element [2].Dist = H / 2f;
				}
			}
			break;
		case 2:
			section.Part = new Part[3];
			section.nPart = 2;
			section.Part [1] = new Part ();
			section.Part [2] = new Part ();
			if (Operators.CompareString (cboType.Text, "S", TextCompare: false) == 0) {
				section.Part [1].Name = "Left Stud";
				section.Part [1].Element [1].Len = len;
				section.Part [1].Element [1].Ang = 4.712389f;
				section.Part [1].Element [1].Web = 1;
				section.Part [1].Element [2].Len = B;
				section.Part [1].Element [2].Ang = (float)Math.PI;
				section.Part [1].Element [2].Web = 2;
				section.Part [1].Element [3].Len = H;
				section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [3].Web = 5;
				section.Part [1].Element [4].Len = B;
				section.Part [1].Element [4].Ang = 0f;
				section.Part [1].Element [4].Web = 2;
				section.Part [1].Element [5].Len = len;
				section.Part [1].Element [5].Ang = -(float)Math.PI / 2f;
				section.Part [1].Element [5].Web = 1;
				section.Part [1].nElem = 5;
				if (num2 > 0f) {
					section.Part [1].Element [3].Hole = num2;
					section.Part [1].Element [3].Dist = H / 2f;
				}
				section.Part [2].Name = "Right Stud";
				section.Part [2].Element [1].Len = len;
				section.Part [2].Element [1].Ang = -(float)Math.PI / 2f;
				section.Part [2].Element [1].Web = 1;
				section.Part [2].Element [2].Len = B;
				section.Part [2].Element [2].Ang = 0f;
				section.Part [2].Element [2].Web = 2;
				section.Part [2].Element [3].Len = H;
				section.Part [2].Element [3].Ang = (float)Math.PI / 2f;
				section.Part [2].Element [3].Web = 5;
				section.Part [2].Element [4].Len = B;
				section.Part [2].Element [4].Ang = (float)Math.PI;
				section.Part [2].Element [4].Web = 2;
				section.Part [2].Element [5].Len = len;
				section.Part [2].Element [5].Ang = 4.712389f;
				section.Part [2].Element [5].Web = 1;
				section.Part [2].nElem = 5;
				if (num2 > 0f) {
					section.Part [2].Element [3].Hole = num2;
					section.Part [2].Element [3].Dist = H / 2f;
				}
			} else {
				section.Part [1].Name = "Left Track";
				section.Part [1].Element [1].Len = B;
				section.Part [1].Element [1].Ang = (float)Math.PI;
				section.Part [1].Element [1].Web = 2;
				section.Part [1].Element [2].Len = len2;
				section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
				section.Part [1].Element [2].Web = 5;
				section.Part [1].Element [3].Len = B;
				section.Part [1].Element [3].Ang = 0f;
				section.Part [1].Element [3].Web = 2;
				section.Part [1].nElem = 3;
				if (num2 > 0f) {
					section.Part [1].Element [2].Hole = num2;
					section.Part [1].Element [2].Dist = H / 2f;
				}
				section.Part [2].Name = "Right Track";
				section.Part [2].Element [1].Len = B;
				section.Part [2].Element [1].Ang = 0f;
				section.Part [2].Element [1].Web = 2;
				section.Part [2].Element [2].Len = len2;
				section.Part [2].Element [2].Ang = (float)Math.PI / 2f;
				section.Part [2].Element [2].Web = 5;
				section.Part [2].Element [3].Len = B;
				section.Part [2].Element [3].Ang = (float)Math.PI;
				section.Part [2].Element [3].Web = 2;
				section.Part [2].nElem = 3;
				if (num2 > 0f) {
					section.Part [2].Element [2].Hole = num2;
					section.Part [2].Element [2].Dist = H / 2f;
				}
			}
			break;
		}
		string strMsg = string.Empty;
		int nPart = section.nPart;
		checked {
			bool blnChg = default(bool);
			for (int i = 1; i <= nPart; i++) {
				section.Part [i].Thickness = T;
				section.Part [i].DefRad = num;
				CFS.SetThicknessIndex (section.Part [1]);
				int nElem = section.Part [i].nElem;
				for (int j = 1; j <= nElem; j++) {
					section.Part [i].Element [j].Rad = section.Part [i].DefRad;
				}
				section.Part [i].Geometry (ref blnChg, ref strMsg);
				if (strMsg.Length > 0) {
					return false;
				}
			}
			switch (cboConfig.SelectedIndex) {
			case 0:
				section.CwOverride = 0f;
				section.JOverride = 0f;
				break;
			case 1:
				section.Part [1].XPosition = section.Part [1].Xleft;
				section.Part [1].iXPosition = 0;
				section.Part [2].XPosition = 0f - section.Part [2].Xright;
				section.Part [2].iXPosition = 2;
				section.CalcProperties (ref strMsg, blnCheckLicense: false);
				if ((strMsg.Length > 0) | !section.SctProp) {
					return false;
				}
				section.CwOverride = (float)(Math.Pow (H - T, 2.0) * (double)section.Prop.Iy / 4.0);
				section.JOverride = 0f;
				section.SctProp = false;
				break;
			case 2: {
				section.Part [1].XPosition = 0f - section.Part [1].Xright;
				section.Part [1].iXPosition = 2;
				section.Part [2].XPosition = section.Part [2].Xleft;
				section.Part [2].iXPosition = 0;
				float num3 = (H - T) / 2f;
				float num4 = B - T / 2f;
				section.CwOverride = (float)(1.3333333333333333 * Math.Pow (num3, 2.0) * Math.Pow (num4, 2.0) * (double)T * Math.Pow (num3 - num4, 2.0) / (double)(num3 + num4));
				section.JOverride = (float)(16.0 * Math.Pow (num3, 2.0) * Math.Pow (num4, 2.0) * (double)T / (double)(num3 + num4));
				break;
			}
			}
			section.SctProp = false;
			section = null;
			return true;
		}
	}

	private float LipLength (float Flange, float Thickness, float Radius)
	{
		float num = ((Flange <= 1.25f) ? 0.1875f : ((Flange <= 1.375f) ? 0.375f : ((Flange <= 1.625f) ? 0.5f : ((!(Flange <= 3f)) ? 1f : 0.625f))));
		if (num < Thickness + Radius) {
			num = (float)((double)checked((int)Math.Round ((double)((Thickness + Radius) * 8f) + 0.5)) / 8.0);
		}
		return num;
	}

	private void cmdReport_Click (object sender, EventArgs e)
	{
		Font selectionFont = new Font ("Arial", 10f);
		Font selectionFont2 = new Font ("Consolas", 10f);
		RichTextBox rtfDialog = My.MyProject.Forms.frmReportDialog.rtfDialog;
		rtfDialog.Rtf = string.Empty;
		rtfDialog.SelectionStart = Strings.Len (rtfDialog.Text);
		Report.rptTitle (rtfDialog, "CFS Quick Design - " + CFS.strCSspec [CFS.intSpecNow]);
		rtfDialog.SelectionFont = selectionFont;
		string left = "Section: " + CFS.Sections [intSct].Description + ", Fy=" + cboYield.Text + ", ";
		left = (rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (left, Operators.ConcatenateObject (Interaction.IIf (chkPunched.Checked, "Punched", "Unpunched"), "\r\n"))));
		rtfDialog.SelectionFont = selectionFont;
		rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Interaction.IIf (chkColdWork.Checked, "Apply", "No"), " cold work of forming strength increase."), "\r\n"));
		rtfDialog.SelectionFont = selectionFont;
		rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Interaction.IIf (chkReserve.Checked, "Apply", "No"), " inelastic reserve strength increase."), "\r\n"));
		rtfDialog.SelectionFont = selectionFont;
		rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Interaction.IIf (AnalysisQD.BucklingTheory, "Global buckling calculated using elastic theory.\r\n", ""), "\r\n"));
		left = AnalysisQD.Description + ", " + Units.DisplayLength (sngSpan, 0, blnShowUnit: true, "", 0, 0) + " Span, " + Units.DisplayLen1 (sngSpacing, 0, blnShowUnit: true, "", 0, 0) + " Spacing, ";
		object left2 = NewLateBinding.LateGet (cboBracing.SelectedItem, null, "ItemData", new object[0], null, null, null);
		if (Operators.ConditionalCompareObjectEqual (left2, 0, TextCompare: false)) {
			left += "Unbraced";
		} else if (Operators.ConditionalCompareObjectEqual (left2, 1, TextCompare: false)) {
			left += "Midpoint Bracing";
		} else if (Operators.ConditionalCompareObjectEqual (left2, 2, TextCompare: false)) {
			left += "Third-point Bracing";
		} else if (Operators.ConditionalCompareObjectEqual (left2, 3, TextCompare: false)) {
			left += "Quarter-point Bracing";
		} else if (Operators.ConditionalCompareObjectEqual (left2, 4, TextCompare: false)) {
			left += "Fully Braced";
		}
		rtfDialog.SelectionFont = selectionFont;
		rtfDialog.SelectedText = left + "\r\n";
		rtfDialog.SelectionFont = selectionFont2;
		string strFmt;
		if (optBeam.Checked) {
			strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (sngDeadLoad, sngLiveLoad, sngWindLoad) * (double)Units.untStress [bytStressUnit].Mult))];
			rtfDialog.SelectedText = "Dead Load" + Units.DisplayStress (sngDeadLoad, bytStressUnit, blnShowUnit: true, strFmt, 12, 0) + "\r\n";
			rtfDialog.SelectedText = "Live Load" + Units.DisplayStress (sngLiveLoad, bytStressUnit, blnShowUnit: true, strFmt, 12, 0) + "\r\n";
		} else {
			strFmt = Units.Fmt [Units.FmtIndex (Math.Max (sngDeadAxial, sngLiveAxial) * Units.untLoad [Units.DefaultUnitIndex [11]].Mult)];
			rtfDialog.SelectedText = "Dead Load" + Units.DisplayLoad (sngDeadAxial, 0, blnShowUnit: true, strFmt, 12, 0) + "\r\n";
			rtfDialog.SelectedText = "Live Load" + Units.DisplayLoad (sngLiveAxial, 0, blnShowUnit: true, strFmt, 12, 0) + "\r\n";
			strFmt = Units.Fmt [Units.FmtIndex (sngWindLoad * Units.untStress [bytStressUnit].Mult)];
		}
		rtfDialog.SelectedText = "Wind Load" + Units.DisplayStress (sngWindLoad, bytStressUnit, blnShowUnit: true, strFmt, 12, 0) + "\r\n";
		rtfDialog.SelectedText = "Axial/Bending: ";
		if (Conversion.Val (txtUnityAB.Text) > 1.0) {
			rtfDialog.SelectionColor = Color.Red;
		}
		rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (txtUnityAB.Text, Interaction.IIf (Conversion.Val (txtUnityAB.Text) <= 1.0, " <=1.0", " > 1.0")), "\r\n"));
		if (Conversion.Val (txtUnityAB.Text) > 1.0) {
			rtfDialog.SelectionColor = Color.Black;
		}
		rtfDialog.SelectedText = "Shear/Bending: ";
		if (Conversion.Val (txtUnitySB.Text) > 1.0) {
			rtfDialog.SelectionColor = Color.Red;
		}
		rtfDialog.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (txtUnitySB.Text, Interaction.IIf (Conversion.Val (txtUnitySB.Text) <= 1.0, " <=1.0", " > 1.0")), "\r\n"));
		if (Conversion.Val (txtUnitySB.Text) > 1.0) {
			rtfDialog.SelectionColor = Color.Black;
		}
		rtfDialog.SelectedText = Report.strPage;
		checked {
			short num = (short)Information.UBound (CFS.frmReport);
			short num2;
			for (num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (CFS.hdgReport [num2].Parent == 3) {
					if (CFS.hdgReport [num2].Deleted) {
						CFS.frmReport [num2].rtfReport.Clear ();
					}
					break;
				}
			}
			if (num2 > Information.UBound (CFS.frmReport)) {
				CFS.frmReport = (frmReportMaster[])Utils.CopyArray (CFS.frmReport, new frmReportMaster[num2 + 1]);
				CFS.frmReport [num2] = new frmReportMaster ((byte)num2);
				CFS.hdgReport = (Heading[])Utils.CopyArray (CFS.hdgReport, new Heading[num2 + 1]);
				CFS.hdgReport [num2] = new Heading ("Quick Design");
				CFS.hdgReport [num2].Parent = 3;
				CFS.frmReport [num2].Text = "Report: " + CFS.hdgReport [num2].Filename;
				CFS.frmReport [num2].Tag = Conversions.ToString (unchecked((int)num2));
			}
			CFS.hdgReport [num2].Deleted = false;
			CFS.hdgReport [num2].RevDate = DateAndTime.Now;
			CFS.hdgReport [num2].RevBy = CFS.User.Name;
			CFS.hdgReport [num2].AppVer = 1400;
			if (CFS.frmReport [num2].WindowState == FormWindowState.Minimized) {
				CFS.frmReport [num2].WindowState = FormWindowState.Normal;
			}
			CFS.frmReport [num2].Show ();
			CFS.frmReport [num2].Activate ();
			Report.AppendRTF (CFS.frmReport [num2].rtfReport, rtfDialog);
		}
	}

	private void cmdCreate_Click (object sender, EventArgs e)
	{
		CFS.intSctNow = intSct;
		Section obj = CFS.Sections [CFS.intSctNow];
		obj.Filename = CFSInterface.NewSctFilename ();
		obj.Saved = false;
		obj.RevDate = DateAndTime.Now;
		obj.RevBy = CFS.User.Name;
		obj.AppVer = 1400;
		_ = null;
		CFS.hdgSctPic [CFS.intSctNow].Initialize ();
		CFS.hdgSctPic [CFS.intSctNow].Deleted = false;
		checked {
			CFS.frmSctPic [CFS.intSctNow] = new frmSctPicMaster ((byte)intSct);
			CFS.frmSctPic [CFS.intSctNow].Text = CFS.Sections [intSct].Filename;
			CFS.frmSctPic [CFS.intSctNow].Show ();
			CFS.intAnlNow = (byte)CFSInterface.NewAnlIndex ();
			CFS.Analyses [CFS.intAnlNow] = AnalysisQD;
			Analysis obj2 = CFS.Analyses [CFS.intAnlNow];
			obj2.Filename = CFSInterface.NewAnlFilename ();
			obj2.iComb = 1;
			obj2.iCombSol = 0;
			obj2.Saved = false;
			obj2.RevDate = DateAndTime.Now;
			obj2.RevBy = CFS.User.Name;
			obj2.AppVer = 1400;
			_ = null;
			CFS.hdgAnlPic [CFS.intAnlNow].Initialize ();
			CFS.hdgAnlPic [CFS.intAnlNow].Deleted = false;
			CFSInterface.ShowAnl (CFS.intAnlNow);
			Close ();
		}
	}
}
