using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class RectBrush : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            var rectangle = new GeometryGroup();
            rectangle.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            rectangle.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));

            var backgroundSquare = new GeometryDrawing(
                    Brushes.White,
                    null,
                    rectangle);

            var checkerBrush = new LinearGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(color, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Black, 1.0));

            var checkers = new GeometryDrawing(checkerBrush, null, rectangle);

            var checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(backgroundSquare);
            checkersDrawingGroup.Children.Add(checkers);

            var brush = new DrawingBrush(checkersDrawingGroup);
            brush.Viewport = new Rect(0, 0, 0.40, 0.40);
            brush.TileMode = TileMode.Tile;
            return brush;
        }

    }
}


// Create a DrawingBrush and use it to
// paint the rectangle.




/*                var brush = new DrawingBrush();
var myGeometryGroup = new GeometryGroup();
myGeometryGroup.Children.Add(new LineGeometry(new Point(10, 0), new Point(0, 10)));

            var myDrawing = new GeometryDrawing(null, new Pen(new SolidColorBrush(color), 10), myGeometryGroup);

brush.Drawing = myDrawing;

            brush.Viewbox = new Rect(0, 0, 0.25, 0.25);
//brush.ViewboxUnits = BrushMappingMode.Absolute;
brush.Viewport = new Rect(0, 0, 0.25, 0.25);
            //brush.ViewportUnits = BrushMappingMode.Absolute;
            //brush.TileMode = TileMode.FlipY;

            return brush;*/