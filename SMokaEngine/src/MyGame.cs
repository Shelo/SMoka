using System;

namespace SMokaEngine
{
	public class MyGame
	{
		static int Main(string[] args)
		{
            var app = new Application(new XMLGame("res/scene.xml", "res/resources.xml"));
			app.SetDisplay("Game Title", 800, 600);
			app.Start(60.0f);
			return 0;
		}
	}
}
