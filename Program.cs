using slot_machine_2._0;

namespace SlotMachine2
{
    internal class Program
    {
        const int GAMEMONEY = 100;
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            Dictionary<int, int> playCost = new Dictionary<int, int>
            {
                {1, 1},
                {2, 3},
                {3, 5},
                {4, 2},
                {5, 4},
                {6, 5}
            };
            Dictionary<int, int> payout = new Dictionary<int, int>
            {
                {1, 3},
                {2, 12},
                {3, 25},
                {4, 6},
                {5, 20},
                {6, 50}
            };
            int playPicker;
            int gameMoney = GAMEMONEY;
            int userBet;
            int[,] numbers2d = new int[3, 3];
            string playOrNo = "y";

            UIMethods.DisplayWelcomeMessage();
            do
            {
                bool winOrLoose = false;
                UIMethods.DisplayPlayOptions();
                
                if (int.TryParse(Console.ReadLine(), out playPicker))
                {
                    if (playCost.ContainsKey(playPicker))
                    {
                        gameMoney -= playCost[playPicker];    
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    Console.Clear();
                    continue;
                }

                Console.Clear();

                //Fills 2d array with random numbers
                for (int row = 0; row < numbers2d.GetLength(0); row++)
                {
                    for (int column = 0; column < numbers2d.GetLength(1); column++)
                    {
                        numbers2d[row, column] = randomNumber.Next(0, 3);
                    }
                }

                //Writes numbers in matrix to user
                for (int row = 0; row < numbers2d.GetLength(0); row++)
                {
                    for (int column = 0; column < numbers2d.GetLength(1); column++)
                    {
                        Console.Write(numbers2d[row, column] + " ");
                    }
                    Console.WriteLine();
                }

                int matchingNumbers = 0;
                int matchingLines = 0;
                //Checking rows
                if (playPicker == 1 || playPicker == 2 || playPicker == 3)
                {
                    for (int row = 0; row < numbers2d.GetLength(0); row++)
                    {
                        matchingNumbers = 0;
                        for (int column = 0; column < numbers2d.GetLength(1); column++)
                        {
                            if (numbers2d[row, 0] == numbers2d[row, column])
                            {
                                matchingNumbers++;
                            }

                        }
                        if (matchingNumbers == 3)
                        {
                            matchingLines++;
                        }
                    }

                    if (matchingLines >= playPicker)
                    {
                        winOrLoose = true;
                    }
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
                    gameMoney += payout[playPicker];
                }

                //Outputs gamemoney
                UIMethods.OutputGamemoney(gameMoney);

                //Asks for new round
                playOrNo = UIMethods.PlayAgain();

                Console.Clear();
            } while (gameMoney > 0 && playOrNo.Contains("y"));

            UIMethods.GameOverMessage(gameMoney);
        }
    }
}