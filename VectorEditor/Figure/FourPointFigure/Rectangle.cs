using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    class Rectangle : FourPointFigure
    {
        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawRectangle(leftXDraw - 1, leftYDraw - 1, rightXDraw, rightYDraw, conturColor);
            paintBox.FillRectangle(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }

    }
}
