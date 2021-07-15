using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Game2048.Models;
using Game2048.Views.Controls;

namespace Game2048.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        bool? isWin;

        public GameControl GameControl { get; set; }

        public bool? IsWin 
        { 
            get => isWin; 
            private set
            {
                if (BannerControl.Value == 2048)
                {
                    isWin = true;
                } 
                else
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            if (positionMatrix[x, y] == 0 ||
                                (y < 3 && positionMatrix[x, y] == positionMatrix[x, y + 1]) ||
                                (x < 3 && positionMatrix[x, y] == positionMatrix[x + 1, y]))
                            {
                                isWin = null;
                            }
                            else
                            {
                                isWin = false;
                            }    
                        }
                    }
                }    
            }
        }

        void DisplayOnScreen()
        {
            // Get all children in scene (includes lights and cubes)
            var children = GameControl.Scene.SceneContainer.Children;

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

        public void CreateRandomCube()
        {
            var emptyPositions = new List<int>();

            for (int i = 0; i < 16; i++)
            {
                if (positionMatrix[i / 4, i % 4] == 0)
                {
                    emptyPositions.Add(i);
                }
            }

            int count = emptyPositions.Count;

            if (count > 0)
            {
                int position = emptyPositions[random.Next(0, count - 1)];

                while (positionMatrix[position / 4, position % 4] != 0 && count > 1)
                {
                    emptyPositions.Remove(position);
                    position = emptyPositions[random.Next(0, count - 1)];
                }

                positionMatrix[position / 4, position % 4] = 2;
                DisplayOnScreen();
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveUp();
                    break;
                case Keys.Down:
                    MoveDown();
                    break;
                case Keys.Left:
                    MoveLeft();
                    break;
                case Keys.Right:
                    MoveRight();
                    break;
            }
        }

        void MoveUp()
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

            if (isSuccess)
            {
                MoveControl.Number++;
                ScoreControl.Number = GetScore();

                CreateRandomCube();
                DisplayOnScreen();
            }
        }

        void MoveDown()
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

            if (isSuccess)
            {
                MoveControl.Number++;
                ScoreControl.Number = GetScore();

                CreateRandomCube();
                DisplayOnScreen();
            }
        }

        void MoveLeft()
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

            if (isSuccess)
            {
                MoveControl.Number++;
                ScoreControl.Number = GetScore();

                CreateRandomCube();
                DisplayOnScreen();
            }
        }

        void MoveRight()
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

            if (isSuccess)
            {
                MoveControl.Number++;
                ScoreControl.Number = GetScore();

                CreateRandomCube();
                DisplayOnScreen();
            }
        }
    }
}
