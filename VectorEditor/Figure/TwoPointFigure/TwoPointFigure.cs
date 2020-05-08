using System.Drawing;
using System.Collections.Generic;

namespace VectorEditorApplication
{
    abstract class TwoPointFigure : Figure
    {
        public List<Point> points;

        public TwoPointFigure()
        {

        }

        public TwoPointFigure(int x, int y, Pen pen)
        {
            points = new List<Point>();
            points.Add(new Point(x, y));
            points.Add(new Point(x, y));
            this.p = pen;
        }


        override abstract public void Draw(Graphics paintBox);

    }
}
