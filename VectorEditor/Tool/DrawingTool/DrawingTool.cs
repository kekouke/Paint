using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public abstract class DrawingTool : Tool
    {
       protected abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor);
    }
}
