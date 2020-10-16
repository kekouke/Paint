using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorEditorApplication
{
    [DataContract]
    public class Pie : FourPointFigure
    {
        Point center;
        [DataMember]
        int startAngle;

        [DataMember]
        int sweepAngle;

        public Pie()
        {

        }

        public Pie(Point point1, Point point2, Pen pen, Brush brush, int startAngle, int sweepAngle) : base(point1, point2, pen, brush)
        {
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        override public void Draw(DrawingContext drawingContext, ViewPort vp)
        {
            SetCorrectCoordinate();

            center = new Point((firstDrawPoint.X + secondDrawPoint.X) / 2, (firstDrawPoint.Y + secondDrawPoint.Y) / 2);

            var geometry = new StreamGeometry();

            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(center, true, false);
                ctx.LineTo(new Point(secondDrawPoint.X, firstDrawPoint.Y), true, false);
                ctx.ArcTo(secondDrawPoint, new Size(100, 50), 45 /* rotation angle */, true /* is large arc */,
                          SweepDirection.Counterclockwise, true /* is stroked */, false /* is smooth join */);
                ctx.LineTo(center, true, false);
            }

            geometry.Freeze();

            drawingContext.DrawGeometry(brush, p, geometry);

            //drawingContext.DrawRectangle(brush, p, new Rect(leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw));
            //paintBox.DrawPie(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, startAngle, sweepAngle);
            //paintBox.FillPie(hBrush, leftXDraw, leftYDraw, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, startAngle, sweepAngle);
        }
    }
}
