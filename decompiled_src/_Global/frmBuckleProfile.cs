// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmBuckleProfile : Form
{
	private IContainer components;

	private short intLengthNow;

	private short intLengthGross;

	private bool blnProfile;

	private bool blnBuckleValue;

	private GraphicsX ProfileGraphics;

	private short intRotation;

	private short intSign;

	internal virtual PictureBox picProfile {
		[CompilerGenerated]
		get {
			return _picProfile;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = picProfile_PreviewKeyDown;
			MouseEventHandler value3 = picProfile_MouseDown;
			EventHandler value4 = picProfile_DoubleClick;
			PictureBox pictureBox = _picProfile;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown -= value2;
				pictureBox.MouseDown -= value3;
				pictureBox.DoubleClick -= value4;
			}
			_picProfile = value;
			pictureBox = _picProfile;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown += value2;
				pictureBox.MouseDown += value3;
				pictureBox.DoubleClick += value4;
			}
		}
	}

	internal virtual Button cmdModeShape {
		[CompilerGenerated]
		get {
			return _cmdModeShape;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdModeShape_Click;
			Button button = _cmdModeShape;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdModeShape = value;
			button = _cmdModeShape;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdBuckleValue {
		[CompilerGenerated]
		get {
			return _cmdBuckleValue;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdBuckleValue_Click;
			Button button = _cmdBuckleValue;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdBuckleValue = value;
			button = _cmdBuckleValue;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdCopyData {
		[CompilerGenerated]
		get {
			return _cmdCopyData;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdCopyData_Click;
			Button button = _cmdCopyData;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdCopyData = value;
			button = _cmdCopyData;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdPrint {
		[CompilerGenerated]
		get {
			return _cmdPrint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdPrint_Click;
			Button button = _cmdPrint;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdPrint = value;
			button = _cmdPrint;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdClose {
		[CompilerGenerated]
		get {
			return _cmdClose;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdClose_Click;
			Button button = _cmdClose;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdClose = value;
			button = _cmdClose;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("picDot")]
	internal virtual PictureBox picDot {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TrackBar sldAmplitude {
		[CompilerGenerated]
		get {
			return _sldAmplitude;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = sldAmplitude_ValueChanged;
			TrackBar trackBar = _sldAmplitude;
			if (trackBar != null) {
				trackBar.ValueChanged -= value2;
			}
			_sldAmplitude = value;
			trackBar = _sldAmplitude;
			if (trackBar != null) {
				trackBar.ValueChanged += value2;
			}
		}
	}

	internal virtual HScrollBar hsbLength {
		[CompilerGenerated]
		get {
			return _hsbLength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = hsbLength_ValueChanged;
			HScrollBar hScrollBar = _hsbLength;
			if (hScrollBar != null) {
				hScrollBar.ValueChanged -= value2;
			}
			_hsbLength = value;
			hScrollBar = _hsbLength;
			if (hScrollBar != null) {
				hScrollBar.ValueChanged += value2;
			}
		}
	}

	internal virtual CheckBox chkRender {
		[CompilerGenerated]
		get {
			return _chkRender;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = chkRender_Click;
			CheckBox checkBox = _chkRender;
			if (checkBox != null) {
				checkBox.PreviewKeyDown -= value2;
				checkBox.Click -= value3;
			}
			_chkRender = value;
			checkBox = _chkRender;
			if (checkBox != null) {
				checkBox.PreviewKeyDown += value2;
				checkBox.Click += value3;
			}
		}
	}

	internal virtual Button cmdCCW {
		[CompilerGenerated]
		get {
			return _cmdCCW;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdCCW_Click;
			Button button = _cmdCCW;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdCCW = value;
			button = _cmdCCW;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdCW {
		[CompilerGenerated]
		get {
			return _cmdCW;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = cmd_PreviewKeyDown;
			EventHandler value3 = cmdCW_Click;
			Button button = _cmdCW;
			if (button != null) {
				button.PreviewKeyDown -= value2;
				button.Click -= value3;
			}
			_cmdCW = value;
			button = _cmdCW;
			if (button != null) {
				button.PreviewKeyDown += value2;
				button.Click += value3;
			}
		}
	}

	internal virtual Button cmdCopyImage {
		[CompilerGenerated]
		get {
			return _cmdCopyImage;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCopyImage_Click;
			Button button = _cmdCopyImage;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCopyImage = value;
			button = _cmdCopyImage;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdSign {
		[CompilerGenerated]
		get {
			return _cmdSign;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdSign_Click;
			Button button = _cmdSign;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdSign = value;
			button = _cmdSign;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmBuckleProfile ()
	{
		base.Load += frmBuckleProfile_Load;
		base.PreviewKeyDown += frmBuckleProfile_PreviewKeyDown;
		base.KeyDown += frmBuckleProfile_KeyDown;
		base.HelpButtonClicked += frmBuckleProfile_HelpButtonClicked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmBuckleProfile));
		this.cmdModeShape = new System.Windows.Forms.Button ();
		this.cmdBuckleValue = new System.Windows.Forms.Button ();
		this.cmdCopyData = new System.Windows.Forms.Button ();
		this.cmdPrint = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.sldAmplitude = new System.Windows.Forms.TrackBar ();
		this.hsbLength = new System.Windows.Forms.HScrollBar ();
		this.chkRender = new System.Windows.Forms.CheckBox ();
		this.picDot = new System.Windows.Forms.PictureBox ();
		this.picProfile = new System.Windows.Forms.PictureBox ();
		this.cmdCCW = new System.Windows.Forms.Button ();
		this.cmdCW = new System.Windows.Forms.Button ();
		this.cmdCopyImage = new System.Windows.Forms.Button ();
		this.cmdSign = new System.Windows.Forms.Button ();
		((System.ComponentModel.ISupportInitialize)this.sldAmplitude).BeginInit ();
		((System.ComponentModel.ISupportInitialize)this.picDot).BeginInit ();
		((System.ComponentModel.ISupportInitialize)this.picProfile).BeginInit ();
		base.SuspendLayout ();
		this.cmdModeShape.Location = new System.Drawing.Point (10, 400);
		this.cmdModeShape.Name = "cmdModeShape";
		this.cmdModeShape.Size = new System.Drawing.Size (90, 25);
		this.cmdModeShape.TabIndex = 1;
		this.cmdModeShape.Text = "Mode &Shape";
		this.cmdModeShape.UseVisualStyleBackColor = true;
		this.cmdBuckleValue.Location = new System.Drawing.Point (106, 400);
		this.cmdBuckleValue.Name = "cmdBuckleValue";
		this.cmdBuckleValue.Size = new System.Drawing.Size (90, 25);
		this.cmdBuckleValue.TabIndex = 2;
		this.cmdBuckleValue.Text = "&Direct Strength";
		this.cmdBuckleValue.UseVisualStyleBackColor = true;
		this.cmdCopyData.Location = new System.Drawing.Point (202, 400);
		this.cmdCopyData.Name = "cmdCopyData";
		this.cmdCopyData.Size = new System.Drawing.Size (75, 25);
		this.cmdCopyData.TabIndex = 3;
		this.cmdCopyData.Text = "Copy Data";
		this.cmdCopyData.UseVisualStyleBackColor = true;
		this.cmdPrint.Location = new System.Drawing.Point (364, 400);
		this.cmdPrint.Name = "cmdPrint";
		this.cmdPrint.Size = new System.Drawing.Size (75, 25);
		this.cmdPrint.TabIndex = 5;
		this.cmdPrint.Text = "&Print";
		this.cmdPrint.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (445, 400);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (75, 25);
		this.cmdClose.TabIndex = 6;
		this.cmdClose.Text = "&Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.sldAmplitude.BackColor = System.Drawing.SystemColors.Window;
		this.sldAmplitude.LargeChange = 1;
		this.sldAmplitude.Location = new System.Drawing.Point (482, 290);
		this.sldAmplitude.Maximum = 8;
		this.sldAmplitude.Name = "sldAmplitude";
		this.sldAmplitude.Orientation = System.Windows.Forms.Orientation.Vertical;
		this.sldAmplitude.Size = new System.Drawing.Size (45, 77);
		this.sldAmplitude.TabIndex = 12;
		this.sldAmplitude.TickStyle = System.Windows.Forms.TickStyle.Both;
		this.sldAmplitude.Value = 4;
		this.sldAmplitude.Visible = false;
		this.hsbLength.LargeChange = 4;
		this.hsbLength.Location = new System.Drawing.Point (9, 361);
		this.hsbLength.Minimum = 1;
		this.hsbLength.Name = "hsbLength";
		this.hsbLength.Size = new System.Drawing.Size (90, 22);
		this.hsbLength.TabIndex = 8;
		this.hsbLength.Value = 1;
		this.hsbLength.Visible = false;
		this.chkRender.AutoSize = true;
		this.chkRender.BackColor = System.Drawing.SystemColors.Window;
		this.chkRender.Location = new System.Drawing.Point (12, 341);
		this.chkRender.Name = "chkRender";
		this.chkRender.Size = new System.Drawing.Size (61, 17);
		this.chkRender.TabIndex = 7;
		this.chkRender.Text = "&Render";
		this.chkRender.UseVisualStyleBackColor = false;
		this.chkRender.Visible = false;
		this.picDot.BackColor = System.Drawing.SystemColors.Window;
		this.picDot.Image = (System.Drawing.Image)resources.GetObject ("picDot.Image");
		this.picDot.Location = new System.Drawing.Point (214, 161);
		this.picDot.Name = "picDot";
		this.picDot.Size = new System.Drawing.Size (8, 8);
		this.picDot.TabIndex = 6;
		this.picDot.TabStop = false;
		this.picProfile.BackColor = System.Drawing.SystemColors.Window;
		this.picProfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picProfile.Location = new System.Drawing.Point (0, 0);
		this.picProfile.Name = "picProfile";
		this.picProfile.Size = new System.Drawing.Size (529, 389);
		this.picProfile.TabIndex = 0;
		this.picProfile.TabStop = false;
		this.cmdCCW.Font = new System.Drawing.Font ("Wingdings 3", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 2);
		this.cmdCCW.Location = new System.Drawing.Point (462, 361);
		this.cmdCCW.Name = "cmdCCW";
		this.cmdCCW.Size = new System.Drawing.Size (24, 24);
		this.cmdCCW.TabIndex = 10;
		this.cmdCCW.Text = "Q";
		this.cmdCCW.UseVisualStyleBackColor = true;
		this.cmdCCW.Visible = false;
		this.cmdCW.Font = new System.Drawing.Font ("Wingdings 3", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 2);
		this.cmdCW.Location = new System.Drawing.Point (439, 361);
		this.cmdCW.Name = "cmdCW";
		this.cmdCW.Size = new System.Drawing.Size (24, 24);
		this.cmdCW.TabIndex = 9;
		this.cmdCW.Text = "P";
		this.cmdCW.UseVisualStyleBackColor = true;
		this.cmdCW.Visible = false;
		this.cmdCopyImage.Location = new System.Drawing.Point (283, 400);
		this.cmdCopyImage.Name = "cmdCopyImage";
		this.cmdCopyImage.Size = new System.Drawing.Size (75, 25);
		this.cmdCopyImage.TabIndex = 4;
		this.cmdCopyImage.Text = "Copy Image";
		this.cmdCopyImage.UseVisualStyleBackColor = true;
		this.cmdSign.Font = new System.Drawing.Font ("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdSign.Location = new System.Drawing.Point (491, 361);
		this.cmdSign.Name = "cmdSign";
		this.cmdSign.Size = new System.Drawing.Size (24, 24);
		this.cmdSign.TabIndex = 11;
		this.cmdSign.Text = "±";
		this.cmdSign.UseVisualStyleBackColor = true;
		this.cmdSign.Visible = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (530, 436);
		base.Controls.Add (this.cmdSign);
		base.Controls.Add (this.cmdCopyImage);
		base.Controls.Add (this.cmdCW);
		base.Controls.Add (this.cmdCCW);
		base.Controls.Add (this.chkRender);
		base.Controls.Add (this.hsbLength);
		base.Controls.Add (this.sldAmplitude);
		base.Controls.Add (this.picDot);
		base.Controls.Add (this.cmdClose);
		base.Controls.Add (this.cmdPrint);
		base.Controls.Add (this.cmdCopyData);
		base.Controls.Add (this.cmdBuckleValue);
		base.Controls.Add (this.cmdModeShape);
		base.Controls.Add (this.picProfile);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBuckleProfile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Elastic Buckling Profile";
		((System.ComponentModel.ISupportInitialize)this.sldAmplitude).EndInit ();
		((System.ComponentModel.ISupportInitialize)this.picDot).EndInit ();
		((System.ComponentModel.ISupportInitialize)this.picProfile).EndInit ();
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmBuckleProfile_Load (object sender, EventArgs e)
	{
		Text = "Elastic Buckling: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		intLengthNow = 1;
		intLengthGross = 1;
		float lF = FiniteStrip.Buckle [1].LF;
		checked {
			short num = (short)Information.UBound (FiniteStrip.Buckle);
			for (short num2 = 2; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (FiniteStrip.Buckle [num2].HoleMode == FiniteStrip.HoleMode.Gross) {
					intLengthGross = num2;
				}
				if (((intLengthNow == 1) & (FiniteStrip.Buckle [num2].HoleMode == FiniteStrip.HoleMode.Gross) & (num2 < Information.UBound (FiniteStrip.Buckle))) && ((FiniteStrip.Buckle [num2].LF < FiniteStrip.Buckle [num2 - 1].LF) & (FiniteStrip.Buckle [num2].LF <= FiniteStrip.Buckle [num2 + 1].LF))) {
					intLengthNow = num2;
				}
				if (FiniteStrip.Buckle [num2].LF < lF) {
					lF = FiniteStrip.Buckle [num2].LF;
				}
			}
			intSign = 1;
			ProfileGraphics = new GraphicsX (picProfile);
			FiniteStrip.PlotProfile (ProfileGraphics);
			PlotDot ();
			FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
			blnProfile = true;
			cmdModeShape.Text = "Mode &Shape";
			base.CancelButton = cmdClose;
			blnBuckleValue = (CFSInterface.BuckleParametersNow.Fc == 1f) | (Math.Abs (CFSInterface.BuckleParametersNow.Fbx) == 1f) | (Math.Abs (CFSInterface.BuckleParametersNow.Fby) == 1f);
			cmdBuckleValue.Enabled = blnBuckleValue;
			hsbLength.Maximum = Information.UBound (FiniteStrip.Buckle) + hsbLength.LargeChange;
			if ((lF <= 0f) & !CFSInterface.BuckleParametersNow.AltMethod) {
				Interaction.MsgBox ("Some results are not valid. The Alternate Method may provide better results.", MsgBoxStyle.Exclamation);
			}
		}
	}

	private void frmBuckleProfile_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		if ((e.KeyCode == Keys.Left) | (e.KeyCode == Keys.Right) | (e.KeyCode == Keys.Return)) {
			e.IsInputKey = true;
		}
	}

	private void picProfile_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		if ((e.KeyCode == Keys.Left) | (e.KeyCode == Keys.Right) | (e.KeyCode == Keys.Return)) {
			e.IsInputKey = true;
		}
		if ((e.KeyCode == Keys.Up) | (e.KeyCode == Keys.Down)) {
			e.IsInputKey = true;
		}
	}

	private void cmd_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		if ((e.KeyCode == Keys.Left) | (e.KeyCode == Keys.Right)) {
			e.IsInputKey = true;
		}
		if ((e.KeyCode == Keys.Up) | (e.KeyCode == Keys.Down)) {
			e.IsInputKey = true;
		}
	}

	private void frmBuckleProfile_KeyDown (object sender, KeyEventArgs e)
	{
		short num = 0;
		checked {
			if (e.Shift) {
				num = (short)unchecked(num + 1);
			}
			if (e.Control) {
				num = (short)unchecked(num + 2);
			}
			if (e.Alt) {
				num = (short)unchecked(num + 4);
			}
			if (e.KeyCode == Keys.F1) {
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-results.htm");
				e.Handled = true;
			} else if (e.KeyCode == Keys.Return) {
				cmdModeShape_Click (RuntimeHelpers.GetObjectValue (sender), null);
				e.Handled = true;
			} else if (blnProfile) {
				if (unchecked(e.KeyCode == Keys.Left && num == 0)) {
					if (intLengthNow > 1 && FiniteStrip.Buckle [intLengthNow - 1].LF > 0f) {
						intLengthNow--;
						PlotDot ();
						FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
					}
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Left && num == 2)) {
					short num2 = (short)(intLengthNow - 1);
					while (num2 >= 1 && FiniteStrip.Buckle [num2].ModeShape <= 0) {
						num2 = (short)unchecked(num2 + -1);
					}
					if (num2 >= 1) {
						intLengthNow = num2;
					}
					PlotDot ();
					FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Right && num == 0)) {
					if (intLengthNow < Information.UBound (FiniteStrip.Buckle) && FiniteStrip.Buckle [intLengthNow + 1].LF > 0f) {
						intLengthNow++;
						PlotDot ();
						FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
					}
					e.Handled = true;
				} else if (unchecked(e.KeyCode == Keys.Right && num == 2)) {
					short num3 = (short)(intLengthNow + 1);
					short num4 = (short)Information.UBound (FiniteStrip.Buckle);
					short num2 = num3;
					while (num2 <= num4 && FiniteStrip.Buckle [num2].ModeShape <= 0) {
						num2 = (short)unchecked(num2 + 1);
					}
					if (num2 <= Information.UBound (FiniteStrip.Buckle)) {
						intLengthNow = num2;
					}
					PlotDot ();
					FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
					e.Handled = true;
				}
			} else if (e.KeyCode == Keys.Left) {
				if (hsbLength.Value > hsbLength.Minimum) {
					hsbLength.Value--;
				}
				e.Handled = true;
			} else if (e.KeyCode == Keys.Right) {
				if (hsbLength.Value < hsbLength.Maximum) {
					hsbLength.Value++;
				}
				e.Handled = true;
			} else if (e.KeyCode == Keys.Up) {
				if (sldAmplitude.Value < sldAmplitude.Maximum) {
					sldAmplitude.Value++;
				}
				e.Handled = true;
			} else if (e.KeyCode == Keys.Down) {
				if (sldAmplitude.Value > sldAmplitude.Minimum) {
					sldAmplitude.Value--;
				}
				e.Handled = true;
			} else if (e.KeyCode == Keys.Prior) {
				intRotation = (short)unchecked(checked(intRotation + 1) % 12);
				FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
				e.Handled = true;
			} else if (e.KeyCode == Keys.Next) {
				intRotation = (short)unchecked(checked(intRotation + 11) % 12);
				FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
				e.Handled = true;
			} else if ((e.KeyCode == Keys.Home) | (e.KeyCode == Keys.Escape)) {
				intRotation = 0;
				intSign = 1;
				FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
				e.Handled = true;
			} else if ((e.KeyCode == Keys.Add) | (e.KeyCode == Keys.Subtract)) {
				intSign = (short)unchecked(-intSign);
				FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
				e.Handled = true;
			}
		}
	}

	private void frmBuckleProfile_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "buckling-results.htm");
		e.Cancel = true;
	}

	private void picProfile_MouseDown (object sender, MouseEventArgs e)
	{
		PointF[] array = new PointF[1] {
			new PointF (e.X, e.Y)
		};
		ProfileGraphics.Graphics.TransformPoints (CoordinateSpace.World, CoordinateSpace.Device, array);
		float num = array [0].X;
		float num2 = array [0].Y;
		if (!blnProfile) {
			return;
		}
		float num3 = Math.Abs (num - GraphicsX.Transform (Units.ConvertValue (FiniteStrip.Buckle [intLengthNow].Length, Units.UnitTypes.LengthUnit, 0), 3));
		float num4 = Math.Abs (num2 - Units.ConvertValue (FiniteStrip.Buckle [intLengthNow].LF, Units.UnitTypes.StressUnit, 0));
		checked {
			short num5 = (short)Information.UBound (FiniteStrip.Buckle);
			for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
				if (FiniteStrip.Buckle [num6].LF > 0f) {
					float num7 = Math.Abs (num - GraphicsX.Transform (Units.ConvertValue (FiniteStrip.Buckle [num6].Length, Units.UnitTypes.LengthUnit, 0), 3));
					float num8 = Math.Abs (num2 - Units.ConvertValue (FiniteStrip.Buckle [num6].LF, Units.UnitTypes.StressUnit, 0));
					if (unchecked(num7 < num3 || (num7 == num3 && num8 < num4))) {
						intLengthNow = num6;
						num3 = num7;
						num4 = num8;
					}
				}
			}
			PlotDot ();
			FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
		}
	}

	private void picProfile_DoubleClick (object sender, EventArgs e)
	{
		if (cmdModeShape.Enabled) {
			cmdModeShape_Click (RuntimeHelpers.GetObjectValue (sender), null);
		}
	}

	private void PlotDot ()
	{
		PointF[] array = new PointF[1] {
			new PointF (GraphicsX.Transform (Units.ConvertValue (FiniteStrip.Buckle [intLengthNow].Length, Units.UnitTypes.LengthUnit, 0), 3), Units.ConvertValue (FiniteStrip.Buckle [intLengthNow].LF, Units.UnitTypes.StressUnit, 0))
		};
		ProfileGraphics.Graphics.TransformPoints (CoordinateSpace.Device, CoordinateSpace.World, array);
		picDot.Visible = false;
		checked {
			picDot.Left = (int)Math.Round ((double)picProfile.Left + (double)(picProfile.Width - picProfile.ClientSize.Width) / 2.0 + (double)array [0].X - (double)picDot.Size.Width / 2.0);
			picDot.Top = (int)Math.Round ((double)picProfile.Top + (double)(picProfile.Height - picProfile.ClientSize.Height) / 2.0 + (double)array [0].Y - (double)picDot.Size.Height / 2.0);
			picDot.Visible = true;
		}
	}

	private void cmdModeShape_Click (object sender, EventArgs e)
	{
		checked {
			if (blnProfile) {
				int num = Information.UBound (FiniteStrip.Buckle);
				int num2 = 0;
				while (true) {
					if (num2 <= num) {
						if (intLengthNow + num2 <= Information.UBound (FiniteStrip.Buckle) && FiniteStrip.Buckle [intLengthNow + num2].ModeShape > 0) {
							ref short reference = ref intLengthNow;
							reference = (short)(reference + num2);
						} else {
							if (intLengthNow - num2 < 1 || FiniteStrip.Buckle [intLengthNow - num2].ModeShape <= 0) {
								if (!((intLengthNow - num2 < 1) & (intLengthNow + num2 > Information.UBound (FiniteStrip.Buckle)))) {
									num2++;
									continue;
								}
								break;
							}
							ref short reference2 = ref intLengthNow;
							reference2 = (short)(reference2 - num2);
						}
					}
					picDot.Visible = false;
					FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
					cmdModeShape.Text = "&Stress Profile";
					cmdCopyData.Enabled = false;
					chkRender.Visible = true;
					hsbLength.Visible = true;
					cmdCCW.Visible = true;
					cmdCW.Visible = true;
					cmdCCW.Enabled = chkRender.Checked;
					cmdCW.Enabled = chkRender.Checked;
					cmdSign.Visible = true;
					sldAmplitude.Visible = true;
					hsbLength.Value = intLengthNow;
					blnProfile = false;
					break;
				}
			} else {
				chkRender.Visible = false;
				hsbLength.Visible = false;
				cmdCCW.Visible = false;
				cmdCW.Visible = false;
				cmdSign.Visible = false;
				sldAmplitude.Visible = false;
				FiniteStrip.PlotProfile (ProfileGraphics);
				PlotDot ();
				FiniteStrip.PlotLabels (ProfileGraphics, intLengthNow);
				cmdModeShape.Text = "Mode &Shape";
				cmdCopyData.Enabled = true;
				blnProfile = true;
			}
		}
	}

	private void cmdBuckleValue_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmBuckleValue.Tag = Conversions.ToString ((int)intLengthNow);
		My.MyProject.Forms.frmBuckleValue.ShowDialog (this);
		My.MyProject.Forms.frmBuckleValue.Dispose ();
	}

	private void cmdCopyData_Click (object sender, EventArgs e)
	{
		string text = "L (" + Units.DisplayUnit (2, 0) + ")\t";
		text = text + "f (" + Units.DisplayUnit (5, 0) + ")\t";
		text = text + "P (" + Units.DisplayUnit (4, 0) + ")\t";
		text = text + "Mx (" + Units.DisplayUnit (6, 0) + ")\t";
		text = text + "My (" + Units.DisplayUnit (6, 0) + ")\t";
		text += "Section\t";
		text += "Work Ratio\t";
		text += "Mode\r\n";
		checked {
			short num = (short)Information.UBound (FiniteStrip.Buckle);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				ref FiniteStrip.BuckleState reference = ref FiniteStrip.Buckle [num2];
				text = text + Conversions.ToString (Units.ConvertValue (reference.Length, Units.UnitTypes.LengthUnit, 0)) + "\t";
				text = text + Conversions.ToString (Units.ConvertValue (reference.LF, Units.UnitTypes.StressUnit, 0)) + "\t";
				text = text + Conversions.ToString (Units.ConvertValue (reference.P, Units.UnitTypes.ForceUnit, 0)) + "\t";
				text = text + Conversions.ToString (Units.ConvertValue (reference.Mx, Units.UnitTypes.MomentUnit, 0)) + "\t";
				text = text + Conversions.ToString (Units.ConvertValue (reference.My, Units.UnitTypes.MomentUnit, 0)) + "\t";
				string text2;
				string text3;
				if (reference.HoleMode == FiniteStrip.HoleMode.Gross) {
					text2 = "Gross";
					text3 = "Global";
					if (FiniteStrip.IsDistortionalBuckling (reference.WorkRatio)) {
						text3 = "Distortional";
					}
					if (FiniteStrip.IsLocalBuckling (reference.WorkRatio)) {
						text3 = "Local";
					}
				} else {
					text2 = "Net";
					text3 = Conversions.ToString (Interaction.IIf (reference.HoleMode == FiniteStrip.HoleMode.Local, "Local", "Distortional"));
				}
				text = text + text2 + "\t";
				text = text + Conversions.ToString (reference.WorkRatio) + "\t";
				text = text + text3 + "\r\n";
			}
			Clipboard.Clear ();
			Clipboard.SetText (text);
			My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste";
			My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			CFSInterface.bytClipBoard = 0;
			CFSInterface.strClipBoard = string.Empty;
			CFSInterface.SetMenuEdit ();
			Interaction.MsgBox ("Elastic buckling data has been copied to the clipboard.", MsgBoxStyle.Information);
		}
	}

	private void cmdCopyImage_Click (object sender, EventArgs e)
	{
		DataObject dataObject = new DataObject ();
		dataObject.SetData (DataFormats.Bitmap, picProfile.Image);
		Clipboard.Clear ();
		Clipboard.SetDataObject (dataObject);
		My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste";
		My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
		My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
		CFSInterface.bytClipBoard = 11;
		CFSInterface.strClipBoard = string.Empty;
		CFSInterface.SetMenuEdit ();
		Interaction.MsgBox ("Display image has been copied to the clipboard.", MsgBoxStyle.Information);
	}

	private void cmdPrint_Click (object sender, EventArgs e)
	{
		PrintRoutines.PrintBuckling ();
		blnProfile = false;
		cmdModeShape_Click (RuntimeHelpers.GetObjectValue (sender), null);
	}

	private void cmdClose_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private void sldAmplitude_ValueChanged (object sender, EventArgs e)
	{
		FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)checked(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
	}

	private void chkRender_Click (object sender, EventArgs e)
	{
		cmdCCW.Enabled = chkRender.Checked;
		cmdCW.Enabled = chkRender.Checked;
		FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)checked(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
	}

	private void hsbLength_ValueChanged (object sender, EventArgs e)
	{
		if (hsbLength.Value == intLengthNow) {
			return;
		}
		checked {
			if (hsbLength.Value > intLengthNow) {
				int num = intLengthNow + 1;
				int num2 = Information.UBound (FiniteStrip.Buckle);
				int i;
				for (i = num; i <= num2; i++) {
					if (FiniteStrip.Buckle [i].ModeShape > 0) {
						intLengthNow = (short)i;
						break;
					}
				}
				if (i > Information.UBound (FiniteStrip.Buckle)) {
					hsbLength.Value = intLengthNow;
					return;
				}
			} else if (hsbLength.Value < intLengthNow) {
				int i;
				for (i = intLengthNow - 1; i >= 1; i += -1) {
					if (FiniteStrip.Buckle [i].ModeShape > 0) {
						intLengthNow = (short)i;
						break;
					}
				}
				if (i < 1) {
					hsbLength.Value = intLengthNow;
					return;
				}
			}
			FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
			hsbLength.Value = intLengthNow;
		}
	}

	private void cmdCCW_Click (object sender, EventArgs e)
	{
		checked {
			intRotation = (short)unchecked(checked(intRotation + 1) % 12);
			FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
		}
	}

	private void cmdCW_Click (object sender, EventArgs e)
	{
		checked {
			intRotation = (short)unchecked(checked(intRotation + 11) % 12);
			FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
		}
	}

	private void cmdSign_Click (object sender, EventArgs e)
	{
		checked {
			intSign = (short)unchecked(-intSign);
			FiniteStrip.PlotModeShape (ProfileGraphics, intLengthNow, (float)((double)(intSign * 2 * sldAmplitude.Value) / (double)sldAmplitude.Maximum), chkRender.Checked, intRotation);
		}
	}
}
