using System;

namespace SMokaEngine
{
	public class Core
	{
		public bool Running { get; private set; }

		private Application app;
        private float frameTime;

        public Core(Application app, float frameTime)
        {
            this.app = app;
            this.frameTime = frameTime;
        }

		public void Start()
		{
			if (!Running)
			{
				Running = false;
				Run();
			}
		}

		private void Run()
		{

		}

	}
}

