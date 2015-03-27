using System;

namespace SMokaEngine
{
	public class SMokaException : Exception
	{
		public SMokaException(string message) : base(message)
		{
			// TODO: not sure if this is ok.
			SMokaLog.E(Application.TAG, this.ToString());
		}
	}
}

