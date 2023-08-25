using System.Collections.Generic;

namespace Tarkov_Radar.Interfaces;

public interface IRadar
{
    void Render();
    void UpdatePlayers(IEnumerable<Player> players);
    void UpdateLoot(IEnumerable<Item> items);
}