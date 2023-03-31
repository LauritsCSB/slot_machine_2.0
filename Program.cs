using System.Collections.ObjectModel;
using slot_machine_2;

namespace SlotMachine2
{
    internal class Program
    {
        public static readonly ReadOnlyDictionary<int, int> PlayCost = new ReadOnlyDictionary<int, int>(
            new Dictionary<int, int>
            {
                {1, 1},
                {2, 3},
                {3, 5},
                {4, 2},
                {5, 4},
                {6, 5}
            });

        public static readonly ReadOnlyDictionary<int, int> Payout = new ReadOnlyDictionary<int, int>(
            new Dictionary<int, int>
            {
                {1, 3},
                {2, 12},
                {3, 25},
                {4, 6},
                {5, 20},
                {6, 50}
            });
        const int GAMEMONEY = 100;
        public static int[,] numbers2d = new int[3, 3];

        static void Main(string[] args)
        {
            int gameMoney = GAMEMONEY;
            string playOrNo;

            UIMethods.PrintWelcomeMessage();
            do
            {
                int playPicker = 0;
                bool winOrLoose = false;

                while (!PlayCost.ContainsKey(playPicker))
                {
                    UIMethods.PrintPlaymodes();
                    playPicker = UIMethods.TakePlayInput();
                    UIMethods.ClearConsole();
                }

                gameMoney -= PlayCost[playPicker];

                LogicMethods.FillMatrixWithRandomNumbers(numbers2d);

                UIMethods.PrintNumbersMatrix(numbers2d);

                winOrLoose = LogicMethods.CheckMatrix(playPicker);

                UIMethods.PrintWinOrLooseMessage(winOrLoose);

                if (winOrLoose)
                {
                    gameMoney += Program.Payout[playPicker];
                }

                UIMethods.PrintGamemoney(gameMoney);

                playOrNo = UIMethods.TakeReplayInput();

                UIMethods.ClearConsole();
            } while (gameMoney > 0 && playOrNo.Contains("y"));

            UIMethods.PrintGameOverMessage(gameMoney);
        }
    }
}