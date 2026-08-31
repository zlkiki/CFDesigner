// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My;

namespace RSG.CFS;

internal class Analysis
{
	public string Filename;

	public DateTime RevDate;

	public string RevBy;

	public string Description;

	public string Project;

	public short AppVer;

	public bool Saved;

	public float Zmin;

	public float Zmax;

	public Beam[] Beam;

	public GridState BeamGrid;

	public byte nBeam;

	public Support[] Sup;

	public GridState SupGrid;

	public byte nSup;

	public Loading[] Ldg;

	public byte iLdg;

	public byte nLdg;

	public LoadCombination[] Comb;

	public bool AllCombos;

	public byte iComb;

	public byte nComb;

	public byte iCombSol;

	public string Notes;

	public string Report;

	public Solution[] Sol;

	public short Zoom;

	public float ZoomX;

	public float ZoomY;

	public short iAnlTab;

	public float[] ZPt;

	public byte iPt;

	public bool Vertical;

	public bool BucklingTheory;

	public bool Torsion;

	public TorsionSegment[] Tseg;

	public short nTseg;

	public short iUndo;

	public short iUndoTab;

	public short iRedoTab;

	public string strUndo;

	public string strRedo;

	public float[] Rdiag;

	public float[] Rdiag2;

	public float Rmax;

	public float YRbase;

	public float[] Vdiag;

	public float[] Vdiag2;

	public float Vmax;

	public float YVbase;

	public float[] Mdiag;

	public float[] Mdiag2;

	public float Mmax;

	public float YMbase;

	public float[] Ddiag;

	public float[] Ddiag2;

	public float Dmax;

	public float YDbase;

	public float[] Zdiag;

	public Analysis ()
	{
		Sol = new Solution[4];
		ZPt = new float[3];
		Initialize ();
	}

	public void Initialize ()
	{
		Filename = string.Empty;
		RevDate = DateAndTime.Now;
		RevBy = CFS.User.Name;
		Description = string.Empty;
		Project = string.Empty;
		Vertical = false;
		BucklingTheory = CFS.blnBucklingTheory;
		Torsion = false;
		AppVer = -1;
		Saved = false;
		Zmin = 0f;
		Zmax = 0f;
		Beam = new Beam[11];
		BeamGrid = new GridState (1, 1);
		nBeam = 0;
		Sup = new Support[11];
		SupGrid = new GridState (1, 1);
		nSup = 0;
		Ldg = new Loading[2];
		Ldg [0] = new Loading (string.Empty, 10);
		Ldg [1] = new Loading (string.Empty, 10);
		iLdg = 1;
		nLdg = 0;
		Comb = new LoadCombination[2];
		Comb [0] = new LoadCombination (string.Empty, 10);
		Comb [1] = new LoadCombination (string.Empty, 10);
		AllCombos = false;
		iComb = 1;
		nComb = 0;
		iCombSol = 0;
		Notes = string.Empty;
		Zoom = 1;
		ZoomX = 0.5f;
		ZoomY = 0.5f;
		iAnlTab = -1;
		iUndo = -1;
		strUndo = string.Empty;
		strRedo = string.Empty;
	}

	public Analysis Clone ()
	{
		Analysis analysis = (Analysis)MemberwiseClone ();
		checked {
			if (!Information.IsNothing (Beam)) {
				analysis.Beam = new Beam[Information.UBound (Beam) + 1];
				int num = Information.LBound (Beam);
				int num2 = Information.UBound (Beam);
				for (int i = num; i <= num2; i++) {
					analysis.Beam [i] = Beam [i].Clone ();
				}
			}
			if (!Information.IsNothing (Sup)) {
				analysis.Sup = new Support[Information.UBound (Sup) + 1];
				int num3 = Information.LBound (Sup);
				int num4 = Information.UBound (Sup);
				for (int j = num3; j <= num4; j++) {
					analysis.Sup [j] = Sup [j];
				}
			}
			if (!Information.IsNothing (Ldg)) {
				analysis.Ldg = new Loading[Information.UBound (Ldg) + 1];
				int num5 = Information.LBound (Ldg);
				int num6 = Information.UBound (Ldg);
				for (int k = num5; k <= num6; k++) {
					analysis.Ldg [k] = Ldg [k].Clone ();
				}
			}
			if (!Information.IsNothing (Comb)) {
				analysis.Comb = new LoadCombination[Information.UBound (Comb) + 1];
				int num7 = Information.LBound (Comb);
				int num8 = Information.UBound (Comb);
				for (int l = num7; l <= num8; l++) {
					analysis.Comb [l] = Comb [l].Clone ();
				}
			}
			analysis.Sol = new Solution[Information.UBound (Sol) + 1];
			int num9 = Information.LBound (Sol);
			int num10 = Information.UBound (Sol);
			for (int m = num9; m <= num10; m++) {
				if (!Information.IsNothing (Sol [m])) {
					analysis.Sol [m] = Sol [m].Clone ();
				}
			}
			analysis.ZPt = (float[])ZPt.Clone ();
			if (!Information.IsNothing (Rdiag)) {
				analysis.Rdiag = (float[])Rdiag.Clone ();
			}
			if (!Information.IsNothing (Rdiag2)) {
				analysis.Rdiag2 = (float[])Rdiag2.Clone ();
			}
			if (!Information.IsNothing (Vdiag)) {
				analysis.Vdiag = (float[])Vdiag.Clone ();
			}
			if (!Information.IsNothing (Vdiag2)) {
				analysis.Vdiag2 = (float[])Vdiag2.Clone ();
			}
			if (!Information.IsNothing (Mdiag)) {
				analysis.Mdiag = (float[])Mdiag.Clone ();
			}
			if (!Information.IsNothing (Mdiag2)) {
				analysis.Mdiag2 = (float[])Mdiag2.Clone ();
			}
			if (!Information.IsNothing (Ddiag)) {
				analysis.Ddiag = (float[])Ddiag.Clone ();
			}
			if (!Information.IsNothing (Ddiag2)) {
				analysis.Ddiag2 = (float[])Ddiag2.Clone ();
			}
			if (!Information.IsNothing (Zdiag)) {
				analysis.Zdiag = (float[])Zdiag.Clone ();
			}
			return analysis;
		}
	}

	public void Analyze (ref string strMsg, bool blnCheckLicense = true)
	{
		short[] array = new short[5];
		strMsg = string.Empty;
		iCombSol = 0;
		if (blnCheckLicense && !CFS.CheckLicense ()) {
			strMsg += "License is no longer available.\r\n";
			return;
		}
		if (nBeam == 0) {
			strMsg += "Members not defined.\r\n";
			return;
		}
		if (nSup == 0) {
			strMsg += "Supports not defined.\r\n";
			return;
		}
		float num = (float)(1E-06 * CFS.Max (System.Math.Abs (Zmin), System.Math.Abs (Zmax), Zmax - Zmin));
		short num2 = nBeam;
		checked {
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				int num4 = num3 + 1;
				int num5 = nBeam;
				for (int i = num4; i <= num5; i++) {
					if (System.Math.Abs (Beam [num3].Z0 - Beam [i].Z0) <= num) {
						Beam [i].Z0 = Beam [num3].Z0;
						break;
					}
					if (System.Math.Abs (Beam [num3].Z1 - Beam [i].Z0) <= num) {
						Beam [i].Z0 = Beam [num3].Z1;
						break;
					}
				}
				int num6 = num3 + 1;
				int num7 = nBeam;
				for (int j = num6; j <= num7; j++) {
					if (System.Math.Abs (Beam [num3].Z0 - Beam [j].Z1) <= num) {
						Beam [j].Z1 = Beam [num3].Z0;
						break;
					}
					if (System.Math.Abs (Beam [num3].Z1 - Beam [j].Z1) <= num) {
						Beam [j].Z1 = Beam [num3].Z1;
						break;
					}
				}
			}
			short num8 = nSup;
			for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
				short num10 = nBeam;
				for (short num3 = 1; num3 <= num10; num3 = (short)unchecked(num3 + 1)) {
					if (System.Math.Abs (Beam [num3].Z0 - Sup [num9].Z) <= num) {
						Sup [num9].Z = Beam [num3].Z0;
						break;
					}
					if (System.Math.Abs (Beam [num3].Z1 - Sup [num9].Z) <= num) {
						Sup [num9].Z = Beam [num3].Z1;
						break;
					}
				}
			}
			float z = Beam [1].Z1;
			short num11 = nBeam;
			for (short num3 = 2; num3 <= num11; num3 = (short)unchecked(num3 + 1)) {
				if (Beam [num3].Z0 > z) {
					strMsg = strMsg + "Gap before member " + Conversions.ToString (unchecked((int)num3)) + ".\r\n";
					return;
				}
				if (Beam [num3].Z1 > z) {
					z = Beam [num3].Z1;
				}
			}
			if (Sup [1].Z < Beam [1].Z0) {
				strMsg += "First support not on member.\r\n";
				return;
			}
			if (Sup [nSup].Z > z) {
				strMsg += "Last support not on member.\r\n";
				return;
			}
			z = float.MinValue;
			short num12 = 0;
			array [1] = 0;
			array [2] = 0;
			array [4] = 0;
			short num13 = nSup;
			for (short num9 = 1; num9 <= num13; num9 = (short)unchecked(num9 + 1)) {
				if ((Sup [num9].Type & 1) == 1) {
					array [1]++;
				}
				if ((Sup [num9].Type & 2) == 2) {
					array [2]++;
				}
				if ((Sup [num9].Type & 4) == 4) {
					array [4]++;
				}
				if (((Sup [num9].Type & 0x18) > 0) & (Sup [num9].Z > Zmin) & (Sup [num9].Z < Zmax)) {
					strMsg += "Rotational restraint not allowed between ends.\r\n";
					return;
				}
				if ((Sup [num9].Type & 0x60) > 0 && ((Sup [num9].Z <= Sup [1].Z) | (Sup [num9].Z >= Sup [nSup].Z))) {
					strMsg += "Hinge supports must be between end supports.\r\n";
					return;
				}
				unchecked {
					if (Sup [num9].Z == z) {
						if ((Sup [num9].Type & num12) > 0) {
							strMsg = strMsg + "Support " + Conversions.ToString ((int)num9) + " contains a duplicate definition.\r\n";
							return;
						}
						num12 = (short)(num12 | Sup [num9].Type);
					} else {
						z = Sup [num9].Z;
						num12 = Sup [num9].Type;
					}
				}
			}
			if (array [1] == 0) {
				strMsg += "No X supports defined.\r\n";
			}
			if (array [2] == 0) {
				strMsg += "No Y supports defined.\r\n";
			}
			if (array [4] == 0) {
				strMsg += "No T supports defined.\r\n";
			}
			if (Strings.Len (strMsg) > 0) {
				return;
			}
			Sol [1] = new Solution {
				nLoad = 0
			};
			Sol [2] = new Solution {
				nLoad = 0
			};
			Sol [3] = new Solution {
				nLoad = 0
			};
			short nLF = Comb [iComb].nLF;
			for (short num14 = 1; num14 <= nLF; num14 = (short)unchecked(num14 + 1)) {
				short num15 = Comb [iComb].LF [num14].iLdg;
				if (Comb [iComb].LF [num14].fLdg != 0f) {
					if (num15 == 0) {
						ref short nLoad = ref Sol [1].nLoad;
						nLoad = (short)unchecked(nLoad + nBeam);
					} else {
						short nLoad2 = Ldg [num15].nLoad;
						for (short num16 = 1; num16 <= nLoad2; num16 = (short)unchecked(num16 + 1)) {
							float z2 = Ldg [num15].Load [num16].Z0;
							float z3 = Ldg [num15].Load [num16].Z1;
							float w = Ldg [num15].Load [num16].W0;
							float w2 = Ldg [num15].Load [num16].W1;
							if (Ldg [num15].Load [num16].Type == 4) {
								if (unchecked(System.Math.Abs (System.Math.Sin (Ldg [num15].Load [num16].Ang)) > 1E-05 && w != 0f)) {
									Sol [1].nLoad++;
								}
								if (unchecked(System.Math.Abs (System.Math.Cos (Ldg [num15].Load [num16].Ang)) > 1E-05 && w != 0f)) {
									Sol [2].nLoad++;
								}
							} else if (Ldg [num15].Load [num16].Type == 3) {
								if (unchecked(w != 0f && z3 > z2)) {
									Sol [3].nLoad++;
									Sol [1].nLoad++;
									Sol [2].nLoad++;
								}
							} else if (Ldg [num15].Load [num16].Type == 2) {
								if (unchecked(System.Math.Abs (System.Math.Sin (Ldg [num15].Load [num16].Ang)) > 1E-05 && w != 0f)) {
									Sol [1].nLoad++;
								}
								if (unchecked(System.Math.Abs (System.Math.Cos (Ldg [num15].Load [num16].Ang)) > 1E-05 && w != 0f)) {
									Sol [2].nLoad++;
								}
							} else if (unchecked(z3 > z2 && (w != 0f || w2 != 0f))) {
								if (System.Math.Abs (System.Math.Sin (Ldg [num15].Load [num16].Ang)) > 1E-05) {
									Sol [1].nLoad++;
								}
								if (System.Math.Abs (System.Math.Cos (Ldg [num15].Load [num16].Ang)) > 1E-05) {
									Sol [2].nLoad++;
								}
							}
							unchecked {
								if (((z2 < Zmin) | (z3 > Zmax)) && (w != 0f || w2 != 0f)) {
									strMsg = strMsg + "Loading " + Ldg [num15].Description + ", load " + Conversions.ToString ((int)num16) + " not on member.\r\n";
									return;
								}
							}
						}
					}
				}
			}
			if ((short)unchecked(checked((short)unchecked(Sol [1].nLoad + Sol [2].nLoad)) + Sol [3].nLoad) == 0) {
				strMsg += "No loads applied.\r\n";
				return;
			}
			short num17 = 0;
			Ldg [0].nLoad = nBeam;
			Ldg [0].Load = new Load[unchecked((int)nBeam) + 1];
			short num18 = nBeam;
			for (short num3 = 1; num3 <= num18; num3 = (short)unchecked(num3 + 1)) {
				unchecked {
					if (Beam [num3].Z0 == Beam [num3].Z1) {
						strMsg = strMsg + "Member " + Conversions.ToString ((int)num3) + " has no length.\r\n";
						return;
					}
					if (Beam [num3].iSct == 0) {
						strMsg = strMsg + "Member " + Conversions.ToString ((int)num3) + " section file not open.\r\n";
						return;
					}
					if (Beam [num3].iSct != num17) {
						num17 = Beam [num3].iSct;
						CFS.Sections [Beam [num3].iSct].CalcProperties (ref strMsg, blnCheckLicense: false);
						if (!CFS.Sections [Beam [num3].iSct].SctProp) {
							if (Strings.Len (strMsg) == 0) {
								strMsg = "Error calculating properties for " + CFS.Sections [Beam [num3].iSct].Filename + ".\r\n";
							}
							return;
						}
					}
					Ldg [0].Load [num3].Type = 1;
					Ldg [0].Load [num3].Ang = (float)System.Math.PI / 2f;
					Ldg [0].Load [num3].Z0 = Beam [num3].Z0;
					Ldg [0].Load [num3].Z1 = Beam [num3].Z1;
					Ldg [0].Load [num3].W0 = 0f - CFS.Sections [Beam [num3].iSct].Prop.Weight;
					if (Vertical) {
						Ldg [0].Load [num3].W0 = 0f;
					}
					Ldg [0].Load [num3].W1 = Ldg [0].Load [num3].W0;
					Ldg [0].Load [num3].Wid = 0f;
					ref Beam reference = ref Beam [num3];
					reference.EI [1] = CFS.Sections [reference.iSct].Material.Eo [2] * CFS.Sections [reference.iSct].Prop.Ix;
					reference.EI [2] = CFS.Sections [reference.iSct].Material.Eo [2] * CFS.Sections [reference.iSct].Prop.Iy;
					reference.EI [3] = CFS.Sections [reference.iSct].Material.Eo [2] * CFS.Sections [reference.iSct].Prop.A;
				}
			}
			if (Sol [1].nLoad > 0) {
				Nodes (1, 2, 8, 32);
				LoadPoints (1);
				BeamStiffness (1);
				Sol [1].SolveBeam ();
				if (Sol [1].nNode == 0) {
					strMsg += "Inadequate Y support.\r\n";
					return;
				}
			}
			if (Sol [2].nLoad > 0) {
				Nodes (2, 1, 16, 64);
				LoadPoints (2);
				BeamStiffness (2);
				Sol [2].SolveBeam ();
				if (Sol [2].nNode == 0) {
					strMsg += "Inadequate X support.\r\n";
					return;
				}
			}
			if (Sol [3].nLoad > 0) {
				Solution solution = Sol [3];
				solution.Znode = new float[2 * unchecked((int)nBeam) + 1];
				solution.nNode = 0;
				short num19 = nBeam;
				for (short num3 = 1; num3 <= num19; num3 = (short)unchecked(num3 + 1)) {
					float z4 = Beam [num3].Z0;
					short nNode = solution.nNode;
					short num20 = 1;
					while (num20 <= nNode && solution.Znode [num20] != z4) {
						num20 = (short)unchecked(num20 + 1);
					}
					if (num20 > solution.nNode) {
						solution.nNode++;
						solution.Znode [solution.nNode] = z4;
					}
					z4 = Beam [num3].Z1;
					short nNode2 = solution.nNode;
					num20 = 1;
					while (num20 <= nNode2 && solution.Znode [num20] != z4) {
						num20 = (short)unchecked(num20 + 1);
					}
					if (num20 > solution.nNode) {
						solution.nNode++;
						solution.Znode [solution.nNode] = z4;
					}
				}
				short num21 = (short)(solution.nNode - 1);
				for (short num20 = 1; num20 <= num21; num20 = (short)unchecked(num20 + 1)) {
					if (solution.Znode [num20] > solution.Znode [num20 + 1]) {
						CFS.Swap (ref Sol [3].Znode [num20], ref Sol [3].Znode [num20 + 1]);
						if (num20 > 1) {
							num20 = (short)(num20 - 2);
						}
					}
				}
				solution = null;
				LoadPoints (3);
				BeamStiffness (3);
			}
			if ((short)unchecked(checked((short)unchecked(Sol [1].nLoad + Sol [2].nLoad)) + Sol [3].nLoad) == 0) {
				strMsg += "All loads net to zero.\r\n";
			} else {
				iCombSol = iComb;
			}
		}
	}

	public void AnalyzeTorsion (ref string strMsg, bool blnCheckLicense = true)
	{
		strMsg = string.Empty;
		if (blnCheckLicense && !CFS.CheckLicense ()) {
			strMsg += "License is no longer available.\r\n";
			return;
		}
		int nLF = Comb [iComb].nLF;
		checked {
			short num2 = default(short);
			for (int i = 1; i <= nLF; i++) {
				short num = Comb [iComb].LF [i].iLdg;
				float fLdg = Comb [iComb].LF [i].fLdg;
				if (fLdg == 0f) {
					continue;
				}
				if (num == 0) {
					if (!Vertical) {
						num2 = (short)unchecked(num2 + nBeam);
					}
					continue;
				}
				int nLoad = Ldg [num].nLoad;
				for (int j = 1; j <= nLoad; j++) {
					if ((Ldg [num].Load [j].W0 != 0f) | (Ldg [num].Load [j].W1 != 0f)) {
						if ((Ldg [num].Load [j].Type == 1) & (Ldg [num].Load [j].Z1 > Ldg [num].Load [j].Z0)) {
							num2 = (short)(num2 + 1);
						}
						if (Ldg [num].Load [j].Type == 2) {
							num2 = (short)(num2 + 1);
						}
						if (Ldg [num].Load [j].Type == 4) {
							num2 = (short)(num2 + 1);
						}
						if ((Ldg [num].Load [j].Type == 3) & (Ldg [num].Load [j].Z1 > Ldg [num].Load [j].Z0)) {
							num2 = (short)(num2 + 1);
						}
						if ((Ldg [num].Load [j].Z0 < Zmin) | (Ldg [num].Load [j].Z1 > Zmax)) {
							strMsg = strMsg + "Loading " + Ldg [num].Description + ", load " + Conversions.ToString (j) + " not on member.\r\n";
							return;
						}
					}
				}
			}
			if (num2 == 0) {
				strMsg += "No torsion loads applied.\r\n";
				return;
			}
			Ldg [0].nLoad = nBeam;
			Ldg [0].Load = new Load[unchecked((int)nBeam) + 1];
			int num3 = nBeam;
			short iSct = default(short);
			for (int k = 1; k <= num3; k++) {
				if (Beam [k].iSct != iSct) {
					iSct = Beam [k].iSct;
					CFS.Sections [Beam [k].iSct].CalcProperties (ref strMsg, blnCheckLicense: false);
					if (!CFS.Sections [Beam [k].iSct].SctProp) {
						if (Strings.Len (strMsg) == 0) {
							strMsg = "Error calculating properties for " + CFS.Sections [Beam [k].iSct].Filename + ".\r\n";
						}
						return;
					}
				}
				Ldg [0].Load [k].Type = 1;
				Ldg [0].Load [k].Ang = (float)System.Math.PI / 2f;
				Ldg [0].Load [k].Z0 = Beam [k].Z0;
				Ldg [0].Load [k].Z1 = Beam [k].Z1;
				Ldg [0].Load [k].W0 = 0f - CFS.Sections [Beam [k].iSct].Prop.Weight;
				if (Vertical) {
					Ldg [0].Load [k].W0 = 0f;
				}
				Ldg [0].Load [k].W1 = Ldg [0].Load [k].W0;
				Ldg [0].Load [k].Wid = 0f;
				ref Beam reference = ref Beam [k];
				reference.GJ = CFS.Sections [reference.iSct].Material.Eo [5] * CFS.Sections [reference.iSct].Prop.J;
				reference.ECw = CFS.Sections [reference.iSct].Material.Eo [2] * CFS.Sections [reference.iSct].Prop.Cw;
			}
			Tseg = new TorsionSegment[2 * unchecked((int)nBeam) + unchecked((int)nSup) + 2 * num2 + 1];
			nTseg = 0;
			int num4 = nBeam;
			for (int l = 1; l <= num4; l++) {
				float z = Beam [l].Z0;
				short num5 = nTseg;
				short num6 = 1;
				while (num6 <= num5 && Tseg [num6].Z != z) {
					num6 = (short)unchecked(num6 + 1);
				}
				if (num6 > nTseg) {
					nTseg++;
					Tseg [num6].Z = z;
				}
				z = Beam [l].Z1;
				short num7 = nTseg;
				num6 = 1;
				while (num6 <= num7 && Tseg [num6].Z != z) {
					num6 = (short)unchecked(num6 + 1);
				}
				if (num6 > nTseg) {
					nTseg++;
					Tseg [num6].Z = z;
				}
			}
			int num8 = nSup;
			for (int m = 1; m <= num8; m++) {
				if ((Sup [m].Type & 0x64) > 0) {
					float z = Sup [m].Z;
					short num9 = nTseg;
					short num6 = 1;
					while (num6 <= num9 && Tseg [num6].Z != z) {
						num6 = (short)unchecked(num6 + 1);
					}
					if (num6 > nTseg) {
						nTseg++;
						Tseg [num6].Z = z;
					}
				}
			}
			int nLF2 = Comb [iComb].nLF;
			for (int n = 1; n <= nLF2; n++) {
				short num = Comb [iComb].LF [n].iLdg;
				float fLdg = Comb [iComb].LF [n].fLdg;
				if (!unchecked(fLdg != 0f && num != 0)) {
					continue;
				}
				int nLoad2 = Ldg [num].nLoad;
				for (int num10 = 1; num10 <= nLoad2; num10++) {
					if (!((Ldg [num].Load [num10].W0 != 0f) | (Ldg [num].Load [num10].W1 != 0f))) {
						continue;
					}
					float z2 = Ldg [num].Load [num10].Z0;
					float z3 = Ldg [num].Load [num10].Z1;
					if (unchecked(((Ldg [num].Load [num10].Type == 1) | (Ldg [num].Load [num10].Type == 3)) && z3 > z2)) {
						short num11 = nTseg;
						short num6 = 1;
						while (num6 <= num11 && Tseg [num6].Z != z2) {
							num6 = (short)unchecked(num6 + 1);
						}
						if (num6 > nTseg) {
							nTseg++;
							Tseg [num6].Z = z2;
						}
						short num12 = nTseg;
						num6 = 1;
						while (num6 <= num12 && Tseg [num6].Z != z3) {
							num6 = (short)unchecked(num6 + 1);
						}
						if (num6 > nTseg) {
							nTseg++;
							Tseg [num6].Z = z3;
						}
					} else if ((Ldg [num].Load [num10].Type == 2) | (Ldg [num].Load [num10].Type == 4)) {
						short num13 = nTseg;
						short num6 = 1;
						while (num6 <= num13 && Tseg [num6].Z != z2) {
							num6 = (short)unchecked(num6 + 1);
						}
						if (num6 > nTseg) {
							nTseg++;
							Tseg [num6].Z = z2;
						}
					}
				}
			}
			short num14 = (short)(nTseg - 1);
			for (short num6 = 1; num6 <= num14; num6 = (short)unchecked(num6 + 1)) {
				if (Tseg [num6].Z > Tseg [num6 + 1].Z) {
					ref TorsionSegment reference2 = ref Tseg [num6];
					object A = reference2;
					ref TorsionSegment reference3 = ref Tseg [num6 + 1];
					object B = reference3;
					CFS.Swap (ref A, ref B);
					object obj = B;
					reference3 = ((obj != null) ? ((TorsionSegment)obj) : default(TorsionSegment));
					object obj2 = A;
					reference2 = ((obj2 != null) ? ((TorsionSegment)obj2) : default(TorsionSegment));
					if (num6 > 1) {
						num6 = (short)(num6 - 2);
					}
				}
			}
			nTseg--;
			List<byte> list = new List<byte> ();
			short num15 = nTseg;
			float num30 = default(float);
			float num31 = default(float);
			for (short num6 = 1; num6 <= num15; num6 = (short)unchecked(num6 + 1)) {
				List<byte> list2 = new List<byte> ();
				int num16 = nBeam;
				for (int num17 = 1; num17 <= num16; num17++) {
					if ((Beam [num17].Z0 <= Tseg [num6].Z) & (Beam [num17].Z1 >= Tseg [num6 + 1].Z)) {
						list2.Add (Beam [num17].iSct);
						Tseg [num6].GJ += Beam [num17].GJ;
						Tseg [num6].ECw += Beam [num17].ECw;
					}
				}
				Tseg [num6].ReleaseWarping = true;
				foreach (byte item in list2) {
					if (list.Contains (item)) {
						Tseg [num6].ReleaseWarping = false;
						break;
					}
				}
				list = list2;
				ref TorsionSegment reference4 = ref Tseg [num6];
				reference4.L = Tseg [num6 + 1].Z - reference4.Z;
				reference4.NoWarping = false;
				reference4.WarpingOnly = false;
				if (reference4.ECw < reference4.GJ * reference4.L * reference4.L / 256f) {
					reference4.NoWarping = true;
				}
				if (reference4.GJ < reference4.ECw / (256f * reference4.L * reference4.L)) {
					reference4.WarpingOnly = true;
				}
				float z3 = Zmin;
				int num18 = nSup;
				for (int num19 = 1; num19 <= num18; num19++) {
					if (((Sup [num19].Type & 4) == 4) & (Sup [num19].Z <= Tseg [num6].Z)) {
						Tseg [num6].Braced = Sup [num19].K == 0f;
					}
					if (((Sup [num19].Type & 4) == 4) & (Sup [num19].Z > Tseg [num6].Z) & (z3 == Zmin)) {
						z3 = Sup [num19].Z;
					}
					if (Sup [num19].Z == Tseg [num6].Z) {
						Tseg [num6].Sup0 = unchecked((byte)(Tseg [num6].Sup0 | Sup [num19].Type));
					}
					if (Sup [num19].Z == Tseg [num6 + 1].Z) {
						Tseg [num6].SupL = unchecked((byte)(Tseg [num6].SupL | Sup [num19].Type));
					}
				}
				if (Tseg [num6].Braced & (z3 == Zmin)) {
					Tseg [num6].Braced = false;
				}
				float num20 = 0f;
				float num21 = 0f;
				float num22 = 0f;
				int num23 = nBeam;
				for (int num24 = 1; num24 <= num23; num24++) {
					if ((Beam [num24].Z0 <= Tseg [num6].Z) & (Beam [num24].Z1 >= Tseg [num6 + 1].Z)) {
						float num25 = (float)((double)Beam [num24].GJ + (double)Beam [num24].ECw / System.Math.Pow (Tseg [num6].L, 2.0));
						num20 += num25;
						num21 += num25 * (Beam [num24].ex - (CFS.Sections [Beam [num24].iSct].Prop.Xcg + CFS.Sections [Beam [num24].iSct].Prop.Xo));
						num22 += num25 * (Beam [num24].ey - (CFS.Sections [Beam [num24].iSct].Prop.Ycg + CFS.Sections [Beam [num24].iSct].Prop.Yo));
						if (Beam [num24].iBrcFlg != 0) {
							Tseg [num6].Braced = true;
						}
					}
				}
				if (num20 > 0f) {
					num21 /= num20;
					num22 /= num20;
				}
				int nLF3 = Comb [iComb].nLF;
				for (int num26 = 1; num26 <= nLF3; num26++) {
					short num = Comb [iComb].LF [num26].iLdg;
					float fLdg = Comb [iComb].LF [num26].fLdg;
					int nLoad3 = Ldg [num].nLoad;
					for (int num27 = 1; num27 <= nLoad3; num27++) {
						float z2 = Ldg [num].Load [num27].Z0;
						z3 = Ldg [num].Load [num27].Z1;
						float ang = Ldg [num].Load [num27].Ang;
						num20 = (float)((double)num21 * System.Math.Sin (ang) - (double)num22 * System.Math.Cos (ang));
						if ((Ldg [num].Load [num27].Type == 1) & (z2 <= Tseg [num6].Z) & (z3 >= Tseg [num6 + 1].Z)) {
							if (num == 0) {
								num20 = 0f - CFS.Sections [Beam [num27].iSct].Prop.Xo;
							}
							float num28 = Ldg [num].Load [num27].W0 * fLdg * num20;
							float num29 = Ldg [num].Load [num27].W1 * fLdg * num20;
							Tseg [num6].W += num28 + (num29 - num28) * (Tseg [num6].Z - z2) / (z3 - z2);
							Tseg [num6].U += (num29 - num28) / (z3 - z2);
						} else if ((Ldg [num].Load [num27].Type == 2) & (z2 == Tseg [num6].Z)) {
							Tseg [num6].T0 += Ldg [num].Load [num27].W0 * fLdg * num20;
						} else if ((Ldg [num].Load [num27].Type == 2) & (num6 == nTseg) & (z2 == Tseg [num6 + 1].Z)) {
							num30 += Ldg [num].Load [num27].W0 * fLdg * num20;
						} else if ((Ldg [num].Load [num27].Type == 4) & (z2 == Tseg [num6].Z)) {
							Tseg [num6].B0 += Ldg [num].Load [num27].W0 * fLdg * num20;
						} else if ((Ldg [num].Load [num27].Type == 4) & (num6 == nTseg) & (z2 == Tseg [num6 + 1].Z)) {
							num31 += Ldg [num].Load [num27].W0 * fLdg * num20;
						} else {
							if (Ldg [num].Load [num27].Type != 3) {
								continue;
							}
							float num25;
							if (z2 == Tseg [num6].Z) {
								num25 = 0f;
								num20 = 0f;
								int num32 = nBeam;
								for (int num33 = 1; num33 <= num32; num33++) {
									if ((Beam [num33].Z0 <= Tseg [num6].Z) & (Beam [num33].Z1 > Tseg [num6].Z)) {
										num25 += Beam [num33].EI [3];
										float num34 = Beam [num33].ex - CFS.Sections [Beam [num33].iSct].Prop.Xcg;
										float num35 = Beam [num33].ey - CFS.Sections [Beam [num33].iSct].Prop.Ycg;
										num20 += Beam [num33].EI [3] * (num35 * (0f - CFS.Sections [Beam [num33].iSct].Prop.Xo) - num34 * (0f - CFS.Sections [Beam [num33].iSct].Prop.Yo));
									}
								}
								if (num25 > 0f) {
									Tseg [num6].B0 += Ldg [num].Load [num27].W0 * fLdg * num20 / num25;
								}
							}
							if (z3 == Tseg [num6].Z) {
								num25 = 0f;
								num20 = 0f;
								int num36 = nBeam;
								for (int num37 = 1; num37 <= num36; num37++) {
									if ((Beam [num37].Z0 < Tseg [num6].Z) & (Beam [num37].Z1 >= Tseg [num6].Z)) {
										num25 += Beam [num37].EI [3];
										float num34 = Beam [num37].ex - CFS.Sections [Beam [num37].iSct].Prop.Xcg;
										float num35 = Beam [num37].ey - CFS.Sections [Beam [num37].iSct].Prop.Ycg;
										num20 += Beam [num37].EI [3] * (num35 * (0f - CFS.Sections [Beam [num37].iSct].Prop.Xo) - num34 * (0f - CFS.Sections [Beam [num37].iSct].Prop.Yo));
									}
								}
								if (num25 > 0f) {
									Tseg [num6].B0 += (0f - Ldg [num].Load [num27].W1) * fLdg * num20 / num25;
								}
							}
							if (!((num6 == nTseg) & (z3 == Tseg [num6 + 1].Z))) {
								continue;
							}
							num25 = 0f;
							num20 = 0f;
							int num38 = nBeam;
							for (int num39 = 1; num39 <= num38; num39++) {
								if ((Beam [num39].Z0 < Tseg [nTseg + 1].Z) & (Beam [num39].Z1 >= Tseg [nTseg + 1].Z)) {
									num25 += Beam [num39].EI [3];
									float num34 = Beam [num39].ex - CFS.Sections [Beam [num39].iSct].Prop.Xcg;
									float num35 = Beam [num39].ey - CFS.Sections [Beam [num39].iSct].Prop.Ycg;
									num20 += Beam [num39].EI [3] * (num35 * (0f - CFS.Sections [Beam [num39].iSct].Prop.Xo) - num34 * (0f - CFS.Sections [Beam [num39].iSct].Prop.Yo));
								}
							}
							if (num25 > 0f) {
								num31 += (0f - Ldg [num].Load [num27].W1) * fLdg * num20 / num25;
							}
						}
					}
				}
			}
			ref TorsionSegment[] tseg = ref Tseg;
			tseg = (TorsionSegment[])Utils.CopyArray (tseg, new TorsionSegment[nTseg + 1]);
			double[,] array = new double[4 * nTseg + 1, 4 * nTseg + 1];
			short num40 = 0;
			short num41 = nTseg;
			short num42 = default(short);
			for (short num6 = 1; num6 <= num41; num6 = (short)unchecked(num6 + 1)) {
				float l2 = Tseg [num6].L;
				float w = Tseg [num6].W;
				float u = Tseg [num6].U;
				float t = Tseg [num6].T0;
				float b = Tseg [num6].B0;
				float gJ = Tseg [num6].GJ;
				float eCw = Tseg [num6].ECw;
				if (!Tseg [num6].Braced) {
					if (Tseg [num6].NoWarping) {
						if (num6 == 1) {
							if ((Tseg [num6].Sup0 & 4) == 4) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, 0] = (0f - b) / gJ;
							} else {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = u * eCw / gJ + t;
							}
						} else if (((Tseg [num6].Sup0 & 4) == 4) | Tseg [num6 - 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, 0] = (0f - b) / gJ;
						} else {
							short num43 = (short)(num42 - 1);
							array [num43, num40 + 1] -= 1.0;
							array [num43, 0] -= (0f - b) / gJ;
							num43 = (short)(num42 - 0);
							array [num43, num40 + 2] -= 0f - gJ;
							array [num43, 0] -= u * eCw / gJ + t;
						}
						if (num6 == nTseg) {
							if ((Tseg [num6].SupL & 4) == 4) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 2] = l2;
								array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0 + (double)num31) / (double)gJ;
							} else {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f + num30) + u * eCw / gJ;
							}
						} else if (((Tseg [num6].SupL & 4) == 4) | Tseg [num6 + 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
						} else {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 0f - gJ;
							array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f) + u * eCw / gJ;
						}
						num40 = (short)(num40 + 2);
					} else if (Tseg [num6].WarpingOnly) {
						if (num6 == 1) {
							switch (Tseg [num6].Sup0 & 0x1C) {
							case 0:
							case 8:
							case 16:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2.0;
								array [num42, 0] = b / eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = 6f * eCw;
								array [num42, 0] = t;
								break;
							case 28:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, 0] = 0.0;
								break;
							case 4:
							case 12:
							case 20:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2.0;
								array [num42, 0] = b / eCw;
								break;
							case 24:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = 6f * eCw;
								array [num42, 0] = t;
								break;
							}
						} else if (Tseg [num6 - 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, 0] = 0.0;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 1.0;
							array [num42, 0] = 0.0;
						} else if ((Tseg [num6].Sup0 & 4) == 4) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, 0] = 0.0;
							if (Tseg [num6 - 1].NoWarping | ((Tseg [num6].Sup0 & 0x60) > 0) | Tseg [num6].ReleaseWarping) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2f * eCw;
								array [num42, 0] = b;
							} else {
								short num43 = (short)(num42 - 2);
								array [num43, num40 + 2] -= gJ;
								array [num43, 0] -= 0.0;
								num43 = (short)(num42 - 1);
								array [num43, num40 + 3] -= 2f * eCw;
								array [num43, 0] -= b;
							}
						} else if (Tseg [num6 - 1].NoWarping | ((Tseg [num6].Sup0 & 0x60) > 0) | Tseg [num6].ReleaseWarping) {
							short num43 = (short)(num42 - 1);
							array [num43, num40 + 1] -= 1.0;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 0);
							array [num43, num40 + 4] -= 6f * eCw;
							array [num43, 0] -= t;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 3] = 2f * eCw;
							array [num42, 0] = b;
						} else {
							short num43 = (short)(num42 - 3);
							array [num43, num40 + 1] -= 1.0;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 2);
							array [num43, num40 + 2] -= gJ;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 1);
							array [num43, num40 + 3] -= 2f * eCw;
							array [num43, 0] -= b;
							num43 = (short)(num42 - 0);
							array [num43, num40 + 4] -= 6f * eCw;
							array [num43, 0] -= t;
						}
						if (num6 == nTseg) {
							switch (Tseg [num6].SupL & 0x1C) {
							case 0:
							case 8:
							case 16:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2.0;
								array [num42, num40 + 4] = 6f * l2;
								array [num42, 0] = (0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0 + (double)num31)) / (double)eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = 6f * eCw;
								array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f + num30);
								break;
							case 28:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 2] = l2;
								array [num42, num40 + 3] = l2 * l2;
								array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
								array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = 2f * l2;
								array [num42, num40 + 4] = 3f * l2 * l2;
								array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 3.0) / 6.0 + (double)u * System.Math.Pow (l2, 4.0) / 24.0)) / (double)eCw;
								break;
							case 4:
							case 12:
							case 20:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 2] = l2;
								array [num42, num40 + 3] = l2 * l2;
								array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
								array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2.0;
								array [num42, num40 + 4] = 6f * l2;
								array [num42, 0] = (0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0 + (double)num31)) / (double)eCw;
								break;
							case 24:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = 2f * l2;
								array [num42, num40 + 4] = 3f * l2 * l2;
								array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 3.0) / 6.0 + (double)u * System.Math.Pow (l2, 4.0) / 24.0)) / (double)eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = 6f * eCw;
								array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f + num30);
								break;
							}
						} else if (Tseg [num6 + 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = l2 * l2;
							array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 1.0;
							array [num42, num40 + 3] = 2f * l2;
							array [num42, num40 + 4] = 3f * l2 * l2;
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 3.0) / 6.0 + (double)u * System.Math.Pow (l2, 4.0) / 24.0)) / (double)eCw;
						} else if ((Tseg [num6].SupL & 4) == 4) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = l2 * l2;
							array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
							if (Tseg [num6 + 1].NoWarping | ((Tseg [num6].SupL & 0x60) > 0) | Tseg [num6 + 1].ReleaseWarping) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2f * eCw;
								array [num42, num40 + 4] = 6f * l2 * eCw;
								array [num42, 0] = 0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0);
							} else {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = gJ;
								array [num42, num40 + 3] = 2f * gJ * l2;
								array [num42, num40 + 4] = 3f * gJ * l2 * l2;
								array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 3.0) / 6.0 + (double)u * System.Math.Pow (l2, 4.0) / 24.0)) * (double)gJ / (double)eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = 2f * eCw;
								array [num42, num40 + 4] = 6f * l2 * eCw;
								array [num42, 0] = 0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0);
							}
						} else if (Tseg [num6 + 1].NoWarping | ((Tseg [num6].SupL & 0x60) > 0) | Tseg [num6 + 1].ReleaseWarping) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 3] = 2f * eCw;
							array [num42, num40 + 4] = 6f * l2 * eCw;
							array [num42, 0] = 0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0);
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = l2 * l2;
							array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 4] = 6f * eCw;
							array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f);
						} else {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = l2 * l2;
							array [num42, num40 + 4] = System.Math.Pow (l2, 3.0);
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 4.0) / 24.0 + (double)u * System.Math.Pow (l2, 5.0) / 120.0)) / (double)eCw;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = gJ;
							array [num42, num40 + 3] = 2f * gJ * l2;
							array [num42, num40 + 4] = 3f * gJ * l2 * l2;
							array [num42, 0] = (0.0 - ((double)w * System.Math.Pow (l2, 3.0) / 6.0 + (double)u * System.Math.Pow (l2, 4.0) / 24.0)) * (double)gJ / (double)eCw;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 3] = 2f * eCw;
							array [num42, num40 + 4] = 6f * l2 * eCw;
							array [num42, 0] = 0.0 - ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0);
							num42 = (short)(num42 + 1);
							array [num42, num40 + 4] = 6f * eCw;
							array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f);
						}
						num40 = (short)(num40 + 4);
					} else {
						float num44 = gJ / eCw;
						float num45 = (float)System.Math.Sqrt (num44);
						if (num6 == 1) {
							switch (Tseg [num6].Sup0 & 0x1C) {
							case 0:
							case 8:
							case 16:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = num44;
								array [num42, 0] = w / gJ + b / eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = u / num44 + t;
								break;
							case 28:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 4] = 1.0;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = num45;
								array [num42, 0] = 0.0;
								break;
							case 4:
							case 12:
							case 20:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 4] = 1.0;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = num44;
								array [num42, 0] = w / gJ + b / eCw;
								break;
							case 24:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = num45;
								array [num42, 0] = 0.0;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = u / num44 + t;
								break;
							}
						} else if (Tseg [num6 - 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 4] = 1.0;
							array [num42, 0] = 0.0;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 1.0;
							array [num42, num40 + 3] = num45;
							array [num42, 0] = 0.0;
						} else if ((Tseg [num6].Sup0 & 4) == 4) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 4] = 1.0;
							array [num42, 0] = 0.0;
							if (Tseg [num6 - 1].NoWarping | ((Tseg [num6].Sup0 & 0x60) > 0) | Tseg [num6].ReleaseWarping) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 4] = gJ;
								array [num42, 0] = w / num44 + b;
							} else {
								short num43 = (short)(num42 - 2);
								array [num43, num40 + 2] -= gJ;
								array [num43, num40 + 3] -= gJ * num45;
								array [num43, 0] -= 0.0;
								num43 = (short)(num42 - 1);
								array [num43, num40 + 4] -= gJ;
								array [num43, 0] -= w / num44 + b;
							}
						} else if (Tseg [num6 - 1].NoWarping | ((Tseg [num6].Sup0 & 0x60) > 0) | Tseg [num6].ReleaseWarping) {
							short num43 = (short)(num42 - 1);
							array [num43, num40 + 1] -= 1.0;
							array [num43, num40 + 4] -= 1.0;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 0);
							array [num43, num40 + 2] -= 0f - gJ;
							array [num43, 0] -= u / num44 + t;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 4] = gJ;
							array [num42, 0] = w / num44 + b;
						} else {
							short num43 = (short)(num42 - 3);
							array [num43, num40 + 1] -= 1.0;
							array [num43, num40 + 4] -= 1.0;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 2);
							array [num43, num40 + 2] -= gJ;
							array [num43, num40 + 3] -= gJ * num45;
							array [num43, 0] -= 0.0;
							num43 = (short)(num42 - 1);
							array [num43, num40 + 4] -= gJ;
							array [num43, 0] -= w / num44 + b;
							num43 = (short)(num42 - 0);
							array [num43, num40 + 2] -= 0f - gJ;
							array [num43, 0] -= u / num44 + t;
						}
						double num46 = System.Math.Sinh (num45 * l2);
						double num47 = System.Math.Cosh (num45 * l2);
						if (num6 == nTseg) {
							switch (Tseg [num6].SupL & 0x1C) {
							case 0:
							case 8:
							case 16:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = (double)num44 * num46;
								array [num42, num40 + 4] = (double)num44 * num47;
								array [num42, 0] = (w + u * l2) / gJ - num31 / eCw;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f + num30) + u / num44;
								break;
							case 28:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 2] = l2;
								array [num42, num40 + 3] = num46;
								array [num42, num40 + 4] = num47;
								array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = (double)num45 * num47;
								array [num42, num40 + 4] = (double)num45 * num46;
								array [num42, 0] = (w * l2 + u * l2 * l2 / 2f) / gJ;
								break;
							case 4:
							case 12:
							case 20:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 1] = 1.0;
								array [num42, num40 + 2] = l2;
								array [num42, num40 + 3] = num46;
								array [num42, num40 + 4] = num47;
								array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = (double)num44 * num46;
								array [num42, num40 + 4] = (double)num44 * num47;
								array [num42, 0] = (w + u * l2) / gJ - num31 / eCw;
								break;
							case 24:
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 1.0;
								array [num42, num40 + 3] = (double)num45 * num47;
								array [num42, num40 + 4] = (double)num45 * num46;
								array [num42, 0] = (w * l2 + u * l2 * l2 / 2f) / gJ;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = 0f - gJ;
								array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f + num30) + u / num44;
								break;
							}
						} else if (Tseg [num6 + 1].Braced) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = num46;
							array [num42, num40 + 4] = num47;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 1.0;
							array [num42, num40 + 3] = (double)num45 * num47;
							array [num42, num40 + 4] = (double)num45 * num46;
							array [num42, 0] = (w * l2 + u * l2 * l2 / 2f) / gJ;
						} else if ((Tseg [num6].SupL & 4) == 4) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = num46;
							array [num42, num40 + 4] = num47;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
							if (Tseg [num6 + 1].NoWarping | ((Tseg [num6].SupL & 0x60) > 0) | Tseg [num6 + 1].ReleaseWarping) {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = (double)gJ * num46;
								array [num42, num40 + 4] = (double)gJ * num47;
								array [num42, 0] = (w + u * l2) / num44;
							} else {
								num42 = (short)(num42 + 1);
								array [num42, num40 + 2] = gJ;
								array [num42, num40 + 3] = (double)(gJ * num45) * num47;
								array [num42, num40 + 4] = (double)(gJ * num45) * num46;
								array [num42, 0] = w * l2 + u * l2 * l2 / 2f;
								num42 = (short)(num42 + 1);
								array [num42, num40 + 3] = (double)gJ * num46;
								array [num42, num40 + 4] = (double)gJ * num47;
								array [num42, 0] = (w + u * l2) / num44;
							}
						} else if (Tseg [num6 + 1].NoWarping | ((Tseg [num6].SupL & 0x60) > 0) | Tseg [num6 + 1].ReleaseWarping) {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 3] = (double)gJ * num46;
							array [num42, num40 + 4] = (double)gJ * num47;
							array [num42, 0] = (w + u * l2) / num44;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = num46;
							array [num42, num40 + 4] = num47;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 0f - gJ;
							array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f) + u / num44;
						} else {
							num42 = (short)(num42 + 1);
							array [num42, num40 + 1] = 1.0;
							array [num42, num40 + 2] = l2;
							array [num42, num40 + 3] = num46;
							array [num42, num40 + 4] = num47;
							array [num42, 0] = ((double)(w * l2 * l2 / 2f) + (double)u * System.Math.Pow (l2, 3.0) / 6.0) / (double)gJ;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = gJ;
							array [num42, num40 + 3] = (double)(gJ * num45) * num47;
							array [num42, num40 + 4] = (double)(gJ * num45) * num46;
							array [num42, 0] = w * l2 + u * l2 * l2 / 2f;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 3] = (double)gJ * num46;
							array [num42, num40 + 4] = (double)gJ * num47;
							array [num42, 0] = (w + u * l2) / num44;
							num42 = (short)(num42 + 1);
							array [num42, num40 + 2] = 0f - gJ;
							array [num42, 0] = 0f - (w * l2 + u * l2 * l2 / 2f) + u / num44;
						}
						num40 = (short)(num40 + 4);
					}
				}
			}
			int num48 = num42;
			for (int num49 = 1; num49 <= num48; num49++) {
				double num50 = 0.0;
				int num51 = num42;
				for (int num52 = 1; num52 <= num51; num52++) {
					if (System.Math.Abs (array [num49, num52]) > num50) {
						num50 = System.Math.Abs (array [num49, num52]);
					}
				}
				int num53 = num42;
				for (int num54 = 0; num54 <= num53; num54++) {
					array [num49, num54] /= num50;
				}
			}
			int num55 = num42;
			for (int num56 = 1; num56 <= num55; num56++) {
				short num57 = (short)num56;
				int num58 = num56 + 1;
				int num59 = num42;
				for (int num60 = num58; num60 <= num59; num60++) {
					if (System.Math.Abs (array [num60, num56]) > System.Math.Abs (array [num57, num56])) {
						num57 = (short)num60;
					}
				}
				if (array [num57, num56] == 0.0) {
					strMsg = "Unable to solve torsion distribution.";
					return;
				}
				if (num57 > num56) {
					int num61 = num42;
					for (int num62 = 0; num62 <= num61; num62++) {
						CFS.Swap (ref array [num56, num62], ref array [num57, num62]);
					}
				}
				int num63 = num42;
				for (int num64 = 1; num64 <= num63; num64++) {
					if ((num56 != num64) & (array [num64, num56] != 0.0)) {
						double num65 = array [num64, num56] / array [num56, num56];
						int num66 = num42;
						for (int num67 = 0; num67 <= num66; num67++) {
							array [num64, num67] -= array [num56, num67] * num65;
						}
					}
				}
			}
			int num68 = num42;
			for (int num69 = 1; num69 <= num68; num69++) {
				array [num69, 0] /= array [num69, num69];
			}
			num40 = 0;
			short num70 = nTseg;
			for (short num6 = 1; num6 <= num70; num6 = (short)unchecked(num6 + 1)) {
				if (!Tseg [num6].Braced) {
					if (Tseg [num6].NoWarping) {
						Tseg [num6].C1 = array [num40 + 1, 0];
						Tseg [num6].C2 = array [num40 + 2, 0];
						Tseg [num6].C3 = 0.0;
						Tseg [num6].C4 = 0.0;
						num40 = (short)(num40 + 2);
					} else {
						Tseg [num6].C1 = array [num40 + 1, 0];
						Tseg [num6].C2 = array [num40 + 2, 0];
						Tseg [num6].C3 = array [num40 + 3, 0];
						Tseg [num6].C4 = array [num40 + 4, 0];
						num40 = (short)(num40 + 4);
					}
				}
			}
		}
	}

	public void TorsionMinMax (ref SolutionDetail Det)
	{
		checked {
			Det.R = new float[2 * nTseg + 1];
			Det.V = new float[3 * nTseg + 1];
			Det.M = new float[3 * nTseg + 1];
			Det.D = new float[4 * nTseg + 1];
			Det.ZR = new float[2 * nTseg + 1];
			Det.ZV = new float[3 * nTseg + 1];
			Det.ZM = new float[4 * nTseg + 1];
			Det.ZD = new float[4 * nTseg + 1];
			Det.NR = 0;
			Det.NV = 0;
			Det.NM = 0;
			Det.ND = 0;
			float[] array = new float[3];
			float[] array2 = new float[3];
			float[] array3 = new float[4];
			float[] array4 = new float[5];
			if ((Tseg [1].Sup0 & 4) == 0) {
				Det.ND++;
				Det.D [Det.ND] = Tseg [1].Phi (0f);
				Det.ZD [Det.ND] = Tseg [1].Z;
			}
			if ((Tseg [1].Sup0 & 0x18) == 24) {
				Det.NM++;
				Det.M [Det.NM] = Tseg [1].B (0f);
				Det.ZM [Det.NM] = Tseg [1].Z;
			}
			int num = nTseg;
			for (int i = 1; i <= num; i++) {
				ref TorsionSegment reference = ref Tseg [i];
				float num2 = reference.T (0f);
				if ((reference.Sup0 & 4) == 4) {
					Det.NV++;
					Det.V [Det.NV] = num2;
					Det.ZV [Det.NV] = reference.Z;
					if (Det.NR == 0) {
						Det.NR = 1;
					}
					Det.R [Det.NR] += Det.V [Det.NV];
					Det.ZR [Det.NR] = reference.Z;
				} else if ((reference.T0 != 0f) & (System.Math.Sign (reference.W) != System.Math.Sign (reference.T0))) {
					if (System.Math.Sign (reference.W) != -System.Math.Sign (num2 - reference.T0)) {
						Det.NV++;
						Det.V [Det.NV] = num2 - reference.T0;
						Det.ZV [Det.NV] = reference.Z;
					}
					if (System.Math.Sign (reference.W) != System.Math.Sign (num2)) {
						Det.NV++;
						Det.V [Det.NV] = num2;
						Det.ZV [Det.NV] = reference.Z;
					}
				}
				float num3 = ((reference.U == 0f) ? 0f : ((0f - reference.W) / reference.U));
				if ((num3 > 0f) & (num3 < reference.L)) {
					Det.NV++;
					Det.V [Det.NV] = reference.T (num3);
					Det.ZV [Det.NV] = reference.Z + num3;
				}
				if ((reference.SupL & 4) == 4) {
					Det.NV++;
					Det.V [Det.NV] = reference.T (reference.L);
					Det.ZV [Det.NV] = reference.Z + reference.L;
					Det.NR++;
					Det.R [Det.NR] = 0f - Det.V [Det.NV];
					Det.ZR [Det.NR] = reference.Z + reference.L;
				} else if (i < nTseg && System.Math.Sign (reference.W + reference.U * reference.L) != System.Math.Sign (Tseg [i + 1].W)) {
					Det.NV++;
					Det.V [Det.NV] = reference.T (reference.L);
					Det.ZV [Det.NV] = reference.Z + reference.L;
				}
				if (reference.NoWarping) {
					num2 = reference.Tsv (0f);
					float num4 = reference.Phi (0f);
					if (System.Math.Sign (num2) * System.Math.Sign (reference.B0) < 0) {
						if (System.Math.Sign (num2) == -System.Math.Sign (num4 + reference.B0 / reference.GJ)) {
							Det.ND++;
							Det.D [Det.ND] = num4 + reference.B0 / reference.GJ;
							Det.ZD [Det.ND] = reference.Z;
						}
						if (System.Math.Sign (num2) == System.Math.Sign (num4)) {
							Det.ND++;
							Det.D [Det.ND] = num4;
							Det.ZD [Det.ND] = reference.Z;
						}
					}
					short num5 = 0;
					num3 = ((reference.U == 0f) ? 0f : ((0f - reference.W) / reference.U));
					if ((num3 > 0f) & (num3 < reference.L)) {
						num5 = (short)(num5 + 1);
						array [num5] = num3;
					}
					num5 = (short)(num5 + 1);
					array [num5] = reference.L;
					int num6 = num5;
					for (int j = 1; j <= num6; j++) {
						if (System.Math.Sign (reference.T (array [j - 1])) * System.Math.Sign (reference.T (array [j])) >= 0) {
							continue;
						}
						num3 = array [j - 1] + (array [j] - array [j - 1]) / (1f - reference.T (array [j]) / reference.T (array [j - 1]));
						int num7 = 1;
						do {
							num3 -= reference.T (num3) / reference.dT (num3);
							if (num3 < array [j - 1]) {
								num3 = array [j - 1];
							}
							if (num3 > array [j]) {
								num3 = array [j];
							}
							num7++;
						} while (num7 <= 5);
						Det.ND++;
						Det.D [Det.ND] = reference.Phi (num3);
						Det.ZD [Det.ND] = reference.Z + num3;
					}
					if (i < nTseg && System.Math.Sign (reference.dPhi (reference.L)) != System.Math.Sign (Tseg [i + 1].dPhi (0f))) {
						Det.ND++;
						Det.D [Det.ND] = reference.Phi (reference.L);
						Det.ZD [Det.ND] = reference.Z + reference.L;
					}
					continue;
				}
				num2 = reference.Tw (0f);
				float num8 = reference.B (0f);
				float num9 = ((i <= 1) ? num8 : Tseg [i - 1].B (Tseg [i - 1].L));
				if (unchecked(checked(System.Math.Sign (num2) * System.Math.Sign (reference.B0)) < 0 || (num9 == 0f && num8 != 0f))) {
					if (System.Math.Sign (num2) == System.Math.Sign (num8 - reference.B0)) {
						Det.NM++;
						Det.M [Det.NM] = num8 - reference.B0;
						Det.ZM [Det.NM] = reference.Z;
					}
					if (System.Math.Sign (num2) == -System.Math.Sign (num8)) {
						Det.NM++;
						Det.M [Det.NM] = num8;
						Det.ZM [Det.NM] = reference.Z;
					}
				}
				short num10 = 0;
				if (System.Math.Sign (reference.dTw (0f)) * System.Math.Sign (reference.dTw (reference.L)) < 0) {
					num3 = reference.L / (1f - reference.dTw (reference.L) / reference.dTw (0f));
					int num11 = 1;
					do {
						num3 -= reference.dTw (num3) / reference.d2Tw (num3);
						if (num3 < 0f) {
							num3 = 0f;
						}
						if (num3 > reference.L) {
							num3 = reference.L;
						}
						num11++;
					} while (num11 <= 5);
					num10 = (short)(num10 + 1);
					array2 [num10] = num3;
				}
				num10 = (short)(num10 + 1);
				array2 [num10] = reference.L;
				short num12 = 0;
				int num13 = num10;
				for (int k = 1; k <= num13; k++) {
					if (System.Math.Sign (reference.Tw (array2 [k - 1])) * System.Math.Sign (reference.Tw (array2 [k])) >= 0) {
						continue;
					}
					num3 = reference.L / (1f - reference.Tw (array2 [k]) / reference.Tw (array2 [k - 1]));
					int num14 = 1;
					do {
						num3 -= reference.Tw (num3) / reference.dTw (num3);
						if (num3 < array2 [k - 1]) {
							num3 = array2 [k - 1];
						}
						if (num3 > array2 [k]) {
							num3 = array2 [k];
						}
						num14++;
					} while (num14 <= 5);
					num12 = (short)(num12 + 1);
					array3 [num12] = num3;
					Det.NM++;
					Det.M [Det.NM] = reference.B (num3);
					Det.ZM [Det.NM] = reference.Z + num3;
				}
				if (i < nTseg && System.Math.Sign (reference.Tw (reference.L)) != System.Math.Sign (Tseg [i + 1].Tw (0f))) {
					Det.NM++;
					Det.M [Det.NM] = reference.B (reference.L);
					Det.ZM [Det.NM] = reference.Z + reference.L;
				}
				num12 = (short)(num12 + 1);
				array3 [num12] = reference.L;
				short num15 = 0;
				int num16 = num12;
				for (int l = 1; l <= num16; l++) {
					if (System.Math.Sign (reference.B (array3 [l - 1])) * System.Math.Sign (reference.B (array3 [l])) >= 0) {
						continue;
					}
					num3 = array3 [l - 1] + (array3 [l] - array3 [l - 1]) / (1f - reference.B (array3 [l]) / reference.B (array3 [l - 1]));
					int num17 = 1;
					do {
						num3 -= reference.B (num3) / reference.dB (num3);
						if (num3 < array3 [l - 1]) {
							num3 = array3 [l - 1];
						}
						if (num3 > array3 [l]) {
							num3 = array3 [l];
						}
						num17++;
					} while (num17 <= 5);
					num15 = (short)(num15 + 1);
					array4 [num15] = num3;
				}
				num15 = (short)(num15 + 1);
				array4 [num15] = reference.L;
				int num18 = num15;
				for (int m = 1; m <= num18; m++) {
					if (System.Math.Sign (reference.dPhi (array4 [m - 1])) * System.Math.Sign (reference.dPhi (array4 [m])) >= 0) {
						continue;
					}
					num3 = array4 [m - 1] + (array4 [m] - array4 [m - 1]) / (1f - reference.dPhi (array4 [m]) / reference.dPhi (array4 [m - 1]));
					int num19 = 1;
					do {
						num3 -= reference.dPhi (num3) / reference.d2Phi (num3);
						if (num3 < array4 [m - 1]) {
							num3 = array4 [m - 1];
						}
						if (num3 > array4 [m]) {
							num3 = array4 [m];
						}
						num19++;
					} while (num19 <= 5);
					Det.ND++;
					Det.D [Det.ND] = reference.Phi (num3);
					Det.ZD [Det.ND] = reference.Z + num3;
				}
				if (i < nTseg && System.Math.Sign (reference.dPhi (reference.L)) != System.Math.Sign (Tseg [i + 1].dPhi (0f))) {
					Det.ND++;
					Det.D [Det.ND] = reference.Phi (reference.L);
					Det.ZD [Det.ND] = reference.Z + reference.L;
				}
			}
			if ((Tseg [nTseg].SupL & 4) == 0) {
				Det.ND++;
				Det.D [Det.ND] = Tseg [nTseg].Phi (Tseg [nTseg].L);
				Det.ZD [Det.ND] = Tseg [nTseg].Z + Tseg [nTseg].L;
			}
			if ((Tseg [nTseg].SupL & 0x18) == 24) {
				Det.NM++;
				Det.M [Det.NM] = Tseg [nTseg].B (Tseg [nTseg].L);
				Det.ZM [Det.NM] = Tseg [nTseg].Z + Tseg [nTseg].L;
			}
		}
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool Load (string strFileName, ref string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		int num3 = default(int);
		short Value2 = default(short);
		int Value3 = default(int);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked {
					switch (try0000_dispatch) {
					default: {
						ProjectData.ClearProjectError ();
						num2 = 2;
						result = false;
						Report = string.Empty;
						Filename = strFileName;
						num3 = FileSystem.FreeFile ();
						if (FileSystem.FileLen (strFileName) == 0L) {
							goto end_IL_0000;
						}
						FileSystem.FileOpen (num3, strFileName, OpenMode.Binary, OpenAccess.Read);
						string Value = Strings.Space (3);
						FileSystem.FileGet (num3, ref Value, -1L);
						short num4;
						if ((Strings.Asc (Value) >= 48) & (Operators.CompareString (Strings.Right (Value, 1), "-", TextCompare: false) == 0)) {
							num4 = 0;
							FileSystem.Seek (num3, 1L);
						} else if (Strings.Asc (Value) == 1) {
							num4 = 100;
							FileSystem.Seek (num3, 2L);
						} else {
							num4 = (short)(Strings.Asc (Value) * 100 + Strings.Asc (Strings.Mid (Value, 2, 1)));
							FileSystem.Seek (num3, 3L);
						}
						if (unchecked(num4 / 10) > 140) {
							strMsg += "Unrecognized analysis file version.\r\n";
							FileSystem.FileClose (num3);
							goto end_IL_0000;
						}
						AppVer = num4;
						iCombSol = 0;
						Saved = true;
						if (num4 <= 100) {
							Value = Strings.Space (10);
							FileSystem.FileGet (num3, ref Value, -1L);
							RevDate = DateAndTime.DateValue (Value);
							Value = Strings.Space (8);
							FileSystem.FileGet (num3, ref Value, -1L);
							ref DateTime revDate = ref RevDate;
							revDate = Conversions.ToDate (Conversions.ToString (revDate) + Conversions.ToString (DateAndTime.TimeValue (Value)));
						} else {
							FileSystem.FileGet (num3, ref RevDate, -1L);
						}
						if (num4 < 100) {
							RevBy = string.Empty;
							Description = string.Empty;
							Project = string.Empty;
						} else {
							Value = ((num4 >= 410) ? Strings.Space (40) : Strings.Space (16));
							FileSystem.FileGet (num3, ref Value, -1L);
							RevBy = Strings.Trim (Value);
							Value = Strings.Space (40);
							FileSystem.FileGet (num3, ref Value, -1L);
							Description = Strings.Trim (Value);
							Value = Strings.Space (40);
							FileSystem.FileGet (num3, ref Value, -1L);
							Project = Strings.Trim (Value);
						}
						if (num4 >= 900) {
							FileSystem.FileGet (num3, ref Vertical, -1L);
						}
						if (num4 >= 1200) {
							FileSystem.FileGet (num3, ref BucklingTheory, -1L);
							FileSystem.FileGet (num3, ref Torsion, -1L);
						}
						FileSystem.FileGet (num3, ref nBeam, -1L);
						if (nBeam > Information.UBound (Beam)) {
							Beam = new Beam[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)nBeam) / 10.0) * 10.0) + 1];
						}
						string[] array = new string[unchecked((int)nBeam) + 1];
						DateTime[] array2 = new DateTime[unchecked((int)nBeam) + 1];
						if (num4 <= 100) {
							short num5 = nBeam;
							for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
								Beam [num6] = new Beam (0);
								ref Beam reference = ref Beam [num6];
								Value = Strings.Space (8);
								FileSystem.FileGet (num3, ref Value, -1L);
								Value = ".\\" + Strings.Trim (Value) + ".sct";
								array [num6] = CFS.FileNameAbsolute (Filename, Value);
								array2 [num6] = DateTime.FromOADate (0.0);
								FileSystem.FileGet (num3, ref reference.Z0, -1L);
								FileSystem.FileGet (num3, ref reference.Z1, -1L);
								reference.iBrcFlg = 0;
								reference.R = 0f;
								reference.Kf = 0f;
								reference.Lm = 240f;
								reference.ex = 0f;
								reference.ey = 0f;
							}
						} else {
							short num7 = nBeam;
							for (short num6 = 1; num6 <= num7; num6 = (short)unchecked(num6 + 1)) {
								Beam [num6] = new Beam (0);
								ref Beam reference2 = ref Beam [num6];
								FileSystem.FileGet (num3, ref Value2, -1L);
								Value = Strings.Space (Value2);
								FileSystem.FileGet (num3, ref Value, -1L);
								array [num6] = CFS.FileNameAbsolute (Filename, Value);
								FileSystem.FileGet (num3, ref array2 [num6], -1L);
								FileSystem.FileGet (num3, ref reference2.Z0, -1L);
								FileSystem.FileGet (num3, ref reference2.Z1, -1L);
								FileSystem.FileGet (num3, ref reference2.iBrcFlg, -1L);
								FileSystem.FileGet (num3, ref reference2.R, -1L);
								if (num4 >= 600) {
									FileSystem.FileGet (num3, ref reference2.Kf, -1L);
								} else {
									reference2.Kf = 0f;
								}
								if (num4 >= 700) {
									FileSystem.FileGet (num3, ref reference2.Lm, -1L);
								} else {
									reference2.Lm = 240f;
								}
								FileSystem.FileGet (num3, ref reference2.ex, -1L);
								FileSystem.FileGet (num3, ref reference2.ey, -1L);
							}
						}
						FileSystem.FileGet (num3, ref nSup, -1L);
						if (nSup > Information.UBound (Sup)) {
							Sup = new Support[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)nSup) / 10.0) * 10.0) + 1];
						}
						short num8 = nSup;
						for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
							ref Support reference3 = ref Sup [num9];
							FileSystem.FileGet (num3, ref reference3.Type, -1L);
							FileSystem.FileGet (num3, ref reference3.Z, -1L);
							FileSystem.FileGet (num3, ref reference3.Wid, -1L);
							if ((double)reference3.Wid < 0.75) {
								reference3.Wid = 0.75f;
							}
							FileSystem.FileGet (num3, ref reference3.K, -1L);
							if (num4 >= 400) {
								FileSystem.FileGet (num3, ref reference3.Fastened, -1L);
							} else {
								reference3.Fastened = false;
							}
						}
						FileSystem.FileGet (num3, ref nLdg, -1L);
						if (nLdg <= 0) {
							Ldg = new Loading[2];
							Ldg [1] = new Loading ("Loading 1", 10);
							if (num4 <= 100) {
								Comb = new LoadCombination[2];
								Comb [1] = new LoadCombination ("Combination 1", 10);
							}
						} else {
							Ldg = new Loading[unchecked((int)nLdg) + 1];
							if (num4 <= 100) {
								nComb = 1;
								Comb = new LoadCombination[2];
								Comb [1] = new LoadCombination ("Combination 1", 10);
								Comb [1].nLF = nLdg;
								if (Comb [1].nLF > Information.UBound (Comb [1].LF)) {
									Comb [1].LF = new LoadFactor[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)Comb [1].nLF) / 10.0) * 10.0) + 1];
								}
								short num10 = nLdg;
								for (short num11 = 1; num11 <= num10; num11 = (short)unchecked(num11 + 1)) {
									Ldg [num11] = new Loading (string.Empty, 10);
									Value = Strings.Space (20);
									FileSystem.FileGet (num3, ref Value, -1L);
									Ldg [num11].Description = Strings.Trim (Value);
									FileSystem.FileGet (num3, ref Comb [1].LF [num11].fLdg, -1L);
									Comb [1].LF [num11].iLdg = (byte)num11;
									FileSystem.FileGet (num3, ref Ldg [num11].nLoad, -1L);
									if (Ldg [num11].nLoad > Information.UBound (Ldg [num11].Load)) {
										Ldg [num11].Load = new Load[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)Ldg [num11].nLoad) / 10.0) * 10.0) + 1];
									}
									short nLoad = Ldg [num11].nLoad;
									for (short num12 = 1; num12 <= nLoad; num12 = (short)unchecked(num12 + 1)) {
										ref Load reference4 = ref Ldg [num11].Load [num12];
										FileSystem.FileGet (num3, ref reference4.Type, -1L);
										FileSystem.FileGet (num3, ref reference4.W0, -1L);
										FileSystem.FileGet (num3, ref reference4.Z0, -1L);
										FileSystem.FileGet (num3, ref reference4.Z1, -1L);
										if ((reference4.Type == 1) | (reference4.Type == 2)) {
											if (System.Math.Abs (reference4.Z1 - reference4.Z0) > 12f) {
												reference4.Type = 1;
											} else {
												reference4.Type = 2;
											}
										}
										switch (reference4.Type) {
										case 1:
											reference4.Ang = (float)System.Math.PI / 2f;
											reference4.W0 = 0f - reference4.W0;
											reference4.W1 = reference4.W0;
											break;
										case 2:
											reference4.Ang = (float)System.Math.PI / 2f;
											reference4.W0 = 0f - reference4.W0;
											reference4.W1 = reference4.W0;
											break;
										case 3:
											reference4.W1 = reference4.W0;
											break;
										}
										if (reference4.Type == 2) {
											reference4.Wid = System.Math.Abs (reference4.Z1 - reference4.Z0);
											reference4.W0 *= reference4.Wid;
											reference4.W1 = 0f;
											if ((double)reference4.Wid < 0.75) {
												reference4.Wid = 0.75f;
											}
											reference4.Z0 = (reference4.Z0 + reference4.Z1) / 2f;
											reference4.Z1 = reference4.Z0;
										}
									}
								}
								short num13 = nLdg;
								for (short num11 = 1; num11 <= num13; num11 = (short)unchecked(num11 + 1)) {
									if (Strings.Len (Ldg [num11].Description) == 0) {
										short num14 = 0;
										string text;
										short num16;
										do {
											num14 = (short)(num14 + 1);
											text = "Loading " + Conversions.ToString (unchecked((int)num14));
											short num15 = nLdg;
											num16 = 1;
											while (num16 <= num15 && Strings.StrComp (Ldg [num16].Description, text, CompareMethod.Text) != 0) {
												num16 = (short)unchecked(num16 + 1);
											}
										} while (num16 <= nLdg);
										Ldg [num11].Description = text;
									}
								}
							} else {
								short num17 = nLdg;
								for (short num11 = 1; num11 <= num17; num11 = (short)unchecked(num11 + 1)) {
									Ldg [num11] = new Loading (string.Empty, 10);
									ref Loading reference5 = ref Ldg [num11];
									Value = Strings.Space (20);
									FileSystem.FileGet (num3, ref Value, -1L);
									reference5.Description = Strings.Trim (Value);
									FileSystem.FileGet (num3, ref reference5.nLoad, -1L);
									if (reference5.nLoad > Information.UBound (reference5.Load)) {
										reference5.Load = new Load[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)reference5.nLoad) / 10.0) * 10.0) + 1];
									}
									short nLoad2 = reference5.nLoad;
									for (short num12 = 1; num12 <= nLoad2; num12 = (short)unchecked(num12 + 1)) {
										ref Load reference6 = ref reference5.Load [num12];
										FileSystem.FileGet (num3, ref reference6.Type, -1L);
										FileSystem.FileGet (num3, ref reference6.Ang, -1L);
										FileSystem.FileGet (num3, ref reference6.Z0, -1L);
										FileSystem.FileGet (num3, ref reference6.Z1, -1L);
										FileSystem.FileGet (num3, ref reference6.W0, -1L);
										FileSystem.FileGet (num3, ref reference6.W1, -1L);
										FileSystem.FileGet (num3, ref reference6.Wid, -1L);
										if (unchecked(reference6.Type == 2 && num4 < 1200)) {
											reference6.W0 *= reference6.Wid;
											reference6.W1 = 0f;
											reference6.Z0 = (reference6.Z0 + reference6.Z1) / 2f;
											reference6.Z1 = reference6.Z0;
										}
									}
								}
							}
						}
						if (num4 >= 300) {
							FileSystem.FileGet (num3, ref nComb, -1L);
							if (nComb <= 0) {
								Comb = new LoadCombination[2];
								Comb [1] = new LoadCombination ("Combination 1", 10);
							} else {
								Comb = new LoadCombination[unchecked((int)nComb) + 1];
								short num18 = nComb;
								for (short num19 = 1; num19 <= num18; num19 = (short)unchecked(num19 + 1)) {
									Comb [num19] = new LoadCombination (string.Empty, 10);
									ref LoadCombination reference7 = ref Comb [num19];
									Value = Strings.Space (30);
									FileSystem.FileGet (num3, ref Value, -1L);
									reference7.Description = Strings.Trim (Value);
									FileSystem.FileGet (num3, ref reference7.Spec, -1L);
									if (num4 < 400) {
										reference7.Spec = System.Math.Abs (reference7.Spec);
									}
									if (reference7.Spec == 0) {
										reference7.Spec = 2;
									}
									if (reference7.Spec == 1) {
										reference7.Spec = 3;
									}
									if (num4 >= 400) {
										FileSystem.FileGet (num3, ref reference7.InflPt, -1L);
									}
									FileSystem.FileGet (num3, ref reference7.nLF, -1L);
									if (reference7.nLF > Information.UBound (reference7.LF)) {
										reference7.LF = new LoadFactor[(int)System.Math.Round (System.Math.Ceiling ((double)unchecked((int)reference7.nLF) / 10.0) * 10.0) + 1];
									}
									short nLF = reference7.nLF;
									for (short num20 = 1; num20 <= nLF; num20 = (short)unchecked(num20 + 1)) {
										FileSystem.FileGet (num3, ref reference7.LF [num20].iLdg, -1L);
										FileSystem.FileGet (num3, ref reference7.LF [num20].fLdg, -1L);
									}
								}
							}
							if (num4 >= 1100) {
								FileSystem.FileGet (num3, ref AllCombos, -1L);
							}
						}
						Comb [0] = default(LoadCombination);
						short num21 = nComb;
						for (short num19 = 1; num19 <= num21; num19 = (short)unchecked(num19 + 1)) {
							if (Comb [num19].Spec >= 0) {
								Comb [0].Spec = Comb [num19].Spec;
								Comb [0].InflPt = Comb [num19].InflPt;
								break;
							}
						}
						if (num4 >= 501) {
							FileSystem.FileGet (num3, ref Value2, -1L);
							if (Value2 > 0) {
								Notes = Strings.Space (Value2);
								FileSystem.FileGet (num3, ref Notes, -1L);
							}
						}
						if (num4 >= 300) {
							FileSystem.FileGet (num3, ref Value3, -1L);
							if (Value3 > 0) {
								Report = Strings.Space (Value3);
								FileSystem.FileGet (num3, ref Report, -1L);
							}
						}
						Ldg [0] = new Loading ("Beam Self Weight", 10);
						FileSystem.FileClose (num3);
						short num22 = nBeam;
						for (short num6 = 1; num6 <= num22; num6 = (short)unchecked(num6 + 1)) {
							ref Beam reference8 = ref Beam [num6];
							reference8.iSct = (byte)CFSInterface.LoadMultiSct (ref array [num6], ref strMsg);
							if ((reference8.iSct > 0) & (DateTime.Compare (array2 [num6], DateTime.FromOADate (0.0)) > 0) & (DateTime.Compare (CFS.Sections [reference8.iSct].RevDate, array2 [num6]) != 0)) {
								short num23 = (short)(num6 - 1);
								short num16 = 1;
								while (num16 <= num23 && reference8.iSct != Beam [num16].iSct) {
									num16 = (short)unchecked(num16 + 1);
								}
								if (num16 > num6 - 1) {
									strMsg = strMsg + array [num6] + " is not the same as when this analysis was saved.\r\n";
									Saved = false;
								}
							}
						}
						if (RemoveBeam (0)) {
							Saved = false;
						}
						result = true;
						goto end_IL_0000_2;
					}
					case 4403:
						num = -1;
						switch (num2) {
						case 2:
							FileSystem.FileClose (num3);
							strMsg = strMsg + Information.Err ().Description + "\r\n";
							ProjectData.ClearProjectError ();
							if (num == 0) {
								throw ProjectData.CreateProjectError (-2146828268);
							}
							num = 0;
							goto end_IL_0000_2;
						}
						break;
					}
					goto IL_1169;
				}
				end_IL_0000_2:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 4403;
				continue;
			}
			break;
			IL_1169:
			throw ProjectData.CreateProjectError (-2146828237);
			continue;
			end_IL_0000:
			break;
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	[MethodImpl (MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	public bool Save (string strMsg)
	{
		int try0000_dispatch = -1;
		int num2 = default(int);
		bool result = default(bool);
		short num3 = default(short);
		int num = default(int);
		while (true) {
			try {
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch) {
				default: {
					ProjectData.ClearProjectError ();
					num2 = 2;
					result = false;
					strMsg = string.Empty;
					if (!File.Exists (Filename)) {
						string text = Path.ChangeExtension (Filename, ".anl");
						if (File.Exists (text)) {
							My.MyProject.Computer.FileSystem.RenameFile (text, CFSInterface.GetFileName (Filename));
						}
					}
					num3 = checked((short)FileSystem.FreeFile ());
					FileSystem.FileOpen (num3, Filename, OpenMode.Output);
					FileSystem.FileClose (num3);
					FileSystem.FileOpen (num3, Filename, OpenMode.Binary, OpenAccess.Write);
					FileSystem.FilePut ((int)num3, (byte)14, -1L);
					FileSystem.FilePut ((int)num3, (byte)0, -1L);
					FileSystem.FilePut (num3, RevDate, -1L);
					FileSystem.FilePut (num3, RevBy.PadRight (40), -1L);
					FileSystem.FilePut (num3, Description.PadRight (40), -1L);
					FileSystem.FilePut (num3, Project.PadRight (40), -1L);
					FileSystem.FilePut (num3, Vertical, -1L);
					FileSystem.FilePut (num3, BucklingTheory, -1L);
					FileSystem.FilePut (num3, Torsion, -1L);
					FileSystem.FilePut (num3, nBeam, -1L);
					short num4 = nBeam;
					checked {
						for (short num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
							ref Beam reference = ref Beam [num5];
							string text2 = CFS.FileNameRelative (Filename, CFS.Sections [reference.iSct].Filename);
							FileSystem.FilePut (num3, (short)Strings.Len (text2), -1L);
							FileSystem.FilePut (num3, text2, -1L);
							FileSystem.FilePut (num3, CFS.Sections [reference.iSct].RevDate, -1L);
							FileSystem.FilePut (num3, reference.Z0, -1L);
							FileSystem.FilePut (num3, reference.Z1, -1L);
							FileSystem.FilePut (num3, reference.iBrcFlg, -1L);
							FileSystem.FilePut (num3, reference.R, -1L);
							FileSystem.FilePut (num3, reference.Kf, -1L);
							FileSystem.FilePut (num3, reference.Lm, -1L);
							FileSystem.FilePut (num3, reference.ex, -1L);
							FileSystem.FilePut (num3, reference.ey, -1L);
						}
						FileSystem.FilePut (num3, nSup, -1L);
						short num6 = nSup;
						for (short num7 = 1; num7 <= num6; num7 = (short)unchecked(num7 + 1)) {
							ref Support reference2 = ref Sup [num7];
							FileSystem.FilePut (num3, reference2.Type, -1L);
							FileSystem.FilePut (num3, reference2.Z, -1L);
							FileSystem.FilePut (num3, reference2.Wid, -1L);
							FileSystem.FilePut (num3, reference2.K, -1L);
							FileSystem.FilePut (num3, reference2.Fastened, -1L);
						}
						FileSystem.FilePut (num3, nLdg, -1L);
						short num8 = nLdg;
						for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
							ref Loading reference3 = ref Ldg [num9];
							FileSystem.FilePut (num3, reference3.Description.PadRight (20), -1L);
							FileSystem.FilePut (num3, reference3.nLoad, -1L);
							short nLoad = reference3.nLoad;
							for (short num10 = 1; num10 <= nLoad; num10 = (short)unchecked(num10 + 1)) {
								ref Load reference4 = ref reference3.Load [num10];
								FileSystem.FilePut (num3, reference4.Type, -1L);
								FileSystem.FilePut (num3, reference4.Ang, -1L);
								FileSystem.FilePut (num3, reference4.Z0, -1L);
								FileSystem.FilePut (num3, reference4.Z1, -1L);
								FileSystem.FilePut (num3, reference4.W0, -1L);
								FileSystem.FilePut (num3, reference4.W1, -1L);
								FileSystem.FilePut (num3, reference4.Wid, -1L);
							}
						}
						FileSystem.FilePut (num3, nComb, -1L);
						short num11 = nComb;
						for (short num12 = 1; num12 <= num11; num12 = (short)unchecked(num12 + 1)) {
							ref LoadCombination reference5 = ref Comb [num12];
							FileSystem.FilePut (num3, reference5.Description.PadRight (30), -1L);
							FileSystem.FilePut (num3, reference5.Spec, -1L);
							FileSystem.FilePut (num3, reference5.InflPt, -1L);
							FileSystem.FilePut (num3, reference5.nLF, -1L);
							short nLF = reference5.nLF;
							for (short num13 = 1; num13 <= nLF; num13 = (short)unchecked(num13 + 1)) {
								FileSystem.FilePut (num3, reference5.LF [num13].iLdg, -1L);
								FileSystem.FilePut (num3, reference5.LF [num13].fLdg, -1L);
							}
						}
						FileSystem.FilePut (num3, AllCombos, -1L);
						FileSystem.FilePut (num3, (short)Strings.Len (Notes), -1L);
						FileSystem.FilePut (num3, Notes, -1L);
						if (Strings.Len (Report) == 0) {
							FileSystem.FilePut (num3, 0, -1L);
						} else {
							FileSystem.FilePut (num3, Strings.Len (Report), -1L);
							FileSystem.FilePut (num3, Report, -1L);
						}
						Saved = true;
						result = true;
						break;
					}
				}
				case 1319:
					num = -1;
					switch (num2) {
					case 2:
						strMsg = strMsg + Information.Err ().Description + "\r\n";
						ProjectData.ClearProjectError ();
						if (num == 0) {
							throw ProjectData.CreateProjectError (-2146828268);
						}
						num = 0;
						break;
					default:
						goto end_IL_0000;
					}
					break;
				}
				FileSystem.FileClose (num3);
				break;
				end_IL_0000:;
			} catch (object obj) when (obj is Exception && num2 != 0 && num == 0) {
				ProjectData.SetProjectError ((Exception)obj);
				try0000_dispatch = 1319;
				continue;
			}
			throw ProjectData.CreateProjectError (-2146828237);
		}
		if (num != 0) {
			ProjectData.ClearProjectError ();
		}
		return result;
	}

	public bool RemoveBeam (byte iSct)
	{
		bool result = false;
		short num = 0;
		short num2 = nBeam;
		checked {
			for (short num3 = 1; num3 <= num2; num3 = (short)unchecked(num3 + 1)) {
				if (Beam [num3].iSct == iSct) {
					num = (short)(num + 1);
					result = true;
				} else {
					Beam [(short)unchecked(num3 - num)] = Beam [num3];
				}
			}
			ref byte reference = ref nBeam;
			reference = (byte)(short)unchecked(reference - num);
			return result;
		}
	}

	private void Nodes (short iDir, byte supTran, byte supRot, byte supHinge)
	{
		Solution solution = Sol [iDir];
		checked {
			solution.nNode = (short)(2 * unchecked((int)nBeam) + unchecked((int)nSup));
			solution.Znode = new float[solution.nNode + 1];
			solution.iDOF = new short[solution.nNode + 1, 3];
			solution.nNode = 0;
			solution.nDOF = 0;
			short num = nSup;
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if ((Sup [num2].Type & supTran) == supTran) {
					solution.nNode++;
					solution.Znode [solution.nNode] = Sup [num2].Z;
				}
			}
			short num3 = nSup;
			for (short num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				if ((Sup [num2].Type & supHinge) == supHinge) {
					float z = Sup [num2].Z;
					short nNode = solution.nNode;
					short num4 = 1;
					while (num4 <= nNode && solution.Znode [num4] != z) {
						num4 = (short)unchecked(num4 + 1);
					}
					if (num4 > solution.nNode) {
						solution.nNode++;
						solution.Znode [solution.nNode] = z;
					}
				}
			}
			short num5 = nBeam;
			for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
				float z = Beam [num6].Z0;
				short nNode2 = solution.nNode;
				short num4 = 1;
				while (num4 <= nNode2 && solution.Znode [num4] != z) {
					num4 = (short)unchecked(num4 + 1);
				}
				if (num4 > solution.nNode) {
					solution.nNode++;
					solution.Znode [solution.nNode] = z;
				}
				z = Beam [num6].Z1;
				short nNode3 = solution.nNode;
				num4 = 1;
				while (num4 <= nNode3 && solution.Znode [num4] != z) {
					num4 = (short)unchecked(num4 + 1);
				}
				if (num4 > solution.nNode) {
					solution.nNode++;
					solution.Znode [solution.nNode] = z;
				}
			}
			short num7 = (short)(solution.nNode - 1);
			for (short num4 = 1; num4 <= num7; num4 = (short)unchecked(num4 + 1)) {
				if (solution.Znode [num4] > solution.Znode [num4 + 1]) {
					CFS.Swap (ref Sol [iDir].Znode [num4], ref Sol [iDir].Znode [num4 + 1]);
					if (num4 > 1) {
						num4 = (short)(num4 - 2);
					}
				}
			}
			short nNode4 = solution.nNode;
			for (short num4 = 1; num4 <= nNode4; num4 = (short)unchecked(num4 + 1)) {
				bool flag = false;
				short num8 = nSup;
				short num2;
				for (num2 = 1; num2 <= num8; num2 = (short)unchecked(num2 + 1)) {
					if ((Sup [num2].Type & supTran) == supTran) {
						if (unchecked(Sup [num2].Z >= solution.Znode [num4] && flag) || !(Sup [num2].Z <= solution.Znode [num4])) {
							break;
						}
						flag = Sup [num2].K == 0f;
					}
				}
				if (flag & (num2 > nSup)) {
					flag = false;
				}
				if (flag) {
					solution.iDOF [num4, 0] = -1;
					solution.iDOF [num4, 1] = -1;
					solution.iDOF [num4, 2] = -1;
				}
			}
			short nNode5 = solution.nNode;
			for (short num4 = 1; num4 <= nNode5; num4 = (short)unchecked(num4 + 1)) {
				short num9 = nSup;
				short num2 = 1;
				while (num2 <= num9 && !((solution.Znode [num4] == Sup [num2].Z) & ((Sup [num2].Type & supRot) == supRot))) {
					num2 = (short)unchecked(num2 + 1);
				}
				if ((num2 > nSup) & (solution.iDOF [num4, 0] == 0)) {
					solution.nDOF++;
					solution.iDOF [num4, 0] = solution.nDOF;
					solution.iDOF [num4, 1] = solution.nDOF;
					short num10 = nSup;
					for (num2 = 1; num2 <= num10; num2 = (short)unchecked(num2 + 1)) {
						if ((Sup [num2].Z == solution.Znode [num4]) & ((Sup [num2].Type & supHinge) == supHinge)) {
							solution.nDOF++;
							solution.iDOF [num4, 1] = solution.nDOF;
							break;
						}
					}
				}
			}
			short nNode6 = solution.nNode;
			for (short num4 = 1; num4 <= nNode6; num4 = (short)unchecked(num4 + 1)) {
				short num11 = nSup;
				short num2 = 1;
				while (num2 <= num11 && !((solution.Znode [num4] == Sup [num2].Z) & ((Sup [num2].Type & supTran) == supTran))) {
					num2 = (short)unchecked(num2 + 1);
				}
				if ((num2 > nSup) & (solution.iDOF [num4, 2] == 0)) {
					solution.nDOF++;
					solution.iDOF [num4, 2] = solution.nDOF;
				}
				if (solution.iDOF [num4, 0] < 0) {
					solution.iDOF [num4, 0] = 0;
				}
				if (solution.iDOF [num4, 1] < 0) {
					solution.iDOF [num4, 1] = 0;
				}
				if (solution.iDOF [num4, 2] < 0) {
					solution.iDOF [num4, 2] = 0;
				}
			}
			solution = null;
		}
	}

	private void LoadPoints (byte iDir)
	{
		Solution solution = Sol [iDir];
		checked {
			solution.nSeg = (short)(solution.nNode + 2 * solution.nLoad);
			solution.Seg = new FlexureSegment[solution.nSeg + 1];
			int nNode = solution.nNode;
			for (int i = 1; i <= nNode; i++) {
				solution.Seg [i].Z = solution.Znode [i];
			}
			solution.nSeg = solution.nNode;
			int nLF = Comb [iComb].nLF;
			short num2;
			for (int j = 1; j <= nLF; j++) {
				short num = Comb [iComb].LF [j].iLdg;
				float fLdg = Comb [iComb].LF [j].fLdg;
				if (fLdg == 0f) {
					continue;
				}
				int nLoad = Ldg [num].nLoad;
				for (int k = 1; k <= nLoad; k++) {
					float value = 0f;
					float z = Ldg [num].Load [k].Z0;
					float z2 = Ldg [num].Load [k].Z1;
					if ((Ldg [num].Load [k].W0 != 0f) | (Ldg [num].Load [k].W1 != 0f)) {
						if (Ldg [num].Load [k].Type == 3) {
							if (z2 > z) {
								value = 1f;
							}
						} else {
							if (iDir == 2) {
								value = (float)System.Math.Cos (Ldg [num].Load [k].Ang);
							}
							if (iDir == 1) {
								value = (float)System.Math.Sin (Ldg [num].Load [k].Ang);
							}
						}
					}
					if ((double)System.Math.Abs (value) > 1E-05) {
						short nSeg = solution.nSeg;
						num2 = 1;
						while (num2 <= nSeg && z != solution.Seg [num2].Z) {
							num2 = (short)unchecked(num2 + 1);
						}
						if (num2 > solution.nSeg) {
							solution.nSeg++;
							solution.Seg [solution.nSeg].Z = z;
						}
						short nSeg2 = solution.nSeg;
						num2 = 1;
						while (num2 <= nSeg2 && z2 != solution.Seg [num2].Z) {
							num2 = (short)unchecked(num2 + 1);
						}
						if (num2 > solution.nSeg) {
							solution.nSeg++;
							solution.Seg [solution.nSeg].Z = z2;
						}
					}
				}
			}
			short num3 = (short)(solution.nSeg - 1);
			for (num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				if (solution.Seg [num2].Z > solution.Seg [num2 + 1].Z) {
					CFS.Swap (ref Sol [iDir].Seg [num2].Z, ref Sol [iDir].Seg [num2 + 1].Z);
					if (num2 > 1) {
						num2 = (short)(num2 - 2);
					}
				}
			}
			solution.nSeg--;
			if (unchecked(iDir == 1 || iDir == 2)) {
				Supports supports = default(Supports);
				if (iDir == 1) {
					supports = Supports.supY;
				}
				if (iDir == 2) {
					supports = Supports.supX;
				}
				short nSeg3 = solution.nSeg;
				for (num2 = 1; num2 <= nSeg3; num2 = (short)unchecked(num2 + 1)) {
					short num4 = nSup;
					short num5;
					for (num5 = 1; num5 <= num4; num5 = (short)unchecked(num5 + 1)) {
						if (unchecked(((uint)Sup [num5].Type & (uint)supports) == (uint)supports)) {
							if (!(Sup [num5].Z <= solution.Seg [num2].Z)) {
								break;
							}
							solution.Seg [num2].Braced = Sup [num5].K == 0f;
						}
					}
					if (solution.Seg [num2].Braced & (num5 > nSup)) {
						solution.Seg [num2].Braced = false;
					}
				}
			}
			int nLF2 = Comb [iComb].nLF;
			float num14 = default(float);
			for (int l = 1; l <= nLF2; l++) {
				short num = Comb [iComb].LF [l].iLdg;
				float fLdg = Comb [iComb].LF [l].fLdg;
				if (fLdg == 0f) {
					continue;
				}
				int nLoad2 = Ldg [num].nLoad;
				for (int m = 1; m <= nLoad2; m++) {
					float value = 0f;
					float z = Ldg [num].Load [m].Z0;
					float z2 = Ldg [num].Load [m].Z1;
					if (Ldg [num].Load [m].Type == 3) {
						if (z2 > z) {
							value = 1f;
						}
					} else {
						if (iDir == 2) {
							value = (float)System.Math.Cos (Ldg [num].Load [m].Ang);
						}
						if (iDir == 1) {
							value = (float)System.Math.Sin (Ldg [num].Load [m].Ang);
						}
					}
					if ((double)System.Math.Abs (value) <= 1E-05) {
						value = 0f;
					}
					float num6 = Ldg [num].Load [m].W0 * value * fLdg;
					float num7 = Ldg [num].Load [m].W1 * value * fLdg;
					if (Ldg [num].Load [m].Type == 2) {
						short num8 = (short)(solution.nSeg + 1);
						for (num2 = 1; num2 <= num8; num2 = (short)unchecked(num2 + 1)) {
							if ((z == solution.Seg [num2].Z) & !solution.Seg [num2].Braced & !solution.Seg [num2 - 1].Braced) {
								solution.Seg [num2].P0 += num6;
							}
						}
					} else if (Ldg [num].Load [m].Type == 4) {
						short num9 = (short)(solution.nSeg + 1);
						for (num2 = 1; num2 <= num9; num2 = (short)unchecked(num2 + 1)) {
							if ((z == solution.Seg [num2].Z) & !solution.Seg [num2].Braced & !solution.Seg [num2 - 1].Braced) {
								solution.Seg [num2].M0 += num6;
							}
						}
					} else if (unchecked(Ldg [num].Load [m].Type == 3 && iDir != 3)) {
						short num10 = (short)(solution.nSeg + 1);
						for (num2 = 1; num2 <= num10; num2 = (short)unchecked(num2 + 1)) {
							if (unchecked(z == solution.Seg [num2].Z && num6 != 0f) & !solution.Seg [num2].Braced & !solution.Seg [num2 - 1].Braced) {
								float num11 = 0f;
								float num12 = 0f;
								int num13 = nBeam;
								for (int n = 1; n <= num13; n++) {
									if ((Beam [n].Z0 <= z) & (Beam [n].Z1 > z)) {
										if (iDir == 1) {
											num14 = Beam [n].ey - CFS.Sections [Beam [n].iSct].Prop.Ycg;
										}
										if (iDir == 2) {
											num14 = Beam [n].ex - CFS.Sections [Beam [n].iSct].Prop.Xcg;
										}
										num11 += Beam [n].EI [3];
										num12 += Beam [n].EI [3] * num14;
									}
								}
								solution.Seg [num2].M0 += num6 * num12 / num11;
							}
							if (unchecked(z2 == solution.Seg [num2].Z && num7 != 0f) & !solution.Seg [num2].Braced & !solution.Seg [num2 - 1].Braced) {
								float num11 = 0f;
								float num12 = 0f;
								int num15 = nBeam;
								for (int num16 = 1; num16 <= num15; num16++) {
									if ((Beam [num16].Z0 < z2) & (Beam [num16].Z1 >= z2)) {
										if (iDir == 1) {
											num14 = Beam [num16].ey - CFS.Sections [Beam [num16].iSct].Prop.Ycg;
										}
										if (iDir == 2) {
											num14 = Beam [num16].ex - CFS.Sections [Beam [num16].iSct].Prop.Xcg;
										}
										num11 += Beam [num16].EI [3];
										num12 += Beam [num16].EI [3] * num14;
									}
								}
								solution.Seg [num2].M0 += (0f - num7) * num12 / num11;
							}
						}
					} else {
						if (!unchecked(num6 != 0f || num7 != 0f)) {
							continue;
						}
						short nSeg4 = solution.nSeg;
						for (num2 = 1; num2 <= nSeg4; num2 = (short)unchecked(num2 + 1)) {
							if ((z <= solution.Seg [num2].Z) & (z2 >= solution.Seg [num2 + 1].Z) & !solution.Seg [num2].Braced) {
								solution.Seg [num2].W0 += num6 + (num7 - num6) * (solution.Seg [num2].Z - z) / (z2 - z);
								solution.Seg [num2].W1 += num6 + (num7 - num6) * (solution.Seg [num2 + 1].Z - z) / (z2 - z);
							}
						}
					}
				}
			}
			solution.nLoad = 0;
			short nSeg5 = solution.nSeg;
			for (num2 = 1; num2 <= nSeg5; num2 = (short)unchecked(num2 + 1)) {
				if ((solution.Seg [num2].W0 != 0f) | (solution.Seg [num2].W1 != 0f) | (solution.Seg [num2].P0 != 0f) | (solution.Seg [num2].M0 != 0f)) {
					solution.nLoad++;
				}
			}
			if ((solution.Seg [num2].P0 != 0f) | (solution.Seg [num2].M0 != 0f)) {
				solution.nLoad++;
			}
			solution = null;
		}
	}

	private void BeamStiffness (byte iDir)
	{
		Solution solution = Sol [iDir];
		checked {
			solution.EI = new float[solution.nNode - 1 + 1];
			short num = (short)(solution.nNode - 1);
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				float num3 = solution.Znode [num2];
				float num4 = solution.Znode [num2 + 1];
				solution.EI [num2] = 0f;
				short num5 = nBeam;
				for (short num6 = 1; num6 <= num5; num6 = (short)unchecked(num6 + 1)) {
					if ((Beam [num6].Z0 <= num3) & (Beam [num6].Z1 >= num4)) {
						solution.EI [num2] = solution.EI [num2] + Beam [num6].EI [iDir];
					}
				}
			}
			solution = null;
		}
	}

	public void MemberCheckPoints (ref short nChk, ref float[] Zchk, ref short[] Schk)
	{
		SolutionDetail Det = default(SolutionDetail);
		nChk = 0;
		short num = nBeam;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				float z = Beam [num2].Z0;
				AddMemberCheck (z, ref nChk, ref Zchk);
				z = Beam [num2].Z1;
				AddMemberCheck (z, ref nChk, ref Zchk);
			}
			if (Sol [1].nLoad > 0) {
				Sol [1].MinimaMaxima (ref Det);
				short nNode = Sol [1].nNode;
				for (short num2 = 1; num2 <= nNode; num2 = (short)unchecked(num2 + 1)) {
					if (Sol [1].D [num2] == 0f) {
						float z = Sol [1].Znode [num2];
						AddMemberCheck (z, ref nChk, ref Zchk);
					}
				}
				short nV = Det.NV;
				for (short num2 = 1; num2 <= nV; num2 = (short)unchecked(num2 + 1)) {
					float z = Det.ZV [num2];
					AddMemberCheck (z, ref nChk, ref Zchk);
				}
				short nM = Det.NM;
				for (short num2 = 1; num2 <= nM; num2 = (short)unchecked(num2 + 1)) {
					float z = Det.ZM [num2];
					AddMemberCheck (z, ref nChk, ref Zchk);
				}
				int num3 = nSup;
				for (int i = 1; i <= num3; i++) {
					if ((Sup [i].Type & 1) == 1) {
						AddMemberCheck (Sup [i].Z, ref nChk, ref Zchk);
					}
				}
			}
			if (Sol [2].nLoad > 0) {
				Sol [2].MinimaMaxima (ref Det);
				short nNode2 = Sol [2].nNode;
				for (short num2 = 1; num2 <= nNode2; num2 = (short)unchecked(num2 + 1)) {
					if (Sol [2].D [num2] == 0f) {
						float z = Sol [2].Znode [num2];
						AddMemberCheck (z, ref nChk, ref Zchk);
					}
				}
				short nV2 = Det.NV;
				for (short num2 = 1; num2 <= nV2; num2 = (short)unchecked(num2 + 1)) {
					float z = Det.ZV [num2];
					AddMemberCheck (z, ref nChk, ref Zchk);
				}
				short nM2 = Det.NM;
				for (short num2 = 1; num2 <= nM2; num2 = (short)unchecked(num2 + 1)) {
					float z = Det.ZM [num2];
					AddMemberCheck (z, ref nChk, ref Zchk);
				}
				int num4 = nSup;
				for (int j = 1; j <= num4; j++) {
					if ((Sup [j].Type & 2) == 2) {
						AddMemberCheck (Sup [j].Z, ref nChk, ref Zchk);
					}
				}
			}
			short nLF = Comb [iComb].nLF;
			float ZMmin = default(float);
			float ZMmax = default(float);
			float Mmin = default(float);
			float Mmax = default(float);
			for (short num5 = 1; num5 <= nLF; num5 = (short)unchecked(num5 + 1)) {
				short num6 = Comb [iComb].LF [num5].iLdg;
				float fLdg = Comb [iComb].LF [num5].fLdg;
				short nLoad = Ldg [num6].nLoad;
				for (short num7 = 1; num7 <= nLoad; num7 = (short)unchecked(num7 + 1)) {
					if (fLdg * Ldg [num6].Load [num7].W0 != 0f) {
						switch (Ldg [num6].Load [num7].Type) {
						case 3: {
							float z2 = Ldg [num6].Load [num7].Z0;
							float z3 = Ldg [num6].Load [num7].Z1;
							Sol [1].Moments (z2, z3, ref ZMmin, ref ZMmax, ref Mmin, ref Mmax);
							if (Mmin < 0f) {
								float z = ZMmin;
								AddMemberCheck (z, ref nChk, ref Zchk);
							}
							if (Mmax > 0f) {
								float z = ZMmax;
								AddMemberCheck (z, ref nChk, ref Zchk);
							}
							Sol [2].Moments (z2, z3, ref ZMmin, ref ZMmax, ref Mmin, ref Mmax);
							if (Mmin < 0f) {
								float z = ZMmin;
								AddMemberCheck (z, ref nChk, ref Zchk);
							}
							if (Mmax > 0f) {
								float z = ZMmax;
								AddMemberCheck (z, ref nChk, ref Zchk);
							}
							if ((Sol [1].nLoad == 0) & (Sol [2].nLoad == 0)) {
								short num8 = nChk;
								short num9 = 1;
								while (num9 <= num8 && !((Zchk [num9] >= z2) & (Zchk [num9] <= z3))) {
									num9 = (short)unchecked(num9 + 1);
								}
								if (num9 > nChk) {
									float z = (z2 + z3) / 2f;
									AddMemberCheck (z, ref nChk, ref Zchk);
								}
							}
							break;
						}
						case 2:
						case 4: {
							float z = Ldg [num6].Load [num7].Z0;
							AddMemberCheck (z, ref nChk, ref Zchk);
							break;
						}
						}
					}
				}
			}
			if ((Sol [1].nLoad == 0) & (Sol [2].nLoad == 0)) {
				float z2 = Zmin;
				int num10 = nSup;
				for (int k = 1; k <= num10; k++) {
					if (((Sup [k].Type & 1) == 1) & (Sup [k].Z > z2)) {
						float z3 = Sup [k].Z;
						short num11 = nChk;
						short num9 = 1;
						while (num9 <= num11 && !((Zchk [num9] >= z2) & (Zchk [num9] <= z3))) {
							num9 = (short)unchecked(num9 + 1);
						}
						if (num9 > nChk) {
							float z = (z2 + z3) / 2f;
							AddMemberCheck (z, ref nChk, ref Zchk);
						}
						z2 = z3;
					}
				}
				z2 = Zmin;
				int num12 = nSup;
				for (int l = 1; l <= num12; l++) {
					if (((Sup [l].Type & 2) == 2) & (Sup [l].Z > z2)) {
						float z3 = Sup [l].Z;
						short num13 = nChk;
						short num9 = 1;
						while (num9 <= num13 && !((Zchk [num9] >= z2) & (Zchk [num9] <= z3))) {
							num9 = (short)unchecked(num9 + 1);
						}
						if (num9 > nChk) {
							float z = (z2 + z3) / 2f;
							AddMemberCheck (z, ref nChk, ref Zchk);
						}
						z2 = z3;
					}
				}
			}
			if (2 * nChk > Information.UBound (Zchk)) {
				Zchk = (float[])Utils.CopyArray (Zchk, new float[2 * nChk + 1]);
			}
			if (2 * nChk > Information.UBound (Schk)) {
				Schk = (short[])Utils.CopyArray (Schk, new short[2 * nChk + 1]);
			}
			short num14 = nChk;
			for (short num9 = 1; num9 <= num14; num9 = (short)unchecked(num9 + 1)) {
				switch (CheckPointSides (Zchk [num9])) {
				case 0:
					Schk [num9] = 0;
					break;
				case 1:
					Schk [num9] = -1;
					break;
				case 2:
					Schk [num9] = 1;
					break;
				case 3:
					Schk [num9] = -1;
					nChk++;
					Zchk [nChk] = Zchk [num9];
					Schk [nChk] = 1;
					break;
				}
			}
			short num15 = (short)(nChk - 1);
			for (short num9 = 1; num9 <= num15; num9 = (short)unchecked(num9 + 1)) {
				if ((Zchk [num9] > Zchk [num9 + 1]) | ((Zchk [num9] == Zchk [num9 + 1]) & (Schk [num9] > Schk [num9 + 1]))) {
					CFS.Swap (ref Zchk [num9], ref Zchk [num9 + 1]);
					CFS.Swap (ref Schk [num9], ref Schk [num9 + 1]);
					if (num9 > 1) {
						num9 = (short)(num9 - 2);
					}
				}
			}
		}
	}

	private void AddMemberCheck (float Z, ref short nCheck, ref float[] Zcheck)
	{
		short num = nCheck;
		short num2 = 1;
		checked {
			while (true) {
				if (num2 <= num) {
					if (!((double)System.Math.Abs (Z - Zcheck [num2]) <= 0.0005)) {
						num2 = (short)unchecked(num2 + 1);
						continue;
					}
					break;
				}
				nCheck++;
				if (nCheck > Information.UBound (Zcheck)) {
					Zcheck = (float[])Utils.CopyArray (Zcheck, new float[2 * nCheck + 1]);
				}
				Zcheck [nCheck] = Z;
				break;
			}
		}
	}

	internal byte CheckPointSides (float Zchk)
	{
		bool flag = false;
		bool flag2 = false;
		short num = nSup;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Zchk == Sup [num2].Z) {
					flag = true;
					flag2 = true;
					break;
				}
			}
			short num3 = nBeam;
			for (short num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				if (Zchk == Beam [num2].Z0) {
					flag = true;
				}
				if (Zchk == Beam [num2].Z1) {
					flag2 = true;
				}
			}
			short nSeg = Sol [3].nSeg;
			for (short num2 = 2; num2 <= nSeg; num2 = (short)unchecked(num2 + 1)) {
				if ((Zchk == Sol [3].Seg [num2].Z) & (Sol [3].Seg [num2 - 1].W1 != Sol [3].Seg [num2].W0)) {
					flag = true;
					flag2 = true;
				}
			}
			short nLF = Comb [iComb].nLF;
			for (short num4 = 1; num4 <= nLF; num4 = (short)unchecked(num4 + 1)) {
				short num5 = Comb [iComb].LF [num4].iLdg;
				float fLdg = Comb [iComb].LF [num4].fLdg;
				short nLoad = Ldg [num5].nLoad;
				for (short num6 = 1; num6 <= nLoad; num6 = (short)unchecked(num6 + 1)) {
					if (((Ldg [num5].Load [num6].Type == 2) | (Ldg [num5].Load [num6].Type == 4)) && ((fLdg * Ldg [num5].Load [num6].W0 != 0f) & (Zchk == Ldg [num5].Load [num6].Z0))) {
						flag = true;
						flag2 = true;
						break;
					}
				}
			}
			byte b = 0;
			if (flag & (Zchk > Zmin)) {
				b = (byte)(unchecked((int)b) + 1);
			}
			if (flag2 & (Zchk < Zmax)) {
				b = (byte)(unchecked((int)b) + 2);
			}
			return b;
		}
	}

	public MemberParameters[] MemberCheckParameters (float Zchk)
	{
		MemberParameters[] array;
		SolutionDetail Det;
		checked {
			array = new MemberParameters[unchecked((int)nBeam) + 1];
			Det = default(SolutionDetail);
			array [0].P = 0f;
			if (Sol [3].nLoad > 0) {
				short nSeg = Sol [3].nSeg;
				for (short num = 1; num <= nSeg; num = (short)unchecked(num + 1)) {
					if ((Sol [3].Seg [num].Z <= Zchk) & (Sol [3].Seg [num + 1].Z > Zchk)) {
						array [0].P = Sol [3].Seg [num].W0;
						break;
					}
				}
			}
			Sol [1].Forces (Zchk, ref array [0].Vy, ref array [0].Mx);
			Sol [2].Forces (Zchk, ref array [0].Vx, ref array [0].My);
		}
		array [0].Spec = (Specifications)checked((byte)Comb [iCombSol].Spec);
		array [0].Analysis = true;
		array [0].BucklingTheory = BucklingTheory;
		float num2 = Zmin;
		float num3 = num2 - 1f;
		array [0].Kx = 2.1f;
		float num4 = Zmin;
		float num5 = num4 - 1f;
		array [0].Ky = 2.1f;
		float num6 = Zmin;
		float num7 = num6 - 1f;
		array [0].Kt = 2.1f;
		short num8 = nSup;
		float num13;
		float num14;
		float num15;
		float num18;
		float num21;
		float num22;
		int num24;
		checked {
			for (short num9 = 1; num9 <= num8; num9 = (short)unchecked(num9 + 1)) {
				unchecked {
					if (Sup [num9].Z <= Zchk) {
						if ((Sup [num9].Type & 1) == 1) {
							array [0].Ky = Sup [num9].K;
							num4 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 2) == 2) {
							array [0].Kx = Sup [num9].K;
							num2 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 4) == 4) {
							array [0].Kt = Sup [num9].K;
							num6 = Sup [num9].Z;
						}
					} else {
						if ((Sup [num9].Type & 1) == 1 && num5 < num4) {
							num5 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 2) == 2 && num3 < num2) {
							num3 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 4) == 4 && num7 < num6) {
							num7 = Sup [num9].Z;
						}
					}
				}
			}
			if (num5 < num4) {
				num5 = Zmax;
				array [0].Ky = (float)CFS.Max (array [0].Ky, 2.1);
			}
			if (num3 < num2) {
				num3 = Zmax;
				array [0].Kx = (float)CFS.Max (array [0].Kx, 2.1);
			}
			if (num7 < num6) {
				num7 = Zmax;
				array [0].Kt = (float)CFS.Max (array [0].Kt, 2.1);
			}
			if (Comb [iCombSol].InflPt) {
				if ((Sol [1].nLoad > 0) & (array [0].Kx < 2f)) {
					short num10 = nSup;
					short num9 = 1;
					while (num9 <= num10 && (!((Sup [num9].Z > num4) & (Sup [num9].Z < num5)) || (Sup [num9].Type & 0x20) != 32)) {
						num9 = (short)unchecked(num9 + 1);
					}
					if (num9 > nSup) {
						Sol [1].MinimaMaxima (ref Det);
						int nR = Det.NR;
						for (int i = 1; i <= nR; i++) {
							if ((Det.ZR [i] > num4) & (Det.ZR [i] <= Zchk)) {
								if (array [0].Ky == 1f) {
									num4 = Det.ZR [i];
								}
								if (array [0].Kt == 1f) {
									num6 = Det.ZR [i];
								}
							} else if ((Det.ZR [i] > Zchk) & (Det.ZR [i] < num5)) {
								if (array [0].Ky == 1f) {
									num5 = Det.ZR [i];
								}
								if (array [0].Kt == 1f) {
									num7 = Det.ZR [i];
								}
							}
						}
					}
				}
				if ((Sol [2].nLoad > 0) & (array [0].Ky < 2f)) {
					short num11 = nSup;
					short num9 = 1;
					while (num9 <= num11 && (!((Sup [num9].Z > num2) & (Sup [num9].Z < num3)) || (Sup [num9].Type & 0x40) != 64)) {
						num9 = (short)unchecked(num9 + 1);
					}
					if (num9 > nSup) {
						Sol [2].MinimaMaxima (ref Det);
						int nR2 = Det.NR;
						for (int j = 1; j <= nR2; j++) {
							if ((Det.ZR [j] > num2) & (Det.ZR [j] <= Zchk)) {
								if (array [0].Kx == 1f) {
									num2 = Det.ZR [j];
								}
							} else if (((Det.ZR [j] > Zchk) & (Det.ZR [j] < num3)) && array [0].Kx == 1f) {
								num3 = Det.ZR [j];
							}
						}
					}
				}
			}
			array [0].Lx = num3 - num2;
			array [0].Ly = num5 - num4;
			array [0].Lt = num7 - num6;
			array [0].Cbx1 = 1f;
			array [0].Cbx2 = 1f;
			array [0].Cmx = 1f;
			float V = default(float);
			float A = default(float);
			float B = default(float);
			float ZMmin = default(float);
			float ZMmax = default(float);
			float Mmin = default(float);
			float Mmax = default(float);
			float M = default(float);
			if (Sol [1].nLoad > 0) {
				Sol [1].Forces (num4, ref V, ref A);
				Sol [1].Forces (num5, ref V, ref B);
				if (System.Math.Abs (A) > System.Math.Abs (B)) {
					CFS.Swap (ref A, ref B);
				}
				float num12 = ((B == 0f) ? (-1f) : ((0f - A) / B));
				short nSeg2 = Sol [1].nSeg;
				short num = 1;
				while (num <= nSeg2 && !((Sol [1].Seg [num].Z < num5) & (Sol [1].Seg [num + 1].Z > num4) & ((Sol [1].Seg [num].W0 != 0f) | (Sol [1].Seg [num].W1 != 0f))) && !((Sol [1].Seg [num].Z < num5) & (Sol [1].Seg [num].Z > num4) & ((Sol [1].Seg [num].P0 != 0f) | (Sol [1].Seg [num].M0 != 0f)))) {
					num = (short)unchecked(num + 1);
				}
				if (num > Sol [1].nSeg) {
					array [0].Cmx = (float)(0.6 - 0.4 * (double)num12);
				}
				Sol [1].Moments (num4, num5, ref ZMmin, ref ZMmax, ref Mmin, ref Mmax);
				if (((double)Mmax <= (double)System.Math.Abs (B) * 1.0001) & ((double)(0f - Mmin) <= (double)System.Math.Abs (B) * 1.0001)) {
					array [0].Cbx2 = (float)(1.75 + 1.05 * (double)num12 + 0.3 * (double)num12 * (double)num12);
				}
				if (System.Math.Abs (Mmin) > System.Math.Abs (Mmax)) {
					Mmax = Mmin;
				}
				float z = (float)(0.75 * (double)num4 + 0.25 * (double)num5);
				Sol [1].Forces (z, ref V, ref A);
				z = (float)(0.5 * (double)num4 + 0.5 * (double)num5);
				Sol [1].Forces (z, ref V, ref B);
				z = (float)(0.25 * (double)num4 + 0.75 * (double)num5);
				Sol [1].Forces (z, ref V, ref M);
				if (Mmax != 0f) {
					array [0].Cbx1 = (float)(12.5 * (double)System.Math.Abs (Mmax) / (2.5 * (double)System.Math.Abs (Mmax) + (double)(3f * System.Math.Abs (A)) + (double)(4f * System.Math.Abs (B)) + (double)(3f * System.Math.Abs (M))));
				}
				if (array [0].Kx >= 2f) {
					array [0].Cbx1 = 1f;
					array [0].Cmx = 1f;
				}
				if ((array [0].Ky == 0f) & (array [0].Kt == 0f)) {
					array [0].Cbx1 = 1f;
					array [0].Cbx2 = 1f;
					array [0].Cmx = 1f;
				}
			}
			array [0].Cby1 = 1f;
			array [0].Cby2 = 1f;
			array [0].Cmy = 1f;
			if (Sol [2].nLoad > 0) {
				Sol [2].Forces (num2, ref V, ref A);
				Sol [2].Forces (num3, ref V, ref B);
				if (System.Math.Abs (A) > System.Math.Abs (B)) {
					CFS.Swap (ref A, ref B);
				}
				float num12 = ((B == 0f) ? (-1f) : ((0f - A) / B));
				short nSeg3 = Sol [2].nSeg;
				short num = 1;
				while (num <= nSeg3 && !((Sol [2].Seg [num].Z < num3) & (Sol [2].Seg [num + 1].Z > num2) & ((Sol [2].Seg [num].W0 != 0f) | (Sol [2].Seg [num].W1 != 0f))) && !((Sol [2].Seg [num].Z < num5) & (Sol [2].Seg [num].Z > num4) & ((Sol [2].Seg [num].P0 != 0f) | (Sol [2].Seg [num].M0 != 0f)))) {
					num = (short)unchecked(num + 1);
				}
				if (num > Sol [2].nSeg) {
					array [0].Cmy = (float)(0.6 - 0.4 * (double)num12);
				}
				Sol [2].Moments (num2, num3, ref ZMmin, ref ZMmax, ref Mmin, ref Mmax);
				if (((double)Mmax <= (double)System.Math.Abs (B) * 1.0001) & ((double)(0f - Mmin) <= (double)System.Math.Abs (B) * 1.0001)) {
					array [0].Cby2 = (float)(1.75 + 1.05 * (double)num12 + 0.3 * (double)num12 * (double)num12);
				}
				if (System.Math.Abs (Mmin) > System.Math.Abs (Mmax)) {
					Mmax = Mmin;
				}
				float z = (float)(0.75 * (double)num2 + 0.25 * (double)num3);
				Sol [2].Forces (z, ref V, ref A);
				z = (float)(0.5 * (double)num2 + 0.5 * (double)num3);
				Sol [2].Forces (z, ref V, ref B);
				z = (float)(0.25 * (double)num2 + 0.75 * (double)num3);
				Sol [2].Forces (z, ref V, ref M);
				if (Mmax != 0f) {
					array [0].Cby1 = (float)(12.5 * (double)System.Math.Abs (Mmax) / (2.5 * (double)System.Math.Abs (Mmax) + (double)(3f * System.Math.Abs (A)) + (double)(4f * System.Math.Abs (B)) + (double)(3f * System.Math.Abs (M))));
				}
				if (array [0].Ky >= 2f) {
					array [0].Cby1 = 1f;
					array [0].Cmy = 1f;
				}
				if ((array [0].Kx == 0f) & (array [0].Kt == 0f)) {
					array [0].Cby1 = 1f;
					array [0].Cby2 = 1f;
					array [0].Cmy = 1f;
				}
			}
			num13 = 0f;
			num14 = 0f;
			num15 = 0f;
			int num16 = nBeam;
			for (int k = 1; k <= num16; k++) {
				if ((Beam [k].Z0 <= Zchk) & (Beam [k].Z1 >= Zchk)) {
					num13 += Beam [k].EI [3];
					num14 += Beam [k].EI [1];
					num15 += Beam [k].EI [2];
				}
			}
			num2 = Zmin;
			num3 = num2 - 1f;
			num4 = Zmin;
			num5 = num4 - 1f;
			short num17 = nSup;
			for (short num9 = 1; num9 <= num17; num9 = (short)unchecked(num9 + 1)) {
				unchecked {
					if (Sup [num9].Z <= Zchk) {
						if ((Sup [num9].Type & 1) == 1) {
							num4 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 2) == 2) {
							num2 = Sup [num9].Z;
						}
					} else {
						if ((Sup [num9].Type & 1) == 1 && num5 < num4) {
							num5 = Sup [num9].Z;
						}
						if ((Sup [num9].Type & 2) == 2 && num3 < num2) {
							num3 = Sup [num9].Z;
						}
					}
				}
			}
			if (num3 < Zmin) {
				num3 = Zmax;
			}
			if (num5 < Zmin) {
				num5 = Zmax;
			}
			num18 = 1f;
			if (array [0].Kx >= 2f) {
				num18 = 0f;
			} else if (Sol [1].nLoad > 0) {
				float num19 = num3;
				float num20 = num2;
				Sol [1].MinimaMaxima (ref Det);
				short nR3 = Det.NR;
				for (short num9 = 1; num9 <= nR3; num9 = (short)unchecked(num9 + 1)) {
					if ((Det.ZR [num9] > num2) & (Det.ZR [num9] < num3)) {
						if (Det.ZR [num9] < num19) {
							num19 = Det.ZR [num9];
						}
						if (Det.ZR [num9] > num20) {
							num20 = Det.ZR [num9];
						}
					}
				}
				unchecked {
					if ((num2 < Zchk && Zchk < num19) & (num19 < (num2 + num3) / 2f)) {
						num18 = 0f;
					}
					if ((num3 > Zchk && Zchk > num20) & (num20 > (num2 + num3) / 2f)) {
						num18 = 0f;
					}
				}
			}
			num21 = 1f;
			if (array [0].Ky >= 2f) {
				num21 = 0f;
			} else if (Sol [2].nLoad > 0) {
				float num19 = num5;
				float num20 = num4;
				Sol [2].MinimaMaxima (ref Det);
				short nR4 = Det.NR;
				for (short num9 = 1; num9 <= nR4; num9 = (short)unchecked(num9 + 1)) {
					if ((Det.ZR [num9] > num4) & (Det.ZR [num9] < num5)) {
						if (Det.ZR [num9] < num19) {
							num19 = Det.ZR [num9];
						}
						if (Det.ZR [num9] > num20) {
							num20 = Det.ZR [num9];
						}
					}
				}
				unchecked {
					if ((num4 < Zchk && Zchk < num19) & (num19 < (num4 + num5) / 2f)) {
						num21 = 0f;
					}
					if ((num5 > Zchk && Zchk > num20) & (num20 > (num4 + num5) / 2f)) {
						num21 = 0f;
					}
				}
			}
			num22 = 0f;
			array [0].Torsion = Torsion;
			array [0].B = 0f;
			if (Torsion) {
				short num23 = nTseg;
				for (short num = 1; num <= num23; num = (short)unchecked(num + 1)) {
					if (((Zchk >= Tseg [num].Z) & (Zchk < Tseg [num].Z + Tseg [num].L)) | (num == nTseg)) {
						array [0].B = Tseg [num].B (Zchk - Tseg [num].Z);
						num22 = Tseg [num].ECw;
						break;
					}
				}
			}
			num24 = nBeam;
		}
		for (int l = 1; l <= num24; l = checked(l + 1)) {
			array [l] = array [0];
			if ((Beam [l].Z0 <= Zchk) & (Beam [l].Z1 >= Zchk)) {
				array [l].P = array [0].P * Beam [l].EI [3] / num13;
				array [l].Mx = array [0].Mx * Beam [l].EI [1] / num14;
				array [l].Vy = array [0].Vy * Beam [l].EI [1] / num14;
				array [l].My = array [0].My * Beam [l].EI [2] / num15;
				array [l].Vx = array [0].Vx * Beam [l].EI [2] / num15;
				if (num22 > 0f) {
					array [l].B = array [0].B * Beam [l].ECw / num22;
				}
			} else {
				array [l].P = 0f;
				array [l].Mx = 0f;
				array [l].Vy = 0f;
				array [l].My = 0f;
				array [l].Vx = 0f;
				array [l].B = 0f;
			}
			array [l].iBrcFlg = (Flanges)Beam [l].iBrcFlg;
			switch (array [l].iBrcFlg) {
			case Flanges.flgBottom:
			case Flanges.flgTop:
				array [l].R = num18 * Beam [l].R;
				break;
			case Flanges.flgLeft:
			case Flanges.flgRight:
				array [l].R = num21 * Beam [l].R;
				break;
			default:
				array [l].R = 0f;
				break;
			}
			array [l].Kf = Beam [l].Kf;
			array [l].Lm = Beam [l].Lm;
			array [l].ex = Beam [l].ex;
			array [l].ey = Beam [l].ey;
			if ((array [l].P > 0f) & CFS.IsSpec1999 ((short)array [l].Spec)) {
				array [l].Cbx1 = 1f;
				array [l].Cbx2 = 1f;
				array [l].Cby1 = 1f;
				array [l].Cby2 = 1f;
			}
		}
		return array;
	}

	public void WebCripCheckPoints (ref short nChk, ref float[] Zchk, ref short[] Schk, ref WebCripParameters[] Param)
	{
		nChk = 0;
		checked {
			bool fastened;
			float num4 = default(float);
			if (Sol [1].nLoad > 0) {
				short num = nSup;
				for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
					if ((Sup [num2].Type & 2) == 2) {
						float z = Sup [num2].Z;
						float wid = Sup [num2].Wid;
						fastened = Sup [num2].Fastened;
						short nNode = Sol [1].nNode;
						for (short num3 = 1; num3 <= nNode; num3 = (short)unchecked(num3 + 1)) {
							if (Sol [1].Znode [num3] == z) {
								num4 = Sol [1].V [num3, 1];
								if (num3 > 1) {
									num4 += Sol [1].V [num3 - 1, 2];
								}
								break;
							}
						}
						AddWebCripCheck (z, 1, num4, wid, fastened, ref nChk, ref Zchk, ref Param);
					}
				}
			}
			if (Sol [2].nLoad > 0) {
				short num5 = nSup;
				for (short num2 = 1; num2 <= num5; num2 = (short)unchecked(num2 + 1)) {
					if ((Sup [num2].Type & 1) == 1) {
						float z = Sup [num2].Z;
						float wid = Sup [num2].Wid;
						fastened = Sup [num2].Fastened;
						short nNode2 = Sol [2].nNode;
						for (short num3 = 1; num3 <= nNode2; num3 = (short)unchecked(num3 + 1)) {
							if (Sol [2].Znode [num3] == z) {
								num4 = Sol [2].V [num3, 1];
								if (num3 > 1) {
									num4 += Sol [2].V [num3 - 1, 2];
								}
								break;
							}
						}
						AddWebCripCheck (z, 2, num4, wid, fastened, ref nChk, ref Zchk, ref Param);
					}
				}
			}
			fastened = false;
			short nLF = Comb [iComb].nLF;
			for (short num6 = 1; num6 <= nLF; num6 = (short)unchecked(num6 + 1)) {
				short num7 = Comb [iComb].LF [num6].iLdg;
				float fLdg = Comb [iComb].LF [num6].fLdg;
				if (fLdg != 0f) {
					ref Loading reference = ref Ldg [num7];
					short nLoad = reference.nLoad;
					for (short num8 = 1; num8 <= nLoad; num8 = (short)unchecked(num8 + 1)) {
						if ((reference.Load [num8].Type == 2) & (reference.Load [num8].W0 != 0f)) {
							float z = reference.Load [num8].Z0;
							float wid = reference.Load [num8].Wid;
							if (System.Math.Abs (System.Math.Sin (reference.Load [num8].Ang)) > 1E-05) {
								num4 = (float)((double)(fLdg * reference.Load [num8].W0) * System.Math.Sin (reference.Load [num8].Ang));
								AddWebCripCheck (z, 1, num4, wid, fastened, ref nChk, ref Zchk, ref Param);
							}
							if (System.Math.Abs (System.Math.Cos (reference.Load [num8].Ang)) > 1E-05) {
								num4 = (float)((double)(fLdg * reference.Load [num8].W0) * System.Math.Cos (reference.Load [num8].Ang));
								AddWebCripCheck (z, 2, num4, wid, fastened, ref nChk, ref Zchk, ref Param);
							}
						}
					}
				}
			}
			if (nChk == 0) {
				return;
			}
			if (2 * nChk > Information.UBound (Zchk)) {
				Zchk = (float[])Utils.CopyArray (Zchk, new float[2 * nChk + 1]);
			}
			if (2 * nChk > Information.UBound (Param)) {
				Param = (WebCripParameters[])Utils.CopyArray (Param, new WebCripParameters[2 * nChk + 1]);
			}
			if (2 * nChk > Information.UBound (Schk)) {
				Schk = (short[])Utils.CopyArray (Schk, new short[2 * nChk + 1]);
			}
			short num9 = nChk;
			for (short num10 = 1; num10 <= num9; num10 = (short)unchecked(num10 + 1)) {
				byte b = 0;
				short num11 = nBeam;
				for (short num12 = 1; num12 <= num11; num12 = (short)unchecked(num12 + 1)) {
					if ((Zchk [num10] == Beam [num12].Z0) & (Zchk [num10] > Zmin)) {
						b = (byte)(b | 1);
					}
					if ((Zchk [num10] == Beam [num12].Z1) & (Zchk [num10] < Zmax)) {
						b = (byte)(b | 2);
					}
				}
				switch (b) {
				case 0:
					Schk [num10] = 0;
					break;
				case 1:
					Schk [num10] = -1;
					break;
				case 2:
					Schk [num10] = 1;
					break;
				case 3:
					Schk [num10] = -1;
					nChk++;
					Zchk [nChk] = Zchk [num10];
					Schk [nChk] = 1;
					Param [nChk] = Param [num10];
					break;
				}
			}
			short num13 = (short)(nChk - 1);
			for (short num10 = 1; num10 <= num13; num10 = (short)unchecked(num10 + 1)) {
				if ((Zchk [num10] > Zchk [num10 + 1]) | ((Zchk [num10] == Zchk [num10 + 1]) & (Schk [num10] > Schk [num10 + 1]))) {
					CFS.Swap (ref Zchk [num10], ref Zchk [num10 + 1]);
					CFS.Swap (ref Schk [num10], ref Schk [num10 + 1]);
					ref LoadDirections dir = ref Param [num10].Dir;
					object A = dir;
					ref LoadDirections dir2 = ref Param [num10 + 1].Dir;
					object B = dir2;
					CFS.Swap (ref A, ref B);
					unchecked {
						dir2 = (LoadDirections)Conversions.ToByte (B);
						dir = (LoadDirections)Conversions.ToByte (A);
					}
					CFS.Swap (ref Param [num10].P, ref Param [num10 + 1].P);
					CFS.Swap (ref Param [num10].N, ref Param [num10 + 1].N);
					CFS.Swap (ref Param [num10].Fastened, ref Param [num10 + 1].Fastened);
					if (num10 > 1) {
						num10 = (short)(num10 - 2);
					}
				}
			}
			short num14 = nChk;
			for (short num10 = 1; num10 <= num14; num10 = (short)unchecked(num10 + 1)) {
				Param [num10].Zload = Zmax - Zmin;
				short num15 = nChk;
				for (short num12 = 1; num12 <= num15; num12 = (short)unchecked(num12 + 1)) {
					if ((Param [num12].Dir == Param [num10].Dir) & (System.Math.Sign (Param [num12].P) == -System.Math.Sign (Param [num10].P))) {
						float z = System.Math.Abs (Zchk [num10] - Zchk [num12]) - Param [num10].N / 2f - Param [num12].N / 2f;
						if (z < Param [num10].Zload) {
							Param [num10].Zload = z;
						}
					}
				}
				if (Param [num10].Zload < 0f) {
					Param [num10].Zload = 0f;
				}
			}
		}
	}

	private void AddWebCripCheck (float Z, byte Dir, float P, float Wid, bool Fastened, ref short nCheck, ref float[] Zcheck, ref WebCripParameters[] Param)
	{
		int num = nCheck;
		for (int i = 1; i <= num; i = checked(i + 1)) {
			if (((double)System.Math.Abs (Z - Zcheck [i]) <= 0.0005) & ((uint)Dir == (uint)Param [i].Dir) & (System.Math.Sign (P) == System.Math.Sign (Param [i].P))) {
				Param [i].P = Param [i].P + P;
				if (Wid < Param [i].N) {
					Param [i].N = Wid;
				}
				return;
			}
		}
		checked {
			nCheck++;
			if (nCheck > Information.UBound (Zcheck)) {
				Zcheck = (float[])Utils.CopyArray (Zcheck, new float[2 * nCheck + 1]);
			}
			if (nCheck > Information.UBound (Param)) {
				Param = (WebCripParameters[])Utils.CopyArray (Param, new WebCripParameters[2 * nCheck + 1]);
			}
			Zcheck [nCheck] = Z;
		}
		Param [nCheck].Dir = (LoadDirections)Dir;
		Param [nCheck].P = P;
		Param [nCheck].N = Wid;
		Param [nCheck].Fastened = Fastened;
		Param [nCheck].Spec = (Specifications)checked((byte)Comb [iComb].Spec);
	}

	public void WebCripCheckParameters (float Zchk, ref WebCripParameters[] Param)
	{
		float V = default(float);
		Sol [(uint)Param [0].Dir].Forces (Zchk, ref V, ref Param [0].M);
		float num = 0f;
		byte b = nBeam;
		byte b2 = 1;
		while ((uint)b2 <= (uint)b) {
			if ((Beam [b2].Z0 <= Zchk) & (Beam [b2].Z1 >= Zchk)) {
				num += Beam [b2].EI [(uint)Param [0].Dir];
			}
			checked {
				b2 = (byte)unchecked((uint)(b2 + 1));
			}
		}
		byte b3 = nBeam;
		b2 = 1;
		while ((uint)b2 <= (uint)b3) {
			Param [b2] = Param [0];
			if ((Beam [b2].Z0 <= Zchk) & (Beam [b2].Z1 >= Zchk)) {
				Param [b2].P = Param [0].P * Beam [b2].EI [(uint)Param [0].Dir] / num;
				Param [b2].M = Param [0].M * Beam [b2].EI [(uint)Param [0].Dir] / num;
				Param [b2].Zend = Zchk - Beam [b2].Z0 - Param [b2].N / 2f;
				float num2 = Beam [b2].Z1 - Zchk - Param [b2].N / 2f;
				if (num2 < Param [b2].Zend) {
					Param [b2].Zend = num2;
				}
				if (Param [b2].Zend < 0f) {
					Param [b2].Zend = 0f;
				}
			} else {
				Param [b2].P = 0f;
				Param [b2].M = 0f;
				Param [b2].Zend = 0f;
			}
			checked {
				b2 = (byte)unchecked((uint)(b2 + 1));
			}
		}
	}

	public void ZExtents ()
	{
		Zmin = 1E+09f;
		Zmax = -1E+09f;
		short num = nBeam;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				if (Beam [num2].Z0 < Zmin) {
					Zmin = Beam [num2].Z0;
				}
				if (Beam [num2].Z1 > Zmax) {
					Zmax = Beam [num2].Z1;
				}
			}
			short num3 = nSup;
			for (short num2 = 1; num2 <= num3; num2 = (short)unchecked(num2 + 1)) {
				if (Sup [num2].Z < Zmin) {
					Zmin = Sup [num2].Z;
				}
				if (Sup [num2].Z > Zmax) {
					Zmax = Sup [num2].Z;
				}
			}
			if (Zmax < Zmin) {
				Zmin = 0f;
				Zmax = 0f;
			}
		}
	}
}
