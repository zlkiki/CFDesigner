// Decompiled with ICSharpCode.Decompiler 7.2
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RSG.Utility;

internal class ScaleGraphics
{
	private PictureBox _PictureBox;

	private Bitmap _Bitmap;

	private Graphics _Graphics;

	private float _Width;

	private float _Height;

	private float _ScaleLeft;

	private float _ScaleTop;

	private float _ScaleRight;

	private float _ScaleBottom;

	private float _ScaleWidth;

	private float _ScaleHeight;

	private float _ScaleLeftSave;

	private float _ScaleTopSave;

	private float _ScaleRightSave;

	private float _ScaleBottomSave;

	public PictureBox PictureBox => _PictureBox;

	public Bitmap Bitmap => _Bitmap;

	public Graphics Graphics => _Graphics;

	public float Width => _Width;

	public float Height => _Height;

	public float ScaleLeft => _ScaleLeft;

	public float ScaleTop => _ScaleTop;

	public float ScaleRight => _ScaleRight;

	public float ScaleBottom => _ScaleBottom;

	public float ScaleWidth => _ScaleWidth;

	public float ScaleHeight => _ScaleHeight;

	public float UnitsPerPixelX => _ScaleWidth / _Width;

	public float UnitsPerPixelY => _ScaleHeight / _Height;

	public ScaleGraphics (PictureBox pic)
	{
		_PictureBox = pic;
		_Width = _PictureBox.ClientSize.Width;
		_Height = _PictureBox.ClientSize.Height;
		_Bitmap = checked(new Bitmap ((int)System.Math.Round (_Width), (int)System.Math.Round (_Height)));
		_Graphics = Graphics.FromImage (_Bitmap);
		_Graphics.Clear (_PictureBox.BackColor);
		_Graphics.ResetTransform ();
		_ScaleLeft = _PictureBox.ClientRectangle.Left;
		_ScaleTop = _PictureBox.ClientRectangle.Top;
		_ScaleRight = _PictureBox.ClientRectangle.Right;
		_ScaleBottom = _PictureBox.ClientRectangle.Bottom;
		_ScaleWidth = _Width;
		_ScaleHeight = _Height;
		_ScaleLeftSave = _ScaleLeft;
		_ScaleTopSave = _ScaleTop;
		_ScaleRightSave = _ScaleRight;
		_ScaleBottomSave = _ScaleBottom;
	}

	public void Clear ()
	{
		_Graphics.Clear (_PictureBox.BackColor);
	}

	public void Scale (float X1, float Y1, float X2, float Y2)
	{
		_ScaleLeftSave = _ScaleLeft;
		_ScaleTopSave = _ScaleTop;
		_ScaleRightSave = _ScaleRight;
		_ScaleBottomSave = _ScaleBottom;
		_ScaleLeft = X1;
		_ScaleTop = Y1;
		_ScaleRight = X2;
		_ScaleBottom = Y2;
		_ScaleWidth = X2 - X1;
		_ScaleHeight = Y2 - Y1;
		_Graphics.ResetTransform ();
		_Graphics.ScaleTransform (_Width / _ScaleWidth, _Height / _ScaleHeight);
		_Graphics.TranslateTransform (0f - _ScaleLeft, 0f - _ScaleTop);
	}

	public void SwapScale ()
	{
		float scaleLeft = _ScaleLeft;
		_ScaleLeft = _ScaleLeftSave;
		_ScaleLeftSave = scaleLeft;
		scaleLeft = _ScaleTop;
		_ScaleTop = _ScaleTopSave;
		_ScaleTopSave = scaleLeft;
		scaleLeft = _ScaleRight;
		_ScaleRight = _ScaleRightSave;
		_ScaleRightSave = scaleLeft;
		scaleLeft = _ScaleBottom;
		_ScaleBottom = _ScaleBottomSave;
		_ScaleBottomSave = scaleLeft;
		_ScaleWidth = _ScaleRight - _ScaleLeft;
		_ScaleHeight = _ScaleBottom - _ScaleTop;
		_Graphics.ResetTransform ();
		_Graphics.ScaleTransform (_Width / _ScaleWidth, _Height / _ScaleHeight);
		_Graphics.TranslateTransform (0f - _ScaleLeft, 0f - _ScaleTop);
	}

	public PointF TransformToDevice (PointF Pt)
	{
		PointF result = default(PointF);
		result.X = (Pt.X - _ScaleLeft) * _Width / _ScaleWidth;
		result.Y = (Pt.Y - _ScaleTop) * _Height / _ScaleHeight;
		return result;
	}

	public PointF TransformToWorld (PointF Pt)
	{
		PointF result = default(PointF);
		result.X = _ScaleLeft + Pt.X * _ScaleWidth / _Width;
		result.Y = _ScaleTop + Pt.Y * _ScaleHeight / _Height;
		return result;
	}

	public void DrawDot (Pen p, float X, float Y, short Pixels = 1)
	{
		float width = p.Width;
		float width2 = p.Width;
		width = (float)Pixels * System.Math.Abs (UnitsPerPixelX);
		width2 = (float)Pixels * System.Math.Abs (UnitsPerPixelY);
		SmoothingMode smoothingMode = _Graphics.SmoothingMode;
		_Graphics.SmoothingMode = SmoothingMode.None;
		_Graphics.FillEllipse (p.Brush, X - width / 2f, Y - width2 / 2f, width, width2);
		_Graphics.SmoothingMode = smoothingMode;
	}

	public void DrawDot (Pen p, PointF Pt)
	{
		DrawDot (p, Pt.X, Pt.Y, 1);
	}

	public void PreserveImage ()
	{
		_PictureBox.Image = _Bitmap;
	}

	public void Dispose ()
	{
		if (_Graphics != null) {
			_Graphics.Dispose ();
		}
		if (_Bitmap != null) {
			_Bitmap.Dispose ();
		}
	}
}
