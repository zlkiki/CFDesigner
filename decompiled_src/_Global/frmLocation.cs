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
public class frmLocation : Form
{
	private IContainer components;

	private float sngLocation;

	private short nChk;

	private short[] Cchk;

	private float[] Zchk;

	private short[] Schk;

	private WebCripParameters[] ParamChk;

	[field: AccessedThroughProperty ("lblLocation")]
	internal virtual Label lblLocation {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLocation {
		[CompilerGenerated]
		get {
			return _cboLocation;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboLocation_GotFocus;
			KeyPressEventHandler value3 = cboLocation_KeyPress;
			EventHandler value4 = cboLocation_TextChanged;
			EventHandler value5 = cboLocation_DropDown;
			EventHandler value6 = cboLocation_SelectedIndexChanged;
			CancelEventHandler value7 = cboLocation_Validating;
			ComboBox comboBox = _cboLocation;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLocation = value;
			comboBox = _cboLocation;
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

	internal virtual Button cmdAdd {
		[CompilerGenerated]
		get {
			return _cmdAdd;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdAdd_Click;
			Button button = _cmdAdd;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdAdd = value;
			button = _cmdAdd;
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

	internal virtual Button cmdCheckAll {
		[CompilerGenerated]
		get {
			return _cmdCheckAll;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCheckAll_Click;
			Button button = _cmdCheckAll;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCheckAll = value;
			button = _cmdCheckAll;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lstLocation")]
	internal virtual CheckedListBox lstLocation {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual RadioButton optLocOpt0 {
		[CompilerGenerated]
		get {
			return _optLocOpt0;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optLocOpt_CheckedChanged;
			RadioButton radioButton = _optLocOpt0;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optLocOpt0 = value;
			radioButton = _optLocOpt0;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton optLocOpt1 {
		[CompilerGenerated]
		get {
			return _optLocOpt1;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optLocOpt_CheckedChanged;
			RadioButton radioButton = _optLocOpt1;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optLocOpt1 = value;
			radioButton = _optLocOpt1;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton optLocOpt2 {
		[CompilerGenerated]
		get {
			return _optLocOpt2;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optLocOpt_CheckedChanged;
			RadioButton radioButton = _optLocOpt2;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optLocOpt2 = value;
			radioButton = _optLocOpt2;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton optLocOpt3 {
		[CompilerGenerated]
		get {
			return _optLocOpt3;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = optLocOpt_CheckedChanged;
			RadioButton radioButton = _optLocOpt3;
			if (radioButton != null) {
				radioButton.CheckedChanged -= value2;
			}
			_optLocOpt3 = value;
			radioButton = _optLocOpt3;
			if (radioButton != null) {
				radioButton.CheckedChanged += value2;
			}
		}
	}

	public frmLocation ()
	{
		base.Load += frmLocation_Load;
		base.KeyDown += frmLocation_KeyDown;
		base.HelpButtonClicked += frmLocation_HelpButtonClicked;
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
		this.lblLocation = new System.Windows.Forms.Label ();
		this.cboLocation = new System.Windows.Forms.ComboBox ();
		this.cmdAdd = new System.Windows.Forms.Button ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.cmdCheckAll = new System.Windows.Forms.Button ();
		this.lstLocation = new System.Windows.Forms.CheckedListBox ();
		this.optLocOpt0 = new System.Windows.Forms.RadioButton ();
		this.optLocOpt1 = new System.Windows.Forms.RadioButton ();
		this.optLocOpt2 = new System.Windows.Forms.RadioButton ();
		this.optLocOpt3 = new System.Windows.Forms.RadioButton ();
		base.SuspendLayout ();
		this.lblLocation.Location = new System.Drawing.Point (9, 14);
		this.lblLocation.Name = "lblLocation";
		this.lblLocation.Size = new System.Drawing.Size (299, 18);
		this.lblLocation.TabIndex = 0;
		this.lblLocation.Text = "Current Load Combination: ASD 4: 0.75*(D+L+R+W)";
		this.cboLocation.FormattingEnabled = true;
		this.cboLocation.Location = new System.Drawing.Point (12, 272);
		this.cboLocation.Name = "cboLocation";
		this.cboLocation.Size = new System.Drawing.Size (129, 21);
		this.cboLocation.TabIndex = 5;
		this.cmdAdd.Location = new System.Drawing.Point (147, 272);
		this.cmdAdd.Name = "cmdAdd";
		this.cmdAdd.Size = new System.Drawing.Size (75, 22);
		this.cmdAdd.TabIndex = 6;
		this.cmdAdd.Text = "Add";
		this.cmdAdd.UseVisualStyleBackColor = true;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (231, 127);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 7;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (231, 158);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 8;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.cmdCheckAll.Location = new System.Drawing.Point (231, 241);
		this.cmdCheckAll.Name = "cmdCheckAll";
		this.cmdCheckAll.Size = new System.Drawing.Size (75, 25);
		this.cmdCheckAll.TabIndex = 9;
		this.cmdCheckAll.Text = "Check &All";
		this.cmdCheckAll.UseVisualStyleBackColor = true;
		this.lstLocation.CheckOnClick = true;
		this.lstLocation.FormattingEnabled = true;
		this.lstLocation.Location = new System.Drawing.Point (12, 127);
		this.lstLocation.Name = "lstLocation";
		this.lstLocation.Size = new System.Drawing.Size (210, 139);
		this.lstLocation.TabIndex = 10;
		this.optLocOpt0.AutoSize = true;
		this.optLocOpt0.Location = new System.Drawing.Point (12, 35);
		this.optLocOpt0.Name = "optLocOpt0";
		this.optLocOpt0.Size = new System.Drawing.Size (284, 17);
		this.optLocOpt0.TabIndex = 14;
		this.optLocOpt0.TabStop = true;
		this.optLocOpt0.Tag = "0";
		this.optLocOpt0.Text = "Report controlling location among all load combinations";
		this.optLocOpt0.UseVisualStyleBackColor = true;
		this.optLocOpt1.AutoSize = true;
		this.optLocOpt1.Location = new System.Drawing.Point (12, 58);
		this.optLocOpt1.Name = "optLocOpt1";
		this.optLocOpt1.Size = new System.Drawing.Size (278, 17);
		this.optLocOpt1.TabIndex = 15;
		this.optLocOpt1.TabStop = true;
		this.optLocOpt1.Tag = "1";
		this.optLocOpt1.Text = "Report controlling location for EACH load combination";
		this.optLocOpt1.UseVisualStyleBackColor = true;
		this.optLocOpt2.AutoSize = true;
		this.optLocOpt2.Location = new System.Drawing.Point (12, 81);
		this.optLocOpt2.Name = "optLocOpt2";
		this.optLocOpt2.Size = new System.Drawing.Size (274, 17);
		this.optLocOpt2.TabIndex = 16;
		this.optLocOpt2.TabStop = true;
		this.optLocOpt2.Tag = "2";
		this.optLocOpt2.Text = "Report controlling location for THIS load combination";
		this.optLocOpt2.UseVisualStyleBackColor = true;
		this.optLocOpt3.AutoSize = true;
		this.optLocOpt3.Location = new System.Drawing.Point (12, 104);
		this.optLocOpt3.Name = "optLocOpt3";
		this.optLocOpt3.Size = new System.Drawing.Size (271, 17);
		this.optLocOpt3.TabIndex = 17;
		this.optLocOpt3.TabStop = true;
		this.optLocOpt3.Tag = "3";
		this.optLocOpt3.Text = "Report selected locations for THIS load combination";
		this.optLocOpt3.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (324, 304);
		base.Controls.Add (this.optLocOpt3);
		base.Controls.Add (this.optLocOpt2);
		base.Controls.Add (this.optLocOpt0);
		base.Controls.Add (this.lstLocation);
		base.Controls.Add (this.cmdCheckAll);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.cmdAdd);
		base.Controls.Add (this.cboLocation);
		base.Controls.Add (this.lblLocation);
		base.Controls.Add (this.optLocOpt1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLocation";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Locations to Check";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmLocation_Load (object sender, EventArgs e)
	{
		Zchk = new float[11];
		Schk = new short[11];
		if (Conversions.ToByte (base.Tag) == 1) {
			Text = "Member Check: " + CFSInterface.GetFileNameWithoutExtension (CFS.Analyses [CFS.intAnlNow].Filename);
			CFS.Analyses [CFS.intAnlNow].MemberCheckPoints (ref nChk, ref Zchk, ref Schk);
			cboLocation.Tag = new ControlData (2, CFS.Analyses [CFS.intAnlNow].Zmin, CFS.Analyses [CFS.intAnlNow].Zmax);
			CFS.blnValidate = false;
			CFSInterface.SetText (cboLocation, sngLocation);
			CFS.blnValidate = true;
		} else {
			Text = "Web Crippling: " + CFSInterface.GetFileNameWithoutExtension (CFS.Analyses [CFS.intAnlNow].Filename);
			ParamChk = new WebCripParameters[2];
			CFS.Analyses [CFS.intAnlNow].WebCripCheckPoints (ref nChk, ref Zchk, ref Schk, ref ParamChk);
			cboLocation.Visible = false;
			cmdAdd.Visible = false;
		}
		lblLocation.Text = "Load Combination: " + CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].Description;
		if (CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].Spec >= 0) {
			optLocOpt2.Enabled = true;
			optLocOpt3.Enabled = true;
		} else {
			optLocOpt2.Enabled = false;
			optLocOpt3.Enabled = false;
			if (CFSInterface.intLocOpt > 1) {
				CFSInterface.intLocOpt = 0;
			}
		}
		switch (CFSInterface.intLocOpt) {
		case 0:
			optLocOpt0.Checked = true;
			break;
		case 1:
			optLocOpt1.Checked = true;
			break;
		case 2:
			optLocOpt2.Checked = true;
			break;
		case 3:
			optLocOpt3.Checked = true;
			break;
		}
		lstLocation.Items.Clear ();
		short num = nChk;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				string text = Units.DisplayLength (Zchk [num2], 0, blnShowUnit: true, "", 0, 0);
				if (Schk [num2] == -1) {
					text = Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (CFS.Analyses [CFS.intAnlNow].Vertical, ", Upper Side", ", Left Side")));
				} else if (Schk [num2] == 1) {
					text = Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (CFS.Analyses [CFS.intAnlNow].Vertical, ", Lower Side", ", Right Side")));
				}
				bool isChecked = false;
				if (Conversions.ToByte (base.Tag) == 1) {
					if (CFSInterface.intAnlMemChk == CFS.intAnlNow) {
						short num3 = (short)Information.UBound (CFSInterface.ZMemChk);
						for (short num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
							if (((double)Math.Abs (CFSInterface.ZMemChk [num4] - Zchk [num2]) <= 0.001) & (CFSInterface.SMemChk [num4] == Schk [num2])) {
								isChecked = true;
								break;
							}
						}
					}
				} else {
					if (CFSInterface.intAnlWebCrip == CFS.intAnlNow) {
						short num5 = (short)Information.UBound (CFSInterface.ZWebCrip);
						for (short num4 = 1; num4 <= num5; num4 = (short)unchecked(num4 + 1)) {
							if (((double)Math.Abs (CFSInterface.ZWebCrip [num4] - Zchk [num2]) <= 0.001) & (CFSInterface.SWebCrip [num4] == Schk [num2])) {
								isChecked = true;
								break;
							}
						}
					}
					ref WebCripParameters reference = ref ParamChk [num2];
					text = ((reference.Dir != LoadDirections.dirY) ? Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (reference.P >= 0f, ", Left Flange", ", Right Flange"))) : Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (reference.P >= 0f, ", Bottom Flange", ", Top Flange"))));
				}
				lstLocation.Items.Add (text, isChecked);
			}
			sngLocation = 0f;
		}
	}

	private void frmLocation_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "locations.htm");
			e.Handled = true;
		}
	}

	private void frmLocation_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "locations.htm");
		e.Cancel = true;
	}

	private void optLocOpt_CheckedChanged (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (sender, null, "Checked", new object[0], null, null, null))) {
			CFSInterface.intLocOpt = checked((short)Math.Round (Conversion.Val (RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null)))));
		}
		lstLocation.Enabled = optLocOpt3.Checked;
		cboLocation.Enabled = optLocOpt3.Checked;
		cmdAdd.Enabled = optLocOpt3.Checked;
		cmdCheckAll.Enabled = optLocOpt3.Checked;
	}

	private void cmdCheckAll_Click (object sender, EventArgs e)
	{
		checked {
			if (Operators.CompareString (cmdCheckAll.Text, "Check &All", TextCompare: false) == 0) {
				cmdCheckAll.Text = "Uncheck &All";
				int num = lstLocation.Items.Count - 1;
				for (int i = 0; i <= num; i++) {
					lstLocation.SetItemChecked (i, value: true);
				}
			} else {
				cmdCheckAll.Text = "Check &All";
				int num2 = lstLocation.Items.Count - 1;
				for (int j = 0; j <= num2; j++) {
					lstLocation.SetItemChecked (j, value: false);
				}
			}
		}
	}

	private void cmdAdd_Click (object sender, EventArgs e)
	{
		short num = 1;
		short num2 = default(short);
		switch (CFS.Analyses [CFS.intAnlNow].CheckPointSides (sngLocation)) {
		case 0:
			num2 = 0;
			break;
		case 1:
			num2 = -1;
			break;
		case 2:
			num2 = 1;
			break;
		case 3:
			num2 = -1;
			num = 2;
			break;
		}
		short num3 = num;
		checked {
			for (num = 1; num <= num3; num = (short)unchecked(num + 1)) {
				if (num == 2) {
					num2 = 1;
				}
				short num4 = nChk;
				short num5;
				for (num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
					if ((sngLocation == Zchk [num5]) & (Schk [num5] == num2)) {
						lstLocation.SetItemChecked (num5 - 1, value: true);
						break;
					}
				}
				if (num5 > nChk) {
					nChk++;
					if (nChk > Information.UBound (Zchk)) {
						ref float[] zchk = ref Zchk;
						zchk = (float[])Utils.CopyArray (zchk, new float[nChk + 1]);
					}
					if (nChk > Information.UBound (Schk)) {
						ref short[] schk = ref Schk;
						schk = (short[])Utils.CopyArray (schk, new short[nChk + 1]);
					}
					Zchk [nChk] = sngLocation;
					Schk [nChk] = num2;
					string text = Units.DisplayLength (Zchk [nChk], Conversions.ToByte (NewLateBinding.LateGet (cboLocation.Tag, null, "Index", new object[0], null, null, null)), blnShowUnit: true, "", 0, 0);
					switch (num2) {
					case -1:
						text = Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (CFS.Analyses [CFS.intAnlNow].Vertical, ", Upper Side", ", Left Side")));
						break;
					case 1:
						text = Conversions.ToString (Operators.ConcatenateObject (text, Interaction.IIf (CFS.Analyses [CFS.intAnlNow].Vertical, ", Lower Side", ", Right Side")));
						break;
					}
					lstLocation.Items.Add (text, isChecked: true);
					lstLocation.SelectedIndex = lstLocation.Items.Count - 1;
				}
			}
			base.AcceptButton = cmdOK;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		MemberCheck Check = new MemberCheck (5);
		WebCripCheck Check2 = new WebCripCheck (3);
		checked {
			short num;
			if (CFSInterface.intLocOpt == 3) {
				num = 0;
				Cchk = new short[Information.UBound (this.Zchk) + 1];
				short num2 = (short)(lstLocation.Items.Count - 1);
				for (short num3 = 0; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
					Cchk [num3 + 1] = CFS.Analyses [CFS.intAnlNow].iComb;
					if (lstLocation.GetItemChecked (num3)) {
						num = (short)(num + 1);
					} else {
						this.Schk [num3 + 1] = 2;
					}
				}
				if (num == 0) {
					Interaction.MsgBox ("Select at least one location.", MsgBoxStyle.Information);
					return;
				}
			} else {
				num = 1;
			}
			if (CFS.intLicenseType == CFS.LicenseTypes.None) {
				if (CFS.Analyses [CFS.intAnlNow].nBeam > 1) {
					CFS.LicenseRequired ("This feature requires a full CFS license for analyses with multiple members.");
					return;
				}
				if (CFS.Analyses [CFS.intAnlNow].nSup > 3) {
					CFS.LicenseRequired ("This feature requires a full CFS license for analyses with more than 3 supports.");
					return;
				}
				if (CFS.Analyses [CFS.intAnlNow].Torsion & (Conversions.ToByte (base.Tag) == 1)) {
					CFS.LicenseRequired ("This feature requires a full CFS license for torsion analysis.");
					return;
				}
				strMsg = CFS.Sections [CFS.Analyses [CFS.intAnlNow].Beam [1].iSct].CheckBasicSection ();
				if (strMsg.Length > 0) {
					CFS.LicenseRequired (strMsg);
					return;
				}
			}
			Hide ();
			short iComb = default(short);
			if (CFSInterface.intLocOpt < 3) {
				Cursor.Current = Cursors.WaitCursor;
				Analysis analysis = CFS.Analyses [CFS.intAnlNow];
				float num4 = ((Math.Sign (analysis.Zmax) != Math.Sign (analysis.Zmin)) ? (analysis.Zmax - analysis.Zmin) : ((!(Math.Abs (analysis.Zmax) > Math.Abs (analysis.Zmin))) ? Math.Abs (analysis.Zmin) : Math.Abs (analysis.Zmax)));
				num4 = (float)((double)num4 * 1E-06);
				WebCripParameters[] Param = new WebCripParameters[unchecked((int)analysis.nBeam) + 1];
				iComb = analysis.iComb;
				float num5 = 0f;
				if (CFSInterface.intLocOpt == 1) {
					nChk = analysis.nComb;
				} else {
					nChk = 1;
				}
				Cchk = new short[nChk + 1];
				this.Zchk = new float[nChk + 1];
				this.Schk = new short[nChk + 1];
				ParamChk = new WebCripParameters[nChk + 1];
				float[] Zchk = new float[11];
				short[] Schk = new short[11];
				WebCripParameters[] Param2 = new WebCripParameters[11];
				short nComb = analysis.nComb;
				short num7 = default(short);
				short num12 = default(short);
				float num13 = default(float);
				short num14 = default(short);
				WebCripParameters webCripParameters = default(WebCripParameters);
				for (short num6 = 1; num6 <= nComb; num6 = (short)unchecked(num6 + 1)) {
					if (CFSInterface.intLocOpt == 1) {
						num5 = 0f;
						Cchk [num6] = num6;
						this.Schk [num6] = 2;
					}
					if (analysis.Comb [num6].Spec >= 0 && ((num6 == iComb) | (CFSInterface.intLocOpt <= 1))) {
						if (num6 != analysis.iComb) {
							analysis.iComb = (byte)num6;
							analysis.Analyze (ref strMsg);
							if (Strings.Len (strMsg) != 0) {
								strMsg = "Combination " + Conversions.ToString (unchecked((int)num6)) + ": " + analysis.Comb [num6].Description + "\r\n" + strMsg;
								Cursor.Current = Cursors.Default;
								Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
							}
							if (analysis.iCombSol == 0) {
								analysis.iComb = (byte)iComb;
								Cursor.Current = Cursors.Default;
								Close ();
								return;
							}
							if (analysis.Torsion) {
								analysis.AnalyzeTorsion (ref strMsg);
								if (Strings.Len (strMsg) != 0) {
									strMsg = "Combination " + Conversions.ToString (unchecked((int)num6)) + ": " + analysis.Comb [num6].Description + "\r\n" + strMsg;
									Cursor.Current = Cursors.Default;
									Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
									Close ();
									return;
								}
							}
						}
						if (Conversions.ToByte (base.Tag) == 1) {
							analysis.MemberCheckPoints (ref num7, ref Zchk, ref Schk);
							short num8 = num7;
							for (short num3 = 1; num3 <= num8; num3 = (short)unchecked(num3 + 1)) {
								float num9 = Zchk [num3] + (float)Schk [num3] * num4;
								MemberParameters[] array = analysis.MemberCheckParameters (num9);
								short nBeam = analysis.nBeam;
								for (short num10 = 1; num10 <= nBeam; num10 = (short)unchecked(num10 + 1)) {
									if ((analysis.Beam [num10].Z0 <= num9) & (analysis.Beam [num10].Z1 >= num9)) {
										CFS.Sections [analysis.Beam [num10].iSct].CalcStrength (unchecked((short)array [num10].Spec));
										CFS.Sections [analysis.Beam [num10].iSct].MemberCheck (array [num10], ref Check);
										float num11 = Check.Eq [1];
										if (Check.Eq [2] > num11) {
											num11 = Check.Eq [2];
										}
										if (Check.Eq [3] > num11) {
											num11 = Check.Eq [3];
										}
										if (Check.Eq [4] > num11) {
											num11 = Check.Eq [4];
										}
										if (Check.Eq [5] > num11) {
											num11 = Check.Eq [5];
										}
										if (num11 > num5) {
											num5 = num11;
											num12 = num6;
											num13 = Zchk [num3];
											num14 = Schk [num3];
										}
									}
								}
							}
						} else {
							analysis.WebCripCheckPoints (ref num7, ref Zchk, ref Schk, ref Param2);
							short num15 = num7;
							for (short num3 = 1; num3 <= num15; num3 = (short)unchecked(num3 + 1)) {
								Param [0] = Param2 [num3];
								float num9 = Zchk [num3] + (float)Schk [num3] * num4;
								analysis.WebCripCheckParameters (num9, ref Param);
								short nBeam2 = analysis.nBeam;
								for (short num10 = 1; num10 <= nBeam2; num10 = (short)unchecked(num10 + 1)) {
									if ((analysis.Beam [num10].Z0 <= num9) & (analysis.Beam [num10].Z1 >= num9)) {
										CFS.Sections [analysis.Beam [num10].iSct].CalcStrength (unchecked((short)Param [num10].Spec));
										CFS.Sections [analysis.Beam [num10].iSct].WebCripCheck (Param [num10], ref Check2);
										float num11 = Check2.Eq [1];
										if (Check2.Eq [2] > num11) {
											num11 = Check2.Eq [2];
										}
										if (Check2.Eq [3] > num11) {
											num11 = Check2.Eq [3];
										}
										if (num11 > num5) {
											num5 = num11;
											num12 = num6;
											num13 = Zchk [num3];
											num14 = Schk [num3];
											webCripParameters = Param2 [num3];
										}
									}
								}
							}
						}
						if (unchecked(CFSInterface.intLocOpt == 1 && num12 == num6)) {
							this.Zchk [num6] = num13;
							this.Schk [num6] = num14;
							ParamChk [num6] = webCripParameters;
						}
					}
				}
				if (unchecked(CFSInterface.intLocOpt != 1 && num12 > 0)) {
					Cchk [1] = num12;
					this.Zchk [1] = num13;
					this.Schk [1] = num14;
					ParamChk [1] = webCripParameters;
				}
				analysis = null;
				if (num12 == 0) {
					CFS.Analyses [CFS.intAnlNow].iComb = (byte)iComb;
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("No locations to check.", MsgBoxStyle.Information);
					Close ();
					return;
				}
				num = nChk;
				Cursor.Current = Cursors.Default;
			}
			if (Conversions.ToByte (base.Tag) == 1) {
				CFSInterface.ZMemChk = new float[num + 1];
				CFSInterface.SMemChk = new short[num + 1];
				short num16 = 0;
				short num17 = nChk;
				for (short num3 = 1; num3 <= num17; num3 = (short)unchecked(num3 + 1)) {
					if (this.Schk [num3] != 2) {
						num16 = (short)(num16 + 1);
						CFSInterface.ZMemChk [num16] = this.Zchk [num3];
						CFSInterface.SMemChk [num16] = this.Schk [num3];
					}
				}
				CFSInterface.intAnlMemChk = CFS.intAnlNow;
				Report.rptMemberCheckAnl (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow], ref nChk, ref Cchk, ref this.Zchk, ref this.Schk);
				My.MyProject.Forms.frmReportDialog.Tag = "2";
				My.MyProject.Forms.frmReportDialog.ShowDialog (My.MyProject.Forms.mdiCFS);
				My.MyProject.Forms.frmReportDialog.Dispose ();
			} else {
				CFSInterface.ZWebCrip = new float[num + 1];
				CFSInterface.SWebCrip = new short[num + 1];
				short num16 = 0;
				short num18 = nChk;
				for (short num3 = 1; num3 <= num18; num3 = (short)unchecked(num3 + 1)) {
					if (this.Schk [num3] != 2) {
						num16 = (short)(num16 + 1);
						CFSInterface.ZWebCrip [num16] = this.Zchk [num3];
						CFSInterface.SWebCrip [num16] = this.Schk [num3];
					}
				}
				CFSInterface.intAnlWebCrip = CFS.intAnlNow;
				Report.rptWebCripplingAnl (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow], ref nChk, ref Cchk, ref this.Zchk, ref this.Schk, ref ParamChk);
				My.MyProject.Forms.frmReportDialog.Tag = "2";
				My.MyProject.Forms.frmReportDialog.ShowDialog (My.MyProject.Forms.mdiCFS);
				My.MyProject.Forms.frmReportDialog.Dispose ();
			}
			if (CFSInterface.intLocOpt == 1) {
				CFS.Analyses [CFS.intAnlNow].iComb = (byte)iComb;
			}
			if (CFS.Analyses [CFS.intAnlNow].iComb != iComb) {
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
				CFSInterface.PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
				CFSInterface.SetMenuEdit ();
				CFSInterface.SetMenuCompute ();
			}
			Close ();
		}
	}

	private void cboLocation_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboLocation_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboLocation_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboLocation_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
			if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
				cmdAdd_Click (cmdAdd, null);
			}
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

	private void cboLocation_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboLocation_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void cboLocation_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboLocation_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			sngLocation = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}
}
