using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media; // Delete later

namespace VectorEditorApplication
{
    public class ZoomTool : Tool
    {
        public override void MouseDownHandler(int x, int y)
        {
        }
        public override void MouseMoveHandler(int x, int y)
        {
        }
        public virtual void MouseUpHandler()
        {
            currentState = States.initial;
        }
        public virtual void MouseLeaveHandler()
        {
        }
        public virtual void MouseEnterHandler(int x, int y)
        {
        }

        // Delete later
        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil();
        }

    }
}
