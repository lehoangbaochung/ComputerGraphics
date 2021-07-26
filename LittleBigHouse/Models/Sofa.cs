using ComputerGraphics;
using ComputerGraphics.Models;

namespace LittleBigHouse.Models
{
    class Sofa : SceneElement
    {
        protected override void Draw()
        {
            // ground
            gl.PushMatrix();
            gl.Translate(-15, -18, 2);
            OpenGLHelper.BindTexture(gl, Resource.phong_nen_cam);
            OpenGLHelper.DrawBox(gl, 15, 5, 1);
            gl.PopMatrix();

            // back
            gl.PushMatrix();
            gl.Translate(-15, -17, 3);
            gl.Rotate(90, 1, 0, 0);
            OpenGLHelper.DrawBox(gl, 15, 5, 1);
            gl.PopMatrix();

            // left-hand
            gl.PushMatrix();
            gl.Translate(-15, -17, 3);
            OpenGLHelper.DrawBox(gl, 1, 4, 1);
            OpenGLHelper.BindTexture(gl, Resource.pphong_nen_nau_do);
            gl.PopMatrix();

            // right-hand
            gl.PushMatrix();
            gl.Translate(-1, -17, 3);
            OpenGLHelper.DrawBox(gl, 1, 4, 1);
            OpenGLHelper.BindTexture(gl, Resource.GreenLeaf);
            gl.PopMatrix();

            // top-left foot
            gl.PushMatrix();
            gl.Translate(-15, -14, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // top-right foot
            gl.PushMatrix();
            gl.Translate(-1, -14, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // bottom-left foot
            gl.PushMatrix();
            gl.Translate(-15, -18, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            // bottom-right foot
            gl.PushMatrix();
            gl.Translate(-1, -18, 0);
            OpenGLHelper.DrawBox(gl, 1, 1, 2);
            gl.PopMatrix();

            
        }
    }
}
