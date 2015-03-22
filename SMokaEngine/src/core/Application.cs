using System;

namespace SMokaEngine
{
	public class Application
	{
		public const string TAG = "SMoka";

		public Resources Resources { get; private set; }
		public Renderer Renderer { get; private set; }
        public Context Context { get; private set; }
		public Display Display { get; private set; }
		public Core Core { get; private set; }
		public Time Time { get; private set; }

        public Application(Context context)
		{
			Context = context;
			Context.App = this;

			// create sub engines, this is done so the client can set some preferences before the
			// engine starts.
			Resources = new Resources(this);
			Display = new Display(this);
			Renderer = new Renderer(this);
			Core = new Core(this);
			Time = new Time();
		}

		public void SetDisplay(string title, int width, int height)
		{
			Display.Create(title, width, height);
		}

		public void Start(float frameCap)
		{
			Core.Create(frameCap);
			Renderer.Create();

			Display.Start();
			Renderer.Start();
			Core.Start();
		}
	}
}
