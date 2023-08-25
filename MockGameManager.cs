using System;
using System.Collections.Generic;
using System.Numerics;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

public class MockGameManager : IGameManager
    {
        public event Action<IEnumerable<Player>> PlayersUpdated;
        public event Action<IEnumerable<Item>> ItemsUpdated;

        private readonly List<Player> _mockPlayers = new()
        {
            new Player(IntPtr.Zero, 45, "Team Alpha", new Vector3(0, 0, 0), new Vector3(1, 1, 1), "1", new Vector3(5, 5, 5), "Player1"),
            new Player(IntPtr.Zero, 30, "Team Alpha", new Vector3(1, 1, 1), new Vector3(2, 2, 2), "2", new Vector3(10, 10, 10), "Player2"),
            new Player(IntPtr.Zero, 15, "Solo", new Vector3(2, 2, 2), new Vector3(3, 3, 3), "3", new Vector3(20, 20, 20), "Player3")
        };
        private readonly List<Item> _mockItems = new()
        {
            new Item { Name = "Loot1", Location = new Vector3(5, 5, 5), Rarity = LootRarity.Common },
            new Item { Name = "Loot2", Location = new Vector3(10, 10, 10), Rarity = LootRarity.Rare },
            new Item { Name = "Loot3", Location = new Vector3(20, 20, 20), Rarity = LootRarity.Legendary }
        };
        
        public void FindPlayers()
        {
            PlayersUpdated?.Invoke(_mockPlayers);
        }

        public void FindRareLoot()
        {
            // Filter and only return rare loot items
            var rareLoot = _mockItems.FindAll(item => item.Rarity == LootRarity.Rare);
            ItemsUpdated?.Invoke(rareLoot);
        }

        public void BuffPlayer()
        {
            // As it's mock data, let's just choose the first player and simulate a "buff"
            if (_mockPlayers.Count > 0)
            {
                var player = _mockPlayers[0];
                // You might modify the player's properties to indicate a buff, or just print a message
                Console.WriteLine($@"{player.NickName} has been buffed!");
            }
        }
    }
