using System;


namespace VectorEditorApplication
{
    class ScaleAnimation : Animation
    {
        private double _speed;
        private double _ticks = 0;
        private double _delay;
        private double _nextFrame;
        private double _currentTime;
        private double frame = 0.25;

        public ScaleAnimation(double value)
        {
            _speed = value / 30;
            _currentTime = 0;
            _nextFrame = 0;
            _delay = _speed / 2;
        }

        public override void Tick(Figure shape)
        {   
            if (_currentTime >= _nextFrame)
            {
                _ticks = (_ticks + 1) % 10000;
                shape.scale += Math.Sin(_ticks) * _speed;
                _nextFrame += _delay;
            }
            _currentTime += frame;
        }
    }
}
