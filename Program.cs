using System.Collections.ObjectModel;
using slot_machine_2;

namespace SlotMachine2
{
    internal class Program
    {
        public static readonly ReadOnlyDictionary<int, int> PlayCost = new ReadOnlyDictionary<int, int>(
            new Dictionary<int, int>
            {
                {1, 1},
                {2, 3},
                {3, 5},
                {4, 2},
                {5, 4},
                {6, 5}
            });

        public static readonly ReadOnlyDictionary<int, int> Payout = new ReadOnlyDictionary<int, int>(
            new Dictionary<int, int>
            {
                {1, 3},
                {2, 12},
                {3, 25},
                {4, 6},
                {5, 20},
                {6, 50}
            });
        const int GAMEMONEY = 100;
        public static int playPicker;
        public static int[,] numbers2d = new int[3, 3];
        public static Random randomNumber = new Random();
        static void Main(string[] args)
        {
            int gameMoney = GAMEMONEY;
            string playOrNo = "y";

            UIMethods.WelcomeMessage();
            do
            {
                playPicker = 0;
                bool winOrLoose = false;

                while (!Program.PlayCost.ContainsKey(playPicker))
                {
                    UIMethods.PlayOptions();
                    playPicker = UIMethods.PlayInput();
                    UIMethods.ClearConsole();
                }

                gameMoney -= PlayCost[playPicker];

                LogicMethods.FillMatrixWithRandomNumbers(numbers2d);

                UIMethods.NumbersMatrix(numbers2d);

                int matchingNumbers = 0;
                int matchingLines = 0;
                
                if (playPicker == 1 || playPicker == 2 || playPicker == 3)
                {
                    matchingLines = LogicMethods.CheckRows(numbers2d);
                }

                if (matchingLines >= playPicker)
                {
                    winOrLoose = true;
                }

                //Checking columns
                if (playPicker == 4 || playPicker == 5)
                {
                    for (int column = 0; column < numbers2d.GetLength(1); column++)
                    {
                        matchingNumbers = 0;
                        for (int row = 0; row < numbers2d.GetLength(0); row ++)
                        {
                            if (numbers2d[0, column] == numbers2d[row, column])
                            {
                                matchingNumbers++;
                            }
                        }

                        if (matchingNumbers == 3)
                        {
                            matchingLines++;
                        }
                    }

                    if (matchingLines >= 1 && playPicker == 4)
                    {
                        winOrLoose = true;
                    }
                    else if (matchingLines >= 2 && playPicker == 5)
                    {
                        winOrLoose = true;
                    }
                }

                //Checking diagonal lines
                if (playPicker == 6)
                {
                    if (numbers2d[0, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 2])
                    {
                        matchingNumbers++;
                    }

                    if (numbers2d[0, 2] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 0])
                    {
                        matchingNumbers++;
                    }

                    if (matchingNumbers >= 2)
                    {
                        winOrLoose = true;
                    }
                }

                UIMethods.WinOrLooseMessage(winOrLoose);

                if (winOrLoose)
                {
                    gameMoney += Program.Payout[playPicker];
                }

                UIMethods.Gamemoney(gameMoney);

                playOrNo = UIMethods.AskForReplay();

                UIMethods.ClearConsole();
            } while (gameMoney > 0 && playOrNo.Contains("y"));

            UIMethods.GameOverMessage(gameMoney);
        }
    }
}