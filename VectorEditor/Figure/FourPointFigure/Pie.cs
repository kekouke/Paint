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

        public Pie(int x1, int y1, int x2, int y2, Pen pen, Brush brush, int startAngle, int sweepAngle) : base(x1, y1, x2, y2, pen, brush)
        {
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        override public void Draw(DrawingContext drawingContext)
        {
            SetCorrectCoordinate();

            center = new Point((leftXDraw + rightXDraw) / 2, (leftYDraw + rightYDraw) / 2);

            var geometry = new StreamGeometry();

            using (var ctx = geometry.Open())
            {
                ctx.BeginFigure(center, true, false);
                ctx.LineTo(new Point(rightXDraw, leftYDraw), true, false);
                ctx.ArcTo(new Point(rightXDraw, rightYDraw), new Size(100, 50), 45 /* rotation angle */, true /* is large arc */,
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
