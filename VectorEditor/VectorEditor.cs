using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace VectorEditorApplication
{

    static class PaintTools
    {
        public static Rectangle Rectabgle
        {
            get { return new Rectangle(); }
        }
        public static Ellipse Ellipse
        {
            get { return new Ellipse(); }
        }
        public static Line Line
        {
            get { return new Line(); }
        }
        public static Pencil Pencil
        {
            get { return new Pencil(); }
        }
    }

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
            inDrawingProcess
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

        public void ResizeFigure(int x, int y)
        {
            if (currentDrawingProcess == DrawingProcess.inDrawingProcess)
            {
                if (!isNotPencil)
                {
                    geometryTools.AddLast(currentTool.CreateFigure(x, y, x, y, conturColor, gradientColor));
                }

                (geometryTools.Last.Value).EditSize(x, y);
                MergeBitmapAndImage();
            }
        }

        public void FinishDraw()
        {
            if (currentDrawingProcess == DrawingProcess.inDrawingProcess)
            {
                currentDrawingProcess = DrawingProcess.notDrawing;
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
    abstract class Tool : IDrawable
    {
        public int leftX;
        public int leftY;
        public int rightX;
        public int rightY;

        public int leftXDraw;
        public int leftYDraw;
        public int rightXDraw;
        public int rightYDraw;

        protected Color conturColor;
        protected Color gradientColor;

        public Tool()
        {

        }

        public Tool(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            this.conturColor = conturColor;
            this.gradientColor = gradientColor;
        }

        abstract public void Draw(WriteableBitmap paintBox);
        public abstract Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor);
        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

        public virtual void SetCorrectCoordinate()
        {
            if (leftX > rightX)
            {
                leftXDraw = rightX;
                rightXDraw = leftX;
            }
            else
            {
                leftXDraw = leftX;
                rightXDraw = rightX;
            }

            if (leftY > rightY)
            {
                leftYDraw = rightY;
                rightYDraw = leftY;
            }
            else
            {
                leftYDraw = leftY;
                rightYDraw = rightY;
            }

        }

    }

    class Rectangle : Tool
    {
        public Rectangle()
        {

        }

        public Rectangle(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Rectangle(x1, y1, x2, y2, conturColor, gradientColor);
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawRectangle(leftXDraw - 1, leftYDraw - 1, rightXDraw, rightYDraw, conturColor);
            paintBox.FillRectangle(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }

    }

    class Ellipse : Tool
    {
        public Ellipse()
        {

        }

        public Ellipse(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Ellipse(x1, y1, x2, y2, conturColor, gradientColor);
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawEllipse(leftXDraw - 1, leftYDraw - 1, rightXDraw + 1, rightYDraw + 1, conturColor);
            paintBox.FillEllipse(leftXDraw, leftYDraw, rightXDraw, rightYDraw, gradientColor);
        }
    }

    class Line : Tool
    {

        public Line()
        {

        }

        public Line(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Line(x1, y1, x2, y2, conturColor, gradientColor);
        }

        public override void SetCorrectCoordinate()
        {
            leftYDraw = leftY;
            rightYDraw = rightY;
            leftXDraw = leftX;
            rightXDraw = rightX;
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            SetCorrectCoordinate();
            paintBox.DrawLine(leftXDraw, leftYDraw, rightXDraw, rightYDraw, conturColor);
        }
    }

    class Pencil : Tool
    {
        public Pencil()
        {

        }

        public Pencil(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor) : base(x1, y1, x2, y2, conturColor, gradientColor)
        {

        }

        static int xcord, ycord;

        override public void Draw(WriteableBitmap paintBox)
        {

            paintBox.DrawLine(leftX, leftY, rightX, rightY, conturColor);

            xcord = rightX;
            ycord = rightY;

        }

        public override void SetCorrectCoordinate()
        {
            leftYDraw = leftY;
            rightYDraw = rightY;
            leftXDraw = leftX;
            rightXDraw = rightX;
        }

        public override Tool CreateFigure(int x1, int y1, int x2, int y2, Color conturColor, Color gradientColor)
        {
            return new Pencil(x1, y1, x2, y2, conturColor, gradientColor);
        }

        public override void EditSize(int x, int y)
        {
            leftX = xcord;
            leftY = ycord;
            rightX = x;
            rightY = y;
        }

    }

}
