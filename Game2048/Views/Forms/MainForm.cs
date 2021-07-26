using ComputerGraphics.Views.Forms;
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
                gameViewModel = new GameViewModel(gameControl3D)
                {
                    BannerControl = bannerControl,
                    ScoreControl = scoreControl,
                    MoveControl = moveControl
                },
                cameraViewModel = new CameraViewModel(gameControl2D),
            };

            // Delegate KeyUp event for view model
            KeyUp += viewModel.KeyUp;
        }  
    }
}
