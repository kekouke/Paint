using System.Windows;

namespace VectorEditorApplication
{
    public class ViewPort
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double Scale { get; set; }
        public ViewPort(Point point1, Point point2)
        {
            StartPoint = point1;
            EndPoint = point2;
            Scale = 1;
        }

        public override string ToString()
        {
            return "" + StartPoint + " " + EndPoint;
        }

    }
}
