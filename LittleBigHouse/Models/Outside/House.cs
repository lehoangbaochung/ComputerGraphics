using ComputerGraphics;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models.Outside
{
    class House : SceneElement
    {
        public float Length { get; set; } = 40;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 10;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, Resource.Wall);

            // left
            gl.PushMatrix();
            gl.Translate(-20, 20, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind
            gl.PushMatrix();
            gl.Rotate(90, 0, 0, 1);
            gl.Translate(-20, -21, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // right-1
            gl.PushMatrix();
            gl.Translate(-20, -21, 0);
            OpenGLHelper.DrawBox(gl, Length / 2, Width, Height);
            gl.PopMatrix();

            // right-2
            gl.PushMatrix();
            gl.Translate(6, -21, 0);
            OpenGLHelper.DrawBox(gl, 14, Width, Height);
            gl.PopMatrix();
        }
    }
}
