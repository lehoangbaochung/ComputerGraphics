using SharpGL.SceneGraph;
using System;
using System.Windows.Forms;
using Game2048.Models;
using ComputerGraphics.Views.Controls;

namespace Game2048.Views.Controls
{
    /// <summary>
    /// The main control of game
    /// </summary>
    class GameControl : BaseSceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            // Set camera position
            Scene.CurrentCamera.Position = new Vertex(0, -10, 30);

            // Remove design primitives
            Scene.SceneContainer.Children.RemoveAt(0);

            // Add a grid
            Scene.SceneContainer.AddChild(new Grid());
        }

        public override void OnKeyUp(object sender, KeyEventArgs e)
        {
            var x = Scene.CurrentCamera.Position.X;
            var y = Scene.CurrentCamera.Position.Y;
            var z = Scene.CurrentCamera.Position.Z;

            switch (e.KeyCode)
            {
                case Keys.Y:
                    ResetCurrentCamera();
                    break;
                case Keys.D:
                    x++;
                    Scene.CurrentCamera.Position =
                        new Vertex(x, Scene.CurrentCamera.Position.Y, Scene.CurrentCamera.Position.Z);
                    break;
                case Keys.A:
                    x--;
                    Scene.CurrentCamera.Position =
                        new Vertex(x, Scene.CurrentCamera.Position.Y, Scene.CurrentCamera.Position.Z);
                    break;
                case Keys.W:
                    y++;
                    Scene.CurrentCamera.Position = 
                        new Vertex(Scene.CurrentCamera.Position.X, y, Scene.CurrentCamera.Position.Z);
                    break;
                case Keys.S:
                    y--;
                    Scene.CurrentCamera.Position = 
                        new Vertex(Scene.CurrentCamera.Position.X, y, Scene.CurrentCamera.Position.Z);
                    break;
                case Keys.Q:
                    z++;
                    Scene.CurrentCamera.Position = 
                        new Vertex(Scene.CurrentCamera.Position.X, Scene.CurrentCamera.Position.Y, z);
                    break;
                case Keys.E:
                    z--;
                    Scene.CurrentCamera.Position = 
                        new Vertex(Scene.CurrentCamera.Position.X, Scene.CurrentCamera.Position.Y, z);
                    break;
            }    
        }
    }
}
