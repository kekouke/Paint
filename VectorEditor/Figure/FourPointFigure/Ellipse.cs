using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [DataContract]
    class Ellipse : FourPointFigure
    {
        [DataMember]
        Point center;

        public Ellipse()
        {

        }

        public Ellipse(Point point1, Point point2, Pen pen, Brush brush) : base(point1, point2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext, ViewPort vp)
        {
            SetCorrectCoordinate();
            center = new Point((firstDrawPoint.X + secondDrawPoint.X) / 2, (firstDrawPoint.Y + secondDrawPoint.Y) / 2);
            drawingContext.DrawEllipse(brush, p, center, center.X - firstDrawPoint.X, center.Y - firstDrawPoint.Y);
        }
    }

}
