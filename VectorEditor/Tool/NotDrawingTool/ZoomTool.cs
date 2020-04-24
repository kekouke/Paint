using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media; // Delete it later
using System.Windows;

namespace VectorEditorApplication
{
    public class ZoomTool : Tool
    {
        LinkedList<Point> zoomPoint;
        bool zoom;

        public ZoomTool()
        {
            zoomPoint = new LinkedList<Point>();
            zoom = false;
        }

        public override void MouseDownHandler(int x, int y)
        {
            zoomPoint.AddLast(new Point(x, y));
            zoomPoint.AddLast(new Point(x, y));
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                zoomPoint.Last.Value = new Point(x, y);
            }
        }
        public override void MouseUpHandler()
        {
            if (!zoom)
            {
                FieldCalculate();

                zoomPoint.Clear();
                currentState = States.initial;
                zoom = true;
            }
        }

        public void MouseRightUpHandler()
        {
            zoom = false;
        }

        private void FieldCalculate()
        {
            if (Point.Subtract(zoomPoint.First.Value, zoomPoint.Last.Value).Length > 100)
            {
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
                VectorEditorApp.distanceToPointX = 1;
                VectorEditorApp.distanceToPointY = 1;
                VectorEditorApp.scaleX = 2;
                VectorEditorApp.scaleY = 2;
            }
        }

        // Delete it later
        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil();
        }

    }
}
