using System.Windows.Forms;
using Game2048.ViewModels;

namespace Game2048.Views.Forms
{
    public partial class MainForm : Form
    {
        static MainViewModel viewModel;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();            
        }

        /// <summary>
        /// Initialize the game
        /// </summary>
        void InitializeGame()
        {
            // Set text for controls
            moveControl.Character = "Move";
            scoreControl.Character = "Score";

            // Initialize view model
            viewModel = new MainViewModel()
            {
                BannerControl = bannerControl,
                CameraControl = gameControl2D,
                GameControl = gameControl3D,
                MoveControl = moveControl,
                ScoreControl = scoreControl
            };

            // Delegate KeyUp event for view model
            KeyUp += viewModel.KeyUp;
            
            // Create a random cube then display it on the screen
            viewModel.CreateRandomCube();
        }  
    }
}
