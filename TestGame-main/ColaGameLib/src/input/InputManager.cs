using Raylib_cs;

namespace ColaGameLib.core.input;

public class InputManager
{
    private readonly Dictionary<string, InputAction> _actions = new();
    private readonly string _saveFilePath;
    private InputProfile _profile;
    
    public bool IsListeningForRebind { get; private set; }
    public string? ActionBeingRebound { get; private set; }

    public InputManager(string configFileName = "keybindings.json")
    {
        // Save to LocalApplicationData for user-level write permissions
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        _saveFilePath = Path.Combine(appData, "ColaGameLib", configFileName);

        _profile = InputProfile.LoadFromFile(_saveFilePath);
        ApplyProfile(_profile);
    }

    public InputAction RegisterAction(string actionName)
    {
        if (!_actions.TryGetValue(actionName, out var action))
        {
            action = new InputAction(actionName);
            _actions[actionName] = action;

            // If the loaded profile contains this action, populate its keys
            if (_profile.KeyBindings.TryGetValue(actionName, out var keys))
            {
                foreach (var k in keys) action.AddKey(k);
            }
        }
        return action;
    }
    
    public void Update()
    {
        if (IsListeningForRebind)
        {
            int keyPressed = Raylib.GetKeyPressed();

            // Ignore 0 (no key) and Escape
            if (keyPressed > 0)
            {
                var newKey = (KeyboardKey)keyPressed;
                if (newKey != KeyboardKey.Escape && ActionBeingRebound != null)
                {
                    RebindAction(ActionBeingRebound, newKey);
                }
                
                IsListeningForRebind = false;
                ActionBeingRebound = null;
            }
        }
    }

    public void StartListeningForRebind(string actionName)
    {
        if (_actions.ContainsKey(actionName))
        {
            IsListeningForRebind = true;
            ActionBeingRebound = actionName;
        }
    }

    public void RebindAction(string actionName, KeyboardKey newKey, bool replaceExisting = true)
    {
        if (!_actions.TryGetValue(actionName, out var action))
            return;

        if (replaceExisting)
        {
            action.ClearKeys();
        }

        action.AddKey(newKey);

        // Sync with profile and persist
        _profile.KeyBindings[actionName] = new List<KeyboardKey>(action.BoundKeys);
        _profile.SaveToFile(_saveFilePath);
    }

    public void ResetToDefaults()
    {
        _profile = InputProfile.CreateDefault();
        ApplyProfile(_profile);
        _profile.SaveToFile(_saveFilePath);
    }

    private void ApplyProfile(InputProfile profile)
    {
        foreach (var (actionName, keys) in profile.KeyBindings)
        {
            var action = RegisterAction(actionName);
            action.ClearKeys();
            foreach (var k in keys)
            {
                action.AddKey(k);
            }
        }
    }

    public bool IsDown(string action) => _actions.TryGetValue(action, out var a) && a.IsDown();
    public bool IsPressed(string action) => _actions.TryGetValue(action, out var a) && a.IsPressed();
    public bool IsReleased(string action) => _actions.TryGetValue(action, out var a) && a.IsReleased();
}