using System.Numerics;
using Avalonia;
using Avalonia.Media;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

public class AvaloniaRenderContext : IRenderContext
{
    private readonly DrawingContext _drawingContext;

    public AvaloniaRenderContext(DrawingContext drawingContext)
    {
        _drawingContext = drawingContext;
    }

    public void DrawCircle(Vector3 location, Color color, int size)
    {
        var brush = new SolidColorBrush(color);
        var geometry = new EllipseGeometry(new Rect(new Point(location.X - size/2, location.Z - size/2), new Size(size, size)));
        _drawingContext.DrawGeometry(brush, null, geometry);
    }

    public void DrawLine(Vector3 startPoint, Vector3 endPoint, Color color)
    {
        var pen = new Pen(new SolidColorBrush(color));
        _drawingContext.DrawLine(pen, new Point(startPoint.X, startPoint.Z), new Point(endPoint.X, endPoint.Z));
    }

    public void DrawStar(Vector3 location, Color color, int size)
    {
        // Assuming a simple 5-point star, this method can be enhanced
        var points = new[]
        {
            new Point(location.X, location.Z - size), // Top point
            new Point(location.X - size * 0.5, location.Z + size * 0.5), // Bottom left
            new Point(location.X + size, location.Z - size * 0.3), // Mid-right
            new Point(location.X - size, location.Z - size * 0.3), // Mid-left
            new Point(location.X + size * 0.5, location.Z + size * 0.5)  // Bottom right
        };
            
        var brush = new SolidColorBrush(color);
        var geometry = new StreamGeometry();
            
        using (var context = geometry.Open())
        {
            context.BeginFigure(points[0], true);
            context.LineTo(points[1]);
        }

        _drawingContext.DrawGeometry(brush, null, geometry);
    }
}