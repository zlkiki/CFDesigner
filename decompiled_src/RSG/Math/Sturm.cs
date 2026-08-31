// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.Math;

[StandardModule]
internal sealed class Sturm
{
	private static double[,] AK;

	private static double[,] AMS;

	private static double[,] D;

	private static double[,] AD;

	private static double[] WLU;

	private static short[] ILU;

	private static double[] EIGEN;

	private static double[] Y;

	private static short N;

	private static short MB;

	private static short M11;

	private static short M21;

	private const double TOLU = 1E+300;

	private const double TOLL = 1E-300;

	private const double EPS = 3E-16;

	private const double EPS1 = 0.0001;

	private const double EPS2 = 0.0001;

	public static void SturmSolve (double[,] K, double[,] KG, short NDOF, double[] LF, double[,] Y1, ref short NR)
	{
		short num = 0;
		short num2 = NDOF;
		short num3 = 1;
		checked {
			while (num3 <= num2 && (short)unchecked(NDOF - num3) >= num) {
				short num4 = (short)((short)unchecked(num3 + num) + 1);
				short num5 = NDOF;
				while (num5 >= num4 && K [num3, num5] == 0.0) {
					num5 = (short)unchecked(num5 + -1);
				}
				if ((short)unchecked(num5 - num3) > num) {
					num = (short)unchecked(num5 - num3);
				}
				short num6 = (short)((short)unchecked(num3 + num) + 1);
				num5 = NDOF;
				while (num5 >= num6 && KG [num3, num5] == 0.0) {
					num5 = (short)unchecked(num5 + -1);
				}
				if ((short)unchecked(num5 - num3) > num) {
					num = (short)unchecked(num5 - num3);
				}
				num3 = (short)unchecked(num3 + 1);
			}
			N = NDOF;
			MB = (short)(num + 1);
			M11 = (short)(num + 1);
			M21 = (short)(num * 2 + 1);
			AK = new double[N + 1, M11 + 1];
			AMS = new double[N + 1, MB + 1];
			D = new double[M11 + 1, M21 + 1];
			AD = new double[N + 1, M21 + 1];
			Y = new double[N + 1];
			short num7 = (short)Information.UBound (LF);
			double num8 = default(double);
			for (num3 = 1; num3 <= num7; num3 = (short)unchecked(num3 + 1)) {
				if (LF [num3] > 0.0 && 1.0 / LF [num3] > num8) {
					num8 = 1.0 / LF [num3];
				}
			}
			if (num8 == 0.0) {
				num8 = 1.0;
			}
			short n = N;
			for (num3 = 1; num3 <= n; num3 = (short)unchecked(num3 + 1)) {
				short m = M11;
				for (short num5 = 1; num5 <= m; num5 = (short)unchecked(num5 + 1)) {
					if ((short)unchecked(num3 + num5) - 1 <= N) {
						AK [num3, num5] = K [num3, (short)unchecked(num3 + num5) - 1];
					}
				}
			}
			short n2 = N;
			for (num3 = 1; num3 <= n2; num3 = (short)unchecked(num3 + 1)) {
				short mB = MB;
				for (short num5 = 1; num5 <= mB; num5 = (short)unchecked(num5 + 1)) {
					if ((short)unchecked(num3 + num5) - 1 <= N) {
						AMS [num3, num5] = KG [num3, (short)unchecked(num3 + num5) - 1];
					}
				}
			}
			Array.Clear (LF, 0, LF.Length);
			Array.Clear (Y1, 0, Y1.Length);
			short num9 = 6;
			short iNORM = 0;
			short NEIG = default(short);
			short NEIG2 = default(short);
			double num10 = default(double);
			if (NR > 0) {
				double p = num10;
				double F = 0.0;
				EIGNUM (p, ref NEIG, ref F, 0, 0);
				while (true) {
					double p2 = num8;
					F = 0.0;
					EIGNUM (p2, ref NEIG2, ref F, 0, 0);
					if (NEIG2 == N) {
						break;
					}
					if (NEIG2 >= NEIG && !(num8 > 1000.0)) {
						if (NEIG2 <= (short)unchecked(N - NR)) {
							num10 = num8;
							NEIG = NEIG2;
						}
						num8 = 2.0 * num8;
						continue;
					}
					return;
				}
				if ((short)unchecked(NEIG2 - NEIG) < NR) {
					NR = (short)unchecked(NEIG2 - NEIG);
				}
			} else {
				double p3 = num10;
				double F = 0.0;
				EIGNUM (p3, ref NEIG, ref F, 0, 0);
				double p4 = num8;
				F = 0.0;
				EIGNUM (p4, ref NEIG2, ref F, 0, 0);
				if (NEIG2 < NEIG) {
					return;
				}
				NR = (short)unchecked(NEIG2 - NEIG);
			}
			WLU = new double[4 * NR + 1];
			ILU = new short[4 * NR + 1];
			EIGEN = new double[NR + 1];
			if (!BISECT (NR, num10, num8, NEIG, NEIG2)) {
				return;
			}
			if (num9 > 0) {
				short num11 = NR;
				for (num3 = 1; num3 <= num11; num3 = (short)unchecked(num3 + 1)) {
					NEIG = 0;
					NEIG2 = 0;
					short NEIG3 = 0;
					short num12 = (short)unchecked(num3 + NR);
					num10 = WLU [num3];
					num8 = WLU [num12];
					double num13 = num8 - num10;
					if ((num13 > 3E-16) & (ILU [num12] != ILU [num3])) {
						double p5 = num10;
						double F = 0.0;
						EIGNUM (p5, ref NEIG, ref F, 0, 0);
						double p6 = num8;
						F = 0.0;
						EIGNUM (p6, ref NEIG2, ref F, 0, 0);
						short num14 = num9;
						for (short num5 = 1; num5 <= num14; num5 = (short)unchecked(num5 + 1)) {
							num13 = (num8 + num10) / 2.0;
							double p7 = num13;
							F = 0.0;
							EIGNUM (p7, ref NEIG3, ref F, 0, 0);
							if (NEIG3 >= NEIG2) {
								num8 = num13;
							} else {
								num10 = num13;
							}
							num13 = num8 - num10;
							if (num13 <= 3E-16) {
								break;
							}
						}
					}
					WLU [num3] = num10;
					WLU [num12] = num8;
				}
			}
			LOCATE (NR);
			double num15 = 1.1175870895385742E-08;
			short num16 = 0;
			short num17 = NR;
			for (num3 = 1; num3 <= num17; num3 = (short)unchecked(num3 + 1)) {
				short num12 = (short)unchecked(num3 + NR);
				if ((ILU [num3] != ILU [num12]) | (EIGEN [num3] == 0.0)) {
					num16 = 0;
				} else {
					num16 = (short)(num16 + 1);
					EIGEN [num3] += (double)(num16 - 1) * num15;
				}
			}
			short num18 = NR;
			for (short num12 = 1; num12 <= num18; num12 = (short)unchecked(num12 + 1)) {
				if (EIGEN [num12] != 0.0) {
					EIGVEC (EIGEN [num12], iNORM);
					LF [num12] = 1.0 / EIGEN [num12];
					short n3 = N;
					for (short num5 = 1; num5 <= n3; num5 = (short)unchecked(num5 + 1)) {
						Y1 [num5, num12] = Y [num5];
					}
				}
			}
		}
	}

	public static void EIGNUM (double P, ref short NEIG, ref double F1, short IEIG, short IV)
	{
		checked {
			short num = (short)(M11 - 1);
			Array.Clear (D, 0, D.Length);
			short m = M11;
			short num2;
			for (num2 = 1; num2 <= m; num2 = (short)unchecked(num2 + 1)) {
				D [1, num2] = AMS [1, num2];
			}
			short m2 = M11;
			for (short num3 = 2; num3 <= m2; num3 = (short)unchecked(num3 + 1)) {
				short num4 = (short)(num3 - 1);
				short num5 = 1;
				short num6 = num3;
				short num7 = num4;
				for (num2 = 1; num2 <= num7; num2 = (short)unchecked(num2 + 1)) {
					D [num3, num2] = AMS [num5, num6];
					num5 = (short)(num5 + 1);
					num6 = (short)(num6 - 1);
				}
				num5 = 0;
				short num8 = (short)unchecked(num3 + num);
				short num9 = num3;
				short num10 = num8;
				for (num2 = num9; num2 <= num10; num2 = (short)unchecked(num2 + 1)) {
					num5 = (short)(num5 + 1);
					D [num3, num2] = AMS [num3, num5];
				}
			}
			short m3 = M11;
			for (num2 = 1; num2 <= m3; num2 = (short)unchecked(num2 + 1)) {
				D [1, num2] = D [1, num2] - P * AK [1, num2];
			}
			short m4 = M11;
			for (short num3 = 2; num3 <= m4; num3 = (short)unchecked(num3 + 1)) {
				short num4 = (short)(num3 - 1);
				short num5 = 1;
				short num6 = num3;
				short num11 = num4;
				for (num2 = 1; num2 <= num11; num2 = (short)unchecked(num2 + 1)) {
					D [num3, num2] -= P * AK [num5, num6];
					num5 = (short)(num5 + 1);
					num6 = (short)(num6 - 1);
				}
				num5 = 0;
				short num12 = (short)unchecked(num3 + num);
				short num13 = num3;
				short num14 = num12;
				for (num2 = num13; num2 <= num14; num2 = (short)unchecked(num2 + 1)) {
					num5 = (short)(num5 + 1);
					D [num3, num2] -= P * AK [num3, num5];
				}
			}
			NEIG = 0;
			short num15 = 0;
			if (IEIG == 1) {
				F1 = D [1, 1];
				if (F1 < 0.0) {
					NEIG++;
				}
			} else if (D [1, 1] < 0.0) {
				NEIG++;
			}
			short num16 = num;
			for (num2 = 1; num2 <= num16; num2 = (short)unchecked(num2 + 1)) {
				short num17 = 0;
				short num18 = num2;
				for (short num3 = 1; num3 <= num18; num3 = (short)unchecked(num3 + 1)) {
					if (System.Math.Abs (D [num2 + 1, num3]) > System.Math.Abs (D [num3, num3])) {
						num15 = (short)(num15 + 1);
						if (IEIG == 0) {
							short num19 = Conversions.ToShort (Interaction.IIf (D [num2 + 1, num3] > 0.0, 1, 2));
							short num20 = Conversions.ToShort (Interaction.IIf (D [num3, num3] > 0.0, 1, 2));
							if (num19 == num20) {
								num17 = (short)(num17 + 1);
							}
						}
						short num21 = num3;
						short m5 = M21;
						for (short num4 = num21; num4 <= m5; num4 = (short)unchecked(num4 + 1)) {
							double num22 = D [num3, num4];
							double num23 = D [num2 + 1, num4];
							D [num3, num4] = num23;
							D [num2 + 1, num4] = num22;
						}
					}
					double num24 = D [num2 + 1, num3] / D [num3, num3];
					short num25 = num3;
					short m6 = M21;
					for (short num4 = num25; num4 <= m6; num4 = (short)unchecked(num4 + 1)) {
						D [num2 + 1, num4] = D [num2 + 1, num4] - num24 * D [num3, num4];
					}
				}
				if (IEIG == 0) {
					if (D [num2 + 1, num2 + 1] < 0.0) {
						num17 = (short)(num17 + 1);
					}
					if (unchecked(num17 % 2) > 0) {
						NEIG++;
					}
				} else {
					double num26 = 1.0;
					short num5 = (short)(num2 + 1);
					short num27 = num5;
					double num28;
					for (short num3 = 1; num3 <= num27; num3 = (short)unchecked(num3 + 1)) {
						num28 = System.Math.Abs (num26);
						if (unchecked(num28 >= 1E+300 || num28 <= 1E-300)) {
							NEIG = -1;
							return;
						}
						num26 *= D [num3, num3];
					}
					double x = -1.0;
					num26 *= System.Math.Pow (x, num15);
					num28 = System.Math.Abs (num26);
					if (unchecked(num28 >= 1E+300 || num28 <= 1E-300)) {
						NEIG = -1;
						return;
					}
					short num29 = Conversions.ToShort (Interaction.IIf (F1 > 0.0, 1, 2));
					short num20 = Conversions.ToShort (Interaction.IIf (num26 > 0.0, 1, 2));
					if (num29 != num20) {
						NEIG++;
					}
					F1 = num26;
				}
			}
			short num30 = (short)(N - 1);
			double num31 = default(double);
			if (IEIG == 1) {
				num31 = D [1, 1];
			}
			short m7 = M11;
			short num32 = num30;
			for (num2 = m7; num2 <= num32; num2 = (short)unchecked(num2 + 1)) {
				if (IV != 0) {
					short num33 = (short)unchecked(num2 - num);
					short m8 = M21;
					for (short num3 = 1; num3 <= m8; num3 = (short)unchecked(num3 + 1)) {
						AD [num33, num3] = D [1, num3];
					}
				}
				short num34 = num;
				short num5;
				for (short num3 = 1; num3 <= num34; num3 = (short)unchecked(num3 + 1)) {
					short m9 = M21;
					for (num5 = 2; num5 <= m9; num5 = (short)unchecked(num5 + 1)) {
						D [num3, num5] = D [num3 + 1, num5];
					}
				}
				short num35 = num;
				for (short num3 = 1; num3 <= num35; num3 = (short)unchecked(num3 + 1)) {
					short m10 = M21;
					for (num5 = 2; num5 <= m10; num5 = (short)unchecked(num5 + 1)) {
						D [num3, num5 - 1] = D [num3, num5];
					}
				}
				short num36 = num;
				for (short num3 = 1; num3 <= num36; num3 = (short)unchecked(num3 + 1)) {
					D [num3, M21] = 0.0;
				}
				short m11 = M21;
				for (short num3 = 1; num3 <= m11; num3 = (short)unchecked(num3 + 1)) {
					D [num + 1, num3] = 0.0;
				}
				short num37 = (short)((short)unchecked(num2 - num) + 1);
				num5 = (short)(num + 1);
				short num38 = num;
				for (short num3 = 1; num3 <= num38; num3 = (short)unchecked(num3 + 1)) {
					D [M11, num3] = AMS [num37, num5] - P * AK [num37, num5];
					num37 = (short)(num37 + 1);
					num5 = (short)(num5 - 1);
				}
				num5 = 0;
				short m12 = M11;
				short m13 = M21;
				for (short num3 = m12; num3 <= m13; num3 = (short)unchecked(num3 + 1)) {
					num5 = (short)(num5 + 1);
					D [M11, num3] = AMS [num2 + 1, num5] - P * AK [num2 + 1, num5];
				}
				short num17 = 0;
				short num39 = num;
				for (short num3 = 1; num3 <= num39; num3 = (short)unchecked(num3 + 1)) {
					if (System.Math.Abs (D [num + 1, num3]) > System.Math.Abs (D [num3, num3])) {
						num15 = (short)(num15 + 1);
						if (IEIG == 0) {
							short num40 = Conversions.ToShort (Interaction.IIf (D [num + 1, num3] > 0.0, 1, 2));
							short num20 = Conversions.ToShort (Interaction.IIf (D [num3, num3] > 0.0, 1, 2));
							if (num40 == num20) {
								num17 = (short)(num17 + 1);
							}
						}
						short num41 = num3;
						short m14 = M21;
						for (short num4 = num41; num4 <= m14; num4 = (short)unchecked(num4 + 1)) {
							double num22 = D [num3, num4];
							double num23 = D [num + 1, num4];
							D [num3, num4] = num23;
							D [num + 1, num4] = num22;
						}
					}
					double num24 = D [num + 1, num3] / D [num3, num3];
					short num42 = num3;
					short m15 = M21;
					for (short num4 = num42; num4 <= m15; num4 = (short)unchecked(num4 + 1)) {
						D [num + 1, num4] = D [num + 1, num4] - num24 * D [num3, num4];
					}
				}
				if (IEIG == 0) {
					if (D [num + 1, num + 1] < 0.0) {
						num17 = (short)(num17 + 1);
					}
					if (unchecked(num17 % 2) > 0) {
						NEIG++;
					}
				} else {
					double num26 = num31;
					short m16 = M11;
					double num28;
					for (short num3 = 1; num3 <= m16; num3 = (short)unchecked(num3 + 1)) {
						num28 = System.Math.Abs (num26);
						if (unchecked(num28 >= 1E+300 || num28 <= 1E-300)) {
							NEIG = -1;
							return;
						}
						num26 *= D [num3, num3];
					}
					double x = -1.0;
					num26 *= System.Math.Pow (x, num15);
					num28 = System.Math.Abs (num26);
					if (unchecked(num28 >= 1E+300 || num28 <= 1E-300)) {
						NEIG = -1;
						return;
					}
					short num43 = Conversions.ToShort (Interaction.IIf (F1 > 0.0, 1, 2));
					short num20 = Conversions.ToShort (Interaction.IIf (num26 > 0.0, 1, 2));
					if (num43 != num20) {
						NEIG++;
					}
					F1 = num26;
					num31 *= D [1, 1];
					num28 = System.Math.Abs (num31);
					if (unchecked(num28 >= 1E+300 || num28 <= 1E-300)) {
						NEIG = -1;
						return;
					}
				}
			}
			if (IV == 0) {
				return;
			}
			num2 = 0;
			short num44 = (short)(N - (num + 1));
			short m17 = M11;
			for (short num3 = 1; num3 <= m17; num3 = (short)unchecked(num3 + 1)) {
				num44 = (short)(num44 + 1);
				num2 = (short)(num2 + 1);
				short num45 = 0;
				short num46 = num2;
				short m18 = M21;
				for (short num4 = num46; num4 <= m18; num4 = (short)unchecked(num4 + 1)) {
					num45 = (short)(num45 + 1);
					AD [num44, num45] = D [num2, num4];
				}
			}
		}
	}

	public static bool BISECT (short NR, double PL, double PU, short N1, short N2)
	{
		bool result = false;
		Array.Clear (WLU, 0, WLU.Length);
		Array.Clear (ILU, 0, ILU.Length);
		short num = NR;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				short num3 = (short)unchecked(num2 + NR);
				WLU [num2] = PL;
				ILU [num2] = N1;
				WLU [num3] = PU;
				ILU [num3] = N2;
			}
			double num4 = PU;
			double num5 = PL;
			short num6 = N2;
			short num7 = (short)unchecked(N2 - N1);
			if (num7 == 0) {
				result = false;
			} else if (num7 == 1) {
				result = true;
			} else {
				while (true) {
					double num8 = (num4 + num5) / 2.0;
					short NEIG = 0;
					double F = 0.0;
					EIGNUM (num8, ref NEIG, ref F, 0, 0);
					if (NEIG > num6) {
						break;
					}
					short num9 = 0;
					short num10 = (short)unchecked(num6 - NEIG);
					short num11 = (short)((short)unchecked(N2 - num6) + 1);
					short num12 = (short)((short)unchecked(num11 + num10) - 1);
					if (num12 >= NR) {
						num9 = NR;
					}
					short num2;
					if ((num10 > 0) & (System.Math.Abs (num4 - num8) < 3E-16)) {
						short num13 = num12;
						for (num2 = num11; num2 <= num13; num2 = (short)unchecked(num2 + 1)) {
							short num3 = (short)unchecked(num2 + NR);
							WLU [num2] = num8;
							ILU [num2] = 1;
							WLU [num3] = num8;
							ILU [num3] = 1;
						}
					} else {
						if (num10 == 0) {
							num4 = num8;
						}
						short num14 = (short)(num12 + 1);
						short num15 = (short)((short)unchecked(num11 + num7) - 1);
						if (num9 == NR) {
							num12 = NR;
						}
						if (num10 == 0) {
							num14 = (short)((short)unchecked(num15 - num7) + 1);
							if (num15 > NR) {
								num15 = NR;
							}
							short num16 = num14;
							short num17 = num15;
							for (num2 = num16; num2 <= num17; num2 = (short)unchecked(num2 + 1)) {
								short num3 = (short)unchecked(num2 + NR);
								WLU [num3] = num8;
								ILU [num3] = NEIG;
							}
						} else {
							short num18 = num12;
							for (num2 = num11; num2 <= num18; num2 = (short)unchecked(num2 + 1)) {
								WLU [num2] = num8;
								ILU [num2] = NEIG;
							}
							if (num9 != NR) {
								if (num10 == num7) {
									short num19 = num12;
									for (num2 = num11; num2 <= num19; num2 = (short)unchecked(num2 + 1)) {
										short num3 = (short)unchecked(num2 + NR);
										WLU [num3] = num4;
									}
								} else {
									if (num15 > NR) {
										num15 = NR;
									}
									short num20 = num14;
									short num21 = num15;
									for (num2 = num20; num2 <= num21; num2 = (short)unchecked(num2 + 1)) {
										short num3 = (short)unchecked(num2 + NR);
										WLU [num3] = num8;
										ILU [num3] = NEIG;
									}
								}
							}
						}
					}
					short num22 = NR;
					num2 = 1;
					while (num2 <= num22 && num10 != 0) {
						short num3 = (short)unchecked(num2 + NR);
						if (ILU [num3] > ILU [num2] + 1) {
							num5 = WLU [num2];
							num4 = WLU [num3];
							num6 = ILU [num3];
							short num23 = ILU [num2];
							num7 = (short)unchecked(num6 - num23);
							break;
						}
						num2 = (short)unchecked(num2 + 1);
					}
					if (num2 > NR) {
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}

	public static void LOCATE (short NR)
	{
		short num = NR;
		checked {
			short NEIG = default(short);
			double F = default(double);
			double F2 = default(double);
			double F3 = default(double);
			short NEIG2 = default(short);
			short NEIG3 = default(short);
			short NEIG4 = default(short);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				short num3 = (short)unchecked(num2 + NR);
				double num4 = WLU [num2];
				double num5 = WLU [num3];
				if ((num5 - num4 <= 3E-16) | (ILU [num3] == ILU [num2])) {
					EIGEN [num2] = WLU [num2];
				} else {
					short num6 = 1;
					short num7 = 1;
					if (ILU [num3] != ILU [num2] + 1) {
						break;
					}
					EIGNUM (num4, ref NEIG, ref F, 1, 0);
					if (NEIG >= 0) {
						EIGNUM (num5, ref NEIG, ref F2, 1, 0);
						if (NEIG >= 0) {
							while (true) {
								short num8 = (short)System.Math.Round ((double)((num6 - 1) * (num6 - 2)) / 2.0);
								double num9 = System.Math.Pow (2.0, num8);
								if (unchecked(F == 0.0 || F2 == 0.0)) {
									if (F == 0.0) {
										EIGEN [num2] = num4;
									}
									if (F2 == 0.0) {
										EIGEN [num2] = num5;
									}
									break;
								}
								double num10 = num4;
								double num11 = (num5 * F - num10 * num9 * F2) / (F - num9 * F2);
								EIGNUM (num11, ref NEIG, ref F3, 1, 0);
								if (NEIG < 0) {
									break;
								}
								short num12 = Conversions.ToShort (Interaction.IIf (F > 0.0, 1, 2));
								short num13 = Conversions.ToShort (Interaction.IIf (F2 > 0.0, 1, 2));
								short num14 = Conversions.ToShort (Interaction.IIf (F3 > 0.0, 1, 2));
								if (num12 == num13) {
									return;
								}
								if (num12 != num14) {
									num7 = (short)(num7 + 1);
									num6 = num7;
								} else {
									if (num13 != num14) {
										num4 = num5;
									}
									F = F2;
									num6 = 1;
									num7 = 1;
								}
								num5 = num11;
								F2 = F3;
								if (System.Math.Abs (num5 - num4) / System.Math.Abs (num4) <= 0.0001) {
									EIGEN [num2] = num5;
									break;
								}
							}
						}
					}
					if (NEIG < 0) {
						double num15 = WLU [num2];
						double num16 = WLU [num3];
						EIGNUM (num15, ref NEIG2, ref F2, 0, 0);
						EIGNUM (num16, ref NEIG3, ref F, 0, 0);
						do {
							double num17 = (num16 + num15) / 2.0;
							EIGNUM (num17, ref NEIG4, ref F3, 0, 0);
							if (NEIG4 >= NEIG3) {
								num16 = num17;
							} else {
								num15 = num17;
							}
						} while (!(System.Math.Abs (num16 - num15) / System.Math.Abs (num15) <= 0.0001));
						EIGEN [num2] = num16;
					}
				}
			}
		}
	}

	public static void EIGVEC (double P, short INORM)
	{
		Array.Clear (AD, 0, AD.Length);
		short n = N;
		checked {
			for (short num = 1; num <= n; num = (short)unchecked(num + 1)) {
				Y [num] = 1.0;
			}
			short NEIG = 0;
			double F = 0.0;
			EIGNUM (P, ref NEIG, ref F, 0, 1);
			int num2 = 1;
			do {
				short num3 = N;
				NEIG = N;
				for (short num = 1; num <= NEIG; num = (short)unchecked(num + 1)) {
					short num4 = (short)(num3 + 1);
					Y [num3] /= AD [num3, 1];
					short m = M21;
					for (short num5 = 2; num5 <= m; num5 = (short)unchecked(num5 + 1)) {
						if (AD [num3, num5] != 0.0) {
							Y [num3] -= AD [num3, num5] / AD [num3, 1] * Y [num4];
						}
						num4 = (short)(num4 + 1);
					}
					num3 = (short)(num3 - 1);
				}
				num2++;
			} while (num2 <= 2);
			double num6 = 0.0;
			if (INORM == 0) {
				short n2 = N;
				for (short num = 1; num <= n2; num = (short)unchecked(num + 1)) {
					if (System.Math.Abs (Y [num]) > System.Math.Abs (num6)) {
						num6 = Y [num];
					}
				}
			} else {
				num6 = Y [INORM];
			}
			short n3 = N;
			for (short num = 1; num <= n3; num = (short)unchecked(num + 1)) {
				Y [num] /= num6;
			}
		}
	}
}
