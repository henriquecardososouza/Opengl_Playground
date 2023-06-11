using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Opengl_Playground.Shaders;

namespace Opengl_Playground.Objects
{
    public class Cubo : RenderObject
    {
        public Cubo(float[] vertices, Vector4 color, Matrix4? transformation) : base(vertices, ShaderPaths.SolidColorVertexShaderPath, ShaderPaths.SolidColorFragShaderPath)
        {
            Type = ObjectType.SolidColorObject;

            SetColor(color);

            SetModel(transformation ?? Matrix4.Identity);

            SetIndices(CreateIndices(true));

            InitializeOpenglObjects();
        }

        public Cubo(float[] vertices, string texturePath, Matrix4? transformation) : base(vertices, ShaderPaths.TextureVertexShaderPath, ShaderPaths.TextureFragShaderPath)
        {
            Type = ObjectType.TextureObject;

            SetTexture(texturePath);

            SetModel(transformation ?? Matrix4.Identity);

            SetIndices(CreateIndices(vertices.Length != 180));

            InitializeOpenglObjects();
        }

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

        override protected void InitializeOpenglObjects()
        {
            VertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * this.Vertices.Length, this.Vertices, BufferUsageHint.StaticDraw);

            VertexArrayObject = GL.GenVertexArray();
            ElementBufferObject = GL.GenBuffer();

            if (Type == ObjectType.SolidColorObject)
            {
                InitializeColorVertexArray();
            }

            else
            {
                InitializeTextureVertexArray();
            }
        }

        private void InitializeColorVertexArray()
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

        public static float[] CreateSolidColorVertices(Vector3 centerPosition, float sideLength)
        {
            var vertices = new float[24];
            var timesCalled = new int[] { 0, 0, 0 };
            var operators = new string[] { "+", "-", "-" };

            for (int i = 0; i < vertices.Length; i++)
            {
                if (i % 3 == 0)
                {
                    //Coordenada x do vértice

                    if (timesCalled[0] % 2 == 0)
                    {
                        if (operators[0].Equals("+"))
                        {
                            operators[0] = "-";
                        }

                        else
                        {
                            operators[0] = "+";
                        }
                    }

                    if (operators[0].Equals("+"))
                    {
                        vertices[i] = centerPosition.X + sideLength / 2;
                    }

                    else
                    {
                        vertices[i] = centerPosition.X - sideLength / 2;
                    }

                    timesCalled[0]++;
                }

                else if (i % 3 == 1)
                {
                    //Coordenada y do vértice

                    if (timesCalled[1] % 1 == 0)
                    {
                        if (operators[1].Equals("+"))
                        {
                            operators[1] = "-";
                        }

                        else
                        {
                            operators[1] = "+";
                        }
                    }

                    if (operators[1].Equals("+"))
                    {
                        vertices[i] = centerPosition.Y + sideLength / 2;
                    }

                    else
                    {
                        vertices[i] = centerPosition.Y - sideLength / 2;
                    }

                    timesCalled[1]++;
                }

                else
                {
                    //Coordenada z do vértice

                    if (timesCalled[2] % 4 == 0)
                    {
                        if (operators[2].Equals("+"))
                        {
                            operators[2] = "-";
                        }

                        else
                        {
                            operators[2] = "+";
                        }
                    }

                    if (operators[2].Equals("+"))
                    {
                        vertices[i] = centerPosition.Z + sideLength / 2;
                    }

                    else
                    {
                        vertices[i] = centerPosition.Z - sideLength / 2;
                    }

                    timesCalled[2]++;
                }
            }

            return vertices;
        }

        public static float[] CreateColorVertices(float centerPosition, float sideLength)
        {
            var vertices = new float[48];

            return vertices;
        }

        /// <summary>
        /// Cria um array contendo os vértices e o mapeamento de textura necessário para rendenização de um cubo
        /// </summary>
        /// <param name="centerPosition">A coordenada central do cubo</param>
        /// <param name="sideLength">O comprimento da lateral do cubo</param>
        /// <param name="verticesEconomized">Especifica se o cubo será construído com método de economia de vétices (não recomendado)</param>
        /// <returns>Um array contendo os vértices do cubo e suas respectivas coordenadas de textura</returns>
        public static float[] CreateTextureVertices(Vector3 centerPosition, float sideLength, bool verticesEconomized)
        {
            float[] vertices;

            if (verticesEconomized)
            {
                vertices = new float[40];
                var counter = new int[] { 0, 0, 0 };

                for (int i = 0; i < 8; i++)
                {
                    //Montando as coordenadas de posição do objeto

                    for (int j = 0; j < 3; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                if (counter[0] < 2)
                                {
                                    vertices[i * 5] = centerPosition.X - sideLength / 2;
                                }

                                else
                                {
                                    vertices[i * 5] = centerPosition.X + sideLength / 2;

                                    if (counter[0] >= 3)
                                    {
                                        counter[0] = -1;
                                    }
                                }

                                break;

                            case 1:
                                if (counter[1] < 1)
                                {
                                    vertices[i * 5 + 1] = centerPosition.Y - sideLength / 2;
                                }

                                else
                                {
                                    vertices[i * 5 + 1] = centerPosition.Y + sideLength / 2;

                                    if (counter[1] >= 1)
                                    {
                                        counter[1] = -1;
                                    }
                                }

                                break;

                            case 2:
                                if (counter[2] < 4)
                                {
                                    vertices[i * 5 + 2] = centerPosition.Z - sideLength / 2;
                                }

                                else
                                {
                                    vertices[i * 5 + 2] = centerPosition.Z + sideLength / 2;

                                    if (counter[2] >= 7)
                                    {
                                        counter[2] = -1;
                                    }
                                }

                                break;
                        }
                    }

                    //Montando as coordenadas de textura

                    switch (i)
                    {
                        case 0:
                            vertices[i * 5 + 3] = 0f;
                            vertices[i * 5 + 4] = 1f;
                            break;

                        case 1:
                            vertices[i * 5 + 3] = 0f;
                            vertices[i * 5 + 4] = 0f;
                            break;

                        case 2:
                            vertices[i * 5 + 3] = 1f;
                            vertices[i * 5 + 4] = 1f;
                            break;

                        case 3:
                            vertices[i * 5 + 3] = 1f;
                            vertices[i * 5 + 4] = 0f;
                            break;

                        case 4:
                            vertices[i * 5 + 3] = 1f;
                            vertices[i * 5 + 4] = 0f;
                            break;

                        case 5:
                            vertices[i * 5 + 3] = 1f;
                            vertices[i * 5 + 4] = 1f;
                            break;

                        case 6:
                            vertices[i * 5 + 3] = 0f;
                            vertices[i * 5 + 4] = 0f;
                            break;

                        case 7:
                            vertices[i * 5 + 3] = 0f;
                            vertices[i * 5 + 4] = 1f;
                            break;
                    }

                    counter[0]++;
                    counter[1]++;
                    counter[2]++;
                }
            }

            else
            {
                vertices = new float[180];

                int[] counter;

                for (int i = 0; i < 2; i++)
                {
                    counter = new int[] { 2, 1, 2, 1 };

                    for (int j = 0; j < vertices.Length / 6; j++)
                    {
                        if (j % 5 == 0)
                        {
                            if (counter[0] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.X - sideLength / 2;
                            }
                            
                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.X + sideLength / 2;

                                if (counter[0] >= 5)
                                {
                                    counter[0] = -1;
                                }
                            }

                            counter[0]++;
                        }

                        if (j % 5 == 1)
                        {
                            if (counter[1] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.Y - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.Y + sideLength / 2;

                                if (counter[1] >= 5)
                                {
                                    counter[1] = -1;
                                }
                            }

                            counter[1]++;
                        }

                        if (j % 5 == 2)
                        {
                            if (i == 0)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.Z - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = centerPosition.Z + sideLength / 2;
                            }
                        }

                        if (j % 5 == 3)
                        {
                            if (counter[2] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = 1f;

                                if (counter[2] >= 5)
                                {
                                    counter[2] = -1;
                                }
                            }

                            counter[2]++;
                        }

                        if (j % 5 == 4)
                        {
                            if (counter[3] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 3 : 0)] = 1f;

                                if (counter[3] >= 5)
                                {
                                    counter[3] = -1;
                                }
                            }

                            counter[3]++;
                        }
                    }

                    counter = new int[] { 4, 5, 4, 2 };

                    for (int j = 0; j < vertices.Length / 6; j++)
                    {
                        if (j % 5 == 0)
                        {
                            if (i == 0)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.X - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.X + sideLength / 2;
                            }
                        }

                        if (j % 5 == 1)
                        {
                            if (counter[0] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.Y - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.Y + sideLength / 2;

                                if (counter[0] >= 5)
                                {
                                    counter[0] = -1;
                                }
                            }

                            counter[0]++;
                        }

                        if (j % 5 == 2)
                        {
                            if (counter[1] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.Z - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = centerPosition.Z + sideLength / 2;

                                if (counter[1] >= 5)
                                {
                                    counter[1] = -1;
                                }
                            }

                            counter[1]++;
                        }

                        if (j % 5 == 3)
                        {
                            if (counter[2] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = 1f;

                                if (counter[2] >= 5)
                                {
                                    counter[2] = -1;
                                }
                            }

                            counter[2]++;
                        }

                        if (j % 5 == 4)
                        {
                            if (counter[3] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 4 : vertices.Length / 6)] = 1f;

                                if (counter[3] >= 5)
                                {
                                    counter[3] = -1;
                                }
                            }

                            counter[3]++;
                        }
                    }

                    counter = new int[] { 2, 1, 2, 4 };

                    for (int j = 0; j < vertices.Length / 6; j++)
                    {
                        if (j % 5 == 0)
                        {
                            if (counter[0] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.X - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.X + sideLength / 2;

                                if (counter[0] >= 5)
                                {
                                    counter[0] = -1;
                                }
                            }

                            counter[0]++;
                        }

                        if (j % 5 == 1)
                        {
                            if (i == 0)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.Y - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.Y + sideLength / 2;
                            }
                        }

                        if (j % 5 == 2)
                        {
                            if (counter[1] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.Z - sideLength / 2;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = centerPosition.Z + sideLength / 2;

                                if (counter[1] >= 5)
                                {
                                    counter[1] = -1;
                                }
                            }

                            counter[1]++;
                        }

                        if (j % 5 == 3)
                        {
                            if (counter[2] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = 1f;

                                if (counter[2] >= 5)
                                {
                                    counter[2] = -1;
                                }
                            }

                            counter[2]++;
                        }

                        if (j % 5 == 4)
                        {
                            if (counter[3] < 3)
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = 0f;
                            }

                            else
                            {
                                vertices[j + (i == 1 ? vertices.Length / 6 * 5 : vertices.Length / 6 * 2)] = 1f;

                                if (counter[3] >= 5)
                                {
                                    counter[3] = -1;
                                }
                            }

                            counter[3]++;
                        }
                    }
                }
            }

            return vertices;
        }

        /// <summary>
        /// Cria um array de índices para desenho do cubo
        /// </summary>
        /// <param name="verticesEconomized">Especifica se o cubo foi criado utilizando método de economia de vértices</param>
        /// <returns>Um array contendo os índices necessários para desenho do cubo</returns>
        public static uint[] CreateIndices(bool verticesEconomized)
        {
            uint[] indices;

            if (verticesEconomized)
            {
                indices = new uint[] {
                    //frente
                    0, 1, 2,
                    1, 2, 3,

                    //fundo
                    4, 5, 6,
                    5, 6, 7,

                    //baixo
                    7, 3, 5,
                    5, 3, 1,

                    //cima
                    0, 2, 4,
                    2, 4, 6,

                    //direita
                    2, 3, 6,
                    3, 6, 7,

                    //esquerda
                    1, 0, 5,
                    0, 5, 4
                };
            }

            else
            {
                indices = new uint[36];

                for (uint i = 0; i < indices.Length; i++)
                {
                    indices[i] = i;
                }
            }

            return indices;
        }
    }
}
