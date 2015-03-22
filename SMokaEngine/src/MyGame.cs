using System;

namespace SMokaEngine
{
	public class MyGame : Context
	{
		Mesh mesh;

		public override void Create()
		{
			Entity entity = NewEntity("MyEntity");
			entity.AddComponent(new Sprite("res/moka.png"));

			mesh = new Mesh(1, 1);
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
