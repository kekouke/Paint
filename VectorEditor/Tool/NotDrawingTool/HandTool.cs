using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class HandTool : NotDrawingTool
    {
        private Point StartPoint { get; set; }
        private Point EndPoint { get; set; }

        public HandTool()
        {

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Hand",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point point1, ViewPort vp)
        {

            StartPoint = point1;
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(Point point2, ViewPort vp)
        {
            EndPoint = point2;
            if (currentState == States.mouseClick)
            {
                vp.StartPoint -= Point.Subtract(EndPoint, StartPoint) / vp.Scale;
                vp.EndPoint -= Point.Subtract(EndPoint, StartPoint) / vp.Scale;
                StartPoint = EndPoint;
            }
        }
    }
}