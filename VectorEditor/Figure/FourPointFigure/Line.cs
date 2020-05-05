using System.Drawing;

namespace VectorEditorApplication
{
    class Line : FourPointFigure
    {
        Pen p;

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness) : base(x1, y1, x2, y2, conturColor, gradientColor, thickness)
        {
            p = new Pen(conturColor);
            p.Width = thickness;
        }

        override public void Draw(Graphics paintBox)
        {
            paintBox.DrawLine(p, leftX, leftY, rightX, rightY);
        }
    }
}
