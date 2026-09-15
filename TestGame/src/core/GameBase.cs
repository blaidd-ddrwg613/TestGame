using Raylib_cs;

namespace TestGame;

public abstract class GameBase
{
    public int Width { get; }
    public int Height { get; }
    public string Title { get; }
    
    public ContentManager ContentManager { get; private set; }
    public SpriteBatch SpriteBatch { get; private set; }
    
    public Color ClearColor { get; set; } = Color.Black;

    protected GameBase(int width, int height, string title)
    {
        Width = width;
        Height = height;
        Title = title;
        
        ContentManager = new ContentManager();
        SpriteBatch = new SpriteBatch();
    }

    public void Run()
    {
        InitializeWindow();
        Initialize();
        LoadContent();

        while (!Raylib.WindowShouldClose())
        {
            var gameTime = new GameTime(Raylib.GetFrameTime());
            Update(gameTime);
            DrawWindow(gameTime);
        }

        UnloadContent();
        Raylib.CloseWindow();
    }

    private void InitializeWindow()
    {
        Raylib.InitWindow(Width, Height, Title);
    }

    private void DrawWindow(GameTime gameTime)
    {
        BeginDraw();
        
        Raylib.ClearBackground(ClearColor);
        Draw(gameTime);
        
        EndDraw();
    }

    private void BeginDraw()
    {
        Raylib.BeginDrawing();
    }

    private void EndDraw()
    {
        Raylib.EndDrawing();
    }
    
    protected virtual void Initialize() { }
    protected virtual void LoadContent() { }
    protected virtual void Update(GameTime gameTime) { }
    protected virtual void Draw(GameTime gameTime) { }

    protected virtual void UnloadContent()
    {
        ContentManager.UnloadAll();
    }
}