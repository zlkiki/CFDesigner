// Decompiled with ICSharpCode.Decompiler 7.2
using Microsoft.VisualBasic;

namespace RSG.CFS;

internal struct Beam
{
	public byte iSct;

	public float Z0;

	public float Z1;

	public byte iBrcFlg;

	public float R;

	public float Kf;

	public float Lm;

	public float ex;

	public float ey;

	public float[] EI;

	public float GJ;

	public float ECw;

	public Beam (byte iSection)
	{
		this = default(Beam);
		iSct = iSection;
		EI = new float[4];
	}

	public Beam Clone ()
	{
		object obj = MemberwiseClone ();
		Beam result = ((obj != null) ? ((Beam)obj) : default(Beam));
		if (!Information.IsNothing (EI)) {
			result.EI = (float[])EI.Clone ();
		}
		return result;
	}
}
