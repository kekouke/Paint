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

        public TwoPointFigure(int x, int y, int thickness, Color conturColor)
        {
            points = new List<Point>();
            points.Add(new Point(x, y));
            points.Add(new Point(x, y));
            this.conturColor = conturColor;
            this.thickness = thickness;
        }


        override abstract public void Draw(Graphics paintBox);

    }
}
