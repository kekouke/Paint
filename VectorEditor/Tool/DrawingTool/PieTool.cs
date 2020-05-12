using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;
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
            conturColor = new ConturColorConfig(System.Windows.Media.Colors.Black);
            fillColor = new FillColorConfig(System.Windows.Media.Colors.White);
            dashStyle = new DashStyleConfig(System.Drawing.Drawing2D.DashStyle.Solid);
            hatchStyle = new HatchBrushConfig(System.Drawing.Drawing2D.HatchStyle.ZigZag);
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

        public override void MouseDownHandler(int x, int y)
        {
            Pen pen = new Pen(conturColor.colorDrawing);
            pen.DashStyle = dashStyle.dashStyle;
            pen.Width = thickness.Thickness;

            VectorEditorApp.figures.AddLast(CreateLayout(x, y, x, y, pen));
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
            LayoutToPie(VectorEditorApp.figures.Last.Value as Ellipse);
            Invalidate();
        }

        private Figure CreateLayout(int x1, int y1, int x2, int y2, Pen pen)
        {
            return new Ellipse(x1, y1, x2, y2, pen, new HatchBrush(hatchStyle.fillStyle, conturColor.colorDrawing, fillColor.colorDrawing));
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Pen pen)
        {
            return new Pie(x1, y1, x2, y2, pen, new HatchBrush(hatchStyle.fillStyle,
                (hatchStyle.Configurator as ComboBox).SelectedItem.ToString() == "None" ? fillColor.colorDrawing : conturColor.colorDrawing,
                fillColor.colorDrawing),
                startAngleConfig.startAngle, sweepAngleConfig.sweepAngle);
        }

        private void LayoutToPie(Ellipse rect)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(rect.leftXDraw, rect.leftYDraw, rect.rightXDraw, rect.rightYDraw,
                                            rect.p));

            VectorEditorApp.figures.Remove(VectorEditorApp.figures.Last.Previous);
        }

    }
}
