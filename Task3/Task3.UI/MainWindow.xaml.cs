namespace Task3.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //todo: move constants to config or settings
            var gameFieldViewModel = new GameBoardViewModel(9, 9, 10);

            GameFieldViewModel.ItemsSource = gameFieldViewModel.Cells;
        }
    }
}