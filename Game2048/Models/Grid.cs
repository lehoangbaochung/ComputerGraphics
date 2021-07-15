using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;
namespace Game2048.Models
{
    /// <summary>
    /// The Grid design time primitive is displays a grid in the scene.
    /// </summary>
    class Grid : SceneElement, IRenderable
    {
        /// <summary>
        /// The internal display list
        /// </summary>
        DisplayList displayList;

        /// <summary>
        /// Render to the provided instance of OpenGL.
        /// </summary>
        /// <param name="gl">The OpenGL instance.</param>
        /// <param name="renderMode">The render mode.</param>
        public void Render(OpenGL gl, RenderMode renderMode)
        {
            //  Design time primitives render only in design mode.
            if (renderMode != RenderMode.Design)
                return;

            //  If we do not have the display list, we must create it.
            //  Otherwise, we can simple call the display list.
            if (displayList == null)
                CreateDisplayList(gl);
            else
                displayList.Call(gl);
        }

        /// <summary>
        /// Creates the display list.
        /// This function draws the geometry as well as compiling it.
        /// </summary>
        void CreateDisplayList(OpenGL gl)
        {
            //  Create the display list
            displayList = new DisplayList();

            //  Generate the display list
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            //  Push attributes, set the color
            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.LineWidth(1.0f);

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

            //  Restore attributes
            gl.PopAttrib();

            //  End the display list
            displayList.End(gl);
        }
    }
}
