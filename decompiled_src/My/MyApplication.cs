// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using RSG.CFS;

namespace My;

[GeneratedCode ("MyTemplate", "11.0.0.0")]
[EditorBrowsable (EditorBrowsableState.Never)]
internal class MyApplication : WindowsFormsApplicationBase
{
	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	[STAThread]
	[DebuggerHidden]
	[EditorBrowsable (EditorBrowsableState.Advanced)]
	internal static void Main (string[] Args)
	{
		Application.SetCompatibleTextRenderingDefault (WindowsFormsApplicationBase.UseCompatibleTextRendering);
		MyProject.Application.Run (Args);
	}

	public void mdiCFS_Startup (object sender, StartupEventArgs e)
	{
		CFS.strAppPath = Path.GetDirectoryName (Application.ExecutablePath);
		if (Operators.CompareString (Strings.Right (CFS.strAppPath, 1), "\\", TextCompare: false) != 0) {
			CFS.strAppPath += "\\";
		}
		Cursor.Current = Cursors.WaitCursor;
		MyProject.Forms.frmSplash.Show ();
		MyProject.Forms.frmSplash.Refresh ();
		double timer = DateAndTime.Timer;
		CFS.InitializeLicense ();
		CFS.intSctNew = 0;
		CFS.intAnlNew = 0;
		CFS.intSctNow = 0;
		CFS.intAnlNow = 0;
		CFS.frmSctPic = new frmSctPicMaster[2];
		CFS.hdgSctPic = new Heading[2];
		CFS.hdgSctPic [1].Initialize ();
		CFS.frmReport = new frmReportMaster[2];
		CFS.hdgReport = new Heading[2];
		CFS.hdgReport [1].Initialize ();
		CFS.frmAnlPic = new frmAnlPicMaster[2];
		CFS.hdgAnlPic = new Heading[2];
		CFS.hdgAnlPic [1].Initialize ();
		PrinterSettings printerSettings = new PrinterSettings ();
		checked {
			int num = PrinterSettings.InstalledPrinters.Count - 1;
			for (int i = 0; i <= num; i++) {
				printerSettings.PrinterName = PrinterSettings.InstalledPrinters [i];
				if (printerSettings.IsDefaultPrinter) {
					CFSInterface.strPrinterName = printerSettings.PrinterName;
					break;
				}
			}
			CFSInterface.GetMaterials ();
			Units.InitializeFormats ();
			Units.InitializeUnits ();
			CFS.InitializeSpecs ();
			CFSInterface.MemberParametersNow.Lm = 240f;
			CFSInterface.MemberParametersNow.Kx = 1f;
			CFSInterface.MemberParametersNow.Ky = 1f;
			CFSInterface.MemberParametersNow.Kt = 1f;
			CFSInterface.MemberParametersNow.Cbx1 = 1f;
			CFSInterface.MemberParametersNow.Cby1 = 1f;
			CFSInterface.MemberParametersNow.Cmx = 1f;
			CFSInterface.MemberParametersNow.Cmy = 1f;
			CFSInterface.WebCripParametersNow.Dir = LoadDirections.dirY;
			CFSInterface.WebCripParametersNow.N = 1f;
			CFSInterface.WebCripParametersNow.Fastened = false;
			CFSInterface.BuckleParametersNow.Lmin = 1.5f;
			CFSInterface.BuckleParametersNow.Lmax = 150f;
			CFSInterface.BuckleParametersNow.Resolution = 2;
			CFSInterface.BuckleParametersNow.Fc = 1f;
			CFSInterface.BuckleParametersNow.Fbx = 0f;
			CFSInterface.BuckleParametersNow.Fby = 0f;
			CFSInterface.BuckleParametersNow.Constrained = false;
			CFSInterface.BuckleParametersNow.AltMethod = false;
			CFSInterface.BuckleParametersNow.Repeat = false;
			CFSInterface.InsertRibsNow.RibType = 1;
			CFSInterface.InsertRibsNow.RibHeight = 0.5f;
			CFSInterface.InsertRibsNow.Angle = 1.30899692f;
			CFSInterface.InsertRibsNow.RibWidth = 0.5f;
			CFSInterface.InsertRibsNow.NumRibs = 1;
			CFSInterface.RegistryHeading (0);
			CFSInterface.RegistryUnits (0);
			CFSInterface.RegistryMaterial (0);
			CFSInterface.RegistryThickness (0);
			CFSInterface.RegistryCombinations (0);
			CFS.Sections = new Section[2];
			int num2 = Information.UBound (CFS.Sections);
			for (int i = 0; i <= num2; i++) {
				CFS.Sections [i] = new Section ();
			}
			CFS.Analyses = new Analysis[2];
			int num3 = Information.UBound (CFS.Analyses);
			for (int i = 0; i <= num3; i++) {
				CFS.Analyses [i] = new Analysis ();
			}
			MyProject.Forms.mdiCFS.Show ();
			MyProject.Forms.mdiCFS.Refresh ();
			CFSInterface.RegistryRecentFiles (0);
			CFSInterface.RegistrySpec (0);
			CFSInterface.SetMenuSpec ();
			MyProject.Forms.mdiCFS.mnuToolsBucklingSpec.Checked = !CFS.blnBucklingTheory;
			MyProject.Forms.mdiCFS.mnuToolsBucklingTheory.Checked = CFS.blnBucklingTheory;
			CFSInterface.RegistryTrace (0);
			CFSInterface.SetMenuTrace ();
			CFSInterface.RegistryAssociations ();
			CFSInterface.RegistryView (0);
			MyProject.Forms.frmSplash.Activate ();
			int num4 = (int)Math.Round (1000.0 * (timer + 3.0 - DateAndTime.Timer));
			if (unchecked(num4 > 0 && num4 <= 3000)) {
				Thread.Sleep (num4);
			}
			MyProject.Forms.frmSplash.Close ();
			MyProject.Forms.frmSplash.Dispose ();
			if (CFS.intLicenseType == CFS.LicenseTypes.None) {
				MyProject.Forms.frmWelcome.ShowDialog (MyProject.Forms.mdiCFS);
				MyProject.Forms.frmWelcome.Dispose ();
			}
			string text = Interaction.Command ();
			if (Strings.Len (text) > 0) {
				if ((Operators.CompareString (Strings.Left (text, 1), "\"", TextCompare: false) == 0) & (Operators.CompareString (Strings.Right (text, 1), "\"", TextCompare: false) == 0)) {
					text = Strings.Trim (Strings.Mid (text, 2, Strings.Len (text) - 2));
				}
				Cursor.Current = Cursors.Default;
				CFSInterface.LoadFile (text);
			}
			CFSInterface.SetMenuFile ();
			CFSInterface.SetMenuEdit ();
			CFSInterface.SetMenuCompute ();
			Cursor.Current = Cursors.Default;
		}
	}

	private void mdiCFS_StartupNextInstance (object sender, StartupNextInstanceEventArgs e)
	{
		if (!MyProject.Forms.mdiCFS.Visible || !MyProject.Forms.mdiCFS.Enabled || !MyProject.Forms.mdiCFS.CanFocus || !MyProject.Forms.mdiCFS.CanSelect) {
			return;
		}
		IEnumerator enumerator = default(IEnumerator);
		try {
			enumerator = MyProject.Application.OpenForms.GetEnumerator ();
			while (enumerator.MoveNext ()) {
				if (((Form)enumerator.Current).Modal) {
					return;
				}
			}
		} finally {
			if (enumerator is IDisposable) {
				(enumerator as IDisposable).Dispose ();
			}
		}
		if (e.CommandLine.Count != 0) {
			string text = Strings.Trim (e.CommandLine [0]);
			if ((Operators.CompareString (Strings.Left (text, 1), "\"", TextCompare: false) == 0) & (Operators.CompareString (Strings.Right (text, 1), "\"", TextCompare: false) == 0)) {
				text = Strings.Trim (Strings.Mid (text, 2, checked(Strings.Len (text) - 2)));
			}
			if (Strings.Len (text) != 0) {
				CFSInterface.LoadFile (text);
			}
		}
	}

	private void mdiCFS_UnhandledException (object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
	{
		Interaction.MsgBox ("Unhandled Exception:" + e.Exception.ToString () + "\r\n" + e.Exception.StackTrace);
	}

	[DebuggerStepThrough]
	public MyApplication ()
		: base (AuthenticationMode.Windows)
	{
		base.Startup += mdiCFS_Startup;
		base.StartupNextInstance += mdiCFS_StartupNextInstance;
		base.UnhandledException += mdiCFS_UnhandledException;
		base.IsSingleInstance = true;
		base.EnableVisualStyles = false;
		base.SaveMySettingsOnExit = false;
		base.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
	}

	[DebuggerStepThrough]
	protected override void OnCreateMainForm ()
	{
		base.MainForm = MyProject.Forms.mdiCFS;
	}
}
