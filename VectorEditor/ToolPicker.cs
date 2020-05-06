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
            polylineTool = new PolylineTool();
            zoomTool = new ZoomTool();
            handTool = new HandTool();
            pieTool = new PieTool();
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
        public PolylineTool Polyline
        {
            get { return polylineTool; }
        }
        public ZoomTool Zoom
        {
            get { return zoomTool; }
        }
        public HandTool Hand
        {
            get { return handTool; }
        }
        public PieTool Pie
        {
            get { return pieTool; }
        }

        RectTool rectTool;
        EllipseTool ellipseTool;
        LineTool lineTool;
        PencilTool pencilTool;
        PolylineTool polylineTool;
        ZoomTool zoomTool;
        HandTool handTool;
        PieTool pieTool;
    }
}
