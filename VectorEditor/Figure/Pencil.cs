using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace VectorEditorApplication
{
    class Pencil : Figure
    {
        public List<int> points = new List<int>();
        private int width;

        public Pencil()
        {

        }

        public Pencil(int x1, int y1, int width, Color conturColor) :base(x1, y1, conturColor)
        {
            this.width = width;
            points = new List<int>();
            points.Add(leftX);
            points.Add(leftY);
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            if (width < 3)
            {
                paintBox.DrawPolyline(points.ToArray(), conturColor);
            }
            else
            {
                for (int i = 2; i < points.Count - 2; i += 2)
                {
                    paintBox.FillEllipseCentered(points[i - 2], points[i - 1], width - 2, width - 2, conturColor);
                }
            }

        }
        public override void EditSize(int x, int y)
        {
            points.Add(x);
            points.Add(y);
        }

    }
}
