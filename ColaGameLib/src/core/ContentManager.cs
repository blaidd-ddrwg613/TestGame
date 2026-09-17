using System.Collections.Generic;
using Raylib_cs;
using TestGame.core;

namespace TestGame;

public class ContentManager
{
    private readonly string _rootDirectory;
    private readonly Dictionary<string, Texture2D> _textures = new();
    private readonly Dictionary<string, Sound> _sounds = new();
    private readonly Dictionary<string, Font> _fonts = new();
    private readonly Dictionary<string, Shader> _shaders = new();

    public ContentManager(string rootDirectory = "resources")
    {
        _rootDirectory = rootDirectory;
    }

    private string Path(string relative)
    {
        return System.IO.Path.Combine(_rootDirectory, relative);
    }

    // -------------------------
    // TEXTURES
    // -------------------------
    public Texture2D LoadTexture(string file)
    {
        if (_textures.TryGetValue(file, out var tex))
            return tex;

        var loaded = Raylib.LoadTexture(Path(file));
        _textures[file] = loaded;
        return loaded;
    }

    // -------------------------
    // SOUNDS
    // -------------------------
    public Sound LoadSound(string file)
    {
        if (_sounds.TryGetValue(file, out var snd))
            return snd;

        var loaded = Raylib.LoadSound(Path(file));
        _sounds[file] = loaded;
        return loaded;
    }

    // -------------------------
    // MUSIC
    // -------------------------
    public Music LoadMusic(string file)
    {
        var music = Raylib.LoadMusicStream(file);
        if (!Raylib.IsMusicValid(music))
        {
            Logger.Warning($"Unable to load music : {file}");
        }

        return music;
    }

    // -------------------------
    // FONTS
    // -------------------------
    public Font LoadFont(string file)
    {
        if (_fonts.TryGetValue(file, out var font))
            return font;

        var loaded = Raylib.LoadFont(Path(file));
        _fonts[file] = loaded;
        return loaded;
    }

    // -------------------------
    // SHADERS
    // -------------------------
    public Shader LoadShader(string vs, string fs)
    {
        string key = $"{vs}|{fs}";
        if (_shaders.TryGetValue(key, out var shader))
            return shader;

        var loaded = Raylib.LoadShader(Path(vs), Path(fs));
        _shaders[key] = loaded;
        return loaded;
    }

    // -------------------------
    // UNLOAD EVERYTHING
    // -------------------------
    public void UnloadAll()
    {
        foreach (var tex in _textures.Values)
            Raylib.UnloadTexture(tex);
        foreach (var snd in _sounds.Values)
            Raylib.UnloadSound(snd);
        foreach (var font in _fonts.Values)
            Raylib.UnloadFont(font);
        foreach (var shader in _shaders.Values)
            Raylib.UnloadShader(shader);

        _textures.Clear();
        _sounds.Clear();
        _fonts.Clear();
        _shaders.Clear();
    }
}