using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [DataContract]
    class Pencil : TwoPointFigure
    {
        public Pencil()
        {

        }

        public Pencil(Point point, Pen pen) : base(point, pen)
        {
        }

        override public void Draw(DrawingContext drawingContext, ViewPort vp)
        {
            var geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(worldPoints[0], true, false);
                foreach (var point in worldPoints)
                {
                    ctx.LineTo(point, true, true);
                }
            }

            var center = new Point(geometry.Bounds.X + geometry.Bounds.Width / 2, geometry.Bounds.Y + geometry.Bounds.Height / 2);

            drawingContext.PushTransform(new RotateTransform(rotationAngle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(scale, scale, center.X, center.Y));
            drawingContext.DrawGeometry(brush, p, geometry);
        }

        public override bool CheckIntersection(Point firstPoint, Point secondPoint)
        {
            int count = 0;
            foreach (var point in points)
            {
                if (new Rect(firstPoint, secondPoint).IntersectsWith(new Rect(point, point)))
                {
                    count++;
                }
            }
            if (count == points.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
