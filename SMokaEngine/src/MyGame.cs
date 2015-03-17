using System;
using Tao.OpenGl;

namespace SMokaEngine
{
	public class MyGame : Context
	{
		public override void Create()
		{
			Texture texture = new Texture("res/moka.png");
		}

		public override void Stop()
		{

		}

		static int Main(string[] args)
		{
			SMokaLog.SharedTag = "SMokaEngine";

			var app = new Application(new MyGame());
			app.SetDisplay("Game Title", 800, 600);
			app.Start(60.0f);
			return 0;
		}
	}
}
