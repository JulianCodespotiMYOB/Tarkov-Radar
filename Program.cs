using Avalonia;
using System;
using Avalonia.Controls;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

class Program
{
    // This will serve as our game manager instance for the entire application.
    private static IGameManager _gameManager;
    private static IRadar _radar;

    [STAThread]
    public static void Main(string[] args)
    {
        InitializeGameComponents();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        ShowMainWindow();
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();

    private static void InitializeGameComponents()
    {
        // Assuming you have concrete implementations for these interfaces.
        _gameManager = new MockGameManager();
        _radar = new Radar(_gameManager, null);
    }
    
    private static void ShowMainWindow()
    {
        // Initialize the main window and add the RadarView to it
        var mainWindow = new Window
        {
            Title = "Radar Application",
            Content = new RadarCanvas(_radar),
            Width = 800,
            Height = 600
        };

        mainWindow.Show();
    }
}