using System;

namespace SMokaEngine
{
	public class Time
	{
		double elapsed;
		public double Delta { get; private set; }

		public void Update(double delta)
		{
			Delta = delta;
			elapsed += delta;
		}
	}
}

