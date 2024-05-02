public interface ICharacter
{
    public string? Name { get; set; }
    public int Health { get; set; }
    public int FistDamage {get; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    
    public void Attack();
    public void Heal();
    public void Magic();

}
