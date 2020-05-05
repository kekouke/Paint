using System;
using System.Collections.Generic;
using System.Windows;

namespace VectorEditorApplication
{
    public class ZoomTool : NotDrawingTool
    {
        LinkedList<Point> zoomPoint;
        public static bool justClick;
        private int deepZoom;

        public ZoomTool()
        {
            zoomPoint = new LinkedList<Point>();
            justClick = false;
            deepZoom = 0;
        }

        public override void MouseDownHandler(int x, int y)
        {
            zoomPoint.AddLast(new Point(x, y));
            zoomPoint.AddLast(new Point(x, y));
            HandTool.handForNewViewport = true;
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
            deepZoom++;
            FieldCalculate();
            MakeRatio();
            zoomPoint.Clear();
            currentState = States.initial;
        }

        public override void MouseRightUpHandler()
        {
            deepZoom = 0;
        }

        private void FieldCalculate()
        {
            if (Point.Subtract(zoomPoint.First.Value, zoomPoint.Last.Value).Length > 50) // && Math.Abs(zoomPoint.First.Value.X - zoomPoint.Last.Value.X) > 20 &&  Math.Abs(zoomPoint.First.Value.Y - zoomPoint.Last.Value.Y) > 20
            {
                justClick = false;

                if (zoomPoint.First.Value.X > zoomPoint.Last.Value.X)
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.First.Value.X - zoomPoint.Last.Value.X);
                    //VectorEditorApp.distanceToPointX = zoomPoint.Last.Value.X;
                }
                else
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.Last.Value.X - zoomPoint.First.Value.X);
                    //VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X;
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
                //VectorEditorApp.distanceToPointY
            }
            else
            {
                justClick = true;
                VectorEditorApp.scaleX = 2 + deepZoom;
                VectorEditorApp.scaleY = 2 + deepZoom;
                VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X / VectorEditorApp.scaleX;
                VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y / VectorEditorApp.scaleY;
            }
        }

        private void MakeRatio()
        {
            // VectorEditorApp.distanceToPointY = VectorEditorApp.imageHeight / 2;
            VectorEditorApp.scaleX = Math.Min(VectorEditorApp.scaleX, VectorEditorApp.scaleY);
            VectorEditorApp.scaleY = Math.Min(VectorEditorApp.scaleX, VectorEditorApp.scaleY);

            //VectorEditorApp.distanceToPointX = VectorEditorApp.imageWidth / 2 / VectorEditorApp.scaleX;
            // VectorEditorApp.distanceToPointY = VectorEditorApp.imageHeight / 2 / VectorEditorApp.scaleY;

            if (Math.Abs(zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y) > Math.Abs(zoomPoint.Last.Value.X - zoomPoint.First.Value.X))
            {
                if (zoomPoint.Last.Value.X > zoomPoint.First.Value.X)
                {
                    VectorEditorApp.distanceToPointX = (zoomPoint.First.Value.X - (Math.Abs(zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y) - Math.Abs(zoomPoint.Last.Value.X - zoomPoint.First.Value.X)) / 2) * VectorEditorApp.scaleX;
                }
                else
                {
                    VectorEditorApp.distanceToPointX = (zoomPoint.Last.Value.X - (Math.Abs(zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y) - Math.Abs(zoomPoint.Last.Value.X - zoomPoint.First.Value.X)) / 2) * VectorEditorApp.scaleX;
                }
                if (zoomPoint.Last.Value.Y> zoomPoint.First.Value.Y)
                {
                    VectorEditorApp.distanceToPointY = (zoomPoint.First.Value.Y + (zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y) / 4) * (VectorEditorApp.scaleY / 2);
                }
                else
                {
                    VectorEditorApp.distanceToPointY = (zoomPoint.Last.Value.Y+ (zoomPoint.First.Value.Y - zoomPoint.Last.Value.Y) / 4) * (VectorEditorApp.scaleY / 2);
                }
            }
            else
            {
                if (zoomPoint.Last.Value.X > zoomPoint.First.Value.X)
                {
                    VectorEditorApp.distanceToPointX = (zoomPoint.First.Value.X + (zoomPoint.Last.Value.X - zoomPoint.First.Value.X) / 4) * VectorEditorApp.scaleX;
                }
                else
                {
                    VectorEditorApp.distanceToPointX = (zoomPoint.Last.Value.X + (zoomPoint.First.Value.X - zoomPoint.Last.Value.X) / 4) * VectorEditorApp.scaleX;
                }
                if (zoomPoint.Last.Value.Y> zoomPoint.First.Value.Y)
                {
                    VectorEditorApp.distanceToPointY = (zoomPoint.Last.Value.Y- (Math.Abs(zoomPoint.Last.Value.X - zoomPoint.First.Value.X) - Math.Abs(zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y)) / 2) * VectorEditorApp.scaleY;
                }
                else
                {
                    VectorEditorApp.distanceToPointY = (zoomPoint.First.Value.Y - (Math.Abs(zoomPoint.Last.Value.X - zoomPoint.First.Value.X) - Math.Abs(zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y)) / 2) * VectorEditorApp.scaleY;
                }
            }

        }
    }
}
