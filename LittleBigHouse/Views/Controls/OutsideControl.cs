using ComputerGraphics.Models;
using ComputerGraphics.Views.Controls;
using System;

namespace LittleBigHouse.Views.Controls
{
    class OutsideControl : SceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            base.Initialized(sender, e);

            var westRoad = new Box()
            {
                Name = "WestRoad",
                TextureImage = Resource.Road,
                Length = 10,
                Width = 100,
                Height = 0,
                Transformation = new()
                {
                    TranslateX = -20,
                    TranslateY = -50
                }
            };

            var southRoad = new Box()
            {
                Name = "SouthRoad",
                TextureImage = Resource.Road,
                Length = 100,
                Width = 10,
                Height = 0,
                Transformation = new()
                {
                    TranslateX = -50,
                    TranslateY = -20
                }
            };

            Scene.SceneContainer.AddChild(westRoad);
            //Scene.SceneContainer.AddChild(southRoad);
        }
    }
}
