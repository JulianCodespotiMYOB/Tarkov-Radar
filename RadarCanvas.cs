using Avalonia.Controls;
using Avalonia.Media;
using Tarkov_Radar.Interfaces;

namespace Tarkov_Radar;

public class RadarCanvas : Control
{
    private readonly IRadar _radar;

    public RadarCanvas(IRadar radar)
    {
        _radar = radar;
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
            
        // We'll wrap the DrawingContext provided by Avalonia into our custom IRenderContext
        var renderContext = new AvaloniaRenderContext(context);
            
        // Then call the radar's Render method
        _radar.Render();
    }
}