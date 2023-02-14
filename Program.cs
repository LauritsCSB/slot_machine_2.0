﻿//TODO Make for loop checking if numbers are the same, start a certain index to check different rows/ columns
//TODO Change program to make the user play on: center row, all three rows, all horizontal columns or diagonal lines


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
            int[] possiblePlays = new int[] { 1, 2, 3, 4 };
            string winMessage = "Win!";
            string lossMessage = "No win..";
            string playOrNo = "y";

            Console.WriteLine("Hello user, this is a slot machine. You can choose to make a bet on 1-3 rows, columns or diagonals. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the price! You start with $100 dollars.");
            do
            {
                //Lets user pick what to bet on
                Console.WriteLine("Here's the possible play options:\n1. Center row ($1 cost, 2x reward)\n2. " +
                    "All rows ($3 cost, 6x reward)\n3. All columns ($4 cost, 8x reward)\n4. Diagonal lines ($5 cost, 10x reward)");
                if (int.TryParse(Console.ReadLine(), out playPicker))
                {
                    Console.WriteLine($"You've picked: {playPicker}");
                }
                else
                {
                    Console.WriteLine("No pick detected.");
                    continue;
                }

                switch (playPicker)
                {
                    case 1:
                        gameMoney -= 1;
                        break;
                    case 2:
                        gameMoney -= 3;
                        break;
                    case 3:
                        gameMoney -= 4;
                        break;
                    case 4:
                        gameMoney -= 5;
                        break;
                    default:
                        break;
                }

                //Checks if user input is supperted by program
                if (!Array.Exists(possiblePlays, element => element == playPicker))
                {
                    Console.WriteLine("Invalid pick, try again.");
                    continue;
                }

                //Takes user bet
                Console.WriteLine("How much would you like to bet?");
                if (int.TryParse(Console.ReadLine(), out userBet))
                {
                    Console.WriteLine($"Your bet: {userBet}");
                    gameMoney -= userBet;
                }
                else
                {
                    Console.WriteLine("No bet detected.");
                    continue;
                }

                //Checks if user bet is inside bounds of playmoney value
                if (userBet > gameMoney)
                {
                    Console.WriteLine($"Sorry, you only have ${gameMoney} left.");
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

                //Checking middle row
                if (playPicker == 1)
                {
                    int counter = 0;
                    gameMoney -= 1;

                  
                }

                //Checking diagonal
                if (playPicker == 7)
                {
                    int counter = 0;
                    if (numbers2d[0, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 2])
                    {
                        counter++;
                    }

                    if (numbers2d[0, 2] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 0])
                    {
                        counter++;
                    }

                    if (counter > 1)
                    {
                        gameMoney += (userBet * 3);
                        Console.WriteLine(winMessage);
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