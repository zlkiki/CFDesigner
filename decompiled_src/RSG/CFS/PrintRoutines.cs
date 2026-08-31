// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;

namespace RSG.CFS;

[StandardModule]
internal sealed class PrintRoutines
{
	public struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public struct CHARRANGE
	{
		public int cpMin;

		public int cpMax;
	}

	public struct FORMATRANGE
	{
		public IntPtr hdc;

		public IntPtr hdcTarget;

		public RECT rc;

		public RECT rcPage;

		public CHARRANGE chrg;
	}

	private enum RTFMethod
	{
		Check,
		Commit,
		Print
	}

	public static FORMATRANGE fr;

	private static RECT rcDrawTo;

	private static RichTextBox rtfHeader;

	private static RichTextBox rtfFooter;

	private static RichTextBox rtfMain;

	private static short intPage;

	private static int lngCharPosStart;

	private static short intCheckedItem;

	private static short intLength;

	private static short intDiagramDir;

	private static bool blnDiagramEnv;

	private static RECT rcGraphic;

	private static short hGraphic;

	private static short intGraphicType;

	private const short None = 0;

	private const short SctSmall = 1;

	private const short SctLarge = 2;

	private const short AnlSmall = 3;

	private const short AnlLarge = 4;

	private const int WM_USER = 1024;

	private const int EM_FORMATRANGE = 1081;

	private const int EM_DISPLAYBAND = 1075;

	public const int TWIPS_PERINCH = 1440;

	public const int TWIPS_PERPOINT = 20;

	private const float TWIPS_PERHUNDREDTH = 14.4f;

	private static float PrinterOffsetX;

	private static float PrinterOffsetY;

	private static PrintDocument ReportDoc {
		[CompilerGenerated]
		get {
			return _ReportDoc;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PrintPageEventHandler value2 = ReportDoc_PrintPage;
			PrintDocument reportDoc = _ReportDoc;
			if (reportDoc != null) {
				reportDoc.PrintPage -= value2;
			}
			_ReportDoc = value;
			reportDoc = _ReportDoc;
			if (reportDoc != null) {
				reportDoc.PrintPage += value2;
			}
		}
	}

	private static PrintDocument BucklingDoc {
		[CompilerGenerated]
		get {
			return _BucklingDoc;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PrintPageEventHandler value2 = BucklingDoc_PrintPage;
			PrintDocument bucklingDoc = _BucklingDoc;
			if (bucklingDoc != null) {
				bucklingDoc.PrintPage -= value2;
			}
			_BucklingDoc = value;
			bucklingDoc = _BucklingDoc;
			if (bucklingDoc != null) {
				bucklingDoc.PrintPage += value2;
			}
		}
	}

	private static PrintDocument DiagramsDoc {
		[CompilerGenerated]
		get {
			return _DiagramsDoc;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			PrintPageEventHandler value2 = DiagramsDoc_PrintPage;
			PrintDocument diagramsDoc = _DiagramsDoc;
			if (diagramsDoc != null) {
				diagramsDoc.PrintPage -= value2;
			}
			_DiagramsDoc = value;
			diagramsDoc = _DiagramsDoc;
			if (diagramsDoc != null) {
				diagramsDoc.PrintPage += value2;
			}
		}
	}

	[DllImport ("USER32", CharSet = CharSet.Ansi, EntryPoint = "SendMessageA", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr SendMessage (IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

	public static void PrintReports ()
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					rtfHeader = new RichTextBox ();
					rtfFooter = new RichTextBox ();
					rtfMain = new RichTextBox ();
					ProjectData.ClearProjectError ();
					num2 = 2;
					Cursor.Current = Cursors.WaitCursor;
					ReportDoc = new PrintDocument ();
					ReportDoc.PrinterSettings.PrinterName = CFSInterface.strPrinterName;
					if (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems.Count == 1) {
						ReportDoc.DocumentName = Conversions.ToString (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [0], null, "Text", new object[0], null, null, null));
					} else {
						ReportDoc.DocumentName = "CFS Reports";
					}
					ReportDoc.PrintController = new StandardPrintController ();
					intCheckedItem = 0;
					lngCharPosStart = 0;
					My.MyProject.Forms.mdiCFS.dlgPrint.Document = ReportDoc;
					if (My.MyProject.Forms.mdiCFS.dlgPrint.ShowDialog () == DialogResult.OK) {
						CFSInterface.strPrinterName = ReportDoc.PrinterSettings.PrinterName;
						ReportDoc.Print ();
					}
					break;
				case 394:
					num = -1;
					switch (num2) {
					case 2:
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						break;
					default:
						goto end_IL_0000;
					}
					break;
				}
				rtfHeader.Dispose ();
				rtfFooter.Dispose ();
				rtfMain.Dispose ();
				Cursor.Current = Cursors.Default;
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 394;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private static void ReportDoc_PrintPage (object sender, PrintPageEventArgs e)
	{
		InitializePage (e, 1.25f, 0.5f, 0.5f, 0.5f);
		if (lngCharPosStart == 0) {
			PrepareNextReport ();
		}
		PrintHeader (e);
		checked {
			short num = default(short);
			if ((intPage == 1) & (intGraphicType != 0)) {
				rcGraphic.Left = fr.rc.Left;
				rcGraphic.Right = rcGraphic.Left + 8640;
				rcGraphic.Top = (int)System.Math.Round ((double)fr.rc.Top + 360.0);
				rcGraphic.Bottom = rcGraphic.Top + 2880;
				if (intGraphicType == 2) {
					rcGraphic.Bottom = fr.rc.Bottom;
				}
				if (intGraphicType == 4) {
					rcGraphic.Bottom = rcGraphic.Top + 5760;
				}
				GraphicsX gX = new GraphicsX (ref e);
				switch (intGraphicType) {
				case 1:
				case 2:
					if (PrintSct (gX, CFS.Sections [hGraphic], rcGraphic)) {
						fr.rc.Top = rcGraphic.Bottom;
					}
					break;
				case 3:
				case 4:
					if (PrintAnl (gX, CFS.Analyses [hGraphic], rcGraphic)) {
						fr.rc.Top = rcGraphic.Bottom;
					}
					break;
				}
				gX = null;
				num = (short)(num + 1);
			}
			while (lngCharPosStart < Strings.Len (rtfMain.Text)) {
				fr.chrg.cpMin = lngCharPosStart;
				int num2 = Strings.InStr (lngCharPosStart + 1, rtfMain.Text, Report.strPage);
				fr.chrg.cpMax = Conversions.ToInteger (Interaction.IIf (num2 > 0, num2 + 1, Strings.Len (rtfMain.Text)));
				num2 = PrintRTF (rtfMain, e, RTFMethod.Check);
				unchecked {
					if (!(checked(((num2 >= fr.chrg.cpMax) & (rcDrawTo.Bottom - fr.rc.Bottom >= 20)) | (rcDrawTo.Bottom - fr.rc.Top >= 5760)) || num == 0)) {
						break;
					}
					PrintRTF (rtfMain, e, RTFMethod.Commit);
					lngCharPosStart = num2;
				}
				num = (short)(num + 1);
				fr.rc.Top = fr.rc.Bottom;
				fr.rc.Right = rcDrawTo.Right;
				fr.rc.Bottom = rcDrawTo.Bottom;
			}
			PrintFooter (e);
			if (lngCharPosStart < Strings.Len (rtfMain.Text)) {
				e.HasMorePages = true;
			} else if (intCheckedItem < My.MyProject.Forms.frmPrint.lstPrint.CheckedItems.Count - 1) {
				intCheckedItem++;
				lngCharPosStart = 0;
				e.HasMorePages = true;
			}
		}
	}

	private static void PrepareNextReport ()
	{
		Heading hdgHeading = default(Heading);
		string source = Conversions.ToString (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem], null, "Text", new object[0], null, null, null));
		short num = Conversions.ToShort (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem], null, "ItemData", new object[0], null, null, null));
		rtfHeader.Clear ();
		rtfMain.Clear ();
		intPage = 0;
		checked {
			if (LikeOperator.LikeString (source, "Large Section Graphic*", CompareMethod.Binary)) {
				hdgHeading.AppVer = CFS.Sections [num].AppVer;
				hdgHeading.Description = CFS.Sections [num].Description;
				hdgHeading.Filename = CFS.Sections [num].Filename;
				hdgHeading.Project = CFS.Sections [num].Project;
				hdgHeading.RevBy = CFS.Sections [num].RevBy;
				hdgHeading.RevDate = CFS.Sections [num].RevDate;
				hdgHeading.Parent = 1;
				Report.rptHeading (rtfHeader, hdgHeading, blnPage: true);
				hGraphic = num;
				intGraphicType = 2;
			} else if (LikeOperator.LikeString (source, "Section Inputs*", CompareMethod.Binary)) {
				hdgHeading.AppVer = CFS.Sections [num].AppVer;
				hdgHeading.Description = CFS.Sections [num].Description;
				hdgHeading.Filename = CFS.Sections [num].Filename;
				hdgHeading.Project = CFS.Sections [num].Project;
				hdgHeading.RevBy = CFS.Sections [num].RevBy;
				hdgHeading.RevDate = CFS.Sections [num].RevDate;
				hdgHeading.Parent = 1;
				Report.rptHeading (rtfHeader, hdgHeading, blnPage: true);
				Report.rptSctInp (rtfMain, CFS.Sections [num]);
				hGraphic = num;
				intGraphicType = 1;
				if (Conversions.ToBoolean (intCheckedItem > 0 && Conversions.ToBoolean (LikeOperator.LikeObject (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem - 1], null, "Text", new object[0], null, null, null), "Large Section Graphic*", CompareMethod.Binary))) && Operators.ConditionalCompareObjectEqual (num, NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem - 1], null, "ItemData", new object[0], null, null, null), TextCompare: false)) {
					intGraphicType = 0;
				}
				if (intCheckedItem < My.MyProject.Forms.frmPrint.lstPrint.CheckedItems.Count - 1 && Conversions.ToBoolean (LikeOperator.LikeObject (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem + 1], null, "Text", new object[0], null, null, null), "Report*", CompareMethod.Binary))) {
					short num2 = Conversions.ToShort (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem + 1], null, "ItemData", new object[0], null, null, null));
					if ((CFS.hdgReport [num2].Parent == 1) & (Operators.CompareString (CFS.Sections [num].Filename, CFS.hdgReport [num2].Filename, TextCompare: false) == 0) & (DateTime.Compare (CFS.Sections [num].RevDate, CFS.hdgReport [num2].RevDate) == 0) & (CFS.Sections [num].AppVer == CFS.hdgReport [num2].AppVer)) {
						rtfMain.SelectionStart = Strings.Len (rtfMain.Text);
						rtfMain.SelectedText = Report.strPage;
						Report.AppendRTF (rtfMain, CFS.frmReport [num2].rtfReport);
						intCheckedItem++;
					}
				}
			} else if (LikeOperator.LikeString (source, "Analysis Inputs*", CompareMethod.Binary)) {
				hdgHeading.AppVer = CFS.Analyses [num].AppVer;
				hdgHeading.Description = CFS.Analyses [num].Description;
				hdgHeading.Filename = CFS.Analyses [num].Filename;
				hdgHeading.Project = CFS.Analyses [num].Project;
				hdgHeading.RevBy = CFS.Analyses [num].RevBy;
				hdgHeading.RevDate = CFS.Analyses [num].RevDate;
				hdgHeading.Parent = 2;
				Report.rptHeading (rtfHeader, hdgHeading, blnPage: true);
				CFSInterface.SortBeams (CFS.Analyses [num]);
				CFSInterface.SortSups (CFS.Analyses [num]);
				int nLdg = CFS.Analyses [num].nLdg;
				for (int i = 1; i <= nLdg; i++) {
					CFSInterface.SortLoads (ref CFS.Analyses [num].Ldg [i]);
				}
				if (num == CFS.intAnlNow) {
					CFSInterface.RefreshAnl (CFS.Analyses [num]);
					CFSInterface.PlotAnl (CFS.frmAnlPic [num], CFS.Analyses [num]);
				}
				Report.rptAnlInp (rtfMain, CFS.Analyses [num]);
				hGraphic = num;
				intGraphicType = Conversions.ToShort (Interaction.IIf (CFS.Analyses [num].Vertical, (short)4, (short)3));
				if (intCheckedItem < My.MyProject.Forms.frmPrint.lstPrint.CheckedItems.Count - 1 && Conversions.ToBoolean (LikeOperator.LikeObject (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem + 1], null, "Text", new object[0], null, null, null), "Report*", CompareMethod.Binary))) {
					short num2 = Conversions.ToShort (NewLateBinding.LateGet (My.MyProject.Forms.frmPrint.lstPrint.CheckedItems [intCheckedItem + 1], null, "ItemData", new object[0], null, null, null));
					if ((CFS.hdgReport [num2].Parent == 2) & (Operators.CompareString (CFS.Analyses [num].Filename, CFS.hdgReport [num2].Filename, TextCompare: false) == 0) & (DateTime.Compare (CFS.Analyses [num].RevDate, CFS.hdgReport [num2].RevDate) == 0) & (CFS.Analyses [num].AppVer == CFS.hdgReport [num2].AppVer)) {
						rtfMain.SelectionStart = Strings.Len (rtfMain.Text);
						rtfMain.SelectedText = Report.strPage;
						Report.AppendRTF (rtfMain, CFS.frmReport [num2].rtfReport);
						intCheckedItem++;
					}
				}
			} else if (LikeOperator.LikeString (source, "Report*", CompareMethod.Binary)) {
				Report.rptHeading (rtfHeader, CFS.hdgReport [num], blnPage: true);
				rtfMain.Rtf = CFS.frmReport [num].rtfReport.Rtf;
				hGraphic = 0;
				intGraphicType = 0;
			}
		}
	}

	private static bool PrintSct (GraphicsX GX, Section Section1, RECT rcSct)
	{
		bool result = false;
		Section section = Section1;
		section.Extents ();
		float num = section.Xmin;
		float num2 = section.Ymin;
		float num3 = section.Xmax;
		float num4 = section.Ymax;
		if (num > 0f) {
			num = 0f;
		}
		if (num2 > 0f) {
			num2 = 0f;
		}
		if (num3 < 0f) {
			num3 = 0f;
		}
		if (num4 < 0f) {
			num4 = 0f;
		}
		if (section.SctProp) {
			if (section.Prop.Xcg + section.Prop.Xo < num) {
				num = section.Prop.Xcg + section.Prop.Xo;
			}
			if (section.Prop.Ycg + section.Prop.Yo < num2) {
				num2 = section.Prop.Ycg + section.Prop.Yo;
			}
			if (section.Prop.Xcg + section.Prop.Xo > num3) {
				num3 = section.Prop.Xcg + section.Prop.Xo;
			}
			if (section.Prop.Ycg + section.Prop.Yo > num4) {
				num4 = section.Prop.Ycg + section.Prop.Yo;
			}
		}
		section.ExtXmin = num;
		section.ExtYmin = num2;
		section.ExtXmax = num3;
		section.ExtYmax = num4;
		if (!(num == num3 && num2 == num4)) {
			float num5 = (float)(0.5 * (double)num + 0.5 * (double)num3);
			float num6 = (float)(0.5 * (double)num2 + 0.5 * (double)num4);
			float num7 = (float)((double)(num3 - num) * 0.525);
			float num8 = (float)((double)(num4 - num2) * 0.525);
			checked {
				float num9 = (float)((double)(rcSct.Bottom - rcSct.Top) / (double)(rcSct.Right - rcSct.Left));
				float num10;
				if (num9 * num7 > num8) {
					num8 = num9 * num7;
					num10 = (float)(0.05 * (double)num7);
				} else {
					num7 = num8 / num9;
					num10 = (float)(0.05 * (double)num8);
				}
				float num11 = 2f * num7 / (float)(rcSct.Right - rcSct.Left);
				float num12 = 2f * num8 / (float)(rcSct.Bottom - rcSct.Top);
				num = num5 - num7 - (float)(rcSct.Left - fr.rcPage.Left) * num11;
				num2 = num6 + num8 + (float)(rcSct.Top - fr.rcPage.Top) * num12;
				num3 = num + (float)(fr.rcPage.Right - fr.rcPage.Left) * num11;
				num4 = num2 - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num12;
				GX.Scale (num, num2, num3, num4);
				Pen pen = new Pen (Color.Black, GX.PenScale / 300f);
				short nPart = section.nPart;
				for (short num13 = 1; num13 <= nPart; num13 = (short)unchecked(num13 + 1)) {
					float thickness = section.Part [num13].Thickness;
					num7 = section.Part [num13].XPosition - section.Part [num13].Xcg;
					num8 = section.Part [num13].YPosition - section.Part [num13].Ycg;
					GX.Graphics.FillEllipse (Brushes.Black, section.Part [num13].XPosition - num10 / 16f, section.Part [num13].YPosition - num10 / 16f, num10 / 8f, num10 / 8f);
					if (section.Part [num13].nElem > 0) {
						float ang = section.Part [num13].Element [section.Part [num13].nElem].Ang;
						short nElem = section.Part [num13].nElem;
						for (short num14 = 1; num14 <= nElem; num14 = (short)unchecked(num14 + 1)) {
							if ((num14 > 1) | section.Part [num13].Closed) {
								num5 = num7 + section.Part [num13].Element [num14].Xac;
								num6 = num8 + section.Part [num13].Element [num14].Yac;
								float arc = section.Part [num13].Element [num14].Arc;
								float rad = section.Part [num13].Element [num14].Rad;
								PrintArc (GX, pen, num5, num6, rad, ang, arc);
								PrintArc (GX, pen, num5, num6, rad + thickness, ang, arc);
							}
							ang = section.Part [num13].Element [num14].Ang;
							float num15 = (float)((double)(thickness / 2f) * System.Math.Sin (ang));
							float num16 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (ang));
							num = num7 + section.Part [num13].Element [num14].X0;
							num2 = num8 + section.Part [num13].Element [num14].Y0;
							num3 = num7 + section.Part [num13].Element [num14].X1;
							num4 = num8 + section.Part [num13].Element [num14].Y1;
							if ((num14 == 1) & !section.Part [num13].Closed) {
								GX.Graphics.DrawLine (pen, num - num15, num2 - num16, num + num15, num2 + num16);
							}
							GX.Graphics.DrawLine (pen, num - num15, num2 - num16, num3 - num15, num4 - num16);
							GX.Graphics.DrawLine (pen, num + num15, num2 + num16, num3 + num15, num4 + num16);
							if ((num14 == section.Part [num13].nElem) & !section.Part [num13].Closed) {
								GX.Graphics.DrawLine (pen, num3 - num15, num4 - num16, num3 + num15, num4 + num16);
							}
							if (section.Part [num13].Element [num14].Hole > 0f) {
								num = num7 + section.Part [num13].Element [num14].Xh0;
								num2 = num8 + section.Part [num13].Element [num14].Yh0;
								num3 = num7 + section.Part [num13].Element [num14].Xh1;
								num4 = num8 + section.Part [num13].Element [num14].Yh1;
								GX.Graphics.DrawLine (pen, num - num15, num2 - num16, num + num15, num2 + num16);
								GX.Graphics.DrawLine (pen, num, num2, num3, num4);
								GX.Graphics.DrawLine (pen, num3 - num15, num4 - num16, num3 + num15, num4 + num16);
							}
						}
					}
				}
				if (section.nPart > 0) {
					GX.Graphics.DrawLine (pen, 0f - num10, 0f, num10, 0f);
					GX.Graphics.DrawLine (pen, 0f, 0f - num10, 0f, num10);
					if (section.SctProp) {
						num7 = (float)((double)num10 * System.Math.Cos (section.Prop.Alpha));
						num8 = (float)((double)num10 * System.Math.Sin (section.Prop.Alpha));
						GX.Graphics.DrawLine (pen, section.Prop.Xcg - 5f * num7, section.Prop.Ycg - 5f * num8, section.Prop.Xcg + 5f * num7, section.Prop.Ycg + 5f * num8);
						GX.Graphics.DrawLine (pen, section.Prop.Xcg - num8, section.Prop.Ycg + num7, section.Prop.Xcg + num8, section.Prop.Ycg - num7);
						GX.Graphics.DrawLine (pen, section.Prop.Xcg + section.Prop.Xo - num10, section.Prop.Ycg + section.Prop.Yo, section.Prop.Xcg + section.Prop.Xo + num10, section.Prop.Ycg + section.Prop.Yo);
						GX.Graphics.DrawLine (pen, section.Prop.Xcg + section.Prop.Xo, section.Prop.Ycg + section.Prop.Yo - num10, section.Prop.Xcg + section.Prop.Xo, section.Prop.Ycg + section.Prop.Yo + num10);
						GX.Graphics.DrawEllipse (pen, section.Prop.Xcg + section.Prop.Xo - num10 / 2f, section.Prop.Ycg + section.Prop.Yo - num10 / 2f, num10, num10);
					}
				}
				section = null;
				result = true;
			}
		}
		return result;
	}

	private static void PrintArc (GraphicsX GX, Pen p, float X, float Y, float R, float A, float Arc)
	{
		if (!((double)System.Math.Abs (R * Arc) <= 0.001 * (double)GX.XUnitsPerInch)) {
			float num = (float)((double)A - (double)System.Math.Sign (Arc) * System.Math.PI / 2.0);
			GX.Graphics.DrawArc (p, X - R, Y - R, 2f * R, 2f * R, (float)((double)(num * 180f) / System.Math.PI), (float)((double)(Arc * 180f) / System.Math.PI));
		}
	}

	private static bool PrintAnl (GraphicsX GX, Analysis Analysis1, RECT rcAnl)
	{
		float[] array = new float[5];
		bool result = false;
		checked {
			if (!((Analysis1.nBeam == 0) & (Analysis1.nSup == 0))) {
				Analysis analysis = Analysis1;
				analysis.ZExtents ();
				float num = (float)((double)(rcAnl.Bottom - rcAnl.Top) / (double)(rcAnl.Right - rcAnl.Left));
				if (analysis.Vertical) {
					num = 1f / num;
				}
				float num2 = (float)(0.5 * (double)analysis.Zmin + 0.5 * (double)analysis.Zmax);
				float num3 = 0f;
				float num4 = (float)((double)(analysis.Zmax - analysis.Zmin) * 0.525);
				float num5 = num * num4;
				float num6 = (analysis.Zmax - analysis.Zmin) / 8f;
				if (num4 == 0f) {
					num4 = 1f;
					num5 = num * num4;
					num6 = 0.25f;
				}
				float X;
				float Y;
				float X2;
				float Y2;
				if (analysis.Vertical) {
					float num7 = 2f * num5 / (float)(rcAnl.Right - rcAnl.Left);
					float num8 = 2f * num4 / (float)(rcAnl.Bottom - rcAnl.Top);
					X = num3 - num5 - (float)(rcAnl.Left - fr.rcPage.Left) * num7;
					Y = num2 - num4 - (float)(rcAnl.Top - fr.rcPage.Top) * num8;
					X2 = X + (float)(fr.rcPage.Right - fr.rcPage.Left) * num7;
					Y2 = Y + (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num8;
				} else {
					float num7 = 2f * num4 / (float)(rcAnl.Right - rcAnl.Left);
					float num8 = 2f * num5 / (float)(rcAnl.Bottom - rcAnl.Top);
					X = num2 - num4 - (float)(rcAnl.Left - fr.rcPage.Left) * num7;
					Y = num3 + num5 + (float)(rcAnl.Top - fr.rcPage.Top) * num8;
					X2 = X + (float)(fr.rcPage.Right - fr.rcPage.Left) * num7;
					Y2 = Y - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num8;
				}
				GX.Scale (X, Y, X2, Y2);
				float num9 = num6 / 80f;
				Pen pen = new Pen (Color.Black, num9);
				array [2] = (float)System.Math.PI / 2f;
				array [1] = 4.712389f;
				array [3] = (float)System.Math.PI;
				array [4] = 0f;
				float num10 = num6 / 12f;
				float num11 = (0f - num9) / 2f;
				float num12 = num9 / 2f;
				float num13 = num11;
				short nBeam = analysis.nBeam;
				for (short num14 = 1; num14 <= nBeam; num14 = (short)unchecked(num14 + 1)) {
					if (num14 > 1 && analysis.Beam [num14].Z0 < analysis.Beam [num14 - 1].Z1) {
						num13 = num11 + num12 - num13;
					}
					if (analysis.Vertical) {
						GX.Graphics.DrawLine (pen, num13, analysis.Beam [num14].Z0, num13, analysis.Beam [num14].Z1);
					} else {
						GX.Graphics.DrawLine (pen, analysis.Beam [num14].Z0, num13, analysis.Beam [num14].Z1, num13);
					}
					if (analysis.Beam [num14].iBrcFlg > 0) {
						CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] - System.Math.PI / 10.0), analysis.Beam [num14].Z0, ref X, ref Y);
						CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] - System.Math.PI / 10.0), analysis.Beam [num14].Z1, ref X2, ref Y2);
						if (analysis.Vertical) {
							GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
						CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] + System.Math.PI / 10.0), analysis.Beam [num14].Z0, ref X, ref Y);
						CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] + System.Math.PI / 10.0), analysis.Beam [num14].Z1, ref X2, ref Y2);
						if (analysis.Vertical) {
							GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
						float num15 = analysis.Beam [num14].Z1 - analysis.Beam [num14].Z0;
						short num16 = (short)System.Math.Ceiling (System.Math.Abs (num15 / (3f * num10)));
						if (num16 > 0) {
							num15 /= (float)num16;
						}
						float num17 = analysis.Beam [num14].Z0;
						short num18 = num16;
						for (short num19 = 0; num19 <= num18; num19 = (short)unchecked(num19 + 1)) {
							CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] - System.Math.PI / 10.0), num17, ref X, ref Y);
							CFSInterface.CylToPlane (num6 / 3f, (float)((double)array [analysis.Beam [num14].iBrcFlg] + System.Math.PI / 10.0), num17, ref X2, ref Y2);
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
							} else {
								GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
							}
							num17 += num15;
						}
					}
				}
				short nSup = analysis.nSup;
				for (short num14 = 1; num14 <= nSup; num14 = (short)unchecked(num14 + 1)) {
					float num15 = analysis.Sup [num14].Z;
					short num20 = (short)System.Math.Sign ((analysis.Zmin + analysis.Zmax) / 2f - num15);
					if (num20 == 0) {
						num20 = 1;
					}
					if ((analysis.Sup [num14].Type & 1) == 1) {
						CFSInterface.CylToPlane (num6 / 4f, (float)System.Math.PI, num15, ref X, ref Y);
						CFSInterface.CylToPlane (num6 / 4f, 0f, num15, ref X2, ref Y2);
						if (analysis.Vertical) {
							GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
					}
					if ((analysis.Sup [num14].Type & 2) == 2) {
						if (analysis.Vertical) {
							GX.Graphics.DrawLine (pen, num6 / 4f, num15, (0f - num6) / 4f, num15);
						} else {
							GX.Graphics.DrawLine (pen, num15, num6 / 4f, num15, (0f - num6) / 4f);
						}
					}
					if ((analysis.Sup [num14].Type & 4) == 4) {
						if (analysis.Vertical) {
							GX.Graphics.DrawEllipse (pen, num11 - num6 / 8f, num15 - num6 / 8f / 2.2f, num6 / 4f, num6 / 4f / 2.2f);
						} else {
							GX.Graphics.DrawEllipse (pen, num15 - num6 / 8f / 2.2f, num11 - num6 / 8f, num6 / 4f / 2.2f, num6 / 4f);
						}
					}
					if ((analysis.Sup [num14].Type & 8) == 8) {
						short num19 = -3;
						do {
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, (float)num19 * num10, num15, (float)(num19 - 1) * num10, num15 - (float)num20 * num10);
							} else {
								GX.Graphics.DrawLine (pen, num15, (float)num19 * num10, num15 - (float)num20 * num10, (float)(num19 - 1) * num10);
							}
							num19 = (short)unchecked(num19 + 1);
						} while (num19 <= 3);
					}
					if ((analysis.Sup [num14].Type & 0x10) == 16) {
						CFSInterface.CylToPlane (num6 / 4f, (float)System.Math.PI, num15, ref X, ref Y);
						CFSInterface.CylToPlane (num6 / 4f, 0f, num15, ref X2, ref Y2);
						float num21 = (X2 - X) / 4f;
						num5 = (Y2 - Y) / 4f;
						short num19 = -2;
						do {
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, (float)num19 * num5, num15 + (float)num19 * num21, (float)num19 * num5, num15 + (float)num19 * num21 - (float)num20 * num10 * 1.4142f);
							} else {
								GX.Graphics.DrawLine (pen, num15 + (float)num19 * num21, (float)num19 * num5, num15 + (float)num19 * num21 - (float)num20 * num10 * 1.4142f, (float)num19 * num5);
							}
							num19 = (short)unchecked(num19 + 1);
						} while (num19 <= 2);
					}
					if ((analysis.Sup [num14].Type & 0x20) == 32) {
						if (analysis.Vertical) {
							GX.Graphics.DrawEllipse (pen, num11 - num6 / 16f, num15 - num6 / 16f, num6 / 8f, num6 / 8f);
						} else {
							GX.Graphics.DrawEllipse (pen, num15 - num6 / 16f, num11 - num6 / 16f, num6 / 8f, num6 / 8f);
						}
					}
					if ((analysis.Sup [num14].Type & 0x40) == 64) {
						if (analysis.Vertical) {
							GX.Graphics.DrawEllipse (pen, num11 - num6 / 16f / 2.2f, num15 - num6 / 16f, num6 / 8f / 2.2f, num6 / 8f);
						} else {
							GX.Graphics.DrawEllipse (pen, num15 - num6 / 16f, num11 - num6 / 16f / 2.2f, num6 / 8f, num6 / 8f / 2.2f);
						}
					}
				}
				short nSup2 = analysis.nSup;
				for (short num14 = 1; num14 <= nSup2; num14 = (short)unchecked(num14 + 1)) {
					if ((analysis.Sup [num14].K == 0f) & ((analysis.Sup [num14].Type & 1) == 1)) {
						float num17 = analysis.Sup [num14].Z;
						float num22 = num17;
						short num23 = (short)(num14 + 1);
						short nSup3 = analysis.nSup;
						for (short num19 = num23; num19 <= nSup3; num19 = (short)unchecked(num19 + 1)) {
							if ((analysis.Sup [num19].Type & 1) == 1) {
								num22 = analysis.Sup [num19].Z;
								num14 = num19;
								if (analysis.Sup [num19].K > 0f) {
									break;
								}
							}
						}
						if (num22 > num17) {
							CFSInterface.CylToPlane (num6 / 4f, 0f, num17, ref X, ref Y);
							CFSInterface.CylToPlane (num6 / 4f, 0f, num22, ref X2, ref Y2);
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
							} else {
								GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
							}
							CFSInterface.CylToPlane (num6 / 4f, (float)System.Math.PI, num17, ref X, ref Y);
							CFSInterface.CylToPlane (num6 / 4f, (float)System.Math.PI, num22, ref X2, ref Y2);
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, Y, X, Y2, X2);
							} else {
								GX.Graphics.DrawLine (pen, X, Y, X2, Y2);
							}
						}
					}
				}
				short nSup4 = analysis.nSup;
				for (short num14 = 1; num14 <= nSup4; num14 = (short)unchecked(num14 + 1)) {
					if ((analysis.Sup [num14].K == 0f) & ((analysis.Sup [num14].Type & 2) == 2)) {
						float num17 = analysis.Sup [num14].Z;
						float num22 = num17;
						short num24 = (short)(num14 + 1);
						short nSup5 = analysis.nSup;
						for (short num19 = num24; num19 <= nSup5; num19 = (short)unchecked(num19 + 1)) {
							if ((analysis.Sup [num19].Type & 2) == 2) {
								num22 = analysis.Sup [num19].Z;
								num14 = num19;
								if (analysis.Sup [num19].K > 0f) {
									break;
								}
							}
						}
						if (num22 > num17) {
							if (analysis.Vertical) {
								GX.Graphics.DrawLine (pen, num6 / 4f, num17, num6 / 4f, num22);
								GX.Graphics.DrawLine (pen, (0f - num6) / 4f, num17, (0f - num6) / 4f, num22);
							} else {
								GX.Graphics.DrawLine (pen, num17, num6 / 4f, num22, num6 / 4f);
								GX.Graphics.DrawLine (pen, num17, (0f - num6) / 4f, num22, (0f - num6) / 4f);
							}
						}
					}
				}
				analysis = null;
				result = true;
			}
			return result;
		}
	}

	public static void PrintBuckling ()
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					rtfHeader = new RichTextBox ();
					ProjectData.ClearProjectError ();
					num2 = 2;
					Cursor.Current = Cursors.WaitCursor;
					BucklingDoc = new PrintDocument ();
					BucklingDoc.PrinterSettings.PrinterName = CFSInterface.strPrinterName;
					BucklingDoc.DocumentName = "Elastic Buckling: " + CFSInterface.GetFileNameWithoutExtension (CFS.Sections [CFS.intSctNow].Filename);
					BucklingDoc.PrintController = new StandardPrintController ();
					Heading hdgHeading = default(Heading);
					hdgHeading.AppVer = CFS.Sections [CFS.intSctNow].AppVer;
					hdgHeading.Description = CFS.Sections [CFS.intSctNow].Description;
					hdgHeading.Filename = CFS.Sections [CFS.intSctNow].Filename;
					hdgHeading.Project = CFS.Sections [CFS.intSctNow].Project;
					hdgHeading.RevBy = CFS.Sections [CFS.intSctNow].RevBy;
					hdgHeading.RevDate = CFS.Sections [CFS.intSctNow].RevDate;
					Report.rptHeading (rtfHeader, hdgHeading, blnPage: true);
					rtfHeader.SelectedText = "\r\n";
					string text = "Finit Strip Elastic Buckling";
					if (CFSInterface.BuckleParametersNow.Repeat) {
						text += " (repeating connected shape)";
					}
					Report.rptTitle (rtfHeader, text);
					intPage = 0;
					My.MyProject.Forms.mdiCFS.dlgPrint.Document = BucklingDoc;
					if (My.MyProject.Forms.mdiCFS.dlgPrint.ShowDialog () == DialogResult.OK) {
						CFSInterface.strPrinterName = BucklingDoc.PrinterSettings.PrinterName;
						BucklingDoc.Print ();
					}
					break;
				}
				case 497:
					num = -1;
					switch (num2) {
					case 2:
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						break;
					default:
						goto end_IL_0000;
					}
					break;
				}
				rtfHeader.Dispose ();
				Cursor.Current = Cursors.Default;
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 497;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private static void BucklingDoc_PrintPage (object sender, PrintPageEventArgs e)
	{
		InitializePage (e, 1.25f, 0.5f, 0.5f, 0.5f);
		PrintHeader (e);
		checked {
			if (intPage == 1) {
				rcGraphic.Left = fr.rc.Left;
				rcGraphic.Right = rcGraphic.Left + 8640;
				rcGraphic.Top = fr.rc.Top;
				rcGraphic.Bottom = (int)System.Math.Round ((double)rcGraphic.Top + 6120.0);
				if (rcGraphic.Bottom > rcDrawTo.Bottom) {
					rcGraphic.Bottom = rcDrawTo.Bottom;
				}
				FiniteStrip.PrintProfile (new GraphicsX (ref e), rcGraphic);
				fr.rc.Top = rcGraphic.Bottom;
				intLength = 0;
			}
			while (intLength < Information.UBound (FiniteStrip.Buckle)) {
				intLength++;
				float num = 0f;
				if (intLength > 1) {
					if (FiniteStrip.Buckle [intLength - 1].HoleMode == FiniteStrip.Buckle [intLength].HoleMode) {
						num = FiniteStrip.Buckle [intLength - 1].LF;
					}
					if (FiniteStrip.Buckle [intLength].HoleMode == FiniteStrip.HoleMode.Distortional) {
						num = FiniteStrip.Buckle [intLength].LF + 1f;
					}
				}
				float lF = FiniteStrip.Buckle [intLength].LF;
				if (intLength < Information.UBound (FiniteStrip.Buckle)) {
					if (FiniteStrip.Buckle [intLength + 1].HoleMode == FiniteStrip.Buckle [intLength].HoleMode) {
						lF = FiniteStrip.Buckle [intLength + 1].LF;
					}
					if (FiniteStrip.Buckle [intLength].HoleMode == FiniteStrip.HoleMode.Distortional) {
						lF = FiniteStrip.Buckle [intLength].LF;
					}
				}
				if ((FiniteStrip.Buckle [intLength].LF < num) & (FiniteStrip.Buckle [intLength].LF <= lF)) {
					if ((double)fr.rc.Top + 2520.0 > (double)rcDrawTo.Bottom) {
						intLength--;
						e.HasMorePages = true;
						break;
					}
					rcGraphic.Left = fr.rc.Left + 2880;
					rcGraphic.Right = rcGraphic.Left + 5760;
					rcGraphic.Top = fr.rc.Top;
					rcGraphic.Bottom = (int)System.Math.Round ((double)rcGraphic.Top + 2520.0);
					FiniteStrip.PrintModeShape (new GraphicsX (ref e), rcGraphic, intLength);
					fr.rc.Top = rcGraphic.Bottom;
				}
			}
		}
	}

	public static void PrintDiagrams (short iDir, bool blnEnv)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					rtfHeader = new RichTextBox ();
					ProjectData.ClearProjectError ();
					num2 = 2;
					Cursor.Current = Cursors.WaitCursor;
					DiagramsDoc = new PrintDocument ();
					DiagramsDoc.PrinterSettings.PrinterName = CFSInterface.strPrinterName;
					DiagramsDoc.DocumentName = "Diagrams: " + CFSInterface.GetFileNameWithoutExtension (CFS.Analyses [CFS.intAnlNow].Filename);
					DiagramsDoc.PrintController = new StandardPrintController ();
					Heading hdgHeading = default(Heading);
					hdgHeading.AppVer = CFS.Analyses [CFS.intAnlNow].AppVer;
					hdgHeading.Description = CFS.Analyses [CFS.intAnlNow].Description;
					hdgHeading.Filename = CFS.Analyses [CFS.intAnlNow].Filename;
					hdgHeading.Project = CFS.Analyses [CFS.intAnlNow].Project;
					hdgHeading.RevBy = CFS.Analyses [CFS.intAnlNow].RevBy;
					hdgHeading.RevDate = CFS.Analyses [CFS.intAnlNow].RevDate;
					Report.rptHeading (rtfHeader, hdgHeading, blnPage: true);
					rtfHeader.SelectedText = "\r\n";
					Analysis analysis = CFS.Analyses [CFS.intAnlNow];
					string text = ((!blnEnv) ? ("Load Combination: " + analysis.Comb [analysis.iCombSol].Description + ", ") : "Envelope of all combinations, ");
					text = iDir switch {
						1 => text + "Y Direction", 
						2 => text + "X Direction", 
						_ => text + "Torsion", 
					};
					analysis = null;
					Report.rptTitle (rtfHeader, text);
					intPage = 0;
					intDiagramDir = iDir;
					blnDiagramEnv = blnEnv;
					My.MyProject.Forms.mdiCFS.dlgPrint.Document = DiagramsDoc;
					if (My.MyProject.Forms.mdiCFS.dlgPrint.ShowDialog () == DialogResult.OK) {
						CFSInterface.strPrinterName = DiagramsDoc.PrinterSettings.PrinterName;
						DiagramsDoc.Print ();
					}
					break;
				}
				case 594:
					num = -1;
					switch (num2) {
					case 2:
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						break;
					default:
						goto end_IL_0000;
					}
					break;
				}
				rtfHeader.Dispose ();
				Cursor.Current = Cursors.Default;
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 594;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private static void DiagramsDoc_PrintPage (object sender, PrintPageEventArgs e)
	{
		InitializePage (e, 1.25f, 0.5f, 0.5f, 0.5f);
		PrintHeader (e);
		rcGraphic.Left = fr.rc.Left;
		checked {
			rcGraphic.Right = (int)System.Math.Round ((double)fr.rc.Left + 9600.48);
			rcGraphic.Top = fr.rc.Top;
			rcGraphic.Bottom = rcGraphic.Top + 11520;
			if (rcGraphic.Bottom > rcDrawTo.Bottom) {
				rcGraphic.Bottom = rcDrawTo.Bottom;
			}
			GraphicsX gX = new GraphicsX (ref e);
			if (intDiagramDir == 4) {
				if (blnDiagramEnv) {
					PrintTorsionEnv (gX, CFS.Analyses [CFS.intAnlNow], rcGraphic);
				} else {
					PrintTorsionDiag (gX, CFS.Analyses [CFS.intAnlNow], rcGraphic);
				}
			} else if (blnDiagramEnv) {
				PrintDiagEnv (gX, CFS.Analyses [CFS.intAnlNow], intDiagramDir, rcGraphic);
			} else {
				PrintDiag (gX, CFS.Analyses [CFS.intAnlNow], intDiagramDir, rcGraphic);
			}
			gX = null;
		}
	}

	public static void PrintDiag (GraphicsX GX, Analysis Analysis1, short iDir, RECT rcAnl)
	{
		SolutionDetail Det = default(SolutionDetail);
		Brush black = Brushes.Black;
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		Analysis analysis = Analysis1;
		analysis.Sol [iDir].MinimaMaxima (ref Det);
		analysis.Rmax = 0f;
		short nNode = analysis.Sol [iDir].nNode;
		float x2;
		int nV2;
		checked {
			float num2 = default(float);
			short num;
			for (num = 1; num <= nNode; num = (short)unchecked(num + 1)) {
				if (analysis.Sol [iDir].D [num] == 0f) {
					num2 = 0f;
					if (num < analysis.Sol [iDir].nNode) {
						num2 += analysis.Sol [iDir].V [num, 1];
					}
					if (num > 1) {
						num2 += analysis.Sol [iDir].V [num - 1, 2];
					}
					if (System.Math.Abs (num2) > analysis.Rmax) {
						analysis.Rmax = System.Math.Abs (num2);
					}
				}
			}
			analysis.Vmax = 0f;
			int nV = Det.NV;
			for (int i = 1; i <= nV; i++) {
				if (System.Math.Abs (Det.V [i]) > analysis.Vmax) {
					analysis.Vmax = System.Math.Abs (Det.V [i]);
				}
			}
			analysis.Mmax = 0f;
			int nM = Det.NM;
			for (int j = 1; j <= nM; j++) {
				if (System.Math.Abs (Det.M [j]) > analysis.Mmax) {
					analysis.Mmax = System.Math.Abs (Det.M [j]);
				}
			}
			analysis.Dmax = 0f;
			int nD = Det.ND;
			for (int k = 1; k <= nD; k++) {
				if (System.Math.Abs (Det.D [k]) > analysis.Dmax) {
					analysis.Dmax = System.Math.Abs (Det.D [k]);
				}
			}
			float num3 = analysis.Zmax - analysis.Zmin;
			float num4 = (float)((double)num3 / 0.75 / (double)(rcAnl.Right - rcAnl.Left));
			float num5 = (float)(8.0 / (double)(rcAnl.Bottom - rcAnl.Top));
			float num6 = (float)((double)analysis.Zmin - 0.15 * (double)num3 / 0.75 - (double)((float)(rcAnl.Left - fr.rcPage.Left) * num4));
			float num7 = 8f + (float)(rcAnl.Top - fr.rcPage.Top) * num5;
			float x = num6 + (float)(fr.rcPage.Right - fr.rcPage.Left) * num4;
			float y = num7 - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num5;
			GX.Scale (num6, num7, x, y);
			float num8 = num3 / 96f;
			float num9 = num8 * System.Math.Abs (GX.Width / GX.ScaleWidth) / System.Math.Abs (GX.Height / GX.ScaleHeight);
			Pen pen = new Pen (Color.Black, (float)(0.016 * (double)GX.PenScale));
			short num10 = (short)System.Math.Round (0.75 * (double)(rcAnl.Right - rcAnl.Left) / 1440.0 / 0.016);
			x2 = (float)((double)analysis.Zmin - 0.075 * (double)num3 / 0.75);
			analysis.YRbase = 7f;
			GX.DrawString ("Reaction", font, black, x2, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			short nNode2 = analysis.Sol [iDir].nNode;
			for (num = 1; num <= nNode2; num = (short)unchecked(num + 1)) {
				if (analysis.Sol [iDir].D [num] == 0f) {
					num2 = analysis.Sol [iDir].V [num, 1];
					if (num > 1) {
						num2 += analysis.Sol [iDir].V [num - 1, 2];
					}
					if ((double)System.Math.Abs (num2) > 0.01 * (double)analysis.Rmax) {
						float num11 = analysis.Sol [iDir].Znode [num];
						float num12 = (float)((double)analysis.YRbase - 0.75 * (double)num2 / (double)analysis.Rmax);
						string s = Units.DisplayForce (num2, 0, blnShowUnit: false, "", 0, 0);
						GX.Graphics.DrawLine (pen, num11, analysis.YRbase, num11, num12);
						if (num2 > 0f) {
							GX.DrawString (s, font2, black, num11, num12, GraphicsX.AlignText.CenterTop, 0f);
							GX.Graphics.DrawLine (pen, num11, analysis.YRbase, num11 - num8, analysis.YRbase - num9);
							GX.Graphics.DrawLine (pen, num11, analysis.YRbase, num11 + num8, analysis.YRbase - num9);
						} else {
							GX.DrawString (s, font2, black, num11, num12, GraphicsX.AlignText.CenterBottom, 0f);
							GX.Graphics.DrawLine (pen, num11, analysis.YRbase, num11 - num8, analysis.YRbase + num9);
							GX.Graphics.DrawLine (pen, num11, analysis.YRbase, num11 + num8, analysis.YRbase + num9);
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
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			float x3 = analysis.Zmin;
			Solution solution = analysis.Sol [iDir];
			yDbase = (float)((double)Analysis1.YDbase + 0.75 / (double)Analysis1.Dmax * (double)solution.D [1]);
			float num13 = (float)(1E-06 * (double)(solution.Znode [solution.nNode] - solution.Znode [1]) / (double)solution.nSeg);
			num = 0;
			short num14 = 0;
			short nSeg = solution.nSeg;
			float num16 = default(float);
			float num19 = default(float);
			float num18 = default(float);
			float num17 = default(float);
			for (short num15 = 1; num15 <= nSeg; num15 = (short)unchecked(num15 + 1)) {
				if (solution.Seg [num15].Z == solution.Znode [num + 1]) {
					num = (short)(num + 1);
					num16 = solution.D [num];
					num2 = solution.R [num];
					num17 = solution.M [num];
					num18 = solution.V [num, 1];
					num19 = solution.EI [num];
				}
				float num20 = solution.Seg [num15 + 1].Z - solution.Seg [num15].Z;
				float num21 = num20 * num20;
				float num22 = num21 * num20;
				float num23 = num21 * num21;
				float num24 = num22 * num21;
				float w = solution.Seg [num15].W0;
				float num25 = (solution.Seg [num15].W1 - w) / num20;
				num18 += solution.Seg [num15].P0;
				num17 += solution.Seg [num15].M0;
				while (true) {
					float num11 = solution.Znode [1] + num3 * (float)num14 / (float)num10;
					float num26 = num11 - solution.Seg [num15].Z;
					if (num26 > num20 + num13) {
						break;
					}
					float num27 = num26 * num26;
					float num28 = num27 * num26;
					float num29 = num27 * num27;
					float num30 = num28 * num27;
					float num12 = (float)((double)Analysis1.YVbase + 0.75 / (double)Analysis1.Vmax * (double)(num18 + w * num26 + num25 * num27 / 2f));
					GX.Graphics.DrawLine (pen, x3, y2, num11, num12);
					y2 = num12;
					num12 = (float)((double)Analysis1.YMbase + 0.75 / (double)Analysis1.Mmax * (double)(num17 + num18 * num26 + w * num27 / 2f + num25 * num28 / 6f));
					GX.Graphics.DrawLine (pen, x3, y3, num11, num12);
					y3 = num12;
					num12 = (float)((double)Analysis1.YDbase + 0.75 / (double)Analysis1.Dmax * (double)(num16 + num2 * num26 + (num17 * num27 / 2f + num18 * num28 / 6f + w * num29 / 24f + num25 * num30 / 120f) / num19));
					GX.Graphics.DrawLine (pen, x3, yDbase, num11, num12);
					yDbase = num12;
					x3 = num11;
					num14 = (short)(num14 + 1);
				}
				num16 += num2 * num20 + (num17 * num21 / 2f + num18 * num22 / 6f + w * num23 / 24f + num25 * num24 / 120f) / num19;
				num2 += (num17 * num20 + num18 * num21 / 2f + w * num22 / 6f + num25 * num23 / 24f) / num19;
				num17 += num18 * num20 + w * num21 / 2f + num25 * num22 / 6f;
				num18 += w * num20 + num25 * num21 / 2f;
				w += num25 * num20;
			}
			solution = null;
			GX.Graphics.DrawLine (pen, x3, y2, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, x3, y3, analysis.Zmax, analysis.YMbase);
			GX.DrawString ("Shear", font, black, x2, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			nV2 = Det.NV;
		}
		for (int l = 1; l <= nV2; l = checked(l + 1)) {
			float num18 = Det.V [l];
			if ((double)System.Math.Abs (num18) > 0.01 * (double)analysis.Vmax) {
				string s = Units.DisplayForce (num18, 0, blnShowUnit: false, "", 0, 0);
				byte align = (byte)((!(num18 > 0f)) ? 3 : 5);
				GX.DrawString (s, font2, black, Det.ZV [l], (float)((double)analysis.YVbase + 0.75 * (double)num18 / (double)analysis.Vmax), (GraphicsX.AlignText)align, 0f);
			}
		}
		GX.DrawString ("Moment", font, black, x2, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
		GX.DrawString ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")");
		int nM2 = Det.NM;
		for (int m = 1; m <= nM2; m = checked(m + 1)) {
			float num17 = Det.M [m];
			if ((double)System.Math.Abs (num17) > 0.01 * (double)analysis.Mmax) {
				string s = Units.DisplayMoment (num17, 0, blnShowUnit: false, "", 0, 0);
				byte align = (byte)((!(num17 > 0f)) ? 3 : 5);
				GX.DrawString (s, font2, black, Det.ZM [m], (float)((double)analysis.YMbase + 0.75 * (double)num17 / (double)analysis.Mmax), (GraphicsX.AlignText)align, 0f);
			}
		}
		GX.DrawString ("Deflection", font, black, x2, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
		GX.DrawString ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")");
		int nD2 = Det.ND;
		for (int n = 1; n <= nD2; n = checked(n + 1)) {
			float num16 = Det.D [n];
			if ((double)System.Math.Abs (num16) > 0.01 * (double)analysis.Dmax) {
				string s = Units.DisplayLen1 (num16, 0, blnShowUnit: false, "", 0, 0);
				byte align = (byte)((!(num16 > 0f)) ? 3 : 5);
				GX.DrawString (s, font2, black, Det.ZD [n], (float)((double)analysis.YDbase + 0.75 * (double)num16 / (double)analysis.Dmax), (GraphicsX.AlignText)align, 0f);
			}
		}
		analysis = null;
	}

	public static void PrintDiagEnv (GraphicsX GX, Analysis Analysis1, short iDir, RECT rcAnl)
	{
		Brush black = Brushes.Black;
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		Analysis analysis = Analysis1;
		float num = analysis.Zmax - analysis.Zmin;
		checked {
			float num2 = (float)((double)num / 0.75 / (double)(rcAnl.Right - rcAnl.Left));
			float num3 = (float)(8.0 / (double)(rcAnl.Bottom - rcAnl.Top));
			float num4 = (float)((double)analysis.Zmin - 0.15 * (double)num / 0.75 - (double)((float)(rcAnl.Left - fr.rcPage.Left) * num2));
			float num5 = 8f + (float)(rcAnl.Top - fr.rcPage.Top) * num3;
			float x = num4 + (float)(fr.rcPage.Right - fr.rcPage.Left) * num2;
			float y = num5 - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num3;
			GX.Scale (num4, num5, x, y);
			float num6 = num / 96f;
			float num7 = num6 * System.Math.Abs (GX.Width / GX.ScaleWidth) / System.Math.Abs (GX.Height / GX.ScaleHeight);
			float num8 = (float)(0.75 * (double)(rcAnl.Right - rcAnl.Left) / 1440.0 / (double)Information.UBound (analysis.Zdiag));
			Pen pen = new Pen (Color.Black, (float)(0.016 * (double)GX.PenScale));
			Pen pen2 = new Pen (Color.Gray, num8 * GX.PenScale);
			float x2 = (float)((double)analysis.Zmin - 0.075 * (double)num / 0.75);
			analysis.YRbase = 7f;
			GX.DrawString ("Reaction", font, black, x2, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			analysis.YVbase = 5f;
			GX.DrawString ("Shear", font, black, x2, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")");
			analysis.YMbase = 3f;
			GX.DrawString ("Moment", font, black, x2, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")");
			analysis.YDbase = 1f;
			GX.DrawString ("Deflection", font, black, x2, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")");
			short num9 = (short)Information.UBound (analysis.Zdiag);
			short num10 = num9;
			for (short num11 = 0; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
				float num12 = analysis.Zdiag [num11];
				float y2 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YVbase, num12, y2);
				y2 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YVbase, num12, y2);
				y2 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YMbase, num12, y2);
				y2 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YMbase, num12, y2);
				y2 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YDbase, num12, y2);
				y2 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YDbase, num12, y2);
			}
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			short num13 = num9;
			for (short num11 = 0; num11 <= num13; num11 = (short)unchecked(num11 + 1)) {
				float num12 = analysis.Zdiag [num11];
				if ((double)analysis.Rdiag [num11] > 0.01 * (double)analysis.Rmax) {
					float y2 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag [num11] / (double)analysis.Rmax);
					string s = Units.DisplayForce (analysis.Rdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, y2, GraphicsX.AlignText.CenterTop, 0f);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12, y2);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 - num6, analysis.YRbase - num7);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 + num6, analysis.YRbase - num7);
				}
				if ((double)analysis.Rdiag2 [num11] < -0.01 * (double)analysis.Rmax) {
					float y2 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag2 [num11] / (double)analysis.Rmax);
					string s = Units.DisplayForce (analysis.Rdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, y2, GraphicsX.AlignText.CenterBottom, 0f);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12, y2);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 - num6, analysis.YRbase + num7);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 + num6, analysis.YRbase + num7);
				}
				if ((num11 == 0 || analysis.Vdiag [num11] > analysis.Vdiag [num11 - 1]) & (num11 == num9 || analysis.Vdiag [num11] > analysis.Vdiag [num11 + 1]) & ((double)analysis.Vdiag [num11] > 0.01 * (double)analysis.Vmax)) {
					string s = Units.DisplayForce (analysis.Vdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag [num11] / (double)analysis.Vmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Vdiag2 [num11] < analysis.Vdiag2 [num11 - 1]) & (num11 == num9 || analysis.Vdiag2 [num11] < analysis.Vdiag2 [num11 + 1]) & ((double)analysis.Vdiag2 [num11] < -0.01 * (double)analysis.Vmax)) {
					string s = Units.DisplayForce (analysis.Vdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag2 [num11] / (double)analysis.Vmax), GraphicsX.AlignText.CenterTop, 0f);
				}
				if ((num11 == 0 || analysis.Mdiag [num11] > analysis.Mdiag [num11 - 1]) & (num11 == num9 || analysis.Mdiag [num11] > analysis.Mdiag [num11 + 1]) & ((double)analysis.Mdiag [num11] > 0.01 * (double)analysis.Mmax)) {
					string s = Units.DisplayMoment (analysis.Mdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag [num11] / (double)analysis.Mmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Mdiag2 [num11] < analysis.Mdiag2 [num11 - 1]) & (num11 == num9 || analysis.Mdiag2 [num11] < analysis.Mdiag2 [num11 + 1]) & ((double)analysis.Mdiag2 [num11] < -0.01 * (double)analysis.Mmax)) {
					string s = Units.DisplayMoment (analysis.Mdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag2 [num11] / (double)analysis.Mmax), GraphicsX.AlignText.CenterTop, 0f);
				}
				if ((num11 == 0 || analysis.Ddiag [num11] > analysis.Ddiag [num11 - 1]) & (num11 == num9 || analysis.Ddiag [num11] > analysis.Ddiag [num11 + 1]) & ((double)analysis.Ddiag [num11] > 0.01 * (double)analysis.Dmax)) {
					string s = Units.DisplayLen1 (analysis.Ddiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag [num11] / (double)analysis.Dmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Ddiag2 [num11] < analysis.Ddiag2 [num11 - 1]) & (num11 == num9 || analysis.Ddiag2 [num11] < analysis.Ddiag2 [num11 + 1]) & ((double)analysis.Ddiag2 [num11] < -0.01 * (double)analysis.Dmax)) {
					string s = Units.DisplayLen1 (analysis.Ddiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag2 [num11] / (double)analysis.Dmax), GraphicsX.AlignText.CenterTop, 0f);
				}
			}
			analysis = null;
		}
	}

	public static void PrintTorsionDiag (GraphicsX GX, Analysis Analysis1, RECT rcAnl)
	{
		SolutionDetail Det = default(SolutionDetail);
		Brush black = Brushes.Black;
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		Analysis analysis = Analysis1;
		analysis.TorsionMinMax (ref Det);
		analysis.Rmax = 0f;
		analysis.Vmax = 0f;
		analysis.Mmax = 0f;
		analysis.Dmax = 0f;
		int nR = Det.NR;
		checked {
			for (int i = 1; i <= nR; i++) {
				if (System.Math.Abs (Det.R [i]) > analysis.Rmax) {
					analysis.Rmax = System.Math.Abs (Det.R [i]);
				}
			}
			int nV = Det.NV;
			for (int j = 1; j <= nV; j++) {
				if (System.Math.Abs (Det.V [j]) > analysis.Vmax) {
					analysis.Vmax = System.Math.Abs (Det.V [j]);
				}
			}
			int nM = Det.NM;
			for (int k = 1; k <= nM; k++) {
				if (System.Math.Abs (Det.M [k]) > analysis.Mmax) {
					analysis.Mmax = System.Math.Abs (Det.M [k]);
				}
			}
			int nD = Det.ND;
			for (int l = 1; l <= nD; l++) {
				if (System.Math.Abs (Det.D [l]) > analysis.Dmax) {
					analysis.Dmax = System.Math.Abs (Det.D [l]);
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
			float num = analysis.Zmax - analysis.Zmin;
			float num2 = num / 0.75f / (float)(rcAnl.Right - rcAnl.Left);
			float num3 = 8f / (float)(rcAnl.Bottom - rcAnl.Top);
			float num4 = analysis.Zmin - 0.15f * num / 0.75f - (float)(rcAnl.Left - fr.rcPage.Left) * num2;
			float num5 = 8f + (float)(rcAnl.Top - fr.rcPage.Top) * num3;
			float x = num4 + (float)(fr.rcPage.Right - fr.rcPage.Left) * num2;
			float y = num5 - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num3;
			GX.Scale (num4, num5, x, y);
			float num6 = num / 96f;
			float num7 = num6 * System.Math.Abs (GX.Width / GX.ScaleWidth) / System.Math.Abs (GX.Height / GX.ScaleHeight);
			Pen pen = new Pen (Color.Black, (float)(0.016 * (double)GX.PenScale));
			short num8 = (short)System.Math.Round ((double)(0.75f * (float)(rcAnl.Right - rcAnl.Left) / 1440f) / 0.016);
			float x2 = (float)((double)analysis.Zmin - 0.075000002980232239 * (double)num / 0.75);
			analysis.YRbase = 7f;
			analysis.YVbase = 5f;
			float y2 = analysis.YVbase;
			analysis.YMbase = 3f;
			float y3 = analysis.YMbase;
			analysis.YDbase = 1f;
			float yDbase = analysis.YDbase;
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			GX.DrawString ("Reaction", font, black, x2, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			int nR2 = Det.NR;
			for (int m = 1; m <= nR2; m++) {
				float num9 = Det.ZR [m];
				float num10 = analysis.YRbase - 0.75f * Det.R [m] / analysis.Rmax;
				string s = Units.DisplayTorque (Det.R [m], 0, blnShowUnit: false, "", 0, 0);
				if ((double)System.Math.Abs (Det.R [m]) > 0.01 * (double)analysis.Rmax) {
					GX.Graphics.DrawLine (pen, num9, analysis.YRbase, num9, num10);
					if (Det.R [m] > 0f) {
						GX.DrawString (s, font2, black, num9, num10, GraphicsX.AlignText.CenterTop, 0f);
						GX.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 - num6, analysis.YRbase - num7);
						GX.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 + num6, analysis.YRbase - num7);
					} else {
						GX.DrawString (s, font2, black, num9, num10, GraphicsX.AlignText.CenterBottom, 0f);
						GX.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 - num6, analysis.YRbase + num7);
						GX.Graphics.DrawLine (pen, num9, analysis.YRbase, num9 + num6, analysis.YRbase + num7);
					}
				}
			}
			float x3 = analysis.Zmin;
			float num11 = (float)(1E-06 * (double)num / (double)analysis.nTseg);
			short num12 = 0;
			yDbase = Analysis1.YDbase + analysis.Tseg [1].Phi (0f) / analysis.Dmax * 0.75f;
			int nTseg = analysis.nTseg;
			for (int n = 1; n <= nTseg; n++) {
				while (true) {
					float num9 = analysis.Zmin + num * (float)num12 / (float)num8;
					if (num9 > analysis.Tseg [n].Z + analysis.Tseg [n].L + num11) {
						break;
					}
					float num10 = Analysis1.YVbase + analysis.Tseg [n].T (num9 - analysis.Tseg [n].Z) / analysis.Vmax * 0.75f;
					GX.Graphics.DrawLine (pen, x3, y2, num9, num10);
					y2 = num10;
					num10 = Analysis1.YMbase + analysis.Tseg [n].B (num9 - analysis.Tseg [n].Z) / analysis.Mmax * 0.75f;
					GX.Graphics.DrawLine (pen, x3, y3, num9, num10);
					y3 = num10;
					num10 = Analysis1.YDbase + analysis.Tseg [n].Phi (num9 - analysis.Tseg [n].Z) / analysis.Dmax * 0.75f;
					GX.Graphics.DrawLine (pen, x3, yDbase, num9, num10);
					yDbase = num10;
					x3 = num9;
					num12 = (short)(num12 + 1);
				}
			}
			GX.Graphics.DrawLine (pen, x3, y2, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, x3, y3, analysis.Zmax, analysis.YMbase);
			GX.DrawString ("Torque", font, black, x2, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			int nV2 = Det.NV;
			for (int num13 = 1; num13 <= nV2; num13++) {
				if ((double)System.Math.Abs (Det.V [num13]) > 0.01 * (double)analysis.Vmax) {
					string s = Units.DisplayTorque (Det.V [num13], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (align: (!(Det.V [num13] > 0f)) ? GraphicsX.AlignText.CenterTop : GraphicsX.AlignText.CenterBottom, s: s, font: font2, brush: black, x: Det.ZV [num13], y: analysis.YVbase + 0.75f * Det.V [num13] / analysis.Vmax, angle: 0f);
				}
			}
			GX.DrawString ("Bimoment", font, black, x2, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")");
			int nM2 = Det.NM;
			for (int num14 = 1; num14 <= nM2; num14++) {
				if ((double)System.Math.Abs (Det.M [num14]) > 0.01 * (double)analysis.Mmax) {
					string s = Units.DisplayBimoment (Det.M [num14], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (align: (!(Det.M [num14] > 0f)) ? GraphicsX.AlignText.CenterTop : GraphicsX.AlignText.CenterBottom, s: s, font: font2, brush: black, x: Det.ZM [num14], y: analysis.YMbase + 0.75f * Det.M [num14] / analysis.Mmax, angle: 0f);
				}
			}
			GX.DrawString ("Twist", font, black, x2, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")");
			int nD2 = Det.ND;
			for (int num15 = 1; num15 <= nD2; num15++) {
				if ((double)System.Math.Abs (Det.D [num15]) > 0.01 * (double)analysis.Dmax) {
					string s = Units.DisplayAngle (Det.D [num15], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (align: (!(Det.D [num15] > 0f)) ? GraphicsX.AlignText.CenterTop : GraphicsX.AlignText.CenterBottom, s: s, font: font2, brush: black, x: Det.ZD [num15], y: analysis.YDbase + 0.75f * Det.D [num15] / analysis.Dmax, angle: 0f);
				}
			}
			analysis = null;
		}
	}

	public static void PrintTorsionEnv (GraphicsX GX, Analysis Analysis1, RECT rcAnl)
	{
		Brush black = Brushes.Black;
		Font font = new Font ("Arial", 10f);
		Font font2 = new Font ("Arial", 6f);
		Analysis analysis = Analysis1;
		float num = analysis.Zmax - analysis.Zmin;
		checked {
			float num2 = (float)((double)num / 0.75 / (double)(rcAnl.Right - rcAnl.Left));
			float num3 = (float)(8.0 / (double)(rcAnl.Bottom - rcAnl.Top));
			float num4 = (float)((double)analysis.Zmin - 0.15 * (double)num / 0.75 - (double)((float)(rcAnl.Left - fr.rcPage.Left) * num2));
			float num5 = 8f + (float)(rcAnl.Top - fr.rcPage.Top) * num3;
			float x = num4 + (float)(fr.rcPage.Right - fr.rcPage.Left) * num2;
			float y = num5 - (float)(fr.rcPage.Bottom - fr.rcPage.Top) * num3;
			GX.Scale (num4, num5, x, y);
			float num6 = num / 96f;
			float num7 = num6 * System.Math.Abs (GX.Width / GX.ScaleWidth) / System.Math.Abs (GX.Height / GX.ScaleHeight);
			float num8 = (float)(0.75 * (double)(rcAnl.Right - rcAnl.Left) / 1440.0 / (double)Information.UBound (analysis.Zdiag));
			Pen pen = new Pen (Color.Black, (float)(0.016 * (double)GX.PenScale));
			Pen pen2 = new Pen (Color.Gray, num8 * GX.PenScale);
			float x2 = (float)((double)analysis.Zmin - 0.075 * (double)num / 0.75);
			analysis.YRbase = 7f;
			GX.DrawString ("Reaction", font, black, x2, analysis.YRbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			analysis.YVbase = 5f;
			GX.DrawString ("Torque", font, black, x2, analysis.YVbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")");
			analysis.YMbase = 3f;
			GX.DrawString ("Bimoment", font, black, x2, analysis.YMbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")");
			analysis.YDbase = 1f;
			GX.DrawString ("Twist", font, black, x2, analysis.YDbase, GraphicsX.AlignText.CenterBottom, 0f);
			GX.DrawString ("(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")");
			short num9 = (short)Information.UBound (analysis.Zdiag);
			short num10 = num9;
			for (short num11 = 0; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
				float num12 = analysis.Zdiag [num11];
				float y2 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YVbase, num12, y2);
				y2 = (float)((double)analysis.YVbase + 0.75 / (double)analysis.Vmax * (double)analysis.Vdiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YVbase, num12, y2);
				y2 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YMbase, num12, y2);
				y2 = (float)((double)analysis.YMbase + 0.75 / (double)analysis.Mmax * (double)analysis.Mdiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YMbase, num12, y2);
				y2 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YDbase, num12, y2);
				y2 = (float)((double)analysis.YDbase + 0.75 / (double)analysis.Dmax * (double)analysis.Ddiag2 [num11]);
				GX.Graphics.DrawLine (pen2, num12, analysis.YDbase, num12, y2);
			}
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YRbase, analysis.Zmax, analysis.YRbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YVbase, analysis.Zmax, analysis.YVbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YMbase, analysis.Zmax, analysis.YMbase);
			GX.Graphics.DrawLine (pen, analysis.Zmin, analysis.YDbase, analysis.Zmax, analysis.YDbase);
			short num13 = num9;
			for (short num11 = 0; num11 <= num13; num11 = (short)unchecked(num11 + 1)) {
				float num12 = analysis.Zdiag [num11];
				if ((double)analysis.Rdiag [num11] > 0.01 * (double)analysis.Rmax) {
					float y2 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag [num11] / (double)analysis.Rmax);
					string s = Units.DisplayTorque (analysis.Rdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, y2, GraphicsX.AlignText.CenterTop, 0f);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12, y2);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 - num6, analysis.YRbase - num7);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 + num6, analysis.YRbase - num7);
				}
				if ((double)analysis.Rdiag2 [num11] < -0.01 * (double)analysis.Rmax) {
					float y2 = (float)((double)analysis.YRbase - 0.75 * (double)analysis.Rdiag2 [num11] / (double)analysis.Rmax);
					string s = Units.DisplayTorque (analysis.Rdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, y2, GraphicsX.AlignText.CenterBottom, 0f);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12, y2);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 - num6, analysis.YRbase + num7);
					GX.Graphics.DrawLine (pen, num12, analysis.YRbase, num12 + num6, analysis.YRbase + num7);
				}
				if ((num11 == 0 || analysis.Vdiag [num11] > analysis.Vdiag [num11 - 1]) & (num11 == num9 || analysis.Vdiag [num11] > analysis.Vdiag [num11 + 1]) & ((double)analysis.Vdiag [num11] > 0.01 * (double)analysis.Vmax)) {
					string s = Units.DisplayTorque (analysis.Vdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag [num11] / (double)analysis.Vmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Vdiag2 [num11] < analysis.Vdiag2 [num11 - 1]) & (num11 == num9 || analysis.Vdiag2 [num11] < analysis.Vdiag2 [num11 + 1]) & ((double)analysis.Vdiag2 [num11] < -0.01 * (double)analysis.Vmax)) {
					string s = Units.DisplayTorque (analysis.Vdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YVbase + 0.75 * (double)analysis.Vdiag2 [num11] / (double)analysis.Vmax), GraphicsX.AlignText.CenterTop, 0f);
				}
				if ((num11 == 0 || analysis.Mdiag [num11] > analysis.Mdiag [num11 - 1]) & (num11 == num9 || analysis.Mdiag [num11] > analysis.Mdiag [num11 + 1]) & ((double)analysis.Mdiag [num11] > 0.01 * (double)analysis.Mmax)) {
					string s = Units.DisplayBimoment (analysis.Mdiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag [num11] / (double)analysis.Mmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Mdiag2 [num11] < analysis.Mdiag2 [num11 - 1]) & (num11 == num9 || analysis.Mdiag2 [num11] < analysis.Mdiag2 [num11 + 1]) & ((double)analysis.Mdiag2 [num11] < -0.01 * (double)analysis.Mmax)) {
					string s = Units.DisplayBimoment (analysis.Mdiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YMbase + 0.75 * (double)analysis.Mdiag2 [num11] / (double)analysis.Mmax), GraphicsX.AlignText.CenterTop, 0f);
				}
				if ((num11 == 0 || analysis.Ddiag [num11] > analysis.Ddiag [num11 - 1]) & (num11 == num9 || analysis.Ddiag [num11] > analysis.Ddiag [num11 + 1]) & ((double)analysis.Ddiag [num11] > 0.01 * (double)analysis.Dmax)) {
					string s = Units.DisplayAngle (analysis.Ddiag [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag [num11] / (double)analysis.Dmax), GraphicsX.AlignText.CenterBottom, 0f);
				}
				if ((num11 == 0 || analysis.Ddiag2 [num11] < analysis.Ddiag2 [num11 - 1]) & (num11 == num9 || analysis.Ddiag2 [num11] < analysis.Ddiag2 [num11 + 1]) & ((double)analysis.Ddiag2 [num11] < -0.01 * (double)analysis.Dmax)) {
					string s = Units.DisplayAngle (analysis.Ddiag2 [num11], 0, blnShowUnit: false, "", 0, 0);
					GX.DrawString (s, font2, black, num12, (float)((double)analysis.YDbase + 0.75 * (double)analysis.Ddiag2 [num11] / (double)analysis.Dmax), GraphicsX.AlignText.CenterTop, 0f);
				}
			}
			analysis = null;
		}
	}

	private static void InitializePage (PrintPageEventArgs e, float LeftMargin, float TopMargin, float RightMargin, float BottomMargin)
	{
		checked {
			fr.rcPage.Left = (int)System.Math.Round ((float)e.MarginBounds.Left * 14.4f);
			fr.rcPage.Top = (int)System.Math.Round ((float)e.MarginBounds.Top * 14.4f);
			fr.rcPage.Right = (int)System.Math.Round ((float)e.MarginBounds.Right * 14.4f);
			fr.rcPage.Bottom = (int)System.Math.Round ((float)e.MarginBounds.Bottom * 14.4f);
			rcDrawTo.Left = (int)System.Math.Round (LeftMargin * 1440f);
			rcDrawTo.Top = (int)System.Math.Round (TopMargin * 1440f);
			rcDrawTo.Right = (int)System.Math.Round (((double)e.PageSettings.Bounds.Right / 100.0 - (double)RightMargin) * 1440.0);
			rcDrawTo.Bottom = (int)System.Math.Round (((double)e.PageSettings.Bounds.Bottom / 100.0 - (double)BottomMargin) * 1440.0);
			fr.rc = rcDrawTo;
			PrinterOffsetX = e.PageSettings.HardMarginX * 14.4f;
			PrinterOffsetY = e.PageSettings.HardMarginY * 14.4f;
		}
	}

	private static void PrintHeader (PrintPageEventArgs e)
	{
		checked {
			intPage++;
			if (Strings.Len (rtfHeader.Text) != 0) {
				int num = Strings.InStr (rtfHeader.Text, "¤");
				if (num > 0) {
					rtfHeader.SelectionStart = num - 1;
					rtfHeader.SelectionLength = 1;
					rtfHeader.SelectedText = Conversions.ToString (unchecked((int)intPage));
				}
				fr.chrg.cpMin = 0;
				fr.chrg.cpMax = Strings.Len (rtfHeader.Text);
				PrintRTF (rtfHeader, e, RTFMethod.Print);
				if (num > 0) {
					rtfHeader.SelectionStart = num - 1;
					rtfHeader.SelectionLength = Strings.Len (Conversions.ToString (unchecked((int)intPage)));
					rtfHeader.SelectedText = "¤";
				}
				fr.rc.Top = fr.rc.Bottom;
				fr.rc.Right = rcDrawTo.Right;
				fr.rc.Bottom = rcDrawTo.Bottom;
			}
		}
	}

	private static void PrintFooter (PrintPageEventArgs e)
	{
		if (Strings.Len (rtfFooter.Text) != 0) {
			fr.rc.Left = rcDrawTo.Left;
			fr.rc.Top = rcDrawTo.Bottom;
			fr.rc.Right = rcDrawTo.Right;
			fr.rc.Bottom = fr.rcPage.Bottom;
			fr.chrg.cpMin = 0;
			fr.chrg.cpMax = Strings.Len (rtfFooter.Text);
			PrintRTF (rtfFooter, e, RTFMethod.Print);
		}
	}

	private static int PrintRTF (RichTextBox RTF, PrintPageEventArgs e, RTFMethod Method)
	{
		fr.hdc = e.Graphics.GetHdc ();
		fr.hdcTarget = fr.hdc;
		ref int left = ref fr.rc.Left;
		checked {
			left = (int)System.Math.Round ((float)left - PrinterOffsetX);
			ref int top = ref fr.rc.Top;
			top = (int)System.Math.Round ((float)top - PrinterOffsetY);
			ref int right = ref fr.rc.Right;
			right = (int)System.Math.Round ((float)right - PrinterOffsetX);
			ref int bottom = ref fr.rc.Bottom;
			bottom = (int)System.Math.Round ((float)bottom - PrinterOffsetY);
			int result = 0;
			switch (Method) {
			case RTFMethod.Check: {
				IntPtr intPtr = Marshal.AllocCoTaskMem (Marshal.SizeOf (fr));
				Marshal.StructureToPtr (fr, intPtr, fDeleteOld: false);
				result = (int)SendMessage (RTF.Handle, 1081, (IntPtr)0L, intPtr);
				object obj2 = Marshal.PtrToStructure (intPtr, typeof(FORMATRANGE));
				fr = ((obj2 != null) ? ((FORMATRANGE)obj2) : default(FORMATRANGE));
				Marshal.FreeCoTaskMem (intPtr);
				break;
			}
			case RTFMethod.Commit: {
				IntPtr intPtr = Marshal.AllocCoTaskMem (Marshal.SizeOf (fr.rc));
				Marshal.StructureToPtr (fr.rc, intPtr, fDeleteOld: false);
				result = (int)SendMessage (RTF.Handle, 1075, (IntPtr)0, intPtr);
				Marshal.FreeCoTaskMem (intPtr);
				break;
			}
			case RTFMethod.Print: {
				IntPtr intPtr = Marshal.AllocCoTaskMem (Marshal.SizeOf (fr));
				Marshal.StructureToPtr (fr, intPtr, fDeleteOld: false);
				result = (int)SendMessage (RTF.Handle, 1081, (IntPtr)(-1L), intPtr);
				object obj = Marshal.PtrToStructure (intPtr, typeof(FORMATRANGE));
				fr = ((obj != null) ? ((FORMATRANGE)obj) : default(FORMATRANGE));
				Marshal.FreeCoTaskMem (intPtr);
				break;
			}
			}
			ref int left2 = ref fr.rc.Left;
			left2 = (int)System.Math.Round ((float)left2 + PrinterOffsetX);
			ref int top2 = ref fr.rc.Top;
			top2 = (int)System.Math.Round ((float)top2 + PrinterOffsetY);
			ref int right2 = ref fr.rc.Right;
			right2 = (int)System.Math.Round ((float)right2 + PrinterOffsetX);
			ref int bottom2 = ref fr.rc.Bottom;
			bottom2 = (int)System.Math.Round ((float)bottom2 + PrinterOffsetY);
			e.Graphics.ReleaseHdc ();
			return result;
		}
	}
}
