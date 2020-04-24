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
            wait,
            mouseLeave,
            mouseMove
        }
        protected States currentState = States.initial;

        public abstract void MouseDownHandler(int x, int y);
        public abstract void MouseMoveHandler(int x, int y);
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

        protected abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor);

        public static void Invalidate()
        {
            VectorEditorApp.paintBox.Clear();

            foreach (var drawingFigure in VectorEditorApp.figures)
            {
                drawingFigure.Draw(VectorEditorApp.paintBox);
            }
        }
    }
}