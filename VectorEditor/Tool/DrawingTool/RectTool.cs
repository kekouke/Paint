using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Input;

namespace VectorEditorApplication
{
    public class RectTool : DrawingTool
    {
        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, VectorEditorApp.conturColor, VectorEditorApp.gradientColor));
            Invalidate();
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                VectorEditorApp.figures.Last.Value.EditSize(x, y);
                Invalidate();
            }
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Rectangle(x1, y1, x2, y2, conturColor, gradientColor);
        }
    }
}
