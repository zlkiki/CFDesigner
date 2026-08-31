// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using com.softwarekey.Client.Licensing;
using com.softwarekey.Client.WebService.XmlActivationService;
using com.softwarekey.Client.WebService.XmlLicenseFileService;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

internal class CFSLicense : License
{
	private static WebServiceHelper m_WebServiceHelper = new WebServiceHelper ();

	private LicenseConfiguration _LicenseConfig;

	private bool IsRefreshLicenseAttemptDue {
		get {
			TimeSpan timeSpan = DateTime.UtcNow.Subtract (SignatureDate);
			if (LicenseConfiguration.RefreshLicenseAlwaysRequired || (LicenseConfiguration.RefreshLicenseAttemptFrequency > 0 && (timeSpan.TotalDays > (double)LicenseConfiguration.RefreshLicenseAttemptFrequency || (LicenseConfiguration.RefreshLicenseRequireFrequency > 0 && timeSpan.TotalDays > (double)LicenseConfiguration.RefreshLicenseRequireFrequency)))) {
				return true;
			}
			return false;
		}
	}

	private bool IsRefreshLicenseRequired {
		get {
			TimeSpan timeSpan = DateTime.UtcNow.Subtract (SignatureDate);
			if (LicenseConfiguration.RefreshLicenseAlwaysRequired | ((LicenseConfiguration.RefreshLicenseRequireFrequency > 0) & (timeSpan.TotalDays > (double)LicenseConfiguration.RefreshLicenseRequireFrequency))) {
				return true;
			}
			return false;
		}
	}

	public WebServiceHelper WebServiceHelper => m_WebServiceHelper;

	internal LicenseConfiguration LicenseConfig => _LicenseConfig;

	internal bool HasAutomation {
		get {
			string customData = ProductOption.CustomData;
			if (customData != null && customData.ToLower ().Contains ("automation")) {
				return true;
			}
			if (LicenseCustomData != null && LicenseCustomData.ToLower ().Contains ("automation")) {
				return true;
			}
			return false;
		}
	}

	public CFSLicense (LicenseConfiguration LicenseConfig)
		: base (LicenseConfiguration.EncryptionKey, useEncryptedFile: true, useWebServiceEncryption: true, LicenseConfiguration.ThisProductID, LicenseConfiguration.ThisProductVersion, LicenseConfig.SystemIdentifierAlgorithms)
	{
		if (LicenseConfig.IsNetworkConfiguration) {
			base.CurrentIdentifiers.Add (new StringIdentifier (LicenseConfig.CompanyName.ToLowerInvariant ()));
		}
		_LicenseConfig = LicenseConfig;
	}

	internal bool ActivateOnline (int licenseId, string password)
	{
		string licenseContent = "";
		XmlActivationService xmlActivationService = m_WebServiceHelper.CreateXmlActivationServiceObject ();
		if (xmlActivationService == null) {
			LastError = m_WebServiceHelper.LastError;
			return false;
		}
		if (!ActivateInstallationLicenseFile (licenseId, password, xmlActivationService, ref licenseContent)) {
			return false;
		}
		return SaveLicenseFile (licenseContent);
	}

	internal bool DeactivateOnline ()
	{
		XmlActivationService xmlActivationService = m_WebServiceHelper.CreateXmlActivationServiceObject ();
		if (xmlActivationService == null) {
			LastError = m_WebServiceHelper.LastError;
			return false;
		}
		if (DeactivateInstallation (xmlActivationService) | (LastError.ExtendedErrorNumber == 5010) | (LastError.ExtendedErrorNumber == 5015) | (LastError.ExtendedErrorNumber == 5016) | (LastError.ExtendedErrorNumber == 5017)) {
			File.Delete (_LicenseConfig.LicenseFilePath);
			return true;
		}
		return false;
	}

	internal bool RefreshLicense ()
	{
		XmlLicenseFileService xmlLicenseFileService = m_WebServiceHelper.CreateXmlLicenseFileServiceObject ();
		if (xmlLicenseFileService == null) {
			LastError = m_WebServiceHelper.LastError;
			return false;
		}
		string licenseContent = "";
		if (!RefreshLicense (xmlLicenseFileService, ref licenseContent)) {
			if ((LastError.ExtendedErrorNumber == 5010) | (LastError.ExtendedErrorNumber == 5015) | (LastError.ExtendedErrorNumber == 5016) | (LastError.ExtendedErrorNumber == 5017)) {
				File.Delete (_LicenseConfig.LicenseFilePath);
				_LicenseConfig.AppendLog ("Invalid " + Conversions.ToString (LastError.ExtendedErrorNumber));
				return true;
			}
			return false;
		}
		if (SaveLicenseFile (licenseContent)) {
			_LicenseConfig.AppendLog ("Refresh");
			return true;
		}
		return false;
	}

	internal bool SaveLicenseFile (string lfContent)
	{
		try {
			File.WriteAllText (_LicenseConfig.LicenseFilePath, lfContent);
		} catch (Exception ex) {
			ProjectData.SetProjectError (ex);
			Exception ex2 = ex;
			LastError = new LicenseError (9201, ex2);
			bool result = false;
			ProjectData.ClearProjectError ();
			return result;
		}
		return true;
	}

	internal bool Validate ()
	{
		if (IsRefreshLicenseAttemptDue) {
			if (RefreshLicense ()) {
				if (!LoadFile (_LicenseConfig.LicenseFilePath)) {
					return false;
				}
			} else if (IsRefreshLicenseRequired) {
				return false;
			}
		}
		List<SystemValidation> list = new List<SystemValidation> ();
		list.Add (new LicenseProductValidation (this, base.ThisProductID));
		list.Add (new LicenseTypeValidation (this));
		list.Add (new SystemIdentifierValidation (base.AuthorizedIdentifiers, base.CurrentIdentifiers, -1));
		list.Add (new SystemClockValidation ());
		list.Add (new LicenseEffectiveDateValidation (this));
		foreach (SystemValidation item in list) {
			if (!item.Validate ()) {
				LastError = item.LastError;
				return false;
			}
		}
		LastError = new LicenseError (0);
		return true;
	}

	internal bool QuickValidate ()
	{
		List<SystemValidation> list = new List<SystemValidation> ();
		list.Add (new SystemClockValidation ());
		list.Add (new LicenseEffectiveDateValidation (this));
		foreach (SystemValidation item in list) {
			if (!item.Validate ()) {
				LastError = item.LastError;
				return false;
			}
		}
		LastError = new LicenseError (0);
		return true;
	}

	internal string GenerateLicenseErrorString ()
	{
		StringBuilder stringBuilder = new StringBuilder ();
		switch (LastError.ErrorNumber) {
		case 9200:
			stringBuilder.Append (LastError.ErrorNumber);
			stringBuilder.Append (": ");
			stringBuilder.Append ("License not found - activation is required.");
			break;
		case 9225:
			stringBuilder.Append (LastError.ErrorNumber);
			stringBuilder.Append (": ");
			if (ProductOption.OptionType == LicenseProductOption.ProductOptionType.VolumeLicense) {
				stringBuilder.Append ("Volume");
			} else {
				stringBuilder.Append ("Downloadable");
			}
			stringBuilder.Append (" license not found.");
			break;
		case 9202: {
			stringBuilder.Append (LastError.ErrorNumber);
			stringBuilder.Append (": ");
			if (ProductOption.OptionType == LicenseProductOption.ProductOptionType.DownloadableLicenseWithTriggerCodeValidation) {
				stringBuilder.Append ("Activation required.");
				break;
			}
			DateTime dateTime = EffectiveStartDate.ToLocalTime ();
			int num = checked((int)System.Math.Round (dateTime.Subtract (DateTime.Now.Date).TotalDays));
			stringBuilder.Append ("License not effective until ");
			if (1 < num) {
				stringBuilder.Append (dateTime.ToLongDateString ());
				stringBuilder.Append (" (");
				stringBuilder.Append (num);
				stringBuilder.Append (" days).");
			} else if (1 == num) {
				stringBuilder.Append ("tomorrow.");
			} else {
				stringBuilder.Append (dateTime.ToShortTimeString () + " today.");
			}
			break;
		}
		case 9203: {
			stringBuilder.Append (LastError.ErrorNumber);
			stringBuilder.Append (": ");
			DateTime dateTime2 = EffectiveEndDate.ToLocalTime ();
			if (dateTime2.Subtract (DateTime.Now).TotalDays < 0.0) {
				stringBuilder.Append ("License expired " + dateTime2.ToLongDateString ());
			} else {
				stringBuilder.Append ("License invalid or expired.");
			}
			break;
		}
		case 9102:
			if (LastError.ExtendedErrorNumber == 5013) {
				stringBuilder.Append ("There are no more activations available. You must first deactivate the license. Please refer to the CFS help topic 'License Activation'");
				break;
			}
			stringBuilder.Append (LastError.ExtendedErrorNumber);
			stringBuilder.Append (": ");
			stringBuilder.Append (LicenseError.GetWebServiceErrorMessage (LastError.ExtendedErrorNumber));
			break;
		default:
			stringBuilder.Append (LastError.ErrorNumber);
			stringBuilder.Append (": ");
			stringBuilder.Append (LastError.ToString ());
			break;
		}
		return stringBuilder.ToString ();
	}

	internal string GenerateLicenseStatusEntry (bool lastValidationSuccessful)
	{
		StringBuilder stringBuilder = new StringBuilder ();
		checked {
			if (lastValidationSuccessful) {
				stringBuilder.Append ("OK");
				if (ProductOption.OptionType == LicenseProductOption.ProductOptionType.VolumeLicense) {
					stringBuilder.Append (" (Volume License)");
				} else if (ProductOption.OptionType == LicenseProductOption.ProductOptionType.DownloadableLicenseWithTriggerCodeValidation) {
					stringBuilder.Append (" (Downloaded, Validated)");
				}
				DateTime dateTime = EffectiveEndDate.ToLocalTime ();
				TimeSpan timeSpan = dateTime.Subtract (DateTime.Now);
				stringBuilder.Append (" - Expires ");
				if (timeSpan.TotalDays < 1.0) {
					stringBuilder.Append (dateTime.ToShortTimeString () + " today.");
				} else if ((int)System.Math.Round (timeSpan.TotalDays) == 1) {
					stringBuilder.Append ("tomorrow.");
				} else {
					stringBuilder.Append (dateTime.ToLongDateString ());
					stringBuilder.Append (" (" + (int)System.Math.Round (timeSpan.TotalDays) + " days).");
				}
				stringBuilder.Append (Environment.NewLine + LicenseRegistrationInfo ());
			} else {
				stringBuilder.Append (GenerateLicenseErrorString ());
			}
			return stringBuilder.ToString ();
		}
	}

	internal string LicenseRegistrationInfo ()
	{
		StringBuilder stringBuilder = new StringBuilder ();
		if ((Operators.CompareString (Customer.FirstName, "", TextCompare: false) != 0) & (Operators.CompareString (Customer.FirstName, "UNREGISTERED", TextCompare: false) != 0)) {
			stringBuilder.Append ("Registered To: ");
			stringBuilder.Append (Customer.FirstName);
		}
		if ((Operators.CompareString (Customer.LastName, "", TextCompare: false) != 0) & (Operators.CompareString (Customer.LastName, "UNREGISTERED", TextCompare: false) != 0)) {
			if (Operators.CompareString (stringBuilder.ToString (), "", TextCompare: false) == 0) {
				stringBuilder.Append ("Registered To:");
			}
			stringBuilder.Append (" ");
			stringBuilder.Append (Customer.LastName);
		}
		if ((Operators.CompareString (Customer.CompanyName, "", TextCompare: false) != 0) & (Operators.CompareString (Customer.CompanyName, "UNREGISTERED", TextCompare: false) != 0)) {
			if (Operators.CompareString (stringBuilder.ToString (), "", TextCompare: false) == 0) {
				stringBuilder.Append ("Registered To:");
			}
			stringBuilder.Append (" ");
			stringBuilder.Append ("[" + Customer.CompanyName + "]");
		}
		if (stringBuilder.Length > 0) {
			stringBuilder.Append (Environment.NewLine);
		}
		stringBuilder.AppendLine ("License ID: " + Conversions.ToString (LicenseID));
		if (HasAutomation) {
			stringBuilder.AppendLine ("Includes Automation");
		}
		if (IsTestLicense) {
			stringBuilder.AppendLine ("Test License - deleted at the end of the month");
		}
		return stringBuilder.ToString ();
	}
}
