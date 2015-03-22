using System;
using Pencil.Gaming.Graphics;

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
			GL.ClearColor(0, 0, 0, 1);

			// indicate the front face, then cull the back face.
			GL.FrontFace(FrontFaceDirection.Cw);
			GL.Enable(EnableCap.CullFace);
			GL.CullFace(CullFaceMode.Back);

			// enable alpha blending.
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
		}

		public void Render()
		{
			Clear();

			foreach (Sprite sprite in Context.SpriteIterator())
			{
				sprite.Render();
			}
		}

		private void Clear()
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
		}

		public override void Stop()
		{

		}
	}
}

