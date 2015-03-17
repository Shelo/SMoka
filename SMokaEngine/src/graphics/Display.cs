using System;

namespace SMokaEngine
{
	public class Display : SubEngine
    {
		private const string TAG = "Display";

        public string Title { get; set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		GLFW.Window window;

		public Display(Application application) : base(application) {}

		public void Create(string title, int width, int height)
		{
			Title = title;
			Width = width;
			Height = height;

			GLFW.Init();

			GLFW.WindowHint(GLFW.SAMPLES, 4);
//			GLFW.WindowHint(GLFW.CONTEXT_VERSION_MINOR, 3);
//			GLFW.WindowHint(GLFW.CONTEXT_VERSION_MAJOR, 3);
//			GLFW.WindowHint(GLFW.OPENGL_PROFILE, GLFW.OPENGL_CORE_PROFILE);

            window = GLFW.CreateWindow(width, height, Title, GLFW.Monitor.Null, GLFW.Window.Null);

			SMokaLog.O(TAG, "Created.");
        }

		public void Start()
		{
//			GLFW.VidMode mode = GLFW.GetVideoMode(GLFW.GetPrimaryMonitor());
			GLFW.MakeContextCurrent(window);
			GLFW.ShowWindow(window);

			SMokaLog.O(TAG, "Started.");
		}

		public void Update()
		{
			GLFW.SwapBuffers(window);
			GLFW.PollEvents();
		}

		public override void Stop()
		{

		}
    }
}

