using ComputerGraphics;
using ComputerGraphics.Interfaces;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models
{
    class Wall : SceneElement, IElementProperty
    {
        public float Length { get; set; } = 100;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 10;
        public Bitmap TextureImage { get; set; } = Resource.Wall;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, TextureImage);

            #region House
            // left
            gl.PushMatrix();
            gl.Translate(-50, 50, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind
            gl.PushMatrix();
            gl.Rotate(90, 0, 0, 1);
            gl.Translate(-50, -51, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // right
            gl.PushMatrix();
            gl.Translate(-50, -51, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
            #endregion

            #region Bedroom
            // right
            gl.PushMatrix();
            gl.Translate(25, 0, 0);
            OpenGLHelper.DrawBox(gl, Length / 4, Width, Height);
            gl.PopMatrix();

            // front
            gl.PushMatrix();
            gl.Rotate(90, 0, 0, 1);
            gl.Translate(0, -25, 0);
            OpenGLHelper.DrawBox(gl, Length / 2, Width, Height);
            gl.PopMatrix();
            #endregion
        }
    }
}
