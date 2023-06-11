using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Opengl_Playground.Shaders;

namespace Opengl_Playground.Objects
{
    /// <summary>
    /// Classe para desenhar um retângulo
    /// </summary>
    public class Retangulo : RenderObject
    {
        #region Construtores

        /// <summary>
        /// Construtor para retângulos de core sólida
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do retângulo</param>
        /// <param name="color">Um vetor contendo valores para os 4 canais de cores (RGBa)</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao retângulo</param>
        public Retangulo(float[] vertices, Vector4 color, Matrix4? transformation) : base(vertices, ShaderPaths.SolidColorVertexShaderPath, ShaderPaths.SolidColorFragShaderPath)
        {
            Type = ObjectType.SolidColorObject;

            SetColor(color);

            SetModel(transformation ?? Matrix4.Identity);

            SetIndices(CreateIndices(vertices.Length == 12));

            if (vertices.Length != 12 && vertices.Length != 18)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Retângulo'");
            }

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para retângulos texturizados
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do retângulo</param>
        /// <param name="texturePath">Caminho para o arquivo de textura</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao retângulo</param>
        public Retangulo(float[] vertices, string texturePath, Matrix4? transformation) : base(vertices, ShaderPaths.TextureVertexShaderPath, ShaderPaths.TextureFragShaderPath)
        {
            Type = ObjectType.TextureObject;

            SetTexture(texturePath);

            SetModel(transformation ?? Matrix4.Identity);

            SetIndices(CreateIndices(vertices.Length == 20));

            if (vertices.Length != 20 && vertices.Length != 30)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Retangulo'");
            }

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para retângulos de várias cores
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do retângulo</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao retângulo</param>
        public Retangulo(float[] vertices, Matrix4? transformation) : base(vertices, ShaderPaths.ColorVertexShaderPath, ShaderPaths.ColorFragShaderPath)
        {
            Type = ObjectType.ColorObject;

            SetModel(transformation ?? Matrix4.Identity);

            SetIndices(CreateIndices(vertices.Length == 24));

            if (vertices.Length != 24 && vertices.Length != 36)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Retangulo'");
            }

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
            GL.DrawElements(PrimitiveType.Triangles, this.Indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        #region Métodos de inicialização de objetos Opengl

        override protected void InitializeOpenglObjects()
        {
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * this.Vertices.Length, this.Vertices, BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();
            ElementBufferObject = GL.GenBuffer();

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

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.Indices.Length * sizeof(uint), this.Indices, BufferUsageHint.StaticDraw);

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

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.Indices.Length * sizeof(uint), this.Indices, BufferUsageHint.StaticDraw);

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

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, this.Indices.Length * sizeof(uint), this.Indices, BufferUsageHint.StaticDraw);

            GL.BindVertexArray(0);
        }

        #endregion

        #region Métodos criadores de vértices e índices

        /// <summary>
        /// Implementa códigos de cor em um array de vértices pré-criado
        /// </summary>
        /// <param name="vertices">O array de vértices</param>
        /// <param name="colors">O array contendo os códigos de cor para cada vértice</param>
        /// <returns>Um array contendo os vértices e suas respectivas cores</returns>
        /// <exception cref="System.Exception">Caso o número de vértices ou o número de códigos de cor sejam inválidos</exception>
        public static float[] ImplementColorAtributtes(float[] vertices, Vector3[] colors)
        {
            var numVertices = vertices.Length / 3;

            if (numVertices != 4 && numVertices != 6)
            {
                throw new System.Exception("Number of vertices invalid at the object 'Retangulo'!\nNumber expected: 4 or 6\nNumber found: " + numVertices);
            }

            if (colors.Length != 4 && colors.Length != 6)
            {
                throw new System.Exception("Number of vertices invalid at the object 'Retangulo'!\nNumber expected: 4 or 6\nNumber found: " + colors.Length);
            }

            if (numVertices == 4)
            {
                if (colors.Length == 4)
                {
                    colors = new Vector3[]
                    {
                        colors[2],
                        colors[3],
                        colors[1],
                        colors[0],
                    };
                }

                else
                {
                    colors = new Vector3[]
                    {
                        colors[2],
                        colors[5],
                        colors[1],
                        colors[0],
                    };
                }
                
            }

            else
            {
                if (colors.Length == 4)
                {
                    colors = new Vector3[]
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[1],
                        colors[2],
                        colors[3],
                    };
                }

                colors = new Vector3[]
                {
                    colors[4],
                    colors[5],
                    colors[3],
                    colors[2],
                    colors[1],
                    colors[0]
                };
            }

            float[] aux = new float[vertices.Length + colors.Length * 3];
            var j = 0;

            var cor = colors;

            for (int i = 0; i < vertices.Length; i++)
            {
                aux[j] = vertices[i];

                if ((i + 1) % 3 == 0)
                {
                    aux[j + 1] = cor[(i - i % 3) / 3].X;
                    aux[j + 2] = cor[(i - i % 3) / 3].Y;
                    aux[j + 3] = cor[(i - i % 3) / 3].Z;

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
        /// <param name="textureCoords">O array contendo as coordenadas de textura para cada vértice / [0] - Top Left, [1] - Top Right, [2] - Bottom Right, [3] - Bottom Left</param>
        /// <returns>Um array contendo os vértices e suas coordenadas de texturas</returns>
        /// <exception cref="System.Exception">Caso o número de vértices ou o número de coordenadas de textura sejam inválidos</exception>
        public static float[] ImplementTextureAtributtes(float[] vertices, Vector2[]? textureCoords)
        {
            textureCoords ??= new Vector2[]
            {
                new Vector2(0f, 1f),
                new Vector2(1f, 1f),
                new Vector2(0f, 0f),
                new Vector2(1f, 0f),
            };

            if (textureCoords.Length != 4 && textureCoords.Length != 6)
            {
                throw new System.Exception("Number of texture coordinates invalid at the object 'Retangulo'!\nNumber expected: 4 or 6\nNumber found: " + textureCoords.Length);
            }

            if (vertices.Length != 12 && vertices.Length != 18)
            {
                throw new System.Exception("Number of vertices coordinates invalid at the object 'Retangulo'!\nNumber expected: 12 or 18\nNumber found: " + vertices.Length);
            }

            if (vertices.Length == 12)
            {
                if (textureCoords.Length == 6)
                {
                    textureCoords = new Vector2[]
                    {
                        textureCoords[2],
                        textureCoords[5],
                        textureCoords[1],
                        textureCoords[0],
                    };
                }

                else
                {
                    textureCoords = new Vector2[]
                    {
                        textureCoords[2],
                        textureCoords[3],
                        textureCoords[1],
                        textureCoords[0],
                    };
                }
            }

            else
            {
                if (textureCoords.Length == 4)
                {
                    textureCoords = new Vector2[]
                    {
                        textureCoords[2],
                        textureCoords[3],
                        textureCoords[1],
                        textureCoords[2],
                        textureCoords[1],
                        textureCoords[0],
                    };
                }

                else
                {
                    textureCoords = new Vector2[]
                    {
                        textureCoords[4],
                        textureCoords[5],
                        textureCoords[1],
                        textureCoords[2],
                        textureCoords[1],
                        textureCoords[0],
                    };
                }
            }

            float[] vert = new float[vertices.Length + textureCoords.Length * 2];
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
        /// Cria o array de vértices para se desenhar um retângulo a partir de um array de vetores de coordenadas
        /// </summary>
        /// <param name="vertices">O array de vetores de coordenadas / [0] - Top Left, [1] - Top Right, [2] - Bottom Left, [3] - Bottom Right</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3[] vertices)
        {
            if (vertices.Length != 4)
            {
                throw new System.Exception("Number of vertices invalid for the object 'Retangulo'!\nNumber Expected: 4\nNumber Found: " + vertices.Length);
            }

            float[] vert = new float[vertices.Length * 3];

            var i = 0;

            foreach (var item in vertices)
            {
                vert[i] = item.X;
                vert[i + 1] = item.Y;
                vert[i + 2] = item.Z;

                i += 3;
            }

            return vert;
        }

        /// <summary>
        /// Cria os vértices para se desenhar um retângulo
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="width">A largura do objeto</param>
        /// <param name="height">A altura do objeto</param>
        /// <param name="verticesEconomized">Define se o retângulo deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3 centerPosition, float width, float height, bool verticesEconomized)
        {
            float[] vertices;

            if (verticesEconomized)
            {
                vertices = new float[12];
                var verticeCount = 0;

                for (int i = 0; i < 4; i++)
                {
                    switch (verticeCount)
                    {
                        case 0:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j] = centerPosition.X - width / 2;
                                        break;

                                    case 1:
                                        vertices[j] = centerPosition.Y - height / 2;
                                        break;

                                    case 2:
                                        vertices[j] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;

                        case 1:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 3] = centerPosition.X + width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 3] = centerPosition.Y - height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 3] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;

                        case 2:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 6] = centerPosition.X + width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 6] = centerPosition.Y + height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 6] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;

                        case 3:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 9] = centerPosition.X - width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 9] = centerPosition.Y + height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 9] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;
                    }

                    verticeCount++;
                }
            }

            else
            {
                vertices = new float[18];
                var aux = CreateSolidColorVertices(centerPosition, width, height, true);
                var indices = CreateIndices(true);
                var k = 0;

                for (int i = 0; i < indices.Length; i++)
                {
                    vertices[k] = aux[indices[i] * 3];
                    vertices[k + 1] = aux[indices[i] * 3 + 1];
                    vertices[k + 2] = aux[indices[i] * 3 + 2];

                    k += 3;
                }
            }

            return vertices;
        }

        /// <summary>
        /// Cria os vértices e as coordenadas de textura para se desenhar um retângulo
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="width">A largura do objeto</param>
        /// <param name="height">A altura do objeto</param>
        /// <param name="verticesEconomized">Define se o retângulo deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto e as coordenadas de textura</returns>
        public static float[] CreateTextureVertices(Vector3 centerPosition, float width, float height, bool verticesEconomized)
        {
            float[] vertices;

            if (verticesEconomized)
            {
                vertices = new float[20];
                var verticeCount = 0;

                for (int i = 0; i < 4; i++)
                {
                    switch (verticeCount)
                    {
                        case 0:
                            for (int j = 0; j < 5; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j] = centerPosition.X - width / 2;
                                        break;

                                    case 1:
                                        vertices[j] = centerPosition.Y + height / 2;
                                        break;

                                    case 2:
                                        vertices[j] = centerPosition.Z;
                                        break;

                                    case 3:
                                        vertices[j] = 0f;
                                        break;

                                    case 4:
                                        vertices[j] = 1f;
                                        break;
                                }
                            }

                            break;

                        case 1:
                            for (int j = 0; j < 5; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 5] = centerPosition.X + width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 5] = centerPosition.Y + height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 5] = centerPosition.Z;
                                        break;

                                    case 3:
                                        vertices[j + 5] = 1f;
                                        break;

                                    case 4:
                                        vertices[j + 5] = 1f;
                                        break;
                                }
                            }

                            break;

                        case 2:
                            for (int j = 0; j < 5; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 10] = centerPosition.X + width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 10] = centerPosition.Y - height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 10] = centerPosition.Z;
                                        break;

                                    case 3:
                                        vertices[j + 10] = 1f;
                                        break;

                                    case 4:
                                        vertices[j + 10] = 0f;
                                        break;
                                }
                            }

                            break;

                        case 3:
                            for (int j = 0; j < 5; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 15] = centerPosition.X - width / 2;
                                        break;

                                    case 1:
                                        vertices[j + 15] = centerPosition.Y - height / 2;
                                        break;

                                    case 2:
                                        vertices[j + 15] = centerPosition.Z;
                                        break;

                                    case 3:
                                        vertices[j + 15] = 0f;
                                        break;

                                    case 4:
                                        vertices[j + 15] = 0f;
                                        break;
                                }
                            }

                            break;
                    }

                    verticeCount++;
                }
            }

            else
            {
                vertices = new float[30];
                var aux = CreateTextureVertices(centerPosition, width, height, true);
                var indices = CreateIndices(true);
                var k = 0;

                for (int i = 0; i < indices.Length; i++)
                {
                    vertices[k] = aux[indices[i] * 5];
                    vertices[k + 1] = aux[indices[i] * 5 + 1];
                    vertices[k + 2] = aux[indices[i] * 5 + 2];
                    vertices[k + 3] = aux[indices[i] * 5 + 3];
                    vertices[k + 4] = aux[indices[i] * 5 + 4];

                    k += 5;
                }
            }

            return vertices;
        }

        /// <summary>
        /// Cria os vértices e as coordenadas de cor necessárias para se desenhar um retângulo
        /// </summary>
        /// <param name="centerPosition">A coordenada X, Y, Z central do objeto</param>
        /// <param name="color">[0] - Top Left Color, [1] - Top Right Color, [2] - Bottom Left Color, [3] - Bottom Right Color</param>
        /// <param name="width">A largura do retâgulo</param>
        /// <param name="height">A altura do retângulo</param>
        /// <param name="verticesEconomized">Define se o retângulo deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateColorVertices(Vector3 centerPosition, Vector3[] color, float width, float height, bool verticesEconomized)
        {
            if (color.Length != 4 && color.Length != 6)
            {
                throw new System.Exception("Number of colors invalid!\nNumber Expected: 4 or 6\nNumber Found: " + color.Length);
            }

            float[] vertices;
            var aux = CreateSolidColorVertices(centerPosition, width, height, verticesEconomized);

            if (verticesEconomized)
            {
                vertices = new float[24];
                var j = 0;

                if (color.Length == 6)
                {
                    color = new Vector3[]
                    {
                        color[0],
                        color[1],
                        color[2],
                        color[5],
                    };
                }

                var cor = new Vector3[]
                {
                    color[2],
                    color[3],
                    color[1],
                    color[0]
                };

                for (int i = 0; i < aux.Length; i++)
                {
                    vertices[j] = aux[i];

                    if ((i + 1) % 3 == 0)
                    {
                        vertices[j + 1] = cor[(i - i % 3) / 3].X;
                        vertices[j + 2] = cor[(i - i % 3) / 3].Y;
                        vertices[j + 3] = cor[(i - i % 3) / 3].Z;

                        j += 3;
                    }

                    j++;
                }
            }

            else
            {
                vertices = new float[36];
                var j = 0;

                if (color.Length == 4)
                {
                    color = new Vector3[]
                    {
                        color[0],
                        color[1],
                        color[2],

                        color[1],
                        color[2],
                        color[3],
                    };
                }

                var cor = new Vector3[]
                {
                    color[4],
                    color[5],
                    color[3],
                    color[2],
                    color[1],
                    color[0]
                };

                for (int i = 0; i < aux.Length; i++)
                {
                    vertices[j] = aux[i];

                    if ((i + 1) % 3 == 0)
                    {
                        vertices[j + 1] = cor[(i - i % 3) / 3].X;
                        vertices[j + 2] = cor[(i - i % 3) / 3].Y;
                        vertices[j + 3] = cor[(i - i % 3) / 3].Z;

                        j += 3;
                    }

                    j++;
                }
            }

            return vertices;
        }

        /// <summary>
        /// Cria os índices necessários para desenho dos triângulos que compõe o retângulo
        /// </summary>
        /// <param name="verticesEconomized">Especifíca se o objeto foi construído utilizando o sistema de economia de vértices</param>
        /// <returns>Um array contendo os índices</returns>
        public static uint[] CreateIndices(bool verticesEconomized)
        {
            uint[] indices = new uint[6];

            if (verticesEconomized)
            {
                indices = new uint[] 
                {
                    0, 1, 2,
                    0, 2, 3
                };
            }

            else
            {
                for (uint i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
            }

            return indices;
        }

        #endregion
    }
}
