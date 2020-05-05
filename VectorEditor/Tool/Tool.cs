using System.Drawing;

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
        public virtual void MouseRightUpHandler()
        {
        }

        public static void Invalidate()
        {
            VectorEditorApp.paintBox.Clear(Color.White);
            
            foreach (var drawingFigure in VectorEditorApp.figures)
            {
                drawingFigure.Draw(VectorEditorApp.paintBox);
            }
        }
    }
}