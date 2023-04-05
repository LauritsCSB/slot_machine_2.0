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

        public static int CheckValidPlayInput(int playPicker)
        {
            while (!Program.PlayCost.ContainsKey(playPicker))
            {
                UIMethods.PrintPlaymodes();
                playPicker = UIMethods.TakePlayInput();
            }
            return playPicker;
        }

        public static bool CheckMatrix(int playmode, int[,] array)
        {
            int matchingLines = 0;
            bool win = false;

            if (playmode <= 3)
            {
                matchingLines = CheckRows(array);
            }
            else if (playmode <= 5)
            {
                matchingLines = CheckColumns(array);
            }
            else
            {
                matchingLines = CheckDiagonals(array);
            }

            win = WinDecider(matchingLines, playmode);
            return win;
        }

        static bool WinDecider(int matchingLines, int playmode )
        {
            bool win = false;

            if (playmode <= 3)
            {
                if (matchingLines >= playmode)
                {
                    win = true;
                }
            }
            else if (playmode <= 5)
            {
                if (matchingLines >= 1 && playmode == 4)
                {
                    win = true;
                }
                else if (matchingLines >= 2 && playmode == 5)
                {
                    win = true;
                }
            }
            else
            {
                if (matchingLines >= 2 && playmode == 6)
                {
                    win = true;
                }
            }

            return win;
        }

        public static int CheckRows(int[,] array)
        {
            int matchingLines = 0;

            for (int row = 0; row < array.GetLength(0); row++)
            {
                int matchingNumbers = 0;
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    if (array[row, 0] == array[row, column])
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

            for (int column = 0; column < array.GetLength(1); column++)
            {
               int matchingNumbers = 0;

                for (int row = 0; row < array.GetLength(0); row++)
                {
                    if (array[0, column] == array[row, column])
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

        public static int CheckDiagonals(int[,] array)
        {
            int matchingLines = 0;

            if (array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2])
            {
                matchingLines++;
            }

            if (array[0, 2] == array[1, 1] && array[1, 1] == array[2, 0])
            {
                matchingLines++;
            }

            return matchingLines;
        }
    }
}

