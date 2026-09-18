using ColaGameLib.core;
using ColaGameLib.core.audio;
using ColaGameLib.core.input;
using Raylib_cs;
using TestGame.core;

namespace TestGame;

public abstract class GameBase : System.IDisposable
{
    private bool _disposed;
    public int Width { get; }
    public int Height { get; }
    public string Title { get; }

    public ContentManager ContentManager { get; private set; }
    public InputManager Input { get; private set; }
    public SpriteBatch SpriteBatch { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public WindowState WindowState { get; private set; }
    public Color ClearColor { get; set; } = Color.Black;

    protected GameBase(int width, int height, string title)
    {
        Width = width;
        Height = height;
        Title = title;
        
        ContentManager = new ContentManager();
        Input = new InputManager();
        AudioManager = new AudioManager();
        SpriteBatch = new SpriteBatch();
        WindowState = new WindowState();
    }

    public void Run()
    {
        InitializeWindow();
        Initialize();
        LoadContent();

        while (!Raylib.WindowShouldClose())
        {
            var gameTime = new GameTime(Raylib.GetFrameTime());
            
            AudioManager.Update();
            Input.Update();

            Update(gameTime);
            DrawWindow(gameTime);
        }

        UnloadContent();
        Dispose();
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

    public void Dispose()
    {
        if (!_disposed)
        {
            AudioManager.Dispose(); // Tear down audio device safely
            _disposed = true;
        }
    }
}