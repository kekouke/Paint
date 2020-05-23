using System.Windows.Media;
using System.Drawing.Drawing2D;

namespace VectorEditorApplication
{
    public abstract class DrawingTool : Tool
    {
       protected abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Pen pen);
    }
}
