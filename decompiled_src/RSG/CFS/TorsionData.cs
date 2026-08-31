// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct TorsionData
{
	public short iElem;

	public float Loc;

	public float Ro;

	public float Wn;

	public float Sw;

	public void Assign (short intElem, float sngLoc, float sngRo, float sngWn, float sngSw)
	{
		iElem = intElem;
		Loc = sngLoc;
		Ro = sngRo;
		Wn = sngWn;
		Sw = sngSw;
	}
}
