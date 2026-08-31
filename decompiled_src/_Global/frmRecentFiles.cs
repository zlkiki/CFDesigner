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
using RSG.CFS;

[DesignerGenerated]
public class frmRecentFiles : Form
{
	private IContainer components;

	private ListViewItem[] listItems;

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

	internal virtual ListView listFiles {
		[CompilerGenerated]
		get {
			return _listFiles;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = listFiles_DoubleClick;
			ListView listView = _listFiles;
			if (listView != null) {
				listView.DoubleClick -= value2;
			}
			_listFiles = value;
			listView = _listFiles;
			if (listView != null) {
				listView.DoubleClick += value2;
			}
		}
	}

	public frmRecentFiles ()
	{
		base.Load += frmRecentFiles_Load;
		base.Resize += frmRecentFiles_Resize;
		base.KeyDown += frmRecentFiles_KeyDown;
		base.HelpButtonClicked += frmRecentFiles_HelpButtonClicked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmRecentFiles));
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.listFiles = new System.Windows.Forms.ListView ();
		base.SuspendLayout ();
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (331, 259);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 23);
		this.cmdOK.TabIndex = 1;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (412, 259);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 23);
		this.cmdCancel.TabIndex = 2;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.listFiles.FullRowSelect = true;
		this.listFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		this.listFiles.HideSelection = false;
		this.listFiles.Location = new System.Drawing.Point (9, 9);
		this.listFiles.MultiSelect = false;
		this.listFiles.Name = "listFiles";
		this.listFiles.Size = new System.Drawing.Size (478, 235);
		this.listFiles.TabIndex = 0;
		this.listFiles.UseCompatibleStateImageBehavior = false;
		this.listFiles.View = System.Windows.Forms.View.Details;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (499, 294);
		base.Controls.Add (this.listFiles);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.HelpButton = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size (500, 300);
		base.Name = "frmRecentFiles";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Recent Files";
		base.ResumeLayout (false);
	}

	private void frmRecentFiles_Load (object sender, EventArgs e)
	{
		checked {
			if (CFSInterface.bytRecentFileCount > 0) {
				listItems = new ListViewItem[unchecked((int)CFSInterface.bytRecentFileCount) - 1 + 1];
			}
			if (listFiles.Columns.Count == 0) {
				listFiles.Columns.Add ("Name", (int)Math.Round (0.4 * (double)listFiles.ClientSize.Width));
				listFiles.Columns.Add ("Location");
			}
			listFiles.Items.Clear ();
			int bytRecentFileCount = CFSInterface.bytRecentFileCount;
			for (int i = 1; i <= bytRecentFileCount; i++) {
				short num = (short)Strings.InStr (CFSInterface.strRecentFile [i], "|");
				if (num > 0) {
					StringType.MidStmtStr (ref CFSInterface.strRecentFile [i], num, int.MaxValue, "\\");
				}
				string fileName = Path.GetFileName (CFSInterface.strRecentFile [i]);
				string sDest = Path.GetDirectoryName (CFSInterface.strRecentFile [i]);
				if (num > 0) {
					StringType.MidStmtStr (ref CFSInterface.strRecentFile [i], num, int.MaxValue, "|");
				}
				if (num > 0) {
					StringType.MidStmtStr (ref sDest, num, int.MaxValue, "|");
				}
				listItems [i - 1] = new ListViewItem (fileName);
				listItems [i - 1].SubItems.Add (sDest);
				listItems [i - 1].Tag = CFSInterface.strRecentFile [i];
				listFiles.Items.Add (listItems [i - 1]);
			}
			listFiles.Columns [1].Width = -1;
			if (CFSInterface.bytRecentFileCount > 0) {
				listItems [0].Selected = true;
			}
		}
	}

	private void frmRecentFiles_Resize (object sender, EventArgs e)
	{
		checked {
			listFiles.Width = base.ClientSize.Width - listFiles.Left - 9;
			listFiles.Height = base.ClientSize.Height - listFiles.Top - cmdOK.Height - 18;
			cmdCancel.Top = listFiles.Top + listFiles.Height + 9;
			cmdCancel.Left = listFiles.Left + listFiles.Width - cmdCancel.Width;
			cmdOK.Top = cmdCancel.Top;
			cmdOK.Left = cmdCancel.Left - 9 - cmdOK.Width;
		}
	}

	private void frmRecentFiles_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "recent-files.htm");
			e.Handled = true;
		}
	}

	private void frmRecentFiles_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "recent-files.htm");
		e.Cancel = true;
	}

	private void listFiles_DoubleClick (object sender, EventArgs e)
	{
		cmdOK_Click (RuntimeHelpers.GetObjectValue (sender), e);
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		if (listFiles.SelectedItems.Count == 1) {
			Hide ();
			base.Tag = RuntimeHelpers.GetObjectValue (listFiles.SelectedItems [0].Tag);
			base.DialogResult = DialogResult.OK;
		}
	}
}
