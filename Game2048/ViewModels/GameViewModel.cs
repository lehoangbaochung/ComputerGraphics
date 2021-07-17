using ComputerGraphics;
using Game2048.Models;
using Game2048.Views.Controls;
using System.Linq;

namespace Game2048.ViewModels
{
    class GameViewModel : MainViewModel
    {
        readonly GameControl gameControl;

        public GameViewModel(GameControl gameControl)
        {
            this.gameControl = gameControl;
            Display();
        }

        public void Display()
        {
            // Get all children in scene (includes lights and cubes)
            var children = gameControl.Scene.SceneContainer.Children;

            // Get all cubes in scene
            var cubes = children.Where(c => c.Name == "Cube")
                .Select(c => c as Cube).ToList();

            // Remove them
            cubes.ForEach(c => children.Remove(c));

            // Add new cubes
            for (int i = 0; i < positionMatrix.Length; i++)
            {
                var x = i / 4;
                var y = i % 4;

                if (positionMatrix[x, y] != 0)
                {
                    var cube = new Cube() { Value = positionMatrix[x, y] };
                    cube.Transformation.TranslateX = Translate(x);
                    cube.Transformation.TranslateY = Translate(y);
                    children.Add(cube);
                }
            }
        }

        public float[] LightPosition { get; set; } = { 0, 0, 1, 0 };
        public float[] Ambient { get; set; } = { 1, 0, 0, 1 };
        public float[] Specular { get; set; } = { 1, 1, 1, 1 };
        public float[] Diffuse { get; set; } = { 1, 1, 1, 1 };
        public float Shininess { get; set; } = 50;

        public void MoveUp()
        {
            var isSuccess = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y > 0; y--)
                {
                    for (int y1 = y - 1; y1 >= 0; y1--)
                    {
                        if (positionMatrix[x, y1] > 0)
                        {
                            if (positionMatrix[x, y] == 0)
                            {
                                positionMatrix[x, y] = positionMatrix[x, y1];
                                positionMatrix[x, y1] = 0;
                                y++;

                                isSuccess = true;
                            }
                            else if (positionMatrix[x, y] == positionMatrix[x, y1])
                            {
                                positionMatrix[x, y] *= 2;
                                positionMatrix[x, y1] = 0;

                                isSuccess = true;
                            }
                            break;
                        }
                    }
                }
            }

            if (!isSuccess) return;

            Move();
        }

        public void MoveDown()
        {
            var isSuccess = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int y1 = y + 1; y1 < 4; y1++)
                    {
                        if (positionMatrix[x, y1] > 0)
                        {
                            if (positionMatrix[x, y] == 0)
                            {
                                positionMatrix[x, y] = positionMatrix[x, y1];
                                positionMatrix[x, y1] = 0;
                                y--;

                                isSuccess = true;
                            }
                            else if (positionMatrix[x, y] == positionMatrix[x, y1])
                            {
                                positionMatrix[x, y] *= 2;
                                positionMatrix[x, y1] = 0;

                                isSuccess = true;
                            }
                            break;
                        }
                    }
                }
            }

            if (!isSuccess) return;

            Move();
        }

        public void MoveLeft()
        {
            var isSuccess = false;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int x1 = x + 1; x1 < 4; x1++)
                    {
                        if (positionMatrix[x1, y] > 0)
                        {
                            if (positionMatrix[x, y] == 0)
                            {
                                positionMatrix[x, y] = positionMatrix[x1, y];
                                positionMatrix[x1, y] = 0;
                                x--;

                                isSuccess = true;
                            }
                            else if (positionMatrix[x, y] == positionMatrix[x1, y])
                            {
                                positionMatrix[x, y] *= 2;
                                positionMatrix[x1, y] = 0;

                                isSuccess = true;
                            }
                            break;
                        }
                    }
                }
            }

            if (!isSuccess) return;

            Move();
        }

        public void MoveRight()
        {
            var isSuccess = false;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x >= 1; x--)
                {
                    for (int x1 = x - 1; x1 >= 0; x1--)
                    {
                        if (positionMatrix[x1, y] > 0)
                        {
                            if (positionMatrix[x, y] == 0)
                            {
                                positionMatrix[x, y] = positionMatrix[x1, y];
                                positionMatrix[x1, y] = 0;
                                x++;

                                isSuccess = true;
                            }
                            else if (positionMatrix[x, y] == positionMatrix[x1, y])
                            {
                                positionMatrix[x, y] *= 2;
                                positionMatrix[x1, y] = 0;

                                isSuccess = true;
                            }
                            break;
                        }
                    }
                }
            }

            if (!isSuccess) return;

            Move();
        }

        void Move()
        {
            CreateRandomCube();
            Display();

            MoveControl.Number++;

            foreach (var positionValue in positionMatrix)
            {
                ScoreControl.Number += positionValue;

                if (positionValue > BannerControl.Value)
                {
                    BannerControl.Value = positionValue;
                }
            }
        }

        public BannerControl BannerControl { get; set; }

        public TextControl ScoreControl { get; set; }

        public TextControl MoveControl { get; set; }
    }
}
