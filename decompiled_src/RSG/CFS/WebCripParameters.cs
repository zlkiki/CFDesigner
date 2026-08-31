// Decompiled with ICSharpCode.Decompiler 7.2
namespace RSG.CFS;

internal struct WebCripParameters
{
	public LoadDirections Dir;

	public float P;

	public float M;

	public float N;

	public float Zend;

	public float Zload;

	public Specifications Spec;

	public bool Fastened;

	public WebCripParameters (Specifications Specification)
	{
		this = default(WebCripParameters);
		Spec = Specification;
	}
}
