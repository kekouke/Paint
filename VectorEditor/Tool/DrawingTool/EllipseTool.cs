using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class EllipseTool : DrawingTool
    {
        private ConturColorConfig conturColor;
        private FillColorConfig fillColor;
        private DashStyleConfig dashStyle;
        private HatchBrushConfig hatchStyle;
        private ThicknessConfig thickness;


        public ConturColorConfig ConturColor { get => conturColor; set => ConturColor = value; }
        public FillColorConfig FillColor { get => fillColor; set => FillColor = value; }
        public DashStyleConfig DashStyle { get => dashStyle; set => DashStyle = value; }
        public HatchBrushConfig HatchStyle { get => hatchStyle; set => HatchStyle = value; }
        public ThicknessConfig Thickness { get => thickness; set => Thickness = value; }

        public EllipseTool()
        {
            conturColor = new ConturColorConfig(Colors.Black);
            fillColor = new FillColorConfig(Colors.White);
            dashStyle = new DashStyleConfig(typeof(SolidPen));
            hatchStyle = new HatchBrushConfig(typeof(SolidBrush));
            thickness = new ThicknessConfig(1);

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Ellipse",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point firstPoint)
        {
            Pen pen = PenPicker.GetPen(dashStyle.Pencil).GetPen(conturColor.Color, thickness.Thickness);

            PaintController.figures.AddLast(CreateFigure(firstPoint, firstPoint, pen));
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(Point secondPoint)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(secondPoint);
            }
        }

        protected override Figure CreateFigure(Point firstPoint, Point secondPoint, Pen pen)
        {
            return new Ellipse(firstPoint, secondPoint, pen, BrushPicker.GetBrush(hatchStyle.Brush).GetBrush(fillColor.Color));
        }
    }
}
