using System;

namespace SMokaEngine
{
	public class SimpleLogger : Component
	{
		public delegate void Logger(Entity entity);
		Logger logger;

		public void AddDelegate(Logger logger)
		{
			this.logger += logger;
		}

		public override void OnUpdate()
		{
			logger.Invoke(Entity);
		}
	}
}
