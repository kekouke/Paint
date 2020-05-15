using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace VectorEditorApplication
{
    class VectorEditorApp
    {
        public static Graphics paintBox;

        public static LinkedList<Figure> figures;

        public ToolPicker toolPicker;

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

        public VectorEditorApp(Bitmap paintBox)
        {
            VectorEditorApp.paintBox = Graphics.FromImage(paintBox);
            figures = new LinkedList<Figure>();
            toolPicker = new ToolPicker();
            currentScaleX = 1;
            currentScaleY = 1;
            isZoomed = false;
        }

        public void SetImageboxSize(double height, double width)
        {
            imageHeight = height;
            imageWidth = width;
        }

       // public Bitmap SetSizeBitmap(Bitmap bitmap)
       // {
       //     paintBox = bitmap;
       //     return paintBox;
        //} //TODO
        
        public void GoBack()
        {

            if (figures.Count > 0)
            {
                figures.RemoveLast();
                Tool.Invalidate();
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

        public void SaveImage()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(LinkedList<Figure>));

            using (var file = new FileStream("picture.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(file, figures);
            }
        }

        public void OpenImage()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(LinkedList<Figure>));

            using (var file = new FileStream("picture.json", FileMode.OpenOrCreate))
            {
                var newFigures = jsonFormatter.ReadObject(file) as LinkedList<Figure>;

                figures.Clear();

                foreach (var figure in newFigures)
                {
                    figure.SetData();
                    figures.AddLast(figure);
                }
               // MessageBox.Show(figures.Count.ToString());
            }

            Tool.Invalidate();
           // foreach (var figure in figures)
           // {
           //     figure.SetData();
           // }

            //Tool.Invalidate();
        }

    }
}
