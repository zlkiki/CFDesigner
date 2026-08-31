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
using RSG.Utility;

[DesignerGenerated]
public class frmSctPicMaster : Form
{
	private IContainer components;

	private short intPartStart;

	private short intElemStart;

	private bool blnDoMouseUp;

	private short Shift;

	private float Xstart;

	private float Ystart;

	internal ScaleGraphics SG;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$Ux;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$Uy;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$U;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$Vx;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$Vy;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$V;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$W;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$A;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$A0;

	[SpecialName]
	private float $STATIC$DistanceToElement$204C1280E06CC$A1;

	internal virtual PictureBox picSct {
		[CompilerGenerated]
		get {
			return _picSct;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = picSct_PreviewKeyDown;
			MouseEventHandler value3 = picSct_MouseWheel;
			MouseEventHandler value4 = picSct_MouseDown;
			MouseEventHandler value5 = picSct_MouseMove;
			MouseEventHandler value6 = picSct_MouseUp;
			MouseEventHandler value7 = picSct_MouseDoubleClick;
			PictureBox pictureBox = _picSct;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown -= value2;
				pictureBox.MouseWheel -= value3;
				pictureBox.MouseDown -= value4;
				pictureBox.MouseMove -= value5;
				pictureBox.MouseUp -= value6;
				pictureBox.MouseDoubleClick -= value7;
			}
			_picSct = value;
			pictureBox = _picSct;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown += value2;
				pictureBox.MouseWheel += value3;
				pictureBox.MouseDown += value4;
				pictureBox.MouseMove += value5;
				pictureBox.MouseUp += value6;
				pictureBox.MouseDoubleClick += value7;
			}
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmSctPicMaster));
		this.picSct = new System.Windows.Forms.PictureBox ();
		((System.ComponentModel.ISupportInitialize)this.picSct).BeginInit ();
		base.SuspendLayout ();
		this.picSct.Location = new System.Drawing.Point (0, 0);
		this.picSct.Name = "picSct";
		this.picSct.Size = new System.Drawing.Size (425, 329);
		this.picSct.TabIndex = 0;
		this.picSct.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (426, 331);
		base.Controls.Add (this.picSct);
		this.DoubleBuffered = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size (100, 100);
		base.Name = "frmSctPicMaster";
		((System.ComponentModel.ISupportInitialize)this.picSct).EndInit ();
		base.ResumeLayout (false);
	}

	public frmSctPicMaster (byte Index)
	{
		base.Load += frmSctPicMaster_Load;
		base.Activated += frmSctPicMaster_Activated;
		base.Resize += frmSctPicMaster_Resize;
		base.Deactivate += frmSctPicMaster_Deactivate;
		base.FormClosing += frmSctPicMaster_FormClosing;
		base.FormClosed += frmSctPicMaster_FormClosed;
		base.PreviewKeyDown += frmSctPicMaster_PreviewKeyDown;
		base.KeyDown += frmSctPicMaster_KeyDown;
		base.KeyUp += frmSctPicMaster_KeyUp;
		base.MdiParent = My.MyProject.Forms.mdiCFS;
		base.Tag = Index;
		InitializeComponent ();
	}

	private void frmSctPicMaster_Load (object sender, EventArgs e)
	{
		float num = 1.16666663f;
		short num2;
		short num3;
		checked {
			num2 = (short)Math.Round (0.75 * (double)My.MyProject.Forms.mdiCFS.Height);
			num3 = (short)Math.Round (0.5 * (double)My.MyProject.Forms.mdiCFS.Width);
			if (num * (float)num3 < (float)num2) {
				num2 = (short)Math.Round (num * (float)num3);
			} else {
				num3 = (short)Math.Round ((float)num2 / num);
			}
		}
		if (num2 < 350 || num3 < 300) {
			num2 = 350;
			num3 = 300;
		}
		picSct.Top = 0;
		picSct.Left = 0;
		base.Width = num3;
		base.Height = num2;
	}

	private void frmSctPicMaster_Activated (object sender, EventArgs e)
	{
		Application.DoEvents ();
		picSct.Enabled = true;
		if (base.Enabled) {
			picSct.Select ();
		}
		CFS.intSctNow = Conversions.ToByte (base.Tag);
		if (Strings.Len (CFS.Sections [CFS.intSctNow].Filename) != 0) {
			Text = CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
			if (CFS.blnSctInpLoaded) {
				My.MyProject.Forms.frmSctInp.Text = "Section Inputs: " + Text;
			}
		} else {
			Text = Conversions.ToString (Operators.ConcatenateObject ("Section ", base.Tag));
		}
		CFS.blnRefreshGrdElements = true;
		CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		base.MaximizeBox = true;
		CFSInterface.SetMenuUndo (CFS.Sections [CFS.intSctNow]);
		CFSInterface.SetMenuFile ();
		CFSInterface.SetMenuEdit ();
		CFSInterface.SetMenuCompute ();
	}

	private void frmSctPicMaster_Resize (object sender, EventArgs e)
	{
		picSct.Width = base.ClientRectangle.Width;
		picSct.Height = base.ClientRectangle.Height;
		CFSInterface.PlotSct (this, CFS.Sections [Conversions.ToByte (base.Tag)]);
	}

	private void frmSctPicMaster_Deactivate (object sender, EventArgs e)
	{
		picSct.Enabled = false;
		base.MaximizeBox = false;
	}

	private void frmSctPicMaster_FormClosing (object sender, FormClosingEventArgs e)
	{
		byte b = Conversions.ToByte (base.Tag);
		checked {
			if (e.CloseReason == CloseReason.UserClosing) {
				short num = (short)Information.UBound (CFS.hdgAnlPic);
				for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if (!CFS.hdgAnlPic [num2].Deleted) {
						short nBeam = CFS.Analyses [num2].nBeam;
						short num3;
						for (num3 = 1; num3 <= nBeam; num3 = (short)unchecked(num3 + 1)) {
							if (CFS.Analyses [num2].Beam [num3].iSct == b) {
								short num4 = (short)Interaction.MsgBox ("Closing this section will remove member(s) from an open analysis.  Select OK to continue.", MsgBoxStyle.OkCancel | MsgBoxStyle.Information);
								if (num4 != 2) {
									break;
								}
								e.Cancel = true;
								return;
							}
						}
						if (num3 <= CFS.Analyses [num2].nBeam) {
							break;
						}
					}
				}
			}
			if (!CFS.Sections [b].Saved) {
				switch ((short)Interaction.MsgBox ("Save changes to " + Text + "?", MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question)) {
				case 6:
					if (!CFSInterface.SaveSct (b)) {
						e.Cancel = true;
					}
					break;
				case 2:
					e.Cancel = true;
					break;
				}
			}
			if (e.CloseReason != CloseReason.UserClosing || e.Cancel) {
				return;
			}
			short num5 = (short)Information.UBound (CFS.hdgAnlPic);
			for (short num2 = 1; num2 <= num5; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgAnlPic [num2].Deleted) {
					if (CFSInterface.RemoveBeam (CFS.Analyses [num2], b) & (num2 == CFS.intAnlNow)) {
						CFSInterface.SetMenuEdit ();
						CFS.blnRefreshGrdBeams = true;
						CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
					}
					int num6 = 0;
					do {
						if (!Information.IsNothing (CFS.AnlUndo [num6, num2])) {
							CFSInterface.RemoveBeam (CFS.AnlUndo [num6, num2], b);
						}
						num6++;
					} while (num6 <= 9);
				}
			}
		}
	}

	private void frmSctPicMaster_FormClosed (object sender, FormClosedEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing) {
			short num = CFSInterface.FindSctRptIndex (CFS.Sections [Conversions.ToByte (base.Tag)]);
			if (num > 0) {
				CFS.frmReport [num].Close ();
			}
		}
		CFSInterface.SetMenuUndo (null);
		CFS.hdgSctPic [Conversions.ToByte (base.Tag)].Initialize ();
		CFS.frmSctPic [Conversions.ToByte (base.Tag)].Dispose ();
		short num2 = 0;
		checked {
			do {
				CFS.SctUndo [num2, Conversions.ToByte (base.Tag)] = null;
				num2 = (short)unchecked(num2 + 1);
			} while (num2 <= 9);
			if (e.CloseReason != CloseReason.UserClosing) {
				return;
			}
			CFS.intSctNow = 0;
			for (num2 = (short)Information.UBound (CFS.hdgSctPic); num2 >= 1; num2 = (short)unchecked(num2 + -1)) {
				if (!CFS.hdgSctPic [num2].Deleted) {
					CFS.intSctNow = num2;
					CFS.frmSctPic [CFS.intSctNow].BringToFront ();
					ActivateMdiChild (CFS.frmSctPic [CFS.intSctNow]);
					break;
				}
			}
			if ((CFS.intSctNow == 0) & CFS.blnSctInpLoaded) {
				My.MyProject.Forms.frmSctInp.Close ();
			}
			short num3 = (short)(Application.OpenForms.Count - 1);
			num2 = 0;
			while (num2 <= num3 && (Application.OpenForms [num2] == this || !Application.OpenForms [num2].IsMdiChild)) {
				num2 = (short)unchecked(num2 + 1);
			}
			if (num2 > Application.OpenForms.Count - 1) {
				CFSInterface.SetMenuFile ();
				CFSInterface.SetMenuEdit ();
				CFSInterface.SetMenuCompute ();
			}
		}
	}

	private void frmSctPicMaster_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void picSct_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void frmSctPicMaster_KeyDown (object sender, KeyEventArgs e)
	{
		Shift = 0;
		checked {
			if (e.Shift) {
				ref short shift = ref Shift;
				shift = (short)unchecked(shift + 1);
			}
			if (e.Control) {
				ref short shift2 = ref Shift;
				shift2 = (short)unchecked(shift2 + 2);
			}
			if (e.Alt) {
				ref short shift3 = ref Shift;
				shift3 = (short)unchecked(shift3 + 4);
			}
			if (CFS.Sections [CFS.intSctNow].nPart == 0) {
				return;
			}
			switch (e.KeyCode) {
			case Keys.F1:
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "section-window.htm");
				e.Handled = true;
				break;
			case Keys.Prior:
			case Keys.Add: {
				Section section = CFS.Sections [CFS.intSctNow];
				if (section.Zoom < 32) {
					section.Zoom *= 2;
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				}
				section = null;
				e.Handled = true;
				break;
			}
			case Keys.Next:
			case Keys.Subtract: {
				Section section5 = CFS.Sections [CFS.intSctNow];
				if (section5.Zoom > 1) {
					section5.Zoom = (short)Math.Round ((double)section5.Zoom / 2.0);
					if (section5.Zoom == 1) {
						section5.ZoomX = 0.5f;
						section5.ZoomY = 0.5f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				}
				section5 = null;
				e.Handled = true;
				break;
			}
			case Keys.Escape:
			case Keys.Home: {
				Section obj = CFS.Sections [CFS.intSctNow];
				obj.Zoom = 1;
				obj.ZoomX = 0.5f;
				obj.ZoomY = 0.5f;
				CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				_ = null;
				e.Handled = true;
				break;
			}
			case Keys.Left:
				if (Shift == 2) {
					Section section3 = CFS.Sections [CFS.intSctNow];
					section3.ZoomX = (float)((double)section3.ZoomX - 1.0 / (double)(4 * section3.Zoom));
					if (section3.ZoomX < 0f) {
						section3.ZoomX = 0f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
					section3 = null;
					e.Handled = true;
				}
				break;
			case Keys.Right:
				if (Shift == 2) {
					Section section6 = CFS.Sections [CFS.intSctNow];
					section6.ZoomX = (float)((double)section6.ZoomX + 1.0 / (double)(4 * section6.Zoom));
					if (section6.ZoomX > 1f) {
						section6.ZoomX = 1f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
					section6 = null;
					e.Handled = true;
				}
				break;
			case Keys.Up: {
				ref GridState elemGrid3 = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
				if ((Shift == 0) & (elemGrid3.RowStart > 1)) {
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)(unchecked((int)elemGrid3.RowStart) - 1), 0);
					elemGrid3.Corner = (byte)(elemGrid3.Corner & -3);
					elemGrid3.TopRow = elemGrid3.RowStart;
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					e.Handled = true;
				} else if ((Shift == 1) & (elemGrid3.RowStart > 1)) {
					if (elemGrid3.RowStart == elemGrid3.RowEnd) {
						elemGrid3.Corner = (byte)(elemGrid3.Corner | 2);
					}
					if ((elemGrid3.Corner & 2) == 0) {
						CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid3.RowStart, (byte)(unchecked((int)elemGrid3.RowEnd) - 1));
					} else {
						CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid3.RowEnd, (byte)(unchecked((int)elemGrid3.RowStart) - 1));
					}
					elemGrid3.TopRow = elemGrid3.RowStart;
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					e.Handled = true;
				} else if (Shift == 2) {
					Section section4 = CFS.Sections [CFS.intSctNow];
					section4.ZoomY = (float)((double)section4.ZoomY + 1.0 / (double)(4 * section4.Zoom));
					if (section4.ZoomY > 1f) {
						section4.ZoomY = 1f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
					section4 = null;
					e.Handled = true;
				}
				break;
			}
			case Keys.Down: {
				ref GridState elemGrid2 = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
				if ((Shift == 0) & unchecked((uint)elemGrid2.RowStart < (uint)CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].nElem)) {
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, (byte)(unchecked((int)elemGrid2.RowStart) + 1), 0);
					elemGrid2.Corner = (byte)(elemGrid2.Corner & -3);
					elemGrid2.TopRow = elemGrid2.RowStart;
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					e.Handled = true;
				} else if ((Shift == 1) & unchecked((uint)elemGrid2.RowEnd < (uint)CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].nElem)) {
					if (elemGrid2.RowStart == elemGrid2.RowEnd) {
						elemGrid2.Corner = (byte)(elemGrid2.Corner & -3);
					}
					if ((elemGrid2.Corner & 2) == 0) {
						CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid2.RowStart, (byte)(unchecked((int)elemGrid2.RowEnd) + 1));
					} else {
						CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid2.RowEnd, (byte)(unchecked((int)elemGrid2.RowStart) + 1));
					}
					elemGrid2.TopRow = elemGrid2.RowStart;
					CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					e.Handled = true;
				} else if (Shift == 2) {
					Section section2 = CFS.Sections [CFS.intSctNow];
					section2.ZoomY = (float)((double)section2.ZoomY - 1.0 / (double)(4 * section2.Zoom));
					if (section2.ZoomY < 0f) {
						section2.ZoomY = 0f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
					section2 = null;
					e.Handled = true;
				}
				break;
			}
			case Keys.Delete: {
				ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
				CFSInterface.DeleteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid.RowStart, elemGrid.RowEnd);
				e.Handled = true;
				break;
			}
			case Keys.Apps:
				My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (picSct, (int)Math.Round ((double)picSct.ClientSize.Width / 2.0), (int)Math.Round ((double)picSct.ClientSize.Height / 2.0));
				break;
			case Keys.B:
				if (Shift == 3) {
					My.MyProject.Forms.frmBeamColumn.ShowDialog ();
				}
				break;
			}
		}
	}

	private void frmSctPicMaster_KeyUp (object sender, KeyEventArgs e)
	{
		Shift = 0;
		checked {
			if (e.Shift) {
				ref short shift = ref Shift;
				shift = (short)unchecked(shift + 1);
			}
			if (e.Control) {
				ref short shift2 = ref Shift;
				shift2 = (short)unchecked(shift2 + 2);
			}
			if (e.Alt) {
				ref short shift3 = ref Shift;
				shift3 = (short)unchecked(shift3 + 4);
			}
		}
	}

	private void picSct_MouseWheel (object sender, MouseEventArgs e)
	{
		if (CFS.Sections [CFS.intSctNow].nPart == 0) {
			return;
		}
		Section section = CFS.Sections [CFS.intSctNow];
		checked {
			if (Shift == 0) {
				if (e.Delta >= 30) {
					section.ZoomY = (float)((double)section.ZoomY + 1.0 / (double)(4 * section.Zoom));
					if (section.ZoomY > 1f) {
						section.ZoomY = 1f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				} else if (e.Delta <= -30) {
					section.ZoomY = (float)((double)section.ZoomY - 1.0 / (double)(4 * section.Zoom));
					if (section.ZoomY < 0f) {
						section.ZoomY = 0f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				}
			} else if (Shift == 1) {
				if (e.Delta >= 30) {
					section.ZoomX = (float)((double)section.ZoomX - 1.0 / (double)(4 * section.Zoom));
					if (section.ZoomX < 0f) {
						section.ZoomX = 0f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				} else if (e.Delta <= -30) {
					section.ZoomX = (float)((double)section.ZoomX + 1.0 / (double)(4 * section.Zoom));
					if (section.ZoomX > 1f) {
						section.ZoomX = 1f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				}
			} else if (Shift == 2) {
				float num = 1f;
				if ((e.Delta >= 30) & (section.Zoom < 32)) {
					num = 2f;
				}
				if ((e.Delta <= -30) & (section.Zoom > 1)) {
					num = 0.5f;
				}
				if (num != 1f) {
					section.Zoom = (short)Math.Round ((float)section.Zoom * num);
					PointF pointF = SG.TransformToWorld (new PointF (e.X, e.Y));
					PointF pointF2 = SG.TransformToWorld (new PointF ((float)((double)picSct.Width / 2.0), (float)((double)picSct.Height / 2.0)));
					section.ZoomX = (pointF.X - (pointF.X - pointF2.X) / num - section.ExtXmin) / (section.ExtXmax - section.ExtXmin);
					section.ZoomY = (pointF.Y - (pointF.Y - pointF2.Y) / num - section.ExtYmin) / (section.ExtYmax - section.ExtYmin);
					if (section.ZoomX < 0f) {
						section.ZoomX = 0f;
					}
					if (section.ZoomX > 1f) {
						section.ZoomX = 1f;
					}
					if (section.ZoomY < 0f) {
						section.ZoomY = 0f;
					}
					if (section.ZoomY > 1f) {
						section.ZoomY = 1f;
					}
					CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				}
			}
			section = null;
		}
	}

	private void picSct_MouseDown (object sender, MouseEventArgs e)
	{
		if (CFS.Sections [CFS.intSctNow].nPart == 0) {
			return;
		}
		PointF pointF = SG.TransformToWorld (new PointF (e.X, e.Y));
		float num = pointF.X;
		float num2 = pointF.Y;
		checked {
			if (((e.Button == MouseButtons.Left) | (e.Button == MouseButtons.Right)) & (Shift == 0)) {
				Section section = CFS.Sections [CFS.intSctNow];
				intPartStart = section.iPart;
				intElemStart = 1;
				float num3 = float.MaxValue;
				short nPart = section.nPart;
				for (short num4 = 1; num4 <= nPart; num4 = (short)unchecked(num4 + 1)) {
					short nElem = section.Part [num4].nElem;
					for (short num5 = 1; num5 <= nElem; num5 = (short)unchecked(num5 + 1)) {
						float num6 = DistanceToElement (section.Part [num4], num5, num, num2);
						if (num6 < num3) {
							num3 = num6;
							intPartStart = num4;
							intElemStart = num5;
						}
					}
				}
				if (e.Button == MouseButtons.Right) {
					if ((intPartStart != section.iPart) | (intElemStart < section.Part [section.iPart].ElemGrid.RowStart) | (intElemStart > section.Part [section.iPart].ElemGrid.RowEnd)) {
						if (intPartStart != section.iPart) {
							CFS.blnRefreshGrdElements = true;
						}
						CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], (byte)intPartStart, (byte)intElemStart, 0);
						section.Part [section.iPart].ElemGrid.Corner = (byte)(section.Part [section.iPart].ElemGrid.Corner & -3);
						section.Part [section.iPart].ElemGrid.TopRow = (byte)intElemStart;
						CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
					}
					My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (picSct, e.X, e.Y);
				} else {
					blnDoMouseUp = true;
				}
				section = null;
			} else if ((e.Button == MouseButtons.Middle) & (Shift == 0)) {
				Xstart = e.X;
				Ystart = e.Y;
				picSct.Cursor = Cursors.SizeAll;
			}
		}
	}

	private void picSct_MouseMove (object sender, MouseEventArgs e)
	{
		if (CFS.Sections [CFS.intSctNow].nPart == 0) {
			return;
		}
		if (picSct.Cursor == Cursors.SizeAll) {
			Section section = CFS.Sections [CFS.intSctNow];
			section.ZoomX += (Xstart - (float)e.X) * SG.UnitsPerPixelX / (section.ExtXmax - section.ExtXmin);
			if (section.ZoomX < 0f) {
				section.ZoomX = 0f;
			}
			if (section.ZoomX > 1f) {
				section.ZoomX = 1f;
			}
			section.ZoomY += (Ystart - (float)e.Y) * SG.UnitsPerPixelY / (section.ExtYmax - section.ExtYmin);
			if (section.ZoomY < 0f) {
				section.ZoomY = 0f;
			}
			if (section.ZoomY > 1f) {
				section.ZoomY = 1f;
			}
			section = null;
			Xstart = e.X;
			Ystart = e.Y;
			CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
		} else if (Shift == 2) {
			picSct.Cursor = Cursors.Cross;
		} else {
			picSct.Cursor = Cursors.Default;
		}
	}

	private void picSct_MouseUp (object sender, MouseEventArgs e)
	{
		if (CFS.Sections [CFS.intSctNow].nPart == 0) {
			return;
		}
		PointF pointF = SG.TransformToWorld (new PointF (e.X, e.Y));
		float num = pointF.X;
		float num2 = pointF.Y;
		picSct.Cursor = Cursors.Default;
		checked {
			if (blnDoMouseUp & (e.Button == MouseButtons.Left) & (Shift == 0)) {
				Section section = CFS.Sections [CFS.intSctNow];
				if (intPartStart == section.iPart) {
					short num3 = 1;
					float num4 = float.MaxValue;
					short nElem = section.Part [section.iPart].nElem;
					for (short num5 = 1; num5 <= nElem; num5 = (short)unchecked(num5 + 1)) {
						float num6 = DistanceToElement (section.Part [section.iPart], num5, num, num2);
						if (num6 < num4) {
							num4 = num6;
							num3 = num5;
						}
					}
					if (!section.Part [section.iPart].Closed) {
						if ((intElemStart == 1) & (num3 == section.Part [section.iPart].nElem)) {
							num3 = (short)(num3 + 1);
						}
						if ((num3 == 1) & (intElemStart == section.Part [section.iPart].nElem)) {
							intElemStart++;
						}
					}
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], section.iPart, (byte)intElemStart, (byte)num3);
					if (intElemStart <= num3) {
						section.Part [section.iPart].ElemGrid.Corner = (byte)(section.Part [section.iPart].ElemGrid.Corner & -3);
						section.Part [section.iPart].ElemGrid.TopRow = (byte)intElemStart;
					} else {
						section.Part [section.iPart].ElemGrid.Corner = (byte)(section.Part [section.iPart].ElemGrid.Corner | 2);
						section.Part [section.iPart].ElemGrid.TopRow = (byte)num3;
					}
				} else {
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], (byte)intPartStart, 0, 0);
					CFS.blnRefreshGrdElements = true;
				}
				section = null;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				blnDoMouseUp = false;
			} else {
				if (!((e.Button == MouseButtons.Left) & (Shift == 2))) {
					return;
				}
				Section section2 = CFS.Sections [CFS.intSctNow];
				float num4 = float.MaxValue;
				section2.iPt = (byte)unchecked(checked(unchecked((int)section2.iPt) + 1) % 3);
				section2.XPt [section2.iPt] = num;
				section2.YPt [section2.iPt] = num2;
				short nPart = section2.nPart;
				for (short num7 = 1; num7 <= nPart; num7 = (short)unchecked(num7 + 1)) {
					float num8 = section2.Part [num7].Thickness / 2f;
					if (section2.Part [num7].Centerline) {
						num8 = 0f;
					}
					float num9 = section2.Part [num7].XPosition - section2.Part [num7].Xcg;
					float num10 = section2.Part [num7].YPosition - section2.Part [num7].Ycg;
					short nElem2 = section2.Part [num7].nElem;
					for (short num5 = 1; num5 <= nElem2; num5 = (short)unchecked(num5 + 1)) {
						float num11 = section2.Part [num7].Element [num5].Rad + section2.Part [num7].Thickness / 2f + num8;
						float ang = section2.Part [num7].Element [num5].Ang;
						float num12 = (float)Math.Sin (ang);
						float num13 = (float)Math.Cos (ang);
						float num14 = num9 + section2.Part [num7].Element [num5].X0 + num8 * num12;
						float num15 = num10 + section2.Part [num7].Element [num5].Y0 - num8 * num13;
						float num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].X0 - num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Y0 + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + (section2.Part [num7].Element [num5].X0 + section2.Part [num7].Element [num5].X1) / 2f + num8 * num12;
						num15 = num10 + (section2.Part [num7].Element [num5].Y0 + section2.Part [num7].Element [num5].Y1) / 2f - num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + (section2.Part [num7].Element [num5].X0 + section2.Part [num7].Element [num5].X1) / 2f - num8 * num12;
						num15 = num10 + (section2.Part [num7].Element [num5].Y0 + section2.Part [num7].Element [num5].Y1) / 2f + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].X1 + num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Y1 - num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].X1 - num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Y1 + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].Xh0 + num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Yh0 - num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].Xh0 - num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Yh0 + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].Xh1 + num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Yh1 - num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + section2.Part [num7].Element [num5].Xh1 - num8 * num12;
						num15 = num10 + section2.Part [num7].Element [num5].Yh1 + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + (section2.Part [num7].Element [num5].Xh0 + section2.Part [num7].Element [num5].Xh1) / 2f + num8 * num12;
						num15 = num10 + (section2.Part [num7].Element [num5].Yh0 + section2.Part [num7].Element [num5].Yh1) / 2f - num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						num14 = num9 + (section2.Part [num7].Element [num5].Xh0 + section2.Part [num7].Element [num5].Xh1) / 2f - num8 * num12;
						num15 = num10 + (section2.Part [num7].Element [num5].Yh0 + section2.Part [num7].Element [num5].Yh1) / 2f + num8 * num13;
						num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
						if (num6 < num4) {
							num4 = num6;
							section2.XPt [section2.iPt] = num14;
							section2.YPt [section2.iPt] = num15;
						}
						if ((num5 > 1) | section2.Part [num7].Closed) {
							num14 = num9 + section2.Part [num7].Element [num5].Xac;
							num15 = num10 + section2.Part [num7].Element [num5].Yac;
							num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
							if (num6 < num4) {
								num4 = num6;
								section2.XPt [section2.iPt] = num14;
								section2.YPt [section2.iPt] = num15;
							}
							float num16 = (float)((double)num11 * Math.Tan (Math.Abs (section2.Part [num7].Element [num5].Arc) / 2f));
							short num17 = (short)Math.Sign (section2.Part [num7].Element [num5].Arc);
							if (num17 == 0) {
								num17 = 1;
							}
							num14 = num9 + section2.Part [num7].Element [num5].X0 + (float)num17 * num8 * num12 - num16 * num13;
							num15 = num10 + section2.Part [num7].Element [num5].Y0 - (float)num17 * num8 * num13 - num16 * num12;
							num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
							if (num6 < num4) {
								num4 = num6;
								section2.XPt [section2.iPt] = num14;
								section2.YPt [section2.iPt] = num15;
							}
						}
						unchecked {
							if ((num5 > 1) | section2.Part [num7].Closed) {
								ang = ((!(section2.Part [num7].Element [num5].Arc >= 0f)) ? ((float)((double)ang + Math.PI / 2.0)) : ((float)((double)ang - Math.PI / 2.0)));
								while ((double)ang > Math.PI) {
									ang = (float)((double)ang - Math.PI * 2.0);
								}
								while ((double)ang < -Math.PI) {
									ang = (float)((double)ang + Math.PI * 2.0);
								}
								float num18 = ang - section2.Part [num7].Element [num5].Arc;
								if ((ang > 0f && num18 < 0f) || (ang < 0f && num18 > 0f)) {
									num14 = num9 + section2.Part [num7].Element [num5].Xac + num11;
									num15 = num10 + section2.Part [num7].Element [num5].Yac;
									num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
									if (num6 < num4) {
										num4 = num6;
										section2.XPt [section2.iPt] = num14;
										section2.YPt [section2.iPt] = num15;
									}
								}
								if (((double)ang > Math.PI / 2.0 && (double)num18 < Math.PI / 2.0) || ((double)ang < Math.PI / 2.0 && (double)num18 > Math.PI / 2.0) || ((double)ang > -4.71238898038469 && (double)num18 < -4.71238898038469)) {
									num14 = num9 + section2.Part [num7].Element [num5].Xac;
									num15 = num10 + section2.Part [num7].Element [num5].Yac + num11;
									num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
									if (num6 < num4) {
										num4 = num6;
										section2.XPt [section2.iPt] = num14;
										section2.YPt [section2.iPt] = num15;
									}
								}
								if (((double)ang < Math.PI && (double)num18 > Math.PI) || ((double)ang > -Math.PI && (double)num18 < -Math.PI)) {
									num14 = num9 + section2.Part [num7].Element [num5].Xac - num11;
									num15 = num10 + section2.Part [num7].Element [num5].Yac;
									num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
									if (num6 < num4) {
										num4 = num6;
										section2.XPt [section2.iPt] = num14;
										section2.YPt [section2.iPt] = num15;
									}
								}
								if (((double)ang > -Math.PI / 2.0 && (double)num18 < -Math.PI / 2.0) || ((double)ang < -Math.PI / 2.0 && (double)num18 > -Math.PI / 2.0) || ((double)ang < 4.71238898038469 && (double)num18 > 4.71238898038469)) {
									num14 = num9 + section2.Part [num7].Element [num5].Xac;
									num15 = num10 + section2.Part [num7].Element [num5].Yac - num11;
									num6 = (float)(Math.Pow (num14 - num, 2.0) + Math.Pow (num15 - num2, 2.0));
									if (num6 < num4) {
										num4 = num6;
										section2.XPt [section2.iPt] = num14;
										section2.YPt [section2.iPt] = num15;
									}
								}
							}
						}
					}
				}
				CFSInterface.PlotSct (this, CFS.Sections [CFS.intSctNow]);
				section2 = null;
			}
		}
	}

	private void picSct_MouseDoubleClick (object sender, MouseEventArgs e)
	{
		checked {
			if (CFS.Sections [CFS.intSctNow].nPart != 0) {
				Section section = CFS.Sections [CFS.intSctNow];
				if (section.Part [section.iPart].Closed) {
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], section.iPart, 1, section.Part [section.iPart].nElem);
				} else {
					CFSInterface.SelectElements (this, CFS.Sections [CFS.intSctNow], section.iPart, 1, (byte)(unchecked((int)section.Part [section.iPart].nElem) + 1));
				}
				section.Part [section.iPart].ElemGrid.Corner = 0;
				section.Part [section.iPart].ElemGrid.TopRow = 1;
				section = null;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
				blnDoMouseUp = false;
			}
		}
	}

	private float DistanceToElement (Part Part1, short iElem, float X, float Y)
	{
		X = X - Part1.XPosition + Part1.Xcg;
		Y = Y - Part1.YPosition + Part1.Ycg;
		ref Element reference = ref Part1.Element [iElem];
		$STATIC$DistanceToElement$204C1280E06CC$Ux = reference.X1 - reference.X0;
		$STATIC$DistanceToElement$204C1280E06CC$Uy = reference.Y1 - reference.Y0;
		$STATIC$DistanceToElement$204C1280E06CC$Vx = X - reference.X0;
		$STATIC$DistanceToElement$204C1280E06CC$Vy = Y - reference.Y0;
		$STATIC$DistanceToElement$204C1280E06CC$U = (float)Math.Sqrt ($STATIC$DistanceToElement$204C1280E06CC$Ux * $STATIC$DistanceToElement$204C1280E06CC$Ux + $STATIC$DistanceToElement$204C1280E06CC$Uy * $STATIC$DistanceToElement$204C1280E06CC$Uy);
		if ($STATIC$DistanceToElement$204C1280E06CC$U > 0f) {
			$STATIC$DistanceToElement$204C1280E06CC$W = ($STATIC$DistanceToElement$204C1280E06CC$Ux * $STATIC$DistanceToElement$204C1280E06CC$Vx + $STATIC$DistanceToElement$204C1280E06CC$Uy * $STATIC$DistanceToElement$204C1280E06CC$Vy) / $STATIC$DistanceToElement$204C1280E06CC$U;
		} else {
			$STATIC$DistanceToElement$204C1280E06CC$W = 0f;
		}
		float num;
		if ($STATIC$DistanceToElement$204C1280E06CC$W <= 0f) {
			num = (float)Math.Sqrt ($STATIC$DistanceToElement$204C1280E06CC$Vx * $STATIC$DistanceToElement$204C1280E06CC$Vx + $STATIC$DistanceToElement$204C1280E06CC$Vy * $STATIC$DistanceToElement$204C1280E06CC$Vy);
		} else if ($STATIC$DistanceToElement$204C1280E06CC$W >= $STATIC$DistanceToElement$204C1280E06CC$U) {
			$STATIC$DistanceToElement$204C1280E06CC$Vx = X - reference.X1;
			$STATIC$DistanceToElement$204C1280E06CC$Vy = Y - reference.Y1;
			num = (float)Math.Sqrt ($STATIC$DistanceToElement$204C1280E06CC$Vx * $STATIC$DistanceToElement$204C1280E06CC$Vx + $STATIC$DistanceToElement$204C1280E06CC$Vy * $STATIC$DistanceToElement$204C1280E06CC$Vy);
		} else {
			num = Math.Abs ($STATIC$DistanceToElement$204C1280E06CC$Ux * $STATIC$DistanceToElement$204C1280E06CC$Vy - $STATIC$DistanceToElement$204C1280E06CC$Uy * $STATIC$DistanceToElement$204C1280E06CC$Vx) / $STATIC$DistanceToElement$204C1280E06CC$U;
		}
		$STATIC$DistanceToElement$204C1280E06CC$Vx = X - reference.Xac;
		$STATIC$DistanceToElement$204C1280E06CC$Vy = Y - reference.Yac;
		$STATIC$DistanceToElement$204C1280E06CC$V = (float)Math.Sqrt ($STATIC$DistanceToElement$204C1280E06CC$Vx * $STATIC$DistanceToElement$204C1280E06CC$Vx + $STATIC$DistanceToElement$204C1280E06CC$Vy * $STATIC$DistanceToElement$204C1280E06CC$Vy);
		$STATIC$DistanceToElement$204C1280E06CC$V = Math.Abs ($STATIC$DistanceToElement$204C1280E06CC$V - reference.Rad - Part1.Thickness / 2f);
		if ($STATIC$DistanceToElement$204C1280E06CC$V < num) {
			$STATIC$DistanceToElement$204C1280E06CC$A = (float)Math.Atan2 ($STATIC$DistanceToElement$204C1280E06CC$Vy, $STATIC$DistanceToElement$204C1280E06CC$Vx);
			$STATIC$DistanceToElement$204C1280E06CC$A1 = (float)((double)reference.Ang - (double)Math.Sign (reference.Arc) * Math.PI / 2.0);
			$STATIC$DistanceToElement$204C1280E06CC$A0 = $STATIC$DistanceToElement$204C1280E06CC$A1 - reference.Arc;
			if (reference.Arc < 0f) {
				CFS.Swap (ref $STATIC$DistanceToElement$204C1280E06CC$A0, ref $STATIC$DistanceToElement$204C1280E06CC$A1);
			}
			while ($STATIC$DistanceToElement$204C1280E06CC$A < $STATIC$DistanceToElement$204C1280E06CC$A0) {
				$STATIC$DistanceToElement$204C1280E06CC$A = (float)((double)$STATIC$DistanceToElement$204C1280E06CC$A + Math.PI * 2.0);
			}
			while ($STATIC$DistanceToElement$204C1280E06CC$A > $STATIC$DistanceToElement$204C1280E06CC$A1) {
				$STATIC$DistanceToElement$204C1280E06CC$A = (float)((double)$STATIC$DistanceToElement$204C1280E06CC$A - Math.PI * 2.0);
			}
			if (($STATIC$DistanceToElement$204C1280E06CC$A > $STATIC$DistanceToElement$204C1280E06CC$A0) & ($STATIC$DistanceToElement$204C1280E06CC$A < $STATIC$DistanceToElement$204C1280E06CC$A1)) {
				num = $STATIC$DistanceToElement$204C1280E06CC$V;
			}
		}
		return num;
	}
}
