using System;
using Tao.OpenGl;
using Tao.DevIl;
using FreeImageAPI;
using System.Drawing;
using System.Drawing.Imaging;

namespace SMokaEngine
{
	public class Texture
	{
		private uint id;
		private uint width;
		private uint height;

		public Texture(String filePath)
		{
			Gl.glGenTextures(1, out id);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);

			FREE_IMAGE_FORMAT format = FREE_IMAGE_FORMAT.FIF_UNKNOWN;
			Bitmap bitmap =  FreeImage.LoadBitmap(filePath,
				FREE_IMAGE_LOAD_FLAGS.DEFAULT, ref format);

			width = (uint) bitmap.Width;
			height = (uint) bitmap.Height;

			BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
				                  ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

			Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, (int)width, (int)height, 0, Gl.GL_RGBA,
				Gl.GL_UNSIGNED_BYTE, data.Scan0);
			bitmap.UnlockBits(data);

			Console.WriteLine(width);
			Console.WriteLine(height);
		}
	}
}

