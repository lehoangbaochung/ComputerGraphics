using ComputerGraphics;
using ComputerGraphics.Views.Controls;
using LittleBigHouse.Models;

namespace LittleBigHouse.Views.Controls
{
    class MainControl : OpenGLControl
    {
        protected override void Render()
        {
            OpenGL.LookAt(0, 0, 80, 0, 0, 0, 0, 20, 0);
        }
    }
}
