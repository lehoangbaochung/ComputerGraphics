using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Game2048.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public GameViewModel gameViewModel;
        public CameraViewModel cameraViewModel;

        protected readonly Random random = new();
        protected readonly int[,] positionMatrix = new int[4, 4];

        protected static float Translate(int position)
        {
            return position switch
            {
                0 => -7.5f,
                1 => -2.5f,
                2 => 2.5f,
                3 => 7.5f,
                _ => position,
            };
        }

        public MainViewModel() { CreateRandomCube(); }

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
                //Display();
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    gameViewModel.MoveUp();
                    break;
                case Keys.Down:
                    gameViewModel.MoveDown();
                    break;
                case Keys.Left:
                    gameViewModel.MoveLeft();
                    break;
                case Keys.Right:
                    gameViewModel.MoveRight();
                    break;
            }

            
        }
    }
}
