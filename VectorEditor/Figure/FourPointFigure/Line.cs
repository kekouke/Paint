using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditorApplication
{
    class Line : FourPointFigure
    {

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(Graphics paintBox)
        {
            paintBox.DrawLine(p, leftX, leftY, rightX, rightY);
        }
    }
}
