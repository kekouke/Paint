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
        public static List<IDrawable> figuresHistory = new List<IDrawable>();
        public Tool currentTool = new RectTool();
        public static Color gradientColor;
        public static Color conturColor;
        public static int thickness;
        public ToolPicker toolPicker;

        private int countOfFigures = 0;

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

        public WriteableBitmap SetSizeBitmap(WriteableBitmap bitmap)
        {
            paintBox = bitmap;
            return paintBox;
        } //TODO
        
        public void GoBack()
        {
            if (countOfFigures > 0)
            {

                foreach (var element in figures)
                {
                    figuresHistory.Add(element);
                }

                figures.RemoveLast();
                Tool.Invalidate();
                countOfFigures--;
            }
        }

        public void GoNext()
        {
            if (countOfFigures < figuresHistory.Count)
            {
                figures.AddLast(figuresHistory[countOfFigures]);
                Tool.Invalidate();
                countOfFigures++;
            }
        }

    }
    interface IDrawable
    {
        void Draw(WriteableBitmap paintBox);
        void EditSize(int x, int y);
    }
}
