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

        public Line(int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawLine(p, new Point(leftX, leftY), new Point(rightX, rightY));
        }
    }
}
