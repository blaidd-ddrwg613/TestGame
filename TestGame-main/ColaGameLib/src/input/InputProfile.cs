using System.Text.Json;
using System.Text.Json.Serialization;
using Raylib_cs;

namespace ColaGameLib.core;

public class InputProfile
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        // Serializes as "Space", "W", "A" instead of integers
        Converters = { new JsonStringEnumConverter() }
    };

    // Maps Action Name -> List of Bound Keys
    public Dictionary<string, List<KeyboardKey>> KeyBindings { get; set; } = new();

    public static InputProfile CreateDefault()
    {
        return new InputProfile
        {
            KeyBindings = new Dictionary<string, List<KeyboardKey>>
            {
                ["MoveLeft"] = new() { KeyboardKey.A, KeyboardKey.Left },
                ["MoveRight"] = new() { KeyboardKey.D, KeyboardKey.Right },
                ["Jump"] = new() { KeyboardKey.Space },
                ["Interact"] = new() { KeyboardKey.F }
            }
        };
    }
    
    public void SaveToFile(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonSerializer.Serialize(this, JsonOptions);
        File.WriteAllText(filePath, json);
    }

    public static InputProfile LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            var defaultProfile = CreateDefault();
            defaultProfile.SaveToFile(filePath);
            return defaultProfile;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<InputProfile>(json, JsonOptions) ?? CreateDefault();
        }
        catch
        {
            // If the file is corrupted, fall back to default
            return CreateDefault();
        }
    }
}