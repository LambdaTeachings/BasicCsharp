class MovingElementDemo
{
    char[,] map = new char[10, 15];
    int playerPosX = 5;
    int playerPosY = 5;

    public void Demo()
    {
        PlaceWalls();

        PlacePlayer(playerPosX, playerPosY);

        PrintMap();

        // Game Loop
        while (true)
        {
            var input = Console.ReadKey().Key;

            if (input == ConsoleKey.W && CanMove(playerPosX - 1, playerPosY))
            {
                map[playerPosX, playerPosY] = ' ';
                playerPosX--;
                map[playerPosX, playerPosY] = '@';
            }
            else if (input == ConsoleKey.S && CanMove(playerPosX + 1, playerPosY))
            {
                map[playerPosX, playerPosY] = ' ';
                playerPosX++;
                map[playerPosX, playerPosY] = '@';
            }
            else if (input == ConsoleKey.A && CanMove(playerPosX, playerPosY - 1))
            {
                map[playerPosX, playerPosY] = ' ';
                playerPosY--;
                map[playerPosX, playerPosY] = '@';
            }
            else if (input == ConsoleKey.D && CanMove(playerPosX, playerPosY + 1))
            {
                map[playerPosX, playerPosY] = ' ';
                playerPosY++;
                map[playerPosX, playerPosY] = '@';
            }

            PrintMap();
        }
    }

    bool CanMove(int x, int y)
    {
        if (x < 0 || x >= map.GetLength(0))
            return false;
        else if (y < 0 || y >= map.GetLength(1))
            return false;
        else if (!char.IsWhiteSpace(map[x, y]))
            return false;

        return true;
    }

    void PlaceWalls()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (i == 0 || i == map.GetLength(0) - 1)
                    map[i, j] = '+';
                else if (j == 0 || j == map.GetLength(1) - 1)
                    map[i, j] = '+';
                else if (i == Random.Shared.Next(map.GetLength(0)))
                    map[i, j] = '+';
                else
                    map[i, j] = ' ';
            }
        }
    }

    void PrintMap()
    {
        Console.Clear();
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j]);
            }

            Console.WriteLine();
        }
    }

    void PlacePlayer(int posX, int posY)
    {
        map[posX, posY] = '@';
    }
}