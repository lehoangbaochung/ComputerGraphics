using ComputerGraphics.Interfaces;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;

namespace ComputerGraphics.Models
{
    /// <summary>
    /// The base class for all elements in a scene
    /// </summary>
    public class SceneElement : SharpGL.SceneGraph.Core.SceneElement, IRenderable, IOpenGLLight, IOpenGLMaterial
    {
        protected OpenGL gl;
        protected DisplayList displayList;

        public float[] LightPosition { get; set; } = { 0, 0, 1, 0 };
        public float[] Ambient { get; set; } = { 1, 0, 0, 1 };
        public float[] Specular { get; set; } = { 1, 1, 1, 1 };
        public float[] Diffuse { get; set; } = { 1, 1, 1, 1 };
        public float Shininess { get; set; } = 50;
        public bool EnableLighting { get; set; } = false;

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

            if (EnableLighting)
            {
                OpenGLHelper.EnableLighting(gl);

                gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, LightPosition);
                gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, Ambient);
                gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, Diffuse);
                gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, Specular);
                gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, Shininess);
            }   
            else
            {
                OpenGLHelper.DisableLighting(gl);
            }    

            Draw();

            gl.PopAttrib();
            displayList.End(gl);
        }

        protected virtual void Draw() { }
    }
}
