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
    public abstract class Tool
    {
        protected enum States
        {
            initial,
            mouseClick,
            mouseMove,
            bouseLeave
        }
        protected States currentState = States.initial;

        public abstract void MouseDownHandler(int x, int y);
        public abstract void MouseMoveHandler(int x, int y);
        public abstract void MouseUpHandler();
        public abstract void MouseLeaveHandler();

        protected abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor);

        public void Invalidate()
        {
            VectorEditorApp.paintBox.Clear();

            foreach (var drawingFigure in VectorEditorApp.figures)
            {
                drawingFigure.Draw(VectorEditorApp.paintBox);
            }
        }
    }
}