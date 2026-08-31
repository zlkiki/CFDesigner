// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal class ListItem
{
	public string Text;

	public int ItemData;

	public ListItem (string strText, int intData)
	{
		Text = strText;
		ItemData = intData;
	}

	public override string ToString ()
	{
		return Text;
	}
}
