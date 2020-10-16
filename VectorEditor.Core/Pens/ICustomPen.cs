using System;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public interface ICustomPen
    {
        Pen GetPen(Color color, double thickness);
    }
}
