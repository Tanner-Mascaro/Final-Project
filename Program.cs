
Console.Clear();

//turn off the cursor and made a player with its position in the maps
Console.CursorVisible = false;
Player player = new Player();
player.PositionX = 1;
player.PositionY = 1;
Random random = new Random(); //random cause i always use it
bool game = true;

Maze level; //get a level but we will assign it later

Console.ForegroundColor = ConsoleColor.White; //colors i liked
Console.BackgroundColor = ConsoleColor.DarkCyan;

//making a bunch of read files for things i wanted
string[] interaction = File.ReadAllLines("FightScreen.txt");
string[] magic = File.ReadAllLines("Magic.txt");
string[] fistAttack = File.ReadAllLines("FistAttack.txt");
string[] swordAttack = File.ReadAllLines("SwordAttack.txt");
string[] healAttack = File.ReadAllLines("Heal.txt");
string[] start = File.ReadAllLines("Welcome.txt");
string[] gameover = File.ReadAllLines("gg.txt");
string[] maceAttack = File.ReadAllLines("MaceAttack.txt");

//showing theh start image
DisplayImage(start);

//will these lines under for some basic instructions
Console.WriteLine("----------------------------------------------------------");
Console.WriteLine("----------------------------------------------------------");

Console.WriteLine("You will use W-A-S-D to move. Make your way to the X and watch out for the M's! $ = coins and H = Health");
Console.WriteLine("What level maze would you like to play?");
Console.WriteLine("Level 1, 2, 3? Type the corresponding number and then press enter!");
string? input = Console.ReadLine();
Console.Clear();

//switch to pick the level they want to play
switch (input)
{
    case "1":
        level = new Maze("Level1.txt");
        break;
    case "2":
        level = new Maze("Level2.txt");
        break;
    case "3":
        level = new Maze("Level3.txt");
        break;
    default:
        level = new Maze("Level1.txt");
        break;
}


//show this all the time. want them to constantly know. curosr needs to be o,0 to be at the top
void GameInstructions()
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine("Hello! Get out of the Maze! Use W-A-S-D to move around the map! Have Fun!");
    Console.WriteLine("You are the O, M are the monsters! The $ are the coins you want to collect 5 to end the game!");
    Console.WriteLine($"Health:{player.Health} Weapons: {player.CurrentWeapon} Coins: {player.Coins}");
}


//method so i dont have to type out the foreach each time
void DisplayImage(string[] image)
{
    foreach (string line in image)
    {
        Console.WriteLine(line);
    }
}

//method to fight the monsters. It takes a random number and makes it either your turn or his
void Interaction(Player player, Monster monster)
{
    while (player.Health > 0 && monster.Health > 0)
    {
        Console.Clear();
        DisplayImage(interaction);
        Console.WriteLine($"Your Health:{player.Health} Monster's Health:{monster.Health}");
        Console.WriteLine("You can either Attack, Use Magic, or Heal!");


        if (random.Next(2) == 0)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Your turn! Press A, M or H!");
            Console.WriteLine("----------------------------------------------------------");
            string? input = Console.ReadLine()?.ToUpper();
            Console.Clear();
            switch (input)
            {
                case "A":
                    if (player.CurrentWeapon == null)
                    {
                        DisplayImage(fistAttack);
                        monster.Health -= player.FistDamage;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("You punched the monster!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    else if (player.CurrentWeapon != null)
                    {
                        if (player.CurrentWeapon is Sword)
                        {
                            DisplayImage(swordAttack);
                            monster.Health -= player.CurrentWeapon.AttackDamage;
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("You cut the monster!"); ;
                            Console.WriteLine("----------------------------------------------------------");
                            break;
                        }
                        else if (player.CurrentWeapon is Mace)
                        {
                            DisplayImage(maceAttack);
                            monster.Health -= player.CurrentWeapon.AttackDamage;
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("You smashed the monster!"); ;
                            Console.WriteLine("----------------------------------------------------------");
                            break;
                        }
                    }
                    break;
                case "M":
                    //magic gives a random chance of hurting you or them!
                    if (random.Next(2) == 0)
                    {
                        DisplayImage(magic);
                        monster.Health -= 6;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Your magic hurt the monster!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    else if (random.Next(2) == 1)
                    {
                        DisplayImage(magic);
                        player.Health -= 6;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Your magic hurt yourself!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    break;
                case "H":
                    DisplayImage(healAttack);
                    player.Health += 3;
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("You healed yourself!");
                    Console.WriteLine("----------------------------------------------------------");
                    break;
                default:
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Try again Press A, M, or H!");
                    Console.WriteLine("----------------------------------------------------------");
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Monster is attacking! Press enter to see what he does!");
            Console.WriteLine("----------------------------------------------------------");
            Console.ReadLine();
            Console.Clear();

            int chanceofattack = random.Next(3);
            switch (chanceofattack)
            {
                case 0:
                    if (monster.weapon == null)
                    {
                        DisplayImage(fistAttack);
                        player.Health -= monster.FistDamage;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("The monster punched you!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    else if (monster.weapon != null)
                    {
                        if (monster.weapon is Sword)
                        {
                            DisplayImage(swordAttack);
                            player.Health -= monster.weapon.AttackDamage;
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("The monster cut you!");
                            Console.WriteLine("----------------------------------------------------------");
                            break;
                        }
                        else if (monster.weapon is Mace)
                        {
                            DisplayImage(maceAttack);
                            player.Health -= monster.weapon.AttackDamage;
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("The monster smashed you!"); ;
                            Console.WriteLine("----------------------------------------------------------");
                            break;
                        }
                        break;
                    }
                    break;

                case 1:
                    //magic gives a random chance of hurting you or them!
                    if (random.Next(2) == 0)
                    {
                        DisplayImage(magic);
                        monster.Health -= 6;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("The monster hit himself with magic!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    else if (random.Next(2) == 1)
                    {
                        DisplayImage(magic);
                        player.Health -= 6;
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("The monster hit you with magic!");
                        Console.WriteLine("----------------------------------------------------------");
                        break;
                    }
                    break;
                case 2:
                    DisplayImage(healAttack);
                    monster.Health += 3;
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("The monster healed itself!");
                    Console.WriteLine("----------------------------------------------------------");
                    break;
            }
        }
        Console.WriteLine($"Player Health:{player.Health} Monster Health:{monster.Health}");
        Console.ReadLine();
        //this down here will give you his weapon if you dont have one
        if (monster.Health <= 0)
        {
            if (monster.weapon != null || player.CurrentWeapon == null)
            {
                player.CurrentWeapon = monster.weapon;
            }
            else if (monster.weapon != null || player.CurrentWeapon != null || monster.weapon?.AttackDamage > player.CurrentWeapon?.AttackDamage)
            {
                player.CurrentWeapon = monster.weapon;
            }
            monster.isAlive = false;
            break;
        }
    }

}

//main game loop. shows instructions and lets the player move
do
{
    GameInstructions();
    ConsoleKey key = Console.ReadKey(true).Key;
    int newX = player.PositionX;
    int newY = player.PositionY;

    switch (key)
    {
        case ConsoleKey.W:
            newY = player.PositionY - 1; // Move up
            break;
        case ConsoleKey.S:
            newY = player.PositionY + 1; // Move down
            break;
        case ConsoleKey.A:
            newX = player.PositionX - 1; // Move left
            break;
        case ConsoleKey.D:
            newX = player.PositionX + 1; // Move right
            break;
    }

    // Check if the new position is within the maze bounds
    if (newY >= 0 && newY < level.Rows && newX >= 0 && newX < level.Cols)
    {
        if (level.Grid?[newY, newX] == " ")
        {
            // Update the player's position
            player.PositionX = newX;
            player.PositionY = newY;

            // Redraw the maze with the updated player position
            level.DrawMaze(player.PositionY, player.PositionX);
        }
        else if (level.Grid?[newY, newX] == "M")
        {
            //looking for the first instance of the monster and assigning it to the monster variable to fight
            //i found first or default and it helps look through the whole list and finds the first condition that matches the properties
            //in this case it finds the monster at the position x and y. i set it to not null cause it will never be null
            Monster monster = level.Monsters?.FirstOrDefault(m => m.PositionX == newX && m.PositionY == newY)!;
            Interaction(player, monster);
            if (player.Health == 0)
            {
                Console.Clear();
                Console.WriteLine("Better Luck next time!");
                DisplayImage(gameover);
                Console.ReadLine();
                game = false;
            }
            else if (player.Health > 0)
            {
                level.Grid[newY, newX] = " ";
                player.PositionX = newX;
                player.PositionY = newY;


                level.DrawMaze(player.PositionY, player.PositionX);
            }
        }
        else if (level.Grid?[newY, newX] == "H")
        {
            level.Grid[newY, newX] = " ";
            player.PositionX = newX;
            player.PositionY = newY;

            player.Health += 5;

            level.DrawMaze(player.PositionY, player.PositionX);
        }
        else if (level.Grid?[newY, newX] == "X" && player.Coins >= 5)
        {
            Console.Clear();
            Console.WriteLine("Congrats! You made it to the end!");
            DisplayImage(gameover);
            Console.ReadLine();
            game = false;
        }
        else if (level.Grid?[newY, newX] == "$")
        {
            level.Grid[newY, newX] = " ";
            player.PositionX = newX;
            player.PositionY = newY;

            player.Coins += 1;

            level.DrawMaze(player.PositionY, player.PositionX);
        }
    }

} while (game == true);


