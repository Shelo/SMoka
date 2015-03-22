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

		public void Clamp()
		{
			r = SMath.Clamp(r, 0, 1);
			g = SMath.Clamp(g, 0, 1);
			b = SMath.Clamp(b, 0, 1);
			a = SMath.Clamp(a, 0, 1);
		}
	}
}

