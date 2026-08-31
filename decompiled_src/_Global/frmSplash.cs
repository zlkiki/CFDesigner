// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class frmSplash : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("picSplash")]
	internal virtual PictureBox picSplash {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblApplication")]
	internal virtual Label lblApplication {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblCopyright")]
	internal virtual Label lblCopyright {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblTrademark")]
	internal virtual Label lblTrademark {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmSplash ()
	{
		base.Load += frmSplash_Load;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmSplash));
		this.picSplash = new System.Windows.Forms.PictureBox ();
		this.lblApplication = new System.Windows.Forms.Label ();
		this.lblCopyright = new System.Windows.Forms.Label ();
		this.lblTrademark = new System.Windows.Forms.Label ();
		((System.ComponentModel.ISupportInitialize)this.picSplash).BeginInit ();
		base.SuspendLayout ();
		this.picSplash.Image = (System.Drawing.Image)resources.GetObject ("picSplash.Image");
		this.picSplash.Location = new System.Drawing.Point (0, 0);
		this.picSplash.Name = "picSplash";
		this.picSplash.Size = new System.Drawing.Size (410, 360);
		this.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picSplash.TabIndex = 0;
		this.picSplash.TabStop = false;
		this.lblApplication.BackColor = System.Drawing.Color.Transparent;
		this.lblApplication.Font = new System.Drawing.Font ("Times New Roman", 20f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblApplication.Location = new System.Drawing.Point (48, 284);
		this.lblApplication.Name = "lblApplication";
		this.lblApplication.Size = new System.Drawing.Size (325, 40);
		this.lblApplication.TabIndex = 1;
		this.lblApplication.Text = "Version 12";
		this.lblApplication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
		this.lblCopyright.Font = new System.Drawing.Font ("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCopyright.Location = new System.Drawing.Point (48, 332);
		this.lblCopyright.Name = "lblCopyright";
		this.lblCopyright.Size = new System.Drawing.Size (325, 19);
		this.lblCopyright.TabIndex = 2;
		this.lblCopyright.Text = "Copyright © 1988-2023 RSG Software, Inc.";
		this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblTrademark.AutoSize = true;
		this.lblTrademark.BackColor = System.Drawing.Color.Transparent;
		this.lblTrademark.Font = new System.Drawing.Font ("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTrademark.Location = new System.Drawing.Point (371, 43);
		this.lblTrademark.Name = "lblTrademark";
		this.lblTrademark.Size = new System.Drawing.Size (20, 20);
		this.lblTrademark.TabIndex = 3;
		this.lblTrademark.Text = "®";
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size (410, 360);
		base.ControlBox = false;
		base.Controls.Add (this.lblTrademark);
		base.Controls.Add (this.lblCopyright);
		base.Controls.Add (this.lblApplication);
		base.Controls.Add (this.picSplash);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSplash";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.TopMost = true;
		((System.ComponentModel.ISupportInitialize)this.picSplash).EndInit ();
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmSplash_Load (object sender, EventArgs e)
	{
		lblApplication.Parent = picSplash;
		lblCopyright.Parent = picSplash;
		lblTrademark.Parent = picSplash;
		lblApplication.Text = "Version " + Conversions.ToString (14);
	}
}
