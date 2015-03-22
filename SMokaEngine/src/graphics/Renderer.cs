using System;
using Pencil.Gaming.Graphics;

namespace SMokaEngine
{
	public class Renderer : SubEngine
	{
		private const string DEFAULT_FRAGMENT_SHADER 	= "res/shaders/pass_through_fragment.glsl";
		private const string DEFAULT_VERTEX_SHADER 		= "res/shaders/pass_through_vertex.glsl";

		private Shader shader;

		public Renderer(Application application) : base(application)
		{}

		public void Create()
		{
			// create the default shader.
			shader = new Shader(DEFAULT_VERTEX_SHADER, DEFAULT_FRAGMENT_SHADER);
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
				sprite.Render(shader);
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

