namespace TestGame;

public class Entry
{
    public static void Main()
    {
        using (var game = new TestGame(100))
        {
            game.Start();
        }
    }
}