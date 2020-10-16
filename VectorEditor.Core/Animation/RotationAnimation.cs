using System;
using System.Windows;

namespace VectorEditorApplication
{
    public class RotationAnimation : Animation
    {
        private double _speed;
        public override void Tick(Figure shape)
        {
            shape.rotationAngle = (shape.rotationAngle + _speed) % 360;
        }

        public RotationAnimation(double value)
        {
            _speed = value;
        }
    }
}
