using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media; // Delete later
using Point = System.Drawing.Point;

namespace VectorEditorApplication
{
    public class HandTool : Tool
    {
        List<Point> handPoint;

        public HandTool()
        {
            handPoint = new List<Point>();
        }

        public override void MouseDownHandler(int x, int y)
        {
            handPoint.Add(new Point(x, y));
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
            currentState = States.initial;
        }

        // Delete later
        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil();
        }

    }
}
