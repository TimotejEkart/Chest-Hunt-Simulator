using System.Windows;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;

namespace Chest_Hunt_Simulator
{
    public partial class GraphWindow : Window
    {
        public GraphWindow(int wins, int losses)
        {
            InitializeComponent();

            int allGames = wins + losses;
            double winPercentage = (double)wins / allGames * 100;
            double lossPercentage = (double)losses / allGames * 100;

            var seriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"Wins {winPercentage:F2}%",
                    Values = new ChartValues<int> { wins },
                    Fill = System.Windows.Media.Brushes.Green,
                    DataLabels = true
                },

                new ColumnSeries
                {
                    Title = $"Losses {lossPercentage:F2}%",
                    Values = new ChartValues<int> { losses },
                    Fill = System.Windows.Media.Brushes.Red,
                    DataLabels = true
                }
            };

            SimulationChart.Series = seriesCollection;
            SimulationChart.AxisX[0].Labels = new[] { "Wins", "Losses" };
            SimulationChart.AxisX[0].Title = "Result";
            SimulationChart.AxisY[0].Title = "Count";

            SimulationChart.LegendLocation = LegendLocation.Right;
            SimulationChart.DisableAnimations = true;

            foreach (var series in seriesCollection)
            {
                series.LabelPoint = point => $"{point.Y}";
            }
        }

        private void GraphWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
