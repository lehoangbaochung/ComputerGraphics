using ComputerGraphics;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models
{
    class Column : SceneElement
    {
        public float Length { get; set; } = 1;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 20;
        public Bitmap TextureImage { get; set; } = Resource.Orange;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, TextureImage);

            // center
            gl.PushMatrix();
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind-left
            gl.PushMatrix();
            gl.Translate(50, 50, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind-right
            gl.PushMatrix();
            gl.Translate(50, -51, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // top-left
            gl.PushMatrix();
            gl.Translate(-51, 50, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // top-right
            gl.PushMatrix();
            gl.Translate(-51, -51, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
