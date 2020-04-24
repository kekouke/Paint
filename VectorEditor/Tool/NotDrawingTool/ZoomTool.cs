using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media; // Delete it later

namespace VectorEditorApplication
{
    public class ZoomTool : Tool
    {
        //Point zoomPoint;
        public override void MouseDownHandler(int x, int y)
        {
/*            zoomPoint = new Point(x, y);
            currentState = States.mouseClick;*/
        }
        public override void MouseMoveHandler(int x, int y)
        {
/*            if (currentState == States.mouseClick)
            {
                currentState = States.mouseMove;
            }*/
        }
        public virtual void MouseUpHandler()
        {
/*            if (currentState == States.mouseClick)
            {
                foreach (FourPointFigure element in VectorEditorApp.figures)
                {
                    element.leftXDraw = element.leftXDraw * 2 - zoomPoint.X;
                    element.rightXDraw = element.rightXDraw * 2 - zoomPoint.X;
                    element.leftYDraw = element.leftYDraw * 2 - zoomPoint.Y;
                    element.rightYDraw = element.rightYDraw * 2 - zoomPoint.Y;
                }
                Invalidate();
                currentState = States.initial;
            }
            else if (currentState == States.mouseMove)
            {
                currentState = States.initial;
            }*/
        }
        public virtual void MouseLeaveHandler()
        {
        }
        public virtual void MouseEnterHandler(int x, int y)
        {
        }

        // Delete it later
        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil();
        }

    }
}
