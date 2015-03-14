using System;

namespace SMokaEngine
{
	/// <summary>
	/// Every sub engine should inherit from this class. This is meant to treat them all in the same way.
	/// </summary>
	public class SubEngine
	{
		private readonly Application application;
		public Application App
		{
			get
			{
				return application;
			}
		}

		public SubEngine(Application application)
		{
			this.application = application;
		}
	}
}

