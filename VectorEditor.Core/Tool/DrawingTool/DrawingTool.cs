using System.Windows.Media;
using System.Drawing.Drawing2D;
using System.Windows;

namespace VectorEditorApplication
{
    public abstract class DrawingTool : Tool
    {
       protected abstract Figure CreateFigure(Point point1, Point point2, Pen pen);
    }
}
