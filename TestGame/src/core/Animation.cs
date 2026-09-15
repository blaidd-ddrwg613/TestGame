namespace TestGame;

public class Animation
{
    public List<TextureRegion> Frames { get; } = new();
    public float FrameTime { get; set; } = 0.1f; // default 10 FPS

    public Animation(float frameTime = 0.1f)
    {
        FrameTime = frameTime;
    }

    public void AddFrame(TextureRegion region)
    {
        Frames.Add(region);
    }
}