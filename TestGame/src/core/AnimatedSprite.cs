using System.Numerics;
using Raylib_cs;

namespace TestGame.core;

public class AnimatedSprite
{
    private readonly Dictionary<string, Animation> _animations = new();
    private Animation _current;
    private int _frameIndex;
    private float _timer;

    public bool FlipX { get; set; }
    public bool Loop { get; set; } = true;

    public Vector2 Scale { get; set; } = new(1.0f, 1.0f);

    // -------------------------
    // ADD ANIMATIONS
    // -------------------------
    public void AddAnimation(string name, Animation animation)
    {
        _animations[name] = animation;
    }

    // -------------------------
    // PLAY BY NAME
    // -------------------------
    public void Play(string name)
    {
        if (_animations.TryGetValue(name, out var anim))
        {
            Play(anim);
        }
    }

    // -------------------------
    // PLAY BY REFERENCE
    // -------------------------
    public void Play(Animation anim)
    {
        if (_current == anim)
            return;

        _current = anim;
        _frameIndex = 0;
        _timer = 0f;
    }

    // -------------------------
    // UPDATE
    // -------------------------
    public void Update(GameTime gameTime)
    {
        if (_current == null || _current.Frames.Count == 0)
            return;

        _timer += gameTime.DeltaTime;

        if (_timer >= _current.FrameTime)
        {
            _timer -= _current.FrameTime;
            _frameIndex++;

            if (_frameIndex >= _current.Frames.Count)
                _frameIndex = Loop ? 0 : _current.Frames.Count - 1;
        }
    }

    // -------------------------
    // DRAW
    // -------------------------
    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color tint)
    {
        if (_current == null || _current.Frames.Count == 0)
            return;

        var frame = _current.Frames[_frameIndex];
        var flipX = FlipX ? -frame.Source.Width : frame.Source.Width;
        Rectangle src = new Rectangle(frame.Source.X, frame.Source.Y, flipX, frame.Source.Height);

        spriteBatch.Draw(
            frame.Texture,
            position,
            tint,
            src,
            rotation: 0f,
            origin: Vector2.Zero, 
            Scale,
            depth: 0f
        );
    }
}