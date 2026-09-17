using System.Numerics;
using Raylib_cs;
using TestGame.core;

namespace TestGame;

public class Game : GameBase
{
    private Rectangle player;
    private Texture2D arrow;
    private AnimatedSprite dino;
    
    public Game(): base(800, 450, "Test Game") {}

    protected override void Initialize()
    {
        base.Initialize();
        Logger.LogLevel = TraceLogLevel.All;
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        player = new Rectangle(10, 10,10, 10);
        arrow = ContentManager.LoadTexture("textures/arrow.png");

        var dinoTex = ContentManager.LoadTexture("textures/dino_walk.png");
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
        
        
        dino = new AnimatedSprite();
        dino.AddAnimation("idle",idleAnim);
        dino.AddAnimation("walk",walkAnim);
        dino.Play("idle");
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        var walking = false;

        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            walking = true;
            dino.FlipX = false;
        }

        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            walking = true;
            dino.FlipX = true;
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
        
        SpriteBatch.Draw(arrow, new Vector2(200, 200), Color.White);
        
        dino.Draw(SpriteBatch, new Vector2(300, 300), Color.White); 
        
        SpriteBatch.End();
    }
}