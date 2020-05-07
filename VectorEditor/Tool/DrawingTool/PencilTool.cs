using System.Drawing;
using System.Windows.Input;

namespace VectorEditorApplication
{
    public class PencilTool : DrawingTool
    {

        private ConturColorConfig conturColor;

        public ConturColorConfig ConturColor { get { return conturColor; } set { ConturColor = value; } }

        public PencilTool()
        {
            conturColor = new ConturColorConfig(System.Windows.Media.Colors.Black);
        }

        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, conturColor.colorDrawing, conturColor.colorDrawing, VectorEditorApp.thickness));
            Invalidate();
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                VectorEditorApp.figures.Last.Value.EditSize(x, y);
                Invalidate();
            }
        }
        public override void MouseUpHandler()
        {
            currentState = States.initial;
        }
        public override void MouseLeaveHandler()
        {
            currentState = States.initial;
        }
        public override void MouseEnterHandler(int x, int y)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MouseDownHandler(x, y);
            }
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color fillColor, int thickness)
        {
            return new Pencil(x1, y1, thickness, conturColor);
        }
    }
}
