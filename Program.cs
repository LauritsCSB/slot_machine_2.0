//TODO Change program to make the user play on: center row, all three rows or diagonal lines,
//work out from existing for loop checking middle row, iterate +2 for checking diagonals


namespace SlotMachine2
{
    internal class Program
    {
        const int GAMEMONEY = 100;
        static void Main(string[] args)
        {
            int playPicker;
            int gameMoney = GAMEMONEY;
            int userBet;
            Random randomNumber = new Random();
            int[,] numbers2d = new int[3, 3];
            int[] possiblePlays = new int[] { 1, 2, 3, 4};
            string winMessage = "Win!";
            string lossMessage = "No win..";
            string playOrNo = "y";
            string gameMoneyError = $"Sorry, you only have {gameMoney} left.";
            string gameMoneyAccept = "Bet taken!";

            Console.WriteLine("Hello user, this is a slot machine. You can choose to make a bet on 1 or 3 rows, 1 or 3 columns or diagonals. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the price! You start with $100 dollars.\n");
            do
            {
                //Lets user pick what to bet on
                Console.WriteLine("Here's the possible play options:\n1. One row ($1 cost, 3x reward)\n2. Two rows ($3 cost, 4x reward)\n3. " +
                    "All rows ($5 cost, 5x reward)\n4. One column  (2$ cost, 3x reward)\n5. Two columns ($4 costm 5x reward)\n6. (Work in progress) Diagonal lines ($5 cost, 10x reward)");
                if (int.TryParse(Console.ReadLine(), out playPicker))
                {
                    Console.WriteLine($"You've picked: {playPicker}");
                }
                else
                {
                    Console.Clear();
                    continue;
                }


                //Checks if user input is supperted by program and withdraws bet from gamemoney
                if (!Array.Exists(possiblePlays, element => element == playPicker))
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    if (playPicker == 1)
                    {
                        if (1 > gameMoney)
                        {
                            Console.WriteLine(gameMoneyError);
                            continue;
                        }
                        else
                        {
                            gameMoney -= 1;
                        }
                    }

                    if (playPicker == 2)
                    {
                        if (3 > gameMoney)
                        {
                            Console.WriteLine(gameMoneyError);
                            continue;
                        }
                        else
                        {
                            gameMoney -= 3;
                        }
                    }

                    if (playPicker == 3)
                    {
                        if (5 > gameMoney)
                        {
                            Console.WriteLine(gameMoneyError);
                            continue;
                        }
                        else
                        {
                            gameMoney -= 5;
                        }
                    }

                    if (playPicker == 4)
                    {
                        if (4 > gameMoney)
                        {
                            Console.WriteLine(gameMoneyError);
                            continue;
                        }
                        else
                        {
                            gameMoney -= 4;
                        }
                    }

                    /*
                    if (playPicker == 4)
                    {
                        if (5 > gameMoney)
                        {
                            Console.WriteLine(gameMoneyError);
                            continue;
                        }
                        else
                        {
                            gameMoney -= 5;
                        }
                    }
                    */
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

                int counter1 = 0;
                int counter2 = 0;
                //Checking rows
                if (playPicker == 1 || playPicker == 2 || playPicker == 3)
                {
                    for (int i = 0; i < numbers2d.GetLength(1); i++)
                    {
                        if (numbers2d[0, 0] == numbers2d[0, i])
                        {
                            counter1++;
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    for (int i = 0; i < numbers2d.GetLength(1); i++)
                    {
                        if (numbers2d[1, 0] == numbers2d[1, i])
                        {
                            counter1++;
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    for (int i = 0; i < numbers2d.GetLength(1); i++)
                    {
                        if (numbers2d[2, 0] == numbers2d[2, i])
                        {
                            counter1++;
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    if (counter2 == 1)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 3;
                    }
                    else if (counter2 == 2)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 12;
                    }
                    else if (counter2 == 3)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 25;
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
                                counter1++;
                            }
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 1; j < numbers2d.GetLength(1); j += 3)
                        {
                            if (numbers2d[0, 1] == numbers2d[i, j])
                            {
                                counter1++;
                            }
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 2; j < numbers2d.GetLength(1); j += 3)
                        {
                            if (numbers2d[0, 2] == numbers2d[i, j])
                            {
                                counter1++;
                            }
                        }

                        if (counter1 == 3)
                        {
                            counter2++;
                        }
                    }

                    if (counter2 == 1)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 6;
                    }
                    else if (counter2 >= 2)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 20;
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
                }

                /*
                //Checking diagonal lines
                if (playPicker == 4)
                {
                    int counter = 0;
                    for (int i = 0; i < numbers2d.GetLength(0); i++)
                    {
                        for (int j = 0; j < numbers2d.GetLength(1); j += 2)
                        {
                            if (numbers2d[0, 1] == numbers2d[i, j])
                            {
                                counter++;
                            }
                        }
                    }

                    if (counter == 5)
                    {
                        Console.WriteLine(winMessage);
                        gameMoney += 50;
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
                }
                */

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