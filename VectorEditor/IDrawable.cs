using System.Windows.Media;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    public interface IDrawable
    {
        void Draw(DrawingContext drawingContext);
        void EditSize(int x, int y);
    }
}
