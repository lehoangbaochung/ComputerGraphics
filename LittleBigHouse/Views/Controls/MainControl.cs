using ComputerGraphics;
using ComputerGraphics.Helpers;
using ComputerGraphics.Interfaces;
using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Windows.Forms;

namespace LittleBigHouse.Views.Controls
{
    class MainControl : OpenGLControl, IOpenGLEvent
    {

        DisplayList displayList;

        public MainControl()
        {
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            OpenGLInitialized += Initialized;
            OpenGLDraw += Draw;
        }

        public void Initialized(object sender, EventArgs e)
        {
            if (displayList == null)
                CreateDisplayList(OpenGL);
            else
                displayList.Call(OpenGL);
        }

        public void Draw(object sender, RenderEventArgs e)
        {
            OpenGL.LoadIdentity();
            OpenGL.LookAt(20.0, 20.0, 50.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            OpenGLHelper.SetBackgroundColor(OpenGL, ConsoleColor.White);
        }

        void CreateDisplayList(OpenGL gl)
        {
            displayList = new DisplayList();
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);


            gl.PopAttrib();
            displayList.End(gl);
        }
    }
}
