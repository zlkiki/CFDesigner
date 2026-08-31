// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct MemberCheck
{
	public float Pa;

	public float QPn;

	public float Mx;

	public float Cbx;

	public float Max;

	public float Maxt;

	public float QMnx;

	public float QMnxt;

	public float My;

	public float Cby;

	public float May;

	public float Mayt;

	public float QMny;

	public float QMnyt;

	public float Vy;

	public float Vx;

	public float B;

	public string[] EqText;

	public float[] Eq;

	public string Msg;

	public float[] VFy;

	public float[] VFx;

	public MemberCheck (short Equations)
	{
		this = default(MemberCheck);
		checked {
			EqText = new string[Equations + 1];
			Eq = new float[Equations + 1];
		}
	}
}
