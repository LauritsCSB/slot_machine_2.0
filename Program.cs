//TODO Make player able to choose to play 1-3 rows, 1-3 columns or diagonals
//TODO Keep track of play and prize money, output money
//TODO Wrap everything in game loop (do while)

int playPicker = 0;
int gameMoney = 100;
int userBet = 0;
string winMessage = "Win!";
string lossMessage = "No win..";
string welcomeAndRules = "Hello user, this is a slot machine. You can choose to make a bet on 1-3 rows, columns or diagonals. " +
    "The more rows, columns and diagonals you choose to bet on, the higher the price! You start with $100 dollars.";
string betOverview = "Picking 1, you choose to bet on one row or column, 2 is for two etc. If you pick 7 you'll bet on diagonals. " +
    "Please enter your pick and press enter: ";
string askForBet = "How much would you like to bet?";

Random randomNumber = new Random();
int[,] numbers2d = new int[3, 3];
for (int column = 0; column < numbers2d.GetLength(0); column++)
{
    for (int row = 0; row < numbers2d.GetLength(1); row++)
    {
        numbers2d[column, row] = randomNumber.Next(1, 10);
    }
}

for (int column = 0; column < numbers2d.GetLength(0); column++)
{
    for (int row = 0; row < numbers2d.GetLength(1); row++)
    {
        Console.Write(numbers2d[column, row] + " ");
    }
    Console.WriteLine();
}

//Checking one row
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

    if (counter > 0)
    {
        gameMoney += (userBet * 2);
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking two rows
if (playPicker == 4 || playPicker == 5)
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

    if (numbers2d[1, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[1, 2])
    {
        counter++;
    }

    if (counter == 2)
    {
        gameMoney += (userBet * 3);
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking three rows
if (playPicker == 6)
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

    if (counter == 3)
    {
        gameMoney += (userBet * 4);
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking one column
if (playPicker == 7 || playPicker == 8 || playPicker == 9)
{
    int counter = 0;
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

    if (counter > 0)
    {
        gameMoney += (userBet * 2);
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking two columns
if (playPicker == 10 || playPicker == 11)
{
    int counter = 0;
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

    if (numbers2d[0, 1] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 1])
    {
        counter++;
    }

    if (counter == 2)
    {
        gameMoney += (userBet * 3);
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking three columns
if (playPicker == 12)
{
    int counter = 0;
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

    if (counter == 3)
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
if (playPicker == 13 || playPicker == 14)
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