using System;
using System.Collections.Generic;

namespace SMokaEngine
{
	public class Entity
	{
		private List<Component> components = new List<Component>();

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

		public string Name { get; private set; }
		public Sprite Sprite { get; set; }

		public Entity(string name)
		{
			Name = name;
		}

		public Entity AddComponent(Component component)
		{
			components.Add(component);
			return this;
		}

		public bool HasSprite()
		{
			return Sprite != null;
		}
	}
}

