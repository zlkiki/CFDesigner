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
public class frmSctWizard : Form
{
	private IContainer components;

	private short iButton;

	private SectionWizard SctWiz;

	private const string strNext = "&Next >";

	private const string strFinished = "&Finished";

	[field: AccessedThroughProperty ("pnlSctWizard1")]
	internal virtual Panel pnlSctWizard1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("picSct1")]
	internal virtual PictureBox picSct1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInfo")]
	internal virtual Label lblInfo {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStrip tbrSections {
		[CompilerGenerated]
		get {
			return _tbrSections;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			ToolStripItemClickedEventHandler value2 = tbrSections_ItemClicked;
			EventHandler value3 = cmdNext_Click;
			ToolStrip toolStrip = _tbrSections;
			if (toolStrip != null) {
				toolStrip.ItemClicked -= value2;
				toolStrip.DoubleClick -= value3;
			}
			_tbrSections = value;
			toolStrip = _tbrSections;
			if (toolStrip != null) {
				toolStrip.ItemClicked += value2;
				toolStrip.DoubleClick += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("btnSct1")]
	internal virtual ToolStripButton btnSct1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct2")]
	internal virtual ToolStripButton btnSct2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct3")]
	internal virtual ToolStripButton btnSct3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct4")]
	internal virtual ToolStripButton btnSct4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct5")]
	internal virtual ToolStripButton btnSct5 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct6")]
	internal virtual ToolStripButton btnSct6 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct7")]
	internal virtual ToolStripButton btnSct7 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct8")]
	internal virtual ToolStripButton btnSct8 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct9")]
	internal virtual ToolStripButton btnSct9 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct10")]
	internal virtual ToolStripButton btnSct10 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct11")]
	internal virtual ToolStripButton btnSct11 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct12")]
	internal virtual ToolStripButton btnSct12 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct13")]
	internal virtual ToolStripButton btnSct13 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct14")]
	internal virtual ToolStripButton btnSct14 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct15")]
	internal virtual ToolStripButton btnSct15 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("btnSct16")]
	internal virtual ToolStripButton btnSct16 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("cmdCancel")]
	internal virtual Button cmdCancel {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdNext {
		[CompilerGenerated]
		get {
			return _cmdNext;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdNext_Click;
			Button button = _cmdNext;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdNext = value;
			button = _cmdNext;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdBack {
		[CompilerGenerated]
		get {
			return _cmdBack;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdBack_Click;
			Button button = _cmdBack;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdBack = value;
			button = _cmdBack;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("pnlSctWizard2")]
	internal virtual Panel pnlSctWizard2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblThickness")]
	internal virtual Label lblThickness {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblSct")]
	internal virtual Label lblSct {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("picSct")]
	internal virtual PictureBox picSct {
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
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboThickness;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboThickness = value;
			comboBox = _cboThickness;
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

	internal virtual ComboBox cboThicknessName {
		[CompilerGenerated]
		get {
			return _cboThicknessName;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_SelectedIndexChanged;
			ComboBox comboBox = _cboThicknessName;
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

	internal virtual TextBox txtNumSpacings {
		[CompilerGenerated]
		get {
			return _txtNumSpacings;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtNumSpacings;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtNumSpacings = value;
			textBox = _txtNumSpacings;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblNumSpacings")]
	internal virtual Label lblNumSpacings {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboRibSpacing {
		[CompilerGenerated]
		get {
			return _cboRibSpacing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboRibSpacing;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboRibSpacing = value;
			comboBox = _cboRibSpacing;
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

	[field: AccessedThroughProperty ("lblRibSpacing")]
	internal virtual Label lblRibSpacing {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLipAngle {
		[CompilerGenerated]
		get {
			return _cboLipAngle;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLipAngle;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLipAngle = value;
			comboBox = _cboLipAngle;
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

	[field: AccessedThroughProperty ("lblLipAngle")]
	internal virtual Label lblLipAngle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboWebAngle {
		[CompilerGenerated]
		get {
			return _cboWebAngle;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboWebAngle;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboWebAngle = value;
			comboBox = _cboWebAngle;
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

	[field: AccessedThroughProperty ("lblWebAngle")]
	internal virtual Label lblWebAngle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboRadius {
		[CompilerGenerated]
		get {
			return _cboRadius;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboRadius;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboRadius = value;
			comboBox = _cboRadius;
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

	[field: AccessedThroughProperty ("lblRadius")]
	internal virtual Label lblRadius {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLip {
		[CompilerGenerated]
		get {
			return _cboLip;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLip;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLip = value;
			comboBox = _cboLip;
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

	[field: AccessedThroughProperty ("lblLip")]
	internal virtual Label lblLip {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboWidth {
		[CompilerGenerated]
		get {
			return _cboWidth;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboWidth;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboWidth = value;
			comboBox = _cboWidth;
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

	[field: AccessedThroughProperty ("lblWidth")]
	internal virtual Label lblWidth {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboDepth {
		[CompilerGenerated]
		get {
			return _cboDepth;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboDepth;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboDepth = value;
			comboBox = _cboDepth;
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

	[field: AccessedThroughProperty ("lblDepth")]
	internal virtual Label lblDepth {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmSctWizard ()
	{
		base.Load += frmSctWizard_Load;
		base.KeyDown += frmSctWizard_KeyDown;
		base.HelpButtonClicked += frmSctWizard_HelpButtonClicked;
		base.FormClosing += frmSctWizard_FormClosing;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmSctWizard));
		this.pnlSctWizard1 = new System.Windows.Forms.Panel ();
		this.tbrSections = new System.Windows.Forms.ToolStrip ();
		this.btnSct1 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct2 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct3 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct4 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct5 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct6 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct7 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct8 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct9 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct10 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct11 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct12 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct13 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct14 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct15 = new System.Windows.Forms.ToolStripButton ();
		this.btnSct16 = new System.Windows.Forms.ToolStripButton ();
		this.lblInfo = new System.Windows.Forms.Label ();
		this.picSct1 = new System.Windows.Forms.PictureBox ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.cmdNext = new System.Windows.Forms.Button ();
		this.cmdBack = new System.Windows.Forms.Button ();
		this.pnlSctWizard2 = new System.Windows.Forms.Panel ();
		this.txtNumSpacings = new System.Windows.Forms.TextBox ();
		this.lblNumSpacings = new System.Windows.Forms.Label ();
		this.cboRibSpacing = new System.Windows.Forms.ComboBox ();
		this.lblRibSpacing = new System.Windows.Forms.Label ();
		this.cboLipAngle = new System.Windows.Forms.ComboBox ();
		this.lblLipAngle = new System.Windows.Forms.Label ();
		this.cboWebAngle = new System.Windows.Forms.ComboBox ();
		this.lblWebAngle = new System.Windows.Forms.Label ();
		this.cboRadius = new System.Windows.Forms.ComboBox ();
		this.lblRadius = new System.Windows.Forms.Label ();
		this.cboLip = new System.Windows.Forms.ComboBox ();
		this.lblLip = new System.Windows.Forms.Label ();
		this.cboWidth = new System.Windows.Forms.ComboBox ();
		this.lblWidth = new System.Windows.Forms.Label ();
		this.cboDepth = new System.Windows.Forms.ComboBox ();
		this.lblDepth = new System.Windows.Forms.Label ();
		this.cboThickness = new System.Windows.Forms.ComboBox ();
		this.cboThicknessName = new System.Windows.Forms.ComboBox ();
		this.lblThickness = new System.Windows.Forms.Label ();
		this.lblSct = new System.Windows.Forms.Label ();
		this.picSct = new System.Windows.Forms.PictureBox ();
		this.pnlSctWizard1.SuspendLayout ();
		this.tbrSections.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)this.picSct1).BeginInit ();
		this.pnlSctWizard2.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)this.picSct).BeginInit ();
		base.SuspendLayout ();
		this.pnlSctWizard1.Controls.Add (this.tbrSections);
		this.pnlSctWizard1.Controls.Add (this.lblInfo);
		this.pnlSctWizard1.Controls.Add (this.picSct1);
		this.pnlSctWizard1.Location = new System.Drawing.Point (0, 0);
		this.pnlSctWizard1.Name = "pnlSctWizard1";
		this.pnlSctWizard1.Size = new System.Drawing.Size (429, 220);
		this.pnlSctWizard1.TabIndex = 0;
		this.tbrSections.AutoSize = false;
		this.tbrSections.BackColor = System.Drawing.SystemColors.Control;
		this.tbrSections.Dock = System.Windows.Forms.DockStyle.None;
		this.tbrSections.Items.AddRange (new System.Windows.Forms.ToolStripItem[16] {
			this.btnSct1, this.btnSct2, this.btnSct3, this.btnSct4, this.btnSct5, this.btnSct6, this.btnSct7, this.btnSct8, this.btnSct9, this.btnSct10,
			this.btnSct11, this.btnSct12, this.btnSct13, this.btnSct14, this.btnSct15, this.btnSct16
		});
		this.tbrSections.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.tbrSections.Location = new System.Drawing.Point (140, 10);
		this.tbrSections.Name = "tbrSections";
		this.tbrSections.Padding = new System.Windows.Forms.Padding (0);
		this.tbrSections.Size = new System.Drawing.Size (169, 182);
		this.tbrSections.TabIndex = 4;
		this.tbrSections.TabStop = true;
		this.btnSct1.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct1.Checked = true;
		this.btnSct1.CheckState = System.Windows.Forms.CheckState.Checked;
		this.btnSct1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct1.Image = (System.Drawing.Image)resources.GetObject ("btnSct1.Image");
		this.btnSct1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct1.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct1.Name = "btnSct1";
		this.btnSct1.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct1.Size = new System.Drawing.Size (38, 38);
		this.btnSct1.Tag = "1";
		this.btnSct1.ToolTipText = "Channel";
		this.btnSct2.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct2.Image = (System.Drawing.Image)resources.GetObject ("btnSct2.Image");
		this.btnSct2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct2.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct2.Name = "btnSct2";
		this.btnSct2.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct2.Size = new System.Drawing.Size (38, 38);
		this.btnSct2.Tag = "2";
		this.btnSct2.ToolTipText = "Stiffened Channel";
		this.btnSct3.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct3.Image = (System.Drawing.Image)resources.GetObject ("btnSct3.Image");
		this.btnSct3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct3.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct3.Name = "btnSct3";
		this.btnSct3.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct3.Size = new System.Drawing.Size (38, 38);
		this.btnSct3.Tag = "3";
		this.btnSct3.ToolTipText = "Zee";
		this.btnSct4.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct4.Image = (System.Drawing.Image)resources.GetObject ("btnSct4.Image");
		this.btnSct4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct4.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct4.Name = "btnSct4";
		this.btnSct4.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct4.Size = new System.Drawing.Size (38, 38);
		this.btnSct4.Tag = "4";
		this.btnSct4.ToolTipText = "Stiffened Zee";
		this.btnSct5.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct5.Image = (System.Drawing.Image)resources.GetObject ("btnSct5.Image");
		this.btnSct5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct5.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct5.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct5.Name = "btnSct5";
		this.btnSct5.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct5.Size = new System.Drawing.Size (38, 38);
		this.btnSct5.Tag = "5";
		this.btnSct5.ToolTipText = "Double Channel";
		this.btnSct6.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct6.Image = (System.Drawing.Image)resources.GetObject ("btnSct6.Image");
		this.btnSct6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct6.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct6.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct6.Name = "btnSct6";
		this.btnSct6.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct6.Size = new System.Drawing.Size (38, 38);
		this.btnSct6.Tag = "6";
		this.btnSct6.ToolTipText = "Double Stiffened Channel";
		this.btnSct7.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct7.Image = (System.Drawing.Image)resources.GetObject ("btnSct7.Image");
		this.btnSct7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct7.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct7.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct7.Name = "btnSct7";
		this.btnSct7.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct7.Size = new System.Drawing.Size (38, 38);
		this.btnSct7.Tag = "7";
		this.btnSct7.ToolTipText = "Box";
		this.btnSct8.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct8.Image = (System.Drawing.Image)resources.GetObject ("btnSct8.Image");
		this.btnSct8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct8.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct8.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct8.Name = "btnSct8";
		this.btnSct8.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct8.Size = new System.Drawing.Size (38, 38);
		this.btnSct8.Tag = "8";
		this.btnSct8.ToolTipText = "Rectangular Tube";
		this.btnSct9.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct9.Image = (System.Drawing.Image)resources.GetObject ("btnSct9.Image");
		this.btnSct9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct9.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct9.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct9.Name = "btnSct9";
		this.btnSct9.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct9.Size = new System.Drawing.Size (38, 38);
		this.btnSct9.Tag = "9";
		this.btnSct9.ToolTipText = "Angle";
		this.btnSct10.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct10.Image = (System.Drawing.Image)resources.GetObject ("btnSct10.Image");
		this.btnSct10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct10.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct10.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct10.Name = "btnSct10";
		this.btnSct10.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct10.Size = new System.Drawing.Size (38, 38);
		this.btnSct10.Tag = "10";
		this.btnSct10.ToolTipText = "Stiffened Angle";
		this.btnSct11.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct11.Image = (System.Drawing.Image)resources.GetObject ("btnSct11.Image");
		this.btnSct11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct11.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct11.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct11.Name = "btnSct11";
		this.btnSct11.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct11.Size = new System.Drawing.Size (38, 38);
		this.btnSct11.Tag = "11";
		this.btnSct11.ToolTipText = "Hat";
		this.btnSct12.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct12.Image = (System.Drawing.Image)resources.GetObject ("btnSct12.Image");
		this.btnSct12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct12.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct12.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct12.Name = "btnSct12";
		this.btnSct12.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct12.Size = new System.Drawing.Size (38, 38);
		this.btnSct12.Tag = "12";
		this.btnSct12.ToolTipText = "Cylindrical Tube";
		this.btnSct13.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct13.Image = (System.Drawing.Image)resources.GetObject ("btnSct13.Image");
		this.btnSct13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct13.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct13.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct13.Name = "btnSct13";
		this.btnSct13.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct13.Size = new System.Drawing.Size (38, 38);
		this.btnSct13.Tag = "13";
		this.btnSct13.ToolTipText = "Panel";
		this.btnSct14.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct14.Image = (System.Drawing.Image)resources.GetObject ("btnSct14.Image");
		this.btnSct14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct14.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct14.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct14.Name = "btnSct14";
		this.btnSct14.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct14.Size = new System.Drawing.Size (38, 38);
		this.btnSct14.Tag = "14";
		this.btnSct14.ToolTipText = "Custom Section";
		this.btnSct15.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct15.Enabled = false;
		this.btnSct15.Image = (System.Drawing.Image)resources.GetObject ("btnSct15.Image");
		this.btnSct15.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct15.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct15.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct15.Name = "btnSct15";
		this.btnSct15.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct15.Size = new System.Drawing.Size (38, 38);
		this.btnSct15.Tag = "15";
		this.btnSct16.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.btnSct16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSct16.Enabled = false;
		this.btnSct16.Image = (System.Drawing.Image)resources.GetObject ("btnSct16.Image");
		this.btnSct16.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSct16.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSct16.Margin = new System.Windows.Forms.Padding (1);
		this.btnSct16.Name = "btnSct16";
		this.btnSct16.Padding = new System.Windows.Forms.Padding (1);
		this.btnSct16.Size = new System.Drawing.Size (38, 38);
		this.btnSct16.Tag = "16";
		this.lblInfo.Location = new System.Drawing.Point (312, 9);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size (111, 183);
		this.lblInfo.TabIndex = 3;
		this.lblInfo.Text = "Select the type of section you want to create.  If the shape isn't represented, you may define any shape by choosing Custom.";
		this.picSct1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picSct1.Image = (System.Drawing.Image)resources.GetObject ("picSct1.Image");
		this.picSct1.Location = new System.Drawing.Point (10, 10);
		this.picSct1.Name = "picSct1";
		this.picSct1.Size = new System.Drawing.Size (120, 160);
		this.picSct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picSct1.TabIndex = 1;
		this.picSct1.TabStop = false;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (340, 224);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 55;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.cmdNext.Location = new System.Drawing.Point (222, 224);
		this.cmdNext.Name = "cmdNext";
		this.cmdNext.Size = new System.Drawing.Size (75, 25);
		this.cmdNext.TabIndex = 54;
		this.cmdNext.Text = "&Next >";
		this.cmdNext.UseVisualStyleBackColor = true;
		this.cmdBack.Enabled = false;
		this.cmdBack.Location = new System.Drawing.Point (141, 224);
		this.cmdBack.Name = "cmdBack";
		this.cmdBack.Size = new System.Drawing.Size (75, 25);
		this.cmdBack.TabIndex = 53;
		this.cmdBack.Text = "< &Back";
		this.cmdBack.UseVisualStyleBackColor = true;
		this.pnlSctWizard2.Controls.Add (this.txtNumSpacings);
		this.pnlSctWizard2.Controls.Add (this.lblNumSpacings);
		this.pnlSctWizard2.Controls.Add (this.cboRibSpacing);
		this.pnlSctWizard2.Controls.Add (this.lblRibSpacing);
		this.pnlSctWizard2.Controls.Add (this.cboLipAngle);
		this.pnlSctWizard2.Controls.Add (this.lblLipAngle);
		this.pnlSctWizard2.Controls.Add (this.cboWebAngle);
		this.pnlSctWizard2.Controls.Add (this.lblWebAngle);
		this.pnlSctWizard2.Controls.Add (this.cboRadius);
		this.pnlSctWizard2.Controls.Add (this.lblRadius);
		this.pnlSctWizard2.Controls.Add (this.cboLip);
		this.pnlSctWizard2.Controls.Add (this.lblLip);
		this.pnlSctWizard2.Controls.Add (this.cboWidth);
		this.pnlSctWizard2.Controls.Add (this.lblWidth);
		this.pnlSctWizard2.Controls.Add (this.cboDepth);
		this.pnlSctWizard2.Controls.Add (this.lblDepth);
		this.pnlSctWizard2.Controls.Add (this.cboThickness);
		this.pnlSctWizard2.Controls.Add (this.cboThicknessName);
		this.pnlSctWizard2.Controls.Add (this.lblThickness);
		this.pnlSctWizard2.Controls.Add (this.lblSct);
		this.pnlSctWizard2.Controls.Add (this.picSct);
		this.pnlSctWizard2.Location = new System.Drawing.Point (0, 0);
		this.pnlSctWizard2.Name = "pnlSctWizard2";
		this.pnlSctWizard2.Size = new System.Drawing.Size (429, 220);
		this.pnlSctWizard2.TabIndex = 56;
		this.pnlSctWizard2.Visible = false;
		this.txtNumSpacings.Location = new System.Drawing.Point (323, 139);
		this.txtNumSpacings.Name = "txtNumSpacings";
		this.txtNumSpacings.Size = new System.Drawing.Size (100, 20);
		this.txtNumSpacings.TabIndex = 20;
		this.lblNumSpacings.Location = new System.Drawing.Point (232, 142);
		this.lblNumSpacings.Name = "lblNumSpacings";
		this.lblNumSpacings.Size = new System.Drawing.Size (85, 33);
		this.lblNumSpacings.TabIndex = 19;
		this.lblNumSpacings.Text = "Number of Rib Spacings";
		this.cboRibSpacing.FormattingEnabled = true;
		this.cboRibSpacing.Location = new System.Drawing.Point (323, 112);
		this.cboRibSpacing.Name = "cboRibSpacing";
		this.cboRibSpacing.Size = new System.Drawing.Size (100, 21);
		this.cboRibSpacing.TabIndex = 18;
		this.lblRibSpacing.Location = new System.Drawing.Point (232, 115);
		this.lblRibSpacing.Name = "lblRibSpacing";
		this.lblRibSpacing.Size = new System.Drawing.Size (85, 17);
		this.lblRibSpacing.TabIndex = 17;
		this.lblRibSpacing.Text = "Rib Spacing";
		this.cboLipAngle.FormattingEnabled = true;
		this.cboLipAngle.Location = new System.Drawing.Point (323, 85);
		this.cboLipAngle.Name = "cboLipAngle";
		this.cboLipAngle.Size = new System.Drawing.Size (100, 21);
		this.cboLipAngle.TabIndex = 16;
		this.lblLipAngle.Location = new System.Drawing.Point (232, 88);
		this.lblLipAngle.Name = "lblLipAngle";
		this.lblLipAngle.Size = new System.Drawing.Size (85, 17);
		this.lblLipAngle.TabIndex = 15;
		this.lblLipAngle.Text = "Lip Angle";
		this.cboWebAngle.FormattingEnabled = true;
		this.cboWebAngle.Location = new System.Drawing.Point (323, 58);
		this.cboWebAngle.Name = "cboWebAngle";
		this.cboWebAngle.Size = new System.Drawing.Size (100, 21);
		this.cboWebAngle.TabIndex = 14;
		this.lblWebAngle.Location = new System.Drawing.Point (232, 61);
		this.lblWebAngle.Name = "lblWebAngle";
		this.lblWebAngle.Size = new System.Drawing.Size (85, 17);
		this.lblWebAngle.TabIndex = 13;
		this.lblWebAngle.Text = "Web Angle";
		this.cboRadius.FormattingEnabled = true;
		this.cboRadius.Location = new System.Drawing.Point (103, 139);
		this.cboRadius.Name = "cboRadius";
		this.cboRadius.Size = new System.Drawing.Size (100, 21);
		this.cboRadius.TabIndex = 12;
		this.lblRadius.Location = new System.Drawing.Point (12, 142);
		this.lblRadius.Name = "lblRadius";
		this.lblRadius.Size = new System.Drawing.Size (85, 17);
		this.lblRadius.TabIndex = 11;
		this.lblRadius.Text = "Inside Radius";
		this.cboLip.FormattingEnabled = true;
		this.cboLip.Location = new System.Drawing.Point (103, 112);
		this.cboLip.Name = "cboLip";
		this.cboLip.Size = new System.Drawing.Size (100, 21);
		this.cboLip.TabIndex = 10;
		this.lblLip.Location = new System.Drawing.Point (12, 115);
		this.lblLip.Name = "lblLip";
		this.lblLip.Size = new System.Drawing.Size (85, 17);
		this.lblLip.TabIndex = 9;
		this.lblLip.Text = "Lip Length";
		this.cboWidth.FormattingEnabled = true;
		this.cboWidth.Location = new System.Drawing.Point (103, 85);
		this.cboWidth.Name = "cboWidth";
		this.cboWidth.Size = new System.Drawing.Size (100, 21);
		this.cboWidth.TabIndex = 8;
		this.lblWidth.Location = new System.Drawing.Point (12, 88);
		this.lblWidth.Name = "lblWidth";
		this.lblWidth.Size = new System.Drawing.Size (85, 17);
		this.lblWidth.TabIndex = 7;
		this.lblWidth.Text = "Flange Width";
		this.cboDepth.FormattingEnabled = true;
		this.cboDepth.Location = new System.Drawing.Point (103, 58);
		this.cboDepth.Name = "cboDepth";
		this.cboDepth.Size = new System.Drawing.Size (100, 21);
		this.cboDepth.TabIndex = 6;
		this.lblDepth.Location = new System.Drawing.Point (12, 61);
		this.lblDepth.Name = "lblDepth";
		this.lblDepth.Size = new System.Drawing.Size (85, 17);
		this.lblDepth.TabIndex = 5;
		this.lblDepth.Text = "Section Depth";
		this.cboThickness.FormattingEnabled = true;
		this.cboThickness.Location = new System.Drawing.Point (323, 7);
		this.cboThickness.Name = "cboThickness";
		this.cboThickness.Size = new System.Drawing.Size (100, 21);
		this.cboThickness.TabIndex = 4;
		this.cboThicknessName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboThicknessName.FormattingEnabled = true;
		this.cboThicknessName.Location = new System.Drawing.Point (217, 7);
		this.cboThicknessName.Name = "cboThicknessName";
		this.cboThicknessName.Size = new System.Drawing.Size (100, 21);
		this.cboThicknessName.TabIndex = 3;
		this.lblThickness.Location = new System.Drawing.Point (154, 10);
		this.lblThickness.Name = "lblThickness";
		this.lblThickness.Size = new System.Drawing.Size (57, 17);
		this.lblThickness.TabIndex = 2;
		this.lblThickness.Text = "Thickness";
		this.lblSct.Location = new System.Drawing.Point (52, 10);
		this.lblSct.Name = "lblSct";
		this.lblSct.Size = new System.Drawing.Size (96, 36);
		this.lblSct.TabIndex = 1;
		this.lblSct.Text = "Section";
		this.picSct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picSct.Location = new System.Drawing.Point (10, 10);
		this.picSct.Name = "picSct";
		this.picSct.Size = new System.Drawing.Size (36, 36);
		this.picSct.TabIndex = 0;
		this.picSct.TabStop = false;
		base.AcceptButton = this.cmdNext;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (435, 255);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdNext);
		base.Controls.Add (this.cmdBack);
		base.Controls.Add (this.pnlSctWizard1);
		base.Controls.Add (this.pnlSctWizard2);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSctWizard";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Section Wizard (1 of 2)";
		this.pnlSctWizard1.ResumeLayout (false);
		this.tbrSections.ResumeLayout (false);
		this.tbrSections.PerformLayout ();
		((System.ComponentModel.ISupportInitialize)this.picSct1).EndInit ();
		this.pnlSctWizard2.ResumeLayout (false);
		this.pnlSctWizard2.PerformLayout ();
		((System.ComponentModel.ISupportInitialize)this.picSct).EndInit ();
		base.ResumeLayout (false);
	}

	private void frmSctWizard_Load (object sender, EventArgs e)
	{
		iButton = SctWiz.SctType;
		if (iButton == 0) {
			iButton = 1;
		}
		checked {
			picSct.Image = tbrSections.Items [iButton - 1].Image;
			lblSct.Text = tbrSections.Items [iButton - 1].ToolTipText;
			lblInfo.Text = "Select the type of section you want to create.\n\nIf the shape isn't represented, you may define any shape by choosing \"Custom\".";
			cmdNext.Text = "&Next >";
			cboThickness.Tag = new ControlData (1, 0.001f, 1f);
			cboDepth.Tag = new ControlData (1, 0.5f, 60f);
			cboWidth.Tag = new ControlData (1, 0.5f, 30f);
			cboLip.Tag = new ControlData (1, 0.1f, 10f);
			cboRadius.Tag = new ControlData (1, 0f, 10f);
			cboWebAngle.Tag = new ControlData (3, (float)Math.PI / 6f, 2.61799383f);
			cboLipAngle.Tag = new ControlData (3, (float)Math.PI / 6f, 2.61799383f);
			cboRibSpacing.Tag = new ControlData (1, 2f, 30f);
			txtNumSpacings.Tag = new ControlData (0, 1f, 20f);
			int num = Information.UBound (CFS.Thicknesses);
			for (int i = 1; i <= num; i++) {
				cboThicknessName.Items.Add (CFS.Thicknesses [i].Name);
			}
		}
	}

	private void frmSctWizard_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			if (pnlSctWizard1.Visible) {
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "section-wizard-1.htm");
			} else {
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "section-wizard-2.htm");
			}
			e.Handled = true;
		}
	}

	private void frmSctWizard_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		if (pnlSctWizard1.Visible) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "section-wizard-1.htm");
		} else {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "section-wizard-2.htm");
		}
		e.Cancel = true;
	}

	private void frmSctWizard_FormClosing (object sender, FormClosingEventArgs e)
	{
	}

	private void tbrSections_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
	{
		checked {
			ToolStripButton toolStripButton = (ToolStripButton)tbrSections.Items [iButton - 1];
			toolStripButton.Checked = false;
			toolStripButton = (ToolStripButton)e.ClickedItem;
			toolStripButton.Checked = true;
			iButton = (short)(tbrSections.Items.IndexOf (toolStripButton) + 1);
			picSct.Image = toolStripButton.Image;
			lblSct.Text = tbrSections.Items [iButton - 1].ToolTipText;
			if (iButton == 14) {
				cmdNext.Text = "&Finished";
			}
		}
	}

	private void cmdBack_Click (object sender, EventArgs e)
	{
		Text = "Section Wizard (1 of 2)";
		cmdBack.Enabled = false;
		pnlSctWizard2.Visible = false;
		pnlSctWizard1.Visible = true;
		cmdNext.Text = "&Next >";
		tbrSections.Select ();
	}

	private void cmdNext_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (pnlSctWizard2.Visible | (iButton == 14)) {
				Hide ();
				My.MyProject.Forms.mdiCFS.Activate ();
				if (iButton == 14) {
					ref SectionWizard sctWiz = ref SctWiz;
					sctWiz.ThicknessIndex = CFS.iThickness;
					sctWiz.Thickness = CFS.Thicknesses [CFS.iThickness].Thickness;
					sctWiz.Rad = CFS.Thicknesses [CFS.iThickness].DefRad;
					sctWiz.SctType = (byte)iButton;
				}
				short num = CFSInterface.NewSctIndex ();
				if (num <= 0) {
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("Unable to create section.", MsgBoxStyle.Information);
					Close ();
					return;
				}
				CFS.intSctNow = num;
				Section section = CFS.Sections [num];
				section.AppVer = 1400;
				section.Filename = CFSInterface.NewSctFilename ();
				byte sctType = SctWiz.SctType;
				unchecked {
					if ((uint)sctType >= 5u && (uint)sctType <= 7u) {
						section.Part = new Part[3];
						section.Part [1] = new Part ();
						section.Part [1].Name = "Part 1";
						section.Part [2] = new Part ();
						section.Part [2].Name = "Part 2";
					} else {
						section.Part = new Part[2];
						section.Part [1] = new Part ();
						section.Part [1].Name = "Part 1";
					}
					section.Description = string.Empty;
					switch (SctWiz.SctType) {
					case 12:
						section.Description = Units.DisplayLen1 (SctWiz.SctDepth, 0, blnShowUnit: false, "", 0, 0) + Conversions.ToString (Strings.Chr (248));
						break;
					default:
						if (SctWiz.SctDepth >= 0f) {
							section.Description = Units.DisplayLen1 (SctWiz.SctDepth, 0, blnShowUnit: false, "", 0, 0);
						}
						if (SctWiz.FlangeWid >= 0f) {
							if (Strings.Len (section.Description) > 0) {
								section.Description += "x";
							}
							string text = Units.DisplayLen1 (SctWiz.FlangeWid, 0, blnShowUnit: false, "", 0, 0);
							section.Description += text;
							if ((SctWiz.SctType == 9) | (SctWiz.SctType == 10)) {
								section.Description = section.Description + "x" + text;
							}
						}
						if (SctWiz.SctType == 13) {
							section.Description = section.Description + "x" + Conversions.ToString ((int)SctWiz.NumSpa) + "@" + Units.DisplayLen1 (SctWiz.RibSpa, 0, blnShowUnit: false, "", 0, 0);
						} else if (SctWiz.LipLen >= 0f) {
							if (Strings.Len (section.Description) > 0) {
								section.Description += "x";
							}
							section.Description += Units.DisplayLen1 (SctWiz.LipLen, 0, blnShowUnit: false, "", 0, 0);
						}
						break;
					case 14:
						break;
					}
				}
				switch (SctWiz.SctType) {
				case 1:
					section.Description = "Channel " + section.Description;
					section.Part [1].Name = "Channel";
					section.Part [1].Element [1].Len = SctWiz.FlangeWid;
					section.Part [1].Element [1].Ang = (float)Math.PI;
					section.Part [1].Element [1].Web = 2;
					section.Part [1].Element [2].Len = SctWiz.SctDepth;
					section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [2].Web = 5;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = 0f;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].nElem = 3;
					section.nPart = 1;
					break;
				case 2:
					section.Description = "Channel " + section.Description;
					section.Part [1].Name = "Stiffened Channel";
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = (float)Math.PI;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = SctWiz.SctDepth;
					section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [3].Web = 5;
					section.Part [1].Element [4].Len = SctWiz.FlangeWid;
					section.Part [1].Element [4].Ang = 0f;
					section.Part [1].Element [4].Web = 2;
					section.Part [1].Element [5].Len = SctWiz.LipLen;
					section.Part [1].Element [5].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [5].Web = 1;
					section.Part [1].nElem = 5;
					section.nPart = 1;
					break;
				case 3:
					section.Description = "Zee " + section.Description;
					section.Part [1].Name = "Zee";
					section.Part [1].Element [1].Len = SctWiz.FlangeWid;
					section.Part [1].Element [1].Ang = 0f;
					section.Part [1].Element [1].Web = 2;
					section.Part [1].Element [2].Len = (float)(((double)SctWiz.SctDepth - (double)SctWiz.Thickness * Math.Cos (SctWiz.WebAng)) / Math.Sin (SctWiz.WebAng));
					section.Part [1].Element [2].Ang = SctWiz.WebAng;
					section.Part [1].Element [2].Web = 6;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = 0f;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].nElem = 3;
					section.nPart = 1;
					break;
				case 4:
					section.Description = "Zee " + section.Description;
					section.Part [1].Name = "Stiffened Zee";
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = 0f;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = (float)(((double)SctWiz.SctDepth - (double)SctWiz.Thickness * Math.Cos (SctWiz.WebAng)) / Math.Sin (SctWiz.WebAng));
					section.Part [1].Element [3].Ang = SctWiz.WebAng;
					section.Part [1].Element [3].Web = 6;
					section.Part [1].Element [4].Len = SctWiz.FlangeWid;
					section.Part [1].Element [4].Ang = 0f;
					section.Part [1].Element [4].Web = 2;
					section.Part [1].Element [5].Len = SctWiz.LipLen;
					section.Part [1].Element [5].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [5].Web = 1;
					section.Part [1].nElem = 5;
					section.nPart = 1;
					break;
				case 5:
					section.Description = "Double Channel " + section.Description;
					section.Part [1].Name = "Right Channel";
					section.Part [1].Element [1].Len = SctWiz.FlangeWid;
					section.Part [1].Element [1].Ang = (float)Math.PI;
					section.Part [1].Element [1].Web = 2;
					section.Part [1].Element [2].Len = SctWiz.SctDepth;
					section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [2].Web = 3;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = 0f;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].nElem = 3;
					section.Part [2].Name = "Left Channel";
					section.Part [2].Element [1].Len = SctWiz.FlangeWid;
					section.Part [2].Element [1].Ang = 0f;
					section.Part [2].Element [1].Web = 2;
					section.Part [2].Element [2].Len = SctWiz.SctDepth;
					section.Part [2].Element [2].Ang = (float)Math.PI / 2f;
					section.Part [2].Element [2].Web = 3;
					section.Part [2].Element [3].Len = SctWiz.FlangeWid;
					section.Part [2].Element [3].Ang = (float)Math.PI;
					section.Part [2].Element [3].Web = 2;
					section.Part [2].nElem = 3;
					section.nPart = 2;
					break;
				case 6:
					section.Description = "Double Channel " + section.Description;
					section.Part [1].Name = "Right Channel";
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = (float)Math.PI;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = SctWiz.SctDepth;
					section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [3].Web = 3;
					section.Part [1].Element [4].Len = SctWiz.FlangeWid;
					section.Part [1].Element [4].Ang = 0f;
					section.Part [1].Element [4].Web = 2;
					section.Part [1].Element [5].Len = SctWiz.LipLen;
					section.Part [1].Element [5].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [5].Web = 1;
					section.Part [1].nElem = 5;
					section.Part [2].Name = "Left Channel";
					section.Part [2].Element [1].Len = SctWiz.LipLen;
					section.Part [2].Element [1].Ang = 0f - SctWiz.LipAng;
					section.Part [2].Element [1].Web = 1;
					section.Part [2].Element [2].Len = SctWiz.FlangeWid;
					section.Part [2].Element [2].Ang = 0f;
					section.Part [2].Element [2].Web = 2;
					section.Part [2].Element [3].Len = SctWiz.SctDepth;
					section.Part [2].Element [3].Ang = (float)Math.PI / 2f;
					section.Part [2].Element [3].Web = 3;
					section.Part [2].Element [4].Len = SctWiz.FlangeWid;
					section.Part [2].Element [4].Ang = (float)Math.PI;
					section.Part [2].Element [4].Web = 2;
					section.Part [2].Element [5].Len = SctWiz.LipLen;
					section.Part [2].Element [5].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [2].Element [5].Web = 1;
					section.Part [2].nElem = 5;
					section.nPart = 2;
					break;
				case 7:
					section.Description = "Box " + section.Description;
					section.Part [1].Name = "Left Channel";
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = (float)Math.PI;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = SctWiz.SctDepth;
					section.Part [1].Element [3].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [3].Web = 5;
					section.Part [1].Element [4].Len = SctWiz.FlangeWid;
					section.Part [1].Element [4].Ang = 0f;
					section.Part [1].Element [4].Web = 2;
					section.Part [1].Element [5].Len = SctWiz.LipLen;
					section.Part [1].Element [5].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [5].Web = 1;
					section.Part [1].nElem = 5;
					section.Part [2].Name = "Right Channel";
					section.Part [2].Element [1].Len = SctWiz.LipLen;
					section.Part [2].Element [1].Ang = 0f - SctWiz.LipAng;
					section.Part [2].Element [1].Web = 1;
					section.Part [2].Element [2].Len = SctWiz.FlangeWid;
					section.Part [2].Element [2].Ang = 0f;
					section.Part [2].Element [2].Web = 2;
					section.Part [2].Element [3].Len = SctWiz.SctDepth;
					section.Part [2].Element [3].Ang = (float)Math.PI / 2f;
					section.Part [2].Element [3].Web = 5;
					section.Part [2].Element [4].Len = SctWiz.FlangeWid;
					section.Part [2].Element [4].Ang = (float)Math.PI;
					section.Part [2].Element [4].Web = 2;
					section.Part [2].Element [5].Len = SctWiz.LipLen;
					section.Part [2].Element [5].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [2].Element [5].Web = 1;
					section.Part [2].nElem = 5;
					section.nPart = 2;
					break;
				case 8:
					section.Description = "Tube " + section.Description;
					section.Part [1].Name = "Tube";
					section.Part [1].Element [1].Len = SctWiz.FlangeWid;
					section.Part [1].Element [1].Ang = 0f;
					section.Part [1].Element [1].Web = 2;
					section.Part [1].Element [2].Len = SctWiz.SctDepth;
					section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = (float)Math.PI;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].Element [4].Len = SctWiz.SctDepth;
					section.Part [1].Element [4].Ang = 4.712389f;
					section.Part [1].Element [4].Web = 2;
					section.Part [1].nElem = 4;
					section.Part [1].Closed = true;
					section.nPart = 1;
					break;
				case 9:
					section.Description = "Angle " + section.Description;
					section.Part [1].Name = "Angle";
					section.Part [1].Element [1].Len = SctWiz.FlangeWid;
					section.Part [1].Element [1].Ang = (float)(Math.PI - (double)SctWiz.WebAng);
					section.Part [1].Element [1].Web = 2;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = SctWiz.WebAng;
					section.Part [1].Element [2].Web = 2;
					section.Part [1].nElem = 2;
					section.nPart = 1;
					break;
				case 10:
					section.Description = "Angle " + section.Description;
					section.Part [1].Name = "Stiffened Angle";
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = (float)(Math.PI + (double)SctWiz.LipAng);
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = (float)(Math.PI - (double)SctWiz.WebAng);
					section.Part [1].Element [2].Web = 2;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = SctWiz.WebAng;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].Element [4].Len = SctWiz.LipLen;
					section.Part [1].Element [4].Ang = 0f - SctWiz.LipAng;
					section.Part [1].Element [4].Web = 1;
					section.Part [1].nElem = 4;
					section.nPart = 1;
					break;
				case 11: {
					section.Description = "Hat " + section.Description;
					section.Part [1].Name = "Hat";
					float len = (float)(((double)SctWiz.SctDepth - (double)SctWiz.Thickness * Math.Cos (SctWiz.WebAng)) / Math.Sin (SctWiz.WebAng));
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = 0f;
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = len;
					section.Part [1].Element [2].Ang = SctWiz.WebAng;
					section.Part [1].Element [2].Web = 7;
					section.Part [1].Element [3].Len = SctWiz.FlangeWid;
					section.Part [1].Element [3].Ang = 0f;
					section.Part [1].Element [3].Web = 2;
					section.Part [1].Element [4].Len = len;
					section.Part [1].Element [4].Ang = 0f - SctWiz.WebAng;
					section.Part [1].Element [4].Web = 7;
					section.Part [1].Element [5].Len = SctWiz.LipLen;
					section.Part [1].Element [5].Ang = 0f;
					section.Part [1].Element [5].Web = 1;
					section.Part [1].nElem = 5;
					section.nPart = 1;
					break;
				}
				case 12: {
					section.Description = "Cylindrical Tube " + section.Description;
					section.Part [1].Name = "Cylindrical Tube";
					float len = SctWiz.SctDepth / 2f - SctWiz.Thickness;
					section.Part [1].DefRad = len;
					section.Part [1].Element [1].Len = SctWiz.SctDepth;
					section.Part [1].Element [1].Ang = 0f;
					section.Part [1].Element [1].Rad = len;
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.SctDepth;
					section.Part [1].Element [2].Ang = (float)Math.PI / 2f;
					section.Part [1].Element [2].Rad = len;
					section.Part [1].Element [2].Web = 1;
					section.Part [1].Element [3].Len = SctWiz.SctDepth;
					section.Part [1].Element [3].Ang = (float)Math.PI;
					section.Part [1].Element [3].Rad = len;
					section.Part [1].Element [3].Web = 1;
					section.Part [1].Element [4].Len = SctWiz.SctDepth;
					section.Part [1].Element [4].Ang = 4.712389f;
					section.Part [1].Element [4].Rad = len;
					section.Part [1].Element [4].Web = 1;
					section.Part [1].nElem = 4;
					section.Part [1].Closed = true;
					section.nPart = 1;
					break;
				}
				case 13: {
					section.Description = "Panel " + section.Description;
					section.Part [1].Centerline = true;
					section.Part [1].Name = "Panel";
					section.Part [1].nElem = (byte)(4 * SctWiz.NumSpa + 4);
					if (section.Part [1].nElem > Information.UBound (section.Part [1].Element)) {
						section.Part [1].Element = new Element[(int)Math.Round (Math.Ceiling ((double)unchecked((int)section.Part [1].nElem) / 10.0) * 10.0) + 1];
					}
					float len = (float)((double)SctWiz.SctDepth / Math.Sin (SctWiz.WebAng));
					float len2 = (float)((double)(SctWiz.RibSpa - SctWiz.FlangeWid) - (double)(2f * SctWiz.SctDepth) * Math.Cos (SctWiz.WebAng) / Math.Sin (SctWiz.WebAng));
					section.Part [1].Element [1].Len = SctWiz.LipLen;
					section.Part [1].Element [1].Ang = SctWiz.WebAng;
					section.Part [1].Element [1].Web = 1;
					section.Part [1].Element [2].Len = SctWiz.FlangeWid;
					section.Part [1].Element [2].Ang = 0f;
					section.Part [1].Element [2].Web = 2;
					short numSpa = SctWiz.NumSpa;
					for (short num2 = 1; num2 <= numSpa; num2 = (short)unchecked(num2 + 1)) {
						section.Part [1].Element [4 * num2 - 1].Len = len;
						section.Part [1].Element [4 * num2 - 1].Ang = 0f - SctWiz.WebAng;
						section.Part [1].Element [4 * num2 - 1].Web = 8;
						section.Part [1].Element [4 * num2].Len = len2;
						section.Part [1].Element [4 * num2].Ang = 0f;
						section.Part [1].Element [4 * num2].Web = 1;
						section.Part [1].Element [4 * num2 + 1].Len = len;
						section.Part [1].Element [4 * num2 + 1].Ang = SctWiz.WebAng;
						section.Part [1].Element [4 * num2 + 1].Web = 8;
						section.Part [1].Element [4 * num2 + 2].Len = SctWiz.FlangeWid;
						section.Part [1].Element [4 * num2 + 2].Ang = 0f;
						section.Part [1].Element [4 * num2 + 2].Web = 2;
					}
					section.Part [1].Element [unchecked((int)section.Part [1].nElem) - 1].Len = len;
					section.Part [1].Element [unchecked((int)section.Part [1].nElem) - 1].Ang = 0f - SctWiz.WebAng;
					section.Part [1].Element [unchecked((int)section.Part [1].nElem) - 1].Web = 8;
					section.Part [1].Element [section.Part [1].nElem].Len = SctWiz.LipLen;
					section.Part [1].Element [section.Part [1].nElem].Ang = 0f;
					section.Part [1].Element [section.Part [1].nElem].Web = 1;
					section.nPart = 1;
					break;
				}
				case 14:
					section.Part [1].ThicknessIndex = SctWiz.ThicknessIndex;
					section.Part [1].Thickness = SctWiz.Thickness;
					section.Part [1].DefRad = SctWiz.Rad;
					break;
				}
				if (SctWiz.SctType != 14) {
					if (SctWiz.ThicknessIndex == -1) {
						string text = "x" + Units.DisplayLen1 (SctWiz.Thickness, 0, blnShowUnit: false, "", 0, 0);
						if (Strings.Len (section.Description + text) <= 40) {
							section.Description += text;
						}
					} else {
						string text = "-" + CFS.Thicknesses [SctWiz.ThicknessIndex].Name;
						if (Strings.Len (section.Description + text) <= 40) {
							section.Description += text;
						}
					}
				}
				short nPart = section.nPart;
				bool blnChg = default(bool);
				for (short num3 = 1; num3 <= nPart; num3 = (short)unchecked(num3 + 1)) {
					section.Part [num3].ThicknessIndex = SctWiz.ThicknessIndex;
					section.Part [num3].Thickness = SctWiz.Thickness;
					if (SctWiz.SctType != 12) {
						section.Part [num3].DefRad = SctWiz.Rad;
						short nElem = section.Part [num3].nElem;
						for (short num4 = 1; num4 <= nElem; num4 = (short)unchecked(num4 + 1)) {
							section.Part [num3].Element [num4].Rad = section.Part [num3].DefRad;
						}
					}
					section.Part [num3].Geometry (ref blnChg, ref strMsg);
					if (Strings.Len (strMsg) != 0) {
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					}
				}
				switch (SctWiz.SctType) {
				case 5:
				case 6:
					section.Part [1].XPosition = section.Part [1].Xleft;
					section.Part [1].iXPosition = 0;
					section.Part [2].XPosition = 0f - section.Part [2].Xright;
					section.Part [2].iXPosition = 2;
					section.CalcProperties (ref strMsg, blnCheckLicense: false);
					if (Strings.Len (strMsg) != 0) {
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					}
					section.CwOverride = (float)(Math.Pow (SctWiz.SctDepth - SctWiz.Thickness, 2.0) * (double)section.Prop.Iy / 4.0);
					section.SctProp = false;
					break;
				case 7: {
					section.Part [1].XPosition = 0f - section.Part [1].Xright;
					section.Part [1].iXPosition = 2;
					section.Part [2].XPosition = section.Part [2].Xleft;
					section.Part [2].iXPosition = 0;
					float len = (SctWiz.SctDepth - SctWiz.Thickness) / 2f;
					float len2 = SctWiz.FlangeWid - SctWiz.Thickness / 2f;
					if (len2 == len) {
						len2 = (float)(1.001 * (double)len);
					}
					section.CwOverride = (float)(1.3333333333333333 * Math.Pow (len, 2.0) * Math.Pow (len2, 2.0) * (double)SctWiz.Thickness * Math.Pow (len - len2, 2.0) / (double)(len + len2));
					section.JOverride = (float)(16.0 * Math.Pow (len, 2.0) * Math.Pow (len2, 2.0) * (double)SctWiz.Thickness / (double)(len + len2));
					break;
				}
				}
				section = null;
				bool flag = ((!CFS.blnSctInpLoaded) ? true : false);
				CFSInterface.ShowSct (num);
				if (!flag) {
					My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex = 0;
				}
				My.MyProject.Forms.frmSctInp.txtDescription.Select ();
				CFSInterface.SctWizSave = SctWiz;
				Close ();
			} else {
				Text = "Section Wizard (2 of 2)";
				cmdBack.Enabled = true;
				ref SectionWizard sctWiz2 = ref SctWiz;
				sctWiz2.ThicknessIndex = CFS.iThickness;
				sctWiz2.Thickness = CFS.Thicknesses [CFS.iThickness].Thickness;
				sctWiz2.SctDepth = -1f;
				sctWiz2.FlangeWid = -1f;
				sctWiz2.LipLen = -1f;
				sctWiz2.WebAng = -1f;
				sctWiz2.LipAng = -1f;
				sctWiz2.RibSpa = -1f;
				sctWiz2.NumSpa = -1;
				if (iButton == 12) {
					sctWiz2.Rad = -1f;
				} else {
					sctWiz2.Rad = CFS.Thicknesses [CFS.iThickness].DefRad;
				}
				lblDepth.Enabled = true;
				cboDepth.Enabled = true;
				lblWidth.Enabled = true;
				cboWidth.Enabled = true;
				lblLip.Enabled = true;
				cboLip.Enabled = true;
				lblRadius.Enabled = true;
				cboRadius.Enabled = true;
				lblWebAngle.Enabled = true;
				cboWebAngle.Enabled = true;
				lblLipAngle.Enabled = true;
				cboLipAngle.Enabled = true;
				lblRibSpacing.Enabled = true;
				cboRibSpacing.Enabled = true;
				lblNumSpacings.Enabled = true;
				txtNumSpacings.Enabled = true;
				sctWiz2.SctType = (byte)iButton;
				NewLateBinding.LateSetComplex (cboDepth.Tag, null, "Max", new object[1] { 60 }, null, null, OptimisticSet: false, RValueBase: true);
				switch (iButton) {
				case 1:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 2f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 2:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 3f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					sctWiz2.LipAng = (float)Math.PI / 2f;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 3:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 2f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 4:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 3f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					sctWiz2.LipAng = (float)Math.PI / 4f;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 5:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 2f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 6:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 3f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					sctWiz2.LipAng = (float)Math.PI / 2f;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 7:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 3f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					sctWiz2.LipAng = (float)Math.PI / 2f;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 8:
					sctWiz2.SctDepth = 8f;
					sctWiz2.FlangeWid = 4f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 9:
					sctWiz2.FlangeWid = 4f;
					sctWiz2.WebAng = (float)Math.PI / 4f;
					lblDepth.Enabled = false;
					cboDepth.Enabled = false;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 10:
					sctWiz2.FlangeWid = 4f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 4f;
					sctWiz2.LipAng = (float)Math.PI / 4f;
					lblDepth.Enabled = false;
					cboDepth.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 11:
					sctWiz2.SctDepth = 4f;
					sctWiz2.FlangeWid = 4f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = (float)Math.PI / 2f;
					sctWiz2.LipAng = 0f;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 12:
					NewLateBinding.LateSetComplex (cboDepth.Tag, null, "Max", new object[1] { 20 }, null, null, OptimisticSet: false, RValueBase: true);
					sctWiz2.SctDepth = 4f;
					lblWidth.Enabled = false;
					cboWidth.Enabled = false;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblRadius.Enabled = false;
					cboRadius.Enabled = false;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				case 13:
					sctWiz2.SctDepth = 2f;
					sctWiz2.FlangeWid = 2f;
					sctWiz2.LipLen = 1f;
					sctWiz2.WebAng = 1.30899692f;
					sctWiz2.LipAng = sctWiz2.WebAng;
					sctWiz2.RibSpa = 12f;
					sctWiz2.NumSpa = 1;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					break;
				case 14:
					lblDepth.Enabled = false;
					cboDepth.Enabled = false;
					lblWidth.Enabled = false;
					cboWidth.Enabled = false;
					lblLip.Enabled = false;
					cboLip.Enabled = false;
					lblWebAngle.Enabled = false;
					cboWebAngle.Enabled = false;
					lblLipAngle.Enabled = false;
					cboLipAngle.Enabled = false;
					lblRibSpacing.Enabled = false;
					cboRibSpacing.Enabled = false;
					lblNumSpacings.Enabled = false;
					txtNumSpacings.Enabled = false;
					break;
				}
				if (SctWiz.SctType == CFSInterface.SctWizSave.SctType) {
					SctWiz = CFSInterface.SctWizSave;
				}
				CFS.blnValidate = false;
				if (sctWiz2.ThicknessIndex == -1) {
					cboThicknessName.SelectedIndex = -1;
				} else {
					cboThicknessName.SelectedIndex = sctWiz2.ThicknessIndex - 1;
				}
				CFSInterface.SetText (cboThickness, sctWiz2.Thickness);
				if (sctWiz2.Rad == -1f) {
					cboRadius.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboRadius, sctWiz2.Rad);
				}
				if (sctWiz2.SctDepth == -1f) {
					cboDepth.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboDepth, sctWiz2.SctDepth);
				}
				if (sctWiz2.FlangeWid == -1f) {
					cboWidth.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboWidth, sctWiz2.FlangeWid);
				}
				if (sctWiz2.LipLen == -1f) {
					cboLip.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboLip, sctWiz2.LipLen);
				}
				if (sctWiz2.WebAng == -1f) {
					cboWebAngle.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboWebAngle, sctWiz2.WebAng);
				}
				if (sctWiz2.LipAng == -1f) {
					cboLipAngle.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboLipAngle, sctWiz2.LipAng);
				}
				if (sctWiz2.RibSpa == -1f) {
					cboRibSpacing.Text = string.Empty;
				} else {
					CFSInterface.SetText (cboRibSpacing, sctWiz2.RibSpa);
				}
				if (sctWiz2.NumSpa == -1) {
					txtNumSpacings.Text = string.Empty;
				} else {
					CFSInterface.SetText (txtNumSpacings, sctWiz2.NumSpa);
				}
				CFS.blnValidate = true;
				picSct.Image = tbrSections.Items [iButton - 1].Image;
				lblSct.Text = tbrSections.Items [iButton - 1].ToolTipText;
				cmdNext.Text = "&Finished";
				cmdNext.Refresh ();
				pnlSctWizard1.Visible = false;
				pnlSctWizard2.Visible = true;
				cboThicknessName.Select ();
			}
			Cursor.Current = Cursors.Default;
		}
	}

	private void ctrl_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void ctrl_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			ctrl_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			ctrl_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void ctrl_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void ctrl_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void ctrl_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		if (sender == cboThicknessName) {
			ref SectionWizard sctWiz = ref SctWiz;
			if (cboThicknessName.SelectedIndex > -1) {
				sctWiz.ThicknessIndex = checked((short)(cboThicknessName.SelectedIndex + 1));
				sctWiz.Thickness = CFS.Thicknesses [sctWiz.ThicknessIndex].Thickness;
				if (sctWiz.Rad > -1f) {
					sctWiz.Rad = CFS.Thicknesses [sctWiz.ThicknessIndex].DefRad;
				}
				CFS.iThickness = sctWiz.ThicknessIndex;
				CFS.blnValidate = false;
				CFSInterface.SetText (cboThickness, sctWiz.Thickness);
				if (sctWiz.Rad > -1f) {
					CFSInterface.SetText (cboRadius, sctWiz.Rad);
				}
				CFS.blnValidate = true;
			}
		} else if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void ctrl_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
			ref SectionWizard sctWiz = ref SctWiz;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboThickness)) {
				sctWiz.Thickness = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				checked {
					short num = (short)Information.UBound (CFS.Thicknesses);
					short num2;
					for (num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
						if (sctWiz.Thickness == CFS.Thicknesses [num2].Thickness) {
							sctWiz.ThicknessIndex = num2;
							if (sctWiz.Rad > -1f) {
								sctWiz.Rad = CFS.Thicknesses [num2].DefRad;
							}
							cboThicknessName.SelectedIndex = num2 - 1;
							CFS.iThickness = num2;
							break;
						}
					}
					if (num2 > Information.UBound (CFS.Thicknesses)) {
						sctWiz.ThicknessIndex = -1;
						if ((sctWiz.Rad > -1f) & (sctWiz.Rad < sctWiz.Thickness)) {
							sctWiz.Rad = sctWiz.Thickness;
						}
						cboThicknessName.SelectedIndex = -1;
					}
					if (sctWiz.Rad > -1f) {
						CFSInterface.SetText (cboRadius, sctWiz.Rad);
					}
				}
			} else if (flag == (sender == cboDepth)) {
				sctWiz.SctDepth = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboWidth)) {
				sctWiz.FlangeWid = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLip)) {
				sctWiz.LipLen = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboRadius)) {
				sctWiz.Rad = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboWebAngle)) {
				sctWiz.WebAng = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				if (iButton == 13) {
					sctWiz.LipAng = sctWiz.WebAng;
					CFSInterface.SetText (cboLipAngle, sctWiz.LipAng);
				}
			} else if (flag == (sender == cboLipAngle)) {
				sctWiz.LipAng = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboRibSpacing)) {
				sctWiz.RibSpa = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtNumSpacings)) {
				sctWiz.NumSpa = Conversions.ToShort (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { Conversions.ToString ((int)sctWiz.NumSpa) }, null, null, OptimisticSet: false, RValueBase: true);
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}
}
