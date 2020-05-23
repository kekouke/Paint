using System;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public interface ICustomPen
    {
        public Pen GetPen(Color color, double thickness);
    }
}
