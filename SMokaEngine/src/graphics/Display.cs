using System;

namespace SMokaEngine
{
    public class Display
    {
        public string Title { get; set; }
        public readonly int width;
        public readonly int height;

		private GLFW.Window window;

        public Display(String title, int width, int height)
        {
            Title = title;
            this.width = width;
            this.height = height;
        }

        public void Create()
        {
			GLFW.Init();

            GLFW.WindowHint(GLFW.SAMPLES, 4);
            GLFW.WindowHint(GLFW.CONTEXT_VERSION_MAJOR, 3);
            GLFW.WindowHint(GLFW.CONTEXT_VERSION_MINOR, 3);
            GLFW.WindowHint(GLFW.OPENGL_PROFILE, GLFW.OPENGL_CORE_PROFILE);

            window = GLFW.CreateWindow(width, height, Title, GLFW.Monitor.Null, GLFW.Window.Null);

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

