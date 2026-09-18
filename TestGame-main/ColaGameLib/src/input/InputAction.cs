using System.Collections.Generic;
using Raylib_cs;

namespace ColaGameLib.core.input;

public class InputAction
{
    public string Name { get; }
    private readonly HashSet<KeyboardKey> _keys = new();

    public IReadOnlyCollection<KeyboardKey> BoundKeys => _keys;

    public InputAction(string name)
    {
        Name = name;
    }

    public InputAction AddKey(KeyboardKey key)
    {
        _keys.Add(key);
        return this;
    }

    public bool RemoveKey(KeyboardKey key) => _keys.Remove(key);

    public void ClearKeys() => _keys.Clear();

    public bool IsDown()
    {
        foreach (var key in _keys)
        {
            if (Raylib.IsKeyDown(key)) return true;
        }
        return false;
    }

    public bool IsPressed()
    {
        foreach (var key in _keys)
        {
            if (Raylib.IsKeyPressed(key)) return true;
        }
        return false;
    }

    public bool IsReleased()
    {
        foreach (var key in _keys)
        {
            if (Raylib.IsKeyReleased(key)) return true;
        }
        return false;
    }
}