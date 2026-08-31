// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

[DesignerGenerated]
public class frmViewText : Form
{
	private IContainer components;

	[field: AccessedThroughProperty ("txtView")]
	internal virtual TextBox txtView {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmViewText ()
	{
		base.Shown += frmViewText_Shown;
		base.Resize += frmViewText_Resize;
		base.PreviewKeyDown += frmViewText_PreviewKeyDown;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmViewText));
		this.txtView = new System.Windows.Forms.TextBox ();
		base.SuspendLayout ();
		this.txtView.Font = new System.Drawing.Font ("Consolas", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtView.Location = new System.Drawing.Point (0, 0);
		this.txtView.Multiline = true;
		this.txtView.Name = "txtView";
		this.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtView.Size = new System.Drawing.Size (742, 411);
		this.txtView.TabIndex = 0;
		this.txtView.WordWrap = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (800, 450);
		base.Controls.Add (this.txtView);
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size (200, 100);
		base.Name = "frmViewText";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Text Viewer";
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void frmViewText_Shown (object sender, EventArgs e)
	{
		frmViewText_Resize (this, null);
	}

	private void frmViewText_Resize (object sender, EventArgs e)
	{
		txtView.Height = base.ClientSize.Height;
		txtView.Width = base.ClientSize.Width;
		txtView.ScrollToCaret ();
	}

	private void frmViewText_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void frmLicenseNetwork_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape) {
			Close ();
		}
	}
}
