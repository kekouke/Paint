using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class SolidPen : ICustomPen
    {
        public Pen GetPen(Color color, double thickness)
        {
            Pen pen = new Pen()
            {
                Brush = new SolidColorBrush(color),
                Thickness = thickness,
                DashStyle = DashStyles.Solid
            };
            return pen;
        }
    }
}
