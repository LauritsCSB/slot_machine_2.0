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

        public static int CheckRows(int[,] array)
        {
            int matchingLines = 0;
            int matchingNumbers = 0;

            for (int row = 0; row < Program.numbers2d.GetLength(0); row++)
            {
                matchingNumbers = 0;
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

        public static int CheckColumns(int[,] array)
        {
            int matchingLines = 0;
            int matchingNumbers = 0;
            for (int column = 0; column < Program.numbers2d.GetLength(1); column++)
            {
                matchingNumbers = 0;
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
    }
}

