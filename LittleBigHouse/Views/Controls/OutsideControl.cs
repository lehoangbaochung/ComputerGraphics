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
                    Name = "Door",
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
                    Name = "Water (the left of house)",
                    TextureImage = Resource.Water,
                    Length = 60,
                    Width = 30,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -10,
                        TranslateY = -50
                    }
                },
                new Box()
                {
                    Name = "The front of house",
                    TextureImage = Resource.Lawn,
                    Length = 30,
                    Width = 60,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -50,
                        TranslateY = -10
                    }
                },
                new Box()
                {
                    Name = "The behind of house",
                    TextureImage = Resource.Lawn,
                    Length = 60,
                    Width = 60,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -10,
                        TranslateY = -10
                    }
                },
                new Box()
                {
                    Name = "The opposite of house",
                    TextureImage = Resource.Lawn,
                    Length = 30,
                    Width = 30,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -50,
                        TranslateY = -10
                    }
                },
                new Box()
                {
                    Name = "OilCan",
                    TextureImage = Resource.Orange,
                    Length = 2,
                    Width = 2,
                    Height = 5,
                    Transformation = new()
                    {
                        TranslateX = -25,
                        TranslateY = -9
                    }
                },
                new Box()
                {
                    Name = "Tree",
                    TextureImage = Resource.Wood,
                    Length = 1,
                    Width = 1,
                    Height = 5,
                    Transformation = new()
                    {
                        TranslateX = 15,
                        TranslateY = -9
                    }
                },
                new Pyramid()
                {
                    Name = "The leaf of tree",
                    TextureImage = Resource.GreenLeaf,
                    Size = 4,
                    Height = 3,
                    Transformation = new()
                    {
                        RotateX = 90,
                        TranslateX = 15.5f,
                        TranslateY = -8.5f,
                        TranslateZ = 5
                    }
                },
                new Box()
                {
                    Name = "Tree",
                    TextureImage = Resource.Wood,
                    Length = 1,
                    Width = 1,
                    Height = 5,
                    Transformation = new()
                    {
                        TranslateX = 20,
                        TranslateY = -9
                    }
                },
                new Pyramid()
                {
                    Name = "The leaf of tree",
                    TextureImage = Resource.GreenLeaf,
                    Size = 4,
                    Height = 3,
                    Transformation = new()
                    {
                        RotateX = 90,
                        TranslateX = 20.5f,
                        TranslateY = -8.5f,
                        TranslateZ = 5
                    }
                },
                new Box()
                {
                    Name = "Tree",
                    TextureImage = Resource.Wood,
                    Length = 1,
                    Width = 1,
                    Height = 5,
                    Transformation = new()
                    {
                        TranslateX = -9,
                        TranslateY = 15
                    }
                },
                new Pyramid()
                {
                    Name = "The leaf of tree",
                    TextureImage = Resource.GreenLeaf,
                    Size = 4,
                    Height = 3,
                    Transformation = new()
                    {
                        RotateX = 90,
                        TranslateX = -8.5f,
                        TranslateY = 15.5f,
                        TranslateZ = 5
                    }
                },
                new Grid()
                {
                    LineWidth = 5,
                    MinValue = -5,
                    MaxValue = 5,
                    TextureImage = Resource.OrangeRed,
                    Transformation = new()
                    {
                        RotateY = -90,
                        TranslateX = -20
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
