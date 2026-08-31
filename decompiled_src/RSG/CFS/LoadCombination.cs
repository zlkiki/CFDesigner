// Decompiled with ICSharpCode.Decompiler 7.2
using Microsoft.VisualBasic;

namespace RSG.CFS;

internal struct LoadCombination
{
	public string Description;

	public short Spec;

	public bool InflPt;

	public LoadFactor[] LF;

	public GridState LFGrid;

	public byte nLF;

	public LoadCombination (string strDescription, byte bytLoadFactors = 10)
	{
		this = default(LoadCombination);
		Initialize (strDescription, bytLoadFactors);
	}

	public void Initialize (string strDescription, byte bytLoadFactors = 10)
	{
		Description = strDescription;
		Spec = CFS.intSpecNow;
		InflPt = false;
		checked {
			LF = new LoadFactor[unchecked((int)bytLoadFactors) + 1];
			nLF = 0;
			LFGrid = new GridState (1, 1);
		}
	}

	public LoadCombination Clone ()
	{
		object obj = MemberwiseClone ();
		LoadCombination result = ((obj != null) ? ((LoadCombination)obj) : default(LoadCombination));
		checked {
			if (!Information.IsNothing (LF)) {
				result.LF = new LoadFactor[Information.UBound (LF) + 1];
				int num = Information.LBound (LF);
				int num2 = Information.UBound (LF);
				for (int i = num; i <= num2; i++) {
					result.LF [i] = LF [i];
				}
			}
			return result;
		}
	}
}
