using System;
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
                    array[row, column] = randomNumber.Next(0, 3);
                }
            }
            return array;
        }
    }
}

