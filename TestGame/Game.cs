using Raylib_cs;

namespace TestGame;

public class Game : GameBase
{
    private Rectangle player;
    private Texture2D arrow;
    
    public Game(): base(800, 450, "Test Game") {}

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        player = new Rectangle(10, 10,10, 10);
        arrow = ContentManager.LoadTexture("textures/arrow.png");
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Raylib.IsKeyDown(KeyboardKey.W)) player.Y -= 1;
        if (Raylib.IsKeyDown(KeyboardKey.S)) player.Y += 1;
        if (Raylib.IsKeyDown(KeyboardKey.A)) player.X -= 1;
        if (Raylib.IsKeyDown(KeyboardKey.D)) player.X += 1;
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        
        Raylib.DrawRectangleRec(player, Color.White);
        Raylib.DrawTexture(arrow, 200, 200,Color.White);
    }
}