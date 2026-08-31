// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

[StandardModule]
internal sealed class Units
{
	public enum UnitTypes
	{
		NoUnit = 0,
		Len1Unit = 1,
		LengthUnit = 2,
		AngleUnit = 3,
		ForceUnit = 4,
		StressUnit = 5,
		MomentUnit = 6,
		Len2Unit = 7,
		Len3Unit = 8,
		Len4Unit = 9,
		Len6Unit = 10,
		LoadUnit = 11,
		TorqueUnit = 12,
		BimomentUnit = 13,
		TorqueLoadUnit = 14,
		StringOnly = 255
	}

	public struct UnitSystem
	{
		public string Name;

		public byte[] UnitIndex;
	}

	public struct Unit
	{
		public string Name;

		public float Mult;

		public Unit (string strName, float sngMult)
		{
			this = default(Unit);
			Name = strName;
			Mult = sngMult;
		}
	}

	public static Unit[] untNone = new Unit[2];

	public static Unit[] untLength = new Unit[6];

	public static Unit[] untAngle = new Unit[4];

	public static Unit[] untForce = new Unit[7];

	public static Unit[] untStress = new Unit[12];

	public static Unit[] untMoment = new Unit[12];

	public static Unit[] untLen2 = new Unit[6];

	public static Unit[] untLen3 = new Unit[6];

	public static Unit[] untLen4 = new Unit[6];

	public static Unit[] untLen6 = new Unit[6];

	public static Unit[] untLoad = new Unit[12];

	public static Unit[] untTorque = new Unit[7];

	public static Unit[] untBimoment = new Unit[7];

	public static Unit[] untTorqueLoad = new Unit[7];

	public const int UNIT_US = 1;

	public const int UNIT_METRIC = 2;

	public const int UNIT_CUSTOM = 3;

	public static byte[] DefaultUnitIndex = new byte[15];

	public static UnitSystem[] UnitSys = new UnitSystem[4];

	public static byte iUnitSys;

	public static string[] Fmt = new string[14];

	public static void InitializeFormats ()
	{
		Fmt [0] = "0";
		Fmt [1] = "0";
		Fmt [2] = "0";
		Fmt [3] = "0";
		Fmt [4] = "0";
		Fmt [5] = "0.0";
		Fmt [6] = "0.00";
		Fmt [7] = "0.000";
		Fmt [8] = "0.0000";
		Fmt [9] = "0.00000";
		Fmt [10] = "0.000000";
		Fmt [11] = "0.0000000";
		Fmt [12] = "0.00000000";
		Fmt [13] = "0.0000e-00";
	}

	public static void InitializeUnits ()
	{
		UnitSys [1].Name = "U.S.";
		UnitSys [2].Name = "Metric";
		UnitSys [3].Name = "Custom";
		UnitSys [1].UnitIndex = new byte[7];
		UnitSys [2].UnitIndex = new byte[7];
		UnitSys [3].UnitIndex = new byte[7];
		untNone [1].Name = string.Empty;
		untNone [1].Mult = 1f;
		UnitSys [1].UnitIndex [0] = 1;
		UnitSys [2].UnitIndex [0] = 1;
		untLength [1] = new Unit ("in", 1f);
		untLength [2] = new Unit ("ft", 1f / 12f);
		untLength [3] = new Unit ("mm", 25.4f);
		untLength [4] = new Unit ("cm", 2.54f);
		untLength [5] = new Unit ("m", 0.0254f);
		UnitSys [1].UnitIndex [1] = 1;
		UnitSys [2].UnitIndex [1] = 3;
		UnitSys [1].UnitIndex [2] = 2;
		UnitSys [2].UnitIndex [2] = 5;
		checked {
			short num = (short)Information.UBound (untLength);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				untLen2 [num2].Name = untLength [num2].Name + "²";
				untLen2 [num2].Mult = (float)System.Math.Pow (untLength [num2].Mult, 2.0);
				untLen3 [num2].Name = untLength [num2].Name + "³";
				untLen3 [num2].Mult = (float)System.Math.Pow (untLength [num2].Mult, 3.0);
				untLen4 [num2].Name = untLength [num2].Name + "⁴";
				untLen4 [num2].Mult = (float)System.Math.Pow (untLength [num2].Mult, 4.0);
				untLen6 [num2].Name = untLength [num2].Name + "⁶";
				untLen6 [num2].Mult = (float)System.Math.Pow (untLength [num2].Mult, 6.0);
			}
			untForce [1] = new Unit ("lb", 1000f);
			untForce [2] = new Unit ("k", 1f);
			untForce [3] = new Unit ("N", 4448.221f);
			untForce [4] = new Unit ("kN", 4.448221f);
			untForce [5] = new Unit ("kgf", 453.592377f);
			untForce [6] = new Unit ("tonne", 0.45359236f);
			UnitSys [1].UnitIndex [4] = 2;
			UnitSys [2].UnitIndex [4] = 4;
			untAngle [1] = new Unit ("deg", 57.29578f);
			untAngle [2] = new Unit ("rad", 1f);
			untAngle [3] = new Unit ("grad", 200f / (float)System.Math.PI);
			UnitSys [1].UnitIndex [3] = 1;
			UnitSys [2].UnitIndex [3] = 1;
			untStress [1] = new Unit ("psi", 1000f);
			untStress [2] = new Unit ("ksi", 1f);
			untStress [3] = new Unit ("psf", 144000f);
			untStress [4] = new Unit ("ksf", 144f);
			untStress [5] = new Unit ("Pa", 6894757f);
			untStress [6] = new Unit ("kPa", 6894.757f);
			untStress [7] = new Unit ("MPa", 6.894757f);
			untStress [8] = new Unit ("GPa", 0.006894757f);
			untStress [9] = new Unit ("kgf/mm²", 0.703069568f);
			untStress [10] = new Unit ("kgf/m²", 703069.563f);
			untStress [11] = new Unit ("tonne/m²", 703.0696f);
			UnitSys [1].UnitIndex [5] = 2;
			UnitSys [2].UnitIndex [5] = 7;
			untMoment [1] = new Unit ("lb-in", 1000f);
			untMoment [2] = new Unit ("lb-ft", 83.3333359f);
			untMoment [3] = new Unit ("k-in", 1f);
			untMoment [4] = new Unit ("k-ft", 1f / 12f);
			untMoment [5] = new Unit ("N-mm", 112984.82f);
			untMoment [6] = new Unit ("N-m", 112.984825f);
			untMoment [7] = new Unit ("kN-mm", 112.984825f);
			untMoment [8] = new Unit ("kN-m", 0.112984821f);
			untMoment [9] = new Unit ("kgf-mm", 11521.2461f);
			untMoment [10] = new Unit ("kgf-m", 11.521246f);
			untMoment [11] = new Unit ("tonne-m", 0.0115212463f);
			UnitSys [1].UnitIndex [6] = 3;
			UnitSys [2].UnitIndex [6] = 8;
			untLoad [1] = new Unit ("lb/in", 1000f);
			untLoad [2] = new Unit ("lb/ft", 12000f);
			untLoad [3] = new Unit ("k/in", 1f);
			untLoad [4] = new Unit ("k/ft", 12f);
			untLoad [5] = new Unit ("N/mm", 175.126831f);
			untLoad [6] = new Unit ("N/m", 175126.828f);
			untLoad [7] = new Unit ("kN/mm", 0.175126821f);
			untLoad [8] = new Unit ("kN/m", 175.126831f);
			untLoad [9] = new Unit ("kgf/mm", 17.8579674f);
			untLoad [10] = new Unit ("kgf/m", 17857.9668f);
			untLoad [11] = new Unit ("tonne/m", 17.8579674f);
			untTorque [1] = new Unit ("lb-in", 1000f);
			untTorque [2] = new Unit ("k-in", 1f);
			untTorque [3] = new Unit ("N-mm", 112984.82f);
			untTorque [4] = new Unit ("kN-mm", 112.984825f);
			untTorque [5] = new Unit ("kgf-mm", 11521.2461f);
			untTorque [6] = new Unit ("tonne-mm", 11.521246f);
			untBimoment [1] = new Unit ("lb-in²", 1000f);
			untBimoment [2] = new Unit ("k-in²", 1f);
			untBimoment [3] = new Unit ("N-mm²", 2869814.5f);
			untBimoment [4] = new Unit ("kN-mm²", 2869.81445f);
			untBimoment [5] = new Unit ("kgf-mm²", 292639.656f);
			untBimoment [6] = new Unit ("tonne-mm²", 292.639648f);
			untTorqueLoad [1] = new Unit ("lb-in/ft", 12000f);
			untTorqueLoad [2] = new Unit ("k-in/ft", 12f);
			untTorqueLoad [3] = new Unit ("N-mm/m", 1.39745E+07f / (float)System.Math.PI);
			untTorqueLoad [4] = new Unit ("kN-mm/m", 4448.221f);
			untTorqueLoad [5] = new Unit ("kgf-mm/m", 453592.375f);
			untTorqueLoad [6] = new Unit ("tonne-mm/m", 453.592377f);
		}
	}

	public static short FmtIndex (float X)
	{
		short num = (short)((X != 0f) ? checked((short)System.Math.Round (8.0 - Conversion.Int (System.Math.Log10 (System.Math.Abs (X))))) : 8);
		if ((num < Information.LBound (Fmt)) | (num > Information.UBound (Fmt))) {
			num = checked((short)Information.UBound (Fmt));
		}
		return num;
	}

	public static float ConvertValue (float Value, UnitTypes bytUnitType, byte bytIndex = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [(int)bytUnitType];
		}
		return bytUnitType switch {
			UnitTypes.NoUnit => Value * untNone [bytIndex].Mult, 
			UnitTypes.LengthUnit => Value * untLength [bytIndex].Mult, 
			UnitTypes.Len1Unit => Value * untLength [bytIndex].Mult, 
			UnitTypes.Len2Unit => Value * untLen2 [bytIndex].Mult, 
			UnitTypes.Len3Unit => Value * untLen3 [bytIndex].Mult, 
			UnitTypes.Len4Unit => Value * untLen4 [bytIndex].Mult, 
			UnitTypes.Len6Unit => Value * untLen6 [bytIndex].Mult, 
			UnitTypes.AngleUnit => Value * untAngle [bytIndex].Mult, 
			UnitTypes.ForceUnit => Value * untForce [bytIndex].Mult, 
			UnitTypes.StressUnit => Value * untStress [bytIndex].Mult, 
			UnitTypes.MomentUnit => Value * untMoment [bytIndex].Mult, 
			UnitTypes.LoadUnit => Value * untLoad [bytIndex].Mult, 
			_ => Value, 
		};
	}

	public static string DisplayNone (float sngValue, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		return DisplayValue (sngValue, untNone [DefaultUnitIndex [0]], blnShowUnit: false, strFmt, intLPad, intRPad);
	}

	public static string DisplayLength (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [2];
		}
		return DisplayValue (sngValue, untLength [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLen1 (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [1];
		}
		return DisplayValue (sngValue, untLength [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLen2 (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [7];
		}
		return DisplayValue (sngValue, untLen2 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLen3 (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [8];
		}
		return DisplayValue (sngValue, untLen3 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLen4 (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [9];
		}
		return DisplayValue (sngValue, untLen4 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLen6 (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [10];
		}
		return DisplayValue (sngValue, untLen6 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayAngle (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [3];
		}
		return DisplayValue (sngValue, untAngle [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayStress (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [5];
		}
		return DisplayValue (sngValue, untStress [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayForce (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [4];
		}
		return DisplayValue (sngValue, untForce [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayMoment (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [6];
		}
		return DisplayValue (sngValue, untMoment [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayLoad (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [11];
		}
		return DisplayValue (sngValue, untLoad [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayTorque (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [12];
		}
		return DisplayValue (sngValue, untTorque [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayBimoment (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [13];
		}
		return DisplayValue (sngValue, untBimoment [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayTorqueLoad (float sngValue, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if (bytIndex == 0) {
			bytIndex = DefaultUnitIndex [14];
		}
		return DisplayValue (sngValue, untTorqueLoad [bytIndex], blnShowUnit, strFmt, intLPad, intRPad);
	}

	public static string DisplayValue (float sngValue, byte bytUnitType, byte bytIndex = 0, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		if ((bytIndex == 0) & (bytUnitType <= Information.UBound (DefaultUnitIndex))) {
			bytIndex = DefaultUnitIndex [bytUnitType];
		}
		return bytUnitType switch {
			0 => DisplayValue (sngValue, untNone [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			2 => DisplayValue (sngValue, untLength [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			1 => DisplayValue (sngValue, untLength [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			7 => DisplayValue (sngValue, untLen2 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			8 => DisplayValue (sngValue, untLen3 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			9 => DisplayValue (sngValue, untLen4 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			10 => DisplayValue (sngValue, untLen6 [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			3 => DisplayValue (sngValue, untAngle [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			4 => DisplayValue (sngValue, untForce [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			5 => DisplayValue (sngValue, untStress [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			6 => DisplayValue (sngValue, untMoment [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			11 => DisplayValue (sngValue, untLoad [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			12 => DisplayValue (sngValue, untTorque [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			13 => DisplayValue (sngValue, untBimoment [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			14 => DisplayValue (sngValue, untTorqueLoad [bytIndex], blnShowUnit, strFmt, intLPad, intRPad), 
			_ => "", 
		};
	}

	public static string DisplayValue (float sngValue, Unit untUnit, bool blnShowUnit = true, string strFmt = "", short intLPad = 0, short intRPad = 0)
	{
		string text = ((Operators.CompareString (strFmt, string.Empty, TextCompare: false) != 0) ? Strings.Format (sngValue * untUnit.Mult, strFmt) : FormatNum (sngValue * untUnit.Mult));
		if (intLPad > 0) {
			text = text.PadLeft (intLPad);
		}
		if (blnShowUnit & (Strings.Len (untUnit.Name) > 0)) {
			text = text + Strings.Space (1) + untUnit.Name;
		}
		checked {
			if (intRPad > 0) {
				text = text.PadRight ((short)unchecked(intLPad + intRPad));
			}
			return text;
		}
	}

	public static string DisplayUnit (byte bytUnitType, byte bytIndex = 0)
	{
		if ((bytIndex == 0) & (bytUnitType <= Information.UBound (DefaultUnitIndex))) {
			bytIndex = DefaultUnitIndex [bytUnitType];
		}
		return bytUnitType switch {
			2 => untLength [bytIndex].Name, 
			1 => untLength [bytIndex].Name, 
			7 => untLen2 [bytIndex].Name, 
			8 => untLen3 [bytIndex].Name, 
			9 => untLen4 [bytIndex].Name, 
			10 => untLen6 [bytIndex].Name, 
			3 => untAngle [bytIndex].Name, 
			4 => untForce [bytIndex].Name, 
			5 => untStress [bytIndex].Name, 
			6 => untMoment [bytIndex].Name, 
			11 => untLoad [bytIndex].Name, 
			12 => untTorque [bytIndex].Name, 
			13 => untBimoment [bytIndex].Name, 
			14 => untTorqueLoad [bytIndex].Name, 
			_ => "", 
		};
	}

	public static string FormatNum (double Value)
	{
		if (double.IsNaN (Value)) {
			return Value.ToString ();
		}
		if (System.Math.Abs (Value) < 1E-20) {
			return "0";
		}
		double num = (double)System.Math.Sign (Value) * System.Math.Pow (10.0, Conversion.Int (System.Math.Log (System.Math.Abs (Value)) / System.Math.Log (10.0)) - 4.0);
		Value = num * Conversion.Int (Value / num + 0.5);
		if (System.Math.Abs (Value) >= 10000000000.0) {
			return Strings.Format (Value, "0.0###e-0#");
		}
		if (System.Math.Abs (Value) >= 1.0) {
			return Strings.Format (Value);
		}
		if (System.Math.Abs (Value) >= 0.0001) {
			return Strings.Format (Value, "0.########");
		}
		return Strings.Format (Value, "0.0###e-0#");
	}
}
