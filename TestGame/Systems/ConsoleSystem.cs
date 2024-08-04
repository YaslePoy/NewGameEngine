namespace NewGameEngine.Systems;

public class ConsoleSystem : ISystem
{
    public void Dispose()
    {
    }

    public void OnLaunch()
    {
    }

    public void OnWork()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey();
            Console.WriteLine($"Console input: {key.KeyChar}");
            if (key.Key == ConsoleKey.Backspace)
                GlobalGameContext.CurrentGame.StopGame();
        }
    }
}