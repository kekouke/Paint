using System;

namespace VectorEditorApplication
{
    public class FlashAnimation : Animation
    {
        private double _speed;
        private double _ticks;
        private readonly int _factor;


        public FlashAnimation(double value)
        {
            _speed = value;
            _ticks = 0;
            _factor = 1000;
        }

        private void FlashContur(Figure shape)
        {
            shape.p.Brush.Opacity -= Math.Sin(_ticks);
        }

        private void FlashFill(Figure shape)
        {
            shape.brush.Opacity -= Math.Sin(_ticks);
        }

        public override void Tick(Figure shape)
        {
            _ticks = (_ticks + 1) % _factor;

            if (shape.brush != null)
            {
                FlashFill(shape);
            }

            FlashContur(shape);
        }
    }
}
