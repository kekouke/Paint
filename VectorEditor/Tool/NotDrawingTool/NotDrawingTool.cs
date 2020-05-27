using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace VectorEditorApplication
{
    public abstract class NotDrawingTool : Tool
    {
        protected static Point ToLocalViewPort(Point point) => new Point(10, 10);
    }
}
