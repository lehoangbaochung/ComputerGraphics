using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ComputerGraphicsTest
{
    public partial class MainForm : Form
    {
        OpenGL gl;
        float rotation = 0;
        readonly uint[] textures = new uint[1];

        enum ColorType { Red, Green, Blue, Yellow }

        public MainForm() => InitializeComponent();        

        void Init(object sender, EventArgs e)
        {
            gl = openGLControl.OpenGL;

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] light_pos = { 0.0f, 0.0f, 1.0f, 0.0f };
            float[] ambient = { 1.0f, 0.0f, 0.0f, 1.0f };
            float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] diff_use = { 0.0f, 0.5f, 0.0f, 1.0f };
            float shininess = 50.0f;

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_pos);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diff_use);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, shininess);

            var textureImage = new Bitmap(@"\\:filename");

            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.GenTextures(1, textures);
            gl.BindTexture(OpenGL.GL_TEXTURE_2D, textures[0]);
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, textureImage.Width, textureImage.Height, 0, 
                OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE,
                textureImage.LockBits(new Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb).Scan0);

            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
        }

        void Draw(object sender, RenderEventArgs e)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            gl.LoadIdentity();
            gl.LookAt(10.0, 10.0, 15.0, 0.0, 0.0, 0.0, 0.0, 5.0, 0.0);

            DrawCoordinate();

            gl.PushMatrix();
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);
            new Cube().Render(gl, SharpGL.SceneGraph.Core.RenderMode.HitTest);
            SetMaterialColor(ColorType.Red);
            gl.PopMatrix();

            gl.PushMatrix();
            gl.Translate(4, 0, 0);
            gl.Rotate(rotation, 1.0f, 0.0f, 0.0f);
            new Cube().Render(gl, SharpGL.SceneGraph.Core.RenderMode.HitTest);
            SetMaterialColor(ColorType.Green);
            gl.PopMatrix();

            gl.PushMatrix();
            gl.Scale(-1, 1, 1);
            gl.Translate(4, 0, 0);
            gl.Rotate(rotation, -1.0f, 0.0f, 0.0f);
            new Cube().Render(gl, SharpGL.SceneGraph.Core.RenderMode.HitTest);
            SetMaterialColor(ColorType.Blue);
            gl.PopMatrix();

            rotation += 2.0f;
            gl.Flush();
        }
        
        void DrawCoordinate()
        {
            gl.Begin(OpenGL.GL_LINES);
            SetMaterialColor(ColorType.Red);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(10.0, 0.0, 0.0);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            SetMaterialColor(ColorType.Green);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 10.0, 0.0);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            SetMaterialColor(ColorType.Blue);
            gl.Vertex(0.0, 0.0, 0.0);
            gl.Vertex(0.0, 0.0, 10.0);
            gl.End();
        }

        void SetMaterialColor(ColorType colorType = default)
        {
            float[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] diffuse = { 0.0f, 0.0f, 0.0f, 1.0f };

            switch (colorType)
            {
                case ColorType.Red:
                    ambient[0] = 1.0f;
                    diffuse[0] = 1.0f;
                    break;
                case ColorType.Green:
                    ambient[1] = 1.0f;
                    diffuse[1] = 1.0f;
                    break;
                case ColorType.Blue:
                    ambient[2] = 1.0f;
                    diffuse[2] = 1.0f;
                    break;
                case ColorType.Yellow:
                    ambient[0] = 1.0f;
                    ambient[1] = 1.0f;
                    diffuse[0] = 1.0f;
                    diffuse[1] = 1.0f;
                    break;
                default:
                    ambient[0] = 1.0f;
                    ambient[1] = 1.0f;
                    ambient[2] = 1.0f;
                    diffuse[0] = 1.0f;
                    diffuse[1] = 1.0f;
                    diffuse[2] = 1.0f;
                    break;
            }

            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffuse);
        }
    }
}
