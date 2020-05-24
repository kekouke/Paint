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

        public Rectangle(Point point1, Point point2, Pen pen, Brush brush) : base(point1, point2, pen, brush)
        {
        }

        override public void Draw(DrawingContext drawingContext, ViewPort vp)
        {
            SetCorrectCoordinate();

            drawingContext.DrawRectangle(brush, p, new Rect(firstDrawPoint, Point.Subtract(secondDrawPoint, firstDrawPoint)));
        }

    }
}
