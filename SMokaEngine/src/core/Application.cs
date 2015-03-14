using System;

namespace SMokaEngine
{
	public class Application
	{
        public Context Context { get; private set; }
        public Display Display { get; private set; }
		public Core Core { get; private set; }

        public Application(Context context)
		{
			Context = context;
			Context.App = this;

			// create sub engines, this is done so the client can set some preferences before the
			// engine starts.
			Display = new Display(this);
			Core = new Core(this);
		}

		public void SetDisplay(String title, int width, int height)
		{
			Display.Create(title, width, height);
		}

		public void Start(float frameCap)
		{
			Core.Create(frameCap);

			Display.Start();
			Core.Start();
		}
	}
}

