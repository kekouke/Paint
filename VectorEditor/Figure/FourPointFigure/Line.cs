using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [DataContract]
    public class Line : FourPointFigure
    {

        public Line()
        {

        }

        public Line(Point point1, Point point2, Pen pen, Brush brush) : base(point1, point2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext, ViewPort vp)
        {
            drawingContext.DrawLine(p, firstPoint, secondPoint);
        }
    }
}
