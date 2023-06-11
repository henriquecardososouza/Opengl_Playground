using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Opengl_Playground.Shaders;

namespace Opengl_Playground.Objects
{
    /// <summary>
    /// Classe para desenhar um hexagono
    /// </summary>
    public class Hexagono : RenderObject
    {
        #region Contrutores

        /// <summary>
        /// Construtor para hexagonos de cores sólidas
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do hexagono</param>
        /// <param name="color">Um vetor contendo valores para os 4 canais de cores (RGBa)</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao hexagono</param>
        public Hexagono(float[] vertices, Vector4 color, Matrix4? transformation) : base(vertices, ShaderPaths.SolidColorVertexShaderPath, ShaderPaths.SolidColorFragShaderPath)
        {
            Type = ObjectType.SolidColorObject;

            SetColor(color);

            SetIndices(CreateIndices(vertices.Length == 21));

            if (vertices.Length != 21 && vertices.Length != 54)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Hexagono'!");
            }

            SetModel(transformation ?? Matrix4.Identity);

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para hexagonos texturizados
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do hexagono</param>
        /// <param name="texturePath">Caminho para o arquivo de textura</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao hexagono</param>
        public Hexagono(float[] vertices, string texturePath, Matrix4? transformation) : base(vertices, ShaderPaths.TextureVertexShaderPath, ShaderPaths.TextureFragShaderPath)
        {
            Type = ObjectType.TextureObject;

            SetTexture(texturePath);

            SetIndices(CreateIndices(vertices.Length == 35));

            if (vertices.Length != 35 && vertices.Length != 90)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Hexagono'!");
            }

            SetModel(transformation ?? Matrix4.Identity);

            InitializeOpenglObjects();
        }

        /// <summary>
        /// Construtor para hexagonos de várias cores
        /// </summary>
        /// <param name="vertices">As coordenadas dos vértices do hexagono</param>
        /// <param name="transformation">Uma matrix para aplicar uma tranformação ao hexagono</param>
        public Hexagono(float[] vertices, Matrix4? transformation) : base(vertices, ShaderPaths.ColorVertexShaderPath, ShaderPaths.ColorFragShaderPath)
        {
            Type = ObjectType.ColorObject;

            SetIndices(CreateIndices(vertices.Length == 42));

            if (vertices.Length != 42 && vertices.Length != 108)
            {
                System.Console.WriteLine("ALERT: You may have selected the wrong vertices constructor for the object 'Hexagono'!");
            }

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
            GL.DrawElements(PrimitiveType.Triangles, this.Indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        #region Métodos de Inicialização de objetos Opengl

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

        #endregion

        #region Métodos Criadores de Vértices e Índices

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

            if (numVertices != 7 && numVertices != 18)
            {
                throw new System.Exception("Number of vertices invalid at the object 'Hexagono'!\nNumber expected: 4 or 8\nNumber found: " + numVertices);
            }

            if (colors.Length != 7 && colors.Length != 18)
            {
                throw new System.Exception("Number of colors invalid at the object 'Hexagono'!\nNumber expected: 7 or 18\nNumber found: " + colors.Length);
            }

            Vector3[] cor;

            if (numVertices == 7)
            {
                if (colors.Length == 7)
                {
                    cor = colors;
                }

                else
                {
                    cor = new Vector3[]
                    {
                        colors[0],
                        colors[1],
                        colors[4],
                        colors[7],
                        colors[10],
                        colors[13],
                        colors[14],
                    };
                }
            }

            else
            {
                if (colors.Length == 7)
                {
                    cor = new Vector3[] {
                        colors[0],
                        colors[1],
                        colors[6],
                        colors[1],
                        colors[2],
                        colors[6],
                        colors[2],
                        colors[3],
                        colors[6],
                        colors[3],
                        colors[4],
                        colors[6],
                        colors[4],
                        colors[5],
                        colors[6],
                        colors[5],
                        colors[0],
                        colors[6]
                    };
                }

                else
                {
                    cor = colors;
                }
            }

            float[] aux = new float[vertices.Length + cor.Length * 3];
            var j = 0;

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
        /// <param name="textureCoords">O array contendo as coordenadas de textura para cada vértice (null para coordenadas automáticas)</param>
        /// <returns>Um array contendo os vértices e suas coordenadas de texturas</returns>
        /// <exception cref="System.Exception">Caso o número de vértices ou o número de coordenadas de textura sejam inválidos</exception>
        public static float[] ImplementTextureAtributtes(float[] vertices, Vector2[]? textureCoords)
        {
            textureCoords ??= (vertices.Length == 21 ? new Vector2[]
            {
                new Vector2(0f, 0.75f),
                new Vector2(0.5f, 1f),
                new Vector2(1f, 0.75f),
                new Vector2(1f, 0.25f),
                new Vector2(0.5f, 0f),
                new Vector2(0f, 0.25f),
                new Vector2(0.5f, 0.5f),
            } : new Vector2[]
            {
                new Vector2(0, 0.75f),
                new Vector2(0.5f, 1),
                new Vector2(0.5f, 0.5f),
                new Vector2(0.5f, 1),
                new Vector2(1, 0.75f),
                new Vector2(0.5f, 0.5f),
                new Vector2(1, 0.75f),
                new Vector2(1, 0.25f),
                new Vector2(0.5f, 0.5f),
                new Vector2(1, 0.25f),
                new Vector2(0.5f, 0),
                new Vector2(0.5f, 0.5f),
                new Vector2(0.5f, 0),
                new Vector2(0, 0.25f),
                new Vector2(0.5f, 0.5f),
                new Vector2(0, 0.25f),
                new Vector2(0, 0.75f),
                new Vector2(0.5f, 0.5f)
            });

            if (textureCoords.Length != 7 && textureCoords.Length != 18)
            {
                throw new System.Exception("Number of texture coordinates invalid at the object 'Hexagono'!\nNumber expected: 7 or 18\nNumber found: " + textureCoords.Length);
            }

            if (vertices.Length != 21 && vertices.Length != 54)
            {
                throw new System.Exception("Number of vertices coordinates invalid at the object 'Hexagono'!\nNumber expected: 21 or 54\nNumber found: " + vertices.Length);
            }

            if (vertices.Length == 54 && textureCoords.Length == 7)
            {
                textureCoords = new Vector2[]
                {
                    textureCoords[0],
                    textureCoords[1],
                    textureCoords[6],
                    textureCoords[1],
                    textureCoords[2],
                    textureCoords[6],
                    textureCoords[2],
                    textureCoords[3],
                    textureCoords[6],
                    textureCoords[3],
                    textureCoords[4],
                    textureCoords[6],
                    textureCoords[4],
                    textureCoords[5],
                    textureCoords[6],
                    textureCoords[5],
                    textureCoords[0],
                    textureCoords[6],
                };
            }

            if (vertices.Length == 21 && textureCoords.Length == 18)
            {
                textureCoords = new Vector2[]
                {
                    textureCoords[0],
                    textureCoords[1],
                    textureCoords[4],
                    textureCoords[7],
                    textureCoords[10],
                    textureCoords[13],
                    textureCoords[17],
                };
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
        /// Cria o array de vértices para se desenhar um hexagono a partir de um array de vetores de coordenadas
        /// </summary>
        /// <param name="vertices">O array de vetores de coordenadas</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3[] vertices)
        {
            if (vertices.Length != 7 && vertices.Length != 18)
            {
                throw new System.Exception("Number of vertices invalid for the object 'Hexagono'!\nNumber Expected: 7 or 18\nNumber Found: " + vertices.Length);
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
        /// Cria os vértices para se desenhar um hexagono
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="sideLength">O comprimento do lado do objeto</param>
        /// <param name="verticesEconomized">Define se o hexagono deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateSolidColorVertices(Vector3 centerPosition, float sideLength, bool verticesEconomized)
        {
            float[] vertices;

            if (verticesEconomized)
            {
                vertices = new float[21];
                int verticeCount = 0;

                for (int i = 0; i < 6; i++)
                {
                    switch (verticeCount)
                    {
                        case 0:
                            for (int j = 0; j < 3; j++) 
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j] = centerPosition.X - (float)MathHelper.Sqrt(3) * sideLength / 2;
                                        break;

                                    case 1:
                                        vertices[j] = centerPosition.Y + sideLength / 2;
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
                                        vertices[j + 3] = centerPosition.X;
                                        break;

                                    case 1:
                                        vertices[j + 3] = centerPosition.Y + sideLength;
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
                                        vertices[j + 6] = centerPosition.X + (float)MathHelper.Sqrt(3) * sideLength / 2;
                                        break;

                                    case 1:
                                        vertices[j + 6] = centerPosition.Y + sideLength / 2;
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
                                        vertices[j + 9] = centerPosition.X + (float)MathHelper.Sqrt(3) * sideLength / 2;
                                        break;

                                    case 1:
                                        vertices[j + 9] = centerPosition.Y - sideLength / 2;
                                        break;

                                    case 2:
                                        vertices[j + 9] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;

                        case 4:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 12] = centerPosition.X;
                                        break;

                                    case 1:
                                        vertices[j + 12] = centerPosition.Y - sideLength;
                                        break;

                                    case 2:
                                        vertices[j + 12] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;

                        case 5:
                            for (int j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        vertices[j + 15] = centerPosition.X - (float)MathHelper.Sqrt(3) * sideLength / 2;
                                        break;

                                    case 1:
                                        vertices[j + 15] = centerPosition.Y - sideLength / 2;
                                        break;

                                    case 2:
                                        vertices[j + 15] = centerPosition.Z;
                                        break;
                                }
                            }

                            break;
                    }

                    verticeCount++;
                }

                vertices[18] = centerPosition.X;
                vertices[19] = centerPosition.Y;
                vertices[20] = centerPosition.Z;
            }

            else
            {
                vertices = new float[54];
                var aux = CreateSolidColorVertices(centerPosition, sideLength, true);
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
        /// Cria os vértices e as coordenadas de textura para se desenhar um hexagono
        /// </summary>
        /// <param name="centerPosition">As coordenadas X, Y, Z da posição central do objeto</param>
        /// <param name="sideLength">O comprimento do lado do objeto</param>
        /// <param name="verticesEconomized">Define se o hexagono deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto e as coordenadas de textura</returns>
        public static float[] CreateTextureVertices(Vector3 centerPosition, float sideLength, bool verticesEconomized)
        {
            return ImplementTextureAtributtes(CreateSolidColorVertices(centerPosition, sideLength, verticesEconomized), null);
        }

        /// <summary>
        /// Cria os vértices e as coordenadas de cor necessárias para se desenhar um retângulo
        /// </summary>
        /// <param name="centerPosition">A coordenada X, Y, Z central do objeto</param>
        /// <param name="color"></param>
        /// <param name="sideLength">O comprimento do lado do objeto</param>
        /// <param name="verticesEconomized">Define se o hexagono deverá ser construído utilizando o método de economia de vértices (recomendado)</param>
        /// <returns>Um array contendo as coordenadas dos vértices do objeto</returns>
        public static float[] CreateColorVertices(Vector3 centerPosition, Vector3[] color, float sideLength, bool verticesEconomized)
        {
            if (color.Length != 7 && color.Length != 18)
            {
                throw new System.Exception("Number of colors invalid at the object 'Hexagono'!\nNumber Expected: 7 or 18\nNumber Found: " + color.Length);
            }

            float[] vertices;
            var aux = CreateSolidColorVertices(centerPosition, sideLength, verticesEconomized);

            if (verticesEconomized)
            {
                vertices = new float[42];
                var j = 0;

                var cor = color;

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
                vertices = new float[108];
                var j = 0;

                var cor = (color.Length == 7 ? new Vector3[]
                {
                    color[0],
                    color[1],
                    color[6],
                    color[1],
                    color[2],
                    color[6],
                    color[2],
                    color[3],
                    color[6],
                    color[3],
                    color[4],
                    color[6],
                    color[4],
                    color[5],
                    color[6],
                    color[5],
                    color[0],
                    color[6],
                } : color);

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

            return ImplementColorAtributtes(CreateSolidColorVertices(centerPosition, sideLength, verticesEconomized), color);
        }

        /// <summary>
        /// Cria os índices necessários para desenho dos triângulos que compõe o hexagono
        /// </summary>
        /// <param name="verticesEconomized">Especifíca se o objeto foi construído utilizando o sistema de economia de vértices</param>
        /// <returns>Um array contendo os índices</returns>
        public static uint[] CreateIndices(bool verticesEconomized)
        {
            uint[] indices = new uint[18];

            if (verticesEconomized)
            {
                for (uint i = 0; i < indices.Length; i++)
                {
                    if (i % 3 == 2)
                    {
                        indices[i] = 6;
                    }

                    else if (i % 3 == 1)
                    {
                        indices[i] = (i != indices.Length - 2 ? i / 3 + 1 : 0);
                    }

                    else
                    {
                        indices[i] = i / 3;
                    }
                } 
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
