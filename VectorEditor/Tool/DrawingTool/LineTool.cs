using System.Drawing;

namespace VectorEditorApplication
{
    public class LineTool : DrawingTool
    {
        private ConturColorConfig conturColor;

        public ConturColorConfig ConturColor { get { return conturColor; } set { ConturColor = value; } }

        public LineTool()
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

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int thickness)
        {
            return new Line(x1, y1, x2, y2, conturColor, gradientColor, thickness);
        }
    }
}
