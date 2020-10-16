using System.Windows.Media;

namespace VectorEditorApplication
{
    public class SolidBrush : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}
