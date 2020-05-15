using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    [DataContract]
    class Ellipse : FourPointFigure
    {
        public Ellipse()
        {

        }

        public Ellipse(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawEllipse(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 2, rightYDraw - leftYDraw + 2);
            paintBox.FillEllipse(hBrush, leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw);
        }
    }

}
