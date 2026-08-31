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
public class frmPrint : Form
{
	private IContainer components;

	internal virtual CheckedListBox lstPrint {
		[CompilerGenerated]
		get {
			return _lstPrint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			ItemCheckEventHandler value2 = lstPrint_ItemCheck;
			CancelEventHandler value3 = lstPrint_Validating;
			CheckedListBox checkedListBox = _lstPrint;
			if (checkedListBox != null) {
				checkedListBox.ItemCheck -= value2;
				checkedListBox.Validating -= value3;
			}
			_lstPrint = value;
			checkedListBox = _lstPrint;
			if (checkedListBox != null) {
				checkedListBox.ItemCheck += value2;
				checkedListBox.Validating += value3;
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

	internal virtual Button cmdHeading {
		[CompilerGenerated]
		get {
			return _cmdHeading;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdHeading_Click;
			Button button = _cmdHeading;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdHeading = value;
			button = _cmdHeading;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdSelectAll {
		[CompilerGenerated]
		get {
			return _cmdSelectAll;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdSelectAll_Click;
			Button button = _cmdSelectAll;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdSelectAll = value;
			button = _cmdSelectAll;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdUnselectAll {
		[CompilerGenerated]
		get {
			return _cmdUnselectAll;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdUnselectAll_Click;
			Button button = _cmdUnselectAll;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdUnselectAll = value;
			button = _cmdUnselectAll;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmPrint ()
	{
		base.Load += frmPrint_Load;
		base.KeyDown += frmPrint_KeyDown;
		base.HelpButtonClicked += frmPrint_HelpButtonClicked;
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
		this.lstPrint = new System.Windows.Forms.CheckedListBox ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.cmdHeading = new System.Windows.Forms.Button ();
		this.cmdSelectAll = new System.Windows.Forms.Button ();
		this.cmdUnselectAll = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.lstPrint.CheckOnClick = true;
		this.lstPrint.FormattingEnabled = true;
		this.lstPrint.Location = new System.Drawing.Point (15, 50);
		this.lstPrint.Name = "lstPrint";
		this.lstPrint.Size = new System.Drawing.Size (309, 184);
		this.lstPrint.TabIndex = 1;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Location = new System.Drawing.Point (168, 240);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (75, 25);
		this.cmdOK.TabIndex = 3;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (249, 240);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 4;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.cmdHeading.Location = new System.Drawing.Point (15, 240);
		this.cmdHeading.Name = "cmdHeading";
		this.cmdHeading.Size = new System.Drawing.Size (75, 25);
		this.cmdHeading.TabIndex = 2;
		this.cmdHeading.Text = "&Heading...";
		this.cmdHeading.UseVisualStyleBackColor = true;
		this.cmdSelectAll.Location = new System.Drawing.Point (15, 15);
		this.cmdSelectAll.Name = "cmdSelectAll";
		this.cmdSelectAll.Size = new System.Drawing.Size (75, 25);
		this.cmdSelectAll.TabIndex = 5;
		this.cmdSelectAll.Text = "Select &All";
		this.cmdSelectAll.UseVisualStyleBackColor = true;
		this.cmdUnselectAll.Location = new System.Drawing.Point (96, 15);
		this.cmdUnselectAll.Name = "cmdUnselectAll";
		this.cmdUnselectAll.Size = new System.Drawing.Size (75, 25);
		this.cmdUnselectAll.TabIndex = 6;
		this.cmdUnselectAll.Text = "&Unselect All";
		this.cmdUnselectAll.UseVisualStyleBackColor = true;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (338, 274);
		base.Controls.Add (this.cmdUnselectAll);
		base.Controls.Add (this.cmdSelectAll);
		base.Controls.Add (this.cmdHeading);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.lstPrint);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmPrint";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Items to Print";
		base.ResumeLayout (false);
	}

	private void frmPrint_Load (object sender, EventArgs e)
	{
		checked {
			short num = (short)Information.UBound (CFS.hdgSctPic);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgSctPic [num2].Deleted) {
					string fileName = CFSInterface.GetFileName (CFS.Sections [num2].Filename);
					short nPart = CFS.Sections [num2].nPart;
					short num3;
					for (num3 = 1; num3 <= nPart; num3 = (short)unchecked(num3 + 1)) {
						short nElem = CFS.Sections [num2].Part [num3].nElem;
						short num4 = 1;
						while (num4 <= nElem && !(CFS.Sections [num2].Part [num3].Element [num4].Len > 0f)) {
							num4 = (short)unchecked(num4 + 1);
						}
						if (num4 <= CFS.Sections [num2].Part [num3].nElem) {
							break;
						}
					}
					if (num3 <= CFS.Sections [num2].nPart) {
						lstPrint.Items.Add (new ListItem ("Large Section Graphic: " + fileName, num2));
					}
					lstPrint.Items.Add (new ListItem ("Section Inputs: " + fileName, num2));
					if (CFS.frmSctPic [num2] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
						lstPrint.SetItemChecked (lstPrint.Items.Count - 1, value: true);
					}
					short num5 = CFSInterface.FindSctRptIndex (CFS.Sections [num2]);
					if (num5 > 0) {
						lstPrint.Items.Add (new ListItem (CFS.frmReport [num5].Text, num5));
						if (CFS.frmReport [num5] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
							lstPrint.SetItemChecked (lstPrint.Items.Count - 1, value: true);
						}
					}
				}
			}
			short num6 = (short)Information.UBound (CFS.hdgAnlPic);
			for (short num2 = 1; num2 <= num6; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgAnlPic [num2].Deleted) {
					string fileName = CFSInterface.GetFileName (CFS.Analyses [num2].Filename);
					lstPrint.Items.Add (new ListItem ("Analysis Inputs: " + fileName, num2));
					if (CFS.frmAnlPic [num2] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
						lstPrint.SetItemChecked (lstPrint.Items.Count - 1, value: true);
					}
					short num5 = CFSInterface.FindAnlRptIndex (CFS.Analyses [num2]);
					if (num5 > 0) {
						lstPrint.Items.Add (new ListItem (CFS.frmReport [num5].Text, num5));
						if (CFS.frmReport [num5] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
							lstPrint.SetItemChecked (lstPrint.Items.Count - 1, value: true);
						}
					}
				}
			}
			short num7 = (short)Information.UBound (CFS.hdgReport);
			for (short num2 = 1; num2 <= num7; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgReport [num2].Deleted && ((CFSInterface.FindSctIndex (num2) == 0) & (CFSInterface.FindAnlIndex (num2) == 0))) {
					lstPrint.Items.Add (new ListItem (CFS.frmReport [num2].Text, num2));
					if (CFS.frmReport [num2] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
						lstPrint.SetItemChecked (lstPrint.Items.Count - 1, value: true);
					}
				}
			}
		}
	}

	private void frmPrint_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "print.htm");
			e.Handled = true;
		}
	}

	private void frmPrint_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "print.htm");
		e.Cancel = true;
	}

	private void cmdSelectAll_Click (object sender, EventArgs e)
	{
		checked {
			int num = lstPrint.Items.Count - 1;
			for (int i = 0; i <= num; i++) {
				lstPrint.SetItemChecked (i, value: true);
			}
		}
	}

	private void cmdUnselectAll_Click (object sender, EventArgs e)
	{
		checked {
			int num = lstPrint.Items.Count - 1;
			for (int i = 0; i <= num; i++) {
				lstPrint.SetItemChecked (i, value: false);
			}
		}
	}

	private void lstPrint_ItemCheck (object sender, ItemCheckEventArgs e)
	{
		cmdOK.Enabled = checked(lstPrint.CheckedItems.Count + e.NewValue - e.CurrentValue) > 0;
	}

	private void lstPrint_Validating (object sender, CancelEventArgs e)
	{
		cmdOK.Enabled = lstPrint.CheckedItems.Count > 0;
	}

	private void cmdHeading_Click (object sender, EventArgs e)
	{
		CFS.bytOptionsTab = 3;
		My.MyProject.Forms.frmOptions.ShowDialog (this);
		My.MyProject.Forms.frmOptions.Dispose ();
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		PrintRoutines.PrintReports ();
		Close ();
	}
}
