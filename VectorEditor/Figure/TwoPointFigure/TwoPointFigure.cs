using System.Drawing;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VectorEditorApplication
{
    [KnownType(typeof(Pencil))]
    [DataContract]
    abstract class TwoPointFigure : Figure
    {
        [DataMember]
        public List<Point> points;

        public TwoPointFigure()
        {

        }

        public TwoPointFigure(int x, int y, Pen pen) : base(pen)
        {
            points = new List<Point>();
            points.Add(new Point(x, y));
            points.Add(new Point(x, y));
            p = pen;
        }


        override abstract public void Draw(Graphics paintBox);

        public override void SetData()
        {

            p = new Pen(penDataObject.penColor);
            p.Width = penDataObject.penWidth;
            p.DashStyle = penDataObject.penStyle;
        }

    }
}
