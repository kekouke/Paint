using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Pie))]
    [KnownType(typeof(Line))]
    [DataContract]
    abstract public class FourPointFigure : Figure
    {
        public int leftXDraw;
        public int leftYDraw;
        public int rightXDraw;
        public int rightYDraw;

        [DataMember]
        public HatchDataObject hatchDataObject;

        public FourPointFigure()
        {

        }

        public FourPointFigure(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush) : base(x1, y1, x2, y2, pen, brush)
        {
            hatchDataObject = new HatchDataObject() { backgroungColor = brush.BackgroundColor, foregroundColor = brush.ForegroundColor,
                hatchStyle = brush.HatchStyle };
        }

        override abstract public void Draw(Graphics paintBox);

        public void SetCorrectCoordinate()
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

        public override void SetData()
        {
            p = new Pen(penDataObject.penColor);

            p.Width = penDataObject.penWidth;
            p.DashStyle = penDataObject.penStyle;

            hBrush = new HatchBrush(hatchDataObject.hatchStyle, hatchDataObject.foregroundColor, hatchDataObject.backgroungColor);
        }

        public struct HatchDataObject
        {
            public Color backgroungColor;
            public Color foregroundColor;
            public HatchStyle hatchStyle;
        }

    }

}
