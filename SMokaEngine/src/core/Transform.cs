using System;
using Pencil.Gaming.MathUtils;

namespace SMokaEngine
{
	public class Transform
	{
		public Entity Entity { get; private set; }

		public Vector2 position;
		public Vector2 size;

		public Transform(Entity entity)
		{
			Entity = entity;
		}

		public Matrix GetModelMatrix()
		{
			var translation = new Matrix();
			translation.M11 = position.x;
			translation.M13 = position.y;

			var scale = new Matrix();
			scale.M11 = size.x;
			scale.M22 = size.y;
			scale.M33 = 1;
			scale.M44 = 1;

			return translation * scale;
		}
	}
}

