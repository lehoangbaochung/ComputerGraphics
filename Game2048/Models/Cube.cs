using ComputerGraphics;
using ComputerGraphics.Interfaces;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;

namespace Game2048.Models
{
    class Cube : SharpGL.SceneGraph.Primitives.Cube, IOpenGLLight, IOpenGLMaterial
    {
        /// <summary>
        /// The internal display list
        /// </summary>
        DisplayList displayList;

        public float[] LightPosition { get; set; } = { 0, 0, 1, 0 };
        public float[] Ambient { get; set; } = { 1, 0, 0, 1 };
        public float[] Specular { get; set; } = { 1, 1, 1, 1 };
        public float[] Diffuse { get; set; } = { 1, 1, 1, 1 };
        public float Shininess { get; set; } = 50;

        /// <summary>
        /// The value of cube
        /// </summary>
        public int Value { get; set; } = 2;

        public Cube()
        {

        }

        /// <summary>
        /// Render to the provided instance of OpenGL
        /// </summary>
        /// <param name="gl">The OpenGL instance</param>
        /// <param name="renderMode">The render mode</param>
        public override void Render(OpenGL gl, RenderMode renderMode)
        {
            //  Design time primitives render only in design mode.
            if (renderMode != RenderMode.Design) return;

            //  If we do not have the display list, we must create it.
            //  Otherwise, we can simple call the display list.
            if (displayList == null)
                CreateDisplayList(gl);
            else
                displayList.Call(gl);
        }

        void Transform(float size = 2.5f)
        {
            Transformation.RotateZ = -90;
            Transformation.ScaleX = size;
            Transformation.ScaleY = size;
            Transformation.ScaleZ = size;
            Transformation.TranslateZ = size;
        }

        /// <summary>
        /// Creates the display list. This function draws the
        /// geometry as well as compiling it.
        /// </summary>
        void CreateDisplayList(OpenGL gl)
        {
            //  Create the display list. 
            displayList = new DisplayList();

            //  Generate the display list
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            //  Push attributes, set the color.
            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            Lighting(gl);
            Transform();
            BindTexture(gl);

            gl.Begin(OpenGL.GL_QUADS);
            // Front Face
            gl.TexCoord(0, 0); gl.Vertex(-1, -1, 1); // Bottom Left Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(1, -1, 1);  // Bottom Right Of The Texture and Quad
            gl.TexCoord(1, 1); gl.Vertex(1, 1, 1);   // Top Right Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, 1);  // Top Left Of The Texture and Quad

            // Back Face
            gl.TexCoord(0, 0); gl.Vertex(-1, -1, -1);    // Bottom Right Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(-1, 1, -1); // Top Right Of The Texture and Quad
            gl.TexCoord(1, 1); gl.Vertex(1, 1, -1);  // Top Left Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(1, -1, -1); // Bottom Left Of The Texture and Quad

            // Top Face
            gl.TexCoord(0, 0); gl.Vertex(-1, 1, -1); // Top Left Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(-1, 1, 1);  // Bottom Left Of The Texture and Quad
            gl.TexCoord(1, 1); gl.Vertex(1, 1, 1);   // Bottom Right Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(1, 1, -1);  // Top Right Of The Texture and Quad

            // Bottom Face
            gl.TexCoord(0, 0); gl.Vertex(-1, -1, -1);    // Top Right Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(1, -1, -1); // Top Left Of The Texture and Quad
            gl.TexCoord(0, 0); gl.Vertex(1, -1, 1);  // Bottom Left Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(-1, -1, 1); // Bottom Right Of The Texture and Quad

            // Right face
            gl.TexCoord(0, 0); gl.Vertex(1, -1, -1); // Bottom Right Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(1, 1, -1);  // Top Right Of The Texture and Quad
            gl.TexCoord(1, 1); gl.Vertex(1, 1, 1);   // Top Left Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(1, -1, 1);  // Bottom Left Of The Texture and Quad

            // Left Face
            gl.TexCoord(0, 0); gl.Vertex(-1, -1, -1);    // Bottom Left Of The Texture and Quad
            gl.TexCoord(0, 1); gl.Vertex(-1, -1, 1); // Bottom Right Of The Texture and Quad
            gl.TexCoord(1, 1); gl.Vertex(-1, 1, 1);  // Top Right Of The Texture and Quad
            gl.TexCoord(1, 0); gl.Vertex(-1, 1, -1);	// Top Left Of The Texture and Quad
            gl.End();

            //  Restore attributes
            gl.PopAttrib();

            //  End the display list
            displayList.End(gl);
        }

        /// <summary>
        /// Set lighting
        /// </summary>
        /// <param name="gl">The OpenGL instance</param>
        void Lighting(OpenGL gl)
        {
            OpenGLHelper.EnableLighting(gl);
            OpenGLHelper.SetLighting(gl, LightPosition);
            OpenGLHelper.SetMaterial(gl, Ambient, Diffuse, Specular, Shininess);
        }

        void BindTexture(OpenGL gl)
        {
            switch (Value)
            {
                case 2:
                    OpenGLHelper.BindTexture(gl, Resource.Cube2);
                    break;
                case 4:
                    OpenGLHelper.BindTexture(gl, Resource.Cube4);
                    break;
                case 8:
                    OpenGLHelper.BindTexture(gl, Resource.Cube8);
                    break;
                case 16:
                    OpenGLHelper.BindTexture(gl, Resource.Cube16);
                    break;
                case 32:
                    OpenGLHelper.BindTexture(gl, Resource.Cube32);
                    break;
                case 64:
                    OpenGLHelper.BindTexture(gl, Resource.Cube64);
                    break;
                case 128:
                    OpenGLHelper.BindTexture(gl, Resource.Cube128);
                    break;
                case 256:
                    OpenGLHelper.BindTexture(gl, Resource.Cube256);
                    break;
                case 512:
                    OpenGLHelper.BindTexture(gl, Resource.Cube512);
                    break;
                case 1024:
                    OpenGLHelper.BindTexture(gl, Resource.Cube1024);
                    break;
                case 2048:
                    OpenGLHelper.BindTexture(gl, Resource.Cube2048);
                    break;
            }
        }
    }
}
