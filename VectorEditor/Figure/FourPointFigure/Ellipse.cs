using System.Drawing;

namespace VectorEditorApplication
{
    class Ellipse : FourPointFigure
    {
        Pen p;
        Brush br;

        public Ellipse()
        {

        }

        public Ellipse(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness) : base(x1, y1, x2, y2, conturColor, gradientColor, thickness)
        {
            p = new Pen(conturColor);
            br = new SolidBrush(gradientColor);
            p.Width = thickness;
        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawEllipse(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 2, rightYDraw - leftYDraw + 2);
            paintBox.FillEllipse(br, leftXDraw, leftYDraw, rightXDraw - leftXDraw, rightYDraw - leftYDraw);
        }
    }

}
