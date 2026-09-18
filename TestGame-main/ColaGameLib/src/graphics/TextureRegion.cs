using Raylib_cs;

namespace TestGame;

public readonly struct TextureRegion
{
    public Texture2D Texture { get; }
    public Rectangle Source { get; }

    public int Width => (int)Source.Width;
    public int Height => (int)Source.Height;

    public TextureRegion(Texture2D texture, Rectangle source)
    {
        Texture = texture;
        Source = source;
    }
}
