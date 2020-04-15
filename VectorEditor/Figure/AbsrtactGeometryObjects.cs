using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{

    static class PaintTools
    {
        public static RectTool Rectabgle
        {
            get { return new RectTool(); }
        }
        public static EllipseTool Ellipse
        {
            get { return new EllipseTool(); }
        }
        public static LineTool Line
        {
            get { return new LineTool(); }
        }
        public static PencilTool Pencil
        {
            get { return new PencilTool(); }
        }
    }
}
