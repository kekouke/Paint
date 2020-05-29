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

            Point center = new Point((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2);

            drawingContext.PushTransform(new RotateTransform(rotationAngle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(scale, scale, center.X, center.Y));
            drawingContext.DrawLine(p, firstPoint, secondPoint);
        }
    }
}
