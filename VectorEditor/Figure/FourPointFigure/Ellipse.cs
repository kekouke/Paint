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

        public Ellipse(int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext)
        {
            SetCorrectCoordinate();
            center = new Point((leftXDraw + rightXDraw) / 2, (leftYDraw + rightYDraw) / 2);
            drawingContext.DrawEllipse(brush, p, center, center.X - leftXDraw, center.Y - leftYDraw);
        }
    }

}
