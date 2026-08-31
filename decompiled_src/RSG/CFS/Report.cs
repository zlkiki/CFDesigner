// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

[StandardModule]
internal sealed class Report
{
	public static readonly string strPage = Conversions.ToString (Strings.Chr (160)) + "\n";

	private static readonly string strLine = new string (Strings.Chr (175), 72) + "\r\n";

	private static readonly Font TitleFont = new Font ("Arial", 12f);

	private static readonly Font HeaderFont = new Font ("Arial", 10f);

	private static readonly Font TextFont = new Font ("Calibri", 10f);

	private static readonly Font BodyFont = new Font ("Consolas", 10f);

	private static readonly Font LineFont = new Font ("Courier New", 10f, FontStyle.Bold);

	public static void AppendRTF (RichTextBox rtfBase, RichTextBox rtfAdd)
	{
		int selectionStart = rtfAdd.SelectionStart;
		int selectionLength = rtfAdd.SelectionLength;
		int num = 0;
		checked {
			while (true) {
				num = Strings.InStr (num + 1, rtfAdd.Text, Conversions.ToString (Strings.Chr (160)));
				if (num == 0) {
					break;
				}
				rtfAdd.SelectionStart = num - 1;
				rtfAdd.SelectionLength = 1;
				rtfAdd.SelectedText = Conversions.ToString (Strings.Chr (183));
			}
			rtfAdd.SelectionStart = selectionStart;
			rtfAdd.SelectionLength = selectionLength;
			int num2 = Strings.Len (rtfBase.Text);
			int selectionStart2 = (rtfBase.SelectionStart = Strings.Len (rtfBase.Text));
			rtfBase.SelectedRtf = rtfAdd.Rtf;
			int num4 = Strings.Len (rtfBase.Text);
			if (num4 > num2 + Strings.Len (rtfAdd.Text) && Strings.Asc (Strings.Mid (rtfBase.Text, num4, 1)) == 10) {
				rtfBase.SelectionStart = num4 - 1;
				rtfBase.SelectionLength = 1;
				rtfBase.ReadOnly = false;
				rtfBase.SelectedText = string.Empty;
				rtfBase.ReadOnly = true;
			}
			num = 0;
			while (true) {
				num = Strings.InStr (num + 1, rtfAdd.Text, Conversions.ToString (Strings.Chr (183)));
				if (num == 0) {
					break;
				}
				rtfAdd.SelectionStart = num - 1;
				rtfAdd.SelectionLength = 1;
				rtfAdd.SelectedText = Conversions.ToString (Strings.Chr (160));
			}
			rtfAdd.SelectionStart = selectionStart;
			rtfAdd.SelectionLength = selectionLength;
			num = 0;
			while (true) {
				num = Strings.InStr (num + 1, rtfBase.Text, Conversions.ToString (Strings.Chr (183)));
				if (num == 0) {
					break;
				}
				rtfBase.SelectionStart = num - 1;
				rtfBase.SelectionLength = 1;
				rtfBase.SelectedText = Conversions.ToString (Strings.Chr (160));
			}
			rtfBase.SelectionStart = selectionStart2;
		}
	}

	private static void rptSymbol (RichTextBox rtf, string strText)
	{
		Font selectionFont = rtf.SelectionFont;
		rtf.SelectionFont = new Font ("Symbol", selectionFont.Size);
		rtf.SelectedText = strText;
		rtf.SelectionFont = selectionFont;
		_ = null;
	}

	private static void rptTrace (RichTextBox rtf, string strText)
	{
		float dpiX = rtf.CreateGraphics ().DpiX;
		rtf.SelectionFont = TextFont;
		checked {
			rtf.SelectionTabs = new int[1] { (int)System.Math.Round (4.5 * (double)dpiX) };
			int num = 1;
			while (num <= Strings.Len (strText)) {
				int num2 = Strings.InStr (num, strText, "\u0001");
				if (num2 >= num) {
					rtf.SelectedText = Strings.Mid (strText, num, num2 - num);
					rptSymbol (rtf, Strings.Mid (strText, num2 + 1, 1));
					num = num2 + 2;
					continue;
				}
				rtf.SelectedText = Strings.Mid (strText, num);
				break;
			}
			rtf.SelectionTabs = new int[0];
		}
	}

	public static void rptHeading (RichTextBox rtf, Heading hdgHeading, bool blnPage = false)
	{
		float dpiX = rtf.CreateGraphics ().DpiX;
		rtf.Rtf = string.Empty;
		rtf.SelectionTabs = checked(new int[2] {
			(int)System.Math.Round (3.25 * (double)dpiX),
			(int)System.Math.Round (5.25 * (double)dpiX)
		});
		rtf.SelectionStart = Strings.Len (rtf.Text);
		rtf.SelectionFont = TitleFont;
		rtf.SelectedText = "CFS Version " + CFS.AppVer (hdgHeading.AppVer);
		if (blnPage) {
			rtf.SelectionFont = HeaderFont;
			rtf.SelectedText = "\t\tPage ¤";
		}
		rtf.SelectedText = "\r\n";
		rtf.SelectionFont = HeaderFont;
		switch (hdgHeading.Parent) {
		case 1:
			rtf.SelectedText = "Section: ";
			break;
		case 2:
			rtf.SelectedText = "Analysis: ";
			break;
		case 3:
			rtf.SelectedText = "Report: ";
			break;
		}
		rtf.SelectedText = CFSInterface.GetFileName (hdgHeading.Filename) + "\t" + CFS.User.Name + "\r\n";
		rtf.SelectionFont = HeaderFont;
		rtf.SelectedText = hdgHeading.Description + "\t" + CFS.User.Company + "\r\n";
		rtf.SelectionFont = HeaderFont;
		rtf.SelectedText = hdgHeading.Project + "\t" + CFS.User.Address1 + "\r\n";
		rtf.SelectionFont = HeaderFont;
		rtf.SelectedText = "Rev. Date: " + Strings.Format (hdgHeading.RevDate, "General Date") + "\t" + CFS.User.Address2 + "\r\n";
		rtf.SelectionFont = HeaderFont;
		if (Strings.Len (hdgHeading.RevBy) > 0) {
			rtf.SelectedText = "By: " + hdgHeading.RevBy + "\t";
		} else {
			rtf.SelectedText = "\t";
		}
		if (Strings.Len (CFS.User.Phone) > 0) {
			rtf.SelectedText = "Ph: " + CFS.User.Phone;
		}
		if ((Strings.Len (CFS.User.Phone) > 0) & (Strings.Len (CFS.User.Fax) > 0)) {
			rtf.SelectedText = ", ";
		}
		if (Strings.Len (CFS.User.Fax) > 0) {
			rtf.SelectedText = "Fax: " + CFS.User.Fax;
		}
		rtf.SelectedText = "\r\n";
		rtf.SelectionFont = HeaderFont;
		rtf.SelectedText = "Printed: " + Strings.Format (DateAndTime.Now, "General Date") + "\t" + CFS.User.Email + "\r\n" + strPage;
	}

	public static void rptTitle (RichTextBox rtf, string strTitle)
	{
		rtf.SelectionFont = TitleFont;
		rtf.SelectedText = strTitle + "\r\n";
		rtf.SelectionFont = LineFont;
		rtf.SelectedText = strLine;
		rtf.SelectionFont = BodyFont;
	}

	public static void rptAnlInp (RichTextBox rtf, Analysis Analysis1)
	{
		Analysis analysis = Analysis1;
		string text = "(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		string text2 = "(" + Units.untLen2 [Units.DefaultUnitIndex [7]].Name + ")";
		string text3 = "(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		string text4 = "(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")";
		string text5 = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
		string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (analysis.Zmin), System.Math.Abs (analysis.Zmax)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
		rtf.Font = BodyFont;
		rtf.SelectionStart = Strings.Len (rtf.Text);
		rptTitle (rtf, "Analysis Inputs");
		rtf.SelectedText = "General\r\n";
		rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Member Orientation: ", Interaction.IIf (analysis.Vertical, "Vertical", "Horizontal")), "\r\n"));
		rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Calculate global buckling using ", Interaction.IIf (analysis.BucklingTheory, "elastic theory", "specification equations")), "\r\n"));
		rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Interaction.IIf (analysis.Torsion, "  Include", "  Do not include"), " torsion in member checks"), "\r\n"), "\r\n"));
		checked {
			string strFmt5;
			float num6;
			string strFmt7;
			if (analysis.nBeam > 0) {
				rtf.SelectedText = "Members\r\n";
				rtf.SelectedText = "    Section File                                  Revision Date and Time\r\n";
				short nBeam = analysis.nBeam;
				for (short num = 1; num <= nBeam; num = (short)unchecked(num + 1)) {
					rtf.SelectedText = Conversions.ToString (unchecked((int)num)).PadLeft (3) + Strings.Space (1) + CFSInterface.GetFileName (CFS.Sections [analysis.Beam [num].iSct].Filename).PadRight (46) + Conversions.ToString (CFS.Sections [analysis.Beam [num].iSct].RevDate) + "\r\n";
				}
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				short nBeam2 = analysis.nBeam;
				for (short num = 1; num <= nBeam2; num = (short)unchecked(num + 1)) {
					float num5 = 0f;
					int nPart = CFS.Sections [analysis.Beam [num].iSct].nPart;
					for (int i = 1; i <= nPart; i++) {
						num5 += CFS.Sections [analysis.Beam [num].iSct].Part [i].A;
					}
					if (num5 > num2) {
						num2 = num5;
					}
					num3 += analysis.Beam [num].Z1 - analysis.Beam [num].Z0;
					num4 = (float)((double)num4 + (double)(num5 * (analysis.Beam [num].Z1 - analysis.Beam [num].Z0)) * 3.4 / 12000.0);
				}
				string strFmt2 = Units.Fmt [Units.FmtIndex (num2 * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)];
				string strFmt3 = Units.Fmt [Units.FmtIndex (num3 * Units.untLength [Units.DefaultUnitIndex [2]].Mult)];
				string strFmt4 = Units.Fmt [Units.FmtIndex (num4 * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
				rtf.SelectedText = strPage;
				rtf.SelectedText = "    Material                       Area     Length     Weight\r\n";
				rtf.SelectedText = Strings.Space (28) + text2.PadLeft (11) + text3.PadLeft (11) + text5.PadLeft (11) + "\r\n";
				short nBeam3 = analysis.nBeam;
				for (short num = 1; num <= nBeam3; num = (short)unchecked(num + 1)) {
					float num5 = 0f;
					int nPart2 = CFS.Sections [analysis.Beam [num].iSct].nPart;
					for (int j = 1; j <= nPart2; j++) {
						num5 += CFS.Sections [analysis.Beam [num].iSct].Part [j].A;
					}
					rtf.SelectedText = Conversions.ToString (unchecked((int)num)).PadLeft (3) + Strings.Space (1) + CFS.Sections [analysis.Beam [num].iSct].Material.Name.PadRight (24) + Units.DisplayLen2 (num5, 0, blnShowUnit: false, strFmt2, 11, 0) + Units.DisplayLength (analysis.Beam [num].Z1 - analysis.Beam [num].Z0, 0, blnShowUnit: false, strFmt3, 11, 0) + Units.DisplayForce ((float)((double)(num5 * (analysis.Beam [num].Z1 - analysis.Beam [num].Z0)) * 3.4 / 12000.0), 0, blnShowUnit: false, strFmt4, 11, 0) + "\r\n";
				}
				rtf.SelectedText = Strings.Space (4) + "Total" + Strings.Space (30) + Units.DisplayLength (num3, 0, blnShowUnit: false, strFmt3, 11, 0) + Units.DisplayForce (num4, 0, blnShowUnit: false, strFmt4, 11, 0) + "\r\n";
				rtf.SelectedText = strPage;
				rtf.SelectedText = "    Start Loc.   End Loc. Braced    R         kφ         Lm         ex         ey\r\n";
				rtf.SelectedText = Strings.Space (3) + text3.PadLeft (11) + text3.PadLeft (11) + " Flange" + Strings.Space (7) + text5.PadLeft (11) + text3.PadLeft (11) + text.PadLeft (11) + text.PadLeft (11) + "\r\n";
				strFmt5 = Units.Fmt [Units.FmtIndex (10f * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
				string strFmt6 = Units.Fmt [Units.FmtIndex (1f)];
				num6 = 0f;
				short nBeam4 = analysis.nBeam;
				for (short num = 1; num <= nBeam4; num = (short)unchecked(num + 1)) {
					if (analysis.Beam [num].Kf > num6) {
						num6 = analysis.Beam [num].Kf;
					}
				}
				strFmt7 = Units.Fmt [Units.FmtIndex (num6 * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
				short nBeam5 = analysis.nBeam;
				for (short num = 1; num <= nBeam5; num = (short)unchecked(num + 1)) {
					rtf.SelectedText = unchecked(Conversions.ToString ((int)num).PadLeft (3) + Units.DisplayLength (analysis.Beam [num].Z0, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLength (analysis.Beam [num].Z1, 0, blnShowUnit: false, strFmt, 11, 0) + Strings.Space (1) + CFSInterface.DisplayFlange ((Flanges)analysis.Beam [num].iBrcFlg).PadRight (6)) + Units.DisplayNone (analysis.Beam [num].R, strFmt6, 7, 0) + Units.DisplayForce (analysis.Beam [num].Kf, 0, blnShowUnit: false, strFmt7, 11, 0) + Units.DisplayLength (analysis.Beam [num].Lm, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLen1 (analysis.Beam [num].ex, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayLen1 (analysis.Beam [num].ey, 0, blnShowUnit: false, strFmt5, 11, 0) + "\r\n";
				}
			}
			strFmt5 = Units.Fmt [Units.FmtIndex (100f * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
			string strFmt8 = Units.Fmt [Units.FmtIndex (2f)];
			if (analysis.nSup > 0) {
				rtf.SelectedText = strPage;
				rtf.SelectedText = "Supports\r\n";
				rtf.SelectedText = "    Type      Location    Bearing   Fastened        K\r\n";
				rtf.SelectedText = Strings.Space (11) + text3.PadLeft (11) + text.PadLeft (11) + "\r\n";
				short nSup = analysis.nSup;
				for (short num7 = 1; num7 <= nSup; num7 = (short)unchecked(num7 + 1)) {
					rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (unchecked(Conversions.ToString ((int)num7).PadLeft (3) + Strings.Space (1) + CFSInterface.DisplaySup ((Supports)analysis.Sup [num7].Type).PadRight (7)) + Units.DisplayLength (analysis.Sup [num7].Z, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLen1 (analysis.Sup [num7].Wid, 0, blnShowUnit: false, strFmt5, 11, 0), NewLateBinding.LateGet (Interaction.IIf (analysis.Sup [num7].Fastened, "Yes", "No"), null, "PadLeft", new object[1] { (short)11 }, null, null, null)), Units.DisplayNone (analysis.Sup [num7].K, strFmt8, 11, 0)), "\r\n"));
				}
			}
			float num8 = 0f;
			num6 = 0f;
			float num9 = 0f;
			short nLdg = analysis.nLdg;
			for (short num10 = 1; num10 <= nLdg; num10 = (short)unchecked(num10 + 1)) {
				if (analysis.Ldg [num10].nLoad > 0) {
					ref Loading reference = ref analysis.Ldg [num10];
					short nLoad = reference.nLoad;
					for (short num11 = 1; num11 <= nLoad; num11 = (short)unchecked(num11 + 1)) {
						switch (reference.Load [num11].Type) {
						case 1:
							if (System.Math.Abs (reference.Load [num11].W0) > num8) {
								num8 = System.Math.Abs (reference.Load [num11].W0);
							}
							if (System.Math.Abs (reference.Load [num11].W1) > num8) {
								num8 = System.Math.Abs (reference.Load [num11].W1);
							}
							break;
						case 2:
							if (System.Math.Abs (reference.Load [num11].W0) > num6) {
								num6 = System.Math.Abs (reference.Load [num11].W0);
							}
							break;
						case 3:
							if (System.Math.Abs (reference.Load [num11].W0) > num6) {
								num6 = System.Math.Abs (reference.Load [num11].W0);
							}
							if (System.Math.Abs (reference.Load [num11].W1) > num6) {
								num6 = System.Math.Abs (reference.Load [num11].W1);
							}
							break;
						case 4:
							if (System.Math.Abs (reference.Load [num11].W0) > num9) {
								num9 = System.Math.Abs (reference.Load [num11].W0);
							}
							break;
						}
					}
				}
			}
			string strFmt9 = Units.Fmt [Units.FmtIndex ((float)(System.Math.PI / 2.0 * (double)Units.untAngle [Units.DefaultUnitIndex [3]].Mult))];
			string strFmt10 = Units.Fmt [Units.FmtIndex (num8 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult)];
			strFmt7 = Units.Fmt [Units.FmtIndex (num6 * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
			string strFmt11 = Units.Fmt [Units.FmtIndex (num9 * Units.untMoment [Units.DefaultUnitIndex [6]].Mult)];
			short nLdg2 = analysis.nLdg;
			for (short num10 = 1; num10 <= nLdg2; num10 = (short)unchecked(num10 + 1)) {
				if (analysis.Ldg [num10].nLoad > 0) {
					ref Loading reference2 = ref analysis.Ldg [num10];
					rtf.SelectedText = strPage;
					rtf.SelectedText = "Loading: " + reference2.Description + "\r\n";
					rtf.SelectedText = "    Type              Angle Start Loc.   End Loc.    Start       End\r\n";
					rtf.SelectedText = Strings.Space (16) + text4.PadLeft (11) + text3.PadLeft (11) + text3.PadLeft (11) + "  Magnitude  Magnitude\r\n";
					short nLoad2 = reference2.nLoad;
					for (short num11 = 1; num11 <= nLoad2; num11 = (short)unchecked(num11 + 1)) {
						rtf.SelectedText = unchecked(Conversions.ToString ((int)num11).PadLeft (3) + Strings.Space (1) + CFSInterface.DisplayLoadType ((LoadTypes)reference2.Load [num11].Type).PadRight (12));
						switch (reference2.Load [num11].Type) {
						case 1:
							rtf.SelectedText = Units.DisplayAngle (reference2.Load [num11].Ang, 0, blnShowUnit: false, strFmt9, 11, 0) + Units.DisplayLength (reference2.Load [num11].Z0, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLength (reference2.Load [num11].Z1, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLoad (reference2.Load [num11].W0, 0, blnShowUnit: false, strFmt10, 11, 0) + Units.DisplayLoad (reference2.Load [num11].W1, 0, blnShowUnit: true, strFmt10, 11, 7) + "\r\n";
							break;
						case 2:
							rtf.SelectedText = Units.DisplayAngle (reference2.Load [num11].Ang, 0, blnShowUnit: false, strFmt9, 11, 0) + Units.DisplayLength (reference2.Load [num11].Z0, 0, blnShowUnit: false, strFmt, 11, 0) + Strings.Space (11) + Units.DisplayForce (reference2.Load [num11].W0, 0, blnShowUnit: true, strFmt7, 11, 0) + ", Width=" + Units.DisplayLen1 (reference2.Load [num11].Wid, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							break;
						case 3:
							rtf.SelectedText = Strings.Space (11) + Units.DisplayLength (reference2.Load [num11].Z0, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLength (reference2.Load [num11].Z1, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayForce (reference2.Load [num11].W0, 0, blnShowUnit: false, strFmt7, 11, 0) + Units.DisplayForce (reference2.Load [num11].W1, 0, blnShowUnit: true, strFmt7, 11, 7) + "\r\n";
							break;
						case 4:
							rtf.SelectedText = Units.DisplayAngle (reference2.Load [num11].Ang, 0, blnShowUnit: false, strFmt9, 11, 0) + Units.DisplayLength (reference2.Load [num11].Z0, 0, blnShowUnit: false, strFmt, 11, 0) + Strings.Space (11) + Units.DisplayMoment (reference2.Load [num11].W0, 0, blnShowUnit: true, strFmt11, 11, 0) + "\r\n";
							break;
						default:
							rtf.SelectedText = "\r\n";
							break;
						}
					}
				}
			}
			short nComb = analysis.nComb;
			for (short num12 = 1; num12 <= nComb; num12 = (short)unchecked(num12 + 1)) {
				if (analysis.Comb [num12].nLF > 0) {
					ref LoadCombination reference3 = ref analysis.Comb [num12];
					rtf.SelectedText = strPage;
					rtf.SelectedText = "Load Combination: " + reference3.Description + "\r\n";
					string text6 = ((reference3.Spec < 0) ? "Deflection Only" : CFS.strCSspec [reference3.Spec]);
					rtf.SelectedText = "Specification:    " + text6 + "\r\n";
					rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Inflection Point Bracing: ", Interaction.IIf (reference3.InflPt, "Yes", "No")), "\r\n"));
					rtf.SelectedText = "    Loading                     Factor\r\n";
					short nLF = reference3.nLF;
					for (short num13 = 1; num13 <= nLF; num13 = (short)unchecked(num13 + 1)) {
						rtf.SelectedText = Conversions.ToString (unchecked((int)num13)).PadLeft (3) + Strings.Space (1) + Analysis1.Ldg [reference3.LF [num13].iLdg].Description.PadRight (23) + Units.DisplayNone (reference3.LF [num13].fLdg, Units.Fmt [Units.FmtIndex (10f)], 11, 0) + "\r\n";
					}
				}
			}
			if (Strings.Len (analysis.Notes) > 0) {
				rtf.SelectedText = strPage;
				rtf.SelectionFont = new Font (BodyFont, FontStyle.Underline);
				rtf.SelectedText = "Notes\r\n";
				rtf.SelectionFont = TextFont;
				rtf.SelectedText = analysis.Notes + "\r\n";
			}
			analysis = null;
		}
	}

	public static void rptDiagrams (RichTextBox rtf, Analysis Analysis1, short iDir)
	{
		SolutionDetail Det = default(SolutionDetail);
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		string text = "(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		string text2 = "(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
		string text3 = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
		string text4 = "(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")";
		string strFmt = Units.Fmt [Units.FmtIndex (analysis.Dmax * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
		string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (analysis.Zmin), System.Math.Abs (analysis.Zmax)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
		string strFmt3 = Units.Fmt [Units.FmtIndex (analysis.Rmax * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
		string strFmt4 = Units.Fmt [Units.FmtIndex (analysis.Mmax * Units.untMoment [Units.DefaultUnitIndex [6]].Mult)];
		analysis.Sol [iDir].MinimaMaxima (ref Det);
		rtf.SelectionStart = Strings.Len (rtf.Text);
		rptTitle (rtf, "Maximum Shears, Moments, and Deflections");
		rtf.SelectedText = "Load Combination: " + analysis.Comb [analysis.iCombSol].Description;
		rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (", ", Interaction.IIf (iDir == 1, "Y", "X")), " Direction"), "\r\n"), "\r\n"));
		rtf.SelectedText = "   Location   Shear(l)   Shear(r)   Reaction\r\n";
		rtf.SelectedText = text2.PadLeft (11) + text3.PadLeft (11) + text3.PadLeft (11) + text3.PadLeft (11) + "\r\n";
		short nNode = analysis.Sol [iDir].nNode;
		checked {
			for (short num = 1; num <= nNode; num = (short)unchecked(num + 1)) {
				if (analysis.Sol [iDir].D [num] == 0f) {
					rtf.SelectedText = Units.DisplayLength (analysis.Sol [iDir].Znode [num], 0, blnShowUnit: false, strFmt2, 11, 0);
					float num2 = ((num <= 1) ? 0f : (0f - analysis.Sol [iDir].V [num - 1, 2]));
					rtf.SelectedText = Units.DisplayForce (num2, 0, blnShowUnit: false, strFmt3, 11, 0);
					float num3 = 0f - num2;
					num2 = analysis.Sol [iDir].V [num, 1];
					rtf.SelectedText = Units.DisplayForce (num2, 0, blnShowUnit: false, strFmt3, 11, 0);
					num3 += num2;
					rtf.SelectedText = Units.DisplayForce (num3, 0, blnShowUnit: false, strFmt3, 11, 0) + "\r\n";
				}
			}
			rtf.SelectedText = strPage;
			rtf.SelectedText = "   Location     Moment   Location Deflection  Inflections\r\n";
			rtf.SelectedText = text2.PadLeft (11) + text4.PadLeft (11) + text2.PadLeft (11) + text.PadLeft (11) + text2.PadLeft (13) + "\r\n";
			short num4 = Det.NM;
			if (Det.NR > num4) {
				num4 = Det.NR;
			}
			if (Det.ND > num4) {
				num4 = Det.ND;
			}
			short num5 = num4;
			for (short num = 1; num <= num5; num = (short)unchecked(num + 1)) {
				if (num <= Det.NM) {
					rtf.SelectedText = Units.DisplayLength (Det.ZM [num], 0, blnShowUnit: false, strFmt2, 11, 0);
					rtf.SelectedText = Units.DisplayMoment (Det.M [num], 0, blnShowUnit: false, strFmt4, 11, 0);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				if (num <= Det.ND) {
					rtf.SelectedText = Units.DisplayLength (Det.ZD [num], 0, blnShowUnit: false, strFmt2, 11, 0);
					rtf.SelectedText = Units.DisplayLen1 (Det.D [num], 0, blnShowUnit: false, strFmt, 11, 0);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				if (num <= Det.NR) {
					rtf.SelectedText = Units.DisplayLength (Det.ZR [num], 0, blnShowUnit: false, strFmt2, 13, 0);
				}
				rtf.SelectedText = "\r\n";
			}
			analysis = null;
		}
	}

	public static void rptTorsionDiagrams (RichTextBox rtf, Analysis Analysis1)
	{
		SolutionDetail Det = default(SolutionDetail);
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		string text = ("(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")").PadLeft (11);
		string text2 = ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")").PadLeft (11);
		string text3 = ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")").PadLeft (11);
		string text4 = ("(" + Units.untTorqueLoad [Units.DefaultUnitIndex [14]].Name + ")").PadLeft (17).PadRight (22);
		string text5 = ("(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")").PadLeft (11);
		string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (analysis.Zmin), System.Math.Abs (analysis.Zmax)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
		string strFmt2 = Units.Fmt [Units.FmtIndex (analysis.Rmax * Units.untTorque [Units.DefaultUnitIndex [12]].Mult)];
		string strFmt3 = Units.Fmt [Units.FmtIndex (analysis.Mmax * Units.untBimoment [Units.DefaultUnitIndex [13]].Mult)];
		string strFmt4 = Units.Fmt [Units.FmtIndex (analysis.Dmax * Units.untAngle [Units.DefaultUnitIndex [3]].Mult)];
		int nTseg = analysis.nTseg;
		checked {
			float num = default(float);
			for (int i = 1; i <= nTseg; i++) {
				if (System.Math.Abs (analysis.Tseg [i].W) > num) {
					num = System.Math.Abs (analysis.Tseg [i].W);
				}
				if (System.Math.Abs (analysis.Tseg [i].W + analysis.Tseg [i].U * analysis.Tseg [i].L) > num) {
					num = System.Math.Abs (analysis.Tseg [i].W + analysis.Tseg [i].U * analysis.Tseg [i].L);
				}
			}
			string strFmt5 = Units.Fmt [Units.FmtIndex (num * Units.untTorqueLoad [Units.DefaultUnitIndex [14]].Mult)];
			analysis.TorsionMinMax (ref Det);
			rtf.SelectionStart = Strings.Len (rtf.Text);
			rptTitle (rtf, "Maximum Torques, Bimoments, and Twist");
			rtf.SelectedText = "Load Combination: " + analysis.Comb [analysis.iCombSol].Description + "\r\n\r\n";
			rtf.SelectedText = "   Torsional Loads\r\n";
			rtf.SelectedText = "   Location     Torque   Bimoment    Distributed Torque        End\r\n";
			rtf.SelectedText = text + text2 + text3 + text4 + text + "\r\n";
			int nTseg2 = analysis.nTseg;
			for (int j = 1; j <= nTseg2; j++) {
				rtf.SelectedText = Units.DisplayLength (analysis.Tseg [j].Z, 0, blnShowUnit: false, strFmt, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (analysis.Tseg [j].T0, 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayBimoment (analysis.Tseg [j].B0, 0, blnShowUnit: false, strFmt3, 11, 0);
				rtf.SelectedText = Units.DisplayTorqueLoad (analysis.Tseg [j].W, 0, blnShowUnit: false, strFmt5, 11, 0);
				rtf.SelectedText = Units.DisplayTorqueLoad (analysis.Tseg [j].W + analysis.Tseg [j].U * analysis.Tseg [j].L, 0, blnShowUnit: false, strFmt5, 11, 0);
				rtf.SelectedText = Units.DisplayLength (analysis.Tseg [j].Z + analysis.Tseg [j].L, 0, blnShowUnit: false, strFmt, 11, 0) + "\r\n";
			}
			rtf.SelectedText = strPage;
			rtf.SelectedText = "   Torsional Results\r\n";
			rtf.SelectedText = "   Location     Tw (l)    Tsv (l)     Tw (r)    Tsv (r)   Reaction\r\n";
			rtf.SelectedText = text + text2 + text2 + text2 + text2 + text2 + "\r\n";
			int nR = Det.NR;
			for (int k = 1; k <= nR; k++) {
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				int nTseg3 = analysis.nTseg;
				for (int l = 1; l <= nTseg3; l++) {
					if (analysis.Tseg [l].Z == Det.ZR [k]) {
						num4 = analysis.Tseg [l].Tw (0f);
						num5 = analysis.Tseg [l].Tsv (0f);
						break;
					}
					if (analysis.Tseg [l].Z + analysis.Tseg [l].L == Det.ZR [k]) {
						num2 = analysis.Tseg [l].Tw (analysis.Tseg [l].L);
						num3 = analysis.Tseg [l].Tsv (analysis.Tseg [l].L);
					}
				}
				float sngValue = 0f - num2 - num3 + num4 + num5;
				rtf.SelectedText = Units.DisplayLength (Det.ZR [k], 0, blnShowUnit: false, strFmt, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (num2, 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (num3, 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (num4, 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (num5, 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (sngValue, 0, blnShowUnit: false, strFmt2, 11, 0) + "\r\n";
			}
			rtf.SelectedText = strPage;
			rtf.SelectedText = "   Location   Bimoment   Location      Twist\r\n";
			rtf.SelectedText = text + text3 + text + text5 + "\r\n";
			short num6 = 1;
			short num7 = 1;
			short num8 = ((Det.ND <= Det.NM) ? Det.NM : Det.ND);
			float num9 = (float)(0.0001 * (double)(analysis.Zmax - analysis.Zmin));
			int num10 = num8;
			for (int m = 1; m <= num10; m++) {
				bool flag = false;
				if ((num8 == Det.NM) | ((short)unchecked(Det.NM - num6) == num8 - m)) {
					flag = true;
				}
				if (num6 <= Det.NM && (num7 >= Det.ND || Det.ZM [num6] < Det.ZD [num7 + 1] - num9)) {
					flag = true;
				}
				bool flag2 = false;
				if ((num8 == Det.ND) | ((short)unchecked(Det.ND - num7) == num8 - m)) {
					flag2 = true;
				}
				if (num7 <= Det.ND && (num6 >= Det.NM || Det.ZD [num7] < Det.ZM [num6 + 1] - num9)) {
					flag2 = true;
				}
				if (flag) {
					rtf.SelectedText = Units.DisplayLength (Det.ZM [num6], 0, blnShowUnit: false, strFmt, 11, 0);
					rtf.SelectedText = Units.DisplayBimoment (Det.M [num6], 0, blnShowUnit: false, strFmt3, 11, 0);
					num6 = (short)(num6 + 1);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				if (flag2) {
					rtf.SelectedText = Units.DisplayLength (Det.ZD [num7], 0, blnShowUnit: false, strFmt, 11, 0);
					rtf.SelectedText = Units.DisplayAngle (Det.D [num7], 0, blnShowUnit: false, strFmt4, 11, 0);
					num7 = (short)(num7 + 1);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				rtf.SelectedText = "\r\n";
			}
			analysis = null;
		}
	}

	public static void rptEnvelopes (RichTextBox rtf, Analysis Analysis1, short iDir)
	{
		SolutionDetail Det = default(SolutionDetail);
		string strMsg = string.Empty;
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		checked {
			float[,] array = new float[Information.UBound (analysis.Rdiag) + 1, 5];
			float[,] array2 = new float[Information.UBound (analysis.Mdiag) + 1, 3];
			float[,] array3 = new float[Information.UBound (analysis.Ddiag) + 1, 3];
			short iComb = analysis.iComb;
			short nComb = analysis.nComb;
			short num7 = default(short);
			short num11 = default(short);
			short num14 = default(short);
			for (short num = 1; num <= nComb; num = (short)unchecked(num + 1)) {
				analysis.iComb = (byte)num;
				analysis.Analyze (ref strMsg, blnCheckLicense: false);
				analysis.Sol [iDir].MinimaMaxima (ref Det);
				short nNode = analysis.Sol [iDir].nNode;
				for (short num2 = 1; num2 <= nNode; num2 = (short)unchecked(num2 + 1)) {
					if (analysis.Sol [iDir].D [num2] == 0f) {
						float num3 = ((num2 <= 1) ? 0f : (0f - analysis.Sol [iDir].V [num2 - 1, 2]));
						float num4 = 0f - num3;
						num4 += analysis.Sol [iDir].V [num2, 1];
						float num5 = analysis.Sol [iDir].Znode [num2];
						short num6 = (short)System.Math.Round ((num5 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Rdiag));
						if (((double)num4 >= 0.999 * (double)analysis.Rdiag [num6]) | ((double)num4 <= 0.999 * (double)analysis.Rdiag2 [num6])) {
							short num8 = num7;
							short num9 = 1;
							while (num9 <= num8 && !((double)System.Math.Abs (array [num9, 1] - num5) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
								num9 = (short)unchecked(num9 + 1);
							}
							if (unchecked(num9 > num7 && num4 != 0f)) {
								num7 = (short)(num7 + 1);
							}
							if (System.Math.Abs (num4) > System.Math.Abs (array [num9, 4])) {
								array [num9, 1] = num5;
								array [num9, 2] = num3;
								array [num9, 3] = analysis.Sol [iDir].V [num2, 1];
								array [num9, 4] = num4;
							}
						}
					}
				}
				short nM = Det.NM;
				for (short num2 = 1; num2 <= nM; num2 = (short)unchecked(num2 + 1)) {
					float num10 = Det.M [num2];
					if ((double)System.Math.Abs (num10) > 0.01 * (double)analysis.Mmax) {
						float num5 = Det.ZM [num2];
						short num6 = (short)System.Math.Round ((num5 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Mdiag));
						if (((double)num10 >= 0.999 * (double)analysis.Mdiag [num6]) | ((double)num10 <= 0.999 * (double)analysis.Mdiag2 [num6])) {
							short num12 = num11;
							short num9 = 1;
							while (num9 <= num12 && !((double)System.Math.Abs (array2 [num9, 1] - num5) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
								num9 = (short)unchecked(num9 + 1);
							}
							if (num9 > num11) {
								num11 = (short)(num11 + 1);
							}
							if (System.Math.Abs (num10) > System.Math.Abs (array2 [num9, 2])) {
								array2 [num9, 1] = num5;
								array2 [num9, 2] = num10;
							}
						}
					}
				}
				short nD = Det.ND;
				for (short num2 = 1; num2 <= nD; num2 = (short)unchecked(num2 + 1)) {
					float num13 = Det.D [num2];
					if ((double)System.Math.Abs (num13) > 0.01 * (double)analysis.Dmax) {
						float num5 = Det.ZD [num2];
						short num6 = (short)System.Math.Round ((num5 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Ddiag));
						if (((double)num13 >= 0.999 * (double)analysis.Ddiag [num6]) | ((double)num13 <= 0.999 * (double)analysis.Ddiag2 [num6])) {
							short num15 = num14;
							short num9 = 1;
							while (num9 <= num15 && !((double)System.Math.Abs (array3 [num9, 1] - num5) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
								num9 = (short)unchecked(num9 + 1);
							}
							if (num9 > num14) {
								num14 = (short)(num14 + 1);
							}
							if (System.Math.Abs (num13) > System.Math.Abs (array3 [num9, 2])) {
								array3 [num9, 1] = num5;
								array3 [num9, 2] = num13;
							}
						}
					}
				}
			}
			analysis.iComb = (byte)iComb;
			analysis.Analyze (ref strMsg, blnCheckLicense: false);
			analysis.Sol [iDir].MinimaMaxima (ref Det);
			short num16 = num7;
			for (short num2 = 2; num2 <= num16; num2 = (short)unchecked(num2 + 1)) {
				short num9 = (short)(num2 - 1);
				while (num9 >= 1 && !(array [num9, 1] <= array [num9 + 1, 1])) {
					CFS.Swap (ref array [num9, 1], ref array [num9 + 1, 1]);
					CFS.Swap (ref array [num9, 2], ref array [num9 + 1, 2]);
					CFS.Swap (ref array [num9, 3], ref array [num9 + 1, 3]);
					CFS.Swap (ref array [num9, 4], ref array [num9 + 1, 4]);
					num9 = (short)unchecked(num9 + -1);
				}
			}
			short num17 = num11;
			for (short num2 = 2; num2 <= num17; num2 = (short)unchecked(num2 + 1)) {
				short num9 = (short)(num2 - 1);
				while (num9 >= 1 && !(array2 [num9, 1] <= array2 [num9 + 1, 1])) {
					CFS.Swap (ref array2 [num9, 1], ref array2 [num9 + 1, 1]);
					CFS.Swap (ref array2 [num9, 2], ref array2 [num9 + 1, 2]);
					num9 = (short)unchecked(num9 + -1);
				}
			}
			short num18 = num14;
			for (short num2 = 2; num2 <= num18; num2 = (short)unchecked(num2 + 1)) {
				short num9 = (short)(num2 - 1);
				while (num9 >= 1 && !(array3 [num9, 1] <= array3 [num9 + 1, 1])) {
					CFS.Swap (ref array3 [num9, 1], ref array3 [num9 + 1, 1]);
					CFS.Swap (ref array3 [num9, 2], ref array3 [num9 + 1, 2]);
					num9 = (short)unchecked(num9 + -1);
				}
			}
			string text = "(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
			string text2 = "(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
			string text3 = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
			string text4 = "(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")";
			string strFmt = Units.Fmt [Units.FmtIndex (analysis.Dmax * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
			string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (analysis.Zmin), System.Math.Abs (analysis.Zmax)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
			string strFmt3 = Units.Fmt [Units.FmtIndex (analysis.Rmax * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
			string strFmt4 = Units.Fmt [Units.FmtIndex (analysis.Mmax * Units.untMoment [Units.DefaultUnitIndex [6]].Mult)];
			rtf.SelectionStart = Strings.Len (rtf.Text);
			rptTitle (rtf, "Maximum Shears, Moments, and Deflections");
			rtf.SelectedText = "Envelope of All Combinations";
			rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (", ", Interaction.IIf (iDir == 1, "Y", "X")), " Direction"), "\r\n"), "\r\n"));
			rtf.SelectedText = "   Location   Shear(l)   Shear(r)   Reaction\r\n";
			rtf.SelectedText = text2.PadLeft (11) + text3.PadLeft (11) + text3.PadLeft (11) + text3.PadLeft (11) + "\r\n";
			short num19 = num7;
			for (short num2 = 1; num2 <= num19; num2 = (short)unchecked(num2 + 1)) {
				rtf.SelectedText = Units.DisplayLength (array [num2, 1], 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayForce (array [num2, 2], 0, blnShowUnit: false, strFmt3, 11, 0);
				rtf.SelectedText = Units.DisplayForce (array [num2, 3], 0, blnShowUnit: false, strFmt3, 11, 0);
				rtf.SelectedText = Units.DisplayForce (array [num2, 4], 0, blnShowUnit: false, strFmt3, 11, 0) + "\r\n";
			}
			rtf.SelectedText = strPage;
			rtf.SelectedText = "   Location     Moment   Location Deflection\r\n";
			rtf.SelectedText = text2.PadLeft (11) + text4.PadLeft (11) + text2.PadLeft (11) + text.PadLeft (11) + "\r\n";
			short num20 = ((num11 <= num14) ? num14 : num11);
			short num21 = num20;
			for (short num2 = 1; num2 <= num21; num2 = (short)unchecked(num2 + 1)) {
				if (num2 <= num11) {
					rtf.SelectedText = Units.DisplayLength (array2 [num2, 1], 0, blnShowUnit: false, strFmt2, 11, 0);
					rtf.SelectedText = Units.DisplayMoment (array2 [num2, 2], 0, blnShowUnit: false, strFmt4, 11, 0);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				if (num2 <= num14) {
					rtf.SelectedText = Units.DisplayLength (array3 [num2, 1], 0, blnShowUnit: false, strFmt2, 11, 0);
					rtf.SelectedText = Units.DisplayLen1 (array3 [num2, 2], 0, blnShowUnit: false, strFmt, 11, 0);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				rtf.SelectedText = "\r\n";
			}
			analysis = null;
		}
	}

	public static void rptTorsionEnvelopes (RichTextBox rtf, Analysis Analysis1)
	{
		SolutionDetail Det = default(SolutionDetail);
		string strMsg = string.Empty;
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		checked {
			float[,] array = new float[Information.UBound (analysis.Rdiag) + 1, 7];
			float[,] array2 = new float[Information.UBound (analysis.Mdiag) + 1, 3];
			float[,] array3 = new float[Information.UBound (analysis.Ddiag) + 1, 3];
			short iComb = analysis.iComb;
			short nComb = analysis.nComb;
			short num9 = default(short);
			short num13 = default(short);
			short num16 = default(short);
			for (short num = 1; num <= nComb; num = (short)unchecked(num + 1)) {
				analysis.iComb = (byte)num;
				analysis.AnalyzeTorsion (ref strMsg, blnCheckLicense: false);
				analysis.TorsionMinMax (ref Det);
				int nR = Det.NR;
				for (int i = 1; i <= nR; i++) {
					float num2 = Det.ZR [i];
					float num3 = 0f;
					float num4 = 0f;
					float num5 = 0f;
					float num6 = 0f;
					int nTseg = analysis.nTseg;
					for (int j = 1; j <= nTseg; j++) {
						if (analysis.Tseg [j].Z == num2) {
							num5 = analysis.Tseg [j].Tw (0f);
							num6 = analysis.Tseg [j].Tsv (0f);
							break;
						}
						if (analysis.Tseg [j].Z + analysis.Tseg [j].L == num2) {
							num3 = analysis.Tseg [j].Tw (analysis.Tseg [j].L);
							num4 = analysis.Tseg [j].Tsv (analysis.Tseg [j].L);
						}
					}
					float num7 = 0f - num3 - num4 + num5 + num6;
					short num8 = (short)System.Math.Round ((num2 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Rdiag));
					if (((double)num7 >= 0.999 * (double)analysis.Rdiag [num8]) | ((double)num7 <= 0.999 * (double)analysis.Rdiag2 [num8])) {
						short num10 = num9;
						short num11 = 1;
						while (num11 <= num10 && !((double)System.Math.Abs (array [num11, 1] - num2) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
							num11 = (short)unchecked(num11 + 1);
						}
						if (num11 > num9) {
							num9 = (short)(num9 + 1);
						}
						array [num11, 1] = num2;
						if (System.Math.Abs (num7) > System.Math.Abs (array [num11, 6])) {
							array [num11, 2] = num3;
							array [num11, 3] = num4;
							array [num11, 4] = num5;
							array [num11, 5] = num6;
							array [num11, 6] = num7;
						}
					}
				}
				int nM = Det.NM;
				for (int k = 1; k <= nM; k++) {
					float num12 = Det.M [k];
					if (!((double)System.Math.Abs (num12) > 0.01 * (double)analysis.Mmax)) {
						continue;
					}
					float num2 = Det.ZM [k];
					short num8 = (short)System.Math.Round ((num2 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Mdiag));
					if (((double)num12 >= 0.999 * (double)analysis.Mdiag [num8]) | ((double)num12 <= 0.999 * (double)analysis.Mdiag2 [num8])) {
						short num14 = num13;
						short num11 = 1;
						while (num11 <= num14 && !((double)System.Math.Abs (array2 [num11, 1] - num2) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
							num11 = (short)unchecked(num11 + 1);
						}
						if (num11 > num13) {
							num13 = (short)(num13 + 1);
						}
						array2 [num11, 1] = num2;
						if (System.Math.Abs (num12) > System.Math.Abs (array2 [num11, 2])) {
							array2 [num11, 2] = num12;
						}
					}
				}
				int nD = Det.ND;
				for (int l = 1; l <= nD; l++) {
					float num15 = Det.D [l];
					if (!((double)System.Math.Abs (num15) > 0.01 * (double)analysis.Dmax)) {
						continue;
					}
					float num2 = Det.ZD [l];
					short num8 = (short)System.Math.Round ((num2 - analysis.Zmin) / (analysis.Zmax - analysis.Zmin) * (float)Information.UBound (analysis.Ddiag));
					if (((double)num15 >= 0.999 * (double)analysis.Ddiag [num8]) | ((double)num15 <= 0.999 * (double)analysis.Ddiag2 [num8])) {
						short num17 = num16;
						short num11 = 1;
						while (num11 <= num17 && !((double)System.Math.Abs (array3 [num11, 1] - num2) <= 0.001 * (double)(analysis.Zmax - analysis.Zmin))) {
							num11 = (short)unchecked(num11 + 1);
						}
						if (num11 > num16) {
							num16 = (short)(num16 + 1);
						}
						array3 [num11, 1] = num2;
						if (System.Math.Abs (num15) > System.Math.Abs (array3 [num11, 2])) {
							array3 [num11, 2] = num15;
						}
					}
				}
			}
			analysis.iComb = (byte)iComb;
			analysis.AnalyzeTorsion (ref strMsg, blnCheckLicense: false);
			int num18 = num9;
			for (int m = 2; m <= num18; m++) {
				short num11 = (short)(m - 1);
				while (num11 >= 1 && !(array [num11, 1] <= array [num11 + 1, 1])) {
					CFS.Swap (ref array [num11, 1], ref array [num11 + 1, 1]);
					CFS.Swap (ref array [num11, 2], ref array [num11 + 1, 2]);
					CFS.Swap (ref array [num11, 3], ref array [num11 + 1, 3]);
					CFS.Swap (ref array [num11, 4], ref array [num11 + 1, 4]);
					CFS.Swap (ref array [num11, 5], ref array [num11 + 1, 5]);
					CFS.Swap (ref array [num11, 6], ref array [num11 + 1, 6]);
					num11 = (short)unchecked(num11 + -1);
				}
			}
			int num19 = num13;
			for (int n = 2; n <= num19; n++) {
				short num11 = (short)(n - 1);
				while (num11 >= 1 && !(array2 [num11, 1] <= array2 [num11 + 1, 1])) {
					CFS.Swap (ref array2 [num11, 1], ref array2 [num11 + 1, 1]);
					CFS.Swap (ref array2 [num11, 2], ref array2 [num11 + 1, 2]);
					num11 = (short)unchecked(num11 + -1);
				}
			}
			int num20 = num16;
			for (int num21 = 2; num21 <= num20; num21++) {
				short num11 = (short)(num21 - 1);
				while (num11 >= 1 && !(array3 [num11, 1] <= array3 [num11 + 1, 1])) {
					CFS.Swap (ref array3 [num11, 1], ref array3 [num11 + 1, 1]);
					CFS.Swap (ref array3 [num11, 2], ref array3 [num11 + 1, 2]);
					num11 = (short)unchecked(num11 + -1);
				}
			}
			string text = ("(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")").PadLeft (11);
			string text2 = ("(" + Units.untTorque [Units.DefaultUnitIndex [12]].Name + ")").PadLeft (11);
			string text3 = ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")").PadLeft (11);
			string text4 = ("(" + Units.untLength [Units.DefaultUnitIndex [3]].Name + ")").PadLeft (11);
			string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (analysis.Zmin), System.Math.Abs (analysis.Zmax)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
			string strFmt2 = Units.Fmt [Units.FmtIndex (analysis.Rmax * Units.untTorque [Units.DefaultUnitIndex [12]].Mult)];
			string strFmt3 = Units.Fmt [Units.FmtIndex (analysis.Mmax * Units.untBimoment [Units.DefaultUnitIndex [13]].Mult)];
			string strFmt4 = Units.Fmt [Units.FmtIndex (analysis.Dmax * Units.untAngle [Units.DefaultUnitIndex [3]].Mult)];
			rtf.SelectionStart = Strings.Len (rtf.Text);
			rptTitle (rtf, "Maximum Torques, Bimoments, and Twist");
			rtf.SelectedText = "Envelope of All Combinations\r\n\r\n";
			rtf.SelectedText = "   Location     Tw (l)    Tsv (l)     Tw (r)    Tsv (r)   Reaction\r\n";
			rtf.SelectedText = text + text2 + text2 + text2 + text2 + text2 + "\r\n";
			int num22 = num9;
			for (int num23 = 1; num23 <= num22; num23++) {
				rtf.SelectedText = Units.DisplayLength (array [num23, 1], 0, blnShowUnit: false, strFmt, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (array [num23, 2], 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (array [num23, 3], 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (array [num23, 4], 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (array [num23, 5], 0, blnShowUnit: false, strFmt2, 11, 0);
				rtf.SelectedText = Units.DisplayTorque (array [num23, 6], 0, blnShowUnit: false, strFmt2, 11, 0) + "\r\n";
			}
			rtf.SelectedText = strPage;
			rtf.SelectedText = "   Location   Bimoment   Location      Twist\r\n";
			rtf.SelectedText = text + text3 + text + text4 + "\r\n";
			short num24 = 1;
			short num25 = 1;
			short num26 = ((num16 <= num13) ? num13 : num16);
			float num27 = (float)(0.0001 * (double)(analysis.Zmax - analysis.Zmin));
			int num28 = num26;
			for (int num29 = 1; num29 <= num28; num29++) {
				bool flag = false;
				if ((num26 == num13) | ((short)unchecked(num13 - num24) == num26 - num29)) {
					flag = true;
				}
				if (num24 <= num13 && (num25 >= num16 || array2 [num24, 1] < array3 [num25 + 1, 1] - num27)) {
					flag = true;
				}
				bool flag2 = false;
				if ((num26 == num16) | ((short)unchecked(num16 - num25) == num26 - num29)) {
					flag2 = true;
				}
				if (num25 <= num16 && (num24 >= num13 || array3 [num25, 1] < array2 [num24 + 1, 1] - num27)) {
					flag2 = true;
				}
				if (flag) {
					rtf.SelectedText = Units.DisplayLength (array2 [num24, 1], 0, blnShowUnit: false, strFmt, 11, 0);
					rtf.SelectedText = Units.DisplayBimoment (array2 [num24, 2], 0, blnShowUnit: false, strFmt3, 11, 0);
					num24 = (short)(num24 + 1);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				if (flag2) {
					rtf.SelectedText = Units.DisplayLength (array3 [num25, 1], 0, blnShowUnit: false, strFmt, 11, 0);
					rtf.SelectedText = Units.DisplayAngle (array3 [num25, 2], 0, blnShowUnit: false, strFmt4, 11, 0);
					num25 = (short)(num25 + 1);
				} else {
					rtf.SelectedText = Strings.Space (22);
				}
				rtf.SelectedText = "\r\n";
			}
			analysis = null;
		}
	}

	public static bool rptMemberCheck (RichTextBox rtf, Section Section1, MemberParameters MP)
	{
		MemberCheck Check = default(MemberCheck);
		bool result = false;
		string text = Section1.CheckBasicSection ();
		if (text.Length > 0) {
			CFS.LicenseRequired (text);
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcStrength ((short)MP.Spec);
			Section1.MemberCheck (MP, ref Check);
			Cursor.Current = Cursors.Default;
			rtf.Rtf = string.Empty;
			ref Section.StrengthType strength = ref Section1.Strength;
			string strFmt = Units.Fmt [Units.FmtIndex (5f)];
			string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (MP.Lx, MP.Ly, MP.Lt, MP.Lm) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
			string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.ex), System.Math.Abs (MP.ey)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
			string text2 = ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")").PadLeft (11);
			string text3 = ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")").PadLeft (11);
			string truePart = ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")").PadLeft (11);
			if (CFS.IsSpecASD ((short)MP.Spec)) {
				string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.P), Check.Pa, System.Math.Abs (MP.Vy), strength.Vay, System.Math.Abs (MP.Vx), strength.Vax) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
				string strFmt5 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.Mx), System.Math.Abs (Check.Mx), Check.Max, System.Math.Abs (MP.My), System.Math.Abs (Check.My), Check.May) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
				string strFmt6 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.B), System.Math.Abs (Check.B), strength.Ba) * (double)Units.untBimoment [Units.DefaultUnitIndex [13]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Member Check - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)MP.Spec], CFS.strSSspec (MP.Spec)))));
				rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				rtf.SelectedText = "Design Parameters:\r\n";
				rtf.SelectedText = "Lx   " + Units.DisplayLength (MP.Lx, 0, blnShowUnit: true, strFmt2, 11, 8) + "Ly   " + Units.DisplayLength (MP.Ly, 0, blnShowUnit: true, strFmt2, 11, 8) + "Lt   " + Units.DisplayLength (MP.Lt, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
				rtf.SelectedText = "Kx   " + Units.DisplayNone (MP.Kx, strFmt, 11, 8) + "Ky   " + Units.DisplayNone (MP.Ky, strFmt, 11, 8) + "Kt   " + Units.DisplayNone (MP.Kt, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Cbx  " + Units.DisplayNone (Check.Cbx, strFmt, 11, 8) + "Cby  " + Units.DisplayNone (Check.Cby, strFmt, 11, 8) + "ex   " + Units.DisplayLen1 (MP.ex, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "Cmx  " + Units.DisplayNone (MP.Cmx, strFmt, 11, 8) + "Cmy  " + Units.DisplayNone (MP.Cmy, strFmt, 11, 8) + "ey   " + Units.DisplayLen1 (MP.ey, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "Braced Flange: " + CFSInterface.DisplayFlange (MP.iBrcFlg).PadRight (9);
				rtf.SelectedText = "kφ   " + Units.DisplayForce (MP.Kf, 0, blnShowUnit: true, "", 11, 8) + "\r\n";
				rtf.SelectedText = "Red. Factor, R: " + Units.DisplayNone (MP.R, "", 0, 8) + "Lm   " + Units.DisplayLength (MP.Lm, 0, blnShowUnit: true, strFmt2, 11, 8) + "\r\n";
				if (MP.BucklingTheory & ((MP.Kx * MP.Lx > 0f) | (MP.Ky * MP.Ly > 0f) | (MP.Kt * MP.Lt > 0f))) {
					rtf.SelectedText = "Global buckling calculated using elastic theory\r\n";
				}
				if (MP.Pdelta & ((MP.Mx != 0f) | (MP.My != 0f))) {
					rtf.SelectedText = "Entered moments include P-δ effects\r\n";
				}
				rtf.SelectedText = strPage;
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Loads:           P         Mx         Vy         My         Vx", Interaction.IIf (MP.Torsion, "         B", "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Strings.Space (8) + text2 + text3 + text2 + text3 + text2, Interaction.IIf (MP.Torsion, truePart, "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Entered " + Units.DisplayForce (MP.P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (MP.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (MP.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (MP.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (MP.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (MP.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Applied " + Units.DisplayForce (MP.P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (Check.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("Strength" + Units.DisplayForce (Check.Pa, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Max, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.Vay, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.May, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.Vax, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (strength.Ba, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"), strPage));
			} else {
				string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.P), Check.QPn, System.Math.Abs (MP.Vy), strength.QVny, System.Math.Abs (MP.Vx), strength.QVnx) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
				string strFmt5 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.Mx), System.Math.Abs (Check.Mx), Check.QMnx, System.Math.Abs (MP.My), System.Math.Abs (Check.My), Check.QMny) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
				string strFmt6 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (MP.B), System.Math.Abs (Check.B), strength.QBn) * (double)Units.untBimoment [Units.DefaultUnitIndex [13]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Member Check - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)MP.Spec], CFS.strSSspec (MP.Spec)))));
				rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				rtf.SelectedText = "Design Parameters:\r\n";
				rtf.SelectedText = "Lx   " + Units.DisplayLength (MP.Lx, 0, blnShowUnit: true, strFmt2, 11, 8) + "Ly   " + Units.DisplayLength (MP.Ly, 0, blnShowUnit: true, strFmt2, 11, 8) + "Lt   " + Units.DisplayLength (MP.Lt, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
				rtf.SelectedText = "Kx   " + Units.DisplayNone (MP.Kx, strFmt, 11, 8) + "Ky   " + Units.DisplayNone (MP.Ky, strFmt, 11, 8) + "Kt   " + Units.DisplayNone (MP.Kt, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Cbx  " + Units.DisplayNone (Check.Cbx, strFmt, 11, 8) + "Cby  " + Units.DisplayNone (Check.Cby, strFmt, 11, 8) + "ex   " + Units.DisplayLen1 (MP.ex, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "Cmx  " + Units.DisplayNone (MP.Cmx, strFmt, 11, 8) + "Cmy  " + Units.DisplayNone (MP.Cmy, strFmt, 11, 8) + "ey   " + Units.DisplayLen1 (MP.ey, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "Braced Flange: " + CFSInterface.DisplayFlange (MP.iBrcFlg).PadRight (9);
				rtf.SelectedText = "kφ   " + Units.DisplayForce (MP.Kf, 0, blnShowUnit: true, "", 11, 8) + "\r\n";
				rtf.SelectedText = "Red. Factor, R: " + Units.DisplayNone (MP.R, "", 0, 8) + "Lm   " + Units.DisplayLength (MP.Lm, 0, blnShowUnit: true, strFmt2, 11, 8) + "\r\n";
				if (MP.BucklingTheory & ((MP.Kx * MP.Lx > 0f) | (MP.Ky * MP.Ly > 0f) | (MP.Kt * MP.Lt > 0f))) {
					rtf.SelectedText = "Global buckling calculated using elastic theory\r\n";
				}
				if (MP.Pdelta & ((MP.Mx != 0f) | (MP.My != 0f))) {
					rtf.SelectedText = "Entered moments include P-δ effects\r\n";
				}
				rtf.SelectedText = strPage;
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Loads:           P         Mx         Vy         My         Vx", Interaction.IIf (MP.Torsion, "         B", "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Strings.Space (8) + text2 + text3 + text2 + text3 + text2, Interaction.IIf (MP.Torsion, truePart, "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Entered " + Units.DisplayForce (MP.P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (MP.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (MP.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (MP.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (MP.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (MP.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Applied " + Units.DisplayForce (MP.P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (Check.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("Strength" + Units.DisplayForce (Check.QPn, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.QMnx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.QVny, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.QMny, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.QVnx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (MP.Torsion, Units.DisplayBimoment (strength.QBn, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"), strPage));
			}
			rtf.SelectedText = "Interaction Equations\r\n";
			short num = 1;
			checked {
				do {
					if (Strings.Len (Check.EqText [num]) != 0) {
						short num2 = (short)Strings.InStr (Check.EqText [num], ">");
						if (num2 > 0) {
							rtf.SelectedText = Strings.Left (Check.EqText [num], num2 - 1);
							rtf.SelectionColor = Color.Red;
							rtf.SelectedText = Strings.Mid (Check.EqText [num], num2) + "\r\n";
							rtf.SelectionColor = Color.Black;
						} else {
							rtf.SelectedText = Check.EqText [num] + "\r\n";
						}
					}
					num = (short)unchecked(num + 1);
				} while (num <= 5);
				if (Strings.Len (Check.Msg) != 0) {
					rtf.SelectedText = strPage + Check.Msg;
				}
				int nPart = Section1.nPart;
				float num3 = default(float);
				for (int i = 1; i <= nPart; i++) {
					if (System.Math.Abs (Check.VFy [i]) > num3) {
						num3 = System.Math.Abs (Check.VFy [i]);
					}
					if (System.Math.Abs (Check.VFx [i]) > num3) {
						num3 = System.Math.Abs (Check.VFx [i]);
					}
				}
				if (unchecked(Section1.nPart > 1 && (double)num3 > 0.001)) {
					string strFmt7 = Units.Fmt [Units.FmtIndex (num3 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult)];
					rtf.SelectedText = strPage + "Shear flow between parts due to:  Vertical Shear    Horizontal Shear\r\n";
					int nPart2 = Section1.nPart;
					for (int j = 1; j <= nPart2; j++) {
						string text4 = "Part " + Conversions.ToString (j) + ": " + Section1.Part [j].Name;
						float num4 = Check.VFy [j];
						float num5 = Check.VFx [j];
						if (Section1.nPart == 2) {
							text4 = "Between parts 1 and 2";
							num4 = System.Math.Abs (num4);
							num5 = System.Math.Abs (num5);
							j = 2;
						}
						rtf.SelectedText = text4.PadRight (31) + Units.DisplayLoad (num4, 0, blnShowUnit: true, strFmt7, 11, 9) + Units.DisplayLoad (num5, 0, blnShowUnit: true, strFmt7, 11, 0) + "\r\n";
					}
				}
			}
			if (CFS.blnTraceMemberChk & (Strings.Len (CFS.strTrace) > 0)) {
				rtf.SelectedText = strPage;
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Calculation Details - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)MP.Spec], CFS.strSSspec (MP.Spec)))));
				rptTrace (rtf, CFS.strTrace);
			}
			result = true;
		}
		return result;
	}

	public static void rptMemberCheckAnl (RichTextBox rtf, Analysis Analysis1, ref short nChk, ref short[] Cchk, ref float[] Zchk, ref short[] Schk)
	{
		string strMsg = string.Empty;
		MemberCheck Check = default(MemberCheck);
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		string text = ("(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")").PadLeft (11);
		string text2 = ("(" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")").PadLeft (11);
		string truePart = ("(" + Units.untBimoment [Units.DefaultUnitIndex [13]].Name + ")").PadLeft (11);
		float num = ((System.Math.Sign (analysis.Zmax) != System.Math.Sign (analysis.Zmin)) ? (analysis.Zmax - analysis.Zmin) : ((!(System.Math.Abs (analysis.Zmax) > System.Math.Abs (analysis.Zmin))) ? System.Math.Abs (analysis.Zmin) : System.Math.Abs (analysis.Zmax)));
		num = (float)((double)num * 1E-06);
		short num2 = nChk;
		checked {
			float num10 = default(float);
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Schk [num3] != 2) {
					short spec = analysis.Comb [Cchk [num3]].Spec;
					if ((analysis.iComb != Cchk [num3]) | (analysis.iCombSol != Cchk [num3])) {
						analysis.iComb = (byte)Cchk [num3];
						analysis.Analyze (ref strMsg);
						if (analysis.Torsion) {
							analysis.AnalyzeTorsion (ref strMsg);
						}
					}
					float num4 = Zchk [num3] + (float)Schk [num3] * num;
					MemberParameters[] array = Analysis1.MemberCheckParameters (num4);
					string strFmt = Units.Fmt [Units.FmtIndex (5f)];
					string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (array [0].Lx, array [0].Ly, array [0].Lt) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
					string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].ex), System.Math.Abs (array [0].ey)) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
					string text3 = string.Empty;
					short nBeam = analysis.nBeam;
					for (short num5 = 1; num5 <= nBeam; num5 = (short)unchecked(num5 + 1)) {
						unchecked {
							if ((analysis.Beam [num5].Z0 <= num4) & (analysis.Beam [num5].Z1 >= num4)) {
								if (CFS.Sections [analysis.Beam [num5].iSct].Material.IsCarbon ()) {
									if (Operators.CompareString (text3, CFS.strSSspec ((Specifications)checked((byte)spec)), TextCompare: false) == 0) {
										text3 = CFS.strCSspec [spec] + " and \r\n" + CFS.strSSspec ((Specifications)checked((byte)spec));
										break;
									}
									text3 = CFS.strCSspec [spec];
								} else {
									if (Operators.CompareString (text3, CFS.strCSspec [spec], TextCompare: false) == 0) {
										text3 = CFS.strCSspec [spec] + " and \r\n" + CFS.strSSspec ((Specifications)checked((byte)spec));
										break;
									}
									text3 = CFS.strSSspec ((Specifications)checked((byte)spec));
								}
							}
						}
					}
					rtf.SelectionStart = Strings.Len (rtf.Text);
					if (rtf.SelectionStart > 0) {
						rtf.SelectedText = strPage;
					}
					rptTitle (rtf, "Member Check - " + text3);
					rtf.SelectedText = "Load Combination: " + analysis.Comb [analysis.iCombSol].Description + "\r\n";
					rtf.SelectedText = "Design Parameters at " + Units.DisplayLength (Zchk [num3], 0, blnShowUnit: true, strFmt2, 0, 0);
					if (Schk [num3] == -1) {
						rtf.SelectedText = Conversions.ToString (Interaction.IIf (analysis.Vertical, ", Upper side", ", Left side"));
					} else if (Schk [num3] == 1) {
						rtf.SelectedText = Conversions.ToString (Interaction.IIf (analysis.Vertical, ", Lower side", ", Right side"));
					}
					rtf.SelectedText = ":\r\n";
					rtf.SelectedText = "Lx   " + Units.DisplayLength (array [0].Lx, 0, blnShowUnit: true, strFmt2, 11, 8) + "Ly   " + Units.DisplayLength (array [0].Ly, 0, blnShowUnit: true, strFmt2, 11, 8) + "Lt   " + Units.DisplayLength (array [0].Lt, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					rtf.SelectedText = "Kx   " + Units.DisplayNone (array [0].Kx, strFmt, 11, 8) + "Ky   " + Units.DisplayNone (array [0].Ky, strFmt, 11, 8) + "Kt   " + Units.DisplayNone (array [0].Kt, strFmt, 11, 0) + "\r\n";
					if (array [0].BucklingTheory & ((array [0].Kx * array [0].Lx > 0f) | (array [0].Ky * array [0].Ly > 0f) | (array [0].Kt * array [0].Lt > 0f))) {
						rtf.SelectedText = "Global buckling calculated using elastic theory\r\n";
					}
					short nBeam2 = analysis.nBeam;
					for (short num5 = 1; num5 <= nBeam2; num5 = (short)unchecked(num5 + 1)) {
						if ((analysis.Beam [num5].Z0 <= num4) & (analysis.Beam [num5].Z1 >= num4)) {
							short num6 = (short)(num5 - 1);
							short num7 = 1;
							while (num7 <= num6 && (analysis.Beam [num5].iSct != analysis.Beam [num7].iSct || !((analysis.Beam [num7].Z0 <= num4) & (analysis.Beam [num7].Z1 >= num4)) || !((array [num7].R == array [num5].R) & (array [num7].iBrcFlg == array [num5].iBrcFlg) & (array [num7].Kf == array [num5].Kf) & (array [num7].Lm == array [num5].Lm) & (array [num7].ex == array [num5].ex) & (array [num7].ey == array [num5].ey)))) {
								num7 = (short)unchecked(num7 + 1);
							}
							if (num7 > num5 - 1) {
								Section section = CFS.Sections [analysis.Beam [num5].iSct];
								section.CalcStrength (unchecked((short)array [num5].Spec));
								section.MemberCheck (array [num5], ref Check);
								ref Section.StrengthType strength = ref section.Strength;
								if (CFS.IsSpecASD (spec)) {
									string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].P), System.Math.Abs (array [num5].P), Check.Pa, System.Math.Abs (array [0].Vy), System.Math.Abs (array [num5].Vy), strength.Vay, System.Math.Abs (array [0].Vx), System.Math.Abs (array [num5].Vx), strength.Vax) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
									string strFmt5 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].Mx), System.Math.Abs (array [num5].Mx), System.Math.Abs (Check.Mx), Check.Max, System.Math.Abs (array [0].My), System.Math.Abs (array [num5].My), System.Math.Abs (Check.My), Check.May) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
									string strFmt6 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].B), System.Math.Abs (Check.B), strength.Ba) * (double)Units.untBimoment [Units.DefaultUnitIndex [13]].Mult))];
									rtf.SelectedText = strPage + "Section: " + CFSInterface.GetFileName (section.Filename) + "\r\n";
									rtf.SelectedText = "Material Type: " + Strings.Trim (section.Material.Name) + ", Fy=" + Units.DisplayStress (section.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
									rtf.SelectedText = "Cbx  " + Units.DisplayNone (Check.Cbx, strFmt, 11, 8) + "Cby  " + Units.DisplayNone (Check.Cby, strFmt, 11, 8) + "ex   " + Units.DisplayLen1 (array [num5].ex, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Cmx  " + Units.DisplayNone (array [num5].Cmx, strFmt, 11, 8) + "Cmy  " + Units.DisplayNone (array [num5].Cmy, strFmt, 11, 8) + "ey   " + Units.DisplayLen1 (array [num5].ey, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Braced Flange: " + CFSInterface.DisplayFlange (array [num5].iBrcFlg).PadRight (9);
									rtf.SelectedText = "kφ   " + Units.DisplayForce (array [num5].Kf, 0, blnShowUnit: true, "", 11, 8) + "\r\n";
									rtf.SelectedText = "Red. Factor, R: " + Units.DisplayNone (array [num5].R, "", 0, 8) + "Lm   " + Units.DisplayLength (array [num5].Lm, 0, blnShowUnit: true, strFmt2, 11, 8) + "\r\n" + strPage;
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Loads:           P         Mx         Vy         My         Vx", Interaction.IIf (array [0].Torsion, "         B", "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Strings.Space (8) + text + text2 + text + text2 + text, Interaction.IIf (array [0].Torsion, truePart, "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Total   " + Units.DisplayForce (array [0].P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (array [0].Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (array [0].Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (array [0].My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (array [0].Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (array [0].B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Applied " + Units.DisplayForce (array [num5].P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (Check.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("Strength" + Units.DisplayForce (Check.Pa, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Max, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.Vay, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.May, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.Vax, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (strength.Ba, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"), strPage));
								} else {
									string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].P), System.Math.Abs (array [num5].P), Check.QPn, System.Math.Abs (array [0].Vy), System.Math.Abs (array [num5].Vy), strength.QVny, System.Math.Abs (array [0].Vx), System.Math.Abs (array [num5].Vx), strength.QVnx) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
									string strFmt5 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].Mx), System.Math.Abs (array [num5].Mx), System.Math.Abs (Check.Mx), Check.QMnx, System.Math.Abs (array [0].My), System.Math.Abs (array [num5].My), System.Math.Abs (Check.My), Check.QMny) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
									string strFmt6 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (array [0].B), System.Math.Abs (Check.B), strength.QBn) * (double)Units.untBimoment [Units.DefaultUnitIndex [13]].Mult))];
									rtf.SelectedText = strPage + "Section: " + CFSInterface.GetFileName (section.Filename) + "\r\n";
									rtf.SelectedText = "Material Type: " + Strings.Trim (section.Material.Name) + ", Fy=" + Units.DisplayStress (section.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
									rtf.SelectedText = "Cbx  " + Units.DisplayNone (Check.Cbx, strFmt, 11, 8) + "Cby  " + Units.DisplayNone (Check.Cby, strFmt, 11, 8) + "ex   " + Units.DisplayLen1 (array [num5].ex, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Cmx  " + Units.DisplayNone (array [num5].Cmx, strFmt, 11, 8) + "Cmy  " + Units.DisplayNone (array [num5].Cmy, strFmt, 11, 8) + "ey   " + Units.DisplayLen1 (array [num5].ey, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Braced Flange: " + CFSInterface.DisplayFlange (array [num5].iBrcFlg).PadRight (9);
									rtf.SelectedText = "kφ   " + Units.DisplayForce (array [num5].Kf, 0, blnShowUnit: true, "", 11, 8) + "\r\n";
									rtf.SelectedText = "Red. Factor, R: " + Units.DisplayNone (array [num5].R, "", 0, 8) + "Lm   " + Units.DisplayLength (array [num5].Lm, 0, blnShowUnit: true, strFmt2, 11, 8) + "\r\n" + strPage;
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Loads:           P         Mx         Vy         My         Vx", Interaction.IIf (array [0].Torsion, "         B", "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Strings.Space (8) + text + text2 + text + text2 + text, Interaction.IIf (array [0].Torsion, truePart, "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Total   " + Units.DisplayForce (array [0].P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (array [0].Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (array [0].Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (array [0].My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (array [0].Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (array [0].B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Applied " + Units.DisplayForce (array [num5].P, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vy, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.My, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (Check.Vx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (Check.B, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"));
									rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("Strength" + Units.DisplayForce (Check.QPn, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.QMnx, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.QVny, 0, blnShowUnit: false, strFmt4, 11, 0) + Units.DisplayMoment (Check.QMny, 0, blnShowUnit: false, strFmt5, 11, 0) + Units.DisplayForce (strength.QVnx, 0, blnShowUnit: false, strFmt4, 11, 0), Interaction.IIf (array [0].Torsion, Units.DisplayBimoment (strength.QBn, 0, blnShowUnit: false, strFmt6, 11, 0), "")), "\r\n"), strPage));
								}
								rtf.SelectedText = "Interaction Equations\r\n";
								short num8 = 1;
								do {
									if (Strings.Len (Check.EqText [num8]) != 0) {
										short num9 = (short)Strings.InStr (Check.EqText [num8], ">");
										if (num9 > 0) {
											rtf.SelectedText = Strings.Left (Check.EqText [num8], num9 - 1);
											rtf.SelectionColor = Color.Red;
											rtf.SelectedText = Strings.Mid (Check.EqText [num8], num9) + "\r\n";
											rtf.SelectionColor = Color.Black;
										} else {
											rtf.SelectedText = Check.EqText [num8] + "\r\n";
										}
									}
									num8 = (short)unchecked(num8 + 1);
								} while (num8 <= 5);
								if (Strings.Len (Check.Msg) != 0) {
									rtf.SelectedText = strPage + Check.Msg;
								}
								int nPart = section.nPart;
								for (int i = 1; i <= nPart; i++) {
									if (System.Math.Abs (Check.VFy [i]) > num10) {
										num10 = System.Math.Abs (Check.VFy [i]);
									}
									if (System.Math.Abs (Check.VFx [i]) > num10) {
										num10 = System.Math.Abs (Check.VFx [i]);
									}
								}
								if (unchecked(section.nPart > 1 && (double)num10 > 0.001)) {
									string strFmt7 = Units.Fmt [Units.FmtIndex (num10 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult)];
									rtf.SelectedText = strPage + "Shear flow between parts due to:  Vertical Shear    Horizontal Shear\r\n";
									int nPart2 = section.nPart;
									for (int j = 1; j <= nPart2; j++) {
										string text4 = "Part " + Conversions.ToString (j) + ": " + section.Part [j].Name;
										if (section.nPart == 2) {
											text4 = "Between parts 1 and 2";
											j = 2;
										}
										rtf.SelectedText = text4.PadRight (31) + Units.DisplayLoad (System.Math.Abs (Check.VFy [j]), 0, blnShowUnit: true, strFmt7, 11, 9) + Units.DisplayLoad (System.Math.Abs (Check.VFx [j]), 0, blnShowUnit: true, strFmt7, 11, 0) + "\r\n";
									}
								}
								if (CFS.blnTraceMemberChk & (Strings.Len (CFS.strTrace) > 0)) {
									rtf.SelectedText = strPage;
									rptTitle (rtf, "Calculation Details - " + text3);
									rptTrace (rtf, CFS.strTrace);
								}
							}
						}
					}
				}
			}
			analysis = null;
		}
	}

	public static bool rptProperties (RichTextBox rtf, Section Section1)
	{
		bool result = false;
		string strMsg = Section1.CheckBasicSection ();
		if (strMsg.Length > 0) {
			CFS.LicenseRequired (strMsg);
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcProperties (ref strMsg);
			Cursor.Current = Cursors.Default;
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (Section1.SctProp) {
				rtf.Rtf = string.Empty;
				ref Section.PropertiesType prop = ref Section1.Prop;
				string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (Section1.Ymax - prop.Ycg, prop.Ycg - Section1.Ymin, Section1.Xmax - prop.Xcg, prop.Xcg - Section1.Xmin, prop.Ro, System.Math.Abs (prop.jx), System.Math.Abs (prop.jy)) * (double)Units.untLength [Units.DefaultUnitIndex [1]].Mult))];
				string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.Sxt, prop.Sxb, prop.Syl, prop.Syr, prop.Zx, prop.Zy) * (double)Units.untLen3 [Units.DefaultUnitIndex [8]].Mult))];
				string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.Io, prop.J) * (double)Units.untLen4 [Units.DefaultUnitIndex [9]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, "Full Section Properties");
				rtf.SelectedText = "Area " + Units.DisplayLen2 (prop.A, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (prop.A * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)], 11, 8) + "Wt.  " + Units.DisplayLoad (prop.Weight, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (prop.Weight * Units.untLoad [Units.DefaultUnitIndex [11]].Mult)], 11, 8) + "Flat " + Units.DisplayLen1 (prop.FlatWidth, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (prop.FlatWidth * Units.untLength [Units.DefaultUnitIndex [1]].Mult)], 11, 0) + "\r\n" + strPage;
				rtf.SelectedText = "Ix   " + Units.DisplayLen4 (prop.Ix, 0, blnShowUnit: true, strFmt3, 11, 8) + "rx   " + Units.DisplayLen1 (prop.Rx, 0, blnShowUnit: true, strFmt, 11, 8) + "Ixy  " + Units.DisplayLen4 (prop.Ixy, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "Sx(t)" + Units.DisplayLen3 (prop.Sxt, 0, blnShowUnit: true, strFmt2, 11, 8) + "y(t) " + Units.DisplayLen1 (Section1.Ymax - prop.Ycg, 0, blnShowUnit: true, strFmt, 11, 8) + "α    " + Units.DisplayAngle (prop.Alpha, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(System.Math.PI / 2.0 * (double)Units.untAngle [Units.DefaultUnitIndex [3]].Mult))], 11, 0) + "\r\n";
				rtf.SelectedText = "Sx(b)" + Units.DisplayLen3 (prop.Sxb, 0, blnShowUnit: true, strFmt2, 11, 8) + "y(b) " + Units.DisplayLen1 (prop.Ycg - Section1.Ymin, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Zx   " + Units.DisplayLen3 (prop.Zx, 0, blnShowUnit: true, strFmt2, 11, 7) + "Height" + Units.DisplayLen1 (Section1.Ymax - Section1.Ymin, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n" + strPage;
				rtf.SelectedText = "Iy   " + Units.DisplayLen4 (prop.Iy, 0, blnShowUnit: true, strFmt3, 11, 8) + "ry   " + Units.DisplayLen1 (prop.Ry, 0, blnShowUnit: true, strFmt, 11, 8) + "x₀   " + Units.DisplayLen1 (prop.Xo, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Sy(l)" + Units.DisplayLen3 (prop.Syl, 0, blnShowUnit: true, strFmt2, 11, 8) + "x(l) " + Units.DisplayLen1 (prop.Xcg - Section1.Xmin, 0, blnShowUnit: true, strFmt, 11, 8) + "y₀   " + Units.DisplayLen1 (prop.Yo, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Sy(r)" + Units.DisplayLen3 (prop.Syr, 0, blnShowUnit: true, strFmt2, 11, 8) + "x(r) " + Units.DisplayLen1 (Section1.Xmax - prop.Xcg, 0, blnShowUnit: true, strFmt, 11, 8) + "jx   " + Units.DisplayLen1 (prop.jx, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "Zy   " + Units.DisplayLen3 (prop.Zy, 0, blnShowUnit: true, strFmt2, 11, 7) + "Width " + Units.DisplayLen1 (Section1.Xmax - Section1.Xmin, 0, blnShowUnit: true, strFmt, 11, 8) + "jy   " + Units.DisplayLen1 (prop.jy, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n" + strPage;
				rtf.SelectedText = "I₁   " + Units.DisplayLen4 (prop.I1, 0, blnShowUnit: true, strFmt3, 11, 8) + "r₁   " + Units.DisplayLen1 (prop.R1, 0, blnShowUnit: true, strFmt, 11, 8) + "Cw   " + Units.DisplayLen6 (prop.Cw, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.Cw, prop.J * prop.Ro * prop.Ro) * (double)Units.untLen6 [Units.DefaultUnitIndex [10]].Mult))], 11, 0) + "\r\n";
				rtf.SelectedText = "I₂   " + Units.DisplayLen4 (prop.I2, 0, blnShowUnit: true, strFmt3, 11, 8) + "r₂   " + Units.DisplayLen1 (prop.R2, 0, blnShowUnit: true, strFmt, 11, 8) + "J    " + Units.DisplayLen4 (prop.J, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.J, prop.Cw / (100f * prop.Ro * prop.Ro)) * (double)Units.untLen4 [Units.DefaultUnitIndex [9]].Mult))], 11, 0) + "\r\n";
				rtf.SelectedText = "Ic   " + Units.DisplayLen4 (prop.Ic, 0, blnShowUnit: true, strFmt3, 11, 8) + "rc   " + Units.DisplayLen1 (prop.Rc, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = "I₀   " + Units.DisplayLen4 (prop.Io, 0, blnShowUnit: true, strFmt3, 11, 8) + "r₀   " + Units.DisplayLen1 (prop.Ro, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				if (prop.An < prop.A) {
					rtf.SelectedText = strPage;
					rptTitle (rtf, "Net Section Properties");
					rtf.SelectedText = "Ix   " + Units.DisplayLen4 (prop.Ixn, 0, blnShowUnit: true, strFmt3, 11, 8) + "rx   " + Units.DisplayLen1 (prop.Rxn, 0, blnShowUnit: true, strFmt, 11, 8) + "Area " + Units.DisplayLen2 (prop.An, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (prop.An * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)], 11, 0) + "\r\n";
					rtf.SelectedText = "Sx(t)" + Units.DisplayLen3 (prop.Sxtn, 0, blnShowUnit: true, strFmt2, 11, 8) + "y(t) " + Units.DisplayLen1 (Section1.Ymax - prop.Ycgn, 0, blnShowUnit: true, strFmt, 11, 8) + "Ixy  " + Units.DisplayLen4 (prop.Ixyn, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
					rtf.SelectedText = "Sx(b)" + Units.DisplayLen3 (prop.Sxbn, 0, blnShowUnit: true, strFmt2, 11, 8) + "y(b) " + Units.DisplayLen1 (prop.Ycgn - Section1.Ymin, 0, blnShowUnit: true, strFmt, 11, 8) + "α    " + Units.DisplayAngle (prop.Alphan, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(System.Math.PI / 2.0 * (double)Units.untAngle [Units.DefaultUnitIndex [3]].Mult))], 11, 0) + "\r\n";
					rtf.SelectedText = "Zx   " + Units.DisplayLen3 (prop.Zxn, 0, blnShowUnit: true, strFmt2, 11, 8) + "\r\n" + strPage;
					rtf.SelectedText = "Iy   " + Units.DisplayLen4 (prop.Iyn, 0, blnShowUnit: true, strFmt3, 11, 8) + "ry   " + Units.DisplayLen1 (prop.Ryn, 0, blnShowUnit: true, strFmt, 11, 8) + "x₀   " + Units.DisplayLen1 (prop.Xon, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
					rtf.SelectedText = "Sy(l)" + Units.DisplayLen3 (prop.Syln, 0, blnShowUnit: true, strFmt2, 11, 8) + "x(l) " + Units.DisplayLen1 (prop.Xcgn - Section1.Xmin, 0, blnShowUnit: true, strFmt, 11, 8) + "y₀   " + Units.DisplayLen1 (prop.Yon, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
					rtf.SelectedText = "Sy(r)" + Units.DisplayLen3 (prop.Syrn, 0, blnShowUnit: true, strFmt2, 11, 8) + "x(r) " + Units.DisplayLen1 (Section1.Xmax - prop.Xcgn, 0, blnShowUnit: true, strFmt, 11, 8) + "jx   " + Units.DisplayLen1 (prop.jxn, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
					rtf.SelectedText = "Zy   " + Units.DisplayLen3 (prop.Zyn, 0, blnShowUnit: true, strFmt2, 11, 8) + Strings.Space (24) + "jy   " + Units.DisplayLen1 (prop.jyn, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n" + strPage;
					rtf.SelectedText = "Ic   " + Units.DisplayLen4 (prop.Icn, 0, blnShowUnit: true, strFmt3, 11, 8) + "rc   " + Units.DisplayLen1 (prop.Rcn, 0, blnShowUnit: true, strFmt, 11, 8) + "Cw   " + Units.DisplayLen6 (prop.Cwn, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.Cwn, prop.Jn * prop.Ron * prop.Ron) * (double)Units.untLen6 [Units.DefaultUnitIndex [10]].Mult))], 11, 0) + "\r\n";
					rtf.SelectedText = "I₀   " + Units.DisplayLen4 (prop.Ion, 0, blnShowUnit: true, strFmt3, 11, 8) + "r₀   " + Units.DisplayLen1 (prop.Ron, 0, blnShowUnit: true, strFmt, 11, 8) + "J    " + Units.DisplayLen4 (prop.Jn, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(CFS.Max (prop.Jn, prop.Cwn / (100f * prop.Ron * prop.Ron)) * (double)Units.untLen4 [Units.DefaultUnitIndex [9]].Mult))], 11, 0) + "\r\n";
				}
				result = true;
			}
		}
		return result;
	}

	public static bool rptEffProperties (RichTextBox rtf, Section Section1, float P, float Mx, float My, short intSpec)
	{
		bool result = false;
		string strMsg = Section1.CheckBasicSection ();
		if (strMsg.Length > 0) {
			CFS.LicenseRequired (strMsg);
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcProperties (ref strMsg);
			Cursor.Current = Cursors.Default;
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (Section1.SctProp) {
				Section.PropertiesType propertiesType = Section1.CalcEffProperties (P, Mx, My, intSpec);
				float num = propertiesType.Ix / propertiesType.Sxt;
				float sngValue = propertiesType.Ix / propertiesType.Sxb;
				float num2 = propertiesType.Iy / propertiesType.Syr;
				float num3 = propertiesType.Iy / propertiesType.Syl;
				rtf.Rtf = string.Empty;
				string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (num, num, num2, num3) * (double)Units.untLength [Units.DefaultUnitIndex [1]].Mult))];
				string strFmt2 = Units.Fmt [Units.FmtIndex (propertiesType.A * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)];
				string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (propertiesType.Sxt, propertiesType.Sxb, propertiesType.Syl, propertiesType.Syr) * (double)Units.untLen3 [Units.DefaultUnitIndex [8]].Mult))];
				string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (propertiesType.Ix, propertiesType.Iy) * (double)Units.untLen4 [Units.DefaultUnitIndex [9]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Effective Section Properties - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [intSpec], CFS.strSSspec ((Specifications)checked((byte)intSpec))))));
				rtf.SelectedText = "P    " + Units.DisplayForce (P, 0, blnShowUnit: true, "", 11, 8) + "Mx   " + Units.DisplayMoment (Mx, 0, blnShowUnit: true, "", 11, 8) + "My   " + Units.DisplayMoment (My, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
				rtf.SelectedText = "Area " + Units.DisplayLen2 (propertiesType.A, 0, blnShowUnit: true, strFmt2, 11, 8) + "Ix   " + Units.DisplayLen4 (propertiesType.Ix, 0, blnShowUnit: true, strFmt4, 11, 8) + "Iy   " + Units.DisplayLen4 (propertiesType.Iy, 0, blnShowUnit: true, strFmt4, 11, 0) + "\r\n";
				rtf.SelectedText = "Ixy  " + Units.DisplayLen4 (propertiesType.Ixy, 0, blnShowUnit: true, strFmt4, 11, 8) + "Sx(t)" + Units.DisplayLen3 (propertiesType.Sxt, 0, blnShowUnit: true, strFmt3, 11, 8) + "Sy(l)" + Units.DisplayLen3 (propertiesType.Syl, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = "α    " + Units.DisplayAngle (propertiesType.Alpha, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex ((float)(System.Math.PI / 2.0 * (double)Units.untAngle [Units.DefaultUnitIndex [3]].Mult))], 11, 8) + "Sx(b)" + Units.DisplayLen3 (propertiesType.Sxb, 0, blnShowUnit: true, strFmt3, 11, 8) + "Sy(r)" + Units.DisplayLen3 (propertiesType.Syr, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
				rtf.SelectedText = Strings.Space (24) + "y(t) " + Units.DisplayLen1 (num, 0, blnShowUnit: true, strFmt, 11, 8) + "x(l) " + Units.DisplayLen1 (num3, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				rtf.SelectedText = Strings.Space (24) + "y(b) " + Units.DisplayLen1 (sngValue, 0, blnShowUnit: true, strFmt, 11, 8) + "x(r) " + Units.DisplayLen1 (num2, 0, blnShowUnit: true, strFmt, 11, 0) + "\r\n";
				if (CFS.blnTraceEffProp & (Strings.Len (CFS.strTrace) > 0)) {
					rtf.SelectedText = strPage;
					rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Calculation Details - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [intSpec], CFS.strSSspec ((Specifications)checked((byte)intSpec))))));
					rptTrace (rtf, CFS.strTrace);
				}
				result = true;
			}
		}
		return result;
	}

	public static void rptSctInp (RichTextBox rtf, Section Section1)
	{
		Section section = Section1;
		string text = "(" + Units.untStress [Units.DefaultUnitIndex [5]].Name + ")";
		string text2 = "(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")";
		string text3 = "(" + Units.untAngle [Units.DefaultUnitIndex [3]].Name + ")";
		rtf.Font = BodyFont;
		rtf.SelectionStart = Strings.Len (rtf.Text);
		rptTitle (rtf, "Section Inputs");
		if (section.Material.IsCarbon ()) {
			rtf.SelectedText = "Material: " + Strings.Trim (section.Material.Name) + "\r\n";
			if (section.ColdWork) {
				rtf.SelectedText = "Apply ";
			} else {
				rtf.SelectedText = "No ";
			}
			rtf.SelectedText = "cold work of forming strength increase.\r\n";
			if (section.Reserve) {
				rtf.SelectedText = "Apply ";
			} else {
				rtf.SelectedText = "No ";
			}
			rtf.SelectedText = "inelastic reserve strength increase.\r\n";
			rtf.SelectedText = "Modulus of Elasticity, E     " + Units.DisplayStress (section.Material.Eo [2], 0, blnShowUnit: true, "", 11, 0) + "\r\n";
			rtf.SelectedText = "Yield Strength, Fy           " + Units.DisplayStress (section.Material.Fy [2], 0, blnShowUnit: true, "", 11, 0) + "\r\n";
			rtf.SelectedText = "Tensile Strength, Fu         " + Units.DisplayStress (section.Material.Fu, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
			rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("Min Elongation in ", Interaction.IIf (Units.DefaultUnitIndex [1] <= 2, "2 inches", "50 mm   ")), "   "), Units.DisplayNone (section.Elongation (), "", 11, 0)), " %"), "\r\n"));
		} else {
			string text4 = string.Empty;
			if (section.Material.IsAustenitic ()) {
				text4 = "  (Austenitic)";
			}
			if (section.Material.IsFerritic ()) {
				text4 = "  (Ferritic)";
			}
			if (section.Material.IsDuplex ()) {
				text4 = "  (Duplex)";
			}
			rtf.SelectedText = section.Material.Name + Strings.Space (9) + "Modulus  Yield Strength  Ramberg-Osgood\r\n";
			rtf.SelectedText = text4.PadRight (24) + ("Eo " + text).PadLeft (16) + ("Fy " + text).PadLeft (16) + "  Coefficient, n\r\n";
			rtf.SelectedText = "Longitudinal Tension    " + Units.DisplayStress (section.Material.Eo [1], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.Fy [1], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.N [1], 0, blnShowUnit: false, "", 16, 0) + "\r\n";
			rtf.SelectedText = "Longitudinal Compression" + Units.DisplayStress (section.Material.Eo [2], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.Fy [2], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.N [2], 0, blnShowUnit: false, "", 16, 0) + "\r\n";
			rtf.SelectedText = "Transverse Tension      " + Units.DisplayStress (section.Material.Eo [3], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.Fy [3], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.N [3], 0, blnShowUnit: false, "", 16, 0) + "\r\n";
			rtf.SelectedText = "Transverse Compression  " + Units.DisplayStress (section.Material.Eo [4], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.Fy [4], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.N [4], 0, blnShowUnit: false, "", 16, 0) + "\r\n";
			rtf.SelectedText = "Shear                   " + Units.DisplayStress (section.Material.Eo [5], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.Fy [5], 0, blnShowUnit: false, "", 16, 0) + Units.DisplayStress (section.Material.N [5], 0, blnShowUnit: false, "", 16, 0) + "\r\n";
			rtf.SelectedText = "Tensile Strength, Fu         " + Units.DisplayStress (section.Material.Fu, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
		}
		rtf.SelectedText = "Torsion Constant Override, J " + Units.DisplayLen4 (section.JOverride, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
		rtf.SelectedText = "Warping Constant Override, Cw" + Units.DisplayLen6 (section.CwOverride, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
		if (section.nPart > 1) {
			rtf.SelectedText = "Connector Spacing            " + Units.DisplayLen1 (section.ConnSpacing, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
		}
		float num = 0f;
		short nPart = section.nPart;
		checked {
			for (short num2 = 1; num2 <= nPart; num2 = (short)unchecked(num2 + 1)) {
				short nElem = section.Part [num2].nElem;
				for (short num3 = 1; num3 <= nElem; num3 = (short)unchecked(num3 + 1)) {
					num += section.Part [num2].Element [num3].Hole;
				}
			}
			if (num > 0f) {
				rtf.SelectedText = "Hole Length                  " + Units.DisplayNone (section.HoleLength, "", 11, 0) + "\r\n";
				rtf.SelectedText = "Hole Spacing                 " + Units.DisplayNone (section.HoleSpacing, "", 11, 0) + "\r\n";
			}
			short nPart2 = section.nPart;
			for (short num2 = 1; num2 <= nPart2; num2 = (short)unchecked(num2 + 1)) {
				rtf.SelectedText = strPage;
				Part part = section.Part [num2];
				rtf.SelectedText = part.Name + ", Thickness " + Units.DisplayLen1 (part.Thickness, 0, blnShowUnit: true, "", 0, 0);
				if (part.ThicknessIndex != -1) {
					rtf.SelectedText = " (" + CFS.Thicknesses [part.ThicknessIndex].Name + ")";
				}
				rtf.SelectedText = "\r\n";
				rtf.SelectedText = "Placement of Part from Origin:\r\n";
				switch (part.iXPosition) {
				case 0:
					rtf.SelectedText = "X to left edge         " + Units.DisplayLen1 (part.XPosition - part.Xleft, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				case 1:
					rtf.SelectedText = "X to center of gravity " + Units.DisplayLen1 (part.XPosition, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				case 2:
					rtf.SelectedText = "X to right edge        " + Units.DisplayLen1 (part.XPosition + part.Xright, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				}
				switch (part.iYPosition) {
				case 0:
					rtf.SelectedText = "Y to top edge          " + Units.DisplayLen1 (part.YPosition + part.Ytop, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				case 1:
					rtf.SelectedText = "Y to center of gravity " + Units.DisplayLen1 (part.YPosition, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				case 2:
					rtf.SelectedText = "Y to bottom edge       " + Units.DisplayLen1 (part.YPosition - part.Ybottom, 0, blnShowUnit: true, "", 11, 0) + "\r\n";
					break;
				}
				if (part.Centerline) {
					rtf.SelectedText = "Centerline dimensions, ";
				} else {
					rtf.SelectedText = "Outside dimensions, ";
				}
				if (part.Closed) {
					rtf.SelectedText = "Closed shape\r\n";
				} else {
					rtf.SelectedText = "Open shape\r\n";
				}
				if (part.nElem > 0) {
					float num4 = 0f;
					float num5 = 0f;
					short nElem2 = part.nElem;
					for (short num3 = 1; num3 <= nElem2; num3 = (short)unchecked(num3 + 1)) {
						if (part.Element [num3].Len > num4) {
							num4 = part.Element [num3].Len;
						}
						if (part.Element [num3].Rad > num5) {
							num5 = part.Element [num3].Rad;
						}
					}
					string strFmt = Units.Fmt [Units.FmtIndex (num4 * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
					string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(System.Math.PI / 2.0 * (double)Units.untAngle [Units.DefaultUnitIndex [3]].Mult))];
					string strFmt3 = Units.Fmt [Units.FmtIndex (num5 * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
					string strFmt4 = Units.Fmt [Units.FmtIndex (24f)];
					rtf.SelectedText = "        Length      Angle     Radius  Web      k    Hole Size   Distance\r\n";
					rtf.SelectedText = Strings.Space (3) + text2.PadLeft (11) + text3.PadLeft (11) + text2.PadLeft (11) + "         Coef." + text2.PadLeft (11) + text2.PadLeft (11) + "\r\n";
					short nElem3 = part.nElem;
					for (short num3 = 1; num3 <= nElem3; num3 = (short)unchecked(num3 + 1)) {
						rtf.SelectedText = unchecked(Conversions.ToString ((int)num3).PadLeft (3) + Units.DisplayLen1 (part.Element [num3].Len, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayAngle (part.Element [num3].Ang, 0, blnShowUnit: false, strFmt2, 11, 0) + Units.DisplayLen1 (part.Element [num3].Rad, 0, blnShowUnit: false, strFmt3, 11, 0) + Strings.Space (1) + CFSInterface.DisplayWeb ((WebTypes)part.Element [num3].Web).PadRight (6)) + Units.DisplayNone (part.Element [num3].K, strFmt4, 7, 0) + Units.DisplayLen1 (part.Element [num3].Hole, 0, blnShowUnit: false, strFmt, 11, 0) + Units.DisplayLen1 (part.Element [num3].Dist, 0, blnShowUnit: false, strFmt, 11, 0) + "\r\n";
					}
				}
				part = null;
			}
			if (section.DSM.UseDSM & !section.DSM.IsAllZero ()) {
				string strFmt5 = Units.Fmt [9];
				rtf.SelectedText = strPage;
				rtf.SelectedText = "Direct Strength Parameters\r\n";
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Prequalified Section: ", Interaction.IIf (section.DSM.PreQualified, "Yes", "No")), "\r\n"));
				rtf.SelectedText = "  Compression: Pcrl/Py =" + Units.DisplayNone (section.DSM.Pcrl, strFmt5, 9, 0) + "  Pcrd/Py =" + Units.DisplayNone (section.DSM.Pcrd, strFmt5, 9, 0) + "\r\n";
				rtf.SelectedText = "  Positive Mx: Mcrl/My =" + Units.DisplayNone (section.DSM.Mcrlxp, strFmt5, 9, 0) + "  Mcrd/My =" + Units.DisplayNone (section.DSM.Mcrdxp, strFmt5, 9, 0) + "\r\n";
				rtf.SelectedText = "  Negative Mx: Mcrl/My =" + Units.DisplayNone (section.DSM.Mcrlxn, strFmt5, 9, 0) + "  Mcrd/My =" + Units.DisplayNone (section.DSM.Mcrdxn, strFmt5, 9, 0) + "\r\n";
				rtf.SelectedText = "  Positive My: Mcrl/My =" + Units.DisplayNone (section.DSM.Mcrlyp, strFmt5, 9, 0) + "  Mcrd/My =" + Units.DisplayNone (section.DSM.Mcrdyp, strFmt5, 9, 0) + "\r\n";
				rtf.SelectedText = "  Negative My: Mcrl/My =" + Units.DisplayNone (section.DSM.Mcrlyn, strFmt5, 9, 0) + "  Mcrd/My =" + Units.DisplayNone (section.DSM.Mcrdyn, strFmt5, 9, 0) + "\r\n";
				rtf.SelectedText = "  Shear:      Vcr/Vy(y)=" + Units.DisplayNone (section.DSM.Vcry, strFmt5, 9, 0) + " Vcr/Vy(x)=" + Units.DisplayNone (section.DSM.Vcrx, strFmt5, 9, 0) + "\r\n";
			}
			section = null;
		}
	}

	public static bool rptStrength (RichTextBox rtf, Section Section1, short intSpec)
	{
		bool result = false;
		string strMsg = Section1.CheckBasicSection ();
		if (strMsg.Length > 0) {
			CFS.LicenseRequired (strMsg);
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcProperties (ref strMsg);
			Cursor.Current = Cursors.Default;
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (Section1.SctProp) {
				Cursor.Current = Cursors.WaitCursor;
				Section1.CalcStrength (intSpec);
				Cursor.Current = Cursors.Default;
				rtf.Rtf = string.Empty;
				ref Section.StrengthType strength = ref Section1.Strength;
				string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.Sxtep, strength.Sylep, strength.Sxbep, strength.Syrep, strength.Sxten, strength.Sylen, strength.Sxben, strength.Syren) * (double)Units.untLen3 [Units.DefaultUnitIndex [8]].Mult))];
				string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.Ixep, strength.Iyep, strength.Ixen, strength.Iyen) * (double)Units.untLen4 [Units.DefaultUnitIndex [9]].Mult))];
				if (CFS.IsSpecASD (intSpec)) {
					string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.Pao, strength.Ta, strength.Vay, strength.Vax) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
					string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.Maxop, strength.Mayop, strength.Maxon, strength.Mayon) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
					rtf.SelectionStart = Strings.Len (rtf.Text);
					rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Fully Braced Strength - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [intSpec], CFS.strSSspec ((Specifications)checked((byte)intSpec))))));
					rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					rtf.SelectedText = "Axial                     Positive Bending          Positive Bending\r\n";
					rtf.SelectedText = "Pao  " + Units.DisplayForce (strength.Pao, 0, blnShowUnit: true, strFmt3, 11, 10) + "Maxo " + Units.DisplayMoment (strength.Maxop, 0, blnShowUnit: true, strFmt4, 11, 10) + "Mayo " + Units.DisplayMoment (strength.Mayop, 0, blnShowUnit: true, strFmt4, 11, 0) + "\r\n";
					rtf.SelectedText = "Ae   " + Units.DisplayLen2 (strength.Ae, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (strength.Ae * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)], 11, 10) + "Ixe  " + Units.DisplayLen4 (strength.Ixep, 0, blnShowUnit: true, strFmt2, 11, 10) + "Iye  " + Units.DisplayLen4 (strength.Iyep, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					rtf.SelectedText = "Ta   " + Units.DisplayForce (strength.Ta, 0, blnShowUnit: true, strFmt3, 11, 10) + "Sxe(t)" + Units.DisplayLen3 (strength.Sxtep, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(l)" + Units.DisplayLen3 (strength.Sylep, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = Strings.Space (26) + "Sxe(b)" + Units.DisplayLen3 (strength.Sxbep, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(r)" + Units.DisplayLen3 (strength.Syrep, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = "Shear\r\n";
					rtf.SelectedText = "Vay  " + Units.DisplayForce (strength.Vay, 0, blnShowUnit: true, strFmt3, 11, 10) + "Negative Bending          Negative Bending\r\n";
					rtf.SelectedText = "Vax  " + Units.DisplayForce (strength.Vax, 0, blnShowUnit: true, strFmt3, 11, 10) + "Maxo " + Units.DisplayMoment (strength.Maxon, 0, blnShowUnit: true, strFmt4, 11, 10) + "Mayo " + Units.DisplayMoment (strength.Mayon, 0, blnShowUnit: true, strFmt4, 11, 0) + "\r\n";
					rtf.SelectedText = Strings.Space (26) + "Ixe  " + Units.DisplayLen4 (strength.Ixen, 0, blnShowUnit: true, strFmt2, 11, 10) + "Iye  " + Units.DisplayLen4 (strength.Iyen, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					rtf.SelectedText = "Torsion" + Strings.Space (19) + "Sxe(t)" + Units.DisplayLen3 (strength.Sxten, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(l)" + Units.DisplayLen3 (strength.Sylen, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = "Ba   " + Units.DisplayBimoment (strength.Ba, 0, blnShowUnit: true, "", 11, 10) + "Sxe(b)" + Units.DisplayLen3 (strength.Sxben, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(r)" + Units.DisplayLen3 (strength.Syren, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
				} else {
					string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.QPno, strength.QTn, strength.QVny, strength.QVnx) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
					string strFmt4 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (strength.QMnxop, strength.QMnyop, strength.QMnxon, strength.QMnyon) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
					rtf.SelectionStart = Strings.Len (rtf.Text);
					rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Fully Braced Strength - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [intSpec], CFS.strSSspec ((Specifications)checked((byte)intSpec))))));
					rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					rtf.SelectedText = "Axial                     Positive Bending          Positive Bending\r\n";
					rtf.SelectedText = "φPno " + Units.DisplayForce (strength.QPno, 0, blnShowUnit: true, strFmt3, 11, 10) + "φMnxo" + Units.DisplayMoment (strength.QMnxop, 0, blnShowUnit: true, strFmt4, 11, 10) + "φMnyo" + Units.DisplayMoment (strength.QMnyop, 0, blnShowUnit: true, strFmt4, 11, 0) + "\r\n";
					rtf.SelectedText = "Ae   " + Units.DisplayLen2 (strength.Ae, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (strength.Ae * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)], 11, 10) + "Ixe  " + Units.DisplayLen4 (strength.Ixep, 0, blnShowUnit: true, strFmt2, 11, 10) + "Iye  " + Units.DisplayLen4 (strength.Iyep, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					rtf.SelectedText = "φTn  " + Units.DisplayForce (strength.QTn, 0, blnShowUnit: true, strFmt3, 11, 10) + "Sxe(t)" + Units.DisplayLen3 (strength.Sxtep, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(l)" + Units.DisplayLen3 (strength.Sylep, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = Strings.Space (26) + "Sxe(b)" + Units.DisplayLen3 (strength.Sxbep, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(r)" + Units.DisplayLen3 (strength.Syrep, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = "Shear\r\n";
					rtf.SelectedText = "φVny " + Units.DisplayForce (strength.QVny, 0, blnShowUnit: true, strFmt3, 11, 10) + "Negative Bending          Negative Bending\r\n";
					rtf.SelectedText = "φVnx " + Units.DisplayForce (strength.QVnx, 0, blnShowUnit: true, strFmt3, 11, 10) + "φMnxo" + Units.DisplayMoment (strength.QMnxon, 0, blnShowUnit: true, strFmt4, 11, 10) + "φMnyo" + Units.DisplayMoment (strength.QMnyon, 0, blnShowUnit: true, strFmt4, 11, 0) + "\r\n";
					rtf.SelectedText = Strings.Space (26) + "Ixe  " + Units.DisplayLen4 (strength.Ixen, 0, blnShowUnit: true, strFmt2, 11, 10) + "Iye  " + Units.DisplayLen4 (strength.Iyen, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					rtf.SelectedText = "Torsion" + Strings.Space (19) + "Sxe(t)" + Units.DisplayLen3 (strength.Sxten, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(l)" + Units.DisplayLen3 (strength.Sylen, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
					rtf.SelectedText = "φBn  " + Units.DisplayBimoment (strength.QBn, 0, blnShowUnit: true, "", 11, 10) + "Sxe(b)" + Units.DisplayLen3 (strength.Sxben, 0, blnShowUnit: true, strFmt, 10, 10) + "Sye(r)" + Units.DisplayLen3 (strength.Syren, 0, blnShowUnit: true, strFmt, 10, 0) + "\r\n";
				}
				if (Strings.Len (strength.Msg) != 0) {
					rtf.SelectedText = "\r\n" + strength.Msg;
				}
				if (CFS.blnTraceStrength & (Strings.Len (CFS.strTrace) > 0)) {
					rtf.SelectedText = strPage;
					rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Calculation Details - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [intSpec], CFS.strSSspec ((Specifications)checked((byte)intSpec))))));
					rptTrace (rtf, CFS.strTrace);
				}
				result = true;
			}
		}
		return result;
	}

	public static bool rptTorsionProp (RichTextBox rtf, Section Section1)
	{
		string strMsg = string.Empty;
		bool result = false;
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			CFS.LicenseRequired ("This calculation requires a full CFS license.");
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcProperties (ref strMsg);
			Cursor.Current = Cursors.Default;
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (Section1.SctProp) {
				TorsionData[] tPg = Section1.Part [1].TPg;
				float num = (float)CFS.Max (Section1.Part [1].Xo, Section1.Part [1].Yo);
				int num2 = Information.UBound (tPg);
				float num3 = default(float);
				float num4 = default(float);
				for (int i = 1; i <= num2; i = checked(i + 1)) {
					if (System.Math.Abs (tPg [i].Loc) > num) {
						num = System.Math.Abs (tPg [i].Loc);
					}
					if (System.Math.Abs (tPg [i].Ro) > num) {
						num = System.Math.Abs (tPg [i].Ro);
					}
					if (System.Math.Abs (tPg [i].Wn) > num3) {
						num3 = System.Math.Abs (tPg [i].Wn);
					}
					if (System.Math.Abs (tPg [i].Sw) > num4) {
						num4 = System.Math.Abs (tPg [i].Sw);
					}
				}
				string strFmt = Units.Fmt [Units.FmtIndex (num * Units.untLength [Units.DefaultUnitIndex [1]].Mult)];
				string strFmt2 = Units.Fmt [Units.FmtIndex (num3 * Units.untLen2 [Units.DefaultUnitIndex [7]].Mult)];
				string strFmt3 = Units.Fmt [Units.FmtIndex (num4 * Units.untLen4 [Units.DefaultUnitIndex [9]].Mult)];
				rtf.Rtf = string.Empty;
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, "Torsion Properties");
				rtf.SelectedText = "Elem" + CFS.Pad ("Location", 12) + CFS.Pad ("Ro", 12) + CFS.Pad ("Wn", 12) + CFS.Pad ("Sw", 12) + "\r\n";
				rtf.SelectedText = Strings.Space (4) + CFS.Pad ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")", 12) + CFS.Pad ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")", 12) + CFS.Pad ("(" + Units.untLen2 [Units.DefaultUnitIndex [7]].Name + ")", 12) + CFS.Pad ("(" + Units.untLen4 [Units.DefaultUnitIndex [9]].Name + ")", 12) + "\r\n";
				int num5 = Information.UBound (tPg);
				for (int j = 1; j <= num5; j = checked(j + 1)) {
					rtf.SelectedText = Conversions.ToString ((int)tPg [j].iElem).PadLeft (3) + " ";
					rtf.SelectedText = Units.DisplayLen1 (tPg [j].Loc, 0, blnShowUnit: false, strFmt, 12, 0);
					rtf.SelectedText = Units.DisplayLen1 (tPg [j].Ro, 0, blnShowUnit: false, strFmt, 12, 0);
					rtf.SelectedText = Units.DisplayLen2 (tPg [j].Wn, 0, blnShowUnit: false, strFmt2, 12, 0);
					rtf.SelectedText = Units.DisplayLen4 (tPg [j].Sw, 0, blnShowUnit: false, strFmt3, 12, 0) + "\r\n";
				}
				rtf.SelectedText = strPage;
				rtf.SelectionFont = TextFont;
				rtf.SelectedText = "Ro = Perpendicular distance from shear center to centerline of element.\r\n";
				rtf.SelectionFont = TextFont;
				rtf.SelectedText = "Wn = Normalized unit warping, used for warping longitudinal stress.\r\n";
				rtf.SelectionFont = TextFont;
				rtf.SelectedText = "Sw = Warping statical moment, used for warping shear stress.\r\n\r\n";
				Part part = Section1.Part [1];
				rtf.SelectionFont = BodyFont;
				rtf.SelectedText = "x₀ =" + Units.DisplayLen1 (part.Xo, 0, blnShowUnit: true, strFmt, 12, 8) + "Cw =" + Units.DisplayLen6 (part.Cw, 0, blnShowUnit: true, "", 12, 8) + "\r\n";
				rtf.SelectedText = "y₀ =" + Units.DisplayLen1 (part.Yo, 0, blnShowUnit: true, strFmt, 12, 8) + "J  =" + Units.DisplayLen4 (part.J, 0, blnShowUnit: true, "", 12, 8) + "\r\n";
				part = null;
				if (Section1.Prop.An < Section1.Prop.A) {
					tPg = Section1.Part [1].TPn;
					rtf.SelectedText = strPage;
					rptTitle (rtf, "Torsion Properties - Net Section");
					rtf.SelectedText = "Elem" + CFS.Pad ("Location", 12) + CFS.Pad ("Ro", 12) + CFS.Pad ("Wn", 12) + CFS.Pad ("Sw", 12) + "\r\n";
					rtf.SelectedText = Strings.Space (4) + CFS.Pad ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")", 12) + CFS.Pad ("(" + Units.untLength [Units.DefaultUnitIndex [1]].Name + ")", 12) + CFS.Pad ("(" + Units.untLen2 [Units.DefaultUnitIndex [7]].Name + ")", 12) + CFS.Pad ("(" + Units.untLen4 [Units.DefaultUnitIndex [9]].Name + ")", 12) + "\r\n";
					int num6 = Information.UBound (tPg);
					for (int k = 1; k <= num6; k = checked(k + 1)) {
						rtf.SelectedText = Conversions.ToString ((int)Conversion.Int (tPg [k].iElem)).PadLeft (3) + " ";
						rtf.SelectedText = Units.DisplayLen1 (tPg [k].Loc, 0, blnShowUnit: false, strFmt, 12, 0);
						rtf.SelectedText = Units.DisplayLen1 (tPg [k].Ro, 0, blnShowUnit: false, strFmt, 12, 0);
						rtf.SelectedText = Units.DisplayLen2 (tPg [k].Wn, 0, blnShowUnit: false, strFmt2, 12, 0);
						rtf.SelectedText = Units.DisplayLen4 (tPg [k].Sw, 0, blnShowUnit: false, strFmt3, 12, 0) + "\r\n";
					}
					rtf.SelectedText = strPage;
					rtf.SelectionFont = TextFont;
					rtf.SelectedText = "Ro = Perpendicular distance from shear center to centerline of element.\r\n";
					rtf.SelectionFont = TextFont;
					rtf.SelectedText = "Wn = Normalized unit warping, used for warping longitudinal stress.\r\n";
					rtf.SelectionFont = TextFont;
					rtf.SelectedText = "Sw = Warping statical moment, used for warping shear stress.\r\n\r\n";
					Part part2 = Section1.Part [1];
					rtf.SelectionFont = BodyFont;
					rtf.SelectedText = "x₀ =" + Units.DisplayLen1 (part2.Xon, 0, blnShowUnit: true, strFmt, 12, 8) + "Cw =" + Units.DisplayLen6 (part2.Cwn, 0, blnShowUnit: true, "", 12, 8) + "\r\n";
					rtf.SelectedText = "y₀ =" + Units.DisplayLen1 (part2.Yon, 0, blnShowUnit: true, strFmt, 12, 8) + "J  =" + Units.DisplayLen4 (part2.Jn, 0, blnShowUnit: true, "", 12, 8) + "\r\n";
					part2 = null;
				}
				result = true;
			}
		}
		return result;
	}

	public static bool rptWebCrippling (RichTextBox rtf, Section Section1, WebCripParameters WCP)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		WebCripCheck Check = default(WebCripCheck);
		bool result = false;
		string text3 = Section1.CheckBasicSection ();
		if (text3.Length > 0) {
			CFS.LicenseRequired (text3);
		} else {
			Cursor.Current = Cursors.WaitCursor;
			Section1.CalcStrength ((short)WCP.Spec);
			Section1.WebCripCheck (WCP, ref Check);
			Cursor.Current = Cursors.Default;
			rtf.Rtf = string.Empty;
			_ = Section1.Strength;
			string strFmt = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (WCP.Zend, WCP.Zload) * (double)Units.untLength [Units.DefaultUnitIndex [2]].Mult))];
			string strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (WCP.M), Check.Ma) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
			string text4 = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
			short num;
			if (CFS.IsSpecASD ((short)WCP.Spec)) {
				string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (WCP.P), Check.SPa) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Web Crippling Check - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)WCP.Spec], CFS.strSSspec (WCP.Spec)))));
				rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				rtf.SelectedText = "Load:   ";
				if (WCP.Dir == LoadDirections.dirY) {
					text2 = ((!(WCP.P >= 0f)) ? "on top flange" : "on bottom flange");
					text = "Pay";
				} else if (WCP.Dir == LoadDirections.dirX) {
					text2 = ((!(WCP.P >= 0f)) ? "on right flange" : "on left flange");
					text = "Pax";
				}
				rtf.SelectedText = Units.DisplayForce (System.Math.Abs (WCP.P), 0, blnShowUnit: true, strFmt3, 11, 0) + Strings.Space (1) + text2 + "\r\n";
				rtf.SelectedText = "Moment: " + Units.DisplayMoment (WCP.M, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
				rtf.SelectedText = "Bearing:" + Units.DisplayLen1 (WCP.N, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (WCP.N * Units.untLength [Units.DefaultUnitIndex [1]].Mult)], 11, 0) + "\r\n";
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Flange fastened to bearing surface: ", Interaction.IIf (WCP.Fastened, "Yes", "No")), "\r\n"));
				rtf.SelectedText = "Distance from edge of bearing to end of member: " + Units.DisplayLength (WCP.Zend, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n";
				rtf.SelectedText = "Distance from edge of bearing to edge of opposite load: " + Units.DisplayLength (WCP.Zload, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n" + strPage;
				rtf.SelectedText = "Part Elem Calculation Type  " + ("Pa " + text4).PadLeft (12) + (text + Strings.Space (1) + text4).PadLeft (12) + " Notes\r\n";
				short nEq = Check.nEq;
				checked {
					for (num = 1; num <= nEq; num = (short)unchecked(num + 1)) {
						short num2 = (short)Strings.InStr (Check.PeText [num] + ";", ";");
						rtf.SelectedText = Strings.Left (Check.PeText [num], num2 - 1) + Units.DisplayForce (Check.Pae [num], 0, blnShowUnit: false, strFmt3, 12, 0) + Units.DisplayForce (Check.Pa [num], 0, blnShowUnit: false, strFmt3, 12, 0) + " " + Strings.Mid (Check.PeText [num], num2 + 1) + "\r\n";
					}
					rtf.SelectedText = "Total".PadLeft (40) + Units.DisplayForce (Check.SPa, 0, blnShowUnit: false, strFmt3, 12, 0) + "\r\n" + strPage;
					rtf.SelectedText = "Web Crippling Check:         " + Units.DisplayForce (System.Math.Abs (WCP.P), 0, blnShowUnit: true, strFmt3, 11, 8);
					if (System.Math.Abs (WCP.P) <= Check.SPa) {
						rtf.SelectedText = "<=" + Units.DisplayForce (Check.SPa, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
					} else {
						rtf.SelectionColor = Color.Red;
						rtf.SelectedText = "> " + Units.DisplayForce (Check.SPa, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
						rtf.SelectionColor = Color.Black;
					}
					rtf.SelectedText = "Moment Check:                " + Units.DisplayMoment (System.Math.Abs (WCP.M), 0, blnShowUnit: true, strFmt2, 11, 8);
					if (System.Math.Abs (WCP.M) <= Check.Ma) {
						rtf.SelectedText = "<=" + Units.DisplayMoment (Check.Ma, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					} else {
						rtf.SelectionColor = Color.Red;
						rtf.SelectedText = "> " + Units.DisplayMoment (Check.Ma, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
						rtf.SelectionColor = Color.Black;
					}
				}
			} else {
				string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (WCP.P), Check.SQPn) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
				rtf.SelectionStart = Strings.Len (rtf.Text);
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Web Crippling Check - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)WCP.Spec], CFS.strSSspec (WCP.Spec)))));
				rtf.SelectedText = "Material Type: " + Strings.Trim (Section1.Material.Name) + ", Fy=" + Units.DisplayStress (Section1.Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				rtf.SelectedText = "Load:   ";
				if (WCP.Dir == LoadDirections.dirY) {
					text2 = ((!(WCP.P >= 0f)) ? "on top flange" : "on bottom flange");
					text = "Pny";
				} else if (WCP.Dir == LoadDirections.dirX) {
					text2 = ((!(WCP.P >= 0f)) ? "on right flange" : "on left flange");
					text = "Pnx";
				}
				rtf.SelectedText = Units.DisplayForce (System.Math.Abs (WCP.P), 0, blnShowUnit: true, strFmt3, 11, 0) + Strings.Space (1) + text2 + "\r\n";
				rtf.SelectedText = "Moment: " + Units.DisplayMoment (WCP.M, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
				rtf.SelectedText = "Bearing:" + Units.DisplayLen1 (WCP.N, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (WCP.N * Units.untLength [Units.DefaultUnitIndex [1]].Mult)], 11, 0) + "\r\n";
				rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Flange fastened to bearing surface: ", Interaction.IIf (WCP.Fastened, "Yes", "No")), "\r\n"));
				rtf.SelectedText = "Distance from edge of bearing to end of member: " + Units.DisplayLength (WCP.Zend, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n";
				rtf.SelectedText = "Distance from edge of bearing to edge of opposite load: " + Units.DisplayLength (WCP.Zload, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n" + strPage;
				rtf.SelectedText = "Part Elem Calculation Type  " + ("φPn " + text4).PadLeft (12) + (text + Strings.Space (1) + text4).PadLeft (12) + " Notes\r\n";
				short nEq2 = Check.nEq;
				checked {
					for (num = 1; num <= nEq2; num = (short)unchecked(num + 1)) {
						short num2 = (short)Strings.InStr (Check.PeText [num] + ";", ";");
						rtf.SelectedText = Strings.Left (Check.PeText [num], num2 - 1) + Units.DisplayForce (Check.QPne [num], 0, blnShowUnit: false, strFmt3, 12, 0) + Units.DisplayForce (Check.QPn [num], 0, blnShowUnit: false, strFmt3, 12, 0) + " " + Strings.Mid (Check.PeText [num], num2 + 1) + "\r\n";
					}
					rtf.SelectedText = "Total".PadLeft (40) + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: false, strFmt3, 12, 0) + "\r\n" + strPage;
					rtf.SelectedText = "Web Crippling Check:         " + Units.DisplayForce (System.Math.Abs (WCP.P), 0, blnShowUnit: true, strFmt3, 11, 8);
					if (System.Math.Abs (WCP.P) <= Check.SQPn) {
						rtf.SelectedText = "<=" + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
					} else {
						rtf.SelectionColor = Color.Red;
						rtf.SelectedText = "> " + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
						rtf.SelectionColor = Color.Black;
					}
					rtf.SelectedText = "Moment Check:                " + Units.DisplayMoment (System.Math.Abs (WCP.M), 0, blnShowUnit: true, strFmt2, 11, 8);
					if (System.Math.Abs (WCP.M) <= Check.QMn) {
						rtf.SelectedText = "<=" + Units.DisplayMoment (Check.QMn, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
					} else {
						rtf.SelectionColor = Color.Red;
						rtf.SelectedText = "> " + Units.DisplayMoment (Check.QMn, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
						rtf.SelectionColor = Color.Black;
					}
				}
			}
			rtf.SelectedText = "Interaction Equations\r\n";
			num = 1;
			checked {
				do {
					if (Strings.Len (Check.EqText [num]) != 0) {
						short num2 = (short)Strings.InStr (Check.EqText [num], ">");
						if (num2 > 0) {
							rtf.SelectedText = Strings.Left (Check.EqText [num], num2 - 1);
							rtf.SelectionColor = Color.Red;
							rtf.SelectedText = Strings.Mid (Check.EqText [num], num2) + "\r\n";
							rtf.SelectionColor = Color.Black;
						} else {
							rtf.SelectedText = Check.EqText [num] + "\r\n";
						}
					}
					num = (short)unchecked(num + 1);
				} while (num <= 3);
				if (Strings.Len (Check.Msg) != 0) {
					rtf.SelectedText = strPage + Check.Msg;
				}
			}
			if (CFS.blnTraceWebCrip & (Strings.Len (CFS.strTrace) > 0)) {
				rtf.SelectedText = strPage;
				rptTitle (rtf, Conversions.ToString (Operators.ConcatenateObject ("Calculation Details - ", Interaction.IIf (Section1.Material.IsCarbon (), CFS.strCSspec [(uint)WCP.Spec], CFS.strSSspec (WCP.Spec)))));
				rptTrace (rtf, CFS.strTrace);
			}
			result = true;
		}
		return result;
	}

	public static void rptWebCripplingAnl (RichTextBox rtf, Analysis Analysis1, ref short nChk, ref short[] Cchk, ref float[] Zchk, ref short[] Schk, ref WebCripParameters[] ParamChk)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		string strMsg = string.Empty;
		WebCripCheck Check = default(WebCripCheck);
		Cursor.Current = Cursors.WaitCursor;
		rtf.Rtf = string.Empty;
		Analysis analysis = Analysis1;
		checked {
			WebCripParameters[] Param = new WebCripParameters[unchecked((int)analysis.nBeam) + 1];
			string text3 = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + ")";
			float num = ((System.Math.Sign (analysis.Zmax) != System.Math.Sign (analysis.Zmin)) ? (analysis.Zmax - analysis.Zmin) : ((!(System.Math.Abs (analysis.Zmax) > System.Math.Abs (analysis.Zmin))) ? System.Math.Abs (analysis.Zmin) : System.Math.Abs (analysis.Zmax)));
			num = (float)((double)num * 1E-06);
			short num2 = nChk;
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Schk [num3] != 2) {
					short spec = analysis.Comb [Cchk [num3]].Spec;
					if ((analysis.iComb != Cchk [num3]) | (analysis.iCombSol != Cchk [num3])) {
						analysis.iComb = (byte)Cchk [num3];
						analysis.Analyze (ref strMsg);
					}
					Param [0] = ParamChk [num3];
					float num4 = Zchk [num3] + (float)Schk [num3] * num;
					analysis.WebCripCheckParameters (num4, ref Param);
					string strFmt = Units.Fmt [Units.FmtIndex (Param [0].Zload * Units.untLength [Units.DefaultUnitIndex [2]].Mult)];
					string strFmt2 = Units.Fmt [Units.FmtIndex (System.Math.Abs (Param [0].P) * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
					string strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (Param [0].M), 1.0) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
					string text4 = string.Empty;
					short nBeam = analysis.nBeam;
					for (short num5 = 1; num5 <= nBeam; num5 = (short)unchecked(num5 + 1)) {
						unchecked {
							if ((analysis.Beam [num5].Z0 <= num4) & (analysis.Beam [num5].Z1 >= num4)) {
								if (CFS.Sections [analysis.Beam [num5].iSct].Material.IsCarbon ()) {
									if (Operators.CompareString (text4, CFS.strSSspec ((Specifications)checked((byte)spec)), TextCompare: false) == 0) {
										text4 = CFS.strCSspec [spec] + "\r\nand " + CFS.strSSspec ((Specifications)checked((byte)spec));
										break;
									}
									text4 = CFS.strCSspec [spec];
								} else {
									if (Operators.CompareString (text4, CFS.strCSspec [spec], TextCompare: false) == 0) {
										text4 = CFS.strCSspec [spec] + "\r\nand " + CFS.strSSspec ((Specifications)checked((byte)spec));
										break;
									}
									text4 = CFS.strSSspec ((Specifications)checked((byte)spec));
								}
							}
						}
					}
					rtf.SelectionStart = Strings.Len (rtf.Text);
					if (rtf.SelectionStart > 0) {
						rtf.SelectedText = strPage;
					}
					rptTitle (rtf, "Web Crippling Check - " + text4);
					rtf.SelectedText = "Load Combination: " + analysis.Comb [analysis.iCombSol].Description + "\r\n";
					rtf.SelectedText = "Parameters at " + Units.DisplayLength (Zchk [num3], 0, blnShowUnit: true, strFmt, 0, 0);
					if (Schk [num3] == -1) {
						rtf.SelectedText = Conversions.ToString (Interaction.IIf (analysis.Vertical, ", Upper side", ", Left side"));
					} else if (Schk [num3] == 1) {
						rtf.SelectedText = Conversions.ToString (Interaction.IIf (analysis.Vertical, ", Lower side", ", Right side"));
					}
					rtf.SelectedText = ":\r\n";
					rtf.SelectedText = "Total Load:  ";
					if (Param [0].Dir == LoadDirections.dirY) {
						text = ((!(Param [0].P >= 0f)) ? "on top flange" : "on bottom flange");
						text2 = "Pay";
					} else if (Param [0].Dir == LoadDirections.dirX) {
						text = ((!(Param [0].P >= 0f)) ? "on right flange" : "on left flange");
						text2 = "Pax";
					}
					rtf.SelectedText = Units.DisplayForce (System.Math.Abs (Param [0].P), 0, blnShowUnit: true, strFmt2, 11, 0) + Strings.Space (1) + text + "\r\n";
					rtf.SelectedText = "Total Moment:" + Units.DisplayMoment (Param [0].M, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
					rtf.SelectedText = "Bearing:     " + Units.DisplayLen1 (Param [0].N, 0, blnShowUnit: true, Units.Fmt [Units.FmtIndex (Param [0].N * Units.untLength [Units.DefaultUnitIndex [1]].Mult)], 11, 0) + "\r\n";
					rtf.SelectedText = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Flange fastened to bearing surface: ", Interaction.IIf (Param [0].Fastened, "Yes", "No")), "\r\n"));
					rtf.SelectedText = "Distance from edge of bearing to edge of opposite load: " + Units.DisplayLength (Param [0].Zload, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n";
					short nBeam2 = analysis.nBeam;
					for (short num5 = 1; num5 <= nBeam2; num5 = (short)unchecked(num5 + 1)) {
						if ((analysis.Beam [num5].Z0 <= num4) & (analysis.Beam [num5].Z1 >= num4)) {
							short num6 = num5;
							float num7 = float.MaxValue;
							short nBeam3 = analysis.nBeam;
							for (short num8 = 1; num8 <= nBeam3; num8 = (short)unchecked(num8 + 1)) {
								if (analysis.Beam [num5].iSct == analysis.Beam [num8].iSct && ((analysis.Beam [num8].Z0 <= num4) & (analysis.Beam [num8].Z1 >= num4) & (Param [num8].Zend < num7))) {
									num7 = Param [num8].Zend;
									num6 = num8;
								}
							}
							if (num5 == num6) {
								CFS.Sections [analysis.Beam [num5].iSct].CalcStrength (unchecked((short)Param [num5].Spec));
								CFS.Sections [analysis.Beam [num5].iSct].WebCripCheck (Param [num5], ref Check);
								_ = CFS.Sections [analysis.Beam [num5].iSct].Strength;
								short num9;
								if (CFS.IsSpecASD (spec)) {
									strFmt = Units.Fmt [Units.FmtIndex (Param [num5].Zend * Units.untLength [Units.DefaultUnitIndex [2]].Mult)];
									strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (Param [num5].P), Check.SPa) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
									strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (Param [num5].M), Check.Ma) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
									rtf.SelectedText = strPage + "Section: " + CFSInterface.GetFileName (CFS.Sections [Analysis1.Beam [num5].iSct].Filename) + "\r\n";
									rtf.SelectedText = "Material Type: " + Strings.Trim (CFS.Sections [Analysis1.Beam [num5].iSct].Material.Name) + ", Fy=" + Units.DisplayStress (CFS.Sections [Analysis1.Beam [num5].iSct].Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
									rtf.SelectedText = "Applied Load:  ";
									if (Param [num5].Dir == LoadDirections.dirY) {
										text = ((!(Param [num5].P >= 0f)) ? "on top flange" : "on bottom flange");
										text2 = "Pay";
									} else if (Param [num5].Dir == LoadDirections.dirX) {
										text = ((!(Param [num5].P >= 0f)) ? "on right flange" : "on left flange");
										text2 = "Pax";
									}
									rtf.SelectedText = Units.DisplayForce (System.Math.Abs (Param [num5].P), 0, blnShowUnit: true, strFmt2, 11, 0) + Strings.Space (1) + text + "\r\n";
									rtf.SelectedText = "Applied Moment:" + Units.DisplayMoment (Param [num5].M, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Distance from edge of bearing to end of member: " + Units.DisplayLength (Param [num5].Zend, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n" + strPage;
									rtf.SelectedText = "Part Elem Calculation Type  " + ("Pa " + text3).PadLeft (11) + (text2 + Strings.Space (1) + text3).PadLeft (11) + " Notes\r\n";
									short nEq = Check.nEq;
									for (num9 = 1; num9 <= nEq; num9 = (short)unchecked(num9 + 1)) {
										short num10 = (short)Strings.InStr (Check.PeText [num9] + ";", ";");
										rtf.SelectedText = Strings.Left (Check.PeText [num9], num10 - 1) + Units.DisplayForce (Check.Pae [num9], 0, blnShowUnit: false, strFmt2, 11, 0) + Units.DisplayForce (Check.Pa [num9], 0, blnShowUnit: false, strFmt2, 11, 0) + " " + Strings.Mid (Check.PeText [num9], num10 + 1) + "\r\n";
									}
									rtf.SelectedText = "Web Crippling Strength".PadLeft (39) + Units.DisplayForce (Check.SPa, 0, blnShowUnit: false, strFmt2, 11, 0) + "\r\n" + strPage;
									rtf.SelectedText = "Web Crippling Check:         " + Units.DisplayForce (System.Math.Abs (Param [num5].P), 0, blnShowUnit: true, strFmt2, 11, 8);
									if (System.Math.Abs (Param [num5].P) <= Check.SPa) {
										rtf.SelectedText = "<=" + Units.DisplayForce (Check.SPa, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
									} else {
										rtf.SelectionColor = Color.Red;
										rtf.SelectedText = "> " + Units.DisplayForce (Check.SPa, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
										rtf.SelectionColor = Color.Black;
									}
									rtf.SelectedText = "Moment Check:                " + Units.DisplayMoment (System.Math.Abs (Param [num5].M), 0, blnShowUnit: true, strFmt3, 11, 8);
									if (System.Math.Abs (Param [num5].M) <= Check.Ma) {
										rtf.SelectedText = "<=" + Units.DisplayMoment (Check.Ma, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									} else {
										rtf.SelectionColor = Color.Red;
										rtf.SelectedText = "> " + Units.DisplayMoment (Check.Ma, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
										rtf.SelectionColor = Color.Black;
									}
								} else {
									strFmt = Units.Fmt [Units.FmtIndex (Param [num5].Zend * Units.untLength [Units.DefaultUnitIndex [2]].Mult)];
									strFmt2 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (Param [num5].P), Check.SQPn) * (double)Units.untForce [Units.DefaultUnitIndex [4]].Mult))];
									strFmt3 = Units.Fmt [Units.FmtIndex ((float)(CFS.Max (System.Math.Abs (Param [num5].M), Check.QMn) * (double)Units.untMoment [Units.DefaultUnitIndex [6]].Mult))];
									rtf.SelectedText = strPage + "Section: " + CFSInterface.GetFileName (CFS.Sections [Analysis1.Beam [num5].iSct].Filename) + "\r\n";
									rtf.SelectedText = "Material Type: " + Strings.Trim (CFS.Sections [Analysis1.Beam [num5].iSct].Material.Name) + ", Fy=" + Units.DisplayStress (CFS.Sections [Analysis1.Beam [num5].iSct].Material.Fy [2], 0, blnShowUnit: true, "", 0, 0) + "\r\n";
									rtf.SelectedText = "Applied Load:  ";
									if (Param [num5].Dir == LoadDirections.dirY) {
										text = ((!(Param [num5].P >= 0f)) ? "on top flange" : "on bottom flange");
										text2 = "Pny";
									} else if (Param [num5].Dir == LoadDirections.dirX) {
										text = ((!(Param [num5].P >= 0f)) ? "on right flange" : "on left flange");
										text2 = "Pnx";
									}
									rtf.SelectedText = Units.DisplayForce (System.Math.Abs (Param [num5].P), 0, blnShowUnit: true, strFmt2, 11, 0) + Strings.Space (1) + text + "\r\n";
									rtf.SelectedText = "Applied Moment:" + Units.DisplayMoment (Param [num5].M, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									rtf.SelectedText = "Distance from edge of bearing to end of member: " + Units.DisplayLength (Param [num5].Zend, 0, blnShowUnit: true, strFmt, 0, 0) + "\r\n" + strPage;
									rtf.SelectedText = "Part Elem Calculation Type  " + ("φPn " + text3).PadLeft (11) + (text2 + Strings.Space (1) + text3).PadLeft (11) + " Notes\r\n";
									short nEq2 = Check.nEq;
									for (num9 = 1; num9 <= nEq2; num9 = (short)unchecked(num9 + 1)) {
										short num10 = (short)Strings.InStr (Check.PeText [num9] + ";", ";");
										rtf.SelectedText = Strings.Left (Check.PeText [num9], num10 - 1) + Units.DisplayForce (Check.QPne [num9], 0, blnShowUnit: false, strFmt2, 11, 0) + Units.DisplayForce (Check.QPn [num9], 0, blnShowUnit: false, strFmt2, 11, 0) + " " + Strings.Mid (Check.PeText [num9], num10 + 1) + "\r\n";
									}
									rtf.SelectedText = "Web Crippling Strength".PadLeft (39) + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: false, strFmt2, 11, 0) + "\r\n" + strPage;
									rtf.SelectedText = "Web Crippling Check:         " + Units.DisplayForce (System.Math.Abs (Param [num5].P), 0, blnShowUnit: true, strFmt2, 11, 8);
									if (System.Math.Abs (Param [num5].P) <= Check.SQPn) {
										rtf.SelectedText = "<=" + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
									} else {
										rtf.SelectionColor = Color.Red;
										rtf.SelectedText = "> " + Units.DisplayForce (Check.SQPn, 0, blnShowUnit: true, strFmt2, 11, 0) + "\r\n";
										rtf.SelectionColor = Color.Black;
									}
									rtf.SelectedText = "Moment Check:                " + Units.DisplayMoment (System.Math.Abs (Param [num5].M), 0, blnShowUnit: true, strFmt3, 11, 8);
									if (System.Math.Abs (Param [num5].M) <= Check.QMn) {
										rtf.SelectedText = "<=" + Units.DisplayMoment (Check.QMn, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
									} else {
										rtf.SelectionColor = Color.Red;
										rtf.SelectedText = "> " + Units.DisplayMoment (Check.QMn, 0, blnShowUnit: true, strFmt3, 11, 0) + "\r\n";
										rtf.SelectionColor = Color.Black;
									}
								}
								rtf.SelectedText = "Interaction Equations\r\n";
								num9 = 1;
								do {
									if (Strings.Len (Check.EqText [num9]) != 0) {
										short num10 = (short)Strings.InStr (Check.EqText [num9], ">");
										if (num10 > 0) {
											rtf.SelectedText = Strings.Left (Check.EqText [num9], num10 - 1);
											rtf.SelectionColor = Color.Red;
											rtf.SelectedText = Strings.Mid (Check.EqText [num9], num10) + "\r\n";
											rtf.SelectionColor = Color.Black;
										} else {
											rtf.SelectedText = Check.EqText [num9] + "\r\n";
										}
									}
									num9 = (short)unchecked(num9 + 1);
								} while (num9 <= 3);
								if (Strings.Len (Check.Msg) != 0) {
									rtf.SelectedText = strPage + Check.Msg;
								}
								if (CFS.blnTraceWebCrip & (Strings.Len (CFS.strTrace) > 0)) {
									rtf.SelectedText = strPage;
									rptTitle (rtf, "Calculation Details - " + text4);
									rptTrace (rtf, CFS.strTrace);
								}
							}
						}
					}
				}
			}
			analysis = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void rptDSMData (RichTextBox rtf, Section Section1, FiniteStrip.DSMData[] DSM)
	{
		float num = Section1.Material.Fy [2];
		float num2 = 1000f * num;
		int num3 = Information.UBound (DSM);
		checked {
			float num4 = default(float);
			float num5 = default(float);
			float stress = default(float);
			float length = default(float);
			for (int i = 0; i <= num3; i++) {
				if (!((DSM [i].Length > 0f) & (DSM [i].Stress < num2))) {
					continue;
				}
				if (i < 2) {
					if (DSM [i].Stress * Section1.Prop.A > num4) {
						num4 = DSM [i].Stress * Section1.Prop.A;
					}
				} else if (i < 6) {
					if (DSM [i].Stress * Section1.Prop.Sx > num5) {
						num5 = DSM [i].Stress * Section1.Prop.Sx;
					}
				} else if (DSM [i].Stress * Section1.Prop.Sy > num5) {
					num5 = DSM [i].Stress * Section1.Prop.Sy;
				}
				if (DSM [i].Stress > stress) {
					stress = DSM [i].Stress;
				}
				if (DSM [i].Length > length) {
					length = DSM [i].Length;
				}
			}
			string strFmt = Units.Fmt [Units.FmtIndex (num4 * Units.untForce [Units.DefaultUnitIndex [4]].Mult)];
			string strFmt2 = Units.Fmt [Units.FmtIndex (num5 * Units.untMoment [Units.DefaultUnitIndex [6]].Mult)];
			string strFmt3 = Units.Fmt [Units.FmtIndex (stress * Units.untStress [Units.DefaultUnitIndex [5]].Mult)];
			string strFmt4 = Units.Fmt [Units.FmtIndex (length * Units.untLength [Units.DefaultUnitIndex [2]].Mult)];
			string strFmt5 = Units.Fmt [Units.FmtIndex (1f)];
			string strFmt6 = Units.Fmt [Units.FmtIndex (100f)];
			rtf.Rtf = string.Empty;
			rtf.SelectionStart = 0;
			rptTitle (rtf, "Finite Strip Elastic Buckling Results");
			rtf.SelectedText = "Buckling  Magnitude     Stress     Stress     Length       Work\r\n";
			string text = "(" + Units.untForce [Units.DefaultUnitIndex [4]].Name + "," + Units.untMoment [Units.DefaultUnitIndex [6]].Name + ")";
			string text2 = "(" + Units.untStress [Units.DefaultUnitIndex [5]].Name + ")";
			string text3 = "(" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
			rtf.SelectedText = "Mode" + text.PadLeft (15) + text2.PadLeft (11) + "/Yield".PadLeft (11) + text3.PadLeft (11) + "Ratio".PadLeft (11) + "\r\n";
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = "-----".PadLeft (11);
			int num6 = Information.UBound (DSM);
			for (int j = 0; j <= num6; j++) {
				switch (j) {
				case 0:
					text4 = "Pcrl    ";
					text5 = Units.DisplayForce (DSM [j].Stress * Section1.Prop.A, 0, blnShowUnit: false, strFmt, 11, 0);
					break;
				case 1:
					text4 = "Pcrd    ";
					text5 = Units.DisplayForce (DSM [j].Stress * Section1.Prop.A, 0, blnShowUnit: false, strFmt, 11, 0);
					break;
				case 2:
					text4 = "Mcrlx+  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sx, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 3:
					text4 = "Mcrdx+  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sx, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 4:
					text4 = "Mcrlx-  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sx, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 5:
					text4 = "Mcrdx-  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sx, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 6:
					text4 = "Mcrly+  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sy, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 7:
					text4 = "Mcrdy+  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sy, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 8:
					text4 = "Mcrly-  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sy, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				case 9:
					text4 = "Mcrdy-  ";
					text5 = Units.DisplayMoment (DSM [j].Stress * Section1.Prop.Sy, 0, blnShowUnit: false, strFmt2, 11, 0);
					break;
				}
				if ((DSM [j].Length == 0f) | (DSM [j].Stress >= num2)) {
					text4 = text4 + text6 + text6 + text6 + text6 + text6;
				} else {
					text4 += text5;
					text4 += Units.DisplayStress (DSM [j].Stress, 0, blnShowUnit: false, strFmt3, 11, 0);
					text4 += Units.DisplayNone (DSM [j].Stress / num, strFmt5, 11, 0);
					text4 += Units.DisplayLength (DSM [j].Length, 0, blnShowUnit: false, strFmt4, 11, 0);
					text4 += Units.DisplayNone (DSM [j].WorkRatio, strFmt6, 11, 0);
				}
				rtf.SelectedText = text4 + "\r\n";
			}
		}
	}

	public static string Symbol (string A)
	{
		return "\u0001" + A;
	}
}
