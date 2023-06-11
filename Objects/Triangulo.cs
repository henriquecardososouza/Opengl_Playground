using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Opengl_Playground.Shaders;

namespace Opengl_Playground.Objects
{
    /// <summary>
    /// Classe para se desenhar um triângulo
    /// </summary>
    public class Triangulo : RenderObject
    {
        #region Construtores

        /// <summary>
        /// Construtor para triângulos de cor sólida
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do triângulo</param>
        /// <param name="color">Um vetor contendo os 4 canais de cores (RGBa)</param>
        /// <param name="transformation">Transformação que será aplicada ao triângulo</param>
        public Triangulo(float[] vertices, Vector4 color, Matrix4? transformation) : base(vertices, ShaderPaths.SolidColorVertexShaderPath, ShaderPaths.SolidColorFragShaderPath)
        {
            Type = ObjectType.SolidColorObject;

            SetColor(color);

            SetModel(transformation ?? Matrix4.Identity);

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para triângulos texturizados
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do triângulo</param>
        /// <param name="texturePath">O caminho para o arquivo de textura</param>
        /// <param name="transformation">Transformação que será aplicada ao triângulo</param>
        public Triangulo(float[] vertices, string texturePath, Matrix4? transformation) : base(vertices, ShaderPaths.TextureVertexShaderPath, ShaderPaths.TextureFragShaderPath)
        {
            Type = ObjectType.TextureObject;

            SetTexture(texturePath);

            SetModel(transformation ?? Matrix4.Identity);

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para triângulos de várias cores
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do triângulo</param>
        /// <param name="transformation">Transformação que será aplicada ao triângulo</param>
        public Triangulo(float[] vertices, Matrix4? transformation) : base(vertices, ShaderPaths.ColorVertexShaderPath, ShaderPaths.ColorFragShaderPath)
        {
            Type = ObjectType.ColorObject;

            SetModel(transformation ?? Matrix4.Identity);

            InitializeOpenglObjects();
        }

        #endregion

        override public void DrawObject()
        {
            if (Type == ObjectType.TextureObject)
            {
                Texture.Use(TextureUnit.Texture0);
            }

            Shader.Use();

            if (Type == ObjectType.SolidColorObject)
            {
                AplicateColor();
            }

            AplicateTransform();

            GL.BindVertexArray(VertexArrayObject);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        #region Métodos de inicialização de objetos Opengl

        override protected void InitializeOpenglObjects()
        {
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * this.Vertices.Length, this.Vertices, BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();

            if (Type == ObjectType.SolidColorObject)
            {
                InitializeSolidColorVertexArray();
            }

            else if (Type == ObjectType.ColorObject)
            {
                InitializeColorVertexArray();
            }

            else
            {
                InitializeTextureVertexArray();
            }
        }

        private void InitializeSolidColorVertexArray()
        {
            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.VertexAttribPointer(Shader.GetAttribLocation("aPosition"), 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(Shader.GetAttribLocation("aPosition"));

            GL.BindVertexArray(0);
        }

        private void InitializeTextureVertexArray()
        {
            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            GL.VertexAttribPointer(Shader.GetAttribLocation("aPosition"), 3, VertexAttribPointerType.Float, false, sizeof(float) * 5, 0);
            GL.EnableVertexAttribArray(Shader.GetAttribLocation("aPosition"));

            GL.EnableVertexAttribArray(Shader.GetAttribLocation("aTexCoord"));
            GL.VertexAttribPointer(Shader.GetAttribLocation("aTexCoord"), 2, VertexAttribPointerType.Float, false, sizeof(float) * 5, sizeof(float) * 3);

            GL.BindVertexArray(0);
        }

        private void InitializeColorVertexArray()
        {
            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);

            GL.VertexAttribPointer(Shader.GetAttribLocation("aPosition"), 3, VertexAttribPointerType.Float, false, sizeof(float) * 6, 0);
            GL.EnableVertexAttribArray(Shader.GetAttribLocation("aPosition"));

            GL.EnableVertexAttribArray(Shader.GetAttribLocation("aColor"));
            GL.VertexAttribPointer(Shader.GetAttribLocation("aColor"), 3, VertexAttribPointerType.Float, false, sizeof(float) * 6, sizeof(float) * 3);

            GL.BindVertexArray(0);
        }

        #endregion

        #region Métodos de criação e manipulação de vértices e índices

        /// <summary>
        /// Implementa códigos de cor em um array de vértices pré-criado
        /// </summary>
        /// <param name="vertices">O array de vértices</param>
        /// <param name="colors">O array contendo os códigos de cor para cada vértice / [0] - Bottom Left, [1] - Top, [2] - Bottom Right</param>
        /// <returns>Um array contendo os vértices e suas respectivas cores</returns>
        /// <exception cref="System.Exception">Caso o número de vértices ou o número de códigos de cor sejam inválidos</exception>
        public static float[] ImplementColorAtributtes(float[] vertices, Vector3[] colors)
        {
            float[] aux = new float[18];
            var numVertices = vertices.Length / 3;

            if (numVertices != 3)
            {
                throw new System.Exception("Number of vertices invalid at the object 'Triangulo'!\nNumber Expected: 3\nNumber Found: " + numVertices);
            }

            if (colors.Length != 3)
            {
                throw new System.Exception("Number of vertices invalid at the object 'Triangulo'!\nNumber Expected: 3\nNumber Found: " + numVertices);
            }

            var j = 0;

            for (int i = 0; i < vertices.Length; i++)
            {
                aux[j] = vertices[i];

                if ((i + 1) % 3 == 0)
                {
                    aux[j + 1] = colors[(i - i % 3) / 3].X;
                    aux[j + 2] = colors[(i - i % 3) / 3].Y;
                    aux[j + 3] = colors[(i - i % 3) / 3].Z;

                    j += 3;
                }

                j++;
            }

            return aux;
        }

        /// <summary>
        /// Implementa coordenadas texturas em um array de vértices pré-criado
        /// </summary>
        /// <param name="vertices">O array de vértices</param>
        /// <param name="textureCoords">O array contendo as coordenadas de textura para cada vértice / [0] - Bottom Left, [1] - Top, [2] - Bottom Right</param>
        /// <returns>Um array contendo os vértices e suas coordenadas de texturas</returns>
        /// <exception cref="System.Exception">Caso o número de vértices ou o número de coordenadas de textura sejam inválidos</exception>
        public static float[] ImplementTextureAtributtes(float[] vertices, Vector2[]? textureCoords)
        {
            textureCoords ??= new Vector2[]
            {
                new Vector2(0f, 0f),
                new Vector2(0.5f, 1f),
                new Vector2(1f, 0f)
            };

            if (textureCoords.Length != 3)
            {
                throw new System.Exception("Number of texture coordinates invalid at the object 'Triangulo'!\nNumber Expected: 3\nNumber Found: " + textureCoords.Length);
            }

            if (vertices.Length != 9)
            {
                throw new System.Exception("Number of vertices coordinates invalid at the object 'Triangulo'!\\nNumber Expected: 9\nNumber Found: " + vertices.Length);
            }

            float[] vert = new float[15];
            var j = 0;

            for (int i = 0; i < vertices.Length; i++)
            {
                vert[j] = vertices[i];

                if ((i + 1) % 3 == 0)
                {
                    vert[j + 1] = textureCoords[(i - i % 3) / 3].X;
                    vert[j + 2] = textureCoords[(i - i % 3) / 3].Y;

                    j += 2;
                }

                j++;
            }

            return vert;
        }

        /// <summary>
        /// Cria o array de vértices para se desenhar um triângulo a partir de um array de vetores de coordenadas
        /// </summary>
        /// <param name="vertices">O array de vetores de coordenadas</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3[] vertices)
        {
            if (vertices.Length != 3)
            {
                throw new System.Exception("Number of vertices invalid for the object 'triangulo'!\nNumber Expected: 3\nNumber Found: " + vertices.Length);
            }

            float[] vert = new float[9];

            var i = 0;

            foreach(var item in vertices)
            {
                vert[i] = item.X;
                vert[i + 1] = item.Y;
                vert[i + 2] = item.Z;

                i += 3;
            }

            return vert;
        }

        /// <summary>
        /// Cria os vértices para se desenhar um triângulo
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="sideLength">O comprimento do lado do triângulo</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3 centerPosition, float sideLength)
        {
            float[] vertices = new float[9];
            var height = sideLength * MathHelper.Sqrt(3) / 2;

            for (int i = 0; i < vertices.Length; i++)
            {
                if (i < 3)
                {
                    switch(i)
                    {
                        case 0:
                            vertices[i] = centerPosition.X - (float)height / 2;
                            break;

                        case 1:
                            vertices[i] = centerPosition.Y - (float)height / 2;
                            break;

                        case 2:
                            vertices[i] = centerPosition.Z;
                            break;
                    }
                }

                else if (i < 6)
                {
                    switch (i)
                    {
                        case 3:
                            vertices[i] = centerPosition.X;
                            break;

                        case 4:
                            vertices[i] = centerPosition.Y + (float)height / 2;
                            break;

                        case 5:
                            vertices[i] = centerPosition.Z;
                            break;
                    }
                }

                else
                {
                    switch (i)
                    {
                        case 6:
                            vertices[i] = centerPosition.X + (float)height / 2;
                            break;

                        case 7:
                            vertices[i] = centerPosition.Y - (float)height / 2;
                            break;

                        case 8:
                            vertices[i] = centerPosition.Z;
                            break;
                    }
                }
            }

            return vertices;
        }

        /// <summary>
        /// Cria os vértices e suas coordenadas de cor necessárias para se desenhar um triângulo
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="sideLength">O comprimento do lado do triângulo</param>
        /// <param name="color">Um array contendo os códigos de cor para cada vértice do objeto / [0] - Bottom Left, [1] - Top, [2] - Bottom Right</param>
        /// <returns>Um array contendo as coordenadas dos vértices e das cores do objeto</returns>
        public static float[] CreateColorVertices(Vector3 centerPosition, float sideLength, Vector3[] color)
        {
            if (color.Length > 3)
            {
                throw new System.Exception("Number of colors invalid for the object 'Triangulo'!\nNumber Expected: 3\nNumber Found: " + color.Length);
            }

            float[] vertices = new float[18];
            var aux = CreateSolidColorVertices(centerPosition, sideLength);

            var j = 0;

            for (int i = 0; i < aux.Length; i++) {
                vertices[j] = aux[i];

                if ((i + 1) % 3 == 0)
                {
                    vertices[j + 1] = color[(i - i % 3) / 3].X;
                    vertices[j + 2] = color[(i - i % 3) / 3].Y;
                    vertices[j + 3] = color[(i - i % 3) / 3].Z;

                    j += 3;
                }

                j++;
            }

            return vertices;
        }

        /// <summary>
        /// Cria os vértices e as coordenadas de textura necessárias para se desenhar um triângulo
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="sideLength">O comprimento do lado do triângulo</param>
        /// <returns>Um array contendo as coordenadas dos vértices e da textura do objeto</returns>
        public static float[] CreateTextureVertices(Vector3 centerPosition, float sideLength)
        {
            float[] vertices = new float[15];
            var aux = CreateSolidColorVertices(centerPosition, sideLength);

            var j = 0;

            for (int i = 0; i < aux.Length; i++)
            {
                vertices[j] = aux[i];

                if ((i + 1) % 3 == 0)
                {
                    switch ((i - i % 3) / 3)
                    {
                        case 0:
                            vertices[j + 1] = 0f;
                            vertices[j + 2] = 0f;
                            break;

                        case 1:
                            vertices[j + 1] = 0.5f;
                            vertices[j + 2] = 1f;
                            break;

                        case 2:
                            vertices[j + 1] = 1f;
                            vertices[j + 2] = 0f;
                            break;
                    }

                    j += 2;
                }

                j++;
            }

            return vertices;
        }

        #endregion
    }
}
