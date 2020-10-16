using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class LinesBrush : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            var rectangle = new GeometryGroup();
            rectangle.Children.Add(new RectangleGeometry(new Rect(0, 0, 100, 50)));
            rectangle.Children.Add(new RectangleGeometry(new Rect(50, 50, 100, 50)));

            var backgroundSquare = new GeometryDrawing(
                    Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0, 0, 100, 100)));

            LinearGradientBrush checkerBrush = new LinearGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(color, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, rectangle);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(backgroundSquare);
            checkersDrawingGroup.Children.Add(checkers);



            var brush = new DrawingBrush(checkersDrawingGroup);
            brush.Viewport = new Rect(0, 0, 10, 0.40);
            brush.TileMode = TileMode.Tile;
            return brush;
        }
    }
}
