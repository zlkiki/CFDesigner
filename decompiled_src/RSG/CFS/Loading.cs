// Decompiled with ICSharpCode.Decompiler 7.2
using Microsoft.VisualBasic;

namespace RSG.CFS;

internal struct Loading
{
	public string Description;

	public Load[] Load;

	public GridState LoadGrid;

	public byte nLoad;

	public Loading (string strDescription, byte bytLoads = 10)
	{
		this = default(Loading);
		Initialize (strDescription, bytLoads);
	}

	public void Initialize (string strDescription, byte bytLoads = 10)
	{
		Description = strDescription;
		checked {
			Load = new Load[unchecked((int)bytLoads) + 1];
			nLoad = 0;
			LoadGrid = new GridState (1, 1);
		}
	}

	public Loading Clone ()
	{
		object obj = MemberwiseClone ();
		Loading result = ((obj != null) ? ((Loading)obj) : default(Loading));
		checked {
			if (!Information.IsNothing (Load)) {
				result.Load = new Load[Information.UBound (Load) + 1];
				int num = Information.LBound (Load);
				int num2 = Information.UBound (Load);
				for (int i = num; i <= num2; i++) {
					result.Load [i] = Load [i];
				}
			}
			return result;
		}
	}
}
