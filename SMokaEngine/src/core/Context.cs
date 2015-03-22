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

		public void Update()
		{

		}

		public void Clean()
		{

		}

		public Entity NewEntity(string name)
		{
			var entity = new Entity(name);
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

        public abstract void Create();
        public abstract void Stop();
    }
}

