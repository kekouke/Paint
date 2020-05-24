using System.Windows.Media;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [KnownType(typeof(Pencil))]
    [DataContract]
    abstract class TwoPointFigure : Figure
    {
        [DataMember]
        public List<Point> points;

        public TwoPointFigure()
        {

        }

        public TwoPointFigure(Point point, Pen pen)
        {
            points = new List<Point>();
            points.Add(point);
            points.Add(point);
            p = pen;
        }


        override abstract public void Draw(DrawingContext drawingContext, ViewPort vp);
    }
}
