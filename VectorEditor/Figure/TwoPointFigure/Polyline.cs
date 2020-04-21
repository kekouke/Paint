using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace VectorEditorApplication
{
    class Polyline : TwoPointFigure
    {
        public Polyline()
        {

        }

        public Polyline(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            points.Add(x1);
            points.Add(y1);
            this.conturColor = conturColor;
        }

        override public void Draw(WriteableBitmap writeableBitmap)
        {
            writeableBitmap.DrawPolyline(points.ToArray(), conturColor);
        }

        public override void EditSize(int x, int y)
        {
            points.Add(x);
            points.Add(y);
        }
    }
}
