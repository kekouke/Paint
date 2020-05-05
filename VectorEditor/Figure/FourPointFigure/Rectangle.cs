using System.Drawing;

namespace VectorEditorApplication
{
    class Rectangle : FourPointFigure
    {
        Pen p;
        Brush br;
        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness) : base(x1, y1, x2, y2, conturColor, gradientColor, thickness)
        {
            p = new Pen(conturColor);
            br = new SolidBrush(gradientColor);
            p.Width = thickness;
        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();

            paintBox.DrawRectangle(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1);
            paintBox.FillRectangle(br, leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw);
        }

    }
}
