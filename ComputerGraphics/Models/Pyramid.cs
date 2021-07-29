using SharpGL.SceneGraph.Transformations;
using System.Drawing;

namespace ComputerGraphics.Models
{
    public class Pyramid : SceneElement
    {
        public float Size { get; set; } = 1;
        public float Height { get; set; } = 2;
        public Bitmap TextureImage { get; set; }
        public LinearTransformation Transformation { get; set; } = new();

        protected override void Draw()
        {
            if (TextureImage != null)
            {
                OpenGLHelper.BindTexture(gl, TextureImage);
            }

            gl.PushMatrix();
            Transformation.Transform(gl);
            OpenGLHelper.DrawPyramid(gl, Size, Height);
            gl.PopMatrix();
        }
    }
}
