using SharpGL;
using SharpGL.SceneGraph.Transformations;
using System;
using System.Drawing;

namespace ComputerGraphics.Models
{
    public class Grid : SceneElement
    {
        public float LineWidth { get; set; } = 1;
        public int MinValue { get; set; } = -10;
        public int MaxValue { get; set; } = 10;
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
            OpenGLHelper.DrawGrid(gl, MinValue, MaxValue);
            gl.PopMatrix();
        }
    }
}
