using System;
using Pencil.Gaming.Graphics;
using System.Collections.Generic;
using System.IO;
using Pencil.Gaming.MathUtils;

namespace SMokaEngine
{
	public class Shader
	{
		private Dictionary<string, int> uniformLocations;
		private uint program;
		private uint fragment;
		private uint vertex;

		public Shader(string vertexFilePath, string fragmentFilePath)
		{
			program = GL.CreateProgram();
			vertex = CreateShader(vertexFilePath, ShaderType.VertexShader);
			fragment = CreateShader(fragmentFilePath, ShaderType.FragmentShader);

			// bind attrib locations just in case.
			GL.BindAttribLocation(program, 0, "a_position");
			GL.BindAttribLocation(program, 1, "a_texCoord");

			// buffer for error codes.
			int errorCode;

			// link program.
			GL.LinkProgram(program);

			// get error code for linking if any.
			GL.GetProgram(program, ProgramParameter.LinkStatus, out errorCode);
			if (errorCode == 0)
				throw new SMokaException(GL.GetShaderInfoLog((int) program));

			// validate program.
			GL.ValidateProgram(program);

			// get error code for validation if any.
			GL.GetProgram(program, ProgramParameter.ValidateStatus, out errorCode);
			if (errorCode == 0)
				throw new SMokaException(GL.GetShaderInfoLog((int) program));

			uniformLocations = new Dictionary<string, int>();

			// output log.
			SMokaLog.O(Application.TAG, "Shader created.");
		}

		public void Bind()
		{
			GL.UseProgram(program);
		}

		public void Update(Sprite sprite)
		{
			// get transform model matrix.
			Matrix model = sprite.Transform.GetModelMatrix();

			// set uniform for that model matrix.
			SetUniform("u_model", model);

			// set uniform for the sprite tint.
			SetUniform("u_color", sprite.Tint);
		}

		/// <summary>
		/// Gets the uniform location. If the uniform didn't existed then we retrieve
		/// the uniform location and store it.
		/// </summary>
		/// <returns>The uniform location.</returns>
		/// <param name="name">Name for the uniform.</param>
		public int GetUniformLocation(string name)
		{
			if (uniformLocations.ContainsKey(name))
				return uniformLocations[name];

			int location = GL.GetUniformLocation(program, name);
			if (location == -1)
			{
				throw new SMokaException("No uniform with name: " + name);
			}
			else
			{
				uniformLocations.Add(name, location);
			}

			SMokaLog.O(Application.TAG, "Shader - New uniform " + name + " at " + location);

			return location;
		}

		public void SetUniform(string name, float a)
		{
			GL.Uniform1(GetUniformLocation(name), a);
		}

		public void SetUniform(string name, float a, float b)
		{
			GL.Uniform2(GetUniformLocation(name), a, b);
		}

		public void SetUniform(string name, float a, float b, float c)
		{
			GL.Uniform3(GetUniformLocation(name), a, b, c);
		}

		public void SetUniform(string name, float a, float b, float c, float d)
		{
			GL.Uniform4(GetUniformLocation(name), a, b, c, d);
		}

		public void SetUniform(string name, Vector2 v)
		{
			GL.Uniform2(GetUniformLocation(name), v.x, v.y);
		}

		public void SetUniform(string name, Vector3 v)
		{
			GL.Uniform3(GetUniformLocation(name), v.x, v.y, v.z);
		}

		public void SetUniform(string name, Color color)
		{
			GL.Uniform4(GetUniformLocation(name), color.r, color.g, color.b, color.a);
		}

		public void SetUniform(string name, Matrix matrix)
		{
			GL.UniformMatrix4(GetUniformLocation(name), true, ref matrix);
		}

		private uint CreateShader(string filePath, ShaderType type)
		{
			// extract GLSL code from file.
			string code = File.ReadAllText(filePath);

			// create shader of the given type.
			uint shader = GL.CreateShader(type);

			// if the code given in the call above is 0 then there was an error.
			if (shader == 0)
				throw new SMokaException("Shader creation failed");

			// give GLSL code for the shader.
			GL.ShaderSource(shader, code);

			GL.CompileShader(shader);

			int status;
			GL.GetShader(shader, ShaderParameter.CompileStatus, out status);

			if (status == 0)
				throw new SMokaException("Shader compile error for file " + filePath
					+ ": " + GL.GetShaderInfoLog((int) shader));

			GL.AttachShader(program, shader);

			return shader;
		}
	}
}

