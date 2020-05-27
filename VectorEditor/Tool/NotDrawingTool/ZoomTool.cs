using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System;

namespace VectorEditorApplication
{
    public class ZoomTool : NotDrawingTool
    {
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }
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
            if (vp.Scale > 32)
            {

            }
            else
            {
                if (Point.Subtract(StartPoint, EndPoint).Length > 2)
                {
                    double scaleX = (vp.EndPoint.X - vp.StartPoint.X) / (EndPoint.X - StartPoint.X);
                    double scaleY = (vp.EndPoint.Y - vp.StartPoint.Y) / (EndPoint.Y - StartPoint.Y);
                    double scale = (scaleX + scaleY) / 2;

                    vp.Scale *= scale;
                    vp.StartPoint = StartPoint;
                    vp.EndPoint = EndPoint;
                }
                else //TODO
                {
                    vp.Scale *= 2;
                    NewScreen = new Point((vp.EndPoint.X - vp.StartPoint.X) / vp.Scale,
                                        (vp.EndPoint.Y - vp.StartPoint.Y) / 2);

                    var offsetX = Math.Abs((NewScreen.X - (vp.EndPoint.X - vp.StartPoint.X)) / 2);
                    var offsetY = Math.Abs((NewScreen.Y - (vp.EndPoint.Y - vp.StartPoint.Y)) / 2);

                    vp.StartPoint = new Point(vp.StartPoint.X - offsetX / 2, vp.StartPoint.Y - offsetY / 2);
                    vp.EndPoint = new Point(vp.EndPoint.X + offsetX / 2, vp.EndPoint.Y + offsetY / 2);
                }
            }
            MessageBox.Show(vp.Scale.ToString());
        }

        public override void MouseRightUpHandler(ViewPort vp)
        {
            if (vp.Scale > 0.01)
            {
                vp.Scale /= 2;
            }
        }

        private void FieldCalculate()
        {
/*            if (Point.Subtract(zoomPoint.First.Value, zoomPoint.Last.Value).Length > 30)
            {
                justClick = false;

                if (zoomPoint.First.Value.X > zoomPoint.Last.Value.X)
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.First.Value.X - zoomPoint.Last.Value.X);
                    VectorEditorApp.distanceToPointX = zoomPoint.Last.Value.X;
                }
                else
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.Last.Value.X - zoomPoint.First.Value.X);
                    VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X;
                }
                if (zoomPoint.First.Value.Y > zoomPoint.Last.Value.Y)
                {
                    VectorEditorApp.scaleY = VectorEditorApp.imageHeight / (zoomPoint.First.Value.Y - zoomPoint.Last.Value.Y);
                    VectorEditorApp.distanceToPointY = zoomPoint.Last.Value.Y;
                }
                else
                {
                    VectorEditorApp.scaleY = VectorEditorApp.imageHeight / (zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y);
                    VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y;
                }
            }
            else
            {
                justClick = true;
                VectorEditorApp.scaleX = 2;
                VectorEditorApp.scaleY = 2;
                VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X / VectorEditorApp.scaleX;
                VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y / VectorEditorApp.scaleY;*/
            //}
        }
    }
}