// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using RSG.CFS;

[DesignerGenerated]
public class frmAbout : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("picIcon")]
	internal virtual PictureBox picIcon {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblTitle")]
	internal virtual Label lblTitle {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblDescription")]
	internal virtual Label lblDescription {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty ("grpDisclaimer")]
	internal virtual GroupBox grpDisclaimer {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblDisclaimer")]
	internal virtual Label lblDisclaimer {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmAbout ()
	{
		base.Load += frmAbout_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmAbout));
		this.picIcon = new System.Windows.Forms.PictureBox ();
		this.lblTitle = new System.Windows.Forms.Label ();
		this.lblDescription = new System.Windows.Forms.Label ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.grpDisclaimer = new System.Windows.Forms.GroupBox ();
		this.lblDisclaimer = new System.Windows.Forms.Label ();
		((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit ();
		this.grpDisclaimer.SuspendLayout ();
		base.SuspendLayout ();
		this.picIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picIcon.Image = (System.Drawing.Image)resources.GetObject ("picIcon.Image");
		this.picIcon.Location = new System.Drawing.Point (15, 12);
		this.picIcon.Name = "picIcon";
		this.picIcon.Size = new System.Drawing.Size (52, 52);
		this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picIcon.TabIndex = 0;
		this.picIcon.TabStop = false;
		this.lblTitle.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.Location = new System.Drawing.Point (81, 13);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size (341, 66);
		this.lblTitle.TabIndex = 1;
		this.lblTitle.Text = "Application Title";
		this.lblDescription.Location = new System.Drawing.Point (81, 90);
		this.lblDescription.Name = "lblDescription";
		this.lblDescription.Size = new System.Drawing.Size (308, 90);
		this.lblDescription.TabIndex = 2;
		this.lblDescription.Text = "Cold-Formed Steel Design Software";
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdOK.Location = new System.Drawing.Point (299, 198);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (100, 25);
		this.cmdOK.TabIndex = 4;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.grpDisclaimer.Controls.Add (this.lblDisclaimer);
		this.grpDisclaimer.Location = new System.Drawing.Point (10, 172);
		this.grpDisclaimer.Name = "grpDisclaimer";
		this.grpDisclaimer.Size = new System.Drawing.Size (259, 63);
		this.grpDisclaimer.TabIndex = 5;
		this.grpDisclaimer.TabStop = false;
		this.lblDisclaimer.Location = new System.Drawing.Point (6, 11);
		this.lblDisclaimer.Name = "lblDisclaimer";
		this.lblDisclaimer.Size = new System.Drawing.Size (245, 49);
		this.lblDisclaimer.TabIndex = 4;
		this.lblDisclaimer.Text = "Warning";
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdOK;
		base.ClientSize = new System.Drawing.Size (423, 244);
		base.Controls.Add (this.grpDisclaimer);
		base.Controls.Add (this.cmdOK);
		base.Controls.Add (this.lblDescription);
		base.Controls.Add (this.lblTitle);
		base.Controls.Add (this.picIcon);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAbout";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "About CFS";
		((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit ();
		this.grpDisclaimer.ResumeLayout (false);
		base.ResumeLayout (false);
	}

	private void frmAbout_Load (object sender, EventArgs e)
	{
		string empty = string.Empty;
		empty = ((CFS.intLicenseType == CFS.LicenseTypes.Sublicense) ? "Sublicense" : ((CFS.intLicenseType == CFS.LicenseTypes.SingleUser) ? ("Single User License, expires " + Conversions.ToString (CFS.SingleLicense.EffectiveEndDate.ToLocalTime ().Date)) : ((CFS.intLicenseType != CFS.LicenseTypes.Semaphore) ? "Light mode" : ("Network License, expires " + Conversions.ToString (CFS.NetworkLicense.EffectiveEndDate.ToLocalTime ().Date)))));
		lblTitle.Text = "CFS® " + CFS.AppVer (1400) + " " + empty + "\nCopyright © 1988-2023 RSG Software, Inc.\nCFS is a registered trademark of RSG Software, Inc.\nwww.rsgsoftware.com";
		lblDescription.Text = "General purpose cold-formed steel component design software that performs calculations in accordance with the AISI North American Specification for the Design of Cold-Formed Steel Structural Members, and the ASCE Specification for the Design of Cold-Formed Stainless Steel Structural Members.";
		lblDisclaimer.Text = "Notice: The interpretation of the output and the application of such data is solely the responsibility of the user.";
	}

	private void cmdOK_Click (object sender, EventArgs e)
	{
		Close ();
	}
}
