using System.Runtime.InteropServices;
using System;

namespace GLFW
{
    public class GLFW
    {
        const string DLL = "glfw3.dll";

        public const int SAMPLES                   = 0x0002100D;
        public const int CONTEXT_VERSION_MINOR     = 0x00022003;
        public const int CONTEXT_VERSION_MAJOR     = 0x00022002;
        public const int OPENGL_PROFILE            = 0x00022008;
        public const int OPENGL_CORE_PROFILE       = 0x00032001;

        [StructLayout(LayoutKind.Explicit)]
        public struct Window
        {
            [FieldOffset(0)] readonly IntPtr nativePtr;

            Window(IntPtr ptr)
            {
				nativePtr = ptr;
            }

			public override string ToString()
			{
				return string.Format("[GLFWwindow] {0}", nativePtr);
			}

            public static Window Null = new Window(IntPtr.Zero);
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Monitor
        {
            [FieldOffset(0)] readonly IntPtr nativePtr;

            Monitor(IntPtr ptr)
            {
				nativePtr = ptr;
            }

            public static Monitor Null = new Monitor(IntPtr.Zero);
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct VidMode
		{
			public int width;
			public int height;
			public int redBits;
			public int greenBits;
			public int blueBits;
			public int refreshRate;
		}

        /*
         * DLL Imports.
         */
		[DllImport(DLL)]
		private static extern int glfwInit();

        [DllImport(DLL)]
        private static extern void glfwWindowHint(int target, int hint);

        [DllImport(DLL)]
        private static extern Window glfwCreateWindow(int width, int height,
            [MarshalAs(UnmanagedType.LPStr)] string title, Monitor monitor,
            Window share);

		[DllImport(DLL)]
		private static extern void glfwMakeContextCurrent(Window window);

		[DllImport(DLL)]
		private static extern void glfwShowWindow(Window window);

		[DllImport(DLL)]
		private static extern void glfwSwapBuffers(Window window);

		[DllImport(DLL)]
		private static extern int glfwWindowShouldClose(Window window);

		[DllImport(DLL)]
		private static extern double glfwGetTime();

		[DllImport(DLL)]
		private static extern Monitor glfwGetPrimaryMonitor();

		[DllImport(DLL)]
		private static extern void glfwPollEvents();

		[DllImport(DLL)]
		private static extern IntPtr glfwGetVideoMode(Monitor monitor);

        /*
         * C# Ports.
         */
		public static int Init()
		{
			return glfwInit();
		}

        public static void WindowHint(int target, int hint)
        {
            glfwWindowHint(target, hint);
        }

        public static Window CreateWindow(int width, int height, string title,
			Monitor monitor, Window share)
        {
            return glfwCreateWindow(width, height, title, monitor, share);
        }

		public static void MakeContextCurrent(Window window)
		{
			glfwMakeContextCurrent(window);
		}

		public static void ShowWindow(Window window)
		{
			glfwShowWindow(window);
		}

		public static void SwapBuffers(Window window)
		{
			glfwSwapBuffers(window);
		}

		public static bool WindowShouldClose(Window window)
		{
			return glfwWindowShouldClose(window) != 0;
		}

		public static double GetTime()
		{
			return glfwGetTime();
		}

		public static Monitor GetPrimaryMonitor()
		{
			return glfwGetPrimaryMonitor();
		}

		public static void PollEvents()
		{
			glfwPollEvents();
		}

		public static VidMode GetVideoMode(Monitor monitor)
		{
			IntPtr ptr = glfwGetVideoMode(monitor);
			return (VidMode) Marshal.PtrToStructure(ptr, typeof(VidMode));
		}
    }
}

