//TODO Make for loop checking if numbers are the same, start a certain index to check different rows/ columns
//TODO Change rules to make the user bet on certain amount of lines or rows, the more they bet on, the higher the cost but also reward


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
            int[] possiblePlays = new int[] { 1, 2, 3, 7 };
            string winMessage = "Win!";
            string lossMessage = "No win..";
            string playOrNo = "y";

            Console.WriteLine("Hello user, this is a slot machine. You can choose to make a bet on 1-3 rows, columns or diagonals. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the price! You start with $100 dollars.";);
            do
            {
                //Lets user pick what to bet on
                Console.WriteLine("Pick 1 if you choose to bet on one row or column, 2 is for two etc. Numbers 4, 5 and 6 arent supported. If you pick 7 you'll bet on diagonals. " +
                "Please enter your pick and press enter: ";);
                if (int.TryParse(Console.ReadLine(), out playPicker))
                {
                    Console.WriteLine($"You've picked: {playPicker}");
                }
                else
                {
                    Console.WriteLine("No pick detected.");
                    continue;
                }

                //Checks if user input is supperted by program
                if (!Array.Exists(possiblePlays, element => element == playPicker))
                {
                    Console.WriteLine("Invalid pick, try again.");
                    continue;
                }

                //Takes user bet
                Console.WriteLine("How much would you like to bet?";);
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
                        numbers2d[column, row] = randomNumber.Next(1, 10);
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

                //Checking one row/ column
                if (playPicker == 1 || playPicker == 2 || playPicker == 3)
                {
                    int counter = 0;
                    if (numbers2d[0, 0] == numbers2d[0, 1] && numbers2d[0, 1] == numbers2d[0, 2])
                    {
                        counter++;
                    }

                    if (numbers2d[1, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[1, 2])
                    {
                        counter++;
                    }

                    if (numbers2d[2, 0] == numbers2d[2, 1] && numbers2d[2, 1] == numbers2d[2, 2])
                    {
                        counter++;
                    }

                    if (numbers2d[0, 0] == numbers2d[1, 0] && numbers2d[1, 0] == numbers2d[2, 0])
                    {
                        counter++;
                    }

                    if (numbers2d[0, 1] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 1])
                    {
                        counter++;
                    }

                    if (numbers2d[0, 2] == numbers2d[1, 2] && numbers2d[1, 2] == numbers2d[2, 2])
                    {
                        counter++;
                    }

                    if (counter == 1)
                    {
                        gameMoney += (userBet * 2);
                        Console.WriteLine(winMessage);
                    }
                    else if (counter == 2)
                    {
                        gameMoney += (userBet * 3);
                        Console.WriteLine(winMessage);
                    }
                    else if (counter > 3)
                    {
                        gameMoney += (userBet * 4);
                        Console.WriteLine(winMessage);
                    }
                    else
                    {
                        Console.WriteLine(lossMessage);
                    }
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
                Console.WriteLine("Would you like to play again?, press y for yes and anything else for no, press enter";);
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