using ComputerGraphics;
using ComputerGraphics.Interfaces;
using ComputerGraphics.Models;

namespace LittleBigHouse.Models
{
    class Column : BaseSceneElement, IElementProperty
    {
        public float Length { get; set; } = 1;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 10;

        protected override void Draw()
        {
            //OpenGLHelper.BindTexture(gl, Resource.phong_nen_cam);

            // center
            gl.PushMatrix();
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind-left
            gl.PushMatrix();
            gl.Translate(20, 20, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // behind-right
            gl.PushMatrix();
            gl.Translate(20, -21, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // top-left
            gl.PushMatrix();
            gl.Translate(-21, 20, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();

            // top-right
            gl.PushMatrix();
            gl.Translate(-21, -21, 0);
            OpenGLHelper.DrawBox(gl, Length, Width, Height);
            gl.PopMatrix();
        }
    }
}
