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
		}

		public string Name { get; private set; }
		public Sprite Sprite { get; set; }

		public Entity(string name)
		{
			Name = name;
			transform = new Transform(this);
		}

		public void Create()
		{
			Sprite.OnCreate();
		}

		public void Update()
		{

		}

		public Entity AddComponent(Component component)
		{
			component.Entity = this;

			if (component is Sprite)
			{
				Sprite = component as Sprite;
			}
			else
			{
				components.Add(component);
			}

			return this;
		}

		public bool HasSprite()
		{
			return Sprite != null;
		}
	}
}

