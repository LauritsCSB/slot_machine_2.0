using System;
using SlotMachine2;

namespace slot_machine_2
{
    public static class UIMethods
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Hello user, this is a slot machine. You can choose to bet on what you think the matrix will show. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the payout! You start with $100 dollars.\n");
        }

        public static void PrintPlaymodes()
        {
            Console.WriteLine($"Here's the possible play options:\n1. One row ($1 cost, ${Program.Payout[1]} reward)\n2. Two rows ($3 cost, ${Program.Payout[2]} reward)\n3. " +
                    $"All rows ($5 cost, ${Program.Payout[3]} reward)\n4. One column  (2$ cost, ${Program.Payout[4]} reward)\n5. Two columns ($4 cost ${Program.Payout[5]} reward)\n6. Diagonal lines ($5 cost, ${Program.Payout[6]} reward)");
        }

        public static int TakePlayInput()
        {
            int playPick;
            int.TryParse(Console.ReadLine(), out playPick);
            
            return playPick;
        }

        public static void PrintNumbersMatrix(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    Console.Write(array[row, column] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintGamemoney(int money)
        {
            Console.WriteLine("$" + money);
        }

        public static string TakeReplayInput()
        {
            string userAnswer = "y";
            Console.WriteLine("Would you like to play again?, press y for yes and anything else for no, press enter");
            userAnswer = Console.ReadLine();
            return userAnswer;
        }

        public static void PrintGameOverMessage(int money)
        {
            if (money > 0)
            {
                Console.WriteLine($"Congratulations! You won: {money}");
            }
            else
            {
                Console.WriteLine("Sorry, you've lost. See you next time!");
            }
        }

        public static void PrintWinOrLooseMessage(bool winOrNot)
        {
            if (winOrNot)
            {
                Console.WriteLine("Win!");
            }
            else
            {
                Console.WriteLine("No win..");
            }
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }
    }
}

