using System;

namespace SMokaEngine
{
	public class MyGame : Context
	{
		public override void OnCreate()
		{
			Entity entity = NewEntity("MyEntity");
			entity.AddComponent(new Sprite("res/moka.png"));
			entity.Transform.size = new Vector2(50, 50);
			entity.Transform.position = new Vector2(100, 100);
		}

		public override void OnStop()
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

// TODO:
// - Create the projection matrix.