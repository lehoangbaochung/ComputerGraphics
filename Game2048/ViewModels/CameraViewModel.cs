using Game2048.Views.Controls;

namespace Game2048.ViewModels
{
    class CameraViewModel : BaseViewModel
    {
        readonly CameraControl cameraControl;

        public CameraViewModel(CameraControl cameraControl)
        {
            this.cameraControl = cameraControl;
        }

        void Display()
        {
            for (int i = 0; i < positionMatrix.Length; i++)
            {
                var x = i / 4;
                var y = i % 4;

                if (positionMatrix[x, y] != 0)
                {
                    
                }
            }
        }
    }
}
