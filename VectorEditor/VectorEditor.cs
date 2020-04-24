using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VectorEditorApplication
{

    class VectorEditorApp
    {
        public static WriteableBitmap paintBox;
        public static LinkedList<IDrawable> figures = new LinkedList<IDrawable>();
        //public static List<IDrawable> figuresHistory;
        public Tool currentTool = new RectTool();
        public static Color gradientColor;
        public static Color conturColor;
        public static int thickness;
        public ToolPicker toolPicker;
        public static double screenOffsetX;
        public static double screenOffsetY;
        public static double scaleX;
        public static double scaleY;
        public static double imageWidth;
        public static double imageHeight;
        public static double distanceToPointX;
        public static double distanceToPointY;

        public VectorEditorApp(WriteableBitmap paintBox)
        {
            VectorEditorApp.paintBox = paintBox;
            toolPicker = new ToolPicker();
        }

        public void SetCurrentTool(Tool currentTool)
        {
            this.currentTool = currentTool;
        }

        public void SetConturColor(Color color)
        {
            conturColor = color;
        }

        public void SetGradientColor(Color color)
        {
            gradientColor = color;
        }

        public void SetThicknessValue(int thickness)
        {
            VectorEditorApp.thickness = thickness;
        }

        public void SetImageboxSize(double height, double width)
        {
            imageHeight = height;
            imageWidth = width;
        }

        public WriteableBitmap SetSizeBitmap(WriteableBitmap bitmap)
        {
            paintBox = bitmap;
            return paintBox;
        } //TODO
        
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

    }
    interface IDrawable
    {
        void Draw(WriteableBitmap paintBox);
        void EditSize(int x, int y);
    }
}
