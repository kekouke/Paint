using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace VectorEditorApplication
{
    public class ZoomTool : NotDrawingTool
    {
        Point startPoint;
        Point endPoint;

        public ZoomTool()
        {
            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Zoom",
                Margin = new Thickness(5)
            };

        }

        public override void MouseDownHandler(Point point, ViewPort vp)
        {
            Figure zoomLayout = new Rectangle(point, point, new Pen(new SolidColorBrush(Colors.Red), 3), new SolidColorBrush());
            zoomLayout.ToLocalSpace(vp);

            PaintController.figures.AddLast(zoomLayout);
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(Point point, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(point, vp);
            }
        }
        public override void MouseUpHandler()
        {
            currentState = States.initial;
            PaintController.figures.RemoveLast() ;
        }

        public override void MouseRightUpHandler()
        {
        }

        private void FieldCalculate()
        {
/*            if (Point.Subtract(zoomPoint.First.Value, zoomPoint.Last.Value).Length > 30)
            {
                justClick = false;

                if (zoomPoint.First.Value.X > zoomPoint.Last.Value.X)
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.First.Value.X - zoomPoint.Last.Value.X);
                    VectorEditorApp.distanceToPointX = zoomPoint.Last.Value.X;
                }
                else
                {
                    VectorEditorApp.scaleX = VectorEditorApp.imageWidth / (zoomPoint.Last.Value.X - zoomPoint.First.Value.X);
                    VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X;
                }
                if (zoomPoint.First.Value.Y > zoomPoint.Last.Value.Y)
                {
                    VectorEditorApp.scaleY = VectorEditorApp.imageHeight / (zoomPoint.First.Value.Y - zoomPoint.Last.Value.Y);
                    VectorEditorApp.distanceToPointY = zoomPoint.Last.Value.Y;
                }
                else
                {
                    VectorEditorApp.scaleY = VectorEditorApp.imageHeight / (zoomPoint.Last.Value.Y - zoomPoint.First.Value.Y);
                    VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y;
                }
            }
            else
            {
                justClick = true;
                VectorEditorApp.scaleX = 2;
                VectorEditorApp.scaleY = 2;
                VectorEditorApp.distanceToPointX = zoomPoint.First.Value.X / VectorEditorApp.scaleX;
                VectorEditorApp.distanceToPointY = zoomPoint.First.Value.Y / VectorEditorApp.scaleY;*/
            //}
        }
    }
}