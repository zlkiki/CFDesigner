// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using My;

namespace RSG.CFS;

[StandardModule]
internal sealed class CFS
{
	public enum LicenseTypes : short
	{
		None = 0,
		Sublicense = 4,
		Semaphore = 5,
		SingleUser = 6
	}

	public struct UserInfo
	{
		public string Name;

		public string Company;

		public string Address1;

		public string Address2;

		public string Email;

		public string Phone;

		public string Fax;

		public UserInfo (string strName)
		{
			this = default(UserInfo);
			Name = strName;
			Company = string.Empty;
			Address1 = string.Empty;
			Address2 = string.Empty;
			Email = string.Empty;
			Phone = string.Empty;
			Fax = string.Empty;
		}
	}

	public const short Version = 1400;

	public const short ReportVersion = 1400;

	public static string strAppPath;

	public const string CFS_REG = "Software\\RSG Software, Inc.\\CFS\\";

	public const string CFS_HLP = "CFS.chm";

	public const string CFS_MTL = "CFS14.mtl";

	public static Section[] Sections = new Section[1];

	public static Section[,] SctUndo = new Section[10, 1];

	public static Analysis[] Analyses = new Analysis[1];

	public static Analysis[,] AnlUndo = new Analysis[10, 1];

	public static Thickness[] Thicknesses = new Thickness[1];

	public static MaterialType[] Materials = new MaterialType[1];

	public static MaterialType MaterialDefault;

	public static LoadCombination[] UserComb;

	public static short intUserCombs;

	public static bool blnColdWork;

	public static bool blnReserve;

	public static short intSctNow = 0;

	public static byte intSctNew;

	public static short intSctTabNow;

	public static byte intAnlNow;

	public static byte intAnlNew;

	public static short intAnlTabNow;

	public static byte intSpecNow = 37;

	public static bool blnBucklingTheory;

	public static short iThickness = 0;

	public static short iMaterial = 0;

	public static string strTrace;

	public static bool blnTraceStrength;

	public static bool blnTraceMemberChk;

	public static bool blnTraceWebCrip;

	public static bool blnTraceEffProp;

	public static bool blnTraceColdWork;

	public const byte vbShiftMask = 1;

	public const byte vbCtrlMask = 2;

	public const byte vbAltMask = 4;

	public const byte nThicknessMax = byte.MaxValue;

	public const byte nElemMax = byte.MaxValue;

	public const byte nPartMax = byte.MaxValue;

	public const byte nBeamMax = byte.MaxValue;

	public const byte nSupMax = byte.MaxValue;

	public const byte nLdgMax = byte.MaxValue;

	public const byte nLoadMax = byte.MaxValue;

	public const byte nCombMax = byte.MaxValue;

	public const byte nLFMax = byte.MaxValue;

	public const byte iUndoMax = 9;

	public const float ThicknessMin = 0.001f;

	public const float ThicknessMax = 1f;

	public const float DefRadMin = 0f;

	public const float DefRadMax = 10f;

	public const float rtfWidth = 601f;

	public const short DefSctWidth = 300;

	public const short DefSctHeight = 350;

	public const short DefAnlWidth = 500;

	public const short DefAnlHeight = 200;

	public static UserInfo User = new UserInfo (string.Empty);

	public static string[] strCSspec = new string[42];

	public static bool blnValidate;

	public static bool blnSctInpLoaded;

	public static bool blnAnlInpLoaded;

	public static bool blnOptionsLoaded;

	public static bool blnRefreshGrdElements;

	public static bool blnRefreshGrdBeams;

	public static bool blnRefreshGrdSupports;

	public static bool blnRefreshGrdLoads;

	public static bool blnRefreshGrdCombs;

	public static byte bytOptionsTab;

	public static Heading[] hdgSctPic;

	public static frmSctPicMaster[] frmSctPic;

	public static Heading[] hdgReport;

	public static frmReportMaster[] frmReport;

	public static Heading[] hdgAnlPic;

	public static frmAnlPicMaster[] frmAnlPic;

	public static bool blnAutomation;

	public static LicenseTypes intLicenseType;

	public static LicenseConfiguration SingleLicenseConfig;

	public static CFSLicense SingleLicense;

	public static LicenseConfiguration NetworkLicenseConfig;

	public static CFSLicense NetworkLicense;

	public static CFSSemaphore LicenseSemaphore;

	public static double dblLicenseCheck;

	public static string AppVer (short intAppVer)
	{
		return Conversions.ToString (intAppVer / 100) + "." + Conversions.ToString (intAppVer / 10 % 10) + "." + Conversions.ToString (intAppVer % 10);
	}

	public static void ResetThicknesses ()
	{
		ResetThicknesses (ref Thicknesses);
	}

	public static void ResetThicknesses (ref Thickness[] DefThickness)
	{
		DefThickness = new Thickness[10];
		DefThickness [1].Name = "18 mil";
		DefThickness [1].Thickness = 0.0188f;
		DefThickness [1].DefRad = 0.0843f;
		DefThickness [2].Name = "27 mil";
		DefThickness [2].Thickness = 0.0283f;
		DefThickness [2].DefRad = 0.0796f;
		DefThickness [3].Name = "30 mil";
		DefThickness [3].Thickness = 0.0312f;
		DefThickness [3].DefRad = 0.0781f;
		DefThickness [4].Name = "33 mil";
		DefThickness [4].Thickness = 0.0346f;
		DefThickness [4].DefRad = 0.0764f;
		DefThickness [5].Name = "43 mil";
		DefThickness [5].Thickness = 0.0451f;
		DefThickness [5].DefRad = 0.0712f;
		DefThickness [6].Name = "54 mil";
		DefThickness [6].Thickness = 0.0566f;
		DefThickness [6].DefRad = 0.0849f;
		DefThickness [7].Name = "68 mil";
		DefThickness [7].Thickness = 0.0713f;
		DefThickness [7].DefRad = 0.1069f;
		DefThickness [8].Name = "97 mil";
		DefThickness [8].Thickness = 0.1017f;
		DefThickness [8].DefRad = 0.1525f;
		DefThickness [9].Name = "118 mil";
		DefThickness [9].Thickness = 0.1242f;
		DefThickness [9].DefRad = 0.1863f;
	}

	public static void SetThicknessIndex (Part Part)
	{
		Part part = Part;
		short num = -1;
		checked {
			short num2 = (short)Information.UBound (Thicknesses);
			short num3;
			for (num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (part.Thickness == Thicknesses [num3].Thickness) {
					if (num == -1) {
						num = num3;
					}
					if (part.DefRad == Thicknesses [num3].DefRad) {
						part.ThicknessIndex = num3;
						break;
					}
				}
			}
			if (num == -1) {
				part.ThicknessIndex = -1;
			} else if (num3 > Information.UBound (Thicknesses)) {
				part.ThicknessIndex = num;
			}
			part = null;
		}
	}

	public static short MatchMaterial (MaterialType Material)
	{
		MaterialType materialType = Material;
		string text = Strings.Trim (materialType.Name);
		bool flag = false;
		if (Operators.CompareString (Strings.Left (text, 1), "[", TextCompare: false) == 0) {
			text = Strings.Mid (text, 2);
			flag = true;
		}
		checked {
			if (Operators.CompareString (Strings.Right (text, 1), "]", TextCompare: false) == 0) {
				text = Strings.Left (text, Strings.Len (text) - 1);
				flag = true;
			}
			short result = 0;
			materialType.AssignFamily ();
			if (materialType.IsCarbon ()) {
				short num = 0;
				float num2 = float.MaxValue;
				float num3 = float.MaxValue;
				short num4 = (short)Information.UBound (Materials);
				for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
					if (Materials [num5].IsCarbon ()) {
						if (!flag & (Strings.StrComp (text, Strings.Trim (Materials [num5].Name), CompareMethod.Text) == 0)) {
							int num6 = 1;
							do {
								materialType.Eo [num6] = Materials [num5].Eo [num6];
								materialType.N [num6] = Materials [num5].N [num6];
								materialType.Fy [num6] = Materials [num5].FyMin * materialType.Fy [num6] / materialType.FyMin;
								if (materialType.Fy [num6] < Materials [num5].FyMin) {
									materialType.Fy [num6] = Materials [num5].FyMin;
								}
								if (materialType.Fy [num6] > Materials [num5].FuMin) {
									materialType.Fy [num6] = Materials [num5].FuMin;
								}
								num6++;
							} while (num6 <= 5);
							materialType.Fy [5] = (float)(0.6 * (double)materialType.Fy [2]);
							materialType.Fu = Materials [num5].FuMin * materialType.Fu / materialType.FuMin;
							if (materialType.Fu < Materials [num5].FuMin) {
								materialType.Fu = Materials [num5].FuMin;
							}
							if (materialType.Fu > Materials [num5].FuMax) {
								materialType.Fu = Materials [num5].FuMax;
							}
							num = num5;
							break;
						}
						if ((materialType.Eo [2] == Materials [num5].Eo [2]) & (materialType.Fy [2] >= Materials [num5].FyMin) & (materialType.Fy [2] <= Materials [num5].FuMin) & (materialType.Fu >= Materials [num5].FuMin) & (materialType.Fu <= Materials [num5].FuMax) & ((materialType.FyMin == 0f) | (materialType.FyMin == Materials [num5].FyMin)) & ((materialType.FuMin == 0f) | (materialType.FuMin == Materials [num5].FuMin)) & ((materialType.FuMax == 0f) | (materialType.FuMax == Materials [num5].FuMax)) & ((materialType.Elong < 0f) | (materialType.Elong == Materials [num5].Elong)) & ((materialType.ElongThin < 0f) | (materialType.ElongThin == Materials [num5].ElongThin)) & ((materialType.ThkMin < 0f) | (materialType.ThkMin == Materials [num5].ThkMin))) {
							if (Strings.StrComp (text, Strings.Trim (Materials [num5].Name), CompareMethod.Text) == 0) {
								num = num5;
								break;
							}
							if (Strings.Len (text) == 0) {
								float num7 = System.Math.Abs (materialType.Fy [2] - Materials [num5].FyMin);
								if (num7 < num2) {
									num2 = num7;
									num3 = System.Math.Abs (materialType.Fu - Materials [num5].Fu);
									num = num5;
								} else if (num7 == num2) {
									num7 = System.Math.Abs (materialType.Fu - Materials [num5].Fu);
									if (num7 < num3) {
										num3 = num7;
										num = num5;
									}
								}
							}
						}
					}
				}
				if (num > 0) {
					materialType.Name = Materials [num].Name;
					materialType.FyMin = Materials [num].FyMin;
					materialType.FuMin = Materials [num].FuMin;
					materialType.FuMax = Materials [num].FuMax;
					materialType.Elong = Materials [num].Elong;
					materialType.ElongThin = Materials [num].ElongThin;
					materialType.ThkMin = Materials [num].ThkMin;
					result = num;
				} else if (num == 0) {
					if (Strings.Len (text) == 0) {
						text = "Unknown";
					}
					materialType.Name = "[" + text + "]";
					if ((materialType.FuMin == 0f) & (materialType.FuMax == 0f)) {
						materialType.FyMin = 0f;
						materialType.FuMin = materialType.Fy [2];
						materialType.FuMax = 2f * materialType.Fy [2];
					}
					if (materialType.Elong < 0f) {
						materialType.Elong = 10f;
					}
					if (materialType.ElongThin < 0f) {
						materialType.ElongThin = 0f;
					}
					if (materialType.ThkMin < 0f) {
						materialType.ThkMin = 0f;
					}
				}
				materialType = null;
			} else {
				short num8 = (short)Information.UBound (Materials);
				short num5 = 1;
				while (true) {
					if (num5 <= num8) {
						if (Materials [num5].IsStainless () && ((materialType.Eo [1] == Materials [num5].Eo [1]) & (materialType.Eo [2] == Materials [num5].Eo [2]) & (materialType.Eo [3] == Materials [num5].Eo [3]) & (materialType.Eo [4] == Materials [num5].Eo [4]) & (materialType.Eo [5] == Materials [num5].Eo [5]) & (materialType.Fy [1] == Materials [num5].Fy [1]) & (materialType.Fy [2] == Materials [num5].Fy [2]) & (materialType.Fy [3] == Materials [num5].Fy [3]) & (materialType.Fy [4] == Materials [num5].Fy [4]) & (materialType.Fy [5] == Materials [num5].Fy [5]) & (materialType.N [1] == Materials [num5].N [1]) & (materialType.N [2] == Materials [num5].N [2]) & (materialType.N [3] == Materials [num5].N [3]) & (materialType.N [4] == Materials [num5].N [4]) & (materialType.N [5] == Materials [num5].N [5]) & (materialType.Fu == Materials [num5].Fu)) && ((Strings.Len (text) == 0) | (Strings.StrComp (text, Strings.Trim (Materials [num5].Name), CompareMethod.Text) == 0))) {
							materialType.Name = Materials [num5].Name;
							materialType.FyMin = Materials [num5].FyMin;
							materialType.FuMin = Materials [num5].FuMin;
							materialType.FuMax = Materials [num5].FuMax;
							result = num5;
							break;
						}
						num5 = (short)unchecked(num5 + 1);
						continue;
					}
					if (Strings.Len (text) == 0) {
						text = "Unknown";
					}
					materialType.Name = "[" + text + "]";
					materialType.FyMin = materialType.Fy [2];
					materialType.FuMin = materialType.Fu;
					materialType.FuMax = materialType.Fu;
					if (materialType.Elong < 0f) {
						materialType.Elong = 10f;
					}
					if (materialType.ElongThin < 0f) {
						materialType.ElongThin = 0f;
					}
					if (materialType.ThkMin < 0f) {
						materialType.ThkMin = 0f;
					}
					result = 0;
					break;
				}
			}
			return result;
		}
	}

	public static void ModifyDSMValues (Section Sct, float Fy)
	{
		float num = Sct.Material.Fy [2] / Fy;
		ref Section.DSMType dSM = ref Sct.DSM;
		if (dSM.Pcrl < 1000f) {
			dSM.Pcrl = (float)Min (dSM.Pcrl * num, 1000.0);
		}
		if (dSM.Pcrd < 1000f) {
			dSM.Pcrd = (float)Min (dSM.Pcrd * num, 1000.0);
		}
		if (dSM.Mcrlxp < 1000f) {
			dSM.Mcrlxp = (float)Min (dSM.Mcrlxp * num, 1000.0);
		}
		if (dSM.Mcrdxp < 1000f) {
			dSM.Mcrdxp = (float)Min (dSM.Mcrdxp * num, 1000.0);
		}
		if (dSM.Mcrlxn < 1000f) {
			dSM.Mcrlxn = (float)Min (dSM.Mcrlxn * num, 1000.0);
		}
		if (dSM.Mcrdxn < 1000f) {
			dSM.Mcrdxn = (float)Min (dSM.Mcrdxn * num, 1000.0);
		}
		if (dSM.Mcrlyp < 1000f) {
			dSM.Mcrlyp = (float)Min (dSM.Mcrlyp * num, 1000.0);
		}
		if (dSM.Mcrdyp < 1000f) {
			dSM.Mcrdyp = (float)Min (dSM.Mcrdyp * num, 1000.0);
		}
		if (dSM.Mcrlyn < 1000f) {
			dSM.Mcrlyn = (float)Min (dSM.Mcrlyn * num, 1000.0);
		}
		if (dSM.Mcrdyn < 1000f) {
			dSM.Mcrdyn = (float)Min (dSM.Mcrdyn * num, 1000.0);
		}
		if (dSM.Vcry < 1000f) {
			dSM.Vcry = (float)Min (dSM.Vcry * num, 1000.0);
		}
		if (dSM.Vcrx < 1000f) {
			dSM.Vcrx = (float)Min (dSM.Vcrx * num, 1000.0);
		}
	}

	public static void InitializeSpecs ()
	{
		strCSspec [0] = "AISI 1999, US, ASD";
		strCSspec [1] = "AISI 1999, US, LRFD";
		strCSspec [2] = "AISI 2001 NAS, US, ASD";
		strCSspec [3] = "AISI 2001 NAS, US, LRFD";
		strCSspec [4] = "AISI 2001 NAS, Mexico, ASD";
		strCSspec [5] = "AISI 2001 NAS, Mexico, LRFD";
		strCSspec [6] = "AISI 2001 NAS, Canada, LSD";
		strCSspec [7] = "AISI 2004 NAS, US, ASD";
		strCSspec [8] = "AISI 2004 NAS, US, LRFD";
		strCSspec [9] = "AISI 2004 NAS, Mexico, ASD";
		strCSspec [10] = "AISI 2004 NAS, Mexico, LRFD";
		strCSspec [11] = "AISI 2004 NAS, Canada, LSD";
		strCSspec [12] = "AISI S100-07, US, ASD";
		strCSspec [13] = "AISI S100-07, US, LRFD";
		strCSspec [14] = "AISI S100-07, Mexico, ASD";
		strCSspec [15] = "AISI S100-07, Mexico, LRFD";
		strCSspec [16] = "AISI S100-07, Canada, LSD";
		strCSspec [17] = "AISI S100-07/S2-10, US, ASD";
		strCSspec [18] = "AISI S100-07/S2-10, US, LRFD";
		strCSspec [19] = "AISI S100-07/S2-10, Mexico, ASD";
		strCSspec [20] = "AISI S100-07/S2-10, Mexico, LRFD";
		strCSspec [21] = "AISI S100-07/S2-10, Canada, LSD";
		strCSspec [22] = "AISI S100-12, US, ASD";
		strCSspec [23] = "AISI S100-12, US, LRFD";
		strCSspec [24] = "AISI S100-12, Mexico, ASD";
		strCSspec [25] = "AISI S100-12, Mexico, LRFD";
		strCSspec [26] = "AISI S100-12, Canada, LSD";
		strCSspec [27] = "AISI S100-16, US, ASD";
		strCSspec [28] = "AISI S100-16, US, LRFD";
		strCSspec [29] = "AISI S100-16, Mexico, ASD";
		strCSspec [30] = "AISI S100-16, Mexico, LRFD";
		strCSspec [31] = "AISI S100-16, Canada, LSD";
		strCSspec [32] = "AISI S100-16/S1-18, US, ASD";
		strCSspec [33] = "AISI S100-16/S1-18, US, LRFD";
		strCSspec [34] = "AISI S100-16/S1-18, Mexico, ASD";
		strCSspec [35] = "AISI S100-16/S1-18, Mexico, LRFD";
		strCSspec [36] = "AISI S100-16/S1-18, Canada, LSD";
		strCSspec [37] = "AISI S100-16/S3-22, US, ASD";
		strCSspec [38] = "AISI S100-16/S3-22, US, LRFD";
		strCSspec [39] = "AISI S100-16/S3-22, Mexico, ASD";
		strCSspec [40] = "AISI S100-16/S3-22, Mexico, LRFD";
		strCSspec [41] = "AISI S100-16/S3-22, Canada, LSD";
	}

	public static string strSSspec (Specifications Spec)
	{
		if (IsSpecASD ((short)Spec)) {
			return "ASCE 8-22 SS Specification, ASD";
		}
		return "ASCE 8-22 SS Specification, LRFD";
	}

	public static bool IsSpecASD (short Spec)
	{
		switch (Spec) {
		case 0:
		case 2:
		case 7:
		case 12:
		case 17:
		case 22:
		case 27:
		case 32:
		case 37:
			return true;
		case 4:
		case 9:
		case 14:
		case 19:
		case 24:
		case 29:
		case 34:
		case 39:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpecLRFD (short Spec)
	{
		switch (Spec) {
		case 1:
		case 3:
		case 8:
		case 13:
		case 18:
		case 23:
		case 28:
		case 33:
		case 38:
			return true;
		case 5:
		case 10:
		case 15:
		case 20:
		case 25:
		case 30:
		case 35:
		case 40:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpecLSD (short Spec)
	{
		switch (Spec) {
		case 6:
		case 11:
		case 16:
		case 21:
		case 26:
		case 31:
		case 36:
		case 41:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpec1999 (short Spec)
	{
		short num = Spec;
		if ((uint)num <= 1u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2001 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 2) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2004 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 7) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2007 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 12) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2010 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 17) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2012 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 22) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2016 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 27) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2018 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 32) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpec2022 (short Spec)
	{
		short num = Spec;
		if ((uint)(num - 37) <= 4u) {
			return true;
		}
		return false;
	}

	public static bool IsSpecUS (short Spec)
	{
		switch (Spec) {
		case 0:
		case 2:
		case 7:
		case 12:
		case 17:
		case 22:
		case 27:
		case 32:
		case 37:
			return true;
		case 1:
		case 3:
		case 8:
		case 13:
		case 18:
		case 23:
		case 28:
		case 33:
		case 38:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpecMex (short Spec)
	{
		switch (Spec) {
		case 4:
		case 9:
		case 14:
		case 19:
		case 24:
		case 29:
		case 34:
		case 39:
			return true;
		case 5:
		case 10:
		case 15:
		case 20:
		case 25:
		case 30:
		case 35:
		case 40:
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpecCan (short Spec)
	{
		switch (Spec) {
		case 6:
		case 11:
		case 16:
		case 21:
		case 26:
		case 31:
		case 36:
		case 41:
			return true;
		default:
			return false;
		}
	}

	public static short SpecYear (short Spec)
	{
		if (IsSpec2022 (Spec)) {
			return 2022;
		}
		if (IsSpec2018 (Spec)) {
			return 2018;
		}
		if (IsSpec2016 (Spec)) {
			return 2016;
		}
		if (IsSpec2012 (Spec)) {
			return 2012;
		}
		if (IsSpec2010 (Spec)) {
			return 2010;
		}
		if (IsSpec2007 (Spec)) {
			return 2007;
		}
		if (IsSpec2004 (Spec)) {
			return 2004;
		}
		if (IsSpec2001 (Spec)) {
			return 2001;
		}
		if (IsSpec1999 (Spec)) {
			return 1999;
		}
		return 0;
	}

	public static void Swap (ref object A, ref object B)
	{
		object objectValue = RuntimeHelpers.GetObjectValue (A);
		A = RuntimeHelpers.GetObjectValue (B);
		B = RuntimeHelpers.GetObjectValue (objectValue);
	}

	public static void Swap (ref double A, ref double B)
	{
		double num = A;
		A = B;
		B = num;
	}

	public static void Swap (ref float A, ref float B)
	{
		float num = A;
		A = B;
		B = num;
	}

	public static void Swap (ref int A, ref int B)
	{
		int num = A;
		A = B;
		B = num;
	}

	public static void Swap (ref short A, ref short B)
	{
		short num = A;
		A = B;
		B = num;
	}

	public static void Swap (ref byte A, ref byte B)
	{
		byte b = A;
		A = B;
		B = b;
	}

	public static void Swap (ref bool A, ref bool B)
	{
		bool flag = A;
		A = B;
		B = flag;
	}

	public static double Max (double X0, double X1, double X2 = double.MinValue, double X3 = double.MinValue, double X4 = double.MinValue, double X5 = double.MinValue, double X6 = double.MinValue, double X7 = double.MinValue, double X8 = double.MinValue, double X9 = double.MinValue)
	{
		double num = System.Math.Max (X0, X1);
		if (X2 > double.MinValue) {
			num = System.Math.Max (num, X2);
			if (X3 > double.MinValue) {
				num = System.Math.Max (num, X3);
				if (X4 > double.MinValue) {
					num = System.Math.Max (num, X4);
					if (X5 > double.MinValue) {
						num = System.Math.Max (num, X5);
						if (X6 > double.MinValue) {
							num = System.Math.Max (num, X6);
							if (X7 > double.MinValue) {
								num = System.Math.Max (num, X7);
								if (X8 > double.MinValue) {
									num = System.Math.Max (num, X8);
									if (X9 > double.MinValue) {
										num = System.Math.Max (num, X9);
									}
								}
							}
						}
					}
				}
			}
		}
		return num;
	}

	public static double Min (double X0, double X1, double X2 = double.MaxValue, double X3 = double.MaxValue, double X4 = double.MaxValue, double X5 = double.MaxValue, double X6 = double.MaxValue, double X7 = double.MaxValue, double X8 = double.MaxValue, double X9 = double.MaxValue)
	{
		double num = System.Math.Min (X0, X1);
		if (X2 < double.MaxValue) {
			num = System.Math.Min (num, X2);
			if (X3 < double.MaxValue) {
				num = System.Math.Min (num, X3);
				if (X4 < double.MaxValue) {
					num = System.Math.Min (num, X4);
					if (X5 < double.MaxValue) {
						num = System.Math.Min (num, X5);
						if (X6 < double.MaxValue) {
							num = System.Math.Min (num, X6);
							if (X7 < double.MaxValue) {
								num = System.Math.Min (num, X7);
								if (X8 < double.MaxValue) {
									num = System.Math.Min (num, X8);
									if (X9 < double.MaxValue) {
										num = System.Math.Min (num, X9);
									}
								}
							}
						}
					}
				}
			}
		}
		return num;
	}

	public static string Pad (string Text, short nChar)
	{
		if (nChar <= 0) {
			return string.Empty;
		}
		checked {
			if (Strings.Len (Text) > nChar) {
				if (nChar <= 3) {
					return new string ('.', nChar);
				}
				return Strings.Left (Text, nChar - 3) + "...";
			}
			short num = (short)unchecked(checked(nChar - Strings.Len (Text)) / 2);
			short number = (short)(nChar - Strings.Len (Text) - num);
			return Strings.Space (num) + Text + Strings.Space (number);
		}
	}

	public static string FileNameAbsolute (string FileNameRef, string FileNameRel)
	{
		string result = FileNameRel;
		checked {
			short num = (short)Strings.Len (FileNameRel);
			short num2 = 1;
			while (num2 <= num && Operators.CompareString (Strings.Mid (FileNameRel, num2, 1), ".", TextCompare: false) == 0) {
				num2 = (short)unchecked(num2 + 1);
			}
			short num3 = (short)(num2 - 1);
			if (num3 > 0) {
				short num4 = 0;
				for (num2 = (short)Strings.Len (FileNameRef); num2 >= 1; num2 = (short)unchecked(num2 + -1)) {
					if (Operators.CompareString (Strings.Mid (FileNameRef, num2, 1), "\\", TextCompare: false) == 0) {
						num4 = (short)(num4 + 1);
						if (num4 == num3) {
							result = Strings.Left (FileNameRef, num2 - 1) + Strings.Mid (FileNameRel, num3 + 1);
							break;
						}
					}
				}
			}
			return result;
		}
	}

	public static string FileNameRelative (string FileNameRef, string FileNameAbs)
	{
		short num = 0;
		short num2 = 0;
		checked {
			short num3 = (short)Strings.Len (FileNameRef);
			short num4 = 1;
			while (num4 <= num3 && Operators.CompareString (Strings.UCase (Strings.Mid (FileNameRef, num4, 1)), Strings.UCase (Strings.Mid (FileNameAbs, num4, 1)), TextCompare: false) == 0) {
				if (Operators.CompareString (Strings.Mid (FileNameRef, num4, 1), "\\", TextCompare: false) == 0) {
					num = num4;
					num2 = (short)(num2 + 1);
				}
				num4 = (short)unchecked(num4 + 1);
			}
			short num5 = num2;
			short num6 = num4;
			short num7 = (short)Strings.Len (FileNameRef);
			for (num4 = num6; num4 <= num7; num4 = (short)unchecked(num4 + 1)) {
				if (Operators.CompareString (Strings.Mid (FileNameRef, num4, 1), "\\", TextCompare: false) == 0) {
					num5 = (short)(num5 + 1);
				}
			}
			if (num > 2) {
				return new string ('.', (short)unchecked(num5 - num2) + 1) + Strings.Mid (FileNameAbs, num);
			}
			return FileNameAbs;
		}
	}

	public static bool Launch (string URL)
	{
		bool result = false;
		try {
			Cursor.Current = Cursors.AppStarting;
			if (Process.Start (URL).Id != 0) {
				result = true;
				return result;
			}
			return result;
		} catch (Exception projectError) {
			ProjectData.SetProjectError (projectError);
			ProjectData.ClearProjectError ();
			return result;
		} finally {
			Cursor.Current = Cursors.Default;
		}
	}

	public static bool InitializeLicense ()
	{
		string text = string.Empty;
		string text2 = string.Empty;
		bool result = false;
		intLicenseType = LicenseTypes.None;
		dblLicenseCheck = DateAndTime.Now.ToOADate ();
		checked {
			if (blnAutomation && CheckSubLicense ()) {
				intLicenseType = LicenseTypes.Sublicense;
				result = true;
			} else {
				SingleLicenseConfig = new LicenseConfiguration (IsNetworkConfiguration: false);
				int num = default(int);
				if (intLicenseType == LicenseTypes.None) {
					SingleLicense = new CFSLicense (SingleLicenseConfig);
					if (SingleLicense.LoadFile (SingleLicenseConfig.LicenseFilePath)) {
						if (!IsRemoteSession ()) {
							if (SingleLicense.Validate ()) {
								if (!blnAutomation || SingleLicense.HasAutomation) {
									result = true;
									intLicenseType = LicenseTypes.SingleUser;
									text2 = "Single User";
									SingleLicenseConfig.AppendLog ("Acquired");
									num = (int)SingleLicense.EffectiveEndDate.ToLocalTime ().Subtract (DateAndTime.Now).TotalDays;
								} else {
									SingleLicenseConfig.AppendLog ("Invalid Auto");
									text = "Requires automation license.";
								}
							} else {
								SingleLicenseConfig.AppendLog ("Invalid " + Conversions.ToString (SingleLicense.LastError.ErrorNumber));
								text = "Invalid single user license: \r\n" + SingleLicense.LastError.ToString ();
								if (SingleLicense.LastError.ErrorNumber == 9203) {
									text = "Single user license expired on " + SingleLicense.EffectiveEndDate.ToShortDateString () + ". If you renewed your license subscription, you need to refresh the license by choosing Single User License from the Tools menu, and clicking the Refresh button.";
								}
							}
						} else {
							SingleLicenseConfig.AppendLog ("Invalid " + Conversions.ToString (9303));
							text = "Single user license cannot be used remotely.";
						}
					} else if (Microsoft.VisualBasic.FileIO.FileSystem.FileExists (SingleLicenseConfig.LicenseFilePath)) {
						SingleLicenseConfig.AppendLog ("Error " + Conversions.ToString (SingleLicense.LastError.ErrorNumber));
						text = "Single user license error: \r\n" + SingleLicense.LastError.ToString ();
					}
				}
				NetworkLicenseConfig = new LicenseConfiguration (IsNetworkConfiguration: true);
				string pathRegistryValue = NetworkLicenseConfig.PathRegistryValue;
				NetworkLicenseConfig.LicenseFilePath = pathRegistryValue;
				NetworkLicenseConfig.CompanyName = NetworkLicenseConfig.CompanyRegistryValue;
				if ((intLicenseType == LicenseTypes.None) & (pathRegistryValue.Length > 0)) {
					NetworkLicense = new CFSLicense (NetworkLicenseConfig);
					if (NetworkLicense.LoadFile (NetworkLicenseConfig.LicenseFilePath)) {
						if (NetworkLicense.Validate ()) {
							if (!blnAutomation || NetworkLicense.HasAutomation) {
								LicenseSemaphore = new CFSSemaphore (Path.GetDirectoryName (NetworkLicenseConfig.LicenseFilePath), NetworkLicenseConfig.NetworkSemaphorePrefix, NetworkLicense.LicenseCounter, !blnAutomation, 15, !blnAutomation);
								if (LicenseSemaphore.Open ()) {
									result = true;
									intLicenseType = LicenseTypes.Semaphore;
									text2 = "Network";
									NetworkLicenseConfig.AppendLog ("Acquired", LicenseSemaphore);
									num = (int)NetworkLicense.EffectiveEndDate.ToLocalTime ().Subtract (DateAndTime.Now).TotalDays;
								} else if (LicenseSemaphore.LastError.ErrorNumber == 9211) {
									if (!blnAutomation && LicenseSemaphore.GetUnusedNetworkLicense ()) {
										result = true;
										intLicenseType = LicenseTypes.Semaphore;
										text2 = "Network";
										num = (int)NetworkLicense.EffectiveEndDate.ToLocalTime ().Subtract (DateAndTime.Now).TotalDays;
									} else {
										text = "No network licenses available.";
										LicenseSemaphore = null;
									}
								} else {
									NetworkLicenseConfig.AppendLog ("Error " + Conversions.ToString (LicenseSemaphore.LastError.ErrorNumber), LicenseSemaphore);
									text = "Network license error: \r\n" + LicenseSemaphore.LastError.ToString ();
									LicenseSemaphore = null;
								}
							} else {
								NetworkLicenseConfig.AppendLog ("Invalid");
								text = "Requires automation license.";
							}
						} else {
							NetworkLicenseConfig.AppendLog ("Invalid " + Conversions.ToString (NetworkLicense.LastError.ErrorNumber));
							text = "Invalid network license: \r\n" + NetworkLicense.LastError.ToString ();
							if (NetworkLicense.LastError.ErrorNumber == 9203) {
								text = "Network license expired on " + NetworkLicense.EffectiveEndDate.ToShortDateString () + ". If you renewed your license subscription, you need to refresh the license by choosing Network License Settings from the Tools menu, and clicking the Refresh button.";
							}
						}
					} else if (Microsoft.VisualBasic.FileIO.FileSystem.FileExists (NetworkLicenseConfig.LicenseFilePath)) {
						NetworkLicenseConfig.AppendLog ("Error " + Conversions.ToString (NetworkLicense.LastError.ErrorNumber));
						text = "Network license error: \r\n" + NetworkLicense.LastError.ToString ();
					}
				}
				if (!blnAutomation) {
					Version version = ((intLicenseType == LicenseTypes.SingleUser) ? new Version (SingleLicense.LatestVersion) : ((intLicenseType != LicenseTypes.Semaphore) ? new Version ("0.0.0.0") : new Version (NetworkLicense.LatestVersion)));
					if (intLicenseType == LicenseTypes.None) {
						if (text.Length > 0) {
							text += "\r\n\r\nCFS will run in light mode.";
							Interaction.MsgBox (text, MsgBoxStyle.Exclamation);
						}
					} else if (num <= 10) {
						text = num switch {
							0 => text2 + " License will expire today. ", 
							1 => text2 + " License will expire tomorrow. ", 
							_ => text2 + " License will expire in " + Conversions.ToString (num) + " days. ", 
						} + "If your license purchase was made with automatic payments and your credit card information is still valid, the license will be renewed automatically.";
						Interaction.MsgBox (text, MsgBoxStyle.Exclamation);
					} else if ((version.Major > My.MyProject.Application.Info.Version.Major) | ((version.Major == My.MyProject.Application.Info.Version.Major) & (version.Minor > My.MyProject.Application.Info.Version.Minor))) {
						text = "Important: CFS version " + version.ToString () + " is available to download and should be used instead of this version. ";
						text += "Go to the download page at www.rsgsoftware.com to get the latest version.";
						Interaction.MsgBox (text, MsgBoxStyle.Exclamation);
					} else if ((version.Major == My.MyProject.Application.Info.Version.Major) & (version.Minor == My.MyProject.Application.Info.Version.Minor) & ((version.Build > My.MyProject.Application.Info.Version.Build) | ((version.Build == My.MyProject.Application.Info.Version.Build) & (version.Revision > My.MyProject.Application.Info.Version.Revision)))) {
						text = "Note: CFS version " + version.ToString () + " is available to download. ";
						text += "Go to the download page at www.rsgsoftware.com to get the latest version.";
						Interaction.MsgBox (text, MsgBoxStyle.Information);
					}
				}
			}
			return result;
		}
	}

	public static bool CheckLicense ()
	{
		double num = DateAndTime.Now.ToOADate ();
		if (intLicenseType == LicenseTypes.None) {
			return true;
		}
		if (intLicenseType == LicenseTypes.Sublicense) {
			return true;
		}
		if (intLicenseType == LicenseTypes.SingleUser) {
			if (num - dblLicenseCheck < 1.0 / 720.0) {
				return true;
			}
			dblLicenseCheck = num;
			if (SingleLicense != null && SingleLicense.QuickValidate ()) {
				return true;
			}
			SingleLicenseConfig.AppendLog ("Released");
		} else if (intLicenseType == LicenseTypes.Semaphore) {
			if (num - dblLicenseCheck < 0.00069444444444444447) {
				return true;
			}
			dblLicenseCheck = num;
			if (NetworkLicense != null && NetworkLicense.QuickValidate () && LicenseSemaphore != null) {
				if (!blnAutomation && LicenseSemaphore.IsActive) {
					return true;
				}
				if (blnAutomation && LicenseSemaphore.IsValid) {
					return true;
				}
			}
			NetworkLicense = null;
			LicenseSemaphore = null;
			NetworkLicenseConfig.AppendLog ("Released");
		}
		intLicenseType = LicenseTypes.None;
		return false;
	}

	public static bool CheckSubLicense ()
	{
		int try0000_dispatch = -1;
		bool result = default(bool);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					result = false;
					ProjectData.ClearProjectError ();
					num2 = 2;
					int num3 = HashValue (((AssemblyCompanyAttribute[])Assembly.GetEntryAssembly ().GetCustomAttributes (typeof(AssemblyCompanyAttribute), inherit: false)) [0].Company, 31);
					if (num3 == 497924146) {
						result = true;
					}
					if (num3 == 1768413592) {
						result = true;
					}
					if (num3 == 302403742) {
						result = true;
					}
					break;
				}
				case 80:
					num = -1;
					switch (num2) {
					case 2:
						break;
					default:
						goto IL_0086;
					}
					break;
				}
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 80;
				continue;
			}
			break;
			IL_0086:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void LicenseRequired (string strMsg)
	{
		My.MyProject.Forms.frmLicenseRequired.Tag = strMsg;
		My.MyProject.Forms.frmLicenseRequired.ShowDialog (Form.ActiveForm);
	}

	public static byte[] HexToByteArray (string strData)
	{
		checked {
			short num = (short)unchecked(Strings.Len (strData) / 2);
			byte[] array = new byte[num + 1];
			short num2 = (short)(num - 1);
			for (short num3 = 0; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				array [num3] = (byte)System.Math.Round (Conversion.Val ("&H" + Strings.Mid (strData, num3 * 2 + 1, 2)));
			}
			return array;
		}
	}

	public static string ByteArrayToHex (byte[] arrByte, short intLength = 0)
	{
		string text = string.Empty;
		checked {
			short num = (short)Information.UBound (arrByte);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				string text2 = Conversion.Hex (arrByte [num2]);
				text2 = new string ('0', 2 - Strings.Len (text2)) + text2;
				text += text2;
				if ((intLength > 0) & (Strings.Len (text) >= intLength)) {
					text = Strings.Left (text, intLength);
					break;
				}
			}
			return text;
		}
	}

	public static string GetComputerCode ()
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num3 = default(int);
		object objectValue = default(object);
		string text = default(string);
		int num = default(int);
		string result;
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					ProjectData.ClearProjectError ();
					num2 = 2;
					string systemDirectory = Environment.SystemDirectory;
					num3 = Conversions.ToInteger (NewLateBinding.LateGet (RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (RuntimeHelpers.GetObjectValue (Interaction.CreateObject ("Scripting.FileSystemObject")), null, "GetDrive", new object[1] { Strings.Left (systemDirectory, 1) }, null, null, null)), null, "SerialNumber", new object[0], null, null, null));
					objectValue = RuntimeHelpers.GetObjectValue (Interaction.GetObject ("winmgmts:\\\\.\\root\\cimv2"));
					text = string.Empty;
					ProjectData.ClearProjectError ();
					num2 = 3;
					IEnumerator enumerator2 = ((IEnumerable)RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (objectValue, null, "ExecQuery", new object[1] { "Select * from Win32_BaseBoard" }, null, null, null))).GetEnumerator ();
					while (enumerator2.MoveNext ()) {
						object objectValue2 = RuntimeHelpers.GetObjectValue (enumerator2.Current);
						if (objectValue2 != null) {
							text = Conversions.ToString (Operators.ConcatenateObject (NewLateBinding.LateGet (objectValue2, null, "SerialNumber", new object[0], null, null, null), string.Empty));
							break;
						}
					}
					if (enumerator2 is IDisposable) {
						(enumerator2 as IDisposable).Dispose ();
					}
					goto IL_0109;
				}
				case 635:
					{
						num = -1;
						switch (num2) {
						case 2:
							break;
						case 3:
							goto IL_0237;
						case 4:
							goto IL_0258;
						default:
							goto end_IL_0000;
						}
						num3 = 0;
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						goto IL_01f5;
					}
					IL_0258:
					text = string.Empty;
					ProjectData.ClearProjectError ();
					if (num == 0) {
						throw ProjectData.CreateProjectError (-2146828268);
					}
					num = 0;
					goto IL_01f5;
					IL_0109:
					ProjectData.ClearProjectError ();
					num2 = 4;
					if (Strings.Len (text) < 6) {
						IEnumerator enumerator = ((IEnumerable)RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (objectValue, null, "ExecQuery", new object[1] { "select * from Win32_ComputerSystemProduct" }, null, null, null))).GetEnumerator ();
						while (enumerator.MoveNext ()) {
							object objectValue2 = RuntimeHelpers.GetObjectValue (enumerator.Current);
							if (objectValue2 == null) {
								continue;
							}
							text = Conversions.ToString (Operators.ConcatenateObject (NewLateBinding.LateGet (objectValue2, null, "IdentifyingNumber", new object[0], null, null, null), string.Empty));
							if (Strings.Len (text) < 6) {
								text = Conversions.ToString (Operators.ConcatenateObject (NewLateBinding.LateGet (objectValue2, null, "UUID", new object[0], null, null, null), string.Empty));
								if (Strings.InStr (text, "00000000") > 0) {
									text = string.Empty;
								}
							}
							break;
						}
						if (enumerator is IDisposable) {
							(enumerator as IDisposable).Dispose ();
						}
					}
					goto IL_01f5;
					IL_0237:
					text = string.Empty;
					ProjectData.ClearProjectError ();
					if (num == 0) {
						throw ProjectData.CreateProjectError (-2146828268);
					}
					num = 0;
					goto IL_0109;
					IL_01f5:
					num3 = ((Strings.Len (text) >= 6) ? (num3 ^ HashValue (text, 31)) : 0);
					result = ValueCode (num3, 0);
					goto end_IL_0000_2;
					end_IL_0000:
					break;
				}
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 635;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000_2:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static int CodeValue (string strCode, short intShift)
	{
		strCode = Strings.UCase (Strings.Left (strCode, 6));
		checked {
			short num = (short)Strings.Len (strCode);
			int num4 = default(int);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				short num3 = (short)(Strings.Asc (Strings.Mid (strCode, num2, 1)) - 48);
				if (num3 > 9) {
					num3 = (short)(num3 - 7);
				}
				if (unchecked(num3 < 0 || num3 > 35)) {
					num3 = 0;
				}
				num4 = 36 * num4 + num3;
			}
			if (unchecked(intShift > 0 && intShift < 31)) {
				intShift = (short)(31 - intShift);
				num4 = (int)System.Math.Round ((double)unchecked(num4 / checked((long)System.Math.Round (System.Math.Pow (2.0, intShift)))) + (double)num4 % System.Math.Pow (2.0, intShift) * System.Math.Pow (2.0, 31 - intShift));
			}
			return num4;
		}
	}

	public static string ValueCode (int lngValue, short intShift)
	{
		string text = string.Empty;
		lngValue &= 0x7FFFFFFF;
		checked {
			if (unchecked(intShift > 0 && intShift < 31)) {
				lngValue = (int)System.Math.Round ((double)unchecked(lngValue / checked((long)System.Math.Round (System.Math.Pow (2.0, intShift)))) + (double)lngValue % System.Math.Pow (2.0, intShift) * System.Math.Pow (2.0, 31 - intShift));
			}
			short num = 1;
			do {
				short num2 = (short)unchecked(lngValue % 36);
				if (num2 > 9) {
					num2 = (short)(num2 + 7);
				}
				text = Conversions.ToString (Strings.Chr (48 + num2)) + text;
				lngValue = unchecked(lngValue / 36);
				num = (short)unchecked(num + 1);
			} while (num <= 6);
			return text;
		}
	}

	public static int HashValue (string strText, short intBits = 31)
	{
		if (intBits < 5) {
			intBits = 5;
		}
		if (intBits > 31) {
			intBits = 31;
		}
		int num = 0;
		short num2 = 0;
		checked {
			short num3 = (short)Strings.Len (strText);
			for (short num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
				int num5 = unchecked(Strings.Asc (Strings.Mid (strText, num4, 1)) % 32);
				if (unchecked(num2 > 0 && num2 < intBits)) {
					num2 = (short)unchecked(intBits - num2);
					num5 = (int)System.Math.Round ((double)unchecked(num5 / checked((long)System.Math.Round (System.Math.Pow (2.0, num2)))) + (double)num5 % System.Math.Pow (2.0, num2) * System.Math.Pow (2.0, (short)unchecked(intBits - num2)));
					num2 = (short)unchecked(intBits - num2);
				}
				num ^= num5;
				num2 = (short)unchecked(checked(num2 + 5) % intBits);
			}
			return num;
		}
	}

	public static float GCD (float A, float B)
	{
		if (A == 0f || B == 0f) {
			return 0f;
		}
		double num = Conversions.ToDouble (Interaction.IIf (System.Math.Abs (A) > System.Math.Abs (B), System.Math.Abs (A), System.Math.Abs (B)));
		double num2 = Conversions.ToDouble (Interaction.IIf (System.Math.Abs (A) > System.Math.Abs (B), System.Math.Abs (B), System.Math.Abs (A)));
		double num3 = 1E-08 * num2;
		while (true) {
			double num4 = num - num2 * Conversion.Int (num / num2);
			if (num4 < num3) {
				break;
			}
			num = num2;
			num2 = num4;
		}
		return (float)num2;
	}

	public static float LCM (float A, float B)
	{
		if (A == 0f || B == 0f) {
			return 0f;
		}
		return System.Math.Abs (A * B) / GCD (A, B);
	}

	public static float GCD3 (float A, float B, float C)
	{
		return GCD (A, GCD (B, C));
	}

	public static float LCM3 (float A, float B, float C)
	{
		return LCM (A, LCM (B, C));
	}

	public static bool IsRemoteSession ()
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result;
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					ProjectData.ClearProjectError ();
					num2 = 2;
					if (SystemInformation.TerminalServerSession) {
						result = true;
						goto end_IL_0000;
					}
					string environmentVariable = Environment.GetEnvironmentVariable ("SessionName");
					if (environmentVariable == null || environmentVariable.Length <= 0) {
						break;
					}
					result = ((Operators.CompareString (environmentVariable.ToUpper (), "CONSOLE", TextCompare: false) != 0) ? true : false);
					goto end_IL_0000_2;
				}
				case 72:
					num = -1;
					switch (num2) {
					case 2:
						break;
					default:
						goto IL_007e;
					}
					break;
				}
				result = false;
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 72;
				continue;
			}
			break;
			IL_007e:
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
}
