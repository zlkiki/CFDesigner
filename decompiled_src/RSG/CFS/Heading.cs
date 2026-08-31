// Decompiled with ICSharpCode.Decompiler 7.2
using System;

namespace RSG.CFS;

internal struct Heading
{
	public string Filename;

	public DateTime RevDate;

	public string RevBy;

	public string Description;

	public string Project;

	public short AppVer;

	public bool Deleted;

	public byte Parent;

	public Heading (string strFileName)
	{
		this = default(Heading);
		Initialize ();
		Filename = strFileName;
	}

	public void Initialize ()
	{
		Filename = string.Empty;
		RevDate = DateTime.FromOADate (0.0);
		RevBy = string.Empty;
		Description = string.Empty;
		Project = string.Empty;
		AppVer = -1;
		Deleted = true;
		Parent = 0;
	}
}
