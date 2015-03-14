using System;

namespace SMokaEngine
{
	public class Core : SubEngine
	{
		public bool Running { get; private set; }
        
		float frameTime;

		public Core(Application application) : base(application) {}

        public void Create(float frameTime)
        {
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

