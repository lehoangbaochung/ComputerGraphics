using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;

namespace ComputerGraphics.Models
{
    /// <summary>
    /// The base class for all elements in a scene
    /// </summary>
    public class SceneElement : SharpGL.SceneGraph.Core.SceneElement, IRenderable
    {
        protected OpenGL gl;
        protected DisplayList displayList;

        public void Render(OpenGL gl, RenderMode renderMode)
        {
            this.gl = gl;

            if (renderMode == RenderMode.Design)
            {
                if (displayList == null)
                    CreateDisplayList();
                else
                    displayList.Call(gl);
            }
        }

        void CreateDisplayList()
        {
            displayList = new DisplayList();
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            Draw();

            gl.PopAttrib();
            displayList.End(gl);
        }

        protected virtual void Draw() { }
    }
}
