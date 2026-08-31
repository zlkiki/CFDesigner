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
public class frmLicenseRequired : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("PictureBox1")]
	internal virtual PictureBox PictureBox1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("Panel1")]
	internal virtual Panel Panel1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("cmdOK")]
	internal virtual Button cmdOK {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
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

	[field: AccessedThroughProperty ("lblMessage")]
	internal virtual Label lblMessage {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmLicenseRequired ()
	{
		base.Load += frmLicenseRequired_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmLicenseRequired));
		this.PictureBox1 = new System.Windows.Forms.PictureBox ();
		this.Panel1 = new System.Windows.Forms.Panel ();
		this.cmdOK = new System.Windows.Forms.Button ();
		this.cmdPurchase = new System.Windows.Forms.Button ();
		this.lblMessage = new System.Windows.Forms.Label ();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit ();
		this.Panel1.SuspendLayout ();
		base.SuspendLayout ();
		this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject ("PictureBox1.Image");
		this.PictureBox1.Location = new System.Drawing.Point (21, 21);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size (32, 32);
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.Panel1.BackColor = System.Drawing.SystemColors.Control;
		this.Panel1.Controls.Add (this.cmdOK);
		this.Panel1.Controls.Add (this.cmdPurchase);
		this.Panel1.Location = new System.Drawing.Point (0, 88);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size (388, 44);
		this.Panel1.TabIndex = 0;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdOK.Location = new System.Drawing.Point (296, 10);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.Size = new System.Drawing.Size (80, 25);
		this.cmdOK.TabIndex = 0;
		this.cmdOK.Text = "OK";
		this.cmdOK.UseVisualStyleBackColor = true;
		this.cmdPurchase.Location = new System.Drawing.Point (132, 10);
		this.cmdPurchase.Name = "cmdPurchase";
		this.cmdPurchase.Size = new System.Drawing.Size (131, 25);
		this.cmdPurchase.TabIndex = 1;
		this.cmdPurchase.Text = "Purchase License";
		this.cmdPurchase.UseVisualStyleBackColor = true;
		this.lblMessage.Location = new System.Drawing.Point (59, 9);
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.Size = new System.Drawing.Size (317, 55);
		this.lblMessage.TabIndex = 1;
		this.lblMessage.Text = "Message";
		this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		base.AcceptButton = this.cmdOK;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Window;
		base.CancelButton = this.cmdOK;
		base.ClientSize = new System.Drawing.Size (388, 132);
		base.Controls.Add (this.lblMessage);
		base.Controls.Add (this.Panel1);
		base.Controls.Add (this.PictureBox1);
		this.Font = new System.Drawing.Font ("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmLicenseRequired";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "CFS License Required";
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit ();
		this.Panel1.ResumeLayout (false);
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmLicenseRequired_Load (object sender, EventArgs e)
	{
		if (Strings.Len (base.Tag.ToString ()) == 0) {
			lblMessage.Text = "This feature requires a full CFS license.";
		} else {
			lblMessage.Text = base.Tag.ToString ();
		}
	}

	private void cmdPurchase_Click (object sender, EventArgs e)
	{
		if (CFS.Launch ("https://secure.softwarekey.com/solo/products/Product.aspx?ProductID=411592")) {
			Close ();
		} else {
			Interaction.MsgBox ("Unable to launch the product catalog web page.\r\n\r\n" + "For additional ordering information, visit www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}
}
