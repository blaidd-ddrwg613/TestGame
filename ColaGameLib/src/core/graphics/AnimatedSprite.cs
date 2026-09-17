using Raylib_cs;
using ColaGameLib.core.graphics;
using TestGame;

namespace TestGame.core;

public class AnimatedSprite : Sprite
{
    private readonly Dictionary<string, Animation> _animations = new();
    private Animation? _current;
    private int _frameIndex;
    private float _timer;

    public bool Loop { get; set; } = true;

    public AnimatedSprite(Texture2D texture)
        : base(texture)
    {
    }

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
    private void Play(Animation anim)
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
    public override void Draw(SpriteBatch spriteBatch)
    {
        if (_current == null || _current.Frames.Count == 0)
            return;

        var frame = _current.Frames[_frameIndex];
        Texture = frame.Texture;
        Source = frame.Source;
        base.Draw(spriteBatch);
    }
}