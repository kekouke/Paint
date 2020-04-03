using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{

    static class PaintTools
    {
        public static Rectangle Rectabgle
        {
            get { return new Rectangle(); }
        }
        public static Ellipse Ellipse
        {
            get { return new Ellipse(); }
        }
        public static Line Line
        {
            get { return new Line(); }
        }
        public static Pencil Pencil
        {
            get { return new Pencil(); }
        }
    }
}
