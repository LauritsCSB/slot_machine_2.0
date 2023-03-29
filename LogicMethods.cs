using System;
using SlotMachine2;

namespace slot_machine_2
{
    public class LogicMethods
    {
        public static int[,] FillMatrixWithRandomNumbers(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = Program.randomNumber.Next(0, 3);
                }
            }
            return array;
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
            int matchingNumbers = 0;

            if (Program.numbers2d[0, 0] == Program.numbers2d[1, 1] && Program.numbers2d[1, 1] == Program.numbers2d[2, 2])
            {
                matchingNumbers++;
            }

            if (Program.numbers2d[0, 2] == Program.numbers2d[1, 1] && Program.numbers2d[1, 1] == Program.numbers2d[2, 0])
            {
                matchingNumbers++;
            }

            return matchingNumbers;
        }
    }
}

