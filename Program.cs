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
            Dictionary<int, int> playCost = new Dictionary<int, int>();
            playCost.Add(1, 1);
            playCost.Add(2, 3);
            playCost.Add(3, 5);
            playCost.Add(4, 2);
            playCost.Add(5, 4);
            playCost.Add(6, 5);
            Dictionary<int, int> payout = new Dictionary<int, int>();
            payout.Add(1, 3);
            payout.Add(2, 12);
            payout.Add(3, 25);
            payout.Add(4, 6);
            payout.Add(5, 20);
            payout.Add(6, 50);
            int playPicker;
            int gameMoney = GAMEMONEY;
            int userBet;
            int[,] numbers2d = new int[3, 3];
            string winMessage = "Win!";
            string lossMessage = "No win..";
            string playOrNo = "y";

            Console.WriteLine("Hello user, this is a slot machine. You can choose to bet on what you think the matrix will show. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the payout! You start with $100 dollars.\n");
            do
            {
                bool winOrLoose = false;
                //Lets user pick what to bet on
                Console.WriteLine($"Here's the possible play options:\n1. One row ($1 cost, ${payout[1]} reward)\n2. Two rows ($3 cost, ${payout[2]} reward)\n3. " +
                    $"All rows ($5 cost, ${payout[3]} reward)\n4. One column  (2$ cost, ${payout[4]} reward)\n5. Two columns ($4 cost ${payout[5]} reward)\n6. Diagonal lines ($5 cost, ${payout[6]} reward)");
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

                if (winOrLoose)
                {
                    Console.WriteLine(winMessage);
                    gameMoney += payout[playPicker];
                }
                else
                {
                    Console.WriteLine(lossMessage);
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