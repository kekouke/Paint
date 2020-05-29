namespace VectorEditorApplication
{
    public class ScaleAnimation : Animation
    {

        private bool _direction = true;
        private double _speed;

        public ScaleAnimation(double value)
        {
            _speed = value;
        }

        public override void Tick(Figure shape)
        {
            if (_direction)
            {
                shape.scale += _speed / 10;
            }
            else
            {
                shape.scale -= _speed / 10;
            }

            if (shape.scale > _speed)
            {
                _direction = false;
            }
            else if (shape.scale < _speed / 5)
            {
                _direction = true;
            }

        }
    }
}
