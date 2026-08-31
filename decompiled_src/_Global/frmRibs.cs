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
public class frmRibs : Form
{
	private IContainer components;

	private InsertRibs InsertRibsTmp;

	[field: AccessedThroughProperty ("lblType")]
	internal virtual Label lblType {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tbrRib")]
	internal virtual ToolStrip tbrRib {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton btnSquare {
		[CompilerGenerated]
		get {
			return _btnSquare;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = btnSquare_Click;
			ToolStripButton toolStripButton = _btnSquare;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_btnSquare = value;
			toolStripButton = _btnSquare;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton btnRound {
		[CompilerGenerated]
		get {
			return _btnRound;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = btnRound_Click;
			ToolStripButton toolStripButton = _btnRound;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_btnRound = value;
			toolStripButton = _btnRound;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblSide")]
	internal virtual Label lblSide {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSide {
		[CompilerGenerated]
		get {
			return _cboSide;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_SelectedIndexChanged;
			ComboBox comboBox = _cboSide;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSide = value;
			comboBox = _cboSide;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblHeight")]
	internal virtual Label lblHeight {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboHeight {
		[CompilerGenerated]
		get {
			return _cboHeight;
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
			ComboBox comboBox = _cboHeight;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboHeight = value;
			comboBox = _cboHeight;
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

	[field: AccessedThroughProperty ("lblAngle")]
	internal virtual Label lblAngle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboAngle {
		[CompilerGenerated]
		get {
			return _cboAngle;
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
			ComboBox comboBox = _cboAngle;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboAngle = value;
			comboBox = _cboAngle;
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

	[field: AccessedThroughProperty ("lblRadius")]
	internal virtual Label lblRadius {
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

	[field: AccessedThroughProperty ("lblNumber")]
	internal virtual Label lblNumber {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtNumber {
		[CompilerGenerated]
		get {
			return _txtNumber;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtNumber;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtNumber = value;
			textBox = _txtNumber;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
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

	public frmRibs ()
	{
		base.Load += frmRibs_Load;
		base.KeyDown += frmRibs_KeyDown;
		base.HelpButtonClicked += frmRibs_HelpButtonClicked;
		base.FormClosing += frmRibs_FormClosing;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmRibs));
		this.lblType = new System.Windows.Forms.Label ();
		this.tbrRib = new System.Windows.Forms.ToolStrip ();
		this.btnSquare = new System.Windows.Forms.ToolStripButton ();
		this.btnRound = new System.Windows.Forms.ToolStripButton ();
		this.lblSide = new System.Windows.Forms.Label ();
		this.cboSide = new System.Windows.Forms.ComboBox ();
		this.lblHeight = new System.Windows.Forms.Label ();
		this.cboHeight = new System.Windows.Forms.ComboBox ();
		this.lblAngle = new System.Windows.Forms.Label ();
		this.cboAngle = new System.Windows.Forms.ComboBox ();
		this.lblWidth = new System.Windows.Forms.Label ();
		this.cboWidth = new System.Windows.Forms.ComboBox ();
		this.lblRadius = new System.Windows.Forms.Label ();
		this.cboRadius = new System.Windows.Forms.ComboBox ();
		this.lblNumber = new System.Windows.Forms.Label ();
		this.txtNumber = new System.Windows.Forms.TextBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.tbrRib.SuspendLayout ();
		base.SuspendLayout ();
		this.lblType.Location = new System.Drawing.Point (9, 9);
		this.lblType.Name = "lblType";
		this.lblType.Size = new System.Drawing.Size (268, 17);
		this.lblType.TabIndex = 0;
		this.lblType.Text = "Select the type of rib(s) to insert";
		this.tbrRib.AutoSize = false;
		this.tbrRib.BackColor = System.Drawing.SystemColors.Control;
		this.tbrRib.Dock = System.Windows.Forms.DockStyle.None;
		this.tbrRib.Items.AddRange (new System.Windows.Forms.ToolStripItem[2] { this.btnSquare, this.btnRound });
		this.tbrRib.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
		this.tbrRib.Location = new System.Drawing.Point (74, 26);
		this.tbrRib.Name = "tbrRib";
		this.tbrRib.Size = new System.Drawing.Size (138, 40);
		this.tbrRib.TabIndex = 1;
		this.tbrRib.Text = "Type of Rib";
		this.btnSquare.Checked = true;
		this.btnSquare.CheckState = System.Windows.Forms.CheckState.Checked;
		this.btnSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnSquare.Image = (System.Drawing.Image)resources.GetObject ("btnSquare.Image");
		this.btnSquare.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnSquare.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnSquare.Name = "btnSquare";
		this.btnSquare.Size = new System.Drawing.Size (68, 36);
		this.btnRound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.btnRound.Image = (System.Drawing.Image)resources.GetObject ("btnRound.Image");
		this.btnRound.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.btnRound.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.btnRound.Name = "btnRound";
		this.btnRound.Size = new System.Drawing.Size (68, 36);
		this.lblSide.Location = new System.Drawing.Point (21, 80);
		this.lblSide.Name = "lblSide";
		this.lblSide.Size = new System.Drawing.Size (101, 17);
		this.lblSide.TabIndex = 2;
		this.lblSide.Text = "Side of Element";
		this.cboSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSide.FormattingEnabled = true;
		this.cboSide.Location = new System.Drawing.Point (128, 77);
		this.cboSide.Name = "cboSide";
		this.cboSide.Size = new System.Drawing.Size (141, 21);
		this.cboSide.TabIndex = 3;
		this.lblHeight.Location = new System.Drawing.Point (21, 107);
		this.lblHeight.Name = "lblHeight";
		this.lblHeight.Size = new System.Drawing.Size (101, 17);
		this.lblHeight.TabIndex = 4;
		this.lblHeight.Text = "Rib Height";
		this.cboHeight.FormattingEnabled = true;
		this.cboHeight.Location = new System.Drawing.Point (128, 104);
		this.cboHeight.Name = "cboHeight";
		this.cboHeight.Size = new System.Drawing.Size (141, 21);
		this.cboHeight.TabIndex = 5;
		this.lblAngle.Location = new System.Drawing.Point (21, 134);
		this.lblAngle.Name = "lblAngle";
		this.lblAngle.Size = new System.Drawing.Size (101, 17);
		this.lblAngle.TabIndex = 6;
		this.lblAngle.Text = "Rib Side Angle";
		this.cboAngle.FormattingEnabled = true;
		this.cboAngle.Location = new System.Drawing.Point (128, 131);
		this.cboAngle.Name = "cboAngle";
		this.cboAngle.Size = new System.Drawing.Size (141, 21);
		this.cboAngle.TabIndex = 7;
		this.lblWidth.Location = new System.Drawing.Point (21, 161);
		this.lblWidth.Name = "lblWidth";
		this.lblWidth.Size = new System.Drawing.Size (101, 17);
		this.lblWidth.TabIndex = 8;
		this.lblWidth.Text = "Rib Top Width";
		this.cboWidth.FormattingEnabled = true;
		this.cboWidth.Location = new System.Drawing.Point (128, 158);
		this.cboWidth.Name = "cboWidth";
		this.cboWidth.Size = new System.Drawing.Size (141, 21);
		this.cboWidth.TabIndex = 9;
		this.lblRadius.Location = new System.Drawing.Point (21, 188);
		this.lblRadius.Name = "lblRadius";
		this.lblRadius.Size = new System.Drawing.Size (101, 17);
		this.lblRadius.TabIndex = 10;
		this.lblRadius.Text = "Inside Radius, R";
		this.cboRadius.FormattingEnabled = true;
		this.cboRadius.Location = new System.Drawing.Point (128, 185);
		this.cboRadius.Name = "cboRadius";
		this.cboRadius.Size = new System.Drawing.Size (141, 21);
		this.cboRadius.TabIndex = 11;
		this.lblNumber.Location = new System.Drawing.Point (21, 215);
		this.lblNumber.Name = "lblNumber";
		this.lblNumber.Size = new System.Drawing.Size (101, 17);
		this.lblNumber.TabIndex = 12;
		this.lblNumber.Text = "Number of Ribs";
		this.txtNumber.Location = new System.Drawing.Point (128, 212);
		this.txtNumber.Name = "txtNumber";
		this.txtNumber.Size = new System.Drawing.Size (141, 20);
		this.txtNumber.TabIndex = 13;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (113, 249);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 23);
		this.cmdOK.TabIndex = 14;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (194, 249);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 23);
		this.cmdCancel.TabIndex = 15;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (294, 285);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.txtNumber);
		base.Controls.Add (this.lblNumber);
		base.Controls.Add (this.cboRadius);
		base.Controls.Add (this.lblRadius);
		base.Controls.Add (this.cboWidth);
		base.Controls.Add (this.lblWidth);
		base.Controls.Add (this.cboAngle);
		base.Controls.Add (this.lblAngle);
		base.Controls.Add (this.cboHeight);
		base.Controls.Add (this.lblHeight);
		base.Controls.Add (this.cboSide);
		base.Controls.Add (this.lblSide);
		base.Controls.Add (this.tbrRib);
		base.Controls.Add (this.lblType);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmRibs";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Insert Ribs";
		this.tbrRib.ResumeLayout (false);
		this.tbrRib.PerformLayout ();
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmRibs_Load (object sender, EventArgs e)
	{
		cboHeight.Tag = new ControlData (1, 0.01f, 5f);
		cboAngle.Tag = new ControlData (3, (float)Math.PI / 6f, 2.61799383f);
		cboWidth.Tag = new ControlData (1, 0f, 10f);
		cboRadius.Tag = new ControlData (1, 0f, 10f);
		txtNumber.Tag = new ControlData (0, 1f, 10f);
		InsertRibsTmp = CFSInterface.InsertRibsNow;
		Section section = CFS.Sections [CFS.intSctNow];
		if (InsertRibsTmp.Radius < section.Part [section.iPart].DefRad) {
			InsertRibsTmp.Radius = section.Part [section.iPart].DefRad;
		}
		if (InsertRibsTmp.Radius > InsertRibsTmp.RibHeight) {
			InsertRibsTmp.RibHeight = InsertRibsTmp.Radius;
		}
		NewLateBinding.LateSetComplex (cboRadius.Tag, null, "Max", new object[1] { InsertRibsTmp.RibHeight }, null, null, OptimisticSet: false, RValueBase: true);
		cboSide.Items.Clear ();
		ref InsertRibs insertRibsTmp;
		checked {
			if (Math.Abs (Math.Sin (section.Part [section.iPart].Element [section.Part [section.iPart].ElemGrid.RowStart].Ang)) < 1.0 / Math.Sqrt (2.0)) {
				cboSide.Items.Add ("Above");
				cboSide.Items.Add ("Below");
				if ((InsertRibsTmp.Side == 0) | (InsertRibsTmp.Side == 1)) {
					cboSide.SelectedIndex = InsertRibsTmp.Side;
				} else {
					cboSide.SelectedIndex = 0;
				}
			} else {
				cboSide.Items.Add ("Left");
				cboSide.Items.Add ("Right");
				if ((InsertRibsTmp.Side == 2) | (InsertRibsTmp.Side == 3)) {
					cboSide.SelectedIndex = unchecked((int)InsertRibsTmp.Side) - 2;
				} else {
					cboSide.SelectedIndex = 0;
				}
			}
			section = null;
			CFS.blnValidate = false;
			insertRibsTmp = ref InsertRibsTmp;
			if (insertRibsTmp.RibType == 1) {
				btnSquare_Click (null, null);
			} else {
				btnRound_Click (null, null);
			}
			CFSInterface.SetText (cboHeight, insertRibsTmp.RibHeight);
			CFSInterface.SetText (cboAngle, insertRibsTmp.Angle);
			CFSInterface.SetText (cboWidth, insertRibsTmp.RibWidth);
			CFSInterface.SetText (cboRadius, insertRibsTmp.Radius);
		}
		CFSInterface.SetText (txtNumber, (int)insertRibsTmp.NumRibs);
		CFS.blnValidate = true;
	}

	private void frmRibs_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "insert-ribs.htm");
			e.Handled = true;
		}
	}

	private void frmRibs_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "insert-ribs.htm");
		e.Cancel = true;
	}

	private void btnSquare_Click (object sender, EventArgs e)
	{
		btnSquare.Checked = true;
		lblWidth.Enabled = true;
		cboWidth.Enabled = true;
		btnRound.Checked = false;
		lblRadius.Enabled = false;
		cboRadius.Enabled = false;
	}

	private void btnRound_Click (object sender, EventArgs e)
	{
		btnSquare.Checked = false;
		lblWidth.Enabled = false;
		cboWidth.Enabled = false;
		btnRound.Checked = true;
		lblRadius.Enabled = true;
		cboRadius.Enabled = true;
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
			base.AcceptButton = cmdOK;
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
		if (sender == cboSide) {
			ref InsertRibs insertRibsTmp = ref InsertRibsTmp;
			switch (cboSide.Text) {
			case "Above":
				insertRibsTmp.Side = 0;
				break;
			case "Below":
				insertRibsTmp.Side = 1;
				break;
			case "Left":
				insertRibsTmp.Side = 2;
				break;
			case "Right":
				insertRibsTmp.Side = 3;
				break;
			}
		} else if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void ctrl_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			ref InsertRibs insertRibsTmp = ref InsertRibsTmp;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboHeight)) {
				insertRibsTmp.RibHeight = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				NewLateBinding.LateSetComplex (cboRadius.Tag, null, "Max", new object[1] { insertRibsTmp.RibHeight }, null, null, OptimisticSet: false, RValueBase: true);
				if (insertRibsTmp.Radius > insertRibsTmp.RibHeight) {
					insertRibsTmp.Radius = insertRibsTmp.RibHeight;
					CFSInterface.SetText (cboRadius, insertRibsTmp.Radius);
				}
			} else if (flag == (sender == cboAngle)) {
				insertRibsTmp.Angle = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboWidth)) {
				insertRibsTmp.RibWidth = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboRadius)) {
				insertRibsTmp.Radius = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtNumber)) {
				insertRibsTmp.NumRibs = checked((byte)Conversions.ToShort (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null)));
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { Conversions.ToString (insertRibsTmp.NumRibs) }, null, null, OptimisticSet: false, RValueBase: true);
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		Cursor.Current = Cursors.WaitCursor;
		Part part = CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart];
		checked {
			byte b = (byte)(unchecked((int)part.ElemGrid.RowStart) + 1);
			short num = (short)(4 * unchecked((int)InsertRibsTmp.NumRibs));
			short num2 = (short)unchecked(part.nElem + num);
			byte b2 = unchecked((byte)((!part.Closed) ? 254 : byte.MaxValue));
			if (num2 > b2) {
				Cursor.Current = Cursors.Default;
				strMsg = ((!part.Closed) ? ("Limit " + Conversions.ToString (b2) + " elements for an open part.") : ("Limit " + Conversions.ToString (b2) + " elements for a closed part."));
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				return;
			}
			Hide ();
			CFSInterface.StoreUndoSct ("Insert Ribs");
			InsertRibsTmp.RibType = Conversions.ToByte (Interaction.IIf (btnSquare.Checked, 1, 2));
			if (num2 > Information.UBound (part.Element)) {
				ref Element[] element = ref part.Element;
				element = (Element[])Utils.CopyArray (element, new Element[(int)Math.Round (Math.Ceiling ((double)num2 / 10.0) * 10.0) + 1]);
			}
			byte nElem = part.nElem;
			short num3 = b;
			short num4;
			for (num4 = nElem; num4 >= num3; num4 = (short)unchecked(num4 + -1)) {
				part.Element [(short)unchecked(num4 + num)] = part.Element [num4];
			}
			short num5 = default(short);
			switch (InsertRibsTmp.Side) {
			case 0:
				num5 = (short)Math.Sign (Math.Cos (part.Element [unchecked((int)b) - 1].Ang));
				break;
			case 1:
				num5 = (short)(-Math.Sign (Math.Cos (part.Element [unchecked((int)b) - 1].Ang)));
				break;
			case 2:
				num5 = (short)Math.Sign (Math.Sin (part.Element [unchecked((int)b) - 1].Ang));
				break;
			case 3:
				num5 = (short)(-Math.Sign (Math.Sin (part.Element [unchecked((int)b) - 1].Ang)));
				break;
			}
			float len;
			float num6;
			float num7;
			if (part.Centerline) {
				len = (float)((double)InsertRibsTmp.RibHeight / Math.Sin (InsertRibsTmp.Angle));
				num6 = ((InsertRibsTmp.RibType != 1) ? ((float)((double)(2f * (InsertRibsTmp.Radius + part.Thickness / 2f)) * Math.Tan (InsertRibsTmp.Angle / 2f) * 1.0000001)) : InsertRibsTmp.RibWidth);
				num7 = (float)((double)num6 + (double)(2f * InsertRibsTmp.RibHeight) * Math.Cos (InsertRibsTmp.Angle) / Math.Sin (InsertRibsTmp.Angle));
			} else {
				len = (float)(((double)InsertRibsTmp.RibHeight - (double)part.Thickness * Math.Cos (InsertRibsTmp.Angle)) / Math.Sin (InsertRibsTmp.Angle));
				num6 = ((InsertRibsTmp.RibType != 1) ? ((float)((double)(2f * (InsertRibsTmp.Radius + part.Thickness)) * Math.Tan (InsertRibsTmp.Angle / 2f) * 1.0000001)) : InsertRibsTmp.RibWidth);
				num7 = (float)((double)num6 + 2.0 * ((double)InsertRibsTmp.RibHeight * Math.Cos (InsertRibsTmp.Angle) - (double)part.Thickness) / Math.Sin (InsertRibsTmp.Angle));
			}
			float len2 = (part.Element [unchecked((int)b) - 1].Len - (float)unchecked((int)InsertRibsTmp.NumRibs) * num7) / (float)(unchecked((int)InsertRibsTmp.NumRibs) + 1);
			num4 = b;
			part.Element [b].Len = len;
			part.Element [b].Ang = part.Element [unchecked((int)b) - 1].Ang + (float)num5 * InsertRibsTmp.Angle;
			part.Element [b].Rad = part.DefRad;
			part.Element [b].Web = 1;
			part.Element [b].K = 0f;
			part.Element [b].Hole = 0f;
			part.Element [b].Dist = part.Element [b].Len / 2f;
			part.Element [unchecked((int)b) + 1].Len = num6;
			part.Element [unchecked((int)b) + 1].Ang = part.Element [unchecked((int)b) - 1].Ang;
			if (InsertRibsTmp.RibType == 1) {
				part.Element [unchecked((int)b) + 1].Rad = part.DefRad;
			} else {
				part.Element [unchecked((int)b) + 1].Rad = InsertRibsTmp.Radius;
			}
			part.Element [unchecked((int)b) + 1].Web = 1;
			part.Element [unchecked((int)b) + 1].K = 0f;
			part.Element [unchecked((int)b) + 1].Hole = 0f;
			part.Element [unchecked((int)b) + 1].Dist = part.Element [unchecked((int)b) + 1].Len / 2f;
			part.Element [unchecked((int)b) + 2].Len = len;
			part.Element [unchecked((int)b) + 2].Ang = part.Element [unchecked((int)b) - 1].Ang - (float)num5 * InsertRibsTmp.Angle;
			if (InsertRibsTmp.RibType == 1) {
				part.Element [unchecked((int)b) + 2].Rad = part.DefRad;
			} else {
				part.Element [unchecked((int)b) + 2].Rad = InsertRibsTmp.Radius;
			}
			part.Element [unchecked((int)b) + 2].Web = 1;
			part.Element [unchecked((int)b) + 2].K = 0f;
			part.Element [unchecked((int)b) + 2].Hole = 0f;
			part.Element [unchecked((int)b) + 2].Dist = part.Element [unchecked((int)b) + 2].Len / 2f;
			part.Element [unchecked((int)b) + 3].Len = len2;
			part.Element [unchecked((int)b) + 3].Ang = part.Element [unchecked((int)b) - 1].Ang;
			part.Element [unchecked((int)b) + 3].Rad = part.DefRad;
			part.Element [unchecked((int)b) + 3].Web = part.Element [unchecked((int)b) - 1].Web;
			part.Element [unchecked((int)b) + 3].K = 0f;
			part.Element [unchecked((int)b) + 3].Hole = 0f;
			part.Element [unchecked((int)b) + 3].Dist = part.Element [unchecked((int)b) + 3].Len / 2f;
			short numRibs = InsertRibsTmp.NumRibs;
			for (short num8 = 2; num8 <= numRibs; num8 = (short)unchecked(num8 + 1)) {
				num4 = (short)(unchecked((int)b) + 4 * (num8 - 1));
				part.Element [num4] = part.Element [b];
				part.Element [num4 + 1] = part.Element [unchecked((int)b) + 1];
				part.Element [num4 + 2] = part.Element [unchecked((int)b) + 2];
				part.Element [num4 + 3] = part.Element [unchecked((int)b) + 3];
			}
			part.Element [unchecked((int)b) - 1].Len = len2;
			part.Element [unchecked((int)b) - 1].K = 0f;
			part.Element [unchecked((int)b) - 1].Hole = 0f;
			part.Element [unchecked((int)b) - 1].Dist = part.Element [unchecked((int)b) - 1].Len / 2f;
			part.nElem = (byte)num2;
			part = null;
			Section section = CFS.Sections [CFS.intSctNow];
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
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			section = null;
			CFSInterface.InsertRibsNow = InsertRibsTmp;
			Close ();
			Cursor.Current = Cursors.Default;
		}
	}

	private void frmRibs_FormClosing (object sender, FormClosingEventArgs e)
	{
		cboSide.Select ();
	}
}
