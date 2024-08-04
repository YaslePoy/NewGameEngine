using NewGameEngine;
using NewGameEngine.Systems;

namespace TestGame;

public class TestGame : IGame 
{
    public override void RegisterSystems()
    {
        RegisterSystem(new ConsoleSystem());
    }

    public TestGame(int maxTps) : base(maxTps)
    {
    }
}