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

        public TwoPointFigure(int x, int y, Pen pen)
        {
            points = new List<Point>();
            points.Add(new Point(x, y));
            points.Add(new Point(x, y));
            p = pen;
        }


        override abstract public void Draw(DrawingContext drawingContext);
    }
}
