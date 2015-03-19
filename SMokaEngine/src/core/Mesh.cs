using System;
using Pencil.Gaming.Graphics;

namespace SMokaEngine
{
	public class Mesh
	{
		private int vao;
		private int vbo;
		private int ibo;

		public Mesh(float texCoordX, float texCoordY)
		{
			// create the vertex array for this mesh.
			vao = GL.GenVertexArray();
			GL.BindVertexArray(vao);

			// create the buffers for this vertex array.
			vbo = GL.GenBuffer();
			ibo = GL.GenBuffer();

			var vertices = new float[]
			{
					-.5f, -.5f, 0, 0, texCoordY,
					-.5f, 0.5f, 0, 0, 0,
					0.5f, 0.5f, 0, texCoordX, 0,
					0.5f, -.5f, 0, texCoordX, texCoordY
			};

			var indices = new int[]
			{
				0, 1, 2, 0, 2, 3
			};

			// Using Vertex Buffer.
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
			GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr) (sizeof(float) * vertices.Length),
				vertices, BufferUsageHint.StaticDraw);

			// enable position and texCoords attrib arrays.
			GL.EnableVertexAttribArray(0);
			GL.EnableVertexAttribArray(1);

			// indicate vertex attrib pointers.
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), sizeof(float) * 3);

			// Using Index buffer.
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, ibo);
			GL.BufferData<int>(BufferTarget.ElementArrayBuffer, (IntPtr) (sizeof(int) * indices.Length), indices,
				BufferUsageHint.StaticDraw);

			// unbind vertex array.
			GL.BindVertexArray(0);
		}

		public void Draw()
		{
			GL.BindVertexArray(vao);
			GL.DrawElements(BeginMode.Triangles, 6, DrawElementsType.UnsignedInt, 0);
			GL.BindVertexArray(0);
		}

		public void Destroy()
		{
			GL.DeleteVertexArray(vao);
		}
	}
}

