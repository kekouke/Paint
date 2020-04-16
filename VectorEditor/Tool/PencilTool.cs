using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Input;

namespace VectorEditorApplication
{
    public class PencilTool : Tool
    {
        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, VectorEditorApp.thickness, VectorEditorApp.thickness, VectorEditorApp.conturColor, VectorEditorApp.gradientColor));
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
        public override void MouseUpHandler()
        {
            currentState = States.initial;
        }
        public override void MouseLeaveHandler()
        {
            currentState = States.initial;
        }
        public override void MouseEnterHandler(int x, int y)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MouseDownHandler(x, y);
            }
        }

        protected override Figure CreateFigure(int x1, int y1, int width,int _, Color conturColor, Color gradientColor)
        {
            return new Pencil(x1, y1, width, conturColor);
        }
    }
}
