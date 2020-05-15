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
    [KnownType(typeof(Pencil))]
    [DataContract]
    public abstract class Figure : IDrawable
    {

        public Pen p;
        public HatchBrush hBrush;

        [DataMember]
        public PenDataObject penDataObject;

        [DataMember]
        public int leftX;

        [DataMember]
        public int leftY;

        [DataMember]
        public int rightX;

        [DataMember]
        public int rightY;

        public Figure()
        {

        }

        public Figure(Pen pen)
        {
            penDataObject = new PenDataObject() { penColor = pen.Color, penWidth = pen.Width, penStyle = pen.DashStyle };
        }

        public Figure(int x1, int y1, int x2, int y2, Pen pen, HatchBrush brush) : this(pen)
        {
            leftX = x1;
            leftY = y1;
            rightX = x2;
            rightY = y2;
            p = pen;
            hBrush = brush;
        }

        abstract public void Draw(Graphics paintBox);

        abstract public void SetData();

        public virtual void EditSize(int x, int y)
        {
            rightX = x;
            rightY = y;
        }

        public struct PenDataObject
        {
            public Color penColor;
            public float penWidth;
            public DashStyle penStyle;
        }

    }
}
