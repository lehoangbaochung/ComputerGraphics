using ComputerGraphics;
using ComputerGraphics.Interfaces;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;

namespace LittleBigHouse.Models
{
    class Tree : SharpGL.SceneGraph.Quadrics.Cylinder, IOpenGLLight, IOpenGLMaterial
    {
        DisplayList displayList;

        public float[] LightPosition { get; set; } = { 0.0f, 0.0f, 1.0f, 0.0f };
        public float[] Ambient { get; set; } = { 1.0f, 0.0f, 0.0f, 1.0f };
        public float[] Specular { get; set; } = { 1.0f, 1.0f, 1.0f, 1.0f };
        public float[] Diffuse { get; set; } = { 1.0f, 1.0f, 1.0f, 1.0f };
        public float Shininess { get; set; } = 50.0f;

        public override void Render(OpenGL gl, RenderMode renderMode)
        {
            if (renderMode != RenderMode.Design) return;

            if (displayList == null)
                CreateDisplayList(gl);
            else
                displayList.Call(gl);
        }

        void CreateDisplayList(OpenGL gl)
        {
            displayList = new DisplayList();
            displayList.Generate(gl);
            displayList.New(gl, DisplayList.DisplayListMode.CompileAndExecute);

            gl.PushAttrib(OpenGL.GL_CURRENT_BIT | OpenGL.GL_ENABLE_BIT | OpenGL.GL_LINE_BIT);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_TEXTURE_2D);

            Transform();
            OpenGLHelper.BindTexture(gl, Resource.OrangeRed);
            gl.Cylinder(glQuadric, BaseRadius, TopRadius, Height, Slices, Stacks);

            gl.PopAttrib();
            displayList.End(gl);
        }

        void Transform()
        {
            BaseRadius = 1;
            TopRadius = 0.5;
            Height = 5;

            Transformation.TranslateX = -10;
            Transformation.TranslateY = 10;
        }
    }
}
