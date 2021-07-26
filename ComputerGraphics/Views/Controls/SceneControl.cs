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
        readonly ArcBallEffect arcBallEffect = new();
        readonly Vertex cameraPosition = new(-10, -10, 30);

        enum Direction
        {
            Front,
            Behind,
            Left,
            Right
        }

        public SceneControl()
        {
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.Fixed3D;

            DrawFPS = false;
            Scene.RenderBoundingVolumes = false;
            Scene.CurrentCamera.Position = cameraPosition;

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
                case Keys.Up:
                    ChangeCameraPosition(Direction.Right);
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
            Scene.CurrentCamera.Position = cameraPosition;

            Scene.SceneContainer.RemoveEffect(arcBallEffect);
        }

        void ChangeCameraPosition(Direction direction)
        {
            var x = Scene.CurrentCamera.Position.X;
            var y = Scene.CurrentCamera.Position.Y;
            var z = Scene.CurrentCamera.Position.Z;

            _ = direction switch
            {
                Direction.Front => x++,
                Direction.Behind => x--,
                Direction.Left => y--,
                Direction.Right => z++,
                _ => z
            };

            Scene.CurrentCamera.Position = new Vertex(x, y, z);
        }
    }
}
