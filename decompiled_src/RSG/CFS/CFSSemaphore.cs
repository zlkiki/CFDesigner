// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Threading;
using System.Windows.Forms;
using com.softwarekey.Client.Licensing.Network;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

internal class CFSSemaphore : NetworkSemaphore
{
	private enum SearchStatuses
	{
		Dormant,
		Running,
		Success,
		Fail
	}

	private bool _IsActive;

	private SearchStatuses SearchStatus;

	public override bool IsValid {
		get {
			_IsActive = base.IsValid;
			return _IsActive;
		}
	}

	public bool IsActive => _IsActive;

	public CFSSemaphore (string strFolder, string strPrefix, int intSeats, bool blnRunValidation, int intValidationInterval, bool blnRunCleanup)
		: base (strFolder, strPrefix, intSeats, blnRunValidation, intValidationInterval, blnRunCleanup)
	{
		base.SearchProgress += CFSSemaphore_SearchProgress;
		base.SearchCompleted += CFSSemaphore_SearchCompleted;
		base.Invalid += CFSSemaphore_Invalid;
	}

	public override bool Open ()
	{
		_IsActive = base.Open ();
		return _IsActive;
	}

	public override void Close ()
	{
		base.Close ();
		_IsActive = false;
	}

	public bool GetUnusedNetworkLicense ()
	{
		string strAction = "No licenses";
		bool flag = false;
		Cursor.Current = Cursors.WaitCursor;
		SearchStatus = SearchStatuses.Running;
		base.CleanupThreadInterval = 1;
		Search ();
		double timer = DateAndTime.Timer;
		while (!(DateAndTime.Timer > timer + (double)checked(3 * CFS.NetworkLicense.LicenseCounter))) {
			Thread.Sleep (500);
			Application.DoEvents ();
			if (SearchStatus == SearchStatuses.Success) {
				flag = IsValid;
				strAction = Conversions.ToString (Interaction.IIf (flag, "Acquired", "Invalid"));
				break;
			}
			if (SearchStatus == SearchStatuses.Fail) {
				break;
			}
		}
		CFS.NetworkLicenseConfig.AppendLog (strAction, this);
		base.CleanupThreadInterval = 10;
		SearchStatus = SearchStatuses.Dormant;
		Cursor.Current = Cursors.Default;
		return flag;
	}

	private void CFSSemaphore_SearchProgress (object sender, SearchProgressEventArgs e)
	{
	}

	private void CFSSemaphore_SearchCompleted (object sender, SearchCompletedEventArgs e)
	{
		if (e.SeatOpened) {
			SearchStatus = SearchStatuses.Success;
		} else {
			SearchStatus = SearchStatuses.Fail;
		}
	}

	private void CFSSemaphore_Invalid (object sender, EventArgs e)
	{
		Close ();
		CFS.NetworkLicense = null;
		CFS.NetworkLicenseConfig.AppendLog ("Dropped");
	}
}
