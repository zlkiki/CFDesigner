// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Diagnostics;
using System.Net;
using System.Web.Services.Protocols;
using com.softwarekey.Client.Compatibility.ProtectionPLUS4;
using com.softwarekey.Client.Licensing;
using com.softwarekey.Client.Utils;
using com.softwarekey.Client.WebService;
using com.softwarekey.Client.WebService.XmlActivationService;
using com.softwarekey.Client.WebService.XmlLicenseFileService;
using com.softwarekey.Client.WebService.XmlLicenseService;
using com.softwarekey.Client.WebService.XmlNetworkFloatingService;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace RSG.CFS;

public class WebServiceHelper
{
	private InternetConnectionInformation m_ConnectionInformation;

	private NetworkCredential m_ProxyAuthenticationCredentials;

	private LicenseError m_LastError;

	private const string m_ManualRequestUrl = "https://secure.softwarekey.com/solo/customers/ManualRequest.aspx";

	private const string m_XmlActivationServiceUrl = "https://secure.softwarekey.com/solo/webservices/XmlActivationService.asmx";

	private const string m_XmlLicenseServiceUrl = "https://secure.softwarekey.com/solo/webservices/XmlLicenseService.asmx";

	private const string m_XmlLicenseFileServiceUrl = "https://secure.softwarekey.com/solo/webservices/XmlLicenseFileService.asmx";

	private const string m_XmlNetworkFloatingServiceUrl = "https://secure.softwarekey.com/solo/webservices/XmlNetworkFloatingService.asmx";

	private const string m_PostEvalDataUrl = "https://secure.softwarekey.com/solo/products/trialsignup.asp";

	private const string m_GetLicenseStatusUrl = "https://secure.softwarekey.com/solo/customers/getlicensestatus.asp";

	private const string m_GetRegDataUrl = "https://secure.softwarekey.com/solo/customers/getregdata.asp";

	private const string m_GetTcDataUrl = "https://secure.softwarekey.com/solo/unlock/getcode.asp";

	private const string m_PostRegDataUrl = "https://secure.softwarekey.com/solo/postings/postregdata.asp";

	private const string PATH_REGISTRY_LOCATION = "Software\\RSG Software, Inc.";

	public InternetConnectionInformation ConnectionInformation => m_ConnectionInformation;

	public LicenseError LastError => m_LastError;

	public NetworkCredential ProxyAuthenticationCredentials {
		get {
			return m_ProxyAuthenticationCredentials;
		}
		set {
			m_ProxyAuthenticationCredentials = value;
		}
	}

	public WebServiceHelper ()
	{
		m_ConnectionInformation = null;
		m_ProxyAuthenticationCredentials = null;
		m_LastError = new LicenseError (0);
		Initialize ();
	}

	private void Initialize ()
	{
		m_ConnectionInformation = new InternetConnectionInformation ("https://secure.softwarekey.com/solo/webservices/XmlActivationService.asmx");
	}

	private bool InitializeWebServiceObject (ref SoapHttpClientProtocol ws)
	{
		IWebProxy proxy = null;
		if (!InitializeProxyObject (ref proxy)) {
			return false;
		}
		if (proxy != null) {
			ws.Proxy = proxy;
		}
		return true;
	}

	private bool InitializeWebFormCall (ref WebFormCall wfc)
	{
		IWebProxy proxy = null;
		if (!InitializeProxyObject (ref proxy)) {
			return false;
		}
		if (proxy != null) {
			wfc.Proxy = proxy;
		}
		return true;
	}

	private bool InitializeProxyObject (ref IWebProxy proxy)
	{
		int try0000_dispatch = -1;
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		string text = default(string);
		string text2 = default(string);
		string text3 = default(string);
		RegistryKey registryKey = default(RegistryKey);
		string prompt = default(string);
		bool result = default(bool);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					num = 1;
					proxy = null;
					goto IL_0005;
				case 513:
					{
						num2 = num;
						switch (num3) {
						case 1:
							break;
						default:
							goto end_IL_0000;
						}
						int num4 = num2 + 1;
						num2 = 0;
						switch (num4) {
						case 1:
							break;
						case 2:
							goto IL_0005;
						case 3:
							goto IL_0017;
						case 4:
							goto IL_0026;
						case 5:
							goto IL_002f;
						case 6:
							goto IL_0038;
						case 7:
							goto IL_003f;
						case 8:
							goto IL_0052;
						case 9:
							goto IL_0058;
						case 10:
							goto IL_0070;
						case 11:
							goto IL_0088;
						case 12:
							goto IL_00a0;
						case 13:
							goto IL_00aa;
						case 14:
							goto IL_00b1;
						case 15:
							goto IL_00c9;
						case 16:
							goto IL_00e8;
						case 17:
							goto IL_00fa;
						case 18:
							goto IL_0113;
						case 19:
							goto IL_0123;
						case 20:
							goto IL_0162;
						case 21:
							goto IL_0170;
						case 22:
							goto IL_0177;
						case 23:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 24:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_0177:
					num = 22;
					proxy = m_ConnectionInformation.Proxy;
					break;
					IL_0005:
					num = 2;
					if (!m_ConnectionInformation.ProxyAuthenticationRequired) {
						break;
					}
					goto IL_0017;
					IL_0017:
					num = 3;
					text = m_ConnectionInformation.ProxyAddress;
					goto IL_0026;
					IL_0026:
					num = 4;
					text2 = string.Empty;
					goto IL_002f;
					IL_002f:
					num = 5;
					text3 = string.Empty;
					goto IL_0038;
					IL_0038:
					ProjectData.ClearProjectError ();
					num3 = 1;
					goto IL_003f;
					IL_003f:
					num = 7;
					registryKey = Registry.CurrentUser.OpenSubKey ("Software\\RSG Software, Inc.");
					goto IL_0052;
					IL_0052:
					num = 8;
					if (registryKey != null) {
						goto IL_0058;
					}
					goto IL_00aa;
					IL_0058:
					num = 9;
					text = Conversions.ToString (registryKey.GetValue ("ProxyAddress", text));
					goto IL_0070;
					IL_0070:
					num = 10;
					text2 = Conversions.ToString (registryKey.GetValue ("ProxyUsername", text2));
					goto IL_0088;
					IL_0088:
					num = 11;
					text3 = Conversions.ToString (registryKey.GetValue ("ProxyPassword", text3));
					goto IL_00a0;
					IL_00a0:
					num = 12;
					registryKey.Close ();
					goto IL_00aa;
					IL_00aa:
					ProjectData.ClearProjectError ();
					num3 = 0;
					goto IL_00b1;
					IL_00b1:
					num = 14;
					if (Operators.CompareString (text, m_ConnectionInformation.ProxyAddress, TextCompare: false) != 0) {
						goto IL_00c9;
					}
					goto IL_00e8;
					IL_00c9:
					num = 15;
					m_ConnectionInformation = new InternetConnectionInformation ("https://secure.softwarekey.com/solo/webservices/XmlActivationService.asmx", 10000, new WebProxy (text));
					goto IL_00e8;
					IL_00e8:
					num = 16;
					m_ProxyAuthenticationCredentials = new NetworkCredential (text2, text3);
					goto IL_00fa;
					IL_00fa:
					num = 17;
					m_ConnectionInformation.Proxy.Credentials = m_ProxyAuthenticationCredentials;
					goto IL_0113;
					IL_0113:
					num = 18;
					if (!m_ConnectionInformation.RunTestRequest ()) {
						goto IL_0123;
					}
					goto IL_0177;
					IL_0123:
					num = 19;
					prompt = "Proxy server authentication failed using:\r\nProxyAddress=" + text + "\r\nProxyUsername=" + text2 + "\r\nProxyPassword=" + text3 + "\r\n\r\nRegistry entries are required for proxy settings.\r\nContact RSG Software for more information.";
					goto IL_0162;
					IL_0162:
					num = 20;
					Interaction.MsgBox (prompt, MsgBoxStyle.Exclamation);
					goto IL_0170;
					IL_0170:
					num = 21;
					result = false;
					goto end_IL_0000_3;
					end_IL_0000_2:
					break;
				}
				num = 23;
				result = true;
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 513;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000_3:
			break;
		}
		if (num2 != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public static void OpenManualRequestUrl ()
	{
		Process.Start ("https://secure.softwarekey.com/solo/customers/ManualRequest.aspx");
	}

	public void ResetProxyAuthenticationCredentials ()
	{
		m_ProxyAuthenticationCredentials = null;
	}

	public XmlActivationService CreateXmlActivationServiceObject ()
	{
		SoapHttpClientProtocol ws = new XmlActivationService ();
		ws.Url = "https://secure.softwarekey.com/solo/webservices/XmlActivationService.asmx";
		if (!InitializeWebServiceObject (ref ws)) {
			return null;
		}
		return (XmlActivationService)ws;
	}

	public XmlLicenseService CreateXmlLicenseServiceObject ()
	{
		SoapHttpClientProtocol ws = new XmlLicenseService ();
		ws.Url = "https://secure.softwarekey.com/solo/webservices/XmlLicenseService.asmx";
		if (!InitializeWebServiceObject (ref ws)) {
			return null;
		}
		return (XmlLicenseService)ws;
	}

	public XmlLicenseFileService CreateXmlLicenseFileServiceObject ()
	{
		SoapHttpClientProtocol ws = new XmlLicenseFileService ();
		ws.Url = "https://secure.softwarekey.com/solo/webservices/XmlLicenseFileService.asmx";
		if (!InitializeWebServiceObject (ref ws)) {
			return null;
		}
		return (XmlLicenseFileService)ws;
	}

	public XmlNetworkFloatingService CreateXmlNetworkFloatingServiceObject ()
	{
		SoapHttpClientProtocol ws = new XmlNetworkFloatingService ();
		ws.Url = "https://secure.softwarekey.com/solo/webservices/XmlNetworkFloatingService.asmx";
		if (!InitializeWebServiceObject (ref ws)) {
			return null;
		}
		return (XmlNetworkFloatingService)ws;
	}

	public GetLicenseStatus CreateGetLicenseStatusObject ()
	{
		WebFormCall wfc = new GetLicenseStatus ("https://secure.softwarekey.com/solo/customers/getlicensestatus.asp");
		if (!InitializeWebFormCall (ref wfc)) {
			return null;
		}
		return (GetLicenseStatus)wfc;
	}

	public GetRegData CreateGetRegDataObject ()
	{
		WebFormCall wfc = new GetRegData ("https://secure.softwarekey.com/solo/customers/getregdata.asp");
		if (!InitializeWebFormCall (ref wfc)) {
			return null;
		}
		return (GetRegData)wfc;
	}

	public GetTcData CreateGetTcDataObject ()
	{
		WebFormCall wfc = new GetTcData ("https://secure.softwarekey.com/solo/unlock/getcode.asp");
		if (!InitializeWebFormCall (ref wfc)) {
			return null;
		}
		return (GetTcData)wfc;
	}

	public PostEvalData CreatePostEvalDataObject ()
	{
		WebFormCall wfc = new PostEvalData ("https://secure.softwarekey.com/solo/products/trialsignup.asp");
		if (!InitializeWebFormCall (ref wfc)) {
			return null;
		}
		return (PostEvalData)wfc;
	}

	public PostRegData CreatePostRegDataObject ()
	{
		WebFormCall wfc = new PostRegData ("https://secure.softwarekey.com/solo/postings/postregdata.asp");
		if (!InitializeWebFormCall (ref wfc)) {
			return null;
		}
		return (PostRegData)wfc;
	}
}
