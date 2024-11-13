using ConsoleNewMinigame;

namespace ConsoleApp1
{
    internal class Program
    {


        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);

                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Console.Clear();
                Console.WriteLine("YOUR OUT OF BOUNDS HACKER >:(");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {

                Console.Clear();
                int x = 20;
                int y = 14;
                int[,] grid = new int[y, x];
                Player player = new Player();
                BuildBorder(grid, player);
                Fruit_Spawner(grid, player);
                while (player.Is_alive)
                {

                    Player(grid, player);
                    Tail(player, grid);
                }
                Console.ReadKey();
                player.Is_alive = true;
            }



        }
        static void BuildBorder(int[,] grid, object instance)
        {
            Player player = (Player)instance;
            //building in the grid
            int sizeY = grid.GetLength(0);
            int sizeX = grid.GetLength(1);
            for (int i = 0; i < sizeY; i++)
            {
                if (i == 0 || i == sizeY - 1)
                {
                    for (int j = 0; j < sizeX; j++)
                    {
                        grid[i, j] = 1;
                    }
                }


                for (int j = 0; j < sizeX; j++)
                {

                    if (j == 0 || j == sizeX - 1)
                    {

                        grid[i, j] = 1;
                    }
                }

            }

            //displaying the visual
            int Y_off = player.Yoff;
            int X_off = player.Xoff;

            int y_size = grid.GetLength(0);
            int x_size = grid.GetLength(1) * 2;
            //WriteAt("██", j, i);
            for (int i = 0; i < y_size; i++)
            {
                if (i == 0 || i == y_size - 1)
                {
                    for (int j = 0; j < x_size; j += 2)
                    {
                        WriteAt("██", j + X_off, i + Y_off);
                    }


                }
                else
                {
                    for (int j = 0; j < x_size; j += 2)
                    {
                        if (j == 0 || j == x_size - 2)
                        {
                            WriteAt("██", j + X_off, i + Y_off);
                        }
                    }
                }
            }


        }
        static void Player(int[,] grid, object instance)
        {

            Player player = (Player)instance;
            int Y_off = player.Yoff;
            int X_off = player.Xoff;
            int Length = player.lengthX.Count() + 1;
            WriteAt(" ", 0, 0);

            if (Console.KeyAvailable == true)
            {

                player.last_key = Console.ReadKey().Key.ToString();
                grid[player.y, player.x] = 0;

                //WriteAt("  ", player.x * 2 + X_off, player.y + Y_off);
            }


            switch (player.last_key)
            {
                case "G":
                    player.God_Mode = true;
                    WriteAt("GodMode", 0,2); break;
                case "R":

                    Fruit_Spawner(grid, player);
                    player.last_key = "Enter";
                    break;
                case "E":
                    //Thread.Sleep(100);
                    WriteAt("Score:" + Length, 7, 0);
                    //Swing(grid, player); break;
                    Increase_size(player);
                    player.last_key = "Enter";
                    break;

                case "W":

                    player.y--;
                    if (grid[player.y, player.x] == 1)
                    {
                        player.y++;
                        GameOver(player);
                    }
                    else if (grid[player.y, player.x] == 3)
                    {
                        Increase_size(player);
                        Fruit_Spawner(grid, player);
                    }
                    break;
                case "A":


                    player.x--;
                    if (grid[player.y, player.x] == 1)
                    {
                        player.x++;
                        GameOver(player);
                    }
                    else if (grid[player.y, player.x] == 3)
                    {
                        Increase_size(player);
                        Fruit_Spawner(grid, player);
                    }
                    break;
                case "S":


                    player.y++;
                    if (grid[player.y, player.x] == 1)
                    {
                        player.y--;
                        GameOver(player);
                    }
                    else if (grid[player.y, player.x] == 3)
                    {
                        Increase_size(player);
                        Fruit_Spawner(grid, player);
                    }
                    break;
                case "D":


                    player.x++;
                    if (grid[player.y, player.x] == 1)
                    {
                        player.x--;
                        GameOver(player);
                    }
                    else if (grid[player.y, player.x] == 3)
                    {
                        Increase_size(player);
                        Fruit_Spawner(grid, player);
                    }
                    break;
            }

            grid[player.y, player.x] = 1;
            WriteAt("██", player.x * 2 + X_off, player.y + Y_off);

        }
        //may remove this tomorow or rename it
        static void Swing(int[,] grid, object instance)
        {

            Player player = (Player)instance;
            int x = player.x * 2;
            int y = player.y;


            WriteAt("]>-----------------", x + 2, y + 1);
            Thread.Sleep(120);
            WriteAt("                   ", x + 2, y + 1);
            for (int i = player.x; i < grid.GetLength(0); i++)
            {
                grid[i, y] = 0;
            }



        }
        static void Tail(object instance, int[,] grid)
        {
            Thread.Sleep(100);
            Player player = (Player)instance;
            int x = player.x;
            int y = player.y;
            player.lengthX.Enqueue(x);
            player.lengthY.Enqueue(y);
            WriteAt("██", x * 2 + player.Xoff, y + player.Yoff);
            ;
            try
            {
                grid[player.lengthY.Peek(), player.lengthX.Peek()] = 0;
                WriteAt("  ", player.lengthX.Dequeue() * 2 + player.Xoff, player.lengthY.Dequeue() + player.Yoff);
            }

            catch
            {

            }

        }
        static void Increase_size(object instance)
        {
            Player player = (Player)instance;
            player.lengthX.Enqueue(player.x);
            player.lengthY.Enqueue(player.y);
            WriteAt("Score:" + player.lengthY.Count(), 7, 0);

        }

        static void Fruit_Spawner(int[,] grid, object instance)
        {
            Player player = (Player)instance;
            Random random = new Random();
            int y = random.Next(1, grid.GetLength(0)-1);
            int x = random.Next(1, grid.GetLength(01)-1);
            grid[y, x] = 3;
            WriteAt("██", x * 2 + player.Xoff, y + player.Yoff);
        }

        static void GameOver(object instance)
        {
            Player player = (Player)instance;
            if (player.God_Mode != true)
            {
                Console.Clear();
                
                player.Is_alive = false;
                WriteAt(" _________________ ", player.x * 2 + player.Xoff, player.y - 1 + player.Yoff);
                WriteAt("/                 \\", player.x * 2 + player.Xoff, player.y + player.Yoff);
                WriteAt("|                 |", player.x * 2 + player.Xoff, player.y + 1 + player.Yoff);
                WriteAt("|    GAME OVER    |", player.x * 2 + player.Xoff, player.y + 2 + player.Yoff);
                WriteAt("|                 |", player.x * 2 + player.Xoff, player.y + 3 + player.Yoff);
                WriteAt("\\_________________/", player.x * 2 + player.Xoff, player.y + 4 + player.Yoff);
                Console.ReadKey();
            }
        }
    }
}






