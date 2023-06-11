using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace Opengl_Playground.Objects
{
    /// <summary>
    /// Classe mãe de todos os objetos pré definidos neste projeto, contém todos os atributos e métodos necessários para desenho de tais objetos
    /// </summary>
    public abstract class RenderObject
    {
        public enum ObjectType { ColorObject, SolidColorObject, TextureObject }

        public RenderObject(float[] vertices, string vertexPath, string fragPath)
        {
            SetVertices(vertices);
            SetShader(vertexPath, fragPath);
            Model = Matrix4.Identity;
        }

        #region Atributos

        /// <summary>
        /// Especifica o tipo do objeto
        /// </summary>
        protected ObjectType Type;

        /// <summary>
        /// Guarda o id do objeto vertex array buffer
        /// </summary>
        public int VertexBufferObject { get; protected set; }

        /// <summary>
        /// Guarda o id do objeto vertex array object
        /// </summary>
        public int VertexArrayObject { get; protected set; }

        /// <summary>
        /// Guarda o id do objeto element array object
        /// </summary>
        public int ElementBufferObject { get; protected set; }

        /// <summary>
        /// Guarda os vértices do objeto atual
        /// </summary>
        public float[] Vertices { get; private set; }

        /// <summary>
        /// Guarda os indíces de vértices do objeto atual
        /// </summary>
        public uint[] Indices { get; private set; }

        /// <summary>
        /// Guarda o shader necessário para desenho do objeto
        /// </summary>
        public Shader Shader { get; private set; }

        /// <summary>
        /// Guarda a textura do objeto
        /// </summary>
        public Texture Texture { get; private set; }

        /// <summary>
        /// Guarda a cor do objeto atual
        /// </summary>
        public Vector4 Color { get; private set; }

        /// <summary>
        /// Guarda a matrix de transformação geral do objeto
        /// </summary>
        public Matrix4 Transform { get; private set; }

        /// <summary>
        /// Guarda a matrix de transformação do nível model do objeto atual
        /// </summary>
        public Matrix4 Model { get; private set; }

        #endregion

        #region Métodos Acessores

        public void SetShader(string newVertexPath, string newFragPath)
        {
            this.Shader = new Shader(newVertexPath, newFragPath);
        }

        public void SetTexture(string path)
        {
            Texture = Texture.LoadFromFile(path);
            Texture.Use(TextureUnit.Texture0);
            Shader.SetInt("texture0", 0);
        }

        public void SetVertices(float[] vertices)
        {
            this.Vertices = vertices;
        }

        public void SetIndices(uint[] indices)
        {
            this.Indices = indices;
        }

        public void SetColor(Vector4 color)
        {
            Color = color;
        }

        public void SetTransform(Matrix4 view, Matrix4 projection)
        {
            Transform = Model * view * projection;
        }

        public void SetModel(Matrix4 model)
        {
            Model *= model;
        }

        public void ResetModel()
        {
            Model = Matrix4.Identity;
        }

        #endregion

        #region Métodos de criação de Matrix4

        public static Matrix4 CreateRotationZ(float degreesAngle)
        {
            return Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(degreesAngle));
        }

        public static Matrix4 CreateRotationY(float degreesAngle)
        {
            return Matrix4.CreateRotationY(MathHelper.DegreesToRadians(degreesAngle));
        }

        public static Matrix4 CreateRotationX(float degreesAngle)
        {
            return Matrix4.CreateRotationX(MathHelper.DegreesToRadians(degreesAngle));
        }

        public static Matrix4 CreateTranslation(float x, float y, float z)
        {
            return Matrix4.CreateTranslation(x, y, z);
        }

        public static Matrix4 CreateScale(float scale)
        {
            return Matrix4.CreateScale(scale);
        }

        public static Matrix4 CombineMatrix(Matrix4 matrix1, Matrix4 matrix2)
        {
            return matrix1 * matrix2;
        }

        #endregion

        #region Métodos de manipulação do Shader

        protected void AplicateColor()
        {
            Shader.SetVector4("backColor", Color);
        }

        protected void AplicateTransform()
        {
            Shader.SetMatrix4("transform", Transform);
        }

        #endregion

        #region Métodos abstratos

        /// <summary>
        /// Desenha o objeto atual
        /// </summary>
        public abstract void DrawObject();

        /// <summary>
        /// Inicializa os objetos Opengl necessários para desenhar o objeto
        /// </summary>
        protected abstract void InitializeOpenglObjects();

        #endregion
    }
}
