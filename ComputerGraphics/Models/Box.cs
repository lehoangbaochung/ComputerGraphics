﻿using SharpGL.SceneGraph.Transformations;
using System.Drawing;

namespace ComputerGraphics.Models
{
    public class Box : SceneElement
    {
        public float Length { get; set; } = 2;
        public float Width { get; set; } = 2;
        public float Height { get; set; } = 1;
        public Bitmap TextureImage { get; set; }
        public LinearTransformation Transformation { get; set; } 

        protected override void Draw()
        {
            if (TextureImage != null)
            {
                OpenGLHelper.BindTexture(gl, TextureImage);
            }

            gl.PopMatrix();
            gl.Translate(1, 1, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PushMatrix();
        }
    }
}
