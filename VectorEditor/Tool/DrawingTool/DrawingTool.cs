using System.Drawing;

namespace VectorEditorApplication
{
    public abstract class DrawingTool : Tool
    {
       protected abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int width);
    }
}
