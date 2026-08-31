// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.Data;

[StandardModule]
internal sealed class DataAnalysis
{
	private struct Point2D
	{
		public float X;

		public float Y;

		public Point2D (float X1, float Y1)
		{
			this = default(Point2D);
			X = X1;
			Y = Y1;
		}

		public Point2D Add (Point2D Pt)
		{
			Point2D result = default(Point2D);
			result.X = X + Pt.X;
			result.Y = Y + Pt.Y;
			return result;
		}

		public Point2D Subt (Point2D Pt)
		{
			Point2D result = default(Point2D);
			result.X = X - Pt.X;
			result.Y = Y - Pt.Y;
			return result;
		}

		public Point2D Mult (float F)
		{
			Point2D result = default(Point2D);
			result.X = X * F;
			result.Y = Y * F;
			return result;
		}

		public float Dist (Point2D Pt)
		{
			return (float)System.Math.Sqrt (System.Math.Pow (X - Pt.X, 2.0) + System.Math.Pow (Y - Pt.Y, 2.0));
		}
	}

	public static double Interpolate (short N, double[] X, double[] Y, double X1)
	{
		double num = 0.0;
		checked {
			for (int i = 1; i <= N; i++) {
				double num2 = Y [i];
				for (int j = 1; j <= N; j++) {
					if (j != i) {
						num2 = num2 * (X1 - X [j]) / (X [i] - X [j]);
					}
				}
				num += num2;
			}
			return num;
		}
	}

	public static float Interpolate (short N, float[] X, float[] Y, float X1)
	{
		float num = 0f;
		checked {
			for (int i = 1; i <= N; i++) {
				float num2 = Y [i];
				for (int j = 1; j <= N; j++) {
					if (j != i) {
						num2 = num2 * (X1 - X [j]) / (X [i] - X [j]);
					}
				}
				num += num2;
			}
			return num;
		}
	}

	public static float Interpolate3 (short N, float[] X, float[] Y, float X1)
	{
		if (N <= 2) {
			return Interpolate (N, X, Y, X1);
		}
		checked {
			short num = (short)(N - 1);
			short num2 = 2;
			while (num2 <= num && !(X [num2] > X1)) {
				num2 = (short)unchecked(num2 + 1);
			}
			short num3 = (short)(num2 - 1);
			if ((X1 > X [num3]) & (X1 < X [num2])) {
				if (num3 == 1) {
					num2 = (short)(num3 + 2);
				}
				if (num2 == N) {
					num3 = (short)(num2 - 2);
				}
				if (unchecked(num3 > 1 && num2 < N)) {
					if (X1 - X [num3] < X [num2] - X1) {
						num3 = (short)(num3 - 1);
					} else {
						num2 = (short)(num2 + 1);
					}
				}
			}
			if (((short)unchecked(num2 - num3) == 2) & ((double)(X [num3 + 1] - X [num3]) < 0.01 * (double)(X [num2] - X [num3]))) {
				num3 = (short)(num3 + 1);
			}
			if (((short)unchecked(num2 - num3) == 2) & ((double)(X [num2] - X [num2 - 1]) < 0.01 * (double)(X [num2] - X [num3]))) {
				num2 = (short)(num2 - 1);
			}
			float[] array = new float[4];
			float[] array2 = new float[4];
			short num4 = num3;
			short num5 = num2;
			short num7 = default(short);
			for (short num6 = num4; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
				num7 = (short)(num7 + 1);
				array [num7] = X [num6];
				array2 [num7] = Y [num6];
			}
			return Interpolate (num7, array, array2, X1);
		}
	}

	public static float Bezier4 (float[] X, float[] Y, float X1)
	{
		Point2D[] array = new Point2D[4];
		int num = 1;
		checked {
			do {
				if (X [num] > X [num + 1]) {
					X [0] = X [num];
					X [num] = X [num + 1];
					X [num + 1] = X [0];
					Y [0] = Y [num];
					Y [num] = Y [num + 1];
					Y [num + 1] = Y [0];
					if (num > 1) {
						num -= 2;
					}
				}
				num++;
			} while (num <= 3);
			int num2 = 0;
			do {
				array [num2] = new Point2D (X [num2 + 1], Y [num2 + 1]);
				num2++;
			} while (num2 <= 3);
			short num3 = 0;
			while (!(X1 > array [num3].X)) {
				num3 = (short)unchecked(num3 + 1);
				if (num3 > 3) {
					break;
				}
			}
			switch (num3) {
			case 0:
				return Y [1];
			case 4:
				return Y [4];
			case 1:
				array [3] = array [2];
				array [2] = array [1];
				array [1] = array [0];
				break;
			}
			if (num3 == 2) {
				array [0] = array [1];
				array [1] = array [2];
				array [2] = array [3];
			}
			array [0].Dist (array [1]);
			float num4 = array [1].Dist (array [2]);
			array [2].Dist (array [3]);
			float num5 = array [0].Dist (array [2]);
			float num6 = array [1].Dist (array [3]);
			Point2D point2D = array [1];
			Point2D point2D2;
			Point2D point2D3;
			float f;
			if ((num5 / 3f < num4) & (num6 / 3f < num4)) {
				f = ((num3 < 2) ? (1f / 3f) : (1f / 6f));
				point2D2 = array [1].Add (array [2].Subt (array [0]).Mult (f));
				f = ((num3 > 2) ? (1f / 3f) : (1f / 6f));
				point2D3 = array [2].Add (array [1].Subt (array [3]).Mult (f));
			} else if ((num5 / 3f >= num4) & (num6 / 3f >= num4)) {
				point2D2 = array [1].Add (array [2].Subt (array [0]).Mult (num4 / 2f / num5));
				point2D3 = array [2].Add (array [1].Subt (array [3]).Mult (num4 / 2f / num6));
			} else if (num5 / 3f >= num4) {
				point2D2 = array [1].Add (array [2].Subt (array [0]).Mult (num4 / 2f / num5));
				point2D3 = array [2].Add (array [1].Subt (array [3]).Mult (num4 / 2f / num5));
			} else {
				point2D2 = array [1].Add (array [2].Subt (array [0]).Mult (num4 / 2f / num6));
				point2D3 = array [2].Add (array [1].Subt (array [3]).Mult (num4 / 2f / num6));
			}
			Point2D point2D4 = array [2];
			f = (X1 - array [num3 - 1].X) / (array [num3].X - array [num3 - 1].X);
			return (float)(System.Math.Pow (1f - f, 3.0) * (double)point2D.Y + (double)(3f * f) * System.Math.Pow (1f - f, 2.0) * (double)point2D2.Y + 3.0 * System.Math.Pow (f, 2.0) * (double)(1f - f) * (double)point2D3.Y + System.Math.Pow (f, 3.0) * (double)point2D4.Y);
		}
	}

	public static float BezierInterpolate (short N, float[] X, float[] Y, float X1)
	{
		float[,] array = BezierControlPoints (N, X);
		float[,] array2 = BezierControlPoints (N, Y);
		if (X1 <= X [1]) {
			float num = (array2 [1, 1] - Y [1]) / (array [1, 1] - X [1]);
			return Y [1] + num * (X1 - X [1]);
		}
		checked {
			if (X1 >= X [N]) {
				float num2 = (Y [N] - array2 [2, N - 1]) / (X [N] - array [2, N - 1]);
				return Y [N] + num2 * (X1 - X [N]);
			}
			int num3 = N - 1;
			for (int i = 1; i <= num3; i++) {
				if (X1 == X [i]) {
					return Y [i];
				}
				if (X [i + 1] > X1) {
					float num4 = X [i + 1] - X [i];
					float num5 = Y [i + 1] - Y [i];
					float num = (array2 [1, i] - Y [i]) / (array [1, i] - X [i]);
					float num2 = (Y [i + 1] - array2 [2, i]) / (X [i + 1] - array [2, i]);
					float num6 = (float)((double)((num2 + num) * num4 - 2f * num5) / System.Math.Pow (num4, 3.0));
					float num7 = (float)(0.5 * (double)(num2 - num) / (double)num4 - 1.5 * (double)num6 * (double)num4);
					float num8 = num;
					num4 = X1 - X [i];
					return (float)((double)(Y [i] + num8 * num4) + (double)num7 * System.Math.Pow (num4, 2.0) + (double)num6 * System.Math.Pow (num4, 3.0));
				}
			}
			float result = default(float);
			return result;
		}
	}

	private static float[,] BezierControlPoints (short NP, float[] X)
	{
		checked {
			short num = (short)(NP - 1);
			float[,] array = new float[3, num + 1];
			float[] array2 = new float[num + 1];
			float[] array3 = new float[num + 1];
			float[] array4 = new float[num + 1];
			float[] array5 = new float[num + 1];
			array2 [1] = 0f;
			array3 [1] = 2f;
			array4 [1] = 1f;
			array5 [1] = X [1] + 2f * X [2];
			int num2 = num;
			for (int i = 2; i <= num2; i++) {
				array2 [i] = 1f;
				array3 [i] = 4f;
				array4 [i] = 1f;
				array5 [i] = 4f * X [i] + 2f * X [i + 1];
			}
			array2 [num] = 2f;
			array3 [num] = 7f;
			array4 [num] = 0f;
			array5 [num] = 8f * X [num] + X [num + 1];
			int num3 = num;
			for (int j = 2; j <= num3; j++) {
				float num4 = array2 [j] / array3 [j - 1];
				array3 [j] -= num4 * array4 [j - 1];
				array5 [j] -= num4 * array5 [j - 1];
			}
			array [1, num] = array5 [num] / array3 [num];
			for (int k = num - 1; k >= 1; k += -1) {
				array [1, k] = (array5 [k] - array4 [k] * array [1, k + 1]) / array3 [k];
			}
			int num5 = num - 1;
			for (int l = 1; l <= num5; l++) {
				array [2, l] = 2f * X [l + 1] - array [1, l + 1];
			}
			array [2, num] = (float)(0.5 * (double)(X [num + 1] + array [1, num]));
			return array;
		}
	}

	public static void Regression (short NV, short NT, int NP, double[,] X, short[] IT, double[,] EX, ref short IErr)
	{
		checked {
			double[,] array = new double[NV + 1, NP + 1];
			double[,] array2 = new double[NT + 1, NT + 1];
			double[] array3 = new double[NT + 1];
			double[] array4 = new double[NT + 1];
			for (int i = 1; i <= NV; i++) {
				for (int j = 1; j <= NP; j++) {
					if (IT [i] == 1) {
						array [i, j] = X [i, j];
					}
					if (IT [i] == 2) {
						array [i, j] = System.Math.Log (X [i, j]);
					}
					if (IT [i] == 3) {
						array [i, j] = System.Math.Log10 (X [i, j]);
					}
				}
			}
			for (int k = 1; k <= NP; k++) {
				for (int l = 1; l <= NT; l++) {
					double num = 1.0;
					int num2 = NV - 1;
					for (int m = 1; m <= num2; m++) {
						if ((array [m, k] < 0.0) & (EX [m, l] != (double)(int)System.Math.Round (EX [m, l]))) {
							IErr = 1;
							return;
						}
						num *= System.Math.Pow (array [m, k], EX [m, l]);
					}
					array4 [l] = num;
				}
				for (int n = 1; n <= NT; n++) {
					for (int num3 = n; num3 <= NT; num3++) {
						array2 [n, num3] += array4 [num3] * array4 [n];
					}
					array3 [n] += array [NV, k] * array4 [n];
				}
			}
			for (int num4 = 2; num4 <= NT; num4++) {
				int num5 = num4 - 1;
				double num7;
				for (int num6 = 2; num6 <= num5; num6++) {
					num7 = 0.0;
					int num8 = num6 - 1;
					for (int num9 = 1; num9 <= num8; num9++) {
						num7 += array2 [num9, num6] * array2 [num9, num4];
					}
					array2 [num6, num4] -= num7;
				}
				num7 = 0.0;
				int num10 = num4 - 1;
				for (int num11 = 1; num11 <= num10; num11++) {
					if (array2 [num11, num11] <= 0.0) {
						IErr = 2;
						return;
					}
					double num = array2 [num11, num4] / array2 [num11, num11];
					num7 += num * array2 [num11, num4];
					array2 [num11, num4] = num;
				}
				array2 [num4, num4] -= num7;
			}
			for (int num12 = 2; num12 <= NT; num12++) {
				int num13 = num12 - 1;
				for (int num14 = 1; num14 <= num13; num14++) {
					array3 [num12] -= array2 [num14, num12] * array3 [num14];
				}
			}
			for (int num15 = NT; num15 >= 1; num15 += -1) {
				array3 [num15] /= array2 [num15, num15];
				for (int num16 = num15 + 1; num16 <= NT; num16++) {
					array3 [num15] -= array2 [num15, num16] * array3 [num16];
				}
			}
			for (int num17 = 1; num17 <= NT; num17++) {
				EX [NV, num17] = array3 [num17];
			}
			IErr = 0;
		}
	}
}
