using System;
using System.Collections.Generic;
using System.Linq;

namespace Chest_Hunt_Simulator
{
    public class Chest
    {
        public bool IsMimic { get; set; }
        public bool IsOpened { get; set; }
        public bool HasSaver { get; set; }
        public bool HasX2 { get; set; }
        public bool IsSafed { get; set; }

        public Chest(bool isMimic, bool hasSaver = false, bool hasX2 = false)
        {
            IsMimic = isMimic;
            HasSaver = hasSaver;
            HasX2 = hasX2;
            IsOpened = false;
            IsSafed = false;
        }
    }

    public class GameManager
    {
        public List<Chest> Chests { get; private set; }
        public int SaverCount { get; private set; }
        public int InitialSaverUses { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool HasWon { get; private set; }
        public bool X2Active { get; private set; }

        private Random random = new Random();

        public GameManager()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            Chests = new List<Chest>();
            SaverCount = 1;
            InitialSaverUses = 2;
            IsGameOver = false;
            HasWon = false;
            X2Active = false;
            InitializeChests();
        }

        // PREPARING GAME 

        private void InitializeChests()
        {
            Random random = new Random();
            int mimicCount = 0;
            int saverChestIndex = random.Next(30);
            int x2ChestIndex;

            do
            {
                x2ChestIndex = random.Next(30);
            } while (x2ChestIndex == saverChestIndex);

            for (int i = 0; i < 30; i++)
            {
                bool isMimic = false;
                bool hasSaver = false;
                bool hasX2 = false;

                if (i == saverChestIndex)
                {
                    hasSaver = true;
                }

                else if (i == x2ChestIndex)
                {
                    hasX2 = true;
                }

                else if (mimicCount < 4 && random.NextDouble() < 0.2)
                {
                    isMimic = true;
                    mimicCount++;
                }

                Chests.Add(new Chest(isMimic, hasSaver, hasX2));
            }

            while (mimicCount < 4)
            {
                int index = random.Next(30);

                if (!Chests[index].IsMimic && !Chests[index].HasSaver && !Chests[index].HasX2)
                {
                    Chests[index].IsMimic = true;
                    mimicCount++;
                }
            }
        }

        // LOGIC FOR OPENING CHESTS

        public void OpenChest(int index)
        {
            if (IsGameOver || index < 0 || index >= Chests.Count || Chests[index].IsOpened)
            {
                return;
            }

            Chests[index].IsOpened = true;

            if (Chests[index].HasX2)
            {
                X2Active = true;
                return;
            }

            if (Chests[index].HasSaver)
            {
                SaverCount += X2Active ? 2 : 1;
                X2Active = false;
                return;
            }

            if (Chests[index].IsMimic)
            {
                if (random.NextDouble() <= 0.03) // 3% chance for killing mimic (SUCKER PUNCH, NINJA GLOVES, AN ACE UP MY SLEEVE ITEMS)
                {
                    OnSuckerPunch();
                    Chests[index].IsMimic = false; 
                    return;
                }

                if (SaverCount > 0)
                {
                    SaverCount--;

                    Chests[index].IsSafed = true;

                    if (InitialSaverUses > 0)
                    {
                        InitialSaverUses = 0;
                    }
                }

                else
                {
                    IsGameOver = true;
                    return;
                }
            }

            else
            {
                if (InitialSaverUses > 0)
                {
                    InitialSaverUses--;

                    if (InitialSaverUses == 0)
                    {
                        SaverCount--;
                    }
                }
            }

            X2Active = false;
            CheckWinCondition();
        }

        public event Action SuckerPunchEvent;

        protected virtual void OnSuckerPunch()
        {
            SuckerPunchEvent?.Invoke();
        }

        private void CheckWinCondition()
        {
            HasWon = Chests.All(chest => chest.IsOpened || chest.IsMimic || chest.HasSaver || chest.HasX2);

            if (HasWon)
            {
                IsGameOver = true;
            }
        }

        // WIN PERCENTAGE BY RUNNING SIMULATIONS

        public double CalculateWinOdds()
        {
            int simulations = 20000;
            int wins = 0;

            for (int i = 0; i < simulations; i++)
            {
                if (SimulateGame())
                {
                    wins++;
                }
            }

            return (double)wins / simulations;
        }

        private bool SimulateGame()
        {
            GameManager simulatedGame = new GameManager();
            simulatedGame.Chests = Chests.Select(chest => new Chest(chest.IsMimic, chest.HasSaver, chest.HasX2) { IsOpened = chest.IsOpened, IsSafed = chest.IsSafed }).ToList();
            simulatedGame.SaverCount = SaverCount;
            simulatedGame.InitialSaverUses = InitialSaverUses;
            simulatedGame.X2Active = X2Active;
            simulatedGame.IsGameOver = IsGameOver;
            simulatedGame.HasWon = HasWon;

            while (!simulatedGame.IsGameOver)
            {
                List<int> availableChests = simulatedGame.Chests.Select((chest, index) => new { chest, index })
                                                                 .Where(x => !x.chest.IsOpened)
                                                                 .Select(x => x.index)
                                                                 .ToList();

                if (availableChests.Count == 0)
                {
                    break;
                }

                int nextChest = availableChests[random.Next(availableChests.Count)];
                simulatedGame.OpenChest(nextChest);
            }

            return simulatedGame.HasWon;
        }
    }
}
