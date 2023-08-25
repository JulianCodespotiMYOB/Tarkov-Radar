using Avalonia;
using Avalonia.Media;
using Avalonia.Threading;
using System.Collections.Generic;
using System.Numerics;
using Tarkov_Radar;
using Tarkov_Radar.Interfaces;

public class Radar : IRadar
{
    private readonly IRenderContext _context;
    private readonly IGameManager _gameManager;
    private readonly List<Player> _players;
    private readonly List<Item> _items;

    public Radar(IGameManager gameManager, IRenderContext context)
    {
        _gameManager = gameManager;
        _context = context;
        _players = new List<Player>();
        _items = new List<Item>();
        
        _gameManager.PlayersUpdated += UpdatePlayers;
        _gameManager.ItemsUpdated += UpdateLoot;

        // Setup Avalonia dispatcher for async operations
        Dispatcher.UIThread.Post(StartListening, DispatcherPriority.Background);
    }

    private void StartListening()
    {
        _gameManager.FindPlayers();
        _gameManager.FindRareLoot();
        _gameManager.BuffPlayer();
    }

    public void Render()
    {
        var pen = new Pen(Brushes.Black);
        _context.DrawLine(new Vector3(0, 0, 0), new Vector3(0, 0, 100), Colors.Black);

        foreach (var player in _players)
        {
            player.Draw(_context);
        }

        foreach (var item in _items)
        {
            item.Draw(_context);
        }
    }

    public void UpdatePlayers(IEnumerable<Player> players)
    {
        _players.Clear();
        _players.AddRange(players);
    }

    public void UpdateLoot(IEnumerable<Item> items)
    {
        _items.Clear();
        _items.AddRange(items);
    }
}