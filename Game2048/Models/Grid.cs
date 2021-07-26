using ComputerGraphics.Models;
using SharpGL;

namespace Game2048.Models
{
    /// <summary>
    /// The Grid design time primitive is displays a grid in the scene
    /// </summary>
    class Grid : SceneElement
    {
        protected override void Draw()
        {
            //  Draw the grid lines
            gl.Begin(OpenGL.GL_LINES);
            for (int i = -10; i <= 10; i++)
            {
                // set color
                float fcol = ((i % 10) == 0) ? 0.3f : 0.15f;
                gl.Color(fcol, fcol, fcol);

                // behind face
                gl.Vertex(i, -10, 0);
                gl.Vertex(i, 10, 0);
                gl.Vertex(-10, i, 0);
                gl.Vertex(10, i, 0);

                //// front face
                //gl.Vertex(i, -10, 20);
                //gl.Vertex(i, 10, 20);
                //gl.Vertex(-10, i, 20);
                //gl.Vertex(10, i, 20);

                // left face
                gl.Vertex(-10, -10, i + 10);
                gl.Vertex(-10, 10, i + 10);
                gl.Vertex(-10, i, 0);
                gl.Vertex(-10, i, 20);

                // right face
                gl.Vertex(10, -10, i + 10);
                gl.Vertex(10, 10, i + 10);
                gl.Vertex(10, i, 0);
                gl.Vertex(10, i, 20);

                // top face
                gl.Vertex(-10, 10, i + 10);
                gl.Vertex(10, 10, i + 10);
                gl.Vertex(i, 10, 0);
                gl.Vertex(i, 10, 20);

                // bottom face
                gl.Vertex(-10, -10, i + 10);
                gl.Vertex(10, -10, i + 10);
                gl.Vertex(i, -10, 0);
                gl.Vertex(i, -10, 20);
            }
            gl.End();
        }
    }
}
