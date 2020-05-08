using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditorApplication
{
    class Rectangle : FourPointFigure
    {
        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush) : base(x1, y1, x2, y2, pen, brush)
        {
        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();

            paintBox.DrawRectangle(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1);
            paintBox.FillRectangle(hBrush, leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw);
        }

    }
}
