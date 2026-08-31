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
public class frmWelcome : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("lblWelcome")]
	internal virtual Label lblWelcome {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblMessage")]
	internal virtual Label lblMessage {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdLightMode {
		[CompilerGenerated]
		get {
			return _cmdLightMode;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdLightMode_Click;
			Button button = _cmdLightMode;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdLightMode = value;
			button = _cmdLightMode;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdSingleUser {
		[CompilerGenerated]
		get {
			return _cmdSingleUser;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdSingleUser_Click;
			Button button = _cmdSingleUser;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdSingleUser = value;
			button = _cmdSingleUser;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdNetwork {
		[CompilerGenerated]
		get {
			return _cmdNetwork;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdNetwork_Click;
			Button button = _cmdNetwork;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdNetwork = value;
			button = _cmdNetwork;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdPurchase {
		[CompilerGenerated]
		get {
			return _cmdPurchase;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdPurchase_Click;
			Button button = _cmdPurchase;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdPurchase = value;
			button = _cmdPurchase;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	public frmWelcome ()
	{
		base.Load += frmWelcome_Load;
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
		this.lblWelcome = new System.Windows.Forms.Label ();
		this.lblMessage = new System.Windows.Forms.Label ();
		this.cmdLightMode = new System.Windows.Forms.Button ();
		this.cmdSingleUser = new System.Windows.Forms.Button ();
		this.cmdNetwork = new System.Windows.Forms.Button ();
		this.cmdPurchase = new System.Windows.Forms.Button ();
		base.SuspendLayout ();
		this.lblWelcome.Font = new System.Drawing.Font ("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblWelcome.Location = new System.Drawing.Point (7, 8);
		this.lblWelcome.Name = "lblWelcome";
		this.lblWelcome.Size = new System.Drawing.Size (380, 26);
		this.lblWelcome.TabIndex = 0;
		this.lblWelcome.Text = "Welcome to CFS!";
		this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblMessage.Font = new System.Drawing.Font ("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMessage.Location = new System.Drawing.Point (7, 45);
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.Size = new System.Drawing.Size (380, 198);
		this.lblMessage.TabIndex = 1;
		this.lblMessage.Text = "Message";
		this.cmdLightMode.Location = new System.Drawing.Point (12, 246);
		this.cmdLightMode.Name = "cmdLightMode";
		this.cmdLightMode.Size = new System.Drawing.Size (160, 25);
		this.cmdLightMode.TabIndex = 2;
		this.cmdLightMode.Text = "&Continue in Light Mode";
		this.cmdLightMode.UseVisualStyleBackColor = true;
		this.cmdSingleUser.Location = new System.Drawing.Point (222, 246);
		this.cmdSingleUser.Name = "cmdSingleUser";
		this.cmdSingleUser.Size = new System.Drawing.Size (160, 25);
		this.cmdSingleUser.TabIndex = 4;
		this.cmdSingleUser.Text = "Activate &Single User License";
		this.cmdSingleUser.UseVisualStyleBackColor = true;
		this.cmdNetwork.Location = new System.Drawing.Point (222, 277);
		this.cmdNetwork.Name = "cmdNetwork";
		this.cmdNetwork.Size = new System.Drawing.Size (160, 25);
		this.cmdNetwork.TabIndex = 5;
		this.cmdNetwork.Text = "Activate &Network License";
		this.cmdNetwork.UseVisualStyleBackColor = true;
		this.cmdPurchase.Location = new System.Drawing.Point (12, 277);
		this.cmdPurchase.Name = "cmdPurchase";
		this.cmdPurchase.Size = new System.Drawing.Size (160, 25);
		this.cmdPurchase.TabIndex = 3;
		this.cmdPurchase.Text = "&Purchase License";
		this.cmdPurchase.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (394, 312);
		base.ControlBox = false;
		base.Controls.Add (this.cmdPurchase);
		base.Controls.Add (this.cmdNetwork);
		base.Controls.Add (this.cmdSingleUser);
		base.Controls.Add (this.cmdLightMode);
		base.Controls.Add (this.lblMessage);
		base.Controls.Add (this.lblWelcome);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmWelcome";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.ResumeLayout (false);
	}

	private void frmWelcome_Load (object sender, EventArgs e)
	{
		lblMessage.Text = "CFS is a comprehensive general-purpose cold-formed steel component design application that performs calculations according to the AISI North American Specification for the Design of Cold-Formed Steel Structural Members, and the ASCE Specification for the Design of Cold-Formed Stainless Steel Structural Members.\r\n\r\nCFS is running in the free Light Mode with a reduced set of features and limitations on section complexity. To enable the full capabilities of CFS, purchase and activate a full license.";
		if (CFS.IsRemoteSession ()) {
			cmdSingleUser.Enabled = false;
		}
	}

	private void cmdLightMode_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private void cmdSingleUser_Click (object sender, EventArgs e)
	{
		Hide ();
		My.MyProject.Forms.frmLicenseSingle.ShowDialog (My.MyProject.Forms.mdiCFS);
		My.MyProject.Forms.frmLicenseSingle.Dispose ();
		Close ();
	}

	private void cmdNetwork_Click (object sender, EventArgs e)
	{
		Hide ();
		My.MyProject.Forms.frmLicenseNetwork.ShowDialog (My.MyProject.Forms.mdiCFS);
		My.MyProject.Forms.frmLicenseNetwork.Dispose ();
		Close ();
	}

	private void cmdPurchase_Click (object sender, EventArgs e)
	{
		if (!CFS.Launch ("https://secure.softwarekey.com/solo/products/Product.aspx?ProductID=411592")) {
			Interaction.MsgBox ("Unable to launch the product catalog web page.\r\n\r\n" + "For additional ordering information, visit www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}
}
