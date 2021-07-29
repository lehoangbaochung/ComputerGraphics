using ComputerGraphics.Interfaces;
using ComputerGraphics.Models;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Effects;
using System;
using System.Windows.Forms;

namespace ComputerGraphics.Views.Controls
{
    /// <summary>
    /// A base control of SceneControl extends from OpenGLControl that contains and draws a Scene object
    /// </summary>
    public class SceneControl : SharpGL.SceneControl, IOpenGLEvent, IControlEvent
    {
        readonly double aspectRatio = 1.8;
        readonly Vertex[] cameraPositions =
        {
            new(-10, -10, 30),
            new(-10, 10, 30),
            new(10, -10, 30),
            new(10, 10, 30),
        };
        readonly ArcBallEffect arcBallEffect = new();

        public SceneControl()
        {
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            DrawFPS = false;
            Scene.RenderBoundingVolumes = false;
            Scene.CurrentCamera.Position = cameraPositions[0];

            OpenGLInitialized += Initialized;
            OpenGLDraw += Draw;
            KeyUp += OnKeyUp;
            MouseUp += OnMouseUp;
            MouseDown += OnMouseDown;
            MouseMove += OnMouseMove;
            MouseWheel += OnMouseWheel;
        }

        public virtual void Draw(object sender, RenderEventArgs e) { }

        public virtual void Initialized(object sender, EventArgs e)
        {
            // Remove all default design primitives
            Scene.SceneContainer.Children.Clear();

            // Add a grid
            Scene.SceneContainer.AddChild(new Grid() 
            { 
                MinValue = -50, 
                MaxValue = 50 
            });
        }

        public virtual void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Home:
                    ResetCurrentCamera();
                    break;
                case Keys.D1:
                    Scene.CurrentCamera.Position = cameraPositions[0];
                    break;
                case Keys.D2:
                    Scene.CurrentCamera.Position = cameraPositions[1];
                    break;
                case Keys.D3:
                    Scene.CurrentCamera.Position = cameraPositions[2];
                    break;
                case Keys.D4:
                    Scene.CurrentCamera.Position = cameraPositions[3];
                    break;
                default:
                    MoveCurrentCamera(sender, e);
                    break;
            }
        }

        public virtual void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            arcBallEffect.ArcBall.SetBounds(Width, Height);
            arcBallEffect.ArcBall.MouseDown(e.X, e.Y);

            if (Scene.SceneContainer.Effects.Contains(arcBallEffect)) return;

            Scene.SceneContainer.AddEffect(arcBallEffect);
        }

        public virtual void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            arcBallEffect.ArcBall.MouseMove(e.X, e.Y);
        }

        public virtual void OnMouseUp(object sender, MouseEventArgs e)
        {
            arcBallEffect.ArcBall.MouseUp(e.X, e.Y); 
        }

        public virtual void OnMouseWheel(object sender, MouseEventArgs e)
        {
            // Wheel up
            if (e.Delta < 0)
                Scene.CurrentCamera.AspectRatio -= 0.1;

            // Wheel down
            else
                Scene.CurrentCamera.AspectRatio += 0.1;
        }

        /// <summary>
        /// Set current camera back to original position
        /// </summary>
        protected void ResetCurrentCamera()
        {
            Scene.CurrentCamera.AspectRatio = aspectRatio;
            Scene.CurrentCamera.Position = cameraPositions[0];

            Scene.SceneContainer.RemoveEffect(arcBallEffect);
        }

        void MoveCurrentCamera(object sender, KeyEventArgs e)
        {
            var cameraPosition = Scene.CurrentCamera.Position;
            var x = cameraPosition.X;
            var y = cameraPosition.Y;
            var z = cameraPosition.Z;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    y++;
                    break;
                case Keys.Down:
                    y--;
                    break;
                case Keys.Left:
                    x++;
                    break;
                case Keys.Right:
                    x--;
                    break;
                case Keys.PageUp:
                    z++;
                    break;
                case Keys.PageDown:
                    z--;
                    break;
            }

            Scene.CurrentCamera.Position = new Vertex(x, y, z);
        }
    }
}
