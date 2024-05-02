public interface IWeapon
{
    public string? Name { get; }
    public int AttackDamage { get; }
    public int Durability { get; }
}

public class Sword : IWeapon
{
    public string? Name => "Sword";
    public int AttackDamage => 3;
    public int Durability => 6;
    public Sword()
    {

    }
}

public class Mace : IWeapon
{
    public string? Name => "Mace";
    public int AttackDamage => 5;
    public int Durability => 3;

    public Mace()
    {

    }
}
