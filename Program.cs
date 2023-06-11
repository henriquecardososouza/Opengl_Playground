using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace Opengl_Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _window = new Window(new GameWindowSettings(), new NativeWindowSettings()
            {
                Title = "Simple Game",
                Size = new Vector2i(600, 600)
            });

            _window.RenderFrequency = 60;
            _window.CenterWindow();
            _window.Run();
        }
    }
}