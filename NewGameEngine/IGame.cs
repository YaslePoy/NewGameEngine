using System.Diagnostics;

namespace NewGameEngine;

public static class GlobalGameContext
{
    public static IGame CurrentGame;
}

public abstract class IGame : IDisposable
{
    private int _maxTps;
    private bool _isRunning = false;

    private List<ISystem> _runningSystems = new();

    protected IGame(int maxTps)
    {
        _maxTps = maxTps;
    }

    public void RegisterSystem(ISystem system)
    {
        _runningSystems.Add(system);
    }

    public virtual void RegisterSystems()
    {
    }

    private void InitializeSystem()
    {
        foreach (var system in _runningSystems)
        {
            system.OnLaunch();
        }
    }

    private void RunSystems()
    {
        var watch = new Stopwatch();
        var minTime = TimeSpan.FromSeconds(1f / _maxTps); 
        while (_isRunning)
        {
            watch.Restart();
            for (int i = 0; i < _runningSystems.Count; i++)
            {
                _runningSystems[i].OnWork();
            }
            watch.Stop();
            var waitTime = watch.Elapsed - minTime;
            if(waitTime.Ticks <= 0)
                continue;
            Thread.Sleep(waitTime);
        }
    }

    public void Start()
    {
        if (GlobalGameContext.CurrentGame != null)
        {
            throw new ApplicationException("Only one game can be started at a time");
        }

        GlobalGameContext.CurrentGame = this;
        _isRunning = true;
        RegisterSystems();
        InitializeSystem();
        RunSystems();
    }

    public void Dispose()
    {
        foreach (var system in _runningSystems)
        {
            system.Dispose();
        }
    }

    public void StopGame()
    {
        _isRunning = false;
    }
}