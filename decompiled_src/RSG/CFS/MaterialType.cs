// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

internal class MaterialType
{
	public string Name;

	public string Family;

	public float[] Eo;

	public float[] Fy;

	public float[] N;

	public float Fu;

	public float FyMin;

	public float FuMin;

	public float FuMax;

	public float Elong;

	public float ElongThin;

	public float ThkMin;

	public MaterialType ()
	{
		Eo = new float[6];
		Fy = new float[6];
		N = new float[6];
		Initialize ();
	}

	public void Initialize ()
	{
		SetCarbon ();
		Name = "A653 SS Grade 33";
		Eo [1] = 29500f;
		Fy [1] = 33f;
		N [1] = 0f;
		Eo [2] = 29500f;
		Fy [2] = 33f;
		N [2] = 0f;
		Eo [3] = 29500f;
		Fy [3] = 33f;
		N [3] = 0f;
		Eo [4] = 29500f;
		Fy [4] = 33f;
		N [4] = 0f;
		Eo [5] = 11300f;
		Fy [5] = 19.8f;
		N [5] = 0f;
		Fu = 45f;
		FyMin = 33f;
		FuMin = 45f;
		FuMax = 60f;
		Elong = 20f;
		ElongThin = 0f;
		ThkMin = 0f;
	}

	public MaterialType Clone ()
	{
		MaterialType materialType = (MaterialType)MemberwiseClone ();
		materialType.Eo = (float[])Eo.Clone ();
		materialType.Fy = (float[])Fy.Clone ();
		materialType.N = (float[])N.Clone ();
		return materialType;
	}

	public float EsEo (float F, short iDir)
	{
		if (!(N [iDir] > 0f)) {
			return 1f;
		}
		float num = ((iDir != 5) ? 0.002f : 0.003f);
		return (float)(1.0 / (1.0 + (double)(num * Eo [iDir] / Fy [iDir]) * System.Math.Pow (System.Math.Abs (F) / Fy [iDir], N [iDir] - 1f)));
	}

	public float EtEo (float F, short iDir)
	{
		if (!(N [iDir] > 0f)) {
			return 1f;
		}
		float num = ((iDir != 5) ? 0.002f : 0.003f);
		return (float)(1.0 / (1.0 + (double)(num * N [iDir] * Eo [iDir] / Fy [iDir]) * System.Math.Pow (System.Math.Abs (F) / Fy [iDir], N [iDir] - 1f)));
	}

	public float FprFy (short iDir)
	{
		if (N [iDir] > 0f) {
			return (float)System.Math.Pow (0.05, 1f / N [iDir]);
		}
		return 1f;
	}

	public void AssignFamily ()
	{
		if ((Family == null || Family.Length != 1) | (Strings.InStr ("CAFD", Family) == 0)) {
			if ((N [1] == 0f) & (N [2] == 0f) & (N [3] == 0f) & (N [4] == 0f) & (N [5] == 0f)) {
				Family = "C";
			} else if ((Strings.InStr (Name, "300") > 0) | (Strings.InStr (Name.ToUpper (), "HARD") > 0)) {
				Family = "A";
			} else if ((Strings.InStr (Name, "301") > 0) | (Strings.InStr (Name, "304") > 0) | (Strings.InStr (Name, "316") > 0)) {
				Family = "A";
			} else if ((Strings.InStr (Name, "409") > 0) | (Strings.InStr (Name, "410") > 0) | (Strings.InStr (Name, "430") > 0) | (Strings.InStr (Name, "439") > 0)) {
				Family = "F";
			} else {
				Family = "D";
			}
		}
	}

	public void SetCarbon ()
	{
		Family = "C";
	}

	public void SetAustenitic ()
	{
		Family = "A";
	}

	public void SetFerritic ()
	{
		Family = "F";
	}

	public void SetDuplex ()
	{
		Family = "D";
	}

	public bool IsCarbon ()
	{
		return Operators.CompareString (Family, "C", TextCompare: false) == 0;
	}

	public bool IsStainless ()
	{
		return Operators.CompareString (Family, "C", TextCompare: false) != 0;
	}

	public bool IsAustenitic ()
	{
		return Operators.CompareString (Family, "A", TextCompare: false) == 0;
	}

	public bool IsFerritic ()
	{
		return Operators.CompareString (Family, "F", TextCompare: false) == 0;
	}

	public bool IsDuplex ()
	{
		return Operators.CompareString (Family, "D", TextCompare: false) == 0;
	}
}
