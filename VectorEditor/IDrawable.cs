using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    public interface IDrawable
    {
        void Draw(DrawingContext drawingContext, ViewPort vp);
        void EditSize(Point point);
    }
}
