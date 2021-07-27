using ComputerGraphics;
using ComputerGraphics.Models;
using System.Drawing;

namespace LittleBigHouse.Models.Outside
{
    class House : SceneElement
    {
        public float Length { get; set; } = 100;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 10;
        public Bitmap TextureImage { get; set; } = Resource.Wall;

        protected override void Draw()
        {
            gl.PushMatrix();
            gl.Translate(-50, 50, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
