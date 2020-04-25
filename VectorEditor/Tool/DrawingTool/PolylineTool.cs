using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{
    public class PolylineTool : DrawingTool
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
        public override void MouseEnterHandler(int x, int y)
        {
            //throw new NotImplementedException();
        }

        protected override Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Polyline(x1, y1, x2, y2, conturColor, gradientColor);
        }
    }
}
