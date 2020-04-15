﻿using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class PencilTool : Tool
    {
        public override void MouseDownHandler(int x, int y)
        {
            VectorEditorApp.figures.AddLast(CreateFigure(x, y, VectorEditorApp.thickness, VectorEditorApp.thickness, VectorEditorApp.conturColor, VectorEditorApp.gradientColor));
            MergeBitmapAndImage();
            currentState = States.mouseClick;
        }
        public override void MouseMoveHandler(int x, int y)
        {
            if (currentState == States.mouseClick)
            {
                VectorEditorApp.figures.AddLast(CreateFigure(x, y, VectorEditorApp.thickness, VectorEditorApp.thickness, VectorEditorApp.conturColor, VectorEditorApp.gradientColor));
                MergeBitmapAndImage();
            }
            /*
            else if (currentDrawingProcess == DrawingProcess.inNotDisplay)
             {
                 if (Mouse.LeftButton == MouseButtonState.Pressed)
                 {
                     currentDrawingProcess = DrawingProcess.notDrawing;
                     StartDraw(x, y);
                 }
             }*/
        }
        public override void MouseUpHandler()
        {
            currentState = States.initial;
        }
        public override void MouseLeaveHandler()
        {

        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil(x1, y1, x2, y2, conturColor, gradientColor);
        }
    }
}