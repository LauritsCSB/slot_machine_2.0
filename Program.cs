//TODO Make player able to choose to play 1-3 rows, 1-3 columns or diagonals
//TODO Make funntion to check for winning column, row and/ or diagonal, output win/ loose message
//TODO Keep track of play and prize money, output money

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

/*Input to determine which result equals win:
1: top row
2: middle row
3: bottom row
4: top two rows
5: bottom two rows
6: all rows
7: left column
8: middle column
9: right column
10: left most columns
11: right most columns
12: all columns
13: forward diagonal
14: back diagonal
*/
int playPicker = 0;
string winMessage = "Win!";
string lossMessage = "No win..";

//Checking one row
if (playPicker == 1 || playPicker == 2 || playPicker == 3)
{
    if (numbers2d[0, 0] == numbers2d[0, 1] && numbers2d[0, 1] == numbers2d[0, 2])
    {
        Console.WriteLine(winMessage);
    }
    else if (numbers2d[1, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[1, 2])
    {
        Console.WriteLine(winMessage);
    }
    else if (numbers2d[2, 0] == numbers2d[2, 1] && numbers2d[2, 1] == numbers2d[2, 2])
    {
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
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking all rows
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
    if (numbers2d[0, 0] == numbers2d[1, 0] && numbers2d[1, 0] == numbers2d[2, 0])
    {
        Console.WriteLine(winMessage);
    }
    if (numbers2d[0, 1] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 1])
    {
        Console.WriteLine(winMessage);
    }
    if (numbers2d[0, 2] == numbers2d[1, 2] && numbers2d[1, 2] == numbers2d[2, 2])
    {
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
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}

//Checking all columns
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
    if (numbers2d[0, 0] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 2])
    {
        Console.WriteLine(winMessage);
    }
    else if (numbers2d[0, 2] == numbers2d[1, 1] && numbers2d[1, 1] == numbers2d[2, 0])
    {
        Console.WriteLine(winMessage);
    }
    else
    {
        Console.WriteLine(lossMessage);
    }
}