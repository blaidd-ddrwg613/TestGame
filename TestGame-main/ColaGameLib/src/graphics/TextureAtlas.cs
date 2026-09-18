using System.Collections.Generic;
using Raylib_cs;

namespace TestGame;

public class TextureAtlas
{
    public Texture2D Texture { get; }
    private readonly List<TextureRegion> _regions = new();

    public TextureAtlas(Texture2D texture)
    {
        Texture = texture;
    }

    public TextureRegion AddRegion(int x, int y, int w, int h)
    {
        var region = new TextureRegion(Texture, new Rectangle(x, y, w, h));
        _regions.Add(region);
        return region;
    }

    public TextureRegion this[int index] => _regions[index];
    public int Count => _regions.Count;
}