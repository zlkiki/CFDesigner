// Decompiled with ICSharpCode.Decompiler 7.2
using com.softwarekey.Client.Licensing;

namespace RSG.CFS;

internal class LicenseTypeValidation : SystemValidation
{
	private CFSLicense _License;

	public LicenseTypeValidation (CFSLicense License)
	{
		_License = License;
	}

	public override bool Validate ()
	{
		bool flag = false;
		string customData = _License.ProductOption.CustomData;
		if (customData != null && customData.ToLower ().Contains ("network")) {
			flag = true;
		}
		if (_License.LicenseCustomData != null && _License.LicenseCustomData.ToLower ().Contains ("network")) {
			flag = true;
		}
		if (flag == _License.LicenseConfig.IsNetworkConfiguration) {
			return true;
		}
		LastError = new LicenseError (9012);
		return false;
	}
}
