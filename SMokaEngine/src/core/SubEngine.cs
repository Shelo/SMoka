using System;

namespace SMokaEngine
{
	/// <summary>
	/// Every sub engine should inherit from this class. This is meant to treat them all in the same way.
	/// </summary>
	public abstract class SubEngine
	{
		private readonly Application application;

		public Core Core
		{
			get
			{
				return application.Core;
			}
		}

		public Resources Resources
		{
			get
			{
				return application.Resources;
			}
		}

		public Context Context
		{
			get
			{
				return application.Context;
			}
		}

		public Renderer Renderer
		{
			get
			{
				return application.Renderer;
			}
		}

		public Display Display
		{
			get
			{
				return application.Display;
			}
		}

		protected SubEngine(Application application)
		{
			this.application = application;
		}

		public abstract void Stop();
	}
}

