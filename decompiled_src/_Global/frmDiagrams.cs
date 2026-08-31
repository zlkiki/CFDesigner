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
public class frmDiagrams : Form
{
	private IContainer components;

	private bool blnCodeChange;

	private GraphicsX DiagramGraphics;

	internal bool blnTorsionCalc;

	internal short iCombPrev;

	internal virtual PictureBox picDiagrams {
		[CompilerGenerated]
		get {
			return _picDiagrams;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			MouseEventHandler value2 = picDiagrams_MouseMove;
			EventHandler value3 = picDiagrams_MouseLeave;
			PictureBox pictureBox = _picDiagrams;
			if (pictureBox != null) {
				pictureBox.MouseMove -= value2;
				pictureBox.MouseLeave -= value3;
			}
			_picDiagrams = value;
			pictureBox = _picDiagrams;
			if (pictureBox != null) {
				pictureBox.MouseMove += value2;
				pictureBox.MouseLeave += value3;
			}
		}
	}

	internal virtual VScrollBar vsbDiagrams {
		[CompilerGenerated]
		get {
			return _vsbDiagrams;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = vsbDiagrams_ValueChanged;
			VScrollBar vScrollBar = _vsbDiagrams;
			if (vScrollBar != null) {
				vScrollBar.ValueChanged -= value2;
			}
			_vsbDiagrams = value;
			vScrollBar = _vsbDiagrams;
			if (vScrollBar != null) {
				vScrollBar.ValueChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("pnlDiagrams")]
	internal virtual Panel pnlDiagrams {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblComb")]
	internal virtual Label lblComb {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdPrint {
		[CompilerGenerated]
		get {
			return _cmdPrint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdPrint_Click;
			Button button = _cmdPrint;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdPrint = value;
			button = _cmdPrint;
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

	internal virtual Button cmdReport {
		[CompilerGenerated]
		get {
			return _cmdReport;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdReport_Click;
			Button button = _cmdReport;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdReport = value;
			button = _cmdReport;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tipDiagrams")]
	internal virtual ToolTip tipDiagrams {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("rtfPrint")]
	internal virtual RichTextBox rtfPrint {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
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

	internal virtual ComboBox cboCombination {
		[CompilerGenerated]
		get {
			return _cboCombination;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboCombination_SelectedIndexChanged;
			ComboBox comboBox = _cboCombination;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboCombination = value;
			comboBox = _cboCombination;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox cboDirection {
		[CompilerGenerated]
		get {
			return _cboDirection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cboDirection_SelectedIndexChanged;
			ComboBox comboBox = _cboDirection;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboDirection = value;
			comboBox = _cboDirection;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	public frmDiagrams ()
	{
		base.Load += frmDiagrams_Load;
		base.Shown += frmDiagrams_Shown;
		base.Resize += frmDiagrams_Resize;
		base.KeyDown += frmDiagrams_KeyDown;
		base.HelpButtonClicked += frmDiagrams_HelpButtonClicked;
		base.MouseWheel += frmDiagrams_MouseWheel;
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
		this.components = new System.ComponentModel.Container ();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmDiagrams));
		this.picDiagrams = new System.Windows.Forms.PictureBox ();
		this.vsbDiagrams = new System.Windows.Forms.VScrollBar ();
		this.pnlDiagrams = new System.Windows.Forms.Panel ();
		this.cboDirection = new System.Windows.Forms.ComboBox ();
		this.cboCombination = new System.Windows.Forms.ComboBox ();
		this.cmdCopyImage = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.cmdReport = new System.Windows.Forms.Button ();
		this.cmdPrint = new System.Windows.Forms.Button ();
		this.lblComb = new System.Windows.Forms.Label ();
		this.tipDiagrams = new System.Windows.Forms.ToolTip (this.components);
		this.rtfPrint = new System.Windows.Forms.RichTextBox ();
		((System.ComponentModel.ISupportInitialize)this.picDiagrams).BeginInit ();
		this.pnlDiagrams.SuspendLayout ();
		base.SuspendLayout ();
		this.picDiagrams.BackColor = System.Drawing.SystemColors.Window;
		this.picDiagrams.Location = new System.Drawing.Point (0, 0);
		this.picDiagrams.Name = "picDiagrams";
		this.picDiagrams.Size = new System.Drawing.Size (480, 576);
		this.picDiagrams.TabIndex = 0;
		this.picDiagrams.TabStop = false;
		this.vsbDiagrams.Location = new System.Drawing.Point (483, 0);
		this.vsbDiagrams.Name = "vsbDiagrams";
		this.vsbDiagrams.Size = new System.Drawing.Size (15, 337);
		this.vsbDiagrams.TabIndex = 1;
		this.pnlDiagrams.Controls.Add (this.cboDirection);
		this.pnlDiagrams.Controls.Add (this.cboCombination);
		this.pnlDiagrams.Controls.Add (this.cmdCopyImage);
		this.pnlDiagrams.Controls.Add (this.cmdClose);
		this.pnlDiagrams.Controls.Add (this.cmdReport);
		this.pnlDiagrams.Controls.Add (this.cmdPrint);
		this.pnlDiagrams.Controls.Add (this.lblComb);
		this.pnlDiagrams.Location = new System.Drawing.Point (0, 340);
		this.pnlDiagrams.Name = "pnlDiagrams";
		this.pnlDiagrams.Size = new System.Drawing.Size (498, 71);
		this.pnlDiagrams.TabIndex = 2;
		this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDirection.FormattingEnabled = true;
		this.cboDirection.Location = new System.Drawing.Point (319, 8);
		this.cboDirection.Name = "cboDirection";
		this.cboDirection.Size = new System.Drawing.Size (87, 21);
		this.cboDirection.TabIndex = 11;
		this.cboCombination.DropDownHeight = 197;
		this.cboCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCombination.FormattingEnabled = true;
		this.cboCombination.IntegralHeight = false;
		this.cboCombination.Location = new System.Drawing.Point (104, 8);
		this.cboCombination.Name = "cboCombination";
		this.cboCombination.Size = new System.Drawing.Size (191, 21);
		this.cboCombination.TabIndex = 10;
		this.cmdCopyImage.Location = new System.Drawing.Point (120, 34);
		this.cmdCopyImage.Name = "cmdCopyImage";
		this.cmdCopyImage.Size = new System.Drawing.Size (75, 25);
		this.cmdCopyImage.TabIndex = 7;
		this.cmdCopyImage.Text = "Copy &Image";
		this.cmdCopyImage.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (320, 34);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (75, 25);
		this.cmdClose.TabIndex = 9;
		this.cmdClose.Text = "Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.cmdReport.Location = new System.Drawing.Point (220, 34);
		this.cmdReport.Name = "cmdReport";
		this.cmdReport.Size = new System.Drawing.Size (75, 25);
		this.cmdReport.TabIndex = 8;
		this.cmdReport.Text = "&Report";
		this.cmdReport.UseVisualStyleBackColor = true;
		this.cmdPrint.Location = new System.Drawing.Point (20, 34);
		this.cmdPrint.Name = "cmdPrint";
		this.cmdPrint.Size = new System.Drawing.Size (75, 25);
		this.cmdPrint.TabIndex = 6;
		this.cmdPrint.Text = "&Print...";
		this.cmdPrint.UseVisualStyleBackColor = true;
		this.lblComb.AutoSize = true;
		this.lblComb.Location = new System.Drawing.Point (26, 11);
		this.lblComb.Name = "lblComb";
		this.lblComb.Size = new System.Drawing.Size (65, 13);
		this.lblComb.TabIndex = 0;
		this.lblComb.Text = "Combination";
		this.rtfPrint.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rtfPrint.Location = new System.Drawing.Point (495, 455);
		this.rtfPrint.Name = "rtfPrint";
		this.rtfPrint.Size = new System.Drawing.Size (128, 64);
		this.rtfPrint.TabIndex = 3;
		this.rtfPrint.Text = "";
		this.rtfPrint.Visible = false;
		base.AcceptButton = this.cmdClose;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (560, 521);
		base.Controls.Add (this.pnlDiagrams);
		base.Controls.Add (this.vsbDiagrams);
		base.Controls.Add (this.picDiagrams);
		base.Controls.Add (this.rtfPrint);
		base.HelpButton = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmDiagrams";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Diagrams";
		((System.ComponentModel.ISupportInitialize)this.picDiagrams).EndInit ();
		this.pnlDiagrams.ResumeLayout (false);
		this.pnlDiagrams.PerformLayout ();
		base.ResumeLayout (false);
	}

	private void frmDiagrams_Load (object sender, EventArgs e)
	{
		vsbDiagrams.Left = picDiagrams.Width;
		pnlDiagrams.Top = vsbDiagrams.Height;
		checked {
			pnlDiagrams.Width = picDiagrams.Width + vsbDiagrams.Width;
			blnCodeChange = true;
			base.Width = picDiagrams.Width + vsbDiagrams.Width + base.Width - base.ClientSize.Width;
			base.Height = vsbDiagrams.Height + pnlDiagrams.Height + base.Height - base.ClientSize.Height;
			MinimumSize = new Size (base.Width, pnlDiagrams.Height + 4 * vsbDiagrams.Width + base.Height - base.ClientSize.Height);
			MaximumSize = new Size (base.Width, pnlDiagrams.Height + picDiagrams.Height + base.Height - base.ClientSize.Height);
			blnCodeChange = false;
			Text = "Diagrams: " + CFSInterface.GetFileName (CFS.Analyses [CFS.intAnlNow].Filename);
			cboCombination.Items.Clear ();
			cboCombination.Items.Add ("Envelope of all combinations");
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			int nComb = analysis.nComb;
			for (int i = 1; i <= nComb; i++) {
				cboCombination.Items.Add (analysis.Comb [i].Description);
			}
			cboCombination.SelectedIndex = analysis.iComb;
			iCombPrev = analysis.iComb;
			analysis = null;
			cboDirection.Items.Clear ();
			cboDirection.Items.Add ("Y Direction");
			cboDirection.Items.Add ("X Direction");
			if (CFS.intLicenseType != 0) {
				cboDirection.Items.Add ("Torsion");
			}
			blnTorsionCalc = false;
			DiagramGraphics = new GraphicsX (picDiagrams);
		}
	}

	private void frmDiagrams_Shown (object sender, EventArgs e)
	{
		cboDirection.SelectedIndex = 0;
	}

	private void frmDiagrams_Resize (object sender, EventArgs e)
	{
		if (blnCodeChange || base.WindowState == FormWindowState.Minimized) {
			return;
		}
		blnCodeChange = true;
		checked {
			short num = (short)(base.ClientSize.Height - pnlDiagrams.Height);
			if (num > picDiagrams.Height) {
				num = (short)picDiagrams.Height;
			}
			vsbDiagrams.Left = picDiagrams.Width;
			vsbDiagrams.Height = num;
			pnlDiagrams.Top = num;
			pnlDiagrams.Width = picDiagrams.Width + vsbDiagrams.Width;
			if (picDiagrams.Height > num) {
				vsbDiagrams.Maximum = picDiagrams.Height;
				vsbDiagrams.LargeChange = num;
				vsbDiagrams.SmallChange = 20;
				if (vsbDiagrams.Value > picDiagrams.Height - num) {
					vsbDiagrams.Value = picDiagrams.Height - num;
				}
				vsbDiagrams.Enabled = true;
			} else {
				vsbDiagrams.Value = 0;
				vsbDiagrams.Enabled = false;
			}
			picDiagrams.Top = -vsbDiagrams.Value;
			blnCodeChange = false;
		}
	}

	private void frmDiagrams_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "analysis-diagrams.htm");
			e.Handled = true;
		}
	}

	private void frmDiagrams_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		if (cboDirection.SelectedIndex == 2) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "torsion-diagrams.htm");
		} else {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "analysis-diagrams.htm");
		}
		e.Cancel = true;
	}

	private void vsbDiagrams_ValueChanged (object sender, EventArgs e)
	{
		picDiagrams.Top = checked(-vsbDiagrams.Value);
	}

	private void frmDiagrams_MouseWheel (object sender, MouseEventArgs e)
	{
		checked {
			if (e.Delta >= 30) {
				int num = vsbDiagrams.Value - vsbDiagrams.SmallChange;
				if (num < 0) {
					num = 0;
				}
				vsbDiagrams.Value = num;
			} else if (e.Delta <= -30) {
				int num = vsbDiagrams.Value + vsbDiagrams.SmallChange;
				if (num > vsbDiagrams.Maximum - vsbDiagrams.LargeChange) {
					num = vsbDiagrams.Maximum - vsbDiagrams.LargeChange;
				}
				vsbDiagrams.Value = num;
			}
		}
	}

	private void cboCombination_SelectedIndexChanged (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!base.Visible) {
			return;
		}
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		checked {
			if (cboCombination.SelectedIndex > 0) {
				analysis.iComb = (byte)cboCombination.SelectedIndex;
				analysis.Analyze (ref strMsg);
				if (Strings.Len (strMsg) != 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
				blnTorsionCalc = false;
			}
			short selectedIndex = (short)cboDirection.SelectedIndex;
			cboDirection.SelectedIndex = -1;
			cboDirection.SelectedIndex = selectedIndex;
			analysis = null;
		}
	}

	private void cboDirection_SelectedIndexChanged (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!base.Visible) {
			return;
		}
		int selectedIndex = cboDirection.SelectedIndex;
		if (selectedIndex < 0) {
			return;
		}
		short num = default(short);
		switch (selectedIndex) {
		case 0:
			num = 1;
			break;
		case 1:
			num = 2;
			break;
		case 2:
			num = 4;
			break;
		}
		Cursor.Current = Cursors.WaitCursor;
		if (num == 4) {
			if (cboCombination.SelectedIndex == 0) {
				if (CFS.Analyses [CFS.intAnlNow].iCombSol > 0 && !PlotTorsionEnvelopes (CFS.Analyses [CFS.intAnlNow])) {
					CFS.Analyses [CFS.intAnlNow].iCombSol = 0;
					blnTorsionCalc = false;
					PlotTorsionDiagrams (CFS.Analyses [CFS.intAnlNow]);
				}
			} else {
				if ((CFS.Analyses [CFS.intAnlNow].iCombSol > 0) & !blnTorsionCalc) {
					CFS.Analyses [CFS.intAnlNow].AnalyzeTorsion (ref strMsg);
					if (strMsg.Length > 0) {
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					} else {
						blnTorsionCalc = true;
					}
				}
				PlotTorsionDiagrams (CFS.Analyses [CFS.intAnlNow]);
			}
		} else if (cboCombination.SelectedIndex == 0) {
			if (!PlotEnvelopes (CFS.Analyses [CFS.intAnlNow], num)) {
				CFS.Analyses [CFS.intAnlNow].iCombSol = 0;
				PlotDiagrams (CFS.Analyses [CFS.intAnlNow], num);
			}
		} else {
			PlotDiagrams (CFS.Analyses [CFS.intAnlNow], num);
		}
		Cursor.Current = Cursors.Default;
	}

	private void cmdPrint_Click (object sender, EventArgs e)
	{
		switch (cboDirection.SelectedIndex) {
		case 0:
			PrintRoutines.PrintDiagrams (1, cboCombination.SelectedIndex == 0);
			break;
		case 1:
			PrintRoutines.PrintDiagrams (2, cboCombination.SelectedIndex == 0);
			break;
		case 2:
			PrintRoutines.PrintDiagrams (4, cboCombination.SelectedIndex == 0);
			break;
		}
	}

	private void cmdReport_Click (object sender, EventArgs e)
	{
		Hide ();
		short num = default(short);
		switch (cboDirection.SelectedIndex) {
		case 0:
			num = 1;
			break;
		case 1:
			num = 2;
			break;
		case 2:
			num = 4;
			break;
		}
		if (num == 4) {
			if (cboCombination.SelectedIndex == 0) {
				Report.rptTorsionEnvelopes (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow]);
			} else {
				Report.rptTorsionDiagrams (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow]);
			}
		} else if (cboCombination.SelectedIndex == 0) {
			Report.rptEnvelopes (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow], num);
		} else {
			Report.rptDiagrams (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow], num);
		}
		My.MyProject.Forms.frmReportDialog.Tag = "2";
		My.MyProject.Forms.frmReportDialog.ShowDialog (this);
		My.MyProject.Forms.frmReportDialog.Dispose ();
		Close ();
	}

	private void cmdCopyImage_Click (object sender, EventArgs e)
	{
		DataObject dataObject = new DataObject ();
		dataObject.SetData (DataFormats.Bitmap, picDiagrams.Image);
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

	private void cmdClose_Click (object sender, EventArgs e)
	{
		CFS.Analyses [CFS.intAnlNow].iComb = checked((byte)iCombPrev);
		Close ();
	}

	private void PlotDiagrams (Analysis Analysis1, short iDir)
	{
		SolutionDetail Det = default(SolutionDetail);
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		Analysis analysis = Analysis1;
		bool flag = false;
		if (analysis.iCombSol == analysis.iComb && analysis.Sol [iDir].nLoad > 0) {
			flag = true;
		}
		cmdPrint.Enabled = flag;
		cmdCopyImage.Enabled = flag;
		cmdReport.Enabled = flag;
		float num7;
		checked {
			float num2 = default(float);
			if (flag) {
				analysis.Sol [iDir].MinimaMaxima (ref Det);
				analysis.Rmax = 0f;
				short nNode = analysis.Sol [iDir].nNode;
				for (short num = 1; num <= nNode; num = (short)unchecked(num + 1)) {
					if (analysis.Sol [iDir].D [num] == 0f) {
						num2 = 0f;
						if (num < analysis.Sol [iDir].nNode) {
							num2 += analysis.Sol [iDir].V [num, 1];
						}
						if (num > 1) {
							num2 += analysis.Sol [iDir].V [num - 1, 2];
						}
						if (Math.Abs (num2) > analysis.Rmax) {
							analysis.Rmax = Math.Abs (num2);
						}
					}
				}
				analysis.Vmax = 0f;
				int nV = Det.NV;
				for (int i = 1; i <= nV; i++) {
					if (Math.Abs (Det.V [i]) > analysis.Vmax) {
						analysis.Vmax = Math.Abs (Det.V [i]);
					}
				}
				analysis.Mmax = 0f;
				int nM = Det.NM;
				for (int j = 1; j <= nM; j++) {
					if (Math.Abs (Det.M [j]) > analysis.Mmax) {
						analysis.Mmax = Math.Abs (Det.M [j]);
					}
				}
				analysis.Dmax = 0f;
				int nD = Det.ND;
				for (int k = 1; k <= nD; k++) {
					if (Math.Abs (Det.D [k]) > analysis.Dmax) {
						analysis.Dmax = Math.Abs (Det.D [k]);
					}
				}
				if (analysis.Rmax == 0f) {
					analysis.Rmax = 1f;
				}
				if (analysis.Vmax == 0f) {
					analysis.Vmax = 1f;
				}
				if (analysis.Mmax == 0f) {
					analysis.Mmax = 1f;
				}
				if (analysis.Dmax == 0f) {
					analysis.Dmax = 1f;
				}
			}
			DiagramGraphics.Graphics.Clear (picDiagrams.BackColor);
			float num3 = analysis.Zmax - analysis.Zmin;
			DiagramGraphics.Scale (analysis.Zmin - 0.15f * num3 / 0.75f, 8f, analysis.Zmax + 0.1f * num3 / 0.75f, 0f);
			pen.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
			float num4 = num3 / 96f;
			float num5 = num4 * Math.Abs (DiagramGraphics.Width / DiagramGraphics.ScaleWidth) / Math.Abs (DiagramGraphics.Height / DiagramGraphics.ScaleHeight);
			short num6 = (short)Math.Round (0.75f * (float)picDiagrams.ClientSize.Width);
			num7 = (float)((double)analysis.Zmin - 0.075000002980232239 * (double)num3 / 0.75);
			analysis.Vdiag = new float[num6 + 1];
			analysis.Mdiag = new float[num6 + 1];
			analysis.Ddiag = new float[num6 + 1];
			analysis.Zdiag = new float[num6 + 1];
			analysis.YRbase = 7f;
			DiagramGraphics.DrawString ("Reaction", font, brush, num7, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			if (flag) {
				short nNode2 = analysis.Sol [iDir].nNode;
				for (short num = 1; num <= nNode2; num = (short)unchecked(num + 1)) {
					if (analysis.Sol [iDir].D [num] == 0f) {
						num2 = analysis.Sol [iDir].V [num, 1];
						if (num > 1) {
							num2 += analysis.Sol [iDir].V [num - 1, 2];
						}
						if ((double)Math.Abs (num2) > 0.01 * (double)analysis.Rmax) {
							float num8 = analysis.Sol [iDir].Znode [num];
							float y = analysis.YRbase - 0.75f * num2 / analysis.Rmax;
							string s = Units.DisplayForce (num2, 0, blnShowUnit: false, "", 0, 0);
							DiagramGraphics.Graphics.DrawLine (pen, num8, analysis.YRbase, num8, y);
							if (num2 > 0f) {
								DiagramGraphics.DrawString (s, font2, brush, num8, y, GraphicsX.AlignText.CenterTop, 0f);
								DiagramGraphics.Graphics.DrawLine (pen, num8, analysis.YRbase, num8 - num4, analysis.YRbase - num5);
								DiagramGraphics.Graphics.DrawLine (pen, num8, analysis.YRbase, num8 + num4, analysis.YRbase - num5);
							} else {
								DiagramGraphics.DrawString (s, font2, brush, num8, y, GraphicsX.AlignText.CenterBottom, 0f);
								DiagramGraphics.Graphics.DrawLine (pen, num8, analysis.YRbase, num8 - num4, analysis.YRbase + num5);
								DiagramGraphics.Graphics.DrawLine (pen, num8, analysis.YRbase, num8 + num4, analysis.YRbase + num5);
							}
						}
					}
				}
			}
			analysis.YVbase = 5f;
			float y2 = analysis.YVbase;
			analysis.YMbase = 3f;
			float y3 = analysis.YMbase;
			analysis.YDbase = 1f;
			float yDbase = analysis.YDbase;
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			float x = analysis.Zmin;
			if (flag) {
				Solution solution = analysis.Sol [iDir];
				yDbase = Analysis1.YDbase + 0.75f / Analysis1.Dmax * solution.D [1];
				float num9 = (float)(1E-06 * (double)(solution.Znode [solution.nNode] - solution.Znode [1]) / (double)solution.nSeg);
				short num = 0;
				short num10 = 0;
				short nSeg = solution.nSeg;
				float num12 = default(float);
				float num15 = default(float);
				float num14 = default(float);
				float num13 = default(float);
				for (short num11 = 1; num11 <= nSeg; num11 = (short)unchecked(num11 + 1)) {
					if (solution.Seg [num11].Z == solution.Znode [num + 1]) {
						num = (short)(num + 1);
						num12 = solution.D [num];
						num2 = solution.R [num];
						num13 = solution.M [num];
						num14 = solution.V [num, 1];
						num15 = solution.EI [num];
					}
					float num16 = solution.Seg [num11 + 1].Z - solution.Seg [num11].Z;
					float num17 = num16 * num16;
					float num18 = num17 * num16;
					float num19 = num17 * num17;
					float num20 = num18 * num17;
					float w = solution.Seg [num11].W0;
					float num21 = (solution.Seg [num11].W1 - w) / num16;
					num14 += solution.Seg [num11].P0;
					num13 += solution.Seg [num11].M0;
					while (true) {
						float num8 = solution.Znode [1] + num3 * (float)num10 / (float)num6;
						float num22 = num8 - solution.Seg [num11].Z;
						if (num22 > num16 + num9) {
							break;
						}
						float num23 = num22 * num22;
						float num24 = num23 * num22;
						float num25 = num23 * num23;
						float num26 = num24 * num23;
						Analysis1.Zdiag [num10] = num8;
						Analysis1.Vdiag [num10] = num14 + w * num22 + num21 * num23 / 2f;
						Analysis1.Mdiag [num10] = num13 + num14 * num22 + w * num23 / 2f + num21 * num24 / 6f;
						Analysis1.Ddiag [num10] = num12 + num2 * num22 + (num13 * num23 / 2f + num14 * num24 / 6f + w * num25 / 24f + num21 * num26 / 120f) / num15;
						float y = Analysis1.YVbase + 0.75f / Analysis1.Vmax * (num14 + w * num22 + num21 * num23 / 2f);
						DiagramGraphics.Graphics.DrawLine (pen, x, y2, num8, y);
						y2 = y;
						y = Analysis1.YMbase + 0.75f / Analysis1.Mmax * (num13 + num14 * num22 + w * num23 / 2f + num21 * num24 / 6f);
						DiagramGraphics.Graphics.DrawLine (pen, x, y3, num8, y);
						y3 = y;
						y = Analysis1.YDbase + 0.75f / Analysis1.Dmax * (num12 + num2 * num22 + (num13 * num23 / 2f + num14 * num24 / 6f + w * num25 / 24f + num21 * num26 / 120f) / num15);
						DiagramGraphics.Graphics.DrawLine (pen, x, yDbase, num8, y);
						yDbase = y;
						x = num8;
						num10 = (short)(num10 + 1);
					}
					num12 += num2 * num16 + (num13 * num17 / 2f + num14 * num18 / 6f + w * num19 / 24f + num21 * num20 / 120f) / num15;
					num2 += (num13 * num16 + num14 * num17 / 2f + w * num18 / 6f + num21 * num19 / 24f) / num15;
					num13 += num14 * num16 + w * num17 / 2f + num21 * num18 / 6f;
					num14 += w * num16 + num21 * num17 / 2f;
					w += num21 * num16;
				}
				solution = null;
				DiagramGraphics.Graphics.DrawLine (pen, x, y2, analysis.Zmax, analysis.YVbase);
				DiagramGraphics.Graphics.DrawLine (pen, x, y3, analysis.Zmax, analysis.YMbase);
			}
			DiagramGraphics.DrawString ("Shear", font, brush, num7, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
		}
		if (flag) {
			int nV2 = Det.NV;
			for (int l = 1; l <= nV2; l = checked(l + 1)) {
				float num14 = Det.V [l];
				if ((double)Math.Abs (num14) > 0.01 * (double)analysis.Vmax) {
					string s = Units.DisplayForce (num14, 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(num14 > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZV [l], analysis.YVbase + 0.75f * num14 / analysis.Vmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		DiagramGraphics.DrawString ("Moment", font, brush, num7, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
		DiagramGraphics.DrawString ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")");
		if (flag) {
			int nM2 = Det.NM;
			for (int m = 1; m <= nM2; m = checked(m + 1)) {
				float num13 = Det.M [m];
				if ((double)Math.Abs (num13) > 0.01 * (double)analysis.Mmax) {
					string s = Units.DisplayMoment (num13, 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(num13 > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZM [m], analysis.YMbase + 0.75f * num13 / analysis.Mmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		DiagramGraphics.DrawString ("Deflection", font, brush, num7, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
		DiagramGraphics.DrawString ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")");
		if (flag) {
			int nD2 = Det.ND;
			for (int n = 1; n <= nD2; n = checked(n + 1)) {
				float num12 = Det.D [n];
				if ((double)Math.Abs (num12) > 0.01 * (double)analysis.Dmax) {
					string s = Units.DisplayLen1 (num12, 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(num12 > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZD [n], analysis.YDbase + 0.75f * num12 / analysis.Dmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		analysis = null;
		DiagramGraphics.PreserveImage ();
	}

	private bool PlotEnvelopes (Analysis Analysis1, short iDir)
	{
		SolutionDetail Det = default(SolutionDetail);
		string strMsg = string.Empty;
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		Pen pen2 = new Pen (Color.Gray, 0f);
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		bool result = false;
		cmdPrint.Enabled = false;
		cmdCopyImage.Enabled = false;
		cmdReport.Enabled = false;
		Analysis analysis = Analysis1;
		DiagramGraphics.Graphics.Clear (picDiagrams.BackColor);
		float num = analysis.Zmax - analysis.Zmin;
		DiagramGraphics.Scale ((float)((double)analysis.Zmin - 0.15 * (double)num / 0.75), 8f, (float)((double)analysis.Zmax + 0.1 * (double)num / 0.75), 0f);
		pen.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
		pen2.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
		float num2 = num / 96f;
		float num3 = num2 * Math.Abs (DiagramGraphics.Width / DiagramGraphics.ScaleWidth) / Math.Abs (DiagramGraphics.Height / DiagramGraphics.ScaleHeight);
		checked {
			short num4 = (short)Math.Round (0.75 * (double)picDiagrams.ClientSize.Width);
			float num5 = (float)((double)analysis.Zmin - 0.075 * (double)num / 0.75);
			analysis.Rdiag = new float[num4 + 1];
			analysis.Vdiag = new float[num4 + 1];
			analysis.Mdiag = new float[num4 + 1];
			analysis.Ddiag = new float[num4 + 1];
			analysis.Zdiag = new float[num4 + 1];
			analysis.Rdiag2 = new float[num4 + 1];
			analysis.Vdiag2 = new float[num4 + 1];
			analysis.Mdiag2 = new float[num4 + 1];
			analysis.Ddiag2 = new float[num4 + 1];
			analysis.YRbase = 7f;
			DiagramGraphics.DrawString ("Reaction", font, brush, num5, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			analysis.YVbase = 5f;
			DiagramGraphics.DrawString ("Shear", font, brush, num5, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			analysis.YMbase = 3f;
			DiagramGraphics.DrawString ("Moment", font, brush, num5, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")");
			analysis.YDbase = 1f;
			DiagramGraphics.DrawString ("Deflection", font, brush, num5, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")");
			short iComb = analysis.iComb;
			analysis.Rmax = 0f;
			analysis.Vmax = 0f;
			analysis.Mmax = 0f;
			analysis.Dmax = 0f;
			short nComb = analysis.nComb;
			short num6 = 1;
			float num8 = default(float);
			float num12 = default(float);
			float num15 = default(float);
			float num14 = default(float);
			float num13 = default(float);
			while (true) {
				if (num6 <= nComb) {
					analysis.iComb = (byte)num6;
					analysis.Analyze (ref strMsg);
					if (Strings.Len (strMsg) != 0) {
						strMsg = "Combination " + Conversions.ToString (unchecked((int)num6)) + ": " + analysis.Comb [num6].Description + "\r\n" + strMsg;
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					}
					if (analysis.iCombSol == 0) {
						analysis.iComb = (byte)iComb;
						analysis.Analyze (ref strMsg);
						Cursor.Current = Cursors.Default;
						break;
					}
					analysis.Sol [iDir].MinimaMaxima (ref Det);
					short nNode = analysis.Sol [iDir].nNode;
					for (short num7 = 1; num7 <= nNode; num7 = (short)unchecked(num7 + 1)) {
						if (analysis.Sol [iDir].D [num7] == 0f) {
							num8 = 0f;
							if (num7 < analysis.Sol [iDir].nNode) {
								num8 += analysis.Sol [iDir].V [num7, 1];
							}
							if (num7 > 1) {
								num8 += analysis.Sol [iDir].V [num7 - 1, 2];
							}
							if (Math.Abs (num8) > analysis.Rmax) {
								analysis.Rmax = Math.Abs (num8);
							}
							short num9 = (short)Math.Round ((analysis.Sol [iDir].Znode [num7] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
							if (num8 > analysis.Rdiag [num9]) {
								analysis.Rdiag [num9] = num8;
							}
							if (num8 < analysis.Rdiag2 [num9]) {
								analysis.Rdiag2 [num9] = num8;
							}
						}
					}
					int nV = Det.NV;
					for (int i = 1; i <= nV; i++) {
						if (Math.Abs (Det.V [i]) > analysis.Vmax) {
							analysis.Vmax = Math.Abs (Det.V [i]);
						}
						short num9 = (short)Math.Round ((Det.ZV [i] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.V [i] > analysis.Vdiag [num9]) {
							analysis.Vdiag [num9] = Det.V [i];
						}
						if (Det.V [i] < analysis.Vdiag2 [num9]) {
							analysis.Vdiag2 [num9] = Det.V [i];
						}
					}
					int nM = Det.NM;
					for (int j = 1; j <= nM; j++) {
						if (Math.Abs (Det.M [j]) > analysis.Mmax) {
							analysis.Mmax = Math.Abs (Det.M [j]);
						}
						short num9 = (short)Math.Round ((Det.ZM [j] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.M [j] > analysis.Mdiag [num9]) {
							analysis.Mdiag [num9] = Det.M [j];
						}
						if (Det.M [j] < analysis.Mdiag2 [num9]) {
							analysis.Mdiag2 [num9] = Det.M [j];
						}
					}
					int nD = Det.ND;
					for (int k = 1; k <= nD; k++) {
						if (Math.Abs (Det.D [k]) > analysis.Dmax) {
							analysis.Dmax = Math.Abs (Det.D [k]);
						}
						short num9 = (short)Math.Round ((Det.ZD [k] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.D [k] > analysis.Ddiag [num9]) {
							analysis.Ddiag [num9] = Det.D [k];
						}
						if (Det.D [k] < analysis.Ddiag2 [num9]) {
							analysis.Ddiag2 [num9] = Det.D [k];
						}
					}
					if (analysis.Sol [iDir].nLoad > 0) {
						Solution solution = analysis.Sol [iDir];
						_ = (float)((double)Analysis1.YDbase + 0.75 / (double)Analysis1.Dmax * (double)solution.D [1]);
						float num10 = (float)(1E-06 * (double)(solution.Znode [solution.nNode] - solution.Znode [1]) / (double)solution.nSeg);
						short num7 = 0;
						short num9 = 0;
						short nSeg = solution.nSeg;
						for (short num11 = 1; num11 <= nSeg; num11 = (short)unchecked(num11 + 1)) {
							if (solution.Seg [num11].Z == solution.Znode [num7 + 1]) {
								num7 = (short)(num7 + 1);
								num12 = solution.D [num7];
								num8 = solution.R [num7];
								num13 = solution.M [num7];
								num14 = solution.V [num7, 1];
								num15 = solution.EI [num7];
							}
							float num16 = solution.Seg [num11 + 1].Z - solution.Seg [num11].Z;
							float num17 = num16 * num16;
							float num18 = num17 * num16;
							float num19 = num17 * num17;
							float num20 = num18 * num17;
							float w = solution.Seg [num11].W0;
							float num21 = (solution.Seg [num11].W1 - w) / num16;
							num14 += solution.Seg [num11].P0;
							num13 += solution.Seg [num11].M0;
							while (true) {
								float num22 = solution.Znode [1] + num * (float)num9 / (float)num4;
								float num23 = num22 - solution.Seg [num11].Z;
								if (num23 > num16 + num10) {
									break;
								}
								float num24 = num23 * num23;
								float num25 = num24 * num23;
								float num26 = num24 * num24;
								float num27 = num25 * num24;
								Analysis1.Zdiag [num9] = num22;
								float num28 = num14 + w * num23 + num21 * num24 / 2f;
								if (num28 > Analysis1.Vdiag [num9]) {
									Analysis1.Vdiag [num9] = num28;
								}
								if (num28 < Analysis1.Vdiag2 [num9]) {
									Analysis1.Vdiag2 [num9] = num28;
								}
								float num29 = num13 + num14 * num23 + w * num24 / 2f + num21 * num25 / 6f;
								if (num29 > Analysis1.Mdiag [num9]) {
									Analysis1.Mdiag [num9] = num29;
								}
								if (num29 < Analysis1.Mdiag2 [num9]) {
									Analysis1.Mdiag2 [num9] = num29;
								}
								float num30 = num12 + num8 * num23 + (num13 * num24 / 2f + num14 * num25 / 6f + w * num26 / 24f + num21 * num27 / 120f) / num15;
								if (num30 > Analysis1.Ddiag [num9]) {
									Analysis1.Ddiag [num9] = num30;
								}
								if (num30 < Analysis1.Ddiag2 [num9]) {
									Analysis1.Ddiag2 [num9] = num30;
								}
								num9 = (short)(num9 + 1);
							}
							num12 += num8 * num16 + (num13 * num17 / 2f + num14 * num18 / 6f + w * num19 / 24f + num21 * num20 / 120f) / num15;
							num8 += (num13 * num16 + num14 * num17 / 2f + w * num18 / 6f + num21 * num19 / 24f) / num15;
							num13 += num14 * num16 + w * num17 / 2f + num21 * num18 / 6f;
							num14 += w * num16 + num21 * num17 / 2f;
							w += num21 * num16;
						}
						solution = null;
					}
					num6 = (short)unchecked(num6 + 1);
					continue;
				}
				if (analysis.Rmax == 0f) {
					analysis.Rmax = 1f;
				}
				if (analysis.Vmax == 0f) {
					analysis.Vmax = 1f;
				}
				if (analysis.Mmax == 0f) {
					analysis.Mmax = 1f;
				}
				if (analysis.Dmax == 0f) {
					analysis.Dmax = 1f;
				}
				analysis.iComb = (byte)iComb;
				analysis.Analyze (ref strMsg);
				short num31 = (short)Information.LBound (analysis.Zdiag);
				short num32 = (short)Information.UBound (analysis.Zdiag);
				for (short num9 = num31; num9 <= num32; num9 = (short)unchecked(num9 + 1)) {
					float num22 = analysis.Zdiag [num9];
					float y = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YVbase, num22, y);
					y = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag2 [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YVbase, num22, y);
					y = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YMbase, num22, y);
					y = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag2 [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YMbase, num22, y);
					y = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YDbase, num22, y);
					y = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag2 [num9]);
					DiagramGraphics.Graphics.DrawLine (pen2, num22, analysis.YDbase, num22, y);
				}
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
				short num33 = num4;
				for (short num9 = 0; num9 <= num33; num9 = (short)unchecked(num9 + 1)) {
					float num22 = analysis.Zdiag [num9];
					if ((double)analysis.Rdiag [num9] > 0.01 * (double)analysis.Rmax) {
						float y = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag [num9] / (double)analysis.Rmax);
						string s = Units.DisplayForce (analysis.Rdiag [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, y, GraphicsX.AlignText.CenterTop, 0f);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22, y);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22 - num2, analysis.YRbase - num3);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22 + num2, analysis.YRbase - num3);
					}
					if ((double)analysis.Rdiag2 [num9] < -0.01 * (double)analysis.Rmax) {
						float y = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag2 [num9] / (double)analysis.Rmax);
						string s = Units.DisplayForce (analysis.Rdiag2 [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, y, GraphicsX.AlignText.CenterBottom, 0f);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22, y);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22 - num2, analysis.YRbase + num3);
						DiagramGraphics.Graphics.DrawLine (pen, num22, analysis.YRbase, num22 + num2, analysis.YRbase + num3);
					}
					if ((num9 == 0 || analysis.Vdiag [num9] > analysis.Vdiag [num9 - 1]) & (num9 == num4 || analysis.Vdiag [num9] > analysis.Vdiag [num9 + 1]) & ((double)analysis.Vdiag [num9] > 0.01 * (double)analysis.Vmax)) {
						string s = Units.DisplayForce (analysis.Vdiag [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag [num9] / (double)analysis.Vmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num9 == 0 || analysis.Vdiag2 [num9] < analysis.Vdiag2 [num9 - 1]) & (num9 == num4 || analysis.Vdiag2 [num9] < analysis.Vdiag2 [num9 + 1]) & ((double)analysis.Vdiag2 [num9] < -0.01 * (double)analysis.Vmax)) {
						string s = Units.DisplayForce (analysis.Vdiag2 [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag2 [num9] / (double)analysis.Vmax), GraphicsX.AlignText.CenterTop, 0f);
					}
					if ((num9 == 0 || analysis.Mdiag [num9] > analysis.Mdiag [num9 - 1]) & (num9 == num4 || analysis.Mdiag [num9] > analysis.Mdiag [num9 + 1]) & ((double)analysis.Mdiag [num9] > 0.01 * (double)analysis.Mmax)) {
						string s = Units.DisplayMoment (analysis.Mdiag [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag [num9] / (double)analysis.Mmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num9 == 0 || analysis.Mdiag2 [num9] < analysis.Mdiag2 [num9 - 1]) & (num9 == num4 || analysis.Mdiag2 [num9] < analysis.Mdiag2 [num9 + 1]) & ((double)analysis.Mdiag2 [num9] < -0.01 * (double)analysis.Mmax)) {
						string s = Units.DisplayMoment (analysis.Mdiag2 [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag2 [num9] / (double)analysis.Mmax), GraphicsX.AlignText.CenterTop, 0f);
					}
					if ((num9 == 0 || analysis.Ddiag [num9] > analysis.Ddiag [num9 - 1]) & (num9 == num4 || analysis.Ddiag [num9] > analysis.Ddiag [num9 + 1]) & ((double)analysis.Ddiag [num9] > 0.01 * (double)analysis.Dmax)) {
						string s = Units.DisplayLen1 (analysis.Ddiag [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag [num9] / (double)analysis.Dmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num9 == 0 || analysis.Ddiag2 [num9] < analysis.Ddiag2 [num9 - 1]) & (num9 == num4 || analysis.Ddiag2 [num9] < analysis.Ddiag2 [num9 + 1]) & ((double)analysis.Ddiag2 [num9] < -0.01 * (double)analysis.Dmax)) {
						string s = Units.DisplayLen1 (analysis.Ddiag2 [num9], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num22, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag2 [num9] / (double)analysis.Dmax), GraphicsX.AlignText.CenterTop, 0f);
					}
				}
				analysis = null;
				DiagramGraphics.PreserveImage ();
				result = true;
				cmdPrint.Enabled = true;
				cmdCopyImage.Enabled = true;
				cmdReport.Enabled = true;
				break;
			}
			return result;
		}
	}

	private void PlotTorsionDiagrams (Analysis Analysis1)
	{
		SolutionDetail Det = default(SolutionDetail);
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		Pen pen2 = new Pen (Color.Gray, 0f);
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		cmdPrint.Enabled = blnTorsionCalc;
		cmdCopyImage.Enabled = blnTorsionCalc;
		cmdReport.Enabled = blnTorsionCalc;
		Analysis analysis = Analysis1;
		float num5;
		checked {
			if (blnTorsionCalc) {
				analysis.TorsionMinMax (ref Det);
				analysis.Rmax = 0f;
				analysis.Vmax = 0f;
				analysis.Mmax = 0f;
				analysis.Dmax = 0f;
				int nR = Det.NR;
				for (int i = 1; i <= nR; i++) {
					if (Math.Abs (Det.R [i]) > analysis.Rmax) {
						analysis.Rmax = Math.Abs (Det.R [i]);
					}
				}
				int nV = Det.NV;
				for (int j = 1; j <= nV; j++) {
					if (Math.Abs (Det.V [j]) > analysis.Vmax) {
						analysis.Vmax = Math.Abs (Det.V [j]);
					}
				}
				int nM = Det.NM;
				for (int k = 1; k <= nM; k++) {
					if (Math.Abs (Det.M [k]) > analysis.Mmax) {
						analysis.Mmax = Math.Abs (Det.M [k]);
					}
				}
				int nD = Det.ND;
				for (int l = 1; l <= nD; l++) {
					if (Math.Abs (Det.D [l]) > analysis.Dmax) {
						analysis.Dmax = Math.Abs (Det.D [l]);
					}
				}
				if (analysis.Rmax == 0f) {
					analysis.Rmax = 1f;
				}
				if (analysis.Vmax == 0f) {
					analysis.Vmax = 1f;
				}
				if (analysis.Mmax == 0f) {
					analysis.Mmax = 1f;
				}
				if (analysis.Dmax == 0f) {
					analysis.Dmax = 1f;
				}
			}
			DiagramGraphics.Graphics.Clear (picDiagrams.BackColor);
			float num = analysis.Zmax - analysis.Zmin;
			DiagramGraphics.Scale (analysis.Zmin - 0.15f * num / 0.75f, 8f, analysis.Zmax + 0.1f * num / 0.75f, 0f);
			pen.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
			pen2.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
			float num2 = num / 96f;
			float num3 = num2 * Math.Abs (DiagramGraphics.Width / DiagramGraphics.ScaleWidth) / Math.Abs (DiagramGraphics.Height / DiagramGraphics.ScaleHeight);
			short num4 = (short)Math.Round (0.75f * (float)picDiagrams.ClientSize.Width);
			num5 = (float)((double)analysis.Zmin - 0.075000002980232239 * (double)num / 0.75);
			analysis.Vdiag = new float[num4 + 1];
			analysis.Mdiag = new float[num4 + 1];
			analysis.Ddiag = new float[num4 + 1];
			analysis.Zdiag = new float[num4 + 1];
			analysis.YRbase = 7f;
			analysis.YVbase = 5f;
			float num6 = analysis.YVbase;
			float y = num6;
			analysis.YMbase = 3f;
			float y2 = analysis.YMbase;
			analysis.YDbase = 1f;
			float yDbase = analysis.YDbase;
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			DiagramGraphics.DrawString ("Reaction", font, brush, num5, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			if (blnTorsionCalc) {
				int nR2 = Det.NR;
				for (int m = 1; m <= nR2; m++) {
					float num7 = Det.ZR [m];
					float y3 = analysis.YRbase - 0.75f * Det.R [m] / analysis.Rmax;
					string s = Units.DisplayTorque (Det.R [m], 0, blnShowUnit: false, "", 0, 0);
					if ((double)Math.Abs (Det.R [m]) > 0.01 * (double)analysis.Rmax) {
						DiagramGraphics.Graphics.DrawLine (pen, num7, analysis.YRbase, num7, y3);
						if (Det.R [m] > 0f) {
							DiagramGraphics.DrawString (s, font2, brush, num7, y3, GraphicsX.AlignText.CenterTop, 0f);
							DiagramGraphics.Graphics.DrawLine (pen, num7, analysis.YRbase, num7 - num2, analysis.YRbase - num3);
							DiagramGraphics.Graphics.DrawLine (pen, num7, analysis.YRbase, num7 + num2, analysis.YRbase - num3);
						} else {
							DiagramGraphics.DrawString (s, font2, brush, num7, y3, GraphicsX.AlignText.CenterBottom, 0f);
							DiagramGraphics.Graphics.DrawLine (pen, num7, analysis.YRbase, num7 - num2, analysis.YRbase + num3);
							DiagramGraphics.Graphics.DrawLine (pen, num7, analysis.YRbase, num7 + num2, analysis.YRbase + num3);
						}
					}
				}
			}
			if (blnTorsionCalc) {
				float x = analysis.Zmin;
				float num8 = (float)(1E-06 * (double)num / (double)analysis.nTseg);
				short num9 = 0;
				yDbase = analysis.YDbase + analysis.Tseg [1].Phi (0f) / analysis.Dmax * 0.75f;
				int nTseg = analysis.nTseg;
				for (int n = 1; n <= nTseg; n++) {
					while (true) {
						float num7 = analysis.Zmin + num * (float)num9 / (float)num4;
						if (num7 > analysis.Tseg [n].Z + analysis.Tseg [n].L + num8) {
							break;
						}
						analysis.Zdiag [num9] = num7;
						float y3 = analysis.YVbase + analysis.Tseg [n].Tsv (num7 - analysis.Tseg [n].Z) / analysis.Vmax * 0.75f;
						if (y3 > analysis.YVbase + 0.75f) {
							y3 = analysis.YVbase + 0.75f;
						}
						if (y3 < analysis.YVbase - 0.75f) {
							y3 = analysis.YVbase - 0.75f;
						}
						DiagramGraphics.Graphics.DrawLine (pen2, x, y, num7, y3);
						y = y3;
						analysis.Vdiag [num9] = analysis.Tseg [n].T (num7 - analysis.Tseg [n].Z);
						y3 = analysis.YVbase + analysis.Vdiag [num9] / analysis.Vmax * 0.75f;
						if (y3 > analysis.YVbase + 0.75f) {
							y3 = analysis.YVbase + 0.75f;
						}
						if (y3 < analysis.YVbase - 0.75f) {
							y3 = analysis.YVbase - 0.75f;
						}
						DiagramGraphics.Graphics.DrawLine (pen, x, num6, num7, y3);
						num6 = y3;
						analysis.Mdiag [num9] = analysis.Tseg [n].B (num7 - analysis.Tseg [n].Z);
						y3 = analysis.YMbase + analysis.Mdiag [num9] / analysis.Mmax * 0.75f;
						if (y3 > analysis.YMbase + 0.75f) {
							y3 = analysis.YMbase + 0.75f;
						}
						if (y3 < analysis.YMbase - 0.75f) {
							y3 = analysis.YMbase - 0.75f;
						}
						DiagramGraphics.Graphics.DrawLine (pen, x, y2, num7, y3);
						y2 = y3;
						analysis.Ddiag [num9] = analysis.Tseg [n].Phi (num7 - analysis.Tseg [n].Z);
						y3 = analysis.YDbase + analysis.Ddiag [num9] / analysis.Dmax * 0.75f;
						if (y3 > analysis.YDbase + 0.75f) {
							y3 = analysis.YDbase + 0.75f;
						}
						if (y3 < analysis.YDbase - 0.75f) {
							y3 = analysis.YDbase - 0.75f;
						}
						DiagramGraphics.Graphics.DrawLine (pen, x, yDbase, num7, y3);
						yDbase = y3;
						x = num7;
						num9 = (short)(num9 + 1);
					}
				}
				DiagramGraphics.Graphics.DrawLine (pen2, x, y, analysis.Zmax, analysis.YVbase);
				DiagramGraphics.Graphics.DrawLine (pen, x, num6, analysis.Zmax, analysis.YVbase);
				DiagramGraphics.Graphics.DrawLine (pen, x, y2, analysis.Zmax, analysis.YMbase);
			}
			DiagramGraphics.DrawString ("Torque", font, brush, num5, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
		}
		if (blnTorsionCalc) {
			int nV2 = Det.NV;
			for (int num10 = 1; num10 <= nV2; num10 = checked(num10 + 1)) {
				if ((double)Math.Abs (Det.V [num10]) > 0.01 * (double)analysis.Vmax) {
					string s = Units.DisplayTorque (Det.V [num10], 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(Det.V [num10] > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZV [num10], analysis.YVbase + 0.75f * Det.V [num10] / analysis.Vmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		DiagramGraphics.DrawString ("Bimoment", font, brush, num5, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
		DiagramGraphics.DrawString ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")");
		if (blnTorsionCalc) {
			int nM2 = Det.NM;
			for (int num11 = 1; num11 <= nM2; num11 = checked(num11 + 1)) {
				if ((double)Math.Abs (Det.M [num11]) > 0.01 * (double)analysis.Mmax) {
					string s = Units.DisplayBimoment (Det.M [num11], 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(Det.M [num11] > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZM [num11], analysis.YMbase + 0.75f * Det.M [num11] / analysis.Mmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		DiagramGraphics.DrawString ("Twist", font, brush, num5, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
		DiagramGraphics.DrawString ("(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")");
		if (blnTorsionCalc) {
			int nD2 = Det.ND;
			for (int num12 = 1; num12 <= nD2; num12 = checked(num12 + 1)) {
				if ((double)Math.Abs (Det.D [num12]) > 0.01 * (double)analysis.Dmax) {
					string s = Units.DisplayAngle (Det.D [num12], 0, blnShowUnit: false, "", 0, 0);
					byte align = (byte)((!(Det.D [num12] > 0f)) ? 3 : 5);
					DiagramGraphics.DrawString (s, font2, brush, Det.ZD [num12], analysis.YDbase + 0.75f * Det.D [num12] / analysis.Dmax, (GraphicsX.AlignText)align, 0f);
				}
			}
		}
		analysis = null;
		DiagramGraphics.PreserveImage ();
	}

	private bool PlotTorsionEnvelopes (Analysis Analysis1)
	{
		string strMsg = string.Empty;
		SolutionDetail Det = default(SolutionDetail);
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		Pen pen2 = new Pen (Color.Gray, 0f);
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		bool result = false;
		cmdPrint.Enabled = false;
		cmdCopyImage.Enabled = false;
		cmdReport.Enabled = false;
		Analysis analysis = Analysis1;
		DiagramGraphics.Graphics.Clear (picDiagrams.BackColor);
		float num = analysis.Zmax - analysis.Zmin;
		DiagramGraphics.Scale ((float)((double)analysis.Zmin - 0.15 * (double)num / 0.75), 8f, (float)((double)analysis.Zmax + 0.1 * (double)num / 0.75), 0f);
		pen.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
		pen2.Width = Math.Min (DiagramGraphics.PenScale / DiagramGraphics.Graphics.DpiX, DiagramGraphics.YUnitsPerInch / DiagramGraphics.Graphics.DpiY);
		float num2 = num / 96f;
		float num3 = num2 * Math.Abs (DiagramGraphics.Width / DiagramGraphics.ScaleWidth) / Math.Abs (DiagramGraphics.Height / DiagramGraphics.ScaleHeight);
		checked {
			short num4 = (short)Math.Round (0.75 * (double)picDiagrams.ClientSize.Width);
			float num5 = (float)((double)analysis.Zmin - 0.075 * (double)num / 0.75);
			analysis.Rdiag = new float[num4 + 1];
			analysis.Vdiag = new float[num4 + 1];
			analysis.Mdiag = new float[num4 + 1];
			analysis.Ddiag = new float[num4 + 1];
			analysis.Zdiag = new float[num4 + 1];
			analysis.Rdiag2 = new float[num4 + 1];
			analysis.Vdiag2 = new float[num4 + 1];
			analysis.Mdiag2 = new float[num4 + 1];
			analysis.Ddiag2 = new float[num4 + 1];
			analysis.YRbase = 7f;
			DiagramGraphics.DrawString ("Reaction", font, brush, num5, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			analysis.YVbase = 5f;
			DiagramGraphics.DrawString ("Torque", font, brush, num5, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			analysis.YMbase = 3f;
			DiagramGraphics.DrawString ("Bimoment", font, brush, num5, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")");
			analysis.YDbase = 1f;
			DiagramGraphics.DrawString ("Twist", font, brush, num5, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
			DiagramGraphics.DrawString ("(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")");
			short iComb = analysis.iComb;
			analysis.Rmax = 0f;
			analysis.Vmax = 0f;
			analysis.Mmax = 0f;
			analysis.Dmax = 0f;
			short nComb = analysis.nComb;
			short num6 = 1;
			while (true) {
				if (num6 <= nComb) {
					analysis.iComb = (byte)num6;
					analysis.AnalyzeTorsion (ref strMsg);
					if (Strings.Len (strMsg) != 0) {
						strMsg = "Combination " + Conversions.ToString (unchecked((int)num6)) + ": " + analysis.Comb [num6].Description + "\r\n" + strMsg;
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
						analysis.iComb = (byte)iComb;
						analysis.AnalyzeTorsion (ref strMsg);
						break;
					}
					analysis.TorsionMinMax (ref Det);
					int nR = Det.NR;
					short num7;
					for (int i = 1; i <= nR; i++) {
						if (Math.Abs (Det.R [i]) > analysis.Rmax) {
							analysis.Rmax = Math.Abs (Det.R [i]);
						}
						num7 = (short)Math.Round ((Det.ZR [i] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.R [i] > analysis.Rdiag [num7]) {
							analysis.Rdiag [num7] = Det.R [i];
						}
						if (Det.R [i] < analysis.Rdiag2 [num7]) {
							analysis.Rdiag2 [num7] = Det.R [i];
						}
					}
					int nV = Det.NV;
					for (int j = 1; j <= nV; j++) {
						if (Math.Abs (Det.V [j]) > analysis.Vmax) {
							analysis.Vmax = Math.Abs (Det.V [j]);
						}
						num7 = (short)Math.Round ((Det.ZV [j] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.V [j] > analysis.Vdiag [num7]) {
							analysis.Vdiag [num7] = Det.V [j];
						}
						if (Det.V [j] < analysis.Vdiag2 [num7]) {
							analysis.Vdiag2 [num7] = Det.V [j];
						}
					}
					int nM = Det.NM;
					for (int k = 1; k <= nM; k++) {
						if (Math.Abs (Det.M [k]) > analysis.Mmax) {
							analysis.Mmax = Math.Abs (Det.M [k]);
						}
						num7 = (short)Math.Round ((Det.ZM [k] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.M [k] > analysis.Mdiag [num7]) {
							analysis.Mdiag [num7] = Det.M [k];
						}
						if (Det.M [k] < analysis.Mdiag2 [num7]) {
							analysis.Mdiag2 [num7] = Det.M [k];
						}
					}
					int nM2 = Det.NM;
					for (int l = 1; l <= nM2; l++) {
						if (Math.Abs (Det.D [l]) > analysis.Dmax) {
							analysis.Dmax = Math.Abs (Det.D [l]);
						}
						num7 = (short)Math.Round ((Det.ZD [l] - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)num4);
						if (Det.D [l] > analysis.Ddiag [num7]) {
							analysis.Ddiag [num7] = Det.D [l];
						}
						if (Det.D [l] < analysis.Ddiag2 [num7]) {
							analysis.Ddiag2 [num7] = Det.D [l];
						}
					}
					float num8 = (float)(1E-06 * (double)num / (double)analysis.nTseg);
					num7 = 0;
					int nTseg = analysis.nTseg;
					for (int m = 1; m <= nTseg; m++) {
						while (true) {
							float num9 = analysis.Zmin + num * (float)num7 / (float)num4;
							if (num9 > analysis.Tseg [m].Z + analysis.Tseg [m].L + num8) {
								break;
							}
							analysis.Zdiag [num7] = num9;
							float num10 = analysis.Tseg [m].T (num9 - analysis.Tseg [m].Z);
							if (num10 > analysis.Vdiag [num7]) {
								analysis.Vdiag [num7] = num10;
							}
							if (num10 < analysis.Vdiag2 [num7]) {
								analysis.Vdiag2 [num7] = num10;
							}
							if (Math.Abs (num10) > analysis.Vmax) {
								analysis.Vmax = Math.Abs (num10);
							}
							num10 = analysis.Tseg [m].B (num9 - analysis.Tseg [m].Z);
							if (num10 > analysis.Mdiag [num7]) {
								analysis.Mdiag [num7] = num10;
							}
							if (num10 < analysis.Mdiag2 [num7]) {
								analysis.Mdiag2 [num7] = num10;
							}
							if (Math.Abs (num10) > analysis.Mmax) {
								analysis.Mmax = Math.Abs (num10);
							}
							num10 = analysis.Tseg [m].Phi (num9 - analysis.Tseg [m].Z);
							if (num10 > analysis.Ddiag [num7]) {
								analysis.Ddiag [num7] = num10;
							}
							if (num10 < analysis.Ddiag2 [num7]) {
								analysis.Ddiag2 [num7] = num10;
							}
							if (Math.Abs (num10) > analysis.Dmax) {
								analysis.Dmax = Math.Abs (num10);
							}
							num7 = (short)(num7 + 1);
						}
					}
					num6 = (short)unchecked(num6 + 1);
					continue;
				}
				if (analysis.Rmax == 0f) {
					analysis.Rmax = 1f;
				}
				if (analysis.Vmax == 0f) {
					analysis.Vmax = 1f;
				}
				if (analysis.Mmax == 0f) {
					analysis.Mmax = 1f;
				}
				if (analysis.Dmax == 0f) {
					analysis.Dmax = 1f;
				}
				analysis.iComb = (byte)iComb;
				analysis.AnalyzeTorsion (ref strMsg);
				short num11 = num4;
				for (short num7 = 0; num7 <= num11; num7 = (short)unchecked(num7 + 1)) {
					float num9 = analysis.Zdiag [num7];
					float num10 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YVbase, num9, num10);
					num10 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag2 [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YVbase, num9, num10);
					num10 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YMbase, num9, num10);
					num10 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag2 [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YMbase, num9, num10);
					num10 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YDbase, num9, num10);
					num10 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag2 [num7]);
					DiagramGraphics.Graphics.DrawLine (pen2, num9, analysis.YDbase, num9, num10);
				}
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
				DiagramGraphics.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
				short num12 = num4;
				for (short num7 = 0; num7 <= num12; num7 = (short)unchecked(num7 + 1)) {
					float num9 = analysis.Zdiag [num7];
					if ((double)analysis.Rdiag [num7] > 0.01 * (double)analysis.Rmax) {
						float num10 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag [num7] / (double)analysis.Rmax);
						string s = Units.DisplayTorque (analysis.Rdiag [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, num10, GraphicsX.AlignText.CenterTop, 0f);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9, num10);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 - num2, analysis.YRbase - num3);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 + num2, analysis.YRbase - num3);
					}
					if ((double)analysis.Rdiag2 [num7] < -0.01 * (double)analysis.Rmax) {
						float num10 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag2 [num7] / (double)analysis.Rmax);
						string s = Units.DisplayTorque (analysis.Rdiag2 [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, num10, GraphicsX.AlignText.CenterBottom, 0f);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9, num10);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 - num2, analysis.YRbase + num3);
						DiagramGraphics.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 + num2, analysis.YRbase + num3);
					}
					if ((num7 == 0 || analysis.Vdiag [num7] > analysis.Vdiag [num7 - 1]) & (num7 == num4 || analysis.Vdiag [num7] > analysis.Vdiag [num7 + 1]) & ((double)analysis.Vdiag [num7] > 0.01 * (double)analysis.Vmax)) {
						string s = Units.DisplayTorque (analysis.Vdiag [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag [num7] / (double)analysis.Vmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num7 == 0 || analysis.Vdiag2 [num7] < analysis.Vdiag2 [num7 - 1]) & (num7 == num4 || analysis.Vdiag2 [num7] < analysis.Vdiag2 [num7 + 1]) & ((double)analysis.Vdiag2 [num7] < -0.01 * (double)analysis.Vmax)) {
						string s = Units.DisplayTorque (analysis.Vdiag2 [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag2 [num7] / (double)analysis.Vmax), GraphicsX.AlignText.CenterTop, 0f);
					}
					if ((num7 == 0 || analysis.Mdiag [num7] > analysis.Mdiag [num7 - 1]) & (num7 == num4 || analysis.Mdiag [num7] > analysis.Mdiag [num7 + 1]) & ((double)analysis.Mdiag [num7] > 0.01 * (double)analysis.Mmax)) {
						string s = Units.DisplayBimoment (analysis.Mdiag [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag [num7] / (double)analysis.Mmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num7 == 0 || analysis.Mdiag2 [num7] < analysis.Mdiag2 [num7 - 1]) & (num7 == num4 || analysis.Mdiag2 [num7] < analysis.Mdiag2 [num7 + 1]) & ((double)analysis.Mdiag2 [num7] < -0.01 * (double)analysis.Mmax)) {
						string s = Units.DisplayBimoment (analysis.Mdiag2 [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag2 [num7] / (double)analysis.Mmax), GraphicsX.AlignText.CenterTop, 0f);
					}
					if ((num7 == 0 || analysis.Ddiag [num7] > analysis.Ddiag [num7 - 1]) & (num7 == num4 || analysis.Ddiag [num7] > analysis.Ddiag [num7 + 1]) & ((double)analysis.Ddiag [num7] > 0.01 * (double)analysis.Dmax)) {
						string s = Units.DisplayAngle (analysis.Ddiag [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag [num7] / (double)analysis.Dmax), GraphicsX.AlignText.CenterBottom, 0f);
					}
					if ((num7 == 0 || analysis.Ddiag2 [num7] < analysis.Ddiag2 [num7 - 1]) & (num7 == num4 || analysis.Ddiag2 [num7] < analysis.Ddiag2 [num7 + 1]) & ((double)analysis.Ddiag2 [num7] < -0.01 * (double)analysis.Dmax)) {
						string s = Units.DisplayAngle (analysis.Ddiag2 [num7], 0, blnShowUnit: false, "", 0, 0);
						DiagramGraphics.DrawString (s, font2, brush, num9, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag2 [num7] / (double)analysis.Dmax), GraphicsX.AlignText.CenterTop, 0f);
					}
				}
				analysis = null;
				DiagramGraphics.PreserveImage ();
				result = true;
				cmdPrint.Enabled = true;
				cmdCopyImage.Enabled = true;
				cmdReport.Enabled = true;
				break;
			}
			return result;
		}
	}

	private void picDiagrams_MouseMove (object sender, MouseEventArgs e)
	{
		PointF[] array = new PointF[1] {
			new PointF (e.X, e.Y)
		};
		DiagramGraphics.Graphics.TransformPoints (CoordinateSpace.World, CoordinateSpace.Device, array);
		float num = array [0].X;
		float num2 = array [0].Y;
		string text = string.Empty;
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		bool flag = false;
		switch (cboDirection.SelectedIndex) {
		case 0:
			if (analysis.iCombSol == analysis.iComb && analysis.Sol [1].nLoad > 0) {
				flag = true;
			}
			break;
		case 1:
			if (analysis.iCombSol == analysis.iComb && analysis.Sol [2].nLoad > 0) {
				flag = true;
			}
			break;
		case 2:
			if (blnTorsionCalc) {
				flag = true;
			}
			break;
		}
		if (e.Button == MouseButtons.None && flag) {
			short num3;
			short num4;
			checked {
				num3 = (short)Information.UBound (analysis.Zdiag);
				num4 = (short)Math.Round ((float)num3 * (num - analysis.Zdiag [0]) / (analysis.Zdiag [num3] - analysis.Zdiag [0]));
			}
			if (num4 >= 0 && num4 <= num3) {
				float num5 = (float)(0.4 * (double)(analysis.YVbase - analysis.YMbase));
				if (cboCombination.SelectedIndex == 0) {
					if ((num2 > analysis.YVbase) & (num2 <= analysis.YVbase + num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayForce (analysis.Vdiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayTorque (analysis.Vdiag [num4], 0, blnShowUnit: true, "", 0, 0));
					} else if ((num2 < analysis.YVbase) & (num2 >= analysis.YVbase - num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayForce (analysis.Vdiag2 [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayTorque (analysis.Vdiag2 [num4], 0, blnShowUnit: true, "", 0, 0));
					} else if ((num2 > analysis.YMbase) & (num2 <= analysis.YMbase + num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayMoment (analysis.Mdiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayBimoment (analysis.Mdiag [num4], 0, blnShowUnit: true, "", 0, 0));
					} else if ((num2 < analysis.YMbase) & (num2 >= analysis.YMbase - num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayMoment (analysis.Mdiag2 [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayBimoment (analysis.Mdiag2 [num4], 0, blnShowUnit: true, "", 0, 0));
					} else if ((num2 > analysis.YDbase) & (num2 <= analysis.YDbase + num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayLen1 (analysis.Ddiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayAngle (analysis.Ddiag [num4], 0, blnShowUnit: true, "", 0, 0));
					} else if ((num2 < analysis.YDbase) & (num2 >= analysis.YDbase - num5)) {
						text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayLen1 (analysis.Ddiag2 [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayAngle (analysis.Ddiag2 [num4], 0, blnShowUnit: true, "", 0, 0));
					}
				} else if ((num2 >= analysis.YVbase - num5) & (num2 <= analysis.YVbase + num5)) {
					text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayForce (analysis.Vdiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayTorque (analysis.Vdiag [num4], 0, blnShowUnit: true, "", 0, 0));
				} else if ((num2 >= analysis.YMbase - num5) & (num2 <= analysis.YMbase + num5)) {
					text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayMoment (analysis.Mdiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayBimoment (analysis.Mdiag [num4], 0, blnShowUnit: true, "", 0, 0));
				} else if ((num2 >= analysis.YDbase - num5) & (num2 <= analysis.YDbase + num5)) {
					text = ((cboDirection.SelectedIndex != 2) ? Units.DisplayLen1 (analysis.Ddiag [num4], 0, blnShowUnit: true, "", 0, 0) : Units.DisplayAngle (analysis.Ddiag [num4], 0, blnShowUnit: true, "", 0, 0));
				}
			}
		}
		analysis = null;
		if (Strings.Len (text) != 0) {
			tipDiagrams.Show (text + " @ " + Units.DisplayLength (num, 0, blnShowUnit: true, "", 0, 0), picDiagrams, e.X, checked(e.Y - 16));
		} else {
			tipDiagrams.Hide (picDiagrams);
		}
	}

	private void picDiagrams_MouseLeave (object sender, EventArgs e)
	{
		tipDiagrams.Hide (picDiagrams);
	}
}
