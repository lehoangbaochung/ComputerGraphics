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
            //Scene.SceneContainer.Children.Clear();

            var sceneElements = new SceneElement[]
            {
                new Box()
                {
                    Name = "House",
                    TextureImage = Resource.Wall,
                    Length = 20,
                    Width = 20,
                    Height = 10,
                    Transformation = new()
                    {
                        TranslateX = -10,
                        TranslateY = -10
                    }
                },
                new Pyramid()
                {
                    Name = "Roof",
                    TextureImage = Resource.Roof,
                    Size = 20,
                    Height = 10,
                    Transformation = new()
                    {
                        RotateX = 90,
                        TranslateZ = 10
                    }
                },
                new Box()
                {
                    Name = "Windows",
                    TextureImage = Resource.Windows,
                    Length = 1,
                    Width = 5,
                    Height = 5,
                    Transformation = new()
                    {
                        RotateZ = -90,
                        TranslateY = -9,
                        TranslateZ = 3
                    }
                },
                new Box()
                {
                    Name = "FrontDoor",
                    TextureImage = Resource.SmallDoor,
                    Length = 1,
                    Width = 5,
                    Height = 8,
                    Transformation = new()
                    {
                        TranslateX = -10
                    }
                },
                new Box()
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
                },
                new Box()
                {
                    Name = "SouthRoad",
                    TextureImage = Resource.Road,
                    Length = 10,
                    Width = 100,
                    Height = 0,
                    Transformation = new()
                    {
                        RotateZ = -90,
                        TranslateX = -50,
                        TranslateY = -10
                    }
                },
                new Box()
                {
                    Name = "FrontGrass",
                    TextureImage = Resource.Lawn,
                    Length = 30,
                    Width = 60,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -50,
                        TranslateY = -10
                    }
                }
            };

            foreach (var sceneElement in sceneElements)
            {
                Scene.SceneContainer.AddChild(sceneElement); 
            }
        }
    }
}
