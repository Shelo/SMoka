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
            Context.Application = this;
		}

		public void SetDisplay(String title, int width, int height)
		{
            Display = new Display(title, width, height);
		}

		public void Start(float frameCap)
		{
            Core = new Core(this, 1.0f / frameCap);

            Display.Create();
			Core.Start();
		}
	}
}

