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
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Texture(String filePath)
		{
			Gl.glGenTextures(1, out id);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);

			/*
			FREE_IMAGE_FORMAT format = FREE_IMAGE_FORMAT.FIF_UNKNOWN;
			Bitmap bm =  FreeImage.LoadBitmap(filePath,
				FREE_IMAGE_LOAD_FLAGS.DEFAULT, ref format);
			*/

			var bitmap = (Bitmap) Image.FromFile(filePath);

			Width = bitmap.Width;
			Height = bitmap.Height;

			var data = bitmap.LockBits(new Rectangle(0, 0, Width, Height), 
				ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);

			Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, Width, Height, 0,
				Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, data.Scan0);

			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
			Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
			Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);
			Gl.glTexParameterf(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);

			bitmap.UnlockBits(data);
			bitmap.Dispose();
		}

		public void Bind(int unit = 0)
		{
			Gl.glActiveTexture(Gl.GL_TEXTURE0 + unit);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, id);
		}
	}
}

