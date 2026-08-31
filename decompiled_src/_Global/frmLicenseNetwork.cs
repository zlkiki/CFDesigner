// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using com.softwarekey.Client.WebService.XmlLicenseService;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmLicenseNetwork : Form
{
	private IContainer components;

	private bool blnActive;

	private const string strFolderExample = "Example: \\\\server\\share";

	[field: AccessedThroughProperty ("lblFolder")]
	internal virtual Label lblFolder {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtFolder {
		[CompilerGenerated]
		get {
			return _txtFolder;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtFolder_GotFocus;
			EventHandler value3 = txtFolder_LostFocus;
			TextBox textBox = _txtFolder;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.LostFocus -= value3;
			}
			_txtFolder = value;
			textBox = _txtFolder;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.LostFocus += value3;
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

	[field: AccessedThroughProperty ("txtStatus")]
	internal virtual TextBox txtStatus {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdAcquire {
		[CompilerGenerated]
		get {
			return _cmdAcquire;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdAcquire_Click;
			Button button = _cmdAcquire;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdAcquire = value;
			button = _cmdAcquire;
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

	[field: AccessedThroughProperty ("lblPortal")]
	internal virtual Label lblPortal {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("grpAdmin")]
	internal virtual GroupBox grpAdmin {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdRegistry {
		[CompilerGenerated]
		get {
			return _cmdRegistry;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdRegistry_Click;
			Button button = _cmdRegistry;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdRegistry = value;
			button = _cmdRegistry;
			if (button != null) {
				button.Click += value2;
			}
		}
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

	[field: AccessedThroughProperty ("lblInformation")]
	internal virtual Label lblInformation {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtCompany")]
	internal virtual TextBox txtCompany {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblCompany")]
	internal virtual Label lblCompany {
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

	internal virtual Button cmdLogFile {
		[CompilerGenerated]
		get {
			return _cmdLogFile;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdLogFile_Click;
			Button button = _cmdLogFile;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdLogFile = value;
			button = _cmdLogFile;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmLicenseNetwork ()
	{
		base.Load += frmLicenseNetwork_Load;
		base.Shown += frmLicenseNetwork_Shown;
		base.HelpButtonClicked += frmLicenseNetwork_HelpButtonClicked;
		base.PreviewKeyDown += frmLicenseNetwork_PreviewKeyDown;
		base.KeyDown += frmLicenseNetwork_KeyDown;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmLicenseNetwork));
		this.lblFolder = new System.Windows.Forms.Label ();
		this.txtFolder = new System.Windows.Forms.TextBox ();
		this.cmdBrowse = new System.Windows.Forms.Button ();
		this.txtStatus = new System.Windows.Forms.TextBox ();
		this.cmdAcquire = new System.Windows.Forms.Button ();
		this.cmdClose = new System.Windows.Forms.Button ();
		this.lblLicenseID = new System.Windows.Forms.Label ();
		this.txtLicenseID = new System.Windows.Forms.TextBox ();
		this.lblPassword = new System.Windows.Forms.Label ();
		this.txtPassword = new System.Windows.Forms.TextBox ();
		this.cmdActivateNow = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.lnkPortal = new System.Windows.Forms.LinkLabel ();
		this.lblPortal = new System.Windows.Forms.Label ();
		this.grpAdmin = new System.Windows.Forms.GroupBox ();
		this.cmdRegistry = new System.Windows.Forms.Button ();
		this.cmdRefresh = new System.Windows.Forms.Button ();
		this.cmdActivate = new System.Windows.Forms.Button ();
		this.lblInformation = new System.Windows.Forms.Label ();
		this.txtCompany = new System.Windows.Forms.TextBox ();
		this.lblCompany = new System.Windows.Forms.Label ();
		this.cmdHelp = new System.Windows.Forms.Button ();
		this.cmdLogFile = new System.Windows.Forms.Button ();
		this.grpAdmin.SuspendLayout ();
		base.SuspendLayout ();
		this.lblFolder.AutoSize = true;
		this.lblFolder.Location = new System.Drawing.Point (12, 36);
		this.lblFolder.Name = "lblFolder";
		this.lblFolder.Size = new System.Drawing.Size (67, 13);
		this.lblFolder.TabIndex = 2;
		this.lblFolder.Text = "Share folder:";
		this.txtFolder.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtFolder.Location = new System.Drawing.Point (85, 33);
		this.txtFolder.Name = "txtFolder";
		this.txtFolder.Size = new System.Drawing.Size (244, 20);
		this.txtFolder.TabIndex = 3;
		this.cmdBrowse.Location = new System.Drawing.Point (335, 33);
		this.cmdBrowse.Name = "cmdBrowse";
		this.cmdBrowse.Size = new System.Drawing.Size (25, 20);
		this.cmdBrowse.TabIndex = 4;
		this.cmdBrowse.Text = "...";
		this.cmdBrowse.UseVisualStyleBackColor = true;
		this.txtStatus.Location = new System.Drawing.Point (12, 59);
		this.txtStatus.Multiline = true;
		this.txtStatus.Name = "txtStatus";
		this.txtStatus.ReadOnly = true;
		this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtStatus.Size = new System.Drawing.Size (348, 107);
		this.txtStatus.TabIndex = 5;
		this.txtStatus.TabStop = false;
		this.cmdAcquire.Location = new System.Drawing.Point (19, 172);
		this.cmdAcquire.Name = "cmdAcquire";
		this.cmdAcquire.Size = new System.Drawing.Size (110, 25);
		this.cmdAcquire.TabIndex = 6;
		this.cmdAcquire.Text = "Acquire License";
		this.cmdAcquire.UseVisualStyleBackColor = true;
		this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdClose.Location = new System.Drawing.Point (251, 172);
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.Size = new System.Drawing.Size (100, 25);
		this.cmdClose.TabIndex = 8;
		this.cmdClose.Text = "Close";
		this.cmdClose.UseVisualStyleBackColor = true;
		this.lblLicenseID.AutoSize = true;
		this.lblLicenseID.Location = new System.Drawing.Point (26, 371);
		this.lblLicenseID.Name = "lblLicenseID";
		this.lblLicenseID.Size = new System.Drawing.Size (61, 13);
		this.lblLicenseID.TabIndex = 17;
		this.lblLicenseID.Text = "License ID:";
		this.txtLicenseID.Enabled = false;
		this.txtLicenseID.Location = new System.Drawing.Point (140, 368);
		this.txtLicenseID.Name = "txtLicenseID";
		this.txtLicenseID.Size = new System.Drawing.Size (100, 20);
		this.txtLicenseID.TabIndex = 18;
		this.lblPassword.AutoSize = true;
		this.lblPassword.Location = new System.Drawing.Point (26, 397);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size (106, 13);
		this.lblPassword.TabIndex = 19;
		this.lblPassword.Text = "Activation Password:";
		this.txtPassword.Enabled = false;
		this.txtPassword.Location = new System.Drawing.Point (140, 394);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size (100, 20);
		this.txtPassword.TabIndex = 20;
		this.cmdActivateNow.Enabled = false;
		this.cmdActivateNow.Location = new System.Drawing.Point (140, 420);
		this.cmdActivateNow.Name = "cmdActivateNow";
		this.cmdActivateNow.Size = new System.Drawing.Size (100, 25);
		this.cmdActivateNow.TabIndex = 22;
		this.cmdActivateNow.Text = "Activate";
		this.cmdActivateNow.UseVisualStyleBackColor = true;
		this.cmdCancel.Enabled = false;
		this.cmdCancel.Location = new System.Drawing.Point (251, 420);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (100, 25);
		this.cmdCancel.TabIndex = 23;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.lnkPortal.AutoSize = true;
		this.lnkPortal.Location = new System.Drawing.Point (217, 346);
		this.lnkPortal.Name = "lnkPortal";
		this.lnkPortal.Size = new System.Drawing.Size (74, 13);
		this.lnkPortal.TabIndex = 15;
		this.lnkPortal.TabStop = true;
		this.lnkPortal.Text = "License Portal";
		this.lblPortal.AutoSize = true;
		this.lblPortal.Location = new System.Drawing.Point (21, 346);
		this.lblPortal.Name = "lblPortal";
		this.lblPortal.Size = new System.Drawing.Size (196, 13);
		this.lblPortal.TabIndex = 14;
		this.lblPortal.Text = "For your license information, log in to the";
		this.grpAdmin.Controls.Add (this.cmdRegistry);
		this.grpAdmin.Controls.Add (this.cmdRefresh);
		this.grpAdmin.Controls.Add (this.cmdActivate);
		this.grpAdmin.Location = new System.Drawing.Point (8, 213);
		this.grpAdmin.Name = "grpAdmin";
		this.grpAdmin.Size = new System.Drawing.Size (353, 52);
		this.grpAdmin.TabIndex = 9;
		this.grpAdmin.TabStop = false;
		this.grpAdmin.Text = "Administration";
		this.cmdRegistry.Location = new System.Drawing.Point (243, 21);
		this.cmdRegistry.Name = "cmdRegistry";
		this.cmdRegistry.Size = new System.Drawing.Size (100, 25);
		this.cmdRegistry.TabIndex = 12;
		this.cmdRegistry.Text = "Automate Clients";
		this.cmdRegistry.UseVisualStyleBackColor = true;
		this.cmdRefresh.Location = new System.Drawing.Point (132, 21);
		this.cmdRefresh.Name = "cmdRefresh";
		this.cmdRefresh.Size = new System.Drawing.Size (100, 25);
		this.cmdRefresh.TabIndex = 11;
		this.cmdRefresh.Text = "Refresh License";
		this.cmdRefresh.UseVisualStyleBackColor = true;
		this.cmdActivate.Location = new System.Drawing.Point (11, 21);
		this.cmdActivate.Name = "cmdActivate";
		this.cmdActivate.Size = new System.Drawing.Size (110, 25);
		this.cmdActivate.TabIndex = 10;
		this.cmdActivate.Text = "Activate License";
		this.cmdActivate.UseVisualStyleBackColor = true;
		this.lblInformation.Location = new System.Drawing.Point (12, 279);
		this.lblInformation.Name = "lblInformation";
		this.lblInformation.Size = new System.Drawing.Size (347, 59);
		this.lblInformation.TabIndex = 13;
		this.lblInformation.Text = resources.GetString ("lblInformation.Text");
		this.txtCompany.ForeColor = System.Drawing.SystemColors.ControlText;
		this.txtCompany.Location = new System.Drawing.Point (85, 7);
		this.txtCompany.MaxLength = 40;
		this.txtCompany.Name = "txtCompany";
		this.txtCompany.Size = new System.Drawing.Size (244, 20);
		this.txtCompany.TabIndex = 1;
		this.lblCompany.AutoSize = true;
		this.lblCompany.Location = new System.Drawing.Point (12, 10);
		this.lblCompany.Name = "lblCompany";
		this.lblCompany.Size = new System.Drawing.Size (54, 13);
		this.lblCompany.TabIndex = 0;
		this.lblCompany.Text = "Company:";
		this.cmdHelp.Enabled = false;
		this.cmdHelp.Location = new System.Drawing.Point (29, 420);
		this.cmdHelp.Name = "cmdHelp";
		this.cmdHelp.Size = new System.Drawing.Size (100, 25);
		this.cmdHelp.TabIndex = 21;
		this.cmdHelp.Text = "&Help";
		this.cmdHelp.UseVisualStyleBackColor = true;
		this.cmdLogFile.Location = new System.Drawing.Point (140, 172);
		this.cmdLogFile.Name = "cmdLogFile";
		this.cmdLogFile.Size = new System.Drawing.Size (100, 25);
		this.cmdLogFile.TabIndex = 24;
		this.cmdLogFile.Text = "View Usage Log";
		this.cmdLogFile.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdClose;
		base.ClientSize = new System.Drawing.Size (373, 451);
		base.Controls.Add (this.cmdLogFile);
		base.Controls.Add (this.cmdHelp);
		base.Controls.Add (this.lblCompany);
		base.Controls.Add (this.txtCompany);
		base.Controls.Add (this.lblPortal);
		base.Controls.Add (this.lnkPortal);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdActivateNow);
		base.Controls.Add (this.txtPassword);
		base.Controls.Add (this.lblPassword);
		base.Controls.Add (this.txtLicenseID);
		base.Controls.Add (this.lblLicenseID);
		base.Controls.Add (this.cmdClose);
		base.Controls.Add (this.cmdAcquire);
		base.Controls.Add (this.txtStatus);
		base.Controls.Add (this.cmdBrowse);
		base.Controls.Add (this.txtFolder);
		base.Controls.Add (this.lblFolder);
		base.Controls.Add (this.grpAdmin);
		base.Controls.Add (this.lblInformation);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLicenseNetwork";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Network License Settings";
		this.grpAdmin.ResumeLayout (false);
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void ReloadLicense ()
	{
		CFS.NetworkLicenseConfig.LicenseFilePath = txtFolder.Text;
		CFS.NetworkLicenseConfig.CompanyName = txtCompany.Text.Trim ();
		CFS.NetworkLicense = new CFSLicense (CFS.NetworkLicenseConfig);
		if (CFS.NetworkLicense.LoadFile (CFS.NetworkLicenseConfig.LicenseFilePath) && CFS.NetworkLicense.Validate ()) {
			Cursor = Cursors.WaitCursor;
			if (CFS.LicenseSemaphore != null) {
				CFS.LicenseSemaphore.Close ();
				CFS.LicenseSemaphore = null;
				CFS.NetworkLicenseConfig.AppendLog ("Released");
			}
			CFS.LicenseSemaphore = new CFSSemaphore (Path.GetDirectoryName (CFS.NetworkLicenseConfig.LicenseFilePath), CFS.NetworkLicenseConfig.NetworkSemaphorePrefix, CFS.NetworkLicense.LicenseCounter, blnRunValidation: true, 15, blnRunCleanup: true);
			if (CFS.LicenseSemaphore.Open ()) {
				if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
					CFS.SingleLicenseConfig.AppendLog ("Released");
				}
				CFS.NetworkLicenseConfig.AppendLog ("Acquired", CFS.LicenseSemaphore);
				CFS.intLicenseType = CFS.LicenseTypes.Semaphore;
				CFS.NetworkLicenseConfig.PathRegistryValue = txtFolder.Text;
				CFS.NetworkLicenseConfig.CompanyRegistryValue = txtCompany.Text.Trim ();
				CFS.User.Company = txtCompany.Text.Trim ();
			} else if (CFS.LicenseSemaphore.LastError.ErrorNumber == 9211) {
				if (CFS.LicenseSemaphore.GetUnusedNetworkLicense ()) {
					if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
						CFS.SingleLicenseConfig.AppendLog ("Released");
					}
					CFS.intLicenseType = CFS.LicenseTypes.Semaphore;
					CFS.NetworkLicenseConfig.PathRegistryValue = txtFolder.Text;
					CFS.NetworkLicenseConfig.CompanyRegistryValue = txtCompany.Text.Trim ();
					CFS.User.Company = txtCompany.Text.Trim ();
				} else {
					CFS.LicenseSemaphore = null;
				}
			} else {
				CFS.NetworkLicenseConfig.AppendLog ("Error " + Conversions.ToString (CFS.LicenseSemaphore.LastError.ErrorNumber), CFS.LicenseSemaphore);
				CFS.LicenseSemaphore = null;
			}
			Cursor = Cursors.Default;
		} else if (CFS.LicenseSemaphore != null) {
			CFS.NetworkLicenseConfig.AppendLog ("Invalid", CFS.LicenseSemaphore);
			CFS.LicenseSemaphore.Close ();
			CFS.LicenseSemaphore = null;
		}
		if ((CFS.LicenseSemaphore == null) & (CFS.intLicenseType == CFS.LicenseTypes.Semaphore)) {
			CFS.intLicenseType = CFS.LicenseTypes.None;
		}
	}

	private void RefreshForm ()
	{
		blnActive = false;
		if (CFS.NetworkLicense != null) {
			if (CFS.NetworkLicense.LastError.ErrorNumber == 0) {
				if (CFS.LicenseSemaphore != null) {
					if (CFS.LicenseSemaphore.LastError.ErrorNumber == 0) {
						txtStatus.Text = CFS.NetworkLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: true) + "\r\n" + CFS.LicenseSemaphore.SeatsActive + " out of " + CFS.NetworkLicense.LicenseCounter + " seats in use.";
						blnActive = true;
					} else {
						txtStatus.Text = CFS.NetworkLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: false) + "\r\n" + CFS.LicenseSemaphore.LastError.ToString ();
					}
				} else {
					txtStatus.Text = "Network license not established.\r\n" + CFS.NetworkLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: false);
				}
			} else {
				txtStatus.Text = "Network license not established.\r\n" + CFS.NetworkLicense.GenerateLicenseStatusEntry (lastValidationSuccessful: false);
			}
			cmdRefresh.Enabled = CFS.NetworkLicense.LicenseID > 0;
		} else {
			txtStatus.Text = "Network license not established.";
			cmdRefresh.Enabled = false;
		}
		if (blnActive) {
			txtCompany.ReadOnly = true;
			txtFolder.ReadOnly = true;
			cmdBrowse.Enabled = false;
			cmdAcquire.Enabled = false;
			cmdRegistry.Enabled = true;
			cmdClose.Focus ();
			cmdActivate.Text = "Deactivate License";
		} else {
			txtCompany.ReadOnly = false;
			txtFolder.ReadOnly = false;
			cmdBrowse.Enabled = true;
			cmdAcquire.Enabled = true;
			cmdRegistry.Enabled = false;
			cmdBrowse.Focus ();
			cmdActivate.Text = "Activate License";
		}
	}

	private bool CheckCompany (string strCompany)
	{
		if (strCompany.Replace (" ", "").Length < 4) {
			Interaction.MsgBox ("Company name must contain at least 4 characters", MsgBoxStyle.Exclamation);
			return false;
		}
		return true;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private bool CheckFolder (string strFolder)
	{
		if (!strFolder.StartsWith ("\\\\")) {
			Interaction.MsgBox ("Folder must be specified using a UNC path such as: \\\\server\\folder", MsgBoxStyle.Exclamation);
			return false;
		}
		if (!Directory.Exists (strFolder)) {
			Interaction.MsgBox ("Folder does not exist.", MsgBoxStyle.Exclamation);
			return false;
		}
		try {
			string pathRoot = Path.GetPathRoot (strFolder);
			Dns.GetHostAddresses (pathRoot.Remove (pathRoot.LastIndexOf ("\\")).Replace ("\\\\", ""));
		} catch (Exception ex) {
			ProjectData.SetProjectError (ex);
			Exception ex2 = ex;
			Interaction.MsgBox ("Server cannot be resolved to an IP address.", MsgBoxStyle.Exclamation);
			bool result = false;
			ProjectData.ClearProjectError ();
			return result;
		}
		try {
			int num = Microsoft.VisualBasic.FileSystem.FreeFile ();
			string text = Path.Combine (strFolder, "~tempfile.tmp");
			Microsoft.VisualBasic.FileSystem.FileOpen (num, text, OpenMode.Output);
			Microsoft.VisualBasic.FileSystem.Print (num, "Test line.");
			Microsoft.VisualBasic.FileSystem.FileClose (num);
			Microsoft.VisualBasic.FileSystem.Kill (text);
			return true;
		} catch (Exception ex3) {
			ProjectData.SetProjectError (ex3);
			Exception ex4 = ex3;
			Interaction.MsgBox ("You do not have read/write permission for this folder.", MsgBoxStyle.Exclamation);
			bool result = false;
			ProjectData.ClearProjectError ();
			return result;
		}
	}

	private void frmLicenseNetwork_Load (object sender, EventArgs e)
	{
		base.Height = checked(grpAdmin.Top + grpAdmin.Height + 8 + (base.Height - base.ClientSize.Height));
		txtCompany.Text = CFS.User.Company;
		string pathRegistryValue = CFS.NetworkLicenseConfig.PathRegistryValue;
		if (Operators.CompareString (pathRegistryValue, string.Empty, TextCompare: false) == 0) {
			txtFolder.ForeColor = Color.DarkGray;
			txtFolder.Text = "Example: \\\\server\\share";
		} else {
			txtFolder.Text = pathRegistryValue;
		}
		RefreshForm ();
	}

	private void frmLicenseNetwork_Shown (object sender, EventArgs e)
	{
		if (cmdBrowse.Enabled) {
			cmdBrowse.Focus ();
		} else {
			cmdClose.Focus ();
		}
		lnkPortal.Left = checked(lblPortal.Left + lblPortal.Width);
	}

	private void frmLicenseNetwork_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "network-license.htm");
		e.Cancel = true;
	}

	private void txtFolder_GotFocus (object sender, EventArgs e)
	{
		if (Operators.CompareString (txtFolder.Text, "Example: \\\\server\\share", TextCompare: false) == 0) {
			txtFolder.Text = string.Empty;
			txtFolder.ForeColor = SystemColors.WindowText;
		}
	}

	private void txtFolder_LostFocus (object sender, EventArgs e)
	{
		if (Operators.CompareString (txtFolder.Text, string.Empty, TextCompare: false) == 0) {
			txtFolder.ForeColor = Color.DarkGray;
			txtFolder.Text = "Example: \\\\server\\share";
		}
	}

	private void cmdBrowse_Click (object sender, EventArgs e)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog ();
		if (folderBrowserDialog.ShowDialog () == DialogResult.OK) {
			txtFolder.Text = folderBrowserDialog.SelectedPath;
			txtFolder.ForeColor = SystemColors.WindowText;
			if (cmdAcquire.Enabled) {
				cmdAcquire.Focus ();
			}
		}
	}

	private void cmdAcquire_Click (object sender, EventArgs e)
	{
		if (CheckCompany (txtCompany.Text) && CheckFolder (txtFolder.Text)) {
			ReloadLicense ();
			RefreshForm ();
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void cmdLogFile_Click (object sender, EventArgs e)
	{
		string text = txtFolder.Text;
		if (CheckFolder (text)) {
			text += "\\CFSLicense.log";
			if (File.Exists (text)) {
				int num = Microsoft.VisualBasic.FileSystem.FreeFile ();
				Microsoft.VisualBasic.FileSystem.FileOpen (num, text, OpenMode.Binary, OpenAccess.Read);
				string Value = Strings.Space (checked((int)Microsoft.VisualBasic.FileSystem.LOF (num)));
				Microsoft.VisualBasic.FileSystem.FileGet (num, ref Value, -1L);
				Microsoft.VisualBasic.FileSystem.FileClose (num);
				frmViewText obj = My.MyProject.Forms.frmViewText;
				obj.Size = new Size (400, 300);
				obj.Text = text;
				obj.txtView.Text = Value;
				obj.txtView.SelectionStart = Strings.Len (Value);
				obj.ShowDialog (this);
				obj.Dispose ();
				_ = null;
			} else {
				Interaction.MsgBox ("Log file does not exist in that folder.", MsgBoxStyle.Information);
			}
		}
	}

	private void frmLicenseNetwork_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void frmLicenseNetwork_KeyDown (object sender, KeyEventArgs e)
	{
		if (((e.KeyCode == Keys.R) & e.Shift & e.Control & !e.Alt & blnActive) && Interaction.MsgBox (string.Concat (string.Concat ("Releasing the license will remove your network license settings. " + "This should only be done to switch to 'light mode'. ", "To free up the license for others to use, just close CFS.\r\n\r\n"), "Are you sure you want to release the license?"), MsgBoxStyle.Exclamation | MsgBoxStyle.YesNo) != MsgBoxResult.No) {
			if (CFS.LicenseSemaphore != null) {
				CFS.LicenseSemaphore.Close ();
				CFS.LicenseSemaphore = null;
			}
			CFS.NetworkLicenseConfig.AppendLog ("Released");
			CFS.intLicenseType = CFS.LicenseTypes.None;
			CFS.NetworkLicenseConfig.LicenseFilePath = string.Empty;
			CFS.NetworkLicenseConfig.PathRegistryValue = string.Empty;
			CFS.NetworkLicense = null;
			RefreshForm ();
		}
	}

	private void cmdActivate_Click (object sender, EventArgs e)
	{
		_ = txtFolder.Text;
		if (CFS.intLicenseType == CFS.LicenseTypes.Semaphore) {
			if (Interaction.MsgBox ("CAUTION: There are a limited number of deactivations.\r\nAre you sure you want to deactivate this license?", MsgBoxStyle.Exclamation | MsgBoxStyle.YesNo) != MsgBoxResult.No) {
				cmdActivate.Enabled = false;
				Cursor = Cursors.WaitCursor;
				bool num = CFS.NetworkLicense.DeactivateOnline ();
				Cursor = Cursors.Default;
				cmdActivate.Enabled = true;
				if (num) {
					CFS.NetworkLicenseConfig.AppendLog ("Deactivated");
					Interaction.MsgBox ("The license has been deactivated.", MsgBoxStyle.Information);
				} else {
					Interaction.MsgBox ("Deactivation Failed.\r\n\r\n" + CFS.NetworkLicense.GenerateLicenseErrorString (), MsgBoxStyle.Exclamation);
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
			cmdAcquire.Enabled = false;
			cmdActivate.Enabled = false;
			cmdClose.Enabled = false;
			base.Height = checked(cmdActivateNow.Top + cmdActivateNow.Height + 8 + (base.Height - base.ClientSize.Height));
			if (CFS.NetworkLicense != null && CFS.NetworkLicense.LicenseID > 0) {
				txtLicenseID.Text = CFS.NetworkLicense.LicenseID.ToString ();
				txtPassword.Focus ();
			} else {
				txtLicenseID.Focus ();
			}
		}
	}

	private void cmdRefresh_Click (object sender, EventArgs e)
	{
		if (CFS.NetworkLicense.RefreshLicense ()) {
			CFS.NetworkLicenseConfig.AppendLog ("Refreshed", CFS.LicenseSemaphore);
			Interaction.MsgBox ("The license has been refreshed successfully.", MsgBoxStyle.Information);
			ReloadLicense ();
		} else {
			Interaction.MsgBox ("The license was not refreshed.  Error: (" + Conversions.ToString (CFS.NetworkLicense.LastError.ErrorNumber) + ")" + CFS.NetworkLicense.LastError.ErrorString, MsgBoxStyle.Information);
		}
		RefreshForm ();
	}

	private void cmdRegistry_Click (object sender, EventArgs e)
	{
		string obj = string.Concat (string.Concat (string.Concat (string.Concat (string.Concat ("Windows Registry Editor Version 5.00\r\n\r\n" + ";Distribute this registry key to each client machine where CFS will run.\r\n", ";Then download and install CFS on each machine to use with your network licenses.\r\n"), "[HKEY_CURRENT_USER\\SOFTWARE\\RSG Software, Inc.]\r\n"), "\"NetworkLicenseShare\"=\"", txtFolder.Text.Replace ("\\", "\\\\"), "\"\r\n"), "[HKEY_CURRENT_USER\\SOFTWARE\\RSG Software, Inc.\\CFS\\Heading]\r\n"), "\"Hdg1\"=\"", txtCompany.Text.Trim (), "\"\r\n");
		Clipboard.Clear ();
		Clipboard.SetText (obj);
		Interaction.MsgBox ("The contents of a Registry file is on the Windows Clipboard. " + "Paste it into a text editor and save as a .reg file for others to use.");
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
		string text = txtFolder.Text.Trim ();
		int result = 0;
		string text2 = txtPassword.Text;
		if (!CheckCompany (txtCompany.Text)) {
			txtCompany.Focus ();
			return;
		}
		if (!CheckFolder (text)) {
			txtFolder.Focus ();
			return;
		}
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
		if (text2.Length == 0) {
			Interaction.MsgBox ("Please enter your password.", MsgBoxStyle.Exclamation);
			txtPassword.Focus ();
			return;
		}
		if (Microsoft.VisualBasic.FileIO.FileSystem.FileExists (Path.Combine (text, "CFSLicense.lfx"))) {
			Interaction.MsgBox ("License file already exists in " + text + ".\r\nUse Acquire License rather than Activate.", MsgBoxStyle.Exclamation);
			txtFolder.Focus ();
			return;
		}
		string optionName = GetLicenseInfo (result, text2, LicenseConfiguration.ThisProductID).OptionName;
		if ((optionName.Length > 0) & !optionName.ToLower ().Contains ("network")) {
			Interaction.MsgBox ("The License ID is not for a network license.", MsgBoxStyle.Exclamation);
			return;
		}
		cmdActivateNow.Enabled = false;
		Cursor = Cursors.WaitCursor;
		CFS.NetworkLicenseConfig.LicenseFilePath = text;
		CFS.NetworkLicenseConfig.CompanyName = txtCompany.Text.Trim ();
		CFS.NetworkLicense = new CFSLicense (CFS.NetworkLicenseConfig);
		CFS.NetworkLicense.InstallationName = text;
		bool num = CFS.NetworkLicense.ActivateOnline (result, text2);
		Cursor = Cursors.Default;
		cmdActivateNow.Enabled = true;
		if (num) {
			CFS.NetworkLicenseConfig.AppendLog ("Activated", CFS.LicenseSemaphore);
			Interaction.MsgBox ("Activation Successful!", MsgBoxStyle.Information);
			CloseActivation ();
			ReloadLicense ();
			RefreshForm ();
		} else {
			Interaction.MsgBox ("Activation Failed.\r\n\r\n" + CFS.NetworkLicense.GenerateLicenseErrorString (), MsgBoxStyle.Exclamation);
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
		base.Height = checked(grpAdmin.Top + grpAdmin.Height + 8 + (base.Height - base.ClientSize.Height));
		txtLicenseID.Enabled = false;
		txtPassword.Enabled = false;
		cmdHelp.Enabled = false;
		cmdActivateNow.Enabled = false;
		cmdCancel.Enabled = false;
		cmdAcquire.Enabled = true;
		cmdActivate.Enabled = true;
		cmdClose.Enabled = true;
	}
}
