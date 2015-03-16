using System;

namespace SMokaEngine
{
	public class Transform
	{
		private readonly Entity entity;
		public Entity Entity
		{
			get
			{
				return entity;
			}
		}

		public Vector2 Position { get; set; }
		public float Rotation { get; set; }

		private Vector2? size;
		public Vector2 Size
		{
			get
			{
				if (size.HasValue)
				{
					return size.Value;
				}
				else
				{
					return new Vector2(0, 0);
				}
			}

			set
			{
				size = value;
			}
		}

		public Transform(Entity entity)
		{
			this.entity = entity;
		}

		public void Update()
		{

		}

		public void Move(float x, float y)
		{
			Position.Add(x, y);
		}

		public void Move(Vector2 distance)
		{
			Position += distance;
		}

	}

}

