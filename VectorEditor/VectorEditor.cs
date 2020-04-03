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
        public WriteableBitmap paintBox;
        public LinkedList<IDrawable> geometryTools = new LinkedList<IDrawable>();
        Tool currentTool = new Rectangle();
        private DrawingProcess currentDrawingProcess;
        public bool isNotPencil;
        Color gradientColor;
        Color conturColor;

        private enum DrawingProcess
        {
            notDrawing,
            inDrawingProcess,
            inNotDisplay
        }

        public VectorEditorApp(WriteableBitmap paintBox)
        {
            this.paintBox = paintBox;
            currentDrawingProcess = DrawingProcess.notDrawing;
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
        }

        public void StartDraw(int x1, int y1)
        {
            if (currentDrawingProcess == DrawingProcess.notDrawing)
            {
                geometryTools.AddLast(currentTool.CreateFigure(x1, y1, x1, y1, conturColor, gradientColor));
                MergeBitmapAndImage();
                currentDrawingProcess = DrawingProcess.inDrawingProcess;
            }
        }

        public void MouseMoveHandler(int x, int y)
        {
            if (currentDrawingProcess == DrawingProcess.inDrawingProcess)
            {
                ResizeFigure(x, y);
            }
            else if (currentDrawingProcess == DrawingProcess.inNotDisplay)
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    currentDrawingProcess = DrawingProcess.notDrawing;
                    StartDraw(x, y);
                }
            }
        }

        public void ResizeFigure(int x, int y)
        {
            if (!isNotPencil)
            {
                geometryTools.AddLast(currentTool.CreateFigure(x, y, x, y, conturColor, gradientColor));
            }

            (geometryTools.Last.Value).EditSize(x, y);
            MergeBitmapAndImage();

        }

        public void FinishDraw()
        {
            if (currentDrawingProcess == DrawingProcess.inDrawingProcess)
            {
                currentDrawingProcess = DrawingProcess.notDrawing;
            }
        }

        public void MouseOutOfRange()
        {
            if (currentDrawingProcess == DrawingProcess.inDrawingProcess)
            {
                currentDrawingProcess = DrawingProcess.inNotDisplay;
            }
        }

        public void MergeBitmapAndImage()
        {
            paintBox.Clear();

            foreach (var drawingFigure in geometryTools)
            {
                drawingFigure.Draw(paintBox);
            }
        }

    }
    interface IDrawable
    {
        void Draw(WriteableBitmap paintBox);
        void EditSize(int x, int y);
    }
}
