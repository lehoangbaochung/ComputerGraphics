using SharpGL;
using System;

namespace ComputerGraphics.Helpers
{
    public class ColorHelper
    {
        public static void SetMaterialColor(OpenGL gl, ConsoleColor color = default)
        {
            float[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] diffuse = { 0.0f, 0.0f, 0.0f, 1.0f };

            switch (color)
            {
                case ConsoleColor.Red:
                    ambient[0] = 1.0f;
                    diffuse[0] = 1.0f;
                    break;
                case ConsoleColor.Green:
                    ambient[1] = 1.0f;
                    diffuse[1] = 1.0f;
                    break;
                case ConsoleColor.Blue:
                    ambient[2] = 1.0f;
                    diffuse[2] = 1.0f;
                    break;
                case ConsoleColor.Yellow:
                    ambient[0] = 1.0f;
                    ambient[1] = 1.0f;
                    diffuse[0] = 1.0f;
                    diffuse[1] = 1.0f;
                    break;
                case ConsoleColor.Cyan:
                    ambient[1] = 1.0f;
                    ambient[2] = 1.0f;
                    diffuse[1] = 1.0f;
                    diffuse[2] = 1.0f;
                    break;
                case ConsoleColor.White:
                    ambient[0] = 1.0f;
                    ambient[1] = 1.0f;
                    ambient[2] = 1.0f;
                    diffuse[0] = 1.0f;
                    diffuse[1] = 1.0f;
                    diffuse[2] = 1.0f;
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
                    gl.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
                    break;
                case ConsoleColor.Red:
                    gl.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
                    break;
                case ConsoleColor.Green:
                    gl.ClearColor(0.0f, 1.0f, 0.0f, 1.0f);
                    break;
                case ConsoleColor.Blue:
                    gl.ClearColor(0.0f, 0.0f, 1.0f, 1.0f);
                    break;
                case ConsoleColor.Black:
                default:
                    gl.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
                    break;
            }
        }
    }
}
