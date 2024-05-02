
public class Player : ICharacter
{
    public string? Name { get; set; }
    public int Health { get; set; }
    public int FistDamage => 2; //damage when he doesn't have a weapon 
    public IArmor[]? armorList { get; set; } //all armor in inventory
    public IArmor? CurrentArmor { get; set; } //Armor we are wearing
    public IWeapon[]? weaponsList { get; set; } //all weapons in inventory
    public IWeapon? CurrentWeapon { get; set; } //weapon we are using
    public int PositionX {get;set;}
    public int PositionY {get;set;}
    public int Coins {get; set;}
    Random rand = new Random();

    public Player()
    {
        Health = 30;
        Coins = 0;
    }

    public Player(string? name)
    {
        Name = name;
        Health = 30;
        Coins = 0;
    }

    public void Attack()
    {

    }

    public void Heal()
    {
        Health =+ 5;
    }

    public void Magic()
    {
        
    }

    //maybe i want to do a random move each time
    public void InputMove()
    {
        int chance = rand.Next(3);
        switch (chance)
        {
            case 0:
                Attack();
                break;
            case 1:
                Heal();
                break;
            case 2:
                Magic();
                break;
        }
    }


}
