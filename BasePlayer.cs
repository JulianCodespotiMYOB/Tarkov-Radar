using System;
using System.Numerics;
using Avalonia.Media;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

public abstract class BasePlayer : IRenderable
{
    public IntPtr Address { get; protected set; }
    public float Direction { get; protected set; }
    public string Group { get; protected set; } = string.Empty;
    public Vector3 GunLocation { get; protected set; }
    public Vector3 HeadLocation { get; protected set; }
    public string Id { get; protected set; } = string.Empty;
    public bool IsLocalPlayer { get; protected set; }
    public Vector3 Location { get; protected set; }
    public string NickName { get; protected set; } = string.Empty;

    public void SetLocation(Vector3 rootLocation, Vector3 gunLocation, Vector3 headLocation)
    {
        Location = rootLocation;
        GunLocation = gunLocation;
        HeadLocation = headLocation;
    }

    public void Draw(IRenderContext context)
    {
        var playerColor = IsLocalPlayer ? Colors.Green : Colors.Red;
        var playerSize = IsLocalPlayer ? 10 : 5; // Make the local player's dot a bit bigger

        // Drawing a circle for the player on the radar
        context.DrawCircle(Location, playerColor, playerSize);

        // If you want to add directionality to the player representation, you can also draw a line
        var directionEndPoint = Location + new Vector3((float)Math.Cos(Direction), 0, (float)Math.Sin(Direction)) * 10; // 10 is the length of the line
        context.DrawLine(Location, directionEndPoint, playerColor);
    }
}