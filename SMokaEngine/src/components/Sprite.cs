using System;

namespace SMokaEngine
{
	public class Sprite : Component
	{
		public Texture Texture { get; private set; }

		private Mesh mesh; 

		public Sprite(string filePath)
		{
			Texture = new Texture(filePath);
		}

		public override void OnCreate()
		{
			mesh = new Quad(1, 1);
		}

		public void Render()
		{
			Texture.Bind();
			mesh.Draw();
		}
	}
}

