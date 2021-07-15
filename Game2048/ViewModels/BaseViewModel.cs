using Game2048.Views.Controls;
using System;

namespace Game2048.ViewModels
{
    class BaseViewModel
    {
        protected readonly Random random = new();
        protected readonly int[,] positionMatrix = new int[4, 4];

        public BannerControl BannerControl { get; set; }
        public CameraControl CameraControl { get; set; }
        public TextControl ScoreControl { get; set; }
        public TextControl MoveControl { get; set; }

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

        protected int GetScore()
        {
            foreach (var positionValue in positionMatrix)
            {
                ScoreControl.Number += positionValue;

                if (positionValue > BannerControl.Value)
                {
                    BannerControl.Value = positionValue;
                }
            }

            return ScoreControl.Number;
        }
    }
}
