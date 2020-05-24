using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;
using System;

namespace VectorEditorApplication
{
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Pie))]
    [KnownType(typeof(Line))]
    [DataContract]
    abstract public class FourPointFigure : Figure
    {
        public Point firstDrawPoint;
        public Point secondDrawPoint;

        public FourPointFigure()
        {
        }

        public FourPointFigure(Point point1, Point point2, Pen pen, Brush brush) : base(point1, point2, pen, brush)
        {
        }

        override abstract public void Draw(DrawingContext drawingContext, ViewPort vp);

        public void SetCorrectCoordinate() //TODO
        {
            /* firstDrawPoint.X = Math.Min(firstPoint.X, secondPoint.X);
             firstDrawPoint.Y = Math.Min(firstPoint.Y, secondPoint.Y);
             secondDrawPoint.X = Math.Max(firstPoint.X, secondPoint.X);
             secondDrawPoint.Y = Math.Max(firstPoint.X, secondPoint.X);*/
            firstDrawPoint = firstPoint;
            secondDrawPoint = secondPoint;
        }
    }

}
