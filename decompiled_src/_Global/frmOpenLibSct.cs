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
public class frmOpenLibSct : Form
{
	private IContainer components;

	private short[] nSct;

	[field: AccessedThroughProperty ("lblCompany")]
	internal virtual Label lblCompany {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress1")]
	internal virtual Label lblAddress1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress2")]
	internal virtual Label lblAddress2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress3")]
	internal virtual Label lblAddress3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress4")]
	internal virtual Label lblAddress4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblSectionType")]
	internal virtual Label lblSectionType {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSectionType {
		[CompilerGenerated]
		get {
			return _cboSectionType;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboSectionType_SelectedIndexChanged;
			ComboBox comboBox = _cboSectionType;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSectionType = value;
			comboBox = _cboSectionType;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblSections")]
	internal virtual Label lblSections {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ListBox lstSections {
		[CompilerGenerated]
		get {
			return _lstSections;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdOpen_Click;
			ListBox listBox = _lstSections;
			if (listBox != null) {
				listBox.DoubleClick -= value2;
			}
			_lstSections = value;
			listBox = _lstSections;
			if (listBox != null) {
				listBox.DoubleClick += value2;
			}
		}
	}

	internal virtual Button cmdOpen {
		[CompilerGenerated]
		get {
			return _cmdOpen;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdOpen_Click;
			Button button = _cmdOpen;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdOpen = value;
			button = _cmdOpen;
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

	public frmOpenLibSct ()
	{
		base.Load += frmOpenLibSct_Load;
		base.KeyDown += frmOpenLibSct_KeyDown;
		base.HelpButtonClicked += frmOpenLibSct_HelpButtonClicked;
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
		this.lblCompany = new System.Windows.Forms.Label ();
		this.lblAddress1 = new System.Windows.Forms.Label ();
		this.lblAddress2 = new System.Windows.Forms.Label ();
		this.lblAddress3 = new System.Windows.Forms.Label ();
		this.lblAddress4 = new System.Windows.Forms.Label ();
		this.lblSectionType = new System.Windows.Forms.Label ();
		this.cboSectionType = new System.Windows.Forms.ComboBox ();
		this.lblSections = new System.Windows.Forms.Label ();
		this.lstSections = new System.Windows.Forms.ListBox ();
		this.cmdOpen = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.lblCompany.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCompany.Location = new System.Drawing.Point (12, 9);
		this.lblCompany.Name = "lblCompany";
		this.lblCompany.Size = new System.Drawing.Size (342, 20);
		this.lblCompany.TabIndex = 0;
		this.lblCompany.Text = "Company Name";
		this.lblAddress1.Location = new System.Drawing.Point (12, 29);
		this.lblAddress1.Name = "lblAddress1";
		this.lblAddress1.Size = new System.Drawing.Size (342, 17);
		this.lblAddress1.TabIndex = 1;
		this.lblAddress1.Text = "Address Line 1";
		this.lblAddress2.Location = new System.Drawing.Point (12, 46);
		this.lblAddress2.Name = "lblAddress2";
		this.lblAddress2.Size = new System.Drawing.Size (342, 17);
		this.lblAddress2.TabIndex = 2;
		this.lblAddress2.Text = "Address Line 2";
		this.lblAddress3.Location = new System.Drawing.Point (12, 63);
		this.lblAddress3.Name = "lblAddress3";
		this.lblAddress3.Size = new System.Drawing.Size (342, 17);
		this.lblAddress3.TabIndex = 3;
		this.lblAddress3.Text = "Address Line 3";
		this.lblAddress4.Location = new System.Drawing.Point (12, 80);
		this.lblAddress4.Name = "lblAddress4";
		this.lblAddress4.Size = new System.Drawing.Size (342, 17);
		this.lblAddress4.TabIndex = 4;
		this.lblAddress4.Text = "Address Line 4";
		this.lblSectionType.Location = new System.Drawing.Point (12, 107);
		this.lblSectionType.Name = "lblSectionType";
		this.lblSectionType.Size = new System.Drawing.Size (83, 17);
		this.lblSectionType.TabIndex = 5;
		this.lblSectionType.Text = "Section &Type";
		this.cboSectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSectionType.FormattingEnabled = true;
		this.cboSectionType.Location = new System.Drawing.Point (101, 104);
		this.cboSectionType.Name = "cboSectionType";
		this.cboSectionType.Size = new System.Drawing.Size (253, 21);
		this.cboSectionType.TabIndex = 6;
		this.lblSections.Location = new System.Drawing.Point (12, 124);
		this.lblSections.Name = "lblSections";
		this.lblSections.Size = new System.Drawing.Size (83, 17);
		this.lblSections.TabIndex = 7;
		this.lblSections.Text = "Sections:";
		this.lstSections.FormattingEnabled = true;
		this.lstSections.Location = new System.Drawing.Point (15, 144);
		this.lstSections.MultiColumn = true;
		this.lstSections.Name = "lstSections";
		this.lstSections.Size = new System.Drawing.Size (338, 147);
		this.lstSections.TabIndex = 8;
		this.cmdOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOpen.Location = new System.Drawing.Point (197, 300);
		this.cmdOpen.Name = "cmdOpen";
		this.cmdOpen.Size = new System.Drawing.Size (75, 25);
		this.cmdOpen.TabIndex = 9;
		this.cmdOpen.Text = "Open";
		this.cmdOpen.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (278, 300);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 10;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOpen;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (366, 336);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOpen);
		base.Controls.Add (this.lstSections);
		base.Controls.Add (this.lblSections);
		base.Controls.Add (this.cboSectionType);
		base.Controls.Add (this.lblSectionType);
		base.Controls.Add (this.lblAddress4);
		base.Controls.Add (this.lblAddress3);
		base.Controls.Add (this.lblAddress2);
		base.Controls.Add (this.lblAddress1);
		base.Controls.Add (this.lblCompany);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmOpenLibSct";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Open Library Section";
		base.ResumeLayout (false);
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void frmOpenLibSct_Load (object sender, EventArgs e)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		short num3 = default(short);
		byte Value = default(byte);
		short Value3 = default(short);
		int Value4 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						base.Tag = string.Empty;
						ProjectData.ClearProjectError ();
						num2 = 2;
						num3 = (short)FileSystem.FreeFile ();
						FileSystem.FileOpen (num3, My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName, OpenMode.Binary, OpenAccess.Read);
						FileSystem.FileGet (num3, ref Value, -1L);
						string Value2 = Strings.Space (Value);
						FileSystem.FileGet (num3, ref Value2, -1L);
						lblCompany.Text = Value2;
						FileSystem.FileGet (num3, ref Value, -1L);
						Value2 = Strings.Space (Value);
						FileSystem.FileGet (num3, ref Value2, -1L);
						lblAddress1.Text = Value2;
						FileSystem.FileGet (num3, ref Value, -1L);
						Value2 = Strings.Space (Value);
						FileSystem.FileGet (num3, ref Value2, -1L);
						lblAddress2.Text = Value2;
						FileSystem.FileGet (num3, ref Value, -1L);
						Value2 = Strings.Space (Value);
						FileSystem.FileGet (num3, ref Value2, -1L);
						lblAddress3.Text = Value2;
						FileSystem.FileGet (num3, ref Value, -1L);
						Value2 = Strings.Space (Value);
						FileSystem.FileGet (num3, ref Value2, -1L);
						lblAddress4.Text = Value2;
						FileSystem.FileGet (num3, ref Value3, -1L);
						nSct = new short[Value3 - 1 + 1];
						short num4 = (short)(Value3 - 1);
						for (short num5 = 0; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
							FileSystem.FileGet (num3, ref Value, -1L);
							Value2 = Strings.Space (Value);
							FileSystem.FileGet (num3, ref Value2, -1L);
							FileSystem.FileGet (num3, ref Value4, -1L);
							FileSystem.FileGet (num3, ref nSct [num5], -1L);
							cboSectionType.Items.Add (new ListItem (Value2, Value4));
						}
						FileSystem.FileClose (num3);
						cboSectionType.SelectedIndex = 0;
						goto end_IL_0000;
					}
					case 501:
						num = -1;
						switch (num2) {
						case 2:
							FileSystem.FileClose (num3);
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000;
						}
						break;
					}
					goto IL_022b;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 501;
				continue;
			}
			break;
			IL_022b:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private void frmOpenLibSct_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "open-library-section.htm");
			e.Handled = true;
		}
	}

	private void frmOpenLibSct_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "open-library-section.htm");
		e.Cancel = true;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void cboSectionType_SelectedIndexChanged (object sender, EventArgs e)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		short num3 = default(short);
		byte Value = default(byte);
		int Value3 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						num3 = (short)FileSystem.FreeFile ();
						FileSystem.FileOpen (num3, My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName, OpenMode.Binary, OpenAccess.Read);
						FileSystem.Seek (num3, Conversions.ToLong (NewLateBinding.LateGet (cboSectionType.SelectedItem, null, "ItemData", new object[0], null, null, null)));
						lstSections.Items.Clear ();
						short num4 = nSct [cboSectionType.SelectedIndex];
						for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
							FileSystem.FileGet (num3, ref Value, -1L);
							string Value2 = Strings.Space (Value);
							FileSystem.FileGet (num3, ref Value2, -1L);
							FileSystem.FileGet (num3, ref Value3, -1L);
							if ((Operators.CompareString (Strings.LCase (Strings.Right (Value2, 4)), ".sct", TextCompare: false) != 0) & (Operators.CompareString (Strings.LCase (Strings.Right (Value2, 5)), ".cfss", TextCompare: false) != 0)) {
								Value2 += ".sct";
							}
							lstSections.Items.Add (new ListItem (Value2, Value3));
						}
						break;
					}
					case 368:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							break;
						default:
							goto end_IL_0000;
						}
						break;
					}
					FileSystem.FileClose (num3);
					lstSections.SelectedItem = -1;
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 368;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private void cmdOpen_Click (object sender, EventArgs e)
	{
		if (lstSections.SelectedIndex != -1) {
			base.Tag = Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName + "|", NewLateBinding.LateGet (cboSectionType.SelectedItem, null, "Text", new object[0], null, null, null)), "\\"), NewLateBinding.LateGet (lstSections.SelectedItem, null, "Text", new object[0], null, null, null));
			Close ();
		}
	}
}
