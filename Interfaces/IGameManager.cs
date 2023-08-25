using System;
using System.Collections.Generic;

namespace Tarkov_Radar.Interfaces;

public interface IGameManager
{
    event Action<IEnumerable<Player>> PlayersUpdated;
    event Action<IEnumerable<Item>> ItemsUpdated;
    void FindPlayers();
    void FindRareLoot();
    void BuffPlayer();
}