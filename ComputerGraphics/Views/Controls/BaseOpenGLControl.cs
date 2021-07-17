using ComputerGraphics.Interfaces;
using SharpGL;
using System;
using System.Windows.Forms;

namespace ComputerGraphics.Views.Controls
{
    public class BaseOpenGLControl : OpenGLControl, IOpenGLEvent, IOpenGLLight, IOpenGLMaterial
    {
        public float[] LightPosition { get; set; } = { 0, 0, 1, 0 };
        public float[] Ambient { get; set; } = { 1, 0, 0, 1 };
        public float[] Specular { get; set; } = { 1, 1, 1, 1 };
        public float[] Diffuse { get; set; } = { 1, 1, 1, 1 };
        public float Shininess { get; set; } = 50;

        public BaseOpenGLControl()
        {
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            OpenGLDraw += Draw; 
            OpenGLInitialized += Initialized;
        }

        public virtual void Initialized(object sender, EventArgs e)
        {
            OpenGLHelper.EnableLighting(OpenGL);
            OpenGLHelper.SetLighting(OpenGL, LightPosition);
            OpenGLHelper.SetMaterial(OpenGL, Ambient, Diffuse, Specular, Shininess);
        }

        public virtual void Draw(object sender, RenderEventArgs args)
        {
            OpenGLHelper.SetBackgroundColor(OpenGL, ConsoleColor.White);

            OpenGL.LoadIdentity();
            OpenGL.LookAt(10.0, 10.0, 15.0, 0.0, 0.0, 0.0, 0.0, 5.0, 0.0);

            Render();

            OpenGL.End();
            OpenGL.Flush();
        }

        protected virtual void Render() { }
    }
}
