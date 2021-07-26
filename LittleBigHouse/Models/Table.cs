using ComputerGraphics;
using ComputerGraphics.Models;

namespace LittleBigHouse.Models
{
    class Table : SceneElement
    {
        protected override void Draw()
        {
            // ground
            gl.PushMatrix();
            gl.Translate(-15, -10, 2);
            OpenGLHelper.BindTexture(gl, Resource.phong_nen_cam);
            OpenGLHelper.DrawBox(gl, 15, 5, 1);
            gl.PopMatrix();

            // top-left foot
            gl.PushMatrix();
            gl.Translate(-15, -6, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // top-right foot
            gl.PushMatrix();
            gl.Translate(-1, -6, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // bottom-left foot
            gl.PushMatrix();
            gl.Translate(-15, -10, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // bottom-right foot
            gl.PushMatrix();
            gl.Translate(-1, -10, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();
        }
    }
}
