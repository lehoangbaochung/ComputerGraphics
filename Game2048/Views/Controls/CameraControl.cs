using ComputerGraphics;
using ComputerGraphics.Interfaces;
using SharpGL;
using System;
using System.Windows.Forms;

namespace Game2048.Views.Controls
{
    class CameraControl : OpenGLControl, IOpenGLEvent
    {
        readonly OpenGL gl;

        public CameraControl()
        {
            gl = OpenGL;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            OpenGLDraw += Draw;
            OpenGLInitialized += Initialized;
        }

        public void Initialized(object sender, EventArgs e)
        {
            OpenGLHelper.EnableLighting(gl);
        }

        public void Draw(object sender, RenderEventArgs args)
        {
            OpenGLHelper.SetBackgroundColor(gl, ConsoleColor.White);

            gl.LoadIdentity();
            gl.LookAt(0, 0, 40, 0, 0, 0, 0, 5, 0);

            OpenGLHelper.DrawGrid(gl, -10, 10);
            OpenGLHelper.DrawCube(gl, 2.5f);

            gl.Flush();
        }
    }
}
