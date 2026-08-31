// Decompiled with ICSharpCode.Decompiler 7.2
using Microsoft.VisualBasic;

namespace RSG.CFS;

internal class ControlData
{
	public byte UnitType;

	public short Index;

	public float Min;

	public float Max;

	public bool Valid;

	public float Value;

	public string Text;

	public ControlData (byte CtrlUnitType, float Minimum = 0f, float Maximum = 0f)
	{
		UnitType = CtrlUnitType;
		if (CtrlUnitType <= Information.UBound (Units.DefaultUnitIndex)) {
			Index = Units.DefaultUnitIndex [CtrlUnitType];
		} else {
			Index = 0;
		}
		Min = Minimum;
		Max = Maximum;
		Valid = true;
	}
}
