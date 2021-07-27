using System.Drawing;

namespace ComputerGraphics.Models
{
    class Box : SceneElement
    {
        public float Length { get; set; } = 1;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;
        public Bitmap TextureImage { get; set; }

        protected override void Draw()
        {
            if (TextureImage != null)
            {
                OpenGLHelper.BindTexture(gl, TextureImage);
            }

            OpenGLHelper.DrawBox(gl, Length, Width, Height);
        }
    }
}
