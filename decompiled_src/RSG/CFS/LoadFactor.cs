// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct LoadFactor
{
	public byte iLdg;

	public float fLdg;

	public void Assign (byte Loading, float Factor)
	{
		iLdg = Loading;
		fLdg = Factor;
	}
}
