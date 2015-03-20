using System;
using Pencil.Gaming.Graphics;
using System.Collections.Generic;
using System.IO;

namespace SMokaEngine
{
	public class Shader
	{
		private Dictionary<String, int> uniformLocations;
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
				throw new SMokaException(GL.GetShaderInfoLog(program, 1024));

			// validate program.
			GL.ValidateProgram(program);

			// get error code for validation if any.
			GL.GetProgram(program, ProgramParameter.ValidateStatus, out errorCode);
			if (errorCode == 0)
				throw new SMokaException(GL.GetShaderInfoLog(program, 1024));

			uniformLocations = new Dictionary<string, int>();

			// output log.
			SMokaLog.O(Application.TAG, "Shader created.");
		}

		public void Bind()
		{
			GL.UseProgram(program);
		}

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

		private uint CreateShader(string filePath, ShaderType type)
		{
			string code = File.ReadAllText(filePath);

			uint shader = GL.CreateShader(type);

			if (shader == 0)
				throw new SMokaException("Shader creation failed for file" + filePath);

			GL.ShaderSource(shader, code);

			GL.CompileShader(shader);

			int status;
			GL.GetShader(shader, ShaderParameter.CompileStatus, out status);

			if (status == 0)
				throw new SMokaException("Shader compile error for file " + filePath
					+ ": " + GL.GetShaderInfoLog(shader, 1024));

			GL.AttachShader(program, shader);

			return shader;
		}
	}
}

