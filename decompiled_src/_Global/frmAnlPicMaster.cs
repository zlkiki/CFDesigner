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
public class frmAnlPicMaster : Form
{
	private IContainer components;

	private bool blnScroll;

	private float Zdown;

	private bool blnDoMouseUp;

	private short Shift;

	private float Xstart;

	private float Ystart;

	internal ScaleGraphics SG;

	internal virtual PictureBox picAnl {
		[CompilerGenerated]
		get {
			return _picAnl;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PreviewKeyDownEventHandler value2 = picAnl_PreviewKeyDown;
			MouseEventHandler value3 = picAnl_MouseWheel;
			MouseEventHandler value4 = picAnl_MouseDown;
			MouseEventHandler value5 = picAnl_MouseMove;
			MouseEventHandler value6 = picAnl_MouseUp;
			PictureBox pictureBox = _picAnl;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown -= value2;
				pictureBox.MouseWheel -= value3;
				pictureBox.MouseDown -= value4;
				pictureBox.MouseMove -= value5;
				pictureBox.MouseUp -= value6;
			}
			_picAnl = value;
			pictureBox = _picAnl;
			if (pictureBox != null) {
				pictureBox.PreviewKeyDown += value2;
				pictureBox.MouseWheel += value3;
				pictureBox.MouseDown += value4;
				pictureBox.MouseMove += value5;
				pictureBox.MouseUp += value6;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmAnlPicMaster));
		this.picAnl = new System.Windows.Forms.PictureBox ();
		((System.ComponentModel.ISupportInitialize)this.picAnl).BeginInit ();
		base.SuspendLayout ();
		this.picAnl.Location = new System.Drawing.Point (0, 0);
		this.picAnl.Name = "picAnl";
		this.picAnl.Size = new System.Drawing.Size (425, 330);
		this.picAnl.TabIndex = 0;
		this.picAnl.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (426, 331);
		base.Controls.Add (this.picAnl);
		this.DoubleBuffered = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size (100, 100);
		base.Name = "frmAnlPicMaster";
		((System.ComponentModel.ISupportInitialize)this.picAnl).EndInit ();
		base.ResumeLayout (false);
	}

	public frmAnlPicMaster (byte Index)
	{
		base.Load += frmAnlPicMaster_Load;
		base.Activated += frmAnlPicMaster_Activated;
		base.Resize += frmAnlPicMaster_Resize;
		base.Deactivate += frmAnlPicMaster_Deactivate;
		base.FormClosing += frmAnlPicMaster_FormClosing;
		base.FormClosed += frmAnlPicMaster_FormClosed;
		base.PreviewKeyDown += frmAnlPicMaster_PreviewKeyDown;
		base.KeyDown += frmAnlPicMaster_KeyDown;
		base.KeyUp += frmAnlPicMaster_KeyUp;
		base.MdiParent = My.MyProject.Forms.mdiCFS;
		base.Tag = Index;
		InitializeComponent ();
	}

	private void frmAnlPicMaster_Load (object sender, EventArgs e)
	{
		checked {
			float num;
			short num2;
			short num3;
			if (CFS.Analyses [Conversions.ToByte (base.Tag)].Vertical) {
				num = 2.5f;
				num2 = (short)Math.Round (Math.Max (0.8 * (double)My.MyProject.Forms.mdiCFS.ClientRectangle.Height, 500.0));
				num3 = (short)Math.Round (Math.Max (0.4 * (double)My.MyProject.Forms.mdiCFS.ClientRectangle.Width, 200.0));
			} else {
				num = 0.4f;
				num2 = (short)Math.Round (Math.Max (0.4 * (double)My.MyProject.Forms.mdiCFS.ClientRectangle.Height, 200.0));
				num3 = (short)Math.Round (Math.Max (0.8 * (double)My.MyProject.Forms.mdiCFS.ClientRectangle.Width, 500.0));
			}
			if (num * (float)num3 < (float)num2) {
				num2 = (short)Math.Round (num * (float)num3);
			} else {
				num3 = (short)Math.Round ((float)num2 / num);
			}
			picAnl.Top = 0;
			picAnl.Left = 0;
			base.Width = num3;
			base.Height = num2;
			blnScroll = true;
		}
	}

	private void frmAnlPicMaster_Activated (object sender, EventArgs e)
	{
		Application.DoEvents ();
		picAnl.Enabled = true;
		if (base.Enabled) {
			picAnl.Select ();
		}
		CFS.intAnlNow = Conversions.ToByte (base.Tag);
		if (Strings.Len (CFS.Analyses [CFS.intAnlNow].Filename) != 0) {
			Text = CFSInterface.GetFileName (CFS.Analyses [CFS.intAnlNow].Filename);
			if (CFS.blnAnlInpLoaded) {
				My.MyProject.Forms.frmAnlInp.Text = "Analysis Inputs: " + Text;
			}
		} else {
			Text = Conversions.ToString (Operators.ConcatenateObject ("Analysis ", base.Tag));
		}
		CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
		CFS.blnRefreshGrdBeams = true;
		CFS.blnRefreshGrdSupports = true;
		CFS.blnRefreshGrdLoads = true;
		CFS.blnRefreshGrdCombs = true;
		CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		base.MaximizeBox = true;
		CFSInterface.SetMenuUndo (CFS.Analyses [CFS.intAnlNow]);
		CFSInterface.SetMenuFile ();
		CFSInterface.SetMenuEdit ();
		CFSInterface.SetMenuCompute ();
	}

	private void frmAnlPicMaster_Resize (object sender, EventArgs e)
	{
		picAnl.Width = base.ClientRectangle.Width;
		picAnl.Height = base.ClientRectangle.Height;
		CFSInterface.PlotAnl (this, CFS.Analyses [Conversions.ToByte (base.Tag)]);
	}

	private void frmAnlPicMaster_Deactivate (object sender, EventArgs e)
	{
		picAnl.Enabled = false;
		base.MaximizeBox = false;
	}

	private void frmAnlPicMaster_FormClosing (object sender, FormClosingEventArgs e)
	{
		if (CFS.Analyses [Conversions.ToByte (base.Tag)].Saved) {
			return;
		}
		switch (checked((short)Interaction.MsgBox ("Save changes to " + Text + "?", MsgBoxStyle.YesNoCancel | MsgBoxStyle.Question))) {
		case 6:
			if (!CFSInterface.SaveAnl (Conversions.ToByte (base.Tag))) {
				e.Cancel = true;
			}
			break;
		case 2:
			e.Cancel = true;
			break;
		}
	}

	private void frmAnlPicMaster_FormClosed (object sender, FormClosedEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing) {
			short num = CFSInterface.FindAnlRptIndex (CFS.Analyses [Conversions.ToByte (base.Tag)]);
			if (num > 0) {
				CFS.frmReport [num].Close ();
			}
		}
		if (CFSInterface.intAnlMemChk == Conversions.ToByte (base.Tag)) {
			CFSInterface.intAnlMemChk = 0;
		}
		if (CFSInterface.intAnlWebCrip == Conversions.ToByte (base.Tag)) {
			CFSInterface.intAnlWebCrip = 0;
		}
		CFSInterface.SetMenuUndo (null);
		CFS.hdgAnlPic [Conversions.ToByte (base.Tag)].Initialize ();
		CFS.frmAnlPic [Conversions.ToByte (base.Tag)].Dispose ();
		short num2 = 0;
		checked {
			do {
				CFS.AnlUndo [num2, Conversions.ToByte (base.Tag)] = null;
				num2 = (short)unchecked(num2 + 1);
			} while (num2 <= 9);
			if (e.CloseReason != CloseReason.UserClosing) {
				return;
			}
			CFS.intAnlNow = 0;
			for (num2 = (short)Information.UBound (CFS.hdgAnlPic); num2 >= 1; num2 = (short)unchecked(num2 + -1)) {
				if (!CFS.hdgAnlPic [num2].Deleted) {
					CFS.intAnlNow = (byte)num2;
					CFS.frmAnlPic [CFS.intAnlNow].BringToFront ();
					ActivateMdiChild (CFS.frmAnlPic [CFS.intAnlNow]);
					break;
				}
			}
			if (CFS.intAnlNow == 0) {
				CFS.intAnlTabNow = -1;
				if (CFS.blnAnlInpLoaded) {
					My.MyProject.Forms.frmAnlInp.Close ();
				}
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

	private void frmAnlPicMaster_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void picAnl_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e)
	{
		e.IsInputKey = true;
	}

	private void frmAnlPicMaster_KeyDown (object sender, KeyEventArgs e)
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
			if (CFS.Analyses [CFS.intAnlNow].Zmax == CFS.Analyses [CFS.intAnlNow].Zmin) {
				return;
			}
			switch (e.KeyCode) {
			case Keys.F1:
				Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "analysis-window.htm");
				e.Handled = true;
				break;
			case Keys.Prior:
			case Keys.Add: {
				Analysis analysis5 = CFS.Analyses [CFS.intAnlNow];
				if (analysis5.Zoom < 32) {
					analysis5.Zoom *= 2;
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				}
				analysis5 = null;
				e.Handled = true;
				break;
			}
			case Keys.Next:
			case Keys.Subtract: {
				Analysis analysis3 = CFS.Analyses [CFS.intAnlNow];
				if (analysis3.Zoom > 1) {
					analysis3.Zoom = (short)Math.Round ((double)analysis3.Zoom / 2.0);
					if (analysis3.Zoom == 1) {
						analysis3.ZoomX = 0.5f;
						analysis3.ZoomY = 0.5f;
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				}
				analysis3 = null;
				e.Handled = true;
				break;
			}
			case Keys.Escape:
			case Keys.Home: {
				Analysis obj = CFS.Analyses [CFS.intAnlNow];
				obj.Zoom = 1;
				obj.ZoomX = 0.5f;
				obj.ZoomY = 0.5f;
				CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				_ = null;
				e.Handled = true;
				break;
			}
			case Keys.Left:
				if (Shift == 2) {
					Analysis analysis = CFS.Analyses [CFS.intAnlNow];
					analysis.ZoomX = (float)((double)analysis.ZoomX - 1.0 / (double)(4 * analysis.Zoom));
					if (analysis.ZoomX < 0f) {
						analysis.ZoomX = 0f;
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
					analysis = null;
					e.Handled = true;
				}
				break;
			case Keys.Right:
				if (Shift == 2) {
					Analysis analysis4 = CFS.Analyses [CFS.intAnlNow];
					analysis4.ZoomX = (float)((double)analysis4.ZoomX + 1.0 / (double)(4 * analysis4.Zoom));
					if (analysis4.ZoomX > 1f) {
						analysis4.ZoomX = 1f;
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
					analysis4 = null;
					e.Handled = true;
				}
				break;
			case Keys.Up:
				if (Shift == 2) {
					Analysis analysis6 = CFS.Analyses [CFS.intAnlNow];
					if (analysis6.Vertical) {
						analysis6.ZoomY = (float)Math.Max ((double)analysis6.ZoomY - 1.0 / (double)(4 * analysis6.Zoom), 0.0);
					} else {
						analysis6.ZoomY = (float)Math.Min ((double)analysis6.ZoomY + 1.0 / (double)(4 * analysis6.Zoom), 1.0);
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
					analysis6 = null;
					e.Handled = true;
				}
				break;
			case Keys.Down:
				if (Shift == 2) {
					Analysis analysis2 = CFS.Analyses [CFS.intAnlNow];
					if (analysis2.Vertical) {
						analysis2.ZoomY = (float)Math.Min ((double)analysis2.ZoomY + 1.0 / (double)(4 * analysis2.Zoom), 1.0);
					} else {
						analysis2.ZoomY = (float)Math.Max ((double)analysis2.ZoomY - 1.0 / (double)(4 * analysis2.Zoom), 0.0);
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
					analysis2 = null;
					e.Handled = true;
				}
				break;
			case Keys.Delete:
				if (Shift == 0) {
					switch (CFS.intAnlTabNow) {
					case 1: {
						ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
						CFSInterface.DeleteBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
						break;
					}
					case 2: {
						ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
						CFSInterface.DeleteSupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
						break;
					}
					case 3: {
						ref GridState loadGrid = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].LoadGrid;
						CFSInterface.DeleteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, loadGrid.RowStart, loadGrid.RowEnd);
						break;
					}
					}
				}
				break;
			case Keys.Apps:
				My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (picAnl, (int)Math.Round ((double)picAnl.ClientSize.Width / 2.0), (int)Math.Round ((double)picAnl.ClientSize.Height / 2.0));
				break;
			}
		}
	}

	private void frmAnlPicMaster_KeyUp (object sender, KeyEventArgs e)
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

	private void picAnl_MouseWheel (object sender, MouseEventArgs e)
	{
		if (CFS.Analyses [CFS.intAnlNow].Zmax == CFS.Analyses [CFS.intAnlNow].Zmin) {
			return;
		}
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		checked {
			if (Shift == 0) {
				if (e.Delta >= 30) {
					if (analysis.Vertical) {
						analysis.ZoomY = (float)Math.Max ((double)analysis.ZoomY - 1.0 / (double)(4 * analysis.Zoom), 0.0);
					} else {
						analysis.ZoomY = (float)Math.Min ((double)analysis.ZoomY + 1.0 / (double)(4 * analysis.Zoom), 1.0);
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				} else if (e.Delta <= -30) {
					if (analysis.Vertical) {
						analysis.ZoomY = (float)Math.Min ((double)analysis.ZoomY + 1.0 / (double)(4 * analysis.Zoom), 1.0);
					} else {
						analysis.ZoomY = (float)Math.Max ((double)analysis.ZoomY - 1.0 / (double)(4 * analysis.Zoom), 0.0);
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				}
			} else if (Shift == 1) {
				if (e.Delta >= 30) {
					analysis.ZoomX = (float)Math.Max ((double)analysis.ZoomX - 1.0 / (double)(4 * analysis.Zoom), 0.0);
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				} else if (e.Delta <= -30) {
					analysis.ZoomX = (float)Math.Min ((double)analysis.ZoomX + 1.0 / (double)(4 * analysis.Zoom), 1.0);
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				}
			} else if (Shift == 2) {
				float num = 1f;
				if ((e.Delta >= 30) & (analysis.Zoom < 32)) {
					num = 2f;
				}
				if ((e.Delta <= -30) & (analysis.Zoom > 1)) {
					num = 0.5f;
				}
				if (num != 1f) {
					analysis.Zoom = (short)Math.Round ((float)analysis.Zoom * num);
					PointF pointF = SG.TransformToWorld (new PointF (e.X, e.Y));
					PointF pointF2 = SG.TransformToWorld (new PointF ((float)((double)picAnl.Width / 2.0), (float)((double)picAnl.Height / 2.0)));
					if (analysis.Vertical) {
						analysis.ZoomY = (pointF.Y - (pointF.Y - pointF2.Y) / num - analysis.Zmin) / (analysis.Zmax - analysis.Zmin);
						float num2 = SG.Width / SG.Height * (analysis.Zmax - analysis.Zmin);
						analysis.ZoomX = (pointF.X - (pointF.X - pointF2.X) / num + num2 / 2f) / num2;
					} else {
						analysis.ZoomX = (pointF.X - (pointF.X - pointF2.X) / num - analysis.Zmin) / (analysis.Zmax - analysis.Zmin);
						float num2 = SG.Height / SG.Width * (analysis.Zmax - analysis.Zmin);
						analysis.ZoomY = (pointF.Y - (pointF.Y - pointF2.Y) / num + num2 / 2f) / num2;
					}
					if (analysis.ZoomX < 0f) {
						analysis.ZoomX = 0f;
					}
					if (analysis.ZoomX > 1f) {
						analysis.ZoomX = 1f;
					}
					if (analysis.ZoomY < 0f) {
						analysis.ZoomY = 0f;
					}
					if (analysis.ZoomY > 1f) {
						analysis.ZoomY = 1f;
					}
					CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				}
			}
			analysis = null;
		}
	}

	private void picAnl_MouseDown (object sender, MouseEventArgs e)
	{
		if (CFS.Analyses [CFS.intAnlNow].Zmax == CFS.Analyses [CFS.intAnlNow].Zmin) {
			return;
		}
		if (e.Button == MouseButtons.Left) {
			if (CFS.Analyses [CFS.intAnlNow].Vertical) {
				Zdown = SG.TransformToWorld (new PointF (e.X, e.Y)).Y;
			} else {
				Zdown = SG.TransformToWorld (new PointF (e.X, e.Y)).X;
			}
			blnDoMouseUp = true;
		} else if (e.Button == MouseButtons.Right) {
			My.MyProject.Forms.mdiCFS.mnuEditPopup.Show (picAnl, e.X, e.Y);
		} else if ((e.Button == MouseButtons.Middle) & (Shift == 0)) {
			Xstart = e.X;
			Ystart = e.Y;
			picAnl.Cursor = Cursors.SizeAll;
		}
	}

	private void picAnl_MouseMove (object sender, MouseEventArgs e)
	{
		if (CFS.Analyses [CFS.intAnlNow].Zmax == CFS.Analyses [CFS.intAnlNow].Zmin) {
			return;
		}
		if (picAnl.Cursor == Cursors.SizeAll) {
			float num = SG.Height / SG.Width;
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			analysis.ZoomX += (Xstart - (float)e.X) * SG.UnitsPerPixelX / (analysis.Zmax - analysis.Zmin);
			if (analysis.ZoomX < 0f) {
				analysis.ZoomX = 0f;
			}
			if (analysis.ZoomX > 1f) {
				analysis.ZoomX = 1f;
			}
			analysis.ZoomY += (Ystart - (float)e.Y) * SG.UnitsPerPixelY / (num * (analysis.Zmax - analysis.Zmin));
			if (analysis.ZoomY < 0f) {
				analysis.ZoomY = 0f;
			}
			if (analysis.ZoomY > 1f) {
				analysis.ZoomY = 1f;
			}
			analysis = null;
			Xstart = e.X;
			Ystart = e.Y;
			CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
		} else {
			picAnl.Cursor = Cursors.Default;
		}
	}

	private void picAnl_MouseUp (object sender, MouseEventArgs e)
	{
		if (CFS.Analyses [CFS.intAnlNow].Zmax == CFS.Analyses [CFS.intAnlNow].Zmin) {
			return;
		}
		PointF pointF = SG.TransformToWorld (new PointF (e.X, e.Y));
		float A = pointF.X;
		float B = pointF.Y;
		if (CFS.Analyses [CFS.intAnlNow].Vertical) {
			CFS.Swap (ref A, ref B);
		}
		picAnl.Cursor = Cursors.Default;
		checked {
			if (blnDoMouseUp & (e.Button == MouseButtons.Left) & (Shift == 0)) {
				Analysis analysis = CFS.Analyses [CFS.intAnlNow];
				if ((analysis.nBeam == 0) & (analysis.nSup == 0)) {
					return;
				}
				float num = ((analysis.Zmax != analysis.Zmin) ? ((analysis.Zmax - analysis.Zmin) / 96f) : 0.25f);
				short nSup = analysis.nSup;
				short num2 = 1;
				while (num2 <= nSup && !(Math.Abs (analysis.Sup [num2].Z - Zdown) <= num)) {
					num2 = (short)unchecked(num2 + 1);
				}
				if ((num2 <= analysis.nSup) | (analysis.nBeam == 0)) {
					CFSInterface.SortSups (CFS.Analyses [CFS.intAnlNow]);
					float num3 = Math.Min (Zdown, A);
					float num4 = Math.Max (Zdown, A);
					byte b = 1;
					float num5 = float.MaxValue;
					short nSup2 = analysis.nSup;
					for (num2 = 1; num2 <= nSup2; num2 = (short)unchecked(num2 + 1)) {
						float num6 = Math.Abs (analysis.Sup [num2].Z - num3);
						if (num6 < num5) {
							num5 = num6;
							b = (byte)num2;
						}
					}
					byte b2 = 1;
					num5 = float.MaxValue;
					for (num2 = analysis.nSup; num2 >= 1; num2 = (short)unchecked(num2 + -1)) {
						float num6 = Math.Abs (analysis.Sup [num2].Z - num4);
						if (num6 < num5) {
							num5 = num6;
							b2 = (byte)num2;
						}
					}
					if (unchecked((uint)b <= (uint)b2)) {
						analysis.SupGrid.Corner = (byte)(analysis.SupGrid.Corner & -3);
						analysis.SupGrid.TopRow = b;
					} else {
						analysis.SupGrid.Corner = (byte)(analysis.SupGrid.Corner | 2);
						analysis.SupGrid.TopRow = b2;
					}
					if (CFS.intAnlTabNow == 2) {
						CFSInterface.SelectAnl (this, CFS.Analyses [CFS.intAnlNow], b, b2);
						CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
					} else {
						CFS.intAnlTabNow = 2;
						analysis.SupGrid.RowStart = b;
						analysis.SupGrid.RowEnd = b2;
						if (CFS.blnAnlInpLoaded) {
							My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.intAnlTabNow;
							Activate ();
						} else {
							CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
						}
						CFSInterface.SetMenuEdit ();
					}
				} else {
					CFSInterface.SortBeams (CFS.Analyses [CFS.intAnlNow]);
					float num3 = Math.Min (Zdown, A);
					float num4 = Math.Max (Zdown, A);
					byte b = 1;
					float num5 = float.MaxValue;
					short nBeam = analysis.nBeam;
					for (num2 = 1; num2 <= nBeam; num2 = (short)unchecked(num2 + 1)) {
						float num6 = ((num3 < analysis.Beam [num2].Z0) ? (analysis.Beam [num2].Z0 - num3) : ((!(num3 > analysis.Beam [num2].Z1)) ? 0f : (num3 - analysis.Beam [num2].Z1)));
						if (num6 < num5) {
							num5 = num6;
							b = (byte)num2;
						}
					}
					byte b2 = 1;
					num5 = float.MaxValue;
					for (num2 = analysis.nBeam; num2 >= 1; num2 = (short)unchecked(num2 + -1)) {
						float num6 = ((num4 < analysis.Beam [num2].Z0) ? (analysis.Beam [num2].Z0 - num4) : ((!(num4 > analysis.Beam [num2].Z1)) ? 0f : (num4 - analysis.Beam [num2].Z1)));
						if (num6 < num5) {
							num5 = num6;
							b2 = (byte)num2;
						}
					}
					if (unchecked((uint)b <= (uint)b2)) {
						analysis.BeamGrid.Corner = (byte)(analysis.BeamGrid.Corner & -3);
						analysis.BeamGrid.TopRow = b;
					} else {
						analysis.BeamGrid.Corner = (byte)(analysis.BeamGrid.Corner | 2);
						analysis.BeamGrid.TopRow = b2;
					}
					if (CFS.intAnlTabNow == 1) {
						CFSInterface.SelectAnl (this, CFS.Analyses [CFS.intAnlNow], b, b2);
						CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
					} else {
						CFS.intAnlTabNow = 1;
						analysis.BeamGrid.RowStart = b;
						analysis.BeamGrid.RowEnd = b2;
						if (CFS.blnAnlInpLoaded) {
							My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.intAnlTabNow;
							Activate ();
						} else {
							CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
						}
						CFSInterface.SetMenuEdit ();
					}
				}
				analysis = null;
				blnDoMouseUp = false;
			} else {
				if (!((e.Button == MouseButtons.Left) & (Shift == 2))) {
					return;
				}
				Analysis analysis2 = CFS.Analyses [CFS.intAnlNow];
				float num5 = float.MaxValue;
				analysis2.iPt = (byte)unchecked(checked(unchecked((int)analysis2.iPt) + 1) % 3);
				analysis2.ZPt [analysis2.iPt] = A;
				short nSup3 = analysis2.nSup;
				for (short num2 = 1; num2 <= nSup3; num2 = (short)unchecked(num2 + 1)) {
					if (Math.Abs (analysis2.Sup [num2].Z - Zdown) < num5) {
						num5 = Math.Abs (analysis2.Sup [num2].Z - Zdown);
						analysis2.ZPt [analysis2.iPt] = analysis2.Sup [num2].Z;
					}
				}
				short nBeam2 = analysis2.nBeam;
				for (short num2 = 1; num2 <= nBeam2; num2 = (short)unchecked(num2 + 1)) {
					if (Math.Abs (analysis2.Beam [num2].Z0 - Zdown) < num5) {
						num5 = Math.Abs (analysis2.Beam [num2].Z0 - Zdown);
						analysis2.ZPt [analysis2.iPt] = analysis2.Beam [num2].Z0;
					}
					if (Math.Abs (analysis2.Beam [num2].Z1 - Zdown) < num5) {
						num5 = Math.Abs (analysis2.Beam [num2].Z1 - Zdown);
						analysis2.ZPt [analysis2.iPt] = analysis2.Beam [num2].Z1;
					}
				}
				if (num5 == float.MaxValue) {
					analysis2.iPt = (byte)unchecked(checked(unchecked((int)analysis2.iPt) + 2) % 3);
				}
				CFSInterface.PlotAnl (this, CFS.Analyses [CFS.intAnlNow]);
				analysis2 = null;
			}
		}
	}
}
