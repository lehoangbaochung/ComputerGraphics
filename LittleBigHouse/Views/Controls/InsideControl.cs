using ComputerGraphics.Models;
using ComputerGraphics.Views.Controls;
using System;

namespace LittleBigHouse.Views.Controls
{
    class InsideControl : SceneControl
    {
        public override void Initialized(object sender, EventArgs e)
        {
            base.Initialized(sender, e);

            var wallSizes = new float[] 
            { 
                100, // length
                1, // thickness
                12 // height
            };

            var sofaSizes = new float[] 
            { 
                20, // length
                5, // width
                1, // thickness
                2, // height of feet
                -15, // translateX
                -10 // translateY
            };

            var sceneElements = new SceneElement[]
            {
                #region Wall
                new Box()
                {
                    Name = "The west wall of house",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0],
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = -wallSizes[0] / 2,
                        TranslateY = -wallSizes[0] / 2
                    }
                },
                new Box()
                {
                    Name = "The east wall of house",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0],
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = wallSizes[0] / 2,
                        TranslateY = -wallSizes[0] / 2
                    }
                },
                new Box()
                {
                    Name = "The north wall of house",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0],
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        TranslateX = -wallSizes[0] / 2,
                        TranslateY = wallSizes[0] / 2
                    }
                },
                new Box()
                {
                    Name = "The south wall of house",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0],
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        TranslateX = -wallSizes[0] / 2,
                        TranslateY = -wallSizes[0] / 2
                    }
                },
                new Box()
                {
                    Name = "The south wall of bedroom",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0] / 4 - 1,
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        TranslateX = wallSizes[0] / 4,
                    }
                },
                new Box()
                {
                    Name = "The west wall of bedroom",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0] / 2,
                    Width = wallSizes[1],
                    Height = wallSizes[2],
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = wallSizes[0] / 4
                    }
                },
                new Box()
                {
                    Name = "The west wall of bathroom",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0] / 4,
                    Width = wallSizes[1],
                    Height = wallSizes[2] / 5,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateY = wallSizes[0] / 4
                    }
                },
                new Box()
                {
                    Name = "The south wall of bathroom",
                    TextureImage = Resource.Wall,
                    Length = wallSizes[0] / 4 - 1,
                    Width = wallSizes[1],
                    Height = wallSizes[2] / 5,
                    Transformation = new()
                    {
                        TranslateY = wallSizes[0] / 4
                    }
                },
                #endregion

                #region Sofa
                new Box()
                {
                    Name = "The front-left foot of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[5] + sofaSizes[1] - 1
                    }
                },
                new Box()
                {
                    Name = "The front-right foot of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4] + sofaSizes[0] - 1,
                        TranslateY = sofaSizes[5] + sofaSizes[1] - 1
                    }
                },
                new Box()
                {
                    Name = "The behind-left foot of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[5] - 1
                    }
                },
                new Box()
                {
                    Name = "The behind-right foot of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4] + sofaSizes[0] - 1,
                        TranslateY = sofaSizes[5] - 1
                    }
                },
                new Box()
                {
                    Name = "The ground of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[0],
                    Width = sofaSizes[1],
                    Height = sofaSizes[2],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[5],
                        TranslateZ = sofaSizes[3]
                    }
                },
                new Box()
                {
                    Name = "The back of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[0],
                    Width = sofaSizes[1],
                    Height = sofaSizes[2],
                    Transformation = new()
                    {
                        RotateX = 90,
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[5],
                        TranslateZ = sofaSizes[3]
                    }
                },
                new Box()
                {
                    Name = "The left hand of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[1],
                    Height = sofaSizes[2],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[5],
                        TranslateZ = sofaSizes[2] + sofaSizes[3]
                    }
                },
                new Box()
                {
                    Name = "The right hand of sofa",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[1],
                    Height = sofaSizes[2],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4] + sofaSizes[0] - 1,
                        TranslateY = sofaSizes[5],
                        TranslateZ = sofaSizes[2] + sofaSizes[3]
                    }
                },
                #endregion

                #region Doors and windows
                new Box()
                {
                    Name = "The door of house",
                    TextureImage = Resource.SmallDoor,
                    Length = 10,
                    Width = 1,
                    Height = 8,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = -wallSizes[0] / 2,
                        TranslateY = 5
                    }
                },
                new Box()
                {
                    Name = "The door of bedroom",
                    TextureImage = Resource.BigDoor,
                    Length = 10,
                    Width = 1,
                    Height = 8,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = wallSizes[0] / 4,
                        TranslateY = 5
                    }
                },
                new Box()
                {
                    Name = "The windows of house",
                    TextureImage = Resource.Windows,
                    Length = 10,
                    Width = wallSizes[1],
                    Height = 5,
                    Transformation = new()
                    {
                        TranslateY = -wallSizes[0] / 2,
                        TranslateZ = 3
                    }
                },
                #endregion

                #region Table
                new Box()
                {
                    Name = "The front-left foot of table",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = sofaSizes[1] - 1
                    }
                },
                new Box()
                {
                    Name = "The front-right foot of table",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4] + sofaSizes[0] - 1,
                        TranslateY = sofaSizes[1] - 1
                    }
                },
                new Box()
                {
                    Name = "The behind-left foot of table",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = 0
                    }
                },
                new Box()
                {
                    Name = "The behind-right foot of table",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[2],
                    Width = sofaSizes[2],
                    Height = sofaSizes[3],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4] + sofaSizes[0] - 1,
                        TranslateY = 0
                    }
                },
                new Box()
                {
                    Name = "The ground of table",
                    TextureImage = Resource.Sofa,
                    Length = sofaSizes[0],
                    Width = sofaSizes[1],
                    Height = sofaSizes[2],
                    Transformation = new()
                    {
                        TranslateX = sofaSizes[4],
                        TranslateY = 0,
                        TranslateZ = sofaSizes[3]
                    }
                },
                #endregion

                #region Others
                new Box()
                {
                    Name = "The lawn carpet",
                    TextureImage = Resource.Lawn,
                    Length = 100,
                    Width = 20,
                    Height = 0,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = -30,
                        TranslateY = -50
                    }
                },
                new Box()
                {
                    Name = "Water",
                    TextureImage = Resource.Water,
                    Length = 25,
                    Width = 25,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateY = wallSizes[0] / 4,
                        TranslateZ = 1
                    }
                },
                new Box()
                {
                    Name = "Cabinet",
                    TextureImage = Resource.Cabinet,
                    Length = 10,
                    Width = 2,
                    Height = 8,
                    Transformation = new()
                    {
                        TranslateX = 35,
                        TranslateY = 2
                    }
                },
                new Box()
                {
                    Name = "Bookshelf",
                    TextureImage = Resource.Bookshelf,
                    Length = 15,
                    Width = 2,
                    Height = 8,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = 48,
                        TranslateY = -40
                    }
                },
                new Box()
                {
                    Name = "Television",
                    TextureImage = Resource.Television,
                    Length = 1,
                    Width = 10,
                    Height = 5,
                    Transformation = new()
                    {
                        RotateZ = 90,
                        TranslateX = -10,
                        TranslateY = wallSizes[0] / 2 - 1,
                        TranslateZ = 3
                    }
                },
                new Box()
                {
                    Name = "Ground",
                    TextureImage = Resource.Wood,
                    Length = 80,
                    Width = 100,
                    Height = 0,
                    Transformation = new()
                    {
                        TranslateX = -30,
                        TranslateY = -50
                    }
                },
                #endregion
            };

            foreach (var sceneElement in sceneElements) 
            {
                Scene.SceneContainer.AddChild(sceneElement); 
            }
        }
    }
}
