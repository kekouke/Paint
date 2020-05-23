using System.Windows;

namespace VectorEditorApplication
{
    public abstract class Tool
    {
        public UIElement ToolForm { get; set; }

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
    }
}