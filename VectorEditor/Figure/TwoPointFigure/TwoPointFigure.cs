using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace VectorEditorApplication
{
    abstract class TwoPointFigure : Figure
    {
        public List<int> points;

        public TwoPointFigure()
        {

        }

        public TwoPointFigure(int x, int y, Color conturColor)
        {
            points = new List<int>();
            points.Add(x);
            points.Add(y);
            this.conturColor = conturColor;
        }


        override abstract public void Draw(WriteableBitmap paintBox);

    }
}
