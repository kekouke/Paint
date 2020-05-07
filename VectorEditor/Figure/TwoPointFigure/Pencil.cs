using System.Drawing;

namespace VectorEditorApplication
{
    class Pencil : TwoPointFigure
    {
        Pen p;

        public Pencil()
        {

        }

        public Pencil(int x1, int y1, int thickness, Color conturColor) : base(x1, y1, thickness, conturColor)
        {
            p = new Pen(conturColor);
            p.Width = thickness;
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        override public void Draw(Graphics paintBox)
        {
            paintBox.DrawLines(p, points.ToArray());
        }

        public override void EditSize(int x, int y)
        {
            points.Add(new Point(x, y));
        }
    }              
}
