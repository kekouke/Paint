using System.Windows.Media;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Pie))]
    [KnownType(typeof(Line))]
    [DataContract]
    abstract public class FourPointFigure : Figure
    {
        public int leftXDraw;
        public int leftYDraw;
        public int rightXDraw;
        public int rightYDraw;

        public FourPointFigure()
        {
        }

        public FourPointFigure(int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override abstract public void Draw(DrawingContext drawingContext);

        public void SetCorrectCoordinate()
        {
            if (leftX > rightX)
            {
                leftXDraw = rightX;
                rightXDraw = leftX;
            }
            else
            {
                leftXDraw = leftX;
                rightXDraw = rightX;
            }

            if (leftY > rightY)
            {
                leftYDraw = rightY;
                rightYDraw = leftY;
            }
            else
            {
                leftYDraw = leftY;
                rightYDraw = rightY;
            }

        }
    }

}
