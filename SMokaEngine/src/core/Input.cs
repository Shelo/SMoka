using System;
using Pencil.Gaming;

namespace SMokaEngine
{
	public class Input : SubEngine
	{
		private const int MOUSE_COUNT 	= 5;
		private const int KEY_COUNT		= 348;

		public Vector2 CursorPosition { get; private set; }
		private bool[] activeMouse;
		private bool[] activeKeys;

		public Input(Application applcation) : base(applcation)
		{}

		public void Create()
		{
			activeMouse = new bool[MOUSE_COUNT];
			activeKeys = new bool[KEY_COUNT];
		}

		public void Update()
		{
			for (int i = 0; i < KEY_COUNT; i++)
			{
				activeKeys[i] = GetKey((Key) i);
			}

			for (int i = 0; i < MOUSE_COUNT; i++)
			{
				activeMouse[i] = GetMouse((MouseButton) i);
			}
		}

		public bool GetKey(Key key)
		{
			return Glfw.GetKey(Display.Window, key);
		}

		public bool GetKeyDown(Key key)
		{
			return GetKey(key) && !activeKeys[key];
		}

		public bool GetKeyUp(Key key)
		{
			return !GetKey(key) && activeKeys[key];
		}

		public bool GetMouse(MouseButton button)
		{
			return Glfw.GetMouseButton(Display.Window, button);
		}

		public bool GetKeyDown(MouseButton button)
		{
			return GetMouse(button) && !activeKeys[button];
		}

		public bool GetKeyUp(MouseButton button)
		{
			return !GetMouse(button) && activeKeys[button];
		}

		public override void Stop()
		{

		}
	}
}

