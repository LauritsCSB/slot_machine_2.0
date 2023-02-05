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

//For playing first row
for (int i = 0; i < numbers2d.GetLength(0); i++)
{
    numbers2d[0, i] = randomNumber.Next();
}