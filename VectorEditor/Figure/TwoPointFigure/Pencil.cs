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

        public Pencil(int x1, int y1, Pen pen) : base(x1, y1, pen)
        {
        }

        override public void Draw(DrawingContext drawingContext)
        {
            var geometry = new StreamGeometry();

            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(points[0], true, false);
                foreach (var point in points)
                {
                    ctx.LineTo(point, true, true);
                }
            }
            geometry.Freeze();
            drawingContext.DrawGeometry(brush, p, geometry);
        }

        public override void EditSize(int x, int y)
        {
            points.Add(new Point(x, y));
        }
    }
}
