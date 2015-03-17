using System;
using Tao.OpenGl;

namespace SMokaEngine
{
	public class MyGame : Context
	{
		public override void Create()
		{
			Entity entity = newEntity();
			entity.AddComponent(new Sprite("res/moka.png"));
		}

		public override void Stop()
		{

		}

		static int Main(string[] args)
		{
			SMokaLog.SharedTag = "SMokaEngine";

			var app = new Application(new MyGame());

			/* here the client could set some values to the engine.
			*/

			app.SetDisplay("Game Title", 800, 600);
			app.Start(60.0f);
			return 0;
		}
	}
}
