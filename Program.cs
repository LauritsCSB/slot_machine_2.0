//TODO Change program to make the user play on: center row, all three rows or diagonal lines,
//work out from existing for loop checking middle row, iterate +2 for checking diagonals


namespace SlotMachine2
{
    internal class Program
    {
        const int GAMEMONEY = 100;
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            Dictionary<int, int> Playlist = new Dictionary<int, int>();
            Playlist.Add(1, 1);
            Playlist.Add(2, 3);
            Playlist.Add(3, 5);
            Playlist.Add(4, 2);
            Playlist.Add(5, 4);
            Playlist.Add(6, 5);
            Dictionary<int, int> Payout = new Dictionary<int, int>();
            Payout.Add(1, 3);
            Payout.Add(2, 12);
            Payout.Add(3, 25);
            Payout.Add(4, 6);
            Payout.Add(5, 20);
            Payout.Add(6, 50);
            int playPicker;
            int gameMoney = GAMEMONEY;
            int userBet;
            int[,] numbers2d = new int[3, 3];
            string winMessage = "Win!";
            string lossMessage = "No win..";
            string playOrNo = "y";

            Console.WriteLine("Hello user, this is a slot machine. You can choose to bet on what you think the matrix will show. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the price! You start with $100 dollars.\n");
            do
            {
                //Lets user pick what to bet on
                Console.WriteLine("Here's the possible play options:\n1. One row ($1 cost, 3x reward)\n2. Two rows ($3 cost, 4x reward)\n3. " +
                    "All rows ($5 cost, 5x reward)\n4. One column  (2$ cost, 3x reward)\n5. Two columns ($4 cost 5x reward)\n6. Diagonal lines ($5 cost, 10x reward)");
                if (int.TryParse(Console.ReadLine(), out playPicker))
                {
                    if (Playlist.ContainsKey(playPicker))
                    {
                        gameMoney -= Playlist[playPicker];    
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
                for (int column = 0; column < numbers2d.GetLength(0); column++)
                {
                    for (int row = 0; row < numbers2d.GetLength(1); row++)
                    {
                        numbers2d[column, row] = randomNumber.Next(0, 3);
                    }
                }

                //Writes numbers in matrix to user
                for (int column = 0; column < numbers2d.GetLength(0); column++)
                {
                    for (int row = 0; row < numbers2d.GetLength(1); row++)
                    {
                        Console.Write(numbers2d[column, row] + " ");
                    }
                    Console.WriteLine();
                }

                int matchingNumbers = 0;
                int matchingLines = 0;
                //Checking rows
                if (playPicker == 1 || playPicker == 2 || playPicker == 3)
                {
                    for (int row = 0; row < numbers2d.GetLength(1); row++)
                    {
                        matchingNumbers = 0;
                        for (int column = 0; column < numbers2d.GetLength(1); column++)
                        {
                            if (numbers2d[row, 0] == numbers2d[row, column])
                            {
                                matchingNumbers++;
                            }

                            if (matchingNumbers == 3)
                            {
                                matchingLines++;
                            }
                        }
                    }

                    if (matchingLines == 1 && playPicker == 1)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else if (matchingLines == 2 && playPicker == 2)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else if (matchingLines == 3 && playPicker == 3)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
                }

                //Checking columns
                if (playPicker == 4 || playPicker == 5)
                {
                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbers2d.GetLength(1); j += 3)
                        {
                            if (numbers2d[0, 0] == numbers2d[i, j])
                            {
                                matchingNumbers++;
                            }
                        }

                        if (matchingNumbers == 3)
                        {
                            matchingLines++;
                        }
                    }

                    matchingNumbers = 0;
                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 1; j < numbers2d.GetLength(1); j += 3)
                        {
                            if (numbers2d[0, 1] == numbers2d[i, j])
                            {
                                matchingNumbers++;
                            }
                        }

                        if (matchingNumbers == 3)
                        {
                            matchingLines++;
                        }
                    }

                    matchingNumbers = 0;
                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 2; j < numbers2d.GetLength(1); j += 3)
                        {
                            if (numbers2d[0, 2] == numbers2d[i, j])
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
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else if (matchingLines >= 2 && playPicker == 5)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
                }

                //Checking diagonal lines
                if (playPicker == 6)
                {
                    if (numbers2d[0, 0].Equals(numbers2d[1, 1]) && numbers2d[1, 1].Equals(numbers2d[2, 2]))
                    {
                        matchingNumbers++;
                    }

                    if (numbers2d[0, 2].Equals(numbers2d[1, 1]) && numbers2d[1, 1].Equals(numbers2d[2, 0]))
                    {
                        matchingNumbers++;
                    }

                    if (matchingNumbers == 2)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += Payout[playPicker];
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
                }
                
                //Outputs gamemoney
                Console.WriteLine("$" + gameMoney);

                //Asks for new round
                Console.WriteLine("Would you like to play again?, press y for yes and anything else for no, press enter");
                playOrNo = Console.ReadLine();

                Console.Clear();
            } while (gameMoney > 0 && playOrNo.Contains("y"));

            if (gameMoney > 0)
            {
                Console.WriteLine($"Congratulations! You won: {gameMoney}");
            }
            else
            {
                Console.WriteLine("Sorry, you've lost. See you next time!");
            }
        }
    }
}