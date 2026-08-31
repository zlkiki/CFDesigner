// Decompiled with ICSharpCode.Decompiler 7.2
using System.Collections.Generic;
using com.softwarekey.Client.Licensing;

namespace RSG.CFS;

internal class StringIdentifierAlgorithm : SystemIdentifierAlgorithm
{
	private string _CustomString;

	public string CustomString {
		get {
			return _CustomString;
		}
		set {
			_CustomString = value;
		}
	}

	public StringIdentifierAlgorithm ()
		: base ("StringIdentifier")
	{
	}

	public StringIdentifierAlgorithm (string CustomString)
		: base ("StringIdentifier")
	{
		_CustomString = CustomString;
	}

	public override List<SystemIdentifier> GetIdentifiers ()
	{
		return new List<SystemIdentifier> {
			new StringIdentifier ("StringIdentifier1", _CustomString)
		};
	}
}
