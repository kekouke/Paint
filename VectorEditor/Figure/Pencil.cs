using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    class Pencil : Figure
    {
        public Pencil()
        {

        }

        public Pencil(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        static int xcord, ycord;

        override public void Draw(WriteableBitmap paintBox)
        {

            paintBox.FillEllipseCentered(leftX, leftY, rightX, rightY, conturColor);

            xcord = rightX;
            ycord = rightY;

        }

        public override void SetCorrectCoordinate()
        {
            leftYDraw = leftY;
            rightYDraw = rightY;
            leftXDraw = leftX;
            rightXDraw = rightX;
        }

        public override void EditSize(int x, int y)
        {
        }

    }
}
