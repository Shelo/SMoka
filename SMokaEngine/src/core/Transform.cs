using System;
using Pencil.Gaming.MathUtils;

namespace SMokaEngine
{
	public class Transform
	{
		public Entity Entity { get; private set; }

		public Vector2 position;
		public Vector2 size;

		public Matrix ModelMatrix
		{
			get
			{
				var translation = Matrix.Identity;
				translation.M14 = position.x;
				translation.M24 = position.y;

				var scale = Matrix.Identity;
				scale.M11 = size.x;
				scale.M22 = size.y;
				scale.M33 = 1;
				scale.M44 = 1;

				return translation * scale;
			}
		}

		public Transform(Entity entity)
		{
			Entity = entity;
		}
	}
}

