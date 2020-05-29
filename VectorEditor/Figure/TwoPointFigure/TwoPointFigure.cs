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

        protected List<Point> worldPoints;

        public TwoPointFigure()
        {

        }

        public TwoPointFigure(Point point, Pen pen) : base()
        {
            points = new List<Point>();
            worldPoints = new List<Point>();
            points.Add(point);
            points.Add(point);
            p = pen;
        }

        public override void EditSize(Point point, ViewPort vp)
        {
            point = ToLocalSpace(point, vp);
            points.Add(point);
        }

        public override void ToWorldSpace(ViewPort vp)
        {
            worldPoints?.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                var point = new Point((points[i].X - vp.StartPoint.X) * vp.Scale,
                                     (points[i].Y - vp.StartPoint.Y) *vp.Scale);
                worldPoints.Add(point);
            }
        }

        override abstract public void Draw(DrawingContext drawingContext, ViewPort vp);
    }
}
