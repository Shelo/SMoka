using System;
using Tao.DevIl;

namespace SMokaEngine
{
	public class Resources : SubEngine
	{
		public Resources(Application application) : base(application)
		{
			Il.ilInit();
			Ilu.iluInit();
			Ilut.ilutInit();
		}

		public void Create()
		{
				
		}

		public override void Stop()
		{
			throw new NotImplementedException();
		}
	}
}

