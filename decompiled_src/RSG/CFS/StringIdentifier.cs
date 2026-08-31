// Decompiled with ICSharpCode.Decompiler 7.2
using com.softwarekey.Client.Licensing;

namespace RSG.CFS;

internal class StringIdentifier : SystemIdentifier
{
	protected static int m_StringIdentifierId = 1;

	public override string Type => "StringIdentifier";

	public StringIdentifier ()
	{
		m_name = "StringIdentifier" + m_StringIdentifierId;
		checked {
			m_StringIdentifierId++;
		}
	}

	public StringIdentifier (string value)
	{
		m_name = "StringIdentifier" + m_StringIdentifierId;
		checked {
			m_StringIdentifierId++;
			m_value = value;
		}
	}

	public StringIdentifier (string name, string value)
		: base (name, value)
	{
	}

	public StringIdentifier (string name, string value, string hash)
		: base (name, value, hash, "StringIdentifier")
	{
	}
}
