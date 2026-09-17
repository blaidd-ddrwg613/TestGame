using System.Numerics;
using Raylib_cs;

namespace TestGame.core;

public class WindowState
{
    /// <summary>
    /// Check if the window is fullscreen.
    /// </summary>
    public  bool IsFullscreen => Raylib.IsWindowFullscreen();

    /// <summary>
    /// Check if the window is Hidden.
    /// </summary>
    public  bool IsHidden => Raylib.IsWindowHidden();

    /// <summary>
    /// Check if the window is maximized.
    /// </summary>
    public  bool IsMaxamized => Raylib.IsWindowMaximized();

    /// <summary>
    /// Check if the window is minimized.
    /// </summary>
    public  bool IsMinimized => Raylib.IsWindowMinimized();

    /// <summary>
    /// Check if the window is focused.
    /// </summary>
    public  bool IsFocused => Raylib.IsWindowFocused();

    /// <summary>
    /// Check if the window was resized since the last update.
    /// </summary>
    public  bool IsWindowResized => Raylib.IsWindowResized();

    /// <summary>
    /// Get native window handle.
    /// </summary>
    public  unsafe void* WindowHandle => Raylib.GetWindowHandle();

    /// <summary>
    /// Get window pos XY on the monitor.
    /// </summary>
    public  Vector2 WindowPosition => Raylib.GetWindowPosition();

    /// <summary>
    /// Get the window scale dpi factor.
    /// </summary>
    public  Vector2 WindowScaleDPI => Raylib.GetWindowScaleDPI();

    /// <summary>
    /// Get the screen width in pixels.
    /// </summary>
    public  int ScreenWidth => Raylib.GetScreenWidth();

    /// <summary>
    /// Get the screen height in pixels.
    /// </summary>
    public  int ScreenHeight => Raylib.GetScreenHeight();

    /// <summary>
    /// Get the render width in pixels.
    /// </summary>
    public  int RenderWidth => Raylib.GetRenderWidth();

    /// <summary>
    /// Get the render height in pixels.
    /// </summary>
    public  int RenderHeight => Raylib.GetRenderHeight();

    /// <summary>
    /// Get the total number of monitors connected to the computer.
    /// </summary>
    public  int MonitorCount => Raylib.GetMonitorCount();

    /// <summary>
    /// Get the current monitors index.
    /// </summary>
    public  int CurrentMonitor => Raylib.GetCurrentMonitor();

    /// <summary>
    /// Set the tile of the window.
    /// </summary>
    /// <param name="title"></param>
    public  void SetTitle(string title)
    {
        Raylib.SetWindowTitle(title);
    }

    /// <summary>
    /// Set the Position of the window.
    /// </summary>
    /// <param name="x">X position in pixels on the monitor.</param>
    /// <param name="y">Y position in pixels on the monitor.</param>
    public  void SetWindowPos(int x, int y)
    {
        Raylib.SetWindowPosition(x, y);
    }

    /// <summary>
    /// Set the current Monitor for the window.
    /// </summary>
    /// <param name="monitor">Monitor index.</param>
    public  void SetMonitor(int monitor)
    {
        Raylib.SetWindowMonitor(monitor);
    }

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    /// <param name="width">Width of the window in pixels</param>
    /// <param name="height">Height of the window in pixels</param>
    public  void SetMinSize(int width, int height)
    {
        Raylib.SetWindowMinSize(width, height);
    }

    /// <summary>
    /// Set window maximum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    /// <param name="width">Width of the window in pixels</param>
    /// <param name="height">Height of the window in pixels</param>
    public  void SetMaxSize(int width, int height)
    {
        Raylib.SetWindowMaxSize(width, height);
    }

    /// <summary>
    /// Set window size.
    /// </summary>
    /// <param name="width">Window width in pixels.</param>
    /// <param name="height">Window height in pixels.</param>
    public  void SetSize(int width, int height)
    {
        Raylib.SetWindowSize(width, height);
    }

    /// <summary>
    /// Set the opacity of the window.
    /// </summary>
    /// <param name="opacity"></param>
    public  void SetOpacity(float opacity)
    {
        Raylib.SetWindowOpacity(opacity);
    }

    /// <summary>
    /// Toggle the fullscreen state of the window.
    /// </summary>
    public  void ToggleFullscreen()
    {
        Raylib.ToggleFullscreen();
    }

    /// <summary>
    /// Maximizes the application window to occupy the full screen or available space.
    /// </summary>
    public void MaxamizeWindow()
    {
        Raylib.MaximizeWindow();
    }

    /// <summary>
    /// Minimizes the window, reducing it to the taskbar or minimizing its visibility on the screen.
    /// </summary>
    public void MinimizeWindow()
    {
        Raylib.MinimizeWindow();
    }

    public  void RestoreWindow()
    {
        Raylib.RestoreWindow();
    }

    /// <summary>
    /// Toggles the window between borderless and bordered mode.
    /// </summary>
    public void ToggleWindowBorderless()
    {
        Raylib.ToggleBorderlessWindowed();
    }

    /// <summary>
    /// Checks if the window state matches the specified configuration flags.
    /// </summary>
    /// <param name="flags">The configuration flags to check against the window state.</param>
    /// <returns>Returns true if the window state matches the specified flags; otherwise, false.</returns>
    public bool IsWindowState(ConfigFlags flags)
    {
        return Raylib.IsWindowState(flags);
    }

    /// <summary>
    /// Alters the state of the window using the specified configuration flags.
    /// </summary>
    /// <param name="flags">Flags indicating the desired state configuration for the window.</param>
    public void SetWindowState(ConfigFlags flags)
    {
        Raylib.SetWindowState(flags);
    }

    /// <summary>
    /// Clears the specified window state flags, reverting the window to its normal behavior.
    /// </summary>
    /// <param name="flags">The configuration flags to clear from the window state.</param>
    public void ClearWindowState(ConfigFlags flags)
    {
        Raylib.ClearWindowState(flags);
    }

    /// <summary>
    /// Get the width of the specified monitor in pixels.
    /// </summary>
    /// <param name="monitor">Index of the monitor to query.</param>
    /// <returns>The width of the monitor in pixels.</returns>
    public int GetMonitorWidth(int monitor)
    {
        return Raylib.GetMonitorWidth(monitor);
    }

    /// <summary>
    /// Get the height of the specified monitor in pixels.
    /// </summary>
    /// <param name="monitor">Monitor index.</param>
    /// <returns>Height of the specified monitor in pixels.</returns>
    public int GetMonitorHeight(int monitor)
    {
        return Raylib.GetMonitorHeight(monitor);
    }

    /// <summary>
    /// Get the refresh rate of the specified monitor.
    /// </summary>
    /// <param name="monitor">Index of the monitor to query.</param>
    /// <returns>Refresh rate of the specified monitor in Hz.</returns>
    public int GetMonitorRefresh(int monitor)
    {
        return Raylib.GetMonitorRefreshRate(monitor);
    }

    /// <summary>
    /// Get the name of the specified monitor.
    /// </summary>
    /// <param name="monitor">The index of the monitor to retrieve the name for.</param>
    /// <returns>The name of the monitor as a string.</returns>
    public string GetMonitorName(int monitor)
    {
        string IHateYou;
        unsafe
        {
            var val = Raylib.GetMonitorName(monitor);
            IHateYou = val->ToString();
        }

        return IHateYou;
    }
    
}