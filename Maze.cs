
public class Maze
{
    public string? Name { get; set; }
    public string[,]? Grid { get; set; }
    public int Rows { get; set; }
    public int Cols { get; set; }
    Random rand = new Random();
    public List<Monster>? Monsters { get; set; }

    public Maze()
    {

    }

    public Maze(string filepath)
    {
        Monsters = new List<Monster>();
        string[] lines = File.ReadAllLines(filepath); // Read all lines from file
        Rows = lines.Length;
        Cols = lines[0].Length;
        Name = Path.GetFileName(filepath); // Get file name without path

        Grid = new string[Rows, Cols]; // Initialize the grid

        // Fill the grid with maze data
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                Grid[i, j] = lines[i][j].ToString();
                if (rand.Next(1000) > 970 && Grid[i, j] == " ")
                {
                    Monster monster = new Monster(j, i);
                    Monsters.Add(monster);
                    Grid[i, j] = "M";
                }
                else if (rand.Next(1000) > 995 && Grid[i, j] == " ")
                {
                    Grid[i, j] = "H";
                }
                else if (rand.Next(1000) > 990 && Grid[i,j] == " ")
                {
                    Grid[i, j] = "$";
                }
            }
        }
    }

    public void DrawMazeCovered(int playerX, int playerY)
    {
        Console.SetCursorPosition(0, 0); // Clear the console before drawing the maze


        int startX = Math.Max(0, playerX - 3);
        int startY = Math.Max(0, playerY - 3);
        int endX = Math.Min(Rows - 1, playerX + 3);
        int endY = Math.Min(Cols - 1, playerY + 3);

        if (playerX - 1 < 0)
        {
            startX = playerX - 1;
            endX += Math.Abs(playerX - 1);
        }
        if (playerY - 1 < 0)
        {
            startY = playerY - 1;
            endY += Math.Abs(playerY - 1);
        }
        if (playerX + 1 >= Rows)
        {
            endX = Rows - 1;
        }
        if (playerY + 1 >= Cols)
        {
            endY = Cols - 1;
        }


        for (int i = startX; i <= endX; i++)
        {
            for (int j = startY; j < endY; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.Write("O"); // Draw the player at the specified position
                }
                else
                {
                    Console.Write(Grid?[i, j]); // Draw the maze cell
                }
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }

    public void DrawMaze(int playerX, int playerY)
    {
        Console.SetCursorPosition(0, 3);

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if (i == playerX && j == playerY)
                {
                    Console.Write("O"); // Draw the player
                }
                else
                    Console.Write(Grid?[i, j]);
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }
}

