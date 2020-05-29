namespace VectorEditorApplication
{
    public class FlashAnimation : Animation
    {
        private double _speed;

        public FlashAnimation(double value)
        {
            _speed = value;
        }

        public override void Tick(Figure shape)
        {
            if (shape.brush != null)
            {
                if (shape.p.Brush.Opacity >= 0)
                {
                    shape.brush.Opacity -= (1 / _speed);
                    shape.p.Brush.Opacity -= (1 / _speed);
                }
                else
                {
                    while (shape.p.Brush.Opacity < 1)
                    {
                        shape.brush.Opacity += (1 / _speed);
                        shape.p.Brush.Opacity += (1 / _speed);
                    }
                }
            }
            else
            {
                if (shape.p.Brush.Opacity >= 0)
                {
                    shape.p.Brush.Opacity -= (1 / _speed);
                }
                else
                {
                    while (shape.p.Brush.Opacity < 1)
                    {
                        shape.p.Brush.Opacity += (1 / _speed);
                    }
                }
            }
        }
    }
}
