using System.Drawing;
using System.Drawing.Drawing2D;

namespace VectorEditorApplication
{
    public abstract class Figure : IDrawable
    {
        public Pen p;
        public HatchBrush hBrush;


        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;

        public Figure()
        {

        }

        public Figure(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            p = pen;
            hBrush = brush;
        }

        abstract public void Draw(Graphics paintBox);
        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

    }
}
