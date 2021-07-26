using LittleBigHouse.Models;
using System;

namespace LittleBigHouse.Views.Controls
{
    class SceneControl : ComputerGraphics.Views.Controls.SceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            base.Initialized(sender, e);

            Scene.SceneContainer.AddChild(new Column());
            Scene.SceneContainer.AddChild(new Wall());
            Scene.SceneContainer.AddChild(new Sofa());
            Scene.SceneContainer.AddChild(new Table());
        }
    }
}
