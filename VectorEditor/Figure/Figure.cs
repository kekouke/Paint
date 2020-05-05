using System.Drawing;

namespace VectorEditorApplication
{
    public abstract class Figure : IDrawable
    {
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;

        public int thickness;
        protected Color conturColor;

        public Figure()
        {

        }

        public Figure(int x1, int y1, int x2, int y2, Color conturColor, int thickness)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            this.conturColor = conturColor;
            this.thickness = thickness;
        }

        abstract public void Draw(Graphics paintBox);
        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

    }
}
