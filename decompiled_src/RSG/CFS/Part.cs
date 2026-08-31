// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

internal class Part
{
	public string Name;

	public bool Centerline;

	public bool Closed;

	public short ThicknessIndex;

	public float Thickness;

	public float DefRad;

	public float XPosition;

	public float YPosition;

	public byte iXPosition;

	public byte iYPosition;

	public Element[] Element;

	public ElementGroupType[] ElementGroup;

	public GridState ElemGrid;

	public byte nElem;

	public byte nElemGrp;

	public float A;

	public float Xcg;

	public float Ycg;

	public float Xleft;

	public float Xright;

	public float Ytop;

	public float Ybottom;

	public float Xlefte;

	public float Xrighte;

	public float Ytope;

	public float Ybottome;

	public float Be1;

	public float Ben;

	public float Avx;

	public float Avy;

	public float Ix;

	public float Iy;

	public float Ixy;

	public float Alpha;

	public float SAX3;

	public float SAY3;

	public float SAYX2;

	public float SAXY2;

	public float Xo;

	public float Yo;

	public float Cw;

	public float J;

	public float WnMax;

	public float Zw;

	public float An;

	public float Xcgn;

	public float Ycgn;

	public float Ixn;

	public float Iyn;

	public float Ixyn;

	public float Alphan;

	public float SAX3n;

	public float SAY3n;

	public float SAYX2n;

	public float SAXY2n;

	public float Xon;

	public float Yon;

	public float Cwn;

	public float Jn;

	public float WnnMax;

	public float Zwn;

	public TorsionData[] TPg;

	public TorsionData[] TPn;

	private float Xmin;

	private float Ymin;

	private float Xmax;

	private float Ymax;

	private float Xmine;

	private float Ymine;

	private float Xmaxe;

	private float Ymaxe;

	public Part ()
	{
		Initialize (10);
	}

	public void Initialize (byte Elements = 10)
	{
		Name = string.Empty;
		Centerline = false;
		Closed = false;
		ThicknessIndex = CFS.iThickness;
		Thickness = CFS.Thicknesses [CFS.iThickness].Thickness;
		DefRad = CFS.Thicknesses [CFS.iThickness].DefRad;
		XPosition = 0f;
		iXPosition = 1;
		YPosition = 0f;
		iYPosition = 1;
		checked {
			Element = new Element[unchecked((int)Elements) + 1];
			ElementGroup = new ElementGroupType[unchecked((int)Elements) + 1];
			nElem = 0;
			A = 0f;
			Xcg = 0f;
			Ycg = 0f;
			Xleft = 0f;
			Xright = 0f;
			Ytop = 0f;
			Ybottom = 0f;
			ElemGrid = new GridState (1, 1);
		}
	}

	public Part Clone ()
	{
		Part part = (Part)MemberwiseClone ();
		checked {
			if (!Information.IsNothing (Element)) {
				part.Element = new Element[Information.UBound (Element) + 1];
				int num = Information.LBound (Element);
				int num2 = Information.UBound (Element);
				for (int i = num; i <= num2; i++) {
					part.Element [i] = Element [i];
				}
			}
			if (!Information.IsNothing (ElementGroup)) {
				part.ElementGroup = new ElementGroupType[Information.UBound (ElementGroup) + 1];
				int num3 = Information.LBound (ElementGroup);
				int num4 = Information.UBound (ElementGroup);
				for (int j = num3; j <= num4; j++) {
					part.ElementGroup [j] = ElementGroup [j];
				}
			}
			if (!Information.IsNothing (TPg)) {
				part.TPg = (TorsionData[])TPg.Clone ();
			}
			if (!Information.IsNothing (TPn)) {
				part.TPn = (TorsionData[])TPn.Clone ();
			}
			return part;
		}
	}

	internal void Geometry (ref bool blnChg, ref string strMsg)
	{
		blnChg = false;
		strMsg = string.Empty;
		checked {
			float ang = default(float);
			float num35 = default(float);
			while (true) {
				float thickness = Thickness;
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				float num4 = 0f;
				short num5 = nElem;
				short num6 = 1;
				while (true) {
					float num19;
					float num20;
					if (num6 > num5) {
						if (Closed) {
							Element [1].Wid = Element [1].Wid - num4;
							Element [1].X0 = (float)((double)num + (double)num3 * System.Math.Cos (Element [1].Ang));
							Element [1].Y0 = (float)((double)num2 + (double)num3 * System.Math.Sin (Element [1].Ang));
						}
						float num7 = 0f;
						float num8 = 0f;
						float num9 = 0f;
						float num10 = thickness * thickness * thickness;
						short num11 = nElem;
						for (num6 = 1; num6 <= num11; num6 = (short)unchecked(num6 + 1)) {
							short num12 = ((num6 != 1) ? ((short)(num6 - 1)) : nElem);
							float num16;
							if ((num6 > 1) | Closed) {
								float num13 = Element [num6].Rad + thickness / 2f;
								float num14 = Element [num6].Arc / 2f;
								float num15 = (float)((double)Element [num12].Ang - (double)System.Math.Sign (num14) * System.Math.PI / 2.0 + (double)num14);
								num14 = System.Math.Abs (num14);
								num16 = 2f * num13 * thickness * num14;
								float num17 = num13 * num13 * thickness + num10 / 12f;
								num7 += num16;
								num8 = (float)((double)num8 + ((double)(num16 * Element [num6].Xac) + (double)(num17 * 2f) * System.Math.Sin (num14) * System.Math.Cos (num15)));
								num9 = (float)((double)num9 + ((double)(num16 * Element [num6].Yac) + (double)(num17 * 2f) * System.Math.Sin (num14) * System.Math.Sin (num15)));
							}
							num16 = thickness * Element [num6].Wid;
							num7 += num16;
							num8 += num16 * (Element [num6].X0 + Element [num6].X1) / 2f;
							num9 += num16 * (Element [num6].Y0 + Element [num6].Y1) / 2f;
						}
						this.A = num7;
						if (num7 > 0f) {
							Xcg = num8 / num7;
							Ycg = num9 / num7;
						} else {
							Xcg = 0f;
							Ycg = 0f;
						}
						if (!Closed & (nElem > 0)) {
							float num16 = thickness * Element [1].Wid;
							num7 -= num16;
							num8 -= num16 * (Element [1].X0 + Element [1].X1) / 2f;
							num9 -= num16 * (Element [1].Y0 + Element [1].Y1) / 2f;
							if (nElem > 1) {
								num16 = thickness * Element [nElem].Wid;
								num7 -= num16;
								num8 -= num16 * (Element [nElem].X0 + Element [nElem].X1) / 2f;
								num9 -= num16 * (Element [nElem].Y0 + Element [nElem].Y1) / 2f;
							}
						}
						if (num7 > 0f) {
							Xmine = num8 / num7;
							Ymine = num9 / num7;
						} else {
							Xmine = Xcg;
							Ymine = Ycg;
						}
						Xmin = Xcg;
						Ymin = Ycg;
						Xmax = Xcg;
						Ymax = Ycg;
						Xmaxe = Xmine;
						Ymaxe = Ymine;
						if (nElem > 0) {
							ang = Element [nElem].Ang;
						}
						short num18 = nElem;
						for (num6 = 1; num6 <= num18; num6 = (short)unchecked(num6 + 1)) {
							unchecked {
								if ((num6 > 1) | Closed) {
									float num13 = Element [num6].Rad + thickness;
									float A = (float)((double)ang - (double)System.Math.Sign (Element [num6].Arc) * System.Math.PI / 2.0);
									float B = A + Element [num6].Arc;
									if (A > B) {
										CFS.Swap (ref A, ref B);
									}
									if ((double)A < -System.Math.PI && (double)B > -System.Math.PI) {
										num = Element [num6].Xac - num13;
										CheckX (num);
									}
									if ((double)A < -System.Math.PI / 2.0 && (double)B > -System.Math.PI / 2.0) {
										num2 = Element [num6].Yac - num13;
										CheckY (num2);
									}
									if (A < 0f && B > 0f) {
										num = Element [num6].Xac + num13;
										CheckX (num);
									}
									if ((double)A < System.Math.PI / 2.0 && (double)B > System.Math.PI / 2.0) {
										num2 = Element [num6].Yac + num13;
										CheckY (num2);
									}
									if ((double)A < System.Math.PI && (double)B > System.Math.PI) {
										num = Element [num6].Xac - num13;
										CheckX (num);
									}
									if ((double)A < 4.71238898038469 && (double)B > 4.71238898038469) {
										num2 = Element [num6].Yac - num13;
										CheckY (num2);
									}
									if ((double)A < System.Math.PI * 2.0 && (double)B > System.Math.PI * 2.0) {
										num = Element [num6].Xac + num13;
										CheckX (num);
									}
								}
								ang = Element [num6].Ang;
								num19 = (float)((double)(thickness / 2f) * System.Math.Sin (ang));
								num20 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (ang));
								bool blnEff = Closed || num6 > 1;
								num = Element [num6].X0 - num19;
								CheckX (num, blnEff);
								num = Element [num6].X0 + num19;
								CheckX (num, blnEff);
								num2 = Element [num6].Y0 - num20;
								CheckY (num2, blnEff);
								num2 = Element [num6].Y0 + num20;
								CheckY (num2, blnEff);
								blnEff = Closed | (num6 < nElem);
								num = Element [num6].X1 - num19;
								CheckX (num, blnEff);
								num = Element [num6].X1 + num19;
								CheckX (num, blnEff);
								num2 = Element [num6].Y1 - num20;
								CheckY (num2, blnEff);
								num2 = Element [num6].Y1 + num20;
								CheckY (num2, blnEff);
							}
						}
						if (iXPosition == 0) {
							XPosition = XPosition - Xleft + (Xcg - Xmin);
						}
						if (iXPosition == 2) {
							XPosition = XPosition + Xright - (Xmax - Xcg);
						}
						if (iYPosition == 0) {
							YPosition = YPosition + Ytop - (Ymax - Ycg);
						}
						if (iYPosition == 2) {
							YPosition = YPosition - Ybottom + (Ycg - Ymin);
						}
						Xleft = Xcg - Xmin;
						Xright = Xmax - Xcg;
						Ytop = Ymax - Ycg;
						Ybottom = Ycg - Ymin;
						Xlefte = Xcg - Xmine;
						Xrighte = Xmaxe - Xcg;
						Ytope = Ymaxe - Ycg;
						Ybottome = Ycg - Ymine;
						ElementGroup = new ElementGroupType[unchecked((int)nElem) + 1];
						nElemGrp = 0;
						short num21 = nElem;
						for (num6 = 1; num6 <= num21; num6 = (short)unchecked(num6 + 1)) {
							nElemGrp++;
							ElementGroup [nElemGrp].iElemFirst = num6;
							ElementGroup [nElemGrp].iElemLast = num6;
							ElementGroup [nElemGrp].Ns = 0;
							short num22 = 0;
							if ((Element [num6].K == 0f) & (((num6 >= 2) & (num6 <= unchecked((int)nElem) - 2)) | Closed)) {
								float num23 = Element [num6].Wid;
								float num24 = num23;
								short num25 = num6;
								float num26 = 0f;
								int num27 = nElem;
								for (int i = 1; i <= num27; i++) {
									num26 = (float)CFS.Max (num26, Distance (Element [num6], Element [i].X0, Element [i].Y0));
									num26 = (float)CFS.Max (num26, Distance (Element [num6], Element [i].X1, Element [i].Y1));
								}
								while (true) {
									if (Closed) {
										unchecked {
											num25 = (short)((num25 == nElem) ? 1 : checked((short)(num25 + 1)));
											if (num25 == num6) {
												break;
											}
										}
									} else {
										num25 = (short)(num25 + 1);
										if (num25 >= nElem) {
											break;
										}
									}
									if (Element [num25].K > 0f || Distance (Element [num6], Element [num25].X0, Element [num25].Y0) >= num26 / 2f || Distance (Element [num6], Element [num25].X1, Element [num25].Y1) >= num26 / 2f) {
										break;
									}
									num24 += Element [num25].Wid;
									if (CollinearElements (Element [num6], Element [num25])) {
										num23 += Element [num25].Wid;
										num22 = (short)(num22 + 1);
										if ((double)num23 >= 0.5 * (double)num24) {
											ElementGroup [nElemGrp].iElemLast = num25;
											ElementGroup [nElemGrp].Ns = num22;
										}
									}
								}
								num6 = ElementGroup [nElemGrp].iElemLast;
								if (num6 < ElementGroup [nElemGrp].iElemFirst) {
									short num28 = 0;
									short num29 = (short)(unchecked((int)nElemGrp) - 1);
									for (num25 = 1; num25 <= num29; num25 = (short)unchecked(num25 + 1)) {
										if (ElementGroup [num25].iElemLast == num6) {
											num28 = num25;
											break;
										}
									}
									ref byte reference = ref nElemGrp;
									reference = (byte)(short)unchecked(reference - num28);
									short num30 = nElemGrp;
									for (num25 = 1; num25 <= num30; num25 = (short)unchecked(num25 + 1)) {
										ElementGroup [num25] = ElementGroup [(short)unchecked(num25 + num28)];
									}
									break;
								}
							}
						}
						return;
					}
					short num31;
					float num32;
					float num33;
					unchecked {
						num31 = (short)((num6 == nElem) ? 1 : checked((short)(num6 + 1)));
						ang = Element [num6].Ang;
						num32 = (float)System.Math.Sin (ang);
						num33 = (float)System.Math.Cos (ang);
					}
					float len;
					float ang2;
					if ((num31 == nElem) & Closed) {
						len = Element [num31].Len;
						ang2 = Element [num31].Ang;
						num19 = 0f - (num + (Element [num6].Len - (num4 - num3)) * num33);
						num20 = 0f - (num2 + (Element [num6].Len - (num4 - num3)) * num32);
						Element [num31].Ang = (float)System.Math.Atan2 (num20, num19);
						if (!Centerline) {
							int num34 = 1;
							while (true) {
								float A = (float)System.Math.Sin (Element [num31].Ang - ang);
								if ((double)System.Math.Abs (A) < 0.0001) {
									A = 0f;
								}
								float B = (float)System.Math.Sin (Element [1].Ang - Element [num31].Ang);
								if ((double)System.Math.Abs (B) < 0.0001) {
									B = 0f;
								}
								A = System.Math.Sign (A);
								B = System.Math.Sign (B);
								if (A == 0f) {
									A = B;
								}
								if (B == 0f) {
									B = A;
								}
								num19 = (float)(0.0 + (double)(B * thickness / 2f) * System.Math.Sin (Element [1].Ang) - (double)(num + (Element [num6].Len - (num4 - num3)) * num33 + A * thickness / 2f * num32));
								num20 = (float)(0.0 - (double)(B * thickness / 2f) * System.Math.Cos (Element [1].Ang) - (double)(num2 + (Element [num6].Len - (num4 - num3)) * num32 - A * thickness / 2f * num33));
								if (A * B >= 0f) {
									Element [num31].Ang = (float)System.Math.Atan2 (num20, num19);
								} else {
									if (((double)(num19 * num19 + num20 * num20) <= 2.0001 * (double)thickness * (double)thickness) & (nElem > 2)) {
										break;
									}
									if (System.Math.Abs (num19) > System.Math.Abs (num20)) {
										Element [num31].Ang = (float)System.Math.Atan (((double)(num19 * num20) - (double)A * System.Math.Sqrt (num19 * num19 * num20 * num20 - (num19 * num19 - thickness * thickness) * (num20 * num20 - thickness * thickness))) / (double)(num19 * num19 - thickness * thickness));
										if (num19 < 0f) {
											Element [num31].Ang = (float)((double)Element [num31].Ang + System.Math.PI);
										}
									} else {
										Element [num31].Ang = (float)(System.Math.PI / 2.0 - System.Math.Atan (((double)(num19 * num20) + (double)A * System.Math.Sqrt (num19 * num19 * num20 * num20 - (num19 * num19 - thickness * thickness) * (num20 * num20 - thickness * thickness))) / (double)(num20 * num20 - thickness * thickness)));
										if (num20 < 0f) {
											Element [num31].Ang = (float)((double)Element [num31].Ang + System.Math.PI);
										}
									}
									num19 = (float)((double)num19 + (double)(A * thickness) * System.Math.Sin (Element [num31].Ang));
									num20 = (float)((double)num20 - (double)(A * thickness) * System.Math.Cos (Element [num31].Ang));
								}
								num34++;
								if (num34 <= 2) {
									continue;
								}
								goto IL_04c4;
							}
							break;
						}
						goto IL_04c4;
					}
					goto IL_0591;
					IL_0591:
					float num36;
					float num37;
					if ((num6 < nElem) | Closed) {
						float num14 = Element [num31].Ang - ang;
						float num13 = Element [num31].Rad;
						while ((double)num14 > System.Math.PI) {
							num14 = (float)((double)num14 - System.Math.PI * 2.0);
						}
						while ((double)num14 < -System.Math.PI) {
							num14 = (float)((double)num14 + System.Math.PI * 2.0);
						}
						if (System.Math.Abs ((double)System.Math.Abs (num14) - System.Math.PI) < 1E-05) {
							num14 = 0f;
						}
						Element [num31].Arc = num14;
						num35 = (float)System.Math.Tan (num14 / 2f);
						num36 = (num13 + thickness / 2f) * System.Math.Abs (num35);
						num37 = ((!Centerline) ? ((num13 + thickness) * System.Math.Abs (num35)) : num36);
					} else {
						Element [num31].Arc = 0f;
						num36 = 0f;
						num37 = 0f;
					}
					Element [num6].Wid = Element [num6].Len - num4 - num37;
					unchecked {
						if ((Element [num6].Wid < 0f) & ((num6 < nElem) | !Closed)) {
							float len2 = Element [num6].Len;
							Element [num6].Len = (num4 + num37) * 1.000001f;
							Element [num6].Wid = Element [num6].Len - num4 - num37;
							if (System.Math.Abs (1f - len2 / Element [num6].Len) > 1E-05f) {
								strMsg = strMsg + Name + " element " + Conversions.ToString ((int)num6) + " has been lengthened.\r\n";
							}
							blnChg = true;
						}
						if ((Element [num6].Hole > Element [num6].Wid * 0.999999f) & (Element [num6].Wid >= 0f)) {
							float len2 = Element [num6].Hole;
							Element [num6].Hole = Element [num6].Wid * 0.999999f;
							if (Element [num6].Hole < 0f) {
								Element [num6].Hole = 0f;
							}
							if (System.Math.Abs (1f - Element [num6].Hole / len2) > 1E-05f) {
								strMsg = strMsg + Name + " element " + Conversions.ToString ((int)num6) + " hole has been reduced.\r\n";
							}
							blnChg = true;
						}
						if ((Element [num6].Hole > 0f) & ((double)Element [num6].Dist - 0.5 * (double)Element [num6].Hole < (double)num4)) {
							float len2 = Element [num6].Dist;
							Element [num6].Dist = (float)(((double)num4 + 0.5 * (double)Element [num6].Hole) * 1.0000009536743164);
							if (System.Math.Abs (1f - len2 / Element [num6].Dist) > 1E-05f) {
								strMsg = strMsg + Name + " element " + Conversions.ToString ((int)num6) + " hole has been moved.\r\n";
							}
							blnChg = true;
						}
						if ((Element [num6].Hole > 0f) & ((double)Element [num6].Dist + 0.5 * (double)Element [num6].Hole > (double)(Element [num6].Len - num37))) {
							float len2 = Element [num6].Dist;
							Element [num6].Dist = (float)(((double)(Element [num6].Len - num37) - 0.5 * (double)Element [num6].Hole) * 0.99999898672103882);
							if (System.Math.Abs (1f - Element [num6].Dist / len2) > 1E-05f) {
								strMsg = strMsg + Name + " element " + Conversions.ToString ((int)num6) + " hole has been moved.\r\n";
							}
							blnChg = true;
						}
						if ((Element [num6].Hole == 0f) & ((Element [num6].Dist <= 0f) | (Element [num6].Dist >= Element [num6].Len))) {
							Element [num6].Dist = Element [num6].Len / 2f;
							blnChg = true;
						}
						Element [num6].X0 = num + num3 * num33;
						Element [num6].Y0 = num2 + num3 * num32;
						Element [num6].X1 = Element [num6].X0 + Element [num6].Wid * num33;
						Element [num6].Y1 = Element [num6].Y0 + Element [num6].Wid * num32;
						Element [num6].Xh0 = (float)((double)Element [num6].X0 + ((double)(Element [num6].Dist - num4) - 0.5 * (double)Element [num6].Hole) * (double)num33);
						Element [num6].Yh0 = (float)((double)Element [num6].Y0 + ((double)(Element [num6].Dist - num4) - 0.5 * (double)Element [num6].Hole) * (double)num32);
						Element [num6].Xh1 = Element [num6].Xh0 + Element [num6].Hole * num33;
						Element [num6].Yh1 = Element [num6].Yh0 + Element [num6].Hole * num32;
						num = Element [num6].X1 + num36 * num33;
						num2 = Element [num6].Y1 + num36 * num32;
						if ((num6 < nElem) | Closed) {
							float len2 = ((num35 != 0f) ? (num36 / num35) : 0f);
							Element [num31].Xac = Element [num6].X1 - len2 * num32;
							Element [num31].Yac = Element [num6].Y1 + len2 * num33;
						} else {
							Element [num31].Xac = Element [num31].X0;
							Element [num31].Yac = Element [num31].Y0;
						}
						num3 = num36;
						num4 = num37;
					}
					num6 = (short)unchecked(num6 + 1);
					continue;
					IL_04c4:
					if (System.Math.Abs (Element [num31].Ang) < 1E-06f) {
						Element [num31].Ang = 0f;
					}
					Element [num31].Len = (float)(System.Math.Sqrt (num19 * num19 + num20 * num20) * 1.0000009536743164);
					if (Element [num31].Len != len) {
						Element [num31].Dist = Element [num31].Len / 2f;
					}
					if (Element [num31].Ang != ang2) {
						blnChg = true;
					}
					if (Element [num31].Len != len) {
						blnChg = true;
					}
					goto IL_0591;
				}
				strMsg = strMsg + Name + " element " + Conversions.ToString (nElem) + " has been removed.\r\n";
				nElem--;
				blnChg = true;
			}
		}
	}

	private void CheckX (float X, bool blnEff = true)
	{
		if (X < Xmin) {
			Xmin = X;
		}
		if (X > Xmax) {
			Xmax = X;
		}
		if (blnEff) {
			if (X < Xmine) {
				Xmine = X;
			}
			if (X > Xmaxe) {
				Xmaxe = X;
			}
		}
	}

	private void CheckY (float Y, bool blnEff = true)
	{
		if (Y < Ymin) {
			Ymin = Y;
		}
		if (Y > Ymax) {
			Ymax = Y;
		}
		if (blnEff) {
			if (Y < Ymine) {
				Ymine = Y;
			}
			if (Y > Ymaxe) {
				Ymaxe = Y;
			}
		}
	}

	internal void Rotate (float sngAngle)
	{
		string strMsg = string.Empty;
		int num = nElem;
		checked {
			float num2;
			for (int i = 1; i <= num; i++) {
				num2 = Element [i].Ang + sngAngle;
				while ((double)num2 <= -System.Math.PI) {
					num2 = (float)((double)num2 + System.Math.PI * 2.0);
				}
				while ((double)num2 >= System.Math.PI * 2.0) {
					num2 = (float)((double)num2 - System.Math.PI * 2.0);
				}
				Element [i].Ang = num2;
			}
			short num3 = iXPosition;
			short num4 = iYPosition;
			iXPosition = 1;
			iYPosition = 1;
			bool blnChg = default(bool);
			Geometry (ref blnChg, ref strMsg);
			float num5 = (float)System.Math.Sqrt (System.Math.Pow (XPosition, 2.0) + System.Math.Pow (YPosition, 2.0));
			num2 = (float)System.Math.Atan2 (YPosition, XPosition);
			XPosition = (float)((double)num5 * System.Math.Cos (sngAngle + num2));
			YPosition = (float)((double)num5 * System.Math.Sin (sngAngle + num2));
			if (System.Math.Cos (sngAngle) >= 0.99999898672103882) {
				iXPosition = (byte)num3;
				iYPosition = (byte)num4;
			} else if (System.Math.Cos (sngAngle) <= -0.99999898672103882) {
				iXPosition = (byte)(2 - num3);
				iYPosition = (byte)(2 - num4);
			} else if (System.Math.Sin (sngAngle) >= 0.99999898672103882) {
				iXPosition = (byte)num4;
				iYPosition = (byte)(2 - num3);
			} else if (System.Math.Sin (sngAngle) <= -0.99999898672103882) {
				iXPosition = (byte)(2 - num4);
				iYPosition = (byte)num3;
			}
		}
	}

	internal void CalcProperties (bool blnCalcTorsion = true)
	{
		_ = new TorsionData[1];
		float thickness = Thickness;
		float num = thickness * thickness * thickness;
		float num2 = thickness * thickness * num;
		float num3 = 0f;
		Avx = 0f;
		Avy = 0f;
		Ix = 0f;
		Iy = 0f;
		Ixy = 0f;
		SAX3 = 0f;
		SAY3 = 0f;
		SAXY2 = 0f;
		SAYX2 = 0f;
		float ang = Element [nElem].Ang;
		short num4 = nElem;
		checked {
			float num42 = default(float);
			float num43 = default(float);
			for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
				float num12;
				float num15;
				float num27;
				float num32;
				float num33;
				float num34;
				if ((num5 > 1) | Closed) {
					float num6 = Element [num5].Rad + thickness / 2f;
					float num7 = num6 * num6;
					float num8 = num6 * num7;
					float num9 = num6 * num8;
					float num10 = Element [num5].Arc / 2f;
					float num11 = (float)((double)ang - (double)System.Math.Sign (num10) * System.Math.PI / 2.0 + (double)num10);
					num10 = System.Math.Abs (num10);
					num12 = (float)System.Math.Sin (num10);
					float num13 = num12 * num12;
					float num14 = num12 * num13;
					num15 = (float)System.Math.Cos (num10);
					float num16 = num15 * num15;
					float num17 = (float)System.Math.Sin (num11);
					float num18 = num17 * num17;
					float num19 = num17 * num18;
					float num20 = (float)System.Math.Cos (num11);
					float num21 = num20 * num20;
					float num22 = num20 * num21;
					float xac = Element [num5].Xac;
					float num23 = xac * xac;
					float num24 = xac * num23;
					float yac = Element [num5].Yac;
					float num25 = yac * yac;
					float num26 = yac * num25;
					num27 = 2f * num6 * thickness * num10;
					float num28 = num7 * thickness + num / 12f;
					float num29 = num28 * 2f * num12 * num20;
					float num30 = num28 * 2f * num12 * num17;
					float num31 = num8 * thickness + num6 * num / 4f;
					num32 = num31 * (num10 + num12 * num15 * (2f * num21 - 1f));
					num33 = num31 * (num10 + num12 * num15 * (2f * num18 - 1f));
					num34 = num31 * 2f * num12 * num15 * num17 * num20;
					float num35 = num9 * thickness + num7 * num / 2f + num2 / 80f;
					float num36 = num35 * 2f / 3f * (num12 * (num16 + 2f) * num22 + num14 * num18 * num20);
					float num37 = num35 * 2f / 3f * (num12 * (num16 + 2f) * num19 + num14 * num21 * num17);
					float num38 = num35 * 2f / 3f * (num12 * (num16 + 2f) * num18 * num20 + num14 * (num22 - 2f * num18 * num20));
					float num39 = num35 * 2f / 3f * (num12 * (num16 + 2f) * num21 * num17 + num14 * (num19 - 2f * num21 * num17));
					float num40 = num27 * num23 + 2f * num29 * xac + num32;
					float num41 = num27 * num25 + 2f * num30 * yac + num33;
					num3 += num27;
					num42 += num27 * xac + num29;
					num43 += num27 * yac + num30;
					Iy += num40;
					Ix += num41;
					Ixy += num27 * xac * yac + num29 * yac + num30 * xac + num34;
					SAX3 += num27 * num24 + 3f * num29 * num23 + 3f * num32 * xac + num36;
					SAY3 += num27 * num26 + 3f * num30 * num25 + 3f * num33 * yac + num37;
					SAXY2 += num41 * xac + num29 * num25 + 2f * num34 * yac + num38;
					SAYX2 += num40 * yac + num30 * num23 + 2f * num34 * xac + num39;
				}
				float wid = Element [num5].Wid;
				ang = Element [num5].Ang;
				num12 = (float)System.Math.Sin (ang);
				num15 = (float)System.Math.Cos (ang);
				float num44 = (Element [num5].X0 + Element [num5].X1) / 2f;
				float num45 = (Element [num5].Y0 + Element [num5].Y1) / 2f;
				num27 = thickness * wid;
				num32 = (float)((double)num27 * (System.Math.Pow (wid * num15, 2.0) + System.Math.Pow (thickness * num12, 2.0)) / 12.0);
				num33 = (float)((double)num27 * (System.Math.Pow (wid * num12, 2.0) + System.Math.Pow (thickness * num15, 2.0)) / 12.0);
				num34 = num27 * (wid * wid - thickness * thickness) * num12 * num15 / 12f;
				num3 += num27;
				num42 += num27 * num44;
				num43 += num27 * num45;
				Iy += num27 * num44 * num44 + num32;
				Ix += num27 * num45 * num45 + num33;
				Ixy += num27 * num44 * num45 + num34;
				SAX3 += num27 * num44 * num44 * num44 + 3f * num32 * num44;
				SAY3 += num27 * num45 * num45 * num45 + 3f * num33 * num45;
				SAXY2 += num27 * num44 * num45 * num45 + num33 * num44 + 2f * num34 * num45;
				SAYX2 += num27 * num45 * num44 * num44 + num32 * num45 + 2f * num34 * num44;
				if (Element [num5].Web != 1) {
					Avx += num27 * num15 * num15;
					Avy += num27 * num12 * num12;
				}
			}
			Ixn = Ix;
			Iyn = Iy;
			Ixyn = Ixy;
			SAX3n = SAX3;
			SAY3n = SAY3;
			SAXY2n = SAXY2;
			SAYX2n = SAYX2;
			A = num3;
			Xcg = num42 / num3;
			Ycg = num43 / num3;
			Ix -= num3 * Ycg * Ycg;
			Iy -= num3 * Xcg * Xcg;
			Ixy -= num3 * Ycg * Xcg;
			SAX3 -= 3f * Iy * Xcg + num3 * Xcg * Xcg * Xcg;
			SAY3 -= 3f * Ix * Ycg + num3 * Ycg * Ycg * Ycg;
			SAXY2 -= Ix * Xcg + 2f * Ixy * Ycg + num3 * Xcg * Ycg * Ycg;
			SAYX2 -= Iy * Ycg + 2f * Ixy * Xcg + num3 * Ycg * Xcg * Xcg;
			if (System.Math.Abs (Ix / Iy - 1f) < 0.0001f) {
				if (System.Math.Abs (Ixy) / (Ix + Iy) < 0.0001f) {
					Alpha = 0f;
				} else {
					Alpha = (float)((double)(-System.Math.Sign (Ixy)) * System.Math.PI / 4.0);
				}
			} else {
				Alpha = (float)(System.Math.Atan (2f * Ixy / (Iy - Ix)) / 2.0);
				if (Ix < Iy) {
					ref float alpha = ref Alpha;
					alpha = (float)((double)alpha + System.Math.PI / 2.0);
				}
				if ((double)Alpha > System.Math.PI / 2.0) {
					ref float alpha2 = ref Alpha;
					alpha2 = (float)((double)alpha2 - System.Math.PI);
				}
			}
			Xo = 0f;
			Yo = 0f;
			Cw = 0f;
			J = 0f;
			if (blnCalcTorsion) {
				TorsionProp ();
			}
			short num46 = nElem;
			for (short num5 = 1; num5 <= num46; num5 = (short)unchecked(num5 + 1)) {
				float wid = Element [num5].Hole;
				if (wid > 0f) {
					ang = Element [num5].Ang;
					float num12 = (float)System.Math.Sin (ang);
					float num15 = (float)System.Math.Cos (ang);
					float num44 = (Element [num5].Xh0 + Element [num5].Xh1) / 2f;
					float num45 = (Element [num5].Yh0 + Element [num5].Yh1) / 2f;
					float num27 = thickness * wid;
					float num32 = (float)((double)num27 * (System.Math.Pow (wid * num15, 2.0) + System.Math.Pow (thickness * num12, 2.0)) / 12.0);
					float num33 = (float)((double)num27 * (System.Math.Pow (wid * num12, 2.0) + System.Math.Pow (thickness * num15, 2.0)) / 12.0);
					float num34 = num27 * (wid * wid - thickness * thickness) * num12 * num15 / 12f;
					num3 -= num27;
					num42 -= num27 * num44;
					num43 -= num27 * num45;
					ref float iyn = ref Iyn;
					iyn = (float)((double)iyn - ((double)(num27 * num44 * num44) + (double)num27 * (System.Math.Pow (wid * num15, 2.0) + System.Math.Pow (thickness * num12, 2.0)) / 12.0));
					ref float ixn = ref Ixn;
					ixn = (float)((double)ixn - ((double)(num27 * num45 * num45) + (double)num27 * (System.Math.Pow (wid * num12, 2.0) + System.Math.Pow (thickness * num15, 2.0)) / 12.0));
					Ixyn -= num27 * num44 * num45 + num27 * ((wid * wid - thickness * thickness) * num12 * num15) / 12f;
					SAX3n -= num27 * num44 * num44 * num44 + 3f * num32 * num44;
					SAY3n -= num27 * num45 * num45 * num45 + 3f * num33 * num45;
					SAXY2n -= num27 * num44 * num45 * num45 + num33 * num44 + 2f * num34 * num45;
					SAYX2n -= num27 * num45 * num44 * num44 + num32 * num45 + 2f * num34 * num44;
				}
			}
			An = num3;
			Xcgn = num42 / num3;
			Ycgn = num43 / num3;
			Ixn -= num3 * Ycgn * Ycgn;
			Iyn -= num3 * Xcgn * Xcgn;
			Ixyn -= num3 * Ycgn * Xcgn;
			SAX3n -= 3f * Iyn * Xcgn + num3 * Xcgn * Xcgn * Xcgn;
			SAY3n -= 3f * Ixn * Ycgn + num3 * Ycgn * Ycgn * Ycgn;
			SAXY2n -= Ixn * Xcgn + 2f * Ixyn * Ycgn + num3 * Xcgn * Ycgn * Ycgn;
			SAYX2n -= Iyn * Ycgn + 2f * Ixyn * Xcgn + num3 * Ycgn * Xcgn * Xcgn;
			if (System.Math.Abs (Ixn / Iyn - 1f) < 0.0001f) {
				if (System.Math.Abs (Ixyn) / (Ixn + Iyn) < 0.0001f) {
					Alphan = 0f;
				} else {
					Alphan = (float)((double)(-System.Math.Sign (Ixyn)) * System.Math.PI / 4.0);
				}
			} else {
				Alphan = (float)(System.Math.Atan (2f * Ixyn / (Iyn - Ixn)) / 2.0);
				if (Ixn < Iyn) {
					ref float alphan = ref Alphan;
					alphan = (float)((double)alphan + System.Math.PI / 2.0);
				}
				if ((double)Alphan > System.Math.PI / 2.0) {
					ref float alphan2 = ref Alphan;
					alphan2 = (float)((double)alphan2 - System.Math.PI);
				}
			}
		}
		if (An < A && blnCalcTorsion) {
			TorsionProp (blnNet: true);
			return;
		}
		Xon = Xo;
		Yon = Yo;
		Cwn = Cw;
		Jn = J;
		WnnMax = WnMax;
		TPn = TPg;
	}

	internal void TorsionProp (bool blnNet = false, bool blnPlastic = false)
	{
		string strMsg = string.Empty;
		float num = Conversions.ToSingle (Interaction.IIf (blnNet, Alphan, Alpha));
		Part part = Clone ();
		short num2 = nElem;
		checked {
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				part.Element [num3].Ang = Element [num3].Ang - num;
			}
			bool blnChg = default(bool);
			part.Geometry (ref blnChg, ref strMsg);
			Part part2 = part;
			float thickness = part2.Thickness;
			num = part2.Element [part2.nElem].Ang;
			float num4 = (float)System.Math.Sin (num);
			float num5 = (float)System.Math.Cos (num);
			short num6 = part2.nElem;
			float num19 = default(float);
			float num20 = default(float);
			float num21 = default(float);
			float num22 = default(float);
			float num23 = default(float);
			float num27 = default(float);
			float num25;
			float num26;
			float num7;
			for (short num3 = 1; num3 <= num6; num3 = (short)unchecked(num3 + 1)) {
				if ((num3 > 1) | part2.Closed) {
					num7 = part2.Element [num3].Rad + thickness / 2f;
					float num8 = num7 * num7;
					float num9 = num7 * num8;
					float num10 = part2.Element [num3].Arc / 2f;
					float num11 = (float)((double)num - (double)System.Math.Sign (num10) * System.Math.PI / 2.0 + (double)num10);
					num10 = System.Math.Abs (num10);
					num4 = (float)System.Math.Sin (num10);
					num5 = (float)System.Math.Cos (num10);
					float num12 = (float)System.Math.Sin (num11);
					float num13 = (float)System.Math.Cos (num11);
					float xac = part2.Element [num3].Xac;
					float yac = part2.Element [num3].Yac;
					float num14 = 2f * num7 * num10;
					float num15 = 2f * num8 * num4 * num13;
					float num16 = 2f * num8 * num4 * num12;
					float num17 = num9 * (num10 + num4 * num5 * (2f * num13 * num13 - 1f));
					float num18 = num9 * (num10 + num4 * num5 * (2f * num12 * num12 - 1f));
					num19 += num14;
					num20 += num14 * xac + num15;
					num21 += num14 * yac + num16;
					num22 += num14 * xac * xac + 2f * num15 * xac + num17;
					num23 += num14 * yac * yac + 2f * num16 * yac + num18;
				}
				float num24 = part2.Element [num3].Wid;
				num = part2.Element [num3].Ang;
				num4 = (float)System.Math.Sin (num);
				num5 = (float)System.Math.Cos (num);
				num25 = (part2.Element [num3].X0 + part2.Element [num3].X1) / 2f;
				num26 = (part2.Element [num3].Y0 + part2.Element [num3].Y1) / 2f;
				if (blnNet & (part2.Element [num3].Hole > 0f)) {
					ref Element reference = ref part2.Element [num3];
					num24 = (float)System.Math.Sqrt (System.Math.Pow (reference.Xh0 - reference.X0, 2.0) + System.Math.Pow (reference.Yh0 - reference.Y0, 2.0));
					num25 = (reference.X0 + reference.Xh0) / 2f;
					num26 = (reference.Y0 + reference.Yh0) / 2f;
					num19 += num24;
					num20 += num24 * num25;
					num21 += num24 * num26;
					num22 += num24 * num25 * num25 + num24 * num24 * num24 * num5 * num5 / 12f;
					num23 += num24 * num26 * num26 + num24 * num24 * num24 * num4 * num4 / 12f;
					num27 += reference.Hole;
					num24 = reference.Wid - reference.Hole - num24;
					num25 = (reference.Xh1 + reference.X1) / 2f;
					num26 = (reference.Yh1 + reference.Y1) / 2f;
				}
				num19 += num24;
				num20 += num24 * num25;
				num21 += num24 * num26;
				num22 += num24 * num25 * num25 + num24 * num24 * num24 * num5 * num5 / 12f;
				num23 += num24 * num26 * num26 + num24 * num24 * num24 * num4 * num4 / 12f;
			}
			num25 = num20 / num19;
			num26 = num21 / num19;
			float num28 = num23 - num19 * num26 * num26;
			float num29 = num22 - num19 * num25 * num25;
			float num30 = num19 * thickness * thickness * thickness / 3f;
			float num31 = 0f;
			if (part2.Closed) {
				short num32 = part2.nElem;
				float num34 = default(float);
				float num35 = default(float);
				for (short num3 = 1; num3 <= num32; num3 = (short)unchecked(num3 + 1)) {
					short num33 = ((num3 != 1) ? ((short)(num3 - 1)) : part2.nElem);
					num34 += (part2.Element [num33].Y1 + part2.Element [num3].Y0) / 2f * (part2.Element [num33].X1 - part2.Element [num3].X0);
					num7 = part2.Element [num3].Rad + thickness / 2f;
					float num10 = part2.Element [num3].Arc;
					num34 = (float)((double)num34 + (double)(num7 * num7) * ((double)num10 - System.Math.Sin (num10)) / 2.0);
					num35 += num7 * System.Math.Abs (num10);
					num34 += (part2.Element [num3].Y0 + part2.Element [num3].Y1) / 2f * (part2.Element [num3].X0 - part2.Element [num3].X1);
					num35 += part2.Element [num3].Wid;
				}
				if (num35 > 0f) {
					if (!blnNet) {
						num30 = 4f * num34 * num34 * thickness / num35;
					}
					num31 = 2f * num34 / num35;
				}
			}
			float num36 = 0f;
			float num37 = 0f;
			float num38 = 0f;
			num = part2.Element [part2.nElem].Ang;
			num4 = (float)System.Math.Sin (num);
			num5 = (float)System.Math.Cos (num);
			short num39 = part2.nElem;
			for (short num3 = 1; num3 <= num39; num3 = (short)unchecked(num3 + 1)) {
				float num40;
				float num41;
				if ((num3 > 1) | part2.Closed) {
					num40 = part2.Element [num3].Xac - num25;
					num41 = part2.Element [num3].Yac - num26;
					num = part2.Element [num3].Arc;
					num7 = (float)System.Math.Sign (num) * (part2.Element [num3].Rad + thickness / 2f);
					float num8 = num7 * num7;
					float num9 = num7 * num8;
					float num12 = (float)System.Math.Sin (num);
					float num13 = (float)System.Math.Cos (num);
					float num42 = num40 * num4 - num41 * num5;
					float num43 = num40 * num5 + num41 * num4;
					float num44 = num7 - num31;
					num36 = num36 + num38 * num7 * num41 * num + num38 * num8 * num4 * (1f - num13) - num38 * num8 * num5 * num12 + num42 * num8 * num41 * (1f - num13) + num42 * num9 * num4 * (num - num12 * num13) / 2f - num42 * num9 * num5 * num12 * num12 / 2f + num43 * num8 * num41 * (num - num12) + num43 * num9 * num4 * (1f - num13 - num12 * num12 / 2f) - num43 * num9 * num5 * (num12 - (num + num12 * num13) / 2f) + num44 * num8 * num41 * num * num / 2f + num44 * num9 * num4 * (num12 - num * num13) - num44 * num9 * num5 * (num * num12 - (1f - num13));
					num37 = num37 + num38 * num7 * num40 * num + num38 * num8 * num5 * (1f - num13) + num38 * num8 * num4 * num12 + num42 * num8 * num40 * (1f - num13) + num42 * num9 * num5 * (num - num12 * num13) / 2f + num42 * num9 * num4 * num12 * num12 / 2f + num43 * num8 * num40 * (num - num12) + num43 * num9 * num5 * (1f - num13 - num12 * num12 / 2f) + num43 * num9 * num4 * (num12 - (num + num12 * num13) / 2f) + num44 * num8 * num40 * num * num / 2f + num44 * num9 * num5 * (num12 - num * num13) + num44 * num9 * num4 * (num * num12 - (1f - num13));
					num38 = num38 + num42 * num7 * num12 + num43 * num7 * (1f - num13) + num44 * num7 * num;
				}
				float num24 = part2.Element [num3].Wid;
				num = part2.Element [num3].Ang;
				num4 = (float)System.Math.Sin (num);
				num5 = (float)System.Math.Cos (num);
				num40 = part2.Element [num3].X0 - num25;
				num41 = part2.Element [num3].Y0 - num26;
				float num45 = num40 * num4 - num41 * num5 - num31;
				if (blnNet & (part2.Element [num3].Hole > 0f)) {
					ref Element reference2 = ref part2.Element [num3];
					num24 = (float)System.Math.Sqrt (System.Math.Pow (reference2.Xh0 - reference2.X0, 2.0) + System.Math.Pow (reference2.Yh0 - reference2.Y0, 2.0));
					num36 = (float)((double)(num36 + num38 * num41 * num24 + (num38 * num4 + num45 * num41) * num24 * num24 / 2f) + (double)(num45 * num4) * System.Math.Pow (num24, 3.0) / 3.0);
					num37 = (float)((double)(num37 + num38 * num40 * num24 + (num38 * num5 + num45 * num40) * num24 * num24 / 2f) + (double)(num45 * num5) * System.Math.Pow (num24, 3.0) / 3.0);
					num38 += num45 * num24;
					num38 += num45 * reference2.Hole;
					num24 = reference2.Wid - reference2.Hole - num24;
					num40 = reference2.Xh1 - num25;
					num41 = reference2.Yh1 - num26;
				}
				num36 = (float)((double)(num36 + num38 * num41 * num24 + (num38 * num4 + num45 * num41) * num24 * num24 / 2f) + (double)(num45 * num4) * System.Math.Pow (num24, 3.0) / 3.0);
				num37 = (float)((double)(num37 + num38 * num40 * num24 + (num38 * num5 + num45 * num40) * num24 * num24 / 2f) + (double)(num45 * num5) * System.Math.Pow (num24, 3.0) / 3.0);
				num38 += num45 * num24;
			}
			float num46 = ((!(num28 > 0f)) ? num25 : (num25 + num36 / num28));
			float num47 = ((!(num29 > 0f)) ? num26 : (num26 - num37 / num29));
			float num48 = 0f;
			float num49 = 0f;
			float num50 = 0f;
			num = part2.Element [part2.nElem].Ang;
			num4 = (float)System.Math.Sin (num);
			num5 = (float)System.Math.Cos (num);
			short num51 = part2.nElem;
			for (short num3 = 1; num3 <= num51; num3 = (short)unchecked(num3 + 1)) {
				float num40;
				float num41;
				if ((num3 > 1) | part2.Closed) {
					num40 = part2.Element [num3].Xac - num46;
					num41 = part2.Element [num3].Yac - num47;
					num = part2.Element [num3].Arc;
					num7 = (float)System.Math.Sign (num) * (part2.Element [num3].Rad + thickness / 2f);
					float num8 = num7 * num7;
					float num9 = num7 * num8;
					float num12 = (float)System.Math.Sin (num);
					float num13 = (float)System.Math.Cos (num);
					float num42 = num40 * num4 - num41 * num5;
					float num43 = num40 * num5 + num41 * num4;
					float num44 = num7 - num31;
					num48 = (float)((double)(num48 + num50 * num50 * num7 * num + 2f * num50 * num42 * num8 * (1f - num13) + 2f * num50 * num43 * num8 * (num - num12) + num50 * num44 * num8 * num * num + num42 * num42 * num9 * (num - num12 * num13) / 2f + 2f * num42 * num43 * num9 * (1f - num13 - num12 * num12 / 2f) + 2f * num42 * num44 * num9 * (num12 - num * num13) + num43 * num43 * num9 * (num - 2f * num12 + (num + num12 * num13) / 2f) + 2f * num43 * num44 * num9 * (num * num / 2f - num * num12 + 1f - num13)) + (double)(num44 * num44 * num9) * System.Math.Pow (num, 3.0) / 3.0);
					num49 = num49 + num50 * num7 * num + num42 * num8 * (1f - num13) + num43 * num8 * (num - num12) + num44 * num8 * num * num / 2f;
					num50 = num50 + num42 * num7 * num12 + num43 * num7 * (1f - num13) + num44 * num7 * num;
				}
				float num24 = part2.Element [num3].Wid;
				num = part2.Element [num3].Ang;
				num4 = (float)System.Math.Sin (num);
				num5 = (float)System.Math.Cos (num);
				num40 = part2.Element [num3].X0 - num46;
				num41 = part2.Element [num3].Y0 - num47;
				float num52 = num40 * num4 - num41 * num5 - num31;
				if (blnNet & (part2.Element [num3].Hole > 0f)) {
					ref Element reference3 = ref part2.Element [num3];
					num24 = (float)System.Math.Sqrt (System.Math.Pow (reference3.Xh0 - reference3.X0, 2.0) + System.Math.Pow (reference3.Yh0 - reference3.Y0, 2.0));
					num48 = (float)((double)(num48 + num50 * num50 * num24 + num50 * num52 * num24 * num24) + (double)(num52 * num52) * System.Math.Pow (num24, 3.0) / 3.0);
					num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
					num50 += num52 * num24;
					num50 += num52 * reference3.Hole;
					num24 = reference3.Wid - reference3.Hole - num24;
				}
				num48 = (float)((double)(num48 + num50 * num50 * num24 + num50 * num52 * num24 * num24) + (double)(num52 * num52) * System.Math.Pow (num24, 3.0) / 3.0);
				num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
				num50 += num52 * num24;
			}
			float num53 = thickness * (num48 - num49 * num49 / num19);
			TorsionData[] array = new TorsionData[5 * unchecked((int)part2.nElem) + 1];
			num50 = (0f - num49) / num19;
			num49 = 0f;
			float num54 = 0f;
			short num55 = 0;
			num = part2.Element [part2.nElem].Ang;
			num4 = (float)System.Math.Sin (num);
			num5 = (float)System.Math.Cos (num);
			short num56 = part2.nElem;
			for (short num3 = 1; num3 <= num56; num3 = (short)unchecked(num3 + 1)) {
				float num40;
				float num41;
				if ((num3 > 1) | part2.Closed) {
					num40 = part2.Element [num3].Xac - num46;
					num41 = part2.Element [num3].Yac - num47;
					num = part2.Element [num3].Arc;
					num7 = (float)System.Math.Sign (num) * (part2.Element [num3].Rad + thickness / 2f);
					float num8 = num7 * num7;
					float num9 = num7 * num8;
					float num12 = (float)System.Math.Sin (num);
					float num13 = (float)System.Math.Cos (num);
					float num42 = num40 * num4 - num41 * num5;
					float num43 = num40 * num5 + num41 * num4;
					float num44 = num7 - num31;
					num54 = num54 + num49 * num7 * num + num50 * num8 * num * num / 2f + num42 * num9 * (num - num12) + num43 * num9 * (num * num / 2f - 1f + num13) + num44 * num9 * num * num * num / 6f;
					num49 = num49 + num50 * num7 * num + num42 * num8 * (1f - num13) + num43 * num8 * (num - num12) + num44 * num8 * num * num / 2f;
					num50 = num50 + num42 * num7 * num12 + num43 * num7 * (1f - num13) + num44 * num7 * num;
				}
				float num24 = part2.Element [num3].Wid;
				num = part2.Element [num3].Ang;
				num4 = (float)System.Math.Sin (num);
				num5 = (float)System.Math.Cos (num);
				num40 = part2.Element [num3].X0 - num46;
				num41 = part2.Element [num3].Y0 - num47;
				float num52 = num40 * num4 - num41 * num5 - num31;
				num55 = (short)(num55 + 1);
				array [num55].Assign (num3, 0f, num52 + num31, num50, thickness * num49);
				float num57 = 0f;
				if (blnNet & (part2.Element [num3].Hole > 0f)) {
					ref Element reference4 = ref part2.Element [num3];
					num24 = (float)System.Math.Sqrt (System.Math.Pow (reference4.Xh0 - reference4.X0, 2.0) + System.Math.Pow (reference4.Yh0 - reference4.Y0, 2.0));
					if (num50 * (num50 + num52 * num24) < 0f) {
						num24 = (0f - num50) / num52;
						num54 = num54 + num49 * num24 + num50 * num24 * num24 / 2f + num52 * num24 * num24 * num24 / 6f;
						num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
						num50 += num52 * num24;
						num55 = (short)(num55 + 1);
						array [num55].Assign (num3, num24, num52 + num31, num50, thickness * num49);
						num24 = (float)(System.Math.Sqrt (System.Math.Pow (reference4.Xh0 - reference4.X0, 2.0) + System.Math.Pow (reference4.Yh0 - reference4.Y0, 2.0)) - (double)num24);
					}
					num54 = num54 + num49 * num24 + num50 * num24 * num24 / 2f + num52 * num24 * num24 * num24 / 6f;
					num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
					num50 += num52 * num24;
					num55 = (short)(num55 + 1);
					array [num55].Assign (num3, num24, num52 + num31, num50, thickness * num49);
					num50 += num52 * reference4.Hole;
					num55 = (short)(num55 + 1);
					array [num55].Assign (num3, num24 + reference4.Hole, num52 + num31, num50, thickness * num49);
					num24 = (float)System.Math.Sqrt (System.Math.Pow (reference4.X1 - reference4.Xh1, 2.0) + System.Math.Pow (reference4.Y1 - reference4.Yh1, 2.0));
					num57 = reference4.Wid - num24;
				}
				if (num50 * (num50 + num52 * num24) < 0f) {
					num24 = (0f - num50) / num52;
					num54 = num54 + num49 * num24 + num50 * num24 * num24 / 2f + num52 * num24 * num24 * num24 / 6f;
					num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
					num50 += num52 * num24;
					num55 = (short)(num55 + 1);
					array [num55].Assign (num3, num57 + num24, num52 + num31, num50, thickness * num49);
					num24 = part2.Element [num3].Wid - (num57 + num24);
				}
				num54 = num54 + num49 * num24 + num50 * num24 * num24 / 2f + num52 * num24 * num24 * num24 / 6f;
				num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
				num50 += num52 * num24;
				num55 = (short)(num55 + 1);
				array [num55].Assign (num3, part2.Element [num3].Wid, num52 + num31, num50, thickness * num49);
			}
			array = (TorsionData[])Utils.CopyArray (array, new TorsionData[num55 + 1]);
			if (part2.Closed) {
				int num58 = num55;
				for (int i = 1; i <= num58; i++) {
					if (array [i].iElem > 0) {
						array [i].Sw -= thickness * num54 / num19;
					}
				}
			}
			if (blnNet) {
				WnnMax = 0f;
			} else {
				WnMax = 0f;
			}
			int num59 = num55;
			for (int j = 1; j <= num59; j++) {
				if (blnNet) {
					if (System.Math.Abs (array [j].Wn) > WnnMax) {
						WnnMax = System.Math.Abs (array [j].Wn);
					}
				} else if (System.Math.Abs (array [j].Wn) > WnMax) {
					WnMax = System.Math.Abs (array [j].Wn);
				}
			}
			num7 = (float)System.Math.Sqrt (num46 * num46 + num47 * num47);
			num = (float)System.Math.Atan2 (num47, num46);
			if (blnNet) {
				Xon = (float)((double)num7 * System.Math.Cos (num + Alphan) - (double)Xcgn);
				Yon = (float)((double)num7 * System.Math.Sin (num + Alphan) - (double)Ycgn);
				Jn = num30;
				Cwn = num53;
				TPn = array;
			} else {
				Xo = (float)((double)num7 * System.Math.Cos (num + Alpha) - (double)Xcg);
				Yo = (float)((double)num7 * System.Math.Sin (num + Alpha) - (double)Ycg);
				J = num30;
				Cw = num53;
				TPg = array;
			}
			if (blnPlastic) {
				float num60 = (float)(0.001 * (double)num19 * System.Math.Sqrt ((num28 + num29) / num19));
				float num61 = default(float);
				float num73 = default(float);
				short num74 = default(short);
				float num75 = default(float);
				short num76 = default(short);
				float num77 = default(float);
				bool flag = default(bool);
				short num78 = default(short);
				float num79 = default(float);
				bool flag2 = default(bool);
				while (true) {
					num50 = 0f - num61;
					num49 = 0f;
					float num62 = 0f;
					float num63 = 0f;
					float num64 = 0f;
					float num65 = 0f;
					num = part2.Element [part2.nElem].Ang;
					num4 = (float)System.Math.Sin (num);
					num5 = (float)System.Math.Cos (num);
					short num66 = part2.nElem;
					for (short num3 = 1; num3 <= num66; num3 = (short)unchecked(num3 + 1)) {
						float num40;
						float num41;
						if ((num3 > 1) | part2.Closed) {
							num40 = part2.Element [num3].Xac - num46;
							num41 = part2.Element [num3].Yac - num47;
							float num10 = part2.Element [num3].Arc;
							num7 = (float)System.Math.Sign (num10) * (part2.Element [num3].Rad + thickness / 2f);
							float num8 = num7 * num7;
							float num9 = num7 * num8;
							float num12 = (float)System.Math.Sin (num10);
							float num13 = (float)System.Math.Cos (num10);
							float num42 = num40 * num4 - num41 * num5;
							float num43 = num40 * num5 + num41 * num4;
							float num44 = num7 - num31;
							num49 = num49 + num50 * num7 * num10 + num42 * num8 * (1f - num13) + num43 * num8 * (num10 - num12) + num44 * num8 * num10 * num10 / 2f;
							float num67 = num42 * num7 * num12 + num43 * num7 * (1f - num13) + num44 * num7 * num10;
							float num14;
							if (num50 * (num50 + num67) < 0f) {
								float num68 = num10 * (0f - num50) / num67;
								num67 += num50;
								num50 /= 2f;
								float num69 = (float)((double)num - (double)System.Math.Sign (num68) * System.Math.PI / 2.0 + (double)(num68 / 2f));
								num4 = (float)System.Math.Sin (System.Math.Abs (num68 / 2f));
								num12 = (float)System.Math.Sin (num69);
								num13 = (float)System.Math.Cos (num69);
								num14 = System.Math.Abs (num7 * num68);
								num62 += num14 * System.Math.Abs (num50);
								num63 += num14 * (float)System.Math.Sign (num50);
								num64 += (num14 * (part2.Element [num3].Yac - num26) + 2f * num8 * num4 * num12) * (float)System.Math.Sign (num50);
								num65 += (num14 * (part2.Element [num3].Xac - num25) + 2f * num8 * num4 * num13) * (float)System.Math.Sign (num50);
								num50 = 0f;
								num += num68;
								num10 -= num68;
							}
							num50 += num67 / 2f;
							float num70 = (float)((double)num - (double)System.Math.Sign (num10) * System.Math.PI / 2.0 + (double)(num10 / 2f));
							num4 = (float)System.Math.Sin (System.Math.Abs (num10 / 2f));
							num12 = (float)System.Math.Sin (num70);
							num13 = (float)System.Math.Cos (num70);
							num14 = System.Math.Abs (num7 * num10);
							num62 += num14 * System.Math.Abs (num50);
							num63 += num14 * (float)System.Math.Sign (num50);
							num64 += (num14 * (part2.Element [num3].Yac - num26) + 2f * num8 * num4 * num12) * (float)System.Math.Sign (num50);
							num65 += (num14 * (part2.Element [num3].Xac - num25) + 2f * num8 * num4 * num13) * (float)System.Math.Sign (num50);
							num50 += num67 / 2f;
						}
						float num24 = part2.Element [num3].Wid;
						num = part2.Element [num3].Ang;
						num4 = (float)System.Math.Sin (num);
						num5 = (float)System.Math.Cos (num);
						num40 = part2.Element [num3].X0 - num46;
						num41 = part2.Element [num3].Y0 - num47;
						float num71 = part2.Element [num3].X0 - num25;
						float num72 = part2.Element [num3].Y0 - num26;
						float num52 = num40 * num4 - num41 * num5 - num31;
						if (blnNet & (part2.Element [num3].Hole > 0f)) {
							ref Element reference5 = ref part2.Element [num3];
							num24 = (float)System.Math.Sqrt (System.Math.Pow (reference5.Xh0 - reference5.X0, 2.0) + System.Math.Pow (reference5.Yh0 - reference5.Y0, 2.0));
							float num57 = 0f;
							num49 = num49 + num50 * num24 + num52 * num24 * num24 / 2f;
							if (num50 * (num50 + num52 * num24) < 0f) {
								num57 = (0f - num50) / num52;
								num71 += num57 * num5 / 2f;
								num72 += num57 * num4 / 2f;
								num50 += num52 * num57 / 2f;
								num62 += num57 * System.Math.Abs (num50);
								num63 += num57 * (float)System.Math.Sign (num50);
								num64 += num57 * num72 * (float)System.Math.Sign (num50);
								num65 += num57 * num71 * (float)System.Math.Sign (num50);
								num50 += num52 * num57 / 2f;
								num71 += num57 * num5 / 2f;
								num72 += num57 * num4 / 2f;
								num24 -= num57;
							}
							num71 += num24 * num5 / 2f;
							num72 += num24 * num4 / 2f;
							num50 += num52 * num24 / 2f;
							num62 += num24 * System.Math.Abs (num50);
							num63 += num24 * (float)System.Math.Sign (num50);
							num64 += num24 * num72 * (float)System.Math.Sign (num50);
							num65 += num24 * num71 * (float)System.Math.Sign (num50);
							num50 += num52 * num24 / 2f;
							num71 += num24 * num5 / 2f;
							num72 += num24 * num4 / 2f;
							num50 += num52 * reference5.Hole;
							num71 += reference5.Hole * num5;
							num72 += reference5.Hole * num4;
							num24 = reference5.Wid - num57 - num24 - reference5.Hole;
						}
						num49 += num50 * num24 + num52 * num24 * num24 / 2f;
						if (num50 * (num50 + num52 * num24) < 0f) {
							float num57 = (0f - num50) / num52;
							num71 += num57 * num5 / 2f;
							num72 += num57 * num4 / 2f;
							num50 += num52 * num57 / 2f;
							num62 += num57 * System.Math.Abs (num50);
							num63 += num57 * (float)System.Math.Sign (num50);
							num64 += num57 * num72 * (float)System.Math.Sign (num50);
							num65 += num57 * num71 * (float)System.Math.Sign (num50);
							num50 += num52 * num57 / 2f;
							num71 += num57 * num5 / 2f;
							num72 += num57 * num4 / 2f;
							num24 -= num57;
						}
						num71 += num24 * num5 / 2f;
						num72 += num24 * num4 / 2f;
						num50 += num52 * num24 / 2f;
						num62 += num24 * System.Math.Abs (num50);
						num63 += num24 * (float)System.Math.Sign (num50);
						num64 += num24 * num72 * (float)System.Math.Sign (num50);
						num65 += num24 * num71 * (float)System.Math.Sign (num50);
						num50 += num52 * num24 / 2f;
						num71 += num24 * num5 / 2f;
						num72 += num24 * num4 / 2f;
					}
					unchecked {
						if (num73 == 0f || num62 * thickness < num73) {
							num73 = num62 * thickness;
						}
						if ((double)System.Math.Abs (num63) > 0.0001 * (double)num19 && num74 < 12) {
							num74 = checked((short)(num74 + 1));
							if (num74 == 1) {
								num61 = num49 / num19;
								num75 = System.Math.Abs (num61) / 2f;
							} else {
								num61 += (float)System.Math.Sign (num63) * num75;
								num75 /= 2f;
							}
							continue;
						}
						if (System.Math.Abs (num64) > num60 && num76 < 20) {
							num76 = checked((short)(num76 + 1));
							if (num76 == 1) {
								num77 = System.Math.Abs (num46 - num25);
								flag = false;
							}
							if (System.Math.Abs (num46 + (float)System.Math.Sign (num64) * num77 - num25) < System.Math.Abs (num46 - num25)) {
								flag = true;
							}
							if (flag) {
								num77 /= 2f;
							}
							num46 += (float)System.Math.Sign (num64) * num77;
							num74 = 0;
							num61 = 0f;
							continue;
						}
						if (!(System.Math.Abs (num65) > num60 && num78 < 20)) {
							break;
						}
					}
					num78 = (short)(num78 + 1);
					if (num78 == 1) {
						num79 = System.Math.Abs (num47 - num26);
						flag2 = false;
					}
					if (System.Math.Abs (num47 - (float)System.Math.Sign (num65) * num79 - num26) < System.Math.Abs (num47 - num26)) {
						flag2 = true;
					}
					if (flag2) {
						num79 /= 2f;
					}
					num47 -= (float)System.Math.Sign (num65) * num79;
					num74 = 0;
					num61 = 0f;
					num76 = 0;
				}
				if (blnNet) {
					Zwn = num73;
				} else {
					Zw = num73;
				}
			}
			part2 = null;
		}
	}

	internal float TorsionReduction (float Mx, float My, float B, byte Spec, bool blnSS, ref string strTrace, bool blnNet = false)
	{
		strTrace = string.Empty;
		if (B == 0f) {
			return 1f;
		}
		if (Mx == 0f && My == 0f) {
			return 0f;
		}
		string right;
		if (blnSS) {
			right = "Eq. 8.4-1";
		} else {
			if (CFS.SpecYear (Spec) < 2007) {
				return 1f;
			}
			right = ((CFS.SpecYear (Spec) >= 2016) ? "Eq. H4-1" : "Eq. C3.6-1");
		}
		TorsionData[] array;
		float num2;
		float num3;
		float num4;
		float num5;
		float num6;
		if (blnNet) {
			array = TPn;
			float num = Ixn * Iyn - Ixyn * Ixyn;
			num2 = (Mx * Iyn - My * Ixyn) / num;
			num3 = (My * Ixn - Mx * Ixyn) / num;
			num4 = Xcgn;
			num5 = Ycgn;
			if (Cwn == 0f) {
				return 0f;
			}
			num6 = B / Cwn;
		} else {
			array = TPg;
			float num = Ix * Iy - Ixy * Ixy;
			num2 = (Mx * Iy - My * Ixy) / num;
			num3 = (My * Ix - Mx * Ixy) / num;
			num4 = Xcg;
			num5 = Ycg;
			if (Cw == 0f) {
				return 0f;
			}
			num6 = B / Cw;
		}
		float num15 = default(float);
		short num16 = default(short);
		float num17 = default(float);
		short num18 = default(short);
		float num20;
		bool flag;
		checked {
			short num7 = (short)Information.UBound (array);
			float num13 = default(float);
			short num14 = default(short);
			short num19 = default(short);
			short num8;
			for (num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
				short iElem = array [num8].iElem;
				float num9 = num2 * (Element [iElem].Y0 - num5) + num3 * (Element [iElem].X0 - num4);
				float num10 = num2 * (Element [iElem].Y1 - num5) + num3 * (Element [iElem].X1 - num4);
				float num11 = num9 + (num10 - num9) * array [num8].Loc / Element [iElem].Wid;
				float num12 = num11 + num6 * array [num8].Wn;
				if (num11 < num13) {
					num13 = num11;
					num14 = num8;
				}
				if (num11 > num15) {
					num15 = num11;
					num16 = num8;
				}
				if (System.Math.Abs (num12) > System.Math.Abs (num17)) {
					num17 = num12;
					num18 = num8;
					num19 = (short)System.Math.Sign (num11);
				}
			}
			if (num17 == 0f) {
				return 1f;
			}
			if (num19 < 0) {
				num15 = num13;
				num16 = num14;
			}
			if (num15 == 0f) {
				return 0f;
			}
			num20 = System.Math.Abs (num15 / num17);
			flag = true;
			short num21 = (short)(num18 + 1);
			short num22 = (short)Information.UBound (array);
			num8 = num21;
			while (num8 <= num22 && !(array [num8].Wn * array [num18].Wn < 0f)) {
				num8 = (short)unchecked(num8 + 1);
			}
			if ((num8 > Information.UBound (array)) & !Closed) {
				flag = false;
			}
			num8 = (short)(num18 - 1);
			while (num8 >= 1 && !(array [num8].Wn * array [num18].Wn < 0f)) {
				num8 = (short)unchecked(num8 + -1);
			}
			if ((num8 < 1) & !Closed) {
				flag = false;
			}
			if (flag && IsStiffenedCee ()) {
				num20 = (float)(1.15 * (double)num20);
			} else {
				flag = false;
			}
			if (num20 > 1f) {
				num20 = 1f;
			}
			strTrace = "Combined Bending and Torsion\r\n";
			strTrace = strTrace + "  Mx=" + Units.DisplayMoment (Mx, 0, blnShowUnit: true, "", 0, 0) + ", My=" + Units.DisplayMoment (My, 0, blnShowUnit: true, "", 0, 0) + ", B=" + Units.DisplayBimoment (B, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		}
		strTrace = strTrace + "  Fb_max=" + Units.DisplayStress (num15, 0, blnShowUnit: true, "", 0, 0) + " on element " + Conversions.ToString ((int)array [num16].iElem) + " at " + Units.DisplayLen1 (array [num16].Loc, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		strTrace = strTrace + "  Fb+Fw=" + Units.DisplayStress (num17, 0, blnShowUnit: true, "", 0, 0) + " on element " + Conversions.ToString ((int)array [num18].iElem) + " at " + Units.DisplayLen1 (array [num18].Loc, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		strTrace = Conversions.ToString (Operators.ConcatenateObject (strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  R=" + Units.DisplayNone (num20, "", 0, 0), Interaction.IIf (flag, " (near flange/web)", "")), "\t"), right), "\r\n"), "\r\n")));
		return num20;
	}

	internal bool CollinearElements (Element elm1, Element elm2)
	{
		bool result = false;
		float num = (float)((double)(elm1.Ang - elm2.Ang) / (System.Math.PI * 2.0));
		checked {
			if (!((double)System.Math.Abs (num - (float)(int)System.Math.Round (num)) > 0.0001)) {
				if ((elm1.Wid == 0f) & (elm2.Wid == 0f)) {
					if ((elm2.Y0 != elm1.Y0) | (elm2.X0 != elm1.X0)) {
						float num2 = (float)(((double)elm1.Ang - System.Math.Atan2 (elm2.Y0 - elm1.Y0, elm2.X0 - elm1.X0)) / (System.Math.PI * 2.0));
						if ((double)System.Math.Abs (num2 - (float)(int)System.Math.Round (num2)) > 0.0001) {
							goto IL_0224;
						}
					}
					goto IL_0222;
				}
				if (elm1.Wid > elm2.Wid) {
					float value = elm1.X0 * (elm1.Y1 - elm2.Y0) + elm1.X1 * (elm2.Y0 - elm1.Y0) + elm2.X0 * (elm1.Y0 - elm1.Y1);
					float num3 = (float)System.Math.Sqrt (System.Math.Pow (elm2.X0 - elm1.X0, 2.0) + System.Math.Pow (elm2.Y0 - elm1.Y0, 2.0));
					if (!((double)System.Math.Abs (value) > 0.0001 * (double)elm1.Wid * (double)num3)) {
						goto IL_0222;
					}
				} else {
					float value2 = elm2.X0 * (elm2.Y1 - elm1.Y1) + elm2.X1 * (elm1.Y1 - elm2.Y0) + elm1.X1 * (elm2.Y0 - elm2.Y1);
					float num3 = (float)System.Math.Sqrt (System.Math.Pow (elm2.X1 - elm1.X1, 2.0) + System.Math.Pow (elm2.Y1 - elm1.Y1, 2.0));
					if (!((double)System.Math.Abs (value2) > 0.0001 * (double)elm2.Wid * (double)num3)) {
						goto IL_0222;
					}
				}
			}
			goto IL_0224;
		}
		IL_0224:
		return result;
		IL_0222:
		result = true;
		goto IL_0224;
	}

	internal float Distance (Element elm, float X, float Y)
	{
		float num = elm.X1 - elm.X0;
		float num2 = elm.Y1 - elm.Y0;
		float num3 = (float)System.Math.Sqrt (num * num + num2 * num2);
		if (num3 == 0f) {
			return (float)System.Math.Sqrt (System.Math.Pow (X - elm.X0, 2.0) + System.Math.Pow (Y - elm.Y0, 2.0));
		}
		return System.Math.Abs (num2 * (X - elm.X0) - num * (Y - elm.Y0)) / num3;
	}

	internal short FlangeElement (byte iBrcFlg)
	{
		short result = 0;
		float thickness = Thickness;
		if (iBrcFlg == 1 || iBrcFlg == 2) {
			float num = ((iBrcFlg != 1) ? Ytop : (0f - Ybottom));
			checked {
				short num2 = (short)unchecked(checked(unchecked((int)nElem) + 1) / 2);
				for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
					short num4 = num3;
					float num5 = System.Math.Abs (Element [num4].Y0 - Ycg - num);
					float num6 = System.Math.Abs (Element [num4].Y1 - Ycg - num);
					if (unchecked((double)num5 < 0.501 * (double)thickness && (double)num6 < 0.501 * (double)thickness)) {
						result = num4;
						break;
					}
					num4 = (short)(unchecked((int)nElem) + 1 - num3);
					float num7 = System.Math.Abs (Element [num4].Y0 - Ycg - num);
					num6 = System.Math.Abs (Element [num4].Y1 - Ycg - num);
					if (unchecked((double)num7 < 0.501 * (double)thickness && (double)num6 < 0.501 * (double)thickness)) {
						result = num4;
						break;
					}
				}
			}
		} else if (iBrcFlg == 3 || iBrcFlg == 4) {
			float num = ((iBrcFlg != 3) ? Xright : (0f - Xleft));
			checked {
				short num8 = (short)unchecked(checked(unchecked((int)nElem) + 1) / 2);
				for (short num3 = 1; num3 <= num8; num3 = (short)unchecked(num3 + 1)) {
					short num4 = num3;
					float num9 = System.Math.Abs (Element [num4].X0 - Xcg - num);
					float num6 = System.Math.Abs (Element [num4].X1 - Xcg - num);
					if (unchecked((double)num9 < 0.501 * (double)thickness && (double)num6 < 0.501 * (double)thickness)) {
						result = num4;
						break;
					}
					num4 = (short)(unchecked((int)nElem) + 1 - num3);
					float num10 = System.Math.Abs (Element [num4].X0 - Xcg - num);
					num6 = System.Math.Abs (Element [num4].X1 - Xcg - num);
					if (unchecked((double)num10 < 0.501 * (double)thickness && (double)num6 < 0.501 * (double)thickness)) {
						result = num4;
						break;
					}
				}
			}
		}
		return result;
	}

	internal bool IsCylinder ()
	{
		bool result = false;
		if (Closed) {
			result = true;
			int num = nElem;
			for (int i = 1; i <= num; i = checked(i + 1)) {
				if (((double)Element [i].Wid > 2E-06 * (double)Element [i].Len) | (Element [i].Rad != Element [1].Rad) | (System.Math.Sign (Element [i].Arc) != System.Math.Sign (Element [1].Arc))) {
					result = false;
					break;
				}
			}
		}
		return result;
	}

	internal bool IsLTBZee (LoadDirections iDir)
	{
		if (Closed) {
			return false;
		}
		if ((double)System.Math.Abs (Ixy) < 0.01 * (double)(Ix + Iy)) {
			return false;
		}
		if (System.Math.Sqrt (Xo * Xo + Yo * Yo) > 0.001 * System.Math.Sqrt ((Ix + Iy) / A)) {
			return false;
		}
		if ((int)nElem % 2 == 0) {
			return false;
		}
		int num = nElem;
		checked {
			short num2 = default(short);
			short num3 = default(short);
			for (int i = 1; i <= num; i++) {
				switch (iDir) {
				case LoadDirections.dirY:
					if (System.Math.Sign (Element [i].Y0 - Ycg) != System.Math.Sign (Element [i].Y1 - Ycg)) {
						num2 = (short)(num2 + 1);
						if (System.Math.Abs (System.Math.Cos (Element [i].Ang)) < 0.01) {
							num3 = (short)(num3 + 1);
						}
					}
					break;
				case LoadDirections.dirX:
					if (System.Math.Sign (Element [i].X0 - Xcg) != System.Math.Sign (Element [i].X1 - Xcg)) {
						num2 = (short)(num2 + 1);
						if (System.Math.Abs (System.Math.Sin (Element [i].Ang)) < 0.01) {
							num3 = (short)(num3 + 1);
						}
					}
					break;
				}
			}
			if (num2 != 1) {
				return false;
			}
			if (num3 != 1) {
				return false;
			}
			return true;
		}
	}

	internal bool IsStiffenedCee ()
	{
		if (Closed) {
			return false;
		}
		if (nElem != 5) {
			return false;
		}
		if (System.Math.Sign (Element [3].Arc) != System.Math.Sign (Element [2].Arc)) {
			return false;
		}
		if (System.Math.Sign (Element [4].Arc) != System.Math.Sign (Element [2].Arc)) {
			return false;
		}
		if (System.Math.Sign (Element [5].Arc) != System.Math.Sign (Element [2].Arc)) {
			return false;
		}
		float num = (float)(0.01 * (double)A / (double)Thickness);
		if (System.Math.Abs (Element [1].Len - Element [5].Len) > num) {
			return false;
		}
		if (System.Math.Abs (Element [2].Len - Element [4].Len) > num) {
			return false;
		}
		if (Element [2].Len > Element [3].Len) {
			return false;
		}
		if ((double)Element [1].Len > 0.5 * (double)Element [3].Len) {
			return false;
		}
		if (System.Math.Abs ((double)System.Math.Abs (Element [3].Arc) - System.Math.PI / 2.0) > 0.001) {
			return false;
		}
		if (System.Math.Abs ((double)System.Math.Abs (Element [4].Arc) - System.Math.PI / 2.0) > 0.001) {
			return false;
		}
		if ((double)System.Math.Abs (Element [5].Arc - Element [2].Arc) > 0.001) {
			return false;
		}
		if ((double)System.Math.Abs (Element [2].Arc) < 0.7) {
			return false;
		}
		return true;
	}

	internal bool IsUnstiffened (LoadDirections iDir, short iSign, float Xpos, float Ypos)
	{
		if (Closed) {
			return false;
		}
		checked {
			switch (iDir) {
			case LoadDirections.dirY:
				if ((Element [1].K == 0f) & (System.Math.Sign (Ypos + Element [1].Y0 - Ycg) == iSign)) {
					if (nElem == 1) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [1].Y1 - Ycg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [2].Y0 - Ycg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [2].Y1 - Ycg) != iSign) {
						return true;
					}
				}
				if ((Element [nElem].K == 0f) & (System.Math.Sign (Ypos + Element [nElem].Y1 - Ycg) == iSign)) {
					if (nElem == 1) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [nElem].Y0 - Ycg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [unchecked((int)nElem) - 1].Y1 - Ycg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Ypos + Element [unchecked((int)nElem) - 1].Y0 - Ycg) != iSign) {
						return true;
					}
				}
				break;
			case LoadDirections.dirX:
				if ((Element [1].K == 0f) & (System.Math.Sign (Xpos + Element [1].X0 - Xcg) == iSign)) {
					if (nElem == 1) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [1].X1 - Xcg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [2].X0 - Xcg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [2].X1 - Xcg) != iSign) {
						return true;
					}
				}
				if ((Element [nElem].K == 0f) & (System.Math.Sign (Xpos + Element [nElem].X1 - Xcg) == iSign)) {
					if (nElem == 1) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [nElem].X0 - Xcg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [unchecked((int)nElem) - 1].X1 - Xcg) != iSign) {
						return true;
					}
					if (System.Math.Sign (Xpos + Element [unchecked((int)nElem) - 1].X0 - Xcg) != iSign) {
						return true;
					}
				}
				break;
			}
			return false;
		}
	}
}
