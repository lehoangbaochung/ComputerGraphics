using ComputerGraphics;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models.Inside
{
    class Armoire : SceneElement
    {
        public float Length { get; set; } = 30;
        public float Width { get; set; } = 5;
        public float Height { get; set; } = 5;
        public Bitmap TextureImage { get; set; } = Resource.OrangeRed;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, TextureImage);

            // screen
            gl.PushMatrix();
            gl.Rotate(-90, 0, 0, 1);
            gl.Translate(5, 42, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
