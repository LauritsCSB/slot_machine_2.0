using System;
using SlotMachine2;

namespace slot_machine_2
{
    public class LogicMethods
    {
        public static Random randomNumber = new Random();

        public static int[,] FillMatrixWithRandomNumbers(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = randomNumber.Next(0, 3);
                }
            }
            return array;
        }

        public static bool CheckMatrix(int playmode)
        {
            int matchingLines = 0;
            bool winOrLoose = false;

            if (playmode <= 3)
            {
                matchingLines = Rows(Program.numbers2d);

                winOrLoose = WinDecider(matchingLines, playmode);
            }
            else if (playmode <= 5)
            {
                matchingLines = Columns(Program.numbers2d);

                winOrLoose = WinDecider(matchingLines, playmode);
            }
            else
            {
                matchingLines = Diagonals(Program.numbers2d);

                winOrLoose = WinDecider(matchingLines, playmode);
            }

            return winOrLoose;
        }

        static bool WinDecider(int matchingLines, int playmode )
        {
            bool winOrLoose = false;

            if (playmode <= 3)
            {
                if (matchingLines >= playmode)
                {
                    winOrLoose = true;
                }
            }
            else if (playmode <= 5)
            {
                if (matchingLines >= 1 && playmode == 4)
                {
                    winOrLoose = true;
                }
                else if (matchingLines >= 2 && playmode == 5)
                {
                    winOrLoose = true;
                }
            }
            else
            {
                if (matchingLines >= 2 && playmode == 6)
                {
                    winOrLoose = true;
                }
            }

            return winOrLoose;
        }

        public static int Rows(int[,] array)
        {
            int matchingLines = 0;

            for (int row = 0; row < Program.numbers2d.GetLength(0); row++)
            {
                int matchingNumbers = 0;
                for (int column = 0; column < Program.numbers2d.GetLength(1); column++)
                {
                    if (Program.numbers2d[row, 0] == Program.numbers2d[row, column])
                    {
                        matchingNumbers++;
                    }

                }
                if (matchingNumbers == 3)
                {
                    matchingLines++;
                }
            }
            return matchingLines;
        }

        public static int Columns(int[,] array)
        {
            int matchingLines = 0;

            for (int column = 0; column < Program.numbers2d.GetLength(1); column++)
            {
               int matchingNumbers = 0;

                for (int row = 0; row < Program.numbers2d.GetLength(0); row++)
                {
                    if (Program.numbers2d[0, column] == Program.numbers2d[row, column])
                    {
                        matchingNumbers++;
                    }
                }

                if (matchingNumbers == 3)
                {
                    matchingLines++;
                }
            }
            return matchingLines;
        }

        public static int Diagonals(int[,] array)
        {
            int matchingLines = 0;

            if (Program.numbers2d[0, 0] == Program.numbers2d[1, 1] && Program.numbers2d[1, 1] == Program.numbers2d[2, 2])
            {
                matchingLines++;
            }

            if (Program.numbers2d[0, 2] == Program.numbers2d[1, 1] && Program.numbers2d[1, 1] == Program.numbers2d[2, 0])
            {
                matchingLines++;
            }

            return matchingLines;
        }
    }
}

