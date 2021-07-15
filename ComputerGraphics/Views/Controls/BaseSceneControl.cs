using ComputerGraphics.Interfaces;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Effects;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Windows.Forms;

namespace ComputerGraphics.Views.Controls
{
    public class BaseSceneControl : SceneControl, IOpenGLEvent, IControlEvent
    {
        readonly double aspectRatio = 1.8;
        readonly ArcBallEffect arcBallEffect = new();
        readonly Vertex cameraPosition = new(-10, -10, 30);

        public BaseSceneControl()
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
            // Remove design primitives
            Scene.SceneContainer.Children.RemoveAt(0);
            
            // Add a grid
            Scene.SceneContainer.AddChild(new Grid());
        }

        public virtual void OnKeyUp(object sender, KeyEventArgs e) { }

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
    }
}
