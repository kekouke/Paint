using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [DataContract]
    class Pencil : TwoPointFigure
    {
        private Rect layout;
        public Pencil()
        {

        }

        public Pencil(Point point, Pen pen) : base(point, pen)
        {
            layout = new Rect();
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

            layout.X = geometry.Bounds.X;
            layout.Y = geometry.Bounds.Y;
            layout.Height = geometry.Bounds.Height;
            layout.Width = geometry.Bounds.Width;

            drawingContext.PushTransform(new RotateTransform(rotationAngle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(scale, scale, center.X, center.Y));
            drawingContext.DrawGeometry(brush, p, geometry);
        }

        public override bool CheckIntersection(Point firstPoint, Point secondPoint)
        {
            if (worldPoints.Count == 2)
            {
                var result = new Rect(firstPoint, secondPoint).IntersectsWith(new Rect(worldPoints[0], worldPoints[1]));
                return result;
            }
            else
            {
                foreach (var point in worldPoints)
                {
                    if (new Rect(firstPoint, secondPoint).IntersectsWith(new Rect(point, point)));
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
