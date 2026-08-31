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
using RSG.Utility;

[DesignerGenerated]
public class frmBuckleParam : Form
{
	private IContainer components;

	private BuckleParameters BuckleParametersTmp;

	private float Fc;

	private ScaleGraphics SG;

	[field: AccessedThroughProperty ("lblLengthMin")]
	internal virtual Label lblLengthMin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblLenghMax")]
	internal virtual Label lblLenghMax {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblIncrement")]
	internal virtual Label lblIncrement {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLengthMin {
		[CompilerGenerated]
		get {
			return _cboLengthMin;
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
			ComboBox comboBox = _cboLengthMin;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLengthMin = value;
			comboBox = _cboLengthMin;
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

	internal virtual ComboBox cboLengthMax {
		[CompilerGenerated]
		get {
			return _cboLengthMax;
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
			ComboBox comboBox = _cboLengthMax;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLengthMax = value;
			comboBox = _cboLengthMax;
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

	internal virtual ComboBox cboResolution {
		[CompilerGenerated]
		get {
			return _cboResolution;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboResolution_SelectedIndexChanged;
			ComboBox comboBox = _cboResolution;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboResolution = value;
			comboBox = _cboResolution;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("picStress")]
	internal virtual PictureBox picStress {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TrackBar sldY {
		[CompilerGenerated]
		get {
			return _sldY;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = sldY_Scroll;
			TrackBar trackBar = _sldY;
			if (trackBar != null) {
				trackBar.Scroll -= value2;
			}
			_sldY = value;
			trackBar = _sldY;
			if (trackBar != null) {
				trackBar.Scroll += value2;
			}
		}
	}

	internal virtual TrackBar sldX {
		[CompilerGenerated]
		get {
			return _sldX;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = sldX_Scroll;
			TrackBar trackBar = _sldX;
			if (trackBar != null) {
				trackBar.Scroll -= value2;
			}
			_sldX = value;
			trackBar = _sldX;
			if (trackBar != null) {
				trackBar.Scroll += value2;
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

	[field: AccessedThroughProperty ("lblStress")]
	internal virtual Label lblStress {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkConstrained {
		[CompilerGenerated]
		get {
			return _chkConstrained;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkAdjust_CheckedChanged;
			CheckBox checkBox = _chkConstrained;
			if (checkBox != null) {
				checkBox.CheckedChanged -= value2;
			}
			_chkConstrained = value;
			checkBox = _chkConstrained;
			if (checkBox != null) {
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("chkAltMethod")]
	internal virtual CheckBox chkAltMethod {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblFbx")]
	internal virtual Label lblFbx {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblFby")]
	internal virtual Label lblFby {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtFbx {
		[CompilerGenerated]
		get {
			return _txtFbx;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtFbx;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtFbx = value;
			textBox = _txtFbx;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	internal virtual TextBox txtFby {
		[CompilerGenerated]
		get {
			return _txtFby;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtFby;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtFby = value;
			textBox = _txtFby;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lblFc")]
	internal virtual Label lblFc {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtFc {
		[CompilerGenerated]
		get {
			return _txtFc;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtFc;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtFc = value;
			textBox = _txtFc;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("chkRepeat")]
	internal virtual CheckBox chkRepeat {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblBimoment")]
	internal virtual Label lblBimoment {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdBimoment {
		[CompilerGenerated]
		get {
			return _cmdBimoment;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdBimoment_Click;
			Button button = _cmdBimoment;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdBimoment = value;
			button = _cmdBimoment;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmBuckleParam ()
	{
		base.Load += frmBuckleParam_Load;
		base.KeyDown += frmBuckleParam_KeyDown;
		base.HelpButtonClicked += frmBuckleParam_HelpButtonClicked;
		base.FormClosing += frmBuckleParam_FormClosing;
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
		this.lblLengthMin = new System.Windows.Forms.Label ();
		this.lblLenghMax = new System.Windows.Forms.Label ();
		this.lblIncrement = new System.Windows.Forms.Label ();
		this.cboLengthMin = new System.Windows.Forms.ComboBox ();
		this.cboLengthMax = new System.Windows.Forms.ComboBox ();
		this.cboResolution = new System.Windows.Forms.ComboBox ();
		this.picStress = new System.Windows.Forms.PictureBox ();
		this.sldY = new System.Windows.Forms.TrackBar ();
		this.sldX = new System.Windows.Forms.TrackBar ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblStress = new System.Windows.Forms.Label ();
		this.chkConstrained = new System.Windows.Forms.CheckBox ();
		this.chkAltMethod = new System.Windows.Forms.CheckBox ();
		this.lblFbx = new System.Windows.Forms.Label ();
		this.lblFby = new System.Windows.Forms.Label ();
		this.txtFbx = new System.Windows.Forms.TextBox ();
		this.txtFby = new System.Windows.Forms.TextBox ();
		this.lblFc = new System.Windows.Forms.Label ();
		this.txtFc = new System.Windows.Forms.TextBox ();
		this.chkRepeat = new System.Windows.Forms.CheckBox ();
		this.lblBimoment = new System.Windows.Forms.Label ();
		this.cmdBimoment = new System.Windows.Forms.Button ();
		((System.ComponentModel.ISupportInitialize)this.picStress).BeginInit ();
		((System.ComponentModel.ISupportInitialize)this.sldY).BeginInit ();
		((System.ComponentModel.ISupportInitialize)this.sldX).BeginInit ();
		base.SuspendLayout ();
		this.lblLengthMin.Location = new System.Drawing.Point (16, 14);
		this.lblLengthMin.Name = "lblLengthMin";
		this.lblLengthMin.Size = new System.Drawing.Size (100, 20);
		this.lblLengthMin.TabIndex = 0;
		this.lblLengthMin.Text = "Start Length";
		this.lblLenghMax.Location = new System.Drawing.Point (16, 43);
		this.lblLenghMax.Name = "lblLenghMax";
		this.lblLenghMax.Size = new System.Drawing.Size (100, 20);
		this.lblLenghMax.TabIndex = 2;
		this.lblLenghMax.Text = "End Length";
		this.lblIncrement.Location = new System.Drawing.Point (16, 72);
		this.lblIncrement.Name = "lblIncrement";
		this.lblIncrement.Size = new System.Drawing.Size (100, 20);
		this.lblIncrement.TabIndex = 4;
		this.lblIncrement.Text = "Increment Size";
		this.cboLengthMin.FormattingEnabled = true;
		this.cboLengthMin.Location = new System.Drawing.Point (122, 11);
		this.cboLengthMin.Name = "cboLengthMin";
		this.cboLengthMin.Size = new System.Drawing.Size (132, 21);
		this.cboLengthMin.TabIndex = 1;
		this.cboLengthMax.FormattingEnabled = true;
		this.cboLengthMax.Location = new System.Drawing.Point (122, 40);
		this.cboLengthMax.Name = "cboLengthMax";
		this.cboLengthMax.Size = new System.Drawing.Size (132, 21);
		this.cboLengthMax.TabIndex = 3;
		this.cboResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboResolution.FormattingEnabled = true;
		this.cboResolution.Location = new System.Drawing.Point (122, 69);
		this.cboResolution.Name = "cboResolution";
		this.cboResolution.Size = new System.Drawing.Size (132, 21);
		this.cboResolution.TabIndex = 5;
		this.picStress.BackColor = System.Drawing.SystemColors.Window;
		this.picStress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picStress.Location = new System.Drawing.Point (46, 197);
		this.picStress.Name = "picStress";
		this.picStress.Size = new System.Drawing.Size (100, 145);
		this.picStress.TabIndex = 6;
		this.picStress.TabStop = false;
		this.sldY.AutoSize = false;
		this.sldY.LargeChange = 200;
		this.sldY.Location = new System.Drawing.Point (46, 171);
		this.sldY.Maximum = 1000;
		this.sldY.Minimum = -1000;
		this.sldY.Name = "sldY";
		this.sldY.Size = new System.Drawing.Size (99, 42);
		this.sldY.SmallChange = 100;
		this.sldY.TabIndex = 10;
		this.sldY.TickStyle = System.Windows.Forms.TickStyle.None;
		this.sldX.LargeChange = 200;
		this.sldX.Location = new System.Drawing.Point (18, 197);
		this.sldX.Maximum = 1000;
		this.sldX.Minimum = -1000;
		this.sldX.Name = "sldX";
		this.sldX.Orientation = System.Windows.Forms.Orientation.Vertical;
		this.sldX.Size = new System.Drawing.Size (45, 145);
		this.sldX.SmallChange = 100;
		this.sldX.TabIndex = 9;
		this.sldX.TickStyle = System.Windows.Forms.TickStyle.None;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (163, 305);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (91, 25);
		this.cmdOK.TabIndex = 19;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (163, 336);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (91, 25);
		this.cmdCancel.TabIndex = 20;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblStress.Location = new System.Drawing.Point (46, 345);
		this.lblStress.Name = "lblStress";
		this.lblStress.Size = new System.Drawing.Size (99, 20);
		this.lblStress.TabIndex = 11;
		this.lblStress.Text = "Stress Distribution";
		this.lblStress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.chkConstrained.Location = new System.Drawing.Point (19, 122);
		this.chkConstrained.Name = "chkConstrained";
		this.chkConstrained.Size = new System.Drawing.Size (246, 20);
		this.chkConstrained.TabIndex = 7;
		this.chkConstrained.Text = "Constrained Bending";
		this.chkConstrained.UseVisualStyleBackColor = true;
		this.chkAltMethod.Location = new System.Drawing.Point (19, 96);
		this.chkAltMethod.Name = "chkAltMethod";
		this.chkAltMethod.Size = new System.Drawing.Size (246, 20);
		this.chkAltMethod.TabIndex = 6;
		this.chkAltMethod.Text = "Use Alternate Method (slower)";
		this.chkAltMethod.UseVisualStyleBackColor = true;
		this.lblFbx.AutoSize = true;
		this.lblFbx.Location = new System.Drawing.Point (160, 200);
		this.lblFbx.Name = "lblFbx";
		this.lblFbx.Size = new System.Drawing.Size (21, 13);
		this.lblFbx.TabIndex = 12;
		this.lblFbx.Text = "fbx";
		this.lblFby.AutoSize = true;
		this.lblFby.Location = new System.Drawing.Point (160, 226);
		this.lblFby.Name = "lblFby";
		this.lblFby.Size = new System.Drawing.Size (21, 13);
		this.lblFby.TabIndex = 14;
		this.lblFby.Text = "fby";
		this.txtFbx.Location = new System.Drawing.Point (187, 197);
		this.txtFbx.Name = "txtFbx";
		this.txtFbx.Size = new System.Drawing.Size (67, 20);
		this.txtFbx.TabIndex = 13;
		this.txtFbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.txtFby.Location = new System.Drawing.Point (187, 223);
		this.txtFby.Name = "txtFby";
		this.txtFby.Size = new System.Drawing.Size (67, 20);
		this.txtFby.TabIndex = 15;
		this.txtFby.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.lblFc.AutoSize = true;
		this.lblFc.Location = new System.Drawing.Point (160, 252);
		this.lblFc.Name = "lblFc";
		this.lblFc.Size = new System.Drawing.Size (16, 13);
		this.lblFc.TabIndex = 16;
		this.lblFc.Text = "fc";
		this.txtFc.Location = new System.Drawing.Point (187, 249);
		this.txtFc.Name = "txtFc";
		this.txtFc.Size = new System.Drawing.Size (67, 20);
		this.txtFc.TabIndex = 17;
		this.txtFc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.chkRepeat.Location = new System.Drawing.Point (19, 148);
		this.chkRepeat.Name = "chkRepeat";
		this.chkRepeat.Size = new System.Drawing.Size (246, 20);
		this.chkRepeat.TabIndex = 8;
		this.chkRepeat.Text = "Repeating Connected Shape (e.g., panel)";
		this.chkRepeat.UseVisualStyleBackColor = true;
		this.lblBimoment.AutoSize = true;
		this.lblBimoment.Location = new System.Drawing.Point (160, 280);
		this.lblBimoment.Name = "lblBimoment";
		this.lblBimoment.Size = new System.Drawing.Size (53, 13);
		this.lblBimoment.TabIndex = 18;
		this.lblBimoment.Text = "Bimoment";
		this.lblBimoment.Visible = false;
		this.cmdBimoment.Location = new System.Drawing.Point (229, 274);
		this.cmdBimoment.Name = "cmdBimoment";
		this.cmdBimoment.Size = new System.Drawing.Size (25, 25);
		this.cmdBimoment.TabIndex = 19;
		this.cmdBimoment.UseVisualStyleBackColor = true;
		this.cmdBimoment.Visible = false;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (268, 372);
		base.Controls.Add (this.cmdBimoment);
		base.Controls.Add (this.lblBimoment);
		base.Controls.Add (this.chkRepeat);
		base.Controls.Add (this.txtFc);
		base.Controls.Add (this.lblFc);
		base.Controls.Add (this.txtFby);
		base.Controls.Add (this.txtFbx);
		base.Controls.Add (this.lblFby);
		base.Controls.Add (this.lblFbx);
		base.Controls.Add (this.picStress);
		base.Controls.Add (this.chkAltMethod);
		base.Controls.Add (this.chkConstrained);
		base.Controls.Add (this.lblStress);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.sldX);
		base.Controls.Add (this.sldY);
		base.Controls.Add (this.cboResolution);
		base.Controls.Add (this.cboLengthMax);
		base.Controls.Add (this.cboLengthMin);
		base.Controls.Add (this.lblIncrement);
		base.Controls.Add (this.lblLenghMax);
		base.Controls.Add (this.lblLengthMin);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBuckleParam";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Elastic Buckling Parameters";
		((System.ComponentModel.ISupportInitialize)this.picStress).EndInit ();
		((System.ComponentModel.ISupportInitialize)this.sldY).EndInit ();
		((System.ComponentModel.ISupportInitialize)this.sldX).EndInit ();
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	public void DrawDiagram ()
	{
		float[,] array = new float[3, 3];
		float[,] array2 = new float[3, 3];
		float[,] array3 = new float[3, 3];
		float[,] array4 = new float[3, 3];
		Pen pen = new Pen (SystemColors.ButtonFace, SG.UnitsPerPixelX);
		if (BuckleParametersTmp.Bimoment != 0) {
			SG.Clear ();
			SG.PreserveImage ();
			return;
		}
		float num;
		float num2;
		if (!BuckleParametersTmp.Constrained) {
			ref Section.PropertiesType prop = ref CFS.Sections [CFS.intSctNow].Prop;
			num = (BuckleParametersTmp.Fbx * prop.Ix * prop.Iy - BuckleParametersTmp.Fby * prop.Ixy * prop.Ix * prop.Sy / prop.Sx) / (prop.Ix * prop.Iy - prop.Ixy * prop.Ixy);
			num2 = (BuckleParametersTmp.Fby * prop.Ix * prop.Iy - BuckleParametersTmp.Fbx * prop.Ixy * prop.Iy * prop.Sx / prop.Sy) / (prop.Ix * prop.Iy - prop.Ixy * prop.Ixy);
		} else {
			num = BuckleParametersTmp.Fbx;
			num2 = BuckleParametersTmp.Fby;
		}
		float fc = BuckleParametersTmp.Fc;
		float num3 = fc + Math.Abs (num) + Math.Abs (num2);
		short num4 = 0;
		checked {
			short num5;
			do {
				num5 = 0;
				do {
					float num6 = (fc + num * (float)(num5 - 1) + num2 * (float)(num4 - 1)) / num3;
					array [num4, num5] = (float)(0.866 * (double)(num4 - 1));
					array2 [num4, num5] = (float)(1.5 * (double)(num5 - 1) - 0.5 * (double)(num4 - 1));
					array3 [num4, num5] = (float)((double)array [num4, num5] - 0.866 * (double)num6);
					array4 [num4, num5] = (float)((double)array2 [num4, num5] - 0.5 * (double)num6);
					num5 = (short)unchecked(num5 + 1);
				} while (num5 <= 2);
				num4 = (short)unchecked(num4 + 1);
			} while (num4 <= 2);
			SG.Clear ();
			float num7 = array [0, 1];
			float num8 = array [2, 1];
			float unitsPerPixelX = SG.UnitsPerPixelX;
			bool flag = unitsPerPixelX >= 0f;
			float num9;
			for (num9 = num7; flag ? (num9 <= num8) : (num9 >= num8); num9 += unitsPerPixelX) {
				float num10 = (float)(-0.5 * (double)num9 / 0.866);
				SG.Graphics.DrawLine (pen, num9, array2 [1, 0] + num10, num9, array2 [1, 2] + num10);
			}
			pen = new Pen (SystemColors.ControlText, SG.UnitsPerPixelX);
			num4 = 0;
			do {
				SG.Graphics.DrawLine (pen, array [num4, 0], array2 [num4, 0], array [num4, 2], array2 [num4, 2]);
				SG.Graphics.DrawLine (pen, array3 [num4, 0], array4 [num4, 0], array3 [num4, 2], array4 [num4, 2]);
				num4 = (short)unchecked(num4 + 1);
			} while (num4 <= 2);
			num5 = 0;
			do {
				SG.Graphics.DrawLine (pen, array [0, num5], array2 [0, num5], array [2, num5], array2 [2, num5]);
				SG.Graphics.DrawLine (pen, array3 [0, num5], array4 [0, num5], array3 [2, num5], array4 [2, num5]);
				num5 = (short)unchecked(num5 + 1);
			} while (num5 <= 2);
			num9 = array [2, 1] / 3f;
			num4 = 0;
			do {
				num5 = 0;
				do {
					SG.Graphics.DrawLine (pen, array [num4, num5], array2 [num4, num5], array3 [num4, num5], array4 [num4, num5]);
					float num11 = array [num4, num5] - array3 [num4, num5];
					if (num11 > num9) {
						SG.Graphics.DrawLine (pen, array [num4, num5], array2 [num4, num5], array [num4, num5] - num9, array2 [num4, num5]);
					} else if (num11 < 0f - num9) {
						SG.Graphics.DrawLine (pen, array [num4, num5], array2 [num4, num5], array [num4, num5] + num9, array2 [num4, num5]);
					}
					num5 = (short)unchecked(num5 + 1);
				} while (num5 <= 2);
				num4 = (short)unchecked(num4 + 1);
			} while (num4 <= 2);
			SG.PreserveImage ();
		}
	}

	private void frmBuckleParam_Load (object sender, EventArgs e)
	{
		Section section = CFS.Sections [CFS.intSctNow];
		float num = (float)(0.075 * (double)section.Prop.Rc);
		num = (float)(0.75 * Math.Pow (2.0, Math.Ceiling (Math.Log ((double)num / 0.75, 2.0))));
		if ((double)num < 0.299999) {
			num = 0.299999f;
		}
		section = null;
		cboLengthMin.Tag = new ControlData (2, num, 1200f);
		cboLengthMax.Tag = new ControlData (2, num, 1200f);
		txtFbx.Tag = new ControlData (0, -1f, 1f);
		txtFby.Tag = new ControlData (0, -1f, 1f);
		txtFc.Tag = new ControlData (0, 0f, 1f);
		cboResolution.Items.Add ("Small (slower)");
		cboResolution.Items.Add ("Medium");
		cboResolution.Items.Add ("Large (faster)");
		SG = new ScaleGraphics (picStress);
		float num2 = SG.Height / SG.Width;
		SG.Scale (-2.5f, (float)(2.5 * (double)num2), 2.5f, (float)(-2.5 * (double)num2));
		BuckleParametersTmp = CFSInterface.BuckleParametersNow;
		CFS.blnValidate = false;
		ref BuckleParameters buckleParametersTmp = ref BuckleParametersTmp;
		if (buckleParametersTmp.intSection == CFS.intSctNow) {
			if (buckleParametersTmp.Lmin < num) {
				buckleParametersTmp.Lmin = num;
			}
		} else {
			if (buckleParametersTmp.Lmin < 2f * num) {
				buckleParametersTmp.Lmin = 2f * num;
			}
			buckleParametersTmp.intSection = CFS.intSctNow;
			buckleParametersTmp.Repeat = false;
		}
		if (buckleParametersTmp.Lmax < buckleParametersTmp.Lmin) {
			buckleParametersTmp.Lmax = buckleParametersTmp.Lmin;
		}
		CFSInterface.SetText (cboLengthMin, buckleParametersTmp.Lmin);
		CFSInterface.SetText (cboLengthMax, buckleParametersTmp.Lmax);
		checked {
			cboResolution.SelectedIndex = buckleParametersTmp.Resolution - 1;
			sldX.Value = (int)Math.Round (buckleParametersTmp.Fbx * (float)sldX.Maximum);
			sldY.Value = (int)Math.Round (buckleParametersTmp.Fby * (float)sldY.Maximum);
			CFSInterface.SetText (txtFbx, buckleParametersTmp.Fbx);
			CFSInterface.SetText (txtFby, buckleParametersTmp.Fby);
			CFSInterface.SetText (txtFc, buckleParametersTmp.Fc);
			chkConstrained.Checked = buckleParametersTmp.Constrained;
			chkAltMethod.Checked = buckleParametersTmp.AltMethod;
			if ((CFS.Sections [CFS.intSctNow].nPart > 1) | CFS.Sections [CFS.intSctNow].Part [1].Closed) {
				chkRepeat.Checked = false;
				chkRepeat.Enabled = false;
			} else {
				chkRepeat.Checked = buckleParametersTmp.Repeat;
			}
			if (BuckleParametersTmp.Bimoment == 0) {
				cmdBimoment.Text = "";
			} else {
				lblBimoment.Visible = true;
				cmdBimoment.Visible = true;
				cmdBimoment.Text = Conversions.ToString (Interaction.IIf (BuckleParametersTmp.Bimoment > 0, "+", "–"));
				sldX.Enabled = false;
				sldY.Enabled = false;
				txtFbx.Enabled = false;
				txtFby.Enabled = false;
				txtFc.Enabled = false;
			}
			CFS.blnValidate = true;
			DrawDiagram ();
		}
	}

	private void frmBuckleParam_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-parameters.htm");
			e.Handled = true;
		} else if ((e.KeyCode == Keys.B) & e.Control & e.Shift) {
			lblBimoment.Visible = !lblBimoment.Visible;
			cmdBimoment.Visible = !cmdBimoment.Visible;
			e.Handled = true;
		}
	}

	private void frmBuckleParam_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-parameters.htm");
		e.Cancel = true;
	}

	private void frmBuckleParam_FormClosing (object sender, FormClosingEventArgs e)
	{
		cboLengthMin.Select ();
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
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void ctrl_Validating (object sender, CancelEventArgs e)
	{
		checked {
			if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				base.AcceptButton = cmdOK;
				base.CancelButton = cmdCancel;
			} else if (CFSInterface.Validate ((Control)sender)) {
				base.AcceptButton = cmdOK;
				base.CancelButton = cmdCancel;
				bool flag = true;
				if (flag == (sender == cboLengthMax)) {
					BuckleParametersTmp.Lmax = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				} else if (flag == (sender == cboLengthMin)) {
					BuckleParametersTmp.Lmin = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				} else if (flag == (sender == txtFbx)) {
					ref BuckleParameters buckleParametersTmp = ref BuckleParametersTmp;
					buckleParametersTmp.Fbx = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
					sldX.Value = (int)Math.Round ((float)sldX.Maximum * buckleParametersTmp.Fbx);
					if (((double)Math.Abs (buckleParametersTmp.Fc) < 0.01) | (Math.Abs (buckleParametersTmp.Fbx) + Math.Abs (buckleParametersTmp.Fby) > 1f)) {
						buckleParametersTmp.Fby = (float)Math.Sign (buckleParametersTmp.Fby) * (1f - Math.Abs (buckleParametersTmp.Fbx));
						sldY.Value = (int)Math.Round ((float)sldY.Maximum * buckleParametersTmp.Fby);
						txtFby.Text = Units.DisplayNone (buckleParametersTmp.Fby, "", 0, 0);
					}
					buckleParametersTmp.Fc = 1f - Math.Abs (buckleParametersTmp.Fbx) - Math.Abs (buckleParametersTmp.Fby);
					if ((double)Math.Abs (buckleParametersTmp.Fc) < 1E-06) {
						buckleParametersTmp.Fc = 0f;
					}
					txtFc.Text = Units.DisplayNone (buckleParametersTmp.Fc, "", 0, 0);
					DrawDiagram ();
				} else if (flag == (sender == txtFby)) {
					ref BuckleParameters buckleParametersTmp2 = ref BuckleParametersTmp;
					buckleParametersTmp2.Fby = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
					sldY.Value = (int)Math.Round ((float)sldY.Maximum * buckleParametersTmp2.Fby);
					if (((double)Math.Abs (buckleParametersTmp2.Fc) < 0.01) | (Math.Abs (buckleParametersTmp2.Fbx) + Math.Abs (buckleParametersTmp2.Fby) > 1f)) {
						buckleParametersTmp2.Fbx = (float)Math.Sign (buckleParametersTmp2.Fbx) * (1f - Math.Abs (buckleParametersTmp2.Fby));
						sldX.Value = (int)Math.Round ((float)sldX.Maximum * buckleParametersTmp2.Fbx);
						txtFbx.Text = Units.DisplayNone (buckleParametersTmp2.Fbx, "", 0, 0);
					}
					buckleParametersTmp2.Fc = 1f - Math.Abs (buckleParametersTmp2.Fbx) - Math.Abs (buckleParametersTmp2.Fby);
					if ((double)Math.Abs (buckleParametersTmp2.Fc) < 1E-06) {
						buckleParametersTmp2.Fc = 0f;
					}
					txtFc.Text = Units.DisplayNone (buckleParametersTmp2.Fc, "", 0, 0);
					DrawDiagram ();
				} else if (flag == (sender == txtFc)) {
					ref BuckleParameters buckleParametersTmp3 = ref BuckleParametersTmp;
					buckleParametersTmp3.Fc = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
					if ((buckleParametersTmp3.Fbx == 0f) & (buckleParametersTmp3.Fby == 0f)) {
						buckleParametersTmp3.Fbx = 1f;
					}
					buckleParametersTmp3.Fbx = (1f - buckleParametersTmp3.Fc) * buckleParametersTmp3.Fbx / (Math.Abs (buckleParametersTmp3.Fbx) + Math.Abs (buckleParametersTmp3.Fby));
					buckleParametersTmp3.Fby = (float)Math.Sign (buckleParametersTmp3.Fby) * (1f - buckleParametersTmp3.Fc - Math.Abs (buckleParametersTmp3.Fbx));
					sldX.Value = (int)Math.Round ((float)sldX.Maximum * buckleParametersTmp3.Fbx);
					sldY.Value = (int)Math.Round ((float)sldY.Maximum * buckleParametersTmp3.Fby);
					txtFbx.Text = Units.DisplayNone (buckleParametersTmp3.Fbx, "", 0, 0);
					txtFby.Text = Units.DisplayNone (buckleParametersTmp3.Fby, "", 0, 0);
					DrawDiagram ();
				}
				CFS.blnValidate = false;
				NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
				CFS.blnValidate = true;
			} else {
				e.Cancel = true;
			}
		}
	}

	private void cboResolution_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			BuckleParametersTmp.Resolution = checked((short)(cboResolution.SelectedIndex + 1));
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		if (BuckleParametersTmp.Lmin > BuckleParametersTmp.Lmax) {
			Interaction.MsgBox ("End Length must be greater than Start Length.", MsgBoxStyle.Information);
			return;
		}
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			CFS.LicenseRequired ("This calculation requires a full CFS license.");
			return;
		}
		BuckleParametersTmp.Constrained = chkConstrained.Checked;
		BuckleParametersTmp.AltMethod = chkAltMethod.Checked;
		BuckleParametersTmp.Repeat = chkRepeat.Checked;
		CFSInterface.BuckleParametersNow = BuckleParametersTmp;
		Hide ();
		My.MyProject.Forms.frmBuckleProgress.ShowDialog (My.MyProject.Forms.mdiCFS);
		if (My.MyProject.Forms.frmBuckleProgress.DialogResult != DialogResult.Cancel) {
			My.MyProject.Forms.frmBuckleProfile.ShowDialog (My.MyProject.Forms.mdiCFS);
			My.MyProject.Forms.frmBuckleProfile.Dispose ();
		}
		My.MyProject.Forms.frmBuckleProgress.Dispose ();
		Close ();
	}

	private void sldX_Scroll (object sender, EventArgs e)
	{
		checked {
			sldX.Value = 100 * (int)Math.Round ((double)sldX.Value / 100.0);
			ref BuckleParameters buckleParametersTmp = ref BuckleParametersTmp;
			buckleParametersTmp.Fbx = (float)((double)sldX.Value / (double)sldX.Maximum);
			if (((double)Math.Abs (buckleParametersTmp.Fc) < 0.01) | (Math.Abs (buckleParametersTmp.Fbx) + Math.Abs (buckleParametersTmp.Fby) > 1f)) {
				buckleParametersTmp.Fby = (float)Math.Sign (buckleParametersTmp.Fby) * (1f - Math.Abs (buckleParametersTmp.Fbx));
				sldY.Value = (int)Math.Round ((float)sldY.Maximum * buckleParametersTmp.Fby);
			}
			buckleParametersTmp.Fc = 1f - Math.Abs (buckleParametersTmp.Fbx) - Math.Abs (buckleParametersTmp.Fby);
			if ((double)Math.Abs (buckleParametersTmp.Fc) < 1E-06) {
				buckleParametersTmp.Fc = 0f;
			}
			txtFbx.Text = Units.DisplayNone (buckleParametersTmp.Fbx, "", 0, 0);
			txtFby.Text = Units.DisplayNone (buckleParametersTmp.Fby, "", 0, 0);
			txtFc.Text = Units.DisplayNone (buckleParametersTmp.Fc, "", 0, 0);
			DrawDiagram ();
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		}
	}

	private void sldY_Scroll (object sender, EventArgs e)
	{
		checked {
			sldY.Value = 100 * (int)Math.Round ((double)sldY.Value / 100.0);
			ref BuckleParameters buckleParametersTmp = ref BuckleParametersTmp;
			buckleParametersTmp.Fby = (float)((double)sldY.Value / (double)sldY.Maximum);
			if (((double)Math.Abs (buckleParametersTmp.Fc) < 0.01) | (Math.Abs (buckleParametersTmp.Fbx) + Math.Abs (buckleParametersTmp.Fby) > 1f)) {
				buckleParametersTmp.Fbx = (float)Math.Sign (buckleParametersTmp.Fbx) * (1f - Math.Abs (buckleParametersTmp.Fby));
				sldX.Value = (int)Math.Round ((float)sldX.Maximum * buckleParametersTmp.Fbx);
			}
			buckleParametersTmp.Fc = 1f - Math.Abs (buckleParametersTmp.Fbx) - Math.Abs (buckleParametersTmp.Fby);
			if ((double)Math.Abs (buckleParametersTmp.Fc) < 1E-06) {
				buckleParametersTmp.Fc = 0f;
			}
			txtFbx.Text = Units.DisplayNone (buckleParametersTmp.Fbx, "", 0, 0);
			txtFby.Text = Units.DisplayNone (buckleParametersTmp.Fby, "", 0, 0);
			txtFc.Text = Units.DisplayNone (buckleParametersTmp.Fc, "", 0, 0);
			DrawDiagram ();
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		}
	}

	private void chkAdjust_CheckedChanged (object sender, EventArgs e)
	{
		BuckleParametersTmp.Constrained = chkConstrained.Checked;
		DrawDiagram ();
	}

	private void cmdBimoment_Click (object sender, EventArgs e)
	{
		checked {
			BuckleParametersTmp.Bimoment = (short)(unchecked(checked(BuckleParametersTmp.Bimoment + 2) % 3) - 1);
			cmdBimoment.Text = Conversions.ToString (Interaction.IIf (BuckleParametersTmp.Bimoment == 0, "", RuntimeHelpers.GetObjectValue (Interaction.IIf (BuckleParametersTmp.Bimoment > 0, "+", "–"))));
			if (BuckleParametersTmp.Bimoment == 0) {
				cmdBimoment.Text = "";
				sldX.Enabled = true;
				sldY.Enabled = true;
				txtFbx.Enabled = true;
				txtFby.Enabled = true;
				txtFc.Enabled = true;
			} else {
				cmdBimoment.Text = Conversions.ToString (Interaction.IIf (BuckleParametersTmp.Bimoment > 0, "+", "–"));
				sldX.Enabled = false;
				sldY.Enabled = false;
				txtFbx.Enabled = false;
				txtFby.Enabled = false;
				txtFc.Enabled = false;
			}
			DrawDiagram ();
		}
	}
}
