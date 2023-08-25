using System;
using System.Linq;
using System.Numerics;
using Avalonia.Media;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

public enum LootRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
    // Add other rarities if necessary
}

public class Item : IRenderable
{
    public IntPtr GameObjectAddress { get; set; }
    public string Id { get; set; }
    public IntPtr ItemAddress { get; set; }
    public Vector3 Location { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public LootRarity Rarity { get; set; }

    private static readonly string[] LootableNames = 
    {
        "cap", "Ammo_crate_Cap", "Grenade_box_Door", "Medical_Door",
        "POS_Money", "Toolbox_Door", "card_file_box", "cover_", "lootable",
        "scontainer_Blue_Barrel_Base_Cap", "scontainer_wood_CAP",
        "suitcase_plastic_lootable_open", "weapon_box_cover"
    };

    public bool CanBeLooted() => LootableNames.Any(lootableName => Name.Contains(lootableName));

    public void Draw(IRenderContext context)
    {
        Color itemColor;
        int itemSize;

        switch (Rarity)
        {
            case LootRarity.Common:
                itemColor = Colors.Gray;
                itemSize = 3;
                break;
            case LootRarity.Uncommon:
                itemColor = Colors.Blue;
                itemSize = 4;
                break;
            case LootRarity.Rare:
                itemColor = Colors.Purple;
                itemSize = 5;
                break;
            case LootRarity.Legendary:
                itemColor = Colors.Gold;
                itemSize = 6;
                break;
            default:
                itemColor = Colors.White;
                itemSize = 3;
                break;
        }

        // Drawing a circle for the item on the radar
        context.DrawCircle(Location, itemColor, itemSize);

        // If you want to represent legendary items as stars, for instance
        if (Rarity == LootRarity.Legendary)
        {
            context.DrawStar(Location, itemColor, itemSize);
        }
    }
}