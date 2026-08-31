// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct WebCripCheck
{
	public short nEq;

	public string[] PeText;

	public float[] Pne;

	public float[] Pn;

	public float[] Pae;

	public float[] Pa;

	public float[] QPne;

	public float[] QPn;

	public float SPn;

	public float SPa;

	public float SQPn;

	public float Mn;

	public float Ma;

	public float QMn;

	public string[] EqText;

	public float[] Eq;

	public string Msg;

	public WebCripCheck (short Equations)
	{
		this = default(WebCripCheck);
		checked {
			EqText = new string[Equations + 1];
			Eq = new float[Equations + 1];
		}
	}
}
