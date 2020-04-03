using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    abstract class Tool : IDrawable
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

        public Tool()
        {

        }

        public Tool(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            this.conturColor = conturColor;
            this.gradientColor = gradientColor;
        }

        abstract public void Draw(WriteableBitmap paintBox);
        public abstract Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor);
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

    class Rectangle : Tool
    {
        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Rectangle(x1, y1, x2, y2, conturColor, gradientColor);
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawRectangle(leftXDraw - 1, leftYDraw - 1, rightXDraw, rightYDraw, conturColor);
            paintBox.FillRectangle(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }

    }

    class Ellipse : Tool
    {
        public Ellipse()
        {

        }

        public Ellipse(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Ellipse(x1, y1, x2, y2, conturColor, gradientColor);
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawEllipse(leftXDraw - 1, leftYDraw - 1, rightXDraw + 1, rightYDraw + 1, conturColor);
            paintBox.FillEllipse(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }
    }

    class Line : Tool
    {

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Line(x1, y1, x2, y2, conturColor, gradientColor);
        }

        public override void SetCorrectCoordinate()
        {
            leftYDraw = leftY;
            rightYDraw = rightY;
            leftXDraw = leftX;
            rightXDraw = rightX;
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawLine(leftXDraw, leftYDraw, rightXDraw, rightYDraw, conturColor);
        }
    }

    class Pencil : Tool
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

            paintBox.DrawLine(leftX, leftY, rightX, rightY, conturColor);

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

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil(x1, y1, x2, y2, conturColor, gradientColor);
        }

        public override void EditSize(int x, int y)
        {
            leftX = xcord;
            leftY = ycord;
            rightX = x;
            rightY = y;
        }

    }
}
