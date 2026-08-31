// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct MemberParameters
{
	public float Lx;

	public float Ly;

	public float Lt;

	public float Lm;

	public float Kx;

	public float Ky;

	public float Kt;

	public float Cbx1;

	public float Cbx2;

	public float Cby1;

	public float Cby2;

	public float Cmx;

	public float Cmy;

	public Flanges iBrcFlg;

	public float R;

	public float Kf;

	public float P;

	public float ex;

	public float ey;

	public float Mx;

	public float Vy;

	public float My;

	public float Vx;

	public float B;

	public Specifications Spec;

	public bool Pdelta;

	public bool Analysis;

	public bool BucklingTheory;

	public bool Torsion;

	public MemberParameters (Specifications Specification)
	{
		this = default(MemberParameters);
		Spec = Specification;
		Kx = 1f;
		Ky = 1f;
		Kt = 1f;
		Cbx1 = 1f;
		Cbx2 = 1f;
		Cmx = 1f;
		Cby1 = 1f;
		Cby2 = 1f;
		Cmy = 1f;
	}
}
