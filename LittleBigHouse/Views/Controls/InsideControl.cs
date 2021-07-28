using ComputerGraphics.Views.Controls;
using LittleBigHouse.Models;
using LittleBigHouse.Models.Inside;
using System;

namespace LittleBigHouse.Views.Controls
{
    class InsideControl : SceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            base.Initialized(sender, e);
            
            Scene.SceneContainer.AddChild(new Column());
            Scene.SceneContainer.AddChild(new Wall());
            Scene.SceneContainer.AddChild(new Sofa());
            Scene.SceneContainer.AddChild(new Table());

            Scene.SceneContainer.AddChild(new Armoire());
            Scene.SceneContainer.AddChild(new Cabinet());

            Scene.SceneContainer.AddChild(new Bed());
        }
    }
}
