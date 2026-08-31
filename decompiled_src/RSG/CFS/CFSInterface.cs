// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FlexCell;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using My;
using RSG.Utility;

namespace RSG.CFS;

[StandardModule]
internal sealed class CFSInterface
{
	public struct SectionLines
	{
		public float X;

		public float Y;

		public byte Color;

		public float Z0;

		public float Z1;
	}

	public static string[] strRecentFile = new string[33];

	public static byte bytRecentFileCount;

	public static string strPrinterName;

	public static MemberParameters MemberParametersNow;

	public static WebCripParameters WebCripParametersNow;

	public static BuckleParameters BuckleParametersNow;

	public static InsertRibs InsertRibsNow;

	public static string strClipBoard;

	public static byte bytClipBoard;

	public static Element[] cbElement;

	public static Part cbPart;

	public static Beam[] cbBeam;

	public static Support[] cbSupport;

	public static Load[] cbLoad;

	public static Loading cbLdg;

	public static LoadFactor[] cbLF;

	public static LoadCombination cbComb;

	public const short ZOOM_MAX = 32;

	public const short ZOOM_MIN = 1;

	public const byte READ_REG = 0;

	public const byte WRITE_REG = 1;

	public const string vTab = "\v";

	public const string strDefSctFile = "\\Section ";

	public const string strDefAnlFile = "\\Analysis ";

	public static float SctInpLeft;

	public static float SctInpTop;

	public static float SctInpWidth;

	public static float SctInpHeight;

	public static float AnlInpLeft;

	public static float AnlInpTop;

	public static float AnlInpWidth;

	public static float AnlInpHeight;

	public static short intLocOpt;

	public static float[] ZMemChk;

	public static short[] SMemChk;

	public static short intAnlMemChk;

	public static float[] ZWebCrip;

	public static short[] SWebCrip;

	public static short intAnlWebCrip;

	public static SectionWizard SctWizSave;

	public static AnalysisWizard AnlWizSave;

	[SpecialName]
	private static string $STATIC$LoadFile$011E$strFileNamePrev;

	[SpecialName]
	private static StaticLocalInitFlag $STATIC$LoadFile$011E$strFileNamePrev$Init;

	[SpecialName]
	private static string $STATIC$SaveReport$011128154$strPathPrev;

	[SpecialName]
	private static StaticLocalInitFlag $STATIC$SaveReport$011128154$strPathPrev$Init;

	public static string GetFileName (string strFileName)
	{
		checked {
			short num = (short)Strings.InStr (strFileName, "|");
			if (num >= strFileName.Length) {
				return string.Empty;
			}
			return Path.GetFileName (Strings.Mid (strFileName, num + 1));
		}
	}

	public static string GetFileNameWithoutExtension (string strFileName)
	{
		checked {
			short num = (short)Strings.InStr (strFileName, "|");
			if (num >= strFileName.Length) {
				return string.Empty;
			}
			return Path.GetFileNameWithoutExtension (Strings.Mid (strFileName, num + 1));
		}
	}

	public static string GetValidFileName (string strFileName)
	{
		strFileName = strFileName.Trim ();
		char[] invalidFileNameChars = Path.GetInvalidFileNameChars ();
		foreach (char c in invalidFileNameChars) {
			strFileName = strFileName.Replace (Conversions.ToString (c), "_");
		}
		return strFileName;
	}

	public static string GetDirectoryName (string strFileName)
	{
		if (strFileName.Length == 0) {
			return string.Empty;
		}
		checked {
			short num = (short)Strings.InStr (strFileName, "|");
			if (num == 0) {
				num = (short)(Strings.Len (strFileName) + 1);
			}
			return Path.GetDirectoryName (Strings.Left (strFileName, num - 1));
		}
	}

	public static string GetFullPath (string strFileName)
	{
		if (strFileName.Length == 0) {
			return string.Empty;
		}
		checked {
			short num = (short)Strings.InStr (strFileName, "|");
			if (num == 0) {
				num = (short)(Strings.Len (strFileName) + 1);
			}
			return Path.GetFullPath (Strings.Left (strFileName, num - 1));
		}
	}

	public static byte[] ByteArray (float[] sngValues, int intStart = 0, int intEnd = -1)
	{
		byte[] result = new byte[0];
		checked {
			if (intStart >= 0) {
				if (intEnd < 0) {
					intEnd = Information.UBound (sngValues);
				}
				if (intEnd >= intStart) {
					byte[] array = new byte[4 * (intEnd - intStart + 1) - 1 + 1];
					int num = intEnd;
					int num2 = default(int);
					for (int i = intStart; i <= num; i++) {
						byte[] bytes = BitConverter.GetBytes (sngValues [i]);
						array [num2] = bytes [0];
						num2++;
						array [num2] = bytes [1];
						num2++;
						array [num2] = bytes [2];
						num2++;
						array [num2] = bytes [3];
						num2++;
					}
					result = array;
				}
			}
			return result;
		}
	}

	public static byte[] ByteArray (short[] intValues, int intStart = 0, int intEnd = -1)
	{
		byte[] result = new byte[0];
		checked {
			if (intStart >= 0) {
				if (intEnd < 0) {
					intEnd = Information.UBound (intValues);
				}
				if (intEnd >= intStart) {
					byte[] array = new byte[2 * (intEnd - intStart + 1) - 1 + 1];
					int num = intEnd;
					int num2 = default(int);
					for (int i = intStart; i <= num; i++) {
						byte[] bytes = BitConverter.GetBytes (intValues [i]);
						array [num2] = bytes [0];
						num2++;
						array [num2] = bytes [1];
						num2++;
					}
					result = array;
				}
			}
			return result;
		}
	}

	public static byte[] ByteArray (int[] intValues, int intStart = 0, int intEnd = -1)
	{
		byte[] result = new byte[0];
		checked {
			if (intStart >= 0) {
				if (intEnd < 0) {
					intEnd = Information.UBound (intValues);
				}
				if (intEnd >= intStart) {
					byte[] array = new byte[4 * (intEnd - intStart + 1) - 1 + 1];
					int num = intEnd;
					int num2 = default(int);
					for (int i = intStart; i <= num; i++) {
						byte[] bytes = BitConverter.GetBytes (intValues [i]);
						array [num2] = bytes [0];
						num2++;
						array [num2] = bytes [1];
						num2++;
						array [num2] = bytes [2];
						num2++;
						array [num2] = bytes [3];
						num2++;
					}
					result = array;
				}
			}
			return result;
		}
	}

	public static byte[] ByteArray (ref object obj)
	{
		IntPtr intPtr = Marshal.AllocHGlobal (Marshal.SizeOf (RuntimeHelpers.GetObjectValue (obj)));
		byte[] array = new byte[checked(Marshal.SizeOf (RuntimeHelpers.GetObjectValue (obj)) - 1 + 1)];
		Marshal.StructureToPtr (RuntimeHelpers.GetObjectValue (obj), intPtr, fDeleteOld: false);
		Marshal.Copy (intPtr, array, 0, Marshal.SizeOf (RuntimeHelpers.GetObjectValue (obj)));
		Marshal.FreeHGlobal (intPtr);
		return array;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void GetMaterials ()
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num3 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						string text = CFS.strAppPath + "CFS14.mtl";
						CFS.Materials = new MaterialType[1];
						ProjectData.ClearProjectError ();
						num2 = 2;
						if (!File.Exists (text)) {
							Interaction.MsgBox ("Materials file not found!", MsgBoxStyle.Critical);
							ProjectData.EndApp ();
						}
						num3 = FileSystem.FreeFile ();
						FileSystem.FileOpen (num3, text, OpenMode.Binary, OpenAccess.Read);
						CFS.Materials = new MaterialType[(int)System.Math.Round ((double)FileSystem.LOF (num3) / 113.0) + 1];
						short num4 = (short)Information.UBound (CFS.Materials);
						for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
							CFS.Materials [num5] = new MaterialType ();
							MaterialType materialType = CFS.Materials [num5];
							materialType.Name = Strings.Space (24);
							FileSystem.FileGet (num3, ref materialType.Name, -1L);
							materialType.Family = Strings.Space (1);
							FileSystem.FileGet (num3, ref materialType.Family, -1L);
							short num6 = 1;
							do {
								FileSystem.FileGet (num3, ref materialType.Eo [num6], -1L);
								num6 = (short)unchecked(num6 + 1);
							} while (num6 <= 5);
							num6 = 1;
							do {
								FileSystem.FileGet (num3, ref materialType.Fy [num6], -1L);
								num6 = (short)unchecked(num6 + 1);
							} while (num6 <= 5);
							num6 = 1;
							do {
								FileSystem.FileGet (num3, ref materialType.N [num6], -1L);
								num6 = (short)unchecked(num6 + 1);
							} while (num6 <= 5);
							FileSystem.FileGet (num3, ref materialType.Fu, -1L);
							FileSystem.FileGet (num3, ref materialType.FyMin, -1L);
							FileSystem.FileGet (num3, ref materialType.FuMin, -1L);
							FileSystem.FileGet (num3, ref materialType.FuMax, -1L);
							FileSystem.FileGet (num3, ref materialType.Elong, -1L);
							FileSystem.FileGet (num3, ref materialType.ElongThin, -1L);
							FileSystem.FileGet (num3, ref materialType.ThkMin, -1L);
							materialType = null;
						}
						FileSystem.FileClose (num3);
						break;
					}
					case 538:
						num = -1;
						switch (num2) {
						case 2:
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
					FileSystem.FileClose (num3);
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 538;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	public static MaterialType GetMaterial (string strName)
	{
		int num = Information.UBound (CFS.Materials);
		for (int i = 1; i <= num; i = checked(i + 1)) {
			if (Operators.CompareString (Strings.Trim (CFS.Materials [i].Name), Strings.Trim (strName), TextCompare: false) == 0) {
				return CFS.Materials [i].Clone ();
			}
		}
		return CFS.MaterialDefault.Clone ();
	}

	public static void RegistryWindows (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string[] array = default(string[]);
		int num2 = default(int);
		int num3 = default(int);
		short num5 = default(short);
		int[] array2 = default(int[]);
		string text = default(string);
		RegistryKey registryKey = default(RegistryKey);
		short num6 = default(short);
		Rectangle workingArea = default(Rectangle);
		byte b = default(byte);
		RegistryKey registryKey2 = default(RegistryKey);
		short num7 = default(short);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						array = new string[14];
						goto IL_000b;
					case 1617:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_000b;
							case 3:
								goto IL_0016;
							case 4:
								goto IL_001f;
							case 5:
								goto IL_0026;
							case 6:
								goto IL_0031;
							case 7:
								goto IL_003c;
							case 8:
								goto IL_0047;
							case 9:
								goto IL_0052;
							case 10:
								goto IL_005e;
							case 11:
								goto IL_006a;
							case 12:
								goto IL_0076;
							case 13:
								goto IL_0082;
							case 14:
								goto IL_008f;
							case 15:
								goto IL_009c;
							case 16:
								goto IL_00a9;
							case 17:
								goto IL_00b6;
							case 18:
								goto IL_00c3;
							case 19:
								goto IL_00cc;
							case 20:
								goto IL_00dd;
							case 21:
								goto IL_00e4;
							case 22:
								goto IL_00f6;
							case 23:
								goto IL_0113;
							case 24:
								goto IL_0120;
							case 25:
								goto IL_012a;
							case 26:
								goto IL_014c;
							case 27:
								goto IL_0154;
							case 28:
								goto IL_0165;
							case 29:
								goto IL_016f;
							case 30:
								goto IL_0185;
							case 31:
								goto IL_0195;
							case 32:
								goto IL_01a3;
							case 33:
								goto IL_01ad;
							case 34:
								goto IL_01c3;
							case 35:
								goto IL_01d3;
							case 36:
								goto IL_01e1;
							case 37:
								goto IL_01eb;
							case 38:
								goto IL_0201;
							case 39:
								goto IL_0216;
							case 40:
								goto IL_0229;
							case 41:
								goto IL_0233;
							case 42:
								goto IL_0249;
							case 43:
								goto IL_025e;
							case 44:
								goto IL_0271;
							case 45:
								goto IL_0287;
							case 46:
								goto IL_029d;
							case 47:
								goto IL_02b3;
							case 48:
								goto IL_02c9;
							case 49:
								goto IL_02df;
							case 50:
								goto IL_02ec;
							case 51:
								goto IL_02f9;
							case 52:
								goto IL_0306;
							case 53:
								goto IL_0314;
							case 54:
								goto IL_0322;
							case 55:
								goto IL_0330;
							case 56:
								goto IL_033e;
							case 58:
								goto IL_0351;
							case 59:
								goto IL_035b;
							case 60:
								goto IL_0370;
							case 61:
								goto IL_0383;
							case 62:
								goto IL_038c;
							case 63:
								goto IL_03a2;
							case 64:
								goto IL_03b8;
							case 65:
								goto IL_03ce;
							case 66:
								goto IL_03e4;
							case 67:
								goto IL_03f7;
							case 68:
								goto IL_040a;
							case 69:
								goto IL_041d;
							case 70:
								goto IL_0431;
							case 71:
								goto IL_0445;
							case 72:
								goto IL_0459;
							case 73:
								goto IL_046d;
							case 74:
								goto IL_0481;
							case 75:
								goto IL_0494;
							case 76:
								goto IL_04a6;
							case 77:
								goto IL_04b7;
							case 78:
								goto IL_04c9;
							case 79:
								goto IL_04e1;
							case 80:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 57:
							case 81:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_04e1:
						num = 79;
						num5 = (short)unchecked(num5 + 1);
						goto IL_04e9;
						IL_000b:
						num = 2;
						array2 = new int[14];
						goto IL_0016;
						IL_0016:
						num = 3;
						text = "Software\\RSG Software, Inc.\\CFS\\Windows";
						goto IL_001f;
						IL_001f:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0026;
						IL_0026:
						num = 5;
						array [1] = "WindowState";
						goto IL_0031;
						IL_0031:
						num = 6;
						array [2] = "Left";
						goto IL_003c;
						IL_003c:
						num = 7;
						array [3] = "Top";
						goto IL_0047;
						IL_0047:
						num = 8;
						array [4] = "Width";
						goto IL_0052;
						IL_0052:
						num = 9;
						array [5] = "Height";
						goto IL_005e;
						IL_005e:
						num = 10;
						array [6] = "SctLeft";
						goto IL_006a;
						IL_006a:
						num = 11;
						array [7] = "SctTop";
						goto IL_0076;
						IL_0076:
						num = 12;
						array [8] = "SctWidth";
						goto IL_0082;
						IL_0082:
						num = 13;
						array [9] = "SctHeight";
						goto IL_008f;
						IL_008f:
						num = 14;
						array [10] = "AnlLeft";
						goto IL_009c;
						IL_009c:
						num = 15;
						array [11] = "AnlTop";
						goto IL_00a9;
						IL_00a9:
						num = 16;
						array [12] = "AnlWidth";
						goto IL_00b6;
						IL_00b6:
						num = 17;
						array [13] = "AnlHeight";
						goto IL_00c3;
						IL_00c3:
						num = 18;
						if (bytAction == 0) {
							goto IL_00cc;
						}
						goto IL_0351;
						IL_00cc:
						num = 19;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_00dd;
						IL_00dd:
						num = 20;
						if (registryKey != null) {
							goto IL_00e4;
						}
						goto IL_012a;
						IL_00e4:
						num = 21;
						num6 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_011b;
						IL_011b:
						if (num5 <= num6) {
							goto IL_00f6;
						}
						goto IL_0120;
						IL_0120:
						num = 24;
						registryKey.Close ();
						goto IL_012a;
						IL_00f6:
						num = 22;
						array2 [num5] = Conversions.ToInteger (registryKey.GetValue (array [num5], 0));
						goto IL_0113;
						IL_0113:
						num = 23;
						num5 = (short)unchecked(num5 + 1);
						goto IL_011b;
						IL_012a:
						num = 25;
						if ((array2 [1] != 0) & (array2 [1] != 1) & (array2 [1] != 2)) {
							goto IL_014c;
						}
						goto IL_0154;
						IL_014c:
						num = 26;
						array2 [1] = 0;
						goto IL_0154;
						IL_0154:
						num = 27;
						workingArea = Screen.GetWorkingArea (new Point (0, 0));
						goto IL_0165;
						IL_0165:
						num = 28;
						if (array2 [4] <= 0) {
							goto IL_016f;
						}
						goto IL_0185;
						IL_016f:
						num = 29;
						array2 [4] = My.MyProject.Forms.mdiCFS.Width;
						goto IL_0185;
						IL_0185:
						num = 30;
						if (array2 [4] > workingArea.Width) {
							goto IL_0195;
						}
						goto IL_01a3;
						IL_0195:
						num = 31;
						array2 [4] = workingArea.Width;
						goto IL_01a3;
						IL_01a3:
						num = 32;
						if (array2 [5] <= 0) {
							goto IL_01ad;
						}
						goto IL_01c3;
						IL_01ad:
						num = 33;
						array2 [5] = My.MyProject.Forms.mdiCFS.Height;
						goto IL_01c3;
						IL_01c3:
						num = 34;
						if (array2 [5] > workingArea.Height) {
							goto IL_01d3;
						}
						goto IL_01e1;
						IL_01d3:
						num = 35;
						array2 [5] = workingArea.Height;
						goto IL_01e1;
						IL_01e1:
						num = 36;
						if (array2 [2] <= 0) {
							goto IL_01eb;
						}
						goto IL_0201;
						IL_01eb:
						num = 37;
						array2 [2] = My.MyProject.Forms.mdiCFS.Left;
						goto IL_0201;
						IL_0201:
						num = 38;
						if (array2 [2] + array2 [4] > workingArea.Width) {
							goto IL_0216;
						}
						goto IL_0229;
						IL_0216:
						num = 39;
						array2 [2] = workingArea.Width - array2 [4];
						goto IL_0229;
						IL_0229:
						num = 40;
						if (array2 [3] <= 0) {
							goto IL_0233;
						}
						goto IL_0249;
						IL_0233:
						num = 41;
						array2 [3] = My.MyProject.Forms.mdiCFS.Top;
						goto IL_0249;
						IL_0249:
						num = 42;
						if (array2 [3] + array2 [5] > workingArea.Height) {
							goto IL_025e;
						}
						goto IL_0271;
						IL_025e:
						num = 43;
						array2 [3] = workingArea.Height - array2 [5];
						goto IL_0271;
						IL_0271:
						num = 44;
						My.MyProject.Forms.mdiCFS.Left = array2 [2];
						goto IL_0287;
						IL_0287:
						num = 45;
						My.MyProject.Forms.mdiCFS.Top = array2 [3];
						goto IL_029d;
						IL_029d:
						num = 46;
						My.MyProject.Forms.mdiCFS.Width = array2 [4];
						goto IL_02b3;
						IL_02b3:
						num = 47;
						My.MyProject.Forms.mdiCFS.Height = array2 [5];
						goto IL_02c9;
						IL_02c9:
						num = 48;
						My.MyProject.Forms.mdiCFS.WindowState = unchecked((FormWindowState)array2 [1]);
						goto IL_02df;
						IL_02df:
						num = 49;
						SctInpLeft = array2 [6];
						goto IL_02ec;
						IL_02ec:
						num = 50;
						SctInpTop = array2 [7];
						goto IL_02f9;
						IL_02f9:
						num = 51;
						SctInpWidth = array2 [8];
						goto IL_0306;
						IL_0306:
						num = 52;
						SctInpHeight = array2 [9];
						goto IL_0314;
						IL_0314:
						num = 53;
						AnlInpLeft = array2 [10];
						goto IL_0322;
						IL_0322:
						num = 54;
						AnlInpTop = array2 [11];
						goto IL_0330;
						IL_0330:
						num = 55;
						AnlInpWidth = array2 [12];
						goto IL_033e;
						IL_033e:
						num = 56;
						AnlInpHeight = array2 [13];
						goto end_IL_0000_3;
						IL_0351:
						num = 58;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_035b;
						IL_035b:
						num = 59;
						b = (byte)My.MyProject.Forms.mdiCFS.WindowState;
						goto IL_0370;
						IL_0370:
						num = 60;
						My.MyProject.Forms.mdiCFS.WindowState = FormWindowState.Normal;
						goto IL_0383;
						IL_0383:
						num = 61;
						array2 [1] = b;
						goto IL_038c;
						IL_038c:
						num = 62;
						array2 [2] = My.MyProject.Forms.mdiCFS.Left;
						goto IL_03a2;
						IL_03a2:
						num = 63;
						array2 [3] = My.MyProject.Forms.mdiCFS.Top;
						goto IL_03b8;
						IL_03b8:
						num = 64;
						array2 [4] = My.MyProject.Forms.mdiCFS.Width;
						goto IL_03ce;
						IL_03ce:
						num = 65;
						array2 [5] = My.MyProject.Forms.mdiCFS.Height;
						goto IL_03e4;
						IL_03e4:
						num = 66;
						array2 [6] = (int)System.Math.Round (SctInpLeft);
						goto IL_03f7;
						IL_03f7:
						num = 67;
						array2 [7] = (int)System.Math.Round (SctInpTop);
						goto IL_040a;
						IL_040a:
						num = 68;
						array2 [8] = (int)System.Math.Round (SctInpWidth);
						goto IL_041d;
						IL_041d:
						num = 69;
						array2 [9] = (int)System.Math.Round (SctInpHeight);
						goto IL_0431;
						IL_0431:
						num = 70;
						array2 [10] = (int)System.Math.Round (AnlInpLeft);
						goto IL_0445;
						IL_0445:
						num = 71;
						array2 [11] = (int)System.Math.Round (AnlInpTop);
						goto IL_0459;
						IL_0459:
						num = 72;
						array2 [12] = (int)System.Math.Round (AnlInpWidth);
						goto IL_046d;
						IL_046d:
						num = 73;
						array2 [13] = (int)System.Math.Round (AnlInpHeight);
						goto IL_0481;
						IL_0481:
						num = 74;
						My.MyProject.Forms.mdiCFS.WindowState = FormWindowState.Minimized;
						goto IL_0494;
						IL_0494:
						num = 75;
						My.MyProject.Forms.mdiCFS.Hide ();
						goto IL_04a6;
						IL_04a6:
						num = 76;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_04b7;
						IL_04b7:
						num = 77;
						num7 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_04e9;
						IL_04e9:
						if (num5 > num7) {
							break;
						}
						goto IL_04c9;
						IL_04c9:
						num = 78;
						registryKey2.SetValue (array [num5], array2 [num5], RegistryValueKind.DWord);
						goto IL_04e1;
						end_IL_0000_2:
						break;
					}
					num = 80;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1617;
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

	public static void RegistryCombinations (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		float[] array = default(float[]);
		short num5 = default(short);
		short num6 = default(short);
		ref LoadCombination reference = default(ref LoadCombination);
		string name = default(string);
		string name2 = default(string);
		string name3 = default(string);
		string text2 = default(string);
		short[] array2 = default(short[]);
		RegistryKey registryKey = default(RegistryKey);
		byte[] array3 = default(byte[]);
		short num7 = default(short);
		short num8 = default(short);
		short num9 = default(short);
		short num10 = default(short);
		short num11 = default(short);
		short intUserCombs = default(short);
		short num12 = default(short);
		ref LoadCombination reference2 = default(ref LoadCombination);
		short num13 = default(short);
		RegistryKey registryKey2 = default(RegistryKey);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						text = "Software\\RSG Software, Inc.\\CFS\\Combinations";
						goto IL_0009;
					case 2562:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_0009;
							case 3:
								goto IL_0012;
							case 4:
								goto IL_001b;
							case 5:
								goto IL_0024;
							case 6:
								goto IL_002d;
							case 7:
								goto IL_0037;
							case 8:
								goto IL_0041;
							case 9:
								goto IL_0048;
							case 10:
								goto IL_0051;
							case 11:
								goto IL_0062;
							case 12:
								goto IL_006c;
							case 13:
								goto IL_0084;
							case 14:
								goto IL_008f;
							case 15:
								goto IL_00a4;
							case 16:
								goto IL_00aa;
							case 17:
								goto IL_00b7;
							case 18:
								goto IL_00c1;
							case 19:
								goto IL_00d6;
							case 20:
								goto IL_00dc;
							case 21:
								goto IL_00ea;
							case 22:
								goto IL_0115;
							case 24:
								goto IL_0132;
							case 23:
							case 25:
								goto IL_013b;
							case 26:
								goto IL_014c;
							case 27:
								goto IL_015b;
							case 28:
								goto IL_017c;
							case 29:
								goto IL_018c;
							case 30:
								goto IL_0199;
							case 31:
								goto IL_01a4;
							case 32:
								goto IL_01b9;
							case 33:
								goto IL_01cc;
							case 34:
								goto IL_01dd;
							case 35:
								goto IL_01ee;
							case 36:
								goto IL_01fb;
							case 37:
								goto IL_0205;
							case 38:
								goto IL_020f;
							case 39:
								goto IL_021d;
							case 40:
								goto IL_0236;
							case 41:
								goto IL_024b;
							case 43:
								goto IL_0264;
							case 44:
								goto IL_0278;
							case 45:
								goto IL_027e;
							case 46:
								goto IL_028f;
							case 47:
								goto IL_02a8;
							case 48:
								goto IL_02bc;
							case 49:
								goto IL_02d3;
							case 51:
								goto IL_02dd;
							case 52:
								goto IL_02ed;
							case 53:
								goto IL_0309;
							case 54:
								goto IL_0319;
							case 55:
								goto IL_032f;
							case 56:
								goto IL_034f;
							case 57:
								goto IL_0365;
							case 58:
								goto IL_0385;
							case 59:
								goto IL_039b;
							case 60:
								goto IL_03bb;
							case 61:
								goto IL_03c6;
							case 62:
								goto IL_03dc;
							case 63:
								goto IL_03f6;
							case 64:
								goto IL_040c;
							case 65:
								goto IL_042c;
							case 66:
								goto IL_0442;
							case 67:
								goto IL_0462;
							case 68:
								goto IL_0478;
							case 69:
								goto IL_0498;
							case 70:
								goto IL_04ae;
							case 72:
								goto IL_04d3;
							case 73:
								goto IL_04e9;
							case 74:
								goto IL_0509;
							case 75:
								goto IL_051f;
							case 76:
								goto IL_053f;
							case 77:
								goto IL_0555;
							case 78:
								goto IL_0575;
							case 79:
								goto IL_058b;
							case 80:
								goto IL_05ab;
							case 81:
								goto IL_05c1;
							case 71:
							case 82:
							case 83:
								goto IL_05e1;
							case 84:
								goto IL_05e8;
							case 86:
								goto IL_05fd;
							case 87:
								goto IL_0607;
							case 88:
								goto IL_060d;
							case 89:
								goto IL_0620;
							case 90:
								goto IL_0637;
							case 91:
								goto IL_0641;
							case 92:
								goto IL_0655;
							case 93:
								goto IL_0667;
							case 94:
								goto IL_067f;
							case 95:
								goto IL_068d;
							case 96:
								goto IL_06ac;
							case 97:
								goto IL_06cb;
							case 98:
								goto IL_06ea;
							case 99:
								goto IL_0709;
							case 100:
								goto IL_0728;
							case 101:
								goto IL_0747;
							case 102:
								goto IL_0766;
							case 103:
							case 104:
								goto IL_0785;
							case 105:
								goto IL_0795;
							case 106:
								goto IL_07a6;
							case 107:
								goto IL_07b5;
							case 108:
								goto IL_07c0;
							case 109:
								goto IL_07d6;
							case 111:
								goto IL_07ee;
							case 112:
								goto IL_07f9;
							case 113:
								goto IL_0808;
							case 110:
							case 114:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 42:
							case 50:
							case 85:
							case 115:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0747:
						num = 101;
						array [(short)unchecked(num5 * num6) + 6] = reference.LF [7].fLdg;
						goto IL_0766;
						IL_0009:
						num = 2;
						name = "Names";
						goto IL_0012;
						IL_0012:
						num = 3;
						name2 = "LoadFactors8";
						goto IL_001b;
						IL_001b:
						num = 4;
						name3 = "Specs";
						goto IL_0024;
						IL_0024:
						num = 5;
						text2 = string.Empty;
						goto IL_002d;
						IL_002d:
						num = 6;
						array2 = new short[1];
						goto IL_0037;
						IL_0037:
						num = 7;
						array = new float[1];
						goto IL_0041;
						IL_0041:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0048;
						IL_0048:
						num = 9;
						if (bytAction == 0) {
							goto IL_0051;
						}
						goto IL_05fd;
						IL_0051:
						num = 10;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_0062;
						IL_0062:
						num = 11;
						if (registryKey != null) {
							goto IL_006c;
						}
						goto IL_0205;
						IL_006c:
						num = 12;
						text2 = Conversions.ToString (registryKey.GetValue (name, string.Empty));
						goto IL_0084;
						IL_0084:
						num = 13;
						array3 = new byte[0];
						goto IL_008f;
						IL_008f:
						num = 14;
						array3 = (byte[])registryKey.GetValue (name2, array3);
						goto IL_00a4;
						IL_00a4:
						num = 15;
						num5 = 8;
						goto IL_00aa;
						IL_00aa:
						num = 16;
						if (array3 == null || array3.Length == 0) {
							goto IL_00b7;
						}
						goto IL_00dc;
						IL_0766:
						num = 102;
						array [(short)unchecked(num5 * num6) + 7] = reference.LF [8].fLdg;
						goto IL_0785;
						IL_00b7:
						num = 17;
						name2 = "LoadFactors";
						goto IL_00c1;
						IL_00c1:
						num = 18;
						array3 = (byte[])registryKey.GetValue (name2, array3);
						goto IL_00d6;
						IL_00d6:
						num = 19;
						num5 = 7;
						goto IL_00dc;
						IL_00dc:
						num = 20;
						if (array3 != null && array3.Length > 0) {
							goto IL_00ea;
						}
						goto IL_0132;
						IL_0785:
						num = 104;
						num6 = (short)unchecked(num6 + 1);
						goto IL_078d;
						IL_00ea:
						num = 21;
						array = new float[(int)System.Math.Round ((double)array3.Length / 4.0 - 1.0) + 1];
						goto IL_0115;
						IL_0115:
						num = 22;
						CFS.intUserCombs = (short)System.Math.Round ((double)Information.UBound (array) / (double)num5);
						goto IL_013b;
						IL_0132:
						num = 24;
						CFS.intUserCombs = 0;
						goto IL_013b;
						IL_013b:
						num = 25;
						num7 = (short)(CFS.intUserCombs - 1);
						num6 = 0;
						goto IL_0194;
						IL_0194:
						if (num6 <= num7) {
							goto IL_014c;
						}
						goto IL_0199;
						IL_0199:
						num = 30;
						array3 = new byte[0];
						goto IL_01a4;
						IL_01a4:
						num = 31;
						array3 = (byte[])registryKey.GetValue (name3, array3);
						goto IL_01b9;
						IL_01b9:
						num = 32;
						array2 = new short[CFS.intUserCombs - 1 + 1];
						goto IL_01cc;
						IL_01cc:
						num = 33;
						num8 = (short)(CFS.intUserCombs - 1);
						num6 = 0;
						goto IL_01f6;
						IL_01f6:
						if (num6 <= num8) {
							goto IL_01dd;
						}
						goto IL_01fb;
						IL_01fb:
						num = 36;
						registryKey.Close ();
						goto IL_0205;
						IL_01dd:
						num = 34;
						array2 [num6] = BitConverter.ToInt16 (array3, 2 * num6);
						goto IL_01ee;
						IL_01ee:
						num = 35;
						num6 = (short)unchecked(num6 + 1);
						goto IL_01f6;
						IL_014c:
						num = 26;
						num9 = (short)(num5 - 1);
						num10 = 0;
						goto IL_0186;
						IL_0186:
						if (num10 <= num9) {
							goto IL_015b;
						}
						goto IL_018c;
						IL_018c:
						num = 29;
						num6 = (short)unchecked(num6 + 1);
						goto IL_0194;
						IL_015b:
						num = 27;
						array [(short)unchecked(checked((short)unchecked(num5 * num6)) + num10)] = BitConverter.ToSingle (array3, 4 * (short)unchecked(checked((short)unchecked(num5 * num6)) + num10));
						goto IL_017c;
						IL_017c:
						num = 28;
						num10 = (short)unchecked(num10 + 1);
						goto IL_0186;
						IL_0205:
						num = 37;
						if (CFS.intUserCombs == 0) {
							goto IL_020f;
						}
						goto IL_0264;
						IL_020f:
						num = 38;
						CFS.UserComb = new LoadCombination[2];
						goto IL_021d;
						IL_021d:
						num = 39;
						CFS.UserComb [1] = new LoadCombination ("Combination 1", 8);
						goto IL_0236;
						IL_0236:
						num = 40;
						CFS.UserComb [1].Spec = 37;
						goto IL_024b;
						IL_024b:
						num = 41;
						CFS.UserComb [1].nLF = 8;
						goto end_IL_0000_3;
						IL_0264:
						num = 43;
						CFS.UserComb = new LoadCombination[CFS.intUserCombs + 1];
						goto IL_0278;
						IL_0278:
						num = 44;
						num11 = 0;
						goto IL_027e;
						IL_027e:
						num = 45;
						intUserCombs = CFS.intUserCombs;
						num6 = 1;
						goto IL_05f0;
						IL_05f0:
						if (num6 > intUserCombs) {
							goto end_IL_0000_3;
						}
						goto IL_028f;
						IL_028f:
						num = 46;
						CFS.UserComb [num6] = new LoadCombination (string.Empty, 8);
						goto IL_02a8;
						IL_02a8:
						num = 47;
						CFS.UserComb [num6].nLF = 8;
						goto IL_02bc;
						IL_02bc:
						num = 48;
						num12 = (short)Strings.InStr (num11 + 1, text2, "\v");
						goto IL_02d3;
						IL_02d3:
						num = 49;
						if (num12 == 0) {
							goto end_IL_0000_3;
						}
						goto IL_02dd;
						IL_02dd:
						num = 51;
						reference2 = ref CFS.UserComb [num6];
						goto IL_02ed;
						IL_02ed:
						num = 52;
						reference2.Description = Strings.Mid (text2, num11 + 1, num12 - (num11 + 1));
						goto IL_0309;
						IL_0309:
						num = 53;
						reference2.Spec = array2 [num6 - 1];
						goto IL_0319;
						IL_0319:
						num = 54;
						reference2.LF [1].iLdg = 0;
						goto IL_032f;
						IL_032f:
						num = 55;
						reference2.LF [1].fLdg = array [num5 * (num6 - 1) + 0];
						goto IL_034f;
						IL_034f:
						num = 56;
						reference2.LF [2].iLdg = 1;
						goto IL_0365;
						IL_0365:
						num = 57;
						reference2.LF [2].fLdg = array [num5 * (num6 - 1) + 1];
						goto IL_0385;
						IL_0385:
						num = 58;
						reference2.LF [3].iLdg = 2;
						goto IL_039b;
						IL_039b:
						num = 59;
						reference2.LF [3].fLdg = array [num5 * (num6 - 1) + 2];
						goto IL_03bb;
						IL_03bb:
						num = 60;
						if (num5 == 7) {
							goto IL_03c6;
						}
						goto IL_04d3;
						IL_03c6:
						num = 61;
						reference2.LF [4].iLdg = 3;
						goto IL_03dc;
						IL_03dc:
						num = 62;
						reference2.LF [4].fLdg = 0f;
						goto IL_03f6;
						IL_03f6:
						num = 63;
						reference2.LF [5].iLdg = 4;
						goto IL_040c;
						IL_040c:
						num = 64;
						reference2.LF [5].fLdg = array [num5 * (num6 - 1) + 3];
						goto IL_042c;
						IL_042c:
						num = 65;
						reference2.LF [6].iLdg = 5;
						goto IL_0442;
						IL_0442:
						num = 66;
						reference2.LF [6].fLdg = array [num5 * (num6 - 1) + 4];
						goto IL_0462;
						IL_0462:
						num = 67;
						reference2.LF [7].iLdg = 6;
						goto IL_0478;
						IL_0478:
						num = 68;
						reference2.LF [7].fLdg = array [num5 * (num6 - 1) + 5];
						goto IL_0498;
						IL_0498:
						num = 69;
						reference2.LF [8].iLdg = 7;
						goto IL_04ae;
						IL_04ae:
						num = 70;
						reference2.LF [8].fLdg = array [num5 * (num6 - 1) + 6];
						goto IL_05e1;
						IL_04d3:
						num = 72;
						reference2.LF [4].iLdg = 3;
						goto IL_04e9;
						IL_04e9:
						num = 73;
						reference2.LF [4].fLdg = array [num5 * (num6 - 1) + 3];
						goto IL_0509;
						IL_0509:
						num = 74;
						reference2.LF [5].iLdg = 4;
						goto IL_051f;
						IL_051f:
						num = 75;
						reference2.LF [5].fLdg = array [num5 * (num6 - 1) + 4];
						goto IL_053f;
						IL_053f:
						num = 76;
						reference2.LF [6].iLdg = 5;
						goto IL_0555;
						IL_0555:
						num = 77;
						reference2.LF [6].fLdg = array [num5 * (num6 - 1) + 5];
						goto IL_0575;
						IL_0575:
						num = 78;
						reference2.LF [7].iLdg = 6;
						goto IL_058b;
						IL_058b:
						num = 79;
						reference2.LF [7].fLdg = array [num5 * (num6 - 1) + 6];
						goto IL_05ab;
						IL_05ab:
						num = 80;
						reference2.LF [8].iLdg = 7;
						goto IL_05c1;
						IL_05c1:
						num = 81;
						reference2.LF [8].fLdg = array [num5 * (num6 - 1) + 7];
						goto IL_05e1;
						IL_05e1:
						num = 83;
						num11 = num12;
						goto IL_05e8;
						IL_05e8:
						num = 84;
						num6 = (short)unchecked(num6 + 1);
						goto IL_05f0;
						IL_05fd:
						num = 86;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_0607;
						IL_0607:
						num = 87;
						num5 = 8;
						goto IL_060d;
						IL_060d:
						num = 88;
						array2 = new short[CFS.intUserCombs - 1 + 1];
						goto IL_0620;
						IL_0620:
						num = 89;
						array = new float[(short)unchecked(num5 * CFS.intUserCombs) - 1 + 1];
						goto IL_0637;
						IL_0637:
						num = 90;
						text2 = string.Empty;
						goto IL_0641;
						IL_0641:
						num = 91;
						num13 = (short)(CFS.intUserCombs - 1);
						num6 = 0;
						goto IL_078d;
						IL_078d:
						if (num6 <= num13) {
							goto IL_0655;
						}
						goto IL_0795;
						IL_0795:
						num = 105;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_07a6;
						IL_07a6:
						num = 106;
						registryKey2.SetValue (name, text2, RegistryValueKind.String);
						goto IL_07b5;
						IL_07b5:
						num = 107;
						if (CFS.intUserCombs > 0) {
							goto IL_07c0;
						}
						goto IL_07ee;
						IL_07c0:
						num = 108;
						registryKey2.SetValue (name2, ByteArray (array), RegistryValueKind.Binary);
						goto IL_07d6;
						IL_07d6:
						num = 109;
						registryKey2.SetValue (name3, ByteArray (array2), RegistryValueKind.Binary);
						break;
						IL_07ee:
						num = 111;
						array3 = new byte[0];
						goto IL_07f9;
						IL_07f9:
						num = 112;
						registryKey2.SetValue (name2, array3, RegistryValueKind.Binary);
						goto IL_0808;
						IL_0808:
						num = 113;
						registryKey2.SetValue (name3, array3, RegistryValueKind.Binary);
						break;
						IL_0655:
						num = 92;
						reference = ref CFS.UserComb [num6 + 1];
						goto IL_0667;
						IL_0667:
						num = 93;
						text2 = text2 + reference.Description + "\v";
						goto IL_067f;
						IL_067f:
						num = 94;
						array2 [num6] = reference.Spec;
						goto IL_068d;
						IL_068d:
						num = 95;
						array [(short)unchecked(num5 * num6) + 0] = reference.LF [1].fLdg;
						goto IL_06ac;
						IL_06ac:
						num = 96;
						array [(short)unchecked(num5 * num6) + 1] = reference.LF [2].fLdg;
						goto IL_06cb;
						IL_06cb:
						num = 97;
						array [(short)unchecked(num5 * num6) + 2] = reference.LF [3].fLdg;
						goto IL_06ea;
						IL_06ea:
						num = 98;
						array [(short)unchecked(num5 * num6) + 3] = reference.LF [4].fLdg;
						goto IL_0709;
						IL_0709:
						num = 99;
						array [(short)unchecked(num5 * num6) + 4] = reference.LF [5].fLdg;
						goto IL_0728;
						IL_0728:
						num = 100;
						array [(short)unchecked(num5 * num6) + 5] = reference.LF [6].fLdg;
						goto IL_0747;
						end_IL_0000_2:
						break;
					}
					num = 114;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 2562;
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

	public static void RegistryHeading (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string[] array = default(string[]);
		int num2 = default(int);
		int num3 = default(int);
		short num5 = default(short);
		string[] array2 = default(string[]);
		string text = default(string);
		string systemDirectory = default(string);
		object objectValue = default(object);
		object objectValue2 = default(object);
		RegistryKey registryKey = default(RegistryKey);
		short num6 = default(short);
		RegistryKey registryKey2 = default(RegistryKey);
		short num7 = default(short);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						array = new string[8];
						goto IL_000a;
					case 1297:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_000a;
							case 3:
								goto IL_0014;
							case 4:
								goto IL_001d;
							case 5:
								goto IL_0024;
							case 6:
								goto IL_002f;
							case 7:
								goto IL_003a;
							case 8:
								goto IL_0045;
							case 9:
								goto IL_0050;
							case 10:
								goto IL_005c;
							case 11:
								goto IL_0068;
							case 12:
								goto IL_0074;
							case 13:
								goto IL_007e;
							case 14:
								goto IL_0097;
							case 15:
								goto IL_00c2;
							case 16:
								goto IL_00e1;
							case 17:
								goto IL_00ea;
							case 18:
								goto IL_0112;
							case 19:
								goto IL_0124;
							case 20:
								goto IL_0136;
							case 21:
								goto IL_0148;
							case 22:
								goto IL_015a;
							case 23:
								goto IL_016c;
							case 24:
								goto IL_0194;
							case 25:
								goto IL_01a5;
							case 26:
								goto IL_01af;
							case 27:
								goto IL_01c1;
							case 28:
								goto IL_01dd;
							case 30:
								goto IL_0206;
							case 32:
								goto IL_021a;
							case 29:
							case 31:
							case 33:
							case 34:
								goto IL_022c;
							case 35:
								goto IL_0239;
							case 36:
								goto IL_0243;
							case 37:
								goto IL_0254;
							case 38:
								goto IL_0265;
							case 39:
								goto IL_0276;
							case 40:
								goto IL_0287;
							case 41:
								goto IL_0298;
							case 42:
								goto IL_02a9;
							case 43:
								goto IL_02ba;
							case 44:
								goto IL_02ce;
							case 45:
								goto IL_02f6;
							case 46:
								goto IL_030d;
							case 48:
								goto IL_033a;
							case 49:
								goto IL_0344;
							case 50:
								goto IL_0355;
							case 51:
								goto IL_0366;
							case 52:
								goto IL_0377;
							case 53:
								goto IL_0388;
							case 54:
								goto IL_0399;
							case 55:
								goto IL_03aa;
							case 56:
								goto IL_03bb;
							case 57:
								goto IL_03cc;
							case 58:
								goto IL_03de;
							case 59:
								goto IL_03f1;
							case 60:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 47:
							case 61:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_03f1:
						num = 59;
						num5 = (short)unchecked(num5 + 1);
						goto IL_03f9;
						IL_000a:
						num = 2;
						array2 = new string[8];
						goto IL_0014;
						IL_0014:
						num = 3;
						text = "Software\\RSG Software, Inc.\\CFS\\Heading";
						goto IL_001d;
						IL_001d:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0024;
						IL_0024:
						num = 5;
						array [1] = "Hdg1";
						goto IL_002f;
						IL_002f:
						num = 6;
						array [2] = "Hdg2";
						goto IL_003a;
						IL_003a:
						num = 7;
						array [3] = "Hdg3";
						goto IL_0045;
						IL_0045:
						num = 8;
						array [4] = "Email";
						goto IL_0050;
						IL_0050:
						num = 9;
						array [5] = "Tel";
						goto IL_005c;
						IL_005c:
						num = 10;
						array [6] = "Fax";
						goto IL_0068;
						IL_0068:
						num = 11;
						array [7] = "User";
						goto IL_0074;
						IL_0074:
						num = 12;
						systemDirectory = Environment.SystemDirectory;
						goto IL_007e;
						IL_007e:
						num = 13;
						objectValue = RuntimeHelpers.GetObjectValue (Interaction.CreateObject ("Scripting.FileSystemObject"));
						goto IL_0097;
						IL_0097:
						num = 14;
						objectValue2 = RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (objectValue, null, "GetDrive", new object[1] { Strings.Left (systemDirectory, 1) }, null, null, null));
						goto IL_00c2;
						IL_00c2:
						num = 15;
						Conversions.ToInteger (NewLateBinding.LateGet (objectValue2, null, "SerialNumber", new object[0], null, null, null));
						goto IL_00e1;
						IL_00e1:
						num = 16;
						if (bytAction == 0) {
							goto IL_00ea;
						}
						goto IL_033a;
						IL_00ea:
						num = 17;
						CFS.User.Company = Strings.Left (Environment.GetEnvironmentVariable ("USERDOMAIN") + string.Empty, 40);
						goto IL_0112;
						IL_0112:
						num = 18;
						CFS.User.Address1 = string.Empty;
						goto IL_0124;
						IL_0124:
						num = 19;
						CFS.User.Address2 = string.Empty;
						goto IL_0136;
						IL_0136:
						num = 20;
						CFS.User.Email = string.Empty;
						goto IL_0148;
						IL_0148:
						num = 21;
						CFS.User.Phone = string.Empty;
						goto IL_015a;
						IL_015a:
						num = 22;
						CFS.User.Fax = string.Empty;
						goto IL_016c;
						IL_016c:
						num = 23;
						CFS.User.Name = Strings.Left (Environment.GetEnvironmentVariable ("USERNAME") + string.Empty, 40);
						goto IL_0194;
						IL_0194:
						num = 24;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_01a5;
						IL_01a5:
						num = 25;
						if (registryKey == null) {
							goto end_IL_0000_3;
						}
						goto IL_01af;
						IL_01af:
						num = 26;
						num6 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_0234;
						IL_0234:
						if (num5 <= num6) {
							goto IL_01c1;
						}
						goto IL_0239;
						IL_0239:
						num = 35;
						registryKey.Close ();
						goto IL_0243;
						IL_0243:
						num = 36;
						CFS.User.Company = array2 [1];
						goto IL_0254;
						IL_0254:
						num = 37;
						CFS.User.Address1 = array2 [2];
						goto IL_0265;
						IL_0265:
						num = 38;
						CFS.User.Address2 = array2 [3];
						goto IL_0276;
						IL_0276:
						num = 39;
						CFS.User.Email = array2 [4];
						goto IL_0287;
						IL_0287:
						num = 40;
						CFS.User.Phone = array2 [5];
						goto IL_0298;
						IL_0298:
						num = 41;
						CFS.User.Fax = array2 [6];
						goto IL_02a9;
						IL_02a9:
						num = 42;
						CFS.User.Name = array2 [7];
						goto IL_02ba;
						IL_02ba:
						num = 43;
						if (CFS.User.Company.Length == 0) {
							goto IL_02ce;
						}
						goto IL_02f6;
						IL_02ce:
						num = 44;
						CFS.User.Company = Strings.Left (Environment.GetEnvironmentVariable ("USERDOMAIN") + string.Empty, 40);
						goto IL_02f6;
						IL_02f6:
						num = 45;
						if (CFS.User.Name.Length != 0) {
							goto end_IL_0000_3;
						}
						goto IL_030d;
						IL_030d:
						num = 46;
						CFS.User.Name = Strings.Left (Environment.GetEnvironmentVariable ("USERNAME") + string.Empty, 40);
						goto end_IL_0000_3;
						IL_01c1:
						num = 27;
						array2 [num5] = Conversions.ToString (registryKey.GetValue (array [num5], string.Empty));
						goto IL_01dd;
						IL_01dd:
						num = 28;
						switch (num5) {
						case 1:
						case 2:
						case 3:
						case 4:
						case 7:
							break;
						case 5:
						case 6:
							goto IL_021a;
						default:
							goto IL_022c;
						}
						goto IL_0206;
						IL_021a:
						num = 32;
						array2 [num5] = Strings.Left (array2 [num5], 16);
						goto IL_022c;
						IL_0206:
						num = 30;
						array2 [num5] = Strings.Left (array2 [num5], 40);
						goto IL_022c;
						IL_022c:
						num = 34;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0234;
						IL_033a:
						num = 48;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_0344;
						IL_0344:
						num = 49;
						array2 [1] = CFS.User.Company;
						goto IL_0355;
						IL_0355:
						num = 50;
						array2 [2] = CFS.User.Address1;
						goto IL_0366;
						IL_0366:
						num = 51;
						array2 [3] = CFS.User.Address2;
						goto IL_0377;
						IL_0377:
						num = 52;
						array2 [4] = CFS.User.Email;
						goto IL_0388;
						IL_0388:
						num = 53;
						array2 [5] = CFS.User.Phone;
						goto IL_0399;
						IL_0399:
						num = 54;
						array2 [6] = CFS.User.Fax;
						goto IL_03aa;
						IL_03aa:
						num = 55;
						array2 [7] = CFS.User.Name;
						goto IL_03bb;
						IL_03bb:
						num = 56;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_03cc;
						IL_03cc:
						num = 57;
						num7 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_03f9;
						IL_03f9:
						if (num5 > num7) {
							break;
						}
						goto IL_03de;
						IL_03de:
						num = 58;
						registryKey2.SetValue (array [num5], array2 [num5], RegistryValueKind.String);
						goto IL_03f1;
						end_IL_0000_2:
						break;
					}
					num = 60;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1297;
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

	public static void RegistryMaterial (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		RegistryKey registryKey = default(RegistryKey);
		string name = default(string);
		string name2 = default(string);
		string name3 = default(string);
		RegistryKey registryKey2 = default(RegistryKey);
		byte[] array = default(byte[]);
		MaterialType materialType = default(MaterialType);
		short num5 = default(short);
		MaterialType materialType2 = default(MaterialType);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						text = "Software\\RSG Software, Inc.\\CFS\\Material";
						goto IL_0008;
					case 1576:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_0008;
							case 3:
								goto IL_0011;
							case 4:
								goto IL_001a;
							case 5:
								goto IL_0023;
							case 6:
								goto IL_002a;
							case 7:
								goto IL_0032;
							case 8:
								goto IL_003e;
							case 9:
								goto IL_0046;
							case 10:
								goto IL_004f;
							case 11:
								goto IL_005f;
							case 12:
								goto IL_0069;
							case 13:
								goto IL_006f;
							case 14:
								goto IL_0084;
							case 15:
								goto IL_0099;
							case 16:
								goto IL_00a3;
							case 17:
								goto IL_00c5;
							case 18:
								goto IL_00cb;
							case 19:
								goto IL_00e8;
							case 20:
								goto IL_00f7;
							case 21:
								goto IL_00fd;
							case 22:
								goto IL_011a;
							case 23:
								goto IL_0129;
							case 24:
								goto IL_012f;
							case 25:
								goto IL_014c;
							case 26:
								goto IL_015b;
							case 27:
								goto IL_016e;
							case 28:
								goto IL_0181;
							case 29:
								goto IL_0194;
							case 30:
								goto IL_01a7;
							case 31:
								goto IL_01b2;
							case 32:
								goto IL_01c5;
							case 33:
								goto IL_01d8;
							case 34:
								goto IL_01eb;
							case 36:
								goto IL_0206;
							case 37:
								goto IL_0215;
							case 38:
								goto IL_0224;
							case 35:
							case 39:
								goto IL_0233;
							case 40:
								goto IL_023d;
							case 41:
								goto IL_0240;
							case 42:
								goto IL_0246;
							case 43:
								goto IL_0263;
							case 44:
								goto IL_0271;
							case 45:
								goto IL_0284;
							case 46:
								goto IL_028a;
							case 47:
								goto IL_02a7;
							case 48:
								goto IL_02b5;
							case 49:
								goto IL_02c8;
							case 50:
								goto IL_02d2;
							case 52:
								goto IL_02e9;
							case 53:
								goto IL_02f3;
							case 54:
								goto IL_02ff;
							case 55:
								goto IL_0309;
							case 56:
								goto IL_032d;
							case 57:
								goto IL_0333;
							case 58:
								goto IL_0357;
							case 59:
								goto IL_037b;
							case 60:
								goto IL_039f;
							case 61:
								goto IL_03ae;
							case 62:
								goto IL_03c8;
							case 63:
								goto IL_03e2;
							case 64:
								goto IL_03fc;
							case 65:
								goto IL_0416;
							case 66:
								goto IL_0430;
							case 67:
								goto IL_044a;
							case 68:
								goto IL_0464;
							case 69:
								goto IL_0483;
							case 70:
								goto IL_0486;
							case 71:
								goto IL_0496;
							case 72:
								goto IL_04a5;
							case 73:
								goto IL_04c1;
							case 74:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 51:
							case 75:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0486:
						num = 70;
						registryKey = Registry.CurrentUser.CreateSubKey (text);
						goto IL_0496;
						IL_0008:
						num = 2;
						name = "Material";
						goto IL_0011;
						IL_0011:
						num = 3;
						name2 = "ColdWork";
						goto IL_001a;
						IL_001a:
						num = 4;
						name3 = "Reserve14";
						goto IL_0023;
						IL_0023:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_002a;
						IL_002a:
						num = 6;
						if (bytAction == 0) {
							goto IL_0032;
						}
						goto IL_02e9;
						IL_0032:
						num = 7;
						CFS.MaterialDefault = new MaterialType ();
						goto IL_003e;
						IL_003e:
						num = 8;
						CFS.blnColdWork = false;
						goto IL_0046;
						IL_0046:
						num = 9;
						CFS.blnReserve = false;
						goto IL_004f;
						IL_004f:
						num = 10;
						registryKey2 = Registry.CurrentUser.OpenSubKey (text);
						goto IL_005f;
						IL_005f:
						num = 11;
						if (registryKey2 != null) {
							goto IL_0069;
						}
						goto IL_02d2;
						IL_0069:
						num = 12;
						array = null;
						goto IL_006f;
						IL_006f:
						num = 13;
						array = (byte[])registryKey2.GetValue (name, array);
						goto IL_0084;
						IL_0084:
						num = 14;
						if (array != null && array.Length >= 100) {
							goto IL_0099;
						}
						goto IL_0240;
						IL_0496:
						num = 71;
						registryKey.SetValue (name, array, RegistryValueKind.Binary);
						goto IL_04a5;
						IL_0099:
						num = 15;
						materialType = CFS.MaterialDefault;
						goto IL_00a3;
						IL_00a3:
						num = 16;
						materialType.Name = Strings.Trim (Strings.Left (Encoding.ASCII.GetString (array), 24));
						goto IL_00c5;
						IL_00c5:
						num = 17;
						num5 = 1;
						goto IL_00cb;
						IL_00cb:
						num = 18;
						materialType.Eo [num5] = BitConverter.ToSingle (array, 24 + 4 * (num5 - 1));
						goto IL_00e8;
						IL_00e8:
						num = 19;
						num5 = (short)unchecked(num5 + 1);
						if (num5 <= 5) {
							goto IL_00cb;
						}
						goto IL_00f7;
						IL_00f7:
						num = 20;
						num5 = 1;
						goto IL_00fd;
						IL_00fd:
						num = 21;
						materialType.Fy [num5] = BitConverter.ToSingle (array, 44 + 4 * (num5 - 1));
						goto IL_011a;
						IL_011a:
						num = 22;
						num5 = (short)unchecked(num5 + 1);
						if (num5 <= 5) {
							goto IL_00fd;
						}
						goto IL_0129;
						IL_0129:
						num = 23;
						num5 = 1;
						goto IL_012f;
						IL_012f:
						num = 24;
						materialType.N [num5] = BitConverter.ToSingle (array, 64 + 4 * (num5 - 1));
						goto IL_014c;
						IL_014c:
						num = 25;
						num5 = (short)unchecked(num5 + 1);
						if (num5 <= 5) {
							goto IL_012f;
						}
						goto IL_015b;
						IL_015b:
						num = 26;
						materialType.Fu = BitConverter.ToSingle (array, 84);
						goto IL_016e;
						IL_016e:
						num = 27;
						materialType.FyMin = BitConverter.ToSingle (array, 88);
						goto IL_0181;
						IL_0181:
						num = 28;
						materialType.FuMin = BitConverter.ToSingle (array, 92);
						goto IL_0194;
						IL_0194:
						num = 29;
						materialType.FuMax = BitConverter.ToSingle (array, 96);
						goto IL_01a7;
						IL_01a7:
						num = 30;
						if (array.Length >= 113) {
							goto IL_01b2;
						}
						goto IL_0206;
						IL_01b2:
						num = 31;
						materialType.Elong = BitConverter.ToSingle (array, 100);
						goto IL_01c5;
						IL_01c5:
						num = 32;
						materialType.ElongThin = BitConverter.ToSingle (array, 104);
						goto IL_01d8;
						IL_01d8:
						num = 33;
						materialType.ThkMin = BitConverter.ToSingle (array, 108);
						goto IL_01eb;
						IL_01eb:
						num = 34;
						materialType.Family = Conversions.ToString (Strings.Chr (array [112]));
						goto IL_0233;
						IL_0206:
						num = 36;
						materialType.Elong = -1f;
						goto IL_0215;
						IL_0215:
						num = 37;
						materialType.ElongThin = -1f;
						goto IL_0224;
						IL_0224:
						num = 38;
						materialType.ThkMin = -1f;
						goto IL_0233;
						IL_0233:
						num = 39;
						materialType.AssignFamily ();
						goto IL_023d;
						IL_023d:
						materialType = null;
						goto IL_0240;
						IL_0240:
						num = 41;
						array = null;
						goto IL_0246;
						IL_0246:
						num = 42;
						array = (byte[])registryKey2.GetValue (name2, CFS.blnColdWork);
						goto IL_0263;
						IL_0263:
						num = 43;
						if (array != null && array.Length > 0) {
							goto IL_0271;
						}
						goto IL_0284;
						IL_04a5:
						num = 72;
						registryKey.SetValue (name2, BitConverter.GetBytes (unchecked((short)(0 - (CFS.blnColdWork ? 1 : 0)))), RegistryValueKind.Binary);
						goto IL_04c1;
						IL_0271:
						num = 44;
						CFS.blnColdWork = BitConverter.ToInt16 (array, 0) != 0;
						goto IL_0284;
						IL_0284:
						num = 45;
						array = null;
						goto IL_028a;
						IL_028a:
						num = 46;
						array = (byte[])registryKey2.GetValue (name3, CFS.blnReserve);
						goto IL_02a7;
						IL_02a7:
						num = 47;
						if (array != null && array.Length > 0) {
							goto IL_02b5;
						}
						goto IL_02c8;
						IL_04c1:
						num = 73;
						registryKey.SetValue (name3, BitConverter.GetBytes (unchecked((short)(0 - (CFS.blnReserve ? 1 : 0)))), RegistryValueKind.Binary);
						break;
						IL_02b5:
						num = 48;
						CFS.blnReserve = BitConverter.ToInt16 (array, 0) != 0;
						goto IL_02c8;
						IL_02c8:
						num = 49;
						registryKey2.Close ();
						goto IL_02d2;
						IL_02d2:
						num = 50;
						CFS.iMaterial = CFS.MatchMaterial (CFS.MaterialDefault);
						goto end_IL_0000_3;
						IL_02e9:
						num = 52;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_02f3;
						IL_02f3:
						num = 53;
						array = new byte[113];
						goto IL_02ff;
						IL_02ff:
						num = 54;
						materialType2 = CFS.MaterialDefault;
						goto IL_0309;
						IL_0309:
						num = 55;
						Array.Copy (Encoding.ASCII.GetBytes (materialType2.Name.PadRight (24)), array, 24);
						goto IL_032d;
						IL_032d:
						num = 56;
						num5 = 1;
						goto IL_0333;
						IL_0333:
						num = 57;
						Array.Copy (BitConverter.GetBytes (materialType2.Eo [num5]), 0, array, 24 + 4 * (num5 - 1), 4);
						goto IL_0357;
						IL_0357:
						num = 58;
						Array.Copy (BitConverter.GetBytes (materialType2.Fy [num5]), 0, array, 44 + 4 * (num5 - 1), 4);
						goto IL_037b;
						IL_037b:
						num = 59;
						Array.Copy (BitConverter.GetBytes (materialType2.N [num5]), 0, array, 64 + 4 * (num5 - 1), 4);
						goto IL_039f;
						IL_039f:
						num = 60;
						num5 = (short)unchecked(num5 + 1);
						if (num5 <= 5) {
							goto IL_0333;
						}
						goto IL_03ae;
						IL_03ae:
						num = 61;
						Array.Copy (BitConverter.GetBytes (materialType2.Fu), 0, array, 84, 4);
						goto IL_03c8;
						IL_03c8:
						num = 62;
						Array.Copy (BitConverter.GetBytes (materialType2.FyMin), 0, array, 88, 4);
						goto IL_03e2;
						IL_03e2:
						num = 63;
						Array.Copy (BitConverter.GetBytes (materialType2.FuMin), 0, array, 92, 4);
						goto IL_03fc;
						IL_03fc:
						num = 64;
						Array.Copy (BitConverter.GetBytes (materialType2.FuMax), 0, array, 96, 4);
						goto IL_0416;
						IL_0416:
						num = 65;
						Array.Copy (BitConverter.GetBytes (materialType2.Elong), 0, array, 100, 4);
						goto IL_0430;
						IL_0430:
						num = 66;
						Array.Copy (BitConverter.GetBytes (materialType2.ElongThin), 0, array, 104, 4);
						goto IL_044a;
						IL_044a:
						num = 67;
						Array.Copy (BitConverter.GetBytes (materialType2.ThkMin), 0, array, 108, 4);
						goto IL_0464;
						IL_0464:
						num = 68;
						Array.Copy (Encoding.ASCII.GetBytes (materialType2.Family), 0, array, 112, 1);
						goto IL_0483;
						IL_0483:
						materialType2 = null;
						goto IL_0486;
						end_IL_0000_2:
						break;
					}
					num = 74;
					registryKey.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1576;
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

	public static void RegistryView (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		RegistryKey registryKey = default(RegistryKey);
		bool flag = default(bool);
		bool flag2 = default(bool);
		bool flag3 = default(bool);
		bool flag4 = default(bool);
		RegistryKey registryKey2 = default(RegistryKey);
		byte[] array = default(byte[]);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					num = 1;
					text = "Software\\RSG Software, Inc.\\CFS\\Options";
					goto IL_0008;
				case 933:
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
							goto IL_0008;
						case 3:
							goto IL_000f;
						case 4:
							goto IL_0017;
						case 5:
							goto IL_001c;
						case 6:
							goto IL_0021;
						case 7:
							goto IL_0026;
						case 8:
							goto IL_002b;
						case 9:
							goto IL_003a;
						case 10:
							goto IL_0044;
						case 11:
							goto IL_004a;
						case 12:
							goto IL_006c;
						case 13:
							goto IL_007a;
						case 14:
							goto IL_008a;
						case 15:
							goto IL_0090;
						case 16:
							goto IL_00b2;
						case 17:
							goto IL_00c0;
						case 18:
							goto IL_00d0;
						case 19:
							goto IL_00d6;
						case 20:
							goto IL_00f8;
						case 21:
							goto IL_0106;
						case 22:
							goto IL_0116;
						case 23:
							goto IL_011c;
						case 24:
							goto IL_013e;
						case 25:
							goto IL_014c;
						case 26:
							goto IL_015c;
						case 27:
							goto IL_0166;
						case 28:
							goto IL_017f;
						case 29:
							goto IL_0198;
						case 30:
							goto IL_01b1;
						case 31:
							goto IL_01ca;
						case 33:
							goto IL_01e8;
						case 34:
							goto IL_01f2;
						case 35:
							goto IL_020b;
						case 36:
							goto IL_0224;
						case 37:
							goto IL_023d;
						case 38:
							goto IL_0256;
						case 39:
							goto IL_0266;
						case 40:
							goto IL_0282;
						case 41:
							goto IL_029e;
						case 42:
							goto IL_02ba;
						case 43:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 32:
						case 44:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_0256:
					num = 38;
					registryKey = Registry.CurrentUser.CreateSubKey (text);
					goto IL_0266;
					IL_0008:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_000f;
					IL_000f:
					num = 3;
					if (bytAction == 0) {
						goto IL_0017;
					}
					goto IL_01e8;
					IL_0017:
					num = 4;
					flag = true;
					goto IL_001c;
					IL_001c:
					num = 5;
					flag2 = true;
					goto IL_0021;
					IL_0021:
					num = 6;
					flag3 = true;
					goto IL_0026;
					IL_0026:
					num = 7;
					flag4 = true;
					goto IL_002b;
					IL_002b:
					num = 8;
					registryKey2 = Registry.CurrentUser.OpenSubKey (text);
					goto IL_003a;
					IL_003a:
					num = 9;
					if (registryKey2 != null) {
						goto IL_0044;
					}
					goto IL_0166;
					IL_0044:
					num = 10;
					array = null;
					goto IL_004a;
					IL_004a:
					num = 11;
					array = (byte[])registryKey2.GetValue ("Toolbar", BitConverter.GetBytes ((short)(0 - (flag ? 1 : 0))));
					goto IL_006c;
					IL_006c:
					num = 12;
					if (array != null && array.Length > 0) {
						goto IL_007a;
					}
					goto IL_008a;
					IL_0266:
					num = 39;
					registryKey.SetValue ("Toolbar", BitConverter.GetBytes ((short)(0 - (flag ? 1 : 0))), RegistryValueKind.Binary);
					goto IL_0282;
					IL_007a:
					num = 13;
					flag = BitConverter.ToInt16 (array, 0) != 0;
					goto IL_008a;
					IL_008a:
					num = 14;
					array = null;
					goto IL_0090;
					IL_0090:
					num = 15;
					array = (byte[])registryKey2.GetValue ("OnTop", BitConverter.GetBytes ((short)(0 - (flag2 ? 1 : 0))));
					goto IL_00b2;
					IL_00b2:
					num = 16;
					if (array != null && array.Length > 0) {
						goto IL_00c0;
					}
					goto IL_00d0;
					IL_0282:
					num = 40;
					registryKey.SetValue ("OnTop", BitConverter.GetBytes ((short)(0 - (flag2 ? 1 : 0))), RegistryValueKind.Binary);
					goto IL_029e;
					IL_00c0:
					num = 17;
					flag2 = BitConverter.ToInt16 (array, 0) != 0;
					goto IL_00d0;
					IL_00d0:
					num = 18;
					array = null;
					goto IL_00d6;
					IL_00d6:
					num = 19;
					array = (byte[])registryKey2.GetValue ("RenderMembers", BitConverter.GetBytes ((short)(0 - (flag3 ? 1 : 0))));
					goto IL_00f8;
					IL_00f8:
					num = 20;
					if (array != null && array.Length > 0) {
						goto IL_0106;
					}
					goto IL_0116;
					IL_029e:
					num = 41;
					registryKey.SetValue ("RenderMembers", BitConverter.GetBytes ((short)(0 - (flag3 ? 1 : 0))), RegistryValueKind.Binary);
					goto IL_02ba;
					IL_0106:
					num = 21;
					flag3 = BitConverter.ToInt16 (array, 0) != 0;
					goto IL_0116;
					IL_0116:
					num = 22;
					array = null;
					goto IL_011c;
					IL_011c:
					num = 23;
					array = (byte[])registryKey2.GetValue ("XYAxes", BitConverter.GetBytes ((short)(0 - (flag4 ? 1 : 0))));
					goto IL_013e;
					IL_013e:
					num = 24;
					if (array != null && array.Length > 0) {
						goto IL_014c;
					}
					goto IL_015c;
					IL_02ba:
					num = 42;
					registryKey.SetValue ("XYAxes", BitConverter.GetBytes ((short)(0 - (flag4 ? 1 : 0))), RegistryValueKind.Binary);
					break;
					IL_014c:
					num = 25;
					flag4 = BitConverter.ToInt16 (array, 0) != 0;
					goto IL_015c;
					IL_015c:
					num = 26;
					registryKey2.Close ();
					goto IL_0166;
					IL_0166:
					num = 27;
					My.MyProject.Forms.mdiCFS.mnuViewToolbar.Checked = flag;
					goto IL_017f;
					IL_017f:
					num = 28;
					My.MyProject.Forms.mdiCFS.tbrCFS.Visible = flag;
					goto IL_0198;
					IL_0198:
					num = 29;
					My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked = flag2;
					goto IL_01b1;
					IL_01b1:
					num = 30;
					My.MyProject.Forms.mdiCFS.mnuViewRenderMembers.Checked = flag3;
					goto IL_01ca;
					IL_01ca:
					num = 31;
					My.MyProject.Forms.mdiCFS.mnuViewXYAxes.Checked = flag4;
					goto end_IL_0000_3;
					IL_01e8:
					num = 33;
					if (bytAction != 1) {
						goto end_IL_0000_3;
					}
					goto IL_01f2;
					IL_01f2:
					num = 34;
					flag = My.MyProject.Forms.mdiCFS.mnuViewToolbar.Checked;
					goto IL_020b;
					IL_020b:
					num = 35;
					flag2 = My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked;
					goto IL_0224;
					IL_0224:
					num = 36;
					flag3 = My.MyProject.Forms.mdiCFS.mnuViewRenderMembers.Checked;
					goto IL_023d;
					IL_023d:
					num = 37;
					flag4 = My.MyProject.Forms.mdiCFS.mnuViewXYAxes.Checked;
					goto IL_0256;
					end_IL_0000_2:
					break;
				}
				num = 43;
				registryKey.Close ();
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 933;
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

	public static void RegistryRecentFiles (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		int num5 = default(int);
		string name = default(string);
		string text2 = default(string);
		RegistryKey registryKey = default(RegistryKey);
		short num6 = default(short);
		short num7 = default(short);
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		RegistryKey registryKey2 = default(RegistryKey);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					int num8;
					switch (try0000_dispatch) {
					default:
						num = 1;
						text = "Software\\RSG Software, Inc.\\CFS\\Files";
						goto IL_0008;
					case 664:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_0008;
							case 3:
								goto IL_0011;
							case 4:
								goto IL_001a;
							case 5:
								goto IL_0021;
							case 6:
								goto IL_0029;
							case 7:
								goto IL_0031;
							case 8:
								goto IL_0040;
							case 9:
								goto IL_0046;
							case 10:
								goto IL_005e;
							case 11:
								goto IL_0068;
							case 14:
								goto IL_0073;
							case 15:
								goto IL_008a;
							case 16:
								goto IL_0091;
							case 17:
								goto IL_00a0;
							case 18:
								goto IL_00ac;
							case 19:
								goto IL_00bc;
							case 20:
								goto IL_00dd;
							case 22:
								goto IL_00f2;
							case 12:
							case 13:
							case 23:
								goto IL_00f9;
							case 21:
							case 24:
								goto IL_010a;
							case 25:
								goto IL_0125;
							case 26:
								goto IL_0135;
							case 27:
								goto IL_0144;
							case 28:
								goto IL_0152;
							case 29:
								goto IL_016a;
							case 31:
								goto IL_0184;
							case 32:
								goto IL_018b;
							case 33:
								goto IL_019a;
							case 34:
								goto IL_01b3;
							case 35:
								goto IL_01c2;
							case 36:
								goto IL_01d2;
							case 37:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 30:
							case 38:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_01b3:
						num = 34;
						num5++;
						goto IL_01bc;
						IL_0008:
						num = 2;
						name = "Files";
						goto IL_0011;
						IL_0011:
						num = 3;
						text2 = string.Empty;
						goto IL_001a;
						IL_001a:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0021;
						IL_0021:
						num = 5;
						if (bytAction == 0) {
							goto IL_0029;
						}
						goto IL_0184;
						IL_0029:
						num = 6;
						bytRecentFileCount = 0;
						goto IL_0031;
						IL_0031:
						num = 7;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_0040;
						IL_0040:
						num = 8;
						if (registryKey != null) {
							goto IL_0046;
						}
						goto IL_0068;
						IL_0046:
						num = 9;
						text2 = Conversions.ToString (registryKey.GetValue (name, string.Empty));
						goto IL_005e;
						IL_005e:
						num = 10;
						registryKey.Close ();
						goto IL_0068;
						IL_0068:
						num = 11;
						num6 = 0;
						goto IL_00f9;
						IL_00f9:
						num = 13;
						if (num6 < Strings.Len (text2)) {
							goto IL_0073;
						}
						goto IL_010a;
						IL_0073:
						num = 14;
						num7 = (short)Strings.InStr (num6 + 1, text2, "\v");
						goto IL_008a;
						IL_008a:
						num = 15;
						if (num7 == 0) {
							goto IL_0091;
						}
						goto IL_00a0;
						IL_0091:
						num = 16;
						num7 = (short)(Strings.Len (text2) + 1);
						goto IL_00a0;
						IL_00a0:
						num = 17;
						if ((short)unchecked(num7 - num6) > 1) {
							goto IL_00ac;
						}
						goto IL_00f2;
						IL_00ac:
						num = 18;
						bytRecentFileCount++;
						goto IL_00bc;
						IL_00bc:
						num = 19;
						strRecentFile [bytRecentFileCount] = Strings.Mid (text2, num6 + 1, (short)unchecked(num7 - num6) - 1);
						goto IL_00dd;
						IL_00dd:
						num = 20;
						if (bytRecentFileCount != Information.UBound (strRecentFile)) {
							goto IL_00f2;
						}
						goto IL_010a;
						IL_010a:
						num = 24;
						num8 = unchecked((int)bytRecentFileCount) + 1;
						num9 = Information.UBound (strRecentFile);
						num10 = num8;
						goto IL_013e;
						IL_013e:
						if (num10 <= num9) {
							goto IL_0125;
						}
						goto IL_0144;
						IL_0144:
						num = 27;
						if (bytRecentFileCount <= 0) {
							goto end_IL_0000_3;
						}
						goto IL_0152;
						IL_0152:
						num = 28;
						My.MyProject.Forms.mdiCFS.mnuFileRecent.Enabled = true;
						goto IL_016a;
						IL_016a:
						num = 29;
						My.MyProject.Forms.mdiCFS.tbrRecent.Enabled = true;
						goto end_IL_0000_3;
						IL_0125:
						num = 25;
						strRecentFile [num10] = string.Empty;
						goto IL_0135;
						IL_0135:
						num = 26;
						num10++;
						goto IL_013e;
						IL_00f2:
						num = 22;
						num6 = num7;
						goto IL_00f9;
						IL_0184:
						num = 31;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_018b;
						IL_018b:
						num = 32;
						num11 = bytRecentFileCount;
						num5 = 1;
						goto IL_01bc;
						IL_01bc:
						if (num5 <= num11) {
							goto IL_019a;
						}
						goto IL_01c2;
						IL_01c2:
						num = 35;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_01d2;
						IL_01d2:
						num = 36;
						registryKey2.SetValue (name, text2, RegistryValueKind.String);
						break;
						IL_019a:
						num = 33;
						text2 = text2 + strRecentFile [num5] + "\v";
						goto IL_01b3;
						end_IL_0000_2:
						break;
					}
					num = 37;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 664;
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

	public static void RegistrySpec (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		RegistryKey registryKey = default(RegistryKey);
		string name = default(string);
		RegistryKey registryKey2 = default(RegistryKey);
		byte[] array = default(byte[]);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					num = 1;
					text = "Software\\RSG Software, Inc.\\CFS\\Options";
					goto IL_0008;
				case 514:
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
							goto IL_0008;
						case 3:
							goto IL_0011;
						case 4:
							goto IL_0018;
						case 5:
							goto IL_0020;
						case 6:
							goto IL_0029;
						case 7:
							goto IL_0038;
						case 8:
							goto IL_0041;
						case 9:
							goto IL_0046;
						case 10:
							goto IL_0063;
						case 11:
							goto IL_0071;
						case 12:
							goto IL_0082;
						case 13:
							goto IL_0088;
						case 14:
							goto IL_00ad;
						case 15:
							goto IL_00bb;
						case 16:
							goto IL_00ce;
						case 17:
							goto IL_00d8;
						case 18:
							goto IL_00ef;
						case 19:
							goto IL_00f9;
						case 20:
							goto IL_0103;
						case 21:
							goto IL_010c;
						case 22:
							goto IL_0117;
						case 24:
							goto IL_0122;
						case 25:
							goto IL_0129;
						case 26:
							goto IL_0139;
						case 27:
							goto IL_0150;
						case 28:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 23:
						case 29:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_0129:
					num = 25;
					registryKey = Registry.CurrentUser.CreateSubKey (text);
					goto IL_0139;
					IL_0008:
					num = 2;
					name = "Spec14";
					goto IL_0011;
					IL_0011:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_0018;
					IL_0018:
					num = 4;
					if (bytAction == 0) {
						goto IL_0020;
					}
					goto IL_0122;
					IL_0020:
					num = 5;
					CFS.intSpecNow = 37;
					goto IL_0029;
					IL_0029:
					num = 6;
					registryKey2 = Registry.CurrentUser.OpenSubKey (text);
					goto IL_0038;
					IL_0038:
					num = 7;
					if (registryKey2 != null) {
						goto IL_0041;
					}
					goto IL_00d8;
					IL_0041:
					num = 8;
					array = null;
					goto IL_0046;
					IL_0046:
					num = 9;
					array = (byte[])registryKey2.GetValue (name, CFS.intSpecNow);
					goto IL_0063;
					IL_0063:
					num = 10;
					if (array != null && array.Length > 0) {
						goto IL_0071;
					}
					goto IL_0082;
					IL_0139:
					num = 26;
					registryKey.SetValue (name, BitConverter.GetBytes (CFS.intSpecNow), RegistryValueKind.Binary);
					goto IL_0150;
					IL_0071:
					num = 11;
					CFS.intSpecNow = checked((byte)BitConverter.ToInt16 (array, 0));
					goto IL_0082;
					IL_0082:
					num = 12;
					array = null;
					goto IL_0088;
					IL_0088:
					num = 13;
					array = (byte[])registryKey2.GetValue ("BucklingTheory", BitConverter.GetBytes ((short)(0 - (CFS.blnBucklingTheory ? 1 : 0))));
					goto IL_00ad;
					IL_00ad:
					num = 14;
					if (array != null && array.Length > 0) {
						goto IL_00bb;
					}
					goto IL_00ce;
					IL_0150:
					num = 27;
					registryKey.SetValue ("BucklingTheory", BitConverter.GetBytes ((short)(0 - (CFS.blnBucklingTheory ? 1 : 0))), RegistryValueKind.Binary);
					break;
					IL_00bb:
					num = 15;
					CFS.blnBucklingTheory = BitConverter.ToInt16 (array, 0) != 0;
					goto IL_00ce;
					IL_00ce:
					num = 16;
					registryKey2.Close ();
					goto IL_00d8;
					IL_00d8:
					num = 17;
					if ((CFS.intSpecNow < 0) | ((uint)CFS.intSpecNow > 41u)) {
						goto IL_00ef;
					}
					goto IL_00f9;
					IL_00ef:
					num = 18;
					CFS.intSpecNow = 37;
					goto IL_00f9;
					IL_00f9:
					num = 19;
					if (CFS.intSpecNow == 0) {
						goto IL_0103;
					}
					goto IL_010c;
					IL_0103:
					num = 20;
					CFS.intSpecNow = 2;
					goto IL_010c;
					IL_010c:
					num = 21;
					if (CFS.intSpecNow != 1) {
						goto end_IL_0000_3;
					}
					goto IL_0117;
					IL_0117:
					num = 22;
					CFS.intSpecNow = 3;
					goto end_IL_0000_3;
					IL_0122:
					num = 24;
					if (bytAction != 1) {
						goto end_IL_0000_3;
					}
					goto IL_0129;
					end_IL_0000_2:
					break;
				}
				num = 28;
				registryKey.Close ();
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 514;
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

	public static void RegistryThickness (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		float[] array = default(float[]);
		short num5 = default(short);
		string name = default(string);
		string name2 = default(string);
		string name3 = default(string);
		string name4 = default(string);
		string text2 = default(string);
		float[] array2 = default(float[]);
		RegistryKey registryKey = default(RegistryKey);
		byte[] array3 = default(byte[]);
		short num6 = default(short);
		short num7 = default(short);
		short num8 = default(short);
		short num9 = default(short);
		short num10 = default(short);
		short num11 = default(short);
		short num12 = default(short);
		RegistryKey registryKey2 = default(RegistryKey);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						text = "Software\\RSG Software, Inc.\\CFS\\Thickness14";
						goto IL_0009;
					case 1529:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_0009;
							case 3:
								goto IL_0012;
							case 4:
								goto IL_001b;
							case 5:
								goto IL_0024;
							case 6:
								goto IL_002d;
							case 7:
								goto IL_0036;
							case 8:
								goto IL_0040;
							case 9:
								goto IL_004a;
							case 10:
								goto IL_0051;
							case 11:
								goto IL_005a;
							case 12:
								goto IL_006b;
							case 13:
								goto IL_0075;
							case 14:
								goto IL_008d;
							case 15:
								goto IL_0098;
							case 16:
								goto IL_00ad;
							case 17:
								goto IL_00bb;
							case 18:
								goto IL_00e6;
							case 19:
								goto IL_00f8;
							case 20:
								goto IL_0109;
							case 21:
								goto IL_0116;
							case 22:
								goto IL_0121;
							case 23:
								goto IL_0136;
							case 24:
								goto IL_0144;
							case 25:
								goto IL_016f;
							case 26:
								goto IL_0181;
							case 27:
								goto IL_0192;
							case 28:
								goto IL_019f;
							case 29:
								goto IL_01aa;
							case 30:
								goto IL_01c0;
							case 31:
								goto IL_01ca;
							case 32:
								goto IL_01f0;
							case 33:
								goto IL_01f8;
							case 35:
								goto IL_0206;
							case 36:
								goto IL_021f;
							case 37:
								goto IL_0225;
							case 38:
								goto IL_023a;
							case 39:
								goto IL_0251;
							case 41:
								goto IL_025b;
							case 42:
								goto IL_0269;
							case 43:
								goto IL_0275;
							case 44:
								goto IL_0283;
							case 45:
								goto IL_028f;
							case 46:
								goto IL_029d;
							case 47:
								goto IL_02a9;
							case 48:
								goto IL_02b7;
							case 49:
								goto IL_02c3;
							case 50:
								goto IL_02dc;
							case 51:
								goto IL_02f5;
							case 52:
								goto IL_0323;
							case 53:
								goto IL_032a;
							case 40:
							case 54:
								goto IL_033a;
							case 55:
								goto IL_0344;
							case 56:
								goto IL_0367;
							case 58:
								goto IL_0375;
							case 59:
								goto IL_037f;
							case 60:
								goto IL_0393;
							case 61:
								goto IL_03ac;
							case 62:
								goto IL_03c5;
							case 63:
								goto IL_03cf;
							case 64:
								goto IL_03e4;
							case 65:
								goto IL_0405;
							case 66:
								goto IL_041e;
							case 67:
								goto IL_0437;
							case 68:
								goto IL_0444;
							case 69:
								goto IL_044e;
							case 70:
								goto IL_045f;
							case 71:
								goto IL_046e;
							case 72:
								goto IL_0484;
							case 73:
								goto IL_049a;
							case 74:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 34:
							case 57:
							case 75:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0405:
						num = 65;
						array [num5 - 1] = CFS.Thicknesses [num5].Thickness;
						goto IL_041e;
						IL_0009:
						num = 2;
						name = "Name";
						goto IL_0012;
						IL_0012:
						num = 3;
						name2 = "Thickness";
						goto IL_001b;
						IL_001b:
						num = 4;
						name3 = "DefRad";
						goto IL_0024;
						IL_0024:
						num = 5;
						name4 = "DefThickness";
						goto IL_002d;
						IL_002d:
						num = 6;
						text2 = string.Empty;
						goto IL_0036;
						IL_0036:
						num = 7;
						array = new float[1];
						goto IL_0040;
						IL_0040:
						num = 8;
						array2 = new float[1];
						goto IL_004a;
						IL_004a:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0051;
						IL_0051:
						num = 10;
						if (bytAction == 0) {
							goto IL_005a;
						}
						goto IL_0375;
						IL_005a:
						num = 11;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_006b;
						IL_006b:
						num = 12;
						if (registryKey != null) {
							goto IL_0075;
						}
						goto IL_01ca;
						IL_0075:
						num = 13;
						text2 = Conversions.ToString (registryKey.GetValue (name, string.Empty));
						goto IL_008d;
						IL_008d:
						num = 14;
						array3 = new byte[0];
						goto IL_0098;
						IL_0098:
						num = 15;
						array3 = (byte[])registryKey.GetValue (name2, array3);
						goto IL_00ad;
						IL_00ad:
						num = 16;
						if (array3 != null && array3.Length > 0) {
							goto IL_00bb;
						}
						goto IL_0116;
						IL_041e:
						num = 66;
						array2 [num5 - 1] = CFS.Thicknesses [num5].DefRad;
						goto IL_0437;
						IL_00bb:
						num = 17;
						array = new float[(int)System.Math.Round ((double)array3.Length / 4.0 - 1.0) + 1];
						goto IL_00e6;
						IL_00e6:
						num = 18;
						num6 = (short)Information.UBound (array);
						num5 = 0;
						goto IL_0111;
						IL_0111:
						if (num5 <= num6) {
							goto IL_00f8;
						}
						goto IL_0116;
						IL_00f8:
						num = 19;
						array [num5] = BitConverter.ToSingle (array3, 4 * num5);
						goto IL_0109;
						IL_0109:
						num = 20;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0111;
						IL_0116:
						num = 21;
						array3 = new byte[0];
						goto IL_0121;
						IL_0121:
						num = 22;
						array3 = (byte[])registryKey.GetValue (name3, array3);
						goto IL_0136;
						IL_0136:
						num = 23;
						if (array3 != null && array3.Length > 0) {
							goto IL_0144;
						}
						goto IL_019f;
						IL_0437:
						num = 67;
						num5 = (short)unchecked(num5 + 1);
						goto IL_043f;
						IL_0144:
						num = 24;
						array2 = new float[(int)System.Math.Round ((double)array3.Length / 4.0 - 1.0) + 1];
						goto IL_016f;
						IL_016f:
						num = 25;
						num7 = (short)Information.UBound (array2);
						num5 = 0;
						goto IL_019a;
						IL_019a:
						if (num5 <= num7) {
							goto IL_0181;
						}
						goto IL_019f;
						IL_0181:
						num = 26;
						array2 [num5] = BitConverter.ToSingle (array3, 4 * num5);
						goto IL_0192;
						IL_0192:
						num = 27;
						num5 = (short)unchecked(num5 + 1);
						goto IL_019a;
						IL_019f:
						num = 28;
						array3 = new byte[4];
						goto IL_01aa;
						IL_01aa:
						num = 29;
						num8 = (short)Conversions.ToInteger (registryKey.GetValue (name4, array3));
						goto IL_01c0;
						IL_01c0:
						num = 30;
						registryKey.Close ();
						goto IL_01ca;
						IL_01ca:
						num = 31;
						if ((Information.UBound (array) == 0) | (Information.UBound (array) != Information.UBound (array2))) {
							goto IL_01f0;
						}
						goto IL_0206;
						IL_01f0:
						num = 32;
						CFS.ResetThicknesses ();
						goto IL_01f8;
						IL_01f8:
						num = 33;
						CFS.iThickness = 1;
						goto end_IL_0000_3;
						IL_0206:
						num = 35;
						CFS.Thicknesses = new Thickness[Information.UBound (array) + 1 + 1];
						goto IL_021f;
						IL_021f:
						num = 36;
						num9 = 0;
						goto IL_0225;
						IL_0225:
						num = 37;
						num10 = (short)Information.UBound (array);
						num5 = 0;
						goto IL_0332;
						IL_0332:
						if (num5 <= num10) {
							goto IL_023a;
						}
						goto IL_033a;
						IL_023a:
						num = 38;
						num11 = (short)Strings.InStr (num9 + 1, text2, "\v");
						goto IL_0251;
						IL_0251:
						num = 39;
						if (num11 != 0) {
							goto IL_025b;
						}
						goto IL_033a;
						IL_025b:
						num = 41;
						if (array [num5] < 0.001f) {
							goto IL_0269;
						}
						goto IL_0275;
						IL_0269:
						num = 42;
						array [num5] = 0.001f;
						goto IL_0275;
						IL_0275:
						num = 43;
						if (array [num5] > 1f) {
							goto IL_0283;
						}
						goto IL_028f;
						IL_0283:
						num = 44;
						array [num5] = 1f;
						goto IL_028f;
						IL_028f:
						num = 45;
						if (array2 [num5] < 0f) {
							goto IL_029d;
						}
						goto IL_02a9;
						IL_029d:
						num = 46;
						array2 [num5] = 0f;
						goto IL_02a9;
						IL_02a9:
						num = 47;
						if (array2 [num5] > 10f) {
							goto IL_02b7;
						}
						goto IL_02c3;
						IL_02b7:
						num = 48;
						array2 [num5] = 10f;
						goto IL_02c3;
						IL_02c3:
						num = 49;
						CFS.Thicknesses [num5 + 1].Thickness = array [num5];
						goto IL_02dc;
						IL_02dc:
						num = 50;
						CFS.Thicknesses [num5 + 1].DefRad = array2 [num5];
						goto IL_02f5;
						IL_02f5:
						num = 51;
						CFS.Thicknesses [num5 + 1].Name = Strings.Left (Strings.Mid (text2, num9 + 1, num11 - (num9 + 1)), 12);
						goto IL_0323;
						IL_0323:
						num = 52;
						num9 = num11;
						goto IL_032a;
						IL_032a:
						num = 53;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0332;
						IL_033a:
						num = 54;
						CFS.iThickness = num8;
						goto IL_0344;
						IL_0344:
						num = 55;
						if (!((CFS.iThickness < 1) | (CFS.iThickness > Information.UBound (CFS.Thicknesses)))) {
							goto end_IL_0000_3;
						}
						goto IL_0367;
						IL_0367:
						num = 56;
						CFS.iThickness = 1;
						goto end_IL_0000_3;
						IL_0375:
						num = 58;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_037f;
						IL_037f:
						num = 59;
						if (Information.UBound (CFS.Thicknesses) <= 0) {
							goto end_IL_0000_3;
						}
						goto IL_0393;
						IL_0393:
						num = 60;
						array = new float[Information.UBound (CFS.Thicknesses) - 1 + 1];
						goto IL_03ac;
						IL_03ac:
						num = 61;
						array2 = new float[Information.UBound (CFS.Thicknesses) - 1 + 1];
						goto IL_03c5;
						IL_03c5:
						num = 62;
						text2 = string.Empty;
						goto IL_03cf;
						IL_03cf:
						num = 63;
						num12 = (short)Information.UBound (CFS.Thicknesses);
						num5 = 1;
						goto IL_043f;
						IL_043f:
						if (num5 <= num12) {
							goto IL_03e4;
						}
						goto IL_0444;
						IL_0444:
						num = 68;
						num8 = CFS.iThickness;
						goto IL_044e;
						IL_044e:
						num = 69;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_045f;
						IL_045f:
						num = 70;
						registryKey2.SetValue (name, text2, RegistryValueKind.String);
						goto IL_046e;
						IL_046e:
						num = 71;
						registryKey2.SetValue (name2, ByteArray (array), RegistryValueKind.Binary);
						goto IL_0484;
						IL_0484:
						num = 72;
						registryKey2.SetValue (name3, ByteArray (array2), RegistryValueKind.Binary);
						goto IL_049a;
						IL_049a:
						num = 73;
						registryKey2.SetValue (name4, num8, RegistryValueKind.DWord);
						break;
						IL_03e4:
						num = 64;
						text2 = text2 + CFS.Thicknesses [num5].Name + "\v";
						goto IL_0405;
						end_IL_0000_2:
						break;
					}
					num = 74;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1529;
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

	public static void RegistryTrace (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string text = default(string);
		int num2 = default(int);
		int num3 = default(int);
		RegistryKey registryKey = default(RegistryKey);
		string[] array = default(string[]);
		int num5 = default(int);
		bool[] array2 = default(bool[]);
		RegistryKey registryKey2 = default(RegistryKey);
		int num6 = default(int);
		byte[] array3 = default(byte[]);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					num = 1;
					text = "Software\\RSG Software, Inc.\\CFS\\Options";
					goto IL_0008;
				case 604:
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
							goto IL_0008;
						case 3:
							goto IL_0012;
						case 4:
							goto IL_001c;
						case 5:
							goto IL_0023;
						case 6:
							goto IL_002e;
						case 7:
							goto IL_0039;
						case 8:
							goto IL_0044;
						case 9:
							goto IL_004f;
						case 10:
							goto IL_005b;
						case 11:
							goto IL_0067;
						case 12:
							goto IL_0073;
						case 13:
							goto IL_007f;
						case 14:
							goto IL_008b;
						case 15:
							goto IL_0097;
						case 16:
							goto IL_00a0;
						case 17:
							goto IL_00b0;
						case 18:
							goto IL_00b7;
						case 19:
							goto IL_00bd;
						case 20:
							goto IL_00c3;
						case 21:
							goto IL_00e8;
						case 22:
							goto IL_00f6;
						case 23:
							goto IL_0109;
						case 24:
							goto IL_0117;
						case 25:
							goto IL_0121;
						case 26:
							goto IL_012d;
						case 27:
							goto IL_0139;
						case 28:
							goto IL_0145;
						case 29:
							goto IL_0151;
						case 31:
							goto IL_015f;
						case 32:
							goto IL_0166;
						case 33:
							goto IL_0176;
						case 34:
							goto IL_017c;
						case 35:
							goto IL_019b;
						case 36:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 30:
						case 37:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_017c:
					num = 34;
					registryKey.SetValue (array [num5], BitConverter.GetBytes ((short)(0 - (array2 [num5] ? 1 : 0))), RegistryValueKind.Binary);
					goto IL_019b;
					IL_0008:
					num = 2;
					array = new string[6];
					goto IL_0012;
					IL_0012:
					num = 3;
					array2 = new bool[6];
					goto IL_001c;
					IL_001c:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_0023;
					IL_0023:
					num = 5;
					array [1] = "TraceStrength";
					goto IL_002e;
					IL_002e:
					num = 6;
					array2 [1] = CFS.blnTraceStrength;
					goto IL_0039;
					IL_0039:
					num = 7;
					array [2] = "TraceMemberChk";
					goto IL_0044;
					IL_0044:
					num = 8;
					array2 [2] = CFS.blnTraceMemberChk;
					goto IL_004f;
					IL_004f:
					num = 9;
					array [3] = "TraceWebCrip";
					goto IL_005b;
					IL_005b:
					num = 10;
					array2 [3] = CFS.blnTraceWebCrip;
					goto IL_0067;
					IL_0067:
					num = 11;
					array [4] = "TraceEffProp";
					goto IL_0073;
					IL_0073:
					num = 12;
					array2 [4] = CFS.blnTraceEffProp;
					goto IL_007f;
					IL_007f:
					num = 13;
					array [5] = "TraceColdWork";
					goto IL_008b;
					IL_008b:
					num = 14;
					array2 [5] = CFS.blnTraceColdWork;
					goto IL_0097;
					IL_0097:
					num = 15;
					if (bytAction == 0) {
						goto IL_00a0;
					}
					goto IL_015f;
					IL_00a0:
					num = 16;
					registryKey2 = Registry.CurrentUser.OpenSubKey (text);
					goto IL_00b0;
					IL_00b0:
					num = 17;
					if (registryKey2 != null) {
						goto IL_00b7;
					}
					goto IL_0121;
					IL_00b7:
					num = 18;
					num6 = 1;
					goto IL_00bd;
					IL_00bd:
					num = 19;
					array3 = null;
					goto IL_00c3;
					IL_00c3:
					num = 20;
					array3 = (byte[])registryKey2.GetValue (array [num6], BitConverter.GetBytes ((short)(0 - (array2 [num6] ? 1 : 0))));
					goto IL_00e8;
					IL_00e8:
					num = 21;
					if (array3 != null && array3.Length > 0) {
						goto IL_00f6;
					}
					goto IL_0109;
					IL_019b:
					num = 35;
					num5 = checked(num5 + 1);
					if (num5 > 5) {
						break;
					}
					goto IL_017c;
					IL_00f6:
					num = 22;
					array2 [num6] = BitConverter.ToInt16 (array3, 0) != 0;
					goto IL_0109;
					IL_0109:
					num = 23;
					num6 = checked(num6 + 1);
					if (num6 <= 5) {
						goto IL_00bd;
					}
					goto IL_0117;
					IL_0117:
					num = 24;
					registryKey2.Close ();
					goto IL_0121;
					IL_0121:
					num = 25;
					CFS.blnTraceStrength = array2 [1];
					goto IL_012d;
					IL_012d:
					num = 26;
					CFS.blnTraceMemberChk = array2 [2];
					goto IL_0139;
					IL_0139:
					num = 27;
					CFS.blnTraceWebCrip = array2 [3];
					goto IL_0145;
					IL_0145:
					num = 28;
					CFS.blnTraceEffProp = array2 [4];
					goto IL_0151;
					IL_0151:
					num = 29;
					CFS.blnTraceColdWork = array2 [5];
					goto end_IL_0000_3;
					IL_015f:
					num = 31;
					if (bytAction != 1) {
						goto end_IL_0000_3;
					}
					goto IL_0166;
					IL_0166:
					num = 32;
					registryKey = Registry.CurrentUser.CreateSubKey (text);
					goto IL_0176;
					IL_0176:
					num = 33;
					num5 = 1;
					goto IL_017c;
					end_IL_0000_2:
					break;
				}
				num = 36;
				registryKey.Close ();
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 604;
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

	public static void RegistryUnits (byte bytAction)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		string[] array = default(string[]);
		int num2 = default(int);
		int num3 = default(int);
		short num5 = default(short);
		string[] array2 = default(string[]);
		string text = default(string);
		RegistryKey registryKey = default(RegistryKey);
		short num6 = default(short);
		short num7 = default(short);
		short num8 = default(short);
		short num9 = default(short);
		short num10 = default(short);
		short num11 = default(short);
		short num12 = default(short);
		short num13 = default(short);
		short num14 = default(short);
		short num15 = default(short);
		RegistryKey registryKey2 = default(RegistryKey);
		short num16 = default(short);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default:
						num = 1;
						array = new string[8];
						goto IL_0009;
					case 2163:
						{
							num2 = num;
							switch (num3) {
							case 1:
								break;
							default:
								goto end_IL_0000;
							}
							int num4 = unchecked(num2 + 1);
							num2 = 0;
							switch (num4) {
							case 1:
								break;
							case 2:
								goto IL_0009;
							case 3:
								goto IL_0013;
							case 4:
								goto IL_001c;
							case 5:
								goto IL_0023;
							case 6:
								goto IL_002d;
							case 7:
								goto IL_0037;
							case 8:
								goto IL_0041;
							case 9:
								goto IL_004b;
							case 10:
								goto IL_0056;
							case 11:
								goto IL_0061;
							case 12:
								goto IL_006c;
							case 13:
								goto IL_0075;
							case 14:
								goto IL_0086;
							case 15:
								goto IL_008d;
							case 16:
								goto IL_009f;
							case 17:
								goto IL_00bc;
							case 18:
								goto IL_00cc;
							case 19:
								goto IL_00d6;
							case 20:
								goto IL_00df;
							case 21:
								goto IL_00ea;
							case 22:
								goto IL_010f;
							case 23:
								goto IL_0131;
							case 24:
								goto IL_014f;
							case 25:
								goto IL_015f;
							case 26:
								goto IL_016e;
							case 27:
								goto IL_0184;
							case 28:
								goto IL_019f;
							case 29:
								goto IL_01bf;
							case 31:
								goto IL_01d9;
							case 30:
							case 32:
								goto IL_01e9;
							case 33:
								goto IL_01f8;
							case 34:
								goto IL_020e;
							case 35:
								goto IL_0229;
							case 36:
								goto IL_0249;
							case 38:
								goto IL_0263;
							case 37:
							case 39:
								goto IL_0273;
							case 40:
								goto IL_0282;
							case 41:
								goto IL_0298;
							case 42:
								goto IL_02b3;
							case 43:
								goto IL_02d3;
							case 45:
								goto IL_02ed;
							case 44:
							case 46:
								goto IL_02fd;
							case 47:
								goto IL_030c;
							case 48:
								goto IL_0322;
							case 49:
								goto IL_033d;
							case 50:
								goto IL_035d;
							case 52:
								goto IL_0377;
							case 51:
							case 53:
								goto IL_0387;
							case 54:
								goto IL_0396;
							case 55:
								goto IL_03ac;
							case 56:
								goto IL_03c7;
							case 57:
								goto IL_03e7;
							case 59:
								goto IL_0401;
							case 58:
							case 60:
								goto IL_0411;
							case 61:
								goto IL_0420;
							case 62:
								goto IL_0436;
							case 63:
								goto IL_0451;
							case 64:
								goto IL_0471;
							case 66:
								goto IL_048b;
							case 65:
							case 67:
								goto IL_049b;
							case 68:
								goto IL_04aa;
							case 69:
								goto IL_04c0;
							case 70:
								goto IL_04e0;
							case 72:
								goto IL_04ed;
							case 74:
								goto IL_04ff;
							case 75:
								goto IL_050e;
							case 71:
							case 73:
							case 76:
								goto IL_0517;
							case 77:
								goto IL_053c;
							case 78:
								goto IL_055e;
							case 79:
								goto IL_056e;
							case 81:
								goto IL_0580;
							case 82:
								goto IL_058a;
							case 83:
								goto IL_05a5;
							case 84:
								goto IL_05cd;
							case 85:
								goto IL_05f5;
							case 86:
								goto IL_061d;
							case 87:
								goto IL_0645;
							case 88:
								goto IL_066d;
							case 89:
								goto IL_0695;
							case 90:
								goto IL_06a6;
							case 91:
								goto IL_06b8;
							case 92:
								goto IL_06cc;
							case 93:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 80:
							case 94:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_06cc:
						num = 92;
						num5 = (short)unchecked(num5 + 1);
						goto IL_06d6;
						IL_0009:
						num = 2;
						array2 = new string[8];
						goto IL_0013;
						IL_0013:
						num = 3;
						text = "Software\\RSG Software, Inc.\\CFS\\Units";
						goto IL_001c;
						IL_001c:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0023;
						IL_0023:
						num = 5;
						array [1] = "UnitSys";
						goto IL_002d;
						IL_002d:
						num = 6;
						array [2] = "SectionLen";
						goto IL_0037;
						IL_0037:
						num = 7;
						array [3] = "Length";
						goto IL_0041;
						IL_0041:
						num = 8;
						array [4] = "Angle";
						goto IL_004b;
						IL_004b:
						num = 9;
						array [5] = "Force";
						goto IL_0056;
						IL_0056:
						num = 10;
						array [6] = "Stress";
						goto IL_0061;
						IL_0061:
						num = 11;
						array [7] = "Moment";
						goto IL_006c;
						IL_006c:
						num = 12;
						if (bytAction == 0) {
							goto IL_0075;
						}
						goto IL_0580;
						IL_0075:
						num = 13;
						registryKey = Registry.CurrentUser.OpenSubKey (text);
						goto IL_0086;
						IL_0086:
						num = 14;
						if (registryKey != null) {
							goto IL_008d;
						}
						goto IL_00d6;
						IL_008d:
						num = 15;
						num6 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_00c6;
						IL_00c6:
						if (num5 <= num6) {
							goto IL_009f;
						}
						goto IL_00cc;
						IL_00cc:
						num = 18;
						registryKey.Close ();
						goto IL_00d6;
						IL_009f:
						num = 16;
						array2 [num5] = Conversions.ToString (registryKey.GetValue (array [num5], string.Empty));
						goto IL_00bc;
						IL_00bc:
						num = 17;
						num5 = (short)unchecked(num5 + 1);
						goto IL_00c6;
						IL_00d6:
						num = 19;
						Units.iUnitSys = 1;
						goto IL_00df;
						IL_00df:
						num = 20;
						Units.DefaultUnitIndex [0] = 1;
						goto IL_00ea;
						IL_00ea:
						num = 21;
						num7 = (short)Information.UBound (Units.UnitSys [Units.iUnitSys].UnitIndex);
						num5 = 1;
						goto IL_0159;
						IL_0159:
						if (num5 <= num7) {
							goto IL_010f;
						}
						goto IL_015f;
						IL_015f:
						num = 25;
						if (Strings.Len (array2 [2]) > 0) {
							goto IL_016e;
						}
						goto IL_01e9;
						IL_016e:
						num = 26;
						num8 = (short)Information.UBound (Units.untLength);
						num5 = 1;
						goto IL_01e3;
						IL_01e3:
						if (num5 <= num8) {
							goto IL_0184;
						}
						goto IL_01e9;
						IL_0184:
						num = 27;
						if (Units.untLength [num5].Mult > 0f) {
							goto IL_019f;
						}
						goto IL_01d9;
						IL_019f:
						num = 28;
						if (Strings.StrComp (array2 [2], Units.untLength [num5].Name) == 0) {
							goto IL_01bf;
						}
						goto IL_01d9;
						IL_01bf:
						num = 29;
						Units.UnitSys [3].UnitIndex [1] = (byte)num5;
						goto IL_01e9;
						IL_01d9:
						num = 31;
						num5 = (short)unchecked(num5 + 1);
						goto IL_01e3;
						IL_01e9:
						num = 32;
						if (Strings.Len (array2 [3]) > 0) {
							goto IL_01f8;
						}
						goto IL_0273;
						IL_01f8:
						num = 33;
						num9 = (short)Information.UBound (Units.untLength);
						num5 = 1;
						goto IL_026d;
						IL_026d:
						if (num5 <= num9) {
							goto IL_020e;
						}
						goto IL_0273;
						IL_020e:
						num = 34;
						if (Units.untLength [num5].Mult > 0f) {
							goto IL_0229;
						}
						goto IL_0263;
						IL_0229:
						num = 35;
						if (Strings.StrComp (array2 [3], Units.untLength [num5].Name) == 0) {
							goto IL_0249;
						}
						goto IL_0263;
						IL_0249:
						num = 36;
						Units.UnitSys [3].UnitIndex [2] = (byte)num5;
						goto IL_0273;
						IL_0263:
						num = 38;
						num5 = (short)unchecked(num5 + 1);
						goto IL_026d;
						IL_0273:
						num = 39;
						if (Strings.Len (array2 [4]) > 0) {
							goto IL_0282;
						}
						goto IL_02fd;
						IL_0282:
						num = 40;
						num10 = (short)Information.UBound (Units.untAngle);
						num5 = 1;
						goto IL_02f7;
						IL_02f7:
						if (num5 <= num10) {
							goto IL_0298;
						}
						goto IL_02fd;
						IL_0298:
						num = 41;
						if (Units.untAngle [num5].Mult > 0f) {
							goto IL_02b3;
						}
						goto IL_02ed;
						IL_02b3:
						num = 42;
						if (Strings.StrComp (array2 [4], Units.untAngle [num5].Name) == 0) {
							goto IL_02d3;
						}
						goto IL_02ed;
						IL_02d3:
						num = 43;
						Units.UnitSys [3].UnitIndex [3] = (byte)num5;
						goto IL_02fd;
						IL_02ed:
						num = 45;
						num5 = (short)unchecked(num5 + 1);
						goto IL_02f7;
						IL_02fd:
						num = 46;
						if (Strings.Len (array2 [5]) > 0) {
							goto IL_030c;
						}
						goto IL_0387;
						IL_030c:
						num = 47;
						num11 = (short)Information.UBound (Units.untForce);
						num5 = 1;
						goto IL_0381;
						IL_0381:
						if (num5 <= num11) {
							goto IL_0322;
						}
						goto IL_0387;
						IL_0322:
						num = 48;
						if (Units.untForce [num5].Mult > 0f) {
							goto IL_033d;
						}
						goto IL_0377;
						IL_033d:
						num = 49;
						if (Strings.StrComp (array2 [5], Units.untForce [num5].Name) == 0) {
							goto IL_035d;
						}
						goto IL_0377;
						IL_035d:
						num = 50;
						Units.UnitSys [3].UnitIndex [4] = (byte)num5;
						goto IL_0387;
						IL_0377:
						num = 52;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0381;
						IL_0387:
						num = 53;
						if (Strings.Len (array2 [6]) > 0) {
							goto IL_0396;
						}
						goto IL_0411;
						IL_0396:
						num = 54;
						num12 = (short)Information.UBound (Units.untStress);
						num5 = 1;
						goto IL_040b;
						IL_040b:
						if (num5 <= num12) {
							goto IL_03ac;
						}
						goto IL_0411;
						IL_03ac:
						num = 55;
						if (Units.untStress [num5].Mult > 0f) {
							goto IL_03c7;
						}
						goto IL_0401;
						IL_03c7:
						num = 56;
						if (Strings.StrComp (array2 [6], Units.untStress [num5].Name) == 0) {
							goto IL_03e7;
						}
						goto IL_0401;
						IL_03e7:
						num = 57;
						Units.UnitSys [3].UnitIndex [5] = (byte)num5;
						goto IL_0411;
						IL_0401:
						num = 59;
						num5 = (short)unchecked(num5 + 1);
						goto IL_040b;
						IL_0411:
						num = 60;
						if (Strings.Len (array2 [7]) > 0) {
							goto IL_0420;
						}
						goto IL_049b;
						IL_0420:
						num = 61;
						num13 = (short)Information.UBound (Units.untStress);
						num5 = 1;
						goto IL_0495;
						IL_0495:
						if (num5 <= num13) {
							goto IL_0436;
						}
						goto IL_049b;
						IL_0436:
						num = 62;
						if (Units.untMoment [num5].Mult > 0f) {
							goto IL_0451;
						}
						goto IL_048b;
						IL_0451:
						num = 63;
						if (Strings.StrComp (array2 [7], Units.untMoment [num5].Name) == 0) {
							goto IL_0471;
						}
						goto IL_048b;
						IL_0471:
						num = 64;
						Units.UnitSys [3].UnitIndex [6] = (byte)num5;
						goto IL_049b;
						IL_048b:
						num = 66;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0495;
						IL_049b:
						num = 67;
						if (Strings.Len (array2 [1]) > 0) {
							goto IL_04aa;
						}
						goto IL_04ff;
						IL_04aa:
						num = 68;
						num14 = (short)Information.UBound (Units.UnitSys);
						num5 = 1;
						goto IL_04f7;
						IL_04f7:
						if (num5 <= num14) {
							goto IL_04c0;
						}
						goto IL_0517;
						IL_04c0:
						num = 69;
						if (Strings.StrComp (array2 [1], Units.UnitSys [num5].Name) == 0) {
							goto IL_04e0;
						}
						goto IL_04ed;
						IL_04e0:
						num = 70;
						Units.iUnitSys = (byte)num5;
						goto IL_0517;
						IL_04ed:
						num = 72;
						num5 = (short)unchecked(num5 + 1);
						goto IL_04f7;
						IL_04ff:
						num = 74;
						if (Strings.Len (array2 [2]) > 0) {
							goto IL_050e;
						}
						goto IL_0517;
						IL_050e:
						num = 75;
						Units.iUnitSys = 3;
						goto IL_0517;
						IL_0517:
						num = 76;
						num15 = (short)Information.UBound (Units.UnitSys [Units.iUnitSys].UnitIndex);
						num5 = 1;
						goto IL_0568;
						IL_0568:
						if (num5 <= num15) {
							goto IL_053c;
						}
						goto IL_056e;
						IL_056e:
						num = 79;
						DepedentUnits (ref Units.DefaultUnitIndex);
						goto end_IL_0000_3;
						IL_053c:
						num = 77;
						Units.DefaultUnitIndex [num5] = Units.UnitSys [Units.iUnitSys].UnitIndex [num5];
						goto IL_055e;
						IL_055e:
						num = 78;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0568;
						IL_010f:
						num = 22;
						Units.DefaultUnitIndex [num5] = Units.UnitSys [Units.iUnitSys].UnitIndex [num5];
						goto IL_0131;
						IL_0131:
						num = 23;
						Units.UnitSys [3].UnitIndex [num5] = Units.DefaultUnitIndex [num5];
						goto IL_014f;
						IL_014f:
						num = 24;
						num5 = (short)unchecked(num5 + 1);
						goto IL_0159;
						IL_0580:
						num = 81;
						if (bytAction != 1) {
							goto end_IL_0000_3;
						}
						goto IL_058a;
						IL_058a:
						num = 82;
						array2 [1] = Units.UnitSys [Units.iUnitSys].Name;
						goto IL_05a5;
						IL_05a5:
						num = 83;
						array2 [2] = Units.untLength [Units.UnitSys [3].UnitIndex [1]].Name;
						goto IL_05cd;
						IL_05cd:
						num = 84;
						array2 [3] = Units.untLength [Units.UnitSys [3].UnitIndex [2]].Name;
						goto IL_05f5;
						IL_05f5:
						num = 85;
						array2 [4] = Units.untAngle [Units.UnitSys [3].UnitIndex [3]].Name;
						goto IL_061d;
						IL_061d:
						num = 86;
						array2 [5] = Units.untForce [Units.UnitSys [3].UnitIndex [4]].Name;
						goto IL_0645;
						IL_0645:
						num = 87;
						array2 [6] = Units.untStress [Units.UnitSys [3].UnitIndex [5]].Name;
						goto IL_066d;
						IL_066d:
						num = 88;
						array2 [7] = Units.untMoment [Units.UnitSys [3].UnitIndex [6]].Name;
						goto IL_0695;
						IL_0695:
						num = 89;
						registryKey2 = Registry.CurrentUser.CreateSubKey (text);
						goto IL_06a6;
						IL_06a6:
						num = 90;
						num16 = (short)Information.UBound (array);
						num5 = 1;
						goto IL_06d6;
						IL_06d6:
						if (num5 > num16) {
							break;
						}
						goto IL_06b8;
						IL_06b8:
						num = 91;
						registryKey2.SetValue (array [num5], array2 [num5], RegistryValueKind.String);
						goto IL_06cc;
						end_IL_0000_2:
						break;
					}
					num = 93;
					registryKey2.Close ();
					break;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 2163;
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

	public static void DepedentUnits (ref byte[] DefaultUnitIndexTmp)
	{
		DefaultUnitIndexTmp [7] = DefaultUnitIndexTmp [1];
		DefaultUnitIndexTmp [8] = DefaultUnitIndexTmp [1];
		DefaultUnitIndexTmp [9] = DefaultUnitIndexTmp [1];
		DefaultUnitIndexTmp [10] = DefaultUnitIndexTmp [1];
		string text = Units.untForce [DefaultUnitIndexTmp [4]].Name + "/";
		checked {
			byte length = (byte)Strings.Len (text);
			float num = Units.untForce [DefaultUnitIndexTmp [4]].Mult / Units.untLength [DefaultUnitIndexTmp [2]].Mult;
			float num2 = float.MaxValue;
			short num3 = 1;
			short num4 = (short)Information.UBound (Units.untLoad);
			for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
				if (Units.untLoad [num5].Mult > 0f && Strings.StrComp (text, Strings.Left (Units.untLoad [num5].Name, length)) == 0 && System.Math.Abs (System.Math.Log (Units.untLoad [num5].Mult) - System.Math.Log (num)) < (double)num2) {
					num2 = (float)System.Math.Abs (System.Math.Log (Units.untLoad [num5].Mult) - System.Math.Log (num));
					num3 = num5;
				}
			}
			DefaultUnitIndexTmp [11] = (byte)num3;
			DefaultUnitIndexTmp [12] = DefaultUnitIndexTmp [4];
			DefaultUnitIndexTmp [13] = DefaultUnitIndexTmp [4];
			DefaultUnitIndexTmp [14] = DefaultUnitIndexTmp [4];
		}
	}

	public static void RegistryAssociations ()
	{
		RegistryKey rkroot = null;
		int num = 1;
		do {
			if (num == 1) {
				rkroot = Registry.CurrentUser;
			}
			if (num == 2) {
				rkroot = Registry.LocalMachine;
			}
			RegistryAssociation (rkroot, ".cfsa", "CFSAnalysis", "CFS Analysis");
			RegistryAssociation (rkroot, ".anl", "CFSAnalysis.1", "CFS Analysis");
			RegistryAssociation (rkroot, ".cfss", "CFSSection", "CFS Section");
			RegistryAssociation (rkroot, ".sct", "CFSSection.1", "CFS Section");
			RegistryAssociation (rkroot, ".cfsl", "CFSSectionLibrary", "CFS Section Library");
			RegistryAssociation (rkroot, ".scl", "CFSSectionLibrary.1", "CFS Section Library");
			num = checked(num + 1);
		} while (num <= 2);
	}

	public static void RegistryAssociation (RegistryKey rkroot, string strExtension, string strSubKey, string strName)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		RegistryKey registryKey = default(RegistryKey);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					ProjectData.ClearProjectError ();
					num2 = 2;
					registryKey = rkroot.CreateSubKey ("SOFTWARE\\Classes\\" + strExtension);
					if (registryKey != null) {
						registryKey.SetValue (string.Empty, strSubKey);
						registryKey.Close ();
					}
					registryKey = rkroot.CreateSubKey ("SOFTWARE\\Classes\\" + strSubKey);
					if (registryKey != null) {
						registryKey.SetValue (string.Empty, strName);
						registryKey.Close ();
					}
					registryKey = rkroot.CreateSubKey ("SOFTWARE\\Classes\\" + strSubKey + "\\DefaultIcon");
					if (registryKey != null) {
						registryKey.SetValue (string.Empty, Application.ExecutablePath + ",0");
						registryKey.Close ();
					}
					registryKey = rkroot.CreateSubKey ("SOFTWARE\\Classes\\" + strSubKey + "\\shell\\open\\command");
					if (registryKey != null) {
						registryKey.SetValue (string.Empty, "\"" + Application.ExecutablePath + "\" \"%1\"");
						registryKey.Close ();
					}
					break;
				case 242:
					num = -1;
					switch (num2) {
					case 2:
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
				registryKey?.Close ();
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 242;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	public static string DisplayWeb (WebTypes bytWeb)
	{
		return bytWeb switch {
			WebTypes.webNone => "None", 
			WebTypes.webSingle => "Single", 
			WebTypes.webDouble => "Double", 
			WebTypes.webNested => "Nested", 
			WebTypes.webCee => "Cee", 
			WebTypes.webZee => "Zee", 
			WebTypes.webHat => "Hat", 
			WebTypes.webDeck => "Deck", 
			WebTypes.webTube => "Tube", 
			_ => "NA", 
		};
	}

	public static string DisplayFlange (Flanges bytFlange)
	{
		return bytFlange switch {
			Flanges.flgNone => "None", 
			Flanges.flgBottom => "Bottom", 
			Flanges.flgTop => "Top", 
			Flanges.flgLeft => "Left", 
			Flanges.flgRight => "Right", 
			_ => "NA", 
		};
	}

	public static string DisplayLoadType (LoadTypes bytLoadType)
	{
		return bytLoadType switch {
			LoadTypes.loadDist => "Distributed", 
			LoadTypes.loadConc => "Concentrated", 
			LoadTypes.loadAxial => "Axial", 
			LoadTypes.loadMoment => "Moment", 
			_ => "NA", 
		};
	}

	public static string DisplaySup (Supports bytSup)
	{
		return bytSup switch {
			Supports.supX => "X", 
			Supports.supY => "Y", 
			(Supports)3 => "XY", 
			Supports.supT => "T", 
			(Supports)5 => "XT", 
			(Supports)6 => "YT", 
			(Supports)7 => "XYT", 
			(Supports)10 => "YRx", 
			(Supports)11 => "XYRx", 
			(Supports)14 => "YTRx", 
			(Supports)15 => "XYTRx", 
			(Supports)17 => "XRy", 
			(Supports)19 => "XYRy", 
			(Supports)21 => "XTRy", 
			(Supports)23 => "XYTRy", 
			(Supports)27 => "XYRxRy", 
			(Supports)31 => "XYTRxRy", 
			Supports.supHx => "Hx", 
			Supports.supHy => "Hy", 
			(Supports)96 => "HxHy", 
			_ => "NA", 
		};
	}

	public static short FindAnlIndex (short intReport)
	{
		short result = 0;
		checked {
			if ((CFS.hdgReport [intReport].AppVer >= 1400) & (CFS.hdgReport [intReport].AppVer <= 1400)) {
				short num = (short)Information.UBound (CFS.hdgAnlPic);
				for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if (!CFS.hdgAnlPic [num2].Deleted & (Strings.StrComp (CFS.Analyses [num2].Filename, CFS.hdgReport [intReport].Filename, CompareMethod.Text) == 0) & (DateTime.Compare (CFS.Analyses [num2].RevDate, CFS.hdgReport [intReport].RevDate) == 0)) {
						result = num2;
						break;
					}
				}
			}
			return result;
		}
	}

	public static short FindAnlRptIndex (Analysis Analysis1)
	{
		short result = 0;
		Analysis analysis = Analysis1;
		checked {
			short num = (short)Information.UBound (CFS.hdgReport);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgReport [num2].Deleted & (Strings.StrComp (CFS.hdgReport [num2].Filename, analysis.Filename, CompareMethod.Text) == 0) & (DateTime.Compare (CFS.hdgReport [num2].RevDate, analysis.RevDate) == 0) & (CFS.hdgReport [num2].AppVer >= 1400) & (CFS.hdgReport [num2].AppVer <= 1400)) {
					result = num2;
					break;
				}
			}
			analysis = null;
			return result;
		}
	}

	public static short FindFreeIndex (Form[] frmName, Heading[] hdgHeading)
	{
		checked {
			short num = (short)Information.UBound (frmName);
			short num2 = 1;
			short result;
			while (true) {
				if (num2 <= num) {
					if (hdgHeading [num2].Deleted) {
						result = num2;
						hdgHeading [num2].Deleted = false;
						break;
					}
					num2 = (short)unchecked(num2 + 1);
					continue;
				}
				result = num2;
				break;
			}
			return result;
		}
	}

	public static short FindSctIndex (short intReport)
	{
		short result = 0;
		checked {
			if ((CFS.hdgReport [intReport].AppVer >= 1400) & (CFS.hdgReport [intReport].AppVer <= 1400)) {
				short num = (short)Information.UBound (CFS.hdgSctPic);
				for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if (!CFS.hdgSctPic [num2].Deleted & (Strings.StrComp (CFS.Sections [num2].Filename, CFS.hdgReport [intReport].Filename, CompareMethod.Text) == 0) & (DateTime.Compare (CFS.Sections [num2].RevDate, CFS.hdgReport [intReport].RevDate) == 0)) {
						result = num2;
						break;
					}
				}
			}
			return result;
		}
	}

	public static short FindSctRptIndex (Section Section1)
	{
		short result = 0;
		Section section = Section1;
		checked {
			short num = (short)Information.UBound (CFS.hdgReport);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgReport [num2].Deleted & (Strings.StrComp (CFS.hdgReport [num2].Filename, section.Filename, CompareMethod.Text) == 0) & (DateTime.Compare (CFS.hdgReport [num2].RevDate, section.RevDate) == 0) & (CFS.hdgReport [num2].AppVer >= 1400) & (CFS.hdgReport [num2].AppVer <= 1400)) {
					result = num2;
					break;
				}
			}
			section = null;
			return result;
		}
	}

	public static short NewAnlIndex ()
	{
		int try0000_dispatch = -1;
		short result = default(short);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						result = 0;
						ProjectData.ClearProjectError ();
						num2 = 2;
						short num3 = FindFreeIndex (CFS.frmAnlPic, CFS.hdgAnlPic);
						result = num3;
						if (num3 > Information.UBound (CFS.frmAnlPic)) {
							CFS.frmAnlPic = (frmAnlPicMaster[])Utils.CopyArray (CFS.frmAnlPic, new frmAnlPicMaster[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.hdgAnlPic)) {
							CFS.hdgAnlPic = (Heading[])Utils.CopyArray (CFS.hdgAnlPic, new Heading[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.Analyses)) {
							CFS.Analyses = (Analysis[])Utils.CopyArray (CFS.Analyses, new Analysis[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.AnlUndo, 2)) {
							CFS.AnlUndo = (Analysis[,])Utils.CopyArray (CFS.AnlUndo, new Analysis[10, num3 + 1]);
						}
						CFS.Analyses [num3] = new Analysis ();
						goto end_IL_0000;
					}
					case 242:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							goto end_IL_0000;
						}
						break;
					}
					goto IL_0128;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 242;
				continue;
			}
			break;
			IL_0128:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void NewRecentFile (string strFile)
	{
		short num = bytRecentFileCount;
		short num2 = 1;
		checked {
			while (num2 <= num && Strings.StrComp (strFile, strRecentFile [num2], CompareMethod.Text) != 0) {
				num2 = (short)unchecked(num2 + 1);
			}
			if (num2 > bytRecentFileCount) {
				if (bytRecentFileCount < Information.UBound (strRecentFile)) {
					bytRecentFileCount++;
				}
				num2 = bytRecentFileCount;
			}
			for (num2 = num2; num2 >= 2; num2 = (short)unchecked(num2 + -1)) {
				strRecentFile [num2] = strRecentFile [num2 - 1];
			}
			strRecentFile [1] = strFile;
			if (bytRecentFileCount > 0) {
				My.MyProject.Forms.mdiCFS.mnuFileRecent.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrRecent.Enabled = true;
			}
		}
	}

	public static void RemoveRecentFile (string strFile)
	{
		short num = bytRecentFileCount;
		short num2 = 1;
		checked {
			while (num2 <= num && Strings.StrComp (strFile, strRecentFile [num2], CompareMethod.Text) != 0) {
				num2 = (short)unchecked(num2 + 1);
			}
			if (num2 <= bytRecentFileCount) {
				bytRecentFileCount--;
				short num3 = num2;
				short num4 = bytRecentFileCount;
				for (num2 = num3; num2 <= num4; num2 = (short)unchecked(num2 + 1)) {
					strRecentFile [num2] = strRecentFile [num2 + 1];
				}
			}
			if (bytRecentFileCount == 0) {
				My.MyProject.Forms.mdiCFS.mnuFileRecent.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrRecent.Enabled = true;
			}
		}
	}

	public static short NewReport ()
	{
		int try0000_dispatch = -1;
		short result = default(short);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						result = 0;
						ProjectData.ClearProjectError ();
						num2 = 2;
						short num3 = FindFreeIndex (CFS.frmReport, CFS.hdgReport);
						result = num3;
						if (num3 > Information.UBound (CFS.frmReport)) {
							CFS.frmReport = (frmReportMaster[])Utils.CopyArray (CFS.frmReport, new frmReportMaster[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.hdgReport)) {
							CFS.hdgReport = (Heading[])Utils.CopyArray (CFS.hdgReport, new Heading[num3 + 1]);
						}
						CFS.frmReport [num3] = new frmReportMaster ((byte)num3);
						goto end_IL_0000;
					}
					case 158:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							goto end_IL_0000;
						}
						break;
					}
					goto IL_00d4;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 158;
				continue;
			}
			break;
			IL_00d4:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static short NewSctIndex ()
	{
		int try0000_dispatch = -1;
		short result = default(short);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						result = 0;
						ProjectData.ClearProjectError ();
						num2 = 2;
						short num3 = FindFreeIndex (CFS.frmSctPic, CFS.hdgSctPic);
						result = num3;
						if (num3 > Information.UBound (CFS.frmSctPic)) {
							CFS.frmSctPic = (frmSctPicMaster[])Utils.CopyArray (CFS.frmSctPic, new frmSctPicMaster[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.hdgSctPic)) {
							CFS.hdgSctPic = (Heading[])Utils.CopyArray (CFS.hdgSctPic, new Heading[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.Sections)) {
							CFS.Sections = (Section[])Utils.CopyArray (CFS.Sections, new Section[num3 + 1]);
						}
						if (num3 > Information.UBound (CFS.SctUndo, 2)) {
							CFS.SctUndo = (Section[,])Utils.CopyArray (CFS.SctUndo, new Section[10, num3 + 1]);
						}
						CFS.Sections [num3] = new Section ();
						goto end_IL_0000;
					}
					case 242:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							goto end_IL_0000;
						}
						break;
					}
					goto IL_0128;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 242;
				continue;
			}
			break;
			IL_0128:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static string NewSctFilename ()
	{
		checked {
			string text;
			bool flag;
			do {
				CFS.intSctNew++;
				text = "\\Section " + Conversions.ToString (CFS.intSctNew) + ".cfss";
				flag = false;
				int num = Information.UBound (CFS.Sections);
				for (int i = 1; i <= num; i++) {
					if ((Strings.StrComp (text, Strings.Right (CFS.Sections [i].Filename, Strings.Len (text)), CompareMethod.Text) == 0) & !CFS.hdgSctPic [i].Deleted) {
						flag = true;
						break;
					}
				}
			} while (flag);
			return text;
		}
	}

	public static string NewAnlFilename ()
	{
		checked {
			string text;
			bool flag;
			do {
				CFS.intAnlNew++;
				text = "\\Analysis " + Conversions.ToString (CFS.intAnlNew) + ".cfsa";
				flag = false;
				int num = Information.UBound (CFS.Analyses);
				for (int i = 1; i <= num; i++) {
					if ((Strings.StrComp (text, Strings.Right (CFS.Analyses [i].Filename, Strings.Len (text)), CompareMethod.Text) == 0) & !CFS.hdgAnlPic [i].Deleted) {
						flag = true;
						break;
					}
				}
			} while (flag);
			return text;
		}
	}

	public static void LoadFile (string strFileName = "")
	{
		if ($STATIC$LoadFile$011E$strFileNamePrev$Init == null) {
			Interlocked.CompareExchange (ref $STATIC$LoadFile$011E$strFileNamePrev$Init, new StaticLocalInitFlag (), null);
		}
		bool lockTaken = false;
		try {
			Monitor.Enter ($STATIC$LoadFile$011E$strFileNamePrev$Init, ref lockTaken);
			if ($STATIC$LoadFile$011E$strFileNamePrev$Init.State == 0) {
				$STATIC$LoadFile$011E$strFileNamePrev$Init.State = 2;
				$STATIC$LoadFile$011E$strFileNamePrev = string.Empty;
			} else if ($STATIC$LoadFile$011E$strFileNamePrev$Init.State == 2) {
				throw new IncompleteInitialization ();
			}
		} finally {
			$STATIC$LoadFile$011E$strFileNamePrev$Init.State = 1;
			if (lockTaken) {
				Monitor.Exit ($STATIC$LoadFile$011E$strFileNamePrev$Init);
			}
		}
		string strMsg = string.Empty;
		if (Strings.Len (strFileName) == 0) {
			string text = "All CFS Files (*.cfss;*.cfsl;*.cfsa;*.sct;*.scl;*.anl)|*.cfss;*.cfsl;*.cfsa;*.sct;*.scl;*.anl";
			text += "|CFS Sections (*.cfss;*.sct)|*.cfss;*.sct";
			text += "|CFS Section Libraries (*.cfsl;*.scl)|*.cfsl;*.scl";
			text += "|CFS Analyses (*.cfsa;*.anl)|*.cfsa;*.anl";
			My.MyProject.Forms.mdiCFS.dlgOpenFile.Filter = text;
			My.MyProject.Forms.mdiCFS.dlgOpenFile.Title = "Open CFS File";
			My.MyProject.Forms.mdiCFS.dlgOpenFile.InitialDirectory = GetDirectoryName ($STATIC$LoadFile$011E$strFileNamePrev);
			My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName = GetFileName ($STATIC$LoadFile$011E$strFileNamePrev);
			if (My.MyProject.Forms.mdiCFS.dlgOpenFile.ShowDialog () == DialogResult.Cancel) {
				return;
			}
			strFileName = My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName;
			$STATIC$LoadFile$011E$strFileNamePrev = strFileName;
		}
		if ((Operators.CompareString (Strings.LCase (Strings.Right (strFileName, 5)), ".cfsl", TextCompare: false) == 0) | (Operators.CompareString (Strings.LCase (Strings.Right (strFileName, 4)), ".scl", TextCompare: false) == 0)) {
			My.MyProject.Forms.mdiCFS.dlgOpenFile.FileName = strFileName;
			My.MyProject.Forms.frmOpenLibSct.ShowDialog (My.MyProject.Forms.mdiCFS);
			strFileName = Conversions.ToString (My.MyProject.Forms.frmOpenLibSct.Tag);
			My.MyProject.Forms.frmOpenLibSct.Dispose ();
			if (Strings.Len (strFileName) == 0) {
				return;
			}
		}
		checked {
			if ((Operators.CompareString (Strings.LCase (Strings.Right (strFileName, 5)), ".cfsa", TextCompare: false) == 0) | (Operators.CompareString (Strings.LCase (Strings.Right (strFileName, 4)), ".anl", TextCompare: false) == 0)) {
				short num = (short)Information.UBound (CFS.Analyses);
				for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if ((Strings.StrComp (strFileName, CFS.Analyses [num2].Filename, CompareMethod.Text) == 0) & !CFS.hdgAnlPic [num2].Deleted) {
						CFS.intAnlNow = (byte)num2;
						bool flag = ((!CFS.blnAnlInpLoaded) ? true : false);
						if (!CFS.blnAnlInpLoaded) {
							if (My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked) {
								My.MyProject.Forms.frmAnlInp.Show (My.MyProject.Forms.mdiCFS);
							} else {
								My.MyProject.Forms.frmAnlInp.Show ();
							}
						}
						if (flag) {
							if (CFS.intAnlTabNow < 0) {
								CFS.intAnlTabNow = 0;
							}
							if (CFS.intAnlTabNow == 0) {
								My.MyProject.Forms.frmAnlInp.txtDescription.Select ();
							} else {
								My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.intAnlTabNow;
							}
						}
						return;
					}
				}
				Cursor.Current = Cursors.WaitCursor;
				short num3 = NewAnlIndex ();
				if (num3 > 0) {
					if (CFS.Analyses [num3].Load (strFileName, ref strMsg)) {
						CFS.intAnlNow = (byte)num3;
						if ((CFS.intSctNow == 0) & (CFS.Analyses [num3].nBeam > 0)) {
							CFS.intSctNow = 1;
						}
						bool flag = ((!CFS.blnAnlInpLoaded) ? true : false);
						Analysis analysis = CFS.Analyses [num3];
						short num4 = FindAnlRptIndex (CFS.Analyses [num3]);
						if ((num4 == 0) & (Strings.Len (analysis.Report) > 0)) {
							num4 = NewReport ();
							CFS.hdgReport [num4].Parent = 2;
							CFS.hdgReport [num4].Filename = analysis.Filename;
							CFS.hdgReport [num4].RevDate = analysis.RevDate;
							CFS.hdgReport [num4].RevBy = analysis.RevBy;
							CFS.hdgReport [num4].Description = analysis.Description;
							CFS.hdgReport [num4].Project = analysis.Project;
							CFS.hdgReport [num4].AppVer = analysis.AppVer;
							CFS.frmReport [num4].Text = "Report: " + GetFileName (analysis.Filename) + Strings.Space (1) + Conversions.ToString (analysis.RevDate);
							CFS.frmReport [num4].Tag = Conversions.ToString (unchecked((int)num4));
							CFS.frmReport [num4].Show ();
							CFS.frmReport [num4].Width = (int)System.Math.Round ((float)(CFS.frmReport [num4].Width - CFS.frmReport [num4].ClientSize.Width) + 601f);
							CFS.frmReport [num4].rtfReport.Rtf = string.Empty;
							CFS.frmReport [num4].rtfReport.SelectedRtf = analysis.Report;
							CFS.frmReport [num4].rtfReport.SelectionStart = 0;
							if ((analysis.AppVer < 1400) | (analysis.AppVer > 1400)) {
								strMsg += "The report for this analysis was created with a different version of CFS.  It cannot be appended.\r\n";
							}
						}
						if (!analysis.Saved) {
							analysis.RevDate = DateAndTime.Now;
							analysis.RevBy = CFS.User.Name;
						}
						analysis.AppVer = 1400;
						analysis = null;
						ShowAnl (num3);
						if (flag) {
							My.MyProject.Forms.frmAnlInp.txtDescription.Select ();
						}
						NewRecentFile (CFS.Analyses [num3].Filename);
					} else {
						strMsg += "Analysis file could not be opened.\r\n";
						CFS.hdgAnlPic [num3].Initialize ();
						RemoveRecentFile (CFS.Analyses [num3].Filename);
					}
				}
			} else {
				short num5 = (short)Information.UBound (CFS.Sections);
				for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
					if ((Strings.StrComp (strFileName, CFS.Sections [num6].Filename, CompareMethod.Text) == 0) & !CFS.hdgSctPic [num6].Deleted) {
						CFS.intSctNow = num6;
						bool flag = ((!CFS.blnSctInpLoaded) ? true : false);
						if (!CFS.blnSctInpLoaded) {
							if (My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked) {
								My.MyProject.Forms.frmSctInp.Show (My.MyProject.Forms.mdiCFS);
							} else {
								My.MyProject.Forms.frmSctInp.Show ();
							}
						}
						if (flag) {
							My.MyProject.Forms.frmSctInp.txtDescription.Select ();
						}
						return;
					}
				}
				Cursor.Current = Cursors.WaitCursor;
				short num3 = NewSctIndex ();
				if (num3 > 0) {
					if (CFS.Sections [num3].Load (strFileName, ref strMsg)) {
						CFS.intSctNow = num3;
						bool flag = ((!CFS.blnSctInpLoaded) ? true : false);
						Section section = CFS.Sections [num3];
						short num4 = FindSctRptIndex (CFS.Sections [num3]);
						if ((num4 == 0) & (Strings.Len (section.Report) > 0)) {
							num4 = NewReport ();
							CFS.hdgReport [num4].Parent = 1;
							CFS.hdgReport [num4].Filename = section.Filename;
							CFS.hdgReport [num4].RevDate = section.RevDate;
							CFS.hdgReport [num4].RevBy = section.RevBy;
							CFS.hdgReport [num4].Description = section.Description;
							CFS.hdgReport [num4].Project = section.Project;
							CFS.hdgReport [num4].AppVer = section.AppVer;
							CFS.frmReport [num4].Text = "Report: " + GetFileName (section.Filename) + Strings.Space (1) + Conversions.ToString (section.RevDate);
							CFS.frmReport [num4].Tag = Conversions.ToString (unchecked((int)num4));
							CFS.frmReport [num4].Show ();
							CFS.frmReport [num4].Width = (int)System.Math.Round ((float)(CFS.frmReport [num4].Width - CFS.frmReport [num4].ClientSize.Width) + 601f);
							CFS.frmReport [num4].rtfReport.Rtf = string.Empty;
							CFS.frmReport [num4].rtfReport.SelectedRtf = section.Report;
							CFS.frmReport [num4].rtfReport.SelectionStart = 0;
							if ((section.AppVer < 1400) | (section.AppVer > 1400)) {
								strMsg += "The report for this section was created with a different version of CFS.  It cannot be appended.\r\n";
							}
						}
						if (!section.Saved) {
							section.RevDate = DateAndTime.Now;
							section.RevBy = CFS.User.Name;
						}
						section.AppVer = 1400;
						section = null;
						ShowSct (num3);
						if (flag) {
							My.MyProject.Forms.frmSctInp.txtDescription.Select ();
						}
						NewRecentFile (CFS.Sections [num3].Filename);
					} else {
						strMsg += "Section file could not be opened.\r\n";
						CFS.hdgSctPic [num3].Initialize ();
						RemoveRecentFile (CFS.Sections [num3].Filename);
					}
				}
			}
			Cursor.Current = Cursors.Default;
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
		}
	}

	public static short LoadMultiSct (ref string strFileName, ref string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		short result = default(short);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						string text = string.Empty;
						string text2 = string.Empty;
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = 0;
						short num3 = (short)Strings.InStr (strFileName, "|");
						string text3;
						if (num3 > 0) {
							text = Strings.Left (strFileName, num3 - 1);
							text2 = text;
							if (Operators.CompareString (Strings.LCase (Strings.Right (text2, 4)), ".scl", TextCompare: false) == 0) {
								text2 = Path.ChangeExtension (text2, ".cfsl");
							}
							text3 = Strings.Mid (strFileName, num3 + 1);
						} else {
							text3 = strFileName;
						}
						string text4 = text3;
						if (Operators.CompareString (Strings.LCase (Strings.Right (text4, 4)), ".sct", TextCompare: false) == 0) {
							text4 = Path.ChangeExtension (text4, ".cfss");
						}
						short num4 = (short)Information.UBound (CFS.Sections);
						short num5 = 1;
						while (true) {
							if (num5 <= num4) {
								if (!CFS.hdgSctPic [num5].Deleted) {
									if (Strings.StrComp (strFileName, CFS.Sections [num5].Filename, CompareMethod.Text) == 0) {
										result = num5;
										break;
									}
									if (num3 == 0 && Strings.StrComp (text4, CFS.Sections [num5].Filename, CompareMethod.Text) == 0) {
										result = num5;
										break;
									}
									if (num3 > 0 && Strings.StrComp (text + "|" + text4, CFS.Sections [num5].Filename, CompareMethod.Text) == 0) {
										result = num5;
										break;
									}
									if (num3 > 0 && Strings.StrComp (text2 + "|" + text3, CFS.Sections [num5].Filename, CompareMethod.Text) == 0) {
										result = num5;
										break;
									}
									if (num3 > 0 && Strings.StrComp (text2 + "|" + text4, CFS.Sections [num5].Filename, CompareMethod.Text) == 0) {
										result = num5;
										break;
									}
								}
								num5 = (short)unchecked(num5 + 1);
								continue;
							}
							short num6 = NewSctIndex ();
							if (num6 <= 0) {
								break;
							}
							if (num3 > 0) {
								if (!File.Exists (text)) {
									strFileName = text2 + "|" + text3;
								}
							} else if (!File.Exists (strFileName)) {
								strFileName = text4;
							}
							if (CFS.Sections [num6].Load (strFileName, ref strMsg)) {
								Section section = CFS.Sections [num6];
								short num7 = FindSctRptIndex (CFS.Sections [num6]);
								if ((num7 == 0) & (Strings.Len (CFS.Sections [num6].Report) > 0)) {
									num7 = NewReport ();
									CFS.hdgReport [num7].Parent = 1;
									CFS.hdgReport [num7].Filename = section.Filename;
									CFS.hdgReport [num7].RevDate = section.RevDate;
									CFS.hdgReport [num7].RevBy = section.RevBy;
									CFS.hdgReport [num7].Description = section.Description;
									CFS.hdgReport [num7].Project = section.Project;
									CFS.hdgReport [num7].AppVer = section.AppVer;
									CFS.frmReport [num7].Text = "Report: " + GetFileName (section.Filename) + Strings.Space (1) + Conversions.ToString (section.RevDate);
									CFS.frmReport [num7].Tag = Conversions.ToString (unchecked((int)num7));
									CFS.frmReport [num7].Show ();
									CFS.frmReport [num7].Width = (int)System.Math.Round ((float)(CFS.frmReport [num7].Width - CFS.frmReport [num7].ClientRectangle.Width) + 601f);
									CFS.frmReport [num7].rtfReport.Rtf = string.Empty;
									CFS.frmReport [num7].rtfReport.SelectionStart = Strings.Len (CFS.frmReport [num7].rtfReport.Text);
									CFS.frmReport [num7].rtfReport.SelectedRtf = CFS.Sections [num6].Report;
									if ((section.AppVer < 1400) | (section.AppVer > 1400)) {
										strMsg = strMsg + "The report for " + section.Filename + " was created with a different version of CFS.  It cannot be appended.\r\n";
									}
								}
								if (!section.Saved) {
									section.RevDate = DateAndTime.Now;
									section.RevBy = CFS.User.Name;
								}
								section.AppVer = 1400;
								section = null;
								CFS.frmSctPic [num6] = new frmSctPicMaster ((byte)num6);
								CFS.frmSctPic [num6].Text = GetFileName (CFS.Sections [num6].Filename);
								CFS.frmSctPic [num6].Show ();
								NewRecentFile (CFS.Sections [num6].Filename);
								result = num6;
							} else {
								strMsg = strMsg + CFS.Sections [num6].Filename + " could not be opened.\r\n";
								CFS.hdgSctPic [num6] = new Heading (string.Empty);
								RemoveRecentFile (CFS.Sections [num6].Filename);
							}
							break;
						}
						goto end_IL_0000;
					}
					case 1277:
						num = -1;
						switch (num2) {
						case 2:
							strMsg = strMsg + Information.Err ().Description + "\r\n";
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000;
						}
						break;
					}
					goto IL_0533;
				}
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1277;
				continue;
			}
			break;
			IL_0533:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void ImportDXFFile (string strFileName)
	{
		string strMsg = string.Empty;
		short num = NewSctIndex ();
		if (CFS.Sections [num].ImportDXF (strFileName, ref strMsg)) {
			CFS.intSctNow = num;
			Section obj = CFS.Sections [num];
			obj.Saved = false;
			obj.RevDate = DateAndTime.Now;
			obj.RevBy = CFS.User.Name;
			obj.AppVer = 1400;
			_ = null;
			ShowSct (num);
			if (!CFS.blnSctInpLoaded) {
				My.MyProject.Forms.frmSctInp.txtDescription.Select ();
			}
			string prompt;
			if (CFS.Sections [num].nPart == 1) {
				prompt = "One part imported.\nMaterial properties and web elements must still be specified.";
			} else {
				prompt = Conversions.ToString (CFS.Sections [num].nPart) + " parts imported.\n";
				prompt += "Material properties and web elements must still be specified.\n";
				prompt += "J Override, Cw Override, and Connector Spacing may also need to be specified.";
			}
			Interaction.MsgBox (prompt, MsgBoxStyle.Information);
			return;
		}
		CFS.hdgSctPic [num].Deleted = true;
		checked {
			if (Strings.Len (strMsg) > 400) {
				short num2 = 400;
				while (Operators.CompareString (Strings.Mid (strMsg, num2, 1), "\n", TextCompare: false) != 0) {
					num2 = (short)unchecked(num2 + -1);
					if (num2 < 1) {
						break;
					}
				}
				strMsg = Strings.Left (strMsg, num2);
			}
			string prompt = "No parts imported. Refer to Help for DXF requirements.\n" + strMsg;
			Interaction.MsgBox (prompt, MsgBoxStyle.Exclamation);
		}
	}

	public static bool SaveSct (byte iSct, bool blnSaveAs = false)
	{
		string strMsg = string.Empty;
		string text = string.Empty;
		bool flag = false;
		Section section = CFS.Sections [iSct];
		short num = checked((short)Strings.InStr (1, section.Filename, "|"));
		section.Report = string.Empty;
		if (((short)(0u - ((blnSaveAs | LikeOperator.LikeString (section.Filename, Strings.Trim ("\\Section ") + "*", CompareMethod.Binary)) ? 1u : 0u)) | num) != 0) {
			if (CFS.intLicenseType != 0) {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.Filter = "Section (*.cfss)|*.cfss|CAD (*.dxf)|*.dxf";
			} else {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.Filter = "Section (*.cfss)|*.cfss";
			}
			My.MyProject.Forms.mdiCFS.dlgSaveFile.FilterIndex = 1;
			My.MyProject.Forms.mdiCFS.dlgSaveFile.Title = "Save Section";
			if (((short)(0u - (LikeOperator.LikeString (section.Filename, Strings.Trim ("\\Section ") + "*", CompareMethod.Binary) ? 1u : 0u)) | num) != 0) {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = string.Empty;
				if (LikeOperator.LikeString (section.Filename, Strings.Trim ("\\Section ") + "*", CompareMethod.Binary)) {
					text = GetValidFileName (section.Description);
				}
			} else {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = GetDirectoryName (section.Filename);
			}
			if (text.Length > 0) {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName = text;
			} else {
				My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName = GetFileNameWithoutExtension (section.Filename);
			}
			if (My.MyProject.Forms.mdiCFS.dlgSaveFile.ShowDialog () == DialogResult.Cancel) {
				goto IL_051c;
			}
			Cursor.Current = Cursors.WaitCursor;
			if (My.MyProject.Forms.mdiCFS.dlgSaveFile.FilterIndex == 2) {
				flag = CFS.Sections [iSct].SaveAsDXF (My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName, Units.untLength [Units.DefaultUnitIndex [1]].Mult, ref strMsg);
				if (strMsg.Length > 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
			} else {
				short num2 = FindSctRptIndex (CFS.Sections [iSct]);
				string filename = section.Filename;
				section.Filename = My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName;
				if (Operators.CompareString (Strings.Right (section.Filename, 5).ToLower (), ".cfss", TextCompare: false) != 0) {
					section.Filename += ".cfss";
				}
				if (num2 > 0) {
					CFS.Sections [iSct].Report = CFS.frmReport [num2].rtfReport.Rtf;
					CFS.hdgReport [num2].Filename = section.Filename;
					CFS.frmReport [num2].Text = "Report: " + GetFileName (section.Filename) + Strings.Space (1) + Conversions.ToString (section.RevDate);
				}
				if (CFS.Sections [iSct].Save (ref strMsg)) {
					if (Strings.Len (section.Filename) != 0) {
						CFS.frmSctPic [iSct].Text = GetFileName (section.Filename);
						if ((iSct == CFS.intSctNow) & CFS.blnSctInpLoaded) {
							My.MyProject.Forms.frmSctInp.Text = "Section Inputs: " + CFS.frmSctPic [iSct].Text;
						}
					}
					CFS.blnRefreshGrdBeams = true;
					UpdateAnl (iSct);
					NewRecentFile (section.Filename);
					flag = true;
				} else {
					section.Filename = filename;
					if (num2 > 0) {
						CFS.hdgReport [num2].Filename = section.Filename;
						CFS.frmReport [num2].Text = "Report: " + GetFileName (section.Filename) + Strings.Space (1) + Conversions.ToString (section.RevDate);
					}
				}
			}
		} else {
			short num2 = FindSctRptIndex (CFS.Sections [iSct]);
			if (num2 > 0) {
				CFS.Sections [iSct].Report = CFS.frmReport [num2].rtfReport.Rtf;
			}
			if (Operators.CompareString (Strings.LCase (Path.GetExtension (section.Filename)), ".sct", TextCompare: false) == 0) {
				RemoveRecentFile (section.Filename);
				section.Filename = Path.ChangeExtension (section.Filename, ".cfss");
				CFS.frmSctPic [iSct].Text = GetFileName (section.Filename);
				if ((iSct == CFS.intSctNow) & CFS.blnSctInpLoaded) {
					My.MyProject.Forms.frmSctInp.Text = "Section Inputs: " + CFS.frmSctPic [iSct].Text;
				}
				UpdateAnl (iSct);
				NewRecentFile (section.Filename);
			}
			if (CFS.Sections [iSct].Save (ref strMsg)) {
				flag = true;
			}
		}
		if (!flag) {
			strMsg = "Section file could not be saved.\r\n" + strMsg;
		}
		section = null;
		Cursor.Current = Cursors.Default;
		if (Strings.Len (strMsg) != 0) {
			Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
		}
		goto IL_051c;
		IL_051c:
		return flag;
	}

	public static bool ShowSct (short hIndex)
	{
		int try0000_dispatch = -1;
		bool result = default(bool);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					result = false;
					ProjectData.ClearProjectError ();
					num2 = 2;
					CFS.frmSctPic [hIndex] = new frmSctPicMaster (checked((byte)hIndex));
					CFS.frmSctPic [hIndex].Text = GetFileName (CFS.Sections [hIndex].Filename);
					CFS.frmSctPic [hIndex].Tag = Conversions.ToString ((int)hIndex);
					CFS.frmSctPic [hIndex].Show ();
					CFS.blnRefreshGrdElements = true;
					RefreshSct (CFS.Sections [hIndex]);
					My.MyProject.Forms.frmSctInp.Text = "Section Inputs: " + CFS.frmSctPic [hIndex].Text;
					Application.DoEvents ();
					if (!CFS.blnSctInpLoaded) {
						if (My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked) {
							My.MyProject.Forms.frmSctInp.Show (My.MyProject.Forms.mdiCFS);
						} else {
							My.MyProject.Forms.frmSctInp.Show ();
						}
					}
					result = true;
					goto end_IL_0000;
				case 249:
					num = -1;
					switch (num2) {
					case 2:
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						goto end_IL_0000;
					}
					break;
				}
				goto IL_012f;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 249;
				continue;
			}
			break;
			IL_012f:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void RefreshSct (Section Section1, bool blnPartList = true)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		float num5 = default(float);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						if (!CFS.blnSctInpLoaded) {
							goto end_IL_0000;
						}
						CFS.blnValidate = false;
						Section section = Section1;
						switch (My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex) {
						case 0:
							My.MyProject.Forms.frmSctInp.txtDescription.Text = section.Description;
							My.MyProject.Forms.frmSctInp.txtDescription.SelectAll ();
							My.MyProject.Forms.frmSctInp.txtProject.Text = section.Project;
							My.MyProject.Forms.frmSctInp.txtProject.SelectAll ();
							My.MyProject.Forms.frmSctInp.txtRevised.Text = Conversions.ToString (section.RevDate) + " by " + section.RevBy;
							My.MyProject.Forms.frmSctInp.txtRevised.SelectAll ();
							RebuildMtlList (section.Material, section.MaterialIndex, My.MyProject.Forms.frmSctInp.cboMaterial);
							NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.cboYield.Tag, null, "Min", new object[1] { section.Material.FyMin }, null, null, OptimisticSet: false, RValueBase: true);
							NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.cboYield.Tag, null, "Max", new object[1] { section.Material.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
							NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.cboTensile.Tag, null, "Min", new object[1] { section.Material.FuMin }, null, null, OptimisticSet: false, RValueBase: true);
							NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.cboTensile.Tag, null, "Max", new object[1] { section.Material.FuMax }, null, null, OptimisticSet: false, RValueBase: true);
							SetText (My.MyProject.Forms.frmSctInp.cboYield, section.Material.Fy [2]);
							SetText (My.MyProject.Forms.frmSctInp.cboTensile, section.Material.Fu);
							SetText (My.MyProject.Forms.frmSctInp.cboJOverride, section.JOverride);
							SetText (My.MyProject.Forms.frmSctInp.cboCwOverride, section.CwOverride);
							SetText (My.MyProject.Forms.frmSctInp.cboConnSpacing, section.ConnSpacing);
							SetText (My.MyProject.Forms.frmSctInp.cboHoleLength, section.HoleLength);
							SetText (My.MyProject.Forms.frmSctInp.cboHoleSpacing, section.HoleSpacing);
							My.MyProject.Forms.frmSctInp.cboYield.Enabled = section.Material.IsCarbon ();
							My.MyProject.Forms.frmSctInp.cboTensile.Enabled = section.Material.IsCarbon ();
							My.MyProject.Forms.frmSctInp.chkColdWork.Checked = section.ColdWork;
							My.MyProject.Forms.frmSctInp.chkReserve.Checked = section.Reserve;
							break;
						case 1:
							if (blnPartList) {
								My.MyProject.Forms.frmSctInp.cboPartName.Items.Clear ();
								short nPart2 = section.nPart;
								for (short num3 = 1; num3 <= nPart2; num3 = (short)unchecked(num3 + 1)) {
									My.MyProject.Forms.frmSctInp.cboPartName.Items.Add (section.Part [num3].Name);
								}
								My.MyProject.Forms.frmSctInp.AddPart (My.MyProject.Forms.frmSctInp.cboPartName);
								My.MyProject.Forms.frmSctInp.cboPartName.SelectedIndex = unchecked((int)section.iPart) - 1;
								My.MyProject.Forms.frmSctInp.cboPartName.SelectAll ();
							}
							if (section.Part [section.iPart].ThicknessIndex == -1) {
								My.MyProject.Forms.frmSctInp.cboThicknessName.SelectedIndex = -1;
							} else {
								My.MyProject.Forms.frmSctInp.cboThicknessName.SelectedIndex = section.Part [section.iPart].ThicknessIndex - 1;
							}
							SetText (My.MyProject.Forms.frmSctInp.cboThickness, section.Part [section.iPart].Thickness);
							SetText (My.MyProject.Forms.frmSctInp.cboRadius, section.Part [section.iPart].DefRad);
							My.MyProject.Forms.frmSctInp.chkCenterline.Checked = section.Part [section.iPart].Centerline;
							My.MyProject.Forms.frmSctInp.chkClosed.Checked = section.Part [section.iPart].Closed;
							My.MyProject.Forms.frmSctInp.cboReferenceX.SelectedIndex = section.Part [section.iPart].iXPosition;
							My.MyProject.Forms.frmSctInp.cboReferenceY.SelectedIndex = section.Part [section.iPart].iYPosition;
							switch (section.Part [section.iPart].iXPosition) {
							case 0:
								num5 = 0f - section.Part [section.iPart].Xleft;
								break;
							case 1:
								num5 = 0f;
								break;
							case 2:
								num5 = section.Part [section.iPart].Xright;
								break;
							}
							SetText (My.MyProject.Forms.frmSctInp.cboX, section.Part [section.iPart].XPosition + num5);
							switch (section.Part [section.iPart].iYPosition) {
							case 0:
								num5 = section.Part [section.iPart].Ytop;
								break;
							case 1:
								num5 = 0f;
								break;
							case 2:
								num5 = 0f - section.Part [section.iPart].Ybottom;
								break;
							}
							SetText (My.MyProject.Forms.frmSctInp.cboY, section.Part [section.iPart].YPosition + num5);
							My.MyProject.Forms.frmSctInp.txtX1.Text = Units.DisplayLen1 (section.Part [section.iPart].Xleft, 0, blnShowUnit: true, "", 0, 0);
							My.MyProject.Forms.frmSctInp.txtX2.Text = Units.DisplayLen1 (section.Part [section.iPart].Xright, 0, blnShowUnit: true, "", 0, 0);
							My.MyProject.Forms.frmSctInp.txtY1.Text = Units.DisplayLen1 (section.Part [section.iPart].Ybottom, 0, blnShowUnit: true, "", 0, 0);
							My.MyProject.Forms.frmSctInp.txtY2.Text = Units.DisplayLen1 (section.Part [section.iPart].Ytop, 0, blnShowUnit: true, "", 0, 0);
							break;
						case 2: {
							My.MyProject.Forms.frmSctInp.cboPartList.Items.Clear ();
							short nPart = section.nPart;
							for (short num3 = 1; num3 <= nPart; num3 = (short)unchecked(num3 + 1)) {
								My.MyProject.Forms.frmSctInp.cboPartList.Items.Add (section.Part [num3].Name);
							}
							My.MyProject.Forms.frmSctInp.AddPart (My.MyProject.Forms.frmSctInp.cboPartList);
							My.MyProject.Forms.frmSctInp.cboPartList.SelectedIndex = unchecked((int)section.iPart) - 1;
							if (CFS.blnRefreshGrdElements) {
								Cursor current = Cursor.Current;
								Cursor.Current = Cursors.WaitCursor;
								My.MyProject.Forms.frmSctInp.blnCodeChange = true;
								if (section.Part [section.iPart].Closed & (section.Part [section.iPart].nElem > 0)) {
									My.MyProject.Forms.frmSctInp.grdElements.Rows = unchecked((int)section.Part [section.iPart].nElem) + 1;
									My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = false;
									My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).ClearText ();
								} else {
									My.MyProject.Forms.frmSctInp.grdElements.Rows = unchecked((int)section.Part [section.iPart].nElem) + 2;
									My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = false;
									My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).ClearText ();
									My.MyProject.Forms.frmSctInp.grdElements.Range (My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 2, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = true;
								}
								if (My.MyProject.Forms.frmSctInp.grdElements.Rows - 1 == 255) {
									My.MyProject.Forms.frmSctInp.grdElements.Range (255, 1, 255, 7).Locked = true;
								}
								short nElem = section.Part [section.iPart].nElem;
								short num4;
								for (num4 = 1; num4 <= nElem; num4 = (short)unchecked(num4 + 1)) {
									ref Element reference = ref section.Part [section.iPart].Element [num4];
									unchecked {
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 0).Text = Conversions.ToString ((int)num4);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 1).Text = Units.DisplayLen1 (reference.Len, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 2).Text = Units.DisplayAngle (reference.Ang, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 3).Text = Units.DisplayLen1 (reference.Rad, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 4).Text = DisplayWeb ((WebTypes)reference.Web);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 5).Text = Units.FormatNum (reference.K);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 6).Text = Units.DisplayLen1 (reference.Hole, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 7).Text = Units.DisplayLen1 (reference.Dist, 0, blnShowUnit: false, "", 0, 0);
									}
								}
								if (num4 == My.MyProject.Forms.frmSctInp.grdElements.Rows - 1) {
									My.MyProject.Forms.frmSctInp.grdElements.Cell (num4, 0).Text = string.Empty;
								}
								My.MyProject.Forms.frmSctInp.blnCodeChange = false;
								CFS.blnRefreshGrdElements = false;
								Cursor.Current = current;
							}
							SetGrid (My.MyProject.Forms.frmSctInp.grdElements, section.Part [section.iPart].ElemGrid);
							break;
						}
						case 3:
							My.MyProject.Forms.frmSctInp.blnCodeChange = true;
							My.MyProject.Forms.frmSctInp.cmdDSM.Enabled = section.nPart == 1;
							My.MyProject.Forms.frmSctInp.chkUseDSM.Checked = section.DSM.UseDSM;
							My.MyProject.Forms.frmSctInp.chkPrequalified.Checked = section.DSM.PreQualified;
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (1, 1).Text = Units.DisplayNone (section.DSM.Pcrl, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (1, 2).Text = Units.DisplayNone (section.DSM.Pcrd, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (3, 1).Text = Units.DisplayNone (section.DSM.Mcrlxp, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (3, 2).Text = Units.DisplayNone (section.DSM.Mcrdxp, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (4, 1).Text = Units.DisplayNone (section.DSM.Mcrlxn, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (4, 2).Text = Units.DisplayNone (section.DSM.Mcrdxn, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (5, 1).Text = Units.DisplayNone (section.DSM.Mcrlyp, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (5, 2).Text = Units.DisplayNone (section.DSM.Mcrdyp, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (6, 1).Text = Units.DisplayNone (section.DSM.Mcrlyn, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (6, 2).Text = Units.DisplayNone (section.DSM.Mcrdyn, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (8, 1).Text = Units.DisplayNone (section.DSM.Vcry, "", 0, 0);
							My.MyProject.Forms.frmSctInp.grdDSM.Cell (9, 1).Text = Units.DisplayNone (section.DSM.Vcrx, "", 0, 0);
							My.MyProject.Forms.frmSctInp.blnCodeChange = false;
							break;
						}
						section = null;
						CFS.blnValidate = true;
						goto end_IL_0000_2;
					}
					case 3869:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							goto end_IL_0000_2;
						}
						break;
					}
					goto IL_0f53;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 3869;
				continue;
			}
			break;
			IL_0f53:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	public static void RefreshElem (Section Section1, short intElem)
	{
		bool blnCodeChange = My.MyProject.Forms.frmSctInp.blnCodeChange;
		CFS.blnValidate = false;
		Section section = Section1;
		My.MyProject.Forms.frmSctInp.blnCodeChange = true;
		ref Element reference;
		checked {
			if (section.Part [section.iPart].Closed & (section.Part [section.iPart].nElem > 0)) {
				My.MyProject.Forms.frmSctInp.grdElements.Rows = unchecked((int)section.Part [section.iPart].nElem) + 1;
				My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = false;
			} else {
				My.MyProject.Forms.frmSctInp.grdElements.Rows = unchecked((int)section.Part [section.iPart].nElem) + 2;
				My.MyProject.Forms.frmSctInp.grdElements.Range (1, 1, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = false;
				My.MyProject.Forms.frmSctInp.grdElements.Range (My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 2, My.MyProject.Forms.frmSctInp.grdElements.Rows - 1, 7).Locked = true;
			}
			reference = ref section.Part [section.iPart].Element [intElem];
		}
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 0).Text = Conversions.ToString ((int)intElem);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 1).Text = Units.DisplayLen1 (reference.Len, 0, blnShowUnit: false, "", 0, 0);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 2).Text = Units.DisplayAngle (reference.Ang, 0, blnShowUnit: false, "", 0, 0);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 3).Text = Units.DisplayLen1 (reference.Rad, 0, blnShowUnit: false, "", 0, 0);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 4).Text = DisplayWeb ((WebTypes)reference.Web);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 5).Text = Units.FormatNum (reference.K);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 6).Text = Units.DisplayLen1 (reference.Hole, 0, blnShowUnit: false, "", 0, 0);
		My.MyProject.Forms.frmSctInp.grdElements.Cell (intElem, 7).Text = Units.DisplayLen1 (reference.Dist, 0, blnShowUnit: false, "", 0, 0);
		My.MyProject.Forms.frmSctInp.blnCodeChange = blnCodeChange;
		section = null;
		CFS.blnValidate = true;
	}

	public static void RebuildMtlList (MaterialType Material, short MaterialIndex, System.Windows.Forms.ComboBox cboName)
	{
		MaterialType materialType = Material;
		checked {
			if (MaterialIndex == 0) {
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboName.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
					NewLateBinding.LateSetComplex (cboName.Items [0], null, "Text", new object[1] { Strings.Trim (materialType.Name) }, null, null, OptimisticSet: false, RValueBase: true);
					cboName.DisplayMember = "Text";
					cboName.DisplayMember = "";
				} else {
					cboName.Items.Insert (0, new ListItem (Strings.Trim (materialType.Name), 0));
				}
				cboName.SelectedIndex = 0;
			} else {
				if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (cboName.Items [0], null, "ItemData", new object[0], null, null, null), 0, TextCompare: false)) {
					cboName.Items.RemoveAt (0);
				}
				short num = (short)(cboName.Items.Count - 1);
				for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if (Operators.ConditionalCompareObjectEqual (MaterialIndex, NewLateBinding.LateGet (cboName.Items [num2], null, "ItemData", new object[0], null, null, null), TextCompare: false)) {
						cboName.SelectedIndex = num2;
						break;
					}
				}
			}
			materialType = null;
		}
	}

	public static void PlotSct (frmSctPicMaster frm, Section Section1)
	{
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		if (frm.WindowState == FormWindowState.Minimized) {
			return;
		}
		if (frm.SG != null) {
			frm.SG.Dispose ();
		}
		frm.SG = new ScaleGraphics (frm.picSct);
		Section section = Section1;
		float num = frm.SG.Height / frm.SG.Width;
		section.Extents ();
		float num2 = section.Xmin;
		float num3 = section.Ymin;
		float num4 = section.Xmax;
		float num5 = section.Ymax;
		if (num2 > 0f) {
			num2 = 0f;
		}
		if (num3 > 0f) {
			num3 = 0f;
		}
		if (num4 < 0f) {
			num4 = 0f;
		}
		if (num5 < 0f) {
			num5 = 0f;
		}
		if (section.SctProp) {
			if (section.Prop.Xcg + section.Prop.Xo < num2) {
				num2 = section.Prop.Xcg + section.Prop.Xo;
			}
			if (section.Prop.Ycg + section.Prop.Yo < num3) {
				num3 = section.Prop.Ycg + section.Prop.Yo;
			}
			if (section.Prop.Xcg + section.Prop.Xo > num4) {
				num4 = section.Prop.Xcg + section.Prop.Xo;
			}
			if (section.Prop.Ycg + section.Prop.Yo > num5) {
				num5 = section.Prop.Ycg + section.Prop.Yo;
			}
		}
		section.ExtXmin = num2;
		section.ExtYmin = num3;
		section.ExtXmax = num4;
		section.ExtYmax = num5;
		if (num2 == num4 && num3 == num5) {
			frm.SG.PreserveImage ();
			return;
		}
		float num6 = (1f - section.ZoomX) * num2 + section.ZoomX * num4;
		float num7 = (1f - section.ZoomY) * num3 + section.ZoomY * num5;
		float num8 = (float)((double)(num4 - num2) * 0.525 / (double)section.Zoom);
		float num9 = (float)((double)(num5 - num3) * 0.525 / (double)section.Zoom);
		if (num * num8 > num9) {
			num9 = num * num8;
		} else {
			num8 = num9 / num;
		}
		float num10 = ((!(frm.SG.Width / num8 > frm.SG.Height / num9)) ? ((float)(0.5 * (double)frm.SG.Height / (double)num9)) : ((float)(0.5 * (double)frm.SG.Width / (double)num8)));
		if (section.nPart > 0) {
			frm.SG.Scale (num6 - num8, num7 + num9, num6 + num8, num7 - num9);
			pen.Width = 1f / num10;
		}
		float num11 = (float)(0.04 * (double)num8 * (double)section.Zoom);
		short nPart = section.nPart;
		checked {
			for (short num12 = 1; num12 <= nPart; num12 = (short)unchecked(num12 + 1)) {
				float thickness = section.Part [num12].Thickness;
				num8 = section.Part [num12].XPosition - section.Part [num12].Xcg;
				num9 = section.Part [num12].YPosition - section.Part [num12].Ycg;
				frm.SG.DrawDot (pen, section.Part [num12].XPosition, section.Part [num12].YPosition, 2);
				if (section.Part [num12].nElem > 0) {
					float ang = section.Part [num12].Element [section.Part [num12].nElem].Ang;
					short nElem = section.Part [num12].nElem;
					for (short num13 = 1; num13 <= nElem; num13 = (short)unchecked(num13 + 1)) {
						if ((num13 > 1) | section.Part [num12].Closed) {
							num6 = num8 + section.Part [num12].Element [num13].Xac;
							num7 = num9 + section.Part [num12].Element [num13].Yac;
							PlotArc (frm.SG.Graphics, pen, num6, num7, section.Part [num12].Element [num13].Rad, ang, section.Part [num12].Element [num13].Arc, num10);
							PlotArc (frm.SG.Graphics, pen, num6, num7, section.Part [num12].Element [num13].Rad + thickness, ang, section.Part [num12].Element [num13].Arc, num10);
						}
						ang = section.Part [num12].Element [num13].Ang;
						float num14 = (float)((double)(thickness / 2f) * System.Math.Sin (ang));
						float num15 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (ang));
						num2 = num8 + section.Part [num12].Element [num13].X0;
						num3 = num9 + section.Part [num12].Element [num13].Y0;
						num4 = num8 + section.Part [num12].Element [num13].X1;
						num5 = num9 + section.Part [num12].Element [num13].Y1;
						if ((num13 == 1) & !section.Part [num12].Closed) {
							frm.SG.Graphics.DrawLine (pen, num2 - num14, num3 - num15, num2 + num14, num3 + num15);
						}
						if ((num13 == 1) & !section.Part [num12].Closed) {
							frm.SG.Graphics.DrawLine (pen, num2 - num14, num3 - num15, num2 + num14, num3 + num15);
						}
						frm.SG.Graphics.DrawLine (pen, num2 - num14, num3 - num15, num4 - num14, num5 - num15);
						frm.SG.Graphics.DrawLine (pen, num2 + num14, num3 + num15, num4 + num14, num5 + num15);
						if ((num13 == section.Part [num12].nElem) & !section.Part [num12].Closed) {
							frm.SG.Graphics.DrawLine (pen, num4 - num14, num5 - num15, num4 + num14, num5 + num15);
						}
						if (section.Part [num12].Element [num13].Hole > 0f) {
							num2 = num8 + section.Part [num12].Element [num13].Xh0;
							num3 = num9 + section.Part [num12].Element [num13].Yh0;
							num4 = num8 + section.Part [num12].Element [num13].Xh1;
							num5 = num9 + section.Part [num12].Element [num13].Yh1;
							frm.SG.Graphics.DrawLine (pen, num2 - num14, num3 - num15, num2 + num14, num3 + num15);
							frm.SG.Graphics.DrawLine (pen, num2, num3, num4, num5);
							frm.SG.Graphics.DrawLine (pen, num4 - num14, num5 - num15, num4 + num14, num5 + num15);
						}
					}
				}
			}
			if (section.nPart > 0) {
				frm.SG.Graphics.DrawLine (pen, 0f - num11, 0f, num11, 0f);
				frm.SG.Graphics.DrawLine (pen, 0f, 0f - num11, 0f, num11);
				if (section.SctProp) {
					num8 = (float)((double)num11 * System.Math.Cos (section.Prop.Alpha));
					num9 = (float)((double)num11 * System.Math.Sin (section.Prop.Alpha));
					frm.SG.Graphics.DrawLine (pen, section.Prop.Xcg - 5f * num8, section.Prop.Ycg - 5f * num9, section.Prop.Xcg + 5f * num8, section.Prop.Ycg + 5f * num9);
					frm.SG.Graphics.DrawLine (pen, section.Prop.Xcg - num9, section.Prop.Ycg + num8, section.Prop.Xcg + num9, section.Prop.Ycg - num8);
					frm.SG.Graphics.DrawLine (pen, section.Prop.Xcg + section.Prop.Xo - num11, section.Prop.Ycg + section.Prop.Yo, section.Prop.Xcg + section.Prop.Xo + num11, section.Prop.Ycg + section.Prop.Yo);
					frm.SG.Graphics.DrawLine (pen, section.Prop.Xcg + section.Prop.Xo, section.Prop.Ycg + section.Prop.Yo - num11, section.Prop.Xcg + section.Prop.Xo, section.Prop.Ycg + section.Prop.Yo + num11);
					frm.SG.Graphics.DrawEllipse (pen, section.Prop.Xcg + section.Prop.Xo - num11 / 2f, section.Prop.Ycg + section.Prop.Yo - num11 / 2f, num11, num11);
				}
			}
			if (section.iPt >= 1) {
				pen = new Pen (Color.Blue, 1f / num10);
				num8 = 4f * frm.SG.UnitsPerPixelX;
				num9 = 4f * frm.SG.UnitsPerPixelY;
				frm.SG.Graphics.DrawLine (pen, section.XPt [1] - num8, section.YPt [1] - num9, section.XPt [1] + num8, section.YPt [1] + num9);
				frm.SG.Graphics.DrawLine (pen, section.XPt [1] - num8, section.YPt [1] + num9, section.XPt [1] + num8, section.YPt [1] - num9);
				if (section.iPt >= 2) {
					frm.SG.Graphics.DrawLine (pen, section.XPt [2] - num8, section.YPt [2] - num9, section.XPt [2] + num8, section.YPt [2] + num9);
					frm.SG.Graphics.DrawLine (pen, section.XPt [2] - num8, section.YPt [2] + num9, section.XPt [2] + num8, section.YPt [2] - num9);
					frm.SG.Graphics.DrawLine (pen, section.XPt [1], section.YPt [1], section.XPt [2], section.YPt [2]);
					frm.SG.Graphics.DrawLine (pen, section.XPt [1], section.YPt [1], section.XPt [2], section.YPt [1]);
					frm.SG.Graphics.DrawLine (pen, section.XPt [2], section.YPt [1], section.XPt [2], section.YPt [2]);
					PointF point = frm.SG.TransformToDevice (new PointF ((section.XPt [1] + section.XPt [2]) / 2f, section.YPt [1]));
					PointF point2 = frm.SG.TransformToDevice (new PointF (section.XPt [2], (section.YPt [1] + section.YPt [2]) / 2f));
					PointF point3 = frm.SG.TransformToDevice (new PointF ((section.XPt [1] + section.XPt [2]) / 2f, (section.YPt [1] + section.YPt [2]) / 2f));
					frm.SG.SwapScale ();
					if (((double)System.Math.Abs (section.XPt [2] - section.XPt [1]) > 1E-05 * (double)(section.Xmax - section.Xmin)) & ((double)System.Math.Abs (section.YPt [2] - section.YPt [1]) > 1E-05 * (double)(section.Ymax - section.Ymin))) {
						frm.SG.Graphics.DrawString (Units.DisplayLen1 (System.Math.Abs (section.XPt [2] - section.XPt [1]), 0, blnShowUnit: true, "", 0, 0), frm.Font, brush, point);
						frm.SG.Graphics.DrawString (Units.DisplayLen1 (System.Math.Abs (section.YPt [2] - section.YPt [1]), 0, blnShowUnit: true, "", 0, 0), frm.Font, brush, point2);
					}
					frm.SG.Graphics.DrawString (Units.DisplayLen1 ((float)System.Math.Sqrt (System.Math.Pow (section.XPt [2] - section.XPt [1], 2.0) + System.Math.Pow (section.YPt [2] - section.YPt [1], 2.0)), 0, blnShowUnit: true, "", 0, 0), frm.Font, brush, point3);
					frm.SG.SwapScale ();
				}
			}
			section = null;
			if (My.MyProject.Forms.mdiCFS.mnuViewXYAxes.Checked) {
				frm.SG.SwapScale ();
				pen = new Pen (brush, 1f);
				num2 = 6f;
				num3 = frm.SG.Height - 6f;
				num11 = 20f;
				frm.SG.Graphics.DrawLine (pen, num2, num3, num2 + num11, num3);
				frm.SG.Graphics.DrawString ("X", frm.Font, brush, num2 + num11, num3 - 6f);
				frm.SG.Graphics.DrawLine (pen, num2, num3, num2, num3 - num11);
				frm.SG.Graphics.DrawString ("Y", frm.Font, brush, num2 - 5f, num3 - num11 - 12f);
				frm.SG.SwapScale ();
			}
			SelectElements (frm, Section1, 0, 0, 0);
		}
	}

	public static void SelectElements (frmSctPicMaster frm, Section Section1, byte bytSelPart = 0, byte bytSelElemStart = 0, byte bytSelElemEnd = 0)
	{
		Pen pen = new Pen (SystemColors.ControlText, 0f);
		Section section = Section1;
		float num = frm.SG.Height / frm.SG.Width;
		float num2 = (float)((double)(section.ExtXmax - section.ExtXmin) * 0.525 / (double)section.Zoom);
		float num3 = (float)((double)(section.ExtYmax - section.ExtYmin) * 0.525 / (double)section.Zoom);
		if (num * num2 > num3) {
			num3 = num * num2;
		} else {
			num2 = num3 / num;
		}
		if (num2 == 0f && num3 == 0f) {
			section.iPart = bytSelPart;
			return;
		}
		float num4 = ((!(frm.SG.Width / num2 > frm.SG.Height / num3)) ? ((float)(0.5 * (double)frm.SG.Height / (double)num3)) : ((float)(0.5 * (double)frm.SG.Width / (double)num2)));
		pen.Width = 1f / num4;
		short num5 = 1;
		checked {
			do {
				if (bytSelPart == 0) {
					num5 = 2;
				}
				if (num5 == 2) {
					pen = new Pen (Color.Blue, 1f / num4);
				}
				if (unchecked(((uint)section.iPart <= (uint)section.nPart) & (section.Part [section.iPart].nElem > 0) & (section.Part [section.iPart].ElemGrid.RowStart > 0) & ((uint)section.Part [section.iPart].ElemGrid.RowStart <= (uint)section.Part [section.iPart].nElem))) {
					float num6 = ((section.Part [section.iPart].ElemGrid.RowStart != 1) ? section.Part [section.iPart].Element [unchecked((int)section.Part [section.iPart].ElemGrid.RowStart) - 1].Ang : section.Part [section.iPart].Element [section.Part [section.iPart].nElem].Ang);
					float thickness = section.Part [section.iPart].Thickness;
					num2 = section.Part [section.iPart].XPosition - section.Part [section.iPart].Xcg;
					num3 = section.Part [section.iPart].YPosition - section.Part [section.iPart].Ycg;
					byte rowStart = section.Part [section.iPart].ElemGrid.RowStart;
					short rowEnd = section.Part [section.iPart].ElemGrid.RowEnd;
					short num7 = rowStart;
					while (num7 <= rowEnd && num7 <= section.Part [section.iPart].nElem) {
						if ((num7 > 1) | section.Part [section.iPart].Closed) {
							float x = num2 + section.Part [section.iPart].Element [num7].Xac;
							float y = num3 + section.Part [section.iPart].Element [num7].Yac;
							PlotArc (frm.SG.Graphics, pen, x, y, section.Part [section.iPart].Element [num7].Rad, num6, section.Part [section.iPart].Element [num7].Arc, num4);
							PlotArc (frm.SG.Graphics, pen, x, y, section.Part [section.iPart].Element [num7].Rad + thickness, num6, section.Part [section.iPart].Element [num7].Arc, num4);
						}
						num6 = section.Part [section.iPart].Element [num7].Ang;
						float num8 = (float)((double)(thickness / 2f) * System.Math.Sin (num6));
						float num9 = (float)((double)((0f - thickness) / 2f) * System.Math.Cos (num6));
						float num10 = num2 + section.Part [section.iPart].Element [num7].X0;
						float num11 = num3 + section.Part [section.iPart].Element [num7].Y0;
						float num12 = num2 + section.Part [section.iPart].Element [num7].X1;
						float num13 = num3 + section.Part [section.iPart].Element [num7].Y1;
						if ((num7 == 1) & !section.Part [section.iPart].Closed) {
							frm.SG.Graphics.DrawLine (pen, num10 - num8, num11 - num9, num10 + num8, num11 + num9);
						}
						frm.SG.Graphics.DrawLine (pen, num10 - num8, num11 - num9, num12 - num8, num13 - num9);
						frm.SG.Graphics.DrawLine (pen, num10 + num8, num11 + num9, num12 + num8, num13 + num9);
						if ((num7 == section.Part [section.iPart].nElem) & !section.Part [section.iPart].Closed) {
							frm.SG.Graphics.DrawLine (pen, num12 - num8, num13 - num9, num12 + num8, num13 + num9);
						}
						if (section.Part [section.iPart].Element [num7].Hole > 0f) {
							num10 = num2 + section.Part [section.iPart].Element [num7].Xh0;
							num11 = num3 + section.Part [section.iPart].Element [num7].Yh0;
							num12 = num2 + section.Part [section.iPart].Element [num7].Xh1;
							num13 = num3 + section.Part [section.iPart].Element [num7].Yh1;
							frm.SG.Graphics.DrawLine (pen, num10 - num8, num11 - num9, num10 + num8, num11 + num9);
							frm.SG.Graphics.DrawLine (pen, num10, num11, num12, num13);
							frm.SG.Graphics.DrawLine (pen, num12 - num8, num13 - num9, num12 + num8, num13 + num9);
						}
						num7 = (short)unchecked(num7 + 1);
					}
				}
				if (num5 == 2) {
					break;
				}
				section.iPart = bytSelPart;
				if (bytSelElemStart != 0) {
					if (bytSelElemEnd == 0) {
						bytSelElemEnd = bytSelElemStart;
					}
					if (bytSelElemStart < 1) {
						bytSelElemStart = 1;
					}
					if (bytSelElemEnd < 1) {
						bytSelElemEnd = 1;
					}
					short num14 = ((!section.Part [section.iPart].Closed) ? ((short)(unchecked((int)section.Part [section.iPart].nElem) + 1)) : section.Part [section.iPart].nElem);
					if (bytSelElemStart > num14) {
						bytSelElemStart = (byte)num14;
					}
					if (bytSelElemEnd > num14) {
						bytSelElemEnd = (byte)num14;
					}
					if (unchecked((uint)bytSelElemEnd < (uint)bytSelElemStart)) {
						CFS.Swap (ref bytSelElemStart, ref bytSelElemEnd);
					}
					section.Part [section.iPart].ElemGrid.RowStart = bytSelElemStart;
					section.Part [section.iPart].ElemGrid.RowEnd = bytSelElemEnd;
				}
				SetMenuEdit ();
				num5 = (short)unchecked(num5 + 1);
			} while (num5 <= 2);
			section = null;
			frm.SG.PreserveImage ();
		}
	}

	private static void PlotArc (Graphics g, Pen p, float X, float Y, float R, float A, float Arc, float S)
	{
		checked {
			short num = (short)System.Math.Round (R * S * System.Math.Abs (Arc));
			if (num == 0) {
				return;
			}
			float num2 = (float)((double)A - (double)System.Math.Sign (Arc) * System.Math.PI / 2.0);
			if (num < 5) {
				float x = (float)((double)X + (double)R * System.Math.Cos (num2));
				float y = (float)((double)Y + (double)R * System.Math.Sin (num2));
				int num3 = num;
				for (int i = 1; i <= num3; i++) {
					float num4 = num2 + Arc * (float)i / (float)num;
					float num5 = (float)((double)X + (double)R * System.Math.Cos (num4));
					float num6 = (float)((double)Y + (double)R * System.Math.Sin (num4));
					g.DrawLine (p, x, y, num5, num6);
					x = num5;
					y = num6;
				}
			} else {
				g.DrawArc (p, X - R, Y - R, 2f * R, 2f * R, (float)((double)(num2 * 180f) / System.Math.PI), (float)((double)(Arc * 180f) / System.Math.PI));
			}
		}
	}

	public static bool AddElement (Part Part1)
	{
		bool result = false;
		Part part = Part1;
		if (part.Closed) {
			if ((uint)part.nElem < 255u) {
				goto IL_0074;
			}
			Interaction.MsgBox ("Limit " + Conversions.ToString (byte.MaxValue) + " elements for a closed part.", MsgBoxStyle.Information);
		} else {
			if (part.nElem < 254) {
				goto IL_0074;
			}
			Interaction.MsgBox ("Limit " + Conversions.ToString (254) + " elements for an open part.", MsgBoxStyle.Information);
		}
		goto IL_01bb;
		IL_01bb:
		return result;
		IL_0074:
		checked {
			part.nElem++;
			if (part.nElem > Information.UBound (part.Element)) {
				ref Element[] element = ref part.Element;
				element = (Element[])Utils.CopyArray (element, new Element[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)part.nElem) / 10.0) * 10.0) + 1]);
			}
			if (part.nElem <= 1) {
				part.Element [part.nElem].Ang = 0f;
			} else {
				part.Element [part.nElem].Ang = part.Element [unchecked((int)part.nElem) - 1].Ang;
			}
			part.Element [part.nElem].Rad = part.DefRad;
			part.Element [part.nElem].Web = 1;
			part.Element [part.nElem].K = 0f;
			part.Element [part.nElem].Hole = 0f;
			part.Element [part.nElem].Dist = 0f;
			part = null;
			CFS.blnRefreshGrdElements = true;
			result = true;
			goto IL_01bb;
		}
	}

	public static void CopyElements (Part Part1, byte bytElemStart = 0, byte bytElemEnd = 0)
	{
		Part part = Part1;
		if (part.nElem <= 0 || (((uint)bytElemStart > (uint)part.nElem) & ((uint)bytElemEnd > (uint)part.nElem))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytElemStart == 0) {
				bytElemStart = 1;
				if (bytElemEnd == 0) {
					bytElemEnd = Conversions.ToByte (Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1));
				}
			} else if (bytElemEnd == 0) {
				bytElemEnd = bytElemStart;
			}
			if (unchecked((uint)bytElemEnd < (uint)bytElemStart)) {
				CFS.Swap (ref bytElemStart, ref bytElemEnd);
			}
			string text = string.Empty;
			if (Conversions.ToBoolean (Operators.AndObject (bytElemStart == 1, Operators.CompareObjectEqual (bytElemEnd, Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1), TextCompare: false)))) {
				bytClipBoard = 3;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Part";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbPart = Part1.Clone ();
				text = "CFS Part\t" + part.Name + "\r\nThickness\t" + Conversions.ToString (part.Thickness * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + Strings.Space (1) + Units.untLength [Units.DefaultUnitIndex [1]].Name + "\r\nRadius\t" + Conversions.ToString (part.DefRad * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + Strings.Space (1) + Units.untLength [Units.DefaultUnitIndex [1]].Name + "\r\nClosed\t" + Conversions.ToString (part.Closed) + "\r\n";
				float num = default(float);
				switch (part.iXPosition) {
				case 0:
					text += "Xleft\t";
					num = 0f - part.Xleft;
					break;
				case 1:
					text += "Xcg\t";
					num = 0f;
					break;
				case 2:
					text += "Xright\t";
					num = part.Xright;
					break;
				}
				text = text + Conversions.ToString ((part.XPosition + num) * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + Strings.Space (1) + Units.untLength [Units.DefaultUnitIndex [1]].Name + "\r\n";
				switch (part.iYPosition) {
				case 0:
					text += "Ytop\t";
					num = part.Ytop;
					break;
				case 1:
					text += "Ycg\t";
					num = 0f;
					break;
				case 2:
					text += "Ybottom\t";
					num = 0f - part.Ybottom;
					break;
				}
				text = text + Conversions.ToString ((part.YPosition + num) * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + Strings.Space (1) + Units.untLength [Units.DefaultUnitIndex [1]].Name + "\r\n";
				if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
					bytElemEnd = part.nElem;
				}
			} else {
				if (bytElemStart < 1) {
					bytElemStart = 1;
				}
				if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
					bytElemEnd = part.nElem;
				}
				short num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytElemEnd - bytElemStart)))) + 1);
				bytClipBoard = 2;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Elements";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbElement = new Element[num2 + 1];
				short num3 = num2;
				for (short num4 = 1; num4 <= num3; num4 = (short)unchecked(num4 + 1)) {
					cbElement [num4] = part.Element [(short)unchecked(bytElemStart + num4) - 1];
				}
			}
			byte num5 = bytElemStart;
			short num6 = bytElemEnd;
			for (short num4 = num5; num4 <= num6; num4 = (short)unchecked(num4 + 1)) {
				ref Element reference = ref part.Element [num4];
				text = text + Conversions.ToString (reference.Len * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\t" + Conversions.ToString (reference.Ang * Units.untAngle [Units.DefaultUnitIndex [3]].Mult) + "\t" + Conversions.ToString (reference.Rad * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\t" + DisplayWeb (unchecked((WebTypes)reference.Web)) + "\t" + Conversions.ToString (reference.K) + "\t" + Conversions.ToString (reference.Hole * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\t" + Conversions.ToString (reference.Dist * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\r\n";
			}
			strClipBoard = text;
			Clipboard.Clear ();
			Clipboard.SetText (strClipBoard);
			SetMenuEdit ();
			part = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void DeleteElements (Section Section1, byte bytPart, byte bytElemStart = 0, byte bytElemEnd = 0)
	{
		string strMsg = string.Empty;
		Part part = Section1.Part [bytPart];
		if (part.nElem <= 0 || (((uint)bytElemStart > (uint)part.nElem) & ((uint)bytElemEnd > (uint)part.nElem))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytElemStart == 0) {
				bytElemStart = 1;
				if (bytElemEnd == 0) {
					bytElemEnd = Conversions.ToByte (Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1));
				}
			} else if (bytElemEnd == 0) {
				bytElemEnd = bytElemStart;
			}
			if (unchecked((uint)bytElemEnd < (uint)bytElemStart)) {
				CFS.Swap (ref bytElemStart, ref bytElemEnd);
			}
			if (Conversions.ToBoolean (Operators.AndObject (bytElemStart == 1, Operators.CompareObjectEqual (bytElemEnd, Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1), TextCompare: false)))) {
				StoreUndoSct ("Delete Part");
				short num = (short)(unchecked((int)bytPart) + 1);
				short nPart = Section1.nPart;
				short num2;
				for (num2 = num; num2 <= nPart; num2 = (short)unchecked(num2 + 1)) {
					Section1.Part [num2 - 1] = Section1.Part [num2].Clone ();
				}
				Section1.Part [num2 - 1].Initialize (10);
				if (Section1.nPart > 0) {
					Section1.nPart--;
				}
				if (bytPart > 1) {
					Section1.iPart--;
				}
				if (Section1.nPart == 0) {
					Section1.Part [Section1.iPart].Name = "Part 1";
				}
			} else {
				StoreUndoSct ("Delete Elements");
				if (bytElemStart < 1) {
					bytElemStart = 1;
				}
				if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
					bytElemEnd = part.nElem;
				}
				if ((bytElemStart > 1) & unchecked((uint)bytElemEnd < (uint)part.nElem)) {
					byte b = (byte)(unchecked((int)bytElemStart) - 1);
					byte b2 = (byte)(unchecked((int)bytElemEnd) + 1);
					if (part.CollinearElements (part.Element [b], part.Element [b2])) {
						byte b3 = default(byte);
						if (unchecked((int)b2) + 1 <= part.nElem) {
							b3 = (byte)(unchecked((int)b2) + 1);
						} else if (part.Closed) {
							b3 = 1;
						}
						float num3 = (float)System.Math.Sqrt (System.Math.Pow (part.Element [b2].X1 - part.Element [b].X0, 2.0) + System.Math.Pow (part.Element [b2].Y1 - part.Element [b].Y0, 2.0));
						unchecked {
							if (part.Centerline) {
								if ((b > 1) | part.Closed) {
									num3 = (float)((double)num3 + (double)(part.Element [b].Rad + part.Thickness / 2f) * System.Math.Tan (System.Math.Abs (part.Element [b].Arc) / 2f));
								}
								if (((uint)b2 < (uint)part.nElem) | part.Closed) {
									num3 = (float)((double)num3 + (double)(part.Element [b3].Rad + part.Thickness / 2f) * System.Math.Tan (System.Math.Abs (part.Element [b3].Arc) / 2f));
								}
							} else {
								if ((b > 1) | part.Closed) {
									num3 = (float)((double)num3 + (double)(part.Element [b].Rad + part.Thickness) * System.Math.Tan (System.Math.Abs (part.Element [b].Arc) / 2f));
								}
								if (((uint)b2 < (uint)part.nElem) | part.Closed) {
									num3 = (float)((double)num3 + (double)(part.Element [b3].Rad + part.Thickness) * System.Math.Tan (System.Math.Abs (part.Element [b3].Arc) / 2f));
								}
							}
							part.Element [b].Len = num3;
							part.Element [b].K = 0f;
							part.Element [b].Hole = 0f;
							part.Element [b].Dist = num3 / 2f;
							bytElemEnd = b2;
							part.ElemGrid.RowStart = b;
							part.ElemGrid.RowEnd = b;
						}
					}
				}
				short num4 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytElemEnd - bytElemStart)))) + 1);
				short num5 = (short)(unchecked((int)bytElemEnd) + 1);
				short nElem = part.nElem;
				for (short num6 = num5; num6 <= nElem; num6 = (short)unchecked(num6 + 1)) {
					part.Element [(short)unchecked(num6 - num4)] = part.Element [num6];
				}
				part.nElem = (byte)(short)unchecked(part.nElem - num4);
				part.ElemGrid.RowStart = bytElemStart;
				part.ElemGrid.RowEnd = bytElemStart;
			}
			part = null;
			Section section = Section1;
			section.GeomChange = true;
			section.GeomChangeDSM = true;
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			bool blnChg = default(bool);
			section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			CFS.blnRefreshGrdElements = true;
			RefreshSct (CFS.Sections [CFS.intSctNow]);
			PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			UpdateAnl ((byte)CFS.intSctNow);
			SetMenuEdit ();
			section = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void InsertElements (Section Section1, byte bytPart, byte bytElemStart = 0, byte bytElemEnd = 0)
	{
		string strMsg = string.Empty;
		Part part = Section1.Part [bytPart];
		if (part.nElem <= 0 || (((uint)bytElemStart > (uint)part.nElem) & ((uint)bytElemEnd > (uint)part.nElem))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		if (bytElemStart == 0) {
			bytElemStart = 1;
		}
		if (bytElemEnd == 0) {
			bytElemEnd = 1;
		}
		if ((uint)bytElemEnd < (uint)bytElemStart) {
			CFS.Swap (ref bytElemStart, ref bytElemEnd);
		}
		if (bytElemStart < 1) {
			bytElemStart = 1;
		}
		checked {
			if (part.Closed) {
				if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
					bytElemEnd = part.nElem;
				}
			} else if (bytElemEnd > unchecked((int)part.nElem) + 1) {
				bytElemEnd = (byte)(unchecked((int)part.nElem) + 1);
			}
			short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytElemEnd - bytElemStart)))) + 1);
			short num2 = (short)unchecked(part.nElem + num);
			byte b = unchecked((byte)((!part.Closed) ? 254 : byte.MaxValue));
			if (num2 > b) {
				num2 = b;
				bytElemEnd = (byte)(unchecked((int)bytElemStart) + ((short)unchecked(num2 - part.nElem) - 1));
				if (unchecked((uint)bytElemEnd < (uint)bytElemStart)) {
					Cursor.Current = Cursors.Default;
					strMsg = ((!part.Closed) ? ("Limit " + Conversions.ToString (b) + " elements for an open part.") : ("Limit " + Conversions.ToString (b) + " elements for a closed part."));
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					return;
				}
				num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytElemEnd - bytElemStart)))) + 1);
			}
			StoreUndoSct ("Insert Elements");
			if (num2 > Information.UBound (part.Element)) {
				ref Element[] element = ref part.Element;
				element = (Element[])Utils.CopyArray (element, new Element[(int)System.Math.Round (System.Math.Ceiling ((double)num2 / 10.0) * 10.0) + 1]);
			}
			byte nElem = part.nElem;
			short num3 = bytElemStart;
			for (short num4 = nElem; num4 >= num3; num4 = (short)unchecked(num4 + -1)) {
				part.Element [(short)unchecked(num4 + num)] = part.Element [num4];
			}
			byte num5 = bytElemStart;
			short num6 = bytElemEnd;
			for (short num4 = num5; num4 <= num6; num4 = (short)unchecked(num4 + 1)) {
				part.Element [num4] = part.Element [bytElemStart];
			}
			part.nElem = (byte)num2;
			part = null;
			Section1.GeomChange = true;
			Section1.GeomChangeDSM = true;
			Section1.Saved = false;
			Section1.RevDate = DateAndTime.Now;
			Section1.RevBy = CFS.User.Name;
			Section1.SctProp = false;
			Section1.iPt = 0;
			bool blnChg = default(bool);
			Section1.Part [bytPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			CFS.blnRefreshGrdElements = true;
			RefreshSct (CFS.Sections [CFS.intSctNow]);
			PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			UpdateAnl ((byte)CFS.intSctNow);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void PasteElements (Section Section1, byte bytPart, byte bytElemStart = 0, byte bytElemEnd = 0)
	{
		string strMsg = string.Empty;
		if (((bytClipBoard != 2) & (bytClipBoard != 3)) || Strings.StrComp (strClipBoard, Clipboard.GetText ()) != 0) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytClipBoard == 2) {
				Part part = Section1.Part [bytPart];
				if (bytElemStart == 0) {
					bytElemStart = Conversions.ToByte (Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1));
				}
				if (bytElemEnd == 0) {
					bytElemEnd = Conversions.ToByte (Interaction.IIf (part.Closed, part.nElem, unchecked((int)part.nElem) + 1));
				}
				if (unchecked((uint)bytElemEnd < (uint)bytElemStart)) {
					CFS.Swap (ref bytElemStart, ref bytElemEnd);
				}
				if (bytElemStart < 1) {
					bytElemStart = 1;
				}
				if (part.Closed) {
					if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
						bytElemEnd = part.nElem;
					}
				} else if (bytElemEnd > unchecked((int)part.nElem) + 1) {
					bytElemEnd = (byte)(unchecked((int)part.nElem) + 1);
				}
				short num = (short)Information.UBound (cbElement);
				short num2;
				if (bytElemEnd == bytElemStart) {
					num2 = 0;
				} else {
					if (unchecked((uint)bytElemEnd > (uint)part.nElem)) {
						bytElemEnd = part.nElem;
					}
					num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytElemEnd - bytElemStart)))) + 1);
				}
				short num3 = (short)unchecked(checked((short)unchecked(part.nElem + num)) - num2);
				if (Operators.ConditionalCompareObjectGreater (num3, Interaction.IIf (part.Closed, byte.MaxValue, 254), TextCompare: false)) {
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("Too many elements to paste.", MsgBoxStyle.Information);
					return;
				}
				StoreUndoSct ("Paste Elements");
				if (num3 > Information.UBound (part.Element)) {
					ref Element[] element = ref part.Element;
					element = (Element[])Utils.CopyArray (element, new Element[(int)System.Math.Round (System.Math.Ceiling ((double)num3 / 10.0) * 10.0) + 1]);
				}
				if (num > num2) {
					byte nElem = part.nElem;
					short num4 = (short)unchecked(bytElemStart + num2);
					for (short num5 = nElem; num5 >= num4; num5 = (short)unchecked(num5 + -1)) {
						part.Element [(short)unchecked(num5 + checked((short)unchecked(num - num2)))] = part.Element [num5];
					}
				} else if (num2 > num) {
					short num6 = (short)unchecked(bytElemStart + num2);
					short nElem2 = part.nElem;
					for (short num5 = num6; num5 <= nElem2; num5 = (short)unchecked(num5 + 1)) {
						part.Element [(short)unchecked(num5 - checked((short)unchecked(num2 - num)))] = part.Element [num5];
					}
				}
				byte num7 = bytElemStart;
				short num8 = (short)((short)unchecked(bytElemStart + num) - 1);
				for (short num5 = num7; num5 <= num8; num5 = (short)unchecked(num5 + 1)) {
					part.Element [num5] = cbElement [(short)unchecked(num5 - bytElemStart) + 1];
				}
				part.nElem = (byte)num3;
				part.ElemGrid.RowStart = bytElemStart;
				part.ElemGrid.RowEnd = (byte)((short)unchecked(bytElemStart + num) - 1);
				part = null;
			} else if (bytClipBoard == 3) {
				Section section = Section1;
				StoreUndoSct ("Paste Part");
				short nPart = section.nPart;
				short num9 = 1;
				while (num9 <= nPart && Strings.StrComp (cbPart.Name, section.Part [num9].Name, CompareMethod.Text) != 0) {
					num9 = (short)unchecked(num9 + 1);
				}
				string text;
				if (num9 <= section.nPart) {
					num9 = 0;
					short num10;
					do {
						num9 = (short)(num9 + 1);
						short nPart2;
						unchecked {
							text = "Part " + Conversions.ToString ((int)checked((short)unchecked(section.nPart + num9)));
							nPart2 = section.nPart;
							num10 = 1;
						}
						while (num10 <= nPart2 && Strings.StrComp (section.Part [num10].Name, text, CompareMethod.Text) != 0) {
							num10 = (short)unchecked(num10 + 1);
						}
					} while (num10 <= section.nPart);
				} else {
					text = cbPart.Name;
				}
				section.nPart++;
				section.iPart = section.nPart;
				if (section.nPart > Information.UBound (section.Part)) {
					ref Part[] part2 = ref section.Part;
					part2 = (Part[])Utils.CopyArray (part2, new Part[unchecked((int)section.nPart) + 1]);
				}
				section.Part [section.nPart] = cbPart.Clone ();
				section.Part [section.nPart].Name = text;
				section = null;
			}
			Section section2 = Section1;
			if (unchecked((uint)section2.iPart > (uint)section2.nPart)) {
				section2.nPart = section2.iPart;
			}
			section2.GeomChange = true;
			section2.GeomChangeDSM = true;
			section2.Saved = false;
			section2.RevDate = DateAndTime.Now;
			section2.RevBy = CFS.User.Name;
			section2.SctProp = false;
			section2.iPt = 0;
			bool blnChg = default(bool);
			section2.Part [section2.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			CFS.blnRefreshGrdElements = true;
			RefreshSct (CFS.Sections [CFS.intSctNow]);
			PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			UpdateAnl ((byte)CFS.intSctNow);
			SetMenuEdit ();
			section2 = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void CombineElements (Section Section1)
	{
		float num = 1E-05f;
		bool flag = false;
		short num2 = 0;
		short num3 = 0;
		int nPart = Section1.nPart;
		checked {
			for (int i = 1; i <= nPart; i++) {
				Part part = Section1.Part [i];
				for (short num4 = 1; num4 < part.nElem; num4 = (short)(num4 + 1)) {
					if ((System.Math.Abs (System.Math.Sin ((part.Element [num4].Ang - part.Element [num4 + 1].Ang) / 2f)) < (double)num) & (part.Element [num4].K == 0f) & (part.Element [num4 + 1].K == 0f)) {
						if (num2 == 0) {
							num2 = num4;
						}
						if (num4 + 1 == part.nElem) {
							num3 = part.nElem;
						}
					} else if (num2 > 0) {
						num3 = num4;
					}
					if (num3 > num2) {
						if (!flag) {
							StoreUndoSct ("Combine Elements");
						}
						float num5 = -1f;
						float num6 = 0f;
						float num7 = 0f;
						short num8 = num2;
						short num9 = num3;
						for (short num10 = num8; num10 <= num9; num10 = (short)unchecked(num10 + 1)) {
							if (part.Element [num10].Hole > 0f) {
								if (num5 < 0f) {
									num5 = num7 + part.Element [num10].Dist - part.Element [num10].Hole / 2f;
								}
								num6 = num7 + part.Element [num10].Dist + part.Element [num10].Hole / 2f;
							}
							num7 += part.Element [num10].Len;
						}
						part.Element [num2].Len = num7;
						if (num6 > 0f) {
							part.Element [num2].Hole = num6 - num5;
							part.Element [num2].Dist = num5 + part.Element [num2].Hole / 2f;
						} else {
							part.Element [num2].Hole = 0f;
							part.Element [num2].Dist = num7 / 2f;
						}
						ref byte nElem = ref part.nElem;
						nElem = (byte)(short)unchecked(nElem - checked((short)unchecked(num3 - num2)));
						int num11 = num2 + 1;
						int nElem2 = part.nElem;
						for (int j = num11; j <= nElem2; j++) {
							part.Element [j] = part.Element [j + num3 - num2];
						}
						num4 = num2;
						num2 = 0;
						num3 = 0;
						flag = true;
					}
				}
				if ((part.Closed && System.Math.Abs (System.Math.Sin ((part.Element [part.nElem].Ang - part.Element [1].Ang) / 2f)) < (double)num) & (part.Element [part.nElem].K == 0f) & (part.Element [1].K == 0f)) {
					if (!flag) {
						StoreUndoSct ("Combine Elements");
					}
					float num12 = -1f;
					float num13 = 0f;
					if (part.Element [part.nElem].Hole > 0f) {
						if (num12 < 0f) {
							num12 = part.Element [part.nElem].Dist - part.Element [part.nElem].Hole / 2f;
						}
						num13 = part.Element [part.nElem].Dist + part.Element [part.nElem].Hole / 2f;
					}
					if (part.Element [1].Hole > 0f) {
						if (num12 < 0f) {
							num12 = part.Element [part.nElem].Len + part.Element [1].Dist - part.Element [1].Hole / 2f;
						}
						num13 = part.Element [part.nElem].Len + part.Element [1].Dist + part.Element [1].Hole / 2f;
					}
					part.Element [1].Len += part.Element [part.nElem].Len;
					if (num13 > 0f) {
						part.Element [1].Hole = num13 - num12;
						part.Element [1].Dist = num12 + part.Element [1].Hole / 2f;
					} else {
						part.Element [1].Hole = 0f;
						part.Element [1].Dist = part.Element [1].Len / 2f;
					}
					part.nElem--;
					flag = true;
				}
				part = null;
			}
			if (flag) {
				string strMsg = string.Empty;
				Section section = Section1;
				section.Saved = false;
				section.RevDate = DateAndTime.Now;
				section.RevBy = CFS.User.Name;
				section.SctProp = false;
				section.iPt = 0;
				int nPart2 = section.nPart;
				bool blnChg = default(bool);
				for (int k = 1; k <= nPart2; k++) {
					section.Part [k].Geometry (ref blnChg, ref strMsg);
				}
				CFS.blnRefreshGrdElements = true;
				RefreshSct (CFS.Sections [CFS.intSctNow]);
				PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				UpdateAnl ((byte)CFS.intSctNow);
				SetMenuEdit ();
				section = null;
				strMsg = "Some adjacent elements are in the same direction and have been combined.";
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
		}
	}

	public static bool SaveAnl (byte iAnl, bool blnSaveAs = false)
	{
		string text = string.Empty;
		string text2 = string.Empty;
		bool flag = false;
		Analysis analysis = CFS.Analyses [iAnl];
		SortBeams (CFS.Analyses [iAnl]);
		SortSups (CFS.Analyses [iAnl]);
		short nLdg = analysis.nLdg;
		checked {
			for (short num = 1; num <= nLdg; num = (short)unchecked(num + 1)) {
				SortLoads (ref analysis.Ldg [num]);
			}
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			short nBeam = analysis.nBeam;
			short num2 = 1;
			while (true) {
				if (num2 <= nBeam) {
					if (!CFS.Sections [analysis.Beam [num2].iSct].Saved && (!SaveSct (analysis.Beam [num2].iSct) || !CFS.Sections [analysis.Beam [num2].iSct].Saved)) {
						break;
					}
					num2 = (short)unchecked(num2 + 1);
					continue;
				}
				analysis.Report = string.Empty;
				if (blnSaveAs | LikeOperator.LikeString (analysis.Filename, Strings.Trim ("\\Analysis ") + "*", CompareMethod.Binary)) {
					My.MyProject.Forms.mdiCFS.dlgSaveFile.Filter = "Analysis (*.cfsa)|*.cfsa";
					My.MyProject.Forms.mdiCFS.dlgSaveFile.FilterIndex = 1;
					My.MyProject.Forms.mdiCFS.dlgSaveFile.Title = "Save Analysis";
					if (LikeOperator.LikeString (analysis.Filename, Strings.Trim ("\\Analysis ") + "*", CompareMethod.Binary)) {
						My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = string.Empty;
						text2 = GetValidFileName (analysis.Description);
					} else {
						My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = GetDirectoryName (analysis.Filename);
					}
					if (text2.Length > 0) {
						My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName = text2;
					} else {
						My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName = GetFileNameWithoutExtension (analysis.Filename);
					}
					if (My.MyProject.Forms.mdiCFS.dlgSaveFile.ShowDialog () == DialogResult.Cancel) {
						break;
					}
					Cursor.Current = Cursors.WaitCursor;
					short num3 = FindAnlRptIndex (CFS.Analyses [iAnl]);
					string filename = analysis.Filename;
					analysis.Filename = My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName;
					if (Operators.CompareString (Strings.Right (analysis.Filename, 5).ToLower (), ".cfsa", TextCompare: false) != 0) {
						analysis.Filename += ".cfsa";
					}
					if (num3 > 0) {
						CFS.Analyses [iAnl].Report = CFS.frmReport [num3].rtfReport.Rtf;
						CFS.hdgReport [num3].Filename = My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName;
						CFS.frmReport [num3].Text = "Report: " + GetFileName (analysis.Filename) + Strings.Space (1) + Conversions.ToString (analysis.RevDate);
					}
					if (CFS.Analyses [iAnl].Save (text)) {
						if (Strings.Len (analysis.Filename) != 0) {
							CFS.frmAnlPic [iAnl].Text = GetFileName (analysis.Filename);
							if ((iAnl == CFS.intAnlNow) & CFS.blnAnlInpLoaded) {
								My.MyProject.Forms.frmAnlInp.Text = "Analysis Inputs: " + CFS.frmAnlPic [iAnl].Text;
							}
						}
						NewRecentFile (analysis.Filename);
						flag = true;
					} else {
						analysis.Filename = filename;
						if (num3 > 0) {
							CFS.hdgReport [num3].Filename = analysis.Filename;
							CFS.frmReport [num3].Text = "Report: " + GetFileName (analysis.Filename) + Strings.Space (1) + Conversions.ToString (analysis.RevDate);
						}
					}
				} else {
					short num3 = FindAnlRptIndex (CFS.Analyses [iAnl]);
					if (num3 > 0) {
						CFS.Analyses [iAnl].Report = CFS.frmReport [num3].rtfReport.Rtf;
					}
					if (Operators.CompareString (Strings.LCase (Path.GetExtension (analysis.Filename)), ".anl", TextCompare: false) == 0) {
						RemoveRecentFile (analysis.Filename);
						analysis.Filename = Path.ChangeExtension (analysis.Filename, ".cfsa");
						CFS.frmAnlPic [iAnl].Text = GetFileName (analysis.Filename);
						if ((iAnl == CFS.intAnlNow) & CFS.blnAnlInpLoaded) {
							My.MyProject.Forms.frmAnlInp.Text = "Analysis Inputs: " + CFS.frmAnlPic [iAnl].Text;
						}
						NewRecentFile (analysis.Filename);
					}
					if (CFS.Analyses [iAnl].Save (text)) {
						flag = true;
					}
				}
				if (!flag) {
					text = "Analysis file could not be saved.\r\n" + text;
				}
				analysis = null;
				Cursor.Current = Cursors.Default;
				if (Strings.Len (text) != 0) {
					Interaction.MsgBox (text, MsgBoxStyle.Information);
				}
				break;
			}
			return flag;
		}
	}

	public static bool ShowAnl (short hIndex)
	{
		int try0000_dispatch = -1;
		bool result = default(bool);
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					result = false;
					ProjectData.ClearProjectError ();
					num2 = 2;
					CFS.frmAnlPic [hIndex] = new frmAnlPicMaster (checked((byte)hIndex));
					CFS.frmAnlPic [hIndex].Text = GetFileName (CFS.Analyses [hIndex].Filename);
					CFS.frmAnlPic [hIndex].Tag = Conversions.ToString ((int)hIndex);
					CFS.frmAnlPic [hIndex].Show ();
					CFS.blnRefreshGrdBeams = true;
					CFS.blnRefreshGrdSupports = true;
					CFS.blnRefreshGrdLoads = true;
					CFS.blnRefreshGrdCombs = true;
					RefreshAnl (CFS.Analyses [hIndex]);
					My.MyProject.Forms.frmAnlInp.Text = "Analysis Inputs: " + CFS.frmAnlPic [hIndex].Text;
					Application.DoEvents ();
					if (!CFS.blnAnlInpLoaded) {
						if (My.MyProject.Forms.mdiCFS.mnuViewInputsOnTop.Checked) {
							My.MyProject.Forms.frmAnlInp.Show (My.MyProject.Forms.mdiCFS);
						} else {
							My.MyProject.Forms.frmAnlInp.Show ();
						}
					}
					result = true;
					goto end_IL_0000;
				case 267:
					num = -1;
					switch (num2) {
					case 2:
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						goto end_IL_0000;
					}
					break;
				}
				goto IL_0141;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 267;
				continue;
			}
			break;
			IL_0141:
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void RefreshAnl (Analysis Analysis1, bool blnList = true)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						if (!CFS.blnAnlInpLoaded) {
							goto end_IL_0000;
						}
						CFS.blnValidate = false;
						Analysis analysis = Analysis1;
						switch (My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex) {
						case 0:
							My.MyProject.Forms.frmAnlInp.txtDescription.Text = analysis.Description;
							My.MyProject.Forms.frmAnlInp.txtDescription.SelectAll ();
							My.MyProject.Forms.frmAnlInp.txtProject.Text = analysis.Project;
							My.MyProject.Forms.frmAnlInp.txtProject.SelectAll ();
							My.MyProject.Forms.frmAnlInp.txtRevised.Text = Conversions.ToString (analysis.RevDate) + " by " + analysis.RevBy;
							My.MyProject.Forms.frmAnlInp.txtRevised.SelectAll ();
							My.MyProject.Forms.frmAnlInp.cboOrientation.SelectedIndex = Conversions.ToInteger (Interaction.IIf (analysis.Vertical, 1, 0));
							My.MyProject.Forms.frmAnlInp.chkBucklingTheory.Checked = analysis.BucklingTheory;
							My.MyProject.Forms.frmAnlInp.chkTorsion.Checked = analysis.Torsion;
							break;
						case 1: {
							My.MyProject.Forms.frmAnlInp.grdBeams.ComboBox (1).Items.Clear ();
							short num10 = (short)Information.UBound (CFS.hdgSctPic);
							for (short num5 = 1; num5 <= num10; num5 = (short)unchecked(num5 + 1)) {
								if (!CFS.hdgSctPic [num5].Deleted) {
									My.MyProject.Forms.frmAnlInp.grdBeams.ComboBox (1).Items.Add (new ListItem (GetFileNameWithoutExtension (CFS.Sections [num5].Filename), num5));
								}
							}
							if (CFS.blnRefreshGrdBeams) {
								Cursor current = Cursor.Current;
								Cursor.Current = Cursors.WaitCursor;
								My.MyProject.Forms.frmAnlInp.blnCodeChange = true;
								My.MyProject.Forms.frmAnlInp.grdBeams.Rows = unchecked((int)analysis.nBeam) + 2;
								My.MyProject.Forms.frmAnlInp.grdBeams.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdBeams.Rows - 1, 9).Locked = false;
								My.MyProject.Forms.frmAnlInp.grdBeams.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdBeams.Rows - 1, 9).ClearText ();
								My.MyProject.Forms.frmAnlInp.grdBeams.Range (unchecked((int)analysis.nBeam) + 1, 2, unchecked((int)analysis.nBeam) + 1, 9).Locked = true;
								if (unchecked((int)analysis.nBeam) + 1 >= 255) {
									My.MyProject.Forms.frmAnlInp.grdBeams.Range (255, 1, 255, 1).Locked = true;
								}
								short nBeam = analysis.nBeam;
								for (short num11 = 1; num11 <= nBeam; num11 = (short)unchecked(num11 + 1)) {
									ref Beam reference3 = ref analysis.Beam [num11];
									unchecked {
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 0).Text = Conversions.ToString ((int)num11);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 1).Text = GetFileNameWithoutExtension (CFS.Sections [reference3.iSct].Filename);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 2).Text = Units.DisplayLength (reference3.Z0, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 3).Text = Units.DisplayLength (reference3.Z1, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 4).Text = DisplayFlange ((Flanges)reference3.iBrcFlg);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 5).Text = Units.FormatNum (reference3.R);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 6).Text = Units.DisplayForce (reference3.Kf, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 7).Text = Units.DisplayLength (reference3.Lm, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 8).Text = Units.DisplayLen1 (reference3.ex, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdBeams.Cell (num11, 9).Text = Units.DisplayLen1 (reference3.ey, 0, blnShowUnit: false, "", 0, 0);
									}
								}
								My.MyProject.Forms.frmAnlInp.blnCodeChange = false;
								CFS.blnRefreshGrdBeams = false;
								Cursor.Current = current;
							}
							SetGrid (My.MyProject.Forms.frmAnlInp.grdBeams, analysis.BeamGrid);
							break;
						}
						case 2:
							if (CFS.blnRefreshGrdSupports) {
								Cursor current = Cursor.Current;
								Cursor.Current = Cursors.WaitCursor;
								My.MyProject.Forms.frmAnlInp.blnCodeChange = true;
								My.MyProject.Forms.frmAnlInp.grdSupports.Rows = unchecked((int)analysis.nSup) + 2;
								My.MyProject.Forms.frmAnlInp.grdSupports.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdSupports.Rows - 1, 5).Locked = false;
								My.MyProject.Forms.frmAnlInp.grdSupports.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdSupports.Rows - 1, 5).ClearText ();
								My.MyProject.Forms.frmAnlInp.grdSupports.Range (unchecked((int)analysis.nSup) + 1, 2, unchecked((int)analysis.nSup) + 1, 5).Locked = true;
								if (unchecked((int)analysis.nSup) + 1 >= 255) {
									My.MyProject.Forms.frmAnlInp.grdSupports.Range (255, 1, 255, 1).Locked = true;
								}
								short nSup = analysis.nSup;
								for (short num9 = 1; num9 <= nSup; num9 = (short)unchecked(num9 + 1)) {
									ref Support reference2 = ref analysis.Sup [num9];
									unchecked {
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 0).Text = Conversions.ToString ((int)num9);
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 1).Text = DisplaySup ((Supports)reference2.Type);
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 2).Text = Units.DisplayLength (reference2.Z, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 3).Text = Units.DisplayLen1 (reference2.Wid, 0, blnShowUnit: false, "", 0, 0);
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 4).Text = Conversions.ToString (reference2.Fastened);
										My.MyProject.Forms.frmAnlInp.grdSupports.Cell (num9, 5).Text = Units.FormatNum (reference2.K);
									}
								}
								My.MyProject.Forms.frmAnlInp.blnCodeChange = false;
								CFS.blnRefreshGrdSupports = false;
								Cursor.Current = current;
							}
							SetGrid (My.MyProject.Forms.frmAnlInp.grdSupports, analysis.SupGrid);
							break;
						case 3:
							if (blnList) {
								My.MyProject.Forms.frmAnlInp.cboLoading.Items.Clear ();
								short nLdg2 = analysis.nLdg;
								for (short num6 = 1; num6 <= nLdg2; num6 = (short)unchecked(num6 + 1)) {
									My.MyProject.Forms.frmAnlInp.cboLoading.Items.Add (analysis.Ldg [num6].Description);
								}
								My.MyProject.Forms.frmAnlInp.AddLoading (My.MyProject.Forms.frmAnlInp.cboLoading);
								My.MyProject.Forms.frmAnlInp.cboLoading.SelectedIndex = unchecked((int)analysis.iLdg) - 1;
							}
							if (CFS.blnRefreshGrdLoads) {
								Cursor current = Cursor.Current;
								Cursor.Current = Cursors.WaitCursor;
								My.MyProject.Forms.frmAnlInp.blnCodeChange = true;
								My.MyProject.Forms.frmAnlInp.grdLoads.Rows = unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 2;
								My.MyProject.Forms.frmAnlInp.grdLoads.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdLoads.Rows - 1, 8).Locked = false;
								My.MyProject.Forms.frmAnlInp.grdLoads.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdLoads.Rows - 1, 8).ClearText ();
								My.MyProject.Forms.frmAnlInp.grdLoads.Range (unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1, 2, unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1, 8).Locked = true;
								if (unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1 >= 255) {
									My.MyProject.Forms.frmAnlInp.grdLoads.Range (255, 1, 255, 1).Locked = true;
								}
								short nLoad = analysis.Ldg [analysis.iLdg].nLoad;
								for (short num8 = 1; num8 <= nLoad; num8 = (short)unchecked(num8 + 1)) {
									ref Load reference = ref analysis.Ldg [analysis.iLdg].Load [num8];
									unchecked {
										My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 0).Text = Conversions.ToString ((int)num8);
										My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 1).Text = DisplayLoadType ((LoadTypes)reference.Type);
										switch (reference.Type) {
										case 1:
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 2).Text = Units.DisplayAngle (reference.Ang, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 3).Text = Units.DisplayLength (reference.Z0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Text = Units.DisplayLength (reference.Z1, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 5).Text = Units.DisplayLoad (reference.W0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Text = Units.DisplayLoad (reference.W1, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 7).Text = Units.untLoad [Units.DefaultUnitIndex [11]].Name;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Locked = true;
											break;
										case 2:
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 2).Text = Units.DisplayAngle (reference.Ang, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 3).Text = Units.DisplayLength (reference.Z0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Locked = true;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 5).Text = Units.DisplayForce (reference.W0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Locked = true;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 7).Text = Units.untForce [Units.DefaultUnitIndex [4]].Name;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Text = Units.DisplayLen1 (reference.Wid, 0, blnShowUnit: false, "", 0, 0);
											break;
										case 3:
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 2).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 2).Locked = true;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 3).Text = Units.DisplayLength (reference.Z0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Text = Units.DisplayLength (reference.Z1, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 5).Text = Units.DisplayForce (reference.W0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Text = Units.DisplayForce (reference.W1, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 7).Text = Units.untForce [Units.DefaultUnitIndex [4]].Name;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Locked = true;
											break;
										case 4:
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 2).Text = Units.DisplayAngle (reference.Ang, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 3).Text = Units.DisplayLength (reference.Z0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 4).Locked = true;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 5).Text = Units.DisplayMoment (reference.W0, 0, blnShowUnit: false, "", 0, 0);
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 6).Locked = true;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 7).Text = Units.untMoment [Units.DefaultUnitIndex [6]].Name;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Text = string.Empty;
											My.MyProject.Forms.frmAnlInp.grdLoads.Cell (num8, 8).Locked = true;
											break;
										}
									}
								}
								My.MyProject.Forms.frmAnlInp.blnCodeChange = false;
								CFS.blnRefreshGrdLoads = false;
								Cursor.Current = current;
							}
							SetGrid (My.MyProject.Forms.frmAnlInp.grdLoads, analysis.Ldg [analysis.iLdg].LoadGrid);
							break;
						case 4: {
							if (blnList) {
								My.MyProject.Forms.frmAnlInp.cboComb.Items.Clear ();
								short nComb = analysis.nComb;
								for (short num3 = 1; num3 <= nComb; num3 = (short)unchecked(num3 + 1)) {
									My.MyProject.Forms.frmAnlInp.cboComb.Items.Add (analysis.Comb [num3].Description);
								}
								My.MyProject.Forms.frmAnlInp.AddComb (My.MyProject.Forms.frmAnlInp.cboComb);
								My.MyProject.Forms.frmAnlInp.cboComb.SelectedIndex = unchecked((int)analysis.iComb) - 1;
							}
							My.MyProject.Forms.frmAnlInp.chkInflectionPoint.Checked = analysis.Comb [analysis.iComb].InflPt;
							My.MyProject.Forms.frmAnlInp.cboSpec.SelectedIndex = -1;
							short num4 = (short)(My.MyProject.Forms.frmAnlInp.cboSpec.Items.Count - 1);
							for (short num5 = 0; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
								if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (My.MyProject.Forms.frmAnlInp.cboSpec.Items [num5], null, "ItemData", new object[0], null, null, null), analysis.Comb [analysis.iComb].Spec, TextCompare: false)) {
									My.MyProject.Forms.frmAnlInp.cboSpec.SelectedIndex = num5;
									break;
								}
							}
							My.MyProject.Forms.frmAnlInp.chkAllCombos.Checked = analysis.AllCombos;
							My.MyProject.Forms.frmAnlInp.grdCombs.ComboBox (1).Items.Clear ();
							short nLdg = analysis.nLdg;
							for (short num6 = 0; num6 <= nLdg; num6 = (short)unchecked(num6 + 1)) {
								My.MyProject.Forms.frmAnlInp.grdCombs.ComboBox (1).Items.Add (analysis.Ldg [num6].Description);
							}
							if (CFS.blnRefreshGrdCombs) {
								Cursor current = Cursor.Current;
								Cursor.Current = Cursors.WaitCursor;
								My.MyProject.Forms.frmAnlInp.blnCodeChange = true;
								My.MyProject.Forms.frmAnlInp.grdCombs.Rows = unchecked((int)analysis.Comb [analysis.iComb].nLF) + 2;
								My.MyProject.Forms.frmAnlInp.grdCombs.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdCombs.Rows - 1, 2).Locked = false;
								My.MyProject.Forms.frmAnlInp.grdCombs.Range (1, 1, My.MyProject.Forms.frmAnlInp.grdCombs.Rows - 1, 2).ClearText ();
								My.MyProject.Forms.frmAnlInp.grdCombs.Range (unchecked((int)analysis.Comb [analysis.iComb].nLF) + 1, 2, unchecked((int)analysis.Comb [analysis.iComb].nLF) + 1, 2).Locked = true;
								if (unchecked((int)analysis.Comb [analysis.iComb].nLF) + 1 >= 255) {
									My.MyProject.Forms.frmAnlInp.grdCombs.Range (255, 1, 255, 1).Locked = true;
								}
								short nLF = analysis.Comb [analysis.iComb].nLF;
								for (short num7 = 1; num7 <= nLF; num7 = (short)unchecked(num7 + 1)) {
									My.MyProject.Forms.frmAnlInp.grdCombs.Cell (num7, 0).Text = Conversions.ToString (unchecked((int)num7));
									My.MyProject.Forms.frmAnlInp.grdCombs.Cell (num7, 1).Text = analysis.Ldg [analysis.Comb [analysis.iComb].LF [num7].iLdg].Description;
									My.MyProject.Forms.frmAnlInp.grdCombs.Cell (num7, 2).Text = Units.FormatNum (analysis.Comb [analysis.iComb].LF [num7].fLdg);
								}
								My.MyProject.Forms.frmAnlInp.blnCodeChange = false;
								CFS.blnRefreshGrdCombs = false;
								Cursor.Current = current;
							}
							SetGrid (My.MyProject.Forms.frmAnlInp.grdCombs, analysis.Comb [analysis.iComb].LFGrid);
							break;
						}
						case 5:
							My.MyProject.Forms.frmAnlInp.txtNotes.Text = analysis.Notes;
							break;
						}
						analysis = null;
						CFS.blnValidate = true;
						goto end_IL_0000_2;
					}
					case 5472:
						num = -1;
						switch (num2) {
						case 2:
							Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							goto end_IL_0000_2;
						}
						break;
					}
					goto IL_1596;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 5472;
				continue;
			}
			break;
			IL_1596:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	public static void UpdateAnl (byte iSct)
	{
		checked {
			short num = (short)Information.UBound (CFS.hdgAnlPic);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (!CFS.hdgAnlPic [num2].Deleted) {
					Analysis analysis = CFS.Analyses [num2];
					short nBeam = analysis.nBeam;
					for (short num3 = 1; num3 <= nBeam; num3 = (short)unchecked(num3 + 1)) {
						if (analysis.Beam [num3].iSct == iSct) {
							analysis.Saved = false;
							analysis.RevDate = DateAndTime.Now;
							analysis.RevBy = CFS.User.Name;
							analysis.iCombSol = 0;
							if (num2 == CFS.intAnlNow) {
								RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
							}
							PlotAnl (CFS.frmAnlPic [num2], CFS.Analyses [num2]);
							SetMenuEdit ();
							break;
						}
					}
					analysis = null;
					int num4 = 0;
					do {
						if (!Information.IsNothing (CFS.AnlUndo [num4, num2])) {
							Analysis analysis2 = CFS.AnlUndo [num4, num2];
							short nBeam2 = analysis2.nBeam;
							for (short num3 = 1; num3 <= nBeam2; num3 = (short)unchecked(num3 + 1)) {
								if (analysis2.Beam [num3].iSct == iSct) {
									analysis2.Saved = false;
									analysis2.RevDate = DateAndTime.Now;
									analysis2.RevBy = CFS.User.Name;
									analysis2.iCombSol = 0;
									break;
								}
							}
							analysis2 = null;
						}
						num4++;
					} while (num4 <= 9);
				}
			}
		}
	}

	public static void PlotAnl (frmAnlPicMaster frm, Analysis Analysis1)
	{
		float[] array = new float[5];
		Brush brush = new SolidBrush (SystemColors.ControlText);
		Pen pen = new Pen (brush, 0f);
		if (frm.WindowState == FormWindowState.Minimized) {
			return;
		}
		if (frm.SG != null) {
			frm.SG.Dispose ();
		}
		frm.SG = new ScaleGraphics (frm.picAnl);
		Analysis analysis = Analysis1;
		frm.SG.Graphics.DrawString ("Current Load Combination: " + analysis.Comb [analysis.iComb].Description, frm.Font, brush, frm.SG.ScaleLeft, frm.SG.ScaleTop);
		int nBeam = analysis.nBeam;
		checked {
			float xmin = default(float);
			float xmax = default(float);
			float ymin = default(float);
			float ymax = default(float);
			for (int i = 1; i <= nBeam; i++) {
				if (analysis.Beam [i].Z1 > analysis.Beam [i].Z0) {
					Section section = CFS.Sections [analysis.Beam [i].iSct];
					if (section.Xmin < xmin) {
						xmin = section.Xmin;
					}
					if (section.Xmax > xmax) {
						xmax = section.Xmax;
					}
					if (section.Ymin < ymin) {
						ymin = section.Ymin;
					}
					if (section.Ymax > ymax) {
						ymax = section.Ymax;
					}
					section = null;
				}
			}
			analysis.ZExtents ();
			float num;
			float num2;
			float num4;
			float num3;
			if (analysis.Vertical) {
				num = frm.SG.Width / frm.SG.Height;
				num2 = (1f - analysis.ZoomY) * analysis.Zmin + analysis.ZoomY * analysis.Zmax;
				num3 = num * (analysis.Zmax - analysis.Zmin);
				num4 = (1f - analysis.ZoomX) * (0f - num3) / 2f + analysis.ZoomX * num3 / 2f;
			} else {
				num = frm.SG.Height / frm.SG.Width;
				num2 = (1f - analysis.ZoomX) * analysis.Zmin + analysis.ZoomX * analysis.Zmax;
				num3 = num * (analysis.Zmax - analysis.Zmin);
				num4 = (1f - analysis.ZoomY) * (0f - num3) / 2f + analysis.ZoomY * num3 / 2f;
			}
			float num5 = (analysis.Zmax - analysis.Zmin) / 8f;
			if ((double)(ymax - ymin) > (double)num5 / 1.5) {
				num5 = (float)(1.5 * (double)(ymax - ymin));
			}
			if ((double)(xmax - xmin) > (double)(4f * num5) / 1.5) {
				num5 = (float)(1.5 * (double)(xmax - xmin) / 4.0);
			}
			float num6 = (float)((double)(8f * num5) * 0.525 / (double)analysis.Zoom);
			if (num6 == 0f) {
				num6 = 1f;
				num5 = 0.25f;
			}
			if (analysis.Vertical) {
				frm.SG.Scale (num4 - num * num6, num2 - num6, num4 + num * num6, num2 + num6);
			} else {
				frm.SG.Scale (num2 - num6, num4 + num * num6, num2 + num6, num4 - num * num6);
			}
			float num8 = (pen.Width = Conversions.ToSingle (Interaction.IIf (analysis.Vertical, System.Math.Abs (frm.SG.UnitsPerPixelX), System.Math.Abs (frm.SG.UnitsPerPixelY))));
			if (My.MyProject.Forms.mdiCFS.mnuViewRenderMembers.Checked) {
				SectionLines[] array2 = new SectionLines[101];
				int nBeam2 = analysis.nBeam;
				short num14 = default(short);
				for (int j = 1; j <= nBeam2; j++) {
					if (!(analysis.Beam [j].Z1 > analysis.Beam [j].Z0)) {
						continue;
					}
					int nPart = CFS.Sections [analysis.Beam [j].iSct].nPart;
					for (int k = 1; k <= nPart; k++) {
						Part part = CFS.Sections [analysis.Beam [j].iSct].Part [k];
						float thickness = part.Thickness;
						float num9 = part.XPosition - part.Xcg;
						num3 = part.YPosition - part.Ycg;
						int nElem = part.nElem;
						for (int l = 1; l <= nElem; l++) {
							short num11;
							if ((l > 1) | part.Closed) {
								short num10 = ((l <= 1) ? part.nElem : ((short)(l - 1)));
								num11 = (short)System.Math.Ceiling ((part.Element [l].Rad + thickness / 2f) * System.Math.Abs (part.Element [l].Arc) / num8);
								short num12 = (short)(num11 - 1);
								for (short num13 = 1; num13 <= num12; num13 = (short)unchecked(num13 + 1)) {
									num14 = (short)(num14 + 1);
									if (num14 > Information.UBound (array2)) {
										array2 = (SectionLines[])Utils.CopyArray (array2, new SectionLines[num14 + 100 + 1]);
									}
									float num15 = (float)((double)part.Element [num10].Ang - (double)System.Math.Sign (part.Element [l].Arc) * System.Math.PI / 2.0 + (double)num13 / (double)num11 * (double)part.Element [l].Arc);
									array2 [num14].X = (float)((double)(num9 + part.Element [l].Xac) + (double)(part.Element [l].Rad + thickness / 2f) * System.Math.Cos (num15));
									array2 [num14].Y = (float)((double)(num3 + part.Element [l].Yac) + (double)(part.Element [l].Rad + thickness / 2f) * System.Math.Sin (num15));
									array2 [num14].Color = (byte)System.Math.Round (150.0 + 50.0 * System.Math.Cos (2.0 * ((double)part.Element [num10].Ang + (double)num13 / (double)num11 * (double)part.Element [l].Arc) + System.Math.PI / 6.0) + (double)(20f * (array2 [num14].X - xmin) / (xmax - xmin)));
									array2 [num14].Z0 = Analysis1.Beam [j].Z0;
									array2 [num14].Z1 = Analysis1.Beam [j].Z1;
								}
							}
							num11 = (short)System.Math.Ceiling (System.Math.Abs ((double)(part.Element [l].Y1 - part.Element [l].Y0) - 0.25 * (double)(part.Element [l].X1 - part.Element [l].X0)) / (double)num8);
							short num16 = num11;
							for (short num13 = 0; num13 <= num16; num13 = (short)unchecked(num13 + 1)) {
								if (num11 == 0) {
									num11 = 1;
								}
								num14 = (short)(num14 + 1);
								if (num14 > Information.UBound (array2)) {
									array2 = (SectionLines[])Utils.CopyArray (array2, new SectionLines[num14 + 100 + 1]);
								}
								array2 [num14].X = (float)((double)(num9 + part.Element [l].X0) + (double)num13 / (double)num11 * (double)(part.Element [l].X1 - part.Element [l].X0));
								array2 [num14].Y = (float)((double)(num3 + part.Element [l].Y0) + (double)num13 / (double)num11 * (double)(part.Element [l].Y1 - part.Element [l].Y0));
								array2 [num14].Color = (byte)System.Math.Round (150.0 + 50.0 * System.Math.Cos ((double)(2f * part.Element [l].Ang) + System.Math.PI / 6.0) + (double)(20f * (array2 [num14].X - xmin) / (xmax - xmin)));
								array2 [num14].Z0 = Analysis1.Beam [j].Z0;
								array2 [num14].Z1 = Analysis1.Beam [j].Z1;
							}
						}
						part = null;
					}
				}
				short num17 = (short)(num14 - 1);
				for (short num13 = 1; num13 <= num17; num13 = (short)unchecked(num13 + 1)) {
					if (array2 [num13].X + array2 [num13].Y / 4f > array2 [num13 + 1].X + array2 [num13 + 1].Y / 4f) {
						array2 [0] = array2 [num13];
						array2 [num13] = array2 [num13 + 1];
						array2 [num13 + 1] = array2 [0];
						if (num13 > 1) {
							num13 = (short)(num13 - 2);
						}
					}
				}
				Pen pen2 = new Pen (Color.Gray, num8);
				Graphics graphics = frm.SG.Graphics;
				short num18 = num14;
				for (short num13 = 1; num13 <= num18; num13 = (short)unchecked(num13 + 1)) {
					pen2.Color = Color.FromArgb (array2 [num13].Color, array2 [num13].Color, array2 [num13].Color);
					float num9 = array2 [num13].X / 2f;
					num3 = (float)((double)array2 [num13].Y - 0.25 * (double)array2 [num13].X);
					if (Analysis1.Vertical) {
						graphics.DrawLine (pen2, num3, array2 [num13].Z0 + num9, num3, array2 [num13].Z1 + num9);
					} else {
						graphics.DrawLine (pen2, array2 [num13].Z0 + num9, num3, array2 [num13].Z1 + num9, num3);
					}
				}
				graphics = null;
			}
			array [2] = (float)System.Math.PI / 2f;
			array [1] = 4.712389f;
			array [3] = (float)System.Math.PI;
			array [4] = 0f;
			float num19 = num5 / 12f;
			float num20 = 0f;
			float num21 = num8;
			if (frm.SG.Height % 2f == 1f) {
				num20 = (0f - num21) / 2f;
				num21 = num20 + num21;
			}
			float num22 = num20;
			short nBeam3 = analysis.nBeam;
			float X = default(float);
			float Y = default(float);
			float X2 = default(float);
			float Y2 = default(float);
			for (short num13 = 1; num13 <= nBeam3; num13 = (short)unchecked(num13 + 1)) {
				if (num13 > 1 && analysis.Beam [num13].Z0 < analysis.Beam [num13 - 1].Z1) {
					num22 = num20 + num21 - num22;
				}
				if (analysis.Vertical) {
					frm.SG.Graphics.DrawLine (pen, num22, analysis.Beam [num13].Z0, num22, analysis.Beam [num13].Z1);
				} else {
					frm.SG.Graphics.DrawLine (pen, analysis.Beam [num13].Z0, num22, analysis.Beam [num13].Z1, num22);
				}
				if (analysis.Beam [num13].iBrcFlg > 0) {
					CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] - System.Math.PI / 10.0), analysis.Beam [num13].Z0, ref X, ref Y);
					CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] - System.Math.PI / 10.0), analysis.Beam [num13].Z1, ref X2, ref Y2);
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
					} else {
						frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
					}
					CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] + System.Math.PI / 10.0), analysis.Beam [num13].Z0, ref X, ref Y);
					CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] + System.Math.PI / 10.0), analysis.Beam [num13].Z1, ref X2, ref Y2);
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
					} else {
						frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
					}
					float num23 = analysis.Beam [num13].Z1 - analysis.Beam [num13].Z0;
					short num11 = (short)System.Math.Ceiling (System.Math.Abs (num23 / (3f * num19)));
					if (num11 > 0) {
						num23 /= (float)num11;
					}
					float num24 = analysis.Beam [num13].Z0;
					short num25 = num11;
					for (short num26 = 0; num26 <= num25; num26 = (short)unchecked(num26 + 1)) {
						CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] - System.Math.PI / 10.0), num24, ref X, ref Y);
						CylToPlane (num5 / 3f, (float)((double)array [analysis.Beam [num13].iBrcFlg] + System.Math.PI / 10.0), num24, ref X2, ref Y2);
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
						num24 += num23;
					}
				}
			}
			short nSup = analysis.nSup;
			for (short num13 = 1; num13 <= nSup; num13 = (short)unchecked(num13 + 1)) {
				float num23 = analysis.Sup [num13].Z;
				short num27 = (short)System.Math.Sign ((analysis.Zmin + analysis.Zmax) / 2f - num23);
				if (num27 == 0) {
					num27 = 1;
				}
				if ((analysis.Sup [num13].Type & 1) == 1) {
					CylToPlane (num5 / 4f, (float)System.Math.PI, num23, ref X, ref Y);
					CylToPlane (num5 / 4f, 0f, num23, ref X2, ref Y2);
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
					} else {
						frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
					}
				}
				if ((analysis.Sup [num13].Type & 2) == 2) {
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawLine (pen, num5 / 4f, num23, (0f - num5) / 4f, num23);
					} else {
						frm.SG.Graphics.DrawLine (pen, num23, num5 / 4f, num23, (0f - num5) / 4f);
					}
				}
				if ((analysis.Sup [num13].Type & 4) == 4) {
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawEllipse (pen, num20 - num5 / 8f, num23 - num5 / 8f / 2.2f, num5 / 4f, num5 / 4f / 2.2f);
					} else {
						frm.SG.Graphics.DrawEllipse (pen, num23 - num5 / 8f / 2.2f, num20 - num5 / 8f, num5 / 4f / 2.2f, num5 / 4f);
					}
				}
				if ((analysis.Sup [num13].Type & 8) == 8) {
					short num26 = -3;
					do {
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, (float)num26 * num19, num23, (float)(num26 - 1) * num19, num23 - (float)num27 * num19);
						} else {
							frm.SG.Graphics.DrawLine (pen, num23, (float)num26 * num19, num23 - (float)num27 * num19, (float)(num26 - 1) * num19);
						}
						num26 = (short)unchecked(num26 + 1);
					} while (num26 <= 3);
				}
				if ((analysis.Sup [num13].Type & 0x10) == 16) {
					CylToPlane (num5 / 4f, (float)System.Math.PI, num23, ref X, ref Y);
					CylToPlane (num5 / 4f, 0f, num23, ref X2, ref Y2);
					float num9 = (X2 - X) / 4f;
					num3 = (Y2 - Y) / 4f;
					short num26 = -2;
					do {
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, (float)num26 * num3, num23 + (float)num26 * num9, (float)num26 * num3, num23 + (float)num26 * num9 - (float)num27 * num19 * 1.4142f);
						} else {
							frm.SG.Graphics.DrawLine (pen, num23 + (float)num26 * num9, (float)num26 * num3, num23 + (float)num26 * num9 - (float)num27 * num19 * 1.4142f, (float)num26 * num3);
						}
						num26 = (short)unchecked(num26 + 1);
					} while (num26 <= 2);
				}
				if ((analysis.Sup [num13].Type & 0x20) == 32) {
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawEllipse (pen, num20 - num5 / 16f, num23 - num5 / 16f, num5 / 8f, num5 / 8f);
					} else {
						frm.SG.Graphics.DrawEllipse (pen, num23 - num5 / 16f, num20 - num5 / 16f, num5 / 8f, num5 / 8f);
					}
				}
				if ((analysis.Sup [num13].Type & 0x40) == 64) {
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawEllipse (pen, num20 - num5 / 16f / 2.2f, num23 - num5 / 16f, num5 / 8f / 2.2f, num5 / 8f);
					} else {
						frm.SG.Graphics.DrawEllipse (pen, num23 - num5 / 16f, num20 - num5 / 16f / 2.2f, num5 / 8f, num5 / 8f / 2.2f);
					}
				}
			}
			short nSup2 = analysis.nSup;
			for (short num13 = 1; num13 <= nSup2; num13 = (short)unchecked(num13 + 1)) {
				if ((analysis.Sup [num13].K == 0f) & ((analysis.Sup [num13].Type & 1) == 1)) {
					float num24 = analysis.Sup [num13].Z;
					float num28 = num24;
					short num29 = (short)(num13 + 1);
					short nSup3 = analysis.nSup;
					for (short num26 = num29; num26 <= nSup3; num26 = (short)unchecked(num26 + 1)) {
						if ((analysis.Sup [num26].Type & 1) == 1) {
							num28 = analysis.Sup [num26].Z;
							num13 = num26;
							if (analysis.Sup [num26].K > 0f) {
								break;
							}
						}
					}
					if (num28 > num24) {
						CylToPlane (num5 / 4f, 0f, num24, ref X, ref Y);
						CylToPlane (num5 / 4f, 0f, num28, ref X2, ref Y2);
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
						CylToPlane (num5 / 4f, (float)System.Math.PI, num24, ref X, ref Y);
						CylToPlane (num5 / 4f, (float)System.Math.PI, num28, ref X2, ref Y2);
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
						} else {
							frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
						}
					}
				}
			}
			short nSup4 = analysis.nSup;
			for (short num13 = 1; num13 <= nSup4; num13 = (short)unchecked(num13 + 1)) {
				if ((analysis.Sup [num13].K == 0f) & ((analysis.Sup [num13].Type & 2) == 2)) {
					float num24 = analysis.Sup [num13].Z;
					float num28 = num24;
					short num30 = (short)(num13 + 1);
					short nSup5 = analysis.nSup;
					for (short num26 = num30; num26 <= nSup5; num26 = (short)unchecked(num26 + 1)) {
						if ((analysis.Sup [num26].Type & 2) == 2) {
							num28 = analysis.Sup [num26].Z;
							num13 = num26;
							if (analysis.Sup [num26].K > 0f) {
								break;
							}
						}
					}
					if (num28 > num24) {
						if (analysis.Vertical) {
							frm.SG.Graphics.DrawLine (pen, num5 / 4f, num24, num5 / 4f, num28);
							frm.SG.Graphics.DrawLine (pen, (0f - num5) / 4f, num24, (0f - num5) / 4f, num28);
						} else {
							frm.SG.Graphics.DrawLine (pen, num24, num5 / 4f, num28, num5 / 4f);
							frm.SG.Graphics.DrawLine (pen, num24, (0f - num5) / 4f, num28, (0f - num5) / 4f);
						}
					}
				}
			}
			if (CFS.intAnlTabNow == 3) {
				ref Loading reference = ref analysis.Ldg [analysis.iLdg];
				float num31 = 0f;
				float num32 = 0f;
				float num33 = 0f;
				short nLoad = reference.nLoad;
				for (short num26 = 1; num26 <= nLoad; num26 = (short)unchecked(num26 + 1)) {
					if (reference.Load [num26].Type == 1) {
						if (System.Math.Abs (reference.Load [num26].W0) > num31) {
							num31 = System.Math.Abs (reference.Load [num26].W0);
						}
						if (System.Math.Abs (reference.Load [num26].W1) > num31) {
							num31 = System.Math.Abs (reference.Load [num26].W1);
						}
					} else if (reference.Load [num26].Type == 2) {
						if (System.Math.Abs (reference.Load [num26].W0) > num32) {
							num32 = System.Math.Abs (reference.Load [num26].W0);
						}
					} else if (reference.Load [num26].Type == 3 && System.Math.Abs (reference.Load [num26].W0) > num33) {
						num33 = System.Math.Abs (reference.Load [num26].W0);
					}
				}
				short nLoad2 = reference.nLoad;
				float Y3 = default(float);
				for (short num26 = 1; num26 <= nLoad2; num26 = (short)unchecked(num26 + 1)) {
					if ((reference.Load [num26].W0 != 0f) | (reference.Load [num26].W1 != 0f)) {
						float num24 = reference.Load [num26].Z0;
						float num28 = reference.Load [num26].Z1;
						float w = reference.Load [num26].W0;
						float w2 = reference.Load [num26].W1;
						if (reference.Load [num26].Type == 1) {
							float num23 = num28 - num24;
							short num11 = (short)System.Math.Ceiling (System.Math.Abs ((double)num23 / (2.99 * (double)num19)));
							if (num11 > 0) {
								num23 /= (float)num11;
								num3 = (w2 - w) / (float)num11;
							}
							CylToPlane (num5 * System.Math.Abs (w) / num31 + num21, reference.Load [num26].Ang, num24, ref X, ref Y);
							CylToPlane (num5 * System.Math.Abs (w2) / num31 + num21, reference.Load [num26].Ang, num28, ref X2, ref Y2);
							if (System.Math.Sign (w) == -System.Math.Sign (w2)) {
								float X3 = (0f - (w - (w2 - w) / (num28 - num24) * num24)) / ((w2 - w) / (num28 - num24));
								CylToPlane (num21, reference.Load [num26].Ang, X3, ref X3, ref Y3);
								if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y3, X3);
									frm.SG.Graphics.DrawLine (pen, Y3, X3, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X3, Y3);
									frm.SG.Graphics.DrawLine (pen, X3, Y3, X2, Y2);
								}
							} else if (Analysis1.Vertical) {
								frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
							} else {
								frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
							}
							short num34 = num11;
							for (short num13 = 0; num13 <= num34; num13 = (short)unchecked(num13 + 1)) {
								CylToPlane (num5 * System.Math.Abs (w + (float)num13 * num3) / num31 + num21, reference.Load [num26].Ang, num24, ref X, ref Y);
								CylToPlane (num21, reference.Load [num26].Ang, num24, ref X2, ref Y2);
								if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
								}
								if (num5 * System.Math.Abs (w + (float)num13 * num3) / num31 >= num19) {
									if (w + (float)num13 * num3 >= 0f) {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 1, num5 * System.Math.Abs (w + (float)num13 * num3) / num31 + num21, reference.Load [num26].Ang, num24, num19);
									} else {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 2, num21, reference.Load [num26].Ang, num24, num19);
									}
								}
								num24 += num23;
							}
						} else if (reference.Load [num26].Type == 2) {
							num24 = (num24 + num28) / 2f;
							CylToPlane ((float)(1.25 * (double)num5 * (double)System.Math.Abs (w) / (double)num32 + (double)num21), reference.Load [num26].Ang, num24, ref X, ref Y);
							CylToPlane (num21, reference.Load [num26].Ang, num24, ref X2, ref Y2);
							if (Analysis1.Vertical) {
								frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
							} else {
								frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
							}
							if (1.25 * (double)num5 * (double)System.Math.Abs (w) / (double)num32 >= (double)num19) {
								if (w >= 0f) {
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 1, (float)(1.25 * (double)num5 * (double)System.Math.Abs (w) / (double)num32 + (double)num21), reference.Load [num26].Ang, num24, num19);
								} else {
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 2, num21, reference.Load [num26].Ang, num24, num19);
								}
							}
						} else if (reference.Load [num26].Type == 3) {
							if (Analysis1.Vertical) {
								frm.SG.Graphics.DrawLine (pen, 0f - num19, num24, 0f - (num5 + num19), num24);
								frm.SG.Graphics.DrawLine (pen, 0f - num19, num28, 0f - (num5 + num19), num28);
								frm.SG.Graphics.DrawLine (pen, 0f - num5, num24, 0f - num5, num24 - num5 * System.Math.Abs (w) / num33);
								frm.SG.Graphics.DrawLine (pen, 0f - num5, num28, 0f - num5, num28 + num5 * System.Math.Abs (w) / num33);
							} else {
								frm.SG.Graphics.DrawLine (pen, num24, 0f - num19, num24, 0f - (num5 + num19));
								frm.SG.Graphics.DrawLine (pen, num28, 0f - num19, num28, 0f - (num5 + num19));
								frm.SG.Graphics.DrawLine (pen, num24, 0f - num5, num24 - num5 * System.Math.Abs (w) / num33, 0f - num5);
								frm.SG.Graphics.DrawLine (pen, num28, 0f - num5, num28 + num5 * System.Math.Abs (w) / num33, 0f - num5);
							}
							if (num5 * System.Math.Abs (w) / num33 >= num19) {
								if (w >= 0f) {
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, 0f - num5, (float)System.Math.PI / 2f, num24, num19);
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 3, 0f - num5, (float)System.Math.PI / 2f, num28, num19);
								} else {
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 3, 0f - num5, (float)System.Math.PI / 2f, num24 - num5 * System.Math.Abs (w) / num33, num19);
									PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, 0f - num5, (float)System.Math.PI / 2f, num28 + num5 * System.Math.Abs (w) / num33, num19);
								}
							}
						} else if (reference.Load [num26].Type == 4) {
							CylToPlane (num5 / 4f, reference.Load [num26].Ang, num24, ref X, ref Y);
							short num13 = 1;
							do {
								CylToPlane ((float)((double)(num5 / 4f) * System.Math.Cos (System.Math.PI * (double)num13 / 12.0)), reference.Load [num26].Ang, (float)((double)num24 - (double)(num5 / 4f) * System.Math.Sin (System.Math.PI * (double)num13 / 12.0)), ref X2, ref Y2);
								if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
								}
								X = X2;
								Y = Y2;
								num13 = (short)unchecked(num13 + 1);
							} while (num13 <= 12);
							PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, (float)System.Math.Sign (w) * num5 / 4f, reference.Load [num26].Ang, num24, num19);
						}
					}
				}
			}
			if (analysis.iPt >= 1) {
				pen = new Pen (Color.Blue, num8);
				float num9 = 4f * frm.SG.UnitsPerPixelX;
				num3 = 4f * frm.SG.UnitsPerPixelY;
				if (analysis.Vertical) {
					frm.SG.Graphics.DrawLine (pen, 0f - num3, analysis.ZPt [1] - num9, num3, analysis.ZPt [1] + num9);
					frm.SG.Graphics.DrawLine (pen, num3, analysis.ZPt [1] - num9, 0f - num3, analysis.ZPt [1] + num9);
				} else {
					frm.SG.Graphics.DrawLine (pen, analysis.ZPt [1] - num9, 0f - num3, analysis.ZPt [1] + num9, num3);
					frm.SG.Graphics.DrawLine (pen, analysis.ZPt [1] - num9, num3, analysis.ZPt [1] + num9, 0f - num3);
				}
				if (analysis.iPt >= 2) {
					if (analysis.Vertical) {
						frm.SG.Graphics.DrawLine (pen, 0f - num3, analysis.ZPt [2] - num9, num3, analysis.ZPt [2] + num9);
						frm.SG.Graphics.DrawLine (pen, num3, analysis.ZPt [2] - num9, 0f - num3, analysis.ZPt [2] + num9);
						frm.SG.Graphics.DrawLine (pen, 0f, analysis.ZPt [1], -0.6f * num5, analysis.ZPt [1]);
						frm.SG.Graphics.DrawLine (pen, 0f, analysis.ZPt [2], -0.6f * num5, analysis.ZPt [2]);
						frm.SG.Graphics.DrawLine (pen, (0f - num5) / 2f, analysis.ZPt [1], (0f - num5) / 2f, analysis.ZPt [2]);
						frm.SG.Graphics.DrawLine (pen, (0f - num5) / 2f, analysis.ZPt [1], (0f - num5) / 2f, analysis.ZPt [2]);
						frm.SG.Graphics.DrawLine (pen, (0f - num5) / 2f, analysis.ZPt [2], (0f - num5) / 2f, analysis.ZPt [2]);
					} else {
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [2] - num9, 0f - num3, analysis.ZPt [2] + num9, num3);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [2] - num9, num3, analysis.ZPt [2] + num9, 0f - num3);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [1], 0f, analysis.ZPt [1], -0.6f * num5);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [2], 0f, analysis.ZPt [2], -0.6f * num5);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [1], (0f - num5) / 2f, analysis.ZPt [2], (0f - num5) / 2f);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [1], (0f - num5) / 2f, analysis.ZPt [2], (0f - num5) / 2f);
						frm.SG.Graphics.DrawLine (pen, analysis.ZPt [2], (0f - num5) / 2f, analysis.ZPt [2], (0f - num5) / 2f);
					}
					string text = Units.DisplayLength (System.Math.Abs (analysis.ZPt [2] - analysis.ZPt [1]), 0, blnShowUnit: true, "", 0, 0);
					PointF point;
					if (analysis.Vertical) {
						point = frm.SG.TransformToDevice (new PointF ((0f - num5) / 2f, (analysis.ZPt [1] + analysis.ZPt [2]) / 2f));
						point.X -= frm.SG.Graphics.MeasureString (text, frm.Font).Width;
					} else {
						point = frm.SG.TransformToDevice (new PointF ((analysis.ZPt [1] + analysis.ZPt [2]) / 2f, (0f - num5) / 2f));
						point.X -= frm.SG.Graphics.MeasureString (text, frm.Font).Width / 2f;
					}
					frm.SG.SwapScale ();
					frm.SG.Graphics.DrawString (text, frm.Font, brush, point);
					frm.SG.SwapScale ();
				}
			}
			analysis = null;
			if (My.MyProject.Forms.mdiCFS.mnuViewXYAxes.Checked) {
				frm.SG.SwapScale ();
				pen = new Pen (brush, 1f);
				if (Analysis1.Vertical) {
					float num35 = 14f;
					num20 = frm.SG.Height - 28f;
					num5 = 20f;
					frm.SG.Graphics.DrawLine (pen, num35, num20, num35 - (float)(int)System.Math.Round (0.4 * (double)num5), num20 + (float)(int)System.Math.Round (0.8 * (double)num5));
					frm.SG.Graphics.DrawString ("X", frm.Font, brush, (float)((double)num35 - 0.4 * (double)num5 - 5.0), (float)((double)num20 + 0.8 * (double)num5));
					frm.SG.Graphics.DrawLine (pen, num35, num20, num35 + num5, num20);
					frm.SG.Graphics.DrawString ("Y", frm.Font, brush, num35 + num5, num20 - 6f);
				} else {
					float num35 = 6f;
					num20 = frm.SG.Height - 14f;
					num5 = 20f;
					frm.SG.Graphics.DrawLine (pen, num35, num20, num35 + (float)(int)System.Math.Round (0.8 * (double)num5), num20 + (float)(int)System.Math.Round (0.4 * (double)num5));
					frm.SG.Graphics.DrawString ("X", frm.Font, brush, (float)((double)num35 + 0.8 * (double)num5), (float)((double)num20 + 0.4 * (double)num5 - 6.0));
					frm.SG.Graphics.DrawLine (pen, num35, num20, num35, num20 - num5);
					frm.SG.Graphics.DrawString ("Y", frm.Font, brush, num35 - 5f, num20 - num5 - 12f);
				}
				frm.SG.SwapScale ();
			}
			SelectAnl (frm, Analysis1, 0, 0);
		}
	}

	public static void SelectAnl (frmAnlPicMaster frm, Analysis Analysis1, byte bytSelStart = 0, byte bytSelEnd = 0)
	{
		Pen pen = new Pen (SystemColors.ControlText, 0f);
		Analysis analysis = Analysis1;
		object objectValue = RuntimeHelpers.GetObjectValue (Interaction.IIf (analysis.Vertical, System.Math.Abs (frm.SG.ScaleHeight) / 2f, System.Math.Abs (frm.SG.ScaleWidth) / 2f));
		float num = Conversions.ToSingle (Operators.DivideObject (Operators.DivideObject (Operators.MultiplyObject (analysis.Zoom, objectValue), 8), 0.525));
		float num2 = num / 12f;
		float num4 = (pen.Width = Conversions.ToSingle (Interaction.IIf (analysis.Vertical, System.Math.Abs (frm.SG.UnitsPerPixelX), System.Math.Abs (frm.SG.UnitsPerPixelY))));
		float num5 = 0f;
		float num6 = num4;
		if (frm.SG.Height % 2f == 1f) {
			num5 = (0f - num6) / 2f;
			num6 = num5 + num6;
		}
		short num7 = 1;
		float X = default(float);
		float Y = default(float);
		float X2 = default(float);
		float Y2 = default(float);
		float num13 = default(float);
		float Y3 = default(float);
		do {
			if ((analysis.iAnlTab < 0 || bytSelStart == 0) | (analysis.iAnlTab != CFS.intAnlTabNow)) {
				analysis.iAnlTab = CFS.intAnlTabNow;
				num7 = 2;
			}
			if (num7 == 2) {
				pen = new Pen (Color.Blue, num4);
			}
			checked {
				if (analysis.iAnlTab == 1) {
					if ((analysis.nBeam > 0) & (analysis.BeamGrid.RowStart > 0) & unchecked((uint)analysis.BeamGrid.RowStart <= (uint)analysis.nBeam)) {
						float num8 = num5;
						short nBeam = analysis.nBeam;
						for (short num9 = 1; num9 <= nBeam; num9 = (short)unchecked(num9 + 1)) {
							if (num9 > 1 && analysis.Beam [num9].Z0 < analysis.Beam [num9 - 1].Z1) {
								num8 = num5 + num6 - num8;
							}
							if ((num9 >= analysis.BeamGrid.RowStart) & (num9 <= analysis.BeamGrid.RowEnd)) {
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawLine (pen, num8, analysis.Beam [num9].Z0, num8, analysis.Beam [num9].Z1);
								} else {
									frm.SG.Graphics.DrawLine (pen, analysis.Beam [num9].Z0, num8, analysis.Beam [num9].Z1, num8);
								}
							}
						}
					}
				} else if (analysis.iAnlTab == 2) {
					if ((analysis.nSup > 0) & (analysis.SupGrid.RowStart > 0) & unchecked((uint)analysis.SupGrid.RowStart <= (uint)analysis.nSup)) {
						byte rowStart = analysis.SupGrid.RowStart;
						short rowEnd = analysis.SupGrid.RowEnd;
						short num9 = rowStart;
						while (num9 <= rowEnd && num9 <= analysis.nSup) {
							float z = analysis.Sup [num9].Z;
							short num10 = (short)System.Math.Sign ((analysis.Zmin + analysis.Zmax) / 2f - z);
							if (num10 == 0) {
								num10 = 1;
							}
							if ((analysis.Sup [num9].Type & 1) == 1) {
								CylToPlane (num / 4f, (float)System.Math.PI, z, ref X, ref Y);
								CylToPlane (num / 4f, 0f, z, ref X2, ref Y2);
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
								}
							}
							if ((analysis.Sup [num9].Type & 2) == 2) {
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawLine (pen, num / 4f, z, (0f - num) / 4f, z);
								} else {
									frm.SG.Graphics.DrawLine (pen, z, num / 4f, z, (0f - num) / 4f);
								}
							}
							if ((analysis.Sup [num9].Type & 4) == 4) {
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawEllipse (pen, num5 - num / 8f, z - num / 8f / 2.2f, num / 4f, num / 4f / 2.2f);
								} else {
									frm.SG.Graphics.DrawEllipse (pen, z - num / 8f / 2.2f, num5 - num / 8f, num / 4f / 2.2f, num / 4f);
								}
							}
							if ((analysis.Sup [num9].Type & 8) == 8) {
								short num11 = -3;
								do {
									if (analysis.Vertical) {
										frm.SG.Graphics.DrawLine (pen, (float)num11 * num2, z, (float)(num11 - 1) * num2, z - (float)num10 * num2);
									} else {
										frm.SG.Graphics.DrawLine (pen, z, (float)num11 * num2, z - (float)num10 * num2, (float)(num11 - 1) * num2);
									}
									num11 = (short)unchecked(num11 + 1);
								} while (num11 <= 3);
							}
							if ((analysis.Sup [num9].Type & 0x10) == 16) {
								CylToPlane (num / 4f, (float)System.Math.PI, z, ref X, ref Y);
								CylToPlane (num / 4f, 0f, z, ref X2, ref Y2);
								float num12 = (X2 - X) / 4f;
								num13 = (Y2 - Y) / 4f;
								short num11 = -2;
								do {
									if (analysis.Vertical) {
										frm.SG.Graphics.DrawLine (pen, (float)num11 * num13, z + (float)num11 * num12, (float)num11 * num13, z + (float)num11 * num12 - (float)num10 * num2 * 1.4142f);
									} else {
										frm.SG.Graphics.DrawLine (pen, z + (float)num11 * num12, (float)num11 * num13, z + (float)num11 * num12 - (float)num10 * num2 * 1.4142f, (float)num11 * num13);
									}
									num11 = (short)unchecked(num11 + 1);
								} while (num11 <= 2);
							}
							if ((analysis.Sup [num9].Type & 0x20) == 32) {
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawEllipse (pen, num5 - num / 16f, z - num / 16f, num / 8f, num / 8f);
								} else {
									frm.SG.Graphics.DrawEllipse (pen, z - num / 16f, num5 - num / 16f, num / 8f, num / 8f);
								}
							}
							if ((analysis.Sup [num9].Type & 0x40) == 64) {
								if (analysis.Vertical) {
									frm.SG.Graphics.DrawEllipse (pen, num5 - num / 16f / 2.2f, z - num / 16f, num / 8f / 2.2f, num / 8f);
								} else {
									frm.SG.Graphics.DrawEllipse (pen, z - num / 16f, num5 - num / 16f / 2.2f, num / 8f, num / 8f / 2.2f);
								}
							}
							num9 = (short)unchecked(num9 + 1);
						}
					}
				} else if (analysis.iAnlTab == 3 && CFS.intAnlTabNow == 3 && unchecked(((uint)analysis.iLdg <= (uint)analysis.nLdg) & (analysis.Ldg [analysis.iLdg].nLoad > 0) & (analysis.Ldg [analysis.iLdg].LoadGrid.RowStart > 0) & ((uint)analysis.Ldg [analysis.iLdg].LoadGrid.RowStart <= (uint)analysis.Ldg [analysis.iLdg].nLoad))) {
					ref Loading reference = ref analysis.Ldg [analysis.iLdg];
					float num14 = 0f;
					float num15 = 0f;
					float num16 = 0f;
					short nLoad = reference.nLoad;
					short num11;
					for (num11 = 1; num11 <= nLoad; num11 = (short)unchecked(num11 + 1)) {
						if (reference.Load [num11].Type == 1) {
							if (System.Math.Abs (reference.Load [num11].W0) > num14) {
								num14 = System.Math.Abs (reference.Load [num11].W0);
							}
							if (System.Math.Abs (reference.Load [num11].W1) > num14) {
								num14 = System.Math.Abs (reference.Load [num11].W1);
							}
						} else if (reference.Load [num11].Type == 2) {
							if (System.Math.Abs (reference.Load [num11].W0) > num15) {
								num15 = System.Math.Abs (reference.Load [num11].W0);
							}
						} else if (reference.Load [num11].Type == 3 && System.Math.Abs (reference.Load [num11].W0) > num16) {
							num16 = System.Math.Abs (reference.Load [num11].W0);
						}
					}
					byte rowStart2 = reference.LoadGrid.RowStart;
					short rowEnd2 = reference.LoadGrid.RowEnd;
					num11 = rowStart2;
					while (num11 <= rowEnd2 && num11 <= reference.nLoad) {
						if ((reference.Load [num11].W0 != 0f) | (reference.Load [num11].W1 != 0f)) {
							float num17 = reference.Load [num11].Z0;
							float z2 = reference.Load [num11].Z1;
							float w = reference.Load [num11].W0;
							float w2 = reference.Load [num11].W1;
							if (reference.Load [num11].Type == 1) {
								float z = z2 - num17;
								short num18 = (short)System.Math.Ceiling (System.Math.Abs ((double)z / (2.99 * (double)num2)));
								if (num18 > 0) {
									z /= (float)num18;
									num13 = (w2 - w) / (float)num18;
								}
								CylToPlane (num * System.Math.Abs (w) / num14 + num6, reference.Load [num11].Ang, num17, ref X, ref Y);
								CylToPlane (num * System.Math.Abs (w2) / num14 + num6, reference.Load [num11].Ang, z2, ref X2, ref Y2);
								if (System.Math.Sign (w) == -System.Math.Sign (w2)) {
									float X3 = (0f - (w - (w2 - w) / (z2 - num17) * num17)) / ((w2 - w) / (z2 - num17));
									CylToPlane (num6, reference.Load [num11].Ang, X3, ref X3, ref Y3);
									if (Analysis1.Vertical) {
										frm.SG.Graphics.DrawLine (pen, Y, X, Y3, X3);
										frm.SG.Graphics.DrawLine (pen, Y3, X3, Y2, X2);
									} else {
										frm.SG.Graphics.DrawLine (pen, X, Y, X3, Y3);
										frm.SG.Graphics.DrawLine (pen, X3, Y3, X2, Y2);
									}
								} else if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
								}
								short num19 = num18;
								for (short num9 = 0; num9 <= num19; num9 = (short)unchecked(num9 + 1)) {
									CylToPlane (num * System.Math.Abs (w + (float)num9 * num13) / num14 + num6, reference.Load [num11].Ang, num17, ref X, ref Y);
									CylToPlane (num6, reference.Load [num11].Ang, num17, ref X2, ref Y2);
									if (Analysis1.Vertical) {
										frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
									} else {
										frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
									}
									if (num * System.Math.Abs (w + (float)num9 * num13) / num14 >= num2) {
										if (w + (float)num9 * num13 >= 0f) {
											PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 1, num * System.Math.Abs (w + (float)num9 * num13) / num14 + num6, reference.Load [num11].Ang, num17, num2);
										} else {
											PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 2, num6, reference.Load [num11].Ang, num17, num2);
										}
									}
									num17 += z;
								}
							} else if (reference.Load [num11].Type == 2) {
								num17 = (num17 + z2) / 2f;
								CylToPlane ((float)(1.25 * (double)num * (double)System.Math.Abs (w) / (double)num15 + (double)num6), reference.Load [num11].Ang, num17, ref X, ref Y);
								CylToPlane (num6, reference.Load [num11].Ang, num17, ref X2, ref Y2);
								if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
								} else {
									frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
								}
								if (1.25 * (double)num * (double)System.Math.Abs (w) / (double)num15 >= (double)num2) {
									if (w >= 0f) {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 1, (float)(1.25 * (double)num * (double)System.Math.Abs (w) / (double)num15 + (double)num6), reference.Load [num11].Ang, num17, num2);
									} else {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 2, num6, reference.Load [num11].Ang, num17, num2);
									}
								}
							} else if (reference.Load [num11].Type == 3) {
								if (Analysis1.Vertical) {
									frm.SG.Graphics.DrawLine (pen, 0f - num2, num17, 0f - (num + num2), num17);
									frm.SG.Graphics.DrawLine (pen, 0f - num2, z2, 0f - (num + num2), z2);
									frm.SG.Graphics.DrawLine (pen, 0f - num, num17, 0f - num, num17 - num * System.Math.Abs (w) / num16);
									frm.SG.Graphics.DrawLine (pen, 0f - num, z2, 0f - num, z2 + num * System.Math.Abs (w) / num16);
								} else {
									frm.SG.Graphics.DrawLine (pen, num17, 0f - num2, num17, 0f - (num + num2));
									frm.SG.Graphics.DrawLine (pen, z2, 0f - num2, z2, 0f - (num + num2));
									frm.SG.Graphics.DrawLine (pen, num17, 0f - num, num17 - num * System.Math.Abs (w) / num16, 0f - num);
									frm.SG.Graphics.DrawLine (pen, z2, 0f - num, z2 + num * System.Math.Abs (w) / num16, 0f - num);
								}
								if (num * System.Math.Abs (w) / num16 >= num2) {
									if (w >= 0f) {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, 0f - num, (float)System.Math.PI / 2f, num17, num2);
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 3, 0f - num, (float)System.Math.PI / 2f, z2, num2);
									} else {
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 3, 0f - num, (float)System.Math.PI / 2f, num17 - num * System.Math.Abs (w) / num16, num2);
										PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, 0f - num, (float)System.Math.PI / 2f, z2 + num * System.Math.Abs (w) / num16, num2);
									}
								}
							} else if (reference.Load [num11].Type == 4) {
								CylToPlane (num / 4f, reference.Load [num11].Ang, num17, ref X, ref Y);
								short num9 = 1;
								do {
									CylToPlane ((float)((double)(num / 4f) * System.Math.Cos (System.Math.PI * (double)num9 / 12.0)), reference.Load [num11].Ang, (float)((double)num17 - (double)(num / 4f) * System.Math.Sin (System.Math.PI * (double)num9 / 12.0)), ref X2, ref Y2);
									if (Analysis1.Vertical) {
										frm.SG.Graphics.DrawLine (pen, Y, X, Y2, X2);
									} else {
										frm.SG.Graphics.DrawLine (pen, X, Y, X2, Y2);
									}
									X = X2;
									Y = Y2;
									num9 = (short)unchecked(num9 + 1);
								} while (num9 <= 12);
								PlotArrow (frm.SG.Graphics, Analysis1.Vertical, pen, 4, (float)System.Math.Sign (w) * num / 4f, reference.Load [num11].Ang, num17, num2);
							}
						}
						num11 = (short)unchecked(num11 + 1);
					}
				}
				if (num7 == 2) {
					break;
				}
				analysis.iAnlTab = CFS.intAnlTabNow;
				if (bytSelEnd == 0) {
					bytSelEnd = bytSelStart;
				}
				if (bytSelStart < 1) {
					bytSelStart = 1;
				}
				if (bytSelEnd < 1) {
					bytSelEnd = 1;
				}
				switch (analysis.iAnlTab) {
				case 1:
					if (bytSelStart > unchecked((int)analysis.nBeam) + 1) {
						bytSelStart = (byte)(unchecked((int)analysis.nBeam) + 1);
					}
					if (bytSelEnd > unchecked((int)analysis.nBeam) + 1) {
						bytSelEnd = (byte)(unchecked((int)analysis.nBeam) + 1);
					}
					if (unchecked((uint)bytSelEnd < (uint)bytSelStart)) {
						CFS.Swap (ref bytSelStart, ref bytSelEnd);
					}
					analysis.BeamGrid.RowStart = bytSelStart;
					analysis.BeamGrid.RowEnd = bytSelEnd;
					SetMenuEdit ();
					break;
				case 2:
					if (bytSelStart > unchecked((int)analysis.nSup) + 1) {
						bytSelStart = (byte)(unchecked((int)analysis.nSup) + 1);
					}
					if (bytSelEnd > unchecked((int)analysis.nSup) + 1) {
						bytSelEnd = (byte)(unchecked((int)analysis.nSup) + 1);
					}
					if (unchecked((uint)bytSelEnd < (uint)bytSelStart)) {
						CFS.Swap (ref bytSelStart, ref bytSelEnd);
					}
					analysis.SupGrid.RowStart = bytSelStart;
					analysis.SupGrid.RowEnd = bytSelEnd;
					SetMenuEdit ();
					break;
				case 3:
					if (bytSelStart > unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1) {
						bytSelStart = (byte)(unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1);
					}
					if (bytSelEnd > unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1) {
						bytSelEnd = (byte)(unchecked((int)analysis.Ldg [analysis.iLdg].nLoad) + 1);
					}
					if (unchecked((uint)bytSelEnd < (uint)bytSelStart)) {
						CFS.Swap (ref bytSelStart, ref bytSelEnd);
					}
					analysis.Ldg [analysis.iLdg].LoadGrid.RowStart = bytSelStart;
					analysis.Ldg [analysis.iLdg].LoadGrid.RowEnd = bytSelEnd;
					SetMenuEdit ();
					break;
				}
				num7 = (short)unchecked(num7 + 1);
			}
		} while (num7 <= 2);
		analysis = null;
		frm.SG.PreserveImage ();
	}

	public static void PlotArrow (Graphics g, bool blnVertical, Pen p, byte iDir, float R, float A, float Z, float D)
	{
		float X = default(float);
		float Y = default(float);
		CylToPlane (R, A, Z, ref X, ref Y);
		float X2 = default(float);
		float Y2 = default(float);
		float X3 = default(float);
		float Y3 = default(float);
		switch (iDir) {
		case 1:
			CylToPlane (R - D, A, Z - D, ref X2, ref Y2);
			CylToPlane (R - D, A, Z + D, ref X3, ref Y3);
			break;
		case 2:
			CylToPlane (R + D, A, Z - D, ref X2, ref Y2);
			CylToPlane (R + D, A, Z + D, ref X3, ref Y3);
			break;
		case 3:
			CylToPlane (R + D, A, Z + D, ref X2, ref Y2);
			CylToPlane (R - D, A, Z + D, ref X3, ref Y3);
			break;
		case 4:
			CylToPlane (R + D, A, Z - D, ref X2, ref Y2);
			CylToPlane (R - D, A, Z - D, ref X3, ref Y3);
			break;
		}
		if (blnVertical) {
			g.DrawLine (p, Y, X, Y2, X2);
			g.DrawLine (p, Y, X, Y3, X3);
		} else {
			g.DrawLine (p, X, Y, X2, Y2);
			g.DrawLine (p, X, Y, X3, Y3);
		}
	}

	public static void CylToPlane (float R, float A, float Z, ref float X, ref float Y)
	{
		X = (float)((double)Z + 0.5 * (double)R * System.Math.Cos (A));
		Y = (float)((double)R * (System.Math.Sin (A) - 0.25 * System.Math.Cos (A)));
	}

	public static bool AddBeam (Analysis Analysis1)
	{
		bool result = false;
		Analysis analysis = Analysis1;
		checked {
			if (analysis.nBeam >= 254) {
				Interaction.MsgBox ("Limit " + Conversions.ToString (254) + " members.", MsgBoxStyle.Information);
			} else {
				analysis.nBeam++;
				if (analysis.nBeam > Information.UBound (analysis.Beam)) {
					ref Beam[] beam = ref analysis.Beam;
					beam = (Beam[])Utils.CopyArray (beam, new Beam[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)analysis.nBeam) / 10.0) * 10.0) + 1]);
				}
				analysis.Beam [analysis.nBeam] = new Beam (0);
				if (analysis.nBeam <= 1) {
					analysis.Beam [analysis.nBeam].Z0 = analysis.Zmin;
					analysis.Beam [analysis.nBeam].Z1 = analysis.Zmin;
				} else {
					analysis.Beam [analysis.nBeam].Z0 = analysis.Beam [unchecked((int)analysis.nBeam) - 1].Z1;
					analysis.Beam [analysis.nBeam].Z1 = analysis.Beam [unchecked((int)analysis.nBeam) - 1].Z1;
				}
				analysis.Beam [analysis.nBeam].iBrcFlg = 0;
				analysis.Beam [analysis.nBeam].R = 0f;
				analysis.Beam [analysis.nBeam].Kf = 0f;
				analysis.Beam [analysis.nBeam].Lm = 240f;
				analysis.Beam [analysis.nBeam].ex = 0f;
				analysis.Beam [analysis.nBeam].ey = 0f;
				analysis = null;
				CFS.blnRefreshGrdBeams = true;
				result = true;
			}
			return result;
		}
	}

	public static bool AddLF (ref LoadCombination Comb1)
	{
		bool result = false;
		checked {
			if (Comb1.nLF >= 254) {
				Interaction.MsgBox ("Limit " + Conversions.ToString (254) + " load factors.", MsgBoxStyle.Information);
			} else {
				Comb1.nLF++;
				if (Comb1.nLF > Information.UBound (Comb1.LF)) {
					ref LoadFactor[] lF = ref Comb1.LF;
					lF = (LoadFactor[])Utils.CopyArray (lF, new LoadFactor[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)Comb1.nLF) / 10.0) * 10.0) + 1]);
				}
				Comb1.LF [Comb1.nLF].fLdg = 1f;
				CFS.blnRefreshGrdCombs = true;
				result = true;
			}
			return result;
		}
	}

	public static bool AddLoad (Analysis Analysis1, ref Loading Ldg)
	{
		bool result = false;
		checked {
			if (Ldg.nLoad >= 254) {
				Interaction.MsgBox ("Limit " + Conversions.ToString (254) + " loads.", MsgBoxStyle.Information);
			} else {
				Ldg.nLoad++;
				if (Ldg.nLoad > Information.UBound (Ldg.Load)) {
					ref Load[] load = ref Ldg.Load;
					load = (Load[])Utils.CopyArray (load, new Load[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)Ldg.nLoad) / 10.0) * 10.0) + 1]);
				}
				Ldg.Load [Ldg.nLoad].Type = 0;
				Ldg.Load [Ldg.nLoad].Ang = (float)System.Math.PI / 2f;
				Ldg.Load [Ldg.nLoad].Z0 = Analysis1.Zmin;
				Ldg.Load [Ldg.nLoad].Z1 = Analysis1.Zmin;
				Ldg.Load [Ldg.nLoad].W0 = 0f;
				Ldg.Load [Ldg.nLoad].W1 = 0f;
				Ldg.Load [Ldg.nLoad].Wid = 1f;
				CFS.blnRefreshGrdLoads = true;
				result = true;
			}
			return result;
		}
	}

	public static bool AddSup (Analysis Analysis1)
	{
		bool result = false;
		Analysis analysis = Analysis1;
		checked {
			if (analysis.nSup >= 254) {
				Interaction.MsgBox ("Limit " + Conversions.ToString (254) + " supports.", MsgBoxStyle.Information);
			} else {
				analysis.nSup++;
				if (analysis.nSup > Information.UBound (analysis.Sup)) {
					ref Support[] sup = ref analysis.Sup;
					sup = (Support[])Utils.CopyArray (sup, new Support[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)analysis.nSup) / 10.0) * 10.0) + 1]);
				}
				if (analysis.nSup <= 1) {
					analysis.Sup [analysis.nSup].Z = analysis.Zmin;
				} else {
					analysis.Sup [analysis.nSup].Z = analysis.Sup [unchecked((int)analysis.nSup) - 1].Z;
				}
				analysis.Sup [analysis.nSup].K = 1f;
				analysis.Sup [analysis.nSup].Wid = 1f;
				if ((analysis.Sup [analysis.nSup].Type & 2) == 2) {
					analysis.Sup [analysis.nSup].Fastened = WebCripParametersNow.Fastened;
				} else {
					analysis.Sup [analysis.nSup].Fastened = false;
				}
				analysis = null;
				CFS.blnRefreshGrdSupports = true;
				result = true;
			}
			return result;
		}
	}

	public static void CopyBeams (Analysis Analysis1, byte bytBeamStart = 0, byte bytBeamEnd = 0)
	{
		Analysis analysis = Analysis1;
		if (analysis.nBeam <= 0 || (((uint)bytBeamStart > (uint)analysis.nBeam) & ((uint)bytBeamEnd > (uint)analysis.nBeam))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		if (bytBeamStart == 0) {
			bytBeamStart = 1;
			if (bytBeamEnd == 0) {
				bytBeamEnd = analysis.nBeam;
			}
		} else if (bytBeamEnd == 0) {
			bytBeamEnd = bytBeamStart;
		}
		if ((uint)bytBeamEnd < (uint)bytBeamStart) {
			CFS.Swap (ref bytBeamStart, ref bytBeamEnd);
		}
		if (bytBeamStart < 1) {
			bytBeamStart = 1;
		}
		if ((uint)bytBeamEnd > (uint)analysis.nBeam) {
			bytBeamEnd = analysis.nBeam;
		}
		checked {
			short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytBeamEnd - bytBeamStart)))) + 1);
			string text = string.Empty;
			bytClipBoard = 5;
			My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Members";
			My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			cbBeam = new Beam[num + 1];
			short num2 = num;
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				cbBeam [num3] = analysis.Beam [(short)unchecked(bytBeamStart + num3) - 1];
			}
			byte num4 = bytBeamStart;
			short num5 = bytBeamEnd;
			for (short num3 = num4; num3 <= num5; num3 = (short)unchecked(num3 + 1)) {
				ref Beam reference = ref analysis.Beam [num3];
				text = text + GetFileName (CFS.Sections [reference.iSct].Filename) + "\t" + Conversions.ToString (reference.Z0 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.Z1 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + DisplayFlange (unchecked((Flanges)reference.iBrcFlg)) + "\t" + Conversions.ToString (reference.R) + "\t" + Conversions.ToString (reference.Kf * Units.untForce [Units.DefaultUnitIndex [4]].Mult) + "\t" + Conversions.ToString (reference.Lm * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.ex * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\t" + Conversions.ToString (reference.ey * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\r\n";
			}
			strClipBoard = text;
			Clipboard.Clear ();
			Clipboard.SetText (strClipBoard);
			SetMenuEdit ();
			analysis = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void CopyLFs (Analysis Analysis1, byte bytComb, byte bytLFStart = 0, byte bytLFEnd = 0)
	{
		ref LoadCombination reference = ref Analysis1.Comb [bytComb];
		if (reference.nLF <= 0 || (((uint)bytLFStart > (uint)reference.nLF) & ((uint)bytLFEnd > (uint)reference.nLF))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytLFStart == 0) {
				bytLFStart = 1;
				if (bytLFEnd == 0) {
					bytLFEnd = (byte)(unchecked((int)reference.nLF) + 1);
				}
			} else if (bytLFEnd == 0) {
				bytLFEnd = bytLFStart;
			}
			if (unchecked((uint)bytLFEnd < (uint)bytLFStart)) {
				CFS.Swap (ref bytLFStart, ref bytLFEnd);
			}
			string text = string.Empty;
			if ((bytLFStart == 1) & (bytLFEnd == unchecked((int)reference.nLF) + 1)) {
				bytClipBoard = 10;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Combination";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbComb = Analysis1.Comb [bytComb];
				text = "CFS Combination\t" + reference.Description + "\r\n";
				if (unchecked((uint)bytLFEnd > (uint)reference.nLF)) {
					bytLFEnd = reference.nLF;
				}
			} else {
				if (bytLFStart < 1) {
					bytLFStart = 1;
				}
				if (unchecked((uint)bytLFEnd > (uint)reference.nLF)) {
					bytLFEnd = reference.nLF;
				}
				short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLFEnd - bytLFStart)))) + 1);
				bytClipBoard = 9;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Load Factors";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbLF = new LoadFactor[num + 1];
				short num2 = num;
				for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
					cbLF [num3] = reference.LF [(short)unchecked(bytLFStart + num3) - 1];
				}
			}
			Analysis analysis = Analysis1;
			byte num4 = bytLFStart;
			short num5 = bytLFEnd;
			for (short num3 = num4; num3 <= num5; num3 = (short)unchecked(num3 + 1)) {
				text = text + analysis.Ldg [analysis.Comb [analysis.iComb].LF [num3].iLdg].Description + "\t" + Conversions.ToString (analysis.Comb [analysis.iComb].LF [num3].fLdg) + "\r\n";
			}
			analysis = null;
			strClipBoard = text;
			Clipboard.Clear ();
			Clipboard.SetText (strClipBoard);
			SetMenuEdit ();
			Cursor.Current = Cursors.Default;
		}
	}

	public static void CopyLoads (ref Loading Loading1, byte bytLoadStart = 0, byte bytLoadEnd = 0)
	{
		if (Loading1.nLoad <= 0 || (((uint)bytLoadStart > (uint)Loading1.nLoad) & ((uint)bytLoadEnd > (uint)Loading1.nLoad))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytLoadStart == 0) {
				bytLoadStart = 1;
				if (bytLoadEnd == 0) {
					bytLoadEnd = (byte)(unchecked((int)Loading1.nLoad) + 1);
				}
			} else if (bytLoadEnd == 0) {
				bytLoadEnd = bytLoadStart;
			}
			if (unchecked((uint)bytLoadEnd < (uint)bytLoadStart)) {
				CFS.Swap (ref bytLoadStart, ref bytLoadEnd);
			}
			string text = string.Empty;
			if ((bytLoadStart == 1) & (bytLoadEnd == unchecked((int)Loading1.nLoad) + 1)) {
				bytClipBoard = 8;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Loading";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbLdg = Loading1;
				text = "CFS Loading\t" + Loading1.Description + "\r\n";
				if (unchecked((uint)bytLoadEnd > (uint)Loading1.nLoad)) {
					bytLoadEnd = Loading1.nLoad;
				}
			} else {
				if (bytLoadStart < 1) {
					bytLoadStart = 1;
				}
				if (unchecked((uint)bytLoadEnd > (uint)Loading1.nLoad)) {
					bytLoadEnd = Loading1.nLoad;
				}
				short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLoadEnd - bytLoadStart)))) + 1);
				bytClipBoard = 7;
				My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Loads";
				My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
				cbLoad = new Load[num + 1];
				short num2 = num;
				for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
					cbLoad [num3] = Loading1.Load [(short)unchecked(bytLoadStart + num3) - 1];
				}
			}
			byte num4 = bytLoadStart;
			short num5 = bytLoadEnd;
			for (short num3 = num4; num3 <= num5; num3 = (short)unchecked(num3 + 1)) {
				ref Load reference = ref Loading1.Load [num3];
				text = text + DisplayLoadType (unchecked((LoadTypes)reference.Type)) + "\t" + Conversions.ToString (reference.Ang * Units.untAngle [Units.DefaultUnitIndex [3]].Mult) + "\t";
				if (reference.Type == 1) {
					text = text + Conversions.ToString (reference.Z0 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.Z1 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.W0 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult) + "\t" + Conversions.ToString (reference.W1 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult) + "\t" + Units.untLoad [Units.DefaultUnitIndex [11]].Name + "\tNA\r\n";
				} else if (reference.Type == 2) {
					text = text + Conversions.ToString (reference.Z0 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\tNA\t" + Conversions.ToString (reference.W0 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult) + "\tNA\t" + Units.untLoad [Units.DefaultUnitIndex [11]].Name + "\t" + Conversions.ToString (reference.Wid * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\r\n";
				} else if (reference.Type == 3) {
					text = text + Conversions.ToString (reference.Z0 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.Z1 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.W0 * Units.untForce [Units.DefaultUnitIndex [4]].Mult) + "\t" + Conversions.ToString (reference.W1 * Units.untForce [Units.DefaultUnitIndex [4]].Mult) + "\t" + Units.untForce [Units.DefaultUnitIndex [4]].Name + "\tNA\r\n";
				} else if (reference.Type == 4) {
					text = text + Conversions.ToString (reference.Z0 * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\tNA\t" + Conversions.ToString (reference.W0 * Units.untLoad [Units.DefaultUnitIndex [11]].Mult) + "\tNA\t" + Units.untMoment [Units.DefaultUnitIndex [6]].Name + "\tNA\r\n";
				}
			}
			strClipBoard = text;
			Clipboard.Clear ();
			Clipboard.SetText (strClipBoard);
			SetMenuEdit ();
			Cursor.Current = Cursors.Default;
		}
	}

	public static void CopySupports (Analysis Analysis1, byte bytSupStart = 0, byte bytSupEnd = 0)
	{
		Analysis analysis = Analysis1;
		if (analysis.nSup <= 0 || (((uint)bytSupStart > (uint)analysis.nSup) & ((uint)bytSupEnd > (uint)analysis.nSup))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		if (bytSupStart == 0) {
			bytSupStart = 1;
			if (bytSupEnd == 0) {
				bytSupEnd = analysis.nSup;
			}
		} else if (bytSupEnd == 0) {
			bytSupEnd = bytSupStart;
		}
		if ((uint)bytSupEnd < (uint)bytSupStart) {
			CFS.Swap (ref bytSupStart, ref bytSupEnd);
		}
		if (bytSupStart < 1) {
			bytSupStart = 1;
		}
		if ((uint)bytSupEnd > (uint)analysis.nSup) {
			bytSupEnd = analysis.nSup;
		}
		checked {
			short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytSupEnd - bytSupStart)))) + 1);
			string text = string.Empty;
			bytClipBoard = 6;
			My.MyProject.Forms.mdiCFS.mnuEditPaste.Text = "&Paste Supports";
			My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			My.MyProject.Forms.mdiCFS.tbrPaste.Text = My.MyProject.Forms.mdiCFS.mnuEditPaste.Text;
			cbSupport = new Support[num + 1];
			short num2 = num;
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				cbSupport [num3] = analysis.Sup [(short)unchecked(bytSupStart + num3) - 1];
			}
			byte num4 = bytSupStart;
			short num5 = bytSupEnd;
			for (short num3 = num4; num3 <= num5; num3 = (short)unchecked(num3 + 1)) {
				ref Support reference = ref analysis.Sup [num3];
				text = text + DisplaySup (unchecked((Supports)reference.Type)) + "\t" + Conversions.ToString (reference.Z * Units.untLength [Units.DefaultUnitIndex [2]].Mult) + "\t" + Conversions.ToString (reference.Wid * Units.untLength [Units.DefaultUnitIndex [1]].Mult) + "\t" + Conversions.ToString (reference.K) + "\r\n";
			}
			strClipBoard = text;
			Clipboard.Clear ();
			Clipboard.SetText (strClipBoard);
			SetMenuEdit ();
			analysis = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void DeleteBeams (Analysis Analysis1, byte bytBeamStart = 0, byte bytBeamEnd = 0)
	{
		Analysis analysis = Analysis1;
		if (analysis.nBeam <= 0 || (((uint)bytBeamStart > (uint)analysis.nBeam) & ((uint)bytBeamEnd > (uint)analysis.nBeam))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		StoreUndoAnl ("Delete Members");
		if (bytBeamStart == 0) {
			bytBeamStart = 1;
			if (bytBeamEnd == 0) {
				bytBeamEnd = analysis.nBeam;
			}
		} else if (bytBeamEnd == 0) {
			bytBeamEnd = bytBeamStart;
		}
		if ((uint)bytBeamEnd < (uint)bytBeamStart) {
			CFS.Swap (ref bytBeamStart, ref bytBeamEnd);
		}
		if (bytBeamStart < 1) {
			bytBeamStart = 1;
		}
		if ((uint)bytBeamEnd > (uint)analysis.nBeam) {
			bytBeamEnd = analysis.nBeam;
		}
		checked {
			short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytBeamEnd - bytBeamStart)))) + 1);
			short num2 = (short)(unchecked((int)bytBeamEnd) + 1);
			short nBeam = analysis.nBeam;
			for (short num3 = num2; num3 <= nBeam; num3 = (short)unchecked(num3 + 1)) {
				analysis.Beam [(short)unchecked(num3 - num)] = analysis.Beam [num3];
			}
			analysis.nBeam = (byte)(short)unchecked(analysis.nBeam - num);
			analysis.BeamGrid.RowStart = bytBeamStart;
			analysis.BeamGrid.RowEnd = bytBeamStart;
			analysis = null;
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdBeams = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void DeleteLFs (Analysis Analysis1, byte bytComb, byte bytLFStart = 0, byte bytLFEnd = 0)
	{
		ref LoadCombination reference = ref Analysis1.Comb [bytComb];
		if (reference.nLF <= 0 || (((uint)bytLFStart > (uint)reference.nLF) & ((uint)bytLFEnd > (uint)reference.nLF))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytLFStart == 0) {
				bytLFStart = 1;
				if (bytLFEnd == 0) {
					bytLFEnd = (byte)(unchecked((int)reference.nLF) + 1);
				}
			} else if (bytLFEnd == 0) {
				bytLFEnd = bytLFStart;
			}
			if (unchecked((uint)bytLFEnd < (uint)bytLFStart)) {
				CFS.Swap (ref bytLFStart, ref bytLFEnd);
			}
			if ((bytLFStart == 1) & (bytLFEnd == unchecked((int)reference.nLF) + 1)) {
				StoreUndoAnl ("Delete Combination");
				short num = (short)(unchecked((int)bytComb) + 1);
				short nComb = Analysis1.nComb;
				short num2;
				for (num2 = num; num2 <= nComb; num2 = (short)unchecked(num2 + 1)) {
					Analysis1.Comb [num2 - 1] = Analysis1.Comb [num2];
				}
				Analysis1.Comb [num2 - 1] = new LoadCombination (string.Empty, 10);
				if (Analysis1.nComb > 0) {
					Analysis1.nComb--;
				}
				if (bytComb > 1) {
					Analysis1.iComb--;
				}
				if (Analysis1.nComb == 0) {
					Analysis1.Comb [Analysis1.iComb].Description = "Combination 1";
				}
			} else {
				StoreUndoAnl ("Delete Load Factors");
				if (bytLFStart < 1) {
					bytLFStart = 1;
				}
				if (unchecked((uint)bytLFEnd > (uint)reference.nLF)) {
					bytLFEnd = reference.nLF;
				}
				short num3 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLFEnd - bytLFStart)))) + 1);
				short num4 = (short)(unchecked((int)bytLFEnd) + 1);
				short nLF = reference.nLF;
				for (short num5 = num4; num5 <= nLF; num5 = (short)unchecked(num5 + 1)) {
					reference.LF [(short)unchecked(num5 - num3)] = reference.LF [num5];
				}
				reference.nLF = (byte)(short)unchecked(reference.nLF - num3);
				reference.LFGrid.RowStart = bytLFStart;
				reference.LFGrid.RowEnd = bytLFStart;
			}
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdCombs = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void DeleteLoads (Analysis Analysis1, byte bytLdg, byte bytLoadStart = 0, byte bytLoadEnd = 0)
	{
		ref Loading reference = ref Analysis1.Ldg [bytLdg];
		if (reference.nLoad <= 0 || (((uint)bytLoadStart > (uint)reference.nLoad) & ((uint)bytLoadEnd > (uint)reference.nLoad))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytLoadStart == 0) {
				bytLoadStart = 1;
				if (bytLoadEnd == 0) {
					bytLoadEnd = (byte)(unchecked((int)reference.nLoad) + 1);
				}
			} else if (bytLoadEnd == 0) {
				bytLoadEnd = bytLoadStart;
			}
			if (unchecked((uint)bytLoadEnd < (uint)bytLoadStart)) {
				CFS.Swap (ref bytLoadStart, ref bytLoadEnd);
			}
			if ((bytLoadStart == 1) & (bytLoadEnd == unchecked((int)reference.nLoad) + 1)) {
				StoreUndoAnl ("Delete Loading");
				if (RemoveLdg (Analysis1, bytLdg)) {
					CFS.blnRefreshGrdCombs = true;
				}
			} else {
				StoreUndoAnl ("Delete Loads");
				if (bytLoadStart < 1) {
					bytLoadStart = 1;
				}
				if (unchecked((uint)bytLoadEnd > (uint)reference.nLoad)) {
					bytLoadEnd = reference.nLoad;
				}
				short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLoadEnd - bytLoadStart)))) + 1);
				short num2 = (short)(unchecked((int)bytLoadEnd) + 1);
				short nLoad = reference.nLoad;
				for (short num3 = num2; num3 <= nLoad; num3 = (short)unchecked(num3 + 1)) {
					reference.Load [(short)unchecked(num3 - num)] = reference.Load [num3];
				}
				reference.nLoad = (byte)(short)unchecked(reference.nLoad - num);
				reference.LoadGrid.RowStart = bytLoadStart;
				reference.LoadGrid.RowEnd = bytLoadStart;
			}
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdLoads = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void DeleteSupports (Analysis Analysis1, byte bytSupStart = 0, byte bytSupEnd = 0)
	{
		Analysis analysis = Analysis1;
		if (analysis.nSup <= 0 || (((uint)bytSupStart > (uint)analysis.nSup) & ((uint)bytSupEnd > (uint)analysis.nSup))) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		StoreUndoAnl ("Delete Supports");
		if (bytSupStart == 0) {
			bytSupStart = 1;
			if (bytSupEnd == 0) {
				bytSupEnd = analysis.nSup;
			}
		} else if (bytSupEnd == 0) {
			bytSupEnd = bytSupStart;
		}
		if ((uint)bytSupEnd < (uint)bytSupStart) {
			CFS.Swap (ref bytSupStart, ref bytSupEnd);
		}
		if (bytSupStart < 1) {
			bytSupStart = 1;
		}
		if ((uint)bytSupEnd > (uint)analysis.nSup) {
			bytSupEnd = analysis.nSup;
		}
		checked {
			short num = (short)(unchecked((int)checked((byte)unchecked((uint)(bytSupEnd - bytSupStart)))) + 1);
			short num2 = (short)(unchecked((int)bytSupEnd) + 1);
			short nSup = analysis.nSup;
			for (short num3 = num2; num3 <= nSup; num3 = (short)unchecked(num3 + 1)) {
				analysis.Sup [(short)unchecked(num3 - num)] = analysis.Sup [num3];
			}
			analysis.nSup = (byte)(short)unchecked(analysis.nSup - num);
			analysis.SupGrid.RowStart = bytSupStart;
			analysis.SupGrid.RowEnd = bytSupStart;
			analysis = null;
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdSupports = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void PasteBeams (Analysis Analysis1, byte bytBeamStart = 0, byte bytBeamEnd = 0)
	{
		if (bytClipBoard != 5 || Strings.StrComp (strClipBoard, Clipboard.GetText ()) != 0) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		Analysis analysis = Analysis1;
		checked {
			if (bytBeamStart == 0) {
				bytBeamStart = (byte)(unchecked((int)analysis.nBeam) + 1);
			}
			if (bytBeamEnd == 0) {
				bytBeamEnd = (byte)(unchecked((int)analysis.nBeam) + 1);
			}
			if (unchecked((uint)bytBeamEnd < (uint)bytBeamStart)) {
				CFS.Swap (ref bytBeamStart, ref bytBeamEnd);
			}
			if (bytBeamStart < 1) {
				bytBeamStart = 1;
			}
			if (bytBeamEnd > unchecked((int)analysis.nBeam) + 1) {
				bytBeamEnd = (byte)(unchecked((int)analysis.nBeam) + 1);
			}
			short num = (short)Information.UBound (cbBeam);
			short num2;
			if (bytBeamEnd == bytBeamStart) {
				num2 = 0;
			} else {
				if (unchecked((uint)bytBeamEnd > (uint)analysis.nBeam)) {
					bytBeamEnd = analysis.nBeam;
				}
				num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytBeamEnd - bytBeamStart)))) + 1);
			}
			short num3 = (short)unchecked(checked((short)unchecked(analysis.nBeam + num)) - num2);
			if (num3 > 254) {
				Cursor.Current = Cursors.Default;
				Interaction.MsgBox ("Too many members to paste.", MsgBoxStyle.Information);
				return;
			}
			StoreUndoAnl ("Paste Members");
			if (num3 > Information.UBound (analysis.Beam)) {
				ref Beam[] beam = ref analysis.Beam;
				beam = (Beam[])Utils.CopyArray (beam, new Beam[(int)System.Math.Round (System.Math.Ceiling ((double)num3 / 10.0) * 10.0) + 1]);
			}
			if (num > num2) {
				byte nBeam = analysis.nBeam;
				short num4 = (short)unchecked(bytBeamStart + num2);
				for (short num5 = nBeam; num5 >= num4; num5 = (short)unchecked(num5 + -1)) {
					analysis.Beam [(short)unchecked(num5 + checked((short)unchecked(num - num2)))] = analysis.Beam [num5];
				}
			} else if (num2 > num) {
				short num6 = (short)unchecked(bytBeamStart + num2);
				short nBeam2 = analysis.nBeam;
				for (short num5 = num6; num5 <= nBeam2; num5 = (short)unchecked(num5 + 1)) {
					analysis.Beam [(short)unchecked(num5 - checked((short)unchecked(num2 - num)))] = analysis.Beam [num5];
				}
			}
			byte num7 = bytBeamStart;
			short num8 = (short)((short)unchecked(bytBeamStart + num) - 1);
			for (short num5 = num7; num5 <= num8; num5 = (short)unchecked(num5 + 1)) {
				analysis.Beam [num5] = cbBeam [(short)unchecked(num5 - bytBeamStart) + 1];
			}
			analysis.nBeam = (byte)num3;
			analysis.BeamGrid.RowStart = bytBeamStart;
			analysis.BeamGrid.RowEnd = (byte)((short)unchecked(bytBeamStart + num) - 1);
			analysis = null;
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdBeams = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void PasteLFs (Analysis Analysis1, byte bytComb, byte bytLFStart = 0, byte bytLFEnd = 0)
	{
		if (((bytClipBoard != 9) & (bytClipBoard != 10)) || Strings.StrComp (strClipBoard, Clipboard.GetText ()) != 0) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytClipBoard == 9) {
				ref LoadCombination reference = ref Analysis1.Comb [bytComb];
				if (bytLFStart == 0) {
					bytLFStart = (byte)(unchecked((int)reference.nLF) + 1);
				}
				if (bytLFEnd == 0) {
					bytLFEnd = (byte)(unchecked((int)reference.nLF) + 1);
				}
				if (unchecked((uint)bytLFEnd < (uint)bytLFStart)) {
					CFS.Swap (ref bytLFStart, ref bytLFEnd);
				}
				if (bytLFStart < 1) {
					bytLFStart = 1;
				}
				if (bytLFEnd > unchecked((int)reference.nLF) + 1) {
					bytLFEnd = (byte)(unchecked((int)reference.nLF) + 1);
				}
				short num = (short)Information.UBound (cbLF);
				short num2;
				if (bytLFEnd == bytLFStart) {
					num2 = 0;
				} else {
					if (unchecked((uint)bytLFEnd > (uint)reference.nLF)) {
						bytLFEnd = reference.nLF;
					}
					num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLFEnd - bytLFStart)))) + 1);
				}
				short num3 = (short)unchecked(checked((short)unchecked(reference.nLF + num)) - num2);
				if (num3 > 254) {
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("Too many load factors to paste.", MsgBoxStyle.Information);
					return;
				}
				StoreUndoAnl ("Paste Load Factors");
				if (num3 > Information.UBound (reference.LF)) {
					ref LoadFactor[] lF = ref reference.LF;
					lF = (LoadFactor[])Utils.CopyArray (lF, new LoadFactor[(int)System.Math.Round (System.Math.Ceiling ((double)num3 / 10.0) * 10.0) + 1]);
				}
				if (num > num2) {
					byte nLF = reference.nLF;
					short num4 = (short)unchecked(bytLFStart + num2);
					for (short num5 = nLF; num5 >= num4; num5 = (short)unchecked(num5 + -1)) {
						reference.LF [(short)unchecked(num5 + checked((short)unchecked(num - num2)))] = reference.LF [num5];
					}
				} else if (num2 > num) {
					short num6 = (short)unchecked(bytLFStart + num2);
					short nLF2 = reference.nLF;
					for (short num5 = num6; num5 <= nLF2; num5 = (short)unchecked(num5 + 1)) {
						reference.LF [(short)unchecked(num5 - checked((short)unchecked(num2 - num)))] = reference.LF [num5];
					}
				}
				byte num7 = bytLFStart;
				short num8 = (short)((short)unchecked(bytLFStart + num) - 1);
				for (short num5 = num7; num5 <= num8; num5 = (short)unchecked(num5 + 1)) {
					reference.LF [num5] = cbLF [(short)unchecked(num5 - bytLFStart) + 1];
				}
				reference.nLF = (byte)num3;
				reference.LFGrid.RowStart = bytLFStart;
				reference.LFGrid.RowEnd = (byte)((short)unchecked(bytLFStart + num) - 1);
			} else if (bytClipBoard == 10) {
				Analysis analysis = Analysis1;
				StoreUndoAnl ("Paste Combination");
				short nComb = analysis.nComb;
				short num9 = 1;
				while (num9 <= nComb && Strings.StrComp (cbComb.Description, analysis.Comb [num9].Description, CompareMethod.Text) != 0) {
					num9 = (short)unchecked(num9 + 1);
				}
				string text;
				if (num9 <= analysis.nComb) {
					num9 = 0;
					short num10;
					do {
						num9 = (short)(num9 + 1);
						short nComb2;
						unchecked {
							text = "Combination " + Conversions.ToString ((int)checked((short)unchecked(analysis.nComb + num9)));
							nComb2 = analysis.nComb;
							num10 = 1;
						}
						while (num10 <= nComb2 && Strings.StrComp (analysis.Comb [num10].Description, text, CompareMethod.Text) != 0) {
							num10 = (short)unchecked(num10 + 1);
						}
					} while (num10 <= analysis.nComb);
				} else {
					text = cbComb.Description;
				}
				analysis.nComb++;
				analysis.iComb = analysis.nComb;
				if (analysis.nComb > Information.UBound (analysis.Comb)) {
					ref LoadCombination[] comb = ref analysis.Comb;
					comb = (LoadCombination[])Utils.CopyArray (comb, new LoadCombination[unchecked((int)analysis.nComb) + 1]);
				}
				analysis.Comb [analysis.nComb] = cbComb;
				analysis.Comb [analysis.nComb].Description = text;
				analysis = null;
			}
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdCombs = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void PasteLoads (Analysis Analysis1, byte bytLdg, byte bytLoadStart = 0, byte bytLoadEnd = 0)
	{
		if (((bytClipBoard != 7) & (bytClipBoard != 8)) || Strings.StrComp (strClipBoard, Clipboard.GetText ()) != 0) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		checked {
			if (bytClipBoard == 7) {
				ref Loading reference = ref Analysis1.Ldg [bytLdg];
				if (bytLoadStart == 0) {
					bytLoadStart = (byte)(unchecked((int)reference.nLoad) + 1);
				}
				if (bytLoadEnd == 0) {
					bytLoadEnd = (byte)(unchecked((int)reference.nLoad) + 1);
				}
				if (unchecked((uint)bytLoadEnd < (uint)bytLoadStart)) {
					CFS.Swap (ref bytLoadStart, ref bytLoadEnd);
				}
				if (bytLoadStart < 1) {
					bytLoadStart = 1;
				}
				if (bytLoadEnd > unchecked((int)reference.nLoad) + 1) {
					bytLoadEnd = (byte)(unchecked((int)reference.nLoad) + 1);
				}
				short num = (short)Information.UBound (cbLoad);
				short num2;
				if (bytLoadEnd == bytLoadStart) {
					num2 = 0;
				} else {
					if (unchecked((uint)bytLoadEnd > (uint)reference.nLoad)) {
						bytLoadEnd = reference.nLoad;
					}
					num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytLoadEnd - bytLoadStart)))) + 1);
				}
				short num3 = (short)unchecked(checked((short)unchecked(reference.nLoad + num)) - num2);
				if (num3 > 254) {
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("Too many loads to paste.", MsgBoxStyle.Information);
					return;
				}
				StoreUndoAnl ("Paste Loads");
				if (num3 > Information.UBound (reference.Load)) {
					ref Load[] load = ref reference.Load;
					load = (Load[])Utils.CopyArray (load, new Load[(int)System.Math.Round (System.Math.Ceiling ((double)num3 / 10.0) * 10.0) + 1]);
				}
				if (num > num2) {
					byte nLoad = reference.nLoad;
					short num4 = (short)unchecked(bytLoadStart + num2);
					for (short num5 = nLoad; num5 >= num4; num5 = (short)unchecked(num5 + -1)) {
						reference.Load [(short)unchecked(num5 + checked((short)unchecked(num - num2)))] = reference.Load [num5];
					}
				} else if (num2 > num) {
					short num6 = (short)unchecked(bytLoadStart + num2);
					short nLoad2 = reference.nLoad;
					for (short num5 = num6; num5 <= nLoad2; num5 = (short)unchecked(num5 + 1)) {
						reference.Load [(short)unchecked(num5 - checked((short)unchecked(num2 - num)))] = reference.Load [num5];
					}
				}
				byte num7 = bytLoadStart;
				short num8 = (short)((short)unchecked(bytLoadStart + num) - 1);
				for (short num5 = num7; num5 <= num8; num5 = (short)unchecked(num5 + 1)) {
					reference.Load [num5] = cbLoad [(short)unchecked(num5 - bytLoadStart) + 1];
				}
				reference.nLoad = (byte)num3;
				reference.LoadGrid.RowStart = bytLoadStart;
				reference.LoadGrid.RowEnd = (byte)((short)unchecked(bytLoadStart + num) - 1);
			} else if (bytClipBoard == 8) {
				Analysis analysis = Analysis1;
				StoreUndoAnl ("Paste Loading");
				short nLdg = analysis.nLdg;
				short num9 = 1;
				while (num9 <= nLdg && Strings.StrComp (cbLdg.Description, analysis.Ldg [num9].Description, CompareMethod.Text) != 0) {
					num9 = (short)unchecked(num9 + 1);
				}
				string text;
				if (num9 <= analysis.nLdg) {
					num9 = 0;
					short num10;
					do {
						num9 = (short)(num9 + 1);
						short nLdg2;
						unchecked {
							text = "Loading " + Conversions.ToString ((int)checked((short)unchecked(analysis.nLdg + num9)));
							nLdg2 = analysis.nLdg;
							num10 = 1;
						}
						while (num10 <= nLdg2 && Strings.StrComp (analysis.Ldg [num10].Description, text, CompareMethod.Text) != 0) {
							num10 = (short)unchecked(num10 + 1);
						}
					} while (num10 <= analysis.nLdg);
				} else {
					text = cbLdg.Description;
				}
				analysis.nLdg++;
				analysis.iLdg = analysis.nLdg;
				if (analysis.nLdg > Information.UBound (analysis.Ldg)) {
					ref Loading[] ldg = ref analysis.Ldg;
					ldg = (Loading[])Utils.CopyArray (ldg, new Loading[unchecked((int)analysis.nLdg) + 1]);
				}
				analysis.Ldg [analysis.nLdg] = cbLdg;
				analysis.Ldg [analysis.nLdg].Description = text;
				analysis = null;
			}
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdLoads = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void PasteSupports (Analysis Analysis1, byte bytSupStart = 0, byte bytSupEnd = 0)
	{
		if (bytClipBoard != 6 || Strings.StrComp (strClipBoard, Clipboard.GetText ()) != 0) {
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		Analysis analysis = Analysis1;
		checked {
			if (bytSupStart == 0) {
				bytSupStart = (byte)(unchecked((int)analysis.nSup) + 1);
			}
			if (bytSupEnd == 0) {
				bytSupEnd = (byte)(unchecked((int)analysis.nSup) + 1);
			}
			if (unchecked((uint)bytSupEnd < (uint)bytSupStart)) {
				CFS.Swap (ref bytSupStart, ref bytSupEnd);
			}
			if (bytSupStart < 1) {
				bytSupStart = 1;
			}
			if (bytSupEnd > unchecked((int)analysis.nSup) + 1) {
				bytSupEnd = (byte)(unchecked((int)analysis.nSup) + 1);
			}
			short num = (short)Information.UBound (cbSupport);
			short num2;
			if (bytSupEnd == bytSupStart) {
				num2 = 0;
			} else {
				if (unchecked((uint)bytSupEnd > (uint)analysis.nSup)) {
					bytSupEnd = analysis.nSup;
				}
				num2 = (short)(unchecked((int)checked((byte)unchecked((uint)(bytSupEnd - bytSupStart)))) + 1);
			}
			short num3 = (short)unchecked(checked((short)unchecked(analysis.nSup + num)) - num2);
			if (num3 > 254) {
				Cursor.Current = Cursors.Default;
				Interaction.MsgBox ("Too many supports to paste.", MsgBoxStyle.Information);
				return;
			}
			StoreUndoAnl ("Paste Supports");
			if (num3 > Information.UBound (analysis.Sup)) {
				ref Support[] sup = ref analysis.Sup;
				sup = (Support[])Utils.CopyArray (sup, new Support[(int)System.Math.Round (System.Math.Ceiling ((double)num3 / 10.0) * 10.0) + 1]);
			}
			if (num > num2) {
				byte nSup = analysis.nSup;
				short num4 = (short)unchecked(bytSupStart + num2);
				for (short num5 = nSup; num5 >= num4; num5 = (short)unchecked(num5 + -1)) {
					analysis.Sup [(short)unchecked(num5 + checked((short)unchecked(num - num2)))] = analysis.Sup [num5];
				}
			} else if (num2 > num) {
				short num6 = (short)unchecked(bytSupStart + num2);
				short nSup2 = analysis.nSup;
				for (short num5 = num6; num5 <= nSup2; num5 = (short)unchecked(num5 + 1)) {
					analysis.Sup [(short)unchecked(num5 - checked((short)unchecked(num2 - num)))] = analysis.Sup [num5];
				}
			}
			byte num7 = bytSupStart;
			short num8 = (short)((short)unchecked(bytSupStart + num) - 1);
			for (short num5 = num7; num5 <= num8; num5 = (short)unchecked(num5 + 1)) {
				analysis.Sup [num5] = cbSupport [(short)unchecked(num5 - bytSupStart) + 1];
			}
			analysis.nSup = (byte)num3;
			analysis.SupGrid.RowStart = bytSupStart;
			analysis.SupGrid.RowEnd = (byte)((short)unchecked(bytSupStart + num) - 1);
			analysis = null;
			Analysis1.Saved = false;
			Analysis1.RevDate = DateAndTime.Now;
			Analysis1.RevBy = CFS.User.Name;
			Analysis1.iCombSol = 0;
			CFS.blnRefreshGrdSupports = true;
			RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
			SetMenuEdit ();
			_ = null;
			Cursor.Current = Cursors.Default;
		}
	}

	public static void SortBeams (Analysis Analysis1)
	{
		bool flag = false;
		Analysis analysis = Analysis1;
		short nBeam = analysis.nBeam;
		checked {
			for (short num = 1; num <= nBeam; num = (short)unchecked(num + 1)) {
				if (analysis.Beam [num].Z0 > analysis.Beam [num].Z1) {
					CFS.Swap (ref analysis.Beam [num].Z0, ref analysis.Beam [num].Z1);
					flag = true;
				}
			}
			short num2 = (short)(unchecked((int)analysis.nBeam) - 1);
			for (short num = 1; num <= num2; num = (short)unchecked(num + 1)) {
				if ((analysis.Beam [num].Z0 > analysis.Beam [num + 1].Z0) | ((analysis.Beam [num].Z0 == analysis.Beam [num + 1].Z0) & (analysis.Beam [num].Z1 > analysis.Beam [num + 1].Z1))) {
					Beam beam = analysis.Beam [num];
					analysis.Beam [num] = analysis.Beam [num + 1];
					analysis.Beam [num + 1] = beam;
					if (analysis.BeamGrid.RowStart == num) {
						analysis.BeamGrid.RowStart = (byte)(num + 1);
						analysis.BeamGrid.RowEnd = analysis.BeamGrid.RowStart;
					} else if (analysis.BeamGrid.RowStart == num + 1) {
						analysis.BeamGrid.RowStart = (byte)num;
						analysis.BeamGrid.RowEnd = analysis.BeamGrid.RowStart;
					}
					if (num > 1) {
						num = (short)(num - 2);
					}
					flag = true;
				}
			}
			analysis = null;
			if (flag) {
				CFS.blnRefreshGrdBeams = true;
			}
		}
	}

	public static void SortLoads (ref Loading Loading1)
	{
		bool flag = false;
		short nLoad = Loading1.nLoad;
		checked {
			for (short num = 1; num <= nLoad; num = (short)unchecked(num + 1)) {
				if (Loading1.Load [num].Z0 > Loading1.Load [num].Z1) {
					CFS.Swap (ref Loading1.Load [num].Z0, ref Loading1.Load [num].Z1);
					flag = true;
				}
			}
			short num2 = (short)(unchecked((int)Loading1.nLoad) - 1);
			for (short num = 1; num <= num2; num = (short)unchecked(num + 1)) {
				if ((Loading1.Load [num].Z0 > Loading1.Load [num + 1].Z0) | ((Loading1.Load [num].Z0 == Loading1.Load [num + 1].Z0) & (Loading1.Load [num].Z1 > Loading1.Load [num + 1].Z1))) {
					Load load = Loading1.Load [num];
					Loading1.Load [num] = Loading1.Load [num + 1];
					Loading1.Load [num + 1] = load;
					if (Loading1.LoadGrid.RowStart == num) {
						Loading1.LoadGrid.RowStart = (byte)(num + 1);
						Loading1.LoadGrid.RowEnd = Loading1.LoadGrid.RowStart;
					} else if (Loading1.LoadGrid.RowStart == num + 1) {
						Loading1.LoadGrid.RowStart = (byte)num;
						Loading1.LoadGrid.RowEnd = Loading1.LoadGrid.RowStart;
					}
					if (num > 1) {
						num = (short)(num - 2);
					}
					flag = true;
				}
			}
			if (flag) {
				CFS.blnRefreshGrdLoads = true;
			}
		}
	}

	public static void SortSups (Analysis Analysis1)
	{
		bool flag = false;
		Analysis analysis = Analysis1;
		checked {
			short num = (short)(unchecked((int)analysis.nSup) - 1);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (analysis.Sup [num2].Z > analysis.Sup [num2 + 1].Z) {
					Support support = analysis.Sup [num2];
					analysis.Sup [num2] = analysis.Sup [num2 + 1];
					analysis.Sup [num2 + 1] = support;
					if (analysis.SupGrid.RowStart == num2) {
						analysis.SupGrid.RowStart = (byte)(num2 + 1);
						analysis.SupGrid.RowEnd = analysis.SupGrid.RowStart;
					} else if (analysis.SupGrid.RowStart == num2 + 1) {
						analysis.SupGrid.RowStart = (byte)num2;
						analysis.SupGrid.RowEnd = analysis.SupGrid.RowStart;
					}
					if (num2 > 1) {
						num2 = (short)(num2 - 2);
					}
					flag = true;
				}
			}
			analysis = null;
			if (flag) {
				CFS.blnRefreshGrdSupports = true;
			}
		}
	}

	public static bool RemoveLdg (Analysis Analysis1, byte iLdg)
	{
		bool result = false;
		if (!((iLdg < 1) | ((uint)iLdg > (uint)Analysis1.nLdg))) {
			Analysis analysis = Analysis1;
			short nComb = analysis.nComb;
			checked {
				for (short num = 1; num <= nComb; num = (short)unchecked(num + 1)) {
					ref LoadCombination reference = ref analysis.Comb [num];
					short num2 = 0;
					short nLF = reference.nLF;
					for (short num3 = 1; num3 <= nLF; num3 = (short)unchecked(num3 + 1)) {
						if (reference.LF [num3].iLdg == iLdg) {
							num2 = (short)(num2 + 1);
						} else {
							if (unchecked((uint)reference.LF [num3].iLdg > (uint)iLdg)) {
								reference.LF [num3].iLdg = (byte)(unchecked((int)reference.LF [num3].iLdg) - 1);
							}
							reference.LF [(short)unchecked(num3 - num2)] = reference.LF [num3];
						}
					}
					reference.nLF = (byte)(short)unchecked(reference.nLF - num2);
					if (num2 > 0) {
						result = true;
						if (num == Analysis1.iCombSol) {
							Analysis1.iCombSol = 0;
						}
						if (num == Analysis1.iComb) {
							CFS.blnRefreshGrdCombs = true;
						}
					}
				}
				analysis.nLdg--;
				short nLdg = analysis.nLdg;
				short num4;
				for (num4 = iLdg; num4 <= nLdg; num4 = (short)unchecked(num4 + 1)) {
					analysis.Ldg [num4] = analysis.Ldg [num4 + 1];
				}
				analysis.Ldg [num4] = new Loading (string.Empty, 10);
				if (analysis.iLdg > 1) {
					analysis.iLdg--;
				}
				if (analysis.nLdg == 0) {
					analysis.Ldg [analysis.iLdg].Description = "Loading 1";
				}
				analysis.Saved = false;
				analysis.RevDate = DateAndTime.Now;
				analysis.RevBy = CFS.User.Name;
				SetMenuEdit ();
				analysis = null;
			}
		}
		return result;
	}

	public static bool RemoveBeam (Analysis Analysis1, byte iSct)
	{
		bool result = false;
		Analysis analysis = Analysis1;
		short num = 0;
		short nBeam = analysis.nBeam;
		checked {
			for (short num2 = 1; num2 <= nBeam; num2 = (short)unchecked(num2 + 1)) {
				if (analysis.Beam [num2].iSct == iSct) {
					num = (short)(num + 1);
				} else {
					analysis.Beam [(short)unchecked(num2 - num)] = analysis.Beam [num2];
				}
			}
			analysis.nBeam = (byte)(short)unchecked(analysis.nBeam - num);
			if (num > 0) {
				analysis.Saved = false;
				analysis.RevDate = DateAndTime.Now;
				analysis.RevBy = CFS.User.Name;
				analysis.iCombSol = 0;
				result = true;
			}
			analysis = null;
			return result;
		}
	}

	public static void SaveReport (frmReportMaster frmReport)
	{
		if ($STATIC$SaveReport$011128154$strPathPrev$Init == null) {
			Interlocked.CompareExchange (ref $STATIC$SaveReport$011128154$strPathPrev$Init, new StaticLocalInitFlag (), null);
		}
		bool lockTaken = false;
		try {
			Monitor.Enter ($STATIC$SaveReport$011128154$strPathPrev$Init, ref lockTaken);
			if ($STATIC$SaveReport$011128154$strPathPrev$Init.State == 0) {
				$STATIC$SaveReport$011128154$strPathPrev$Init.State = 2;
				$STATIC$SaveReport$011128154$strPathPrev = string.Empty;
			} else if ($STATIC$SaveReport$011128154$strPathPrev$Init.State == 2) {
				throw new IncompleteInitialization ();
			}
		} finally {
			$STATIC$SaveReport$011128154$strPathPrev$Init.State = 1;
			if (lockTaken) {
				Monitor.Exit ($STATIC$SaveReport$011128154$strPathPrev$Init);
			}
		}
		My.MyProject.Forms.mdiCFS.dlgSaveFile.Filter = "Word Document (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf";
		My.MyProject.Forms.mdiCFS.dlgSaveFile.FilterIndex = 1;
		My.MyProject.Forms.mdiCFS.dlgSaveFile.Title = "Save Report File";
		short num = Conversions.ToByte (frmReport.Tag);
		if (LikeOperator.LikeString (CFS.hdgReport [num].Filename, Strings.Trim ("\\Section ") + "*", CompareMethod.Binary) | LikeOperator.LikeString (CFS.hdgReport [num].Filename, Strings.Trim ("\\Analysis ") + "*", CompareMethod.Binary)) {
			My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = string.Empty;
		} else {
			My.MyProject.Forms.mdiCFS.dlgSaveFile.InitialDirectory = string.Empty;
		}
		My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName = GetFileNameWithoutExtension (CFS.hdgReport [num].Filename);
		if (My.MyProject.Forms.mdiCFS.dlgSaveFile.ShowDialog () != DialogResult.Cancel) {
			Cursor.Current = Cursors.WaitCursor;
			$STATIC$SaveReport$011128154$strPathPrev = GetFullPath (My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName);
			RichTextBox richTextBox = new RichTextBox ();
			num = Conversions.ToByte (frmReport.Tag);
			Report.rptHeading (richTextBox, CFS.hdgReport [num]);
			richTextBox.SelectionStart = Strings.Len (richTextBox.Text);
			richTextBox.SelectedRtf = frmReport.rtfReport.Rtf;
			richTextBox.SaveFile (My.MyProject.Forms.mdiCFS.dlgSaveFile.FileName);
			richTextBox.Dispose ();
			Cursor.Current = Cursors.Default;
		}
	}

	public static bool BuildList (System.Windows.Forms.ComboBox ctrName)
	{
		if (!(ctrName.Tag is ControlData)) {
			return false;
		}
		object left = NewLateBinding.LateGet (ctrName.Tag, null, "UnitType", new object[0], null, null, null);
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.NoUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untNone);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.LengthUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLength);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len1Unit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLength);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len2Unit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLen2);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len3Unit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLen3);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len4Unit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLen4);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len6Unit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLen6);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.AngleUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untAngle);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.StressUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untStress);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.ForceUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untForce);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.MomentUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untMoment);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.LoadUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untLoad);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.TorqueUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untTorque);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.BimomentUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untBimoment);
		}
		if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.TorqueLoadUnit, TextCompare: false)) {
			return BuildList (ctrName, Units.untTorqueLoad);
		}
		return false;
	}

	private static bool BuildList (System.Windows.Forms.ComboBox ctrName, Units.Unit[] untUnitType)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		short selectionStart = default(short);
		short selectionLength = default(short);
		float sngValue = default(float);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						string @string = "+-Ee0123456789" + Strings.Mid (Strings.Format (0.5, "0.0"), 2, 1);
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						if (ctrName is System.Windows.Forms.ComboBox) {
							System.Windows.Forms.ComboBox comboBox = ctrName;
							selectionStart = (short)comboBox.SelectionStart;
							selectionLength = (short)comboBox.SelectionLength;
							comboBox.Items.Clear ();
						}
						string text = Strings.Trim (ctrName.Text);
						short num3 = (short)Strings.Len (text);
						short num4 = 1;
						while (num4 <= num3 && Strings.InStr (1, @string, Strings.Mid (text, num4, 1)) != 0) {
							num4 = (short)unchecked(num4 + 1);
						}
						string text2 = Strings.Trim (Strings.Mid (text, num4));
						if (Strings.Len (text2) == 0) {
							sngValue = (float)(ValEx (text) / (double)untUnitType [Conversions.ToInteger (NewLateBinding.LateGet (ctrName.Tag, null, "Index", new object[0], null, null, null))].Mult);
							num4 = 0;
						} else {
							short num5 = (short)Information.UBound (untUnitType);
							for (num4 = 1; num4 <= num5; num4 = (short)unchecked(num4 + 1)) {
								if (Strings.StrComp (untUnitType [num4].Name, text2) == 0) {
									sngValue = (float)(ValEx (text) / (double)untUnitType [num4].Mult);
									NewLateBinding.LateSetComplex (ctrName.Tag, null, "Index", new object[1] { num4 }, null, null, OptimisticSet: false, RValueBase: true);
									break;
								}
							}
						}
						if (num4 > Information.UBound (untUnitType)) {
							goto end_IL_0000;
						}
						if (ctrName is System.Windows.Forms.ComboBox) {
							System.Windows.Forms.ComboBox comboBox = ctrName;
							short num6 = (short)Information.UBound (untUnitType);
							for (short num7 = 1; num7 <= num6; num7 = (short)unchecked(num7 + 1)) {
								if (untUnitType [num7].Mult > 0f) {
									comboBox.Items.Add (new ListItem (Units.DisplayValue (sngValue, untUnitType [num7], blnShowUnit: true, "", 0, 0), num7));
								}
							}
							comboBox.SelectionStart = selectionStart;
							comboBox.SelectionLength = selectionLength;
						}
						result = true;
						goto end_IL_0000_2;
					}
					case 560:
						num = -1;
						switch (num2) {
						case 2: {
							int number = Information.Err ().Number;
							if (number != 6) {
								Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
							}
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000_2;
						}
						}
						break;
					}
					goto IL_0266;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 560;
				continue;
			}
			break;
			IL_0266:
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

	public static void SetText (Control Ctrl, float sngValue, bool blnShowUnit = true)
	{
		Ctrl.Text = Units.DisplayValue (sngValue, Conversions.ToByte (NewLateBinding.LateGet (Ctrl.Tag, null, "UnitType", new object[0], null, null, null)), Conversions.ToByte (NewLateBinding.LateGet (Ctrl.Tag, null, "Index", new object[0], null, null, null)), blnShowUnit, "", 0, 0);
		if (Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreaterEqual (sngValue, NewLateBinding.LateGet (Ctrl.Tag, null, "Min", new object[0], null, null, null), TextCompare: false), Operators.CompareObjectLessEqual (sngValue, NewLateBinding.LateGet (Ctrl.Tag, null, "Max", new object[0], null, null, null), TextCompare: false)))) {
			NewLateBinding.LateSetComplex (Ctrl.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (Ctrl.Tag, null, "Text", new object[1] { Ctrl.Text }, null, null, OptimisticSet: false, RValueBase: true);
		} else {
			NewLateBinding.LateSetComplex (Ctrl.Tag, null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (Ctrl.Tag, null, "Text", new object[1] { Units.DisplayValue (Conversions.ToSingle (NewLateBinding.LateGet (Ctrl.Tag, null, "Min", new object[0], null, null, null)), Conversions.ToByte (NewLateBinding.LateGet (Ctrl.Tag, null, "UnitType", new object[0], null, null, null)), Conversions.ToByte (NewLateBinding.LateGet (Ctrl.Tag, null, "Index", new object[0], null, null, null)), blnShowUnit, "", 0, 0) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	public static void SetSelection (Control ctrName, bool blnNumeric = true)
	{
		short num = checked((short)Strings.InStr (ctrName.Text, Strings.Space (1)));
		if (ctrName is TextBox) {
			TextBox textBox = (TextBox)ctrName;
			if (blnNumeric && num > 0) {
				textBox.SelectionStart = 0;
				textBox.SelectionLength = checked(num - 1);
			} else {
				textBox.SelectAll ();
			}
		}
		if (ctrName is System.Windows.Forms.ComboBox) {
			System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)ctrName;
			if (blnNumeric && num > 0) {
				comboBox.SelectionStart = 0;
				comboBox.SelectionLength = checked(num - 1);
			} else {
				comboBox.SelectAll ();
			}
		}
	}

	public static short SetSelectedItem (System.Windows.Forms.ComboBox cboName, string Text)
	{
		short result = -1;
		checked {
			int num = cboName.Items.Count - 1;
			for (int i = 0; i <= num; i++) {
				if (Strings.StrComp (Text, cboName.Items [i].ToString ()) == 0) {
					cboName.SelectedIndex = i;
					result = (short)i;
					break;
				}
			}
			return result;
		}
	}

	public static bool Validate (Control ctrName, bool blnShowUnit = true)
	{
		bool result = false;
		if (ctrName.Tag is ControlData) {
			object left = NewLateBinding.LateGet (ctrName.Tag, null, "UnitType", new object[0], null, null, null);
			if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.NoUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untNone, blnShowUnit: false);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.LengthUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLength, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len1Unit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLength, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len2Unit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLen2, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len3Unit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLen3, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len4Unit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLen4, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.Len6Unit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLen6, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.AngleUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untAngle, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.StressUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untStress, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.ForceUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untForce, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.MomentUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untMoment, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.LoadUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untLoad, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.TorqueUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untTorque, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.BimomentUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untBimoment, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.TorqueLoadUnit, TextCompare: false)) {
				result = Validate (ctrName, Units.untTorqueLoad, blnShowUnit);
			} else if (Operators.ConditionalCompareObjectEqual (left, Units.UnitTypes.StringOnly, TextCompare: false)) {
				object tag = ctrName.Tag;
				if (Conversions.ToBoolean (Operators.OrObject (Operators.CompareObjectLess (NewLateBinding.LateGet (tag, null, "Index", new object[0], null, null, null), NewLateBinding.LateGet (tag, null, "Min", new object[0], null, null, null), TextCompare: false), Operators.CompareObjectGreater (NewLateBinding.LateGet (tag, null, "Index", new object[0], null, null, null), NewLateBinding.LateGet (tag, null, "Max", new object[0], null, null, null), TextCompare: false)))) {
					result = false;
					NewLateBinding.LateSetComplex (tag, null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
				} else {
					result = true;
					NewLateBinding.LateSetComplex (tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				}
				NewLateBinding.LateSetComplex (tag, null, "Value", new object[1] { NewLateBinding.LateGet (tag, null, "Index", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
				NewLateBinding.LateSetComplex (tag, null, "Text", new object[1] { ctrName.Text }, null, null, OptimisticSet: false, RValueBase: true);
				tag = null;
			}
		}
		return result;
	}

	private static bool Validate (Control ctrName, Units.Unit[] untUnitType, bool blnShowUnit = true)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						string text2 = string.Empty;
						string @string = "+-Ee0123456789" + Strings.Mid (Strings.Format (0.5, "0.0"), 2, 1);
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						ControlData controlData = (ControlData)ctrName.Tag;
						controlData.Valid = false;
						controlData.Value = 0f;
						string text3 = Strings.Trim (ctrName.Text);
						short num3 = (short)Strings.Len (text3);
						short num4 = 1;
						while (num4 <= num3 && Strings.InStr (1, @string, Strings.Mid (text3, num4, 1)) != 0) {
							num4 = (short)unchecked(num4 + 1);
						}
						string text4 = Strings.Trim (Strings.Mid (text3, num4));
						if (Strings.Len (text4) == 0) {
							controlData.Value = (float)(ValEx (text3) / (double)untUnitType [controlData.Index].Mult);
							num4 = 0;
						} else {
							text2 = string.Empty;
							short num5 = (short)Information.UBound (untUnitType);
							for (num4 = 1; num4 <= num5; num4 = (short)unchecked(num4 + 1)) {
								if (Strings.StrComp (untUnitType [num4].Name, text4) == 0) {
									controlData.Value = (float)(ValEx (text3) / (double)untUnitType [num4].Mult);
									if (blnShowUnit) {
										controlData.Index = num4;
									}
									break;
								}
								if (untUnitType [num4].Mult > 0f) {
									text2 = text2 + untUnitType [num4].Name + ", ";
								}
							}
						}
						if (num4 <= Information.UBound (untUnitType)) {
							if (controlData.Value < controlData.Min) {
								Interaction.MsgBox ("Value less than " + Units.DisplayValue (controlData.Min, untUnitType [controlData.Index], blnShowUnit: true, "", 0, 0), MsgBoxStyle.Information);
								goto end_IL_0000;
							}
							if (controlData.Value > controlData.Max) {
								Interaction.MsgBox ("Value greater than " + Units.DisplayValue (controlData.Max, untUnitType [controlData.Index], blnShowUnit: true, "", 0, 0), MsgBoxStyle.Information);
								goto end_IL_0000;
							}
							controlData.Text = Units.DisplayValue (controlData.Value, untUnitType [controlData.Index], blnShowUnit, "", 0, 0);
							controlData.Valid = true;
							result = true;
						} else {
							text2 = Strings.Left (text2, Strings.Len (text2) - 2);
							if (Strings.Len (text2) != 0) {
								text3 = "Please select a unit from:\n{" + text2 + "}.\n";
								text3 = ((!blnShowUnit) ? (text3 + "If no unit is specified, the default unit is assumed.") : (text3 + "If no unit is specified, the previously displayed unit is assumed."));
							} else {
								text3 = "This is a dimensionless value and should not contain units.";
							}
							Interaction.MsgBox (text3, MsgBoxStyle.Information);
						}
						goto end_IL_0000_2;
					}
					case 796:
						num = -1;
						switch (num2) {
						case 2: {
							int number = Information.Err ().Number;
							string text = ((number != 6) ? ("Unexpected Error:  " + Information.Err ().Description) : ("The value entered is outside the range allowed by " + Application.ProductName + "."));
							if (Strings.Len (text) != 0) {
								Interaction.MsgBox (text, MsgBoxStyle.Information);
							}
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000_2;
						}
						}
						break;
					}
					goto IL_0352;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 796;
				continue;
			}
			break;
			IL_0352:
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

	public static double ValEx (string strText)
	{
		string @string = Strings.Mid (Strings.Format (0.5, "0.0"), 2, 1);
		short num = checked((short)Strings.InStr (1, strText, @string));
		if (num != 0) {
			StringType.MidStmtStr (ref strText, num, int.MaxValue, ".");
		}
		return Conversion.Val (strText);
	}

	public static void SetGrid (Grid grdName, GridState grdNameGrid)
	{
		bool flag = default(bool);
		if (grdNameGrid.RowStart < 1) {
			grdNameGrid.RowStart = 1;
			flag = true;
		}
		checked {
			if (grdNameGrid.RowStart > grdName.Rows - 1) {
				grdNameGrid.RowStart = (byte)(grdName.Rows - 1);
				flag = true;
			}
			if (grdNameGrid.RowEnd < 1) {
				grdNameGrid.RowEnd = 1;
				flag = true;
			}
			if (grdNameGrid.RowEnd > grdName.Rows - 1) {
				grdNameGrid.RowEnd = (byte)(grdName.Rows - 1);
				flag = true;
			}
			if (grdNameGrid.TopRow > grdName.Rows - 1) {
				grdNameGrid.TopRow = (byte)(grdName.Rows - 1);
				flag = true;
			}
			if (grdNameGrid.LeftCol > grdName.Cols - 1) {
				grdNameGrid.LeftCol = (byte)(grdName.Cols - 1);
				flag = true;
			}
			if (flag) {
				SetMenuEdit ();
			}
		}
		grdName.Range (Conversions.ToInteger (Interaction.IIf ((int)grdNameGrid.Corner / 2 == 0, grdNameGrid.RowStart, grdNameGrid.RowEnd)), Conversions.ToInteger (Interaction.IIf ((int)grdNameGrid.Corner % 2 == 0, grdNameGrid.ColStart, grdNameGrid.ColEnd)), Conversions.ToInteger (Interaction.IIf ((int)grdNameGrid.Corner / 2 == 0, grdNameGrid.RowEnd, grdNameGrid.RowStart)), Conversions.ToInteger (Interaction.IIf ((int)grdNameGrid.Corner % 2 == 0, grdNameGrid.ColEnd, grdNameGrid.ColStart))).SelectCells ();
		grdName.TopRow = grdNameGrid.TopRow;
		grdName.LeftCol = grdNameGrid.LeftCol;
	}

	public static void SetMenuFile ()
	{
		My.MyProject.Forms.mdiCFS.mnuFileNewAnalysis.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrNewAnalysis.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuFileSave.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrSave.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuFileSaveAs.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrSaveAs.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuFileClose.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuFileReportInputs.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrPrintPreview.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuFilePrint.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrPrint.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrCascade.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrTileVertical.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrTileHorizontal.Enabled = false;
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild == null) {
			return;
		}
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmSctPicMaster) {
			if (CFS.intSctNow == 0) {
				return;
			}
			My.MyProject.Forms.mdiCFS.mnuFileSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuFileSaveAs.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSaveAs.Enabled = true;
		} else if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmAnlPicMaster) {
			if (CFS.intAnlNow == 0) {
				return;
			}
			My.MyProject.Forms.mdiCFS.mnuFileSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuFileSaveAs.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSaveAs.Enabled = true;
		} else if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmReportMaster) {
			if (Information.IsNothing (RuntimeHelpers.GetObjectValue (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag)) || Operators.ConditionalCompareObjectEqual (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag, string.Empty, TextCompare: false) || Operators.CompareString (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag.ToString (), string.Empty, TextCompare: false) == 0) {
				return;
			}
			My.MyProject.Forms.mdiCFS.mnuFileSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSave.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuFileSaveAs.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrSaveAs.Enabled = true;
		}
		My.MyProject.Forms.mdiCFS.tbrCascade.Enabled = true;
		My.MyProject.Forms.mdiCFS.tbrTileVertical.Enabled = true;
		My.MyProject.Forms.mdiCFS.tbrTileHorizontal.Enabled = true;
		if (CFS.intSctNow > 0) {
			My.MyProject.Forms.mdiCFS.mnuFileNewAnalysis.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrNewAnalysis.Enabled = true;
		}
		My.MyProject.Forms.mdiCFS.mnuFileReportInputs.Enabled = true;
		My.MyProject.Forms.mdiCFS.tbrPrintPreview.Enabled = true;
		My.MyProject.Forms.mdiCFS.mnuFilePrint.Enabled = true;
		My.MyProject.Forms.mdiCFS.tbrPrint.Enabled = true;
		checked {
			short num = (short)(Application.OpenForms.Count - 1);
			for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Application.OpenForms [num2] == My.MyProject.Forms.mdiCFS.ActiveMdiChild) {
					My.MyProject.Forms.mdiCFS.mnuFileClose.Enabled = true;
					break;
				}
			}
		}
	}

	public static void SetMenuEdit ()
	{
		SetMenuUndo (null);
		My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrCut.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditCopyImage.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditInsert.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditInsertRibs.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditRotate.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditRotatePart.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditRotateSection.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditMirror.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditMirrorPart.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditMirrorSection.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditCenterSection.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditCompleteSymmetry.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Visible = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupInsert.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupInsert.Visible = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Visible = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupInsertRibs.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupInsertRibs.Visible = false;
		My.MyProject.Forms.mdiCFS.mnuEditPopupSep1.Visible = false;
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild == null) {
			return;
		}
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmSctPicMaster) {
			if (CFS.intSctNow == 0) {
				return;
			}
			SetMenuUndo (CFS.Sections [CFS.intSctNow]);
			Section section = CFS.Sections [CFS.intSctNow];
			if (!((section.Part [section.iPart].ElemGrid.RowStart == section.Part [section.iPart].ElemGrid.RowEnd) & ((uint)section.Part [section.iPart].ElemGrid.RowStart > (uint)section.Part [section.iPart].nElem))) {
				My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrCut.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditInsert.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupInsert.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = true;
			}
			if (Strings.StrComp (strClipBoard, Clipboard.GetText ()) == 0) {
				if (bytClipBoard == 3) {
					if ((uint)section.nPart < 255u) {
						My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
					}
				} else if (bytClipBoard == 2) {
					My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
				}
			}
			if ((section.Part [section.iPart].ElemGrid.RowStart == section.Part [section.iPart].ElemGrid.RowEnd) & ((uint)section.Part [section.iPart].ElemGrid.RowStart <= (uint)section.Part [section.iPart].nElem)) {
				My.MyProject.Forms.mdiCFS.mnuEditInsertRibs.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupInsertRibs.Enabled = true;
			}
			if (section.nPart > 0) {
				My.MyProject.Forms.mdiCFS.mnuEditRotate.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditRotateSection.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditMirror.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditMirrorSection.Enabled = true;
				if (section.Part [section.iPart].nElem > 0) {
					My.MyProject.Forms.mdiCFS.mnuEditCopyImage.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditMirrorPart.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditRotatePart.Enabled = true;
				}
				if (!section.Part [section.iPart].Closed & (section.Part [section.iPart].nElem > 1)) {
					My.MyProject.Forms.mdiCFS.mnuEditCompleteSymmetry.Enabled = true;
				}
				My.MyProject.Forms.mdiCFS.mnuEditCenterSection.Enabled = true;
			}
			section = null;
			My.MyProject.Forms.mdiCFS.mnuEditPopupInsert.Visible = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Visible = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Visible = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupInsertRibs.Visible = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupSep1.Visible = true;
		} else if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmAnlPicMaster) {
			if (CFS.intAnlNow == 0) {
				return;
			}
			SetMenuUndo (CFS.Analyses [CFS.intAnlNow]);
			Analysis analysis = CFS.Analyses [CFS.intAnlNow];
			switch (CFS.intAnlTabNow) {
			case 1:
				if (!((analysis.BeamGrid.RowStart == analysis.BeamGrid.RowEnd) & ((uint)analysis.BeamGrid.RowStart > (uint)analysis.nBeam))) {
					My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = true;
				}
				break;
			case 2:
				if (!((analysis.SupGrid.RowStart == analysis.SupGrid.RowEnd) & ((uint)analysis.SupGrid.RowStart > (uint)analysis.nSup))) {
					My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = true;
				}
				break;
			case 3:
				if (!((analysis.Ldg [analysis.iLdg].LoadGrid.RowStart == analysis.Ldg [analysis.iLdg].LoadGrid.RowEnd) & ((uint)analysis.Ldg [analysis.iLdg].LoadGrid.RowStart > (uint)analysis.Ldg [analysis.iLdg].nLoad))) {
					My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = true;
				}
				break;
			case 4:
				if (!((analysis.Comb [analysis.iComb].LFGrid.RowStart == analysis.Comb [analysis.iComb].LFGrid.RowEnd) & ((uint)analysis.Comb [analysis.iComb].LFGrid.RowStart > (uint)analysis.Comb [analysis.iComb].nLF))) {
					My.MyProject.Forms.mdiCFS.mnuEditCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditDelete.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCut.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Enabled = true;
				}
				break;
			}
			if (Strings.StrComp (strClipBoard, Clipboard.GetText ()) == 0) {
				switch (CFS.intAnlTabNow) {
				case 1:
					if (bytClipBoard == 5) {
						My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
					}
					break;
				case 2:
					if (bytClipBoard == 6) {
						My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
					}
					break;
				case 3:
					if ((bytClipBoard == 8) | (bytClipBoard == 7)) {
						My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
					}
					break;
				case 4:
					if ((bytClipBoard == 10) | (bytClipBoard == 9)) {
						My.MyProject.Forms.mdiCFS.mnuEditPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.tbrPaste.Enabled = true;
						My.MyProject.Forms.mdiCFS.mnuEditPopupPaste.Enabled = true;
					}
					break;
				}
			}
			if ((analysis.nBeam > 0) | (analysis.nSup > 0)) {
				My.MyProject.Forms.mdiCFS.mnuEditCopyImage.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Enabled = true;
			}
			analysis = null;
			My.MyProject.Forms.mdiCFS.mnuEditPopupDelete.Visible = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupCopyImage.Visible = true;
		} else if (Operators.CompareString (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag.ToString (), string.Empty, TextCompare: false) != 0) {
			My.MyProject.Forms.mdiCFS.mnuEditCopy.Enabled = true;
			My.MyProject.Forms.mdiCFS.tbrCopy.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuEditPopupCopy.Enabled = true;
		}
	}

	public static void SetMenuCompute ()
	{
		My.MyProject.Forms.mdiCFS.mnuToolsSpec.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuToolsBuckling.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeProperties.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrProperties.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeEffProperties.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrEffProperties.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeStrength.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrStrength.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeMemberCheck.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrMemberCheck.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeWebCheck.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrWebCheck.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeTorsionProperties.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeElasticBuckling.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrElasticBuckling.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuComputeDiagrams.Enabled = false;
		My.MyProject.Forms.mdiCFS.tbrDiagrams.Enabled = false;
		My.MyProject.Forms.mdiCFS.mnuCompute.Tag = "0";
		if (My.MyProject.Forms.mdiCFS.ActiveMdiChild == null) {
			My.MyProject.Forms.mdiCFS.mnuToolsSpec.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuToolsBuckling.Enabled = true;
		} else if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmSctPicMaster) {
			My.MyProject.Forms.mdiCFS.mnuToolsSpec.Enabled = true;
			My.MyProject.Forms.mdiCFS.mnuToolsBuckling.Enabled = true;
			if (CFS.intSctNow != 0) {
				My.MyProject.Forms.mdiCFS.mnuComputeProperties.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrProperties.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeEffProperties.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrEffProperties.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeStrength.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrStrength.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeMemberCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrMemberCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeWebCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrWebCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeTorsionProperties.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeElasticBuckling.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrElasticBuckling.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuCompute.Tag = "1";
			}
		} else if (My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmAnlPicMaster) {
			if (CFS.intAnlNow != 0) {
				My.MyProject.Forms.mdiCFS.mnuComputeMemberCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrMemberCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuComputeWebCheck.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrWebCheck.Enabled = true;
				_ = CFS.Analyses [CFS.intAnlNow];
				My.MyProject.Forms.mdiCFS.mnuComputeDiagrams.Enabled = true;
				My.MyProject.Forms.mdiCFS.tbrDiagrams.Enabled = true;
				_ = null;
				My.MyProject.Forms.mdiCFS.mnuCompute.Tag = "2";
			}
		} else {
			if (!(My.MyProject.Forms.mdiCFS.ActiveMdiChild is frmReportMaster) || Information.IsNothing (RuntimeHelpers.GetObjectValue (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag)) || Operators.ConditionalCompareObjectEqual (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag, string.Empty, TextCompare: false)) {
				return;
			}
			short num = Conversions.ToByte (My.MyProject.Forms.mdiCFS.ActiveMdiChild.Tag);
			if (CFS.hdgReport [num].Parent == 1) {
				short num2 = FindSctIndex (num);
				if (num2 > 0) {
					My.MyProject.Forms.mdiCFS.mnuToolsSpec.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuToolsBuckling.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeProperties.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrProperties.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeEffProperties.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrEffProperties.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeStrength.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrStrength.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeMemberCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrMemberCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeWebCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrWebCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeTorsionProperties.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeElasticBuckling.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrElasticBuckling.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuCompute.Tag = "1";
					CFS.intSctNow = num2;
				}
			} else if (CFS.hdgReport [num].Parent == 2) {
				short num2 = FindAnlIndex (num);
				if (num2 > 0) {
					My.MyProject.Forms.mdiCFS.mnuComputeMemberCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrMemberCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeWebCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrWebCheck.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuComputeDiagrams.Enabled = true;
					My.MyProject.Forms.mdiCFS.tbrDiagrams.Enabled = true;
					My.MyProject.Forms.mdiCFS.mnuCompute.Tag = "2";
					CFS.intAnlNow = checked((byte)num2);
				}
			} else if (CFS.hdgReport [num].Parent == 3) {
				My.MyProject.Forms.mdiCFS.mnuToolsSpec.Enabled = true;
				My.MyProject.Forms.mdiCFS.mnuToolsBuckling.Enabled = true;
			}
		}
	}

	public static void SetMenuSpec ()
	{
		if (CFS.SpecYear (CFS.intSpecNow) == 0) {
			CFS.intSpecNow = 37;
		}
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022.Checked = CFS.IsSpec2022 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018.Checked = CFS.IsSpec2018 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016.Checked = CFS.IsSpec2016 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012.Checked = CFS.IsSpec2012 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010.Checked = CFS.IsSpec2010 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007.Checked = CFS.IsSpec2007 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004.Checked = CFS.IsSpec2004 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001.Checked = CFS.IsSpec2001 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec1999.Checked = CFS.IsSpec1999 (CFS.intSpecNow);
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022USASD.Checked = CFS.intSpecNow == 37;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022USLRFD.Checked = CFS.intSpecNow == 38;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022MexicoASD.Checked = CFS.intSpecNow == 39;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022MexicoLRFD.Checked = CFS.intSpecNow == 40;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2022CanadaLSD.Checked = CFS.intSpecNow == 41;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018USASD.Checked = CFS.intSpecNow == 32;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018USLRFD.Checked = CFS.intSpecNow == 33;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018MexicoASD.Checked = CFS.intSpecNow == 34;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018MexicoLRFD.Checked = CFS.intSpecNow == 35;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2018CanadaLSD.Checked = CFS.intSpecNow == 36;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016USASD.Checked = CFS.intSpecNow == 27;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016USLRFD.Checked = CFS.intSpecNow == 28;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016MexicoASD.Checked = CFS.intSpecNow == 29;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016MexicoLRFD.Checked = CFS.intSpecNow == 30;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2016CanadaLSD.Checked = CFS.intSpecNow == 31;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012USASD.Checked = CFS.intSpecNow == 22;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012USLRFD.Checked = CFS.intSpecNow == 23;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012MexicoASD.Checked = CFS.intSpecNow == 24;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012MexicoLRFD.Checked = CFS.intSpecNow == 25;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2012CanadaLSD.Checked = CFS.intSpecNow == 26;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010USASD.Checked = CFS.intSpecNow == 17;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010USLRFD.Checked = CFS.intSpecNow == 18;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010MexicoASD.Checked = CFS.intSpecNow == 19;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010MexicoLRFD.Checked = CFS.intSpecNow == 20;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2010CanadaLSD.Checked = CFS.intSpecNow == 21;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007USASD.Checked = CFS.intSpecNow == 12;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007USLRFD.Checked = CFS.intSpecNow == 13;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007MexicoASD.Checked = CFS.intSpecNow == 14;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007MexicoLRFD.Checked = CFS.intSpecNow == 15;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2007CanadaLSD.Checked = CFS.intSpecNow == 16;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004USASD.Checked = CFS.intSpecNow == 7;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004USLRFD.Checked = CFS.intSpecNow == 8;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004MexicoASD.Checked = CFS.intSpecNow == 9;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004MexicoLRFD.Checked = CFS.intSpecNow == 10;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2004CanadaLSD.Checked = CFS.intSpecNow == 11;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001USASD.Checked = CFS.intSpecNow == 2;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001USLRFD.Checked = CFS.intSpecNow == 3;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001MexicoASD.Checked = CFS.intSpecNow == 4;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001MexicoLRFD.Checked = CFS.intSpecNow == 5;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec2001CanadaLSD.Checked = CFS.intSpecNow == 6;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec1999ASD.Checked = CFS.intSpecNow == 0;
		My.MyProject.Forms.mdiCFS.mnuToolsSpec1999LRFD.Checked = CFS.intSpecNow == 1;
	}

	public static void SetMenuTrace ()
	{
		My.MyProject.Forms.mdiCFS.mnuToolsTraceStrength.Checked = CFS.blnTraceStrength;
		My.MyProject.Forms.mdiCFS.mnuToolsTraceMemberCheck.Checked = CFS.blnTraceMemberChk;
		My.MyProject.Forms.mdiCFS.mnuToolsTraceWebCheck.Checked = CFS.blnTraceWebCrip;
		My.MyProject.Forms.mdiCFS.mnuToolsTraceEffectiveSection.Checked = CFS.blnTraceEffProp;
		My.MyProject.Forms.mdiCFS.mnuToolsTraceColdWork.Checked = CFS.blnTraceColdWork;
		My.MyProject.Forms.mdiCFS.mnuToolsTraceAll.Checked = CFS.blnTraceStrength & CFS.blnTraceMemberChk & CFS.blnTraceWebCrip & CFS.blnTraceEffProp & CFS.blnTraceColdWork;
	}

	public static void SetMenuUndo (object obj)
	{
		if (obj is Section || obj is Analysis) {
			My.MyProject.Forms.mdiCFS.mnuEditUndo.Text = Conversions.ToString (Operators.ConcatenateObject ("&Undo ", NewLateBinding.LateGet (obj, null, "strUndo", new object[0], null, null, null)));
			My.MyProject.Forms.mdiCFS.mnuEditRedo.Text = Conversions.ToString (Operators.ConcatenateObject ("&Redo ", NewLateBinding.LateGet (obj, null, "strRedo", new object[0], null, null, null)));
			My.MyProject.Forms.mdiCFS.mnuEditUndo.Enabled = Operators.ConditionalCompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (obj, null, "strUndo", new object[0], null, null, null), null, "Length", new object[0], null, null, null), 0, TextCompare: false);
			My.MyProject.Forms.mdiCFS.mnuEditRedo.Enabled = Operators.ConditionalCompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (obj, null, "strRedo", new object[0], null, null, null), null, "Length", new object[0], null, null, null), 0, TextCompare: false);
		} else {
			My.MyProject.Forms.mdiCFS.mnuEditUndo.Text = "&Undo";
			My.MyProject.Forms.mdiCFS.mnuEditRedo.Text = "&Redo";
			My.MyProject.Forms.mdiCFS.mnuEditUndo.Enabled = false;
			My.MyProject.Forms.mdiCFS.mnuEditRedo.Enabled = false;
		}
		My.MyProject.Forms.mdiCFS.tbrUndo.Text = My.MyProject.Forms.mdiCFS.mnuEditUndo.Text;
		My.MyProject.Forms.mdiCFS.tbrRedo.Text = My.MyProject.Forms.mdiCFS.mnuEditRedo.Text;
		My.MyProject.Forms.mdiCFS.tbrUndo.Enabled = My.MyProject.Forms.mdiCFS.mnuEditUndo.Enabled;
		My.MyProject.Forms.mdiCFS.tbrRedo.Enabled = My.MyProject.Forms.mdiCFS.mnuEditRedo.Enabled;
	}

	public static void StoreUndoSct (string strText)
	{
		checked {
			short num = (short)(CFS.Sections [CFS.intSctNow].iUndo + 1);
			if (num > 9) {
				num = 9;
				int num2 = 0;
				do {
					CFS.SctUndo [num2, CFS.intSctNow] = CFS.SctUndo [num2 + 1, CFS.intSctNow];
					num2++;
				} while (num2 <= 8);
				CFS.SctUndo [0, CFS.intSctNow].strUndo = string.Empty;
			}
			CFS.SctUndo [num, CFS.intSctNow] = CFS.Sections [CFS.intSctNow].Clone ();
			CFS.Sections [CFS.intSctNow].iUndo = num;
			CFS.Sections [CFS.intSctNow].strUndo = strText;
			CFS.Sections [CFS.intSctNow].strRedo = string.Empty;
			SetMenuUndo (CFS.Sections [CFS.intSctNow]);
			CFS.Sections [CFS.intSctNow].iUndoTab = -1;
			if (CFS.blnSctInpLoaded && My.MyProject.Forms.m_frmSctInp == Form.ActiveForm) {
				CFS.Sections [CFS.intSctNow].iUndoTab = (short)My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex;
			}
		}
	}

	public static void UndoSct ()
	{
		short iUndo = CFS.Sections [CFS.intSctNow].iUndo;
		if (iUndo < 0) {
			return;
		}
		Section[] sections = CFS.Sections;
		int intSctNow;
		object A = sections [intSctNow = CFS.intSctNow];
		Section[,] sctUndo;
		int num;
		int intSctNow2;
		object B = (sctUndo = CFS.SctUndo) [num = iUndo, intSctNow2 = CFS.intSctNow];
		CFS.Swap (ref A, ref B);
		sctUndo [num, intSctNow2] = (Section)B;
		sections [intSctNow] = (Section)A;
		CFS.Sections [CFS.intSctNow].strRedo = CFS.SctUndo [iUndo, CFS.intSctNow].strUndo;
		CFS.Sections [CFS.intSctNow].iRedoTab = CFS.SctUndo [iUndo, CFS.intSctNow].iUndoTab;
		checked {
			CFS.Sections [CFS.intSctNow].iUndo = (short)(iUndo - 1);
			if (CFS.blnSctInpLoaded) {
				CFS.blnRefreshGrdElements = true;
				if ((CFS.Sections [CFS.intSctNow].iRedoTab >= 0) & (CFS.Sections [CFS.intSctNow].iRedoTab != My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex)) {
					My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex = CFS.Sections [CFS.intSctNow].iRedoTab;
				} else {
					RefreshSct (CFS.Sections [CFS.intSctNow]);
				}
				if (My.MyProject.Forms.frmSctInp.ActiveControl.Tag is ControlData) {
					NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.ActiveControl.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				}
			}
			PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			UpdateAnl ((byte)CFS.intSctNow);
			SetMenuEdit ();
		}
	}

	public static void RedoSct ()
	{
		checked {
			short num = (short)(CFS.Sections [CFS.intSctNow].iUndo + 1);
			if (num > 9) {
				return;
			}
			Section[] sections = CFS.Sections;
			int intSctNow;
			object A = sections [intSctNow = CFS.intSctNow];
			Section[,] sctUndo;
			int num2;
			int intSctNow2;
			object B = (sctUndo = CFS.SctUndo) [num2 = num, intSctNow2 = CFS.intSctNow];
			CFS.Swap (ref A, ref B);
			sctUndo [num2, intSctNow2] = (Section)B;
			sections [intSctNow] = (Section)A;
			CFS.Sections [CFS.intSctNow].iUndo = num;
			CFS.Sections [CFS.intSctNow].strUndo = CFS.SctUndo [num, CFS.intSctNow].strRedo;
			CFS.Sections [CFS.intSctNow].iUndoTab = CFS.SctUndo [num, CFS.intSctNow].iRedoTab;
			if (CFS.blnSctInpLoaded) {
				CFS.blnRefreshGrdElements = true;
				if ((CFS.Sections [CFS.intSctNow].iUndoTab >= 0) & (CFS.Sections [CFS.intSctNow].iUndoTab != My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex)) {
					My.MyProject.Forms.frmSctInp.tabSct.SelectedIndex = CFS.Sections [CFS.intSctNow].iUndoTab;
				} else {
					RefreshSct (CFS.Sections [CFS.intSctNow]);
				}
				if (My.MyProject.Forms.frmSctInp.ActiveControl.Tag is ControlData) {
					NewLateBinding.LateSetComplex (My.MyProject.Forms.frmSctInp.ActiveControl.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				}
			}
			PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			UpdateAnl ((byte)CFS.intSctNow);
			SetMenuEdit ();
		}
	}

	public static void StoreUndoAnl (string strText)
	{
		checked {
			short num = (short)(CFS.Analyses [CFS.intAnlNow].iUndo + 1);
			if (num > 9) {
				num = 9;
				int num2 = 0;
				do {
					CFS.AnlUndo [num2, CFS.intAnlNow] = CFS.AnlUndo [num2 + 1, CFS.intAnlNow];
					num2++;
				} while (num2 <= 8);
				CFS.AnlUndo [0, CFS.intAnlNow].strUndo = string.Empty;
			}
			CFS.AnlUndo [num, CFS.intAnlNow] = CFS.Analyses [CFS.intAnlNow].Clone ();
			CFS.Analyses [CFS.intAnlNow].iUndo = num;
			CFS.Analyses [CFS.intAnlNow].strUndo = strText;
			CFS.Analyses [CFS.intAnlNow].strRedo = string.Empty;
			SetMenuUndo (CFS.Analyses [CFS.intAnlNow]);
			CFS.Analyses [CFS.intAnlNow].iUndoTab = -1;
			if (CFS.blnAnlInpLoaded && My.MyProject.Forms.m_frmAnlInp == Form.ActiveForm) {
				CFS.Analyses [CFS.intAnlNow].iUndoTab = (short)My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex;
			}
		}
	}

	public static void UndoAnl ()
	{
		short iUndo = CFS.Analyses [CFS.intAnlNow].iUndo;
		if (iUndo < 0) {
			return;
		}
		Analysis[] analyses = CFS.Analyses;
		int intAnlNow;
		object A = analyses [intAnlNow = CFS.intAnlNow];
		Analysis[,] anlUndo;
		int num;
		int intAnlNow2;
		object B = (anlUndo = CFS.AnlUndo) [num = iUndo, intAnlNow2 = CFS.intAnlNow];
		CFS.Swap (ref A, ref B);
		anlUndo [num, intAnlNow2] = (Analysis)B;
		analyses [intAnlNow] = (Analysis)A;
		CFS.Analyses [CFS.intAnlNow].strRedo = CFS.AnlUndo [iUndo, CFS.intAnlNow].strUndo;
		CFS.Analyses [CFS.intAnlNow].iRedoTab = CFS.AnlUndo [iUndo, CFS.intAnlNow].iUndoTab;
		CFS.Analyses [CFS.intAnlNow].iUndo = checked((short)(iUndo - 1));
		if (CFS.blnAnlInpLoaded) {
			CFS.blnRefreshGrdBeams = true;
			CFS.blnRefreshGrdSupports = true;
			CFS.blnRefreshGrdLoads = true;
			CFS.blnRefreshGrdCombs = true;
			if ((CFS.Analyses [CFS.intAnlNow].iRedoTab >= 0) & (CFS.Analyses [CFS.intAnlNow].iRedoTab != My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex)) {
				My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.Analyses [CFS.intAnlNow].iRedoTab;
			} else {
				RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			}
			if (My.MyProject.Forms.frmAnlInp.ActiveControl.Tag is ControlData) {
				NewLateBinding.LateSetComplex (My.MyProject.Forms.frmAnlInp.ActiveControl.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			}
		}
		PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
		SetMenuEdit ();
	}

	public static void RedoAnl ()
	{
		short num = checked((short)(CFS.Analyses [CFS.intAnlNow].iUndo + 1));
		if (num > 9) {
			return;
		}
		Analysis[] analyses = CFS.Analyses;
		int intAnlNow;
		object A = analyses [intAnlNow = CFS.intAnlNow];
		Analysis[,] anlUndo;
		int num2;
		int intAnlNow2;
		object B = (anlUndo = CFS.AnlUndo) [num2 = num, intAnlNow2 = CFS.intAnlNow];
		CFS.Swap (ref A, ref B);
		anlUndo [num2, intAnlNow2] = (Analysis)B;
		analyses [intAnlNow] = (Analysis)A;
		CFS.Analyses [CFS.intAnlNow].iUndo = num;
		CFS.Analyses [CFS.intAnlNow].strUndo = CFS.AnlUndo [num, CFS.intAnlNow].strRedo;
		CFS.Analyses [CFS.intAnlNow].iUndoTab = CFS.AnlUndo [num, CFS.intAnlNow].iRedoTab;
		if (CFS.blnAnlInpLoaded) {
			CFS.blnRefreshGrdBeams = true;
			CFS.blnRefreshGrdSupports = true;
			CFS.blnRefreshGrdLoads = true;
			CFS.blnRefreshGrdCombs = true;
			if ((CFS.Analyses [CFS.intAnlNow].iUndoTab >= 0) & (CFS.Analyses [CFS.intAnlNow].iUndoTab != My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex)) {
				My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.Analyses [CFS.intAnlNow].iUndoTab;
			} else {
				RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			}
			if (My.MyProject.Forms.frmAnlInp.ActiveControl.Tag is ControlData) {
				NewLateBinding.LateSetComplex (My.MyProject.Forms.frmAnlInp.ActiveControl.Tag, null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			}
		}
		PlotAnl (CFS.frmAnlPic [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow]);
		SetMenuEdit ();
	}

	public static void CloseAll ()
	{
		checked {
			short num = (short)Information.UBound (CFS.hdgAnlPic);
			short num2 = 1;
			while (true) {
				if (num2 <= num) {
					if (!CFS.hdgAnlPic [num2].Deleted) {
						CFS.frmAnlPic [num2].Close ();
					}
					if (CFS.hdgAnlPic [num2].Deleted) {
						num2 = (short)unchecked(num2 + 1);
						continue;
					}
					break;
				}
				short num3 = (short)Information.UBound (CFS.hdgSctPic);
				num2 = 1;
				while (true) {
					if (num2 <= num3) {
						if (!CFS.hdgSctPic [num2].Deleted) {
							CFS.frmSctPic [num2].Close ();
						}
						if (CFS.hdgSctPic [num2].Deleted) {
							num2 = (short)unchecked(num2 + 1);
							continue;
						}
						break;
					}
					short num4 = (short)Information.UBound (CFS.hdgReport);
					for (num2 = 1; num2 <= num4; num2 = (short)unchecked(num2 + 1)) {
						if (!CFS.hdgReport [num2].Deleted && FindSctIndex (Conversions.ToShort (CFS.frmReport [num2].Tag)) == 0) {
							CFS.frmReport [num2].Close ();
						}
					}
					break;
				}
				break;
			}
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void GenerateSections ()
	{
		string strMsg = string.Empty;
		MaterialType material = GetMaterial ("A1003 ST Grade 33H");
		short intSctNow = CFS.intSctNow;
		CFS.intSctNow = NewSctIndex ();
		int num = FileSystem.FreeFile ();
		FileSystem.FileOpen (num, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-NS33.txt", OpenMode.Input, OpenAccess.Read);
		int num2 = FileSystem.FreeFile ();
		FileSystem.FileOpen (num2, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-NS33DSM3.txt", OpenMode.Output);
		FileSystem.LineInput (num);
		bool blnChg = default(bool);
		while (!FileSystem.EOF (num)) {
			string[] array = FileSystem.LineInput (num).Split ("\t".ToCharArray ());
			if (array.Length >= 7) {
				string text = array [0];
				float num3 = (float)Conversion.Val (array [1]);
				float num4 = (float)Conversion.Val (array [2]);
				float num5 = (float)Conversion.Val (array [3]);
				float hole = (float)Conversion.Val (array [4]);
				float num6 = (float)Conversion.Val (array [5]);
				float thickness = (float)Conversion.Val (array [6]);
				Section section = CFS.Sections [CFS.intSctNow];
				section.Initialize ();
				section.Filename = "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\Non-Structural Studs 33 ksi\\" + text + ".cfss";
				section.Description = text + ", " + Conversions.ToString (material.Fy [2]) + " ksi Stud";
				section.Project = "SFIA Library";
				section.Material = material;
				section.ColdWork = true;
				section.Reserve = false;
				section.HoleLength = 4.5f;
				section.HoleSpacing = 24f;
				section.DSM.UseDSM = false;
				section.DSM.PreQualified = true;
				section.nPart = 1;
				Part part = section.Part [section.nPart];
				part.Initialize (10);
				part.Name = "Stud";
				part.Thickness = thickness;
				part.DefRad = num6;
				part.Centerline = false;
				part.Closed = false;
				if (num5 == 0f) {
					part.nElem = 3;
					part.Element [1].Len = num4;
					part.Element [1].Ang = (float)System.Math.PI;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 2;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num4 / 2f;
					part.Element [2].Len = num3;
					part.Element [2].Ang = (float)System.Math.PI / 2f;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 5;
					part.Element [2].Hole = hole;
					part.Element [2].Dist = num3 / 2f;
					part.Element [3].Len = num4;
					part.Element [3].Ang = 0f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 2;
					part.Element [3].Hole = 0f;
					part.Element [3].Dist = num4 / 2f;
				} else {
					part.nElem = 5;
					part.Element [1].Len = num5;
					part.Element [1].Ang = 4.712389f;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 1;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num5 / 2f;
					part.Element [2].Len = num4;
					part.Element [2].Ang = (float)System.Math.PI;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 2;
					part.Element [2].Hole = 0f;
					part.Element [2].Dist = num4 / 2f;
					part.Element [3].Len = num3;
					part.Element [3].Ang = (float)System.Math.PI / 2f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 5;
					part.Element [3].Hole = hole;
					part.Element [3].Dist = num3 / 2f;
					part.Element [4].Len = num4;
					part.Element [4].Ang = 0f;
					part.Element [4].Rad = num6;
					part.Element [4].Web = 2;
					part.Element [4].Hole = 0f;
					part.Element [4].Dist = num4 / 2f;
					part.Element [5].Len = num5;
					part.Element [5].Ang = -(float)System.Math.PI / 2f;
					part.Element [5].Rad = num6;
					part.Element [5].Web = 1;
					part.Element [5].Hole = 0f;
					part.Element [5].Dist = num5 / 2f;
				}
				part.Geometry (ref blnChg, ref strMsg);
				part = null;
				section = null;
				My.MyProject.Forms.frmSctInp.cmdDSM_Click (null, null);
				CFS.Sections [CFS.intSctNow].RevDate = new DateTime (637669431600000000L);
				CFS.Sections [CFS.intSctNow].RevBy = "RSG Software";
				ref Section.DSMType dSM = ref CFS.Sections [CFS.intSctNow].DSM;
				FileSystem.PrintLine (num2, text + "\t" + Conversions.ToString (dSM.Pcrl) + "\t" + Conversions.ToString (dSM.Pcrd) + "\t" + Conversions.ToString (dSM.Mcrlxp) + "\t" + Conversions.ToString (dSM.Mcrdxp) + "\t" + Conversions.ToString (dSM.Mcrlxn) + "\t" + Conversions.ToString (dSM.Mcrdxn) + "\t" + Conversions.ToString (dSM.Mcrlyp) + "\t" + Conversions.ToString (dSM.Mcrdyp) + "\t" + Conversions.ToString (dSM.Mcrlyn) + "\t" + Conversions.ToString (dSM.Mcrdyn));
				if ("C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\Non-Structural Studs 33 ksi\\".Length > 0) {
					CFS.Sections [CFS.intSctNow].Save (ref strMsg);
				}
			}
		}
		FileSystem.FileClose (num);
		FileSystem.FileClose (num2);
		CFS.intSctNow = intSctNow;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void GenerateMnd ()
	{
		string strMsg = string.Empty;
		MaterialType material = GetMaterial ("A1003 ST Grade 50H");
		short intSctNow = CFS.intSctNow;
		CFS.intSctNow = NewSctIndex ();
		int num = FileSystem.FreeFile ();
		FileSystem.FileOpen (num, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-SS50.txt", OpenMode.Input, OpenAccess.Read);
		int num2 = FileSystem.FreeFile ();
		FileSystem.FileOpen (num2, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-SS50Mnd24.txt", OpenMode.Output);
		FileSystem.LineInput (num);
		bool blnChg = default(bool);
		while (!FileSystem.EOF (num)) {
			string[] array = FileSystem.LineInput (num).Split ("\t".ToCharArray ());
			if (array.Length >= 7) {
				string text = array [0];
				float num3 = (float)Conversion.Val (array [1]);
				float num4 = (float)Conversion.Val (array [2]);
				float num5 = (float)Conversion.Val (array [3]);
				float hole = (float)Conversion.Val (array [4]);
				float num6 = (float)Conversion.Val (array [5]);
				float num7 = (float)Conversion.Val (array [6]);
				Section section = CFS.Sections [CFS.intSctNow];
				section.Initialize ();
				section.Filename = text + ".cfss";
				section.Description = text + ", " + Conversions.ToString (material.Fy [2]) + " ksi Stud";
				section.Project = "SFIA Calculation";
				section.Material = material;
				section.ColdWork = false;
				section.Reserve = false;
				section.HoleLength = 4.5f;
				section.HoleSpacing = 24f;
				section.DSM.UseDSM = false;
				section.DSM.PreQualified = true;
				section.nPart = 1;
				Part part = section.Part [section.nPart];
				part.Initialize (10);
				part.Name = "Stud";
				part.Thickness = num7;
				part.DefRad = num6;
				part.Centerline = false;
				part.Closed = false;
				if (num5 == 0f) {
					part.nElem = 3;
					part.Element [1].Len = num4;
					part.Element [1].Ang = (float)System.Math.PI;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 2;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num4 / 2f;
					part.Element [2].Len = num3;
					part.Element [2].Ang = (float)System.Math.PI / 2f;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 5;
					part.Element [2].Hole = hole;
					part.Element [2].Dist = num3 / 2f;
					part.Element [3].Len = num4;
					part.Element [3].Ang = 0f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 2;
					part.Element [3].Hole = 0f;
					part.Element [3].Dist = num4 / 2f;
				} else {
					part.nElem = 5;
					part.Element [1].Len = num5;
					part.Element [1].Ang = 4.712389f;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 1;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num5 / 2f;
					part.Element [2].Len = num4;
					part.Element [2].Ang = (float)System.Math.PI;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 2;
					part.Element [2].Hole = 0f;
					part.Element [2].Dist = num4 / 2f;
					part.Element [3].Len = num3;
					part.Element [3].Ang = (float)System.Math.PI / 2f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 5;
					part.Element [3].Hole = hole;
					part.Element [3].Dist = num3 / 2f;
					part.Element [4].Len = num4;
					part.Element [4].Ang = 0f;
					part.Element [4].Rad = num6;
					part.Element [4].Web = 2;
					part.Element [4].Hole = 0f;
					part.Element [4].Dist = num4 / 2f;
					part.Element [5].Len = num5;
					part.Element [5].Ang = -(float)System.Math.PI / 2f;
					part.Element [5].Rad = num6;
					part.Element [5].Web = 1;
					part.Element [5].Hole = 0f;
					part.Element [5].Dist = num5 / 2f;
				}
				part.Geometry (ref blnChg, ref strMsg);
				part = null;
				section = null;
				float num8 = CFS.Sections [CFS.intSctNow].DesignFy (StressDirections.dirLC, Specifications.spc2016USASD);
				MemberParameters param = new MemberParameters (Specifications.spc2016USASD);
				Section section2 = CFS.Sections [CFS.intSctNow];
				section2.CalcProperties (ref strMsg);
				float num9 = section2.Prop.Sx * num8;
				float num10 = section2.Prop.Sxn * num8;
				section2.CalcStrength (27);
				float mnxop = section2.Strength.Mnxop;
				param.Lm = 240f;
				param.iBrcFlg = Flanges.flgTop;
				param.Kf = (float)(0.5 * (0.00035 * (double)section2.Material.Eo [2] * (double)num7 * (double)num7 + 0.075));
				float num11 = section2.DistortionalBucklingMoment (param, 2);
				float num12 = (float)System.Math.Sqrt (num9 / num11);
				float num13 = (float)(0.673 * System.Math.Pow (num10 / num9, 3.0));
				float num14 = (float)(0.673 * (1.7 * System.Math.Pow (num9 / num10, 2.7) - 0.7));
				float num15 = (float)((1.0 - 0.22 / (double)num14) / (double)num14 * (double)num9);
				float num16 = ((num12 <= num13) ? num10 : ((!(num12 <= num14)) ? ((float)((1.0 - 0.22 / (double)num12) / (double)num12 * (double)num9)) : (num10 - (num10 - num15) * (num12 - num13) / (num14 - num13))));
				section2 = null;
				FileSystem.PrintLine (num2, text + "\t" + Conversions.ToString (num8) + "\t" + Conversions.ToString (num10) + "\t" + Conversions.ToString (mnxop) + "\t" + Conversions.ToString (param.Lm) + "\t" + Conversions.ToString (param.Kf) + "\t" + Conversions.ToString (num11) + "\t" + Conversions.ToString (num16));
			}
		}
		FileSystem.FileClose (num);
		FileSystem.FileClose (num2);
		CFS.intSctNow = intSctNow;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void GenerateMnl ()
	{
		string strMsg = string.Empty;
		MaterialType material = GetMaterial ("A1003 ST Grade 50H");
		short intSctNow = CFS.intSctNow;
		CFS.intSctNow = NewSctIndex ();
		int num = FileSystem.FreeFile ();
		FileSystem.FileOpen (num, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-ST50.txt", OpenMode.Input, OpenAccess.Read);
		int num2 = FileSystem.FreeFile ();
		FileSystem.FileOpen (num2, "C:\\Users\\User\\Documents\\Visual Studio 2015\\Projects\\CFS\\Libraries\\SFIA\\SFIA-ST50EWMy.txt", OpenMode.Output);
		FileSystem.LineInput (num);
		bool blnChg = default(bool);
		while (!FileSystem.EOF (num)) {
			string[] array = FileSystem.LineInput (num).Split ("\t".ToCharArray ());
			if (array.Length >= 7) {
				string text = array [0];
				float num3 = (float)Conversion.Val (array [1]);
				float num4 = (float)Conversion.Val (array [2]);
				float num5 = (float)Conversion.Val (array [3]);
				float hole = (float)Conversion.Val (array [4]);
				float num6 = (float)Conversion.Val (array [5]);
				float thickness = (float)Conversion.Val (array [6]);
				Section section = CFS.Sections [CFS.intSctNow];
				section.Initialize ();
				section.Filename = text + ".cfss";
				section.Description = text + ", " + Conversions.ToString (material.Fy [2]) + " ksi Stud";
				section.Project = "SFIA Library";
				section.Material = material;
				section.ColdWork = false;
				section.Reserve = false;
				section.HoleLength = 4.5f;
				section.HoleSpacing = 24f;
				section.DSM.UseDSM = false;
				section.DSM.PreQualified = true;
				section.nPart = 1;
				Part part = section.Part [section.nPart];
				part.Initialize (10);
				part.Name = "Stud";
				part.Thickness = thickness;
				part.DefRad = num6;
				part.Centerline = false;
				part.Closed = false;
				if (num5 == 0f) {
					part.nElem = 3;
					part.Element [1].Len = num4;
					part.Element [1].Ang = (float)System.Math.PI;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 2;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num4 / 2f;
					part.Element [2].Len = num3;
					part.Element [2].Ang = (float)System.Math.PI / 2f;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 5;
					part.Element [2].Hole = hole;
					part.Element [2].Dist = num3 / 2f;
					part.Element [3].Len = num4;
					part.Element [3].Ang = 0f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 2;
					part.Element [3].Hole = 0f;
					part.Element [3].Dist = num4 / 2f;
				} else {
					part.nElem = 5;
					part.Element [1].Len = num5;
					part.Element [1].Ang = 4.712389f;
					part.Element [1].Rad = num6;
					part.Element [1].Web = 1;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num5 / 2f;
					part.Element [2].Len = num4;
					part.Element [2].Ang = (float)System.Math.PI;
					part.Element [2].Rad = num6;
					part.Element [2].Web = 2;
					part.Element [2].Hole = 0f;
					part.Element [2].Dist = num4 / 2f;
					part.Element [3].Len = num3;
					part.Element [3].Ang = (float)System.Math.PI / 2f;
					part.Element [3].Rad = num6;
					part.Element [3].Web = 5;
					part.Element [3].Hole = hole;
					part.Element [3].Dist = num3 / 2f;
					part.Element [4].Len = num4;
					part.Element [4].Ang = 0f;
					part.Element [4].Rad = num6;
					part.Element [4].Web = 2;
					part.Element [4].Hole = 0f;
					part.Element [4].Dist = num4 / 2f;
					part.Element [5].Len = num5;
					part.Element [5].Ang = -(float)System.Math.PI / 2f;
					part.Element [5].Rad = num6;
					part.Element [5].Web = 1;
					part.Element [5].Hole = 0f;
					part.Element [5].Dist = num5 / 2f;
				}
				part.Geometry (ref blnChg, ref strMsg);
				part = null;
				section = null;
				Section section2 = CFS.Sections [CFS.intSctNow];
				section2.CalcProperties (ref strMsg, blnCheckLicense: false);
				float syln = section2.Prop.Syln;
				float syrn = section2.Prop.Syrn;
				float num7 = section2.Prop.Syn * section2.DesignFy (StressDirections.dirLC, Specifications.spc2016USASD);
				section2.CalcStrength (27);
				float mnyop = section2.Strength.Mnyop;
				float mnyon = section2.Strength.Mnyon;
				section2 = null;
				FileSystem.PrintLine (num2, text + "\t" + Conversions.ToString (num7) + "\t" + Conversions.ToString (mnyop) + "\t" + Conversions.ToString (mnyon) + "\t" + Conversions.ToString (syln) + "\t" + Conversions.ToString (syrn));
			}
		}
		FileSystem.FileClose (num);
		FileSystem.FileClose (num2);
		CFS.intSctNow = intSctNow;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public static void GenerateBCData ()
	{
		string strMsg = string.Empty;
		MaterialType material = GetMaterial ("A1003 ST Grade 50H");
		short intSctNow = CFS.intSctNow;
		CFS.intSctNow = NewSctIndex ();
		int num = FileSystem.FreeFile ();
		FileSystem.FileOpen (num, "C:\\Users\\User\\Documents\\CFS\\AISI\\Projects\\DSM Local Buckling\\BCD Inputs.txt", OpenMode.Input, OpenAccess.Read);
		int num2 = FileSystem.FreeFile ();
		FileSystem.FileOpen (num2, "C:\\Users\\User\\Documents\\CFS\\AISI\\Projects\\DSM Local Buckling\\BCD Outputs.txt", OpenMode.Output);
		FileSystem.LineInput (num);
		FileSystem.PrintLine (num2, "Index\tSpecimen\tθMM\tϕPM\tβy\tβp\tks1\tks2\tβp/βy\tβs1\tβs2\tβs");
		bool blnChg = default(bool);
		while (!FileSystem.EOF (num)) {
			string[] array = FileSystem.LineInput (num).Split ("\t".ToCharArray ());
			if (array.Length >= 11) {
				int num3 = checked((int)System.Math.Round (Conversion.Val (array [0])));
				string text = array [1];
				string text2 = array [2];
				float num4 = (float)Conversion.Val (array [3]);
				float num5 = (float)Conversion.Val (array [4]);
				float num6 = (float)Conversion.Val (array [5]);
				float thickness = (float)Conversion.Val (array [6]);
				float num7 = (float)Conversion.Val (array [7]);
				float num8 = (float)Conversion.Val (array [8]);
				float num9 = (float)Conversion.Val (array [9]);
				float num10 = (float)Conversion.Val (array [10]);
				Section section = CFS.Sections [CFS.intSctNow];
				section.Initialize ();
				section.Filename = text + ".cfss";
				section.Description = text + ", " + Conversions.ToString (material.Fy [2]) + " ksi " + text2;
				section.Project = "Beam-Column Prediction";
				section.Material = material;
				section.nPart = 1;
				Part part = section.Part [section.nPart];
				part.Initialize (10);
				part.Name = text2;
				part.Thickness = thickness;
				part.DefRad = num7;
				part.Centerline = false;
				part.Closed = false;
				if (num6 == 0f) {
					part.nElem = 3;
					part.Element [1].Len = num5;
					part.Element [1].Ang = (float)System.Math.PI;
					part.Element [1].Rad = num7;
					part.Element [1].Web = 2;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num5 / 2f;
					part.Element [2].Len = num4;
					part.Element [2].Ang = (float)System.Math.PI / 2f;
					part.Element [2].Rad = num7;
					part.Element [2].Web = 5;
					part.Element [2].Hole = 0f;
					part.Element [2].Dist = num4 / 2f;
					part.Element [3].Len = num5;
					part.Element [3].Ang = 0f;
					part.Element [3].Rad = num7;
					part.Element [3].Web = 2;
					part.Element [3].Hole = 0f;
					part.Element [3].Dist = num5 / 2f;
					if (Operators.CompareString (text2, "Z", TextCompare: false) == 0) {
						part.Element [1].Ang = 0f;
						part.Element [2].Web = 6;
					}
				} else {
					part.nElem = 5;
					part.Element [1].Len = num6;
					part.Element [1].Ang = 4.712389f;
					part.Element [1].Rad = num7;
					part.Element [1].Web = 1;
					part.Element [1].Hole = 0f;
					part.Element [1].Dist = num6 / 2f;
					part.Element [2].Len = num5;
					part.Element [2].Ang = (float)System.Math.PI;
					part.Element [2].Rad = num7;
					part.Element [2].Web = 2;
					part.Element [2].Hole = 0f;
					part.Element [2].Dist = num5 / 2f;
					part.Element [3].Len = num4;
					part.Element [3].Ang = (float)System.Math.PI / 2f;
					part.Element [3].Rad = num7;
					part.Element [3].Web = 5;
					part.Element [3].Hole = 0f;
					part.Element [3].Dist = num4 / 2f;
					part.Element [4].Len = num5;
					part.Element [4].Ang = 0f;
					part.Element [4].Rad = num7;
					part.Element [4].Web = 2;
					part.Element [4].Hole = 0f;
					part.Element [4].Dist = num5 / 2f;
					part.Element [5].Len = num6;
					part.Element [5].Ang = -(float)System.Math.PI / 2f;
					part.Element [5].Rad = num7;
					part.Element [5].Web = 1;
					part.Element [5].Hole = 0f;
					part.Element [5].Dist = num6 / 2f;
					if (Operators.CompareString (text2, "Z", TextCompare: false) == 0) {
						part.Element [1].Ang = -0.87266463f;
						part.Element [2].Ang = 0f;
						part.Element [5].Ang = -0.87266463f;
						part.Element [3].Web = 6;
					}
					if (Operators.CompareString (text2, "H", TextCompare: false) == 0) {
						part.Element [1].Ang = (float)System.Math.PI / 2f;
						part.Element [5].Ang = (float)System.Math.PI / 2f;
						part.Element [3].Web = 7;
					}
				}
				part.Geometry (ref blnChg, ref strMsg);
				part = null;
				section = null;
				Section section2 = CFS.Sections [CFS.intSctNow];
				section2.CalcProperties (ref strMsg, blnCheckLicense: false);
				section2.Rotate (-1f * section2.Prop.Alpha);
				section2.CalcProperties (ref strMsg, blnCheckLicense: false);
				float num11 = section2.Prop.A * 50f;
				float num12 = section2.Prop.Sx * 50f;
				float num13 = section2.Prop.Sy * 50f;
				float num14 = section2.Prop.Zx * 50f;
				float num15 = section2.Prop.Zy * 50f;
				float num16 = (float)System.Math.Sqrt (System.Math.Pow (num8 / num11, 2.0) + System.Math.Pow (num9 / num12, 2.0) + System.Math.Pow (num10 / num13, 2.0));
				float num17 = (float)System.Math.Atan2 (num10 / num13, num9 / num12);
				float num18 = (float)System.Math.Acos (num8 / num11 / num16);
				section2.PlasticSurface ();
				float num19 = section2.BetaY (num8, num9, num10);
				float num20 = section2.BetaP (num8, num9, num10);
				float num21 = section2.BetaS (num8, num9, num10);
				float num22 = 2f / (1f + section2.Prop.Sxt / section2.Prop.Sxb);
				if (num9 < 0f) {
					num22 = 2f - num22;
				}
				float num23 = 2f / (1f + section2.Prop.Syr / section2.Prop.Syl);
				if (num10 < 0f) {
					num23 = 2f - num23;
				}
				section2 = null;
				FileSystem.PrintLine (num2, Conversions.ToString (num3) + "\t" + text + "\t" + Conversions.ToString ((double)(num17 * 180f) / System.Math.PI) + "\t" + Conversions.ToString ((double)(num18 * 180f) / System.Math.PI) + "\t" + Conversions.ToString (num19) + "\t" + Conversions.ToString (num20) + "\t" + Conversions.ToString (num14 / num12) + "\t" + Conversions.ToString (num15 / num13) + "\t" + Conversions.ToString (num20 / num19) + "\t" + Conversions.ToString (num22) + "\t" + Conversions.ToString (num23) + "\t" + Conversions.ToString (num21));
			}
			if ("".Length > 0) {
				CFS.Sections [CFS.intSctNow].Save (ref strMsg);
			}
		}
		FileSystem.FileClose (num);
		FileSystem.FileClose (num2);
		CFS.intSctNow = intSctNow;
	}
}
