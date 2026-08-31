// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;
using RSG.CFS;

[DesignerGenerated]
public class frmAnlWizard : Form
{
	private IContainer components;

	private short iButton;

	private short iPage;

	private AnalysisWizard AnlWiz;

	private string strDel;

	private string[] CombSet;

	private short intCombSet;

	private LoadCombination[,] Comb;

	private const string strNext = "&Next >";

	private const string strFinished = "&Finished";

	[field: AccessedThroughProperty ("pnlAnlWizard1")]
	internal virtual Panel pnlAnlWizard1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ToolStrip tbrAnalyses {
		[CompilerGenerated]
		get {
			return _tbrAnalyses;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			ToolStripItemClickedEventHandler value2 = tbrAnalyses_ItemClicked;
			EventHandler value3 = cmdNext_Click;
			ToolStrip toolStrip = _tbrAnalyses;
			if (toolStrip != null) {
				toolStrip.ItemClicked -= value2;
				toolStrip.DoubleClick -= value3;
			}
			_tbrAnalyses = value;
			toolStrip = _tbrAnalyses;
			if (toolStrip != null) {
				toolStrip.ItemClicked += value2;
				toolStrip.DoubleClick += value3;
			}
		}
	}

	[field: AccessedThroughProperty ("picAnl1")]
	internal virtual PictureBox picAnl1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tbrButton1")]
	internal virtual ToolStripButton tbrButton1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tbrButton2")]
	internal virtual ToolStripButton tbrButton2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInfo")]
	internal virtual Label lblInfo {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tbrButton3")]
	internal virtual ToolStripButton tbrButton3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("tbrButton4")]
	internal virtual ToolStripButton tbrButton4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button cmdBack {
		[CompilerGenerated]
		get {
			return _cmdBack;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdBack_Click;
			Button button = _cmdBack;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdBack = value;
			button = _cmdBack;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	internal virtual Button cmdNext {
		[CompilerGenerated]
		get {
			return _cmdNext;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = cmdNext_Click;
			Button button = _cmdNext;
			if (button != null) {
				button.Click -= value2;
			}
			_cmdNext = value;
			button = _cmdNext;
			if (button != null) {
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("cmdCancel")]
	internal virtual Button cmdCancel {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("pnlAnlWizard2")]
	internal virtual Panel pnlAnlWizard2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("picAnl2")]
	internal virtual PictureBox picAnl2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLm {
		[CompilerGenerated]
		get {
			return _cboLm;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLm;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLm = value;
			comboBox = _cboLm;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput11")]
	internal virtual Label lblInput11 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboStiffness {
		[CompilerGenerated]
		get {
			return _cboStiffness;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboStiffness;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboStiffness = value;
			comboBox = _cboStiffness;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput10")]
	internal virtual Label lblInput10 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInput9")]
	internal virtual Label lblInput9 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboBracedFlange {
		[CompilerGenerated]
		get {
			return _cboBracedFlange;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = list_SelectedIndexChanged;
			ComboBox comboBox = _cboBracedFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboBracedFlange = value;
			comboBox = _cboBracedFlange;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput8")]
	internal virtual Label lblInput8 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboMemberBracing {
		[CompilerGenerated]
		get {
			return _cboMemberBracing;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = list_SelectedIndexChanged;
			ComboBox comboBox = _cboMemberBracing;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboMemberBracing = value;
			comboBox = _cboMemberBracing;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput7")]
	internal virtual Label lblInput7 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboFastenedSupport {
		[CompilerGenerated]
		get {
			return _cboFastenedSupport;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = list_SelectedIndexChanged;
			ComboBox comboBox = _cboFastenedSupport;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboFastenedSupport = value;
			comboBox = _cboFastenedSupport;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput6")]
	internal virtual Label lblInput6 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboBearingLength {
		[CompilerGenerated]
		get {
			return _cboBearingLength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboBearingLength;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboBearingLength = value;
			comboBox = _cboBearingLength;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput5")]
	internal virtual Label lblInput5 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkFixed {
		[CompilerGenerated]
		get {
			return _chkFixed;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkFixed_Click;
			CheckBox checkBox = _chkFixed;
			if (checkBox != null) {
				checkBox.Click -= value2;
			}
			_chkFixed = value;
			checkBox = _chkFixed;
			if (checkBox != null) {
				checkBox.Click += value2;
			}
		}
	}

	internal virtual ComboBox cboLapLength {
		[CompilerGenerated]
		get {
			return _cboLapLength;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLapLength;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLapLength = value;
			comboBox = _cboLapLength;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	internal virtual TextBox txtSpans {
		[CompilerGenerated]
		get {
			return _txtSpans;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = txtSpans_GotFocus;
			KeyPressEventHandler value3 = txtSpans_KeyPress;
			EventHandler value4 = txtSpans_TextChanged;
			CancelEventHandler value5 = txtSpans_Validating;
			TextBox textBox = _txtSpans;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtSpans = value;
			textBox = _txtSpans;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	internal virtual ComboBox cboCantilever {
		[CompilerGenerated]
		get {
			return _cboCantilever;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboCantilever;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboCantilever = value;
			comboBox = _cboCantilever;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	internal virtual ComboBox cboSection {
		[CompilerGenerated]
		get {
			return _cboSection;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = list_SelectedIndexChanged;
			ComboBox comboBox = _cboSection;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged -= value2;
			}
			_cboSection = value;
			comboBox = _cboSection;
			if (comboBox != null) {
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput4")]
	internal virtual Label lblInput4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInput3")]
	internal virtual Label lblInput3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInput2")]
	internal virtual Label lblInput2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblInput1")]
	internal virtual Label lblInput1 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAnl2")]
	internal virtual Label lblAnl2 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("pnlAnlWizard3")]
	internal virtual Panel pnlAnlWizard3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLoadAngle {
		[CompilerGenerated]
		get {
			return _cboLoadAngle;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLoadAngle;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLoadAngle = value;
			comboBox = _cboLoadAngle;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput19")]
	internal virtual Label lblInput19 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboWindLoad {
		[CompilerGenerated]
		get {
			return _cboWindLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboWindLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboWindLoad = value;
			comboBox = _cboWindLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput18")]
	internal virtual Label lblInput18 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboSnowLoad {
		[CompilerGenerated]
		get {
			return _cboSnowLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboSnowLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboSnowLoad = value;
			comboBox = _cboSnowLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput17")]
	internal virtual Label lblInput17 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboRoofLoad {
		[CompilerGenerated]
		get {
			return _cboRoofLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboRoofLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboRoofLoad = value;
			comboBox = _cboRoofLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput16")]
	internal virtual Label lblInput16 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboProductLoad {
		[CompilerGenerated]
		get {
			return _cboProductLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboProductLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboProductLoad = value;
			comboBox = _cboProductLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput15")]
	internal virtual Label lblInput15 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboLiveLoad {
		[CompilerGenerated]
		get {
			return _cboLiveLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboLiveLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboLiveLoad = value;
			comboBox = _cboLiveLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput14")]
	internal virtual Label lblInput14 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox cboDeadLoad {
		[CompilerGenerated]
		get {
			return _cboDeadLoad;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboDeadLoad;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboDeadLoad = value;
			comboBox = _cboDeadLoad;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput13")]
	internal virtual Label lblInput13 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual CheckBox chkSelfWt {
		[CompilerGenerated]
		get {
			return _chkSelfWt;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = chkSelfWt_Click;
			CheckBox checkBox = _chkSelfWt;
			if (checkBox != null) {
				checkBox.Click -= value2;
			}
			_chkSelfWt = value;
			checkBox = _chkSelfWt;
			if (checkBox != null) {
				checkBox.Click += value2;
			}
		}
	}

	internal virtual ComboBox cboWidth {
		[CompilerGenerated]
		get {
			return _cboWidth;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			EventHandler value5 = ctrl_DropDown;
			EventHandler value6 = ctrl_SelectedIndexChanged;
			CancelEventHandler value7 = ctrl_Validating;
			ComboBox comboBox = _cboWidth;
			if (comboBox != null) {
				comboBox.GotFocus -= value2;
				comboBox.KeyPress -= value3;
				comboBox.TextChanged -= value4;
				comboBox.DropDown -= value5;
				comboBox.SelectedIndexChanged -= value6;
				comboBox.Validating -= value7;
			}
			_cboWidth = value;
			comboBox = _cboWidth;
			if (comboBox != null) {
				comboBox.GotFocus += value2;
				comboBox.KeyPress += value3;
				comboBox.TextChanged += value4;
				comboBox.DropDown += value5;
				comboBox.SelectedIndexChanged += value6;
				comboBox.Validating += value7;
			}
		}
	}

	[field: AccessedThroughProperty ("lblInput12")]
	internal virtual Label lblInput12 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblAnl3")]
	internal virtual Label lblAnl3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("picAnl3")]
	internal virtual PictureBox picAnl3 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("pnlAnlWizard4")]
	internal virtual Panel pnlAnlWizard4 {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("chkInflectionPoint")]
	internal virtual CheckBox chkInflectionPoint {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("lblComb")]
	internal virtual Label lblComb {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ListBox lstCombSet {
		[CompilerGenerated]
		get {
			return _lstCombSet;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = lstCombSet_SelectedIndexChanged;
			ListBox listBox = _lstCombSet;
			if (listBox != null) {
				listBox.SelectedIndexChanged -= value2;
			}
			_lstCombSet = value;
			listBox = _lstCombSet;
			if (listBox != null) {
				listBox.SelectedIndexChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty ("lblCombSet")]
	internal virtual Label lblCombSet {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty ("txtSpan")]
	internal virtual TextBox txtSpan {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual TextBox txtMomRed {
		[CompilerGenerated]
		get {
			return _txtMomRed;
		}
		[MethodImpl (MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set {
			EventHandler value2 = ctrl_GotFocus;
			KeyPressEventHandler value3 = ctrl_KeyPress;
			EventHandler value4 = ctrl_TextChanged;
			CancelEventHandler value5 = ctrl_Validating;
			TextBox textBox = _txtMomRed;
			if (textBox != null) {
				textBox.GotFocus -= value2;
				textBox.KeyPress -= value3;
				textBox.TextChanged -= value4;
				textBox.Validating -= value5;
			}
			_txtMomRed = value;
			textBox = _txtMomRed;
			if (textBox != null) {
				textBox.GotFocus += value2;
				textBox.KeyPress += value3;
				textBox.TextChanged += value4;
				textBox.Validating += value5;
			}
		}
	}

	[field: AccessedThroughProperty ("lstComb")]
	internal virtual CheckedListBox lstComb {
		get; [MethodImpl (MethodImplOptions.Synchronized)]
		set;
	}

	public frmAnlWizard ()
	{
		base.Load += frmAnlWizard_Load;
		base.KeyDown += frmAnlWizard_KeyDown;
		base.HelpButtonClicked += frmAnlWizard_HelpButtonClicked;
		base.FormClosing += frmAnlWizard_FormClosing;
		AnlWiz = new AnalysisWizard (20);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof(frmAnlWizard));
		this.pnlAnlWizard1 = new System.Windows.Forms.Panel ();
		this.lblInfo = new System.Windows.Forms.Label ();
		this.tbrAnalyses = new System.Windows.Forms.ToolStrip ();
		this.tbrButton1 = new System.Windows.Forms.ToolStripButton ();
		this.tbrButton2 = new System.Windows.Forms.ToolStripButton ();
		this.tbrButton3 = new System.Windows.Forms.ToolStripButton ();
		this.tbrButton4 = new System.Windows.Forms.ToolStripButton ();
		this.picAnl1 = new System.Windows.Forms.PictureBox ();
		this.cmdBack = new System.Windows.Forms.Button ();
		this.cmdNext = new System.Windows.Forms.Button ();
		this.cmdCancel = new System.Windows.Forms.Button ();
		this.pnlAnlWizard2 = new System.Windows.Forms.Panel ();
		this.txtMomRed = new System.Windows.Forms.TextBox ();
		this.txtSpan = new System.Windows.Forms.TextBox ();
		this.cboLm = new System.Windows.Forms.ComboBox ();
		this.lblInput11 = new System.Windows.Forms.Label ();
		this.cboStiffness = new System.Windows.Forms.ComboBox ();
		this.lblInput10 = new System.Windows.Forms.Label ();
		this.lblInput9 = new System.Windows.Forms.Label ();
		this.cboBracedFlange = new System.Windows.Forms.ComboBox ();
		this.lblInput8 = new System.Windows.Forms.Label ();
		this.cboMemberBracing = new System.Windows.Forms.ComboBox ();
		this.lblInput7 = new System.Windows.Forms.Label ();
		this.cboFastenedSupport = new System.Windows.Forms.ComboBox ();
		this.lblInput6 = new System.Windows.Forms.Label ();
		this.cboBearingLength = new System.Windows.Forms.ComboBox ();
		this.lblInput5 = new System.Windows.Forms.Label ();
		this.chkFixed = new System.Windows.Forms.CheckBox ();
		this.cboLapLength = new System.Windows.Forms.ComboBox ();
		this.txtSpans = new System.Windows.Forms.TextBox ();
		this.cboCantilever = new System.Windows.Forms.ComboBox ();
		this.cboSection = new System.Windows.Forms.ComboBox ();
		this.lblInput4 = new System.Windows.Forms.Label ();
		this.lblInput3 = new System.Windows.Forms.Label ();
		this.lblInput2 = new System.Windows.Forms.Label ();
		this.lblInput1 = new System.Windows.Forms.Label ();
		this.lblAnl2 = new System.Windows.Forms.Label ();
		this.picAnl2 = new System.Windows.Forms.PictureBox ();
		this.pnlAnlWizard3 = new System.Windows.Forms.Panel ();
		this.cboLoadAngle = new System.Windows.Forms.ComboBox ();
		this.lblInput19 = new System.Windows.Forms.Label ();
		this.cboWindLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput18 = new System.Windows.Forms.Label ();
		this.cboSnowLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput17 = new System.Windows.Forms.Label ();
		this.cboRoofLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput16 = new System.Windows.Forms.Label ();
		this.cboProductLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput15 = new System.Windows.Forms.Label ();
		this.cboLiveLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput14 = new System.Windows.Forms.Label ();
		this.cboDeadLoad = new System.Windows.Forms.ComboBox ();
		this.lblInput13 = new System.Windows.Forms.Label ();
		this.chkSelfWt = new System.Windows.Forms.CheckBox ();
		this.cboWidth = new System.Windows.Forms.ComboBox ();
		this.lblInput12 = new System.Windows.Forms.Label ();
		this.lblAnl3 = new System.Windows.Forms.Label ();
		this.picAnl3 = new System.Windows.Forms.PictureBox ();
		this.pnlAnlWizard4 = new System.Windows.Forms.Panel ();
		this.lstComb = new System.Windows.Forms.CheckedListBox ();
		this.chkInflectionPoint = new System.Windows.Forms.CheckBox ();
		this.lblComb = new System.Windows.Forms.Label ();
		this.lstCombSet = new System.Windows.Forms.ListBox ();
		this.lblCombSet = new System.Windows.Forms.Label ();
		this.pnlAnlWizard1.SuspendLayout ();
		this.tbrAnalyses.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)this.picAnl1).BeginInit ();
		this.pnlAnlWizard2.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)this.picAnl2).BeginInit ();
		this.pnlAnlWizard3.SuspendLayout ();
		((System.ComponentModel.ISupportInitialize)this.picAnl3).BeginInit ();
		this.pnlAnlWizard4.SuspendLayout ();
		base.SuspendLayout ();
		this.pnlAnlWizard1.Controls.Add (this.lblInfo);
		this.pnlAnlWizard1.Controls.Add (this.tbrAnalyses);
		this.pnlAnlWizard1.Controls.Add (this.picAnl1);
		this.pnlAnlWizard1.Location = new System.Drawing.Point (0, 0);
		this.pnlAnlWizard1.Name = "pnlAnlWizard1";
		this.pnlAnlWizard1.Size = new System.Drawing.Size (429, 220);
		this.pnlAnlWizard1.TabIndex = 0;
		this.lblInfo.Location = new System.Drawing.Point (289, 10);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size (126, 160);
		this.lblInfo.TabIndex = 2;
		this.lblInfo.Text = "Select the type of analysis you want to create.  If the geometry isn't represented, you may define your own geometry by choosing Custom Analysis.";
		this.tbrAnalyses.AutoSize = false;
		this.tbrAnalyses.BackColor = System.Drawing.SystemColors.Control;
		this.tbrAnalyses.Dock = System.Windows.Forms.DockStyle.None;
		this.tbrAnalyses.Items.AddRange (new System.Windows.Forms.ToolStripItem[4] { this.tbrButton1, this.tbrButton2, this.tbrButton3, this.tbrButton4 });
		this.tbrAnalyses.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
		this.tbrAnalyses.Location = new System.Drawing.Point (140, 10);
		this.tbrAnalyses.Name = "tbrAnalyses";
		this.tbrAnalyses.Padding = new System.Windows.Forms.Padding (0);
		this.tbrAnalyses.Size = new System.Drawing.Size (145, 179);
		this.tbrAnalyses.TabIndex = 1;
		this.tbrAnalyses.TabStop = true;
		this.tbrButton1.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.tbrButton1.Checked = true;
		this.tbrButton1.CheckState = System.Windows.Forms.CheckState.Checked;
		this.tbrButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrButton1.Image = (System.Drawing.Image)resources.GetObject ("tbrButton1.Image");
		this.tbrButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.tbrButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrButton1.Margin = new System.Windows.Forms.Padding (1);
		this.tbrButton1.Name = "tbrButton1";
		this.tbrButton1.Padding = new System.Windows.Forms.Padding (1);
		this.tbrButton1.Size = new System.Drawing.Size (134, 38);
		this.tbrButton1.ToolTipText = "Beam-Column";
		this.tbrButton2.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.tbrButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrButton2.Image = (System.Drawing.Image)resources.GetObject ("tbrButton2.Image");
		this.tbrButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.tbrButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrButton2.Margin = new System.Windows.Forms.Padding (1);
		this.tbrButton2.Name = "tbrButton2";
		this.tbrButton2.Padding = new System.Windows.Forms.Padding (1);
		this.tbrButton2.Size = new System.Drawing.Size (134, 38);
		this.tbrButton2.ToolTipText = "Continuous Beam";
		this.tbrButton3.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.tbrButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrButton3.Image = (System.Drawing.Image)resources.GetObject ("tbrButton3.Image");
		this.tbrButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.tbrButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrButton3.Margin = new System.Windows.Forms.Padding (1);
		this.tbrButton3.Name = "tbrButton3";
		this.tbrButton3.Padding = new System.Windows.Forms.Padding (1);
		this.tbrButton3.Size = new System.Drawing.Size (134, 38);
		this.tbrButton3.ToolTipText = "Multi-Span Beam with Laps";
		this.tbrButton4.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.tbrButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.tbrButton4.Image = (System.Drawing.Image)resources.GetObject ("tbrButton4.Image");
		this.tbrButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.tbrButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.tbrButton4.Margin = new System.Windows.Forms.Padding (1);
		this.tbrButton4.Name = "tbrButton4";
		this.tbrButton4.Padding = new System.Windows.Forms.Padding (1);
		this.tbrButton4.Size = new System.Drawing.Size (134, 38);
		this.tbrButton4.ToolTipText = "Custom Analysis";
		this.picAnl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picAnl1.Image = (System.Drawing.Image)resources.GetObject ("picAnl1.Image");
		this.picAnl1.Location = new System.Drawing.Point (10, 10);
		this.picAnl1.Name = "picAnl1";
		this.picAnl1.Size = new System.Drawing.Size (120, 160);
		this.picAnl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picAnl1.TabIndex = 0;
		this.picAnl1.TabStop = false;
		this.cmdBack.Enabled = false;
		this.cmdBack.Location = new System.Drawing.Point (141, 224);
		this.cmdBack.Name = "cmdBack";
		this.cmdBack.Size = new System.Drawing.Size (75, 25);
		this.cmdBack.TabIndex = 50;
		this.cmdBack.Text = "< &Back";
		this.cmdBack.UseVisualStyleBackColor = true;
		this.cmdNext.Location = new System.Drawing.Point (222, 224);
		this.cmdNext.Name = "cmdNext";
		this.cmdNext.Size = new System.Drawing.Size (75, 25);
		this.cmdNext.TabIndex = 51;
		this.cmdNext.Text = "&Next >";
		this.cmdNext.UseVisualStyleBackColor = true;
		this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.cmdCancel.Location = new System.Drawing.Point (340, 224);
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.Size = new System.Drawing.Size (75, 25);
		this.cmdCancel.TabIndex = 52;
		this.cmdCancel.Text = "Cancel";
		this.cmdCancel.UseVisualStyleBackColor = true;
		this.pnlAnlWizard2.Controls.Add (this.txtMomRed);
		this.pnlAnlWizard2.Controls.Add (this.txtSpan);
		this.pnlAnlWizard2.Controls.Add (this.cboLm);
		this.pnlAnlWizard2.Controls.Add (this.lblInput11);
		this.pnlAnlWizard2.Controls.Add (this.cboStiffness);
		this.pnlAnlWizard2.Controls.Add (this.lblInput10);
		this.pnlAnlWizard2.Controls.Add (this.lblInput9);
		this.pnlAnlWizard2.Controls.Add (this.cboBracedFlange);
		this.pnlAnlWizard2.Controls.Add (this.lblInput8);
		this.pnlAnlWizard2.Controls.Add (this.cboMemberBracing);
		this.pnlAnlWizard2.Controls.Add (this.lblInput7);
		this.pnlAnlWizard2.Controls.Add (this.cboFastenedSupport);
		this.pnlAnlWizard2.Controls.Add (this.lblInput6);
		this.pnlAnlWizard2.Controls.Add (this.cboBearingLength);
		this.pnlAnlWizard2.Controls.Add (this.lblInput5);
		this.pnlAnlWizard2.Controls.Add (this.chkFixed);
		this.pnlAnlWizard2.Controls.Add (this.cboLapLength);
		this.pnlAnlWizard2.Controls.Add (this.txtSpans);
		this.pnlAnlWizard2.Controls.Add (this.cboCantilever);
		this.pnlAnlWizard2.Controls.Add (this.cboSection);
		this.pnlAnlWizard2.Controls.Add (this.lblInput4);
		this.pnlAnlWizard2.Controls.Add (this.lblInput3);
		this.pnlAnlWizard2.Controls.Add (this.lblInput2);
		this.pnlAnlWizard2.Controls.Add (this.lblInput1);
		this.pnlAnlWizard2.Controls.Add (this.lblAnl2);
		this.pnlAnlWizard2.Controls.Add (this.picAnl2);
		this.pnlAnlWizard2.Location = new System.Drawing.Point (0, 0);
		this.pnlAnlWizard2.Name = "pnlAnlWizard2";
		this.pnlAnlWizard2.Size = new System.Drawing.Size (429, 220);
		this.pnlAnlWizard2.TabIndex = 5;
		this.pnlAnlWizard2.Visible = false;
		this.txtMomRed.Location = new System.Drawing.Point (326, 148);
		this.txtMomRed.Name = "txtMomRed";
		this.txtMomRed.Size = new System.Drawing.Size (100, 20);
		this.txtMomRed.TabIndex = 22;
		this.txtSpan.Location = new System.Drawing.Point (15, 101);
		this.txtSpan.Name = "txtSpan";
		this.txtSpan.Size = new System.Drawing.Size (66, 20);
		this.txtSpan.TabIndex = 53;
		this.txtSpan.Visible = false;
		this.cboLm.FormattingEnabled = true;
		this.cboLm.Location = new System.Drawing.Point (326, 195);
		this.cboLm.Name = "cboLm";
		this.cboLm.Size = new System.Drawing.Size (100, 21);
		this.cboLm.TabIndex = 26;
		this.lblInput11.Location = new System.Drawing.Point (228, 198);
		this.lblInput11.Name = "lblInput11";
		this.lblInput11.Size = new System.Drawing.Size (100, 15);
		this.lblInput11.TabIndex = 25;
		this.lblInput11.Text = "Length Lm";
		this.cboStiffness.FormattingEnabled = true;
		this.cboStiffness.Location = new System.Drawing.Point (326, 171);
		this.cboStiffness.Name = "cboStiffness";
		this.cboStiffness.Size = new System.Drawing.Size (100, 21);
		this.cboStiffness.TabIndex = 24;
		this.lblInput10.Location = new System.Drawing.Point (228, 174);
		this.lblInput10.Name = "lblInput10";
		this.lblInput10.Size = new System.Drawing.Size (100, 15);
		this.lblInput10.TabIndex = 23;
		this.lblInput10.Text = "Stiffness, kϕ";
		this.lblInput9.Location = new System.Drawing.Point (228, 150);
		this.lblInput9.Name = "lblInput9";
		this.lblInput9.Size = new System.Drawing.Size (100, 15);
		this.lblInput9.TabIndex = 21;
		this.lblInput9.Text = "Red. Factor, R";
		this.cboBracedFlange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBracedFlange.FormattingEnabled = true;
		this.cboBracedFlange.Location = new System.Drawing.Point (326, 124);
		this.cboBracedFlange.Name = "cboBracedFlange";
		this.cboBracedFlange.Size = new System.Drawing.Size (100, 21);
		this.cboBracedFlange.TabIndex = 20;
		this.lblInput8.Location = new System.Drawing.Point (228, 127);
		this.lblInput8.Name = "lblInput8";
		this.lblInput8.Size = new System.Drawing.Size (100, 15);
		this.lblInput8.TabIndex = 19;
		this.lblInput8.Text = "Braced Flange";
		this.cboMemberBracing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboMemberBracing.FormattingEnabled = true;
		this.cboMemberBracing.Location = new System.Drawing.Point (326, 100);
		this.cboMemberBracing.Name = "cboMemberBracing";
		this.cboMemberBracing.Size = new System.Drawing.Size (100, 21);
		this.cboMemberBracing.TabIndex = 18;
		this.lblInput7.Location = new System.Drawing.Point (228, 103);
		this.lblInput7.Name = "lblInput7";
		this.lblInput7.Size = new System.Drawing.Size (100, 15);
		this.lblInput7.TabIndex = 17;
		this.lblInput7.Text = "Member Bracing";
		this.cboFastenedSupport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFastenedSupport.FormattingEnabled = true;
		this.cboFastenedSupport.Location = new System.Drawing.Point (326, 76);
		this.cboFastenedSupport.Name = "cboFastenedSupport";
		this.cboFastenedSupport.Size = new System.Drawing.Size (100, 21);
		this.cboFastenedSupport.TabIndex = 16;
		this.lblInput6.Location = new System.Drawing.Point (228, 79);
		this.lblInput6.Name = "lblInput6";
		this.lblInput6.Size = new System.Drawing.Size (100, 15);
		this.lblInput6.TabIndex = 15;
		this.lblInput6.Text = "Fastened Support";
		this.cboBearingLength.FormattingEnabled = true;
		this.cboBearingLength.Location = new System.Drawing.Point (326, 52);
		this.cboBearingLength.Name = "cboBearingLength";
		this.cboBearingLength.Size = new System.Drawing.Size (100, 21);
		this.cboBearingLength.TabIndex = 14;
		this.lblInput5.Location = new System.Drawing.Point (228, 55);
		this.lblInput5.Name = "lblInput5";
		this.lblInput5.Size = new System.Drawing.Size (100, 15);
		this.lblInput5.TabIndex = 13;
		this.lblInput5.Text = "Bearing Length";
		this.chkFixed.Location = new System.Drawing.Point (90, 171);
		this.chkFixed.Name = "chkFixed";
		this.chkFixed.Size = new System.Drawing.Size (126, 25);
		this.chkFixed.TabIndex = 12;
		this.chkFixed.Text = "Fixed End Supports";
		this.chkFixed.UseVisualStyleBackColor = true;
		this.cboLapLength.FormattingEnabled = true;
		this.cboLapLength.Location = new System.Drawing.Point (110, 147);
		this.cboLapLength.Name = "cboLapLength";
		this.cboLapLength.Size = new System.Drawing.Size (100, 21);
		this.cboLapLength.TabIndex = 11;
		this.txtSpans.Location = new System.Drawing.Point (110, 76);
		this.txtSpans.Multiline = true;
		this.txtSpans.Name = "txtSpans";
		this.txtSpans.Size = new System.Drawing.Size (100, 45);
		this.txtSpans.TabIndex = 7;
		this.cboCantilever.FormattingEnabled = true;
		this.cboCantilever.Location = new System.Drawing.Point (110, 124);
		this.cboCantilever.Name = "cboCantilever";
		this.cboCantilever.Size = new System.Drawing.Size (100, 21);
		this.cboCantilever.TabIndex = 9;
		this.cboSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSection.FormattingEnabled = true;
		this.cboSection.Location = new System.Drawing.Point (110, 52);
		this.cboSection.Name = "cboSection";
		this.cboSection.Size = new System.Drawing.Size (100, 21);
		this.cboSection.TabIndex = 5;
		this.lblInput4.Location = new System.Drawing.Point (12, 150);
		this.lblInput4.Name = "lblInput4";
		this.lblInput4.Size = new System.Drawing.Size (100, 15);
		this.lblInput4.TabIndex = 10;
		this.lblInput4.Text = "Lap Length";
		this.lblInput3.Location = new System.Drawing.Point (12, 127);
		this.lblInput3.Name = "lblInput3";
		this.lblInput3.Size = new System.Drawing.Size (100, 15);
		this.lblInput3.TabIndex = 8;
		this.lblInput3.Text = "Cantilever Length";
		this.lblInput2.Location = new System.Drawing.Point (12, 79);
		this.lblInput2.Name = "lblInput2";
		this.lblInput2.Size = new System.Drawing.Size (100, 15);
		this.lblInput2.TabIndex = 6;
		this.lblInput2.Text = "Span Lengths";
		this.lblInput1.Location = new System.Drawing.Point (12, 55);
		this.lblInput1.Name = "lblInput1";
		this.lblInput1.Size = new System.Drawing.Size (100, 15);
		this.lblInput1.TabIndex = 4;
		this.lblInput1.Text = "Section";
		this.lblAnl2.Location = new System.Drawing.Point (152, 10);
		this.lblAnl2.Name = "lblAnl2";
		this.lblAnl2.Size = new System.Drawing.Size (270, 36);
		this.lblAnl2.TabIndex = 3;
		this.lblAnl2.Text = "lblAnl2";
		this.picAnl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picAnl2.Location = new System.Drawing.Point (10, 10);
		this.picAnl2.Name = "picAnl2";
		this.picAnl2.Size = new System.Drawing.Size (132, 36);
		this.picAnl2.TabIndex = 0;
		this.picAnl2.TabStop = false;
		this.pnlAnlWizard3.Controls.Add (this.cboLoadAngle);
		this.pnlAnlWizard3.Controls.Add (this.lblInput19);
		this.pnlAnlWizard3.Controls.Add (this.cboWindLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput18);
		this.pnlAnlWizard3.Controls.Add (this.cboSnowLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput17);
		this.pnlAnlWizard3.Controls.Add (this.cboRoofLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput16);
		this.pnlAnlWizard3.Controls.Add (this.cboProductLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput15);
		this.pnlAnlWizard3.Controls.Add (this.cboLiveLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput14);
		this.pnlAnlWizard3.Controls.Add (this.cboDeadLoad);
		this.pnlAnlWizard3.Controls.Add (this.lblInput13);
		this.pnlAnlWizard3.Controls.Add (this.chkSelfWt);
		this.pnlAnlWizard3.Controls.Add (this.cboWidth);
		this.pnlAnlWizard3.Controls.Add (this.lblInput12);
		this.pnlAnlWizard3.Controls.Add (this.lblAnl3);
		this.pnlAnlWizard3.Controls.Add (this.picAnl3);
		this.pnlAnlWizard3.Location = new System.Drawing.Point (0, 0);
		this.pnlAnlWizard3.Name = "pnlAnlWizard3";
		this.pnlAnlWizard3.Size = new System.Drawing.Size (429, 220);
		this.pnlAnlWizard3.TabIndex = 6;
		this.pnlAnlWizard3.Visible = false;
		this.cboLoadAngle.FormattingEnabled = true;
		this.cboLoadAngle.Location = new System.Drawing.Point (326, 147);
		this.cboLoadAngle.Name = "cboLoadAngle";
		this.cboLoadAngle.Size = new System.Drawing.Size (100, 21);
		this.cboLoadAngle.TabIndex = 44;
		this.lblInput19.Location = new System.Drawing.Point (228, 150);
		this.lblInput19.Name = "lblInput19";
		this.lblInput19.Size = new System.Drawing.Size (100, 15);
		this.lblInput19.TabIndex = 43;
		this.lblInput19.Text = "Load Angle";
		this.cboWindLoad.FormattingEnabled = true;
		this.cboWindLoad.Location = new System.Drawing.Point (326, 124);
		this.cboWindLoad.Name = "cboWindLoad";
		this.cboWindLoad.Size = new System.Drawing.Size (100, 21);
		this.cboWindLoad.TabIndex = 42;
		this.lblInput18.Location = new System.Drawing.Point (228, 127);
		this.lblInput18.Name = "lblInput18";
		this.lblInput18.Size = new System.Drawing.Size (100, 15);
		this.lblInput18.TabIndex = 41;
		this.lblInput18.Text = "Wind Uplift";
		this.cboSnowLoad.FormattingEnabled = true;
		this.cboSnowLoad.Location = new System.Drawing.Point (326, 100);
		this.cboSnowLoad.Name = "cboSnowLoad";
		this.cboSnowLoad.Size = new System.Drawing.Size (100, 21);
		this.cboSnowLoad.TabIndex = 40;
		this.lblInput17.Location = new System.Drawing.Point (228, 103);
		this.lblInput17.Name = "lblInput17";
		this.lblInput17.Size = new System.Drawing.Size (100, 15);
		this.lblInput17.TabIndex = 39;
		this.lblInput17.Text = "Snow Load";
		this.cboRoofLoad.FormattingEnabled = true;
		this.cboRoofLoad.Location = new System.Drawing.Point (326, 76);
		this.cboRoofLoad.Name = "cboRoofLoad";
		this.cboRoofLoad.Size = new System.Drawing.Size (100, 21);
		this.cboRoofLoad.TabIndex = 38;
		this.lblInput16.Location = new System.Drawing.Point (228, 79);
		this.lblInput16.Name = "lblInput16";
		this.lblInput16.Size = new System.Drawing.Size (100, 15);
		this.lblInput16.TabIndex = 37;
		this.lblInput16.Text = "Roof Live Load";
		this.cboProductLoad.FormattingEnabled = true;
		this.cboProductLoad.Location = new System.Drawing.Point (110, 147);
		this.cboProductLoad.Name = "cboProductLoad";
		this.cboProductLoad.Size = new System.Drawing.Size (100, 21);
		this.cboProductLoad.TabIndex = 36;
		this.lblInput15.Location = new System.Drawing.Point (12, 150);
		this.lblInput15.Name = "lblInput15";
		this.lblInput15.Size = new System.Drawing.Size (100, 15);
		this.lblInput15.TabIndex = 35;
		this.lblInput15.Text = "Product Load";
		this.cboLiveLoad.FormattingEnabled = true;
		this.cboLiveLoad.Location = new System.Drawing.Point (110, 124);
		this.cboLiveLoad.Name = "cboLiveLoad";
		this.cboLiveLoad.Size = new System.Drawing.Size (100, 21);
		this.cboLiveLoad.TabIndex = 34;
		this.lblInput14.Location = new System.Drawing.Point (12, 127);
		this.lblInput14.Name = "lblInput14";
		this.lblInput14.Size = new System.Drawing.Size (100, 15);
		this.lblInput14.TabIndex = 33;
		this.lblInput14.Text = "Live Load";
		this.cboDeadLoad.FormattingEnabled = true;
		this.cboDeadLoad.Location = new System.Drawing.Point (110, 100);
		this.cboDeadLoad.Name = "cboDeadLoad";
		this.cboDeadLoad.Size = new System.Drawing.Size (100, 21);
		this.cboDeadLoad.TabIndex = 32;
		this.lblInput13.Location = new System.Drawing.Point (12, 103);
		this.lblInput13.Name = "lblInput13";
		this.lblInput13.Size = new System.Drawing.Size (100, 15);
		this.lblInput13.TabIndex = 31;
		this.lblInput13.Text = "Dead Load";
		this.chkSelfWt.Location = new System.Drawing.Point (15, 74);
		this.chkSelfWt.Name = "chkSelfWt";
		this.chkSelfWt.Size = new System.Drawing.Size (194, 25);
		this.chkSelfWt.TabIndex = 30;
		this.chkSelfWt.Text = "Include beam self-weight";
		this.chkSelfWt.UseVisualStyleBackColor = true;
		this.cboWidth.FormattingEnabled = true;
		this.cboWidth.Location = new System.Drawing.Point (110, 52);
		this.cboWidth.Name = "cboWidth";
		this.cboWidth.Size = new System.Drawing.Size (100, 21);
		this.cboWidth.TabIndex = 29;
		this.lblInput12.Location = new System.Drawing.Point (12, 55);
		this.lblInput12.Name = "lblInput12";
		this.lblInput12.Size = new System.Drawing.Size (100, 15);
		this.lblInput12.TabIndex = 28;
		this.lblInput12.Text = "Tributary Width";
		this.lblAnl3.Location = new System.Drawing.Point (152, 10);
		this.lblAnl3.Name = "lblAnl3";
		this.lblAnl3.Size = new System.Drawing.Size (270, 36);
		this.lblAnl3.TabIndex = 27;
		this.lblAnl3.Text = "lblAnl3";
		this.picAnl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.picAnl3.Location = new System.Drawing.Point (10, 10);
		this.picAnl3.Name = "picAnl3";
		this.picAnl3.Size = new System.Drawing.Size (132, 36);
		this.picAnl3.TabIndex = 0;
		this.picAnl3.TabStop = false;
		this.pnlAnlWizard4.Controls.Add (this.lstComb);
		this.pnlAnlWizard4.Controls.Add (this.chkInflectionPoint);
		this.pnlAnlWizard4.Controls.Add (this.lblComb);
		this.pnlAnlWizard4.Controls.Add (this.lstCombSet);
		this.pnlAnlWizard4.Controls.Add (this.lblCombSet);
		this.pnlAnlWizard4.Location = new System.Drawing.Point (0, 0);
		this.pnlAnlWizard4.Name = "pnlAnlWizard4";
		this.pnlAnlWizard4.Size = new System.Drawing.Size (429, 220);
		this.pnlAnlWizard4.TabIndex = 7;
		this.pnlAnlWizard4.Visible = false;
		this.lstComb.CheckOnClick = true;
		this.lstComb.FormattingEnabled = true;
		this.lstComb.Location = new System.Drawing.Point (231, 31);
		this.lstComb.Name = "lstComb";
		this.lstComb.Size = new System.Drawing.Size (195, 184);
		this.lstComb.TabIndex = 50;
		this.chkInflectionPoint.Location = new System.Drawing.Point (15, 195);
		this.chkInflectionPoint.Name = "chkInflectionPoint";
		this.chkInflectionPoint.Size = new System.Drawing.Size (194, 21);
		this.chkInflectionPoint.TabIndex = 49;
		this.chkInflectionPoint.Text = "Use Inflection Point Bracing";
		this.chkInflectionPoint.UseVisualStyleBackColor = true;
		this.lblComb.Location = new System.Drawing.Point (231, 10);
		this.lblComb.Name = "lblComb";
		this.lblComb.Size = new System.Drawing.Size (195, 18);
		this.lblComb.TabIndex = 47;
		this.lblComb.Text = "Combinations to Include";
		this.lstCombSet.FormattingEnabled = true;
		this.lstCombSet.Location = new System.Drawing.Point (15, 31);
		this.lstCombSet.Name = "lstCombSet";
		this.lstCombSet.Size = new System.Drawing.Size (195, 160);
		this.lstCombSet.TabIndex = 46;
		this.lblCombSet.Location = new System.Drawing.Point (15, 10);
		this.lblCombSet.Name = "lblCombSet";
		this.lblCombSet.Size = new System.Drawing.Size (115, 18);
		this.lblCombSet.TabIndex = 45;
		this.lblCombSet.Text = "Load Combinations";
		base.AutoScaleDimensions = new System.Drawing.SizeF (6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.cmdCancel;
		base.ClientSize = new System.Drawing.Size (435, 255);
		base.Controls.Add (this.cmdCancel);
		base.Controls.Add (this.cmdNext);
		base.Controls.Add (this.cmdBack);
		base.Controls.Add (this.pnlAnlWizard1);
		base.Controls.Add (this.pnlAnlWizard2);
		base.Controls.Add (this.pnlAnlWizard3);
		base.Controls.Add (this.pnlAnlWizard4);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.HelpButton = true;
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAnlWizard";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Analysis Wizard (1 of 4)";
		this.pnlAnlWizard1.ResumeLayout (false);
		this.tbrAnalyses.ResumeLayout (false);
		this.tbrAnalyses.PerformLayout ();
		((System.ComponentModel.ISupportInitialize)this.picAnl1).EndInit ();
		this.pnlAnlWizard2.ResumeLayout (false);
		this.pnlAnlWizard2.PerformLayout ();
		((System.ComponentModel.ISupportInitialize)this.picAnl2).EndInit ();
		this.pnlAnlWizard3.ResumeLayout (false);
		((System.ComponentModel.ISupportInitialize)this.picAnl3).EndInit ();
		this.pnlAnlWizard4.ResumeLayout (false);
		base.ResumeLayout (false);
	}

	private void frmAnlWizard_Load (object sender, EventArgs e)
	{
		iPage = 1;
		iButton = AnlWiz.AnlType;
		if (iButton == 0) {
			iButton = 1;
		}
		checked {
			picAnl2.Image = tbrAnalyses.Items [iButton - 1].Image;
			lblAnl2.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
			picAnl3.Image = tbrAnalyses.Items [iButton - 1].Image;
			lblAnl3.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
			lblInfo.Text = "Select the type of analysis you want to create.\n\nIf the analysis you want isn't represented, you may define your own by choosing \"Custom Analysis\".";
			cmdNext.Text = "&Next >";
			txtSpans.Tag = new ControlData (2, 12f, 2400f);
			txtSpan.Tag = new ControlData (2, 12f, 2400f);
			cboCantilever.Tag = new ControlData (2, 0f, 240f);
			cboLapLength.Tag = new ControlData (2, 0f, 120f);
			cboBearingLength.Tag = new ControlData (1, 0.75f, 12f);
			txtMomRed.Tag = new ControlData (0, 0f, 1f);
			cboWidth.Tag = new ControlData (2, 0f, 1200f);
			cboDeadLoad.Tag = new ControlData (4, 0f, 100f);
			cboLiveLoad.Tag = new ControlData (4, 0f, 100f);
			cboRoofLoad.Tag = new ControlData (4, 0f, 100f);
			cboSnowLoad.Tag = new ControlData (4, 0f, 100f);
			cboWindLoad.Tag = new ControlData (5, 0f, 0.00208333344f);
			cboLoadAngle.Tag = new ControlData (3, -(float)Math.PI, (float)Math.PI * 2f);
			cboProductLoad.Tag = new ControlData (4, 0f, 100f);
			cboStiffness.Tag = new ControlData (4, 0f, 1000f);
			cboLm.Tag = new ControlData (2, 0f, 1200f);
			cboSection.Items.Clear ();
			int num = Information.UBound (CFS.hdgSctPic);
			for (int i = 1; i <= num; i++) {
				if (!CFS.hdgSctPic [i].Deleted) {
					cboSection.Items.Add (new ListItem (CFSInterface.GetFileNameWithoutExtension (CFS.Sections [i].Filename), i));
				}
			}
			cboFastenedSupport.Items.Clear ();
			cboFastenedSupport.Items.Add ("Yes");
			cboFastenedSupport.Items.Add ("No");
			AnlWiz.Fastened = CFSInterface.WebCripParametersNow.Fastened;
			cboMemberBracing.Items.Clear ();
			cboMemberBracing.Items.Add ("None");
			cboMemberBracing.Items.Add ("Mid-Point");
			cboMemberBracing.Items.Add ("Third-Points");
			cboMemberBracing.Items.Add ("Quarter-Points");
			cboMemberBracing.Items.Add ("Fully Braced");
			cboBracedFlange.Items.Clear ();
			cboBracedFlange.Items.Add ("None");
			cboBracedFlange.Items.Add ("Bottom Flange");
			cboBracedFlange.Items.Add ("Top Flange");
			cboBracedFlange.Items.Add ("Left Flange");
			cboBracedFlange.Items.Add ("Right Flange");
			strDel = Conversions.ToString (Interaction.IIf (Operators.CompareString (Strings.Mid (Strings.Format (0.5, "0.0"), 2, 1), ".", TextCompare: false) == 0, ",", ";"));
		}
	}

	private void frmAnlWizard_KeyDown (object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.F1) {
			Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "analysis-wizard-" + Conversions.ToString ((int)iPage) + ".htm");
			e.Handled = true;
		}
	}

	private void frmAnlWizard_HelpButtonClicked (object sender, CancelEventArgs e)
	{
		Help.ShowHelp (this, CFS.strAppPath + "CFS.chm", "analysis-wizard-" + Conversions.ToString ((int)iPage) + ".htm");
		e.Cancel = true;
	}

	private void frmAnlWizard_FormClosing (object sender, FormClosingEventArgs e)
	{
		CombSet = null;
		Comb = null;
	}

	private void tbrAnalyses_ItemClicked (object sender, ToolStripItemClickedEventArgs e)
	{
		checked {
			ToolStripButton toolStripButton = (ToolStripButton)tbrAnalyses.Items [iButton - 1];
			toolStripButton.Checked = false;
			toolStripButton = (ToolStripButton)e.ClickedItem;
			toolStripButton.Checked = true;
			iButton = (short)(tbrAnalyses.Items.IndexOf (toolStripButton) + 1);
			picAnl2.Image = toolStripButton.Image;
			lblAnl2.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
			picAnl3.Image = toolStripButton.Image;
			lblAnl3.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
		}
	}

	private void cmdBack_Click (object sender, EventArgs e)
	{
		pnlAnlWizard1.Visible = false;
		pnlAnlWizard2.Visible = false;
		pnlAnlWizard3.Visible = false;
		pnlAnlWizard4.Visible = false;
		if ((iPage == 2) | ((iPage == 4) & (iButton == 4))) {
			iPage = 1;
			Text = "Analysis Wizard (1 of 4)";
			pnlAnlWizard1.Visible = true;
			cmdBack.Enabled = false;
			cmdNext.Text = "&Next >";
			tbrAnalyses.Select ();
			base.AcceptButton = cmdNext;
		} else if (iPage == 3) {
			iPage = 2;
			Text = "Analysis Wizard (2 of 4)";
			pnlAnlWizard2.Visible = true;
			cmdNext.Text = "&Next >";
			cboSection.Select ();
			base.AcceptButton = cmdNext;
		} else if (iPage == 4) {
			iPage = 3;
			Text = "Analysis Wizard (3 of 4)";
			pnlAnlWizard3.Visible = true;
			cmdNext.Text = "&Next >";
			cboWidth.Select ();
			base.AcceptButton = cmdNext;
		}
	}

	private void cmdNext_Click (object sender, EventArgs e)
	{
		Cursor.Current = Cursors.WaitCursor;
		if ((iPage == 1) & (iButton == 4)) {
			iPage = 3;
			cmdBack.Enabled = true;
			AnlWiz.SelfWt = true;
			AnlWiz.Dead = 1f;
			AnlWiz.Live = 1f;
			AnlWiz.Prod = 0f;
			AnlWiz.Roof = 1f;
			AnlWiz.Snow = 1f;
			AnlWiz.Wind = 1f;
		}
		pnlAnlWizard1.Visible = false;
		pnlAnlWizard2.Visible = false;
		pnlAnlWizard3.Visible = false;
		pnlAnlWizard4.Visible = false;
		checked {
			if (iPage == 1) {
				iPage = 2;
				Text = "Analysis Wizard (2 of 4)";
				pnlAnlWizard2.Visible = true;
				cmdBack.Enabled = true;
				ref AnalysisWizard anlWiz = ref AnlWiz;
				lblInput3.Enabled = true;
				cboCantilever.Enabled = true;
				lblInput4.Enabled = true;
				cboLapLength.Enabled = true;
				anlWiz.iSct = Conversions.ToByte (NewLateBinding.LateGet (cboSection.Items [0], null, "ItemData", new object[0], null, null, null));
				anlWiz.Wid = 2f;
				anlWiz.iMemBrace = 0;
				anlWiz.iBrcFlg = 0;
				anlWiz.R = 0f;
				anlWiz.Kf = 0f;
				anlWiz.Lm = 240f;
				anlWiz.Fixed = false;
				anlWiz.AnlType = (byte)iButton;
				Array.Clear (anlWiz.SpanLen, 0, anlWiz.SpanLen.Count ());
				switch (iButton) {
				case 1:
					anlWiz.nSpan = 1;
					anlWiz.CantLen = 0f;
					anlWiz.LapLen = 0f;
					anlWiz.SpanLen [1] = 120f;
					lblInput3.Enabled = false;
					cboCantilever.Enabled = false;
					lblInput4.Enabled = false;
					cboLapLength.Enabled = false;
					break;
				case 2:
					anlWiz.nSpan = 3;
					anlWiz.CantLen = 0f;
					anlWiz.LapLen = 0f;
					anlWiz.SpanLen [1] = 240f;
					anlWiz.SpanLen [2] = 240f;
					anlWiz.SpanLen [3] = 240f;
					lblInput4.Enabled = false;
					cboLapLength.Enabled = false;
					break;
				case 3:
					anlWiz.nSpan = 3;
					anlWiz.CantLen = 0f;
					anlWiz.LapLen = 12f;
					anlWiz.SpanLen [1] = 240f;
					anlWiz.SpanLen [2] = 240f;
					anlWiz.SpanLen [3] = 240f;
					break;
				}
				if (AnlWiz.AnlType == CFSInterface.AnlWizSave.AnlType) {
					AnlWiz = CFSInterface.AnlWizSave;
				} else if ((AnlWiz.AnlType == 2) & (CFSInterface.AnlWizSave.AnlType == 3)) {
					CFSInterface.AnlWizSave.AnlType = AnlWiz.AnlType;
					CFSInterface.AnlWizSave.LapLen = AnlWiz.LapLen;
					AnlWiz = CFSInterface.AnlWizSave;
				} else if ((AnlWiz.AnlType == 3) & (CFSInterface.AnlWizSave.AnlType == 2)) {
					CFSInterface.AnlWizSave.AnlType = AnlWiz.AnlType;
					CFSInterface.AnlWizSave.LapLen = AnlWiz.LapLen;
					AnlWiz = CFSInterface.AnlWizSave;
				}
				CFS.blnValidate = false;
				cboSection.SelectedIndex = 0;
				lblInput2.Text = "Span Lengths (" + Units.untLength [Units.DefaultUnitIndex [2]].Name + ")";
				string text = string.Empty;
				short nSpan = anlWiz.nSpan;
				for (short num = 1; num <= nSpan; num = (short)unchecked(num + 1)) {
					text += Units.DisplayLength (anlWiz.SpanLen [num], Conversions.ToByte (NewLateBinding.LateGet (txtSpans.Tag, null, "Index", new object[0], null, null, null)), blnShowUnit: false, "", 0, 0);
					if (num < anlWiz.nSpan) {
						text = text + strDel + " ";
					}
				}
				txtSpans.Text = text;
				txtSpans.SelectAll ();
				cboFastenedSupport.SelectedIndex = Conversions.ToInteger (Interaction.IIf (anlWiz.Fastened, 0, 1));
				if (cboCantilever.Enabled) {
					CFSInterface.SetText (cboCantilever, anlWiz.CantLen);
				} else {
					cboCantilever.Text = string.Empty;
				}
				if (cboLapLength.Enabled) {
					CFSInterface.SetText (cboLapLength, anlWiz.LapLen);
				} else {
					cboLapLength.Text = string.Empty;
				}
				CFSInterface.SetText (cboBearingLength, anlWiz.Wid);
				cboMemberBracing.SelectedIndex = anlWiz.iMemBrace;
				cboBracedFlange.SelectedIndex = anlWiz.iBrcFlg;
				txtMomRed.Text = Units.DisplayNone (anlWiz.R, "", 0, 0);
				CFSInterface.SetText (cboStiffness, anlWiz.Kf);
				CFSInterface.SetText (cboLm, anlWiz.Lm);
				chkFixed.Checked = anlWiz.Fixed;
				CFS.blnValidate = true;
				picAnl2.Image = tbrAnalyses.Items [iButton - 1].Image;
				lblAnl2.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
				cboSection.Select ();
			} else if (iPage == 2) {
				short nSpan2 = AnlWiz.nSpan;
				for (short num2 = 1; num2 <= nSpan2; num2 = (short)unchecked(num2 + 1)) {
					if (AnlWiz.CantLen > AnlWiz.SpanLen [num2]) {
						pnlAnlWizard2.Visible = true;
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("Cantilever Length greater than Span Length.", MsgBoxStyle.Information);
						return;
					}
					if (AnlWiz.LapLen > AnlWiz.SpanLen [num2] / 2f) {
						pnlAnlWizard2.Visible = true;
						Cursor.Current = Cursors.Default;
						Interaction.MsgBox ("Lap Length exceeds 1/2 Span Length.", MsgBoxStyle.Information);
						return;
					}
				}
				iPage = 3;
				Text = "Analysis Wizard (3 of 4)";
				pnlAnlWizard3.Visible = true;
				byte b = unchecked((byte)((Units.DefaultUnitIndex [4] >= 3) ? 6 : 3));
				NewLateBinding.LateSetComplex (cboWindLoad.Tag, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
				ref AnalysisWizard anlWiz2 = ref AnlWiz;
				chkSelfWt.Enabled = true;
				CFS.blnValidate = false;
				if (iButton == 1) {
					object tag = cboDeadLoad.Tag;
					NewLateBinding.LateSetComplex (tag, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
					tag = null;
					object tag2 = cboLiveLoad.Tag;
					NewLateBinding.LateSetComplex (tag2, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag2, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag2, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
					tag2 = null;
					object tag3 = cboProductLoad.Tag;
					NewLateBinding.LateSetComplex (tag3, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag3, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag3, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
					tag3 = null;
					object tag4 = cboRoofLoad.Tag;
					NewLateBinding.LateSetComplex (tag4, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag4, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag4, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
					tag4 = null;
					object tag5 = cboSnowLoad.Tag;
					NewLateBinding.LateSetComplex (tag5, null, "UnitType", new object[1] { Units.UnitTypes.ForceUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag5, null, "Index", new object[1] { Units.DefaultUnitIndex [4] }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag5, null, "Max", new object[1] { 100 }, null, null, OptimisticSet: false, RValueBase: true);
					tag5 = null;
					if (AnlWiz.AnlType != CFSInterface.AnlWizSave.AnlType) {
						anlWiz2.TribWid = 60f;
						anlWiz2.Wind = 0.000138888892f;
						anlWiz2.SelfWt = false;
						anlWiz2.Dead = 1f;
						anlWiz2.Live = 4f;
						anlWiz2.Prod = 0f;
						anlWiz2.Roof = 2f;
						anlWiz2.Snow = 2f;
					}
					chkSelfWt.Enabled = false;
					CFSInterface.SetText (cboDeadLoad, anlWiz2.Dead);
					CFSInterface.SetText (cboLiveLoad, anlWiz2.Live);
					CFSInterface.SetText (cboProductLoad, anlWiz2.Prod);
					CFSInterface.SetText (cboRoofLoad, anlWiz2.Roof);
					CFSInterface.SetText (cboSnowLoad, anlWiz2.Snow);
					lblInput18.Text = "Wind Load";
					lblInput19.Visible = false;
					cboLoadAngle.Visible = false;
				} else {
					object tag6 = cboDeadLoad.Tag;
					NewLateBinding.LateSetComplex (tag6, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag6, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag6, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
					tag6 = null;
					object tag7 = cboLiveLoad.Tag;
					NewLateBinding.LateSetComplex (tag7, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag7, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag7, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
					tag7 = null;
					object tag8 = cboProductLoad.Tag;
					NewLateBinding.LateSetComplex (tag8, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag8, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag8, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
					tag8 = null;
					object tag9 = cboRoofLoad.Tag;
					NewLateBinding.LateSetComplex (tag9, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag9, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag9, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
					tag9 = null;
					object tag10 = cboSnowLoad.Tag;
					NewLateBinding.LateSetComplex (tag10, null, "UnitType", new object[1] { Units.UnitTypes.StressUnit }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag10, null, "Index", new object[1] { b }, null, null, OptimisticSet: false, RValueBase: true);
					NewLateBinding.LateSetComplex (tag10, null, "Max", new object[1] { 1.0 / 720.0 }, null, null, OptimisticSet: false, RValueBase: true);
					tag10 = null;
					if (AnlWiz.AnlType != CFSInterface.AnlWizSave.AnlType) {
						anlWiz2.TribWid = 60f;
						anlWiz2.Wind = 0.000138888892f;
						anlWiz2.SelfWt = true;
						anlWiz2.Dead = 6.94444461E-05f;
						anlWiz2.Live = 0.000277777785f;
						anlWiz2.Prod = 0f;
						anlWiz2.Roof = 0.000138888892f;
						anlWiz2.Snow = 0.000138888892f;
						anlWiz2.Angle = (float)Math.PI / 2f;
					}
					CFSInterface.SetText (cboDeadLoad, anlWiz2.Dead);
					CFSInterface.SetText (cboLiveLoad, anlWiz2.Live);
					CFSInterface.SetText (cboProductLoad, anlWiz2.Prod);
					CFSInterface.SetText (cboRoofLoad, anlWiz2.Roof);
					CFSInterface.SetText (cboSnowLoad, anlWiz2.Snow);
					CFSInterface.SetText (cboLoadAngle, anlWiz2.Angle);
					lblInput18.Text = "Wind Uplift";
					lblInput19.Visible = true;
					cboLoadAngle.Visible = true;
				}
				CFSInterface.SetText (cboWidth, anlWiz2.TribWid);
				chkSelfWt.Checked = anlWiz2.SelfWt;
				CFSInterface.SetText (cboWindLoad, anlWiz2.Wind);
				CFS.blnValidate = true;
				picAnl3.Image = tbrAnalyses.Items [iButton - 1].Image;
				lblAnl3.Text = tbrAnalyses.Items [iButton - 1].ToolTipText;
				cboWidth.Select ();
			} else if (iPage == 3) {
				iPage = 4;
				Text = "Analysis Wizard (4 of 4)";
				pnlAnlWizard4.Visible = true;
				InitializeCombinations (AnlWiz.SelfWt);
				lstCombSet.Items.Clear ();
				short num3 = (short)Information.UBound (CombSet);
				short num = 1;
				while (num <= num3 && !Information.IsNothing (CombSet [num]) && CombSet [num].Length != 0) {
					lstCombSet.Items.Add (CombSet [num]);
					num = (short)unchecked(num + 1);
				}
				lstCombSet.SelectedIndex = intCombSet - 1;
				cmdNext.Text = "&Finished";
				lstCombSet.Select ();
			} else {
				Hide ();
				if (iButton == 4) {
					AnlWiz.AnlType = (byte)iButton;
					AnlWiz.SelfWt = true;
				}
				CFSInterface.WebCripParametersNow.Fastened = AnlWiz.Fastened;
				short num4 = CFSInterface.NewAnlIndex ();
				if (num4 <= 0) {
					Cursor.Current = Cursors.Default;
					Interaction.MsgBox ("Unable to create analysis.", MsgBoxStyle.Information);
					Close ();
					return;
				}
				CFS.intAnlNow = (byte)num4;
				Analysis analysis = CFS.Analyses [num4];
				analysis.AppVer = 1400;
				analysis.Filename = CFSInterface.NewAnlFilename ();
				analysis.nLdg = 7;
				analysis.Ldg = new Loading[unchecked((int)analysis.nLdg) + 1];
				short nLdg = analysis.nLdg;
				for (short num = 0; num <= nLdg; num = (short)unchecked(num + 1)) {
					analysis.Ldg [num].Initialize (string.Empty, 10);
				}
				analysis.Ldg [0].Description = "Beam Self Weight";
				analysis.Ldg [1].Description = "Dead Load";
				analysis.Ldg [2].Description = "Live Load";
				analysis.Ldg [3].Description = "Product Load";
				analysis.Ldg [4].Description = "Roof Live Load";
				analysis.Ldg [5].Description = "Snow Load";
				analysis.Ldg [6].Description = "Wind Load";
				analysis.Ldg [7].Description = "Earthquake Load";
				short num5 = CFS.intSpecNow;
				if (Strings.InStr (CombSet [intCombSet], "ASD") > 0) {
					if (num5 == 38) {
						num5 = 37;
					}
					if (num5 == 40) {
						num5 = 39;
					}
					if (num5 == 41) {
						num5 = 37;
					}
					if (num5 == 33) {
						num5 = 32;
					}
					if (num5 == 35) {
						num5 = 34;
					}
					if (num5 == 36) {
						num5 = 32;
					}
					if (num5 == 28) {
						num5 = 27;
					}
					if (num5 == 30) {
						num5 = 29;
					}
					if (num5 == 31) {
						num5 = 27;
					}
					if (num5 == 23) {
						num5 = 22;
					}
					if (num5 == 25) {
						num5 = 24;
					}
					if (num5 == 26) {
						num5 = 22;
					}
					if (num5 == 18) {
						num5 = 17;
					}
					if (num5 == 20) {
						num5 = 19;
					}
					if (num5 == 21) {
						num5 = 17;
					}
					if (num5 == 13) {
						num5 = 12;
					}
					if (num5 == 15) {
						num5 = 14;
					}
					if (num5 == 16) {
						num5 = 12;
					}
					if (num5 == 8) {
						num5 = 7;
					}
					if (num5 == 10) {
						num5 = 9;
					}
					if (num5 == 11) {
						num5 = 7;
					}
					if (num5 == 3) {
						num5 = 2;
					}
					if (num5 == 5) {
						num5 = 4;
					}
					if (num5 == 6) {
						num5 = 2;
					}
					if (num5 == 1) {
						num5 = 0;
					}
				} else {
					if (num5 == 37) {
						num5 = 38;
					}
					if (num5 == 39) {
						num5 = 40;
					}
					if (num5 == 32) {
						num5 = 33;
					}
					if (num5 == 34) {
						num5 = 35;
					}
					if (num5 == 27) {
						num5 = 28;
					}
					if (num5 == 29) {
						num5 = 30;
					}
					if (num5 == 22) {
						num5 = 23;
					}
					if (num5 == 24) {
						num5 = 25;
					}
					if (num5 == 17) {
						num5 = 18;
					}
					if (num5 == 19) {
						num5 = 20;
					}
					if (num5 == 12) {
						num5 = 13;
					}
					if (num5 == 14) {
						num5 = 15;
					}
					if (num5 == 7) {
						num5 = 8;
					}
					if (num5 == 9) {
						num5 = 10;
					}
					if (num5 == 2) {
						num5 = 3;
					}
					if (num5 == 4) {
						num5 = 5;
					}
					if (num5 == 0) {
						num5 = 1;
					}
				}
				analysis.Comb = new LoadCombination[Information.UBound (Comb, 2) + 1];
				short num6 = (short)Information.UBound (analysis.Comb);
				for (short num7 = 0; num7 <= num6; num7 = (short)unchecked(num7 + 1)) {
					analysis.Comb [num7].Initialize (string.Empty, 10);
					analysis.Comb [num7].Spec = num5;
					analysis.Comb [num7].InflPt = chkInflectionPoint.Checked;
				}
				analysis.nComb = 0;
				short num8 = (short)(lstComb.Items.Count - 1);
				for (short num = 0; num <= num8; num = (short)unchecked(num + 1)) {
					if (lstComb.CheckedIndices.Contains (num)) {
						analysis.nComb++;
						analysis.Comb [analysis.nComb] = Comb [intCombSet, num + 1];
						analysis.Comb [analysis.nComb].InflPt = chkInflectionPoint.Checked;
						if (!((CFS.intUserCombs > 0) & (intCombSet == 1))) {
							analysis.Comb [analysis.nComb].Spec = num5;
						}
					}
				}
				analysis.AllCombos = true;
				if ((CFS.intUserCombs > 0) & (intCombSet == 1)) {
					analysis.AllCombos = false;
				}
				if (analysis.nComb == 0) {
					analysis.Comb [analysis.iComb].Description = "Combination 1";
				}
				analysis.Description = string.Empty;
				if (iButton < 4) {
					analysis.nSup = (byte)(AnlWiz.nSpan + 1);
					if (AnlWiz.iMemBrace == 4) {
						analysis.nSup += 2;
					} else {
						analysis.nSup = (byte)(short)unchecked(analysis.nSup + checked((short)unchecked(AnlWiz.nSpan * AnlWiz.iMemBrace)));
						if (AnlWiz.Fixed) {
							analysis.nSup = (byte)((short)unchecked(analysis.nSup + AnlWiz.nSpan) + 1);
						}
					}
					analysis.Sup = new Support[unchecked((int)analysis.nSup) + 1];
					short num9 = 0;
					float num10 = 0f;
					short num11 = (short)(AnlWiz.nSpan + 1);
					for (short num2 = 1; num2 <= num11; num2 = (short)unchecked(num2 + 1)) {
						num9 = (short)(num9 + 1);
						ref Support reference = ref analysis.Sup [num9];
						reference.Type = Conversions.ToByte (Interaction.IIf ((AnlWiz.iMemBrace == 4) | AnlWiz.Fixed, Supports.supY, (byte)7));
						reference.Z = num10;
						reference.Wid = AnlWiz.Wid;
						reference.K = 1f;
						if (AnlWiz.Fixed) {
							if ((num2 == 1) | (num2 > AnlWiz.nSpan)) {
								ref byte type = ref reference.Type;
								type = (byte)unchecked((uint)(type + 8));
							}
							if (num2 == 1) {
								reference.K = Conversions.ToSingle (Interaction.IIf (AnlWiz.nSpan == 1, 0.65, 0.8));
							}
							if ((num2 > 1) & (num2 == AnlWiz.nSpan)) {
								reference.K = 0.8f;
							}
						}
						reference.Fastened = AnlWiz.Fastened;
						if (((AnlWiz.iMemBrace == 4) & ((num2 == 1) | (num2 > AnlWiz.nSpan))) | ((AnlWiz.iMemBrace != 4) & AnlWiz.Fixed)) {
							num9 = (short)(num9 + 1);
							ref Support reference2 = ref analysis.Sup [num9];
							reference2.Type = 5;
							reference2.Z = Conversions.ToSingle (Operators.AddObject (num10, Operators.MultiplyObject (AnlWiz.CantLen, Interaction.IIf (num2 == 1, -1, 1))));
							reference2.Wid = AnlWiz.Wid;
							reference2.K = 1f;
							if (AnlWiz.Fixed) {
								if ((num2 == 1) | (num2 > AnlWiz.nSpan)) {
									ref byte type2 = ref reference2.Type;
									type2 = (byte)unchecked((uint)(type2 + 16));
								}
								if (num2 == 1) {
									reference2.K = Conversions.ToSingle (Interaction.IIf ((AnlWiz.nSpan == 1) & (AnlWiz.iMemBrace == 0), 0.65, 0.8));
								}
								if ((num2 > 1) & (num2 == AnlWiz.nSpan) & (AnlWiz.iMemBrace == 0)) {
									reference2.K = 0.8f;
								}
							}
							if (unchecked(AnlWiz.iMemBrace == 4 && num2 == 1)) {
								reference2.K = 0f;
							}
							reference2.Fastened = AnlWiz.Fastened;
						}
						if ((AnlWiz.iMemBrace != 4) & (num2 <= AnlWiz.nSpan)) {
							short iMemBrace = AnlWiz.iMemBrace;
							for (short num12 = 1; num12 <= iMemBrace; num12 = (short)unchecked(num12 + 1)) {
								num9 = (short)(num9 + 1);
								ref Support reference3 = ref analysis.Sup [num9];
								reference3.Type = 5;
								reference3.Z = (float)((double)num10 + (double)num12 / (double)(unchecked((int)AnlWiz.iMemBrace) + 1) * (double)AnlWiz.SpanLen [num2]);
								reference3.Wid = 1f;
								reference3.K = 1f;
								if (AnlWiz.Fixed & (num2 == AnlWiz.nSpan) & (num12 == AnlWiz.iMemBrace)) {
									reference3.K = 0.8f;
								}
								reference3.Fastened = false;
							}
						}
						if (num2 <= AnlWiz.nSpan) {
							num10 += AnlWiz.SpanLen [num2];
						}
					}
					unchecked {
						switch (AnlWiz.AnlType) {
						case 1: {
							string text = ((AnlWiz.nSpan != 1) ? (Conversions.ToString ((int)AnlWiz.nSpan) + "-Story") : (Units.DisplayLength (AnlWiz.SpanLen [1], 0, blnShowUnit: true, "", 0, 0) + " Tall"));
							if (AnlWiz.Fixed) {
								text += " Fixed-End";
							}
							analysis.Description = text + " Beam-Column";
							analysis.Vertical = true;
							analysis.nBeam = 1;
							analysis.Beam [1] = new Beam (AnlWiz.iSct);
							ref Beam reference11 = ref analysis.Beam [1];
							reference11.Z0 = 0f;
							reference11.Z1 = num10;
							reference11.iBrcFlg = AnlWiz.iBrcFlg;
							reference11.R = AnlWiz.R;
							reference11.Kf = AnlWiz.Kf;
							reference11.Lm = AnlWiz.Lm;
							reference11.ex = 0f;
							reference11.ey = 0f;
							if (AnlWiz.Dead > 0f) {
								ref Load reference12 = ref analysis.Ldg [1].Load [1];
								reference12.Type = 3;
								reference12.Ang = 0f;
								reference12.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference12.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference12.W0 = AnlWiz.Dead;
								reference12.W1 = reference12.W0;
								reference12.Wid = 1f;
								CFS.Analyses [num4].Ldg [1].nLoad = 1;
							}
							if (AnlWiz.Live > 0f) {
								ref Load reference13 = ref analysis.Ldg [2].Load [1];
								reference13.Type = 3;
								reference13.Ang = 0f;
								reference13.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference13.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference13.W0 = AnlWiz.Live;
								reference13.W1 = reference13.W0;
								reference13.Wid = 1f;
								CFS.Analyses [num4].Ldg [2].nLoad = 1;
							}
							if (AnlWiz.Prod > 0f) {
								ref Load reference14 = ref analysis.Ldg [3].Load [1];
								reference14.Type = 3;
								reference14.Ang = 0f;
								reference14.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference14.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference14.W0 = AnlWiz.Prod;
								reference14.W1 = reference14.W0;
								reference14.Wid = 1f;
								CFS.Analyses [num4].Ldg [3].nLoad = 1;
							}
							if (AnlWiz.Roof > 0f) {
								ref Load reference15 = ref analysis.Ldg [4].Load [1];
								reference15.Type = 3;
								reference15.Ang = 0f;
								reference15.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference15.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference15.W0 = AnlWiz.Roof;
								reference15.W1 = reference15.W0;
								reference15.Wid = 1f;
								CFS.Analyses [num4].Ldg [4].nLoad = 1;
							}
							if (AnlWiz.Snow > 0f) {
								ref Load reference16 = ref analysis.Ldg [5].Load [1];
								reference16.Type = 3;
								reference16.Ang = 0f;
								reference16.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference16.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference16.W0 = AnlWiz.Snow;
								reference16.W1 = reference16.W0;
								reference16.Wid = 1f;
								CFS.Analyses [num4].Ldg [5].nLoad = 1;
							}
							if (AnlWiz.Wind * AnlWiz.TribWid > 0f) {
								ref Load reference17 = ref analysis.Ldg [6].Load [1];
								reference17.Type = 1;
								reference17.Ang = (float)Math.PI / 2f;
								reference17.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference17.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference17.W0 = (0f - AnlWiz.Wind) * AnlWiz.TribWid;
								reference17.W1 = reference17.W0;
								reference17.Wid = 1f;
								CFS.Analyses [num4].Ldg [6].nLoad = 1;
							}
							break;
						}
						case 2: {
							string text;
							if (AnlWiz.nSpan == 1) {
								text = Units.DisplayLength (AnlWiz.SpanLen [1], 0, blnShowUnit: true, "", 0, 0) + " Span";
								text = (AnlWiz.Fixed ? (text + " Fixed-End Beam") : ((AnlWiz.CantLen != 0f) ? (text + " Beam") : (text + " Simple Beam")));
							} else {
								text = Conversions.ToString ((int)AnlWiz.nSpan) + "-Span";
								if (AnlWiz.Fixed) {
									text += " Fixed-End";
								}
								text += " Continuous Beam";
							}
							analysis.Description = text;
							analysis.Vertical = false;
							analysis.nBeam = 1;
							analysis.Beam [1] = new Beam (AnlWiz.iSct);
							ref Beam reference18 = ref analysis.Beam [1];
							reference18.Z0 = 0f - AnlWiz.CantLen;
							reference18.Z1 = num10 + AnlWiz.CantLen;
							reference18.iBrcFlg = AnlWiz.iBrcFlg;
							reference18.R = AnlWiz.R;
							reference18.Kf = AnlWiz.Kf;
							reference18.Lm = AnlWiz.Lm;
							reference18.ex = 0f;
							reference18.ey = 0f;
							if (AnlWiz.Dead * AnlWiz.TribWid > 0f) {
								ref Load reference19 = ref analysis.Ldg [1].Load [1];
								reference19.Type = 1;
								reference19.Ang = AnlWiz.Angle;
								reference19.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference19.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference19.W0 = (0f - AnlWiz.Dead) * AnlWiz.TribWid;
								reference19.W1 = reference19.W0;
								reference19.Wid = 1f;
								CFS.Analyses [num4].Ldg [1].nLoad = 1;
							}
							if (AnlWiz.Live * AnlWiz.TribWid > 0f) {
								ref Load reference20 = ref analysis.Ldg [2].Load [1];
								reference20.Type = 1;
								reference20.Ang = AnlWiz.Angle;
								reference20.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference20.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference20.W0 = (0f - AnlWiz.Live) * AnlWiz.TribWid;
								reference20.W1 = reference20.W0;
								reference20.Wid = 1f;
								CFS.Analyses [num4].Ldg [2].nLoad = 1;
							}
							if (AnlWiz.Prod * AnlWiz.TribWid > 0f) {
								ref Load reference21 = ref analysis.Ldg [3].Load [1];
								reference21.Type = 1;
								reference21.Ang = AnlWiz.Angle;
								reference21.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference21.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference21.W0 = (0f - AnlWiz.Prod) * AnlWiz.TribWid;
								reference21.W1 = reference21.W0;
								reference21.Wid = 1f;
								CFS.Analyses [num4].Ldg [3].nLoad = 1;
							}
							if (AnlWiz.Roof * AnlWiz.TribWid > 0f) {
								ref Load reference22 = ref analysis.Ldg [4].Load [1];
								reference22.Type = 1;
								reference22.Ang = AnlWiz.Angle;
								reference22.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference22.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference22.W0 = (0f - AnlWiz.Roof) * AnlWiz.TribWid;
								reference22.W1 = reference22.W0;
								reference22.Wid = 1f;
								CFS.Analyses [num4].Ldg [4].nLoad = 1;
							}
							if (AnlWiz.Snow * AnlWiz.TribWid > 0f) {
								ref Load reference23 = ref analysis.Ldg [5].Load [1];
								reference23.Type = 1;
								reference23.Ang = AnlWiz.Angle;
								reference23.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference23.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference23.W0 = (0f - AnlWiz.Snow) * AnlWiz.TribWid;
								reference23.W1 = reference23.W0;
								reference23.Wid = 1f;
								CFS.Analyses [num4].Ldg [5].nLoad = 1;
							}
							if (AnlWiz.Wind * AnlWiz.TribWid > 0f) {
								ref Load reference24 = ref analysis.Ldg [6].Load [1];
								reference24.Type = 1;
								reference24.Ang = AnlWiz.Angle;
								reference24.Z0 = CFS.Analyses [num4].Beam [1].Z0;
								reference24.Z1 = CFS.Analyses [num4].Beam [1].Z1;
								reference24.W0 = AnlWiz.Wind * AnlWiz.TribWid;
								reference24.W1 = reference24.W0;
								reference24.Wid = 1f;
								CFS.Analyses [num4].Ldg [6].nLoad = 1;
							}
							break;
						}
						case 3: {
							string text;
							if (AnlWiz.nSpan == 1) {
								text = Units.DisplayLength (AnlWiz.SpanLen [1], 0, blnShowUnit: true, "", 0, 0) + " Span";
								text = (AnlWiz.Fixed ? (text + " Fixed-End Beam") : ((AnlWiz.CantLen != 0f) ? (text + " Beam") : (text + " Simple Beam")));
							} else {
								text = Conversions.ToString ((int)AnlWiz.nSpan) + "-Span";
								if (AnlWiz.Fixed) {
									text += " Fixed-End";
								}
								text += " Beams with Laps";
							}
							analysis.Description = text;
							analysis.Vertical = false;
							checked {
								analysis.nBeam = (byte)AnlWiz.nSpan;
								if (analysis.nBeam > Information.UBound (analysis.Beam)) {
									analysis.Beam = new Beam[(int)Math.Round (Math.Ceiling ((double)unchecked((int)analysis.nBeam) / 10.0) * 10.0) + 1];
								}
								num10 = 0f;
								short nBeam = analysis.nBeam;
								for (short num2 = 1; num2 <= nBeam; num2 = (short)unchecked(num2 + 1)) {
									analysis.Beam [num2] = new Beam (AnlWiz.iSct);
									ref Beam reference4 = ref analysis.Beam [num2];
									reference4.Z0 = num10 - AnlWiz.LapLen;
									num10 += AnlWiz.SpanLen [num2];
									reference4.Z1 = num10 + AnlWiz.LapLen;
									reference4.iBrcFlg = AnlWiz.iBrcFlg;
									reference4.R = AnlWiz.R;
									reference4.Kf = AnlWiz.Kf;
									reference4.Lm = AnlWiz.Lm;
									reference4.ex = 0f;
									reference4.ey = 0f;
								}
								analysis.Beam [1].Z0 = 0f - AnlWiz.CantLen;
								analysis.Beam [analysis.nBeam].Z1 = num10 + AnlWiz.CantLen;
								if (AnlWiz.Dead * AnlWiz.TribWid > 0f) {
									ref Load reference5 = ref analysis.Ldg [1].Load [1];
									reference5.Type = 1;
									reference5.Ang = AnlWiz.Angle;
									reference5.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference5.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference5.W0 = (0f - AnlWiz.Dead) * AnlWiz.TribWid;
									reference5.W1 = reference5.W0;
									reference5.Wid = 1f;
									CFS.Analyses [num4].Ldg [1].nLoad = 1;
								}
								if (AnlWiz.Live * AnlWiz.TribWid > 0f) {
									ref Load reference6 = ref analysis.Ldg [2].Load [1];
									reference6.Type = 1;
									reference6.Ang = AnlWiz.Angle;
									reference6.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference6.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference6.W0 = (0f - AnlWiz.Live) * AnlWiz.TribWid;
									reference6.W1 = reference6.W0;
									reference6.Wid = 1f;
									CFS.Analyses [num4].Ldg [2].nLoad = 1;
								}
								if (AnlWiz.Prod * AnlWiz.TribWid > 0f) {
									ref Load reference7 = ref analysis.Ldg [3].Load [1];
									reference7.Type = 1;
									reference7.Ang = AnlWiz.Angle;
									reference7.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference7.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference7.W0 = (0f - AnlWiz.Prod) * AnlWiz.TribWid;
									reference7.W1 = reference7.W0;
									reference7.Wid = 1f;
									CFS.Analyses [num4].Ldg [3].nLoad = 1;
								}
								if (AnlWiz.Roof * AnlWiz.TribWid > 0f) {
									ref Load reference8 = ref analysis.Ldg [4].Load [1];
									reference8.Type = 1;
									reference8.Ang = AnlWiz.Angle;
									reference8.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference8.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference8.W0 = (0f - AnlWiz.Roof) * AnlWiz.TribWid;
									reference8.W1 = reference8.W0;
									reference8.Wid = 1f;
									CFS.Analyses [num4].Ldg [4].nLoad = 1;
								}
								if (AnlWiz.Snow * AnlWiz.TribWid > 0f) {
									ref Load reference9 = ref analysis.Ldg [5].Load [1];
									reference9.Type = 1;
									reference9.Ang = AnlWiz.Angle;
									reference9.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference9.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference9.W0 = (0f - AnlWiz.Snow) * AnlWiz.TribWid;
									reference9.W1 = reference9.W0;
									reference9.Wid = 1f;
									CFS.Analyses [num4].Ldg [5].nLoad = 1;
								}
								if (AnlWiz.Wind * AnlWiz.TribWid > 0f) {
									ref Load reference10 = ref analysis.Ldg [6].Load [1];
									reference10.Type = 1;
									reference10.Ang = AnlWiz.Angle;
									reference10.Z0 = CFS.Analyses [num4].Beam [1].Z0;
									reference10.Z1 = CFS.Analyses [num4].Beam [CFS.Analyses [num4].nBeam].Z1;
									reference10.W0 = AnlWiz.Wind * AnlWiz.TribWid;
									reference10.W1 = reference10.W0;
									reference10.Wid = 1f;
									CFS.Analyses [num4].Ldg [6].nLoad = 1;
								}
								break;
							}
						}
						}
					}
				}
				analysis = null;
				bool flag = ((!CFS.blnAnlInpLoaded) ? true : false);
				CFSInterface.ShowAnl (num4);
				if (!flag) {
					My.MyProject.Forms.frmAnlInp.tabAnl.SelectedIndex = 0;
				}
				My.MyProject.Forms.frmAnlInp.txtDescription.Select ();
				CFSInterface.AnlWizSave = AnlWiz;
				Close ();
			}
			Cursor.Current = Cursors.Default;
		}
	}

	private void InitializeCombinations (bool blnSelfWt)
	{
		CombSet = new string[41];
		Comb = new LoadCombination[41, 15];
		int num = Information.UBound (Comb);
		checked {
			for (int i = 1; i <= num; i++) {
				short num2 = (short)Information.UBound (Comb, 2);
				for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
					Comb [i, num3].Initialize (string.Empty, 10);
				}
			}
			intCombSet = 0;
			if (CFS.intUserCombs > 0) {
				intCombSet++;
				CombSet [intCombSet] = "Custom Combinations";
				short intUserCombs = CFS.intUserCombs;
				for (short num3 = 1; num3 <= intUserCombs; num3 = (short)unchecked(num3 + 1)) {
					Comb [intCombSet, num3] = CFS.UserComb [num3].Clone ();
					ref LoadCombination reference = ref Comb [intCombSet, num3];
					reference.nLF = 0;
					if (unchecked(reference.LF [1].iLdg == 0 && !blnSelfWt)) {
						reference.LF [1].fLdg = 0f;
					}
					short num4 = 1;
					do {
						if (reference.LF [num4].fLdg != 0f) {
							reference.nLF++;
							reference.LF [reference.nLF] = CFS.UserComb [num3].LF [num4];
						}
						num4 = (short)unchecked(num4 + 1);
					} while (num4 <= 8);
					for (num4 = (short)(unchecked((int)reference.nLF) + 1); num4 <= 8; num4 = (short)unchecked(num4 + 1)) {
						reference.LF [num4].iLdg = 0;
						reference.LF [num4].fLdg = 0f;
					}
				}
			}
			InitCombASCE (ref intCombSet, blnSelfWt);
			InitCombIBC (ref intCombSet, blnSelfWt);
			InitCombNBCC (ref intCombSet, blnSelfWt);
			InitCombRMI (ref intCombSet, blnSelfWt);
			if (CFS.intUserCombs > 0) {
				intCombSet = 1;
				return;
			}
			if (CFS.IsSpecASD (CFS.intSpecNow)) {
				intCombSet = 1;
			}
			if (CFS.IsSpecLRFD (CFS.intSpecNow)) {
				intCombSet = 2;
			}
			if (CFS.IsSpecLSD (CFS.intSpecNow)) {
				intCombSet = 27;
			}
		}
	}

	private void InitCombASCE (ref short intCombSet, bool blnSelfWt)
	{
		checked {
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-22 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+0.7S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+0.7S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.75(L+0.6W+Lr)", new byte[6] { 0, 1, 2, 3, 6, 4 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.45f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(L+0.6W+0.7S)", new byte[6] { 0, 1, 2, 3, 6, 5 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.45f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.525E+0.75L+0.1S", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.1f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-22 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.3S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.3f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 4, 2, 3 }, new float[5] { 1.2f, 1.2f, 1.6f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+S+L", new byte[5] { 0, 1, 5, 2, 3 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 6, 2, 3, 4 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 1f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.3S", new byte[6] { 0, 1, 6, 2, 3, 5 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 1f, 0.3f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "1.2D+E+L+0.15S", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 1f, 0.15f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-16 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(0.6W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(0.6W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-16 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-10 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(0.6W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(0.6W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 14, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-10 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-05 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 14, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-05 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-02 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.525f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 14, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-02 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-98 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.7E+L+Lr", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 1f, 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.7E+L+S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 1f, 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-98 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+0.5L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+0.5L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+0.5L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+0.5L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+0.5L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-95 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(E+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(E+L+S)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "ASCE 7-95 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+0.5L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+0.5L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.3W+0.5L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.3W+0.5L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+0.5L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.2f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.3W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
		}
	}

	private void InitCombIBC (ref short intCombSet, bool blnSelfWt)
	{
		checked {
			intCombSet++;
			CombSet [intCombSet] = "IBC 2018 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(0.6W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(0.6W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2018 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2015 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(0.6W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(0.6W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2015 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2012 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(0.6W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(0.6W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+0.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 0.6f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2012 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.5W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.5W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2009 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+Lr)", new byte[6] { 0, 1, 7, 2, 3, 4 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 14, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2009 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2006 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.75(0.7E+L+Lr)", new byte[6] { 0, 1, 7, 2, 3, 4 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "D+0.75(0.7E+L+S)", new byte[6] { 0, 1, 7, 2, 3, 5 }, new float[6] { 1f, 1f, 0.525f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 14, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2006 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2000 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+Lr", new byte[3] { 0, 1, 4 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+S", new byte[3] { 0, 1, 5 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+W", new byte[3] { 0, 1, 6 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(L+Lr)", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.75(L+S)", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.75(W+L+Lr)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "D+0.75(W+L+S)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "D+0.7E+L+Lr", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 1f, 1f, 1f, 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "D+0.7E+L+S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1f, 1f, 1f, 1f, 1f, 0.7f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.6D+W", new byte[3] { 0, 1, 6 }, new float[3] { 0.6f, 0.6f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 13, "0.6D+0.7E", new byte[3] { 0, 1, 7 }, new float[3] { 0.6f, 0.6f, 0.7f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "IBC 2000 LRFD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1f, 1f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.6W+L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.6W+L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+E+L+0.7S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 1f, 1f, 0.7f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.6W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1f }, blnSelfWt);
		}
	}

	private void InitCombNBCC (ref short intCombSet, bool blnSelfWt)
	{
		checked {
			intCombSet++;
			CombSet [intCombSet] = "NBCC 2020 LSD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.25D+1.5L+S", new byte[4] { 0, 1, 2, 5 }, new float[4] { 1.25f, 1.25f, 1.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.25D+1.5L+0.4W", new byte[4] { 0, 1, 2, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.25D+1.5S+L", new byte[4] { 0, 1, 5, 2 }, new float[4] { 1.25f, 1.25f, 1.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.25D+1.5S+0.4W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.25D+1.4W+0.5L", new byte[4] { 0, 1, 6, 2 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.25D+1.4W+0.5S", new byte[4] { 0, 1, 6, 5 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "0.9D+1.4W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.0D+E+0.5L+0.25S", new byte[5] { 0, 1, 7, 2, 5 }, new float[5] { 1f, 1f, 1f, 0.5f, 0.25f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "NBCC 2015 LSD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.25D+1.5L+S", new byte[4] { 0, 1, 2, 5 }, new float[4] { 1.25f, 1.25f, 1.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.25D+1.5L+0.4W", new byte[4] { 0, 1, 2, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.25D+1.5S+L", new byte[4] { 0, 1, 5, 2 }, new float[4] { 1.25f, 1.25f, 1.5f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.25D+1.5S+0.4W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.25D+1.4W+0.5L", new byte[4] { 0, 1, 6, 2 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.25D+1.4W+0.5S", new byte[4] { 0, 1, 6, 5 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "0.9D+1.4W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.0D+E+0.5L+0.25S", new byte[5] { 0, 1, 7, 2, 5 }, new float[5] { 1f, 1f, 1f, 0.5f, 0.25f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "NBCC 2010 LSD";
			AssignCombination (intCombSet, 1, "1.4D", new byte[2] { 0, 1 }, new float[2] { 1.4f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.25D+1.5L+0.5S", new byte[4] { 0, 1, 2, 5 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.25D+1.5L+0.4W", new byte[4] { 0, 1, 2, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.25D+1.5S+0.5L", new byte[4] { 0, 1, 5, 2 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.25D+1.5S+0.4W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.25f, 1.25f, 1.5f, 0.4f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.25D+1.4W+0.5L", new byte[4] { 0, 1, 6, 2 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.25D+1.4W+0.5S", new byte[4] { 0, 1, 6, 5 }, new float[4] { 1.25f, 1.25f, 1.4f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "0.9D+1.4W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.0D+E+0.5L+0.25S", new byte[5] { 0, 1, 7, 2, 5 }, new float[5] { 1f, 1f, 1f, 0.5f, 0.25f }, blnSelfWt);
		}
	}

	private void InitCombRMI (ref short intCombSet, bool blnSelfWt)
	{
		checked {
			intCombSet++;
			CombSet [intCombSet] = "RMI MH16.1-2012 ASD";
			AssignCombination (intCombSet, 1, "D+P", new byte[3] { 0, 1, 3 }, new float[3] { 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+P+L", new byte[4] { 0, 1, 3, 2 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+P+Lr", new byte[4] { 0, 1, 3, 4 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "D+P+S", new byte[4] { 0, 1, 3, 5 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "D+0.75(P+L+Lr)", new byte[5] { 0, 1, 3, 2, 4 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "D+0.75(P+L+S)", new byte[5] { 0, 1, 3, 2, 5 }, new float[5] { 1f, 1f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "D+0.75(P+L+Lr+0.6W)", new byte[6] { 0, 1, 3, 2, 4, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "D+0.75(P+L+S+0.6W)", new byte[6] { 0, 1, 3, 2, 5, 6 }, new float[6] { 1f, 1f, 0.75f, 0.75f, 0.75f, 0.45f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "0.6D+0.6P+0.6W", new byte[4] { 0, 1, 3, 6 }, new float[4] { 0.6f, 0.6f, 0.6f, 0.6f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "RMI MH16.1-2012 LRFD";
			AssignCombination (intCombSet, 1, "1.4D+1.2P", new byte[3] { 0, 1, 3 }, new float[3] { 1.4f, 1.4f, 1.2f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.4P+1.6L+0.5Lr", new byte[5] { 0, 1, 3, 2, 4 }, new float[5] { 1.2f, 1.2f, 1.4f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.4P+1.6L+0.5S", new byte[5] { 0, 1, 3, 2, 5 }, new float[5] { 1.2f, 1.2f, 1.4f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+0.85P+0.5L+1.6Lr", new byte[5] { 0, 1, 3, 2, 4 }, new float[5] { 1.2f, 1.2f, 0.85f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+0.85P+0.5L+1.6S", new byte[5] { 0, 1, 3, 2, 5 }, new float[5] { 1.2f, 1.2f, 0.85f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+0.85P+0.5W+1.6Lr", new byte[5] { 0, 1, 3, 6, 4 }, new float[5] { 1.2f, 1.2f, 0.85f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+0.85P+0.5W+1.6S", new byte[5] { 0, 1, 3, 6, 5 }, new float[5] { 1.2f, 1.2f, 0.85f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+0.85P+0.5L+W+0.5Lr", new byte[6] { 0, 1, 3, 2, 6, 4 }, new float[6] { 1.2f, 1.2f, 0.85f, 0.5f, 1f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+0.85P+0.5L+W+0.5S", new byte[6] { 0, 1, 3, 2, 6, 5 }, new float[6] { 1.2f, 1.2f, 0.85f, 0.5f, 1f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "0.9D+0.9P+W", new byte[4] { 0, 1, 3, 6 }, new float[4] { 0.9f, 0.9f, 0.9f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "RMI MH16.1-2004 ASD";
			AssignCombination (intCombSet, 1, "DL", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "DL+LL+SL+PL", new byte[5] { 0, 1, 2, 5, 3 }, new float[5] { 1f, 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "DL+WL+PL", new byte[4] { 0, 1, 6, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "DL+EL+PL", new byte[4] { 0, 1, 7, 3 }, new float[4] { 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "DL+LL+0.5SL+WL+PL", new byte[6] { 0, 1, 2, 5, 6, 3 }, new float[6] { 1f, 1f, 1f, 0.5f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "DL+LL+0.5SL+EL+PL", new byte[6] { 0, 1, 2, 5, 7, 3 }, new float[6] { 1f, 1f, 1f, 0.5f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "DL+LL+0.5SL+0.88PL", new byte[5] { 0, 1, 2, 5, 3 }, new float[5] { 1f, 1f, 1f, 0.5f, 0.88f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "RMI MH16.1-2004 LRFD";
			AssignCombination (intCombSet, 1, "1.4DL+LL+1.2PL", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1.4f, 1.4f, 1f, 1.2f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2DL+1.6LL+0.5SL+1.4PL", new byte[5] { 0, 1, 2, 5, 3 }, new float[5] { 1.2f, 1.2f, 1.6f, 0.5f, 1.4f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2DL+1.6SL+0.5LL+0.85PL", new byte[5] { 0, 1, 5, 2, 3 }, new float[5] { 1.2f, 1.2f, 1.6f, 0.5f, 0.85f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2DL+1.6SL+0.8WL+0.85PL", new byte[5] { 0, 1, 5, 6, 3 }, new float[5] { 1.2f, 1.2f, 1.6f, 0.8f, 0.85f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2DL+1.3WL+0.5LL+0.5SL+0.85PL", new byte[6] { 0, 1, 6, 2, 5, 3 }, new float[6] { 1.2f, 1.2f, 1.3f, 0.5f, 0.5f, 0.85f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2DL+1.5EL+0.5LL+0.2SL+0.85PL", new byte[6] { 0, 1, 7, 2, 5, 3 }, new float[6] { 1.2f, 1.2f, 1.5f, 0.5f, 0.2f, 0.85f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "0.9DL+1.3WL+0.9PL", new byte[4] { 0, 1, 6, 3 }, new float[4] { 0.9f, 0.9f, 1.3f, 0.9f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "0.9DL+1.3EL+0.9PL", new byte[4] { 0, 1, 7, 3 }, new float[4] { 0.9f, 0.9f, 1.3f, 0.9f }, blnSelfWt);
		}
	}

	private void InitCombAISI (ref short intCombSet, bool blnSelfWt)
	{
		checked {
			intCombSet++;
			CombSet [intCombSet] = "AISI 2001 LSD";
			AssignCombination (intCombSet, 1, "1.25D+1.5L", new byte[6] { 0, 1, 2, 3, 4, 5 }, new float[6] { 1.25f, 1.25f, 1.5f, 1.5f, 1.5f, 1.5f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.25D+1.5W", new byte[3] { 0, 1, 6 }, new float[3] { 1.25f, 1.25f, 1.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.25D+0.7(1.5L+1.5W)", new byte[7] { 0, 1, 2, 3, 4, 5, 6 }, new float[7] { 1.25f, 1.25f, 1.05f, 1.05f, 1.05f, 1.05f, 1.05f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "0.85D+1.5W", new byte[3] { 0, 1, 6 }, new float[3] { 0.85f, 0.85f, 1.5f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "0.85D+0.7(1.5L+1.5W)", new byte[7] { 0, 1, 2, 3, 4, 5, 6 }, new float[7] { 0.85f, 0.85f, 1.05f, 1.05f, 1.05f, 1.05f, 1.05f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.0D+1.0E+1.0L", new byte[7] { 0, 1, 2, 3, 4, 5, 7 }, new float[7] { 1f, 1f, 1f, 1f, 0.5f, 0.5f, 1f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "AISI 1996 ASD";
			AssignCombination (intCombSet, 1, "D", new byte[2] { 0, 1 }, new float[2] { 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "D+L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1f, 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "D+L+S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1f, 1f, 1f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "0.75(D+W)", new byte[3] { 0, 1, 6 }, new float[3] { 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "0.75(D+E)", new byte[3] { 0, 1, 7 }, new float[3] { 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "0.75(D+L+Lr+W)", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "0.75(D+L+Lr+E)", new byte[6] { 0, 1, 2, 3, 4, 7 }, new float[6] { 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "0.75(D+L+S+W)", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "0.75(D+L+S+E)", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 0.75f, 0.75f, 0.75f, 0.75f, 0.75f, 0.75f }, blnSelfWt);
			intCombSet++;
			CombSet [intCombSet] = "AISI 1996 LRFD";
			AssignCombination (intCombSet, 1, "1.4D+L", new byte[4] { 0, 1, 2, 3 }, new float[4] { 1.4f, 1.4f, 1f, 1f }, blnSelfWt);
			AssignCombination (intCombSet, 2, "1.2D+1.6L+0.5Lr", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 3, "1.2D+1.6L+0.5S", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 1.6f, 1.6f, 0.5f }, blnSelfWt);
			AssignCombination (intCombSet, 4, "1.2D+1.6Lr+0.5L", new byte[5] { 0, 1, 2, 3, 4 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 5, "1.2D+1.6Lr+0.8W", new byte[4] { 0, 1, 4, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 6, "1.2D+1.6S+0.5L", new byte[5] { 0, 1, 2, 3, 5 }, new float[5] { 1.2f, 1.2f, 0.5f, 0.5f, 1.6f }, blnSelfWt);
			AssignCombination (intCombSet, 7, "1.2D+1.6S+0.8W", new byte[4] { 0, 1, 5, 6 }, new float[4] { 1.2f, 1.2f, 1.6f, 0.8f }, blnSelfWt);
			AssignCombination (intCombSet, 8, "1.2D+1.3W+0.5L+0.5Lr", new byte[6] { 0, 1, 2, 3, 4, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 9, "1.2D+1.3W+0.5L+0.5S", new byte[6] { 0, 1, 2, 3, 5, 6 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.5f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 10, "1.2D+1.5E+0.5L+0.2S", new byte[6] { 0, 1, 2, 3, 5, 7 }, new float[6] { 1.2f, 1.2f, 0.5f, 0.5f, 0.2f, 1.5f }, blnSelfWt);
			AssignCombination (intCombSet, 11, "0.9D+1.3W", new byte[3] { 0, 1, 6 }, new float[3] { 0.9f, 0.9f, 1.3f }, blnSelfWt);
			AssignCombination (intCombSet, 12, "0.9D+1.5E", new byte[3] { 0, 1, 7 }, new float[3] { 0.9f, 0.9f, 1.5f }, blnSelfWt);
		}
	}

	private void AssignCombination (short intCombSet, short intComb, string strDesc, byte[] iLdgs, float[] fLdgs, bool blnSelfWt)
	{
		ref LoadCombination reference = ref Comb [intCombSet, intComb];
		reference.Description = strDesc;
		reference.nLF = 0;
		int num = Information.LBound (iLdgs);
		int num2 = Information.UBound (iLdgs);
		checked {
			for (int i = num; i <= num2; i++) {
				if (unchecked(iLdgs [i] != 0 || blnSelfWt)) {
					reference.nLF++;
					reference.LF [reference.nLF].iLdg = iLdgs [i];
					reference.LF [reference.nLF].fLdg = fLdgs [i];
				}
			}
		}
	}

	private void lstCombSet_SelectedIndexChanged (object sender, EventArgs e)
	{
		checked {
			intCombSet = (short)(lstCombSet.SelectedIndex + 1);
			lstComb.Items.Clear ();
			short num = (short)Information.UBound (Comb, 2);
			short num2 = 1;
			IEnumerator enumerator = default(IEnumerator);
			while (num2 <= num && Strings.Len (Comb [intCombSet, num2].Description) != 0) {
				ListItem listItem = new ListItem (Comb [intCombSet, num2].Description, 0);
				int num3 = 0;
				short nLF = Comb [intCombSet, num2].nLF;
				for (short num4 = 1; num4 <= nLF; num4 = (short)unchecked(num4 + 1)) {
					ref LoadFactor reference = ref Comb [intCombSet, num2].LF [num4];
					switch (reference.iLdg) {
					case 1:
						if ((AnlWiz.Dead != 0f) | AnlWiz.SelfWt) {
							num3 = (int)Math.Round ((float)num3 + 20f * reference.fLdg);
						}
						break;
					case 2:
						if (AnlWiz.Live != 0f) {
							num3 = (int)Math.Round ((float)num3 + 400f * reference.fLdg);
						}
						break;
					case 3:
						if (AnlWiz.Prod != 0f) {
							num3 = (int)Math.Round ((float)num3 + 8000f * reference.fLdg);
						}
						break;
					case 4:
						if (AnlWiz.Roof != 0f) {
							num3 = (int)Math.Round ((float)num3 + 160000f * reference.fLdg);
						}
						break;
					case 5:
						if (AnlWiz.Snow != 0f) {
							num3 = (int)Math.Round ((float)num3 + 3200000f * reference.fLdg);
						}
						break;
					case 6:
						if (AnlWiz.Wind != 0f) {
							num3 = (int)Math.Round ((float)num3 + 6.4E+07f * reference.fLdg);
						}
						break;
					case 7:
						num3++;
						break;
					}
				}
				listItem.ItemData = num3;
				bool isChecked = num3 > 0;
				try {
					enumerator = lstComb.CheckedItems.GetEnumerator ();
					while (enumerator.MoveNext ()) {
						if (Operators.ConditionalCompareObjectEqual (NewLateBinding.LateGet (RuntimeHelpers.GetObjectValue (enumerator.Current), null, "ItemData", new object[0], null, null, null), num3, TextCompare: false)) {
							isChecked = false;
							break;
						}
					}
				} finally {
					if (enumerator is IDisposable) {
						(enumerator as IDisposable).Dispose ();
					}
				}
				lstComb.Items.Add (listItem, isChecked);
				num2 = (short)unchecked(num2 + 1);
			}
			if (lstComb.Items.Count > 0) {
				lstComb.TopIndex = 0;
			}
		}
	}

	private void chkFixed_Click (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			ref AnalysisWizard anlWiz = ref AnlWiz;
			CFS.blnValidate = false;
			if (chkFixed.Checked) {
				anlWiz.Fixed = true;
				anlWiz.CantLen = 0f;
				CFSInterface.SetText (cboCantilever, anlWiz.CantLen);
			} else {
				anlWiz.Fixed = false;
			}
			CFS.blnValidate = true;
		}
	}

	private void chkSelfWt_Click (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			if (chkSelfWt.Checked) {
				AnlWiz.SelfWt = true;
			} else {
				AnlWiz.SelfWt = false;
			}
		}
	}

	private void ctrl_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
		CFSInterface.SetSelection ((Control)sender);
	}

	private void ctrl_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (sender is ComboBox) {
			NewLateBinding.LateSet (sender, null, "DroppedDown", new object[1] { false }, null, null);
		}
		if (e.KeyChar == '\r') {
			ctrl_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			ctrl_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			CFSInterface.SetSelection ((Control)sender);
			e.Handled = true;
		}
	}

	private void ctrl_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void ctrl_DropDown (object sender, EventArgs e)
	{
		CFSInterface.BuildList ((ComboBox)sender);
	}

	private void ctrl_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate && Conversions.ToBoolean (Operators.AndObject (Operators.CompareObjectGreater (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Items", new object[0], null, null, null), null, "Count", new object[0], null, null, null), 0, TextCompare: false), Operators.CompareObjectGreaterEqual (NewLateBinding.LateGet (sender, null, "SelectedIndex", new object[0], null, null, null), 0, TextCompare: false)))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Index", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "SelectedItem", new object[0], null, null, null), null, "ItemData", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void list_SelectedIndexChanged (object sender, EventArgs e)
	{
		if (!CFS.blnValidate) {
			return;
		}
		ref AnalysisWizard anlWiz = ref AnlWiz;
		CFS.blnValidate = false;
		bool flag = true;
		checked {
			if (flag == (sender == cboSection)) {
				anlWiz.iSct = Conversions.ToByte (NewLateBinding.LateGet (cboSection.Items [cboSection.SelectedIndex], null, "ItemData", new object[0], null, null, null));
			} else if (flag == (sender == cboFastenedSupport)) {
				anlWiz.Fastened = cboFastenedSupport.SelectedIndex == 0;
			} else if (flag == (sender == cboMemberBracing)) {
				anlWiz.iMemBrace = (byte)cboMemberBracing.SelectedIndex;
				if (anlWiz.iMemBrace == 4) {
					anlWiz.iBrcFlg = 0;
					cboBracedFlange.SelectedIndex = anlWiz.iBrcFlg;
				}
			} else if (flag == (sender == cboBracedFlange)) {
				anlWiz.iBrcFlg = (byte)cboBracedFlange.SelectedIndex;
				if ((anlWiz.iBrcFlg > 0) & (anlWiz.iMemBrace == 4)) {
					anlWiz.iMemBrace = 0;
					cboMemberBracing.SelectedIndex = anlWiz.iMemBrace;
				}
			}
			CFS.blnValidate = true;
		}
	}

	private void ctrl_Validating (object sender, CancelEventArgs e)
	{
		if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
		} else if (CFSInterface.Validate ((Control)sender)) {
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
			ref AnalysisWizard anlWiz = ref AnlWiz;
			CFS.blnValidate = false;
			bool flag = true;
			if (flag == (sender == cboCantilever)) {
				anlWiz.CantLen = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
				if (anlWiz.CantLen > 0f) {
					anlWiz.Fixed = false;
					chkFixed.Checked = false;
				}
			} else if (flag == (sender == cboLapLength)) {
				anlWiz.LapLen = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboBearingLength)) {
				anlWiz.Wid = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == txtMomRed)) {
				anlWiz.R = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboStiffness)) {
				anlWiz.Kf = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLm)) {
				anlWiz.Lm = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboWidth)) {
				anlWiz.TribWid = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboDeadLoad)) {
				anlWiz.Dead = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLiveLoad)) {
				anlWiz.Live = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboProductLoad)) {
				anlWiz.Prod = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboRoofLoad)) {
				anlWiz.Roof = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboSnowLoad)) {
				anlWiz.Snow = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboWindLoad)) {
				anlWiz.Wind = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			} else if (flag == (sender == cboLoadAngle)) {
				anlWiz.Angle = Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Value", new object[0], null, null, null));
			}
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
		} else {
			e.Cancel = true;
		}
	}

	private void txtSpans_GotFocus (object sender, EventArgs e)
	{
		if (Conversions.ToBoolean (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[0], null, null, null))) {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[1] { NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
		}
	}

	private void txtSpans_KeyPress (object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r') {
			txtSpans_Validating (RuntimeHelpers.GetObjectValue (sender), new CancelEventArgs ());
			txtSpans_GotFocus (RuntimeHelpers.GetObjectValue (sender), null);
			e.Handled = true;
		} else if (e.KeyChar == '\u001b') {
			NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
			base.AcceptButton = cmdNext;
			base.CancelButton = cmdCancel;
			CFS.blnValidate = false;
			NewLateBinding.LateSet (sender, null, "Text", new object[1] { NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null) }, null, null);
			CFS.blnValidate = true;
			e.Handled = true;
		}
	}

	private void txtSpans_TextChanged (object sender, EventArgs e)
	{
		if (CFS.blnValidate) {
			base.AcceptButton = null;
			base.CancelButton = null;
		}
	}

	private void txtSpans_Validating (object sender, CancelEventArgs e)
	{
		checked {
			float[] array = new float[Information.UBound (AnlWiz.SpanLen) + 1];
			if (Strings.StrComp (Conversions.ToString (NewLateBinding.LateGet (sender, null, "Text", new object[0], null, null, null)), Conversions.ToString (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Text", new object[0], null, null, null))) == 0) {
				NewLateBinding.LateSetComplex (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Valid", new object[1] { true }, null, null, OptimisticSet: false, RValueBase: true);
				base.AcceptButton = cmdNext;
				base.CancelButton = cmdCancel;
			} else {
				string text = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject ("Enter the length of each span separated by ", Interaction.IIf (Operators.CompareString (strDel, ",", TextCompare: false) == 0, "commas.", "semicolons.")), "\r\n"));
				text = text + "Span lengths must be between " + Units.DisplayLength (Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Min", new object[0], null, null, null)), 0, blnShowUnit: true, "", 0, 0) + " and " + Units.DisplayLength (Conversions.ToSingle (NewLateBinding.LateGet (NewLateBinding.LateGet (sender, null, "Tag", new object[0], null, null, null), null, "Max", new object[0], null, null, null)), 0, blnShowUnit: true, "", 0, 0) + ".\r\n";
				text = text + "You may enter up to " + Conversions.ToString (Information.UBound (AnlWiz.SpanLen)) + " spans.";
				string text2 = Strings.Trim (txtSpans.Text);
				if (Strings.Len (text2) == 0) {
					NewLateBinding.LateSetComplex (txtSpans.Tag, null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
					Interaction.MsgBox (text, MsgBoxStyle.Information);
					e.Cancel = true;
					return;
				}
				if (Operators.CompareString (Strings.Right (text2, 1), strDel, TextCompare: false) != 0) {
					text2 += strDel;
				}
				short num = 0;
				short num2 = 0;
				while (true) {
					short num3 = (short)Strings.InStr (num2 + 1, text2, strDel);
					if (num3 == 0) {
						break;
					}
					num = (short)(num + 1);
					if (num > Information.UBound (AnlWiz.SpanLen)) {
						NewLateBinding.LateSetComplex (txtSpans.Tag, null, "Valid", new object[1] { false }, null, null, OptimisticSet: false, RValueBase: true);
						Interaction.MsgBox (text, MsgBoxStyle.Information);
						e.Cancel = true;
						return;
					}
					txtSpan.Text = Strings.Trim (Strings.Mid (text2, num2 + 1, (short)unchecked(num3 - num2) - 1));
					NewLateBinding.LateSetComplex (txtSpan.Tag, null, "Index", new object[1] { NewLateBinding.LateGet (txtSpans.Tag, null, "Index", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
					CFSInterface.Validate (txtSpan, blnShowUnit: false);
					NewLateBinding.LateSetComplex (txtSpans.Tag, null, "Valid", new object[1] { NewLateBinding.LateGet (txtSpan.Tag, null, "Valid", new object[0], null, null, null) }, null, null, OptimisticSet: false, RValueBase: true);
					if (Conversions.ToBoolean (Operators.NotObject (NewLateBinding.LateGet (txtSpans.Tag, null, "Valid", new object[0], null, null, null)))) {
						Interaction.MsgBox (text, MsgBoxStyle.Information);
						e.Cancel = true;
						return;
					}
					array [num] = Conversions.ToSingle (NewLateBinding.LateGet (txtSpan.Tag, null, "Value", new object[0], null, null, null));
					text2 = Conversions.ToString (Operators.ConcatenateObject (Operators.ConcatenateObject (Strings.Left (text2, num2) + " ", NewLateBinding.LateGet (txtSpan.Tag, null, "Text", new object[0], null, null, null)), Strings.Mid (text2, num3)));
					num2 = (short)(num2 + Strings.Len (RuntimeHelpers.GetObjectValue (NewLateBinding.LateGet (txtSpan.Tag, null, "Text", new object[0], null, null, null))) + 2);
				}
				AnlWiz.nSpan = num;
				AnlWiz.SpanLen = array;
				base.AcceptButton = cmdNext;
				base.CancelButton = cmdCancel;
				CFS.blnValidate = false;
				txtSpans.Text = Strings.Mid (text2, 2, Strings.Len (text2) - 2);
				CFS.blnValidate = true;
			}
			txtSpans.SelectAll ();
		}
	}
}
