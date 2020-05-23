using System;
using System.Windows.Media;
using System.Runtime.Serialization;

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
        public int leftX;

        [DataMember]
        public int leftY;

        [DataMember]
        public int rightX;

        [DataMember]
        public int rightY;

        public Figure()
        {

        }

        public Figure(int x1, int y1, int x2, int y2, Pen pen, Brush brush)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            p = pen;
            this.brush = brush;
        }

        abstract public void Draw(DrawingContext drawingContext);

        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

    }
}
