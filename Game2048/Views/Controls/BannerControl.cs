using ComputerGraphics;
using ComputerGraphics.Interfaces;
using SharpGL;
using System;
using System.Windows.Forms;

namespace Game2048.Views.Controls
{
    class BannerControl : OpenGLControl, IOpenGLEvent
    {
        int value;
        int rotation = 0;

        public int Value
        {
            get => value;
            set
            {
                this.value = value;

                switch (value)
                {
                    case 2:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube2);
                        break;
                    case 4:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube4);
                        break;
                    case 8:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube8);
                        break;
                    case 16:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube16);
                        break;
                    case 32:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube32);
                        break;
                    case 64:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube64);
                        break;
                    case 128:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube128);
                        break;
                    case 256:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube256);
                        break;
                    case 512:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube512);
                        break;
                    case 1024:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube1024);
                        break;
                    case 2048:
                    default:
                        OpenGLHelper.BindTexture(OpenGL, Resource.Cube2048);
                        break;
                }
            }
        }

        public BannerControl()
        {
            Value = 2;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            OpenGLDraw += Draw;
            OpenGLInitialized += Initialized;
        }

        public void Initialized(object sender, EventArgs e)
        {
        }

        public void Draw(object sender, RenderEventArgs args)
        {
            OpenGLHelper.SetBackgroundColor(OpenGL);
            OpenGL.LoadIdentity();

            OpenGL.Rotate(rotation, 0.0f, 1.0f, 0.0f);
            OpenGL.Rotate(180, 1.0f, 0.0f, 0.0f);
            OpenGL.Begin(OpenGL.GL_QUADS);

            // Front face
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(-1.0f, -1.0f, 1.0f); // Bottom Left Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(1.0f, -1.0f, 1.0f);  // Bottom Right Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(1.0f, 1.0f, 1.0f);   // Top Right Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(-1.0f, 1.0f, 1.0f);  // Top Left Of The Texture and Quad

            // Back face
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(-1.0f, -1.0f, -1.0f);    // Bottom Right Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(-1.0f, 1.0f, -1.0f); // Top Right Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(1.0f, 1.0f, -1.0f);  // Top Left Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(1.0f, -1.0f, -1.0f); // Bottom Left Of The Texture and Quad

            // Top face
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(-1.0f, 1.0f, -1.0f); // Top Left Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(-1.0f, 1.0f, 1.0f);  // Bottom Left Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(1.0f, 1.0f, 1.0f);   // Bottom Right Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(1.0f, 1.0f, -1.0f);  // Top Right Of The Texture and Quad

            // Bottom face
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(-1.0f, -1.0f, -1.0f);    // Top Right Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(1.0f, -1.0f, -1.0f); // Top Left Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(1.0f, -1.0f, 1.0f);  // Bottom Left Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(-1.0f, -1.0f, 1.0f); // Bottom Right Of The Texture and Quad

            // Right face
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(1.0f, -1.0f, -1.0f); // Bottom Right Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(1.0f, 1.0f, -1.0f);  // Top Right Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(1.0f, 1.0f, 1.0f);   // Top Left Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(1.0f, -1.0f, 1.0f);  // Bottom Left Of The Texture and Quad

            // Left face
            OpenGL.TexCoord(0.0f, 0.0f); OpenGL.Vertex(-1.0f, -1.0f, -1.0f);    // Bottom Left Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 0.0f); OpenGL.Vertex(-1.0f, -1.0f, 1.0f); // Bottom Right Of The Texture and Quad
            OpenGL.TexCoord(1.0f, 1.0f); OpenGL.Vertex(-1.0f, 1.0f, 1.0f);  // Top Right Of The Texture and Quad
            OpenGL.TexCoord(0.0f, 1.0f); OpenGL.Vertex(-1.0f, 1.0f, -1.0f);	// Top Left Of The Texture and Quad

            OpenGL.End();
            OpenGL.Flush();

            rotation += 2;
        }
    }
}
