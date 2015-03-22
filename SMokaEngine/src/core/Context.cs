using System;
using System.Collections;
using System.Collections.Generic;

namespace SMokaEngine
{
	public abstract class Context
	{
		private List<Entity> entities = new List<Entity>();
		private Application application;
		public Application App
		{
			get
			{
				return application;
			}

			set
			{
				if (application == null)
				{
					application = value;
				}
				else
				{
					throw new SMokaException("Application is already set.");
				}
			}
		}

		public void Create()
		{
			OnCreate();

			for (int i = entities.Count - 1; i >= 0; i--)
			{
				entities[i].Create();
			}
		}

		public void Update()
		{
			for (int i = entities.Count - 1; i >= 0; i--)
			{
				entities[i].Update();
			}
		}

		public void Clean()
		{
			for (int i = entities.Count - 1; i >= 0; i--)
			{
				if (entities[i].Destroyed)
				{
					entities.RemoveAt(i);
				}
			}
		}

		public Entity NewEntity(string name)
		{
			var entity = new Entity(this, name);
			entities.Add(entity);
			return entity;
		}

		public IEnumerable<Sprite> SpriteIterator()
		{
			foreach (Entity entity in entities)
			{
				if (entity.HasSprite())
				{
					yield return entity.Sprite;
				}
			}
		}

        public abstract void OnCreate();
        public abstract void OnStop();
    }
}

