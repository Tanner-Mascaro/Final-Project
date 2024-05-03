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
    public void ShowsInstructions()
    {

    }
}
