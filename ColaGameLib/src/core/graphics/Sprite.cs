using System.Numerics;
using Raylib_cs;
using TestGame;

namespace ColaGameLib.core.graphics;

public class Sprite
{
    public Texture2D Texture { get; set; }
    public Rectangle? Source { get; set; }

    public Vector2 Position { get; set; }
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;

    public float Rotation { get; set; }
    public float Depth { get; set; }

    public Color Tint { get; set; } = Color.White;

    public bool FlipX { get; set; }
    public bool FlipY { get; set; }

    public int Width
    {
        get
        {
            var source = GetSourceRectangle();
            return (int)MathF.Abs(source.Width);
        }
    }

    public int Height
    {
        get
        {
            var source = GetSourceRectangle();
            return (int)MathF.Abs(source.Height);
        }
    }

    public Sprite(Texture2D texture)
    {
        Texture = texture;
    }

    public Sprite(TextureRegion region)
    {
        Texture = region.Texture;
        Source = region.Source;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var source = GetSourceRectangle();

        if (FlipX)
        {
            source.Width *= -1;
        }

        if (FlipY)
        {
            source.Height *= -1;
        }

        spriteBatch.Draw(
            Texture,
            Position,
            Tint,
            source,
            Rotation,
            Origin,
            Scale,
            Depth
        );
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Position = position;
        Draw(spriteBatch);
    }

    private Rectangle GetSourceRectangle()
    {
        return Source ?? new Rectangle(0, 0, Texture.Width, Texture.Height);
    }
}