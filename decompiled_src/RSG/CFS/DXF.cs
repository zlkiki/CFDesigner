// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

[StandardModule]
internal sealed class DXF
{
	public struct Point2D
	{
		public double X;

		public double Y;
	}

	private const string IntFmt = "#####0";

	private const string DblFmt = "#######0.######";

	private const string strDot = ".";

	private static double dblScale;

	private static string strDec;

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFOpen (int N, string File, Point2D LimMin, Point2D LimMax, double Factor = 1.0)
	{
		dblScale = Factor;
		strDec = Strings.Mid (Strings.Format (0.5, "0.0"), 2, 1);
		FileSystem.FileOpen (N, File, OpenMode.Output);
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "SECTION");
		FileSystem.PrintLine (N, "  2");
		FileSystem.PrintLine (N, "HEADER");
		FileSystem.PrintLine (N, "  9");
		FileSystem.PrintLine (N, "$LIMMIN");
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (LimMin.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (LimMin.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, "  9");
		FileSystem.PrintLine (N, "$LIMMAX");
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (LimMax.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (LimMax.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, "  9");
		FileSystem.PrintLine (N, "$FLATLAND");
		FileSystem.PrintLine (N, " 70");
		FileSystem.PrintLine (N, "1");
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "ENDSEC");
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "SECTION");
		FileSystem.PrintLine (N, "  2");
		FileSystem.PrintLine (N, "ENTITIES");
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFPoint (int N, string Layer, short Color, string LineType, Point2D Pt)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "POINT");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		if (Operators.CompareString (LineType, "", TextCompare: false) != 0) {
			FileSystem.PrintLine (N, "  6");
			FileSystem.PrintLine (N, LineType);
		}
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt.Y * dblScale, "#######0.######"), strDec, "."));
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFLine (int N, string Layer, short Color, string LineType, Point2D StartPt, Point2D EndPt)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "LINE");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		if (Operators.CompareString (LineType, "", TextCompare: false) != 0) {
			FileSystem.PrintLine (N, "  6");
			FileSystem.PrintLine (N, LineType);
		}
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (StartPt.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (StartPt.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 11");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (EndPt.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 21");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (EndPt.Y * dblScale, "#######0.######"), strDec, "."));
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFArc (int N, string Layer, short Color, string LineType, Point2D Center, double Radius, double StartAng, double EndAng)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "ARC");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		if (Operators.CompareString (LineType, "", TextCompare: false) != 0) {
			FileSystem.PrintLine (N, "  6");
			FileSystem.PrintLine (N, LineType);
		}
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Center.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Center.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 40");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Radius * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 50");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (StartAng * 180.0 / System.Math.PI, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 51");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (EndAng * 180.0 / System.Math.PI, "#######0.######"), strDec, "."));
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFCircle (int N, string Layer, short Color, string LineType, Point2D Center, double Radius)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "CIRCLE");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		if (Operators.CompareString (LineType, "", TextCompare: false) != 0) {
			FileSystem.PrintLine (N, "  6");
			FileSystem.PrintLine (N, LineType);
		}
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Center.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Center.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 40");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Radius * dblScale, "#######0.######"), strDec, "."));
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFInsert (int N, string File, Point2D InsPt, double Factor, double Angle, bool Mirror)
	{
		string left = "";
		int num = FileSystem.FreeFile ();
		FileSystem.FileOpen (num, File + ".DXF", OpenMode.Input);
		checked {
			while (true) {
				string inputStr = FileSystem.LineInput (num);
				short num2 = (short)System.Math.Round (Conversion.Val (inputStr));
				inputStr = FileSystem.LineInput (num);
				if ((num2 == 0) & (Operators.CompareString (inputStr, "SECTION", TextCompare: false) == 0)) {
					inputStr = FileSystem.LineInput (num);
					num2 = (short)System.Math.Round (Conversion.Val (inputStr));
					inputStr = FileSystem.LineInput (num);
					if ((num2 == 2) & (Operators.CompareString (inputStr, "ENTITIES", TextCompare: false) == 0)) {
						break;
					}
				}
			}
			short num3 = default(short);
			short num4 = default(short);
			double num5 = default(double);
			double num6 = default(double);
			while (!FileSystem.EOF (num)) {
				string inputStr = FileSystem.LineInput (num);
				short num2 = (short)System.Math.Round (Conversion.Val (inputStr));
				inputStr = FileSystem.LineInput (num);
				if (num2 == 0) {
					left = inputStr;
					num3 = -1;
					num4 = -1;
					if (Operators.CompareString (left, "ENDSEC", TextCompare: false) == 0) {
						break;
					}
					if (Operators.CompareString (left, "INSERT", TextCompare: false) == 0) {
						Interaction.MsgBox (File + ".DXF contains a block.", MsgBoxStyle.Critical);
						break;
					}
				}
				if (num2 <= 9) {
					FileSystem.PrintLine (N, Strings.Format (num2, "#####0"));
					FileSystem.PrintLine (N, inputStr);
				} else if (num2 <= 19) {
					num3 = (short)(num2 - 10);
					num5 = Conversion.Val (inputStr);
					if (num3 == num4) {
						double num7 = Factor * System.Math.Sqrt (num5 * num5 + num6 * num6) * dblScale;
						double num8 = System.Math.Atan2 (num6, num5);
						num8 = ((!Mirror) ? (num8 + Angle) : (2.0 * Angle - num8));
						num5 = InsPt.X + num7 * System.Math.Cos (num8);
						num6 = InsPt.Y + num7 * System.Math.Sin (num8);
						FileSystem.PrintLine (N, Strings.Format (10 + num3, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num5, "#######0.######"), strDec, "."));
						FileSystem.PrintLine (N, Strings.Format (20 + num4, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num6, "#######0.######"), strDec, "."));
					}
				} else if (num2 <= 29) {
					num4 = (short)(num2 - 20);
					num6 = Conversion.Val (inputStr);
					if (num4 == num3) {
						double num7 = Factor * System.Math.Sqrt (num5 * num5 + num6 * num6) * dblScale;
						double num8 = System.Math.Atan2 (num6, num5);
						num8 = ((!Mirror) ? (num8 + Angle) : (2.0 * Angle - num8));
						num5 = InsPt.X + num7 * System.Math.Cos (num8);
						num6 = InsPt.Y + num7 * System.Math.Sin (num8);
						FileSystem.PrintLine (N, Strings.Format (10 + num3, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num5, "#######0.######"), strDec, "."));
						FileSystem.PrintLine (N, Strings.Format (20 + num4, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num6, "#######0.######"), strDec, "."));
					}
				} else {
					if (num2 <= 39) {
						continue;
					}
					if (num2 <= 49) {
						double num7 = Conversion.Val (inputStr);
						if (unchecked(Operators.CompareString (left, "VERTEX", TextCompare: false) == 0 && num2 == 42)) {
							if (Mirror) {
								num7 = 0.0 - num7;
							}
						} else {
							num7 = num7 * Factor * dblScale;
						}
						FileSystem.PrintLine (N, Strings.Format (num2, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num7, "#######0.######"), strDec, "."));
					} else if (num2 <= 59) {
						double num8 = Conversion.Val (inputStr);
						if (Mirror) {
							if (Operators.CompareString (left, "ARC", TextCompare: false) == 0) {
								num2 = (short)(101 - num2);
							}
							num8 = 2.0 * Angle * 180.0 / System.Math.PI - num8;
						} else {
							num8 += Angle * 180.0 / System.Math.PI;
						}
						FileSystem.PrintLine (N, Strings.Format (num2, "#####0"));
						FileSystem.PrintLine (N, Strings.Replace (Strings.Format (num8, "#######0.######"), strDec, "."));
					} else if (num2 <= 79) {
						FileSystem.PrintLine (N, Strings.Format (num2, "#####0"));
						FileSystem.PrintLine (N, inputStr);
					} else if (num2 != 999) {
						Interaction.MsgBox (File + ".DXF contains invalid code:" + Conversion.Str (num2), MsgBoxStyle.Critical);
						break;
					}
				}
			}
			FileSystem.FileClose (num);
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFPolyLine (int N, string Layer, short Color, string LineType, bool Closed, short NumPt, Point2D[] Pt)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "POLYLINE");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		if (Operators.CompareString (LineType, "", TextCompare: false) != 0) {
			FileSystem.PrintLine (N, "  6");
			FileSystem.PrintLine (N, LineType);
		}
		FileSystem.PrintLine (N, " 70");
		if (Closed) {
			FileSystem.PrintLine (N, "1");
		} else {
			FileSystem.PrintLine (N, "0");
		}
		short num = NumPt;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				FileSystem.PrintLine (N, "  0");
				FileSystem.PrintLine (N, "VERTEX");
				FileSystem.PrintLine (N, "  8");
				FileSystem.PrintLine (N, Layer);
				FileSystem.PrintLine (N, " 10");
				FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt [num2].X * dblScale, "#######0.######"), strDec, "."));
				FileSystem.PrintLine (N, " 20");
				FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt [num2].Y * dblScale, "#######0.######"), strDec, "."));
			}
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFText (int N, string Layer, short Color, Point2D Pt, float Ht, float Ang, string Text)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "LINE");
		FileSystem.PrintLine (N, "  8");
		FileSystem.PrintLine (N, Layer);
		if (Color > 0) {
			FileSystem.PrintLine (N, " 62");
			FileSystem.PrintLine (N, Strings.Format (Color, "#####0"));
		}
		FileSystem.PrintLine (N, " 10");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt.X * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 20");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format (Pt.Y * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 40");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format ((double)Ht * dblScale, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, " 50");
		FileSystem.PrintLine (N, Strings.Replace (Strings.Format ((double)(Ang * 180f) / System.Math.PI, "#######0.######"), strDec, "."));
		FileSystem.PrintLine (N, "  1");
		FileSystem.PrintLine (N, Text);
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void DXFClose (int N)
	{
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "ENDSEC");
		FileSystem.PrintLine (N, "  0");
		FileSystem.PrintLine (N, "EOF");
		FileSystem.FileClose (N);
	}
}
