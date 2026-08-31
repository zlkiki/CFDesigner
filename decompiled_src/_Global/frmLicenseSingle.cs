// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using com.softwarekey.Client.WebService.XmlLicenseService;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RSG.CFS;

[DesignerGenerated]
public class frmLicenseSingle : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("txtStatus")]
	internal virtual TextBox txtStatus {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdRefresh {
		[CompilerGenerated]
		get {
			return _cmdRefresh;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdRefresh_Click;
			Button button = _cmdRefresh;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdRefresh = value;
			button = _cmdRefresh;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdActivate {
		[CompilerGenerated]
		get {
			return _cmdActivate;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdActivate_Click;
			Button button = _cmdActivate;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdActivate = value;
			button = _cmdActivate;
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

	[field: AccessedThroughProperty ("lblLicenseID")]
	internal virtual Label lblLicenseID {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtLicenseID")]
	internal virtual TextBox txtLicenseID {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblPassword")]
	internal virtual Label lblPassword {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtPassword")]
	internal virtual TextBox txtPassword {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdActivateNow {
		[CompilerGenerated]
		get {
			return _cmdActivateNow;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdActivateNow_Click;
			Button button = _cmdActivateNow;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdActivateNow = value;
			button = _cmdActivateNow;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdCancel {
		[CompilerGenerated]
		get {
			return _cmdCancel;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdCancel_Click;
			Button button = _cmdCancel;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdCancel = value;
			button = _cmdCancel;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblPortal")]
	internal virtual Label lblPortal {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual LinkLabel lnkPortal {
		[CompilerGenerated]
		get {
			return _lnkPortal;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			LinkLabelLinkClickedEventHandler value2 = lnkPortal_LinkClicked;
			LinkLabel linkLabel = _lnkPortal;
			if (linkLabel != null) {
				linkLabel.LinkClicked -= value2;
			}
			_lnkPortal = value;
			linkLabel = _lnkPortal;
			if (linkLabel != null) {
				linkLabel.LinkClicked += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInformation")]
	internal virtual Label lblInformation {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdHelp {
		[CompilerGenerated]
		get {
			return _cmdHelp;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdHelp_Click;
			Button button = _cmdHelp;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdHelp = value;
			button = _cmdHelp;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmLicenseSingle ()
	{
		base.Load += frmLicenseSingle_Load;
		base.Shown += frmLicenseSingle_Shown;
		base.HelpButtonClicked += frmLicenseSingle_HelpButtonClicked;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmLicenseSingle));
		this.txtStatus = new System.Windows.Forms.TextBox ();
		this.cmdRefresh = new System.Windows.Forms.Button ();
		this.cmdActivate = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.lblLicenseID = new System.Windows.Forms.Label ();
		this.txtLicenseID = new System.Windows.Forms.TextBox ();
		this.lblPassword = new System.Windows.Forms.Label ();
		this.txtPassword = new System.Windows.Forms.TextBox ();
		this.cmdActivateNow = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lblPortal = new System.Windows.Forms.Label ();
		this.lnkPortal = new System.Windows.Forms.LinkLabel ();
		this.lblInformation = new System.Windows.Forms.Label ();
		this.cmdHelp = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.txtStatus.Location = new System.Drawing.Point (12, 8);
		this.txtStatus.Multiline = true;
		this.txtStatus.Name = "txtStatus";
		this.txtStatus.ReadOnly = true;
		this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtStatus.Size = new System.Drawing.Size (348, 107);
		this.txtStatus.TabIndex = 3;
		this.txtStatus.TabStop = false;
		this.cmdRefresh.Location = new System.Drawing.Point (140, 121);
		this.cmdRefresh.Name = "cmdRefresh";
		this.cmdRefresh.Size = new System.Drawing.Size (100, 25);
		this.cmdRefresh.TabIndex = 5;
		this.cmdRefresh.Text = "Refresh License";
		this.cmdRefresh.UseVisualStyleBackColor = true;
		this.cmdActivate.Location = new System.Drawing.Point (19, 121);
		this.cmdActivate.Name = "cmdActivate";
		this.cmdActivate.Size = new System.Drawing.Size (110, 25);
		this.cmdActivate.TabIndex = 4;
		this.cmdActivate.Text = "Activate License";
		this.cmdActivate.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (251, 121);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (100, 25);
		this.cmdClose.TabIndex = 6;
		this.cmdClose.Text = "Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.lblLicenseID.AutoSize = true;
		this.lblLicenseID.Location = new System.Drawing.Point (26, 252);
		this.lblLicenseID.Name = "lblLicenseID";
		this.lblLicenseID.Size = new System.Drawing.Size (61, 13);
		this.lblLicenseID.TabIndex = 15;
		this.lblLicenseID.Text = "License ID:";
		this.txtLicenseID.Enabled = false;
		this.txtLicenseID.Location = new System.Drawing.Point (140, 249);
		this.txtLicenseID.Name = "txtLicenseID";
		this.txtLicenseID.Size = new System.Drawing.Size (100, 20);
		this.txtLicenseID.TabIndex = 16;
		this.lblPassword.AutoSize = true;
		this.lblPassword.Location = new System.Drawing.Point (26, 278);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size (106, 13);
		this.lblPassword.TabIndex = 17;
		this.lblPassword.Text = "Activation Password:";
		this.txtPassword.Enabled = false;
		this.txtPassword.Location = new System.Drawing.Point (140, 275);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size (100, 20);
		this.txtPassword.TabIndex = 18;
		this.cmdActivateNow.Enabled = false;
		this.cmdActivateNow.Location = new System.Drawing.Point (140, 301);
		this.cmdActivateNow.Name = "cmdActivateNow";
		this.cmdActivateNow.Size = new System.Drawing.Size (100, 25);
		this.cmdActivateNow.TabIndex = 20;
		this.cmdActivateNow.Text = "Activate";
		this.cmdActivateNow.UseVisualStyleBackColor = true;
		this.cmdCancel.Enabled = false;
		this.cmdCancel.Location = new System.Drawing.Point (251, 301);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (100, 25);
		this.cmdCancel.TabIndex = 21;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lblPortal.AutoSize = true;
		this.lblPortal.Location = new System.Drawing.Point (22, 227);
		this.lblPortal.Name = "lblPortal";
		this.lblPortal.Size = new System.Drawing.Size (196, 13);
		this.lblPortal.TabIndex = 12;
		this.lblPortal.Text = "For your license information, log in to the";
		this.lnkPortal.AutoSize = true;
		this.lnkPortal.Location = new System.Drawing.Point (218, 227);
		this.lnkPortal.Name = "lnkPortal";
		this.lnkPortal.Size = new System.Drawing.Size (74, 13);
		this.lnkPortal.TabIndex = 13;
		this.lnkPortal.TabStop = true;
		this.lnkPortal.Text = "License Portal";
		this.lblInformation.Location = new System.Drawing.Point (13, 160);
		this.lblInformation.Name = "lblInformation";
		this.lblInformation.Size = new System.Drawing.Size (347, 59);
		this.lblInformation.TabIndex = 11;
		this.lblInformation.Text = resources.GetString ("lblInformation.Text");
		this.cmdHelp.Enabled = false;
		this.cmdHelp.Location = new System.Drawing.Point (29, 301);
		this.cmdHelp.Name = "cmdHelp";
		this.cmdHelp.Size = new System.Drawing.Size (100, 25);
		this.cmdHelp.TabIndex = 19;
		this.cmdHelp.Text = "&Help";
		this.cmdHelp.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (373, 335);
		base.Controls.Add (this.cmdHelp);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdActivateNow);
		base.Controls.Add (this.txtPassword);
		base.Controls.Add (this.lblPassword);
		base.Controls.Add (this.txtLicenseID);
		base.Controls.Add (this.lblLicenseID);
		base.Controls.Add (this.cmdClose);
		base.Controls.Add (this.cmdActivate);
		base.Controls.Add (this.cmdRefresh);
		base.Controls.Add (this.txtStatus);
		base.Controls.Add (this.lblPortal);
		base.Controls.Add (this.lnkPortal);
		base.Controls.Add (this.lblInformation);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLicenseSingle";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Single User License";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void ReloadLicense ()
	{
		if (CFS.SingleLicense == null) {
			CFS.SingleLicense = new CFSLicense (CFS.SingleLicenseConfig);
		}
		if (CFS.SingleLicense.LoadFile (CFS.SingleLicenseConfig.LicenseFilePath)) {
			if (CFS.SingleLicense.Validate ()) {
				if (CFS.intLicenseType == CFS.LicenseTypes.Semaphore) {
					CFS.NetworkLicenseConfig.AppendLog ("Released");
				}
				if (CFS.LicenseSemaphore != null) {
					CFS.LicenseSemaphore.Close ();
					CFS.LicenseSemaphore = null;
				}
				CFS.SingleLicenseConfig.AppendLog ("Acquired");
				CFS.intLicenseType = CFS.LicenseTypes.SingleUser;
			} else {
				CFS.SingleLicenseConfig.AppendLog ("Invalid");
				if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
					CFS.intLicenseType = CFS.LicenseTypes.None;
				}
			}
		} else {
			CFS.SingleLicenseConfig.AppendLog ("Error " + Conversions.ToString (CFS.SingleLicense.LastError.ErrorNumber));
			if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
				CFS.intLicenseType = CFS.LicenseTypes.None;
			}
		}
	}

	private void RefreshForm ()
	{
		if (CFS.SingleLicense != null) {
			if (CFS.SingleLicense.LastError.ErrorNumber == 0) {
				txtStatus.Text = CFS.SingleLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: true);
			} else {
				txtStatus.Text = CFS.SingleLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: false);
			}
			cmdRefresh.Enabled = CFS.SingleLicense.LicenseID > 0;
		} else {
			txtStatus.Text = "Single user license not established.";
			cmdRefresh.Enabled = false;
		}
		cmdActivate.Text = Conversions.ToString (Interaction.IIf (CFS.intLicenseType == CFS.LicenseTypes.SingleUser, "Deactivate License", "Activate License"));
		if (cmdRefresh.Enabled) {
			cmdClose.Focus ();
		} else {
			cmdActivate.Focus ();
		}
	}

	private void frmLicenseSingle_Load (object sender, EventArgs e)
	{
		base.Height = checked(cmdActivate.Top + cmdActivate.Height + 8 + (base.Height - base.ClientSize.Height));
		RefreshForm ();
	}

	private void frmLicenseSingle_Shown (object sender, EventArgs e)
	{
		if (cmdRefresh.Enabled) {
			cmdClose.Focus ();
		} else {
			cmdActivate.Focus ();
		}
		lnkPortal.Left = checked(lblPortal.Left + lblPortal.Width);
	}

	private void frmLicenseSingle_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "single-user-license.htm");
		e.Cancel = true;
	}

	private void cmdRefresh_Click (object sender, EventArgs e)
	{
		if (CFS.SingleLicense.RefreshLicense ()) {
			CFS.SingleLicenseConfig.AppendLog ("Refreshed");
			Interaction.MsgBox ("The license has been refreshed successfully.", MsgBoxStyle.Information);
		} else {
			Interaction.MsgBox ("The license was not refreshed.  Error: (" + Conversions.ToString (CFS.SingleLicense.LastError.ErrorNumber) + ")" + CFS.SingleLicense.LastError.ErrorString, MsgBoxStyle.Information);
		}
		ReloadLicense ();
		RefreshForm ();
	}

	private void cmdActivate_Click (object sender, EventArgs e)
	{
		if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
			if (Interaction.MsgBox ("CAUTION: There are a limited number of deactivations.\r\nAre you sure you want to deactivate this license?", MsgBoxStyle.Exclamation | MsgBoxStyle.YesNo) != MsgBoxResult.No) {
				cmdActivate.Enabled = false;
				Cursor = Cursors.WaitCursor;
				bool num = CFS.SingleLicense.DeactivateOnline ();
				Cursor = Cursors.Default;
				cmdActivate.Enabled = true;
				if (num) {
					CFS.SingleLicenseConfig.AppendLog ("Deactivated");
					Interaction.MsgBox ("The license has been deactivated.", MsgBoxStyle.Information);
				} else {
					Interaction.MsgBox ("Deactivation Failed.\r\n\r\n" + CFS.SingleLicense.GenerateLicenseErrorString (), MsgBoxStyle.Exclamation);
				}
				ReloadLicense ();
				RefreshForm ();
			}
		} else {
			txtLicenseID.Enabled = true;
			txtPassword.Enabled = true;
			cmdHelp.Enabled = true;
			cmdActivateNow.Enabled = true;
			cmdCancel.Enabled = true;
			cmdActivate.Enabled = false;
			cmdClose.Enabled = false;
			base.Height = checked(cmdActivateNow.Top + cmdActivateNow.Height + 8 + (base.Height - base.ClientSize.Height));
			if (CFS.SingleLicense != null && CFS.SingleLicense.LicenseID > 0) {
				txtLicenseID.Text = CFS.SingleLicense.LicenseID.ToString ();
				txtPassword.Focus ();
			} else {
				txtLicenseID.Focus ();
			}
		}
	}

	private void cmdClose_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private void lnkPortal_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
	{
		CFS.Launch ("https://secure.softwarekey.com/solo/customers/Default.aspx?AuthorID=5117130");
	}

	private void cmdHelp_Click (object sender, EventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "license-activation.htm");
	}

	private void cmdActivateNow_Click (object sender, EventArgs e)
	{
		int result = 0;
		string text = txtPassword.Text;
		if (txtLicenseID.Text.Length == 0) {
			Interaction.MsgBox ("Please enter a license ID.", MsgBoxStyle.Exclamation);
			txtLicenseID.Focus ();
			return;
		}
		if (!int.TryParse (txtLicenseID.Text, out result)) {
			Interaction.MsgBox ("The License ID may only contain numbers.", MsgBoxStyle.Exclamation);
			txtLicenseID.Focus ();
			return;
		}
		if (text.Length == 0) {
			Interaction.MsgBox ("Please enter your password.", MsgBoxStyle.Exclamation);
			txtPassword.Focus ();
			return;
		}
		string optionName = GetLicenseInfo (result, text, LicenseConfiguration.ThisProductID).OptionName;
		if ((optionName.Length > 0) & !optionName.ToLower ().Contains ("single")) {
			Interaction.MsgBox ("The License ID is not for a single user license.", MsgBoxStyle.Exclamation);
			return;
		}
		cmdActivateNow.Enabled = false;
		Cursor = Cursors.WaitCursor;
		CFS.SingleLicense = new CFSLicense (CFS.SingleLicenseConfig);
		CFS.SingleLicense.InstallationName = Environment.UserName + " on " + Environment.MachineName;
		bool num = CFS.SingleLicense.ActivateOnline (result, text);
		Cursor = Cursors.Default;
		cmdActivateNow.Enabled = true;
		if (num) {
			CFS.SingleLicenseConfig.AppendLog ("Activated");
			Interaction.MsgBox ("Activation Successful!", MsgBoxStyle.Information);
			CloseActivation ();
			ReloadLicense ();
			RefreshForm ();
		} else {
			Interaction.MsgBox ("Activation Failed.\r\n\r\n" + CFS.SingleLicense.GenerateLicenseErrorString (), MsgBoxStyle.Exclamation);
		}
	}

	private InfoCheck GetLicenseInfo (int licenseID, string password, int productID)
	{
		InfoCheck infoCheck = new InfoCheck ();
		infoCheck.LicenseID = licenseID;
		infoCheck.Password = password;
		infoCheck.ProductID = productID;
		infoCheck.CallWebService ();
		return infoCheck;
	}

	private void cmdCancel_Click (object sender, EventArgs e)
	{
		CloseActivation ();
	}

	private void CloseActivation ()
	{
		base.Height = checked(cmdActivate.Top + cmdActivate.Height + 8 + (base.Height - base.ClientSize.Height));
		txtLicenseID.Enabled = false;
		txtPassword.Enabled = false;
		cmdHelp.Enabled = false;
		cmdActivateNow.Enabled = false;
		cmdCancel.Enabled = false;
		cmdActivate.Enabled = true;
		cmdClose.Enabled = true;
	}
}
