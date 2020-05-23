using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace VectorEditorApplication
{
    class VectorEditorApp
    {

        public static LinkedList<Figure> figures;

        public ToolPicker toolPicker;

        private readonly DrawingObject canvas;

        public static double screenOffsetX;
        public static double screenOffsetY;
        public static double scaleX;
        public static double scaleY;
        public static double currentScaleX;
        public static double currentScaleY;
        public static double imageWidth;
        public static double imageHeight;
        public static double distanceToPointX;
        public static double distanceToPointY;
        public bool isZoomed;

        public VectorEditorApp(DrawingObject canvas)
        {
            this.canvas = canvas;
            figures = new LinkedList<Figure>();
            toolPicker = new ToolPicker();
            currentScaleX = 1;
            currentScaleY = 1;
            isZoomed = false;

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
        
        public void GoBack()
        {

            if (figures.Count > 0)
            {
                figures.RemoveLast();
                //Tool.Invalidate();
            }
        }

        public void GoNext()
        {
/*            if (figures.Count < figuresHistory.Count)
            {
                figures.AddLast(figuresHistory[figures.Count]);
                figuresHistory.RemoveAt(figuresHistory.Count - 1);
                Tool.Invalidate();
            }*/
        } //TODO

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
                    MessageBox.Show("Ошибка в чтении файла! Возможно файл поврежден");
                }
            }
        }

        public void Invalidate()
        {
            canvas.Invalidate(figures);
        }

    }
}
