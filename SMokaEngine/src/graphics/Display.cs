using System;
using Pencil.Gaming;

namespace SMokaEngine
{
	public class Display : SubEngine
    {
        public string Title { get; set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		GlfwWindowPtr window;

		public Display(Application application) : base(application)
		{}

		public void Create(string title, int width, int height)
		{
			Title = title;
			Width = width;
			Height = height;

			Glfw.Init();

			Glfw.WindowHint(WindowHint.Samples, 4);
			Glfw.WindowHint(WindowHint.ContextVersionMinor, 3);
			Glfw.WindowHint(WindowHint.ContextVersionMajor, 3);
			Glfw.WindowHint(WindowHint.OpenGLProfile, (int) OpenGLProfile.Core);

			window = Glfw.CreateWindow(width, height, Title, GlfwMonitorPtr.Null, GlfwWindowPtr.Null);
			Glfw.MakeContextCurrent(window);

			// Show engine status.
			SMokaLog.O(Application.TAG, "Display Created.");
        }

		public void Start()
		{
//			GLFW.VidMode mode = GLFW.GetVideoMode(GLFW.GetPrimaryMonitor());
			Glfw.ShowWindow(window);

			SMokaLog.O(Application.TAG, "Display Started.");
		}

		public void Update()
		{
			Glfw.SwapBuffers(window);
			Glfw.PollEvents();
		}

		public bool IsCloseRequested()
		{
			return Glfw.WindowShouldClose(window);
		}

		public override void Stop()
		{

		}
    }
}

