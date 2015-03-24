using System;
using System.Drawing;
using System.Drawing.Imaging;
using Pencil.Gaming.Graphics;

namespace SMokaEngine
{
	public class Texture
	{
		private int id;
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Texture(String filePath)
		{
			id = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, id);

			// set texture parameters when changing its dimensions.
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
				(int) TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
				(int) TextureMagFilter.Nearest);

			// create the bitmap from whee we'll read the pixel bits.
			var bitmap = new Bitmap(filePath);

			// save dimensions.
			Width = bitmap.Width;
			Height = bitmap.Height;

			// capture data from the bitmap.
			var data = bitmap.LockBits(new Rectangle(0, 0, Width, Height), 
				ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			// send bitmap data to OpenGL.
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0,
				Pencil.Gaming.Graphics.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

			bitmap.UnlockBits(data);
		}

		public void Bind(TextureUnit unit = TextureUnit.Texture0)
		{
			GL.ActiveTexture(unit);
			GL.BindTexture(TextureTarget.Texture2D, id);
		}
	}
}

