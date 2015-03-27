using System;
using Pencil.Gaming.MathUtils;

namespace SMokaEngine
{
	public class Camera : Component
	{
		public const int Z_NEAR = -10;
		public const int Z_FAR	= 10;

		public Matrix Projection { get; private set; }

		public Matrix ProjectedView
		{
			get
			{
				return Projection;
			}
		}

		public Camera()
		{
			var projection = new Matrix();

			projection.M11 = 2 / Application.Display.Width;
			projection.M12 = 0;
			projection.M13 = 0;
			projection.M14 = - 1;

			projection.M21 = 0;
			projection.M22 = 2 / Application.Display.Height;
			projection.M23 = 0;
			projection.M24 = - 1;

			projection.M31 = 0;
			projection.M32 = 0;
			projection.M33 = -2 / (Z_FAR - Z_NEAR);
			projection.M34 = - (Z_FAR + Z_NEAR) / (Z_FAR - Z_NEAR);

			projection.M41 = 0;
			projection.M42 = 0;
			projection.M43 = 0;
			projection.M44 = 1;

			Projection = projection;
		}

		public Camera(float width, float height)
		{
			var projection = new Matrix();

			projection.M11 = 2 / width;
			projection.M12 = 0;
			projection.M13 = 0;
			projection.M14 = - 1;

			projection.M21 = 0;
			projection.M22 = 2 / height;
			projection.M23 = 0;
			projection.M24 = - 1;

			projection.M31 = 0;
			projection.M32 = 0;
			projection.M33 = -2 / (Z_FAR - Z_NEAR);
			projection.M34 = - (Z_FAR + Z_NEAR) / (Z_FAR - Z_NEAR);

			projection.M41 = 0;
			projection.M42 = 0;
			projection.M43 = 0;
			projection.M44 = 1;

			Projection = projection;

			Console.WriteLine(projection);
		}

		public void SetAsMain()
		{
			Application.Renderer.MainCamera = this;
		}
	}
}

