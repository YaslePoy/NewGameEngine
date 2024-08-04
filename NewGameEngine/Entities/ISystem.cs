namespace NewGameEngine;

public interface ISystem : IDisposable
{
    public void OnLaunch();
    public void OnWork();
}