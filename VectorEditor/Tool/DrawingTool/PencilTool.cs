using System.Drawing;
using System.Windows.Input;

namespace VectorEditorApplication
{
    public class PencilTool : DrawingTool
    {

        private ConturColorConfig conturColor;
        private DashCapConfig dashStyle;
        private ThicknessConfig thickness;

        public ConturColorConfig ConturColor { get { return conturColor; } set { ConturColor = value; } }
        public DashCapConfig DashStyle { get { return dashStyle; } set { DashStyle = value; } }
        public ThicknessConfig Thickness { get { return thickness; } set { Thickness = value; } }

        public PencilTool()
        {
            conturColor = new ConturColorConfig(System.Windows.Media.Colors.Black);
            dashStyle = new DashCapConfig(System.Drawing.Drawing2D.DashStyle.Solid);
            thickness = new ThicknessConfig(1);
        }

        public override void MouseDownHandler(int x, int y)
        {
            Pen pen = new Pen(conturColor.colorDrawing);
            pen.DashStyle = dashStyle.dashStyle;
            pen.Width = thickness.Thickness;

            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, pen));
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

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Pen pen)
        {
            return new Pencil(x1, y1, pen);
        }
    }
}
