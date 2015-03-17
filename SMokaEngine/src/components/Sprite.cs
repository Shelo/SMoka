using System;
using Tao.DevIl;

namespace SMokaEngine
{
	public class Sprite : Component
	{
		public Texture Texture { get; private set; }

		public Sprite(string filePath)
		{
			Texture = new Texture(filePath);
		}

		public void Render()
		{
			Texture.Bind();
			// TODO: more rendering.
		}
	}
}

