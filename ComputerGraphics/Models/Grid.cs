using SharpGL;
using SharpGL.SceneGraph.Transformations;

namespace ComputerGraphics.Models
{
    class Grid : SceneElement
    {
        public float LineWidth { get; set; } = 1;
        public int MinValue { get; set; } = -10;
        public int MaxValue { get; set; } = 10;
        public LinearTransformation Transformation { get; set; } = new();

        protected override void Draw()
        {
            gl.LineWidth(LineWidth);
            gl.Begin(OpenGL.GL_LINES);

            for (int i = MinValue; i <= MaxValue; i++)
            {
                gl.Vertex(i, MinValue, 0);
                gl.Vertex(i, MaxValue, 0);
                gl.Vertex(MinValue, i, 0);
                gl.Vertex(MaxValue, i, 0);
            }

            gl.End();
        }
    }
}
