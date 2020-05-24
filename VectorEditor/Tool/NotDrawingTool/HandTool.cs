using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class HandTool //: NotDrawingTool
    {
        /*List<Point> handPoint;
        public static bool handActive;
        public static bool handForNewViewport = true;
        
        public HandTool()
        {
            handPoint = new List<Point>();
            handActive = false;

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Hand",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(int x, int y)
        {

            //scrollViewer.ScrollToVerticalOffset(VectorEditorApp.screenOffsetY);

            if (handForNewViewport)
            {
                VectorEditorApp.screenOffsetX = VectorEditorApp.scaleX * VectorEditorApp.distanceToPointX;
                VectorEditorApp.screenOffsetY = VectorEditorApp.scaleY * VectorEditorApp.distanceToPointY;
                handForNewViewport = false;
            }

            handPoint.Add(new Point(x, y));
            handActive = true;
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                handPoint.Add(new Point(x, y));
                VectorEditorApp.screenOffsetX -= handPoint[handPoint.Count - 1].X - handPoint[handPoint.Count - 2].X;
                VectorEditorApp.screenOffsetY -= handPoint[handPoint.Count - 1].Y - handPoint[handPoint.Count - 2].Y;
            }
        }

        public override void MouseUpHandler()
        {
            handPoint.Clear();
            handActive = false;
            currentState = States.initial;
            //VectorEditorApp.screenOffsetX = 0;
            // VectorEditorApp.screenOffsetY = 0;
        }*/
    }
}