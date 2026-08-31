// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct AnalysisWizard
{
	public byte AnlType;

	public byte iSct;

	public short nSpan;

	public float[] SpanLen;

	public float CantLen;

	public float LapLen;

	public float Wid;

	public bool Fastened;

	public byte iMemBrace;

	public byte iBrcFlg;

	public float R;

	public float Kf;

	public float Lm;

	public bool Fixed;

	public float TribWid;

	public bool SelfWt;

	public float Dead;

	public float Live;

	public float Prod;

	public float Roof;

	public float Snow;

	public float Wind;

	public float Angle;

	public AnalysisWizard (short SpansMax)
	{
		this = default(AnalysisWizard);
		SpanLen = new float[checked(SpansMax + 1)];
	}
}
