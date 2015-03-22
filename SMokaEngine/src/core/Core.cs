using System;
using Pencil.Gaming;

namespace SMokaEngine
{
	public class Core : SubEngine
	{
		public bool Running { get; private set; }
        
		float frameTime;

		public Core(Application application) : base(application)
		{}

        public void Create(float frameTime)
        {
			this.frameTime = 1.0f / frameTime;
			Context.Create();
        }

		/// <summary>
		/// Start the core of the engine.
		/// </summary>
		public void Start()
		{
			if (!Running)
			{
				Running = true;
				Glfw.SetTime(0.0);
				Run();
			}
			else
			{
				throw new SMokaException("Application is already running.");
			}
		}

		private void Run()
		{
			double delta = frameTime;

			double currentTime = Glfw.GetTime();
			double accumulator = 0;

			// this is just to show some statics.
			int updateFrames = 0;
			int renderFrames = 0;
			double accSeconds = 0;

			while (Running)
			{
				bool render = false;

				double newTime = Glfw.GetTime();
				double curFrameTime = newTime - currentTime;
				currentTime = newTime;

				accumulator += curFrameTime;

				while (accumulator > delta)
				{
					render = true;

					Time.Update(delta);
					Context.Update();
					Context.Clean();

					Running &= !Display.IsCloseRequested();

					accumulator -= delta;
					accSeconds += delta;

					updateFrames++;
				}

				if (render)
				{
					renderFrames++;
					Renderer.Render();
					Display.Update();
				}
				else
				{
					System.Threading.Thread.Sleep(1);
				}

				if (accSeconds >= 1)
				{
					SMokaLog.O(Application.TAG, String.Format("Core update: {0} fps, {1} ups.", renderFrames,
						updateFrames));
					accSeconds = renderFrames = updateFrames = 0;
				}
			}
		}

		public override void Stop()
		{

		}
	}
}

