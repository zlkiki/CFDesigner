// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

internal class GraphicsX
{
	public enum AlignText : byte
	{
		LeftTop,
		LeftCenter,
		LeftBottom,
		CenterTop,
		CenterCenter,
		CenterBottom,
		RightTop,
		RightCenter,
		RightBottom
	}

	private float _XOrigin;

	private float _YOrigin;

	private float _Width;

	private float _Height;

	private float _PrintWidth;

	private float _PrintHeight;

	private float _XUnitsPerInch;

	private float _YUnitsPerInch;

	private float _ScaleWidth;

	private float _ScaleHeight;

	private float _ScaleLeft;

	private float _ScaleTop;

	private float _ScaleWidthSave;

	private float _ScaleHeightSave;

	private float _ScaleLeftSave;

	private float _ScaleTopSave;

	private float _PenScale;

	private bool _IsPrinter;

	private Font _font;

	private PointF _pt;

	private AlignText _align;

	private float _angle;

	private Brush _brush;

	private PictureBox p;

	private Bitmap b;

	private Graphics g;

	[SpecialName]
	private float $STATIC$PrintDashLine$205112819CCCC$XbPrev;

	[SpecialName]
	private float $STATIC$PrintDashLine$205112819CCCC$YbPrev;

	[SpecialName]
	private float $STATIC$PrintDashLine$205112819CCCC$D1Prev;

	public float XOrigin => _XOrigin;

	public float YOrigin => _YOrigin;

	public float Width => _Width;

	public float Height => _Height;

	public float PrintWidth => _PrintWidth;

	public float PrintHeight => _PrintHeight;

	public float XUnitsPerInch => _XUnitsPerInch;

	public float YUnitsPerInch => _YUnitsPerInch;

	public float ScaleWidth => _ScaleWidth;

	public float ScaleHeight => _ScaleHeight;

	public float ScaleTop => _ScaleTop;

	public float ScaleLeft => _ScaleLeft;

	public float PenScale => _PenScale;

	public Graphics Graphics => g;

	public PictureBox PictureBox => p;

	public bool IsPrinter => _IsPrinter;

	public GraphicsX (ref PrintPageEventArgs e)
	{
		g = e.Graphics;
		_IsPrinter = true;
		_XOrigin = ((float)e.MarginBounds.Left - e.PageSettings.HardMarginX) / 100f;
		_YOrigin = ((float)e.MarginBounds.Top - e.PageSettings.HardMarginY) / 100f;
		_Width = (float)((double)e.MarginBounds.Width / 100.0);
		_Height = (float)((double)e.MarginBounds.Height / 100.0);
		_ScaleWidth = _Width * g.DpiX;
		_ScaleHeight = _Height * g.DpiY;
		_PrintWidth = (float)((double)e.PageSettings.Bounds.Right / 100.0);
		_PrintHeight = (float)((double)e.PageSettings.Bounds.Bottom / 100.0);
	}

	public GraphicsX (PictureBox picDraw)
	{
		p = picDraw;
		b = new Bitmap (p.ClientSize.Width, p.ClientSize.Height);
		g = Graphics.FromImage (b);
		_IsPrinter = false;
		_XOrigin = 0f;
		_YOrigin = 0f;
		_Width = (float)picDraw.ClientSize.Width / g.DpiX;
		_Height = (float)picDraw.ClientSize.Height / g.DpiY;
		_ScaleWidth = picDraw.ClientSize.Width;
		_ScaleHeight = picDraw.ClientSize.Height;
		_PrintWidth = _Width;
		_PrintHeight = _Height;
	}

	public void Scale (float X1, float Y1, float X2, float Y2)
	{
		Matrix matrix = new Matrix ();
		_ScaleLeftSave = _ScaleLeft;
		_ScaleTopSave = _ScaleTop;
		_ScaleWidthSave = _ScaleWidth;
		_ScaleHeightSave = _ScaleHeight;
		_ScaleLeft = X1;
		_ScaleTop = Y1;
		_ScaleWidth = X2 - X1;
		_ScaleHeight = Y1 - Y2;
		_XUnitsPerInch = ScaleWidth / Width;
		_YUnitsPerInch = ScaleHeight / Height;
		_PenScale = XUnitsPerInch;
		float offsetX = XOrigin - X1 / XUnitsPerInch;
		float offsetY = YOrigin + Height + Y2 / YUnitsPerInch;
		g.ResetTransform ();
		g.PageUnit = GraphicsUnit.Inch;
		matrix.Scale (1f / XUnitsPerInch, -1f / YUnitsPerInch, MatrixOrder.Append);
		matrix.Translate (offsetX, offsetY, MatrixOrder.Append);
		g.Transform = matrix;
	}

	public void SwapScale ()
	{
		if (!((_ScaleWidthSave == 0f) | (_ScaleHeightSave == 0f))) {
			float scaleLeft = _ScaleLeft;
			_ScaleLeft = _ScaleLeftSave;
			_ScaleLeftSave = scaleLeft;
			scaleLeft = _ScaleTop;
			_ScaleTop = _ScaleTopSave;
			_ScaleTopSave = scaleLeft;
			scaleLeft = _ScaleWidth;
			_ScaleWidth = _ScaleWidthSave;
			_ScaleWidthSave = scaleLeft;
			scaleLeft = _ScaleHeight;
			_ScaleHeight = _ScaleHeightSave;
			_ScaleHeightSave = scaleLeft;
			_XUnitsPerInch = ScaleWidth / Width;
			_YUnitsPerInch = ScaleHeight / Height;
			_PenScale = XUnitsPerInch;
			float offsetX = _XOrigin - _ScaleLeft / _XUnitsPerInch;
			float offsetY = _YOrigin + Height + (_ScaleTop - _ScaleHeight) / _YUnitsPerInch;
			Matrix matrix = new Matrix ();
			g.ResetTransform ();
			g.PageUnit = GraphicsUnit.Inch;
			matrix.Scale (1f / XUnitsPerInch, -1f / YUnitsPerInch, MatrixOrder.Append);
			matrix.Translate (offsetX, offsetY, MatrixOrder.Append);
			g.Transform = matrix;
		}
	}

	public void PreserveImage ()
	{
		p.Image = b;
	}

	public PointF DrawString (string s, Font font, Brush brush, float x, float y, AlignText align, float angle)
	{
		return DrawString (s, font, brush, x, y, align, angle, IsImage: false);
	}

	public PointF DrawString (string s, Font font, float x, float y)
	{
		return DrawString (s, font, _brush, x, y, _align, _angle, IsImage: false);
	}

	public PointF DrawString (string s, float x, float y)
	{
		return DrawString (s, _font, _brush, x, y, _align, _angle, IsImage: false);
	}

	public PointF DrawString (string s, Font font)
	{
		return DrawString (s, font, _brush, _pt.X, _pt.Y, _align, _angle, IsImage: false);
	}

	public PointF DrawString (string s)
	{
		return DrawString (s, _font, _brush, _pt.X, _pt.Y, _align, _angle, IsImage: false);
	}

	public PointF DrawString (string s, Font font, Brush brush, float x, float y, AlignText align, float angle, bool IsImage)
	{
		GraphicsState gstate = g.Save ();
		Matrix matrix = new Matrix ();
		checked {
			float offsetX = (int)Math.Round ((XOrigin + (x - ScaleLeft) / ScaleWidth * Width) * g.DpiX);
			float offsetY = (int)Math.Round ((YOrigin + (1f - (y - (ScaleTop - ScaleHeight)) / ScaleHeight) * Height) * g.DpiY);
			matrix.Translate (offsetX, offsetY);
			matrix.RotateAt (angle, new PointF (0f, 0f));
			g.PageUnit = GraphicsUnit.Pixel;
			g.Transform = matrix;
			PointF point = new PointF (0f, 0f);
			if (IsImage) {
				int num = 4;
				SizeF layoutArea = g.MeasureString (s, font, layoutArea, StringFormat.GenericDefault);
				layoutArea.Width = (float)Math.Ceiling (layoutArea.Width);
				layoutArea.Height = (float)Math.Ceiling (layoutArea.Height);
				Bitmap bitmap = new Bitmap ((int)Math.Round (layoutArea.Width + (float)(num * 2)), (int)Math.Round (layoutArea.Height + (float)(num * 2)), g);
				Graphics graphics = Graphics.FromImage (bitmap);
				graphics.PageUnit = GraphicsUnit.Pixel;
				graphics.FillRectangle (new SolidBrush (Color.White), 0, 0, bitmap.Width, bitmap.Height);
				graphics.DrawString (s, font, brush, num, num);
				switch (align) {
				case AlignText.LeftCenter:
					point.Y = (0f - layoutArea.Height) / 2f;
					break;
				case AlignText.LeftBottom:
					point.Y = 0f - layoutArea.Height;
					break;
				case AlignText.CenterTop:
					point.X = (0f - layoutArea.Width) / 2f;
					break;
				case AlignText.CenterCenter:
					point.X = (0f - layoutArea.Width) / 2f;
					point.Y = (0f - layoutArea.Height) / 2f;
					break;
				case AlignText.CenterBottom:
					point.X = (0f - layoutArea.Width) / 2f;
					point.Y = 0f - layoutArea.Height;
					break;
				case AlignText.RightTop:
					point.X = 0f - layoutArea.Width;
					break;
				case AlignText.RightCenter:
					point.X = 0f - layoutArea.Width;
					point.Y = (0f - layoutArea.Height) / 2f;
					break;
				case AlignText.RightBottom:
					point.X = 0f - layoutArea.Width;
					point.Y = 0f - layoutArea.Height;
					break;
				}
				point.X = (int)Math.Round (point.X);
				point.Y = (int)Math.Round (point.Y);
				g.CompositingMode = CompositingMode.SourceCopy;
				g.DrawImageUnscaled (bitmap, (int)Math.Round (point.X), (int)Math.Round (point.Y), 0, 0);
			} else {
				StringFormat stringFormat = new StringFormat (StringFormat.GenericTypographic);
				switch (align) {
				case AlignText.LeftTop:
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Near;
					break;
				case AlignText.LeftCenter:
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Center;
					break;
				case AlignText.LeftBottom:
					stringFormat.Alignment = StringAlignment.Near;
					stringFormat.LineAlignment = StringAlignment.Far;
					break;
				case AlignText.CenterTop:
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Near;
					break;
				case AlignText.CenterCenter:
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					break;
				case AlignText.CenterBottom:
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Far;
					break;
				case AlignText.RightTop:
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Near;
					break;
				case AlignText.RightCenter:
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Center;
					break;
				case AlignText.RightBottom:
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Far;
					break;
				}
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.DrawString (s, font, brush, point, stringFormat);
			}
			g.Restore (gstate);
			SizeF layoutArea2 = g.MeasureString (s, font, layoutArea2, StringFormat.GenericTypographic);
			PointF pointF = default(PointF);
			pointF.X = (float)((double)x - (double)layoutArea2.Height * Math.Sin ((double)angle * Math.PI / 180.0) * (double)XUnitsPerInch);
			pointF.Y = (float)((double)y - (double)layoutArea2.Height * Math.Cos ((double)angle * Math.PI / 180.0) * (double)YUnitsPerInch);
			_font = font;
			_pt = pointF;
			_align = align;
			_angle = angle;
			_brush = brush;
			return pointF;
		}
	}

	public PointF DrawValue (string Label, string Value, int LPad, float LabelWidth)
	{
		return DrawValue (Label, Value, LPad, LabelWidth, _font, _brush, _pt.X, _pt.Y);
	}

	public PointF DrawValue (string Label, string Value, int LPad, float LabelWidth, Font font)
	{
		return DrawValue (Label, Value, LPad, LabelWidth, font, _brush, _pt.X, _pt.Y);
	}

	public PointF DrawValue (string Label, string Value, int LPad, float LabelWidth, Font font, float x, float y)
	{
		return DrawValue (Label, Value, LPad, LabelWidth, font, _brush, x, y);
	}

	public PointF DrawValue (string Label, string Value, int LPad, float LabelWidth, Font font, Brush brush, float x, float y)
	{
		Font font2 = new Font ("Courier New", font.Size, FontStyle.Regular);
		PointF pointF = default(PointF);
		pointF.Y = _pt.Y;
		PointF pt = DrawString (Label, font, brush, x, y, AlignText.LeftTop, 0f);
		pointF.X = pt.X + LabelWidth;
		DrawString (Strings.Mid (Value, 1, LPad), font2, pointF.X, pointF.Y);
		pointF.X += MeasureString (Strings.Mid (Value, 1, LPad), font2, 0f).Width;
		DrawString (Strings.Mid (Value, checked(LPad + 1)), font, pointF.X, pointF.Y);
		return _pt = pt;
	}

	public SizeF MeasureString (string s, Font font, float angle)
	{
		return MeasureString (s, font, angle, IsImage: false);
	}

	public SizeF MeasureString (string s, Font font, float angle, bool IsImage)
	{
		SizeF layoutArea = g.MeasureString (s, font, layoutArea, (StringFormat)Interaction.IIf (IsImage, StringFormat.GenericDefault, StringFormat.GenericTypographic));
		layoutArea.Width = (float)((double)layoutArea.Width * Math.Sqrt (Math.Pow (Math.Cos ((double)angle * Math.PI / 180.0) * (double)XUnitsPerInch, 2.0) + Math.Pow (Math.Sin ((double)angle * Math.PI / 180.0) * (double)YUnitsPerInch, 2.0)));
		layoutArea.Height = (float)((double)layoutArea.Height * Math.Sqrt (Math.Pow (Math.Sin ((double)angle * Math.PI / 180.0) * (double)XUnitsPerInch, 2.0) + Math.Pow (Math.Cos ((double)angle * Math.PI / 180.0) * (double)YUnitsPerInch, 2.0)));
		return layoutArea;
	}

	public static float Transform (float Value, int iVarTrans)
	{
		return iVarTrans switch {
			1 => Value, 
			2 => (float)Math.Log (Value), 
			3 => (float)Math.Log10 (Value), 
			_ => Value, 
		};
	}

	public void PrintCurveGrid (CurveGridStructure crvGrid)
	{
		int[] intLabel = new int[10];
		int[] intLabel2 = new int[10];
		if (crvGrid.XAxis.Min >= crvGrid.XAxis.Max || crvGrid.YAxis.Min >= crvGrid.YAxis.Max) {
			return;
		}
		int iVarTrans = Conversions.ToInteger (Interaction.IIf (crvGrid.XAxis.LogScale, 3, 1));
		int iVarTrans2 = Conversions.ToInteger (Interaction.IIf (crvGrid.YAxis.LogScale, 3, 1));
		float num = Transform (crvGrid.XAxis.Min, iVarTrans);
		float num2 = Transform (crvGrid.XAxis.Max, iVarTrans);
		float num3 = Transform (crvGrid.YAxis.Min, iVarTrans2);
		float num4 = Transform (crvGrid.YAxis.Max, iVarTrans2);
		Color black;
		Color color;
		Color color2;
		Color black2;
		if (_IsPrinter) {
			black = Color.Black;
			color = Color.Black;
			color2 = Color.Black;
			black2 = Color.Black;
		} else {
			black = Color.Black;
			color = Color.FromArgb (128, 128, 128);
			color2 = Color.FromArgb (192, 192, 192);
			black2 = Color.Black;
		}
		SolidBrush brush = new SolidBrush (black);
		Font font = new Font (crvGrid.Font.Name, (float)(0.7 * (double)crvGrid.Font.Size));
		float num5 = (num2 - num) / crvGrid.Width;
		float num6 = (0f - (num4 - num3)) / crvGrid.Height;
		float num7 = num - crvGrid.Left * num5 + _ScaleLeft * num5;
		float x = num7 + _ScaleWidth * num5;
		float num8 = num4 - crvGrid.Top * num6 + _ScaleTop * num6;
		float y = num8 - _ScaleHeight * num6;
		Scale (num7, num8, x, y);
		Pen pen = new Pen (color2, PenScale / g.DpiX);
		Pen pen2 = new Pen (color, PenScale / g.DpiX);
		Pen pen3 = new Pen (black2, PenScale / g.DpiX);
		if (_IsPrinter) {
			pen.Width = (float)(0.001 * (double)PenScale);
			pen2.Width = (float)(0.008 * (double)PenScale);
			pen3.Width = (float)(0.008 * (double)PenScale);
		}
		float MajorFirst = default(float);
		float MinorFirst = default(float);
		float LabelFirst = default(float);
		int intPower = default(int);
		int intCycles = default(int);
		GetCurveIncrements (ref crvGrid.XAxis, ref MajorFirst, ref MinorFirst, ref LabelFirst, ref intPower, ref intCycles, ref intLabel);
		float MajorFirst2 = default(float);
		float MinorFirst2 = default(float);
		float LabelFirst2 = default(float);
		int intPower2 = default(int);
		int intCycles2 = default(int);
		GetCurveIncrements (ref crvGrid.YAxis, ref MajorFirst2, ref MinorFirst2, ref LabelFirst2, ref intPower2, ref intCycles2, ref intLabel2);
		if (crvGrid.XAxis.MinorInc > 0f) {
			if (!crvGrid.XAxis.LogScale || intCycles == 0) {
				float num9 = MinorFirst;
				float num10 = Transform (num9, iVarTrans);
				int num11 = 0;
				while (!((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min))) {
					g.DrawLine (pen, num10, num3, num10, num4);
					num11 = checked(num11 + 1);
					num9 = MinorFirst + crvGrid.XAxis.MinorInc * (float)num11;
					num10 = Transform (num9, iVarTrans);
				}
			} else {
				float num12 = (float)Math.Pow (10.0, Conversion.Int (num));
				float num9 = MinorFirst;
				while (true) {
					float num10 = (float)Math.Log10 (num9);
					if ((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min)) {
						break;
					}
					while (!((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min))) {
						g.DrawLine (pen, num10, num3, num10, num4);
						float num13 = ((!(num9 >= (float)((double)(5f * num12) - 0.001 * (double)(5f * num12 - crvGrid.XAxis.Min)))) ? (crvGrid.XAxis.MinorInc * num12) : (crvGrid.XAxis.MinorInc5 * num12));
						if (num9 >= (float)((double)(10f * num12) - 0.001 * (double)(10f * num12 - crvGrid.XAxis.Min))) {
							break;
						}
						num9 += num13;
						num10 = (float)Math.Log10 (num9);
					}
					num12 *= 10f;
					num9 = num12 + crvGrid.XAxis.MinorInc * num12;
				}
			}
		}
		if (crvGrid.YAxis.MinorInc > 0f) {
			if (!crvGrid.YAxis.LogScale || intCycles2 == 0) {
				float num9 = MinorFirst2;
				float num10 = Transform (num9, iVarTrans2);
				int num11 = 0;
				while (!((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min))) {
					g.DrawLine (pen, num, num10, num2, num10);
					num11 = checked(num11 + 1);
					num9 = MinorFirst2 + crvGrid.YAxis.MinorInc * (float)num11;
					num10 = Transform (num9, iVarTrans2);
				}
			} else {
				float num12 = (float)Math.Pow (10.0, Conversion.Int (num3));
				float num9 = MinorFirst2;
				while (true) {
					float num10 = (float)Math.Log10 (num9);
					if ((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min)) {
						break;
					}
					while (!((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min))) {
						g.DrawLine (pen, num, num10, num2, num10);
						float num13 = ((!(num9 >= (float)((double)(5f * num12) - 0.001 * (double)(5f * num12 - crvGrid.YAxis.Min)))) ? (crvGrid.YAxis.MinorInc * num12) : (crvGrid.YAxis.MinorInc5 * num12));
						if (num9 >= (float)((double)(10f * num12) - 0.001 * (double)(10f * num12 - crvGrid.YAxis.Min))) {
							break;
						}
						num9 += num13;
						num10 = (float)Math.Log10 (num9);
					}
					num12 *= 10f;
					num9 = num12 + crvGrid.YAxis.MinorInc * num12;
				}
			}
		}
		if (crvGrid.XAxis.MajorInc > 0f) {
			if (!crvGrid.XAxis.LogScale || intCycles == 0) {
				float num9 = MajorFirst;
				float num10 = Transform (num9, iVarTrans);
				int num11 = 0;
				while (!((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min))) {
					g.DrawLine (pen2, num10, num3, num10, num4);
					num11 = checked(num11 + 1);
					num9 = MajorFirst + crvGrid.XAxis.MajorInc * (float)num11;
					num10 = Transform (num9, iVarTrans);
				}
			} else {
				float num12 = (float)Math.Pow (10.0, Conversion.Int (num));
				float num9 = MajorFirst;
				while (true) {
					float num10 = (float)Math.Log10 (num9);
					if ((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min)) {
						break;
					}
					while (!((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min))) {
						g.DrawLine (pen2, num10, num3, num10, num4);
						float num13 = ((!(num9 >= (float)((double)(5f * num12) - 0.001 * (double)(5f * num12 - crvGrid.XAxis.Min)))) ? (crvGrid.XAxis.MajorInc * num12) : (crvGrid.XAxis.MajorInc5 * num12));
						if (num9 >= (float)((double)(10f * num12) - 0.001 * (double)(10f * num12 - crvGrid.XAxis.Min))) {
							break;
						}
						num9 += num13;
						num10 = (float)Math.Log10 (num9);
					}
					num12 *= 10f;
					num9 = (float)((double)(crvGrid.XAxis.MajorInc * num12) * Math.Ceiling ((1f + crvGrid.XAxis.MinorInc) / crvGrid.XAxis.MajorInc));
				}
			}
		}
		checked {
			float num16;
			float x2;
			float y2;
			if (crvGrid.XAxis.LabelInc > 0f) {
				float height;
				if (unchecked(!crvGrid.XAxis.LogScale || intCycles == 0)) {
					float num9 = LabelFirst;
					float num10 = Transform (num9, iVarTrans);
					int num11 = 0;
					height = MeasureString (Conversions.ToString (num9), crvGrid.Font, 0f).Height;
					while (!((double)num9 > (double)crvGrid.XAxis.Max + 0.001 * (double)(crvGrid.XAxis.Max - crvGrid.XAxis.Min))) {
						x2 = num10;
						y2 = (float)((double)num3 - 0.4 * (double)height);
						DrawString (Strings.Format ((float)((double)num9 / Math.Pow (10.0, intPower))), crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
						num11++;
						num9 = LabelFirst + crvGrid.XAxis.LabelInc * (float)num11;
						num10 = Transform (num9, iVarTrans);
					}
				} else {
					float num12 = (float)Math.Pow (10.0, Conversion.Int (num));
					height = MeasureString ("1", crvGrid.Font, 0f).Height;
					while (!(num12 > crvGrid.XAxis.Max)) {
						if (num12 >= crvGrid.XAxis.Min) {
							float num10 = (int)Math.Round (Math.Log10 (num12));
							x2 = num10;
							y2 = (float)((double)num3 - 0.4 * (double)height);
							if (num10 == -1f) {
								DrawString ("0.1", crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
							} else if (num10 == 0f) {
								DrawString ("1", crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
							} else if (num10 == 1f) {
								DrawString ("10", crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
							} else if (num10 == 2f) {
								DrawString ("100", crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
							} else {
								DrawString ("10", crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
								x2 = (float)((double)num10 + 0.5 * (double)MeasureString ("10", crvGrid.Font, 0f).Width);
								y2 = (float)((double)num3 - 0.4 * (double)height);
								DrawString (Conversions.ToString (num10), font, brush, x2, y2, AlignText.LeftTop, 0f);
							}
						}
						int num14 = Information.LBound (intLabel);
						int num15 = Information.UBound (intLabel);
						for (int i = num14; i <= num15; i++) {
							float num9 = (float)intLabel [i] * num12;
							if (num9 > crvGrid.XAxis.Max) {
								goto end_IL_0a69;
							}
							if (num9 >= crvGrid.XAxis.Min) {
								float num10 = (float)Math.Log10 (num9);
								x2 = num10;
								y2 = (float)((double)num3 - 0.4 * (double)height);
								if (unchecked((double)num9 > 0.1 && num9 < 100f)) {
									DrawString (Conversions.ToString (num9), crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
								} else {
									DrawString (Conversions.ToString (intLabel [i]), crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
								}
							}
						}
						num12 *= 10f;
						continue;
						end_IL_0a69:
						break;
					}
				}
				num16 = (float)((double)num3 - 1.6 * (double)height);
			} else {
				num16 = (float)((double)num3 - 0.5 * (double)MeasureString (crvGrid.XAxis.Title, crvGrid.Font, 0f).Height);
			}
			if (crvGrid.YAxis.MajorInc > 0f) {
				if (unchecked(!crvGrid.YAxis.LogScale || intCycles2 == 0)) {
					float num9 = MajorFirst2;
					float num10 = Transform (num9, iVarTrans2);
					int num11 = 0;
					while (!((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min))) {
						g.DrawLine (pen2, num, num10, num2, num10);
						num11++;
						num9 = MajorFirst2 + crvGrid.YAxis.MajorInc * (float)num11;
						num10 = Transform (num9, iVarTrans2);
					}
				} else {
					float num12 = (float)Math.Pow (10.0, Conversion.Int (num3));
					float num9 = MajorFirst2;
					while (true) {
						float num10 = (float)Math.Log10 (num9);
						if ((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min)) {
							break;
						}
						while (!((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min))) {
							g.DrawLine (pen2, num, num10, num2, num10);
							float num13 = ((!(num9 >= (float)((double)(5f * num12) - 0.001 * (double)(5f * num12 - crvGrid.YAxis.Min)))) ? (crvGrid.YAxis.MajorInc * num12) : (crvGrid.YAxis.MajorInc5 * num12));
							if (num9 >= (float)((double)(10f * num12) - 0.001 * (double)(10f * num12 - crvGrid.YAxis.Min))) {
								break;
							}
							num9 += num13;
							num10 = (float)Math.Log10 (num9);
						}
						num12 *= 10f;
						num9 = (float)((double)(crvGrid.YAxis.MajorInc * num12) * Math.Ceiling ((1f + crvGrid.YAxis.MinorInc) / crvGrid.YAxis.MajorInc));
					}
				}
			}
			float num17 = num;
			if (crvGrid.YAxis.LabelInc > 0f) {
				if (unchecked(!crvGrid.YAxis.LogScale || intCycles2 == 0)) {
					float num9 = LabelFirst2;
					float num10 = Transform (num9, iVarTrans2);
					int num11 = 0;
					while (!((double)num9 > (double)crvGrid.YAxis.Max + 0.001 * (double)(crvGrid.YAxis.Max - crvGrid.YAxis.Min))) {
						x2 = num;
						y2 = num10;
						DrawString (Strings.Format ((float)((double)num9 / Math.Pow (10.0, intPower2))), crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
						float width = MeasureString (Strings.Format ((float)((double)num9 / Math.Pow (10.0, intPower2))), crvGrid.Font, 0f).Width;
						if (num - width < num17) {
							num17 = num - width;
						}
						num11++;
						num9 = LabelFirst2 + crvGrid.YAxis.LabelInc * (float)num11;
						num10 = Transform (num9, iVarTrans2);
					}
				} else {
					float num12 = (float)Math.Pow (10.0, Conversion.Int (num3));
					while (!(num12 > crvGrid.YAxis.Max)) {
						if (num12 >= crvGrid.YAxis.Min) {
							float num10 = (int)Math.Round (Math.Log10 (num12));
							float width2 = MeasureString (Conversions.ToString (Conversion.Int ((float)Math.Log10 (num12))), font, 0f).Width;
							x2 = (float)((double)num - 1.25 * (double)width2);
							y2 = num10;
							float width;
							if (num10 == -1f) {
								DrawString ("0.1", crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								width = (float)((double)MeasureString ("0.1", crvGrid.Font, 0f).Width + 1.25 * (double)width2);
							} else if (num10 == 0f) {
								DrawString ("1", crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								width = (float)((double)MeasureString ("1", crvGrid.Font, 0f).Width + 1.25 * (double)width2);
							} else if (num10 == 1f) {
								DrawString ("10", crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								width = (float)((double)MeasureString ("10", crvGrid.Font, 0f).Width + 1.25 * (double)width2);
							} else if (num10 == 2f) {
								DrawString ("100", crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								width = (float)((double)MeasureString ("100", crvGrid.Font, 0f).Width + 1.25 * (double)width2);
							} else {
								DrawString ("10", crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								x2 = num;
								y2 = (float)((double)num10 + 0.15 * (double)MeasureString (Conversions.ToString (Conversion.Int ((float)Math.Log10 (num12))), font, 0f).Height);
								DrawString (Conversions.ToString (num10), font, brush, x2, y2, AlignText.RightCenter, 0f);
								width = (float)((double)MeasureString ("10", crvGrid.Font, 0f).Width + 1.25 * (double)width2);
							}
							if (num - width < num17) {
								num17 = num - width;
							}
						}
						int num18 = Information.LBound (intLabel2);
						int num19 = Information.UBound (intLabel2);
						for (int i = num18; i <= num19; i++) {
							float num9 = (float)intLabel2 [i] * num12;
							if (num9 > crvGrid.YAxis.Max) {
								goto end_IL_10a4;
							}
							if (num9 >= crvGrid.YAxis.Min) {
								float num10 = (float)Math.Log10 (num9);
								x2 = num;
								y2 = num10;
								if (unchecked((double)num9 > 0.1 && num9 < 100f)) {
									DrawString (Conversions.ToString (num9), crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								} else {
									DrawString (Conversions.ToString (intLabel2 [i]), crvGrid.Font, brush, x2, y2, AlignText.RightCenter, 0f);
								}
							}
						}
						num12 *= 10f;
						continue;
						end_IL_10a4:
						break;
					}
				}
			}
			num17 = (float)((double)num17 - 0.5 * (double)MeasureString (crvGrid.YAxis.Title, crvGrid.Font, -90f).Height);
			g.DrawLine (pen3, num, num3, num, num4);
			g.DrawLine (pen3, num, num3, num2, num3);
			string text = crvGrid.XAxis.Title;
			if (intPower != 0) {
				text = text + " (x " + Conversions.ToString (Math.Pow (10.0, intPower)) + ")";
			}
			x2 = (num + num2) / 2f;
			y2 = num16;
			DrawString (text, crvGrid.Font, brush, x2, y2, AlignText.CenterTop, 0f);
			text = crvGrid.YAxis.Title;
			if (intPower2 != 0) {
				text = text + " (x " + Conversions.ToString (Math.Pow (10.0, intPower2)) + ")";
			}
			x2 = num17;
			y2 = (num3 + num4) / 2f;
			DrawString (text, crvGrid.Font, brush, x2, y2, AlignText.CenterBottom, -90f, IsImage: false);
		}
	}

	public void PrintCurve (CurveGridStructure crvGrid, CurveDataStructure crvData)
	{
		if (crvGrid.XAxis.Min >= crvGrid.XAxis.Max || crvGrid.YAxis.Min >= crvGrid.YAxis.Max) {
			return;
		}
		int iVarTrans = Conversions.ToInteger (Interaction.IIf (crvGrid.XAxis.LogScale, 3, 1));
		int iVarTrans2 = Conversions.ToInteger (Interaction.IIf (crvGrid.YAxis.LogScale, 3, 1));
		float num = Transform (crvGrid.XAxis.Min, iVarTrans);
		float num2 = Transform (crvGrid.XAxis.Max, iVarTrans);
		float num3 = Transform (crvGrid.YAxis.Min, iVarTrans2);
		float num4 = Transform (crvGrid.YAxis.Max, iVarTrans2);
		Pen pen = ((!_IsPrinter) ? new Pen (Color.Blue, PenScale / g.DpiX) : new Pen (Color.Black, (float)(0.016 * (double)PenScale)));
		SolidBrush brush = new SolidBrush (pen.Color);
		float num5 = Transform (crvData.HardLimit.Xmin, iVarTrans);
		float num6 = Transform (crvData.SoftLimit.Xmin, iVarTrans);
		float num7 = Transform (crvData.SoftLimit.Xmax, iVarTrans);
		float num8 = Transform (crvData.HardLimit.Xmax, iVarTrans);
		float num9 = Transform (crvData.HardLimit.Ymin, iVarTrans2);
		float num10 = Transform (crvData.SoftLimit.Ymin, iVarTrans2);
		float num11 = Transform (crvData.SoftLimit.Ymax, iVarTrans2);
		float num12 = Transform (crvData.HardLimit.Ymax, iVarTrans2);
		if (num > num5) {
			num5 = num;
		}
		if (num2 < num8) {
			num8 = num2;
		}
		if (num3 > num9) {
			num9 = num3;
		}
		if (num4 < num12) {
			num12 = num4;
		}
		checked {
			int num13 = Information.UBound (crvData.Points) - 1;
			for (int i = 1; i <= num13; i++) {
				float num14 = Transform (crvData.Points [i].X, iVarTrans);
				float num15 = Transform (crvData.Points [i].Y, iVarTrans2);
				float num16 = Transform (crvData.Points [i + 1].X, iVarTrans) - num14;
				float num17 = Transform (crvData.Points [i + 1].Y, iVarTrans2) - num15;
				float num18 = 0f;
				float num19 = 0f;
				float num20 = 1f;
				float num21 = 1f;
				unchecked {
					if (num16 == 0f) {
						if (num14 < num5) {
							num18 = 1f;
						}
						if (num14 < num6) {
							num19 = 1f;
						}
						if (num14 > num7) {
							num20 = 0f;
						}
						if (num14 > num8) {
							num21 = 0f;
						}
					} else {
						float num22 = (num5 - num14) / num16;
						if (num16 > 0f && num22 > num18) {
							num18 = num22;
						}
						if (num16 < 0f && num22 < num21) {
							num21 = num22;
						}
						num22 = (num6 - num14) / num16;
						if (num16 > 0f && num22 > num19) {
							num19 = num22;
						}
						if (num16 < 0f && num22 < num20) {
							num20 = num22;
						}
						num22 = (num7 - num14) / num16;
						if (num16 > 0f && num22 < num20) {
							num20 = num22;
						}
						if (num16 < 0f && num22 > num19) {
							num19 = num22;
						}
						num22 = (num8 - num14) / num16;
						if (num16 > 0f && num22 < num21) {
							num21 = num22;
						}
						if (num16 < 0f && num22 > num18) {
							num18 = num22;
						}
					}
					if (num17 == 0f) {
						if (num15 < num9) {
							num18 = 1f;
						}
						if (num15 < num10) {
							num19 = 1f;
						}
						if (num15 > num11) {
							num20 = 0f;
						}
						if (num15 > num12) {
							num21 = 0f;
						}
					} else {
						float num22 = (num9 - num15) / num17;
						if (num17 > 0f && num22 > num18) {
							num18 = num22;
						}
						if (num17 < 0f && num22 < num21) {
							num21 = num22;
						}
						num22 = (num10 - num15) / num17;
						if (num17 > 0f && num22 > num19) {
							num19 = num22;
						}
						if (num17 < 0f && num22 < num20) {
							num20 = num22;
						}
						num22 = (num11 - num15) / num17;
						if (num17 > 0f && num22 < num20) {
							num20 = num22;
						}
						if (num17 < 0f && num22 > num19) {
							num19 = num22;
						}
						num22 = (num12 - num15) / num17;
						if (num17 > 0f && num22 < num21) {
							num21 = num22;
						}
						if (num17 < 0f && num22 > num18) {
							num18 = num22;
						}
					}
					if (num21 < num18) {
						num21 = num18;
					}
					if (num19 < num18) {
						num19 = num18;
					}
					if (num19 > num21) {
						num19 = num21;
					}
					if (num20 < num18) {
						num20 = num18;
					}
					if (num20 > num21) {
						num20 = num21;
					}
					if (num20 < num19) {
						num20 = num19;
					}
					bool flag = false;
					if (num18 < num19) {
						PrintDashLine (pen, num14 + num18 * num16, num15 + num18 * num17, num14 + num19 * num16, num15 + num19 * num17);
						if (num18 == 0f) {
							flag = true;
						}
					}
					if (num19 < num20) {
						g.DrawLine (pen, num14 + num19 * num16, num15 + num19 * num17, num14 + num20 * num16, num15 + num20 * num17);
						if (num19 == 0f) {
							flag = true;
						}
					}
					if (num20 < num21) {
						PrintDashLine (pen, num14 + num20 * num16, num15 + num20 * num17, num14 + num21 * num16, num15 + num21 * num17);
						if (num20 == 0f) {
							flag = true;
						}
					}
					if ((flag & (Strings.Len (crvData.Symbol) > 0)) && ((crvData.SymbolPoint == 0) | (crvData.SymbolPoint == i))) {
						if (!crvData.FontTransparent) {
							SizeF sizeF = MeasureString (crvData.Symbol, crvData.Font, 0f);
							g.FillRectangle (new SolidBrush (Color.White), num14 - sizeF.Width / 2f, num15 - sizeF.Height / 2f, sizeF.Width, sizeF.Height);
						}
						DrawString (crvData.Symbol, crvData.Font, brush, num14, num15, AlignText.CenterCenter, 0f, IsImage: true);
					}
				}
			}
		}
	}

	public void PrintDashLine (Pen pen, float Xa, float Ya, float Xb, float Yb)
	{
		float num = ((!_IsPrinter) ? (6f / g.DpiX) : (1f / 12f));
		float num2 = num;
		float num3 = (float)Math.Sqrt (Math.Pow ((Xb - Xa) / XUnitsPerInch, 2.0) + Math.Pow ((Yb - Ya) / YUnitsPerInch, 2.0));
		if (num3 == 0f) {
			return;
		}
		if ((Xa != $STATIC$PrintDashLine$205112819CCCC$XbPrev) | (Ya != $STATIC$PrintDashLine$205112819CCCC$YbPrev)) {
			$STATIC$PrintDashLine$205112819CCCC$D1Prev = num2;
		}
		float num4 = $STATIC$PrintDashLine$205112819CCCC$D1Prev;
		while (!(num4 >= num3)) {
			float num5 = num4 + num;
			if (num4 < 0f) {
				num4 = 0f;
			}
			if (num5 > num3) {
				num5 = num3;
			}
			float x = Xa + num4 / num3 * (Xb - Xa);
			float y = Ya + num4 / num3 * (Yb - Ya);
			float x2 = Xa + num5 / num3 * (Xb - Xa);
			float y2 = Ya + num5 / num3 * (Yb - Ya);
			if (_IsPrinter) {
				g.DrawLine (pen, x, y, x2, y2);
			} else {
				g.DrawLine (pen, x, y, x2, y2);
			}
			if (num5 == num3) {
				break;
			}
			num4 = num5 + num2;
		}
		if (num4 == 0f) {
			num4 = $STATIC$PrintDashLine$205112819CCCC$D1Prev;
		}
		$STATIC$PrintDashLine$205112819CCCC$D1Prev = num4 - num3;
		$STATIC$PrintDashLine$205112819CCCC$XbPrev = Xb;
		$STATIC$PrintDashLine$205112819CCCC$YbPrev = Yb;
	}

	public void PrintX (float x, float y, float size)
	{
		GraphicsState gstate = g.Save ();
		Matrix matrix = new Matrix ();
		checked {
			float offsetX = (int)Math.Round ((XOrigin + (x - ScaleLeft) / ScaleWidth * Width) * g.DpiX);
			float offsetY = (int)Math.Round ((YOrigin + (1f - (y - (ScaleTop - ScaleHeight)) / ScaleHeight) * Height) * g.DpiY);
			matrix.Translate (offsetX, offsetY);
			g.PageUnit = GraphicsUnit.Pixel;
			g.Transform = matrix;
			Pen pen = new Pen (Color.Black, (float)(0.008 * (double)g.DpiX));
			int num = (int)Math.Round (size * g.DpiX);
			if (unchecked(num % 2) == 0) {
				num++;
			}
			int num2 = (int)Math.Round (size * g.DpiY);
			if (unchecked(num2 % 2) == 0) {
				num2++;
			}
			int num3 = (int)Math.Round ((double)(num - 1) / 2.0);
			int num4 = (int)Math.Round ((double)(num2 - 1) / 2.0);
			g.DrawLine (pen, -num3, -num4, num3, num4);
			g.DrawLine (pen, -num3, num4, num3, -num4);
			g.Restore (gstate);
		}
	}

	public void PrintError (CurveGridStructure crvGrid)
	{
		int iVarTrans = Conversions.ToInteger (Interaction.IIf (crvGrid.XAxis.LogScale, 3, 1));
		int iVarTrans2 = Conversions.ToInteger (Interaction.IIf (crvGrid.YAxis.LogScale, 3, 1));
		float num = Transform (crvGrid.XAxis.Min, iVarTrans);
		float num2 = Transform (crvGrid.XAxis.Max, iVarTrans);
		float num3 = Transform (crvGrid.YAxis.Min, iVarTrans2);
		float num4 = Transform (crvGrid.YAxis.Max, iVarTrans2);
		float x = (float)((double)num + (double)(num2 - num) * 0.5);
		float y = (float)((double)num3 + (double)(num4 - num3) * 0.5);
		float emSize = 20f * Width / 10f;
		Font font = new Font ("Arial", emSize, FontStyle.Bold);
		SolidBrush brush = new SolidBrush (Color.Red);
		PointF pointF = DrawString ("CALCULATION ERROR", font, brush, x, y, AlignText.CenterBottom, 0f, IsImage: true);
		DrawString ("CURVES ARE NOT VALID", font, brush, pointF.X, pointF.Y, AlignText.CenterBottom, 0f, IsImage: true);
	}

	private void GetCurveIncrements (ref AxisType Axis, ref float MajorFirst, ref float MinorFirst, ref float LabelFirst, ref int intPower, ref int intCycles, ref int[] intLabel)
	{
		float[] array = new float[9] { 0f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 20f, 50f };
		checked {
			if (Axis.LogScale) {
				if (Axis.ManualInc & ((float)Math.Log10 (Axis.Max / Axis.Min) < 1f)) {
					MajorFirst = Axis.Min;
					MinorFirst = Axis.Min;
					LabelFirst = Axis.Min;
					if (Axis.MajorInc > 0f) {
						MajorFirst = (float)((double)Axis.MajorInc * Math.Ceiling (Axis.Min / Axis.MajorInc));
					}
					if (Axis.MinorInc > 0f) {
						MinorFirst = (float)((double)Axis.MinorInc * Math.Ceiling (Axis.Min / Axis.MinorInc));
					}
					if (Axis.LabelInc > 0f) {
						LabelFirst = (float)((double)Axis.LabelInc * Math.Ceiling (Axis.Min / Axis.LabelInc));
					}
					intCycles = 0;
				} else if ((float)Math.Log10 (Axis.Max / Axis.Min) < 1f) {
					intCycles = 0;
					int num = (int)Conversion.Int ((float)Math.Log10 (Axis.Max - Axis.Min));
					Axis.MajorInc = (float)(5.0 / (5.0 * Math.Pow (10.0, num) / (double)(Axis.Max - Axis.Min)));
					if (Axis.MajorInc > array [8]) {
						Axis.MajorInc = array [8];
					}
					int num2 = 3;
					do {
						if (array [num2] >= Axis.MajorInc) {
							Axis.MajorInc = (float)((double)array [num2] * Math.Pow (10.0, num - 1));
							Axis.MinorInc = (float)((double)array [num2 - 2] * Math.Pow (10.0, num - 1));
							break;
						}
						num2++;
					} while (num2 <= 8);
					MajorFirst = (float)((double)Axis.MajorInc * Math.Ceiling (Axis.Min / Axis.MajorInc));
					MinorFirst = (float)((double)Axis.MinorInc * Math.Ceiling (Axis.Min / Axis.MinorInc));
					Axis.MajorInc5 = Axis.MajorInc;
					Axis.MinorInc5 = Axis.MinorInc;
					Axis.LabelInc = Axis.MajorInc;
					LabelFirst = MajorFirst;
				} else {
					intCycles = (int)Math.Round (Math.Log10 (Axis.Max / Axis.Min));
					int num3 = Information.LBound (intLabel);
					int num4 = Information.UBound (intLabel);
					for (int num2 = num3; num2 <= num4; num2++) {
						intLabel [num2] = 0;
					}
					switch (intCycles) {
					case 1: {
						Axis.MinorInc = 0.1f;
						Axis.MinorInc5 = 0.2f;
						Axis.MajorInc = 0.5f;
						Axis.MajorInc5 = 1f;
						int num2 = 2;
						do {
							intLabel [num2] = num2;
							num2++;
						} while (num2 <= 9);
						break;
					}
					case 2:
					case 3: {
						Axis.MinorInc = 0.25f;
						Axis.MinorInc5 = 0.5f;
						Axis.MajorInc = 1f;
						Axis.MajorInc5 = 1f;
						int num2 = 2;
						do {
							intLabel [num2] = num2;
							num2++;
						} while (num2 <= 6);
						intLabel [8] = 8;
						break;
					}
					case 4:
					case 5:
						Axis.MinorInc = 0.5f;
						Axis.MinorInc5 = 1f;
						Axis.MajorInc = 1f;
						Axis.MajorInc5 = 5f;
						intLabel [3] = 3;
						intLabel [5] = 5;
						break;
					case 6:
					case 7:
						Axis.MinorInc = 0.5f;
						Axis.MinorInc5 = 1f;
						Axis.MajorInc = 5f;
						Axis.MajorInc5 = 5f;
						intLabel [5] = 5;
						break;
					default:
						Axis.MinorInc = 1f;
						Axis.MinorInc5 = 5f;
						Axis.MajorInc = 5f;
						Axis.MajorInc5 = 5f;
						break;
					}
					int num5 = (int)Conversion.Int ((float)Math.Log10 (Axis.Min));
					if ((double)Axis.Min < 5.0 * Math.Pow (10.0, num5)) {
						MajorFirst = (float)((double)Axis.MajorInc * Math.Pow (10.0, num5) * Math.Ceiling ((float)((double)Axis.Min / ((double)Axis.MajorInc * Math.Pow (10.0, num5)))));
						MinorFirst = (float)((double)Axis.MinorInc * Math.Pow (10.0, num5) * Math.Ceiling ((float)((double)Axis.Min / ((double)Axis.MinorInc * Math.Pow (10.0, num5)))));
					} else {
						MajorFirst = (float)((double)Axis.MajorInc5 * Math.Pow (10.0, num5) * Math.Ceiling ((float)((double)Axis.Min / ((double)Axis.MajorInc5 * Math.Pow (10.0, num5)))));
						MinorFirst = (float)((double)Axis.MinorInc5 * Math.Pow (10.0, num5) * Math.Ceiling ((float)((double)Axis.Min / ((double)Axis.MinorInc5 * Math.Pow (10.0, num5)))));
					}
					Axis.LabelInc = Axis.MajorInc;
					if (intCycles == 0) {
						LabelFirst = MajorFirst;
					}
				}
				intPower = (int)Math.Round (Conversion.Int ((float)Math.Log10 (Axis.Min)) - 1f);
			} else {
				if (Axis.ManualInc) {
					MajorFirst = Axis.Min;
					MinorFirst = Axis.Min;
					LabelFirst = Axis.Min;
					if (Axis.MajorInc > 0f) {
						MajorFirst = (float)((double)Axis.MajorInc * Math.Ceiling (Axis.Min / Axis.MajorInc));
					}
					if (Axis.MinorInc > 0f) {
						MinorFirst = (float)((double)Axis.MinorInc * Math.Ceiling (Axis.Min / Axis.MinorInc));
					}
					if (Axis.LabelInc > 0f) {
						LabelFirst = (float)((double)Axis.LabelInc * Math.Ceiling (Axis.Min / Axis.LabelInc));
					}
				} else {
					int num = (int)Conversion.Int ((float)Math.Log10 (Axis.Max - Axis.Min));
					Axis.MajorInc = (float)(5.0 / (5.0 * Math.Pow (10.0, num) / (double)(Axis.Max - Axis.Min)));
					if (Axis.MajorInc > array [8]) {
						Axis.MajorInc = array [8];
					}
					int num2 = 3;
					do {
						if (array [num2] >= Axis.MajorInc) {
							Axis.MajorInc = (float)((double)array [num2] * Math.Pow (10.0, num - 1));
							Axis.MinorInc = (float)((double)array [num2 - 2] * Math.Pow (10.0, num - 1));
							break;
						}
						num2++;
					} while (num2 <= 8);
					MajorFirst = (float)((double)Axis.MajorInc * Math.Ceiling (Axis.Min / Axis.MajorInc));
					MinorFirst = (float)((double)Axis.MinorInc * Math.Ceiling (Axis.Min / Axis.MinorInc));
					Axis.LabelInc = Axis.MajorInc;
					LabelFirst = MajorFirst;
				}
				Axis.MajorInc5 = Axis.MajorInc;
				Axis.MinorInc5 = Axis.MinorInc;
				float num6 = ((Math.Sign (Axis.Min) == Math.Sign (Axis.Max)) ? ((Math.Abs (Axis.Min) + Math.Abs (Axis.Max)) / 2f) : ((float)(0.5 * (double)(Axis.Min * Axis.Min + Axis.Max * Axis.Max) / (double)Math.Abs (Axis.Max - Axis.Min))));
				intPower = (int)Math.Round (Conversion.Int ((float)Math.Log10 (num6)) - 1f);
			}
			if (!Axis.AllowPower) {
				intPower = 0;
			}
		}
	}
}
