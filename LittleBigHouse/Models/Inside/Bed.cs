using ComputerGraphics;
using ComputerGraphics.Models;
using SharpGL.SceneGraph;
using System.Drawing;

namespace LittleBigHouse.Models.Inside
{
    class Bed : SceneElement
    {
        public float FootLength { get; set; } = 2;
        public Vertex TopLeft { get; set; } = new(1, 1, 0);
        public Bitmap TextureImage { get; set; } = Resource.phong_nen_cam;

        protected override void Draw()
        {
            OpenGLHelper.BindTexture(gl, TextureImage);

            #region feet
            // top-left
            gl.PushMatrix();
            gl.Translate(30, 46, 0);
            OpenGLHelper.DrawBox(gl, 2, 2, 2);
            gl.PopMatrix();

            // top-right
            gl.PushMatrix();
            gl.Translate(44, 46, 0);
            OpenGLHelper.DrawBox(gl, 2, 2, 2);
            gl.PopMatrix();

            // bottom-left
            gl.PushMatrix();
            gl.Translate(30, 20, 0);
            OpenGLHelper.DrawBox(gl, 2, 2, 2);
            gl.PopMatrix();

            // bottom-right
            gl.PushMatrix();
            gl.Translate(44, 20, 0);
            OpenGLHelper.DrawBox(gl, 2, 2, 2);
            gl.PopMatrix();
            #endregion
        }
    }
}
