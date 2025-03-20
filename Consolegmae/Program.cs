namespace Consolegmae
{
    internal class Program
    {
        static char[,] map =
             {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                { '#', '.', '.', '.', '#', '.', '.', '.', 'G', '#'},
                { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#'},
                { '#', '.', '#', '.', '.', '.', '.', '.', '.', '#'},
                { '#', '.', '#', '#', '#', '#', '#', '#', '.', '#'},
                { '#', '.', '.', '.', '.', '.', '.', '#', '.', '#'},
                { '#', '#', '#', '#', '#', '#', '.', '#', '.', '#'},
                { '#', 'P', '.', '.', '.', '#', '.', '#', '.', '#'},
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
        };

        //플레이어 위치
        static int playerX = 7;
        static int playerY = 1;
        static void Main(string[] args)
        {
            while (true)
            {
                //화면 초기화
                Console.Clear();
                //맵 출력
                PrintMap();
                //키입력
                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                MovePlayer(KeyInfo.Key);
                //목표지점도달
                if (map[playerX, playerY] == 'G')
                {
                    Console.Clear();
                    PrintMap();
                    Console.WriteLine("\n목표 지점에 도달!");
                    break;

                }

            }
        }
        //맵 출력 함수
        static void PrintMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.WriteLine(map[i, j] + " ");

                }
                Console.WriteLine();
            }

        }
        //플레이어 이동 함수
        static void MovePlayer(ConsoleKey key)
        {
            int newX = playerX;
            int newY = playerY;

            switch (key)
            {
                case ConsoleKey.W:
                    newX--;
                    break;
                case ConsoleKey.S:
                    newX++;
                    break;
                case ConsoleKey.A:
                    newX--;
                    break;
                case ConsoleKey.D:
                    newX++;
                    break;

            }
            // 이동가능여부
            if (map[newX, newY] == '.' || map[newX, newY] == 'G')
            {
                map[playerX, playerY] = '.';
                playerX = newX;
                playerY = newY;
                map[playerX, playerY] = 'P';
            }
        }
    }
}
