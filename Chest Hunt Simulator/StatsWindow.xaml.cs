using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Chest_Hunt_Simulator
{
    public partial class StatsWindow : Window
    {
        public StatsWindow()
        {
            InitializeComponent();
        }

        private void CalculateStatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PlayedGamesTextBox.Text, out int playedGames) && int.TryParse(WinsTextBox.Text, out int wins))
            {
                if (playedGames < wins)
                {
                    MessageBox.Show("Wins cannot be greater than played games.");
                    return;
                }

                double winRate = (double)wins / playedGames;
                double expectedWinRate = 0.01637675;

                StatsResultTextBlock.Inlines.Clear();

                Run playedGamesRun = new Run($"Played Games: {playedGames}\n");
                Run winsRun = new Run($"Wins: {wins}\n");
                Run winRateRun = new Run($"Win Rate: {winRate:P2}\n");

                Run resultRun = new Run();

                if (winRate > expectedWinRate)
                {
                    resultRun.Text = "Above average!";
                    resultRun.Foreground = Brushes.Green;
                }

                else if (winRate < expectedWinRate)
                {
                    resultRun.Text = "Below average!";
                    resultRun.Foreground = Brushes.Red;
                }

                else
                {
                    resultRun.Text = "Your stats are average.";
                }

                StatsResultTextBlock.Inlines.Add(playedGamesRun);
                StatsResultTextBlock.Inlines.Add(winsRun);
                StatsResultTextBlock.Inlines.Add(winRateRun);
                StatsResultTextBlock.Inlines.Add(resultRun);
            }

            else
            {
                MessageBox.Show("Please enter valid whole numbers for played games and wins.");
            }
        }

        private void StatsWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
