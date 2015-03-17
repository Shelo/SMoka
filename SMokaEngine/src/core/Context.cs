using System;

namespace SMokaEngine
{
	public abstract class Context
    {
		private Application application;
		public Application App
		{
			get
			{
				return application;
			}

			set
			{
				if (application == null)
				{
					application = value;
				}
				else
				{
					throw new SMokaException("Application is already set.");
				}
			}
		}

        public abstract void Create();
        public abstract void Stop();
    }
}

