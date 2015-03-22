using System;
using System.Collections.Generic;

namespace SMokaEngine
{
	public class Entity
	{
		private List<Component> components = new List<Component>();

		private bool destroyed;
		public bool Destroyed
		{
			get
			{
				return destroyed;
			}
		}

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

		private Context context;
		public Context Context
		{
			get
			{
				return context;
			}
		}

		public Entity(Context context, string name)
		{
			this.context = context;
			Name = name;

			transform = new Transform(this);
		}

		public void Create()
		{
			if (HasSprite())
				if (Sprite.Enabled)
					Sprite.OnCreate();

			// iterate over the components list in reverse, this allows a component
			// to add new components while creating.
			for (int i = components.Count - 1; i >= 0; i--)
			{
				if (components[i].Enabled)
					components[i].OnCreate();
			}
		}

		public void Update()
		{
			// iterate over the components list in reverse, this allows a component
			// to add new components in runtime.
			for (int i = components.Count - 1; i >= 0; i--)
			{
				if (components[i].Enabled)
					components[i].OnUpdate();
			}
		}

		public void OnPostUpdate()
		{
			// iterate over the components list in reverse, this allows a component
			// to add new components in runtime.
			for (int i = components.Count - 1; i >= 0; i--)
			{
				if (components[i].Enabled)
					components[i].OnPostUpdate();
			}
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

		public void Destroy()
		{
			destroyed = true;
		}
	}
}

