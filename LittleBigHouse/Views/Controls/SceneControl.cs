using ComputerGraphics.Views.Controls;
using LittleBigHouse.Models;
using System;

namespace LittleBigHouse.Views.Controls
{
    class SceneControl : BaseSceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            base.Initialized(sender, e);

            Scene.SceneContainer.AddChild(new Column());
            Scene.SceneContainer.AddChild(new Wall());
        }
    }
}
