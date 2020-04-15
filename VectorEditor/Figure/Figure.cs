using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    abstract class Figure : IDrawable
    {
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;

        public int leftXDraw;
        public int leftYDraw;
        public int rightXDraw;
        public int rightYDraw;

        protected Color conturColor;
        protected Color gradientColor;

        public Figure()
        {

        }

        public Figure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            this.conturColor = conturColor;
            this.gradientColor = gradientColor;
        }

        abstract public void Draw(WriteableBitmap paintBox);
        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

        public virtual void SetCorrectCoordinate()
        {
            if (leftX > rightX)
            {
                leftXDraw = rightX;
                rightXDraw = leftX;
            }
            else
            {
                leftXDraw = leftX;
                rightXDraw = rightX;
            }

            if (leftY > rightY)
            {
                leftYDraw = rightY;
                rightYDraw = leftY;
            }
            else
            {
                leftYDraw = leftY;
                rightYDraw = rightY;
            }

        }

    }
}
