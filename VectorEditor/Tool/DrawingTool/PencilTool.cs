﻿using System.Windows.Media;
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

        public override void MouseDownHandler(int x, int y)
        {
            Pen pen = PenPicker.GetPen(dashStyle.Pencil).GetPen(conturColor.Color, thickness.Thickness);

            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, pen));
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                VectorEditorApp.figures.Last.Value.EditSize(x, y);
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
