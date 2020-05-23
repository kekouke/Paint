using System.Windows.Media;

namespace VectorEditorApplication
{
    public class DashPen : ICustomPen
    {
        public Pen GetPen(Color color, double thickness)
        {
            Pen pen = new Pen()
            {
                Brush = new SolidColorBrush(color),
                Thickness = thickness,
                DashStyle = DashStyles.Dash
            };
            return pen;
        }
    }
}
