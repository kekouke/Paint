﻿using System.Drawing;

namespace VectorEditorApplication
{
    public class EllipseTool : DrawingTool
    {
        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, x, y, VectorEditorApp.conturColor, VectorEditorApp.fillColor, VectorEditorApp.thickness));
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

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor, int width)
        {
            return new Ellipse(x1, y1, x2, y2, conturColor, gradientColor, width);
        }
    }
}
