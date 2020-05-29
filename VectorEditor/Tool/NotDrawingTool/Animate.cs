using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class Animate : NotDrawingTool
    {
        public Animate()
        {
            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Animate!",
                Margin = new Thickness(5)
            };
        }

        public override void MouseDownHandler(Point point, ViewPort vp)
        {
            Figure selectLayout = new Rectangle(point, point, PenPicker.GetPen(typeof(DashPen)).GetPen(Colors.Black, 3), new SolidColorBrush());
            selectLayout.ToLocalSpace(vp);

            PaintController.figures.AddLast(selectLayout);
            currentState = States.mouseClick;
            StartPoint = selectLayout.firstPoint;
        }

        public override void MouseMoveHandler(Point point, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(point, vp);
                EndPoint = PaintController.figures.Last.Value.secondPoint;
            }
        }

        public override void MouseUpHandler(ViewPort vp)
        {
            currentState = States.initial;
            PaintController.figures.RemoveLast();
            MakeAnimation();
        }

        private void MakeAnimation()
        {
            foreach (var item in PaintController.figures)
            {
                if (StartPoint.X < item.firstPoint.X && StartPoint.Y < item.firstPoint.Y && EndPoint.X > item.secondPoint.X
                    && EndPoint.Y > item.secondPoint.Y)
                {
                    item.brush = new SolidColorBrush(Colors.Red);
                }
            }
        }
    }
}
