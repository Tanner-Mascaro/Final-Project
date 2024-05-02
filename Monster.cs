public class Monster : ICharacter
{
    public string? Name { get; set; }
    public int Health { get; set; }
    public int FistDamage => 4;
    public IWeapon weapon{ get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public bool isAlive { get; set; }
    Random rand = new Random();

    public Monster(int X, int Y)
    {
        Name = "Monster";
        PositionX = X;
        PositionY = Y;
        Health = 8;
        if(rand.Next(11) >= 5)
        {
            weapon = new Mace();
        }
        else 
        {
            weapon = new Sword();
        }
        isAlive = true;
    }

    public void Attack()
    {

    }

    public void Heal()
    {

    }

    public void Magic()
    {

    }
}
