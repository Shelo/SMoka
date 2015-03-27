using System;

namespace SMokaEngine
{
	public struct Color
	{
		public float r;
		public float g;
		public float b;
		public float a;

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public Color Clamp()
		{
			r = SMath.Clamp(r, 0, 1);
			g = SMath.Clamp(g, 0, 1);
			b = SMath.Clamp(b, 0, 1);
			a = SMath.Clamp(a, 0, 1);
			return this;
		}

		public static Color operator +(Color t, Color o)
		{
			Color color = new Color(t.r + o.r, t.g + o.g, t.b + o.b, t.a + o.a);
			return color.Clamp();
		}

		public static Color operator -(Color t, Color o)
		{
			Color color = new Color(t.r - o.r, t.g - o.g, t.b - o.b, t.a - o.a);
			return color.Clamp();
		}

		public static Color operator *(Color t, Color o)
		{
			Color color = new Color(t.r * o.r, t.g * o.g, t.b * o.b, t.a * o.a);
			return color.Clamp();
		}

		public static Color operator /(Color t, Color o)
		{
			Color color = new Color(t.r / o.r, t.g / o.g, t.b / o.b, t.a / o.a);
			return color.Clamp();
		}

		public static bool operator ==(Color t, Color o)
		{
			return t.r == o.r && t.g == o.g && t.b == o.b && t.a == o.a;
		}

		public static bool operator !=(Color t, Color o)
		{
			return t.r != o.r || t.g != o.g || t.b != o.b || t.a != o.a;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1}, {2}, {3})", r, g, b, a);
		}
	}
}

