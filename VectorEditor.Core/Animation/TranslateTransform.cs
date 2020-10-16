using System;

namespace VectorEditorApplication
{
    public class TranslateAnimation : Animation
    {
        private double _speed;
        private double _angle = 0;

        public TranslateAnimation(double value)
        {
            _speed = value * 10;
        }

        public override void Tick(Figure shape)
        {
            _angle = (_angle + 1) % 360;
            shape.offsetX = Math.Sin(_angle / Math.PI) * _speed;
            shape.offsetY = Math.Cos(_angle / Math.PI) * _speed;
        }
    }
}
