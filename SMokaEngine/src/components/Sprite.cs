using System;

namespace SMokaEngine
{
	public class Sprite : Component
	{
		public Texture Texture { get; private set; }
		public Color Tint { get; set; }

		private Mesh mesh;

		public Sprite(string filePath)
		{
			Texture = new Texture(filePath);
			Tint = new Color(1, 1, 1, 1);
		}

		public override void OnCreate()
		{
			mesh = new Quad(1, 1);
		}

		public void Render(Shader shader)
		{
			Texture.Bind();
			shader.Update(this);
			mesh.Draw();
		}
	}
}

