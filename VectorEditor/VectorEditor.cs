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
        public Tool currentTool = new RectTool();
        public bool isNotPencil;
        public static Color gradientColor;
        public static Color conturColor;

        public VectorEditorApp(WriteableBitmap paintBox)
        {
            VectorEditorApp.paintBox = paintBox;
            isNotPencil = true;
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

        public WriteableBitmap SetSizeBitmap(WriteableBitmap bitmap)
        {
            paintBox = bitmap;
            return paintBox;
        } //TODO

        public void MouseOutOfRange()
        {

        }

    }
    interface IDrawable
    {
        void Draw(WriteableBitmap paintBox);
        void EditSize(int x, int y);
    }
}
