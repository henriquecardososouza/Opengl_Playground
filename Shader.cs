using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Collections.Generic;
using System;

namespace Opengl_Playground
{
    public class Shader
    {
        /// <summary>
        /// id do program shader
        /// </summary>
        public readonly int Handle;

        /// <summary>
        /// Dicionario da localização dos atributos uniform dos shaders
        /// </summary>
        private readonly Dictionary<string, int> _uniformsLocation;

        public Shader(string vertexPath, string fragmentPath)
        {
            // Basicamente primeiro lemos o código do shader
            var sourceShader = File.ReadAllText(vertexPath);

            // Depois criamos um shader vazio, e guardamos seu id
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);

            // Em seguida atribuímos o código que lemos ao shader que acabamos de criar
            GL.ShaderSource(vertexShader, sourceShader);

            // Por último compilamos o código
            CompileShader(vertexShader);

            // Agora repetimos o processo com o outro shader
            sourceShader = File.ReadAllText(fragmentPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, sourceShader);
            CompileShader(fragmentShader);

            // O opengl executa um shader program, vamos combinar os dois shaders acima em um programa

            // Primeiro vamos cria um programa vazio
            Handle = GL.CreateProgram();

            // Vamos adicionar os dois shaders ao programa
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);

            // Combinamos os shaders
            LinkProgram(Handle);

            // Agora excluimos os shaders originais (Eles ja forma copiados para o program shader)
            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            // O shader está pronto, mas agora vamos guardar os valores dos atributos uniforms
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            _uniformsLocation = new Dictionary<string, int>();

            for (int i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(Handle, i, out _, out _);
                var location = GL.GetUniformLocation(Handle, key);

                _uniformsLocation.Add(key, location);
            }
        }

        /// <summary>
        /// Compila um shader
        /// </summary>
        /// <param name="shader">Id do shader a ser compilado</param>
        /// <exception cref="Exception"></exception>
        private static void CompileShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var state);
            if (state != (int)All.True)
            {
                throw new Exception($"Erro ao compilar o shader ({shader}).\n\n{GL.GetShaderInfoLog(shader)}");
            }
        }

        /// <summary>
        /// Linka um programa
        /// </summary>
        /// <param name="program">Id do programa a ser linkado</param>
        /// <exception cref="Exception"></exception>
        private static void LinkProgram(int program)
        {
            GL.LinkProgram(program);

            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var state);

            if (state != (int)All.True)
            {
                throw new Exception($"Erro ao linkar o programa {program}");
            }
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        // The shader sources provided with this project use hardcoded layout(location)-s. If you want to do it dynamically,
        // you can omit the layout(location=X) lines in the vertex shader, and use this in VertexAttribPointer instead of the hardcoded values.
        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(Handle, attribName);
        }

        // Uniform setters
        // Uniforms are variables that can be set by user code, instead of reading them from the VBO.
        // You use VBOs for vertex-related data, and uniforms for almost everything else.

        // Setting a uniform is almost always the exact same, so I'll explain it here once, instead of in every method:
        //     1. Bind the program you want to set the uniform on
        //     2. Get a handle to the location of the uniform with GL.GetUniformLocation.
        //     3. Use the appropriate GL.Uniform* function to set the uniform.

        /// <summary>
        /// Set a uniform int on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetInt(string name, int data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformsLocation[name], data);
        }

        /// <summary>
        /// Set a uniform float on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetFloat(string name, float data)
        {
            GL.UseProgram(Handle);
            GL.Uniform1(_uniformsLocation[name], data);
        }

        /// <summary>
        /// Set a uniform Matrix4 on this shader
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        /// <remarks>
        ///   <para>
        ///   The matrix is transposed before being sent to the shader.
        ///   </para>
        /// </remarks>
        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Handle);
            GL.UniformMatrix4(_uniformsLocation[name], true, ref data);
        }

        /// <summary>
        /// Set a uniform Vector3 on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetVector3(string name, Vector3 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform3(_uniformsLocation[name], data);
        }

        /// <summary>
        /// Set a uniform Vector4 on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetVector4(string name, Vector4 data)
        {
            GL.UseProgram(Handle);
            GL.Uniform4(_uniformsLocation[name], data.X, data.Y, data.Z, data.W);
        }
    }
}
