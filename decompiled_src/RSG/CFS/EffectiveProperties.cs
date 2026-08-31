// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace RSG.CFS;

internal class EffectiveProperties
{
	private struct LipType
	{
		public float W;

		public float Ang;

		public float D;

		public float Dh;

		public float Dps;

		public float X1;

		public float Y1;

		public float W2;

		public short Elem;
	}

	private float Xcge;

	private float Ycge;

	private float Ae;

	private float Ixe;

	private float Iye;

	private float Ixye;

	private float Sxte;

	private float Sxbe;

	private float Sxe;

	private float Syle;

	private float Syre;

	private float Sye;

	private string strMsge;

	private string strTraceEff;

	private bool blnColdWorkAllowed;

	private bool blnRationalAnalysis;

	private bool blnIterate;

	private float LambdaMax;

	private float Xmine;

	private float Xmaxe;

	private float Ymine;

	private float Ymaxe;

	private float P1;

	private float Mx1;

	private float My1;

	private byte effMode1;

	private short Spec1;

	private float E;

	private float Er;

	private short nPart;

	private float ConnSpa;

	private float Depth;

	private float X;

	private float Y;

	private float T;

	private float W;

	private float A;

	private float Sn;

	private float Cs;

	private float X0;

	private float Y0;

	private float F0;

	private float X1;

	private float Y1;

	private float F1;

	private float X2;

	private float Y2;

	private float F2;

	private float F3;

	private float Xh1;

	private float Yh1;

	private float Fh1;

	private float Xh2;

	private float Yh2;

	private float Fh2;

	private float XII;

	private float YII;

	private float FII1;

	private float FII2;

	private float W1;

	private float W2;

	private float Dh;

	private float SA;

	private float SAX;

	private float SAY;

	private float SAX2;

	private float SAY2;

	private float SAXY;

	private float Xc;

	private float Yc;

	private float DW;

	private float DA;

	private float M1;

	private float M2;

	private float K;

	private float K0;

	private float Ku;

	private float Ka;

	private float Rk;

	private string strRk;

	private float L;

	private float Si;

	private float Be;

	private float B0;

	private float B1;

	private float B2;

	private float ho;

	private float bo;

	private bool blnStfFlg;

	private LipType Lip;

	private float S;

	private float Ds;

	private float Ist;

	private float Ia;

	private float Ri;

	private float C1;

	private float C2;

	private float Expn;

	private bool blnSS;

	private bool blnUseProcII;

	private float Fy;

	private short iElemGrp;

	private short nElemGrp;

	private bool blnEdgeStiffened;

	private bool blnUseIS;

	private float SH;

	private bool blnChg;

	private string strMsg;

	private float Ag;

	private float Bp;

	private float W0;

	private float C;

	private float Asi;

	private float Isi;

	private float Xci;

	private float Yci;

	private float SGW;

	private float SDW;

	private float R;

	private float Fcr;

	private float Lc;

	private float Kc;

	private float D;

	private float Arc;

	private float Ang;

	private float SnA;

	private float CsA;

	private float Xac;

	private float Yac;

	private float AX;

	private float AY;

	private float AX2;

	private float AY2;

	private float AXY;

	private string strEqLambda;

	private string strEqRho;

	private string strEqB;

	private string strEqW;

	private string strEqDs;

	private string strEqS;

	private string strEqIa1;

	private string strEqIa2;

	private string strEqKred;

	private string strEqSi;

	private string strEqK1;

	private string strEqK2;

	private string strEqB1a;

	private string strEqB2a;

	private string strEqB2b;

	private string strEqB1c;

	private string strEqB2c;

	private string strEqB1d;

	private string strEqB2d;

	private string strEqBhole;

	private string strEqLipSi;

	private string strEqLipK1;

	private string strEqLipK2;

	private string strEqLipK3;

	private string strEqLipK4;

	private string strEqLipRho3;

	private string strEqLipRho4;

	private string strRho;

	private string strEqISk;

	private string strEqISR;

	private string strEqISkloc;

	private string strEqISkd;

	private string strEqISbeta;

	private string strEqISB;

	private string strEqISRho1;

	private string strEqISRho;

	private string strEqISL;

	private string strEqISFcrl;

	private string strEqRhoIIa;

	private string strEqRhoIIb;

	private string strEqRho1;

	private string strIS;

	private string strEqFcrl;

	private string strEqFc;

	private string strEqLambdat;

	private string strEqRhot;

	private string strEqRhom;

	private string strEqEr;

	private const float Lmax = 0.6732051f;

	private const float SiMax = -0.236067981f;

	private const float Ks = 4f;

	internal void ResetProp (Section Section, byte effMode)
	{
		ref Section.PropertiesType prop = ref Section.Prop;
		if (effMode == 0) {
			Xcge = prop.Xcgn;
			Ycge = prop.Ycgn;
			Ae = prop.An;
			Ixe = prop.Ixn;
			Iye = prop.Iyn;
			Ixye = prop.Ixyn;
			Sxte = prop.Sxtn;
			Sxbe = prop.Sxbn;
			Sxe = prop.Sxn;
			Syle = prop.Syln;
			Syre = prop.Syrn;
			Sye = prop.Syn;
		} else {
			Xcge = prop.Xcg;
			Ycge = prop.Ycg;
			Ae = prop.A;
			Ixe = prop.Ix;
			Iye = prop.Iy;
			Ixye = prop.Ixy;
			Sxte = prop.Sxt;
			Sxbe = prop.Sxb;
			Sxe = prop.Sx;
			Syle = prop.Syl;
			Syre = prop.Syr;
			Sye = prop.Sy;
		}
		strTraceEff = string.Empty;
		strMsge = string.Empty;
		blnColdWorkAllowed = true;
		blnRationalAnalysis = false;
		blnIterate = false;
		LambdaMax = 0.0862222239f;
		int num = Section.nPart;
		for (int i = 1; i <= num; i = checked(i + 1)) {
			Part part = Section.Part [i];
			part.Be1 = part.Element [1].Wid;
			part.Ben = part.Element [part.nElem].Wid;
			part = null;
		}
		ref Section.EffectivePropertiesType propEff = ref Section.PropEff;
		propEff.Xcg = Xcge;
		propEff.Ycg = Ycge;
		propEff.A = Ae;
		propEff.Ix = Ixe;
		propEff.Iy = Iye;
		propEff.Ixy = Ixye;
		propEff.Sxt = Sxte;
		propEff.Sxb = Sxbe;
		propEff.Sx = Sxe;
		propEff.Syl = Syle;
		propEff.Syr = Syre;
		propEff.Sy = Sye;
		propEff.ColdWorkAllowed = blnColdWorkAllowed;
		propEff.RationalAnalysis = blnRationalAnalysis;
		propEff.Iterate = blnIterate;
		propEff.LambdaMax = LambdaMax;
		propEff.Trace = strTraceEff;
		propEff.Msg = strMsge;
	}

	internal void EffProp (Section Section, float P, float Mx, float My, byte effMode, short Spec)
	{
		P1 = P;
		Mx1 = Mx;
		My1 = My;
		effMode1 = effMode;
		Spec1 = Spec;
		strIS = "B5";
		blnSS = Section.Material.IsStainless ();
		strEqEr = string.Empty;
		if (blnSS) {
			strEqW = "ASCE Eq. A-1";
			strEqB = "ASCE Eq. A-1";
			strEqRho = "ASCE Eq. A-2";
			strEqEr = "ASCE Eq. A-7";
			strEqRhoIIa = string.Empty;
			strEqRhoIIb = string.Empty;
			strEqLambda = "ASCE Eq. A-3";
			strEqDs = "ASCE Eq. A-45";
			strEqS = "ASCE Eq. A-46";
			strEqIa1 = "ASCE Eq. A-47";
			strEqIa2 = "ASCE Eq. A-47";
			strEqKred = "ASCE Table A-1";
			strEqSi = "ASCE Eq. A-10";
			strEqK1 = "ASCE Eq. A-11";
			strEqK2 = "ASCE Eq. A-17";
			strEqB1a = "ASCE Eq. A-12";
			strEqB2a = "ASCE Eq. A-13";
			strEqB2b = "ASCE Eq. A-14";
			strEqB1c = "ASCE Eq. A-15";
			strEqB2c = "ASCE Eq. A-16";
			strEqB1d = "ASCE Eq. A-18";
			strEqB2d = "ASCE Eq. A-19";
			strEqBhole = "ASCE Eq. A-9";
			strEqISB = "ASCE Eq. A-51";
			strEqISRho1 = string.Empty;
			strEqISRho = "ASCE Eq. A-52";
			strEqISL = "ASCE Eq. A-53";
			strEqISFcrl = "ASCE Eq. A-54";
			strEqISk = "ASCE Eq. A-55";
			strEqISR = "ASCE Eq. A-56";
			strEqISkloc = "ASCE A-62";
			strEqISkd = "ASCE Eq. A-63";
			strEqISbeta = "AISI Eq. A-64";
		} else if (CFS.IsSpec1999 (Spec)) {
			strEqW = "Eq. B2.1-1";
			strEqB = "Eq. B2.1-2";
			strEqRho = "Eq. B2.1-3";
			strEqRhoIIa = "Eq. B2.1-8";
			strEqRhoIIb = "Eq. B2.1-9";
			strEqLambda = "Eq. B2.1-4";
			strEqDs = "Eq. B4.2-9";
			strEqS = "Eq. B4-1";
			strEqIa1 = "Eq. B4.2-4";
			strEqIa2 = "Eq. B4.2-11";
			strEqKred = "Eq. B4.2-8";
			strEqSi = "Eq. B2.3-5";
			strEqK1 = "Eq. B2.3-4";
			strEqK2 = "Eq. B2.3-4";
			strEqB1a = "Eq. B2.3-1";
			strEqB2a = "Eq. B2.3-2";
			strEqB2b = "Eq. B2.3-3";
			strEqB1c = "Eq. B2.3-1";
			strEqB2c = "Eq. B2.3-2";
			strEqB1d = "Eq. B2.3-1";
			strEqB2d = "Eq. B2.3-2";
			strEqBhole = "Eq. B2.2-2";
			strEqISB = "Eq. B5.1-1";
			strEqISRho1 = "Eq. B5.1-2";
			strEqISRho = "Eq. B5.1-3";
			strEqISL = "Eq. B5.1-4";
			strEqISFcrl = "Eq. B5.1-5";
			strEqISk = "Eq. B5.1-6";
			strEqISR = "Eq. B5.1-8";
			strEqISkloc = "Eq. B5.1.2-1";
			strEqISkd = "Eq. B5.1.2-2";
			strEqISbeta = "Eq. B5.1.2-3";
		} else if (CFS.IsSpec2001 (Spec)) {
			strEqW = "Eq. B2.1-1";
			strEqB = "Eq. B2.1-2";
			strEqRho = "Eq. B2.1-3";
			strEqRhoIIa = "Eq. B2.1-9";
			strEqRhoIIb = "Eq. B2.1-10";
			strEqLambda = "Eq. B2.1-4";
			strEqDs = "Eq. B4.2-7";
			strEqS = "Eq. B4-1";
			strEqIa1 = "Eq. B4.2-10";
			strEqIa2 = "Eq. B4.2-10";
			strEqKred = "Table B4.2";
			strEqSi = "Eq. B2.3-1";
			strEqK1 = "Eq. B2.3-2";
			strEqK2 = "Eq. B2.3-8";
			strEqB1a = "Eq. B2.3-3";
			strEqB2a = "Eq. B2.3-4";
			strEqB2b = "Eq. B2.3-5";
			strEqB1c = "Eq. B2.3-6";
			strEqB2c = "Eq. B2.3-7";
			strEqB1d = "Eq. B2.3-9";
			strEqB2d = "Eq. B2.3-10";
			strEqBhole = "Eq. B2.2-2";
			strEqISB = "Eq. B5.1-1";
			strEqISRho1 = "Eq. B5.1-2";
			strEqISRho = "Eq. B5.1-3";
			strEqISL = "Eq. B5.1-4";
			strEqISFcrl = "Eq. B5.1-5";
			strEqISk = "Eq. B5.1-6";
			strEqISR = "Eq. B5.1-8";
			strEqISkloc = "Eq. B5.1.2-1";
			strEqISkd = "Eq. B5.1.2-2";
			strEqISbeta = "Eq. B5.1.2-3";
		} else if (CFS.IsSpec2004 (Spec)) {
			strEqW = "Eq. B2.1-1";
			strEqB = "Eq. B2.1-2";
			strEqRho = "Eq. B2.1-3";
			strEqRhoIIa = "Eq. B2.1-9";
			strEqRhoIIb = "Eq. B2.1-10";
			strEqLambda = "Eq. B2.1-4";
			strEqDs = "Eq. B4.2-7";
			strEqS = "Eq. B4-1";
			strEqIa1 = "Eq. B4.2-10";
			strEqIa2 = "Eq. B4.2-10";
			strEqKred = "Table B4.2";
			strEqSi = "Eq. B2.3-1";
			strEqK1 = "Eq. B2.3-2";
			strEqK2 = "Eq. B2.3-8";
			strEqB1a = "Eq. B2.3-3";
			strEqB2a = "Eq. B2.3-4";
			strEqB2b = "Eq. B2.3-5";
			strEqB1c = "Eq. B2.3-6";
			strEqB2c = "Eq. B2.3-7";
			strEqB1d = "Eq. B2.3-9";
			strEqB2d = "Eq. B2.3-10";
			strEqBhole = "Eq. B2.2-2";
			strEqLipSi = "Eq. B3.2-1";
			strEqLipK1 = "Eq. B3.2-2";
			strEqLipK2 = "Eq. B3.2-3";
			strEqLipK3 = "Eq. B3.2-5";
			strEqLipK4 = "Eq. B3.2-7";
			strEqLipRho3 = "Eq. B3.2-4";
			strEqLipRho4 = "Eq. B3.2-6";
			strEqISB = "Eq. B5.1-1";
			strEqISRho1 = "Eq. B5.1-2";
			strEqISRho = "Eq. B5.1-3";
			strEqISL = "Eq. B5.1-4";
			strEqISFcrl = "Eq. B5.1-5";
			strEqISk = "Eq. B5.1-6";
			strEqISR = "Eq. B5.1-8";
			strEqISkloc = "Eq. B5.1.2-1";
			strEqISkd = "Eq. B5.1.2-2";
			strEqISbeta = "Eq. B5.1.2-3";
		} else if (CFS.IsSpec2007 (Spec) | CFS.IsSpec2010 (Spec) | CFS.IsSpec2012 (Spec)) {
			strEqW = "Eq. B2.1-1";
			strEqB = "Eq. B2.1-2";
			strEqRho = "Eq. B2.1-3";
			strEqFcrl = "Eq. B2.1-5";
			strEqRhoIIa = "Eq. B2.1-8";
			strEqRhoIIb = "Eq. B2.1-9";
			strEqLambda = "Eq. B2.1-4";
			strEqRhot = "Eq. B2.5-2";
			strEqLambdat = "Eq. B2.5-3";
			strEqFc = "Eq. B2.5-4";
			strEqRhom = "Eq. B2.5-5";
			strEqDs = "Eq. B4-6";
			strEqS = "Eq. B4-7";
			strEqIa1 = "Eq. B4-8";
			strEqIa2 = "Eq. B4-8";
			strEqKred = "Table B4-1";
			strEqSi = "Eq. B2.3-1";
			strEqK1 = "Eq. B2.3-2";
			strEqK2 = "Eq. B2.3-8";
			strEqB1a = "Eq. B2.3-3";
			strEqB2a = "Eq. B2.3-4";
			strEqB2b = "Eq. B2.3-5";
			strEqB1c = "Eq. B2.3-6";
			strEqB2c = "Eq. B2.3-7";
			strEqB1d = "Eq. B2.3-9";
			strEqB2d = "Eq. B2.3-10";
			strEqBhole = "Eq. B2.2-2";
			strEqLipSi = "Eq. B3.2-1";
			strEqLipK1 = "Eq. B3.2-2";
			strEqLipK2 = "Eq. B3.2-3";
			strEqLipK3 = "Eq. B3.2-5";
			strEqLipK4 = "Eq. B3.2-7";
			strEqLipRho3 = "Eq. B3.2-4";
			strEqLipRho4 = "Eq. B3.2-6";
			strEqISB = "Eq. B5.1-1";
			strEqISRho1 = string.Empty;
			strEqISRho = "Eq. B5.1-2";
			strEqISL = "Eq. B5.1-3";
			strEqISFcrl = "Eq. B5.1-4";
			strEqISk = "Eq. B5.1-5";
			strEqISR = "Eq. B5.1-6";
			strEqISkloc = "Eq. B5.1.2-1";
			strEqISkd = "Eq. B5.1.2-2";
			strEqISbeta = "Eq. B5.1.2-3";
		} else {
			strEqW = "Eq. 1.1-1";
			strEqB = "Eq. 1.1-1";
			strEqRho = "Eq. 1.1-2";
			strEqFcrl = "Eq. 1.1-4";
			strEqRhoIIa = "Eq. 1.1-6";
			strEqRhoIIb = "Eq. 1.1-7";
			strEqLambda = "Eq. 1.1-3";
			strEqRhot = "Eq. 1.1.4-2";
			strEqLambdat = "Eq. 1.1.4-3";
			strEqFc = "Eq. 1.1.4-4";
			strEqRhom = "Eq. 1.1.4-5";
			strEqDs = "Eq. 1.3-6";
			strEqS = "Eq. 1.3-7";
			strEqIa1 = "Eq. 1.3-8";
			strEqIa2 = "Eq. 1.3-8";
			strEqKred = "Table 1.3-1";
			strEqSi = "Eq. 1.1.2-1";
			strEqK1 = "Eq. 1.1.2-2";
			strEqK2 = "Eq. 1.1.2-8";
			strEqB1a = "Eq. 1.1.2-3";
			strEqB2a = "Eq. 1.1.2-4";
			strEqB2b = "Eq. 1.1.2-5";
			strEqB1c = "Eq. 1.1.2-6";
			strEqB2c = "Eq. 1.1.2-7";
			strEqB1d = "Eq. 1.1.2-9";
			strEqB2d = "Eq. 1.1.2-10";
			strEqBhole = "Eq. 1.1.1-2";
			strEqLipSi = "Eq. 1.2.2-1";
			strEqLipK1 = "Eq. 1.2.2-2";
			strEqLipK2 = "Eq. 1.2.2-3";
			strEqLipK3 = "Eq. 1.2.2-5";
			strEqLipK4 = "Eq. 1.2.2-7";
			strEqLipRho3 = "Eq. 1.2.2-4";
			strEqLipRho4 = "Eq. 1.2.2-6";
			strEqISB = "Eq. 1.4.1-1";
			strEqISRho1 = string.Empty;
			strEqISRho = "Eq. 1.4.1-2";
			strEqISL = "Eq. 1.4.1-3";
			strEqISFcrl = "Eq. 1.4.1-4";
			strEqISk = "Eq. 1.4.1-5";
			strEqISR = "Eq. 1.4.1-6";
			strEqISkloc = "Eq. 1.4.1.2-1";
			strEqISkd = "Eq. 1.4.1.2-2";
			strEqISbeta = "Eq. 1.4.1.2-3";
			strIS = "1.4.1";
		}
		Ku = 0.43f;
		Section section = Section;
		Xmine = section.Xmine;
		Xmaxe = section.Xmaxe;
		Ymine = section.Ymine;
		Ymaxe = section.Ymaxe;
		section = null;
		strTraceEff = string.Empty;
		ref Section.PropertiesType prop = ref Section.Prop;
		if (effMode == 0) {
			SA = prop.An;
			SAX = prop.An * prop.Xcgn;
			SAY = prop.An * prop.Ycgn;
			SAX2 = prop.Iyn + prop.An * prop.Xcgn * prop.Xcgn;
			SAY2 = prop.Ixn + prop.An * prop.Ycgn * prop.Ycgn;
			SAXY = prop.Ixyn + prop.An * prop.Xcgn * prop.Ycgn;
		} else {
			SA = prop.A;
			SAX = prop.A * prop.Xcg;
			SAY = prop.A * prop.Ycg;
			SAX2 = prop.Iy + prop.A * prop.Xcg * prop.Xcg;
			SAY2 = prop.Ix + prop.A * prop.Ycg * prop.Ycg;
			SAXY = prop.Ixy + prop.A * prop.Xcg * prop.Ycg;
		}
		blnColdWorkAllowed = true;
		blnRationalAnalysis = false;
		LambdaMax = 0.0862222239f;
		M1 = Mx / Ixe;
		M2 = My / Iye;
		F1 = Conversions.ToSingle (Operators.AddObject (Operators.AddObject (P / Ae, Interaction.IIf (Mx >= 0f, Mx / Sxte, (0f - Mx) / Sxbe)), Interaction.IIf (My >= 0f, My / Syre, (0f - My) / Syle)));
		F2 = Conversions.ToSingle (Operators.AddObject (Operators.AddObject (P / Ae, Interaction.IIf (Mx >= 0f, (0f - Mx) / Sxbe, Mx / Sxte)), Interaction.IIf (My >= 0f, (0f - My) / Syle, My / Syre)));
		E = Section.Material.Eo [2];
		Er = E * (Section.Material.EsEo (F1, Conversions.ToShort (Interaction.IIf (F1 > 0f, StressDirections.dirLC, StressDirections.dirLT))) + Section.Material.EsEo (F2, Conversions.ToShort (Interaction.IIf (F2 > 0f, StressDirections.dirLC, StressDirections.dirLT)))) / 2f;
		if (blnSS && effMode == 2) {
			E = Er;
			ref string reference = ref strTraceEff;
			ref string reference2 = ref reference;
			reference = reference2 + "  Reduced modulus for deflection: Er=" + Units.DisplayStress (Er, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqEr + "\r\n";
		}
		Fy = Section.DesignFy (StressDirections.dirLC, (Specifications)checked((byte)Spec1));
		nPart = Section.nPart;
		ConnSpa = Section.ConnSpacing;
		Depth = 0f;
		if (Mx != 0f && P == 0f && My == 0f) {
			Depth = Section.Ymax - Section.Ymin;
		}
		if (My != 0f && P == 0f && Mx == 0f) {
			Depth = Section.Xmax - Section.Xmin;
		}
		short num = Section.nPart;
		checked {
			for (short num2 = 1; num2 <= num; num2 = (short)unchecked(num2 + 1)) {
				ref string reference3 = ref strTraceEff;
				reference3 = reference3 + "  Effective width calculations for " + Section.Part [num2].Name + "\r\n";
				Part part = Section.Part [num2];
				T = part.Thickness;
				X = part.XPosition - part.Xcg - Xcge;
				Y = part.YPosition - part.Ycg - Ycge;
				part = null;
				Part part2 = Section.Part [num2];
				ElementGroupType[] array = new ElementGroupType[unchecked((int)part2.nElem) + 1];
				nElemGrp = 0;
				short nElem = part2.nElem;
				for (short num3 = 1; num3 <= nElem; num3 = (short)unchecked(num3 + 1)) {
					nElemGrp++;
					array [nElemGrp].iElemFirst = num3;
					array [nElemGrp].iElemLast = num3;
					if (((num3 >= 2) & (num3 <= unchecked((int)part2.nElem) - 2)) | part2.Closed) {
						X1 = X + part2.Element [num3].X0;
						Y1 = Y + part2.Element [num3].Y0;
						X2 = X + part2.Element [num3].X1;
						Y2 = Y + part2.Element [num3].Y1;
						F1 = P / Ae + M1 * Y1 + M2 * X1;
						F2 = P / Ae + M1 * Y2 + M2 * X2;
						array [nElemGrp].X1 = X1;
						array [nElemGrp].Y1 = Y1;
						array [nElemGrp].F1 = F1;
						array [nElemGrp].X2 = X2;
						array [nElemGrp].Y2 = Y2;
						array [nElemGrp].F2 = F2;
						if ((F1 >= 0f) & (F2 >= 0f) & (part2.Element [num3].K == 0f)) {
							float num4 = part2.Element [num3].Wid;
							float num5 = num4;
							short num6 = num3;
							float num7 = 0f;
							int nElem2 = part2.nElem;
							for (int i = 1; i <= nElem2; i++) {
								num7 = (float)CFS.Max (num7, part2.Distance (part2.Element [num3], part2.Element [i].X0, part2.Element [i].Y0));
								num7 = (float)CFS.Max (num7, part2.Distance (part2.Element [num3], part2.Element [i].X1, part2.Element [i].Y1));
							}
							while (true) {
								if (part2.Closed) {
									unchecked {
										num6 = (short)((num6 == part2.nElem) ? 1 : checked((short)(num6 + 1)));
										if (num6 == num3) {
											break;
										}
									}
								} else {
									num6 = (short)(num6 + 1);
									if (num6 >= part2.nElem) {
										break;
									}
								}
								X1 = X + part2.Element [num6].X0;
								Y1 = Y + part2.Element [num6].Y0;
								X2 = X + part2.Element [num6].X1;
								Y2 = Y + part2.Element [num6].Y1;
								F1 = P / Ae + M1 * Y1 + M2 * X1;
								F2 = P / Ae + M1 * Y2 + M2 * X2;
								if (((F1 < 0f) | (F2 < 0f)) || part2.Element [num6].K > 0f || part2.Distance (part2.Element [num3], part2.Element [num6].X0, part2.Element [num6].Y0) >= num7 / 2f || part2.Distance (part2.Element [num3], part2.Element [num6].X1, part2.Element [num6].Y1) >= num7 / 2f) {
									break;
								}
								num5 += part2.Element [num6].Wid;
								if (part2.CollinearElements (part2.Element [num3], part2.Element [num6])) {
									num4 += part2.Element [num6].Wid;
									if ((double)num4 >= 0.5 * (double)num5) {
										array [nElemGrp].iElemLast = num6;
										array [nElemGrp].X2 = X2;
										array [nElemGrp].Y2 = Y2;
										array [nElemGrp].F2 = F2;
									}
								}
							}
							num3 = array [nElemGrp].iElemLast;
							if (num3 < array [nElemGrp].iElemFirst) {
								short num8 = 0;
								short num9 = (short)(nElemGrp - 1);
								for (num6 = 1; num6 <= num9; num6 = (short)unchecked(num6 + 1)) {
									if (array [num6].iElemLast == num3) {
										num8 = num6;
										break;
									}
								}
								ref short reference4 = ref nElemGrp;
								reference4 = (short)unchecked(reference4 - num8);
								short num10 = nElemGrp;
								for (num6 = 1; num6 <= num10; num6 = (short)unchecked(num6 + 1)) {
									array [num6] = array [(short)unchecked(num6 + num8)];
								}
								break;
							}
						}
					}
				}
				part2 = null;
				blnStfFlg = true;
				short num11 = nElemGrp;
				for (iElemGrp = 1; iElemGrp <= num11; iElemGrp = (short)unchecked(iElemGrp + 1)) {
					EffWidth (Section, Section.Part [num2], array [iElemGrp]);
					if ((iElemGrp == nElemGrp - 2) & !Section.Part [num2].Closed) {
						blnStfFlg = true;
						iElemGrp = nElemGrp;
						EffWidth (Section, Section.Part [num2], array [iElemGrp]);
						iElemGrp--;
						EffWidth (Section, Section.Part [num2], array [iElemGrp]);
						break;
					}
				}
				Part part3 = Section.Part [num2];
				if (!part3.Closed) {
					A = part3.Element [1].Ang;
					Sn = (float)System.Math.Sin (A);
					Cs = (float)System.Math.Cos (A);
					if ((CFS.SpecYear (Spec) < 2004) & !blnSS) {
						part3.Be1 = part3.Element [1].Wid;
					}
					X0 = part3.XPosition - part3.Xcg + part3.Element [1].X1 - part3.Be1 * Cs - T / 2f * Sn;
					if (X0 < Xmine) {
						Xmine = X0;
					}
					if (X0 > Xmaxe) {
						Xmaxe = X0;
					}
					X0 = part3.XPosition - part3.Xcg + part3.Element [1].X1 - part3.Be1 * Cs + T / 2f * Sn;
					if (X0 < Xmine) {
						Xmine = X0;
					}
					if (X0 > Xmaxe) {
						Xmaxe = X0;
					}
					Y0 = part3.YPosition - part3.Ycg + part3.Element [1].Y1 - part3.Be1 * Sn - T / 2f * Cs;
					if (Y0 < Ymine) {
						Ymine = Y0;
					}
					if (Y0 > Ymaxe) {
						Ymaxe = Y0;
					}
					Y0 = part3.YPosition - part3.Ycg + part3.Element [1].Y1 - part3.Be1 * Sn + T / 2f * Cs;
					if (Y0 < Ymine) {
						Ymine = Y0;
					}
					if (Y0 > Ymaxe) {
						Ymaxe = Y0;
					}
					A = part3.Element [part3.nElem].Ang;
					Sn = (float)System.Math.Sin (A);
					Cs = (float)System.Math.Cos (A);
					if ((CFS.SpecYear (Spec) < 2004) & !blnSS) {
						part3.Ben = part3.Element [part3.nElem].Wid;
					}
					X1 = part3.XPosition - part3.Xcg + part3.Element [part3.nElem].X0 + part3.Ben * Cs - T / 2f * Sn;
					if (X1 < Xmine) {
						Xmine = X1;
					}
					if (X1 > Xmaxe) {
						Xmaxe = X1;
					}
					X1 = part3.XPosition - part3.Xcg + part3.Element [part3.nElem].X0 + part3.Ben * Cs + T / 2f * Sn;
					if (X1 < Xmine) {
						Xmine = X1;
					}
					if (X1 > Xmaxe) {
						Xmaxe = X1;
					}
					Y1 = part3.YPosition - part3.Ycg + part3.Element [part3.nElem].Y0 + part3.Ben * Sn - T / 2f * Cs;
					if (Y1 < Ymine) {
						Ymine = Y1;
					}
					if (Y1 > Ymaxe) {
						Ymaxe = Y1;
					}
					Y1 = part3.YPosition - part3.Ycg + part3.Element [part3.nElem].Y0 + part3.Ben * Sn + T / 2f * Cs;
					if (Y1 < Ymine) {
						Ymine = Y1;
					}
					if (Y1 > Ymaxe) {
						Ymaxe = Y1;
					}
				}
				part3 = null;
				Part part4 = Section.Part [num2];
				short nElem3 = part4.nElem;
				for (short num3 = 1; num3 <= nElem3; num3 = (short)unchecked(num3 + 1)) {
					if (unchecked(part4.Closed || num3 > 1)) {
						short num12 = Conversions.ToShort (Interaction.IIf (num3 == 1, part4.nElem, num3 - 1));
						X1 = X + part4.Element [num12].X1;
						Y1 = Y + part4.Element [num12].Y1;
						X2 = X + part4.Element [num3].X0;
						Y2 = Y + part4.Element [num3].Y0;
						F1 = P / Ae + M1 * Y1 + M2 * X1;
						F2 = P / Ae + M1 * Y2 + M2 * X2;
						if (F1 > F2) {
							F3 = F1;
						} else {
							F3 = F2;
						}
						if (F3 > 0f) {
							R = part4.Element [num3].Rad + T / 2f;
							D = 2f * R + T;
							if (blnSS) {
								C = Section.Material.FprFy (2);
								Kc = (float)(((double)((1f - C) * (E / F3) / (D / T)) + 5.882 * (double)C) / (8.93 - 3.048 * (double)C));
							} else {
								Kc = (float)(0.037 * (double)(E / F3) / (double)(D / T) + 0.667);
							}
							Fcr = (float)(0.328 * (double)E / (double)(D / T));
							if (System.Math.Sqrt (F3 / Fcr) > (double)LambdaMax) {
								LambdaMax = (float)System.Math.Sqrt (F3 / Fcr);
							}
							if (Kc < 1f) {
								blnRationalAnalysis = true;
								ref string reference5 = ref strTraceEff;
								ref string reference2 = ref reference5;
								reference5 = reference2 + "    Arc element " + Conversions.ToString (unchecked((int)num3)) + ": D/t=" + Units.DisplayNone (D / T, "", 0, 0) + " (rational analysis)\r\n";
								ref string reference6 = ref strTraceEff;
								reference2 = ref reference6;
								reference6 = reference2 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", reduce thickness by " + Units.DisplayNone (100f * (1f - Kc), "", 0, 0) + "%\r\n";
								DW = T * (1f - Kc);
								Arc = part4.Element [num3].Arc / 2f;
								Ang = (float)((double)part4.Element [num12].Ang - (double)System.Math.Sign (Arc) * System.Math.PI / 2.0 + (double)Arc);
								Arc = System.Math.Abs (Arc);
								Sn = (float)System.Math.Sin (Arc);
								Cs = (float)System.Math.Cos (Arc);
								SnA = (float)System.Math.Sin (Ang);
								CsA = (float)System.Math.Cos (Ang);
								Xac = X + part4.Element [num3].Xac;
								Yac = Y + part4.Element [num3].Yac;
								DA = 2f * R * Arc * DW;
								AX = 2f * R * R * Sn * CsA * DW;
								AY = 2f * R * R * Sn * SnA * DW;
								AX2 = (float)(System.Math.Pow (R, 3.0) * (double)(Arc + Sn * Cs * (2f * CsA * CsA - 1f)) * (double)DW);
								AY2 = (float)(System.Math.Pow (R, 3.0) * (double)(Arc + Sn * Cs * (2f * SnA * SnA - 1f)) * (double)DW);
								AXY = (float)(2.0 * System.Math.Pow (R, 3.0) * (double)Sn * (double)Cs * (double)SnA * (double)CsA * (double)DW);
								SA += 0f - DA;
								SAX += (0f - DA) * (Xcge + Xac) - AX;
								SAY += (0f - DA) * (Ycge + Yac) - AY;
								ref float sAX = ref SAX2;
								sAX = (float)((double)sAX + ((double)(0f - DA) * System.Math.Pow (Xcge + Xac, 2.0) - (double)(2f * AX * (Xcge + Xac)) - (double)AX2));
								ref float sAY = ref SAY2;
								sAY = (float)((double)sAY + ((double)(0f - DA) * System.Math.Pow (Ycge + Yac, 2.0) - (double)(2f * AY * (Ycge + Yac)) - (double)AY2));
								SAXY += (0f - DA) * (Xcge + Xac) * (Ycge + Yac) - AX * (Ycge + Yac) - AY * (Xcge + Xac) - AXY;
							}
						}
					}
				}
				part4 = null;
			}
			Ae = SA;
			Xcge = SAX / SA;
			Ycge = SAY / SA;
			Ixe = SAY2 - SA * Ycge * Ycge;
			Iye = SAX2 - SA * Xcge * Xcge;
			Ixye = SAXY - SA * Ycge * Xcge;
			Sxte = Ixe / (Ymaxe - Ycge);
			Sxbe = Ixe / (Ycge - Ymine);
			Syle = Iye / (Xcge - Xmine);
			Syre = Iye / (Xmaxe - Xcge);
			if (Sxte < Sxbe) {
				Sxe = Sxte;
			} else {
				Sxe = Sxbe;
			}
			if (Syle < Syre) {
				Sye = Syle;
			} else {
				Sye = Syre;
			}
		}
		if (!blnIterate && effMode != 2) {
			strTraceEff += "  Iteration is not required\r\n";
		}
		ref Section.EffectivePropertiesType propEff = ref Section.PropEff;
		propEff.Xcg = Xcge;
		propEff.Ycg = Ycge;
		propEff.A = Ae;
		propEff.Ix = Ixe;
		propEff.Iy = Iye;
		propEff.Ixy = Ixye;
		propEff.Sxt = Sxte;
		propEff.Sxb = Sxbe;
		propEff.Sx = Sxe;
		propEff.Syl = Syle;
		propEff.Syr = Syre;
		propEff.Sy = Sye;
		propEff.ColdWorkAllowed = blnColdWorkAllowed;
		propEff.RationalAnalysis = blnRationalAnalysis;
		propEff.Iterate = blnIterate;
		propEff.LambdaMax = LambdaMax;
		propEff.Trace = strTraceEff;
		propEff.Msg = strMsge;
	}

	private void EffWidth (Section Section, Part Part, ElementGroupType ElemGrp)
	{
		short iElemFirst = ElemGrp.iElemFirst;
		short iElemLast = ElemGrp.iElemLast;
		Part part = Part;
		W = part.Element [iElemFirst].Wid;
		A = part.Element [iElemFirst].Ang;
		Sn = (float)System.Math.Sin (A);
		Cs = (float)System.Math.Cos (A);
		X1 = X + part.Element [iElemFirst].X0;
		Y1 = Y + part.Element [iElemFirst].Y0;
		X2 = X + part.Element [iElemFirst].X1;
		Y2 = Y + part.Element [iElemFirst].Y1;
		Xh1 = X + part.Element [iElemFirst].Xh0;
		Yh1 = Y + part.Element [iElemFirst].Yh0;
		Xh2 = X + part.Element [iElemFirst].Xh1;
		Yh2 = Y + part.Element [iElemFirst].Yh1;
		W1 = (float)System.Math.Sqrt (System.Math.Pow (X1 - Xh1, 2.0) + System.Math.Pow (Y1 - Yh1, 2.0));
		W2 = (float)System.Math.Sqrt (System.Math.Pow (X2 - Xh2, 2.0) + System.Math.Pow (Y2 - Yh2, 2.0));
		F1 = P1 / Ae + M1 * Y1 + M2 * X1;
		F2 = P1 / Ae + M1 * Y2 + M2 * X2;
		if (F1 > F2) {
			F3 = F1;
		} else {
			F3 = F2;
		}
		Fh1 = P1 / Ae + M1 * Yh1 + M2 * Xh1;
		Fh2 = P1 / Ae + M1 * Yh2 + M2 * Xh2;
		if (effMode1 == 0) {
			Dh = part.Element [iElemFirst].Hole;
		} else {
			Dh = 0f;
		}
		Rk = 1f;
		strRk = string.Empty;
		if ((CFS.SpecYear (Spec1) >= 2012) | blnSS) {
			if ((part.Closed || iElemFirst > 1) & (part.Element [iElemFirst].K == 0f)) {
				R = part.Element [iElemFirst].Rad;
				if (R > 30f * T) {
					R = 30f * T;
				}
				if (R / T > 10f) {
					ref float rk = ref Rk;
					rk = (float)((double)rk * (1.08 - (double)(R / T / 50f)));
				}
			}
			if ((part.Closed | (iElemLast < part.nElem)) & (part.Element [iElemLast].K == 0f)) {
				short num = Conversions.ToShort (Interaction.IIf (iElemLast < part.nElem, checked(iElemLast + 1), 1));
				R = part.Element [num].Rad;
				if (R > 30f * T) {
					R = 30f * T;
				}
				if (R / T > 10f) {
					ref float rk2 = ref Rk;
					rk2 = (float)((double)rk2 * (1.08 - (double)(R / T / 50f)));
				}
			}
		}
		if (Rk < 1f) {
			blnRationalAnalysis = true;
			strRk = " (rational analysis)";
		}
		ho = part.Element [iElemFirst].Len;
		if (part.Centerline && iElemFirst > 1) {
			ref float reference = ref ho;
			reference = (float)((double)reference + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [iElemFirst].Arc / 2f)));
		}
		checked {
			if (part.Centerline & (iElemFirst < part.nElem)) {
				ref float reference2 = ref ho;
				reference2 = (float)((double)reference2 + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [iElemFirst + 1].Arc / 2f)));
			}
			bo = T;
			if (F1 > F2) {
				short num2 = (short)(iElemFirst - 1);
				if ((num2 < 1) & part.Closed) {
					num2 = part.nElem;
				}
				if (num2 >= 1) {
					bo = part.Element [num2].Len;
					if (unchecked(part.Centerline && num2 > 1)) {
						ref float reference3 = ref bo;
						reference3 = (float)((double)reference3 + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [num2].Arc / 2f)));
					}
					if (part.Centerline & (num2 < part.nElem)) {
						ref float reference4 = ref bo;
						reference4 = (float)((double)reference4 + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [num2 + 1].Arc / 2f)));
					}
				}
			} else {
				short num = (short)(iElemFirst + 1);
				if ((num > part.nElem) & part.Closed) {
					num = 1;
				}
				if (num <= part.nElem) {
					bo = part.Element [num].Len;
					if (unchecked(part.Centerline && num > 1)) {
						ref float reference5 = ref bo;
						reference5 = (float)((double)reference5 + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [num].Arc / 2f)));
					}
					if (part.Centerline & (num < part.nElem)) {
						ref float reference6 = ref bo;
						reference6 = (float)((double)reference6 + 0.5 * (double)T * System.Math.Tan (System.Math.Abs (part.Element [num + 1].Arc / 2f)));
					}
				}
			}
			if (bo < T) {
				bo = T;
			}
			part = null;
			if (iElemLast != iElemFirst) {
				blnIterate = true;
				Part part2 = Part;
				Part part3 = Part.Clone ();
				part3.Closed = false;
				part3.nElem = Conversions.ToByte (Operators.AddObject ((short)unchecked(iElemLast - iElemFirst) + 1, Interaction.IIf (iElemLast < iElemFirst, part2.nElem, 0)));
				int nElem = part3.nElem;
				for (int i = 1; i <= nElem; i++) {
					short num3 = (short)(iElemFirst + i - 1);
					if (num3 > part2.nElem) {
						num3 = (short)unchecked(num3 - part2.nElem);
					}
					part3.Element [i].Len = part2.Element [num3].Len;
					part3.Element [i].Ang = part2.Element [num3].Ang - part2.Element [iElemFirst].Ang;
					part3.Element [i].Rad = part2.Element [num3].Rad;
					part3.Element [i].Hole = 0f;
				}
				W0 = Conversions.ToSingle (Operators.MultiplyObject (Operators.AddObject (part2.Element [iElemFirst].Rad, Operators.MultiplyObject (Interaction.IIf (part2.Centerline, 0.5, 1), T)), System.Math.Tan (System.Math.Abs (part2.Element [iElemFirst].Arc) / 2f)));
				part3.Element [1].Len = part2.Element [iElemFirst].Len - W0;
				if (iElemLast < part2.nElem) {
					R = part2.Element [iElemLast + 1].Rad;
					Arc = part2.Element [iElemLast + 1].Arc;
				} else if (part2.Closed) {
					R = part2.Element [1].Rad;
					Arc = part2.Element [1].Arc;
				} else {
					R = 0f;
					Arc = 0f;
				}
				W0 = Conversions.ToSingle (Operators.MultiplyObject (Operators.AddObject (R, Operators.MultiplyObject (Interaction.IIf (part2.Centerline, 0.5, 1), T)), System.Math.Tan (System.Math.Abs (Arc) / 2f)));
				part3.Element [part3.nElem].Len = part2.Element [iElemLast].Len - W0;
				part3.Geometry (ref blnChg, ref strMsg);
				Ag = part3.A;
				B0 = part3.Xleft + part3.Xright;
				Xci = X1 + part3.Xcg * Cs - part3.Ycg * Sn;
				Yci = Y1 + part3.Xcg * Sn + part3.Ycg * Cs;
				short num2 = iElemFirst;
				SGW = 0f;
				SDW = 0f;
				SH = part2.Element [iElemFirst].Hole;
				Bp = part2.Element [iElemFirst].Wid;
				short num = num2;
				while (true) {
					num = (short)(num + 1);
					unchecked {
						if (num > iElemLast && iElemLast > iElemFirst) {
							break;
						}
						if (num > part2.nElem) {
							num = 1;
						}
						if (num > iElemLast && num < iElemFirst) {
							break;
						}
						if (part2.Element [num].Wid > Bp) {
							Bp = part2.Element [num].Wid;
						}
					}
					if (part2.CollinearElements (part2.Element [iElemFirst], part2.Element [num])) {
						if ((short)unchecked(num - num2) == 1) {
							Asi = 0f;
							Isi = 0f;
							C = 0f;
						} else {
							part3.nElem = Conversions.ToByte (Operators.AddObject ((short)unchecked(num - num2) + 1, Interaction.IIf (num < num2, part2.nElem, 0)));
							int nElem2 = part3.nElem;
							for (int j = 1; j <= nElem2; j++) {
								short num3 = (short)(num2 + j - 1);
								if (num3 > part2.nElem) {
									num3 = (short)unchecked(num3 - part2.nElem);
								}
								part3.Element [j].Len = part2.Element [num3].Len;
								part3.Element [j].Ang = part2.Element [num3].Ang - part2.Element [iElemFirst].Ang;
								part3.Element [j].Rad = part2.Element [num3].Rad;
								part3.Element [j].Hole = 0f;
							}
							if (num2 < part2.nElem) {
								R = part2.Element [num2 + 1].Rad;
								Arc = part2.Element [num2 + 1].Arc;
							} else if (part2.Closed) {
								R = part2.Element [1].Rad;
								Arc = part2.Element [1].Arc;
							} else {
								R = 0f;
								Arc = 0f;
							}
							W0 = Conversions.ToSingle (Operators.MultiplyObject (Operators.AddObject (R, Operators.MultiplyObject (Interaction.IIf (part2.Centerline, 0.5, 1), T)), System.Math.Tan (System.Math.Abs (Arc) / 2f)));
							part3.Element [1].Len = W0;
							W0 = Conversions.ToSingle (Operators.MultiplyObject (Operators.AddObject (part2.Element [num].Rad, Operators.MultiplyObject (Interaction.IIf (part2.Centerline, 0.5, 1), T)), System.Math.Tan (System.Math.Abs (part2.Element [num].Arc) / 2f)));
							part3.Element [part3.nElem].Len = W0;
							part3.Geometry (ref blnChg, ref strMsg);
							part3.CalcProperties (blnCalcTorsion: false);
							Asi = part3.A;
							Isi = (float)((double)part3.Ix + (double)Asi * System.Math.Pow (part3.Ycg, 2.0));
							C = (float)(System.Math.Sqrt (System.Math.Pow (part2.Element [num2].X1 - part2.Element [iElemFirst].X0, 2.0) + System.Math.Pow (part2.Element [num2].Y1 - part2.Element [iElemFirst].Y0, 2.0)) + (double)part3.Xcg);
						}
						W0 = (float)System.Math.Pow (System.Math.Sin (System.Math.PI * (double)C / (double)B0), 2.0);
						ref float sGW = ref SGW;
						sGW = (float)((double)sGW + 10.92 * (double)Isi * (double)W0 / (double)(B0 * T * T * T));
						SDW += Asi * W0 / (B0 * T);
						num2 = num;
					}
					SH += part2.Element [num].Hole;
				}
				if ((double)Bp <= 1E-06 * (double)B0) {
					Bp = (float)(1E-06 * (double)B0);
				}
				ref string reference7 = ref strTraceEff;
				ref string reference8 = ref reference7;
				reference7 = unchecked(reference8 + "    Elements " + Conversions.ToString ((int)iElemFirst) + " to " + Conversions.ToString ((int)iElemLast)) + ":\r\n";
				ref string reference9 = ref strTraceEff;
				reference9 = reference9 + "      Section " + strIS + " - Elements with Intermediate Stiffeners\r\n";
				ref string reference10 = ref strTraceEff;
				reference8 = ref reference10;
				reference10 = reference8 + "      b₀=" + Units.DisplayLen1 (B0, 0, blnShowUnit: true, "", 0, 0) + ", bp=" + Units.DisplayLen1 (Bp, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				X1 = ElemGrp.X1;
				Y1 = ElemGrp.Y1;
				F1 = ElemGrp.F1;
				X2 = ElemGrp.X2;
				Y2 = ElemGrp.Y2;
				F2 = ElemGrp.F2;
				blnUseIS = true;
				if (part2.Closed) {
					blnEdgeStiffened = false;
				} else if ((F1 < F2 / 2f) | (F2 < F1 / 2f)) {
					blnEdgeStiffened = false;
				} else if ((iElemFirst == 2) & (iElemLast < unchecked((int)part2.nElem) - 1)) {
					blnEdgeStiffened = true;
				} else if ((iElemFirst > 2) & (iElemLast == unchecked((int)part2.nElem) - 1)) {
					blnEdgeStiffened = true;
				} else {
					blnEdgeStiffened = false;
				}
				if (blnEdgeStiffened) {
					ref string reference11 = ref strTraceEff;
					reference11 = reference11 + "      Check for lip stiffener reduction using w=" + Units.DisplayLen1 (B0, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					W = B0;
					if (F1 > F2) {
						F3 = F1;
					} else {
						F3 = F2;
					}
					if (iElemFirst == 2) {
						CFS.Swap (ref X1, ref X2);
						CFS.Swap (ref Y1, ref Y2);
						CFS.Swap (ref F1, ref F2);
						ref float a = ref A;
						a = (float)((double)a - System.Math.PI);
						Sn = 0f - Sn;
						Cs = 0f - Cs;
					}
					C1 = 1f;
					C2 = 1f;
					Ri = 1f;
					K = 4f;
					if (Lip.Elem == 1) {
						ReduceStiffener (ref part2.Be1);
					} else {
						ReduceStiffener (ref part2.Ben);
					}
					if (Ia == 0f) {
						blnUseIS = false;
					} else if (K < 4f) {
						blnUseIS = false;
						ref string reference12 = ref strTraceEff;
						reference12 = reference12 + "      Partially stiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						PartStiffened ();
					}
				}
				if (blnUseIS) {
					Xc = Xci;
					Yc = Yci;
					ref string reference13 = ref strTraceEff;
					reference8 = ref reference13;
					reference13 = reference8 + "      kloc=" + Units.DisplayNone ((float)(4.0 * System.Math.Pow (B0 / Bp, 2.0)), "", 0, 0) + "\t" + strEqISkloc + "\r\n";
					B2 = (float)System.Math.Sqrt (2f * SGW + 1f);
					ref string reference14 = ref strTraceEff;
					reference8 = ref reference14;
					reference14 = reference8 + "      β=" + Units.DisplayNone ((float)System.Math.Sqrt (B2), "", 0, 0) + "\t" + strEqISbeta + "\r\n";
					K = (float)((System.Math.Pow (1f + B2, 2.0) + (double)(2f * SGW)) / (double)(B2 * (1f + 2f * SDW)));
					ref string reference15 = ref strTraceEff;
					reference8 = ref reference15;
					reference15 = reference8 + "      kd=" + Units.DisplayNone (K, "", 0, 0) + "\t" + strEqISkd + "\r\n";
					if (iElemFirst > 1) {
						W0 = part2.Element [iElemFirst - 1].Wid;
					} else if (part2.Closed) {
						W0 = part2.Element [part2.nElem].Wid;
					} else {
						W0 = B0 / 10f;
					}
					if (iElemLast < part2.nElem) {
						W0 = (float)CFS.Min (W0, part2.Element [iElemLast + 1].Wid);
					} else if (part2.Closed) {
						W0 = (float)CFS.Min (W0, part2.Element [1].Wid);
					} else {
						W0 = B0 / 10f;
					}
					if (W0 < B0 / 10f) {
						W0 = B0 / 10f;
					}
					R = (11f - B0 / W0) / 5f;
					if ((double)R < 0.5) {
						R = 0.5f;
					}
					if (R > 2f) {
						R = 2f;
					}
					if (blnEdgeStiffened & (R > 1f)) {
						R = 1f;
					}
					ref string reference16 = ref strTraceEff;
					reference8 = ref reference16;
					reference16 = reference8 + "      R=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqISR + "\r\n";
					K = (float)CFS.Min (R * K, 4.0 * System.Math.Pow (B0 / Bp, 2.0));
					ref string reference17 = ref strTraceEff;
					reference8 = ref reference17;
					reference17 = reference8 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqISk + "\r\n";
					F3 = (F1 + F2) / 2f;
					ref string reference18 = ref strTraceEff;
					reference18 = reference18 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					if ((double)System.Math.Abs (F2 - F1) > 0.2 * (double)F3) {
						strTraceEff += "      Non-uniform compression (rational analysis)\r\n";
						blnRationalAnalysis = true;
					}
					Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)B0 * (double)B0));
					ref string reference19 = ref strTraceEff;
					reference8 = ref reference19;
					reference19 = reference8 + "      Fcrl=" + Units.DisplayStress (Fcr, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqISFcrl + "\r\n";
					L = (float)System.Math.Sqrt (F3 / Fcr);
					if (L > LambdaMax) {
						LambdaMax = L;
					}
					ref string reference20 = ref strTraceEff;
					reference8 = ref reference20;
					reference20 = reference8 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqISL + "\r\n";
					if (L > 0.6732051f) {
						blnColdWorkAllowed = false;
						R = (float)((1.0 - 0.22 / (double)L) / (double)L);
						ref string reference21 = ref strTraceEff;
						reference8 = ref reference21;
						reference21 = reference8 + "      ρ=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqISRho + "\r\n";
						DW = (1f - R) * (Ag / T);
						if (effMode1 == 0) {
							DW -= SH;
						}
						ref string reference22 = ref strTraceEff;
						reference8 = ref reference22;
						reference22 = reference8 + "      be=" + Units.DisplayLen1 (R * Ag / T, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqISB + "\r\n";
						if (DW > 0f) {
							ReduceProperties ();
						}
					} else {
						ref string reference23 = ref strTraceEff;
						reference23 = reference23 + "      ρ=1 (fully effective)\t" + strEqISRho1 + "\r\n";
					}
				}
				part2 = null;
				return;
			}
		}
		if (F3 <= 0f) {
			ref string reference24 = ref strTraceEff;
			reference24 = reference24 + "    Element " + Conversions.ToString ((int)iElemFirst) + ": No compressive stress (fully effective)\r\n";
			if (iElemFirst == 1) {
				Part.Be1 = W;
			}
			if (iElemFirst == Part.nElem) {
				Part.Ben = W;
			}
			return;
		}
		Part part4 = Part;
		if (!part4.Closed && (((iElemFirst <= 2) & (iElemGrp <= nElemGrp / 2)) | ((part4.nElem == 1) & (F2 < 0f)))) {
			CFS.Swap (ref X1, ref X2);
			CFS.Swap (ref Y1, ref Y2);
			CFS.Swap (ref F1, ref F2);
			CFS.Swap (ref Xh1, ref Xh2);
			CFS.Swap (ref Yh1, ref Yh2);
			CFS.Swap (ref Fh1, ref Fh2);
			CFS.Swap (ref W1, ref W2);
			ref float a2 = ref A;
			a2 = (float)((double)a2 - System.Math.PI);
			Sn = 0f - Sn;
			Cs = 0f - Cs;
		}
		ref string reference25 = ref strTraceEff;
		reference25 = reference25 + "    Element " + Conversions.ToString ((int)iElemFirst) + ": ";
		checked {
			if ((part4.Element [iElemFirst].K > 0f) & (Dh == 0f)) {
				blnIterate = true;
				K = part4.Element [iElemFirst].K;
				if ((((unchecked(((nPart > 1) & !part4.Closed) && iElemFirst > 1) & (iElemFirst < part4.nElem)) && ConnSpa > 0f) & (Depth > 0f) & ((double)System.Math.Abs (F2 - F1) <= 0.1 * (double)F3) & ((CFS.SpecYear (Spec1) >= 2010) | blnSS)) && (((double)System.Math.Abs (part4.Element [iElemFirst].Arc) < 0.01) | ((double)System.Math.Abs (part4.Element [iElemFirst + 1].Arc) < 0.01))) {
					if (((double)System.Math.Abs (part4.Element [iElemFirst].Arc) < 0.01) & ((double)System.Math.Abs (part4.Element [iElemFirst + 1].Arc) < 0.01)) {
						ref string reference26 = ref strTraceEff;
						reference26 = reference26 + "Fastened Cover Plate, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CoverPlate (4f);
					} else {
						ref string reference27 = ref strTraceEff;
						reference27 = reference27 + "Fastened Cover Plate Edge, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						CoverPlate (1.25f);
					}
				} else {
					ref string reference28 = ref strTraceEff;
					ref string reference8 = ref reference28;
					reference28 = reference8 + "User defined stiffness, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K, "", 0, 0) + " (rational analysis)\r\n";
					blnRationalAnalysis = true;
					UserStiffened ();
					if (iElemFirst == 1) {
						part4.Be1 = W;
					}
					if (iElemFirst == part4.nElem) {
						part4.Ben = W;
					}
				}
			} else if (part4.nElem == 1) {
				blnIterate = true;
				part4.Be1 = W;
				part4.Ben = W;
				if ((F1 < 0f) | (F2 < 0f)) {
					K = Ku;
					ref string reference29 = ref strTraceEff;
					reference29 = reference29 + "Unstiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					float Bex = W;
					UnStiffened (ref Bex);
				} else {
					ref string reference30 = ref strTraceEff;
					reference30 = reference30 + "Free edges in compression, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					FreeEdges ();
				}
			} else if (!part4.Closed & ((iElemFirst == 1) | (iElemFirst == part4.nElem))) {
				K = Ku;
				ref string reference31 = ref strTraceEff;
				reference31 = reference31 + "Unstiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
				if (W / T > 60f) {
					blnRationalAnalysis = true;
					strTraceEff += "      w/t exceeds limit, treat as rational analysis\r\n";
				}
				if (iElemFirst == 1) {
					UnStiffened (ref part4.Be1);
				} else {
					UnStiffened (ref part4.Ben);
				}
				if (!blnStfFlg) {
					Lip.D = part4.Element [iElemFirst].Len;
					if (part4.Centerline) {
						if (iElemFirst == 1) {
							ref float d = ref Lip.D;
							d = (float)((double)d + (double)(T / 2f) * System.Math.Tan (System.Math.Abs (part4.Element [2].Arc) / 2f));
						}
						if (iElemFirst == part4.nElem) {
							ref float d2 = ref Lip.D;
							d2 = (float)((double)d2 + (double)(T / 2f) * System.Math.Tan (System.Math.Abs (part4.Element [part4.nElem].Arc) / 2f));
						}
					}
					Lip.Ang = A;
					Lip.Dh = Dh;
					Lip.W2 = W2;
					Lip.W = W;
					Lip.Dps = Be;
					Lip.X1 = X1 + B0 * Cs;
					Lip.Y1 = Y1 + B0 * Sn;
					Lip.Elem = iElemFirst;
				}
			} else {
				blnIterate = true;
				C1 = 1f;
				C2 = 1f;
				Ri = 1f;
				K = 4f;
				blnUseProcII = false;
				if (!part4.Closed & ((iElemFirst == 2) | (iElemFirst == unchecked((int)part4.nElem) - 1)) & (part4.nElem > 3) & (F1 >= 0f) & (F2 >= 0f)) {
					strTraceEff += "Check for lip stiffener reduction\r\n";
					if (Lip.Elem == 1) {
						ReduceStiffener (ref part4.Be1);
					} else {
						ReduceStiffener (ref part4.Ben);
					}
					ref string reference32 = ref strTraceEff;
					reference32 = reference32 + "    Element " + Conversions.ToString (unchecked((int)iElemFirst)) + ": ";
				}
				if (Dh == 0f) {
					if (K < 4f) {
						ref string reference33 = ref strTraceEff;
						reference33 = reference33 + "Partially stiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (Operators.ConditionalCompareObjectGreater (W / T, Interaction.IIf (Ri < 1f, 60, 90), TextCompare: false)) {
							blnRationalAnalysis = true;
							strTraceEff += "      w/t exceeds limit, treat as rational analysis\r\n";
						}
						PartStiffened ();
					} else {
						if ((effMode1 == 2) & ((double)System.Math.Abs (F1 - F2) < 0.05 * (double)F3) & !blnSS & (part4.Closed | ((iElemFirst > 1) & (iElemFirst < part4.nElem)))) {
							short num2 = (short)(iElemFirst - 1);
							if (num2 < 1) {
								num2 = part4.nElem;
							}
							XII = X + part4.Element [num2].X0;
							YII = Y + part4.Element [num2].Y0;
							FII1 = P1 / Ae + M1 * YII + M2 * XII;
							short num = (short)(iElemFirst + 1);
							if (num > part4.nElem) {
								num = 1;
							}
							XII = X + part4.Element [num].X1;
							YII = Y + part4.Element [num].Y1;
							FII2 = P1 / Ae + M1 * YII + M2 * XII;
							if ((FII1 < 0f) & (FII2 < 0f)) {
								blnUseProcII = true;
							}
						}
						ref string reference34 = ref strTraceEff;
						reference34 = reference34 + "Stiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
						if (Operators.ConditionalCompareObjectGreater (W / T, Interaction.IIf (blnSS, 400, 500), TextCompare: false)) {
							blnRationalAnalysis = true;
							strTraceEff += "      w/t exceeds limit, treat as rational analysis\r\n";
						}
						FullStiffened ();
					}
				} else if ((K >= 4f) & ((double)System.Math.Abs (F1 - F2) < 0.05 * (double)F3) & ((double)(Dh / W) <= 0.5) & (W / T <= 70f) & ((double)System.Math.Abs (W1 - W2) < 0.05 * (double)W) & (Dh == Section.HoleLength) & (Section.HoleSpacing >= W / 2f) & (Section.HoleSpacing >= 3f * Dh)) {
					ref string reference35 = ref strTraceEff;
					ref string reference8 = ref reference35;
					reference35 = reference8 + "Element with hole, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + ", hole size=" + Units.DisplayLen1 (Dh, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
					HoleElement ();
				} else {
					string text = string.Empty;
					if ((double)System.Math.Abs (F1 - F2) < 0.05 * (double)F3) {
						if (Operators.ConditionalCompareObjectGreater (W / T, Interaction.IIf (blnSS, 400, 500), TextCompare: false)) {
							blnRationalAnalysis = true;
							text += "      w/t exceeds limit, treat as rational analysis\r\n";
						}
						if ((double)(Dh / ho) > 0.5) {
							blnRationalAnalysis = true;
							text += "      dh/wo greater than 0.5, treat as rational analysis\r\n";
						}
						if (Section.HoleSpacing < 24f) {
							blnRationalAnalysis = true;
							text = text + "      Hole spacing less than " + Units.DisplayLen1 (24f, 0, blnShowUnit: true, "", 0, 0) + ", treat as rational analysis\r\n";
						}
					} else {
						if (W / T > 200f) {
							blnRationalAnalysis = true;
							text += "      h/t greater than 200, treat as rational analysis\r\n";
						}
						if ((double)(Dh / W) > 0.7) {
							blnRationalAnalysis = true;
							text += "      dh/h greater than 0.7, treat as rational analysis\r\n";
						}
						if (Section.HoleSpacing - Section.HoleLength < 18f) {
							blnRationalAnalysis = true;
							text = text + "      Clear distance between holes less than " + Units.DisplayLen1 (18f, 0, blnShowUnit: true, "", 0, 0) + ", treat as rational analysis\r\n";
						}
					}
					float num4 = Conversions.ToSingle (Interaction.IIf (Dh == Section.HoleLength, 6, 2.5));
					if (Dh > num4) {
						blnRationalAnalysis = true;
						text = text + "      Hole depth greater than " + Units.DisplayLen1 (num4, 0, blnShowUnit: true, "", 0, 0) + ", treat as rational analysis\r\n";
					}
					if ((Dh != Section.HoleLength) & ((double)Section.HoleLength > 4.5)) {
						blnRationalAnalysis = true;
						text = text + "      Hole length greater than " + Units.DisplayLen1 (4.5f, 0, blnShowUnit: true, "", 0, 0) + ", treat as rational analysis\r\n";
					}
					if ((Fh1 <= 0f) & (Fh2 <= 0f)) {
						ref string reference36 = ref strTraceEff;
						ref string reference8 = ref reference36;
						reference36 = reference8 + "Stiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n" + text;
						FullStiffened ();
					} else if (((double)Dh < 0.38 * (double)W) & (((Fh1 <= 0f) & ((double)W2 >= 0.3 * (double)W)) | ((Fh2 <= 0f) & ((double)W1 >= 0.3 * (double)W)))) {
						ref string reference37 = ref strTraceEff;
						ref string reference8 = ref reference37;
						reference37 = reference8 + "Stiffened, w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + "\r\n" + text;
						FullStiffened ();
					} else {
						ref string reference38 = ref strTraceEff;
						reference38 = reference38 + "Treat as two unstiffened elements\r\n" + text;
						K0 = Ku * (K / 4f);
						X0 = X2;
						Y0 = Y2;
						F0 = F2;
						Dh = 0f;
						X2 = Xh1;
						Y2 = Yh1;
						F2 = Fh1;
						W = W1;
						float Bex2 = W;
						if (F1 > F2) {
							F3 = F1;
						} else {
							F3 = F2;
						}
						if (F3 > 0f) {
							K = C1 * K0;
							UnStiffened (ref Bex2);
						}
						ref float a3 = ref A;
						a3 = (float)((double)a3 + System.Math.PI);
						Sn = 0f - Sn;
						Cs = 0f - Cs;
						X1 = X0;
						Y1 = Y0;
						F1 = F0;
						X2 = Xh2;
						Y2 = Yh2;
						F2 = Fh2;
						W = W2;
						Bex2 = W;
						if (F1 > F2) {
							F3 = F1;
						} else {
							F3 = F2;
						}
						if (F3 > 0f) {
							K = C2 * K0;
							UnStiffened (ref Bex2);
						}
					}
				}
			}
			part4 = null;
		}
	}

	private void FreeEdges ()
	{
		K = Ku;
		Fcr = (float)((double)K * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
		L = (float)System.Math.Sqrt (F3 / Fcr);
		if (L > LambdaMax) {
			LambdaMax = L;
		}
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K, "", 0, 0) + "\r\n";
		ref string reference3 = ref strTraceEff;
		reference2 = ref reference3;
		reference3 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
		if (L <= 0.6732051f) {
			ref string reference4 = ref strTraceEff;
			reference4 = reference4 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
			return;
		}
		blnColdWorkAllowed = false;
		Be = (float)((double)W * (1.0 - 0.22 / (double)L) / (double)L);
		if (W > 0f) {
			strRho = Units.DisplayNone (Be / W, "", 0, 0);
		} else {
			strRho = "?";
		}
		ref string reference5 = ref strTraceEff;
		reference2 = ref reference5;
		reference5 = reference2 + "      ρ=" + strRho + "\t" + strEqRho + "\r\n";
		ref string reference6 = ref strTraceEff;
		reference2 = ref reference6;
		reference6 = reference2 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (W - Be, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqB + "\r\n";
		DW = F1 / (F1 + F2) * (W - Be);
		if ((Dh > 0f) & (DW > W1) & (DW <= W1 + Dh)) {
			DW = W1;
		}
		Xc = X1 + DW / 2f * Cs;
		Yc = Y1 + DW / 2f * Sn;
		ReduceProperties ();
		if ((Dh > 0f) & (DW > W1 + Dh)) {
			DW = 0f - Dh;
			Xc = (Xh1 + Xh2) / 2f;
			Yc = (Yh1 + Yh2) / 2f;
			ReduceProperties ();
		}
		DW = F2 / (F1 + F2) * (W - Be);
		if ((Dh > 0f) & (DW > W2) & (DW <= W2 + Dh)) {
			DW = W2;
		}
		Xc = X2 - DW / 2f * Cs;
		Yc = Y2 - DW / 2f * Sn;
		ReduceProperties ();
		if ((Dh > 0f) & (DW > W2 + Dh)) {
			DW = 0f - Dh;
			Xc = (Xh1 + Xh2) / 2f;
			Yc = (Yh1 + Yh2) / 2f;
			ReduceProperties ();
		}
	}

	private void UnStiffened (ref float Bex)
	{
		if (F2 > F1) {
			F3 = F1 + (F2 - F1) * Bex / W;
		}
		if (F3 < 0f) {
			F3 = 0f;
		}
		Be = W;
		Bex = W;
		if (F2 >= 0f) {
			blnStfFlg = false;
		}
		ref string reference3;
		if ((CFS.SpecYear (Spec1) < 2004) & !blnSS) {
			blnIterate = true;
			if (F2 < 0f) {
				strTraceEff += "    Free edge is in tension, treat as stiffened\r\n";
				FullStiffened ();
				return;
			}
			if (F1 < 0f) {
				B0 = W * F1 / (F1 - F2);
				W -= B0;
			} else {
				B0 = 0f;
			}
			Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
			L = (float)System.Math.Sqrt (F3 / Fcr);
			ref string reference = ref strTraceEff;
			reference = Conversions.ToString (Operators.ConcatenateObject (reference, Interaction.IIf (F1 < 0f, "      Use w=" + Units.DisplayLen1 (W, 0, blnShowUnit: true, "", 0, 0) + ", ", "      ")));
			ref string reference2 = ref strTraceEff;
			reference3 = ref reference2;
			reference2 = reference3 + "f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\r\n";
			ref string reference4 = ref strTraceEff;
			reference3 = ref reference4;
			reference4 = reference3 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
			if (L <= 0.6732051f) {
				ref string reference5 = ref strTraceEff;
				reference5 = reference5 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
				return;
			}
			R = (float)((1.0 - 0.22 / (double)L) / (double)L);
			ref string reference6 = ref strTraceEff;
			reference3 = ref reference6;
			reference6 = reference3 + "      ρ=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqRho + "\r\n";
		} else {
			B0 = 0f;
			if (F1 > F2) {
				Si = System.Math.Abs (F2 / F1);
			} else {
				Si = System.Math.Abs (F1 / F2);
			}
			ref string reference7 = ref strTraceEff;
			reference3 = ref reference7;
			reference7 = reference3 + "      f₁=" + Units.DisplayStress ((float)CFS.Max (F1, F2), 0, blnShowUnit: true, "", 0, 0) + ", f₂=" + Units.DisplayStress ((float)CFS.Min (F1, F2), 0, blnShowUnit: true, "", 0, 0);
			ref string reference8 = ref strTraceEff;
			reference8 = Conversions.ToString (Operators.ConcatenateObject (reference8, Operators.ConcatenateObject (Interaction.IIf (F3 < F2, ", f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0), ""), "\r\n")));
			ref string reference9 = ref strTraceEff;
			reference3 = ref reference9;
			reference9 = reference3 + "      ψ=" + Units.DisplayNone (Si, "", 0, 0) + "\t" + strEqLipSi + "\r\n";
			if ((F1 > 0f) & (F2 > 0f)) {
				blnIterate = true;
				if (F2 < F1) {
					if ((double)Si < 0.999) {
						K = (float)(0.578 / ((double)Si + 0.34) * (double)K / (double)Ku);
					}
					ref string reference10 = ref strTraceEff;
					reference3 = ref reference10;
					reference10 = reference3 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqLipK1 + "\r\n";
				} else {
					K = (float)((0.57 - 0.21 * (double)Si + 0.07 * System.Math.Pow (Si, 2.0)) * (double)K / (double)Ku);
					ref string reference11 = ref strTraceEff;
					reference3 = ref reference11;
					reference11 = reference3 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqLipK2 + "\r\n";
				}
				Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
				L = (float)System.Math.Sqrt (F3 / Fcr);
				if (L > LambdaMax) {
					LambdaMax = L;
				}
				ref string reference12 = ref strTraceEff;
				reference3 = ref reference12;
				reference12 = reference3 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
				if (L <= 0.6732051f) {
					ref string reference13 = ref strTraceEff;
					reference13 = reference13 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
					return;
				}
				R = (float)((1.0 - 0.22 / (double)L) / (double)L);
				ref string reference14 = ref strTraceEff;
				reference3 = ref reference14;
				reference14 = reference3 + "      ρ=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqRho + "\r\n";
			} else if (F2 > 0f) {
				K = (float)((0.57 + 0.21 * (double)Si + 0.07 * System.Math.Pow (Si, 2.0)) * (double)K / (double)Ku);
				Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
				L = (float)System.Math.Sqrt (F3 / Fcr);
				if (L > LambdaMax) {
					LambdaMax = L;
				}
				ref string reference15 = ref strTraceEff;
				reference3 = ref reference15;
				reference15 = reference3 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqLipK3 + "\r\n";
				ref string reference16 = ref strTraceEff;
				reference3 = ref reference16;
				reference16 = reference3 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
				if (L <= 0.6732051f * (1f + Si)) {
					strTraceEff += "      λ<0.673(1+ψ) (fully effective)\r\n";
					return;
				}
				R = (float)((1.0 - 0.22 * (double)(1f + Si) / (double)L) * (double)(1f + Si) / (double)L);
				ref string reference17 = ref strTraceEff;
				reference3 = ref reference17;
				reference17 = reference3 + "      ρ=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqLipRho3 + "\r\n";
			} else {
				blnIterate = true;
				if (Si >= 1f) {
					ref string reference18 = ref strTraceEff;
					reference18 = reference18 + "      ψ>1 (fully effective)\t" + strEqW + "\r\n";
					return;
				}
				K = (float)((1.7 + (double)(5f * Si) + 17.1 * System.Math.Pow (Si, 2.0)) * (double)K / (double)Ku);
				Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
				L = (float)System.Math.Sqrt (F3 / Fcr);
				if (L > LambdaMax) {
					LambdaMax = L;
				}
				ref string reference19 = ref strTraceEff;
				reference3 = ref reference19;
				reference19 = reference3 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqLipK4 + "\r\n";
				ref string reference20 = ref strTraceEff;
				reference3 = ref reference20;
				reference20 = reference3 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
				if (L <= 0.6732051f) {
					ref string reference21 = ref strTraceEff;
					reference21 = reference21 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
					return;
				}
				R = (float)((double)(1f - Si) * (1.0 - 0.22 / (double)L) / (double)L + (double)Si);
				ref string reference22 = ref strTraceEff;
				reference3 = ref reference22;
				reference22 = reference3 + "      ρ=" + Units.DisplayNone (R, "", 0, 0) + "\t" + strEqLipRho4 + "\r\n";
			}
		}
		blnColdWorkAllowed = false;
		Be = W * R;
		Bex = Be;
		DW = W - Be;
		ref string reference23 = ref strTraceEff;
		reference3 = ref reference23;
		reference23 = reference3 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqB + "\r\n";
		if ((Dh > 0f) & (DW > W2) & (DW <= W2 + Dh)) {
			DW = W2;
			Bex = W1;
		}
		Xc = X2 - DW / 2f * Cs;
		Yc = Y2 - DW / 2f * Sn;
		ReduceProperties ();
		if ((Dh > 0f) & (DW > W2 + Dh)) {
			DW = 0f - Dh;
			Xc = (Xh1 + Xh2) / 2f;
			Yc = (Yh1 + Yh2) / 2f;
			ReduceProperties ();
		}
	}

	private void ReduceStiffener (ref float Bex)
	{
		if (blnStfFlg) {
			return;
		}
		S = (float)(1.28 * System.Math.Sqrt (E / F3));
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      S=" + Units.DisplayNone (S, "", 0, 0) + "\t" + strEqS + "\r\n";
		if (CFS.IsSpec1999 (Spec1) & !blnSS) {
			if (W / T <= S / 3f) {
				strTraceEff += "      w/t < S/3 (fully stiffened, no lip reduction)\r\n";
				Ia = 0f;
				return;
			}
			if (W / T < S) {
				Ia = (float)(399.0 * System.Math.Pow ((double)(W / T / S) - System.Math.Sqrt (0.1075), 3.0) * System.Math.Pow (T, 4.0));
				Expn = 0.5f;
				ref string reference3 = ref strTraceEff;
				reference2 = ref reference3;
				reference3 = reference2 + "      Ia=" + Units.DisplayLen4 (Ia, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqIa1 + "\r\n";
			} else {
				Ia = (float)((double)(115f * W / T / S + 5f) * System.Math.Pow (T, 4.0));
				Expn = 1f / 3f;
				ref string reference4 = ref strTraceEff;
				reference2 = ref reference4;
				reference4 = reference2 + "      Ia=" + Units.DisplayLen4 (Ia, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqIa2 + "\r\n";
			}
		} else {
			if ((double)(W / T) <= 0.328 * (double)S) {
				strTraceEff += "      w/t < 0.328S (no lip reduction)\r\n";
				Ia = 0f;
				return;
			}
			Ia = (float)(399.0 * System.Math.Pow ((double)(W / T / S) - 0.328, 3.0));
			if (Ia > 115f * W / T / S + 5f) {
				Ia = 115f * W / T / S + 5f;
			}
			ref float ia = ref Ia;
			ia = (float)((double)ia * System.Math.Pow (T, 4.0));
			ref string reference5 = ref strTraceEff;
			reference2 = ref reference5;
			reference5 = reference2 + "      Ia=" + Units.DisplayLen4 (Ia, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqIa1 + "\r\n";
			Expn = (float)(0.582 - (double)(W / T / (4f * S)));
			if ((double)Expn < 1.0 / 3.0) {
				Expn = 1f / 3f;
			}
		}
		Ist = (float)((double)(T * Lip.W) * (System.Math.Pow ((double)Lip.W * System.Math.Sin (A - Lip.Ang), 2.0) + System.Math.Pow ((double)T * System.Math.Cos (A - Lip.Ang), 2.0)) / 12.0);
		ref string reference6 = ref strTraceEff;
		reference6 = Conversions.ToString (Operators.ConcatenateObject (reference6, Operators.ConcatenateObject (Operators.ConcatenateObject ("      Is=" + Units.DisplayLen4 (Ist, 0, blnShowUnit: true, "", 0, 0), Interaction.IIf (Ist >= Ia, " > Ia (no lip reduction)", string.Empty)), "\r\n")));
		C1 = 1f;
		C2 = 1f;
		Ri = 1f;
		if (Ist < Ia) {
			if ((CFS.SpecYear (Spec1) >= 2016) | blnSS) {
				blnColdWorkAllowed = false;
			}
			Ri = Ist / Ia;
			C2 = Ist / Ia;
			C1 = 2f - C2;
			Ds = Lip.Dps * Ri;
			if ((Lip.Dh > 0f) & (Lip.Dps <= Lip.W - Lip.W2) & (Lip.Dps > Lip.W - Lip.W2 - Lip.Dh)) {
				Lip.Dps = Lip.W - Lip.W2 - Lip.Dh;
			}
			if ((Lip.Dh > 0f) & (Ds < Lip.W - Lip.W2) & (Ds >= Lip.W - Lip.W2 - Lip.Dh)) {
				Ds = Lip.W - Lip.W2;
			}
			if (Ds > Lip.Dps) {
				Ds = Lip.Dps;
			}
			Bex = Ds;
			DW = Lip.Dps - Ds;
			ref string reference7 = ref strTraceEff;
			reference2 = ref reference7;
			reference7 = reference2 + "      ds=" + Units.DisplayLen1 (Ds, 0, blnShowUnit: true, "", 0, 0) + " (lip ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqDs + "\r\n";
			Sn = (float)System.Math.Sin (Lip.Ang);
			Cs = (float)System.Math.Cos (Lip.Ang);
			Xc = Lip.X1 + (Ds + DW / 2f) * Cs;
			Yc = Lip.Y1 + (Ds + DW / 2f) * Sn;
			ReduceProperties ();
			if ((Lip.Dh > 0f) & (Lip.Dps > Lip.W - Lip.W2) & (Ds < Lip.W - Lip.W2 - Lip.Dh)) {
				DW = 0f - Lip.Dh;
				Xc = Lip.X1 + (Lip.W - Lip.W2 - Lip.Dh / 2f) * Cs;
				Yc = Lip.Y1 + (Lip.W - Lip.W2 - Lip.Dh / 2f) * Sn;
				ReduceProperties ();
			}
			Sn = (float)System.Math.Sin (A);
			Cs = (float)System.Math.Cos (A);
		}
		if (CFS.IsSpec1999 (Spec1) & !blnSS) {
			Ka = (float)(4.0 - 5.0 * ((double)(Lip.D / W) - 0.25));
			if (Ka < Ku) {
				Ka = Ku;
			}
			if (Ka > 4f) {
				Ka = 4f;
			}
			K = (float)((double)Ku + (double)(Ka - Ku) * System.Math.Pow (C2, Expn));
			ref string reference8 = ref strTraceEff;
			reference2 = ref reference8;
			reference8 = reference2 + "      k=" + Units.DisplayNone (K, "", 0, 0) + "\t" + strEqKred + "\r\n";
		} else {
			if ((double)(Lip.D / W) <= 0.25) {
				K = (float)(3.57 * System.Math.Pow (Ri, Expn) + 0.43);
			} else {
				K = (float)((4.82 - (double)(5f * Lip.D / W)) * System.Math.Pow (Ri, Expn) + 0.43);
				if (K < Ku) {
					K = Ku;
				}
			}
			ref string reference9 = ref strTraceEff;
			reference2 = ref reference9;
			reference9 = reference2 + "      k=" + Units.DisplayNone (K, "", 0, 0) + "\t" + strEqKred + "\r\n";
		}
		if ((double)(Lip.D / W) > 0.80001) {
			strMsg = "Edge stiffener D/w exceeds 0.8.";
			if (Strings.InStr (strMsge, strMsg) == 0) {
				ref string reference10 = ref strMsge;
				reference10 = reference10 + strMsg + "\r\n";
			}
			blnRationalAnalysis = true;
			strTraceEff += "      Edge stiffener D/w exceeds 0.8, treat as rational analysis\r\n";
		}
		if (System.Math.Abs (System.Math.Sin (A - Lip.Ang)) < System.Math.Sin (0.69811424750521189)) {
			strMsg = "Edge stiffener angle not within 40°-140°.";
			if (Strings.InStr (strMsge, strMsg) == 0) {
				ref string reference11 = ref strMsge;
				reference11 = reference11 + strMsg + "\r\n";
			}
			blnRationalAnalysis = true;
			strTraceEff += "      Edge stiffener angle not within 40°-140°, treat as rational analysis\r\n";
		}
	}

	private void PartStiffened ()
	{
		Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
		L = (float)System.Math.Sqrt (F3 / Fcr);
		if (L > LambdaMax) {
			LambdaMax = L;
		}
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\r\n";
		ref string reference3 = ref strTraceEff;
		reference2 = ref reference3;
		reference3 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
		if (L <= 0.6732051f) {
			ref string reference4 = ref strTraceEff;
			reference4 = reference4 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
			return;
		}
		blnColdWorkAllowed = false;
		Be = (float)((double)W * (1.0 - 0.22 / (double)L) / (double)L);
		DW = W - Be;
		if (W > 0f) {
			strRho = Units.DisplayNone (Be / W, "", 0, 0);
		} else {
			strRho = "?";
		}
		ref string reference5 = ref strTraceEff;
		reference2 = ref reference5;
		reference5 = reference2 + "      ρ=" + strRho + "\t" + strEqRho + "\r\n";
		ref string reference6 = ref strTraceEff;
		reference2 = ref reference6;
		reference6 = reference2 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqB + "\r\n";
		if (CFS.IsSpec1999 (Spec1) & !blnSS) {
			B1 = C1 * Be / 2f;
			B2 = C2 * Be / 2f;
			Xc = X1 + (B1 + DW / 2f) * Cs;
			Yc = Y1 + (B1 + DW / 2f) * Sn;
		} else {
			B1 = Ri * Be / 2f;
			B2 = Be - B1;
			Xc = X1 + (B2 + DW / 2f) * Cs;
			Yc = Y1 + (B2 + DW / 2f) * Sn;
		}
		ref string reference7 = ref strTraceEff;
		reference2 = ref reference7;
		reference7 = reference2 + "      b₁=" + Units.DisplayLen1 (B1, 0, blnShowUnit: true, "", 0, 0) + ", b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		ReduceProperties ();
	}

	private void FullStiffened ()
	{
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      f₁=" + Units.DisplayStress ((float)CFS.Max (F1, F2), 0, blnShowUnit: true, "", 0, 0) + ", f₂=" + Units.DisplayStress ((float)CFS.Min (F1, F2), 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		B0 = 0f;
		if (F1 < 0f) {
			B0 = W * F1 / (F1 - F2);
		}
		if (F2 < 0f) {
			B0 = W * F2 / (F2 - F1);
		}
		if (F1 > F2) {
			Si = F2 / F1;
		} else {
			Si = F1 / F2;
		}
		if (CFS.IsSpec1999 (Spec1) & !blnSS) {
			K = (float)((double)(4f + 2f * (1f - Si)) + 2.0 * System.Math.Pow (1f - Si, 3.0));
			L = (float)(1.052 / System.Math.Sqrt (K * Rk) * (double)W / (double)T * System.Math.Sqrt (F3 / E));
			if (L > LambdaMax) {
				LambdaMax = L;
			}
			if (L > 0.6732051f) {
				Be = (float)((double)W * (1.0 - 0.22 / (double)L) / (double)L);
			} else {
				Be = W;
			}
			if (W > 0f) {
				strRho = Units.DisplayNone (Be / W, "", 0, 0);
			} else {
				strRho = "?";
			}
			ref string reference3 = ref strTraceEff;
			reference2 = ref reference3;
			reference3 = reference2 + "      ψ=" + Units.DisplayNone (Si, "", 0, 0) + "\t" + strEqSi + "\r\n";
			ref string reference4 = ref strTraceEff;
			reference2 = ref reference4;
			reference4 = reference2 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqK1 + "\r\n";
			ref string reference5 = ref strTraceEff;
			reference2 = ref reference5;
			reference5 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
			ref string reference6 = ref strTraceEff;
			reference2 = ref reference6;
			reference6 = reference2 + "      ρ=" + strRho + "\t" + strEqRho + "\r\n";
			ref string reference7 = ref strTraceEff;
			reference2 = ref reference7;
			reference7 = reference2 + "      be=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB + "\r\n";
			B1 = Be / (3f - Si);
			ref string reference8 = ref strTraceEff;
			reference2 = ref reference8;
			reference8 = reference2 + "      b₁=" + Units.DisplayLen1 (B1, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB1a + "\r\n";
			if (Si <= -0.236067981f) {
				B2 = Be / 2f;
				ref string reference9 = ref strTraceEff;
				reference2 = ref reference9;
				reference9 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2a + "\r\n";
			} else {
				B2 = Be - B1;
				ref string reference10 = ref strTraceEff;
				reference2 = ref reference10;
				reference10 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2b + "\r\n";
			}
		} else {
			Si = System.Math.Abs (Si);
			ref string reference11 = ref strTraceEff;
			reference2 = ref reference11;
			reference11 = reference2 + "      ψ=" + Units.DisplayNone (Si, "", 0, 0) + "\t" + strEqSi + "\r\n";
			if (System.Math.Sign (F1) != System.Math.Sign (F2)) {
				K = (float)((double)(4f + 2f * (1f + Si)) + 2.0 * System.Math.Pow (1f + Si, 3.0));
				ref string reference12 = ref strTraceEff;
				reference2 = ref reference12;
				reference12 = reference2 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqK1 + "\r\n";
			} else {
				K = (float)((double)(4f + 2f * (1f - Si)) + 2.0 * System.Math.Pow (1f - Si, 3.0));
				ref string reference13 = ref strTraceEff;
				reference2 = ref reference13;
				reference13 = reference2 + "      k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\t" + strEqK2 + "\r\n";
			}
			Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
			L = (float)System.Math.Sqrt (F3 / Fcr);
			if (L > LambdaMax) {
				LambdaMax = L;
			}
			ref string reference14 = ref strTraceEff;
			reference2 = ref reference14;
			reference14 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
			strEqRho1 = strEqRho;
			if (blnUseProcII) {
				Lc = (float)(0.256 + 0.328 * (double)W / (double)T * System.Math.Sqrt (Fy / E));
				if (L <= 0.6732051f) {
					Be = W;
				} else if (L < Lc) {
					Be = (float)((double)W * (1.358 - 0.461 / (double)L) / (double)L);
					strEqRho1 = strEqRhoIIa;
				} else {
					Be = (float)((double)W * (0.41 + 0.59 * System.Math.Sqrt (Fy / F3) - 0.22 / (double)L) / (double)L);
					strEqRho1 = strEqRhoIIb;
				}
			} else if (L > 0.6732051f) {
				Be = (float)((double)W * (1.0 - 0.22 / (double)L) / (double)L);
			} else {
				Be = W;
			}
			if (W > 0f) {
				strRho = Units.DisplayNone (Be / W, "", 0, 0);
			} else {
				strRho = "?";
			}
			ref string reference15 = ref strTraceEff;
			reference2 = ref reference15;
			reference15 = reference2 + "      ρ=" + strRho + "\t" + strEqRho1 + "\r\n";
			ref string reference16 = ref strTraceEff;
			reference2 = ref reference16;
			reference16 = reference2 + "      be=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB + "\r\n";
			if (System.Math.Sign (F1) != System.Math.Sign (F2)) {
				B1 = Be / (3f + Si);
				ref string reference17 = ref strTraceEff;
				reference2 = ref reference17;
				reference17 = reference2 + "      h₀=" + Units.DisplayLen1 (ho, 0, blnShowUnit: true, "", 0, 0) + ", b₀=" + Units.DisplayLen1 (bo, 0, blnShowUnit: true, "", 0, 0) + ", h₀/b₀=" + Units.DisplayNone (ho / bo, "", 0, 0) + "\r\n";
				if (ho / bo <= 4f) {
					ref string reference18 = ref strTraceEff;
					reference2 = ref reference18;
					reference18 = reference2 + "      b₁=" + Units.DisplayLen1 (B1, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB1a + "\r\n";
					if (Si > System.Math.Abs (-0.236067981f)) {
						B2 = Be / 2f;
						ref string reference19 = ref strTraceEff;
						reference2 = ref reference19;
						reference19 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2a + "\r\n";
					} else {
						B2 = Be - B1;
						ref string reference20 = ref strTraceEff;
						reference2 = ref reference20;
						reference20 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2b + "\r\n";
					}
				} else {
					B2 = Be / (1f + Si) - B1;
					ref string reference21 = ref strTraceEff;
					reference2 = ref reference21;
					reference21 = reference2 + "      b₁=" + Units.DisplayLen1 (B1, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB1c + "\r\n";
					ref string reference22 = ref strTraceEff;
					reference2 = ref reference22;
					reference22 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2c + "\r\n";
				}
			} else {
				B1 = Be / (3f - Si);
				B2 = Be - B1;
				ref string reference23 = ref strTraceEff;
				reference2 = ref reference23;
				reference23 = reference2 + "      b₁=" + Units.DisplayLen1 (B1, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB1d + "\r\n";
				ref string reference24 = ref strTraceEff;
				reference2 = ref reference24;
				reference24 = reference2 + "      b₂=" + Units.DisplayLen1 (B2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqB2d + "\r\n";
			}
		}
		if (B0 > 0f) {
			ref string reference25 = ref strTraceEff;
			reference25 = reference25 + "      Compression width=" + Units.DisplayLen1 (W - B0, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		}
		DW = W - B0 - B1 - B2;
		if ((double)DW <= 1E-06 * (double)System.Math.Abs (W)) {
			strTraceEff += "      b₁+b₂ > compression width (fully effective)\r\n";
			return;
		}
		ref string reference26 = ref strTraceEff;
		reference26 = reference26 + "      Ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		blnColdWorkAllowed = false;
		if (F1 > F2) {
			if ((B1 > W1) & (B1 < W1 + Dh)) {
				DW = DW + B1 - W1;
				B1 = W1;
			}
			if ((B1 + DW > W1) & (B1 + DW < W1 + Dh)) {
				DW = W1 - B1;
			}
			Xc = X1 + (B1 + DW / 2f) * Cs;
			Yc = Y1 + (B1 + DW / 2f) * Sn;
			ReduceProperties ();
			if ((B1 <= W1) & (B1 + DW >= W1 + Dh) & (Dh > 0f)) {
				DW = 0f - Dh;
				Xc = (Xh1 + Xh2) / 2f;
				Yc = (Yh1 + Yh2) / 2f;
				ReduceProperties ();
			}
		} else {
			if ((B1 > W2) & (B1 < W2 + Dh)) {
				DW = DW + B1 - W2;
				B1 = W2;
			}
			if ((B1 + DW > W2) & (B1 + DW < W2 + Dh)) {
				DW = W2 - B1;
			}
			Xc = X2 - (B1 + DW / 2f) * Cs;
			Yc = Y2 - (B1 + DW / 2f) * Sn;
			ReduceProperties ();
			if ((B1 <= W2) & (B1 + DW >= W2 + Dh) & (Dh > 0f)) {
				DW = 0f - Dh;
				Xc = (Xh1 + Xh2) / 2f;
				Yc = (Yh1 + Yh2) / 2f;
				ReduceProperties ();
			}
		}
	}

	private void HoleElement ()
	{
		Fcr = (float)((double)(K * Rk) * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
		L = (float)System.Math.Sqrt (F3 / Fcr);
		if (L > LambdaMax) {
			LambdaMax = L;
		}
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K * Rk, "", 0, 0) + strRk + "\r\n";
		ref string reference3 = ref strTraceEff;
		reference2 = ref reference3;
		reference3 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
		if (L <= 0.6732051f) {
			ref string reference4 = ref strTraceEff;
			reference4 = reference4 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
			return;
		}
		blnColdWorkAllowed = false;
		if ((CFS.SpecYear (Spec1) >= 2004) | blnSS) {
			Be = (float)((double)W * (1.0 - 0.22 / (double)L - 0.8 * (double)Dh / (double)W + 0.085 * (double)Dh / (double)W / (double)L) / (double)L);
		} else {
			Be = (float)((double)W * (1.0 - 0.22 / (double)L - 0.8 * (double)Dh / (double)W) / (double)L);
		}
		DW = (W - Dh - Be) / 2f;
		if (W > 0f) {
			strRho = Units.DisplayNone (Be / W, "", 0, 0);
		} else {
			strRho = "?";
		}
		ref string reference5 = ref strTraceEff;
		reference2 = ref reference5;
		reference5 = reference2 + "      ρ=" + strRho + "\t" + strEqRho + "\r\n";
		ref string reference6 = ref strTraceEff;
		reference2 = ref reference6;
		reference6 = reference2 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + " each side)\t" + strEqBhole + "\r\n";
		Xc = Xh1 - DW / 2f * Cs;
		Yc = Yh1 - DW / 2f * Sn;
		ReduceProperties ();
		Xc = Xh2 + DW / 2f * Cs;
		Yc = Yh2 + DW / 2f * Sn;
		ReduceProperties ();
	}

	private void UserStiffened ()
	{
		B0 = 0f;
		if (F1 < 0f) {
			B0 = W * F1 / (F1 - F2);
			F1 = 0f;
		}
		if (F2 < 0f) {
			B0 = W * F2 / (F2 - F1);
			F2 = 0f;
		}
		if (F1 > F2) {
			Si = F2 / F1;
		} else {
			Si = F1 / F2;
		}
		if (B0 > 0f) {
			ref string reference = ref strTraceEff;
			reference = reference + "      Compression width=" + Units.DisplayLen1 (W - B0, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		}
		F3 = (F1 + F2) / 2f;
		Fcr = (float)((double)K * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * System.Math.Pow (W - B0, 2.0)));
		L = (float)System.Math.Sqrt (F3 / Fcr);
		if (L > LambdaMax) {
			LambdaMax = L;
		}
		ref string reference2 = ref strTraceEff;
		ref string reference3 = ref reference2;
		reference2 = reference3 + "      f₁=" + Units.DisplayStress ((float)CFS.Max (F1, F2), 0, blnShowUnit: true, "", 0, 0) + ", f₂=" + Units.DisplayStress ((float)CFS.Min (F1, F2), 0, blnShowUnit: true, "", 0, 0) + ", f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + "\r\n";
		ref string reference4 = ref strTraceEff;
		reference3 = ref reference4;
		reference4 = reference3 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
		if (L <= 0.6732051f) {
			ref string reference5 = ref strTraceEff;
			reference5 = reference5 + "      λ<0.673 (fully effective)\t" + strEqW + "\r\n";
			return;
		}
		blnColdWorkAllowed = false;
		Be = (float)((double)(W - B0) * (1.0 - 0.22 / (double)L) / (double)L);
		B1 = Be / (3f - Si);
		B2 = Be - B1;
		DW = W - B0 - B1 - B2;
		if (W - B0 > 0f) {
			strRho = Units.DisplayNone (Be / (W - B0), "", 0, 0);
		} else {
			strRho = "?";
		}
		ref string reference6 = ref strTraceEff;
		reference3 = ref reference6;
		reference6 = reference3 + "      ρ=" + strRho + "\t" + strEqRho + "\r\n";
		ref string reference7 = ref strTraceEff;
		reference3 = ref reference7;
		reference7 = reference3 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqB + "\r\n";
		if (F1 > F2) {
			Xc = X1 + (B1 + DW / 2f) * Cs;
			Yc = Y1 + (B1 + DW / 2f) * Sn;
		} else {
			Xc = X2 - (B1 + DW / 2f) * Cs;
			Yc = Y2 - (B1 + DW / 2f) * Sn;
		}
		ReduceProperties ();
	}

	private void CoverPlate (float K)
	{
		Fcr = (float)((double)K * System.Math.PI * System.Math.PI * (double)E * (double)T * (double)T / (10.92 * (double)W * (double)W));
		L = (float)System.Math.Sqrt (F3 / Fcr);
		float num = Conversions.ToSingle (Interaction.IIf (L < 0.6732051f, 1, (1.0 - 0.22 / (double)L) / (double)L));
		ref string reference = ref strTraceEff;
		ref string reference2 = ref reference;
		reference = reference2 + "      f=" + Units.DisplayStress (F3, 0, blnShowUnit: true, "", 0, 0) + ", k=" + Units.DisplayNone (K, "", 0, 0) + "\r\n";
		ref string reference3 = ref strTraceEff;
		reference2 = ref reference3;
		reference3 = reference2 + "      Fcrl=" + Units.DisplayStress (Fcr, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqFcrl + "\r\n";
		ref string reference4 = ref strTraceEff;
		reference2 = ref reference4;
		reference4 = reference2 + "      λ=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambda + "\r\n";
		ref string reference5 = ref strTraceEff;
		reference2 = ref reference5;
		reference5 = reference2 + "      ρ=" + Units.DisplayNone (num, "", 0, 0) + "\t" + strEqRho + "\r\n";
		float num2 = (float)(3.29 * (double)E / System.Math.Pow (ConnSpa / T, 2.0));
		L = (float)System.Math.Sqrt (num2 / Fcr);
		float num3 = Conversions.ToSingle (Interaction.IIf (L < 0.6732051f, 1, (1.0 - 0.22 / (double)L) / (double)L));
		float num4 = (float)((double)(8f * Fy / F3) * System.Math.Sqrt (T / Depth * num2 / F3));
		if (num4 > 1f) {
			num4 = 1f;
		}
		if (num4 * num3 < num) {
			num = num4 * num3;
		}
		Be = num * W;
		DW = W - Be;
		ref string reference6 = ref strTraceEff;
		reference2 = ref reference6;
		reference6 = reference2 + "      Fc=" + Units.DisplayStress (num2, 0, blnShowUnit: true, "", 0, 0) + "\t" + strEqFc + "\r\n";
		ref string reference7 = ref strTraceEff;
		reference2 = ref reference7;
		reference7 = reference2 + "      λt=" + Units.DisplayNone (L, "", 0, 0) + "\t" + strEqLambdat + "\r\n";
		ref string reference8 = ref strTraceEff;
		reference2 = ref reference8;
		reference8 = reference2 + "      ρt=" + Units.DisplayNone (num3, "", 0, 0) + "\t" + strEqRhot + "\r\n";
		ref string reference9 = ref strTraceEff;
		reference2 = ref reference9;
		reference9 = reference2 + "      ρm=" + Units.DisplayNone (num4, "", 0, 0) + "\t" + strEqRhom + "\r\n";
		ref string reference10 = ref strTraceEff;
		reference2 = ref reference10;
		reference10 = reference2 + "      b=" + Units.DisplayLen1 (Be, 0, blnShowUnit: true, "", 0, 0) + " (ineffective width=" + Units.DisplayLen1 (DW, 0, blnShowUnit: true, "", 0, 0) + ")\t" + strEqB + "\r\n";
		Xc = X1 + (W / 2f - DW / 2f) * Cs;
		Yc = Y1 + (W / 2f - DW / 2f) * Sn;
		ReduceProperties ();
		if ((double)Depth < 1.5) {
			ref string reference11 = ref strTraceEff;
			reference11 = reference11 + "      Depth d < " + Units.DisplayLen1 (1.5f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if ((double)Depth > 7.5) {
			ref string reference12 = ref strTraceEff;
			reference12 = reference12 + "      Depth d > " + Units.DisplayLen1 (7.5f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if ((double)T < 0.035) {
			ref string reference13 = ref strTraceEff;
			reference13 = reference13 + "      Thickness t < " + Units.DisplayLen1 (0.035f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if ((double)T > 0.06) {
			ref string reference14 = ref strTraceEff;
			reference14 = reference14 + "      Thickness t > " + Units.DisplayLen1 (0.06f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if (ConnSpa < 2f) {
			ref string reference15 = ref strTraceEff;
			reference15 = reference15 + "      Spacing s < " + Units.DisplayLen1 (2f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if (ConnSpa > 8f) {
			ref string reference16 = ref strTraceEff;
			reference16 = reference16 + "      Spacing s > " + Units.DisplayLen1 (8f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if (Fy < 33f) {
			ref string reference17 = ref strTraceEff;
			reference17 = reference17 + "      Fy < " + Units.DisplayStress (33f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if (Fy > 60f) {
			ref string reference18 = ref strTraceEff;
			reference18 = reference18 + "      Fy > " + Units.DisplayStress (60f, 0, blnShowUnit: true, "", 0, 0) + " (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
		if (W / T > 350f) {
			strTraceEff += "      w/t > 350 (rational analysis)\r\n";
			blnRationalAnalysis = true;
		}
	}

	private void ReduceProperties ()
	{
		DA = DW * T;
		SA += 0f - DA;
		SAX += (0f - DA) * (Xcge + Xc);
		SAY += (0f - DA) * (Ycge + Yc);
		ref float sAX = ref SAX2;
		sAX = (float)((double)sAX + ((double)(0f - DA) * System.Math.Pow (Xcge + Xc, 2.0) - (double)DA * (System.Math.Pow (DW * Cs, 2.0) + System.Math.Pow (T * Sn, 2.0)) / 12.0));
		ref float sAY = ref SAY2;
		sAY = (float)((double)sAY + ((double)(0f - DA) * System.Math.Pow (Ycge + Yc, 2.0) - (double)DA * (System.Math.Pow (DW * Sn, 2.0) + System.Math.Pow (T * Cs, 2.0)) / 12.0));
		SAXY += (0f - DA) * (Xcge + Xc) * (Ycge + Yc) - DA * ((DW * DW - T * T) * Sn * Cs) / 12f;
	}
}
