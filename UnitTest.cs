namespace Best_Maze_Game;

[TestFixture]
public class PlayerTests
{
    [Test]
    public void Player_Constructor_Correctly()
    {
        string name = "TestPlayer";

        Player player = new Player(name);

        Assert.That(player.Name, Is.EqualTo(name));
        Assert.That(player.Health, Is.EqualTo(30));
        Assert.That(player.Coins, Is.EqualTo(0));
    }

    [Test]
    public void Sword_Constructor_Correct()
    {
        Sword sword = new Sword()

        Assert.That(sword.Name, Is.EqualTo("Sword"));
        Assert.That(sword.AttackDamage, Is.EqualTo(3));
        Assert.That(sword.Durability, Is.EqualTo(6));
    }

    [Test]
    public void Mace_Constructuctor_Correct()
    {
        Mace mace = new Mace();

        Assert.That(mace.Name, Is.Equal("Mace"));
        Assert.That(mace.AttackDamage, Is.Equal(5));
        Assert.That(mace.Durability, Is.Equal(3));
    }
}
