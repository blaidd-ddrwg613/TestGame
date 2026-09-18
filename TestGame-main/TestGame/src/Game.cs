using System.Numerics;
using ColaGameLib.core.graphics;
using Raylib_cs;
using TestGame.core;

namespace TestGame;

public class Game : GameBase
{
    private Sprite arrow;
    private AnimatedSprite dino;

    private Sound _jumpSound;
    
    public Game(): base(800, 450, "Test Game") {}

    protected override void Initialize()
    {
        base.Initialize();
        Logger.LogLevel = TraceLogLevel.All;
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        _jumpSound = ContentManager.LoadSound("audio/sounds/jump.mp3");
        AudioManager.SetSoundVolume(_jumpSound, 0.1f);
        
        arrow = new Sprite(ContentManager.LoadTexture("textures/arrow.png"))
        {
            Position = new Vector2(100, 100)
        };

        var dinoTex = ContentManager.LoadTexture("textures/dino_walk.png");
        dino = new AnimatedSprite(dinoTex)
        {
            Position = new Vector2(200, 200)
        };

        var atlas = new TextureAtlas(dinoTex);

        var dinoSize = 48;
        
        Animation idleAnim = new Animation();
        idleAnim.AddFrame(atlas.AddRegion(0,0,dinoSize,dinoSize));

        var walkAnim = new Animation();
        walkAnim.AddFrame(atlas.AddRegion(0,0,dinoSize,dinoSize));
        walkAnim.AddFrame(atlas.AddRegion(48,0,dinoSize,dinoSize));
        walkAnim.AddFrame(atlas.AddRegion(48 * 2,0,dinoSize,dinoSize));
        walkAnim.AddFrame(atlas.AddRegion(48 * 3,0,dinoSize,dinoSize));
        walkAnim.AddFrame(atlas.AddRegion(48 * 4,0,dinoSize,dinoSize));
        walkAnim.AddFrame(atlas.AddRegion(48 * 5,0,dinoSize,dinoSize));
        
        dino.AddAnimation("idle",idleAnim);
        dino.AddAnimation("walk",walkAnim);
        dino.Play("idle");
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        var walking = false;

        if (Input.IsDown("MoveRight"))
        {
            walking = true;
            dino.FlipX = false;
        }

        if (Input.IsDown("MoveLeft"))
        {
            walking = true;
            dino.FlipX = true;
        }

        if (Input.IsPressed("Jump"))
        {
            AudioManager.PlaySound(_jumpSound);
        }

        if (walking)
        {
            dino.Play("walk");
        }
        else
        {
            dino.Play("idle");
        }
        
        dino.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        SpriteBatch.Begin();
        
        arrow.Draw(SpriteBatch);
        
        dino.Draw(SpriteBatch);
        
        SpriteBatch.End();
    }
}