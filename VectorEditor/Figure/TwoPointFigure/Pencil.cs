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
            geometry.Freeze();
            drawingContext.DrawGeometry(brush, p, geometry);
        }
    }
}
