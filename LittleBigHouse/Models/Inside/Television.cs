using ComputerGraphics;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models.Inside
{
    class Television : SceneElement
    {
        public float Length { get; set; } = 5;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 3;
        public Bitmap TextureImage { get; set; } = Resource.Orange;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, TextureImage);

            // screen
            gl.PushMatrix();
            gl.Scale(5, 0, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
