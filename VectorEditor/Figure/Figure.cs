using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Pie))]
    [KnownType(typeof(Line))]
    [KnownType(typeof(Pencil))]

    //TODO
    [KnownType(typeof(SolidColorBrush))]
    [KnownType(typeof(MatrixTransform))]

    [KnownType(typeof(DrawingBrush))]
    [KnownType(typeof(DrawingGroup))]
    [KnownType(typeof(GeometryGroup))]
    [KnownType(typeof(LinearGradientBrush))]
    [KnownType(typeof(GeometryDrawing))]
    [KnownType(typeof(RectangleGeometry))]

    [DataContract]
    public abstract class Figure : IDrawable
    {
        [DataMember]
        public Pen p;

        [DataMember]
        public Brush brush;

        [DataMember]
        public Point firstPoint;

        [DataMember]
        public Point secondPoint;

        public Figure()
        {

        }

        public Figure(Point point1, Point point2, Pen pen, Brush brush)
        {
            firstPoint = point1;
            secondPoint = point2;
            p = pen;
            this.brush = brush;
        }

        abstract public void Draw(DrawingContext drawingContext, ViewPort vp);

        public virtual void EditSize(Point point, ViewPort vp)
        {
            point = ToLocalSpace(point, vp);
            secondPoint = point;
        }

        public virtual void ToWorldSpace(ViewPort vp)
        {
            firstPoint.X = (firstPoint.X - vp.StartPoint.X) * vp.Scale;
            firstPoint.Y = (firstPoint.Y - vp.StartPoint.Y) * vp.Scale;
            secondPoint.X = (secondPoint.X - vp.StartPoint.X) * vp.Scale;
            secondPoint.Y = (secondPoint.Y - vp.StartPoint.Y) * vp.Scale;
        }

        public virtual void ToLocalSpace(ViewPort vp)
        {                       
            firstPoint.X = firstPoint.X / vp.Scale + vp.StartPoint.X;
            firstPoint.Y = firstPoint.Y / vp.Scale + vp.StartPoint.Y;
            secondPoint.X = secondPoint.X / vp.Scale + vp.StartPoint.X;
            secondPoint.Y = secondPoint.Y / vp.Scale + vp.StartPoint.Y;
        }

        public Point ToLocalSpace(Point point, ViewPort vp) => new Point(point.X / vp.Scale + vp.StartPoint.X, point.Y / vp.Scale + vp.StartPoint.Y);

        public object Clone() => MemberwiseClone();
    }
}
