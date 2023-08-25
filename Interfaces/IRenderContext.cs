using System.Numerics;
using Avalonia.Media;

namespace Tarkov_Radar.Interfaces;

public interface IRenderContext
{
    void DrawCircle(Vector3 location, Color color, int size);
    void DrawLine(Vector3 startPoint, Vector3 endPoint, Color color);
    void DrawStar(Vector3 location, Color color, int size); // Only if you want to represent items as stars
}
