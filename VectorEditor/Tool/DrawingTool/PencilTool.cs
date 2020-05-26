using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace VectorEditorApplication
{
    public class PencilTool : DrawingTool
    {

        private ConturColorConfig conturColor;
        private DashStyleConfig dashStyle;
        private ThicknessConfig thickness;

        public ConturColorConfig ConturColor { get => conturColor; set => ConturColor = value; }
        public DashStyleConfig DashStyle { get => dashStyle; set => DashStyle = value; }
        public ThicknessConfig Thickness { get => thickness; set => Thickness = value; }

        public PencilTool()
        {
            conturColor = new ConturColorConfig(Colors.Black);
            dashStyle = new DashStyleConfig(typeof(SolidPen));
            thickness = new ThicknessConfig(1);

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Pencil",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point firstPoint, ViewPort vp)
        {
            Pen pen = PenPicker.GetPen(dashStyle.Pencil).GetPen(conturColor.Color, thickness.Thickness);
            var localPoint = new Point(firstPoint.X / vp.Scale + vp.StartPoint.X,
                                        firstPoint.Y / vp.Scale + vp.StartPoint.Y); //TODO
           
            PaintController.figures.AddLast(CreateFigure(localPoint, localPoint, pen));
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(Point secondPoint, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(secondPoint, vp);
            }
        }
        public override void MouseLeaveHandler()
        {
            currentState = States.initial;
        }
        public override void MouseEnterHandler(int x, int y)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
               // MouseDownHandler(new Point(x, y));
            }
        }

        protected override Figure CreateFigure(Point point1, Point point2, Pen pen)
        {
            return new Pencil(point1, pen);
        }
    }
}
