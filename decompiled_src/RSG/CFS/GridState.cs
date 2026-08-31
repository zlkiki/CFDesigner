// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct GridState
{
	public byte RowStart;

	public byte ColStart;

	public byte RowEnd;

	public byte ColEnd;

	public byte Corner;

	public byte TopRow;

	public byte LeftCol;

	public GridState (byte bytRowEnd, byte bytColEnd)
	{
		this = default(GridState);
		RowStart = 1;
		RowEnd = bytRowEnd;
		ColStart = 1;
		ColEnd = bytColEnd;
		Corner = 0;
		TopRow = 1;
		LeftCol = 1;
	}
}
