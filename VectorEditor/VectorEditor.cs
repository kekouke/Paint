using System;
using System.Collections.Generic;
using System.Drawing;

namespace VectorEditorApplication
{

    class VectorEditorApp
    {
        public static Graphics paintBox;
        public static LinkedList<IDrawable> figures;
        public Tool currentTool;
        public static int thickness;
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

        public VectorEditorApp(Bitmap paintBox)
        {
            VectorEditorApp.paintBox = Graphics.FromImage(paintBox);
            figures = new LinkedList<IDrawable>();
            toolPicker = new ToolPicker();
            currentScaleX = 1;
            currentScaleY = 1;
        }

        public void SetCurrentTool(Tool currentTool)
        {
            this.currentTool = currentTool;
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

    }
}
