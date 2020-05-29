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

        public abstract void MouseDownHandler(Point firstPoint, ViewPort vp);
        public abstract void MouseMoveHandler(Point secondPoint, ViewPort vp);
        public virtual void MouseUpHandler(ViewPort vp)
        {
            currentState = States.initial;
        }
        public virtual void MouseLeaveHandler()
        {
        }
        public virtual void MouseEnterHandler(int x, int y)
        {
        }
        public virtual void MouseRightUpHandler(ViewPort vp, Point point)
        {
        }
    }
}