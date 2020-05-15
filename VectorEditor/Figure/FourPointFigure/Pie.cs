using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    [DataContract]
    public class Pie : FourPointFigure
    {

        [DataMember]
        int startAngle;

        [DataMember]
        int sweepAngle;

        public Pie()
        {

        }

        public Pie(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush, int startAngle, int sweepAngle) : base (x1, y1, x2, y2, pen, brush)
        {
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();

            paintBox.DrawPie(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, startAngle, sweepAngle);
            paintBox.FillPie(hBrush, leftXDraw, leftYDraw, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, startAngle, sweepAngle);
        }
    }
}
