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
public class frmAngle : Form
{
	private IContainer components;

	private float sngAngle;

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
			EventHandler value2 = cboAngle_GotFocus;
			KeyPressEventHandler value3 = cboAngle_KeyPress;
			EventHandler value4 = cboAngle_TextChanged;
			EventHandler value5 = cboAngle_DropDown;
			EventHandler value6 = cboAngle_SelectedIndexChanged;
			CancelEventHandler value7 = cboAngle_Validating;
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

	public frmAngle ()
	{
		base.Load += frmAngle_Load;
		base.KeyDown += frmAngle_KeyDown;
		base.HelpButtonClicked += frmAngle_HelpButtonClicked;
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
		this.lblAngle = new System.Windows.Forms.Label ();
		this.cboAngle = new System.Windows.Forms.ComboBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.lblAngle.AutoSize = true;
		this.lblAngle.Location = new System.Drawing.Point (22, 24);
		this.lblAngle.Name = "lblAngle";
		this.lblAngle.Size = new System.Drawing.Size (76, 13);
		this.lblAngle.TabIndex = 0;
		this.lblAngle.Text = "Angle to rotate";
		this.cboAngle.FormattingEnabled = true;
		this.cboAngle.Location = new System.Drawing.Point (133, 21);
		this.cboAngle.Name = "cboAngle";
		this.cboAngle.Size = new System.Drawing.Size (146, 21);
		this.cboAngle.TabIndex = 1;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (66, 57);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 2;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (156, 57);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 3;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (296, 95);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.cboAngle);
		base.Controls.Add (this.lblAngle);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAngle";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Rotate";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmAngle_Load (object sender, EventArgs e)
	{
		cboAngle.Tag = new ControlData (3, -(float)Math.PI, (float)Math.PI * 2f);
		if ((((Strings.StrComp (Conversions.ToString (base.Tag), "RotatePart") == 0) & (CFS.Sections [CFS.intSctNow].nPart == 1)) | (Strings.StrComp (Conversions.ToString (base.Tag), "RotateSct") == 0)) & CFS.Sections [CFS.intSctNow].SctProp) {
			sngAngle = 0f - CFS.Sections [CFS.intSctNow].Prop.Alpha;
		} else {
			sngAngle = (float)Math.PI / 2f;
		}
		CFS.blnValidate = false;
		CFSInterface.SetText (cboAngle, sngAngle);
		CFS.blnValidate = true;
	}

	private void frmAngle_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "rotate-mirror.htm");
			e.Handled = true;
		}
	}

	private void frmAngle_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "rotate-mirror.htm");
		e.Cancel = true;
	}

	private void cboAngle_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void cboAngle_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			cboAngle_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			cboAngle_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
			if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
				cmdOK_Click (RuntimeHelpers.GetObjectValue (sender), new EventArgs ());
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

	private void cboAngle_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void cboAngle_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void cboAngle_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void cboAngle_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdOK;
			base.CancelButton = cmdCancel;
			sngAngle = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		Section section = CFS.Sections [CFS.intSctNow];
		object tag = base.Tag;
		checked {
			bool blnChg = default(bool);
			bool flag = default(bool);
			if (Conversions.ToBoolean (Conversions.ToBoolean (Operators.CompareObjectEqual (tag, "RotatePart", TextCompare: false)) || Conversions.ToBoolean (Operators.CompareObjectEqual (tag, "RotateSct", TextCompare: false)))) {
				CFSInterface.StoreUndoSct ("Rotate");
				short nPart = section.nPart;
				for (short num = 1; num <= nPart; num = (short)unchecked(num + 1)) {
					if ((num == section.iPart) | (Strings.StrComp (Conversions.ToString (base.Tag), "RotateSct", CompareMethod.Text) == 0)) {
						short nElem = section.Part [num].nElem;
						float num3;
						for (short num2 = 1; num2 <= nElem; num2 = (short)unchecked(num2 + 1)) {
							num3 = section.Part [num].Element [num2].Ang + sngAngle;
							while ((double)num3 <= -Math.PI) {
								num3 = (float)((double)num3 + Math.PI * 2.0);
							}
							while ((double)num3 >= Math.PI * 2.0) {
								num3 = (float)((double)num3 - Math.PI * 2.0);
							}
							section.Part [num].Element [num2].Ang = num3;
						}
						byte iXPosition = section.Part [num].iXPosition;
						byte iYPosition = section.Part [num].iYPosition;
						section.Part [num].iXPosition = 1;
						section.Part [num].iYPosition = 1;
						section.Part [num].Geometry (ref blnChg, ref strMsg);
						if (Strings.Len (strMsg) != 0) {
							Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
						}
						float num4 = (float)Math.Sqrt (Math.Pow (section.Part [num].XPosition, 2.0) + Math.Pow (section.Part [num].YPosition, 2.0));
						num3 = (float)Math.Atan2 (section.Part [num].YPosition, section.Part [num].XPosition);
						section.Part [num].XPosition = (float)((double)num4 * Math.Cos (sngAngle + num3));
						section.Part [num].YPosition = (float)((double)num4 * Math.Sin (sngAngle + num3));
						if (Math.Cos (sngAngle) >= 0.99999898672103882) {
							section.Part [num].iXPosition = iXPosition;
							section.Part [num].iYPosition = iYPosition;
							flag = true;
						} else if (Math.Cos (sngAngle) <= -0.99999898672103882) {
							section.Part [num].iXPosition = (byte)(2 - unchecked((int)iXPosition));
							section.Part [num].iYPosition = (byte)(2 - unchecked((int)iYPosition));
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "RotateSct", TextCompare: false), section.nPart == 1)))) {
								CFS.Swap (ref section.DSM.Mcrlxp, ref section.DSM.Mcrlxn);
								CFS.Swap (ref section.DSM.Mcrlyp, ref section.DSM.Mcrlyn);
								CFS.Swap (ref section.DSM.Mcrdxp, ref section.DSM.Mcrdxn);
								CFS.Swap (ref section.DSM.Mcrdyp, ref section.DSM.Mcrdyn);
								flag = true;
							}
						} else if (Math.Sin (sngAngle) >= 0.99999898672103882) {
							section.Part [num].iXPosition = iYPosition;
							section.Part [num].iYPosition = (byte)(2 - unchecked((int)iXPosition));
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "RotateSct", TextCompare: false), section.nPart == 1)))) {
								float mcrlxp = section.DSM.Mcrlxp;
								section.DSM.Mcrlxp = section.DSM.Mcrlyp;
								section.DSM.Mcrlyp = section.DSM.Mcrlxn;
								section.DSM.Mcrlxn = section.DSM.Mcrlyn;
								section.DSM.Mcrlyn = mcrlxp;
								mcrlxp = section.DSM.Mcrdxp;
								section.DSM.Mcrdxp = section.DSM.Mcrdyp;
								section.DSM.Mcrdyp = section.DSM.Mcrdxn;
								section.DSM.Mcrdxn = section.DSM.Mcrdyn;
								section.DSM.Mcrdyn = mcrlxp;
								CFS.Swap (ref section.DSM.Vcry, ref section.DSM.Vcrx);
								flag = true;
							}
						} else if (Math.Sin (sngAngle) <= -0.99999898672103882) {
							section.Part [num].iXPosition = (byte)(2 - unchecked((int)iYPosition));
							section.Part [num].iYPosition = iXPosition;
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "RotateSct", TextCompare: false), section.nPart == 1)))) {
								float mcrlxp = section.DSM.Mcrlxp;
								section.DSM.Mcrlxp = section.DSM.Mcrlyn;
								section.DSM.Mcrlyn = section.DSM.Mcrlxn;
								section.DSM.Mcrlxn = section.DSM.Mcrlyp;
								section.DSM.Mcrlyp = mcrlxp;
								mcrlxp = section.DSM.Mcrdxp;
								section.DSM.Mcrdxp = section.DSM.Mcrdyn;
								section.DSM.Mcrdyn = section.DSM.Mcrdxn;
								section.DSM.Mcrdxn = section.DSM.Mcrdyp;
								section.DSM.Mcrdyp = mcrlxp;
								CFS.Swap (ref section.DSM.Vcry, ref section.DSM.Vcrx);
								flag = true;
							}
						}
					}
				}
			} else if (Conversions.ToBoolean (Conversions.ToBoolean (Operators.CompareObjectEqual (tag, "MirrorPart", TextCompare: false)) || Conversions.ToBoolean (Operators.CompareObjectEqual (tag, "MirrorSct", TextCompare: false)))) {
				CFSInterface.StoreUndoSct ("Mirror");
				short nPart2 = section.nPart;
				for (short num = 1; num <= nPart2; num = (short)unchecked(num + 1)) {
					if ((num == section.iPart) | (Strings.StrComp (Conversions.ToString (base.Tag), "MirrorSct", CompareMethod.Text) == 0)) {
						short nElem2 = section.Part [num].nElem;
						float num3;
						for (short num2 = 1; num2 <= nElem2; num2 = (short)unchecked(num2 + 1)) {
							num3 = 2f * sngAngle - section.Part [num].Element [num2].Ang;
							while ((double)num3 <= -Math.PI) {
								num3 = (float)((double)num3 + Math.PI * 2.0);
							}
							while ((double)num3 >= Math.PI * 2.0) {
								num3 = (float)((double)num3 - Math.PI * 2.0);
							}
							section.Part [num].Element [num2].Ang = num3;
						}
						byte iXPosition = section.Part [num].iXPosition;
						byte iYPosition = section.Part [num].iYPosition;
						section.Part [num].iXPosition = 1;
						section.Part [num].iYPosition = 1;
						section.Part [num].Geometry (ref blnChg, ref strMsg);
						if (Strings.Len (strMsg) != 0) {
							Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
						}
						float num4 = (float)Math.Sqrt (Math.Pow (section.Part [num].XPosition, 2.0) + Math.Pow (section.Part [num].YPosition, 2.0));
						num3 = (float)Math.Atan2 (section.Part [num].YPosition, section.Part [num].XPosition);
						section.Part [num].XPosition = (float)((double)num4 * Math.Cos (2f * sngAngle - num3));
						section.Part [num].YPosition = (float)((double)num4 * Math.Sin (2f * sngAngle - num3));
						if (Math.Cos (2f * sngAngle) >= 0.99999898672103882) {
							section.Part [num].iXPosition = iXPosition;
							section.Part [num].iYPosition = (byte)(2 - unchecked((int)iYPosition));
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "MirrorSct", TextCompare: false), section.nPart == 1)))) {
								CFS.Swap (ref section.DSM.Mcrlxp, ref section.DSM.Mcrlxn);
								CFS.Swap (ref section.DSM.Mcrdxp, ref section.DSM.Mcrdxn);
								flag = true;
							}
						} else if (Math.Cos (2f * sngAngle) <= -0.99999898672103882) {
							section.Part [num].iXPosition = (byte)(2 - unchecked((int)iXPosition));
							section.Part [num].iYPosition = iYPosition;
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "MirrorSct", TextCompare: false), section.nPart == 1)))) {
								CFS.Swap (ref section.DSM.Mcrlyp, ref section.DSM.Mcrlyn);
								CFS.Swap (ref section.DSM.Mcrdyp, ref section.DSM.Mcrdyn);
								flag = true;
							}
						} else if (Math.Sin (2f * sngAngle) >= 0.99999898672103882) {
							section.Part [num].iXPosition = (byte)(2 - unchecked((int)iYPosition));
							section.Part [num].iYPosition = (byte)(2 - unchecked((int)iXPosition));
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "MirrorSct", TextCompare: false), section.nPart == 1)))) {
								CFS.Swap (ref section.DSM.Mcrlxp, ref section.DSM.Mcrlyp);
								CFS.Swap (ref section.DSM.Mcrlxn, ref section.DSM.Mcrlyn);
								CFS.Swap (ref section.DSM.Mcrdxp, ref section.DSM.Mcrdyp);
								CFS.Swap (ref section.DSM.Mcrdxn, ref section.DSM.Mcrdyn);
								CFS.Swap (ref section.DSM.Vcry, ref section.DSM.Vcrx);
								flag = true;
							}
						} else if (Math.Sin (2f * sngAngle) <= -0.99999898672103882) {
							section.Part [num].iXPosition = iYPosition;
							section.Part [num].iYPosition = iXPosition;
							if (Conversions.ToBoolean (Operators.AndObject (num == 1, Operators.OrObject (Operators.CompareObjectEqual (base.Tag, "MirrorSct", TextCompare: false), section.nPart == 1)))) {
								CFS.Swap (ref section.DSM.Mcrlxp, ref section.DSM.Mcrlyn);
								CFS.Swap (ref section.DSM.Mcrlxn, ref section.DSM.Mcrlyp);
								CFS.Swap (ref section.DSM.Mcrdxp, ref section.DSM.Mcrdyn);
								CFS.Swap (ref section.DSM.Mcrdxn, ref section.DSM.Mcrdyp);
								CFS.Swap (ref section.DSM.Vcry, ref section.DSM.Vcrx);
								flag = true;
							}
						}
					}
				}
			}
			if (((Strings.StrComp (Conversions.ToString (base.Tag), "RotatePart", CompareMethod.Text) == 0) | (Strings.StrComp (Conversions.ToString (base.Tag), "MirrorPart", CompareMethod.Text) == 0)) && section.nPart > 1) {
				section.GeomChange = true;
			}
			if (!flag) {
				section.GeomChangeDSM = true;
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			CFSInterface.SetMenuEdit ();
			section = null;
			CFS.blnRefreshGrdElements = true;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			Close ();
		}
	}
}
