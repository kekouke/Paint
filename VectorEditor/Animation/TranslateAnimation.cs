using System;

namespace VectorEditorApplication
{
    class TranslateAnimation : Animation
    {
        private double _speed;
        private double _ticks = 1;

        public TranslateAnimation(double value)
        {
            _speed = value;
        }

        public override void Tick(Figure shape)
        {
            _ticks = (_ticks + 1) % 360;
            shape.offsetX = Math.Sin(_ticks / Math.PI) * _speed;
            shape.offsetY = Math.Cos(_ticks / Math.PI) * _speed;
        }
    }
}
