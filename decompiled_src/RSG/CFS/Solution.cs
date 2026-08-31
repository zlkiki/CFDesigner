// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;

namespace RSG.CFS;

internal class Solution
{
	public short nLoad;

	public short nNode;

	public float[] Znode;

	public float[] EI;

	public short nSeg;

	public FlexureSegment[] Seg;

	public short nDOF;

	public short[,] iDOF;

	public float[,] V;

	public float[] M;

	public float[] R;

	public float[] D;

	public Solution Clone ()
	{
		Solution solution = (Solution)MemberwiseClone ();
		if (!Information.IsNothing (Znode)) {
			solution.Znode = (float[])Znode.Clone ();
		}
		if (!Information.IsNothing (EI)) {
			solution.EI = (float[])EI.Clone ();
		}
		if (!Information.IsNothing (Seg)) {
			solution.Seg = (FlexureSegment[])Seg.Clone ();
		}
		if (!Information.IsNothing (iDOF)) {
			solution.iDOF = (short[,])iDOF.Clone ();
		}
		if (!Information.IsNothing (V)) {
			solution.V = (float[,])V.Clone ();
		}
		if (!Information.IsNothing (M)) {
			solution.M = (float[])M.Clone ();
		}
		if (!Information.IsNothing (R)) {
			solution.R = (float[])R.Clone ();
		}
		if (!Information.IsNothing (D)) {
			solution.D = (float[])D.Clone ();
		}
		return solution;
	}

	internal void SolveBeam ()
	{
		checked {
			short num = (short)(nNode - 1);
			short num2 = (short)(2 * num);
			V = new float[nNode + 1, 3];
			M = new float[nNode + 1];
			R = new float[nNode + 1];
			D = new float[nNode + 1];
			double[] array = new double[num + 1];
			double[] array2 = new double[num2 + 1];
			double[,] array3 = new double[num2 + 1, num2 + 1];
			double[] array4 = new double[nDOF + 1];
			double[] array5 = new double[nDOF + 1];
			double[,] array6 = new double[nDOF + 1, num2 + 1];
			double[,] array7 = new double[num2 + 1, nDOF + 1];
			double[,] array8 = new double[nDOF + 1, nDOF + 1];
			short num3 = num;
			short num4;
			for (num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
				array [num4] = Znode [num4 + 1] - Znode [num4];
			}
			short num5 = 0;
			short num6 = 1;
			short num7 = nSeg;
			short num8;
			short num24;
			for (num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
				if (Seg [num8].Z == Znode [num5 + 1]) {
					num5 = (short)(num5 + 1);
					num6 = (short)(2 * num5 - 1);
					num4 = num5;
				}
				float num9 = Seg [num8].Z - Znode [num5];
				float num10 = Seg [num8 + 1].Z - Znode [num5];
				float num11 = (float)(1.0 - (double)num9 / array [num4]);
				float num12 = num11 * num11;
				float num13 = num12 * num11;
				float num14 = num12 * num12;
				float num15 = (float)(1.0 - (double)num10 / array [num4]);
				float num16 = num15 * num15;
				float num17 = num16 * num15;
				float num18 = num16 * num16;
				float num19 = (Seg [num8].W1 - Seg [num8].W0) / (num10 - num9);
				float num20 = (float)(array [num4] / 2.0 * ((double)(Seg [num8].W1 * num17 * (2f - num15) - Seg [num8].W0 * num13 * (2f - num11)) + (double)num19 * array [num4] / 10.0 * (double)(num18 * (5f - 2f * num15) - num14 * (5f - 2f * num11))));
				float num21 = 0f - num20 - (Seg [num8].W0 + Seg [num8].W1) / 2f * (num10 - num9);
				float num22 = (float)((double)num20 * array [num4] / 2.0 + array [num4] * array [num4] / 6.0 * ((double)(Seg [num8].W0 * num13 - Seg [num8].W1 * num17) + (double)num19 * array [num4] / 4.0 * (double)(num14 - num18)));
				float num23 = (float)((double)num20 * array [num4] - (double)num22 + array [num4] * array [num4] / 6.0 * ((double)(3f * Seg [num8].W0 * num12 - 3f * Seg [num8].W1 * num16) + (double)num19 * array [num4] * (double)(num13 - num17)));
				num20 += (0f - Seg [num8].P0) * num12 * (3f - 2f * num11);
				num21 = (float)((double)num21 + (double)(0f - Seg [num8].P0) * System.Math.Pow (1f - num11, 2.0) * (double)(1f + 2f * num11));
				num22 = (float)((double)num22 + (double)((0f - Seg [num8].P0) * (1f - num11) * num12) * array [num4]);
				num23 = (float)((double)num23 + (double)Seg [num8].P0 * System.Math.Pow (1f - num11, 2.0) * (double)num11 * array [num4]);
				num20 = (float)((double)num20 + (double)(-6f * Seg [num8].M0 * (1f - num11) * num11) / array [num4]);
				num21 = (float)((double)num21 + (double)(6f * Seg [num8].M0 * (1f - num11) * num11) / array [num4]);
				num22 += Seg [num8].M0 * num11 * (3f * num11 - 2f);
				num23 += Seg [num8].M0 * (1f - num11) * (1f - 3f * num11);
				array2 [num6] += 0f - num22;
				array2 [num6 + 1] += 0f - num23;
				num24 = iDOF [num5, 2];
				if (num24 > 0) {
					array4 [num24] += 0f - num20;
				}
				num24 = iDOF [num5 + 1, 2];
				if (num24 > 0) {
					array4 [num24] += 0f - num21;
				}
				num20 = (float)((0.0 - array [num4]) * (double)(num11 - num15) * (double)(Seg [num8].W0 * (num11 + num15) / 2f + (Seg [num8].W1 - Seg [num8].W0) * (num11 + 2f * num15) / 6f));
				num21 = 0f - num20 - (Seg [num8].W0 + Seg [num8].W1) / 2f * (num10 - num9);
				num20 += (0f - Seg [num8].P0) * num11;
				num21 += (0f - Seg [num8].P0) * (1f - num11);
				num20 = (float)((double)num20 + (double)(0f - Seg [num8].M0) / array [num4]);
				num21 = (float)((double)num21 + (double)Seg [num8].M0 / array [num4]);
				V [num4, 1] += num20;
				V [num4, 2] += num21;
			}
			array2 [num6 + 1] += 0f - Seg [num8].M0;
			ref float reference = ref V [num4, 1];
			reference = (float)((double)reference + (double)(0f - Seg [num8].M0) / array [num4]);
			ref float reference2 = ref V [num4, 2];
			reference2 = (float)((double)reference2 + ((double)Seg [num8].M0 / array [num4] - (double)Seg [num8].P0));
			num24 = iDOF [nNode, 2];
			if (num24 > 0) {
				array4 [num24] += Seg [num8].P0;
			}
			short num25 = nNode;
			for (num5 = 1; num5 <= num25; num5 = (short)unchecked(num5 + 1)) {
				num24 = iDOF [num5, 0];
				if (num24 > 0) {
					num6 = (short)(2 * num5 - 2);
					if (num6 >= 1) {
						array6 [num24, num6] = 1.0;
						array4 [num24] -= array2 [num6];
					}
				}
				num24 = iDOF [num5, 1];
				if (num24 > 0) {
					num6 = (short)(2 * num5 - 1);
					if (num6 <= num2) {
						array6 [num24, num6] = 1.0;
						array4 [num24] -= array2 [num6];
					}
				}
				num24 = iDOF [num5, 2];
				if (num24 > 0) {
					num6 = (short)(2 * num5 - 3);
					if (num6 >= 1) {
						array6 [num24, num6] = 1.0 / array [num5 - 1];
						array6 [num24, num6 + 1] = 1.0 / array [num5 - 1];
					}
					num6 = (short)(2 * num5 - 1);
					if (num6 <= num2) {
						array6 [num24, num6] = -1.0 / array [num5];
						array6 [num24, num6 + 1] = -1.0 / array [num5];
					}
				}
			}
			short num26 = num;
			for (num4 = 1; num4 <= num26; num4 = (short)unchecked(num4 + 1)) {
				float num27 = (float)((double)EI [num4] / array [num4]);
				num6 = (short)(2 * num4 - 1);
				short num28 = (short)(num6 + 1);
				array3 [num6, num6] = 4f * num27;
				array3 [num6, num28] = 2f * num27;
				array3 [num28, num6] = 2f * num27;
				array3 [num28, num28] = 4f * num27;
			}
			short num29 = num2;
			for (num6 = 1; num6 <= num29; num6 = (short)unchecked(num6 + 1)) {
				short num30 = nDOF;
				for (num24 = 1; num24 <= num30; num24 = (short)unchecked(num24 + 1)) {
					short num31 = num2;
					for (short num28 = 1; num28 <= num31; num28 = (short)unchecked(num28 + 1)) {
						array7 [num6, num24] += array3 [num6, num28] * array6 [num24, num28];
					}
				}
			}
			short num32 = nDOF;
			for (num24 = 1; num24 <= num32; num24 = (short)unchecked(num24 + 1)) {
				short num33 = nDOF;
				for (short num34 = 1; num34 <= num33; num34 = (short)unchecked(num34 + 1)) {
					short num35 = num2;
					for (num6 = 1; num6 <= num35; num6 = (short)unchecked(num6 + 1)) {
						array8 [num24, num34] += array6 [num24, num6] * array7 [num6, num34];
					}
				}
			}
			double num36 = 0.0;
			short num37 = nDOF;
			for (num24 = 1; num24 <= num37; num24 = (short)unchecked(num24 + 1)) {
				if (System.Math.Abs (array8 [num24, num24]) > num36) {
					num36 = System.Math.Abs (array8 [num24, num24]);
				}
			}
			short num38 = nDOF;
			for (short num39 = 1; num39 <= num38; num39 = (short)unchecked(num39 + 1)) {
				float num11 = (float)array8 [num39, num39];
				if ((double)System.Math.Abs (num11) <= num36 * 1E-08) {
					nNode = 0;
					return;
				}
				short num40 = nDOF;
				for (num24 = 1; num24 <= num40; num24 = (short)unchecked(num24 + 1)) {
					float num15 = (float)(array8 [num24, num39] / (double)num11);
					if (num24 != num39) {
						short num41 = num24;
						short num42 = nDOF;
						for (short num34 = num41; num34 <= num42; num34 = (short)unchecked(num34 + 1)) {
							array8 [num24, num34] -= (double)num15 * array8 [num39, num34];
							array8 [num34, num24] = array8 [num24, num34];
						}
					}
					array8 [num24, num39] = num15;
					array8 [num39, num24] = num15;
				}
				array8 [num39, num39] = -1f / num11;
			}
			short num43 = nDOF;
			for (num24 = 1; num24 <= num43; num24 = (short)unchecked(num24 + 1)) {
				short num44 = nDOF;
				for (short num34 = 1; num34 <= num44; num34 = (short)unchecked(num34 + 1)) {
					array8 [num24, num34] = 0.0 - array8 [num24, num34];
				}
			}
			short num45 = nDOF;
			for (num24 = 1; num24 <= num45; num24 = (short)unchecked(num24 + 1)) {
				short num46 = nDOF;
				for (short num34 = 1; num34 <= num46; num34 = (short)unchecked(num34 + 1)) {
					array5 [num24] += array8 [num24, num34] * array4 [num34];
				}
			}
			short num47 = num2;
			for (num6 = 1; num6 <= num47; num6 = (short)unchecked(num6 + 1)) {
				short num48 = nDOF;
				for (num24 = 1; num24 <= num48; num24 = (short)unchecked(num24 + 1)) {
					array2 [num6] += array7 [num6, num24] * array5 [num24];
				}
			}
			short num49 = num;
			for (num4 = 1; num4 <= num49; num4 = (short)unchecked(num4 + 1)) {
				M [num4] = (float)array2 [2 * num4 - 1];
			}
			M [nNode] = (float)(0.0 - array2 [num2]);
			short num50 = num;
			for (num4 = 1; num4 <= num50; num4 = (short)unchecked(num4 + 1)) {
				float num20 = (float)((0.0 - (array2 [2 * num4 - 1] + array2 [2 * num4])) / array [num4]);
				V [num4, 1] += num20;
				V [num4, 2] -= num20;
			}
			short num51 = nNode;
			for (num5 = 1; num5 <= num51; num5 = (short)unchecked(num5 + 1)) {
				num24 = iDOF [num5, 1];
				if (num24 > 0) {
					R [num5] = (float)(0.0 - array5 [num24]);
				} else {
					R [num5] = 0f;
				}
				num24 = iDOF [num5, 2];
				if (num24 > 0) {
					D [num5] = (float)array5 [num24];
				} else {
					D [num5] = 0f;
				}
			}
		}
	}

	internal void Forces (float Z0, ref float V, ref float M)
	{
		V = 0f;
		M = 0f;
		checked {
			if (nLoad == 0 || ((Z0 < Seg [1].Z) | (Z0 > Seg [nSeg + 1].Z))) {
				return;
			}
			short num = 0;
			short num2 = nSeg;
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Seg [num3].Z == Znode [num + 1]) {
					num = (short)(num + 1);
					M = this.M [num];
					V = this.V [num, 1];
				}
				float num4 = Seg [num3 + 1].Z - Seg [num3].Z;
				float w = Seg [num3].W0;
				float num5 = (Seg [num3].W1 - w) / num4;
				V += Seg [num3].P0;
				M += Seg [num3].M0;
				if ((Seg [num3].Z <= Z0) & (Seg [num3 + 1].Z > Z0)) {
					float num6 = Z0 - Seg [num3].Z;
					M = M + V * num6 + w * num6 * num6 / 2f + num5 * num6 * num6 * num6 / 6f;
					V = V + w * num6 + num5 * num6 * num6 / 2f;
					break;
				}
				M += V * num4 + w * num4 * num4 / 2f + num5 * num4 * num4 * num4 / 6f;
				V += w * num4 + num5 * num4 * num4 / 2f;
				w += num5 * num4;
			}
		}
	}

	internal void Moments (float Z0, float Z1, ref float ZMmin, ref float ZMmax, ref float Mmin, ref float Mmax)
	{
		ZMmin = Z0;
		ZMmax = Z0;
		Mmin = 0f;
		Mmax = 0f;
		if (nLoad == 0) {
			return;
		}
		if (Z0 > Z1) {
			CFS.Swap (ref Z0, ref Z1);
		}
		if (Z0 < Seg [1].Z) {
			Z0 = Seg [1].Z;
		}
		checked {
			if (Z1 > Seg [nSeg + 1].Z) {
				Z1 = Seg [nSeg + 1].Z;
			}
			if (Z0 > Z1) {
				return;
			}
			short num = 0;
			short num2 = nSeg;
			short num3 = 1;
			float num5 = default(float);
			float num4 = default(float);
			while (true) {
				if (num3 <= num2) {
					if (Seg [num3].Z == Znode [num + 1]) {
						num = (short)(num + 1);
						num4 = M [num];
						num5 = V [num, 1];
					}
					float num6 = Seg [num3 + 1].Z - Seg [num3].Z;
					float w = Seg [num3].W0;
					float num7 = (Seg [num3].W1 - w) / num6;
					if ((double)System.Math.Abs (num7) <= 1E-06 * (double)System.Math.Abs (w / num6)) {
						num7 = 0f;
					}
					num5 += Seg [num3].P0;
					num4 += Seg [num3].M0;
					if (Seg [num3 + 1].Z > Z0) {
						if (Seg [num3].Z <= Z0) {
							float num8 = Z0 - Seg [num3].Z;
							Mmin = num4 + num5 * num8 + w * num8 * num8 / 2f + num7 * num8 * num8 * num8 / 6f;
							Mmax = Mmin;
						} else {
							if (num4 < Mmin) {
								Mmin = num4;
								ZMmin = Seg [num3].Z;
							}
							if (num4 > Mmax) {
								Mmax = num4;
								ZMmax = Seg [num3].Z;
							}
						}
						float num9 = w * w - 2f * num5 * num7;
						unchecked {
							if (num7 == 0f) {
								if (w != 0f) {
									float num8 = (0f - num5) / w;
									if ((num8 >= 0f && num8 <= num6) & (Seg [num3].Z + num8 > Z0) & (Seg [num3].Z + num8 < Z1)) {
										float num10 = num4 + num5 * num8 + w * num8 * num8 / 2f + num7 * num8 * num8 * num8 / 6f;
										if (num10 < Mmin) {
											Mmin = num10;
											ZMmin = Seg [num3].Z + num8;
										}
										if (num10 > Mmax) {
											Mmax = num10;
											ZMmax = Seg [num3].Z + num8;
										}
									}
								}
							} else if (num9 >= 0f) {
								num9 = (float)System.Math.Sqrt (num9);
								float num8 = (0f - w - num9) / num7;
								if ((num8 >= 0f && num8 <= num6) & (Seg [num3].Z + num8 > Z0) & (Seg [num3].Z + num8 < Z1)) {
									float num10 = num4 + num5 * num8 + w * num8 * num8 / 2f + num7 * num8 * num8 * num8 / 6f;
									if (num10 < Mmin) {
										Mmin = num10;
										ZMmin = Seg [num3].Z + num8;
									}
									if (num10 > Mmax) {
										Mmax = num10;
										ZMmax = Seg [num3].Z + num8;
									}
								}
								num8 = (0f - w + num9) / num7;
								if ((num8 >= 0f && num8 <= num6) & (Seg [num3].Z + num8 > Z0) & (Seg [num3].Z + num8 < Z1)) {
									float num10 = num4 + num5 * num8 + w * num8 * num8 / 2f + num7 * num8 * num8 * num8 / 6f;
									if (num10 < Mmin) {
										Mmin = num10;
										ZMmin = Seg [num3].Z + num8;
									}
									if (num10 > Mmax) {
										Mmax = num10;
										ZMmax = Seg [num3].Z + num8;
									}
								}
							}
						}
						if (Seg [num3 + 1].Z >= Z1) {
							float num8 = Z1 - Seg [num3].Z;
							float num10 = num4 + num5 * num8 + w * num8 * num8 / 2f + num7 * num8 * num8 * num8 / 6f;
							if (num10 < Mmin) {
								Mmin = num10;
								ZMmin = Seg [num3].Z + num8;
							}
							if (num10 > Mmax) {
								Mmax = num10;
								ZMmax = Seg [num3].Z + num8;
							}
							if (Seg [num3 + 1].Z > Z1) {
								break;
							}
						}
					}
					num4 += num5 * num6 + w * num6 * num6 / 2f + num7 * num6 * num6 * num6 / 6f;
					num5 += w * num6 + num7 * num6 * num6 / 2f;
					w += num7 * num6;
					num3 = (short)unchecked(num3 + 1);
					continue;
				}
				if (Z1 == Seg [num3].Z) {
					if (num4 < Mmin) {
						Mmin = num4;
						ZMmin = Seg [num3].Z;
					}
					if (num4 > Mmax) {
						Mmax = num4;
						ZMmax = Seg [num3].Z;
					}
				}
				break;
			}
		}
	}

	internal void MinimaMaxima (ref SolutionDetail Det)
	{
		float[] array = new float[4];
		float[] array2 = new float[5];
		Det.NV = 0;
		Det.NM = 0;
		Det.NR = 0;
		Det.ND = 0;
		if (nLoad == 0) {
			return;
		}
		float num = (float)(1E-06 * (double)(Znode [nNode] - Znode [1]) / (double)nSeg);
		checked {
			Det.ZV = new float[3 * nSeg + 1];
			Det.V = new float[3 * nSeg + 1];
			Det.ZM = new float[4 * nSeg + 1];
			Det.M = new float[4 * nSeg + 1];
			Det.ZR = new float[4 * nSeg + 1];
			Det.R = new float[4 * nSeg + 1];
			Det.ZD = new float[4 * nSeg + 1];
			Det.D = new float[4 * nSeg + 1];
			if (D [1] != 0f) {
				Det.ND++;
				Det.ZD [Det.ND] = Znode [1];
				Det.D [Det.ND] = D [1];
			}
			if (R [1] == 0f) {
				Det.NM++;
				Det.ZM [Det.NM] = Seg [1].Z;
				Det.M [Det.NM] = M [1];
			}
			short num2 = 0;
			short num3 = nSeg;
			short num4;
			float num7 = default(float);
			float num8 = default(float);
			float num9 = default(float);
			float num5 = default(float);
			float num6 = default(float);
			for (num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
				if (Seg [num4].Z == Znode [num2 + 1]) {
					num2 = (short)(num2 + 1);
					if ((num2 > 1) & (System.Math.Sign (V [num2, 1]) != System.Math.Sign (num5))) {
						bool flag = false;
						if (Det.NM == 0 || System.Math.Abs (Seg [num4].Z - Det.ZM [Det.NM]) > num) {
							flag = true;
						}
						if (System.Math.Abs (num6) < System.Math.Abs (M [num2] + Seg [num4].M0)) {
							num6 = M [num2] + Seg [num4].M0;
						}
						if (flag) {
							Det.NM++;
							Det.ZM [Det.NM] = Seg [num4].Z;
							Det.M [Det.NM] = num6;
						}
					}
					if ((num2 > 1) & (System.Math.Sign (R [num2]) != System.Math.Sign (num7))) {
						bool flag = false;
						if (Det.ND == 0 || System.Math.Abs (Seg [num4].Z - Det.ZD [Det.ND]) > num) {
							flag = true;
						}
						if (flag) {
							Det.ND++;
							Det.ZD [Det.ND] = Seg [num4].Z;
							Det.D [Det.ND] = num8;
						}
					}
					num8 = D [num2];
					num7 = R [num2];
					num6 = M [num2];
					num5 = V [num2, 1];
					num9 = EI [num2];
				}
				float num10 = Seg [num4 + 1].Z - Seg [num4].Z;
				float num11 = num10 * num10;
				float num12 = num11 * num10;
				float num13 = num11 * num11;
				float num14 = num12 * num11;
				float w = Seg [num4].W0;
				float num15 = (Seg [num4].W1 - w) / num10;
				if ((double)System.Math.Abs (num15) <= 1E-06 * (double)System.Math.Abs (w / num10)) {
					num15 = 0f;
				}
				num5 += Seg [num4].P0;
				num6 += Seg [num4].M0;
				if (unchecked(Seg [num4].Z == Znode [num2] && num8 == 0f)) {
					if (num2 > 1) {
						Det.NV++;
						Det.ZV [Det.NV] = Seg [num4].Z;
						Det.V [Det.NV] = 0f - V [num2 - 1, 2];
					}
					Det.NV++;
					Det.ZV [Det.NV] = Seg [num4].Z;
					Det.V [Det.NV] = V [num2, 1];
				} else if ((Seg [num4].P0 != 0f) & (System.Math.Sign (w) != System.Math.Sign (Seg [num4].P0))) {
					if (System.Math.Sign (w) != -System.Math.Sign (num5 - Seg [num4].P0)) {
						Det.NV++;
						Det.ZV [Det.NV] = Seg [num4].Z;
						Det.V [Det.NV] = num5 - Seg [num4].P0;
					}
					if (System.Math.Sign (w) != System.Math.Sign (num5)) {
						Det.NV++;
						Det.ZV [Det.NV] = Seg [num4].Z;
						Det.V [Det.NV] = num5;
					}
				}
				if (num4 > 1 && System.Math.Sign (Seg [num4 - 1].W1) != System.Math.Sign (w) && (Det.NV == 0 || Det.ZV [Det.NV] != Seg [num4].Z || Det.V [Det.NV] != num5)) {
					Det.NV++;
					Det.ZV [Det.NV] = Seg [num4].Z;
					Det.V [Det.NV] = num5;
				}
				if (System.Math.Sign (w) != System.Math.Sign (w + num15 * num10)) {
					float num16 = (0f - w) / num15;
					bool flag = false;
					if (Det.NV == 0 || System.Math.Abs (Seg [num4].Z + num16 - Det.ZV [Det.NV]) > num) {
						flag = true;
					}
					if (flag) {
						Det.NV++;
						Det.ZV [Det.NV] = Seg [num4].Z + num16;
						Det.V [Det.NV] = num5 + w * num16 + num15 * num16 * num16 / 2f;
					}
				}
				short num17 = 0;
				float num18 = w * w - 2f * num5 * num15;
				if (System.Math.Sign (num5) != System.Math.Sign (num5 - Seg [num4].P0)) {
					num17 = (short)(num17 + 1);
					array [num17] = 0f;
				}
				if (num15 == 0f) {
					if (w != 0f) {
						float num16 = (0f - num5) / w;
						if (unchecked(num16 >= 0f && num16 < num10)) {
							num17 = (short)(num17 + 1);
							array [num17] = num16;
						}
					}
				} else if (num18 == 0f) {
					float num16 = (0f - w) / num15;
					if (unchecked(num16 >= 0f && num16 < num10)) {
						num17 = (short)(num17 + 1);
						array [num17] = num16;
					}
				} else if (num18 > 0f) {
					num18 = (float)System.Math.Sqrt (num18);
					float num16 = (0f - w - num18) / num15;
					if (unchecked(num16 >= 0f && num16 < num10)) {
						num17 = (short)(num17 + 1);
						array [num17] = num16;
					}
					num16 = (0f - w + num18) / num15;
					if (unchecked(num16 >= 0f && num16 < num10)) {
						num17 = (short)(num17 + 1);
						array [num17] = num16;
					}
					if ((num17 == 2) & (array [1] > array [2])) {
						CFS.Swap (ref array [1], ref array [2]);
					}
				}
				if (System.Math.Sign (num5) * System.Math.Sign (Seg [num4].M0) < 0) {
					if (System.Math.Sign (num5) == System.Math.Sign (num6 - Seg [num4].M0)) {
						Det.NM++;
						Det.ZM [Det.NM] = Seg [num4].Z;
						Det.M [Det.NM] = num6 - Seg [num4].M0;
					}
					if (System.Math.Sign (num5) == -System.Math.Sign (num6)) {
						Det.NM++;
						Det.ZM [Det.NM] = Seg [num4].Z;
						Det.M [Det.NM] = num6;
					}
				}
				short num19 = num17;
				for (short num20 = 1; num20 <= num19; num20 = (short)unchecked(num20 + 1)) {
					float num16 = array [num20];
					bool flag = false;
					if (Det.NM == 0 || System.Math.Abs (Seg [num4].Z + num16 - Det.ZM [Det.NM]) > num) {
						flag = true;
					}
					if (flag) {
						Det.NM++;
						Det.ZM [Det.NM] = Seg [num4].Z + num16;
						Det.M [Det.NM] = num6 + num5 * num16 + w * num16 * num16 / 2f + num15 * num16 * num16 * num16 / 6f;
					}
				}
				num17 = (short)(num17 + 1);
				array [num17] = num10;
				short num21 = 0;
				float num22 = 0f;
				float num23 = num6;
				short num24 = num17;
				for (short num20 = 1; num20 <= num24; num20 = (short)unchecked(num20 + 1)) {
					float num25 = num22;
					float num26 = num23;
					num22 = array [num20];
					num23 = num6 + num5 * num22 + w * num22 * num22 / 2f + num15 * num22 * num22 * num22 / 6f;
					if (System.Math.Sign (num26) != System.Math.Sign (num23)) {
						float num16 = num25 + (num22 - num25) * (0f - num26) / (num23 - num26);
						while (true) {
							float num27 = num5 + w * num16 + num15 * num16 * num16 / 2f;
							float num28 = num6 + num5 * num16 + w * num16 * num16 / 2f + num15 * num16 * num16 * num16 / 6f;
							if (unchecked(System.Math.Abs (num28) <= num * System.Math.Abs (num27) || num27 == 0f)) {
								break;
							}
							num16 += (0f - num28) / num27;
						}
						bool flag = false;
						if (num21 == 0 || System.Math.Abs (Seg [num4].Z + num16 - array2 [num21]) > num) {
							flag = true;
						}
						if (flag) {
							num21 = (short)(num21 + 1);
							array2 [num21] = num16;
						}
					}
				}
				short num29 = num21;
				for (short num20 = 1; num20 <= num29; num20 = (short)unchecked(num20 + 1)) {
					float num16 = array2 [num20];
					if ((System.Math.Abs (Seg [num4].Z + num16 - Znode [1]) > 1000f * num) & (System.Math.Abs (Seg [num4].Z + num16 - Znode [nNode]) > 1000f * num)) {
						Det.NR++;
						Det.ZR [Det.NR] = Seg [num4].Z + num16;
						Det.R [Det.NR] = (float)((double)num7 + ((double)(num6 * num16 + num5 * num16 * num16 / 2f + w * num16 * num16 * num16 / 6f) + (double)num15 * System.Math.Pow (num16, 4.0) / 24.0) / (double)num9);
					}
				}
				num21 = (short)(num21 + 1);
				array2 [num21] = num10;
				num22 = 0f;
				float num30 = num9 * num7;
				short num31 = num21;
				for (short num20 = 1; num20 <= num31; num20 = (short)unchecked(num20 + 1)) {
					float num25 = num22;
					float num32 = num30;
					num22 = array2 [num20];
					num30 = num9 * num7 + num6 * num22 + num5 * num22 * num22 / 2f + w * num22 * num22 * num22 / 6f + num15 * num22 * num22 * num22 * num22 / 24f;
					if (System.Math.Sign (num32) != System.Math.Sign (num30)) {
						float num16 = num25 + (num22 - num25) * (0f - num32) / (num30 - num32);
						while (true) {
							float num28 = num6 + num5 * num16 + w * num16 * num16 / 2f + num15 * num16 * num16 * num16 / 6f;
							float num33 = num9 * num7 + num6 * num16 + num5 * num16 * num16 / 2f + w * num16 * num16 * num16 / 6f + num15 * num16 * num16 * num16 * num16 / 24f;
							if (unchecked(System.Math.Abs (num33) <= num * System.Math.Abs (num28) || num28 == 0f)) {
								break;
							}
							num16 += (0f - num33) / num28;
						}
						bool flag = false;
						if (Det.ND == 0 || System.Math.Abs (Seg [num4].Z + num16 - Det.ZD [Det.ND]) > num) {
							flag = true;
						}
						if (flag) {
							Det.ND++;
							Det.ZD [Det.ND] = Seg [num4].Z + num16;
							Det.D [Det.ND] = (float)((double)(num8 + num7 * num16) + ((double)(num6 * num16 * num16 / 2f + num5 * num16 * num16 * num16 / 6f) + (double)w * System.Math.Pow (num16, 4.0) / 24.0 + (double)num15 * System.Math.Pow (num16, 5.0) / 120.0) / (double)num9);
						}
					}
				}
				num8 += num7 * num10 + (num6 * num11 / 2f + num5 * num12 / 6f + w * num13 / 24f + num15 * num14 / 120f) / num9;
				num7 += (num6 * num10 + num5 * num11 / 2f + w * num12 / 6f + num15 * num13 / 24f) / num9;
				num6 += num5 * num10 + w * num11 / 2f + num15 * num12 / 6f;
				num5 += w * num10 + num15 * num11 / 2f;
				w += num15 * num10;
			}
			if (D [nNode] == 0f) {
				Det.NV++;
				Det.ZV [Det.NV] = Znode [nNode];
				Det.V [Det.NV] = 0f - V [num2, 2];
			} else {
				bool flag = false;
				if (Det.ND == 0 || System.Math.Abs (Znode [nNode] - Det.ZD [Det.ND]) > num) {
					flag = true;
				}
				if (flag) {
					Det.ND++;
					Det.ZD [Det.ND] = Znode [nNode];
					Det.D [Det.ND] = D [nNode];
				}
			}
			if (R [nNode] == 0f) {
				bool flag = false;
				if (Det.NM == 0 || System.Math.Abs (Znode [nNode] - Det.ZM [Det.NM]) > num) {
					flag = true;
				}
				if (flag) {
					Det.NM++;
					Det.ZM [Det.NM] = Znode [nNode];
					Det.M [Det.NM] = M [nNode];
				}
				flag = false;
				if (Det.ND == 0 || System.Math.Abs (Znode [nNode] - Det.ZD [Det.ND]) > num) {
					flag = true;
				}
				if (flag) {
					Det.ND++;
					Det.ZD [Det.ND] = Znode [nNode];
					Det.D [Det.ND] = D [nNode];
				}
			} else if (Seg [num4].M0 != 0f) {
				Det.NM++;
				Det.ZM [Det.NM] = Seg [num4].Z;
				Det.M [Det.NM] = 0f - Seg [num4].M0;
			}
		}
	}
}
