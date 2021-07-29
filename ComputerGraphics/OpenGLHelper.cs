using SharpGL;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ComputerGraphics
{
    public class OpenGLHelper : SharpGL.SceneGraph.Helpers.OpenGLHelper
    {
        #region Color
        public static void SetMaterialColor(OpenGL gl, ConsoleColor color = default)
        {
            float[] ambient = { 0, 0, 0, 1 };
            float[] diffuse = { 0, 0, 0, 1 };

            switch (color)
            {
                case ConsoleColor.Red:
                    ambient[0] = 1;
                    diffuse[0] = 1;
                    break;
                case ConsoleColor.Green:
                    ambient[1] = 1;
                    diffuse[1] = 1;
                    break;
                case ConsoleColor.Blue:
                    ambient[2] = 1;
                    diffuse[2] = 1;
                    break;
                case ConsoleColor.Yellow:
                    ambient[0] = 1;
                    ambient[1] = 1;
                    diffuse[0] = 1;
                    diffuse[1] = 1;
                    break;
                case ConsoleColor.Cyan:
                    ambient[1] = 1;
                    ambient[2] = 1;
                    diffuse[1] = 1;
                    diffuse[2] = 1;
                    break;
                case ConsoleColor.White:
                    ambient[0] = 1;
                    ambient[1] = 1;
                    ambient[2] = 1;
                    diffuse[0] = 1;
                    diffuse[1] = 1;
                    diffuse[2] = 1;
                    break;
                case ConsoleColor.Black:
                default:
                    break;
            }

            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffuse);
        }

        public static void SetMaterialColor(OpenGL gl, float[] ambient, float[] diffuse)
        {
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffuse);
        }

        public static void SetBackgroundColor(OpenGL gl, ConsoleColor color = default)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            switch (color)
            {
                case ConsoleColor.White:
                    gl.ClearColor(1, 1, 1, 1);
                    break;
                case ConsoleColor.Red:
                    gl.ClearColor(1, 0, 0, 1);
                    break;
                case ConsoleColor.Green:
                    gl.ClearColor(0, 1, 0, 1);
                    break;
                case ConsoleColor.Blue:
                    gl.ClearColor(0, 0, 1, 1);
                    break;
                case ConsoleColor.Black:
                default:
                    gl.ClearColor(0, 0, 0, 1);
                    break;
            }
        }
        #endregion

        #region Draw
        public static void DrawBox(OpenGL gl, float x, float y, float z)
        {
            // front
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0, 0, 1);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(0, y, z);
            gl.TexCoord(1, 1); gl.Vertex(x, y, z);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, z);
            gl.End();

            // behind
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0, 0, -1);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, 0);
            gl.TexCoord(0, 1); gl.Vertex(0, y, 0);
            gl.End();

            // left
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(-1, 0, 0);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(0, 1); gl.Vertex(0, 0, z);
            gl.TexCoord(1, 1); gl.Vertex(0, y, z);
            gl.TexCoord(1, 0); gl.Vertex(0, y, 0);
            gl.End();

            // right
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(1, 0, 0);
            gl.TexCoord(0, 0); gl.Vertex(x, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, y, z);
            gl.End();

            // top
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0, 1, 0);
            gl.TexCoord(0, 0); gl.Vertex(0, y, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, y, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, y, z);
            gl.TexCoord(0, 1); gl.Vertex(0, y, z);
            gl.End();

            // bottom
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0, -1, 0);
            gl.TexCoord(0, 0); gl.Vertex(0, 0, 0);
            gl.TexCoord(1, 0); gl.Vertex(x, 0, 0);
            gl.TexCoord(1, 1); gl.Vertex(x, 0, z);
            gl.TexCoord(0, 1); gl.Vertex(0, 0, z);
            gl.End();
        }

        public static void DrawLine(OpenGL gl, float[] startPoint, float[] endPoint, 
            ConsoleColor color = default, float lineWidth = 1)
        {
            gl.Begin(OpenGL.GL_LINES);
            SetMaterialColor(gl, color);
            gl.LineWidth(lineWidth);
            gl.Vertex(startPoint);
            gl.Vertex(endPoint);
            gl.End();
        }

        public static void DrawNumber2D(OpenGL gl, int number, 
            float width = 1, float height = 2, ConsoleColor color = ConsoleColor.White, float lineWidth = 2)
        {
            var point1 = new float[] { 0, height, 0 };
            var point2 = new float[] { width, height, 0 };
            var point3 = new float[] { width, height / 2, 0 };
            var point4 = new float[] { width, 0, 0 };
            var point5 = new float[] { 0, 0, 0 };
            var point6 = new float[] { 0, height / 2, 0 };

            // Modify the width of lines
            gl.LineWidth(2);

            switch (number)
            {
                case 0:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point4, color);
                    DrawLine(gl, point4, point5, color);
                    DrawLine(gl, point5, point1, color);
                    break;
                case 1:
                    DrawLine(gl, point2, point4, color);
                    break;
                case 2:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point3, color);
                    DrawLine(gl, point3, point6, color);
                    DrawLine(gl, point6, point5, color);
                    DrawLine(gl, point5, point4, color);
                    break;
                case 3:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point4, color);
                    DrawLine(gl, point3, point6, color);
                    DrawLine(gl, point5, point4, color);
                    break;
                case 4:
                    DrawLine(gl, point1, point6, color);
                    DrawLine(gl, point6, point3, color);
                    DrawLine(gl, point2, point4, color);
                    break;
                case 5:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point1, point6, color);
                    DrawLine(gl, point6, point3, color);
                    DrawLine(gl, point3, point4, color);
                    DrawLine(gl, point5, point4, color);
                    break;
                case 6:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point1, point5, color);
                    DrawLine(gl, point5, point4, color);
                    DrawLine(gl, point6, point3, color);
                    DrawLine(gl, point3, point4, color);
                    break;
                case 7:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point4, color);
                    break;
                case 8:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point4, color);
                    DrawLine(gl, point4, point5, color);
                    DrawLine(gl, point1, point5, color);
                    DrawLine(gl, point3, point6, color);
                    break;
                case 9:
                    DrawLine(gl, point1, point2, color);
                    DrawLine(gl, point2, point4, color);
                    DrawLine(gl, point4, point5, color);
                    DrawLine(gl, point1, point6, color);
                    DrawLine(gl, point3, point6, color);
                    break;
            }
        }

        public static void DrawCharacter2D(OpenGL gl, char character,
            float width = 1, float height = 2, ConsoleColor color = ConsoleColor.White, float lineWidth = 2)
        {
            var point1 = new float[] { 0, height, 0 };
            var point2 = new float[] { width / 2, height, 0 };
            var point3 = new float[] { width, height, 0 };
            var point4 = new float[] { width, height / 2, 0 };
            var point5 = new float[] { width, 0, 0 };
            var point6 = new float[] { width / 2, 0, 0 };
            var point7 = new float[] { 0, 0, 0 };
            var point8 = new float[] { 0, height / 2, 0 };

            switch (character)
            {
                case 'S':
                case 's':
                case '5':
                    DrawNumber2D(gl, 5, width, height, color, lineWidth);
                    break;
                case 'C':
                case 'c':
                    DrawLine(gl, point1, point3, color, lineWidth);
                    DrawLine(gl, point1, point7, color, lineWidth);
                    DrawLine(gl, point7, point5, color, lineWidth);
                    break;
                case 'O':
                case 'o':
                    DrawNumber2D(gl, 0, width, height, color, lineWidth);
                    break;
                case 'R':
                case 'r':
                    DrawLine(gl, point1, point3, color, lineWidth);
                    DrawLine(gl, point1, point7, color, lineWidth);
                    DrawLine(gl, point3, point4, color, lineWidth);
                    DrawLine(gl, point8, point5, color, lineWidth);
                    break;
                case 'E':
                case 'e':
                    DrawLine(gl, point1, point3, color, lineWidth);
                    DrawLine(gl, point1, point7, color, lineWidth);
                    DrawLine(gl, point7, point5, color, lineWidth);
                    DrawLine(gl, point8, point4, color, lineWidth);
                    break;
                case 'M':
                case 'm':
                    DrawLine(gl, point1, point3, color, lineWidth);
                    DrawLine(gl, point1, point7, color, lineWidth);
                    DrawLine(gl, point3, point5, color, lineWidth);
                    DrawLine(gl, point2, point6, color, lineWidth);
                    break;
                case 'V':
                case 'v':
                    DrawLine(gl, point1, point8, color, lineWidth);
                    DrawLine(gl, point8, point6, color, lineWidth);
                    DrawLine(gl, point3, point4, color, lineWidth);
                    DrawLine(gl, point6, point4, color, lineWidth);
                    break;
            }    
        }

        public static void DrawGrid(OpenGL gl, int minValue, int maxValue, ConsoleColor color = default)
        {
            gl.Begin(OpenGL.GL_LINES);

            for (int i = minValue; i <= maxValue; i++)
            {
                SetMaterialColor(gl, color);
                gl.Vertex(i, minValue, 0);
                gl.Vertex(i, maxValue, 0);
                gl.Vertex(minValue, i, 0);
                gl.Vertex(maxValue, i, 0);
            }

            gl.End();
        }

        /// <summary>
        /// Draw a cube
        /// </summary>
        /// <param name="gl">The OpenGL object</param>
        /// <param name="size">The size of cube</param>
        public static void DrawCube(OpenGL gl, float size)
        {
            gl.Begin(OpenGL.GL_QUADS);

            // Front face
            gl.Normal(0.0, 0.0, 1.0);
            gl.Vertex(-size, -size, size);
            gl.Vertex(size, -size, size);
            gl.Vertex(size, size, size);
            gl.Vertex(-size, size, size);

            // Back face
            gl.Normal(0.0, 0.0, -1.0);
            gl.Vertex(-size, -size, -size);
            gl.Vertex(-size, size, -size);
            gl.Vertex(size, size, -size);
            gl.Vertex(size, -size, -size);

            // Top face
            gl.Normal(0.0, 1.0, 0.0);
            gl.Vertex(-size, size, -size);
            gl.Vertex(-size, size, size);
            gl.Vertex(size, size, size);
            gl.Vertex(size, size, -size);

            // Bottom face
            gl.Normal(0.0, -1.0, 0.0);
            gl.Vertex(-size, -size, -size);
            gl.Vertex(size, -size, -size);
            gl.Vertex(size, -size, size);
            gl.Vertex(-size, -size, size);

            // Right face
            gl.Normal(1.0, 0.0, 0.0);
            gl.Vertex(size, -size, -size);
            gl.Vertex(size, size, -size);
            gl.Vertex(size, size, size);
            gl.Vertex(size, -size, size);

            // Left face
            gl.Normal(-1.0, 0.0, 0.0);
            gl.Vertex(-size, -size, -size);
            gl.Vertex(-size, -size, size);
            gl.Vertex(-size, size, size);
            gl.Vertex(-size, size, -size);

            gl.End();
        }

        /// <summary>
        /// Draw a pyramid
        /// </summary>
        /// <param name="gl">The OpenGL object</param>
        /// <param name="size">The size of pyramid</param>
        /// <param name="height">The height of pyramid</param>
        public static void DrawPyramid(OpenGL gl, float size, float height)
        {
            var half_size = size * 0.5;

            gl.Begin(OpenGL.GL_TRIANGLES);

            //Front face
            gl.Normal(0.0, 0.0, 1.0f);
            gl.TexCoord(0, 0); gl.Vertex(0.0f, height, 0.0f);
            gl.TexCoord(0, 1); gl.Vertex(-half_size, 0, half_size);
            gl.TexCoord(1, 0); gl.Vertex(half_size, 0, half_size);

            //left face
            gl.Normal(-1.0, 0.0, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(0.0, height, 0.0);
            gl.TexCoord(0, 1); gl.Vertex(-half_size, 0.0, -half_size);
            gl.TexCoord(1, 0); gl.Vertex(-half_size, 0.0, half_size);

            //back face
            gl.Normal(0.0, 0.0, -1.0f);
            gl.TexCoord(0, 0); gl.Vertex(0.0f, height, 0.0f);
            gl.TexCoord(1, 0); gl.Vertex(-half_size, 0, -half_size);
            gl.TexCoord(0, 1); gl.Vertex(half_size, 0, -half_size);

            //Right face
            gl.Normal(1.0, 0.0, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(0.0, height, 0.0);
            gl.TexCoord(1, 0); gl.Vertex(half_size, 0.0, -half_size);
            gl.TexCoord(0, 1); gl.Vertex(half_size, 0.0, half_size);
            gl.End();

            //Bottom face
            gl.Begin(OpenGL.GL_QUADS);
            gl.Normal(0.0, -1.0, 0.0f);
            gl.TexCoord(0, 0); gl.Vertex(half_size, 0.0, half_size);
            gl.TexCoord(0, 1); gl.Vertex(half_size, 0.0, -half_size);
            gl.TexCoord(1, 1); gl.Vertex(-half_size, 0.0, -half_size);
            gl.TexCoord(0, 1); gl.Vertex(-half_size, 0.0, half_size);
            gl.End();
        }
        #endregion

        #region Lighting
        public static void EnableLighting(OpenGL gl)
        {
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        public static void DisableLighting(OpenGL gl)
        {
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
        }

        /// <summary>
        /// This function sets a light position
        /// </summary>
        /// <param name="gl">OpenGL object</param>
        /// <param name="lightPosition">The position (x, y, z) of light</param>
        public static void SetLighting(OpenGL gl, float[] lightPosition)
        {
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, lightPosition);
        }
        #endregion

        #region Material
        /// <summary>
        /// This function sets a material parameter
        /// </summary>
        /// <param name="gl">OpenGL object</param>
        /// <param name="shininess"></param>
        /// <param name="ambient"></param>
        /// <param name="diffuse"></param>
        /// <param name="specular"></param>
        public static void SetMaterial(OpenGL gl, float[] ambient, float[] diffuse, float[] specular, float shininess)
        {
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, shininess);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT, ambient);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_DIFFUSE, diffuse);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular);
        }
        #endregion

        #region Texture
        public static void BindTexture(OpenGL gl, Bitmap textureImage)
        {
            gl.Enable(OpenGL.GL_TEXTURE_2D);

            //  Tell OpenGL where the texture data is
            gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, textureImage.Width, textureImage.Height, 0,
                OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE,
                textureImage.LockBits(new Rectangle(0, 0, textureImage.Width, textureImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb).Scan0);

            //  Specify linear filtering
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
        }
        #endregion
    }
}
