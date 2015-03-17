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
				Running = true;
				Context.Create();
				Run();
			}
			else
			{
				throw new SMokaException("Application is already running.");
			}
		}

		private void Run()
		{

		}

		public override void Stop()
		{

		}
	}
}

