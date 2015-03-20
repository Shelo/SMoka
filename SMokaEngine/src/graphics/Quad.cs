using System;

namespace SMokaEngine
{
	public class Quad : Mesh
	{
		public Quad(float texCoordX, float texCoordY)
		{
			var vertices = new float[]
				{
					-.5f, -.5f, 0, 0, texCoordY,
					-.5f, 0.5f, 0, 0, 0,
					0.5f, 0.5f, 0, texCoordX, 0,
					0.5f, -.5f, 0, texCoordX, texCoordY
				};

			var indices = new int[]
				{
					0, 1, 2, 0, 2, 3
				};

			base.Create(vertices, indices);
		}
	}
}
