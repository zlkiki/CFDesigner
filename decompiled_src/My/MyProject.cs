// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace My;

[StandardModule]
[HideModuleName]
[GeneratedCode ("MyTemplate", "11.0.0.0")]
internal sealed class MyProject
{
	[EditorBrowsable (EditorBrowsableState.Never)]
	[MyGroupCollection ("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	internal sealed class MyForms
	{
		[ThreadStatic]
		private static Hashtable m_FormBeingCreated;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmAbout m_frmAbout;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmAngle m_frmAngle;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmAnlInp m_frmAnlInp;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmAnlWizard m_frmAnlWizard;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBeamColumn m_frmBeamColumn;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBuckleParam m_frmBuckleParam;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBuckleParam2 m_frmBuckleParam2;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBuckleProfile m_frmBuckleProfile;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBuckleProgress m_frmBuckleProgress;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmBuckleValue m_frmBuckleValue;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmDiagrams m_frmDiagrams;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmEffProp m_frmEffProp;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmLicenseNetwork m_frmLicenseNetwork;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmLicenseRequired m_frmLicenseRequired;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmLicenseSingle m_frmLicenseSingle;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmLocation m_frmLocation;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmMaterial m_frmMaterial;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmMemberCheck m_frmMemberCheck;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmOpenLibSct m_frmOpenLibSct;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmOptions m_frmOptions;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmPrint m_frmPrint;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmQuickDesign m_frmQuickDesign;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmRecentFiles m_frmRecentFiles;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmReportDialog m_frmReportDialog;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmRibs m_frmRibs;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmSctInp m_frmSctInp;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmSctLib m_frmSctLib;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmSctWizard m_frmSctWizard;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmSplash m_frmSplash;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmViewText m_frmViewText;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmWebCrippling m_frmWebCrippling;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public frmWelcome m_frmWelcome;

		[EditorBrowsable (EditorBrowsableState.Never)]
		public mdiCFS m_mdiCFS;

		public frmAbout frmAbout {
			get {
				m_frmAbout = Create__Instance__ (m_frmAbout);
				return m_frmAbout;
			}
			set {
				if (value != m_frmAbout) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmAbout);
				}
			}
		}

		public frmAngle frmAngle {
			get {
				m_frmAngle = Create__Instance__ (m_frmAngle);
				return m_frmAngle;
			}
			set {
				if (value != m_frmAngle) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmAngle);
				}
			}
		}

		public frmAnlInp frmAnlInp {
			get {
				m_frmAnlInp = Create__Instance__ (m_frmAnlInp);
				return m_frmAnlInp;
			}
			set {
				if (value != m_frmAnlInp) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmAnlInp);
				}
			}
		}

		public frmAnlWizard frmAnlWizard {
			get {
				m_frmAnlWizard = Create__Instance__ (m_frmAnlWizard);
				return m_frmAnlWizard;
			}
			set {
				if (value != m_frmAnlWizard) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmAnlWizard);
				}
			}
		}

		public frmBeamColumn frmBeamColumn {
			get {
				m_frmBeamColumn = Create__Instance__ (m_frmBeamColumn);
				return m_frmBeamColumn;
			}
			set {
				if (value != m_frmBeamColumn) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBeamColumn);
				}
			}
		}

		public frmBuckleParam frmBuckleParam {
			get {
				m_frmBuckleParam = Create__Instance__ (m_frmBuckleParam);
				return m_frmBuckleParam;
			}
			set {
				if (value != m_frmBuckleParam) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBuckleParam);
				}
			}
		}

		public frmBuckleParam2 frmBuckleParam2 {
			get {
				m_frmBuckleParam2 = Create__Instance__ (m_frmBuckleParam2);
				return m_frmBuckleParam2;
			}
			set {
				if (value != m_frmBuckleParam2) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBuckleParam2);
				}
			}
		}

		public frmBuckleProfile frmBuckleProfile {
			get {
				m_frmBuckleProfile = Create__Instance__ (m_frmBuckleProfile);
				return m_frmBuckleProfile;
			}
			set {
				if (value != m_frmBuckleProfile) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBuckleProfile);
				}
			}
		}

		public frmBuckleProgress frmBuckleProgress {
			get {
				m_frmBuckleProgress = Create__Instance__ (m_frmBuckleProgress);
				return m_frmBuckleProgress;
			}
			set {
				if (value != m_frmBuckleProgress) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBuckleProgress);
				}
			}
		}

		public frmBuckleValue frmBuckleValue {
			get {
				m_frmBuckleValue = Create__Instance__ (m_frmBuckleValue);
				return m_frmBuckleValue;
			}
			set {
				if (value != m_frmBuckleValue) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmBuckleValue);
				}
			}
		}

		public frmDiagrams frmDiagrams {
			get {
				m_frmDiagrams = Create__Instance__ (m_frmDiagrams);
				return m_frmDiagrams;
			}
			set {
				if (value != m_frmDiagrams) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmDiagrams);
				}
			}
		}

		public frmEffProp frmEffProp {
			get {
				m_frmEffProp = Create__Instance__ (m_frmEffProp);
				return m_frmEffProp;
			}
			set {
				if (value != m_frmEffProp) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmEffProp);
				}
			}
		}

		public frmLicenseNetwork frmLicenseNetwork {
			get {
				m_frmLicenseNetwork = Create__Instance__ (m_frmLicenseNetwork);
				return m_frmLicenseNetwork;
			}
			set {
				if (value != m_frmLicenseNetwork) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmLicenseNetwork);
				}
			}
		}

		public frmLicenseRequired frmLicenseRequired {
			get {
				m_frmLicenseRequired = Create__Instance__ (m_frmLicenseRequired);
				return m_frmLicenseRequired;
			}
			set {
				if (value != m_frmLicenseRequired) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmLicenseRequired);
				}
			}
		}

		public frmLicenseSingle frmLicenseSingle {
			get {
				m_frmLicenseSingle = Create__Instance__ (m_frmLicenseSingle);
				return m_frmLicenseSingle;
			}
			set {
				if (value != m_frmLicenseSingle) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmLicenseSingle);
				}
			}
		}

		public frmLocation frmLocation {
			get {
				m_frmLocation = Create__Instance__ (m_frmLocation);
				return m_frmLocation;
			}
			set {
				if (value != m_frmLocation) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmLocation);
				}
			}
		}

		public frmMaterial frmMaterial {
			get {
				m_frmMaterial = Create__Instance__ (m_frmMaterial);
				return m_frmMaterial;
			}
			set {
				if (value != m_frmMaterial) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmMaterial);
				}
			}
		}

		public frmMemberCheck frmMemberCheck {
			get {
				m_frmMemberCheck = Create__Instance__ (m_frmMemberCheck);
				return m_frmMemberCheck;
			}
			set {
				if (value != m_frmMemberCheck) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmMemberCheck);
				}
			}
		}

		public frmOpenLibSct frmOpenLibSct {
			get {
				m_frmOpenLibSct = Create__Instance__ (m_frmOpenLibSct);
				return m_frmOpenLibSct;
			}
			set {
				if (value != m_frmOpenLibSct) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmOpenLibSct);
				}
			}
		}

		public frmOptions frmOptions {
			get {
				m_frmOptions = Create__Instance__ (m_frmOptions);
				return m_frmOptions;
			}
			set {
				if (value != m_frmOptions) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmOptions);
				}
			}
		}

		public frmPrint frmPrint {
			get {
				m_frmPrint = Create__Instance__ (m_frmPrint);
				return m_frmPrint;
			}
			set {
				if (value != m_frmPrint) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmPrint);
				}
			}
		}

		public frmQuickDesign frmQuickDesign {
			get {
				m_frmQuickDesign = Create__Instance__ (m_frmQuickDesign);
				return m_frmQuickDesign;
			}
			set {
				if (value != m_frmQuickDesign) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmQuickDesign);
				}
			}
		}

		public frmRecentFiles frmRecentFiles {
			get {
				m_frmRecentFiles = Create__Instance__ (m_frmRecentFiles);
				return m_frmRecentFiles;
			}
			set {
				if (value != m_frmRecentFiles) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmRecentFiles);
				}
			}
		}

		public frmReportDialog frmReportDialog {
			get {
				m_frmReportDialog = Create__Instance__ (m_frmReportDialog);
				return m_frmReportDialog;
			}
			set {
				if (value != m_frmReportDialog) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmReportDialog);
				}
			}
		}

		public frmRibs frmRibs {
			get {
				m_frmRibs = Create__Instance__ (m_frmRibs);
				return m_frmRibs;
			}
			set {
				if (value != m_frmRibs) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmRibs);
				}
			}
		}

		public frmSctInp frmSctInp {
			get {
				m_frmSctInp = Create__Instance__ (m_frmSctInp);
				return m_frmSctInp;
			}
			set {
				if (value != m_frmSctInp) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmSctInp);
				}
			}
		}

		public frmSctLib frmSctLib {
			get {
				m_frmSctLib = Create__Instance__ (m_frmSctLib);
				return m_frmSctLib;
			}
			set {
				if (value != m_frmSctLib) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmSctLib);
				}
			}
		}

		public frmSctWizard frmSctWizard {
			get {
				m_frmSctWizard = Create__Instance__ (m_frmSctWizard);
				return m_frmSctWizard;
			}
			set {
				if (value != m_frmSctWizard) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmSctWizard);
				}
			}
		}

		public frmSplash frmSplash {
			get {
				m_frmSplash = Create__Instance__ (m_frmSplash);
				return m_frmSplash;
			}
			set {
				if (value != m_frmSplash) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmSplash);
				}
			}
		}

		public frmViewText frmViewText {
			get {
				m_frmViewText = Create__Instance__ (m_frmViewText);
				return m_frmViewText;
			}
			set {
				if (value != m_frmViewText) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmViewText);
				}
			}
		}

		public frmWebCrippling frmWebCrippling {
			get {
				m_frmWebCrippling = Create__Instance__ (m_frmWebCrippling);
				return m_frmWebCrippling;
			}
			set {
				if (value != m_frmWebCrippling) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmWebCrippling);
				}
			}
		}

		public frmWelcome frmWelcome {
			get {
				m_frmWelcome = Create__Instance__ (m_frmWelcome);
				return m_frmWelcome;
			}
			set {
				if (value != m_frmWelcome) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_frmWelcome);
				}
			}
		}

		public mdiCFS mdiCFS {
			get {
				m_mdiCFS = Create__Instance__ (m_mdiCFS);
				return m_mdiCFS;
			}
			set {
				if (value != m_mdiCFS) {
					if (value != null) {
						throw new ArgumentException ("Property can only be set to Nothing");
					}
					Dispose__Instance__ (ref m_mdiCFS);
				}
			}
		}

		[DebuggerHidden]
		private static T Create__Instance__<T> (T Instance) where T : Form, new()
		{
			if (Instance == null || Instance.IsDisposed) {
				if (m_FormBeingCreated != null) {
					if (m_FormBeingCreated.ContainsKey (typeof(T))) {
						throw new InvalidOperationException (Utils.GetResourceString ("WinForms_RecursiveFormCreate"));
					}
				} else {
					m_FormBeingCreated = new Hashtable ();
				}
				m_FormBeingCreated.Add (typeof(T), null);
				try {
					return new T ();
				} catch (TargetInvocationException ex) when (((Func<bool>)delegate {
					// Could not convert BlockContainer to single expression
					ProjectData.SetProjectError (ex);
					return ex.InnerException != null;
				}).Invoke ()) {
					throw new InvalidOperationException (Utils.GetResourceString ("WinForms_SeeInnerException", ex.InnerException.Message), ex.InnerException);
				} finally {
					m_FormBeingCreated.Remove (typeof(T));
				}
			}
			return Instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T> (ref T instance) where T : Form
		{
			instance.Dispose ();
			instance = null;
		}

		[DebuggerHidden]
		[EditorBrowsable (EditorBrowsableState.Never)]
		public MyForms ()
		{
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		public override bool Equals (object o)
		{
			return base.Equals (RuntimeHelpers.GetObjectValue (o));
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		internal new Type GetType ()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		public override string ToString ()
		{
			return base.ToString ();
		}
	}

	[EditorBrowsable (EditorBrowsableState.Never)]
	[MyGroupCollection ("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class MyWebServices
	{
		[EditorBrowsable (EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals (object o)
		{
			return base.Equals (RuntimeHelpers.GetObjectValue (o));
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		[DebuggerHidden]
		internal new Type GetType ()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable (EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString ()
		{
			return base.ToString ();
		}

		[DebuggerHidden]
		private static T Create__Instance__<T> (T instance) where T : new()
		{
			if (instance == null) {
				return new T ();
			}
			return instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T> (ref T instance)
		{
			instance = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable (EditorBrowsableState.Never)]
		public MyWebServices ()
		{
		}
	}

	[EditorBrowsable (EditorBrowsableState.Never)]
	[ComVisible (false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		[CompilerGenerated]
		[ThreadStatic]
		private static T m_ThreadStaticValue;

		internal T GetInstance {
			[DebuggerHidden]
			get {
				if (m_ThreadStaticValue == null) {
					m_ThreadStaticValue = new T ();
				}
				return m_ThreadStaticValue;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable (EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider ()
		{
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer> ();

	private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication> ();

	private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User> ();

	private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms> ();

	private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices> ();

	[HelpKeyword ("My.Computer")]
	internal static MyComputer Computer {
		[DebuggerHidden]
		get {
			return m_ComputerObjectProvider.GetInstance;
		}
	}

	[HelpKeyword ("My.Application")]
	internal static MyApplication Application {
		[DebuggerHidden]
		get {
			return m_AppObjectProvider.GetInstance;
		}
	}

	[HelpKeyword ("My.User")]
	internal static User User {
		[DebuggerHidden]
		get {
			return m_UserObjectProvider.GetInstance;
		}
	}

	[HelpKeyword ("My.Forms")]
	internal static MyForms Forms {
		[DebuggerHidden]
		get {
			return m_MyFormsObjectProvider.GetInstance;
		}
	}

	[HelpKeyword ("My.WebServices")]
	internal static MyWebServices WebServices {
		[DebuggerHidden]
		get {
			return m_MyWebServicesObjectProvider.GetInstance;
		}
	}
}
