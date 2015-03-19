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

			var bitmap = new Bitmap(filePath);

			Width = bitmap.Width;
			Height = bitmap.Height;

			var data = bitmap.LockBits(new Rectangle(0, 0, Width, Height), 
				ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0,
				Pencil.Gaming.Graphics.PixelFormat.Rgba, PixelType.UnsignedByte, data.Scan0);

			bitmap.UnlockBits(data);
		}

		public void Bind(TextureUnit unit = TextureUnit.Texture0)
		{
			GL.ActiveTexture(unit);
			GL.BindTexture(TextureTarget.Texture2D, id);
		}
	}
}

