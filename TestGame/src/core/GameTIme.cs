namespace TestGame;

public readonly struct GameTime
{
    public float DeltaTime { get; }
    public float TotalTime { get; }

    private static float _total;

    public GameTime(float dt)
    {
        DeltaTime = dt;
        _total += dt;
        TotalTime = _total;
    }
}