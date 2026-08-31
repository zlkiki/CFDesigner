// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using com.softwarekey.Client.Licensing;
using com.softwarekey.Client.Licensing.Network;
using com.softwarekey.Client.Utils;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace RSG.CFS;

internal sealed class LicenseConfiguration
{
	public const string LICENSE_FILENAME = "CFSLicense.lfx";

	private const string PATH_REGISTRY_LOCATION = "Software\\RSG Software, Inc.";

	private const string COMPANY_REGISTRY_LOCATION = "Software\\RSG Software, Inc.\\CFS\\Heading";

	private bool _NetworkConfig;

	private string _LicenseFilePath;

	private string _CompanyName;

	internal static AuthorEncryptionKey EncryptionKey {
		get {
			string envelopeKey = "jg1drOnLsdlPAEkddNZX66+JvORnqiFCfGpllvCxvwx9lHx80dIvAiZhpneTXlPA";
			string envelope = "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";
			return new AuthorEncryptionKey (envelopeKey, envelope, useMachineKeyStore: false);
		}
	}

	internal static string ManualActionIV => "SV46ohk3vdIU7e+/jxUfHQ==";

	internal static string ManualActionKey => "DLcuUW/9d7IkRmGs0jzapfHzmoh0+FQhYQCz4QvZJLw=";

	internal static int RegKey2Seed => 190;

	internal static int TriggerCodeSeed => 28333;

	internal static string ApplicationDirectory {
		get {
			string text = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData), "RSG Software\\CFS");
			if (!Directory.Exists (text)) {
				Directory.CreateDirectory (text);
			}
			return text;
		}
	}

	internal static int ThisProductID => 411592;

	internal static string ThisProductVersion => IOHelper.GetAssemblyFileVersion (Assembly.GetExecutingAssembly ());

	internal static List<LicenseAlias> Aliases => new List<LicenseAlias> (new LicenseAlias[2] {
		new LicenseFileSystemAlias (Path.Combine (ApplicationDirectory, "CFSLicenseAlias1.lfx"), EncryptionKey, useEncryption: true),
		new LicenseFileSystemAlias (Path.Combine (ApplicationDirectory, "CFSLicenseAlias2.lfx"), EncryptionKey, useEncryption: true)
	});

	internal string LicenseFilePath {
		get {
			if (_LicenseFilePath == null || Operators.CompareString (_LicenseFilePath, "", TextCompare: false) == 0) {
				return Path.Combine (ApplicationDirectory, "CFSLicense.lfx");
			}
			return _LicenseFilePath;
		}
		set {
			_LicenseFilePath = Path.Combine (Conversions.ToString (Interaction.IIf (value == null, string.Empty, value)), "CFSLicense.lfx");
		}
	}

	internal string CompanyName {
		get {
			return _CompanyName;
		}
		set {
			_CompanyName = value;
		}
	}

	internal static string ManualActionSessionStateFilePath => Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.LocalApplicationData), Path.GetFileNameWithoutExtension (Assembly.GetExecutingAssembly ().Location) + "ManualAction.xml");

	internal string PathRegistryValue {
		get {
			int try0000_dispatch = -1;
			int num3 = default(int);
			int num2 = default(int);
			int num = default(int);
			string result = default(string);
			RegistryKey registryKey = default(RegistryKey);
			string name = default(string);
			while (true) {
				try {
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					switch (try0000_dispatch) {
					default:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0007;
					case 155:
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
								goto IL_0007;
							case 3:
								goto IL_000f;
							case 4:
								goto IL_0022;
							case 6:
								goto IL_0028;
							case 7:
								goto IL_0046;
							case 8:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 5:
							case 9:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0046:
						num = 7;
						result = Conversions.ToString (registryKey.GetValue (name, string.Empty));
						break;
						IL_0007:
						num = 2;
						result = string.Empty;
						goto IL_000f;
						IL_000f:
						num = 3;
						registryKey = Registry.CurrentUser.OpenSubKey ("Software\\RSG Software, Inc.");
						goto IL_0022;
						IL_0022:
						num = 4;
						if (registryKey == null) {
							goto end_IL_0000_3;
						}
						goto IL_0028;
						IL_0028:
						num = 6;
						name = Conversions.ToString (Interaction.IIf (_NetworkConfig, "NetworkLicenseShare", "SingleLicenseFolder"));
						goto IL_0046;
						end_IL_0000_2:
						break;
					}
					num = 8;
					registryKey.Close ();
					break;
					end_IL_0000:;
				} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
					ProjectData.SetProjectError ((Exception)obj);
					try0000_dispatch = 155;
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
		set {
			int try0000_dispatch = -1;
			int num3 = default(int);
			int num2 = default(int);
			int num = default(int);
			RegistryKey registryKey = default(RegistryKey);
			string name = default(string);
			while (true) {
				try {
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					switch (try0000_dispatch) {
					default:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0007;
					case 117:
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
								goto IL_0007;
							case 3:
								goto IL_0019;
							case 4:
								goto IL_0037;
							case 5:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 6:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0037:
						num = 4;
						registryKey.SetValue (name, value, RegistryValueKind.String);
						break;
						IL_0007:
						num = 2;
						registryKey = Registry.CurrentUser.CreateSubKey ("Software\\RSG Software, Inc.");
						goto IL_0019;
						IL_0019:
						num = 3;
						name = Conversions.ToString (Interaction.IIf (_NetworkConfig, "NetworkLicenseShare", "SingleLicenseFolder"));
						goto IL_0037;
						end_IL_0000_2:
						break;
					}
					num = 5;
					registryKey.Close ();
					break;
					end_IL_0000:;
				} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
					ProjectData.SetProjectError ((Exception)obj);
					try0000_dispatch = 117;
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
		}
	}

	internal string CompanyRegistryValue {
		get {
			int try0000_dispatch = -1;
			int num3 = default(int);
			int num2 = default(int);
			int num = default(int);
			string result = default(string);
			RegistryKey registryKey = default(RegistryKey);
			while (true) {
				try {
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					switch (try0000_dispatch) {
					default:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0007;
					case 124:
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
								goto IL_0007;
							case 3:
								goto IL_000f;
							case 4:
								goto IL_0022;
							case 6:
								goto IL_0028;
							case 7:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 5:
							case 8:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0028:
						num = 6;
						result = Conversions.ToString (registryKey.GetValue ("Hdg1", string.Empty));
						break;
						IL_0007:
						num = 2;
						result = string.Empty;
						goto IL_000f;
						IL_000f:
						num = 3;
						registryKey = Registry.CurrentUser.OpenSubKey ("Software\\RSG Software, Inc.\\CFS\\Heading");
						goto IL_0022;
						IL_0022:
						num = 4;
						if (registryKey == null) {
							goto end_IL_0000_3;
						}
						goto IL_0028;
						end_IL_0000_2:
						break;
					}
					num = 7;
					registryKey.Close ();
					break;
					end_IL_0000:;
				} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
					ProjectData.SetProjectError ((Exception)obj);
					try0000_dispatch = 124;
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
		set {
			int try0000_dispatch = -1;
			int num3 = default(int);
			int num2 = default(int);
			int num = default(int);
			RegistryKey registryKey = default(RegistryKey);
			while (true) {
				try {
					/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
					switch (try0000_dispatch) {
					default:
						ProjectData.ClearProjectError ();
						num3 = 1;
						goto IL_0007;
					case 86:
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
								goto IL_0007;
							case 3:
								goto IL_0019;
							case 4:
								goto end_IL_0000_2;
							default:
								goto end_IL_0000;
							case 5:
								goto end_IL_0000_3;
							}
							goto default;
						}
						IL_0019:
						num = 3;
						registryKey.SetValue ("Hdg1", value, RegistryValueKind.String);
						break;
						IL_0007:
						num = 2;
						registryKey = Registry.CurrentUser.CreateSubKey ("Software\\RSG Software, Inc.\\CFS\\Heading");
						goto IL_0019;
						end_IL_0000_2:
						break;
					}
					num = 4;
					registryKey.Close ();
					break;
					end_IL_0000:;
				} catch (object obj) when (obj is Exception && num3 != 0 && num2 == 0) {
					ProjectData.SetProjectError ((Exception)obj);
					try0000_dispatch = 86;
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
		}
	}

	internal string NetworkSemaphorePrefix => "CFSsema";

	internal bool IsNetworkConfiguration => _NetworkConfig;

	internal static int FreshEvaluationDuration => 0;

	internal static bool RefreshLicenseAlwaysRequired => false;

	internal static int RefreshLicenseAttemptFrequency => 4;

	internal static bool RefreshLicenseEnabled {
		get {
			if (!RefreshLicenseAlwaysRequired && RefreshLicenseAttemptFrequency == 0) {
				return RefreshLicenseRequireFrequency != 0;
			}
			return true;
		}
	}

	internal static int RefreshLicenseRequireFrequency => 28;

	internal static int RuntimeBackdateThresholdSeconds => 300;

	internal List<SystemIdentifierAlgorithm> SystemIdentifierAlgorithms {
		get {
			if (_NetworkConfig) {
				return new List<SystemIdentifierAlgorithm> (new SystemIdentifierAlgorithm[2] {
					new NetworkNameIdentifierAlgorithm (Path.GetDirectoryName (LicenseFilePath.ToLowerInvariant ())),
					new StringIdentifierAlgorithm (CompanyName.ToLowerInvariant ())
				});
			}
			if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
				return new List<SystemIdentifierAlgorithm> (new SystemIdentifierAlgorithm[5] {
					new UserNameIdentifierAlgorithm (),
					new ComputerNameIdentifierAlgorithm (),
					new HardDiskVolumeSerialIdentifierAlgorithm (HardDiskVolumeSerialFilterType.OperatingSystemRootVolume),
					new BiosUuidIdentifierAlgorithm (),
					new ProcessorIdentifierAlgorithm (new ProcessorIdentifierAlgorithmTypes[3] {
						ProcessorIdentifierAlgorithmTypes.ProcessorName,
						ProcessorIdentifierAlgorithmTypes.ProcessorVendor,
						ProcessorIdentifierAlgorithmTypes.ProcessorVersion
					})
				});
			}
			return new List<SystemIdentifierAlgorithm> (new SystemIdentifierAlgorithm[3] {
				new NicIdentifierAlgorithm (),
				new HardDiskVolumeSerialIdentifierAlgorithm (HardDiskVolumeSerialFilterType.OperatingSystemRootVolume),
				new ComputerNameIdentifierAlgorithm ()
			});
		}
	}

	internal static int TimeLimitedWarningDays => 30;

	internal static bool DownloadableLicenseOverwriteWithNewerAllowed => true;

	internal static bool DownloadableLicenseOverwriteWithOlderAllowed => true;

	internal static bool DownloadableLicenseOverwriteWithNewerRequiresActivation => false;

	internal static bool DownloadableLicenseOverwriteWithOlderRequiresActivation => true;

	internal static string VolumeLicenseFilePath => Path.Combine (ApplicationDirectory, "CFSVolumeLicense.lfx");

	internal static List<SystemIdentifierAlgorithm> VolumeSystemIdentifierAlgorithms => new List<SystemIdentifierAlgorithm> (new SystemIdentifierAlgorithm[1] {
		new LicenseIDIdentifierAlgorithm ()
	});

	public LicenseConfiguration (bool IsNetworkConfiguration)
	{
		_LicenseFilePath = "";
		_CompanyName = "";
		_NetworkConfig = IsNetworkConfiguration;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	internal void AppendLog (string strAction, NetworkSemaphore sema = null)
	{
		int num = FileSystem.FreeFile ();
		string fileName = Path.Combine (Path.GetDirectoryName (LicenseFilePath), "CFSLicense.log");
		try {
			FileSystem.FileOpen (num, fileName, OpenMode.Append, OpenAccess.Write, OpenShare.Shared);
			string text = Strings.Format (DateTime.UtcNow, "yyyyMMdd HH:mm:ss") + " " + Environment.UserName.PadRight (20) + " " + strAction.PadRight (12);
			if (sema != null) {
				text = text + " " + Conversions.ToString (sema.SeatsActive) + "/" + Conversions.ToString (sema.SeatsTotal);
			}
			FileSystem.PrintLine (num, text);
			FileSystem.FileClose (num);
		} catch (Exception ex) {
			ProjectData.SetProjectError (ex);
			Exception ex2 = ex;
			FileSystem.FileClose (num);
			ProjectData.ClearProjectError ();
		}
	}
}
