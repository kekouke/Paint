using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace VectorEditorApplication
{
    public class RectTool : DrawingTool
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

        public RectTool()
        {
            conturColor = new ConturColorConfig(Colors.Black);
            fillColor = new FillColorConfig(Colors.White);
            thickness = new ThicknessConfig(1);
            dashStyle = new DashStyleConfig(typeof(SolidPen));
            hatchStyle = new HatchBrushConfig(typeof(SolidBrush));

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Rectangle",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point firstPoint, ViewPort vp)
        {
            Pen pen = PenPicker.GetPen(dashStyle.Pencil).GetPen(conturColor.Color, thickness.Thickness);
            Figure localFigure = CreateFigure(firstPoint, firstPoint, pen);
            localFigure.ToLocalSpace(vp);

            PaintController.figures.AddLast(localFigure);
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(Point secondPoint, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(secondPoint, vp);
            }
        }

        protected override Figure CreateFigure(Point point1, Point point2, Pen pen)
        {
            return new Rectangle(point1, point2, pen, BrushPicker.GetBrush(hatchStyle.Brush).GetBrush(fillColor.Color));                             
        }
    }
}
