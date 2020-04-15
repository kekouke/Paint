using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    class Ellipse : Figure
    {
        public Ellipse()
        {

        }

        public Ellipse(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawEllipse(leftXDraw - 1, leftYDraw - 1, rightXDraw + 1, rightYDraw + 1, conturColor);
            paintBox.FillEllipse(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }
    }

}
