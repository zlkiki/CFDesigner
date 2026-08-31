// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmSctLib : Form
{
	private IContainer components;

	internal virtual Label lblFolder {
		[CompilerGenerated]
		get {
			return _lblFolder;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			MouseEventHandler value2 = lblFolder_MouseClick;
			Label label = _lblFolder;
			if (label != null) {
				label.MouseClick -= value2;
			}
			_lblFolder = value;
			label = _lblFolder;
			if (label != null) {
				label.MouseClick += value2;
			}
		}
	}

	internal virtual TextBox txtFolder {
		[CompilerGenerated]
		get {
			return _txtFolder;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtFolder_LostFocus;
			TextBox textBox = _txtFolder;
			if (textBox != null) {
				textBox.LostFocus -= value2;
			}
			_txtFolder = value;
			textBox = _txtFolder;
			if (textBox != null) {
				textBox.LostFocus += value2;
			}
		}
	}

	internal virtual Button cmdBrowse {
		[CompilerGenerated]
		get {
			return _cmdBrowse;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdBrowse_Click;
			Button button = _cmdBrowse;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdBrowse = value;
			button = _cmdBrowse;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCompany")]
	internal virtual Label lblCompany {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtCompany")]
	internal virtual TextBox txtCompany {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress1")]
	internal virtual Label lblAddress1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtAddress1")]
	internal virtual TextBox txtAddress1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress2")]
	internal virtual Label lblAddress2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtAddress2")]
	internal virtual TextBox txtAddress2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress3")]
	internal virtual Label lblAddress3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtAddress3")]
	internal virtual TextBox txtAddress3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAddress4")]
	internal virtual Label lblAddress4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtAddress4")]
	internal virtual TextBox txtAddress4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdBuild {
		[CompilerGenerated]
		get {
			return _cmdBuild;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdBuild_Click;
			Button button = _cmdBuild;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdBuild = value;
			button = _cmdBuild;
			if (button != null) {
				button.Click += value2;
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
			EventHandler value2 = cmdClose_Click;
			Button button = _cmdClose;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdClose = value;
			button = _cmdClose;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox chkRevision {
		[CompilerGenerated]
		get {
			return _chkRevision;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkRevision_Click;
			CheckBox checkBox = _chkRevision;
			if (checkBox != null) {
				checkBox.Click -= value2;
			}
			_chkRevision = value;
			checkBox = _chkRevision;
			if (checkBox != null) {
				checkBox.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblRevDate")]
	internal virtual Label lblRevDate {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRevDate")]
	internal virtual TextBox txtRevDate {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblRevBy")]
	internal virtual Label lblRevBy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtRevBy")]
	internal virtual TextBox txtRevBy {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmSctLib ()
	{
		base.Load += frmSctLib_Load;
		base.KeyDown += frmSctLib_KeyDown;
		base.HelpButtonClicked += frmSctLib_HelpButtonClicked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmSctLib));
		this.lblFolder = new System.Windows.Forms.Label ();
		this.txtFolder = new System.Windows.Forms.TextBox ();
		this.cmdBrowse = new System.Windows.Forms.Button ();
		this.lblCompany = new System.Windows.Forms.Label ();
		this.txtCompany = new System.Windows.Forms.TextBox ();
		this.lblAddress1 = new System.Windows.Forms.Label ();
		this.txtAddress1 = new System.Windows.Forms.TextBox ();
		this.lblAddress2 = new System.Windows.Forms.Label ();
		this.txtAddress2 = new System.Windows.Forms.TextBox ();
		this.lblAddress3 = new System.Windows.Forms.Label ();
		this.txtAddress3 = new System.Windows.Forms.TextBox ();
		this.lblAddress4 = new System.Windows.Forms.Label ();
		this.txtAddress4 = new System.Windows.Forms.TextBox ();
		this.cmdBuild = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.chkRevision = new System.Windows.Forms.CheckBox ();
		this.lblRevDate = new System.Windows.Forms.Label ();
		this.txtRevDate = new System.Windows.Forms.TextBox ();
		this.lblRevBy = new System.Windows.Forms.Label ();
		this.txtRevBy = new System.Windows.Forms.TextBox ();
		base.SuspendLayout ();
		this.lblFolder.Location = new System.Drawing.Point (12, 9);
		this.lblFolder.Name = "lblFolder";
		this.lblFolder.Size = new System.Drawing.Size (290, 17);
		this.lblFolder.TabIndex = 0;
		this.lblFolder.Text = "Library Folder";
		this.txtFolder.Location = new System.Drawing.Point (12, 29);
		this.txtFolder.Name = "txtFolder";
		this.txtFolder.Size = new System.Drawing.Size (310, 20);
		this.txtFolder.TabIndex = 1;
		this.cmdBrowse.Location = new System.Drawing.Point (328, 26);
		this.cmdBrowse.Name = "cmdBrowse";
		this.cmdBrowse.Size = new System.Drawing.Size (75, 25);
		this.cmdBrowse.TabIndex = 2;
		this.cmdBrowse.Text = "&Browse";
		this.cmdBrowse.UseVisualStyleBackColor = true;
		this.lblCompany.Location = new System.Drawing.Point (12, 68);
		this.lblCompany.Name = "lblCompany";
		this.lblCompany.Size = new System.Drawing.Size (60, 17);
		this.lblCompany.TabIndex = 3;
		this.lblCompany.Text = "&Company";
		this.txtCompany.Location = new System.Drawing.Point (78, 65);
		this.txtCompany.MaxLength = 255;
		this.txtCompany.Name = "txtCompany";
		this.txtCompany.Size = new System.Drawing.Size (325, 20);
		this.txtCompany.TabIndex = 4;
		this.lblAddress1.Location = new System.Drawing.Point (12, 94);
		this.lblAddress1.Name = "lblAddress1";
		this.lblAddress1.Size = new System.Drawing.Size (60, 17);
		this.lblAddress1.TabIndex = 5;
		this.lblAddress1.Text = "Address &1";
		this.txtAddress1.Location = new System.Drawing.Point (78, 91);
		this.txtAddress1.MaxLength = 255;
		this.txtAddress1.Name = "txtAddress1";
		this.txtAddress1.Size = new System.Drawing.Size (325, 20);
		this.txtAddress1.TabIndex = 6;
		this.lblAddress2.Location = new System.Drawing.Point (12, 120);
		this.lblAddress2.Name = "lblAddress2";
		this.lblAddress2.Size = new System.Drawing.Size (60, 17);
		this.lblAddress2.TabIndex = 7;
		this.lblAddress2.Text = "Address &2";
		this.txtAddress2.Location = new System.Drawing.Point (78, 117);
		this.txtAddress2.MaxLength = 255;
		this.txtAddress2.Name = "txtAddress2";
		this.txtAddress2.Size = new System.Drawing.Size (325, 20);
		this.txtAddress2.TabIndex = 8;
		this.lblAddress3.Location = new System.Drawing.Point (12, 146);
		this.lblAddress3.Name = "lblAddress3";
		this.lblAddress3.Size = new System.Drawing.Size (60, 17);
		this.lblAddress3.TabIndex = 9;
		this.lblAddress3.Text = "Address &3";
		this.txtAddress3.Location = new System.Drawing.Point (78, 143);
		this.txtAddress3.MaxLength = 255;
		this.txtAddress3.Name = "txtAddress3";
		this.txtAddress3.Size = new System.Drawing.Size (325, 20);
		this.txtAddress3.TabIndex = 10;
		this.lblAddress4.Location = new System.Drawing.Point (12, 172);
		this.lblAddress4.Name = "lblAddress4";
		this.lblAddress4.Size = new System.Drawing.Size (60, 17);
		this.lblAddress4.TabIndex = 11;
		this.lblAddress4.Text = "Address &4";
		this.txtAddress4.Location = new System.Drawing.Point (78, 169);
		this.txtAddress4.MaxLength = 255;
		this.txtAddress4.Name = "txtAddress4";
		this.txtAddress4.Size = new System.Drawing.Size (325, 20);
		this.txtAddress4.TabIndex = 12;
		this.cmdBuild.Location = new System.Drawing.Point (118, 206);
		this.cmdBuild.Name = "cmdBuild";
		this.cmdBuild.Size = new System.Drawing.Size (75, 25);
		this.cmdBuild.TabIndex = 13;
		this.cmdBuild.Text = "Buil&d";
		this.cmdBuild.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (222, 206);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (75, 25);
		this.cmdClose.TabIndex = 14;
		this.cmdClose.Text = "Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.chkRevision.AutoSize = true;
		this.chkRevision.Location = new System.Drawing.Point (15, 237);
		this.chkRevision.Name = "chkRevision";
		this.chkRevision.Size = new System.Drawing.Size (161, 17);
		this.chkRevision.TabIndex = 15;
		this.chkRevision.Text = "Modify Section &Revision Info";
		this.chkRevision.UseVisualStyleBackColor = true;
		this.chkRevision.Visible = false;
		this.lblRevDate.AutoSize = true;
		this.lblRevDate.Location = new System.Drawing.Point (12, 257);
		this.lblRevDate.Name = "lblRevDate";
		this.lblRevDate.Size = new System.Drawing.Size (81, 13);
		this.lblRevDate.TabIndex = 16;
		this.lblRevDate.Text = "Rev Date/Time";
		this.lblRevDate.Visible = false;
		this.txtRevDate.Location = new System.Drawing.Point (99, 254);
		this.txtRevDate.Name = "txtRevDate";
		this.txtRevDate.Size = new System.Drawing.Size (143, 20);
		this.txtRevDate.TabIndex = 17;
		this.txtRevDate.Visible = false;
		this.lblRevBy.AutoSize = true;
		this.lblRevBy.Location = new System.Drawing.Point (12, 277);
		this.lblRevBy.Name = "lblRevBy";
		this.lblRevBy.Size = new System.Drawing.Size (61, 13);
		this.lblRevBy.TabIndex = 18;
		this.lblRevBy.Text = "Revised By";
		this.lblRevBy.Visible = false;
		this.txtRevBy.Location = new System.Drawing.Point (99, 274);
		this.txtRevBy.MaxLength = 16;
		this.txtRevBy.Name = "txtRevBy";
		this.txtRevBy.Size = new System.Drawing.Size (143, 20);
		this.txtRevBy.TabIndex = 19;
		this.txtRevBy.Visible = false;
		base.AcceptButton = this.cmdBuild;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (415, 241);
		base.Controls.Add (this.txtRevBy);
		base.Controls.Add (this.lblRevBy);
		base.Controls.Add (this.txtRevDate);
		base.Controls.Add (this.lblRevDate);
		base.Controls.Add (this.cmdClose);
		base.Controls.Add (this.cmdBuild);
		base.Controls.Add (this.txtAddress4);
		base.Controls.Add (this.lblAddress4);
		base.Controls.Add (this.txtAddress3);
		base.Controls.Add (this.lblAddress3);
		base.Controls.Add (this.txtAddress2);
		base.Controls.Add (this.lblAddress2);
		base.Controls.Add (this.txtAddress1);
		base.Controls.Add (this.lblAddress1);
		base.Controls.Add (this.txtCompany);
		base.Controls.Add (this.lblCompany);
		base.Controls.Add (this.cmdBrowse);
		base.Controls.Add (this.txtFolder);
		base.Controls.Add (this.lblFolder);
		base.Controls.Add (this.chkRevision);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSctLib";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Section Library Builder";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmSctLib_Load (object sender, EventArgs e)
	{
		txtFolder.Text = SpecialDirectories.MyDocuments + "\\CFS Files";
		txtRevDate.Text = Strings.Format (DateAndTime.Now, "General Date");
		txtRevBy.Text = "RSG Software";
	}

	private void frmSctLib_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "library-builder.htm");
			e.Handled = true;
		}
	}

	private void frmSctLib_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "library-builder.htm");
		e.Cancel = true;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void GetHeader ()
	{
		if (Operators.ConditionalCompareObjectEqual (txtFolder.Text, txtFolder.Tag, TextCompare: false)) {
			return;
		}
		if (Directory.Exists (txtFolder.Text)) {
			string text = txtFolder.Text + ".cfsl";
			if (!File.Exists (text)) {
				text = txtFolder.Text + ".scl";
			}
			if (File.Exists (text)) {
				short num = checked((short)Microsoft.VisualBasic.FileSystem.FreeFile ());
				Microsoft.VisualBasic.FileSystem.FileOpen (num, text, OpenMode.Binary, OpenAccess.Read);
				byte Value = default(byte);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				string Value2 = Strings.Space (Value);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value2, -1L);
				txtCompany.Text = Value2;
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				Value2 = Strings.Space (Value);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value2, -1L);
				txtAddress1.Text = Value2;
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				Value2 = Strings.Space (Value);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value2, -1L);
				txtAddress2.Text = Value2;
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				Value2 = Strings.Space (Value);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value2, -1L);
				txtAddress3.Text = Value2;
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				Value2 = Strings.Space (Value);
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value2, -1L);
				txtAddress4.Text = Value2;
				Microsoft.VisualBasic.FileSystem.FileClose (num);
			} else {
				txtCompany.Text = string.Empty;
				txtAddress1.Text = string.Empty;
				txtAddress2.Text = string.Empty;
				txtAddress3.Text = string.Empty;
				txtAddress4.Text = string.Empty;
			}
			Refresh ();
		}
		txtFolder.Tag = txtFolder.Text;
	}

	private void chkRevision_Click (object sender, EventArgs e)
	{
		lblRevDate.Enabled = chkRevision.Checked;
		txtRevDate.Enabled = chkRevision.Checked;
		lblRevBy.Enabled = chkRevision.Checked;
		txtRevBy.Enabled = chkRevision.Checked;
	}

	private void cmdBrowse_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.mdiCFS.dlgGetFolder.Description = "Select a folder which contains sub-folders with section files. Each sub-folder is a section type grouping in the library.";
		My.MyProject.Forms.mdiCFS.dlgGetFolder.SelectedPath = txtFolder.Text;
		My.MyProject.Forms.mdiCFS.dlgGetFolder.ShowNewFolderButton = false;
		if (My.MyProject.Forms.mdiCFS.dlgGetFolder.ShowDialog (this) != DialogResult.Cancel) {
			txtFolder.Text = My.MyProject.Forms.mdiCFS.dlgGetFolder.SelectedPath;
			GetHeader ();
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void cmdBuild_Click (object sender, EventArgs e)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		DateTime value2 = default(DateTime);
		int num = default(int);
		int num3 = default(int);
		int Value = default(int);
		short Value2 = default(short);
		int num17 = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					string[] array;
					string[] array2;
					string value;
					short num5;
					short num7;
					short num4;
					string text2;
					byte value3;
					int num10;
					short num11;
					short num13;
					int num18;
					int num12;
					short num19;
					switch (try0000_dispatch) {
					default:
						array = new string[11];
						array2 = new string[11];
						new Section ();
						_ = string.Empty;
						value = Strings.Space (16);
						_ = string.Empty;
						ProjectData.ClearProjectError ();
						num2 = 2;
						if (CFS.intLicenseType == CFS.LicenseTypes.None) {
							CFS.LicenseRequired ("This feature requires a full CFS license.");
							goto end_IL_0000;
						}
						if (!Directory.Exists (txtFolder.Text)) {
							Interaction.MsgBox ("Not a valid directory.");
							goto end_IL_0000;
						}
						if (Strings.Len (txtCompany.Text) == 0) {
							Interaction.MsgBox ("Company name not specified.");
							goto end_IL_0000;
						}
						if (!chkRevision.Checked) {
							goto IL_00ff;
						}
						if (!Information.IsDate (txtRevDate.Text)) {
							Interaction.MsgBox ("Invalid revision date/time.");
							goto end_IL_0000;
						}
						value2 = Conversions.ToDate (txtRevDate.Text);
						value = txtRevBy.Text + Strings.Space (16 - Strings.Len (txtRevBy.Text));
						goto IL_00ff;
					case 2291:
						{
							num = -1;
							switch (num2) {
							case 2:
								if (num3 != 0) {
									Microsoft.VisualBasic.FileSystem.FileClose (num3);
								}
								Cursor.Current = Cursors.Default;
								Interaction.MsgBox ("Unexpected Error: " + Information.Err ().Description, MsgBoxStyle.Information);
								goto end_IL_0000_2;
							}
							break;
						}
						IL_00ff:
						num4 = 1;
						array [num4] = Microsoft.VisualBasic.FileSystem.Dir (txtFolder.Text + "\\*.*", FileAttribute.Directory);
						while (Strings.Len (array [num4]) > 0) {
							num4 = (short)(num4 + 1);
							if (num4 > Information.UBound (array)) {
								array = (string[])Utils.CopyArray (array, new string[num4 + 9 + 1]);
							}
							array [num4] = Microsoft.VisualBasic.FileSystem.Dir ();
						}
						num4 = (short)(num4 - 1);
						num5 = num4;
						for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
							if ((Operators.CompareString (array [num6], ".", TextCompare: false) == 0) | (Operators.CompareString (array [num6], "..", TextCompare: false) == 0)) {
								array [num6] = string.Empty;
							} else if (!Directory.Exists (txtFolder.Text + "\\" + array [num6])) {
								array [num6] = string.Empty;
							} else if ((Strings.Len (Microsoft.VisualBasic.FileSystem.Dir (txtFolder.Text + "\\" + array [num6] + "\\*.cfss")) == 0) & (Strings.Len (Microsoft.VisualBasic.FileSystem.Dir (txtFolder.Text + "\\" + array [num6] + "\\*.sct")) == 0)) {
								array [num6] = string.Empty;
							}
						}
						num7 = (short)(num4 - 1);
						for (short num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
							short num9 = num8;
							while (num9 >= 1 && Strings.Len (array [num9 + 1]) != 0 && !((Strings.Len (array [num9]) > 0) & (Operators.CompareString (array [num9], array [num9 + 1], TextCompare: false) <= 0))) {
								string text = array [num9];
								array [num9] = array [num9 + 1];
								array [num9 + 1] = text;
								num9 = (short)unchecked(num9 + -1);
							}
						}
						num4 = num4;
						while (num4 >= 1 && Strings.Len (array [num4]) <= 0) {
							num4 = (short)unchecked(num4 + -1);
						}
						if (num4 == 0) {
							Interaction.MsgBox ("No section files found in any subdirectories");
							goto end_IL_0000;
						}
						Cursor.Current = Cursors.WaitCursor;
						text2 = txtFolder.Text + ".cfsl";
						if (File.Exists (text2)) {
							Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile (text2);
						}
						num3 = Microsoft.VisualBasic.FileSystem.FreeFile ();
						Microsoft.VisualBasic.FileSystem.FileOpen (num3, text2, OpenMode.Binary, OpenAccess.ReadWrite);
						value3 = (byte)Strings.Len (txtCompany.Text);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, txtCompany.Text, -1L);
						value3 = (byte)Strings.Len (txtAddress1.Text);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, txtAddress1.Text, -1L);
						value3 = (byte)Strings.Len (txtAddress2.Text);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, txtAddress2.Text, -1L);
						value3 = (byte)Strings.Len (txtAddress3.Text);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, txtAddress3.Text, -1L);
						value3 = (byte)Strings.Len (txtAddress4.Text);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, txtAddress4.Text, -1L);
						Microsoft.VisualBasic.FileSystem.FilePut (num3, num4, -1L);
						num10 = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
						num11 = num4;
						for (short num6 = 1; num6 <= num11; num6 = (short)unchecked(num6 + 1)) {
							value3 = (byte)Strings.Len (array [num6]);
							Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
							Microsoft.VisualBasic.FileSystem.FilePut (num3, array [num6], -1L);
							Microsoft.VisualBasic.FileSystem.FilePut (num3, Value, -1L);
							Microsoft.VisualBasic.FileSystem.FilePut (num3, Value2, -1L);
						}
						Value = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
						num12 = num10;
						num13 = num4;
						for (short num6 = 1; num6 <= num13; num6 = (short)unchecked(num6 + 1)) {
							Value2 = 1;
							array2 [Value2] = Microsoft.VisualBasic.FileSystem.Dir (txtFolder.Text + "\\" + array [num6] + "\\*.cfss");
							while (Strings.Len (array2 [Value2]) > 0) {
								Value2 = (short)(Value2 + 1);
								if (Value2 > Information.UBound (array2)) {
									array2 = (string[])Utils.CopyArray (array2, new string[Value2 + 9 + 1]);
								}
								array2 [Value2] = Microsoft.VisualBasic.FileSystem.Dir ();
							}
							array2 [Value2] = Microsoft.VisualBasic.FileSystem.Dir (txtFolder.Text + "\\" + array [num6] + "\\*.sct");
							while (Strings.Len (array2 [Value2]) > 0) {
								Value2 = (short)(Value2 + 1);
								if (Value2 > Information.UBound (array2)) {
									array2 = (string[])Utils.CopyArray (array2, new string[Value2 + 9 + 1]);
								}
								array2 [Value2] = Microsoft.VisualBasic.FileSystem.Dir ();
							}
							Value2 = (short)(Value2 - 1);
							short num14 = (short)(Value2 - 1);
							for (short num8 = 1; num8 <= num14; num8 = (short)unchecked(num8 + 1)) {
								short num9 = num8;
								while (num9 >= 1 && Operators.CompareString (array2 [num9], array2 [num9 + 1], TextCompare: false) > 0) {
									string text = array2 [num9];
									array2 [num9] = array2 [num9 + 1];
									array2 [num9 + 1] = text;
									num9 = (short)unchecked(num9 + -1);
								}
							}
							Microsoft.VisualBasic.FileSystem.Seek (num3, num12 + 1 + Strings.Len (array [num6]));
							Microsoft.VisualBasic.FileSystem.FilePut (num3, Value, -1L);
							Microsoft.VisualBasic.FileSystem.FilePut (num3, Value2, -1L);
							num12 = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
							Microsoft.VisualBasic.FileSystem.Seek (num3, Value);
							short num15 = Value2;
							for (short num16 = 1; num16 <= num15; num16 = (short)unchecked(num16 + 1)) {
								value3 = (byte)Strings.Len (array2 [num16]);
								Microsoft.VisualBasic.FileSystem.FilePut (num3, value3, -1L);
								Microsoft.VisualBasic.FileSystem.FilePut (num3, array2 [num16], -1L);
								Microsoft.VisualBasic.FileSystem.FilePut (num3, num17, -1L);
							}
							Value = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
						}
						num17 = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
						num18 = Microsoft.VisualBasic.FileSystem.FreeFile ();
						num12 = num10;
						num19 = num4;
						for (short num6 = 1; num6 <= num19; num6 = (short)unchecked(num6 + 1)) {
							Microsoft.VisualBasic.FileSystem.Seek (num3, num12);
							Microsoft.VisualBasic.FileSystem.FileGet (num3, ref value3, -1L);
							Microsoft.VisualBasic.FileSystem.FileGet (num3, ref array [num6], -1L);
							Microsoft.VisualBasic.FileSystem.FileGet (num3, ref Value, -1L);
							Microsoft.VisualBasic.FileSystem.FileGet (num3, ref Value2, -1L);
							num12 = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
							short num20 = Value2;
							for (short num16 = 1; num16 <= num20; num16 = (short)unchecked(num16 + 1)) {
								Microsoft.VisualBasic.FileSystem.Seek (num3, Value);
								Microsoft.VisualBasic.FileSystem.FileGet (num3, ref value3, -1L);
								string text = Strings.Space (value3);
								Microsoft.VisualBasic.FileSystem.FileGet (num3, ref text, -1L);
								Microsoft.VisualBasic.FileSystem.FilePut (num3, num17, -1L);
								Value = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
								Microsoft.VisualBasic.FileSystem.FileOpen (num18, txtFolder.Text + "\\" + array [num6] + "\\" + text, OpenMode.Binary, OpenAccess.Read);
								string Value3 = Strings.Space ((int)Microsoft.VisualBasic.FileSystem.LOF (num18));
								Microsoft.VisualBasic.FileSystem.FileGet (num18, ref Value3, -1L);
								Microsoft.VisualBasic.FileSystem.FileClose (num18);
								Microsoft.VisualBasic.FileSystem.Seek (num3, num17);
								if (chkRevision.Checked) {
									text = Strings.Left (Value3, 2);
									short num21 = (short)(Strings.Asc (text) * 100 + Strings.Asc (Strings.Mid (text, 2, 1)));
									Microsoft.VisualBasic.FileSystem.FilePut (num3, text, -1L);
									Microsoft.VisualBasic.FileSystem.FilePut (num3, value2, -1L);
									Microsoft.VisualBasic.FileSystem.FilePut (num3, value, -1L);
									if (num21 <= 400) {
										text = Strings.Mid (Value3, 27);
									} else {
										Microsoft.VisualBasic.FileSystem.FilePut (num3, Strings.Space (24), -1L);
										text = Strings.Mid (Value3, 51);
									}
									Microsoft.VisualBasic.FileSystem.FilePut (num3, text, -1L);
								} else {
									Microsoft.VisualBasic.FileSystem.FilePut (num3, Value3, -1L);
								}
								num17 = (int)Microsoft.VisualBasic.FileSystem.Seek (num3);
							}
						}
						Microsoft.VisualBasic.FileSystem.FileClose (num3);
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("The following section library has been created with " + Conversions.ToString (unchecked((int)num4)) + " groups.\r\n\r\n" + text2, MsgBoxStyle.Information);
						goto end_IL_0000_2;
					}
					goto IL_0929;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 2291;
				continue;
			}
			break;
			IL_0929:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private void cmdClose_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private void lblFolder_MouseClick (object sender, MouseEventArgs e)
	{
		checked {
			if ((e.Button == MouseButtons.Middle) & !chkRevision.Visible) {
				base.Height += 60;
				chkRevision.Visible = true;
				lblRevDate.Visible = true;
				txtRevDate.Visible = true;
				lblRevBy.Visible = true;
				txtRevBy.Visible = true;
			}
		}
	}

	private void txtFolder_LostFocus (object sender, EventArgs e)
	{
		while (Operators.CompareString (Strings.Right (txtFolder.Text, 1), "\\", TextCompare: false) == 0) {
			txtFolder.Text = Strings.Left (txtFolder.Text, checked(Strings.Len (txtFolder.Text) - 1));
		}
		GetHeader ();
	}
}
