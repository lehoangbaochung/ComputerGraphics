﻿using ComputerGraphics;
using ComputerGraphics.Views.Controls;

namespace LittleBigHouse.Views.Controls
{
    class MainControl : BaseOpenGLControl
    {
        public float Length { get; set; } = 1;
        public float Width1 { get; set; } = 1;
        public float Height1 { get; set; } = 10;

        protected override void Render()
        {
            var gl = OpenGL;

            // center
            gl.PushMatrix();
            OpenGLHelper.DrawBox(gl, Length, Width1, Height1);
            gl.PopMatrix();

            // behind-left
            gl.PushMatrix();
            gl.Translate(20, 20, 0);
            OpenGLHelper.DrawBox(gl, Length, Width1, Height1);
            gl.PopMatrix();

            // behind-right
            gl.PushMatrix();
            gl.Translate(20, -21, 0);
            OpenGLHelper.DrawBox(gl, Length, Width1, Height1);
            gl.PopMatrix();

            // top-left
            gl.PushMatrix();
            gl.Translate(-21, 20, 0);
            OpenGLHelper.DrawBox(gl, Length, Width1, Height1);
            gl.PopMatrix();

            // top-right
            gl.PushMatrix();
            gl.Translate(-21, -21, 0);
            OpenGLHelper.DrawBox(gl, Length, Width1, Height1);
            gl.PopMatrix();
        }
    }
}
