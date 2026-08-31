// Decompiled with ICSharpCode.Decompiler 7.2
using System;

namespace RSG.CFS;

internal struct TorsionSegment
{
	public float Z;

	public float L;

	public float W;

	public float U;

	public float T0;

	public float B0;

	public float ECw;

	public float GJ;

	public bool Braced;

	public bool NoWarping;

	public bool WarpingOnly;

	public bool ReleaseWarping;

	public byte Sup0;

	public byte SupL;

	public double C1;

	public double C2;

	public double C3;

	public double C4;

	public float Phi (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return (float)(C1 + C2 * (double)Z - ((double)(W * Z * Z / 2f) + (double)U * System.Math.Pow (Z, 3.0) / 6.0) / (double)GJ);
		}
		if (WarpingOnly) {
			return (float)(C1 + C2 * (double)Z + C3 * (double)Z * (double)Z + C4 * System.Math.Pow (Z, 3.0) + ((double)W * System.Math.Pow (Z, 4.0) / 24.0 + (double)U * System.Math.Pow (Z, 5.0) / 120.0) / (double)ECw);
		}
		float num = (float)System.Math.Sqrt (GJ / ECw);
		return (float)(C1 + C2 * (double)Z + C3 * System.Math.Sinh (num * Z) + C4 * System.Math.Cosh (num * Z) - ((double)(W * Z * Z / 2f) + (double)U * System.Math.Pow (Z, 3.0) / 6.0) / (double)GJ);
	}

	public float dPhi (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return (float)(C2 - (double)((W * Z + U * Z * Z / 2f) / GJ));
		}
		if (WarpingOnly) {
			return (float)(C2 + 2.0 * C3 * (double)Z + 3.0 * C4 * (double)Z * (double)Z + ((double)W * System.Math.Pow (Z, 3.0) / 6.0 + (double)U * System.Math.Pow (Z, 4.0) / 24.0) / (double)ECw);
		}
		float num = (float)System.Math.Sqrt (GJ / ECw);
		return (float)(C2 + C3 * (double)num * System.Math.Cosh (num * Z) + C4 * (double)num * System.Math.Sinh (num * Z) - (double)((W * Z + U * Z * Z / 2f) / GJ));
	}

	public float d2Phi (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return (0f - (W + U * Z)) / GJ;
		}
		if (WarpingOnly) {
			return (float)(2.0 * C3 + 6.0 * C4 * (double)Z + ((double)(W * Z * Z / 2f) + (double)U * System.Math.Pow (Z, 3.0) / 6.0) / (double)ECw);
		}
		float num = GJ / ECw;
		float num2 = (float)System.Math.Sqrt (num);
		return (float)(C3 * (double)num * System.Math.Sinh (num2 * Z) + C4 * (double)num * System.Math.Cosh (num2 * Z) - (double)((W + U * Z) / GJ));
	}

	public float d3Phi (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return (0f - U) / GJ;
		}
		if (WarpingOnly) {
			return (float)(6.0 * C4 + (double)((W * Z + U * Z * Z / 2f) / ECw));
		}
		float num = GJ / ECw;
		float num2 = (float)System.Math.Sqrt (num);
		return (float)(C3 * (double)num2 * (double)num * System.Math.Cosh (num2 * Z) + C4 * (double)num2 * (double)num * System.Math.Sinh (num2 * Z) - (double)(U / GJ));
	}

	public float d4Phi (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return 0f;
		}
		if (WarpingOnly) {
			return (W + U * Z) / ECw;
		}
		float num = GJ / ECw;
		float num2 = (float)System.Math.Sqrt (num);
		return (float)(C3 * (double)num * (double)num * System.Math.Sinh (num2 * Z) + C4 * (double)num * (double)num * System.Math.Cosh (num2 * Z));
	}

	public float Tsv (float Z)
	{
		return (0f - GJ) * dPhi (Z);
	}

	public float dTsv (float Z)
	{
		return (0f - GJ) * d2Phi (Z);
	}

	public float B (float Z)
	{
		return ECw * d2Phi (Z);
	}

	public float dB (float Z)
	{
		return ECw * d3Phi (Z);
	}

	public float Tw (float Z)
	{
		return ECw * d3Phi (Z);
	}

	public float dTw (float Z)
	{
		return ECw * d4Phi (Z);
	}

	public float d2Tw (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return 0f;
		}
		if (WarpingOnly) {
			return U;
		}
		float num = GJ / ECw;
		float num2 = (float)System.Math.Sqrt (num);
		return (float)((double)(GJ * num2 * num) * C3 * System.Math.Cosh (num2 * Z) + (double)(GJ * num2 * num) * C4 * System.Math.Sinh (num2 * Z));
	}

	public float T (float Z)
	{
		if (Braced) {
			return 0f;
		}
		if (NoWarping) {
			return (float)((double)(0f - GJ) * C2 + (double)(W * Z) + (double)(U * Z * Z / 2f) - (double)(U * ECw / GJ));
		}
		if (WarpingOnly) {
			return (float)(6.0 * C4 * (double)ECw + (double)(W * Z) + (double)(U * Z * Z / 2f));
		}
		return (float)((double)(0f - GJ) * C2 + (double)(W * Z) + (double)(U * Z * Z / 2f) - (double)(U * ECw / GJ));
	}

	public float dT (float Z)
	{
		if (Braced) {
			return 0f;
		}
		return W + U * Z;
	}
}
