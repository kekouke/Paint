using System.Drawing;

namespace VectorEditorApplication
{
    class Pencil : TwoPointFigure
    {

        public Pencil()
        {

        }

        public Pencil(int x1, int y1, Pen pen) : base(x1, y1, pen)
        {
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
