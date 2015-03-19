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

		public Entity newEntity(string name)
		{
			var entity = new Entity(name);
			entities.Add(entity);
			return entity;
		}

        public abstract void Create();
        public abstract void Stop();
    }
}

