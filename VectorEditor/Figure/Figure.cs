using System;
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

        public virtual void EditSize(Point point)
        {
            secondPoint = point;
        }

        public virtual Figure ToWorldSpace(ViewPort vp)
        {
            /*            var globalFigure = (Figure)Clone();
                        globalFigure.startPoint.X = (startPoint.X - vp.x1) * vp.scale;
                        globalFigure.startPoint.Y = (startPoint.Y - vp.y1) * vp.scale;
                        globalFigure.endPoint.X = (endPoint.X - vp.x1) * vp.scale;
                        globalFigure.endPoint.Y = (endPoint.Y - vp.y1) * vp.scale;
                        return globalFigure;*/
            return null;
        }

        public virtual Figure InLocalSpace(ViewPort vp)
        {
            /*          var globalFigure = (Figure)Clone();
                        globalFigure.startPoint.X = startPoint.X / vp.scale + vp.x1;
                        globalFigure.startPoint.Y = startPoint.Y / vp.scale + vp.y1;
                        globalFigure.endPoint.X = endPoint.X / vp.scale + vp.x1;
                        globalFigure.endPoint.Y = endPoint.Y / vp.scale + vp.y1;
                        return globalFigure;*/
            return null;
        }

    }
}
