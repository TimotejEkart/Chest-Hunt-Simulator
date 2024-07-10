using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chest_Hunt_Simulator
{
    public class Simulation
    {
        private int numberOfSimulations;
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public Simulation(int numberOfSimulations)
        {
            this.numberOfSimulations = numberOfSimulations;
            Wins = 0;
            Losses = 0;
        }

        public void RunSimulations()
        {
            Parallel.For(0, numberOfSimulations, i =>
            {
                var gameManager = new GameManager();
                RunSingleGame(gameManager);

                if (gameManager.HasWon)
                {
                    lock (this)
                    {
                        Wins++;
                    }
                }

                else
                {
                    lock (this)
                    {
                        Losses++;
                    }
                }
            });
        }

        private void RunSingleGame(GameManager gameManager) // opening till x2 then using on saver for optimal results
        {
            bool foundX2 = false;

            for (int i = 0; i < gameManager.Chests.Count; i++)
            {
                if (gameManager.Chests[i].IsOpened)
                {
                    continue;
                }

                if (gameManager.Chests[i].HasX2)
                {
                    foundX2 = true;
                    gameManager.OpenChest(i);
                    break;
                }

                if (!gameManager.Chests[i].HasSaver)
                {
                    gameManager.OpenChest(i);
                }
            }

            if (foundX2)
            {
                for (int i = 0; i < gameManager.Chests.Count; i++)
                {
                    if (gameManager.Chests[i].HasSaver && !gameManager.Chests[i].IsOpened)
                    {
                        gameManager.OpenChest(i);
                        break;
                    }
                }
            }

            for (int i = 0; i < gameManager.Chests.Count; i++)
            {
                if (!gameManager.Chests[i].IsOpened)
                {
                    gameManager.OpenChest(i);
                }
            }
        }

        public void DisplayResults()
        {
            Console.WriteLine($"Simulations: {numberOfSimulations}");
            Console.WriteLine($"Wins: {Wins}");
            Console.WriteLine($"Losses: {Losses}");
        }
    }
}
