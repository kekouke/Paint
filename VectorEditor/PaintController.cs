using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace VectorEditorApplication
{
    class PaintController
    {
        private readonly DrawingObject canvas;

        public static LinkedList<Figure> figures;
        public ToolPicker toolPicker;
        public ViewPort vp;

        public static double imageWidth;
        public static double imageHeight;

        public Point startPoint;
        public Point endPoint;

        public PaintController(DrawingObject canvas)
        {
            this.canvas = canvas;
            figures = new LinkedList<Figure>();
            toolPicker = new ToolPicker();

            startPoint = new Point(0, 0);
            endPoint = new Point(769, 385);
            
            vp = new ViewPort(startPoint, endPoint);

            BrushPicker.AddBrush(new SolidBrush());
            BrushPicker.AddBrush(new RectBrush());
            BrushPicker.AddBrush(new LinesBrush());

            PenPicker.AddPen(new SolidPen());
            PenPicker.AddPen(new DotPen());
            PenPicker.AddPen(new DashPen());
            PenPicker.AddPen(new DashDotPen());
            PenPicker.AddPen(new DashDotDotPen());
        }

        public void SetImageboxSize(double height, double width)
        {
            imageHeight = height;
            imageWidth = width;
        }

        public void SaveImage(string fileName)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(LinkedList<Figure>));

            using (var file = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(file, figures);
            }
        }
        public void OpenImage(string fileName)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(LinkedList<Figure>));

            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    figures = jsonFormatter.ReadObject(file) as LinkedList<Figure>;
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения файла! Возможно, файл поврежден.");
                }
            }
        }

        public void Invalidate()
        {
            canvas.Invalidate(figures, vp);
        }

    }
}