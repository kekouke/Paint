using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class PieTool : DrawingTool
    {

        private ConturColorConfig conturColor;
        private FillColorConfig fillColor;
        private DashStyleConfig dashStyle;
        private HatchBrushConfig hatchStyle;
        private ThicknessConfig thickness;
        private PieConfigStart startAngleConfig;
        private PieConfigSweep sweepAngleConfig;

        public ConturColorConfig ConturColor { get => conturColor; set => ConturColor = value; }
        public FillColorConfig FillColor { get => fillColor; set => FillColor = value; }
        public DashStyleConfig DashStyle { get => dashStyle; set => DashStyle = value; }
        public HatchBrushConfig HatchStyle { get => hatchStyle; set => HatchStyle = value; }
        public ThicknessConfig Thickness { get => thickness; set => Thickness = value; }
        public PieConfigStart StartAngleConfig { get => startAngleConfig; set => StartAngleConfig = value; }
        public PieConfigSweep SweepAngleConfig { get => sweepAngleConfig; set => SweepAngleConfig = value; }


        public PieTool()
        {
            conturColor = new ConturColorConfig(Colors.Black);
            fillColor = new FillColorConfig(Colors.White);
            dashStyle = new DashStyleConfig(typeof(SolidPen));
            hatchStyle = new HatchBrushConfig(typeof(SolidBrush));
            thickness = new ThicknessConfig(1);
            startAngleConfig = new PieConfigStart(0);
            sweepAngleConfig = new PieConfigSweep(360);

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Pie",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point firstPoint)
        {
            Pen pen = PenPicker.GetPen(dashStyle.Pencil).GetPen(conturColor.Color, thickness.Thickness);

            PaintController.figures.AddLast(CreateLayout(firstPoint, firstPoint, pen));
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(Point secondPoint)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(secondPoint);
            }
        }

        public override void MouseUpHandler()
        {
            currentState = States.initial;
            LayoutToPie(PaintController.figures.Last.Value as Ellipse);
        }

        private Figure CreateLayout(Point firstPoint, Point secondPoint, Pen pen)
        {
            return new Ellipse(firstPoint, secondPoint, pen, BrushPicker.GetBrush(hatchStyle.Brush).GetBrush(fillColor.Color));
        }

        protected override Figure CreateFigure(Point firstPoint, Point secondPoint, Pen pen)
        {
            return new Pie(firstPoint, secondPoint, pen, BrushPicker.GetBrush(hatchStyle.Brush).GetBrush(fillColor.Color),
                startAngleConfig.startAngle, sweepAngleConfig.sweepAngle);
        }

        private void LayoutToPie(Ellipse rect)
        {
            PaintController.figures.AddLast(CreateFigure(rect.firstDrawPoint, rect.secondDrawPoint,
                                            rect.p));

            PaintController.figures.Remove(PaintController.figures.Last.Previous);
        }

    }
}
