using ComputerGraphics;
using ComputerGraphics.Views.Controls;

namespace Game2048.Views.Controls
{
    class CameraControl : OpenGLControl
    {
        protected override void Render()
        {
            OpenGL.LookAt(0, 0, 40, 0, 0, 0, 0, 5, 0);
            OpenGLHelper.DrawGrid(OpenGL, -10, 10);
            OpenGLHelper.DrawCube(OpenGL, 2.5f);
            OpenGL.Flush();
        }
    }
}
