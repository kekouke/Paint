using System;
using System.Windows;

namespace VectorEditorApplication
{
    class RotationAnimation : Animation
    {
        public double increment;
        public Point center;
        private double phi;
        public override void Tick()
        {
            phi += increment;
        }

        public override Point Transform(Point p)
        {
            throw new NotImplementedException();
        }

        public override double Transform(double angle)
        {
            throw new NotImplementedException();
        }
    }
}
