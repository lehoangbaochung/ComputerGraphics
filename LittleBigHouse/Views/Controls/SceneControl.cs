using ComputerGraphics.Views.Controls;
using LittleBigHouse.Models;
using System;

namespace LittleBigHouse.Views.Controls
{
    class SceneControl : BaseSceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            // Remove design primitives
            Scene.SceneContainer.Children.RemoveAt(0);

            Scene.SceneContainer.AddChild(new Wall());
            Scene.SceneContainer.AddChild(new Tree());
        }
    }
}
