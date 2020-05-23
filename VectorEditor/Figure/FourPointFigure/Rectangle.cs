using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    [DataContract]
    public class Rectangle : FourPointFigure
    {

        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Pen pen, Brush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext)
        {
            SetCorrectCoordinate();

            drawingContext.DrawRectangle(brush, p, new Rect(leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw));
        }

    }
}
