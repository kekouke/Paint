using System.Windows.Media;

namespace VectorEditorApplication
{
    public class DashDotPen : ICustomPen
    {
        public Pen GetPen(Color color, double thickness)
        {
            Pen pen = new Pen()
            {
                Brush = new SolidColorBrush(color),
                Thickness = thickness,
                DashStyle = DashStyles.DashDot
            };
            return pen;
        }
    }
}
