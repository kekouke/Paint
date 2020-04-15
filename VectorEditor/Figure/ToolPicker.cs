using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{

    public class ToolPicker
    {

        public ToolPicker()
        {
            rectTool = new RectTool();
            ellipseTool = new EllipseTool();
            lineTool = new LineTool();
            pencilTool = new PencilTool();
        }

        public RectTool Rectabgle
        {
            get { return rectTool; }
        }
        public EllipseTool Ellipse
        {
            get { return ellipseTool; }
        }
        public LineTool Line
        {
            get { return lineTool; }
        }
        public PencilTool Pencil
        {
            get { return pencilTool; }
        }

        RectTool rectTool;
        EllipseTool ellipseTool;
        LineTool lineTool;
        PencilTool pencilTool;
    }
}
