using System.Windows.Media;

namespace VectorEditorApplication
{
    public class DashDotDotPen : ICustomPen
    {
        public Pen GetPen(Color color, double thickness)
        {
            Pen pen = new Pen()
            {
                Brush = new SolidColorBrush(color),
                Thickness = thickness,
                DashStyle = DashStyles.DashDotDot
            };
            return pen;
        }
    }
}
