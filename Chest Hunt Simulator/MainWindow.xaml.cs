using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Chest_Hunt_Simulator
{
    public partial class MainWindow : Window
    {
        private GameManager gameManager;
        private bool isToggleModeOn = false;
        private int previousSaverCount;
        private Simulation lastSimulation;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
            ToggleModeButton.Content = "Show Visuals";
            previousSaverCount = gameManager.SaverCount;
        }

        private void StartNewGame()
        {
            gameManager = new GameManager();
            gameManager.SuckerPunchEvent += OnSuckerPunch;
            InitializeChestGrid();
            UpdateSaverStatus();
            SuckerPunchStatus.Text = "";
            UpdateWinOdds();
        }

        private void OnSuckerPunch()
        {
            SuckerPunchStatus.Text = "Sucker Punch!";
            SuckerPunchStatus.Foreground = Brushes.Orange;
            var suckerPunchAnimation = (Storyboard)this.Resources["SuckerPunchAnimation"];
            suckerPunchAnimation.Begin();
        }   

        private void InitializeChestGrid()
        {
            ChestGrid.Children.Clear();

            for (int i = 0; i < gameManager.Chests.Count; i++)
            {
                var chestButton = new Button
                {
                    Tag = i,
                    Background = GetChestBackground(gameManager.Chests[i]),
                    BorderBrush = gameManager.Chests[i].HasSaver ? Brushes.Lime : Brushes.Transparent,
                    BorderThickness = gameManager.Chests[i].HasSaver ? new Thickness(3) : new Thickness(0),
                    Margin = new Thickness(5)
                };

                chestButton.Click += ChestButton_Click;

                var chestImage = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/closed_chest.PNG", UriKind.RelativeOrAbsolute)),
                    Width = 50,
                    Height = 50
                };

                chestButton.Content = chestImage;
                ChestGrid.Children.Add(chestButton);
            }
        }

        private void ChestButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Tag is int index)
            {
                gameManager.OpenChest(index);

                UpdateChestGrid();
                UpdateSaverStatus();

                if (gameManager.IsGameOver)
                {
                    DisplayGameOverStatus();
                    RevealAllChests();
                }

                UpdateWinOdds();
            }
        }

        private void RevealAllChests()
        {
            foreach (var chest in gameManager.Chests)
            {
                chest.IsOpened = true;
            }

            UpdateChestGrid();
        }

        private void UpdateChestGrid()
        {
            for (int i = 0; i < gameManager.Chests.Count; i++)
            {
                if (ChestGrid.Children[i] is Button chestButton)
                {
                    UpdateChestButtonAppearance(chestButton, gameManager.Chests[i]);
                }
            }
        }

        private void UpdateChestButtonAppearance(Button chestButton, Chest chest)
        {
            var chestImage = new Image { Width = 50, Height = 50 };

            if (chest.IsOpened)
            {
                chestImage.Source = GetOpenedChestImageSource(chest);
                chestButton.IsEnabled = false;
            }

            else
            {
                chestImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/closed_chest.PNG", UriKind.RelativeOrAbsolute));
            }

            chestButton.Content = chestImage;
            chestButton.BorderBrush = chest.HasSaver ? Brushes.Lime : Brushes.Transparent;
            chestButton.BorderThickness = chest.HasSaver ? new Thickness(3) : new Thickness(0);
            chestButton.Background = GetChestBackground(chest);

            if (gameManager.IsGameOver)
            {
                chestButton.IsEnabled = false;
            }
        }

        private ImageSource GetOpenedChestImageSource(Chest chest)
        {
            if (chest.HasSaver)
                return new BitmapImage(new Uri("pack://application:,,,/Images/saver_chest.PNG", UriKind.RelativeOrAbsolute));

            if (chest.HasX2)
                return new BitmapImage(new Uri("pack://application:,,,/Images/x2_chest.PNG", UriKind.RelativeOrAbsolute));

            if (chest.IsMimic)
                return new BitmapImage(new Uri("pack://application:,,,/Images/mimic_chest.PNG", UriKind.RelativeOrAbsolute));

            return new BitmapImage(new Uri("pack://application:,,,/Images/opened_chest.PNG", UriKind.RelativeOrAbsolute));
        }

        private Brush GetChestBackground(Chest chest)
        {
            if (isToggleModeOn && chest.IsMimic && !chest.IsOpened)
                return new SolidColorBrush(Color.FromArgb(120, 255, 0, 0));

            if (isToggleModeOn && chest.HasX2 && !chest.IsOpened)
                return new SolidColorBrush(Color.FromArgb(120, 0, 204, 204));

            return Brushes.Transparent;
        }

        private void UpdateSaverStatus()
        {
            SaverStatus.Text = gameManager.InitialSaverUses > 0
                ? $"Savers: {gameManager.SaverCount} (Crystal Saver Uses Remaining: {gameManager.InitialSaverUses})"
                : $"Savers: {gameManager.SaverCount}";

            if (gameManager.SaverCount < previousSaverCount)
            {
                TriggerSaverUsedAnimation();
            }

            previousSaverCount = gameManager.SaverCount;
        }

        private void TriggerSaverUsedAnimation()
        {
            var saverUsedAnimation = (Storyboard)this.Resources["SaverUsedAnimation"];
            saverUsedAnimation.Begin();
        }

        private void UpdateWinOdds()
        {
            double winOdds = gameManager.CalculateWinOdds();
            WinOddsStatus.Text = $"Odds of Winning: {winOdds:P2}";
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void HowItWorksButton_Click(object sender, RoutedEventArgs e)
        {
            var instructionsWindow = new InstructionsWindow { Owner = this };
            instructionsWindow.ShowDialog();
        }

        private async void RunSimulationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(SimulationCountTextBox.Text, out int simulationCount) && simulationCount > 0)
                {
                    RunSimulationButton.IsEnabled = false;
                    SimulationResults.Text = "Running simulations...";
                    lastSimulation = new Simulation(simulationCount);

                    await Task.Run(() => lastSimulation.RunSimulations());

                    SimulationResults.Text = $"Simulations: {simulationCount}\nPerfect Chest Hunts: {lastSimulation.Wins}\nLosses: {lastSimulation.Losses}";
                    RunSimulationButton.IsEnabled = true;
                }

                else
                {
                    MessageBox.Show("Please enter a valid whole number of simulations.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void ToggleModeButton_Click(object sender, RoutedEventArgs e)
        {
            isToggleModeOn = !isToggleModeOn;
            ToggleModeButton.Content = isToggleModeOn ? "Hide Visuals" : "Show Visuals";
            UpdateChestGrid();
        }

        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            var statsWindow = new StatsWindow { Owner = this };
            statsWindow.ShowDialog();
        }

        private void GraphButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastSimulation != null)
            {
                var graphWindow = new GraphWindow(lastSimulation.Wins, lastSimulation.Losses) { Owner = this };
                graphWindow.ShowDialog();
            }

            else
            {
                MessageBox.Show("Please run a simulation first.");
            }
        }

        private void DisplayGameOverStatus()
        {
            SuckerPunchStatus.Text = gameManager.HasWon ? "You won!" : "You lost!";
            SuckerPunchStatus.Foreground = gameManager.HasWon ? Brushes.Green : Brushes.Red;
        }
    }
}
