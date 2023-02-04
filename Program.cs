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

Console.WriteLine($"{numbers2d[0, 0]} {numbers2d[0, 1]} {numbers2d[0, 2]}");
Console.WriteLine($"{numbers2d[1, 0]} {numbers2d[1, 1]} {numbers2d[1, 2]}");
Console.WriteLine($"{numbers2d[2, 0]} {numbers2d[2, 1]} {numbers2d[2, 2]}");