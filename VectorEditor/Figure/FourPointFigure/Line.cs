using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    class Line : FourPointFigure
    {

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        override public void Draw(WriteableBitmap paintBox)
        {
            paintBox.DrawLine(leftX, leftY, rightX, rightY, conturColor);
        }
    }
}
