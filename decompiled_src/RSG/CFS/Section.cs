// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.Data;

namespace RSG.CFS;

internal class Section
{
	public struct DSMType
	{
		public bool UseDSM;

		public bool PreQualified;

		public float Pcrl;

		public float Pcrd;

		public float Mcrlxp;

		public float Mcrdxp;

		public float Mcrlxn;

		public float Mcrdxn;

		public float Mcrlyp;

		public float Mcrdyp;

		public float Mcrlyn;

		public float Mcrdyn;

		public float Vcry;

		public float Vcrx;

		public bool IsAllZero ()
		{
			if (Pcrl > 0f) {
				return false;
			}
			if (Pcrd > 0f) {
				return false;
			}
			if (Mcrlxp > 0f) {
				return false;
			}
			if (Mcrlxn > 0f) {
				return false;
			}
			if (Mcrlyp > 0f) {
				return false;
			}
			if (Mcrlyn > 0f) {
				return false;
			}
			if (Mcrdxp > 0f) {
				return false;
			}
			if (Mcrdxn > 0f) {
				return false;
			}
			if (Mcrdyp > 0f) {
				return false;
			}
			if (Mcrdyn > 0f) {
				return false;
			}
			if (Vcry > 0f) {
				return false;
			}
			if (Vcrx > 0f) {
				return false;
			}
			return true;
		}
	}

	public struct PropertiesType
	{
		public float A;

		public float Weight;

		public float FlatWidth;

		public float Xcg;

		public float Ycg;

		public float Ix;

		public float Rx;

		public float Sxt;

		public float Sxb;

		public float Sx;

		public float Iy;

		public float Ry;

		public float Syl;

		public float Syr;

		public float Sy;

		public float Ixy;

		public float Alpha;

		public float Xo;

		public float Yo;

		public float jx;

		public float jy;

		public float Cw;

		public float J;

		public float I1;

		public float I2;

		public float Ic;

		public float Io;

		public float R1;

		public float R2;

		public float Rc;

		public float Ro;

		public byte Symmetry;

		public float Avx;

		public float Avy;

		public float Zx;

		public float Zy;

		public float An;

		public float Xcgn;

		public float Ycgn;

		public float Ixn;

		public float Rxn;

		public float Sxtn;

		public float Sxbn;

		public float Sxn;

		public float Iyn;

		public float Ryn;

		public float Syln;

		public float Syrn;

		public float Syn;

		public float Ixyn;

		public float Alphan;

		public float Icn;

		public float Rcn;

		public float Xon;

		public float Yon;

		public float Ion;

		public float Ron;

		public float jxn;

		public float jyn;

		public float Cwn;

		public float Jn;

		public float I1n;

		public float I2n;

		public float Zxn;

		public float Zyn;

		public byte SymmetryNet;
	}

	public struct EffectivePropertiesType
	{
		public float A;

		public float Xcg;

		public float Ycg;

		public float Ix;

		public float Sxt;

		public float Sxb;

		public float Sx;

		public float Iy;

		public float Syl;

		public float Syr;

		public float Sy;

		public float Ixy;

		public bool ColdWorkAllowed;

		public bool RationalAnalysis;

		public bool Iterate;

		public float LambdaMax;

		public string Trace;

		public string Msg;
	}

	public struct StressType
	{
		public float Fyat;

		public float Fyac;

		public float Fyacg;

		public float Fyacn;

		public float Fyax;

		public float Fyaxpg;

		public float Fyaxpn;

		public float Fyaxng;

		public float Fyaxnn;

		public float Fyay;

		public float Fyaypg;

		public float Fyaypn;

		public float Fyayng;

		public float Fyaynn;
	}

	public struct StrengthType
	{
		public float Tn;

		public float Ta;

		public float QTn;

		public float Pno;

		public float Pao;

		public float QPno;

		public float Ae;

		public float Vay;

		public float QVny;

		public float Vax;

		public float QVnx;

		public float Mnxop;

		public float Maxop;

		public float QMnxop;

		public float Maxtop;

		public float QMnxtop;

		public float Ixep;

		public float Sxtep;

		public float Sxbep;

		public float Mnxon;

		public float Maxon;

		public float QMnxon;

		public float Maxton;

		public float QMnxton;

		public float Ixen;

		public float Sxten;

		public float Sxben;

		public float Mnyop;

		public float Mayop;

		public float QMnyop;

		public float Maytop;

		public float QMnytop;

		public float Iyep;

		public float Sylep;

		public float Syrep;

		public float Mnyon;

		public float Mayon;

		public float QMnyon;

		public float Mayton;

		public float QMnyton;

		public float Bn;

		public float Ba;

		public float QBn;

		public float Iyen;

		public float Sylen;

		public float Syren;

		public bool Qual;

		public bool PQual;

		public bool MxpQual;

		public bool MxnQual;

		public bool MypQual;

		public bool MynQual;

		public bool VyQual;

		public bool VxQual;

		public string Msg;
	}

	private struct DXFVertex
	{
		public float X;

		public float Y;

		public float Arc;
	}

	internal struct Extremes
	{
		public float Dmin;

		public float Dmax;
	}

	internal struct SurfacePoint
	{
		public float Theta;

		public float Phi;

		public float Beta;
	}

	public string Filename;

	public DateTime RevDate;

	public string RevBy;

	public string Description;

	public string Project;

	public short AppVer;

	public MaterialType Material;

	public short MaterialIndex;

	public bool ColdWork;

	public bool Reserve;

	public float JOverride;

	public float CwOverride;

	public float ConnSpacing;

	public float HoleLength;

	public float HoleSpacing;

	public bool GeomChange;

	public bool GeomChangeDSM;

	public bool Saved;

	public Part[] Part;

	public byte iPart;

	public byte nPart;

	public float Xmin;

	public float Xmax;

	public float Ymin;

	public float Ymax;

	public float Xmine;

	public float Xmaxe;

	public float Ymine;

	public float Ymaxe;

	public string Report;

	public DSMType DSM;

	public PropertiesType Prop;

	public EffectivePropertiesType PropEff;

	public StressType Stress;

	public StrengthType Strength;

	public bool SctProp;

	public short Zoom;

	public float ZoomX;

	public float ZoomY;

	public float ExtXmin;

	public float ExtXmax;

	public float ExtYmin;

	public float ExtYmax;

	public float[] XPt;

	public float[] YPt;

	public byte iPt;

	public SurfacePoint[,] Plastic;

	public short iUndo;

	public short iUndoTab;

	public short iRedoTab;

	public string strUndo;

	public string strRedo;

	private string strTraceDB;

	private string strTraceCW;

	public Section ()
	{
		XPt = new float[3];
		YPt = new float[3];
		Initialize ();
	}

	public void Initialize ()
	{
		Filename = string.Empty;
		RevDate = DateAndTime.Now;
		RevBy = CFS.User.Name;
		Description = string.Empty;
		Project = string.Empty;
		AppVer = -1;
		MaterialIndex = CFS.iMaterial;
		if (CFS.iMaterial > 0) {
			Material = CFS.Materials [CFS.iMaterial].Clone ();
		} else {
			Material = CFS.MaterialDefault.Clone ();
		}
		ColdWork = CFS.blnColdWork;
		Reserve = CFS.blnReserve;
		JOverride = 0f;
		CwOverride = 0f;
		ConnSpacing = 0f;
		HoleLength = 1.5f;
		HoleSpacing = 24f;
		GeomChange = false;
		GeomChangeDSM = false;
		Saved = false;
		Part = new Part[2];
		Part [0] = new Part ();
		Part [1] = new Part ();
		iPart = 1;
		nPart = 0;
		Xmin = 0f;
		Xmax = 0f;
		Ymin = 0f;
		Ymax = 0f;
		SctProp = false;
		Zoom = 1;
		ZoomX = 0.5f;
		ZoomY = 0.5f;
		ExtXmin = 0f;
		ExtXmax = 0f;
		ExtYmin = 0f;
		ExtYmax = 0f;
		DSM = default(DSMType);
		iUndo = -1;
		strUndo = string.Empty;
		strRedo = string.Empty;
	}

	public Section Clone ()
	{
		Section section = (Section)MemberwiseClone ();
		section.Material = Material.Clone ();
		checked {
			if (!Information.IsNothing (Part)) {
				section.Part = new Part[Information.UBound (Part) + 1];
				int num = Information.LBound (Part);
				int num2 = Information.UBound (Part);
				for (int i = num; i <= num2; i++) {
					if (!Information.IsNothing (Part [i])) {
						section.Part [i] = Part [i].Clone ();
					}
				}
			}
			section.XPt = (float[])XPt.Clone ();
			section.YPt = (float[])YPt.Clone ();
			if (!Information.IsNothing (Plastic)) {
				section.Plastic = (SurfacePoint[,])Plastic.Clone ();
			}
			return section;
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool Load (string strFileName, ref string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		int num4 = default(int);
		byte Value = default(byte);
		short Value3 = default(short);
		int Value4 = default(int);
		short Value5 = default(short);
		int Value6 = default(int);
		int num = default(int);
		float Value7 = default(float);
		float num11 = default(float);
		byte Value8 = default(byte);
		byte Value9 = default(byte);
		float Value10 = default(float);
		bool flag = default(bool);
		bool blnChg = default(bool);
		int Value11 = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					short num9;
					string Value2;
					Part part;
					MaterialType materialType;
					short num5;
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						Report = string.Empty;
						Filename = strFileName;
						short num3 = (short)Strings.InStr (1, strFileName, "|");
						num4 = FileSystem.FreeFile ();
						if (num3 != 0) {
							string fileName = CFSInterface.GetFileName (strFileName);
							string @string = Strings.Mid (strFileName, num3 + 1, Strings.Len (strFileName) - num3 - Strings.Len (fileName) - 1);
							strFileName = Strings.Left (strFileName, num3 - 1);
							if (FileSystem.FileLen (strFileName) == 0L) {
								goto end_IL_0000;
							}
							FileSystem.FileOpen (num4, strFileName, OpenMode.Binary, OpenAccess.Read);
							num5 = 1;
							do {
								FileSystem.FileGet (num4, ref Value, -1L);
								Value2 = Strings.Space (Value);
								FileSystem.FileGet (num4, ref Value2, -1L);
								num5 = (short)unchecked(num5 + 1);
							} while (num5 <= 5);
							FileSystem.FileGet (num4, ref Value3, -1L);
							short num6 = Value3;
							for (num5 = 1; num5 <= num6; num5 = (short)unchecked(num5 + 1)) {
								FileSystem.FileGet (num4, ref Value, -1L);
								Value2 = Strings.Space (Value);
								FileSystem.FileGet (num4, ref Value2, -1L);
								if (Strings.StrComp (@string, Value2, CompareMethod.Text) == 0) {
									FileSystem.FileGet (num4, ref Value4, -1L);
									FileSystem.FileGet (num4, ref Value5, -1L);
									FileSystem.Seek (num4, Value4);
									short num7 = Value5;
									short num8;
									for (num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
										FileSystem.FileGet (num4, ref Value, -1L);
										Value2 = Strings.Space (Value);
										FileSystem.FileGet (num4, ref Value2, -1L);
										if (Strings.StrComp (fileName, Value2, CompareMethod.Text) == 0) {
											FileSystem.FileGet (num4, ref Value6, -1L);
											break;
										}
										if (Strings.StrComp (Strings.Left (fileName, Strings.Len (fileName) - 4) + ".cfss", Value2, CompareMethod.Text) == 0) {
											FileSystem.FileGet (num4, ref Value6, -1L);
											break;
										}
										if (Strings.StrComp (fileName, Value2 + ".sct", CompareMethod.Text) == 0) {
											FileSystem.FileGet (num4, ref Value6, -1L);
											break;
										}
										FileSystem.Seek (num4, FileSystem.Seek (num4) + 4);
									}
									if (num8 <= Value5) {
										break;
									}
								} else {
									FileSystem.Seek (num4, FileSystem.Seek (num4) + 6);
								}
							}
							if (num5 > Value3) {
								strMsg = strMsg + "Could not find library section:  " + Filename + "\r\n";
								break;
							}
							goto IL_023e;
						}
						if (FileSystem.FileLen (strFileName) != 0L) {
							FileSystem.FileOpen (num4, strFileName, OpenMode.Binary, OpenAccess.Read);
							Value6 = 1;
							goto IL_023e;
						}
						goto end_IL_0000_2;
					}
					case 4192:
						{
							num = -1;
							switch (num2) {
							case 2:
								strMsg = strMsg + Information.Err ().Description + "\r\n";
								ProjectData.ClearProjectError ();
								if (num == 0) {
									throw ProjectData.CreateProjectError (-2146828268);
								}
								num = 0;
								break;
							default:
								goto IL_1096;
							}
							break;
						}
						IL_0bfe:
						strMsg = strMsg + part.Name + " has more than " + Conversions.ToString (byte.MaxValue) + " elements.\r\n";
						break;
						IL_023e:
						FileSystem.Seek (num4, Value6);
						Value2 = Strings.Space (3);
						FileSystem.FileGet (num4, ref Value2, -1L);
						if ((Strings.Asc (Value2) >= 48) & (Operators.CompareString (Strings.Right (Value2, 1), "-", TextCompare: false) == 0)) {
							num9 = 0;
							FileSystem.Seek (num4, 1L);
						} else if (Strings.Asc (Value2) == 1) {
							num9 = 100;
							FileSystem.Seek (num4, 2L);
						} else {
							num9 = (short)(Strings.Asc (Value2) * 100 + Strings.Asc (Strings.Mid (Value2, 2, 1)));
							FileSystem.Seek (num4, Value6 + 2);
						}
						if (unchecked(num9 / 10) > 140) {
							strMsg += "Unrecognized section file version.\r\n";
							break;
						}
						AppVer = num9;
						SctProp = false;
						Saved = true;
						if (num9 <= 100) {
							Value2 = Strings.Space (10);
							FileSystem.FileGet (num4, ref Value2, -1L);
							RevDate = DateAndTime.DateValue (Value2);
							Value2 = Strings.Space (8);
							FileSystem.FileGet (num4, ref Value2, -1L);
							RevDate = RevDate.AddTicks (DateAndTime.TimeValue (Value2).Ticks);
						} else {
							FileSystem.FileGet (num4, ref RevDate, -1L);
						}
						if (num9 < 100) {
							RevBy = string.Empty;
							Description = string.Empty;
							Project = string.Empty;
						} else {
							Value2 = ((num9 >= 410) ? Strings.Space (40) : Strings.Space (16));
							FileSystem.FileGet (num4, ref Value2, -1L);
							RevBy = Strings.Trim (Value2);
							Value2 = Strings.Space (40);
							FileSystem.FileGet (num4, ref Value2, -1L);
							Description = Strings.Trim (Value2);
							Value2 = Strings.Space (40);
							FileSystem.FileGet (num4, ref Value2, -1L);
							Project = Strings.Trim (Value2);
						}
						if (num9 <= 100) {
							FileSystem.FileGet (num4, ref Material.Fy [2], -1L);
							if (num9 == 100) {
								FileSystem.FileGet (num4, ref Material.Fu, -1L);
							} else {
								Material.Fu = Material.Fy [2];
							}
							if (Material.Fu == Material.Fy [2]) {
								Material.Fu = (float)(1.4 * (double)Material.Fy [2]);
								ColdWork = false;
							} else {
								ColdWork = true;
							}
							FileSystem.FileGet (num4, ref Material.Eo [2], -1L);
							Value2 = Strings.Space (4);
							FileSystem.FileGet (num4, ref Value2, -1L);
							FileSystem.FileGet (num4, ref Value7, -1L);
							float num10 = Material.Eo [2] * Value7 * Value7 / 29500f;
							if (num10 >= 500f && num10 <= 4000f) {
								num11 = 1000f;
							} else if (num10 >= 0.5f && num10 <= 4f) {
								num11 = 1f;
							} else if (num10 >= 4f && num10 <= 400f) {
								num11 = 4.448221f;
							} else if (num10 > 4000f) {
								num11 = 4448.221f;
							} else if (num10 >= 400f && num10 <= 500f) {
								num11 = 453.592377f;
							} else if (num10 >= 0f && num10 <= 0.5f) {
								num11 = 0.45359236f;
							}
							MaterialType material = Material;
							material.SetCarbon ();
							material.Fy [2] = material.Fy [2] * Value7 * Value7 / num11;
							material.Eo [2] = material.Eo [2] * Value7 * Value7 / num11;
							material.Fu = material.Fu * Value7 * Value7 / num11;
							num5 = 1;
							do {
								material.Fy [num5] = material.Fy [2];
								material.Eo [num5] = material.Eo [2];
								material.N [num5] = 0f;
								num5 = (short)unchecked(num5 + 1);
							} while (num5 <= 4);
							material.Fy [5] = (float)(0.6 * (double)material.Fy [2]);
							material.Eo [5] = (float)((double)material.Eo [2] / 29500.0 * 11300.0);
							material.N [5] = 0f;
							material.Name = string.Empty;
							material.FyMin = 0f;
							material.FuMin = 0f;
							material.FuMax = 0f;
							material.Elong = -1f;
							material.ElongThin = -1f;
							material.ThkMin = -1f;
							material = null;
						} else {
							FileSystem.FileGet (num4, ref ColdWork, -1L);
							if (num9 >= 1100) {
								FileSystem.FileGet (num4, ref Reserve, -1L);
							}
							MaterialType material2 = Material;
							material2.Name = Strings.Space (24);
							FileSystem.FileGet (num4, ref material2.Name, -1L);
							material2.Family = Strings.Space (1);
							if (num9 >= 1400) {
								FileSystem.FileGet (num4, ref material2.Family, -1L);
							}
							num5 = 1;
							do {
								FileSystem.FileGet (num4, ref material2.Eo [num5], -1L);
								num5 = (short)unchecked(num5 + 1);
							} while (num5 <= 5);
							num5 = 1;
							do {
								FileSystem.FileGet (num4, ref material2.Fy [num5], -1L);
								num5 = (short)unchecked(num5 + 1);
							} while (num5 <= 5);
							num5 = 1;
							do {
								FileSystem.FileGet (num4, ref material2.N [num5], -1L);
								num5 = (short)unchecked(num5 + 1);
							} while (num5 <= 5);
							FileSystem.FileGet (num4, ref material2.Fu, -1L);
							FileSystem.FileGet (num4, ref material2.FyMin, -1L);
							FileSystem.FileGet (num4, ref material2.FuMin, -1L);
							FileSystem.FileGet (num4, ref material2.FuMax, -1L);
							material2.Elong = -1f;
							material2.ElongThin = -1f;
							material2.ThkMin = -1f;
							if (num9 >= 1400) {
								FileSystem.FileGet (num4, ref material2.Elong, -1L);
								FileSystem.FileGet (num4, ref material2.ElongThin, -1L);
								FileSystem.FileGet (num4, ref material2.ThkMin, -1L);
							}
							material2.AssignFamily ();
							material2 = null;
							Value7 = 1f;
							num11 = 1f;
						}
						FileSystem.FileGet (num4, ref CwOverride, -1L);
						FileSystem.FileGet (num4, ref JOverride, -1L);
						if (num9 >= 400) {
							FileSystem.FileGet (num4, ref ConnSpacing, -1L);
						}
						if (num9 >= 1000) {
							FileSystem.FileGet (num4, ref HoleLength, -1L);
							if (num9 >= 1100) {
								FileSystem.FileGet (num4, ref HoleSpacing, -1L);
							} else {
								HoleSpacing = 24f;
								HoleLength *= HoleSpacing;
							}
						}
						if (num9 >= 500) {
							FileSystem.FileGet (num4, ref DSM.UseDSM, -1L);
							FileSystem.FileGet (num4, ref DSM.PreQualified, -1L);
							FileSystem.FileGet (num4, ref DSM.Pcrl, -1L);
							FileSystem.FileGet (num4, ref DSM.Pcrd, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrlxp, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrdxp, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrlxn, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrdxn, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrlyp, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrdyp, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrlyn, -1L);
							FileSystem.FileGet (num4, ref DSM.Mcrdyn, -1L);
							if (num9 >= 800) {
								FileSystem.FileGet (num4, ref DSM.Vcry, -1L);
								FileSystem.FileGet (num4, ref DSM.Vcrx, -1L);
							}
						}
						FileSystem.FileGet (num4, ref nPart, -1L);
						if (unchecked((uint)nPart) > 255u) {
							strMsg = strMsg + "Cannot open a section with more than " + Conversions.ToString (byte.MaxValue) + " parts.\r\n";
							break;
						}
						if (nPart <= 0) {
							Part = new Part[2];
							Part [1] = new Part {
								Name = "Part 1"
							};
						} else {
							Part = new Part[unchecked((int)nPart) + 1];
							short num12 = nPart;
							for (short num13 = 1; num13 <= num12; num13 = (short)unchecked(num13 + 1)) {
								Part [num13] = new Part ();
								part = Part [num13];
								unchecked {
									if (num9 <= 100) {
										part.Name = "Part " + Conversions.ToString ((int)num13);
										Value8 = part.iXPosition;
										Value9 = part.iYPosition;
									} else {
										Value2 = Strings.Space (20);
										FileSystem.FileGet (num4, ref Value2, -1L);
										part.Name = Strings.Trim (Value2);
										FileSystem.FileGet (num4, ref part.Centerline, -1L);
										FileSystem.FileGet (num4, ref part.Closed, -1L);
										FileSystem.FileGet (num4, ref part.DefRad, -1L);
										FileSystem.FileGet (num4, ref Value8, -1L);
										FileSystem.FileGet (num4, ref Value9, -1L);
									}
									FileSystem.FileGet (num4, ref Value10, -1L);
									part.XPosition = Value10 / Value7;
									FileSystem.FileGet (num4, ref Value10, -1L);
									part.YPosition = Value10 / Value7;
									FileSystem.FileGet (num4, ref Value10, -1L);
									part.Thickness = Value10 / Value7;
									FileSystem.FileGet (num4, ref part.nElem, -1L);
									if (part.Closed) {
										if ((uint)part.nElem > 255u) {
											goto IL_0bfe;
										}
									} else if (part.nElem > 254) {
										goto IL_0c4a;
									}
								}
								if (part.nElem > Information.UBound (part.Element)) {
									part.Element = new Element[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)part.nElem) / 10.0) * 10.0) + 1];
								}
								short nElem = part.nElem;
								for (short num14 = 1; num14 <= nElem; num14 = (short)unchecked(num14 + 1)) {
									FileSystem.FileGet (num4, ref Value10, -1L);
									part.Element [num14].Len = Value10 / Value7;
									FileSystem.FileGet (num4, ref part.Element [num14].Ang, -1L);
									if (num9 <= 100) {
										part.Element [num14].Ang = (float)((double)part.Element [num14].Ang * System.Math.PI / 180.0);
									}
									FileSystem.FileGet (num4, ref Value10, -1L);
									part.Element [num14].Rad = Value10 / Value7;
									FileSystem.FileGet (num4, ref part.Element [num14].Web, -1L);
									if ((num9 < 400) & (part.Element [num14].Web == 2)) {
										flag = true;
									}
									FileSystem.FileGet (num4, ref part.Element [num14].K, -1L);
									if (num9 < 100) {
										part.Element [num14].Hole = 0f;
										part.Element [num14].Dist = part.Element [num14].Len / 2f;
									} else {
										FileSystem.FileGet (num4, ref Value10, -1L);
										part.Element [num14].Hole = Value10 / Value7;
										FileSystem.FileGet (num4, ref Value10, -1L);
										part.Element [num14].Dist = Value10 / Value7;
									}
								}
								if (num9 <= 100) {
									part.DefRad = part.Element [1].Rad;
								}
								CFS.SetThicknessIndex (Part [num13]);
								if ((num9 <= 100) & (part.nElem == 0)) {
									if (part.ThicknessIndex == -1) {
										part.DefRad = part.Thickness;
									} else {
										part.DefRad = CFS.Thicknesses [part.ThicknessIndex].DefRad;
									}
								}
								part = null;
								Part [num13].Geometry (ref blnChg, ref Value2);
								Part [num13].iXPosition = Value8;
								Part [num13].iYPosition = Value9;
							}
							if (flag) {
								strMsg += "This section was created with an older version of CFS. Elements with Single webs may need to be classified differently.\r\n";
							}
						}
						if (num9 >= 300) {
							FileSystem.FileGet (num4, ref Value11, -1L);
							if (Value11 > 0) {
								Report = Strings.Space (Value11);
								FileSystem.FileGet (num4, ref Report, -1L);
							}
						}
						materialType = Material.Clone ();
						MaterialIndex = CFS.MatchMaterial (Material);
						if (Material.Fy [2] != materialType.Fy [2]) {
							MaterialType material3 = Material;
							Material = materialType;
							CFS.ModifyDSMValues (this, material3.Fy [2]);
							Material = material3;
						}
						num5 = 1;
						do {
							if (materialType.Eo [num5] != Material.Eo [num5]) {
								GeomChangeDSM = true;
							}
							num5 = (short)unchecked(num5 + 1);
						} while (num5 <= 5);
						result = true;
						break;
						IL_0c4a:
						strMsg = strMsg + part.Name + " has more than " + Conversions.ToString (254) + " elements.\r\n";
						break;
					}
					FileSystem.FileClose (num4);
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 4192;
				continue;
			}
			break;
			IL_1096:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool ImportDXF (string strFileName, ref string strMsg)
	{
		int try0000_dispatch = -1;
		bool result;
		short intCode = default(short);
		double dblValue = default(double);
		short num8 = default(short);
		bool blnClosed = default(bool);
		int num = default(int);
		int num2 = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						string strCode = string.Empty;
						string empty = string.Empty;
						DXFVertex[] array = new DXFVertex[511];
						double num3 = 1.0;
						double num4 = 1E+308;
						double num5 = 1E+308;
						Initialize ();
						result = false;
						Filename = Path.ChangeExtension (strFileName, ".cfss");
						empty = CFSInterface.GetFileName (strFileName);
						Description = Strings.Left (CFSInterface.GetFileNameWithoutExtension (strFileName), 40);
						int num6 = FileSystem.FreeFile ();
						FileSystem.FileOpen (num6, strFileName, OpenMode.Input);
						bool flag;
						while (!FileSystem.EOF (num6)) {
							ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
							if (!((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "SECTION", TextCompare: false) == 0))) {
								continue;
							}
							ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
							if ((intCode == 2) & (Operators.CompareString (Strings.UCase (empty), "HEADER", TextCompare: false) == 0)) {
								while (!FileSystem.EOF (num6)) {
									ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
									if ((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "ENDSEC", TextCompare: false) == 0)) {
										break;
									}
									if (!((intCode == 9) & (Operators.CompareString (Strings.UCase (empty), "$INSUNITS", TextCompare: false) == 0))) {
										continue;
									}
									ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
									if (intCode == 70) {
										double num7 = Conversion.Int (dblValue);
										if (num7 == 0.0) {
											num3 = 1.0;
										} else if (num7 == 1.0) {
											num3 = 1.0;
										} else if (num7 == 2.0) {
											num3 = 12.0;
										} else if (num7 == 3.0) {
											num3 = 63360.0;
										} else if (num7 == 4.0) {
											num3 = 0.03937007874015748;
										} else if (num7 == 5.0) {
											num3 = 0.39370078740157483;
										} else if (num7 == 6.0) {
											num3 = 39.370078740157481;
										} else if (num7 == 7.0) {
											num3 = 39370.078740157485;
										} else if (num7 == 8.0) {
											num3 = 1E-06;
										} else if (num7 == 9.0) {
											num3 = 0.001;
										} else if (num7 == 10.0) {
											num3 = 36.0;
										} else if (num7 == 11.0) {
											num3 = 3.9370078740157481E-09;
										} else if (num7 == 12.0) {
											num3 = 3.9370078740157486E-08;
										} else if (num7 == 13.0) {
											num3 = 3.9370078740157478E-05;
										} else if (num7 == 14.0) {
											num3 = 3.9370078740157486;
										} else if (num7 == 15.0) {
											num3 = 393.70078740157481;
										} else if (num7 == 16.0) {
											num3 = 3937.0078740157483;
										} else if (num7 == 17.0) {
											num3 = 39370078740.157478;
										} else if (num7 == 18.0) {
											num3 = 5889679948818.8975;
										} else if (num7 == 19.0) {
											num3 = 3.7246970364491341E+17;
										} else if (num7 == 20.0) {
											num3 = 1.2148336935005394E+18;
										}
									}
								}
								continue;
							}
							if ((intCode == 2) & (Operators.CompareString (Strings.UCase (empty), "ENTITIES", TextCompare: false) == 0)) {
								ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
								while (!FileSystem.EOF (num6) && !((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "ENDSEC", TextCompare: false) == 0))) {
									if ((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "POLYLINE", TextCompare: false) == 0)) {
										num8 = (short)(num8 + 1);
										flag = true;
										Array.Clear (array, 0, array.Length);
										short num9 = 0;
										float num10 = -1f;
										unchecked {
											while (!FileSystem.EOF (num6)) {
												ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
												if (intCode == 40 || intCode == 41 || intCode == 43) {
													if (num10 >= 0f && (float)(num3 * dblValue) != num10 && flag) {
														flag = false;
														strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Non-uniform width\n";
													}
													if (num10 < 0f) {
														num10 = (float)(num3 * dblValue);
													}
													if (num10 < 0f || (num10 > 1f && flag)) {
														flag = false;
														strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid width\n";
													}
													if (num10 == 0f && flag) {
														flag = false;
														strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Width must be greater than 0\n";
													}
												} else if (intCode == 70) {
													if ((checked((long)System.Math.Round (dblValue)) & 1) == 1) {
														blnClosed = true;
													}
												} else if ((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "VERTEX", TextCompare: false) == 0)) {
													while (!FileSystem.EOF (num6)) {
														ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
														switch (intCode) {
														case 10:
															if (num9 < Information.UBound (array)) {
																num9 = checked((short)(num9 + 1));
															} else if (flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Too many elements\n";
															}
															if (num4 == 1E+308) {
																num4 = num3 * dblValue;
															}
															array [num9].X = (float)(num3 * dblValue - num4);
															continue;
														case 20:
															if (num5 == 1E+308) {
																num5 = num3 * dblValue;
															}
															array [num9].Y = (float)(num3 * dblValue - num5);
															continue;
														case 30:
															if (dblValue != 0.0 && flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Not in X-Y plane\n";
															}
															continue;
														}
														if (intCode == 40 || intCode == 41 || intCode == 43) {
															if (num10 >= 0f && (float)(num3 * dblValue) != num10 && flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Non-uniform width\n";
															}
															if (num10 < 0f) {
																num10 = (float)(num3 * dblValue);
															}
															if (num10 < 0f || (num10 > 1f && flag)) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid width\n";
															}
															if (num10 == 0f && flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Width must be greater than 0\n";
															}
															continue;
														}
														switch (intCode) {
														case 42:
															if (System.Math.Abs (dblValue) > 0.999 && flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid arc segment\n";
															}
															array [num9].Arc = (float)(4.0 * System.Math.Atan (dblValue));
															continue;
														case 0:
															break;
														default:
															continue;
														}
														if (Operators.CompareString (Strings.UCase (empty), "VERTEX", TextCompare: false) != 0) {
															break;
														}
													}
												}
												if (intCode == 0) {
													break;
												}
											}
											if ((num10 <= 0f || num9 < 2) && flag) {
												flag = false;
												strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Incomplete\n";
											}
										}
										if (flag) {
											nPart++;
											ref Part[] part = ref Part;
											part = (Part[])Utils.CopyArray (part, new Part[unchecked((int)nPart) + 1]);
											Part [nPart] = DXFPart (array, num9, num10, blnClosed);
											Part [nPart].Name = "Part " + Conversions.ToString (nPart);
										}
									} else if ((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "LWPOLYLINE", TextCompare: false) == 0)) {
										num8 = (short)(num8 + 1);
										flag = true;
										Array.Clear (array, 0, array.Length);
										short num9 = 0;
										float num10 = -1f;
										ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
										unchecked {
											while (!FileSystem.EOF (num6)) {
												if (intCode == 43) {
													num10 = (float)(num3 * dblValue);
													if (num10 < 0f || (num10 > 1f && flag)) {
														flag = false;
														strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid width\n";
													}
													if (num10 == 0f && flag) {
														flag = false;
														strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Width must be greater than 0\n";
													}
												} else if (intCode == 70) {
													if ((checked((long)System.Math.Round (dblValue)) & 1) == 1) {
														blnClosed = true;
													}
												} else if (intCode == 10) {
													while (!FileSystem.EOF (num6)) {
														switch (intCode) {
														case 10:
															if (num9 < Information.UBound (array)) {
																num9 = checked((short)(num9 + 1));
															} else {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Too many elements\n";
															}
															if (num4 == 1E+308) {
																num4 = num3 * dblValue;
															}
															array [num9].X = (float)(num3 * dblValue - num4);
															break;
														case 20:
															if (num5 == 1E+308) {
																num5 = num3 * dblValue;
															}
															array [num9].Y = (float)(num3 * dblValue - num5);
															break;
														case 30:
															if (dblValue != 0.0 && flag) {
																flag = false;
																strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Not in X-Y plane\n";
															}
															break;
														default:
															if (intCode == 40 || intCode == 41 || intCode == 43) {
																if (num10 >= 0f && (float)(num3 * dblValue) != num10 && flag) {
																	flag = false;
																	strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Non-uniform width\n";
																}
																if (num10 < 0f) {
																	num10 = (float)(num3 * dblValue);
																}
																if (num10 < 0f || (num10 > 1f && flag)) {
																	flag = false;
																	strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid width\n";
																}
																if (num10 == 0f && flag) {
																	flag = false;
																	strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Width must be greater than 0\n";
																}
															} else if (intCode == 42) {
																if (System.Math.Abs (dblValue) > 0.999 && flag) {
																	flag = false;
																	strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Invalid arc segment\n";
																}
																array [num9].Arc = (float)(4.0 * System.Math.Atan (dblValue));
															}
															break;
														}
														ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
														if (intCode == 0) {
															break;
														}
													}
												}
												if (intCode == 0) {
													break;
												}
												ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
											}
											if ((num10 <= 0f || num9 < 2) && flag) {
												flag = false;
												strMsg = strMsg + "Polyline " + Conversions.ToString ((int)num8) + ": Incomplete\n";
											}
										}
										if (flag) {
											nPart++;
											ref Part[] part2 = ref Part;
											part2 = (Part[])Utils.CopyArray (part2, new Part[unchecked((int)nPart) + 1]);
											Part [nPart] = DXFPart (array, num9, num10, blnClosed);
											Part [nPart].Name = "Part " + Conversions.ToString (nPart);
										}
									} else {
										ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
									}
									if (nPart == byte.MaxValue) {
										break;
									}
								}
								break;
							}
							while (!FileSystem.EOF (num6)) {
								ImportDXFData (num6, ref strCode, ref intCode, ref empty, ref dblValue);
								if ((intCode == 0) & (Operators.CompareString (Strings.UCase (empty), "ENDSEC", TextCompare: false) == 0)) {
									break;
								}
							}
						}
						FileSystem.FileClose (num6);
						if (num8 == 0) {
							strMsg += "No polylines found.\n";
						}
						string strMsg2 = string.Empty;
						do {
							flag = true;
							CalcProperties (ref strMsg2, blnCheckLicense: false);
							if (!SctProp) {
								continue;
							}
							int num11 = nPart;
							for (int i = 1; i <= num11; i++) {
								Part part3 = Part [i];
								if (part3.nElem > 0) {
									part3.XPosition -= Prop.Xcg;
									if (part3.XPosition < -100f) {
										part3.XPosition = -100f;
										flag = false;
									}
									if (part3.XPosition > 100f) {
										part3.XPosition = 100f;
										flag = false;
									}
									part3.YPosition -= Prop.Ycg;
									if (part3.YPosition < -100f) {
										part3.YPosition = -100f;
										flag = false;
									}
									if (part3.YPosition > 100f) {
										part3.YPosition = 100f;
										flag = false;
									}
								}
								part3 = null;
							}
						} while (!flag);
						SctProp = false;
						if (nPart > 0) {
							result = true;
						}
						goto end_IL_0000;
					}
					case 3583:
						num = -1;
						switch (num2) {
						}
						break;
					}
					goto IL_0e31;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 3583;
				continue;
			}
			break;
			IL_0e31:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	private Part DXFPart (DXFVertex[] Vertex, short nVertex, float T, bool blnClosed)
	{
		Part part = new Part ();
		string strMsg = string.Empty;
		Part part2 = part;
		part2.Thickness = T;
		part2.ThicknessIndex = -1;
		part2.Centerline = true;
		part2.Closed = blnClosed;
		if (nVertex < 4) {
			part2.Closed = false;
		}
		float num4 = default(float);
		float num5 = default(float);
		float num6 = default(float);
		if (blnClosed & (Vertex [nVertex].Arc != 0f)) {
			float num = Vertex [1].X - Vertex [nVertex].X;
			float num2 = Vertex [1].Y - Vertex [nVertex].Y;
			float num3 = (float)System.Math.Sqrt (num * num + num2 * num2);
			num4 = (float)((double)(num3 / 2f) / System.Math.Sin (System.Math.Abs (Vertex [nVertex].Arc) / 2f));
			num5 = (float)((double)num4 * System.Math.Tan (System.Math.Abs (Vertex [nVertex].Arc) / 2f));
			num6 = num5;
		}
		checked {
			int num7 = nVertex - 1;
			for (int i = 1; i <= num7; i++) {
				float num = Vertex [i + 1].X - Vertex [i].X;
				float num2 = Vertex [i + 1].Y - Vertex [i].Y;
				float num3 = (float)System.Math.Sqrt (num * num + num2 * num2);
				if (Vertex [i].Arc == 0f) {
					part2.nElem++;
					if (part2.nElem > Information.UBound (part2.Element)) {
						ref Element[] element = ref part2.Element;
						element = (Element[])Utils.CopyArray (element, new Element[unchecked((int)part2.nElem) + 9 + 1]);
					}
					part2.Element [part2.nElem].Len = num5 + num3;
					part2.Element [part2.nElem].Ang = (float)System.Math.Atan2 (num2, num);
					part2.Element [part2.nElem].Rad = (float)CFS.Max (num4 - T / 2f, 0.0);
					part2.Element [part2.nElem].Web = 1;
					num4 = 0f;
					num5 = 0f;
				} else {
					if (unchecked(num5 > 0f || i == 1)) {
						part2.nElem++;
						if (part2.nElem > Information.UBound (part2.Element)) {
							ref Element[] element2 = ref part2.Element;
							element2 = (Element[])Utils.CopyArray (element2, new Element[unchecked((int)part2.nElem) + 9 + 1]);
						}
						part2.Element [part2.nElem].Len = num5;
						part2.Element [part2.nElem].Ang = (float)(System.Math.Atan2 (num2, num) - (double)(Vertex [i].Arc / 2f));
						part2.Element [part2.nElem].Rad = (float)CFS.Max (num4 - T / 2f, 0.0);
						part2.Element [part2.nElem].Web = 1;
					}
					num4 = (float)((double)(num3 / 2f) / System.Math.Sin (System.Math.Abs (Vertex [i].Arc) / 2f));
					num5 = (float)((double)num4 * System.Math.Tan (System.Math.Abs (Vertex [i].Arc) / 2f));
					part2.Element [part2.nElem].Len += num5;
					if (i == 1) {
						part2.Element [part2.nElem].Rad = (float)CFS.Max (num4 - T / 2f, 0.0);
					}
				}
				if (unchecked((uint)part2.nElem) >= 255u) {
					break;
				}
			}
			if ((num5 > 0f) & (unchecked((uint)part2.nElem) < 255u)) {
				part2.nElem++;
				if (part2.nElem > Information.UBound (part2.Element)) {
					ref Element[] element3 = ref part2.Element;
					element3 = (Element[])Utils.CopyArray (element3, new Element[unchecked((int)part2.nElem) + 9 + 1]);
				}
				part2.Element [part2.nElem].Len = num5;
				part2.Element [part2.nElem].Ang = part2.Element [unchecked((int)part2.nElem) - 1].Ang + Vertex [nVertex - 1].Arc;
				part2.Element [part2.nElem].Rad = (float)CFS.Max (num4 - T / 2f, 0.0);
				part2.Element [part2.nElem].Web = 1;
			} else if (unchecked((part2.Closed && num5 == 0f && num6 == 0f) & ((uint)part2.nElem < 255u))) {
				part2.nElem++;
				if (part2.nElem > Information.UBound (part2.Element)) {
					ref Element[] element4 = ref part2.Element;
					element4 = (Element[])Utils.CopyArray (element4, new Element[unchecked((int)part2.nElem) + 9 + 1]);
				}
				part2.Element [part2.nElem].Rad = (float)CFS.Max (num4 - T / 2f, 0.0);
				part2.Element [part2.nElem].Web = 1;
			}
			part2.DefRad = part2.Element [2].Rad;
			if (!part2.Closed) {
				part2.Element [1].Rad = part2.DefRad;
			}
			if (part2.DefRad < 0f) {
				part2.DefRad = 0f;
			}
			if (part2.DefRad > 10f) {
				part2.DefRad = 10f;
			}
			int nElem = part2.nElem;
			for (int j = 1; j <= nElem; j++) {
				if (part2.Element [j].Rad < 0f) {
					part2.Element [j].Rad = 0f;
				}
				if (part2.Element [j].Rad > 10f) {
					part2.Element [j].Rad = 10f;
				}
				if (part2.Element [j].Len > 100f) {
					part2.Element [j].Len = 100f;
				}
			}
			bool blnChg = default(bool);
			part2.Geometry (ref blnChg, ref strMsg);
			part2.XPosition = (float)((double)Vertex [1].X - (double)num6 * System.Math.Cos (part2.Element [1].Ang) + (double)part2.Xcg);
			part2.YPosition = (float)((double)Vertex [1].Y - (double)num6 * System.Math.Sin (part2.Element [1].Ang) + (double)part2.Ycg);
			part2 = null;
			CFS.SetThicknessIndex (part);
			return part;
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void ImportDXFData (int hFile, ref string strCode, ref short intCode, ref string strValue, ref double dblValue)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					num = 1;
					strCode = FileSystem.LineInput (hFile);
					goto IL_000a;
				case 139:
					{
						num2 = num;
						switch (num3) {
						case 1:
							break;
						default:
							goto end_IL_0000;
						}
						int num4 = num2 + 1;
						num2 = 0;
						switch (num4) {
						case 1:
							break;
						case 2:
							goto IL_000a;
						case 3:
							goto IL_0020;
						case 4:
							goto IL_002b;
						case 5:
							goto IL_0039;
						case 6:
							goto IL_0040;
						case 7:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 8:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_0040:
					num = 6;
					dblValue = Conversion.Val (Strings.Trim (strValue));
					break;
					IL_000a:
					num = 2;
					intCode = checked((short)System.Math.Round (Conversion.Val (Strings.Trim (strCode))));
					goto IL_0020;
					IL_0020:
					num = 3;
					strValue = FileSystem.LineInput (hFile);
					goto IL_002b;
					IL_002b:
					num = 4;
					dblValue = 0.0;
					goto IL_0039;
					IL_0039:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_0040;
					end_IL_0000_2:
					break;
				}
				ProjectData.ClearProjectError ();
				num3 = 0;
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 139;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000_3:
			break;
		}
		if (num2 != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool Save (ref string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		int num3 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						strMsg = string.Empty;
						if (!File.Exists (Filename)) {
							string text = Path.ChangeExtension (Filename, ".sct");
							if (File.Exists (text)) {
								My.MyProject.Computer.FileSystem.RenameFile (text, CFSInterface.GetFileName (Filename));
							}
						}
						num3 = FileSystem.FreeFile ();
						FileSystem.FileOpen (num3, Filename, OpenMode.Output, OpenAccess.Write);
						FileSystem.FileClose (num3);
						FileSystem.FileOpen (num3, Filename, OpenMode.Binary, OpenAccess.Write);
						FileSystem.FilePut (num3, (byte)14, -1L);
						FileSystem.FilePut (num3, (byte)0, -1L);
						FileSystem.FilePut (num3, RevDate, -1L);
						FileSystem.FilePut (num3, RevBy.PadRight (40), -1L);
						FileSystem.FilePut (num3, Description.PadRight (40), -1L);
						FileSystem.FilePut (num3, Project.PadRight (40), -1L);
						FileSystem.FilePut (num3, ColdWork, -1L);
						FileSystem.FilePut (num3, Reserve, -1L);
						MaterialType material = Material;
						FileSystem.FilePut (num3, Strings.Left (material.Name, 24).PadRight (24), -1L);
						FileSystem.FilePut (num3, Strings.Left (material.Family, 1).PadRight (1), -1L);
						int num4 = 1;
						do {
							FileSystem.FilePut (num3, material.Eo [num4], -1L);
							num4++;
						} while (num4 <= 5);
						int num5 = 1;
						do {
							FileSystem.FilePut (num3, material.Fy [num5], -1L);
							num5++;
						} while (num5 <= 5);
						int num6 = 1;
						do {
							FileSystem.FilePut (num3, material.N [num6], -1L);
							num6++;
						} while (num6 <= 5);
						FileSystem.FilePut (num3, material.Fu, -1L);
						FileSystem.FilePut (num3, material.FyMin, -1L);
						FileSystem.FilePut (num3, material.FuMin, -1L);
						FileSystem.FilePut (num3, material.FuMax, -1L);
						FileSystem.FilePut (num3, material.Elong, -1L);
						FileSystem.FilePut (num3, material.ElongThin, -1L);
						FileSystem.FilePut (num3, material.ThkMin, -1L);
						material = null;
						FileSystem.FilePut (num3, CwOverride, -1L);
						FileSystem.FilePut (num3, JOverride, -1L);
						FileSystem.FilePut (num3, ConnSpacing, -1L);
						FileSystem.FilePut (num3, HoleLength, -1L);
						FileSystem.FilePut (num3, HoleSpacing, -1L);
						FileSystem.FilePut (num3, DSM, -1L);
						FileSystem.FilePut (num3, nPart, -1L);
						short num7 = nPart;
						for (short num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
							Part part = Part [num8];
							FileSystem.FilePut (num3, part.Name.PadRight (20), -1L);
							FileSystem.FilePut (num3, part.Centerline, -1L);
							FileSystem.FilePut (num3, part.Closed, -1L);
							FileSystem.FilePut (num3, part.DefRad, -1L);
							FileSystem.FilePut (num3, part.iXPosition, -1L);
							FileSystem.FilePut (num3, part.iYPosition, -1L);
							FileSystem.FilePut (num3, part.XPosition, -1L);
							FileSystem.FilePut (num3, part.YPosition, -1L);
							FileSystem.FilePut (num3, part.Thickness, -1L);
							FileSystem.FilePut (num3, part.nElem, -1L);
							short nElem = part.nElem;
							for (short num9 = 1; num9 <= nElem; num9 = (short)unchecked(num9 + 1)) {
								FileSystem.FilePut (num3, part.Element [num9].Len, -1L);
								FileSystem.FilePut (num3, part.Element [num9].Ang, -1L);
								FileSystem.FilePut (num3, part.Element [num9].Rad, -1L);
								FileSystem.FilePut (num3, part.Element [num9].Web, -1L);
								FileSystem.FilePut (num3, part.Element [num9].K, -1L);
								FileSystem.FilePut (num3, part.Element [num9].Hole, -1L);
								FileSystem.FilePut (num3, part.Element [num9].Dist, -1L);
							}
							part = null;
						}
						if (Strings.Len (Report) == 0) {
							FileSystem.FilePut (num3, 0, -1L);
						} else {
							FileSystem.FilePut (num3, Strings.Len (Report), -1L);
							FileSystem.FilePut (num3, Report, -1L);
						}
						Saved = true;
						result = true;
						break;
					}
					case 1197:
						num = -1;
						switch (num2) {
						case 2:
							strMsg = strMsg + Information.Err ().Description + "\r\n";
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
					FileSystem.FileClose (num3);
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1197;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool SaveAsDXF (string strFileName, float Mult, ref string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		int num3 = default(int);
		DXF.Point2D point2D = default(DXF.Point2D);
		DXF.Point2D point2D2 = default(DXF.Point2D);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						num3 = FileSystem.FreeFile ();
						Extents ();
						point2D.X = Xmin;
						point2D.Y = Ymin;
						point2D2.X = Xmax;
						point2D2.Y = Ymax;
						DXF.DXFOpen (num3, strFileName, point2D, point2D2, Mult);
						string layer = "0";
						short color = 0;
						string empty = string.Empty;
						short num4 = nPart;
						for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
							float thickness = Part [num5].Thickness;
							float num6 = Part [num5].XPosition - Part [num5].Xcg;
							float num7 = Part [num5].YPosition - Part [num5].Ycg;
							if (Part [num5].nElem > 0) {
								float ang = Part [num5].Element [Part [num5].nElem].Ang;
								short nElem = Part [num5].nElem;
								for (short num8 = 1; num8 <= nElem; num8 = (short)unchecked(num8 + 1)) {
									if ((num8 > 1) | Part [num5].Closed) {
										point2D.X = num6 + Part [num5].Element [num8].Xac;
										point2D.Y = num7 + Part [num5].Element [num8].Yac;
										float arc = Part [num5].Element [num8].Arc;
										if (arc != 0f) {
											float rad = Part [num5].Element [num8].Rad;
											float A = (float)((double)ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
											float B = A + arc;
											if (arc < 0f) {
												CFS.Swap (ref A, ref B);
											}
											if (rad > 0f) {
												DXF.DXFArc (num3, layer, color, empty, point2D, rad, A, B);
											}
											rad += thickness;
											if (rad > 0f) {
												DXF.DXFArc (num3, layer, color, empty, point2D, rad, A, B);
											}
										}
									}
									ang = Part [num5].Element [num8].Ang;
									float num9 = (float)((double)(thickness / 2f) * System.Math.Sin (ang));
									float num10 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (ang));
									float num11 = num6 + Part [num5].Element [num8].X0;
									float num12 = num7 + Part [num5].Element [num8].Y0;
									float num13 = num6 + Part [num5].Element [num8].X1;
									float num14 = num7 + Part [num5].Element [num8].Y1;
									point2D.X = num11 - num9;
									point2D.Y = num12 - num10;
									if ((num8 == 1) & !Part [num5].Closed) {
										point2D2.X = num11 + num9;
										point2D2.Y = num12 + num10;
										DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
									}
									point2D2.X = num13 - num9;
									point2D2.Y = num14 - num10;
									DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
									point2D.X = num11 + num9;
									point2D.Y = num12 + num10;
									point2D2.X = num13 + num9;
									point2D2.Y = num14 + num10;
									DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
									if ((num8 == Part [num5].nElem) & !Part [num5].Closed) {
										point2D.X = num13 - num9;
										point2D.Y = num14 - num10;
										DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
									}
									if (Part [num5].Element [num8].Hole > 0f) {
										num11 = num6 + Part [num5].Element [num8].Xh0;
										num12 = num7 + Part [num5].Element [num8].Yh0;
										num13 = num6 + Part [num5].Element [num8].Xh1;
										num14 = num7 + Part [num5].Element [num8].Yh1;
										point2D.X = num11 - num9;
										point2D.Y = num12 - num10;
										point2D2.X = num11 + num9;
										point2D2.Y = num12 + num10;
										DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
										point2D.X = num11;
										point2D.Y = num12;
										point2D2.X = num13;
										point2D2.Y = num14;
										DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
										point2D.X = num13 - num9;
										point2D.Y = num14 - num10;
										point2D2.X = num13 + num9;
										point2D2.Y = num14 + num10;
										DXF.DXFLine (num3, layer, color, empty, point2D, point2D2);
									}
								}
							}
						}
						DXF.DXFClose (num3);
						result = true;
						goto end_IL_0000;
					}
					case 1517:
						num = -1;
						switch (num2) {
						case 2:
							strMsg = strMsg + Information.Err ().Description + "\r\n";
							FileSystem.FileClose (num3);
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000;
						}
						break;
					}
					goto IL_0623;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1517;
				continue;
			}
			break;
			IL_0623:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public string CheckBasicSection ()
	{
		if (CFS.intLicenseType != 0) {
			return string.Empty;
		}
		if (nPart > 1) {
			return "This calculation requires a full CFS license for sections with more than 1 part.";
		}
		if (Material.IsStainless ()) {
			return "This calculation requires a full CFS license for stainless steel sections.";
		}
		if (MaterialIndex == 0) {
			return "This calculation requires a full CFS license for custom materials.";
		}
		if (ColdWork) {
			return "This calculation requires a full CFS license to use cold work of forming strength increase.";
		}
		if (Reserve) {
			return "This calculation requires a full CFS license to use inelastic reserve strength.";
		}
		int num = nPart;
		checked {
			for (int i = 1; i <= num; i++) {
				if (Part [i].Closed & (Part [i].nElem > 4)) {
					return "This calculation requires a full CFS license for closed parts with more than 4 elements.";
				}
				if (!Part [i].Closed & (Part [i].nElem > 5)) {
					return "This calculation requires a full CFS license for parts with more than 5 elements.";
				}
				int nElem = Part [i].nElem;
				for (int j = 1; j <= nElem; j++) {
					if (Part [i].Element [j].Hole > 0f) {
						return "This calculation requires a full CFS license for elements with holes.";
					}
					if (Part [i].Element [j].K > 0f) {
						return "This calculation requires a full CFS license for elements with k overrides.";
					}
				}
			}
			return string.Empty;
		}
	}

	public void CalcProperties (ref string strMsg, bool blnCheckLicense = true)
	{
		_ = new TorsionData[1];
		strMsg = string.Empty;
		SctProp = false;
		if (blnCheckLicense && !CFS.CheckLicense ()) {
			strMsg += "License is no longer available.\r\n";
			return;
		}
		short num = 1;
		checked {
			do {
				if ((double)Material.Fy [num] > 0.01 * (double)Material.Eo [num]) {
					strMsg += "Yield strain exceeds 0.01.\r\n";
					return;
				}
				num = (short)unchecked(num + 1);
			} while (num <= 4);
			if ((double)Material.Fy [5] > 0.8 * (double)Material.FyMin) {
				strMsg += "Shear yield greater than 0.8Fy.\r\n";
				return;
			}
			if (Material.Fu > 3f * Material.Fy [2]) {
				strMsg += "Tensile strength exceeds 3Fy.\r\n";
				return;
			}
			if (HoleSpacing < 2f * HoleLength) {
				strMsg += "Hole spacing less than twice the hole length.\r\n";
				return;
			}
			if (nPart == 0) {
				strMsg += "Section has no parts.\r\n";
				return;
			}
			short num2 = nPart;
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Part [num3].nElem == 0) {
					strMsg = strMsg + Part [num3].Name + " has no elements.\r\n";
				}
				Part part = Part [num3];
				short nElem = part.nElem;
				for (short num4 = 1; num4 <= nElem; num4 = (short)unchecked(num4 + 1)) {
					unchecked {
						if (part.Element [num4].Len == 0f) {
							strMsg = strMsg + part.Name + " element " + Conversions.ToString ((int)num4) + " length is zero and should be removed.\r\n";
						}
						if (part.Element [num4].Wid < 0f) {
							strMsg = strMsg + part.Name + " element " + Conversions.ToString ((int)num4) + " is too short.\r\n";
						}
						short num5;
						if (num4 == part.nElem) {
							if (!part.Closed) {
								break;
							}
							num5 = 1;
						} else {
							num5 = checked((short)(num4 + 1));
						}
						float num6 = System.Math.Abs (part.Element [num5].Ang - part.Element [num4].Ang);
						if ((double)num6 > System.Math.PI * 2.0) {
							num6 = (float)((double)num6 - System.Math.PI * 2.0);
						}
						if (System.Math.Abs (System.Math.PI - (double)num6) < 9.9999997473787516E-05) {
							strMsg = strMsg + part.Name + " elements " + Conversions.ToString ((int)num4) + " and " + Conversions.ToString ((int)num5) + " are in opposite directions.\r\n";
						}
					}
				}
				part = null;
			}
			if (Strings.Len (strMsg) > 0) {
				return;
			}
			short num7 = nPart;
			for (short num3 = 1; num3 <= num7; num3 = (short)unchecked(num3 + 1)) {
				Part part2 = Part [num3];
				short num8 = 0;
				short num9 = 0;
				short num10 = (short)(unchecked((int)part2.nElem) - 1);
				for (short num4 = 1; num4 <= num10; num4 = (short)unchecked(num4 + 1)) {
					if ((System.Math.Abs (System.Math.Sin ((part2.Element [num4].Ang - part2.Element [num4 + 1].Ang) / 2f)) < 9.9999997473787516E-05) & (part2.Element [num4].K == 0f) & (part2.Element [num4 + 1].K == 0f)) {
						if (num8 == 0) {
							num8 = num4;
						}
						if (num4 + 1 == part2.nElem) {
							num9 = part2.nElem;
						}
					} else if (num8 > 0) {
						num9 = num4;
					}
					if (num9 > num8) {
						strMsg = unchecked(strMsg + part2.Name + " elements " + Conversions.ToString ((int)num8) + " to " + Conversions.ToString ((int)num9)) + " are in the same direction and must be combined.\r\n";
						num8 = 0;
						num9 = 0;
					}
				}
				if ((part2.Closed && System.Math.Abs (System.Math.Sin ((part2.Element [part2.nElem].Ang - part2.Element [1].Ang) / 2f)) < 9.9999997473787516E-05) & (part2.Element [part2.nElem].K == 0f) & (part2.Element [1].K == 0f)) {
					strMsg = strMsg + part2.Name + " elements 1 and " + Conversions.ToString (part2.nElem) + " are in the same direction and must be combined.\r\n";
				}
				part2 = null;
			}
			if (Strings.Len (strMsg) > 0) {
				return;
			}
			Prop.FlatWidth = 0f;
			short num11 = nPart;
			float num12 = default(float);
			float num13 = default(float);
			float num14 = default(float);
			float num15 = default(float);
			float num16 = default(float);
			float num17 = default(float);
			float num22 = default(float);
			float num23 = default(float);
			float num24 = default(float);
			float num25 = default(float);
			float num26 = default(float);
			float num27 = default(float);
			float num28 = default(float);
			float num29 = default(float);
			float num30 = default(float);
			float num31 = default(float);
			float num32 = default(float);
			float num33 = default(float);
			float num34 = default(float);
			float num35 = default(float);
			float num40 = default(float);
			float num41 = default(float);
			float num42 = default(float);
			float num43 = default(float);
			float num44 = default(float);
			float num45 = default(float);
			float num18 = default(float);
			float num19 = default(float);
			float num20 = default(float);
			float num21 = default(float);
			float num36 = default(float);
			float num37 = default(float);
			float num38 = default(float);
			float num39 = default(float);
			for (short num3 = 1; num3 <= num11; num3 = (short)unchecked(num3 + 1)) {
				Part part3 = Part [num3];
				part3.CalcProperties ();
				float xPosition = part3.XPosition;
				float yPosition = part3.YPosition;
				Prop.FlatWidth += part3.A / part3.Thickness;
				num12 += part3.A;
				num13 += part3.A * xPosition;
				num14 += part3.A * yPosition;
				num15 += part3.A * xPosition * xPosition + part3.Iy;
				num16 += part3.A * yPosition * yPosition + part3.Ix;
				num17 += part3.A * xPosition * yPosition + part3.Ixy;
				num18 += part3.SAX3 + 3f * part3.Iy * xPosition + part3.A * xPosition * xPosition * xPosition;
				num19 += part3.SAY3 + 3f * part3.Ix * yPosition + part3.A * yPosition * yPosition * yPosition;
				num20 += part3.SAXY2 + part3.Ix * xPosition + 2f * part3.Ixy * yPosition + part3.A * xPosition * yPosition * yPosition;
				num21 += part3.SAYX2 + part3.Iy * yPosition + 2f * part3.Ixy * xPosition + part3.A * yPosition * xPosition * xPosition;
				num22 += part3.Avx;
				num23 += part3.Avy;
				num24 += part3.Ix;
				num25 += part3.Iy;
				num26 += part3.Ix * (xPosition + part3.Xo);
				num27 += part3.Iy * (yPosition + part3.Yo);
				num28 += part3.Cw;
				num29 += part3.J;
				xPosition = part3.XPosition - part3.Xcg + part3.Xcgn;
				yPosition = part3.YPosition - part3.Ycg + part3.Ycgn;
				num30 += part3.An;
				num31 += part3.An * xPosition;
				num32 += part3.An * yPosition;
				num33 += part3.An * xPosition * xPosition + part3.Iyn;
				num34 += part3.An * yPosition * yPosition + part3.Ixn;
				num35 += part3.An * xPosition * yPosition + part3.Ixyn;
				num36 += part3.SAX3n + 3f * part3.Iyn * xPosition + part3.An * xPosition * xPosition * xPosition;
				num37 += part3.SAY3n + 3f * part3.Ixn * yPosition + part3.An * yPosition * yPosition * yPosition;
				num38 += part3.SAXY2n + part3.Ixn * xPosition + 2f * part3.Ixyn * yPosition + part3.An * xPosition * yPosition * yPosition;
				num39 += part3.SAYX2n + part3.Iyn * yPosition + 2f * part3.Ixyn * xPosition + part3.An * yPosition * xPosition * xPosition;
				num40 += part3.Ixn;
				num41 += part3.Iyn;
				num42 += part3.Ixn * (xPosition + part3.Xon);
				num43 += part3.Iyn * (yPosition + part3.Yon);
				num44 += part3.Cwn;
				num45 += part3.Jn;
				part3 = null;
			}
			ref PropertiesType prop = ref Prop;
			prop.A = num12;
			prop.Xcg = num13 / num12;
			prop.Ycg = num14 / num12;
			prop.Ix = num16 - num12 * prop.Ycg * prop.Ycg;
			prop.Iy = num15 - num12 * prop.Xcg * prop.Xcg;
			prop.Ixy = num17 - num12 * prop.Ycg * prop.Xcg;
			prop.Xo = num26 / num24 - prop.Xcg;
			prop.Yo = num27 / num25 - prop.Ycg;
			prop.Ic = prop.Ix + prop.Iy;
			prop.Io = prop.Ic + num12 * (prop.Xo * prop.Xo + prop.Yo * prop.Yo);
			num18 = num18 - 3f * prop.Iy * prop.Xcg - num12 * prop.Xcg * prop.Xcg * prop.Xcg;
			num19 = num19 - 3f * prop.Ix * prop.Ycg - num12 * prop.Ycg * prop.Ycg * prop.Ycg;
			num20 = num20 - prop.Ix * prop.Xcg - 2f * prop.Ixy * prop.Ycg - num12 * prop.Xcg * prop.Ycg * prop.Ycg;
			num21 = num21 - prop.Iy * prop.Ycg - 2f * prop.Ixy * prop.Xcg - num12 * prop.Ycg * prop.Xcg * prop.Xcg;
			float num46 = num19 + num21;
			float num47 = num18 + num20;
			prop.jy = (float)(0.5 * (double)(num46 * prop.Iy - num47 * prop.Ixy) / (double)(prop.Ix * prop.Iy - prop.Ixy * prop.Ixy) - (double)prop.Yo);
			prop.jx = (float)(0.5 * (double)(num47 * prop.Ix - num46 * prop.Ixy) / (double)(prop.Ix * prop.Iy - prop.Ixy * prop.Ixy) - (double)prop.Xo);
			prop.Cw = num28;
			prop.J = num29;
			if (CwOverride > 0f) {
				prop.Cw = CwOverride;
			}
			if (JOverride > prop.J) {
				prop.J = JOverride;
			}
			prop.I1 = (float)((double)((prop.Ix + prop.Iy) / 2f) + System.Math.Sqrt (System.Math.Pow (prop.Iy - prop.Ix, 2.0) / 4.0 + System.Math.Pow (prop.Ixy, 2.0)));
			prop.I2 = prop.Ix + prop.Iy - prop.I1;
			if (System.Math.Abs (prop.Ix / prop.Iy - 1f) < 0.0001f) {
				if (System.Math.Abs (prop.Ixy / prop.Io) < 0.0001f) {
					prop.Alpha = 0f;
				} else {
					prop.Alpha = (float)((double)(-System.Math.Sign (prop.Ixy)) * System.Math.PI / 4.0);
				}
			} else {
				prop.Alpha = (float)(System.Math.Atan (2f * prop.Ixy / (prop.Iy - prop.Ix)) / 2.0);
				if (prop.Ix < prop.Iy) {
					prop.Alpha = (float)((double)prop.Alpha + System.Math.PI / 2.0);
				}
				if ((double)prop.Alpha > System.Math.PI / 2.0) {
					prop.Alpha = (float)((double)prop.Alpha - System.Math.PI);
				}
			}
			if ((double)System.Math.Abs (prop.Alpha) < 1E-06) {
				prop.Alpha = 0f;
			}
			Extents ();
			prop.Sxt = prop.Ix / (Ymax - prop.Ycg);
			prop.Sxb = prop.Ix / (prop.Ycg - Ymin);
			if (prop.Sxt < prop.Sxb) {
				prop.Sx = prop.Sxt;
			} else {
				prop.Sx = prop.Sxb;
			}
			prop.Syl = prop.Iy / (prop.Xcg - Xmin);
			prop.Syr = prop.Iy / (Xmax - prop.Xcg);
			if (prop.Syl < prop.Syr) {
				prop.Sy = prop.Syl;
			} else {
				prop.Sy = prop.Syr;
			}
			prop.Rx = (float)System.Math.Sqrt (prop.Ix / prop.A);
			prop.Ry = (float)System.Math.Sqrt (prop.Iy / prop.A);
			prop.R1 = (float)System.Math.Sqrt (prop.I1 / prop.A);
			prop.R2 = (float)System.Math.Sqrt (prop.I2 / prop.A);
			prop.Rc = (float)System.Math.Sqrt (prop.Ic / prop.A);
			prop.Ro = (float)System.Math.Sqrt (prop.Io / prop.A);
			prop.Symmetry = 0;
			if ((double)(prop.Io - prop.Ic) < 0.01 * (double)prop.Ic) {
				prop.Symmetry = 1;
			}
			if ((double)System.Math.Abs (prop.Ixy) < 0.01 * (double)prop.Ic) {
				prop.Symmetry |= 2;
				if ((double)System.Math.Abs (prop.jy) < 0.001 * (double)prop.Rx) {
					prop.Symmetry |= 6;
				}
				if ((double)System.Math.Abs (prop.jx) < 0.001 * (double)prop.Ry) {
					prop.Symmetry |= 10;
				}
			}
			prop.Weight = (float)((double)prop.A * 3.4 / 12000.0);
			prop.An = num30;
			prop.Xcgn = num31 / num30;
			prop.Ycgn = num32 / num30;
			prop.Ixn = num34 - num30 * prop.Ycgn * prop.Ycgn;
			prop.Iyn = num33 - num30 * prop.Xcgn * prop.Xcgn;
			prop.Ixyn = num35 - num30 * prop.Xcgn * prop.Ycgn;
			prop.Xon = num42 / num40 - prop.Xcgn;
			prop.Yon = num43 / num41 - prop.Ycgn;
			prop.Icn = prop.Ixn + prop.Iyn;
			prop.Ion = prop.Icn + prop.An * (prop.Xon * prop.Xon + prop.Yon * prop.Yon);
			num36 = num36 - 3f * prop.Iyn * prop.Xcgn - num30 * prop.Xcgn * prop.Xcgn * prop.Xcgn;
			num37 = num37 - 3f * prop.Ixn * prop.Ycgn - num30 * prop.Ycgn * prop.Ycgn * prop.Ycgn;
			num38 = num38 - prop.Ixn * prop.Xcgn - 2f * prop.Ixyn * prop.Ycgn - num30 * prop.Xcgn * prop.Ycgn * prop.Ycgn;
			num39 = num39 - prop.Iyn * prop.Ycgn - 2f * prop.Ixyn * prop.Xcgn - num30 * prop.Ycgn * prop.Xcgn * prop.Xcgn;
			num46 = num37 + num39;
			num47 = num36 + num38;
			prop.jyn = (float)(0.5 * (double)(num46 * prop.Iyn - num47 * prop.Ixyn) / (double)(prop.Ixn * prop.Iyn - prop.Ixyn * prop.Ixyn) - (double)prop.Yon);
			prop.jxn = (float)(0.5 * (double)(num47 * prop.Ixn - num46 * prop.Ixyn) / (double)(prop.Ixn * prop.Iyn - prop.Ixyn * prop.Ixyn) - (double)prop.Xon);
			prop.Cwn = num44;
			prop.Jn = num45;
			if (CwOverride > 0f) {
				prop.Cwn = CwOverride;
			}
			if (JOverride > prop.Jn) {
				prop.Jn = JOverride;
			}
			prop.I1n = (float)((double)((prop.Ixn + prop.Iyn) / 2f) + System.Math.Sqrt (System.Math.Pow (prop.Iyn - prop.Ixn, 2.0) / 4.0 + System.Math.Pow (prop.Ixyn, 2.0)));
			prop.I2n = prop.Ixn + prop.Iyn - prop.I1n;
			if (System.Math.Abs (prop.Ixn / prop.Iyn - 1f) < 0.0001f) {
				if (System.Math.Abs (prop.Ixyn / prop.Ion) < 0.0001f) {
					prop.Alphan = 0f;
				} else {
					prop.Alphan = (float)((double)(-System.Math.Sign (prop.Ixyn)) * System.Math.PI / 4.0);
				}
			} else {
				prop.Alphan = (float)(System.Math.Atan (2f * prop.Ixyn / (prop.Iyn - prop.Ixn)) / 2.0);
				if (prop.Ixn < prop.Iyn) {
					prop.Alphan = (float)((double)prop.Alphan + System.Math.PI / 2.0);
				}
				if ((double)prop.Alphan > System.Math.PI / 2.0) {
					prop.Alphan = (float)((double)prop.Alphan - System.Math.PI);
				}
			}
			if ((double)System.Math.Abs (prop.Alphan) < 1E-06) {
				prop.Alphan = 0f;
			}
			prop.Sxtn = prop.Ixn / (Ymax - prop.Ycgn);
			prop.Sxbn = prop.Ixn / (prop.Ycgn - Ymin);
			if (prop.Sxtn < prop.Sxbn) {
				prop.Sxn = prop.Sxtn;
			} else {
				prop.Sxn = prop.Sxbn;
			}
			prop.Syln = prop.Iyn / (prop.Xcgn - Xmin);
			prop.Syrn = prop.Iyn / (Xmax - prop.Xcgn);
			if (prop.Syln < prop.Syrn) {
				prop.Syn = prop.Syln;
			} else {
				prop.Syn = prop.Syrn;
			}
			prop.Rxn = (float)System.Math.Sqrt (prop.Ixn / prop.An);
			prop.Ryn = (float)System.Math.Sqrt (prop.Iyn / prop.An);
			prop.Rcn = (float)System.Math.Sqrt (prop.Icn / prop.An);
			prop.Ron = (float)System.Math.Sqrt (prop.Ion / prop.An);
			prop.SymmetryNet = 0;
			if ((double)(prop.Ion - prop.Icn) < 0.01 * (double)prop.Icn) {
				prop.SymmetryNet = 1;
			}
			if ((double)System.Math.Abs (prop.Ixyn) < 0.01 * (double)prop.Icn) {
				prop.SymmetryNet |= 2;
				if ((double)System.Math.Abs (prop.jyn) < 0.001 * (double)prop.Rxn) {
					prop.SymmetryNet |= 6;
				}
				if ((double)System.Math.Abs (prop.jxn) < 0.001 * (double)prop.Ryn) {
					prop.SymmetryNet |= 10;
				}
			}
			prop.Avx = num22;
			prop.Avy = num23;
			if (IsCylinder ()) {
				float thickness = Part [1].Thickness;
				float rad = Part [1].Element [1].Rad;
				float num48 = rad + thickness;
				prop.Avx = (float)((double)prop.A * 0.75 * (double)(num48 * num48 + rad * rad) / (double)(num48 * num48 + num48 * rad + rad * rad));
				prop.Avy = prop.Avx;
			}
			PlasticModulus ();
			SctProp = true;
			if (GeomChange & ((CwOverride > 0f) | (JOverride > 0f))) {
				strMsg += "The section geometry changed since Cw and J override values were entered. Make sure the override values are still accurate.\r\n";
				GeomChange = false;
			}
			if (GeomChangeDSM & DSM.UseDSM & !DSM.IsAllZero ()) {
				strMsg += "The section geometry or material changed since Direct Strength values were entered. The Direct Strength values may need to be updated.\r\n";
				GeomChangeDSM = false;
			}
		}
	}

	public PropertiesType CalcEffProperties (float P, float Mx, float My, short Spec)
	{
		EffectiveProperties effectiveProperties = new EffectiveProperties ();
		float num = Material.Fy [2];
		float a = Prop.A;
		CFS.strTrace = string.Empty;
		PropertiesType result = default(PropertiesType);
		result.A = 0f;
		result.Ix = 0f;
		result.Iy = 0f;
		if (DSM.UseDSM & (DSM.Pcrl > 0f) & (DSM.Pcrd > 0f)) {
			float num2 = DSM.Pcrl * a * num;
			float num3 = ((!(P > 0f)) ? 0f : ((float)System.Math.Sqrt (P / num2)));
			float num4 = (Material.IsCarbon () ? ((!((double)num3 > 0.776)) ? 1f : ((float)((1.0 - 0.15 * System.Math.Pow (num2 / P, 0.4)) * System.Math.Pow (num2 / P, 0.4)))) : ((!((double)num3 > 0.55)) ? 1f : ((float)((0.95 - 0.22 * System.Math.Pow (num2 / P, 0.5)) * System.Math.Pow (num2 / P, 0.5)))));
			result.A = a * num4;
			float num5 = DSM.Pcrd * a * num;
			num3 = ((!(P > 0f)) ? 0f : ((float)System.Math.Sqrt (P / num5)));
			float num6 = (Material.IsCarbon () ? ((!((double)num3 > 0.561)) ? 1f : ((float)((1.0 - 0.25 * System.Math.Pow (num5 / P, 0.6)) * System.Math.Pow (num5 / P, 0.6)))) : (Material.IsFerritic () ? ((!((double)num3 > 0.533)) ? 1f : ((float)((0.9 - 0.2 * System.Math.Pow (num5 / P, 0.55)) * System.Math.Pow (num5 / P, 0.55)))) : ((!((double)num3 > 0.533)) ? 1f : ((float)((0.8 - 0.15 * System.Math.Pow (num5 / P, 0.55)) * System.Math.Pow (num5 / P, 0.55))))));
			if (num6 < num4) {
				result.A = a * num6;
			}
		}
		if ((DSM.UseDSM & (DSM.Mcrlxp > 0f) & (DSM.Mcrdxp > 0f)) && Mx >= 0f) {
			float num7 = DSM.Mcrlxp * Prop.Sx * num;
			float num3 = (float)System.Math.Sqrt (System.Math.Abs (Mx) / num7);
			float num4 = (Material.IsCarbon () ? ((!((double)num3 > 0.776)) ? 1f : ((float)((1.0 - 0.15 * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)))) : ((!((double)num3 > 0.667)) ? 1f : ((float)((1.0 - 0.2 * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)))));
			result.Ix = Prop.Ix * num4;
			result.Sxt = Prop.Sxt * num4;
			result.Sxb = Prop.Sxb * num4;
			float num8 = DSM.Mcrdxp * Prop.Sx * num;
			num3 = (float)System.Math.Sqrt (System.Math.Abs (Mx) / num8);
			float num6 = (Material.IsCarbon () ? ((!((double)num3 > 0.673)) ? 1f : ((float)((1.0 - 0.22 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.5)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.5)))) : (Material.IsFerritic () ? ((!((double)num3 > 0.533)) ? 1f : ((float)((0.9 - 0.2 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)))) : ((!((double)num3 > 0.533)) ? 1f : ((float)((0.8 - 0.15 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55))))));
			if (num6 < num4) {
				result.Ix = Prop.Ix * num6;
				result.Sxt = Prop.Sxt * num6;
				result.Sxb = Prop.Sxb * num6;
			}
		}
		if (((DSM.UseDSM & (DSM.Mcrlxn > 0f) & (DSM.Mcrdxn > 0f)) && Mx <= 0f) & (result.Ix == 0f)) {
			float num7 = DSM.Mcrlxn * Prop.Sx * num;
			float num3 = (float)System.Math.Sqrt (System.Math.Abs (Mx) / num7);
			float num4 = (Material.IsCarbon () ? ((!((double)num3 > 0.776)) ? 1f : ((float)((1.0 - 0.15 * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)))) : ((!((double)num3 > 0.667)) ? 1f : ((float)((1.0 - 0.2 * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (Mx), 0.4)))));
			result.Ix = Prop.Ix * num4;
			result.Sxt = Prop.Sxt * num4;
			result.Sxb = Prop.Sxb * num4;
			float num8 = DSM.Mcrdxn * Prop.Sx * num;
			num3 = (float)System.Math.Sqrt (System.Math.Abs (Mx) / num8);
			float num6 = (Material.IsCarbon () ? ((!((double)num3 > 0.673)) ? 1f : ((float)((1.0 - 0.22 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.5)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.5)))) : (Material.IsFerritic () ? ((!((double)num3 > 0.533)) ? 1f : ((float)((0.9 - 0.2 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)))) : ((!((double)num3 > 0.533)) ? 1f : ((float)((0.8 - 0.15 * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (Mx), 0.55))))));
			if (num6 < num4) {
				result.Ix = Prop.Ix * num6;
				result.Sxt = Prop.Sxt * num6;
				result.Sxb = Prop.Sxb * num6;
			}
		}
		if ((DSM.UseDSM & (DSM.Mcrlyp > 0f) & (DSM.Mcrdyp > 0f)) && My >= 0f) {
			float num7 = DSM.Mcrlyp * Prop.Sy * num;
			float num3 = (float)System.Math.Sqrt (System.Math.Abs (My) / num7);
			float num4 = (Material.IsCarbon () ? ((!((double)num3 > 0.776)) ? 1f : ((float)((1.0 - 0.15 * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)))) : ((!((double)num3 > 0.667)) ? 1f : ((float)((1.0 - 0.2 * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)))));
			result.Iy = Prop.Iy * num4;
			result.Syl = Prop.Syl * num4;
			result.Syr = Prop.Syr * num4;
			float num8 = DSM.Mcrdyp * Prop.Sy * num;
			num3 = (float)System.Math.Sqrt (System.Math.Abs (My) / num8);
			float num6 = (Material.IsCarbon () ? ((!((double)num3 > 0.673)) ? 1f : ((float)((1.0 - 0.22 * System.Math.Pow (num8 / System.Math.Abs (My), 0.5)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.5)))) : (Material.IsFerritic () ? ((!((double)num3 > 0.533)) ? 1f : ((float)((0.9 - 0.2 * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)))) : ((!((double)num3 > 0.533)) ? 1f : ((float)((0.8 - 0.15 * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.55))))));
			if (num6 < num4) {
				result.Iy = Prop.Iy * num6;
				result.Syl = Prop.Syl * num6;
				result.Syr = Prop.Syr * num6;
			}
		}
		if (((DSM.UseDSM & (DSM.Mcrlyn > 0f) & (DSM.Mcrdyn > 0f)) && My <= 0f) & (result.Iy == 0f)) {
			float num7 = DSM.Mcrlyn * Prop.Sy * num;
			float num3 = (float)System.Math.Sqrt (System.Math.Abs (My) / num7);
			float num4 = (Material.IsCarbon () ? ((!((double)num3 > 0.776)) ? 1f : ((float)((1.0 - 0.15 * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)))) : ((!((double)num3 > 0.667)) ? 1f : ((float)((1.0 - 0.2 * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)) * System.Math.Pow (num7 / System.Math.Abs (My), 0.4)))));
			result.Iy = Prop.Iy * num4;
			result.Syl = Prop.Syl * num4;
			result.Syr = Prop.Syr * num4;
			float num8 = DSM.Mcrdyn * Prop.Sy * num;
			num3 = (float)System.Math.Sqrt (System.Math.Abs (My) / num8);
			float num6 = (Material.IsCarbon () ? ((!((double)num3 > 0.673)) ? 1f : ((float)((1.0 - 0.22 * System.Math.Pow (num8 / System.Math.Abs (My), 0.5)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.5)))) : (Material.IsFerritic () ? ((!((double)num3 > 0.533)) ? 1f : ((float)((0.9 - 0.2 * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)))) : ((!((double)num3 > 0.533)) ? 1f : ((float)((0.8 - 0.22 * System.Math.Pow (num8 / System.Math.Abs (My), 0.55)) * System.Math.Pow (num8 / System.Math.Abs (My), 0.55))))));
			if (num6 < num4) {
				result.Iy = Prop.Iy * num6;
				result.Syl = Prop.Syl * num6;
				result.Syr = Prop.Syr * num6;
			}
		}
		if ((result.Ix > 0f) & (result.Iy > 0f)) {
			result.Ixy = (float)(0.5 * (double)(result.Iy - result.Ix) * System.Math.Tan (2f * Prop.Alpha));
		}
		PropEff.Trace = string.Empty;
		checked {
			if ((result.A == 0f) | (result.Ix == 0f) | (result.Iy == 0f)) {
				effectiveProperties.ResetProp (this, 2);
				int num9 = 1;
				do {
					float a2 = PropEff.A;
					effectiveProperties.EffProp (this, P, Mx, My, 2, Spec);
					if (!PropEff.Iterate || (double)System.Math.Abs (PropEff.A / a2 - 1f) < 0.0001) {
						break;
					}
					num9++;
				} while (num9 <= 20);
				if (result.A == 0f) {
					result.A = PropEff.A;
				}
				if ((result.Ix == 0f) | (result.Iy == 0f)) {
					result.Ixy = PropEff.Ixy;
				}
				if (result.Ix == 0f) {
					result.Ix = PropEff.Ix;
					result.Sxt = PropEff.Sxt;
					result.Sxb = PropEff.Sxb;
				}
				if (result.Iy == 0f) {
					result.Iy = PropEff.Iy;
					result.Syl = PropEff.Syl;
					result.Syr = PropEff.Syr;
				}
				if (CFS.blnTraceEffProp & !IsCylinder ()) {
					CFS.strTrace = CFS.strTrace + "Effective section at applied loads\r\n" + PropEff.Trace + "\r\n";
				}
			}
			result.Rx = (float)System.Math.Sqrt (result.Ix / result.A);
			result.Ry = (float)System.Math.Sqrt (result.Iy / result.A);
			result.Ic = result.Ix + result.Iy;
			result.Rc = (float)System.Math.Sqrt (result.Ic / result.A);
			result.Xo = Prop.Xo;
			result.Yo = Prop.Yo;
			result.Io = (float)((double)result.Ic + (double)result.A * (System.Math.Pow (result.Xo, 2.0) + System.Math.Pow (result.Yo, 2.0)));
			result.Ro = (float)System.Math.Sqrt (result.Io / result.A);
			result.I1 = (float)((double)((result.Ix + result.Iy) / 2f) + System.Math.Sqrt (System.Math.Pow (result.Iy - result.Ix, 2.0) / 4.0 + System.Math.Pow (result.Ixy, 2.0)));
			result.I2 = result.Ix + result.Iy - result.I1;
			if ((double)System.Math.Abs (result.Ix / result.Iy - 1f) < 0.0001) {
				if ((double)System.Math.Abs (result.Ixy / result.Io) < 0.0001) {
					result.Alpha = 0f;
				} else {
					result.Alpha = (float)((double)(-System.Math.Sign (result.Ixy)) * System.Math.PI / 4.0);
				}
			} else {
				result.Alpha = (float)(System.Math.Atan (2f * result.Ixy / (result.Iy - result.Ix)) / 2.0);
				if (result.Ix < result.Iy) {
					result.Alpha = (float)((double)result.Alpha + System.Math.PI / 2.0);
				}
				if ((double)result.Alpha > System.Math.PI / 2.0) {
					result.Alpha = (float)((double)result.Alpha - System.Math.PI);
				}
			}
			if ((double)System.Math.Abs (result.Alpha) < 1E-06) {
				result.Alpha = 0f;
			}
			return result;
		}
	}

	public void CalcStrength (short Spec)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		EffectiveProperties effectiveProperties = new EffectiveProperties ();
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		string text6 = string.Empty;
		bool flag = Material.IsStainless ();
		string text7;
		string text8;
		string text9;
		string text10;
		string text11;
		string truePart;
		string falsePart;
		string text12;
		string text13;
		string text15;
		string text16;
		string text17;
		string text18;
		string text19;
		string text14;
		if (flag) {
			text7 = "ASCE Eq. 4-1";
			text8 = "ASCE Eq. 4-7";
			text9 = "ASCE Eq. 7-1";
			text10 = "ASCE Eq. 7-2";
			text11 = "ASCE Eq. 7-3";
			text3 = "ASCE Eq. 7-4";
			truePart = string.Empty;
			falsePart = "ASCE Eq. 7-14";
			text12 = "ASCE Eq. 5-13";
			text13 = "ASCE Eq. 6-24";
			text14 = "ASCE Eq. 6-39";
			text15 = "ASCE Eq. 6-40";
			text16 = "ASCE Eq. 6-41";
			text17 = "ASCE Eq. 6-42";
			text18 = "ASCE Eq. 5-13";
			text19 = "ASCE Eq. 5-20";
			text = "ASCE Eq. 6-21";
			text2 = "ASCE Eq. 6-30";
		} else if (CFS.IsSpec1999 (Spec)) {
			text7 = "Eq. C2-1";
			text8 = "Eq. C2-2";
			text9 = "Eq. C3.2.1-1";
			text10 = "Eq. C3.2.1-2";
			text11 = "Eq. C3.2.1-3";
			truePart = "Eq. C3.2.2-1";
			falsePart = "Eq. C3.2.2-2";
			text12 = "Eq. C4-1";
			text13 = "Eq. C3.1.1-1";
			text14 = "Eq. C6.1-1";
			text15 = "Eq. C6.1-1";
			text16 = "Eq. C6.1-2";
			text17 = "Eq. C6.1-3";
			text18 = "Eq. C6.2-1";
			text19 = "Eq. C6.2-7";
		} else if (CFS.IsSpec2001 (Spec)) {
			if (CFS.IsSpecCan (Spec)) {
				text7 = "Eq. C2.1-1";
				text8 = "Eq. C2.2-1";
			} else {
				text7 = "Eq. C2-1";
				text8 = "Eq. C2-2";
			}
			text9 = "Eq. C3.2.1-2";
			text10 = "Eq. C3.2.1-3";
			text11 = "Eq. C3.2.1-4";
			truePart = "Eq. C3.2.2-1";
			falsePart = "Eq. C3.2.2-2";
			text12 = "Eq. C4-1";
			text13 = "Eq. C3.1.1-1";
			text14 = "Eq. C6.1-1";
			text15 = "Eq. C6.1-2";
			text16 = "Eq. C6.1-3";
			text17 = "Eq. C6.1-4";
			text18 = "Eq. C6.2-1";
			text19 = "Eq. C6.2-7";
		} else if (CFS.IsSpec2004 (Spec)) {
			if (CFS.IsSpecCan (Spec)) {
				text7 = "Eq. C2.1-1";
				text8 = "Eq. C2.2-1";
			} else {
				text7 = "Eq. C2-1";
				text8 = "Eq. C2-2";
			}
			text9 = "Eq. C3.2.1-2";
			text10 = "Eq. C3.2.1-3";
			text11 = "Eq. C3.2.1-4";
			truePart = "Eq. C3.2.2-1";
			falsePart = "Eq. C3.2.2-2";
			text12 = "Eq. C4-1";
			text13 = "Eq. C3.1.1-1";
			text14 = "Eq. C6.1-1";
			text15 = "Eq. C6.1-2";
			text16 = "Eq. C6.1-3";
			text17 = "Eq. C6.1-4";
			text18 = "Eq. C6.2-1";
			text19 = "Eq. C6.2-7";
		} else if (CFS.IsSpec2007 (Spec)) {
			if (CFS.IsSpecCan (Spec)) {
				text7 = "Eq. C2.1-1";
				text8 = "Eq. C2.2-1";
			} else {
				text7 = "Eq. C2-1";
				text8 = "Eq. C2-2";
			}
			text9 = "Eq. C3.2.1-2";
			text10 = "Eq. C3.2.1-3";
			text11 = "Eq. C3.2.1-4a";
			truePart = string.Empty;
			falsePart = "Eq. C3.2.2-1";
			text12 = "Eq. C4.1-1";
			text13 = "Eq. C3.1.1-1";
			text14 = "Eq. C3.1.3-1";
			text15 = "Eq. C3.1.3-2";
			text16 = "Eq. C3.1.3-3";
			text17 = "Eq. C3.1.3-4";
			text18 = "Eq. C4.1-1";
			text19 = "Eq. C4.1.5-2";
		} else if (CFS.IsSpec2010 (Spec) | CFS.IsSpec2012 (Spec)) {
			text7 = "Eq. C2.1-1";
			text8 = "Eq. C2.2-1";
			text9 = "Eq. C3.2.1-2";
			text10 = "Eq. C3.2.1-3";
			text11 = "Eq. C3.2.1-4a";
			truePart = string.Empty;
			falsePart = "Eq. C3.2.2-1";
			text12 = "Eq. C4.1-1";
			text13 = "Eq. C3.1.1-1";
			text14 = "Eq. C3.1.3-1";
			text15 = "Eq. C3.1.3-2";
			text16 = "Eq. C3.1.3-3";
			text17 = "Eq. C3.1.3-4";
			text18 = "Eq. C4.1-1";
			text19 = "Eq. C4.1.5-2";
			text = "1.2.2-5";
			text2 = "1.2.2-10";
		} else if (CFS.IsSpec2016 (Spec) | CFS.IsSpec2018 (Spec)) {
			text7 = "Eq. D2-1";
			text8 = "Eq. D3-1";
			text9 = "Eq. G2.1-1";
			text10 = "Eq. G2.1-2";
			text11 = "Eq. G2.1-3";
			truePart = string.Empty;
			falsePart = "Eq. G3-1";
			text12 = "Eq. E3.1-1";
			text13 = "Eq. F3.1-1";
			text14 = "Eq. F2.3-1";
			text15 = "Eq. F2.3-2";
			text16 = "Eq. F2.3-3";
			text17 = "Eq. F2.3-4";
			text18 = "Eq. E3.1-1";
			text19 = "Eq. E3.1.1.1-2";
			text = "Eq. F2.4.2-1";
			text2 = "Eq. F3.2.3-1";
		} else {
			text7 = "Eq. D2-1";
			text8 = "Eq. D3-1";
			text9 = "Eq. G2.1-1";
			text10 = "Eq. G2.1-2";
			text11 = string.Empty;
			truePart = string.Empty;
			falsePart = string.Empty;
			text4 = "Eq. G3-2";
			text5 = "Eq. G3-6";
			text6 = "Eq. G3-8";
			text12 = "Eq. E3.1-1";
			text13 = "Eq. F3.1-1";
			text14 = string.Empty;
			text15 = "Eq. F2.2.3-1";
			text16 = "Eq. F3.3-2";
			text17 = "Eq. F3.3-4";
			text18 = "Eq. E3.1-1";
			text19 = "Eq. E3.3-2";
			text = "Eq. F2.2.2-1";
			text2 = "Eq. F3.2.1-1";
		}
		string text20 = "Eq. 1.2.1-5";
		string text21 = "Eq. 1.2.1-6";
		string text22 = "Eq. 1.2.1-9 (2012)";
		string text23 = "Eq. 1.2.2-5";
		string text24 = "Eq. 1.2.2-6";
		string text25 = "Eq. 1.2.2-16 (2012)";
		if (flag) {
			text20 = "ASCE Eq. 5-14";
			text21 = "ASCE Eq. 5-15";
			text22 = "ASCE Eq. 5-18";
			text23 = "ASCE Eq. 6-25";
			text24 = "ASCE Eq. 6-26";
			text25 = "ASCE Eq. 6-29";
		} else if (CFS.IsSpec2012 (Spec)) {
			text20 = "Eq. 1.2.1-5";
			text21 = "Eq. 1.2.1-6";
			text22 = "Eq. 1.2.1-9";
			text23 = "Eq. 1.2.2-7";
			text24 = "Eq. 1.2.2-8";
			text25 = "Eq. 1.2.2-16";
		} else if (CFS.IsSpec2016 (Spec) | CFS.IsSpec2018 (Spec)) {
			text20 = "Eq. E3.2.1-1";
			text21 = "Eq. E3.2.1-2";
			text22 = "Eq. E3.2.2-2";
			text23 = "Eq. F3.2.1-1";
			text24 = "Eq. F3.2.1-2";
			text25 = "Eq. F3.2.2-2";
		} else if (CFS.IsSpec2022 (Spec)) {
			text20 = "Eq. E3.2-1";
			text21 = "Eq. E3.2-2";
			text22 = "Eq. E3.2-5";
			text23 = "Eq. F3.2-1";
			text24 = "Eq. F3.2-2";
			text25 = "Eq. F3.2-5";
		}
		string text26 = Conversions.ToString (Interaction.IIf (CFS.SpecYear (Spec) >= 2016 || flag, "Fn", "Fc"));
		CFS.strTrace = string.Empty;
		ColdWorkStress ((Specifications)checked((byte)Spec));
		if (CFS.blnTraceColdWork) {
			CFS.strTrace += strTraceCW;
		}
		float num = Material.Eo [2];
		float num2 = Material.Fy [2];
		float num3 = DesignFy (StressDirections.dirLC, (Specifications)checked((byte)Spec));
		float num4 = DesignFy (StressDirections.dirLT, (Specifications)checked((byte)Spec));
		float num5 = (float)CFS.Min (num3, num4);
		float num6 = DesignFy (StressDirections.dirSH, (Specifications)checked((byte)Spec));
		float num7 = Material.Fy [5];
		float num8 = DesignFu ((Specifications)checked((byte)Spec));
		float num9 = 2f;
		float num10 = 0.8f;
		if (CFS.IsSpecLSD (Spec) && !flag) {
			num10 = 0.75f;
		}
		Strength.Msg = string.Empty;
		Strength.Qual = CheckLimits (Spec, blnDSM: false, 0f, 0f, 0f);
		bool blnDSM = DSM.UseDSM & (DSM.Pcrl > 0f);
		Strength.PQual = CheckLimits (Spec, blnDSM, 1f, 0f, 0f);
		blnDSM = DSM.UseDSM & (DSM.Mcrlxp > 0f);
		Strength.MxpQual = CheckLimits (Spec, blnDSM, 0f, 1f, 0f);
		blnDSM = DSM.UseDSM & (DSM.Mcrlxn > 0f);
		Strength.MxnQual = CheckLimits (Spec, blnDSM, 0f, -1f, 0f);
		blnDSM = DSM.UseDSM & (DSM.Mcrlyp > 0f);
		Strength.MypQual = CheckLimits (Spec, blnDSM, 0f, 0f, 1f);
		blnDSM = DSM.UseDSM & (DSM.Mcrlyn > 0f);
		Strength.MynQual = CheckLimits (Spec, blnDSM, 0f, 0f, -1f);
		if (DSM.UseDSM & (DSM.Vcry > 0f)) {
			Strength.VyQual = true;
			if (DSM.Mcrlxp > 0f) {
				Strength.VyQual &= Strength.MxpQual;
			} else {
				Strength.VyQual &= CheckLimits (Spec, blnDSM: true, 0f, 1f, 0f);
			}
			if (DSM.Mcrlxn > 0f) {
				Strength.VyQual &= Strength.MxnQual;
			} else {
				Strength.VyQual &= CheckLimits (Spec, blnDSM: true, 0f, -1f, 0f);
			}
		}
		if (DSM.UseDSM & (DSM.Vcrx > 0f)) {
			Strength.VxQual = true;
			if (DSM.Mcrlyp > 0f) {
				Strength.VxQual &= Strength.MypQual;
			} else {
				Strength.VxQual &= CheckLimits (Spec, blnDSM: true, 0f, 0f, 1f);
			}
			if (DSM.Mcrlyn > 0f) {
				Strength.VxQual &= Strength.MynQual;
			} else {
				Strength.VxQual &= CheckLimits (Spec, blnDSM: true, 0f, 0f, -1f);
			}
		}
		CFS.strTrace += "Axial Tension Strength\r\n";
		float num11 = Conversions.ToSingle (Interaction.IIf (flag, 1.8, 1.67));
		float num12 = 0.9f;
		if (!Strength.Qual) {
			num11 = (float)CFS.Max (num11, num9);
			num12 = (float)CFS.Min (num12, num10);
		}
		float num13 = Stress.Fyat * Prop.A;
		Strength.Tn = num13;
		Strength.Ta = num13 / num11;
		Strength.QTn = num12 * num13;
		CFS.strTrace = CFS.strTrace + "  Ag=" + Units.DisplayLen2 (Prop.A, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (Stress.Fyat, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		CFS.strTrace = CFS.strTrace + "  Tn=" + Units.DisplayForce (num13, 0, blnShowUnit: true, "", 0, 0) + "\t" + text7 + "\r\n";
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωt=" + Conversions.ToString (num11) + ", φt=" + Conversions.ToString (num12), Interaction.IIf (num11 == num9 && num12 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		num11 = Conversions.ToSingle (Interaction.IIf (flag, 2.15, 2));
		num12 = 0.75f;
		if (!Strength.Qual) {
			num11 = (float)CFS.Max (num11, num9);
			num12 = (float)CFS.Min (num12, num10);
		}
		num13 = num8 * Prop.An;
		if (num13 < Strength.Tn) {
			Strength.Tn = num13;
		}
		if (num13 / num11 < Strength.Ta) {
			Strength.Ta = num13 / num11;
		}
		if (num12 * num13 < Strength.QTn) {
			Strength.QTn = num12 * num13;
		}
		CFS.strTrace = CFS.strTrace + "  An=" + Units.DisplayLen2 (Prop.An, 0, blnShowUnit: true, "", 0, 0) + ", Fu=" + Units.DisplayStress (num8, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		CFS.strTrace = CFS.strTrace + "  Tn=" + Units.DisplayForce (num13, 0, blnShowUnit: true, "", 0, 0) + "\t" + text8 + "\r\n";
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωt=" + Conversions.ToString (num11) + ", φt=" + Conversions.ToString (num12), Interaction.IIf (num11 == num9 && num12 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		float num18;
		float num19;
		float num24;
		float fyaxpn;
		float num25;
		float num20;
		float num21;
		if (IsCylinder ()) {
			float thickness = Part [1].Thickness;
			float num14 = 2f * (Part [1].Element [1].Rad + thickness);
			float num15 = Prop.Avx * num6;
			effectiveProperties.ResetProp (this, 0);
			float num16;
			float num17;
			if (flag) {
				num16 = 1.8f;
				num17 = 0.9f;
				num18 = 1.9f;
				num19 = 0.85f;
				num20 = 1.7f;
				num21 = 0.95f;
				if ((double)(num14 / thickness) > 0.88101 * (double)num / (double)Stress.Fyacn) {
					Strength.Msg += "D/t exceeds 0.881E/Fy.\r\n";
					num16 = num9;
					num17 = num10;
					num18 = num9;
					num19 = num10;
					num20 = num9;
					num21 = num10;
				}
				CFS.strTrace += "Shear Strength\r\n";
				CFS.strTrace = CFS.strTrace + "  Av=" + Units.DisplayLen2 (Prop.Avx, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (num6, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Vn=" + Units.DisplayForce (num15, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωv=" + Conversions.ToString (num16) + ", φv=" + Conversions.ToString (num17), Interaction.IIf (num16 == num9 && num17 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
				float num22 = Material.FprFy (2);
				float num23 = (float)(((double)((1f - num22) * (num / Stress.Fyacn) / (num14 / thickness)) + 5.882 * (double)num22) / (8.93 - 3.048 * (double)num22));
				if (num23 > 1f) {
					num23 = 1f;
				}
				PropEff.A = num23 * Prop.A;
				num24 = Stress.Fyacn * PropEff.A;
				Strength.Pno = num24;
				CFS.strTrace += "Axial Compression Strength\r\n";
				CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (Stress.Fyacn, 0, blnShowUnit: true, "", 0, 0) + ", C=" + Units.DisplayNone (num22, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Kc=" + Units.DisplayNone (num23, "", 0, 0) + "\t" + text17 + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Ae=Ao=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Pn=" + Units.DisplayForce (num24, 0, blnShowUnit: true, "", 0, 0) + "\t" + text18 + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωc=" + Conversions.ToString (num18) + ", φc=" + Conversions.ToString (num19), Interaction.IIf (num18 == num9 && num19 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
				fyaxpn = Stress.Fyaxpn;
				num22 = Material.FprFy (2);
				num23 = (float)(((double)((1f - num22) * (num / fyaxpn) / (num14 / thickness)) + 5.882 * (double)num22) / (8.93 - 3.048 * (double)num22));
				if (num23 < 1f) {
					text14 = text16;
				} else {
					num23 = 1f;
					text14 = text15;
				}
				num25 = num23 * fyaxpn * PropEff.Sx;
				if ((num23 == 1f) & Reserve) {
					float num26 = (float)(0.328 * (double)num * (double)thickness / (double)num14);
					float num27 = (float)(0.121 / System.Math.Pow (num5 / num26, 1.25));
					float num28 = (float)(0.1 * (double)(1f - num5 / num8) * (double)num / (double)num5);
					if (Material.IsFerritic ()) {
						num28 = (float)(0.24 * (double)(1f - num5 / num8) * (double)num / (double)num5);
					}
					num27 = (float)CFS.Min (num27, num28, 15.0);
					if (num27 > 1f) {
						num25 = (float)((double)num5 * ((double)Prop.Sx + (1.0 - 1.0 / System.Math.Pow (num27, 2.0)) * (double)(Prop.Zx - Prop.Sx)));
						text14 = text2;
					}
				}
				CFS.strTrace += "Flexural Strength\r\n";
				CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Sf=" + Units.DisplayLen3 (PropEff.Sx, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Mn=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text14 + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
			} else {
				num16 = 1.6f;
				num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.8, 0.95));
				if (CFS.IsSpec1999 (Spec)) {
					num16 = 1.5f;
					num17 = 1f;
				}
				num18 = 1.8f;
				num19 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.8, 0.85));
				num20 = 1.67f;
				num21 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.9, 0.95));
				if ((double)(num14 / thickness) > 0.44101 * (double)num / (double)Stress.Fyacn) {
					Strength.Msg += "D/t exceeds 0.441E/Fy.\r\n";
					num16 = num9;
					num17 = num10;
					num18 = num9;
					num19 = num10;
					num20 = num9;
					num21 = num10;
				}
				CFS.strTrace += "Shear Strength\r\n";
				CFS.strTrace = CFS.strTrace + "  Av=" + Units.DisplayLen2 (Prop.Avx, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (num6, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Vn=" + Units.DisplayForce (num15, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωv=" + Conversions.ToString (num16) + ", φv=" + Conversions.ToString (num17), Interaction.IIf (num16 == num9 && num17 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
				float num23 = (float)(0.037 * (double)(num / Stress.Fyacn) / (double)(num14 / thickness) + 0.667);
				if (num23 > 1f) {
					num23 = 1f;
				}
				PropEff.A = num23 * Prop.A;
				num24 = Stress.Fyacn * PropEff.A;
				Strength.Pno = num24;
				CFS.strTrace += "Axial Compression Strength\r\n";
				CFS.strTrace = CFS.strTrace + "  Fn=" + Units.DisplayStress (Stress.Fyacn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Kc=" + Units.DisplayNone (num23, "", 0, 0) + "\t" + text17 + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Ae=Ao=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Pn=" + Units.DisplayForce (num24, 0, blnShowUnit: true, "", 0, 0) + "\t" + text18 + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωc=" + Conversions.ToString (num18) + ", φc=" + Conversions.ToString (num19), Interaction.IIf (num18 == num9 && num19 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
				fyaxpn = Stress.Fyaxpn;
				string text27;
				if (CFS.SpecYear (Spec) < 2022) {
					if ((double)(num14 / thickness) <= 1.0 / 14.0 * (double)num / (double)fyaxpn) {
						num23 = 1.25f;
						text27 = text15;
					} else if ((double)(num14 / thickness) <= 154.0 / 485.0 * (double)num / (double)fyaxpn) {
						num23 = (float)(0.02 * (double)(num / fyaxpn) / (double)(num14 / thickness) + 0.97);
						text27 = text16;
					} else {
						num23 = (float)(0.328 * (double)(num / fyaxpn) / (double)(num14 / thickness));
						text27 = text17;
					}
					num25 = num23 * fyaxpn * PropEff.Sx;
				} else {
					float num29 = (float)(1.25 * (double)Prop.Sx * (double)fyaxpn);
					float num30 = (float)(0.656 * (double)thickness * (double)num * (double)Prop.I1 / System.Math.Pow (num14, 2.0));
					if ((double)num30 >= 3.67 * (double)num29) {
						num25 = num29;
						text27 = text15;
					} else if ((double)num30 >= 0.826 * (double)num29) {
						num25 = (float)(0.776 * (double)num29 + 0.061 * (double)num30);
						text27 = text16;
					} else {
						num25 = num30;
						text27 = text17;
					}
				}
				CFS.strTrace += "Flexural Strength\r\n";
				if (CFS.IsSpec1999 (Spec)) {
					CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (Stress.Fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "  Mn=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text27 + "\r\n";
				} else if (CFS.SpecYear (Spec) < 2022) {
					CFS.strTrace = CFS.strTrace + "  " + text26 + "=" + Units.DisplayStress (num23 * Stress.Fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\t" + text27 + "\r\n";
					CFS.strTrace = CFS.strTrace + "  Mn=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text14 + "\r\n";
				} else {
					CFS.strTrace = CFS.strTrace + "  Mn=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text27 + "\r\n";
				}
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
			}
			Strength.Vax = num15 / num16;
			Strength.QVnx = num17 * num15;
			Strength.Vay = num15 / num16;
			Strength.QVny = num17 * num15;
			Strength.Pao = num24 / num18;
			Strength.QPno = num19 * num24;
			Strength.Ae = PropEff.A;
			Strength.Maxop = num25 / num20;
			Strength.QMnxop = num21 * num25;
			Strength.Ixep = PropEff.Ix;
			Strength.Sxtep = PropEff.Sxt;
			Strength.Sxbep = PropEff.Sxb;
			Strength.Maxon = num25 / num20;
			Strength.QMnxon = num21 * num25;
			Strength.Ixen = PropEff.Ix;
			Strength.Sxten = PropEff.Sxt;
			Strength.Sxben = PropEff.Sxb;
			Strength.Mayop = num25 / num20;
			Strength.QMnyop = num21 * num25;
			Strength.Iyep = PropEff.Iy;
			Strength.Sylep = PropEff.Syl;
			Strength.Syrep = PropEff.Syr;
			Strength.Mayon = num25 / num20;
			Strength.QMnyon = num21 * num25;
			Strength.Iyen = PropEff.Iy;
			Strength.Sylen = PropEff.Syl;
			Strength.Syren = PropEff.Syr;
			Strength.Mnxop = num25;
			Strength.Mnxon = num25;
			Strength.Mnyop = num25;
			Strength.Mnyon = num25;
			num25 = Stress.Fyaxpn * PropEff.Sx;
			Strength.Maxtop = num25 / num20;
			Strength.QMnxtop = num21 * num25;
			Strength.Maxton = num25 / num20;
			Strength.QMnxton = num21 * num25;
			Strength.Maytop = num25 / num20;
			Strength.QMnytop = num21 * num25;
			Strength.Mayton = num25 / num20;
			Strength.QMnyton = num21 * num25;
			Strength.Ba = 0f;
			Strength.QBn = 0f;
			return;
		}
		CFS.strTrace += "Shear Strength\r\n";
		if (Prop.Avy < Prop.A / 1000f) {
			Strength.Msg += "Section contains no web elements for vertical shear.\r\n";
		}
		if (Prop.Avx < Prop.A / 1000f) {
			Strength.Msg += "Section contains no web elements for horizontal shear.\r\n";
		}
		float num31 = 5.34f;
		Strength.Vax = 0f;
		Strength.Vay = 0f;
		Strength.QVnx = 0f;
		Strength.QVny = 0f;
		if (!((CFS.SpecYear (Spec) >= 2016 || flag) & DSM.UseDSM & (DSM.Vcry > 0f) & (DSM.Vcrx > 0f))) {
			short num32 = nPart;
			checked {
				float num43 = default(float);
				for (short num33 = 1; num33 <= num32; num33 = (short)unchecked(num33 + 1)) {
					float thickness = Part [num33].Thickness;
					short nElem = Part [num33].nElem;
					for (short num34 = 1; num34 <= nElem; num34 = (short)unchecked(num34 + 1)) {
						ref Element reference = ref Part [num33].Element [num34];
						float wid = reference.Wid;
						float ang = reference.Ang;
						float num14 = reference.Hole;
						if (Part [num33].Element [num34].Web != 1) {
							CFS.strTrace = CFS.strTrace + "  " + Part [num33].Name + " element " + Conversions.ToString (unchecked((int)num34)) + "\r\n";
							float num35 = num6 * wid * thickness;
							float num36 = (float)(9.869604401089358 * (double)num * (double)num31 * (double)thickness * (double)thickness * (double)thickness / (10.92 * (double)wid));
							float num37 = (float)System.Math.Sqrt (num35 / num36);
							float num16;
							float num17;
							float num15;
							string text28;
							if (flag) {
								num16 = 1.8f;
								num17 = 0.9f;
								if ((double)num37 <= 0.53) {
									num15 = num35;
									text28 = text9;
								} else if ((double)num37 <= 0.79) {
									num15 = (float)(1.0 - 0.761 * ((double)num37 - 0.53) * (double)num35);
									text28 = text10;
								} else if ((double)num37 <= 2.184) {
									num15 = (float)((5.02 - 1.227 * (double)num37) / (1.62 + 4.357 * (double)num37) * (double)num35);
									text28 = text11;
								} else {
									num15 = num36;
									text28 = text3;
								}
							} else if (CFS.IsSpec1999 (Spec)) {
								if ((double)(wid / thickness) <= 0.96 * System.Math.Sqrt ((double)(num * num31) * 0.6 / (double)num6)) {
									num15 = num35;
									num16 = 1.5f;
									num17 = 1f;
									text28 = text9;
								} else if ((double)(wid / thickness) <= 1.415 * System.Math.Sqrt ((double)(num * num31) * 0.6 / (double)num6)) {
									num15 = (float)(0.64 * (double)thickness * (double)thickness * System.Math.Sqrt ((double)(num31 * num6) / 0.6 * (double)num));
									num16 = 1.67f;
									num17 = 0.9f;
									text28 = text10;
								} else {
									num15 = num36;
									num16 = 1.67f;
									num17 = 0.9f;
									text28 = text11;
								}
							} else if (CFS.SpecYear (Spec) < 2022) {
								num16 = 1.6f;
								num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.8, 0.95));
								if ((double)num37 <= 0.815) {
									num15 = num35;
									text28 = text9;
								} else if ((double)num37 <= 1.227) {
									num15 = (float)(0.815 * System.Math.Sqrt (num36 * num35));
									text28 = text10;
								} else {
									num15 = num36;
									text28 = text11;
								}
							} else {
								num16 = 1.67f;
								num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.75, 0.9));
								if (((double)num14 > 0.5625) | ((double)(num14 / wid) > 0.7)) {
									float num38 = (float)(-0.173 - 0.925 * (double)HoleLength / (double)num14 + 0.0524 * System.Math.Pow (HoleLength / num14, 2.0));
									float num39 = (float)(-3.41 + 1.99 * (double)HoleLength / (double)num14 - 0.0995 * System.Math.Pow (HoleLength / num14, 2.0));
									float num40 = (float)(2.68 - 1.08 * (double)HoleLength / (double)num14 + 0.0466 * System.Math.Pow (HoleLength / num14, 2.0));
									if ((double)(num14 / wid) > 0.1) {
										num35 = (float)((double)num35 * (1.0 + (double)num38 * ((double)(num14 / wid) - 0.1) + (double)num39 * System.Math.Pow ((double)(num14 / wid) - 0.1, 2.0) + (double)num40 * System.Math.Pow ((double)(num14 / wid) - 0.1, 3.0)));
									}
									CFS.strTrace = CFS.strTrace + "    Vyh=" + Units.DisplayForce (num35, 0, blnShowUnit: true, "", 0, 0) + "\t" + text4 + "\r\n";
									float num41 = 2f * HoleSpacing;
									short num42 = Conversions.ToShort (Interaction.IIf (num34 > 1, num34 - 1, 0));
									if ((num34 == 1) & Part [num33].Closed) {
										num42 = Part [num33].nElem;
									}
									if (num42 > 0) {
										num43 = Part [num33].Element [num42].Len;
									}
									num42 = Conversions.ToShort (Interaction.IIf (num34 < Part [num33].nElem, num34 + 1, 0));
									if ((num34 == Part [num33].nElem) & Part [num33].Closed) {
										num42 = 1;
									}
									if (num42 > 0) {
										num43 = (float)CFS.Min (num43, Part [num33].Element [num42].Len);
									}
									float num44 = (float)(4.86 + 6.15 * (double)wid / (double)num41 - 3.63 * (double)num14 / (double)wid - 19.6 * (double)num14 / (double)num41 + 13.9 * System.Math.Pow (num14, 2.0) / (double)(wid * num41) + 0.57 * (double)num43 / (double)wid);
									CFS.strTrace = CFS.strTrace + "    kv=" + Units.DisplayNone (num44, "", 0, 0) + "\t" + text6 + "\r\n";
									num36 = (float)((double)(float)System.Math.Pow (CFS.Min (CFS.Max (1.0 - 0.4 * (double)(HoleLength - num14) / (double)wid, 0.0), 1.0), 2.0) * (9.869604401089358 * (double)num * (double)num44 * (double)thickness * (double)thickness * (double)thickness / (10.92 * (double)wid)));
									CFS.strTrace = CFS.strTrace + "    Vcrh=" + Units.DisplayForce (num36, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
									num37 = (float)System.Math.Sqrt (num35 / num36);
								}
								if ((double)num37 <= 0.587) {
									num15 = num35;
									text28 = text9;
								} else {
									num15 = (float)((1.0 - 0.25 * System.Math.Pow (num36 / num35, 0.65)) * System.Math.Pow (num36 / num35, 0.65) * (double)num35);
									text28 = text10;
								}
							}
							if ((flag | (CFS.SpecYear (Spec) < 2022)) & (((double)num14 > 0.5625) | ((double)(num14 / wid) > 0.7))) {
								float num45 = (wid / 2f - num14 / 2f) / (54f * thickness);
								if (num45 > 1f) {
									num45 = 1f;
								}
								num15 *= num45;
								CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    qs=" + Units.DisplayNone (num45, "", 0, 0) + "\t", Interaction.IIf (num45 == 1f, truePart, falsePart)), "\r\n")));
							}
							if (!Strength.Qual) {
								num16 = num9;
								num17 = num10;
							}
							unchecked {
								if (wid / thickness > 200f) {
									string text29 = Part [num33].Name + " element " + Conversions.ToString ((int)num34) + " h/t exceeds 200.";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg = ref Strength.Msg;
										msg = msg + text29 + "\r\n";
									}
									CFS.strTrace += "    h/t exceeds 200 (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								}
								float num46 = 0.7f;
								if (Material.IsCarbon () & (CFS.SpecYear (Spec) >= 2022)) {
									num46 = 0.8f;
								}
								if (num14 / wid > num46) {
									string text29 = Part [num33].Name + " element " + Conversions.ToString ((int)num34) + " dh/h exceeds " + Conversions.ToString (num46) + ".";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg2 = ref Strength.Msg;
										msg2 = msg2 + text29 + "\r\n";
									}
									CFS.strTrace = CFS.strTrace + "    dh/h exceeds " + Conversions.ToString (num46) + " (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								}
								if (flag | (CFS.SpecYear (Spec) < 2022)) {
									num46 = Conversions.ToSingle (Interaction.IIf (num14 == HoleLength, 6, 2.5));
									if (num14 > num46) {
										string text29 = "Hole depth greater than " + Units.DisplayLen1 (num46, 0, blnShowUnit: true, "", 0, 0) + ".";
										if (Strings.InStr (Strength.Msg, text29) == 0) {
											ref string msg3 = ref Strength.Msg;
											msg3 = msg3 + text29 + "\r\n";
										}
										CFS.strTrace = CFS.strTrace + "    Hole size greater than " + Units.DisplayLen1 (num46, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
										num16 = num9;
										num17 = num10;
									}
									if (((double)num14 > 0.5625) & (num14 != HoleLength) & ((double)HoleLength > 4.5)) {
										string text29 = "Hole length greater than " + Units.DisplayLen1 (4.5f, 0, blnShowUnit: true, "", 0, 0) + ".";
										if (Strings.InStr (Strength.Msg, text29) == 0) {
											ref string msg4 = ref Strength.Msg;
											msg4 = msg4 + text29 + "\r\n";
										}
										CFS.strTrace = CFS.strTrace + "    Hole length greater than " + Units.DisplayLen1 (4.5f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
										num16 = num9;
										num17 = num10;
									}
								} else if (((double)num14 > 0.5625) & (HoleLength < num14)) {
									string text29 = Part [num33].Name + " element " + Conversions.ToString ((int)num34) + " Lh/dh less than 1.";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg5 = ref Strength.Msg;
										msg5 = msg5 + text29 + "\r\n";
									}
									CFS.strTrace += "    Lh/dh less than 1 (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								} else if (((double)num14 > 0.5625) & (HoleLength > 3f * num14)) {
									string text29 = Part [num33].Name + " element " + Conversions.ToString ((int)num34) + " Lh/dh exceeds 3.";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg6 = ref Strength.Msg;
										msg6 = msg6 + text29 + "\r\n";
									}
									CFS.strTrace += "    Lh/dh exceeds 3 (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								}
								if (((double)num14 > 0.5625) & (HoleSpacing - HoleLength < 18f)) {
									string text29 = "Clear distance between holes less than " + Units.DisplayLen1 (18f, 0, blnShowUnit: true, "", 0, 0) + ".";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg7 = ref Strength.Msg;
										msg7 = msg7 + text29 + "\r\n";
									}
									CFS.strTrace = CFS.strTrace + "    Clear distance between holes less than " + Units.DisplayLen1 (18f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								}
								if (((double)num14 > 0.5625) & (System.Math.Abs ((double)(Part [num33].Element [num34].Dist / Part [num33].Element [num34].Len) - 0.5) > 0.02)) {
									string text29 = Part [num33].Name + " element " + Conversions.ToString ((int)num34) + " hole not at mid-depth.";
									if (Strings.InStr (Strength.Msg, text29) == 0) {
										ref string msg8 = ref Strength.Msg;
										msg8 = msg8 + text29 + "\r\n";
									}
									CFS.strTrace += "    Hole not at mid-depth (rational analysis)\r\n";
									num16 = num9;
									num17 = num10;
								}
								CFS.strTrace = CFS.strTrace + "    Vn=" + Units.DisplayForce (num15, 0, blnShowUnit: true, "", 0, 0) + " at " + Units.DisplayAngle (ang, 0, blnShowUnit: true, "", 0, 0) + "\t" + text28 + "\r\n";
								CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωv=" + Conversions.ToString (num16) + ", φv=" + Conversions.ToString (num17), Interaction.IIf (num16 == num9 && num17 == num10, " (rational analysis)", "")), "\r\n")));
								ref float vax = ref Strength.Vax;
								vax = (float)((double)vax + (double)(num15 / num16) * System.Math.Abs (System.Math.Cos (ang)));
								ref float qVnx = ref Strength.QVnx;
								qVnx = (float)((double)qVnx + (double)(num17 * num15) * System.Math.Abs (System.Math.Cos (ang)));
								ref float vay = ref Strength.Vay;
								vay = (float)((double)vay + (double)(num15 / num16) * System.Math.Abs (System.Math.Sin (ang)));
								ref float qVny = ref Strength.QVny;
								qVny = (float)((double)qVny + (double)(num17 * num15) * System.Math.Abs (System.Math.Sin (ang)));
							}
						}
					}
				}
				CFS.strTrace += "\r\n";
			}
		}
		if ((CFS.SpecYear (Spec) >= 2016 || flag) & DSM.UseDSM & (DSM.Vcry > 0f)) {
			CFS.strTrace += "  Vertical Shear - Direct Strength Method\r\n";
			float num35 = Prop.Avy * num6;
			float num36 = DSM.Vcry * Prop.Avy * num7;
			CFS.strTrace = CFS.strTrace + "    Aw=" + Units.DisplayLen2 (Prop.Avy, 0, blnShowUnit: true, "", 0, 0) + ", Vy=" + Units.DisplayForce (num35, 0, blnShowUnit: true, "", 0, 0) + ", Vcr=" + Units.DisplayForce (num36, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			float num37 = ((!(num36 > 0f)) ? 0f : ((float)System.Math.Sqrt (num35 / num36)));
			float num16;
			float num17;
			float num15;
			string text28;
			if (flag) {
				num16 = 1.8f;
				num17 = 0.9f;
				if ((double)num37 <= 0.53) {
					num15 = num35;
					text28 = text9;
				} else if ((double)num37 <= 0.79) {
					num15 = (float)(1.0 - 0.761 * ((double)num37 - 0.53) * (double)num35);
					text28 = text10;
				} else if ((double)num37 <= 2.184) {
					num15 = (float)((5.02 - 1.227 * (double)num37) / (1.62 + 4.357 * (double)num37) * (double)num35);
					text28 = text11;
				} else {
					num15 = num36;
					text28 = text3;
				}
			} else if (CFS.SpecYear (Spec) < 2022) {
				num16 = 1.6f;
				num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.8, 0.95));
				if ((double)num37 <= 0.815) {
					num15 = num35;
					text28 = text9;
				} else if ((double)num37 <= 1.227) {
					num15 = (float)(0.815 * System.Math.Sqrt (num36 * num35));
					text28 = text10;
				} else {
					num15 = num36;
					text28 = text11;
				}
			} else {
				num16 = 1.67f;
				num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.75, 0.9));
				if ((double)num37 <= 0.587) {
					num15 = num35;
					text28 = text9;
				} else {
					num15 = (float)((1.0 - 0.25 * System.Math.Pow (num36 / num35, 0.65)) * System.Math.Pow (num36 / num35, 0.65) * (double)num35);
					text28 = text10;
				}
			}
			if (!Strength.VyQual) {
				num16 = num9;
				num17 = num10;
			}
			Strength.Vay = num15 / num16;
			Strength.QVny = num17 * num15;
			CFS.strTrace = CFS.strTrace + "    Vn=" + Units.DisplayForce (num15, 0, blnShowUnit: true, "", 0, 0) + "\t" + text28 + "\r\n";
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωv=" + Conversions.ToString (num16) + ", φv=" + Conversions.ToString (num17), Interaction.IIf (num16 == num9 && num17 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		}
		if ((CFS.SpecYear (Spec) >= 2016 || flag) & DSM.UseDSM & (DSM.Vcrx > 0f)) {
			CFS.strTrace += "  Horizontal Shear - Direct Strength Method\r\n";
			float num35 = Prop.Avx * num6;
			float num36 = DSM.Vcrx * Prop.Avx * num7;
			CFS.strTrace = CFS.strTrace + "    Aw=" + Units.DisplayLen2 (Prop.Avx, 0, blnShowUnit: true, "", 0, 0) + ", Vy=" + Units.DisplayForce (num35, 0, blnShowUnit: true, "", 0, 0) + ", Vcr=" + Units.DisplayForce (num36, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			float num37 = ((!(num36 > 0f)) ? 0f : ((float)System.Math.Sqrt (num35 / num36)));
			float num16;
			float num17;
			float num15;
			string text28;
			if (flag) {
				num16 = 1.8f;
				num17 = 0.9f;
				if ((double)num37 <= 0.53) {
					num15 = num35;
					text28 = text9;
				} else if ((double)num37 <= 0.79) {
					num15 = (float)(1.0 - 0.761 * ((double)num37 - 0.53) * (double)num35);
					text28 = text10;
				} else if ((double)num37 <= 2.184) {
					num15 = (float)((5.02 - 1.227 * (double)num37) / (1.62 + 4.357 * (double)num37) * (double)num35);
					text28 = text11;
				} else {
					num15 = num36;
					text28 = text3;
				}
			} else if (CFS.SpecYear (Spec) < 2022) {
				num16 = 1.6f;
				num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.8, 0.95));
				if ((double)num37 <= 0.815) {
					num15 = num35;
					text28 = text9;
				} else if ((double)num37 <= 1.227) {
					num15 = (float)(0.815 * System.Math.Sqrt (num36 * num35));
					text28 = text10;
				} else {
					num15 = num36;
					text28 = text11;
				}
			} else {
				num16 = 1.67f;
				num17 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecLSD (Spec), 0.75, 0.9));
				if ((double)num37 <= 0.587) {
					num15 = num35;
					text28 = text9;
				} else {
					num15 = (float)((1.0 - 0.25 * System.Math.Pow (num36 / num35, 0.65)) * System.Math.Pow (num36 / num35, 0.65) * (double)num35);
					text28 = text10;
				}
			}
			if (!Strength.VxQual) {
				num16 = num9;
				num17 = num10;
			}
			Strength.Vax = num15 / num16;
			Strength.QVnx = num17 * num15;
			CFS.strTrace = CFS.strTrace + "    Vn=" + Units.DisplayForce (num15, 0, blnShowUnit: true, "", 0, 0) + "\t" + text28 + "\r\n";
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωv=" + Conversions.ToString (num16) + ", φv=" + Conversions.ToString (num17), Interaction.IIf (num16 == num9 && num17 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		}
		float num47;
		float num48;
		float num49;
		float num50;
		float num51;
		float num52;
		float num53;
		float num54;
		if (flag) {
			num18 = 1.8f;
			num19 = 0.9f;
			num47 = 1.8f;
			num48 = 0.9f;
			num49 = 0.9f;
			num50 = 0.9f;
			num51 = 0.9f;
			num52 = 0.9f;
			num53 = 1.8f;
			num54 = 0.9f;
		} else if (CFS.IsSpecLSD (Spec)) {
			num18 = 1.8f;
			num19 = 0.8f;
			num47 = 1.67f;
			num48 = 0.9f;
			if (CFS.SpecYear (Spec) < 2016) {
				num48 = 0.85f;
			}
			num49 = 0.9f;
			num50 = 0.9f;
			num51 = 0.9f;
			num52 = 0.9f;
			num53 = 1.67f;
			num54 = 0.9f;
		} else {
			num18 = 1.8f;
			num19 = 0.85f;
			num47 = 1.67f;
			num48 = 0.9f;
			num49 = 0.9f;
			num50 = 0.9f;
			num51 = 0.9f;
			num52 = 0.9f;
			if (CFS.SpecYear (Spec) < 2010) {
				if (!IsUnstiffened (LoadDirections.dirY, 1, blnGrossSct: false)) {
					num49 = 0.95f;
				}
				if (!IsUnstiffened (LoadDirections.dirY, -1, blnGrossSct: false)) {
					num50 = 0.95f;
				}
				if (!IsUnstiffened (LoadDirections.dirX, 1, blnGrossSct: false)) {
					num51 = 0.95f;
				}
				if (!IsUnstiffened (LoadDirections.dirX, -1, blnGrossSct: false)) {
					num52 = 0.95f;
				}
			}
			num53 = 1.67f;
			num54 = 0.9f;
		}
		fyaxpn = Stress.Fyacn;
		CFS.strTrace += "Axial Compression Strength\r\n";
		string text30;
		if (DSM.UseDSM & (DSM.Pcrl > 0f)) {
			float num55 = Prop.A * fyaxpn;
			float num56 = DSM.Pcrl * Prop.A * num2;
			float num37 = (float)System.Math.Sqrt (num55 / num56);
			if (flag) {
				if ((double)num37 <= 0.55) {
					num24 = num55;
					text30 = text20;
				} else {
					num24 = (float)((0.95 - 0.22 * System.Math.Pow (num56 / num55, 0.5)) * System.Math.Pow (num56 / num55, 0.5) * (double)num55);
					text30 = text21;
				}
			} else if ((double)num37 <= 0.776) {
				num24 = num55;
				text30 = text20;
			} else {
				num24 = (float)((1.0 - 0.15 * System.Math.Pow (num56 / num55, 0.4)) * System.Math.Pow (num56 / num55, 0.4) * (double)num55);
				text30 = text21;
			}
			float num57 = Prop.An * fyaxpn;
			if (num24 > num57) {
				num24 = num57;
				text30 = text22;
			}
			PropEff.A = num24 / fyaxpn;
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  Pne=" + Units.DisplayForce (num55, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (num57 < num55, ", Pynet=" + Units.DisplayForce (num57, 0, blnShowUnit: true, "", 0, 0), "")), "\r\n")));
			CFS.strTrace = CFS.strTrace + "  Pcrl=" + Units.DisplayForce (num56, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		} else {
			effectiveProperties.ResetProp (this, 0);
			effectiveProperties.EffProp (this, PropEff.A * fyaxpn, 0f, 0f, 0, Spec);
			Strength.Msg += PropEff.Msg;
			if (CFS.blnTraceEffProp) {
				CFS.strTrace += PropEff.Trace;
			}
			num24 = PropEff.A * fyaxpn;
			text30 = text12;
			if (PropEff.RationalAnalysis) {
				num18 = num9;
				num19 = num10;
			}
			CFS.strTrace = CFS.strTrace + "  Ae=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + ", Fn=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		}
		if (!Strength.PQual) {
			num18 = num9;
			num19 = num10;
		}
		Strength.Pno = num24;
		Strength.Pao = num24 / num18;
		Strength.QPno = num19 * num24;
		Strength.Ae = PropEff.A;
		CFS.strTrace = CFS.strTrace + "  Pn=" + Units.DisplayForce (num24, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωc=" + Conversions.ToString (num18) + ", φc=" + Conversions.ToString (num19), Interaction.IIf (num18 == num9 && num19 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		fyaxpn = Stress.Fyaxpn;
		num20 = num47;
		num21 = num49;
		CFS.strTrace += "Positive Flexural Strength about X-axis\r\n";
		string text31;
		if (DSM.UseDSM & (DSM.Mcrlxp > 0f)) {
			num21 = num48;
			float num58 = Prop.Sx * fyaxpn;
			float num59 = Prop.Sxn * fyaxpn;
			float num60 = DSM.Mcrlxp * Prop.Sx * num2;
			float num37 = (float)System.Math.Sqrt (num58 / num60);
			if (flag) {
				if ((double)num37 <= 0.667) {
					num25 = num58;
					text31 = text23;
				} else {
					num25 = (float)((1.0 - 0.2 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
					text31 = text24;
				}
			} else if ((double)num37 <= 0.776) {
				num25 = num58;
				text31 = text23;
			} else {
				num25 = (float)((1.0 - 0.15 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
				text31 = text24;
			}
			if (num25 > num59) {
				num25 = num59;
				text31 = text25;
			}
			PropEff.Sx = num25 / fyaxpn;
			PropEff.Ix = Prop.Ix * PropEff.Sx / Prop.Sx;
			PropEff.Sxt = Prop.Sxt * PropEff.Sx / Prop.Sx;
			PropEff.Sxb = Prop.Sxb * PropEff.Sx / Prop.Sx;
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  My=" + Units.DisplayMoment (num58, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (num59 < num58, ", Mynet=" + Units.DisplayMoment (num59, 0, blnShowUnit: true, "", 0, 0), "")), "\r\n")));
			CFS.strTrace = CFS.strTrace + "  Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + "\r\n";
			if ((num25 == num59) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				num37 = (float)System.Math.Sqrt (Prop.Sx * num5 / num60);
				float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
				if (num61 > 9f) {
					num61 = 9f;
				}
				float num62 = (Prop.Sxn + (1f - 1f / num61) * (Prop.Zxn - Prop.Sxn)) * num5;
				if (num62 > num25) {
					num25 = num62;
					text31 = text2;
					CFS.strTrace = CFS.strTrace + "  Mp=" + Units.DisplayMoment (Prop.Zxn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
				}
			}
		} else {
			effectiveProperties.ResetProp (this, 0);
			short num63 = 1;
			checked {
				do {
					float sx = PropEff.Sx;
					effectiveProperties.EffProp (this, 0f, PropEff.Sx * fyaxpn, 0f, 0, Spec);
					if (!PropEff.Iterate || System.Math.Abs (PropEff.Sx / sx - 1f) < 0.001f) {
						break;
					}
					num63 = (short)unchecked(num63 + 1);
				} while (num63 <= 10);
				num25 = PropEff.Sx * fyaxpn;
				if (CFS.blnTraceEffProp) {
					CFS.strTrace += PropEff.Trace;
				}
				CFS.strTrace = CFS.strTrace + "  Center of gravity shift: y=" + Units.DisplayLen1 (PropEff.Ycg - Prop.Ycgn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Sxe=" + Units.DisplayLen3 (PropEff.Sx, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				text31 = text13;
				if (PropEff.RationalAnalysis) {
					num20 = num9;
					num21 = num10;
				}
			}
			if ((PropEff.Ix == Prop.Ixn) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				EffectivePropertiesType propEff = PropEff;
				effectiveProperties.ResetProp (this, 0);
				effectiveProperties.EffProp (this, 0f, Prop.Sxtn * num5, 0f, 0, Spec);
				if (Operators.ConditionalCompareObjectLess (PropEff.LambdaMax, Interaction.IIf (flag, 0.667, 0.776), TextCompare: false)) {
					float num37 = PropEff.LambdaMax;
					float num60 = (float)((double)(Prop.Sxn * num5) / System.Math.Pow (num37, 2.0));
					float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
					if (num61 > 9f) {
						num61 = 9f;
					}
					float num62 = (Prop.Sxn + (1f - 1f / num61) * (Prop.Zxn - Prop.Sxn)) * num5;
					if (num62 > num25) {
						num25 = num62;
						text31 = text2;
						CFS.strTrace += "  Local inelastic reserve\r\n";
						CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (Prop.Sxn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zxn * num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
					}
				}
				PropEff = propEff;
			}
		}
		CFS.strTrace = CFS.strTrace + "  Mnl=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
		if (num25 > Prop.Zx * num5) {
			num25 = Prop.Zx * num5;
			CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
		}
		if (!Strength.MxpQual) {
			num20 = num9;
			num21 = num10;
		}
		Strength.Mnxop = num25;
		Strength.Maxop = num25 / num20;
		Strength.QMnxop = num21 * num25;
		Strength.Ixep = PropEff.Ix;
		Strength.Sxtep = PropEff.Sxt;
		Strength.Sxbep = PropEff.Sxb;
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		num25 = Conversions.ToSingle (Operators.MultiplyObject (Prop.Sxbn, Interaction.IIf (flag, num4, Stress.Fyaxpn)));
		Strength.Maxtop = num25 / num47;
		Strength.QMnxtop = num49 * num25;
		fyaxpn = Stress.Fyaxnn;
		num20 = num47;
		num21 = num50;
		CFS.strTrace += "Negative Flexural Strength about X-axis\r\n";
		if (DSM.UseDSM & (DSM.Mcrlxn > 0f)) {
			num21 = num48;
			float num58 = Prop.Sx * fyaxpn;
			float num59 = Prop.Sxn * fyaxpn;
			float num60 = DSM.Mcrlxn * Prop.Sx * num2;
			float num37 = (float)System.Math.Sqrt (num58 / num60);
			if (flag) {
				if ((double)num37 <= 0.667) {
					num25 = num58;
					text31 = text23;
				} else {
					num25 = (float)((1.0 - 0.2 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
					text31 = text24;
				}
			} else if ((double)num37 <= 0.776) {
				num25 = num58;
				text31 = text23;
			} else {
				num25 = (float)((1.0 - 0.15 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
				text31 = text24;
			}
			if (num25 > num59) {
				num25 = num59;
				text31 = text25;
			}
			PropEff.Sx = num25 / fyaxpn;
			PropEff.Ix = Prop.Ix * PropEff.Sx / Prop.Sx;
			PropEff.Sxt = Prop.Sxt * PropEff.Sx / Prop.Sx;
			PropEff.Sxb = Prop.Sxb * PropEff.Sx / Prop.Sx;
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  My=" + Units.DisplayMoment (num58, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (num59 < num58, ", Mynet=" + Units.DisplayMoment (num59, 0, blnShowUnit: true, "", 0, 0), "")), "\r\n")));
			CFS.strTrace = CFS.strTrace + "  Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + "\r\n";
			if ((num25 == num59) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				num37 = (float)System.Math.Sqrt (Prop.Sx * num5 / num60);
				float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
				if (num61 > 9f) {
					num61 = 9f;
				}
				float num62 = (Prop.Sxn + (1f - 1f / num61) * (Prop.Zxn - Prop.Sxn)) * num5;
				if (num62 > num25) {
					num25 = num62;
					text31 = text2;
					CFS.strTrace = CFS.strTrace + "  Mp=" + Units.DisplayMoment (Prop.Zxn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
				}
			}
		} else {
			effectiveProperties.ResetProp (this, 0);
			short num63 = 1;
			checked {
				do {
					float sx = PropEff.Sx;
					effectiveProperties.EffProp (this, 0f, (0f - PropEff.Sx) * fyaxpn, 0f, 0, Spec);
					if (!PropEff.Iterate || System.Math.Abs (PropEff.Sx / sx - 1f) < 0.001f) {
						break;
					}
					num63 = (short)unchecked(num63 + 1);
				} while (num63 <= 10);
				num25 = PropEff.Sx * fyaxpn;
				if (CFS.blnTraceEffProp) {
					CFS.strTrace += PropEff.Trace;
				}
				CFS.strTrace = CFS.strTrace + "  Center of gravity shift: y=" + Units.DisplayLen1 (PropEff.Ycg - Prop.Ycgn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Sxe=" + Units.DisplayLen3 (PropEff.Sx, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				text31 = text13;
				if (PropEff.RationalAnalysis) {
					num20 = num9;
					num21 = num10;
				}
			}
			if ((PropEff.Ix == Prop.Ixn) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				EffectivePropertiesType propEff = PropEff;
				effectiveProperties.ResetProp (this, 0);
				effectiveProperties.EffProp (this, 0f, (0f - Prop.Sxbn) * num5, 0f, 0, Spec);
				if (Operators.ConditionalCompareObjectLess (PropEff.LambdaMax, Interaction.IIf (flag, 0.667, 0.776), TextCompare: false)) {
					float num37 = PropEff.LambdaMax;
					float num60 = (float)((double)(Prop.Sxn * num5) / System.Math.Pow (num37, 2.0));
					float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
					if (num61 > 9f) {
						num61 = 9f;
					}
					float num62 = (Prop.Sxn + (1f - 1f / num61) * (Prop.Zxn - Prop.Sxn)) * num5;
					if (num62 > num25) {
						num25 = num62;
						text31 = text2;
						CFS.strTrace += "  Local inelastic reserve\r\n";
						CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (Prop.Sxn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zxn * num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
					}
				}
				PropEff = propEff;
			}
		}
		CFS.strTrace = CFS.strTrace + "  Mnl=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
		if (num25 > Prop.Zx * num5) {
			num25 = Prop.Zx * num5;
			CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
		}
		if (!Strength.MxnQual) {
			num20 = num9;
			num21 = num10;
		}
		Strength.Mnxon = num25;
		Strength.Maxon = num25 / num20;
		Strength.QMnxon = num21 * num25;
		Strength.Ixen = PropEff.Ix;
		Strength.Sxten = PropEff.Sxt;
		Strength.Sxben = PropEff.Sxb;
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		num25 = Conversions.ToSingle (Operators.MultiplyObject (Prop.Sxtn, Interaction.IIf (flag, num4, Stress.Fyaxnn)));
		Strength.Maxton = num25 / num47;
		Strength.QMnxton = num50 * num25;
		fyaxpn = Stress.Fyaypn;
		num20 = num47;
		num21 = num51;
		CFS.strTrace += "Positive Flexural Strength about Y-axis\r\n";
		if (DSM.UseDSM & (DSM.Mcrlyp > 0f)) {
			num21 = num48;
			float num58 = Prop.Sy * fyaxpn;
			float num59 = Prop.Syn * fyaxpn;
			float num60 = DSM.Mcrlyp * Prop.Sy * num2;
			float num37 = (float)System.Math.Sqrt (num58 / num60);
			if (flag) {
				if ((double)num37 <= 0.667) {
					num25 = num58;
					text31 = text23;
				} else {
					num25 = (float)((1.0 - 0.2 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
					text31 = text24;
				}
			} else if ((double)num37 <= 0.776) {
				num25 = num58;
				text31 = text23;
			} else {
				num25 = (float)((1.0 - 0.15 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
				text31 = text24;
			}
			if (num25 > num59) {
				num25 = num59;
				text31 = text25;
			}
			PropEff.Sy = num25 / fyaxpn;
			PropEff.Iy = Prop.Iy * PropEff.Sy / Prop.Sy;
			PropEff.Syr = Prop.Syr * PropEff.Sy / Prop.Sy;
			PropEff.Syl = Prop.Syl * PropEff.Sy / Prop.Sy;
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  My=" + Units.DisplayMoment (num58, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (num59 < num58, ", Mynet=" + Units.DisplayMoment (num59, 0, blnShowUnit: true, "", 0, 0), "")), "\r\n")));
			CFS.strTrace = CFS.strTrace + "  Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + "\r\n";
			if ((num25 == num59) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				num37 = (float)System.Math.Sqrt (Prop.Sy * num5 / num60);
				float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
				if (num61 > 9f) {
					num61 = 9f;
				}
				float num62 = (Prop.Syn + (1f - 1f / num61) * (Prop.Zyn - Prop.Syn)) * num5;
				if (num62 > num25) {
					num25 = num62;
					text31 = text2;
					CFS.strTrace = CFS.strTrace + "  Mp=" + Units.DisplayMoment (Prop.Zyn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
				}
			}
		} else {
			effectiveProperties.ResetProp (this, 0);
			short num63 = 1;
			checked {
				do {
					float sx = PropEff.Sy;
					effectiveProperties.EffProp (this, 0f, 0f, PropEff.Sy * fyaxpn, 0, Spec);
					if (!PropEff.Iterate || System.Math.Abs (PropEff.Sy / sx - 1f) < 0.001f) {
						break;
					}
					num63 = (short)unchecked(num63 + 1);
				} while (num63 <= 10);
				num25 = PropEff.Sy * fyaxpn;
				if (CFS.blnTraceEffProp) {
					CFS.strTrace += PropEff.Trace;
				}
				CFS.strTrace = CFS.strTrace + "  Center of gravity shift: x=" + Units.DisplayLen1 (PropEff.Xcg - Prop.Xcgn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Sye=" + Units.DisplayLen3 (PropEff.Sy, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				text31 = text13;
				if (PropEff.RationalAnalysis) {
					num20 = num9;
					num21 = num10;
				}
			}
			if ((PropEff.Iy == Prop.Iyn) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				EffectivePropertiesType propEff = PropEff;
				effectiveProperties.ResetProp (this, 0);
				effectiveProperties.EffProp (this, 0f, 0f, Prop.Syrn * num5, 0, Spec);
				if (Operators.ConditionalCompareObjectLess (PropEff.LambdaMax, Interaction.IIf (flag, 0.667, 0.776), TextCompare: false)) {
					float num37 = PropEff.LambdaMax;
					float num60 = (float)((double)(Prop.Syn * num5) / System.Math.Pow (num37, 2.0));
					float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
					if (num61 > 9f) {
						num61 = 9f;
					}
					float num62 = (Prop.Syn + (1f - 1f / num61) * (Prop.Zyn - Prop.Syn)) * num5;
					if (num62 > num25) {
						num25 = num62;
						text31 = text2;
						CFS.strTrace += "  Local inelastic reserve\r\n";
						CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (Prop.Syn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zyn * num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
					}
				}
				PropEff = propEff;
			}
		}
		CFS.strTrace = CFS.strTrace + "  Mnl=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
		if (num25 > Prop.Zy * num5) {
			num25 = Prop.Zy * num5;
			CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
		}
		if (!Strength.MypQual) {
			num20 = num9;
			num21 = num10;
		}
		Strength.Mnyop = num25;
		Strength.Mayop = num25 / num20;
		Strength.QMnyop = num21 * num25;
		Strength.Iyep = PropEff.Iy;
		Strength.Sylep = PropEff.Syl;
		Strength.Syrep = PropEff.Syr;
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		num25 = Conversions.ToSingle (Operators.MultiplyObject (Prop.Syln, Interaction.IIf (flag, num4, Stress.Fyaypn)));
		Strength.Maytop = num25 / num47;
		Strength.QMnytop = num51 * num25;
		fyaxpn = Stress.Fyaynn;
		num20 = num47;
		num21 = num52;
		CFS.strTrace += "Negative Flexural Strength about Y-axis\r\n";
		if (DSM.UseDSM & (DSM.Mcrlyn > 0f)) {
			num21 = num48;
			float num58 = Prop.Sy * fyaxpn;
			float num59 = Prop.Syn * fyaxpn;
			float num60 = DSM.Mcrlyn * Prop.Sy * num2;
			float num37 = (float)System.Math.Sqrt (num58 / num60);
			if (flag) {
				if ((double)num37 <= 0.667) {
					num25 = num58;
					text31 = text23;
				} else {
					num25 = (float)((1.0 - 0.2 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
					text31 = text24;
				}
			} else if ((double)num37 <= 0.776) {
				num25 = num58;
				text31 = text23;
			} else {
				num25 = (float)((1.0 - 0.15 * System.Math.Pow (num60 / num58, 0.4)) * System.Math.Pow (num60 / num58, 0.4) * (double)num58);
				text31 = text24;
			}
			if (num25 > num59) {
				num25 = num59;
				text31 = text25;
			}
			PropEff.Sy = num25 / fyaxpn;
			PropEff.Iy = Prop.Iy * PropEff.Sy / Prop.Sy;
			PropEff.Syr = Prop.Syr * PropEff.Sy / Prop.Sy;
			PropEff.Syl = Prop.Syl * PropEff.Sy / Prop.Sy;
			CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  My=" + Units.DisplayMoment (num58, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (num59 < num58, ", Mynet=" + Units.DisplayMoment (num59, 0, blnShowUnit: true, "", 0, 0), "")), "\r\n")));
			CFS.strTrace = CFS.strTrace + "  Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + "\r\n";
			if ((num25 == num59) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				num37 = (float)System.Math.Sqrt (Prop.Sy * num5 / num60);
				float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
				if (num61 > 9f) {
					num61 = 9f;
				}
				float num62 = (Prop.Syn + (1f - 1f / num61) * (Prop.Zyn - Prop.Syn)) * num5;
				if (num62 > num25) {
					num25 = num62;
					text31 = text2;
					CFS.strTrace = CFS.strTrace + "  Mp=" + Units.DisplayMoment (Prop.Zyn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
				}
			}
		} else {
			effectiveProperties.ResetProp (this, 0);
			short num63 = 1;
			checked {
				do {
					float sx = PropEff.Sy;
					effectiveProperties.EffProp (this, 0f, 0f, (0f - PropEff.Sy) * fyaxpn, 0, Spec);
					if (!PropEff.Iterate || System.Math.Abs (PropEff.Sy / sx - 1f) < 0.001f) {
						break;
					}
					num63 = (short)unchecked(num63 + 1);
				} while (num63 <= 10);
				num25 = PropEff.Sy * fyaxpn;
				if (CFS.blnTraceEffProp) {
					CFS.strTrace += PropEff.Trace;
				}
				CFS.strTrace = CFS.strTrace + "  Center of gravity shift: x=" + Units.DisplayLen1 (PropEff.Xcg - Prop.Xcgn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Sye=" + Units.DisplayLen3 (PropEff.Sy, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				text31 = text13;
				if (PropEff.RationalAnalysis) {
					num20 = num9;
					num21 = num10;
				}
			}
			if ((PropEff.Iy == Prop.Iyn) & Reserve & (CFS.SpecYear (Spec) >= 2012 || flag)) {
				EffectivePropertiesType propEff = PropEff;
				effectiveProperties.ResetProp (this, 0);
				effectiveProperties.EffProp (this, 0f, 0f, (0f - Prop.Syln) * num5, 0, Spec);
				if (Operators.ConditionalCompareObjectLess (PropEff.LambdaMax, Interaction.IIf (flag, 0.667, 0.776), TextCompare: false)) {
					float num37 = PropEff.LambdaMax;
					float num60 = (float)((double)(Prop.Syn * num5) / System.Math.Pow (num37, 2.0));
					float num61 = Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (flag, 0.667, 0.776), num37));
					if (num61 > 9f) {
						num61 = 9f;
					}
					float num62 = (Prop.Syn + (1f - 1f / num61) * (Prop.Zyn - Prop.Syn)) * num5;
					if (num62 > num25) {
						num25 = num62;
						text31 = text2;
						CFS.strTrace += "  Local inelastic reserve\r\n";
						CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (Prop.Syn * num5, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zyn * num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num60, 0, blnShowUnit: true, "", 0, 0) + ", λl=" + Units.DisplayNone (num37, "", 0, 0) + ", Cyl=" + Units.DisplayNone ((float)System.Math.Sqrt (num61), "", 0, 0) + "\r\n";
					}
				}
				PropEff = propEff;
			}
		}
		CFS.strTrace = CFS.strTrace + "  Mnl=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
		if (num25 > Prop.Zy * num5) {
			num25 = Prop.Zy * num5;
			CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num25, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
		}
		if (!Strength.MynQual) {
			num20 = num9;
			num21 = num10;
		}
		Strength.Mnyon = num25;
		Strength.Mayon = num25 / num20;
		Strength.QMnyon = num21 * num25;
		Strength.Iyen = PropEff.Iy;
		Strength.Sylen = PropEff.Syl;
		Strength.Syren = PropEff.Syr;
		CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
		num25 = Conversions.ToSingle (Operators.MultiplyObject (Prop.Syrn, Interaction.IIf (flag, num4, Stress.Fyaynn)));
		Strength.Mayton = num25 / num47;
		Strength.QMnyton = num52 * num25;
		num20 = num53;
		num21 = num54;
		if (!Strength.Qual) {
			num20 = num9;
			num21 = num10;
		}
		string text32 = Conversions.ToString (Interaction.IIf (flag | (CFS.SpecYear (Spec) < 2022), "Bn=Fy·Cw/Wn", "G8.1-1"));
		float num66 = default(float);
		if (CwOverride == 0f) {
			int num64 = nPart;
			for (int i = 1; i <= num64; i = checked(i + 1)) {
				Part part = Part [i];
				if (part.WnnMax > 0f) {
					float num65 = num5 * part.Cwn / part.WnnMax;
					num66 += num65;
					CFS.strTrace = CFS.strTrace + "Bimoment Strength, " + part.Name + "\r\n";
					CFS.strTrace = CFS.strTrace + "  Cw=" + Units.DisplayLen6 (part.Cwn, 0, blnShowUnit: true, "", 0, 0) + ", Wn=" + Units.DisplayLen2 (part.WnnMax, 0, blnShowUnit: true, "", 0, 0) + ", Fy=" + Units.DisplayStress (num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "  Bn=" + Units.DisplayBimoment (num65, 0, blnShowUnit: true, "", 0, 0) + "\t" + text32 + "\r\n";
				}
				part = null;
			}
			if (num66 > 0f) {
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωb=" + Conversions.ToString (num20) + ", φb=" + Conversions.ToString (num21), Interaction.IIf (num20 == num9 && num21 == num10, " (rational analysis)", "")), "\r\n"), "\r\n")));
			}
		}
		Strength.Bn = num66;
		Strength.Ba = num66 / num20;
		Strength.QBn = num21 * num66;
	}

	public bool CheckLimits (short Spec, bool blnDSM, float P, float Mx, float My)
	{
		bool flag = true;
		if (blnDSM) {
			flag = DSM.PreQualified;
			if (CFS.SpecYear (Spec) < 2016 || !flag) {
				return flag;
			}
		}
		bool flag2 = Material.IsStainless ();
		float num = Conversions.ToSingle (Interaction.IIf (CFS.SpecYear (Spec) < 2012 && !flag2, float.MaxValue, RuntimeHelpers.GetObjectValue (Interaction.IIf (blnDSM, 20, 10))));
		float num2 = Conversions.ToSingle (Interaction.IIf (CFS.SpecYear (Spec) < 2016 && !flag2, float.MaxValue, RuntimeHelpers.GetObjectValue (Interaction.IIf (blnDSM, 0.7, 0.7))));
		float num3 = Conversions.ToSingle (Interaction.IIf (CFS.SpecYear (Spec) < 2016 && !flag2, float.MaxValue, RuntimeHelpers.GetObjectValue (Interaction.IIf (blnDSM, 95, 80))));
		if (Material.Fy [2] > num3) {
			flag = false;
			string text = "Yield stress exceeds " + Units.DisplayStress (num3, 0, blnShowUnit: true, "", 0, 0) + ".";
			if (Strings.InStr (Strength.Msg, text) == 0) {
				ref string msg = ref Strength.Msg;
				msg = msg + text + "\r\n";
			}
		}
		if (P <= 0f && Mx == 0f && My == 0f) {
			return flag;
		}
		int num4 = nPart;
		for (int i = 1; i <= num4; i = checked(i + 1)) {
			Part part = Part [i];
			float thickness = Part [i].Thickness;
			float num5 = part.XPosition - part.Xcg - Prop.Xcg;
			float num6 = part.YPosition - part.Ycg - Prop.Ycg;
			if (!IsCylinder ()) {
				float num7 = num5 + part.Element [part.nElem].X1;
				float num8 = num6 + part.Element [part.nElem].Y1;
				float num9 = P / Prop.A + Mx * num8 / Prop.Ix + My * num7 / Prop.Iy;
				int nElem = part.nElem;
				for (int j = 1; j <= nElem; j = checked(j + 1)) {
					float num10 = part.Element [j].Rad / thickness;
					float num11 = num5 + part.Element [j].X0;
					float num12 = num6 + part.Element [j].Y0;
					float num13 = P / Prop.A + Mx * num12 / Prop.Ix + My * num11 / Prop.Iy;
					if (((j > 1) | part.Closed) && num9 > 0f && num13 > 0f && num10 > num) {
						flag = false;
						string text = "R/t exceeds " + Conversions.ToString (num) + ".";
						if (Strings.InStr (Strength.Msg, text) == 0) {
							ref string msg2 = ref Strength.Msg;
							msg2 = msg2 + text + "\r\n";
						}
					}
					num7 = num5 + part.Element [j].X1;
					num8 = num6 + part.Element [j].Y1;
					num9 = P / Prop.A + Mx * num8 / Prop.Ix + My * num7 / Prop.Iy;
				}
			}
			int nElemGrp = part.nElemGrp;
			for (int k = 1; k <= nElemGrp; k = checked(k + 1)) {
				short iElemFirst = part.ElementGroup [k].iElemFirst;
				float num11 = num5 + part.Element [iElemFirst].X0;
				float num12 = num6 + part.Element [iElemFirst].Y0;
				float num13 = P / Prop.A + Mx * num12 / Prop.Ix + My * num11 / Prop.Iy;
				short iElemLast = part.ElementGroup [k].iElemLast;
				float num7 = num5 + part.Element [iElemLast].X1;
				float num8 = num6 + part.Element [iElemLast].Y1;
				float num9 = P / Prop.A + Mx * num8 / Prop.Ix + My * num7 / Prop.Iy;
				float num14 = (float)(System.Math.Sqrt (System.Math.Pow (num7 - num11, 2.0) + System.Math.Pow (num8 - num12, 2.0)) / (double)thickness);
				float num15 = float.MaxValue;
				string text2 = "w/t";
				short num16 = short.MaxValue;
				string text3 = ".";
				string text4 = Conversions.ToString (Interaction.IIf (iElemFirst == iElemLast, " element " + Conversions.ToString ((int)iElemFirst), " elements " + Conversions.ToString ((int)iElemFirst) + "-" + Conversions.ToString ((int)iElemLast)));
				if ((num13 > 0f && num9 > 0f) & !part.Closed & ((iElemFirst == 1) | (iElemLast == part.nElem))) {
					num15 = Conversions.ToSingle (Interaction.IIf (blnDSM, 60, 60));
					text2 = "d/t";
					num16 = 0;
					text3 = " (lip).";
				} else if ((num13 > 0f && num9 > 0f) & !part.Closed & ((iElemFirst == 2) | (iElemLast == checked(unchecked((int)part.nElem) - 1))) & (part.nElem >= 4)) {
					num15 = Conversions.ToSingle (Interaction.IIf (blnDSM, 160, 90));
					text2 = "b/t";
					num16 = 2;
					text3 = " (flange).";
					checked {
						if (num14 > 20f) {
							float num17 = (float)((double)(part.Element [iElemFirst].Rad + thickness) * System.Math.Tan (System.Math.Abs (part.Element [iElemFirst].Arc) / 2f));
							float num18 = (float)((double)(part.Element [iElemLast + 1].Rad + thickness) * System.Math.Tan (System.Math.Abs (part.Element [iElemLast + 1].Arc) / 2f));
							float num19 = num14 * thickness + num17 + num18;
							float num20 = ((iElemFirst != 2) ? (part.Element [iElemLast + 1].Wid + num18) : (part.Element [iElemFirst - 1].Wid + num17));
							if (num20 / num19 > num2) {
								flag = false;
								string text = part.Name + text4 + " d₀/b₀ exceeds " + Conversions.ToString (num2) + ".";
								if (Strings.InStr (Strength.Msg, text) == 0) {
									ref string msg3 = ref Strength.Msg;
									msg3 = msg3 + text + "\r\n";
								}
							}
						}
					}
				} else if (num13 > 0f && num9 > 0f) {
					num15 = Conversions.ToSingle (Interaction.IIf (flag2, 400, RuntimeHelpers.GetObjectValue (Interaction.IIf (blnDSM, 500, 500))));
					num16 = 4;
				} else if (num13 * num9 < 0f) {
					num15 = Conversions.ToSingle (Interaction.IIf (flag2, 200, RuntimeHelpers.GetObjectValue (Interaction.IIf (blnDSM, 300, RuntimeHelpers.GetObjectValue (Interaction.IIf (CFS.SpecYear (Spec) < 2022, 200, 300))))));
					text2 = "h/t";
					num16 = Conversions.ToShort (Interaction.IIf (blnDSM, 4, 0));
					text3 = " (web).";
				}
				if (num14 > num15) {
					flag = false;
					string text = part.Name + text4 + " " + text2 + " exceeds " + Conversions.ToString (num15) + ".";
					if (Strings.InStr (Strength.Msg, text) == 0) {
						ref string msg4 = ref Strength.Msg;
						msg4 = msg4 + text + "\r\n";
					}
				}
				if (part.ElementGroup [k].Ns > num16) {
					flag = false;
					string text = part.Name + text4 + " number of stiffeners exceeds " + Conversions.ToString ((int)num16) + text3;
					if (Strings.InStr (Strength.Msg, text) == 0) {
						ref string msg5 = ref Strength.Msg;
						msg5 = msg5 + text + "\r\n";
					}
				}
			}
			part = null;
		}
		return flag;
	}

	public void MemberCheck (MemberParameters Param, ref MemberCheck Check, bool blnFixCG = false)
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		string text = string.Empty;
		string text2 = string.Empty;
		EffectiveProperties effectiveProperties = new EffectiveProperties ();
		string text3 = string.Empty;
		string text4 = string.Empty;
		string text5 = string.Empty;
		string text6 = string.Empty;
		string text7 = string.Empty;
		string text8 = string.Empty;
		string text9 = string.Empty;
		string text10 = string.Empty;
		bool flag = Material.IsStainless ();
		string text11;
		string text12;
		string text13;
		string truePart;
		string truePart2;
		string text14;
		string text15;
		string text16;
		string text17;
		string text18;
		string text19;
		string text20;
		string text21;
		string text22;
		string text23;
		string text24;
		string text25;
		string text26;
		string truePart3;
		string text27;
		string text28;
		string text29;
		string text30;
		string text31;
		string text32;
		string text33;
		string text34;
		string text35;
		string text36;
		string text37;
		string text38;
		if (flag) {
			text11 = "ASCE Eq. 6-14";
			text12 = "ASCE Eq. 6-10";
			text13 = "ASCE Eq. 6-11";
			truePart = "ASCE Eq. 6-8";
			truePart2 = string.Empty;
			text14 = "ASCE Eq. 9-3";
			text15 = "ASCE Eq. 5-6";
			text16 = "ASCE Eq. 5-7";
			text17 = "ASCE Eq. B-5";
			text18 = "ASCE Eq. 5-5";
			text19 = "ASCE Eq. 5-3";
			text20 = "ASCE Eq. 5-4";
			text21 = "ASCE Eq. 5-1";
			text22 = "ASCE Eq. 5-13";
			text4 = "ASCE Eq. 5-26";
			text5 = "ASCE Eq. 5-27";
			text6 = "ASCE Eq. 5-23";
			text23 = "S100-16 Eq. I6.2.3-2";
			text24 = "S100-16 Eq. I6.2.3-3";
			text25 = "S100-16 Eq. I6.2.3-4";
			text26 = "S100-16 Eq. I6.2.3-1";
			truePart3 = "ASCE Eq. 6-7";
			text27 = "ASCE Eq. 6-16";
			text28 = "ASCE Eq. 6-13";
			text29 = "ASCE Eq. 6-3";
			text30 = "ASCE Eq. 6-4";
			text31 = "ASCE Eq. 6-5";
			text32 = "ASCE Eq. 6-1";
			text33 = "ASCE Eq. 6-24";
			text7 = "ASCE Eq. 6-47";
			text8 = "ASCE Eq. 6-48";
			text9 = "ASCE Eq. 6-44";
			text10 = "ASCE Eq. 8-11";
			text34 = "S100-16 Eq. I6.2.1-1";
			text = "ASCE Eq. 6-21";
			text2 = "ASCE Eq. 6-53";
			text35 = "ASCE Eq. 3-6";
			text36 = "ASCE Eq. 3-6";
			text37 = "ASCE Eq. 3-6";
			text38 = "ASCE Eq. 3-6";
		} else if (CFS.IsSpec1999 ((short)Param.Spec)) {
			text11 = "Eq. C3.1.2.1-7";
			text12 = "Eq. C3.1.2.1-8";
			text13 = "Eq. C3.1.2.1-9";
			truePart = "Eq. C3.1.2.1-10";
			truePart2 = "Eq. C3.1.2.1-11";
			text14 = string.Empty;
			text15 = "Eq. C4.1-1";
			text16 = "Eq. C4.2-1";
			text17 = "Analytical";
			text18 = "Eq. C4-4";
			text19 = "Eq. C4-2";
			text20 = "Eq. C4-3";
			text21 = string.Empty;
			text22 = "Eq. C4-1";
			text23 = "Eq. C4.4-2";
			text24 = "Eq. C4.4-3";
			text25 = "Eq. C4.4-5";
			text26 = "Eq. C4.4-1";
			truePart3 = "Eq. C3.1.2.1-5";
			text27 = "Eq. C3.1.2.1-5*";
			text28 = "Eq. C3.1.2.1-6";
			text29 = "Eq. C3.1.2.1-2";
			text30 = "Eq. C3.1.2.1-3";
			text31 = "Eq. C3.1.2.1-4";
			text32 = string.Empty;
			text33 = "Eq. C3.1.2.1-1";
			text34 = "Eq. C3.1.3-1";
			text35 = "Eq. C5.2.1-4";
			text36 = "Eq. C5.2.1-5";
			text37 = "Eq. C5.2.2-4";
			text38 = "Eq. C5.2.2-5";
		} else if (CFS.IsSpec2001 ((short)Param.Spec)) {
			text11 = "Eq. C3.1.2.1-7";
			text12 = "Eq. C3.1.2.1-8";
			text13 = "Eq. C3.1.2.1-9";
			truePart = "Eq. C3.1.2.1-10";
			truePart2 = "Eq. C3.1.2.1-11";
			text14 = "Eq. C4.5-1";
			text15 = "Eq. C4.1-1";
			text16 = "Eq. C4.2-1";
			text17 = "Analytical";
			text18 = "Eq. C4-4";
			text19 = "Eq. C4-2";
			text20 = "Eq. C4-3";
			text21 = string.Empty;
			text22 = "Eq. C4-1";
			text23 = "Eq. C4.6-2";
			text24 = "Eq. C4.6-3";
			text25 = "Eq. C4.6-4";
			text26 = "Eq. C4.6-1";
			truePart3 = "Eq. C3.1.2.1-5";
			text27 = "Eq. C3.1.2.1-5*";
			text28 = "Eq. C3.1.2.1-6";
			text29 = "Eq. C3.1.2.1-2";
			text30 = "Eq. C3.1.2.1-3";
			text31 = "Eq. C3.1.2.1-4";
			text32 = string.Empty;
			text33 = "Eq. C3.1.2.1-1";
			text34 = "Eq. C3.1.3-1";
			text35 = "Eq. C5.2.1-4";
			text36 = "Eq. C5.2.1-5";
			text37 = "Eq. C5.2.2-4";
			text38 = "Eq. C5.2.2-5";
		} else if (CFS.IsSpec2004 ((short)Param.Spec)) {
			text11 = "Eq. C3.1.2.1-6";
			text12 = "Eq. C3.1.2.1-7";
			text13 = "Eq. C3.1.2.1-8";
			truePart = "Eq. C3.1.2.1-9";
			truePart2 = "Eq. C3.1.2.1-10";
			text14 = "Eq. C4.5-1";
			text15 = "Eq. C4.1-1";
			text16 = "Eq. C4.2-1";
			text17 = "Analytical";
			text18 = "Eq. C4-4";
			text19 = "Eq. C4-2";
			text20 = "Eq. C4-3";
			text21 = string.Empty;
			text22 = "Eq. C4-1";
			text23 = "Eq. C4.6-2";
			text24 = "Eq. C4.6-3";
			text25 = "Eq. C4.6-4";
			text26 = "Eq. C4.6-1";
			truePart3 = "Eq. C3.1.2.1-4";
			text27 = "Eq. C3.1.2.1-4*";
			text28 = "Eq. C3.1.2.1-5";
			text29 = string.Empty;
			text30 = "Eq. C3.1.2.1-2";
			text31 = "Eq. C3.1.2.1-3";
			text32 = string.Empty;
			text33 = "Eq. C3.1.2.1-1";
			text34 = "Eq. C3.1.3-1";
			text35 = "Eq. C5.2.1-4";
			text36 = "Eq. C5.2.1-5";
			text37 = "Eq. C5.2.2-4";
			text38 = "Eq. C5.2.2-5";
		} else if (CFS.IsSpec2007 ((short)Param.Spec) | CFS.IsSpec2010 ((short)Param.Spec) | CFS.IsSpec2012 ((short)Param.Spec)) {
			text11 = "Eq. C3.1.2.1-11";
			text12 = "Eq. C3.1.2.1-8";
			text13 = "Eq. C3.1.2.1-9";
			truePart = "Eq. C3.1.2.1-6";
			truePart2 = "Eq. C3.1.2.1-12";
			text14 = "Eq. D1.2-1";
			text15 = "Eq. C4.1.1-1";
			text16 = "Eq. C4.1.2-1";
			text17 = "Analytical";
			text18 = "Eq. C4.1-4";
			text19 = "Eq. C4.1-2";
			text20 = "Eq. C4.1-3";
			text21 = string.Empty;
			text22 = "Eq. C4.1-1";
			text4 = "Eq. C4.2-1";
			text5 = "Eq. 1.2.1-14";
			text6 = "Eq. C4.2-2";
			text23 = "Eq. D6.1.3-2";
			text24 = "Eq. D6.1.3-3";
			text25 = "Eq. D6.1.3-4";
			text26 = "Eq. D6.1.3-1";
			truePart3 = "Eq. C3.1.2.1-4";
			text27 = "Eq. C3.1.2.1-5";
			text28 = "Eq. C3.1.2.1-10";
			text29 = string.Empty;
			text30 = "Eq. C3.1.2.1-2";
			text31 = "Eq. C3.1.2.1-3";
			text32 = string.Empty;
			text33 = "Eq. C3.1.2.1-1";
			text7 = "Eq. C3.1.4-1";
			text8 = "Eq. 1.2.2-25";
			text9 = "Eq. C3.1.4-2";
			text10 = "Eq. C3.6-1";
			text34 = "Eq. D6.1.1-1";
			text = "1.2.2-5";
			text2 = "1.2.2-20";
			text35 = "Eq. C5.2.1-4";
			text36 = "Eq. C5.2.1-5";
			text37 = "Eq. C5.2.2-4";
			text38 = "Eq. C5.2.2-5";
		} else if (CFS.IsSpec2016 ((short)Param.Spec) | CFS.IsSpec2018 ((short)Param.Spec)) {
			text11 = "Eq. F2.1.2-2";
			text12 = "Eq. F2.1.1-4";
			text13 = "Eq. F2.1.1-5";
			truePart = "Eq. F2.1.1-2";
			truePart2 = "Eq. F2.1.2-3";
			text14 = "Eq. I1.2-1";
			text15 = "Eq. E2.1-1";
			text16 = "Eq. E2.2-1";
			text17 = "Eq. 2.3.1.1-2";
			text18 = "Eq. E2-4";
			text19 = "Eq. E2-2";
			text20 = "Eq. E2-3";
			text21 = "Eq. E2-1";
			text22 = "Eq. E3.1-1";
			text4 = "Eq. E4.2-1";
			text5 = "Eq. E4.2-2";
			text6 = "Eq. E4.1-2";
			text23 = "Eq. I6.2.3-2";
			text24 = "Eq. I6.2.3-3";
			text25 = "Eq. I6.2.3-4";
			text26 = "Eq. I6.2.3-1";
			truePart3 = "Eq. F2.1.1-1";
			text27 = "Eq. F2.1.3-1";
			text28 = "Eq. F2.1.2-1";
			text29 = "Eq. F2.1-3";
			text30 = "Eq. F2.1-4";
			text31 = "Eq. F2.1-5";
			text32 = "Eq. F2.1-1";
			text33 = "Eq. F3.1-1";
			text7 = "Eq. F4.2-1";
			text8 = "Eq. F4.2-2";
			text9 = "Eq. F4.1-2";
			text10 = "Eq. H4-1";
			text34 = "Eq. I6.2.1-1";
			text = "F2.4.2-1";
			text2 = "F4.3-1";
			text35 = "Eq. C1.2.1.1-3";
			text36 = "Eq. C1.2.1.1-3";
			text37 = "Eq. C1.2.1.1-3";
			text38 = "Eq. C1.2.1.1-3";
		} else {
			text11 = "Eq. 2.3.1-1";
			text12 = "Eq. 2.3.1-2";
			text13 = "Eq. 2.3.1-3";
			truePart = "Eq. 2.3.1-8";
			truePart2 = string.Empty;
			text14 = "Eq. I1.2.2.1-1";
			text15 = "2.3.1.1.1-1";
			text16 = "Eq. 2.3.1.1.2-1";
			text17 = "Eq. 2.3.1.1.4-3";
			text3 = "Eq. C-2.3.1.1.2-2";
			text18 = "Eq. E2-4";
			text19 = "Eq. E2-2";
			text20 = "Eq. E2-3";
			text21 = "Eq. E2-1";
			text22 = "Eq. E3.1-1";
			text4 = "Eq. E4-3";
			text5 = "Eq. E4-4";
			text6 = "Eq. E4-2";
			text23 = "Eq. I6.2.3-2";
			text24 = "Eq. I6.2.3-3";
			text25 = "Eq. I6.2.3-4";
			text26 = "Eq. I6.2.3-1";
			truePart3 = "Eq. 2.3.1.2.1-1";
			text27 = "Eq. 2.3.1.2.3-1";
			text28 = "Eq. 2.3.1.2.2-1";
			text29 = "Eq. F2.1-3";
			text30 = "Eq. F2.1-4";
			text31 = "Eq. F2.1-5";
			text32 = "Eq. F2.1-1";
			text33 = "Eq. F3.1-1";
			text7 = "Eq. F4-3";
			text8 = "Eq. F4-4";
			text9 = "Eq. F4-2";
			text10 = string.Empty;
			text34 = "Eq. I6.2.1-1";
			text = "F2.2.2-1";
			text2 = "F4.1-1";
			text35 = "Eq. C1.2.1.1-3";
			text36 = "Eq. C1.2.1.1-3";
			text37 = "Eq. C1.2.1.1-3";
			text38 = "Eq. C1.2.1.1-3";
		}
		string text39 = "Eq. 1.2.1-5";
		string text40 = "Eq. 1.2.1-6";
		string text41 = "Eq. 1.2.1-9 (2012)";
		string text42 = "Eq. 1.2.2-5";
		string text43 = "Eq. 1.2.2-6";
		string text44 = "Eq. 1.2.2-16 (2012)";
		if (flag) {
			text39 = "ASCE Eq. 5-14";
			text40 = "ASCE Eq. 5-15";
			text41 = "ASCE Eq. 5-17";
			text42 = "ASCE Eq. 6-25";
			text43 = "ASCE Eq. 6-26";
			text44 = "ASCE Eq. 6-28";
		} else if (CFS.IsSpec2012 ((short)Param.Spec)) {
			text39 = "Eq. 1.2.1-5";
			text40 = "Eq. 1.2.1-6";
			text41 = "Eq. 1.2.1-9";
			text42 = "Eq. 1.2.2-7";
			text43 = "Eq. 1.2.2-8";
			text44 = "Eq. 1.2.2-16";
		} else if (CFS.IsSpec2016 ((short)Param.Spec) | CFS.IsSpec2018 ((short)Param.Spec)) {
			text39 = "Eq. E3.2.1-1";
			text40 = "Eq. E3.2.1-2";
			text41 = "Eq. E3.2.2-2";
			text42 = "Eq. F3.2.1-1";
			text43 = "Eq. F3.2.1-2";
			text44 = "Eq. F3.2.2-2";
		} else if (CFS.IsSpec2022 ((short)Param.Spec)) {
			text39 = "Eq. E3.2-1";
			text40 = "Eq. E3.2-2";
			text41 = "Eq. E3.2-5";
			text42 = "Eq. F3.2-1";
			text43 = "Eq. F3.2-2";
			text44 = "Eq. F3.2-5";
		}
		string text45;
		string text46;
		if (CFS.SpecYear ((short)Param.Spec) >= 2016 || flag) {
			text45 = "Fcre";
			text46 = "Fn";
		} else {
			text45 = "Fe";
			text46 = "Fc";
		}
		CFS.strTrace = string.Empty;
		Check.Msg = Strength.Msg;
		float num = Material.Eo [2];
		float num2 = Material.Fy [2];
		float num3 = DesignFy (StressDirections.dirLC, Param.Spec);
		float num4 = (float)CFS.Min (num3, DesignFy (StressDirections.dirLT, Param.Spec));
		DesignFu (Param.Spec);
		float num5 = Param.Kx * Param.Lx;
		float num6 = Param.Ky * Param.Ly;
		float num7 = Param.Kt * Param.Lt;
		float num8 = HoleLength;
		float num9 = (float)CFS.Max (CFS.Min (HoleSpacing, num5 / 2f), num8, 0.001);
		float num10 = (float)CFS.Max (CFS.Min (HoleSpacing, num6 / 2f), num8, 0.001);
		float num11 = (float)CFS.Max (CFS.Min (HoleSpacing, num7 / 2f), num8, 0.001);
		if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
			num8 = 0f;
		}
		float num12 = Prop.Xo - (Prop.Xo - Prop.Xon) * num8 / num11;
		float num13 = Prop.Yo - (Prop.Yo - Prop.Yon) * num8 / num11;
		float num14 = Prop.jx - (Prop.jx - Prop.jxn) * num8 / num11;
		float num15 = Prop.jy - (Prop.jy - Prop.jyn) * num8 / num11;
		float num16 = Prop.Ix - (Prop.Ix - Prop.Ixn) * num8 / num9;
		float num17 = Prop.Iy - (Prop.Iy - Prop.Iyn) * num8 / num10;
		float num18 = (float)((double)Prop.Ixy - (double)((Prop.Ixy - Prop.Ixyn) * num8) / CFS.Min (num9, num10));
		float num19 = (float)((double)Prop.I2 - (double)((Prop.I2 - Prop.I2n) * num8) / CFS.Min (num9, num10));
		float num20 = Prop.J - (Prop.J - Prop.Jn) * num8 / num11;
		float num21 = Conversions.ToSingle (Interaction.IIf (num8 == 0f, Prop.Cw, Prop.Cwn));
		float num22 = Prop.A - (Prop.A - Prop.An) * num8 / num11;
		float num23 = (float)((double)(num16 + num17) + (double)num22 * (System.Math.Pow (num12, 2.0) + System.Math.Pow (num13, 2.0)));
		float num24 = (float)System.Math.Sqrt (num23 / num22);
		float a = Prop.A;
		float num25 = 2f;
		float num26 = 0.8f;
		if (!flag & CFS.IsSpecLSD ((short)Param.Spec)) {
			num26 = 0.75f;
		}
		Check.Mx = Param.Mx;
		Check.Vy = Param.Vy;
		Check.My = Param.My;
		Check.Vx = Param.Vx;
		Check.B = Param.B;
		effectiveProperties.ResetProp (this, 1);
		if (DSM.UseDSM & (DSM.Pcrl > 0f)) {
			blnFixCG = true;
		}
		if (CFS.SpecYear ((short)Param.Spec) >= 2016 || flag) {
			blnFixCG = true;
		}
		if (Param.P > 0f && !blnFixCG) {
			effectiveProperties.EffProp (this, Param.P, 0f, 0f, 1, (short)Param.Spec);
		}
		float num27 = Param.ex - PropEff.Xcg;
		float num28 = Param.ey - PropEff.Ycg;
		if (Param.Analysis) {
			num27 = Prop.Xcg - PropEff.Xcg;
			num28 = Prop.Ycg - PropEff.Ycg;
		}
		if (Param.Kx == 0f) {
			Check.Mx = 0f;
			Check.Vy = 0f;
		}
		if (Param.Ky == 0f) {
			Check.My = 0f;
			Check.Vx = 0f;
		}
		if (Param.Kt == 0f) {
			Check.B = 0f;
		}
		if (num5 <= 0f) {
			num28 = 0f;
		}
		if (num6 <= 0f) {
			num27 = 0f;
		}
		if (Param.P != 0f && (num27 != 0f || num28 != 0f)) {
			Check.Mx += Param.P * num28;
			Check.My += Param.P * num27;
			if (Param.P > 0f) {
				CFS.strTrace = CFS.strTrace + "Axial Load Eccentricity, P=" + Units.DisplayForce (Param.P, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				if (CFS.blnTraceEffProp & !IsCylinder ()) {
					CFS.strTrace += PropEff.Trace;
				}
				CFS.strTrace = CFS.strTrace + "  Center of gravity shift:  x=" + Units.DisplayLen1 (PropEff.Xcg - Prop.Xcg, 0, blnShowUnit: true, "", 0, 0) + ",  y=" + Units.DisplayLen1 (PropEff.Ycg - Prop.Ycg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			} else {
				CFS.strTrace = CFS.strTrace + "Axial Load Eccentricity, T=" + Units.DisplayForce (0f - Param.P, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			}
			if (!Param.Analysis) {
				CFS.strTrace = CFS.strTrace + "  Initial eccentricity:  x=" + Units.DisplayLen1 (0f - Prop.Xcg, 0, blnShowUnit: true, "", 0, 0) + ",  y=" + Units.DisplayLen1 (0f - Prop.Ycg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Specified eccentricity:  x=" + Units.DisplayLen1 (Param.ex, 0, blnShowUnit: true, "", 0, 0) + ",  y=" + Units.DisplayLen1 (Param.ey, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Overall eccentricity:  x=" + Units.DisplayLen1 (Param.ex - PropEff.Xcg, 0, blnShowUnit: true, "", 0, 0) + ",  y=" + Units.DisplayLen1 (Param.ey - PropEff.Ycg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			}
			if (num5 <= 0f) {
				CFS.strTrace += "  Fully braced about X axis\r\n";
			}
			if (num6 <= 0f) {
				CFS.strTrace += "  Fully braced about Y axis\r\n";
			}
			CFS.strTrace = CFS.strTrace + "  Additional moments:  My=" + Units.DisplayMoment (Param.P * num27, 0, blnShowUnit: true, "", 0, 0) + ",  Mx=" + Units.DisplayMoment (Param.P * num28, 0, blnShowUnit: true, "", 0, 0) + "\r\n\r\n";
		}
		if (((nPart == 1) & (Part [1].nElem == 2) & HasSymmetry (Symmetry.Principal) & (Param.P > 0f)) && ((CFS.IsSpec1999 ((short)Param.Spec) && !flag) | !IsCompactAngle (Stress.Fyacg))) {
			if (System.Math.Abs (num15) > System.Math.Abs (num14)) {
				if (num5 > 0f) {
					CFS.strTrace += "Angle Section\r\n";
					CFS.strTrace = CFS.strTrace + "  Additional moment Mx=PL/1000=" + Units.DisplayMoment ((float)System.Math.Sign (num15) * Param.P * Param.Lx / 1000f, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					double num29 = Check.Mx + (float)System.Math.Sign (num15) * Param.P * Param.Lx / 1000f;
					float num30 = ((!(Check.Mx >= 0f)) ? ((0f - Check.Mx) / Strength.Maxon) : (Check.Mx / Strength.Maxop));
					float num31 = ((!(num29 >= 0.0)) ? ((float)((0.0 - num29) / (double)Strength.Maxon)) : ((float)(num29 / (double)Strength.Maxop)));
					if (num31 > num30) {
						Check.Mx = (float)num29;
					} else {
						CFS.strTrace += "  Not applied because it results in a lower interaction value.\r\n";
					}
					CFS.strTrace += "\r\n";
				}
			} else if (num6 > 0f) {
				CFS.strTrace += "Angle Section\r\n";
				CFS.strTrace = CFS.strTrace + "  Additional moment My=PL/1000=" + Units.DisplayMoment ((float)System.Math.Sign (num14) * Param.P * Param.Ly / 1000f, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				double num29 = Check.My + (float)System.Math.Sign (num14) * Param.P * Param.Ly / 1000f;
				float num30 = ((!(Check.My >= 0f)) ? ((0f - Check.My) / Strength.Mayon) : (Check.My / Strength.Mayop));
				float num31 = ((!(num29 >= 0.0)) ? ((float)((0.0 - num29) / (double)Strength.Mayon)) : ((float)(num29 / (double)Strength.Mayop)));
				if (num31 > num30) {
					Check.My = (float)num29;
				} else {
					CFS.strTrace += "  Not applied because it results in a lower interaction value.\r\n";
				}
				CFS.strTrace += "\r\n";
			}
		}
		float num32 = (float)(9.869604401089358 * (double)num);
		float num33 = (float)CFS.Min (num5, num6);
		float num34 = (float)((double)a * System.Math.Pow (num5, 2.0) / (double)(num32 * num16));
		float num35 = (float)((double)a * System.Math.Pow (num6, 2.0) / (double)(num32 * num17));
		float num36 = (float)((double)a * System.Math.Pow (num33, 2.0) / (double)(num32 * num19));
		float num37 = num34;
		float num38 = num35;
		float num39 = num36;
		float num40 = (float)(1.0 - System.Math.Pow (num18, 2.0) / (double)(num16 * num17));
		float num41 = (float)CFS.Max (num5 / Prop.Rx, num6 / Prop.Ry, num33 / Prop.R2);
		if ((Param.iBrcFlg == Flanges.flgBottom) | (Param.iBrcFlg == Flanges.flgTop)) {
			num41 = num5 / Prop.Rx;
		}
		if ((Param.iBrcFlg == Flanges.flgLeft) | (Param.iBrcFlg == Flanges.flgRight)) {
			num41 = num6 / Prop.Ry;
		}
		if ((CFS.SpecYear ((short)Param.Spec) >= 2016 || flag) & (Param.P > 0f) & !Param.Pdelta) {
			CFS.strTrace += "P-δ effects\r\n";
			num22 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecASD ((short)Param.Spec), 1.6, 1));
			num22 = 1f - num22 * Param.P * num34 / a;
			float num42 = ((!(num22 > 0f)) ? 1f : ((float)CFS.Max (Param.Cmx / num22, 1.0)));
			Check.Mx *= num42;
			CFS.strTrace = CFS.strTrace + "  B₁x=" + Units.DisplayNone (num42, "", 0, 0) + "\t" + text35 + "\r\n";
			num22 = Conversions.ToSingle (Interaction.IIf (CFS.IsSpecASD ((short)Param.Spec), 1.6, 1));
			num22 = 1f - num22 * Param.P * num35 / a;
			num42 = ((!(num22 > 0f)) ? 1f : ((float)CFS.Max (Param.Cmy / num22, 1.0)));
			Check.My *= num42;
			CFS.strTrace = CFS.strTrace + "  B₁y=" + Units.DisplayNone (num42, "", 0, 0) + "\t" + text36 + "\r\n";
		}
		if (Param.P >= 0f) {
			CFS.strTrace += "Axial Compression Strength\r\n";
		}
		float num43 = ConnSpacing;
		if (CFS.IsSpec1999 ((short)Param.Spec) && !flag) {
			num43 = 0f;
		}
		if ((double)num43 > CFS.Max (Param.Lx, Param.Ly)) {
			num43 = (float)CFS.Max (Param.Lx, Param.Ly);
		}
		if (nPart > 1 && num43 > 0f) {
			float num44 = Prop.R2;
			short num45 = nPart;
			float sngValue;
			float sngValue2;
			checked {
				float num48 = default(float);
				float num49 = default(float);
				for (short num46 = 1; num46 <= num45; num46 = (short)unchecked(num46 + 1)) {
					Part part = Part [num46];
					float num47 = (float)System.Math.Sqrt (((double)((part.Ix + part.Iy) / 2f) - System.Math.Sqrt (System.Math.Pow (part.Ix - part.Iy, 2.0) / 4.0 + System.Math.Pow (part.Ixy, 2.0))) / (double)part.A);
					if (num47 < num44) {
						num44 = num47;
					}
					num48 += part.Ix;
					num49 += part.Iy;
					part = null;
				}
				sngValue = 1f;
				sngValue2 = 1f;
				if (((double)Prop.Ix > 1.01 * (double)num48) | (System.Math.Abs (num18 / num23) > 0.001f)) {
					sngValue = (float)((double)num37 / ((double)num37 + System.Math.Pow (num43 / num44, 2.0) / (double)num32));
					num37 = (float)((double)num37 + System.Math.Pow (num43 / num44, 2.0) / (double)num32);
				}
				if (((double)Prop.Iy > 1.01 * (double)num49) | (System.Math.Abs (num18 / num23) > 0.001f)) {
					sngValue2 = (float)((double)num38 / ((double)num38 + System.Math.Pow (num43 / num44, 2.0) / (double)num32));
					num38 = (float)((double)num38 + System.Math.Pow (num43 / num44, 2.0) / (double)num32);
				}
				if ((((double)Prop.Ix > 1.01 * (double)num48) | ((double)Prop.Iy > 1.01 * (double)num49)) & (System.Math.Abs (num18 / num23) > 0.001f)) {
					num39 = (float)((double)num39 + System.Math.Pow (num43 / num44, 2.0) / (double)num32);
				}
			}
			if (Param.P >= 0f) {
				if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
					CFS.strTrace += "  Built-Up Member - Modified column slenderness\r\n";
					CFS.strTrace = CFS.strTrace + "    Connector spacing a=" + Units.DisplayLen1 (num43, 0, blnShowUnit: true, "", 0, 0) + ", ri=" + Units.DisplayLen1 (num44, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    (KL/r)x=" + Units.DisplayNone ((float)System.Math.Sqrt (num37 * num32), "", 0, 0) + ", (KL/r)y=" + Units.DisplayNone ((float)System.Math.Sqrt (num38 * num32), "", 0, 0) + "\t" + text14 + "\r\n";
				} else {
					CFS.strTrace += "  Built-Up Member - Moment of inertia reduction\r\n";
					CFS.strTrace = CFS.strTrace + "    Connector spacing a=" + Units.DisplayLen1 (num43, 0, blnShowUnit: true, "", 0, 0) + ", ri=" + Units.DisplayLen1 (num44, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    (Ir/I)x=" + Units.DisplayNone (sngValue, "", 0, 0) + ", (Ir/I)y=" + Units.DisplayNone (sngValue2, "", 0, 0) + "\t" + text14 + "\r\n";
				}
			}
			if (((double)(num43 / num44) > 0.5 * (double)num41) & (Param.P > 0f)) {
				Check.Msg += "Connector spacing: a/ri exceeds 0.5KL/r.\r\n";
			}
		}
		float num50 = ((!(num7 > 0f)) ? 0f : ((float)((double)a * System.Math.Pow (num24, 2.0) / ((double)(Material.Eo [5] * num20) + (double)(num32 * num21) / System.Math.Pow (num7, 2.0)))));
		float num51 = default(float);
		float num65 = default(float);
		float num66 = default(float);
		float num68 = default(float);
		bool flag2 = default(bool);
		float num67 = default(float);
		if (Param.P >= 0f) {
			if (Prop.An < a && num8 > 0f) {
				CFS.strTrace += "  Reduced section properties used to account for holes\r\n";
			}
			if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
				CFS.strTrace += "  σex=";
				if (num37 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num37, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text11 + "\r\n";
				CFS.strTrace += "  σey=";
				if (num38 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num38, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text12 + "\r\n";
				CFS.strTrace += "  σt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			} else {
				CFS.strTrace += "  Pex=";
				if (num37 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num37, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text11 + "\r\n";
				CFS.strTrace += "  Pey=";
				if (num38 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num38, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text12 + "\r\n";
				CFS.strTrace += "  Pt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			}
			flag2 = false;
			string text47;
			if ((CFS.SpecYear ((short)Param.Spec) > 1999 || flag) & IsCompactAngle (Stress.Fyacg)) {
				num51 = (float)CFS.Max (num37, num38, num39);
				text47 = text15;
			} else if ((CFS.SpecYear ((short)Param.Spec) < 2022 || flag) & ((!Param.BucklingTheory | HasSymmetry (Symmetry.Point)) || (num5 == num7 && num6 == num7))) {
				num51 = (float)CFS.Max (num37, num38, num39);
				text47 = text15;
				if (num50 > num51) {
					num51 = num50;
					text47 = text13;
				}
				double num52 = 1.0 - System.Math.Pow (num12 / num24, 2.0);
				if (num52 < 0.9999 && num37 > 0f && num50 > 0f) {
					float num53 = 1f / num37;
					float num54 = 1f / num50;
					float num55 = (float)(((double)(num53 + num54) - System.Math.Sqrt (System.Math.Pow (num53 + num54, 2.0) - 4.0 * num52 * (double)num53 * (double)num54)) / (2.0 * num52));
					if (1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text16;
					}
				}
				num52 = 1.0 - System.Math.Pow (num13 / num24, 2.0);
				if (num52 < 0.9999 && num38 > 0f && num50 > 0f) {
					float num56 = 1f / num38;
					float num54 = 1f / num50;
					float num55 = (float)(((double)(num56 + num54) - System.Math.Sqrt (System.Math.Pow (num56 + num54, 2.0) - 4.0 * num52 * (double)num56 * (double)num54)) / (2.0 * num52));
					if (1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text16;
					}
				}
				if (num33 > 0f && num7 > 0f) {
					float num53;
					float num56;
					float num57;
					if ((double)System.Math.Abs (num18) < 0.0001 * (double)(num16 + num17)) {
						num53 = 1f / num37;
						num56 = 1f / num38;
						num57 = 0f;
					} else {
						num53 = (float)((double)(num32 * num16) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
						num56 = (float)((double)(num32 * num17) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
						num57 = (float)((double)(num32 * num18) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
					}
					float num54 = 1f / num50;
					double num58 = 1.0 - System.Math.Pow (num13 / num24, 2.0) - System.Math.Pow (num12 / num24, 2.0);
					num52 = (double)num53 * (1.0 - System.Math.Pow (num13 / num24, 2.0)) + (double)num56 * (1.0 - System.Math.Pow (num12 / num24, 2.0)) + (double)num54 - (double)(2f * num57 * num12 * num13) / System.Math.Pow (num24, 2.0);
					double num59 = (double)(num53 * num56 + num53 * num54 + num56 * num54) - System.Math.Pow (num57, 2.0);
					double num60 = ((double)(num53 * num56) - System.Math.Pow (num57, 2.0)) * (double)num54;
					num52 /= num58;
					num59 /= num58;
					num60 /= num58;
					double num29 = num52 * num52 / 9.0 - num59 / 3.0;
					double num61 = num52 * num52 * num52 / 27.0 - num52 * num59 / 6.0 + num60 / 2.0;
					if (num29 < 0.0) {
						num29 = 0.0;
					}
					if (System.Math.Abs (num61) > System.Math.Pow (num29, 1.5)) {
						num61 = (double)System.Math.Sign (num61) * System.Math.Pow (num29, 1.5);
					}
					float num62 = ((!(num29 > 0.0)) ? 0f : ((float)System.Math.Acos (num61 / System.Math.Pow (num29, 1.5))));
					float num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (num62 / 3f) + num52 / 3.0);
					if (num55 > 0f && (double)(1f / num55) > 1.0001 * (double)num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
					num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (((double)num62 + System.Math.PI * 2.0) / 3.0) + num52 / 3.0);
					if (num55 > 0f && (double)(1f / num55) > 1.0001 * (double)num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
					num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (((double)num62 + System.Math.PI * 4.0) / 3.0) + num52 / 3.0);
					if (num55 > 0f && (double)(1f / num55) > 1.0001 * (double)num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
				}
			} else {
				if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
					flag2 = true;
				}
				num51 = (float)CFS.Max (num37, num38, num39);
				text47 = text15;
				if (num50 > num51) {
					num51 = num50;
					text47 = text13;
				}
				if (num37 > 0f && num50 > 0f) {
					float num53 = 1f / num37;
					float num63 = num7;
					if (((double)Param.Lt < 0.99 * (double)num5) & ((double)Param.Kt > 0.7) & (Param.Kt <= 1f) & (Param.Kx <= 1f)) {
						num63 = (float)(0.7 * (double)Param.Lt);
					}
					if (num63 > num5) {
						num63 = num5;
					}
					float num54 = (float)(((double)(Material.Eo [5] * num20) + (double)(num32 * num21) / System.Math.Pow (num63, 2.0)) / ((double)a * System.Math.Pow (num24, 2.0)));
					double num52 = 1.0 - System.Math.Pow (num12 / num24, 2.0) * System.Math.Pow (num63 / num5, 2.0);
					float num55 = (float)(((double)(num53 + num54) - System.Math.Sqrt (System.Math.Pow (num53 + num54, 2.0) - 4.0 * num52 * (double)num53 * (double)num54)) / (2.0 * num52));
					if (1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text16;
					}
				}
				if (num38 > 0f && num50 > 0f) {
					float num56 = 1f / num38;
					float num63 = num7;
					if (((double)Param.Lt < 0.99 * (double)num6) & ((double)Param.Kt > 0.7) & (Param.Kt <= 1f) & (Param.Ky <= 1f)) {
						num63 = (float)(0.7 * (double)Param.Lt);
					}
					if (num63 > num6) {
						num63 = num6;
					}
					float num54 = (float)(((double)(Material.Eo [5] * num20) + (double)(num32 * num21) / System.Math.Pow (num63, 2.0)) / ((double)a * System.Math.Pow (num24, 2.0)));
					double num52 = 1.0 - System.Math.Pow (num13 / num24, 2.0) * System.Math.Pow (num63 / num6, 2.0);
					float num55 = (float)(((double)(num56 + num54) - System.Math.Sqrt (System.Math.Pow (num56 + num54, 2.0) - 4.0 * num52 * (double)num56 * (double)num54)) / (2.0 * num52));
					if (1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text16;
					}
				}
				if (num33 > 0f && num7 > 0f) {
					float num53 = (float)((double)(num32 * num16) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
					float num56 = (float)((double)(num32 * num17) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
					float num57 = (float)((double)(num32 * num18) / ((double)a * System.Math.Pow (num33, 2.0)) * (double)num36 / (double)num39);
					float num63 = num7;
					if (((double)Param.Lt < 0.99 * (double)num33) & ((double)Param.Kt > 0.7) & (Param.Kt <= 1f) & (Param.Kx <= 1f) & (Param.Ky <= 1f)) {
						num63 = (float)(0.7 * (double)Param.Lt);
					}
					if (num63 > num33) {
						num63 = num33;
					}
					float num54 = (float)(((double)(Material.Eo [5] * num20) + (double)(num32 * num21) / System.Math.Pow (num63, 2.0)) / ((double)a * System.Math.Pow (num24, 2.0)));
					double num58 = 1.0 - System.Math.Pow (num13 / num24, 2.0) * System.Math.Pow (num63 / num33, 2.0) - System.Math.Pow (num12 / num24, 2.0) * System.Math.Pow (num63 / num33, 2.0);
					double num52 = (double)num53 * (1.0 - System.Math.Pow (num13 / num24, 2.0) * System.Math.Pow (num63 / num33, 2.0)) + (double)num56 * (1.0 - System.Math.Pow (num12 / num24, 2.0) * System.Math.Pow (num63 / num33, 2.0)) + (double)num54 - (double)(2f * num57 * num12 * num13) / System.Math.Pow (num24, 2.0) * System.Math.Pow (num63 / num33, 2.0);
					double num59 = (double)(num53 * num56 + num53 * num54 + num56 * num54) - System.Math.Pow (num57, 2.0);
					double num60 = ((double)(num53 * num56) - System.Math.Pow (num57, 2.0)) * (double)num54;
					num52 /= num58;
					num59 /= num58;
					num60 /= num58;
					double num29 = num52 * num52 / 9.0 - num59 / 3.0;
					double num61 = num52 * num52 * num52 / 27.0 - num52 * num59 / 6.0 + num60 / 2.0;
					if (num29 < 0.0) {
						num29 = 0.0;
					}
					if (System.Math.Abs (num61) > System.Math.Pow (num29, 1.5)) {
						num61 = (double)System.Math.Sign (num61) * System.Math.Pow (num29, 1.5);
					}
					float num62 = ((!(num29 > 0.0)) ? 0f : ((float)System.Math.Acos (num61 / System.Math.Pow (num29, 1.5))));
					float num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (num62 / 3f) + num52 / 3.0);
					if (num55 > 0f && 1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
					num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (((double)num62 + System.Math.PI * 2.0) / 3.0) + num52 / 3.0);
					if (num55 > 0f && 1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
					num55 = (float)(2.0 * System.Math.Sqrt (num29) * System.Math.Cos (((double)num62 + System.Math.PI * 4.0) / 3.0) + num52 / 3.0);
					if (num55 > 0f && 1f / num55 > num51) {
						num51 = 1f / num55;
						text47 = text17;
					}
				}
				if (num50 > 0f) {
					double num58 = System.Math.Pow (num13 / num24, 2.0) * (double)num16 + System.Math.Pow (num12 / num24, 2.0) * (double)num17 + (double)(2f * num12 * num13) / System.Math.Pow (num24, 2.0) * (double)num18;
					double num52 = (double)num32 / ((double)a * System.Math.Pow (num7, 2.0)) * ((double)(num16 * num17) - System.Math.Pow (num18, 2.0));
					if (num58 > 1E-06 * num52 * (double)num50) {
						float num55 = (float)(0.5 * (0.0 - num52 + System.Math.Sqrt (System.Math.Pow (num52, 2.0) + 4.0 * num58 * num52 / (double)num50)) / num58);
						if (1f / num55 > num51) {
							num51 = 1f / num55;
							text47 = text3;
						}
					}
				}
				if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
					text47 = "Analytical";
				}
			}
			if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
				if (num51 > 0f) {
					CFS.strTrace = CFS.strTrace + "  " + text45 + "=" + Units.DisplayStress (1f / num51, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
				} else {
					CFS.strTrace = CFS.strTrace + "  " + text45 + "=infinity\r\n";
				}
			} else if (num51 > 0f) {
				CFS.strTrace = CFS.strTrace + "  Pcre=" + Units.DisplayForce (a / num51, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Fcre=" + Units.DisplayStress (1f / num51, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			} else {
				CFS.strTrace += "  Pcre=infinity\r\n";
			}
			float num64 = (float)System.Math.Sqrt (Stress.Fyacn * num51);
			CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (Stress.Fyacn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
			CFS.strTrace = CFS.strTrace + "  λc=" + Units.DisplayNone (num64, "", 0, 0) + "\t" + text18 + "\r\n";
			if (flag) {
				num65 = 1.8f;
				num66 = 0.9f;
				if ((double)num64 <= 1.8) {
					num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.46, System.Math.Pow (num64, 1.18)), 1.2 * System.Math.Pow (0.41, System.Math.Pow (num64, 1.13))), Stress.Fyacn));
					if (num67 > Stress.Fyacn) {
						num67 = Stress.Fyacn;
					}
					CFS.strTrace = CFS.strTrace + "  Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
				} else {
					num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.82 / (double)num51, 0.69 / (double)num51));
					CFS.strTrace = CFS.strTrace + "  Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text20 + "\r\n";
				}
			} else {
				num65 = 1.8f;
				num66 = 0.85f;
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num66 = 0.8f;
				}
				if ((double)num64 <= 1.5) {
					num67 = (float)(System.Math.Pow (0.658, num64 * num64) * (double)Stress.Fyacn);
					CFS.strTrace = CFS.strTrace + "  Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
				} else {
					num67 = (float)(0.877 / (double)num51);
					CFS.strTrace = CFS.strTrace + "  Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text20 + "\r\n";
				}
			}
			num68 = num67 * a;
			CFS.strTrace = CFS.strTrace + "  Pne=" + Units.DisplayForce (num68, 0, blnShowUnit: true, "", 0, 0) + "\t" + text21 + "\r\n";
			if ((num41 > 200f) & (Param.P > 0f)) {
				Check.Msg += "KL/r exceeds 200.\r\n";
			}
		} else {
			CFS.strTrace += "Axial Tension Strength - see fully braced strength report\r\n\r\n";
			Check.Pa = Strength.Ta;
			Check.QPn = Strength.QTn;
		}
		float num75 = default(float);
		if (IsCylinder ()) {
			if (Param.P >= 0f) {
				float thickness = Part [1].Thickness;
				float num69 = 2f * (Part [1].Element [1].Rad + thickness);
				float num70;
				float num71;
				if (flag) {
					num70 = 1.9f;
					num71 = 0.85f;
					float num72 = Material.FprFy (2);
					float num73 = (float)(((double)((1f - num72) * (num / Stress.Fyacg) / (num69 / thickness)) + 5.882 * (double)num72) / (8.93 - 3.048 * (double)num72));
					if (num73 > 1f) {
						num73 = 1f;
					}
					PropEff.A = (float)(((double)num73 + System.Math.Pow (Material.EtEo (num67, 2), 2.0) * (double)(1f - num73)) * (double)a);
				} else {
					num70 = num65;
					num71 = num66;
					float num73 = (float)(0.037 * (double)(num / Stress.Fyacg) / (double)(num69 / thickness) + 0.667);
					if (num73 > 1f) {
						num73 = 1f;
					}
					float num47 = Stress.Fyacg * num51 / 2f;
					if (num47 > 1f) {
						num47 = 1f;
					}
					PropEff.A = (num73 + num47 * (1f - num73)) * a;
				}
				float num74 = num67 * PropEff.A;
				CFS.strTrace = CFS.strTrace + "  Ae=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty + "\r\n";
				CFS.strTrace = CFS.strTrace + "  Pn=" + Units.DisplayForce (num74, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty2 + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ωc=" + Conversions.ToString (num70) + ", φc=" + Conversions.ToString (num71), Interaction.IIf (num70 == num25 && num71 == num26, " (rational analysis)", "")), "\r\n"), "\r\n")));
				Check.Pa = num74 / num70;
				num75 = num70;
				if (Check.Pa > Strength.Pao) {
					Check.Pa = Strength.Pao;
				}
				Check.QPn = num71 * num74;
				if (Check.QPn > Strength.QPno) {
					Check.QPn = Strength.QPno;
				}
			}
			CFS.strTrace += "Flexural Strength - see fully braced strength report\r\n\r\n";
			Check.Cbx = 1f;
			Check.Cby = 1f;
			Check.Max = Strength.Maxop;
			Check.QMnx = Strength.QMnxop;
			Check.May = Strength.Mayop;
			Check.QMny = Strength.QMnyop;
			Check.Maxt = Strength.Maxtop;
			Check.QMnxt = Strength.QMnxtop;
			Check.Mayt = Strength.Maytop;
			Check.QMnyt = Strength.QMnytop;
		} else {
			if (Param.P >= 0f) {
				float num70 = num65;
				float num71 = num66;
				if (flag2) {
					num70 = num25;
					num71 = num26;
				}
				float num74;
				string text48;
				if (DSM.UseDSM & (DSM.Pcrl > 0f)) {
					float num76 = DSM.Pcrl * a * num2;
					CFS.strTrace += "  Local buckling (DSM)\r\n";
					CFS.strTrace = CFS.strTrace + "    Pcrl=" + Units.DisplayForce (num76, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float num77 = (float)System.Math.Sqrt (num68 / num76);
					if (flag) {
						if ((double)num77 <= 0.55) {
							num74 = num68;
							text48 = text39;
						} else {
							num74 = (float)((0.95 - 0.22 * System.Math.Pow (num76 / num68, 0.5)) * System.Math.Pow (num76 / num68, 0.5) * (double)num68);
							text48 = text40;
						}
					} else if ((double)num77 <= 0.776) {
						num74 = num68;
						text48 = text39;
					} else {
						num74 = (float)((1.0 - 0.15 * System.Math.Pow (num76 / num68, 0.4)) * System.Math.Pow (num76 / num68, 0.4) * (double)num68);
						text48 = text40;
					}
					float num78 = Prop.An * Stress.Fyacn;
					if (num74 > num78) {
						num74 = num78;
						text48 = text41;
					}
				} else {
					CFS.strTrace += "  Local buckling (EWM)\r\n";
					effectiveProperties.ResetProp (this, 0);
					effectiveProperties.EffProp (this, PropEff.A * num67, 0f, 0f, 0, (short)Param.Spec);
					if (CFS.blnTraceEffProp) {
						CFS.strTrace += PropEff.Trace;
					}
					num74 = PropEff.A * num67;
					text48 = text22;
					if (PropEff.RationalAnalysis) {
						num70 = num25;
						num71 = num26;
					}
					CFS.strTrace = CFS.strTrace + "    Ae=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				if (!Strength.PQual) {
					num70 = num25;
					num71 = num26;
				}
				Check.Pa = num74 / num70;
				num75 = num70;
				Check.QPn = num71 * num74;
				CFS.strTrace = CFS.strTrace + "    Pnl=" + Units.DisplayForce (num74, 0, blnShowUnit: true, "", 0, 0) + "\t" + text48 + "\r\n";
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωc=" + Conversions.ToString (num70) + ", φc=" + Conversions.ToString (num71), Interaction.IIf (num70 == num25 && num71 == num26, " (rational analysis)", "")), "\r\n")));
				num70 = num65;
				num71 = num66;
				if (Param.Lm > 0f) {
					float num79 = a * num3;
					float num78 = Prop.An * num3;
					float num80;
					if (DSM.UseDSM & (DSM.Pcrd > 0f)) {
						num80 = DSM.Pcrd * a * num2;
						strTraceDB = "  Distortional buckling (DSM)\r\n";
						ref string reference = ref strTraceDB;
						reference = reference + "    Pcrd=" + Units.DisplayForce (num80, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (CFS.SpecYear ((short)Param.Spec) < 2012 && !flag) {
							num78 = num79;
						}
					} else {
						if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
							num79 = a * Stress.Fyacg;
							num78 = num79;
						}
						num80 = DistortionalBucklingLoad (Param);
					}
					if (CFS.SpecYear ((short)Param.Spec) > 2016 && !flag) {
						num79 = a * Stress.Fyacg;
						num78 = Prop.An * Stress.Fyacn;
					}
					if (!Strength.PQual) {
						num70 = num25;
						num71 = num26;
					}
					float num77 = (float)System.Math.Sqrt (num79 / num80);
					float num81;
					float num82;
					float num83;
					if (flag) {
						num81 = (float)(0.533 * (double)num78 / (double)num79);
						num82 = (float)(0.533 * (14.0 * System.Math.Pow (num79 / num78, 0.4) - 13.0));
						num83 = ((!Material.IsFerritic ()) ? ((float)((double)num79 * (0.8 - 0.15 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))) : ((float)((double)num79 * (0.9 - 0.2 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))));
					} else {
						num81 = (float)(0.561 * (double)num78 / (double)num79);
						num82 = (float)(0.561 * (14.0 * System.Math.Pow (num79 / num78, 0.4) - 13.0));
						num83 = (float)((double)num79 * (1.0 - 0.25 / System.Math.Pow (num82, 1.2)) / System.Math.Pow (num82, 1.2));
					}
					float num84;
					string text49;
					if (num77 <= num81) {
						num84 = num78;
						text49 = text4;
						if (CFS.SpecYear ((short)Param.Spec) == 2016 || flag) {
							num84 = (float)((double)Prop.An * CFS.Min ((double)num80 * System.Math.Pow (num81, 2.0) / (double)a, Stress.Fyac));
						}
					} else if (num77 <= num82) {
						num84 = num78 - (num78 - num83) * (num77 - num81) / (num82 - num81);
						text49 = text5;
					} else if (flag) {
						if (Material.IsFerritic ()) {
							num84 = (float)((0.9 - 0.2 * System.Math.Pow (num80 / num79, 0.55)) * System.Math.Pow (num80 / num79, 0.55) * (double)num79);
							text49 = text6;
						} else {
							num84 = (float)((0.8 - 0.15 * System.Math.Pow (num80 / num79, 0.55)) * System.Math.Pow (num80 / num79, 0.55) * (double)num79);
							text49 = text6;
						}
					} else {
						num84 = (float)((1.0 - 0.25 * System.Math.Pow (num80 / num79, 0.6)) * System.Math.Pow (num80 / num79, 0.6) * (double)num79);
						text49 = text6;
					}
					if (num84 / num70 < Check.Pa) {
						Check.Pa = num84 / num70;
						num75 = num70;
					}
					if (num71 * num84 < Check.QPn) {
						Check.QPn = num71 * num84;
					}
					if (num77 > num81 / 2f) {
						CFS.strTrace += strTraceDB;
						CFS.strTrace = CFS.strTrace + "    Pnd=" + Units.DisplayForce (num84, 0, blnShowUnit: true, "", 0, 0) + "\t" + text49 + "\r\n";
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωc=" + Conversions.ToString (num70) + ", φc=" + Conversions.ToString (num71), Interaction.IIf (num70 == num25 && num71 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				if (Check.Pa > Strength.Pao) {
					Check.Pa = Strength.Pao;
				}
				if (Check.QPn > Strength.QPno) {
					Check.QPn = Strength.QPno;
				}
				if ((Param.iBrcFlg != Flanges.flgNone) & (nPart == 1) & !Part [nPart].Closed) {
					float num85 = num65;
					float num86 = num66;
					CFS.strTrace += "  One Flange Braced\r\n";
					bool flag3 = false;
					float thickness = Part [nPart].Thickness;
					float num69 = default(float);
					if ((Param.iBrcFlg == Flanges.flgBottom) | (Param.iBrcFlg == Flanges.flgTop)) {
						num69 = Ymax - Ymin;
					}
					if ((Param.iBrcFlg == Flanges.flgLeft) | (Param.iBrcFlg == Flanges.flgRight)) {
						num69 = Xmax - Xmin;
					}
					short num87 = Part [nPart].FlangeElement ((byte)Param.iBrcFlg);
					float num88;
					float num90;
					if (num87 > 0) {
						num88 = Part [nPart].Element [num87].Len;
						if (Part [nPart].Centerline) {
							num88 = (float)((double)num88 + (double)(thickness / 2f) * System.Math.Tan (System.Math.Abs (Part [nPart].Element [num87].Arc) / 2f));
							short num89 = (short)((num87 >= Part [nPart].nElem) ? 1 : checked((short)(num87 + 1)));
							num88 = (float)((double)num88 + (double)(thickness / 2f) * System.Math.Tan (System.Math.Abs (Part [nPart].Element [num89].Arc) / 2f));
						}
						num90 = Part [nPart].Element [num87].Wid;
					} else {
						num88 = 0f;
						num90 = 0f;
						flag3 = true;
					}
					float num91 = 0.5f;
					float num92 = (float)(0.79 * (double)num91 + 0.54);
					float num93 = (float)(1.17 * (double)thickness + 0.93);
					float num94 = (float)(2.5 * (double)num88 - 1.63 * (double)num69 + 22.8);
					if (num94 < 0f) {
						num94 = 0f;
					}
					num74 = num92 * num93 * num94 * Part [nPart].A * num / 29500f;
					if ((double)thickness > 0.125 || num69 < 6f || num69 > 12f) {
						flag3 = true;
					}
					if (num87 == 1) {
						flag3 = true;
					}
					if (num87 == Part [nPart].nElem) {
						flag3 = true;
					}
					if (num69 < 70f * thickness || num69 > 170f * thickness) {
						flag3 = true;
					}
					if ((double)num69 < 2.8 * (double)num88 || num69 > 5f * num88) {
						flag3 = true;
					}
					if (num90 < 16f * thickness || num90 > 50f * thickness) {
						flag3 = true;
					}
					if (num3 < 33f) {
						flag3 = true;
					}
					if (num5 > 396f || num6 > 396f || num7 > 396f) {
						flag3 = true;
					}
					if (flag3) {
						num85 = num25;
						num86 = num26;
					}
					float num95 = num74 / num85;
					float num96 = num86 * num74;
					CFS.strTrace = CFS.strTrace + "    C1=" + Units.DisplayNone (num92, "", 0, 0) + "\t" + text23 + "\r\n";
					CFS.strTrace = CFS.strTrace + "    C2=" + Units.DisplayNone (num93, "", 0, 0) + "\t" + text24 + "\r\n";
					CFS.strTrace = CFS.strTrace + "    C3=" + Units.DisplayNone (num94, "", 0, 0) + "\t" + text25 + "\r\n";
					CFS.strTrace = CFS.strTrace + "    Pn=" + Units.DisplayForce (num74, 0, blnShowUnit: true, "", 0, 0) + "\t" + text26 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωc=" + Conversions.ToString (num85) + ", φc=" + Conversions.ToString (num86), Interaction.IIf (num85 == num25 && num86 == num26, " (rational analysis)", "")), "\r\n")));
					if (Param.P > 0f) {
						short num97 = CFS.SpecYear ((short)Param.Spec);
						string text50 = ((num97 <= 1999) ? "C4.4" : ((num97 <= 2004) ? "C4.6" : ((num97 > 2012) ? "I6.2.3" : "D6.1.3")));
						if (flag) {
							text50 = "I6.2.3 (S100-16)";
						}
						if (flag3) {
							ref string msg = ref Check.Msg;
							msg = msg + "Section does not meet all requirements of section " + text50 + ".\r\n";
						}
						ref string msg2 = ref Check.Msg;
						msg2 = msg2 + "Value of x in " + text50 + " assumed to be 0.5.\r\n";
					}
					if ((Param.iBrcFlg == Flanges.flgBottom) | (Param.iBrcFlg == Flanges.flgTop)) {
						num51 = num37;
					}
					if ((Param.iBrcFlg == Flanges.flgLeft) | (Param.iBrcFlg == Flanges.flgRight)) {
						num51 = num38;
					}
					CFS.strTrace += "  Buckling about axis parallel to sheathing\r\n";
					CFS.strTrace = CFS.strTrace + "    KL/r=" + Units.DisplayNone ((float)System.Math.Sqrt (num51 * num32), "", 0, 0) + "\r\n";
					if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
						CFS.strTrace = CFS.strTrace + "    " + text45 + "=" + Units.DisplayStress (1f / num51, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					} else {
						CFS.strTrace = CFS.strTrace + "    Pcre=" + Units.DisplayForce (a / num51, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					float num64 = (float)System.Math.Sqrt (Stress.Fyacn * num51);
					CFS.strTrace = CFS.strTrace + "    Fy=" + Units.DisplayStress (Stress.Fyacn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    λc=" + Units.DisplayNone (num64, "", 0, 0) + "\t" + text18 + "\r\n";
					if (flag) {
						if ((double)num64 <= 1.8) {
							num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.46, System.Math.Pow (num64, 1.18)), 1.2 * System.Math.Pow (0.41, System.Math.Pow (num64, 1.13))), Stress.Fyacn));
							if (num67 > Stress.Fyacn) {
								num67 = Stress.Fyacn;
							}
							CFS.strTrace = CFS.strTrace + "    Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
						} else {
							num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.82 / (double)num51, 0.69 / (double)num51));
							CFS.strTrace = CFS.strTrace + "    Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text20 + "\r\n";
						}
					} else if ((double)num64 <= 1.5) {
						num67 = (float)(System.Math.Pow (0.658, num64 * num64) * (double)Stress.Fyacn);
						CFS.strTrace = CFS.strTrace + "    Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text19 + "\r\n";
					} else {
						num67 = (float)(0.877 / (double)num51);
						CFS.strTrace = CFS.strTrace + "    Fn=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text20 + "\r\n";
					}
					num68 = num67 * a;
					CFS.strTrace = CFS.strTrace + "    Pne=" + Units.DisplayForce (num68, 0, blnShowUnit: true, "", 0, 0) + "\t" + text21 + "\r\n";
					num70 = num65;
					num71 = num66;
					if (DSM.UseDSM & (DSM.Pcrl > 0f)) {
						float num76 = DSM.Pcrl * a * num2;
						CFS.strTrace += "  Local buckling (DSM)\r\n";
						CFS.strTrace = CFS.strTrace + "    Pcrl=" + Units.DisplayForce (num76, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						float num77 = (float)System.Math.Sqrt (num68 / num76);
						if (flag) {
							if ((double)num77 <= 0.55) {
								num74 = num68;
								text48 = text39;
							} else {
								num74 = (float)((0.95 - 0.22 * System.Math.Pow (num76 / num68, 0.5)) * System.Math.Pow (num76 / num68, 0.5) * (double)num68);
								text48 = text40;
							}
						} else if ((double)num77 <= 0.776) {
							num74 = num68;
							text48 = text39;
						} else {
							num74 = (float)((1.0 - 0.15 * System.Math.Pow (num76 / num68, 0.4)) * System.Math.Pow (num76 / num68, 0.4) * (double)num68);
							text48 = text40;
						}
						float num78 = Prop.An * Stress.Fyacn;
						if (num74 > num78) {
							num74 = num78;
							text48 = text41;
						}
					} else {
						CFS.strTrace += "  Local buckling (EWM)\r\n";
						effectiveProperties.ResetProp (this, 0);
						effectiveProperties.EffProp (this, PropEff.A * num67, 0f, 0f, 0, (short)Param.Spec);
						if (CFS.blnTraceEffProp) {
							CFS.strTrace += PropEff.Trace;
						}
						num74 = PropEff.A * num67;
						text48 = text22;
						if (PropEff.RationalAnalysis) {
							num70 = num25;
							num71 = num26;
						}
						CFS.strTrace = CFS.strTrace + "    Ae=" + Units.DisplayLen2 (PropEff.A, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					if (!Strength.PQual) {
						num70 = num25;
						num71 = num26;
					}
					CFS.strTrace = CFS.strTrace + "    Pnl=" + Units.DisplayForce (num74, 0, blnShowUnit: true, "", 0, 0) + "\t" + text48 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωc=" + Conversions.ToString (num70) + ", φc=" + Conversions.ToString (num71), Interaction.IIf (num70 == num25 && num71 == num26, " (rational analysis)", "")), "\r\n")));
					if (num74 / num70 < num95) {
						num95 = num74 / num70;
						num85 = num70;
					}
					if (num71 * num74 < num96) {
						num96 = num71 * num74;
						num86 = num71;
					}
					if (num95 > Strength.Pao) {
						num95 = Strength.Pao;
					}
					if (num96 > Strength.QPno) {
						num96 = Strength.QPno;
					}
					if (num95 > Check.Pa) {
						Check.Pa = num95;
						num75 = num85;
					}
					if (num96 > Check.QPn) {
						Check.QPn = num96;
					}
				}
				CFS.strTrace += "\r\n";
			}
			Check.Cbx = Param.Cbx1;
			Check.Cby = Param.Cby1;
			float num98;
			float num99;
			float num100;
			float num101;
			float num102;
			short num103;
			if (flag) {
				num98 = 1.8f;
				num99 = 0.9f;
				num100 = 0.9f;
				num101 = 0.9f;
				num102 = 0.9f;
				if ((Param.Ky > 1f) | (Param.Kt > 1f)) {
					Check.Cbx = 1f;
				}
				if ((Param.Kx > 1f) | (Param.Kt > 1f)) {
					Check.Cby = 1f;
				}
				num103 = 0;
			} else {
				num98 = 1.67f;
				num99 = 0.9f;
				num100 = 0.9f;
				num101 = 0.9f;
				num102 = 0.9f;
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					if (CFS.SpecYear ((short)Param.Spec) < 2016) {
						num100 = 0.85f;
						num101 = 0.85f;
					}
					if (CFS.SpecYear ((short)Param.Spec) < 2007) {
						num102 = 0.8f;
					}
				}
				if (System.Math.Abs (num15) > 0.001f * num24) {
					if ((Param.Cbx2 > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2022)) {
						Check.Cbx = Param.Cbx2;
						if ((double)Check.Cbx > 3.1) {
							Check.Cbx = 3.1f;
						}
						Check.Cbx = (float)(1.0 / (1.3 - System.Math.Sqrt (0.49 - 0.16 * (1.75 - (double)Check.Cbx) / 0.3)));
					}
				} else if ((Param.Ky > 1f) | (Param.Kt > 1f)) {
					Check.Cbx = 1f;
				}
				if (System.Math.Abs (num14) > 0.001f * num24) {
					if ((Param.Cby2 > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2022)) {
						Check.Cby = Param.Cby2;
						if ((double)Check.Cby > 3.1) {
							Check.Cby = 3.1f;
						}
						Check.Cby = (float)(1.0 / (1.3 - System.Math.Sqrt (0.49 - 0.16 * (1.75 - (double)Check.Cby) / 0.3)));
					}
				} else if ((Param.Kx > 1f) | (Param.Kt > 1f)) {
					Check.Cby = 1f;
				}
				num103 = Conversions.ToShort (Interaction.IIf (CFS.SpecYear ((short)Param.Spec) < 2016, EffectivePropertiesTypes.effGross, EffectivePropertiesTypes.effNet));
			}
			string text51 = "see fully braced strength report for Mnl calculation\r\n";
			CFS.strTrace += "Flexural Strength about X-axis\r\n";
			if (Prop.An < a && num8 > 0f) {
				CFS.strTrace += "  Reduced section properties used to account for holes\r\n";
			}
			if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
				CFS.strTrace += "  σey=";
				if (num35 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num35, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text12 + "\r\n";
				CFS.strTrace += "  σt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			} else {
				CFS.strTrace += "  Pey=";
				if (num35 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num35, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text12 + "\r\n";
				CFS.strTrace += "  Pt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			}
			if (((System.Math.Abs (num15) <= num24 * 0.001f) | (CFS.SpecYear ((short)Param.Spec) >= 2022)) || flag) {
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  Cb=" + Units.DisplayNone (Check.Cbx, "", 0, 0) + "\t", Interaction.IIf (Param.Analysis, truePart, string.Empty)), "\r\n")));
			} else {
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ctf=" + Units.DisplayNone (1f / Check.Cbx, "", 0, 0) + "\t", Interaction.IIf (Param.Analysis, truePart2, string.Empty)), "\r\n")));
			}
			if (Check.Mx >= 0f) {
				float num104 = (Check.Max = Strength.Maxop);
				float num105 = (Check.QMnx = Strength.QMnxop);
				Check.Maxt = Strength.Maxtop;
				Check.QMnxt = Strength.QMnxtop;
				float num110;
				float num111;
				if ((num50 == 0f || (num35 == 0f && num15 <= num24 * 0.001f)) | (Param.iBrcFlg == Flanges.flgTop)) {
					CFS.strTrace = CFS.strTrace + "  Fully braced, " + text51;
				} else {
					flag2 = false;
					float num106;
					string text47;
					if (num35 == 0f) {
						num106 = (float)((double)(Check.Cbx * a) * System.Math.Pow (num24, 2.0) / (double)(2f * num50 * num15));
						text47 = text28;
					} else if (IsLTBZee (LoadDirections.dirY) & !Param.BucklingTheory) {
						num106 = (float)((double)(Check.Cbx * a * num24 / 2f) / System.Math.Sqrt (num35 * num50));
						text47 = text27;
					} else {
						num106 = (float)((double)(Check.Cbx * a * num40 / num35) * ((double)(0f - num15) + System.Math.Sqrt (num15 * num15 + num24 * num24 * num35 / num40 / num50)));
						text47 = Conversions.ToString (Interaction.IIf (HasSymmetry (Symmetry.Principal), RuntimeHelpers.GetObjectValue (Interaction.IIf (HasSymmetry (Symmetry.PrincipalX), truePart3, text28)), "Analytical"));
						if ((!HasSymmetry (Symmetry.Principal) & (CFS.SpecYear ((short)Param.Spec) < 2016)) && !flag) {
							flag2 = true;
						}
					}
					float sxt = Prop.Sxt;
					float num55 = num106 / sxt;
					if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
						CFS.strTrace = CFS.strTrace + "  " + text45 + "=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					} else {
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fcre=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					string text52 = string.Empty;
					float fyaxpg = Stress.Fyaxpg;
					float num107 = Prop.Sx * fyaxpg;
					CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (fyaxpg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float num108;
					if (flag) {
						float num77 = (float)System.Math.Sqrt (fyaxpg / num55);
						if (Operators.ConditionalCompareObjectLessEqual (num77, Interaction.IIf (Material.IsFerritic (), 0.41, 0.35), TextCompare: false)) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num77 <= 1.6) {
							num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.49, System.Math.Pow (num77, 1.55)), 1.2 * System.Math.Pow (0.44, System.Math.Pow (num77, 1.44))), fyaxpg));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.7 * (double)num55, 0.61 * (double)num55));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					} else if (DSM.UseDSM & (DSM.Mcrlxp > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2016)) {
						if (!((double)num106 >= 2.7777777777777777 * (double)num107)) {
							num108 = ((!((double)num106 >= 5.0 / 9.0 * (double)num107)) ? num106 : ((float)((double)num107 / 0.9 * (1.0 - (double)(num107 / num106) / 3.6))));
						} else {
							num108 = num107;
							text52 = "  Mne >= My, ";
						}
						num67 = num108 / sxt;
					} else {
						if ((double)num55 >= 2.7777777777777777 * (double)fyaxpg) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num55 >= 5.0 / 9.0 * (double)fyaxpg) {
							num67 = (float)((double)fyaxpg / 0.9 * (1.0 - (double)(fyaxpg / num55) / 3.6));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = num55;
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					}
					CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text32 + "\r\n";
					if ((DSM.UseDSM & (DSM.Mcrlxp > 0f)) && num108 >= num107) {
						text52 = "  Mne >= My, ";
					}
					if (Strings.Len (text52) > 0) {
						CFS.strTrace = CFS.strTrace + text52 + text51;
						num107 = Prop.Sx * num4;
						float num109 = Prop.Zx * num4;
						if ((Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) && (double)num106 > 2.78 * (double)num107) {
							num108 = (float)((double)num109 - (double)(num109 - num107) * (System.Math.Sqrt (num107 / num106) - 0.23) / 0.37);
							if (num108 > num109) {
								num108 = num109;
							}
							CFS.strTrace += "  Global inelastic reserve\r\n";
							CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (num107, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (num109, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							CFS.strTrace = CFS.strTrace + "    Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
							CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num98) + ", φb=" + Conversions.ToString (num100), Interaction.IIf (num98 == num25 && num100 == num26, " (rational analysis)", "")), "\r\n")));
							if (num108 / num98 < Check.Max) {
								Check.Max = num108 / num98;
							}
							if (num100 * num108 < Check.QMnx) {
								Check.QMnx = num100 * num108;
							}
						}
					} else {
						num110 = num98;
						num111 = num99;
						if (flag2) {
							num110 = num25;
							num111 = num26;
						}
						checked {
							float num113;
							if (DSM.UseDSM & (DSM.Mcrlxp > 0f)) {
								num111 = num100;
								float num112 = DSM.Mcrlxp * Prop.Sx * num2;
								CFS.strTrace += "  Local buckling (DSM)\r\n";
								CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num112, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								float num77 = (float)System.Math.Sqrt (num108 / num112);
								if (flag) {
									if ((double)num77 <= 0.667) {
										num113 = num108;
										empty3 = text42;
									} else {
										num113 = (float)((1.0 - 0.2 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
										empty3 = text43;
									}
								} else if ((double)num77 <= 0.776) {
									num113 = num108;
									empty3 = text42;
								} else {
									num113 = (float)((1.0 - 0.15 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
									empty3 = text43;
								}
								float num114 = Prop.Sxn * Stress.Fyaxpn;
								if (num113 > num114) {
									num113 = num114;
									empty3 = text44;
								}
							} else {
								CFS.strTrace += "  Local buckling (EWM)\r\n";
								effectiveProperties.ResetProp (this, (byte)num103);
								short num115 = 1;
								do {
									float num91 = PropEff.Sxt;
									effectiveProperties.EffProp (this, 0f, num67 * PropEff.Sxt, 0f, (byte)num103, unchecked((short)Param.Spec));
									if (!PropEff.Iterate || System.Math.Abs (PropEff.Sxt / num91 - 1f) < 0.001f) {
										break;
									}
									num115 = (short)unchecked(num115 + 1);
								} while (num115 <= 10);
								num113 = num67 * PropEff.Sxt;
								empty3 = text33;
								if (PropEff.RationalAnalysis) {
									num110 = num25;
									num111 = num26;
								}
								if (CFS.blnTraceEffProp) {
									CFS.strTrace += PropEff.Trace;
								}
								CFS.strTrace = CFS.strTrace + "    Center of gravity shift: y=" + Units.DisplayLen1 (PropEff.Ycg - Prop.Ycg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								CFS.strTrace = CFS.strTrace + "    Sec=" + Units.DisplayLen3 (PropEff.Sxt, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							}
							if (!Strength.MxpQual) {
								num110 = num25;
								num111 = num26;
							}
							if (num113 / num110 < Check.Max) {
								Check.Max = num113 / num110;
							}
							if (num111 * num113 < Check.QMnx) {
								Check.QMnx = num111 * num113;
							}
							CFS.strTrace = CFS.strTrace + "    Mnl=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty3 + "\r\n";
						}
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				num110 = num98;
				num111 = num101;
				if (Param.Lm > 0f) {
					float num107 = Prop.Sx * num4;
					float num114 = Prop.Sxn * num4;
					float num116;
					if (DSM.UseDSM & (DSM.Mcrdxp > 0f)) {
						num116 = DSM.Mcrdxp * Prop.Sx * num2;
						strTraceDB = "  Distortional buckling (DSM)\r\n";
						ref string reference2 = ref strTraceDB;
						reference2 = reference2 + "    Mcrd=" + Units.DisplayMoment (num116, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (CFS.SpecYear ((short)Param.Spec) < 2012 && !flag) {
							num114 = num107;
						}
					} else {
						if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
							num107 = Prop.Sx * Stress.Fyaxpg;
							num114 = num107;
						}
						num116 = DistortionalBucklingMoment (Param, 2);
					}
					if (CFS.SpecYear ((short)Param.Spec) > 2016 && !flag) {
						num107 = Prop.Sx * Stress.Fyaxpg;
						num114 = Prop.Sxn * Stress.Fyaxpn;
					}
					if (!Strength.MxpQual) {
						num110 = num25;
						num111 = num26;
					}
					float num77 = (float)System.Math.Sqrt (num107 / num116);
					float num81;
					float num82;
					float num117;
					if (flag) {
						num81 = (float)(0.533 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.533 * (14.0 * System.Math.Pow (num107 / num114, 0.4) - 13.0));
						num117 = ((!Material.IsFerritic ()) ? ((float)((double)num107 * (0.8 - 0.15 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))) : ((float)((double)num107 * (0.9 - 0.2 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))));
					} else {
						num81 = (float)(0.673 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.673 * (1.7 * System.Math.Pow (num107 / num114, 2.7) - 0.7));
						num117 = (float)((double)num107 * (1.0 - 0.22 / (double)num82) / (double)num82);
					}
					float num118;
					string text53;
					if (num77 <= num81) {
						num118 = num114;
						text53 = text7;
						if (CFS.SpecYear ((short)Param.Spec) == 2016 || flag) {
							num118 = (float)((double)Prop.Sxn * CFS.Min ((double)num116 * System.Math.Pow (num81, 2.0) / (double)Prop.Sx, Stress.Fyax));
						}
						if (Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) {
							float num119 = num81 / num77;
							if (num119 > 9f) {
								num119 = 9f;
							}
							float num120 = (Prop.Sxn + (1f - 1f / num119) * (Prop.Zxn - Prop.Sxn)) * num4;
							if (num120 > num118) {
								num118 = num120;
								text53 = text2;
								strTraceDB += "  Distortional inelastic reserve\r\n";
								ref string reference3 = ref strTraceDB;
								ref string reference4 = ref reference3;
								reference3 = reference4 + "    My=" + Units.DisplayMoment (Prop.Sxn * num4, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zxn * num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								ref string reference5 = ref strTraceDB;
								reference4 = ref reference5;
								reference5 = reference4 + "    λd=" + Units.DisplayNone (num77, "", 0, 0) + ", λd1=" + Units.DisplayNone (num81, "", 0, 0) + ", Cyd=" + Units.DisplayNone ((float)System.Math.Sqrt (num119), "", 0, 0) + "\r\n";
							}
						}
					} else if (num77 <= num82) {
						num118 = num114 - (num114 - num117) * (num77 - num81) / (num82 - num81);
						text53 = text8;
					} else if (flag) {
						if (Material.IsFerritic ()) {
							num118 = (float)((0.9 - 0.2 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						} else {
							num118 = (float)((0.8 - 0.15 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						}
					} else {
						num118 = (float)((1.0 - 0.22 * System.Math.Pow (num116 / num107, 0.5)) * System.Math.Pow (num116 / num107, 0.5) * (double)num107);
						text53 = text9;
					}
					if (num118 / num110 < Check.Max) {
						Check.Max = num118 / num110;
					}
					if (num111 * num118 < Check.QMnx) {
						Check.QMnx = num111 * num118;
					}
					if (Operators.ConditionalCompareObjectGreater (num77, Interaction.IIf (Reserve, num81 / 9f, num81 / 2f), TextCompare: false)) {
						CFS.strTrace += strTraceDB;
						CFS.strTrace = CFS.strTrace + "    Mnd=" + Units.DisplayMoment (num118, 0, blnShowUnit: true, "", 0, 0) + "\t" + text53 + "\r\n";
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				if ((Param.iBrcFlg == Flanges.flgBottom) & (Param.R > 0f)) {
					num110 = num98;
					num111 = num102;
					if (!Strength.MxpQual) {
						num110 = num25;
						num111 = num26;
					}
					float num113 = Param.R * Strength.Mnxop;
					CFS.strTrace += "  Tension flange braced\r\n";
					CFS.strTrace = CFS.strTrace + "    R=" + Units.DisplayNone (Param.R, "", 0, 0) + ",  Mnlo=" + Units.DisplayMoment (Strength.Mnxop, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    Mn=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + text34 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					if (Check.Max < num113 / num110) {
						Check.Max = num113 / num110;
					}
					if (Check.QMnx < num111 * num113) {
						Check.QMnx = num111 * num113;
					}
				}
				if (Check.Max > num104) {
					Check.Max = num104;
				}
				if (Check.QMnx > num105) {
					Check.QMnx = num105;
				}
				CFS.strTrace += "\r\n";
			}
			if (Check.Mx < 0f) {
				float num104 = (Check.Max = Strength.Maxon);
				float num105 = (Check.QMnx = Strength.QMnxon);
				Check.Maxt = Strength.Maxton;
				Check.QMnxt = Strength.QMnxton;
				float num110;
				float num111;
				if ((num50 == 0f || (num35 == 0f && num15 >= (0f - num24) * 0.001f)) | (Param.iBrcFlg == Flanges.flgBottom)) {
					CFS.strTrace = CFS.strTrace + "  Fully braced, " + text51;
				} else {
					flag2 = false;
					float num106;
					string text47;
					if (num35 == 0f) {
						num106 = (float)((double)(Check.Cbx * a) * System.Math.Pow (num24, 2.0) / (double)(2f * num50 * (0f - num15)));
						text47 = text28;
					} else if (IsLTBZee (LoadDirections.dirY) & !Param.BucklingTheory) {
						num106 = (float)((double)(Check.Cbx * a * num24 / 2f) / System.Math.Sqrt (num35 * num50));
						text47 = text27;
					} else {
						num106 = (float)((double)(Check.Cbx * a * num40 / num35) * ((double)num15 + System.Math.Sqrt (num15 * num15 + num24 * num24 * num35 / num40 / num50)));
						text47 = Conversions.ToString (Interaction.IIf (HasSymmetry (Symmetry.Principal), RuntimeHelpers.GetObjectValue (Interaction.IIf (HasSymmetry (Symmetry.PrincipalX), truePart3, text28)), "Analytical"));
						if ((!HasSymmetry (Symmetry.Principal) & (CFS.SpecYear ((short)Param.Spec) < 2016)) && !flag) {
							flag2 = true;
						}
					}
					float sxt = Prop.Sxb;
					float num55 = num106 / sxt;
					if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
						CFS.strTrace = CFS.strTrace + "  " + text45 + "=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					} else {
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fcre=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					string text52 = string.Empty;
					float fyaxpg = Stress.Fyaxng;
					float num107 = Prop.Sx * fyaxpg;
					CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (fyaxpg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float num108;
					if (flag) {
						float num77 = (float)System.Math.Sqrt (fyaxpg / num55);
						if (Operators.ConditionalCompareObjectLessEqual (num77, Interaction.IIf (Material.IsFerritic (), 0.41, 0.35), TextCompare: false)) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num77 <= 1.6) {
							num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.49, System.Math.Pow (num77, 1.55)), 1.2 * System.Math.Pow (0.44, System.Math.Pow (num77, 1.44))), fyaxpg));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.7 * (double)num55, 0.61 * (double)num55));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					} else if (DSM.UseDSM & (DSM.Mcrlxn > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2016)) {
						if (!((double)num106 >= 2.7777777777777777 * (double)num107)) {
							num108 = ((!((double)num106 >= 5.0 / 9.0 * (double)num107)) ? num106 : ((float)((double)num107 / 0.9 * (1.0 - (double)(num107 / num106) / 3.6))));
						} else {
							num108 = num107;
							text52 = "  Mne >= My, ";
						}
						num67 = num108 / sxt;
					} else {
						if ((double)num55 >= 2.7777777777777777 * (double)fyaxpg) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num55 >= 5.0 / 9.0 * (double)fyaxpg) {
							num67 = (float)((double)fyaxpg / 0.9 * (1.0 - (double)(fyaxpg / num55) / 3.6));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = num55;
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					}
					CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text32 + "\r\n";
					if ((DSM.UseDSM & (DSM.Mcrlxn > 0f)) && num108 >= num107) {
						text52 = "  Mne >= My, ";
					}
					if (Strings.Len (text52) > 0) {
						CFS.strTrace = CFS.strTrace + text52 + text51;
						num107 = Prop.Sx * num4;
						float num109 = Prop.Zx * num4;
						if ((Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) && (double)num106 > 2.78 * (double)num107) {
							num108 = (float)((double)num109 - (double)(num109 - num107) * (System.Math.Sqrt (num107 / num106) - 0.23) / 0.37);
							if (num108 > num109) {
								num108 = num109;
							}
							CFS.strTrace += "  Global inelastic reserve\r\n";
							CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (num107, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (num109, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							CFS.strTrace = CFS.strTrace + "    Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
							CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num98) + ", φb=" + Conversions.ToString (num100), Interaction.IIf (num98 == num25 && num100 == num26, " (rational analysis)", "")), "\r\n")));
							if (num108 / num98 < Check.Max) {
								Check.Max = num108 / num98;
							}
							if (num100 * num108 < Check.QMnx) {
								Check.QMnx = num100 * num108;
							}
						}
					} else {
						num110 = num98;
						num111 = num99;
						if (flag2) {
							num110 = num25;
							num111 = num26;
						}
						checked {
							float num113;
							if (DSM.UseDSM & (DSM.Mcrlxn > 0f)) {
								num111 = num100;
								float num112 = DSM.Mcrlxn * Prop.Sx * num2;
								CFS.strTrace += "  Local buckling (DSM)\r\n";
								CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num112, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								float num77 = (float)System.Math.Sqrt (num108 / num112);
								if (flag) {
									if ((double)num77 <= 0.667) {
										num113 = num108;
										empty3 = text42;
									} else {
										num113 = (float)((1.0 - 0.2 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
										empty3 = text43;
									}
								} else if ((double)num77 <= 0.776) {
									num113 = num108;
									empty3 = text42;
								} else {
									num113 = (float)((1.0 - 0.15 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
									empty3 = text43;
								}
								float num114 = Prop.Sxn * Stress.Fyaxnn;
								if (num113 > num114) {
									num113 = num114;
									empty3 = text44;
								}
							} else {
								CFS.strTrace += "  Local buckling (EWM)\r\n";
								effectiveProperties.ResetProp (this, (byte)num103);
								short num115 = 1;
								do {
									float num91 = PropEff.Sxb;
									effectiveProperties.EffProp (this, 0f, (0f - num67) * PropEff.Sxb, 0f, (byte)num103, unchecked((short)Param.Spec));
									if (!PropEff.Iterate || System.Math.Abs (PropEff.Sxb / num91 - 1f) < 0.001f) {
										break;
									}
									num115 = (short)unchecked(num115 + 1);
								} while (num115 <= 10);
								num113 = num67 * PropEff.Sxb;
								empty3 = text33;
								if (PropEff.RationalAnalysis) {
									num110 = num25;
									num111 = num26;
								}
								if (CFS.blnTraceEffProp) {
									CFS.strTrace += PropEff.Trace;
								}
								CFS.strTrace = CFS.strTrace + "    Center of gravity shift: y=" + Units.DisplayLen1 (PropEff.Ycg - Prop.Ycg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								CFS.strTrace = CFS.strTrace + "    Sec=" + Units.DisplayLen3 (PropEff.Sxb, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							}
							if (!Strength.MxnQual) {
								num110 = num25;
								num111 = num26;
							}
							if (num113 / num110 < Check.Max) {
								Check.Max = num113 / num110;
							}
							if (num111 * num113 < Check.QMnx) {
								Check.QMnx = num111 * num113;
							}
							CFS.strTrace = CFS.strTrace + "    Mnl=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty3 + "\r\n";
						}
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				num110 = num98;
				num111 = num101;
				if (Param.Lm > 0f) {
					float num107 = Prop.Sx * num4;
					float num114 = Prop.Sxn * num4;
					float num116;
					if (DSM.UseDSM & (DSM.Mcrdxn > 0f)) {
						num116 = DSM.Mcrdxn * Prop.Sx * num2;
						strTraceDB = "  Distortional buckling (DSM)\r\n";
						ref string reference6 = ref strTraceDB;
						reference6 = reference6 + "    Mcrd=" + Units.DisplayMoment (num116, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (CFS.SpecYear ((short)Param.Spec) < 2012 && !flag) {
							num114 = num107;
						}
					} else {
						if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
							num107 = Prop.Sx * Stress.Fyaxng;
							num114 = num107;
						}
						num116 = DistortionalBucklingMoment (Param, 1);
					}
					if (CFS.SpecYear ((short)Param.Spec) > 2016 && !flag) {
						num107 = Prop.Sx * Stress.Fyaxng;
						num114 = Prop.Sxn * Stress.Fyaxnn;
					}
					if (!Strength.MxnQual) {
						num110 = num25;
						num111 = num26;
					}
					float num77 = (float)System.Math.Sqrt (num107 / num116);
					float num81;
					float num82;
					float num117;
					if (flag) {
						num81 = (float)(0.533 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.533 * (14.0 * System.Math.Pow (num107 / num114, 0.4) - 13.0));
						num117 = ((!Material.IsFerritic ()) ? ((float)((double)num107 * (0.8 - 0.15 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))) : ((float)((double)num107 * (0.9 - 0.2 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))));
					} else {
						num81 = (float)(0.673 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.673 * (1.7 * System.Math.Pow (num107 / num114, 2.7) - 0.7));
						num117 = (float)((double)num107 * (1.0 - 0.22 / (double)num82) / (double)num82);
					}
					float num118;
					string text53;
					if (num77 <= num81) {
						num118 = num114;
						text53 = text7;
						if (CFS.SpecYear ((short)Param.Spec) == 2016 || flag) {
							num118 = (float)((double)Prop.Sxn * CFS.Min ((double)num116 * System.Math.Pow (num81, 2.0) / (double)Prop.Sx, Stress.Fyax));
						}
						if (Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) {
							float num119 = num81 / num77;
							if (num119 > 9f) {
								num119 = 9f;
							}
							float num120 = (Prop.Sxn + (1f - 1f / num119) * (Prop.Zxn - Prop.Sxn)) * num4;
							if (num120 > num118) {
								num118 = num120;
								text53 = text2;
								strTraceDB += "  Distortional inelastic reserve\r\n";
								ref string reference7 = ref strTraceDB;
								ref string reference4 = ref reference7;
								reference7 = reference4 + "    My=" + Units.DisplayMoment (Prop.Sxn * num4, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zxn * num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								ref string reference8 = ref strTraceDB;
								reference4 = ref reference8;
								reference8 = reference4 + "    λd=" + Units.DisplayNone (num77, "", 0, 0) + ", λd1=" + Units.DisplayNone (num81, "", 0, 0) + ", Cyd=" + Units.DisplayNone ((float)System.Math.Sqrt (num119), "", 0, 0) + "\r\n";
							}
						}
					} else if (num77 <= num82) {
						num118 = num114 - (num114 - num117) * (num77 - num81) / (num82 - num81);
						text53 = text8;
					} else if (flag) {
						if (Material.IsFerritic ()) {
							num118 = (float)((0.9 - 0.2 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						} else {
							num118 = (float)((0.8 - 0.15 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						}
					} else {
						num118 = (float)((1.0 - 0.22 * System.Math.Pow (num116 / num107, 0.5)) * System.Math.Pow (num116 / num107, 0.5) * (double)num107);
						text53 = text9;
					}
					if (num118 / num110 < Check.Max) {
						Check.Max = num118 / num110;
					}
					if (num111 * num118 < Check.QMnx) {
						Check.QMnx = num111 * num118;
					}
					if (Operators.ConditionalCompareObjectGreater (num77, Interaction.IIf (Reserve, num81 / 9f, num81 / 2f), TextCompare: false)) {
						CFS.strTrace += strTraceDB;
						CFS.strTrace = CFS.strTrace + "    Mnd=" + Units.DisplayMoment (num118, 0, blnShowUnit: true, "", 0, 0) + "\t" + text53 + "\r\n";
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				if ((Param.iBrcFlg == Flanges.flgTop) & (Param.R > 0f)) {
					num110 = num98;
					num111 = num102;
					if (!Strength.MxnQual) {
						num110 = num25;
						num111 = num26;
					}
					float num113 = Param.R * Strength.Mnxon;
					CFS.strTrace += "  Tension flange braced\r\n";
					CFS.strTrace = CFS.strTrace + "    R=" + Units.DisplayNone (Param.R, "", 0, 0) + ",  Mnlo=" + Units.DisplayMoment (Strength.Mnxon, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    Mn=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + text34 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					if (Check.Max < num113 / num110) {
						Check.Max = num113 / num110;
					}
					if (Check.QMnx < num111 * num113) {
						Check.QMnx = num111 * num113;
					}
				}
				if (Check.Max > num104) {
					Check.Max = num104;
				}
				if (Check.QMnx > num105) {
					Check.QMnx = num105;
				}
				CFS.strTrace += "\r\n";
			}
			CFS.strTrace += "Flexural Strength about Y-axis\r\n";
			if (Prop.An < a && num8 > 0f) {
				CFS.strTrace += "  Reduced section properties used to account for holes\r\n";
			}
			if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
				CFS.strTrace += "  σex=";
				if (num34 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num34, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text11 + "\r\n";
				CFS.strTrace += "  σt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayStress (1f / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			} else {
				CFS.strTrace += "  Pex=";
				if (num34 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num34, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text11 + "\r\n";
				CFS.strTrace += "  Pt=";
				if (num50 > 0f) {
					CFS.strTrace += Units.DisplayForce (a / num50, 0, blnShowUnit: true, "", 0, 0);
				} else {
					CFS.strTrace += "infinity";
				}
				CFS.strTrace = CFS.strTrace + "\t" + text13 + "\r\n";
			}
			if (((System.Math.Abs (num14) <= num24 * 0.001f) | (CFS.SpecYear ((short)Param.Spec) >= 2022)) || flag) {
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  Cb=" + Units.DisplayNone (Check.Cby, "", 0, 0) + "\t", Interaction.IIf (Param.Analysis, truePart, string.Empty)), "\r\n")));
			} else {
				CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("  Ctf=" + Units.DisplayNone (1f / Check.Cby, "", 0, 0) + "\t", Interaction.IIf (Param.Analysis, truePart2, string.Empty)), "\r\n")));
			}
			if (Check.My >= 0f) {
				float num104 = (Check.May = Strength.Mayop);
				float num105 = (Check.QMny = Strength.QMnyop);
				Check.Mayt = Strength.Maytop;
				Check.QMnyt = Strength.QMnytop;
				float num110;
				float num111;
				if ((num50 == 0f || (num34 == 0f && num14 <= num24 * 0.001f)) | (Param.iBrcFlg == Flanges.flgRight)) {
					CFS.strTrace = CFS.strTrace + "  Fully braced, " + text51;
				} else {
					flag2 = false;
					float num106;
					string text47;
					if (num34 == 0f) {
						num106 = (float)((double)(Check.Cby * a) * System.Math.Pow (num24, 2.0) / (double)(2f * num50 * num14));
						text47 = text28;
					} else if (IsLTBZee (LoadDirections.dirX) & !Param.BucklingTheory) {
						num106 = (float)((double)(Check.Cby * a * num24 / 2f) / System.Math.Sqrt (num34 * num50));
						text47 = text27;
					} else {
						num106 = (float)((double)(Check.Cby * a * num40 / num34) * ((double)(0f - num14) + System.Math.Sqrt (num14 * num14 + num24 * num24 * num34 / num40 / num50)));
						text47 = Conversions.ToString (Interaction.IIf (HasSymmetry (Symmetry.Principal), RuntimeHelpers.GetObjectValue (Interaction.IIf (HasSymmetry (Symmetry.PrincipalY), truePart3, text28)), "Analytical"));
						if ((!HasSymmetry (Symmetry.Principal) & (CFS.SpecYear ((short)Param.Spec) < 2016)) && !flag) {
							flag2 = true;
						}
					}
					float sxt = Prop.Syr;
					float num55 = num106 / sxt;
					if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
						CFS.strTrace = CFS.strTrace + "  " + text45 + "=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					} else {
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fcre=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					string text52 = string.Empty;
					float fyaxpg = Stress.Fyaypg;
					float num107 = Prop.Sy * fyaxpg;
					CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (fyaxpg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float num108;
					if (flag) {
						float num77 = (float)System.Math.Sqrt (fyaxpg / num55);
						if (Operators.ConditionalCompareObjectLessEqual (num77, Interaction.IIf (Material.IsFerritic (), 0.41, 0.35), TextCompare: false)) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num77 <= 1.6) {
							num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.49, System.Math.Pow (num77, 1.55)), 1.2 * System.Math.Pow (0.44, System.Math.Pow (num77, 1.44))), fyaxpg));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.7 * (double)num55, 0.61 * (double)num55));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					} else if (DSM.UseDSM & (DSM.Mcrlyp > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2016)) {
						if (!((double)num106 >= 2.7777777777777777 * (double)num107)) {
							num108 = ((!((double)num106 >= 5.0 / 9.0 * (double)num107)) ? num106 : ((float)((double)num107 / 0.9 * (1.0 - (double)(num107 / num106) / 3.6))));
						} else {
							num108 = num107;
							text52 = "  Mne >= My, ";
						}
						num67 = num108 / sxt;
					} else {
						if ((double)num55 >= 2.7777777777777777 * (double)fyaxpg) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num55 >= 5.0 / 9.0 * (double)fyaxpg) {
							num67 = (float)((double)fyaxpg / 0.9 * (1.0 - (double)(fyaxpg / num55) / 3.6));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = num55;
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					}
					CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text32 + "\r\n";
					if ((DSM.UseDSM & (DSM.Mcrlyp > 0f)) && num108 >= num107) {
						text52 = "  Mne >= My, ";
					}
					if (Strings.Len (text52) > 0) {
						CFS.strTrace = CFS.strTrace + text52 + text51;
						num107 = Prop.Sy * num4;
						float num109 = Prop.Zy * num4;
						if ((Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) && (double)num106 > 2.78 * (double)num107) {
							num108 = (float)((double)num109 - (double)(num109 - num107) * (System.Math.Sqrt (num107 / num106) - 0.23) / 0.37);
							if (num108 > num109) {
								num108 = num109;
							}
							CFS.strTrace += "  Global inelastic reserve\r\n";
							CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (num107, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (num109, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							CFS.strTrace = CFS.strTrace + "    Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
							CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num98) + ", φb=" + Conversions.ToString (num100), Interaction.IIf (num98 == num25 && num100 == num26, " (rational analysis)", "")), "\r\n")));
							if (num108 / num98 < Check.May) {
								Check.May = num108 / num98;
							}
							if (num100 * num108 < Check.QMny) {
								Check.QMny = num100 * num108;
							}
						}
					} else {
						num110 = num98;
						num111 = num99;
						if (flag2) {
							num110 = num25;
							num111 = num26;
						}
						checked {
							float num113;
							if (DSM.UseDSM & (DSM.Mcrlyp > 0f)) {
								num111 = num100;
								float num112 = DSM.Mcrlyp * Prop.Sy * num2;
								CFS.strTrace += "  Local buckling (DSM)\r\n";
								CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num112, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								float num77 = (float)System.Math.Sqrt (num108 / num112);
								if (flag) {
									if ((double)num77 <= 0.667) {
										num113 = num108;
										empty3 = text42;
									} else {
										num113 = (float)((1.0 - 0.2 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
										empty3 = text43;
									}
								} else if ((double)num77 <= 0.776) {
									num113 = num108;
									empty3 = text42;
								} else {
									num113 = (float)((1.0 - 0.15 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
									empty3 = text43;
								}
								float num114 = Prop.Syn * Stress.Fyaypn;
								if (num113 > num114) {
									num113 = num114;
									empty3 = text44;
								}
							} else {
								CFS.strTrace += "  Local buckling (EWM)\r\n";
								effectiveProperties.ResetProp (this, (byte)num103);
								short num115 = 1;
								do {
									float num91 = PropEff.Syr;
									effectiveProperties.EffProp (this, 0f, 0f, num67 * PropEff.Syr, (byte)num103, unchecked((short)Param.Spec));
									if (!PropEff.Iterate || System.Math.Abs (PropEff.Syr / num91 - 1f) < 0.001f) {
										break;
									}
									num115 = (short)unchecked(num115 + 1);
								} while (num115 <= 10);
								num113 = num67 * PropEff.Syr;
								empty3 = text33;
								if (PropEff.RationalAnalysis) {
									num110 = num25;
									num111 = num26;
								}
								if (CFS.blnTraceEffProp) {
									CFS.strTrace += PropEff.Trace;
								}
								CFS.strTrace = CFS.strTrace + "    Center of gravity shift: x=" + Units.DisplayLen1 (PropEff.Xcg - Prop.Xcg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								CFS.strTrace = CFS.strTrace + "    Sec=" + Units.DisplayLen3 (PropEff.Syr, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							}
							if (!Strength.MypQual) {
								num110 = num25;
								num111 = num26;
							}
							if (num113 / num110 < Check.May) {
								Check.May = num113 / num110;
							}
							if (num111 * num113 < Check.QMny) {
								Check.QMny = num111 * num113;
							}
							CFS.strTrace = CFS.strTrace + "    Mnl=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty3 + "\r\n";
						}
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				num110 = num98;
				num111 = num101;
				if (Param.Lm > 0f) {
					float num107 = Prop.Sy * num4;
					float num114 = Prop.Syn * num4;
					float num116;
					if (DSM.UseDSM & (DSM.Mcrdyp > 0f)) {
						num116 = DSM.Mcrdyp * Prop.Sy * num2;
						strTraceDB = "  Distortional buckling (DSM)\r\n";
						ref string reference9 = ref strTraceDB;
						reference9 = reference9 + "    Mcrd=" + Units.DisplayMoment (num116, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (CFS.SpecYear ((short)Param.Spec) < 2012 && !flag) {
							num114 = num107;
						}
					} else {
						if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
							num107 = Prop.Sy * Stress.Fyaypg;
							num114 = num107;
						}
						num116 = DistortionalBucklingMoment (Param, 4);
					}
					if (CFS.SpecYear ((short)Param.Spec) > 2016 && !flag) {
						num107 = Prop.Sy * Stress.Fyaypg;
						num114 = Prop.Syn * Stress.Fyaypn;
					}
					if (!Strength.MypQual) {
						num110 = num25;
						num111 = num26;
					}
					float num77 = (float)System.Math.Sqrt (num107 / num116);
					float num81;
					float num82;
					float num117;
					if (flag) {
						num81 = (float)(0.533 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.533 * (14.0 * System.Math.Pow (num107 / num114, 0.4) - 13.0));
						num117 = ((!Material.IsFerritic ()) ? ((float)((double)num107 * (0.8 - 0.15 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))) : ((float)((double)num107 * (0.9 - 0.2 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))));
					} else {
						num81 = (float)(0.673 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.673 * (1.7 * System.Math.Pow (num107 / num114, 2.7) - 0.7));
						num117 = (float)((double)num107 * (1.0 - 0.22 / (double)num82) / (double)num82);
					}
					float num118;
					string text53;
					if (num77 <= num81) {
						num118 = num114;
						text53 = text7;
						if (CFS.SpecYear ((short)Param.Spec) == 2016 || flag) {
							num118 = (float)((double)Prop.Syn * CFS.Min ((double)num116 * System.Math.Pow (num81, 2.0) / (double)Prop.Sy, Stress.Fyay));
						}
						if (Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) {
							float num119 = num81 / num77;
							if (num119 > 9f) {
								num119 = 9f;
							}
							float num120 = (Prop.Syn + (1f - 1f / num119) * (Prop.Zyn - Prop.Syn)) * num4;
							if (num120 > num118) {
								num118 = num120;
								text53 = text2;
								strTraceDB += "  Distortional inelastic reserve\r\n";
								ref string reference10 = ref strTraceDB;
								ref string reference4 = ref reference10;
								reference10 = reference4 + "    My=" + Units.DisplayMoment (Prop.Syn * num4, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zyn * num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								ref string reference11 = ref strTraceDB;
								reference4 = ref reference11;
								reference11 = reference4 + "    λd=" + Units.DisplayNone (num77, "", 0, 0) + ", λd1=" + Units.DisplayNone (num81, "", 0, 0) + ", Cyd=" + Units.DisplayNone ((float)System.Math.Sqrt (num119), "", 0, 0) + "\r\n";
							}
						}
					} else if (num77 <= num82) {
						num118 = num114 - (num114 - num117) * (num77 - num81) / (num82 - num81);
						text53 = text8;
					} else if (flag) {
						if (Material.IsFerritic ()) {
							num118 = (float)((0.9 - 0.2 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						} else {
							num118 = (float)((0.8 - 0.15 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						}
					} else {
						num118 = (float)((1.0 - 0.22 * System.Math.Pow (num116 / num107, 0.5)) * System.Math.Pow (num116 / num107, 0.5) * (double)num107);
						text53 = text9;
					}
					if (num118 / num110 < Check.May) {
						Check.May = num118 / num110;
					}
					if (num111 * num118 < Check.QMny) {
						Check.QMny = num111 * num118;
					}
					if (Operators.ConditionalCompareObjectGreater (num77, Interaction.IIf (Reserve, num81 / 9f, num81 / 2f), TextCompare: false)) {
						CFS.strTrace += strTraceDB;
						CFS.strTrace = CFS.strTrace + "    Mnd=" + Units.DisplayMoment (num118, 0, blnShowUnit: true, "", 0, 0) + "\t" + text53 + "\r\n";
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				if ((Param.iBrcFlg == Flanges.flgLeft) & (Param.R > 0f)) {
					num110 = num98;
					num111 = num102;
					if (!Strength.MypQual) {
						num110 = num25;
						num111 = num26;
					}
					float num113 = Param.R * Strength.Mnyop;
					CFS.strTrace += "  Tension flange braced\r\n";
					CFS.strTrace = CFS.strTrace + "    R=" + Units.DisplayNone (Param.R, "", 0, 0) + ",  Mnlo=" + Units.DisplayMoment (Strength.Mnyop, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    Mn=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + text34 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					if (Check.May < num113 / num110) {
						Check.May = num113 / num110;
					}
					if (Check.QMny < num111 * num113) {
						Check.QMny = num111 * num113;
					}
				}
				if (Check.May > num104) {
					Check.May = num104;
				}
				if (Check.QMny > num105) {
					Check.QMny = num105;
				}
				CFS.strTrace += "\r\n";
			}
			if (Check.My < 0f) {
				float num104 = (Check.May = Strength.Mayon);
				float num105 = (Check.QMny = Strength.QMnyon);
				Check.Mayt = Strength.Mayton;
				Check.QMnyt = Strength.QMnyton;
				float num110;
				float num111;
				if ((num50 == 0f || (num34 == 0f && num14 >= (0f - num24) * 0.001f)) | (Param.iBrcFlg == Flanges.flgLeft)) {
					CFS.strTrace = CFS.strTrace + "  Fully Braced, " + text51;
				} else {
					flag2 = false;
					float num106;
					string text47;
					if (num34 == 0f) {
						num106 = (float)((double)(Check.Cby * a) * System.Math.Pow (num24, 2.0) / (double)(2f * num50 * (0f - num14)));
						text47 = text28;
					} else if (IsLTBZee (LoadDirections.dirX) & !Param.BucklingTheory) {
						num106 = (float)((double)(Check.Cby * a * num24 / 2f) / System.Math.Sqrt (num34 * num50));
						text47 = text27;
					} else {
						num106 = (float)((double)(Check.Cby * a * num40 / num34) * ((double)num14 + System.Math.Sqrt (num14 * num14 + num24 * num24 * num34 / num40 / num50)));
						text47 = Conversions.ToString (Interaction.IIf (HasSymmetry (Symmetry.Principal), RuntimeHelpers.GetObjectValue (Interaction.IIf (HasSymmetry (Symmetry.PrincipalY), truePart3, text28)), "Analytical"));
						if ((!HasSymmetry (Symmetry.Principal) & (CFS.SpecYear ((short)Param.Spec) < 2016)) && !flag) {
							flag2 = true;
						}
					}
					float sxt = Prop.Syl;
					float num55 = num106 / sxt;
					if (CFS.SpecYear ((short)Param.Spec) < 2022 || flag) {
						CFS.strTrace = CFS.strTrace + "  " + text45 + "=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					} else {
						CFS.strTrace = CFS.strTrace + "  Mcre=" + Units.DisplayMoment (num106, 0, blnShowUnit: true, "", 0, 0) + "\t" + text47 + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fcre=" + Units.DisplayStress (num55, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
					string text52 = string.Empty;
					float fyaxpg = Stress.Fyayng;
					float num107 = Prop.Sy * fyaxpg;
					CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (fyaxpg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float num108;
					if (flag) {
						float num77 = (float)System.Math.Sqrt (fyaxpg / num55);
						if (Operators.ConditionalCompareObjectLessEqual (num77, Interaction.IIf (Material.IsFerritic (), 0.41, 0.35), TextCompare: false)) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num77 <= 1.6) {
							num67 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (Material.IsFerritic (), 1.2 * System.Math.Pow (0.49, System.Math.Pow (num77, 1.55)), 1.2 * System.Math.Pow (0.44, System.Math.Pow (num77, 1.44))), fyaxpg));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.7 * (double)num55, 0.61 * (double)num55));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					} else if (DSM.UseDSM & (DSM.Mcrlyn > 0f) & (CFS.SpecYear ((short)Param.Spec) < 2016)) {
						if (!((double)num106 >= 2.7777777777777777 * (double)num107)) {
							num108 = ((!((double)num106 >= 5.0 / 9.0 * (double)num107)) ? num106 : ((float)((double)num107 / 0.9 * (1.0 - (double)(num107 / num106) / 3.6))));
						} else {
							num108 = num107;
							text52 = "  Mne >= My, ";
						}
						num67 = num108 / sxt;
					} else {
						if ((double)num55 >= 2.7777777777777777 * (double)fyaxpg) {
							num67 = fyaxpg;
							text52 = "  " + text46 + " = Fy, ";
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text29 + "\r\n";
						} else if ((double)num55 >= 5.0 / 9.0 * (double)fyaxpg) {
							num67 = (float)((double)fyaxpg / 0.9 * (1.0 - (double)(fyaxpg / num55) / 3.6));
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text30 + "\r\n";
						} else {
							num67 = num55;
							CFS.strTrace = CFS.strTrace + "  " + text46 + "=" + Units.DisplayStress (num67, 0, blnShowUnit: true, "", 0, 0) + "\t" + text31 + "\r\n";
						}
						num108 = (float)CFS.Min (num67 * sxt, num107);
					}
					CFS.strTrace = CFS.strTrace + "  Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text32 + "\r\n";
					if ((DSM.UseDSM & (DSM.Mcrlyn > 0f)) && num108 >= num107) {
						text52 = "  Mne >= My, ";
					}
					if (Strings.Len (text52) > 0) {
						CFS.strTrace = CFS.strTrace + text52 + text51;
						num107 = Prop.Sy * num4;
						float num109 = Prop.Zy * num4;
						if ((Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) && (double)num106 > 2.78 * (double)num107) {
							num108 = (float)((double)num109 - (double)(num109 - num107) * (System.Math.Sqrt (num107 / num106) - 0.23) / 0.37);
							if (num108 > num109) {
								num108 = num109;
							}
							CFS.strTrace += "  Global inelastic reserve\r\n";
							CFS.strTrace = CFS.strTrace + "    My=" + Units.DisplayMoment (num107, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (num109, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							CFS.strTrace = CFS.strTrace + "    Mne=" + Units.DisplayMoment (num108, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
							CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num98) + ", φb=" + Conversions.ToString (num100), Interaction.IIf (num98 == num25 && num100 == num26, " (rational analysis)", "")), "\r\n")));
							if (num108 / num98 < Check.May) {
								Check.May = num108 / num98;
							}
							if (num100 * num108 < Check.QMny) {
								Check.QMny = num100 * num108;
							}
						}
					} else {
						num110 = num98;
						num111 = num99;
						if (flag2) {
							num110 = num25;
							num111 = num26;
						}
						checked {
							float num113;
							if (DSM.UseDSM & (DSM.Mcrlyn > 0f)) {
								num111 = num100;
								float num112 = DSM.Mcrlyn * Prop.Sy * num2;
								CFS.strTrace += "  Local buckling (DSM)\r\n";
								CFS.strTrace = CFS.strTrace + "    Mcrl=" + Units.DisplayMoment (num112, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								float num77 = (float)System.Math.Sqrt (num108 / num112);
								if (flag) {
									if ((double)num77 <= 0.667) {
										num113 = num108;
										empty3 = text42;
									} else {
										num113 = (float)((1.0 - 0.2 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
										empty3 = text43;
									}
								} else if ((double)num77 <= 0.776) {
									num113 = num108;
									empty3 = text42;
								} else {
									num113 = (float)((1.0 - 0.15 * System.Math.Pow (num112 / num108, 0.4)) * System.Math.Pow (num112 / num108, 0.4) * (double)num108);
									empty3 = text43;
								}
								float num114 = Prop.Syn * Stress.Fyaynn;
								if (num113 > num114) {
									num113 = num114;
									empty3 = text44;
								}
							} else {
								CFS.strTrace += "  Local buckling (EWM)\r\n";
								effectiveProperties.ResetProp (this, (byte)num103);
								short num115 = 1;
								do {
									float num91 = PropEff.Syl;
									effectiveProperties.EffProp (this, 0f, 0f, (0f - num67) * PropEff.Syl, (byte)num103, unchecked((short)Param.Spec));
									if (!PropEff.Iterate || System.Math.Abs (PropEff.Syl / num91 - 1f) < 0.001f) {
										break;
									}
									num115 = (short)unchecked(num115 + 1);
								} while (num115 <= 10);
								num113 = num67 * PropEff.Syl;
								empty3 = text33;
								if (PropEff.RationalAnalysis) {
									num110 = num25;
									num111 = num26;
								}
								if (CFS.blnTraceEffProp) {
									CFS.strTrace += PropEff.Trace;
								}
								CFS.strTrace = CFS.strTrace + "    Center of gravity shift: x=" + Units.DisplayLen1 (PropEff.Xcg - Prop.Xcg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								CFS.strTrace = CFS.strTrace + "    Sec=" + Units.DisplayLen3 (PropEff.Syl, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							}
							if (!Strength.MynQual) {
								num110 = num25;
								num111 = num26;
							}
							if (num113 / num110 < Check.May) {
								Check.May = num113 / num110;
							}
							if (num111 * num113 < Check.QMny) {
								Check.QMny = num111 * num113;
							}
							CFS.strTrace = CFS.strTrace + "    Mnl=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + empty3 + "\r\n";
						}
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				num110 = num98;
				num111 = num101;
				if (Param.Lm > 0f) {
					float num107 = Prop.Sy * num4;
					float num114 = Prop.Syn * num4;
					float num116;
					if (DSM.UseDSM & (DSM.Mcrdyn > 0f)) {
						num116 = DSM.Mcrdyn * Prop.Sy * num2;
						strTraceDB = "  Distortional buckling (DSM)\r\n";
						ref string reference12 = ref strTraceDB;
						reference12 = reference12 + "    Mcrd=" + Units.DisplayMoment (num116, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (CFS.SpecYear ((short)Param.Spec) < 2012 && !flag) {
							num114 = num107;
						}
					} else {
						if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
							num107 = Prop.Sy * Stress.Fyayng;
							num114 = num107;
						}
						num116 = DistortionalBucklingMoment (Param, 3);
					}
					if (CFS.SpecYear ((short)Param.Spec) > 2016 && !flag) {
						num107 = Prop.Sy * Stress.Fyayng;
						num114 = Prop.Syn * Stress.Fyaynn;
					}
					if (!Strength.MynQual) {
						num110 = num25;
						num111 = num26;
					}
					float num77 = (float)System.Math.Sqrt (num107 / num116);
					float num81;
					float num82;
					float num117;
					if (flag) {
						num81 = (float)(0.533 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.533 * (14.0 * System.Math.Pow (num107 / num114, 0.4) - 13.0));
						num117 = ((!Material.IsFerritic ()) ? ((float)((double)num107 * (0.8 - 0.15 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))) : ((float)((double)num107 * (0.9 - 0.2 / System.Math.Pow (num82, 1.1)) / System.Math.Pow (num82, 1.1))));
					} else {
						num81 = (float)(0.673 * System.Math.Pow (num114 / num107, 3.0));
						num82 = (float)(0.673 * (1.7 * System.Math.Pow (num107 / num114, 2.7) - 0.7));
						num117 = (float)((double)num107 * (1.0 - 0.22 / (double)num82) / (double)num82);
					}
					float num118;
					string text53;
					if (num77 <= num81) {
						num118 = num114;
						text53 = text7;
						if (CFS.SpecYear ((short)Param.Spec) == 2016 || flag) {
							num118 = (float)((double)Prop.Syn * CFS.Min ((double)num116 * System.Math.Pow (num81, 2.0) / (double)Prop.Sy, Stress.Fyay));
						}
						if (Reserve & (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag)) {
							float num119 = num81 / num77;
							if (num119 > 9f) {
								num119 = 9f;
							}
							float num120 = (Prop.Syn + (1f - 1f / num119) * (Prop.Zyn - Prop.Syn)) * num4;
							if (num120 > num118) {
								num118 = num120;
								text53 = text2;
								strTraceDB += "  Distortional inelastic reserve\r\n";
								ref string reference13 = ref strTraceDB;
								ref string reference4 = ref reference13;
								reference13 = reference4 + "    My=" + Units.DisplayMoment (Prop.Syn * num4, 0, blnShowUnit: true, "", 0, 0) + ", Mp=" + Units.DisplayMoment (Prop.Zyn * num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
								ref string reference14 = ref strTraceDB;
								reference4 = ref reference14;
								reference14 = reference4 + "    λd=" + Units.DisplayNone (num77, "", 0, 0) + ", λd1=" + Units.DisplayNone (num81, "", 0, 0) + ", Cyd=" + Units.DisplayNone ((float)System.Math.Sqrt (num119), "", 0, 0) + "\r\n";
							}
						}
					} else if (num77 <= num82) {
						num118 = num114 - (num114 - num117) * (num77 - num81) / (num82 - num81);
						text53 = text8;
					} else if (flag) {
						if (Material.IsFerritic ()) {
							num118 = (float)((0.9 - 0.2 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						} else {
							num118 = (float)((0.8 - 0.15 * System.Math.Pow (num116 / num107, 0.55)) * System.Math.Pow (num116 / num107, 0.55) * (double)num107);
							text53 = text9;
						}
					} else {
						num118 = (float)((1.0 - 0.22 * System.Math.Pow (num116 / num107, 0.5)) * System.Math.Pow (num116 / num107, 0.5) * (double)num107);
						text53 = text9;
					}
					if (num118 / num110 < Check.May) {
						Check.May = num118 / num110;
					}
					if (num111 * num118 < Check.QMny) {
						Check.QMny = num111 * num118;
					}
					if (Operators.ConditionalCompareObjectGreater (num77, Interaction.IIf (Reserve, num81 / 9f, num81 / 2f), TextCompare: false)) {
						CFS.strTrace += strTraceDB;
						CFS.strTrace = CFS.strTrace + "    Mnd=" + Units.DisplayMoment (num118, 0, blnShowUnit: true, "", 0, 0) + "\t" + text53 + "\r\n";
						CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					}
				}
				if ((Param.iBrcFlg == Flanges.flgRight) & (Param.R > 0f)) {
					num110 = num98;
					num111 = num102;
					if (!Strength.MynQual) {
						num110 = num25;
						num111 = num26;
					}
					float num113 = Param.R * Strength.Mnyon;
					CFS.strTrace += "  Tension flange braced\r\n";
					CFS.strTrace = CFS.strTrace + "    R=" + Units.DisplayNone (Param.R, "", 0, 0) + ",  Mnlo=" + Units.DisplayMoment (Strength.Mnyon, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					CFS.strTrace = CFS.strTrace + "    Mn=" + Units.DisplayMoment (num113, 0, blnShowUnit: true, "", 0, 0) + "\t" + text34 + "\r\n";
					CFS.strTrace = Conversions.ToString (Operators.ConcatenateObject (CFS.strTrace, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωb=" + Conversions.ToString (num110) + ", φb=" + Conversions.ToString (num111), Interaction.IIf (num110 == num25 && num111 == num26, " (rational analysis)", "")), "\r\n")));
					if (Check.May < num113 / num110) {
						Check.May = num113 / num110;
					}
					if (Check.QMny < num111 * num113) {
						Check.QMny = num111 * num113;
					}
				}
				if (Check.May > num104) {
					Check.May = num104;
				}
				if (Check.QMny > num105) {
					Check.QMny = num105;
				}
				CFS.strTrace += "\r\n";
			}
		}
		if ((Param.iBrcFlg == Flanges.flgBottom) | (Param.iBrcFlg == Flanges.flgTop)) {
			num35 = 0f;
		}
		if ((Param.iBrcFlg == Flanges.flgLeft) | (Param.iBrcFlg == Flanges.flgRight)) {
			num34 = 0f;
		}
		string text54 = "0.000";
		float num121 = 9.999f;
		Check.Eq = new float[6];
		Check.EqText = new string[6];
		if (CFS.IsSpecLRFD ((short)Param.Spec) | CFS.IsSpecLSD ((short)Param.Spec)) {
			float num30;
			float num31;
			float num123;
			if (Param.P < 0f) {
				if (flag) {
					Check.EqText [1] = "Eq. 8-1      (Mx, My, T)  ";
					Check.EqText [2] = "Eq. 8-2      (Mx, My, T)  ";
				} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
					Check.EqText [1] = "Eq. C5.1.2-1 (Mx, My, T)  ";
					Check.EqText [2] = "Eq. C5.1.2-2 (Mx, My, T)  ";
				} else {
					Check.EqText [1] = "Eq. H1.1-1   (Mx, My, T)  ";
					Check.EqText [2] = "Eq. H1.1-2   (Mx, My, T)  ";
				}
				num30 = System.Math.Abs (Check.Mx) / Check.QMnxt;
				num31 = System.Math.Abs (Check.My) / Check.QMnyt;
				float num122 = System.Math.Abs (Param.P) / Check.QPn;
				num123 = num30 + num31 + num122;
				Check.Eq [1] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				ref string reference15 = ref Check.EqText [1];
				ref string reference4 = ref reference15;
				reference15 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
				}
				num30 = System.Math.Abs (Check.Mx) / Check.QMnx;
				num31 = System.Math.Abs (Check.My) / Check.QMny;
				num122 = System.Math.Abs (Param.P) / Check.QPn;
				num123 = num30 + num31 - num122;
				Check.Eq [2] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				if (num123 < 0f - num121) {
					num123 = 0f - num121;
				}
				ref string reference16 = ref Check.EqText [2];
				reference4 = ref reference16;
				reference16 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " - " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
				}
			} else {
				if (flag) {
					Check.EqText [1] = "Eq. 8-4      (P, Mx, My)  ";
					Check.EqText [2] = string.Empty;
				} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
					Check.EqText [1] = "Eq. C5.2.2-1 (P, Mx, My)  ";
					Check.EqText [2] = "Eq. C5.2.2-2 (P, Mx, My)  ";
				} else {
					Check.EqText [1] = "Eq. H1.2-1   (P, Mx, My)  ";
					Check.EqText [2] = string.Empty;
				}
				num30 = System.Math.Abs (Param.P) / Check.QPn;
				float num122;
				if ((CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) & !Param.Pdelta) {
					CFS.strTrace += "Compression and Bending Interaction\r\n";
					num22 = 1f - Param.P * num34 / a;
					CFS.strTrace = CFS.strTrace + "  αx=" + Units.DisplayNone (num22, "", 0, 0) + "\t" + text37 + "\r\n";
					num31 = ((!(num22 > 0f)) ? num121 : (Param.Cmx * System.Math.Abs (Check.Mx) / (Check.QMnx * num22)));
					num22 = 1f - Param.P * num35 / a;
					CFS.strTrace = CFS.strTrace + "  αy=" + Units.DisplayNone (num22, "", 0, 0) + "\t" + text38 + "\r\n\r\n";
					num122 = ((!(num22 > 0f)) ? num121 : (Param.Cmy * System.Math.Abs (Check.My) / (Check.QMny * num22)));
				} else {
					num31 = System.Math.Abs (Check.Mx) / Check.QMnx;
					num122 = System.Math.Abs (Check.My) / Check.QMny;
				}
				num123 = num30 + num31 + num122;
				Check.Eq [1] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				ref string reference17 = ref Check.EqText [1];
				ref string reference4 = ref reference17;
				reference17 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
				}
				if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
					num30 = System.Math.Abs (Param.P) / Strength.QPno;
					num31 = System.Math.Abs (Check.Mx) / Check.QMnx;
					num122 = System.Math.Abs (Check.My) / Check.QMny;
					num123 = num30 + num31 + num122;
					Check.Eq [2] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num122 > num121) {
						num122 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference18 = ref Check.EqText [2];
					reference4 = ref reference18;
					reference18 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
					if (System.Math.Round (num123, 3) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
					}
				}
			}
			if (flag) {
				Check.EqText [3] = "Eq. 8-5         (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. 8-5         (My, Vx)     Sqrt(";
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [3] = "Eq. C3.3.2-1    (Mx, Vy)          ";
				Check.EqText [4] = "Eq. C3.3.2-1    (My, Vx)          ";
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [3] = "Eq. C3.3.2-1    (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. C3.3.2-1    (My, Vx)     Sqrt(";
			} else {
				Check.EqText [3] = "Eq. H2-1        (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. H2-1        (My, Vx)     Sqrt(";
			}
			num30 = ((!(Check.Mx >= 0f)) ? ((float)System.Math.Pow (System.Math.Abs (Check.Mx) / Strength.QMnxon, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Mx) / Strength.QMnxop, 2.0)));
			num31 = ((!(Strength.QVny > 0f)) ? ((float)System.Math.Pow (num121, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Vy) / Strength.QVny, 2.0)));
			num123 = num30 + num31;
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				num123 = (float)System.Math.Sqrt (num123);
			}
			Check.Eq [3] = num123;
			if (num30 > num121) {
				num30 = num121;
			}
			if (num31 > num121) {
				num31 = num121;
			}
			if (num123 > num121) {
				num123 = num121;
			}
			ref string reference19 = ref Check.EqText [3];
			reference19 = reference19 + num30.ToString (text54) + " + " + num31.ToString (text54);
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				ref string reference20 = ref Check.EqText [3];
				reference20 = reference20 + ")= " + num123.ToString (text54) + " <= 1.0";
			} else {
				ref string reference21 = ref Check.EqText [3];
				reference21 = reference21 + " = " + num123.ToString (text54) + " <= 1.0";
			}
			if (System.Math.Round (num123, 3) > 1.0) {
				StringType.MidStmtStr (ref Check.EqText [3], Strings.InStr (Check.EqText [3], "<="), int.MaxValue, "> ");
			}
			num30 = ((!(Check.My >= 0f)) ? ((float)System.Math.Pow (System.Math.Abs (Check.My) / Strength.QMnyon, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.My) / Strength.QMnyop, 2.0)));
			num31 = ((!(Strength.QVnx > 0f)) ? ((float)System.Math.Pow (num121, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Vx) / Strength.QVnx, 2.0)));
			num123 = num30 + num31;
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				num123 = (float)System.Math.Sqrt (num123);
			}
			Check.Eq [4] = num123;
			if (num30 > num121) {
				num30 = num121;
			}
			if (num31 > num121) {
				num31 = num121;
			}
			if (num123 > num121) {
				num123 = num121;
			}
			ref string reference22 = ref Check.EqText [4];
			reference22 = reference22 + num30.ToString (text54) + " + " + num31.ToString (text54);
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				ref string reference23 = ref Check.EqText [4];
				reference23 = reference23 + ")= " + num123.ToString (text54) + " <= 1.0";
			} else {
				ref string reference24 = ref Check.EqText [4];
				reference24 = reference24 + " = " + num123.ToString (text54) + " <= 1.0";
			}
			if (System.Math.Round (num123, 3) > 1.0) {
				StringType.MidStmtStr (ref Check.EqText [4], Strings.InStr (Check.EqText [4], "<="), int.MaxValue, "> ");
			}
			if (Param.Torsion & (((CFS.SpecYear ((short)Param.Spec) >= 2007) & (CFS.SpecYear ((short)Param.Spec) < 2022)) || flag)) {
				if ((CwOverride > 0f) & (Check.B != 0f)) {
					Check.Msg += "Unable to check torsion with overridden Cw.\r\n";
				} else if ((Check.Mx == 0f) & (Check.My == 0f) & (Strength.QBn > 0f)) {
					num123 = System.Math.Abs (Check.B) / Strength.QBn;
					Check.Eq [5] = num123;
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference25 = ref Check.EqText [5];
					reference25 = reference25 + "Bimoment unity check".PadRight (50) + num123.ToString (text54) + " <= 1.0";
					if (System.Math.Round (num123, 3) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				} else {
					if (flag) {
						Check.EqText [5] = "Eq. 8-10        (Mx, My)          ";
					} else if (CFS.SpecYear ((short)Param.Spec) <= 2012) {
						Check.EqText [5] = "Section C3.6    (Mx, My)          ";
					} else {
						Check.EqText [5] = "Section H4      (Mx, My)          ";
					}
					float num47;
					if (nPart == 1) {
						string strTrace = string.Empty;
						num47 = Part [1].TorsionReduction (Check.Mx, Check.My, Check.B, (byte)Param.Spec, flag, ref strTrace, blnNet: true);
						CFS.strTrace += strTrace;
					} else if (Strength.Bn > 0f) {
						num30 = System.Math.Abs (MaxStress (0f, Check.Mx, Check.My, blnNet: true));
						num31 = num4 * System.Math.Abs (Check.B) / Strength.Bn;
						num47 = num30 / (num30 + num31);
						CFS.strTrace += "Combined Bending and Torsion\r\n";
						CFS.strTrace = CFS.strTrace + "  Mx=" + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: true, "", 0, 0) + ", My=" + Units.DisplayMoment (Check.My, 0, blnShowUnit: true, "", 0, 0) + ", B=" + Units.DisplayBimoment (Check.B, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fb_max=" + Units.DisplayStress (num30, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fb+Fw=" + Units.DisplayStress (num30 + num31, 0, blnShowUnit: true, "", 0, 0) + " (conservative)\r\n";
						CFS.strTrace = CFS.strTrace + "  R=" + Units.DisplayNone (num47, "", 0, 0) + "\t" + text10 + "\r\n\r\n";
					} else {
						num47 = Conversions.ToSingle (Interaction.IIf (Check.B == 0f, 1, 0));
					}
					num30 = ((num47 == 0f) ? num121 : ((!(Check.Mx >= 0f)) ? (System.Math.Abs (Check.Mx) / (num47 * Strength.QMnxon)) : (System.Math.Abs (Check.Mx) / (num47 * Strength.QMnxop))));
					num31 = ((num47 == 0f) ? num121 : ((!(Check.My >= 0f)) ? (System.Math.Abs (Check.My) / (num47 * Strength.QMnyon)) : (System.Math.Abs (Check.My) / (num47 * Strength.QMnyop))));
					num123 = num30 + num31;
					Check.Eq [5] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference26 = ref Check.EqText [5];
					ref string reference4 = ref reference26;
					reference26 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
					if (System.Math.Round (num123, 3) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				}
			} else if ((Param.Torsion & (CFS.SpecYear ((short)Param.Spec) >= 2022)) && !flag) {
				if ((CwOverride > 0f) & (Check.B != 0f)) {
					Check.Msg += "Unable to check torsion with overridden Cw.\r\n";
				} else {
					Check.EqText [5] = "Eq. H4-1     (Mx, My, B)  ";
					num30 = Conversions.ToSingle (Operators.DivideObject (System.Math.Abs (Check.Mx), Interaction.IIf (Check.Mx >= 0f, Strength.QMnxop, Strength.QMnxon)));
					num31 = Conversions.ToSingle (Operators.DivideObject (System.Math.Abs (Check.My), Interaction.IIf (Check.My >= 0f, Strength.QMnyop, Strength.QMnxon)));
					float num122 = System.Math.Abs (Check.B) / Strength.QBn;
					num123 = num30 + num31 + num122;
					Check.Eq [5] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num122 > num121) {
						num122 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference27 = ref Check.EqText [5];
					ref string reference4 = ref reference27;
					reference27 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.15";
					if (System.Math.Round (num123, 3) > 1.15) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				}
			}
		} else {
			float num30;
			float num31;
			float num123;
			if (Param.P < 0f) {
				if (flag) {
					Check.EqText [1] = "Eq. 8-1      (Mx, My, T)  ";
					Check.EqText [2] = "Eq. 8-2      (Mx, My, T)  ";
				} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
					Check.EqText [1] = "Eq. C5.1.1-1 (Mx, My, T)  ";
					Check.EqText [2] = "Eq. C5.1.1-2 (Mx, My, T)  ";
				} else {
					Check.EqText [1] = "Eq. H1.1-1   (Mx, My, T)  ";
					Check.EqText [2] = "Eq. H1.1-2   (Mx, My, T)  ";
				}
				num30 = System.Math.Abs (Check.Mx) / Check.Maxt;
				num31 = System.Math.Abs (Check.My) / Check.Mayt;
				float num122 = System.Math.Abs (Param.P) / Check.Pa;
				num123 = num30 + num31 + num122;
				Check.Eq [1] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				ref string reference28 = ref Check.EqText [1];
				ref string reference4 = ref reference28;
				reference28 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
				}
				num30 = System.Math.Abs (Check.Mx) / Check.Max;
				num31 = System.Math.Abs (Check.My) / Check.May;
				num122 = System.Math.Abs (Param.P) / Check.Pa;
				num123 = num30 + num31 - num122;
				Check.Eq [2] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				if (num123 < 0f - num121) {
					num123 = 0f - num121;
				}
				ref string reference29 = ref Check.EqText [2];
				reference4 = ref reference29;
				reference29 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " - " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
				}
			} else {
				if (flag) {
					Check.EqText [1] = "Eq. 8-4      (P, Mx, My)  ";
					Check.EqText [2] = string.Empty;
				} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
					Check.EqText [1] = "Eq. C5.2.1-1 (P, Mx, My)  ";
					Check.EqText [2] = "Eq. C5.2.1-2 (P, Mx, My)  ";
				} else {
					Check.EqText [1] = "Eq. H1.2-1   (P, Mx, My)  ";
					Check.EqText [2] = string.Empty;
				}
				num30 = System.Math.Abs (Param.P) / Check.Pa;
				float num122;
				if ((CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) & !Param.Pdelta) {
					CFS.strTrace += "Compression and Bending Interaction\r\n";
					num22 = 1f - num75 * Param.P * num34 / a;
					CFS.strTrace = CFS.strTrace + "  αx=" + Units.DisplayNone (num22, "", 0, 0) + "\t" + text35 + "\r\n";
					num31 = ((!(num22 > 0f)) ? num121 : (Param.Cmx * System.Math.Abs (Check.Mx) / (Check.Max * num22)));
					num22 = 1f - num75 * Param.P * num35 / a;
					CFS.strTrace = CFS.strTrace + "  αy=" + Units.DisplayNone (num22, "", 0, 0) + "\t" + text36 + "\r\n\r\n";
					num122 = ((!(num22 > 0f)) ? num121 : (Param.Cmy * System.Math.Abs (Check.My) / (Check.May * num22)));
				} else {
					num31 = System.Math.Abs (Check.Mx) / Check.Max;
					num122 = System.Math.Abs (Check.My) / Check.May;
				}
				num123 = num30 + num31 + num122;
				Check.Eq [1] = num123;
				if (num30 > num121) {
					num30 = num121;
				}
				if (num31 > num121) {
					num31 = num121;
				}
				if (num122 > num121) {
					num122 = num121;
				}
				if (num123 > num121) {
					num123 = num121;
				}
				ref string reference30 = ref Check.EqText [1];
				ref string reference4 = ref reference30;
				reference30 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
				if (System.Math.Round (num123, 3) > 1.0) {
					StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
				}
				if (CFS.SpecYear ((short)Param.Spec) < 2016 && !flag) {
					num30 = System.Math.Abs (Param.P) / Strength.Pao;
					num31 = System.Math.Abs (Check.Mx) / Check.Max;
					num122 = System.Math.Abs (Check.My) / Check.May;
					num123 = num30 + num31 + num122;
					Check.Eq [2] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num122 > num121) {
						num122 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference31 = ref Check.EqText [2];
					reference4 = ref reference31;
					reference31 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
					if (Conversion.Val (num123.ToString (text54)) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
					}
				}
			}
			if (flag) {
				Check.EqText [3] = "Eq. 8-5         (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. 8-5         (My, Vx)     Sqrt(";
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [3] = "Eq. C3.3.1-1    (Mx, Vy)          ";
				Check.EqText [4] = "Eq. C3.3.1-1    (My, Vx)          ";
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [3] = "Eq. C3.3.1-1    (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. C3.3.1-1    (My, Vx)     Sqrt(";
			} else {
				Check.EqText [3] = "Eq. H2-1        (Mx, Vy)     Sqrt(";
				Check.EqText [4] = "Eq. H2-1        (My, Vx)     Sqrt(";
			}
			num30 = ((!(Check.Mx >= 0f)) ? ((float)System.Math.Pow (System.Math.Abs (Check.Mx) / Strength.Maxon, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Mx) / Strength.Maxop, 2.0)));
			num31 = ((!(Strength.Vay > 0f)) ? ((float)System.Math.Pow (num121, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Vy) / Strength.Vay, 2.0)));
			num123 = num30 + num31;
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				num123 = (float)System.Math.Sqrt (num123);
			}
			Check.Eq [3] = num123;
			if (num30 > num121) {
				num30 = num121;
			}
			if (num31 > num121) {
				num31 = num121;
			}
			if (num123 > num121) {
				num123 = num121;
			}
			ref string reference32 = ref Check.EqText [3];
			reference32 = reference32 + num30.ToString (text54) + " + " + num31.ToString (text54);
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				ref string reference33 = ref Check.EqText [3];
				reference33 = reference33 + ")= " + num123.ToString (text54) + " <= 1.0";
			} else {
				ref string reference34 = ref Check.EqText [3];
				reference34 = reference34 + " = " + num123.ToString (text54) + " <= 1.0";
			}
			if (System.Math.Round (num123, 3) > 1.0) {
				StringType.MidStmtStr (ref Check.EqText [3], Strings.InStr (Check.EqText [3], "<="), int.MaxValue, "> ");
			}
			num30 = ((!(Check.My >= 0f)) ? ((float)System.Math.Pow (System.Math.Abs (Check.My) / Strength.Mayon, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.My) / Strength.Mayop, 2.0)));
			num31 = ((!(Strength.Vax > 0f)) ? ((float)System.Math.Pow (num121, 2.0)) : ((float)System.Math.Pow (System.Math.Abs (Check.Vx) / Strength.Vax, 2.0)));
			num123 = num30 + num31;
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				num123 = (float)System.Math.Sqrt (num123);
			}
			Check.Eq [4] = num123;
			if (num30 > num121) {
				num30 = num121;
			}
			if (num31 > num121) {
				num31 = num121;
			}
			if (num123 > num121) {
				num123 = num121;
			}
			ref string reference35 = ref Check.EqText [4];
			reference35 = reference35 + num30.ToString (text54) + " + " + num31.ToString (text54);
			if (CFS.SpecYear ((short)Param.Spec) >= 2004 || flag) {
				ref string reference36 = ref Check.EqText [4];
				reference36 = reference36 + ")= " + num123.ToString (text54) + " <= 1.0";
			} else {
				ref string reference37 = ref Check.EqText [4];
				reference37 = reference37 + " = " + num123.ToString (text54) + " <= 1.0";
			}
			if (System.Math.Round (num123, 3) > 1.0) {
				StringType.MidStmtStr (ref Check.EqText [4], Strings.InStr (Check.EqText [4], "<="), int.MaxValue, "> ");
			}
			if (Param.Torsion & (((CFS.SpecYear ((short)Param.Spec) >= 2007) & (CFS.SpecYear ((short)Param.Spec) < 2022)) || flag)) {
				if ((CwOverride > 0f) & (Check.B != 0f)) {
					Check.Msg += "Unable to check torsion with overridden Cw.\r\n";
				} else if ((Check.Mx == 0f) & (Check.My == 0f) & (Strength.Ba > 0f)) {
					num123 = System.Math.Abs (Check.B) / Strength.Ba;
					Check.Eq [5] = num123;
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference38 = ref Check.EqText [5];
					reference38 = reference38 + "Bimoment unity check".PadRight (50) + num123.ToString (text54) + " <= 1.0";
					if (System.Math.Round (num123, 3) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				} else {
					if (flag) {
						Check.EqText [5] = "Eq. 8-10        (Mx, My)          ";
					} else if (CFS.SpecYear ((short)Param.Spec) <= 2012) {
						Check.EqText [5] = "Section C3.6    (Mx, My)          ";
					} else {
						Check.EqText [5] = "Section H4      (Mx, My)          ";
					}
					float num47;
					if (nPart == 1) {
						string strTrace2 = string.Empty;
						num47 = Part [1].TorsionReduction (Check.Mx, Check.My, Check.B, (byte)Param.Spec, flag, ref strTrace2, blnNet: true);
						CFS.strTrace += strTrace2;
					} else if (Strength.Bn > 0f) {
						num30 = System.Math.Abs (MaxStress (0f, Check.Mx, Check.My, blnNet: true));
						num31 = num4 * System.Math.Abs (Check.B) / Strength.Bn;
						num47 = num30 / (num30 + num31);
						CFS.strTrace += "Combined Bending and Torsion\r\n";
						CFS.strTrace = CFS.strTrace + "  Mx=" + Units.DisplayMoment (Check.Mx, 0, blnShowUnit: true, "", 0, 0) + ", My=" + Units.DisplayMoment (Check.My, 0, blnShowUnit: true, "", 0, 0) + ", B=" + Units.DisplayBimoment (Check.B, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fb_max=" + Units.DisplayStress (num30, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CFS.strTrace = CFS.strTrace + "  Fb+Fw=" + Units.DisplayStress (num30 + num31, 0, blnShowUnit: true, "", 0, 0) + " (conservative)\r\n";
						CFS.strTrace = CFS.strTrace + "  R=" + Units.DisplayNone (num47, "", 0, 0) + "\t" + text10 + "\r\n\r\n";
					} else {
						num47 = Conversions.ToSingle (Interaction.IIf (Check.B == 0f, 1, 0));
					}
					num30 = ((num47 == 0f) ? num121 : ((!(Check.Mx >= 0f)) ? (System.Math.Abs (Check.Mx) / (num47 * Strength.Maxon)) : (System.Math.Abs (Check.Mx) / (num47 * Strength.Maxop))));
					num31 = ((num47 == 0f) ? num121 : ((!(Check.My >= 0f)) ? (System.Math.Abs (Check.My) / (num47 * Strength.Mayon)) : (System.Math.Abs (Check.My) / (num47 * Strength.Mayop))));
					num123 = num30 + num31;
					Check.Eq [5] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference39 = ref Check.EqText [5];
					ref string reference4 = ref reference39;
					reference39 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.0";
					if (System.Math.Round (num123, 3) > 1.0) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				}
			} else if ((Param.Torsion & (CFS.SpecYear ((short)Param.Spec) >= 2022)) && !flag) {
				if ((CwOverride > 0f) & (Check.B != 0f)) {
					Check.Msg += "Unable to check torsion with overridden Cw.\r\n";
				} else {
					Check.EqText [5] = "Eq. H4-1     (Mx, My, B)  ";
					num30 = Conversions.ToSingle (Operators.DivideObject (System.Math.Abs (Check.Mx), Interaction.IIf (Check.Mx >= 0f, Strength.Maxop, Strength.Maxon)));
					num31 = Conversions.ToSingle (Operators.DivideObject (System.Math.Abs (Check.My), Interaction.IIf (Check.My >= 0f, Strength.Mayop, Strength.Mayon)));
					float num122 = System.Math.Abs (Check.B) / Strength.Ba;
					num123 = num30 + num31 + num122;
					Check.Eq [5] = num123;
					if (num30 > num121) {
						num30 = num121;
					}
					if (num31 > num121) {
						num31 = num121;
					}
					if (num122 > num121) {
						num122 = num121;
					}
					if (num123 > num121) {
						num123 = num121;
					}
					ref string reference40 = ref Check.EqText [5];
					ref string reference4 = ref reference40;
					reference40 = reference4 + num30.ToString (text54) + " + " + num31.ToString (text54) + " + " + num122.ToString (text54) + " = " + num123.ToString (text54) + " <= 1.15";
					if (System.Math.Round (num123, 3) > 1.15) {
						StringType.MidStmtStr (ref Check.EqText [5], Strings.InStr (Check.EqText [5], "<="), int.MaxValue, "> ");
					}
				}
			}
		}
		checked {
			Check.VFy = new float[unchecked((int)nPart) + 1];
			Check.VFx = new float[unchecked((int)nPart) + 1];
			int num124 = nPart;
			for (int i = 1; i <= num124; i++) {
				Check.VFy [i] = Check.Vy * Part [i].A * (Part [i].YPosition - Prop.Ycg) / Prop.Ix;
				Check.VFx [i] = Check.Vx * Part [i].A * (Part [i].XPosition - Prop.Xcg) / Prop.Iy;
			}
		}
	}

	public void WebCripCheck (WebCripParameters Param, ref WebCripCheck Check)
	{
		float[,] array = new float[10, 17];
		float[,] array2 = new float[10, 17];
		float[,] array3 = new float[10, 17];
		float[,] array4 = new float[10, 17];
		float[,] array5 = new float[10, 17];
		float[,] array6 = new float[10, 17];
		float[,] array7 = new float[10, 17];
		float[,] array8 = new float[10, 17];
		string[] array9 = new string[17];
		Check.Pne = new float[2];
		Check.Pn = new float[2];
		Check.Pae = new float[2];
		Check.Pa = new float[2];
		Check.QPne = new float[2];
		Check.QPn = new float[2];
		Check.PeText = new string[2];
		array9 [1] = "FS-EOF";
		array9 [2] = "FS-IOF";
		array9 [3] = "FS-ETF";
		array9 [4] = "FS-ITF";
		array9 [5] = "FU-EOF";
		array9 [6] = "FU-IOF";
		array9 [7] = "FU-ETF";
		array9 [8] = "FU-ITF";
		array9 [9] = "US-EOF";
		array9 [10] = "US-IOF";
		array9 [11] = "US-ETF";
		array9 [12] = "US-ITF";
		array9 [13] = "UU-EOF";
		array9 [14] = "UU-IOF";
		array9 [15] = "UU-ETF";
		array9 [16] = "UU-ITF";
		bool flag = Material.IsStainless ();
		string text;
		string text2;
		string text3;
		if (flag) {
			text = "Eq. 7-19";
			text2 = "Eq. 7-20";
			text3 = "Eq. 7-21";
		} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
			text = "Eq. C3.4.1-1";
			text2 = "Eq. C3.4.2-1";
			text3 = "Eq. C3.4.2-2";
		} else {
			text = "Eq. G5-1";
			text2 = "Eq. G6-1";
			text3 = "Eq. G6-2";
		}
		short num = 2;
		array [num, 1] = 4f;
		array2 [num, 1] = 0.14f;
		array3 [num, 1] = 0.35f;
		array4 [num, 1] = 0.02f;
		array5 [num, 1] = 1.75f;
		array6 [num, 1] = 0.85f;
		array7 [num, 1] = 0.75f;
		array8 [num, 1] = 9f;
		array [num, 2] = 13f;
		array2 [num, 2] = 0.23f;
		array3 [num, 2] = 0.14f;
		array4 [num, 2] = 0.01f;
		array5 [num, 2] = 1.65f;
		array6 [num, 2] = 0.9f;
		array7 [num, 2] = 0.8f;
		array8 [num, 2] = 5f;
		array [num, 3] = 7.5f;
		array2 [num, 3] = 0.08f;
		array3 [num, 3] = 0.12f;
		array4 [num, 3] = 0.048f;
		array5 [num, 3] = 1.75f;
		array6 [num, 3] = 0.85f;
		array7 [num, 3] = 0.75f;
		array8 [num, 3] = 12f;
		array [num, 4] = 20f;
		array2 [num, 4] = 0.1f;
		array3 [num, 4] = 0.08f;
		array4 [num, 4] = 0.031f;
		array5 [num, 4] = 1.75f;
		array6 [num, 4] = 0.85f;
		array7 [num, 4] = 0.75f;
		array8 [num, 4] = 12f;
		array [num, 5] = 4f;
		array2 [num, 5] = 0.4f;
		array3 [num, 5] = 0.6f;
		array4 [num, 5] = 0.03f;
		array5 [num, 5] = 1.8f;
		array6 [num, 5] = 0.85f;
		array7 [num, 5] = 0.7f;
		array8 [num, 5] = 2f;
		array [num, 6] = 13f;
		array2 [num, 6] = 0.32f;
		array3 [num, 6] = 0.1f;
		array4 [num, 6] = 0.01f;
		array5 [num, 6] = 1.8f;
		array6 [num, 6] = 0.85f;
		array7 [num, 6] = 0.7f;
		array8 [num, 6] = 1f;
		array [num, 7] = 2f;
		array2 [num, 7] = 0.11f;
		array3 [num, 7] = 0.37f;
		array4 [num, 7] = 0.01f;
		array5 [num, 7] = 2f;
		array6 [num, 7] = 0.75f;
		array7 [num, 7] = 0.65f;
		array8 [num, 7] = 1f;
		array [num, 8] = 13f;
		array2 [num, 8] = 0.47f;
		array3 [num, 8] = 0.25f;
		array4 [num, 8] = 0.04f;
		array5 [num, 8] = 1.9f;
		array6 [num, 8] = 0.8f;
		array7 [num, 8] = 0.65f;
		array8 [num, 8] = 1f;
		array [num, 9] = 4f;
		array2 [num, 9] = 0.14f;
		array3 [num, 9] = 0.35f;
		array4 [num, 9] = 0.02f;
		array5 [num, 9] = 1.85f;
		array6 [num, 9] = 0.8f;
		array7 [num, 9] = 0.7f;
		array8 [num, 9] = 5f;
		array [num, 10] = 13f;
		array2 [num, 10] = 0.23f;
		array3 [num, 10] = 0.14f;
		array4 [num, 10] = 0.01f;
		array5 [num, 10] = 1.65f;
		array6 [num, 10] = 0.9f;
		array7 [num, 10] = 0.8f;
		array8 [num, 10] = 5f;
		array [num, 11] = 13f;
		array2 [num, 11] = 0.32f;
		array3 [num, 11] = 0.05f;
		array4 [num, 11] = 0.04f;
		array5 [num, 11] = 1.65f;
		array6 [num, 11] = 0.9f;
		array7 [num, 11] = 0.8f;
		array8 [num, 11] = 3f;
		array [num, 12] = 24f;
		array2 [num, 12] = 0.52f;
		array3 [num, 12] = 0.15f;
		array4 [num, 12] = 0.001f;
		array5 [num, 12] = 1.9f;
		array6 [num, 12] = 0.8f;
		array7 [num, 12] = 0.65f;
		array8 [num, 12] = 3f;
		array [num, 13] = 4f;
		array2 [num, 13] = 0.4f;
		array3 [num, 13] = 0.6f;
		array4 [num, 13] = 0.03f;
		array5 [num, 13] = 1.8f;
		array6 [num, 13] = 0.85f;
		array7 [num, 13] = 0.7f;
		array8 [num, 13] = 2f;
		array [num, 14] = 13f;
		array2 [num, 14] = 0.32f;
		array3 [num, 14] = 0.1f;
		array4 [num, 14] = 0.01f;
		array5 [num, 14] = 1.8f;
		array6 [num, 14] = 0.85f;
		array7 [num, 14] = 0.7f;
		array8 [num, 14] = 1f;
		array [num, 15] = 2f;
		array2 [num, 15] = 0.11f;
		array3 [num, 15] = 0.37f;
		array4 [num, 15] = 0.01f;
		array5 [num, 15] = 2f;
		array6 [num, 15] = 0.75f;
		array7 [num, 15] = 0.65f;
		array8 [num, 15] = 1f;
		array [num, 16] = 13f;
		array2 [num, 16] = 0.47f;
		array3 [num, 16] = 0.25f;
		array4 [num, 16] = 0.04f;
		array5 [num, 16] = 1.9f;
		array6 [num, 16] = 0.8f;
		array7 [num, 16] = 0.65f;
		array8 [num, 16] = 1f;
		if (flag) {
			array5 [num, 1] = 1.9f;
			array6 [num, 1] = 0.8f;
			array5 [num, 2] = 1.75f;
			array6 [num, 2] = 0.85f;
			array5 [num, 3] = 1.9f;
			array6 [num, 3] = 0.8f;
			array5 [num, 4] = 1.9f;
			array6 [num, 4] = 0.8f;
			array5 [num, 5] = 1.9f;
			array6 [num, 5] = 0.8f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array5 [num, 7] = 2.15f;
			array6 [num, 7] = 0.7f;
			array5 [num, 8] = 2f;
			array6 [num, 8] = 0.75f;
			array5 [num, 9] = 2f;
			array6 [num, 9] = 0.75f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array5 [num, 11] = 1.75f;
			array6 [num, 11] = 0.85f;
			array5 [num, 12] = 2f;
			array6 [num, 12] = 0.75f;
			array5 [num, 13] = 1.9f;
			array6 [num, 13] = 0.8f;
			array5 [num, 14] = 1.9f;
			array6 [num, 14] = 0.8f;
			array5 [num, 15] = 2.15f;
			array6 [num, 15] = 0.7f;
			array5 [num, 16] = 2f;
			array6 [num, 16] = 0.75f;
		}
		num = 5;
		short num2 = 1;
		checked {
			do {
				array [num, num2] = array [2, num2];
				array2 [num, num2] = array2 [2, num2];
				array3 [num, num2] = array3 [2, num2];
				array4 [num, num2] = array4 [2, num2];
				array5 [num, num2] = array5 [2, num2];
				array6 [num, num2] = array6 [2, num2];
				array7 [num, num2] = array7 [2, num2];
				array8 [num, num2] = array8 [2, num2];
				num2 = (short)unchecked(num2 + 1);
			} while (num2 <= 16);
			num = 3;
		}
		if ((CFS.IsSpec2001 ((short)Param.Spec) | CFS.IsSpec2004 ((short)Param.Spec)) && !flag) {
			array [num, 1] = 10f;
			array2 [num, 1] = 0.14f;
			array3 [num, 1] = 0.28f;
			array4 [num, 1] = 0.001f;
			array5 [num, 1] = 2f;
			array6 [num, 1] = 0.75f;
			array7 [num, 1] = 0.6f;
			array8 [num, 1] = 5f;
			array [num, 2] = 20f;
			array2 [num, 2] = 0.15f;
			array3 [num, 2] = 0.05f;
			array4 [num, 2] = 0.003f;
			array5 [num, 2] = 1.65f;
			array6 [num, 2] = 0.9f;
			array7 [num, 2] = 0.8f;
			array8 [num, 2] = 5f;
			array [num, 3] = 15.5f;
			array2 [num, 3] = 0.09f;
			array3 [num, 3] = 0.08f;
			array4 [num, 3] = 0.04f;
			array5 [num, 3] = 2f;
			array6 [num, 3] = 0.75f;
			array7 [num, 3] = 0.65f;
			array8 [num, 3] = 3f;
			array [num, 4] = 36f;
			array2 [num, 4] = 0.14f;
			array3 [num, 4] = 0.08f;
			array4 [num, 4] = 0.04f;
			array5 [num, 4] = 2f;
			array6 [num, 4] = 0.75f;
			array7 [num, 4] = 0.65f;
			array8 [num, 4] = 3f;
			array [num, 5] = 10f;
			array2 [num, 5] = 0.14f;
			array3 [num, 5] = 0.28f;
			array4 [num, 5] = 0.001f;
			array5 [num, 5] = 2f;
			array6 [num, 5] = 0.75f;
			array7 [num, 5] = 0.6f;
			array8 [num, 5] = 5f;
			array [num, 6] = 20.5f;
			array2 [num, 6] = 0.17f;
			array3 [num, 6] = 0.11f;
			array4 [num, 6] = 0.001f;
			array5 [num, 6] = 1.75f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.75f;
			array8 [num, 6] = 3f;
			array [num, 9] = 10f;
			array2 [num, 9] = 0.14f;
			array3 [num, 9] = 0.28f;
			array4 [num, 9] = 0.001f;
			array5 [num, 9] = 2f;
			array6 [num, 9] = 0.75f;
			array7 [num, 9] = 0.6f;
			array8 [num, 9] = 5f;
			array [num, 10] = 20.5f;
			array2 [num, 10] = 0.17f;
			array3 [num, 10] = 0.11f;
			array4 [num, 10] = 0.001f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array7 [num, 10] = 0.75f;
			array8 [num, 10] = 3f;
			array [num, 11] = 15.5f;
			array2 [num, 11] = 0.09f;
			array3 [num, 11] = 0.08f;
			array4 [num, 11] = 0.04f;
			array5 [num, 11] = 2f;
			array6 [num, 11] = 0.75f;
			array7 [num, 11] = 0.65f;
			array8 [num, 11] = 3f;
			array [num, 12] = 36f;
			array2 [num, 12] = 0.14f;
			array3 [num, 12] = 0.08f;
			array4 [num, 12] = 0.04f;
			array5 [num, 12] = 2f;
			array6 [num, 12] = 0.75f;
			array7 [num, 12] = 0.65f;
			array8 [num, 12] = 3f;
			array [num, 13] = 10f;
			array2 [num, 13] = 0.14f;
			array3 [num, 13] = 0.28f;
			array4 [num, 13] = 0.001f;
			array5 [num, 13] = 2f;
			array6 [num, 13] = 0.75f;
			array7 [num, 13] = 0.6f;
			array8 [num, 13] = 5f;
			array [num, 14] = 20.5f;
			array2 [num, 14] = 0.17f;
			array3 [num, 14] = 0.11f;
			array4 [num, 14] = 0.001f;
			array5 [num, 14] = 1.75f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.75f;
			array8 [num, 14] = 3f;
		} else {
			array [num, 1] = 10f;
			array2 [num, 1] = 0.14f;
			array3 [num, 1] = 0.28f;
			array4 [num, 1] = 0.001f;
			array5 [num, 1] = 2f;
			array6 [num, 1] = 0.75f;
			array7 [num, 1] = 0.6f;
			array8 [num, 1] = 5f;
			array [num, 2] = 20.5f;
			array2 [num, 2] = 0.17f;
			array3 [num, 2] = 0.11f;
			array4 [num, 2] = 0.001f;
			array5 [num, 2] = 1.75f;
			array6 [num, 2] = 0.85f;
			array7 [num, 2] = 0.75f;
			array8 [num, 2] = 5f;
			array [num, 3] = 15.5f;
			array2 [num, 3] = 0.09f;
			array3 [num, 3] = 0.08f;
			array4 [num, 3] = 0.04f;
			array5 [num, 3] = 2f;
			array6 [num, 3] = 0.75f;
			array7 [num, 3] = 0.65f;
			array8 [num, 3] = 3f;
			array [num, 4] = 36f;
			array2 [num, 4] = 0.14f;
			array3 [num, 4] = 0.08f;
			array4 [num, 4] = 0.04f;
			array5 [num, 4] = 2f;
			array6 [num, 4] = 0.75f;
			array7 [num, 4] = 0.65f;
			array8 [num, 4] = 3f;
			array [num, 5] = 10f;
			array2 [num, 5] = 0.14f;
			array3 [num, 5] = 0.28f;
			array4 [num, 5] = 0.001f;
			array5 [num, 5] = 2f;
			array6 [num, 5] = 0.75f;
			array7 [num, 5] = 0.6f;
			array8 [num, 5] = 5f;
			array [num, 6] = 20.5f;
			array2 [num, 6] = 0.17f;
			array3 [num, 6] = 0.11f;
			array4 [num, 6] = 0.001f;
			array5 [num, 6] = 1.75f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.75f;
			array8 [num, 6] = 3f;
			array [num, 9] = 10f;
			array2 [num, 9] = 0.14f;
			array3 [num, 9] = 0.28f;
			array4 [num, 9] = 0.001f;
			array5 [num, 9] = 2f;
			array6 [num, 9] = 0.75f;
			array7 [num, 9] = 0.6f;
			array8 [num, 9] = 5f;
			array [num, 10] = 20.5f;
			array2 [num, 10] = 0.17f;
			array3 [num, 10] = 0.11f;
			array4 [num, 10] = 0.001f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array7 [num, 10] = 0.75f;
			array8 [num, 10] = 3f;
			array [num, 11] = 15.5f;
			array2 [num, 11] = 0.09f;
			array3 [num, 11] = 0.08f;
			array4 [num, 11] = 0.04f;
			array5 [num, 11] = 2f;
			array6 [num, 11] = 0.75f;
			array7 [num, 11] = 0.65f;
			array8 [num, 11] = 3f;
			array [num, 12] = 36f;
			array2 [num, 12] = 0.14f;
			array3 [num, 12] = 0.08f;
			array4 [num, 12] = 0.04f;
			array5 [num, 12] = 2f;
			array6 [num, 12] = 0.75f;
			array7 [num, 12] = 0.65f;
			array8 [num, 12] = 3f;
			array [num, 13] = 10f;
			array2 [num, 13] = 0.14f;
			array3 [num, 13] = 0.28f;
			array4 [num, 13] = 0.001f;
			array5 [num, 13] = 2f;
			array6 [num, 13] = 0.75f;
			array7 [num, 13] = 0.6f;
			array8 [num, 13] = 5f;
			array [num, 14] = 20.5f;
			array2 [num, 14] = 0.17f;
			array3 [num, 14] = 0.11f;
			array4 [num, 14] = 0.001f;
			array5 [num, 14] = 1.75f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.75f;
			array8 [num, 14] = 3f;
		}
		if (flag) {
			array5 [num, 1] = 2.15f;
			array6 [num, 1] = 0.7f;
			array5 [num, 2] = 1.9f;
			array6 [num, 2] = 0.8f;
			array5 [num, 3] = 2.15f;
			array6 [num, 3] = 0.7f;
			array5 [num, 4] = 2.15f;
			array6 [num, 4] = 0.7f;
			array5 [num, 5] = 2.15f;
			array6 [num, 5] = 0.7f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array5 [num, 9] = 2.15f;
			array6 [num, 9] = 0.7f;
			array5 [num, 10] = 1.9f;
			array6 [num, 10] = 0.8f;
			array5 [num, 11] = 2.15f;
			array6 [num, 11] = 0.7f;
			array5 [num, 12] = 2.15f;
			array6 [num, 12] = 0.7f;
			array5 [num, 13] = 2.15f;
			array6 [num, 13] = 0.7f;
			array5 [num, 14] = 1.9f;
			array6 [num, 14] = 0.8f;
		}
		num = 6;
		if ((CFS.IsSpec2001 ((short)Param.Spec) | CFS.IsSpec2004 ((short)Param.Spec)) && !flag) {
			array [num, 1] = 4f;
			array2 [num, 1] = 0.14f;
			array3 [num, 1] = 0.35f;
			array4 [num, 1] = 0.02f;
			array5 [num, 1] = 1.75f;
			array6 [num, 1] = 0.85f;
			array7 [num, 1] = 0.75f;
			array8 [num, 1] = 9f;
			array [num, 2] = 13f;
			array2 [num, 2] = 0.23f;
			array3 [num, 2] = 0.14f;
			array4 [num, 2] = 0.01f;
			array5 [num, 2] = 1.65f;
			array6 [num, 2] = 0.9f;
			array7 [num, 2] = 0.8f;
			array8 [num, 2] = 5f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.05f;
			array3 [num, 3] = 0.16f;
			array4 [num, 3] = 0.052f;
			array5 [num, 3] = 1.75f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.75f;
			array8 [num, 3] = 12f;
			array [num, 4] = 24f;
			array2 [num, 4] = 0.07f;
			array3 [num, 4] = 0.07f;
			array4 [num, 4] = 0.04f;
			array5 [num, 4] = 1.85f;
			array6 [num, 4] = 0.8f;
			array7 [num, 4] = 0.7f;
			array8 [num, 4] = 12f;
			array [num, 5] = 4f;
			array2 [num, 5] = 0.4f;
			array3 [num, 5] = 0.6f;
			array4 [num, 5] = 0.03f;
			array5 [num, 5] = 1.8f;
			array6 [num, 5] = 0.85f;
			array7 [num, 5] = 0.7f;
			array8 [num, 5] = 2f;
			array [num, 6] = 13f;
			array2 [num, 6] = 0.32f;
			array3 [num, 6] = 0.1f;
			array4 [num, 6] = 0.01f;
			array5 [num, 6] = 1.8f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.7f;
			array8 [num, 6] = 1f;
			array [num, 7] = 2f;
			array2 [num, 7] = 0.11f;
			array3 [num, 7] = 0.37f;
			array4 [num, 7] = 0.01f;
			array5 [num, 7] = 2f;
			array6 [num, 7] = 0.75f;
			array7 [num, 7] = 0.65f;
			array8 [num, 7] = 1f;
			array [num, 8] = 13f;
			array2 [num, 8] = 0.47f;
			array3 [num, 8] = 0.25f;
			array4 [num, 8] = 0.04f;
			array5 [num, 8] = 1.9f;
			array6 [num, 8] = 0.8f;
			array7 [num, 8] = 0.65f;
			array8 [num, 8] = 1f;
			array [num, 9] = 5f;
			array2 [num, 9] = 0.09f;
			array3 [num, 9] = 0.02f;
			array4 [num, 9] = 0.001f;
			array5 [num, 9] = 1.8f;
			array6 [num, 9] = 0.85f;
			array7 [num, 9] = 0.75f;
			array8 [num, 9] = 5f;
			array [num, 10] = 13f;
			array2 [num, 10] = 0.23f;
			array3 [num, 10] = 0.14f;
			array4 [num, 10] = 0.01f;
			array5 [num, 10] = 1.65f;
			array6 [num, 10] = 0.9f;
			array7 [num, 10] = 0.8f;
			array8 [num, 10] = 5f;
			array [num, 11] = 13f;
			array2 [num, 11] = 0.32f;
			array3 [num, 11] = 0.05f;
			array4 [num, 11] = 0.04f;
			array5 [num, 11] = 1.65f;
			array6 [num, 11] = 0.9f;
			array7 [num, 11] = 0.8f;
			array8 [num, 11] = 3f;
			array [num, 12] = 24f;
			array2 [num, 12] = 0.52f;
			array3 [num, 12] = 0.15f;
			array4 [num, 12] = 0.001f;
			array5 [num, 12] = 1.9f;
			array6 [num, 12] = 0.8f;
			array7 [num, 12] = 0.65f;
			array8 [num, 12] = 3f;
			array [num, 13] = 4f;
			array2 [num, 13] = 0.4f;
			array3 [num, 13] = 0.6f;
			array4 [num, 13] = 0.03f;
			array5 [num, 13] = 1.8f;
			array6 [num, 13] = 0.85f;
			array7 [num, 13] = 0.7f;
			array8 [num, 13] = 2f;
			array [num, 14] = 13f;
			array2 [num, 14] = 0.32f;
			array3 [num, 14] = 0.1f;
			array4 [num, 14] = 0.01f;
			array5 [num, 14] = 1.8f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.7f;
			array8 [num, 14] = 1f;
			array [num, 15] = 2f;
			array2 [num, 15] = 0.11f;
			array3 [num, 15] = 0.37f;
			array4 [num, 15] = 0.01f;
			array5 [num, 15] = 2f;
			array6 [num, 15] = 0.75f;
			array7 [num, 15] = 0.65f;
			array8 [num, 15] = 1f;
			array [num, 16] = 13f;
			array2 [num, 16] = 0.47f;
			array3 [num, 16] = 0.25f;
			array4 [num, 16] = 0.04f;
			array5 [num, 16] = 1.9f;
			array6 [num, 16] = 0.8f;
			array7 [num, 16] = 0.65f;
			array8 [num, 16] = 1f;
		} else {
			array [num, 1] = 4f;
			array2 [num, 1] = 0.14f;
			array3 [num, 1] = 0.35f;
			array4 [num, 1] = 0.02f;
			array5 [num, 1] = 1.75f;
			array6 [num, 1] = 0.85f;
			array7 [num, 1] = 0.75f;
			array8 [num, 1] = 9f;
			array [num, 2] = 13f;
			array2 [num, 2] = 0.23f;
			array3 [num, 2] = 0.14f;
			array4 [num, 2] = 0.01f;
			array5 [num, 2] = 1.65f;
			array6 [num, 2] = 0.9f;
			array7 [num, 2] = 0.8f;
			array8 [num, 2] = 5.5f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.05f;
			array3 [num, 3] = 0.16f;
			array4 [num, 3] = 0.052f;
			array5 [num, 3] = 1.75f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.75f;
			array8 [num, 3] = 12f;
			array [num, 4] = 24f;
			array2 [num, 4] = 0.07f;
			array3 [num, 4] = 0.07f;
			array4 [num, 4] = 0.04f;
			array5 [num, 4] = 1.85f;
			array6 [num, 4] = 0.8f;
			array7 [num, 4] = 0.7f;
			array8 [num, 4] = 12f;
			array [num, 5] = 4f;
			array2 [num, 5] = 0.4f;
			array3 [num, 5] = 0.6f;
			array4 [num, 5] = 0.03f;
			array5 [num, 5] = 1.8f;
			array6 [num, 5] = 0.85f;
			array7 [num, 5] = 0.7f;
			array8 [num, 5] = 2f;
			array [num, 6] = 13f;
			array2 [num, 6] = 0.32f;
			array3 [num, 6] = 0.1f;
			array4 [num, 6] = 0.01f;
			array5 [num, 6] = 1.8f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.7f;
			array8 [num, 6] = 1f;
			array [num, 7] = 2f;
			array2 [num, 7] = 0.11f;
			array3 [num, 7] = 0.37f;
			array4 [num, 7] = 0.01f;
			array5 [num, 7] = 2f;
			array6 [num, 7] = 0.75f;
			array7 [num, 7] = 0.65f;
			array8 [num, 7] = 1f;
			array [num, 8] = 13f;
			array2 [num, 8] = 0.47f;
			array3 [num, 8] = 0.25f;
			array4 [num, 8] = 0.04f;
			array5 [num, 8] = 1.9f;
			array6 [num, 8] = 0.8f;
			array7 [num, 8] = 0.65f;
			array8 [num, 8] = 1f;
			array [num, 9] = 5f;
			array2 [num, 9] = 0.09f;
			array3 [num, 9] = 0.02f;
			array4 [num, 9] = 0.001f;
			array5 [num, 9] = 1.8f;
			array6 [num, 9] = 0.85f;
			array7 [num, 9] = 0.75f;
			array8 [num, 9] = 5f;
			array [num, 10] = 13f;
			array2 [num, 10] = 0.23f;
			array3 [num, 10] = 0.14f;
			array4 [num, 10] = 0.01f;
			array5 [num, 10] = 1.65f;
			array6 [num, 10] = 0.9f;
			array7 [num, 10] = 0.8f;
			array8 [num, 10] = 5f;
			array [num, 11] = 13f;
			array2 [num, 11] = 0.32f;
			array3 [num, 11] = 0.05f;
			array4 [num, 11] = 0.04f;
			array5 [num, 11] = 1.65f;
			array6 [num, 11] = 0.9f;
			array7 [num, 11] = 0.8f;
			array8 [num, 11] = 3f;
			array [num, 12] = 24f;
			array2 [num, 12] = 0.52f;
			array3 [num, 12] = 0.15f;
			array4 [num, 12] = 0.001f;
			array5 [num, 12] = 1.9f;
			array6 [num, 12] = 0.8f;
			array7 [num, 12] = 0.65f;
			array8 [num, 12] = 3f;
			array [num, 13] = 4f;
			array2 [num, 13] = 0.4f;
			array3 [num, 13] = 0.6f;
			array4 [num, 13] = 0.03f;
			array5 [num, 13] = 1.8f;
			array6 [num, 13] = 0.85f;
			array7 [num, 13] = 0.7f;
			array8 [num, 13] = 2f;
			array [num, 14] = 13f;
			array2 [num, 14] = 0.32f;
			array3 [num, 14] = 0.1f;
			array4 [num, 14] = 0.01f;
			array5 [num, 14] = 1.8f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.7f;
			array8 [num, 14] = 1f;
			array [num, 15] = 2f;
			array2 [num, 15] = 0.11f;
			array3 [num, 15] = 0.37f;
			array4 [num, 15] = 0.01f;
			array5 [num, 15] = 2f;
			array6 [num, 15] = 0.75f;
			array7 [num, 15] = 0.65f;
			array8 [num, 15] = 1f;
			array [num, 16] = 13f;
			array2 [num, 16] = 0.47f;
			array3 [num, 16] = 0.25f;
			array4 [num, 16] = 0.04f;
			array5 [num, 16] = 1.9f;
			array6 [num, 16] = 0.8f;
			array7 [num, 16] = 0.65f;
			array8 [num, 16] = 1f;
		}
		if (flag) {
			array5 [num, 1] = 1.9f;
			array6 [num, 1] = 0.8f;
			array5 [num, 2] = 1.75f;
			array6 [num, 2] = 0.85f;
			array5 [num, 3] = 1.9f;
			array6 [num, 3] = 0.8f;
			array5 [num, 4] = 2f;
			array6 [num, 4] = 0.75f;
			array5 [num, 5] = 1.9f;
			array6 [num, 5] = 0.8f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array5 [num, 7] = 2.15f;
			array6 [num, 7] = 0.7f;
			array5 [num, 8] = 2f;
			array6 [num, 8] = 0.75f;
			array5 [num, 9] = 1.9f;
			array6 [num, 9] = 0.8f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array5 [num, 11] = 1.75f;
			array6 [num, 11] = 0.85f;
			array5 [num, 12] = 2f;
			array6 [num, 12] = 0.75f;
			array5 [num, 13] = 1.9f;
			array6 [num, 13] = 0.8f;
			array5 [num, 14] = 1.9f;
			array6 [num, 14] = 0.8f;
			array5 [num, 15] = 2.15f;
			array6 [num, 15] = 0.7f;
			array5 [num, 16] = 2f;
			array6 [num, 16] = 0.75f;
		}
		num = 4;
		num2 = 1;
		checked {
			do {
				array [num, num2] = array [6, num2];
				array2 [num, num2] = array2 [6, num2];
				array3 [num, num2] = array3 [6, num2];
				array4 [num, num2] = array4 [6, num2];
				array5 [num, num2] = array5 [6, num2];
				array6 [num, num2] = array6 [6, num2];
				array7 [num, num2] = array7 [6, num2];
				array8 [num, num2] = array8 [6, num2];
				num2 = (short)unchecked(num2 + 1);
			} while (num2 <= 16);
			num = 7;
		}
		if ((CFS.IsSpec2001 ((short)Param.Spec) | CFS.IsSpec2004 ((short)Param.Spec)) && !flag) {
			array [num, 1] = 4f;
			array2 [num, 1] = 0.25f;
			array3 [num, 1] = 0.68f;
			array4 [num, 1] = 0.04f;
			array5 [num, 1] = 2f;
			array6 [num, 1] = 0.75f;
			array7 [num, 1] = 0.65f;
			array8 [num, 1] = 5f;
			array [num, 2] = 17f;
			array2 [num, 2] = 0.13f;
			array3 [num, 2] = 0.13f;
			array4 [num, 2] = 0.04f;
			array5 [num, 2] = 1.9f;
			array6 [num, 2] = 0.8f;
			array7 [num, 2] = 0.7f;
			array8 [num, 2] = 10f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.1f;
			array3 [num, 3] = 0.07f;
			array4 [num, 3] = 0.03f;
			array5 [num, 3] = 1.75f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.75f;
			array8 [num, 3] = 10f;
			array [num, 4] = 10f;
			array2 [num, 4] = 0.14f;
			array3 [num, 4] = 0.22f;
			array4 [num, 4] = 0.02f;
			array5 [num, 4] = 1.8f;
			array6 [num, 4] = 0.85f;
			array7 [num, 4] = 0.75f;
			array8 [num, 4] = 10f;
			array [num, 5] = 4f;
			array2 [num, 5] = 0.25f;
			array3 [num, 5] = 0.68f;
			array4 [num, 5] = 0.04f;
			array5 [num, 5] = 2f;
			array6 [num, 5] = 0.75f;
			array7 [num, 5] = 0.65f;
			array8 [num, 5] = 5f;
			array [num, 6] = 17f;
			array2 [num, 6] = 0.13f;
			array3 [num, 6] = 0.13f;
			array4 [num, 6] = 0.04f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array7 [num, 6] = 0.7f;
			array8 [num, 6] = 10f;
			array [num, 7] = 9f;
			array2 [num, 7] = 0.1f;
			array3 [num, 7] = 0.07f;
			array4 [num, 7] = 0.03f;
			array5 [num, 7] = 1.75f;
			array6 [num, 7] = 0.85f;
			array7 [num, 7] = 0.75f;
			array8 [num, 7] = 10f;
			array [num, 8] = 10f;
			array2 [num, 8] = 0.14f;
			array3 [num, 8] = 0.22f;
			array4 [num, 8] = 0.02f;
			array5 [num, 8] = 1.8f;
			array6 [num, 8] = 0.85f;
			array7 [num, 8] = 0.75f;
			array8 [num, 8] = 10f;
			array [num, 9] = 4f;
			array2 [num, 9] = 0.25f;
			array3 [num, 9] = 0.68f;
			array4 [num, 9] = 0.04f;
			array5 [num, 9] = 2f;
			array6 [num, 9] = 0.75f;
			array7 [num, 9] = 0.65f;
			array8 [num, 9] = 4f;
			array [num, 10] = 17f;
			array2 [num, 10] = 0.13f;
			array3 [num, 10] = 0.13f;
			array4 [num, 10] = 0.04f;
			array5 [num, 10] = 1.7f;
			array6 [num, 10] = 0.9f;
			array7 [num, 10] = 0.75f;
			array8 [num, 10] = 4f;
			array [num, 13] = 4f;
			array2 [num, 13] = 0.25f;
			array3 [num, 13] = 0.68f;
			array4 [num, 13] = 0.04f;
			array5 [num, 13] = 2f;
			array6 [num, 13] = 0.75f;
			array7 [num, 13] = 0.65f;
			array8 [num, 13] = 4f;
			array [num, 14] = 17f;
			array2 [num, 14] = 0.13f;
			array3 [num, 14] = 0.13f;
			array4 [num, 14] = 0.04f;
			array5 [num, 14] = 1.7f;
			array6 [num, 14] = 0.9f;
			array7 [num, 14] = 0.75f;
			array8 [num, 14] = 4f;
		} else {
			array [num, 1] = 4f;
			array2 [num, 1] = 0.25f;
			array3 [num, 1] = 0.68f;
			array4 [num, 1] = 0.04f;
			array5 [num, 1] = 2f;
			array6 [num, 1] = 0.75f;
			array7 [num, 1] = 0.65f;
			array8 [num, 1] = 5f;
			array [num, 2] = 17f;
			array2 [num, 2] = 0.13f;
			array3 [num, 2] = 0.13f;
			array4 [num, 2] = 0.04f;
			array5 [num, 2] = 1.8f;
			array6 [num, 2] = 0.85f;
			array7 [num, 2] = 0.7f;
			array8 [num, 2] = 10f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.1f;
			array3 [num, 3] = 0.07f;
			array4 [num, 3] = 0.03f;
			array5 [num, 3] = 1.75f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.75f;
			array8 [num, 3] = 10f;
			array [num, 4] = 10f;
			array2 [num, 4] = 0.14f;
			array3 [num, 4] = 0.22f;
			array4 [num, 4] = 0.02f;
			array5 [num, 4] = 1.8f;
			array6 [num, 4] = 0.85f;
			array7 [num, 4] = 0.75f;
			array8 [num, 4] = 10f;
			array [num, 5] = 4f;
			array2 [num, 5] = 0.25f;
			array3 [num, 5] = 0.68f;
			array4 [num, 5] = 0.04f;
			array5 [num, 5] = 2f;
			array6 [num, 5] = 0.75f;
			array7 [num, 5] = 0.65f;
			array8 [num, 5] = 5f;
			array [num, 6] = 17f;
			array2 [num, 6] = 0.13f;
			array3 [num, 6] = 0.13f;
			array4 [num, 6] = 0.04f;
			array5 [num, 6] = 1.8f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.7f;
			array8 [num, 6] = 10f;
			array [num, 7] = 9f;
			array2 [num, 7] = 0.1f;
			array3 [num, 7] = 0.07f;
			array4 [num, 7] = 0.03f;
			array5 [num, 7] = 1.75f;
			array6 [num, 7] = 0.85f;
			array7 [num, 7] = 0.75f;
			array8 [num, 7] = 10f;
			array [num, 8] = 10f;
			array2 [num, 8] = 0.14f;
			array3 [num, 8] = 0.22f;
			array4 [num, 8] = 0.02f;
			array5 [num, 8] = 1.8f;
			array6 [num, 8] = 0.85f;
			array7 [num, 8] = 0.75f;
			array8 [num, 8] = 10f;
			array [num, 9] = 4f;
			array2 [num, 9] = 0.25f;
			array3 [num, 9] = 0.68f;
			array4 [num, 9] = 0.04f;
			array5 [num, 9] = 2f;
			array6 [num, 9] = 0.75f;
			array7 [num, 9] = 0.65f;
			array8 [num, 9] = 4f;
			array [num, 10] = 17f;
			array2 [num, 10] = 0.13f;
			array3 [num, 10] = 0.13f;
			array4 [num, 10] = 0.04f;
			array5 [num, 10] = 1.8f;
			array6 [num, 10] = 0.85f;
			array7 [num, 10] = 0.7f;
			array8 [num, 10] = 4f;
			array [num, 13] = 4f;
			array2 [num, 13] = 0.25f;
			array3 [num, 13] = 0.68f;
			array4 [num, 13] = 0.04f;
			array5 [num, 13] = 2f;
			array6 [num, 13] = 0.75f;
			array7 [num, 13] = 0.65f;
			array8 [num, 13] = 4f;
			array [num, 14] = 17f;
			array2 [num, 14] = 0.13f;
			array3 [num, 14] = 0.13f;
			array4 [num, 14] = 0.04f;
			array5 [num, 14] = 1.8f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.7f;
			array8 [num, 14] = 4f;
			if (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag) {
				array8 [num, 9] = 5f;
				array8 [num, 10] = 10f;
				array8 [num, 13] = 5f;
				array8 [num, 14] = 10f;
			}
		}
		if (flag) {
			array5 [num, 1] = 2.15f;
			array6 [num, 1] = 0.7f;
			array5 [num, 2] = 1.9f;
			array6 [num, 2] = 0.8f;
			array5 [num, 3] = 1.9f;
			array6 [num, 3] = 0.8f;
			array5 [num, 4] = 1.9f;
			array6 [num, 4] = 0.8f;
			array5 [num, 5] = 2.15f;
			array6 [num, 5] = 0.7f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array5 [num, 7] = 1.9f;
			array6 [num, 7] = 0.8f;
			array5 [num, 8] = 1.9f;
			array6 [num, 8] = 0.8f;
			array5 [num, 9] = 2.15f;
			array6 [num, 9] = 0.7f;
			array5 [num, 10] = 1.9f;
			array6 [num, 10] = 0.8f;
			array5 [num, 13] = 2.15f;
			array6 [num, 13] = 0.7f;
			array5 [num, 14] = 1.9f;
			array6 [num, 14] = 0.8f;
		}
		num = 8;
		if (CFS.IsSpec2001 ((short)Param.Spec) && !flag) {
			array [num, 1] = 3f;
			array2 [num, 1] = 0.08f;
			array3 [num, 1] = 0.7f;
			array4 [num, 1] = 0.055f;
			array5 [num, 1] = 2.25f;
			array6 [num, 1] = 0.65f;
			array7 [num, 1] = 0.55f;
			array8 [num, 1] = 7f;
			array [num, 2] = 8f;
			array2 [num, 2] = 0.1f;
			array3 [num, 2] = 0.17f;
			array4 [num, 2] = 0.004f;
			array5 [num, 2] = 1.75f;
			array6 [num, 2] = 0.85f;
			array7 [num, 2] = 0.75f;
			array8 [num, 2] = 10f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.12f;
			array3 [num, 3] = 0.14f;
			array4 [num, 3] = 0.04f;
			array5 [num, 3] = 1.8f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.7f;
			array8 [num, 3] = 10f;
			array [num, 4] = 10f;
			array2 [num, 4] = 0.11f;
			array3 [num, 4] = 0.21f;
			array4 [num, 4] = 0.02f;
			array5 [num, 4] = 1.75f;
			array6 [num, 4] = 0.85f;
			array7 [num, 4] = 0.75f;
			array8 [num, 4] = 10f;
			array [num, 5] = 3f;
			array2 [num, 5] = 0.08f;
			array3 [num, 5] = 0.7f;
			array4 [num, 5] = 0.055f;
			array5 [num, 5] = 2.25f;
			array6 [num, 5] = 0.65f;
			array7 [num, 5] = 0.55f;
			array8 [num, 5] = 7f;
			array [num, 6] = 8f;
			array2 [num, 6] = 0.1f;
			array3 [num, 6] = 0.17f;
			array4 [num, 6] = 0.004f;
			array5 [num, 6] = 1.75f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.75f;
			array8 [num, 6] = 10f;
			array [num, 7] = 9f;
			array2 [num, 7] = 0.12f;
			array3 [num, 7] = 0.14f;
			array4 [num, 7] = 0.04f;
			array5 [num, 7] = 1.8f;
			array6 [num, 7] = 0.85f;
			array7 [num, 7] = 0.7f;
			array8 [num, 7] = 10f;
			array [num, 8] = 10f;
			array2 [num, 8] = 0.11f;
			array3 [num, 8] = 0.21f;
			array4 [num, 8] = 0.02f;
			array5 [num, 8] = 1.75f;
			array6 [num, 8] = 0.85f;
			array7 [num, 8] = 0.75f;
			array8 [num, 8] = 10f;
			array [num, 9] = 3f;
			array2 [num, 9] = 0.08f;
			array3 [num, 9] = 0.7f;
			array4 [num, 9] = 0.055f;
			array5 [num, 9] = 2.25f;
			array6 [num, 9] = 0.65f;
			array7 [num, 9] = 0.55f;
			array8 [num, 9] = 7f;
			array [num, 10] = 8f;
			array2 [num, 10] = 0.1f;
			array3 [num, 10] = 0.17f;
			array4 [num, 10] = 0.004f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array7 [num, 10] = 0.75f;
			array8 [num, 10] = 7f;
			array [num, 11] = 6f;
			array2 [num, 11] = 0.16f;
			array3 [num, 11] = 0.15f;
			array4 [num, 11] = 0.05f;
			array5 [num, 11] = 1.65f;
			array6 [num, 11] = 0.9f;
			array7 [num, 11] = 0.8f;
			array8 [num, 11] = 5f;
			array [num, 12] = 17f;
			array2 [num, 12] = 0.1f;
			array3 [num, 12] = 0.1f;
			array4 [num, 12] = 0.046f;
			array5 [num, 12] = 1.65f;
			array6 [num, 12] = 0.9f;
			array7 [num, 12] = 0.8f;
			array8 [num, 12] = 5f;
			array [num, 13] = 3f;
			array2 [num, 13] = 0.08f;
			array3 [num, 13] = 0.7f;
			array4 [num, 13] = 0.055f;
			array5 [num, 13] = 2.25f;
			array6 [num, 13] = 0.65f;
			array7 [num, 13] = 0.55f;
			array8 [num, 13] = 7f;
			array [num, 14] = 8f;
			array2 [num, 14] = 0.1f;
			array3 [num, 14] = 0.17f;
			array4 [num, 14] = 0.004f;
			array5 [num, 14] = 1.75f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.75f;
			array8 [num, 14] = 7f;
			array [num, 15] = 6f;
			array2 [num, 15] = 0.16f;
			array3 [num, 15] = 0.15f;
			array4 [num, 15] = 0.05f;
			array5 [num, 15] = 1.65f;
			array6 [num, 15] = 0.9f;
			array7 [num, 15] = 0.8f;
			array8 [num, 15] = 5f;
			array [num, 16] = 17f;
			array2 [num, 16] = 0.1f;
			array3 [num, 16] = 0.1f;
			array4 [num, 16] = 0.046f;
			array5 [num, 16] = 1.65f;
			array6 [num, 16] = 0.9f;
			array7 [num, 16] = 0.8f;
			array8 [num, 16] = 5f;
		} else {
			array [num, 1] = 4f;
			array2 [num, 1] = 0.04f;
			array3 [num, 1] = 0.25f;
			array4 [num, 1] = 0.025f;
			array5 [num, 1] = 1.7f;
			array6 [num, 1] = 0.9f;
			array7 [num, 1] = 0.8f;
			array8 [num, 1] = 20f;
			array [num, 2] = 8f;
			array2 [num, 2] = 0.1f;
			array3 [num, 2] = 0.17f;
			array4 [num, 2] = 0.004f;
			array5 [num, 2] = 1.75f;
			array6 [num, 2] = 0.85f;
			array7 [num, 2] = 0.75f;
			array8 [num, 2] = 10f;
			array [num, 3] = 9f;
			array2 [num, 3] = 0.12f;
			array3 [num, 3] = 0.14f;
			array4 [num, 3] = 0.04f;
			array5 [num, 3] = 1.8f;
			array6 [num, 3] = 0.85f;
			array7 [num, 3] = 0.7f;
			array8 [num, 3] = 10f;
			array [num, 4] = 10f;
			array2 [num, 4] = 0.11f;
			array3 [num, 4] = 0.21f;
			array4 [num, 4] = 0.02f;
			array5 [num, 4] = 1.75f;
			array6 [num, 4] = 0.85f;
			array7 [num, 4] = 0.75f;
			array8 [num, 4] = 10f;
			array [num, 5] = 4f;
			array2 [num, 5] = 0.04f;
			array3 [num, 5] = 0.25f;
			array4 [num, 5] = 0.025f;
			array5 [num, 5] = 1.7f;
			array6 [num, 5] = 0.9f;
			array7 [num, 5] = 0.8f;
			array8 [num, 5] = 20f;
			array [num, 6] = 8f;
			array2 [num, 6] = 0.1f;
			array3 [num, 6] = 0.17f;
			array4 [num, 6] = 0.004f;
			array5 [num, 6] = 1.75f;
			array6 [num, 6] = 0.85f;
			array7 [num, 6] = 0.75f;
			array8 [num, 6] = 10f;
			array [num, 7] = 9f;
			array2 [num, 7] = 0.12f;
			array3 [num, 7] = 0.14f;
			array4 [num, 7] = 0.04f;
			array5 [num, 7] = 1.8f;
			array6 [num, 7] = 0.85f;
			array7 [num, 7] = 0.7f;
			array8 [num, 7] = 10f;
			array [num, 8] = 10f;
			array2 [num, 8] = 0.11f;
			array3 [num, 8] = 0.21f;
			array4 [num, 8] = 0.02f;
			array5 [num, 8] = 1.75f;
			array6 [num, 8] = 0.85f;
			array7 [num, 8] = 0.75f;
			array8 [num, 8] = 10f;
			array [num, 9] = 3f;
			array2 [num, 9] = 0.04f;
			array3 [num, 9] = 0.29f;
			array4 [num, 9] = 0.028f;
			array5 [num, 9] = 2.45f;
			array6 [num, 9] = 0.6f;
			array7 [num, 9] = 0.5f;
			array8 [num, 9] = 20f;
			array [num, 10] = 8f;
			array2 [num, 10] = 0.1f;
			array3 [num, 10] = 0.17f;
			array4 [num, 10] = 0.004f;
			array5 [num, 10] = 1.75f;
			array6 [num, 10] = 0.85f;
			array7 [num, 10] = 0.75f;
			array8 [num, 10] = 20f;
			array [num, 11] = 6f;
			array2 [num, 11] = 0.16f;
			array3 [num, 11] = 0.15f;
			array4 [num, 11] = 0.05f;
			array5 [num, 11] = 1.65f;
			array6 [num, 11] = 0.9f;
			array7 [num, 11] = 0.8f;
			array8 [num, 11] = 5f;
			array [num, 12] = 17f;
			array2 [num, 12] = 0.1f;
			array3 [num, 12] = 0.1f;
			array4 [num, 12] = 0.046f;
			array5 [num, 12] = 1.65f;
			array6 [num, 12] = 0.9f;
			array7 [num, 12] = 0.8f;
			array8 [num, 12] = 5f;
			array [num, 13] = 3f;
			array2 [num, 13] = 0.04f;
			array3 [num, 13] = 0.29f;
			array4 [num, 13] = 0.028f;
			array5 [num, 13] = 2.45f;
			array6 [num, 13] = 0.6f;
			array7 [num, 13] = 0.5f;
			array8 [num, 13] = 20f;
			array [num, 14] = 8f;
			array2 [num, 14] = 0.1f;
			array3 [num, 14] = 0.17f;
			array4 [num, 14] = 0.004f;
			array5 [num, 14] = 1.75f;
			array6 [num, 14] = 0.85f;
			array7 [num, 14] = 0.75f;
			array8 [num, 14] = 20f;
			array [num, 15] = 6f;
			array2 [num, 15] = 0.16f;
			array3 [num, 15] = 0.15f;
			array4 [num, 15] = 0.05f;
			array5 [num, 15] = 1.65f;
			array6 [num, 15] = 0.9f;
			array7 [num, 15] = 0.8f;
			array8 [num, 15] = 5f;
			array [num, 16] = 17f;
			array2 [num, 16] = 0.1f;
			array3 [num, 16] = 0.1f;
			array4 [num, 16] = 0.046f;
			array5 [num, 16] = 1.65f;
			array6 [num, 16] = 0.9f;
			array7 [num, 16] = 0.8f;
			array8 [num, 16] = 5f;
			if (CFS.SpecYear ((short)Param.Spec) >= 2012 || flag) {
				array8 [num, 2] = 20f;
				array8 [num, 6] = 20f;
			}
		}
		if (flag) {
			array5 [num, 1] = 1.75f;
			array6 [num, 1] = 0.85f;
			array5 [num, 2] = 1.9f;
			array6 [num, 2] = 0.8f;
			array5 [num, 3] = 1.9f;
			array6 [num, 3] = 0.8f;
			array5 [num, 4] = 1.9f;
			array6 [num, 4] = 0.8f;
			array5 [num, 5] = 1.75f;
			array6 [num, 5] = 0.85f;
			array5 [num, 6] = 1.9f;
			array6 [num, 6] = 0.8f;
			array5 [num, 7] = 1.9f;
			array6 [num, 7] = 0.8f;
			array5 [num, 8] = 1.9f;
			array6 [num, 8] = 0.8f;
			array5 [num, 9] = 2.7f;
			array6 [num, 9] = 0.55f;
			array5 [num, 10] = 1.9f;
			array6 [num, 10] = 0.8f;
			array5 [num, 11] = 1.75f;
			array6 [num, 11] = 0.85f;
			array5 [num, 12] = 1.75f;
			array6 [num, 12] = 0.85f;
			array5 [num, 13] = 2.7f;
			array6 [num, 13] = 0.55f;
			array5 [num, 14] = 1.9f;
			array6 [num, 14] = 0.8f;
			array5 [num, 15] = 1.75f;
			array6 [num, 15] = 0.85f;
			array5 [num, 16] = 1.75f;
			array6 [num, 16] = 0.85f;
		}
		num = 9;
		array [num, 1] = 2f;
		array2 [num, 1] = 0.32f;
		array3 [num, 1] = 1.6f;
		array4 [num, 1] = 0.04f;
		array5 [num, 1] = 1.6f;
		array6 [num, 1] = 0.95f;
		array7 [num, 1] = 0.9f;
		array8 [num, 1] = 2f;
		array [num, 2] = 1f;
		array2 [num, 2] = 0.04f;
		array3 [num, 2] = 2.3f;
		array4 [num, 2] = 0.001f;
		array5 [num, 2] = 1.6f;
		array6 [num, 2] = 0.95f;
		array7 [num, 2] = 0.9f;
		array8 [num, 2] = 2f;
		array [num, 3] = 1f;
		array2 [num, 3] = 0.35f;
		array3 [num, 3] = 2.6f;
		array4 [num, 3] = 0.05f;
		array5 [num, 3] = 1.6f;
		array6 [num, 3] = 0.95f;
		array7 [num, 3] = 0.9f;
		array8 [num, 3] = 2f;
		array [num, 4] = 4f;
		array2 [num, 4] = 0.21f;
		array3 [num, 4] = 0.75f;
		array4 [num, 4] = 0.01f;
		array5 [num, 4] = 1.67f;
		array6 [num, 4] = 0.9f;
		array7 [num, 4] = 0.8f;
		array8 [num, 4] = 2f;
		array [num, 5] = 2f;
		array2 [num, 5] = 0.32f;
		array3 [num, 5] = 1.6f;
		array4 [num, 5] = 0.04f;
		array5 [num, 5] = 1.6f;
		array6 [num, 5] = 0.95f;
		array7 [num, 5] = 0.9f;
		array8 [num, 5] = 2f;
		array [num, 6] = 1f;
		array2 [num, 6] = 0.04f;
		array3 [num, 6] = 2.3f;
		array4 [num, 6] = 0.001f;
		array5 [num, 6] = 1.6f;
		array6 [num, 6] = 0.95f;
		array7 [num, 6] = 0.9f;
		array8 [num, 6] = 2f;
		array [num, 7] = 1f;
		array2 [num, 7] = 0.35f;
		array3 [num, 7] = 2.6f;
		array4 [num, 7] = 0.05f;
		array5 [num, 7] = 1.6f;
		array6 [num, 7] = 0.95f;
		array7 [num, 7] = 0.9f;
		array8 [num, 7] = 2f;
		array [num, 8] = 4f;
		array2 [num, 8] = 0.21f;
		array3 [num, 8] = 0.75f;
		array4 [num, 8] = 0.01f;
		array5 [num, 8] = 1.67f;
		array6 [num, 8] = 0.9f;
		array7 [num, 8] = 0.8f;
		array8 [num, 8] = 2f;
		array [num, 9] = 2f;
		array2 [num, 9] = 0.32f;
		array3 [num, 9] = 1.6f;
		array4 [num, 9] = 0.04f;
		array5 [num, 9] = 1.6f;
		array6 [num, 9] = 0.95f;
		array7 [num, 9] = 0.9f;
		array8 [num, 9] = 2f;
		array [num, 10] = 1f;
		array2 [num, 10] = 0.04f;
		array3 [num, 10] = 2.3f;
		array4 [num, 10] = 0.001f;
		array5 [num, 10] = 1.6f;
		array6 [num, 10] = 0.95f;
		array7 [num, 10] = 0.9f;
		array8 [num, 10] = 2f;
		array [num, 11] = 1f;
		array2 [num, 11] = 0.35f;
		array3 [num, 11] = 2.6f;
		array4 [num, 11] = 0.05f;
		array5 [num, 11] = 1.6f;
		array6 [num, 11] = 0.95f;
		array7 [num, 11] = 0.9f;
		array8 [num, 11] = 2f;
		array [num, 12] = 4f;
		array2 [num, 12] = 0.21f;
		array3 [num, 12] = 0.75f;
		array4 [num, 12] = 0.01f;
		array5 [num, 12] = 1.67f;
		array6 [num, 12] = 0.9f;
		array7 [num, 12] = 0.8f;
		array8 [num, 12] = 2f;
		array [num, 13] = 2f;
		array2 [num, 13] = 0.32f;
		array3 [num, 13] = 1.6f;
		array4 [num, 13] = 0.04f;
		array5 [num, 13] = 1.6f;
		array6 [num, 13] = 0.95f;
		array7 [num, 13] = 0.9f;
		array8 [num, 13] = 2f;
		array [num, 14] = 1f;
		array2 [num, 14] = 0.04f;
		array3 [num, 14] = 2.3f;
		array4 [num, 14] = 0.001f;
		array5 [num, 14] = 1.6f;
		array6 [num, 14] = 0.95f;
		array7 [num, 14] = 0.9f;
		array8 [num, 14] = 2f;
		array [num, 15] = 1f;
		array2 [num, 15] = 0.35f;
		array3 [num, 15] = 2.6f;
		array4 [num, 15] = 0.05f;
		array5 [num, 15] = 1.6f;
		array6 [num, 15] = 0.95f;
		array7 [num, 15] = 0.9f;
		array8 [num, 15] = 2f;
		array [num, 16] = 4f;
		array2 [num, 16] = 0.21f;
		array3 [num, 16] = 0.75f;
		array4 [num, 16] = 0.01f;
		array5 [num, 16] = 1.67f;
		array6 [num, 16] = 0.9f;
		array7 [num, 16] = 0.8f;
		array8 [num, 16] = 2f;
		CFS.strTrace = string.Empty;
		Check.Msg = Strength.Msg;
		float num3 = DesignFy (StressDirections.dirTC, Param.Spec);
		float n = Param.N;
		if (num3 != Material.Fy [2]) {
			CFS.strTrace = CFS.strTrace + "  Fy=" + Units.DisplayStress (num3, 0, blnShowUnit: true, "", 0, 0) + " in transverse compression\r\n";
		}
		float num4 = 2f;
		float num5 = 0.8f;
		if (CFS.IsSpecLSD ((short)Param.Spec) && !flag) {
			num5 = 0.75f;
		}
		float num6 = 1f;
		float num7 = 1f;
		Check.SPn = 0f;
		Check.SPa = 0f;
		Check.SQPn = 0f;
		Check.nEq = 0;
		short num8 = nPart;
		bool expression = default(bool);
		bool flag5 = default(bool);
		bool flag4 = default(bool);
		bool flag3 = default(bool);
		string text8;
		float num43;
		checked {
			float num11 = default(float);
			float num13 = default(float);
			float num14 = default(float);
			float num15 = default(float);
			float num16 = default(float);
			for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
				float thickness = Part [num9].Thickness;
				short nElem = Part [num9].nElem;
				for (short num10 = 1; num10 <= nElem; num10 = (short)unchecked(num10 + 1)) {
					num = Part [num9].Element [num10].Web;
					if (unchecked((flag & Part [num9].Closed & (Part [num9].nElem == 4)) && num == 2)) {
						num = 9;
					}
					if (num != 1) {
						if (Param.Dir == LoadDirections.dirY) {
							num11 = (float)System.Math.Abs (System.Math.Sin (Part [num9].Element [num10].Ang));
						}
						if (Param.Dir == LoadDirections.dirX) {
							num11 = (float)System.Math.Abs (System.Math.Cos (Part [num9].Element [num10].Ang));
						}
						if ((double)num11 >= 0.7071) {
							Part part = Part [num9];
							short num12 = (short)(num10 - 1);
							if ((Param.Dir == LoadDirections.dirY) & (System.Math.Sign (part.Element [num10].Y0 - part.Element [num10].Y1) == System.Math.Sign (Param.P))) {
								num12 = (short)(num10 + 1);
							}
							if ((Param.Dir == LoadDirections.dirX) & (System.Math.Sign (part.Element [num10].X0 - part.Element [num10].X1) == System.Math.Sign (Param.P))) {
								num12 = (short)(num10 + 1);
							}
							if ((num12 == 0) & part.Closed) {
								num12 = part.nElem;
							}
							if ((num12 > part.nElem) & part.Closed) {
								num12 = 1;
							}
							float wid = part.Element [num10].Wid;
							if (num12 < 1) {
								num13 = 0f;
								num14 = (float)System.Math.PI / 2f;
								num15 = part.Element [num10].X0;
								num16 = part.Element [num10].Y0;
							} else if (num12 > part.nElem) {
								num13 = 0f;
								num14 = (float)System.Math.PI / 2f;
								num15 = part.Element [num10].X1;
								num16 = part.Element [num10].Y1;
							} else if (num12 < num10) {
								num13 = part.Element [num10].Rad;
								num14 = System.Math.Abs (part.Element [num10].Arc);
								num15 = part.Element [num12].X1;
								num16 = part.Element [num12].Y1;
							} else if (num12 > num10) {
								num13 = part.Element [num12].Rad;
								num14 = System.Math.Abs (part.Element [num12].Arc);
								num15 = part.Element [num12].X0;
								num16 = part.Element [num12].Y0;
							}
							if ((num12 >= 1) & (num12 <= part.nElem)) {
								if (Param.Dir == LoadDirections.dirY) {
									num11 = (float)System.Math.Abs (System.Math.Cos (part.Element [num12].Ang));
								}
								if (Param.Dir == LoadDirections.dirX) {
									num11 = (float)System.Math.Abs (System.Math.Sin (part.Element [num12].Ang));
								}
							}
							num15 = part.XPosition - part.Xcg + num15;
							num16 = part.YPosition - part.Ycg + num16;
							part = null;
							short num17 = nPart;
							short num18;
							for (num18 = 1; num18 <= num17; num18 = (short)unchecked(num18 + 1)) {
								Part part2 = Part [num18];
								float num19 = part2.XPosition - part2.Xcg + part2.Element [part2.nElem].X1;
								float num20 = part2.YPosition - part2.Ycg + part2.Element [part2.nElem].Y1;
								short nElem2 = part2.nElem;
								short num21;
								for (num21 = 1; num21 <= nElem2; num21 = (short)unchecked(num21 + 1)) {
									float num22 = num19;
									float num23 = num20;
									num19 = part2.XPosition - part2.Xcg + part2.Element [num21].X0;
									num20 = part2.YPosition - part2.Ycg + part2.Element [num21].Y0;
									if ((num21 > 1) | part2.Closed) {
										if ((Param.Dir == LoadDirections.dirY) & (System.Math.Sign (num15 - num22) != System.Math.Sign (num15 - num19))) {
											float num24 = num23 + (num20 - num23) * (num15 - num22) / (num19 - num22);
											if ((float)System.Math.Sign (Param.P) * (num16 - num24) > 2f * thickness) {
												break;
											}
										} else if ((Param.Dir == LoadDirections.dirX) & (System.Math.Sign (num16 - num23) != System.Math.Sign (num16 - num20))) {
											float num25 = num22 + (num19 - num22) * (num16 - num23) / (num20 - num23);
											if ((float)System.Math.Sign (Param.P) * (num15 - num25) > 2f * thickness) {
												break;
											}
										}
									}
									num22 = num19;
									num23 = num20;
									num19 = part2.XPosition - part2.Xcg + part2.Element [num21].X1;
									num20 = part2.YPosition - part2.Ycg + part2.Element [num21].Y1;
									if ((Param.Dir == LoadDirections.dirY) & (System.Math.Sign (num15 - num22) != System.Math.Sign (num15 - num19))) {
										float num24 = num23 + (num20 - num23) * (num15 - num22) / (num19 - num22);
										if ((float)System.Math.Sign (Param.P) * (num16 - num24) > 2f * thickness) {
											break;
										}
									} else if ((Param.Dir == LoadDirections.dirX) & (System.Math.Sign (num16 - num23) != System.Math.Sign (num16 - num20))) {
										float num25 = num22 + (num19 - num22) * (num16 - num23) / (num20 - num23);
										if ((float)System.Math.Sign (Param.P) * (num15 - num25) > 2f * thickness) {
											break;
										}
									}
								}
								part2 = null;
								if (num21 <= Part [num18].nElem) {
									break;
								}
							}
							if ((num18 > nPart) & ((double)num11 >= System.Math.Sin (System.Math.PI / 4.0))) {
								Check.nEq++;
								if (Check.nEq > Information.UBound (Check.PeText)) {
									ref string[] peText = ref Check.PeText;
									peText = (string[])Utils.CopyArray (peText, new string[Check.nEq + 1]);
									ref float[] pne = ref Check.Pne;
									pne = (float[])Utils.CopyArray (pne, new float[Check.nEq + 1]);
									ref float[] pn = ref Check.Pn;
									pn = (float[])Utils.CopyArray (pn, new float[Check.nEq + 1]);
									ref float[] pae = ref Check.Pae;
									pae = (float[])Utils.CopyArray (pae, new float[Check.nEq + 1]);
									ref float[] pa = ref Check.Pa;
									pa = (float[])Utils.CopyArray (pa, new float[Check.nEq + 1]);
									ref float[] qPne = ref Check.QPne;
									qPne = (float[])Utils.CopyArray (qPne, new float[Check.nEq + 1]);
									ref float[] qPn = ref Check.QPn;
									qPn = (float[])Utils.CopyArray (qPn, new float[Check.nEq + 1]);
								}
								num2 = 1;
								if (!Param.Fastened) {
									num2 = (short)(num2 + 8);
								}
								if (((num12 == 1) | (num12 == Part [num9].nElem)) & !Part [num9].Closed) {
									num2 = (short)(num2 + 4);
								}
								if (unchecked(CFS.IsSpec2001 ((short)Param.Spec) && !flag)) {
									if ((double)Param.Zload <= 1.5 * (double)wid) {
										num2 = (short)(num2 + 2);
									}
								} else if ((double)Param.Zload < 1.5 * (double)wid) {
									num2 = (short)(num2 + 2);
								}
								if (unchecked(num == 2 || num == 5 || num == 6 || num == 4)) {
									if (unchecked(num2 == 3 || num2 == 7)) {
										if ((double)Param.Zend >= 2.5 * (double)wid) {
											num2 = (short)(num2 + 1);
										}
									} else if (unchecked(num2 == 11 || num2 == 15)) {
										if ((double)Param.Zend >= 1.5 * (double)wid) {
											num2 = (short)(num2 + 1);
										}
									} else if ((double)Param.Zend >= 1.5 * (double)wid) {
										num2 = (short)(num2 + 1);
									}
								} else if ((double)Param.Zend >= 1.5 * (double)wid) {
									num2 = (short)(num2 + 1);
								}
								float num26 = (float)(1.0 - (double)array2 [num, num2] * System.Math.Sqrt (num13 / thickness));
								if (num26 < 0f) {
									num26 = 0f;
								}
								float num27 = (float)(1.0 + (double)array3 [num, num2] * System.Math.Sqrt (n / thickness));
								if (num27 < 0f) {
									num27 = 0f;
								}
								float num28 = (float)(1.0 - (double)array4 [num, num2] * System.Math.Sqrt (wid / thickness));
								if (num28 < 0f) {
									num28 = 0f;
								}
								float num29 = (float)((double)(array [num, num2] * thickness * thickness * num3) * System.Math.Sin (num14) * (double)num26 * (double)num27 * (double)num28);
								float num30 = array5 [num, num2];
								float num31 = array6 [num, num2];
								unchecked {
									if (CFS.IsSpecLSD ((short)Param.Spec) && !flag) {
										num31 = array7 [num, num2];
									}
									string text4 = CFSInterface.DisplayWeb ((WebTypes)checked((byte)num)) + ", " + array9 [num2];
									string text5 = text;
									string text6 = "  " + Part [num9].Name + " element " + Conversions.ToString ((int)num10) + "\r\n";
									text6 = text6 + "    t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", C=" + Units.DisplayNone (array [num, num2], "", 0, 0) + ", θ=" + Units.DisplayAngle (num14, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
									text6 = text6 + "    R=" + Units.DisplayLen1 (num13, 0, blnShowUnit: true, "", 0, 0) + ", Cr=" + Units.DisplayNone (array2 [num, num2], "", 0, 0) + "\r\n";
									text6 = text6 + "    N=" + Units.DisplayLen1 (n, 0, blnShowUnit: true, "", 0, 0) + ", Cn=" + Units.DisplayNone (array3 [num, num2], "", 0, 0) + "\r\n";
									text6 = text6 + "    h=" + Units.DisplayLen1 (wid, 0, blnShowUnit: true, "", 0, 0) + ", Ch=" + Units.DisplayNone (array4 [num, num2], "", 0, 0) + "\r\n";
									text6 = text6 + "    Pn=" + Units.DisplayForce (num29, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
									bool flag2 = false;
									string sDest = string.Empty;
									if (num == 9) {
										if (wid / thickness > 60f) {
											sDest += ",h/t>60";
										}
									} else if (wid / thickness > 200f) {
										sDest += ",h/t>200";
									}
									switch (num) {
									case 7:
										if (n / thickness > 200f) {
											sDest += ",N/t>200";
										}
										break;
									case 9:
										if (n / thickness > 55f) {
											sDest += ",N/t>55";
										}
										break;
									default:
										if (n / thickness > 210f) {
											sDest += ",N/t>210";
										}
										break;
									}
									switch (num) {
									case 3:
										if (n / wid > 1f) {
											sDest += ",N/h>1";
										}
										break;
									case 8:
									case 9:
										if (n / wid > 3f) {
											sDest += ",N/h>3";
										}
										break;
									default:
										if (n / wid > 2f) {
											sDest += ",N/h>2";
										}
										break;
									}
									if (num == 8) {
										if ((double)num14 < 0.78439816339744828) {
											sDest += ",θ<45°";
										}
									} else if ((double)num14 < 1.5697963267948967) {
										sDest += ",θ<90°";
									}
									if ((double)num14 > 1.5717963267948964) {
										sDest += ",θ>90°";
									}
									if (num13 / thickness > array8 [num, num2]) {
										sDest = sDest + ",R/t>" + Conversions.ToString (array8 [num, num2]);
									}
									if (Strings.Len (sDest) > 0) {
										StringType.MidStmtStr (ref sDest, 1, int.MaxValue, ";");
										if (num30 < num4) {
											num30 = num4;
										}
										if (num31 > num5) {
											num31 = num5;
										}
										flag2 = true;
									}
									text6 = Conversions.ToString (Operators.ConcatenateObject (text6, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωw=" + Conversions.ToString (num30) + ", φw=" + Conversions.ToString (num31), Interaction.IIf (num30 == num4 && num31 == num5, " (rational analysis)", "")), "\r\n")));
									if ((CFS.IsSpec1999 ((short)Param.Spec) && !flag) | (array [num, num2] == 0f)) {
										if (num2 % 2 == 0) {
											num2 = checked((short)(num2 - 1));
										}
										if ((double)Param.Zend >= 1.5 * (double)wid) {
											num2 = checked((short)(num2 + 1));
										}
										short num32 = (short)(((double)Param.Zload > 1.5 * (double)wid) ? (((double)Param.Zend < 1.5 * (double)wid) ? ((num != 3) ? 2 : 3) : ((num != 3) ? 4 : 5)) : (((double)Param.Zend < 1.5 * (double)wid) ? ((num != 3) ? 6 : 7) : ((num != 3) ? 8 : 9)));
										if ((num32 == 2) & (Part [num9].Closed | ((num12 > 1) & (num12 < Part [num9].nElem)))) {
											num32 = 1;
										}
										float num33 = num3 / 33f;
										float num34 = (float)((double)thickness / 0.075);
										num26 = (float)(1.22 - 0.22 * (double)num33);
										if ((double)(num26 * num33) > 1.69) {
											num26 = (float)(1.69 / (double)num33);
										}
										num27 = (float)(1.06 - 0.06 * (double)num13 / (double)thickness);
										if (num27 > 1f) {
											num27 = 1f;
										}
										num28 = (float)(1.33 - 0.33 * (double)num33);
										if ((double)(num28 * num33) > 1.34) {
											num28 = (float)(1.34 / (double)num33);
										}
										if (!flag) {
											num28 = num26;
										}
										float num35 = (float)(1.15 - 0.15 * (double)num13 / (double)thickness);
										if ((double)num35 < 0.5) {
											num35 = 0.5f;
										}
										if (num35 > 1f) {
											num35 = 1f;
										}
										float num36 = (float)(1.49 - 0.53 * (double)num33);
										if ((double)num36 < 0.6) {
											num36 = 0.6f;
										}
										float num37 = 1f + wid / thickness / 750f;
										if ((double)num37 > 1.2) {
											num37 = 1.2f;
										}
										float num38 = (float)((1.1 - (double)(wid / thickness / 665f)) / (double)num33);
										if (num38 > 1f / num33) {
											num38 = 1f / num33;
										}
										float num39 = (float)((0.98 - (double)(wid / thickness / 865f)) / (double)num33);
										float num40 = (float)(0.7 + 0.3 * System.Math.Pow ((double)(num14 * 2f) / System.Math.PI, 2.0));
										if (num40 > 1f) {
											num40 = 1f;
										}
										switch (num32) {
										case 1:
											num29 = (float)((double)(thickness * thickness * num3 * num28 * num35 * num40) * (331.0 - 0.61 * (double)wid / (double)thickness) / 33.0 * (1.0 + 0.01 * (double)n / (double)thickness));
											if (((num == 6 || num == 4) & Param.Fastened & (wid / thickness <= 150f) & (num13 / thickness <= 4f)) && (double)thickness >= 0.06) {
												num29 = (float)((double)num29 * 1.3);
											}
											break;
										case 2:
											num29 = (float)((double)(thickness * thickness * num3 * num28 * num35 * num40) * (217.0 - 0.28 * (double)wid / (double)thickness) / 33.0);
											num29 = ((!(n / thickness > 60f)) ? ((float)((double)num29 * (1.0 + 0.01 * (double)n / (double)thickness))) : ((float)((double)num29 * (0.71 + 0.015 * (double)n / (double)thickness))));
											break;
										case 3:
											num29 = (float)((double)(thickness * thickness * num3 * num37) * (10.0 + 1.25 * System.Math.Sqrt (n / thickness)));
											break;
										case 4:
											num29 = (float)((double)(thickness * thickness * num3 * num26 * num27 * num40) * (538.0 - 0.74 * (double)wid / (double)thickness) / 33.0);
											num29 = ((!(n / thickness > 60f)) ? ((float)((double)num29 * (1.0 + 0.007 * (double)n / (double)thickness))) : ((float)((double)num29 * (0.75 + 0.011 * (double)n / (double)thickness))));
											break;
										case 5:
											num29 = (float)((double)(thickness * thickness * num3 * num36) * (0.88 + 0.12 * (double)num34) * (15.0 + 3.25 * System.Math.Sqrt (n / thickness)));
											break;
										case 6:
											num29 = (float)((double)(thickness * thickness * num3 * num28 * num35 * num40) * (244.0 - 0.57 * (double)wid / (double)thickness) / 33.0 * (1.0 + 0.01 * (double)n / (double)thickness));
											break;
										case 7:
											num29 = (float)((double)(thickness * thickness * num3 * num39) * (0.64 + 0.31 * (double)num34) * (10.0 + 1.25 * System.Math.Sqrt (n / thickness)));
											break;
										case 8:
											num29 = (float)((double)(thickness * thickness * num3 * num26 * num27 * num40) * (771.0 - 2.26 * (double)wid / (double)thickness) / 33.0 * (1.0 + 0.0013 * (double)n / (double)thickness));
											break;
										case 9:
											num29 = (float)((double)(thickness * thickness * num3 * num38) * (0.82 + 0.15 * (double)num34) * (15.0 + 3.25 * System.Math.Sqrt (n / thickness)));
											break;
										}
										if (flag) {
											text5 = "ASCE 8-02 Eq. 3.3.4-" + Conversions.ToString ((int)num32);
											if (num == 3) {
												num30 = 2.2f;
												num31 = 0.7f;
											} else {
												num30 = 2f;
												num31 = 0.7f;
											}
										} else {
											text5 = "1999 AISI C3.4-" + Conversions.ToString ((int)num32);
											if (num == 3) {
												num30 = 2f;
												num31 = 0.8f;
											} else if (num == 4 && num32 == 4) {
												num30 = 1.8f;
												num31 = 0.85f;
											} else {
												num30 = 1.85f;
												num31 = 0.75f;
											}
											if (CFS.IsSpecLSD ((short)Param.Spec)) {
												num31 = (float)((double)num31 - 0.1);
											}
										}
										text4 = text5;
										text6 = "  " + Part [num9].Name + " element " + Conversions.ToString ((int)num10) + "\r\n";
										text6 = text6 + "    t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", m=" + Units.DisplayNone (num34, "", 0, 0) + "\r\n";
										text6 = text6 + "    k=" + Units.DisplayNone (num33, "", 0, 0) + ", C1=" + Units.DisplayNone (num26, "", 0, 0) + ", C3=" + Units.DisplayNone (num28, "", 0, 0) + ", C5=" + Units.DisplayNone (num36, "", 0, 0) + "\r\n";
										text6 = text6 + "    R=" + Units.DisplayLen1 (num13, 0, blnShowUnit: true, "", 0, 0) + ", C2=" + Units.DisplayNone (num27, "", 0, 0) + ", C4=" + Units.DisplayNone (num35, "", 0, 0) + "\r\n";
										text6 = text6 + "    h=" + Units.DisplayLen1 (wid, 0, blnShowUnit: true, "", 0, 0) + ", C6=" + Units.DisplayNone (num37, "", 0, 0) + ", C7=" + Units.DisplayNone (num38, "", 0, 0) + ", C8=" + Units.DisplayNone (num39, "", 0, 0) + "\r\n";
										text6 = text6 + "    θ=" + Units.DisplayAngle (num14, 0, blnShowUnit: true, "", 0, 0) + ", Cθ=" + Units.DisplayNone (num40, "", 0, 0) + "\r\n";
										text6 = text6 + "    Pn=" + Units.DisplayForce (num29, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
										flag2 = false;
										sDest = string.Empty;
										if (wid / thickness > 200f) {
											sDest += ",h/t>200";
										}
										if (n / thickness > 210f) {
											sDest += ",N/t>210";
										}
										if ((double)(n / wid) > 3.5) {
											sDest += ",N/h>3.5";
										}
										if ((double)num14 < 0.78439816339744828) {
											sDest += ",θ<45°";
										}
										if ((double)num14 > 1.5717963267948964) {
											sDest += ",θ>90°";
										}
										if (num == 8) {
											if (num13 / thickness > 7f) {
												sDest += ",R/t>7";
											}
										} else if (num13 / thickness > 6f) {
											sDest += ",R/t>6";
										}
										if (Strings.Len (sDest) > 0) {
											StringType.MidStmtStr (ref sDest, 1, int.MaxValue, ";");
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										text6 = Conversions.ToString (Operators.ConcatenateObject (text6, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωw=" + Conversions.ToString (num30) + ", φw=" + Conversions.ToString (num31), Interaction.IIf (num30 == num4 && num31 == num5, " (rational analysis)", "")), "\r\n")));
									}
									float hole = Part [num9].Element [num10].Hole;
									if ((double)hole > 0.5625) {
										float num41;
										string text7;
										if (num2 % 2 == 1) {
											num41 = (float)(1.01 - 0.325 * (double)hole / (double)wid);
											text7 = text2;
											if (n < 1f) {
												sDest += ",N<1";
											}
										} else {
											num41 = (float)(0.9 - 0.047 * (double)hole / (double)wid);
											text7 = text3;
											if (n < 3f) {
												sDest += ",N<3";
											}
										}
										if (Strings.Len (sDest) > 0) {
											StringType.MidStmtStr (ref sDest, 1, int.MaxValue, ";");
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if (num41 > 1f) {
											num41 = 1f;
										}
										num29 *= num41;
										text6 += "    Strength reduction for web hole (assume x=0):\r\n";
										if ((double)(hole / wid) > 0.7) {
											text6 += "    dh/h exceeds 0.7 (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if (HoleSpacing - HoleLength < 18f) {
											text6 = text6 + "    Clear distance between holes less than " + Units.DisplayLen1 (18f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											expression = true;
										}
										float num42 = Conversions.ToSingle (Interaction.IIf (hole == HoleLength, 6, 2.5));
										if (hole > num42) {
											text6 = text6 + "    Hole depth greater than " + Units.DisplayLen1 (num42, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if ((hole != HoleLength) & ((double)HoleLength > 4.5)) {
											text6 = text6 + "    Hole length greater than " + Units.DisplayLen1 (4.5f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if (System.Math.Abs ((double)(Part [num9].Element [num10].Dist / Part [num9].Element [num10].Len) - 0.5) > 0.02) {
											text6 += "    Hole not at mid-depth (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if (num != 5) {
											text6 += "    Not a C-section web (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										if ((checked(num2 - 1) & 2) == 2) {
											text6 += "    Two flange loading (rational analysis)\r\n";
											if (num30 < num4) {
												num30 = num4;
											}
											if (num31 > num5) {
												num31 = num5;
											}
											flag2 = true;
										}
										text6 = text6 + "    Rc=" + Units.DisplayNone (num41, "", 0, 0) + "\t" + text7 + "\r\n";
										text6 = text6 + "    Pn=" + Units.DisplayForce (num29, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
										text6 = Conversions.ToString (Operators.ConcatenateObject (text6, Operators.ConcatenateObject (Operators.ConcatenateObject ("    Ωw=" + Conversions.ToString (num30) + ", φw=" + Conversions.ToString (num31), Interaction.IIf (num30 == num4 && num31 == num5, " (rational analysis)", "")), "\r\n")));
									}
									Check.Pne [Check.nEq] = num29;
									Check.Pn [Check.nEq] = num29 / num11;
									Check.Pae [Check.nEq] = num29 / num30;
									Check.Pa [Check.nEq] = Check.Pae [Check.nEq] / num11;
									Check.QPne [Check.nEq] = num31 * num29;
									Check.QPn [Check.nEq] = Check.QPne [Check.nEq] / num11;
									Check.SPn += Check.Pn [Check.nEq];
									Check.SPa += Check.Pa [Check.nEq];
									Check.SQPn += Check.QPn [Check.nEq];
									Check.PeText [Check.nEq] = Conversions.ToString ((int)num9).PadLeft (3) + Conversions.ToString ((int)num10).PadLeft (5) + "  " + text4.PadRight (18) + sDest;
									switch (num) {
									case 3:
										flag5 = true;
										break;
									case 4:
										flag4 = true;
										if (num30 > num6) {
											num6 = num30;
										}
										if (num31 < num7) {
											num7 = num31;
										}
										break;
									default:
										flag3 = true;
										break;
									}
									CFS.strTrace += text6;
									if (flag2) {
										expression = true;
									}
								}
							}
						}
					}
				}
			}
			if (Param.Dir == LoadDirections.dirY) {
				if (Param.M >= 0f) {
					Check.Mn = Strength.Mnxop;
					Check.Ma = Strength.Maxop;
					Check.QMn = Strength.QMnxop;
				} else {
					Check.Mn = Strength.Mnxon;
					Check.Ma = Strength.Maxon;
					Check.QMn = Strength.QMnxon;
				}
			} else if (Param.M >= 0f) {
				Check.Mn = Strength.Mnyop;
				Check.Ma = Strength.Mayop;
				Check.QMn = Strength.QMnyop;
			} else {
				Check.Mn = Strength.Mnyon;
				Check.Ma = Strength.Mayon;
				Check.QMn = Strength.QMnyon;
			}
			if ((double)(Check.Mn / Check.Ma) > 0.999 * (double)num4) {
				expression = true;
			}
			if ((double)(Check.QMn / Check.Mn) < 1.001 * (double)num5) {
				expression = true;
			}
			text8 = "0.000";
			num43 = 9.999f;
			Check.Eq = new float[4];
			Check.EqText = new string[4];
		}
		if (CFS.IsSpecLRFD ((short)Param.Spec) | CFS.IsSpecLSD ((short)Param.Spec)) {
			float num44;
			float num45;
			float num46;
			if (flag) {
				Check.EqText [1] = "Eq. 8-7a     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.33, Interaction.IIf (expression, num5, 0.85)));
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [1] = "Eq. C3.5.2-1 (P, M)  ";
				num44 = ((!(Check.SQPn > 0f)) ? num43 : ((float)(1.07 * (double)System.Math.Abs (Param.P) / (double)Check.SQPn)));
				num45 = System.Math.Abs (Param.M) / Check.QMn;
				num46 = 1.42f;
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [1] = "Eq. C3.5.2-1 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.33, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.33, Interaction.IIf (expression, num5, 0.75)));
				}
			} else {
				Check.EqText [1] = "Eq. H3-1b    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.33, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.33, Interaction.IIf (expression, num5, 0.75)));
				}
			}
			float num47 = num44 + num45;
			Check.Eq [1] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference = ref Check.EqText [1];
			ref string reference2 = ref reference;
			reference = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
			}
			Check.Eq [1] = Check.Eq [1] / num46;
			if (flag) {
				Check.EqText [2] = "Eq. 8-8b     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.46, Interaction.IIf (expression, num5, 0.85)));
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [2] = "Eq. C3.5.2-2 (P, M)  ";
				num44 = ((!(Check.SQPn > 0f)) ? num43 : ((float)(0.82 * (double)System.Math.Abs (Param.P) / (double)Check.SQPn)));
				num45 = System.Math.Abs (Param.M) / Check.QMn;
				num46 = 1.32f;
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [2] = "Eq. C3.5.2-2 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.46, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.46, Interaction.IIf (expression, num5, 0.75)));
				}
			} else {
				Check.EqText [2] = "Eq. H3-2b    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.46, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.46, Interaction.IIf (expression, num5, 0.75)));
				}
			}
			num47 = num44 + num45;
			Check.Eq [2] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference3 = ref Check.EqText [2];
			reference2 = ref reference3;
			reference3 = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
			}
			Check.Eq [2] = Check.Eq [2] / num46;
			if (flag) {
				Check.EqText [3] = "Eq. 8-9b     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.85)));
			} else if (CFS.IsSpec1999 ((short)Param.Spec)) {
				Check.EqText [3] = "Eq. C3.5.2-3 (M, P)  ";
				num44 = System.Math.Abs (Param.M) / Check.Mn;
				num45 = ((!(Check.SPn > 0f)) ? num43 : (System.Math.Abs (Param.P) / Check.SPn));
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.68, Interaction.IIf (expression, num5, 0.9)));
			} else if (CFS.IsSpec2001 ((short)Param.Spec)) {
				Check.EqText [3] = "Eq. C3.5.2-3 (M, P)  ";
				num44 = System.Math.Abs (Param.M) / Check.Mn;
				num45 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.85 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.8)));
				}
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [3] = "Eq. C3.5.2-3 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.8)));
				}
			} else {
				Check.EqText [3] = "Eq. H3-3b    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.9)));
				if (CFS.IsSpecLSD ((short)Param.Spec)) {
					num46 = Conversions.ToSingle (Operators.MultiplyObject (1.65, Interaction.IIf (expression, num5, 0.8)));
				}
			}
			num47 = num44 + num45;
			Check.Eq [3] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference4 = ref Check.EqText [3];
			reference2 = ref reference4;
			reference4 = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [3], Strings.InStr (Check.EqText [3], "<="), int.MaxValue, "> ");
			}
			Check.Eq [3] = Check.Eq [3] / num46;
		} else {
			float num44;
			float num45;
			float num46;
			if (flag) {
				Check.EqText [1] = "Eq. 8-7a     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.33, Interaction.IIf (expression, num4, 1.9)));
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [1] = "Eq. C3.5.1-1 (P, M)  ";
				num44 = ((!(Check.SPa > 0f)) ? num43 : ((float)(1.2 * (double)System.Math.Abs (Param.P) / (double)Check.SPa)));
				num45 = System.Math.Abs (Param.M) / Check.Ma;
				num46 = 1.5f;
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [1] = "Eq. C3.5.1-1 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.33, Interaction.IIf (expression, num4, 1.7)));
			} else {
				Check.EqText [1] = "Eq. H3-1a    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.91 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.33, Interaction.IIf (expression, num4, 1.7)));
			}
			float num47 = num44 + num45;
			Check.Eq [1] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference5 = ref Check.EqText [1];
			ref string reference2 = ref reference5;
			reference5 = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [1], Strings.InStr (Check.EqText [1], "<="), int.MaxValue, "> ");
			}
			Check.Eq [1] = Check.Eq [1] / num46;
			if (flag) {
				Check.EqText [2] = "Eq. 8-8a     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.46, Interaction.IIf (expression, num4, 1.9)));
			} else if (CFS.SpecYear ((short)Param.Spec) <= 2001) {
				Check.EqText [2] = "Eq. C3.5.1-2 (P, M)  ";
				num44 = ((!(Check.SPa > 0f)) ? num43 : ((float)(1.1 * (double)System.Math.Abs (Param.P) / (double)Check.SPa)));
				num45 = System.Math.Abs (Param.M) / Check.Ma;
				num46 = 1.5f;
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [2] = "Eq. C3.5.1-2 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.46, Interaction.IIf (expression, num4, 1.7)));
			} else {
				Check.EqText [2] = "Eq. H3-2a    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.88 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.46, Interaction.IIf (expression, num4, 1.7)));
			}
			num47 = num44 + num45;
			Check.Eq [2] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference6 = ref Check.EqText [2];
			reference2 = ref reference6;
			reference6 = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [2], Strings.InStr (Check.EqText [2], "<="), int.MaxValue, "> ");
			}
			Check.Eq [2] = Check.Eq [2] / num46;
			if (flag) {
				Check.EqText [3] = "Eq. 8-9a     (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.65, Interaction.IIf (expression, num4, 1.9)));
			} else if (CFS.IsSpec1999 ((short)Param.Spec)) {
				Check.EqText [3] = "Eq. C3.5.1-3 (M, P)  ";
				num44 = System.Math.Abs (Param.M) / Check.Mn;
				num45 = ((!(Check.SPn > 0f)) ? num43 : (System.Math.Abs (Param.P) / Check.SPn));
				num46 = Conversions.ToSingle (Operators.DivideObject (1.67, Interaction.IIf (expression, num4, 1.67)));
			} else if (CFS.IsSpec2001 ((short)Param.Spec)) {
				Check.EqText [3] = "Eq. C3.5.1-3 (M, P)  ";
				num44 = System.Math.Abs (Param.M) / Check.Mn;
				num45 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.85 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num46 = Conversions.ToSingle (Operators.DivideObject (1.65, Interaction.IIf (expression, num4, 1.75)));
			} else if (CFS.SpecYear ((short)Param.Spec) < 2016) {
				Check.EqText [3] = "Eq. C3.5.1-3 (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.65, Interaction.IIf (expression, num4, 1.7)));
			} else {
				Check.EqText [3] = "Eq. H3-3a    (P, M)  ";
				num44 = ((!(Check.SPn > 0f)) ? num43 : ((float)(0.86 * (double)System.Math.Abs (Param.P) / (double)Check.SPn)));
				num45 = System.Math.Abs (Param.M) / Check.Mn;
				num46 = Conversions.ToSingle (Operators.DivideObject (1.65, Interaction.IIf (expression, num4, 1.7)));
			}
			num47 = num44 + num45;
			Check.Eq [3] = num47;
			if (num44 > num43) {
				num44 = num43;
			}
			if (num45 > num43) {
				num45 = num43;
			}
			if (num47 > num43) {
				num47 = num43;
			}
			ref string reference7 = ref Check.EqText [3];
			reference2 = ref reference7;
			reference7 = reference2 + num44.ToString (text8) + " + " + num45.ToString (text8) + " = " + num47.ToString (text8) + " <= " + num46.ToString (text8);
			if (System.Math.Round (num47, 3) > System.Math.Round (num46, 3)) {
				StringType.MidStmtStr (ref Check.EqText [3], Strings.InStr (Check.EqText [3], "<="), int.MaxValue, "> ");
			}
			Check.Eq [3] = Check.Eq [3] / num46;
		}
		if (!flag3) {
			Check.EqText [1] = string.Empty;
			Check.Eq [1] = 0f;
		}
		if (!flag5) {
			Check.EqText [2] = string.Empty;
			Check.Eq [2] = 0f;
		}
		if (!flag4) {
			Check.EqText [3] = string.Empty;
			Check.Eq [3] = 0f;
		}
		if ((Check.SPn == 0f) & (Check.Eq [1] == 0f) & (Check.Eq [2] == 0f) & (Check.Eq [3] == 0f)) {
			Check.Eq [1] = num43;
		}
	}

	public void Extents ()
	{
		Xmin = 0f;
		Ymin = 0f;
		Xmax = 0f;
		Ymax = 0f;
		Xmine = 0f;
		Ymine = 0f;
		Xmaxe = 0f;
		Ymaxe = 0f;
		short num = nPart;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				float num3 = Part [num2].XPosition - Part [num2].Xleft;
				if ((num2 == 1) | (num3 < Xmin)) {
					Xmin = num3;
				}
				float num4 = Part [num2].YPosition - Part [num2].Ybottom;
				if ((num2 == 1) | (num4 < Ymin)) {
					Ymin = num4;
				}
				num3 = Part [num2].XPosition + Part [num2].Xright;
				if ((num2 == 1) | (num3 > Xmax)) {
					Xmax = num3;
				}
				num4 = Part [num2].YPosition + Part [num2].Ytop;
				if ((num2 == 1) | (num4 > Ymax)) {
					Ymax = num4;
				}
				num3 = Part [num2].XPosition - Part [num2].Xlefte;
				if ((num2 == 1) | (num3 < Xmine)) {
					Xmine = num3;
				}
				num4 = Part [num2].YPosition - Part [num2].Ybottome;
				if ((num2 == 1) | (num4 < Ymine)) {
					Ymine = num4;
				}
				num3 = Part [num2].XPosition + Part [num2].Xrighte;
				if ((num2 == 1) | (num3 > Xmaxe)) {
					Xmaxe = num3;
				}
				num4 = Part [num2].YPosition + Part [num2].Ytope;
				if ((num2 == 1) | (num4 > Ymaxe)) {
					Ymaxe = num4;
				}
			}
		}
	}

	internal Extremes ExtremeFibers (float AxisAngle, bool blnNet = false)
	{
		float num = (float)System.Math.Sin (AxisAngle);
		float num2 = (float)System.Math.Cos (AxisAngle);
		int num3 = nPart;
		float ang = default(float);
		float num10 = default(float);
		float num11 = default(float);
		for (int i = 1; i <= num3; i = checked(i + 1)) {
			Part part = Part [i];
			float num4;
			float num5;
			if (blnNet) {
				num4 = part.XPosition - part.Xcg - Prop.Xcgn;
				num5 = part.YPosition - part.Ycg - Prop.Ycgn;
			} else {
				num4 = part.XPosition - part.Xcg - Prop.Xcg;
				num5 = part.YPosition - part.Ycg - Prop.Ycg;
			}
			float thickness = part.Thickness;
			if (part.nElem > 0) {
				ang = part.Element [part.nElem].Ang;
			}
			int nElem = part.nElem;
			for (int j = 1; j <= nElem; j = checked(j + 1)) {
				float num7;
				float num8;
				float num9;
				if ((j > 1) | part.Closed) {
					float num6 = part.Element [j].Rad + thickness;
					num7 = num4 + part.Element [j].Xac;
					num8 = num5 + part.Element [j].Yac;
					float A = (float)((double)ang - (double)System.Math.Sign (part.Element [j].Arc) * System.Math.PI / 2.0);
					float B = A + part.Element [j].Arc;
					if (A > B) {
						CFS.Swap (ref A, ref B);
					}
					num9 = (0f - num) * num7 + num2 * num8 + num6;
					ang = (float)((double)AxisAngle - 4.71238898038469);
					if (A < ang && B > ang && num9 > num10) {
						num10 = num9;
					}
					ang = (float)((double)AxisAngle + System.Math.PI / 2.0);
					if (A < ang && B > ang && num9 > num10) {
						num10 = num9;
					}
					ang = (float)((double)AxisAngle + 7.8539816339744828);
					if (A < ang && B > ang && num9 > num10) {
						num10 = num9;
					}
					num9 = (0f - num) * num7 + num2 * num8 - num6;
					ang = (float)((double)AxisAngle - System.Math.PI / 2.0);
					if (A < ang && B > ang && num9 < num11) {
						num11 = num9;
					}
					ang = (float)((double)AxisAngle + 4.71238898038469);
					if (A < ang && B > ang && num9 < num11) {
						num11 = num9;
					}
				}
				ang = part.Element [j].Ang;
				float num12 = (float)((double)(thickness / 2f) * System.Math.Sin (ang));
				float num13 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (ang));
				num7 = num4 + part.Element [j].X0 - num12;
				num8 = num5 + part.Element [j].Y0 - num13;
				num9 = (0f - num) * num7 + num2 * num8;
				num10 = (float)CFS.Max (num10, num9);
				num11 = (float)CFS.Min (num11, num9);
				num7 = num4 + part.Element [j].X0 + num12;
				num8 = num5 + part.Element [j].Y0 + num13;
				num9 = (0f - num) * num7 + num2 * num8;
				num10 = (float)CFS.Max (num10, num9);
				num11 = (float)CFS.Min (num11, num9);
				num7 = num4 + part.Element [j].X1 - num12;
				num8 = num5 + part.Element [j].Y1 - num13;
				num9 = (0f - num) * num7 + num2 * num8;
				num10 = (float)CFS.Max (num10, num9);
				num11 = (float)CFS.Min (num11, num9);
				num7 = num4 + part.Element [j].X1 + num12;
				num8 = num5 + part.Element [j].Y1 + num13;
				num9 = (0f - num) * num7 + num2 * num8;
				num10 = (float)CFS.Max (num10, num9);
				num11 = (float)CFS.Min (num11, num9);
			}
			part = null;
		}
		Extremes result = default(Extremes);
		result.Dmin = num11;
		result.Dmax = num10;
		return result;
	}

	private void NetProp ()
	{
		ref PropertiesType prop = ref Prop;
		float num = prop.A;
		float num2 = prop.A * prop.Xcg;
		float num3 = prop.A * prop.Ycg;
		float num4 = prop.Iy + prop.A * prop.Xcg * prop.Xcg;
		float num5 = prop.Ix + prop.A * prop.Ycg * prop.Ycg;
		float num6 = prop.Ixy + prop.A * prop.Xcg * prop.Ycg;
		short num7 = nPart;
		checked {
			for (short num8 = 1; num8 <= num7; num8 = (short)unchecked(num8 + 1)) {
				Part part = Part [num8];
				float thickness = part.Thickness;
				short nElem = part.nElem;
				for (short num9 = 1; num9 <= nElem; num9 = (short)unchecked(num9 + 1)) {
					float hole = part.Element [num9].Hole;
					if (hole > 0f) {
						float ang = part.Element [num9].Ang;
						float num10 = (float)System.Math.Sin (ang);
						float num11 = (float)System.Math.Cos (ang);
						float num12 = part.XPosition - part.Xcg + (part.Element [num9].Xh0 + part.Element [num9].Xh1) / 2f;
						float num13 = part.YPosition - part.Ycg + (part.Element [num9].Yh0 + part.Element [num9].Yh1) / 2f;
						float num14 = thickness * hole;
						num -= num14;
						num2 -= num14 * num12;
						num3 -= num14 * num13;
						num4 = (float)((double)num4 - ((double)(num14 * num12 * num12) + (double)num14 * (System.Math.Pow (hole * num11, 2.0) + System.Math.Pow (thickness * num10, 2.0)) / 12.0));
						num5 = (float)((double)num5 - ((double)(num14 * num13 * num13) + (double)num14 * (System.Math.Pow (hole * num10, 2.0) + System.Math.Pow (thickness * num11, 2.0)) / 12.0));
						num6 -= num14 * num12 * num13 + num14 * ((hole * hole - thickness * thickness) * num10 * num11) / 12f;
					}
				}
				part = null;
			}
			ref PropertiesType prop2 = ref Prop;
			prop2.An = num;
			prop2.Xcgn = num2 / num;
			prop2.Ycgn = num3 / num;
			prop2.Ixn = num5 - num * prop2.Ycgn * prop2.Ycgn;
			prop2.Iyn = num4 - num * prop2.Xcgn * prop2.Xcgn;
			prop2.Ixyn = num6 - num * prop2.Xcgn * prop2.Ycgn;
			prop2.Icn = prop2.Ixn + prop2.Iyn;
			prop2.Sxtn = prop2.Ixn / (Ymax - prop2.Ycgn);
			prop2.Sxbn = prop2.Ixn / (prop2.Ycgn - Ymin);
			if (prop2.Sxtn < prop2.Sxbn) {
				prop2.Sxn = prop2.Sxtn;
			} else {
				prop2.Sxn = prop2.Sxbn;
			}
			prop2.Syln = prop2.Iyn / (prop2.Xcgn - Xmin);
			prop2.Syrn = prop2.Iyn / (Xmax - prop2.Xcgn);
			if (prop2.Syln < prop2.Syrn) {
				prop2.Syn = prop2.Syln;
			} else {
				prop2.Syn = prop2.Syrn;
			}
			prop2.Rxn = (float)System.Math.Sqrt (prop2.Ixn / prop2.An);
			prop2.Ryn = (float)System.Math.Sqrt (prop2.Iyn / prop2.An);
			prop2.Rcn = (float)System.Math.Sqrt (prop2.Icn / prop2.An);
			prop2.Xon = prop2.Xo + prop2.Xcg - prop2.Xcgn;
			prop2.Yon = prop2.Yo + prop2.Ycg - prop2.Ycgn;
			prop2.Ion = prop2.Icn + prop2.An * (prop2.Xon * prop2.Xon + prop2.Yon * prop2.Yon);
			prop2.Ron = (float)System.Math.Sqrt (prop2.Ion / prop2.An);
		}
	}

	private void PlasticModulus ()
	{
		float[] array = new float[4];
		float num = Prop.Ycg;
		int num2 = 1;
		checked {
			float num16 = default(float);
			float num4;
			do {
				float num3 = 0f;
				num4 = 0f;
				int num5 = nPart;
				for (int i = 1; i <= num5; i++) {
					Part part = Part [i];
					float thickness = part.Thickness;
					int nElem = part.nElem;
					for (int j = 1; j <= nElem; j++) {
						short num6 = Conversions.ToShort (Interaction.IIf (j == 1, part.nElem, j - 1));
						float num12;
						float num11;
						float num7;
						if ((j > 1) | part.Closed) {
							num7 = part.YPosition - part.Ycg + part.Element [j].Yac;
							float num8 = part.Element [j].Rad + thickness / 2f;
							float arc = part.Element [j].Arc;
							array [0] = (float)((double)part.Element [num6].Ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
							array [3] = array [0] + arc;
							array [1] = array [0];
							array [2] = array [0];
							if (System.Math.Abs (num - num7) < num8) {
								array [1] = AngleBetween (array [0], array [3], (float)System.Math.Asin ((num - num7) / num8));
								array [2] = AngleBetween (array [0], array [3], (float)(System.Math.PI - System.Math.Asin ((num - num7) / num8)));
								if (System.Math.Sign (array [2] - array [1]) != System.Math.Sign (array [3] - array [0])) {
									CFS.Swap (ref array [1], ref array [2]);
								}
							}
							int num9 = 0;
							do {
								if (array [num9 + 1] != array [num9]) {
									arc = System.Math.Abs (array [num9 + 1] - array [num9]) / 2f;
									float num10 = (array [num9 + 1] + array [num9]) / 2f;
									num11 = 2f * num8 * arc;
									num12 = (float)((double)num7 + (System.Math.Pow (num8, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Sin (num10) / (double)num11);
									num3 += num11 * thickness * (float)System.Math.Sign (num12 - num);
									num4 += num11 * thickness * System.Math.Abs (num12 - num);
								}
								num9++;
							} while (num9 <= 2);
						}
						num7 = part.YPosition - part.Ycg + part.Element [j].Y0;
						float num13 = part.YPosition - part.Ycg + part.Element [j].Y1;
						num12 = (num7 + num13) / 2f;
						num11 = part.Element [j].Wid;
						if ((num7 - num) * (num13 - num) < 0f) {
							float num14 = num11 * (num7 - num) / (num7 - num13);
							float num15 = num11 * (num13 - num) / (num13 - num7);
							num3 += (num15 - num14) * thickness * (float)System.Math.Sign (num13 - num);
							num4 += num14 * thickness * System.Math.Abs (num7 - num) / 2f + num15 * thickness * System.Math.Abs (num13 - num) / 2f;
						} else if ((num12 + thickness / 2f - num) * (num12 - thickness / 2f - num) < 0f) {
							num13 = num12 + thickness / 2f - num;
							num7 = num - (num12 - thickness / 2f);
							num3 += num11 * num13 - num11 * num7;
							num4 = (float)((double)num4 + ((double)num11 * System.Math.Pow (num13, 2.0) / 2.0 + (double)num11 * System.Math.Pow (num7, 2.0) / 2.0));
						} else {
							num3 += num11 * thickness * (float)System.Math.Sign (num12 - num);
							num4 += num11 * thickness * System.Math.Abs (num12 - num);
						}
					}
					part = null;
				}
				if ((double)System.Math.Abs (num3) < 0.0001 * (double)Prop.A) {
					break;
				}
				num16 = ((num2 != 1) ? (num16 / 2f) : Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (num3 > 0f, Ymax - num, num - Ymin), 2)));
				num += (float)System.Math.Sign (num3) * num16;
				num2++;
			} while (num2 <= 12);
			Prop.Zx = num4;
			float num17 = Prop.Xcg;
			int num18 = 1;
			do {
				float num3 = 0f;
				num4 = 0f;
				int num19 = nPart;
				for (int k = 1; k <= num19; k++) {
					Part part2 = Part [k];
					float thickness = part2.Thickness;
					int nElem2 = part2.nElem;
					for (int l = 1; l <= nElem2; l++) {
						short num6 = Conversions.ToShort (Interaction.IIf (l == 1, part2.nElem, l - 1));
						float num22;
						float num11;
						float num20;
						if ((l > 1) | part2.Closed) {
							num20 = part2.XPosition - part2.Xcg + part2.Element [l].Xac;
							float num8 = part2.Element [l].Rad + thickness / 2f;
							float arc = part2.Element [l].Arc;
							array [0] = (float)((double)part2.Element [num6].Ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
							array [3] = array [0] + arc;
							array [1] = array [0];
							array [2] = array [0];
							if (System.Math.Abs (num17 - num20) < num8) {
								array [1] = AngleBetween (array [0], array [3], (float)System.Math.Acos ((num17 - num20) / num8));
								array [2] = AngleBetween (array [0], array [3], (float)(0.0 - System.Math.Acos ((num17 - num20) / num8)));
								if (System.Math.Sign (array [2] - array [1]) != System.Math.Sign (array [3] - array [0])) {
									CFS.Swap (ref array [1], ref array [2]);
								}
							}
							int num21 = 0;
							do {
								if (array [num21 + 1] != array [num21]) {
									arc = System.Math.Abs (array [num21 + 1] - array [num21]) / 2f;
									float num10 = (array [num21 + 1] + array [num21]) / 2f;
									num11 = 2f * num8 * arc;
									num22 = (float)((double)num20 + (System.Math.Pow (num8, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Cos (num10) / (double)num11);
									num3 += num11 * thickness * (float)System.Math.Sign (num22 - num17);
									num4 += num11 * thickness * System.Math.Abs (num22 - num17);
								}
								num21++;
							} while (num21 <= 2);
						}
						num20 = part2.XPosition - part2.Xcg + part2.Element [l].X0;
						float num23 = part2.XPosition - part2.Xcg + part2.Element [l].X1;
						num22 = (num20 + num23) / 2f;
						num11 = part2.Element [l].Wid;
						if ((num20 - num17) * (num23 - num17) < 0f) {
							float num14 = num11 * (num20 - num17) / (num20 - num23);
							float num15 = num11 * (num23 - num17) / (num23 - num20);
							num3 += (num15 - num14) * thickness * (float)System.Math.Sign (num23 - num17);
							num4 += num14 * thickness * System.Math.Abs (num20 - num17) / 2f + num15 * thickness * System.Math.Abs (num23 - num17) / 2f;
						} else if ((num22 + thickness / 2f - num17) * (num22 - thickness / 2f - num17) < 0f) {
							num23 = num22 + thickness / 2f - num17;
							num20 = num17 - (num22 - thickness / 2f);
							num3 += num11 * num23 - num11 * num20;
							num4 = (float)((double)num4 + ((double)num11 * System.Math.Pow (num23, 2.0) / 2.0 + (double)num11 * System.Math.Pow (num20, 2.0) / 2.0));
						} else {
							num3 += num11 * thickness * (float)System.Math.Sign (num22 - num17);
							num4 += num11 * thickness * System.Math.Abs (num22 - num17);
						}
					}
					part2 = null;
				}
				if ((double)System.Math.Abs (num3) < 0.0001 * (double)Prop.A) {
					break;
				}
				num16 = ((num18 != 1) ? (num16 / 2f) : Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (num3 > 0f, Xmax - num17, num17 - Xmin), 2)));
				num17 += (float)System.Math.Sign (num3) * num16;
				num18++;
			} while (num18 <= 12);
			Prop.Zy = num4;
			if (Prop.An == Prop.A) {
				Prop.Zxn = Prop.Zx;
				Prop.Zyn = Prop.Zy;
				return;
			}
			num = Prop.Ycgn;
			int num24 = 1;
			do {
				float num3 = 0f;
				num4 = 0f;
				int num25 = nPart;
				for (int m = 1; m <= num25; m++) {
					Part part3 = Part [m];
					float thickness = part3.Thickness;
					int nElem3 = part3.nElem;
					for (int n = 1; n <= nElem3; n++) {
						short num6 = Conversions.ToShort (Interaction.IIf (n == 1, part3.nElem, n - 1));
						if ((n > 1) | part3.Closed) {
							float num7 = part3.YPosition - part3.Ycg + part3.Element [n].Yac;
							float num8 = part3.Element [n].Rad + thickness / 2f;
							float arc = part3.Element [n].Arc;
							array [0] = (float)((double)part3.Element [num6].Ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
							array [3] = array [0] + arc;
							array [1] = array [0];
							array [2] = array [0];
							if (System.Math.Abs (num - num7) < num8) {
								array [1] = AngleBetween (array [0], array [3], (float)System.Math.Asin ((num - num7) / num8));
								array [2] = AngleBetween (array [0], array [3], (float)(System.Math.PI - System.Math.Asin ((num - num7) / num8)));
								if (System.Math.Sign (array [2] - array [1]) != System.Math.Sign (array [3] - array [0])) {
									CFS.Swap (ref array [1], ref array [2]);
								}
							}
							int num26 = 0;
							do {
								if (array [num26 + 1] != array [num26]) {
									arc = System.Math.Abs (array [num26 + 1] - array [num26]) / 2f;
									float num10 = (array [num26 + 1] + array [num26]) / 2f;
									float num11 = 2f * num8 * arc;
									float num12 = (float)((double)num7 + (System.Math.Pow (num8, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Sin (num10) / (double)num11);
									num3 += num11 * thickness * (float)System.Math.Sign (num12 - num);
									num4 += num11 * thickness * System.Math.Abs (num12 - num);
								}
								num26++;
							} while (num26 <= 2);
						}
						int num27 = 0;
						do {
							float num20 = part3.XPosition - part3.Xcg + part3.Element [n].X0;
							float num7 = part3.YPosition - part3.Ycg + part3.Element [n].Y0;
							float num23 = part3.XPosition - part3.Xcg + part3.Element [n].X1;
							float num13 = part3.YPosition - part3.Ycg + part3.Element [n].Y1;
							if (part3.Element [n].Hole == 0f) {
								num27 = 2;
							}
							if (num27 == 0) {
								num23 = part3.XPosition - part3.Xcg + part3.Element [n].Xh0;
								num13 = part3.YPosition - part3.Ycg + part3.Element [n].Yh0;
							}
							if (num27 == 1) {
								num20 = part3.XPosition - part3.Xcg + part3.Element [n].Xh1;
								num7 = part3.YPosition - part3.Ycg + part3.Element [n].Yh1;
							}
							float num12 = (num7 + num13) / 2f;
							float num11 = (float)System.Math.Sqrt (System.Math.Pow (num23 - num20, 2.0) + System.Math.Pow (num13 - num7, 2.0));
							if ((num7 - num) * (num13 - num) < 0f) {
								float num14 = num11 * (num7 - num) / (num7 - num13);
								float num15 = num11 * (num13 - num) / (num13 - num7);
								num3 += (num15 - num14) * thickness * (float)System.Math.Sign (num13 - num);
								num4 += num14 * thickness * System.Math.Abs (num7 - num) / 2f + num15 * thickness * System.Math.Abs (num13 - num) / 2f;
							} else if ((num12 + thickness / 2f - num) * (num12 - thickness / 2f - num) < 0f) {
								num13 = num12 + thickness / 2f - num;
								num7 = num - (num12 - thickness / 2f);
								num3 += num11 * num13 - num11 * num7;
								num4 = (float)((double)num4 + ((double)num11 * System.Math.Pow (num13, 2.0) / 2.0 + (double)num11 * System.Math.Pow (num7, 2.0) / 2.0));
							} else {
								num3 += num11 * thickness * (float)System.Math.Sign (num12 - num);
								num4 += num11 * thickness * System.Math.Abs (num12 - num);
							}
							num27++;
						} while (num27 <= 1);
					}
					part3 = null;
				}
				if ((double)System.Math.Abs (num3) < 0.0001 * (double)Prop.An) {
					break;
				}
				num16 = ((num24 != 1) ? (num16 / 2f) : Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (num3 > 0f, Ymax - num, num - Ymin), 2)));
				num += (float)System.Math.Sign (num3) * num16;
				num24++;
			} while (num24 <= 12);
			Prop.Zxn = num4;
			num17 = Prop.Xcgn;
			int num28 = 1;
			do {
				float num3 = 0f;
				num4 = 0f;
				int num29 = nPart;
				for (int num30 = 1; num30 <= num29; num30++) {
					Part part4 = Part [num30];
					float thickness = part4.Thickness;
					int nElem4 = part4.nElem;
					for (int num31 = 1; num31 <= nElem4; num31++) {
						short num6 = Conversions.ToShort (Interaction.IIf (num31 == 1, part4.nElem, num31 - 1));
						if ((num31 > 1) | part4.Closed) {
							float num20 = part4.XPosition - part4.Xcg + part4.Element [num31].Xac;
							float num8 = part4.Element [num31].Rad + thickness / 2f;
							float arc = part4.Element [num31].Arc;
							array [0] = (float)((double)part4.Element [num6].Ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
							array [3] = array [0] + arc;
							array [1] = array [0];
							array [2] = array [0];
							if (System.Math.Abs (num17 - num20) < num8) {
								array [1] = AngleBetween (array [0], array [3], (float)System.Math.Acos ((num17 - num20) / num8));
								array [2] = AngleBetween (array [0], array [3], (float)(0.0 - System.Math.Acos ((num17 - num20) / num8)));
								if (System.Math.Sign (array [2] - array [1]) != System.Math.Sign (array [3] - array [0])) {
									CFS.Swap (ref array [1], ref array [2]);
								}
							}
							int num32 = 0;
							do {
								if (array [num32 + 1] != array [num32]) {
									arc = System.Math.Abs (array [num32 + 1] - array [num32]) / 2f;
									float num10 = (array [num32 + 1] + array [num32]) / 2f;
									float num11 = 2f * num8 * arc;
									float num22 = (float)((double)num20 + (System.Math.Pow (num8, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Cos (num10) / (double)num11);
									num3 += num11 * thickness * (float)System.Math.Sign (num22 - num17);
									num4 += num11 * thickness * System.Math.Abs (num22 - num17);
								}
								num32++;
							} while (num32 <= 2);
						}
						int num33 = 0;
						do {
							float num20 = part4.XPosition - part4.Xcg + part4.Element [num31].X0;
							float num7 = part4.YPosition - part4.Ycg + part4.Element [num31].Y0;
							float num23 = part4.XPosition - part4.Xcg + part4.Element [num31].X1;
							float num13 = part4.YPosition - part4.Ycg + part4.Element [num31].Y1;
							if (part4.Element [num31].Hole == 0f) {
								num33 = 2;
							}
							if (num33 == 0) {
								num23 = part4.XPosition - part4.Xcg + part4.Element [num31].Xh0;
								num13 = part4.YPosition - part4.Ycg + part4.Element [num31].Yh0;
							}
							if (num33 == 1) {
								num20 = part4.XPosition - part4.Xcg + part4.Element [num31].Xh1;
								num7 = part4.YPosition - part4.Ycg + part4.Element [num31].Yh1;
							}
							float num22 = (num20 + num23) / 2f;
							float num11 = (float)System.Math.Sqrt (System.Math.Pow (num23 - num20, 2.0) + System.Math.Pow (num13 - num7, 2.0));
							if ((num20 - num17) * (num23 - num17) < 0f) {
								float num14 = num11 * (num20 - num17) / (num20 - num23);
								float num15 = num11 * (num23 - num17) / (num23 - num20);
								num3 += (num15 - num14) * thickness * (float)System.Math.Sign (num23 - num17);
								num4 += num14 * thickness * System.Math.Abs (num20 - num17) / 2f + num15 * thickness * System.Math.Abs (num23 - num17) / 2f;
							} else if ((num22 + thickness / 2f - num17) * (num22 - thickness / 2f - num17) < 0f) {
								num23 = num22 + thickness / 2f - num17;
								num20 = num17 - (num22 - thickness / 2f);
								num3 += num11 * num23 - num11 * num20;
								num4 = (float)((double)num4 + ((double)num11 * System.Math.Pow (num23, 2.0) / 2.0 + (double)num11 * System.Math.Pow (num20, 2.0) / 2.0));
							} else {
								num3 += num11 * thickness * (float)System.Math.Sign (num22 - num17);
								num4 += num11 * thickness * System.Math.Abs (num22 - num17);
							}
							num33++;
						} while (num33 <= 1);
					}
					part4 = null;
				}
				if ((double)System.Math.Abs (num3) < 0.0001 * (double)Prop.An) {
					break;
				}
				num16 = ((num28 != 1) ? (num16 / 2f) : Conversions.ToSingle (Operators.DivideObject (Interaction.IIf (num3 > 0f, Xmax - num17, num17 - Xmin), 2)));
				num17 += (float)System.Math.Sign (num3) * num16;
				num28++;
			} while (num28 <= 12);
			Prop.Zyn = num4;
		}
	}

	private float AngleBetween (float A0, float A1, float A)
	{
		if (A1 > A0) {
			while (A > A1) {
				A = (float)((double)A - System.Math.PI * 2.0);
			}
			while (A < A0) {
				A = (float)((double)A + System.Math.PI * 2.0);
			}
			if (A > A0 && A < A1) {
				return A;
			}
			return A0;
		}
		while (A < A1) {
			A = (float)((double)A + System.Math.PI * 2.0);
		}
		while (A > A0) {
			A = (float)((double)A - System.Math.PI * 2.0);
		}
		if (A > A1 && A < A0) {
			return A;
		}
		return A0;
	}

	internal float BetaY (float P, float Mx, float My)
	{
		if (Mx == 0f && My == 0f) {
			return Prop.An / Prop.A;
		}
		float num = (float)((double)Mx * System.Math.Cos (Prop.Alpha) - (double)My * System.Math.Sin (Prop.Alpha));
		float num2 = (float)((double)My * System.Math.Cos (Prop.Alpha) + (double)Mx * System.Math.Sin (Prop.Alpha));
		float num3 = Material.Fy [2];
		float i = Prop.I1;
		float i2 = Prop.I2;
		float num4 = num3 * Prop.A;
		Extremes extremes = ExtremeFibers (Prop.Alpha);
		float num5 = (float)((double)(num3 * i) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		extremes = ExtremeFibers ((float)((double)Prop.Alpha + System.Math.PI / 2.0));
		float num6 = (float)((double)(num3 * i2) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		float num7 = (float)System.Math.Sqrt (System.Math.Pow (P / num4, 2.0) + System.Math.Pow (num / num5, 2.0) + System.Math.Pow (num2 / num6, 2.0));
		num = (float)((double)Mx * System.Math.Cos (Prop.Alphan) - (double)My * System.Math.Sin (Prop.Alphan));
		num2 = (float)((double)My * System.Math.Cos (Prop.Alphan) + (double)Mx * System.Math.Sin (Prop.Alphan));
		i = Prop.I1n;
		i2 = Prop.I2n;
		float num8 = (float)System.Math.Atan2 (num2 / i2, num / i);
		extremes = ExtremeFibers (Prop.Alphan - num8, blnNet: true);
		float num9 = ((!(System.Math.Abs (num / i) > System.Math.Abs (num2 / i2))) ? ((float)((double)(num2 / i2) / System.Math.Sin (num8))) : ((float)((double)(num / i) / System.Math.Cos (num8))));
		float num10 = System.Math.Abs (P / Prop.An + num9 * extremes.Dmax);
		float num11 = System.Math.Abs (P / Prop.An + num9 * extremes.Dmin);
		return (float)((double)(num7 * num3) / CFS.Max (num10, num11));
	}

	internal float BetaS (float P, float Mx, float My)
	{
		float num = 0f;
		if (Mx == 0f && My == 0f) {
			return checked(1 + System.Math.Sign (num));
		}
		float num2 = (float)((double)Mx * System.Math.Cos (Prop.Alpha) - (double)My * System.Math.Sin (Prop.Alpha));
		float num3 = (float)((double)My * System.Math.Cos (Prop.Alpha) + (double)Mx * System.Math.Sin (Prop.Alpha));
		float num4 = Material.Fy [2];
		float i = Prop.I1;
		float i2 = Prop.I2;
		float num5 = num4 * Prop.A;
		Extremes extremes = ExtremeFibers (Prop.Alpha);
		float num6 = (float)((double)(num4 * i) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		extremes = ExtremeFibers ((float)((double)Prop.Alpha + System.Math.PI / 2.0));
		float num7 = (float)((double)(num4 * i2) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		_ = (float)System.Math.Sqrt (System.Math.Pow (num / num5, 2.0) + System.Math.Pow (num2 / num6, 2.0) + System.Math.Pow (num3 / num7, 2.0));
		float num8 = (float)System.Math.Atan2 (num3 / i2, num2 / i);
		extremes = ExtremeFibers (Prop.Alpha - num8);
		float num9 = ((!(System.Math.Abs (num2 / i) > System.Math.Abs (num3 / i2))) ? ((float)((double)(num3 / i2) / System.Math.Sin (num8))) : ((float)((double)(num2 / i) / System.Math.Cos (num8))));
		float A = num / Prop.A + num9 * extremes.Dmax;
		float B = num / Prop.A + num9 * extremes.Dmin;
		if (B > A) {
			CFS.Swap (ref A, ref B);
		}
		if (A < 0f) {
			A = 0f;
		}
		if (B > 0f) {
			B = 0f;
		}
		return 2f * A / (A - B);
	}

	internal void PlasticSurface ()
	{
		Section section = Clone ();
		string strMsg = string.Empty;
		float[] array = new float[4];
		Plastic = new SurfacePoint[109, 25];
		Section section2 = section;
		section2.Rotate (0f - Prop.Alpha);
		section2.CalcProperties (ref strMsg, blnCheckLicense: false);
		float num = section2.Material.Fy [2];
		_ = section2.Prop;
		_ = section2.Prop;
		float num2 = num * section2.Prop.A;
		float num3 = num * section2.Prop.Sx;
		float num4 = num * section2.Prop.Sy;
		float num5 = 0.08726646f;
		int num6 = 0;
		checked {
			do {
				if (num6 > 0) {
					section2.Rotate (num5);
					section2.CalcProperties (ref strMsg, blnCheckLicense: false);
				}
				int num7 = 0;
				do {
					if (unchecked(num7 == 0 || num7 == 24)) {
						float num8 = Conversions.ToSingle (Operators.MultiplyObject (Interaction.IIf (num7 == 0, num, 0f - num), section2.Prop.An));
						Plastic [num6, num7].Theta = (float)num6 * num5;
						Plastic [num6, num7].Beta = System.Math.Abs (num8 / num2);
						Plastic [num6, num7].Phi = (float)System.Math.Acos (System.Math.Sign (num8));
					} else {
						float num9 = (float)((double)section2.Ymin + (double)(section2.Ymax - section2.Ymin) * (1.0 - System.Math.Cos (System.Math.PI * (double)num7 / 24.0)) / 2.0);
						float num8 = 0f;
						float num10 = 0f;
						float num11 = 0f;
						int num12 = section2.nPart;
						for (int i = 1; i <= num12; i++) {
							Part part = section2.Part [i];
							float thickness = part.Thickness;
							int nElem = part.nElem;
							for (int j = 1; j <= nElem; j++) {
								short num13 = Conversions.ToShort (Interaction.IIf (j == 1, part.nElem, j - 1));
								if ((j > 1) | part.Closed) {
									float num14 = part.XPosition - part.Xcg + part.Element [j].Xac;
									float num15 = part.YPosition - part.Ycg + part.Element [j].Yac;
									float num16 = part.Element [j].Rad + thickness / 2f;
									float arc = part.Element [j].Arc;
									array [0] = (float)((double)part.Element [num13].Ang - (double)System.Math.Sign (arc) * System.Math.PI / 2.0);
									array [3] = array [0] + arc;
									array [1] = array [0];
									array [2] = array [0];
									if (System.Math.Abs (num9 - num15) < num16) {
										array [1] = AngleBetween (array [0], array [3], (float)System.Math.Asin ((num9 - num15) / num16));
										array [2] = AngleBetween (array [0], array [3], (float)(System.Math.PI - System.Math.Asin ((num9 - num15) / num16)));
										if (System.Math.Sign (array [2] - array [1]) != System.Math.Sign (array [3] - array [0])) {
											CFS.Swap (ref array [1], ref array [2]);
										}
									}
									int num17 = 0;
									do {
										if (array [num17 + 1] != array [num17]) {
											arc = System.Math.Abs (array [num17 + 1] - array [num17]) / 2f;
											float num18 = (array [num17 + 1] + array [num17]) / 2f;
											float num19 = 2f * num16 * arc;
											float num20 = (float)((double)num14 + (System.Math.Pow (num16, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Cos (num18) / (double)num19);
											float num21 = (float)((double)num15 + (System.Math.Pow (num16, 2.0) + System.Math.Pow (thickness, 2.0) / 12.0) * 2.0 * System.Math.Sin (arc) * System.Math.Sin (num18) / (double)num19);
											num8 += num19 * thickness * (float)System.Math.Sign (num21 - num9);
											num10 += num19 * thickness * System.Math.Abs (num21 - num9);
											num11 += num19 * thickness * (float)System.Math.Sign (num21 - num9) * num20;
										}
										num17++;
									} while (num17 <= 2);
								}
								int num22 = 0;
								do {
									float num14 = part.XPosition - part.Xcg + part.Element [j].X0;
									float num15 = part.YPosition - part.Ycg + part.Element [j].Y0;
									float num23 = part.XPosition - part.Xcg + part.Element [j].X1;
									float num24 = part.YPosition - part.Ycg + part.Element [j].Y1;
									if (part.Element [j].Hole == 0f) {
										num22 = 2;
									}
									if (num22 == 0) {
										num23 = part.XPosition - part.Xcg + part.Element [j].Xh0;
										num24 = part.YPosition - part.Ycg + part.Element [j].Yh0;
									}
									if (num22 == 1) {
										num14 = part.XPosition - part.Xcg + part.Element [j].Xh1;
										num15 = part.YPosition - part.Ycg + part.Element [j].Yh1;
									}
									float num20 = (num14 + num23) / 2f;
									float num21 = (num15 + num24) / 2f;
									float num19 = (float)System.Math.Sqrt (System.Math.Pow (num23 - num14, 2.0) + System.Math.Pow (num24 - num15, 2.0));
									if ((num15 - num9) * (num24 - num9) < 0f) {
										float num25 = num19 * (num15 - num9) / (num15 - num24);
										float num26 = num19 * (num24 - num9) / (num24 - num15);
										num20 = num14 + (num23 - num14) * num25 / num19;
										num8 += (num26 - num25) * thickness * (float)System.Math.Sign (num24 - num9);
										num10 += num25 * thickness * System.Math.Abs (num15 - num9) / 2f + num26 * thickness * System.Math.Abs (num24 - num9) / 2f;
										num11 += num25 * thickness * (float)System.Math.Sign (num15 - num9) * (num14 + num20) / 2f + num26 * thickness * (float)System.Math.Sign (num24 - num9) * (num20 + num23) / 2f;
									} else if ((num21 + thickness / 2f - num9) * (num21 - thickness / 2f - num9) < 0f) {
										num24 = num21 + thickness / 2f - num9;
										num15 = num9 - (num21 - thickness / 2f);
										num8 += num19 * num24 - num19 * num15;
										num10 = (float)((double)num10 + ((double)num19 * System.Math.Pow (num24, 2.0) / 2.0 + (double)num19 * System.Math.Pow (num15, 2.0) / 2.0));
										num11 += num19 * num24 * num20 - num19 * num15 * num20;
									} else {
										num8 += num19 * thickness * (float)System.Math.Sign (num21 - num9);
										num10 += num19 * thickness * System.Math.Abs (num21 - num9);
										num11 += num19 * thickness * (float)System.Math.Sign (num21 - num9) * num20;
									}
									num22++;
								} while (num22 <= 1);
							}
							part = null;
						}
						num10 -= num8 * (section2.Prop.Ycgn - num9);
						num11 -= num8 * section2.Prop.Xcgn;
						num8 *= num;
						num10 *= num;
						num11 *= num;
						float num27 = (float)((double)num10 * System.Math.Cos ((float)num6 * num5) - (double)num11 * System.Math.Sin ((float)num6 * num5));
						float num28 = (float)((double)num11 * System.Math.Cos ((float)num6 * num5) + (double)num10 * System.Math.Sin ((float)num6 * num5));
						Plastic [num6, num7].Theta = (float)System.Math.Atan2 (num28 / num4, num27 / num3);
						if ((double)Plastic [num6, num7].Theta < (double)((float)num6 * num5) - System.Math.PI) {
							ref float theta = ref Plastic [num6, num7].Theta;
							theta = (float)((double)theta + System.Math.PI * 2.0);
						}
						Plastic [num6, num7].Beta = (float)System.Math.Sqrt (System.Math.Pow (num8 / num2, 2.0) + System.Math.Pow (num27 / num3, 2.0) + System.Math.Pow (num28 / num4, 2.0));
						Plastic [num6, num7].Phi = (float)System.Math.Acos (num8 / num2 / Plastic [num6, num7].Beta);
						if (float.IsNaN (Plastic [num6, num7].Phi)) {
							Plastic [num6, num7].Phi = (float)System.Math.Acos (System.Math.Sign (num8));
						}
						if ((double)System.Math.Abs (num8 / num2 / Plastic [num6, num7].Beta) > 0.9999) {
							Plastic [num6, num7].Theta = (float)num6 * num5;
						}
					}
					num7++;
				} while (num7 <= 24);
				num6++;
			} while (num6 <= 71);
			double num29 = 72.0;
			do {
				int num30 = 0;
				do {
					Plastic [(int)System.Math.Round (num29), num30].Theta = (float)((double)Plastic [(int)System.Math.Round (num29 - 72.0), num30].Theta + System.Math.PI * 2.0);
					Plastic [(int)System.Math.Round (num29), num30].Phi = Plastic [(int)System.Math.Round (num29 - 72.0), num30].Phi;
					Plastic [(int)System.Math.Round (num29), num30].Beta = Plastic [(int)System.Math.Round (num29 - 72.0), num30].Beta;
					num30++;
				} while (num30 <= 24);
				num29 += 1.0;
			} while (num29 <= 108.0);
			section2 = null;
		}
	}

	internal float BetaP (float P, float Mx, float My)
	{
		float[] array = new float[6];
		float[] array2 = new float[6];
		float[] array3 = new float[6];
		float[] array4 = new float[6];
		float[] array5 = new float[6];
		if (Mx == 0f && My == 0f) {
			return Prop.An / Prop.A;
		}
		float num = (float)((double)Mx * System.Math.Cos (Prop.Alpha) - (double)My * System.Math.Sin (Prop.Alpha));
		float num2 = (float)((double)My * System.Math.Cos (Prop.Alpha) + (double)Mx * System.Math.Sin (Prop.Alpha));
		float num3 = Material.Fy [2];
		float num4 = num3 * Prop.A;
		Extremes extremes = ExtremeFibers (Prop.Alpha);
		float num5 = (float)((double)(num3 * Prop.I1) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		extremes = ExtremeFibers ((float)((double)Prop.Alpha + System.Math.PI / 2.0));
		float num6 = (float)((double)(num3 * Prop.I2) / CFS.Max (extremes.Dmax, 0f - extremes.Dmin));
		float num7 = (float)System.Math.Atan2 (num2 / num6, num / num5);
		if ((double)num7 < System.Math.PI / 4.0) {
			num7 = (float)((double)num7 + System.Math.PI * 2.0);
		}
		float num8 = (float)System.Math.Sqrt (System.Math.Pow (P / num4, 2.0) + System.Math.Pow (num / num5, 2.0) + System.Math.Pow (num2 / num6, 2.0));
		float num9 = (float)System.Math.Acos (P / num4 / num8);
		if (float.IsNaN (num9)) {
			num9 = (float)System.Math.Acos (System.Math.Sign (P));
		}
		checked {
			short num10 = (short)Information.UBound (Plastic);
			short num15 = default(short);
			for (short num11 = 0; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
				short num12 = 0;
				bool flag = false;
				short num13 = (short)Information.UBound (Plastic, 2);
				for (short num14 = 0; num14 <= num13; num14 = (short)unchecked(num14 + 1)) {
					if (num14 + 4 >= Information.UBound (Plastic, 2)) {
						flag = true;
					}
					if (num14 + 1 <= Information.UBound (Plastic, 2) && Plastic [num11, num14 + 1].Phi > num9) {
						flag = true;
					}
					if (num14 + 5 <= Information.UBound (Plastic, 2) && Plastic [num11, num14 + 4].Phi > num9 && num9 - Plastic [num11, num14].Phi < Plastic [num11, num14 + 5].Phi - num9) {
						flag = true;
					}
					if (flag) {
						num12 = (short)(num12 + 1);
						array [num12] = Plastic [num11, num14].Phi;
						array2 [num12] = Plastic [num11, num14].Theta;
						array3 [num12] = Plastic [num11, num14].Beta;
						if (num12 == 5) {
							break;
						}
					}
				}
				if (num15 == 5) {
					array4 [1] = array4 [2];
					array4 [2] = array4 [3];
					array4 [3] = array4 [4];
					array4 [4] = array4 [5];
					array5 [1] = array5 [2];
					array5 [2] = array5 [3];
					array5 [3] = array5 [4];
					array5 [4] = array5 [5];
				} else {
					num15 = (short)(num15 + 1);
				}
				array4 [num15] = DataAnalysis.BezierInterpolate (num12, array, array2, num9);
				array5 [num15] = DataAnalysis.BezierInterpolate (num12, array, array3, num9);
				if ((num15 > 1) & (array4 [num15] < array4 [num15 - 1])) {
					num15 = (short)(num15 - 1);
					array4 [num15] = (float)(0.5 * (double)(array4 [num15] + array4 [num15 + 1]));
					array5 [num15] = (float)(0.5 * (double)(array5 [num15] + array5 [num15 + 1]));
				}
				if (num15 == 5 && array4 [num15 - 2] > num7) {
					break;
				}
			}
			return DataAnalysis.BezierInterpolate (5, array4, array5, num7);
		}
	}

	internal void Rotate (float sngAngle)
	{
		int num = nPart;
		for (int i = 1; i <= num; i = checked(i + 1)) {
			Part [i].Rotate (sngAngle);
		}
		bool flag = default(bool);
		if (System.Math.Cos (sngAngle) >= 0.99999898672103882) {
			flag = true;
		} else if (System.Math.Cos (sngAngle) <= -0.99999898672103882) {
			CFS.Swap (ref DSM.Mcrlxp, ref DSM.Mcrlxn);
			CFS.Swap (ref DSM.Mcrlyp, ref DSM.Mcrlyn);
			CFS.Swap (ref DSM.Mcrdxp, ref DSM.Mcrdxn);
			CFS.Swap (ref DSM.Mcrdyp, ref DSM.Mcrdyn);
			flag = true;
		} else if (System.Math.Sin (sngAngle) >= 0.99999898672103882) {
			float mcrlxp = DSM.Mcrlxp;
			DSM.Mcrlxp = DSM.Mcrlyp;
			DSM.Mcrlyp = DSM.Mcrlxn;
			DSM.Mcrlxn = DSM.Mcrlyn;
			DSM.Mcrlyn = mcrlxp;
			mcrlxp = DSM.Mcrdxp;
			DSM.Mcrdxp = DSM.Mcrdyp;
			DSM.Mcrdyp = DSM.Mcrdxn;
			DSM.Mcrdxn = DSM.Mcrdyn;
			DSM.Mcrdyn = mcrlxp;
			CFS.Swap (ref DSM.Vcry, ref DSM.Vcrx);
			flag = true;
		} else if (System.Math.Sin (sngAngle) <= -0.99999898672103882) {
			float mcrlxp = DSM.Mcrlxp;
			DSM.Mcrlxp = DSM.Mcrlyn;
			DSM.Mcrlyn = DSM.Mcrlxn;
			DSM.Mcrlxn = DSM.Mcrlyp;
			DSM.Mcrlyp = mcrlxp;
			mcrlxp = DSM.Mcrdxp;
			DSM.Mcrdxp = DSM.Mcrdyn;
			DSM.Mcrdyn = DSM.Mcrdxn;
			DSM.Mcrdxn = DSM.Mcrdyp;
			DSM.Mcrdyp = mcrlxp;
			CFS.Swap (ref DSM.Vcry, ref DSM.Vcrx);
			flag = true;
		}
		if (!flag) {
			GeomChangeDSM = true;
		}
	}

	public bool HasSymmetry (Symmetry sym)
	{
		if (sym == Symmetry.None) {
			return Prop.Symmetry == 0;
		}
		return ((uint)Prop.Symmetry & (uint)sym) == (uint)sym;
	}

	public bool HasSymmetryNet (Symmetry sym)
	{
		if (sym == Symmetry.None) {
			return Prop.SymmetryNet == 0;
		}
		return ((uint)Prop.SymmetryNet & (uint)sym) == (uint)sym;
	}

	public bool IsCylinder ()
	{
		bool result = false;
		if (nPart == 1) {
			result = Part [1].IsCylinder ();
		}
		return result;
	}

	private bool IsCompactAngle (float Fy)
	{
		bool result = false;
		if (nPart == 1) {
			Part part = Part [1];
			if (part.nElem == 2 && (double)System.Math.Abs (part.Element [1].Len - part.Element [2].Len) < 0.001 * (double)part.A / (double)part.Thickness && (double)(part.Element [1].Wid / part.Thickness) <= 0.42 * System.Math.Sqrt (Material.Eo [2] / Fy)) {
				result = true;
			}
			part = null;
		}
		return result;
	}

	private bool IsLTBZee (LoadDirections iDir)
	{
		if (nPart != 1) {
			return false;
		}
		return Part [1].IsLTBZee (iDir);
	}

	private bool IsUnstiffened (LoadDirections iDir, short iSign, bool blnGrossSct)
	{
		short num = nPart;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (blnGrossSct) {
					if (Part [num2].IsUnstiffened (iDir, iSign, Part [num2].XPosition - Prop.Xcg, Part [num2].YPosition - Prop.Ycg)) {
						return true;
					}
				} else if (Part [num2].IsUnstiffened (iDir, iSign, Part [num2].XPosition - Prop.Xcgn, Part [num2].YPosition - Prop.Ycgn)) {
					return true;
				}
			}
			return false;
		}
	}

	public float Elongation ()
	{
		int num = 0;
		int num2 = 0;
		int num3 = nPart;
		checked {
			for (int i = 1; i <= num3; i++) {
				if (Part [i].Thickness < Material.ThkMin) {
					num2++;
				} else {
					num++;
				}
			}
			if (num2 == 0) {
				return Material.Elong;
			}
			if (num == 0) {
				return Material.ElongThin;
			}
			return (float)CFS.Min (Material.Elong, Material.ElongThin);
		}
	}

	public float DesignFy (StressDirections dir, Specifications Spec)
	{
		float num = Material.Fy [(uint)dir];
		if (Material.IsCarbon ()) {
			float num2 = Elongation ();
			if (CFS.SpecYear ((short)Spec) < 2012) {
				if (num2 < 10f) {
					num = (float)((double)num * 0.75);
					if (num > 60f) {
						num = 60f;
					}
					if (dir == StressDirections.dirSH && num > 36f) {
						num = 36f;
					}
				}
			} else if (num2 < 3f) {
				num = (float)((double)num * 0.75);
				if (num > 60f) {
					num = 60f;
				}
				if (dir == StressDirections.dirSH && num > 36f) {
					num = 36f;
				}
			} else if (num2 < 10f) {
				num = (float)((double)num * 0.9);
			}
		}
		return num;
	}

	public float DesignFu (Specifications Spec)
	{
		float num = Material.Fu;
		if (Material.IsCarbon ()) {
			float num2 = Elongation ();
			if (CFS.SpecYear ((short)Spec) < 2012) {
				if (num2 < 10f) {
					num = (float)((double)num * 0.75);
					if (num > 62f) {
						num = 62f;
					}
				}
			} else if (num2 < 3f) {
				num = Conversions.ToSingle (Operators.MultiplyObject (num, Interaction.IIf (CFS.SpecYear ((short)Spec) < 2022, 0.75, 0.8)));
				float num3 = Conversions.ToSingle (Interaction.IIf (CFS.SpecYear ((short)Spec) < 2022, 62, 65));
				if (num > num3) {
					num = num3;
				}
			} else if (num2 < 10f) {
				num = (float)((double)num * 0.9);
			}
		}
		return num;
	}

	internal void ColdWorkStress (Specifications Spec)
	{
		EffectiveProperties effectiveProperties = new EffectiveProperties ();
		bool flag = Material.IsStainless ();
		string text = string.Empty;
		string text2 = string.Empty;
		string text3 = string.Empty;
		string falsePart = string.Empty;
		string truePart = string.Empty;
		string text4 = string.Empty;
		string text5;
		string text6;
		string text7;
		if (flag) {
			text5 = "ASCE Eq. 1-1";
			text6 = "ASCE Eq. 1-2";
			text7 = "ASCE Eq. 1-3";
			text2 = "ASCE Eq. 1-4";
			text3 = "ASCE Eq. 1-5";
			falsePart = "ASCE Eq. 1-7";
			truePart = "ASCE Eq. 1-8";
			text4 = "ASCE Eq. 1-6";
		} else if (CFS.SpecYear ((short)Spec) < 2016) {
			text5 = "Eq. A7.2-1";
			text6 = "Eq. A7.2-2";
			text7 = "Eq. A7.2-3";
			text = "Eq. A7.2-4";
		} else {
			text5 = "Eq. A3.3.2-1";
			text6 = "Eq. A3.3.2-2";
			text7 = "Eq. A3.3.2-3";
			text = "Eq. A3.3.2-4";
		}
		strTraceCW = string.Empty;
		float num = Material.Fy [2];
		float num2 = DesignFy (StressDirections.dirLC, Spec);
		float num3 = DesignFy (StressDirections.dirLT, Spec);
		float num4 = (float)CFS.Min (num2, num3);
		float num5 = DesignFu (Spec);
		float num6 = Material.Eo [2];
		float num7 = num5 / num2;
		Stress.Fyat = num3;
		Stress.Fyac = num2;
		Stress.Fyacg = num2;
		Stress.Fyacn = num2;
		Stress.Fyax = num4;
		Stress.Fyaxpg = num4;
		Stress.Fyaxpn = num4;
		Stress.Fyaxng = num4;
		Stress.Fyaxnn = num4;
		Stress.Fyay = num4;
		Stress.Fyaypg = num4;
		Stress.Fyaypn = num4;
		Stress.Fyayng = num4;
		Stress.Fyaynn = num4;
		if (!Conversions.ToBoolean (Operators.AndObject (Operators.AndObject (ColdWork, Operators.CompareObjectGreaterEqual (num7, Interaction.IIf (Material.IsCarbon (), 1.2f, 1.1f), TextCompare: false)), !IsCylinder ()))) {
			return;
		}
		strTraceCW += "Cold-work of forming stresses\r\n";
		ref string reference = ref strTraceCW;
		ref string reference2 = ref reference;
		reference = reference2 + "  Fy=" + Units.DisplayStress (num2, 0, blnShowUnit: true, "", 0, 0) + ", Fu=" + Units.DisplayStress (num5, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		float num8 = default(float);
		float num9 = default(float);
		float num10 = default(float);
		float num12 = default(float);
		if (Material.IsCarbon ()) {
			num8 = (float)(3.69 * (double)num7 - 0.819 * (double)num7 * (double)num7 - 1.79);
			num9 = (float)(0.192 * (double)num7 - 0.068);
			ref string reference3 = ref strTraceCW;
			reference2 = ref reference3;
			reference3 = reference2 + "  Bc=" + Units.DisplayNone (num8, "", 0, 0) + "\t" + text7 + "\r\n";
			ref string reference4 = ref strTraceCW;
			reference2 = ref reference4;
			reference4 = reference2 + "  m=" + Units.DisplayNone (num9, "", 0, 0) + "\t" + text + "\r\n";
		} else {
			num10 = (float)(0.002 + (double)(num2 / num6));
			float num11 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.6 * (double)(1f - num2 / num5), 1f - num2 / num5));
			num12 = (float)(System.Math.Log (num2 / num5) / System.Math.Log (num10 / num11));
			ref string reference5 = ref strTraceCW;
			reference2 = ref reference5;
			reference5 = reference2 + "  εp0.2=" + Units.DisplayNone (num10, "", 0, 0) + "\t" + text3 + "\r\n";
			ref string reference6 = ref strTraceCW;
			reference6 = Conversions.ToString (Operators.ConcatenateObject (reference6, Operators.ConcatenateObject (Operators.ConcatenateObject ("  εu=" + Units.DisplayNone (num11, "", 0, 0) + "\t", Interaction.IIf (Material.IsFerritic (), truePart, falsePart)), "\r\n")));
			ref string reference7 = ref strTraceCW;
			reference2 = ref reference7;
			reference7 = reference2 + "  np=" + Units.DisplayNone (num12, "", 0, 0) + "\t" + text4 + "\r\n";
		}
		strTraceCW += "  Axial Load\r\n";
		float num13 = 0f;
		float num14 = 0f;
		short num15 = nPart;
		float num22;
		checked {
			for (short num16 = 1; num16 <= num15; num16 = (short)unchecked(num16 + 1)) {
				Part part = Part [num16];
				float thickness = part.Thickness;
				short nElem = part.nElem;
				for (short num17 = 1; num17 <= nElem; num17 = (short)unchecked(num17 + 1)) {
					unchecked {
						if ((num17 > 1) | part.Closed) {
							num7 = part.Element [num17].Rad;
							float num18 = System.Math.Abs (part.Element [num17].Arc);
							float num19 = (num7 + thickness / 2f) * thickness * num18;
							ref string reference8 = ref strTraceCW;
							reference2 = ref reference8;
							reference8 = reference2 + "    " + part.Name + " corner " + Conversions.ToString ((int)num17) + "\r\n";
							ref string reference9 = ref strTraceCW;
							reference2 = ref reference9;
							reference9 = reference2 + "      t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", R=" + Units.DisplayLen1 (num7, 0, blnShowUnit: true, "", 0, 0) + ", Ac=" + Units.DisplayLen2 (num19, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							float num20;
							if (Material.IsCarbon ()) {
								num20 = num2;
								if ((double)num18 >= System.Math.PI / 3.0 && num7 <= 7f * thickness) {
									num20 = ((!(num7 > thickness)) ? (num8 * num2) : ((float)((double)(num8 * num2) / System.Math.Pow (num7 / thickness, num9))));
								}
							} else {
								float num21 = (float)(0.25 * (double)thickness / (double)(num7 + thickness / 2f));
								num8 = (float)(0.85 * System.Math.Pow (num21 / num10 + 1f, num12));
								num20 = (float)CFS.Min (CFS.Max (num8 * num2, num2), num5);
								ref string reference10 = ref strTraceCW;
								reference2 = ref reference10;
								reference10 = reference2 + "      εc=" + Units.DisplayNone (num21, "", 0, 0) + "\t" + text2 + "\r\n";
								ref string reference11 = ref strTraceCW;
								reference2 = ref reference11;
								reference11 = reference2 + "      Bc=" + Units.DisplayNone (num8, "", 0, 0) + "\t" + text7 + "\r\n";
							}
							ref string reference12 = ref strTraceCW;
							reference2 = ref reference12;
							reference12 = reference2 + "      Fyc=" + Units.DisplayStress (num20, 0, blnShowUnit: true, "", 0, 0) + "\t" + text6 + "\r\n";
							num13 += num19;
							num14 += num19 * num20;
						}
					}
				}
				part = null;
			}
			num22 = (num14 + (Prop.A - num13) * num2) / Prop.A;
			if (num22 > num5) {
				num22 = num5;
			}
			ref string reference13 = ref strTraceCW;
			reference2 = ref reference13;
			reference13 = reference2 + "    Fya=" + Units.DisplayStress (num22, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
		}
		if (num22 > num2) {
			Stress.Fyat = num22;
			Stress.Fyac = num22;
			if (DSM.UseDSM & (DSM.Pcrl > 0f)) {
				Stress.Fyacg = (float)(System.Math.Pow (0.776, 2.0) * (double)DSM.Pcrl * (double)num);
				if (Stress.Fyacg < num2) {
					Stress.Fyacg = num2;
				}
				if (Stress.Fyacg > num22) {
					Stress.Fyacg = num22;
				}
				if (CFS.SpecYear ((short)Spec) < 2016 && !flag) {
					Stress.Fyacg = num2;
				}
				Stress.Fyacn = Stress.Fyacg;
			} else {
				float num23 = num2;
				float num24 = num22 - num2;
				short num25 = 1;
				do {
					effectiveProperties.ResetProp (this, 1);
					effectiveProperties.EffProp (this, Prop.A * num23, 0f, 0f, 1, (short)Spec);
					if (PropEff.ColdWorkAllowed) {
						Stress.Fyacg = num23;
						if (num25 == 2) {
							break;
						}
						num23 += num24;
					} else {
						if (num25 == 1) {
							break;
						}
						num23 -= num24;
					}
					num24 /= 2f;
					checked {
						num25 = (short)unchecked(num25 + 1);
					}
				} while (num25 <= 10);
				if (Stress.Fyacg < num22) {
					ref string reference14 = ref strTraceCW;
					reference14 = reference14 + "    Max compression stress allowed: Fya=" + Units.DisplayStress (Stress.Fyacg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				Stress.Fyacn = Stress.Fyacg;
				if ((Prop.An < Prop.A) & (Stress.Fyacg > num2)) {
					num23 = num2;
					num24 = Stress.Fyacg - num2;
					num25 = 1;
					do {
						effectiveProperties.ResetProp (this, 0);
						effectiveProperties.EffProp (this, Prop.An * num23, 0f, 0f, 0, (short)Spec);
						if (PropEff.ColdWorkAllowed) {
							Stress.Fyacn = num23;
							if (num25 == 2) {
								break;
							}
							num23 += num24;
						} else {
							if (num25 == 1) {
								break;
							}
							num23 -= num24;
						}
						num24 /= 2f;
						checked {
							num25 = (short)unchecked(num25 + 1);
						}
					} while (num25 <= 10);
					if (Stress.Fyacn < Stress.Fyacg) {
						ref string reference15 = ref strTraceCW;
						reference15 = reference15 + "    Max net section compression stress allowed: Fya=" + Units.DisplayStress (Stress.Fyacg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
				}
			}
		}
		if (Material.IsStainless () && num3 != num2) {
			ref string reference16 = ref strTraceCW;
			reference16 = reference16 + "  Axial Tension (Fy=" + Units.DisplayStress (num3, 0, blnShowUnit: true, "", 0, 0) + ")\r\n";
			num10 = (float)(0.002 + (double)(num3 / num6));
			float num11 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.6 * (double)(1f - num3 / num5), 1f - num3 / num5));
			num12 = (float)(System.Math.Log (num3 / num5) / System.Math.Log (num10 / num11));
			ref string reference17 = ref strTraceCW;
			reference2 = ref reference17;
			reference17 = reference2 + "    εp0.2=" + Units.DisplayNone (num10, "", 0, 0) + "\t" + text3 + "\r\n";
			ref string reference18 = ref strTraceCW;
			reference18 = Conversions.ToString (Operators.ConcatenateObject (reference18, Operators.ConcatenateObject (Operators.ConcatenateObject ("    εu=" + Units.DisplayNone (num11, "", 0, 0) + "\t", Interaction.IIf (Material.IsFerritic (), truePart, falsePart)), "\r\n")));
			ref string reference19 = ref strTraceCW;
			reference2 = ref reference19;
			reference19 = reference2 + "    np=" + Units.DisplayNone (num12, "", 0, 0) + "\t" + text4 + "\r\n";
			num13 = 0f;
			num14 = 0f;
			short num26 = nPart;
			checked {
				for (short num16 = 1; num16 <= num26; num16 = (short)unchecked(num16 + 1)) {
					Part part2 = Part [num16];
					float thickness = part2.Thickness;
					short nElem2 = part2.nElem;
					for (short num17 = 1; num17 <= nElem2; num17 = (short)unchecked(num17 + 1)) {
						if ((num17 > 1) | part2.Closed) {
							num7 = part2.Element [num17].Rad;
							float num18 = System.Math.Abs (part2.Element [num17].Arc);
							float num19 = (num7 + thickness / 2f) * thickness * num18;
							ref string reference20 = ref strTraceCW;
							reference2 = ref reference20;
							reference20 = reference2 + "    " + part2.Name + " corner " + Conversions.ToString (unchecked((int)num17)) + "\r\n";
							ref string reference21 = ref strTraceCW;
							reference2 = ref reference21;
							reference21 = reference2 + "      t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", R=" + Units.DisplayLen1 (num7, 0, blnShowUnit: true, "", 0, 0) + ", Ac=" + Units.DisplayLen2 (num19, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							float num21 = (float)(0.25 * (double)thickness / (double)(num7 + thickness / 2f));
							num8 = (float)(0.85 * System.Math.Pow (num21 / num10 + 1f, num12));
							float num20 = (float)CFS.Min (CFS.Max (num8 * num3, num3), num5);
							ref string reference22 = ref strTraceCW;
							reference2 = ref reference22;
							reference22 = reference2 + "      εc=" + Units.DisplayNone (num21, "", 0, 0) + "\t" + text2 + "\r\n";
							ref string reference23 = ref strTraceCW;
							reference2 = ref reference23;
							reference23 = reference2 + "      Bc=" + Units.DisplayNone (num8, "", 0, 0) + "\t" + text7 + "\r\n";
							ref string reference24 = ref strTraceCW;
							reference2 = ref reference24;
							reference24 = reference2 + "      Fyc=" + Units.DisplayStress (num20, 0, blnShowUnit: true, "", 0, 0) + "\t" + text6 + "\r\n";
							num13 += num19;
							num14 += num19 * num20;
						}
					}
					part2 = null;
				}
				num22 = (num14 + (Prop.A - num13) * num3) / Prop.A;
				if (num22 > num5) {
					num22 = num5;
				}
				ref string reference25 = ref strTraceCW;
				reference2 = ref reference25;
				reference25 = reference2 + "    Fya=" + Units.DisplayStress (num22, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
				Stress.Fyat = num22;
			}
		}
		if (Material.IsStainless () && (num3 != num2 || num4 != num2)) {
			ref string reference26 = ref strTraceCW;
			reference26 = reference26 + "  Flexure (Fy=" + Units.DisplayStress (num4, 0, blnShowUnit: true, "", 0, 0) + ")\r\n";
			num10 = (float)(0.002 + (double)(num4 / num6));
			float num11 = Conversions.ToSingle (Interaction.IIf (Material.IsFerritic (), 0.6 * (double)(1f - num4 / num5), 1f - num4 / num5));
			num12 = (float)(System.Math.Log (num4 / num5) / System.Math.Log (num10 / num11));
			ref string reference27 = ref strTraceCW;
			reference2 = ref reference27;
			reference27 = reference2 + "    εp0.2=" + Units.DisplayNone (num10, "", 0, 0) + "\t" + text3 + "\r\n";
			ref string reference28 = ref strTraceCW;
			reference28 = Conversions.ToString (Operators.ConcatenateObject (reference28, Operators.ConcatenateObject (Operators.ConcatenateObject ("    εu=" + Units.DisplayNone (num11, "", 0, 0) + "\t", Interaction.IIf (Material.IsFerritic (), truePart, falsePart)), "\r\n")));
			ref string reference29 = ref strTraceCW;
			reference2 = ref reference29;
			reference29 = reference2 + "    np=" + Units.DisplayNone (num12, "", 0, 0) + "\t" + text4 + "\r\n";
		}
		strTraceCW += "  Bending about X-axis\r\n";
		num13 = 0f;
		num14 = 0f;
		float num27 = 0f;
		float num28 = ((!(Ymax - Prop.Ycg > Prop.Ycg - Ymin)) ? (Prop.Ycg - Ymin) : (Ymax - Prop.Ycg));
		short num29 = nPart;
		checked {
			for (short num16 = 1; num16 <= num29; num16 = (short)unchecked(num16 + 1)) {
				Part part3 = Part [num16];
				float thickness = part3.Thickness;
				float num30 = part3.YPosition - part3.Ycg;
				float num31 = num28 - System.Math.Abs (num30 + part3.Element [part3.nElem].Y1 - Prop.Ycg);
				short nElem3 = part3.nElem;
				for (short num17 = 1; num17 <= nElem3; num17 = (short)unchecked(num17 + 1)) {
					float num32 = num28 - System.Math.Abs (num30 + part3.Element [num17].Y0 - Prop.Ycg);
					unchecked {
						if (((num17 > 1) | part3.Closed) && ((double)num31 < 0.501 * (double)thickness || (double)num32 < 0.501 * (double)thickness)) {
							num7 = part3.Element [num17].Rad;
							float num18 = System.Math.Abs (part3.Element [num17].Arc);
							float num19 = (num7 + thickness / 2f) * thickness * num18;
							ref string reference30 = ref strTraceCW;
							reference2 = ref reference30;
							reference30 = reference2 + "    " + part3.Name + " corner " + Conversions.ToString ((int)num17) + "\r\n";
							ref string reference31 = ref strTraceCW;
							reference2 = ref reference31;
							reference31 = reference2 + "      t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", R=" + Units.DisplayLen1 (num7, 0, blnShowUnit: true, "", 0, 0) + ", Ac=" + Units.DisplayLen2 (num19, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							float num20;
							if (Material.IsCarbon ()) {
								num20 = num4;
								if ((double)num18 >= System.Math.PI / 3.0 && num7 <= 7f * thickness) {
									num20 = ((!(num7 > thickness)) ? (num8 * num4) : ((float)((double)(num8 * num4) / System.Math.Pow (num7 / thickness, num9))));
								}
							} else {
								float num21 = (float)(0.25 * (double)thickness / (double)(num7 + thickness / 2f));
								num8 = (float)(0.85 * System.Math.Pow (num21 / num10 + 1f, num12));
								num20 = (float)CFS.Min (CFS.Max (num8 * num4, num4), num5);
								ref string reference32 = ref strTraceCW;
								reference2 = ref reference32;
								reference32 = reference2 + "      εc=" + Units.DisplayNone (num21, "", 0, 0) + "\t" + text2 + "\r\n";
								ref string reference33 = ref strTraceCW;
								reference2 = ref reference33;
								reference33 = reference2 + "      Bc=" + Units.DisplayNone (num8, "", 0, 0) + "\t" + text7 + "\r\n";
							}
							ref string reference34 = ref strTraceCW;
							reference2 = ref reference34;
							reference34 = reference2 + "      Fyc=" + Units.DisplayStress (num20, 0, blnShowUnit: true, "", 0, 0) + "\t" + text6 + "\r\n";
							num13 += num19;
							num14 += num19 * num20;
						}
						num31 = num28 - System.Math.Abs (num30 + part3.Element [num17].Y1 - Prop.Ycg);
						if ((double)num32 < 0.501 * (double)thickness && (double)num31 < 0.501 * (double)thickness) {
							num27 += part3.Element [num17].Wid * thickness;
						}
					}
				}
				part3 = null;
			}
		}
		if (num13 == 0f && num27 == 0f) {
			num27 = 1f;
		}
		num22 = (num14 + num27 * num4) / (num13 + num27);
		if (num22 > num5) {
			num22 = num5;
		}
		ref string reference35 = ref strTraceCW;
		reference2 = ref reference35;
		reference35 = reference2 + "    Fya=" + Units.DisplayStress (num22, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
		if (num22 > num4) {
			Stress.Fyax = num22;
			if (DSM.UseDSM & (DSM.Mcrlxp > 0f)) {
				Stress.Fyaxpg = (float)(System.Math.Pow (0.776, 2.0) * (double)DSM.Mcrlxp * (double)num);
				if (Stress.Fyaxpg < num4) {
					Stress.Fyaxpg = num4;
				}
				if (Stress.Fyaxpg > num22) {
					Stress.Fyaxpg = num22;
				}
				if (CFS.SpecYear ((short)Spec) < 2016 && !flag) {
					Stress.Fyaxpg = num4;
				}
				Stress.Fyaxpn = Stress.Fyaxpg;
			} else {
				float num23 = num4;
				float num24 = num22 - num4;
				short num25 = 1;
				do {
					effectiveProperties.ResetProp (this, 1);
					effectiveProperties.EffProp (this, 0f, Prop.Sxt * num23, 0f, 1, (short)Spec);
					if (PropEff.ColdWorkAllowed) {
						Stress.Fyaxpg = num23;
						if (num25 == 2) {
							break;
						}
						num23 += num24;
					} else {
						if (num25 == 1) {
							break;
						}
						num23 -= num24;
					}
					num24 /= 2f;
					checked {
						num25 = (short)unchecked(num25 + 1);
					}
				} while (num25 <= 10);
				if (Stress.Fyaxpg < num22) {
					ref string reference36 = ref strTraceCW;
					reference36 = reference36 + "    Max compression stress allowed for positive bending: Fya=" + Units.DisplayStress (Stress.Fyaxpg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				Stress.Fyaxpn = Stress.Fyaxpg;
				if ((Prop.An < Prop.A) & (Stress.Fyaxpg > num4)) {
					num23 = num4;
					num24 = num22 - num4;
					num25 = 1;
					do {
						effectiveProperties.ResetProp (this, 1);
						effectiveProperties.EffProp (this, 0f, Prop.Sx * num23, 0f, 1, (short)Spec);
						if (PropEff.ColdWorkAllowed) {
							effectiveProperties.ResetProp (this, 0);
							effectiveProperties.EffProp (this, 0f, Prop.Sxn * num23, 0f, 0, (short)Spec);
							if (PropEff.ColdWorkAllowed) {
								Stress.Fyaxpn = num23;
								if (num25 == 2) {
									break;
								}
								num23 += num24;
							} else {
								if (num25 == 1) {
									break;
								}
								num23 -= num24;
							}
						} else {
							if (num25 == 1) {
								break;
							}
							num23 -= num24;
						}
						num24 /= 2f;
						checked {
							num25 = (short)unchecked(num25 + 1);
						}
					} while (num25 <= 10);
					if (Stress.Fyaxpn < num22) {
						ref string reference37 = ref strTraceCW;
						reference37 = reference37 + "    Max net section stress allowed for positive bending: Fya=" + Units.DisplayStress (Stress.Fyaxpn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
				}
			}
			if (DSM.UseDSM & (DSM.Mcrlxn > 0f)) {
				Stress.Fyaxng = (float)(System.Math.Pow (0.776, 2.0) * (double)DSM.Mcrlxn * (double)num);
				if (Stress.Fyaxng < num4) {
					Stress.Fyaxng = num4;
				}
				if (Stress.Fyaxng > num22) {
					Stress.Fyaxng = num22;
				}
				if (CFS.SpecYear ((short)Spec) < 2016 && !flag) {
					Stress.Fyaxng = num4;
				}
				Stress.Fyaxnn = Stress.Fyaxng;
			} else {
				float num23 = num4;
				float num24 = num22 - num4;
				short num25 = 1;
				do {
					effectiveProperties.ResetProp (this, 1);
					effectiveProperties.EffProp (this, 0f, (0f - Prop.Sxb) * num23, 0f, 1, (short)Spec);
					if (PropEff.ColdWorkAllowed) {
						Stress.Fyaxng = num23;
						if (num25 == 2) {
							break;
						}
						num23 += num24;
					} else {
						if (num25 == 1) {
							break;
						}
						num23 -= num24;
					}
					num24 /= 2f;
					checked {
						num25 = (short)unchecked(num25 + 1);
					}
				} while (num25 <= 10);
				if (Stress.Fyaxng < num22) {
					ref string reference38 = ref strTraceCW;
					reference38 = reference38 + "    Max compression stress allowed for negative bending: Fya=" + Units.DisplayStress (Stress.Fyaxng, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				Stress.Fyaxnn = Stress.Fyaxng;
				if ((Prop.An < Prop.A) & (Stress.Fyaxng > num4)) {
					num23 = num4;
					num24 = num22 - num4;
					num25 = 1;
					do {
						effectiveProperties.ResetProp (this, 1);
						effectiveProperties.EffProp (this, 0f, (0f - Prop.Sx) * num23, 0f, 1, (short)Spec);
						if (PropEff.ColdWorkAllowed) {
							effectiveProperties.ResetProp (this, 0);
							effectiveProperties.EffProp (this, 0f, (0f - Prop.Sxn) * num23, 0f, 0, (short)Spec);
							if (PropEff.ColdWorkAllowed) {
								Stress.Fyaxnn = num23;
								if (num25 == 2) {
									break;
								}
								num23 += num24;
							} else {
								if (num25 == 1) {
									break;
								}
								num23 -= num24;
							}
						} else {
							if (num25 == 1) {
								break;
							}
							num23 -= num24;
						}
						num24 /= 2f;
						checked {
							num25 = (short)unchecked(num25 + 1);
						}
					} while (num25 <= 10);
					if (Stress.Fyaxnn < num22) {
						ref string reference39 = ref strTraceCW;
						reference39 = reference39 + "    Max net section stress allowed for negative bending: Fya=" + Units.DisplayStress (Stress.Fyaxnn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
				}
			}
		}
		strTraceCW += "  Bending about Y-axis\r\n";
		num13 = 0f;
		num14 = 0f;
		num27 = 0f;
		num28 = ((!(Xmax - Prop.Xcg > Prop.Xcg - Xmin)) ? (Prop.Xcg - Xmin) : (Xmax - Prop.Xcg));
		short num33 = nPart;
		checked {
			for (short num16 = 1; num16 <= num33; num16 = (short)unchecked(num16 + 1)) {
				Part part4 = Part [num16];
				float thickness = part4.Thickness;
				float num30 = part4.XPosition - part4.Xcg;
				float num31 = num28 - System.Math.Abs (num30 + part4.Element [part4.nElem].X1 - Prop.Xcg);
				short nElem4 = part4.nElem;
				for (short num17 = 1; num17 <= nElem4; num17 = (short)unchecked(num17 + 1)) {
					float num32 = num28 - System.Math.Abs (num30 + part4.Element [num17].X0 - Prop.Xcg);
					unchecked {
						if (((num17 > 1) | part4.Closed) && ((double)num31 < 0.501 * (double)thickness || (double)num32 < 0.501 * (double)thickness)) {
							num7 = part4.Element [num17].Rad;
							float num18 = System.Math.Abs (part4.Element [num17].Arc);
							float num19 = (num7 + thickness / 2f) * thickness * num18;
							ref string reference40 = ref strTraceCW;
							reference2 = ref reference40;
							reference40 = reference2 + "    " + part4.Name + " corner " + Conversions.ToString ((int)num17) + "\r\n";
							ref string reference41 = ref strTraceCW;
							reference2 = ref reference41;
							reference41 = reference2 + "      t=" + Units.DisplayLen1 (thickness, 0, blnShowUnit: true, "", 0, 0) + ", R=" + Units.DisplayLen1 (num7, 0, blnShowUnit: true, "", 0, 0) + ", Ac=" + Units.DisplayLen2 (num19, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
							float num20;
							if (Material.IsCarbon ()) {
								num20 = num4;
								if ((double)num18 >= System.Math.PI / 3.0 && num7 <= 7f * thickness) {
									num20 = ((!(num7 > thickness)) ? (num8 * num4) : ((float)((double)(num8 * num4) / System.Math.Pow (num7 / thickness, num9))));
								}
							} else {
								float num21 = (float)(0.25 * (double)thickness / (double)(num7 + thickness / 2f));
								num8 = (float)(0.85 * System.Math.Pow (num21 / num10 + 1f, num12));
								num20 = num8 * num4;
								ref string reference42 = ref strTraceCW;
								reference2 = ref reference42;
								reference42 = reference2 + "      εc=" + Units.DisplayNone (num21, "", 0, 0) + "\t" + text2 + "\r\n";
								ref string reference43 = ref strTraceCW;
								reference2 = ref reference43;
								reference43 = reference2 + "      Bc=" + Units.DisplayNone (num8, "", 0, 0) + "\t" + text7 + "\r\n";
							}
							ref string reference44 = ref strTraceCW;
							reference2 = ref reference44;
							reference44 = reference2 + "      Fyc=" + Units.DisplayStress (num20, 0, blnShowUnit: true, "", 0, 0) + "\t" + text6 + "\r\n";
							num13 += num19;
							num14 += num19 * num20;
						}
						num31 = num28 - System.Math.Abs (num30 + part4.Element [num17].X1 - Prop.Xcg);
						if ((double)num32 < 0.501 * (double)thickness && (double)num31 < 0.501 * (double)thickness) {
							num27 += part4.Element [num17].Wid * thickness;
						}
					}
				}
				part4 = null;
			}
		}
		if (num13 == 0f && num27 == 0f) {
			num27 = 1f;
		}
		num22 = (num14 + num27 * num4) / (num13 + num27);
		if (num22 > num5) {
			num22 = num5;
		}
		ref string reference45 = ref strTraceCW;
		reference2 = ref reference45;
		reference45 = reference2 + "    Fya=" + Units.DisplayStress (num22, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
		if (num22 > num4) {
			Stress.Fyay = num22;
			if (DSM.UseDSM & (DSM.Mcrlyp > 0f)) {
				Stress.Fyaypg = (float)(System.Math.Pow (0.776, 2.0) * (double)DSM.Mcrlyp * (double)num);
				if (Stress.Fyaypg < num4) {
					Stress.Fyaypg = num4;
				}
				if (Stress.Fyaypg > num22) {
					Stress.Fyaypg = num22;
				}
				if (CFS.SpecYear ((short)Spec) < 2016 && !flag) {
					Stress.Fyaypg = num4;
				}
				Stress.Fyaypn = Stress.Fyaypg;
			} else {
				float num23 = num4;
				float num24 = num22 - num4;
				short num25 = 1;
				do {
					effectiveProperties.ResetProp (this, 1);
					effectiveProperties.EffProp (this, 0f, 0f, Prop.Syr * num23, 1, (short)Spec);
					if (PropEff.ColdWorkAllowed) {
						Stress.Fyaypg = num23;
						if (num25 == 2) {
							break;
						}
						num23 += num24;
					} else {
						if (num25 == 1) {
							break;
						}
						num23 -= num24;
					}
					num24 /= 2f;
					checked {
						num25 = (short)unchecked(num25 + 1);
					}
				} while (num25 <= 10);
				if (Stress.Fyaypg < num22) {
					ref string reference46 = ref strTraceCW;
					reference46 = reference46 + "    Max compression stress allowed for positive bending: Fya=" + Units.DisplayStress (Stress.Fyaypg, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				Stress.Fyaypn = Stress.Fyaypg;
				if ((Prop.An < Prop.A) & (Stress.Fyaypg > num4)) {
					num23 = num4;
					num24 = num22 - num4;
					num25 = 1;
					do {
						effectiveProperties.ResetProp (this, 1);
						effectiveProperties.EffProp (this, 0f, 0f, Prop.Sy * num23, 1, (short)Spec);
						if (PropEff.ColdWorkAllowed) {
							effectiveProperties.ResetProp (this, 0);
							effectiveProperties.EffProp (this, 0f, 0f, Prop.Syn * num23, 0, (short)Spec);
							if (PropEff.ColdWorkAllowed) {
								Stress.Fyaypn = num23;
								if (num25 == 2) {
									break;
								}
								num23 += num24;
							} else {
								if (num25 == 1) {
									break;
								}
								num23 -= num24;
							}
						} else {
							if (num25 == 1) {
								break;
							}
							num23 -= num24;
						}
						num24 /= 2f;
						checked {
							num25 = (short)unchecked(num25 + 1);
						}
					} while (num25 <= 10);
					if (Stress.Fyaypn < num22) {
						ref string reference47 = ref strTraceCW;
						reference47 = reference47 + "    Max net section stress allowed for positive bending: Fya=" + Units.DisplayStress (Stress.Fyaypn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
				}
			}
			if (DSM.UseDSM & (DSM.Mcrlyn > 0f)) {
				Stress.Fyayng = (float)(System.Math.Pow (0.776, 2.0) * (double)DSM.Mcrlyn * (double)num);
				if (Stress.Fyayng < num4) {
					Stress.Fyayng = num4;
				}
				if (Stress.Fyayng > num22) {
					Stress.Fyayng = num22;
				}
				if (CFS.SpecYear ((short)Spec) < 2016 && !flag) {
					Stress.Fyayng = num4;
				}
				Stress.Fyaynn = Stress.Fyayng;
			} else {
				float num23 = num4;
				float num24 = num22 - num4;
				short num25 = 1;
				do {
					effectiveProperties.ResetProp (this, 1);
					effectiveProperties.EffProp (this, 0f, 0f, (0f - Prop.Syl) * num23, 1, (short)Spec);
					if (PropEff.ColdWorkAllowed) {
						Stress.Fyayng = num23;
						if (num25 == 2) {
							break;
						}
						num23 += num24;
					} else {
						if (num25 == 1) {
							break;
						}
						num23 -= num24;
					}
					num24 /= 2f;
					checked {
						num25 = (short)unchecked(num25 + 1);
					}
				} while (num25 <= 10);
				if (Stress.Fyayng < num22) {
					ref string reference48 = ref strTraceCW;
					reference48 = reference48 + "    Max compression stress allowed for negative bending: Fya=" + Units.DisplayStress (Stress.Fyayng, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				}
				Stress.Fyaynn = Stress.Fyayng;
				if ((Prop.An < Prop.A) & (Stress.Fyayng > num4)) {
					num23 = num4;
					num24 = num22 - num4;
					num25 = 1;
					do {
						effectiveProperties.ResetProp (this, 1);
						effectiveProperties.EffProp (this, 0f, 0f, (0f - Prop.Sy) * num23, 1, (short)Spec);
						if (PropEff.ColdWorkAllowed) {
							effectiveProperties.ResetProp (this, 0);
							effectiveProperties.EffProp (this, 0f, 0f, (0f - Prop.Syn) * num23, 0, (short)Spec);
							if (PropEff.ColdWorkAllowed) {
								Stress.Fyaynn = num23;
								if (num25 == 2) {
									break;
								}
								num23 += num24;
							} else {
								if (num25 == 1) {
									break;
								}
								num23 -= num24;
							}
						} else {
							if (num25 == 1) {
								break;
							}
							num23 -= num24;
						}
						num24 /= 2f;
						checked {
							num25 = (short)unchecked(num25 + 1);
						}
					} while (num25 <= 10);
					if (Stress.Fyaynn < num22) {
						ref string reference49 = ref strTraceCW;
						reference49 = reference49 + "    Max net section stress allowed for negative bending: Fya=" + Units.DisplayStress (Stress.Fyaynn, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					}
				}
			}
		}
		strTraceCW += "\r\n";
	}

	internal float DistortionalBucklingLoad (MemberParameters Param)
	{
		string strMsg = string.Empty;
		_ = new TorsionData[1];
		strTraceDB = string.Empty;
		float num = 1000f * Prop.A * Material.Fy [2];
		float result = num;
		string text;
		string text2;
		string text3;
		string text4;
		string text5;
		string text6;
		string text7;
		if (Material.IsStainless ()) {
			text = "ASCE Eq. B-12";
			text2 = "ASCE Eq. B-13";
			text3 = "ASCE Eq. B-18";
			text4 = "ASCE Eq. B-14";
			text5 = "ASCE Eq. B-15";
			text6 = "ASCE Eq. B-16";
			text7 = "ASCE Eq. B-17";
		} else if (CFS.IsSpec2007 ((short)Param.Spec)) {
			text = "Eq. C4.2-5";
			text2 = "Eq. C4.2-10";
			text3 = "Eq. C4.2-13";
			text4 = "Eq. C3.1.4-13";
			text5 = "Eq. C4.2-11";
			text6 = "Eq. C3.1.4-15";
			text7 = "Eq. C4.2-12";
		} else if (CFS.IsSpec2010 ((short)Param.Spec) | CFS.IsSpec2012 ((short)Param.Spec)) {
			text = "Eq. C4.2-5";
			text2 = "Eq. C4.2-6";
			text3 = "Eq. C4.2-9";
			text4 = "Eq. C3.1.4-9";
			text5 = "Eq. C4.2-7";
			text6 = "Eq. C3.1.4-11";
			text7 = "Eq. C4.2-8";
		} else if (CFS.IsSpec2016 ((short)Param.Spec) | CFS.IsSpec2018 ((short)Param.Spec)) {
			text = "Eq. 2.3.1.3-1";
			text2 = "Eq. 2.3.1.3-2";
			text3 = "Eq. 2.3.1.3-7";
			text4 = "Eq. 2.3.1.3-3";
			text5 = "Eq. 2.3.1.3-4";
			text6 = "Eq. 2.3.1.3-5";
			text7 = "Eq. 2.3.1.3-6";
		} else {
			if (!CFS.IsSpec2022 ((short)Param.Spec)) {
				goto IL_1043;
			}
			text = "Eq. 2.3.3.1-1";
			text2 = "Eq. 2.3.3.1-2";
			text3 = "Eq. 2.3.3.1-7";
			text4 = "Eq. 2.3.3.1-3";
			text5 = "Eq. 2.3.3.1-4";
			text6 = "Eq. 2.3.3.1-5";
			text7 = "Eq. 2.3.3.1-6";
		}
		float num2 = Material.Eo [2];
		float num3 = Material.Eo [5];
		float num4 = 0f;
		short num5 = nPart;
		checked {
			bool blnChg = default(bool);
			for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
				Part part = Part [num6];
				if (!part.Closed) {
					float thickness = part.Thickness;
					float num7 = (float)System.Math.Sqrt (((double)((part.Ix + part.Iy) / 2f) - System.Math.Sqrt (System.Math.Pow (part.Iy - part.Ix, 2.0) / 4.0 + System.Math.Pow (part.Ixy, 2.0))) / (double)part.A);
					short num8 = 1;
					do {
						short num9;
						short num10;
						if (num8 > 0) {
							num9 = 1;
							num10 = part.nElem;
						} else {
							num9 = part.nElem;
							num10 = 1;
						}
						short num11 = 0;
						short num12 = num9;
						short num13 = num10;
						short num14 = num8;
						short num15 = num12;
						while (unchecked(((short)(num14 >> 15) ^ num15) <= ((short)(num14 >> 15) ^ num13))) {
							if (num11 > 0) {
								float num16 = part.Element [num15].Len;
								if (unchecked(part.Centerline && num15 > 1)) {
									num16 = (float)((double)num16 + 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num15].Arc / 2f)));
								}
								if (part.Centerline & (num15 < part.nElem)) {
									num16 = (float)((double)num16 + 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num15 + 1].Arc / 2f)));
								}
								Part part2 = Part [num6].Clone ();
								part2.nElem = (byte)(System.Math.Abs ((short)unchecked(num11 - num9)) + 1);
								part2.iXPosition = 1;
								part2.XPosition = 0f;
								part2.iYPosition = 1;
								part2.YPosition = 0f;
								float num21;
								float num22;
								if (num8 > 0) {
									float num17 = (float)((double)part.Element [num15].Ang + System.Math.PI / 2.0);
									short num18 = num9;
									short num19 = num11;
									for (short num20 = num18; num20 <= num19; num20 = (short)unchecked(num20 + 1)) {
										part2.Element [(short)unchecked(num20 - num9) + 1].Len = part.Element [num20].Len;
										part2.Element [(short)unchecked(num20 - num9) + 1].Ang = part.Element [num20].Ang - num17;
										part2.Element [(short)unchecked(num20 - num9) + 1].Rad = part.Element [num20].Rad;
										part2.Element [(short)unchecked(num20 - num9) + 1].Hole = 0f;
									}
									if (!part.Centerline & (num11 < part.nElem)) {
										ref float len = ref part2.Element [part2.nElem].Len;
										len = (float)((double)len - 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num11 + 1].Arc / 2f)));
									}
									num21 = part.XPosition + part.Element [num11].X1 - part.Xcg;
									num22 = part.YPosition + part.Element [num11].Y1 - part.Ycg;
								} else {
									float num17 = (float)((double)part.Element [num15].Ang - System.Math.PI / 2.0);
									short num23 = num11;
									short num24 = num9;
									for (short num20 = num23; num20 <= num24; num20 = (short)unchecked(num20 + 1)) {
										part2.Element [(short)unchecked(num20 - num11) + 1].Len = part.Element [num20].Len;
										part2.Element [(short)unchecked(num20 - num11) + 1].Ang = part.Element [num20].Ang - num17;
										part2.Element [(short)unchecked(num20 - num11) + 1].Rad = part.Element [num20].Rad;
										part2.Element [(short)unchecked(num20 - num11) + 1].Hole = 0f;
									}
									if (unchecked(!part.Centerline && num11 > 1)) {
										ref float len2 = ref part2.Element [1].Len;
										len2 = (float)((double)len2 - 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num11].Arc / 2f)));
									}
									num21 = part.XPosition + part.Element [num11].X0 - part.Xcg;
									num22 = part.YPosition + part.Element [num11].Y0 - part.Ycg;
								}
								num4 = 0f;
								switch (Param.iBrcFlg) {
								case Flanges.flgTop:
									if (Ymax - num22 < part.Thickness) {
										num4 = Param.Kf;
									}
									break;
								case Flanges.flgBottom:
									if (num22 - Ymin < part.Thickness) {
										num4 = Param.Kf;
									}
									break;
								case Flanges.flgLeft:
									if (num21 - Xmax < part.Thickness) {
										num4 = Param.Kf;
									}
									break;
								case Flanges.flgRight:
									if (Xmax - num21 < part.Thickness) {
										num4 = Param.Kf;
									}
									break;
								}
								part2.Geometry (ref blnChg, ref strMsg);
								part2.CalcProperties ();
								float xo = part2.Xo;
								float yo = part2.Yo;
								float cw = part2.Cw;
								float j = part2.J;
								float a = part2.A;
								float ixy = part2.Ixy;
								float ix = part2.Ix;
								float iy = part2.Iy;
								float num25 = Conversions.ToSingle (Interaction.IIf (num8 < 0, part2.Element [1].X0 - part2.Xcg, part2.Element [part2.nElem].X1 - part2.Xcg));
								if (a > part.A / 2f || System.Math.Sqrt ((iy + ix) / a) > (double)(2f * num7)) {
									break;
								}
								float num26 = (float)(System.Math.PI * (double)num16 * System.Math.Pow (5.46 / System.Math.Pow (thickness * num16, 3.0) * ((double)cw + (double)ix * System.Math.Pow (xo - num25, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))), 0.25));
								float num27 = num26;
								if (Param.Lm < num27) {
									num27 = Param.Lm;
								}
								float num28 = num27;
								if (HoleSpacing < num28) {
									num28 = HoleSpacing;
								}
								if (num28 < HoleLength) {
									num28 = HoleLength;
								}
								float num29 = ((!((part.Element [num15].Hole > 0f) & ((CFS.SpecYear (unchecked((short)Param.Spec)) >= 2016) | Material.IsStainless ()))) ? thickness : ((float)((double)thickness * System.Math.Pow (1f - HoleLength / num28, 0.333))));
								if (num27 > thickness) {
									float num30 = (float)(System.Math.Pow (System.Math.PI / (double)num27, 4.0) * (double)num2 * ((double)cw + (double)ix * System.Math.Pow (xo - num25, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))) + System.Math.Pow (System.Math.PI / (double)num27, 2.0) * (double)num3 * (double)j);
									float num31 = (float)((double)num2 * System.Math.Pow (num29, 3.0) / 10.92 * (double)(2f / num16));
									float num32 = (float)(System.Math.Pow (System.Math.PI / (double)num27, 2.0) * ((double)(ix + iy) + (double)a * (System.Math.Pow (num25, 2.0) + System.Math.Pow (yo, 2.0) - (double)(2f * yo * (xo - num25) * ixy / iy) + System.Math.Pow (xo - num25, 2.0) * System.Math.Pow (ixy / iy, 2.0))));
									float num33 = (float)(System.Math.Pow (System.Math.PI / (double)num27, 2.0) * (double)num29 * System.Math.Pow (num16, 3.0) / 60.0);
									float num34 = (num30 + num31 + num4) / (num32 + num33);
									float num35 = Prop.A * num34;
									if (num35 < num) {
										strTraceDB = "  Distortional buckling for " + part.Name + " elements ";
										ref string reference = ref strTraceDB;
										ref string reference2 = ref reference;
										reference = reference2 + Conversions.ToString (CFS.Min (num9, num11)) + " to " + Conversions.ToString (CFS.Max (num9, num11)) + "\r\n";
										ref string reference3 = ref strTraceDB;
										reference2 = ref reference3;
										reference3 = reference2 + "    Af=" + Units.DisplayLen2 (a, 0, blnShowUnit: true, "", 0, 0) + ", Ixf=" + Units.DisplayLen4 (ix, 0, blnShowUnit: true, "", 0, 0) + ", Iyf=" + Units.DisplayLen4 (iy, 0, blnShowUnit: true, "", 0, 0) + ", Ixyf=" + Units.DisplayLen4 (ixy, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference4 = ref strTraceDB;
										reference2 = ref reference4;
										reference4 = reference2 + "    xof=" + Units.DisplayLen1 (xo, 0, blnShowUnit: true, "", 0, 0) + ", yof=" + Units.DisplayLen1 (yo, 0, blnShowUnit: true, "", 0, 0) + ", Cwf=" + Units.DisplayLen6 (cw, 0, blnShowUnit: true, "", 0, 0) + ", Jf=" + Units.DisplayLen4 (j, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference5 = ref strTraceDB;
										reference2 = ref reference5;
										reference5 = reference2 + "    hxf=" + Units.DisplayLen1 (num25, 0, blnShowUnit: true, "", 0, 0) + ", ho=" + Units.DisplayLen1 (num16, 0, blnShowUnit: true, "", 0, 0) + ", tweb=" + Units.DisplayLen1 (num29, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference6 = ref strTraceDB;
										reference2 = ref reference6;
										reference6 = reference2 + "    Lcrd=" + Units.DisplayLen1 (num26, 0, blnShowUnit: true, "", 0, 0) + "\t" + text3 + "\r\n";
										if (num27 < num26) {
											ref string reference7 = ref strTraceDB;
											reference7 = reference7 + "    L=" + Units.DisplayLen1 (num27, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										}
										ref string reference8 = ref strTraceDB;
										reference2 = ref reference8;
										reference8 = reference2 + "    kφfe=" + Units.DisplayForce (num30, 0, blnShowUnit: true, "", 0, 0) + "\t" + text4 + "\r\n";
										ref string reference9 = ref strTraceDB;
										reference2 = ref reference9;
										reference9 = reference2 + "    kφwe=" + Units.DisplayForce (num31, 0, blnShowUnit: true, "", 0, 0) + "\t" + text5 + "\r\n";
										ref string reference10 = ref strTraceDB;
										reference10 = reference10 + "    kφ=" + Units.DisplayForce (num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference11 = ref strTraceDB;
										reference2 = ref reference11;
										reference11 = reference2 + "    kφfg=" + Units.DisplayLen2 (num32, 0, blnShowUnit: true, "", 0, 0) + "\t" + text6 + "\r\n";
										ref string reference12 = ref strTraceDB;
										reference2 = ref reference12;
										reference12 = reference2 + "    kφwg=" + Units.DisplayLen2 (num33, 0, blnShowUnit: true, "", 0, 0) + "\t" + text7 + "\r\n";
										ref string reference13 = ref strTraceDB;
										reference2 = ref reference13;
										reference13 = reference2 + "    Fcrd=" + Units.DisplayStress (num34, 0, blnShowUnit: true, "", 0, 0) + "\t" + text2 + "\r\n";
										ref string reference14 = ref strTraceDB;
										reference2 = ref reference14;
										reference14 = reference2 + "    Pcrd=" + Units.DisplayForce (num35, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
										num = num35;
									}
								}
								num11 = 0;
							}
							if (num15 != num9) {
								num11 = num15;
							}
							num15 = (short)unchecked(num15 + num14);
						}
						num8 = (short)unchecked(num8 + -2);
					} while (num8 >= -1);
				}
				part = null;
			}
			result = num;
			goto IL_1043;
		}
		IL_1043:
		return result;
	}

	internal float DistortionalBucklingMoment (MemberParameters Param, byte intFlg, float M1M2 = -1f)
	{
		string strMsg = string.Empty;
		_ = new TorsionData[1];
		strTraceDB = string.Empty;
		float num = (float)(1000.0 * CFS.Max (Prop.Sx, Prop.Sy) * (double)Material.Fy [2]);
		float result = num;
		string text;
		string text2;
		string text3;
		string text4;
		string text5;
		string text6;
		string text7;
		string text8;
		string text9;
		string text10;
		string text11;
		string text12;
		if (Material.IsStainless ()) {
			text = "ASCE Eq. B-33";
			text2 = "ASCE Eq. B-34";
			text3 = "ASCE Eq. B-36";
			text4 = "ASCE Eq. B-14";
			text5 = "ASCE Eq. B-37";
			text6 = "ASCE Eq. B-16";
			text7 = "ASCE Eq. B-38";
			text8 = "S100-22 Eq. 2.3.3.2-8";
			text9 = "ASCE Eq. B-14";
			text10 = "S100-22 Eq. 2.3.3.2-9";
			text11 = "S100-22 Eq. 2.3.3.2-10";
			text12 = "Analytical";
		} else if (CFS.IsSpec2007 ((short)Param.Spec)) {
			text = "Eq. C3.1.4-5";
			text2 = "Eq. C3.1.4-10";
			text3 = "Eq. C3.1.4-12";
			text4 = "Eq. C3.1.4-13";
			text5 = "Eq. C3.1.4-14";
			text6 = "Eq. C3.1.4-15";
			text7 = "Eq. C3.1.4-16";
			text8 = "S100-22 Eq. 2.3.3.2-8";
			text9 = "Eq. C3.1.4-13";
			text10 = "S100-22 Eq. 2.3.3.2-9";
			text11 = "S100-22 Eq. 2.3.3.2-10";
			text12 = "Analytical";
		} else if (CFS.IsSpec2010 ((short)Param.Spec) | CFS.IsSpec2012 ((short)Param.Spec)) {
			text = "Eq. C3.1.4-5";
			text2 = "Eq. C3.1.4-6";
			text3 = "Eq. C3.1.4-8";
			text4 = "Eq. C3.1.4-9";
			text5 = "Eq. C3.1.4-10";
			text6 = "Eq. C3.1.4-11";
			text7 = "Eq. C3.1.4-12";
			text8 = "S100-22 Eq. 2.3.3.2-8";
			text9 = "Eq. C3.1.4-9";
			text10 = "S100-22 Eq. 2.3.3.2-9";
			text11 = "S100-22 Eq. 2.3.3.2-10";
			text12 = "Analytical";
		} else if (CFS.IsSpec2016 ((short)Param.Spec) | CFS.IsSpec2018 ((short)Param.Spec)) {
			text = "Eq. 2.3.3.3-1";
			text2 = "Eq. 2.3.3.3-2";
			text3 = "Eq. 2.3.3.3-4";
			text4 = "Eq. 2.3.1.3-3";
			text5 = "Eq. 2.3.3.3-5";
			text6 = "Eq. 2.3.1.3-5";
			text7 = "Eq. 2.3.3.3-6";
			text8 = "S100-22 Eq. 2.3.3.2-8";
			text9 = "Eq. 2.3.1.3-3";
			text10 = "S100-22 Eq. 2.3.3.2-9";
			text11 = "S100-22 Eq. 2.3.3.2-10";
			text12 = "Analytical";
		} else {
			if (!CFS.IsSpec2022 ((short)Param.Spec)) {
				goto IL_1c06;
			}
			text = "Eq. 2.3.3.2-1";
			text2 = "Eq. 2.3.3.2-2";
			text3 = "Eq. 2.3.3.2-4";
			text4 = "Eq. 2.3.3.1-3";
			text5 = "Eq. 2.3.3.2-5";
			text6 = "Eq. 2.3.3.2-6";
			text7 = "Eq. 2.3.3.2-7";
			text8 = "Eq. 2.3.3.2-8";
			text9 = "Eq. 2.3.3.1-3";
			text10 = "Eq. 2.3.3.2-9";
			text11 = "Eq. 2.3.3.2-10";
			text12 = "Analytical";
		}
		float num2 = Material.Eo [2];
		float num3 = Material.Eo [5];
		float num4 = (((uint)intFlg != (uint)Param.iBrcFlg) ? 0f : Param.Kf);
		float num9 = default(float);
		float num6 = default(float);
		float num7 = default(float);
		float num8 = default(float);
		float num5 = default(float);
		switch (intFlg) {
		case 2:
			num9 = 1f;
			num6 = Ymax - Prop.Ycg;
			num7 = Prop.Sxt;
			num8 = (float)System.Math.PI / 2f;
			break;
		case 1:
			num9 = -1f;
			num6 = Prop.Ycg - Ymin;
			num7 = Prop.Sxb;
			num8 = -(float)System.Math.PI / 2f;
			break;
		case 3:
			num5 = -1f;
			num6 = Prop.Xcg - Xmin;
			num7 = Prop.Syl;
			num8 = (float)System.Math.PI;
			break;
		case 4:
			num5 = 1f;
			num6 = Xmax - Prop.Xcg;
			num7 = Prop.Syr;
			num8 = 0f;
			break;
		}
		short num10 = nPart;
		checked {
			bool blnChg = default(bool);
			float num36 = default(float);
			float num49 = default(float);
			float num50 = default(float);
			float num51 = default(float);
			float num52 = default(float);
			float num53 = default(float);
			for (short num11 = 1; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
				Part part = Part [num11];
				if (!part.Closed) {
					float thickness = part.Thickness;
					float num12 = (float)System.Math.Sqrt (((double)((part.Ix + part.Iy) / 2f) - System.Math.Sqrt (System.Math.Pow (part.Iy - part.Ix, 2.0) / 4.0 + System.Math.Pow (part.Ixy, 2.0))) / (double)part.A);
					short num13 = 1;
					do {
						short num14;
						short num15;
						if (num13 > 0) {
							num14 = 1;
							num15 = (short)(unchecked((int)part.nElem) - 1);
						} else {
							num14 = part.nElem;
							num15 = 2;
						}
						short num16 = 0;
						short num17 = num14;
						short num18 = num15;
						short num19 = num13;
						short num20 = num17;
						while (unchecked(((short)(num19 >> 15) ^ num20) <= ((short)(num19 >> 15) ^ num18))) {
							float num21 = part.XPosition - part.Xcg + part.Element [num20].X0 - Prop.Xcg;
							float num22 = part.YPosition - part.Ycg + part.Element [num20].Y0 - Prop.Ycg;
							float num23 = part.XPosition - part.Xcg + part.Element [num20].X1 - Prop.Xcg;
							float num24 = part.YPosition - part.Ycg + part.Element [num20].Y1 - Prop.Ycg;
							float A = num9 * num22 + num5 * num21;
							float B = num9 * num24 + num5 * num23;
							unchecked {
								if (num20 == num14 && (A < 0f || B < 0f)) {
									break;
								}
								float num25 = Conversions.ToSingle (Interaction.IIf (num13 > 0, A, B));
								if (A < B) {
									CFS.Swap (ref A, ref B);
								}
								if ((double)System.Math.Abs (A - B) < 0.0001 * (double)num6) {
									B = A;
								}
								if (num16 > 0) {
									float num26 = part.Element [num20].Len;
									if (part.Centerline && num20 > 1) {
										num26 = (float)((double)num26 + 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num20].Arc / 2f)));
									}
									Part part2;
									float num28;
									float xo;
									float yo;
									float cw;
									float j;
									float a;
									float ixy;
									float ix;
									float iy;
									float num34;
									float num37;
									float num38;
									checked {
										if (part.Centerline & (num20 < part.nElem)) {
											num26 = (float)((double)num26 + 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num20 + 1].Arc / 2f)));
										}
										part2 = Part [num11].Clone ();
										part2.nElem = (byte)(System.Math.Abs ((short)unchecked(num16 - num14)) + 1);
										part2.iXPosition = 1;
										part2.XPosition = 0f;
										part2.iYPosition = 1;
										part2.YPosition = 0f;
										float num27;
										if (num13 > 0) {
											num27 = (float)((double)part.Element [num16].Ang - System.Math.PI);
											num28 = (float)((double)part.Element [num20].Ang + System.Math.PI / 2.0);
											short num29 = num14;
											short num30 = num16;
											for (short num31 = num29; num31 <= num30; num31 = (short)unchecked(num31 + 1)) {
												part2.Element [(short)unchecked(num31 - num14) + 1].Len = part.Element [num31].Len;
												part2.Element [(short)unchecked(num31 - num14) + 1].Ang = part.Element [num31].Ang - num28;
												part2.Element [(short)unchecked(num31 - num14) + 1].Rad = part.Element [num31].Rad;
												part2.Element [(short)unchecked(num31 - num14) + 1].Hole = 0f;
											}
											if (!part.Centerline & (num16 < part.nElem)) {
												ref float len = ref part2.Element [part2.nElem].Len;
												len = (float)((double)len - 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num16 + 1].Arc / 2f)));
											}
										} else {
											num27 = part.Element [num16].Ang;
											num28 = (float)((double)part.Element [num20].Ang - System.Math.PI / 2.0);
											short num32 = num16;
											short num33 = num14;
											for (short num31 = num32; num31 <= num33; num31 = (short)unchecked(num31 + 1)) {
												part2.Element [(short)unchecked(num31 - num16) + 1].Len = part.Element [num31].Len;
												part2.Element [(short)unchecked(num31 - num16) + 1].Ang = part.Element [num31].Ang - num28;
												part2.Element [(short)unchecked(num31 - num16) + 1].Rad = part.Element [num31].Rad;
												part2.Element [(short)unchecked(num31 - num16) + 1].Hole = 0f;
											}
											if (unchecked(!part.Centerline && num16 > 1)) {
												ref float len2 = ref part2.Element [1].Len;
												len2 = (float)((double)len2 - 0.5 * (double)thickness * System.Math.Tan (System.Math.Abs (part.Element [num16].Arc / 2f)));
											}
										}
										part2.Geometry (ref blnChg, ref strMsg);
										part2.CalcProperties ();
										xo = part2.Xo;
										yo = part2.Yo;
										cw = part2.Cw;
										j = part2.J;
										a = part2.A;
										ixy = part2.Ixy;
										ix = part2.Ix;
										iy = part2.Iy;
										num34 = Conversions.ToSingle (Interaction.IIf (num13 < 0, part2.Element [1].X0 - part2.Xcg, part2.Element [part2.nElem].X1 - part2.Xcg));
										float num35 = Conversions.ToSingle (Interaction.IIf (num13 < 0, part2.Element [1].Wid, part2.Element [part2.nElem].Wid));
										Conversions.ToSingle (Interaction.IIf (num34 < 0f, part2.Xright, 0f - part2.Xleft));
										num37 = (float)((double)num36 - (double)num35 * System.Math.Cos (num27 - num8));
										if (a > part.A / 2f || System.Math.Sqrt ((iy + ix) / a) > (double)(2f * num12)) {
											break;
										}
										num38 = 2f * num;
									}
									string text13;
									string text14;
									string text15;
									string text16;
									string text17;
									float num44;
									float num45;
									float num48;
									if ((num37 < 0f) | (System.Math.Abs (System.Math.Cos (num28 - num8)) > 0.71)) {
										part2.Rotate (num28 - num8);
										part2.Geometry (ref blnChg, ref strMsg);
										float num39;
										float num40;
										if (Operators.ConditionalCompareObjectLess (Interaction.IIf (num13 < 0, part2.Element [1].X0, part2.Element [part2.nElem].X1), part2.Xcg, TextCompare: false)) {
											num39 = num37 + part2.Xleft + part2.Xright;
											num40 = num37 + part2.Xleft;
										} else {
											num39 = num37 - part2.Xleft - part2.Xright;
											num40 = num37 - part2.Xright;
										}
										if (num39 <= 0f) {
											break;
										}
										if ((double)System.Math.Abs (num39 - num37) < 0.0001 * (double)num6) {
											num37 = num39;
										}
										float num41 = (num39 - num37) / num39;
										float num42 = num40 / num39;
										text13 = text8;
										text14 = text9;
										text15 = text10;
										text16 = text11;
										text17 = text12;
										float num43 = (float)(3.5 * System.Math.Sqrt ((double)(iy / a) + System.Math.Pow (num34, 2.0)));
										if (num37 > 0f) {
											num43 = num26;
										}
										num44 = (float)(System.Math.PI * (double)num43 * System.Math.Pow (5.46 / System.Math.Pow (thickness * num43, 3.0) * ((double)cw + (double)ix * System.Math.Pow (xo - num34, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))) + 1.0 / 120.0, 0.25));
										num45 = num44;
										if (Param.Lm < num45) {
											num45 = Param.Lm;
										}
										float num46 = num45;
										if (HoleSpacing < num46) {
											num46 = HoleSpacing;
										}
										if (num46 < HoleLength) {
											num46 = HoleLength;
										}
										float num47 = (float)(1.0 + 0.4 * System.Math.Pow (num45 / Param.Lm, 0.7) * System.Math.Pow (1f + M1M2, 0.7));
										num48 = ((!((part.Element [num20].Hole > 0f) & ((CFS.SpecYear ((short)Param.Spec) >= 2016) | Material.IsStainless ()))) ? thickness : ((float)((double)thickness * System.Math.Pow (1f - HoleLength / num46, 0.333))));
										if (num45 > thickness && (double)num39 > 0.0001 * (double)num6) {
											num49 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 4.0) * (double)num2 * ((double)cw + (double)ix * System.Math.Pow (xo - num34, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))) + System.Math.Pow (System.Math.PI / (double)num45, 2.0) * (double)num3 * (double)j);
											num50 = (float)((double)num2 * System.Math.Pow (num48, 3.0) / 10.92 * (double)(2f / num43) * (1.0 + System.Math.Pow (System.Math.PI * (double)num43 / (double)num45, 2.0) / 6.0 + System.Math.Pow (System.Math.PI * (double)num43 / (double)num45, 4.0) / 120.0));
											num51 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 2.0) * ((double)(ix + iy) + (double)a * (System.Math.Pow (num34, 2.0) + System.Math.Pow (yo, 2.0) - (double)(2f * yo * (xo - num34) * ixy / iy))) * (double)num42 + System.Math.Pow (System.Math.PI / (double)num45, 2.0) * (double)iy * (double)num41);
											num52 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 2.0) * (double)num48 * System.Math.Pow (num43, 3.0) / 60.0 * (double)(1f - num41));
											if (num37 <= 0f) {
												num52 = 0f;
												text17 = string.Empty;
											}
											if (num51 + num52 > 0f) {
												num53 = num47 * (num49 + num50 + num4) / (num51 + num52);
												num38 = num7 * num53 * (num6 / num39);
											}
										}
									} else {
										text13 = text3;
										text14 = text4;
										text15 = text5;
										text16 = text6;
										text17 = text7;
										num44 = (float)(System.Math.PI * (double)num26 * System.Math.Pow (3.64 / System.Math.Pow (thickness * num26, 3.0) * ((double)cw + (double)ix * System.Math.Pow (xo - num34, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))) + 1.0 / 720.0, 0.25));
										num45 = num44;
										if (Param.Lm < num45) {
											num45 = Param.Lm;
										}
										float num46 = num45;
										if (HoleSpacing < num46) {
											num46 = HoleSpacing;
										}
										if (num46 < HoleLength) {
											num46 = HoleLength;
										}
										float num47 = (float)(1.0 + 0.4 * System.Math.Pow (num45 / Param.Lm, 0.7) * System.Math.Pow (1f + M1M2, 0.7));
										num48 = ((!((part.Element [num20].Hole > 0f) & ((CFS.SpecYear ((short)Param.Spec) >= 2016) | Material.IsStainless ()))) ? thickness : ((float)((double)thickness * System.Math.Pow (1f - HoleLength / num46, 0.333))));
										if (num45 > thickness && (double)A > 0.0001 * (double)num6) {
											float num54 = (A - B) / A;
											num49 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 4.0) * (double)num2 * ((double)cw + (double)ix * System.Math.Pow (xo - num34, 2.0) * (1.0 - System.Math.Pow (ixy, 2.0) / (double)(ix * iy))) + System.Math.Pow (System.Math.PI / (double)num45, 2.0) * (double)num3 * (double)j);
											if ((CFS.SpecYear ((short)Param.Spec) < 2022) | Material.IsStainless ()) {
												num50 = (float)((double)num2 * System.Math.Pow (num48, 3.0) / 10.92 * ((double)(3f / num26) + System.Math.Pow (System.Math.PI / (double)num45, 2.0) * 19.0 * (double)num26 / 60.0 + System.Math.Pow (System.Math.PI / (double)num45, 4.0) * System.Math.Pow (num26, 3.0) / 240.0));
												num51 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 2.0) * ((double)a * (System.Math.Pow (xo - num34, 2.0) * System.Math.Pow (ixy / iy, 2.0) - (double)(2f * yo * (xo - num34) * (ixy / iy)) + System.Math.Pow (num34, 2.0) + System.Math.Pow (yo, 2.0)) + (double)ix + (double)iy));
												num52 = (float)((double)(num26 * num48) * 9.869604401089358 / 13440.0 * (((double)(45360f * (1f - num54) + 62160f) * System.Math.Pow (num45 / num26, 2.0) + 4421.5827716880322 + System.Math.Pow (num26 / num45, 2.0) * (double)(53f + 3f * (1f - num54)) * 97.409091034002415) / (System.Math.Pow (System.Math.PI, 4.0) + 276.348923230502 * System.Math.Pow (num45 / num26, 2.0) + 420.0 * System.Math.Pow (num45 / num26, 4.0))));
											} else {
												num50 = (float)((double)num2 * System.Math.Pow (num48, 3.0) / 10.92 * (double)(3f / num26) * (1.0 + 2.0 * System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 2.0) / 15.0 + System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 4.0) / 720.0));
												num51 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 2.0) * ((double)(ix + iy) + (double)a * (System.Math.Pow (num34, 2.0) + System.Math.Pow (yo, 2.0) - (double)(2f * yo * (xo - num34) * ixy / iy))));
												num52 = (float)(System.Math.Pow (System.Math.PI / (double)num45, 2.0) * (double)num48 * System.Math.Pow (num26, 3.0) / 240.0 * ((double)(1110f + 810f * (1f - num54)) + 8.0 * System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 2.0) + System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 4.0)) / (420.0 + 28.0 * System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 2.0) + System.Math.Pow (System.Math.PI * (double)num26 / (double)num45, 4.0)));
											}
											if (num51 + num52 > 0f) {
												num53 = num47 * (num49 + num50 + num4) / (num51 + num52);
												num38 = num7 * num53 * (num6 / num37);
											}
										}
									}
									if (num38 < num) {
										strTraceDB = "  Distortional buckling for " + part.Name + " elements ";
										ref string reference = ref strTraceDB;
										ref string reference2 = ref reference;
										reference = reference2 + Conversions.ToString (CFS.Min (num14, num16)) + " to " + Conversions.ToString (CFS.Max (num14, num16)) + "\r\n";
										ref string reference3 = ref strTraceDB;
										reference2 = ref reference3;
										reference3 = reference2 + "    Af=" + Units.DisplayLen2 (a, 0, blnShowUnit: true, "", 0, 0) + ", Ixf=" + Units.DisplayLen4 (ix, 0, blnShowUnit: true, "", 0, 0) + ", Iyf=" + Units.DisplayLen4 (iy, 0, blnShowUnit: true, "", 0, 0) + ", Ixyf=" + Units.DisplayLen4 (ixy, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference4 = ref strTraceDB;
										reference2 = ref reference4;
										reference4 = reference2 + "    xof=" + Units.DisplayLen1 (xo, 0, blnShowUnit: true, "", 0, 0) + ", yof=" + Units.DisplayLen1 (yo, 0, blnShowUnit: true, "", 0, 0) + ", Cwf=" + Units.DisplayLen6 (cw, 0, blnShowUnit: true, "", 0, 0) + ", Jf=" + Units.DisplayLen4 (j, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference5 = ref strTraceDB;
										reference2 = ref reference5;
										reference5 = reference2 + "    hxf=" + Units.DisplayLen1 (num34, 0, blnShowUnit: true, "", 0, 0) + ", ho=" + Units.DisplayLen1 (num26, 0, blnShowUnit: true, "", 0, 0) + ", tweb=" + Units.DisplayLen1 (num48, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference6 = ref strTraceDB;
										reference2 = ref reference6;
										reference6 = reference2 + "    Lcrd=" + Units.DisplayLen1 (num44, 0, blnShowUnit: true, "", 0, 0) + "\t" + text13 + "\r\n";
										if (num45 < num44) {
											ref string reference7 = ref strTraceDB;
											reference7 = reference7 + "    L=" + Units.DisplayLen1 (num45, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										}
										ref string reference8 = ref strTraceDB;
										reference2 = ref reference8;
										reference8 = reference2 + "    kφfe=" + Units.DisplayForce (num49, 0, blnShowUnit: true, "", 0, 0) + "\t" + text14 + "\r\n";
										ref string reference9 = ref strTraceDB;
										reference2 = ref reference9;
										reference9 = reference2 + "    kφwe=" + Units.DisplayForce (num50, 0, blnShowUnit: true, "", 0, 0) + "\t" + text15 + "\r\n";
										ref string reference10 = ref strTraceDB;
										reference10 = reference10 + "    kφ=" + Units.DisplayForce (num4, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
										ref string reference11 = ref strTraceDB;
										reference2 = ref reference11;
										reference11 = reference2 + "    kφfg=" + Units.DisplayLen2 (num51, 0, blnShowUnit: true, "", 0, 0) + "\t" + text16 + "\r\n";
										ref string reference12 = ref strTraceDB;
										reference2 = ref reference12;
										reference12 = reference2 + "    kφwg=" + Units.DisplayLen2 (num52, 0, blnShowUnit: true, "", 0, 0) + "\t" + text17 + "\r\n";
										ref string reference13 = ref strTraceDB;
										reference2 = ref reference13;
										reference13 = reference2 + "    Fcrd=" + Units.DisplayStress (num53, 0, blnShowUnit: true, "", 0, 0) + "\t" + text2 + "\r\n";
										ref string reference14 = ref strTraceDB;
										reference2 = ref reference14;
										reference14 = reference2 + "    Mcrd=" + Units.DisplayMoment (num38, 0, blnShowUnit: true, "", 0, 0) + "\t" + text + "\r\n";
										num = num38;
									}
									if (num37 < 0f) {
										break;
									}
									num16 = 0;
								}
								if (num20 != num14) {
									num16 = num20;
									num36 = num25;
								}
							}
							num20 = (short)unchecked(num20 + num19);
						}
						num13 = (short)unchecked(num13 + -2);
					} while (num13 >= -1);
				}
				part = null;
			}
			result = num;
			goto IL_1c06;
		}
		IL_1c06:
		return result;
	}

	internal float MaxStress (float P, float Mx, float My, bool blnNet = false)
	{
		float num;
		float num3;
		float num4;
		if (blnNet) {
			num = Prop.An;
			float num2 = (float)((double)(Prop.Ixn * Prop.Iyn) - System.Math.Pow (Prop.Ixyn, 2.0));
			num3 = (Mx * Prop.Iyn - My * Prop.Ixyn) / num2;
			num4 = (My * Prop.Ixn - Mx * Prop.Ixyn) / num2;
		} else {
			num = Prop.A;
			float num2 = (float)((double)(Prop.Ix * Prop.Iy) - System.Math.Pow (Prop.Ixy, 2.0));
			num3 = (Mx * Prop.Iy - My * Prop.Ixy) / num2;
			num4 = (My * Prop.Ix - Mx * Prop.Ixy) / num2;
		}
		int num5 = nPart;
		checked {
			float num9 = default(float);
			for (int i = 1; i <= num5; i++) {
				float num6;
				float num7;
				if (blnNet) {
					num6 = Part [i].XPosition - Part [i].Xcgn - Prop.Xcgn;
					num7 = Part [i].YPosition - Part [i].Ycgn - Prop.Ycgn;
				} else {
					num6 = Part [i].XPosition - Part [i].Xcg - Prop.Xcg;
					num7 = Part [i].YPosition - Part [i].Ycg - Prop.Ycg;
				}
				int nElem = Part [i].nElem;
				for (int j = 1; j <= nElem; j++) {
					ref Element reference = ref Part [i].Element [j];
					float num8 = P / num + num3 * (num7 + reference.Y0) + num4 * (num6 + reference.X0);
					if (System.Math.Abs (num8) > System.Math.Abs (num9)) {
						num9 = num8;
					}
					num8 = P / num + num3 * (num7 + reference.Y1) + num4 * (num6 + reference.X1);
					if (System.Math.Abs (num8) > System.Math.Abs (num9)) {
						num9 = num8;
					}
				}
			}
			return num9;
		}
	}
}
