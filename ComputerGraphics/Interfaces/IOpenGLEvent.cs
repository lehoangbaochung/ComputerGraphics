using SharpGL;
using System;

namespace ComputerGraphics.Interfaces
{
    /// <summary>
    /// Defines the mainly OpenGL events
    /// </summary>
    public interface IOpenGLEvent
    {
        /// <summary>
        /// Occurs when OpenGL has been initialized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Initialized(object sender, EventArgs e);

        /// <summary>
        /// Occurs when OpenGL drawing should be performed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Draw(object sender, RenderEventArgs e);
    }
}
