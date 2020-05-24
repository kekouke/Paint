using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class ZoomTool //: NotDrawingTool
    {
       /* LinkedList<Point> zoomPoint;
        public static bool justClick;
        private bool _zoom;

        public ZoomTool()
        {
            zoomPoint = new LinkedList<Point>();
            justClick = false;
            _zoom = false;

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Zoom",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(int x, int y)
        {
            if (_zoom == false)
            {
                zoomPoint.AddLast(new Point(x, y));
                zoomPoint.AddLast(new Point(x, y));
                HandTool.handForNewViewport = true;
                currentState = States.mouseClick;
            }
        }

        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick && !_zoom)
            {
                zoomPoint.Last.Value = new Point(x, y);
            }
        }
        public override void MouseUpHandler()
        {
            if (_zoom == false)
            {
                _zoom = true;
                FieldCalculate();
                zoomPoint.Clear();
                MakeRatio();
                currentState = States.initial;
            }
        }

        public override void MouseRightUpHandler()
        {
            _zoom = false;
        }

        private void FieldCalculate()
        {
            if (Point.Subtract(zoomPoint.First.Value, zoomPoint.Last.Value).Length > 30)
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
                VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y / VectorEditorApp.scaleY;
            }
        }

        private void MakeRatio()
        {
            VectorEditorApp.scaleY = (VectorEditorApp.scaleY + VectorEditorApp.scaleX) / 2;
            VectorEditorApp.scaleX = VectorEditorApp.scaleY;
        }*/
    }
}