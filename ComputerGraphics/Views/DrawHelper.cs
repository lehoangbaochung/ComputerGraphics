using SharpGL;

namespace ComputerGraphics.Helpers
{
    public class DrawHelper : SharpGL.SceneGraph.Helpers.OpenGLHelper
    {
        public static void RenderBox(OpenGL gl, float x, float y, float z)
        {
            // front
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 0.0f, 1.0f);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(0, y, z);
            gl.TexCoord(1, 1); gl.Vertex(x, y, z);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, z);
            gl.End();

            // behind
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 0.0f, -1.0f);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, 0);
            gl.TexCoord(0, 1); gl.Vertex(0, y, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(-1.0f, 0.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(0, 1); gl.Vertex(0, 0, z);
            gl.TexCoord(1, 1); gl.Vertex(0, y, z);
            gl.TexCoord(1, 0); gl.Vertex(0, y, 0);
            gl.End();

            // right
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(1.0f, 0.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(x, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, y, z);
            gl.End();

            // top
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, 1.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(0, y, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, y, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, z);
            gl.TexCoord(0, 1); gl.Vertex(0, y, z);
            gl.End();

            // bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0f, -1.0f, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(0, 0, z);
            gl.End();
        }
    }
}
