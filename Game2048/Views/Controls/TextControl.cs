using ComputerGraphics;
using SharpGL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Game2048.Views.Controls
{
    /// <summary>
    /// A basic control to display text (includes numbers and characters) by digital format
    /// </summary>
    class TextControl : OpenGLControl
    {
        int number = 0;
        readonly OpenGL gl;

        /// <summary>
        /// The number of control
        /// </summary>
        public int Number
        {
            get => number;
            set
            {
                number = value;

                if (value % 4 == 0)
                {
                    OpenGLHelper.SetBackgroundColor(gl, ConsoleColor.Black);
                }
                else if (value % 4 == 1)
                {
                    OpenGLHelper.SetBackgroundColor(gl, ConsoleColor.Blue);
                }    
                else if (value % 4 == 2)
                {
                    OpenGLHelper.SetBackgroundColor(gl, ConsoleColor.Green);
                }
                else if (value % 4 == 3)
                {
                    OpenGLHelper.SetBackgroundColor(gl, ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// The text of control
        /// </summary>
        public string Character { get; set; }

        /// <summary>
        /// Initialize an instance of text control
        /// </summary>
        public TextControl()
        {
            gl = OpenGL;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            OpenGLDraw += Draw;
        }

        void Draw(object sender, RenderEventArgs e)
        {
            gl.LoadIdentity();
            gl.LookAt(0, 0, 5, 0, 0, 0, 0, 5, 5);

            // Get a character list from the text of control
            var characters = Character.ToCharArray();

            // Align the left margin
            gl.Translate(characters.Length * -2, -0.8, 0);

            // Read all characters in character list
            foreach (var character in characters)
            {
                OpenGLHelper.DrawCharacter2D(gl, character);
                gl.Translate(2, 0, 0);
            }

            // Get a number list from the number of control
            var numbers = number.ToString().Select(digit => int.Parse(digit.ToString()));

            // Split characters and numbers by space
            gl.Translate(6 - numbers.Count(), 0, 0);

            // Read all numbers in number list
            foreach (var number in numbers)
            {
                OpenGLHelper.DrawNumber2D(gl, number);
                gl.Translate(2, 0, 0);
            }

            gl.Flush();
        }
    }
}
