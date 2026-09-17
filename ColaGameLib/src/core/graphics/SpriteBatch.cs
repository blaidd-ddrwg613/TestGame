using System;
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace TestGame;

public class SpriteBatch
{
    private struct DrawCommand
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Rectangle? Source;
        public Vector2 Origin;
        public float Rotation;
        public Vector2 Scale;
        public Color Tint;
        public float Depth;
    }

    private readonly List<DrawCommand> _commands = new();

    public void Begin()
    {
        _commands.Clear();
    }

    public void Draw(
        Texture2D texture,
        Vector2 position,
        Color tint,
        Rectangle? source = null,
        float rotation = 0f,
        Vector2? origin = null,
        Vector2? scale = null,
        float depth = 0f)
    {
        _commands.Add(new DrawCommand
        {
            Texture = texture,
            Position = position,
            Source = source,
            Rotation = rotation,
            Origin = origin ?? Vector2.Zero,
            Scale = scale ?? Vector2.One,
            Tint = tint,
            Depth = depth
        });
    }

    public void End()
    {
        // Optional: sort by depth
        _commands.Sort((a, b) => a.Depth.CompareTo(b.Depth));

        foreach (var cmd in _commands)
        {
            var src = cmd.Source ?? new Rectangle(0, 0, cmd.Texture.Width, cmd.Texture.Height);
            var dest = new Rectangle(cmd.Position.X, cmd.Position.Y, src.Width * cmd.Scale.X, src.Height * cmd.Scale.Y);

            Raylib.DrawTexturePro(
                cmd.Texture,
                src,
                dest,
                cmd.Origin,
                cmd.Rotation,
                cmd.Tint
            );
        }
    }
}