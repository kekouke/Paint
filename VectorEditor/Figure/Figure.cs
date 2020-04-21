using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    public abstract class Figure : IDrawable
    {
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;

        protected Color conturColor;

        public Figure()
        {

        }

        public Figure(int x1, int y1, int x2, int y2, Color conturColor)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            this.conturColor = conturColor;
        }

        abstract public void Draw(WriteableBitmap paintBox);
        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

    }
}
