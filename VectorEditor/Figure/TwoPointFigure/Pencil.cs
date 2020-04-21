using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace VectorEditorApplication
{
    class Pencil : TwoPointFigure
    {
        private int width;

        public Pencil()
        {

        }

        public Pencil(int x1, int y1, int width, Color conturColor) : base(x1, y1, conturColor)
        {
            this.width = width;
        }

        override public void Draw(WriteableBitmap paintBox)
        {
            if (width < 2)
            {
                paintBox.DrawPolyline(points.ToArray(), conturColor);
            }
            else
            {
                for (int i = 2; i <= points.Count - 2; i += 2)
                {
                    paintBox.FillEllipseCentered(points[i - 2], points[i - 1], width, width, conturColor);
                }
            }

        }
        public override void EditSize(int x, int y)
        {
            List<int> tmp = Interpolate(points[points.Count - 2], points[points.Count - 1], x, y, width).ConvertAll(new Converter<double, int>(Convert.ToInt32));
            points.InsertRange(points.Count, tmp);
        }
        private List<double> Interpolate(int x1, int y1, int x2, int y2, int width)
        {
            // Initial
            List<double> tmpList = new List<double>();
            tmpList.Add(x1);
            tmpList.Add(y1);
            double offsetX = x1;
            double offsetY = y1;

            // Parallax calculations
            double dx = Math.Abs(x1 - x2);
            double dy = Math.Abs(y1 - y2);
            double lenght = Math.Sqrt(dx * dx + dy * dy);
            double integralPoints = 2 * lenght / width;
            double Xparallax = dx / integralPoints;
            double Yparallax = dy / integralPoints;

            // Interpolate
            for (int i = 0; i < integralPoints; i++)
            {
                if (x1 > x2 && y1 > y2)
                {
                    offsetX = offsetX - Xparallax;
                    offsetY = offsetY - Yparallax;
                }
                else if (x1 < x2 && y1 < y2)
                {
                    offsetX = offsetX + Xparallax;
                    offsetY = offsetY + Yparallax;
                }
                else if (x1 > x2 && y1 < y2)
                {
                    offsetX = offsetX - Xparallax;
                    offsetY = offsetY + Yparallax;
                }
                else if (x1 < x2 && y1 > y2)
                {
                    offsetX = offsetX + Xparallax;
                    offsetY = offsetY - Yparallax;
                }
                tmpList.Add(offsetX);
                tmpList.Add(offsetY);
            }

            tmpList.Add(x2);
            tmpList.Add(y2);

            return tmpList;
            
        }
    }              
}
