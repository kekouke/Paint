using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorEditorApplication
{
    public class Animate : NotDrawingTool
    {
        private RotateConfig _rotation;
        private FlashConfig _flash;
        private ScaleConfig _scale;

        public RotateConfig Rotation { get => _rotation; set => Rotation = value; }
        public FlashConfig Flash { get => _flash; set => Flash = value; }
        public ScaleConfig Scale { get => _scale; set => Scale = value; }

        public Animate()
        {
            _scale = new ScaleConfig(0);
            _rotation = new RotateConfig(0);
            _flash = new FlashConfig(0);

            ToolForm = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Animate!",
                Margin = new Thickness(5)
            };
        }

        public override void MouseDownHandler(Point point, ViewPort vp)
        {
            Figure selectLayout = new Rectangle(point, point, PenPicker.GetPen(typeof(DashPen)).GetPen(Colors.Black, 3), new SolidColorBrush());
            selectLayout.ToLocalSpace(vp);

            PaintController.figures.AddLast(selectLayout);
            currentState = States.mouseClick;
        }

        public override void MouseMoveHandler(Point point, ViewPort vp)
        {
            if (currentState == States.mouseClick)
            {
                PaintController.figures.Last.Value.EditSize(point, vp);
            }
        }

        public override void MouseUpHandler(ViewPort vp)
        {
            currentState = States.initial;
            StartPoint = PaintController.figures.Last.Value.firstPoint;
            EndPoint = PaintController.figures.Last.Value.secondPoint;
            PaintController.figures.RemoveLast();
            MakeAnimation();
        }

        private void MakeAnimation()
        {
            foreach (var shape in PaintController.figures)
            {
                if (shape.CheckIntersection(StartPoint, EndPoint))
                {
                    if (Rotation.RotationValue != 0)
                    {
                        shape.AddAnim(new RotationAnimation(Rotation.RotationValue));
                    }
                    if (Flash.FlashValue != 0)
                    {
                        shape.AddAnim(new FlashAnimation(Flash.FlashValue));
                    }
                    if (Scale.ScaleValue != 0)
                    {
                        shape.AddAnim(new ScaleAnimation(Scale.ScaleValue));
                    }
                }
            }
        }
    }
}
