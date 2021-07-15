using ComputerGraphics;
using ComputerGraphics.Helpers;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;

namespace LittleBigHouse.Models
{
    class Wall : SceneElement, IRenderable
    {
        DisplayList displayList;

        public void Render(OpenGL gl, RenderMode renderMode)
        {
            if (renderMode != RenderMode.Design) return;

            if (displayList == null)
                CreateDisplayList(gl);
            else
                displayList.Call(gl);
        }

        void CreateDisplayList(OpenGL gl)
        {
            displayList = new DisplayList();
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            Draw(gl);

            gl.PopAttrib();
            displayList.End(gl);
        }

        void Draw(OpenGL gl)
        {
            // tuong phai
            gl.PushMatrix();
            gl.Translate(0, 4, 0);
            OpenGLHelper.BindTexture(gl, Resource.Wall);
            DrawHelper.RenderBox(gl, 10, 1, 5);
            gl.PopMatrix();

            // tuong trai
            gl.PushMatrix();
            gl.Translate(0, -5, 0);
            DrawHelper.RenderBox(gl, 10, 1, 5);
            gl.PopMatrix();

            // tuong truoc 1
            gl.PushMatrix();
            gl.Translate(0, 1, 0);
            DrawHelper.RenderBox(gl, 1, 3, 5);
            gl.PopMatrix();

            // tuong truoc 2
            gl.PushMatrix();
            gl.Translate(0, -4, 0);
            DrawHelper.RenderBox(gl, 1, 3, 5);
            gl.PopMatrix();

            // tuong sau
            gl.PushMatrix();
            gl.Translate(9, -4, 0);
            DrawHelper.RenderBox(gl, 1, 8, 5);
            gl.PopMatrix();

            // mai nha truoc
            gl.PushMatrix();
            gl.Translate(0, -5, 5);
            gl.Rotate(0, 45, 0);
            OpenGLHelper.BindTexture(gl, Resource.mai_nha);
            DrawHelper.RenderBox(gl, 1, 10, 6);
            gl.PopMatrix();

            // mai nha sau
            gl.PushMatrix();
            gl.Translate(9, -5, 5);
            gl.Rotate(0, -45, 0);
            DrawHelper.RenderBox(gl, 1, 10, 6);
            gl.PopMatrix();

            gl.PushMatrix();
            gl.Translate(-15, -15, -1);
            OpenGLHelper.BindTexture(gl, Resource.GreenLeaf);
            OpenGLHelper.DrawBox(gl, 30, 30, 1);
            gl.PopMatrix();

            gl.PushMatrix();
            
            gl.PopMatrix();

        }
    }
}
