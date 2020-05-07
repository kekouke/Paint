using System.Drawing;

namespace VectorEditorApplication
{
    class Pie : FourPointFigure //TODO
    {
        Pen p;
        Brush br;

        float startAngle = 180;
        float sweepAngle = 90;

        public Pie()
        {

        }

        public Pie(float x, float y) //TODO
        {

        }


        public Pie(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness) : base (x1, y1, x2, y2, conturColor, gradientColor, thickness)
        {
            p = new Pen(conturColor);
            br = new SolidBrush(gradientColor);
            p.Width = thickness;

        }

        override public void Draw(Graphics paintBox)
        {
            SetCorrectCoordinate();

            paintBox.DrawPie(p, leftXDraw - 1, leftYDraw - 1, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, startAngle, sweepAngle);
            paintBox.FillPie(br, leftXDraw, leftYDraw, rightXDraw - leftXDraw + 1, rightYDraw - leftYDraw + 1, 0, 0);
        }
    }
}
