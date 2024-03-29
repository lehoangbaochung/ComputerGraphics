﻿using SharpGL.SceneGraph.Transformations;
using System.Drawing;

namespace ComputerGraphics.Models
{
    public class Box : SceneElement
    {
        public float Length { get; set; } = 0;
        public float Width { get; set; } = 0;
        public float Height { get; set; } = 0;
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
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
