// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.Math;

namespace RSG.CFS;

[StandardModule]
internal sealed class FiniteStrip
{
	public enum HoleMode
	{
		Gross = 1,
		Local,
		Distortional
	}

	public struct BuckleState
	{
		public float Length;

		public float LF;

		public float P;

		public float Mx;

		public float My;

		public float Fmax;

		public short ModeShape;

		public float WorkRatio;

		public HoleMode HoleMode;

		public bool HoleMarker;
	}

	public struct DSMData
	{
		public float Stress;

		public float Length;

		public float WorkRatio;
	}

	private struct NodeType
	{
		public float X;

		public float Y;

		public float A;

		public float Wn;

		public float F;

		public short DOFx;

		public short DOFy;

		public short DOFz;

		public short DOFr;

		public short R;
	}

	private struct StripType
	{
		public short Nodei;

		public short Nodej;

		public float Thickness;

		public float Width;

		public float Alpha;

		public float HoleLength;
	}

	private struct ModeShapeType
	{
		public float DX;

		public float DY;

		public float DZ;

		public float Rot;
	}

	public static BuckleState[] Buckle;

	private static NodeType[] Node;

	private static StripType[] Strip;

	private static ModeShapeType[,] ModeShape;

	private static short intNodeCount;

	private static short intStripCount;

	public static void FiniteStripAnalysis (Section Section1, BuckleParameters Param)
	{
		float fbx = Param.Fbx;
		float fby = Param.Fby;
		short bimoment = Param.Bimoment;
		float lmin = Param.Lmin;
		float lmax = Param.Lmax;
		short resolution = Param.Resolution;
		bool constrained = Param.Constrained;
		bool altMethod = Param.AltMethod;
		bool repeat = Param.Repeat;
		float[] array = new float[20];
		double[,] array2 = new double[9, 9];
		double[,] array3 = new double[9, 9];
		double[,] array4 = new double[9, 9];
		double[,] array5 = new double[9, 9];
		short[] array6 = new short[9];
		ref Section.PropertiesType prop = ref Section1.Prop;
		float num = prop.A;
		float num2 = prop.Sx;
		float num3 = prop.Sy;
		float num4 = prop.Ix;
		float num5 = prop.Iy;
		float num6 = prop.Ixy;
		float num7 = num4 / num2;
		float num8 = num5 / num3;
		float num9 = 1f - System.Math.Abs (fbx) - System.Math.Abs (fby);
		float num10 = fbx;
		float num11 = fby;
		if (!constrained) {
			num10 = (fbx * num4 * num5 - fby * num6 * num4 * num3 / num2) / (num4 * num5 - num6 * num6);
			num11 = (fby * num4 * num5 - fbx * num6 * num5 * num2 / num3) / (num4 * num5 - num6 * num6);
		}
		float num12 = 0f;
		float num13 = 0f;
		short nPart = Section1.nPart;
		checked {
			for (short num14 = 1; num14 <= nPart; num14 = (short)unchecked(num14 + 1)) {
				Part part = Section1.Part [num14];
				int nElem = part.nElem;
				for (int i = 1; i <= nElem; i++) {
					if (part.Element [i].Wid > num12) {
						num12 = part.Element [i].Wid;
					}
				}
				int num15 = Information.UBound (part.TPg);
				for (int j = 1; j <= num15; j++) {
					if (System.Math.Abs (part.TPg [j].Wn) > num13) {
						num13 = System.Math.Abs (part.TPg [j].Wn);
					}
				}
				part = null;
			}
			float num16 = default(float);
			if (bimoment != 0) {
				num9 = 0f;
				num10 = 0f;
				num11 = 0f;
				num16 = bimoment;
			}
			intStripCount = 0;
			short num17 = 0;
			intNodeCount = 0;
			short num18 = 0;
			Node = new NodeType[11];
			Strip = new StripType[11];
			Node [0].X = Section1.Prop.Xcg;
			Node [0].Y = Section1.Prop.Ycg;
			short nPart2 = Section1.nPart;
			float wn = default(float);
			float wn2 = default(float);
			float holeLength = default(float);
			float num27 = default(float);
			float loc = default(float);
			for (short num14 = 1; num14 <= nPart2; num14 = (short)unchecked(num14 + 1)) {
				Part part2 = Section1.Part [num14];
				float thickness = part2.Thickness;
				float num19 = part2.XPosition - part2.Xcg;
				float num20 = part2.YPosition - part2.Ycg;
				short nElem2 = part2.nElem;
				for (short num21 = 1; num21 <= nElem2; num21 = (short)unchecked(num21 + 1)) {
					short num22 = ((num21 <= 1) ? part2.nElem : ((short)(num21 - 1)));
					if (((num21 > 1) | part2.Closed) && (double)((part2.Element [num21].Rad + thickness / 2f) * System.Math.Abs (part2.Element [num21].Arc)) > 1E-06 * (double)Section1.Prop.Rc) {
						short num23 = (short)System.Math.Round (20.0 * System.Math.Sqrt ((part2.Element [num21].Rad + thickness / 2f) / Section1.Prop.Rc) * System.Math.Abs ((double)part2.Element [num21].Arc / System.Math.PI));
						if (num23 < 1) {
							num23 = 1;
						}
						for (short num24 = (short)Information.UBound (part2.TPg); num24 >= 1; num24 = (short)unchecked(num24 + -1)) {
							if (part2.TPg [num24].iElem == num22) {
								wn = part2.TPg [num24].Wn;
								if (num24 == Information.UBound (part2.TPg)) {
									num24 = 0;
								}
								wn2 = part2.TPg [num24 + 1].Wn;
								break;
							}
						}
						if (intNodeCount == num18) {
							intNodeCount++;
							if (intNodeCount > Information.UBound (Node)) {
								Node = (NodeType[])Utils.CopyArray (Node, new NodeType[intNodeCount + 9 + 1]);
							}
							Node [intNodeCount].X = num19 + part2.Element [num22].X1;
							Node [intNodeCount].Y = num20 + part2.Element [num22].Y1;
							Node [intNodeCount].Wn = wn;
						}
						short num25 = num23;
						for (short num26 = 1; num26 <= num25; num26 = (short)unchecked(num26 + 1)) {
							intNodeCount++;
							if (intNodeCount > Information.UBound (Node)) {
								Node = (NodeType[])Utils.CopyArray (Node, new NodeType[intNodeCount + 9 + 1]);
							}
							num27 = (float)((double)part2.Element [num22].Ang - (double)System.Math.Sign (part2.Element [num21].Arc) * System.Math.PI / 2.0 + (double)(part2.Element [num21].Arc * (float)num26 / (float)num23));
							Node [intNodeCount].X = (float)((double)(num19 + part2.Element [num21].Xac) + (double)(part2.Element [num21].Rad + thickness / 2f) * System.Math.Cos (num27));
							Node [intNodeCount].Y = (float)((double)(num20 + part2.Element [num21].Yac) + (double)(part2.Element [num21].Rad + thickness / 2f) * System.Math.Sin (num27));
							Node [intNodeCount].Wn = wn + (wn2 - wn) * (float)num26 / (float)num23;
							intStripCount++;
							if (intStripCount > Information.UBound (Strip)) {
								Strip = (StripType[])Utils.CopyArray (Strip, new StripType[intStripCount + 9 + 1]);
							}
							Strip [intStripCount].Nodei = (short)(intNodeCount - 1);
							Strip [intStripCount].Nodej = intNodeCount;
							Strip [intStripCount].Thickness = thickness;
						}
					}
					float num28 = part2.Element [num21].X0;
					float num29 = part2.Element [num21].Y0;
					short num30 = (short)Information.UBound (part2.TPg);
					for (short num24 = 1; num24 <= num30; num24 = (short)unchecked(num24 + 1)) {
						if (part2.TPg [num24].iElem == num21) {
							wn = part2.TPg [num24].Wn;
							wn2 = part2.TPg [num24 + 1].Wn;
							loc = part2.TPg [num24 + 1].Loc;
							break;
						}
					}
					int num31 = 1;
					do {
						float num32 = num28;
						float num33 = num29;
						if ((part2.Element [num21].Hole == 0f) | (Section1.HoleLength == 0f)) {
							num31 = 3;
						}
						switch (num31) {
						case 1:
							num28 = part2.Element [num21].Xh0;
							num29 = part2.Element [num21].Yh0;
							break;
						case 2:
							num28 = part2.Element [num21].Xh1;
							num29 = part2.Element [num21].Yh1;
							break;
						case 3:
							num28 = part2.Element [num21].X1;
							num29 = part2.Element [num21].Y1;
							break;
						}
						float num34 = (float)System.Math.Sqrt (System.Math.Pow (num28 - num32, 2.0) + System.Math.Pow (num29 - num33, 2.0));
						if ((double)num34 > 1E-05 * (double)Section1.Prop.Rc) {
							float num35 = num19 + num32 - Section1.Prop.Xcg;
							float num36 = num20 + num33 - Section1.Prop.Ycg;
							float num37 = (float)System.Math.Sqrt (System.Math.Pow (num32 - part2.Element [num21].X0, 2.0) + System.Math.Pow (num33 - part2.Element [num21].Y0, 2.0));
							float num38 = wn + (wn2 - wn) * num37 / loc;
							float num39 = num9 + num10 * num36 / num7 + num11 * num35 / num8 + num16 * num38 / num13;
							num35 = num19 + num28 - Section1.Prop.Xcg;
							num36 = num20 + num29 - Section1.Prop.Ycg;
							num37 = (float)System.Math.Sqrt (System.Math.Pow (num28 - part2.Element [num21].X0, 2.0) + System.Math.Pow (num29 - part2.Element [num21].Y0, 2.0));
							num38 = wn + (wn2 - wn) * num37 / loc;
							float num40 = num9 + num10 * num36 / num7 + num11 * num35 / num8 + num16 * num38 / num13;
							short num23 = (short)System.Math.Round (2.5 * System.Math.Sqrt (num34 / Section1.Prop.Rc) * (1.0 + 0.5 * (double)System.Math.Abs (num39 - num40)));
							if (num23 < 1 + (short)System.Math.Round (3f * num34 / num12)) {
								num23 = (short)(1 + (short)System.Math.Round (3f * num34 / num12));
							}
							if (intNodeCount == num18) {
								intNodeCount++;
								if (intNodeCount > Information.UBound (Node)) {
									Node = (NodeType[])Utils.CopyArray (Node, new NodeType[intNodeCount + 9 + 1]);
								}
								Node [intNodeCount].X = num19 + num32;
								Node [intNodeCount].Y = num20 + num33;
								Node [intNodeCount].Wn = wn;
							}
							short num41 = num23;
							for (short num26 = 1; num26 <= num41; num26 = (short)unchecked(num26 + 1)) {
								intNodeCount++;
								if (intNodeCount > Information.UBound (Node)) {
									Node = (NodeType[])Utils.CopyArray (Node, new NodeType[intNodeCount + 9 + 1]);
								}
								Node [intNodeCount].X = (float)((double)(num19 + num32) + (double)(num28 - num32) * ((double)num26 / (double)num23));
								Node [intNodeCount].Y = (float)((double)(num20 + num33) + (double)(num29 - num33) * ((double)num26 / (double)num23));
								num37 = (float)System.Math.Sqrt (System.Math.Pow ((double)num32 + (double)(num28 - num32) * ((double)num26 / (double)num23) - (double)part2.Element [num21].X0, 2.0) + System.Math.Pow ((double)num33 + (double)(num29 - num33) * ((double)num26 / (double)num23) - (double)part2.Element [num21].Y0, 2.0));
								Node [intNodeCount].Wn = wn + (wn2 - wn) * num37 / loc;
								intStripCount++;
								if (intStripCount > Information.UBound (Strip)) {
									Strip = (StripType[])Utils.CopyArray (Strip, new StripType[intStripCount + 9 + 1]);
								}
								Strip [intStripCount].Nodei = (short)(intNodeCount - 1);
								Strip [intStripCount].Nodej = intNodeCount;
								Strip [intStripCount].Thickness = thickness;
								Strip [intStripCount].HoleLength = Conversions.ToSingle (Operators.MultiplyObject (Operators.MultiplyObject (Section1.HoleLength, Interaction.IIf (part2.Element [num21].Hole > 0f, 1, 0)), Interaction.IIf (num31 == 2, 1, -1)));
								if (Strip [intStripCount].HoleLength > holeLength) {
									holeLength = Strip [intStripCount].HoleLength;
								}
							}
						}
						num31++;
					} while (num31 <= 3);
				}
				if (unchecked(part2.Closed || repeat) & (intNodeCount > num18 + 1)) {
					NodeType[] array7 = new NodeType[(short)unchecked(intNodeCount - num18) + 1];
					short num42 = (short)(num18 + 1);
					short num43 = intNodeCount;
					for (short num44 = num42; num44 <= num43; num44 = (short)unchecked(num44 + 1)) {
						array7 [(short)unchecked(num44 - num18)] = Node [num44];
					}
					short num45 = (short)(num17 + 1);
					short num46 = intStripCount;
					for (short num26 = num45; num26 <= num46; num26 = (short)unchecked(num26 + 1)) {
						short num47 = (short)unchecked(Strip [num26].Nodei - num18);
						if (num47 >= 3) {
							short num44 = (short)(num18 + 2 * (num47 - 1));
							if (num44 > intNodeCount) {
								num44 = (short)(intNodeCount - ((short)unchecked(num44 - intNodeCount) - 1));
							}
							Node [num44] = array7 [num47];
							Strip [num26].Nodei = num44;
						}
						num47 = (short)unchecked(Strip [num26].Nodej - num18);
						if (num47 >= 3) {
							short num44 = (short)(num18 + 2 * (num47 - 1));
							if (num44 > intNodeCount) {
								num44 = (short)(intNodeCount - ((short)unchecked(num44 - intNodeCount) - 1));
							}
							Node [num44] = array7 [num47];
							Strip [num26].Nodej = num44;
						}
					}
					array7 = null;
					Node [Strip [intStripCount].Nodej].R = (short)unchecked(-Strip [checked(num17 + 1)].Nodei);
				}
				num18 = intNodeCount;
				num17 = intStripCount;
				part2 = null;
			}
			if (intNodeCount == 0) {
				return;
			}
			short num48 = intStripCount;
			for (short num26 = 1; num26 <= num48; num26 = (short)unchecked(num26 + 1)) {
				float num19 = Node [Strip [num26].Nodej].X - Node [Strip [num26].Nodei].X;
				float num20 = Node [Strip [num26].Nodej].Y - Node [Strip [num26].Nodei].Y;
				Strip [num26].Width = (float)System.Math.Sqrt (num19 * num19 + num20 * num20);
				Strip [num26].Alpha = (float)System.Math.Atan2 (num20, num19);
				ref float a = ref Node [Strip [num26].Nodei].A;
				a = (float)((double)a + 0.5 * (double)Strip [num26].Width * (double)Strip [num26].Thickness);
				ref float a2 = ref Node [Strip [num26].Nodej].A;
				a2 = (float)((double)a2 + 0.5 * (double)Strip [num26].Width * (double)Strip [num26].Thickness);
			}
			short num49 = 0;
			float num50 = 0f;
			short num51 = intNodeCount;
			for (short num44 = 1; num44 <= num51; num44 = (short)unchecked(num44 + 1)) {
				Node [num44].F = num9 + num10 * (Node [num44].Y - Section1.Prop.Ycg) / num7 + num11 * (Node [num44].X - Section1.Prop.Xcg) / num8 + num16 * Node [num44].Wn / num13;
				if (Node [num44].F > num50) {
					num50 = Node [num44].F;
				}
				short r = Node [num44].R;
				if (r < 0) {
					Node [num44].DOFx = Node [(short)unchecked(-r)].DOFx;
					Node [num44].DOFz = Node [(short)unchecked(-r)].DOFz;
					Node [num44].DOFy = Node [(short)unchecked(-r)].DOFy;
					Node [num44].DOFr = Node [(short)unchecked(-r)].DOFr;
				} else {
					if ((r & 1) == 0) {
						num49 = (short)(num49 + 1);
						Node [num44].DOFx = num49;
					}
					if ((r & 4) == 0) {
						num49 = (short)(num49 + 1);
						Node [num44].DOFz = num49;
					}
					if ((r & 2) == 0) {
						num49 = (short)(num49 + 1);
						Node [num44].DOFy = num49;
					}
					if ((r & 8) == 0) {
						num49 = (short)(num49 + 1);
						Node [num44].DOFr = num49;
					}
				}
			}
			double[] array8 = new double[num49 + 1];
			double[,] array9 = new double[num49 + 1, num49 + 1];
			double[] array10 = new double[num49 + 1];
			double[] array11 = new double[num49 + 1];
			double[] array12 = new double[num49 + 1];
			float num52 = Section1.Material.Eo [4];
			float num53 = Section1.Material.Eo [2];
			float num54 = Section1.Material.Eo [5];
			float num55 = num52 / (2f * num54) - 1f;
			float num56 = num53 / (2f * num54) - 1f;
			float num57 = num52 / (1f - num55 * num56);
			float num58 = num53 / (1f - num55 * num56);
			array [0] = 1f;
			array [1] = 1.125f;
			array [2] = 1.25f;
			array [3] = 1.4f;
			array [4] = 1.6f;
			array [5] = 1.75f;
			array [6] = 2f;
			array [7] = 2.25f;
			array [8] = 2.5f;
			array [9] = 2.8f;
			array [10] = 3.2f;
			array [11] = 3.5f;
			array [12] = 4f;
			array [13] = 4.5f;
			array [14] = 5f;
			array [15] = 5.6f;
			array [16] = 6.4f;
			array [17] = 7f;
			array [18] = 8f;
			array [19] = 9f;
			short num59 = default(short);
			switch (resolution) {
			case 1:
				num59 = 1;
				break;
			case 2:
				num59 = 2;
				break;
			case 3:
				num59 = 4;
				break;
			}
			short num60 = (short)System.Math.Round (1.0 + Conversion.Int ((System.Math.Log10 (lmax / lmin) * 20.0 + 0.1) / (double)num59));
			short num61 = (short)(4 * num60 - 3);
			Buckle = new BuckleState[num61 + 1];
			ModeShape = new ModeShapeType[intNodeCount + 1, num60 + 1];
			My.MyProject.Forms.frmBuckleProgress.prgBuckle.Maximum = num60;
			short num62 = 1;
			float num63 = 1f;
			short num67 = default(short);
			short num68 = default(short);
			short num69 = default(short);
			short num70 = default(short);
			float num119 = default(float);
			float lF = default(float);
			float workRatio = default(float);
			float num122 = default(float);
			float num123 = default(float);
			float num124 = default(float);
			float workRatio2 = default(float);
			bool flag = default(bool);
			float num136 = default(float);
			float num137 = default(float);
			short num138 = default(short);
			while (true) {
				short num64 = num59;
				short num65 = 0;
				while (true) {
					if (unchecked(((short)(num64 >> 15) ^ num65) <= ((short)(num64 >> 15) ^ 0x13))) {
						num27 = lmin * num63 * array [num65];
						if (num27 > lmax) {
							num61 = (short)(num62 - 4);
						}
						if (num62 <= num61) {
							Buckle [num62].Length = num27;
							Buckle [num62].HoleMode = HoleMode.Gross;
							num62 = (short)(num62 + 4);
							num65 = (short)unchecked(num65 + num64);
							continue;
						}
					} else {
						num63 *= 10f;
						if (!(num27 > lmax)) {
							break;
						}
					}
					Buckle = (BuckleState[])Utils.CopyArray (Buckle, new BuckleState[num61 + 1]);
					num60 = 0;
					int num66 = 1;
					do {
						if (num66 == 1) {
							num67 = 1;
							num68 = num61;
							num69 = 4;
						}
						if (num66 == 2) {
							num67 = (short)(num61 + 1);
							num68 = (short)unchecked(num61 + num70);
							num69 = 1;
						}
						short num71 = num67;
						short num72 = num68;
						short num73 = num69;
						num62 = num71;
						while (unchecked(((short)(num73 >> 15) ^ num62) <= ((short)(num73 >> 15) ^ num72))) {
							My.MyProject.Forms.frmBuckleProgress.lblLength.Text = "Length = " + Units.DisplayLength (Buckle [num62].Length, 0, blnShowUnit: true, "", 0, 0);
							if (num66 == 2) {
								num = 0f;
								float num74 = 0f;
								float num75 = 0f;
								num5 = 0f;
								num4 = 0f;
								num6 = 0f;
								float num76 = Node [0].X;
								float num77 = Node [0].Y;
								num8 = num76;
								num7 = num77;
								short num78 = intStripCount;
								for (short num26 = 1; num26 <= num78; num26 = (short)unchecked(num26 + 1)) {
									float width = Strip [num26].Width;
									float thickness = Strip [num26].Thickness;
									if ((Buckle [num62].HoleMode == HoleMode.Local) & (Strip [num26].HoleLength >= Buckle [num62].Length)) {
										thickness = 0f;
									}
									if ((Buckle [num62].HoleMode == HoleMode.Distortional) & (Strip [num26].HoleLength != 0f)) {
										float num79 = Buckle [num62].Length;
										if (Section1.HoleSpacing < num79) {
											num79 = Section1.HoleSpacing;
										}
										if (num79 < System.Math.Abs (Strip [num26].HoleLength)) {
											num79 = System.Math.Abs (Strip [num26].HoleLength);
										}
										thickness = (float)((double)thickness * System.Math.Pow (1f - System.Math.Abs (Strip [num26].HoleLength) / num79, 0.333));
									}
									if (((Buckle [num62].HoleMode == HoleMode.Local) & (Strip [num26].HoleLength >= Buckle [num62].Length)) && ((short)unchecked(num62 + num69) > num68 || Buckle [(short)unchecked(num62 + num69)].HoleMode != HoleMode.Local || Buckle [(short)unchecked(num62 + num69)].Length > Strip [num26].HoleLength)) {
										Buckle [num62].HoleMarker = true;
									}
									float x = Node [Strip [num26].Nodei].X;
									float y = Node [Strip [num26].Nodei].Y;
									float x2 = Node [Strip [num26].Nodej].X;
									float y2 = Node [Strip [num26].Nodej].Y;
									num76 = (float)CFS.Min (num76, x, x2);
									num77 = (float)CFS.Min (num77, y, y2);
									num8 = (float)CFS.Max (num8, x, x2);
									num7 = (float)CFS.Max (num7, y, y2);
									float num19 = x2 - x;
									float num20 = y2 - y;
									float num35 = (x + x2) / 2f;
									float num36 = (y + y2) / 2f;
									num += width * thickness;
									num74 += width * thickness * num35;
									num75 += width * thickness * num36;
									num4 += width * thickness * (num20 * num20 / 12f + num36 * num36);
									num5 += width * thickness * (num19 * num19 / 12f + num35 * num35);
									num6 += width * thickness * (num19 * num20 / 12f + num35 * num36);
								}
								float num80 = num74 / num;
								float num81 = num75 / num;
								num4 -= num * num81 * num81;
								num5 -= num * num80 * num80;
								num6 -= num * num81 * num80;
								num8 = (float)CFS.Max (num8 - num80, num80 - num76);
								num7 = (float)CFS.Max (num7 - num81, num81 - num77);
								num2 = num4 / num7;
								num3 = num5 / num8;
								if (!constrained) {
									num10 = (fbx * num4 * num5 - fby * num6 * num4 * num3 / num2) / (num4 * num5 - num6 * num6);
									num11 = (fby * num4 * num5 - fbx * num6 * num5 * num2 / num3) / (num4 * num5 - num6 * num6);
								}
								num50 = 0f;
								short num82 = intNodeCount;
								for (short num44 = 1; num44 <= num82; num44 = (short)unchecked(num44 + 1)) {
									Node [num44].F = num9 + num10 * (Node [num44].Y - num81) / num7 + num11 * (Node [num44].X - num80) / num8;
									if (Node [num44].F > num50) {
										num50 = Node [num44].F;
									}
								}
							}
							double[,] array13 = new double[num49 + 1, num49 + 1];
							double[,] array14 = new double[num49 + 1, num49 + 1];
							num27 = Buckle [num62].Length;
							short num83 = intStripCount;
							short num90;
							for (short num26 = 1; num26 <= num83; num26 = (short)unchecked(num26 + 1)) {
								float num84 = (float)(System.Math.PI / (double)num27);
								float thickness = Strip [num26].Thickness;
								if ((Buckle [num62].HoleMode == HoleMode.Local) & (Strip [num26].HoleLength >= Buckle [num62].Length)) {
									thickness = 0f;
								}
								if ((Buckle [num62].HoleMode == HoleMode.Distortional) & (Strip [num26].HoleLength != 0f)) {
									float num79 = Buckle [num62].Length;
									if (Section1.HoleSpacing < num79) {
										num79 = Section1.HoleSpacing;
									}
									if (num79 < System.Math.Abs (Strip [num26].HoleLength)) {
										num79 = System.Math.Abs (Strip [num26].HoleLength);
									}
									thickness = (float)((double)thickness * System.Math.Pow (1f - System.Math.Abs (Strip [num26].HoleLength) / num79, 0.333));
								}
								float width = Strip [num26].Width;
								float num85 = (float)((double)num52 * System.Math.Pow (thickness, 3.0) / (double)(12f * (1f - num55 * num56)));
								float num86 = (float)((double)num53 * System.Math.Pow (thickness, 3.0) / (double)(12f * (1f - num55 * num56)));
								loc = (float)((double)(num55 * num53) * System.Math.Pow (thickness, 3.0) / (double)(12f * (1f - num55 * num56)));
								float num87 = (float)((double)num54 * System.Math.Pow (thickness, 3.0) / 12.0);
								Array.Clear (array2, 0, array2.Length);
								array2 [1, 1] = (double)thickness * ((double)(num27 * num57 / (2f * width)) + (double)(num27 * width) * System.Math.Pow (num84, 2.0) * (double)num54 / 6.0);
								array2 [2, 2] = (double)thickness * ((double)(num27 * width) * System.Math.Pow (num84, 2.0) * (double)num58 / 6.0 + (double)(num27 * num54 / (2f * width)));
								array2 [3, 3] = array2 [1, 1];
								array2 [4, 4] = array2 [2, 2];
								array2 [2, 1] = thickness * (num27 * num84 * num55 * num58 / 4f - num27 * num84 * num54 / 4f);
								array2 [3, 1] = (double)thickness * ((double)((0f - num27) * num57 / (2f * width)) + (double)(num27 * width) * System.Math.Pow (num84, 2.0) * (double)num54 / 12.0);
								array2 [4, 1] = thickness * (num27 * num84 * num55 * num58 / 4f + num27 * num84 * num54 / 4f);
								array2 [3, 2] = 0.0 - array2 [4, 1];
								array2 [4, 2] = (double)thickness * ((double)(num27 * width) * System.Math.Pow (num84, 2.0) * (double)num58 / 12.0 - (double)(num27 * num54 / (2f * width)));
								array2 [4, 3] = 0.0 - array2 [2, 1];
								array2 [5, 5] = (double)(13f * num27 * width / 70f) * System.Math.Pow (num84, 4.0) * (double)num86 + (double)(12f * num27 / (5f * width)) * System.Math.Pow (num84, 2.0) * (double)num87 + (double)(6f * num27 / (5f * width)) * System.Math.Pow (num84, 2.0) * (double)loc + (double)(6f * num27) / System.Math.Pow (width, 3.0) * (double)num85;
								array2 [6, 6] = (double)num27 * System.Math.Pow (width, 3.0) / 210.0 * System.Math.Pow (num84, 4.0) * (double)num86 + (double)(4f * num27 * width / 15f) * System.Math.Pow (num84, 2.0) * (double)num87 + (double)(2f * num27 * width / 15f) * System.Math.Pow (num84, 2.0) * (double)loc + (double)(2f * num27 / width * num85);
								array2 [7, 7] = array2 [5, 5];
								array2 [8, 8] = array2 [6, 6];
								array2 [6, 5] = (double)(3f * num27 / 5f) * System.Math.Pow (num84, 2.0) * (double)loc + (double)(num27 / 5f) * System.Math.Pow (num84, 2.0) * (double)num87 + (double)(3f * num27) / System.Math.Pow (width, 2.0) * (double)num85 + (double)(11f * num27) * System.Math.Pow (width, 2.0) / 420.0 * System.Math.Pow (num84, 4.0) * (double)num86;
								array2 [7, 5] = (double)(9f * num27 * width / 140f) * System.Math.Pow (num84, 4.0) * (double)num86 - (double)(12f * num27 / (5f * width)) * System.Math.Pow (num84, 2.0) * (double)num87 - (double)(6f * num27 / (5f * width)) * System.Math.Pow (num84, 2.0) * (double)loc - (double)(6f * num27) / System.Math.Pow (width, 3.0) * (double)num85;
								array2 [8, 5] = (double)(-13f * num27) * System.Math.Pow (width, 2.0) / 840.0 * System.Math.Pow (num84, 4.0) * (double)num86 + (double)(num27 / 5f) * System.Math.Pow (num84, 2.0) * (double)num87 + (double)(num27 / 10f) * System.Math.Pow (num84, 2.0) * (double)loc + (double)(3f * num27) / System.Math.Pow (width, 2.0) * (double)num85;
								array2 [7, 6] = 0.0 - array2 [8, 5];
								array2 [8, 6] = (double)(-3f * num27) * System.Math.Pow (width, 3.0) / 840.0 * System.Math.Pow (num84, 4.0) * (double)num86 - (double)(num27 * width / 15f) * System.Math.Pow (num84, 2.0) * (double)num87 - (double)(num27 * width / 30f) * System.Math.Pow (num84, 2.0) * (double)loc + (double)(num27 / width * num85);
								array2 [8, 7] = 0.0 - array2 [6, 5];
								float num88 = (float)((double)width * System.Math.PI * System.Math.PI / (double)(1680f * num27));
								float num39 = Node [Strip [num26].Nodei].F * thickness * num88;
								float num40 = Node [Strip [num26].Nodej].F * thickness * num88;
								Array.Clear (array3, 0, array3.Length);
								array3 [1, 1] = 70f * (3f * num39 + num40);
								array3 [2, 2] = array3 [1, 1];
								array3 [3, 3] = 70f * (num39 + 3f * num40);
								array3 [4, 4] = array3 [3, 3];
								array3 [3, 1] = 70f * (num39 + num40);
								array3 [4, 2] = array3 [3, 1];
								array3 [5, 5] = 24f * (10f * num39 + 3f * num40);
								array3 [6, 6] = width * width * (5f * num39 + 3f * num40);
								array3 [7, 7] = 24f * (3f * num39 + 10f * num40);
								array3 [8, 8] = width * width * (3f * num39 + 5f * num40);
								array3 [6, 5] = 2f * width * (15f * num39 + 7f * num40);
								array3 [7, 5] = 54f * (num39 + num40);
								array3 [7, 6] = 2f * width * (6f * num39 + 7f * num40);
								array3 [8, 5] = -2f * width * (7f * num39 + 6f * num40);
								array3 [8, 6] = -3f * width * width * (num39 + num40);
								array3 [8, 7] = -2f * width * (7f * num39 + 15f * num40);
								short num89 = 1;
								do {
									for (num90 = (short)(num89 + 1); num90 <= 8; num90 = (short)unchecked(num90 + 1)) {
										array2 [num89, num90] = array2 [num90, num89];
										array3 [num89, num90] = array3 [num90, num89];
									}
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 7);
								array4 [1, 1] = System.Math.Cos (Strip [num26].Alpha);
								array4 [2, 2] = 1.0;
								array4 [3, 3] = array4 [1, 1];
								array4 [4, 4] = 1.0;
								array4 [5, 5] = array4 [1, 1];
								array4 [6, 6] = 1.0;
								array4 [7, 7] = array4 [1, 1];
								array4 [8, 8] = 1.0;
								array4 [5, 1] = System.Math.Sin (Strip [num26].Alpha);
								array4 [1, 5] = 0.0 - array4 [5, 1];
								array4 [7, 3] = array4 [5, 1];
								array4 [3, 7] = 0.0 - array4 [7, 3];
								Array.Clear (array5, 0, array5.Length);
								num89 = 1;
								do {
									num90 = 1;
									do {
										short num91 = 1;
										do {
											array5 [num89, num90] += array2 [num89, num91] * array4 [num90, num91];
											num91 = (short)unchecked(num91 + 1);
										} while (num91 <= 8);
										num90 = (short)unchecked(num90 + 1);
									} while (num90 <= 8);
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 8);
								Array.Clear (array2, 0, array2.Length);
								num89 = 1;
								do {
									num90 = 1;
									do {
										short num91 = 1;
										do {
											array2 [num89, num90] += array4 [num89, num91] * array5 [num91, num90];
											num91 = (short)unchecked(num91 + 1);
										} while (num91 <= 8);
										num90 = (short)unchecked(num90 + 1);
									} while (num90 <= 8);
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 8);
								Array.Clear (array5, 0, array5.Length);
								num89 = 1;
								do {
									num90 = 1;
									do {
										short num91 = 1;
										do {
											array5 [num89, num90] += array3 [num89, num91] * array4 [num90, num91];
											num91 = (short)unchecked(num91 + 1);
										} while (num91 <= 8);
										num90 = (short)unchecked(num90 + 1);
									} while (num90 <= 8);
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 8);
								Array.Clear (array3, 0, array3.Length);
								num89 = 1;
								do {
									num90 = 1;
									do {
										short num91 = 1;
										do {
											array3 [num89, num90] += array4 [num89, num91] * array5 [num91, num90];
											num91 = (short)unchecked(num91 + 1);
										} while (num91 <= 8);
										num90 = (short)unchecked(num90 + 1);
									} while (num90 <= 8);
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 8);
								array6 [1] = Node [Strip [num26].Nodei].DOFx;
								array6 [2] = Node [Strip [num26].Nodei].DOFz;
								array6 [3] = Node [Strip [num26].Nodej].DOFx;
								array6 [4] = Node [Strip [num26].Nodej].DOFz;
								array6 [5] = Node [Strip [num26].Nodei].DOFy;
								array6 [6] = Node [Strip [num26].Nodei].DOFr;
								array6 [7] = Node [Strip [num26].Nodej].DOFy;
								array6 [8] = Node [Strip [num26].Nodej].DOFr;
								num89 = 1;
								do {
									num90 = 1;
									do {
										array13 [array6 [num89], array6 [num90]] = array13 [array6 [num89], array6 [num90]] + array2 [num89, num90];
										array14 [array6 [num89], array6 [num90]] = array14 [array6 [num89], array6 [num90]] + array3 [num89, num90];
										num90 = (short)unchecked(num90 + 1);
									} while (num90 <= 8);
									num89 = (short)unchecked(num89 + 1);
								} while (num89 <= 8);
							}
							if (Buckle [num62].HoleMode == HoleMode.Local) {
								short num92 = num49;
								for (short num89 = 1; num89 <= num92; num89 = (short)unchecked(num89 + 1)) {
									if (array13 [num89, num89] == 0.0) {
										array13 [num89, num89] = num53 * num27;
									}
								}
							}
							short NR;
							if (altMethod) {
								double[,] array15 = new double[num49 + 1, num49 + 1];
								double[,] array16 = new double[num49 + 1, num49 + 1];
								Array.Copy (array13, array15, (int)System.Math.Round (System.Math.Pow (num49 + 1, 2.0)));
								Array.Copy (array14, array16, (int)System.Math.Round (System.Math.Pow (num49 + 1, 2.0)));
								Jacobi (array15, array16, num49, array8, array9);
								array15 = null;
								array16 = null;
							} else {
								short nDOF = num49;
								NR = 1;
								Sturm.SturmSolve (array13, array14, nDOF, array8, array9, ref NR);
							}
							Application.DoEvents ();
							if (My.MyProject.Forms.frmBuckleProgress.DialogResult == DialogResult.Cancel) {
								return;
							}
							double num93 = 1E+308;
							num90 = 0;
							NR = num49;
							for (short num91 = 1; num91 <= NR; num91 = (short)unchecked(num91 + 1)) {
								if ((array8 [num91] > 0.0) & (array8 [num91] < num93)) {
									num93 = array8 [num91];
									num90 = num91;
								}
							}
							num60 = (short)(num60 + 1);
							Buckle [num62].Length = num27;
							Buckle [num62].LF = (float)array8 [num90];
							Buckle [num62].P = Buckle [num62].LF * num9 * num;
							Buckle [num62].Mx = Buckle [num62].LF * (num10 * num2 + num11 * num3 * num6 / num5);
							Buckle [num62].My = Buckle [num62].LF * (num11 * num3 + num10 * num2 * num6 / num4);
							if ((double)System.Math.Abs (Buckle [num62].Mx) < 1E-06 * (double)System.Math.Abs (Buckle [num62].My)) {
								Buckle [num62].Mx = 0f;
							}
							if ((double)System.Math.Abs (Buckle [num62].My) < 1E-06 * (double)System.Math.Abs (Buckle [num62].Mx)) {
								Buckle [num62].My = 0f;
							}
							Buckle [num62].Fmax = num50;
							Buckle [num62].ModeShape = num60;
							if (num90 == 0) {
								Buckle [num62].ModeShape = 0;
							}
							if (num66 == 2) {
								if (num9 == 1f) {
									Buckle [num62].LF = Buckle [num62].P / Section1.Prop.A;
								}
								if (System.Math.Abs (fbx) == 1f) {
									Buckle [num62].LF = System.Math.Abs (Buckle [num62].Mx) / Section1.Prop.Sx;
								}
								if (System.Math.Abs (fby) == 1f) {
									Buckle [num62].LF = System.Math.Abs (Buckle [num62].My) / Section1.Prop.Sy;
								}
							}
							float num94 = 0f;
							float num95 = 0f;
							float num96 = 0f;
							float num97 = 0f;
							float num98 = 0f;
							short num99 = intNodeCount;
							for (short num44 = 1; num44 <= num99; num44 = (short)unchecked(num44 + 1)) {
								ref ModeShapeType reference = ref ModeShape [num44, num60];
								reference.DX = (float)array9 [Node [num44].DOFx, num90];
								reference.DY = (float)array9 [Node [num44].DOFy, num90];
								reference.DZ = (float)array9 [Node [num44].DOFz, num90];
								reference.Rot = (float)array9 [Node [num44].DOFr, num90];
								num94 += reference.DX * Node [num44].A;
								num95 += reference.DY * Node [num44].A;
								num96 += reference.Rot;
								num97 += reference.Rot * reference.Rot;
								num98 += Node [num44].A;
							}
							short num101;
							unchecked {
								if (num66 == 1) {
									My.MyProject.Forms.frmBuckleProgress.prgBuckle.Value = checked(num62 + 3) / 4;
								}
								num94 /= num98;
								num95 /= num98;
								num96 /= (float)intNodeCount;
								float num100 = num97 / (float)intNodeCount - num96 * num96;
								num100 = ((!(num100 > 0f)) ? 0f : ((float)System.Math.Sqrt (num100)));
								num96 = ((!(num100 > System.Math.Abs (num96) / 4f)) ? (num96 * (1f - 4f * num100 / System.Math.Abs (num96))) : 0f);
								Array.Clear (array11, 0, array11.Length);
								Array.Clear (array10, 0, array10.Length);
								num101 = intNodeCount;
							}
							for (short num44 = 1; num44 <= num101; num44 = (short)unchecked(num44 + 1)) {
								array11 [Node [num44].DOFx] = array9 [Node [num44].DOFx, num90] - (double)(num94 - (Node [num44].Y - Node [0].Y) * num96);
								array11 [Node [num44].DOFy] = array9 [Node [num44].DOFy, num90] - (double)(num95 + (Node [num44].X - Node [0].X) * num96);
								array11 [Node [num44].DOFr] = array9 [Node [num44].DOFr, num90] - (double)num96;
								array10 [Node [num44].DOFz] = array9 [Node [num44].DOFz, num90];
							}
							int num102 = num49;
							for (int k = 1; k <= num102; k++) {
								array12 [k] = 0.0;
								int num103 = num49;
								for (int l = 1; l <= num103; l++) {
									array12 [k] += array13 [k, l] * array11 [l];
								}
							}
							double num104 = 0.0;
							int num105 = num49;
							for (int m = 1; m <= num105; m++) {
								num104 += 0.5 * array11 [m] * array12 [m];
							}
							int num106 = num49;
							for (int n = 1; n <= num106; n++) {
								array12 [n] = 0.0;
								int num107 = num49;
								for (int num108 = 1; num108 <= num107; num108++) {
									array12 [n] += array13 [n, num108] * array10 [num108];
								}
							}
							double num109 = 0.0;
							int num110 = num49;
							for (int num111 = 1; num111 <= num110; num111++) {
								num109 += 0.5 * array10 [num111] * array12 [num111];
							}
							Buckle [num62].WorkRatio = (float)System.Math.Sqrt (num104 / num109);
							if ((Buckle [num62].HoleMode == HoleMode.Distortional) & !IsDistortionalBuckling (Buckle [num62].WorkRatio)) {
								num60 = (short)(num60 - 1);
								short num112 = (short)(num61 - 1);
								short num113;
								for (num113 = 1; num113 <= num112; num113 = (short)unchecked(num113 + 1)) {
									if (Buckle [num113].Length == Buckle [num62].Length) {
										if (IsGlobalBuckling (Buckle [num113 + 1].WorkRatio)) {
											num113 = num61;
											break;
										}
										Buckle [num62].Length = Buckle [num113 + 1].Length;
										num62 = (short)(num62 - 1);
										break;
									}
								}
								if (num113 >= num61) {
									num70 = (short)(num70 - 1);
									short num114 = num62;
									short num115 = (short)unchecked(num61 + num70);
									for (num113 = num114; num113 <= num115; num113 = (short)unchecked(num113 + 1)) {
										Buckle [num113] = Buckle [num113 + 1];
									}
									Buckle = (BuckleState[])Utils.CopyArray (Buckle, new BuckleState[(short)unchecked(num61 + num70) + 1]);
								}
							}
							num62 = (short)unchecked(num62 + num73);
						}
						if (num66 == 2) {
							break;
						}
						float num116 = (float)System.Math.Log (Buckle [1].Length);
						float num117 = Buckle [1].LF;
						float num118 = Buckle [1].WorkRatio;
						if (Information.UBound (Buckle) >= 5) {
							num119 = (float)System.Math.Log (Buckle [5].Length);
							lF = Buckle [5].LF;
							workRatio = Buckle [5].WorkRatio;
						}
						num62 = 0;
						short num120 = (short)Information.UBound (Buckle);
						for (short num121 = 1; num121 <= num120; num121 = (short)unchecked(num121 + 1)) {
							if (unchecked(num121 % 4) == 1) {
								num62 = num121;
								if (num62 + 8 <= Information.UBound (Buckle)) {
									num122 = num116;
									num123 = num117;
									num124 = num118;
									num116 = num119;
									num117 = lF;
									num118 = workRatio;
									num119 = (float)System.Math.Log (Buckle [num62 + 8].Length);
									lF = Buckle [num62 + 8].LF;
									workRatio = Buckle [num62 + 8].WorkRatio;
								}
							} else {
								unchecked {
									float num35 = (float)System.Math.Log (Buckle [num62].Length + (Buckle [checked(num62 + 4)].Length - Buckle [num62].Length) * (float)(checked(num121 - 1) % 4) / 4f);
									float num36;
									if (num123 > 0f && num117 > 0f && lF > 0f) {
										float num125 = (num35 - num122) / (num119 - num116);
										float num126 = (num35 - num116) / (num119 - num122);
										float num127 = (num35 - num119) / (num116 - num122);
										num36 = num123 * num126 * num127 - num117 * num125 * num127 + lF * num125 * num126;
										if (num35 < num116) {
											workRatio2 = num124 + (num35 - num122) * (num118 - num124) / (num116 - num122);
										}
										if (num35 > num116) {
											workRatio2 = num118 + (num35 - num116) * (workRatio - num118) / (num119 - num116);
										}
									} else if (num123 > 0f && num117 > 0f && num35 > num122 && num35 < num116) {
										num36 = num123 + (num35 - num122) * (num117 - num123) / (num116 - num122);
										workRatio2 = num124 + (num35 - num122) * (num118 - num124) / (num116 - num122);
									} else if (num117 > 0f && lF > 0f && num35 > num116 && num35 < num119) {
										num36 = num117 + (num35 - num116) * (lF - num117) / (num119 - num116);
										workRatio2 = num118 + (num35 - num116) * (workRatio - num118) / (num119 - num116);
									} else {
										num36 = 0f;
										workRatio2 = 0f;
									}
									_ = Section1.Prop;
									Buckle [num121].Length = (float)System.Math.Exp (num35);
									Buckle [num121].HoleMode = HoleMode.Gross;
									Buckle [num121].LF = num36;
									Buckle [num121].P = Buckle [num121].LF * num9 * num;
									Buckle [num121].Mx = Buckle [num121].LF * (num10 * num2 + num11 * num3 * num6 / num5);
									Buckle [num121].My = Buckle [num121].LF * (num11 * num3 + num10 * num2 * num6 / num4);
									if ((double)System.Math.Abs (Buckle [num121].Mx) < 1E-06 * (double)System.Math.Abs (Buckle [num121].My)) {
										Buckle [num121].Mx = 0f;
									}
									if ((double)System.Math.Abs (Buckle [num121].My) < 1E-06 * (double)System.Math.Abs (Buckle [num121].Mx)) {
										Buckle [num121].My = 0f;
									}
									Buckle [num121].Fmax = num50;
									Buckle [num121].ModeShape = 0;
									Buckle [num121].WorkRatio = workRatio2;
								}
							}
						}
						if (Section1.Prop.An == Section1.Prop.A || !((num9 == 1f) | (System.Math.Abs (fbx) == 1f) | (System.Math.Abs (fby) == 1f))) {
							break;
						}
						if (unchecked(holeLength >= lmin && holeLength <= lmax)) {
							short num128 = num61;
							for (num62 = 1; num62 <= num128; num62 = (short)unchecked(num62 + 4)) {
								num70 = (short)(num70 + 1);
								if ((double)Buckle [num62].Length > 0.95 * (double)holeLength) {
									break;
								}
							}
							Buckle = (BuckleState[])Utils.CopyArray (Buckle, new BuckleState[(short)unchecked(num61 + num70) + 1]);
							short num129 = num70;
							for (num62 = 1; num62 <= num129; num62 = (short)unchecked(num62 + 1)) {
								Buckle [(short)unchecked(num61 + num62)].Length = Buckle [num62 * 4 - 3].Length;
								if (num62 == num70) {
									Buckle [(short)unchecked(num61 + num62)].Length = holeLength;
								}
								Buckle [(short)unchecked(num61 + num62)].HoleMode = HoleMode.Local;
							}
						}
						short num130 = 0;
						short num131 = num61;
						for (num62 = 2; num62 <= num131; num62 = (short)unchecked(num62 + 1)) {
							if ((num62 < num61) & IsDistortionalBuckling (Buckle [num62].WorkRatio)) {
								if (num130 == 0) {
									num130 = num62;
								}
								if ((Buckle [num62].LF < Buckle [num62 - 1].LF) & (Buckle [num62].LF < Buckle [num62 + 1].LF)) {
									num70 = (short)(num70 + 1);
									Buckle = (BuckleState[])Utils.CopyArray (Buckle, new BuckleState[(short)unchecked(num61 + num70) + 1]);
									Buckle [(short)unchecked(num61 + num70)].Length = Buckle [num62].Length;
									Buckle [(short)unchecked(num61 + num70)].HoleMode = HoleMode.Distortional;
									num130 = -1;
								}
							} else if (num130 > 0) {
								int num132 = num130 + 1;
								int num133 = num62 - 1;
								for (int num134 = num132; num134 <= num133; num134++) {
									float num135 = (float)((double)(Buckle [num134].LF - Buckle [num134 - 1].LF) / System.Math.Log10 (Buckle [num134].Length / Buckle [num134 - 1].Length));
									if (num135 < 0f) {
										break;
									}
									if (!flag) {
										unchecked {
											if (num134 == checked(num130 + 1) || num135 > num136) {
												num136 = num135;
											}
										}
										if (((double)num135 < 0.9 * (double)num136) & (num135 / Buckle [num62].LF < 1f)) {
											flag = true;
											num137 = num135;
											num138 = (short)num134;
										}
										continue;
									}
									if (num135 < num137) {
										num137 = num135;
										num138 = (short)num134;
									}
									if ((double)num135 > 1.1 * (double)num137) {
										num70 = (short)(num70 + 1);
										Buckle = (BuckleState[])Utils.CopyArray (Buckle, new BuckleState[(short)unchecked(num61 + num70) + 1]);
										Buckle [(short)unchecked(num61 + num70)].Length = Buckle [num138].Length;
										Buckle [(short)unchecked(num61 + num70)].HoleMode = HoleMode.Distortional;
										break;
									}
								}
								num130 = 0;
							} else if (num130 < 0) {
								num130 = 0;
							}
						}
						ModeShape = (ModeShapeType[,])Utils.CopyArray (ModeShape, new ModeShapeType[intNodeCount + 1, (short)unchecked(num60 + num70) + 1]);
						num66++;
					} while (num66 <= 2);
					return;
				}
			}
		}
	}

	private static void Jacobi (double[,] A, double[,] B, short N, double[] V, double[,] X)
	{
		checked {
			double[] array = new double[N + 1];
			double num = 0.0001;
			double num2 = 0.0;
			short num3 = N;
			for (short num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
				if (System.Math.Abs (B [num4, num4]) > num2) {
					num2 = System.Math.Abs (B [num4, num4]);
				}
			}
			num2 *= 1E-20;
			short num5 = N;
			for (short num4 = 1; num4 <= num5; num4 = (short)unchecked(num4 + 1)) {
				if (A [num4, num4] == 0.0) {
					throw ProjectData.CreateProjectError (5);
				}
				if (System.Math.Abs (B [num4, num4]) < num2) {
					B [num4, num4] = num2;
				}
				array [num4] = A [num4, num4] / B [num4, num4];
				V [num4] = array [num4];
			}
			short num6 = N;
			for (short num4 = 1; num4 <= num6; num4 = (short)unchecked(num4 + 1)) {
				short num7 = N;
				for (short num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
					X [num4, num8] = 0.0;
				}
				X [num4, num4] = 1.0;
			}
			if (N == 1) {
				return;
			}
			short num9 = 1;
			while (true) {
				Application.DoEvents ();
				if (My.MyProject.Forms.frmBuckleProgress.DialogResult == DialogResult.Cancel) {
					break;
				}
				double num10 = System.Math.Pow (0.01, 2 * num9);
				short num11 = (short)(N - 1);
				short num4;
				for (short num8 = 1; num8 <= num11; num8 = (short)unchecked(num8 + 1)) {
					short num12 = (short)(num8 + 1);
					short num13 = N;
					for (short num14 = num12; num14 <= num13; num14 = (short)unchecked(num14 + 1)) {
						double num15 = A [num8, num14] * A [num8, num14] / (A [num8, num8] * A [num14, num14]);
						double num16 = B [num8, num14] * B [num8, num14] / (B [num8, num8] * B [num14, num14]);
						if (unchecked(num15 > num10 || num16 > num10)) {
							double num17 = A [num14, num14] * B [num8, num14] - B [num14, num14] * A [num8, num14];
							double num18 = A [num8, num8] * B [num8, num14] - B [num8, num8] * A [num8, num14];
							double num19 = A [num8, num8] * B [num14, num14] - A [num14, num14] * B [num8, num8];
							num2 = (num19 * num19 + 4.0 * num17 * num18) / 4.0;
							if (num2 < 0.0) {
								throw ProjectData.CreateProjectError (5);
							}
							double num20 = ((!(num19 > 0.0)) ? (num19 / 2.0 - System.Math.Sqrt (num2)) : (num19 / 2.0 + System.Math.Sqrt (num2)));
							double num21;
							double num22;
							if (num20 != 0.0) {
								num21 = num17 / num20;
								num22 = (0.0 - num18) / num20;
							} else {
								num21 = 0.0;
								num22 = (0.0 - A [num8, num14]) / A [num14, num14];
							}
							short num23 = (short)(num8 - 1);
							double num25;
							for (num4 = 1; num4 <= num23; num4 = (short)unchecked(num4 + 1)) {
								num18 = A [num4, num8];
								double num24 = B [num4, num8];
								num17 = A [num4, num14];
								num25 = B [num4, num14];
								A [num4, num8] = num18 + num22 * num17;
								B [num4, num8] = num24 + num22 * num25;
								A [num4, num14] = num17 + num21 * num18;
								B [num4, num14] = num25 + num21 * num24;
							}
							short num26 = (short)(num14 + 1);
							short num27 = N;
							for (num4 = num26; num4 <= num27; num4 = (short)unchecked(num4 + 1)) {
								num18 = A [num8, num4];
								double num24 = B [num8, num4];
								num17 = A [num14, num4];
								num25 = B [num14, num4];
								A [num8, num4] = num18 + num22 * num17;
								B [num8, num4] = num24 + num22 * num25;
								A [num14, num4] = num17 + num21 * num18;
								B [num14, num4] = num25 + num21 * num24;
							}
							short num28 = (short)(num8 + 1);
							short num29 = (short)(num14 - 1);
							for (num4 = num28; num4 <= num29; num4 = (short)unchecked(num4 + 1)) {
								num18 = A [num8, num4];
								double num24 = B [num8, num4];
								num17 = A [num4, num14];
								num25 = B [num4, num14];
								A [num8, num4] = num18 + num22 * num17;
								B [num8, num4] = num24 + num22 * num25;
								A [num4, num14] = num17 + num21 * num18;
								B [num4, num14] = num25 + num21 * num24;
							}
							num17 = A [num14, num14];
							num25 = B [num14, num14];
							A [num14, num14] = num17 + 2.0 * num21 * A [num8, num14] + num21 * num21 * A [num8, num8];
							B [num14, num14] = num25 + 2.0 * num21 * B [num8, num14] + num21 * num21 * B [num8, num8];
							A [num8, num8] = A [num8, num8] + 2.0 * num22 * A [num8, num14] + num22 * num22 * num17;
							B [num8, num8] = B [num8, num8] + 2.0 * num22 * B [num8, num14] + num22 * num22 * num25;
							A [num8, num14] = 0.0;
							B [num8, num14] = 0.0;
							short num30 = N;
							for (num4 = 1; num4 <= num30; num4 = (short)unchecked(num4 + 1)) {
								double num31 = X [num4, num8];
								double num32 = X [num4, num14];
								X [num4, num8] = num31 + num22 * num32;
								X [num4, num14] = num32 + num21 * num31;
							}
						}
					}
				}
				short num33 = N;
				for (num4 = 1; num4 <= num33; num4 = (short)unchecked(num4 + 1)) {
					if ((A [num4, num4] == 0.0) | (B [num4, num4] == 0.0)) {
						throw ProjectData.CreateProjectError (5);
					}
					V [num4] = A [num4, num4] / B [num4, num4];
				}
				short num34 = N;
				num4 = 1;
				while (true) {
					if (num4 <= num34) {
						if (!(System.Math.Abs (V [num4] - array [num4]) > num * System.Math.Abs (array [num4]))) {
							num4 = (short)unchecked(num4 + 1);
							continue;
						}
						goto IL_06a2;
					}
					num10 = num * num;
					short num35 = (short)(N - 1);
					for (short num8 = 1; num8 <= num35; num8 = (short)unchecked(num8 + 1)) {
						short num36 = (short)(num8 + 1);
						short num37 = N;
						short num14 = num36;
						while (num14 <= num37) {
							double num38 = A [num8, num14] * A [num8, num14] / (A [num8, num8] * A [num14, num14]);
							double num16 = B [num8, num14] * B [num8, num14] / (B [num8, num8] * B [num14, num14]);
							if (!unchecked(num38 > num10 || num16 > num10)) {
								num14 = (short)unchecked(num14 + 1);
								continue;
							}
							goto IL_06a2;
						}
					}
					goto IL_06c7;
					IL_06c7:
					short num39 = (short)(N - 1);
					for (short num8 = 1; num8 <= num39; num8 = (short)unchecked(num8 + 1)) {
						short num40 = (short)(num8 + 1);
						short num41 = N;
						for (short num14 = num40; num14 <= num41; num14 = (short)unchecked(num14 + 1)) {
							A [num14, num8] = A [num8, num14];
							B [num14, num8] = B [num8, num14];
						}
					}
					short num42 = N;
					for (short num8 = 1; num8 <= num42; num8 = (short)unchecked(num8 + 1)) {
						double num24 = System.Math.Sqrt (System.Math.Abs (B [num8, num8]));
						short num43 = N;
						for (short num14 = 1; num14 <= num43; num14 = (short)unchecked(num14 + 1)) {
							X [num14, num8] /= num24;
						}
					}
					return;
					IL_06a2:
					short num44 = N;
					for (num4 = 1; num4 <= num44; num4 = (short)unchecked(num4 + 1)) {
						array [num4] = V [num4];
					}
					num9 = (short)unchecked(num9 + 1);
					if (num9 <= 15) {
						break;
					}
					goto IL_06c7;
				}
			}
		}
	}

	private static void EigenJK (double[,] Ke, double[,] Kg, short N, double[] V, double[,] X)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		double num17 = default(double);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						double[,] array = (double[,])Ke.Clone ();
						ProjectData.ClearProjectError ();
						num2 = 2;
						short num3 = 1;
						do {
							int num4 = N - 1;
							for (int i = 1; i <= num4; i++) {
								for (int j = i + 1; j <= N; j++) {
									double num5 = 0.0;
									double num6 = 0.0;
									for (int k = 1; k <= N; k++) {
										double num7 = array [k, i];
										double num8 = array [k, j];
										num5 += num7 * num8;
										num6 += (num7 + num8) * (num7 - num8);
									}
									num5 = 2.0 * num5;
									if (unchecked(System.Math.Abs (num5) < 1E-16 && num6 >= 0.0)) {
										break;
									}
									double num10;
									double num11;
									if (System.Math.Abs (num5) <= System.Math.Abs (num6)) {
										double num9 = System.Math.Abs (num5 / num6);
										num10 = 1.0 / System.Math.Sqrt (1.0 + num9 * num9);
										num11 = num9 * num10;
									} else {
										double num12 = System.Math.Abs (num6 / num5);
										num11 = 1.0 / System.Math.Sqrt (1.0 + num12 * num12);
										num10 = num12 * num11;
									}
									double num13 = System.Math.Sqrt ((1.0 + num10) / 2.0);
									double num14 = num11 / (2.0 * num13);
									if (num6 < 0.0) {
										double num15 = num13;
										num13 = num14;
										num14 = num15;
									}
									num14 = (double)System.Math.Sign (num5) * num14;
									for (int l = 1; l <= N; l++) {
										double num7 = array [l, i];
										double num8 = array [l, j];
										array [l, i] = num7 * num13 + num8 * num14;
										array [l, j] = (0.0 - num7) * num14 + num8 * num13;
									}
								}
							}
							double num16 = 0.0;
							for (int m = 1; m <= N; m++) {
								for (int n = 1; n <= N; n++) {
									num16 += array [m, n] * array [m, n];
								}
							}
							if (unchecked(System.Math.Abs (num16 - num17) < 1E-16 && num3 > 5)) {
								break;
							}
							num17 = num16;
							num3 = (short)unchecked(num3 + 1);
						} while (num3 <= 15);
						V = new double[N + 1];
						X = new double[N + 1, N + 1];
						for (int num18 = 1; num18 <= N; num18++) {
							for (int num19 = 1; num19 <= N; num19++) {
								V [num18] += System.Math.Pow (array [num19, num18], 2.0);
							}
							V [num18] = System.Math.Sqrt (V [num18]);
							for (int num20 = 1; num20 <= N; num20++) {
								if (V [num18] <= 0.0) {
									X [num20, num18] = 0.0;
								} else {
									X [num20, num18] = array [num20, num18] / V [num18];
								}
							}
						}
						break;
					}
					case 841:
						num = -1;
						switch (num2) {
						case 2:
							break;
						default:
							goto IL_037f;
						}
						break;
					}
				}
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 841;
				continue;
			}
			break;
			IL_037f:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	public static void PlotLabels (GraphicsX GX, short intLength, float Rot = 0f)
	{
		Font font = new Font ("Arial", 8f);
		Brush brush = new SolidBrush (Color.Black);
		Graphics graphics = GX.Graphics;
		float num = 6.25f;
		float y = num * GX.Height / GX.Width;
		GX.Scale (0f, 0f, num, y);
		Brush brush2 = new SolidBrush (GX.PictureBox.BackColor);
		graphics.FillRectangle (brush2, 0.5f, 0f, 2.25f, 0.25f);
		graphics.FillRectangle (brush2, 4.5f, 0f, 1.5f, 0.25f);
		graphics.FillRectangle (brush2, 4.75f, 0.25f, 1.25f, 0.75f);
		Pen pen = new Pen (Color.Black, GX.PenScale / GX.Graphics.DpiX);
		graphics.DrawRectangle (pen, 4.75f, 0.25f, 1.25f, 0.75f);
		string s = "L = " + Units.DisplayLength (Buckle [intLength].Length, 0, blnShowUnit: true, "", 0, 0);
		GX.DrawString (s, font, brush, 4.8f, 0.25f, GraphicsX.AlignText.LeftTop, 0f);
		s = "f = " + Units.DisplayStress (Buckle [intLength].LF, 0, blnShowUnit: true, "", 0, 0);
		GX.DrawString (s);
		s = "P = " + Units.DisplayForce (Buckle [intLength].P, 0, blnShowUnit: true, "", 0, 0);
		GX.DrawString (s);
		s = "Mx = " + Units.DisplayMoment (Buckle [intLength].Mx, 0, blnShowUnit: true, "", 0, 0);
		GX.DrawString (s);
		s = "My = " + Units.DisplayMoment (Buckle [intLength].My, 0, blnShowUnit: true, "", 0, 0);
		GX.DrawString (s);
		string text;
		if (Buckle [intLength].HoleMode == HoleMode.Gross) {
			s = "Gross Section";
			text = "Global Buckling";
			if (IsDistortionalBuckling (Buckle [intLength].WorkRatio)) {
				text = "Distortional Buckling";
			}
			if (IsLocalBuckling (Buckle [intLength].WorkRatio)) {
				text = "Local Buckling";
			}
		} else {
			s = "Net Section";
			text = Conversions.ToString (Interaction.IIf (Buckle [intLength].HoleMode == HoleMode.Local, "Local Buckling", "Distortional Buckling"));
		}
		GX.DrawString (s + " - " + text, font, brush, 0.5f, 0.125f, GraphicsX.AlignText.LeftCenter, 0f);
		s = "Work Ratio = " + Units.DisplayNone (Buckle [intLength].WorkRatio, "", 0, 0);
		GX.DrawString (s, font, brush, 6f, 0.125f, GraphicsX.AlignText.RightCenter, 0f);
		if (Rot != 0f) {
			float num2 = (float)(0.4 + 0.3 * System.Math.Cos (Rot));
			float num3 = (float)(0.4 - 0.3 * System.Math.Sin (Rot));
			graphics.DrawLine (pen, 0.4f, 0.4f, num2, num3);
			GX.DrawString ("X", font, brush, num2, num3, GraphicsX.AlignText.CenterCenter, (float)((double)((0f - Rot) * 180f) / System.Math.PI));
			num2 = (float)(0.4 - 0.3 * System.Math.Sin (Rot));
			num3 = (float)(0.4 - 0.3 * System.Math.Cos (Rot));
			graphics.DrawLine (pen, 0.4f, 0.4f, num2, num3);
			GX.DrawString ("Y", font, brush, num2, num3, GraphicsX.AlignText.CenterCenter, (float)((double)((0f - Rot) * 180f) / System.Math.PI));
		}
		GX.SwapScale ();
		GX.PreserveImage ();
	}

	public static void PlotModeShape (GraphicsX GX, short intLength, float Factor = 1f, bool blnRender = false, short intRotation = 0)
	{
		Pen pen = new Pen (Color.LightGray, 0f);
		Pen pen2 = new Pen (Color.Black, 0f);
		float length = Buckle [intLength].Length;
		short modeShape = Buckle [intLength].ModeShape;
		if (modeShape == 0) {
			return;
		}
		float num = Conversions.ToSingle (Interaction.IIf (blnRender, (double)intRotation * System.Math.PI / 6.0, 0));
		float num2 = (float)System.Math.Sin (num);
		float num3 = (float)System.Math.Cos (num);
		float x = Node [0].X;
		float num4 = x;
		float num5 = x;
		float y = Node [0].Y;
		float num6 = y;
		float num7 = y;
		float num8 = 0f;
		float num9 = 0f;
		short num10 = intNodeCount;
		checked {
			float num12;
			float num13;
			for (short num11 = 1; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
				num12 = Node [num11].X - x;
				num13 = Node [num11].Y - y;
				float num14 = (float)System.Math.Sqrt (num12 * num12 + num13 * num13);
				if (num14 > num9) {
					num9 = num14;
				}
				float num15 = x + num12 * num3 - num13 * num2;
				float num16 = y + num13 * num3 + num12 * num2;
				if (num15 < num4) {
					num4 = num15;
				}
				if (num15 > num5) {
					num5 = num15;
				}
				if (num16 < num6) {
					num6 = num16;
				}
				if (num16 > num7) {
					num7 = num16;
				}
				num14 = (float)System.Math.Sqrt (System.Math.Pow (ModeShape [num11, modeShape].DX, 2.0) + System.Math.Pow (ModeShape [num11, modeShape].DY, 2.0));
				if (num14 > num8) {
					num8 = num14;
				}
			}
			num12 = num5 - num4;
			num13 = num7 - num6;
			num9 = 2f * num9;
			num8 = (float)((double)num8 / (0.1 * (double)num9));
			GX.Graphics.Clear (GX.PictureBox.BackColor);
			float num17 = (float)((double)GX.PictureBox.ClientSize.Height / (double)GX.PictureBox.ClientSize.Width);
			float num19 = default(float);
			float num20 = default(float);
			if (blnRender) {
				num12 = (float)(1.6 * (double)num9);
				num13 = (float)(1.6 * (double)num9);
				if (num17 * num12 > num13) {
					num13 = num17 * num12;
				} else {
					num12 = num13 / num17;
				}
				GX.Scale (x - num12 / 2f, y + num13 / 2f, x / 2f + num12 / 2f, y - num13 / 2f);
				short num18 = (short)System.Math.Round (2f * num9 / length);
				if (num18 < 1) {
					num18 = 1;
				}
				num8 = (float)((double)num8 * System.Math.Sqrt (num18));
				num19 = (float)num18 * length;
				num20 = 10f * num9;
				pen2.Width = (float)(0.012 * (double)num9);
				GX.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			} else {
				num12 = (float)(1.25 * (double)num12);
				num13 = (float)(1.25 * (double)num13);
				if (num17 * num12 > num13) {
					num13 = num17 * num12;
				} else {
					num12 = num13 / num17;
				}
				GX.Scale ((num4 + num5) / 2f - num12 / 2f, (num6 + num7) / 2f + num13 / 2f, (num4 + num5) / 2f + num12 / 2f, (num6 + num7) / 2f - num13 / 2f);
				pen.Width = GX.PenScale / GX.Graphics.DpiX;
				pen2.Width = GX.PenScale / GX.Graphics.DpiX;
				GX.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			}
			int num21 = 240;
			do {
				float num22;
				float num23;
				float num24;
				float num26;
				float num27;
				if (blnRender) {
					num22 = (float)(0.4 * (double)num9 * ((double)num21 / 240.0 - 0.5));
					num23 = (float)(0.6 * (double)num9 * ((double)num21 / 240.0 - 0.5));
					num24 = (float)(1.0 - (double)num21 / 240.0 * (double)num19 / (double)(num20 + num19));
					float num25 = num20 / num24 - num20;
					num26 = (float)System.Math.Sin (System.Math.PI * (double)num25 / (double)length);
					num27 = (float)System.Math.Cos (System.Math.PI * (double)num25 / (double)length);
				} else {
					num21 = 0;
					num22 = 0f;
					num23 = 0f;
					num24 = 1f;
					float num25 = length / 2f;
					num26 = 1f;
					num27 = 0f;
				}
				short num28 = intStripCount;
				for (short num29 = 1; num29 <= num28; num29 = (short)unchecked(num29 + 1)) {
					if ((Buckle [intLength].HoleMode != HoleMode.Local) | (Strip [num29].HoleLength < Buckle [intLength].Length)) {
						short num11 = Strip [num29].Nodei;
						num12 = Node [num11].X - x;
						num13 = Node [num11].Y - y;
						float num15 = x + num12 * num3 - num13 * num2;
						float num16 = y + num13 * num3 + num12 * num2;
						num12 = ModeShape [num11, modeShape].DX * Factor / num8;
						num13 = ModeShape [num11, modeShape].DY * Factor / num8;
						float num30 = num12 * num3 - num13 * num2;
						float num31 = num13 * num3 + num12 * num2;
						float num32 = ModeShape [num11, modeShape].Rot * Factor / num8;
						num11 = Strip [num29].Nodej;
						num12 = Node [num11].X - x;
						num13 = Node [num11].Y - y;
						float num33 = x + num12 * num3 - num13 * num2;
						float num34 = y + num13 * num3 + num12 * num2;
						num12 = ModeShape [num11, modeShape].DX * Factor / num8;
						num13 = ModeShape [num11, modeShape].DY * Factor / num8;
						float num35 = num12 * num3 - num13 * num2;
						float num36 = num13 * num3 + num12 * num2;
						float num37 = ModeShape [num11, modeShape].Rot * Factor / num8;
						if (!blnRender) {
							GX.Graphics.DrawLine (pen, num15, num16, num33, num34);
						}
						num12 = num33 - num15;
						num13 = num34 - num16;
						float num38 = (float)System.Math.Atan2 (num13, num12);
						float num39 = (float)System.Math.Sqrt (num12 * num12 + num13 * num13);
						float num40 = (0f - (num13 * num30 - num12 * num31)) / num39;
						float num41 = (0f - (num13 * num35 - num12 * num36)) / num39;
						float num42 = num40;
						float num43 = num32;
						float num44 = (float)((double)(num32 + num37) / System.Math.Pow (num39, 2.0) - (double)(2f * (num41 - num40)) / System.Math.Pow (num39, 3.0));
						float num45 = (float)(0.5 * (double)(num37 - num32) / (double)num39 - 1.5 * (double)num44 * (double)num39);
						short num46 = (short)System.Math.Round (25f * num39 / num9);
						if (num46 < 1) {
							num46 = 1;
						}
						float num47 = num15 + num26 * num30;
						float num48 = num16 + num26 * num31;
						num15 = num47;
						num16 = num48;
						float num49 = (float)System.Math.Sin (num38);
						float num50 = (float)System.Math.Cos (num38);
						float num51 = (float)System.Math.Cos ((double)(2f * num38) + System.Math.PI / 2.0);
						short num52 = (short)System.Math.Sign (System.Math.Cos ((double)num38 + System.Math.PI / 4.0));
						if (num52 == 0) {
							num52 = 1;
						}
						short num53 = num46;
						for (short num54 = 1; num54 <= num53; num54 = (short)unchecked(num54 + 1)) {
							float num14 = num39 * (float)num54 / (float)num46;
							num14 = num42 + num43 * num14 + num45 * num14 * num14 + num44 * num14 * num14 * num14;
							num33 = num47 + num12 * (float)num54 / (float)num46 - num26 * (num14 - num40) * num49;
							num34 = num48 + num13 * (float)num54 / (float)num46 + num26 * (num14 - num40) * num50;
							if (blnRender) {
								int num55 = (int)System.Math.Round ((double)(150f + 50f * num51) + (double)((float)(50 * num52) * num27 * num14) / (0.1 * (double)num9));
								if (num55 > 250) {
									num55 = 250;
								}
								if (num55 < 50) {
									num55 = 50;
								}
								pen2.Color = Color.FromArgb (num55, num55, num55);
							}
							GX.Graphics.DrawLine (pen2, num22 + num24 * num15, num23 + num24 * num16, num22 + num24 * num33, num23 + num24 * num34);
							num15 = num33;
							num16 = num34;
						}
					}
				}
				num21 += -1;
			} while (num21 >= 0);
			PlotLabels (GX, intLength, num);
		}
	}

	public static void PrintModeShape (GraphicsX GX, PrintRoutines.RECT rcPlot, short intLength)
	{
		Pen pen = new Pen (Color.Black);
		Pen pen2 = new Pen (Color.Black);
		Font font = new Font ("Consolas", 10f);
		GX.Scale (PrintRoutines.fr.rcPage.Left, PrintRoutines.fr.rcPage.Top, PrintRoutines.fr.rcPage.Right, PrintRoutines.fr.rcPage.Bottom);
		checked {
			GX.DrawString (" ", font, Brushes.Black, rcPlot.Left - 2880, rcPlot.Top, GraphicsX.AlignText.LeftTop, 0f);
			GX.DrawString ("Length" + Units.DisplayLength (Buckle [intLength].Length, 0, blnShowUnit: true, "", 11, 0));
			GX.DrawString ("Stress" + Units.DisplayStress (Buckle [intLength].LF, 0, blnShowUnit: true, "", 11, 0));
			GX.DrawString ("P     " + Units.DisplayForce (Buckle [intLength].P, 0, blnShowUnit: true, "", 11, 0));
			GX.DrawString ("Mx    " + Units.DisplayMoment (Buckle [intLength].Mx, 0, blnShowUnit: true, "", 11, 0));
			GX.DrawString ("My    " + Units.DisplayMoment (Buckle [intLength].My, 0, blnShowUnit: true, "", 11, 0));
			string s;
			string s2;
			if (Buckle [intLength].HoleMode == HoleMode.Gross) {
				s = "Gross Section";
				s2 = "Global Buckling";
				if (IsDistortionalBuckling (Buckle [intLength].WorkRatio)) {
					s2 = "Distortional Buckling";
				}
				if (IsLocalBuckling (Buckle [intLength].WorkRatio)) {
					s2 = "Local Buckling";
				}
			} else {
				s = "Net Section";
				s2 = Conversions.ToString (Interaction.IIf (Buckle [intLength].HoleMode == HoleMode.Local, "Local Buckling", "Distortional Buckling"));
			}
			GX.DrawString (s);
			GX.DrawString (s2);
			GX.DrawString ("Work Ratio = " + Units.DisplayNone (Buckle [intLength].WorkRatio, "", 0, 0));
			short num = 0;
			short num2 = (short)Information.UBound (Buckle);
			for (short num3 = 0; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if ((short)unchecked(intLength + num3) <= Information.UBound (Buckle) && Buckle [(short)unchecked(intLength + num3)].ModeShape > 0) {
					num = Buckle [(short)unchecked(intLength + num3)].ModeShape;
					break;
				}
				if ((short)unchecked(intLength - num3) >= 1 && Buckle [(short)unchecked(intLength - num3)].ModeShape > 0) {
					num = Buckle [(short)unchecked(intLength - num3)].ModeShape;
					break;
				}
				if (((short)unchecked(intLength - num3) < 1) & ((short)unchecked(intLength + num3) > Information.UBound (Buckle))) {
					break;
				}
			}
			if (num == 0) {
				return;
			}
			float x = Node [1].X;
			float num4 = x;
			float y = Node [1].Y;
			float num5 = y;
			float num6 = 0f;
			short num7 = intNodeCount;
			for (short num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
				if (Node [num8].X < x) {
					x = Node [num8].X;
				}
				if (Node [num8].X > num4) {
					num4 = Node [num8].X;
				}
				if (Node [num8].Y < y) {
					y = Node [num8].Y;
				}
				if (Node [num8].Y > num5) {
					num5 = Node [num8].Y;
				}
				if (System.Math.Abs (ModeShape [num8, num].DX) > num6) {
					num6 = System.Math.Abs (ModeShape [num8, num].DX);
				}
				if (System.Math.Abs (ModeShape [num8, num].DY) > num6) {
					num6 = System.Math.Abs (ModeShape [num8, num].DY);
				}
			}
			float num9 = num4 - x;
			float num10 = num5 - y;
			float num11 = (float)System.Math.Sqrt (num9 * num9 + num10 * num10);
			num6 = (float)((double)num6 / (0.1 * (double)num11));
			num9 = (float)(1.25 * (double)num9);
			num10 = (float)(1.25 * (double)num10);
			float num12 = (float)((double)(rcPlot.Bottom - rcPlot.Top) / (double)(rcPlot.Right - rcPlot.Left));
			if (num12 * num9 > num10) {
				num10 = num12 * num9;
			} else {
				num9 = num10 / num12;
			}
			float num13 = num9 / (float)(rcPlot.Right - rcPlot.Left);
			float num14 = num10 / (float)(rcPlot.Bottom - rcPlot.Top);
			float num15 = (x + num4) / 2f - num9 / 2f - (float)(rcPlot.Left - PrintRoutines.fr.rcPage.Left) * num13;
			float num16 = (y + num5) / 2f + num10 / 2f + (float)(rcPlot.Top - PrintRoutines.fr.rcPage.Top) * num14;
			float x2 = num15 + (float)(PrintRoutines.fr.rcPage.Right - PrintRoutines.fr.rcPage.Left) * num13;
			float y2 = num16 - (float)(PrintRoutines.fr.rcPage.Bottom - PrintRoutines.fr.rcPage.Top) * num14;
			GX.Scale (num15, num16, x2, y2);
			pen.Width = (float)(0.001 * (double)GX.XUnitsPerInch);
			pen2.Width = (float)(0.008 * (double)GX.XUnitsPerInch);
			short num17 = intStripCount;
			for (short num18 = 1; num18 <= num17; num18 = (short)unchecked(num18 + 1)) {
				if ((Buckle [intLength].HoleMode != HoleMode.Local) | (Strip [num18].HoleLength < Buckle [intLength].Length)) {
					short num8 = Strip [num18].Nodei;
					x2 = Node [num8].X;
					float num19 = ModeShape [num8, num].DX / num6;
					y2 = Node [num8].Y;
					float num20 = ModeShape [num8, num].DY / num6;
					float num21 = ModeShape [num8, num].Rot / num6;
					num8 = Strip [num18].Nodej;
					float x3 = Node [num8].X;
					float num22 = ModeShape [num8, num].DX / num6;
					float y3 = Node [num8].Y;
					float num23 = ModeShape [num8, num].DY / num6;
					float num24 = ModeShape [num8, num].Rot / num6;
					GX.Graphics.DrawLine (pen, x2, y2, x3, y3);
					num9 = x3 - x2;
					num10 = y3 - y2;
					float num25 = (float)System.Math.Atan2 (num10, num9);
					float num26 = (float)System.Math.Sqrt (num9 * num9 + num10 * num10);
					float num27 = (0f - (num10 * num19 - num9 * num20)) / num26;
					float num28 = (0f - (num10 * num22 - num9 * num23)) / num26;
					float num29 = num27;
					float num30 = num21;
					float num31 = (float)((double)(num21 + num24) / System.Math.Pow (num26, 2.0) - (double)(2f * (num28 - num27)) / System.Math.Pow (num26, 3.0));
					float num32 = (float)(0.5 * (double)(num24 - num21) / (double)num26 - 1.5 * (double)num31 * (double)num26);
					short num33 = (short)System.Math.Round (25f * num26 / num11);
					if (num33 < 1) {
						num33 = 1;
					}
					num15 = x2 + num19;
					num16 = y2 + num20;
					x2 = num15;
					y2 = num16;
					short num34 = num33;
					for (short num3 = 1; num3 <= num34; num3 = (short)unchecked(num3 + 1)) {
						float num35 = num26 * (float)num3 / (float)num33;
						num35 = num29 + num30 * num35 + num32 * num35 * num35 + num31 * num35 * num35 * num35;
						x3 = (float)((double)(num15 + num9 * (float)num3 / (float)num33) - (double)(num35 - num27) * System.Math.Sin (num25));
						y3 = (float)((double)(num16 + num10 * (float)num3 / (float)num33) + (double)(num35 - num27) * System.Math.Cos (num25));
						GX.Graphics.DrawLine (pen2, x2, y2, x3, y3);
						x2 = x3;
						y2 = y3;
					}
				}
			}
		}
	}

	public static void PlotModeDisp (GraphicsX GX, short intLength, float Factor = 1f, bool blnRender = false, short intRotation = 0)
	{
		Pen pen = new Pen (Color.Gray, 0f);
		Pen pen2 = new Pen (Color.Black, 2f * CFS.Sections [CFS.intSctNow].Part [1].Thickness);
		Pen pen3 = new Pen (Color.Red, CFS.Sections [CFS.intSctNow].Part [1].Thickness);
		_ = ref Buckle [intLength];
		short modeShape = Buckle [intLength].ModeShape;
		if (modeShape == 0) {
			return;
		}
		float num = (float)((double)System.Math.Sign (5.5 - (double)intRotation) * System.Math.Pow (2.0, System.Math.Abs (5.5 - (double)intRotation)));
		float x = Node [0].X;
		float num2 = x;
		float num3 = x;
		float y = Node [0].Y;
		float num4 = y;
		float num5 = y;
		float num6 = 0f;
		float num7 = 0f;
		short num8 = intNodeCount;
		checked {
			float num10;
			float num11;
			for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
				num10 = Node [num9].X - x;
				num11 = Node [num9].Y - y;
				float num12 = (float)System.Math.Sqrt (num10 * num10 + num11 * num11);
				if (num12 > num7) {
					num7 = num12;
				}
				float num13 = x + num10;
				float num14 = y + num11;
				if (num13 < num2) {
					num2 = num13;
				}
				if (num13 > num3) {
					num3 = num13;
				}
				if (num14 < num4) {
					num4 = num14;
				}
				if (num14 > num5) {
					num5 = num14;
				}
				num12 = (float)System.Math.Sqrt (System.Math.Pow (ModeShape [num9, modeShape].DX, 2.0) + System.Math.Pow (ModeShape [num9, modeShape].DY, 2.0));
				if (num12 > num6) {
					num6 = num12;
				}
			}
			num10 = num3 - num2;
			num11 = num5 - num4;
			num7 = 2f * num7;
			num6 = (float)((double)num6 / (0.1 * (double)num7));
			GX.Graphics.Clear (GX.PictureBox.BackColor);
			GX.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			float num15 = (float)((double)GX.PictureBox.ClientSize.Height / (double)GX.PictureBox.ClientSize.Width);
			num10 = (float)(1.5 * (double)num10);
			num11 = (float)(1.5 * (double)num11);
			if (num15 * num10 > num11) {
				num11 = num15 * num10;
			} else {
				num10 = num11 / num15;
			}
			GX.Scale ((num2 + num3) / 2f - num10 / 2f, (num4 + num5) / 2f + num11 / 2f, (num2 + num3) / 2f + num10 / 2f, (num4 + num5) / 2f - num11 / 2f);
			pen.Width = GX.PenScale / GX.Graphics.DpiX;
			float num16 = 0f;
			float num17 = 0f;
			short num18 = intStripCount;
			for (short num19 = 1; num19 <= num18; num19 = (short)unchecked(num19 + 1)) {
				if ((Buckle [intLength].HoleMode != HoleMode.Local) | (Strip [num19].HoleLength < Buckle [intLength].Length)) {
					short num9 = Strip [num19].Nodei;
					num10 = Node [num9].X - x;
					num11 = Node [num9].Y - y;
					float num13 = x + num10;
					float num14 = y + num11;
					num10 = ModeShape [num9, modeShape].DX * Factor / num6;
					num11 = ModeShape [num9, modeShape].DY * Factor / num6;
					float num20 = num10;
					float num21 = num11;
					float num22 = ModeShape [num9, modeShape].Rot * Factor / num6;
					float num23 = ModeShape [num9, modeShape].DZ * Factor * num / num6;
					num9 = Strip [num19].Nodej;
					num10 = Node [num9].X - x;
					num11 = Node [num9].Y - y;
					float num24 = x + num10;
					float num25 = y + num11;
					num10 = ModeShape [num9, modeShape].DX * Factor / num6;
					num11 = ModeShape [num9, modeShape].DY * Factor / num6;
					float num26 = num10;
					float num27 = num11;
					float num28 = ModeShape [num9, modeShape].Rot * Factor / num6;
					float num29 = ModeShape [num9, modeShape].DZ * Factor * num / num6;
					if (!blnRender) {
						GX.Graphics.DrawLine (pen, ViewPoint (num13, num14, 0f), ViewPoint (num24, num25, 0f));
					}
					num10 = num24 - num13;
					num11 = num25 - num14;
					float num30 = (float)System.Math.Atan2 (num11, num10);
					float num31 = (float)System.Math.Sqrt (num10 * num10 + num11 * num11);
					float num32 = (0f - (num11 * num20 - num10 * num21)) / num31;
					float num33 = (0f - (num11 * num26 - num10 * num27)) / num31;
					float num34 = num32;
					float num35 = num22;
					float num36 = (float)((double)(num22 + num28) / System.Math.Pow (num31, 2.0) - (double)(2f * (num33 - num32)) / System.Math.Pow (num31, 3.0));
					float num37 = (float)(0.5 * (double)(num28 - num22) / (double)num31 - 1.5 * (double)num36 * (double)num31);
					short num38 = (short)System.Math.Round (25f * num31 / num7);
					if (num38 < 1) {
						num38 = 1;
					}
					float num39 = num13 + num20;
					float num40 = num14 + num21;
					num13 = num39;
					num14 = num40;
					if (blnRender) {
						GX.Graphics.DrawLine (pen, ViewPoint (num16 + num13, num17 + num14, 0f), ViewPoint (num16 + num13, num17 + num14, num23));
					}
					float num41 = (float)System.Math.Sin (num30);
					float num42 = (float)System.Math.Cos (num30);
					short num43 = num38;
					for (short num44 = 1; num44 <= num43; num44 = (short)unchecked(num44 + 1)) {
						float num12 = num31 * (float)num44 / (float)num38;
						num12 = num34 + num35 * num12 + num37 * num12 * num12 + num36 * num12 * num12 * num12;
						num24 = num39 + num10 * (float)num44 / (float)num38 - (num12 - num32) * num41;
						num25 = num40 + num11 * (float)num44 / (float)num38 + (num12 - num32) * num42;
						GX.Graphics.DrawLine (pen2, ViewPoint (num16 + num13, num17 + num14, 0f), ViewPoint (num16 + num24, num17 + num25, 0f));
						if (blnRender) {
							float z = num23 + (num29 - num23) * (float)num44 / (float)num38;
							GX.Graphics.DrawLine (pen3, ViewPoint (num16 + num13, num17 + num14, num23 + (num29 - num23) * (float)(num44 - 1) / (float)num38), ViewPoint (num16 + num24, num17 + num25, z));
							GX.Graphics.DrawLine (pen, ViewPoint (num16 + num24, num17 + num25, 0f), ViewPoint (num16 + num24, num17 + num25, z));
						}
						num13 = num24;
						num14 = num25;
					}
				}
			}
			PlotLabels (GX, intLength);
		}
	}

	private static PointF ViewPoint (float X, float Y, float Z)
	{
		return new PointF ((float)(0.866 * (double)X - 0.866 * (double)Z), (float)((double)Y - 0.5 * (double)X - 0.5 * (double)Z));
	}

	public static void PlotProfile (GraphicsX GX)
	{
		CurveGridStructure crvGrid = default(CurveGridStructure);
		CurveDataStructure crvData = default(CurveDataStructure);
		float num = 0f;
		checked {
			short num2 = (short)Information.UBound (Buckle);
			short num4 = default(short);
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Buckle [num3].LF > num) {
					num = Buckle [num3].LF;
				}
				if (Buckle [num3].HoleMode == HoleMode.Gross) {
					num4 = num3;
				}
			}
			GX.Graphics.Clear (GX.PictureBox.BackColor);
			float num5 = 6.25f;
			float num6 = num5 * GX.Height / GX.Width;
			GX.Scale (0f, 0f, num5, num6);
			crvGrid.Left = 0.5f;
			crvGrid.Top = 0.25f;
			crvGrid.Width = (float)((double)(num5 - crvGrid.Left) - 0.25);
			crvGrid.Height = (float)((double)(num6 - crvGrid.Top) - 0.5);
			crvGrid.XAxis.Title = "Member Half-Wavelength (" + Units.DisplayUnit (2, 0) + ")";
			crvGrid.XAxis.LogScale = true;
			crvGrid.XAxis.Min = Units.ConvertValue (CFSInterface.BuckleParametersNow.Lmin, Units.UnitTypes.LengthUnit, 0);
			crvGrid.XAxis.Max = Units.ConvertValue (CFSInterface.BuckleParametersNow.Lmax, Units.UnitTypes.LengthUnit, 0);
			if (Information.UBound (Buckle) == 1) {
				crvGrid.XAxis.Min = crvGrid.XAxis.Min / 2f;
				crvGrid.XAxis.Max = crvGrid.XAxis.Max * 2f;
			}
			crvGrid.YAxis.Title = "Stress (" + Units.DisplayUnit (5, 0) + ")";
			crvGrid.YAxis.LogScale = false;
			crvGrid.YAxis.Min = 0f;
			crvGrid.YAxis.Max = (float)(1.1 * (double)Units.ConvertValue (num, Units.UnitTypes.StressUnit, 0));
			crvGrid.YAxis.AllowPower = true;
			crvGrid.Font = new Font ("Arial", 8f);
			GX.Graphics.SmoothingMode = SmoothingMode.Default;
			GX.PrintCurveGrid (crvGrid);
			crvData.HardLimit.Xmin = crvGrid.XAxis.Min;
			crvData.HardLimit.Xmax = crvGrid.XAxis.Max;
			crvData.HardLimit.Ymin = crvGrid.YAxis.Min + num / 1000f;
			crvData.HardLimit.Ymax = crvGrid.YAxis.Max;
			crvData.SoftLimit = crvData.HardLimit;
			crvData.Points = new PointType[num4 + 1];
			short num7 = num4;
			for (short num3 = 1; num3 <= num7; num3 = (short)unchecked(num3 + 1)) {
				crvData.Points [num3].X = Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0);
				crvData.Points [num3].Y = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
			}
			GX.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			GX.PrintCurve (crvGrid, crvData);
			short num8 = (short)(num4 + 1);
			short num9 = (short)Information.UBound (Buckle);
			short num10 = num8;
			while (num10 <= num9 && Buckle [num10].HoleMode == HoleMode.Local) {
				num10 = (short)unchecked(num10 + 1);
			}
			num10 = (short)(num10 - 1);
			if (num10 == num4 + 1) {
				num10 = (short)(num10 - 1);
			}
			if (num10 > num4) {
				crvData.SoftLimit.Xmax = crvGrid.XAxis.Min;
				crvData.Points = new PointType[(short)unchecked(num10 - num4) + 1];
				short num11 = (short)(num4 + 1);
				short num12 = num10;
				for (short num3 = num11; num3 <= num12; num3 = (short)unchecked(num3 + 1)) {
					crvData.Points [(short)unchecked(num3 - num4)].X = Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0);
					crvData.Points [(short)unchecked(num3 - num4)].Y = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
				}
				GX.PrintCurve (crvGrid, crvData);
			}
			Pen pen = new Pen (Color.Blue, GX.PenScale / GX.Graphics.DpiX);
			short num13 = (short)(num4 + 1);
			short num14 = (short)Information.UBound (Buckle);
			for (short num3 = num13; num3 <= num14; num3 = (short)unchecked(num3 + 1)) {
				if (Buckle [num3].HoleMarker) {
					float num15 = (float)System.Math.Log10 (Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0));
					float num16 = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
					float num17 = GX.XUnitsPerInch / 16f;
					float num18 = GX.YUnitsPerInch / 16f;
					GX.Graphics.DrawEllipse (pen, num15 - num17 / 2f, num16 - num18 / 2f, num17, num18);
				}
			}
			short num19 = (short)(num10 + 1);
			short num20 = (short)Information.UBound (Buckle);
			for (short num3 = num19; num3 <= num20; num3 = (short)unchecked(num3 + 1)) {
				GX.PrintX ((float)System.Math.Log10 (Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0)), Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0), 0.1f);
			}
			GX.PreserveImage ();
		}
	}

	public static void PrintProfile (GraphicsX GX, PrintRoutines.RECT rcPlot)
	{
		CurveGridStructure crvGrid = default(CurveGridStructure);
		CurveDataStructure crvData = default(CurveDataStructure);
		float num = 0f;
		checked {
			short num2 = (short)Information.UBound (Buckle);
			short num4 = default(short);
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Buckle [num3].LF > num) {
					num = Buckle [num3].LF;
				}
				if (Buckle [num3].HoleMode == HoleMode.Gross) {
					num4 = num3;
				}
			}
			float num5 = (float)(6.0 / (double)(rcPlot.Right - rcPlot.Left));
			float num6 = (float)(4.25 / (double)(rcPlot.Bottom - rcPlot.Top));
			float num7 = 0f - (float)(rcPlot.Left - PrintRoutines.fr.rcPage.Left) * num5;
			float num8 = 0f - (float)(rcPlot.Top - PrintRoutines.fr.rcPage.Top) * num6;
			float x = num7 + (float)(PrintRoutines.fr.rcPage.Right - PrintRoutines.fr.rcPage.Left) * num5;
			float y = num8 + (float)(PrintRoutines.fr.rcPage.Bottom - PrintRoutines.fr.rcPage.Top) * num6;
			GX.Scale (num7, num8, x, y);
			crvGrid.Left = 0.5f;
			crvGrid.Top = 0f;
			crvGrid.Width = 5.5f;
			crvGrid.Height = 3.75f;
			crvGrid.XAxis.Title = "Member Half-Wavelength (" + Units.DisplayUnit (2, 0) + ")";
			crvGrid.XAxis.LogScale = true;
			crvGrid.XAxis.Min = Units.ConvertValue (CFSInterface.BuckleParametersNow.Lmin, Units.UnitTypes.LengthUnit, 0);
			crvGrid.XAxis.Max = Units.ConvertValue (CFSInterface.BuckleParametersNow.Lmax, Units.UnitTypes.LengthUnit, 0);
			if (Information.UBound (Buckle) == 1) {
				crvGrid.XAxis.Min = crvGrid.XAxis.Min / 2f;
				crvGrid.XAxis.Max = crvGrid.XAxis.Max * 2f;
			}
			crvGrid.YAxis.Title = "Stress (" + Units.DisplayUnit (5, 0) + ")";
			crvGrid.YAxis.LogScale = false;
			crvGrid.YAxis.Min = 0f;
			crvGrid.YAxis.Max = (float)(1.1 * (double)Units.ConvertValue (num, Units.UnitTypes.StressUnit, 0));
			crvGrid.YAxis.AllowPower = true;
			crvGrid.Font = new Font ("Arial", 10f);
			GX.PrintCurveGrid (crvGrid);
			crvData.HardLimit.Xmin = crvGrid.XAxis.Min;
			crvData.HardLimit.Xmax = crvGrid.XAxis.Max;
			crvData.HardLimit.Ymin = crvGrid.YAxis.Min + num / 1000f;
			crvData.HardLimit.Ymax = crvGrid.YAxis.Max;
			crvData.SoftLimit = crvData.HardLimit;
			crvData.Points = new PointType[num4 + 1];
			short num9 = num4;
			for (short num3 = 1; num3 <= num9; num3 = (short)unchecked(num3 + 1)) {
				crvData.Points [num3].X = Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0);
				crvData.Points [num3].Y = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
			}
			GX.PrintCurve (crvGrid, crvData);
			short num10 = (short)(num4 + 1);
			short num11 = (short)Information.UBound (Buckle);
			short num12 = num10;
			while (num12 <= num11 && Buckle [num12].HoleMode == HoleMode.Local) {
				num12 = (short)unchecked(num12 + 1);
			}
			num12 = (short)(num12 - 1);
			if (num12 == num4 + 1) {
				num12 = (short)(num12 - 1);
			}
			if (num12 > num4) {
				crvData.SoftLimit.Xmax = crvGrid.XAxis.Min;
				crvData.Points = new PointType[(short)unchecked(num12 - num4) + 1];
				short num13 = (short)(num4 + 1);
				short num14 = num12;
				for (short num3 = num13; num3 <= num14; num3 = (short)unchecked(num3 + 1)) {
					crvData.Points [(short)unchecked(num3 - num4)].X = Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0);
					crvData.Points [(short)unchecked(num3 - num4)].Y = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
				}
				GX.PrintCurve (crvGrid, crvData);
			}
			Pen pen = new Pen (Color.Black, GX.PenScale / GX.Graphics.DpiX);
			short num15 = (short)(num4 + 1);
			short num16 = (short)Information.UBound (Buckle);
			for (short num3 = num15; num3 <= num16; num3 = (short)unchecked(num3 + 1)) {
				if (Buckle [num3].HoleMarker) {
					float num17 = (float)System.Math.Log10 (Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0));
					float num18 = Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0);
					float num19 = GX.XUnitsPerInch / 16f;
					float num20 = GX.YUnitsPerInch / 16f;
					GX.Graphics.DrawEllipse (pen, num17 - num19 / 2f, num18 - num20 / 2f, num19, num20);
				}
			}
			short num21 = (short)(num12 + 1);
			short num22 = (short)Information.UBound (Buckle);
			for (short num3 = num21; num3 <= num22; num3 = (short)unchecked(num3 + 1)) {
				GX.PrintX ((float)System.Math.Log10 (Units.ConvertValue (Buckle [num3].Length, Units.UnitTypes.LengthUnit, 0)), Units.ConvertValue (Buckle [num3].LF, Units.UnitTypes.StressUnit, 0), 0.1f);
			}
		}
	}

	public static PointF Minimum (float X0, float Y0, float X1, float Y1, float X2, float Y2)
	{
		float num = Y0 / ((X1 - X0) * (X2 - X0));
		float num2 = Y1 / ((X1 - X0) * (X2 - X1));
		float num3 = Y2 / ((X2 - X0) * (X2 - X1));
		PointF result = default(PointF);
		if (num - num2 + num3 == 0f) {
			result.X = X0;
			result.Y = Y0;
			if (Y1 < result.Y) {
				result.X = X1;
				result.Y = Y1;
			}
			if (Y2 < result.Y) {
				result.X = X2;
				result.Y = Y2;
			}
		} else {
			float num4 = (num * (X1 + X2) - num2 * (X0 + X2) + num3 * (X0 + X1)) / (num - num2 + num3) / 2f;
			num = (num4 - X0) / (X2 - X1);
			num2 = (num4 - X1) / (X2 - X0);
			num3 = (num4 - X2) / (X1 - X0);
			result.X = num4;
			result.Y = Y0 * num2 * num3 - Y1 * num * num3 + Y2 * num * num2;
		}
		return result;
	}

	public static bool IsLocalBuckling (float WorkRatio)
	{
		return WorkRatio > 3f;
	}

	public static bool IsDistortionalBuckling (float WorkRatio)
	{
		return (double)WorkRatio > 0.2 && WorkRatio <= 3f;
	}

	public static bool IsGlobalBuckling (float WorkRatio)
	{
		return (double)WorkRatio <= 0.2;
	}
}
