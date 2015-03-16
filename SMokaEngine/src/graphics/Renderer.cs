using System;
using Tao.OpenGl;

namespace SMokaEngine
{
	public class Renderer : SubEngine
	{
		public Renderer(Application application) : base(application)
		{

		}

		public void Start()
		{
			// indicate the clear color.
			Gl.glClearColor(0, 0, 0, 1);

			// indicate the front face, then cull the back face.
			Gl.glFrontFace(Gl.GL_CW);
			Gl.glEnable(Gl.GL_CULL_FACE);
			Gl.glCullFace(Gl.GL_BACK);

			// enable alpha blending.
			Gl.glEnable(Gl.GL_BLEND);
			Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
		}

		public void Render()
		{

		}

		public override void Stop()
		{

		}
	}
}

