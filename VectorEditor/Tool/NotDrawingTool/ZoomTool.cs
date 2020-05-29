using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace VectorEditorApplication
{
    public class ZoomTool : NotDrawingTool
    {
        Point NewScreen { get; set; }

        public ZoomTool()
        {
            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Zoom",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point point, ViewPort vp)
        {
            Figure zoomLayout = new Rectangle(point, point, new Pen(new SolidColorBrush(Colors.Red), 3), new SolidColorBrush());
            zoomLayout.ToLocalSpace(vp);

            PaintController.figures.AddLast(zoomLayout);
            currentState = States.mouseClick;
            StartPoint = zoomLayout.firstPoint;
            EndPoint = zoomLayout.firstPoint;
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
            if (vp.Scale > 50)
            {
                return;
            }

            if (Point.Subtract(StartPoint, EndPoint).Length > 2)
            {
                double scaleX = (vp.EndPoint.X - vp.StartPoint.X) / (EndPoint.X - StartPoint.X);
                double scaleY = (vp.EndPoint.Y - vp.StartPoint.Y) / (EndPoint.Y - StartPoint.Y);
                double scale = (scaleX + scaleY) / 2;

                vp.Scale *= scale;
                vp.StartPoint = StartPoint;
                vp.EndPoint = EndPoint;
            }
            else
            {               
                double NewWidth = (vp.EndPoint.X - vp.StartPoint.X) / 2;
                double NewHeight = (vp.EndPoint.Y - vp.StartPoint.Y) / 2;
                vp.StartPoint = new Point()
                {
                    X = StartPoint.X - NewWidth / 2,
                    Y = StartPoint.Y - NewHeight / 2
                };
                vp.EndPoint = new Point()
                {
                    X = vp.StartPoint.X + NewWidth,
                    Y = vp.StartPoint.Y + NewHeight
                };
                vp.Scale *= 2;
            }
        }
        
        public override void MouseRightUpHandler(ViewPort vp, Point point)
        {
            StartPoint = point;
            if (vp.Scale > 0.1)
            {
                double NewWidth = (vp.EndPoint.X - vp.StartPoint.X) * 2;
                double NewHeight = (vp.EndPoint.Y - vp.StartPoint.Y) * 2;
                vp.StartPoint = new Point()
                {
                    X = StartPoint.X / vp.Scale + vp.StartPoint.X - NewWidth / 2,
                    Y = StartPoint.Y / vp.Scale + vp.StartPoint.Y - NewHeight / 2
                };
                vp.EndPoint = new Point()
                {
                    X = vp.StartPoint.X + NewWidth,
                    Y = vp.StartPoint.Y + NewHeight
                };
                vp.Scale /= 2;
            }
        }
    }
}