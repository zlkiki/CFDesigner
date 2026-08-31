// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class mdiCFS : Form
{
	private IContainer components;

	[SpecialName]
	private byte $STATIC$mdiCFS_Resize$20211C1280B1$bytWSPrev;

	internal virtual ToolStripMenuItem mnuHelpContents {
		[CompilerGenerated]
		get {
			return _mnuHelpContents;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuHelpContents_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuHelpContents;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuHelpContents = value;
			toolStripMenuItem = _mnuHelpContents;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuHelp")]
	internal virtual ToolStripMenuItem mnuHelp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuHelpIndex {
		[CompilerGenerated]
		get {
			return _mnuHelpIndex;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuHelpIndex_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuHelpIndex;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuHelpIndex = value;
			toolStripMenuItem = _mnuHelpIndex;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuHelpSearch {
		[CompilerGenerated]
		get {
			return _mnuHelpSearch;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuHelpSearch_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuHelpSearch;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuHelpSearch = value;
			toolStripMenuItem = _mnuHelpSearch;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuHelpSep1")]
	internal virtual ToolStripSeparator mnuHelpSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuHelpAbout {
		[CompilerGenerated]
		get {
			return _mnuHelpAbout;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuHelpAbout_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuHelpAbout;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuHelpAbout = value;
			toolStripMenuItem = _mnuHelpAbout;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindowsArrangeIcons {
		[CompilerGenerated]
		get {
			return _mnuWindowsArrangeIcons;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsArrangeIcons_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindowsArrangeIcons;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindowsArrangeIcons = value;
			toolStripMenuItem = _mnuWindowsArrangeIcons;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindowsCloseAll {
		[CompilerGenerated]
		get {
			return _mnuWindowsCloseAll;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsCloseAll_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindowsCloseAll;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindowsCloseAll = value;
			toolStripMenuItem = _mnuWindowsCloseAll;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindows {
		[CompilerGenerated]
		get {
			return _mnuWindows;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindows_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindows;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindows = value;
			toolStripMenuItem = _mnuWindows;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindowsCascade {
		[CompilerGenerated]
		get {
			return _mnuWindowsCascade;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsCascade_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindowsCascade;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindowsCascade = value;
			toolStripMenuItem = _mnuWindowsCascade;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindowsTileVertical {
		[CompilerGenerated]
		get {
			return _mnuWindowsTileVertical;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsTileVertical_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindowsTileVertical;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindowsTileVertical = value;
			toolStripMenuItem = _mnuWindowsTileVertical;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuWindowsTileHorizontal {
		[CompilerGenerated]
		get {
			return _mnuWindowsTileHorizontal;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsTileHorizontal_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuWindowsTileHorizontal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuWindowsTileHorizontal = value;
			toolStripMenuItem = _mnuWindowsTileHorizontal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsOptions {
		[CompilerGenerated]
		get {
			return _mnuToolsOptions;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsOptions_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsOptions;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsOptions = value;
			toolStripMenuItem = _mnuToolsOptions;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrHelp {
		[CompilerGenerated]
		get {
			return _tbrHelp;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tbrHelp_Click;
			ToolStripButton toolStripButton = _tbrHelp;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrHelp = value;
			toolStripButton = _tbrHelp;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrSepPrint")]
	internal virtual ToolStripSeparator tbrSepPrint {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrPrintPreview {
		[CompilerGenerated]
		get {
			return _tbrPrintPreview;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileReportInputs_Click;
			ToolStripButton toolStripButton = _tbrPrintPreview;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrPrintPreview = value;
			toolStripButton = _tbrPrintPreview;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("ToolTip")]
	internal virtual ToolTip ToolTip {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrPrint {
		[CompilerGenerated]
		get {
			return _tbrPrint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFilePrint_Click;
			ToolStripButton toolStripButton = _tbrPrint;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrPrint = value;
			toolStripButton = _tbrPrint;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrCFS")]
	internal virtual ToolStrip tbrCFS {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrOpen {
		[CompilerGenerated]
		get {
			return _tbrOpen;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileOpen_Click;
			ToolStripButton toolStripButton = _tbrOpen;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrOpen = value;
			toolStripButton = _tbrOpen;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrSave {
		[CompilerGenerated]
		get {
			return _tbrSave;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileSave_Click;
			ToolStripButton toolStripButton = _tbrSave;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrSave = value;
			toolStripButton = _tbrSave;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrSepFile")]
	internal virtual ToolStripSeparator tbrSepFile {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuFileReportInputs {
		[CompilerGenerated]
		get {
			return _mnuFileReportInputs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileReportInputs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileReportInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileReportInputs = value;
			toolStripMenuItem = _mnuFileReportInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFilePrint {
		[CompilerGenerated]
		get {
			return _mnuFilePrint;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFilePrint_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFilePrint;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFilePrint = value;
			toolStripMenuItem = _mnuFilePrint;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuFileSep2")]
	internal virtual ToolStripSeparator mnuFileSep2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuFileExit {
		[CompilerGenerated]
		get {
			return _mnuFileExit;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileExit_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileExit;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileExit = value;
			toolStripMenuItem = _mnuFileExit;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuFileSep3")]
	internal virtual ToolStripSeparator mnuFileSep3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuFileSaveAs {
		[CompilerGenerated]
		get {
			return _mnuFileSaveAs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileSaveAs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileSaveAs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileSaveAs = value;
			toolStripMenuItem = _mnuFileSaveAs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuFile")]
	internal virtual ToolStripMenuItem mnuFile {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuFileOpen {
		[CompilerGenerated]
		get {
			return _mnuFileOpen;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileOpen_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileOpen;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileOpen = value;
			toolStripMenuItem = _mnuFileOpen;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuFileSep1")]
	internal virtual ToolStripSeparator mnuFileSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuFileSave {
		[CompilerGenerated]
		get {
			return _mnuFileSave;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileSave_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileSave;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileSave = value;
			toolStripMenuItem = _mnuFileSave;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuCFS")]
	internal virtual MenuStrip mnuCFS {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("mnuEdit")]
	internal virtual ToolStripMenuItem mnuEdit {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditUndo {
		[CompilerGenerated]
		get {
			return _mnuEditUndo;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditUndo_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditUndo;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditUndo = value;
			toolStripMenuItem = _mnuEditUndo;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditRedo {
		[CompilerGenerated]
		get {
			return _mnuEditRedo;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditRedo_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditRedo;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditRedo = value;
			toolStripMenuItem = _mnuEditRedo;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditSep1")]
	internal virtual ToolStripSeparator mnuEditSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditCut {
		[CompilerGenerated]
		get {
			return _mnuEditCut;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCut_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditCut;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditCut = value;
			toolStripMenuItem = _mnuEditCut;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditCopy {
		[CompilerGenerated]
		get {
			return _mnuEditCopy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCopy_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditCopy;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditCopy = value;
			toolStripMenuItem = _mnuEditCopy;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPaste {
		[CompilerGenerated]
		get {
			return _mnuEditPaste;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditPaste_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPaste;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPaste = value;
			toolStripMenuItem = _mnuEditPaste;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditSep2")]
	internal virtual ToolStripSeparator mnuEditSep2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuView {
		[CompilerGenerated]
		get {
			return _mnuView;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuView_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuView;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuView = value;
			toolStripMenuItem = _mnuView;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuViewToolbar {
		[CompilerGenerated]
		get {
			return _mnuViewToolbar;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewToolbar_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewToolbar;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewToolbar = value;
			toolStripMenuItem = _mnuViewToolbar;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuTools {
		[CompilerGenerated]
		get {
			return _mnuTools;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuTools_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuTools;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuTools = value;
			toolStripMenuItem = _mnuTools;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileNewSection {
		[CompilerGenerated]
		get {
			return _mnuFileNewSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileNewSection_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileNewSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileNewSection = value;
			toolStripMenuItem = _mnuFileNewSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileNewAnalysis {
		[CompilerGenerated]
		get {
			return _mnuFileNewAnalysis;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileNewAnalysis_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileNewAnalysis;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileNewAnalysis = value;
			toolStripMenuItem = _mnuFileNewAnalysis;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileRecent {
		[CompilerGenerated]
		get {
			return _mnuFileRecent;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileRecent_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileRecent;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileRecent = value;
			toolStripMenuItem = _mnuFileRecent;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileImportDXF {
		[CompilerGenerated]
		get {
			return _mnuFileImportDXF;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileImportDXF_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileImportDXF;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileImportDXF = value;
			toolStripMenuItem = _mnuFileImportDXF;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileClose {
		[CompilerGenerated]
		get {
			return _mnuFileClose;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileClose_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileClose;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileClose = value;
			toolStripMenuItem = _mnuFileClose;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditInsert {
		[CompilerGenerated]
		get {
			return _mnuEditInsert;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditInsert_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditInsert;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditInsert = value;
			toolStripMenuItem = _mnuEditInsert;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditDelete {
		[CompilerGenerated]
		get {
			return _mnuEditDelete;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditDelete_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditDelete;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditDelete = value;
			toolStripMenuItem = _mnuEditDelete;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditRotate")]
	internal virtual ToolStripMenuItem mnuEditRotate {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditRotatePart {
		[CompilerGenerated]
		get {
			return _mnuEditRotatePart;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditRotatePart_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditRotatePart;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditRotatePart = value;
			toolStripMenuItem = _mnuEditRotatePart;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditRotateSection {
		[CompilerGenerated]
		get {
			return _mnuEditRotateSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditRotateSection_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditRotateSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditRotateSection = value;
			toolStripMenuItem = _mnuEditRotateSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditMirror")]
	internal virtual ToolStripMenuItem mnuEditMirror {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditMirrorPart {
		[CompilerGenerated]
		get {
			return _mnuEditMirrorPart;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditMirrorPart_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditMirrorPart;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditMirrorPart = value;
			toolStripMenuItem = _mnuEditMirrorPart;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditMirrorSection {
		[CompilerGenerated]
		get {
			return _mnuEditMirrorSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditMirrorSection_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditMirrorSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditMirrorSection = value;
			toolStripMenuItem = _mnuEditMirrorSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditSep3")]
	internal virtual ToolStripSeparator mnuEditSep3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditCenterSection {
		[CompilerGenerated]
		get {
			return _mnuEditCenterSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCenterSection_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditCenterSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditCenterSection = value;
			toolStripMenuItem = _mnuEditCenterSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditCompleteSymmetry {
		[CompilerGenerated]
		get {
			return _mnuEditCompleteSymmetry;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCompleteSymmetry_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditCompleteSymmetry;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditCompleteSymmetry = value;
			toolStripMenuItem = _mnuEditCompleteSymmetry;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditInsertRibs {
		[CompilerGenerated]
		get {
			return _mnuEditInsertRibs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditInsertRibs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditInsertRibs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditInsertRibs = value;
			toolStripMenuItem = _mnuEditInsertRibs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuViewInputsOnTop {
		[CompilerGenerated]
		get {
			return _mnuViewInputsOnTop;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewInputsOnTop_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewInputsOnTop;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewInputsOnTop = value;
			toolStripMenuItem = _mnuViewInputsOnTop;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuViewSectionInputs {
		[CompilerGenerated]
		get {
			return _mnuViewSectionInputs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewSectionInputs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewSectionInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewSectionInputs = value;
			toolStripMenuItem = _mnuViewSectionInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuViewAnalysisInputs {
		[CompilerGenerated]
		get {
			return _mnuViewAnalysisInputs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewAnalysisInputs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewAnalysisInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewAnalysisInputs = value;
			toolStripMenuItem = _mnuViewAnalysisInputs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuCompute")]
	internal virtual ToolStripMenuItem mnuCompute {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuComputeProperties {
		[CompilerGenerated]
		get {
			return _mnuComputeProperties;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeProperties_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeProperties = value;
			toolStripMenuItem = _mnuComputeProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeStrength {
		[CompilerGenerated]
		get {
			return _mnuComputeStrength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeStrength_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeStrength;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeStrength = value;
			toolStripMenuItem = _mnuComputeStrength;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeMemberCheck {
		[CompilerGenerated]
		get {
			return _mnuComputeMemberCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeMemberCheck_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeMemberCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeMemberCheck = value;
			toolStripMenuItem = _mnuComputeMemberCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeWebCheck {
		[CompilerGenerated]
		get {
			return _mnuComputeWebCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeWebCheck_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeWebCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeWebCheck = value;
			toolStripMenuItem = _mnuComputeWebCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuComputeSep1")]
	internal virtual ToolStripSeparator mnuComputeSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuComputeTorsionProperties {
		[CompilerGenerated]
		get {
			return _mnuComputeTorsionProperties;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeTorsionProperties_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeTorsionProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeTorsionProperties = value;
			toolStripMenuItem = _mnuComputeTorsionProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeElasticBuckling {
		[CompilerGenerated]
		get {
			return _mnuComputeElasticBuckling;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeElasticBuckling_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeElasticBuckling;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeElasticBuckling = value;
			toolStripMenuItem = _mnuComputeElasticBuckling;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeDiagrams {
		[CompilerGenerated]
		get {
			return _mnuComputeDiagrams;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeDiagrams_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeDiagrams;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeDiagrams = value;
			toolStripMenuItem = _mnuComputeDiagrams;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec")]
	internal virtual ToolStripMenuItem mnuToolsSpec {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2012")]
	internal virtual ToolStripMenuItem mnuToolsSpec2012 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2012USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2012USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2012USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2012USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2012USASD = value;
			toolStripMenuItem = _mnuToolsSpec2012USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2012USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2012USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2012USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2012USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2012USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2012USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2012MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2012MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2012MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2012MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2012MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2012MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2012MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2012MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2012MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2012MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2012MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2012MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2012CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2012CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2012CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2012CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2012CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2012CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2010")]
	internal virtual ToolStripMenuItem mnuToolsSpec2010 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2010USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2010USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2010USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2010USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2010USASD = value;
			toolStripMenuItem = _mnuToolsSpec2010USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2010USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2010USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2010USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2010USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2010USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2010USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2010MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2010MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2010MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2010MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2010MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2010MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2010MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2010MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2010MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2010MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2010MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2010MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2010CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2010CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2010CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2010CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2010CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2010CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2007")]
	internal virtual ToolStripMenuItem mnuToolsSpec2007 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2007USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2007USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2007USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2007USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2007USASD = value;
			toolStripMenuItem = _mnuToolsSpec2007USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2007USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2007USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2007USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2007USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2007USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2007USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2007MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2007MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2007MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2007MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2007MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2007MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2007MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2007MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2007MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2007MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2007MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2007MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2007CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2007CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2007CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2007CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2007CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2007CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2004")]
	internal virtual ToolStripMenuItem mnuToolsSpec2004 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2004USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2004USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2004USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2004USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2004USASD = value;
			toolStripMenuItem = _mnuToolsSpec2004USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2004USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2004USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2004USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2004USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2004USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2004USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2004MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2004MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2004MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2004MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2004MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2004MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2004MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2004MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2004MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2004MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2004MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2004MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2004CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2004CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2004CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2004CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2004CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2004CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2001")]
	internal virtual ToolStripMenuItem mnuToolsSpec2001 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2001USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2001USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2001USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2001USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2001USASD = value;
			toolStripMenuItem = _mnuToolsSpec2001USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2001USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2001USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2001USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2001USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2001USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2001USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2001MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2001MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2001MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2001MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2001MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2001MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2001MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2001MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2001MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2001MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2001MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2001MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2001CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2001CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2001CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2001CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2001CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2001CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec1999")]
	internal virtual ToolStripMenuItem mnuToolsSpec1999 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec1999ASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec1999ASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec1999ASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec1999ASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec1999ASD = value;
			toolStripMenuItem = _mnuToolsSpec1999ASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec1999LRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec1999LRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec1999LRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec1999LRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec1999LRFD = value;
			toolStripMenuItem = _mnuToolsSpec1999LRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsTrace")]
	internal virtual ToolStripMenuItem mnuToolsTrace {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsTraceAll {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceAll;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceAll_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceAll;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceAll = value;
			toolStripMenuItem = _mnuToolsTraceAll;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsTraceStrength {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceStrength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceStrength_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceStrength;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceStrength = value;
			toolStripMenuItem = _mnuToolsTraceStrength;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsTraceMemberCheck {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceMemberCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceMemberCheck_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceMemberCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceMemberCheck = value;
			toolStripMenuItem = _mnuToolsTraceMemberCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsTraceWebCheck {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceWebCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceWebCheck_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceWebCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceWebCheck = value;
			toolStripMenuItem = _mnuToolsTraceWebCheck;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsTraceEffectiveSection {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceEffectiveSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceEffectiveSection_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceEffectiveSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceEffectiveSection = value;
			toolStripMenuItem = _mnuToolsTraceEffectiveSection;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSep1")]
	internal virtual ToolStripSeparator mnuToolsSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("mnuToolsLicense")]
	internal virtual ToolStripMenuItem mnuToolsLicense {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsPurchaseLicense {
		[CompilerGenerated]
		get {
			return _mnuToolsPurchaseLicense;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsPurchaseLicense_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsPurchaseLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsPurchaseLicense = value;
			toolStripMenuItem = _mnuToolsPurchaseLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSep2")]
	internal virtual ToolStripSeparator mnuToolsSep2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSectionGenerator {
		[CompilerGenerated]
		get {
			return _mnuToolsSectionGenerator;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSectionGenerator_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSectionGenerator;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSectionGenerator = value;
			toolStripMenuItem = _mnuToolsSectionGenerator;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsLibraryBuilder {
		[CompilerGenerated]
		get {
			return _mnuToolsLibraryBuilder;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsLibraryBuilder_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsLibraryBuilder;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsLibraryBuilder = value;
			toolStripMenuItem = _mnuToolsLibraryBuilder;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuHelpRSGSoftware {
		[CompilerGenerated]
		get {
			return _mnuHelpRSGSoftware;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuHelpRSGSoftware_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuHelpRSGSoftware;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuHelpRSGSoftware = value;
			toolStripMenuItem = _mnuHelpRSGSoftware;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuHelpSep2")]
	internal virtual ToolStripSeparator mnuHelpSep2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrNewSection {
		[CompilerGenerated]
		get {
			return _tbrNewSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileNewSection_Click;
			ToolStripButton toolStripButton = _tbrNewSection;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrNewSection = value;
			toolStripButton = _tbrNewSection;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrNewAnalysis {
		[CompilerGenerated]
		get {
			return _tbrNewAnalysis;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileNewAnalysis_Click;
			ToolStripButton toolStripButton = _tbrNewAnalysis;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrNewAnalysis = value;
			toolStripButton = _tbrNewAnalysis;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrRecent {
		[CompilerGenerated]
		get {
			return _tbrRecent;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileRecent_Click;
			ToolStripButton toolStripButton = _tbrRecent;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrRecent = value;
			toolStripButton = _tbrRecent;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrCut {
		[CompilerGenerated]
		get {
			return _tbrCut;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCut_Click;
			ToolStripButton toolStripButton = _tbrCut;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrCut = value;
			toolStripButton = _tbrCut;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrCopy {
		[CompilerGenerated]
		get {
			return _tbrCopy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCopy_Click;
			ToolStripButton toolStripButton = _tbrCopy;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrCopy = value;
			toolStripButton = _tbrCopy;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrPaste {
		[CompilerGenerated]
		get {
			return _tbrPaste;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditPaste_Click;
			ToolStripButton toolStripButton = _tbrPaste;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrPaste = value;
			toolStripButton = _tbrPaste;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrSepEdit")]
	internal virtual ToolStripSeparator tbrSepEdit {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrUndo {
		[CompilerGenerated]
		get {
			return _tbrUndo;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditUndo_Click;
			ToolStripButton toolStripButton = _tbrUndo;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrUndo = value;
			toolStripButton = _tbrUndo;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrProperties {
		[CompilerGenerated]
		get {
			return _tbrProperties;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeProperties_Click;
			ToolStripButton toolStripButton = _tbrProperties;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrProperties = value;
			toolStripButton = _tbrProperties;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrStrength {
		[CompilerGenerated]
		get {
			return _tbrStrength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeStrength_Click;
			ToolStripButton toolStripButton = _tbrStrength;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrStrength = value;
			toolStripButton = _tbrStrength;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrMemberCheck {
		[CompilerGenerated]
		get {
			return _tbrMemberCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeMemberCheck_Click;
			ToolStripButton toolStripButton = _tbrMemberCheck;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrMemberCheck = value;
			toolStripButton = _tbrMemberCheck;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrWebCheck {
		[CompilerGenerated]
		get {
			return _tbrWebCheck;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeWebCheck_Click;
			ToolStripButton toolStripButton = _tbrWebCheck;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrWebCheck = value;
			toolStripButton = _tbrWebCheck;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrDiagrams {
		[CompilerGenerated]
		get {
			return _tbrDiagrams;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeDiagrams_Click;
			ToolStripButton toolStripButton = _tbrDiagrams;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrDiagrams = value;
			toolStripButton = _tbrDiagrams;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrSepCompute")]
	internal virtual ToolStripSeparator tbrSepCompute {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("dlgGetFolder")]
	internal virtual FolderBrowserDialog dlgGetFolder {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrRedo {
		[CompilerGenerated]
		get {
			return _tbrRedo;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditRedo_Click;
			ToolStripButton toolStripButton = _tbrRedo;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrRedo = value;
			toolStripButton = _tbrRedo;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ContextMenuStrip mnuEditPopup {
		[CompilerGenerated]
		get {
			return _mnuEditPopup;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			CancelEventHandler value2 = EditPopupMenu_Opening;
			ContextMenuStrip contextMenuStrip = _mnuEditPopup;
			if (contextMenuStrip != null) {
				contextMenuStrip.Opening -= value2;
			}
			_mnuEditPopup = value;
			contextMenuStrip = _mnuEditPopup;
			if (contextMenuStrip != null) {
				contextMenuStrip.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupCut {
		[CompilerGenerated]
		get {
			return _mnuEditPopupCut;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCut_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupCut;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupCut = value;
			toolStripMenuItem = _mnuEditPopupCut;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupCopy {
		[CompilerGenerated]
		get {
			return _mnuEditPopupCopy;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCopy_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupCopy;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupCopy = value;
			toolStripMenuItem = _mnuEditPopupCopy;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupPaste {
		[CompilerGenerated]
		get {
			return _mnuEditPopupPaste;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditPaste_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupPaste;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupPaste = value;
			toolStripMenuItem = _mnuEditPopupPaste;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupInsert {
		[CompilerGenerated]
		get {
			return _mnuEditPopupInsert;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditInsert_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupInsert;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupInsert = value;
			toolStripMenuItem = _mnuEditPopupInsert;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuEditPopupSep1")]
	internal virtual ToolStripSeparator mnuEditPopupSep1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuEditPopupDelete {
		[CompilerGenerated]
		get {
			return _mnuEditPopupDelete;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditDelete_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupDelete;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupDelete = value;
			toolStripMenuItem = _mnuEditPopupDelete;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupInsertRibs {
		[CompilerGenerated]
		get {
			return _mnuEditPopupInsertRibs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditInsertRibs_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupInsertRibs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupInsertRibs = value;
			toolStripMenuItem = _mnuEditPopupInsertRibs;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("dlgOpenFile")]
	internal virtual OpenFileDialog dlgOpenFile {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("dlgSaveFile")]
	internal virtual SaveFileDialog dlgSaveFile {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("CFSHelp")]
	internal virtual HelpProvider CFSHelp {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("dlgPrint")]
	internal virtual PrintDialog dlgPrint {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripButton tbrElasticBuckling {
		[CompilerGenerated]
		get {
			return _tbrElasticBuckling;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeElasticBuckling_Click;
			ToolStripButton toolStripButton = _tbrElasticBuckling;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrElasticBuckling = value;
			toolStripButton = _tbrElasticBuckling;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuViewRenderMembers {
		[CompilerGenerated]
		get {
			return _mnuViewRenderMembers;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewRenderMembers_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewRenderMembers;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewRenderMembers = value;
			toolStripMenuItem = _mnuViewRenderMembers;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditPopupCopyImage {
		[CompilerGenerated]
		get {
			return _mnuEditPopupCopyImage;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCopyImage_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditPopupCopyImage;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditPopupCopyImage = value;
			toolStripMenuItem = _mnuEditPopupCopyImage;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditCopyImage {
		[CompilerGenerated]
		get {
			return _mnuEditCopyImage;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditCopyImage_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditCopyImage;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditCopyImage = value;
			toolStripMenuItem = _mnuEditCopyImage;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2016")]
	internal virtual ToolStripMenuItem mnuToolsSpec2016 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2016USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2016USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2016USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2016USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2016USASD = value;
			toolStripMenuItem = _mnuToolsSpec2016USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2016USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2016USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2016USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2016USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2016USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2016USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2016MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2016MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2016MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2016MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2016MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2016MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2016MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2016MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2016MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2016MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2016MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2016MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2016CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2016CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2016CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2016CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2016CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2016CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrGenerate {
		[CompilerGenerated]
		get {
			return _tbrGenerate;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = tbrGenerate_Click;
			ToolStripButton toolStripButton = _tbrGenerate;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrGenerate = value;
			toolStripButton = _tbrGenerate;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrCascade {
		[CompilerGenerated]
		get {
			return _tbrCascade;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsCascade_Click;
			ToolStripButton toolStripButton = _tbrCascade;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrCascade = value;
			toolStripButton = _tbrCascade;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrTileVertical {
		[CompilerGenerated]
		get {
			return _tbrTileVertical;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsTileVertical_Click;
			ToolStripButton toolStripButton = _tbrTileVertical;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrTileVertical = value;
			toolStripButton = _tbrTileVertical;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrTileHorizontal {
		[CompilerGenerated]
		get {
			return _tbrTileHorizontal;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuWindowsTileHorizontal_Click;
			ToolStripButton toolStripButton = _tbrTileHorizontal;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrTileHorizontal = value;
			toolStripButton = _tbrTileHorizontal;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("tbrSepWindow")]
	internal virtual ToolStripSeparator tbrSepWindow {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuViewXYAxes {
		[CompilerGenerated]
		get {
			return _mnuViewXYAxes;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuViewXYAxes_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuViewXYAxes;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuViewXYAxes = value;
			toolStripMenuItem = _mnuViewXYAxes;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrSaveAs {
		[CompilerGenerated]
		get {
			return _tbrSaveAs;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileSaveAs_Click;
			ToolStripButton toolStripButton = _tbrSaveAs;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrSaveAs = value;
			toolStripButton = _tbrSaveAs;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsNetworkLicense {
		[CompilerGenerated]
		get {
			return _mnuToolsNetworkLicense;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsNetworkLicense_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsNetworkLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsNetworkLicense = value;
			toolStripMenuItem = _mnuToolsNetworkLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSingleUserLicense {
		[CompilerGenerated]
		get {
			return _mnuToolsSingleUserLicense;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSingleUserLicense_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSingleUserLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSingleUserLicense = value;
			toolStripMenuItem = _mnuToolsSingleUserLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsRenewLicense {
		[CompilerGenerated]
		get {
			return _mnuToolsRenewLicense;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsRenewLicense_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsRenewLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsRenewLicense = value;
			toolStripMenuItem = _mnuToolsRenewLicense;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuFileQuickDesign {
		[CompilerGenerated]
		get {
			return _mnuFileQuickDesign;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileQuickDesign_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuFileQuickDesign;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuFileQuickDesign = value;
			toolStripMenuItem = _mnuFileQuickDesign;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrQuickDesign {
		[CompilerGenerated]
		get {
			return _tbrQuickDesign;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuFileQuickDesign_Click;
			ToolStripButton toolStripButton = _tbrQuickDesign;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrQuickDesign = value;
			toolStripButton = _tbrQuickDesign;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2018")]
	internal virtual ToolStripMenuItem mnuToolsSpec2018 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2018USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2018USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2018USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2018USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2018USASD = value;
			toolStripMenuItem = _mnuToolsSpec2018USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2018USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2018USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2018USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2018USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2018USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2018USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2018MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2018MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2018MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2018MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2018MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2018MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2018MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2018MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2018MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2018MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2018MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2018MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2018CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2018CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2018CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2018CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2018CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2018CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsLicensePortal {
		[CompilerGenerated]
		get {
			return _mnuToolsLicensePortal;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsLicensePortal_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsLicensePortal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsLicensePortal = value;
			toolStripMenuItem = _mnuToolsLicensePortal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsBuckling")]
	internal virtual ToolStripMenuItem mnuToolsBuckling {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsBucklingSpec {
		[CompilerGenerated]
		get {
			return _mnuToolsBucklingSpec;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsBucklingSpec_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsBucklingSpec;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsBucklingSpec = value;
			toolStripMenuItem = _mnuToolsBucklingSpec;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsBucklingTheory {
		[CompilerGenerated]
		get {
			return _mnuToolsBucklingTheory;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsBucklingTheory_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsBucklingTheory;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsBucklingTheory = value;
			toolStripMenuItem = _mnuToolsBucklingTheory;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuEditRotatePrincipal {
		[CompilerGenerated]
		get {
			return _mnuEditRotatePrincipal;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuEditRotatePrincipal_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuEditRotatePrincipal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuEditRotatePrincipal = value;
			toolStripMenuItem = _mnuEditRotatePrincipal;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuComputeEffProperties {
		[CompilerGenerated]
		get {
			return _mnuComputeEffProperties;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeEffProperties_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuComputeEffProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuComputeEffProperties = value;
			toolStripMenuItem = _mnuComputeEffProperties;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripButton tbrEffProperties {
		[CompilerGenerated]
		get {
			return _tbrEffProperties;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuComputeEffProperties_Click;
			ToolStripButton toolStripButton = _tbrEffProperties;
			if (toolStripButton != null) {
				toolStripButton.Click -= value2;
			}
			_tbrEffProperties = value;
			toolStripButton = _tbrEffProperties;
			if (toolStripButton != null) {
				toolStripButton.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("mnuToolsSpec2022")]
	internal virtual ToolStripMenuItem mnuToolsSpec2022 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2022USASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2022USASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2022USASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2022USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2022USASD = value;
			toolStripMenuItem = _mnuToolsSpec2022USASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2022USLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2022USLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2022USLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2022USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2022USLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2022USLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2022MexicoASD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2022MexicoASD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2022MexicoASD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2022MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2022MexicoASD = value;
			toolStripMenuItem = _mnuToolsSpec2022MexicoASD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2022MexicoLRFD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2022MexicoLRFD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2022MexicoLRFD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2022MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2022MexicoLRFD = value;
			toolStripMenuItem = _mnuToolsSpec2022MexicoLRFD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsSpec2022CanadaLSD {
		[CompilerGenerated]
		get {
			return _mnuToolsSpec2022CanadaLSD;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsSpec2022CanadaLSD_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsSpec2022CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsSpec2022CanadaLSD = value;
			toolStripMenuItem = _mnuToolsSpec2022CanadaLSD;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem mnuToolsTraceColdWork {
		[CompilerGenerated]
		get {
			return _mnuToolsTraceColdWork;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = mnuToolsTraceColdWork_Click;
			ToolStripMenuItem toolStripMenuItem = _mnuToolsTraceColdWork;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click -= value2;
			}
			_mnuToolsTraceColdWork = value;
			toolStripMenuItem = _mnuToolsTraceColdWork;
			if (toolStripMenuItem != null) {
				toolStripMenuItem.Click += value2;
			}
		}
	}

	public mdiCFS ()
	{
		base.Load += mdiCFS_Load;
		base.Resize += mdiCFS_Resize;
		base.KeyDown += mdiCFS_KeyDown;
		base.DragOver += mdiCFS_DragOver;
		base.DragDrop += mdiCFS_DragDrop;
		base.FormClosing += mdiCFS_FormClosing;
		base.FormClosed += mdiCFS_FormClosed;
		InitializeComponent ();
	}

	[DebuggerNonUserCode]
	protected override void Dispose (bool disposing)
	{
		try {
			if (disposing && components != null) {
				components.Dispose ();
			}
		} finally {
			base.Dispose (disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent ()
	{
		this.components = new System.ComponentModel.Container ();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(mdiCFS));
		this.mnuCFS = new System.Windows.Forms.MenuStrip ();
		this.mnuFile = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileNewSection = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileNewAnalysis = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileQuickDesign = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileRecent = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileImportDXF = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileClose = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileSep2 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuFileReportInputs = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuFileSep3 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditRedo = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditCopyImage = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditSep2 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuEditInsert = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditRotate = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditRotatePart = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditRotateSection = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditRotatePrincipal = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditMirror = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditMirrorPart = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditMirrorSection = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditSep3 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuEditCenterSection = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditCompleteSymmetry = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditInsertRibs = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuView = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewToolbar = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewInputsOnTop = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewSectionInputs = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewAnalysisInputs = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewRenderMembers = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuViewXYAxes = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuCompute = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeProperties = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeEffProperties = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeStrength = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeMemberCheck = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeWebCheck = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuComputeTorsionProperties = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeElasticBuckling = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuComputeDiagrams = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuTools = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2022CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2018CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2016CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2012CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2010CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2007CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2004CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001USASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001USLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001MexicoASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001MexicoLRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec2001CanadaLSD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec1999 = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec1999ASD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSpec1999LRFD = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsBuckling = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsBucklingSpec = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsBucklingTheory = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTrace = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceAll = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceStrength = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceMemberCheck = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceWebCheck = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceEffectiveSection = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsTraceColdWork = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuToolsOptions = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsLicense = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsPurchaseLicense = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsRenewLicense = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSingleUserLicense = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsNetworkLicense = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsLicensePortal = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsSep2 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuToolsSectionGenerator = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuToolsLibraryBuilder = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindowsCascade = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindowsTileVertical = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindowsTileHorizontal = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindowsArrangeIcons = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuWindowsCloseAll = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelpContents = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelpIndex = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelpSearch = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelpSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuHelpRSGSoftware = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuHelpSep2 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem ();
		this.tbrCFS = new System.Windows.Forms.ToolStrip ();
		this.tbrNewSection = new System.Windows.Forms.ToolStripButton ();
		this.tbrNewAnalysis = new System.Windows.Forms.ToolStripButton ();
		this.tbrQuickDesign = new System.Windows.Forms.ToolStripButton ();
		this.tbrOpen = new System.Windows.Forms.ToolStripButton ();
		this.tbrRecent = new System.Windows.Forms.ToolStripButton ();
		this.tbrSave = new System.Windows.Forms.ToolStripButton ();
		this.tbrSaveAs = new System.Windows.Forms.ToolStripButton ();
		this.tbrSepFile = new System.Windows.Forms.ToolStripSeparator ();
		this.tbrPrintPreview = new System.Windows.Forms.ToolStripButton ();
		this.tbrPrint = new System.Windows.Forms.ToolStripButton ();
		this.tbrSepPrint = new System.Windows.Forms.ToolStripSeparator ();
		this.tbrCut = new System.Windows.Forms.ToolStripButton ();
		this.tbrCopy = new System.Windows.Forms.ToolStripButton ();
		this.tbrPaste = new System.Windows.Forms.ToolStripButton ();
		this.tbrUndo = new System.Windows.Forms.ToolStripButton ();
		this.tbrRedo = new System.Windows.Forms.ToolStripButton ();
		this.tbrSepEdit = new System.Windows.Forms.ToolStripSeparator ();
		this.tbrProperties = new System.Windows.Forms.ToolStripButton ();
		this.tbrEffProperties = new System.Windows.Forms.ToolStripButton ();
		this.tbrStrength = new System.Windows.Forms.ToolStripButton ();
		this.tbrMemberCheck = new System.Windows.Forms.ToolStripButton ();
		this.tbrWebCheck = new System.Windows.Forms.ToolStripButton ();
		this.tbrElasticBuckling = new System.Windows.Forms.ToolStripButton ();
		this.tbrDiagrams = new System.Windows.Forms.ToolStripButton ();
		this.tbrSepCompute = new System.Windows.Forms.ToolStripSeparator ();
		this.tbrCascade = new System.Windows.Forms.ToolStripButton ();
		this.tbrTileVertical = new System.Windows.Forms.ToolStripButton ();
		this.tbrTileHorizontal = new System.Windows.Forms.ToolStripButton ();
		this.tbrSepWindow = new System.Windows.Forms.ToolStripSeparator ();
		this.tbrHelp = new System.Windows.Forms.ToolStripButton ();
		this.tbrGenerate = new System.Windows.Forms.ToolStripButton ();
		this.ToolTip = new System.Windows.Forms.ToolTip (this.components);
		this.dlgGetFolder = new System.Windows.Forms.FolderBrowserDialog ();
		this.mnuEditPopup = new System.Windows.Forms.ContextMenuStrip (this.components);
		this.mnuEditPopupCut = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupCopy = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupPaste = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupCopyImage = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupSep1 = new System.Windows.Forms.ToolStripSeparator ();
		this.mnuEditPopupInsert = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupDelete = new System.Windows.Forms.ToolStripMenuItem ();
		this.mnuEditPopupInsertRibs = new System.Windows.Forms.ToolStripMenuItem ();
		this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog ();
		this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog ();
		this.CFSHelp = new System.Windows.Forms.HelpProvider ();
		this.dlgPrint = new System.Windows.Forms.PrintDialog ();
		this.mnuCFS.SuspendLayout ();
		this.tbrCFS.SuspendLayout ();
		this.mnuEditPopup.SuspendLayout ();
		base.SuspendLayout ();
		this.mnuCFS.Items.AddRange (new System.Windows.Forms.ToolStripItem[7] { this.mnuFile, this.mnuEdit, this.mnuView, this.mnuCompute, this.mnuTools, this.mnuWindows, this.mnuHelp });
		this.mnuCFS.Location = new System.Drawing.Point (0, 0);
		this.mnuCFS.MdiWindowListItem = this.mnuWindows;
		this.mnuCFS.Name = "mnuCFS";
		this.mnuCFS.Size = new System.Drawing.Size (664, 24);
		this.mnuCFS.TabIndex = 5;
		this.mnuCFS.Text = "CFS Menu Bar";
		this.mnuFile.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[15] {
			this.mnuFileNewSection, this.mnuFileNewAnalysis, this.mnuFileQuickDesign, this.mnuFileOpen, this.mnuFileRecent, this.mnuFileImportDXF, this.mnuFileSep1, this.mnuFileSave, this.mnuFileSaveAs, this.mnuFileClose,
			this.mnuFileSep2, this.mnuFileReportInputs, this.mnuFilePrint, this.mnuFileSep3, this.mnuFileExit
		});
		this.mnuFile.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
		this.mnuFile.Name = "mnuFile";
		this.mnuFile.Size = new System.Drawing.Size (37, 20);
		this.mnuFile.Text = "&File";
		this.mnuFileNewSection.Image = (System.Drawing.Image)resources.GetObject ("mnuFileNewSection.Image");
		this.mnuFileNewSection.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileNewSection.Name = "mnuFileNewSection";
		this.mnuFileNewSection.Size = new System.Drawing.Size (153, 22);
		this.mnuFileNewSection.Text = "&New Section...";
		this.mnuFileNewAnalysis.Image = (System.Drawing.Image)resources.GetObject ("mnuFileNewAnalysis.Image");
		this.mnuFileNewAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileNewAnalysis.Name = "mnuFileNewAnalysis";
		this.mnuFileNewAnalysis.Size = new System.Drawing.Size (153, 22);
		this.mnuFileNewAnalysis.Text = "N&ew Analysis...";
		this.mnuFileQuickDesign.Image = (System.Drawing.Image)resources.GetObject ("mnuFileQuickDesign.Image");
		this.mnuFileQuickDesign.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileQuickDesign.Name = "mnuFileQuickDesign";
		this.mnuFileQuickDesign.Size = new System.Drawing.Size (153, 22);
		this.mnuFileQuickDesign.Text = "&Quick Design...";
		this.mnuFileOpen.Image = (System.Drawing.Image)resources.GetObject ("mnuFileOpen.Image");
		this.mnuFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileOpen.Name = "mnuFileOpen";
		this.mnuFileOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
		this.mnuFileOpen.Size = new System.Drawing.Size (153, 22);
		this.mnuFileOpen.Text = "&Open";
		this.mnuFileRecent.Image = (System.Drawing.Image)resources.GetObject ("mnuFileRecent.Image");
		this.mnuFileRecent.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileRecent.Name = "mnuFileRecent";
		this.mnuFileRecent.Size = new System.Drawing.Size (153, 22);
		this.mnuFileRecent.Text = "&Recent Files...";
		this.mnuFileImportDXF.Name = "mnuFileImportDXF";
		this.mnuFileImportDXF.Size = new System.Drawing.Size (153, 22);
		this.mnuFileImportDXF.Text = "Import &DXF...";
		this.mnuFileSep1.Name = "mnuFileSep1";
		this.mnuFileSep1.Size = new System.Drawing.Size (150, 6);
		this.mnuFileSave.Image = (System.Drawing.Image)resources.GetObject ("mnuFileSave.Image");
		this.mnuFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileSave.Name = "mnuFileSave";
		this.mnuFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.mnuFileSave.Size = new System.Drawing.Size (153, 22);
		this.mnuFileSave.Text = "&Save";
		this.mnuFileSaveAs.Image = (System.Drawing.Image)resources.GetObject ("mnuFileSaveAs.Image");
		this.mnuFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileSaveAs.Name = "mnuFileSaveAs";
		this.mnuFileSaveAs.ShortcutKeys = System.Windows.Forms.Keys.F12;
		this.mnuFileSaveAs.Size = new System.Drawing.Size (153, 22);
		this.mnuFileSaveAs.Text = "Save &As ...";
		this.mnuFileClose.Name = "mnuFileClose";
		this.mnuFileClose.Size = new System.Drawing.Size (153, 22);
		this.mnuFileClose.Text = "&Close";
		this.mnuFileSep2.Name = "mnuFileSep2";
		this.mnuFileSep2.Size = new System.Drawing.Size (150, 6);
		this.mnuFileReportInputs.Image = (System.Drawing.Image)resources.GetObject ("mnuFileReportInputs.Image");
		this.mnuFileReportInputs.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFileReportInputs.Name = "mnuFileReportInputs";
		this.mnuFileReportInputs.Size = new System.Drawing.Size (153, 22);
		this.mnuFileReportInputs.Text = "Report &Inputs";
		this.mnuFilePrint.Image = (System.Drawing.Image)resources.GetObject ("mnuFilePrint.Image");
		this.mnuFilePrint.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuFilePrint.Name = "mnuFilePrint";
		this.mnuFilePrint.ShortcutKeys = System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Control;
		this.mnuFilePrint.Size = new System.Drawing.Size (153, 22);
		this.mnuFilePrint.Text = "&Print ...";
		this.mnuFileSep3.Name = "mnuFileSep3";
		this.mnuFileSep3.Size = new System.Drawing.Size (150, 6);
		this.mnuFileExit.Name = "mnuFileExit";
		this.mnuFileExit.Size = new System.Drawing.Size (153, 22);
		this.mnuFileExit.Text = "E&xit";
		this.mnuEdit.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[16] {
			this.mnuEditUndo, this.mnuEditRedo, this.mnuEditSep1, this.mnuEditCut, this.mnuEditCopy, this.mnuEditPaste, this.mnuEditCopyImage, this.mnuEditSep2, this.mnuEditInsert, this.mnuEditDelete,
			this.mnuEditRotate, this.mnuEditMirror, this.mnuEditSep3, this.mnuEditCenterSection, this.mnuEditCompleteSymmetry, this.mnuEditInsertRibs
		});
		this.mnuEdit.Name = "mnuEdit";
		this.mnuEdit.Size = new System.Drawing.Size (39, 20);
		this.mnuEdit.Text = "&Edit";
		this.mnuEditUndo.Enabled = false;
		this.mnuEditUndo.Image = (System.Drawing.Image)resources.GetObject ("mnuEditUndo.Image");
		this.mnuEditUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuEditUndo.Name = "mnuEditUndo";
		this.mnuEditUndo.ShortcutKeys = System.Windows.Forms.Keys.Z | System.Windows.Forms.Keys.Control;
		this.mnuEditUndo.Size = new System.Drawing.Size (207, 22);
		this.mnuEditUndo.Text = "&Undo";
		this.mnuEditRedo.Enabled = false;
		this.mnuEditRedo.Image = (System.Drawing.Image)resources.GetObject ("mnuEditRedo.Image");
		this.mnuEditRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuEditRedo.Name = "mnuEditRedo";
		this.mnuEditRedo.ShortcutKeys = System.Windows.Forms.Keys.Y | System.Windows.Forms.Keys.Control;
		this.mnuEditRedo.Size = new System.Drawing.Size (207, 22);
		this.mnuEditRedo.Text = "&Redo";
		this.mnuEditSep1.Name = "mnuEditSep1";
		this.mnuEditSep1.Size = new System.Drawing.Size (204, 6);
		this.mnuEditCut.Image = (System.Drawing.Image)resources.GetObject ("mnuEditCut.Image");
		this.mnuEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuEditCut.Name = "mnuEditCut";
		this.mnuEditCut.ShortcutKeys = System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control;
		this.mnuEditCut.Size = new System.Drawing.Size (207, 22);
		this.mnuEditCut.Text = "Cu&t";
		this.mnuEditCopy.Image = (System.Drawing.Image)resources.GetObject ("mnuEditCopy.Image");
		this.mnuEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuEditCopy.Name = "mnuEditCopy";
		this.mnuEditCopy.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
		this.mnuEditCopy.Size = new System.Drawing.Size (207, 22);
		this.mnuEditCopy.Text = "&Copy";
		this.mnuEditPaste.Image = (System.Drawing.Image)resources.GetObject ("mnuEditPaste.Image");
		this.mnuEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuEditPaste.Name = "mnuEditPaste";
		this.mnuEditPaste.ShortcutKeys = System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control;
		this.mnuEditPaste.Size = new System.Drawing.Size (207, 22);
		this.mnuEditPaste.Text = "&Paste";
		this.mnuEditCopyImage.Name = "mnuEditCopyImage";
		this.mnuEditCopyImage.Size = new System.Drawing.Size (207, 22);
		this.mnuEditCopyImage.Text = "Copy Image";
		this.mnuEditSep2.Name = "mnuEditSep2";
		this.mnuEditSep2.Size = new System.Drawing.Size (204, 6);
		this.mnuEditInsert.Name = "mnuEditInsert";
		this.mnuEditInsert.Size = new System.Drawing.Size (207, 22);
		this.mnuEditInsert.Text = "&Insert";
		this.mnuEditDelete.Name = "mnuEditDelete";
		this.mnuEditDelete.Size = new System.Drawing.Size (207, 22);
		this.mnuEditDelete.Text = "&Delete";
		this.mnuEditRotate.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[3] { this.mnuEditRotatePart, this.mnuEditRotateSection, this.mnuEditRotatePrincipal });
		this.mnuEditRotate.Name = "mnuEditRotate";
		this.mnuEditRotate.Size = new System.Drawing.Size (207, 22);
		this.mnuEditRotate.Text = "&Rotate";
		this.mnuEditRotatePart.Name = "mnuEditRotatePart";
		this.mnuEditRotatePart.Size = new System.Drawing.Size (148, 22);
		this.mnuEditRotatePart.Text = "&Part...";
		this.mnuEditRotateSection.Name = "mnuEditRotateSection";
		this.mnuEditRotateSection.Size = new System.Drawing.Size (148, 22);
		this.mnuEditRotateSection.Text = "&Section...";
		this.mnuEditRotatePrincipal.Name = "mnuEditRotatePrincipal";
		this.mnuEditRotatePrincipal.Size = new System.Drawing.Size (148, 22);
		this.mnuEditRotatePrincipal.Text = "Principal &Axes";
		this.mnuEditMirror.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[2] { this.mnuEditMirrorPart, this.mnuEditMirrorSection });
		this.mnuEditMirror.Name = "mnuEditMirror";
		this.mnuEditMirror.Size = new System.Drawing.Size (207, 22);
		this.mnuEditMirror.Text = "&Mirror";
		this.mnuEditMirrorPart.Name = "mnuEditMirrorPart";
		this.mnuEditMirrorPart.Size = new System.Drawing.Size (122, 22);
		this.mnuEditMirrorPart.Text = "Part...";
		this.mnuEditMirrorSection.Name = "mnuEditMirrorSection";
		this.mnuEditMirrorSection.Size = new System.Drawing.Size (122, 22);
		this.mnuEditMirrorSection.Text = "Section...";
		this.mnuEditSep3.Name = "mnuEditSep3";
		this.mnuEditSep3.Size = new System.Drawing.Size (204, 6);
		this.mnuEditCenterSection.Name = "mnuEditCenterSection";
		this.mnuEditCenterSection.Size = new System.Drawing.Size (207, 22);
		this.mnuEditCenterSection.Text = "Ce&nter Section";
		this.mnuEditCompleteSymmetry.Name = "mnuEditCompleteSymmetry";
		this.mnuEditCompleteSymmetry.Size = new System.Drawing.Size (207, 22);
		this.mnuEditCompleteSymmetry.Text = "Complete Part S&ymmetry";
		this.mnuEditInsertRibs.Name = "mnuEditInsertRibs";
		this.mnuEditInsertRibs.Size = new System.Drawing.Size (207, 22);
		this.mnuEditInsertRibs.Text = "In&sert Ribs...";
		this.mnuView.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[6] { this.mnuViewToolbar, this.mnuViewInputsOnTop, this.mnuViewSectionInputs, this.mnuViewAnalysisInputs, this.mnuViewRenderMembers, this.mnuViewXYAxes });
		this.mnuView.Name = "mnuView";
		this.mnuView.Size = new System.Drawing.Size (44, 20);
		this.mnuView.Text = "&View";
		this.mnuViewToolbar.Checked = true;
		this.mnuViewToolbar.CheckOnClick = true;
		this.mnuViewToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
		this.mnuViewToolbar.Name = "mnuViewToolbar";
		this.mnuViewToolbar.Size = new System.Drawing.Size (195, 22);
		this.mnuViewToolbar.Text = "&Toolbar";
		this.mnuViewInputsOnTop.Name = "mnuViewInputsOnTop";
		this.mnuViewInputsOnTop.Size = new System.Drawing.Size (195, 22);
		this.mnuViewInputsOnTop.Text = "&Input Windows On Top";
		this.mnuViewSectionInputs.Name = "mnuViewSectionInputs";
		this.mnuViewSectionInputs.ShortcutKeys = System.Windows.Forms.Keys.F3;
		this.mnuViewSectionInputs.Size = new System.Drawing.Size (195, 22);
		this.mnuViewSectionInputs.Text = "&Section Inputs";
		this.mnuViewAnalysisInputs.Name = "mnuViewAnalysisInputs";
		this.mnuViewAnalysisInputs.ShortcutKeys = System.Windows.Forms.Keys.F4;
		this.mnuViewAnalysisInputs.Size = new System.Drawing.Size (195, 22);
		this.mnuViewAnalysisInputs.Text = "&Analysis Inputs";
		this.mnuViewRenderMembers.Name = "mnuViewRenderMembers";
		this.mnuViewRenderMembers.Size = new System.Drawing.Size (195, 22);
		this.mnuViewRenderMembers.Text = "&Render Members";
		this.mnuViewXYAxes.Name = "mnuViewXYAxes";
		this.mnuViewXYAxes.Size = new System.Drawing.Size (195, 22);
		this.mnuViewXYAxes.Text = "&X-Y Axes";
		this.mnuCompute.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[9] { this.mnuComputeProperties, this.mnuComputeEffProperties, this.mnuComputeStrength, this.mnuComputeMemberCheck, this.mnuComputeWebCheck, this.mnuComputeSep1, this.mnuComputeTorsionProperties, this.mnuComputeElasticBuckling, this.mnuComputeDiagrams });
		this.mnuCompute.Name = "mnuCompute";
		this.mnuCompute.Size = new System.Drawing.Size (69, 20);
		this.mnuCompute.Text = "&Compute";
		this.mnuComputeProperties.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeProperties.Image");
		this.mnuComputeProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeProperties.Name = "mnuComputeProperties";
		this.mnuComputeProperties.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeProperties.Text = "&Properties";
		this.mnuComputeEffProperties.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeEffProperties.Image");
		this.mnuComputeEffProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeEffProperties.Name = "mnuComputeEffProperties";
		this.mnuComputeEffProperties.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeEffProperties.Text = "&Effective Properties...";
		this.mnuComputeStrength.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeStrength.Image");
		this.mnuComputeStrength.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeStrength.Name = "mnuComputeStrength";
		this.mnuComputeStrength.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeStrength.Text = "&Strength";
		this.mnuComputeMemberCheck.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeMemberCheck.Image");
		this.mnuComputeMemberCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeMemberCheck.Name = "mnuComputeMemberCheck";
		this.mnuComputeMemberCheck.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeMemberCheck.Text = "&Member Check...";
		this.mnuComputeWebCheck.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeWebCheck.Image");
		this.mnuComputeWebCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeWebCheck.Name = "mnuComputeWebCheck";
		this.mnuComputeWebCheck.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeWebCheck.Text = "&Web Crippling...";
		this.mnuComputeSep1.Name = "mnuComputeSep1";
		this.mnuComputeSep1.Size = new System.Drawing.Size (181, 6);
		this.mnuComputeTorsionProperties.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeTorsionProperties.Image");
		this.mnuComputeTorsionProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeTorsionProperties.Name = "mnuComputeTorsionProperties";
		this.mnuComputeTorsionProperties.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeTorsionProperties.Text = "&Torsion Properties";
		this.mnuComputeElasticBuckling.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeElasticBuckling.Image");
		this.mnuComputeElasticBuckling.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeElasticBuckling.Name = "mnuComputeElasticBuckling";
		this.mnuComputeElasticBuckling.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeElasticBuckling.Text = "Elastic &Buckling...";
		this.mnuComputeDiagrams.Image = (System.Drawing.Image)resources.GetObject ("mnuComputeDiagrams.Image");
		this.mnuComputeDiagrams.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuComputeDiagrams.Name = "mnuComputeDiagrams";
		this.mnuComputeDiagrams.Size = new System.Drawing.Size (184, 22);
		this.mnuComputeDiagrams.Text = "&Diagrams";
		this.mnuTools.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[9] { this.mnuToolsSpec, this.mnuToolsBuckling, this.mnuToolsTrace, this.mnuToolsSep1, this.mnuToolsOptions, this.mnuToolsLicense, this.mnuToolsSep2, this.mnuToolsSectionGenerator, this.mnuToolsLibraryBuilder });
		this.mnuTools.Name = "mnuTools";
		this.mnuTools.Size = new System.Drawing.Size (46, 20);
		this.mnuTools.Text = "&Tools";
		this.mnuToolsSpec.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[9] { this.mnuToolsSpec2022, this.mnuToolsSpec2018, this.mnuToolsSpec2016, this.mnuToolsSpec2012, this.mnuToolsSpec2010, this.mnuToolsSpec2007, this.mnuToolsSpec2004, this.mnuToolsSpec2001, this.mnuToolsSpec1999 });
		this.mnuToolsSpec.Name = "mnuToolsSpec";
		this.mnuToolsSpec.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec.Text = "&Specification";
		this.mnuToolsSpec2022.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2022USASD, this.mnuToolsSpec2022USLRFD, this.mnuToolsSpec2022MexicoASD, this.mnuToolsSpec2022MexicoLRFD, this.mnuToolsSpec2022CanadaLSD });
		this.mnuToolsSpec2022.Name = "mnuToolsSpec2022";
		this.mnuToolsSpec2022.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2022.Text = "AISI S100-16/S3-22";
		this.mnuToolsSpec2022USASD.Name = "mnuToolsSpec2022USASD";
		this.mnuToolsSpec2022USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2022USASD.Text = "US, ASD";
		this.mnuToolsSpec2022USLRFD.Name = "mnuToolsSpec2022USLRFD";
		this.mnuToolsSpec2022USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2022USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2022MexicoASD.Name = "mnuToolsSpec2022MexicoASD";
		this.mnuToolsSpec2022MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2022MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2022MexicoLRFD.Name = "mnuToolsSpec2022MexicoLRFD";
		this.mnuToolsSpec2022MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2022MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2022CanadaLSD.Name = "mnuToolsSpec2022CanadaLSD";
		this.mnuToolsSpec2022CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2022CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2018.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2018USASD, this.mnuToolsSpec2018USLRFD, this.mnuToolsSpec2018MexicoASD, this.mnuToolsSpec2018MexicoLRFD, this.mnuToolsSpec2018CanadaLSD });
		this.mnuToolsSpec2018.Name = "mnuToolsSpec2018";
		this.mnuToolsSpec2018.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2018.Text = "AISI S100-16/S1-18";
		this.mnuToolsSpec2018USASD.Name = "mnuToolsSpec2018USASD";
		this.mnuToolsSpec2018USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2018USASD.Text = "US, ASD";
		this.mnuToolsSpec2018USLRFD.Name = "mnuToolsSpec2018USLRFD";
		this.mnuToolsSpec2018USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2018USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2018MexicoASD.Name = "mnuToolsSpec2018MexicoASD";
		this.mnuToolsSpec2018MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2018MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2018MexicoLRFD.Name = "mnuToolsSpec2018MexicoLRFD";
		this.mnuToolsSpec2018MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2018MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2018CanadaLSD.Name = "mnuToolsSpec2018CanadaLSD";
		this.mnuToolsSpec2018CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2018CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2016.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2016USASD, this.mnuToolsSpec2016USLRFD, this.mnuToolsSpec2016MexicoASD, this.mnuToolsSpec2016MexicoLRFD, this.mnuToolsSpec2016CanadaLSD });
		this.mnuToolsSpec2016.Name = "mnuToolsSpec2016";
		this.mnuToolsSpec2016.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2016.Text = "AISI S100-16";
		this.mnuToolsSpec2016USASD.Name = "mnuToolsSpec2016USASD";
		this.mnuToolsSpec2016USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2016USASD.Text = "US, ASD";
		this.mnuToolsSpec2016USLRFD.Name = "mnuToolsSpec2016USLRFD";
		this.mnuToolsSpec2016USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2016USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2016MexicoASD.Name = "mnuToolsSpec2016MexicoASD";
		this.mnuToolsSpec2016MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2016MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2016MexicoLRFD.Name = "mnuToolsSpec2016MexicoLRFD";
		this.mnuToolsSpec2016MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2016MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2016CanadaLSD.Name = "mnuToolsSpec2016CanadaLSD";
		this.mnuToolsSpec2016CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2016CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2012.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2012USASD, this.mnuToolsSpec2012USLRFD, this.mnuToolsSpec2012MexicoASD, this.mnuToolsSpec2012MexicoLRFD, this.mnuToolsSpec2012CanadaLSD });
		this.mnuToolsSpec2012.Name = "mnuToolsSpec2012";
		this.mnuToolsSpec2012.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2012.Text = "AISI S100-12";
		this.mnuToolsSpec2012USASD.Name = "mnuToolsSpec2012USASD";
		this.mnuToolsSpec2012USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2012USASD.Text = "US, ASD";
		this.mnuToolsSpec2012USLRFD.Name = "mnuToolsSpec2012USLRFD";
		this.mnuToolsSpec2012USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2012USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2012MexicoASD.Name = "mnuToolsSpec2012MexicoASD";
		this.mnuToolsSpec2012MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2012MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2012MexicoLRFD.Name = "mnuToolsSpec2012MexicoLRFD";
		this.mnuToolsSpec2012MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2012MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2012CanadaLSD.Name = "mnuToolsSpec2012CanadaLSD";
		this.mnuToolsSpec2012CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2012CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2010.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2010USASD, this.mnuToolsSpec2010USLRFD, this.mnuToolsSpec2010MexicoASD, this.mnuToolsSpec2010MexicoLRFD, this.mnuToolsSpec2010CanadaLSD });
		this.mnuToolsSpec2010.Name = "mnuToolsSpec2010";
		this.mnuToolsSpec2010.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2010.Text = "AISI S100-07/S2-10";
		this.mnuToolsSpec2010USASD.Name = "mnuToolsSpec2010USASD";
		this.mnuToolsSpec2010USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2010USASD.Text = "US, ASD";
		this.mnuToolsSpec2010USLRFD.Name = "mnuToolsSpec2010USLRFD";
		this.mnuToolsSpec2010USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2010USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2010MexicoASD.Name = "mnuToolsSpec2010MexicoASD";
		this.mnuToolsSpec2010MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2010MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2010MexicoLRFD.Name = "mnuToolsSpec2010MexicoLRFD";
		this.mnuToolsSpec2010MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2010MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2010CanadaLSD.Name = "mnuToolsSpec2010CanadaLSD";
		this.mnuToolsSpec2010CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2010CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2007.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2007USASD, this.mnuToolsSpec2007USLRFD, this.mnuToolsSpec2007MexicoASD, this.mnuToolsSpec2007MexicoLRFD, this.mnuToolsSpec2007CanadaLSD });
		this.mnuToolsSpec2007.Name = "mnuToolsSpec2007";
		this.mnuToolsSpec2007.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2007.Text = "AISI S100-07";
		this.mnuToolsSpec2007USASD.Name = "mnuToolsSpec2007USASD";
		this.mnuToolsSpec2007USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2007USASD.Text = "US, ASD";
		this.mnuToolsSpec2007USLRFD.Name = "mnuToolsSpec2007USLRFD";
		this.mnuToolsSpec2007USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2007USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2007MexicoASD.Name = "mnuToolsSpec2007MexicoASD";
		this.mnuToolsSpec2007MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2007MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2007MexicoLRFD.Name = "mnuToolsSpec2007MexicoLRFD";
		this.mnuToolsSpec2007MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2007MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2007CanadaLSD.Name = "mnuToolsSpec2007CanadaLSD";
		this.mnuToolsSpec2007CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2007CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2004.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2004USASD, this.mnuToolsSpec2004USLRFD, this.mnuToolsSpec2004MexicoASD, this.mnuToolsSpec2004MexicoLRFD, this.mnuToolsSpec2004CanadaLSD });
		this.mnuToolsSpec2004.Name = "mnuToolsSpec2004";
		this.mnuToolsSpec2004.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2004.Text = "AISI 2004";
		this.mnuToolsSpec2004USASD.Name = "mnuToolsSpec2004USASD";
		this.mnuToolsSpec2004USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2004USASD.Text = "US, ASD";
		this.mnuToolsSpec2004USLRFD.Name = "mnuToolsSpec2004USLRFD";
		this.mnuToolsSpec2004USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2004USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2004MexicoASD.Name = "mnuToolsSpec2004MexicoASD";
		this.mnuToolsSpec2004MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2004MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2004MexicoLRFD.Name = "mnuToolsSpec2004MexicoLRFD";
		this.mnuToolsSpec2004MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2004MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2004CanadaLSD.Name = "mnuToolsSpec2004CanadaLSD";
		this.mnuToolsSpec2004CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2004CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec2001.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsSpec2001USASD, this.mnuToolsSpec2001USLRFD, this.mnuToolsSpec2001MexicoASD, this.mnuToolsSpec2001MexicoLRFD, this.mnuToolsSpec2001CanadaLSD });
		this.mnuToolsSpec2001.Name = "mnuToolsSpec2001";
		this.mnuToolsSpec2001.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec2001.Text = "AISI 2001";
		this.mnuToolsSpec2001USASD.Name = "mnuToolsSpec2001USASD";
		this.mnuToolsSpec2001USASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2001USASD.Text = "US, ASD";
		this.mnuToolsSpec2001USLRFD.Name = "mnuToolsSpec2001USLRFD";
		this.mnuToolsSpec2001USLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2001USLRFD.Text = "US, LRFD";
		this.mnuToolsSpec2001MexicoASD.Name = "mnuToolsSpec2001MexicoASD";
		this.mnuToolsSpec2001MexicoASD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2001MexicoASD.Text = "Mexico, ASD";
		this.mnuToolsSpec2001MexicoLRFD.Name = "mnuToolsSpec2001MexicoLRFD";
		this.mnuToolsSpec2001MexicoLRFD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2001MexicoLRFD.Text = "Mexico, LRFD";
		this.mnuToolsSpec2001CanadaLSD.Name = "mnuToolsSpec2001CanadaLSD";
		this.mnuToolsSpec2001CanadaLSD.Size = new System.Drawing.Size (146, 22);
		this.mnuToolsSpec2001CanadaLSD.Text = "Canada, LSD";
		this.mnuToolsSpec1999.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[2] { this.mnuToolsSpec1999ASD, this.mnuToolsSpec1999LRFD });
		this.mnuToolsSpec1999.Name = "mnuToolsSpec1999";
		this.mnuToolsSpec1999.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec1999.Text = "AISI 1999";
		this.mnuToolsSpec1999.Visible = false;
		this.mnuToolsSpec1999ASD.Name = "mnuToolsSpec1999ASD";
		this.mnuToolsSpec1999ASD.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec1999ASD.Text = "US, ASD";
		this.mnuToolsSpec1999LRFD.Name = "mnuToolsSpec1999LRFD";
		this.mnuToolsSpec1999LRFD.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSpec1999LRFD.Text = "US, LRFD";
		this.mnuToolsBuckling.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[2] { this.mnuToolsBucklingSpec, this.mnuToolsBucklingTheory });
		this.mnuToolsBuckling.Name = "mnuToolsBuckling";
		this.mnuToolsBuckling.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsBuckling.Text = "Global Buc&kling";
		this.mnuToolsBucklingSpec.Name = "mnuToolsBucklingSpec";
		this.mnuToolsBucklingSpec.Size = new System.Drawing.Size (154, 22);
		this.mnuToolsBucklingSpec.Text = "&Spec Equations";
		this.mnuToolsBucklingTheory.Name = "mnuToolsBucklingTheory";
		this.mnuToolsBucklingTheory.Size = new System.Drawing.Size (154, 22);
		this.mnuToolsBucklingTheory.Text = "Elastic &Theory";
		this.mnuToolsTrace.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[6] { this.mnuToolsTraceAll, this.mnuToolsTraceStrength, this.mnuToolsTraceMemberCheck, this.mnuToolsTraceWebCheck, this.mnuToolsTraceEffectiveSection, this.mnuToolsTraceColdWork });
		this.mnuToolsTrace.Name = "mnuToolsTrace";
		this.mnuToolsTrace.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsTrace.Text = "Include &Trace";
		this.mnuToolsTraceAll.Name = "mnuToolsTraceAll";
		this.mnuToolsTraceAll.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceAll.Text = "All";
		this.mnuToolsTraceStrength.Name = "mnuToolsTraceStrength";
		this.mnuToolsTraceStrength.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceStrength.Text = "Strength";
		this.mnuToolsTraceMemberCheck.Name = "mnuToolsTraceMemberCheck";
		this.mnuToolsTraceMemberCheck.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceMemberCheck.Text = "Member Check";
		this.mnuToolsTraceWebCheck.Name = "mnuToolsTraceWebCheck";
		this.mnuToolsTraceWebCheck.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceWebCheck.Text = "Web Crippling";
		this.mnuToolsTraceEffectiveSection.Name = "mnuToolsTraceEffectiveSection";
		this.mnuToolsTraceEffectiveSection.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceEffectiveSection.Text = "Effective Section";
		this.mnuToolsTraceColdWork.Name = "mnuToolsTraceColdWork";
		this.mnuToolsTraceColdWork.Size = new System.Drawing.Size (174, 22);
		this.mnuToolsTraceColdWork.Text = "Cold Work Stresses";
		this.mnuToolsSep1.Name = "mnuToolsSep1";
		this.mnuToolsSep1.Size = new System.Drawing.Size (177, 6);
		this.mnuToolsOptions.Name = "mnuToolsOptions";
		this.mnuToolsOptions.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsOptions.Text = "&Options...";
		this.mnuToolsLicense.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuToolsPurchaseLicense, this.mnuToolsRenewLicense, this.mnuToolsSingleUserLicense, this.mnuToolsNetworkLicense, this.mnuToolsLicensePortal });
		this.mnuToolsLicense.Name = "mnuToolsLicense";
		this.mnuToolsLicense.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsLicense.Text = "&License";
		this.mnuToolsPurchaseLicense.Name = "mnuToolsPurchaseLicense";
		this.mnuToolsPurchaseLicense.Size = new System.Drawing.Size (215, 22);
		this.mnuToolsPurchaseLicense.Text = "&Purchase New License...";
		this.mnuToolsRenewLicense.Name = "mnuToolsRenewLicense";
		this.mnuToolsRenewLicense.Size = new System.Drawing.Size (215, 22);
		this.mnuToolsRenewLicense.Text = "&Renew License...";
		this.mnuToolsRenewLicense.Visible = false;
		this.mnuToolsSingleUserLicense.Name = "mnuToolsSingleUserLicense";
		this.mnuToolsSingleUserLicense.Size = new System.Drawing.Size (215, 22);
		this.mnuToolsSingleUserLicense.Text = "&Single User License...";
		this.mnuToolsNetworkLicense.Name = "mnuToolsNetworkLicense";
		this.mnuToolsNetworkLicense.Size = new System.Drawing.Size (215, 22);
		this.mnuToolsNetworkLicense.Text = "&Network License Settings...";
		this.mnuToolsLicensePortal.Name = "mnuToolsLicensePortal";
		this.mnuToolsLicensePortal.Size = new System.Drawing.Size (215, 22);
		this.mnuToolsLicensePortal.Text = "&License Portal...";
		this.mnuToolsSep2.Name = "mnuToolsSep2";
		this.mnuToolsSep2.Size = new System.Drawing.Size (177, 6);
		this.mnuToolsSectionGenerator.Name = "mnuToolsSectionGenerator";
		this.mnuToolsSectionGenerator.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsSectionGenerator.Text = "Section &Generator...";
		this.mnuToolsSectionGenerator.Visible = false;
		this.mnuToolsLibraryBuilder.Name = "mnuToolsLibraryBuilder";
		this.mnuToolsLibraryBuilder.Size = new System.Drawing.Size (180, 22);
		this.mnuToolsLibraryBuilder.Text = "Library &Builder...";
		this.mnuWindows.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[5] { this.mnuWindowsCascade, this.mnuWindowsTileVertical, this.mnuWindowsTileHorizontal, this.mnuWindowsArrangeIcons, this.mnuWindowsCloseAll });
		this.mnuWindows.Name = "mnuWindows";
		this.mnuWindows.Size = new System.Drawing.Size (68, 20);
		this.mnuWindows.Text = "&Windows";
		this.mnuWindowsCascade.Image = (System.Drawing.Image)resources.GetObject ("mnuWindowsCascade.Image");
		this.mnuWindowsCascade.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuWindowsCascade.Name = "mnuWindowsCascade";
		this.mnuWindowsCascade.Size = new System.Drawing.Size (150, 22);
		this.mnuWindowsCascade.Text = "&Cascade";
		this.mnuWindowsTileVertical.Image = (System.Drawing.Image)resources.GetObject ("mnuWindowsTileVertical.Image");
		this.mnuWindowsTileVertical.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuWindowsTileVertical.Name = "mnuWindowsTileVertical";
		this.mnuWindowsTileVertical.Size = new System.Drawing.Size (150, 22);
		this.mnuWindowsTileVertical.Text = "Tile &Vertical";
		this.mnuWindowsTileHorizontal.Image = (System.Drawing.Image)resources.GetObject ("mnuWindowsTileHorizontal.Image");
		this.mnuWindowsTileHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuWindowsTileHorizontal.Name = "mnuWindowsTileHorizontal";
		this.mnuWindowsTileHorizontal.Size = new System.Drawing.Size (150, 22);
		this.mnuWindowsTileHorizontal.Text = "Tile &Horizontal";
		this.mnuWindowsArrangeIcons.Name = "mnuWindowsArrangeIcons";
		this.mnuWindowsArrangeIcons.Size = new System.Drawing.Size (150, 22);
		this.mnuWindowsArrangeIcons.Text = "&Arrange Icons";
		this.mnuWindowsCloseAll.Name = "mnuWindowsCloseAll";
		this.mnuWindowsCloseAll.Size = new System.Drawing.Size (150, 22);
		this.mnuWindowsCloseAll.Text = "C&lose All";
		this.mnuHelp.DropDownItems.AddRange (new System.Windows.Forms.ToolStripItem[7] { this.mnuHelpContents, this.mnuHelpIndex, this.mnuHelpSearch, this.mnuHelpSep1, this.mnuHelpRSGSoftware, this.mnuHelpSep2, this.mnuHelpAbout });
		this.mnuHelp.Name = "mnuHelp";
		this.mnuHelp.Size = new System.Drawing.Size (44, 20);
		this.mnuHelp.Text = "&Help";
		this.mnuHelpContents.Name = "mnuHelpContents";
		this.mnuHelpContents.ShortcutKeys = System.Windows.Forms.Keys.F1 | System.Windows.Forms.Keys.Control;
		this.mnuHelpContents.Size = new System.Drawing.Size (182, 22);
		this.mnuHelpContents.Text = "&Contents";
		this.mnuHelpIndex.Image = (System.Drawing.Image)resources.GetObject ("mnuHelpIndex.Image");
		this.mnuHelpIndex.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuHelpIndex.Name = "mnuHelpIndex";
		this.mnuHelpIndex.Size = new System.Drawing.Size (182, 22);
		this.mnuHelpIndex.Text = "&Index";
		this.mnuHelpSearch.Image = (System.Drawing.Image)resources.GetObject ("mnuHelpSearch.Image");
		this.mnuHelpSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuHelpSearch.Name = "mnuHelpSearch";
		this.mnuHelpSearch.Size = new System.Drawing.Size (182, 22);
		this.mnuHelpSearch.Text = "&Search";
		this.mnuHelpSep1.Name = "mnuHelpSep1";
		this.mnuHelpSep1.Size = new System.Drawing.Size (179, 6);
		this.mnuHelpRSGSoftware.Image = (System.Drawing.Image)resources.GetObject ("mnuHelpRSGSoftware.Image");
		this.mnuHelpRSGSoftware.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuHelpRSGSoftware.Name = "mnuHelpRSGSoftware";
		this.mnuHelpRSGSoftware.Size = new System.Drawing.Size (182, 22);
		this.mnuHelpRSGSoftware.Text = "&RSG Software Online";
		this.mnuHelpSep2.Name = "mnuHelpSep2";
		this.mnuHelpSep2.Size = new System.Drawing.Size (179, 6);
		this.mnuHelpAbout.Name = "mnuHelpAbout";
		this.mnuHelpAbout.Size = new System.Drawing.Size (182, 22);
		this.mnuHelpAbout.Text = "&About CFS";
		this.tbrCFS.Items.AddRange (new System.Windows.Forms.ToolStripItem[31] {
			this.tbrNewSection, this.tbrNewAnalysis, this.tbrQuickDesign, this.tbrOpen, this.tbrRecent, this.tbrSave, this.tbrSaveAs, this.tbrSepFile, this.tbrPrintPreview, this.tbrPrint,
			this.tbrSepPrint, this.tbrCut, this.tbrCopy, this.tbrPaste, this.tbrUndo, this.tbrRedo, this.tbrSepEdit, this.tbrProperties, this.tbrEffProperties, this.tbrStrength,
			this.tbrMemberCheck, this.tbrWebCheck, this.tbrElasticBuckling, this.tbrDiagrams, this.tbrSepCompute, this.tbrCascade, this.tbrTileVertical, this.tbrTileHorizontal, this.tbrSepWindow, this.tbrHelp,
			this.tbrGenerate
		});
		this.tbrCFS.Location = new System.Drawing.Point (0, 24);
		this.tbrCFS.Name = "tbrCFS";
		this.tbrCFS.Size = new System.Drawing.Size (664, 25);
		this.tbrCFS.TabIndex = 6;
		this.tbrCFS.Text = "CFS Toolbar";
		this.tbrNewSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrNewSection.Image = (System.Drawing.Image)resources.GetObject ("tbrNewSection.Image");
		this.tbrNewSection.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrNewSection.Name = "tbrNewSection";
		this.tbrNewSection.Size = new System.Drawing.Size (23, 22);
		this.tbrNewSection.Text = "New Section";
		this.tbrNewAnalysis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrNewAnalysis.Image = (System.Drawing.Image)resources.GetObject ("tbrNewAnalysis.Image");
		this.tbrNewAnalysis.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrNewAnalysis.Name = "tbrNewAnalysis";
		this.tbrNewAnalysis.Size = new System.Drawing.Size (23, 22);
		this.tbrNewAnalysis.Text = "New Analysis";
		this.tbrQuickDesign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrQuickDesign.Image = (System.Drawing.Image)resources.GetObject ("tbrQuickDesign.Image");
		this.tbrQuickDesign.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrQuickDesign.Name = "tbrQuickDesign";
		this.tbrQuickDesign.Size = new System.Drawing.Size (23, 22);
		this.tbrQuickDesign.Text = "Quick Design";
		this.tbrOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrOpen.Image = (System.Drawing.Image)resources.GetObject ("tbrOpen.Image");
		this.tbrOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrOpen.Name = "tbrOpen";
		this.tbrOpen.Size = new System.Drawing.Size (23, 22);
		this.tbrOpen.Text = "Open";
		this.tbrRecent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrRecent.Image = (System.Drawing.Image)resources.GetObject ("tbrRecent.Image");
		this.tbrRecent.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrRecent.Name = "tbrRecent";
		this.tbrRecent.Size = new System.Drawing.Size (23, 22);
		this.tbrRecent.Text = "Recent Files";
		this.tbrSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrSave.Image = (System.Drawing.Image)resources.GetObject ("tbrSave.Image");
		this.tbrSave.ImageTransparentColor = System.Drawing.Color.Fuchsia;
		this.tbrSave.Name = "tbrSave";
		this.tbrSave.Size = new System.Drawing.Size (23, 22);
		this.tbrSave.Text = "Save";
		this.tbrSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrSaveAs.Image = (System.Drawing.Image)resources.GetObject ("tbrSaveAs.Image");
		this.tbrSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrSaveAs.Name = "tbrSaveAs";
		this.tbrSaveAs.Size = new System.Drawing.Size (23, 22);
		this.tbrSaveAs.Text = "Save As";
		this.tbrSepFile.Name = "tbrSepFile";
		this.tbrSepFile.Size = new System.Drawing.Size (6, 25);
		this.tbrPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrPrintPreview.Image = (System.Drawing.Image)resources.GetObject ("tbrPrintPreview.Image");
		this.tbrPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrPrintPreview.Name = "tbrPrintPreview";
		this.tbrPrintPreview.Size = new System.Drawing.Size (23, 22);
		this.tbrPrintPreview.Text = "Report Inputs";
		this.tbrPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrPrint.Image = (System.Drawing.Image)resources.GetObject ("tbrPrint.Image");
		this.tbrPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrPrint.Name = "tbrPrint";
		this.tbrPrint.Size = new System.Drawing.Size (23, 22);
		this.tbrPrint.Text = "Print";
		this.tbrSepPrint.Name = "tbrSepPrint";
		this.tbrSepPrint.Size = new System.Drawing.Size (6, 25);
		this.tbrCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrCut.Image = (System.Drawing.Image)resources.GetObject ("tbrCut.Image");
		this.tbrCut.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrCut.Name = "tbrCut";
		this.tbrCut.Size = new System.Drawing.Size (23, 22);
		this.tbrCut.Text = "Cut";
		this.tbrCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrCopy.Image = (System.Drawing.Image)resources.GetObject ("tbrCopy.Image");
		this.tbrCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrCopy.Name = "tbrCopy";
		this.tbrCopy.Size = new System.Drawing.Size (23, 22);
		this.tbrCopy.Text = "Copy";
		this.tbrPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrPaste.Image = (System.Drawing.Image)resources.GetObject ("tbrPaste.Image");
		this.tbrPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrPaste.Name = "tbrPaste";
		this.tbrPaste.Size = new System.Drawing.Size (23, 22);
		this.tbrPaste.Text = "Paste";
		this.tbrUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrUndo.Enabled = false;
		this.tbrUndo.Image = (System.Drawing.Image)resources.GetObject ("tbrUndo.Image");
		this.tbrUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrUndo.Name = "tbrUndo";
		this.tbrUndo.Size = new System.Drawing.Size (23, 22);
		this.tbrUndo.Text = "Undo";
		this.tbrRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrRedo.Enabled = false;
		this.tbrRedo.Image = (System.Drawing.Image)resources.GetObject ("tbrRedo.Image");
		this.tbrRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrRedo.Name = "tbrRedo";
		this.tbrRedo.Size = new System.Drawing.Size (23, 22);
		this.tbrRedo.Text = "Redo";
		this.tbrSepEdit.Name = "tbrSepEdit";
		this.tbrSepEdit.Size = new System.Drawing.Size (6, 25);
		this.tbrProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrProperties.Image = (System.Drawing.Image)resources.GetObject ("tbrProperties.Image");
		this.tbrProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrProperties.Name = "tbrProperties";
		this.tbrProperties.Size = new System.Drawing.Size (23, 22);
		this.tbrProperties.Text = "Compute Properties";
		this.tbrEffProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrEffProperties.Image = (System.Drawing.Image)resources.GetObject ("tbrEffProperties.Image");
		this.tbrEffProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrEffProperties.Name = "tbrEffProperties";
		this.tbrEffProperties.Size = new System.Drawing.Size (23, 22);
		this.tbrEffProperties.Text = "Compute Effective Properties";
		this.tbrStrength.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrStrength.Image = (System.Drawing.Image)resources.GetObject ("tbrStrength.Image");
		this.tbrStrength.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrStrength.Name = "tbrStrength";
		this.tbrStrength.Size = new System.Drawing.Size (23, 22);
		this.tbrStrength.Text = "Compute Strength";
		this.tbrMemberCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrMemberCheck.Image = (System.Drawing.Image)resources.GetObject ("tbrMemberCheck.Image");
		this.tbrMemberCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrMemberCheck.Name = "tbrMemberCheck";
		this.tbrMemberCheck.Size = new System.Drawing.Size (23, 22);
		this.tbrMemberCheck.Text = "Compute Member Check";
		this.tbrWebCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrWebCheck.Image = (System.Drawing.Image)resources.GetObject ("tbrWebCheck.Image");
		this.tbrWebCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrWebCheck.Name = "tbrWebCheck";
		this.tbrWebCheck.Size = new System.Drawing.Size (23, 22);
		this.tbrWebCheck.Text = "Compute Web Crippling";
		this.tbrElasticBuckling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrElasticBuckling.Image = (System.Drawing.Image)resources.GetObject ("tbrElasticBuckling.Image");
		this.tbrElasticBuckling.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrElasticBuckling.Name = "tbrElasticBuckling";
		this.tbrElasticBuckling.Size = new System.Drawing.Size (23, 22);
		this.tbrElasticBuckling.Text = "Compute Elastic Buckling";
		this.tbrDiagrams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrDiagrams.Image = (System.Drawing.Image)resources.GetObject ("tbrDiagrams.Image");
		this.tbrDiagrams.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrDiagrams.Name = "tbrDiagrams";
		this.tbrDiagrams.Size = new System.Drawing.Size (23, 22);
		this.tbrDiagrams.Text = "Compute Diagrams";
		this.tbrSepCompute.Name = "tbrSepCompute";
		this.tbrSepCompute.Size = new System.Drawing.Size (6, 25);
		this.tbrCascade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrCascade.Image = (System.Drawing.Image)resources.GetObject ("tbrCascade.Image");
		this.tbrCascade.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrCascade.Name = "tbrCascade";
		this.tbrCascade.Size = new System.Drawing.Size (23, 22);
		this.tbrCascade.Text = "Cascade Windows";
		this.tbrTileVertical.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrTileVertical.Image = (System.Drawing.Image)resources.GetObject ("tbrTileVertical.Image");
		this.tbrTileVertical.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrTileVertical.Name = "tbrTileVertical";
		this.tbrTileVertical.Size = new System.Drawing.Size (23, 22);
		this.tbrTileVertical.Text = "Tile Vertical";
		this.tbrTileHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrTileHorizontal.Image = (System.Drawing.Image)resources.GetObject ("tbrTileHorizontal.Image");
		this.tbrTileHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrTileHorizontal.Name = "tbrTileHorizontal";
		this.tbrTileHorizontal.Size = new System.Drawing.Size (23, 22);
		this.tbrTileHorizontal.Text = "Tile Horizontal";
		this.tbrSepWindow.Name = "tbrSepWindow";
		this.tbrSepWindow.Size = new System.Drawing.Size (6, 25);
		this.tbrHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrHelp.Image = (System.Drawing.Image)resources.GetObject ("tbrHelp.Image");
		this.tbrHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrHelp.Name = "tbrHelp";
		this.tbrHelp.Size = new System.Drawing.Size (23, 22);
		this.tbrHelp.Text = "Help";
		this.tbrGenerate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrGenerate.Image = (System.Drawing.Image)resources.GetObject ("tbrGenerate.Image");
		this.tbrGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrGenerate.Name = "tbrGenerate";
		this.tbrGenerate.Size = new System.Drawing.Size (23, 22);
		this.tbrGenerate.Text = "Generate Sections";
		this.tbrGenerate.Visible = false;
		this.mnuEditPopup.Items.AddRange (new System.Windows.Forms.ToolStripItem[8] { this.mnuEditPopupCut, this.mnuEditPopupCopy, this.mnuEditPopupPaste, this.mnuEditPopupCopyImage, this.mnuEditPopupSep1, this.mnuEditPopupInsert, this.mnuEditPopupDelete, this.mnuEditPopupInsertRibs });
		this.mnuEditPopup.Name = "ContextMenuStrip1";
		this.mnuEditPopup.Size = new System.Drawing.Size (139, 164);
		this.mnuEditPopupCut.Name = "mnuEditPopupCut";
		this.mnuEditPopupCut.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupCut.Text = "Cu&t";
		this.mnuEditPopupCopy.Name = "mnuEditPopupCopy";
		this.mnuEditPopupCopy.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupCopy.Text = "&Copy";
		this.mnuEditPopupPaste.Name = "mnuEditPopupPaste";
		this.mnuEditPopupPaste.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupPaste.Text = "&Paste";
		this.mnuEditPopupCopyImage.Name = "mnuEditPopupCopyImage";
		this.mnuEditPopupCopyImage.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupCopyImage.Text = "Copy Image";
		this.mnuEditPopupSep1.Name = "mnuEditPopupSep1";
		this.mnuEditPopupSep1.Size = new System.Drawing.Size (135, 6);
		this.mnuEditPopupInsert.Name = "mnuEditPopupInsert";
		this.mnuEditPopupInsert.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupInsert.Text = "&Insert";
		this.mnuEditPopupDelete.Name = "mnuEditPopupDelete";
		this.mnuEditPopupDelete.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupDelete.Text = "&Delete";
		this.mnuEditPopupInsertRibs.Name = "mnuEditPopupInsertRibs";
		this.mnuEditPopupInsertRibs.Size = new System.Drawing.Size (138, 22);
		this.mnuEditPopupInsertRibs.Text = "In&sert Ribs...";
		this.dlgOpenFile.FileName = "File1";
		this.dlgPrint.AllowPrintToFile = false;
		this.dlgPrint.UseEXDialog = true;
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size (664, 453);
		base.Controls.Add (this.tbrCFS);
		base.Controls.Add (this.mnuCFS);
		base.Icon = (System.Drawing.Icon)resources.GetObject ("$this.Icon");
		base.IsMdiContainer = true;
		base.KeyPreview = true;
		base.MainMenuStrip = this.mnuCFS;
		base.Name = "mdiCFS";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "CFS";
		this.mnuCFS.ResumeLayout (false);
		this.mnuCFS.PerformLayout ();
		this.tbrCFS.ResumeLayout (false);
		this.tbrCFS.PerformLayout ();
		this.mnuEditPopup.ResumeLayout (false);
		base.ResumeLayout (false);
		base.PerformLayout ();
	}

	private void mdiCFS_Load (object sender, EventArgs e)
	{
		CFSInterface.RegistryWindows (0);
	}

	private void mdiCFS_Resize (object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Minimized) {
			if (CFS.blnSctInpLoaded) {
				My.MyProject.Forms.frmSctInp.Visible = false;
			}
			if (CFS.blnAnlInpLoaded) {
				My.MyProject.Forms.frmAnlInp.Visible = false;
			}
		} else if ($STATIC$mdiCFS_Resize$20211C1280B1$bytWSPrev == 1) {
			if (CFS.blnSctInpLoaded) {
				CFS.frmSctPic [CFS.intSctNow].BringToFront ();
				Application.DoEvents ();
				My.MyProject.Forms.frmSctInp.Visible = true;
			}
			if (CFS.blnAnlInpLoaded) {
				CFS.frmAnlPic [CFS.intAnlNow].BringToFront ();
				Application.DoEvents ();
				My.MyProject.Forms.frmAnlInp.Visible = true;
			}
		}
		$STATIC$mdiCFS_Resize$20211C1280B1$bytWSPrev = checked((byte)base.WindowState);
	}

	private void mdiCFS_KeyDown (object sender, KeyEventArgs e)
	{
		switch (checked(e.Modifiers + e.KeyValue)) {
		case Keys.O | Keys.Control:
			if (mnuFileOpen.Enabled) {
				mnuFileOpen_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.S | Keys.Control:
			if (mnuFileSave.Enabled) {
				mnuFileSave_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.F12:
			if (mnuFileSaveAs.Enabled) {
				mnuFileSaveAs_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.P | Keys.Control:
			if (mnuFilePrint.Enabled) {
				mnuFilePrint_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.Z | Keys.Control:
			if (mnuEditUndo.Enabled) {
				mnuEditUndo_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.Y | Keys.Control:
			if (mnuEditRedo.Enabled) {
				mnuEditRedo_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.X | Keys.Control:
			if (mnuEditCut.Enabled) {
				mnuEditCut_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.C | Keys.Control:
			if (mnuEditCopy.Enabled) {
				mnuEditCopy_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.V | Keys.Control:
			if (mnuEditPaste.Enabled) {
				mnuEditPaste_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.F1 | Keys.Control:
			if (mnuHelpContents.Enabled) {
				mnuHelpContents_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.F3:
			mnuView_Click (RuntimeHelpers.GetObjectValue (sender), null);
			if (mnuViewSectionInputs.Enabled) {
				mnuViewSectionInputs_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		case Keys.F4:
			mnuView_Click (RuntimeHelpers.GetObjectValue (sender), null);
			if (mnuViewAnalysisInputs.Enabled) {
				mnuViewAnalysisInputs_Click (RuntimeHelpers.GetObjectValue (sender), null);
			}
			e.Handled = true;
			break;
		}
	}

	private void mdiCFS_DragOver (object sender, DragEventArgs e)
	{
		if (base.Enabled & e.Data.GetDataPresent (DataFormats.FileDrop)) {
			e.Effect = DragDropEffects.Copy;
		} else {
			e.Effect = DragDropEffects.None;
		}
	}

	private void mdiCFS_DragDrop (object sender, DragEventArgs e)
	{
		if (!(base.Enabled & e.Data.GetDataPresent (DataFormats.FileDrop))) {
			return;
		}
		string[] array = (string[])e.Data.GetData (DataFormats.FileDrop);
		foreach (string text in array) {
			Activate ();
			Application.DoEvents ();
			if (Operators.CompareString (Strings.LCase (Strings.Right (text, 4)), ".dxf", TextCompare: false) == 0) {
				if (CFS.intLicenseType != 0) {
					CFSInterface.ImportDXFFile (text);
				}
			} else {
				CFSInterface.LoadFile (text);
			}
			if (Operators.CompareString (Strings.LCase (Strings.Right (text, 5)), ".cfsl", TextCompare: false) == 0 || Operators.CompareString (Strings.LCase (Strings.Right (text, 4)), ".scl", TextCompare: false) == 0) {
				break;
			}
		}
	}

	private void mdiCFS_FormClosing (object sender, FormClosingEventArgs e)
	{
		if (CFS.blnSctInpLoaded) {
			My.MyProject.Forms.frmSctInp.Close ();
		}
		if (CFS.blnAnlInpLoaded) {
			My.MyProject.Forms.frmAnlInp.Close ();
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void mdiCFS_FormClosed (object sender, FormClosedEventArgs e)
	{
		if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
			CFS.SingleLicenseConfig.AppendLog ("Released");
		} else if (CFS.intLicenseType == CFS.LicenseTypes.Semaphore) {
			CFS.NetworkLicenseConfig.AppendLog ("Released");
		}
		if (CFS.LicenseSemaphore != null) {
			CFS.LicenseSemaphore.Close ();
		}
		CFSInterface.RegistryWindows (1);
		CFSInterface.RegistryRecentFiles (1);
		CFSInterface.RegistrySpec (1);
		CFSInterface.RegistryTrace (1);
		CFSInterface.RegistryThickness (1);
		CFSInterface.RegistryCombinations (1);
		CFSInterface.RegistryView (1);
		ProjectData.EndApp ();
	}

	private void mnuFileNewSection_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmSctWizard.ShowDialog (this);
		My.MyProject.Forms.frmSctWizard.Dispose ();
	}

	private void mnuFileNewAnalysis_Click (object sender, EventArgs e)
	{
		if (CFS.intSctNow == 0) {
			Interaction.MsgBox ("You must first create or open the section you want to analyze.", MsgBoxStyle.Information);
			return;
		}
		My.MyProject.Forms.frmAnlWizard.ShowDialog (this);
		My.MyProject.Forms.frmAnlWizard.Dispose ();
	}

	private void mnuFileQuickDesign_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmQuickDesign.ShowDialog (this);
	}

	private void mnuFileOpen_Click (object sender, EventArgs e)
	{
		CFSInterface.LoadFile ();
	}

	private void mnuFileRecent_Click (object sender, EventArgs e)
	{
		if (My.MyProject.Forms.frmRecentFiles.ShowDialog (this) == DialogResult.OK && Strings.Len (RuntimeHelpers.GetObjectValue (My.MyProject.Forms.frmRecentFiles.Tag)) != 0) {
			CFSInterface.LoadFile (Conversions.ToString (My.MyProject.Forms.frmRecentFiles.Tag));
		}
	}

	private void mnuFileImportDXF_Click (object sender, EventArgs e)
	{
		if (CFS.intLicenseType == CFS.LicenseTypes.None) {
			CFS.LicenseRequired ("This feature requires a full CFS license.");
			return;
		}
		dlgOpenFile.Filter = "DXF Files (*.dxf)|*.dxf";
		dlgOpenFile.Title = "Import DXF File";
		if (dlgOpenFile.ShowDialog (this) != DialogResult.Cancel) {
			CFSInterface.ImportDXFFile (dlgOpenFile.FileName);
		}
	}

	private void mnuFileSave_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			CFSInterface.SaveSct (checked((byte)CFS.intSctNow));
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			CFSInterface.SaveAnl (CFS.intAnlNow);
		} else if (base.ActiveMdiChild is frmReportMaster) {
			CFSInterface.SaveReport ((frmReportMaster)base.ActiveMdiChild);
		}
	}

	private void mnuFileSaveAs_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			CFSInterface.SaveSct (checked((byte)CFS.intSctNow), blnSaveAs: true);
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			CFSInterface.SaveAnl (CFS.intAnlNow, blnSaveAs: true);
		} else if (base.ActiveMdiChild is frmReportMaster) {
			CFSInterface.SaveReport ((frmReportMaster)base.ActiveMdiChild);
		}
	}

	private void mnuFileClose_Click (object sender, EventArgs e)
	{
		base.ActiveMdiChild.Close ();
	}

	private void mnuFileReportInputs_Click (object sender, EventArgs e)
	{
		string text = string.Empty;
		if (base.ActiveMdiChild is frmSctPicMaster) {
			text = "1";
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			text = "2";
		} else if (base.ActiveMdiChild is frmReportMaster) {
			if (Information.IsNothing (RuntimeHelpers.GetObjectValue (base.ActiveMdiChild.Tag)) || Operators.ConditionalCompareObjectEqual (base.ActiveMdiChild.Tag, string.Empty, TextCompare: false)) {
				return;
			}
			short num = Conversions.ToByte (base.ActiveMdiChild.Tag);
			if (CFS.hdgReport [num].Parent == 1) {
				short num2 = CFSInterface.FindSctIndex (num);
				if (num2 == 0) {
					return;
				}
				text = "1";
				CFS.intSctNow = num2;
			} else {
				if (CFS.hdgReport [num].Parent != 2) {
					return;
				}
				short num2 = CFSInterface.FindAnlIndex (num);
				if (num2 == 0) {
					return;
				}
				text = "2";
				CFS.intAnlNow = checked((byte)num2);
			}
		}
		My.MyProject.Forms.frmReportDialog.rtfDialog.Rtf = string.Empty;
		My.MyProject.Forms.frmReportDialog.Tag = text;
		if (Operators.CompareString (text, "1", TextCompare: false) == 0) {
			Report.rptSctInp (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow]);
		} else if (Operators.CompareString (text, "2", TextCompare: false) == 0) {
			Report.rptAnlInp (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Analyses [CFS.intAnlNow]);
		}
		My.MyProject.Forms.frmReportDialog.ShowDialog (this);
		My.MyProject.Forms.frmReportDialog.Dispose ();
	}

	private void mnuFilePrint_Click (object sender, EventArgs e)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default:
					ProjectData.ClearProjectError ();
					num2 = 2;
					if (PrinterSettings.InstalledPrinters.Count == 0) {
						Interaction.MsgBox ("No printers available", MsgBoxStyle.Information);
						goto end_IL_0000;
					}
					My.MyProject.Forms.frmPrint.ShowDialog (this);
					My.MyProject.Forms.frmPrint.Dispose ();
					goto end_IL_0000_2;
				case 121:
					num = -1;
					switch (num2) {
					case 2:
						Interaction.MsgBox ("Unexpected Error:  " + Information.Err ().Description, MsgBoxStyle.Information);
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						goto end_IL_0000_2;
					}
					break;
				}
				goto IL_00af;
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 121;
				continue;
			}
			break;
			IL_00af:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
	}

	private void mnuFileExit_Click (object sender, EventArgs e)
	{
		Close ();
	}

	private void mnuEditUndo_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			CFSInterface.UndoSct ();
			base.ActiveMdiChild.Select ();
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			CFSInterface.UndoAnl ();
			base.ActiveMdiChild.Select ();
		}
	}

	private void mnuEditRedo_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			CFSInterface.RedoSct ();
			base.ActiveMdiChild.Select ();
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			CFSInterface.RedoAnl ();
			base.ActiveMdiChild.Select ();
		}
	}

	private void mnuEditCut_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
			CFSInterface.CopyElements (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart], elemGrid.RowStart, elemGrid.RowEnd);
			CFSInterface.DeleteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid.RowStart, elemGrid.RowEnd);
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			switch (CFS.intAnlTabNow) {
			case 1: {
				ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
				CFSInterface.CopyBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
				CFSInterface.DeleteBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
				break;
			}
			case 2: {
				ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
				CFSInterface.CopySupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
				CFSInterface.DeleteSupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
				break;
			}
			case 3: {
				ref GridState loadGrid = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].LoadGrid;
				CFSInterface.CopyLoads (ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg], loadGrid.RowStart, loadGrid.RowEnd);
				CFSInterface.DeleteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, loadGrid.RowStart, loadGrid.RowEnd);
				break;
			}
			case 4: {
				ref GridState lFGrid = ref CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].LFGrid;
				CFSInterface.CopyLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, lFGrid.RowStart, lFGrid.RowEnd);
				CFSInterface.DeleteLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, lFGrid.RowStart, lFGrid.RowEnd);
				break;
			}
			}
		}
	}

	private void mnuEditCopy_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
			CFSInterface.CopyElements (CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart], elemGrid.RowStart, elemGrid.RowEnd);
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			switch (CFS.intAnlTabNow) {
			case 1: {
				ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
				CFSInterface.CopyBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
				break;
			}
			case 2: {
				ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
				CFSInterface.CopySupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
				break;
			}
			case 3: {
				ref GridState loadGrid = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].LoadGrid;
				CFSInterface.CopyLoads (ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg], loadGrid.RowStart, loadGrid.RowEnd);
				break;
			}
			case 4: {
				ref GridState lFGrid = ref CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].LFGrid;
				CFSInterface.CopyLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, lFGrid.RowStart, lFGrid.RowEnd);
				break;
			}
			}
		} else if (base.ActiveMdiChild is frmReportMaster) {
			Clipboard.Clear ();
			frmReportMaster frmReportMaster2 = (frmReportMaster)base.ActiveMdiChild;
			if (frmReportMaster2.rtfReport.SelectionLength == 0) {
				RichTextBox richTextBox = new RichTextBox ();
				Report.rptHeading (richTextBox, CFS.hdgReport [Conversions.ToByte (frmReportMaster2.Tag)]);
				richTextBox.SelectionStart = Strings.Len (richTextBox.Text);
				richTextBox.SelectedRtf = frmReportMaster2.rtfReport.Rtf;
				DataObject dataObject = new DataObject ();
				dataObject.SetData (DataFormats.Text, richTextBox.Text);
				dataObject.SetData (DataFormats.Rtf, richTextBox.Rtf);
				Clipboard.SetDataObject (dataObject);
				richTextBox.Dispose ();
			} else {
				DataObject dataObject2 = new DataObject ();
				dataObject2.SetData (DataFormats.Text, frmReportMaster2.rtfReport.SelectedText);
				dataObject2.SetData (DataFormats.Rtf, frmReportMaster2.rtfReport.SelectedRtf);
				Clipboard.SetDataObject (dataObject2);
			}
			CFSInterface.bytClipBoard = 4;
			mnuEditPaste.Text = "&Paste";
			mnuEditPopupPaste.Text = mnuEditPaste.Text;
			tbrPaste.Text = mnuEditPaste.Text;
			CFSInterface.SetMenuEdit ();
		}
	}

	private void mnuEditCopyImage_Click (object sender, EventArgs e)
	{
		DataObject dataObject = new DataObject ();
		if (base.ActiveMdiChild is frmSctPicMaster) {
			dataObject.SetData (DataFormats.Bitmap, CFS.frmSctPic [CFS.intSctNow].picSct.Image);
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			dataObject.SetData (DataFormats.Bitmap, CFS.frmAnlPic [CFS.intAnlNow].picAnl.Image);
		}
		Clipboard.Clear ();
		Clipboard.SetDataObject (dataObject);
		mnuEditPaste.Text = "&Paste";
		tbrPaste.Text = mnuEditPaste.Text;
		mnuEditPopupPaste.Text = mnuEditPaste.Text;
		CFSInterface.bytClipBoard = 11;
		CFSInterface.strClipBoard = string.Empty;
		CFSInterface.SetMenuEdit ();
	}

	private void mnuEditPaste_Click (object sender, EventArgs e)
	{
		CFSInterface.SetMenuEdit ();
		if (!mnuEditPaste.Enabled) {
			return;
		}
		if (base.ActiveMdiChild is frmSctPicMaster) {
			Section section = CFS.Sections [CFS.intSctNow];
			CFSInterface.PasteElements (CFS.Sections [CFS.intSctNow], section.iPart, section.Part [section.iPart].ElemGrid.RowStart, section.Part [section.iPart].ElemGrid.RowEnd);
			section = null;
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			switch (CFS.intAnlTabNow) {
			case 1: {
				ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
				CFSInterface.PasteBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
				break;
			}
			case 2: {
				ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
				CFSInterface.PasteSupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
				break;
			}
			case 3: {
				Analysis analysis2 = CFS.Analyses [CFS.intAnlNow];
				CFSInterface.PasteLoads (CFS.Analyses [CFS.intAnlNow], analysis2.iLdg, analysis2.Ldg [analysis2.iLdg].LoadGrid.RowStart, analysis2.Ldg [analysis2.iLdg].LoadGrid.RowEnd);
				analysis2 = null;
				break;
			}
			case 4: {
				Analysis analysis = CFS.Analyses [CFS.intAnlNow];
				CFSInterface.PasteLFs (CFS.Analyses [CFS.intAnlNow], analysis.iComb, analysis.Comb [analysis.iComb].LFGrid.RowStart, analysis.Comb [analysis.iComb].LFGrid.RowEnd);
				analysis = null;
				break;
			}
			}
		}
	}

	private void mnuEditInsert_Click (object sender, EventArgs e)
	{
		ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
		CFSInterface.InsertElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid.RowStart, elemGrid.RowEnd);
	}

	private void mnuEditDelete_Click (object sender, EventArgs e)
	{
		if (base.ActiveMdiChild is frmSctPicMaster) {
			ref GridState elemGrid = ref CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].ElemGrid;
			CFSInterface.DeleteElements (CFS.Sections [CFS.intSctNow], CFS.Sections [CFS.intSctNow].iPart, elemGrid.RowStart, elemGrid.RowEnd);
		} else if (base.ActiveMdiChild is frmAnlPicMaster) {
			switch (CFS.intAnlTabNow) {
			case 1: {
				ref GridState beamGrid = ref CFS.Analyses [CFS.intAnlNow].BeamGrid;
				CFSInterface.DeleteBeams (CFS.Analyses [CFS.intAnlNow], beamGrid.RowStart, beamGrid.RowEnd);
				break;
			}
			case 2: {
				ref GridState supGrid = ref CFS.Analyses [CFS.intAnlNow].SupGrid;
				CFSInterface.DeleteSupports (CFS.Analyses [CFS.intAnlNow], supGrid.RowStart, supGrid.RowEnd);
				break;
			}
			case 3: {
				ref GridState loadGrid = ref CFS.Analyses [CFS.intAnlNow].Ldg [CFS.Analyses [CFS.intAnlNow].iLdg].LoadGrid;
				CFSInterface.DeleteLoads (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iLdg, loadGrid.RowStart, loadGrid.RowEnd);
				break;
			}
			case 4: {
				ref GridState lFGrid = ref CFS.Analyses [CFS.intAnlNow].Comb [CFS.Analyses [CFS.intAnlNow].iComb].LFGrid;
				CFSInterface.DeleteLFs (CFS.Analyses [CFS.intAnlNow], CFS.Analyses [CFS.intAnlNow].iComb, lFGrid.RowStart, lFGrid.RowEnd);
				break;
			}
			}
		}
	}

	private void mnuEditRotatePart_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmAngle.Text = "Rotate Part: " + CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].Name;
		My.MyProject.Forms.frmAngle.lblAngle.Text = "Angle to rotate";
		My.MyProject.Forms.frmAngle.Tag = "RotatePart";
		My.MyProject.Forms.frmAngle.ShowDialog (this);
		My.MyProject.Forms.frmAngle.Dispose ();
	}

	private void mnuEditRotateSection_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmAngle.Text = "Rotate Section: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		My.MyProject.Forms.frmAngle.lblAngle.Text = "Angle to rotate";
		My.MyProject.Forms.frmAngle.Tag = "RotateSct";
		My.MyProject.Forms.frmAngle.ShowDialog (this);
		My.MyProject.Forms.frmAngle.Dispose ();
	}

	private void mnuEditRotatePrincipal_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (!CFS.Sections [CFS.intSctNow].SctProp) {
			CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg, blnCheckLicense: false);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			if (!CFS.Sections [CFS.intSctNow].SctProp) {
				return;
			}
		}
		CFSInterface.StoreUndoSct ("Rotate");
		Section obj = CFS.Sections [CFS.intSctNow];
		float num = obj.Prop.Alpha;
		if ((double)Math.Abs (num) > Math.PI / 4.0) {
			num = (float)((double)num - (double)Math.Sign (num) * Math.PI / 2.0);
		}
		obj.Rotate (0f - num);
		obj.Saved = false;
		obj.RevDate = DateAndTime.Now;
		obj.RevBy = CFS.User.Name;
		obj.SctProp = false;
		obj.iPt = 0;
		_ = null;
		CFS.blnRefreshGrdElements = true;
		CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
		CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		CFSInterface.UpdateAnl (checked((byte)CFS.intSctNow));
		CFSInterface.SetMenuEdit ();
	}

	private void mnuEditMirrorPart_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmAngle.Text = "Mirror Part: " + CFS.Sections [CFS.intSctNow].Part [CFS.Sections [CFS.intSctNow].iPart].Name;
		My.MyProject.Forms.frmAngle.lblAngle.Text = "Angle of mirror";
		My.MyProject.Forms.frmAngle.Tag = "MirrorPart";
		My.MyProject.Forms.frmAngle.ShowDialog (this);
		My.MyProject.Forms.frmAngle.Dispose ();
	}

	private void mnuEditMirrorSection_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmAngle.Text = "Mirror Section: " + CFSInterface.GetFileName (CFS.Sections [CFS.intSctNow].Filename);
		My.MyProject.Forms.frmAngle.lblAngle.Text = "Angle of mirror";
		My.MyProject.Forms.frmAngle.Tag = "MirrorSct";
		My.MyProject.Forms.frmAngle.ShowDialog (this);
		My.MyProject.Forms.frmAngle.Dispose ();
	}

	private void mnuEditCenterSection_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg, blnCheckLicense: false);
		if (Strings.Len (strMsg) != 0) {
			Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
		}
		if (!CFS.Sections [CFS.intSctNow].SctProp) {
			return;
		}
		CFSInterface.StoreUndoSct ("Center Section");
		Section section = CFS.Sections [CFS.intSctNow];
		float xcg = section.Prop.Xcg;
		float ycg = section.Prop.Ycg;
		short nPart = section.nPart;
		checked {
			for (short num = 1; num <= nPart; num = (short)unchecked(num + 1)) {
				if (section.Part [num].nElem > 0) {
					section.Part [num].XPosition = section.Part [num].XPosition - xcg;
					section.Part [num].YPosition = section.Part [num].YPosition - ycg;
				}
			}
			if ((section.nPart == 1) & (section.Part [1].nElem > 0)) {
				section.Part [1].iXPosition = 1;
				section.Part [1].iYPosition = 1;
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			CFS.blnRefreshGrdElements = true;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			section = null;
		}
	}

	private void mnuEditCompleteSymmetry_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		Cursor.Current = Cursors.WaitCursor;
		Section section = CFS.Sections [CFS.intSctNow];
		Part part = section.Part [section.iPart];
		byte b = (byte)((!part.Closed) ? 254 : byte.MaxValue);
		if ((uint)part.nElem >= (uint)b) {
			Cursor.Current = Cursors.Default;
			Interaction.MsgBox ("Too many elements to complete part symmetry.", MsgBoxStyle.Information);
			return;
		}
		checked {
			short num = (short)(2 * unchecked((int)part.nElem) - 1);
			if (num > b) {
				num = b;
			}
			CFSInterface.StoreUndoSct ("Part Symmetry");
			if (num > Information.UBound (part.Element)) {
				ref Element[] element = ref part.Element;
				element = (Element[])Utils.CopyArray (element, new Element[(int)Math.Round (Math.Ceiling ((double)num / 10.0) * 10.0) + 1]);
			}
			short num2 = part.nElem;
			for (short num3 = (short)(unchecked((int)part.nElem) - 1); num3 >= 1; num3 = (short)unchecked(num3 + -1)) {
				num2 = (short)(num2 + 1);
				part.Element [num2].Len = part.Element [num3].Len;
				float num4 = 2f * part.Element [part.nElem].Ang - part.Element [num3].Ang;
				while ((double)num4 <= -Math.PI) {
					num4 = (float)((double)num4 + Math.PI * 2.0);
				}
				while ((double)num4 >= Math.PI * 2.0) {
					num4 = (float)((double)num4 - Math.PI * 2.0);
				}
				part.Element [num2].Ang = num4;
				part.Element [num2].Rad = part.Element [num3 + 1].Rad;
				part.Element [num2].Web = part.Element [num3].Web;
				part.Element [num2].K = part.Element [num3].K;
				part.Element [num2].Hole = part.Element [num3].Hole;
				part.Element [num2].Dist = part.Element [num3].Len - part.Element [num3].Dist;
				if (num2 == b) {
					break;
				}
			}
			part.nElem = (byte)num2;
			part = null;
			bool blnChg = default(bool);
			section.Part [section.iPart].Geometry (ref blnChg, ref strMsg);
			if (Strings.Len (strMsg) != 0) {
				Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
			}
			section.Saved = false;
			section.RevDate = DateAndTime.Now;
			section.RevBy = CFS.User.Name;
			section.SctProp = false;
			section.iPt = 0;
			section = null;
			CFS.blnRefreshGrdElements = true;
			CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
			CFSInterface.UpdateAnl ((byte)CFS.intSctNow);
			CFSInterface.SetMenuEdit ();
			Cursor.Current = Cursors.Default;
		}
	}

	private void mnuEditInsertRibs_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmRibs.ShowDialog (this);
		My.MyProject.Forms.frmRibs.Dispose ();
	}

	private void mnuView_Click (object sender, EventArgs e)
	{
		mnuViewSectionInputs.Enabled = CFS.intSctNow > 0;
		mnuViewAnalysisInputs.Enabled = CFS.intAnlNow > 0;
	}

	private void mnuViewToolbar_Click (object sender, EventArgs e)
	{
		tbrCFS.Visible = mnuViewToolbar.Checked;
	}

	private void mnuViewInputsOnTop_Click (object sender, EventArgs e)
	{
		mnuViewInputsOnTop.Checked = !mnuViewInputsOnTop.Checked;
		checked {
			if (!mnuViewInputsOnTop.Checked) {
				if (CFS.blnSctInpLoaded) {
					short left = (short)My.MyProject.Forms.frmSctInp.Left;
					short top = (short)My.MyProject.Forms.frmSctInp.Top;
					My.MyProject.Forms.frmSctInp.Close ();
					mnuViewSectionInputs_Click (RuntimeHelpers.GetObjectValue (sender), e);
					My.MyProject.Forms.frmSctInp.Left = left;
					My.MyProject.Forms.frmSctInp.Top = top;
				}
				if (CFS.blnAnlInpLoaded) {
					short left = (short)My.MyProject.Forms.frmAnlInp.Left;
					short top = (short)My.MyProject.Forms.frmAnlInp.Top;
					My.MyProject.Forms.frmAnlInp.Close ();
					mnuViewAnalysisInputs_Click (RuntimeHelpers.GetObjectValue (sender), e);
					My.MyProject.Forms.frmAnlInp.Left = left;
					My.MyProject.Forms.frmAnlInp.Top = top;
				}
			} else {
				if (CFS.blnSctInpLoaded) {
					My.MyProject.Forms.frmSctInp.Hide ();
					My.MyProject.Forms.frmSctInp.Show (this);
				}
				if (CFS.blnAnlInpLoaded) {
					My.MyProject.Forms.frmAnlInp.Hide ();
					My.MyProject.Forms.frmAnlInp.Show (this);
				}
			}
			Application.DoEvents ();
			Activate ();
		}
	}

	public void mnuViewSectionInputs_Click (object sender, EventArgs e)
	{
		if (CFS.intSctNow != 0) {
			bool flag;
			if (CFS.blnSctInpLoaded) {
				flag = false;
			} else {
				flag = true;
				My.MyProject.Forms.frmSctInp.Text = "Section Inputs: " + CFS.frmSctPic [CFS.intSctNow].Text;
				CFSInterface.RefreshSct (CFS.Sections [CFS.intSctNow]);
			}
			CFS.frmSctPic [CFS.intSctNow].BringToFront ();
			Application.DoEvents ();
			My.MyProject.Forms.frmSctInp.Hide ();
			if (mnuViewInputsOnTop.Checked) {
				My.MyProject.Forms.frmSctInp.Show (this);
			} else {
				My.MyProject.Forms.frmSctInp.Show ();
			}
			My.MyProject.Forms.frmSctInp.Activate ();
			if (flag) {
				My.MyProject.Forms.frmSctInp.txtDescription.Select ();
			}
		}
	}

	public void mnuViewAnalysisInputs_Click (object sender, EventArgs e)
	{
		if (CFS.intAnlNow == 0) {
			return;
		}
		bool flag;
		if (CFS.blnAnlInpLoaded) {
			flag = false;
		} else {
			flag = true;
			My.MyProject.Forms.frmAnlInp.Text = "Analysis Inputs: " + CFS.frmAnlPic [CFS.intAnlNow].Text;
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
		}
		CFS.frmAnlPic [CFS.intAnlNow].BringToFront ();
		Application.DoEvents ();
		My.MyProject.Forms.frmAnlInp.Hide ();
		if (mnuViewInputsOnTop.Checked) {
			My.MyProject.Forms.frmAnlInp.Show (this);
		} else {
			My.MyProject.Forms.frmAnlInp.Show ();
		}
		My.MyProject.Forms.frmAnlInp.Activate ();
		if (flag) {
			if (CFS.intAnlTabNow < 0) {
				CFS.intAnlTabNow = 0;
			}
			if (CFS.intAnlTabNow == 0) {
				My.MyProject.Forms.frmAnlInp.txtDescription.Select ();
			} else {
				My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = CFS.intAnlTabNow;
			}
		}
	}

	private void mnuViewRenderMembers_Click (object sender, EventArgs e)
	{
		mnuViewRenderMembers.Checked = !mnuViewRenderMembers.Checked;
		Form[] mdiChildren = base.MdiChildren;
		foreach (Form form in mdiChildren) {
			if (form is frmAnlPicMaster) {
				CFSInterface.PlotAnl ((frmAnlPicMaster)form, CFS.Analyses [Conversions.ToByte (form.Tag)]);
			}
		}
	}

	private void mnuViewXYAxes_Click (object sender, EventArgs e)
	{
		mnuViewXYAxes.Checked = !mnuViewXYAxes.Checked;
		Form[] mdiChildren = base.MdiChildren;
		foreach (Form form in mdiChildren) {
			if (form is frmSctPicMaster) {
				CFSInterface.PlotSct ((frmSctPicMaster)form, CFS.Sections [Conversions.ToByte (form.Tag)]);
			} else if (form is frmAnlPicMaster) {
				CFSInterface.PlotAnl ((frmAnlPicMaster)form, CFS.Analyses [Conversions.ToByte (form.Tag)]);
			}
		}
	}

	private void mnuComputeProperties_Click (object sender, EventArgs e)
	{
		if (Report.rptProperties (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow])) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (this);
			My.MyProject.Forms.frmReportDialog.Dispose ();
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		}
	}

	private void mnuComputeEffProperties_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		Cursor.Current = Cursors.WaitCursor;
		CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg);
		CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		Cursor.Current = Cursors.Default;
		if (Strings.Len (strMsg) != 0) {
			Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
		}
		if (CFS.Sections [CFS.intSctNow].SctProp) {
			CFS.Sections [CFS.intSctNow].CalcStrength (CFS.intSpecNow);
			My.MyProject.Forms.frmEffProp.ShowDialog (this);
			My.MyProject.Forms.frmEffProp.Dispose ();
		}
	}

	private void mnuComputeStrength_Click (object sender, EventArgs e)
	{
		if (Report.rptStrength (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow], CFS.intSpecNow)) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (this);
			My.MyProject.Forms.frmReportDialog.Dispose ();
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		}
	}

	private void mnuComputeMemberCheck_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		checked {
			if (Conversions.ToByte (mnuCompute.Tag) == 1) {
				Cursor.Current = Cursors.WaitCursor;
				CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg);
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				Cursor.Current = Cursors.Default;
				if (Strings.Len (strMsg) != 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
				if (CFS.Sections [CFS.intSctNow].SctProp) {
					My.MyProject.Forms.frmMemberCheck.ShowDialog (this);
					My.MyProject.Forms.frmMemberCheck.Dispose ();
				}
			} else {
				if (Conversions.ToByte (mnuCompute.Tag) != 2) {
					return;
				}
				Cursor.Current = Cursors.WaitCursor;
				Analysis analysis = CFS.Analyses [CFS.intAnlNow];
				CFSInterface.SortBeams (CFS.Analyses [CFS.intAnlNow]);
				CFSInterface.SortSups (CFS.Analyses [CFS.intAnlNow]);
				short nLdg = analysis.nLdg;
				for (short num = 1; num <= nLdg; num = (short)unchecked(num + 1)) {
					CFSInterface.SortLoads (ref analysis.Ldg [num]);
				}
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
				if (analysis.iComb != analysis.iCombSol) {
					CFS.Analyses [CFS.intAnlNow].Analyze (ref strMsg);
					Cursor.Current = Cursors.Default;
					if (Strings.Len (strMsg) != 0) {
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					}
					if (CFS.Analyses [CFS.intAnlNow].iCombSol == 0) {
						return;
					}
				}
				if (CFS.Analyses [CFS.intAnlNow].Torsion) {
					CFS.Analyses [CFS.intAnlNow].AnalyzeTorsion (ref strMsg);
					Cursor.Current = Cursors.Default;
					if (Strings.Len (strMsg) != 0) {
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
						return;
					}
				}
				analysis = null;
				Cursor.Current = Cursors.Default;
				My.MyProject.Forms.frmLocation.Tag = "1";
				My.MyProject.Forms.frmLocation.ShowDialog (this);
				My.MyProject.Forms.frmLocation.Dispose ();
			}
		}
	}

	private void mnuComputeWebCheck_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		checked {
			if (Conversions.ToByte (mnuCompute.Tag) == 1) {
				Cursor.Current = Cursors.WaitCursor;
				CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg);
				CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
				Cursor.Current = Cursors.Default;
				if (Strings.Len (strMsg) != 0) {
					Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
				}
				if (CFS.Sections [CFS.intSctNow].SctProp) {
					My.MyProject.Forms.frmWebCrippling.ShowDialog (this);
					My.MyProject.Forms.frmWebCrippling.Dispose ();
				}
			} else {
				if (Conversions.ToByte (mnuCompute.Tag) != 2) {
					return;
				}
				Cursor.Current = Cursors.WaitCursor;
				Analysis analysis = CFS.Analyses [CFS.intAnlNow];
				CFSInterface.SortBeams (CFS.Analyses [CFS.intAnlNow]);
				CFSInterface.SortSups (CFS.Analyses [CFS.intAnlNow]);
				short nLdg = analysis.nLdg;
				for (short num = 1; num <= nLdg; num = (short)unchecked(num + 1)) {
					CFSInterface.SortLoads (ref analysis.Ldg [num]);
				}
				CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
				if (analysis.iComb != analysis.iCombSol) {
					CFS.Analyses [CFS.intAnlNow].Analyze (ref strMsg);
					Cursor.Current = Cursors.Default;
					if (Strings.Len (strMsg) != 0) {
						Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
					}
					if (CFS.Analyses [CFS.intAnlNow].iCombSol == 0) {
						return;
					}
				}
				analysis = null;
				Cursor.Current = Cursors.Default;
				My.MyProject.Forms.frmLocation.Tag = "2";
				My.MyProject.Forms.frmLocation.ShowDialog (this);
				My.MyProject.Forms.frmLocation.Dispose ();
			}
		}
	}

	private void mnuComputeTorsionProperties_Click (object sender, EventArgs e)
	{
		if (CFS.Sections [CFS.intSctNow].nPart > 1) {
			Interaction.MsgBox ("Torsion properties can only be calculated for a section with one part.", MsgBoxStyle.Information);
		} else if (CFS.Sections [CFS.intSctNow].CwOverride > 0f) {
			Interaction.MsgBox ("Torsion properties cannot be determined if Cw is overridden.", MsgBoxStyle.Information);
		} else if (Report.rptTorsionProp (My.MyProject.Forms.frmReportDialog.rtfDialog, CFS.Sections [CFS.intSctNow])) {
			My.MyProject.Forms.frmReportDialog.Tag = "1";
			My.MyProject.Forms.frmReportDialog.ShowDialog (this);
			My.MyProject.Forms.frmReportDialog.Dispose ();
			CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		}
	}

	private void mnuComputeElasticBuckling_Click (object sender, EventArgs e)
	{
		string strMsg = string.Empty;
		if (CFS.Sections [CFS.intSctNow].nPart > 1) {
			Interaction.MsgBox ("Elastic buckling can only be performed on a section with one part.", MsgBoxStyle.Information);
			return;
		}
		Cursor.Current = Cursors.WaitCursor;
		CFS.Sections [CFS.intSctNow].CalcProperties (ref strMsg);
		CFSInterface.PlotSct (CFS.frmSctPic [CFS.intSctNow], CFS.Sections [CFS.intSctNow]);
		Cursor.Current = Cursors.Default;
		if (Strings.Len (strMsg) != 0) {
			Interaction.MsgBox (strMsg, MsgBoxStyle.Information);
		}
		if (CFS.Sections [CFS.intSctNow].SctProp) {
			My.MyProject.Forms.frmBuckleParam.ShowDialog (this);
			My.MyProject.Forms.frmBuckleParam.Dispose ();
		}
	}

	private void mnuComputeDiagrams_Click (object sender, EventArgs e)
	{
		string empty = string.Empty;
		Analysis analysis = CFS.Analyses [CFS.intAnlNow];
		CFSInterface.SortBeams (CFS.Analyses [CFS.intAnlNow]);
		CFSInterface.SortSups (CFS.Analyses [CFS.intAnlNow]);
		short nLdg = analysis.nLdg;
		checked {
			for (short num = 1; num <= nLdg; num = (short)unchecked(num + 1)) {
				CFSInterface.SortLoads (ref analysis.Ldg [num]);
			}
			CFSInterface.RefreshAnl (CFS.Analyses [CFS.intAnlNow]);
			analysis = null;
			if (CFS.intLicenseType == CFS.LicenseTypes.None) {
				if (CFS.Analyses [CFS.intAnlNow].nBeam > 1) {
					CFS.LicenseRequired ("This feature requires a full CFS license for analyses with multiple members.");
					return;
				}
				if (CFS.Analyses [CFS.intAnlNow].nSup > 3) {
					CFS.LicenseRequired ("This feature requires a full CFS license for analyses with more than 3 supports.");
					return;
				}
				empty = CFS.Sections [CFS.Analyses [CFS.intAnlNow].Beam [1].iSct].CheckBasicSection ();
				if (empty.Length > 0) {
					CFS.LicenseRequired (empty);
					return;
				}
			}
			My.MyProject.Forms.frmDiagrams.ShowDialog (this);
			My.MyProject.Forms.frmDiagrams.Dispose ();
		}
	}

	private void mnuTools_Click (object sender, EventArgs e)
	{
	}

	private void mnuToolsSpec1999ASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 0;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec1999LRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 1;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2001USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 2;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2001USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 3;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2001MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 4;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2001MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 5;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2001CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 6;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2004USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 7;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2004USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 8;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2004MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 9;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2004MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 10;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2004CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 11;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2007USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 12;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2007USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 13;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2007MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 14;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2007MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 15;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2007CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 16;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2010USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 17;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2010USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 18;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2010MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 19;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2010MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 20;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2010CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 21;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2012USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 22;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2012USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 23;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2012MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 24;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2012MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 25;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2012CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 26;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2016USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 27;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2016USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 28;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2016MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 29;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2016MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 30;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2016CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 31;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2018USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 32;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2018USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 33;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2018MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 34;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2018MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 35;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2018CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 36;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2022USASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 37;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2022USLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 38;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2022MexicoASD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 39;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2022MexicoLRFD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 40;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsSpec2022CanadaLSD_Click (object sender, EventArgs e)
	{
		CFS.intSpecNow = 41;
		CFSInterface.SetMenuSpec ();
	}

	private void mnuToolsBucklingSpec_Click (object sender, EventArgs e)
	{
		mnuToolsBucklingSpec.Checked = true;
		mnuToolsBucklingTheory.Checked = false;
		CFS.blnBucklingTheory = false;
	}

	private void mnuToolsBucklingTheory_Click (object sender, EventArgs e)
	{
		mnuToolsBucklingSpec.Checked = false;
		mnuToolsBucklingTheory.Checked = true;
		CFS.blnBucklingTheory = true;
	}

	private void mnuToolsTraceAll_Click (object sender, EventArgs e)
	{
		CFS.blnTraceColdWork = (CFS.blnTraceEffProp = (CFS.blnTraceWebCrip = (CFS.blnTraceMemberChk = (CFS.blnTraceStrength = !mnuToolsTraceAll.Checked))));
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsTraceStrength_Click (object sender, EventArgs e)
	{
		CFS.blnTraceStrength = !mnuToolsTraceStrength.Checked;
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsTraceMemberCheck_Click (object sender, EventArgs e)
	{
		CFS.blnTraceMemberChk = !mnuToolsTraceMemberCheck.Checked;
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsTraceWebCheck_Click (object sender, EventArgs e)
	{
		CFS.blnTraceWebCrip = !mnuToolsTraceWebCheck.Checked;
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsTraceEffectiveSection_Click (object sender, EventArgs e)
	{
		CFS.blnTraceEffProp = !mnuToolsTraceEffectiveSection.Checked;
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsTraceColdWork_Click (object sender, EventArgs e)
	{
		CFS.blnTraceColdWork = !mnuToolsTraceColdWork.Checked;
		CFSInterface.SetMenuTrace ();
	}

	private void mnuToolsOptions_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmOptions.ShowDialog (this);
		My.MyProject.Forms.frmOptions.Dispose ();
	}

	private void mnuToolsPurchaseLicense_Click (object sender, EventArgs e)
	{
		if (!CFS.Launch ("https://secure.softwarekey.com/solo/products/Product.aspx?ProductID=411592")) {
			Interaction.MsgBox ("Unable to launch the product catalog web page.\r\n\r\n" + "For additional ordering information, visit www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}

	private void mnuToolsRenewLicense_Click (object sender, EventArgs e)
	{
		string text = "https://secure.softwarekey.com/solo/customers/RenewalsAndUpgrades.aspx?AuthorID=5117130";
		if (CFS.intLicenseType == CFS.LicenseTypes.SingleUser) {
			text = text + "&LicenseID=" + Conversions.ToString (CFS.SingleLicense.LicenseID);
		} else if (CFS.intLicenseType == CFS.LicenseTypes.Semaphore) {
			text = text + "&LicenseID=" + Conversions.ToString (CFS.NetworkLicense.LicenseID);
		} else if (CFS.SingleLicense != null && CFS.SingleLicense.LicenseID > 0) {
			text = text + "&LicenseID=" + Conversions.ToString (CFS.SingleLicense.LicenseID);
		} else if (CFS.NetworkLicense != null && CFS.NetworkLicense.LicenseID > 0) {
			text = text + "&LicenseID=" + Conversions.ToString (CFS.NetworkLicense.LicenseID);
		}
		if (!CFS.Launch (text)) {
			Interaction.MsgBox ("Unable to launch the license renewal web page.\r\n\r\n" + "For additional ordering information, visit www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}

	private void mnuToolsSingleUserLicense_Click (object sender, EventArgs e)
	{
		if (CFS.IsRemoteSession ()) {
			Interaction.MsgBox ("A single-user license is not available for remote use.", MsgBoxStyle.Information);
			return;
		}
		My.MyProject.Forms.frmLicenseSingle.ShowDialog (this);
		My.MyProject.Forms.frmLicenseSingle.Dispose ();
	}

	private void mnuToolsNetworkLicense_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmLicenseNetwork.ShowDialog (this);
		My.MyProject.Forms.frmLicenseNetwork.Dispose ();
	}

	private void mnuToolsLicensePortal_Click (object sender, EventArgs e)
	{
		if (!CFS.Launch ("https://secure.softwarekey.com/solo/customers/Default.aspx?AuthorID=5117130")) {
			Interaction.MsgBox ("Unable to launch the license portal web page.\r\n\r\n" + "For additional ordering information, visit www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}

	private void mnuToolsSectionGenerator_Click (object sender, EventArgs e)
	{
		if (CFS.intSctNow == 0) {
			Interaction.MsgBox ("You must first create or open the base section you want to generate from.", MsgBoxStyle.Information);
		}
	}

	private void mnuToolsLibraryBuilder_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmSctLib.ShowDialog (this);
		My.MyProject.Forms.frmSctLib.Dispose ();
	}

	private void mnuWindows_Click (object sender, EventArgs e)
	{
		if (base.MdiChildren.Count () > 0) {
			mnuWindowsCascade.Enabled = true;
			mnuWindowsTileVertical.Enabled = true;
			mnuWindowsTileHorizontal.Enabled = true;
			mnuWindowsArrangeIcons.Enabled = true;
			mnuWindowsCloseAll.Enabled = true;
		} else {
			mnuWindowsCascade.Enabled = false;
			mnuWindowsTileVertical.Enabled = false;
			mnuWindowsTileHorizontal.Enabled = false;
			mnuWindowsArrangeIcons.Enabled = false;
			mnuWindowsCloseAll.Enabled = false;
		}
	}

	private void mnuWindowsCascade_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.Cascade);
	}

	private void mnuWindowsTileVertical_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.TileVertical);
	}

	private void mnuWindowsTileHorizontal_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.TileHorizontal);
	}

	private void mnuWindowsArrangeIcons_Click (object sender, EventArgs e)
	{
		LayoutMdi (MdiLayout.ArrangeIcons);
	}

	private void mnuWindowsCloseAll_Click (object sender, EventArgs e)
	{
		CFSInterface.CloseAll ();
	}

	private void mnuHelpContents_Click (object sender, EventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", HelpNavigator.TableOfContents);
	}

	private void mnuHelpIndex_Click (object sender, EventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", HelpNavigator.Index);
	}

	private void mnuHelpSearch_Click (object sender, EventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", HelpNavigator.Find, string.Empty);
	}

	private void mnuHelpRSGSoftware_Click (object sender, EventArgs e)
	{
		if (!CFS.Launch ("https://www.rsgsoftware.com")) {
			Interaction.MsgBox ("Unable to launch the web page.\r\n" + "The address is https://www.rsgsoftware.com.", MsgBoxStyle.Information);
		}
	}

	private void mnuHelpAbout_Click (object sender, EventArgs e)
	{
		My.MyProject.Forms.frmAbout.ShowDialog (this);
		My.MyProject.Forms.frmAbout.Dispose ();
	}

	private void tbrHelp_Click (object sender, EventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", HelpNavigator.TableOfContents);
	}

	private void tbrGenerate_Click (object sender, EventArgs e)
	{
	}

	private void EditPopupMenu_Opening (object sender, CancelEventArgs e)
	{
		mnuEditPopupCopyImage.Enabled = mnuEditPopup.SourceControl is PictureBox;
	}
}
