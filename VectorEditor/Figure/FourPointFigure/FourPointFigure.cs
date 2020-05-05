using System.Drawing;

namespace VectorEditorApplication
{
    abstract class FourPointFigure : Figure
    {
        public int leftXDraw;
        public int leftYDraw;
        public int rightXDraw;
        public int rightYDraw;

        protected Color gradientColor;

        public FourPointFigure()
        {

        }

        public FourPointFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int width) : base(x1, y1, x2, y2, conturColor, width)
        {
            this.gradientColor = gradientColor;
        }

        override abstract public void Draw(Graphics paintBox);

        public void SetCorrectCoordinate()
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
