using System;
using System.Collections.Generic;
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
            Point center = new Point((firstPoint.X + secondPoint.X) / 2, (firstPoint.Y + secondPoint.Y) / 2);

            drawingContext.PushTransform(new RotateTransform(rotationAngle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(scale, scale, center.X, center.Y));
            drawingContext.PushTransform(new TranslateTransform(offsetX, offsetY));

            drawingContext.DrawRectangle(brush, p, new Rect(firstDrawPoint, Point.Subtract(secondDrawPoint, firstDrawPoint)));
        }
    }
}
