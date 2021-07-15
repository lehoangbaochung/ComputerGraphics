using System.Windows.Forms;

namespace ComputerGraphics.Interfaces
{
    /// <summary>
    /// Provides custom control events
    /// </summary>
    public interface IControlEvent
    {
        /// <summary>
        /// Occurs when a key is released while the control has focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnKeyUp(object sender, KeyEventArgs e);

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseDown(object sender, MouseEventArgs e);

        /// <summary>
        /// Occurs when the mouse pointer is moved over the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseMove(object sender, MouseEventArgs e);

        /// <summary>
        /// Occurs when the mouse wheel moves while the control has focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseWheel(object sender, MouseEventArgs e);

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMouseUp(object sender, MouseEventArgs e);
    }
}
