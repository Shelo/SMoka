using System;

namespace SMokaEngine
{
	public class Entity
	{
		private Transform transform;
		public Transform Transform
		{
			get
			{
				return transform;
			}

			set
			{
				if (transform == null)
				{
					transform = value;
				}
				else
				{
					throw new SMokaException("Entity's transform is already set.");
				}
			}
		}

		public Entity()
		{

		}
	}
}

