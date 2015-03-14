using System;

namespace SMokaEngine
{
	public class Display : SubEngine
    {
        public string Title { get; set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		GLFW.Window window;

		public Display(Application application) : base(application) {}

		public void Create(String title, int width, int height)
		{
			Title = title;
			Width = width;
			Height = height;

			GLFW.Init();

            GLFW.WindowHint(GLFW.SAMPLES, 4);
            GLFW.WindowHint(GLFW.CONTEXT_VERSION_MAJOR, 3);
            GLFW.WindowHint(GLFW.CONTEXT_VERSION_MINOR, 3);
            GLFW.WindowHint(GLFW.OPENGL_PROFILE, GLFW.OPENGL_CORE_PROFILE);

            window = GLFW.CreateWindow(width, height, Title, GLFW.Monitor.Null, GLFW.Window.Null);
        }

		public void Start()
		{
			GLFW.VidMode mode = GLFW.GetVideoMode(GLFW.GetPrimaryMonitor());
			Console.WriteLine(mode.width);

			GLFW.MakeContextCurrent(window);
			GLFW.ShowWindow(window);
		}

		public void Update()
		{
			GLFW.SwapBuffers(window);
			GLFW.PollEvents();
		}
    }
}

