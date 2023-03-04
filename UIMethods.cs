﻿using System;
using SlotMachine2;

namespace slot_machine_2._0
{
    public static class UIMethods
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Hello user, this is a slot machine. You can choose to bet on what you think the matrix will show. " +
                "The more rows, columns and diagonals you choose to bet on, the higher the payout! You start with $100 dollars.\n");
        }

        public static void DisplayPlayOptions()
        {
            Console.WriteLine($"Here's the possible play options:\n1. One row ($1 cost, ${Program.PayoutDictionary(1)} reward)\n2. Two rows ($3 cost, ${Program.PayoutDictionary(2)} reward)\n3. " +
                    $"All rows ($5 cost, ${Program.PayoutDictionary(3)} reward)\n4. One column  (2$ cost, ${Program.PayoutDictionary(4)} reward)\n5. Two columns ($4 cost ${Program.PayoutDictionary(5)} reward)\n6. Diagonal lines ($5 cost, ${Program.PayoutDictionary(6)} reward)");
        }
    }
}
